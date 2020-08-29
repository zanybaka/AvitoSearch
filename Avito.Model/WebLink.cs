namespace Avito.Model
{
    public struct WebLink
    {
        private string url;
        private string text;

        public WebLink(string url, string text)
        {
            this.url = url;
            this.text = text;
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
    }
}