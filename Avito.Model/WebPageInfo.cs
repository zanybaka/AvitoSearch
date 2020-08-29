namespace Avito.Model
{
    public sealed class WebPageInfo
    {
        private int pageCount;

        public WebPageInfo(int pageCount)
        {
            this.pageCount = pageCount;
        }

        public int PageCount
        {
            get { return pageCount; }
            set { pageCount = value; }
        }
    }
}