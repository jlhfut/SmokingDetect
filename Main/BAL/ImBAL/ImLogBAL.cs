using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.DAL.IDAL;
using wayeal.os.exhaust.DAL.ImDAL;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.BAL.ImBAL
{
   
   public class ImLogBAL : ILogBAL
    {
        ILogDAL DAL = new ImLogDAL();
       

        DataTable ILogBAL.SelectAllLog(Log log)
        {
            return DAL.SelectAllLog(log);
        }

        DataTable ILogBAL.SelectByTimeCategoryContent(DateTime startTime, DateTime endTime, string category, string content)
        {
            return DAL.SelectByTimeCategoryContent(startTime, endTime, category, content);
        }

        DataTable ILogBAL.SelectByTimeCategoryContentPagelist(DateTime startTime, DateTime endTime, string category, string content, int pageIndex, int pageSize, ref int pageTotal)
        {
           return DAL.SelectByTimeCategoryContentPagelist(startTime, endTime, category, content, pageIndex, pageSize,ref pageTotal);
        }

        DataTable ILogBAL.SelectByTimeNameContent(DateTime startTime, DateTime endTime, string name, string content)
        {
            return DAL.SelectByTimeNameContent(startTime, endTime, name, content);
        }

        DataTable ILogBAL.SelectByTimeNameContentPagelist(DateTime startTime, DateTime endTime, string name, string content, int pageIndex, int pageSize, ref int pageTotal)
        {
            return DAL.SelectByTimeNameContentPagelist(startTime, endTime, name, content, pageIndex, pageSize,ref pageTotal);
        }
    }
}
