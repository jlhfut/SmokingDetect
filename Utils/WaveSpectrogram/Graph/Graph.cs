using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Wayee.PeakObject;
using Wayee.ResultAnalyzer;
using Wayee.WaveReadWrite;
using Wayee.PeakLocation;

namespace Wayee.WaveSpectrogram
{
    public enum SpectrogramCalcuates { SC_Add, SC_Sub }
    public class Graph
    {
        #region defined
        [DllImport("gdi32.dll")]
        private static extern bool PtVisible(int hdc, int x, int y);
        const int c_peaksplitheight = 6;
        const string c_InvalidationPeak = "invalidation";
        /// <summary>
        /// 数据集管理器
        /// </summary>
        private DataHelper _datahelper = new DataHelper();
        /// <summary>
        /// 峰对象管理器
        /// </summary>
        private PeakHelper _peakhelper = new PeakHelper();
        /// <summary>
        /// 最新所绘点
        /// </summary>
        private PointF _currentpoint = PointF.Empty;
        /// <summary>
        /// 当前数据集索引
        /// </summary>
        private int _index = -1;
        /// <summary>
        /// 当前绘制状态
        /// </summary>
        private bool bdraw = false;
        private IPeakLocation _peakcheckor = null;
        /// <summary>
        /// 判到有效峰
        /// </summary>
        private bool _peakchecked = false;
        /// <summary>
        /// 图形名称
        /// </summary>
        private string _graphname = "";
        /// <summary>
        /// 取消峰列表
        /// </summary>
        private List<PointF> _cancelpeaklist = new List<PointF>();
        /// <summary>
        /// 集合图形颜色列表
        /// </summary>
        private List<Color> _graphcolors = null;
        #endregion

        #region initialization
        public Graph()
        {
        }


        #endregion

        #region defined event
        #endregion

        #region properties
        private DetectPeakParameter _detectpeakparameter = new DetectPeakParameter();
        /// <summary>
        /// 判峰参数
        /// </summary>
        public DetectPeakParameter DetectPeakParameter
        {
            get { return _detectpeakparameter; }
            set
            {
                DetectPeakParameter old = _detectpeakparameter;
                _detectpeakparameter = value;
                if (old.CheckLevel != value.CheckLevel || old.StartSlope != value.StartSlope || old.EndSlope != value.EndSlope)
                {
                    ReCheckPeak(value);
                }
                ReCheckPeak(null);
            }
        }
        /// <summary>
        /// 当前峰
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Peak this[int index]
        {
            get
            {
                if (index < 0 || index > PeakList.Count) return null;
                return _peakhelper.Peaks[index];
            }
            set
            {
                if (index < 0 || index > PeakList.Count) return;
                _peakhelper.Peaks[index] = value;
            }
        }

        /// <summary>
        /// 获取当前峰的点集
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public List<PointF> this[Peak pk]
        {
            get
            {
                PointF[] pts = _datahelper.GetPoints(pk.StartPoint.X, pk.EndPoint.X);
                if (pts == null) return null;
                return pts.ToList<PointF>();
            }
        }

        /// <summary>
        /// 获取当前峰的点集中Y坐标最大、小值
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public PointF[] this[List<PointF> lst]
        {
            get
            {
                if (lst == null || lst.Count == 0) return new PointF[] { PointF.Empty, PointF.Empty };
                return _datahelper.GetPoints(lst.ToArray());
            }
        }

        /// <summary>
        /// 根据X坐标获取点从点集中
        /// </summary>
        /// <param name="x">x坐标</param>
        /// <returns>点</returns>
        public PointF this[float x]
        {
            get { return _datahelper.GetPoint(x); }
        }

        /// <summary>
        /// 点集
        /// </summary>
        public List<PointF> PointList
        {
            get { return _datahelper.List; }
        }

        /// <summary>
        /// 峰集
        /// </summary>
        public List<Peak> PeakList
        {
            get { return _peakhelper.Peaks; }
        }

        private bool _RealCheckPeak = false;
        /// <summary>
        /// 是否在采集数据时实时判峰
        /// </summary>
        public bool RealCheckPeak
        {
            get { return _RealCheckPeak; }
            set { _RealCheckPeak = value; }
        }
        /// <summary>
        /// 数据单位
        /// </summary>
        public DataUnitDescription DataUnit
        {
            get { return _datahelper.DataUnit; }
            set { _datahelper.DataUnit = value; }
        }

        private bool _showpeak = true;
        /// <summary>
        /// 显示峰信息
        /// </summary>
        public bool ShowPeak
        {
            get { return _showpeak; }
            set { _showpeak = value; }
        }
        private bool _showpeakname = true;
        /// <summary>
        /// 显示峰组份名称
        /// </summary>
        public bool ShowPeakName
        {
            get { return _showpeakname; }
            set { _showpeakname = value; }
        }

