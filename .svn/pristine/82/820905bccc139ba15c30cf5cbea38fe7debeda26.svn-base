using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Reflection;
using Wayee.Services;
using WYDAO;

namespace wayeal.plugin
{
    public class LogDataServiceHelper: PluginBase
    {
        #region init
        private IDataServer _DataServer = null;
        public LogDataServiceHelper()
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
        private static LogDataServiceHelper _Instanse = null;
        /// <summary>
        /// 获取数据服务
        /// </summary>
        public static LogDataServiceHelper Instanse
        {
            get
            {
                if (_Instanse == null)
                    _Instanse = new LogDataServiceHelper();
                return _Instanse;
            }
        }
        #endregion

        #region public 
        /// <summary>
        /// 查询系统日志总记录数
        /// </summary>
        /// <param name="sd">开始时间</param>
        /// <param name="ed">结束时间</param>
        /// <param name="UserName">用户名</param>
        /// <param name="LogContent">日志内容</param>
        /// <returns></returns>
        public int QuerySystemLogCount(DateTime sd, DateTime ed,string UserName,string LogContent)
        {
            if (_DataServer == null) return 0;
            DTSystemLogInfo dtSys = new DTSystemLogInfo();
            dtSys.LogTime.Value = sd.ToString("yyyy-MM-dd HH:mm:ss");
            dtSys.LogTime.Value2 = ed.ToString("yyyy-MM-dd HH:mm:ss");
            dtSys.LogTime.RelationalOptor = WYDBC.Relational.Between;
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
                int rs = _DataServer.GetRowCount(dtSys);
            return rs;
        }

        /// <summary>
        /// 分页查询系统日志
        /// </summary>
        /// <param name="sd">开始时间</param>
        /// <param name="ed">结束时间</param>
        /// <param name="UserName">用户名</param>
        /// <param name="LogContent">日志内容</param>
        /// <returns></returns>
        public ArrayList QuerySystemLogPage(DateTime sd, DateTime ed, int pagenumber, int pagesize, string UserName, string LogContent)
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
            //,dtSys.ID.FieldName
            ArrayList rs = _DataServer.GetResult(dtSys, dtSys.LogTime.FieldName, pagenumber,pagesize);
            return rs;
        }


        /// <summary>
        /// 查询系统日志的结果
        /// </summary>
        public ArrayList QuerySystemLog()
        {
            if (_DataServer == null) return null;
            DTSystemLogInfo dtSys = new DTSystemLogInfo();
            dtSys.LogTime.Orderby = 2;
            ArrayList rs = _DataServer.GetResult(dtSys);
            return rs;
        }

        /// <summary>
        /// 查询运行日志的结果
        /// </summary>
        /// <param name="sd">开始时间</param>
        /// <param name="ed">结束时间</param>
        /// <param name="LogContent">日志内容</param>
        /// <returns></returns>
        public int QueryRunningLogCount(DateTime sd, DateTime ed, string LogContent)
        {
            if (_DataServer == null) return 0;
            DTRunningLogInfo dtrun = new DTRunningLogInfo();
            dtrun.LogTime.Value = sd.ToString("yyyy-MM-dd HH:mm:ss");
            dtrun.LogTime.Value2 = ed.ToString("yyyy-MM-dd HH:mm:ss");
            dtrun.LogTime.RelationalOptor = WYDBC.Relational.Between;
            if (LogContent != "")
            {
                dtrun.LogContent.Value = LogContent;
                dtrun.LogContent.RelationalOptor = WYDBC.Relational.Like;
            }
                int rs = _DataServer.GetRowCount(dtrun);
            return rs;
        }

        /// <summary>
        /// 分页查询运行日志的结果
        /// </summary>
        /// <param name="sd">开始时间</param>
        /// <param name="ed">结束时间</param>
        /// <param name="LogContent">日志内容</param>
        /// <returns></returns>
        public ArrayList QueryRunningLogPage(DateTime sd, DateTime ed, int pagenumber, int pagesize, string LogContent)
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
            ArrayList rs = _DataServer.GetResult( dtrun,dtrun.LogTime.FieldName, pagenumber, pagesize);
            return rs;
        }

        /// <summary>
        /// 查询运行日志结果
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryRunningLog()
        {
            if (_DataServer == null) return null;
            DTRunningLogInfo dtrun = new DTRunningLogInfo();
            dtrun.LogTime.Orderby = 2;
            ArrayList rs = _DataServer.GetResult(dtrun);
            return rs;
        }

        /// <summary>
        /// 查询后台日志的结果
        /// </summary>
        /// <param name="sd">开始时间</param>
        /// <param name="ed">结束时间</param>
        /// <param name="LogType">日志类型</param>
        /// <param name="LogContent">日志内容</param>
        /// <returns></returns>
        public int QueryBackgroundLogCount(DateTime sd, DateTime ed,string LogType, string LogContent)
        {
            if (_DataServer == null) return 0;
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
                
            int rs = _DataServer.GetRowCount(dtBack);
            return rs;
        }

        /// <summary>
        /// 分页查询后台日志
        /// </summary>
        /// <param name="sd">开始时间</param>
        /// <param name="ed">结束时间</param>
        /// <param name="LogType">日志类型</param>
        /// <param name="LogContent">日志内容</param>
        /// <returns></returns>
        public ArrayList QueryBackgroundLogPage(DateTime sd, DateTime ed, int pagenumber, int pagesize, string LogType, string LogContent)
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

            ArrayList rs = _DataServer.GetResult( dtBack,dtBack.LogTime.FieldName, pagenumber, pagesize);
            return rs;
        }

        /// <summary>
        /// 查询后台日志的结果
        /// </summary>
        /// <returns></returns>
        public ArrayList QueryBackgroundLog()
        {
            if (_DataServer == null) return null;
            DTBackgroundLogInfo dtBack = new DTBackgroundLogInfo();
            dtBack.LogTime.Orderby = 2;
            ArrayList rs = _DataServer.GetResult(dtBack);
            return rs;
        }

        #endregion
    }
}
