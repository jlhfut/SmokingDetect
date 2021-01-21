﻿using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using wayeal.os.exhaust.Services;
using Wayeal.Services.Business.Utils;
using Wayee.Services;

namespace wayeal.os.exhaust.ViewModel
{
    public class CalibrationViewModel : BaseViewModel
    {
        public enum ExecuteCommand {
            ec_CalculateCoefficient,
            ec_SaveCoefficient,
            ec_Calibrate,
            ec_SetUltraviolet,
            ec_SetInfrared,
            ec_RefreshCoefficient,
            ec_RefreshUltraviolet,
            ec_RefreshInfrared,
            ec_RefreshSmoke,
            ec_SetSmoke,
            ec_RefreshAccelerated,
            ec_SetAccelerated,
            ec_RefreshSystem,
            ec_SetSystem,
            ec_RefreshTimingCalibration,
            ec_SaveTimingCalibration,
            ec_NewNonlinearConcentration,
            ec_RefreshNonlinearCorrection,
            ec_SaveNonlinearCorrection,
            ec_NewPointConcentration,
            ec_RefreshPointCorrection,
            ec_SavePointCorrection,
            ec_RefreshAll
        }
        private static CalibrationViewModel _VM = new CalibrationViewModel();
        public static CalibrationViewModel VM {
            get { return _VM; }
        }
        public event ModelEventHandler ModelChanged;
        /// <summary>
        /// 标定参数
        /// </summary>
        public virtual ParamterModel CalibrationParamter { get; private set; }
        /// <summary>
        /// 标定控制
        /// </summary>
        public virtual CalibrationValueModel CalibrationValue { get; private set; }

        private int _CalibrationIntensityIndex = 0;
        /// <summary>
        /// 不透光烟度当前通道号
        /// </summary>
        public virtual int CalibrationIntensityIndex
        {
            get { return _CalibrationIntensityIndex; }
            set
            {
                if (value < 0 || value >= _CalibrationIntensity.Count) return;
                //_CalibrationIntensity[_CalibrationIntensityIndex].Clone(CalibrationIntensity);
                _CalibrationIntensityIndex = value;
                Utils.Copy(CalibrationIntensity, _CalibrationIntensity[value]);
            }
        }
        private List<CalibrationIntensityModel> _CalibrationIntensity = null;
        /// <summary>
        /// 不透光烟度校准
        /// </summary>
        public virtual CalibrationIntensityModel CalibrationIntensity { get; private set; }
        /// <summary>
        /// 光谱数据
        /// </summary>
        public virtual SpectrumDataModel SpectrumData { get; private set; }
        /// <summary>
        /// 吸光度/谐波数据
        /// </summary>
        public virtual AbsortHarmonicModel AbsortHarmonicData { get; private set; }
        /// <summary>
        /// 组份历史数据
        /// </summary>
        public virtual ComponentModel Component { get; private set; }
        /// <summary>
        /// 调试数据
        /// </summary>
        public virtual DebugModel Debug { get; private set; }

        /// <summary>
        /// 紫外板参数
        /// </summary>
        public virtual UltravioletModel Ultraviolet { get; private set; }
        /// <summary>
        /// 红外板参数
        /// </summary>
        public virtual InfraredModel Infrared { get; private set; }
        /// <summary>
        /// 烟度参数
        /// </summary>
        public virtual SmokeModel Smoke { get; private set; }
        /// <summary>
        /// 加速度参数
        /// </summary>
        public virtual AccelerationModel Acceleration { get; private set; }
        /// <summary>
        /// 加速度参数(实时刷新)
        /// </summary>
        public virtual AccelerationActiveModel AccelerationActive { get; private set; }
        /// <summary>
        /// 系统/扩展参数设置
        /// </summary>
        public virtual SystemParamModel SystemParam { get; private set; }
        /// <summary>
        /// 调试模式下谱图数据
        /// </summary>
        public virtual DebugDataModel DebugData { get; private set; }
        /// <summary>
        /// 定时标定
        /// </summary>
        public virtual TimingCalibrationModel TimingCalibration { get; private set; }
        /// <summary>
        /// 非线性修正
        /// </summary>
        public virtual NonlinearCorrectionModel NonlinearCorrection { get; private set; }
        /// <summary>
        /// 点修正
        /// </summary>
        public virtual PointCorrectionModel PointCorrection { get; private set; }
        /// <summary>
        /// 分析仪名称
        /// </summary>
        private static string _analysisName = "";
        public static string AnalysisName { get { return _analysisName; }set { _analysisName = value; } }

        private delegate void ExecuteDelegate(object args);
        private SortedDictionary<string, bool> _ParamReaded = new SortedDictionary<string, bool>();
        private object _Lock = new object();
        
        /// <summary>
        /// 绑定到视图中的函数表
        /// </summary>
        private SortedList<string, ExecuteDelegate> _FunTable = new SortedList<string, ExecuteDelegate>();

        public CalibrationViewModel()
        {
            CalibrationParamter = new ParamterModel();
            CalibrationValue = new CalibrationValueModel();
            CalibrationIntensity = new CalibrationIntensityModel();
            _CalibrationIntensity = new List<CalibrationIntensityModel>();
            for (int i = 1; i <= 10; i++)
            {
                _CalibrationIntensity.Add(new CalibrationIntensityModel());
                _CalibrationIntensity[i - 1].ChannelIndex = i;
            }

            CalibrationIntensityIndex = 0;
            SpectrumData = new SpectrumDataModel();
            AbsortHarmonicData = new AbsortHarmonicModel();
            Ultraviolet = new UltravioletModel();
            Infrared = new InfraredModel();
            Component = new ComponentModel();
            Debug = new DebugModel();
            DebugData = new DebugDataModel();
            Smoke = new SmokeModel();
            Acceleration = new AccelerationModel();
            AccelerationActive = new AccelerationActiveModel();
            SystemParam = new SystemParamModel();
            TimingCalibration = new TimingCalibrationModel();
            NonlinearCorrection = new NonlinearCorrectionModel();
            PointCorrection = new PointCorrectionModel();
            InitCommoand();
            this.Execute();
        }
        /// <summary>
        /// 退出调试模式
        /// </summary>
        /// <param name="mode"></param>
        public bool ExitDebugMode()
        {
            try
            {
                lock (_Lock)
                {
                    if (Debug.Mode)
                    {
                        BusinessResult bs = BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.ExhaustToNormalBusiness);
                        if (bs != null) return bs.Result;
                    }
                    return true;
                }
            }
            catch
            { }
            return false;
        }
        /// <summary>
        /// 切换调试模式
        /// </summary>
        /// <param name="mode"></param>
        public bool SwitchDebugMode(bool mode,string analysisName=null)
        {
            try
            {
                lock (_Lock)
                {
                    BusinessResult bs = BusinessServiceHelper.Instanse.ExecuteBusiness(mode ? ExternalBusinessCmd.ExhaustToMaintenanceBusiness : ExternalBusinessCmd.ExhaustToNormalBusiness,null,BusinessType.Set,analysisName);
                    if (bs != null) return bs.Result;
                }
            }
            catch
            { }
            return false;
        }

