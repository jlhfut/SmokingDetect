using wayeal.language;

namespace wayeal.os.exhaust
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.bbiHelp = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAbout = new DevExpress.XtraBars.BarButtonItem();
            this.bsiCopyRight = new DevExpress.XtraBars.BarStaticItem();
            this.bbiLogin = new DevExpress.XtraBars.BarButtonItem();
            this.bbiModifyPassword = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUser = new DevExpress.XtraBars.BarButtonItem();
            this.pmUserManage = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bbiLogout2 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLogout = new DevExpress.XtraBars.BarButtonItem();
            this.bsiInfo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRealtimeMonitoring = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeviceManager = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDebugging = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExhaustData = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAirQuality = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUserManage = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAssistManage = new DevExpress.XtraBars.BarButtonItem();
            this.bbiStationSettings = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLimitingSettings = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRunningLog = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBackgroundLog = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSystemLog = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDataStatistics = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDataCount = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUserMan = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.menuOperate = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpHome = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.menuSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgLog = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.menuStation = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpStation = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.menuHelp = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpHelp = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.rpgFollowUp = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.IconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timerLogout = new System.Windows.Forms.Timer(this.components);
            this.hpHelp = new System.Windows.Forms.HelpProvider();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.pcMain = new DevExpress.XtraEditors.PanelControl();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmUserManage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.IconMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.AllowMdiChildButtons = false;
            this.ribbonControl.AllowMinimizeRibbon = false;
            this.ribbonControl.ApplicationButtonDropDownControl = this.barDockControlTop;
            this.ribbonControl.BackColor = System.Drawing.Color.DodgerBlue;
            this.ribbonControl.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbonControl.DrawGroupCaptions = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.DrawGroupsBorderMode = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            resources.ApplyResources(this.ribbonControl, "ribbonControl");
            this.ribbonControl.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bbiHelp,
            this.bbiAbout,
            this.bsiCopyRight,
            this.bbiLogin,
            this.bbiModifyPassword,
            this.bbiUser,
            this.bsiInfo,
            this.bbiRealtimeMonitoring,
            this.bbiDeviceManager,
            this.bbiDebugging,
            this.bbiExhaustData,
            this.bbiAirQuality,
            this.bbiUserManage,
            this.bbiAssistManage,
            this.bbiStationSettings,
            this.bbiLimitingSettings,
            this.bbiRunningLog,
            this.bbiBackgroundLog,
            this.bbiSystemLog,
            this.bbiLogout2,
            this.bbiDataStatistics,
            this.barButtonItem1,
            this.bbiDataCount,
            this.bbiUserMan,
            this.bbiLogout});
            this.ribbonControl.MaxItemId = 6;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.OptionsStubGlyphs.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonControl.OptionsStubGlyphs.Type = DevExpress.Utils.Drawing.GlyphBackgroundType.Ellipse;
            this.ribbonControl.OptionsStubGlyphs.UseFont = true;
            this.ribbonControl.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbonControl.PageHeaderItemLinks.Add(this.bbiUser);
            this.ribbonControl.PageHeaderMinWidth = 40;
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.menuOperate,
            this.menuSystem,
            this.menuStation,
            this.menuHelp});
            this.ribbonControl.RibbonCaptionAlignment = DevExpress.XtraBars.Ribbon.RibbonCaptionAlignment.Left;
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowCategoryInCaption = false;
            this.ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.hpHelp.SetShowHelp(this.ribbonControl, ((bool)(resources.GetObject("ribbonControl.ShowHelp"))));
            this.ribbonControl.ShowItemCaptionsInPageHeader = true;
            this.ribbonControl.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowQatLocationSelector = false;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl.TransparentEditorsMode = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Click += new System.EventHandler(this.ribbonControl_Click);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            this.barDockControlTop.Manager = null;
            // 
            // bbiHelp
            // 
            resources.ApplyResources(this.bbiHelp, "bbiHelp");
            this.bbiHelp.Id = 52;
            this.bbiHelp.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiHelp.ImageOptions.LargeImage")));
            this.bbiHelp.Name = "bbiHelp";
            this.bbiHelp.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.bbiHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiAbout
            // 
            resources.ApplyResources(this.bbiAbout, "bbiAbout");
            this.bbiAbout.GroupIndex = 1;
            this.bbiAbout.Id = 53;
            this.bbiAbout.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("bbiAbout.ImageOptions.DisabledImage")));
            this.bbiAbout.ImageOptions.DisabledLargeImage = ((System.Drawing.Image)(resources.GetObject("bbiAbout.ImageOptions.DisabledLargeImage")));
            this.bbiAbout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiAbout.ImageOptions.LargeImage")));
            this.bbiAbout.Name = "bbiAbout";
            this.bbiAbout.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.bbiAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAbout_ItemClick);
            // 
            // bsiCopyRight
            // 
            resources.ApplyResources(this.bsiCopyRight, "bsiCopyRight");
            this.bsiCopyRight.Id = 2;
            this.bsiCopyRight.Name = "bsiCopyRight";
            // 
            // bbiLogin
            // 
            resources.ApplyResources(this.bbiLogin, "bbiLogin");
            this.bbiLogin.Id = 2;
            this.bbiLogin.Name = "bbiLogin";
            this.bbiLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiModifyPassword
            // 
            resources.ApplyResources(this.bbiModifyPassword, "bbiModifyPassword");
            this.bbiModifyPassword.Id = 3;
            this.bbiModifyPassword.Name = "bbiModifyPassword";
            this.bbiModifyPassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiUser
            // 
            this.bbiUser.ActAsDropDown = true;
            this.bbiUser.AllowRightClickInMenu = false;
            this.bbiUser.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            resources.ApplyResources(this.bbiUser, "bbiUser");
            this.bbiUser.DropDownControl = this.pmUserManage;
            this.bbiUser.Id = 4;
            this.bbiUser.Name = "bbiUser";
            this.bbiUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUser_ItemClick);
            // 
            // pmUserManage
            // 
            this.pmUserManage.ItemLinks.Add(this.bbiLogin);
            this.pmUserManage.ItemLinks.Add(this.bbiModifyPassword);
            this.pmUserManage.ItemLinks.Add(this.bbiLogout2);
            this.pmUserManage.ItemLinks.Add(this.bbiLogout);
            this.pmUserManage.Name = "pmUserManage";
            this.pmUserManage.Ribbon = this.ribbonControl;
            // 
            // bbiLogout2
            // 
            resources.ApplyResources(this.bbiLogout2, "bbiLogout2");
            this.bbiLogout2.Id = 16;
            this.bbiLogout2.Name = "bbiLogout2";
            this.bbiLogout2.Tag = "";
            this.bbiLogout2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiLogout
            // 
            resources.ApplyResources(this.bbiLogout, "bbiLogout");
            this.bbiLogout.Id = 5;
            this.bbiLogout.Name = "bbiLogout";
            this.bbiLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bsiInfo
            // 
            this.bsiInfo.Id = 6;
            this.bsiInfo.Name = "bsiInfo";
            this.bsiInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiRealtimeMonitoring
            // 
            this.bbiRealtimeMonitoring.AllowRightClickInMenu = false;
            resources.ApplyResources(this.bbiRealtimeMonitoring, "bbiRealtimeMonitoring");
            this.bbiRealtimeMonitoring.CloseSubMenuOnClick = false;
            this.bbiRealtimeMonitoring.DropDownEnabled = false;
            this.bbiRealtimeMonitoring.GroupIndex = 1;
            this.bbiRealtimeMonitoring.Id = 11;
            this.bbiRealtimeMonitoring.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.bbiRealtimeMonitoring.ImageOptions.AllowStubGlyph = DevExpress.Utils.DefaultBoolean.False;
            this.bbiRealtimeMonitoring.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("bbiRealtimeMonitoring.ImageOptions.DisabledImage")));
            this.bbiRealtimeMonitoring.ImageOptions.DisabledLargeImage = ((System.Drawing.Image)(resources.GetObject("bbiRealtimeMonitoring.ImageOptions.DisabledLargeImage")));
            this.bbiRealtimeMonitoring.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiRealtimeMonitoring.ImageOptions.LargeImage")));
            this.bbiRealtimeMonitoring.ItemAppearance.Pressed.BackColor = ((System.Drawing.Color)(resources.GetObject("bbiRealtimeMonitoring.ItemAppearance.Pressed.BackColor")));
            this.bbiRealtimeMonitoring.ItemAppearance.Pressed.Options.UseBackColor = true;
            this.bbiRealtimeMonitoring.ItemClickFireMode = DevExpress.XtraBars.BarItemEventFireMode.Postponed;
            this.bbiRealtimeMonitoring.Name = "bbiRealtimeMonitoring";
            this.bbiRealtimeMonitoring.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            this.bbiRealtimeMonitoring.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.bbiRealtimeMonitoring.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiDeviceManager
            // 
            resources.ApplyResources(this.bbiDeviceManager, "bbiDeviceManager");
            this.bbiDeviceManager.GroupIndex = 1;
            this.bbiDeviceManager.Id = 12;
            this.bbiDeviceManager.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("bbiDeviceManager.ImageOptions.DisabledImage")));
            this.bbiDeviceManager.ImageOptions.DisabledLargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDeviceManager.ImageOptions.DisabledLargeImage")));
            this.bbiDeviceManager.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDeviceManager.ImageOptions.LargeImage")));
            this.bbiDeviceManager.Name = "bbiDeviceManager";
            this.bbiDeviceManager.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.bbiDeviceManager.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiDeviceManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiDebugging
            // 
            resources.ApplyResources(this.bbiDebugging, "bbiDebugging");
            this.bbiDebugging.GroupIndex = 1;
            this.bbiDebugging.Id = 13;
            this.bbiDebugging.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("bbiDebugging.ImageOptions.DisabledImage")));
            this.bbiDebugging.ImageOptions.DisabledLargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDebugging.ImageOptions.DisabledLargeImage")));
            this.bbiDebugging.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDebugging.ImageOptions.LargeImage")));
            this.bbiDebugging.Name = "bbiDebugging";
            this.bbiDebugging.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.bbiDebugging.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiDebugging.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiExhaustData
            // 
            resources.ApplyResources(this.bbiExhaustData, "bbiExhaustData");
            this.bbiExhaustData.Id = 18;
            this.bbiExhaustData.Name = "bbiExhaustData";
            this.bbiExhaustData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiAirQuality
            // 
            resources.ApplyResources(this.bbiAirQuality, "bbiAirQuality");
            this.bbiAirQuality.Id = 19;
            this.bbiAirQuality.Name = "bbiAirQuality";
            this.bbiAirQuality.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiUserManage
            // 
            resources.ApplyResources(this.bbiUserManage, "bbiUserManage");
            this.bbiUserManage.Id = 20;
            this.bbiUserManage.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("bbiUserManage.ImageOptions.DisabledImage")));
            this.bbiUserManage.ImageOptions.DisabledLargeImage = ((System.Drawing.Image)(resources.GetObject("bbiUserManage.ImageOptions.DisabledLargeImage")));
            this.bbiUserManage.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiUserManage.ImageOptions.LargeImage")));
            this.bbiUserManage.Name = "bbiUserManage";
            this.bbiUserManage.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.bbiUserManage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiAssistManage
            // 
            resources.ApplyResources(this.bbiAssistManage, "bbiAssistManage");
            this.bbiAssistManage.Id = 24;
            this.bbiAssistManage.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("bbiAssistManage.ImageOptions.DisabledImage")));
            this.bbiAssistManage.ImageOptions.DisabledLargeImage = ((System.Drawing.Image)(resources.GetObject("bbiAssistManage.ImageOptions.DisabledLargeImage")));
            this.bbiAssistManage.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiAssistManage.ImageOptions.LargeImage")));
            this.bbiAssistManage.Name = "bbiAssistManage";
            this.bbiAssistManage.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.bbiAssistManage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiStationSettings
            // 
            resources.ApplyResources(this.bbiStationSettings, "bbiStationSettings");
            this.bbiStationSettings.GroupIndex = 1;
            this.bbiStationSettings.Id = 25;
            this.bbiStationSettings.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("bbiStationSettings.ImageOptions.DisabledImage")));
            this.bbiStationSettings.ImageOptions.DisabledLargeImage = ((System.Drawing.Image)(resources.GetObject("bbiStationSettings.ImageOptions.DisabledLargeImage")));
            this.bbiStationSettings.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiStationSettings.ImageOptions.LargeImage")));
            this.bbiStationSettings.Name = "bbiStationSettings";
            this.bbiStationSettings.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.bbiStationSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiLimitingSettings
            // 
            resources.ApplyResources(this.bbiLimitingSettings, "bbiLimitingSettings");
            this.bbiLimitingSettings.Id = 26;
            this.bbiLimitingSettings.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("bbiLimitingSettings.ImageOptions.DisabledImage")));
            this.bbiLimitingSettings.ImageOptions.DisabledLargeImage = ((System.Drawing.Image)(resources.GetObject("bbiLimitingSettings.ImageOptions.DisabledLargeImage")));
            this.bbiLimitingSettings.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiLimitingSettings.ImageOptions.LargeImage")));
            this.bbiLimitingSettings.Name = "bbiLimitingSettings";
            this.bbiLimitingSettings.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.bbiLimitingSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiRunningLog
            // 
            resources.ApplyResources(this.bbiRunningLog, "bbiRunningLog");
            this.bbiRunningLog.Id = 12;
            this.bbiRunningLog.Name = "bbiRunningLog";
            this.bbiRunningLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiBackgroundLog
            // 
            resources.ApplyResources(this.bbiBackgroundLog, "bbiBackgroundLog");
            this.bbiBackgroundLog.Id = 14;
            this.bbiBackgroundLog.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("bbiBackgroundLog.ImageOptions.DisabledImage")));
            this.bbiBackgroundLog.ImageOptions.DisabledLargeImage = ((System.Drawing.Image)(resources.GetObject("bbiBackgroundLog.ImageOptions.DisabledLargeImage")));
            this.bbiBackgroundLog.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiBackgroundLog.ImageOptions.LargeImage")));
            this.bbiBackgroundLog.Name = "bbiBackgroundLog";
            this.bbiBackgroundLog.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.bbiBackgroundLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiSystemLog
            // 
            resources.ApplyResources(this.bbiSystemLog, "bbiSystemLog");
            this.bbiSystemLog.Id = 15;
            this.bbiSystemLog.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("bbiSystemLog.ImageOptions.DisabledImage")));
            this.bbiSystemLog.ImageOptions.DisabledLargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSystemLog.ImageOptions.DisabledLargeImage")));
            this.bbiSystemLog.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSystemLog.ImageOptions.LargeImage")));
            this.bbiSystemLog.Name = "bbiSystemLog";
            this.bbiSystemLog.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.bbiSystemLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiDataStatistics
            // 
            resources.ApplyResources(this.bbiDataStatistics, "bbiDataStatistics");
            this.bbiDataStatistics.Id = 17;
            this.bbiDataStatistics.Name = "bbiDataStatistics";
            this.bbiDataStatistics.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.DisabledImage")));
            this.barButtonItem1.ImageOptions.DisabledLargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.DisabledLargeImage")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // bbiDataCount
            // 
            resources.ApplyResources(this.bbiDataCount, "bbiDataCount");
            this.bbiDataCount.Id = 2;
            this.bbiDataCount.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("bbiDataCount.ImageOptions.DisabledImage")));
            this.bbiDataCount.ImageOptions.DisabledLargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDataCount.ImageOptions.DisabledLargeImage")));
            this.bbiDataCount.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDataCount.ImageOptions.LargeImage")));
            this.bbiDataCount.Name = "bbiDataCount";
            this.bbiDataCount.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiDataCount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // bbiUserMan
            // 
            resources.ApplyResources(this.bbiUserMan, "bbiUserMan");
            this.bbiUserMan.GroupIndex = 1;
            this.bbiUserMan.Id = 4;
            this.bbiUserMan.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("bbiUserMan.ImageOptions.DisabledImage")));
            this.bbiUserMan.ImageOptions.DisabledLargeImage = ((System.Drawing.Image)(resources.GetObject("bbiUserMan.ImageOptions.DisabledLargeImage")));
            this.bbiUserMan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiUserMan.ImageOptions.LargeImage")));
            this.bbiUserMan.Name = "bbiUserMan";
            this.bbiUserMan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ItemClick);
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            resources.ApplyResources(this.ribbonPageCategory1, "ribbonPageCategory1");
            // 
            // menuOperate
            // 
            this.menuOperate.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("menuOperate.Appearance.BackColor")));
            this.menuOperate.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("menuOperate.Appearance.Font")));
            this.menuOperate.Appearance.Options.UseBackColor = true;
            this.menuOperate.Appearance.Options.UseFont = true;
            this.menuOperate.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpHome});
            this.menuOperate.ImageOptions.Alignment = DevExpress.Utils.HorzAlignment.Center;
            this.menuOperate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuOperate.ImageOptions.Image")));
            this.menuOperate.Name = "menuOperate";
            // 
            // rpHome
            // 
            this.rpHome.ImageOptions.SvgImageSize = new System.Drawing.Size(1440, 94);
            this.rpHome.ItemLinks.Add(this.bbiRealtimeMonitoring);
            this.rpHome.ItemLinks.Add(this.bbiDeviceManager);
            this.rpHome.ItemLinks.Add(this.bbiDebugging);
            this.rpHome.ItemLinks.Add(this.bbiDataCount);
            this.rpHome.ItemsLayout = DevExpress.XtraBars.Ribbon.RibbonPageGroupItemsLayout.OneRow;
            this.rpHome.Name = "rpHome";
            this.rpHome.ShowCaptionButton = false;
            // 
            // menuSystem
            // 
            this.menuSystem.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("menuSystem.Appearance.Font")));
            this.menuSystem.Appearance.Options.UseFont = true;
            this.menuSystem.Appearance.Options.UseImage = true;
            this.menuSystem.Appearance.Options.UseTextOptions = true;
            this.menuSystem.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.menuSystem.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpSystem,
            this.rpgLog});
            this.menuSystem.ImageOptions.Alignment = DevExpress.Utils.HorzAlignment.Center;
            this.menuSystem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuSystem.ImageOptions.Image")));
            this.menuSystem.Name = "menuSystem";
            this.menuSystem.Visible = false;
            // 
            // rpSystem
            // 
            this.rpSystem.ItemLinks.Add(this.bbiUserMan);
            this.rpSystem.ItemLinks.Add(this.bbiAssistManage);
            this.rpSystem.Name = "rpSystem";
            this.rpSystem.ShowCaptionButton = false;
            // 
            // rpgLog
            // 
            this.rpgLog.ItemLinks.Add(this.bbiSystemLog);
            this.rpgLog.ItemLinks.Add(this.bbiBackgroundLog);
            this.rpgLog.Name = "rpgLog";
            resources.ApplyResources(this.rpgLog, "rpgLog");
            // 
            // menuStation
            // 
            this.menuStation.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("menuStation.Appearance.Font")));
            this.menuStation.Appearance.Options.UseFont = true;
            this.menuStation.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpStation});
            this.menuStation.ImageOptions.Alignment = DevExpress.Utils.HorzAlignment.Center;
            this.menuStation.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuStation.ImageOptions.Image")));
            this.menuStation.Name = "menuStation";
            this.menuStation.Visible = false;
            // 
            // rpStation
            // 
            this.rpStation.ItemLinks.Add(this.bbiStationSettings);
            this.rpStation.ItemLinks.Add(this.bbiLimitingSettings);
            this.rpStation.Name = "rpStation";
            this.rpStation.ShowCaptionButton = false;
            // 
            // menuHelp
            // 
            this.menuHelp.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("menuHelp.Appearance.Font")));
            this.menuHelp.Appearance.Options.UseFont = true;
            this.menuHelp.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpHelp});
            this.menuHelp.ImageOptions.Alignment = DevExpress.Utils.HorzAlignment.Center;
            this.menuHelp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuHelp.ImageOptions.Image")));
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Visible = false;
            // 
            // rpHelp
            // 
            this.rpHelp.ItemLinks.Add(this.bbiAbout);
            this.rpHelp.ItemLinks.Add(this.bbiHelp);
            this.rpHelp.Name = "rpHelp";
            this.rpHelp.ShowCaptionButton = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ForeColor = System.Drawing.Color.Silver;
            this.ribbonStatusBar.ItemLinks.Add(this.bsiCopyRight);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiInfo);
            resources.ApplyResources(this.ribbonStatusBar, "ribbonStatusBar");
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // dockManager1
            // 
            this.dockManager1.DockingOptions.FloatOnDblClick = false;
            this.dockManager1.DockingOptions.ShowAutoHideButton = false;
            this.dockManager1.DockingOptions.ShowCaptionOnMouseHover = true;
            this.dockManager1.DockingOptions.ShowCloseButton = false;
            this.dockManager1.DockingOptions.ShowMaximizeButton = false;
            this.dockManager1.DockMode = DevExpress.XtraBars.Docking.Helpers.DockMode.Standard;
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl"});
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            this.barDockControlBottom.Manager = null;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            this.barDockControlLeft.Manager = null;
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            this.barDockControlRight.Manager = null;
            // 
            // rpgFollowUp
            // 
            this.rpgFollowUp.Name = "rpgFollowUp";
            this.rpgFollowUp.ShowCaptionButton = false;
            resources.ApplyResources(this.rpgFollowUp, "rpgFollowUp");
            // 
            // notify
            // 
            resources.ApplyResources(this.notify, "notify");
            this.notify.ContextMenuStrip = this.IconMenu;
            this.notify.DoubleClick += new System.EventHandler(this.notify_DoubleClick);
            this.notify.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notify_MouseClick);
            // 
            // IconMenu
            // 
            this.IconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExit});
            this.IconMenu.Name = "contextMenuStrip1";
            resources.ApplyResources(this.IconMenu, "IconMenu");
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            resources.ApplyResources(this.miExit, "miExit");
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // barButtonItem2
            // 
            resources.ApplyResources(this.barButtonItem2, "barButtonItem2");
            this.barButtonItem2.Id = 19;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // pcMain
            // 
            resources.ApplyResources(this.pcMain, "pcMain");
            this.pcMain.Name = "pcMain";
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.ribbonControl;
            // 
            // frmMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("frmMain.Appearance.BackColor")));
            this.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("frmMain.Appearance.ForeColor")));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcMain);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmUserManage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.IconMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage menuOperate;
        private DevExpress.XtraBars.Ribbon.RibbonPage menuHelp;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgFollowUp;
        private DevExpress.XtraBars.BarButtonItem bbiHelp;
        private DevExpress.XtraBars.BarButtonItem bbiAbout;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpHelp;
        private DevExpress.XtraBars.BarStaticItem bsiCopyRight;
        private DevExpress.XtraBars.Ribbon.RibbonPage menuStation;
        private DevExpress.XtraBars.PopupMenu pmUserManage;
        private DevExpress.XtraBars.BarButtonItem bbiLogin;
        private DevExpress.XtraBars.BarButtonItem bbiModifyPassword;
        private DevExpress.XtraBars.BarButtonItem bbiUser;
        private DevExpress.XtraBars.Ribbon.RibbonPage menuSystem;
        private DevExpress.XtraBars.BarButtonItem bsiInfo;
        private DevExpress.XtraBars.BarButtonItem bbiRealtimeMonitoring;
        private DevExpress.XtraBars.BarButtonItem bbiDeviceManager;
        private DevExpress.XtraBars.BarButtonItem bbiDebugging;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpHome;
        private DevExpress.XtraBars.BarButtonItem bbiExhaustData;
        private DevExpress.XtraBars.BarButtonItem bbiAirQuality;
        private DevExpress.XtraBars.BarButtonItem bbiUserManage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpSystem;
        private DevExpress.XtraBars.BarButtonItem bbiAssistManage;
        private DevExpress.XtraBars.BarButtonItem bbiStationSettings;
        private DevExpress.XtraBars.BarButtonItem bbiLimitingSettings;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpStation;
        private DevExpress.XtraBars.BarButtonItem bbiRunningLog;
        private DevExpress.XtraBars.BarButtonItem bbiBackgroundLog;
        private DevExpress.XtraBars.BarButtonItem bbiSystemLog;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgLog;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ContextMenuStrip IconMenu;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private DevExpress.XtraBars.BarButtonItem bbiLogout2;
        private System.Windows.Forms.Timer timerLogout;
        private System.Windows.Forms.HelpProvider hpHelp;
        private DevExpress.XtraBars.BarButtonItem bbiDataStatistics;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraEditors.PanelControl pcMain;
        private DevExpress.XtraBars.BarButtonItem bbiDataCount;
        private DevExpress.XtraBars.BarButtonItem bbiUserMan;
        protected DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem bbiLogout;
    }
}

