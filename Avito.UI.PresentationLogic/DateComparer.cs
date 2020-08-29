using System.Collections.Generic;
using Avito.Model;

namespace Avito.UI.PresentationLogic
{
    public class DateComparer : IComparer<WebSearchResult>
    {
        private readonly int invert;

        public DateComparer(bool invert)
        {
            this.invert = invert ? -1 : 1;
        }

        public int Compare(WebSearchResult x, WebSearchResult y)
        {
            return x.Date.CompareTo(y.Date) * invert;
        }
    }
}