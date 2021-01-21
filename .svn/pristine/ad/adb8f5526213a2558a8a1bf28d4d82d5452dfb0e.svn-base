//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: PeakObjectCalculator.cs
// 日期：2011/03/04
// 描述：峰对象计算、定量计算
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
// 
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
    #region 错误提示信息
    /// <summary>
    /// 定量计算不符合条件信息提示
    /// </summary>
    public enum QualitativeErrorInfo
    {
        /// <summary>计算正常</summary>
        Success = 0,
        /// <summary>计算方法选择错误</summary>
        CalculationMethodError,
        /// <summary>校准方法选择错误</summary>
        CalibrationMethodError,
        /// <summary>曲线拟合方法选择错误</summary>
        CurveFitMethodError,
        /// <summary>定性峰失败</summary>
        IdentifyPeakError,
        /// <summary>浓度为空或为0</summary>
        ConcentrationEmpty,
        /// <summary>内标设置错误</summary>
        InternalStandardError,
        /// <summary>保留时间错误</summary>
        RetentionTimeError,
        /// <summary>响应值错误</summary>
        ResponseValueError,
        /// <summary>标样信息错误</summary>
        StandardSampleError,
        /// <summary>无参考峰错误或参考峰信息错误</summary>
        ReferencePeakError,
        /// <summary>物质的量信息错误</summary>
        CapacityError,
        /// <summary>峰列表对象为空</summary>
        PeakListError,
        /// <summary>峰对象为空</summary>
        PeakObjectError,
        /// <summary>峰曲线为空</summary>
        PeakCurveError,
        /// <summary>校准曲线系数错误</summary>
        CoefficientError,
        /// <summary>峰信息计算错误</summary>
        ComputePeakInfoError,
    }
    #endregion

    #region 峰计算方法
    [Serializable]
    public class PeakCalculationMethod
    {
        /// <summary>药典选择</summary>
        public enum PharmacopeiaMethod
        {
            /// <summary>美国药典</summary>
            pm_usp = 0,
            /// <summary>日本药典</summary>
            pm_japan,
            /// <summary>日本药典2</summary>
            pm_japan2,
            /// <summary>中国药典</summary>
            pm_china,
        };
        /// <summary>死时间选择</summary>
        public enum DeadTimeMethod
        {
            /// <summary>选择第一个峰</summary>
            dtm_first_peak = 0,
            /// <summary>指定时间</summary>
            dtm_set_time,
        }

        private PharmacopeiaMethod _pharmacopeiaMethod = PharmacopeiaMethod.pm_usp;

        public PharmacopeiaMethod Pharmacopeia_Method
        {
            set { _pharmacopeiaMethod = value; }
            get { return _pharmacopeiaMethod; }
        }

        private DeadTimeMethod _deadTimeMethod = DeadTimeMethod.dtm_first_peak;

        public DeadTimeMethod DeadTime_Method
        {
            set { _deadTimeMethod = value; }
            get { return _deadTimeMethod; }
        }

        private double _deadTime = 0.0;

        public double DeadTime
        {
            set { _deadTime = value; }
            get { return _deadTime; }
        }
    }
    #endregion

    #region 定性方法
    [Serializable]
    public class PeakIdentificationMethod
    {
        /// <summary>时间窗口方法</summary>
        public enum TimeMethod
        {
            /// <summary>时间窗</summary>
            tm_window = 0,
            /// <summary>时间带</summary>
            tm_band
        };
        /// <summary>定性方法</summary>
        public enum IdentificationMethod
        {
            /// <summary>绝对保留时间定性方法</summary>
            im_absolute = 0,
            /// <summary>相对保留时间定性方法</summary>
            im_relative
        };
        /// <summary>峰选择方法</summary>
        public enum PeakSelectMethod
        {
            /// <summary>选择最近峰</summary>
            psm_closest,
            /// <summary>选择最大峰</summary>
            psm_largest
        };

        private TimeMethod _timeMethod = TimeMethod.tm_window;

        public TimeMethod Time_Method
        {
            set { _timeMethod = value; }
            get { return _timeMethod; }
        }

        private IdentificationMethod _identificationMethod = IdentificationMethod.im_absolute;

        public IdentificationMethod Identification_Method
        {
            set { _identificationMethod = value; }
            get { return _identificationMethod; }
        }

        private PeakSelectMethod _peakSelectMethod = PeakSelectMethod.psm_closest;

        public PeakSelectMethod PeakSelect_Method
        {
            set { _peakSelectMethod = value; }
            get { return _peakSelectMethod; }
        }

        private double _timeWindow = 0.03;  //%3

        public double TimeWindow
        {
            set { _timeWindow = value; }
            get { return _timeWindow; }
        }

        private double _timeBand = 10;    //second

        public double TimeBand
        {
            set { _timeBand = value; }
            get { return _timeBand; }
        }
    }
    #endregion

    #region 定量方法
    [Serializable]
    public class PeakQuantificationMethod
    {
        /// <summary>峰对象列表求和</summary>
        public enum SumMethod
        {
            /// <summary>百分比法</summary>
            sm_normal = 0,
            /// <summary>绝对校正因子</summary>
            sm_absolute_adjust,
            /// <summary>相对校正因子</summary>
            sm_relative_adjust,
        }

        /// <summary>定量计算方法</summary>
        public enum QualitativeMethod
        {
            /// <summary>峰面积</summary>
            qm_peakArea = 0,
            /// <summary>峰高</summary>
            qm_peakHeight,
            /// <summary>峰面积平方根</summary>
            qm_peakAreaSquareRoot,
            /// <summary>峰高平方根</summary>
            qm_peakHeightSquareRoot,
        }

        /// <summary>曲线拟合方法</summary>
        public enum CurveFittingMethod
        {
            /// <summary>线性拟合</summary>
            cfm_linear = 0,
            /// <summary>二次曲线拟合</summary>
            cfm_quadratic,
            /// <summary>三次曲线拟合</summary>
            cfm_cubic,
            /// <summary>对数拟合</summary>
            cfm_log
        }

        /// <summary>校准方法</summary>
        public enum CalibrationMethod
        {
            /// <summary>百分比法</summary>
            cm_Normalization = 0,
            /// <summary>绝对校正因子归一法</summary>
            cm_CorrectedNormalization,
            /// <summary>相对校正因子归一法</summary>
            cm_CorrectedNormalizationWithISD,
            /// <summary>外标法</summary>
            cm_ExternalStandard,
            /// <summary>内标法</summary>
            cm_InternalStandard,
        }

        private QualitativeMethod _qualitativeMethod = QualitativeMethod.qm_peakArea;

        public QualitativeMethod Qualitative_Method
        {
            set { _qualitativeMethod = value; }
            get { return _qualitativeMethod; }
        }

        private CurveFittingMethod _curveFittingMethod = CurveFittingMethod.cfm_linear;

        public CurveFittingMethod CurveFitting_Method
        {
            set { _curveFittingMethod = value; }
            get { return _curveFittingMethod; }
        }

        private CalibrationMethod _calculationMethod = CalibrationMethod.cm_ExternalStandard;

        public CalibrationMethod Calibration_Method
        {
            set { _calculationMethod = value; }
            get { return _calculationMethod; }
        }

        private bool _zeroPassage = true;

        public bool ZeroPassage
        {
            set { _zeroPassage = value; }
            get { return _zeroPassage; }
        }
    }
    #endregion
    
    #region 谱图分析方法
    [Serializable]
    public class AnalyzerMethod
    {
        private PeakCalculationMethod _calculationMethod = new PeakCalculationMethod();
        /// <summary>
        /// 峰信息计算方法
        /// </summary>
        public PeakCalculationMethod CalculationMethod
        {
            get { return _calculationMethod; }
            set { _calculationMethod = value; }
        }

        private PeakIdentificationMethod _identificationMethod = new PeakIdentificationMethod();
        /// <summary>
        /// 峰定性方法
        /// </summary>
        public PeakIdentificationMethod IdentificationMethod
        {
            get { return _identificationMethod; }
            set { _identificationMethod = value; }
        }

        private PeakQuantificationMethod _quantificationMethod = new PeakQuantificationMethod();
        /// <summary>
        /// 峰定量方法
        /// </summary>
        public PeakQuantificationMethod QuantificationMethod
        {
            get { return _quantificationMethod; }
            set { _quantificationMethod = value; }
        }
    }
    #endregion

    #region 峰过滤
    internal class CPeakFilter
    {
        /// <summary>确定正常峰</summary>
        /// <param name="p">峰对象</param>
        /// <returns>符合返回true，否则返回false</returns>
        public static bool FindNaturalPeak(Peak p)
        {
            return p.PeakState == Peak.PeakStates.ps_natural;
        }
        /// <summary>确定正常峰</summary>
        /// <param name="p">峰对象</param>
        /// <returns>符合返回true，否则返回false</returns>
        public static bool FindCheckedPeak(Peak p)
        {
            return ((p.PeakState == Peak.PeakStates.ps_natural) && p.Checked);
        }
        /// <summary>确定参考峰</summary>
        /// <param name="p">峰对象</param>
        /// <returns>符合返回true，否则返回false</returns>
        public static bool FindReferencePeak(Peak p)
        {
            return ((p.PeakState == Peak.PeakStates.ps_natural) && p.Checked && p.ReferencePeak);
        }
        /// <summary>确定内标峰</summary>
        /// <param name="peak">峰对象</param>
        /// <returns>符合返回true，否则返回false</returns>
        public static bool FindInternalStandardPeak(Peak p)
        {
            return ((p.PeakState == Peak.PeakStates.ps_natural) && p.Checked && (p.InternalStandard != null) && (p.InternalStandard.Trim() != ""));
        }

        public static bool FindValidPeak(Peak p)
        { 
            return (!((p.Tag != null) && (p.Tag.ToString() == "invalidation")));
        }
    }
    #endregion

    #region 定性定量综合分析
    public class QualitativeAnalyzer
    {
        #region 公共方法

        #region 计算峰信息
        public static QualitativeErrorInfo QA_ComputePeakInfo(PeakAndPointList unknown_papl, AnalyzerMethod am)
        {
            ClearPeakResult(unknown_papl.PeakList);

            return CCalculationFactory.ComputePeakInfo(unknown_papl.PeakList, unknown_papl.PointList, am.CalculationMethod, CPeakFilter.FindValidPeak);
        }

        #endregion

        #region 百分比法
        /// <summary>百分比法</summary>
        /// <param name="unknown_papl">PeakAndPointList对象</param>
        /// <param name="pcm">计算方法参数</param>
        /// <param name="pqm">定量方法参数</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo QA_Normalization(PeakAndPointList unknown_papl, AnalyzerMethod am)
        {
            return QA_Normalization(unknown_papl, am, true);
        }
        /// <summary>百分比法</summary>
        /// <param name="unknown_papl">PeakAndPointList对象</param>
        /// <param name="pcm">计算方法参数</param>
        /// <param name="pqm">定量方法参数</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo QA_Normalization(PeakAndPointList unknown_papl, AnalyzerMethod am, bool bfilter)
        {
            ClearPeakResult(unknown_papl.PeakList);
            am.QuantificationMethod.Calibration_Method = PeakQuantificationMethod.CalibrationMethod.cm_Normalization;

            if (bfilter)
            {
                CCalculationFactory.ComputePeakInfo(unknown_papl.PeakList, unknown_papl.PointList, am.CalculationMethod);
            }           

            return CQuantificationFactory.Quantitate(unknown_papl.PeakList, am.QuantificationMethod);
        }
        #endregion

        #region 归一化法
        /// <summary>归一化法</summary>
        /// <param name="std_papl">标准样品</param>
        /// <param name="unknown_papl">未知样品</param>
        /// <param name="pcm">计算方法参数</param>
        /// <param name="pqm">定量方法参数</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo QA_CorrectedNormalization(PeakAndPointList std_papl, PeakAndPointList unknown_papl, AnalyzerMethod am)
        {
            QualitativeErrorInfo _rc = QualitativeErrorInfo.Success;
                                    
            //计算标样峰信息
            _rc = CCalculationFactory.ComputePeakInfo(std_papl.PeakList, std_papl.PointList, am.CalculationMethod);
            if (_rc != QualitativeErrorInfo.Success)
                return _rc;

            //计算标样校正因子
            _rc = CQuantificationFactory.GetAdjustFactor(std_papl.PeakList, am.QuantificationMethod);
            if (_rc != QualitativeErrorInfo.Success)
                return _rc;
            
            ResetPeakList(unknown_papl.PeakList);
            
            //计算未知样峰信息
            _rc = CCalculationFactory.ComputePeakInfo(unknown_papl.PeakList, unknown_papl.PointList, am.CalculationMethod);
            if (_rc != QualitativeErrorInfo.Success)
                return _rc;            

            //定性未知样
            List<Peak> _target_list = CIdentificationFactory.Identify(std_papl.PeakList, unknown_papl.PeakList, am.IdentificationMethod);
            if (_target_list == null)
                return QualitativeErrorInfo.IdentifyPeakError;

            //未知样定量
            _rc = CQuantificationFactory.Quantitate(_target_list, am.QuantificationMethod);

            return _rc;
        }
        #endregion

        #region 外标法
        #endregion

        #region 内标法
        #endregion

        #region 单点校正
        private static List<Peak> GetAverStandardPeakList(List<PeakAndPointList> unknown_std_papl, List<Peak> standard_list,PeakIdentificationMethod pim, PeakQuantificationMethod pqm)
        {
            QualitativeErrorInfo _rc = QualitativeErrorInfo.Success;

            if ((unknown_std_papl == null) || (unknown_std_papl.Count == 0) || (standard_list == null) || (standard_list.Count == 0))
                return null;

            int[] _std_count = new int[standard_list.Count];
            double[] _std_rt = new double[standard_list.Count];

            List<Peak> _aver_std_list = new List<Peak>();

            for (int i = 0; i < standard_list.Count; i++)
            {
                _std_count[i] = 0;
                _std_rt[i] = 0;

                Peak _p = new Peak();

                _p.Name = standard_list[i].Name;
                _p.Checked = true;
                _p.Index = i;

                _aver_std_list.Add(_p);
            }

            foreach (PeakAndPointList _papl in unknown_std_papl)
            {
                List<Peak> _unknown_std_list = _papl.PeakList.FindAll(CPeakFilter.FindNaturalPeak);
                if (_unknown_std_list == null) continue;

                //定性标样峰
                List<Peak> _target_list = CIdentificationFactory.Identify(standard_list, _unknown_std_list, pim);
                if (_target_list == null) continue;

                _rc = CQuantificationFactory.GetAdjustFactor(_target_list, pqm);    //计算校正因子
                if (_rc != QualitativeErrorInfo.Success) continue;

                foreach (Peak _p in _aver_std_list)
                {
                    foreach (Peak _p0 in _target_list)
                    {
                        if (_p.Name == _p0.Name)
                        {
                            _p.Capacity += _p0.Capacity;
                            _p.PeakHeight += _p0.PeakHeight;
                            _p.PeakArea += _p0.PeakArea;
                            _p.AdjustFactor += _p0.AdjustFactor;

                            _std_count[_p.Index]++;
                            _std_rt[_p.Index] += _p0.PeakPoint.X;

                            _target_list.Remove(_p0);
                            break;
                        }
                    }
                }            
            }

            foreach (Peak _p in _aver_std_list)
            {
                int _count = _std_count[_p.Index];

                _std_rt[_p.Index] /= _count;

                _p.Capacity /= _count;
                _p.PeakHeight /= _count;
                _p.PeakArea /= _count;
                _p.AdjustFactor /= _count;

                _p.PeakPoint = new PointF((float)_std_rt[_p.Index], 0);
            }

            return (_aver_std_list.Count > 0) ? _aver_std_list : null;
        }

        /// <summary>单点校正函数，此单点校正有不止一个标样，按多个标样的平均值计算。</summary>
        /// <param name="std_papl">标样列表</param>
        /// <param name="unknown_papl">未知样品</param>
        /// <param name="am">分析参数</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo QA_SinglePointFitting(List<PeakAndPointList> std_papl, PeakAndPointList unknown_papl, AnalyzerMethod am)
        {
            QualitativeErrorInfo _rc = QualitativeErrorInfo.Success;

            if (std_papl == null || std_papl.Count <= 0)            
                return QualitativeErrorInfo.PeakListError;            

            //计算标样的峰信息
            foreach (PeakAndPointList _papl in std_papl)
            {
                CCalculationFactory.ComputePeakInfo(_papl.PeakList, _papl.PointList, am.CalculationMethod);
            }

            List<Peak> _std_list = std_papl[0].PeakList.FindAll(CPeakFilter.FindCheckedPeak);
            if (_std_list == null)
                return QualitativeErrorInfo.StandardSampleError;

            _rc = CQuantificationFactory.GetAdjustFactor(_std_list, am.QuantificationMethod);
            if (_rc != QualitativeErrorInfo.Success)
                return _rc;            

            //如果存在多组标样,需要首先定性这些标样
            if (std_papl.Count > 1)
            {                
                List<Peak> _aver_std_list = GetAverStandardPeakList(std_papl, _std_list, am.IdentificationMethod, am.QuantificationMethod);
                if (_aver_std_list != null)
                {
                    _std_list = _aver_std_list;
                }
            }
            //计算未知峰信息
            ResetPeakList(unknown_papl.PeakList);

            CCalculationFactory.ComputePeakInfo(unknown_papl.PeakList, unknown_papl.PointList, am.CalculationMethod);

            //定性未知样          
            List<Peak> _target_list = CIdentificationFactory.Identify(_std_list, unknown_papl.PeakList, am.IdentificationMethod);
            if (_target_list == null)
                return QualitativeErrorInfo.IdentifyPeakError;
            
            //定量未知样
            _rc = CQuantificationFactory.Quantitate(_target_list, am.QuantificationMethod);
            return _rc;    
        }
        #endregion

        #region 多点校正
        public static QualitativeErrorInfo QA_CreateCalibrationCoeff(List<PeakAndPointList> standard_papl, List<Peak> peak_param, AnalyzerMethod am)
        {
            if ((standard_papl == null) || (standard_papl.Count == 0) || (peak_param == null) || (peak_param.Count == 0))
                return QualitativeErrorInfo.PeakListError;
            
            QualitativeErrorInfo _rc = QualitativeErrorInfo.Success;

            //计算标样的峰信息
            foreach (PeakAndPointList _papl in standard_papl)
            {
                _rc = CCalculationFactory.ComputePeakInfo(_papl.PeakList, _papl.PointList, am.CalculationMethod);
                if (_rc != QualitativeErrorInfo.Success) continue;

                CIdentificationFactory.Identify(peak_param, _papl.PeakList, am.IdentificationMethod);  
            }

            foreach (Peak _p in peak_param)
            {
                List<Peak> _peak_list = CQuantificationFactory.GetStandardPeakList(standard_papl, _p.Name, am.QuantificationMethod);
                if (_peak_list == null) continue;

                _p.Coefficient = CQuantificationFactory.GetCoefficient(_peak_list, am.QuantificationMethod);
                if (_p.Coefficient == null) continue;

                string _fitting_formula = CQuantificationFactory.GetFittingFormula(_p.Coefficient, am.QuantificationMethod);

                foreach (Peak _p0 in _peak_list)
                {
                    if ((_p0.InternalStandard == null) || _p0.InternalStandard.Trim() == "")
                    {
                        _p0.Coefficient = _p.Coefficient.GetRange(0, _p.Coefficient.Count);
                        _p0.FittingFormula = _fitting_formula;
                    }
                }
            }
            return _rc;
        }
        /// <summary>根据标样曲线，进行多点校正/// </summary>
        /// <param name="std_papl">标样列表</param>
        /// <param name="unknown_papl">未知样品</param>
        /// <param name="am">分析参数</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static QualitativeErrorInfo QA_MultiPointFitting(List<PeakAndPointList> std_papl, PeakAndPointList unknown_papl, AnalyzerMethod am)
        {
            if (std_papl == null || std_papl.Count <= 0 || unknown_papl == null) 
                return QualitativeErrorInfo.PeakListError;

            QualitativeErrorInfo _rc = QualitativeErrorInfo.Success;

            //检查标样的浓度是否正常
            if (SampleIsError(std_papl))
            {
                Debug.WriteLine("The sample doesn't meet the requirements for calculation.");
                return QualitativeErrorInfo.ConcentrationEmpty;
            }

            //计算标样的峰信息
            _rc = CCalculationFactory.ComputePeakInfo(std_papl[0].PeakList, std_papl[0].PointList, am.CalculationMethod);
            if (_rc != QualitativeErrorInfo.Success)
                return _rc;

            List<Peak> _valid_standard_list = std_papl[0].PeakList.FindAll(CPeakFilter.FindCheckedPeak);
            if (_valid_standard_list == null)
                return QualitativeErrorInfo.StandardSampleError;
            //计算校准曲线
            //List<PeakAndPointList> _unknown_std_papl = std_papl.GetRange(1, std_papl.Count - 1);
            //_rc = QA_CreateCalibrationCoeff(_unknown_std_papl, _valid_standard_list, am);
            _rc = QA_CreateCalibrationCoeff(std_papl, _valid_standard_list, am);

            //计算未知样的峰信息
            ResetPeakList(unknown_papl.PeakList);
            _rc = CCalculationFactory.ComputePeakInfo(unknown_papl.PeakList, unknown_papl.PointList, am.CalculationMethod);
            if (_rc != QualitativeErrorInfo.Success)
                return _rc;

            //定性未知峰
            List<Peak> _target_list = CIdentificationFactory.Identify(_valid_standard_list, unknown_papl.PeakList, am.IdentificationMethod);
            if (_target_list == null)
                return QualitativeErrorInfo.IdentifyPeakError;

            //定量
            _rc = CQuantificationFactory.Quantitate(_target_list, am.QuantificationMethod);
            return _rc;
        }
        #endregion

        #region 工作曲线
        /// <summary>获取校准曲线</summary>
        /// <param name="standard_papl">标样列表</param>
        /// <param name="peak_param">峰参数</param>
        /// <param name="am">分析参数</param>
        /// <returns>QualitativeErrorInfo枚举值</returns>
        public static List<object> GetFittingPoint(List<PeakAndPointList> std_papl, AnalyzerMethod am)
        {
            if ((std_papl == null) || (std_papl.Count == 0))
                return null;

            List<Peak> _standard_peaks = std_papl[0].PeakList.FindAll(CPeakFilter.FindCheckedPeak);
            if (_standard_peaks == null)
                return null;

            List<Object> _obj_list = new List<object>();

            foreach (Peak _p in _standard_peaks)
            {
                List<Peak> _peak_list = CQuantificationFactory.GetStandardPeakList(std_papl, _p.Name, am.QuantificationMethod);
                if (_peak_list == null) continue;

                List<PointF> _point_list = CQuantificationFactory.GetCalibrationCurve(_peak_list, am.QuantificationMethod);
                if (_point_list == null) continue;

                List<Object> _obj = new List<object>();

                _obj.Add(_point_list);
                _obj.Add(_p.Name);

                _obj_list.Add(_obj);
            }

            return (_obj_list.Count > 0) ? _obj_list : null;
        }
        #endregion

        #endregion

        #region 私有方法
        /// <summary>
        /// 重置峰对象列表
        /// </summary>
        /// <param name="pap">标样</param>
        private static void ResetPeakList(List<Peak> peak_list)
        {
            foreach (Peak _p in peak_list)
            {
                if (_p.InternalStandard != null && _p.InternalStandard.Trim() != "") continue;
                //obj.Name = string.Empty;
                _p.AdjustFactor = -1;
                //obj.AdjustNormalization = 0;
                _p.AsymmetricDegree = -1;
                _p.Capacity = 0;
                _p.CapacityFactor = -1;
                _p.Checked = false;
                //obj.Normalization = 0;
                _p.PeakArea = -1;
                _p.PeakHeight = -1;
                _p.PeakWidth1 = -1;
                _p.PeakWidth2 = -1;
                _p.PeakWidth4 = -1;
                _p.PlateIdealNum = -1;
                _p.PlateRealNum = -1;
                _p.SeparatingDegree = -1;
                _p.TailingFactor = -1;
                _p.FittingFormula = "";
            }
        }

        private static void ClearPeakResult(List<Peak> peak_list)
        {
            List<Peak> _valid_peak_list = peak_list.FindAll(CPeakFilter.FindNaturalPeak);
            if (_valid_peak_list == null) return;

            foreach (Peak _p in _valid_peak_list)
            {
                _p.AdjustFactor = -1;
                _p.AsymmetricDegree = -1;
                _p.Capacity = 0;
                _p.CapacityFactor = -1;
                _p.Checked = false;
                _p.PeakArea = -1;
                _p.PeakHeight = -1;
                _p.PeakWidth1 = -1;
                _p.PeakWidth2 = -1;
                _p.PeakWidth4 = -1;
                _p.PlateIdealNum = -1;
                _p.PlateRealNum = -1;
                _p.SeparatingDegree = -1;
                _p.TailingFactor = -1;
                _p.FittingFormula = "";
            }
        }

        /// <summary>
        /// 判断待测样和标样组是否有浓度不符合要求的组分
        /// </summary>
        /// <param name="standardSampleList">标样组</param>
        /// <param name="unknownSample">待测样</param>
        /// <returns>true or false</returns>
        private static bool SampleIsError(List<PeakAndPointList> papl_list)
        {
            foreach (PeakAndPointList _papl in papl_list)
            {
                if (CapacityIsError(_papl.PeakList))
                {
                    //Debug.WriteLine("in Sample_" + i);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 判断样品是否有浓度不符合要求的组分
        /// </summary>
        /// <param name="pList">峰列表（组分列表）</param>
        /// <returns>true or false</returns>
        private static bool CapacityIsError(List<Peak> peak_list)
        {
            foreach (Peak _p in peak_list)
            {
                if (!CPeakFilter.FindCheckedPeak(_p)) continue;
                if (Double.IsNaN(_p.Capacity) || Double.IsInfinity(_p.Capacity))
                //if (Double.IsNaN(_p.Capacity) || Double.IsInfinity(_p.Capacity) || _p.Capacity == 0)
                {
                    //Debug.Write("The peak " + "(" + _p.PeakPoint.X + ")" + " is checked, but its concentration is: " + _p.Capacity + ", ");
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
    #endregion
}
