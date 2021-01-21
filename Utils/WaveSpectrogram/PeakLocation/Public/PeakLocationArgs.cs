//===============================================================
// Copyright (C) 2010-2020 皖仪科技研发中心
// 文件名: DistinguishedArgesBase.cs
// 日期：2013-10-12
// 描述：判峰参数
// 版本：1.00
//
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
//
//==============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Wayee.PeakLocation
{
    /// <summary>
    /// 峰参数基类
    /// </summary>
    public class LocationArgs
    {
        LocationType _distinguishedType = LocationType.AdvancedWithMerging;
        /// <summary>
        /// 判峰类型
        /// </summary>
        public LocationType LocationType
        {
            get { return _distinguishedType; }
            set { _distinguishedType = value; }
        }

        protected PointF[] _SourceData = null;
        /// <summary>
        /// 原始数据
        /// </summary>
        public PointF[] SourceData
        {
            get { return _SourceData; }
            set { _SourceData = value; }
        }


        double _minimumWdth = double.NaN;
        /// <summary>
        /// 最小峰宽
        /// </summary>
        public double MinimumWidth
        {
            get
            {
                return _minimumWdth;
            }
            set
            {
                _minimumWdth = value;
            }
        }
        private double _noiseAmplitude = double.NaN;
        /// <summary>
        /// 噪声阈值（峰峰值）
        /// </summary>
        public double BaseLineNoiseAmplitude
        {
            get
            {
                return _noiseAmplitude;
            }
            set
            {
                _noiseAmplitude = value;
            }
        }

        double _resolution = 2.0;
        /// <summary>
        /// 分离度定义
        /// </summary>
        public double Resolution
        {
            get
            {
                return _resolution;
            }
            set
            {
                _resolution = value;
            }
        }
        float _startsLope = 0.06f;
        /// <summary>
        /// 起点斜率阈值
        /// </summary>
        public float StartSLope
        {
            get
            {
                return _startsLope;
            }
            set
            {
                _startsLope = value;
            }
        }
        float _endsLope = -0.02f;
        /// <summary>
        /// 终点斜率阈值
        /// </summary>
        public float EndSLope
        {
            get
            {
                return _endsLope;
            }
            set
            {
                _endsLope = value;
            }
        }

        private double _timeSpan = 0.05;
        /// <summary>
        /// 数据间隔
        /// </summary>
        public double TimeSpan
        {
            get { return _timeSpan; }
            set { _timeSpan = value; }
        }
       
        protected int _Interval = 1;
        /// <summary>
        /// 一阶二阶导数抽样率
        /// </summary>
        public int SampleInterval
        {
            get { return _Interval; }
            set { _Interval = value; }
        }

        private int _SG_Order = 5;
        /// <summary>
        /// SG滤波器阶数
        /// </summary>
        public int SG_Order
        {
            get { return _SG_Order; }
            set { _SG_Order = value; }
        }

        private int _SG_SideWindowLength = 40;
        /// <summary>
        /// SG滤波器半窗口宽度
        /// </summary>
        public int SG_SideWindowLength
        {
            get { return _SG_SideWindowLength; }
            set { _SG_SideWindowLength = value; }
        }

        private double _SDNoiseAmplitude = double.NaN;
        /// <summary>
        /// 二阶导数噪声阈值
        /// </summary>
        public double SDNoiseAmplitude
        {
            get { return _SDNoiseAmplitude; }
            set { _SDNoiseAmplitude = value; }
        }
    }

    /// <summary>
    /// 判峰参数类
    /// </summary>
    public class PeakLocationArgs : LocationArgs
    {
        PointF[] _sampleData = null;
        /// <summary>
        /// 抽样后的原始数据
        /// </summary>
        public PointF[] SampleData
        {
            get { return _sampleData; }
            set { _sampleData = value; }
        }
       
        protected PointF[] _FDData = null;
        /// <summary>
        /// 一阶导数
        /// </summary>
        public PointF[] First_Order_Derivative
        {
            get { return _FDData; }
            set { _FDData = value; }
        }

        protected PointF[] _SDData = null;
        /// <summary>
        /// 二阶导数数据
        /// </summary>
        public PointF[] Second_Order_Derivative
        {
            get { return _SDData; }
            set { _SDData = value; }
        }

        List<PeakArgs> _peekList = null;
        /// <summary>
        /// 峰列表
        /// </summary>
        public List<PeakArgs> PeakList
        {
            get { return _peekList; }
            set 
            {
                IEnumerable<PeakArgs> varlist = from peak in value orderby peak.PeakPoint.X select peak;
                _peekList = varlist .ToList(); 
            }
        }

        double _heightRate = 0.2;
        /// <summary>
        /// 峰高比
        /// </summary>
        public double HeightRate
        {
            get
            {
                return _heightRate;
            }
            set
            {
                _heightRate = value;
            }
        }
    }
}
