using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.DAL.IDAL
{
    interface ILogDAL
    {
        /// <summary>
        /// 查询所有日志
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        DataTable SelectAllLog(Log log);

        /// <summary>
        /// 根据时间，用户名，日志内容查询
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="name">用户名</param>
        /// <param name="content">日志内容</param>
        /// <returns></returns>
        DataTable SelectByTimeNameContent(DateTime startTime, DateTime endTime, string name, string content);


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
        DataTable SelectByTimeNameContentPagelist(DateTime startTime, DateTime endTime, string name, string content,int pageIndex,int pageSize,ref int pageTotal);


        /// <summary>
        /// 后台日志查询----
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="category">类别</param>
        /// <param name="content">日志内容</param>
        /// <returns></returns>
        DataTable SelectByTimeCategoryContent(DateTime startTime, DateTime endTime, string category, string content);





        /// <summary>
        /// 后台日志查询分页
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="category">类别</param>
        /// <param name="content">内容</param>
        /// <param name="pageIndex">页面索引</param>
        /// <param name="pageSize">每页存放的条数</param>
        /// <param name="pageTotal">查询结果条数</param>
        /// <returns></returns>
        DataTable SelectByTimeCategoryContentPagelist(DateTime startTime, DateTime endTime, string category, string content,int pageIndex,int pageSize,ref int pageTotal);

    }
}
