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
using Newtonsoft.Json.Linq;

namespace wayeal.exdevice
{
    public partial class ucPlatDevice : ucDeviceBase
    {
        private MVVMContextFluentAPI<DeviceCommViewModel> fluent;

        public ucPlatDevice()
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
           
            AddBinding(fluent.SetBinding(cbeCommunication, ce => ce.Text, x => x.PlatEntities, m => {
                if (m == null || m.Commuunication.Value == null) return null;
                return m.Commuunication.Value.ToString();
            }));
            AddBinding(fluent.SetBinding(tePlatNumber, lc => lc.Text, x => x.PlatEntities, m => {
                if (m == null || m.Param.Value == null) return null;
                object o = JsonNewtonsoft.FromJSON(m.Param.Value.ToString());
                if(o is JObject)
                {
                    return (o as JObject)["platNum"].ToString();
                }
                return m.Param.Value.ToString();
            }));
            AddBinding(fluent.SetBinding(ceUnloadData, lc => lc.Checked, x => x.PlatEntities, m => {
                if (m == null || m.Param.Value == null) return ceUnloadData.Checked;
                object o = JsonNewtonsoft.FromJSON(m.Param.Value.ToString());
                if (o is JObject)
                {
                    return (o as JObject)["unloadInvalidData"].ToString().Trim().ToLower()=="true";
                }
                return ceUnloadData.Checked;
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
        /// 刷新界面
        /// </summary>
        private void RefreshUI()
        {
            DeviceCommViewModel.VM.Execute(new List<Object> {
                DeviceCommViewModel.ExecuteCommand.ec_QueryDeviceInfo,
                DeviceCommViewModel.DeviceName.Plat
            });
            InitComboBox();
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            SimpleButton[] buttons = { sbRefresh, sbSave };
            ButtonEnable(false, buttons);
            //获取旧的参数，保存失败则回溯
            DTDeviceInfo dt = DeviceCommViewModel.VM.PlatEntities;
            PlatParam pp = new PlatParam();
            pp.platNum = tePlatNumber.Text.ToString();
            pp.unloadInvalidData = ceUnloadData.Checked;
            string param = JsonNewtonsoft.ToJSON(pp);

            bool rs = SaveDeviceComChanges(
             DeviceCommViewModel.DeviceName.Plat,
             cbeCommunication.Text,null,param);

            if (!rs) { BackDeviceComChanges(dt); }
            ButtonEnable(true, buttons);
            RefreshUI();
            if (!rs) return;

            DeviceNotifyEventArgs args = new DeviceNotifyEventArgs();
            args.Key = "PlatDevice";
            args.Param = param;
            onDeviceNotify(args);
        }
        private class PlatParam
        {
            /// <summary>
            /// 平台编号
            /// </summary>
            public  string platNum;
            /// <summary>
            /// 是否上传无效数据
            /// </summary>
            public bool unloadInvalidData;
        }

    }
}
