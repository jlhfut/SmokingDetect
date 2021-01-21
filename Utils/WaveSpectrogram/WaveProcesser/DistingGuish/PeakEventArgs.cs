//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: PeakFoundEventArgs.cs
// 作者：胡凡平
// 日期：2011/03/09
// 描述：定义峰数据结构的标识符
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
//              2011-04-19       胡凡平             将起止点和峰值点修改为PointF类型
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Wayee.WaveProcesser
{
    public class PeakFoundEventArgs
    {
        PointF startpoint = new PointF(0, 0);
        PointF endpoint = new PointF(0, 0);
        PointF peakpoint = new PointF(0, 0);
        int backtrendpointNum = 0;
        int lefttrendpointNum = 0;
        bool ismidpeak = false;


        /// <summary>
        /// 定义峰数据结构的起点标示符
        /// </summary>
        public PointF StartPoint
        {
            get
            {
                return startpoint;
            }
            set
            {
                startpoint = value;
            }
        }
        /// <summary>
        /// 定义峰数据结构的终点标示符
        /// </summary>
        public PointF EndingPoint
        {
            get
            {
                return endpoint;
            }
            set
            {
                endpoint = value;
            }
        }

        /// <summary>
        /// 定义峰数据结构的峰顶点标识符
        /// </summary>
        public PointF PeakPoint
        {
            get
            {
                return peakpoint;
            }
            set
            {
                peakpoint = value;
            }
        }

        /// <summary>
        /// 定义峰数据结构的后肩峰数据标识符
        /// </summary>
        public int BackTrendPointNum
        {
            get
            {
                return backtrendpointNum;
            }
            set
            {
                backtrendpointNum = value;
            }
        }

        /// <summary>
        /// 定义峰数据结构的左肩峰数据标识符
        /// </summary>
        public int LeftTrendPointNum
        {
            get
            {
                return lefttrendpointNum;
            }
            set
            {
                lefttrendpointNum = value;
            }
        }
        /// <summary>
        /// 标记峰为中间峰
        /// </summary>
        public bool IsMidPeak
        {
            get
            {
                return ismidpeak;
            }
            set
            {
                ismidpeak = value;
            }
        }
    }
}
