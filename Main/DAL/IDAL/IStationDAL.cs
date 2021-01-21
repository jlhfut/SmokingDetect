using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.Models;


namespace wayeal.os.exhaust.DAL.IDAL
{
  public  interface IStationDAL
    {
       
        /// <summary>
        /// 增加站点
        /// </summary>
        /// <param name="station">Station 实例</param>
        /// <returns>添加是否成功</returns>
         bool   AddStation(StationList station);
    }
}
