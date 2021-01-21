//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: PeakData.cs
// 作者：胡凡平
// 日期：2011/03/09
// 描述：定义峰数据结构的标识符
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
// 
//==============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wayee.WaveProcesser
{
    /// <summary>
    /// 定义峰数据结构的标识符
    /// </summary>
    public class PeakData
    {
        /// <summary>
        /// 定义峰数据结构的起点标示符
        /// </summary>
        public static string StartingPoint
        {
            get
            {
                return "StartPoint";
            }
        }
        /// <summary>
        /// 定义峰数据结构的终点标示符
        /// </summary>
        public static string EndingPoint
        {
            get
            {
                return "EndPoint";
            }
        }

        /// <summary>
        /// 定义峰数据结构的起点标示符
        /// </summary>
        public static string ZStartingPoint
        {
            get
            {
                return "ZStartPoint";
            }
        }
        /// <summary>
        /// 定义峰数据结构的终点标示符
        /// </summary>
        public static string ZEndingPoint
        {
            get
            {
                return "ZEndPoint";
            }
        }
        /// <summary>
        /// 定义峰数据结构的左拐点数据标识符
        /// </summary>
        public static string LeftInflextionPoint
        {
            get
            {
                return "LeftInflextionPoint";
            }
        }
        /// <summary>
        /// 定义峰数据结构的右拐点标识符
        /// </summary>
        public static string RightInflectionPoint
        {
            get
            {
                return "RightInflectionPoint";
            }
        }
        /// <summary>
        /// 定义峰数据结构的峰顶点标识符
        /// </summary>
        public static string PeakPoint
        {
            get
            {
                return "PeakPoint";
            }
        }
        /// <summary>
        /// 定义峰数据结构的谷点标识符
        /// </summary>
        public static string ValleyPoint
        {
            get
            {
                return "ValleyPoint";
            }
        }
        /// <summary>
        /// 定义峰数据结构的后肩峰数据标识符
        /// </summary>
        public static string BackTrendPoint
        {
            get
            {
                return "BackTrendPoint";
            }
        }
    }
}
