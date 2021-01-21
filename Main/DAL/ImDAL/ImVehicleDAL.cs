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
 public   class ImVehicleDAL : IVehicleDAL
    {
        //获取数据库连接
        SqlSugarClient db = new SqlConnect().GetInstance();

        DataTable IVehicleDAL.GetSumVehicles()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("daySum", typeof(System.Int32));
            DataColumn dc2 = new DataColumn("totalSum", typeof(System.Int32));
            dt.Columns.Add(dc);
            dt.Columns.Add(dc2);

            //Initialize the row

            DataTable dataTable = GetSumCar();
            DataTable dataTable2 = getDaySumCar();

            int maxCount;

            if (dataTable.Rows.Count > dataTable2.Rows.Count)
            {
                maxCount = dataTable.Rows.Count;
            }
            else
            {
                maxCount = dataTable2.Rows.Count;
            }

            for (int i = 0; i < maxCount; i++)
            {
                DataRow dr = dt.NewRow();


                dr["totalSum"] = dataTable.Rows[i][1];
                if (i < 2)
                {
                    dr["daySum"] = dataTable2.Rows[i][0];
                }
                else
                {
                    dr["daySum"] = 0;
                }

                dt.Rows.Add(dr);


            }
            return dt;
        }

        Vehicle IVehicleDAL.GetVehicle()
        {
            int index= db.Queryable<Vehicle>().Sum(it => it.vid);
            return db.Queryable<Vehicle>().First(it => it.vid == 1);//查询单条
        }
       
        DataTable IVehicleDAL.GetVehicles(int count)
        {
          return db.Queryable<Vehicle>().Take(5).ToDataTable();//查询前n条资料
        }


        //辅助部分
        /// <summary>
        /// 得到总车辆数   不同林格曼系数下
        /// </summary>
        /// <returns></returns>
        private DataTable GetSumCar()
        {
            
            var dt = db.Ado.GetDataTable("select vehicle.vringelman,   count ('vringelma' )   as   sumCar  from vehicle group by vringelman ");
            return dt;
        }

        /// <summary>
        /// 当日车辆数   不同林格曼系数下
        /// </summary>
        /// <returns></returns>
        private DataTable getDaySumCar()
        {
          
            var dt = db.Ado.GetDataTable(" select vehicle.vringelman,  count ('vringelma' )   as   daysumCar from vehicle where vcheckdate='2020-12-26' group by vringelman ,vcheckdate");
            return dt;
        }

        DataTable IVehicleDAL.SelectAllVehicle()
        {
            return db.Queryable<Vehicle>().ToDataTable();//查询所有
        }

        Vehicle IVehicleDAL.SelectVehicleById(int id)
        {
            return db.Queryable<Vehicle>().First(it => it.vid == id);//查询单条
        }

        int IVehicleDAL.GetTotal()
        {
            return db.Queryable<Vehicle>().Count();
        }


        /// <summary>
        /// 根据时间段统计林格曼黑度信息
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name=""></param>
        /// <returns></returns>
        DataTable IVehicleDAL.GetVehicleByDateTime(DateTime startTime, DateTime dateTime)
        {
           return  db.Ado.GetDataTable("  select vringelman, count(vheadimage) 'count' from vehicle where vcheckdate >= @startT and vcheckdate<= @endT group by vringelman",new List<SugarParameter>(){
                new SugarParameter("@startT",startTime),
               new SugarParameter("@endT", dateTime),
            });
           

           

        }


        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="vNo"></param>
        /// <param name="vColor"></param>
        /// <param name="vRingeman"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalPage"></param>
        /// <returns></returns>
        DataTable IVehicleDAL.GetVehiclesByMulCondition(DateTime startTime, DateTime endTime, string vNo, string vColor, int? vRingeman ,int pageIndex,int pageSize,ref int totalPage)
        {
            string d = startTime.ToString();//"2020 - 12 - 25";//startTime.ToString();
            string e = endTime.ToString();//"2020 - 12 - 25";
            

           
            return db.Queryable<Vehicle>()
               .WhereIF(string.IsNullOrEmpty(d), it => it.vcheckdate <= startTime)  //开始时间
               .WhereIF(string.IsNullOrEmpty(e), it => it.vcheckdate >= endTime)   //结束时间
              .WhereIF(!string.IsNullOrEmpty(vColor), it => it.vcolor == vColor)  //车身颜色
               .WhereIF(!string.IsNullOrEmpty(vNo), it => it.vno.Contains(vNo))//车牌号码
           .WhereIF(!string.IsNullOrEmpty(Convert.ToString(vRingeman)), it => it.vringelman == vRingeman).ToDataTablePage(pageIndex, pageSize, ref totalPage);  //分页后的table

        }



        /// <summary>
        /// 添加车辆信息
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>返回收影响的行数</returns>
        int IVehicleDAL.AddVehicle(Vehicle vehicle)
        {
           return db.Insertable(vehicle).ExecuteCommand();
        }
    }
}
