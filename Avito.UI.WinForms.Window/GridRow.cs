using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Avito.Model;
using Shared.Utils.Desktop;

namespace AvitoSearch
{
    public class GridRow : DataGridViewRow
    {
        public GridRow()
        {
            Height = 64;
        }

        public GridRow(WebSearchResult webSearchResult, int count) : this()
        {
            HeaderCell.Value = $"{count + 1}";

            Cells.Add(new DataGridViewTextBoxCell());
            Cells[0].Style.BackColor = webSearchResult.IsVIPad ? Color.DarkOrange : Color.White;

            DataGridViewTextBoxCell dateCell = new DataGridViewTextBoxCell() { Value = webSearchResult.Date.ToString(CultureInfo.CurrentUICulture) };
            Cells.Add(dateCell);
            dateCell.Style.BackColor = webSearchResult.IsHighlighted ? Color.Lavender : Color.White;

            if (webSearchResult.ImageBinary == null && webSearchResult.ImageBase64 != null)
            {
                webSearchResult.ImageBinary = ImageUtil.Base64StringToImage(webSearchResult.ImageBase64);
            }
            Cells.Add(new DataGridViewImageCell() { Value = (Image)webSearchResult.ImageBinary });
            DataGridViewLinkCell linkCell = new DataGridViewLinkCell
            {
                Value = webSearchResult.Title.Text,
                Tag = webSearchResult.Title.Url
            };
            Cells.Add(linkCell);
            Cells.Add(new DataGridViewTextBoxCell() { Value = $"{webSearchResult.Price:C}" });
            Cells.Add(new DataGridViewTextBoxCell() { Value = webSearchResult.Category });
            Cells.Add(new DataGridViewTextBoxCell() { Value = webSearchResult.Address });
        }
    }
}
