namespace wayeal.os.exhaust.UserControls
{
    partial class ucDebuggingDevices
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDebuggingDevices));
            this.icConnectionState = new DevExpress.Utils.ImageCollection();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.lcOffline = new DevExpress.XtraEditors.LabelControl();
            this.lcOnline = new DevExpress.XtraEditors.LabelControl();
            this.tlDeviceDebug = new DevExpress.XtraTreeList.TreeList();
            this.tlcDeviceName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcOnline = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlCommunication = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tcList = new DevExpress.XtraTab.XtraTabControl();
            this.xtpDevice = new DevExpress.XtraTab.XtraTabPage();
            this.tlDeviceSource = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcState = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.xtpCommunication = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lcDelete = new DevExpress.XtraEditors.LabelControl();
            this.lcNew = new DevExpress.XtraEditors.LabelControl();
            this.peNew = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icConnectionState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlDeviceDebug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlCommunication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcList)).BeginInit();
            this.tcList.SuspendLayout();
            this.xtpDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlDeviceSource)).BeginInit();
            this.xtpCommunication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peNew.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // icConnectionState
            // 
            this.icConnectionState.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("icConnectionState.ImageStream")));
            this.icConnectionState.Images.SetKeyName(0, "离线.png");
            this.icConnectionState.Images.SetKeyName(1, "在线.png");
            // 
            // panelControl4
            // 
            this.panelControl4.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl4.Appearance.Options.UseBackColor = true;
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.lcOffline);
            this.panelControl4.Controls.Add(this.lcOnline);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(0, 616);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(353, 33);
            this.panelControl4.TabIndex = 0;
            // 
            // lcOffline
            // 
            this.lcOffline.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lcOffline.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lcOffline.Appearance.ImageIndex = 0;
            this.lcOffline.Appearance.ImageList = this.icConnectionState;
            this.lcOffline.Appearance.Options.UseForeColor = true;
            this.lcOffline.Appearance.Options.UseImageAlign = true;
            this.lcOffline.Appearance.Options.UseImageIndex = true;
            this.lcOffline.Appearance.Options.UseImageList = true;
            this.lcOffline.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcOffline.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lcOffline.Location = new System.Drawing.Point(94, 5);
            this.lcOffline.Name = "lcOffline";
            this.lcOffline.Size = new System.Drawing.Size(84, 20);
            this.lcOffline.TabIndex = 1;
            this.lcOffline.Text = "Offline";
            // 
            // lcOnline
            // 
            this.lcOnline.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lcOnline.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lcOnline.Appearance.ImageIndex = 1;
            this.lcOnline.Appearance.ImageList = this.icConnectionState;
            this.lcOnline.Appearance.Options.UseForeColor = true;
            this.lcOnline.Appearance.Options.UseImageAlign = true;
            this.lcOnline.Appearance.Options.UseImageIndex = true;
            this.lcOnline.Appearance.Options.UseImageList = true;
            this.lcOnline.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcOnline.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lcOnline.Location = new System.Drawing.Point(4, 4);
            this.lcOnline.Name = "lcOnline";
            this.lcOnline.Size = new System.Drawing.Size(84, 20);
            this.lcOnline.TabIndex = 2;
            this.lcOnline.Text = "Online";
            // 
            // tlDeviceDebug
            // 
            this.tlDeviceDebug.ActiveFilterString = "[Online] Like \'1\'";
            this.tlDeviceDebug.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.tlDeviceDebug.Appearance.Empty.Options.UseBackColor = true;
            this.tlDeviceDebug.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.tlDeviceDebug.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tlDeviceDebug.Appearance.FocusedCell.Options.UseFont = true;
            this.tlDeviceDebug.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tlDeviceDebug.Appearance.FocusedRow.BackColor = System.Drawing.Color.White;
            this.tlDeviceDebug.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tlDeviceDebug.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tlDeviceDebug.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tlDeviceDebug.Appearance.FocusedRow.Options.UseFont = true;
            this.tlDeviceDebug.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tlDeviceDebug.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.tlDeviceDebug.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tlDeviceDebug.Appearance.Row.Options.UseBackColor = true;
            this.tlDeviceDebug.Appearance.Row.Options.UseFont = true;
            this.tlDeviceDebug.Appearance.Row.Options.UseTextOptions = true;
            this.tlDeviceDebug.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tlDeviceDebug.Appearance.SelectedRow.BackColor = System.Drawing.Color.Olive;
            this.tlDeviceDebug.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tlDeviceDebug.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tlDeviceDebug.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tlDeviceDebug.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcDeviceName,
            this.tlcOnline});
            this.tlDeviceDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDeviceDebug.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tlDeviceDebug.IndicatorWidth = 5;
            this.tlDeviceDebug.Location = new System.Drawing.Point(0, 0);
            this.tlDeviceDebug.Margin = new System.Windows.Forms.Padding(5);
            this.tlDeviceDebug.Name = "tlDeviceDebug";
            this.tlDeviceDebug.BeginUnboundLoad();
            this.tlDeviceDebug.AppendNode(new object[] {
            "Meteorograph",
            "1"}, -1, 0, 0, 0, "Meteorograph|Meteorograph");
            this.tlDeviceDebug.AppendNode(new object[] {
            "Air Quality Instrument",
            "1"}, -1, 0, 0, 0, "AirQualityDevice|AirQuality");
            this.tlDeviceDebug.AppendNode(new object[] {
            "License Plate Recognition Camera",
            "1"}, -1, 0, 0, 0, "LicenseRecognition|LicenseRecog");
            this.tlDeviceDebug.AppendNode(new object[] {
            "Security Camera",
            "1"}, -1, 0, 0, 0, "SecurityCamera|SecurityCamera");
            this.tlDeviceDebug.AppendNode(new object[] {
            "NVR",
            "1"}, -1, 0, 0, 0, "NVRDevice|NVR");
            this.tlDeviceDebug.AppendNode(new object[] {
            "LED Display Screen",
            "1"}, -1, 0, 0, 0, "LEDDevice|LED");
            this.tlDeviceDebug.AppendNode(new object[] {
            "Exhuast Analyzer",
            "1"}, -1, 0, 0, 0, "AnalysisDevice|Analysis");
            this.tlDeviceDebug.AppendNode(new object[] {
            "GPS",
            "1"}, -1, 0, 0, 0, "GPSDevice|GPS");
            this.tlDeviceDebug.AppendNode(new object[] {
            "Plat",
            "1"}, -1, 0, 0, 0, "PlatDevice|Plat");
            this.tlDeviceDebug.EndUnboundLoad();
            this.tlDeviceDebug.OptionsBehavior.AllowExpandOnDblClick = false;
            this.tlDeviceDebug.OptionsBehavior.AutoChangeParent = false;
            this.tlDeviceDebug.OptionsBehavior.AutoPopulateColumns = false;
            this.tlDeviceDebug.OptionsBehavior.AutoScrollOnSorting = false;
            this.tlDeviceDebug.OptionsBehavior.AutoSelectAllInEditor = false;
            this.tlDeviceDebug.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.tlDeviceDebug.OptionsBehavior.Editable = false;
            this.tlDeviceDebug.OptionsBehavior.ResizeNodes = false;
            this.tlDeviceDebug.OptionsBehavior.ShowToolTips = false;
            this.tlDeviceDebug.OptionsBehavior.SmartMouseHover = false;
            this.tlDeviceDebug.OptionsCustomization.AllowBandMoving = false;
            this.tlDeviceDebug.OptionsCustomization.AllowBandResizing = false;
            this.tlDeviceDebug.OptionsCustomization.AllowColumnMoving = false;
            this.tlDeviceDebug.OptionsCustomization.AllowColumnResizing = false;
            this.tlDeviceDebug.OptionsCustomization.AllowFilter = false;
            this.tlDeviceDebug.OptionsCustomization.AllowQuickHideColumns = false;
            this.tlDeviceDebug.OptionsCustomization.AllowSort = false;
            this.tlDeviceDebug.OptionsCustomization.ShowBandsInCustomizationForm = false;
            this.tlDeviceDebug.OptionsDragAndDrop.ExpandNodeOnDrag = false;
            this.tlDeviceDebug.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.tlDeviceDebug.OptionsFilter.AllowColumnMRUFilterList = false;
            this.tlDeviceDebug.OptionsFilter.AllowFilterEditor = false;
            this.tlDeviceDebug.OptionsFilter.AllowMRUFilterList = false;
            this.tlDeviceDebug.OptionsFilter.ShowAllValuesInCheckedFilterPopup = false;
            this.tlDeviceDebug.OptionsFind.AllowFindPanel = false;
            this.tlDeviceDebug.OptionsFind.ClearFindOnClose = false;
            this.tlDeviceDebug.OptionsFind.HighlightFindResults = false;
            this.tlDeviceDebug.OptionsFind.ShowClearButton = false;
            this.tlDeviceDebug.OptionsFind.ShowCloseButton = false;
            this.tlDeviceDebug.OptionsFind.ShowFindButton = false;
            this.tlDeviceDebug.OptionsLayout.AddNewColumns = false;
            this.tlDeviceDebug.OptionsMenu.EnableColumnMenu = false;
            this.tlDeviceDebug.OptionsMenu.EnableFooterMenu = false;
            this.tlDeviceDebug.OptionsMenu.ShowAutoFilterRowItem = false;
            this.tlDeviceDebug.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.tlDeviceDebug.OptionsSelection.MultiSelectMode = DevExpress.XtraTreeList.TreeListMultiSelectMode.CellSelect;
            this.tlDeviceDebug.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.tlDeviceDebug.OptionsView.ShowBandsMode = DevExpress.Utils.DefaultBoolean.False;
            this.tlDeviceDebug.OptionsView.ShowButtons = false;
            this.tlDeviceDebug.OptionsView.ShowColumns = false;
            this.tlDeviceDebug.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
            this.tlDeviceDebug.OptionsView.ShowFirstLines = false;
            this.tlDeviceDebug.OptionsView.ShowHierarchyIndentationLines = DevExpress.Utils.DefaultBoolean.False;
            this.tlDeviceDebug.OptionsView.ShowHorzLines = false;
            this.tlDeviceDebug.OptionsView.ShowIndicator = false;
            this.tlDeviceDebug.OptionsView.ShowRoot = false;
            this.tlDeviceDebug.OptionsView.ShowVertLines = false;
            this.tlDeviceDebug.Padding = new System.Windows.Forms.Padding(5);
            this.tlDeviceDebug.RowHeight = 25;
            this.tlDeviceDebug.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowOnlyInEditor;
            this.tlDeviceDebug.Size = new System.Drawing.Size(353, 616);
            this.tlDeviceDebug.StateImageList = this.icConnectionState;
            this.tlDeviceDebug.TabIndex = 0;
            this.tlDeviceDebug.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeList;
            this.tlDeviceDebug.RowClick += new DevExpress.XtraTreeList.RowClickEventHandler(this.tlDevice_RowClick);
            // 
            // tlcDeviceName
            // 
            this.tlcDeviceName.Caption = "DeviceName";
            this.tlcDeviceName.FieldName = "DeviceName";
            this.tlcDeviceName.Name = "tlcDeviceName";
            this.tlcDeviceName.Visible = true;
            this.tlcDeviceName.VisibleIndex = 0;
            // 
            // tlcOnline
            // 
            this.tlcOnline.Caption = "Online";
            this.tlcOnline.FieldName = "Online";
            this.tlcOnline.Name = "tlcOnline";
            // 
            // tlCommunication
            // 
            this.tlCommunication.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.tlCommunication.Appearance.Empty.Options.UseBackColor = true;
            this.tlCommunication.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.tlCommunication.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tlCommunication.Appearance.FocusedCell.Options.UseFont = true;
            this.tlCommunication.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tlCommunication.Appearance.FocusedRow.BackColor = System.Drawing.Color.White;
            this.tlCommunication.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tlCommunication.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tlCommunication.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tlCommunication.Appearance.FocusedRow.Options.UseFont = true;
            this.tlCommunication.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tlCommunication.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.tlCommunication.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tlCommunication.Appearance.Row.Options.UseBackColor = true;
            this.tlCommunication.Appearance.Row.Options.UseFont = true;
            this.tlCommunication.Appearance.Row.Options.UseTextOptions = true;
            this.tlCommunication.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tlCommunication.Appearance.SelectedRow.BackColor = System.Drawing.Color.Olive;
            this.tlCommunication.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tlCommunication.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tlCommunication.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tlCommunication.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.tlCommunication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCommunication.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tlCommunication.IndicatorWidth = 5;
            this.tlCommunication.Location = new System.Drawing.Point(0, 0);
            this.tlCommunication.Margin = new System.Windows.Forms.Padding(5);
            this.tlCommunication.Name = "tlCommunication";
            this.tlCommunication.BeginUnboundLoad();
            this.tlCommunication.AppendNode(new object[] {
            "COM1"}, -1);
            this.tlCommunication.AppendNode(new object[] {
            null}, -1);
            this.tlCommunication.AppendNode(new object[] {
            null}, -1);
            this.tlCommunication.AppendNode(new object[] {
            null}, -1);
            this.tlCommunication.EndUnboundLoad();
            this.tlCommunication.OptionsBehavior.AllowExpandOnDblClick = false;
            this.tlCommunication.OptionsBehavior.AutoChangeParent = false;
            this.tlCommunication.OptionsBehavior.AutoPopulateColumns = false;
            this.tlCommunication.OptionsBehavior.AutoScrollOnSorting = false;
            this.tlCommunication.OptionsBehavior.AutoSelectAllInEditor = false;
            this.tlCommunication.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.tlCommunication.OptionsBehavior.Editable = false;
            this.tlCommunication.OptionsBehavior.ResizeNodes = false;
            this.tlCommunication.OptionsBehavior.ShowToolTips = false;
            this.tlCommunication.OptionsBehavior.SmartMouseHover = false;
            this.tlCommunication.OptionsCustomization.AllowBandMoving = false;
            this.tlCommunication.OptionsCustomization.AllowBandResizing = false;
            this.tlCommunication.OptionsCustomization.AllowColumnMoving = false;
            this.tlCommunication.OptionsCustomization.AllowColumnResizing = false;
            this.tlCommunication.OptionsCustomization.AllowFilter = false;
            this.tlCommunication.OptionsCustomization.AllowQuickHideColumns = false;
            this.tlCommunication.OptionsCustomization.AllowSort = false;
            this.tlCommunication.OptionsCustomization.ShowBandsInCustomizationForm = false;
            this.tlCommunication.OptionsDragAndDrop.ExpandNodeOnDrag = false;
            this.tlCommunication.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.tlCommunication.OptionsFilter.AllowColumnMRUFilterList = false;
            this.tlCommunication.OptionsFilter.AllowFilterEditor = false;
            this.tlCommunication.OptionsFilter.AllowMRUFilterList = false;
            this.tlCommunication.OptionsFilter.ShowAllValuesInCheckedFilterPopup = false;
            this.tlCommunication.OptionsFind.AllowFindPanel = false;
            this.tlCommunication.OptionsFind.ClearFindOnClose = false;
            this.tlCommunication.OptionsFind.HighlightFindResults = false;
            this.tlCommunication.OptionsFind.ShowClearButton = false;
            this.tlCommunication.OptionsFind.ShowCloseButton = false;
            this.tlCommunication.OptionsFind.ShowFindButton = false;
            this.tlCommunication.OptionsLayout.AddNewColumns = false;
            this.tlCommunication.OptionsMenu.EnableColumnMenu = false;
            this.tlCommunication.OptionsMenu.EnableFooterMenu = false;
            this.tlCommunication.OptionsMenu.ShowAutoFilterRowItem = false;
            this.tlCommunication.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.tlCommunication.OptionsSelection.MultiSelectMode = DevExpress.XtraTreeList.TreeListMultiSelectMode.CellSelect;
            this.tlCommunication.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.tlCommunication.OptionsView.ShowBandsMode = DevExpress.Utils.DefaultBoolean.False;
            this.tlCommunication.OptionsView.ShowButtons = false;
            this.tlCommunication.OptionsView.ShowColumns = false;
            this.tlCommunication.OptionsView.ShowFirstLines = false;
            this.tlCommunication.OptionsView.ShowHierarchyIndentationLines = DevExpress.Utils.DefaultBoolean.False;
            this.tlCommunication.OptionsView.ShowHorzLines = false;
            this.tlCommunication.OptionsView.ShowIndicator = false;
            this.tlCommunication.OptionsView.ShowRoot = false;
            this.tlCommunication.OptionsView.ShowVertLines = false;
            this.tlCommunication.Padding = new System.Windows.Forms.Padding(5);
            this.tlCommunication.RowHeight = 25;
            this.tlCommunication.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowOnlyInEditor;
            this.tlCommunication.Size = new System.Drawing.Size(349, 600);
            this.tlCommunication.StateImageList = this.icConnectionState;
            this.tlCommunication.TabIndex = 1;
            this.tlCommunication.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeList;
            this.tlCommunication.RowClick += new DevExpress.XtraTreeList.RowClickEventHandler(this.tlCommunication_RowClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // tcList
            // 
            this.tcList.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.Black;
            this.tcList.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.tcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcList.Location = new System.Drawing.Point(0, 0);
            this.tcList.Name = "tcList";
            this.tcList.SelectedTabPage = this.xtpDevice;
            this.tcList.Size = new System.Drawing.Size(355, 680);
            this.tcList.TabIndex = 10;
            this.tcList.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpDevice,
            this.xtpCommunication});
            this.tcList.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tcList_SelectedPageChanged);
            // 
            // xtpDevice
            // 
            this.xtpDevice.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtpDevice.Appearance.Header.Options.UseFont = true;
            this.xtpDevice.Appearance.PageClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(88)))), ((int)(((byte)(165)))));
            this.xtpDevice.Appearance.PageClient.Options.UseBackColor = true;
            this.xtpDevice.Controls.Add(this.tlDeviceDebug);
            this.xtpDevice.Controls.Add(this.panelControl4);
            this.xtpDevice.Controls.Add(this.tlDeviceSource);
            this.xtpDevice.Name = "xtpDevice";
            this.xtpDevice.Size = new System.Drawing.Size(353, 649);
            this.xtpDevice.Text = "Device List";
            // 
            // tlDeviceSource
            // 
            this.tlDeviceSource.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.tlDeviceSource.Appearance.Empty.Options.UseBackColor = true;
            this.tlDeviceSource.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tlDeviceSource.Appearance.FocusedCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tlDeviceSource.Appearance.FocusedCell.Options.UseFont = true;
            this.tlDeviceSource.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tlDeviceSource.Appearance.FocusedRow.BackColor = System.Drawing.Color.White;
            this.tlDeviceSource.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tlDeviceSource.Appearance.FocusedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tlDeviceSource.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tlDeviceSource.Appearance.FocusedRow.Options.UseFont = true;
            this.tlDeviceSource.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tlDeviceSource.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.tlDeviceSource.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tlDeviceSource.Appearance.Row.Options.UseBackColor = true;
            this.tlDeviceSource.Appearance.Row.Options.UseFont = true;
            this.tlDeviceSource.Appearance.Row.Options.UseTextOptions = true;
            this.tlDeviceSource.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.tlDeviceSource.Appearance.SelectedRow.BackColor = System.Drawing.Color.Olive;
            this.tlDeviceSource.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tlDeviceSource.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tlDeviceSource.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tlDeviceSource.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn2,
            this.tlcState});
            this.tlDeviceSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlDeviceSource.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tlDeviceSource.IndicatorWidth = 5;
            this.tlDeviceSource.Location = new System.Drawing.Point(0, 0);
            this.tlDeviceSource.Margin = new System.Windows.Forms.Padding(5);
            this.tlDeviceSource.Name = "tlDeviceSource";
            this.tlDeviceSource.BeginUnboundLoad();
            this.tlDeviceSource.AppendNode(new object[] {
            "Meteorograph",
            null}, -1, 0, 0, 0, "Meteorograph|Meteorograph");
            this.tlDeviceSource.AppendNode(new object[] {
            "Air Quality Instrument",
            null}, -1, 0, 0, 0, "AirQualityDevice|AirQuality");
            this.tlDeviceSource.AppendNode(new object[] {
            "License Plate Recognition Camera",
            null}, -1, 0, 0, 0, "LicenseRecognition|LicenseRecog");
            this.tlDeviceSource.AppendNode(new object[] {
            "Security Camera",
            null}, -1, 0, 0, 0, "SecurityCamera|SecurityCamera");
            this.tlDeviceSource.AppendNode(new object[] {
            "NVR",
            null}, -1, 0, 0, 0, "NVRDevice|NVR");
            this.tlDeviceSource.AppendNode(new object[] {
            "LED Display Screen",
            null}, -1, 0, 0, 0, "LEDDevice|LED");
            this.tlDeviceSource.AppendNode(new object[] {
            "Exhuast Analyzer",
            null}, -1, 0, 0, 0, "AnalysisDevice|Analysis");
            this.tlDeviceSource.AppendNode(new object[] {
            "GPS",
            null}, -1, 0, 0, 0, "GPSDevice|GPS");
            this.tlDeviceSource.AppendNode(new object[] {
            "Plat",
            null}, -1, 0, 0, 0, "PlatDevice|Plat");
            this.tlDeviceSource.EndUnboundLoad();
            this.tlDeviceSource.OptionsBehavior.AllowExpandOnDblClick = false;
            this.tlDeviceSource.OptionsBehavior.AutoChangeParent = false;
            this.tlDeviceSource.OptionsBehavior.AutoPopulateColumns = false;
            this.tlDeviceSource.OptionsBehavior.AutoScrollOnSorting = false;
            this.tlDeviceSource.OptionsBehavior.AutoSelectAllInEditor = false;
            this.tlDeviceSource.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.tlDeviceSource.OptionsBehavior.Editable = false;
            this.tlDeviceSource.OptionsBehavior.ResizeNodes = false;
            this.tlDeviceSource.OptionsBehavior.ShowToolTips = false;
            this.tlDeviceSource.OptionsBehavior.SmartMouseHover = false;
            this.tlDeviceSource.OptionsCustomization.AllowBandMoving = false;
            this.tlDeviceSource.OptionsCustomization.AllowBandResizing = false;
            this.tlDeviceSource.OptionsCustomization.AllowColumnMoving = false;
            this.tlDeviceSource.OptionsCustomization.AllowColumnResizing = false;
            this.tlDeviceSource.OptionsCustomization.AllowFilter = false;
            this.tlDeviceSource.OptionsCustomization.AllowQuickHideColumns = false;
            this.tlDeviceSource.OptionsCustomization.AllowSort = false;
            this.tlDeviceSource.OptionsCustomization.ShowBandsInCustomizationForm = false;
            this.tlDeviceSource.OptionsDragAndDrop.ExpandNodeOnDrag = false;
            this.tlDeviceSource.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.tlDeviceSource.OptionsFilter.AllowColumnMRUFilterList = false;
            this.tlDeviceSource.OptionsFilter.AllowFilterEditor = false;
            this.tlDeviceSource.OptionsFilter.AllowMRUFilterList = false;
            this.tlDeviceSource.OptionsFilter.ShowAllValuesInCheckedFilterPopup = false;
            this.tlDeviceSource.OptionsFind.AllowFindPanel = false;
            this.tlDeviceSource.OptionsFind.ClearFindOnClose = false;
            this.tlDeviceSource.OptionsFind.HighlightFindResults = false;
            this.tlDeviceSource.OptionsFind.ShowClearButton = false;
            this.tlDeviceSource.OptionsFind.ShowCloseButton = false;
            this.tlDeviceSource.OptionsFind.ShowFindButton = false;
            this.tlDeviceSource.OptionsLayout.AddNewColumns = false;
            this.tlDeviceSource.OptionsMenu.EnableColumnMenu = false;
            this.tlDeviceSource.OptionsMenu.EnableFooterMenu = false;
            this.tlDeviceSource.OptionsMenu.ShowAutoFilterRowItem = false;
            this.tlDeviceSource.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.tlDeviceSource.OptionsSelection.MultiSelectMode = DevExpress.XtraTreeList.TreeListMultiSelectMode.CellSelect;
            this.tlDeviceSource.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.tlDeviceSource.OptionsView.ShowBandsMode = DevExpress.Utils.DefaultBoolean.False;
            this.tlDeviceSource.OptionsView.ShowButtons = false;
            this.tlDeviceSource.OptionsView.ShowColumns = false;
            this.tlDeviceSource.OptionsView.ShowFirstLines = false;
            this.tlDeviceSource.OptionsView.ShowHierarchyIndentationLines = DevExpress.Utils.DefaultBoolean.False;
            this.tlDeviceSource.OptionsView.ShowHorzLines = false;
            this.tlDeviceSource.OptionsView.ShowIndicator = false;
            this.tlDeviceSource.OptionsView.ShowRoot = false;
            this.tlDeviceSource.OptionsView.ShowVertLines = false;
            this.tlDeviceSource.Padding = new System.Windows.Forms.Padding(5);
            this.tlDeviceSource.RowHeight = 25;
            this.tlDeviceSource.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowOnlyInEditor;
            this.tlDeviceSource.Size = new System.Drawing.Size(353, 649);
            this.tlDeviceSource.StateImageList = this.icConnectionState;
            this.tlDeviceSource.TabIndex = 1;
            this.tlDeviceSource.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeList;
            this.tlDeviceSource.Visible = false;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "treeListColumn1";
            this.treeListColumn2.FieldName = "DeviceName";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 0;
            // 
            // tlcState
            // 
            this.tlcState.Caption = "treeListColumn3";
            this.tlcState.FieldName = "treeListColumn3";
            this.tlcState.Name = "tlcState";
            // 
            // xtpCommunication
            // 
            this.xtpCommunication.Appearance.Header.BackColor = System.Drawing.Color.White;
            this.xtpCommunication.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.xtpCommunication.Appearance.Header.Options.UseBackColor = true;
            this.xtpCommunication.Appearance.Header.Options.UseFont = true;
            this.xtpCommunication.Controls.Add(this.tlCommunication);
            this.xtpCommunication.Controls.Add(this.panelControl1);
            this.xtpCommunication.Name = "xtpCommunication";
            this.xtpCommunication.Size = new System.Drawing.Size(349, 646);
            this.xtpCommunication.Text = "Communication List";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lcDelete);
            this.panelControl1.Controls.Add(this.lcNew);
            this.panelControl1.Controls.Add(this.peNew);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 600);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(349, 46);
            this.panelControl1.TabIndex = 3;
            // 
            // lcDelete
            // 
            this.lcDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lcDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lcDelete.Appearance.Options.UseFont = true;
            this.lcDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lcDelete.Location = new System.Drawing.Point(276, 11);
            this.lcDelete.Name = "lcDelete";
            this.lcDelete.Size = new System.Drawing.Size(54, 19);
            this.lcDelete.TabIndex = 4;
            this.lcDelete.Text = "Delete";
            this.lcDelete.Click += new System.EventHandler(this.lcDelete_Click);
            // 
            // lcNew
            // 
            this.lcNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lcNew.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lcNew.Appearance.Options.UseFont = true;
            this.lcNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lcNew.Location = new System.Drawing.Point(54, 11);
            this.lcNew.Name = "lcNew";
            this.lcNew.Size = new System.Drawing.Size(36, 19);
            this.lcNew.TabIndex = 3;
            this.lcNew.Text = "New";
            this.lcNew.Click += new System.EventHandler(this.peNew_Click);
            // 
            // peNew
            // 
            this.peNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.peNew.EditValue = global::wayeal.os.exhaust.Properties.Resources.新增;
            this.peNew.Location = new System.Drawing.Point(5, 1);
            this.peNew.Name = "peNew";
            this.peNew.Properties.AllowFocused = false;
            this.peNew.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.peNew.Properties.Appearance.Options.UseFont = true;
            this.peNew.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.peNew.Properties.InitialImageOptions.Image = global::wayeal.os.exhaust.Properties.Resources.新增;
            this.peNew.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.peNew.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.peNew.Size = new System.Drawing.Size(45, 41);
            this.peNew.TabIndex = 2;
            this.peNew.Click += new System.EventHandler(this.peNew_Click);
            // 
            // ucDebuggingDevices
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcList);
            this.Name = "ucDebuggingDevices";
            this.Size = new System.Drawing.Size(355, 680);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icConnectionState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlDeviceDebug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlCommunication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcList)).EndInit();
            this.tcList.ResumeLayout(false);
            this.xtpDevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlDeviceSource)).EndInit();
            this.xtpCommunication.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peNew.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.ImageCollection icConnectionState;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl lcOffline;
        private DevExpress.XtraEditors.LabelControl lcOnline;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcDeviceName;
        private DevExpress.XtraTreeList.TreeList tlDeviceDebug;
        private DevExpress.XtraTreeList.TreeList tlCommunication;
        private DevExpress.XtraTab.XtraTabControl tcList;
        private DevExpress.XtraTab.XtraTabPage xtpDevice;
        private DevExpress.XtraTab.XtraTabPage xtpCommunication;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lcNew;
        private DevExpress.XtraEditors.PictureEdit peNew;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.LabelControl lcDelete;
        private DevExpress.XtraTreeList.TreeList tlDeviceSource;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcState;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcOnline;
    }
}
