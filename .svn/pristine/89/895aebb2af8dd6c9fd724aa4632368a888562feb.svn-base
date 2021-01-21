//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: IJudgePeak.cs
// 作者：胡凡平
// 日期：2011/03/09
// 描述：定义判峰算法的接口
// 版本：1.00
// 修改历史纪录

// 版本         修改时间         修改人           修改内容
//
//              2011-03-25        胡凡平            增加最小峰宽设定和
//                                                  峰宽自增幅度设定
//               2011-04-19       胡凡平             将起止点和峰值点修改为PointF类型
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace Wayee.WaveProcesser
{
    /// <summary>
    /// 定义判峰算法的接口
    /// </summary>
    public interface ICheckPeak
    {
        /// <summary>
        /// 判峰算法接口，需要参数：点的横坐标、纵坐标、峰增长幅度
        /// </summary>
        /// <param name="YVal">采样信号强度</param>
        /// <param name="XVal">采样信号的时间坐标</param>
        /// <param name="PWidthSte">峰宽增长速率</param>/ 
        /// <returns>返回判峰结果，true为判峰成功，否则没有找到峰</returns>
        bool CheckPeak(PointF PointData);
        /// <summary>
        /// 清除历史数据
        /// </summary>
        void ClearData();

        //       void FindPeak(PointF pointdata);

        //       void Dispose();
        /// <summary>
        /// 定义找到峰事件
        /// </summary>
        event PeakFoundEvent.PeakfoundeventHandler PeakFoundEvent;

        ///// <summary>
        ///// 数据处理的窗口长度
        ///// </summary>
        //int ProWinLength
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// 起点斜率阈值
        /// </summary>
        float StartSlopeGate
        {
            get;
            set;
        }
        /// <summary>
        /// 终点斜率阈值
        /// </summary>
        float EndSlopeGate
        {
            get;
            set;
        }
        /// <summary>
        /// 是否已经手动停止
        /// </summary>
        bool Stoped
        {
            get;
            set;
        }
        /// <summary>
        /// 设置最大窗口长度，默认值为500；
        /// 用于调整判峰分辨率
        /// </summary>
        int WindowLengthMax
        {
            get;
            set;
        }

    }
}
