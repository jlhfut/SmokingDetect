//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: PeakObj.cs
// 作者：软件部
// 日期：2011/03/04
// 描述：峰对象定义
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人                     修改内容
//
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Wayee.PeakObject
{
    #region 峰对象
    [Serializable]
    public class Peak
    {
        /// <summary>
        /// 峰状态
        /// </summary>
        public enum PeakStates
        {
            /// <summary>
            /// 正常峰
            /// </summary>
            ps_natural = 0,
            /// <summary>
            /// 杂峰
            /// </summary>
            ps_noise,
            /// <summary>
            /// 被禁判峰
            /// </summary>
            ps_inderdict,
            /// <summary>
            /// 合并峰
            /// </summary>
            ps_combine,
            /// <summary>
            /// 被删除峰
            /// </summary>
            ps_delete,
            /// <summary>
            /// 被隐藏
            /// </summary>
            ps_hide,
        };

        public Peak()
        {

        }
        private int _index = -1;
        /// <summary>
        /// 峰索引
        /// </summary>
        public int Index
        {
            get { return _index; }
            set { _index=value; }
        }
        private String _name = null;
        /// <summary>
        /// 峰对象名称（组分名称）
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private PointF startPoint=new PointF();
        /// <summary>
        /// 峰对象起始点
        /// </summary>
        public PointF StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }
        private PointF endPoint = new PointF();
        /// <summary>
        /// 峰对象结束点
        /// </summary>
        public PointF EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }
        private PointF startBaseLine = new PointF();
        /// <summary>
        /// 基线起始点
        /// </summary>
        public PointF StartBaseLine
        {
            get { return startBaseLine; }
            set { startBaseLine = value; }
        }
        private PointF endBaseLine = new PointF();
        /// <summary>
        /// 基线结束点
        /// </summary>        
        public PointF EndBaseLine
        {
            get { return endBaseLine; }
            set { 
                endBaseLine = value; 
            }
        }
        private PointF peakPoint = new PointF();
        /// <summary>
        /// 峰值点
        /// </summary>
        public PointF PeakPoint
        {
            get { return peakPoint; }
            set { peakPoint = value; }
        }
        private int _frontTrendNum =0;
        /// <summary>
        /// 前肩峰数
        /// </summary>
        public int FrontTrendNum
        {
            get { return _frontTrendNum; }
            set { _frontTrendNum = value; }
        }
        private int _backTrendNum = 0;
        /// <summary>
        /// 后肩峰数
        /// </summary>
        public int BackTrendNum
        {
            get { return _backTrendNum; }
            set { _backTrendNum = value; }
        }
        private Double peakHeight = 0;
        /// <summary>
        /// 峰高
        /// </summary>
        public Double PeakHeight
        {
            get { return peakHeight; }
            set { peakHeight = value; }
        }
        private Double peakWidth1 = 0;
        /// <summary>
        /// 峰宽
        /// </summary>
        public Double PeakWidth1
        {
            get { return peakWidth1; }
            set { peakWidth1 = value; }
        }
        private Double peakWidth2 = 0;
        /// <summary>
        /// 半高峰宽
        /// </summary>
        public Double PeakWidth2
        {
            get { return peakWidth2; }
            set { peakWidth2 = value; }
        }
        private Double peakWidth4 = 0;
        /// <summary>
        /// 四分之一高峰宽
        /// </summary>
        public Double PeakWidth4
        {
            get { return peakWidth4; }
            set { peakWidth4 = value; }
        }
        private Int64 plateIdealNum = 0;
        /// <summary>
        /// 理论塔板数目
        /// </summary>
        public Int64 PlateIdealNum
        {
            get { return plateIdealNum; }
            set { plateIdealNum = value; }
        }
        private Int64 plateRealNum = 0;
        /// <summary>
        /// 有效塔板数目
        /// </summary>
        public Int64 PlateRealNum
        {
            get { return plateRealNum; }
            set { plateRealNum = value; }
        }
        private Double tailingFactor = 0;
        /// <summary>
        /// 拖尾因子
        /// </summary>
        public Double TailingFactor
        {
            get { return tailingFactor; }
            set { tailingFactor = value; }
        }
        private Double asymmetricDegree = 0;
        /// <summary>
        /// 不对称度
        /// </summary>
        public Double AsymmetricDegree
        {
            get { return asymmetricDegree; }
            set { asymmetricDegree = value; }
        }
        private Double separatingDegree = 0;
        /// <summary>
        /// 分离度
        /// </summary>
        public Double SeparatingDegree
        {
            get { return separatingDegree; }
            set { separatingDegree = value; }
        }
        private Double capacityFactor = 0;
        /// <summary>
        /// 容量因子
        /// </summary>
        public Double CapacityFactor
        {
            get { return capacityFactor; }
            set { capacityFactor = value; }
        }
        private Double _adjustFactor = 0;
        /// <summary>
        /// 校正因子
        /// </summary>
        public Double AdjustFactor
        {
            get { return _adjustFactor; }
            set { _adjustFactor = value; }
        }

        private Double capacity = 0;
        /// <summary>
        /// 峰对象对应的物质的量
        /// </summary>
        public Double Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        private string _fittingformula = "";
        /// <summary>
        /// 工作曲线拟合公式
        /// </summary>
        public string FittingFormula
        {
            get { return _fittingformula; }
            set { _fittingformula = value; }
        }
        private string _internalStandard = "";
        /// <summary>
        /// 是否内标物
        /// </summary>
        public string InternalStandard
        {
            get { return _internalStandard; }
            set { _internalStandard = value; }
        }
        private bool _checked = false;
        /// <summary>
        /// 是否被选中
        /// </summary>
        public bool Checked
        {
            get { return _checked; }
            set { _checked = value; }
        }
        private Double peakArea = 0;
        /// <summary>
        /// 峰面积
        /// </summary>
        public Double PeakArea
        {
            get { return peakArea; }
            set { peakArea = value; }
        }
        private List<PointF> _protractlist = new List<PointF>();
        /// <summary>
        /// 峰前伸列表
        /// </summary>
        public List<PointF> ProtractList
        {
            get { return _protractlist; }
            set { _protractlist = value; }
        }
        private List<PointF> _tailinglist=new List<PointF>();
        /// <summary>
        /// 峰拖尾列表
        /// </summary>
        public List<PointF> TailingList
        {
            get { return _tailinglist; }
            set { _tailinglist = value; }
        }
        private bool _baselineend = false;
        /// <summary>
        /// 是否终点峰
        /// </summary>
        public bool BaseLineEnd
        {
            get { return _baselineend; }
            set { _baselineend = value; }
        }
        private PeakStates _peakstate = PeakStates.ps_natural;
        /// <summary>
        /// 峰状态
        /// </summary>
        public PeakStates PeakState
        {
            get { return _peakstate; }
            set { _peakstate = value; }
        }
        private bool _ReferencePeak = false;
        /// <summary>
        /// 是否做为参考峰
        /// </summary>
        public bool ReferencePeak
        {
            get { return _ReferencePeak; }
            set { _ReferencePeak = value; }
        }
        private List<double> _Coefficient = new List<double>();
        /// <summary>
        /// 系数列表
        /// </summary>
        public List<double> Coefficient
        {
            get { return _Coefficient; }
            set { _Coefficient = value; }
        }
        private object _Description = null;
        /// <summary>
        /// Description.
        /// </summary>
        public object Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private object _Tag = null;
        /// <summary>
        /// tag.
        /// </summary>
        public object Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
        }
    }
    #endregion

    #region 峰对象列表和点列表
    /// <summary>
    /// 峰对象列表和点列表封装类
    /// </summary>
    public class PeakAndPointList
    {
        private List<Peak> _peakList = new List<Peak>();
        /// <summary>
        /// 峰列表
        /// </summary>
        public List<Peak> PeakList
        {
            get { return _peakList; }
            set { _peakList = value; }
        }
        private List<PointF> _pointList = new List<PointF>();
        /// <summary>
        /// 点列表
        /// </summary>
        public List<PointF> PointList
        {
            get { return _pointList; }
            set { _pointList = value; }
        }
        public PeakAndPointList()
        {
            _peakList = null;
            _pointList = null;
        }
        public PeakAndPointList(List<Peak> objList, List<PointF> pList)
        {
            _peakList = objList;
            _pointList = pList;
        }
        ~PeakAndPointList()
        {
            _peakList = null;
            _pointList = null;
        }
    }
    #endregion

    #region 定量计算模式
    /// <summary>
    /// 定量计算模式
    /// </summary>
    public enum QualitativeMode
    {
        /// <summary>
        /// 峰面积
        /// </summary>
        peakArea = 0,
        /// <summary>
        /// 峰高
        /// </summary>
        peakHeight,
        /// <summary>
        /// 峰面积平方根
        /// </summary>
        peakAreaSquareRoot,
        /// <summary>
        /// 峰高平方根
        /// </summary>
        peakHeightSquareRoot,
    }
    /// <summary>
    /// 定量计算方法
    /// </summary>
    public enum CalculateMethods
    {
        /// <summary>
        /// 归一
        /// </summary>
        cm_Normalizing = 0,
        /// <summary>
        /// 校正归一
        /// </summary>
        cm_CNormalizing,
        /// <summary>
        /// 单点校正
        /// </summary>
        cm_SCorrection,
        /// <summary>
        /// 多点校正
        /// </summary>
        cm_MCorrection
    }
    /// <summary>
    /// 定量计算依据
    /// </summary>
    #endregion

    #region 峰对象过滤器
    public class PeakFilter
    {
        /// <summary>确定可被绘制基线的峰</summary>
        /// <param name="p">峰对象</param>
        /// <returns>符合返回true，否则返回false</returns>
        public static bool MatchBaselinePeak(Peak p)
        {
            return p.PeakState == Peak.PeakStates.ps_natural || p.PeakState == Peak.PeakStates.ps_hide;
        }
    }
    #endregion
}