        /// <summary>
        /// UI binding method
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (parameter is ArrayList && (parameter as ArrayList).Count > 0)
            {
                ArrayList list = new ArrayList();
                list.AddRange((parameter as ArrayList).GetRange(1, (parameter as ArrayList).Count - 1));
                if (_FunTable.ContainsKey((parameter as ArrayList)[0].ToString())) _FunTable[(parameter as ArrayList)[0].ToString()](list);
            }
            else if (_FunTable.ContainsKey(parameter.ToString()))
                _FunTable[parameter.ToString()](null);
        }

        private void InitCommoand()
        {
            _FunTable.Add(ExecuteCommand.ec_CalculateCoefficient.ToString(), (args) =>
            {
                CalibrationIntensity.CalculateCoefficient();
                if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(CalibrationViewModel.CalibrationIntensityModel).Name));
            });
            _FunTable.Add(ExecuteCommand.ec_SaveCoefficient.ToString(), (args) =>
            {
                Utils.Copy(_CalibrationIntensity[_CalibrationIntensityIndex], CalibrationIntensity);
                doWrite(_CalibrationIntensity, ExternalBusinessCmd.SetSmokeParameter);
            });
            _FunTable.Add(ExecuteCommand.ec_SaveTimingCalibration.ToString(), (args) => { doWrite(TimingCalibration, ExternalBusinessCmd.SetTimingCalParameter); });
            _FunTable.Add(ExecuteCommand.ec_Calibrate.ToString(), Calibrate);
            _FunTable.Add(ExecuteCommand.ec_SetUltraviolet.ToString(), (args) => { doWrite(Ultraviolet, ExternalBusinessCmd.SetUVSCtrlParameter); });
            _FunTable.Add(ExecuteCommand.ec_SetInfrared.ToString(), (args) => { doWrite(Infrared, ExternalBusinessCmd.SetTDLASCtrlParameter); });
            _FunTable.Add(ExecuteCommand.ec_SetSmoke.ToString(), (args) => { doWrite(Smoke, ExternalBusinessCmd.SetSmokeHandwareParameter); });
            _FunTable.Add(ExecuteCommand.ec_SetAccelerated.ToString(), (args) => { doWrite(Acceleration, ExternalBusinessCmd.SetAcceleratedParameter); });
            _FunTable.Add(ExecuteCommand.ec_SetSystem.ToString(), (args) => { doWrite(SystemParam, ExternalBusinessCmd.SetSystemParameter); });
            _FunTable.Add(ExecuteCommand.ec_NewNonlinearConcentration.ToString(), (args) => {
                if (args != null && args is ArrayList && (args as ArrayList)[0] is NonlinearCorrectionModel.CorrectConcentration)
                    NonlinearCorrection.AddConcentration((args as ArrayList)[0] as NonlinearCorrectionModel.CorrectConcentration);
            });
            _FunTable.Add(ExecuteCommand.ec_NewPointConcentration.ToString(), (args) =>
            {
                if (args != null && args is ArrayList && (args as ArrayList)[0] is PointCorrectionModel.CorrectConcentration)
                    PointCorrection.AddConcentration((args as ArrayList)[0] as PointCorrectionModel.CorrectConcentration);
            });
            _FunTable.Add(ExecuteCommand.ec_SaveNonlinearCorrection.ToString(), (args) => { doWrite(NonlinearCorrection, ExternalBusinessCmd.SetNoLinearCalParameter); });
            _FunTable.Add(ExecuteCommand.ec_SavePointCorrection.ToString(), (args) => { doWrite(PointCorrection, ExternalBusinessCmd.SePointCalParameter); });


            _ParamReaded.Add(typeof(CalibrationIntensityModel).Name, false);
            _ParamReaded.Add(typeof(InfraredModel).Name, false);
            _ParamReaded.Add(typeof(UltravioletModel).Name, false);
            _ParamReaded.Add(typeof(SmokeModel).Name, false);
            _ParamReaded.Add(typeof(AccelerationModel).Name, false);
            _ParamReaded.Add(typeof(SystemParamModel).Name, false);
            _ParamReaded.Add(typeof(TimingCalibrationModel).Name, false);
            _ParamReaded.Add(typeof(NonlinearCorrectionModel).Name, false);
            _ParamReaded.Add(typeof(PointCorrectionModel).Name, false);

            _FunTable.Add(ExecuteCommand.ec_RefreshCoefficient.ToString(), (args) => { _ParamReaded[typeof(CalibrationIntensityModel).Name] = false; });
            _FunTable.Add(ExecuteCommand.ec_RefreshInfrared.ToString(), (args) => { _ParamReaded[typeof(InfraredModel).Name] = false; });
            _FunTable.Add(ExecuteCommand.ec_RefreshUltraviolet.ToString(), (args) => { _ParamReaded[typeof(UltravioletModel).Name] = false; });
            _FunTable.Add(ExecuteCommand.ec_RefreshSmoke.ToString(), (args) => { _ParamReaded[typeof(SmokeModel).Name] = false; });
            _FunTable.Add(ExecuteCommand.ec_RefreshAccelerated.ToString(), (args) => { _ParamReaded[typeof(AccelerationModel).Name] = false; });
            _FunTable.Add(ExecuteCommand.ec_RefreshSystem.ToString(), (args) => { _ParamReaded[typeof(SystemParamModel).Name] = false; });
            _FunTable.Add(ExecuteCommand.ec_RefreshTimingCalibration.ToString(), (args) => { _ParamReaded[typeof(TimingCalibrationModel).Name] = false; });
            _FunTable.Add(ExecuteCommand.ec_RefreshNonlinearCorrection.ToString(), (args) => { _ParamReaded[typeof(NonlinearCorrectionModel).Name] = false; });
            _FunTable.Add(ExecuteCommand.ec_RefreshPointCorrection.ToString(), args => { _ParamReaded[typeof(PointCorrectionModel).Name] = false; });
            _FunTable.Add(ExecuteCommand.ec_RefreshAll.ToString(), (args) => {
                _ParamReaded[typeof(CalibrationIntensityModel).Name] = false;
                _ParamReaded[typeof(InfraredModel).Name] = false;
                _ParamReaded[typeof(UltravioletModel).Name] = false;
                _ParamReaded[typeof(SmokeModel).Name] = false;
                _ParamReaded[typeof(AccelerationModel).Name] = false;
                _ParamReaded[typeof(SystemParamModel).Name] = false;
                _ParamReaded[typeof(TimingCalibrationModel).Name] = false;
                _ParamReaded[typeof(NonlinearCorrectionModel).Name] = false;
                _ParamReaded[typeof(PointCorrectionModel).Name] = false;
                AbsortHarmonicData.UltravioletReaded = false;
                AbsortHarmonicData.InfraredReaded = false;
                AbsortHarmonicData.BackgroudReaded = false;
                SpectrumData.BackgroudReaded = false;
            });
        }

        /// <summary>
        /// Calibrate
        /// </summary>
        private void Calibrate(object args)
        {
            lock (_Lock)
            {
                CalibrateParam cp = new CalibrateParam();
                cp.CORange = CalibrationValue.ActualCO;
                cp.CO2Range = CalibrationValue.ActualCO2;
                cp.HCRange = CalibrationValue.ActualHC;
                cp.NORange = CalibrationValue.ActualNO;
                cp.IsCOCalEnable = CalibrationValue.COSelected;
                cp.IsCO2CalEnable = CalibrationValue.CO2Selected;
                cp.IsNOCalEnable = CalibrationValue.NOSelected;
                cp.IsHCCalEnable = CalibrationValue.HCSelected;
                cp.IsUVCalZero = CalibrationValue.UltravioletBgSelected;
                cp.IsTDLASCalZero = CalibrationValue.InfraredBgSelected;
                cp.UVAverageCount = Ultraviolet.CalibrateAverageNumber;
                cp.TDLASAverageCount = Infrared.CalibrateAverageNumber;
                string rs = JsonNewtonsoft.ToJSON(cp);
                try
                {
                    //      ErrorLog.ParamChanged(DateTime.Now, rs, frmMain.UserName);
                }
                catch
                {
                }
                BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.CalibrateGas, rs,BusinessType.Set,AnalysisName);
            }
        }

        /// <summary>
        /// 执行设置
        /// </summary>
        protected virtual void doWrite(object dest, string businessKey)
        {
            lock (_Lock)
            {
                string rs = JsonNewtonsoft.ToJSON(dest);
                if (businessKey == ExternalBusinessCmd.SetSystemParameter)
                {
                    Write("Write   " + rs);
                }
                BusinessResult bs = BusinessServiceHelper.Instanse.ExecuteBusiness(businessKey, rs, BusinessType.Set,AnalysisName);
                MessageBoxs.ShowDelayMessageBox(Program.infoResource.GetLocalizedString((bs != null && bs.Result) ? language.InfoId.SaveCompleted : language.InfoId.SaveFail));
                if (_ParamReaded.ContainsKey(dest.GetType().Name)) _ParamReaded[dest.GetType().Name] = (bs != null && bs.Result);
            }
        }

        private void WriteLog(string rs, string businessKey)
        {
            if (rs == null) return;
            try
            {
                string log = null;
                switch (businessKey)
                {
                    case ExternalBusinessCmd.SetTimingCalParameter:
                        log += Program.infoResource.GetLocalizedString(language.InfoId.SetTimingCalParameter);
                        break;
                    case ExternalBusinessCmd.SetUVSCtrlParameter:
                        log += Program.infoResource.GetLocalizedString(language.InfoId.SetUVSCtrlParameter);
                        break;
                    case ExternalBusinessCmd.SetTDLASCtrlParameter:
                        log += Program.infoResource.GetLocalizedString(language.InfoId.SetTDLASCtrlParameter);
                        break;
                    case ExternalBusinessCmd.SetSmokeHandwareParameter:
                        log += Program.infoResource.GetLocalizedString(language.InfoId.SetSmokeHandwareParameter);
                        break;
                    case ExternalBusinessCmd.SetAcceleratedParameter:
                        log += Program.infoResource.GetLocalizedString(language.InfoId.SetAcceleratedParameter);
                        break;
                    case ExternalBusinessCmd.SetSystemParameter:
                        log += Program.infoResource.GetLocalizedString(language.InfoId.SetSystemParameter);
                        break;
                    case ExternalBusinessCmd.SetNoLinearCalParameter:
                        log += Program.infoResource.GetLocalizedString(language.InfoId.SetNoLinearCalParameter);
                        break;
                }
                //写参数更改日志
                ErrorLog.ParamChanged(DateTime.Now, log, frmMain.UserName);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 执行读取
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="businessKey"></param>
        protected virtual bool doRead(object dest, string businessKey)
        {
            if (!_ParamReaded.ContainsKey(dest.GetType().Name) || !_ParamReaded[dest.GetType().Name])
            {
                BusinessResult bs = BusinessServiceHelper.Instanse.ExecuteBusiness(businessKey,"",BusinessType.Get,AnalysisName);

                if (businessKey == ExternalBusinessCmd.ReadAcceleratedParameter)
                {
                      Messenger.Default.Send(Acceleration);
          //          Write("Read   " +dest.ToString()+"  "+ bs.ResultInfo);
                }

                if (bs != null)
                {
                    if (_ParamReaded.ContainsKey(dest.GetType().Name)) _ParamReaded[dest.GetType().Name] = true;
                    object ri = JsonNewtonsoft.FromJSON(bs.ResultInfo);
                    FillProperties(dest, ri, dest.GetType().GetProperties());
                    return true;
                }
            }
            return false;
        }
        TextWriter tw = null;
        private void Write(string s)
        {
            if (tw == null)
                tw = new StreamWriter("d:\\accelerate.txt", true);
            tw.WriteLine(DateTime.Now.ToString("HH:mm:ss") + s);
            tw.Flush();
        }
        /// <summary>
        /// 内部工作线程
        /// </summary>
        protected void Execute()
        {
            Random r = new Random();
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sender, e) => { });
                bw.DoWork += (sender, e) => {
                    while (true)
                    {
                        try
                        {
                            lock (_Lock)
                            {
                                HandShake();
                                if (!Debug.Mode)
                                {
                                    Thread.Sleep(1000);
                                    continue;
                                }
                                GetParams();
                                GetTelemetryData();
                                GetDebugData();
                                GetSpectrumData();
                                GetOpSmokeIntensityData();
                                if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(CalibrationViewModel).Name));

                                Thread.Sleep(500);
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.Error(ex.StackTrace.ToString());
                        }
                    }
                };
                bw.RunWorkerAsync();
            }
        }
        /// <summary>
        /// 执行握手---以前的握手
        /// </summary>
        private void HandShakeOrigin()
        {
            try
            {
                
                //Debug.Mode = true;
                //CalibrationValue.ActualCO = 3;
                ////List<double> d = new List<double>();
                ////for (int i = 0; i < 512; i++) d.Add(i);
                ////AbsortHarmonicData.InfraredSpectrum = d.ToArray();
                //return;
                BusinessResult bs = BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.GetHandShakeData,"",BusinessType.Get,AnalysisName);
                if (bs != null)
                {
                    object ri = JsonNewtonsoft.FromJSON(bs.ResultInfo);
                    if (ri != null && ri is JObject && (ri as JObject).HasValues)
                    {
                        //DebugData.HandShakeData = ri.ToString();
                        //JObject handshake = ((ri as JObject).GetValue("HandShakeData") as JObject);
                        //if (handshake == null) return;
                        //JObject x = handshake.GetValue("DeviceStatusFlag") as JObject;
                        //bool debug =  bool.Parse(x.GetValue("STATUS_DEBUG").ToString());


                        DebugData.HandShakeData = ri.ToString();
                        JObject handshake = ((ri as JObject).GetValue("DevHandShakeData") as JObject);
                        if (handshake == null) return;
                        JObject devHandshake = (handshake.GetValue("HandShakeData") as JObject);
                        if (devHandshake == null) return;
                        JObject x = devHandshake.GetValue("DeviceStatusFlag") as JObject;
                        bool debug = bool.Parse(x.GetValue("STATUS_DEBUG").ToString());



                        if (Debug.Mode != debug)
                        {
                            Debug.Mode = debug;
                            if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(DebugModel).Name));
                        }

                        if (Debug.Mode)
                        {
                            bool c = bool.Parse(((ri as JObject).GetValue("IsCalibrate").ToString()));
                            if (CalibrationValue.IsCalibrate != c)
                            {
                                CalibrationValue.IsCalibrate = c;
                                if (!c)
                                {
                                    AbsortHarmonicData.UltravioletReaded = false;
                                    AbsortHarmonicData.InfraredReaded = false;
                                    AbsortHarmonicData.BackgroudReaded = false;
                                    SpectrumData.BackgroudReaded = false;
                                }

                            }
                            CalibrationParamter.StandardValve1 = bool.Parse(x.GetValue("STATUS_VALVE1").ToString());
                            CalibrationParamter.StandardValve2 = bool.Parse(x.GetValue("STATUS_VALVE2").ToString());
                            CalibrationParamter.AirPump = bool.Parse(x.GetValue("STATUS_PUMP").ToString());
                            CalibrationParamter.DeuteriumLamp = bool.Parse(x.GetValue("STATUS_LAMP").ToString());

                            Ultraviolet.AverageIntensity = float.Parse(handshake.GetValue("UVLD").ToString());
                            Infrared.AverageIntensity = float.Parse(handshake.GetValue("TdLD").ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void HandShake()
        {
            try
            {

                //Debug.Mode = true;
                //CalibrationValue.ActualCO = 3;
                ////List<double> d = new List<double>();
                ////for (int i = 0; i < 512; i++) d.Add(i);
                ////AbsortHarmonicData.InfraredSpectrum = d.ToArray();
                //return;
                BusinessResult bs = BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.GetHandShakeData, "", BusinessType.Get, AnalysisName);
                if (bs != null)
                {
                    object ri = JsonNewtonsoft.FromJSON(bs.ResultInfo);
                    if (ri != null && ri is JObject && (ri as JObject).HasValues)
                    {
                        DebugData.HandShakeData = ri.ToString();
                        JObject handshake = ((ri as JObject).GetValue("DevHandShakeData") as JObject);
                        if (handshake == null) return;
                        JObject devHandshake = (handshake.GetValue("HandShakeData") as JObject);
                        if (devHandshake == null) return;
                        JObject x = devHandshake.GetValue("DeviceStatusFlag") as JObject;
                        bool debug = bool.Parse(x.GetValue("STATUS_DEBUG").ToString());
                        if (Debug.Mode != debug)
                        {
                            Debug.Mode = debug;
                            if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(DebugModel).Name));
                        }

                        if (Debug.Mode)
                        {
                            bool c = bool.Parse((handshake.GetValue("IsCalibrate").ToString()));
                            if (CalibrationValue.IsCalibrate != c)
                            {
                                CalibrationValue.IsCalibrate = c;
                                if (!c)
                                {
                                    AbsortHarmonicData.UltravioletReaded = false;
                                    AbsortHarmonicData.InfraredReaded = false;
                                    AbsortHarmonicData.BackgroudReaded = false;
                                    SpectrumData.BackgroudReaded = false;
                                }

                            }
                            CalibrationParamter.StandardValve1 = bool.Parse(x.GetValue("STATUS_VALVE1").ToString());
                            CalibrationParamter.StandardValve2 = bool.Parse(x.GetValue("STATUS_VALVE2").ToString());
                            CalibrationParamter.AirPump = bool.Parse(x.GetValue("STATUS_PUMP").ToString());
                            CalibrationParamter.DeuteriumLamp = bool.Parse(x.GetValue("STATUS_LAMP").ToString());

                            Ultraviolet.AverageIntensity = float.Parse(devHandshake.GetValue("UVLD").ToString());
                            Infrared.AverageIntensity = float.Parse(devHandshake.GetValue("TdLD").ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }


        /// <summary>
        /// 执行业务
        /// </summary>
        /// <param name="model">数据模型</param>
        /// <param name="bkey">业务关键字</param>
        private void GetDebugData()
        {
            try
            {
                BusinessResult bs = BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.GetDebugData, Debug.Type.ToString(),BusinessType.Get,AnalysisName);
                if (bs != null)
                {
                    object ri = JsonNewtonsoft.FromJSON(bs.ResultInfo);
                    switch (Debug.Type)
                    {
                        case 0:
                            if (bs.DataFloat != null) AbsortHarmonicData.UltravioletSpectrum = bs.DataFloat;
                            if (bs.TDLASData != null) AbsortHarmonicData.InfraredSpectrum = Array.ConvertAll(bs.TDLASData, new Converter<short, double>(locate => (double)locate));
                            break;
                        case 1:
                            if (bs.DataFloat != null) SpectrumData.UltravioletSpectrum = bs.DataFloat;
                            if (bs.TDLASData != null) SpectrumData.InfraredSpectrum = Array.ConvertAll(bs.TDLASData, new Converter<short, double>(locate => (double)locate));
                            break;
                        case 2:
                            if (ri != null && ri is JObject && (ri as JObject).HasValues) FillComponent(ri as JObject);
                            break;
                        case 3:
                            if (bs.TDLASData != null) DebugData.InfraredActiveOriginalHarmonic = Array.ConvertAll(bs.TDLASData, new Converter<short, double>(locate => (double)locate));
                            if (bs.Data != null) DebugData.InfraredTelemetryOriginalHarmonic = Array.ConvertAll(bs.Data, new Converter<short, double>(locate => (double)locate));
                            break;
                    }
                    FillProperties(CalibrationParamter, ri, CalibrationParamter.GetType().GetProperties());
                    FillProperties(CalibrationValue, ri, CalibrationValue.GetType().GetProperties());
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        /// <summary>
        /// 执行获取参数业务
        /// </summary>
        private void GetParams()
        {
            try
            {
                if(doRead(Ultraviolet, ExternalBusinessCmd.ReadUVSCtrlParameter))
                {
                    CalibrationValue.ActualNO = Ultraviolet.AbsorptionBand1Range;
                    CalibrationValue.ActualHC = Ultraviolet.AbsorptionBand2Range;
                }
                if (doRead(Infrared, ExternalBusinessCmd.ReadTDLASCtrlParameter))
                {
                    CalibrationValue.ActualCO = Infrared.AbsorptionBand1Range;
                    CalibrationValue.ActualCO2 = Infrared.AbsorptionBand2Range;
                }

                if (!_ParamReaded[typeof(CalibrationIntensityModel).Name])
                {
                    BusinessResult bs = BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.ReadSmokeParameter,"",BusinessType.Get,AnalysisName);
                    if (bs != null)
                    {
                        _ParamReaded[typeof(CalibrationIntensityModel).Name] = true;
                        object ri = JsonNewtonsoft.FromJSON(bs.ResultInfo);
                        if (ri is JArray)
                        {
                            for (int i = 0; i < (ri as JArray).Count; i++)
                            {
                                if (i >= _CalibrationIntensity.Count) break;
                                FillProperties(_CalibrationIntensity[i], (ri as JArray)[i], _CalibrationIntensity[i].GetType().GetProperties());
                                if (i == CalibrationIntensityIndex) FillProperties(CalibrationIntensity, (ri as JArray)[i], CalibrationIntensity.GetType().GetProperties());
                            }
                        }
                    }
                }
                
                doRead(Smoke, ExternalBusinessCmd.ReadSmokeHandwareParameter);
                doRead(Acceleration, ExternalBusinessCmd.ReadAcceleratedParameter);
                doRead(AccelerationActive, ExternalBusinessCmd.ReadAcceleratedParameter);
                doRead(SystemParam, ExternalBusinessCmd.ReadSystemParameter);
                doRead(TimingCalibration, ExternalBusinessCmd.ReadTimingCalParameter);
                doRead(NonlinearCorrection, ExternalBusinessCmd.ReadNoLinearCalParameter);
                doRead(PointCorrection, ExternalBusinessCmd.ReadPointCalParameter);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        /// <summary>
        /// 执行吸光度/谐波/背景谱图数据业务
        /// </summary>
        private void GetSpectrumData()
        {
            try
            {
                BusinessResult bs = null;
                if (Debug.Type == 0)
                {
                    if (AbsortHarmonicData.UltravioletReaded && AbsortHarmonicData.InfraredReaded && AbsortHarmonicData.BackgroudReaded) return;
                    if (!AbsortHarmonicData.UltravioletReaded)
                    {
                        bs = BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.ReadNOCORangeSpectrogram,"",BusinessType.Get,AnalysisName);
                        if (bs != null)
                        {
                            AbsortHarmonicData.UltravioletReaded = true;
                            if (bs.DataFloat != null) AbsortHarmonicData.UltravioletNO = bs.DataFloat;
                            if (bs.TDLASData != null) AbsortHarmonicData.InfraredCO = Array.ConvertAll(bs.TDLASData, new Converter<short, double>(locate => (double)locate));
                        }
                    }

                    if (!AbsortHarmonicData.InfraredReaded)
                    {
                        bs = BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.ReadHCCO2RangeSpectrogram,"",BusinessType.Get,AnalysisName);
                        if (bs != null)
                        {
                            AbsortHarmonicData.InfraredReaded = true;
                            if (bs.DataFloat != null) AbsortHarmonicData.UltravioletHC = bs.DataFloat;
                            if (bs.TDLASData != null) AbsortHarmonicData.InfraredCO2 = Array.ConvertAll(bs.TDLASData, new Converter<short, double>(locate => (double)locate));
                        }
                    }

                    if (!AbsortHarmonicData.BackgroudReaded)
                    {
                        bs = BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.ReadBackgroundSpectrogram, "", BusinessType.Get, AnalysisName);
                        if (bs != null)
                        {
                            AbsortHarmonicData.BackgroudReaded = true;
                            if (bs.Data != null) AbsortHarmonicData.InfraredBgSpectrum = Array.ConvertAll(bs.Data, new Converter<short, double>(locate => (double)locate));
                        }
                    }
                }

                if (Debug.Type == 1)
                {
                    if (SpectrumData.BackgroudReaded) return;
                    bs = BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.ReadBackgroundSpectrogram, "", BusinessType.Get, AnalysisName);
                    if (bs != null)
                    {
                        SpectrumData.BackgroudReaded = true;
                        if (bs.DataFloat != null) SpectrumData.UltravioletBgSpectrum = bs.DataFloat;
                        if (bs.TDLASData != null) SpectrumData.InfraredBgSpectrum = Array.ConvertAll(bs.TDLASData, new Converter<short, double>(locate => (double)locate));
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        /// <summary>
        /// 执行遥测数据业务
        /// </summary>
        private void GetTelemetryData()
        {
            try
            {
                BusinessResult bs = BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.ReadMeasureSpectrogram, "", BusinessType.Get, AnalysisName);
                if (bs != null)
                {
                    if (bs.DataExFloat != null) AbsortHarmonicData.UltravioletTelemetry = bs.DataExFloat;
                    if (bs.TDLASData != null) AbsortHarmonicData.InfraredTelemetry = Array.ConvertAll(bs.TDLASData, new Converter<short, double>(locate => (double)locate));
                    if (bs.DataFloat != null) SpectrumData.TelemetrySpectrum = bs.DataFloat;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        /// <summary>
        /// 执行获取10路不透光实时光强数据业务
        /// </summary>
        private void GetOpSmokeIntensityData()
        {
            try
            {
                BusinessResult bs = BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.ReadSmokeIntensity, "", BusinessType.Get, AnalysisName);
                if (bs != null)
                {
                    if(bs.DataFloat!=null && bs.DataFloat.Length==_CalibrationIntensity.Count)
                    {
                        double rs = 0;
                        for (int i = 0; i < bs.DataFloat.Length; i++)
                        {
                            _CalibrationIntensity[i].OpSmoke = (float)bs.DataFloat[i];
                            if(CalibrationIntensityIndex==i) CalibrationIntensity.OpSmoke = (float)bs.DataFloat[i];
                            if(_CalibrationIntensity[i].Calculate()>rs) rs = _CalibrationIntensity[i].Calculate();
                        }
                        CalibrationParamter.OpSmoke2 = (float)rs;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        /// <summary>
        /// 填充属性值
        /// </summary>
        /// <param name="ri">JObject对象</param>
        /// <param name="pinf">对象属性集</param>
        private void FillProperties(object model, object ri, PropertyInfo[] pinf)
        {
            JToken token = null;
            foreach (PropertyInfo pi in pinf)
            {
                try
                {
                    if ((ri as JObject).TryGetValue(pi.Name, out token) && pi.CanWrite)
                        pi.SetValue(model, token.ToObject(pi.PropertyType));
                }
                catch { }
            }
        }
        /// <summary>
        /// 填充组份列表
        /// </summary>
        /// <param name="ri"></param>
        private void FillComponent(JObject ri)
        {
            PropertyInfo[] pinf = Component.GetType().GetProperties();
            if (pinf != null)
            {
                JToken token = null;
                foreach (PropertyInfo pi in pinf)
                {
                    try
                    {
                        if ((ri as JObject).TryGetValue(pi.Name, out token))
                            Component.AddData(pi.Name, float.Parse(token.ToString()));
                    }
                    catch { }
                }
            }
        }
        #region class
        public class ParamterModel
        {
            private bool _StandardValve1 = false;
            /// <summary>
            /// 标准阀1
            /// </summary>        
            public virtual bool StandardValve1 {
                get { return _StandardValve1; }
                set
                {
                    _StandardValve1 = value;
                }
            }
            private bool _StandardValve2 = false;
            /// <summary>
            /// 标准阀2
            /// </summary>        
            public virtual bool StandardValve2
            {
                get { return _StandardValve2; }
                set
                {
                    _StandardValve2 = value;
                }
            }
            private bool _AirPump = false;
            /// <summary>
            /// 空气泵
            /// </summary>        
            public virtual bool AirPump
            {
                get { return _AirPump; }
                set
                {
                    _AirPump = value;
                }
            }
            /// <summary>
            /// 氘灯
            /// </summary>
            public virtual bool DeuteriumLamp { get; set; }
            /// <summary>
            /// 实时光强
            /// </summary>
            public virtual float RealIntensity { get; set; }
            /// <summary>
            /// 不透光烟度
            /// </summary>
            public virtual float OpSmoke { get; set; }
            /// <summary>
            /// 不透光烟度
            /// </summary>
            public virtual float OpSmoke2 { get; set; }
            /// <summary>
            /// 设置阀
            /// </summary>
            /// <param name="num">阀号1、2</param>
            /// <param name="value"></param>
            public void SetValve(int num, bool value)
            {
                if (num < 0 || num > 2) return;
                string key=(value ? ExternalBusinessCmd.ExhaustAirValve1OnBusiness : ExternalBusinessCmd.ExhaustAirValve1OffBusiness);
                BusinessServiceHelper.Instanse.ExecuteBusiness(num==1?key:
                    (value ? ExternalBusinessCmd.ExhaustAirValve2OnBusiness : ExternalBusinessCmd.ExhaustAirValve2OffBusiness), "", BusinessType.Get, AnalysisName);
            }
            /// <summary>
            /// 设置空气泵
            /// </summary>
            /// <param name="value"></param>
            public void SetAirPump(bool value)
            {
                BusinessServiceHelper.Instanse.ExecuteBusiness(value ? ExternalBusinessCmd.ExhaustAirPumpOnBusiness : ExternalBusinessCmd.ExhaustAirPumpOffBusiness, "", BusinessType.Get, AnalysisName);
            }            
            /// <summary>
            /// 设置氘灯
            /// </summary>
            /// <param name="value"></param>
            public void SetDeuteriumLamp(bool value)
            {
                BusinessServiceHelper.Instanse.ExecuteBusiness(value ? ExternalBusinessCmd.ExhaustLampOnBusiness : ExternalBusinessCmd.ExhaustLampOffBusiness, "", BusinessType.Get, AnalysisName);
            }
        }

        public class CalibrationValueModel : BaseModel
        {
            /// <summary>
            /// Original NO value
            /// </summary>       
            public virtual float OriginalNO { get; set; }
            /// <summary>
            /// NO value
            /// </summary>       
            public virtual float ActualNO { get; set; }
            /// <summary>
            /// Active NO value
            /// </summary>
            public virtual float NO { get; set; }
            /// <summary>
            /// Original CO value
            /// </summary>       
            public virtual float OriginalCO { get; set; }
            /// <summary>
            /// CO value
            /// </summary>       
            public virtual float ActualCO { get; set; }
            /// <summary>
            /// Active CO value
            /// </summary>
            public virtual float CO { get; set; }

            /// <summary>
            /// Original HC value
            /// </summary>       
            public virtual float OriginalHC { get; set; }
            /// <summary>
            /// HC value
            /// </summary>       
            public virtual float ActualHC { get; set; }
            /// <summary>
            /// Active HC value
            /// </summary>
            public virtual float HC { get; set; }

            /// <summary>
            /// Original CO2 value
            /// </summary>       
            public virtual float OriginalCO2 { get; set; }
            /// <summary>
            /// CO2 value
            /// </summary>       
            public virtual float ActualCO2 { get; set; }
            /// <summary>
            /// Active CO2 value
            /// </summary>
            public virtual float CO2 { get; set; }
            private bool _UltravioletBgSelected = false;
            /// <summary>
            /// 紫外背景光谱被选中
            /// </summary>
            public virtual bool UltravioletBgSelected
            {
                get { return _UltravioletBgSelected; }
                set {
                    _UltravioletBgSelected = value;
                    if(value)
                    {
                        NOSelected = false;
                        HCSelected = false;
                    }
                }
            }
            private bool _InfraredBgSelected = false;
            /// <summary>
            /// 红外背景光谱被选中
            /// </summary>
            public virtual bool InfraredBgSelected
            {
                get { return _InfraredBgSelected; }
                set
                {
                    _InfraredBgSelected = value;
                    if (value)
                    {
                        COSelected = false;
                        CO2Selected = false;
                    }
                }
            }
            private bool _NOSelected = false;
            /// <summary>
            /// NO光谱被选中
            /// </summary>
            public virtual bool NOSelected
            {
                get { return _NOSelected; }
                set
                {
                    _NOSelected = value;
                    if (value && UltravioletBgSelected) UltravioletBgSelected = false;
                }
            }
            private bool _HCSelected = false;
            /// <summary>
            /// HC光谱被选中
            /// </summary>
            public virtual bool HCSelected
            {
                get { return _HCSelected; }
                set
                {
                    _HCSelected = value;
                    if (value && UltravioletBgSelected) UltravioletBgSelected = false;
                }
            }
            private bool _COSelected = false;
            /// <summary>
            /// CO光谱被选中
            /// </summary>
            public virtual bool COSelected
            {
                get { return _COSelected; }
                set
                {
                    _COSelected = value;
                    if (value && InfraredBgSelected) InfraredBgSelected = false;
                }
            }
            private bool _CO2Selected = false;
            /// <summary>
            /// CO2光谱被选中
            /// </summary>
            public virtual bool CO2Selected
            {
                get { return _CO2Selected; }
                set
                {
                    _CO2Selected = value;
                    if (value && InfraredBgSelected) InfraredBgSelected = false;
                }
            }

            /// <summary>
            /// 是否校准
            /// </summary>
            public virtual bool IsCalibrate { get; set; }
        }
        /// <summary>
        /// 标定实时光强
        /// </summary>
        public class CalibrationIntensityModel : BaseModel
        {
            /// <summary>
            /// 通道号
            /// </summary>
            public virtual int ChannelIndex { get; set; }
            /// <summary>
            /// real time intensity 1 group
            /// </summary>       
            public virtual float RealtimeIntensity1 { get; set; }
            /// <summary>
            /// calibration result by real time intensity 1 group
            /// </summary>       
            public virtual float CalibrationValue1 { get; set; }

            /// <summary>
            /// real time intensity 2 group
            /// </summary>       
            public virtual float RealtimeIntensity2 { get; set; }
            /// <summary>
            /// calibration result by real time intensity 2 group
            /// </summary>       
            public virtual float CalibrationValue2 { get; set; }

            /// <summary>
            /// real time intensity 3 group
            /// </summary>       
            public virtual float RealtimeIntensity3 { get; set; }
            /// <summary>
            /// calibration result by real time intensity 3 group
            /// </summary>       
            public virtual float CalibrationValue3 { get; set; }

            /// <summary>
            /// real time intensity 4 group
            /// </summary>       
            public virtual float RealtimeIntensity4 { get; set; }
            /// <summary>
            /// calibration result by real time intensity 4 group
            /// </summary>       
            public virtual float CalibrationValue4 { get; set; }

            /// <summary>
            /// real time intensity 5 group
            /// </summary>       
            public virtual float RealtimeIntensity5 { get; set; }
            /// <summary>
            /// calibration result by real time intensity 5 group
            /// </summary>       
            public virtual float CalibrationValue5 { get; set; }

            /// <summary>
            /// A coefficient of equation
            /// </summary>       
            public virtual float CoefficientA { get; set; }
            /// <summary>
            /// B coefficient of equation
            /// </summary>       
            public virtual float CoefficientB { get; set; }
            /// <summary>
            /// C coefficient of equation
            /// </summary>       
            public virtual float CoefficientC { get; set; }
            /// <summary>
            /// K coefficient of equation
            /// </summary>       
            public virtual float CoefficientK { get; set; }

            /// <summary>
            /// 零点光强系数,每次校准时系数变成1
            /// </summary>
            public double ZeroIntensityCoef { get; set; }

            /// <summary>
            /// 被选中的标定号
            /// </summary>
            public virtual int ActiveCalibration { get; set; }
            private float _OpacityValue = 0f;
            /// <summary>
            /// 实时不透光烟度
            /// </summary>
            public virtual float OpSmoke { get { return _OpacityValue; } set { _OpacityValue = value; SetCalibrationValue(value); } }

            public CalibrationIntensityModel()
            {
                ChannelIndex = 0;
                ActiveCalibration = -1;
            }

            /// <summary>
            /// 设置当前被选中的标定值
            /// </summary>
            /// <param name="value"></param>
            private void SetCalibrationValue(float value)
            {
                switch (ActiveCalibration)
                {
                    case 1:
                        RealtimeIntensity1 = value;
                        break;
                    case 2:
                        RealtimeIntensity2 = value;
                        break;
                    case 3:
                        RealtimeIntensity3 = value;
                        break;
                    case 4:
                        RealtimeIntensity4 = value;
                        break;
                    case 5:
                        RealtimeIntensity5 = value;
                        break;
                }
            }
            /// <summary>
            /// Calculating opacity smoke coefficient
            /// </summary>
            public void CalculateCoefficient()
            {
                const int num = 5;
                int len = RealtimeIntensity4 < 0.01f && RealtimeIntensity5 < 0.01f ? 3 : 5;

                double[] arrX = new double[num] {RealtimeIntensity1,RealtimeIntensity2,RealtimeIntensity3,RealtimeIntensity4,RealtimeIntensity5 };
                double[] arrY = new double[num] { CalibrationValue1, CalibrationValue2, CalibrationValue3, CalibrationValue4, CalibrationValue5 };

                double[] rs = LeastSquaresCalculator.MultiLine(arrY,arrX,  len, len < 5 ? 2 : 3);
                if (rs != null)
                {
                    CoefficientA = rs.Length > 3 ? (float)rs[3] : 0;
                    CoefficientB = rs.Length > 2 ? (float)rs[2] : 0;
                    CoefficientC = rs.Length > 1 ? (float)rs[1] : 0;
                    CoefficientK = rs.Length > 0 ? (float)rs[0] : 0;
                }
                ZeroIntensityCoef = 1;
                //double xx = Calculate();
                //xx = 0;
            }

            public double Calculate()
            {
                //OpSmoke = 200;
                return CoefficientA * (Math.Pow(OpSmoke, 3)) + CoefficientB * (Math.Pow(OpSmoke, 2)) + CoefficientC * OpSmoke + CoefficientK;
            }
        }

        public class SpectrumBaseModel
        {
            /// <summary>
            /// 紫外实时光谱
            /// </summary>
            public virtual double[] UltravioletSpectrum { get; set; }
            /// <summary>
            /// 红外实时光谱
            /// </summary>
            public virtual double[] InfraredSpectrum { get; set; }
            /// <summary>
            /// 红外背景光谱
            /// </summary>
            public virtual double[] InfraredBgSpectrum { get; set; }
            /// <summary>
            /// 背景数据已读
            /// </summary>
            public virtual bool BackgroudReaded { get; set; }
        }


        /// <summary>
        /// 光谱数据
        /// </summary>
        public class SpectrumDataModel:SpectrumBaseModel
        {
            /// <summary>
            /// 紫外背景光谱
            /// </summary>
            public virtual double[] UltravioletBgSpectrum { get; set; }
            /// <summary>
            /// 遥测光谱
            /// </summary>
            public virtual double[] TelemetrySpectrum { get; set; }
        }

        /// <summary>
        /// 吸光度/谐波数据
        /// </summary>
        public class AbsortHarmonicModel: SpectrumBaseModel
        {
            /// <summary>
            /// 紫外数据已读
            /// </summary>
            public virtual bool UltravioletReaded { get; set; }
            /// <summary>
            /// 紫外NO
            /// </summary>
            public virtual double[] UltravioletNO { get; set; }
            /// <summary>
            /// 紫外HC
            /// </summary>
            public virtual double[] UltravioletHC { get; set; }
            /// <summary>
            /// 遥测吸光度
            /// </summary>
            public virtual double[] UltravioletTelemetry { get; set; }

            /// <summary>
            /// 红外数据已读
            /// </summary>
            public virtual bool InfraredReaded { get; set; }
            /// <summary>
            /// 红外CO
            /// </summary>
            public virtual double[] InfraredCO { get; set; }
            /// <summary>
            /// 红外CO2
            /// </summary>
            public virtual double[] InfraredCO2 { get; set; }
            /// <summary>
            /// 遥测谐波
            /// </summary>
            public virtual double[] InfraredTelemetry { get; set; }
        }

        /// <summary>
        /// 调试模式下数据
        /// </summary>
        public class DebugDataModel
        {
            /// <summary>
            /// 实时原始谐波
            /// </summary>
            public virtual double[] InfraredActiveOriginalHarmonic { get; set; }
            /// <summary>
            /// 遥测原始谐波
            /// </summary>
            public virtual double[] InfraredTelemetryOriginalHarmonic { get; set; }
            /// <summary>
            /// 握手数据
            /// </summary>
            public string HandShakeData { get; set; }
        }

        /// <summary>
        /// 红外和紫外信号控制
        /// </summary>
        [Serializable]
        public class IUBaseModel
        {
            /// <summary>
            /// 标定时范围1
            /// </summary>
            public virtual float AbsorptionBand1Range { get; set; }
            /// <summary>
            /// 标定时范围2
            /// </summary>
            public virtual float AbsorptionBand2Range { get; set; }
            /// <summary>
            /// 标定平均次数
            /// </summary>
            public virtual int CalibrateAverageNumber { get; set; }
            private int[] _AbsorptionBand1 = new int[2] { -1, -1 };
            /// <summary>
            /// 吸光度范围
            /// </summary>
            public virtual int AbsorptionBand1Start
            {
                get { return _AbsorptionBand1[0] == -1 ? 0 : _AbsorptionBand1[0]; }
                set
                {
                    _AbsorptionBand1[0] = (value <= _AbsorptionBand1[1] || _AbsorptionBand1[1] == -1 ? value : _AbsorptionBand1[1]);
                }
            }
            public virtual int AbsorptionBand1End
            {
                get { return _AbsorptionBand1[1] == -1 ? 0 : _AbsorptionBand1[1]; }
                set
                {
                    _AbsorptionBand1[1] = (value >= _AbsorptionBand1[0] || _AbsorptionBand1[0] == -1 ? value : _AbsorptionBand1[0]);
                }
            }
            private int[] _AbsorptionBand2 = new int[2] { -1, -1 };
            /// <summary>
            /// 吸光度范围
            /// </summary>
            public virtual int AbsorptionBand2Start
            {
                get { return _AbsorptionBand2[0] == -1 ? 0 : _AbsorptionBand2[0]; }
                set
                {
                    _AbsorptionBand2[0] = (value <= _AbsorptionBand2[1] || _AbsorptionBand2[1] == -1 ? value : _AbsorptionBand2[1]);
                }
            }
            public virtual int AbsorptionBand2End
            {
                get { return _AbsorptionBand2[1] == -1 ? 0 : _AbsorptionBand2[1]; }
                set
                {
                    _AbsorptionBand2[1] = (value >= _AbsorptionBand2[0] || _AbsorptionBand2[0] == -1 ? value : _AbsorptionBand2[0]);
                }
            }
            /// <summary>
            /// 平均光强
            /// </summary>
            public float AverageIntensity { get; set; }
            /// <summary>
            /// 光强满量程
            /// </summary>
            public int IntensityFullRange { get; set; }
            private int[] _IntensityAlarmRange = new int[2] { -1, -1 };
            /// <summary>
            /// 光强报警范围
            /// </summary>
            public virtual int IntensityAlarmStart
            {
                get { return _IntensityAlarmRange[0] == -1 ? 0 : _IntensityAlarmRange[0]; }
                set
                {
                    _IntensityAlarmRange[0] = (value <= _IntensityAlarmRange[1] || _IntensityAlarmRange[1] == -1 ? value : _IntensityAlarmRange[1]);
                }
            }
            public virtual int IntensityAlarmEnd
            {
                get { return _IntensityAlarmRange[1] == -1 ? 0 : _IntensityAlarmRange[1]; }
                set
                {
                    _IntensityAlarmRange[1] = (value >= _IntensityAlarmRange[0] || _IntensityAlarmRange[0] == -1 ? value : _IntensityAlarmRange[0]);
                }
            }

            /// <summary>
            /// 滤波时间常数
            /// </summary>
            public virtual int FilteringTimeConstant { get; set; }
        }
        /// <summary>
        /// 红外信号控制
        /// </summary>
        [Serializable]
        public class InfraredModel: IUBaseModel
        {
            /// <summary>
            /// 平均次数
            /// </summary>
            public virtual int AverageNumber { get; set; }
            /// <summary>
            /// 相位
            /// </summary>
            public virtual float Phase { get; set; }
            /// <summary>
            /// 增益
            /// </summary>
            public virtual int Gain { get; set; }
            /// <summary>
            /// 采样周期
            /// </summary>
            public virtual int SamplingPeriod { get; set; }
            /// <summary>
            /// 管芯温度
            /// </summary>
            public virtual float CoreTemperature { get; set; }
            /// <summary>
            /// 工作电流
            /// </summary>
            public virtual float WorkingCurrent { get; set; }
            /// <summary>
            /// 扫描电流
            /// </summary>
            public virtual float ScanningCurrent { get; set; }
            /// <summary>
            /// 正弦调制电流
            /// </summary>
            public virtual float SineCurrent { get; set; }
            /// <summary>
            /// 自动相位锁定
            /// </summary>
            public virtual bool AutoPhaseLocking { get; set; }
            /// <summary>
            /// 挡光门限
            /// </summary>
            public virtual float LightThreshold { get; set; }
            /// <summary>
            /// 触发延迟
            /// </summary>
            public virtual int TriggerDelay { get; set; }
            /// <summary>
            /// 锁相修正系数
            /// </summary>
            public double PhaseCorrectCoef { get; set; }
        }
        /// <summary>
        /// 紫外信号控制
        /// </summary>
        [Serializable]
        public class UltravioletModel: IUBaseModel
        {
            /// <summary>
            /// 主控板平均次数
            /// </summary>
            public virtual int MainBoardAverageNumber { get; set; }
            /// <summary>
            /// 光谱仪平均次数
            /// </summary>
            public virtual int SpectrometerAverageNumber { get; set; }
            /// <summary>
            /// 积分时间
            /// </summary>
            public virtual int IntegralTime { get; set; }

            private int[] _IntensityRange = new int[2] { -1, -1 };
            /// <summary>
            /// 光强范围
            /// </summary>
            public virtual int IntensityRangeStart
            {
                get { return _IntensityRange[0] == -1 ? 0 : _IntensityRange[0]; }
                set
                {
                    _IntensityRange[0] = (value <= _IntensityRange[1] || _IntensityRange[1] == -1 ? value : _IntensityRange[1]);
                }
            }
            public virtual int IntensityRangeEnd
            {
                get { return _IntensityRange[1] == -1 ? 0 : _IntensityRange[1]; }
                set
                {
                    _IntensityRange[1] = (value >= _IntensityRange[0] || _IntensityRange[0] == -1 ? value : _IntensityRange[0]);
                }
            }
        }

        /// <summary>
        /// 测量因子
        /// </summary>
        public class ComponentModel
        {
            private List<float> _COList = new List<float>();
            public virtual List<float> OriginalCO { get { return _COList; } set { _COList = value; } }
            private List<float> _CO2List = new List<float>();
            public virtual List<float> OriginalCO2 { get { return _CO2List; } set { _CO2List = value; } }
            private List<float> _HCList = new List<float>();
            public virtual List<float> OriginalHC { get { return _HCList; } set { _HCList = value; } }
            private List<float> _NOList = new List<float>();
            public virtual List<float> OriginalNO { get { return _NOList; } set { _NOList = value; } }
            private List<float> _OpSmokeList = new List<float>();
            public virtual List<float> OpSmoke { get { return _OpSmokeList; } set { _OpSmokeList = value; } }

            public void AddData(string name, float value)
            {
                List<float> list = null;
                switch (name)
                {
                    case "OriginalCO":
                        list = OriginalCO;
                        break;
                    case "OriginalCO2":
                        list = OriginalCO2;
                        break;
                    case "OriginalHC":
                        list = OriginalHC;
                        break;
                    case "OriginalNO":
                        list = OriginalNO;
                        break;
                    case "OpSmoke":
                        list = OpSmoke;
                        break;
                }
                if (list == null) return;
                AddData(list, new List<float> { value });
            }
            protected void AddData(List<float> list, List<float> value)
            {
                int max = 100;
                list.AddRange(value);
                if (list.Count > max) list.RemoveRange(0, list.Count - max);
            }
        }

        /// <summary>
        /// 调试模型
        /// </summary>
        public class DebugModel
        {
            /// <summary>
            /// 调试类型
            /// </summary>
            public virtual int Type { get; set; }

            private bool _Mode = false;
            /// <summary>
            /// 调试模式
            /// </summary>
            public virtual bool Mode { get { return _Mode; } set { _Mode = value; } }
        }
        /// <summary>
        /// 烟度模型
        /// </summary>
        public class SmokeModel
        {
            /// <summary>
            /// 挡光门限
            /// </summary>
            public virtual float LightThreshold { get; set; }
            /// <summary>
            /// 平均次数
            /// </summary>
            public virtual int AverageNumber { get; set; }
            /// <summary>
            /// 滤波时间常数
            /// </summary>
            public virtual int FilteringTimeConstant { get; set; }
        }
        /// <summary>
        /// 加速度模型
        /// </summary>
        public class AccelerationModel
        {
            /// <summary>
            /// 点1-2的距离
            /// </summary>
            public virtual float L12 { get; set; }
            /// <summary>
            /// 点1-3的距离
            /// </summary>
            public virtual float L13 { get; set; }
            /// <summary>
            /// 挡光门限
            /// </summary>
            public virtual float LightThreshold { get; set; }
            /// <summary>
            /// 使能开关
            /// </summary>
            public virtual bool Enable { get; set; }
        }
        /// <summary>
        /// 加速度模型
        /// </summary>
        public class AccelerationActiveModel
        {
            /// <summary>
            /// 点1-2的时间
            /// </summary>
            public virtual uint T12 { get; set; }
            /// <summary>
            /// 点1-3的时间
            /// </summary>
            public virtual uint T13 { get; set; }
            /// <summary>
            /// 速度
            /// </summary>
            public virtual float Speed { get; set; }
            /// <summary>
            /// 加速度
            /// </summary>
            public virtual float Acceleration { get; set; }
            /// <summary>
            /// 点1处实时光强
            /// </summary>
            public virtual float Intensity1 { get; set; }
            /// <summary>
            /// 点2处实时光强
            /// </summary>
            public virtual float Intensity2 { get; set; }
            /// <summary>
            /// 点3处实时光强
            /// </summary>
            public virtual float Intensity3 { get; set; }

            /// <summary>
            /// 使能开关
            /// </summary>
            public virtual bool Enable { get; set; }
        }
        /// <summary>
        /// 全局参数模型
        /// </summary>
        public class SystemParamModel
        {
            /// <summary>
            /// 1,TDLAS;2,加速度板;3,烟度板;其它无效
            /// </summary>
            public virtual int CaptureVehicleEvent { get; set; }
            /// <summary>
            /// 标准预热时间
            /// </summary>
            public virtual int StandardPreheatingTime { get; set; }
           
            /// <summary>
            /// 组份范围
            /// </summary>
            public List<ComponentLimit> GroupLimit { get; set; }

        }
        /// <summary>
        /// 组份限值
        /// </summary>
        public class ComponentLimit
        {
            /// <summary>
            /// 组份名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 下限
            /// </summary>
            public double LowerLimit { get; set; }

            /// <summary>
            /// 上限
            /// </summary>
            public double UpLimit { get; set; }

            /// <summary>
            /// 单位
            /// </summary>
            public string Unit { get; set; }
        }


        /// <summary>
        /// 定时标定参数模型
        /// </summary>
        public class TimingCalibrationModel
        {
            /// <summary>
            /// 自动标定零点
            /// </summary>
            public virtual bool AutoCalibrateZero { get; set; }
            /// <summary>
            /// 自动标定量程
            /// </summary>
            public virtual bool AutoCalibrateRange { get; set; }
            /// <summary>
            /// 自动标定零点间隔
            /// </summary>
            public virtual int AutoCalibrateZeroInterval { get; set; }
            /// <summary>
            /// 定时列表
            /// </summary>
            public virtual List<TimeItem> Times { get; set; }

            public TimingCalibrationModel()
            {
                Times = new List<TimeItem>();
                for (int i = 0; i < 24; i++) Times.Add(new TimeItem(i));
                AutoCalibrateZeroInterval = 0;
            }

            /// <summary>
            /// Time Item
            /// </summary>
            public class TimeItem
            {
                public TimeItem(int idx)
                {
                    Text = idx.ToString("00") + ":00";
                    Index = idx;
                    CheckState = CheckState.Unchecked;
                }
                public string Text { get; set; }
                public int Index { get; set; }
                public CheckState CheckState { get; set; }
            }
        }

        /// <summary>
        /// 非线性修正模型
        /// </summary>
        public class NonlinearCorrectionModel
        {

            /// <summary>
            /// 气体名
            /// </summary>
            [JsonIgnore]
            public virtual string GasName { get; set; }

            [JsonIgnore]
            private string[] _GasNameList = new string[] {"NO","HC" };
            /// <summary>
            /// 气体名称列表
            /// </summary>
            [JsonIgnore]
            public string[] GasNameList { get { return _GasNameList; } }
            /// <summary>
            /// NO修正
            /// </summary>
            public virtual bool NOCorrection { get; set; }
            /// <summary>
            /// HC修正
            /// </summary>
            public virtual bool HCCorrection { get; set; }
            /// <summary>
            /// NO浓度列表
            /// </summary>
            public virtual List<CorrectConcentration> NOConcentration { get; set; }
            /// <summary>
            /// HC浓度列表
            /// </summary>
            public virtual List<CorrectConcentration> HCConcentration { get; set; }
            /// <summary>
            /// 浓度列表
            /// </summary>
            [JsonIgnore]
            public virtual List<CorrectConcentration> Concentration
            {
                get
                {
                    return GasName.Equals(_GasNameList[0]) ? NOConcentration : HCConcentration;
                }
                set
                {                    
                    if (GasName.Equals(_GasNameList[0])) NOConcentration = value; else HCConcentration = value;
                }
            }
            /// <summary>
            /// 增加浓度
            /// </summary>
            /// <param name="cc"></param>
            public void AddConcentration(CorrectConcentration cc)
            {
                if (GasName == "") return;
                Concentration.Add(cc);
            }

            /// <summary>
            /// 修正
            /// </summary>
            [JsonIgnore]
            public virtual bool Correction {
                get
                {
                    return GasName.Equals(_GasNameList[0]) ? NOCorrection : HCCorrection;
                }
                set
                {
                    if (GasName.Equals(_GasNameList[0])) NOCorrection = value; else HCCorrection = value;
                }
            }

            public NonlinearCorrectionModel()
            {
                GasName = _GasNameList[0];
                NOConcentration = new List<CorrectConcentration>();
                HCConcentration = new List<CorrectConcentration>();
            }

            /// <summary>
            /// 修正浓度
            /// </summary>            
            public class CorrectConcentration
            {
                private float _PreConcentration = 0f;
                /// <summary>
                /// 修正前浓度
                /// </summary>
                public virtual float PreConcentration
                {
                    get { return _PreConcentration; }
                    set
                    {
                        if (value < 0 || value > 1000000) return;
                        _PreConcentration = value;
                    }
                }
                private float _PostConcentration = 0f;
                /// <summary>
                /// 修正后浓度
                /// </summary>
                public virtual float PostConcentration
                {
                    get { return _PostConcentration; }
                    set
                    {
                        if (value < 0 || value > 1000000) return;
                        _PostConcentration = value;
                    }
                }
            }

        }

        #region uiPointModel
        /// <summary>
        /// 点修正模型
        /// </summary>
        //public class PointCorrectionModel
        //{

        //    /// <summary>
        //    /// 气体名
        //    /// </summary>
        //    [JsonIgnore]
        //    public virtual string GasName { get; set; }

        //    [JsonIgnore]
        //    private string[] _GasNameList = new string[] { "NO", "HC","CO","CO2" };
        //    /// <summary>
        //    /// 气体名称列表
        //    /// </summary>
        //    [JsonIgnore]
        //    public string[] GasNameList { get { return _GasNameList; } }
        //    /// <summary>
        //    /// NO修正
        //    /// </summary>
        //    public virtual bool NOCorrection { get; set; }
        //    /// <summary>
        //    /// HC修正
        //    /// </summary>
        //    public virtual bool HCCorrection { get; set; }
        //    /// <summary>
        //    /// CO修正
        //    /// </summary>
        //    public virtual bool COCorrection { get; set; }
        //    /// <summary>
        //    /// CO2修正
        //    /// </summary>
        //    public virtual bool CO2Correction { get; set; }
        //    /// <summary>
        //    /// NO浓度列表
        //    /// </summary>
        //    public virtual List<CorrectConcentration> NOConcentration { get; set; }
        //    /// <summary>
        //    /// HC浓度列表
        //    /// </summary>
        //    public virtual List<CorrectConcentration> HCConcentration { get; set; }
        //    /// <summary>
        //    /// CO浓度列表
        //    /// </summary>
        //    public virtual List<CorrectConcentration> COConcentration { get; set; }
        //    /// <summary>
        //    /// CO2浓度列表
        //    /// </summary>
        //    public virtual List<CorrectConcentration> CO2Concentration { get; set; }
        //    /// <summary>
        //    /// 浓度列表
        //    /// </summary>
        //    [JsonIgnore]
        //    public virtual List<CorrectConcentration> Concentration
        //    {
        //        get
        //        {
        //            switch (GasName)
        //            {
        //                case "NO":
        //                    return NOConcentration;
        //                case "CO":
        //                    return COConcentration;
        //                case "HC":
        //                    return HCConcentration;
        //                case "CO2":
        //                    return CO2Concentration;
        //                case "CO₂":
        //                    return CO2Concentration;
        //                default:
        //                    return null;
        //            }
        //        }
        //        set
        //        {
        //            switch (GasName)
        //            {
        //                case "NO":
        //                    NOConcentration = value; break;
        //                case "CO":
        //                    COConcentration = value; break;
        //                case "HC":
        //                    HCConcentration = value; break;
        //                case "CO2":
        //                    CO2Concentration = value; break;
        //                case "CO₂":
        //                    CO2Concentration = value;break;
        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //    /// <summary>
        //    /// 增加浓度
        //    /// </summary>
        //    /// <param name="cc"></param>
        //    public void AddConcentration(CorrectConcentration cc)
        //    {
        //        if (GasName == "") return;
        //        Concentration.Add(cc);
        //    }

        //    /// <summary>
        //    /// 修正
        //    /// </summary>
        //    [JsonIgnore]
        //    public virtual bool Correction
        //    {
        //        get
        //        {
        //            switch (GasName)
        //            {
        //                case "NO":
        //                    return NOCorrection;
        //                case "CO":
        //                    return COCorrection;
        //                case "HC":
        //                    return HCCorrection;
        //                case "CO2":
        //                    return CO2Correction;
        //                case "CO₂":
        //                    return CO2Correction;
        //                default:
        //                    return false;
        //            }
        //        }
        //        set
        //        {
        //            switch (GasName)
        //            {
        //                case "NO":
        //                    NOCorrection = value; break;
        //                case "CO":
        //                    COCorrection = value; break;
        //                case "HC":
        //                    HCCorrection = value; break;
        //                case "CO2":
        //                    CO2Correction = value; break;
        //                case "CO₂":
        //                    CO2Correction = value; break;
        //                default:
        //                    break;
        //            }
        //        }
        //    }

        //    public PointCorrectionModel()
        //    {
        //        GasName = _GasNameList[0];
        //        NOConcentration = new List<CorrectConcentration>();
        //        HCConcentration = new List<CorrectConcentration>() ;
        //        COConcentration = new List<CorrectConcentration>() ;
        //        CO2Concentration = new List<CorrectConcentration>();
        //    }

        //    /// <summary>
        //    /// 修正浓度
        //    /// </summary>            
        //    public class CorrectConcentration
        //    {
        //        /// <summary>
        //        /// 范围下限
        //        /// </summary>
        //        private float _RangeDown = 0f;
        //        /// <summary>
        //        /// 范围上限
        //        /// </summary>
        //        private float _RangeUp = 100000f;

        //        private float _PreConcentration = 0f;
        //        /// <summary>
        //        /// 修正前浓度
        //        /// </summary>
        //        public virtual float PreConcentration
        //        {
        //            get { return _PreConcentration; }
        //            set
        //            {
        //                if (value < _RangeDown || value > _RangeUp) return;
        //                _PreConcentration = value;
        //            }
        //        }
        //        private float _ConcentrationRange = 0f;
        //        /// <summary>
        //        /// 修正范围
        //        /// </summary>
        //        public virtual float ConcentrationRange
        //        {
        //            get { return _ConcentrationRange; }
        //            set
        //            {
        //                if (value < _RangeDown || value > _RangeUp) return;
        //                _ConcentrationRange = value;
        //            }
        //        }
        //        private float _ConcentrationCoefficient = 0f;
        //        /// <summary>
        //        /// 修正系数
        //        /// </summary>
        //        public virtual float ConcentrationCoefficient
        //        {
        //            get { return _ConcentrationCoefficient; }
        //            set
        //            {
        //                if (value < 0 || value > 1) return;
        //                _ConcentrationCoefficient = value;
        //            }
        //        }
        //        public CorrectConcentration(float down,float up)
        //        {
        //            _RangeDown = down;
        //            _RangeUp = up;
        //        }
        //    }
        //}
        #endregion
        /// <summary>
        /// 点修正模型
        /// </summary>
        public class PointCorrectionModel
        {

            /// <summary>
            /// 气体名
            /// </summary>
            [JsonIgnore]
            public virtual string GasName { get; set; }

            [JsonIgnore]
            private string[] _GasNameList = new string[] { "NO", "HC", "CO", "CO2" };
            /// <summary>
            /// 气体名称列表
            /// </summary>
            [JsonIgnore]
            public string[] GasNameList { get { return _GasNameList; } }
            /// <summary>
            /// NO修正
            /// </summary>
            public virtual bool NOCorrection { get; set; }
            /// <summary>
            /// HC修正
            /// </summary>
            public virtual bool HCCorrection { get; set; }
            /// <summary>
            /// CO修正
            /// </summary>
            public virtual bool COCorrection { get; set; }
            /// <summary>
            /// CO2修正
            /// </summary>
            public virtual bool CO2Correction { get; set; }
            /// <summary>
            /// NO浓度列表
            /// </summary>
            public virtual List<CorrectConcentration> NOConcentration { get; set; }
            /// <summary>
            /// HC浓度列表
            /// </summary>
            public virtual List<CorrectConcentration> HCConcentration { get; set; }
            /// <summary>
            /// CO浓度列表
            /// </summary>
            public virtual List<CorrectConcentration> COConcentration { get; set; }
            /// <summary>
            /// CO2浓度列表
            /// </summary>
            public virtual List<CorrectConcentration> CO2Concentration { get; set; }
            /// <summary>
            /// 浓度列表
            /// </summary>
            [JsonIgnore]
            public virtual List<CorrectConcentration> Concentration
            {
                get
                {
                    switch (GasName)
                    {
                        case "NO":
                            return NOConcentration;
                        case "CO":
                            return COConcentration;
                        case "HC":
                            return HCConcentration;
                        case "CO2":
                            return CO2Concentration;
                        case "CO₂":
                            return CO2Concentration;
                        default:
                            return null;
                    }
                }
                set
                {
                    switch (GasName)
                    {
                        case "NO":
                            NOConcentration = value; break;
                        case "CO":
                            COConcentration = value; break;
                        case "HC":
                            HCConcentration = value; break;
                        case "CO2":
                            CO2Concentration = value; break;
                        case "CO₂":
                            CO2Concentration = value; break;
                        default:
                            break;
                    }
                }
            }
            /// <summary>
            /// 增加浓度
            /// </summary>
            /// <param name="cc"></param>
            public void AddConcentration(CorrectConcentration cc)
            {
                if (GasName == "") return;
                Concentration.Add(cc);
            }

            /// <summary>
            /// 修正
            /// </summary>
            [JsonIgnore]
            public virtual bool Correction
            {
                get
                {
                    switch (GasName)
                    {
                        case "NO":
                            return NOCorrection;
                        case "CO":
                            return COCorrection;
                        case "HC":
                            return HCCorrection;
                        case "CO2":
                            return CO2Correction;
                        case "CO₂":
                            return CO2Correction;
                        default:
                            return false;
                    }
                }
                set
                {
                    switch (GasName)
                    {
                        case "NO":
                            NOCorrection = value; break;
                        case "CO":
                            COCorrection = value; break;
                        case "HC":
                            HCCorrection = value; break;
                        case "CO2":
                            CO2Correction = value; break;
                        case "CO₂":
                            CO2Correction = value; break;
                        default:
                            break;
                    }
                }
            }

            public PointCorrectionModel()
            {
                GasName = _GasNameList[0];
                NOConcentration = new List<CorrectConcentration>();
                HCConcentration = new List<CorrectConcentration>();
                COConcentration = new List<CorrectConcentration>();
                CO2Concentration = new List<CorrectConcentration>();
                NOCorrection = false;
                HCCorrection = false;
                CO2Correction = false;
                COCorrection = false;
            }

            /// <summary>
            /// 修正浓度
            /// </summary>            
            public class CorrectConcentration : IComparer<CorrectConcentration>
            {
                /// <summary>
                /// 范围下限
                /// </summary>
                private static float _RangeDown = 0f;
                /// <summary>
                /// 范围上限
                /// </summary>
                private static float _RangeUp = 100000f;

                private float _PreConcentration = 0f;
                /// <summary>
                /// 修正前浓度
                /// </summary>
                public virtual float PreConcentration
                {
                    get { return _PreConcentration; }
                    set
                    {
                        // if (value < _RangeDown || value > _RangeUp) return;
                        _PreConcentration = value;
                    }
                }
                private float _ConcentrationRange = 0f;
                /// <summary>
                /// 修正范围
                /// </summary>
                public virtual float ConcentrationRange
                {
                    get { return _ConcentrationRange; }
                    set
                    {
                        //if (value < _RangeDown || value > _RangeUp) return;
                        _ConcentrationRange = value;
                    }
                }
                private float _ConcentrationCoefficient = 0.5f;
                /// <summary>
                /// 修正系数
                /// </summary>
                public virtual float ConcentrationCoefficient
                {
                    get { return _ConcentrationCoefficient; }
                    set
                    {
                        if (value < 0 || value > 1) return;
                        _ConcentrationCoefficient = value;
                    }
                }
                public CorrectConcentration(float down, float up)
                {
                    _RangeDown = down;
                    _RangeUp = up;
                }


                public int Compare(CorrectConcentration x, CorrectConcentration y)
                {
                    if (x == null || y == null) return 0;
                    if (Math.Abs(x.PreConcentration - y.PreConcentration) < 0.0000001) return 0;
                    else if (x.PreConcentration > y.PreConcentration) return 1;
                    else return -1;
                }
            }
        }

        /// <summary>
        /// 返回调试数据类型
        /// </summary>
        public enum DebugDataType
        {
            /// <summary>
            /// 吸光度
            /// </summary>
            Absorb = 0,
            /// <summary>
            /// 浓度+实时光谱
            /// </summary>
            Intensity = 1,
            /// <summary>
            /// 遥测数据
            /// </summary>
            Exhaust = 2,
            /// <summary>
            /// 读取谐波原始数据
            /// </summary>
            Harm = 3,
            /// <summary>
            /// 只读浓度数据
            /// </summary>
            Dense
        }

        /// <summary>
        /// 设备状态
        /// </summary>
        public class DeviceState
        {
            /// <summary>
            /// 设备是否使用
            /// </summary>
            public bool IsDevUsed { get; set; }

            /// <summary>
            /// 通信状态是否正常
            /// </summary>
            public bool IsCommState { get; private set; }

            private int _CommFailCount;

            private int _MaxCommCount;

            public int CommFailCount
            {
                get
                {
                    return _CommFailCount;
                }
                set
                {
                    _CommFailCount = value;
                    if (_CommFailCount > _MaxCommCount)
                    {
                        IsCommState = false;
                    }
                    else
                    {
                        IsCommState = true;
                    }
                }
            }

            public DeviceState(int maxCommCount = 3)
            {
                IsDevUsed = false;
                IsCommState = false;
                _CommFailCount = 0;
                _MaxCommCount = maxCommCount;
            }
        }

        /// <summary>
        /// 业务握手数据，包含设备握手数据
        /// </summary>
        public class ExhaustBusinessHandShake
        {
            /// <summary>
            /// 默认只读浓度
            /// 0 浓度 1 实时光谱 2 吸光度
            /// </summary>
            private int _DebugDataType = 0;

            /// <summary>
            /// 业务握手数据状态
            /// </summary>
            public int DebugDataType
            {
                get { return _DebugDataType; }
                set { _DebugDataType = value; }
            }

            ///// <summary>
            ///// 校准状态
            ///// </summary>
            //private bool _IsCalibrate = false;

            ///// <summary>
            ///// 校准状态
            ///// </summary>
            //public bool IsCalibrate
            //{
            //    get { return _IsCalibrate; }
            //    set { _IsCalibrate = value; }
            //}

            ///// <summary>
            ///// 自动校准状态
            ///// </summary>
            //private bool _IsAutoRangeCalibrate = false;

            ///// <summary>
            ///// 自动校准状态
            ///// </summary>
            //public bool IsAutoRangeCalibrate
            //{
            //    get { return _IsAutoRangeCalibrate; }
            //    set { _IsAutoRangeCalibrate = value; }
            //}

            private bool _HandShakeCommState = true;

            /// <summary>
            /// 业务握手数据状态
            /// </summary>
            public bool HandShakeCommState
            {
                get { return _HandShakeCommState; }
                set { _HandShakeCommState = value; }
            }
            private DeviceState _LedDeviceState = new DeviceState();
            /// <summary>
            /// LED设备状态
            /// </summary>
            public DeviceState LedDeviceState
            {
                get { return _LedDeviceState; }
                set { _LedDeviceState = value; }
            }

            private DeviceState _AirDeviceState = new DeviceState();
            /// <summary>
            /// 空气设备状态
            /// </summary>
            public DeviceState AirDeviceState
            {
                get { return _AirDeviceState; }
                set { _AirDeviceState = value; }
            }

            private DeviceState _MeteorologyDeviceState = new DeviceState(5);
            /// <summary>
            /// 大气五参设备状态
            /// </summary>
            public DeviceState MeteorologyDeviceState
            {
                get { return _MeteorologyDeviceState; }
                set { _MeteorologyDeviceState = value; }
            }

            private DeviceState _GpsDeviceState = new DeviceState();

            /// <summary>
            /// GPS设备状态
            /// </summary>
            public DeviceState GpsDeviceState
            {
                get { return _GpsDeviceState; }
                set { _GpsDeviceState = value; }
            }

            private DeviceState _CaptureDeviceState = new DeviceState(12);

            /// <summary>
            /// 抓拍相机状态
            /// </summary>
            public DeviceState CaptureDeviceState
            {
                get { return _CaptureDeviceState; }
                set { _CaptureDeviceState = value; }
            }

            private string _LastErrBusinessKey = "";
            /// <summary>
            /// 最后一次执行错误业务命令
            /// </summary>
            public string LastErrBusinessKey
            {
                get { return _LastErrBusinessKey; }
                set { _LastErrBusinessKey = value; }
            }

            private string _LastErrBusinessDescription = "";
            /// <summary>
            /// 最后一次执行错误业务命令信息描述
            /// </summary>
            public string LastErrBusinessDescription
            {
                get { return _LastErrBusinessDescription; }
                set { _LastErrBusinessDescription = value; }
            }

            private ExhaustDeviceHandShake _DevHandShakeData = null;
            /// <summary>
            /// 获取设备握手数据状态
            /// </summary>
            public ExhaustDeviceHandShake DevHandShakeData
            {
                get { return _DevHandShakeData; }
                set { _DevHandShakeData = value; }
            }
        }

        public class ExhaustDeviceHandShake
        {
            /// <summary>
            /// 校准状态
            /// </summary>
            private bool _IsCalibrate = false;

            /// <summary>
            /// 校准状态
            /// </summary>
            public bool IsCalibrate
            {
                get { return _IsCalibrate; }
                set { _IsCalibrate = value; }
            }

            /// <summary>
            /// 自动校准状态
            /// </summary>
            private bool _IsAutoRangeCalibrate = false;

            /// <summary>
            /// 自动校准状态
            /// </summary>
            public bool IsAutoRangeCalibrate
            {
                get { return _IsAutoRangeCalibrate; }
                set { _IsAutoRangeCalibrate = value; }
            }

            //private ExhaustHandShakeData _HandShakeData = null;
            ///// <summary>
            ///// 获取设备握手数据状态
            ///// </summary>
            //public ExhaustHandShakeData HandShakeData
            //{
            //    get { return _HandShakeData; }
            //    set { _HandShakeData = value; }
            //}
        }
        #endregion
    }



}