        private Point _graphoffset = new Point(0, 0);
        /// <summary>
        /// 图形偏移量
        /// </summary>
        public Point GraphOffset
        {
            get { return _graphoffset; }
            set { _graphoffset = value; }
        }
        private PointF _StartPoint = PointF.Empty;
        /// <summary>
        /// 图形起始点
        /// </summary>
        public PointF StartPoint
        {
            get { return _StartPoint; }
            set { _StartPoint = value; }
        }
        private string _description = "";
        /// <summary>
        /// 图形描述信息
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private bool _groupgraph = false;
        /// <summary>
        /// 显示组图形
        /// </summary>
        public bool GroupGraph
        {
            get { return _groupgraph; }
            set { _groupgraph = value; }
        }
        private bool _drawpeaktag = true;
        /// <summary>
        /// 绘制峰处理标记
        /// </summary>
        public bool DrawPeakTag
        {
            get { return _drawpeaktag; }
            set { _drawpeaktag = value; }
        }
        private bool _calculated = true;
        /// <summary>
        /// 返回是否需要重新计算
        /// </summary>
        public bool Calculated
        {
            get { return _calculated; }
            set { _calculated = value; }
        }
        private SmoothingMode _SmoothingMode = SmoothingMode.Default;
        /// <summary>
        /// 当前图形的平滑模式
        /// </summary>
        public SmoothingMode SmoothingMode
        {
            get { return _SmoothingMode; }
            set { _SmoothingMode = value; }
        }

        private CompositingQuality _CompositingQuality = CompositingQuality.Default;
        /// <summary>
        /// 当前图形的等级
        /// </summary>
        public CompositingQuality CompositingQuality
        {
            get { return _CompositingQuality; }
            set { _CompositingQuality = value; }
        }

        private Point _ActivatedCoordinate = new Point();
        /// <summary>
        /// 当前图形的操作坐标
        /// </summary>
        public Point ActivatedCoordinate
        {
            get { return _ActivatedCoordinate; }
            set { _ActivatedCoordinate = value; }
        }
        #endregion

