using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.BAL.IBAL
{
    interface IVehicleBAL
    {
        /// <summary>
        /// 得到一条车辆的信息
        /// </summary>
        /// <returns></returns>
        Vehicle GetVehicle();

        /// <summary>
        /// 返回指定条数的车辆记录
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        DataTable GetVehicles(int count);

        /// <summary>
        /// 获得车辆数   ---不同林格曼系数下
        /// </summary>
        /// <returns></returns>
        DataTable GetSumVehicles();
        /// <summary>
        /// 查询所有车辆信息
        /// </summary>
        /// <returns></returns>
        DataTable SelectAllVehicle();

        /// <summary>
        /// 根据Id查询车辆信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Vehicle SelectVehicleById(int id);
        /// <summary>
        /// 获得记录条数
        /// </summary>
        /// <returns></returns>
        int GetTotal();

        /// <summary>
        /// 根据时间段统计林格曼黑度信息
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        DataTable GetVehicleByDateTime(DateTime startTime, DateTime endTime);

        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="vNo">车牌号</param>
        /// <param name="vColor">车身颜色</param>
        /// <param name="vRingeman">林格曼系数</param>
        /// <param name="pageIndex">索引号</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="totalPage">共有多少条</param>
        /// <returns></returns>
        DataTable GetVehiclesByMulCondition(DateTime startTime, DateTime endTime, string vNo, string vColor, int? vRingeman, int pageIndex, int pageSize, ref int totalPage);

        /// <summary>
        /// 添加车辆信息
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        int AddVehicle(Vehicle vehicle);
    }
}
