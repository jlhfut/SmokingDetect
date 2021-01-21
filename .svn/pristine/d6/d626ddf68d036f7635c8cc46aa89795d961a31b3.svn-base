//===============================================================
// Copyright (C) 2010-2013 皖仪科技研发中心
// 文件名: IdentifyPeak.cs
// 日期：2013/10/10
// 描述：峰定性算法
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wayee.PeakObject;
using System.Drawing;
using System.Diagnostics;

namespace Wayee.ResultAnalyzer
{
    #region 定性分析

    #region 峰选择
    internal class CPeakSelect
    {
        /// <summary>选择与指定保留时间最接近的峰</summary>
        /// <param name="peak_list">峰对象列表</param>
        /// <param name="std_rt">保留时间</param>
        /// <returns>返回符合要求的峰对象</returns>
        private static Peak Closest(List<Peak> peak_list, double std_rt)
        {            
            double _delta_time = 0.0, _min_delta_time = 0.0;

            _min_delta_time = Math.Abs(std_rt - peak_list[0].PeakPoint.X);
            Peak peak = peak_list[0];

            for (int i = 1; i < peak_list.Count; i++)
            {
                _delta_time = Math.Abs(std_rt - peak_list[i].PeakPoint.X);
                if (_delta_time < _min_delta_time)
                {
                    _min_delta_time = _delta_time;
                    peak = peak_list[i];
                }
            }

            return peak;
        }
        /// <summary>选择峰列表中面积最大的峰</summary>
        /// <param name="peak_list">峰对象列表</param>
        /// <returns>返回符合要求的峰对象</returns>
        private static Peak Largest(List<Peak> peak_list)
        {
            double _peak_area = 0.0, _max_peak_area = 0.0;

            _max_peak_area = peak_list[0].PeakArea;
            Peak peak = peak_list[0];

            for (int i = 1; i < peak_list.Count; i++)
            {
                _peak_area = peak_list[i].PeakArea;
                if (_peak_area > _max_peak_area)
                {
                    _max_peak_area = _peak_area;
                    peak = peak_list[i];
                }
            }
            return peak;
        }
        /// <summary>按指定方法选择峰对象</summary>
        /// <param name="peak_list">峰对象列表</param>
        /// <param name="std_rt">保留时间</param>
        /// <param name="psm">峰选择方法</param>
        /// <returns>返回符合要求的峰对象</returns>
        public static Peak PeakSelect(List<Peak> peak_list, double std_rt, PeakIdentificationMethod.PeakSelectMethod psm)
        {
            if ((peak_list == null) || (peak_list.Count == 0))
                return null;

            switch (psm)
            { 
                case PeakIdentificationMethod.PeakSelectMethod.psm_largest:
                    return Largest(peak_list);
                case PeakIdentificationMethod.PeakSelectMethod.psm_closest:
                default:
                    return Closest(peak_list, std_rt);
            }          
        }
    }
    #endregion

    #region 时间窗
    internal class CTimeBand
    {
        /// <summary>获取时间窗口</summary>
        /// <param name="rt">保留时间</param>
        /// <param name="pim">定性方法</param>
        /// <returns></returns>
        public static double GetTimeBand(double rt, PeakIdentificationMethod pim)
        {
            double _band = 0.0;

            if (pim.Time_Method == PeakIdentificationMethod.TimeMethod.tm_window)
            {
                _band = rt * pim.TimeWindow;
            }
            else
            {
                _band = pim.TimeBand;
            }

            return _band;
        }
    }
    #endregion    

    #region 绝对保留时间定性
    internal class CIdentificationAbsolute
    {
        #region 私有方法
        /// <summary>更新峰信息</summary>
        /// <param name="target">目标峰对象</param>
        /// <param name="std">标准峰对象</param>
        /// <returns></returns>
        protected void UpdatePeakInfo(Peak target, Peak std, bool Checked)
        {
            target.Checked = Checked;
            target.Name = std.Name;            
            target.InternalStandard = std.InternalStandard;
            target.ReferencePeak = std.ReferencePeak;
            target.FittingFormula = std.FittingFormula;
            target.Coefficient = null;

            if ((std.Coefficient != null) && (std.Coefficient.Count > 0))
            {
                target.Coefficient = std.Coefficient.GetRange(0, std.Coefficient.Count);
            }
            else
            { 
                target.AdjustFactor = std.AdjustFactor;            
            }
            return;
        }
        #endregion

