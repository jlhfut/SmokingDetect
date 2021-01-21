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
using wayeal.os.exhaust.ViewModel;
using DevExpress.Mvvm;
using DevExpress.XtraEditors;

namespace wayeal.exdevice
{
    public partial class ucMeteorographDevice : ucDeviceBase
    {
        string p = ",";
        string nullstring = "---";
        private MVVMContextFluentAPI<DeviceCommViewModel> fluent;

        public ucMeteorographDevice()
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
            AddBinding(fluent.SetBinding(cbeCommunication, ce => ce.Text, x => x.MeteorographEntities, m => {
                if (m == null || m.Commuunication.Value == null) return null;
                return m.Commuunication.Value.ToString();
            }));
            AddBinding(lcTempValue.Name, fluent.SetBinding(lcTempValue, lc => lc.Text, x => x.DeviceEnvironEntities, m => {
                if (m == null) return nullstring;
                return m.Temperature.ToString("f2");
            }));
            AddBinding(lcHumidValue.Name,fluent.SetBinding(lcHumidValue, lc => lc.Text, x => x.DeviceEnvironEntities, m => {
                if (m == null ) return nullstring;
                return m.Humidity.ToString("f2");
            }));
            AddBinding(lcWindDirectValue.Name,fluent.SetBinding(lcWindDirectValue, lc => lc.Text, x => x.DeviceEnvironEntities, m => {
                if (m == null ) return nullstring;
                return m.WindDirection.ToString("f2");
            }));
            AddBinding(lcWindSpeedValue.Name,fluent.SetBinding(lcWindSpeedValue, lc => lc.Text, x => x.DeviceEnvironEntities, m => {
                if (m == null ) return nullstring;
                return m.WindSpeed.ToString("f2");
            }));
            AddBinding(lcPressureValue.Name,fluent.SetBinding(lcPressureValue, lc => lc.Text, x => x.DeviceEnvironEntities, m => {
                if (m == null ) return nullstring;
                return m.Pressure.ToString("f2");
            }));

            Messenger.Default.Register<RealtimeMonitorViewModel.EnvironmentInfoModel>(this, UpdateEnvironmentInfo);
            DeviceCommViewModel.VM.ModelChanged += (sender, arg) =>
            {
                if (arg.ModelName == typeof(DeviceCommViewModel).Name) action();
            };
            RefreshUI();
            base.InitializeBindings();
        }
        private void UpdateEnvironmentInfo(RealtimeMonitorViewModel.EnvironmentInfoModel model)
        {
            DeviceCommViewModel.VM.DeviceEnvironEntities = model;
            string json = lcTempValue.Name + p + lcHumidValue.Name + p + lcWindDirectValue.Name + p + lcWindSpeedValue.Name + p + lcPressureValue.Name;
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
        /// <summary>
        /// 刷新界面
        /// </summary>
        private void RefreshUI()
        {
            DeviceCommViewModel.VM.Execute(new List<Object> {
                DeviceCommViewModel.ExecuteCommand.ec_QueryDeviceInfo,
                DeviceCommViewModel.DeviceName.Meteorograph
            });
            DeviceCommViewModel.VM.Execute(new List<Object> {
                DeviceCommViewModel.ExecuteCommand.ec_QueryEnvironmentInfo,
            });

            InitComboBox();
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            RefreshUI();
            ErrorLog.SystemLog(DateTime.Now, "刷新");
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            SimpleButton[] buttons = { sbRefresh, sbSave };
            ButtonEnable(false, buttons);
            //获取旧的参数，保存失败则回溯
            DTDeviceInfo dt = DeviceCommViewModel.VM.MeteorographEntities;

            bool rs = SaveDeviceComChanges(
            DeviceCommViewModel.DeviceName.Meteorograph,
            cbeCommunication.Text);
            if (!rs) { BackDeviceComChanges(dt); }
            ButtonEnable(true, buttons);
            RefreshUI();
            if (!rs) return;

            DeviceNotifyEventArgs args = new DeviceNotifyEventArgs();
            args.Key = "MeteorographDevice";
            args.Param = rs;
            onDeviceNotify(args);
            //if (rs) XtraMessageBox.Show("保存成功");
            //else XtraMessageBox.Show("保存失败");
        }
        
    }
}
