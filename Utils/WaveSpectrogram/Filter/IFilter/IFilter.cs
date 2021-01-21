//==================================================================
// Copyright(C) 皖仪科技研发中心软件部
// 文件名: 
// 日期：
// 描述：
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人                     修改内容
//
//==================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wayee.Filter
{
    /// <summary>
    /// 数据处理参数基类
    /// </summary>
    public class FilterArgs
    {

    }
    /// <summary>
    /// 中值滤波参数类
    /// </summary>
    public class MedianFilterArgs : FilterArgs
    {
        int _FrameSize = 3;
        /// <summary>
        /// 中值滤波窗口长度
        /// </summary>
        public int FrameSize
        {
            get { return _FrameSize; }
            set { _FrameSize = value; }
        }
    }
    /// <summary>
    /// S_G滤波参数类
    /// </summary>
    public class SGFilterArgs : FilterArgs
    {
        int _Order = 2;
        /// <summary>
        /// 多项式阶数
        /// </summary>
        public int Order
        {
            get { return _Order; }
            set { _Order = value; }
        }

        int _sidePoint = 3;
        /// <summary>
        /// 窗口半宽度；FrameSize = SidePoint*2+1
        /// </summary>
        public int SidePoint
        {
            get { return _sidePoint; }
            set { _sidePoint = value; }
        }
    }
    /// <summary>
    /// 一阶微分参数基类
    ///        d
    /// f(t) = — F(t)
    ///        dt
    ///      1
    /// Yi = —（Xi+1 - Xi-1）
    ///     2dt
    /// </summary>
    public class DifferentiateFilterArgs : FilterArgs
    {
        double _dt = 1.0;
        /// <summary>
        /// 数据间隔，要求传入的数据序列是等间隔的：默认1.0
        /// </summary>
        public double Dt
        {
            get { return _dt; }
            set { _dt = value; }
        }
        double _initialCondition = 0.0;
        /// <summary>
        /// 初始条件，用于计算第一个点的微分值
        /// </summary>
        public double InitialCondition
        {
            get { return _initialCondition; }
            set { _initialCondition = value; }
        }
        double _finalCondition = 0.0;
        /// <summary>
        /// 结束条件，用于计算最后一个数据的微分值
        /// </summary>
        public double FinalCondition
        {
            get { return _finalCondition; }
            set { _finalCondition = value; }
        }
    }

    /// <summary>
    /// 抽样参数
    /// </summary>
    public class SampleArgs : FilterArgs
    {
        int _interval = 1;
        /// <summary>
        /// 抽样宽度
        /// </summary>
        public int Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }
    }

    /// <summary>
    /// Filter interface.
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// 滤波处理
        /// </summary>
        /// <param name="srcData">原始数据</param>
        /// <param name="FrameSize">窗宽</param>
        /// <returns></returns>
        double[] Process(double[] srcData, FilterArgs arges);
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        bool Init();
    }

    /// <summary>
    /// Filter Base class
    /// </summary>
    public class FilterBase : IFilter
    {
        /// <summary>
        /// 基类数据处理，判定输入数据有效性
        /// </summary>
        /// <param name="srcData"></param>
        /// <param name="arges"></param>
        /// <returns></returns>
        public virtual double[] Process(double[] srcData, FilterArgs args)
        {
            if (srcData == null) return null;
            if (srcData.Length == 0) return null;
            if (args == null) return null;
            return srcData;
        }

        public virtual bool Init()
        {
            return true;
        }
    }
}
