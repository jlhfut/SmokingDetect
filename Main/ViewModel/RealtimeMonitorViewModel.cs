using DevExpress.Mvvm;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.Services;
using Wayeal.Services.Business.Utils;
using Wayee.Services;

namespace wayeal.os.exhaust.ViewModel
{
    public class RealtimeMonitorViewModel:BaseViewModel
    {
        private bool m_StatisticBusy = false;

        private static RealtimeMonitorViewModel _VM = new RealtimeMonitorViewModel();
        public static RealtimeMonitorViewModel VM
        {
            get { return _VM; }
        }
        public event ModelEventHandler ModelChanged;

        private ComponentModel _Component = new ComponentModel();
        /// <summary>
        /// 测量组份模型
        /// </summary>
        public ComponentModel Component { get{ return _Component; }  set { _Component = value; } }

        private VehicleConditionInfoModel _VehicleConditionInfo = new VehicleConditionInfoModel();
        /// <summary>
        /// 车道信息模型
        /// </summary>
        public VehicleConditionInfoModel VehicleConditionInfo { get { return _VehicleConditionInfo; } private set { _VehicleConditionInfo = value; } }

        private EnvironmentInfoModel _EnvironmentInfo = new EnvironmentInfoModel();
        /// <summary>
        /// 环境信息模型
        /// </summary>
        public EnvironmentInfoModel EnvironmentInfo { get { return _EnvironmentInfo; } private set { _EnvironmentInfo = value; } }

        private AirQualityModel _AirQuality = new AirQualityModel();
        /// <summary>
        /// 空气质量模型
        /// </summary>
        public AirQualityModel AirQuality { get { return _AirQuality; } private set { _AirQuality = value; } }

        private MonitoringResultModel _MonitoringResult = new MonitoringResultModel();
        /// <summary>
        /// 实时车辆监测结果
        /// </summary>
        public MonitoringResultModel MonitoringResult { get { return _MonitoringResult; }set { _MonitoringResult = value; } }

        public int _stnType = -1;

