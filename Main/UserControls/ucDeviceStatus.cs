using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using wayeal.os.exhaust.ViewModel;
using DevExpress.Utils.MVVM;
using DevExpress.Mvvm;
using wayeal.plugin;
using Wayeal.Services.Business.Utils;
using wayeal.os.exhaust.Services;
using Wayee.Services;
using DevExpress.XtraSplashScreen;
using wayeal.os.exhaust.Forms;
using System.Diagnostics;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucDeviceStatus : ucBase
    {
        const string c_Device = "Device";
        public ucDeviceStatus()
        {
            InitializeComponent();
            InitBingdings();
            InitDeviceList();
        }
        private void InitBingdings()
        {
            Messenger.Default.Register<ucPluginBase.DeviceNotifyEventArgs>(this, (args) => {
                if (!args.Key.Contains("Device")) return;
                RealtimeMonitorViewModel.VM.Devices = null;
                InitDeviceList();
                SendDeivceComToSOA(args.Param);
            });
        }
        public void InitDeviceList()
        {
            try
            {
                ilbcActiveDevice.Items.Clear();
                for (int i = 0; i < ilbcDevice.Items.Count; i++)
                {
                    if (ilbcDevice.Items[i].Tag != null && RealtimeMonitorViewModel.VM.getDeviceUsed(ilbcDevice.Items[i].Tag.ToString()))
                        ilbcActiveDevice.Items.Add(ilbcDevice.Items[i]);
                    //ilbcDevice.Items[i].ImageOptions.ImageIndex = (ilbcDevice.Items[i].Tag != null && RealtimeMonitorViewModel.VM.getDeviceUsed(ilbcDevice.Items[i].Tag.ToString())) ? 1 : 0;
                }
                //额外增加垂直式的分析仪
                SetAnalysisDevice();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }

        }
        //下发设备保存命令
        public void SendDeivceComToSOA(object args)
        {
            SplashScreenManager.ShowForm(this.ParentForm, typeof(wfMain), false, true);
            try
            {
                BusinessResult bs= BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.DeviceConfigUpdate, "", BusinessType.Set);
                if (bs == null || bs.Result == false)
                {
                    ErrorLog.SystemLog(DateTime.Now, Program.infoResource.GetLocalizedString(language.InfoId.OperateFail));
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.OperateFail));
                }
                else
                {
                    ErrorLog.SystemLog(DateTime.Now, Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess));
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess));
                }
                SplashScreenManager.CloseForm();
            }
            catch
            {
                SplashScreenManager.CloseForm();
            }
        }
        [Conditional("VerticalDistribution")]
        private void SetAnalysisDevice()
        {
            bool state = true;
            for (int i = 0; i < 6; i++)
            {
                string name = "Analysis" + (i % 2 == 0 ? "L" : "R") + (i / 2 + 1);
                state &= RealtimeMonitorViewModel.VM.getDeviceUsed(name);
            }
            if(state) ilbcActiveDevice.Items.Add(ilbcDevice.Items[6]);
        }
    }
}
