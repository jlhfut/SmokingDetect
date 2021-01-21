using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.DAL.IDAL
{
    interface IVehicleDAL
    {
        /// <summary>
        /// 添加设备信息
        /// </summary>
        /// <param name="vehicle">实体类</param>
        /// <returns>返回0表示添加失败</returns>
        int AddVehicle(Vehicle vehicle);

        int GetTotal();

        /// <summary>
        /// 得到一条车辆的信息
        /// </summary>
        /// <returns></returns>
      Vehicle GetVehicle();

        /// <summary>
        /// 获取指定条数的车辆信息
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
       DataTable GetVehicles(int count);

        /// <summary>
        /// 获得不同林格曼黑度下车辆数量
        /// </summary>
        /// <returns></returns>
        DataTable GetSumVehicles();
        /// <summary>
        /// 查询所有设备信息
        /// </summary>
        /// <returns></returns>
        DataTable SelectAllVehicle();

        /// <summary>
        /// 根据ID查找车辆
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Vehicle SelectVehicleById(int id);

        /// <summary>
        /// 根据时间段查询林格曼统计信息
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name=""></param>
        /// <returns></returns>
        DataTable GetVehicleByDateTime(DateTime startTime,DateTime endTime);


       /// <summary>
       /// 分页操作
       /// </summary>
       /// <param name="startTime">开始时间</param>
       /// <param name="endTime">结束时间</param>
       /// <param name="vNo">车牌号</param>
       /// <param name="vColor">车身颜色</param>
       /// <param name="vRingeman">林格曼系数</param>
       /// <param name="pageIndex">页索引</param>
       /// <param name="pageSize">美颜显示多少条</param>
       /// <param name=""></param>
       /// <returns></returns>
        DataTable GetVehiclesByMulCondition(DateTime startTime, DateTime endTime, string vNo, string vColor, int? vRingeman, int pageIndex, int pageSize, ref int totalPage);
       
    }
}
