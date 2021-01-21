using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.BAL.IBAL
{
   public interface IStationBAL
    {
        /// <summary>
        /// 添加站点信息
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        bool AddStation(StationList station);
    }
}
