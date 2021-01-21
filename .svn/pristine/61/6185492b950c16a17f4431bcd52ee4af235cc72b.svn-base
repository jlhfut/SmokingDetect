using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wayeal.Services.Business.Utils;
using Wayee.Services.BusinessLogic.Data;

namespace Wayeal.Services.Configs
{
    /// <summary>
    /// 尾气本身配置的相关参数
    /// </summary>
    public class SystemParam
    {
        /// <summary>
        /// 坡度
        /// </summary>
        public float Slope { get; set; }

        /// <summary>
        /// l12
        /// </summary>
        public float Distance { get; set; }

        /// <summary>
        /// l13
        /// </summary>
        public float Distance2 { get; set; }

        /// <summary>
        /// 抓拍和遥测时间差,单位s
        /// </summary>
        public float EffectTime { get; set; }

        /// <summary>
        /// 系统预热时间
        /// </summary>
        public int StandardPreheatingTime { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 光谱仪校准参数
        /// </summary>
        public UVSParam UVSCalParam { get; set; }

        /// <summary>
        /// NO相关校准参数
        /// </summary>
        public UVSRangeParam UVSNOCalParam { get; set; }

        /// <summary>
        /// HC相关校准参数
        /// </summary>
        public UVSRangeParam UVSHCCalParam { get; set; }

        /// <summary>
        /// TDLAS校准参数
        /// </summary>
        public TDLASParam TDLASCaParam { get; set; }

        /// <summary>
        /// CO相关校准参数
        /// </summary>
        public TDLASRangeParam TDLASCOCalParam { get; set; }

        /// <summary>
        /// CO2相关校准参数
        /// </summary>
        public TDLASRangeParam TDLASCO2CalParam { get; set; }


        public List<SmokeCalParam> SmokeCalParam { get; set; }

        /// <summary>
        /// Smoke参数
        /// </summary>
        public SmokeCfgParam SmokeParam { get; set; }

        /// <summary>
        /// 算法参数
        /// </summary>
        public AlgorithmParameter AlgorithmParam { get; set; }

        /// <summary>
        /// Led模板
        /// </summary>
        public LedAct LedTemplate { get; set; }

        /// <summary>
        /// 自动校准参数
        /// </summary>
        public AutoCalParameter AutoCalParam { get; set; }

        /// <summary>
        /// 抓拍参数
        /// </summary>
        public CaptureParameter CaptureParam { get; set; }

        /// <summary>
        /// 车辆限值信息
        /// </summary>
        public CarLimitingInfo CarLimitParamInfo { get; set; }

        public SystemParam()
        {
            UVSCalParam = new UVSParam();
            UVSNOCalParam = new UVSRangeParam();
            UVSHCCalParam = new UVSRangeParam();
            TDLASCaParam = new TDLASParam();
            TDLASCOCalParam = new TDLASRangeParam();
            TDLASCO2CalParam = new TDLASRangeParam();
            SmokeParam = new SmokeCfgParam();
            SmokeCalParam = new List<SmokeCalParam>();
            AlgorithmParam = new AlgorithmParameter();
            Slope = 5;
            EffectTime = 5;
            Distance = 200;
            Distance2 = 400;
            StandardPreheatingTime = 30;
            LedTemplate = new LedAct();
            AutoCalParam = new AutoCalParameter();
            CaptureParam = new CaptureParameter();
        }
    }

    /// <summary>
    /// Smoke参数
    /// </summary>
    public class SmokeCfgParam
    {
        /// <summary>
        /// 烟道使能通道数
        /// </summary>
        public int EnableChannels { get; set; }
        /// <summary>
        /// 不透光烟度滤波常数(ms)
        /// </summary>
        public int FilteringTime { get; set; }
        /// <summary>
        /// 校准系数
        /// </summary>
        public List<double> CaliRatioList { get; set; }

        public SmokeCfgParam()
        {
            EnableChannels = 3;
        }
    }

    /// <summary>
    /// UVS相关参数
    /// </summary>
    public class UVSParam
    {
        /// <summary>
        /// 校准平均次数
        /// </summary>
        public int CalAverageCount { get; set; }

        /// <summary>
        /// 光强报警开始
        /// </summary>
        public virtual int IntensityAlarmStart { get; set; }
        /// <summary>
        /// 光强报警结束
        /// </summary>
        public virtual int IntensityAlarmEnd { get; set; }

