using System;
using System.Collections.Generic;
using System.IO;
using Avito.Model;
using Avito.Search;
using Avito.UI.Interfaces;
using Shared.Utils.Desktop;
using Shared.Utils.Lib.Entities.String;

namespace Avito.UI.PresentationLogic
{
    public abstract class BaseMainFormPresenter
    {
        private readonly AvitoSettings _settings;
        private readonly IMainForm _form;
        private readonly IFileProvider _fileProvider;
        private int _totalPages;
        private int _parsedPages;

        protected BaseMainFormPresenter(AvitoSettings settings, IMainForm form, IFileProvider fileProvider)
        {
            _settings = settings;
            _form = form;
            _fileProvider = fileProvider;
            _form.LoadLayoutFromFile += OnLoadLayoutFromFile;
            _form.FormLoaded += OnFormLoaded;
            _form.Search += OnSearch;
            _form.SearchNext += OnSearchNext;
            _form.SaveLayoutAsFile += OnSaveLayoutAsFile;
            _form.SaveLayoutToDefaultFile += OnSaveLayoutToDefaultFile;
            _form.ResetLayoutToDefault += OnResetLayoutToDefault;
            _form.SortBy += OnSortBy;
        }

        #region Event handler

        private void OnFormLoaded(object sender, EventArgs e)
        {
            _form.SearchStartFrom = DateTime.Today.AddDays(-1);
            using (Stream stream = GetDefaultLayoutStreamRead())
            {
                LoadLayoutFromStream(stream);
            }
        }

        private void OnSearch(object sender, EventArgs e)
        {
            _totalPages = 0;
            _parsedPages = 0;
            _form.PageCount = 0;
            _form.ResultCount = 0;
            _form.CanSearchNext = false;
            object state = _form.BeginSearching();
            try
            {
                Layout layout = _form.GetLayout();
                if (new IsEmptyString(layout.SearchText))
                {
                    return;
                }
                WebPageInfo pageInfo = new AvitoPage(_settings, new AvitoPageRequest(_settings, layout.SearchText)).Info();
                if (pageInfo.PageCount == 0)
                {
                    return;
                }

                _form.PageCount = _totalPages = pageInfo.PageCount;
                for (int i = 1; i <= layout.PagesPerSet; i++)
                {
                    _parsedPages++;
                    if (_parsedPages > _totalPages)
                    {
                        return;
                    }
                    List<WebSearchResult> newResults = SearchOnPage(i, layout);
                    for (int j = 0; j < newResults.Count; j++)
                    {
                        _form.ResultCount++;
                        _form.AddResultEntry(newResults[j]);
                    }
                }
            }
            finally
            {
                _form.EndSearching(state);
                _form.CanSearchNext = _parsedPages < _totalPages;
                SortBy();
            }
        }

        private void OnSearchNext(object sender, EventArgs e)
        {
            object state = _form.BeginSearchingNext();
            _form.CanSearchNext = false;
            try
            {
                Layout layout = _form.GetLayout();
                foreach (WebSearchResult result in layout.Results)
                {
                    result.IsHighlighted = false;
                }
                int startIndex = 1 + _parsedPages;
                int endIndex = startIndex + layout.PagesPerSet - 1;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    _parsedPages++;
                    if (_parsedPages > _totalPages)
                    {
                        return;
                    }
                    List<WebSearchResult> newResults = SearchOnPage(i, layout);
                    for (int j = 0; j < newResults.Count; j++)
                    {
                        _form.ResultCount++;
                        newResults[j].IsHighlighted = true;
                        _form.AddResultEntry(newResults[j]);
                    }
                }
            }
            finally
            {
                _form.EndSearchingNext(state);
                _form.CanSearchNext = true;
                _form.CanSearchNext = _parsedPages < _totalPages;
            }
            SortBy();
        }

        private void OnSaveLayoutAsFile(object sender, EventArgs e)
        {
            using (Stream stream = _fileProvider.CreateFile())
            {
                if (stream == Stream.Null)
                {
                    return;
                }
                SaveLayoutToStream(stream);
            }
        }

        private void OnSaveLayoutToDefaultFile(object sender, EventArgs e)
        {
            using (Stream stream = GetDefaultLayoutStreamWrite())
            {
                SaveLayoutToStream(stream);
            }
        }

        private void OnResetLayoutToDefault(object sender, EventArgs e)
        {
            _form.ApplyLayout(Layout.Default);
            SortBy();
        }

        private void OnSortBy(object sender, EventArgs e)
        {
            SortBy();
        }

        private void OnLoadLayoutFromFile(object sender, EventArgs e)
        {
            using (Stream stream = _fileProvider.OpenFile())
            {
                if (stream == Stream.Null)
                {
                    return;
                }
                LoadLayoutFromStream(stream);
            }
        }

        #endregion

        #region Protected method

        protected abstract Stream GetDefaultLayoutStreamRead();
        
        protected abstract Stream GetDefaultLayoutStreamWrite();

        #endregion

        #region Private method

        private void LoadLayoutFromStream(Stream stream)
        {
            object state = _form.BeginLoadingLayout();
            try
            {
                _form.ApplyLayout(LayoutUtil.StreamToLayout(stream) ?? Layout.Default);
                _form.BeginSorting();
                SortBy();
            }
            finally
            {
                _form.EndLoadingLayout(state);
            }
        }

        private void SaveLayoutToStream(Stream stream)
        {
            object state = _form.BeginSavingLayout();
            try
            {
                Layout layout = _form.GetLayout();
                LayoutUtil.LayoutToStream(layout, stream);
            }
            finally
            {
                _form.EndSavingLayout(state);
            }
        }

        private List<WebSearchResult> SearchOnPage(int pageNumber, Layout layout)
        {
            AvitoPage page = new AvitoPage(_settings, new AvitoPageRequest(_settings, pageNumber, layout.SearchText));
            List<WebSearchResult> results = new List<WebSearchResult>();
            Filter filter = new Filter();
            string[] titleContains = layout.SearchText.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < titleContains.Length; i++)
            {
                titleContains[i] = new LowerText(new TrimText(titleContains[i]));
            }
            filter.TitleContains = titleContains;
            string[] titleDoesNotContain = layout.SearchTextExclude.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < titleDoesNotContain.Length; i++)
            {
                titleDoesNotContain[i] = new LowerText(new TrimText(titleDoesNotContain[i]));
            }
            filter.TitleDoesNotContain = titleDoesNotContain;
            filter.MinPrice = layout.MinPrice;
            filter.MaxPrice = layout.MaxPrice < 1 ? int.MaxValue : layout.MaxPrice;
            filter.DatesAfter = layout.DatesAfter;
            var webSearchResults = page.GetResults(filter);
            foreach (var result in webSearchResults)
            {
                if (result.ImageUrl != null)
                {
                    var image = ImageUtil.GetImage(result.ImageUrl).GetThumbnailImage(100, 70, null, IntPtr.Zero);
                    result.ImageBase64 = ImageUtil.ImageToBase64String(image);
                }
            }
            results.AddRange(webSearchResults);
            return results;
        }

        private void SortBy()
        {
            Layout layout = _form.GetLayout();
            List<WebSearchResult> list = new List<WebSearchResult>();
            foreach (WebSearchResult resultEntry in layout.Results)
            {
                list.Add(resultEntry);
            }
            if (layout.SortByDate)
            {
                list.Sort(new DateComparer(layout.InvertSorting));
            }
            else
            {
                list.Sort(new PriceComparer(layout.InvertSorting));
            }
            _form.UpdateResults(list);
        }

        #endregion
    }
}