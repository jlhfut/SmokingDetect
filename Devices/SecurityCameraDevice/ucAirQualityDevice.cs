﻿//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using wayeal.plugin;
//using DevExpress.Utils.MVVM;
//using Wayee.Services;
//using Newtonsoft.Json.Linq;
//using wayeal.os.exhaust;
//using DevExpress.XtraEditors;
//using DevExpress.Mvvm;
//using wayeal.os.exhaust.ViewModel;

//namespace wayeal.exdevice
//{
//    public partial class ucAirQualityDevice : ucDeviceBase
//    {
//        string p = ",";
//        string nullstring = "---";
//        private MVVMContextFluentAPI<DeviceCommViewModel> fluent;
//        //private ResultDataViewModel.UnitParam _upCurent = new ResultDataViewModel.UnitParam();
//        ///// <summary>
//        ///// 当前正在使用的参数(格式为带上下标)
//        ///// </summary>
//        //public ResultDataViewModel.UnitParam UPcurrent { get { return _upCurent; }set { _upCurent = value; } }
//        //public ucAirQualityDevice()
//        //{
//        //    InitializeComponent();
//        //    InitLabelTextOfsubscript();
//        //    InitComboBox();
//        //    ResultDataViewModel.VM.UpdateDeviceCombx += new ComboboxEventHandler(InitComboBox);
//        //    if (!mvvmContext1.IsDesignMode) InitializeBindings();
//        //}
//        /// <summary>
//        /// 初始化特殊下标的界面显示
//        /// </summary>
//        private void InitLabelTextOfsubscript()
//        {
//            lcSO2Device.Text = "SO₂:";
//            lcNO2Devcie.Text = "NO₂:";
//            lcO3Device.Text = "O₃:";
//        }

