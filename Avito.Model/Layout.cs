using System;

namespace Avito.Model
{
    public class Layout
    {
        public int? WindowState;
        public int? Top;
        public int? Left;
        public int? Width;
        public int? Height;
        public int MinPrice;
        public int MaxPrice;
        public DateTime DatesAfter;
        public int PagesPerSet;
        public string SearchText;
        public string SearchTextExclude;
        public int LastPageCount;
        public int LastResultCount;
        public bool InvertSorting;
        public bool SortByDate;
        public WebSearchResult[] Results;

        public static Layout Default
        {
            get
            {
                Layout layout = new Layout();
                layout.MinPrice = 0;
                layout.MaxPrice = 0;
                layout.DatesAfter = DateTime.Now.AddDays(-7);
                layout.PagesPerSet = 1;
                layout.SearchText = "";
                layout.SearchTextExclude = "";
                layout.LastPageCount = 0;
                layout.LastResultCount = 0;
                layout.InvertSorting = false;
                layout.SortByDate = true;
                layout.Results = new WebSearchResult[0];
                return layout;
            }
        }
    }
}