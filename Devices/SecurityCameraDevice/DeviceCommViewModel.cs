﻿using DevExpress.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wayee.Services;
using wayeal.os.exhaust.ViewModel;
using wayeal.os.exhaust;

namespace wayeal.exdevice
{
    public  class DeviceCommViewModel
    {
        public DeviceCommViewModel()
        {
        }
        private static DeviceCommViewModel _VM = new DeviceCommViewModel();
        public static DeviceCommViewModel VM
        {
            get { return _VM; }
        }
        public event ModelEventHandler ModelChanged;
        public enum ExecuteCommand
        {
            ec_QueryComInfo,
            ec_QueryDeviceInfo,
            ec_SaveDeviceChange,
            ec_SaveComChange,
            ec_DeleteComInfo,
            ec_QueryAirQualityInfo,
            ec_QueryEnvironmentInfo,
            ec_SendDeviceToSOA,
        }
        public enum DeviceName
        {
            AirQuality,
            Analysis,
            GPS,
            LED,
            LicenseRecog,
            Meteorograph,
            NVR,
            Plat,
            SecurityCamera,
            AnalysisR1,
            AnalysisR2,
            AnalysisR3,
            AnalysisL1,
            AnalysisL2,
            AnalysisL3,
        }
        #region Model Event 
        public class ModelEventArgs : EventArgs
        {
            public ModelEventArgs(string name)
            {
                ModelName = name;
            }
            public string ModelName { get; set; }
        }
        public delegate void ModelEventHandler(object sender, ModelEventArgs e);
        #endregion

        /// <summary>
        /// 设备配置更新
        /// </summary>
        public const string DeviceConfigUpdate = "DeviceConfigUpdate";

        private BusinessResult _sendDeviceToSOAEntities= new BusinessResult();
        /// <summary>
        ///空气质量设备信息查询结果集模型
        /// </summary>
        public BusinessResult SendDeviceToSOAEntities { get { return _sendDeviceToSOAEntities; } private set { _sendDeviceToSOAEntities = value; } }


        private DTDeviceInfo _airQualitEntities = new DTDeviceInfo();
        /// <summary>
        ///空气质量设备信息查询结果集模型
        /// </summary>
        public DTDeviceInfo AirQualitEntities { get { return _airQualitEntities; } private set { _airQualitEntities = value; } }

        //private RealtimeMonitorViewModel.AirQualityModel _DeviceAirEntities = new RealtimeMonitorViewModel.AirQualityModel();
        ///// <summary>
        ///// 实时获取空气质量设备信息
        ///// </summary>
        //public  RealtimeMonitorViewModel.AirQualityModel DeviceAirEntities { get { return _DeviceAirEntities; }  set { _DeviceAirEntities = value; } }

        //private RealtimeMonitorViewModel.EnvironmentInfoModel _deviceEnvironEntities = new RealtimeMonitorViewModel.EnvironmentInfoModel();
        ///// <summary>
        ///// 实时获取气象仪环境信息
        ///// </summary>
        //public RealtimeMonitorViewModel.EnvironmentInfoModel DeviceEnvironEntities { get { return _deviceEnvironEntities; } set { _deviceEnvironEntities = value; } }

        //private RealtimeMonitorViewModel.GPSInfoModel _deviceGPSEntities = new RealtimeMonitorViewModel.GPSInfoModel();
        ///// <summary>
        ///// 实时获取GPS设备信息
        ///// </summary>
        //public RealtimeMonitorViewModel.GPSInfoModel DeviceGPSEntities { get { return _deviceGPSEntities; } set { _deviceGPSEntities = value; } }


        private DTDeviceInfo _analysisEntities = new DTDeviceInfo();
        /// <summary>
        ///尾气遥感分析仪设备信息查询结果集模型
        /// </summary>
        public DTDeviceInfo AnalysisEntities { get { return _analysisEntities; } private set { _analysisEntities = value; } }

        private DTDeviceInfo _GPSEntities = new DTDeviceInfo();
        /// <summary>
        ///GPS设备信息查询结果集模型
        /// </summary>
        public DTDeviceInfo GPSEntities { get { return _GPSEntities; } private set { _GPSEntities = value; } }

