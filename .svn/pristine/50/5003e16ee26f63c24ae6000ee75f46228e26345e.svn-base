//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: PeakArgs.cs
// 日期：2013/10/12
// 描述：定义峰数据结构的标识符
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Wayee.PeakLocation
{
    /// <summary>
    /// 峰类型：分离峰，融合峰
    /// </summary>
    public enum PeakType
    { 
        /// <summary>
        /// 分离峰
        /// </summary>
        Detached,
        /// <summary>
        /// 融合峰
        /// </summary>
        Mixed,
        /// <summary>
        /// 噪声峰
        /// </summary>
        Noise
    }
    /// <summary>
    /// 峰特征点标记
    /// </summary>
    public enum PeakFlag
    { 
        /// <summary>
        /// 峰起点
        /// </summary>
        O,
        /// <summary>
        /// 峰终点
        /// </summary>
        T,
        /// <summary>
        /// 拐点：二阶导数过零点
        /// </summary>
        I,
        /// <summary>
        /// 顶点
        /// </summary>
        A,
        /// <summary>
        /// 谷点：
        /// </summary>
        V,
        /// <summary>
        /// 肩峰边界
        /// </summary>
        S,
        /// <summary>
        /// 圆角峰边界
        /// </summary>
        R,
        /// <summary>
        /// 上坡点：二阶导数极小值点
        /// </summary>
        U

    }
    /// <summary>
    /// 峰对象特征参数
    /// </summary>
    public class PeakArgs
    {
        string _characteristicPointsFlag = "";
        /// <summary>
        /// 峰特征点标记,例如：
        /// OIAIT：标识分离峰的特征点：起点、拐点、顶点、拐点、终点
        /// OIAIVIAIT：标识融合峰特征点：起点、拐点、顶点、拐点、谷点、拐点、顶点、拐点、终点
        /// OIAISIAIST：标识带肩峰的融合峰：起点、拐点、顶点、拐点、肩峰起点、拐点、肩峰顶点、拐点、肩峰终点、终点
        /// 圆角峰类似肩峰标识
        /// </summary>
        public string CharacteristicPointsFlag
        {
            get { return _characteristicPointsFlag; }
            set { _characteristicPointsFlag = value; }
        }

        private PeakType _type = PeakType.Detached;
        /// <summary>
        /// 峰类型，标记为分离峰，融合峰，噪声峰
        /// </summary>
        public PeakType Type
        {
            get { return _type; }
            set { _type = value; }
        }

         PointF _startPoint = new PointF(0, 0);
        /// <summary>
        /// 定义峰数据结构的起点标示符
        /// </summary>
        public PointF StartPoint
        {
            get{return _startPoint;}
            set{_startPoint = value;}
        }

        PointF _endPoint = new PointF(0, 0);
        /// <summary>
        /// 定义峰数据结构的终点标示符
        /// </summary>
        public PointF EndPoint
        {
            get{ return _endPoint; }
            set{ _endPoint = value;}
        }

        PointF _peakPoint = new PointF(0, 0);
        /// <summary>
        /// 定义峰数据结构的峰顶点标识符
        /// </summary>
        public PointF PeakPoint
        {
            get{return _peakPoint;}
            set{_peakPoint = value;}
        }

        List<PointF> _characteristicPoints = new List<PointF>();
        /// <summary>
        /// 峰特征点列表
        /// </summary>
        public List<PointF> CharacteristicPoints
        {
            get { return _characteristicPoints; }
            set { _characteristicPoints = value; }
        }

    }
}
