using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wayeal.os.exhaust.DAL.SqlHelp
{
   public class SqlConnect
    {
      
        public  SqlSugarClient GetInstance()
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
