using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace Shared.Utils.Desktop
{
    public class ImageUtil
    {
        public static Image GetImage(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (Stream stream = httpWebReponse.GetResponseStream())
            {
                if (stream == null)
                {
                    return null;
                }

                return Image.FromStream(stream);
            }
        }

        public static string ImageToBase64String(Image image)
        {
            if (image == null)
            {
                return null;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                byte[] array = ms.ToArray();
                return Convert.ToBase64String(array);
            }
        }

        public static Image Base64StringToImage(string imageString)
        {
            if (imageString == null)
            {
                return null;
            }
            byte[] array = Convert.FromBase64String(imageString);
            using (MemoryStream ms = new MemoryStream(array))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }
    }
}