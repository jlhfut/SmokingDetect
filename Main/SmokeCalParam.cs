using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wayee.Services.BusinessLogic.Data
{
    /// <summary>
    /// 不透光烟度校准参数
    /// </summary>
    public class SmokeCalParam
    {
        public int ChannelIndex { get; set; }

        public double RealtimeIntensity1 { get; set; }
        public double RealtimeIntensity2 { get; set; }
        public double RealtimeIntensity3 { get; set; }
        public double RealtimeIntensity4 { get; set; }
        public double RealtimeIntensity5 { get; set; }

        public double CalibrationValue1 { get; set; }
        public double CalibrationValue2 { get; set; }
        public double CalibrationValue3 { get; set; }
        public double CalibrationValue4 { get; set; }
        public double CalibrationValue5 { get; set; }

        public double CoefficientA { get; set; }
        public double CoefficientB { get; set; }
        public double CoefficientC { get; set; }
        public double CoefficientK { get; set; }
        public double ActiveCalibration { get; set; }

        public double OpacityValue { get; set; }

        /// <summary>
        /// 零点光强系数,每次校准时系数变成1
        /// </summary>
        public double ZeroIntensityCoef { get; set; }

        public SmokeCalParam()
        {
            ZeroIntensityCoef = 1;
        }
    }

    /// <summary>
    /// 烟度模型
    /// </summary>
    public class SmokeModel
    {
        /// <summary>
        /// 挡光门限
        /// </summary>
        public virtual float LightThreshold { get; set; }
        /// <summary>
        /// 平均次数
        /// </summary>
        public virtual int AverageNumber { get; set; }
        /// <summary>
        /// 滤波时间常数
        /// </summary>
        public virtual int FilteringTimeConstant { get; set; }
    }

}
