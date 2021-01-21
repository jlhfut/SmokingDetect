using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraNavBar;
using wayeal.language;
using System.Globalization;
using DevExpress.XtraEditors;
using wayeal.plugin;
using System.Threading;
using wayeal.os.exhaust.ViewModel;
using System.IO;
using wayeal.os.exhaust.Forms;
using wayeal.os.exhaust.HKDevice;

namespace wayeal.os.exhaust
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
                #region defines
        ModulesNavigator modulesNavigator = null;
        BarButtonItem activeBarItem = null;
        MouseHook hook = null;


        

        

        //当前用户名
        public static string UserName = Program.infoResource.GetLocalizedString(InfoId.Tourist);// "游客"
        private string SuperManager = "WAYEE";
        string _helpChmPath = null;

        #endregion

        #region init
        public frmMain()
        {
            try
            {

                
                // ribbonControl.Tag=new NavBarGroupTagObject(ribbonControl.Name, typeof(RibbonControl), RibbonControlColorScheme.Purple);
               bool flag= CHCNetSDK.NET_DVR_Init();
                if (flag == false)
                {
                    MessageBox.Show("SDK初始化失败");
                }

                InitializeComponent();
                modulesNavigator = new ModulesNavigator(ribbonControl, pcMain);
               // Program.resourceManager.ApplyLanguage(this);
                InitBarItemLinks();
                //Program.permissionManager.ApplyPermission(this);
                string log = Program.infoResource.GetLocalizedString(language.InfoId.OpenApp);
                //   ErrorLog.SystemLog(DateTime.Now, log, bbiUser.Caption);

                bbiLogout2.Visibility = BarItemVisibility.Never;

                hook = new MouseHook();
                hook.OnMouseActivity += Hook_OnMouseActivity;
                hook.Start();

                HelpChmLoad();
            }
            catch (Exception ex)
            {
                //       ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void Hook_OnMouseActivity(object sender, MouseEventArgs e)
        {
            Program.IdleStart = new TimeSpan(DateTime.Now.Ticks);
        }

        /// <summary>
        /// init expriment mode
        /// </summary>
        void InitBarItemLinks()
        {
            //bbiRealtimeMonitoring.Tag = new NavBarGroupTagObject(bbiRealtimeMonitoring.Name, typeof(Modules.ucRealtimeMonitor));
            //bbiCalibration.Tag = new NavBarGroupTagObject(bbiCalibration.Name, typeof(Modules.ucConcentrationCalibrator));
            //bbiDebugging.Tag = new NavBarGroupTagObject(bbiDebugging.Name, typeof(Modules.ucDebugger));

            //bbiStationSettings.Tag = new NavBarGroupTagObject(bbiStationSettings.Caption, typeof(Modules.ucStationSettings));
            //bbiLimitingSettings.Tag = new NavBarGroupTagObject(bbiLimitingSettings.Caption, typeof(Modules.ucLimitingSettings));

            //bbiAirQuality.Tag = new NavBarGroupTagObject(bbiAirQuality.Caption, typeof(Modules.ucAirQuality));
            //bbiExhaustData.Tag = new NavBarGroupTagObject(bbiExhaustData.Caption, typeof(Modules.ucExhaustData));
            //bbiDataStatistics.Tag=new NavBarGroupTagObject(bbiDataStatistics.Caption, typeof(Modules.ucDataStatistics));

            //用户管理模块
           bbiUserMan.Tag = new NavBarGroupTagObject(bbiUserMan.Caption, typeof(Modules.ucUserManager));

            //站点设置
            bbiStationSettings.Tag = new NavBarGroupTagObject(bbiStationSettings.Caption, typeof(Modules.ucStationSetting));
            //系统日志
           bbiSystemLog.Tag = new NavBarGroupTagObject(bbiSystemLog.Caption, typeof(Modules.ucSystemLog));
            //主页
            bbiRealtimeMonitoring.Tag = new NavBarGroupTagObject(bbiRealtimeMonitoring.Caption, typeof(Modules.ucMain));
            //后台日志
            bbiBackgroundLog.Tag = new NavBarGroupTagObject(bbiBackgroundLog.Caption, typeof(Modules.ucBackgroundLog));
            //限制范围
            bbiLimitingSettings.Tag = new NavBarGroupTagObject(bbiLimitingSettings.Caption, typeof(Modules.ucLimitingSettings));

            //辅助配置
            bbiAssistManage.Tag = new NavBarGroupTagObject(bbiAssistManage.Caption, typeof(Modules.ucAssistManage));

            //设备管理
             bbiDeviceManager.Tag = new NavBarGroupTagObject(bbiDeviceManager.Caption, typeof(Modules.ucDevicemanager));

            //历史记录
            bbiDebugging.Tag = new NavBarGroupTagObject(bbiDebugging.Caption, typeof(Modules.ucRealHistory));


            //数据统计
            bbiDataCount.Tag=new NavBarGroupTagObject(bbiDataCount.Caption, typeof(Modules.ucCountInfo));
            //关于
             bbiAbout.Tag= new NavBarGroupTagObject(bbiDataCount.Caption, typeof(Modules.ucAbout));

            //      bbiRoleManage.Tag = new NavBarGroupTagObject(bbiRoleManage.Caption, typeof(Modules.ucRoleManage));
            //       bbiCommunicationManage.Tag = new NavBarGroupTagObject(bbiCommunicationManage.Caption, typeof(Modules.ucCommunicationManage));
            //bbiAssistManage.Tag = new NavBarGroupTagObject(bbiAssistManage.Caption, typeof(Modules.ucAssistManage));


            //PluginInfo p = Program.appPluginManger.GetPlugin("SystemLog");
            //if (p != null) bbiSystemLog.Tag = new NavBarGroupTagObject(bbiSystemLog.Caption, typeof(Modules.ucLogManager), new object[] { p.SetupUI });
            //p = Program.appPluginManger.GetPlugin("RunningLog");
            //if (p != null) bbiRunningLog.Tag = new NavBarGroupTagObject(bbiRunningLog.Caption, typeof(Modules.ucLogManager), new object[] { p.SetupUI });
            //p = Program.appPluginManger.GetPlugin("BackgroundLog");
            //if (p != null) bbiBackgroundLog.Tag = new NavBarGroupTagObject(bbiBackgroundLog.Caption, typeof(Modules.ucLogManager), new object[] { p.SetupUI });

            ////实时监控
            bbiRealtimeMonitoring.Tag =  new NavBarGroupTagObject(bbiRealtimeMonitoring.Caption, typeof(Modules.ucMain));
            //用户管理
            bbiUser.Tag =  new NavBarGroupTagObject(bbiUser.Caption, typeof(Modules.ucUserManager));
            //NavBarGroupTagObject
            bbiStationSettings.Tag =  new NavBarGroupTagObject(bbiStationSettings.Caption, typeof(Modules.ucStationSetting));
            //关于
            //bbi_ItemClick(null, new ItemClickEventArgs(bbiAbout, null));
            bbi_ItemClick(null, new ItemClickEventArgs(bbiRealtimeMonitoring, null));


        }
        #endregion

        #region properties
        public RibbonStatusBar RibbonStatusBar { get { return ribbonStatusBar; } }
        #endregion

        #region events
        private void bbi_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                BarButtonItem v = (BarButtonItem)e.Item;
                if (v == bbiLogin)
                {
                    wfLogin login = new wfLogin();

                    //第四步  初始化事件
                    login.setFormTextVaule += Login_setFormTextVaule;

                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        Logout();
                        bbiUser.Caption = wfLogin.userName;
                        //Program.permissionManager.ActivePermission = wfLogin.permission;
                        UserName = bbiUser.Caption;


                        MessageBox.Show(UserName);
                       // Program.permissionManager.ApplyPermission(this);
                        //定时器初始化
                        timerLogout = new System.Windows.Forms.Timer();
                        this.timerLogout.Interval = 60 * 1000;
                        this.timerLogout.Tick += new System.EventHandler(OverTimeLogout);
                        timerLogout.Enabled = true;
                        Program.IdleStart = new TimeSpan(DateTime.Now.Ticks);

                        if (bbiUser.Caption != Program.infoResource.GetLocalizedString(InfoId.Tourist)) bbiLogout2.Visibility = BarItemVisibility.Always;
                    }

                    return;
                }
                if (v == bbiModifyPassword)
                {
                    if (bbiUser.Caption == Program.infoResource.GetLocalizedString(InfoId.Tourist))
                    {
                        XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.LoginFirst));
                        return;
                    }
                    if (bbiUser.Caption == SuperManager)
                    {
                        XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.NoPowerChangePwd));
                        return;
                    }
                    else
                    {
                        wfModifyPassword from = new wfModifyPassword(bbiUser.Caption);
                        from.ShowDialog();
                    }
                }
                if (v == bbiLogout)
                {
                   


                    bbiUser.Caption = "游客";

                   
                        menuSystem.Visible = false;
                        menuStation.Visible = false;
                        menuHelp.Visible = false;
                    frmMain frm = new frmMain();
                    frm.bbiDeviceManager.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    frm.bbiDebugging.Visibility= DevExpress.XtraBars.BarItemVisibility.Never;
                    frm.bbiDataCount.Visibility= DevExpress.XtraBars.BarItemVisibility.Never;


                    Logout();
                    //bbiLogout.Visibility = BarItemVisibility.Never;
                }
                //if (v == bbiHelp)
                //{
                //    if (String.IsNullOrEmpty(_helpChmPath)||!File.Exists(_helpChmPath))
                //    {
                //        XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.NoHelpChm));
                //        return;
                //    }
                //    Help.ShowHelpIndex(this, _helpChmPath);
                //}
                if (v.Tag != null)
                {
                    if (activeBarItem != null && activeBarItem.ImageOptions.DisabledLargeImage != null)
                    {
                        activeBarItem.ImageOptions.LargeImage = activeBarItem.ImageOptions.DisabledLargeImage;
                        activeBarItem.ImageOptions.Image = activeBarItem.ImageOptions.LargeImage;
                    }

                    activeBarItem = v;
                    if (v.ImageOptions.DisabledImage != null)
                    {
                        v.ImageOptions.LargeImage = v.ImageOptions.DisabledImage;
                        v.ImageOptions.Image = v.ImageOptions.LargeImage;
                    }

                    NavBarItemLink link = new NavBarItemLink(new NavBarItem(v.Name));
                    link.Item.Tag = v.Tag;
                    modulesNavigator.ChangeSelectedItem(link, null);
                }
            } 
            catch (Exception ex)
            {
                //    ErrorLog.Error(ex.StackTrace.ToString());
            }
        }


        //第五步  实现事件
        private void Login_setFormTextVaule(string uname,int textValue)
        {
            bbiUser.Caption = uname;

            if (textValue == 1)  //管理员
            {
                menuSystem.Visible = true;
                menuStation.Visible = true;
                menuHelp.Visible = true;
               
                this.bbiDeviceManager.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                this.bbiDebugging.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                this.bbiDataCount.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            }
            if (textValue == 0)//游客
            {
                menuSystem.Visible = false;
                menuStation.Visible = false;
                menuHelp.Visible = false;

                this.bbiDeviceManager.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.bbiDebugging.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.bbiDataCount.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            //具体实现
           
           

        }
        #endregion

        #region privates
        internal void ShowInfo(int? count)
        {
            if (count == null) bsiInfo.Caption = bsiInfo.Caption = Program.infoResource.GetLocalizedString(InfoId.VersionText);
            else
                bsiInfo.Caption = string.Format(Program.infoResource.GetLocalizedString(InfoId.VersionText), count.Value);
        }
        private void bbiAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            wfAbout from = new wfAbout();
            from.ShowDialog();
        }

        /// <summary>
        /// 定时器回调函数，超时注销登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OverTimeLogout(object sender, System.EventArgs e)
        {
            //if (Program.permissionManager.ActivePermission != 3 && Program.Idle)
            //{
            //    string log = Program.infoResource.GetLocalizedString(language.InfoId.Logout) + UserName;
            //    //     ErrorLog.SystemLog(DateTime.Now, log, UserName);
            //    Logout();
            //}
        }
        #endregion

        #region Notify
        private void notify_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Visible = true;
                WindowState = FormWindowState.Maximized;
                notify.Visible = false;
                base.OnDoubleClick(e);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        public void ChangeNotifyIcon(bool bl)
        {
            if (bl) WindowState = FormWindowState.Minimized;
            this.Visible = !bl;
            notify.Visible = bl;
            notify.Tag = bl.ToString();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notify.Visible = true;
            }
            base.OnSizeChanged(e);
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (notify.Tag == null || notify.Tag.ToString() == false.ToString())
                {
                    //再次确认退出
                    DialogResult rs = XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.CloseApp) + "?", "", MessageBoxButtons.OKCancel);
                    if (rs == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }

                    //CalibrationViewModel.VM.ExitDebugMode();
                    string log = Program.infoResource.GetLocalizedString(InfoId.CloseApp);
                    //ErrorLog.SystemLog(DateTime.Now, log, bbiUser.Caption);
                    CloseApp();
                    e.Cancel = false;
                }
                else
                {
                    try
                    {
                        this.Hide();
                        this.notify.Visible = true;
                        e.Cancel = true;
                    }
                    catch (Exception ex)
                    {
                        //       ErrorLog.Error(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                //   ErrorLog.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notify_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                IconMenu.Items[0].Text = Program.infoResource.GetLocalizedString(language.InfoId.APPExit);
                IconMenu.Show();
            }
        }
        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miExit_Click(object sender, EventArgs e)
        {

            DialogResult rs = XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.CloseApp) + "?", "", MessageBoxButtons.OKCancel);
            if (rs == DialogResult.Cancel) return;
            string log = Program.infoResource.GetLocalizedString(language.InfoId.CloseApp);
            //      ErrorLog.SystemLog(DateTime.Now, log, bbiUser.Caption);
            CloseApp();
            this.Dispose();
            Application.Exit();
        }
        #endregion
        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            return bbiUser.Caption;
        }
        /// <summary>
        /// 注销登录
        /// </summary>
        public void Logout()
        {
            bbiUser.Caption = Program.infoResource.GetLocalizedString(InfoId.Tourist);
            UserName = bbiUser.Caption;
            //修改视图权限
            //Program.permissionManager.ActivePermission = 3;
            //Program.permissionManager.ApplyPermission(this);
            //修改按钮为未选中状态
            if (activeBarItem != null && activeBarItem.ImageOptions.DisabledLargeImage != null)
            {
                activeBarItem.ImageOptions.LargeImage = activeBarItem.ImageOptions.DisabledLargeImage;
                activeBarItem.ImageOptions.Image = activeBarItem.ImageOptions.LargeImage;
            }
            //回到实时监测界面
            activeBarItem = bbiRealtimeMonitoring;
            NavBarItemLink link = new NavBarItemLink(new NavBarItem(bbiRealtimeMonitoring.Name));
            link.Item.Tag = bbiRealtimeMonitoring.Tag;
            modulesNavigator.ChangeSelectedItem(link, null);
            //200215注销按钮不可见
            bbiLogout2.Visibility = BarItemVisibility.Never;
            //200215弹窗关闭
            FormCollection collection = Application.OpenForms;
            for (int i = Application.OpenForms.Count - 1; i > -1; i--)
            {
                try
                {
                    if (Application.OpenForms[i] != this) Application.OpenForms[i].Close();
                }
                catch { }
            }
        }
        /// <summary>
        /// 加载帮助文档
        /// </summary>
        private void HelpChmLoad()
        {
            try
            {
                _helpChmPath = Application.StartupPath + "\\help.chm";
            }
            catch (Exception ex)
            {
                //         ErrorLog.Error(ex.ToString());
            }
        }
        private void CloseApp()
        {
            //      ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_CloseVedio });
        }

        private void ribbonControl_Click(object sender, EventArgs e)
        {
            RibbonControl ribbon = this.ribbonControl;
            switch (ribbon.SelectedPage.Name)
            {
                case "menuOperate": bbi_ItemClick(bbiRealtimeMonitoring, new ItemClickEventArgs(bbiRealtimeMonitoring, null)); break;

                case "menuSystem": bbi_ItemClick(bbiUserMan, new ItemClickEventArgs(bbiUserMan, null)); break;
                case "menuStation": bbi_ItemClick(bbiStationSettings, new ItemClickEventArgs(bbiStationSettings, null)); break;
                case "menuHelp": bbi_ItemClick(bbiAbout, new ItemClickEventArgs(bbiAbout, null)); break;

            }
        }

        private void bbiUser_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }

}