using System.Collections.Generic;
using Avito.Model;

namespace Avito.UI.PresentationLogic
{
    public class PriceComparer : IComparer<WebSearchResult>
    {
        private readonly int invert;

        public PriceComparer(bool invert)
        {
            this.invert = invert ? -1 : 1;
        }

        public int Compare(WebSearchResult x, WebSearchResult y)
        {
            bool a = x.Price == null;
            bool b = y.Price == null;
            if (a || b)
            {
                return a && b ? (x.Date.CompareTo(y.Date) * invert) : a ? -1 * invert : 1 * invert;
            }

            int compareTo = x.Price.Value.CompareTo(y.Price.Value);
            return compareTo == 0 ? (x.Date.CompareTo(y.Date) * invert) : compareTo * invert;
        }
    }
}