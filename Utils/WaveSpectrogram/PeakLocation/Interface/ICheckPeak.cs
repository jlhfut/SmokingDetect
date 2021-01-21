//===============================================================
// Copyright (C) 2010-2020 皖仪科技研发中心
// 文件名: IDistinguished.cs
// 日期：2011/03/09
// 描述：定义判峰算法的接口
// 版本：1.00
// 修改历史纪录

// 版本         修改时间         修改人           修改内容
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace Wayee.PeakLocation
{
    /// <summary>
    /// 判峰接口抽象接口
    /// </summary>
    public interface IPeakLocation
    {       
        /// <summary>
        /// 初始化，用于需要清除历史数据的算法
        /// </summary>
        void Init(); 
        /// <summary>
        /// 执行操作
        /// </summary>
        /// <returns></returns>
        bool Execute();
        /// <summary>
        /// 定义找到峰事件
        /// </summary>
        event PeakFoundEvent.PeakLocationEventHandler OnPeakFound;
        ///// <summary>
        ///// 判峰参数输入
        ///// </summary>
        //LocationArgs LocationParam
        //{
        //    get;
        //    set;
        //}
        /// <summary>
        /// 判峰参数传出：包含一阶二阶导数，滤波后的数据等所有参数
        /// 只读
        /// </summary>
        PeakLocationArgs PeakLocationParam
        {
            get;
            set;
        }

    }   
}
