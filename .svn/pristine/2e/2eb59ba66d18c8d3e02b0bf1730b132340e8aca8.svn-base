//===============================================================
// Copyright (C) 2010-2020 皖仪科技研发中心
// 文件名: DisTinguishSD.cs
// 日期：2011/03/09
// 描述：定义二阶导数判峰算法
// 版本：1.00
// 修改历史纪录

// 版本         修改时间         修改人           修改内容

//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Wayee.PeakLocation
{
   
    /// <summary>
    /// 二阶导数判定特征点
    /// 需要输入的数据 ：原始数据，原始数据抽样数据，一阶导数，二阶导数，峰列表
    /// 数据一致性需要外部保证（原始数据，原始数据抽样数据，一阶导数，二阶导数，峰列表必须为顺序处理的结果）
    /// </summary>
    class PeakLocationSD : CLocationBase
    {
        #region Define
        /// <summary>
        /// 分离峰列表
        /// </summary>
        List<PeakArgs> _detachedPeakList = new List<PeakArgs>();
        /// <summary>
        /// 融合峰列表
        /// </summary>
        List<PeakArgs> _mixedPeakList = new List<PeakArgs>();
        /// <summary>
        /// 二阶导数极大值列表
        /// </summary>
        List<PointF> _maxList = new List<PointF>();
        /// <summary>
        /// 二阶导数极小值列表
        /// </summary>
        List<PointF> _minList = new List<PointF>();
        /// <summary>
        /// 融合峰二阶导数极大值缓存列表
        /// </summary>
        Dictionary<string, List<PointF>> _mixedPeakMaxExtremumList = new Dictionary<string, List<PointF>>();
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arges"></param>
        public PeakLocationSD(PeakLocationArgs args)
            : base(args)
        { }

        #region public 成员

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            
        }
        /// <summary>
        /// 判峰操作
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            if (!ValidityCheck()) return false;
            //二阶导数列表查找极值
            this._maxList = GetMaxExtremum(this.PeakLocationParam.Second_Order_Derivative);
            this._minList = GetMinExtremum(this.PeakLocationParam.Second_Order_Derivative);
            if (this._minList == null) return false;
            if (this._maxList == null) return false;
            //峰列表分组
            if (!PeakGrouping()) return false;
            //分离峰拐点判断:并传出分离峰
            if (this._detachedPeakList.Count > 0)
            {
                if (this.DetachedPeakTraversing(this._detachedPeakList))
                {
                    foreach (PeakArgs e in this._detachedPeakList)
                    {
                        if (this._Onfoundpeak == null) break;
                        if (e == null) continue;
                        this._Onfoundpeak(this, e);
                    }
                }
            }
            List<PeakArgs> sl = null;
            //遍历融合峰，判断特征点，并传出峰
            for (int i = 0; i < this._mixedPeakList.Count; i++)
            {
                sl = MixedPeakTraversing(this._mixedPeakList[i]);
                if (sl == null) continue;
                for (int j = 0; j < sl.Count; j++)
                {
                    string startflag = sl[j].CharacteristicPointsFlag.Substring(0, 1);
                    string endflag = sl[j].CharacteristicPointsFlag.Substring(sl[j].CharacteristicPointsFlag.Length - 1, 1);
                    this.GetPeakCharacteristicPoints(sl[j], startflag, endflag);
                }
                _mixedPeakList[i].CharacteristicPoints.Clear();
                _mixedPeakList[i].CharacteristicPointsFlag = "";
                for (int k = 1; k < sl.Count; k++)
                {
                    if (k >= sl.Count) continue;
                    if (sl[k - 1] == null) continue;
                    if (sl[k] == null) continue;
                    if (_mixedPeakList[i].CharacteristicPointsFlag == "")
                    {
                        _mixedPeakList[i].CharacteristicPointsFlag += sl[k - 1].CharacteristicPointsFlag;
                        _mixedPeakList[i].CharacteristicPoints.Clear();
                        _mixedPeakList[i].CharacteristicPoints.AddRange(sl[k - 1].CharacteristicPoints);
                    }
                    _mixedPeakList[i].CharacteristicPointsFlag = _mixedPeakList[i].CharacteristicPointsFlag.Substring(0, _mixedPeakList[i].CharacteristicPointsFlag.Length - 1);
                    _mixedPeakList[i].CharacteristicPointsFlag += sl[k].CharacteristicPointsFlag;
                    _mixedPeakList[i].CharacteristicPoints.RemoveAt(_mixedPeakList[i].CharacteristicPoints.Count - 1);
                    _mixedPeakList[i].CharacteristicPoints.AddRange(sl[k].CharacteristicPoints);
                }
                for (int m = 0; m < _mixedPeakList[i].CharacteristicPoints.Count; m++)
                {
                    if (_mixedPeakList[i].CharacteristicPoints[m].IsEmpty)
                    {
                        _mixedPeakList[i].CharacteristicPoints.RemoveAt(m);
                        string subStr = _mixedPeakList[i].CharacteristicPointsFlag.Substring(0, m);
                        subStr += _mixedPeakList[i].CharacteristicPointsFlag.Substring(m + 1);
                        _mixedPeakList[i].CharacteristicPointsFlag = subStr;
                        m = 0;
                    }
                }
                if (this._Onfoundpeak == null) break;
                if (_mixedPeakList[i] == null) continue;
                this._Onfoundpeak(this, _mixedPeakList[i]);
            }
            return true;
        }
        #endregion

        #region private
        /// <summary>
        /// 初始化检查
        /// </summary>
        /// <returns></returns>
        private bool ValidityCheck()
        {
            if (this.PeakLocationParam == null) return false;
            if (this.PeakLocationParam.Second_Order_Derivative == null) return false;
            if (this.PeakLocationParam.SampleData == null) return false;
            if (this.PeakLocationParam.PeakList == null) return false;
            if (this.PeakLocationParam.PeakList.Count == 0) return false;
            if (this.PeakLocationParam.Second_Order_Derivative.Length == 0) return false;
            if (this.PeakLocationParam.SampleData.Length == 0) return false;
            if (this.PeakLocationParam.Second_Order_Derivative.Length != this.PeakLocationParam.SourceData.Length / this.PeakLocationParam.SampleInterval) return false;
            if (this._maxList != null) this._maxList.Clear();
            if (this._minList != null) this._minList.Clear();
            if (this._detachedPeakList != null) this._detachedPeakList.Clear();
            if (this._mixedPeakList != null) this._mixedPeakList.Clear();
            if (this._mixedPeakMaxExtremumList != null) this._mixedPeakMaxExtremumList.Clear();
            return true;
        }

        /// <summary>
        /// 得到最大值列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<PointF> GetMaxExtremum(PointF[] list)
        {
            if (list == null) return null;
            if (list.Length < 5) return null;
            if (double.IsNaN(this.PeakLocationParam.SDNoiseAmplitude))return null ; 
            List<PointF> maxlist = new List<PointF>();
            for (int i = 2; i < list.Length - 2; i++)
            {
                //先判断极大值，在判断极大值两边满足调件
                if (list[i].Y <= list[i - 1].Y) continue;
                if (list[i].Y <= list[i + 1].Y)continue ;
                if (list[i - 1].Y <= list[i - 2].Y)continue ;
                if( list[i + 1].Y <= list[i + 2].Y)continue ;
                if (Math.Abs(list[i].Y) <= this.PeakLocationParam.SDNoiseAmplitude/2.0) continue;
                maxlist.Add(list[i]);
            }
            return maxlist;

        }
        /// <summary>
        /// 得到最小值列表
        /// </summary>
        /// <param name="list"></param>
        private List<PointF> GetMinExtremum(PointF[] list)
        {
            if (list == null) return null;
            if (list.Length < 5) return null;
            if (double.IsNaN(this.PeakLocationParam.SDNoiseAmplitude)) return null;
            List<PointF> minList = new List<PointF>();
            for (int i = 2; i < list.Length - 2; i++)
            {
                if(list[i].Y >= list[i - 1].Y)continue ;
                if (list[i].Y >= list[i + 1].Y)continue ;
                if (list[i - 1].Y >= list[i - 2].Y)continue ;
                if(list[i + 1].Y >= list[i + 2].Y)continue ;
                if (Math.Abs(list[i].Y) <= this.PeakLocationParam.SDNoiseAmplitude/2.0) continue;
                minList.Add(list[i]);                
            }
            return minList;
        }

        /// <summary>
        /// 峰分组，分为分离峰和融合峰
        /// </summary>
        /// <returns></returns>
        private bool PeakGrouping()
        {
            if (this.PeakLocationParam.PeakList == null) return false;
            if (this.PeakLocationParam.PeakList.Count == 0) return false;
            if (this._maxList == null) return false;
            if (this._minList == null) return false;
            this._mixedPeakMaxExtremumList.Clear();
            this._detachedPeakList.Clear();
            this._mixedPeakList.Clear();
            List<PointF> midlist = null;
            for (int i = 0; i < PeakLocationParam.PeakList.Count; i++)
            {
                if (this.PeakLocationParam.PeakList[i] == null) continue;
                midlist = FindPointList(this._maxList
                                          , this.PeakLocationParam.PeakList[i].StartPoint.X
                                          , this.PeakLocationParam.PeakList[i].EndPoint.X
                                          );
                if (midlist == null) continue;
                int count = midlist.Count();
                if (count > 1)
                {
                    PeakLocationParam.PeakList[i].Type = PeakType.Mixed;
                    this._mixedPeakList.Add(PeakLocationParam.PeakList[i]);
                    _mixedPeakMaxExtremumList.Add(PeakLocationParam.PeakList[i].StartPoint.X.ToString(), midlist);
                }
                else if (count == 1)
                {
                    PeakLocationParam.PeakList[i].Type = PeakType.Detached;
                    this._detachedPeakList.Add(PeakLocationParam.PeakList[i]);
                }
            }
            return true;
        } 
        /// <summary>
        /// 遍历分离峰查找拐点
        /// </summary>
        /// <returns></returns>
        private bool DetachedPeakTraversing(List<PeakArgs> DetachedPeakList)
        {
            if (DetachedPeakList == null) return false;
            if (DetachedPeakList.Count == 0) return false;
            for (int i = 0; i < DetachedPeakList.Count; i++)
            {
                if (DetachedPeakList[i] == null) continue;
                GetPeakCharacteristicPoints(DetachedPeakList[i], PeakFlag.O.ToString(), PeakFlag.T.ToString());

            }
            return true;
        }
        /// <summary>
        /// 查找分离峰特征点
        /// </summary>
        /// <param name="peak"></param>
        /// <param name="startflag"></param>
        /// <param name="endflag"></param>
        private void GetPeakCharacteristicPoints(PeakArgs peak, string startflag, string endflag)
        {
            if (peak == null) return;
            if (startflag == null) return;
            if (endflag == null) return;
            peak.Type = PeakType.Detached;
            peak.CharacteristicPointsFlag = startflag
                                          + PeakFlag.U.ToString()
                                          + PeakFlag.I.ToString()
                                          + PeakFlag.A.ToString()
                                          + PeakFlag.I.ToString()
                                          + PeakFlag.U.ToString()
                                          + endflag;
            PointF iptfL = new PointF(float.MinValue, float.MinValue);
            PointF iptfR = new PointF(float.MinValue, float.MinValue);
            CalInflectionPoint(peak, out iptfL, out iptfR);
            if (iptfL.Y != 0f)
                iptfL = PointF.Empty;
            if (iptfR.Y != 0f)
                iptfR = PointF.Empty;
            PointF uptfL = new PointF(float.MaxValue, float.MaxValue);
            PointF uptfR = new PointF(float.MaxValue, float.MaxValue);
            CalUpstarePoint(peak, out uptfL, out uptfR);
            if (uptfL.X == float.MaxValue)
                uptfL = PointF.Empty;
            if (uptfR.X == float.MaxValue)
                uptfR = PointF.Empty;
            peak.CharacteristicPoints.Clear();
            peak.CharacteristicPoints.Add(peak.StartPoint);
            peak.CharacteristicPoints.Add(uptfL);
            peak.CharacteristicPoints.Add(iptfL);
            peak.CharacteristicPoints.Add(peak.PeakPoint);
            peak.CharacteristicPoints.Add(iptfR);
            peak.CharacteristicPoints.Add(uptfR);
            peak.CharacteristicPoints.Add(peak.EndPoint);
        }
        /// <summary>
        /// 查找拐点：过零点
        /// </summary>
        /// <param name="peak"></param>
        /// <returns></returns>
        private bool CalInflectionPoint(PeakArgs peak, out PointF IptfLI, out PointF IptfLR)
        {
           
            IptfLI = new PointF(float.MaxValue, float.MaxValue);
            IptfLR = new PointF(float.MaxValue, float.MaxValue);
            if (peak == null) return false; 
            if (this.PeakLocationParam == null) return false;
            PointF[] zeroBuffer = GetZeroPointF(this.PeakLocationParam.Second_Order_Derivative
                                                , (int)peak.StartPoint.X
                                                , (int)peak.PeakPoint.X);
            PointF UP = CalZeroPointF(zeroBuffer);
            if (UP == PointF.Empty) return false;
            IptfLI = UP;           
            PointF[] zeroBufferR = GetZeroPointF(this.PeakLocationParam.Second_Order_Derivative
                                                , (int)peak.PeakPoint.X
                                                , (int)peak.EndPoint.X);
            UP = CalZeroPointF(zeroBufferR);
            if (UP == PointF.Empty) return false;
            IptfLR = UP;            
            return true;
        }
        /// <summary>
        /// 在点列表中，在给定范围内寻找第一个过零点的前后点
        /// 
        /// </summary>
        /// <param name="srcData"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns>索引0：负值；索引1 ：正值</returns>
        private PointF[] GetZeroPointF(PointF[] srcData, int startIndex, int endIndex)
        {
            if (srcData == null) return null;
            if (startIndex < 0) return null;
            if (endIndex >= srcData.Length) return null;
            if (startIndex >= endIndex) return null;
            if (startIndex >= srcData.Length) return null;
            if (endIndex >= srcData.Length) return null;
            PointF[] buffer = null;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (i - 1 < 0) continue;
                if (srcData[i].Y * srcData[i - 1].Y > 0) continue;
                buffer =new PointF[2];
                buffer[0] = srcData[i-1];
                buffer [1] = srcData [i];
                if (buffer[0].Y >= 0)
                {
                    PointF v = buffer[0];
                    buffer [0]=buffer [1];
                    buffer[1] = v;
                }
                break ;
            }
            return buffer;
        }
        /// <summary>
        /// 计算过零点
        /// </summary>
        /// <param name="srcbuffer"></param>
        /// <returns></returns>
        private PointF CalZeroPointF(PointF[] srcbuffer)
        {
            if (srcbuffer == null) return PointF.Empty;
            if (srcbuffer.Length != 2) return PointF.Empty ;
            if (srcbuffer[0].Y * srcbuffer[1].Y > 0) return PointF.Empty;
            if (srcbuffer[1].Y <= srcbuffer[0].Y) return PointF.Empty;
            PointF UP = srcbuffer[1];
            PointF DP = srcbuffer[0];           
            float X = UP.X - UP.Y * (UP.X - DP.X) / (UP.Y - DP.Y);
            return  new PointF(X, 0);
        }
        /// <summary>
        /// 上坡点，极小值点，负值
        /// </summary>
        /// <param name="peak">原始峰数据源</param>
        /// <param name="IptfLU">左上坡点</param>
        /// <param name="IptfRU">右上坡点</param>
        /// <param name="bFront"></param>
        /// <returns></returns>
        private bool CalUpstarePoint(PeakArgs peak, out PointF IptfLU, out PointF IptfRU)
        {            
            IptfLU = new PointF(float.MaxValue, float.MaxValue);
            IptfRU = new PointF(float.MaxValue, float.MaxValue);
            if (peak == null) return false;
            if (this.PeakLocationParam == null) return false;
            GetMinimumPointF(this.PeakLocationParam.Second_Order_Derivative
                            , (int)peak.StartPoint.X
                            , (int)peak.PeakPoint.X
                            , out IptfLU);
            GetMinimumPointF(this.PeakLocationParam.Second_Order_Derivative
                            , (int)peak.PeakPoint.X
                            , (int)peak.EndPoint.X
                            , out IptfRU);
            return true;
        }
        /// <summary>
        /// 查找给定范围内的小于零的最小值
        /// </summary>
        /// <param name="srcBuffer"></param>
        /// <param name="startX"></param>
        /// <param name="endX"></param>
        private void GetMinimumPointF(PointF[] srcBuffer, int startIndex, int endIndex,out PointF ptf)
        {
            ptf = new PointF(float.MaxValue, float.MaxValue);
            if(srcBuffer ==null)return;
            if(srcBuffer .Length ==0)return ;
             if (startIndex < 0) return ;           
            if (startIndex >= endIndex) return ;
            if (startIndex >= srcBuffer.Length) return ;
            if (endIndex >= srcBuffer.Length) return;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (srcBuffer[i].Y < ptf.Y)
                {
                    if (srcBuffer[i].Y > 0) continue;
                    ptf = srcBuffer [i];
                }
            }
        }

        #region OLD_CODE
        ///// <summary>
        ///// 遍历融合峰，区分峰谷，肩峰和圆角峰
        ///// </summary>
        ///// <returns></returns>
        //List<PeakArgs> MixedPeakTraversing(PeakArgs peak)
        //{
        //    if (peak == null) return null;
        //    if (this.PeakLocationParam.SampleData == null) return null;
        //    if (this._maxList == null) return null;
        //    if (this._minList == null) return null;
        //    if (this._mixedPeakMaxExtremumList == null) return null;
        //    if (!this._mixedPeakMaxExtremumList.ContainsKey(peak.StartPoint.X.ToString())) return null;
        //    List<PointF> MaxEList = this._mixedPeakMaxExtremumList[peak.StartPoint.X.ToString()];
        //    if (MaxEList == null) return null;
        //    if (MaxEList.Count < 2) return null;
        //    List<PeakArgs> singelPeakList = new List<PeakArgs>();
        //    string hisStartFlag = PeakFlag.O.ToString();

        //    //采用的算法是，在所有极大值范围内查找极小值并列表缓存；
        //    //在两个极大值之间，取靠近第二个极大值的极小值做处理，判定是峰谷，或者肩峰
        //    List<PointF> MinEList = FindPointList(this._minList, MaxEList[0].X, MaxEList[MaxEList.Count - 1].X);
        //    if (MinEList == null) return null;
        //    if (MinEList.Count == 0) return null;
        //    for (int i = 1; i < MaxEList.Count; i++)
        //    {
        //        PeakArgs midpeak = new PeakArgs();
        //        if ((i - 1) >= MinEList.Count) break;
        //        if (i == 1)
        //        {
        //            midpeak.StartPoint = peak.StartPoint;
        //        }
        //        else
        //        {
        //            PointF _midptf =FindPoint(MinEList, MaxEList[i-1].X);
        //            if (_midptf == PointF.Empty) continue;
        //            midpeak.StartPoint = _midptf;
        //        }

        //        PointF midptf = FindPoint(MinEList, MaxEList[i].X);
        //        if (midptf == PointF.Empty) continue;
        //        if (midptf.Y > 0f)//判断圆角峰
        //        {
        //            midpeak = CreateSingelPeak(midpeak.StartPoint, MaxEList[i - 1], midptf, hisStartFlag, PeakFlag.R.ToString());
        //            hisStartFlag = PeakFlag.R.ToString();
        //            singelPeakList.Add(midpeak);
        //        }
        //        else//判断峰谷和肩峰
        //        {                   
        //            List<PointF> _mmidlist = FindPointList(this.PeakLocationParam.SampleData, MaxEList[i - 1].X, MaxEList[i].X);
        //            if (_mmidlist == null) continue;
        //            if (_mmidlist.Count == 0) continue;
        //            List<PointF> minli = GetMinExtremum(_mmidlist.ToArray());
        //            if (minli.Count == 0)
        //            {
        //                //重新判断肩峰起点
        //                //二阶导数列表查找极值
        //                //List<PointF> fdMaxList = GetMaxExtremum(this.DistinguishedParameters.First_Order_Derivative );
        //                //List<PointF> fdMinList = GetMinExtremum(this.DistinguishedParameters.First_Order_Derivative);
        //                //List<PointF> midMaxLsit = FindPointList(fdMaxList, 0f, MaxEList[i - 1].X);
        //                //List<PointF> midMinList = FindPointList(fdMinList, 0f, MaxEList[i - 1].X);
        //                //if (midMinList == null) continue;
        //                //if (midMaxLsit == null) continue;
        //                //if (midMinList.Count  == 0) continue;
        //                //if (midMaxLsit.Count  == 0) continue;
        //                //if (midMaxLsit.Last().X > midMinList.Last().X)
        //                //    midpeak.StartPoint = midMaxLsit.Last();
        //                //else
        //                //    midpeak.StartPoint = midMinList.Last();
        //                //end
        //                midpeak = CreateSingelPeak(midpeak.StartPoint, MaxEList[i - 1], midptf, hisStartFlag, PeakFlag.S.ToString());
        //                hisStartFlag = PeakFlag.S.ToString();
        //                singelPeakList.Add(midpeak);
        //            }
        //            else
        //            {
        //                midpeak = CreateSingelPeak(midpeak.StartPoint, MaxEList[i - 1], midptf, hisStartFlag, PeakFlag.V.ToString());
        //                hisStartFlag = PeakFlag.V.ToString();
        //                singelPeakList.Add(midpeak);
        //            }
        //        }

        //    }
        //    PeakArgs lastPeak = CreateSingelPeak(MinEList[MinEList.Count - 1]
        //                                            , MaxEList[MaxEList.Count - 1]
        //                                            , peak.EndPoint, hisStartFlag
        //                                            , PeakFlag.T.ToString());
        //    singelPeakList.Add(lastPeak);
        //    return singelPeakList;
        //}
        #endregion

        #region NEW_CODE
        /// <summary>
        /// 遍历融合峰，区分峰谷，肩峰和圆角峰
        /// </summary>
        /// <returns></returns>
        List<PeakArgs> MixedPeakTraversing(PeakArgs peak)
        {
            if (peak == null) return null;
            if (this.PeakLocationParam.SampleData == null) return null;
            if (this._maxList == null) return null;
            if (this._minList == null) return null;
            if (this._mixedPeakMaxExtremumList == null) return null;
            if (!this._mixedPeakMaxExtremumList.ContainsKey(peak.StartPoint.X.ToString())) return null;

            //找到混合峰的最大极值点列表
            List<PointF> MaxEList = this._mixedPeakMaxExtremumList[peak.StartPoint.X.ToString()];
            if (MaxEList == null) return null;
            if (MaxEList.Count < 2) return null;

            List<PeakArgs> singelPeakList = new List<PeakArgs>();
            string hisStartFlag = PeakFlag.O.ToString();

            //采用的算法是，在所有极大值范围内查找极小值并列表缓存；
            //在两个极大值之间，取靠近第二个极大值的极小值做处理，判定是峰谷，或者肩峰
            //找出最大极值点之间的最小极值点

            List<PointF> MinEList = FindPointList(this._minList, MaxEList[0].X, MaxEList[MaxEList.Count - 1].X);
            if (MinEList == null) return null;
            if (MinEList.Count == 0) return null;

            for (int i = 1; i < MaxEList.Count; i++)
            {
                PeakArgs midpeak = new PeakArgs();
                if ((i - 1) >= MinEList.Count) break;

                if (i == 1)
                {
                    midpeak.StartPoint = peak.StartPoint;
                }
                else
                {
                    PointF _midptf = FindPoint(MinEList, MaxEList[i - 1].X);
                    if (_midptf == PointF.Empty) continue;
                    midpeak.StartPoint = _midptf;
                }

                PointF midptf = FindPoint(MinEList, MaxEList[i].X);
                if (midptf == PointF.Empty) continue;

                if (midptf.Y > 0f)//判断圆角峰
                {
                    midpeak = CreateSinglePeak(midpeak.StartPoint, MaxEList[i - 1], midptf, hisStartFlag, PeakFlag.R.ToString());
                    hisStartFlag = PeakFlag.R.ToString();
                    singelPeakList.Add(midpeak);
                }
                else//判断峰谷和肩峰
                {
                    PointF[] _curve_points = FindPeakCurve(this.PeakLocationParam.SampleData, (int)MaxEList[i - 1].X, (int)MaxEList[i].X);
                    if (_curve_points == null) continue;
                    if (_curve_points.Length == 0) continue;

                    List<PointF> _mini_point_list = GetMinExtremum(_curve_points);

                    if (_mini_point_list.Count == 0)
                    {
                        //重新判断肩峰起点
                        //二阶导数列表查找极值

                        #region
                        //List<PointF> fdMaxList = GetMaxExtremum(this.DistinguishedParameters.First_Order_Derivative );
                        //List<PointF> fdMinList = GetMinExtremum(this.DistinguishedParameters.First_Order_Derivative);
                        //List<PointF> midMaxLsit = FindPointList(fdMaxList, 0f, MaxEList[i - 1].X);
                        //List<PointF> midMinList = FindPointList(fdMinList, 0f, MaxEList[i - 1].X);
                        //if (midMinList == null) continue;
                        //if (midMaxLsit == null) continue;
                        //if (midMinList.Count  == 0) continue;
                        //if (midMaxLsit.Count  == 0) continue;
                        //if (midMaxLsit.Last().X > midMinList.Last().X)
                        //    midpeak.StartPoint = midMaxLsit.Last();
                        //else
                        //    midpeak.StartPoint = midMinList.Last();
                        //end
                        #endregion

                        midpeak = CreateSinglePeak(midpeak.StartPoint, MaxEList[i - 1], midptf, hisStartFlag, PeakFlag.S.ToString());
                        hisStartFlag = PeakFlag.S.ToString();
                        singelPeakList.Add(midpeak);
                    }
                    else
                    {
                        midpeak = CreateSinglePeak(midpeak.StartPoint, MaxEList[i - 1], midptf, hisStartFlag, PeakFlag.V.ToString());
                        hisStartFlag = PeakFlag.V.ToString();
                        singelPeakList.Add(midpeak);
                    }
                }
            }

            PeakArgs lastPeak = CreateSinglePeak(MinEList[MinEList.Count - 1]
                                                    , MaxEList[MaxEList.Count - 1]
                                                    , peak.EndPoint, hisStartFlag
                                                    , PeakFlag.T.ToString());
            singelPeakList.Add(lastPeak);
            return singelPeakList;
        }

        #endregion

        /// <summary>
        /// 在给定的点列表中查找小于给定横坐标的点，默认返回空点
        /// </summary>
        /// <returns></returns>
        private PointF FindPoint(List<PointF > srcList,float endX)
        {
            List<PointF> list = FindPointList(srcList,float.MinValue, endX);
            if (list == null) return PointF.Empty;
            if (list.Count == 0) return PointF.Empty;
            return list.Last();
        }

        /// <summary>
        /// 在给定的点列表中查找小于给定横坐标的点集合，默认返回空列表
        /// </summary>
        /// <returns></returns>
        private List< PointF> FindPointList(List<PointF> srcList,float startX, float endX)
        {
            if (srcList == null) return null;
            if (srcList.Count == 0) return null;
            List<PointF> midptf = new List<PointF>();
            for (int j = 0; j < srcList.Count; j++)
            {
                if (srcList[j].X <= startX) continue;
                if (srcList[j].X >= endX) break;
                midptf.Add(srcList[j]);
            }
            return midptf;
        }
        /// <summary>
        /// 在给定的点列表中查找小于给定横坐标的点集合，默认返回空列表
        /// </summary>
        /// <returns></returns>
        private List<PointF> FindPointList(PointF[] srcList, float startX, float endX)
        {
            if (srcList == null) return null;
            if (srcList.Length == 0) return null;
            List<PointF> midptf = new List<PointF>();
            for (int j = 0; j < srcList.Length ; j++)
            {
                if (srcList[j].X <= startX) continue;
                if (srcList[j].X >= endX) break;
                midptf.Add(srcList[j]);
            }
            return midptf;
        }

        #region NEW_CODE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="curve_list"></param>
        /// <param name="start_index"></param>
        /// <param name="end_index"></param>
        /// <returns></returns>
        private PointF[] FindPeakCurve(PointF[] curve_list, int start_index, int end_index)
        {
            if ((curve_list == null) || curve_list.Length == 0) return null;

            int _count = end_index - start_index - 1;

            if (_count <= 0) return null;

            PointF[] _peak_curve = new PointF[_count];

            Array.Copy(curve_list, start_index + 1, _peak_curve, 0, _count);

            return _peak_curve;
        }
        #endregion

        /// <summary>
        /// 构造单个的分离峰
        /// </summary>
        /// <param name="peak"></param>
        /// <param name="MaxEList"></param>
        /// <param name="hisStartFlag"></param>
        /// <param name="MinEList"></param>
        /// <returns></returns>
        private PeakArgs CreateSinglePeak(PointF StartPoint, PointF PeakPoint, PointF EndPoint, string stargFlag, string endFlag)
        {
            if (stargFlag == null) return null;
            if (endFlag == null) return null;
            PeakArgs lastPeak = new PeakArgs();
            lastPeak.StartPoint = StartPoint;
            lastPeak.PeakPoint = PeakPoint;
            lastPeak.EndPoint = EndPoint;
            lastPeak.CharacteristicPointsFlag = stargFlag
                                                 + PeakFlag.I.ToString()
                                                 + PeakFlag.A.ToString()
                                                 + PeakFlag.I.ToString()
                                                 + endFlag;
            return lastPeak;
        }

        #endregion
    }
}
