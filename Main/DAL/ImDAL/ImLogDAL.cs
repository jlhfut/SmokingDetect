using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.DAL.IDAL;
using wayeal.os.exhaust.DAL.SqlHelp;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.DAL.ImDAL
{
    class ImLogDAL : ILogDAL
    {
        SqlSugarClient db = new SqlConnect().GetInstance();

        /// <summary>
        /// 分页工具  后台日志
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="category"></param>
        /// <param name="content"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageTotal"></param>
        /// <returns></returns>
        public DataTable SelectByTimeCategoryContentPagelist(DateTime startTime, DateTime endTime, string category, string content, int pageIndex, int pageSize, ref int pageTotal)
        {
            string d = startTime.ToString();
            string e = endTime.ToString();
            return db.Queryable<Log>()
            .WhereIF(string.IsNullOrEmpty(d), it => it.Date >= startTime)  //开始时间
             .WhereIF(string.IsNullOrEmpty(e), it => it.Date <= endTime)   //结束时间
               .WhereIF(!string.IsNullOrEmpty(category), it => it.Level == category)  //日志类别
            .WhereIF(!string.IsNullOrEmpty(content), it => it.Message.Contains(content)).ToDataTablePage(pageIndex, pageSize, ref pageTotal);  //日志内容
            
        }

        /// <summary>
        /// 系统日志分页
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="name"></param>
        /// <param name="content"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageTotal"></param>
        /// <returns></returns>
        public DataTable SelectByTimeNameContentPagelist(DateTime startTime, DateTime endTime, string name, string content, int pageIndex, int pageSize, ref int pageTotal)
        {
            string d = startTime.ToString();
            string e = endTime.ToString();
           return db.Queryable<Log>()
            .WhereIF(string.IsNullOrEmpty(d), it => it.Date >= startTime)  //开始时间
             .WhereIF(string.IsNullOrEmpty(e), it => it.Date <= endTime)   //结束时间
               .WhereIF(!string.IsNullOrEmpty(name), it => it.Thread == name)  //用户名
            .WhereIF(!string.IsNullOrEmpty(content), it => it.Message.Contains(content)).ToDataTablePage(pageIndex, pageSize,ref pageTotal); //日志内容
             
        }

        /// <summary>
        /// 查询所有日志记录
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        DataTable ILogDAL.SelectAllLog(Log log)
        {
            return db.Queryable<Log>().ToDataTable();//查询所有
        }

        /// <summary>
        /// 后台日志查询
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="category"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        DataTable ILogDAL.SelectByTimeCategoryContent(DateTime startTime, DateTime endTime, string category, string content)
        {
            string d = startTime.ToString();
            string e = endTime.ToString();
            var list = db.Queryable<Log>()
            .WhereIF(string.IsNullOrEmpty(d), it => it.Date >= startTime)  //开始时间
             .WhereIF(string.IsNullOrEmpty(e), it => it.Date  <= endTime)   //结束时间
               .WhereIF(!string.IsNullOrEmpty(category), it => it.Level == category)  //日志类别
            .WhereIF(!string.IsNullOrEmpty(content), it => it.Message.Contains(content)).ToDataTable();  //日志内容
            return list;
        }


        /// <summary>
        /// 系统日志查询
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="name"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        DataTable ILogDAL.SelectByTimeNameContent(DateTime startTime, DateTime endTime, string name, string content)
        {
          
            string d = startTime.ToString();
            string e = endTime.ToString();
            var list = db.Queryable<Log>()
            .WhereIF(string.IsNullOrEmpty(d), it => it.Date >= startTime)  //开始时间
             .WhereIF(string.IsNullOrEmpty(e), it => it.Date <= endTime)   //结束时间
               .WhereIF(!string.IsNullOrEmpty(name), it => it.Thread==name)  //用户名
            .WhereIF(!string.IsNullOrEmpty(content), it => it.Message.Contains(content)).ToDataTable();  //日志内容
            return list;
        }
    }
}
