using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wayeal.plugin
{
    public class LogManagerViewModel : PluginBase
    {
        /// <summary>
        /// QueryXXXLog:查总页数+分页
        /// QueryXXXLogPage:查分页
        /// </summary>
        public enum ExecuteCommand
        {
            ec_QuerySystemLog,
            ec_QuerySystemLogPage,
            ec_QueryRunningLog,
            ec_QueryRunningLogPage,
            ec_QueryBackgroundLog,
            ec_QueryBackgroundLogPage,

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
        private static LogManagerViewModel _VM = new LogManagerViewModel();
        public static LogManagerViewModel VM
        {
            get { return _VM; }
        }
        public event ModelEventHandler ModelChanged;

        /// <summary>
        /// 系统日志总页面个数
        /// </summary>
        public int SystemTotalPage { get; private set; }

        /// <summary>
        /// 运行日志总页面个数
        /// </summary>
        public int RunningTotalPage { get; private set; }

        /// <summary>
        /// 后台日志总页面个数
        /// </summary>
        public int BackgroundTotalPage { get; private set; }

        /// <summary>
        /// 系统日志总条数
        /// </summary>
        public int SystemTotalCount { get; private set; }

        /// <summary>
        /// 运行日志总条数
        /// </summary>
        public int RunningTotalCount { get; private set; }

        /// <summary>
        /// 后台日志总条数
        /// </summary>
        public int BackgroundTotalCount { get; private set; }


        private ArrayList _SystemLogEntities = new ArrayList();
        /// <summary>
        /// 系统日志结果集模型
        /// </summary>
        public ArrayList SystemLogEntities { get { return _SystemLogEntities; } private set { _SystemLogEntities = value; } }

        private ArrayList _RunningLogEntities = new ArrayList();
        /// <summary>
        /// 运行日志结果集模型
        /// </summary>
        public ArrayList RunningLogEntities { get { return _RunningLogEntities; } private set { _RunningLogEntities = value; } }

        private ArrayList _BackgroundLogEntities = new ArrayList();
        /// <summary>
        /// 背景日志结果集模型
        /// </summary>
        public ArrayList BackgroundLogEntities { get { return _BackgroundLogEntities; } private set { _BackgroundLogEntities = value; } }

        private bool _InsertLogEntities = false;
        /// <summary>
        /// 插入日志结果集模型
        /// </summary>
        public bool InsertLogEntities { get { return _InsertLogEntities; } private set { _InsertLogEntities = value; } }

        /// <summary>
        /// 绑定到视图中的函数表
        /// </summary>
        public LogManagerViewModel()
        {
        }

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
                    case ExecuteCommand.ec_QuerySystemLog: QuerySystemLog(args); break;
                    case ExecuteCommand.ec_QuerySystemLogPage: QuerySystemLogPage(args); break;
                    case ExecuteCommand.ec_QueryRunningLog: QueryRunningLog(args); break;
                    case ExecuteCommand.ec_QueryRunningLogPage: QueryRunningLogPage(args); break;
                    case ExecuteCommand.ec_QueryBackgroundLog: QueryBackgroundLog(args); break;
                    case ExecuteCommand.ec_QueryBackgroundLogPage: QueryBackgroundLogPage(args); break;
                }
            }
        }

        /// <summary>
        /// 查询系统日志
        /// </summary>
        /// <param name="args"></param>
        private void QuerySystemLog(List<object> args)
        {
            try
            {
                ArrayList rs = null;
                if (SystemLogEntities != null) SystemLogEntities.Clear();
                if (args.Count >= 2)
                {
                    DateTime s, e;
                    if (!DateTime.TryParse(args[0].ToString(), out s)) return;
                    if (!DateTime.TryParse(args[1].ToString(), out e)) return;

                    int RowCount = LogDataServiceHelper.Instanse.QuerySystemLogCount(s, e, args.Count < 4 ? "" : args[3].ToString(), args.Count < 5 ? "" : args[4].ToString());
                    rs = LogDataServiceHelper.Instanse.QuerySystemLogPage(s, e, 1, Convert.ToInt16(args[2]), args[3].ToString(), args[4].ToString());
                    SystemTotalCount = RowCount;
                    if (RowCount == 0 || rs == null || rs.Count == 0) ;// XtraMessageBox.Show("查询结果为空！");
                    else SystemLogEntities = rs;

                    SystemTotalPage = (int)Math.Ceiling(Convert.ToDouble(RowCount) / Convert.ToDouble(args[2]));
                    if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(LogManagerViewModel).Name));
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void QuerySystemLogPage(List<object> args)
        {
            try
            {
                ArrayList rs = null;
                if (SystemLogEntities != null) SystemLogEntities.Clear();
                if (args.Count >= 2)
                {
                    DateTime s, e;
                    if (!DateTime.TryParse(args[0].ToString(), out s)) return;
                    if (!DateTime.TryParse(args[1].ToString(), out e)) return;

                    rs = LogDataServiceHelper.Instanse.QuerySystemLogPage(s, e, Convert.ToInt16(args[2]), Convert.ToInt16(args[3]), args[4].ToString(), args[5].ToString());
                    SystemLogEntities = rs;
                    int RowCount = LogDataServiceHelper.Instanse.QuerySystemLogCount(s, e, args.Count < 5 ? "" : args[4].ToString(), args.Count < 6 ? "" : args[5].ToString());
                    SystemTotalPage = (int)Math.Ceiling(Convert.ToDouble(RowCount) / Convert.ToDouble(args[3]));
                    if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(LogManagerViewModel).Name));
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 查询运行日志
        /// </summary>
        /// <param name="args"></param>
        private void QueryRunningLog(List<object> args)
        {
            try
            {
                ArrayList rs = null;
                if (RunningLogEntities != null) RunningLogEntities.Clear();
                if (args.Count >= 2)
                {
                    DateTime s, e;
                    if (!DateTime.TryParse(args[0].ToString(), out s)) return;
                    if (!DateTime.TryParse(args[1].ToString(), out e)) return;

                    int RowCount = LogDataServiceHelper.Instanse.QueryRunningLogCount(s, e, args.Count < 4 ? "" : args[3].ToString());
                    rs = LogDataServiceHelper.Instanse.QueryRunningLogPage(s, e, 1, Convert.ToInt16(args[2]), args[3].ToString());
                    RunningTotalCount = RowCount;
                    if (RowCount == 0 || rs == null || rs.Count == 0) ;//XtraMessageBox.Show("查询结果为空！");
                    else RunningLogEntities = rs;

                    RunningTotalPage = (int)Math.Ceiling(Convert.ToDouble(RowCount) / Convert.ToDouble(args[2]));
                    if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(LogManagerViewModel).Name));
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 查询运行日志
        /// </summary>
        /// <param name="args"></param>
        private void QueryRunningLogPage(List<object> args)
        {
            try
            {

                ArrayList rs = null;
                if (RunningLogEntities != null) RunningLogEntities.Clear();
                if (args.Count >= 2)
                {
                    DateTime s, e;
                    if (!DateTime.TryParse(args[0].ToString(), out s)) return;
                    if (!DateTime.TryParse(args[1].ToString(), out e)) return;

                    rs = LogDataServiceHelper.Instanse.QueryRunningLogPage(s, e, Convert.ToInt16(args[2]), Convert.ToInt16(args[3]), args[4].ToString());
                    RunningLogEntities = rs;

                    if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(LogManagerViewModel).Name));
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 查询后台日志
        /// </summary>
        /// <param name="args"></param>
        private void QueryBackgroundLog(List<object> args)
        {
            try
            {
                ArrayList rs = null;
                if (BackgroundLogEntities != null) BackgroundLogEntities.Clear();
                if (args.Count >= 2)
                {
                    DateTime s, e;
                    if (!DateTime.TryParse(args[0].ToString(), out s)) return;
                    if (!DateTime.TryParse(args[1].ToString(), out e)) return;
                    int RowCount = LogDataServiceHelper.Instanse.QueryBackgroundLogCount(s, e, args.Count < 4 ? "" : args[3].ToString(), args.Count < 5 ? "" : args[4].ToString());
                    rs = LogDataServiceHelper.Instanse.QueryBackgroundLogPage(s, e, 1, Convert.ToInt16(args[2]), args[3].ToString(), args[4].ToString());
                    BackgroundTotalCount = RowCount;
                    if (RowCount == 0 || rs == null || rs.Count == 0) ;// XtraMessageBox.Show("查询结果为空！");
                    else BackgroundLogEntities = rs;
                    BackgroundTotalPage = (int)Math.Ceiling(Convert.ToDouble(RowCount) / Convert.ToDouble(args[2]));
                    if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(LogManagerViewModel).Name));

                }
            }
            catch (Exception ex)
            {

            }
           
        }

        /// <summary>
        /// 查询后台日志
        /// </summary>
        /// <param name="args"></param>
        private void QueryBackgroundLogPage(List<object> args)
        {
            try
            {
                ArrayList rs = null;
                if (BackgroundLogEntities != null) BackgroundLogEntities.Clear();
                if (args.Count >= 2)
                {
                    DateTime s, e;
                    if (!DateTime.TryParse(args[0].ToString(), out s)) return;
                    if (!DateTime.TryParse(args[1].ToString(), out e)) return;
                    rs = LogDataServiceHelper.Instanse.QueryBackgroundLogPage(s, e, Convert.ToInt16(args[2]), Convert.ToInt16(args[3]), args[4].ToString(), args[5].ToString());
                    BackgroundLogEntities = rs;
                    int RowCount = LogDataServiceHelper.Instanse.QueryBackgroundLogCount(s, e, args.Count < 5 ? "" : args[4].ToString(), args.Count < 6 ? "" : args[5].ToString());
                    BackgroundTotalPage = (int)Math.Ceiling(Convert.ToDouble(RowCount) / Convert.ToDouble(args[3]));
                    if (ModelChanged != null) ModelChanged(this, new ModelEventArgs(typeof(LogManagerViewModel).Name));

                }
            }
            catch (Exception ex)
            {

            }
            
        }

    }
}
