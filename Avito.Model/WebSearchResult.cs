using System;
using System.Xml.Serialization;

namespace Avito.Model
{
    public sealed class WebSearchResult
    {
        private DateTime date;
        private string imageUrl;
        private object image;
        private WebLink title;
        private int? price;
        private string category;
        private string address;
        private string imageData;
        private bool isVIPad;
        private bool isHighlighted;

        public bool IsVIPad
        {
            get { return isVIPad; }
            set { isVIPad = value; }
        }

        public bool IsHighlighted
        {
            get { return isHighlighted; }
            set { isHighlighted = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }

        public string ImageBase64
        {
            get { return imageData; }
            set { imageData = value; }
        }

        [XmlIgnore]
        public object ImageBinary
        {
            get { return image; }
            set { image = value; }
        }

        public WebLink Title
        {
            get { return title; }
            set { title = value; }
        }

        public int? Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}