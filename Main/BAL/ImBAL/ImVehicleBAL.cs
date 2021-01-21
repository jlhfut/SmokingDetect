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
    class ImVehicleBAL : IVehicleBAL
    {
        IVehicleDAL DAL = new ImVehicleDAL();

        int IVehicleBAL.AddVehicle(Vehicle vehicle)
        {
            return DAL.AddVehicle(vehicle);
        }

        DataTable IVehicleBAL.GetSumVehicles()
        {
            return DAL.GetSumVehicles();
        }

        int IVehicleBAL.GetTotal()
        {
            return DAL.GetTotal();
        }

        Vehicle IVehicleBAL.GetVehicle()
        {
            return DAL.GetVehicle();
        }

        DataTable IVehicleBAL.GetVehicleByDateTime(DateTime startTime, DateTime endTime)
        {
            return DAL.GetVehicleByDateTime(startTime, endTime);
        }

        DataTable IVehicleBAL.GetVehicles(int count)
        {
            return DAL.GetVehicles(count);
        }

        DataTable IVehicleBAL.GetVehiclesByMulCondition(DateTime startTime, DateTime endTime, string vNo, string vColor, int? vRingeman, int pageIndex, int pageSize, ref int totalPage)
        {
            return DAL.GetVehiclesByMulCondition(startTime, endTime, vNo, vColor, vRingeman, pageIndex, pageSize, ref totalPage);
        }

        DataTable IVehicleBAL.SelectAllVehicle()
        {
            return DAL.SelectAllVehicle();
        }

        Vehicle IVehicleBAL.SelectVehicleById(int id)
        {
            return DAL.SelectVehicleById(id);
        }
    }
}
