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
    /// 基于传统积分的峰列表后处理
    /// </summary>
    class CPeakMergingAdvanced : CPeakMergingTradition
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arges"></param>
        public CPeakMergingAdvanced(PeakLocationArgs arges)
            : base(arges)
        { }

        /// <summary>
        /// 合并到峰谷，供Execute调用
        /// </summary>
        /// <param name="srcList"></param>
        /// <param name="DetechedIndex"></param>
        /// <returns></returns>
        protected override List<PeakArgs> MergeFusionPeak(List<PeakArgs> input_peak_list, List<int> detached_peak_index)
        {
            if (input_peak_list == null) return null;
            if (detached_peak_index == null) return null;
            if (detached_peak_index[detached_peak_index.Count - 1] >= input_peak_list.Count) return null;

            List<PeakArgs> _output_peak_list = new List<PeakArgs>();
            int _current_index = -1;

            //合并到峰谷
            for (int i = 0; i < detached_peak_index.Count; i++)
            {
                if (input_peak_list[i] == null) continue;
                PeakArgs _peak = new PeakArgs();

                _peak.PeakPoint = input_peak_list[_current_index + 1].PeakPoint;
                _peak.StartPoint = input_peak_list[_current_index + 1].StartPoint;
                _peak.EndPoint = input_peak_list[detached_peak_index[i]].EndPoint;
                _peak.CharacteristicPointsFlag = input_peak_list[_current_index + 1].CharacteristicPointsFlag;
                _peak.CharacteristicPoints.AddRange(input_peak_list[_current_index + 1].CharacteristicPoints);
                _peak.Type = PeakType.Detached;

                //for (int j = _current_index + 2; j <= detached_peak_index[i]; j++)
                for (int j = _current_index + 1; j <= detached_peak_index[i]; j++)
                {
                    if (input_peak_list[j].PeakPoint.Y > _peak.PeakPoint.Y)
                        _peak.PeakPoint = input_peak_list[j].PeakPoint;

                    if (input_peak_list[j].CharacteristicPoints == null) continue;
                    if (input_peak_list[j].CharacteristicPoints.Count == 0) continue;
                    if (input_peak_list[j].CharacteristicPointsFlag == null) continue;
                    if (input_peak_list[j].CharacteristicPointsFlag.Length <= 0) continue;
                    if (_peak.CharacteristicPoints.Count < 1) continue;
                    if (_peak.CharacteristicPointsFlag == null) continue;
                    if (_peak.CharacteristicPointsFlag.Length == 0) continue;

                    _peak.CharacteristicPoints.RemoveAt(_peak.CharacteristicPoints.Count - 1);
                    _peak.CharacteristicPoints.AddRange(input_peak_list[j].CharacteristicPoints);
                    _peak.CharacteristicPointsFlag = _peak.CharacteristicPointsFlag.Substring(0, _peak.CharacteristicPointsFlag.Length - 1);
                    _peak.CharacteristicPointsFlag += (PeakFlag.V.ToString() + input_peak_list[j].CharacteristicPointsFlag.Substring(1));
                    _peak.Type = PeakType.Mixed;
                }

                _output_peak_list.Add(_peak);
                _current_index = detached_peak_index[i];
            }

            return _output_peak_list;
        }
    }
}
