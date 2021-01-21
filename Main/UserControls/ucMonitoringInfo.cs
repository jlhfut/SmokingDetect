using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.ViewModel;
using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using System.Reflection;
using Newtonsoft.Json.Linq;
using static wayeal.os.exhaust.ViewModel.ResultDataViewModel;
using wayeal.plugin;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucMonitoringInfo : ucBase
    {
        private MVVMContextFluentAPI<RealtimeMonitorViewModel> fluent;
        private string c_LED = "LED";
        private string c_AirQuality = "AirQuality";
        public ucMonitoringInfo()
        {
            InitializeComponent();
            //if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        protected override void OnFirstLoad()
        {
            base.OnFirstLoad();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }

        /// <summary>
        /// Init
        /// </summary>
        protected override void InitializeBindings()
        {
            try
            {



                mvvmContext1.SetViewModel(typeof(RealtimeMonitorViewModel), RealtimeMonitorViewModel.VM);
                fluent = mvvmContext1.OfType<RealtimeMonitorViewModel>();
                AddBinding(fluent.SetBinding(lcSpeedValue, ce => ce.Text, x => x.Entities, m => {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        return ((m[0] as JObject)["Speed"]) == null ? "0" : (Convert.ToSingle((m[0] as JObject)["Speed"])*3.6).ToString("f2");
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); return "0"; }
                }));//转km/h
                AddBinding(fluent.SetBinding(lcVSPValue, ce => ce.Text, x => x.Entities, m => {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        return ((m[0] as JObject)["VSP"]) == null ? "0" : (Convert.ToSingle((m[0] as JObject)["VSP"])).ToString("f2");
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); return "0"; }
                }));
                AddBinding(fluent.SetBinding(lcAccelerationValue, ce => ce.Text, x => x.Entities, m => {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        return ((m[0] as JObject)["Acceleration"]) == null ? "0" : (Convert.ToSingle((m[0] as JObject)["Acceleration"])).ToString("f2");
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); return "0"; }
                }));
                
               // AddBinding(fluent.SetBinding(lcTemperatureValue, ce => ce.Text, x => x.EnvironmentInfo.Temperature, m => { return Utils.FiltrateFloat(m).ToString("f2"); }));
               // AddBinding(fluent.SetBinding(lcHumidityValue, ce => ce.Text, x => x.EnvironmentInfo.Humidity, m => { return  Utils.FiltrateFloat(m).ToString("f2"); }));
               //// AddBinding(fluent.SetBinding(lcSlopeValue, ce => ce.Text, x => x.EnvironmentInfo.Slope, m => { return Utils.FiltrateFloat(m).ToString("f2"); }));
               // AddBinding(fluent.SetBinding(lcWindDirectionValue, ce => ce.Text, x => x.EnvironmentInfo.WindDirection, m => { return Utils.FiltrateFloat(m).ToString("f2"); }));
               // AddBinding(fluent.SetBinding(lcWindSpeedValue, ce => ce.Text, x => x.EnvironmentInfo.WindSpeed, m => { return Utils.FiltrateFloat(m).ToString("f2"); }));
               // AddBinding(fluent.SetBinding(lcPressureValue, ce => ce.Text, x => x.EnvironmentInfo.Pressure, m => { return Utils.FiltrateFloat(m).ToString("f2"); }));


                AddBinding(fluent.SetBinding(lcTemperatureValue, ce => ce.Text, x => x.Entities, m => {
                    if (m == null || m.Count == 0) return "0";
                    Single fl= ((m[0] as JObject)["Temperature"]) == null ? 0: (Convert.ToSingle((m[0] as JObject)["Temperature"]));
                    return Utils.FiltrateFloat(fl).ToString("f2"); }));
                AddBinding(fluent.SetBinding(lcHumidityValue, ce => ce.Text, x => x.Entities, m => {
                    if (m == null || m.Count == 0) return "0";
                    Single fl = ((m[0] as JObject)["Humidity"]) == null ? 0 : (Convert.ToSingle((m[0] as JObject)["Humidity"]));
                    return Utils.FiltrateFloat(fl).ToString("f2"); }));
                AddBinding(fluent.SetBinding(lcWindDirectionValue, ce => ce.Text, x => x.Entities, m => {
                    if (m == null || m.Count == 0) return "0";
                    Single fl = ((m[0] as JObject)["WindDirection"]) == null ? 0 : (Convert.ToSingle((m[0] as JObject)["WindDirection"]));
                    return Utils.FiltrateFloat(fl).ToString("f2");
                }));
                AddBinding(fluent.SetBinding(lcWindSpeedValue, ce => ce.Text, x => x.Entities, m => {
                    if (m == null || m.Count == 0) return "0";
                    Single fl = ((m[0] as JObject)["WindSpeed"]) == null ? 0 : (Convert.ToSingle((m[0] as JObject)["WindSpeed"]));
                    return Utils.FiltrateFloat(fl).ToString("f2");
                }));
                AddBinding(fluent.SetBinding(lcPressureValue, ce => ce.Text, x => x.Entities, m => {
                    if (m == null || m.Count == 0) return "0";
                    Single fl = ((m[0] as JObject)["Pressure"]) == null ? 0 : (Convert.ToSingle((m[0] as JObject)["Pressure"]));
                    return Utils.FiltrateFloat(fl).ToString("f2");
                }));

                AddBinding(fluent.SetBinding(lcPM25Unit, ce => ce.Text, x => x.AirQuality.PM25, m =>
                {
                    return RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, lcPM25Unit.Name.Substring(2, lcPM25Unit.Name.Length - 6)).Replace("m3", "m³");
                }));
                AddBinding(fluent.SetBinding(lcPM10Unit, ce => ce.Text, x => x.AirQuality.PM10, m =>
                {
                    return RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, lcPM10Unit.Name.Substring(2, lcPM10Unit.Name.Length - 6)).Replace("m3", "m³");
                }));
                AddBinding(fluent.SetBinding(lcCOUnit, ce => ce.Text, x => x.AirQuality.CO, m =>
                {
                    return RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, lcCOUnit.Name.Substring(2, lcCOUnit.Name.Length - 6)).Replace("m3", "m³");
                }));
                AddBinding(fluent.SetBinding(lcSO2Unit, ce => ce.Text, x => x.AirQuality.SO2, m =>
                {
                    return RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, lcSO2Unit.Name.Substring(2, lcSO2Unit.Name.Length - 6)).Replace("m3", "m³");
                }));
                AddBinding(fluent.SetBinding(lcNO2Unit, ce => ce.Text, x => x.AirQuality.NO2, m =>
                {
                    return RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, lcNO2Unit.Name.Substring(2, lcNO2Unit.Name.Length - 6)).Replace("m3", "m³");
                }));
                AddBinding(fluent.SetBinding(lcO3Unit, ce => ce.Text, x => x.AirQuality.O3, m =>
                {
                    return RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, lcO3Unit.Name.Substring(2, lcO3Unit.Name.Length - 6)).Replace("m3", "m³");
                }));

                AddBinding(fluent.SetBinding(lcPM25Value, ce => ce.Text, x => x.AirQuality.PM25, m => { return Utils.FiltrateFloat(Utils.UnitConvert(Utils.FiltrateFloat(m), Utils.UnitTypes.ugm3, lcPM25Unit.Text, 0)).ToString("f2"); }));
                AddBinding(fluent.SetBinding(lcPM10Value, ce => ce.Text, x => x.AirQuality.PM10, m => { return Utils.FiltrateFloat(Utils.UnitConvert(Utils.FiltrateFloat(m), Utils.UnitTypes.ugm3, lcPM10Unit.Text, 0)).ToString("f2"); }));
                AddBinding(fluent.SetBinding(lcCOValue, ce => ce.Text, x => x.AirQuality.CO, m => { return Utils.FiltrateFloat(Utils.UnitConvert(Utils.FiltrateFloat(m), Utils.UnitTypes.mgm3, lcCOUnit.Text, 28)).ToString("f2"); }));
                AddBinding(fluent.SetBinding(lcSO2Value, ce => ce.Text, x => x.AirQuality.SO2, m => { return Utils.FiltrateFloat(Utils.UnitConvert(Utils.FiltrateFloat(m), Utils.UnitTypes.ugm3, lcSO2Unit.Text, 64)).ToString("f2"); }));
                AddBinding(fluent.SetBinding(lcNO2Value, ce => ce.Text, x => x.AirQuality.NO2, m => { return Utils.FiltrateFloat(Utils.UnitConvert(Utils.FiltrateFloat(m), Utils.UnitTypes.ugm3, lcNO2Unit.Text, 46)).ToString("f2"); }));
                AddBinding(fluent.SetBinding(lcO3Value, ce => ce.Text, x => x.AirQuality.O3, m => { return Utils.FiltrateFloat(Utils.UnitConvert(Utils.FiltrateFloat(m), Utils.UnitTypes.ugm3, lcO3Unit.Text, 48)).ToString("f2"); }));

                AddBinding(fluent.SetBinding(lcCarLisenceValue, ce => ce.Text, x => x.Entities,m=> {
                    try
                    {
                        if (m == null || m.Count == 0) return "";
                        return ((m[0] as JObject)["CarNumber"]) == null ? "" : ((m[0] as JObject)["CarNumber"]).ToString();
                    }
                    catch(Exception ex) { ErrorLog.Error(ex.ToString());return ""; }
                }));
                AddBinding(fluent.SetBinding(lcResultValue, ce => ce.Text, x => x.Entities, m =>
                {
                    if (m == null || m.Count == 0) return "";
                    int i= (int)(m[0] as JObject)["Result"];
                    string rs = Program.infoResource.GetLocalizedString(language.InfoId.Invalid);
                    lcResultValue.ForeColor = Color.Green;
                    switch (i)
                    {
                        case -1:
                            rs = "";
                            break;
                        case 0:
                            rs = Program.infoResource.GetLocalizedString(language.InfoId.Disqualified);
                            lcResultValue.ForeColor = Color.Red;
                            break;
                        case 1:
                            rs = Program.infoResource.GetLocalizedString(language.InfoId.Qualified);
                            lcResultValue.ForeColor = Color.Green;
                            break;
                    }
                    return rs;
                }));
                AddBinding(fluent.SetBinding(this, ce => ce.MonitorPanelEnabled, x => x.Devices, m =>
                {
                    if (m == null || m.Count == 0) return true;
                    return RealtimeMonitorViewModel.VM.getDeviceUsed(c_LED);
                }));
                AddBinding(fluent.SetBinding(this, ce => ce.Height, x => x.Devices, m =>
                {
                    if (m == null || m.Count == 0) return this.Height;
                    int rs = RealtimeMonitorViewModel.VM.getDeviceUsed(c_AirQuality) ? gcAirQuality.Top + gcAirQuality.Height : gcAirQuality.Top;
                    return rs;
                }));

                Messenger.Default.Register<string>(this, typeof(RealtimeMonitorViewModel).Name, action);
                Messenger.Default.Register<ucPluginBase.DeviceNotifyEventArgs>(this, (args) =>
                {
                    if (!args.Key.Contains( c_AirQuality)) return;

                    RealtimeMonitorViewModel.VM.Devices = null;
                    action();
                });
                RealtimeMonitorViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(RealtimeMonitorViewModel.MonitoringResultModel).Name)
                    {
                        if (RealtimeMonitorViewModel.VM.Entities.Count == 0) return;
                        action();
                    }
                };
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        /// <summary>
        /// 监控面板是否显示
        /// </summary>
        public bool MonitorPanelEnabled
        {
            get { return lcLEDTitle.Visible; }
            set
            {
                lcLEDTitle.Visible = value;
                lcCarLisenceValue.Visible = value;
                lcResultValue.Visible = value;
            }
        }

    }
}
