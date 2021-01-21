using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.BAL.IBAL
{
    interface ILogBAL
    {
        /// <summary>
        /// 查询所有日志
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        DataTable SelectAllLog(Log log);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="name"></param>
        /// <param name="content"></param>
        /// <returns></returns>

        DataTable SelectByTimeNameContent(DateTime startTime, DateTime endTime, string name, string content);
        /// <summary>
        /// 后台日志查询
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="category">日志类别</param>
        /// <param name="content">日志内容</param>
        /// <returns></returns>

        DataTable SelectByTimeCategoryContent(DateTime startTime, DateTime endTime, string category, string content);


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
        DataTable SelectByTimeNameContentPagelist(DateTime startTime, DateTime endTime, string name, string content, int pageIndex, int pageSize, ref int pageTotal);

        /// <summary>
        /// 后台日志分页查询
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="category"></param>
        /// <param name="content"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageTotal"></param>
        /// <returns></returns>
        DataTable SelectByTimeCategoryContentPagelist(DateTime startTime, DateTime endTime, string category, string content, int pageIndex, int pageSize, ref int pageTotal);
    }
}
