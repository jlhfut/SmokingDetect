//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: DistinguishedManager.cs
// 日期：2012/10/18
// 描述：判峰算法管理器
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
// 
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wayee.Filter;
using Wayee.Filter.SG;
using System.Drawing;

namespace Wayee.PeakLocation
{   
    /// <summary>
    /// 判峰算法基类:需要继承此类，重写实现方法，实现不同类型的判峰算法
    /// </summary>
    public abstract class CPeakLocationBase : CLocationBase
    {
        #region 参数
        /// <summary>
        /// 一阶导数判峰算法实例
        /// </summary>
        private IPeakLocation _PeakLocationFD = null;
        /// <summary>
        /// 一阶导数判峰算法实例
        /// </summary>
        protected IPeakLocation PeakLocationFD
        {
            get { return _PeakLocationFD; }
            set { _PeakLocationFD = value; }
        }
        /// <summary>
        /// 二阶导数判峰算法实例
        /// </summary>
        private IPeakLocation _PeakLocationSD = null;
        /// <summary>
        /// 二阶导数判峰算法实例
        /// </summary>
        protected IPeakLocation PeakLocationSD
        {
            get { return _PeakLocationSD; }
            set { _PeakLocationSD = value; }
        }
        /// <summary>
        /// 数据还原算法实例
        /// </summary>
        private IPeakLocation _PeakDataRecovering = null;
        /// <summary>
        /// 数据还原算法实例
        /// </summary>
        protected IPeakLocation PeakDataRecovering
        {
            get { return _PeakDataRecovering; }
            set { _PeakDataRecovering = value; }
        }
        /// <summary>
        /// 峰列表后处理算法实例
        /// </summary>
        private IPeakLocation _PeakMerging = null;
        /// <summary>
        /// 峰列表后处理算法实例
        /// </summary>
        protected IPeakLocation PeakMerging
        {
            get { return _PeakMerging; }
            set { _PeakMerging = value; }
        }
        #endregion

        #region define

        /// <summary>
        /// SG滤波器
        /// </summary>
        IFilter _SG_Filter = new SavitzkyGolay();
        /// <summary>
        /// SG滤波器参数
        /// </summary>
        SGFilterArgs _SG_Arges = new SGFilterArgs();
        /// <summary>
        /// 微分计算器
        /// </summary>
        Differentiate _dfferentiateFilter = new Differentiate();
        /// <summary>
        /// 微分计算参数
        /// </summary>
        DifferentiateFilterArgs _diffArges = new DifferentiateFilterArgs();
        /// <summary>
        /// 
        /// </summary>
        Sample _sampleFilter = new Sample();
        /// <summary>
        /// 抽样参数
        /// </summary>
        SampleArgs _sampleArges = new SampleArgs();
        /// <summary>
        /// 原始数据横坐标变换匹配表
        /// </summary>
        //PointF[] _OriginalData = null;

        /// <summary>
        /// 一阶导数判峰导出列表
        /// </summary>
        protected List<PeakArgs> _DSDPeakList = new List<PeakArgs>();
        /// <summary>
        /// 二阶导数判峰导出列表
        /// </summary>
        protected List<PeakArgs> _DFDPeakList = new List<PeakArgs>();
        /// <summary>
        /// 数据还原判峰导出列表
        /// </summary>
        protected List<PeakArgs> _RSDPeakList = new List<PeakArgs>();
        /// <summary>
        /// 峰后处理导出列表
        /// </summary>
        protected List<PeakArgs> _PRPPeakList = new List<PeakArgs>();
        /// <summary>
        /// 一阶导数二阶导数缩放比例
        /// </summary>
        double _scaleRate = 1000.0;
        #endregion

        /// <summary>
        /// construct
        /// 
        /// </summary>
        public CPeakLocationBase()
        {

            InitProcessor();
        }

        /// <summary>
        /// 判峰器初始化，可重写
        /// </summary>
        protected virtual void InitProcessor()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            if (!ValidityCheck()) return false;

            _DSDPeakList.Clear();
            _DFDPeakList.Clear();
            _RSDPeakList.Clear();
            _PRPPeakList.Clear();

            if (this.PeakLocationParam == null) return false;
            if (this.PeakLocationParam.SourceData == null) return false;
            if (this.PeakLocationParam.SourceData.Length == 0) return false;