        private GPSInfoModel _GPSResult = new GPSInfoModel();
        /// <summary>
        /// 实时GPS监测结果
        /// </summary>
        public GPSInfoModel GPSResult {
            get {
                if (_stnType == -1)
                {
                    ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryOtherParam });
                    if (ResultDataViewModel.VM.OtherParamEntities == null || ResultDataViewModel.VM.OtherParamEntities.Count == 0) { _stnType = 0; return _GPSResult; }
                    _stnType =((DTOtherParamInfo)ResultDataViewModel.VM.OtherParamEntities[0]).StationType.Value==null?0:Convert.ToInt32(((DTOtherParamInfo)ResultDataViewModel.VM.OtherParamEntities[0]).StationType.Value.ToString());
                }
                if (_stnType == 0)
                {
                    if (ResultDataViewModel.VM.OtherParamEntities == null || ResultDataViewModel.VM.OtherParamEntities.Count == 0)
                        return _GPSResult;
                    if (ResultDataViewModel.VM.OtherParamEntities[0] is DTOtherParamInfo)
                    {
                        DTOtherParamInfo dt = ResultDataViewModel.VM.OtherParamEntities[0] as DTOtherParamInfo;
                        _GPSResult.StationName = dt.Name.Value == null ? "" : dt.Name.Value.ToString();
                        _GPSResult.TESTLAT = dt.Latitude.Value == null ? 0 : Convert.ToDouble(dt.Latitude.Value.ToString());
                        _GPSResult.TESTLNG = dt.Longitude.Value == null ? 0 : Convert.ToDouble(dt.Longitude.Value.ToString());
                        _GPSResult.Slope = dt.Slope.Value == null ? 0 : Convert.ToDouble(dt.Slope.Value.ToString());
                    }
                    return _GPSResult;
                }
                return _GPSResult;
            }
            set { _GPSResult = value; } }

        private List<object> _Entities = new List<object>();
        /// <summary>
        /// 监测结果集模型
        /// 用ObservableCollection可以直接刷新UI
        /// </summary>
        public List<object> Entities { get { return _Entities; } private set { _Entities = value; } }

        private string _nearPath = null;
        /// <summary>
        /// 近景图路径
        /// </summary>
        public string NearPath { get { return _nearPath; } set { _nearPath = value; } }

        private string _farPath = null;
        /// <summary>
        /// 远景图
        /// </summary>
        public string FarPath { get { return _farPath; } set { _farPath = value; } }


        private List<int> _DailyData = null;
        private List<object> _DailyStatistics = null;
        private DateTime currentDay;
        /// <summary>
        /// 日统计结果
        /// </summary>
        public List<object> DailyStatistics
        {
            get
            {
                if (_DailyStatistics == null)
                {
                    _DailyStatistics = CreateStatisticList();
                    currentDay = new DateTime();
                    currentDay = DateTime.Now;
                    UpdateStatisticList();
                }
         //       UpdateStatisticList();
                return _DailyStatistics;
            }
            private set { _DailyStatistics = value; }
        }
        private List<int> _ComplexData = null;
        private List<object> _ComplexStatistics = null;
        /// <summary>
        /// 复合统计结果
        /// </summary>
        public List<object> ComplexStatistics
        {
            get
            {
                if (_ComplexStatistics == null)
                {
                    _ComplexStatistics = CreateStatisticList();
                    UpdateStatisticList();
                }
            //    UpdateStatisticList();
                return _ComplexStatistics;
            }
            private set { _ComplexStatistics = value; }
        }
        
        private List<object> _Devices = null;// new List<object>();
        /// <summary>
        /// 查询设备信息列表
        /// </summary>
        public virtual List<object> Devices
        {
            get
            {
                if (_Devices == null) _Devices = DataServiceHelper.Instanse.QueryDevices();
                return _Devices;
            }
            set { _Devices = value; }
        }
        /// <summary>
        /// 通过设备名获取设备
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DTDeviceInfo GetDevice(string name)
        {
            if (Devices == null) return null;
            foreach(object d in Devices)
            {
                if(d is DTDeviceInfo)
                {
                    if ((d as DTDeviceInfo).Name.Equals(name)) return d as DTDeviceInfo;
                }
            }
            return null;
        }
        /// <summary>
        /// 获取设备是否启用
        /// </summary>
        /// <param name="name">设备名</param>
        /// <returns></returns>
        public bool getDeviceUsed(string name)
        {
            object d = RealtimeMonitorViewModel.VM.GetDevice(name);
            if (d == null) return true;
            PropertyInfo pi = d.GetType().GetProperty("Used");
            if (pi == null) return true;
            object v = pi.GetValue(d);
            return (v != null && v.ToString() == "1");
        }
        /// <summary>
        /// 获取设备指定参数值
        /// </summary>
        /// <param name="name">设备名</param>
        /// <param name="key">参数名</param>
        /// <returns></returns>
        public string getDeviceParam(string name, string key)
        {
            object d = RealtimeMonitorViewModel.VM.GetDevice(name);
            if (d == null) return "";
            PropertyInfo pi = d.GetType().GetProperty("Param");
            if (pi == null) return "";
            object v = pi.GetValue(d);
            if (v == null || v.ToString() == "") return "";
            object json = JsonNewtonsoft.FromJSON(v.ToString());
            if (json == null) return "";
            if (json is JObject && (json as JObject).HasValues)
            {
                JToken jt = (json as JObject).GetValue(key);
                if (jt != null)
                    return jt.ToString();
            }
            return "";
        }

        /// <summary>
        /// 正在加载结果数据集
        /// </summary>
        public bool IsLoading { get; set; }

        public RealtimeMonitorViewModel()
        {
            Execute();

            //MonitoringResultModel mr = new MonitoringResultModel();
            //mr.DateTime = DateTime.Now;
            //mr.CarNumber = "皖A 888888";
            //mr.CarNumberColor = "绿";
            //mr.Lane = "1";
            //mr.Confidence = "90";
            //mr.PicFarPath = "";
            //mr.PicNearPath = "";
            //ComponentModel cm = new ComponentModel();
            //cm.NO = 1;
            //cm.CO2 = 2;
            //cm.HC = 3;
            //cm.CO = 4.12345677889f;
            //cm.Blackness = 5;
            //cm.OpSmoke = 6;
            //cm.Result = 7;

            //VehicleConditionInfoModel vm = new VehicleConditionInfoModel();
            //vm.Acceleration = 8;
            //vm.Speed = 9;
            //vm.VSP = 10;
            //vm.CarType = "Y";
            //EnvironmentInfoModel em = new EnvironmentInfoModel();
            //em.Humidity = 11;
            //em.Pressure = 12;
            //em.Slope = 13;
            //em.Temperature = 14;
            //em.WindDirection = 15;
            //em.WindSpeed = 16;
            //UpdateResult(mr, cm, vm, em);
        }

        #region private
        /// <summary>
        /// 内部工作线程
        /// </summary>
        protected void Execute()
        {
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sender,e) =>{ });
                bw.DoWork += (sender,e) => {
                    while (true)
                    {
                        try
                        {
                            //if(CalibrationViewModel.VM.Debug.Mode)
                            //{
                            //    Thread.Sleep(1000);
                            //    continue;
                            //}
                            GetRealData();
                            GetAirData();
                            JObject jObject = UpdateResult();
                            if (jObject!=null)
                            {
                              //  UpdateStatisticList(-1,"",true/*int.Parse(jObject["Result"].ToString()), jObject["FUELTYPE"].ToString()*/);                                
                            }
                            Thread.Sleep(500);
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.Error(ex.StackTrace.ToString());
                            ErrorLog.Error(ex.ToString());
                        }
                    }
                };
                bw.RunWorkerAsync();
            }

            //Thread thread = new Thread(() =>
            //{
            //});
            //thread.IsBackground = true;
            //thread.Start();
        }
        TextWriter tw = null;
        private void Write(string s)
        {
            if(tw==null)
                tw= new StreamWriter("d:\\统计数据", true);
            tw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss")+s);
            tw.Flush();
        }
        /// <summary>
        /// 获取遥测车辆数据
        /// </summary>
        private void GetRealData()
        {
            BusinessResult bs = BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.GetRealData);
            if (bs != null)
            {
                object ri = JsonNewtonsoft.FromJSON(bs.ResultInfo);
                if (ri != null && ri is JObject && (ri as JObject).HasValues)
                {
                    ExecBusiness(Component, "", bs);                    
                    ExecBusiness(VehicleConditionInfo, "", bs);
             //       JudgePollution(Component, VehicleConditionInfo.CarType);
                    ExecBusiness(GPSResult, "", bs);
            //        Write(" 接收："+bs==null?"bs是空":bs.ResultInfo);
                    ExecBusiness(EnvironmentInfo, ExternalBusinessCmd.GetMeteorologyData);
                    MonitoringResultModel mr = MonitoringResult;// new MonitoringResultModel();
                    ExecBusiness(mr, "", bs);
                    //UpdateResult(mr, Component, VehicleConditionInfo,EnvironmentInfo,GPSResult);
                    Messenger.Default.Send(EnvironmentInfo);
                    Messenger.Default.Send(GPSResult);
                    if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(RealtimeMonitorViewModel).Name));
                }
            }
        }
        /// <summary>
        /// 获取环境信息数据
        /// </summary>
        private void GetAirData()
        {
            ExecBusiness(AirQuality, ExternalBusinessCmd.GetAirData);
            Messenger.Default.Send(AirQuality);
        }
        /// <summary>
        /// 执行业务
        /// </summary>
        /// <param name="model">数据模型</param>
        /// <param name="bkey">业务关键字</param>
        private void ExecBusiness(object model,string bkey=null, BusinessResult br=null)
        {
            BusinessResult bs =br==null? BusinessServiceHelper.Instanse.ExecuteBusiness(bkey):br;
            
            if (bs != null)
            {
                object ri = JsonNewtonsoft.FromJSON(bs.ResultInfo);
                
                if (ri != null && ri is JObject && (ri as JObject).HasValues)
                {
                    PropertyInfo[] pinf = model.GetType().GetProperties();
                    if (pinf != null)
                    {
                        FillProperties(model, ri, pinf);                        
                    }

                }
            }
        }

        /// <summary>
        /// 填充属性值
        /// </summary>
        /// <param name="ri">JObject对象</param>
        /// <param name="pinf">对象属性集</param>
        private void FillProperties(object model,object ri, PropertyInfo[] pinf)
        {
            JToken token = null;
            foreach (PropertyInfo pi in pinf)
            {
                try
                {
                    if ((ri as JObject).TryGetValue(pi.Name, out token) && pi.CanWrite)
                        pi.SetValue(model, token.ToObject(pi.PropertyType));
                }
                catch {}
            }
        }
        /// <summary>
        /// 通过服务获取最新一条记录
        /// </summary>
        private JObject UpdateResult()
        {
            BusinessResult bs = BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.GetBufferRecData);
            if (bs != null && bs.ResultInfo!="")
            {
            //    Write("  收到soa的缓存");
                //"{\"MN\":\"WQ1002\",\"PW\":\"123456\",\"PM10\":0.0,\"PM2P5\":0.0,\"SO2\":0.0,\"NOX\":0.0,\"CO\":0.0,\"NO\":0.0,\"NO2\":0.0,\"O3\":0.0,\"NMHC\":0.0,\"TESTNO\":\"20200422191321350\",\"TESTTYPE\":null,\"TESTMODEL\":null,\"TESTNAME\":null,\"LaneNumber\":0,\"TESTDATE\":\"2020-04-22T19:13:21.3505539+08:00\",\"TESTLNG\":152.568,\"TESTLAT\":25.569,\"RESULT\":2,\"LICENSE\":null,\"LICENSETYPE\":-1,\"FUELTYPE\":\"A\",\"COCO2\":0.0,\"HCCO2\":0.0,\"NOCO2\":0.0,\"CO2JG\":15.7032141731708,\"COJG\":0.18660391344996352,\"HCJG\":0.14505294937563495,\"NOJG\":175.61454637724961,\"BTGD\":90.457527160644531,\"LGMHD\":5.0,\"COXZ\":3.0,\"HCXZ\":6.5,\"NOXZ\":2.0,\"BTGDXZ\":30.0,\"LGMHDXZ\":1.0,\"SPEED\":0.0,\"ASPEED\":0.0,\"VSP\":0.0,\"SLOPE\":15.0,\"HUM\":0.0,\"TEMP\":0.0,\"WSPEED\":0.0,\"FX\":0.0,\"DQY\":0.0,\"TP1\":null,\"TP2\":null,\"FullPathTP1\":null,\"FullPathTP2\":null,\"SP1\":null}";
                object json = JsonNewtonsoft.FromJSON(bs.ResultInfo);
                if (json != null)
                {
                    JObject s = (JObject)json;
                    JObject m = new JObject();
                    //MonitoringResultModel
                    //m.Add("Index", 1);
              //      Write("    "+ bs.ResultInfo);
                    m.Add("TestingTime", s["TESTDATE"]);
                    m.Add("Lane", s["LaneNumber"]);
                    m.Add("CarNumber", s["LICENSE"]);
                    m.Add("CarNumberColor", s["LICENSETYPE"]);
                    m.Add("Confidence", s["Confidence"]);
                    m.Add("PicFarPath", s["FullPathTP2"]);
                    m.Add("PicNearPath", s["FullPathTP1"]);
                    //ComponentModel
                    m.Add("NO", s["NOJG"]);
                    m.Add("HC", s["HCJG"]);
                    m.Add("CO2", s["CO2JG"]);
                    m.Add("CO", s["COJG"]);
                    m.Add("Blackness", s["LGMHD"]);
                    m.Add("OpSmoke", s["BTGD"]);
                    m.Add("Result", (int)s["RESULT"]);
                    //VehicleConditionInfoModel
                    m.Add("Acceleration", s["ASPEED"]);
                    m.Add("Speed", s["SPEED"]);
                    m.Add("VSP", s["VSP"]);
                    //EnvironmentInfoModel
                    m.Add("Humidity", s["HUM"]);
                    m.Add("Pressure", s["DQY"]);
                    m.Add("Slope", s["SLOPE"]);
                    m.Add("Temperature", s["TEMP"]);
                    m.Add("WindDirection", s["FX"]);
                    m.Add("WindSpeed", s["WSPEED"]);
                    //GPSInfoModel
                    m.Add("Station", s["StationName"]);
                    m.Add("Longitude", s["TESTLNG"]);
                    m.Add("Latitude", s["TESTLAT"]);
                    m.Add("CarType", s["FUELTYPE"]);
                    m.Add("Serial", 0);
                    m.Add("VehicleType", s["VEHICLETYPE"]);

                    _farPath = s["FullPathTP2"].ToString();
                    _nearPath = s["FullPathTP1"].ToString();
                    try
                    {
                        Component.CO = Convert.ToSingle(s["COJG"]);
                        Component.CO2 = Convert.ToSingle(s["CO2JG"]);
                        Component.HC = Convert.ToSingle(s["HCJG"]);
                        Component.NO = Convert.ToSingle(s["NOJG"]);
                        Component.Blackness = Convert.ToSingle(s["LGMHD"]);
                        Component.OpSmoke = Convert.ToSingle(s["BTGD"]);
                        JudgePollution(Component, s["FUELTYPE"].ToString(), (int)s["RESULT"]);
                    }
                    catch(Exception ex)
                    {
                        ErrorLog.Error(ex.ToString());
                    }
                    int max = 20;
                    if (currentDay.Day == DateTime.Now.Day)
                    {
                        UpdateStatisticList(m);
                    }
                    else
                    {
                        UpdateStatisticList(-1,"",true);
                        currentDay = DateTime.Now;
                    }
                    Entities.Insert(0, m);
                    if (Entities.Count > max) Entities.RemoveAt(max);
                    if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(RealtimeMonitorViewModel.MonitoringResultModel).Name));
                    return (JObject)json;
                }
            }
            return null;


        }
        static object lck =new object();
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="m"></param>
        private void UpdateStatisticList(JObject m)
        {
            lock (lck)
            {
                try
                {
                    string carType = m["CarType"].ToString();
                    string result = m["Result"].ToString();

                    switch (carType + result)
                    {
                        case "B0"://汽油 超标
                            ((JObject)DailyStatistics[0])[c_Diesel] = Convert.ToInt32(((JObject)DailyStatistics[0])[c_Diesel]) + 1;//汽油车总车次+1
                            ((JObject)DailyStatistics[0])[c_Total] = Convert.ToInt32(((JObject)DailyStatistics[0])[c_Total]) + 1;//总数总车次+1
                            ((JObject)DailyStatistics[1])[c_Diesel] = Convert.ToInt32(((JObject)DailyStatistics[1])[c_Diesel]) + 1;//汽油车超标+1
                            ((JObject)DailyStatistics[1])[c_Total] = Convert.ToInt32(((JObject)DailyStatistics[1])[c_Total]) + 1;//总数超标+1

                            ((JObject)ComplexStatistics[0])[c_Diesel] = Convert.ToInt32(((JObject)ComplexStatistics[0])[c_Diesel]) + 1;//汽油车总车次+1
                            ((JObject)ComplexStatistics[0])[c_Total] = Convert.ToInt32(((JObject)ComplexStatistics[0])[c_Total]) + 1;//总数总车次+1
                            ((JObject)ComplexStatistics[1])[c_Diesel] = Convert.ToInt32(((JObject)ComplexStatistics[1])[c_Diesel]) + 1;//汽油车超标+1
                            ((JObject)ComplexStatistics[1])[c_Total] = Convert.ToInt32(((JObject)ComplexStatistics[1])[c_Total]) + 1;//总数超标+1
                            break;
                        case "A0"://柴油 超标
                            ((JObject)ComplexStatistics[0])[c_Gas] = Convert.ToInt32(((JObject)ComplexStatistics[0])[c_Gas]) + 1;//柴油车总车次+1
                            ((JObject)ComplexStatistics[0])[c_Total] = Convert.ToInt32(((JObject)ComplexStatistics[0])[c_Total]) + 1;//总数总车次+1
                            ((JObject)ComplexStatistics[1])[c_Gas] = Convert.ToInt32(((JObject)ComplexStatistics[1])[c_Gas]) + 1;//柴油车超标+1
                            ((JObject)ComplexStatistics[1])[c_Total] = Convert.ToInt32(((JObject)ComplexStatistics[1])[c_Total]) + 1;//总数超标+1

                            ((JObject)DailyStatistics[0])[c_Gas] = Convert.ToInt32(((JObject)DailyStatistics[0])[c_Gas]) + 1;//柴油车总车次+1
                            ((JObject)DailyStatistics[0])[c_Total] = Convert.ToInt32(((JObject)DailyStatistics[0])[c_Total]) + 1;//总数总车次+1
                            ((JObject)DailyStatistics[1])[c_Gas] = Convert.ToInt32(((JObject)DailyStatistics[1])[c_Gas]) + 1;//柴油车超标+1
                            ((JObject)DailyStatistics[1])[c_Total] = Convert.ToInt32(((JObject)DailyStatistics[1])[c_Total]) + 1;//总数超标+1
                            break;
                        case "B1"://汽油 合格
                            ((JObject)DailyStatistics[0])[c_Diesel] = Convert.ToInt32(((JObject)DailyStatistics[0])[c_Diesel]) + 1;//汽油车总车次+1
                            ((JObject)DailyStatistics[0])[c_Total] = Convert.ToInt32(((JObject)DailyStatistics[0])[c_Total]) + 1;//总数总车次+1
                            ((JObject)DailyStatistics[2])[c_Diesel] = Convert.ToInt32(((JObject)DailyStatistics[2])[c_Diesel]) + 1;//汽油车合格+1
                            ((JObject)DailyStatistics[2])[c_Total] = Convert.ToInt32(((JObject)DailyStatistics[2])[c_Total]) + 1;//总数合格+1

                            ((JObject)ComplexStatistics[0])[c_Diesel] = Convert.ToInt32(((JObject)ComplexStatistics[0])[c_Diesel]) + 1;//汽油车总车次+1
                            ((JObject)ComplexStatistics[0])[c_Total] = Convert.ToInt32(((JObject)ComplexStatistics[0])[c_Total]) + 1;//总数总车次+1
                            ((JObject)ComplexStatistics[2])[c_Diesel] = Convert.ToInt32(((JObject)ComplexStatistics[2])[c_Diesel]) + 1;//汽油车合格+1
                            ((JObject)ComplexStatistics[2])[c_Total] = Convert.ToInt32(((JObject)ComplexStatistics[2])[c_Total]) + 1;//总数合格+1
                            break;
                        case "A1"://柴油 合格
                            ((JObject)DailyStatistics[0])[c_Gas] = Convert.ToInt32(((JObject)DailyStatistics[0])[c_Gas]) + 1;//柴油车总车次+1
                            ((JObject)DailyStatistics[0])[c_Total] = Convert.ToInt32(((JObject)DailyStatistics[0])[c_Total]) + 1;//总数总车次+1
                            ((JObject)DailyStatistics[2])[c_Gas] = Convert.ToInt32(((JObject)DailyStatistics[2])[c_Gas]) + 1;//柴油车合格+1
                            ((JObject)DailyStatistics[2])[c_Total] = Convert.ToInt32(((JObject)DailyStatistics[2])[c_Total]) + 1;//总数合格+1

                            ((JObject)ComplexStatistics[0])[c_Gas] = Convert.ToInt32(((JObject)ComplexStatistics[0])[c_Gas]) + 1;//柴油车总车次+1
                            ((JObject)ComplexStatistics[0])[c_Total] = Convert.ToInt32(((JObject)ComplexStatistics[0])[c_Total]) + 1;//总数总车次+1
                            ((JObject)ComplexStatistics[2])[c_Gas] = Convert.ToInt32(((JObject)ComplexStatistics[2])[c_Gas]) + 1;//柴油车合格+1
                            ((JObject)ComplexStatistics[2])[c_Total] = Convert.ToInt32(((JObject)ComplexStatistics[2])[c_Total]) + 1;//总数合格+1
                            break;
                        case "B2"://汽油 无效
                            ((JObject)DailyStatistics[0])[c_Diesel] = Convert.ToInt32(((JObject)DailyStatistics[0])[c_Diesel]) + 1;//汽油车总车次+1
                            ((JObject)DailyStatistics[0])[c_Total] = Convert.ToInt32(((JObject)DailyStatistics[0])[c_Total]) + 1;//总数总车次+1
                            ((JObject)DailyStatistics[3])[c_Diesel] = Convert.ToInt32(((JObject)DailyStatistics[3])[c_Diesel]) + 1;//汽油车无效+1
                            ((JObject)DailyStatistics[3])[c_Total] = Convert.ToInt32(((JObject)DailyStatistics[3])[c_Total]) + 1;//总数无效+1

                            ((JObject)ComplexStatistics[0])[c_Diesel] = Convert.ToInt32(((JObject)ComplexStatistics[0])[c_Diesel]) + 1;//汽油车总车次+1
                            ((JObject)ComplexStatistics[0])[c_Total] = Convert.ToInt32(((JObject)ComplexStatistics[0])[c_Total]) + 1;//总数总车次+1
                            ((JObject)ComplexStatistics[3])[c_Diesel] = Convert.ToInt32(((JObject)ComplexStatistics[3])[c_Diesel]) + 1;//汽油车无效+1
                            ((JObject)ComplexStatistics[3])[c_Total] = Convert.ToInt32(((JObject)ComplexStatistics[3])[c_Total]) + 1;//总数无效+1
                            break;
                        case "A2"://柴油 无效
                            ((JObject)DailyStatistics[0])[c_Gas] = Convert.ToInt32(((JObject)DailyStatistics[0])[c_Gas]) + 1;//柴油车总车次+1
                            ((JObject)DailyStatistics[0])[c_Total] = Convert.ToInt32(((JObject)DailyStatistics[0])[c_Total]) + 1;//总数总车次+1
                            ((JObject)DailyStatistics[3])[c_Gas] = Convert.ToInt32(((JObject)DailyStatistics[3])[c_Gas]) + 1;//柴油车无效+1
                            ((JObject)DailyStatistics[3])[c_Total] = Convert.ToInt32(((JObject)DailyStatistics[3])[c_Total]) + 1;//总数无效+1

                            ((JObject)ComplexStatistics[0])[c_Gas] = Convert.ToInt32(((JObject)ComplexStatistics[0])[c_Gas]) + 1;//柴油车总车次+1
                            ((JObject)ComplexStatistics[0])[c_Total] = Convert.ToInt32(((JObject)ComplexStatistics[0])[c_Total]) + 1;//总数总车次+1
                            ((JObject)ComplexStatistics[3])[c_Gas] = Convert.ToInt32(((JObject)ComplexStatistics[3])[c_Gas]) + 1;//柴油车无效+1
                            ((JObject)ComplexStatistics[3])[c_Total] = Convert.ToInt32(((JObject)ComplexStatistics[3])[c_Total]) + 1;//总数无效+1
                            break;
                        case "Z2"://其他燃油 无效
                            ((JObject)DailyStatistics[0])[c_Total] = Convert.ToInt32(((JObject)DailyStatistics[0])[c_Total]) + 1;//柴油车总车次+1
                            ((JObject)DailyStatistics[3])[c_Total] = Convert.ToInt32(((JObject)DailyStatistics[3])[c_Total]) + 1;//总数无效+1

                            ((JObject)ComplexStatistics[0])[c_Total] = Convert.ToInt32(((JObject)ComplexStatistics[0])[c_Total]) + 1;//柴油车总车次+1
                            ((JObject)ComplexStatistics[3])[c_Total] = Convert.ToInt32(((JObject)ComplexStatistics[3])[c_Total]) + 1;//总数无效+1
                            break;
                        default:
                            MessageBox.Show(carType + result);
                            break;
                    }
                    //重新计算超标率
                    ((JObject)DailyStatistics[4])[c_Diesel] = ((JObject)DailyStatistics[0])[c_Diesel].Value<int>() <= 0 ? "0" : ((((JObject)DailyStatistics[1])[c_Diesel].Value<int>() * 1f / ((JObject)DailyStatistics[0])[c_Diesel].Value<int>()) * 100).ToString("f2") + "%";
                    ((JObject)DailyStatistics[4])[c_Gas] = ((JObject)DailyStatistics[0])[c_Gas].Value<int>() <= 0 ? "0" : ((((JObject)DailyStatistics[1])[c_Gas].Value<int>() * 1f / ((JObject)DailyStatistics[0])[c_Gas].Value<int>()) * 100).ToString("f2") + "%";
                    ((JObject)DailyStatistics[4])[c_Total] = ((JObject)DailyStatistics[0])[c_Total].Value<int>() <= 0 ? "0" : ((((JObject)DailyStatistics[1])[c_Total].Value<int>() * 1f / ((JObject)DailyStatistics[0])[c_Total].Value<int>()) * 100).ToString("f2") + "%";
                    ((JObject)ComplexStatistics[4])[c_Diesel] = ((JObject)ComplexStatistics[0])[c_Diesel].Value<int>() <= 0 ? "0" : ((((JObject)ComplexStatistics[1])[c_Diesel].Value<int>() * 1f / ((JObject)ComplexStatistics[0])[c_Diesel].Value<int>()) * 100).ToString("f2") + "%";
                    ((JObject)ComplexStatistics[4])[c_Gas] = ((JObject)ComplexStatistics[0])[c_Gas].Value<int>() <= 0 ? "0" : ((((JObject)ComplexStatistics[1])[c_Gas].Value<int>() * 1f / ((JObject)ComplexStatistics[0])[c_Gas].Value<int>()) * 100).ToString("f2") + "%";
                    ((JObject)ComplexStatistics[4])[c_Total] = ((JObject)ComplexStatistics[0])[c_Total].Value<int>() <= 0 ? "0" : ((((JObject)ComplexStatistics[1])[c_Total].Value<int>() * 1f / ((JObject)ComplexStatistics[0])[c_Total].Value<int>()) * 100).ToString("f2") + "%";

                    Write("   "+carType+result+"   "+ ((JObject)DailyStatistics[0])[c_Total].ToString());
                }
                catch (Exception ex)
                {
                    ErrorLog.Error(ex.ToString());
                }
            }
        }

        private string m_LastData = " ";
        /// <summary>
        /// 更新监测结果数据集
        /// </summary>
        private void UpdateResult(MonitoringResultModel mr, ComponentModel cm, VehicleConditionInfoModel vm, EnvironmentInfoModel em, GPSInfoModel gm)
        {
            if (mr.DateTime.ToString("yyyyMMddHHmmss") == "00010101000000") return;
            if (m_LastData == mr.StoreDateTime || mr.StoreDateTime!="") return;

            //ArrayList al = DataServiceHelper.Instanse.Query(DateTime.Now.AddDays(-24), DateTime.Now, "", "", "", 1, 20);
            //Entities.Clear();
            //if (al != null) Entities.AddRange(al.ToArray());
            //UpdateStatisticList((int)cm.Result, vm.CarType, true);            
            //if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(RealtimeMonitorViewModel.MonitoringResultModel).Name));
            //m_LastData = mr.StoreDateTime;
            //return;

            int max = 20;
            IsLoading = true;
            try
            {
                JObject m = new JObject();
                //MonitoringResultModel
                //m.Add("Index", 1);
                m.Add("TestingTime", mr.DateTime);
                m.Add("Lane", mr.Lane);
                m.Add("CarNumber", mr.CarNumber);
                m.Add("CarNumberColor", mr.CarNumberColor);
                m.Add("Confidence", mr.Confidence);
                m.Add("PicFarPath", mr.PicFarPath);
                m.Add("PicNearPath", mr.PicNearPath);
                //ComponentModel
                m.Add("NO", cm.NO);
                m.Add("HC", cm.HC);
                m.Add("CO2", cm.CO2);
                m.Add("CO", cm.CO);
                m.Add("Blackness", cm.Blackness);
                m.Add("OpSmoke", cm.OpSmoke);
                m.Add("Result", (int)cm.Result);
                //VehicleConditionInfoModel
                m.Add("Acceleration", vm.Acceleration);
                m.Add("Speed", vm.Speed);
                m.Add("VSP", vm.VSP);
                //EnvironmentInfoModel
                m.Add("Humidity", em.Humidity);
                m.Add("Pressure", em.Pressure);
                m.Add("Slope", em.Slope);
                m.Add("Temperature", em.Temperature);
                m.Add("WindDirection", em.WindDirection);
                m.Add("WindSpeed", em.WindSpeed);
                //GPSInfoModel
                m.Add("Station", gm.StationName);
                m.Add("Longitude", gm.TESTLNG);
                m.Add("Latitude", gm.TESTLAT);
                //m.Add("Slop", gm.Slope);

                Entities.Insert(0, m);
                if (Entities.Count > max) Entities.RemoveAt(max);
           //     UpdateStatisticList((int)cm.Result, vm.CarType,true);
                if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(RealtimeMonitorViewModel.MonitoringResultModel).Name));
                m_LastData = mr.StoreDateTime;

                //if (mr.DateTime.ToString("yyyyMMddHHmmss") == "00010101000000") return;
                //bool redata = false;
                //if (m_LastData == mr.DateTime.ToString("yyyyMMddHHmmss"))
                //{
                //    if ((int)cm.Result == -1 || (
                //        ((JObject)Entities[0])["Result"].ToString() == ((int)cm.Result).ToString()) &&
                //        ((JObject)Entities[0])["CarNumber"].ToString() == mr.CarNumber && mr.CarNumber.ToString() != "")
                //        return;
                //    Entities[0] = m;
                //    redata = true;
                //}
                //else
                //{
                //    m_LastResult = (int)cm.Result;
                //    m_LastCarNumber = mr.CarNumber;
                //    m_LastData = mr.DateTime.ToString("yyyyMMddHHmmss");
                //    Entities.Insert(0, m);

                //}
                //if (Entities.Count > max) Entities.RemoveAt(max);

                //ErrorLog.RealTime(DateTime.Now, mr.ToString());

                //for (int i = 0; i < Entities.Count; i++) ((JObject)Entities[i])["Index"] = i + 1;

                //if (!redata || (redata && m_LastResult != (int)cm.Result))
                //{
                //    if (redata && m_LastResult != (int)cm.Result)
                //    {
                //        //UpdateStatisticList(m_LastResult, vm.CarType,true);
                //        m_LastResult = (int)cm.Result;
                //    }
                //    UpdateStatisticList((int)cm.Result, vm.CarType, true);

                //}
                //if (!redata || (redata && m_LastCarNumber != mr.CarNumber))
                //{
                //    //JudgePollution(cm, vm.CarType);
                //    if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(RealtimeMonitorViewModel.MonitoringResultModel).Name));
                //}
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.StackTrace.ToString());
            }
            finally
            {
                IsLoading = false;
            }

        }
        /// <summary>
        /// 创建统计结果表
        /// </summary>
        /// <returns></returns>
        private List<object> CreateStatisticList(bool daily=false)
        {
            List<object> rs = new List<object>();
            language.InfoId infoId = language.InfoId.STAT_TOTAL;
            for (int i = 0; i < 5; i++)
            {
                JObject m = new JObject();
                m.Add("Type", Program.infoResource.GetLocalizedString(infoId));
                m.Add("Diesel", "---");
                m.Add("Gas", "---");
                m.Add("Total", "---");
                rs.Add(m);
                infoId++;
            }
            
            return rs;
        }

        string c_Diesel = "Diesel";
        string c_Gas = "Gas";
        string c_Total = "Total";
        /// <summary>
        /// 更新统计表
        /// </summary>
        public void UpdateStatisticList(int result = -1, string cartype = "", bool reload = false)
        {
            if (m_StatisticBusy) return;
            if (_DailyStatistics != null && _ComplexStatistics != null && _DailyStatistics.Count == 5 && _ComplexStatistics.Count == 5)
            {
                m_StatisticBusy = true;
                //Thread thread = new Thread(() =>
                //{
                try
                {
                    
                    if (!reload)
                    {
                        if (_DailyData == null || _DailyData.Count != 7) _DailyData = DataServiceHelper.Instanse.Statistics(true);
                        if (_ComplexData == null || _ComplexData.Count != 7) _ComplexData = DataServiceHelper.Instanse.Statistics();
                    }
                    else
                    {
                        _DailyData = DataServiceHelper.Instanse.Statistics(true);
                        _ComplexData = DataServiceHelper.Instanse.Statistics();
                    }
                    if (_DailyData == null || _DailyData.Count != 7 || _ComplexData == null || _ComplexData.Count != 7) return;

                    List<object> table = null;
                    List<int> data = null;
                    for (int k = 0; k < 2; k++)
                    {
                        table = k == 0 ? _DailyStatistics : _ComplexStatistics;
                        data = k == 0 ? _DailyData : _ComplexData;
                        //更新值
                        if (cartype == "B" || cartype == "A")
                        {
                            //[0]=超/柴;[1]=合/柴;[2]=无效/柴;[3]=超/气;[4]=合/气;[5]=无效/气;[6]=无效
                            //data[(result != 0 && result!=1 ? 2 : result) + cartype == "B" ? 0 : 3] += 1;
                            //MessageBox.Show(((result != 0 && result != 1 ? 2 : result) + cartype == "B" ? 0 : 3).ToString()+"   "+ data[(result != 0 && result != 1 ? 2 : result) + cartype == "B" ? 0 : 3].ToString());
                        }
                        //总
                        ((JObject)table[0])[c_Diesel] = data[0] + data[1] + data[2];
                        ((JObject)table[0])[c_Gas] = data[3] + data[4] + data[5];
                        ((JObject)table[0])[c_Total] = data[0] + data[1] + data[3] + data[4] +data[6];
                        //超标/合格/无效
                        for (int i = 1; i < 4; i++)
                        {
                            ((JObject)table[i])[c_Diesel] = data[i - 1] < 0 ? 0 : data[i - 1];
                            ((JObject)table[i])[c_Gas] = data[i - 1 + 3] < 0 ? 0 : data[i - 1 + 3];
                            ((JObject)table[i])[c_Total] = (data[i - 1] + data[i - 1 + 3]) < 0 ? 0 : data[i - 1] + data[i - 1 + 3];
                        }
                        //无效总数为所有无效值，计算方式与其他不同
                        if (data.Count > 6) ((JObject)table[3])[c_Total] = data[6] < 0 ? 0 : data[6];
                        //超标率
                        ((JObject)table[4])[c_Diesel] = ((JObject)table[0])[c_Diesel].Value<int>() <= 0 ? "0" : ((((JObject)table[1])[c_Diesel].Value<int>() * 1f / ((JObject)table[0])[c_Diesel].Value<int>()) * 100).ToString("f2") + "%";
                        ((JObject)table[4])[c_Gas] = ((JObject)table[0])[c_Gas].Value<int>() <= 0 ? "0" : ((((JObject)table[1])[c_Gas].Value<int>() * 1f / ((JObject)table[0])[c_Gas].Value<int>()) * 100).ToString("f2") + "%";
                        ((JObject)table[4])[c_Total] = ((JObject)table[0])[c_Total].Value<int>() <= 0 ? "0" : ((((JObject)table[1])[c_Total].Value<int>() * 1f / ((JObject)table[0])[c_Total].Value<int>()) * 100).ToString("f2") + "%";
                     }
                    if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(RealtimeMonitorViewModel.StatisticResultModel).Name));
                }
                finally
                {
                    m_StatisticBusy = false;
                }
                //});
            }
        }
        /// <summary>
        /// 判断测量组分是否超标
        /// </summary>
        /// <param name="cm"></param>
        /// <param name="vm"></param>
        private void JudgePollution(ComponentModel cm,  string cartype = "",int result=-1)
        {
            cm.BlacknessPollution = false;
            cm.CO2Pollution = false;
            cm.COPollution = false;
            cm.HCPollution = false;
            cm.OpSmokePollution = false;
            cm.NOPollution = false;
            if (!(cartype == "B" || cartype == "A"||cartype=="Z")) return;
            if (cartype == "Z")
            {
                PropertyInfo[] pro= cm.GetType().GetProperties();
                foreach (var p in pro)
                {
                    if (p.Name.Contains("Pollution")) p.SetValue(cm, false);
                }
                return;
            }
            ArrayList ls = null;
            if (cartype == "B")
                ls= DataServiceHelper.Instanse.QueryDieselCarLimiting();
            else
                ls = DataServiceHelper.Instanse.QueryGasolineLimiting();
           
            float fv;
            if (ls != null && ls.Count > 0)
            {
                if (cartype == "B")
                    cm.NOPollution = float.TryParse(((DTDieselCarLimitingInfo)ls[0]).NOLimiting.ToString(), out fv) ? cm.NO > fv : false;
                else
                    cm.NOPollution = float.TryParse(((DTGasolineLimitingInfo)ls[0]).NOLimiting.ToString(), out fv) ? cm.NO > fv : false;
                if (cartype == "B")
                    cm.OpSmokePollution = float.TryParse(((DTDieselCarLimitingInfo)ls[0]).OpSmokeLimiting.ToString(), out fv) ? cm.OpSmoke > fv : false;
                else
                    cm.OpSmokePollution = float.TryParse(((DTGasolineLimitingInfo)ls[0]).OpSmokeLimiting.ToString(), out fv) ? cm.OpSmoke > fv : false;
                cm.BlacknessPollution = cartype == "B" && float.TryParse(((DTDieselCarLimitingInfo)ls[0]).BlacknessLimiting.ToString(), out fv) ? cm.Blackness > fv : false;
                cm.COPollution = cartype == "A" && float.TryParse(((DTGasolineLimitingInfo)ls[0]).COLimiting.ToString(), out fv) ? cm.CO > fv : false;
                cm.HCPollution = cartype == "A" && float.TryParse(((DTGasolineLimitingInfo)ls[0]).HCLimiting.ToString(), out fv) ? cm.HC > fv : false;
            }
            if (result == 2)
            {
                //无效则不标红
                cm.BlacknessPollution = false;
                cm.CO2Pollution = false;
                cm.COPollution = false;
                cm.HCPollution = false;
                cm.OpSmokePollution = false;
                cm.NOPollution = false;
            }
    }
        #endregion

        #region class
        /// <summary>
        /// 测量因子
        /// </summary>
        public class ComponentModel
        {

            private float _CO = 0f;
            
            public virtual float CO
            {
                get { return _CO; }
                set { _CO = value;  }
            }
            
            private float _CO2 = 0f;
            public virtual float CO2
            {
                get { return _CO2; }
                set { _CO2 = value; }
            }
            private float _HC = 0f;
            public virtual float HC
            {
                get { return _HC; }
                set { _HC = value; }
            }
            private float _NO = 0f;
            public virtual float NO
            {
                get { return _NO; }
                set { _NO = value;  }
            }
            private float _OpSmoke = 0f;
            /// <summary>
            /// 不透光光度
            /// </summary>
            public virtual float OpSmoke
            {
                get { return _OpSmoke; }
                set { _OpSmoke = value; }
            }
            private float _Blackness = 0f;
            /// <summary>
            /// 林戈曼黑度
            /// </summary>
            public virtual float Blackness
            {
                get { return _Blackness; }
                set { _Blackness = value; }
            }

            public virtual bool COPollution { get; set; }
            public virtual bool CO2Pollution { get; set; }
            public virtual bool HCPollution { get; set; }
            public virtual bool NOPollution { get; set; }
            public virtual bool OpSmokePollution { get; set; }
            public virtual bool BlacknessPollution { get; set; }

            private float _Result = -1f;
            /// <summary>
            /// 结果
            /// </summary>
            public virtual float Result
            {
                get { return _Result; }
                set { _Result = value; }
            }
        }
        /// <summary>
        /// 车况信息
        /// </summary>
        public class VehicleConditionInfoModel
        {
            /// <summary>
            /// 速度
            /// </summary>
            public virtual float Speed { get; set; }
            public virtual float VSP { get; set; }
            /// <summary>
            /// 加速度
            /// </summary>
            public virtual float Acceleration { get; set; }
            /// <summary>
            /// 车类型， N 小汽车，Y柴油车
            /// </summary>
            public string CarType { get; set; }
        }
        public class GPSInfoModel
        {
            /// <summary>
            /// 站点名称
            /// </summary>
            public virtual string StationName { get; set; }
            /// <summary>
            /// 经度
            /// </summary>
            public virtual double TESTLNG { get; set; }
            /// <summary>
            /// 纬度
            /// </summary>
            public virtual double TESTLAT { get; set; }
            /// <summary>
            /// 坡度
            /// </summary>
            public virtual double Slope { get; set; }
        }
        /// <summary>
        /// 环境信息
        /// </summary>
        public class EnvironmentInfoModel
        {
            /// <summary>
            /// 温度
            /// </summary>
            public virtual float Temperature { get; set; }
            /// <summary>
            /// 湿度
            /// </summary>
            public virtual float Humidity { get; set; }
            /// <summary>
            /// 坡度
            /// </summary>
            public virtual float Slope { get; set; }
            /// <summary>
            /// 风向
            /// </summary>
            public virtual float WindDirection { get; set; }
            /// <summary>
            /// 风速
            /// </summary>
            public virtual float WindSpeed { get; set; }
            /// <summary>
            /// 气压
            /// </summary>
            public virtual float Pressure { get; set; }
        }
        /// <summary>
        /// 环境信息
        /// </summary>
        public class AirQualityModel
        {
            /// <summary>
            /// PM 2.5
            /// </summary>
            public virtual float PM25 { get; set; }
            public virtual float PM10 { get; set; }
            public virtual float NO2 { get; set; }
            public virtual float O3 { get; set; }
            public virtual float Vocs { get; set; }
            public virtual float CO { get; set; }
            public virtual float SO2 { get; set; }
        }
        /// <summary>
        /// 监控结果
        /// </summary>
        public class MonitoringResultModel
        {
            /// <summary>
            /// 序号
            /// </summary>
            public virtual int Index { get; set; }
            /// <summary>
            /// 结果产生时间
            /// </summary>
            public virtual DateTime DateTime { get; set; }
            /// <summary>
            /// 车道
            /// </summary>
            public virtual string Lane { get; set; }
            /// <summary>
            /// 车牌
            /// </summary>
            public virtual string CarNumber { get; set; }
            /// <summary>
            /// 车牌颜色
            /// </summary>
            public virtual string CarNumberColor { get; set; }
            /// <summary>
            /// 置信度
            /// </summary>
            public virtual string Confidence { get; set; }
            /// <summary>
            /// 车辆远景照片
            /// </summary>
            public virtual string PicFarPath { get; set; }
            /// <summary>
            /// 车辆近景照片
            /// </summary>
            public virtual string PicNearPath { get; set; }

            /// <summary>
            /// 车辆存储时间
            /// </summary>
            public virtual string StoreDateTime { get; set; }
        }
        /// <summary>
        /// 统计结果
        /// </summary>
        public class StatisticResultModel
        { }

        #endregion
    }


}
