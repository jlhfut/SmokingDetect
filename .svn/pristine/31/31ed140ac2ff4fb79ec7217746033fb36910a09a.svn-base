//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: PeakListReprocess.cs
// 日期：2011/03/09
// 描述：定义峰列表后处理算法
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
    /// 峰列表后处理，主要根据分离度合并相邻峰的起点和终点，在适当的时候将中间点作为峰谷处理
    /// </summary>
    class CPeakMergingTradition : CLocationBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arges"></param>
        public CPeakMergingTradition(PeakLocationArgs arges)
            : base(arges)
        { }

        #region IPeakLocation 成员

        /// <summary>
        /// 重写合并函数
        /// </summary>
        /// <param name="srcList"></param>
        /// <param name="DetechedIndex"></param>
        /// <returns></returns>
        protected virtual List<PeakArgs> MergeFusionPeak(List<PeakArgs> input_peak_list, List<int> detached_peak_index)
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

                //_peak.CharacteristicPointsFlag = input_peak_list[_current_index + 1].CharacteristicPointsFlag;
                //_peak.CharacteristicPoints.AddRange(input_peak_list[_current_index + 1].CharacteristicPoints);

                _peak.Type = PeakType.Detached;

                _peak.CharacteristicPoints.Clear();
                _peak.CharacteristicPointsFlag = "";

                for (int j = _current_index + 1; j <= detached_peak_index[i]; j++)
                {
                    if (input_peak_list[j].PeakPoint.Y > _peak.PeakPoint.Y)
                        _peak.PeakPoint = input_peak_list[j].PeakPoint;

                    _peak.CharacteristicPoints.Add(input_peak_list[j].StartPoint);
                    _peak.CharacteristicPointsFlag += PeakFlag.V.ToString();

                    _peak.CharacteristicPoints.Add(input_peak_list[j].PeakPoint);
                    _peak.CharacteristicPointsFlag += PeakFlag.A.ToString();

                    _peak.Type = PeakType.Mixed;
                }

                if (_peak.Type == PeakType.Mixed)
                {
                    _peak.CharacteristicPoints.Add(input_peak_list[detached_peak_index[i]].EndPoint);

                    _peak.CharacteristicPointsFlag += PeakFlag.T.ToString();
                    _peak.CharacteristicPointsFlag = _peak.CharacteristicPointsFlag.Substring(1);
                    _peak.CharacteristicPointsFlag = PeakFlag.O.ToString() + _peak.CharacteristicPointsFlag;
                }
                _output_peak_list.Add(_peak);
                _current_index = detached_peak_index[i];
            }
            return _output_peak_list;
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            if (!ValidityCheck()) return false;

            List<int> _detached_peak_index = new List<int>();
            //查找峰组，分离峰群
            for (int i = 0; i < this.PeakLocationParam.PeakList.Count - 1; i++)
            {
                double _resolution = CalResolution(PeakLocationParam.PeakList[i], PeakLocationParam.PeakList[i + 1]);
                if (_resolution < this.PeakLocationParam.Resolution)
                    _detached_peak_index.Add(i);
            }

            if (_detached_peak_index.Count == 0) _detached_peak_index.Add(this.PeakLocationParam.PeakList.Count - 1);
            if (_detached_peak_index[_detached_peak_index.Count - 1] != this.PeakLocationParam.PeakList.Count - 1)
                _detached_peak_index.Add(this.PeakLocationParam.PeakList.Count - 1);
            int currentIndex = -1;
            //遍历峰列表，合并峰，将起点终点合并并作为谷点建立一个新的峰
            for (int i = 0; i < _detached_peak_index.Count; i++)
            {
                for (int j = currentIndex + 1; j < _detached_peak_index[i]; j++)
                {
                    if (this.PeakLocationParam.PeakList[j].PeakPoint.X < this.PeakLocationParam.PeakList[j].StartPoint.X)
                        this.PeakLocationParam.PeakList[j].PeakPoint = this.PeakLocationParam.PeakList[j].StartPoint;

                    if (this.PeakLocationParam.PeakList[j].PeakPoint.X > this.PeakLocationParam.PeakList[j].EndPoint.X)
                        this.PeakLocationParam.PeakList[j].PeakPoint = this.PeakLocationParam.PeakList[j].EndPoint;

                    this.PeakLocationParam.PeakList[j].EndPoint = this.PeakLocationParam.PeakList[j + 1].StartPoint;
                }
                currentIndex = _detached_peak_index[i];
            }

            List<PeakArgs> _peak_list = MergeFusionPeak(this.PeakLocationParam.PeakList, _detached_peak_index);
            if (_peak_list == null) return false;
            if (_peak_list.Count == 0) return false;

            List<int> _noise_peak_index = new List<int>();
            //遍历列表，查找噪声峰索引
            for (int i = 0; i < _peak_list.Count - 1; i++)
            {
                if (_peak_list[i].EndPoint.X != _peak_list[i + 1].StartPoint.X)
                    _noise_peak_index.Add(i);
            }

            List<PeakArgs> _noise_peak_list = new List<PeakArgs>();
            //遍历噪声峰索引列表，构造噪声峰
            PeakArgs _noise_peak = null;
            for (int i = 0; i < _noise_peak_index.Count; i++)
            {
                _noise_peak = CreateNoisePeak(_peak_list[_noise_peak_index[i]].EndPoint, _peak_list[_noise_peak_index[i] + 1].StartPoint);
                _noise_peak_list.Add(_noise_peak);
            }
            
            //_noise_peak_list.Add(CreateNoisePeak(new PointF(0f, this.PeakLocationParam.SourceData[0].Y), _peak_list[0].StartPoint));
            _noise_peak_list.Add(CreateNoisePeak(this.PeakLocationParam.SourceData[0], _peak_list[0].StartPoint));
            
            _peak_list.AddRange(_noise_peak_list);
            this.PeakLocationParam.PeakList = _peak_list;

            if (this._Onfoundpeak == null) return false;
            foreach (PeakArgs _peak in this.PeakLocationParam.PeakList)
                this._Onfoundpeak(this, _peak);

            return true;
        }
        #endregion

        #region private
        /// <summary>
        /// 有效性检查
        /// </summary>
        /// <returns></returns>
        protected virtual bool ValidityCheck()
        {
            if (this.PeakLocationParam.PeakList == null) return false;
            if (this.PeakLocationParam.PeakList.Count == 0) return false;
            if (double.IsNaN(this.PeakLocationParam.Resolution)) return false;
            if (double.IsNaN(this.PeakLocationParam.HeightRate)) return false;

            return true;
        }

        /// <summary>
        /// 计算分离度：采用empower的做法
        /// 相邻峰间的间隔与峰的宽度的比值
        /// </summary>
        /// <returns></returns>
        protected virtual double CalResolution(PeakArgs front_peak, PeakArgs after_peak)
        {
            if (front_peak == null) return double.MaxValue;
            if (after_peak == null) return double.MaxValue;

            if (front_peak.EndPoint.X > after_peak.StartPoint.X) return double.MaxValue;

            float _front_peak_width = front_peak.EndPoint.X - front_peak.StartPoint.X;
            float _after_peak_width = after_peak.EndPoint.X - after_peak.StartPoint.X;
            ////float E12 = afterPeak.PeakPoint.X - frontPeak.PeakPoint.X;
            ////return 2 * E12 / (W1 + W2);

            float E12 = after_peak.StartPoint.X - front_peak.EndPoint.X;
            float W = _front_peak_width > _after_peak_width ? _front_peak_width : _after_peak_width;

            return W / E12;
        }
        /// <summary>
        /// 计算两峰之间，峰谷与峰高的高度比
        /// </summary>
        /// <param name="frontPeak"></param>
        /// <param name="arfterPeak"></param>
        /// <returns></returns>
        protected virtual double CalHeightRate(PeakArgs front_peak, PeakArgs after_peak)
        {
            if (front_peak.EndPoint.X != after_peak.StartPoint.X) return double.NaN;
            if (front_peak.EndPoint.Y <= front_peak.StartPoint.Y || front_peak.EndPoint.Y <= after_peak.EndPoint.Y) return 0;

            float startY = front_peak.StartPoint.Y < after_peak.EndPoint.Y ? front_peak.StartPoint.Y : after_peak.EndPoint.Y;
            float H12 = front_peak.EndPoint.Y - startY;
            float H2 = after_peak.PeakPoint.Y - startY;
            float H1 = front_peak.PeakPoint.Y - startY;
            float Hmax = H1 > H2 ? H1 : H2;

            return H12 / Hmax;
        }

        /// <summary>
        /// 创建噪声峰
        /// </summary>
        /// <param name="startPt"></param>
        /// <param name="endPt"></param>
        /// <returns></returns>
        private PeakArgs CreateNoisePeak(PointF startPt, PointF endPt)
        {
            PeakArgs _peak = new PeakArgs();

            _peak.StartPoint = startPt;
            _peak.EndPoint = endPt;

            //float dt = endPt.X - startPt.X;
            //_peak.PeakPoint = new PointF(startPt .X +(float)(dt/2.0),endPt .Y);
            _peak.PeakPoint = startPt.Y > endPt.Y ? startPt : endPt;

            _peak.Type = PeakType.Noise;

            return _peak;
        }
        #endregion

    }
}
