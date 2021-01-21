using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.plugin;
using DevExpress.Utils.MVVM;
using Wayee.Services;
using DevExpress.XtraEditors;
using wayeal.os.exhaust.ViewModel;
using wayeal.os.exhaust;

namespace wayeal.exdevice
{
    public partial class ucNVRDevice : ucDeviceBase
    {
        string nullstring = "---";
        private MVVMContextFluentAPI<DeviceCommViewModel> fluent;

        public ucNVRDevice()
        {
            InitializeComponent();
            InitComboBox();
            webBrowser.ScriptErrorsSuppressed = true;
            Initwww();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
            ResultDataViewModel.VM.UpdateDeviceCombx += new ComboboxEventHandler(InitComboBox);

        }
        protected override void InitializeBindings()
        {
            mvvmContext1.SetViewModel(typeof(DeviceCommViewModel), DeviceCommViewModel.VM);
            fluent = mvvmContext1.OfType<DeviceCommViewModel>();
            AddBinding(fluent.SetBinding(ceUsedPm, ce => ce.CheckState, x => x.NVREntities, m => {
                if (m == null || m.Used.Value == null) return CheckState.Checked;
                return m.Used.Value.ToString() == "1" ? CheckState.Checked : CheckState.Unchecked;
            }));
            AddBinding(fluent.SetBinding(cbeCommunication, ce => ce.Text, x => x.NVREntities, m => {
                if (m == null || m.Commuunication.Value == null) return null;
                return m.Commuunication.Value.ToString();
            }));
            DeviceCommViewModel.VM.ModelChanged += (sender, arg) =>
            {
                if (arg.ModelName == typeof(DeviceCommViewModel).Name) action();
            };
            RefreshUI();
            base.InitializeBindings();
        }
        /// <summary>
        /// 初始化下拉列表（可用作刷新）
        /// </summary>
        private void InitComboBox()
        {
            cbeCommunication.Properties.Items.Clear();
            DeviceCommViewModel.VM.Execute(new List<Object> {
                DeviceCommViewModel.ExecuteCommand.ec_QueryComInfo
            });
            if (DeviceCommViewModel.VM.ComInfoEntities == null || DeviceCommViewModel.VM.ComInfoEntities.Count == 0) return;

            for (int i = 0; i < DeviceCommViewModel.VM.ComInfoEntities.Count; i++)
            {
                try
                {
                    cbeCommunication.Properties.Items.Add(((DTCommunicationInfo)DeviceCommViewModel.VM.ComInfoEntities[i]).Name.Value.ToString());
                }
                catch
                {

                }
            }
        }
        /// <summary>
        /// 初始化网址
        /// </summary>
        private void Initwww()
        {
            try
            {
                //查找ip和port；
                DeviceCommViewModel.VM.Execute(new List<object>
                {
                DeviceCommViewModel.ExecuteCommand.ec_QueryComInfo,
                cbeCommunication.Text.Trim(),
                });
                if (DeviceCommViewModel.VM.ComInfoEntities == null || DeviceCommViewModel.VM.ComInfoEntities.Count == 0) return;
                DTCommunicationInfo dt = (DTCommunicationInfo)DeviceCommViewModel.VM.ComInfoEntities[0];
                if (dt != null && dt.IP != null && dt.PortNumberTCP != null && dt.IP.Value != null && dt.PortNumberTCP.Value != null)
                {
                    Uri uri = new Uri("http://" + dt.IP.Value.ToString().Trim() + ":" + dt.PortNumberTCP.Value.ToString().Trim());
                    webBrowser.Url = uri;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
        }
        private void sbRefresh_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }
        /// <summary>
        /// 刷新界面
        /// </summary>
        private void RefreshUI()
        {
            DeviceCommViewModel.VM.Execute(new List<Object> {
                DeviceCommViewModel.ExecuteCommand.ec_QueryDeviceInfo,
                DeviceCommViewModel.DeviceName.NVR
            });
            InitComboBox();
            Initwww();
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            SimpleButton[] buttons = { sbRefresh, sbSave };
            ButtonEnable(false, buttons);
            //获取旧的参数，保存失败则回溯
            DTDeviceInfo dt = DeviceCommViewModel.VM.NVREntities;
            bool rs = SaveDeviceComChanges(
             DeviceCommViewModel.DeviceName.NVR,
             cbeCommunication.Text,
             ceUsedPm.Checked ? "1" : "0");

            if (!rs) { BackDeviceComChanges(dt); }
            ButtonEnable(true, buttons);
            RefreshUI();
            if (!rs) return;
            DeviceNotifyEventArgs args = new DeviceNotifyEventArgs();
            args.Key = "NVRDevice";
            args.Param = rs;
            onDeviceNotify(args);
            //if (rs) XtraMessageBox.Show("保存成功");
            //else XtraMessageBox.Show("保存失败");
        }
    }
}
