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
    class ImDeviceListDAL : IDeviceListDAL
    {
        /// <summary>
        /// 获取所有设备信息
        /// </summary>
        SqlSugarClient db = new SqlConnect().GetInstance();


        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        int IDeviceListDAL.addDevice(DeviceList devicelist)
        {
          return db.Insertable(devicelist).ExecuteCommand();
        }


        /// <summary>
        /// 车辆信息
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        int IDeviceListDAL.AddDeviceInfo(DeviceList device)
        {
            throw new NotImplementedException();
        }

        int IDeviceListDAL.DeleteByDName(string dname)
        {
          return  db.Deleteable<DeviceList>().Where(it => it.dname == dname).ExecuteCommand();
        }

        DataTable IDeviceListDAL.GetAllDeviceInfo(DeviceList device)
        {
            return db.Queryable<DeviceList>().ToDataTable();//查询所有设备信息
        }

        List<DeviceList> IDeviceListDAL.GetAllDeviceInfo()
        {
            return db.Queryable<DeviceList>().ToList();//查询所有设备信息
        }

        /// <summary>
        /// 根据设备名获取设备信息
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        DeviceList IDeviceListDAL.GetAllDeviceInfoByName(DeviceList device)
        {
          // return db.Queryable<DeviceList>().Where(it => it.dname == device.dname).ToDataTable();
           return   db.Queryable<DeviceList>().First(it => it.dname == device.dname);
        }

        DeviceList IDeviceListDAL.GetDeviceByName(string dname)
        {
            DeviceList device = db.Queryable<DeviceList>().First(it => it.dname == dname);
            return device;
        }

        /// <summary>
        /// 保存登录名和密码
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        int IDeviceListDAL.InsertDNameDPwd(DeviceList device)
        {
            return db.Updateable<DeviceList>(it => new DeviceList() { duname = device.duname, dpwd = device.dpwd }).Where(it => it.did == device.did).ExecuteCommand();
              
        }

        /// <summary>
        /// 根据设备名更新设备信息
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        int IDeviceListDAL.UpDataByName(DeviceList device)
        {
           return db.Updateable(device).WhereColumns(it => new { it.dname }).ExecuteCommand();//更新单 条根据ID
        }
    }
}
