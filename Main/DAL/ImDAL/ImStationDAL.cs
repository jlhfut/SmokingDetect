using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.DAL.IDAL;
using wayeal.os.exhaust.DAL.SqlHelp;
using wayeal.os.exhaust.Models;


namespace wayeal.os.exhaust.DAL.ImDAL
{
   
    public class ImStationDAL : IStationDAL
    {

        SqlSugarClient db = GetInstance();
        /// <summary>
        /// 添加站点信息
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        bool IStationDAL.AddStation(StationList station)
        {
         int isbool=
            db.Insertable(station).ExecuteCommand();
            if (isbool > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public static SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Server=DESKTOP-T2M881V\\MSQL;uid=sa;pwd=root;database=smokingdb",//连接符字串
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute//从特性读取主键自增信息
            });


            return db;
        }
    }
    
}