            double[] srcVal = new double[this.PeakLocationParam.SourceData.Length];
            //_OriginalData = new PointF[this.PeakLocationParam.SourceData.Length];

            //缓存传入数据的横坐标：因为后续DSP处理以double数据类型进行，同时避免传入数据的横坐标不连续，给后续处理带来问题
            for (int i = 0; i < this.PeakLocationParam.SourceData.Length; i++)
            {
                srcVal[i] = this.PeakLocationParam.SourceData[i].Y;
                //_OriginalData[i] = this.PeakLocationParam.SourceData[i];                
                //this.PeakLocationParam.SourceData[i] = new PointF((float)i, (float)srcVal[i]);
            }

            //原始数据滤波
            _SG_Arges.Order = this.PeakLocationParam.SG_Order;
            _SG_Arges.SidePoint = this.PeakLocationParam.SG_SideWindowLength;
            double[] resVal = _SG_Filter.Process(srcVal, _SG_Arges);
            if (resVal == null) return false;
            if (resVal.Length != this.PeakLocationParam.SourceData.Length) return false;
            //for (int i = 0; i < srcVal.Length; i++)
            //{
            //    this.PeakLocationParam.SourceData[i] = new PointF((float)i, (float)resVal[i]);                
            //}

            //原始数据抽样
            this._sampleArges.Interval = this.PeakLocationParam.SampleInterval;
            double[] sampleBuffer = this._sampleFilter.Process(resVal, this._sampleArges);
            if ((sampleBuffer == null) || (sampleBuffer.Length == 0)) return false;
            if (sampleBuffer.Length != resVal.Length / this.PeakLocationParam.SampleInterval) return false;

            System.Drawing.PointF[] sampleData = new System.Drawing.PointF[sampleBuffer.Length];
            for (int i = 0; i < sampleData.Length; i++)
            {
                sampleData[i] = new PointF((float)i, (float)sampleBuffer[i]);
            }
            this.PeakLocationParam.SampleData = sampleData;
            //计算一阶导数
            _diffArges.Dt = this.PeakLocationParam.TimeSpan * this.PeakLocationParam.SampleInterval;
            _diffArges.InitialCondition = sampleBuffer[0];
            _diffArges.FinalCondition = sampleBuffer[sampleBuffer.Length - 1];
            double[] fd = _dfferentiateFilter.Process(sampleBuffer, _diffArges);
            if ((fd == null) || (fd.Length == 0)) return false;

            Scale(fd, _scaleRate);
            PointF[] FdBuffer = new PointF[fd.Length];
            for (int i = 0; i < fd.Length; i++)
            {
                FdBuffer[i] = new PointF((float)i, (float)fd[i]);
            }
            this.PeakLocationParam.First_Order_Derivative = FdBuffer;

            //计算二阶导数
            _diffArges.InitialCondition = fd[0];
            _diffArges.FinalCondition = fd[fd.Length - 1];
            double[] ffd = _dfferentiateFilter.Process(fd, _diffArges);
            if (ffd == null) return false;
            _SG_Arges.Order = 2;
            _SG_Arges.SidePoint = 12;
            ffd = _SG_Filter.Process(ffd, _SG_Arges);            //2. 二阶导数S-G滤波
            if (ffd == null) return false;
            _SG_Arges.Order = 3;
            _SG_Arges.SidePoint = 12;
            ffd = _SG_Filter.Process(ffd, _SG_Arges);//3. 二阶导数S-G滤波//
            if (ffd == null) return false;
            Scale(ffd, _scaleRate);
            if (ffd == null) return false;
            Scale(ffd, -1.0);// 3-1 二阶导数翻转
            if (ffd == null) return false;
            if (ffd.Length != fd.Length) return false;
            this.PeakLocationParam.SDNoiseAmplitude = this.PeakLocationParam.SDNoiseAmplitude * _scaleRate;
            PointF[] SdBuffer = new PointF[ffd.Length];
            for (int i = 0; i < ffd.Length; i++)
            {
                SdBuffer[i] = new PointF((float)i, (float)ffd[i]);
            }
            this.PeakLocationParam.Second_Order_Derivative = SdBuffer;
            // 开始平判峰
            this.PeakProcess();
            //传送数据:单个峰为对象传递，考虑可以逐次显示
            if (this._Onfoundpeak == null) return false;
            if (this.PeakLocationParam.PeakList == null) return false;
            if (this.PeakLocationParam.PeakList.Count == 0) return false;
            for (int i = 0; i < this.PeakLocationParam.PeakList.Count; i++)
            {
                this._Onfoundpeak(this, this.PeakLocationParam.PeakList[i]);
            }
            return true;
        }
        /// <summary>
        /// 判峰处理:填写判峰步骤，填写峰结果列表
        /// </summary>
        /// <returns></returns>
        protected virtual bool PeakProcess()
        {
            return false;

        }