        /// <summary>
        /// 校准光强
        /// </summary>
        public double AverageIntensity { get; set; }

        /// <summary>
        /// 光强开始范围
        /// </summary>
        public virtual int IntensityRangeStart { get; set; }
        /// <summary>
        /// 光强结束范围
        /// </summary>
        public virtual int IntensityRangeEnd { get; set; }
        /// <summary>
        /// 紫外静态校准滤波常数(ms)
        /// </summary>
        public int FilteringTime { get; set; }

        /// <summary>
        /// 零点光强
        /// </summary>
        public List<double> ZeroIntensity { get; set; }

    }

    /// <summary>
    /// TDLAS相关参数
    /// </summary>
    public class TDLASParam
    {
        /// <summary>
        /// 校准平均次数
        /// </summary>
        public int CalAverageCount { get; set; }

        /// <summary>
        /// 光强报警开始
        /// </summary>
        public int IntensityAlarmStart { get; set; }
        /// <summary>
        /// 光强报警结束
        /// </summary>
        public int IntensityAlarmEnd { get; set; }

        /// <summary>
        /// 校准光强
        /// </summary>
        public double AverageIntensity { get; set; }

        /// <summary>
        /// TDLAS静态校准滤波常数(ms)
        /// </summary>
        public int FilteringTime { get; set; }

        /// <summary>
        /// 自动相位锁定
        /// </summary>
        public bool AutoPhaseLocking { get; set; }

        /// <summary>
        /// 锁相修正系数
        /// </summary>
        public double PhaseCorrectCoef { get; set; }

        /// <summary>
        /// 出厂工作电流
        /// </summary>
        public double FactoryWorkCurrent { get; set; }

        /// <summary>
        /// 零点光强
        /// </summary>
        public List<Int16> ZeroIntensity { get; set; }

        /// <summary>
        /// 零点谐波
        /// </summary>
        public List<Int16> Harm { get; set; }

    }


    /// <summary>
    /// UVS 相关校准参数
    /// </summary>
    public class UVSRangeParam
    {
        /// <summary>
        /// 起始点
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 结束点
        /// </summary>
        public int End { get; set; }

        /// <summary>
        /// 量程
        /// </summary>
        public double Range { get; set; }

        /// <summary>
        ///标定时的光强
        /// </summary>
        public double AverageIntensity { get; set; }

        /// <summary>
        /// 吸光度
        /// </summary>
        public List<double> Absorb { get; set; }

        /// <summary>
        ///是否非线性修正
        /// </summary>
        public bool IsLinear { get; set; }

        /// <summary>
        /// 最大的非线性量程,每次手动修改非线性数据时时更新
        /// </summary>
        public double MaxNoLinearRange { get; set; }
        /// <summary>
        /// 非线性修改数据
        /// </summary>
        public List<NoLinearCalData> NolinearList { get; set; }

    }

    /// <summary>
    /// UVS 相关校准参数
    /// </summary>
    public class TDLASRangeParam
    {
        /// <summary>
        /// 起始点
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// 结束点
        /// </summary>
        public int End { get; set; }

        /// <summary>
        /// 量程
        /// </summary>
        public double Range { get; set; }

        /// <summary>
        /// 校准光强
        /// </summary>
        public double AverageIntensity { get; set; }

        /// <summary>
        /// 量程谐波
        /// </summary>
        public List<Int16> Harm { get; set; }

        /// <summary>
        /// 量程光强
        /// </summary>
        public List<Int16> Intensity { get; set; }

    }

    /// <summary>
    /// 算法参数
    /// </summary>
    public class AlgorithmParameter
    {
        /// <summary>
        /// 是否滤波
        /// </summary>
        public bool IsFir { get; set; }

        /// <summary>
        /// 滤波系数
        /// </summary>
        public List<double> FirCoefficients { get; set; }

        public AlgorithmParameter()
        {
            IsFir = false;
            FirCoefficients = null;
        }
    }

    /// <summary>
    /// 自动校准参数
    /// </summary>
    public class AutoCalParameter
    {
        /// <summary>
        /// 自动校零开关
        /// </summary>
        public bool AutoZeroCalSwitch { get; set; }

