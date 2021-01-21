﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Wayee.Services;
using WYDAO;
using static wayeal.os.exhaust.UserControls.ucCalibrationExtendController;

namespace wayeal.os.exhaust.Services
{
    public class DataServiceHelper
    {
        #region init
        private IDataServer _DataServer = null;
        public IDataServer DataServerStatue { get { return _DataServer; } }
        public DataServiceHelper()
        {
            if (SOAClient.Instance != null)
            {
                _DataServer = SOAClient.Instance.GetService<IDataServer>();
            }
        }
        private IUserManagerServer _LoginServer = null;

        #endregion

        #region Define
        private string MINPERMISSION = "4";
        private string DEFAULTPWD = "123456";
        private enum enumErrorType
        {
            SOAClientConnectionFail=0,
            LoginServerConnectionFail=1,
            UserNameOrPasswordError=2
        }
        private static DataServiceHelper _Instanse = null;
        /// <summary>
        /// 获取数据服务
        /// </summary>
        public static DataServiceHelper Instanse
        {
            get
            {
                if (_Instanse == null)
                    _Instanse = new DataServiceHelper();
                return _Instanse;
            }
        }
        #endregion

        #region public
        /// <summary>
        /// 统计结果
        /// 结果:[0]=超/柴;[1]=合/柴;[2]=无效/柴;[3]=超/气;[4]=合/气;[5]=无效/气;[6]=所有无效;
        /// </summary>
        public List<int> Statistics(bool daily=false,string beginTime=null,string endTime=null)
        {
            if (_DataServer == null) return null;
            try
            {
                DTMonitoringResult mr = new DTMonitoringResult();
                DTVehicleInfo vi = new DTVehicleInfo();
                if (daily)
                {
                    mr.MonitoringTime.RelationalOptor = WYDBC.Relational.Between;
                    mr.MonitoringTime.Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
                    mr.MonitoringTime.Value2 = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
                }
                if (!String.IsNullOrEmpty(beginTime) && !String.IsNullOrEmpty(endTime))
                {
                    DateTime s, e;
                    if (!DateTime.TryParse(beginTime, out s)) return null;
                    if (!DateTime.TryParse(endTime, out e)) return null;
                    mr.MonitoringTime.RelationalOptor = WYDBC.Relational.Between;
                    mr.MonitoringTime.Value = s.ToString("yyyy-MM-dd HH:mm:ss");
                    mr.MonitoringTime.Value2 = e.ToString("yyyy-MM-dd HH:mm:ss");
                }
                List<int> value = new List<int>();
                int count = 0;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        vi.CarType.Value = i == 0 ? "B" : "A";
                        mr.Result.Value = j;
                        mr.UniqueKey.JionTo = "1." + mr.UniqueKey.FieldName + ";" + "2." + vi.UniqueKey.FieldName;
                        count = _DataServer.GetRowCount(new ArrayList() { mr, vi });
                        value.Add(count < 0 ? 0 : count);
                    }
                }
                vi = new DTVehicleInfo();
                mr.Result.Value = 2;
                mr.UniqueKey.JionTo= "1." + mr.UniqueKey.FieldName + ";" + "2." + vi.UniqueKey.FieldName;
                count = _DataServer.GetRowCount(new ArrayList() { mr, vi });
                value.Add(count < 0 ? 0 : count);
                return value;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 查询设备信息
        /// </summary>
        /// <returns></returns>
        public List<object> QueryDevices()
        {
            try
            {
                if (_DataServer == null) return null;
                DTDeviceInfo dt = new DTDeviceInfo();
                ArrayList rs = _DataServer.GetResult(dt);
                return rs != null ? rs.ToArray().ToList<object>():null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 查询尾气结果
        /// </summary>
        /// <param name="sd">开始时间</param>
        /// <param name="ed">结束时间</param>
        /// <param name="number">车牌号</param>
        /// <param name="result">结果类型</param>
        /// <returns>数据列表</returns>
        public ArrayList Query(DateTime sd, DateTime ed, string number = "", string result = "", string factor = "", string NOBegin = "", string NOEnd = "", string COBegin = "",
            string COEnd = "", string HCBegin = "", string HCEnd = "", string OpSmokeBegin = "", string OpSmokeEnd = "", string BlacknessBegin = "", string BlacknessEnd = "", int SortFactor = 0,
            int SortOrder = 2, int pageNumber = -1, int pageSize = -1, int lane = 0, int fuel = 0,int VehicleType=-1)
        {
            try
            {
                if (_DataServer == null) return null;
                #region dtMonitoring
                DTMonitoringResult dt = new DTMonitoringResult();
                dt.MonitoringTime.Value = sd.ToString("yyyy-MM-dd HH:mm:ss");
                dt.MonitoringTime.Value2 = ed.ToString("yyyy-MM-dd HH:mm:ss");
                dt.MonitoringTime.RelationalOptor = WYDBC.Relational.Between;
                
                if (result != "")
                {
                    if (result == "3")
                    {
                        //查有效等于所有减无效
                        dt.Result.Value = 2;
                        dt.Result.RelationalOptor = WYDBC.Relational.NoEquals;
                    }
                    else
                    { dt.Result.Value = result; }
                }
                if (factor != "")
                {
                    dt.ExcessiveFactor.Value = factor;
                    dt.ExcessiveFactor.RelationalOptor = WYDBC.Relational.Like;
                }
                SetQueryCondition(dt.NO, NOBegin, NOEnd);
                SetQueryCondition(dt.CO, COBegin, COEnd);
                SetQueryCondition(dt.HC, HCBegin, HCEnd);
                SetQueryCondition(dt.OpSmoke, OpSmokeBegin, OpSmokeEnd);
                SetQueryCondition(dt.Blackness, BlacknessBegin, BlacknessEnd);

                string fieldName = "";
                if (SortFactor < 7||SortOrder==0)
                {
                    SetSortCondition(dt, SortFactor, SortOrder, out fieldName);
                }

                object field = null;
                PropertyInfo[] property = dt.GetType().GetProperties();
                foreach (PropertyInfo pinf in property)
                {
                    field = pinf.GetValue(dt);
                    if (field != null && field is FieldAttribute) (field as FieldAttribute).IsSelectField = true;
                }
                dt.ID.IsSelectField = false;
                #endregion

                #region vehicle
                DTVehicleInfo vehicleInfo = new DTVehicleInfo();

                string vehiField= CreateDtVehicle(vehicleInfo,number,lane,fuel,SortOrder,SortFactor);
                if (fieldName == "") fieldName =vehiField;
                #endregion

                #region environment   airquality
                DTEnvironmentInfo environmentInfo = new DTEnvironmentInfo();
                property = environmentInfo.GetType().GetProperties();
                foreach (PropertyInfo pinf in property)
                {
                    field = pinf.GetValue(environmentInfo);
                    if (field != null && field is FieldAttribute) (field as FieldAttribute).IsSelectField = true;
                }
                environmentInfo.ID.IsSelectField = false;
                environmentInfo.UniqueKey.IsSelectField = false;

                DTAirQualityInfo airQualityInfo = new DTAirQualityInfo();
                property = airQualityInfo.GetType().GetProperties();
                foreach (PropertyInfo pinf in property)
                {
                    field = pinf.GetValue(airQualityInfo);
                    if (field != null && field is FieldAttribute) (field as FieldAttribute).IsSelectField = true;
                }

                airQualityInfo.ID.IsSelectField = false;
                airQualityInfo.UniqueKey.IsSelectField = false;
                airQualityInfo.TestingTime.IsSelectField = false;
                airQualityInfo.Serial.IsSelectField = false;
                if (SortOrder != 0)
                {
                    airQualityInfo.ID.Orderby = (byte)SortOrder;
                    
                }
                #endregion
                string dtUnikeyJoin = "1." + environmentInfo.UniqueKey.FieldName + ";" + "2." + vehicleInfo.UniqueKey.FieldName  + ";" + "3." + airQualityInfo.UniqueKey.FieldName;
                dt.UniqueKey.JionTo = dtUnikeyJoin;
                
                ArrayList alDataTable = new ArrayList() { dt, environmentInfo, vehicleInfo,airQualityInfo };
                if (VehicleType > 0)
                {
                    List<int> vehicleClass;
                    switch (VehicleType)
                    {
                        case 1: vehicleClass = new List<int>() { 0 }; break;
                        case 2: vehicleClass = new List<int>() { 1, 10, 26 }; break;
                        case 3: vehicleClass = new List<int>() { 3, 9, 13, 14, 23, 24, 25, 11 }; break;
                        case 4: vehicleClass = new List<int>() { 2, 5, 16, 15, 17, 18, 20, 21, 22 }; break;
                        case 5: vehicleClass = new List<int>() { 6, 7, 8, 12 }; break;
                        case 6: vehicleClass = new List<int>() { 4 }; break;
                        case 7: vehicleClass = new List<int>() { 19 }; break;
                        default: vehicleClass = null; break;
                    }
                    if (vehicleClass != null)
                    {
                            for (int i = 0; i < vehicleClass.Count; i++)
                            {
                                DTVehicleInfo dtvehi = new DTVehicleInfo();
                                dtvehi.ConditionGroupName = "11";
                                dtvehi.VehicleType.Value = vehicleClass[i];
                                alDataTable.Add(dtvehi);
                            }
                    }
                }

                ArrayList rs = new ArrayList();

                if (pageNumber == -1) fieldName = null;
                else if (SortFactor < 7) fieldName = ","+ dt.TABLENAME + "." + fieldName;
                else fieldName = ","+airQualityInfo.TABLENAME + "." + fieldName;

                //fieldName = vehicleInfo.TABLENAME + "." + "ID";

                rs = _DataServer.GetResult(alDataTable, fieldName, pageNumber, pageSize);
                if (rs == null) return null;
                ArrayList list = new ArrayList();
                for (int i = 0; i < rs.Count; i++)
                {
                    if (rs[i] != null)
                    {
                        object obj = JsonNewtonsoft.FromJSON(rs[i].ToString().Replace('\'','\"'));
                        if (obj != null) list.Add(obj);
                    }
                }
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private void SetSortCondition(DTMonitoringResult dt,int SortFactor,int SortOrder,out string filedName)
        {
            filedName = null ;
            if (!(SortOrder == 0 || SortOrder == 1 || SortOrder == 2)) return;
            //不排序则恢复按时间倒序
            if (SortOrder == 0)
            {
                filedName = dt.MonitoringTime.FieldName;
                dt.MonitoringTime.Orderby = 2;
                return;
            }
            switch (SortFactor)
            {
                case 0: dt.MonitoringTime.Orderby= (byte)SortOrder; filedName=dt.MonitoringTime.FieldName; break;
                case 1: dt.NO.Orderby=(byte)SortOrder; filedName = dt.NO.FieldName; break;
                case 2: dt.HC.Orderby = (byte)SortOrder; filedName = dt.HC.FieldName; break;
                case 3: dt.CO.Orderby = (byte)SortOrder; filedName = dt.CO.FieldName; break;
                case 4: dt.CO2.Orderby = (byte)SortOrder; filedName = dt.CO2.FieldName; break;
                case 5: dt.OpSmoke.Orderby = (byte)SortOrder; filedName = dt.OpSmoke.FieldName; break;
                case 6: dt.Blackness.Orderby = (byte)SortOrder; filedName = dt.Blackness.FieldName; break;
                default:return;
            }
        }
        private void SetSortCondition(DTVehicleInfo dt, int SortFactor, int SortOrder, out string filedName)
        {
            filedName = "";
            if (!(SortOrder == 0 || SortOrder == 1 || SortOrder == 2)) return;
            switch (SortFactor)
            {
                case 7: dt.Speed.Orderby = (byte)SortOrder; filedName = dt.Speed.FieldName; break;
                case 8: dt.Acceleration.Orderby = (byte)SortOrder; filedName = dt.Acceleration.FieldName; break;
                case 9: dt.VSP.Orderby = (byte)SortOrder; filedName = dt.VSP.FieldName; break;
                default: return;
            }
        }

        private void SetQueryCondition(FieldAttribute fied, string begin, string end)
        {
            if (begin == "")
            {
                if (end != "")
                {
                    fied.Value = end;
                    fied.RelationalOptor = WYDBC.Relational.SmallerEquals;
                }
            }
            else
            {
                fied.Value = begin;
                if (end == "")
                {
                    fied.RelationalOptor = WYDBC.Relational.GreaterEquals;
                }
                else
                {
                    fied.Value2 = end;
                    fied.RelationalOptor = WYDBC.Relational.Between;
                }
            }
        }

        public ArrayList QueryUniqueKey(string uniqueKey)
        {
            try
            {
                if (_DataServer == null) return null;
                DTMonitoringResult dt = new DTMonitoringResult();
           
                object field = null;
                PropertyInfo[] property = dt.GetType().GetProperties();
                foreach (PropertyInfo pinf in property)
                {
                    field = pinf.GetValue(dt);
                    if (field != null && field is FieldAttribute) (field as FieldAttribute).IsSelectField = true;
                }
                dt.ID.IsSelectField = false;
            //    dt.UniqueKey.Value = uniqueKey;

                DTVehicleInfo vehicleInfo = new DTVehicleInfo();
                property = vehicleInfo.GetType().GetProperties();
                foreach (PropertyInfo pinf in property)
                {
                    field = pinf.GetValue(vehicleInfo);
                    if (field != null && field is FieldAttribute) (field as FieldAttribute).IsSelectField = true;
                }
                vehicleInfo.ID.IsSelectField = false;
                vehicleInfo.UniqueKey.IsSelectField = false;
              //  vehicleInfo.UniqueKey.Value = uniqueKey;

                DTEnvironmentInfo environmentInfo = new DTEnvironmentInfo();
                property = environmentInfo.GetType().GetProperties();
                foreach (PropertyInfo pinf in property)
                {
                    field = pinf.GetValue(environmentInfo);
                    if (field != null && field is FieldAttribute) (field as FieldAttribute).IsSelectField = true;
                }
                environmentInfo.ID.IsSelectField = false;
                environmentInfo.UniqueKey.IsSelectField = false;

                DTAirQualityInfo airQualityInfo = new DTAirQualityInfo();
                property = airQualityInfo.GetType().GetProperties();
                foreach (PropertyInfo pinf in property)
                {
                    field = pinf.GetValue(airQualityInfo);
                    if (field != null && field is FieldAttribute) (field as FieldAttribute).IsSelectField = true;
                }

                airQualityInfo.ID.IsSelectField = false;
                airQualityInfo.UniqueKey.IsSelectField = false;
                airQualityInfo.TestingTime.IsSelectField = false;
                airQualityInfo.Serial.IsSelectField = false;
                dt.UniqueKey.JionTo = "1." + vehicleInfo.UniqueKey.FieldName + ";" + "2." + environmentInfo.UniqueKey.FieldName + ";" + "3." + airQualityInfo.UniqueKey.FieldName;
                dt.UniqueKey.Value = uniqueKey;

                ClassHelper c = new ClassHelper();
                ArrayList rs = _DataServer.GetResult(new ArrayList() { dt, vehicleInfo, environmentInfo, airQualityInfo });
                if (rs == null) return null;
                ArrayList list = new ArrayList();
                for (int i = 0; i < rs.Count; i++)
                {
                    if (rs[i] != null)
                    {
                        object obj = JsonNewtonsoft.FromJSON(rs[i].ToString());
                        if (obj != null) list.Add(obj);
                    }
                    //JObject obj = Newtonsoft.Json.Linq.JObject.Parse(rs[i].ToString ());
                    //list.Add(obj);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 查询尾气总数
        /// </summary>
        /// <param name="sd"></param>
        /// <param name="ed"></param>
        /// <param name="number"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public int QueryExhaustCount(DateTime sd, DateTime ed, string number = "", string result = "", string factor = "", string NOBegin = "", string NOEnd = "", 
            string COBegin = "",string COEnd = "", string HCBegin = "", string HCEnd = "", string OpSmokeBegin = "", string OpSmokeEnd = "", string BlacknessBegin = "",
            string BlacknessEnd = "",string lane="0",string fuel="0",int VehicleType = -1)
        {
            try
            {
                if (_DataServer == null) return 0;
                DTMonitoringResult dt = new DTMonitoringResult();
                dt.MonitoringTime.Value = sd.ToString("yyyy-MM-dd HH:mm:ss");
                dt.MonitoringTime.Value2 = ed.ToString("yyyy-MM-dd HH:mm:ss");
                dt.MonitoringTime.RelationalOptor = WYDBC.Relational.Between;
                if (result != "")
                {
                    if (result == "3")
                    {
                        //查有效等于所有减无效
                        dt.Result.Value = 2;
                        dt.Result.RelationalOptor = WYDBC.Relational.NoEquals;
                    }
                    else
                    { dt.Result.Value = result; }
                }
                if (factor != "")
                {
                    dt.ExcessiveFactor.Value = factor;
                    dt.ExcessiveFactor.RelationalOptor = WYDBC.Relational.Like;
                }
                SetQueryCondition(dt.NO, NOBegin, NOEnd);
                SetQueryCondition(dt.CO, COBegin, COEnd);
                SetQueryCondition(dt.HC, HCBegin, HCEnd);
                SetQueryCondition(dt.OpSmoke, OpSmokeBegin, OpSmokeEnd);
                SetQueryCondition(dt.Blackness, BlacknessBegin, BlacknessEnd);
                
                object field = null;
                PropertyInfo[] property = dt.GetType().GetProperties();
                foreach (PropertyInfo pinf in property)
                {
                    field = pinf.GetValue(dt);
                    if (field != null && field is FieldAttribute) (field as FieldAttribute).IsSelectField = true;
                }
                dt.ID.IsSelectField = false;

                DTVehicleInfo vehicleInfo = new DTVehicleInfo();
                property = vehicleInfo.GetType().GetProperties();
                foreach (PropertyInfo pinf in property)
                {
                    field = pinf.GetValue(vehicleInfo);
                    if (field != null && field is FieldAttribute) (field as FieldAttribute).IsSelectField = true;
                }
                CreateDtVehicle(vehicleInfo, number,Convert.ToInt32(lane),Convert.ToInt32(fuel));
                vehicleInfo.ID.IsSelectField = false;
                vehicleInfo.UniqueKey.IsSelectField = false;

                DTEnvironmentInfo environmentInfo = new DTEnvironmentInfo();
                property = environmentInfo.GetType().GetProperties();
                foreach (PropertyInfo pinf in property)
                {
                    field = pinf.GetValue(environmentInfo);
                    if (field != null && field is FieldAttribute) (field as FieldAttribute).IsSelectField = true;
                }
                environmentInfo.ID.IsSelectField = false;
                environmentInfo.UniqueKey.IsSelectField = false;

                DTAirQualityInfo airQualityInfo = new DTAirQualityInfo();
                property = airQualityInfo.GetType().GetProperties();
                foreach (PropertyInfo pinf in property)
                {
                    field = pinf.GetValue(airQualityInfo);
                    if (field != null && field is FieldAttribute) (field as FieldAttribute).IsSelectField = true;
                }

                airQualityInfo.ID.IsSelectField = false;
                airQualityInfo.UniqueKey.IsSelectField = false;
                airQualityInfo.TestingTime.IsSelectField = false;
                airQualityInfo.Serial.IsSelectField = false;

                string dtUnikeyJoin = "1." + environmentInfo.UniqueKey.FieldName + ";" + "2." + airQualityInfo.UniqueKey.FieldName + ";" + "3." + vehicleInfo.UniqueKey.FieldName;
                dt.UniqueKey.JionTo = dtUnikeyJoin;

                ArrayList alDataTable = new ArrayList() { dt, environmentInfo, airQualityInfo ,vehicleInfo};
                if (VehicleType > 0)
                {
                    List<int> vehicleClass;
                    switch (VehicleType)
                    {
                        case 1: vehicleClass = new List<int>() { 0 }; break;
                        case 2: vehicleClass = new List<int>() { 1, 10, 26 }; break;
                        case 3: vehicleClass = new List<int>() { 3, 9, 13, 14, 23, 24, 25, 11 }; break;
                        case 4: vehicleClass = new List<int>() { 2, 5, 16, 15, 17, 18, 20, 21, 22 }; break;
                        case 5: vehicleClass = new List<int>() { 6, 7, 8, 12 }; break;
                        case 6: vehicleClass = new List<int>() { 4 }; break;
                        case 7: vehicleClass = new List<int>() { 19 }; break;
                        default: vehicleClass = null; break;
                    }
                    if (vehicleClass != null)
                    {
                        for (int i = 0; i < vehicleClass.Count; i++)
                        {
                            DTVehicleInfo dtvehi = new DTVehicleInfo();
                            dtvehi.ConditionGroupName = "11";
                            dtvehi.VehicleType.Value = vehicleClass[i];
                            alDataTable.Add(dtvehi);
                        }
                    }
                }
                int rs = _DataServer.GetRowCount(alDataTable);
                return rs;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 查询用户信息结果
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="permission">权限等级</param>
        /// <returns>数据列表</returns>
        public ArrayList QueryUser(string username,string permission,string password,int pagenumber=-1,int pagesize=-1)
        {
            try
            {
                if (_DataServer == null) return null;
                DTUserInfo dTUser = new DTUserInfo();
                if (username != "")
                {
                    dTUser.UserName.Value = username;
                    dTUser.UserName.RelationalOptor = password != null ? WYDBC.Relational.Equals : WYDBC.Relational.Like;
                }
                if (permission != "") dTUser.Permission.Value = Convert.ToInt32(permission);

                if (password != null)
                {
                    dTUser.Permission.IsSelectField = true;
                    dTUser.Statue.IsSelectField = true;
                    dTUser.Password.IsSelectField = true;
                    dTUser.Password.Value = password;
                }
                if (password == "") { dTUser.Password.Value = null; }
                //按时间正序
                dTUser.CreateTime.Orderby = 1;
                ArrayList rs = _DataServer.GetResult(dTUser, dTUser.CreateTime.FieldName.ToString(),pagenumber,pagesize);
                return rs;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 查询用户总条数
        /// </summary>
        /// <param name="username"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int QueryUserCount(string username, string permission)
        {
            if (_DataServer == null) return 0;
            DTUserInfo dTUser = new DTUserInfo();
            if (username != "")
            {
                dTUser.UserName.Value = username;
                dTUser.UserName.RelationalOptor = WYDBC.Relational.Like;
            }
            if (permission != "") dTUser.Permission.Value = Convert.ToInt32(permission);
            int rs = _DataServer.GetRowCount(dTUser);
            return rs;
        }
        
        /// <summary>
        /// 查询柴油车限值历史记录结果
        /// </summary>
        /// <returns>数据列表</returns>
        public ArrayList QueryDieselCarLimiting()
        {
            try
            {
                if (_DataServer == null) return null;
                DTDieselCarLimitingInfo dT = new DTDieselCarLimitingInfo();
                dT.StartTime.Orderby = 2;
                ArrayList rs = _DataServer.GetResult(dT);
                return rs;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 查询汽油车限值历史记录结果
        /// </summary>
        /// <returns>数据列表</returns>
        public ArrayList QueryGasolineLimiting()
        {
            try
            {
                if (_DataServer == null) return null;
                DTGasolineLimitingInfo dT = new DTGasolineLimitingInfo();
                dT.StartTime.Orderby = 2;
                ArrayList rs = _DataServer.GetResult(dT);
                return rs;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 查询其他参数结果
        /// </summary>
        /// <returns>数据列表</returns>
        public ArrayList QueryOtherParam()
        {
            try
            {
                if (_DataServer == null) return null;
                DTOtherParamInfo dTOtherParamInfo = new DTOtherParamInfo();
                ArrayList rs = _DataServer.GetResult(dTOtherParamInfo);
                return rs;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 查询空气质量结果
        /// </summary>
        /// <param name="sd">开始时间</param>
        /// <param name="ed">结束时间</param>
        /// <returns></returns>
        public ArrayList QueryAirQuality(DateTime sd, DateTime ed, int pagenumber = -1, int pagesize = -1)
        {
            try
            {
                if (_DataServer == null) return null;
                DTAirQualityInfo dtAir = new DTAirQualityInfo();
                dtAir.TestingTime.Value = sd.ToString("yyyy-MM-dd HH:mm:ss");
                dtAir.TestingTime.Value2 = ed.ToString("yyyy-MM-dd HH:mm:ss");
                dtAir.TestingTime.RelationalOptor = WYDBC.Relational.Between;
                dtAir.ID.Orderby = 2;
                ArrayList rs = null;
                if (pagenumber == -1 && pagesize == -1)
                    rs = _DataServer.GetResult(dtAir);
                else
                    rs= _DataServer.GetResult(dtAir,dtAir.ID.FieldName,pagenumber,pagesize);
                return rs;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 查询空气质量结果总条数
        /// </summary>
        /// <param name="sd">开始时间</param>
        /// <param name="ed">结束时间</param>
        /// <returns>-1：出错</returns>
        public int QueryAirQualityCount(DateTime sd, DateTime ed)
        {
            if (_DataServer == null) return 0;
            DTAirQualityInfo dtAir = new DTAirQualityInfo();
            dtAir.TestingTime.Value = sd.ToString("yyyy-MM-dd HH:mm:ss");
            dtAir.TestingTime.Value2 = ed.ToString("yyyy-MM-dd HH:mm:ss");
            dtAir.TestingTime.RelationalOptor = WYDBC.Relational.Between;
            dtAir.TestingTime.Orderby = 2;
            int rs = _DataServer.GetRowCount(dtAir);
            return rs;
        }
        /// <summary>
        /// 插入用户数据
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="ctor">创建者</param>
        /// <param name="time">创建时间</param>
        /// <param name="pmt">权限级别</param>
        /// <param name="statue">账号状态</param>
        /// <returns></returns>
        public object InsertUser(string name,string ctor,DateTime time,string pmt,string statue)
        {
            try
            {
                if (_DataServer == null) return false;
                DTUserInfo dt = new DTUserInfo();
                dt.UserName.Value = name;
                dt.Creator.Value = ctor;
                dt.CreateTime.Value = time;
                dt.Permission.Value = (pmt != "" ? pmt : MINPERMISSION);
                dt.Statue.Value = statue;
                dt.Password.Value = DEFAULTPWD;
                return _DataServer.SaveResult(dt) ? dt : null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 插入柴油车限值记录
        /// </summary>
        /// <param name="st">时间</param>
        /// <param name="NO">NO限值</param>
        /// <param name="op">不透光烟度</param>
        /// <param name="bla">林格曼黑度</param>
        /// <param name="judge1">不透光烟度是否作为判定条件</param>
        /// <param name="judge2">黄牌车是否作为判定条件</param>
        /// <param name="jv">不透光烟度判定值</param>
        /// <param name="tips">备注</param>
        /// <returns></returns>
        public object InsertDieselCarLimiting( DateTime st,string NO,string op,string bla,string judge1,string judge2,string jv,string tips)
        {
            try
            {
                if (_DataServer == null) return null;
                DTDieselCarLimitingInfo dt = new DTDieselCarLimitingInfo();
                dt.StartTime.Value = st;
                dt.NOLimiting.Value = NO;
                dt.OpSmokeLimiting.Value = op;
                dt.BlacknessLimiting.Value = bla;
                if (judge1 == "0" || judge1 == "1") dt.JudgeOpSmoke.Value = judge1;
                //  else if (judge1 == "1") dt.JudgeOpSmoke.Value = true;
                if (judge2 == "0" || judge2 == "1") dt.JudgeYellowCar.Value = judge2;
                //   else if (judge2 == "1") dt.JudgeOpSmoke.Value = true;
                dt.JudgeOpSmokeValue.Value = jv;
                dt.Tips.Value = tips;
                return _DataServer.SaveResult(dt) ? dt : null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 插入汽油车限值记录
        /// </summary>
        /// <param name="st"></param>
        /// <param name="NO"></param>
        /// <param name="CO"></param>
        /// <param name="HC"></param>
        /// <param name="tips"></param>
        /// <returns></returns>
        public object InsertGasolineLimiting(DateTime st,string NO,string CO,string HC,string tips)
        {
            try
            {
                if (_DataServer == null) return null;
                DTGasolineLimitingInfo dt = new DTGasolineLimitingInfo();
                dt.StartTime.Value = st;
                dt.NOLimiting.Value = NO;
                dt.COLimiting.Value = CO;
                dt.HCLimiting.Value = HC;
                dt.Tips.Value = tips;
                return _DataServer.SaveResult(dt) ? dt : null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 插入其他参数
        /// </summary>
        /// <param name="auto"></param>
        /// <param name="model"></param>
        /// <param name="num"></param>
        /// <param name="name"></param>
        /// <param name="lg"></param>
        /// <param name="lt"></param>
        /// <param name="high"></param>
        /// <param name="slo"></param>
        /// <param name="add"></param>
        /// <param name="tips"></param>
        /// <returns></returns>
        public object InsertOtherParam(string auto, string model, string num, string name, string lg, string lt, string high, string slo, string add, string tips,int type)
        {
            try
            {
                if (_DataServer == null) return null;
                DTOtherParamInfo dt = new DTOtherParamInfo();
                if (auto != "") dt.AddToAutoStart.Value = auto;
                if (model != "") dt.RunningModel.Value = model;
                if (num != "") dt.StationNumber.Value = num;
                if (name != "") dt.Name.Value = name;
                if (lg != "") dt.Longitude.Value = lg;
                if (lt != "") dt.Latitude.Value = lt;
                if (high != "") dt.Highly.Value = high;
                if (slo != "") dt.Slope.Value = slo;
                if (add != "") dt.DetialedAddress.Value = add;
                if (tips != "") dt.Tips.Value = tips;
                if (type != -1) dt.StationType.Value = type;
                return _DataServer.SaveResult(dt) ? dt : null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 修改其他参数
        /// </summary>
        /// <param name="auto"></param>
        /// <param name="model"></param>
        /// <param name="num"></param>
        /// <param name="name"></param>
        /// <param name="lg"></param>
        /// <param name="lt"></param>
        /// <param name="high"></param>
        /// <param name="slo"></param>
        /// <param name="add"></param>
        /// <param name="tips"></param>
        /// <returns></returns>
        public object ChangeOtherParam(string auto, string model, string num, string name, string lg, string lt, string high, string slo, string add, string tips,int type)
        {
            try
            {
                if (_DataServer == null) return null;
                DTOtherParamInfo dt = new DTOtherParamInfo();
                DTOtherParamInfo dt2 = new DTOtherParamInfo();
                if (auto != null) dt.AddToAutoStart.Value = auto;
                if (model != null) dt.RunningModel.Value = model;
                if (num != null) dt.StationNumber.Value = num;
                if (name != null) dt.Name.Value = name;
                if (lg != null) dt.Longitude.Value = lg;
                if (lt != null) dt.Latitude.Value = lt;
                if (high != null) dt.Highly.Value = high;
                if (slo != null) dt.Slope.Value = slo;
                if (add != null) dt.DetialedAddress.Value = add;
                if (tips != null) dt.Tips.Value = tips;
                if (type != -1) dt.StationType.Value = type;
                dt2.ID.Value = 0;
                dt2.ID.RelationalOptor = WYDBC.Relational.Greater;
                return _DataServer.UpdateResult(dt, dt2) ? dt : null;
            }
            catch
            {
                return null;
            }
        }
        public object ChangeUserInfo(string name,string pm,string stt,string pwd,string oldpwd)
        {
            try
            {
                if (_DataServer == null) return null;
                DTUserInfo dt1 = new DTUserInfo();
                DTUserInfo dt2 = new DTUserInfo();
                if (pm != "") dt1.Permission.Value = pm;
                if (stt != "") dt1.Statue.Value = stt;
                dt1.Password.Value = pwd;
                if (name != null) dt2.UserName.Value = name;
                if (oldpwd != null) dt2.Password.Value = oldpwd;
                object rs = _DataServer.GetResult(dt2);
                if (rs == null) return false;
                return _DataServer.UpdateResult(dt1, dt2) ? dt1 : null;
            }
            catch
            {
                return null;
            }
        }
        public object DeleteUserInfo(string name/*,string pm = "", string stt = "", string pwd = ""*/)
        {
            try
            {
                if (_DataServer == null) return null;
                DTUserInfo dt = new DTUserInfo();
                dt.UserName.Value = name;
                dt.UserName.RelationalOptor = WYDBC.Relational.Equals;
                //if (pm != "") dt.Permission.Value = pm;
                //if (stt != "") dt.Statue.Value = stt;
                //if (pwd != "") dt.Password.Value = pwd;
                return _DataServer.DeleteResult(dt);
            }
            catch
            {
                return null;
            }
        }
        //查询图表数据
        public string QueryFileInfo(string Filename)
        {
            try
            {
                if (_DataServer == null) return null;
                string rs = _DataServer.ReadFile(Filename);
                object o = JsonNewtonsoft.FromJSON(rs);
                return rs;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region public 
        /// <summary>
        /// 查询系统日志的结果
        /// </summary>
        /// <param name="sd">开始时间</param>
        /// <param name="ed">结束时间</param>
        /// <param name="UserName">用户名</param>
        /// <param name="LogContent">日志内容</param>
        /// <returns></returns>
        public ArrayList QuerySystemLog(DateTime sd, DateTime ed, string UserName, string LogContent)
        {
            try
            {
                if (_DataServer == null) return null;
                DTSystemLogInfo dtSys = new DTSystemLogInfo();
                dtSys.LogTime.Value = sd.ToString("yyyy-MM-dd HH:mm:ss");
                dtSys.LogTime.Value2 = ed.ToString("yyyy-MM-dd HH:mm:ss");
                dtSys.LogTime.RelationalOptor = WYDBC.Relational.Between;
                dtSys.LogTime.Orderby = 2;
                if (UserName != "")
                {
                    dtSys.UserName.Value = UserName;
                    dtSys.UserName.RelationalOptor = WYDBC.Relational.Like;
                }
                if (LogContent != "")
                {
                    dtSys.LogContent.Value = LogContent;
                    dtSys.LogContent.RelationalOptor = WYDBC.Relational.Like;
                }
                ArrayList rs = _DataServer.GetResult(dtSys);
                return rs;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 查询运行日志的结果
        /// </summary>
        /// <param name="sd">开始时间</param>
        /// <param name="ed">结束时间</param>
        /// <param name="LogContent">日志内容</param>
        /// <returns></returns>
        public ArrayList QueryRunningLog(DateTime sd, DateTime ed, string LogContent)
        {
            try
            {
                if (_DataServer == null) return null;
                DTRunningLogInfo dtrun = new DTRunningLogInfo();
                dtrun.LogTime.Value = sd.ToString("yyyy-MM-dd HH:mm:ss");
                dtrun.LogTime.Value2 = ed.ToString("yyyy-MM-dd HH:mm:ss");
                dtrun.LogTime.RelationalOptor = WYDBC.Relational.Between;
                dtrun.LogTime.Orderby = 2;
                if (LogContent != "")
                {
                    dtrun.LogContent.Value = LogContent;
                    dtrun.LogContent.RelationalOptor = WYDBC.Relational.Like;
                }
                ArrayList rs = _DataServer.GetResult(dtrun);
                return rs;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 查询后台日志的结果
        /// </summary>
        /// <param name="sd">开始时间</param>
        /// <param name="ed">结束时间</param>
        /// <param name="LogType">日志类型</param>
        /// <param name="LogContent">日志内容</param>
        /// <returns></returns>
        public ArrayList QueryBackgroundLog(DateTime sd, DateTime ed, string LogType, string LogContent)
        {
            try
            {
                if (_DataServer == null) return null;
                DTBackgroundLogInfo dtBack = new DTBackgroundLogInfo();
                dtBack.LogTime.Value = sd.ToString("yyyy-MM-dd HH:mm:ss");
                dtBack.LogTime.Value2 = ed.ToString("yyyy-MM-dd HH:mm:ss");
                dtBack.LogTime.RelationalOptor = WYDBC.Relational.Between;
                dtBack.LogTime.Orderby = 2;
                if (LogType != "") dtBack.LogType.Value = LogType;
                if (LogContent != "")
                {
                    dtBack.LogContent.Value = LogContent;
                    dtBack.LogContent.RelationalOptor = WYDBC.Relational.Like;
                }
                ArrayList rs = _DataServer.GetResult(dtBack);
                return rs;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 插入日志
        /// </summary>
        /// <param name="logtime"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public object InsertRunningLog(DateTime logtime, string content)
        {
            try
            {
                if (_DataServer == null) return null;
                DTRunningLogInfo dt = new DTRunningLogInfo();
                dt.LogTime.Value = logtime;
                dt.LogContent.Value = content;
                return _DataServer.SaveResult(dt) ? dt : null;
            }
            catch
            {
                return null;
            }
        }
        public object InsertSystemLog(DateTime logtime, string content, string username)
        {
            try
            {
                if (_DataServer == null) return null;
                DTSystemLogInfo dt = new DTSystemLogInfo();
                dt.LogTime.Value = logtime;
                dt.LogContent.Value = content;
                dt.UserName.Value = username;
                return _DataServer.SaveResult(dt) ? dt : null;
            }
            catch
            {
                return null;
            }
        }
        public object InsertBackgroundLog(DateTime logtime, string content, int type, string other = "")
        {
            try
            {
                if (_DataServer == null) return null;
                DTBackgroundLogInfo dt = new DTBackgroundLogInfo();
                dt.LogTime.Value = logtime;
                dt.LogContent.Value = content;
                dt.LogType.Value = type;
                return _DataServer.SaveResult(dt) ? dt : null;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 只适用于超级管理员的动态密码登录
        /// </summary>
        /// <param name="name">超级管理员用户名</param>
        /// <param name="password">超级管理员密码</param>
        /// <returns></returns>
        public ArrayList ManagerLogin(string name,string password)
        {
            ArrayList rs = new ArrayList();
            if (name == null || password == null || name.Trim() == "" || password.Trim() == "")
            {
                //用户名或密码为空
                rs.Add(false);
                rs.Add((int)enumErrorType.UserNameOrPasswordError);
                return rs;
            }
            if (SOAClient.Instance == null)
            {
                //soa连接失败
                rs.Add(false);
                rs.Add((int)enumErrorType.SOAClientConnectionFail);
                return rs;
            }
            _LoginServer = SOAClient.Instance.GetService<IUserManagerServer>();
            if (_LoginServer == null)
            {
                //登录服务连接失败
                rs.Add(false);
                rs.Add((int)enumErrorType.LoginServerConnectionFail);
                return rs;
            }
            Response response = _LoginServer.Login(name, password);
            if (response==null||!response.IsSuccess)
            {
                //用户名或密码错误
                rs.Add(false);
                rs.Add((int)enumErrorType.UserNameOrPasswordError);
                return rs;
            }
            rs.Add(true);
            return rs;
        }
        #endregion
        public ArrayList QueryUserAndPwd(string userName,string Password="")
        {
            if (_DataServer == null&&SOAClient.Instance!=null)
            {
                SOAClient.Instance.LoadServices();
                _DataServer = SOAClient.Instance.GetService<IDataServer>();
            }
            if (_DataServer == null) return null;
            DTUserInfo dt = new DTUserInfo();
            dt.UserName.Value = userName;
            if(Password!="")dt.Password.Value = Password;
            ArrayList rs= _DataServer.GetResult(dt);
            if (rs == null) return null; 
            ArrayList list = new ArrayList();
            for (int i = 0; i < rs.Count; i++)
            {
                if ((rs[i] as DTUserInfo).UserName.Value.ToString().Equals(userName))
                {
                    if (Password == "")
                    {
                        list.Add(rs[i]);
                        continue;
                    }
                    if((rs[i] as DTUserInfo).Password.Value.ToString().Equals(Password)) list.Add(rs[i]);
                }
            }
            return list;
        }
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool BackUpDataBase(string filePath)
        {
            bool rs = false;
            rs = _DataServer.BackupDatabase(filePath);
            return rs;
        }
        /// <summary>
        /// 还原数据库
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool RestoreDataBase(string filePath)
        {
            bool rs = false;
            rs = _DataServer.RestoreBackup(filePath);
            return rs;
        }
        /// <summary>
        /// 查询通讯信息
        /// </summary>
        /// <param name="comName"></param>
        /// <returns></returns>
        public ArrayList QueryComInfo(string comName=null)
        {
            DTCommunicationInfo dt = new DTCommunicationInfo();
            if (comName != null) dt.Name.Value = comName;
            dt.ID.Orderby = 1;
            ArrayList rs = _DataServer.GetResult(dt);
            return rs;
        }
        public bool NewComInfo(string comName, string ComType)
        {
            DTCommunicationInfo dt = new DTCommunicationInfo();
            if (comName != null) dt.Name.Value = comName;
            if (ComType != null) dt.ComType.Value = ComType;
            bool rs = _DataServer.SaveResult(dt);
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
        /// 查询组分范围信息
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryComponentRangeInfo()
        {
            DTMonitingComponentRange dt = new DTMonitingComponentRange();
            ArrayList rs = _DataServer.GetResult(dt);
            return rs;
        }

        //public bool ChangeComponentRange(ArrayList dt)
        //{
        //    if (dt == null) return false;
        //    DTMonitingComponentRange dtRange = new DTMonitingComponentRange();
        //    DTMonitingComponentRange dtCond = new DTMonitingComponentRange();
        //    for (int i = 0; i < dt.Count; i++)
        //    {
        //        if( !(dt[i] is ComponentRange)) continue;
        //        dtRange.ID.Value = i + 1;
        //        dtCond.LowerLimit.Value = (dt[i] as ComponentRange).LowerLimit;
        //        dtCond.UpperLimit.Value = (dt[i] as ComponentRange).UpperLimit;
        //        bool rs= _DataServer.UpdateResult(dtCond,dtRange);
        //        if (!rs) return false;
        //    }
        //    return true;
        //}

        private string CreateDtVehicle(DTVehicleInfo vehicleInfo, string number = "", int lane =0, int fuel = -1, int SortOrder = 0,int SortFactor = -1)
        {
            if (vehicleInfo == null) vehicleInfo = new DTVehicleInfo();
            object field = null;
            PropertyInfo[] property = vehicleInfo.GetType().GetProperties();
            if (number != "")
            {
                vehicleInfo.CarNumber.Value = number;
                vehicleInfo.CarNumber.RelationalOptor = WYDBC.Relational.Like;
            }
            property = vehicleInfo.GetType().GetProperties();
            foreach (PropertyInfo pinf in property)
            {
                field = pinf.GetValue(vehicleInfo);
                if (field != null && field is FieldAttribute) (field as FieldAttribute).IsSelectField = true;
            }
            vehicleInfo.ID.IsSelectField = false;
            vehicleInfo.UniqueKey.IsSelectField = false;
            if (lane !=0)
            {
                vehicleInfo.Lane.Value = lane;
            }
            if (fuel != 0)
            {
                if (fuel == 1) vehicleInfo.CarType.Value = "A";
                else if (fuel == 2) vehicleInfo.CarType.Value = "B";
                else if (fuel == 3) vehicleInfo.CarType.Value = "Z";
                vehicleInfo.CarType.RelationalOptor = WYDBC.Relational.Like;
            }
            string filedName = "";
            if (SortFactor > 6 && SortOrder != 0)
            {
                SetSortCondition(vehicleInfo, SortFactor, SortOrder, out filedName);
            }
            return filedName;
        }
    }
}
