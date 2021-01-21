//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: PeakFoundEventArgs.cs
// 作者：胡凡平
// 日期：2011/03/09
// 描述：定义找到峰后出发的事件
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
    public class PeakFoundEvent
    {
        /// <summary>
        /// 定义事件句柄，搜索到峰值时触发的事件
        /// </summary>
        /// <param name="sender">目前没有意义，只是看到系统有这个参数，照个样子吧</param>
        /// <param name="e">包含峰参数的一个数据结构吧</param>
        public delegate void PeakfoundeventHandler(object sender,List <PeakFoundEventArgs> e);
    }
}
