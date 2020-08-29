using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Avito.Model;
using Avito.Search;
using Avito.UI.Interfaces;
using Avito.UI.WinForms.Logic;
using ComponentFactory.Krypton.Toolkit;

namespace AvitoSearch
{
    public partial class MainForm : Form, IMainForm
    {
        #region Events and fields

        public event EventHandler Search;
        public event EventHandler SearchNext;
        public event EventHandler LoadLayoutFromFile;
        public event EventHandler FormLoaded;
        public event EventHandler SaveLayoutAsFile;
        public event EventHandler SaveLayoutToDefaultFile;
        public event EventHandler ResetLayoutToDefault;
        public event EventHandler SortBy;

        private KryptonContextMenuItem loadLayout;
        private KryptonContextMenuItem saveLayout;
        private KryptonContextMenuItem saveAsLayout;
        private KryptonContextMenuItem resetLayout;

        private IMainFormPresenter presenter;
        private int pageCount;
        private int resultCount;
        private DataTable table = new DataTable();

        #endregion

        #region Public property

        public int PageCount
        {
            get => pageCount;
            set
            {
                if (value <= 0)
                {
                    pageCount = 0;
                    results.ValuesSecondary.Heading = "";
                    return;
                }

                pageCount = value;
                results.ValuesSecondary.Heading = $"Total pages: {pageCount}; results: {(resultCount == 0 ? "?" : resultCount.ToString())}";
                Application.DoEvents();
            }
        }

        public int ResultCount
        {
            get => resultCount;
            set
            {
                if (value <= 0)
                {
                    resultCount = 0;
                    results.ValuesSecondary.Heading = "";
                    return;
                }

                resultCount = value;
                results.ValuesSecondary.Heading = $"Total pages: {pageCount}; results: {(resultCount == 0 ? "?" : resultCount.ToString())}";
                Application.DoEvents();
            }
        }

        public bool CanSearchNext
        {
            get => btnSearchNext.Enabled;
            set => btnSearchNext.Enabled = value;
        }

        public DateTime? SearchStartFrom
        {
            get
            {
                if (!datesAfter.Checked)
                {
                    return DateTime.MinValue;
                }

                return datesAfter.Value;
            }
            set
            {
                if (value == null)
                {
                    datesAfter.Value = datesAfter.CalendarTodayDate;
                    datesAfter.Checked = false;
                    return;
                }

                datesAfter.Checked = true;
                datesAfter.Value = value.Value;
            }
        }

        #endregion

        #region Ctor

        public MainForm()
        {
            InitializeComponent();

            loadLayout = new KryptonContextMenuItem("Load Layout", (sender, e) => LoadLayoutFromFile?.Invoke(sender, e));
            loadLayout.Image = Resources.Properties.Images.load32;
            menuLayout.RibbonAppButton.AppButtonMenuItems.Add(loadLayout);
            saveLayout = new KryptonContextMenuItem("Save Layout", (sender, e) => SaveLayoutToDefaultFile?.Invoke(sender, e));
            saveLayout.Image = Resources.Properties.Images.save32;
            menuLayout.RibbonAppButton.AppButtonMenuItems.Add(saveLayout);
            saveAsLayout = new KryptonContextMenuItem("Save Layout As", (sender, e) => SaveLayoutAsFile?.Invoke(sender, e));
            saveAsLayout.Image = Resources.Properties.Images.save32;
            menuLayout.RibbonAppButton.AppButtonMenuItems.Add(saveAsLayout);
            resetLayout = new KryptonContextMenuItem("Reset Layout", (sender, e) => ResetLayoutToDefault?.Invoke(sender, e));
            resetLayout.Image = Resources.Properties.Images.reset32;
            menuLayout.RibbonAppButton.AppButtonMenuItems.Add(resetLayout);

            btnInvertSorting.ImageLarge = Resources.Properties.Images.invert64_color;
            btnInvertSorting.ImageSmall = Resources.Properties.Images.invert64_color;

            resultsGrid.Columns["columnDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            resultsGrid.Columns["columnPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            resultsGrid.CellContentClick += ResultsGridOnCellContentClick;

            presenter = new WinFormsMainFormPresenter(new AvitoSettings(), this);
        }

        private void ResultsGridOnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (resultsGrid.Rows[0].Cells["columnLink"].ColumnIndex == e.ColumnIndex)
            {
                object tag = resultsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
                if (tag != null)
                {
                    Process.Start(tag.ToString());
                }
            }
        }

        #endregion

        #region Public method