        /// <summary>
        /// 自动校零开关
        /// </summary>
        public bool AutoCalRangeSwitch { get; set; }

        /// <summary>
        /// 扩散时间，尾气扩散后多长时间开始测试,校准零点时使用
        /// </summary>
        public int DiffusionTime { get; set; }

        /// <summary>
        /// 校准间隔(s),校准零点时使用
        /// </summary>
        public int CalTimeInterval { get; set; }

        /// <summary>
        /// 自动标零有效范围，在原始标定光强的20%波动
        /// </summary>
        public int UVSCalEffectRange { get; set; }

        /// <summary>
        /// 自动标零有效范围，在原始标定光强的20%波动
        /// </summary>
        public int TDLASCalEffectRange { get; set; }

        /// <summary>
        /// 不透光度标定范围
        /// </summary>
        public int OPACCalEffectRange { get; set; }

        /// <summary>
        /// 紫外校准滤波常数(ms)
        /// </summary>
        public int UVSCalFilteringTime { get; set; }

        /// <summary>
        /// TDLAS校准滤波常数(ms)
        /// </summary>
        public int TDLASCalFilteringTime { get; set; }

        /// <summary>
        /// 不透光烟度滤波时间(ms)
        /// </summary>
        public int OPACCalFilteringTime { get; set; }

        /// <summary>
        /// TDLAS量程校准滤波常数(ms)
        /// </summary>
        public int TDLASCalRangeFilteringTime { get; set; }

        /// <summary>
        /// 紫外量程校准滤波常数(ms)
        /// </summary>
        public int UVSCalRangeFilteringTime { get; set; }

        /// <summary>
        /// 开阀1延迟时间s
        /// </summary>
        public int OpenValve1Delay { get; set; }

        /// <summary>
        /// 开阀2延迟时间s
        /// </summary>
        public int OpenValve2Delay { get; set; }

        /// <summary>
        /// 关阀开泵延迟
        /// </summary>
        public int OpenPumpDelay { get; set; }

        /// <summary>
        /// 量程校准总的时间
        /// </summary>
        public int MaxCalRangeTotalTime { get; set; }

        /// <summary>
        /// 量程校准的每天时间段
        /// 1 2 3 
        /// </summary>
        public List<int> CalRangeTimeList { get; set; }

        public AutoCalParameter()
        {
            AutoZeroCalSwitch = false;
            AutoCalRangeSwitch = false;
            DiffusionTime = 3;
            CalTimeInterval = 10;
            UVSCalFilteringTime = 100;
            TDLASCalFilteringTime = 100;
            OPACCalFilteringTime = 100;

            UVSCalRangeFilteringTime = 1000;
            TDLASCalRangeFilteringTime = 1000;

            UVSCalEffectRange = 20;
            TDLASCalEffectRange = 20;
            OPACCalEffectRange = 20;

            OpenValve1Delay = 10;
            OpenValve2Delay = 10;
            OpenPumpDelay = 10;
            MaxCalRangeTotalTime = 600;
            CalRangeTimeList = new List<int>();
        }
    }

    /// <summary>
    /// 抓拍参数
    /// </summary>
    public class CaptureParameter
    {
        /// <summary>
        /// 是否手动抓拍
        /// </summary>
        public bool IsManual { get; set; }

        /// <summary>
        /// 抓拍次数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 等待时间ms
        /// </summary>
        public int WaitTime { get; set; }

        /// <summary>
        /// 间隔ms
        /// </summary>
        public int Interval { get; set; }

        public CaptureParameter()
        {
            IsManual = false;
            Count = 2;
            WaitTime = 500;
            Interval = 500;
        }
    }

    /// <summary>
    /// 非线性校准数据
    /// </summary>
    public class NoLinearCalData :IComparer<NoLinearCalData>
    {
        /// <summary>
        /// 原始数据
        /// </summary>
        public double OriginalData { get; set; }

        /// <summary>
        /// 修正数据
        /// </summary>
        public double CorrectData { get; set; }

        public int Compare(NoLinearCalData x, NoLinearCalData y)
        {
            if (x == null || y == null) return 0;
            if (Math.Abs(x.OriginalData - y.CorrectData) < 0.0000001) return 0;
            else if (x.OriginalData > y.CorrectData) return 1;
            else return -1;
        }
    }
}
