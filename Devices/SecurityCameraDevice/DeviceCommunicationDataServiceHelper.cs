using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.plugin;
using Wayee.Services;

namespace wayeal.exdevice
{
    class DeviceCommunicationDataServiceHelper: PluginBase
    {
        #region init
        private IDataServer _DataServer = null;
        public DeviceCommunicationDataServiceHelper()
        {
            try
            {
                if (SOAClient.Instance != null)
                {
                    _DataServer = SOAClient.Instance.GetService<IDataServer>();
                }
            }
            catch
            {

            }

        }
        #endregion
        #region Define
        private static DeviceCommunicationDataServiceHelper _Instanse = null;
        /// <summary>
        /// 获取数据服务
        /// </summary>
        public static DeviceCommunicationDataServiceHelper Instanse
        {
            get
            {
                if (_Instanse == null)
                    _Instanse = new DeviceCommunicationDataServiceHelper();
                return _Instanse;
            }
        }
        #endregion
        #region private
        /// <summary>
        /// 查询设备信息
        /// </summary>
        /// <param name="DeviceName"></param>
        /// <returns></returns>
        public ArrayList QueryDeviceInfo(string DeviceName)
        {
            DTDeviceInfo dt = new DTDeviceInfo();
            dt.Name.Value = DeviceName;
            ArrayList rs = _DataServer.GetResult(dt);
            return rs;
        }

        /// <summary>
        /// 查询通讯信息
        /// </summary>
        /// <param name="ComName"></param>
        /// <returns>有通讯名称则查通讯，无通讯名称则查整个列表</returns>
        public ArrayList QueryCommunicationInfo(string ComName = null)
        {
            DTCommunicationInfo dt = new DTCommunicationInfo();
            if(ComName!=null)dt.Name.Value = ComName;
            ArrayList rs = _DataServer.GetResult(dt);
            return rs;
        }
        /// <summary>
        /// 保存设备通讯信息
        /// </summary>
        /// <param name="deviceName"></param>
        /// <param name="com"></param>
        /// <param name="intUsed"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public bool SaveDeviceComInfo(string deviceName, string com = null, string intUsed = null, string Param = null)
        {
            if (com == null && intUsed == null && Param == null) return true;
            DTDeviceInfo dt = new DTDeviceInfo();
            dt.Name.Value = deviceName;
            DTDeviceInfo dtafter = new DTDeviceInfo();
            if (com != null) dtafter.Commuunication.Value = com;
            if (intUsed != null) dtafter.Used.Value = Convert.ToInt32(intUsed);
            if (Param != null) dtafter.Param.Value = Param;
            bool rs = _DataServer.UpdateResult(dtafter, dt);
            return rs;
        }
        /// <summary>
        /// 保存通讯信息
        /// </summary>
        /// <param name="comName">通讯名</param>
        /// <param name="portNumber">端口号</param>
        /// <param name="baudRate">波特率</param>
        /// <param name="dataBit">数据位</param>
        /// <param name="stopBit">停止位</param>
        /// <param name="checkBit">校验位</param>
        /// <param name="IP">IP</param>
        /// <param name="portNumberTCP">TCP端口号</param>
        /// <returns></returns>
        public bool SaveCommunicationInfo(string comName,string portNumber=null,int baudRate=-1,int dataBit=-1,float stopBit=-1,int checkBit=-1,string IP=null,string portNumberTCP=null)
        {
            DTCommunicationInfo dtCondition = new DTCommunicationInfo();
            dtCondition.Name.Value = comName;
            DTCommunicationInfo dt = new DTCommunicationInfo();
            if (portNumber != null) dt.PortNumber.Value = portNumber;
            if (baudRate != -1) dt.BaudRate.Value = baudRate;
            if (dataBit != -1) dt.DataBit.Value = dataBit;
            if (stopBit != -1) dt.StopBit.Value = stopBit;
            if (checkBit != -1) dt.CheckBit.Value = checkBit;
            if (IP != null) dt.IP.Value = IP;
            if (portNumberTCP != null) dt.PortNumberTCP.Value = portNumberTCP;
            bool rs= _DataServer.UpdateResult(dt, dtCondition);
            return rs;
        }
        /// <summary>
        /// 删除通讯信息
        /// </summary>
        /// <param name="comName"></param>
        /// <returns></returns>
        public bool DeleteCommunicationInfo(string comName)
        {
            DTCommunicationInfo dt = new DTCommunicationInfo();
            dt.Name.Value = comName;
            bool rs = _DataServer.DeleteResult(dt);
            return rs;
        }
        /// <summary>
        /// 查询最后一条空气质量信息
        /// </summary>
        /// <returns></returns>
        public DTAirQualityInfo QueryAirQuality()
        {
            DTAirQualityInfo dt = new DTAirQualityInfo();
            dt.ID.Orderby = 2;
            ArrayList rs = _DataServer.GetResult(dt);
            DTAirQualityInfo rsdt = null;
            if (rs != null && rs.Count != 0) rsdt=(DTAirQualityInfo)rs[0];
            return rsdt;
        }
        /// <summary>
        /// 查询最后一条空气质量信息
        /// </summary>
        /// <returns></returns>
        public DTEnvironmentInfo QueryEnvironment()
        {
            DTEnvironmentInfo dt = new DTEnvironmentInfo();
            dt.ID.Orderby = 2;
            ArrayList rs = _DataServer.GetResult(dt);
            DTEnvironmentInfo rsdt = null;
            if (rs != null && rs.Count != 0) rsdt = (DTEnvironmentInfo)rs[0];
            return rsdt;
        }
        #endregion
    }
}