        private DTDeviceInfo _LEDEntities = new DTDeviceInfo();
        /// <summary>
        ///LED设备信息查询结果集模型
        /// </summary>
        public DTDeviceInfo LEDEntities { get { return _LEDEntities; } private set { _LEDEntities = value; } }

        private DTDeviceInfo _licenseRecogEntities = new DTDeviceInfo();
        /// <summary>
        ///车牌识别信息查询结果集模型
        /// </summary>
        public DTDeviceInfo LicenseRecogEntities { get { return _licenseRecogEntities; } private set { _licenseRecogEntities = value; } }

        private DTDeviceInfo _meteorographEntities = new DTDeviceInfo();
        /// <summary>
        ///气象仪设备信息查询结果集模型
        /// </summary>
        public DTDeviceInfo MeteorographEntities { get { return _meteorographEntities; } private set { _meteorographEntities = value; } }

        private DTDeviceInfo _NVREntities = new DTDeviceInfo();
        /// <summary>
        ///NVR设备信息查询结果集模型
        /// </summary>
        public DTDeviceInfo NVREntities { get { return _NVREntities; } private set { _NVREntities = value; } }

        private DTDeviceInfo _platEntities = new DTDeviceInfo();
        /// <summary>
        ///平台信息查询结果集模型
        /// </summary>
        public DTDeviceInfo PlatEntities { get { return _platEntities; } private set { _platEntities = value; } }

        private DTDeviceInfo _securityCameraEntities = new DTDeviceInfo();
        /// <summary>
        ///安防相机查询结果集模型
        /// </summary>
        public DTDeviceInfo SecurityCameraEntities { get { return _securityCameraEntities; } private set { _securityCameraEntities = value; } }


        private ArrayList _comInfoEntities = new ArrayList();
        /// <summary>
        ///通讯信息查询结果集模型
        /// </summary>
        public ArrayList ComInfoEntities { get { return _comInfoEntities; } private set { _comInfoEntities = value; } }

        private bool _saveDeviceChangeEntities=false;
        /// <summary>
        /// 保存设备参数修改的结果
        /// </summary>
        public bool SaveDeviceChangeEntities { get { return _saveDeviceChangeEntities; } private set { _saveDeviceChangeEntities = value; } }

        private bool _saveComChangeEntities = false;
        /// <summary>
        /// 保存通讯参数修改的结果
        /// </summary>
        public bool SaveComChangeEntities { get { return _saveComChangeEntities; } private set { _saveComChangeEntities = value; } }

        private bool _deleteComInfoEntities = false;
        /// <summary>
        /// 删除通讯信息的结果
        /// </summary>
        public bool DeleteComInfoEntities { get { return _deleteComInfoEntities; } private set { _deleteComInfoEntities = value; } }

        private DTAirQualityInfo _queryAirQualityEntities = new DTAirQualityInfo();
        /// <summary>
        /// 查询最后一条空气质量信息结果
        /// </summary>
        public DTAirQualityInfo QueryAirQualityEntities { get { return _queryAirQualityEntities; } private set { _queryAirQualityEntities = value; } }

