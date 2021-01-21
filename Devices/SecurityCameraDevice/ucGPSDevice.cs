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
using wayeal.os.exhaust;
using Newtonsoft.Json.Linq;
using Wayee.Services;
using DevExpress.XtraEditors;
using wayeal.os.exhaust.ViewModel;
using DevExpress.Mvvm;

namespace wayeal.exdevice
{
    public partial class ucGPSDevice : ucDeviceBase
    {
        string nullstring = "---";
        private MVVMContextFluentAPI<DeviceCommViewModel> fluent;

        public ucGPSDevice()
        {
            InitializeComponent();
            InitComboBox();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
            ResultDataViewModel.VM.UpdateDeviceCombx += new ComboboxEventHandler(InitComboBox);
        }
        protected override void InitializeBindings()
        {
            mvvmContext1.SetViewModel(typeof(DeviceCommViewModel), DeviceCommViewModel.VM);
            fluent = mvvmContext1.OfType<DeviceCommViewModel>();
            AddBinding(fluent.SetBinding(ceUsed, ce => ce.CheckState, x => x.GPSEntities, m => {
                if (m == null || m.Used.Value == null) return CheckState.Checked;
                return m.Used.Value.ToString() == "1" ? CheckState.Checked : CheckState.Unchecked;
            }));
            AddBinding(fluent.SetBinding(cbeCommunication, ce => ce.Text, x => x.GPSEntities, m => {
                if (m == null || m.Commuunication.Value == null) return null;
                return m.Commuunication.Value.ToString();
            }));
            AddBinding(lcLongitudeValue.Name, fluent.SetBinding(lcLongitudeValue, lc => lc.Text, x => x.DeviceGPSEntities, m => {
                if (m == null) return nullstring;
                return m.TESTLNG.ToString();
            }));
            AddBinding(lcLatitudeValue.Name, fluent.SetBinding(lcLatitudeValue, lc => lc.Text, x => x.DeviceGPSEntities, m => {
                if (m == null) return nullstring;
                return m.TESTLAT.ToString();
            }));
            Messenger.Default.Register<RealtimeMonitorViewModel.GPSInfoModel>(this, UpdateAirQualityInfo);

            DeviceCommViewModel.VM.ModelChanged += (sender, arg) =>
            {
                if (arg.ModelName == typeof(DeviceCommViewModel).Name) action();
            };
            RefreshUI();
            base.InitializeBindings();
        }
        private void UpdateAirQualityInfo(RealtimeMonitorViewModel.GPSInfoModel gps)
        {
            DeviceCommViewModel.VM.DeviceGPSEntities = gps;
            string json = lcLatitudeValue.Name + "," + lcLongitudeValue.Name ;
            action(json);
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
                DeviceCommViewModel.DeviceName.GPS
            });
            InitComboBox();
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            SimpleButton[] buttons = { sbRefresh, sbSave };
            ButtonEnable(false, buttons);
            //获取旧的参数，保存失败则回溯
            DTDeviceInfo dt = DeviceCommViewModel.VM.GPSEntities;

            bool rs = SaveDeviceComChanges(
             DeviceCommViewModel.DeviceName.GPS,
             cbeCommunication.Text,
             ceUsed.Checked ? "1" : "0");

            if (!rs) { BackDeviceComChanges(dt); }
            ButtonEnable(true, buttons);
            RefreshUI();
            if (!rs) return;

            DeviceNotifyEventArgs args = new DeviceNotifyEventArgs();
            args.Key = "GPSDevice";
            args.Param = rs;
            onDeviceNotify(args);
            //if (rs) XtraMessageBox.Show("保存成功");
            //else XtraMessageBox.Show("保存失败");
        }
    }
}
