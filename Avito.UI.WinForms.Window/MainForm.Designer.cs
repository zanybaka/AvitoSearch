namespace AvitoSearch
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuLayout = new ComponentFactory.Krypton.Ribbon.KryptonRibbon();
            this.kryptonRibbonTab1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.subjectGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.textLine = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines();
            this.kryptonRibbonGroupLabel5 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel();
            this.tbContains = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTextBox();
            this.kryptonRibbonGroupLabel6 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel();
            this.tbExclude = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTextBox();
            this.priceGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupLines1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines();
            this.kryptonRibbonGroupLabel1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel();
            this.udMinPrice = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupNumericUpDown();
            this.kryptonRibbonGroupLabel2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel();
            this.udMaxPrice = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupNumericUpDown();
            this.resultGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.Group2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines();
            this.kryptonRibbonGroupLabel3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel();
            this.datesAfter = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupDateTimePicker();
            this.kryptonRibbonGroupLabel4 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel();
            this.upPagesPerSet = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupNumericUpDown();
            this.actionGroup = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnSearch = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnSearchNext = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupSeparator1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator();
            this.kryptonRibbonGroupTriple2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnInvertSorting = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnSortByPrice = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.btnSortByDate = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.results = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.resultsGrid = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.columnVIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.columnLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.columnPrice = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.columnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.menuLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.results)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.results.Panel)).BeginInit();
            this.results.Panel.SuspendLayout();
            this.results.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuLayout
            // 
            this.menuLayout.InDesignHelperMode = false;
            this.menuLayout.Name = "menuLayout";
            this.menuLayout.QATLocation = ComponentFactory.Krypton.Ribbon.QATLocation.Hidden;
            this.menuLayout.QATUserChange = false;
            this.menuLayout.RibbonAppButton.AppButtonShowRecentDocs = false;
            this.menuLayout.RibbonAppButton.AppButtonText = "Layout";
            this.menuLayout.RibbonTabs.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab[] {
            this.kryptonRibbonTab1});
            this.menuLayout.SelectedTab = this.kryptonRibbonTab1;
            this.menuLayout.Size = new System.Drawing.Size(1503, 159);
            this.menuLayout.TabIndex = 6;
            // 
            // kryptonRibbonTab1
            // 
            this.kryptonRibbonTab1.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.subjectGroup,
            this.priceGroup,
            this.resultGroup,
            this.actionGroup});
            this.kryptonRibbonTab1.KeyTip = "F";
            this.kryptonRibbonTab1.Text = "Filter";
            // 
            // subjectGroup
            // 
            this.subjectGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.textLine});
            this.subjectGroup.TextLine1 = "Subject";
            // 
            // textLine
            // 
            this.textLine.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupLabel5,
            this.tbContains,
            this.kryptonRibbonGroupLabel6,
            this.tbExclude});
            // 
            // kryptonRibbonGroupLabel5
            // 
            this.kryptonRibbonGroupLabel5.TextLine1 = "Text contains";
            // 
            // tbContains
            // 
            this.tbContains.MaximumSize = new System.Drawing.Size(180, 0);
            this.tbContains.MinimumSize = new System.Drawing.Size(180, 0);
            this.tbContains.Text = "";
            // 
            // kryptonRibbonGroupLabel6
            // 
            this.kryptonRibbonGroupLabel6.TextLine1 = "Doesn\'t contain";
            // 
            // tbExclude
            // 
            this.tbExclude.MaximumSize = new System.Drawing.Size(164, 0);
            this.tbExclude.MinimumSize = new System.Drawing.Size(164, 0);
            this.tbExclude.Text = "";
            // 
            // priceGroup
            // 
            this.priceGroup.AllowCollapsed = false;
            this.priceGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupLines1});
            this.priceGroup.KeyTipGroup = "P";
            this.priceGroup.TextLine1 = "Price";
            // 
            // kryptonRibbonGroupLines1
            // 
            this.kryptonRibbonGroupLines1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupLabel1,
            this.udMinPrice,
            this.kryptonRibbonGroupLabel2,
            this.udMaxPrice});
            this.kryptonRibbonGroupLines1.MinimumSize = ComponentFactory.Krypton.Ribbon.GroupItemSize.Large;
            // 
            // kryptonRibbonGroupLabel1
            // 
            this.kryptonRibbonGroupLabel1.TextLine1 = "Min";
            // 
            // udMinPrice
            // 
            this.udMinPrice.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udMinPrice.KeyTip = "N";
            this.udMinPrice.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.udMinPrice.MaximumSize = new System.Drawing.Size(100, 0);
            this.udMinPrice.MinimumSize = new System.Drawing.Size(100, 0);
            this.udMinPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udMinPrice.ThousandsSeparator = true;
            // 
            // kryptonRibbonGroupLabel2
            // 
            this.kryptonRibbonGroupLabel2.TextLine1 = "Max";
            // 
            // udMaxPrice
            // 
            this.udMaxPrice.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udMaxPrice.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.udMaxPrice.MaximumSize = new System.Drawing.Size(98, 0);
            this.udMaxPrice.MinimumSize = new System.Drawing.Size(98, 0);
            this.udMaxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // resultGroup
            // 
            this.resultGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.Group2});
            this.resultGroup.TextLine1 = "Result";
            // 
            // Group2
            // 
            this.Group2.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupLabel3,
            this.datesAfter,
            this.kryptonRibbonGroupLabel4,
            this.upPagesPerSet});
            // 
            // kryptonRibbonGroupLabel3
            // 
            this.kryptonRibbonGroupLabel3.TextLine1 = "Date ≥";
            // 
            // datesAfter
            // 
            this.datesAfter.CalendarCloseOnTodayClick = true;
            this.datesAfter.KeyTip = "D";
            this.datesAfter.ShowCheckBox = true;
            // 
            // kryptonRibbonGroupLabel4
            // 
            this.kryptonRibbonGroupLabel4.TextLine1 = "Pages per set";
            // 
            // upPagesPerSet
            // 
            this.upPagesPerSet.MaximumSize = new System.Drawing.Size(139, 0);
            this.upPagesPerSet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upPagesPerSet.MinimumSize = new System.Drawing.Size(139, 0);
            this.upPagesPerSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.upPagesPerSet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // actionGroup
            // 
            this.actionGroup.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple1,
            this.kryptonRibbonGroupSeparator1,
            this.kryptonRibbonGroupTriple2});
            this.actionGroup.TextLine1 = "Action";
            // 
            // kryptonRibbonGroupTriple1
            // 
            this.kryptonRibbonGroupTriple1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnSearch,
            this.btnSearchNext});
            // 
            // btnSearch
            // 
            this.btnSearch.ImageLarge = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageLarge")));
            this.btnSearch.ImageSmall = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageSmall")));
            this.btnSearch.TextLine1 = "Start";
            this.btnSearch.TextLine2 = "search";
            this.btnSearch.Click += new System.EventHandler(this.kryptonRibbonGroupButton3_Click);
            // 
            // btnSearchNext
            // 
            this.btnSearchNext.ImageLarge = ((System.Drawing.Image)(resources.GetObject("btnSearchNext.ImageLarge")));
            this.btnSearchNext.ImageSmall = ((System.Drawing.Image)(resources.GetObject("btnSearchNext.ImageSmall")));
            this.btnSearchNext.TextLine1 = "Search";
            this.btnSearchNext.TextLine2 = "next";
            this.btnSearchNext.Click += new System.EventHandler(this.kryptonRibbonGroupButton4_Click);
            // 
            // kryptonRibbonGroupTriple2
            // 
            this.kryptonRibbonGroupTriple2.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnInvertSorting,
            this.btnSortByPrice,
            this.btnSortByDate});
            // 
            // btnInvertSorting
            // 
            this.btnInvertSorting.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Check;
            this.btnInvertSorting.TextLine1 = "Invert sorting";
            this.btnInvertSorting.Click += new System.EventHandler(this.kryptonRibbonGroupButton3_Click_1);
            this.btnInvertSorting.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.btnSort_PropertyChanged);
            // 
            // btnSortByPrice
            // 
            this.btnSortByPrice.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Check;
            this.btnSortByPrice.TextLine1 = "Sort by price";
            this.btnSortByPrice.Click += new System.EventHandler(this.btnSortByPrice_Click);
            this.btnSortByPrice.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.btnSort_PropertyChanged);
            // 
            // btnSortByDate
            // 
            this.btnSortByDate.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Check;
            this.btnSortByDate.TextLine1 = "Sort by date";
            this.btnSortByDate.Click += new System.EventHandler(this.btnSortByDate_Click);
            this.btnSortByDate.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.btnSort_PropertyChanged);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.results);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1503, 941);
            this.kryptonPanel1.TabIndex = 7;
            // 
            // results
            // 
            this.results.Location = new System.Drawing.Point(0, 158);
            this.results.Name = "results";
            // 
            // results.Panel
            // 
            this.results.Panel.Controls.Add(this.resultsGrid);
            this.results.Size = new System.Drawing.Size(1014, 783);
            this.results.TabIndex = 0;
            this.results.ValuesPrimary.Heading = "Results";
            this.results.ValuesSecondary.Heading = "Total";
            // 
            // resultsGrid
            // 
            this.resultsGrid.AllowUserToAddRows = false;
            this.resultsGrid.AllowUserToDeleteRows = false;
            this.resultsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnVIP,
            this.columnDate,
            this.columnImage,
            this.columnLink,
            this.columnPrice,
            this.columnCategory,
            this.columnAddress});
            this.resultsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsGrid.Location = new System.Drawing.Point(0, 0);
            this.resultsGrid.Name = "resultsGrid";
            this.resultsGrid.ReadOnly = true;
            this.resultsGrid.Size = new System.Drawing.Size(1012, 724);
            this.resultsGrid.TabIndex = 0;
            // 
            // columnVIP
            // 
            this.columnVIP.Frozen = true;
            this.columnVIP.HeaderText = "VIP";
            this.columnVIP.Name = "columnVIP";
            this.columnVIP.ReadOnly = true;
            this.columnVIP.Width = 34;
            // 
            // columnDate
            // 
            this.columnDate.Frozen = true;
            this.columnDate.HeaderText = "Date";
            this.columnDate.Name = "columnDate";
            this.columnDate.ReadOnly = true;
            // 
            // columnImage
            // 
            this.columnImage.HeaderText = "Image";
            this.columnImage.Name = "columnImage";
            this.columnImage.ReadOnly = true;
            // 
            // columnLink
            // 
            this.columnLink.HeaderText = "Url";
            this.columnLink.Name = "columnLink";
            this.columnLink.ReadOnly = true;
            this.columnLink.Width = 300;
            // 
            // columnPrice
            // 
            this.columnPrice.HeaderText = "Price";
            this.columnPrice.Name = "columnPrice";
            this.columnPrice.ReadOnly = true;
            this.columnPrice.Width = 100;
            // 
            // columnCategory
            // 
            this.columnCategory.HeaderText = "Category";
            this.columnCategory.Name = "columnCategory";
            this.columnCategory.ReadOnly = true;
            this.columnCategory.Width = 200;
            // 
            // columnAddress
            // 
            this.columnAddress.HeaderText = "Address";
            this.columnAddress.Name = "columnAddress";
            this.columnAddress.ReadOnly = true;
            this.columnAddress.Width = 170;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 941);
            this.Controls.Add(this.menuLayout);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(860, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AvitoSearch";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.menuLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.results.Panel)).EndInit();
            this.results.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.results)).EndInit();
            this.results.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Ribbon.KryptonRibbon menuLayout;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup priceGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines kryptonRibbonGroupLines1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel kryptonRibbonGroupLabel1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel kryptonRibbonGroupLabel2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup resultGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines Group2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel kryptonRibbonGroupLabel3;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupDateTimePicker datesAfter;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel kryptonRibbonGroupLabel4;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupNumericUpDown udMaxPrice;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupNumericUpDown udMinPrice;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupNumericUpDown upPagesPerSet;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines textLine;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel kryptonRibbonGroupLabel5;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTextBox tbContains;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel kryptonRibbonGroupLabel6;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTextBox tbExclude;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup subjectGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup actionGroup;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnSearch;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnSearchNext;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup results;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView resultsGrid;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnInvertSorting;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnSortByPrice;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnSortByDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnVIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDate;
        private System.Windows.Forms.DataGridViewImageColumn columnImage;
        private System.Windows.Forms.DataGridViewLinkColumn columnLink;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn columnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAddress;
    }
}

