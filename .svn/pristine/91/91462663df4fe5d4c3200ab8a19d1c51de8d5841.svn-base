//===============================================================
// Copyright (C) 2010-2013 皖仪科技研发中心
// 文件名: QuantifyPeak.cs
// 日期：2013/10/10
// 描述：峰定量算法
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
    #region 定量分析
    #region 基类
    internal class CQuantificationBase
    {
        #region 获取响应
        /// <summary>获取峰对象响应值总和</summary>
        /// <param name="peak_list">峰对象集合</param>
        /// <param name="qm">相应值类型选择</param>
        /// <param name="sm">求和参数</param>
        /// <returns>返回求和值</returns>
        protected static double GetResponseSum(List<Peak> peak_list, PeakQuantificationMethod.QualitativeMethod qm, PeakQuantificationMethod.SumMethod sm)
        {
            double _sum = 0;

            List<Peak> _valid_peaks = null;
            switch (sm)
            {
                case PeakQuantificationMethod.SumMethod.sm_normal:
                    _valid_peaks = peak_list.FindAll(CPeakFilter.FindNaturalPeak);
                    if (_valid_peaks != null)
                    {
                        foreach (Peak _p in _valid_peaks)
                        {
                            _sum += GetResponseValue(_p, qm);
                        }
                    }
                    break;
                case PeakQuantificationMethod.SumMethod.sm_absolute_adjust:
                case PeakQuantificationMethod.SumMethod.sm_relative_adjust:
                    _valid_peaks = peak_list.FindAll(CPeakFilter.FindCheckedPeak);
                    if (_valid_peaks != null)
                    {
                        foreach (Peak _p in _valid_peaks)
                        {
                            _sum += _p.AdjustFactor * GetResponseValue(_p, qm);
                        }
                    }
                    break;
                default:
                break;
            }
            return _sum;
        }
        /// <summary>获取峰对象响应值</summary>
        /// <param name="peak_list">峰对象集合</param>
        /// <param name="qm">响应值类型选择</param>
        /// <returns>返回响应值</returns>
        protected static double GetResponseValue(Peak p, PeakQuantificationMethod.QualitativeMethod qm)
        {
            double _value = 0;
            switch (qm)
            {
                case PeakQuantificationMethod.QualitativeMethod.qm_peakArea:
                    _value = p.PeakArea;
                    break;
                case PeakQuantificationMethod.QualitativeMethod.qm_peakHeight:
                    _value = p.PeakHeight;
                    break;
                case PeakQuantificationMethod.QualitativeMethod.qm_peakAreaSquareRoot:
                    _value = Math.Sqrt(p.PeakArea);
                    break;
                case PeakQuantificationMethod.QualitativeMethod.qm_peakHeightSquareRoot:
                    _value = Math.Sqrt(p.PeakHeight);
                    break;
                default:
                    _value = 0;
                    break;
            }
            if (double.IsNaN(_value))
            {
                _value = 0;
            }
            return _value;
        }
        #endregion

        #region 计算校正因子
        /// <summary>计算指定峰绝对校正因子</summary>
        /// <param name="std_peak">峰对象</param>
        /// <param name="qm">响应值类型选择</param>
        /// <param name="adjust_factor">校正因子</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo ComputeAbsoluteAdjustFactor(Peak std_peak, PeakQuantificationMethod.QualitativeMethod qm, ref double adjust_factor)
        {
            QualitativeErrorInfo _rc = QualitativeErrorInfo.CapacityError;

            if (std_peak.Capacity >= 0 && !double.IsNaN(std_peak.Capacity))
            {
                adjust_factor = std_peak.Capacity / GetResponseValue(std_peak, qm);
                _rc = QualitativeErrorInfo.Success;
            }
            return _rc;
        }
        /// <summary>计算指定峰相对对校正因子</summary>
        /// <param name="std_peak">标准峰对象</param>
        /// <param name="internal_standard_peak">内标峰对象</param>
        /// <param name="qm">响应值类型选择</param>
        /// <param name="adjust_factor">校正因子</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo ComputeRelativeAdjustFactor(Peak std_peak, Peak internal_standard_peak, PeakQuantificationMethod.QualitativeMethod qm, ref double adjust_factor)
        {
            double _absolute_adjust_factor = 0.0;

            QualitativeErrorInfo _rc = CQuantificationExternal.ComputeAbsoluteAdjustFactor(std_peak, qm, ref _absolute_adjust_factor);
            if (_rc != QualitativeErrorInfo.Success)
                return _rc;

            if (internal_standard_peak.AdjustFactor == 0)
                return QualitativeErrorInfo.InternalStandardError;

            adjust_factor = _absolute_adjust_factor / internal_standard_peak.AdjustFactor;
            return _rc;
        }
        #endregion

        #region 计算物质的量
        /// <summary>计算指定峰的物质的量</summary>
        /// <param name="p">峰对象</param>
        /// <param name="internal_standard_peak">内标峰</param>
        /// <param name="pqm">定量参数</param>
        /// <param name="capacity">物质的量</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo Capacity(Peak p, double response, PeakQuantificationMethod.CurveFittingMethod cfm, ref double capacity)
        {
            QualitativeErrorInfo _rc = QualitativeErrorInfo.Success;

            if ((p.Coefficient == null) || (p.Coefficient.Count < 2))
            {
                capacity = p.AdjustFactor * response;
            }
            else
            {
                switch (cfm)
                {
                    case PeakQuantificationMethod.CurveFittingMethod.cfm_linear:
                    case PeakQuantificationMethod.CurveFittingMethod.cfm_quadratic:
                    case PeakQuantificationMethod.CurveFittingMethod.cfm_cubic:
                        capacity = 0;
                        for (int k = 0; k < p.Coefficient.Count; k++)
                        {
                            capacity += p.Coefficient[k] * Math.Pow(response, k);
                        }
                        break;
                    case PeakQuantificationMethod.CurveFittingMethod.cfm_log:
                        capacity = Math.Pow(10, (p.Coefficient[0] + p.Coefficient[1] * Math.Log10(response)));
                        break;
                    default:
                        _rc = QualitativeErrorInfo.CurveFitMethodError;
                        break;
                }
            }
            return _rc;
        }
        #endregion

        #region 校正曲线
        /// <summary>获取曲线拟合后的系数</summary>
        /// <param name="point_list">待拟合点</param>
        /// <param name="pqm">定量参数</param>
        /// <returns>拟合系数列表</returns>
        public static List<Double> CurveFitting(List<PointF> point_list, PeakQuantificationMethod pqm)
        {
            switch (pqm.CurveFitting_Method)
            {
                case PeakQuantificationMethod.CurveFittingMethod.cfm_linear:
                    return CLeastSquareFitting.Fitting(point_list, 1, pqm.ZeroPassage);
                case PeakQuantificationMethod.CurveFittingMethod.cfm_quadratic:
                    return CLeastSquareFitting.Fitting(point_list, 2, pqm.ZeroPassage);
                case PeakQuantificationMethod.CurveFittingMethod.cfm_cubic:
                    return CLeastSquareFitting.Fitting(point_list, 3, pqm.ZeroPassage);
                case PeakQuantificationMethod.CurveFittingMethod.cfm_log:
                    return CLogFitting.Fitting(point_list, pqm.ZeroPassage);
                default:
                    return null;
            }
        }
        /// <summary>获取校准曲线方程</summary>
        /// <param name="coefficient">系数</param>
        /// <param name="pqm">定量参数</param>
        /// <returns>校准曲线方程字符串</returns>
        public static string GetFittingFormula(List<double> coefficient, PeakQuantificationMethod pqm)
        {
            switch (pqm.CurveFitting_Method)
            {
                case PeakQuantificationMethod.CurveFittingMethod.cfm_linear:
                    return CLeastSquareFitting.GetFormula(coefficient, 1);
                case PeakQuantificationMethod.CurveFittingMethod.cfm_quadratic:
                    return CLeastSquareFitting.GetFormula(coefficient, 2);
                case PeakQuantificationMethod.CurveFittingMethod.cfm_cubic:
                    return CLeastSquareFitting.GetFormula(coefficient, 3);
                case PeakQuantificationMethod.CurveFittingMethod.cfm_log:
                    return CLogFitting.GetFormula(coefficient);
                default:
                    return null;
            }
        }
        #endregion
    }
    #endregion

    #region 百分比法
    internal class CQuantificationNormalization : CQuantificationBase
    {
        /// <summary>百分比法</summary>
        /// <param name="std_peak_list">峰对象列表</param>
        /// <param name="qm">定量参数</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo Quantitate(List<Peak> peak_list, PeakQuantificationMethod pqm)
        {
            if (peak_list == null)
                return QualitativeErrorInfo.PeakListError;

            QualitativeErrorInfo _rc = QualitativeErrorInfo.Success;

            double _sum = GetResponseSum(peak_list, pqm.Qualitative_Method, PeakQuantificationMethod.SumMethod.sm_normal);
            if (_sum == 0)
                return QualitativeErrorInfo.ResponseValueError;

            foreach (Peak _p in peak_list)
            {
                if (!CPeakFilter.FindNaturalPeak(_p)) continue;

                _p.Checked = true;
                _p.Capacity = GetResponseValue(_p, pqm.Qualitative_Method) / _sum;
            }

            return _rc;
        }
    }
    #endregion 

    #region 校正归一法
    internal class CQuantificationCorrectedNormalization : CQuantificationBase
    {
        /// <summary>归一法</summary>
        /// <param name="std_peak_list">峰对象列表</param>
        /// <param name="qm">定量参数</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo Quantitate(List<Peak> peak_list, PeakQuantificationMethod pqm)
        {
            if (peak_list == null)
                return QualitativeErrorInfo.PeakListError;

            QualitativeErrorInfo _rc = QualitativeErrorInfo.Success;

            double _sum = GetResponseSum(peak_list, pqm.Qualitative_Method, PeakQuantificationMethod.SumMethod.sm_absolute_adjust);
            if (_sum == 0)
                return QualitativeErrorInfo.CapacityError;

            //归一法首先需要定性，以确定校准因子
            foreach (Peak _p in peak_list)
            {
                if (!CPeakFilter.FindCheckedPeak(_p)) continue;

                _p.Capacity = _p.AdjustFactor * GetResponseValue(_p, pqm.Qualitative_Method) / _sum;
            }

            return _rc;
        }
    }
    #endregion

    #region 外标法
    internal class CQuantificationExternal:CQuantificationBase
    {
        #region 计算校正因子
        /// <summary>计算峰列表中每个有效峰的校正因子</summary>
        /// <param name="std_peak_list">峰对象列表</param>
        /// <param name="qm">响应值类型选择</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo GetAdjustFactor(List<Peak> std_peak_list, PeakQuantificationMethod.QualitativeMethod qm)
        {
            QualitativeErrorInfo _rc = QualitativeErrorInfo.Success;

            try
            {
                List<Peak> _valid_peaks = std_peak_list.FindAll(CPeakFilter.FindCheckedPeak);
                if (_valid_peaks != null)
                {
                    foreach (Peak _p in _valid_peaks)
                    {
                        double _factor = 0.0;

                        _rc = ComputeAbsoluteAdjustFactor(_p, qm, ref _factor);
                        if (_rc == QualitativeErrorInfo.Success)
                        {
                            _p.AdjustFactor = _factor;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                _rc = QualitativeErrorInfo.PeakListError;
            }

            return _rc;
        } 
        
        #endregion

        #region 计算物质的量
        /// <summary>计算指定峰的物质的量</summary>
        /// <param name="p">峰对象</param>
        /// <param name="qm">定量参数</param>
        /// <param name="capacity">物质的量</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo GetCapacity(Peak p, PeakQuantificationMethod pqm, ref double capacity)
        {
            double _response = GetResponseValue(p, pqm.Qualitative_Method);

            return Capacity(p, _response, pqm.CurveFitting_Method, ref capacity);
        }
        
        /// <summary>计算峰列表中峰对象所对应的物质的量</summary>
        /// <param name="peak_list">峰对象列表</param>
        /// <param name="capacity">物质的量</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo Quantitate(List<Peak> peak_list, PeakQuantificationMethod pqm)
        {
            QualitativeErrorInfo _rc = QualitativeErrorInfo.Success;
            double _capacity = 0.0;

            if (pqm.Calibration_Method != PeakQuantificationMethod.CalibrationMethod.cm_ExternalStandard)
                return QualitativeErrorInfo.CalibrationMethodError;

            //外标定量
            foreach (Peak _p in peak_list)
            {
                if (!CPeakFilter.FindCheckedPeak(_p)) continue;

                _capacity = 0.0;

                _rc = GetCapacity(_p, pqm, ref _capacity);
                if (_rc == QualitativeErrorInfo.Success)
                {
                    _p.Capacity = _capacity;
                }
            }           
            return _rc;
        }
        #endregion

        #region 校正曲线
        /// <summary>从多组标样中获取拟合曲线所需的点列表</summary>
        /// <param name="peak_list">标准样品列表</param>
        /// <param name="pqm">定量参数</param>
        /// <returns>点列表</returns>
        public static List<PointF> GetCalibrationCurve(List<Peak> peak_list, PeakQuantificationMethod.QualitativeMethod qm)
        {
            if (peak_list == null)
                return null;

            List<PointF> _point_list = new List<PointF>();

            foreach (Peak _p in peak_list)
            {
                //if (Double.IsNaN(_p.Capacity) || Double.IsInfinity(_p.Capacity) || _p.Capacity == 0)
                if (Double.IsNaN(_p.Capacity) || Double.IsInfinity(_p.Capacity)) continue;

                float _x = (float)(GetResponseValue(_p, qm));
                float _y = (float)(_p.Capacity);

                _point_list.Add(new PointF(_x, _y));
            }

            return (_point_list.Count > 0) ? _point_list : null;
        }

        /// <summary>计算校准曲线系数</summary>
        /// <param name="std_peak_list">标准峰对象列表</param>
        /// <param name="qm">定量参数</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static List<double> GetCoefficient(List<Peak> std_peak_list, PeakQuantificationMethod pqm)
        {
            if (pqm.Calibration_Method != PeakQuantificationMethod.CalibrationMethod.cm_ExternalStandard)
                return null;

            List<PointF> _point_list = GetCalibrationCurve(std_peak_list, pqm.Qualitative_Method);
            return CurveFitting(_point_list, pqm);
        }

        /// <summary>从多个标样峰列表中找出特定物质的多浓度标样峰</summary>
        /// <param name="std_papl">多个标样峰列表</param>
        /// <param name="std_name">标样名称</param>
        /// <param name="pqm">定量参数</param>
        /// <returns>同种物质的标样峰</returns>
        public static List<Peak> GetStandardPeakList(List<PeakAndPointList> std_papl, string std_name)
        {
            List<Peak> _peak_list = new List<Peak>();

            foreach (PeakAndPointList _papl in std_papl)
            {
                foreach (Peak _p in _papl.PeakList)
                {
                    if (!CPeakFilter.FindCheckedPeak(_p)) continue;

                    if (_p.Name == std_name)
                    {
                        _peak_list.Add(_p);
                    }
                }
            }           
            
            return (_peak_list.Count > 0) ? _peak_list : null;
        }
        #endregion
    }
    #endregion

    #region 内标法
    internal class CQuantificationInternal : CQuantificationBase
    {
        #region 计算校正因子
        /// <summary>计算峰列表中每个有效峰的相对校正因子</summary>
        /// <param name="std_peak_list">标准峰对象列表</param>
        /// <param name="qm">响应值类型选择</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo GetAdjustFactor(List<Peak> std_peak_list, PeakQuantificationMethod.QualitativeMethod qm)
        {
            QualitativeErrorInfo _rc = QualitativeErrorInfo.Success;
            double _factor = 0.0;

            if (std_peak_list == null)
                return QualitativeErrorInfo.PeakListError;

            //至少包含一个内标物和被测物
            if (std_peak_list.Count < 2)
                return QualitativeErrorInfo.PeakListError;

            //查找内标物
            Peak _internal_standard_peak = std_peak_list.Find(CPeakFilter.FindInternalStandardPeak);
            if (_internal_standard_peak == null)
                return QualitativeErrorInfo.InternalStandardError;

            //计算内标物的绝对校正因子
            _rc = CQuantificationBase.ComputeAbsoluteAdjustFactor(_internal_standard_peak, qm, ref _factor);
            if (_rc != QualitativeErrorInfo.Success)
                return QualitativeErrorInfo.InternalStandardError;

            _internal_standard_peak.AdjustFactor = _factor;

            //计算未知物的校正因子(注意未知物列表要剔除内标物)
            foreach (Peak _p in std_peak_list)
            {
                if (!CPeakFilter.FindCheckedPeak(_p) || ((_p.InternalStandard != null) && (_p.InternalStandard != ""))) continue;

                _factor = 0.0;

                _rc = CQuantificationBase.ComputeRelativeAdjustFactor(_p, _internal_standard_peak, qm, ref _factor);
                if (_rc == QualitativeErrorInfo.Success)
                {
                    _p.AdjustFactor = _factor;
                }
            }

            return _rc;
        }
        #endregion

        #region 计算物质的量
        /// <summary>计算指定峰的物质的量</summary>
        /// <param name="p">峰对象</param>
        /// <param name="internal_standard_peak">内标峰</param>
        /// <param name="pqm">定量参数</param>
        /// <param name="capacity">物质的量</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo GetCapacity(Peak p, Peak internal_standard_peak, PeakQuantificationMethod pqm, ref double capacity)
        {
            if ((p == null) || (internal_standard_peak == null))
                return QualitativeErrorInfo.PeakObjectError;

            double _internal_standard_response = GetResponseValue(internal_standard_peak, pqm.Qualitative_Method);
            if (_internal_standard_response == 0)
                return QualitativeErrorInfo.InternalStandardError;

            double _response = internal_standard_peak.Capacity / _internal_standard_response * GetResponseValue(p, pqm.Qualitative_Method);

            return Capacity(p, _response, pqm.CurveFitting_Method, ref capacity);
        }

        /// <summary>计算峰列表中所有有效峰对应的物质的量</summary>
        /// <param name="peak_list">峰对象列表</param>
        /// <param name="capacity">物质的量</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo Quantitate(List<Peak> peak_list, PeakQuantificationMethod pqm)
        {
            QualitativeErrorInfo _rc = QualitativeErrorInfo.Success;
            double _capacity = 0.0;

            if (pqm.Calibration_Method != PeakQuantificationMethod.CalibrationMethod.cm_InternalStandard)
                return QualitativeErrorInfo.CalibrationMethodError;

            //内标定量
            Peak _internal_standard_peak = peak_list.Find(CPeakFilter.FindInternalStandardPeak);

            //if ((_internal_standard_peak == null) || (_internal_standard_peak.AdjustFactor == 0))
            if (_internal_standard_peak == null)
                return QualitativeErrorInfo.InternalStandardError;

            foreach (Peak _p in peak_list)
            {
                if (!CPeakFilter.FindCheckedPeak(_p) || ((_p.InternalStandard != null) && (_p.InternalStandard != ""))) continue;

                _capacity = 0.0;

                _rc = GetCapacity(_p, _internal_standard_peak, pqm, ref _capacity);
                if (_rc == QualitativeErrorInfo.Success)                
                {
                    _p.Capacity = _capacity;
                }
            }

            return _rc;
        }
        #endregion

        #region 校正曲线
        /// <summary>从多组标样中获取拟合曲线所需的点列表</summary>
        /// <param name="peak_list">标准样品列表</param>
        /// <param name="pqm">定量参数</param>
        /// <returns>点列表</returns>
        public static List<PointF> GetCalibrationCurve(List<Peak> peak_list, PeakQuantificationMethod.QualitativeMethod qm)
        {
            if (peak_list == null)
                return null;

            List<PointF> _point_list = new List<PointF>();

            if ((peak_list.Count % 2) != 0)
                return null;

            for (int i = 0; i < peak_list.Count; i += 2)
            {
                Peak _p = peak_list[i];

                //if (Double.IsNaN(_p.Capacity) || Double.IsInfinity(_p.Capacity) || _p.Capacity == 0)
                if (Double.IsNaN(_p.Capacity) || Double.IsInfinity(_p.Capacity)) continue;

                Peak _isp = peak_list[i + 1];

                float _x = (float)(GetResponseValue(_p, qm) * _isp.Capacity / GetResponseValue(_isp, qm));
                float _y = (float)(_p.Capacity);

                _point_list.Add(new PointF(_x, _y));
            }            

            return (_point_list.Count > 0) ? _point_list : null;
        }

        /// <summary>计算校准曲线系数</summary>
        /// <param name="std_peak_list">标准峰对象列表</param>
        /// <param name="qm">定量参数</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static List<double> GetCoefficient(List<Peak> std_peak_list, PeakQuantificationMethod pqm)
        {
            if (pqm.Calibration_Method != PeakQuantificationMethod.CalibrationMethod.cm_InternalStandard)
                return null;

            List<PointF> _point_list = GetCalibrationCurve(std_peak_list, pqm.Qualitative_Method);
            return CurveFitting(_point_list, pqm);
        }

        /// <summary>从多个标样峰列表中找出特定物质的多浓度标样峰</summary>
        /// <param name="std_papl">多个标样峰列表</param>
        /// <param name="std_name">标样名称</param>
        /// <param name="pqm">定量参数</param>
        /// <returns>同种物质的标样峰</returns>
        public static List<Peak> GetStandardPeakList(List<PeakAndPointList> std_papl, string std_name)
        {
            List<Peak> _peak_list = new List<Peak>();

            foreach (PeakAndPointList _papl in std_papl)
            {
                Peak _isp = _papl.PeakList.Find(CPeakFilter.FindInternalStandardPeak);
                if (_isp == null)
                    continue;

                foreach (Peak _p in _papl.PeakList)
                {
                    if (!CPeakFilter.FindCheckedPeak(_p)) continue;

                    if (_p.Name == std_name)
                    {
                        _peak_list.Add(_p);
                        _peak_list.Add(_isp);
                    }
                }
            }

            return (_peak_list.Count > 0) ? _peak_list : null;
        }
        #endregion
    }
    #endregion

    #region 工厂
    public class CQuantificationFactory
    {
        /// <summary>计算峰列表中每个有效峰的校正因子</summary>
        /// <param name="std_peak_list">标准峰对象列表</param>
        /// <param name="qm">定量参数</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo GetAdjustFactor(List<Peak> peak_list, PeakQuantificationMethod pqm)
        {
            switch (pqm.Calibration_Method)
            { 
                case PeakQuantificationMethod.CalibrationMethod.cm_CorrectedNormalization:
                case PeakQuantificationMethod.CalibrationMethod.cm_ExternalStandard:
                    return CQuantificationExternal.GetAdjustFactor(peak_list, pqm.Qualitative_Method);
                case PeakQuantificationMethod.CalibrationMethod.cm_CorrectedNormalizationWithISD:
                case PeakQuantificationMethod.CalibrationMethod.cm_InternalStandard:
                    return CQuantificationInternal.GetAdjustFactor(peak_list, pqm.Qualitative_Method);
                default:
                    return QualitativeErrorInfo.CalibrationMethodError;
            }
        }
        /// <summary>计算峰列表中所有有效峰对应的物质的量</summary>
        /// <param name="peak_list">峰对象列表</param>
        /// <param name="capacity">物质的量</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo Quantitate(List<Peak> peak_list, PeakQuantificationMethod pqm)
        {
            switch (pqm.Calibration_Method)
            {
                case PeakQuantificationMethod.CalibrationMethod.cm_Normalization:
                    return CQuantificationNormalization.Quantitate(peak_list, pqm);
                case PeakQuantificationMethod.CalibrationMethod.cm_CorrectedNormalization:
                case PeakQuantificationMethod.CalibrationMethod.cm_CorrectedNormalizationWithISD:
                    return CQuantificationCorrectedNormalization.Quantitate(peak_list, pqm);
                case PeakQuantificationMethod.CalibrationMethod.cm_ExternalStandard:
                    return CQuantificationExternal.Quantitate(peak_list, pqm);
                case PeakQuantificationMethod.CalibrationMethod.cm_InternalStandard:
                    return CQuantificationInternal.Quantitate(peak_list, pqm);
                default:
                    return QualitativeErrorInfo.CalibrationMethodError;
            }
        }

        /// <summary>从多组标样中获取拟合曲线所需的点列表</summary>
        /// <param name="peak_list">标准样品列表</param>
        /// <param name="pqm">定量参数</param>
        /// <returns>点列表</returns>
        public static List<PointF> GetCalibrationCurve(List<Peak> peak_list, PeakQuantificationMethod pqm)
        {
            switch(pqm.Calibration_Method)
            {
                case PeakQuantificationMethod.CalibrationMethod.cm_ExternalStandard:
                    return CQuantificationExternal.GetCalibrationCurve(peak_list, pqm.Qualitative_Method);
                case PeakQuantificationMethod.CalibrationMethod.cm_InternalStandard:
                    return CQuantificationInternal.GetCalibrationCurve(peak_list, pqm.Qualitative_Method);
                default:
                    return null;
            }
        }

        /// <summary>计算校准曲线系数</summary>
        /// <param name="std_peak_list">标准峰对象列表</param>
        /// <param name="pqm">定量参数</param>
        /// <returns>返回系数列表</returns>
        public static List<double> GetCoefficient(List<Peak> peak_list, PeakQuantificationMethod pqm)
        {
            switch (pqm.Calibration_Method)
            {
                case PeakQuantificationMethod.CalibrationMethod.cm_ExternalStandard:
                    return CQuantificationExternal.GetCoefficient(peak_list, pqm);
                case PeakQuantificationMethod.CalibrationMethod.cm_InternalStandard:
                    return CQuantificationInternal.GetCoefficient(peak_list, pqm);
                default:
                    return null;
            }
        }

        /// <summary>从多个标样峰列表中找出特定物质的多浓度标样峰</summary>
        /// <param name="std_papl">多个标样峰列表</param>
        /// <param name="std_name">标样名称</param>
        /// <param name="pqm">定量参数</param>
        /// <returns>同种物质的标样峰列表</returns>
        public static List<Peak> GetStandardPeakList(List<PeakAndPointList> std_papl, string std_name, PeakQuantificationMethod pqm)
        {
            switch (pqm.Calibration_Method)
            {
                case PeakQuantificationMethod.CalibrationMethod.cm_ExternalStandard:
                    return CQuantificationExternal.GetStandardPeakList(std_papl, std_name);
                case PeakQuantificationMethod.CalibrationMethod.cm_InternalStandard:
                    return CQuantificationInternal.GetStandardPeakList(std_papl, std_name);
                default:
                    return null;
            }
        }

        /// <summary>获取校准曲线方程</summary>
        /// <param name="coefficient">系数</param>
        /// <param name="pqm">定量参数</param>
        /// <returns>校准曲线方程字符串</returns>
        public static string GetFittingFormula(List<double> coefficient, PeakQuantificationMethod pqm)
        {
            return CQuantificationBase.GetFittingFormula(coefficient, pqm);
        }
    }
    #endregion
    #endregion
}