        public void ApplyLayout(Layout layout)
        {
            Width = layout.Width == null || layout.Width < MinimumSize.Width ? MinimumSize.Width : layout.Width.Value;
            Height = layout.Height == null || layout.Height < MinimumSize.Height ? MinimumSize.Height : layout.Height.Value;
            WindowState = layout.WindowState == null ? FormWindowState.Normal : (FormWindowState) layout.WindowState;
            if (layout.Top != null) Top = layout.Top.Value;
            if (layout.Left != null) Top = layout.Left.Value;
            udMinPrice.Value = layout.MinPrice;
            udMaxPrice.Value = layout.MaxPrice;
            datesAfter.Value = layout.DatesAfter.Date;
            upPagesPerSet.Value = layout.PagesPerSet;
            tbContains.Text = layout.SearchText;
            tbExclude.Text = layout.SearchTextExclude;
            PageCount = layout.LastPageCount;
            ResultCount = layout.LastResultCount;
            btnInvertSorting.Checked = layout.InvertSorting;
            btnSortByDate.Checked = layout.SortByDate;
            UpdateResults(layout.Results);
            Application.DoEvents();
        }

        public Layout GetLayout()
        {
            Layout layout = new Layout();
            layout.WindowState = (int) WindowState;
            layout.Top = Top;
            layout.Left = Left;
            layout.Width = Width;
            layout.Height = Height;
            layout.DatesAfter = datesAfter.Value.Date.AddDays(1).AddSeconds(-1);
            layout.MinPrice = (int)udMinPrice.Value;
            layout.MaxPrice = (int)udMaxPrice.Value;
            layout.SearchText = tbContains.Text;
            layout.SearchTextExclude = tbExclude.Text;
            layout.PagesPerSet = (int)upPagesPerSet.Value;
            layout.LastPageCount = pageCount;
            layout.LastResultCount = resultCount;
            layout.InvertSorting = btnInvertSorting.Checked;
            layout.SortByDate = btnSortByDate.Checked;
            layout.Results = new WebSearchResult[resultsGrid.Rows.Count];
            for (int i = 0; i < resultsGrid.Rows.Count; i++)
            {
                WebSearchResult result = (WebSearchResult)resultsGrid.Rows[i].Tag;
                layout.Results[i] = result;
            }
            return layout;
        }

        public void AddResultEntry(WebSearchResult newResult)
        {
            GridRow row = new GridRow(newResult, resultsGrid.Rows.Count);
            row.Tag = newResult;
            resultsGrid.Rows.Add(row);
        }

        public object BeginSearching()
        {
            string state = Text;
            menuLayout.Enabled = false;
            Text = "Searching...";
            resultsGrid.Rows.Clear();
            return state;
        }

        public void EndSearching(object state)
        {
            Text = (string)state;
            menuLayout.Enabled = true;
        }

        public void UpdateResults(IEnumerable<WebSearchResult> items)
        {
            resultsGrid.Rows.Clear();
            foreach (WebSearchResult result in items)
            {
                AddResultEntry(result);
            }
        }

        public object BeginLoadingLayout()
        {
            string text = Text;
            Text = "Loading layout...";
            Application.DoEvents();
            return text;
        }

        public void EndLoadingLayout(object state)
        {
            Text = (string)state;
            Application.DoEvents();
        }

        public object BeginSorting()
        {
            string text = Text;
            Text = "Sorting...";
            Application.DoEvents();
            return text;
        }

        public object BeginSavingLayout()
        {
            string text = Text;
            Text = "Saving...";
            saveLayout.Enabled = false;
            Application.DoEvents();
            return text;
        }

        public void EndSavingLayout(object state)
        {
            Text = (string)state;
            saveLayout.Enabled = true;
            Application.DoEvents();
        }

        public object BeginSearchingNext()
        {
            string text = Text;
            Text = "Searching...";
            menuLayout.Enabled = false;
            Application.DoEvents();
            return text;
        }

        public void EndSearchingNext(object state)
        {
            Text = (string)state;
            menuLayout.Enabled = true;
            Application.DoEvents();
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            FormLoaded?.Invoke(sender, e);
        }

        private void kryptonRibbonGroupButton3_Click(object sender, EventArgs e)
        {
            Search?.Invoke(sender, e);
        }

        private void kryptonRibbonGroupButton4_Click(object sender, EventArgs e)
        {
            SearchNext?.Invoke(sender, e);
        }

        private void kryptonRibbonGroupButton3_Click_1(object sender, EventArgs e)
        {
            SortBy?.Invoke(sender, e);
        }

        private void btnSortByPrice_Click(object sender, EventArgs e)
        {
            btnSortByDate.Checked = !btnSortByPrice.Checked;

            SortBy?.Invoke(sender, e);
        }

        private void btnSortByDate_Click(object sender, EventArgs e)
        {
            btnSortByPrice.Checked = !btnSortByDate.Checked;

            SortBy?.Invoke(sender, e);
        }

        private void btnSort_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Checked")
            {
                btnSortByDate.ImageSmall = btnSortByDate.ImageLarge = !btnInvertSorting.Checked ? Resources.Properties.Images.sortDate64 : Resources.Properties.Images.sortDate64_invert;
                btnSortByPrice.ImageSmall = btnSortByPrice.ImageLarge = !btnInvertSorting.Checked ? Resources.Properties.Images.sortPrice_64 : Resources.Properties.Images.sortPrice64_invert;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            results.Width = Width - 16;
            results.Height = Height - 38 - menuLayout.Height;
        }
    }
}