//        protected override void InitializeBindings()
//        {
//            mvvmContext1.SetViewModel(typeof(DeviceCommViewModel), DeviceCommViewModel.VM);
//            fluent = mvvmContext1.OfType<DeviceCommViewModel>();
//            AddBinding(fluent.SetBinding(ceUsedPm,ce=>ce.CheckState,x=>x.AirQualitEntities,m=> {
//                if (m == null || m.Used.Value == null) return CheckState.Unchecked;
//                return m.Used.Value.ToString() == "1" ? CheckState.Checked : CheckState.Unchecked;
//            }));
//            AddBinding(fluent.SetBinding(cbeCommunication, ce => ce.Text, x => x.AirQualitEntities, m => {
//                if (m == null||m.Commuunication.Value == null) return null;
//                return m.Commuunication.Value.ToString();
//            }));
//            AddBinding(lcPM25Value.Name, fluent.SetBinding(lcPM25Value, lc => lc.Text, x => x.DeviceAirEntities, m => {
//                if (m == null) return nullstring;
//                return m.PM25.ToString();
//            }));
//            AddBinding(lcPM10Value.Name, fluent.SetBinding(lcPM10Value, lc => lc.Text, x => x.DeviceAirEntities, m => {
//                if (m == null) return nullstring;
//                return m.PM10.ToString();
//            }));
//            AddBinding(lcCOValue.Name, fluent.SetBinding(lcCOValue, lc => lc.Text, x => x.DeviceAirEntities, m => {
//                if (m == null) return nullstring;
//                return m.CO.ToString();
//            }));
//            AddBinding(lcSO2Value.Name, fluent.SetBinding(lcSO2Value, lc => lc.Text, x => x.DeviceAirEntities, m => {
//                if (m == null) return nullstring;
//                return m.SO2.ToString();
//            }));
//            AddBinding(lcNO2Value.Name, fluent.SetBinding(lcNO2Value, lc => lc.Text, x => x.DeviceAirEntities, m => {
//                if (m == null) return nullstring;
//                return m.NO2.ToString();
//            }));
//            AddBinding(lcO3Value.Name, fluent.SetBinding(lcO3Value, lc => lc.Text, x => x.DeviceAirEntities, m => {
//                if (m == null) return nullstring;
//                return m.O3.ToString();
//            }));
//            AddBinding(cbePM25.Name, fluent.SetBinding(cbePM25, lc => lc.Text, x => x.AirQualitEntities, m => {
//                if (m == null || m.Param.Value == null) return nullstring;
//                object o = JsonNewtonsoft.FromJSON(m.Param.Value.ToString());
//                if (o is JObject)
//                {
//                    JObject jo = (o as JObject);
//                    string value = jo["PM25"].ToString();
//                    UPcurrent.PM25 = ChangeValue(value);
//                    return UPcurrent.PM25;
//                }
//                return nullstring;
//            }));
//            AddBinding(cbePM10.Name, fluent.SetBinding(cbePM10, lc => lc.Text, x => x.AirQualitEntities, m => {
//                if (m == null || m.Param.Value == null) return nullstring;
//                object o = JsonNewtonsoft.FromJSON(m.Param.Value.ToString());
//                if (o is JObject)
//                {
//                    JObject jo = (o as JObject);
//                    string value = jo["PM10"].ToString();
//                    UPcurrent.PM10 = ChangeValue(value);
//                    return UPcurrent.PM10;
//                }
//                return nullstring;
//            }));
//            AddBinding(cbeNO2.Name, fluent.SetBinding(cbeNO2, lc => lc.Text, x => x.AirQualitEntities, m => {
//                if (m == null || m.Param.Value == null) return nullstring;
//                object o = JsonNewtonsoft.FromJSON(m.Param.Value.ToString());
//                if (o is JObject)
//                {
//                    JObject jo = (o as JObject);
//                    string value = jo["NO2"].ToString();
//                    UPcurrent.NO2 = ChangeValue(value);
//                    return UPcurrent.NO2;
//                }
//                return nullstring;
//            }));
//            AddBinding( cbeO3.Name,fluent.SetBinding(cbeO3, lc => lc.Text, x => x.AirQualitEntities, m => {
//                if (m == null || m.Param.Value == null) return nullstring;
//                object o = JsonNewtonsoft.FromJSON(m.Param.Value.ToString());
//                if (o is JObject)
//                {
//                    JObject jo = (o as JObject);
//                    string value = jo["O3"].ToString();
//                    UPcurrent.O3 = ChangeValue(value);
//                    return UPcurrent.O3;
//                }
//                return nullstring;
//            }));
//            AddBinding(cbeSO2.Name, fluent.SetBinding(cbeSO2, lc => lc.Text, x => x.AirQualitEntities, m => {
//                if (m == null || m.Param.Value == null) return nullstring;
//                object o = JsonNewtonsoft.FromJSON(m.Param.Value.ToString());
//                if (o is JObject)
//                {
//                    JObject jo = (o as JObject);
//                    string value = jo["SO2"].ToString();
//                    UPcurrent.SO2 = ChangeValue(value);
//                    return UPcurrent.SO2;
//                }
//                return nullstring;
//            }));
//            AddBinding(cbeCO.Name, fluent.SetBinding(cbeCO, lc => lc.Text, x => x.AirQualitEntities, m => {
//                if (m == null || m.Param.Value == null) return nullstring;
//                object o = JsonNewtonsoft.FromJSON(m.Param.Value.ToString());
//                if (o is JObject)
//                {
//                    JObject jo = (o as JObject);
//                    string value = jo["CO"].ToString();
//                    UPcurrent.CO = ChangeValue(value);
//                    return UPcurrent.CO;
//                }
//                return nullstring;
//            }));
//            //Messenger.Default.Register<RealtimeMonitorViewModel.AirQualityModel>(this, UpdateAirQualityInfo);
//            DeviceCommViewModel.VM.ModelChanged += (sender, arg) =>
//            {
//                if (arg.ModelName == typeof(DeviceCommViewModel).Name) action();
//            };
//            base.InitializeBindings();
//            RefreshUI();

