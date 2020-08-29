using System;

namespace Avito.Model
{
    public class Filter
    {
        public string[] TitleContains = new string[0];
        public string[] TitleDoesNotContain = new string[0];
        public int MinPrice;
        public int MaxPrice;
        public DateTime DatesAfter;

        public Filter()
        {
            MaxPrice = int.MaxValue;
        }
    }
}