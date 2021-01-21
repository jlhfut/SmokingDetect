#define VerticalDistribution
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Globalization;
using System.Threading;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using wayeal.language;

using wayeal.validate;
//using wayeal.os.exhaust.Forms;
using wayeal.plugin;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using wayeal.os.exhaust.ViewModel;
using Wayee.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System.Diagnostics;


namespace wayeal.os.exhaust
{
    static class Program
    {
        public static InfoLocalizer infoResource = LocalizationHelper.InfoLocalizer;
        public static ControlLocalizer controlResouce = LocalizationHelper.ControlLocalizer;
        public static ValidErrorTextLocalizer validResouce = LocalizationHelper.ValidErrorTextLocalizer;
        public static LanguageManager<ControlStringId> resourceManager = new LanguageManager<ControlStringId>(controlResouce);
        public static ToolTipManager<ErrorTextId> toolTipManager = new ToolTipManager<ErrorTextId>(validResouce);
        //public static uv_Permission uv_Permission = new uv_Permission();
        //public static PermissionManager<PermissionStringId> permissionManager = new PermissionManager<PermissionStringId>(uv_Permission);

        public static uv_Validity uv_Validity = new uv_Validity();
        public static ValidateManager<ValidStringId> validateManager = new ValidateManager<ValidStringId>(uv_Validity);

        public static PluginManager devicePluginManager = null;// new PluginManager(AppDomain.CurrentDomain.BaseDirectory+"\\Devices");
        public static PluginManager appPluginManger = null;

        public static frmMain frmMain = null;
        /// <summary>
        /// 系统进入空闲状态开始
        /// </summary>
        public static TimeSpan IdleStart { get; set; }
        /// <summary>
        /// 系统是否超时
        /// </summary>
        public static bool Idle
        {
            get
            {
                TimeSpan et = new TimeSpan(DateTime.Now.Ticks);
                bool rs = (et.TotalMilliseconds >(IdleStart.TotalMilliseconds +30*60*1000));
                if (rs)
                    IdleStart = new TimeSpan(DateTime.Now.Ticks);
                return rs;
            }
        }
        static void LoadCulture()
        {
            string cultureName = "zh-CN";
            // Create a new object, representing the China culture.  
            CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
            // The following line provides localization for the application's user interface.  
            Thread.CurrentThread.CurrentUICulture = culture;
            // The following line provides localization for data formats.  
            Thread.CurrentThread.CurrentCulture = culture;
            // Set this culture as the default culture for all threads in this application.  
            // Note: The following properties are supported in the .NET Framework 4.5+ 
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            LocalizationHelper.XtraLocalizer.LoadLocalizer();
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bRun = false;
            log4net.Config.XmlConfigurator.Configure();
            System.Threading.Mutex m = new System.Threading.Mutex(true, "EXHAUSTUI", out bRun);
            if (bRun)
            {
                //设置应用程序处理异常方式：ThreadException处理
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                BonusSkins.Register();

                LoadCulture();
                
                    frmMain = new frmMain();
                //    frmMain.ChangeNotifyIcon(bl == 0 ? false : true);
                //   
                //}
                Application.Run(frmMain);
            }
            m.ReleaseMutex();
        }
        
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
         //   ErrorLog.Error( "系统错误"+e.Exception.ToString());
          //  XtraMessageBox.Show(e.Exception.ToString(), "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
      //      ErrorLog.Error("系统错误2" + e.ToString());
          //  MessageBox.Show(e.ToString(), "系统错误2", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
       
    }
}