//        }
//        //更新空气各组分数值
//        //private void UpdateAirQualityInfo(RealtimeMonitorViewModel.AirQualityModel air)
//        //{
//        //    DeviceCommViewModel.VM.DeviceAirEntities = air;
//        //    string json = lcPM25Value.Name + p + lcPM10Value.Name + p + lcNO2Value.Name + p + lcCOValue.Name + p + lcSO2Value.Name + p + lcO3Value.Name;
//        //    action(json);
//        //}
//        private string ChangeValue(string value)
//        {
//            if (value == "ug/m3") return "ug/m³";
//            if (value == "mg/m3") return "mg/m³";
//            return value;
//        }
//        /// <summary>
//        /// 初始化下拉列表（可用作刷新）
//        /// </summary>
//        private void InitComboBox()
//        {
//            cbeCommunication.Properties.Items.Clear();
//            DeviceCommViewModel.VM.Execute(new List<Object> {
//                DeviceCommViewModel.ExecuteCommand.ec_QueryComInfo
//            });
//            if (DeviceCommViewModel.VM.ComInfoEntities == null || DeviceCommViewModel.VM.ComInfoEntities.Count == 0) return;

//            for (int i = 0; i < DeviceCommViewModel.VM.ComInfoEntities.Count; i++)
//            {
//                try
//                {
//                    cbeCommunication.Properties.Items.Add(((DTCommunicationInfo)DeviceCommViewModel.VM.ComInfoEntities[i]).Name.Value.ToString());
//                }
//                catch
//                {

//                }
//            }
//        }
//        /// <summary>
//        /// 刷新
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void sbRefresh_Click(object sender, EventArgs e)
//        {
//            RefreshUI();
//        }
//        /// <summary>
//        /// 刷新界面
//        /// </summary>
//        private void RefreshUI()
//        {
//            DeviceCommViewModel.VM.Execute(new List<Object> {
//                DeviceCommViewModel.ExecuteCommand.ec_QueryDeviceInfo,
//                DeviceCommViewModel.DeviceName.AirQuality
//            });

//            DeviceCommViewModel.VM.Execute(new List<Object> {
//                DeviceCommViewModel.ExecuteCommand.ec_QueryAirQualityInfo
//            });
//            InitComboBox();

//            sbSave.Enabled = true;
//            sbRefresh.Enabled = true;
//        }
//        /// <summary>
//        /// 保存
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void sbSave_Click(object sender, EventArgs e)
//        {
//            SimpleButton[] buttons = { sbRefresh, sbSave };
//            ButtonEnable(false, buttons);
//            //获取旧的参数，保存失败则回溯
//            DTDeviceInfo dt = DeviceCommViewModel.VM.AirQualitEntities;
//            ResultDataViewModel.UnitParam um = new ResultDataViewModel.UnitParam();
//            um.PM25 = cbePM25.Text;
//            um.PM10 = cbePM10.Text;
//            um.CO = cbeCO.Text;
//            um.SO2 = cbeSO2.Text;
//            um.NO2 = cbeNO2.Text;
//            um.O3 = cbeO3.Text;
//            string param = JsonNewtonsoft.ToJSON(um);
//            bool rs = SaveDeviceComChanges(
//                DeviceCommViewModel.DeviceName.AirQuality,
//                cbeCommunication.Text,
//                ceUsedPm.Checked ? "1" : "0",
//                param
//                );
//            if (!rs)
//            {
//                BackDeviceComChanges(dt);
//            }
//            ButtonEnable(true, buttons);
//            RefreshUI();
//            if (!rs) return;
//            //保存单位、启用事件
//            DeviceNotifyEventArgs args = new DeviceNotifyEventArgs();
//            args.Key = "AirQualityDevice";
//            args.Param = param;
//            onDeviceNotify(args);
//        }
//    }
//}
