using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.DAL.IDAL
{
    interface IDeviceListDAL
    {

        /// <summary>
        /// 获取所有设备信息
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
         DataTable GetAllDeviceInfo(DeviceList device);

        /// <summary>
        /// 根据用户名获取该设备所有信息
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        DeviceList GetAllDeviceInfoByName(DeviceList device);
        /// <summary>
        /// 删除设备信息
        /// </summary>
        /// <param name="dname"></param>
        /// <returns></returns>
        int DeleteByDName(string dname);

        /// <summary>
        /// 获取所有设备信息
        /// </summary>
        /// <returns></returns>
        List<DeviceList> GetAllDeviceInfo();

        /// <summary>
        /// 根据用户名更新设备信息
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        int UpDataByName(DeviceList device);

        //增加设备
        int addDevice(DeviceList devicelist);
        /// <summary>
        /// 根据用户名返回设备信息
        /// </summary>
        /// <param name="dname"></param>
        /// <returns></returns>
        DeviceList GetDeviceByName( string dname);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dname"></param>
        /// <param name="dpwd"></param>
        /// <returns></returns>
        int InsertDNameDPwd(DeviceList device);


        /// <summary>
        /// 添加设备信息根据设备名
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        int AddDeviceInfo(DeviceList device);
        

    }
}
