using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data ;
using System.Threading.Tasks;

namespace wayeal.os.exhaust
{
    public static class ClassEnum
    {
        public enum ColumnName
        {
            Number,
            TestingNumber,
            TestingTime,
            TrackNumber,
            LicenseNumber,
            LicenseColor,
            BodyColor,
            TestingResult,
            NO,
            CO,
            CO2,
            HC,
            OpSmoke,
            Blackness,
            WindSpeed,
            WindDirection,
            Pressure,
            Temperature,
            Humidity,
            Speed,
            Acceleration,
            VSP,
            Operation,
            Setting
        }
        public enum UDColumn
        {
            IsVisible,
            Width,
            ColumnName
        }

        /// <summary>
        /// 车牌颜色
        /// </summary>
        //string[] CarNumberColor = { "Color_blue", "Color_yellow", "Color_white", " Color_black", "Color_green", "Color_blackness", "Color_other" };
        public enum enumCarNumberColor
        {
            /// <summary>
            /// 蓝色
            /// </summary>
            Color_Blue = 0,
            /// <summary>
            /// 黄色
            /// </summary>
            Color_Yellow = 1,
            /// <summary>
            /// 白色
            /// </summary>
            Color_White = 2,
            /// <summary>
            /// 黑色
            /// </summary>
            Color_Black = 3,
            /// <summary>
            /// 绿色
            /// </summary>
            Color_Green = 4,
            /// <summary>
            /// 民航黑
            /// </summary>
            Color_Blackness = 5,
            /// <summary>
            /// q其他颜色
            /// </summary>
            Color_Other = 0xff
        }
        /// <summary>
        /// 车身颜色
        /// </summary>
        public enum enumBodyColor
        {
            /// <summary>
            /// 其他颜色
            /// </summary>
            Color_Other = 0,
            /// <summary>
            /// 白色
            /// </summary>
            Color_White = 1,
            /// <summary>
            /// 银色
            /// </summary>
            Color_Silvery = 2,
            /// <summary>
            /// 灰色
            /// </summary>
            Color_Gray = 3,
            /// <summary>
            /// 黑色
            /// </summary>
            Color_Black = 4,
            /// <summary>
            /// 红色
            /// </summary>
            Color_Red = 5,
            /// <summary>
            /// 深蓝
            /// </summary>
            Color_Darkblue = 6,
            /// <summary>
            /// 蓝色
            /// </summary>
            Color_Blue = 7,
            /// <summary>
            /// 黄色
            /// </summary>
            Color_Yellow = 8,
            /// <summary>
            /// 绿色
            /// </summary>
            Color_Green = 9,
            /// <summary>
            /// 棕色
            /// </summary>
            Color_Brown = 10,
            /// <summary>
            /// 粉色
            /// </summary>
            Color_Pink = 11,
            /// <summary>
            /// 紫色
            /// </summary>
            Color_Violet = 12,
            /// <summary>
            /// 深灰
            /// </summary>
            Color_Darkgrey = 13,
            /// <summary>
            /// 青色
            /// </summary>
            Color_Cyan = 14,
            Color_Undefine = 0xff
        }
        /// <summary>
        /// 车牌类型
        /// </summary>
        public enum enumLicenseType
        {
            /// <summary>
            /// 标准民用车与军车车牌 
            /// </summary>
            VCA_STANDARD92_PLATE = 0,

            /// <summary>
            /// 02式民用车牌
            /// </summary>
            VCA_STANDARD02_PLATE,

            /// <summary>
            /// 武警车车牌 
            /// </summary>
            VCA_WJPOLICE_PLATE,

            /// <summary>
            /// 警车车牌 
            /// </summary>
            VCA_JINGCHE_PLATE,

            /// <summary>
            /// 民用车双行尾牌 
            /// </summary>
            STANDARD92_BACK_PLATE,

            /// <summary>
            /// 使馆车牌
            /// </summary>
            VCA_SHIGUAN_PLATE,

            /// <summary>
            /// 农用车车牌 
            /// </summary>
            VCA_NONGYONG_PLATE,

            /// <summary>
            /// 摩托车车牌 
            /// </summary>
            VCA_MOTO_PLATE,

            /// <summary>
            ///  新能源车牌
            /// </summary>
            NEW_ENERGY_PLATE
        }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public enum enumVehicleType
        {
            //Bit5- 小货车，Bit6- 行人，Bit7- 二轮车，Bit8- 三轮车，Bit9- SUV/MPV，Bit10- 中型客车
            /// <summary>
            /// 未知（其他）
            /// </summary>
            Unknow = 0,
            /// <summary>
            /// 客车
            /// </summary>
            PassengerCar = 1,
            /// <summary>
            /// 大货车
            /// </summary>
            BigTruck = 2,
            /// <summary>
            /// 轿车
            /// </summary>
            SaloonCar = 3,
            /// <summary>
            /// 面包车
            /// </summary>
            Van = 4,
            /// <summary>
            /// 小货车
            /// </summary>
            Buggy = 5,
            /// <summary>
            /// 行人
            /// </summary>
            Pedestrian = 6,
            /// <summary>
            /// 二轮车
            /// </summary>
            TwoWheels = 7,
            /// <summary>
            /// 三轮车
            /// </summary>
            ThreeWheels = 8,
            /// <summary>
            /// SUV/MPV
            /// </summary>
            SUVMPV = 9,
            /// <summary>
            /// 中型客车
            /// </summary>
            MediumBus = 10
        }

        //public DataTable BuildUserDefineTable(DataTable dt)
        //{
        //    dt.Columns.Add(new DataColumn("ColumnName"));
        //    dt.Columns.Add(new DataColumn("IsVisible"));
        //    dt.Columns.Add(new DataColumn("Width"));
        //    dt.Columns["IsVisible"].DataType = Type.GetType("System.Boolean");
        //    dt.Columns["Width"].DataType = Type.GetType("System.Int32");
        //    foreach (ColumnName cn in Enum.GetValues(typeof(ColumnName)))
        //    {
        //        DataRow row = dt.NewRow();
        //        row["ColumnName"] = cn.ToString();
        //        dt.Rows.Add(row);
        //    }
        //    return dt;
        //}
    }
}
