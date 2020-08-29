using System.IO;
using System.Xml.Serialization;
using Avito.Model;

namespace Avito.UI.PresentationLogic
{
    public static class LayoutUtil
    {
        public static Layout StreamToLayout(Stream stream)
        {
            if (stream == null || stream == Stream.Null)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Layout));
            Layout layout = (Layout)serializer.Deserialize(stream);
            return layout;
        }
        
        public static void LayoutToStream(Layout layout, Stream stream)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Layout));
            ser.Serialize(stream, layout);
        }
    }
}