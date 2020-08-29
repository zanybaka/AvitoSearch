using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Avito.Model;
using HtmlAgilityPack;
using Shared.Utils.Lib.Entities.String;
using Shared.Utils.Lib.Utils;
using Shared.Utils.Web.Entities.Html;

namespace Avito.Search
{
    public class AvitoPage
    {
        private readonly AvitoSettings _settings;
        private readonly AvitoPageRequest _request;
        private readonly Lazy<string> _content;

        public AvitoPage(AvitoSettings settings, AvitoPageRequest request)
        {
            _settings = settings;
            _request = request;
            _content = new Lazy<string>(
                () =>
                    new WebPage(_request.GetUrl())
                        .GetContent(Encoding.UTF8));
        }

        public List<WebSearchResult> GetResults(Filter filter)
        {
            List<WebSearchResult> results = new List<WebSearchResult>();
            
            HtmlNode node = new HtmlToHtmlNode(_content.Value);
            if (node == null)
            {
                Log.Error("Can't parse content. Invalid HtmlNode.");
                return results;
            }

            // <div class="snippet-date-info" data-marker="item-date" data-shape="default" data-tooltip="27 августа 14:12" flow="down">
            // 2 дня назад
            // </div>
            HtmlNodeCollection dates = node.SelectNodes("//div[@data-marker='item-date']");
            if (dates == null)
            {
                Log.Error("Can't parse dates. Unexpected html structure.");
                return results;
            }

            DateTime prevDate = DateTime.Today;
            foreach (HtmlNode dateNode in dates)
            {
                // <div class="description item_table-description">
                // <div class="snippet-title-row">...
                HtmlNode entryNode = dateNode.ParentNode.ParentNode.ParentNode;
                HtmlNode titleANode = entryNode.SelectSingleNode(".//div[contains(@class,'snippet-title-row')]/h3/a");
                WebLink titleValue = GetTitleValue(titleANode);
                string title = new LowerText(titleValue.Text);
                bool @break = false;
                foreach (string contains in filter.TitleContains)
                {
                    if (!title.Contains(contains))
                    {
                        @break = true;
                        break;
                    }
                }
                if (@break)
                {
                    continue;
                }

                foreach (string contains in filter.TitleDoesNotContain)
                {
                    if (title.Contains(contains))
                    {
                        @break = true;
                        break;
                    }
                }
                if (@break)
                {
                    continue;
                }

                DateTime? dateValue = AvitoParser.GetDateValue(dateNode.InnerText, prevDate, DateTime.Now);
                if (dateValue == null || dateValue < filter.DatesAfter)
                {
                    continue;
                }

                // <div class="snippet-price-row"><span itemprop="offers" itemtype="http://schema.org/Offer" itemscope="" class="snippet-price " data-shape="default" data-marker="item-price"><meta itemprop="priceCurrency" content="RUB"><meta itemprop="price" content="6490"><meta itemprop="availability" content="https://schema.org/LimitedAvailability">
                // 6 490  ₽
                HtmlNode priceNode = entryNode.SelectSingleNode(".//span[@data-marker='item-price']");
                int? priceValue = AvitoParser.GetPriceValue(priceNode?.InnerText);
                if (priceValue != null)
                {
                    if (priceValue < filter.MinPrice || priceValue > filter.MaxPrice)
                    {
                        continue;
                    }
                }

                bool isVIPad = priceNode.ParentNode.ParentNode.GetAttributeValue("class", "") == "options" && priceNode.ParentNode.ParentNode.GetAttributeValue("itemprop", "") == "offers";

                // <div class="data">
                // <p>Часы и украшения</p>
                HtmlNode categoryNode = entryNode.SelectSingleNode(".//div[@class='data']/p");

                // <span class="item-address-georeferences-item__content">Комендантский проспект</span>
                HtmlNode addressNode = entryNode.SelectSingleNode(".//span[@class='item-address-georeferences-item__content']");

                // <div class="item-photo" data-marker="item-photo">
                HtmlNode imgNode = entryNode.ParentNode.ParentNode.SelectSingleNode(".//div[@data-marker='item-photo']");
                imgNode = imgNode?.SelectSingleNode(".//img");

                if (isVIPad)
                {
                    if (imgNode == null)
                    {
                        imgNode = entryNode.ParentNode.ParentNode.SelectSingleNode(".//div[@class='img-container']");
                        imgNode = imgNode?.SelectSingleNode(".//img");
                    }
                }

                WebSearchResult result = new WebSearchResult();
                result.Title = titleValue;
                result.IsVIPad = isVIPad;
                result.Date = dateValue.Value;
                prevDate = result.Date.Date;
                result.Category = AvitoParser.GetCategoryValue(categoryNode?.InnerText);
                result.Address = AvitoParser.GetAddressValue(addressNode?.InnerText);
                result.ImageUrl = GetImageUrl(imgNode);
                result.Price = priceValue;
                results.Add(result);
            }

            return results;
        }

        public WebPageInfo Info()
        {
            if (_content.Value == null)
            {
                return new WebPageInfo(0) ;
            }

            HtmlNode node = new HtmlToHtmlNode(_content.Value);
            if (node == null)
            {
                return new WebPageInfo(0) ;
            }

            // <a class="pagination-page" href="/sankt-peterburg?p=100&amp;q=watch">Последняя</a>
            HtmlNode a = node.SelectNodes("//a[@class='pagination-page']")?.LastOrDefault();
            if (a == null)
            {
                return new WebPageInfo(1) ;
            }

            string href = a.GetAttributeValue("href", null);
            if (href == null)
            {
                Log.Error("[AvitoPage:Info] Can't parse the next page number");
                return new WebPageInfo(0) ;
            }

            Regex regex = new Regex(@"p=(\d*)&");
            string value = regex.Match(href).Groups[1].Value;
            int pageCount = int.Parse(value);

            return new WebPageInfo(pageCount);

            /*
                Regex regex = new Regex(@"(?inx)
                <a \s [^>]*
                    class=""pagination-page"" [^>]* \s
                    href \s* = \s*
                        (?<q> ['""] )
                            [^""]+ \?p=(?<p>\d+) [^""]+
                        \k<q>
                [^>]* >");

                MatchCollection matches = regex.Matches(_content.Value);
                if (matches.Count == 0)
                {
                    Log.Info("[AvitoPage:Info] Can't parse the next page number");
                    return new WebPageInfo(1);
                }

                Group pageCount = matches[matches.Count - 1].Groups["p"];
                return new WebPageInfo(int.Parse(pageCount.Value));
            */
        }

        internal WebLink GetTitleValue(HtmlNode aNode)
        {
            string url = _settings.UrlPrefix + aNode.GetAttributeValue("href", "parse error");
            string title = AvitoParser.GetTitleValue(aNode.InnerText);
            return new WebLink(url, title);
        }

        internal string GetImageUrl(HtmlNode imgNode)
        {
            if (imgNode == null)
            {
                return null;
            }

            var url = imgNode.GetAttributeValue("data-srcset", null);
            if (url != null)
            {
                return url.Substring(0, url.IndexOf(' '));
            }

            return imgNode.GetAttributeValue("src", "parse error");
        }
    }
}