        /// <summary>
        /// 有效性检查
        /// </summary>
        /// <returns></returns>
        protected bool ValidityCheck()
        {
            if (this.PeakLocationParam == null) return false;
            if (this.PeakLocationParam.SourceData == null) return false;
            return true;
        }
        /// <summary>
        /// 一阶导数判峰数据接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _DFD_OnPeakFound(object sender, PeakArgs e)
        {
            if (e == null) return;
            _DFDPeakList.Add(e);
        }
        /// <summary>
        /// 二阶导数判峰数据接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _DSD_OnPeakFound(object sender, PeakArgs e)
        {
            if (e == null) return;
            _DSDPeakList.Add(e);
        }
        /// <summary>
        /// 原始数据匹配处理峰数据接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _RSD_OnPeakFound(object sender, PeakArgs e)
        {
            if (e == null) return;
            _RSDPeakList.Add(e);
        }
        /// <summary>
        /// 峰列表后处理数据接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _PRP_OnPeakFound(object sender, PeakArgs peak)
        {
            if (peak == null) return;
            
            #region delete
            //if (this._OriginalData == null) return;
            //if (this._OriginalData.Length == 0) return;

            //int _index = 0;

            //for (int i = 0; i < peak.CharacteristicPoints.Count; i++)
            //{
            //    _index = (int)(peak.CharacteristicPoints[i].X);
            //    if (_index >= this._OriginalData.Length) return;
            //    peak.CharacteristicPoints[i] = new PointF(_OriginalData[_index].X, _OriginalData[_index].Y);
            //}

            //_index = (int)(peak.StartPoint.X);
            //if (_index >= this._OriginalData.Length) return;
            //peak.StartPoint = new PointF(_OriginalData[_index].X, _OriginalData[_index].Y);

            //_index = (int)(peak.PeakPoint.X);
            //if (_index >= this._OriginalData.Length) return;
            //peak.PeakPoint = new PointF(_OriginalData[_index].X, _OriginalData[_index].Y);

            //_index = (int)(peak.EndPoint.X);
            //if (_index >= this._OriginalData.Length) return;
            //peak.EndPoint = new PointF(_OriginalData[_index].X, _OriginalData[_index].Y);        
            #endregion

            #region OLD_CODE
            //if (peak == null) return;
            //if (this._srcDataMatchList == null) return;
            //if (this._srcDataMatchList.Count == 0) return;

            //for (int i = 0; i < peak.CharacteristicPoints.Count; i++)
            //{
            //    if (!_srcDataMatchList.ContainsKey(peak.CharacteristicPoints[i].X)) return;
            //    peak.CharacteristicPoints[i] = new PointF(_srcDataMatchList[peak.CharacteristicPoints[i].X], peak.CharacteristicPoints[i].Y);
            //}

            //if (!_srcDataMatchList.ContainsKey(peak.StartPoint.X)) return;
            //peak.StartPoint = new PointF(_srcDataMatchList[peak.StartPoint.X], peak.StartPoint.Y);
            //if (!_srcDataMatchList.ContainsKey(peak.PeakPoint.X)) return;
            //peak.PeakPoint = new PointF(_srcDataMatchList[peak.PeakPoint.X], peak.PeakPoint.Y);
            //if (!_srcDataMatchList.ContainsKey(peak.EndPoint.X)) return;
            //peak.EndPoint = new PointF(_srcDataMatchList[peak.EndPoint.X], peak.EndPoint.Y);              
            #endregion

            _PRPPeakList.Add(peak);
        }
        /// <summary>
        /// 缩放数据
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="sceal"></param>
        private void Scale(double[] buf, double sceal)
        {
            for (int i = 0; i < buf.Length; i++)
                buf[i] *= sceal;
        }
    }

    /// <summary>
    /// 规则传统积分：积分判断分离度并合并为峰谷
    /// </summary>
    class PeakLocationTraditionWithMerging : CPeakLocationBase
    {
        /// <summary>
        /// 初始化判峰器
        /// </summary>
        protected override void  InitProcessor()
        {
            PeakLocationFD = new CPeakLocationFD(this.PeakLocationParam);
            PeakLocationFD.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(_DFD_OnPeakFound);

            PeakLocationSD = null;
            // PeakLocationSD.OnPeakFound += new PeakFoundEvent.PeakfoundeventHandler(_DSD_OnPeakFound);

            PeakDataRecovering = new CPeakDataRecovering(this.PeakLocationParam);
            PeakDataRecovering.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(_RSD_OnPeakFound);

            PeakMerging = new CPeakMergingTradition(this.PeakLocationParam);
            PeakMerging.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(_PRP_OnPeakFound);
        }

        /// <summary>
        /// 判峰步骤
        /// </summary>
        /// <returns></returns>
        protected override bool PeakProcess()
        {
            if (this.PeakLocationFD == null) return false;
            this.PeakLocationFD.Init();
            this.PeakLocationFD.PeakLocationParam = this.PeakLocationParam;
            this.PeakLocationFD.Execute();
            this.PeakLocationParam.PeakList = _DFDPeakList;

            if (this.PeakDataRecovering == null) return false;
            this.PeakDataRecovering.PeakLocationParam = this.PeakLocationParam;
            if (this.PeakDataRecovering.Execute())
                this.PeakLocationParam.PeakList = this._RSDPeakList;
            if (this.PeakMerging == null) return false;
            
            this.PeakMerging.PeakLocationParam = this.PeakLocationParam;
            if (this.PeakMerging.Execute())
                this.PeakLocationParam.PeakList = _PRPPeakList;
            return true;            
        }
    }

    /// <summary>
    /// 规则传统积分：积分不判断分离度不合并为峰谷
    /// </summary>
    class PeakLocationTraditionWithoutMerging : CPeakLocationBase
    {
        /// <summary>
        /// 初始化判峰器
        /// </summary>
        protected override void InitProcessor()
        {
            PeakLocationFD = new CPeakLocationFD(this.PeakLocationParam);
            PeakLocationFD.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(_DFD_OnPeakFound);

            PeakLocationSD = null;
            // PeakLocationSD.OnPeakFound += new PeakFoundEvent.PeakfoundeventHandler(_DSD_OnPeakFound);

            PeakDataRecovering = new CPeakDataRecovering(this.PeakLocationParam);
            PeakDataRecovering.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(_RSD_OnPeakFound);

            PeakMerging = new CPeakMergingDoNothing(this.PeakLocationParam);
            PeakMerging.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(_PRP_OnPeakFound);
        }

        /// <summary>
        /// 判峰步骤
        /// </summary>
        /// <returns></returns>
        protected override bool PeakProcess()
        {
            if (this.PeakLocationFD == null) return false;
            this.PeakLocationFD.Init();
            this.PeakLocationFD.PeakLocationParam = this.PeakLocationParam;
            this.PeakLocationFD.Execute();
            this.PeakLocationParam.PeakList = _DFDPeakList;

            double min = this.PeakLocationParam.MinimumWidth;
            this.PeakLocationParam.MinimumWidth = double.NaN;
            double noi = this.PeakLocationParam.BaseLineNoiseAmplitude;
            this.PeakLocationParam.BaseLineNoiseAmplitude = double.NaN;
            
            if (this.PeakDataRecovering == null) return false;
            this.PeakDataRecovering.PeakLocationParam = this.PeakLocationParam;
            if (this.PeakDataRecovering.Execute())
                this.PeakLocationParam.PeakList = this._RSDPeakList;
            
            this.PeakLocationParam.MinimumWidth = min;
            this.PeakLocationParam.BaseLineNoiseAmplitude = noi;
            
            if (this.PeakMerging == null) return false;
            this.PeakMerging.PeakLocationParam = this.PeakLocationParam;
            if (this.PeakMerging.Execute())
                this.PeakLocationParam.PeakList = _PRPPeakList;
            
            return true;
        }
    }

    /// <summary>
    /// 规则混合积分：积分判断特征点，判断分离度并合并为峰谷
    /// </summary>
    class PeakLocationAdvancedWithMegring : CPeakLocationBase
    {
        /// <summary>
        /// 初始化判峰器
        /// </summary>
        protected override void InitProcessor()
        {
            PeakLocationFD = new CPeakLocationFD(this.PeakLocationParam);
            PeakLocationFD.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(_DFD_OnPeakFound);

            PeakLocationSD = new PeakLocationSD (this .PeakLocationParam);
            PeakLocationSD.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(_DSD_OnPeakFound);

            PeakDataRecovering = new CPeakDataRecovering(this.PeakLocationParam);
            PeakDataRecovering.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(_RSD_OnPeakFound);

            PeakMerging = new CPeakMergingAdvanced(this.PeakLocationParam);
            PeakMerging.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(_PRP_OnPeakFound);
        }

        /// <summary>
        /// 判峰步骤
        /// </summary>
        /// <returns></returns>
        protected override bool PeakProcess()
        {
            if (this.PeakLocationFD == null) return false;
            this.PeakLocationFD.Init();
            this.PeakLocationFD.PeakLocationParam = this.PeakLocationParam;
            this.PeakLocationFD.Execute();
            this.PeakLocationParam.PeakList = _DFDPeakList;

            if (this.PeakLocationSD == null) return false;
            this.PeakLocationSD.PeakLocationParam = this.PeakLocationParam;
            if (this.PeakLocationSD.Execute())
                this.PeakLocationParam.PeakList = _DSDPeakList;

            if (this.PeakDataRecovering == null) return false;
            this.PeakDataRecovering.PeakLocationParam = this.PeakLocationParam;
            if (this.PeakDataRecovering.Execute())
                this.PeakLocationParam.PeakList = this._RSDPeakList;

            if (this.PeakMerging == null) return false;
            this.PeakMerging.PeakLocationParam = this.PeakLocationParam;
            if (this.PeakMerging.Execute())
                this.PeakLocationParam.PeakList = _PRPPeakList;
            
            return true;
        }
    }

    /// <summary>
    /// 不规则混合积分：积分判断特征点不判断分离度不合并为峰谷
    /// </summary>
    class PeakLocationAdvancedWithoutMerging : CPeakLocationBase
    {
        /// <summary>
        /// 初始化判峰器
        /// </summary>
        protected override void InitProcessor()
        {

            PeakLocationFD = new CPeakLocationFD(this.PeakLocationParam);
            PeakLocationFD.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(_DFD_OnPeakFound);

            PeakLocationSD = new PeakLocationSD (this .PeakLocationParam);
            PeakLocationSD.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(_DSD_OnPeakFound);

            PeakDataRecovering = new CPeakDataRecovering(this.PeakLocationParam);
            PeakDataRecovering.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(_RSD_OnPeakFound);

            PeakMerging = new CPeakMergingDoNothing (this.PeakLocationParam);
            PeakMerging.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(_PRP_OnPeakFound);
        }

        /// <summary>
        /// 判峰步骤
        /// </summary>
        /// <returns></returns>
        protected override bool PeakProcess()
        {
            if (this.PeakLocationFD == null) return false;
            this.PeakLocationFD.Init();
            this.PeakLocationFD.PeakLocationParam = this.PeakLocationParam;
            this.PeakLocationFD.Execute();
            this.PeakLocationParam.PeakList = _DFDPeakList;

            if (this.PeakLocationSD == null) return false;
            this.PeakLocationSD.PeakLocationParam = this.PeakLocationParam;
            if (this.PeakLocationSD.Execute())
                this.PeakLocationParam.PeakList = _DSDPeakList;
            
            if (this.PeakDataRecovering == null) return false;
            this.PeakDataRecovering.PeakLocationParam = this.PeakLocationParam;
            if (this.PeakDataRecovering.Execute())
                this.PeakLocationParam.PeakList = this._RSDPeakList;

            if (this.PeakMerging == null) return false;
            this.PeakMerging.PeakLocationParam = this.PeakLocationParam;
            if (this.PeakMerging.Execute())
                this.PeakLocationParam.PeakList = _PRPPeakList;

            return true;
        }
    }
}