        /// <summary>绝对保留时间定性方法</summary>
        /// <param name="peakList">未知样峰对象列表</param>
        /// <param name="std_rt">保留时间</param>
        /// <param name="pim">定性参数</param>
        /// <returns>成功匹配的峰对象</returns>
        public Peak IdentifyPeak(List<Peak> peak_list, double std_rt, double next_std_rt, PeakIdentificationMethod pim)
        {
            if (peak_list == null)
                return null;

            List<Peak> _target_peak_list = new List<Peak>();

            double _band = CTimeBand.GetTimeBand(std_rt, pim);
            double _delta_time = 0.0, _delta_time_for_next_std = 0.0;

            foreach (Peak _p in peak_list)
            {
                //if (!FilterPeak(_p)) continue;

                _delta_time = Math.Abs(std_rt - _p.PeakPoint.X);
                _delta_time_for_next_std = Math.Abs(next_std_rt - _p.PeakPoint.X);

                if ((_delta_time <= _band) && (_delta_time <= _delta_time_for_next_std))
                {
                    _target_peak_list.Add(_p);
                }
            }

            return CPeakSelect.PeakSelect(_target_peak_list, std_rt, pim.PeakSelect_Method);
        }
        /// <summary>绝对保留时间定性方法</summary>
        /// <param name="std_peak_list">标样峰对象列表</param>
        /// <param name="unknown_peak_list">未知样峰对象列表</param>
        /// <param name="pim">定性参数</param>
        /// <returns>返回识别的峰列表</returns>
        public virtual List<Peak> IdentifyPeakList(List<Peak> std_peak_list, List<Peak> unknown_peak_list, PeakIdentificationMethod pim)
        {
            try
            {
                //获取有效峰列表
                List<Peak> _standard_list = std_peak_list.FindAll(CPeakFilter.FindCheckedPeak);
                if (_standard_list == null) return null;

                List<Peak> _unknown_list = unknown_peak_list.FindAll(CPeakFilter.FindNaturalPeak);
                if (_unknown_list == null) return null;

                List<Peak> _target_list = new List<Peak>();

                //峰匹配过程
                Peak _p, _pnext;
                double next_sdt_rt = 0.0;

                for (int i = 0; i < _standard_list.Count; i++)
                {
                    _p = _standard_list[i];

                    if (i < (_standard_list.Count - 1))
                    {
                        _pnext = _standard_list[i + 1];
                        next_sdt_rt = _pnext.PeakPoint.X;
                    }
                    else
                    {
                        next_sdt_rt = double.MaxValue;
                    }

                    Peak _target_peak = IdentifyPeak(_unknown_list, _p.PeakPoint.X, next_sdt_rt, pim);
                    if (_target_peak != null)
                    {
                        UpdatePeakInfo(_target_peak, _p, true);
                        //将已经匹配过的峰从列表中移出，加速匹配过程
                        _unknown_list.RemoveRange(0, _unknown_list.IndexOf(_target_peak) + 1);
                        _target_list.Add(_target_peak);
                    }
                }
                return (_target_list.Count > 0) ? _target_list : null;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
    #endregion

    #region 相对保留时间定性
    internal class CIdentificationRelative : CIdentificationAbsolute
    {
        /// <summary>相对保留时间定性方法，单参考峰</summary>
        /// <param name="peak_list">未知样峰对象列表</param>
        /// <param name="std_ref">标样中的参考峰</param>
        /// <param name="measure_ref">未知样中的参考峰</param>
        /// <param name="std_rt">保留时间</param>
        /// <param name="pim">定性参数</param>
        /// <returns>成功匹配的峰对象</returns>
        public Peak IdentifyPeak(List<Peak> peak_list, Peak std_ref, Peak unknown_ref, double std_rt, PeakIdentificationMethod pim)
        {
            if ((std_ref == null) || (unknown_ref == null) || (peak_list == null))
                return null;

            if (unknown_ref.PeakPoint.X == 0)
                return null;

            List<Peak> _target_list = new List<Peak>();

            double _band = CTimeBand.GetTimeBand(std_rt, pim);
            double _delta_time = 0.0;

            foreach (Peak _p in peak_list)
            {
                //if (!FilterPeak(_p)) continue;

                _delta_time = Math.Abs(std_rt - (std_ref.PeakPoint.X / unknown_ref.PeakPoint.X) * _p.PeakPoint.X);

                if (_delta_time <= _band)
                {
                    _target_list.Add(_p);
                }
            }

            return CPeakSelect.PeakSelect(_target_list, std_rt, pim.PeakSelect_Method);
        }
        /// <summary>相对保留时间定性方法，多参考峰</summary>
        /// <param name="peak_list">未知样峰对象列表</param>
        /// <param name="std_ref_list">标样中的参考峰列表</param>
        /// <param name="measure_ref_list">未知样中的参考峰列表</param>
        /// <param name="std_rt">保留时间</param>
        /// <param name="pim">定性参数</param>
        /// <returns>成功匹配的峰对象</returns>
        public Peak IdentifyPeak(List<Peak> peak_list, List<Peak> std_ref_list, List<Peak> unknown_ref_list, double std_rt, PeakIdentificationMethod pim)
        {
            if ((peak_list == null) || (std_ref_list == null) || (unknown_ref_list == null))
                return null;

            if ((std_ref_list.Count != 2) || (unknown_ref_list.Count != 2))
                return null;

            List<Peak> _target_list = new List<Peak>();

            double _band = CTimeBand.GetTimeBand(std_rt, pim);
            double _corr_rt = 0.0, _delta_time = 0.0;

            foreach (Peak _p in peak_list)
            {
                //if (!FilterPeak(_p)) continue;

                _corr_rt = ((_p.PeakPoint.X - unknown_ref_list[0].PeakPoint.X) / (unknown_ref_list[1].PeakPoint.X - unknown_ref_list[0].PeakPoint.X)) * (std_ref_list[1].PeakPoint.X - std_ref_list[0].PeakPoint.X) + std_ref_list[0].PeakPoint.X;
                _delta_time = Math.Abs(_corr_rt - std_rt);

                if (_delta_time <= _band)
                {
                    _target_list.Add(_p);
                }
            }

            return CPeakSelect.PeakSelect(_target_list, std_rt, pim.PeakSelect_Method);
        }
        /// <summary>相对保留时间定性方法，单参考峰</summary>
        /// <param name="std_peak_list">标样峰列表</param>
        /// <param name="unknown_peak_list">未知样峰列表</param>
        /// <param name="std_ref">标样中的参考峰</param>
        /// <param name="unknown_ref">未知样中的参考峰</param>
        /// <param name="pim">定性参数</param>
        /// <returns>成功匹配的峰对象</returns>
        public List<Peak> IdentifyPeakList(List<Peak> std_peak_list, List<Peak> unknown_peak_list, Peak std_ref, Peak unknown_ref, PeakIdentificationMethod pim)
        {
            if ((std_peak_list == null) || (unknown_peak_list == null))
                return null;

            //获取有效峰列表
            List<Peak> _standard_list = std_peak_list.FindAll(CPeakFilter.FindCheckedPeak);
            if (_standard_list == null) return null;

            List<Peak> _unknown_list = unknown_peak_list.FindAll(CPeakFilter.FindNaturalPeak);
            if (_unknown_list == null) return null;

            List<Peak> _target_list = new List<Peak>();

            foreach (Peak _p in std_peak_list)
            {
                Peak _target_peak = IdentifyPeak(_unknown_list, std_ref, unknown_ref, _p.PeakPoint.X, pim);
                if (_target_peak != null)
                {
                    UpdatePeakInfo(_target_peak, _p, true);
                    _unknown_list.RemoveRange(0, _unknown_list.IndexOf(_target_peak) + 1);
                    _target_list.Add(_target_peak);
                }
            }
            return (_target_list.Count > 0) ? _target_list : null;
        }
        /// <summary>相对保留时间定性方法</summary>
        /// <param name="std_pl">标样峰对象列表</param>
        /// <param name="unknown_pl">未知样峰对象列表</param>
        /// <param name="pim">定性参数</param>
        /// <returns>QualitativeErrorInfo枚举</returns>
        public override List<Peak> IdentifyPeakList(List<Peak> std_peak_list, List<Peak> unknown_peak_list, PeakIdentificationMethod pim)
        {
            try
            {
                List<Peak> _valid_standard_list = std_peak_list.FindAll(CPeakFilter.FindCheckedPeak);   //获取标样峰列表中的有效峰
                List<Peak> _valid_unknown_list = unknown_peak_list.FindAll(CPeakFilter.FindNaturalPeak);//获取未知样峰列表中的有效峰
                List<Peak> _std_ref_list = _valid_standard_list.FindAll(CPeakFilter.FindReferencePeak); //查找标样中的参考峰

                //定性未知样中的参考物
                List<Peak> _unknown_ref_list = base.IdentifyPeakList(_std_ref_list, _valid_unknown_list, pim);
                if ((_unknown_ref_list == null) || (_unknown_ref_list.Count == 0) || (_unknown_ref_list.Count != _std_ref_list.Count))
                    return null;

                List<Peak> _target_list = new List<Peak>();

                //定性未知样中的其他物质
                //______/\_________/\_________/\___________    

                int _standard_ref_index = _valid_standard_list.IndexOf(_std_ref_list[0]);
                int _unknown_ref_index = _valid_unknown_list.IndexOf(_unknown_ref_list[0]);

                List<Peak> _valid_standard_peaks = _valid_standard_list.GetRange(0, _standard_ref_index);    //第一个参考峰之前的标准峰                
                List<Peak> _valid_unknown_peaks = _valid_unknown_list.GetRange(0, _unknown_ref_index);   //第一个参考峰之前的未知峰

                //定性第一个参考峰之前的未知峰，单参考峰定性方法
                List<Peak> _return_peaks = IdentifyPeakList(_valid_standard_peaks, _valid_unknown_peaks, _std_ref_list[0], _unknown_ref_list[0], pim);

                _valid_standard_list.RemoveRange(0, _standard_ref_index);
                _valid_unknown_list.RemoveRange(0, _unknown_ref_index);

                if (_return_peaks != null) _target_list.AddRange(_return_peaks);

                //两个参考峰之间的标准峰
                for (int i = 0; i < _std_ref_list.Count - 1; i++)
                {
                    _standard_ref_index = _valid_standard_list.IndexOf(_std_ref_list[i]) + 1;
                    _unknown_ref_index = _valid_unknown_list.IndexOf(_unknown_ref_list[i]) + 1;

                    int _standard_peaks = _valid_standard_list.IndexOf(_std_ref_list[i + 1]) - _standard_ref_index;
                    if (_standard_peaks == 0) continue;

                    int _unknown_peaks = _valid_unknown_list.IndexOf(_unknown_ref_list[i + 1]) - _unknown_ref_index;
                    if (_unknown_peaks == 0) continue;

                    _valid_standard_peaks = _valid_standard_list.GetRange(_standard_ref_index, _standard_peaks);
                    if (_valid_standard_peaks == null) continue;

                    _valid_unknown_peaks = _valid_unknown_list.GetRange(_unknown_ref_index, _unknown_peaks);
                    if (_valid_unknown_peaks == null) continue;

                    List<Peak> _standard_ref_tmp = _std_ref_list.GetRange(i, 2);
                    List<Peak> _unknown_ref_tmp = _unknown_ref_list.GetRange(i, 2);

                    foreach (Peak _p in _valid_standard_peaks)
                    {
                        Peak _target_peak = IdentifyPeak(_valid_unknown_peaks, _standard_ref_tmp, _unknown_ref_tmp, _p.PeakPoint.X, pim);
                        if (_target_peak != null)
                        {
                            UpdatePeakInfo(_target_peak, _p, true);
                            _valid_unknown_peaks.RemoveRange(0, _valid_unknown_peaks.IndexOf(_target_peak) + 1);
                            _target_list.Add(_target_peak);
                        }
                    }
                }

                //最后一个参考峰之后的标准峰
                int _last_index = _std_ref_list.Count - 1;

                _standard_ref_index = _valid_standard_list.IndexOf(_std_ref_list[_last_index]);
                _unknown_ref_index = _valid_unknown_list.IndexOf(_unknown_ref_list[_last_index]);

                _valid_standard_peaks = _valid_standard_list.GetRange(_standard_ref_index, _valid_standard_list.Count - _standard_ref_index - 1); //最后一个参考峰之后的未知峰
                _valid_unknown_peaks = _valid_unknown_list.GetRange(_unknown_ref_index, _valid_unknown_list.Count - _unknown_ref_index - 1); //定性最后一个参考峰之后的未知峰

                _return_peaks = IdentifyPeakList(_valid_standard_peaks, _valid_unknown_peaks, _std_ref_list[_last_index], _unknown_ref_list[_last_index], pim);

                if (_return_peaks != null) _target_list.AddRange(_return_peaks);

                return (_target_list.Count > 0) ? _target_list : null;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
    #endregion

    #region 工厂
    public class CIdentificationFactory
    {
        private static CIdentificationRelative _IdRelative = new CIdentificationRelative();
        private static CIdentificationAbsolute _IdAbsolute = new CIdentificationAbsolute();
        /// <summary>定性方法</summary>
        /// <param name="std_pl">标样峰对象列表</param>
        /// <param name="unknown_pl">未知样峰对象列表</param>
        /// <param name="pim">定性参数</param>
        /// <returns>返回识别峰列表</returns>
        public static List<Peak> Identify(List<Peak> std_peak_list, List<Peak> unknown_peak_list, PeakIdentificationMethod pim)
        {
            switch (pim.Identification_Method)
            {
                case PeakIdentificationMethod.IdentificationMethod.im_relative:
                    //return CIdentificationRelative.IdentifyPeakList(std_peak_list, unknown_peak_list, pim);
                    return _IdRelative.IdentifyPeakList(std_peak_list, unknown_peak_list, pim);
                case PeakIdentificationMethod.IdentificationMethod.im_absolute:
                default:
                    return _IdAbsolute.IdentifyPeakList(std_peak_list, unknown_peak_list, pim);
                    //return CIdentificationAbsolute.IdentifyPeakList(std_peak_list, unknown_peak_list, pim);
            }
        }
    }
    #endregion

    #endregion
}
