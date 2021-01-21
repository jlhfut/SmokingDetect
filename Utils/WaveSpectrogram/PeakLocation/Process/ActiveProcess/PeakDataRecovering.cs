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
    /// 传入原始数据和峰列表，根据抽样率，计算各特征点原始数据并更新特征点数据
    /// 分别根据不同特征点数据计算方法不同：
    /// 起点：在所给定的抽样范围内找最小值为起点
    /// 拐点：在所给定的抽样范围内找中值为拐点
    /// 顶点：在所给定的抽样范围内查找最大值为顶点
    /// 谷点：在所给定的抽样范围内查找最小值为谷点
    /// 肩峰边界：在所给定的抽样范围内查找最小值为肩峰边界
    /// 圆角峰边界：在给定的抽样范围内查找最大值为圆角峰边界
    /// </summary>
    class CPeakDataRecovering : CLocationBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arges"></param>
        public CPeakDataRecovering(PeakLocationArgs arges)
            : base(arges)
        { }

        #region IPeakLocation 成员

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            if (!ValidityCheck()) return false;
            if (this._Onfoundpeak == null) return false;

            for (int i = 0; i < this.PeakLocationParam.PeakList.Count; i++)
            {
                if (!this.RecoverPeakArges(this.PeakLocationParam.PeakList[i])) continue;
                if (!double.IsNaN(this.PeakLocationParam.MinimumWidth))
                {
                    if (CalWidth(this.PeakLocationParam.PeakList[i]) <= this.PeakLocationParam.MinimumWidth)
                        continue;
                }
                if (!double.IsNaN(this.PeakLocationParam.BaseLineNoiseAmplitude))
                {
                    if (CalHeight(this.PeakLocationParam.PeakList[i]) <= this.PeakLocationParam.BaseLineNoiseAmplitude)
                        continue;
                }
                this._Onfoundpeak(this, this.PeakLocationParam.PeakList[i]);
            }

            return true;
        }

        #endregion

        #region protected
        /// <summary>
        /// 有效性检查
        /// </summary>
        /// <returns></returns>
        protected virtual bool ValidityCheck()
        {
            if (this.PeakLocationParam.PeakList == null) return false;
            if (this.PeakLocationParam.PeakList.Count == 0) return false;
            if (this.PeakLocationParam.SourceData == null) return false;
            if (this.PeakLocationParam.SourceData.Length == 0) return false;
            if (this.PeakLocationParam.SampleInterval < 1) return false;
            return true;
        }

        /// <summary>
        /// 根据抽样率和原始数据，还原抽样后的峰特征点
        /// </summary>
        /// <param name="peak"></param>
        /// <param name="srcData"></param>
        /// <param name="SampleInterval"></param>
        /// <returns></returns>
        protected virtual bool RecoverPeakArges(PeakArgs peak)
        {
            if ((peak.CharacteristicPointsFlag == null) || (peak.CharacteristicPointsFlag == string.Empty))
                return RecoverDataWithoutFlag(peak);
            if (peak.CharacteristicPointsFlag.Length != peak.CharacteristicPoints.Count)
                return RecoverDataWithoutFlag(peak);

            return RecoverDataWithFlag(peak);
        }

        #region NEW_CODE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcList"></param>
        /// <param name="startX"></param>
        /// <param name="endX"></param>
        /// <returns></returns>
        protected virtual PointF[] FindDataList(PointF[] input_data, float start_index, float end_index)
        {
            if (input_data == null) return null;
            if (input_data.Length == 0) return null;
            if (end_index >= input_data.Count()) end_index = input_data.Count() - 1;

            int _data_len = (int)end_index - (int)start_index;
            if (_data_len < 0) return null;
            _data_len += 1;

            PointF[] _output_data = new PointF[_data_len];
            //Array.Copy(srcList, (int)startX, _output_data, 0, _data_len);

            int j = 0;
            for (int i = (int)start_index; i <= (int)end_index; i++)
            {
                _output_data[j] = input_data[i];
                j++;
            }

            return _output_data;
        }
        /// <summary>
        /// 
        /// </summary>
        public class PointFComparer : IComparer<PointF>
        {
            public int Compare(PointF p1, PointF p2)
            {
                return p1.Y.CompareTo(p2.Y);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input_data"></param>
        /// <returns></returns>
        private PointF[] FindKeyPoint(PointF[] input_data)
        {
            if (input_data == null) return null;
            if (input_data.Length == 0) return null;

            PointF[] sort_point = new PointF[input_data.Length];

            input_data.CopyTo(sort_point, 0);
            Array.Sort(sort_point, new PointFComparer());

            PointF[] _key = new PointF[3];

            _key[0] = sort_point.First();
            _key[2] = sort_point.Last();
            _key[1] = sort_point[sort_point.Length / 2];

            return _key;
        }

        /// <summary>
        /// 覆盖原始数据（目标峰必须具有CharacteristicPointsFlag）
        /// 供RecoverPeakArges调用
        /// </summary>
        /// <param name="peak"></param>
        /// <returns></returns>
        protected virtual bool RecoverDataWithFlag(PeakArgs peak)
        {
            if (peak.CharacteristicPointsFlag == null)
                return false;
            if (peak.CharacteristicPointsFlag == string.Empty)
                return false;
            if (peak.CharacteristicPointsFlag.Length != peak.CharacteristicPoints.Count) return false;

            peak.PeakPoint = PointF.Empty;

            List<PointF> _cpoint_list = new List<PointF>();

            for (int i = 0; i < peak.CharacteristicPointsFlag.Length; i++)
            {
                PointF _cpoint = peak.CharacteristicPoints[i];
                if (_cpoint.IsEmpty) continue;

                float _start_offset = (i == 0) ? 2 : (peak.CharacteristicPoints[i].X - peak.CharacteristicPoints[i - 1].X) / 2;
                float _end_offset = (i < peak.CharacteristicPoints.Count - 1) ? (peak.CharacteristicPoints[i + 1].X - peak.CharacteristicPoints[i].X) / 2 : 2;

                _start_offset = _start_offset > 20 ? 20 : _start_offset;
                _end_offset = _end_offset > 20 ? 20 : _end_offset;

                //_start_offset = _start_offset < 10 ? 10 : _start_offset;
                //_end_offset = _end_offset < 10 ? 10 : _end_offset;

                float _start_point = _cpoint.X - _start_offset;
                float _end_point = _cpoint.X + _end_offset;

                _start_point = _start_point < 0 ? 0 : _start_point;
                _end_point = _end_point < 0 ? 0 : _end_point;
                _end_point = _end_point <= _start_point ? _start_point + 1 : _end_point;

                PointF[] _curve_point = FindDataList(this.PeakLocationParam.SourceData, _start_point * this.PeakLocationParam.SampleInterval, (_end_point) * this.PeakLocationParam.SampleInterval);

                if (_curve_point == null) continue;
                if (_curve_point.Length == 0) continue;

                string CharacteristicFlag = peak.CharacteristicPointsFlag.Substring(i, 1);

                PeakFlag flag = (PeakFlag)Enum.Parse(typeof(PeakFlag), CharacteristicFlag);
                PointF[] _key_point = FindKeyPoint(_curve_point);
                if (_key_point == null) continue;

                switch (flag)
                {
                    case PeakFlag.O:
                        _cpoint_list.Add(_key_point[0]);
                        peak.StartPoint = _key_point[0];
                        break;
                    case PeakFlag.I:
                        PointF _point = FindData(this.PeakLocationParam.SourceData, _cpoint.X * this.PeakLocationParam.SampleInterval);
                        _cpoint_list.Add(_point);
                        break;
                    case PeakFlag.A:
                        _cpoint_list.Add(_key_point[2]);
                        if (peak.PeakPoint.IsEmpty)
                            peak.PeakPoint = _key_point[2];

                        if (_key_point[2].Y > peak.PeakPoint.Y)
                            peak.PeakPoint = _key_point[2];

                        if (peak.PeakPoint.X < peak.StartPoint.X)
                            break;
                        break;
                    case PeakFlag.S:
                        _cpoint_list.Add(_key_point[0]);
                        break;
                    case PeakFlag.R:
                        _cpoint_list.Add(_key_point[1]);
                        break;
                    case PeakFlag.V:
                        _cpoint_list.Add(_key_point[0]);
                        break;
                    case PeakFlag.T:
                        _cpoint_list.Add(_key_point[0]);
                        peak.EndPoint = _key_point[0];
                        break;
                    case PeakFlag.U:
                        _point = FindData(this.PeakLocationParam.SourceData, _cpoint.X * this.PeakLocationParam.SampleInterval);
                        _cpoint_list.Add(_point);
                        break;
                }
            }

            peak.CharacteristicPoints = _cpoint_list;
            return true;
        }
        #endregion

        #region OLD_CODE
        ///// <summary>
        ///// 查找数据
        ///// </summary>
        ///// <param name="srcList"></param>
        ///// <param name="start"></param>
        ///// <param name="end"></param>
        ///// <returns></returns>
        //protected virtual List<PointF> FindDataList(PointF[] srcList, float startX, float endX)
        //{ 
        //    if(srcList ==null)return null ;
        //    if(srcList.Length ==0)return null ;
        //    if (endX >= srcList.Count()) return null;
        //    List<PointF> list = new List<PointF>();
        //    for (int i =(int) startX; i <=(int) endX;i++ )
        //    {
        //        list.Add(srcList [i]);
        //    }
        //    if (list.Count == 0) return null;
        //    return list;
        //}

        ///// <summary>
        ///// 覆盖原始数据（目标峰必须具有CharacteristicPointsFlag）
        ///// 供RecoverPeakArges调用
        ///// </summary>
        ///// <param name="peak"></param>
        ///// <returns></returns>
        //protected virtual bool RecoverDataWithFlag(PeakArgs peak)
        //{
        //    if (peak.CharacteristicPointsFlag == null)
        //        return false;
        //    if (peak.CharacteristicPointsFlag == string.Empty)
        //        return false;
        //    if (peak.CharacteristicPointsFlag.Length != peak.CharacteristicPoints.Count) return false;

        //    peak.PeakPoint = PointF.Empty;

        //    List<PointF> _feature_point = new List<PointF>();

        //    for (int i = 0; i < peak.CharacteristicPointsFlag.Length; i++)
        //    {
        //        PointF CharacteristicPoint = peak.CharacteristicPoints[i];
        //        if (CharacteristicPoint.IsEmpty) continue;

        //        float _start_offset = (i == 0) ? 2 : (peak.CharacteristicPoints[i].X - peak.CharacteristicPoints[i - 1].X) / 2;
        //        float _end_offset = (i < peak.CharacteristicPoints.Count - 1) ? (peak.CharacteristicPoints[i + 1].X - peak.CharacteristicPoints[i].X) / 2 : 2;

        //        _start_offset = _start_offset > 20 ? 20 : _start_offset;
        //        _end_offset = _end_offset > 20 ? 20 : _end_offset;

        //        //_start_offset = _start_offset < 10 ? 10 : _start_offset;
        //        //_end_offset = _end_offset < 10 ? 10 : _end_offset;

        //        float _start_point = CharacteristicPoint.X - _start_offset;
        //        float _end_point = CharacteristicPoint.X + _end_offset;

        //        _start_point = _start_point < 0 ? 0 : _start_point;
        //        _end_point = _end_point < 0 ? 0 : _end_point;
        //        _end_point = _end_point <= _start_point ? _start_point + 1 : _end_point;

        //        List<PointF> _curve_point = FindDataList(this.PeakLocationParam.SourceData, _start_point * this.PeakLocationParam.SampleInterval, (_end_point ) * this.PeakLocationParam.SampleInterval);

        //        if (_curve_point == null) continue ;
        //        if (_curve_point.Count == 0) continue;

        //        string CharacteristicFlag = peak.CharacteristicPointsFlag.Substring(i, 1);

        //        PeakFlag flag = (PeakFlag)Enum.Parse(typeof(PeakFlag), CharacteristicFlag);
        //        PointF[] _key = FindValue(_curve_point);
        //        if (_key == null) continue;

        //        switch (flag)
        //        {
        //            case PeakFlag.O:
        //                //peak.CharacteristicPoints.Add(_key[0]);
        //                _feature_point.Add(_key[0]);
        //                peak.StartPoint = _key[0];
        //                break;
        //            case PeakFlag.I:
        //                PointF ptf = FindData(this .PeakLocationParam .SourceData , CharacteristicPoint.X*this .PeakLocationParam.SampleInterval);
        //                _feature_point.Add(ptf);
        //                //peak.CharacteristicPoints.Add(ptf);
        //                break;
        //            case PeakFlag.A:
        //                //peak.CharacteristicPoints.Add(_key[2]);
        //                _feature_point.Add(_key[2]);
        //                if (peak.PeakPoint.IsEmpty)
        //                    peak.PeakPoint = _key[2];
        //                if (_key[2].Y > peak.PeakPoint.Y)
        //                    peak.PeakPoint = _key[2];
        //                if (peak.PeakPoint.X < peak.StartPoint.X)
        //                    break;
        //                break;
        //            case PeakFlag.S:
        //                //peak.CharacteristicPoints.Add(_key[0]);
        //                _feature_point.Add(_key[0]);
        //                break;
        //            case PeakFlag.R:
        //                //peak.CharacteristicPoints.Add(_key[1]);
        //                _feature_point.Add(_key[1]);
        //                break;
        //            case PeakFlag.V:
        //                //peak.CharacteristicPoints.Add(_key[0]);
        //                _feature_point.Add(_key[0]);
        //                break;
        //            case PeakFlag.T:
        //                //peak.CharacteristicPoints.Add(_key[0]);
        //                _feature_point.Add(_key[0]);
        //                peak.EndPoint = _key[0];
        //                break;
        //            case PeakFlag.U:
        //                ptf = FindData(this.PeakLocationParam.SourceData, CharacteristicPoint.X*this .PeakLocationParam.SampleInterval);
        //                //peak.CharacteristicPoints.Add(ptf);
        //                _feature_point.Add(ptf);
        //                break;
        //        }

        //    }

        //    peak.CharacteristicPoints = _feature_point;

        //    //if (peak.CharacteristicPoints.Count != peak.CharacteristicPointsFlag.Length * 2)
        //    //    return false;
        //    //peak.CharacteristicPoints.RemoveRange(0, peak.CharacteristicPointsFlag.Length);
        //    return true;
        //}

        ///// <summary>
        ///// 查找最小值，中值，最大值
        ///// </summary>
        ///// <param name="srcdata"></param>
        ///// <returns></returns>
        //private PointF[] FindValue(List<PointF> srcdata)
        //{
        //    if (srcdata == null) return null;
        //    if (srcdata.Count == 0) return null;
        //    PointF[] ResBuf = new PointF[3];
        //    IEnumerable<PointF> list = from ptf in srcdata orderby ptf.Y select ptf;
        //    if (list == null) return null;
        //    ResBuf[0] = list.First();
        //    ResBuf[1] = srcdata[srcdata.Count / 2];
        //    ResBuf[2] = list.Last();
        //    return ResBuf;

        //}
        #endregion

        /// <summary>
        /// 覆盖原始数据（没有特征标志的峰用此处理）
        /// 供RecoverPeakArges调用
        /// </summary>
        /// <param name="peak"></param>
        /// <returns></returns>
        protected virtual bool RecoverDataWithoutFlag(PeakArgs peak)
        {
            peak.CharacteristicPointsFlag = string.Empty;
            peak.CharacteristicPoints.Clear();
            peak.CharacteristicPointsFlag += PeakFlag.O.ToString();
            peak.CharacteristicPoints.Add(peak.StartPoint);
            peak.CharacteristicPointsFlag += PeakFlag.A.ToString();
            peak.CharacteristicPoints.Add(peak.PeakPoint);
            peak.CharacteristicPointsFlag += PeakFlag.T.ToString();
            peak.CharacteristicPoints.Add(peak.EndPoint);

            if (RecoverDataWithFlag(peak))
            {
                peak.CharacteristicPointsFlag = string.Empty;
                peak.CharacteristicPoints.Clear();
                return true;
            }
            else
                return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private PointF FindData(PointF[] input_data, float X)
        {
            if (input_data.Length <= X) return PointF.Empty;
            if (X < 0) return PointF.Empty;
            return input_data[(int)X];
        }
        /// <summary>
        /// 计算峰宽
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private double CalWidth(PeakArgs e)
        {
            if (e == null) return double.NaN;
            return e.EndPoint.X - e.StartPoint.X;
        }
        /// <summary>
        /// 粗略计算峰高
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private double CalHeight(PeakArgs e)
        {
            if (e == null) return double.NaN;
            double H1 = Math.Abs(e.PeakPoint.Y - e.StartPoint.Y);
            double H2 = Math.Abs(e.PeakPoint.Y - e.EndPoint.Y);
            double H = H1 > H2 ? H1 : H2;
            return H;
        }
        #endregion

    }
}