        #region events
        /// <summary>
        /// 判峰成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPeakFound(object sender, PeakArgs arg)
        {
            try
            {
                if (arg == null) return;
                Peak peak = null;
                switch (arg.Type)
                {
                    case PeakType.Detached:
                    case PeakType.Noise:
                        peak = new Peak();
                        peak.StartPoint = arg.StartPoint;
                        peak.EndPoint = arg.EndPoint;
                        peak.PeakPoint = arg.PeakPoint;
                        peak.Index = _peakhelper.Peaks.Count;
                        if (arg.Type == PeakType.Detached)
                        {
                            peak.PeakState = Peak.PeakStates.ps_natural;
                        }
                        else
                        {
                            peak.PeakState = Peak.PeakStates.ps_noise;
                            peak.Tag = c_InvalidationPeak;
                        }
                        peak.BaseLineEnd = true;
                        _peakhelper.Add(peak);
                        break;
                    case PeakType.Mixed:
                        if (arg.CharacteristicPointsFlag == null || arg.CharacteristicPointsFlag.Length == 0) return;
                        int istart = -1;
                        int inext = -1;
                        int ipeak = -1;
                        int iend = -1;
                        for (int i = 0; i < arg.CharacteristicPointsFlag.Length; i++)
                        {
                            switch (arg.CharacteristicPointsFlag[i].ToString().ToLower())
                            {
                                case "o":
                                    iend = -1;
                                    ipeak = -1;
                                    istart = i;
                                    break;
                                case "a":
                                    iend = -1;
                                    if (istart == -1 && inext != -1)
                                    {
                                        istart = inext;
                                        inext = -1;
                                    }
                                    ipeak = i;
                                    break;
                                case "v":
                                    inext = i;
                                    iend = i;
                                    break;
                                case "t":
                                    iend = i;
                                    break;
                            }
                            if (istart != -1 && ipeak != -1 && iend != -1)
                            {
                                peak = new Peak();
                                peak.StartPoint = arg.CharacteristicPoints[istart];
                                peak.EndPoint = arg.CharacteristicPoints[iend];
                                peak.PeakPoint = arg.CharacteristicPoints[ipeak];
                                peak.Index = _peakhelper.Peaks.Count;
                                peak.PeakState = Peak.PeakStates.ps_natural;
                                _peakhelper.Add(peak);
                                istart = -1;
                                ipeak = -1;
                                iend = -1;
                            }
                        }
                        if (peak != null) peak.BaseLineEnd = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
        }

        #endregion

        #region public function
        /// <summary>
        /// 增加谱图数据点
        /// </summary>
        /// <param name="pt"></param>
        public bool AddPoint(PointF pt)
        {
            try
            {
                AddNewPoint(pt);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 增加谱图数据点集
        /// </summary>
        /// <param name="pt"></param>
        public bool AddPoint(PointF[] pt)
        {
            try
            {
                for (int i = 0; i < pt.GetLength(0); i++)
                {
                    AddPoint(pt[i]);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 停止接收数据
        /// </summary>
        /// <returns></returns>
        public bool StopRecieve()
        {
            try
            {
                //_peakcheckor.Stoped = true;
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
        /// <summary>
        /// 清除所有数据集
        /// </summary>
        public void Flush()
        {
            try
            {
                _datahelper.Flush();
                _currentpoint = PointF.Empty;
                _graphname = "";
                _description = "";
                _groupgraph = false;
                _graphcolors = null;
                _calculated = true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
        }
        /// <summary>
        /// 清除所有引用
        /// </summary>
        public void FlushRef()
        {
            try
            {
                _peakhelper = null;
                _peakcheckor = null;
                _datahelper = null;
                if (_cancelpeaklist != null) _cancelpeaklist.Clear();
                _cancelpeaklist = null;
                if (_graphcolors != null) _graphcolors.Clear();
                _graphcolors = null;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
        }
        /// <summary>
        /// 打开数据
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool Open(string filename)
        {
            return Open(filename, false);
        }
        /// <summary>
        /// 打开数据
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool Open(string filename, bool onlydata)
        {
            _graphname = System.IO.Path.GetFileNameWithoutExtension(filename);
            if (onlydata)
                return DoOpen(filename, _datahelper, null, null);
            else
                return DoOpen(filename, _datahelper, _peakhelper, DetectPeakParameter);
        }
        /// <summary>
        /// 打开一组谱图
        /// </summary>
        /// <param name="index"></param>
        /// <param name="filenames"></param>
        /// <param name="colors"></param>
        /// <returns></returns>
        public bool Open(List<string> filenames, List<Color> colors)
        {
            try
            {
                GroupGraph = true;
                //get all pointf collect
                List<List<PointF>> pts = new List<List<PointF>>();
                List<List<Peak>> pks = new List<List<Peak>>();
                List<PointF> xrect = new List<PointF>();
                List<PointF> yrect = new List<PointF>();
                DataHelper dh = new DataHelper();
                for (int i = 0; i < filenames.Count; i++)
                {
                    string[] name = filenames[i].Split(',');
                    PeakAndPointList ppl = Graph.GetGraphData(name[0]);
                    List<PointF> pt = ppl.PointList;
                    List<Peak> pk = ppl.PeakList;
                    if (pt == null || pt.Count <= 0) continue;
                    pts.Add(pt);
                    pks.Add(pk);
                    //20130823采用查询方式获取限值
                    //xrect.Add(new PointF(pt[0].X, pt[pt.Count - 1].X));
                    //yrect.Add(new PointF(pt.Min(ymin => ymin.Y), pt.Max(ymax => ymax.Y)));
                    xrect.Add(new PointF(pt.Min(xmin => xmin.X), pt.Max(xmax => xmax.X)));
                    yrect.Add(new PointF(pt.Min(ymin => ymin.Y), pt.Max(ymax => ymax.Y)));
                    //20130823
                    if (name.GetLength(0) > 1)
                        _graphname += name[1] + ";";
                    else
                        _graphname += System.IO.Path.GetFileNameWithoutExtension(name[0]) + ";";

                    //2013-06-18谱图重叠时显示一条谱图的峰信息
                    //2013-08-21打开谱图时获取数据单位
                    //if (i == 0) DoOpen(name[0], null, _peakhelper, null);
                    if (i == 0)
                    {
                        DoOpen(name[0], dh, _peakhelper, null);
                        _datahelper.DataUnit = dh.DataUnit;
                    }
                    //2013-06-18

                }
                _peakhelper.GroupList = pks;
                _datahelper.GroupList = pts;
                //get data rect
                _datahelper.XLimitValue = new PointF(xrect.Min(xmin => xmin.X), xrect.Max(xmax => xmax.Y));
                _datahelper.YLimitValue = new PointF(yrect.Min(ymin => ymin.X), yrect.Max(ymax => ymax.Y));
                //colors
                _graphcolors = colors;
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
        /// <summary>
        /// 谱图相加/减
        /// </summary>
        /// <param name="filenames"></param>
        /// <returns></returns>
        public bool Calculate(List<string> filenames, SpectrogramCalcuates sc)
        {
            try
            {
                List<List<PointF>> lst = GetGraphList(filenames);
                if (lst == null || lst.Count < 2) return false;
                for (int i = 1; i < lst.Count; i++)
                {
                    switch (sc)
                    {
                        case SpectrogramCalcuates.SC_Add:
                            lst[0] = Wayee.Spectrogram.SpectrogramProcessor.Add(lst[0], lst[i]);
                            break;
                        case SpectrogramCalcuates.SC_Sub:
                            lst[0] = Wayee.Spectrogram.SpectrogramProcessor.Sub(lst[0], lst[i]);
                            break;
                    }
                }
                for (int i = 0; i < lst[0].Count; i++)
                {
                    if (i > 0 && lst[0][i].X == 0.0) break;
                    _datahelper.AddPoint(lst[0][i]);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }

        /// <summary>
        /// 获取谱图图形数据
        /// </summary>
        /// <param name="filename">图谱文件名</param>
        /// <returns></returns>
        public static PeakAndPointList GetGraphData(string filename)
        {
            try
            {
                //open points
                DataHelper dh = new DataHelper();
                //open peaks
                PeakHelper ph = new PeakHelper();
                DoOpen(filename, dh, ph, null);
                PeakAndPointList lst = new PeakAndPointList();
                lst.PeakList = ph.Peaks;
                lst.PointList = dh.List;
                return lst;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return null;
            }
        }
        /// <summary>
        /// 获取检测峰参数
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static DetectPeakParameter GetDetectPeakParameter(string filename)
        {
            try
            {
                DetectPeakParameter dpp = new DetectPeakParameter();
                DoOpen(filename, null, null, dpp);
                return dpp;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return null;
            }
        }
        /// <summary>
        /// 打开文件获取操作堆栈信息
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static PeakHelper GetPeekHelper(string filename)
        {
            PeakHelper ph = new PeakHelper();
            if (DoOpen(filename, null, ph, null))
                return ph;
            return null;
        }
        /// <summary>
        /// 保存峰数据
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static bool SetGraphData(string filename, List<Peak> lst)
        {
            try
            {
                //open points
                DataHelper dh = new DataHelper();
                //open peaks
                PeakHelper ph = new PeakHelper();
                //open detectpeakparameter
                DetectPeakParameter dpp = new DetectPeakParameter();
                if (!DoOpen(filename, dh, ph, dpp)) return false;
                ph.Peaks.Clear();
                ph.Peaks.AddRange(lst);
                return DoSave(filename, dh, ph, dpp);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="filename"></param>
        public bool Save(string filename)
        {
            return DoSave(filename, _datahelper, _peakhelper, DetectPeakParameter);
        }
        /// <summary>
        /// 获得数据集中的四个限制
        /// </summary>
        /// <returns>四个元素，依次为x轴最小值、最大值;y轴的最小值、最大值</returns>
        public float[] GetLimitValue()
        {
            int count = 1;
            if (GroupGraph && _datahelper.GroupList != null && _datahelper.GroupList.Count > 1) count = _datahelper.GroupList.Count - 1;
            float[] rs = new float[4];
            PointF pt = _datahelper.XLimitValue;
            rs[0] = pt.X;//+ GraphOffset.X * count;
            rs[1] = pt.Y;// +GraphOffset.X * count;
            if (GraphOffset.X < 0)
                rs[0] += GraphOffset.X * count;
            else
                rs[1] += GraphOffset.X * count;
            pt = _datahelper.YLimitValue;
            rs[2] = pt.X;// -GraphOffset.Y * count;
            rs[3] = pt.Y;// +GraphOffset.Y * count;
            if (GraphOffset.Y < 0)
                rs[2] += GraphOffset.Y * count;
            else
                rs[3] += GraphOffset.Y * count;

            return rs;

        }
        /// <summary>
        /// 定量计算
        /// </summary>
        /// <param name="cm">定量方法</param>
        /// <param name="qm">定量依据</param>
        /// <param name="cp">计算参数</param>
        /// <param name="stdsample">标样列表</param>
        public bool Calculate(CalculateMethods cm, QualitativeMode qm, CalculateParameter cp, List<PeakAndPointList> stdsample)
        {
            try
            {
                //if (cm== CalculateMethods.cm_Normalizing && !Calculated) return true;
                PeakAndPointList test = new PeakAndPointList(_peakhelper.Peaks, _datahelper.List);
                bool rs = Calculate(test, cm, qm, cp, stdsample);
                //FormatPeakList(test.PeakList, WaveCanvas.VerticalCoordinate.DataMultiple);
                Calculated = false;
                return rs;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }

        /// <summary>
        /// 格式化分析方法
        /// </summary>
        /// <param name="qm"></param>
        /// <param name="?"></param>
        /// <param name="cp"></param>
        /// <returns></returns>
        public static AnalyzerMethod FormatAnalyzerMethod(QualitativeMode qm, CalculateParameter cp)
        {
            return FormatAnalyzerMethod(qm, cp, null);
        }

        /// <summary>
        /// 格式化分析方法
        /// </summary>
        /// <param name="qm"></param>
        /// <param name="?"></param>
        /// <param name="cp"></param>
        /// <returns></returns>
        public static AnalyzerMethod FormatAnalyzerMethod(QualitativeMode qm, CalculateParameter cp, List<PeakAndPointList> stdsample)
        {
            AnalyzerMethod am = new AnalyzerMethod();
            float deltatime = 0.5f;
            if (cp != null) deltatime = cp.TimePrecision;
            am.IdentificationMethod.TimeBand = deltatime;
            am.IdentificationMethod.Time_Method = PeakIdentificationMethod.TimeMethod.tm_band;

            am.QuantificationMethod.ZeroPassage = cp.ZeroPoint;
            switch (cp.Degree)
            {
                case 1:
                    am.QuantificationMethod.CurveFitting_Method = PeakQuantificationMethod.CurveFittingMethod.cfm_linear;
                    break;
                case 2:
                    am.QuantificationMethod.CurveFitting_Method = PeakQuantificationMethod.CurveFittingMethod.cfm_quadratic;
                    break;
                case 3:
                default:
                    am.QuantificationMethod.CurveFitting_Method = PeakQuantificationMethod.CurveFittingMethod.cfm_cubic;
                    break;
            }
            if (cp.Logarithm)
                am.QuantificationMethod.CurveFitting_Method = PeakQuantificationMethod.CurveFittingMethod.cfm_log;
            am.QuantificationMethod.Qualitative_Method = (PeakQuantificationMethod.QualitativeMethod)qm;

            //确定是否为内标
            if (stdsample != null && stdsample.Count > 0)
            {
                foreach (PeakAndPointList pp in stdsample)
                {
                    if (pp == null || pp.PeakList == null || pp.PeakList.Count == 0) continue;
                    for (int i = 0; i < pp.PeakList.Count; i++)
                        if (pp.PeakList[i].Checked && pp.PeakList[i].InternalStandard.Trim() != "")
                        {
                            am.QuantificationMethod.Calibration_Method = PeakQuantificationMethod.CalibrationMethod.cm_InternalStandard;
                            break;
                        }
                    if (am.QuantificationMethod.Calibration_Method == PeakQuantificationMethod.CalibrationMethod.cm_InternalStandard) break;
                }

            }
            return am;
        }

        /// <summary>
        /// 定量计算
        /// </summary>
        /// <param name="cm">定量方法</param>
        /// <param name="qm">定量依据</param>
        /// <param name="cp">计算参数</param>
        /// <param name="stdsample">标样列表</param>
        public static bool Calculate(PeakAndPointList test, CalculateMethods cm, QualitativeMode qm, CalculateParameter cp, List<PeakAndPointList> stdsample)
        {
            try
            {
                AnalyzerMethod am = Graph.FormatAnalyzerMethod(qm, cp, stdsample);
                switch (cm)
                {
                    case CalculateMethods.cm_Normalizing:
                        //QualitativeAnalyzer.ComputeNormalization(test, qm,false);  
                        QualitativeAnalyzer.QA_ComputePeakInfo(test, am);
                        QualitativeAnalyzer.QA_Normalization(test, am);
                        break;
                    case CalculateMethods.cm_CNormalizing:
                        if (stdsample == null || stdsample.Count == 0) return false;
                        //QualitativeAnalyzer.ComputeAjustNormalization(stdsample[0], test, qm, deltatime);
                        ClearPeakText(test.PeakList);
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //20141221：校正归一计算中，计算Dll中根据参数选择调用函数
                        am.QuantificationMethod.Calibration_Method = PeakQuantificationMethod.CalibrationMethod.cm_CorrectedNormalization;
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        QualitativeAnalyzer.QA_CorrectedNormalization(stdsample[0], test, am);
                        UnCalculatePeak(stdsample[0], test);
                        break;
                    case CalculateMethods.cm_SCorrection:
                        if (stdsample == null || stdsample.Count == 0) return false;
                        //QualitativeAnalyzer.SinglePointFitting(stdsample[0], test, qm, deltatime);
                        ClearPeakText(test.PeakList);
                        QualitativeAnalyzer.QA_SinglePointFitting(stdsample, test, am);
                        UnCalculatePeak(stdsample[0], test);
                        break;
                    case CalculateMethods.cm_MCorrection:
                        if (stdsample == null || stdsample.Count <= 1) return false;
                        //QualitativeAnalyzer.MultiPointFitting(stdsample, test, qm, deltatime, cp.Degree, cp.ZeroPoint, cp.Logarithm);
                        ClearPeakText(test.PeakList);
                        QualitativeAnalyzer.QA_MultiPointFitting(stdsample, test, am);
                        UnCalculatePeak(stdsample[0], test);
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }

        /// <summary>
        /// 清除组份名
        /// </summary>
        /// <param name="pks"></param>
        private static void ClearPeakText(List<Peak> pks)
        {
            if (pks == null) return;
            foreach (Peak pk in pks)
                pk.Name = "";
        }
        /// <summary>
        /// 计算后未处理的标样峰
        /// </summary>
        /// <param name="stdsample"></param>
        /// <param name="test"></param>
        /// <returns></returns>
        private static bool UnCalculatePeak(PeakAndPointList stdsample, PeakAndPointList test)
        {
            try
            {
                bool flag = false;
                Peak pk = null;
                for (int i = 0; i < test.PeakList.Count; i++)
                {
                    test.PeakList[i].Description = null;
                }
                for (int i = 0; i < stdsample.PeakList.Count; i++)
                {
                    if (stdsample.PeakList[i].PeakState == Peak.PeakStates.ps_natural && stdsample.PeakList[i].Checked && stdsample.PeakList[i].Name != "")
                    {
                        flag = false;
                        pk = null;
                        for (int j = 0; j < test.PeakList.Count; j++)
                        {
                            if (stdsample.PeakList[i].Name == test.PeakList[j].Name && test.PeakList[j].Checked)
                            {
                                flag = true;
                                break;
                            }
                            if (test.PeakList[j].PeakPoint.X > stdsample.PeakList[i].StartPoint.X &&
                                test.PeakList[j].PeakPoint.X < stdsample.PeakList[i].EndPoint.X)
                            {
                                if (pk != null && Math.Abs(stdsample.PeakList[i].PeakPoint.X - test.PeakList[j].PeakPoint.X) < Math.Abs(stdsample.PeakList[i].PeakPoint.X - pk.PeakPoint.X))
                                    pk = test.PeakList[j];
                                if (pk == null) pk = test.PeakList[j];
                            }
                        }
                        if (!flag && pk != null && pk.PeakState != Peak.PeakStates.ps_natural)
                        {
                            //test.PeakList[pk.Index].Name = stdsample.PeakList[i].Name + ":" + stdsample.PeakList[i].PeakPoint.X.ToString();
                            //20140430
                            test.PeakList[pk.Index].Description = stdsample.PeakList[i].Name + ":" + stdsample.PeakList[i].PeakPoint.X.ToString();
                            //test.PeakList[pk.Index].PeakState = Peak.PeakStates.ps_natural;
                            test.PeakList[pk.Index].Checked = true;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
        /// <summary>
        /// 格式化峰列表
        /// </summary>
        /// <param name="lst"></param>
        public static void FormatPeakList(List<Peak> lst, int Multiple)
        {
            if (lst == null) return;
            foreach (Peak pk in lst)
                FormatPeak(pk, Multiple);
        }
        /// <summary>
        /// 格式化峰信息
        /// </summary>
        /// <param name="peak"></param>
        private static void FormatPeak(Peak peak, int Multiple)
        {
            System.Reflection.PropertyInfo[] pinfs = peak.GetType().GetProperties();
            object value = null;
            foreach (System.Reflection.PropertyInfo pinf in pinfs)
            {
                if (pinf.PropertyType.Name.ToLower() != "double") continue;
                value = pinf.GetValue(peak, null);
                if (value == null) continue;
                //if (value.ToString() == "-1") value = Double.NaN;
                if (value.ToString() != "-1" && Multiple != 0 &&
                    (pinf.Name == "PeakArea" ||
                    pinf.Name == "PeakHeight" ||
                    pinf.Name == "PeakWidth1" ||
                    pinf.Name == "PeakWidth2" ||
                    pinf.Name == "PeakWidth4" ||
                    pinf.Name == "AdjustFactor"))
                {
                    if (Multiple > 0)
                        value = ((double)value) * Multiple;
                    else
                        value = ((double)value) / Math.Abs(Multiple);
                }

                pinf.SetValue(peak, Convert.ChangeType(((double)value).ToString("f6"), typeof(Double), null), null);
            }
        }
        /// <summary>
        /// 计算基线噪声和漂移
        /// </summary>
        /// <returns></returns>
        public BaseLineInfo CalculateBaseLineInfo(int pointpersecond)
        {
            try
            {
                BaseLineInfo inf = new BaseLineInfo();
                if (_datahelper.List != null && _datahelper.List.Count > 0)
                {
                    inf.BaseLineNoise = Wayee.BaseLine.BaseLineCalculator.ComputeBaseLineNoise(_datahelper.List, pointpersecond);
                    inf.BaseLineDrift = Wayee.BaseLine.BaseLineCalculator.ComputeBaseLineDrift(_datahelper.List, pointpersecond);
                    return inf;
                }
                return null;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return null;
            }
        }
        /// <summary>
        /// 根据阀值重新判峰
        /// </summary>
        /// <param name="winwidth">判峰宽度</param>
        /// <returns></returns>
        public bool ReCheckPeak(DetectPeakParameter dpp)
        {
            try
            {
                if (dpp == null)
                {
                    ReCheckPeak();
                    return true;
                }
                if (_peakcheckor == null)
                {
                    _peakcheckor = new PeakLocationManager();
                    _peakcheckor.PeakLocationParam.LocationType = LocationType.TraditionWithMerging;
                    _peakcheckor.PeakLocationParam.SG_Order = dpp.SG_Order;//3;
                    _peakcheckor.PeakLocationParam.SG_SideWindowLength = dpp.SG_SideWindowLength;//20;
                    _peakcheckor.PeakLocationParam.TimeSpan = dpp.TimeSpan;//1f / 20;
                    _peakcheckor.Execute();
                    _peakcheckor.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(OnPeakFound);
                }
                _peakcheckor.PeakLocationParam.StartSLope = dpp.StartSlope;
                _peakcheckor.PeakLocationParam.SampleInterval = dpp.CheckLevel;
                _peakcheckor.PeakLocationParam.EndSLope = dpp.EndSlope;
                _peakhelper.Flush();

                _peakcheckor.PeakLocationParam.SDNoiseAmplitude = 1f;
                _peakcheckor.PeakLocationParam.SourceData = _datahelper.List.ToArray();
                _peakcheckor.Execute();

                Calculated = true;
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
        /// <summary>
        /// 重新判峰
        /// </summary>
        public bool ReCheckPeak()
        {
            try
            {
                DoReCheckPeak(null);
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
        /// <summary>
        /// 反转点集以基点为准
        /// </summary>
        /// <param name="start">点集的开始索引</param>
        /// <param name="end">点集的结束索引</param>
        /// <returns></returns>
        public bool ReversalPoints(float start, float end)
        {
            try
            {
                bool rs = _datahelper.ReversalPoints(start, end);
                return rs;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
        #endregion

        #region private function
        /// <summary>
        /// 增加点集
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        private void AddNewPoint(PointF pt)
        {
            _index = _datahelper.AddPoint(pt);
        }

        /// <summary>
        ///  重新判峰
        /// </summary>
        /// <param name="peak"></param>
        private void DoReCheckPeak(Peak peak)
        {
            bool natural = true;
            Peak pk;
            for (int i = _peakhelper.Peaks.Count - 1; i >= 0; i--)
            {
                pk = _peakhelper.Peaks[i];
                if (peak != null && peak.Index != pk.Index) continue;
                if (pk.PeakHeight == 0f && pk.PeakWidth1 == 0f && pk.PeakArea == 0f) continue;

                if (pk.PeakState == Peak.PeakStates.ps_noise && pk.Tag != null && pk.Tag.ToString() == c_InvalidationPeak) continue;
                if (pk.PeakState != Peak.PeakStates.ps_natural && pk.PeakState != Peak.PeakStates.ps_noise) continue;
                natural = (Math.Abs(pk.PeakHeight) > DetectPeakParameter.MinHeight);
                natural &= (pk.PeakArea > DetectPeakParameter.MinArea);
                pk.PeakState = (natural ? Peak.PeakStates.ps_natural : Peak.PeakStates.ps_noise);
            }
        }
        /// <summary>
        /// 格式化绘制坐标
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public PointF FormatPosition(float x, float y)
        {
            return FormatPosition(new PointF(x, y));
        }

        /// <summary>
        /// 格式化绘制坐标
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public PointF FormatPosition(PointF pt)
        {
            if (_StartPoint == PointF.Empty) return pt;
            return new PointF(pt.X + _StartPoint.X, pt.Y + _StartPoint.Y);
        }

        /// <summary>
        /// 检查点坐标
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public bool CheckPosition(PointF spt)
        {
            bool rs = (spt.X != double.NegativeInfinity && spt.X != double.PositiveInfinity && !double.IsNaN(spt.X));
            rs &= (spt.Y != double.NegativeInfinity && spt.Y != double.PositiveInfinity && !double.IsNaN(spt.Y));
            return rs;
        }
        /// <summary>
        /// 获得图形点集列表
        /// </summary>
        /// <returns></returns>
        private List<List<PointF>> GetGraphList(List<string> filenames)
        {
            if (filenames == null || filenames.Count == 0) return null;
            IFileReadWrite file = ReadWriteFactory.CreateFileInstance(SerialType.Binary);
            string filename = "";
            List<List<PointF>> lst = new List<List<PointF>>();
            for (int i = 0; i < filenames.Count; i++)
            {
                filename = filenames[i];
                if (!File.Exists(filename)) continue;
                try
                {
                    file.OpenFile(filename, FileOpenFlag.Open);
                    List<MemoryStream> mlst = new List<MemoryStream>();
                    //open points
                    if (file.ReadContent(0, out mlst))
                    {
                        DataHelper dh = new DataHelper();
                        dh.Deserialize(mlst[0]);
                        if (dh != null && dh.List != null && dh.List.Count > 0) lst.Add(dh.List);
                    }
                }
                finally
                {
                    file.CloseFile();
                }
            }
            return lst;
        }
        /// <summary>
        /// 打开数据
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private static bool DoOpen(string filename, DataHelper dh, PeakHelper ph, DetectPeakParameter dpp)
        {
            try
            {
                //if (dh == null || ph == null) return false;
                if (!File.Exists(filename)) return false;
                IFileReadWrite file = ReadWriteFactory.CreateFileInstance(SerialType.Binary);
                try
                {
                    file.OpenFile(filename, FileOpenFlag.Open);
                    List<MemoryStream> mlst = new List<MemoryStream>();
                    //open points
                    if (dh != null && file.ReadContent(0, out mlst))
                        dh.Deserialize(mlst[0]);
                    mlst = new List<MemoryStream>();
                    //open peaks
                    if (ph != null && file.ReadContent(1, out mlst))
                        ph.DeserializePeaks(mlst[0]);
                    mlst = new List<MemoryStream>();
                    ////open operates
                    //if (ph != null && file.ReadContent(2, out mlst))
                    //    ph.DeserializeOperates(mlst[0]);
                    //open Detect Peak Parameter
                    if (dpp != null && file.ReadContent(2, out mlst))
                        dpp.Deserialize(mlst[0]);
                    return true;
                }
                finally
                {
                    file.CloseFile();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="dh"></param>
        /// <param name="ph"></param>
        /// <returns></returns>
        //private static bool DoSave(string filename, DataHelper dh, PeekHelper ph)
        //{
        //    return DoSave(filename, dh, ph, null);
        //}
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="dh"></param>
        /// <param name="ph"></param>
        /// <returns></returns>
        private static bool DoSave(string filename, DataHelper dh, PeakHelper ph, DetectPeakParameter dpp)
        {
            try
            {
                if (dh == null || ph == null) return false;
                IFileReadWrite file = ReadWriteFactory.CreateFileInstance(SerialType.Binary);
                try
                {
                    file.OpenFile(filename, FileOpenFlag.Create);
                    List<MemoryStream> mlst = new List<MemoryStream>();
                    MemoryStream ms = new MemoryStream();
                    //save points
                    dh.Serialize(ref ms);
                    mlst.Add(ms);
                    file.WriteContent(mlst, 0);
                    //save peaks
                    mlst.Clear();
                    ms = new MemoryStream();
                    ph.SerializePeaks(ref ms);
                    mlst.Add(ms);
                    file.WriteContent(mlst, 1);
                    //save operates
                    //mlst.Clear();
                    //ms = new MemoryStream();
                    //ph.SerializeOperates(ref ms);
                    //mlst.Add(ms);
                    //file.WriteContent(mlst, 2);
                    //save Detect Peak Parameter
                    mlst.Clear();
                    ms = new MemoryStream();
                    dpp.Serialize(ref ms);
                    mlst.Add(ms);
                    file.WriteContent(mlst, 2);
                }
                finally
                {
                    file.CloseFile();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
 
        /// <summary>
        /// 设置消除峰列表
        /// </summary>
        /// <param name="pks"></param>
        private List<PointF> GetCancelPeakList(List<Peak> pks)
        {
            List<PointF> rpk = new List<PointF>();
            if (pks != null)
            {
                var values = from p in pks
                             where p.PeakState == Peak.PeakStates.ps_delete
                             select p;
                if (values == null) return rpk;
                foreach (Peak v in values)
                    rpk.Add(new PointF(v.StartPoint.X, v.EndPoint.X));
            }
            return rpk;
        }
        /// <summary>
        /// 判断峰点是否为有效点
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        private bool ValidPoint(List<PointF> lst, float x)
        {
            if (lst == null) return true;
            for (int i = 0; i < lst.Count; i++)
                if (x > lst[i].X && x < lst[i].Y) return false;
            return true;
        }

        /// <summary>
        /// 判断点是否在峰中
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="idx"></param>
        /// <param name="peak"></param>
        /// <returns></returns>
        private int PointInPeak(PointF pt, int idx, Peak peak)
        {
            GraphicsPath gp = new GraphicsPath();
            Region rgn = new Region();
            PointF[] pts = _datahelper.GetPoints(peak.StartPoint.X, peak.EndPoint.X);
            List<PointF> lst = new List<PointF>();
            PointF dpt;
            int dx = 0;
            int divy = 10000;
            if (pts[0].Y < divy * 1000) divy = 1;

            foreach (PointF tpt in pts)
            {
                dpt = new PointF(tpt.X, tpt.Y / divy);
                if (dx == dpt.X) continue;
                lst.Add(dpt);
                dx = (int)dpt.X;
            }
            lst.Add(new PointF(peak.EndBaseLine.X, peak.EndBaseLine.Y / divy));
            lst.Add(new PointF(peak.StartBaseLine.X, peak.StartBaseLine.Y / divy));

            gp.Reset();
            gp.AddPolygon(lst.ToArray());
            rgn.MakeEmpty();
            rgn.Union(gp);

            if (!rgn.IsVisible(new PointF(pt.X, pt.Y / divy)))
                idx = -(idx + 2);
            return idx;
        }
        #endregion
    }
}
