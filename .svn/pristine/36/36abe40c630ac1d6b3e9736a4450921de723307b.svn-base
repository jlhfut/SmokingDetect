using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wayeal.Services.Configs
{
    /// <summary>
    /// 车辆限值信息
    /// </summary>
    public class CarLimitingInfo
    {
        /// <summary>
        /// 不透光烟度是否作为柴油车判定条件
        /// </summary>
        public int JudgeOpSmoke { get; set; }
        /// <summary>
        /// 黄牌车是否作为柴油车判定条件
        /// </summary>
        public int JudgeYellowCar { get; set; }
        /// <summary>
        /// 不透光烟度限值（作为是否为柴油车的判定条件）
        /// </summary>
        public Double JudgeOpSmokeValue { get; set; }

        /// <summary>
        /// 柴油车当前限值信息
        /// </summary>
        public DieselCarInfo DieselCarLimitInfo { get; set; }
        /// <summary>
        /// 汽油车当前限值信息
        /// </summary>
        public GasolineCarInfo GasolimitCarInfo { get; set; }
    }

    /// <summary>
    /// 柴油车当前限值信息
    /// </summary>
    public class DieselCarInfo
    {
        /// <summary>
        /// NO限值
        /// </summary>
        public Double NOLimiting { get; set; }
       
       
        /// <summary>
        /// 不透光烟度限值（作为柴油车是否超标的判定条件）
        /// </summary>
        public Double OpSmokeLimiting { get; set; }
        /// <summary>
        /// 林戈曼黑度限值
        /// </summary>
        public int BlacknessLimiting { get; set; }
    }
    /// <summary>
    /// 汽油车当前限值信息
    /// </summary>
    public class GasolineCarInfo
    { 
        /// <summary>
        /// NO限值
        /// </summary>
        public Double NOLimiting { get; set; }
        /// <summary>
        /// CO限值
        /// </summary>
        public Double COLimiting { get; set; }
        /// <summary>
        /// HC限值
        /// </summary>
        public Double HCLimiting { get; set; }
    
    }
}
