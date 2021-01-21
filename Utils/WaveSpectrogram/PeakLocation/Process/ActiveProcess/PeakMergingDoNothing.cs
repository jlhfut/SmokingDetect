//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: PeakFoundEventArgs.cs
// 日期：2011/03/09
// 描述：定义峰数据还原算法
// 版本：1.00
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
    /// 提供峰数据后处理，不合并峰列表中分离度不够的峰到峰谷
    /// </summary>
    class CPeakMergingDoNothing:CPeakMergingTradition
    {
        /// <summary>
        /// construct 
        /// </summary>
        /// <param name="arges"></param>
        public CPeakMergingDoNothing(PeakLocationArgs arges)
            : base(arges)
        {

        }

        /// <summary>
        /// 不合并到峰谷
        /// </summary>
        /// <param name="srcList"></param>
        /// <param name="DetechedIndex"></param>
        /// <returns></returns>
        protected override List<PeakArgs> MergeFusionPeak(List<PeakArgs> srcList, List<int> DetechedIndex)
        {
            return srcList;
        }
    }
}
