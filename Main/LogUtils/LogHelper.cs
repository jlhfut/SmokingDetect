using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace wayeal.os.exhaust.LogUtils
{
   public class LogHelper
    {
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");//这里的 loginfo 和 log4net.config 里的名字要一样
        //public static readonly log4net.ILog loginfoDb = log4net.LogManager.GetLogger("loginfoDb");//这里的 loginfoDb 和 log4net.config 里的名字要一样

        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");//这里的 logerror 和 log4net.config 里的名字要一样

        public static void WriteLog(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        public static void WriteLog(string info, Exception ex)
        {
            if (logerror.IsErrorEnabled)
            {
                Task.Run(() => logerror.Error(info, ex));   //异步
                //Task.Factory.StartNew(() => logerror.Error(info, ex));//  这种异步也可以
            }
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info, ex);//同步处理
            }
            //if (loginfoDb.IsInfoEnabled)
            //{
            //    loginfoDb.Info(info, ex);
            //}
            //loginfo.Debug("开始调试");
            //loginfo.Info("这是一个消息");
            //loginfo.Warn("这是一个警告");
            //loginfo.Error("Error", new Exception("这是一个异常"));
        }

        /// <summary>
        /// 日志记录助手
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="ex"></param>
        public static void LogUtlis(string className, Exception ex)
        {
            log4net.ILog loginfoDb = LogFactory.GetLogger(className);
            LogHelper.WriteLog(ex.Message.ToString(), ex);
            string tempmsg = ex.Message.ToString() + "/r/n" + ex.Source.ToString() + "/r/n" + ex.TargetSite.ToString() + "/r/n" + ex.StackTrace.ToString();
            if (loginfoDb.IsInfoEnabled)
            {
                Task.Run(() => { loginfoDb.Info(tempmsg, ex); });
            }


        }
    }
    public static class LogFactory
    {
        public const string Log4NetConfig = "log4net.config";

        public static ILog GetLogger(string logger)
        {
            var uri = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), Log4NetConfig));
            var configFile = new FileInfo(Path.GetFullPath(uri.LocalPath));
            XmlConfigurator.ConfigureAndWatch(configFile);
            ILog log = LogManager.GetLogger(logger);
            return log;
        }
    }



    }

