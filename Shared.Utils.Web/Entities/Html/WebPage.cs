using System;
using System.IO;
using System.Net;
using System.Text;

namespace Shared.Utils.Web.Entities.Html
{
    public class WebPage
    {
        private readonly string _url;
        private const int DefaultTimeoutSec = 30;

        public WebPage(string url)
        {
            _url = url;
        }

        public string GetContent()
        {
            return GetContent(null, null, null, null, null);
        }

        public string GetContent(Encoding encoding)
        {
            return GetContent(null, null, null, null, encoding);
        }

        public string GetContent(string proxyHost, int? proxyPort, Encoding encoding)
        {
            return GetContent(proxyHost, proxyPort, null, null, encoding);
        }

        public string GetContent(string proxyHost, int? proxyPort, string cookies, int? timeOut, Encoding encoding)
        {
            WebRequest request = WebRequest.Create(_url);
            
            if (proxyHost != null && proxyPort != null)
            {
                request.Proxy = new WebProxy(proxyHost, proxyPort.Value);
            }

            if (cookies != null)
            {
                request.Headers.Add(HttpRequestHeader.Cookie, cookies);
            }

            if (timeOut == null)
            {
                timeOut = 1000 * DefaultTimeoutSec;
            }

            request.Timeout = timeOut.Value;

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException)
            {
                return null;
            }
            Stream stream = response.GetResponseStream();
            if (stream == null)
            {
                throw new InvalidOperationException("Response stream is null.");
            }

            if (encoding == null)
            {
                encoding = Encoding.GetEncoding(1251);
            }
            
            StreamReader reader = new StreamReader(stream, encoding);
            string content = reader.ReadToEnd();
            return content;
        }
    }
}