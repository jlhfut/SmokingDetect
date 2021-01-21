using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.DAL.IDAL;
using wayeal.os.exhaust.DAL.ImDAL;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.BAL.ImBAL
{
    public class ImStationBAL : IStationBAL
    {
        IStationDAL stationDal = new ImStationDAL();


        /// <summary>
        /// 添加站点信息
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        bool IStationBAL.AddStation(StationList station)
        {
           return stationDal.AddStation(station);
        }
    }
}
