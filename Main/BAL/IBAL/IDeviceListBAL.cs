using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.BAL.IBAL
{
    interface IDeviceListBAL
    {

        /// <summary>
        /// 获取所有设备信息
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        DataTable GetAllDeviceInfo(DeviceList device);


        /// <summary>
        /// 获取所有设备信息
        /// </summary>
        /// <returns></returns>
        List<DeviceList> GetAllDeviceInfo( );


        /// <summary>
        /// 根据用户名获取该设备所有信息
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        DeviceList GetAllDeviceInfoByName(DeviceList device);

        /// <summary>
        /// 根据用户名更新设备信息
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        int UpDataByName(DeviceList device);

        /// <summary>
        /// 增加设备
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        int addDevice(DeviceList device);

        /// <summary>
        /// 根据用户名查询设备信息
        /// </summary>
        /// <param name="dname"></param>
        /// <returns></returns>
        DeviceList GetDeviceByName(string dname);

        /// <summary>
        /// 根据用户名删除设备信息
        /// </summary>
        /// <param name="dname"></param>
        /// <returns></returns>
        int DeleteByDName(string dname);
        /// <summary>
        /// 保存用户密码和账号
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        int InsertDNameDPwd(DeviceList device);

    }
}
