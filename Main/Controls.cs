﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraNavBar;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Import.Html;
using DevExpress.XtraRichEdit.Model;
using DevExpress.XtraSplashScreen;
using wayeal.language;

namespace wayeal.os.exhaust
{
    public class ModulesNavigator {
        RibbonControl ribbon;
        Control panel;
        string currentModuleName = string.Empty;
        public ModulesNavigator(RibbonControl ribbon, Control panel) {
            this.ribbon = ribbon;
            this.panel = panel;
        }
        public void ChangeSelectedItem(NavBarItemLink link, object moduleData) {

            NavBarGroupTagObject groupObject = link.Item.Tag as NavBarGroupTagObject;
            if (groupObject == null)
                return;
            List<RibbonPage> deferredPagesToShow = new List<RibbonPage>();
            foreach (RibbonPage page in ribbon.Pages) {
                if (!string.IsNullOrEmpty(string.Format("{0}", page.Tag))) {
                    bool isPageVisible = groupObject.Name.Equals(page.Tag);
                    if (isPageVisible != page.Visible && isPageVisible)
                        deferredPagesToShow.Add(page);
                    else
                        page.Visible = isPageVisible;
                }
            }
            bool firstShow = groupObject.Module == null;
            if (firstShow) {
                if (SplashScreenManager.Default == null)
                    SplashScreenManager.ShowForm(ribbon.FindForm(), typeof(Forms.wfMain), false, true);
                ConstructorInfo constructorInfoObj = groupObject.ModuleType.GetConstructor(groupObject.ParamType);
                if (constructorInfoObj != null) {
                    try {                        
                        groupObject.Module = constructorInfoObj.Invoke(groupObject.Param) as BaseModule;
                        if (groupObject.Module == null) return;
                        groupObject.Module.InitModule(ribbon, moduleData);
                        currentModuleName = link.Caption;
                    } catch(Exception e) {
                        var entryAsm = Assembly.GetEntryAssembly();
                        string msg = string.Format("Error on Showing Module: {0}\r\nPrevModule: {1}\r\nStartUp: {2}", 
                            link.Caption, currentModuleName, (entryAsm != null ? entryAsm.Location : string.Empty));
                        throw new ApplicationException(msg, e);
                    }
                }
                if (SplashScreenManager.Default != null) {
                    Form frm = moduleData as Form;
                    if (frm != null) {
                        if (SplashScreenManager.FormInPendingState)
                            SplashScreenManager.CloseForm();
                        else
                            SplashScreenManager.CloseForm(false, 500, frm);
                    }
                    else
                        SplashScreenManager.CloseForm();
                }
            }
            //切换界面时重置界面权限
            //if(groupObject.Module!=null) Program.permissionManager.ApplyPermission(groupObject.Module);
            ribbon.ColorScheme = groupObject.RibbonScheme;
            foreach (RibbonPage page in deferredPagesToShow) {
                page.Visible = true;
            }
            
            foreach (RibbonPage page in ribbon.Pages) {                
                if (page.Visible && ribbon.SelectedPage == page)
                {
                    ribbon.SelectedPage = page;
                    break;
                }
            }

            if (groupObject.Module != null) {
                if (panel.Controls.Count > 0) {
                    BaseModule currentModule = panel.Controls[0] as BaseModule;
                    if (currentModule != null)
                        currentModule.HideModule();
                }
                panel.Controls.Clear();
                panel.Controls.Add(groupObject.Module);
                groupObject.Module.Dock = DockStyle.Fill;
                groupObject.Module.ShowModule(firstShow);
            }
        }
        public BaseModule CurrentModule {
            get {
                if (panel.Controls.Count == 0)
                    return null;
                return panel.Controls[0] as BaseModule;
            }
        }
    }
    public class BaseControl : XtraUserControl {
        public BaseControl() {
            if (!DesignTimeTools.IsDesignMode)
                LookAndFeel.ActiveLookAndFeel.StyleChanged += new EventHandler(ActiveLookAndFeel_StyleChanged);
            this.VisibleChanged += new EventHandler(BaseControl_VisibleChanged);
        }
        void BaseControl_VisibleChanged(object sender, EventArgs e) {
            if (this.Visible) {
                ShowControlFirstTime();
                this.VisibleChanged -= new EventHandler(BaseControl_VisibleChanged);
            }
        }
        internal virtual void ShowControlFirstTime() { }
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            if (!DesignTimeTools.IsDesignMode)
                LookAndFeelStyleChanged();
        }
        protected override void Dispose(bool disposing) {
            if (disposing && !DesignTimeTools.IsDesignMode)
                LookAndFeel.ActiveLookAndFeel.StyleChanged -= new EventHandler(ActiveLookAndFeel_StyleChanged);
            base.Dispose(disposing);
        }
        void ActiveLookAndFeel_StyleChanged(object sender, EventArgs e) {
            LookAndFeelStyleChanged();
        }
        protected virtual void LookAndFeelStyleChanged() { }
    }
    public class BaseModule : BaseControl {
        protected string partName = string.Empty;
                
        public BaseModule() { }

        internal frmMain OwnerForm { get { return this.FindForm() as frmMain; } }
        protected RibbonControl MainRibbon { get { return OwnerForm.Ribbon; } }
        private bool bExecMergeRibbon = false;
        public bool ExecMergeRibbon { set { bExecMergeRibbon = value; } get { return bExecMergeRibbon; } }

        internal virtual void ShowModule(bool firstShow) {
            if (OwnerForm == null)
                return;
            MergeRibbon();
            ShowInfo();
        }

        internal virtual void FocusObject(object obj) { }
        internal void ShowInfo() {
            if (OwnerForm == null)
                return;
            if (Grid == null) {
                OwnerForm.ShowInfo(null);
                return;
            }
            ICollection list = Grid.DataSource as ICollection;
            if (list == null)
                OwnerForm.ShowInfo(null);
            else
                OwnerForm.ShowInfo(list.Count);
        }
        internal virtual void HideModule() {
            if (OwnerForm != null)
                UnMergeRibbon();
        }
        internal virtual void InitModule(IDXMenuManager manager, object data) {
            SetMenuManager(this.Controls, manager);
            if (Grid != null && Grid.MainView is ColumnView) {
                ((ColumnView)Grid.MainView).ColumnFilterChanged += new EventHandler(BaseModule_ColumnFilterChanged);
            }
            CapitalizeChildRibbonPages();
        }
        void CapitalizeChildRibbonPages() {
            if (ChildRibbon == null)
                return;
            foreach (RibbonPage page in ChildRibbon.Pages)
                page.Text = page.Text.ToUpper();
            foreach (RibbonPageCategory category in ChildRibbon.PageCategories) {
                foreach (RibbonPage page in category.Pages)
                    page.Text = page.Text.ToUpper();
            }
        }

        internal virtual void MergeRibbon()
        {
            if (!this.ExecMergeRibbon) return;
            List<RibbonControl> rcs = new List<RibbonControl>();
            List<RibbonStatusBar> rsbs = new List<RibbonStatusBar>();
            MergeRibbon(this, rcs, rsbs);
            doMergeRibbon(this, rcs, rsbs);

            if (rcs.Count > 0) rcs.Add(OwnerForm.Ribbon);
            for (int i = 1; i < rcs.Count; i++)
            {
                rcs[i].MergeRibbon(rcs[i - 1]);
            }

            RibbonPage page = OwnerForm.Ribbon.Pages.GetPageByText(Program.controlResouce.GetLocalizedString(ControlStringId.menuHelp));
            if (page != null)
            {
                OwnerForm.Ribbon.MergedPages.Remove(page);
                OwnerForm.Ribbon.MergedPages.Insert(OwnerForm.Ribbon.MergedPages.Count, page);
            }

            if (rsbs.Count > 0) rsbs.Add(OwnerForm.RibbonStatusBar);
            for (int i = 1; i < rsbs.Count; i++)
            {
                rsbs[i].MergeStatusBar(rsbs[i - 1]);
            }
        }

        internal virtual void MergeRibbon(Control cc, List<RibbonControl> rcs, List<RibbonStatusBar> rsbs)
        {
            foreach (Control c in cc.Controls)
            {
                if (c.HasChildren) MergeRibbon(c,rcs,rsbs);
                doMergeRibbon(c,rcs, rsbs);
            }            
        }
        internal virtual void doMergeRibbon(Control c,List<RibbonControl> rcs, List<RibbonStatusBar> rsbs)
        {
            if (c is BaseModule)
            {
                if ((c as BaseModule).AutoMergeRibbon)
                {
                    if ((c as BaseModule).ChildRibbon != null && !rcs.Contains((c as BaseModule).ChildRibbon))
                        rcs.Add((c as BaseModule).ChildRibbon);
                    if ((c as BaseModule).ChildRibbonStatusBar != null && !rsbs.Contains((c as BaseModule).ChildRibbonStatusBar))
                        rsbs.Add((c as BaseModule).ChildRibbonStatusBar);
                }
            }
        }
        internal virtual void UnMergeRibbon()
        {
            RibbonPage page = OwnerForm.Ribbon.MergedPages.GetPageByText(Program.controlResouce.GetLocalizedString(ControlStringId.menuHelp));
            if (page != null)
                OwnerForm.Ribbon.MergedPages.Remove(page);
            UnMergeRibbon(this);
            doUnMergeRibbon(this);

            OwnerForm.Ribbon.UnMergeRibbon();
            if (page != null)
                OwnerForm.Ribbon.Pages.Insert(OwnerForm.Ribbon.Pages.Count, page);
        }

        internal virtual void UnMergeRibbon(Control cc)
        {
            foreach (Control c in cc.Controls)
            {
                if (c.HasChildren) UnMergeRibbon(c);
                doUnMergeRibbon(c);
            }
        }
        internal virtual void doUnMergeRibbon(Control c)
        {
            if (c is BaseModule)
            {
                if ((c as BaseModule).AutoMergeRibbon)
                {
                    if ((c as BaseModule).ChildRibbon != null) (c as BaseModule).ChildRibbon.UnMergeRibbon();
                    if ((c as BaseModule).ChildRibbonStatusBar != null) (c as BaseModule).ChildRibbonStatusBar.UnMergeStatusBar();
                }
            }
        }

        internal void ShowInfo(ColumnView view) {
            if (OwnerForm == null) return;
            OwnerForm.ShowInfo(view.DataRowCount);
        }
        void BaseModule_ColumnFilterChanged(object sender, EventArgs e) {
            ShowInfo(sender as ColumnView);
        }
        void SetMenuManager(ControlCollection controlCollection, IDXMenuManager manager) {
            foreach (Control ctrl in controlCollection) {
                GridControl grid = ctrl as GridControl;
                if (grid != null) {
                    grid.MenuManager = manager;
                    break;
                }
                PivotGridControl pivot = ctrl as PivotGridControl;
                if(pivot != null) {
                    pivot.MenuManager = manager;
                    break;
                }
                BaseEdit edit = ctrl as BaseEdit;
                if (edit != null) {
                    edit.MenuManager = manager;
                    break;
                }
                SetMenuManager(ctrl.Controls, manager);
            }
        }
        RibbonControl FindRibbon(ControlCollection controls) {
            RibbonControl res = controls.OfType<Control>().FirstOrDefault(x => x is RibbonControl) as RibbonControl;
            if (res != null)
                return res;
            foreach (Control control in controls) {
                if (control.HasChildren) {
                    res = FindRibbon(control.Controls);
                    if (res != null)
                        return res;
                }
            }
            return null;
        }

        protected virtual bool AllowZoomControl { get { return false; } }
        protected virtual void SetZoomCaption() { }
        public virtual float ZoomFactor {
            get { return 1; }
            set { }
        }
        public virtual IPrintable PrintableComponent { get { return Grid; } }
        public virtual IPrintable ExportComponent { get { return Grid; } }
        public virtual bool AllowRtfTitle { get { return true; } }
        protected virtual GridControl Grid { get { return null; } }
        protected virtual bool SaveAsEnable { get { return false; } }
        protected virtual bool SaveAttachmentEnable { get { return false; } }
        protected virtual bool SaveCalendarVisible { get { return false; } }
        protected internal virtual void ButtonClick(string tag) { }
        protected internal virtual void SendKeyDown(KeyEventArgs e) { }
        protected internal virtual RichEditControl CurrentRichEdit { get { return null; } }
        public virtual string ModuleName { get { return this.GetType().Name; } }
        public string PartName { get { return partName; } }
        [DefaultValue(false)]
        protected virtual bool AutoMergeRibbon { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        protected virtual RibbonControl ChildRibbon {
            get {
                if (!AutoMergeRibbon)
                    return null;
                return FindRibbon(Controls);
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        protected virtual RibbonStatusBar ChildRibbonStatusBar {
            get {
                if(ChildRibbon != null) return ChildRibbon.StatusBar;
                return null;
            }
        }
    }
    public class NavBarGroupTagObject {
        string name;
        Type moduleType;
        BaseModule module;
        Object[] paramObj;
        RibbonControlColorScheme ribbonScheme = RibbonControlColorScheme.Default;
        public NavBarGroupTagObject(string name, Type moduleType) : this(name, moduleType, RibbonControlColorScheme.Default ) {
        }
        public NavBarGroupTagObject(string name, Type moduleType,Object[] paramObj) : this(name, moduleType, RibbonControlColorScheme.Default)
        {
            this.paramObj = paramObj;
        }
        public NavBarGroupTagObject(string name, Type moduleType, RibbonControlColorScheme ribbonScheme) {
            this.name = name;
            this.moduleType = moduleType;
            this.ribbonScheme = ribbonScheme;
            this.paramObj =null;
            module = null;
        }
        public string Name { get { return name; } }
        public Type ModuleType { get { return moduleType; } }
        public Type[] ParamType {
            get
            {
                if(paramObj!=null && paramObj.Length>0)
                {
                    List<Type> types = new List<Type>();
                    for (int i = 0; i < paramObj.Length; i++) types.Add(paramObj[i].GetType());
                    return types.ToArray<Type>();
                }
                return Type.EmptyTypes;
            }
        }
        public object[] Param { get { return paramObj; } }
        public RibbonControlColorScheme RibbonScheme { get { return ribbonScheme; } }
        public BaseModule Module {
            get { return module; }
            set { module = value; }
        }
    }
    public class BackstageViewLabel : LabelControl {
        public BackstageViewLabel() {
            Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            LineVisible = true;
            ShowLineShadow = false;
        }
    }
    public class ZoomManager {
        ZoomTrackBarControl zoomControl;
        int zoomFactor = 0;
        List<int> zoomValues = new List<int>() { 100, 115, 130, 150, 200, 250, 300, 350, 400, 500 };
        RibbonControl ribbon;
        BarEditItem beiZoom;
        ModulesNavigator modulesNavigator;
        public ZoomManager(RibbonControl ribbon, ModulesNavigator modulesNavigator, BarEditItem beItem) {
            this.ribbon = ribbon;
            this.modulesNavigator = modulesNavigator;
            this.beiZoom = beItem;
            this.beiZoom.HiddenEditor += new DevExpress.XtraBars.ItemClickEventHandler(this.beiZoom_HiddenEditor);
            this.beiZoom.ShownEditor += new DevExpress.XtraBars.ItemClickEventHandler(this.beiZoom_ShownEditor);
        }
        ZoomTrackBarControl ZoomControl { get { return zoomControl; } }
        public int ZoomFactor {
            get { return zoomFactor; }
            set {
                zoomFactor = value;
                beiZoom.Caption = string.Format(" {0}%", ZoomFactor);
                int index = zoomValues.IndexOf(ZoomFactor);
                if (index == -1)
                    beiZoom.EditValue = ZoomFactor / 10;
                else
                    beiZoom.EditValue = 10 + index;
                modulesNavigator.CurrentModule.ZoomFactor = (float)ZoomFactor / 100;
            }
        }
        public void SetZoomCaption(string caption) {
            beiZoom.Caption = caption;
        }
        private void beiZoom_ShownEditor(object sender, ItemClickEventArgs e) {
            this.zoomControl = ribbon.Manager.ActiveEditor as ZoomTrackBarControl;
            if (ZoomControl != null) {
                ZoomControl.ValueChanged += new EventHandler(OnZoomTackValueChanged);
                OnZoomTackValueChanged(ZoomControl, EventArgs.Empty);
            }
        }
        private void beiZoom_HiddenEditor(object sender, ItemClickEventArgs e) {
            ZoomControl.ValueChanged -= new EventHandler(OnZoomTackValueChanged);
            this.zoomControl = null;
        }
        private void OnZoomTackValueChanged(object sender, EventArgs e) {
            int val = val = ZoomControl.Value * 10;
            if (ZoomControl.Value > 10)
                val = zoomValues[ZoomControl.Value - 10];
            ZoomFactor = val;
        }
    }
    public class ObjectToolTipController : IDisposable {
        ToolTipController controller;
        Control parent;
        object editObject;
        public object EditObject { get { return editObject; } }
        public ObjectToolTipController(Control parent) {
            this.parent = parent;
            this.parent.Disposed += new EventHandler(delegate { Dispose(); });
            this.controller = new ToolTipController();
            this.controller.ToolTipType = ToolTipType.SuperTip;
            this.controller.AllowHtmlText = true;
            this.controller.ReshowDelay = controller.InitialDelay;
            this.controller.AutoPopDelay = 10000;
            parent.MouseDown += new MouseEventHandler(delegate { HideHint(false); });
            parent.MouseLeave += new EventHandler(delegate { HideHint(true); });
        }
        public void ShowHint(object editObject, Point location) {
            if (object.Equals(editObject, this.editObject))
                return;
            this.editObject = editObject;
            ToolTipControlInfo info = new ToolTipControlInfo();
            ToolTipItem item = new ToolTipItem();
            InitToolTipItem(item);
            item.ImageToTextDistance = 10;
            info.Object = DateTime.Now.Ticks;
            info.SuperTip = new SuperToolTip();
            info.SuperTip.Items.Add(item);
            info.ToolTipPosition = this.parent.PointToScreen(location);
            controller.ShowHint(info);
        }
        protected virtual void InitToolTipItem(ToolTipItem item) {
        }
        public void HideHint(bool clearCurrentObject) {
            if (clearCurrentObject)
                this.editObject = null;
            this.controller.HideHint();
        }
        #region IDisposable Members
        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                this.controller.Dispose();
            }
        }
        ~ObjectToolTipController() {
            Dispose(false);
        }
        #endregion
    }
    //public class ContactToolTipController : ObjectToolTipController {
    //    const int MaxPhotoWidth = 120, MaxPhotoHeight = 120;
    //    public ContactToolTipController(Control parent) : base(parent) { }
    //    Content CurrentContact { get { return EditObject as Constant; } }
    //    protected override void InitToolTipItem(ToolTipItem item) {
    //        if (CurrentContact == null)
    //            return;
    //        if (CurrentContact.Photo != null)
    //            item.Image = ImageCreator.CreateImage(CurrentContact.Photo, MaxPhotoWidth, MaxPhotoHeight);
    //        item.Text = CurrentContact.GetContactInfoHtml();
    //    }
    //}
    public class ImageCreator {
        public static Image CreateImage(Image srcImage, int maxWidth, int maxHeight) {
            if (srcImage == null)
                return null;
            Size size = GetPhotoSize(srcImage, maxWidth, maxHeight);
            Image ret = new Bitmap(size.Width, size.Height);
            using (Graphics gr = Graphics.FromImage(ret)) {
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gr.DrawImage(srcImage, new Rectangle(0, 0, size.Width, size.Height));
            }
            return ret;
        }
        static Size GetPhotoSize(Image image, int maxWidth, int maxHeight) {
            int width = Math.Min(maxWidth, image.Width),
                height = width * image.Height / image.Width;
            if (height > maxHeight) {
                height = maxHeight;
                width = height * image.Width / image.Height;
            }
            return new Size(width, height);
        }
        public static Rectangle GetZoomDestRectangle(Rectangle r, Image img) {
            float horzRatio = Math.Min((float)r.Width / img.Width, 1);
            float vertRatio = Math.Min((float)r.Height / img.Height, 1);
            float zoomRatio = Math.Min(horzRatio, vertRatio);

            return new Rectangle(
                r.Left + (int)(r.Width - img.Width * zoomRatio) / 2,
                r.Top + (int)(r.Height - img.Height * zoomRatio) / 2,
                (int)(img.Width * zoomRatio),
                (int)(img.Height * zoomRatio));
        }
    }
}
