namespace wayeal.os.exhaust.Modules
{
    partial class ucAirQuality
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAirQuality));
            this.panelQuary = new System.Windows.Forms.Panel();
            this.lcQuaryTime = new DevExpress.XtraEditors.LabelControl();
            this.sbDerive = new DevExpress.XtraEditors.SimpleButton();
            this.sbQuary = new DevExpress.XtraEditors.SimpleButton();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.lcTilde = new System.Windows.Forms.Label();
            this.panelDataview = new System.Windows.Forms.Panel();
            this.gcAirQuality = new DevExpress.XtraGrid.GridControl();
            this.gvAirQuality = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTestingTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPM25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPM10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSO2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNO2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcO3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcVOCs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager();
            this.pcBottom = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tsbGotoPage = new DevExpress.XtraEditors.SimpleButton();
            this.numGoPage = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslAll = new System.Windows.Forms.ToolStripLabel();
            this.tslCount = new System.Windows.Forms.ToolStripLabel();
            this.tslRecords = new System.Windows.Forms.ToolStripLabel();
            this.cbePageRecord = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFirstPage = new System.Windows.Forms.ToolStripButton();
            this.tsbLastPage = new System.Windows.Forms.ToolStripButton();
            this.tslCurrentPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tslTotalPage = new System.Windows.Forms.ToolStripLabel();
            this.tsbNextPage = new System.Windows.Forms.ToolStripButton();
            this.tsbEndPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            this.panelQuary.SuspendLayout();
            this.panelDataview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAirQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAirQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcBottom)).BeginInit();
            this.pcBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGoPage)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelQuary
            // 
            this.panelQuary.BackColor = System.Drawing.Color.White;
            this.panelQuary.Controls.Add(this.lcQuaryTime);
            this.panelQuary.Controls.Add(this.sbDerive);
            this.panelQuary.Controls.Add(this.sbQuary);
            this.panelQuary.Controls.Add(this.dtpEnd);
            this.panelQuary.Controls.Add(this.dtpBegin);
            this.panelQuary.Controls.Add(this.lcTilde);
            this.panelQuary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQuary.Location = new System.Drawing.Point(0, 0);
            this.panelQuary.Name = "panelQuary";
            this.panelQuary.Size = new System.Drawing.Size(1178, 40);
            this.panelQuary.TabIndex = 49;
            // 
            // lcQuaryTime
            // 
            this.lcQuaryTime.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcQuaryTime.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcQuaryTime.Appearance.Options.UseFont = true;
            this.lcQuaryTime.Appearance.Options.UseForeColor = true;
            this.lcQuaryTime.Appearance.Options.UseTextOptions = true;
            this.lcQuaryTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcQuaryTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcQuaryTime.Location = new System.Drawing.Point(-4, 12);
            this.lcQuaryTime.Name = "lcQuaryTime";
            this.lcQuaryTime.Size = new System.Drawing.Size(73, 16);
            this.lcQuaryTime.TabIndex = 32;
            this.lcQuaryTime.Text = "QuaryTime";
            // 
            // sbDerive
            // 
            this.sbDerive.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbDerive.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbDerive.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbDerive.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("sbDerive.Appearance.Image")));
            this.sbDerive.Appearance.Options.UseBackColor = true;
            this.sbDerive.Appearance.Options.UseFont = true;
            this.sbDerive.Appearance.Options.UseForeColor = true;
            this.sbDerive.Appearance.Options.UseImage = true;
            this.sbDerive.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbDerive.AppearanceHovered.Options.UseBackColor = true;
            this.sbDerive.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbDerive.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbDerive.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbDerive.AppearancePressed.Image")));
            this.sbDerive.AppearancePressed.Options.UseBackColor = true;
            this.sbDerive.AppearancePressed.Options.UseFont = true;
            this.sbDerive.AppearancePressed.Options.UseImage = true;
            this.sbDerive.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbDerive.Location = new System.Drawing.Point(512, 7);
            this.sbDerive.Margin = new System.Windows.Forms.Padding(4);
            this.sbDerive.Name = "sbDerive";
            this.sbDerive.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbDerive.Size = new System.Drawing.Size(78, 28);
            this.sbDerive.TabIndex = 42;
            this.sbDerive.Text = "Derive";
            this.sbDerive.Click += new System.EventHandler(this.sbDerive_Click);
            // 
            // sbQuary
            // 
            this.sbQuary.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbQuary.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbQuary.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbQuary.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("sbQuary.Appearance.Image")));
            this.sbQuary.Appearance.Options.UseBackColor = true;
            this.sbQuary.Appearance.Options.UseFont = true;
            this.sbQuary.Appearance.Options.UseForeColor = true;
            this.sbQuary.Appearance.Options.UseImage = true;
            this.sbQuary.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbQuary.AppearanceHovered.Options.UseBackColor = true;
            this.sbQuary.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbQuary.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbQuary.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbQuary.AppearancePressed.Image")));
            this.sbQuary.AppearancePressed.Options.UseBackColor = true;
            this.sbQuary.AppearancePressed.Options.UseFont = true;
            this.sbQuary.AppearancePressed.Options.UseImage = true;
            this.sbQuary.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbQuary.Location = new System.Drawing.Point(426, 7);
            this.sbQuary.Margin = new System.Windows.Forms.Padding(4);
            this.sbQuary.Name = "sbQuary";
            this.sbQuary.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbQuary.Size = new System.Drawing.Size(78, 28);
            this.sbQuary.TabIndex = 41;
            this.sbQuary.Text = "Quary";
            this.sbQuary.Click += new System.EventHandler(this.sbQuary_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(261, 9);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(158, 24);
            this.dtpEnd.TabIndex = 32;
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBegin.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(75, 9);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(158, 24);
            this.dtpBegin.TabIndex = 31;
            // 
            // lcTilde
            // 
            this.lcTilde.AutoSize = true;
            this.lcTilde.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcTilde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(106)))), ((int)(((byte)(170)))));
            this.lcTilde.Location = new System.Drawing.Point(239, 12);
            this.lcTilde.Name = "lcTilde";
            this.lcTilde.Size = new System.Drawing.Size(18, 17);
            this.lcTilde.TabIndex = 11;
            this.lcTilde.Text = "~";
            // 
            // panelDataview
            // 
            this.panelDataview.BackColor = System.Drawing.Color.White;
            this.panelDataview.Controls.Add(this.gcAirQuality);
            this.panelDataview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDataview.Location = new System.Drawing.Point(0, 40);
            this.panelDataview.Name = "panelDataview";
            this.panelDataview.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.panelDataview.Size = new System.Drawing.Size(1178, 639);
            this.panelDataview.TabIndex = 50;
            // 
            // gcAirQuality
            // 
            this.gcAirQuality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAirQuality.Location = new System.Drawing.Point(8, 3);
            this.gcAirQuality.MainView = this.gvAirQuality;
            this.gcAirQuality.Name = "gcAirQuality";
            this.gcAirQuality.Size = new System.Drawing.Size(1162, 628);
            this.gcAirQuality.TabIndex = 31;
            this.gcAirQuality.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAirQuality});
            // 
            // gvAirQuality
            // 
            this.gvAirQuality.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAirQuality.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvAirQuality.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvAirQuality.Appearance.Row.Options.UseFont = true;
            this.gvAirQuality.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvAirQuality.Appearance.SelectedRow.Options.UseFont = true;
            this.gvAirQuality.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcNumber,
            this.gcTestingTime,
            this.gcPM25,
            this.gcPM10,
            this.gcCO,
            this.gcSO2,
            this.gcNO2,
            this.gcO3,
            this.gcVOCs});
            this.gvAirQuality.DetailHeight = 408;
            this.gvAirQuality.GridControl = this.gcAirQuality;
            this.gvAirQuality.Name = "gvAirQuality";
            this.gvAirQuality.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gvAirQuality.OptionsCustomization.AllowFilter = false;
            this.gvAirQuality.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gvAirQuality.OptionsView.ShowGroupPanel = false;
            this.gvAirQuality.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvAirQuality_CustomColumnDisplayText);
            // 
            // gcNumber
            // 
            this.gcNumber.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcNumber.AppearanceCell.Options.UseFont = true;
            this.gcNumber.Caption = "Serial";
            this.gcNumber.FieldName = "Serial";
            this.gcNumber.MinWidth = 23;
            this.gcNumber.Name = "gcNumber";
            this.gcNumber.OptionsColumn.AllowEdit = false;
            this.gcNumber.OptionsColumn.AllowFocus = false;
            this.gcNumber.Visible = true;
            this.gcNumber.VisibleIndex = 0;
            this.gcNumber.Width = 45;
            // 
            // gcTestingTime
            // 
            this.gcTestingTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcTestingTime.AppearanceCell.Options.UseFont = true;
            this.gcTestingTime.Caption = "TestingTime";
            this.gcTestingTime.FieldName = "TestingTime";
            this.gcTestingTime.MinWidth = 23;
            this.gcTestingTime.Name = "gcTestingTime";
            this.gcTestingTime.OptionsColumn.AllowEdit = false;
            this.gcTestingTime.OptionsColumn.AllowFocus = false;
            this.gcTestingTime.Visible = true;
            this.gcTestingTime.VisibleIndex = 1;
            this.gcTestingTime.Width = 180;
            // 
            // gcPM25
            // 
            this.gcPM25.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcPM25.AppearanceCell.Options.UseFont = true;
            this.gcPM25.Caption = "PM2.5(ug/m³)";
            this.gcPM25.FieldName = "PM2Point5";
            this.gcPM25.MinWidth = 23;
            this.gcPM25.Name = "gcPM25";
            this.gcPM25.OptionsColumn.AllowEdit = false;
            this.gcPM25.OptionsColumn.AllowFocus = false;
            this.gcPM25.OptionsFilter.AllowFilter = false;
            this.gcPM25.Visible = true;
            this.gcPM25.VisibleIndex = 2;
            this.gcPM25.Width = 144;
            // 
            // gcPM10
            // 
            this.gcPM10.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcPM10.AppearanceCell.Options.UseFont = true;
            this.gcPM10.Caption = "PM10(ug/m³)";
            this.gcPM10.FieldName = "PM10";
            this.gcPM10.MinWidth = 23;
            this.gcPM10.Name = "gcPM10";
            this.gcPM10.OptionsColumn.AllowEdit = false;
            this.gcPM10.OptionsColumn.AllowFocus = false;
            this.gcPM10.OptionsFilter.AllowFilter = false;
            this.gcPM10.Visible = true;
            this.gcPM10.VisibleIndex = 3;
            this.gcPM10.Width = 152;
            // 
            // gcCO
            // 
            this.gcCO.Caption = "CO(ppm)";
            this.gcCO.FieldName = "COAir";
            this.gcCO.Name = "gcCO";
            this.gcCO.OptionsColumn.AllowEdit = false;
            this.gcCO.OptionsColumn.AllowFocus = false;
            this.gcCO.OptionsFilter.AllowFilter = false;
            this.gcCO.Visible = true;
            this.gcCO.VisibleIndex = 4;
            this.gcCO.Width = 139;
            // 
            // gcSO2
            // 
            this.gcSO2.Caption = "SO₂(ppb)";
            this.gcSO2.FieldName = "SO2";
            this.gcSO2.Name = "gcSO2";
            this.gcSO2.OptionsColumn.AllowEdit = false;
            this.gcSO2.OptionsColumn.AllowFocus = false;
            this.gcSO2.OptionsFilter.AllowFilter = false;
            this.gcSO2.Visible = true;
            this.gcSO2.VisibleIndex = 5;
            this.gcSO2.Width = 150;
            // 
            // gcNO2
            // 
            this.gcNO2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcNO2.AppearanceCell.Options.UseFont = true;
            this.gcNO2.Caption = "NO₂(ppm)";
            this.gcNO2.FieldName = "NO2";
            this.gcNO2.MinWidth = 23;
            this.gcNO2.Name = "gcNO2";
            this.gcNO2.OptionsColumn.AllowEdit = false;
            this.gcNO2.OptionsColumn.AllowFocus = false;
            this.gcNO2.OptionsFilter.AllowFilter = false;
            this.gcNO2.Visible = true;
            this.gcNO2.VisibleIndex = 7;
            this.gcNO2.Width = 170;
            // 
            // gcO3
            // 
            this.gcO3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcO3.AppearanceCell.Options.UseFont = true;
            this.gcO3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.gcO3.AppearanceHeader.Options.UseFont = true;
            this.gcO3.Caption = "O₃(ppm)";
            this.gcO3.FieldName = "O3";
            this.gcO3.MinWidth = 23;
            this.gcO3.Name = "gcO3";
            this.gcO3.OptionsColumn.AllowEdit = false;
            this.gcO3.OptionsColumn.AllowFocus = false;
            this.gcO3.OptionsFilter.AllowFilter = false;
            this.gcO3.Visible = true;
            this.gcO3.VisibleIndex = 6;
            this.gcO3.Width = 161;
            // 
            // gcVOCs
            // 
            this.gcVOCs.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcVOCs.AppearanceCell.Options.UseFont = true;
            this.gcVOCs.Caption = "VOCs";
            this.gcVOCs.FieldName = "VOCs";
            this.gcVOCs.MinWidth = 23;
            this.gcVOCs.Name = "gcVOCs";
            this.gcVOCs.OptionsColumn.AllowEdit = false;
            this.gcVOCs.OptionsColumn.AllowFocus = false;
            this.gcVOCs.Width = 160;
            // 
            // pcBottom
            // 
            this.pcBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.pcBottom.Appearance.Options.UseBackColor = true;
            this.pcBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pcBottom.Controls.Add(this.labelControl1);
            this.pcBottom.Controls.Add(this.tsbGotoPage);
            this.pcBottom.Controls.Add(this.numGoPage);
            this.pcBottom.Controls.Add(this.toolStrip1);
            this.pcBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pcBottom.Location = new System.Drawing.Point(0, 679);
            this.pcBottom.Name = "pcBottom";
            this.pcBottom.Size = new System.Drawing.Size(1178, 37);
            this.pcBottom.TabIndex = 55;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(1126, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 14);
            this.labelControl1.TabIndex = 105;
            this.labelControl1.Text = "页";
            // 
            // tsbGotoPage
            // 
            this.tsbGotoPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbGotoPage.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.tsbGotoPage.Appearance.Options.UseBorderColor = true;
            this.tsbGotoPage.AutoSize = true;
            this.tsbGotoPage.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tsbGotoPage.Location = new System.Drawing.Point(1142, 11);
            this.tsbGotoPage.Name = "tsbGotoPage";
            this.tsbGotoPage.Size = new System.Drawing.Size(27, 20);
            this.tsbGotoPage.TabIndex = 100;
            this.tsbGotoPage.Text = "跳转";
            this.tsbGotoPage.Click += new System.EventHandler(this.tsbGotoPage_Click_1);
            // 
            // numGoPage
            // 
            this.numGoPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numGoPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGoPage.Location = new System.Drawing.Point(1065, 10);
            this.numGoPage.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numGoPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGoPage.Name = "numGoPage";
            this.numGoPage.Size = new System.Drawing.Size(55, 23);
            this.numGoPage.TabIndex = 99;
            this.numGoPage.Tag = "pageControl7";
            this.numGoPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslAll,
            this.tslCount,
            this.tslRecords,
            this.cbePageRecord,
            this.toolStripLabel2,
            this.toolStripSeparator1,
            this.tsbFirstPage,
            this.tsbLastPage,
            this.tslCurrentPage,
            this.toolStripLabel3,
            this.tslTotalPage,
            this.tsbNextPage,
            this.tsbEndPage,
            this.toolStripSeparator2,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(668, 10);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(399, 25);
            this.toolStrip1.TabIndex = 91;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Paint += new System.Windows.Forms.PaintEventHandler(this.toolStrip1_Paint);
            // 
            // tslAll
            // 
            this.tslAll.Name = "tslAll";
            this.tslAll.Size = new System.Drawing.Size(52, 22);
            this.tslAll.Text = "amount";
            // 
            // tslCount
            // 
            this.tslCount.Name = "tslCount";
            this.tslCount.Size = new System.Drawing.Size(15, 22);
            this.tslCount.Text = "0";
            // 
            // tslRecords
            // 
            this.tslRecords.Name = "tslRecords";
            this.tslRecords.Size = new System.Drawing.Size(56, 22);
            this.tslRecords.Text = "Records";
            // 
            // cbePageRecord
            // 
            this.cbePageRecord.AutoSize = false;
            this.cbePageRecord.BackColor = System.Drawing.Color.White;
            this.cbePageRecord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbePageRecord.DropDownWidth = 55;
            this.cbePageRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbePageRecord.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbePageRecord.ForeColor = System.Drawing.Color.Black;
            this.cbePageRecord.Items.AddRange(new object[] {
            "20",
            "40",
            "60",
            "80",
            "100"});
            this.cbePageRecord.MaxDropDownItems = 5;
            this.cbePageRecord.Name = "cbePageRecord";
            this.cbePageRecord.Size = new System.Drawing.Size(55, 24);
            this.cbePageRecord.SelectedIndexChanged += new System.EventHandler(this.cbePageRecord_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel2.Text = "行/页";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbFirstPage
            // 
            this.tsbFirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFirstPage.Image = global::wayeal.os.exhaust.Properties.Resources.首页;
            this.tsbFirstPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirstPage.Name = "tsbFirstPage";
            this.tsbFirstPage.Size = new System.Drawing.Size(23, 22);
            this.tsbFirstPage.Text = "首页";
            this.tsbFirstPage.Click += new System.EventHandler(this.tsbFirstPage_Click);
            // 
            // tsbLastPage
            // 
            this.tsbLastPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLastPage.Image = global::wayeal.os.exhaust.Properties.Resources.上页;
            this.tsbLastPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLastPage.Name = "tsbLastPage";
            this.tsbLastPage.Size = new System.Drawing.Size(23, 22);
            this.tsbLastPage.Text = "上一页";
            this.tsbLastPage.Click += new System.EventHandler(this.tsbLastPage_Click);
            // 
            // tslCurrentPage
            // 
            this.tslCurrentPage.Name = "tslCurrentPage";
            this.tslCurrentPage.Size = new System.Drawing.Size(15, 22);
            this.tslCurrentPage.Text = "0";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel3.Text = "/";
            // 
            // tslTotalPage
            // 
            this.tslTotalPage.Name = "tslTotalPage";
            this.tslTotalPage.Size = new System.Drawing.Size(15, 22);
            this.tslTotalPage.Text = "0";
            // 
            // tsbNextPage
            // 
            this.tsbNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNextPage.Image = global::wayeal.os.exhaust.Properties.Resources.下页;
            this.tsbNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNextPage.Name = "tsbNextPage";
            this.tsbNextPage.Size = new System.Drawing.Size(23, 22);
            this.tsbNextPage.Text = "下一页";
            this.tsbNextPage.Click += new System.EventHandler(this.tsbNextPage_Click);
            // 
            // tsbEndPage
            // 
            this.tsbEndPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEndPage.Image = global::wayeal.os.exhaust.Properties.Resources.末页;
            this.tsbEndPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEndPage.Name = "tsbEndPage";
            this.tsbEndPage.Size = new System.Drawing.Size(23, 22);
            this.tsbEndPage.Text = "末页";
            this.tsbEndPage.Click += new System.EventHandler(this.tsbEndPage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel1.Text = "转至";
            // 
            // ucAirQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDataview);
            this.Controls.Add(this.panelQuary);
            this.Controls.Add(this.pcBottom);
            this.Name = "ucAirQuality";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.Size = new System.Drawing.Size(1178, 716);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            this.panelQuary.ResumeLayout(false);
            this.panelQuary.PerformLayout();
            this.panelDataview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAirQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAirQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcBottom)).EndInit();
            this.pcBottom.ResumeLayout(false);
            this.pcBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGoPage)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelQuary;
        private DevExpress.XtraEditors.LabelControl lcQuaryTime;
        private DevExpress.XtraEditors.SimpleButton sbDerive;
        private DevExpress.XtraEditors.SimpleButton sbQuary;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label lcTilde;
        private System.Windows.Forms.Panel panelDataview;
        private DevExpress.XtraGrid.GridControl gcAirQuality;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAirQuality;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcTestingTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcPM25;
        private DevExpress.XtraGrid.Columns.GridColumn gcPM10;
        private DevExpress.XtraGrid.Columns.GridColumn gcVOCs;
        private DevExpress.XtraGrid.Columns.GridColumn gcO3;
        private DevExpress.XtraGrid.Columns.GridColumn gcNO2;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.PanelControl pcBottom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton tsbGotoPage;
        private System.Windows.Forms.NumericUpDown numGoPage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cbePageRecord;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbFirstPage;
        private System.Windows.Forms.ToolStripButton tsbLastPage;
        private System.Windows.Forms.ToolStripLabel tslCurrentPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel tslTotalPage;
        private System.Windows.Forms.ToolStripButton tsbNextPage;
        private System.Windows.Forms.ToolStripButton tsbEndPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCO;
        private DevExpress.XtraGrid.Columns.GridColumn gcSO2;
        private System.Windows.Forms.ToolStripLabel tslAll;
        private System.Windows.Forms.ToolStripLabel tslCount;
        private System.Windows.Forms.ToolStripLabel tslRecords;
    }
}
