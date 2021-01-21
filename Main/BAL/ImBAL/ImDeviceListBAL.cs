using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.DAL.IDAL;
using wayeal.os.exhaust.DAL.ImDAL;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.BAL.ImBAL
{
    class ImDeviceListBAL : IDeviceListBAL
    {
        IDeviceListDAL DAL = new ImDeviceListDAL();

        int IDeviceListBAL.addDevice(DeviceList devicelist)
        {
            return DAL.addDevice(devicelist);
        }

        int IDeviceListBAL.DeleteByDName(string dname)
        {
            return DAL.DeleteByDName(dname);
        }

        DataTable IDeviceListBAL.GetAllDeviceInfo(DeviceList device)
        {
            return DAL.GetAllDeviceInfo(device);
        }

        List<DeviceList> IDeviceListBAL.GetAllDeviceInfo()
        {
            return DAL.GetAllDeviceInfo();
        }

        DeviceList IDeviceListBAL.GetAllDeviceInfoByName(DeviceList device)
        {
          return  DAL.GetAllDeviceInfoByName(device);
           
        }

        DeviceList IDeviceListBAL.GetDeviceByName(string dname)
        {
            return DAL.GetDeviceByName(dname);
        }

        int IDeviceListBAL.InsertDNameDPwd(DeviceList device)
        {
            return DAL.InsertDNameDPwd(device);
        }

        int IDeviceListBAL.UpDataByName(DeviceList device)
        {
            return DAL.UpDataByName(device);
        }
    }
}