        private DTEnvironmentInfo _queryEnvironmentEntities = new DTEnvironmentInfo();
        /// <summary>
        /// 查询最后一条环境信息结果
        /// </summary>
        public DTEnvironmentInfo QueryEnvironmentEntities { get { return _queryEnvironmentEntities; } private set { _queryEnvironmentEntities = value; } }

        
        /// <summary>
        /// UI binding method
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object paramter)
        {
            if (paramter is List<object> && (paramter as List<object>).Count > 0 && (paramter as List<object>)[0] is ExecuteCommand)
            {
                List<object> args = (paramter as List<object>);
                ExecuteCommand ec = (ExecuteCommand)args[0];
                args.RemoveAt(0);
                switch (ec)
                {
                    case ExecuteCommand.ec_QueryDeviceInfo: QueryDeviceInfo(args); break;
                    case ExecuteCommand.ec_QueryComInfo: QueryComInfo(args); break;
                    case ExecuteCommand.ec_SaveDeviceChange:SaveDeviceChange(args);break;
                    case ExecuteCommand.ec_SaveComChange: SaveComChange(args); break;
                    case ExecuteCommand.ec_DeleteComInfo: DeleteComInfo(args); break;
                    case ExecuteCommand.ec_QueryAirQualityInfo:QueryAirQualityInfo(args);break;
                    case ExecuteCommand.ec_QueryEnvironmentInfo: QueryEnvironmentInfo(args); break;
                    case ExecuteCommand.ec_SendDeviceToSOA:SendDeviceInfoToSOA(args);break;
                    //case ExecuteCommand.ec_QueryBackgroundLogPage: QueryBackgroundLogPage(args); break;
                }
            }
        }
        #region private
        /// <summary>
        /// 查询设备信息
        /// </summary>
        /// <param name="args">0:设备名</param>
        private void QueryDeviceInfo(List<object> args)
        {
            try
            {
                if (args.Count > 0)
                {
                    ArrayList rs= DeviceCommDataServiceHelper.Instanse.QueryDeviceInfo(args[0].ToString());
                    if (args[0].ToString().Contains("Analysis"))
                    {
                        if (rs == null) ClearDTDevice(AnalysisEntities);
                        else  ChangeDTDevice(AnalysisEntities,(DTDeviceInfo)rs[0]);
                    }
                    switch (args[0])
                    {
                        case DeviceName.AirQuality:
                            if (rs == null) ClearDTDevice(AirQualitEntities);
                            else ChangeDTDevice(AirQualitEntities, (DTDeviceInfo)rs[0]);
                            break;
                        //case DeviceName.Analysis:
                        //    AnalysisEntities = rs == null ? ClearDTDevice(AnalysisEntities) : (DTDeviceInfo)rs[0];
                        //    break;
                        case DeviceName.GPS:
                            if (rs == null) ClearDTDevice(GPSEntities);
                            else ChangeDTDevice(GPSEntities, (DTDeviceInfo)rs[0]);
                            break;
                        case DeviceName.LED:
                            LEDEntities = rs == null ? ClearDTDevice(LEDEntities) : (DTDeviceInfo)rs[0];
                            break;
                        case DeviceName.LicenseRecog:
                            LicenseRecogEntities = rs == null ? ClearDTDevice(LicenseRecogEntities) : (DTDeviceInfo)rs[0];
                            break;
                        case DeviceName.Meteorograph:
                            MeteorographEntities = rs == null ? ClearDTDevice(MeteorographEntities) : (DTDeviceInfo)rs[0];
                            break;
                        case DeviceName.NVR:
                            NVREntities = rs == null ? ClearDTDevice(NVREntities) : (DTDeviceInfo)rs[0];
                            break;
                        case DeviceName.Plat:
                            PlatEntities = rs == null ? ClearDTDevice(PlatEntities) : (DTDeviceInfo)rs[0];
                            break;
                        case DeviceName.SecurityCamera:
                            SecurityCameraEntities = rs == null ? ClearDTDevice(SecurityCameraEntities) : (DTDeviceInfo)rs[0];
                            break;
                        default:
                            break;
                    }
                }
                if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(DeviceCommViewModel).Name));
            }
            catch (Exception ex)
            {

            }

        }
        /// <summary>
        /// 查询通讯信息
        /// </summary>
        /// <param name="args">0:通信名（为空则查询整个列表）</param>
        private void QueryComInfo(List<object> args)
        {
            try
            {
                ArrayList rs = DeviceCommDataServiceHelper.Instanse.QueryCommunicationInfo(args.Count>0? args[0].ToString():null);
                if(rs!=null)ComInfoEntities = rs;
                if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(DeviceCommViewModel).Name));
               
            }
            catch (Exception ex)
            {

            }

        }
        private DTDeviceInfo ClearDTDevice(DTDeviceInfo dt)
        {
            if (dt != null)
            {
                dt.Commuunication.Value = null;
                dt.Param.Value= null;
                dt.Used.Value = null;
            }
            return dt;
        }
        private void ChangeDTDevice(DTDeviceInfo dt1,DTDeviceInfo dt2)
        {
            try
            {
                if (dt2 == null) return;
                dt1.Commuunication.Value = dt2.Commuunication.Value;
                dt1.Param.Value = dt2.Param.Value;
                dt1.Used.Value = dt2.Used.Value;
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 保存设备信息修改
        /// </summary>
        /// <param name="args"></param>
        private void SaveDeviceChange(List<object> args)
        {
            //需传四个参数，不改变的数据用null代替。
            if (args.Count < 3) return;
            bool rs = DeviceCommDataServiceHelper.Instanse.SaveDeviceComInfo(args[0].ToString(),
                args[1] == null ? null : args[1].ToString(),
                 args[2] == null ? null : args[2].ToString(),
                  args[3] == null ? null : args[3].ToString());
            SaveDeviceChangeEntities = rs;
      //      if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(DeviceCommunicationViewModel).Name));
        }
        /// <summary>
        /// 保存通讯修改
        /// </summary>
        /// <param name="args"></param>
        private void SaveComChange(List<object> args)
        {
            try
            {
                if (args.Count == 4)
                {
                    string ip =args[1]==null? null: args[1].ToString();
                    string portNumberTCP = args[2].ToString();
                    string CSType = args[3] == null ? null:args[3].ToString();
                    bool rs = DeviceCommDataServiceHelper.Instanse.SaveCommunicationInfo(args[0].ToString(), null, -1, -1, -1, -1, ip, portNumberTCP,args[3].ToString());
                    SaveComChangeEntities = rs;
                }
                else if (args.Count == 6)
                {
                    bool rs = DeviceCommDataServiceHelper.Instanse.SaveCommunicationInfo(args[0].ToString(), args[1].ToString(),
                        Convert.ToInt32(args[2]), Convert.ToInt32(args[3]), Convert.ToSingle(args[4]), Convert.ToInt32(args[5]));
                    SaveComChangeEntities = rs;
                }
            }
            catch (Exception ex)
            {
                SaveComChangeEntities = false;
            }
        }
        /// <summary>
        /// 删除通讯信息
        /// </summary>
        /// <param name="args"></param>
        private void DeleteComInfo(List<object> args)
        {
            try
            {
                if (args.Count < 1) return;
                DeleteComInfoEntities = DeviceCommDataServiceHelper.Instanse.DeleteCommunicationInfo(args[0].ToString());
            }
            catch (Exception ex)
            {
                DeleteComInfoEntities = false;
            }
        }
        /// <summary>
        /// 查询最后一条空气质量信息
        /// </summary>
        /// <param name="args"></param>
        private void QueryAirQualityInfo(List<object> args)
        {
            try
            {
                DTAirQualityInfo dt = DeviceCommDataServiceHelper.Instanse.QueryAirQuality();
                if (dt == null) return;
                QueryAirQualityEntities = dt;
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 查询最后一条环境信息
        /// </summary>
        /// <param name="args"></param>
        private void QueryEnvironmentInfo(List<object> args)
        {
            try
            {
                DTEnvironmentInfo dt = DeviceCommDataServiceHelper.Instanse.QueryEnvironment();
                if (dt == null) return;
                QueryEnvironmentEntities = dt;
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 发送设备信息给SOA
        /// </summary>
        /// <param name="args"></param>
        public void SendDeviceInfoToSOA(List<object> args)
        {
            SendDeviceToSOAEntities.Result = false;
            if (args.Count < 3) return;
            try
            {
                DeviceInfo info = new DeviceInfo();
                info.Name = args[0] == null ? "" : args[0].ToString();
                info.Communication = args[1] == null ? "" : args[1].ToString();
                info.Used = args[2] == null ? -1 : Convert.ToInt32(args[2]);
                info.Param = args[3] == null ? "" : args[3].ToString();
                
                SendDeviceToSOAEntities = DeviceCommBusinessServerHelper.Instanse.ExecuteBusiness(DeviceConfigUpdate, JsonNewtonsoft.ToJSON(info),BusinessType.Set);
            }
            catch (Exception ex)
            {

            }
        }
        class DeviceInfo
        {
            /// <summary>
            /// 设备名称
            /// </summary>
            public string Name;
            /// <summary>
            /// 通讯名
            /// </summary>
            public string Communication;
            /// <summary>
            /// 是否启用
            /// </summary>
            public int Used;
            /// <summary>
            /// 参数
            /// </summary>
            public string Param;
        }
        #endregion

    }
}
