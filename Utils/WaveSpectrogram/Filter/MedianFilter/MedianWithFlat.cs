//===============================================================
// Copyright (C) 2010-2011 皖仪科技软件部
// 文件名: MidPointFilter.cs
// 日期：2011/03/03
// 描述：实现接口IFilter，实现高保真中值滤波
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
//==============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Wayee.Filter
{
    /// <summary>
    /// 具备平台处理的中值滤波
    /// </summary>
    public class MedianFilterWithFlat : FilterBase
    {
        /// <summary>
        /// 平台处理实例
        /// </summary>
        FlatProcess _flatPro = new FlatProcess();
        /// <summary>
        /// 中值滤波实例
        /// </summary>
        MedianFilter _midFilter = new MedianFilter();
        /// <summary>
        /// 历史中值数据
        /// </summary>
        List<double> _his_mid_list = new List<double>();
        /// <summary>
        /// 历史中值数据
        /// </summary>
        List<double> _his_input_list = new List<double>();
        /// <summary>
        /// 数据偏移补偿列表
        /// </summary>
        List<double> _his_input_nofilting = new List<double>();
        /// <summary>
        /// midpoint filter
        /// </summary>
        /// <param name="srcData"></param>
        /// <param name="FrameSize"></param>
        /// <returns></returns>
        protected virtual double[] Process(double[] input_data, MedianFilterArgs args)
        {
            if (input_data == null) return null;
            if (args == null) return null;
            if (input_data.Length <= args.FrameSize) return input_data;

            int _half_window_size = args.FrameSize / 2;
            int _flat_width = _half_window_size + 1;             

            //一次滤波过程中总有半窗口长度的数据未被滤波
            //组织用于恢复平台的原始数据
            List<double> _input_data_list = input_data.ToList();
            _input_data_list.InsertRange(0, this._his_input_nofilting);
            _his_input_nofilting = _input_data_list.GetRange(_input_data_list.Count - _half_window_size, _half_window_size);//更新数据偏移
            _input_data_list.RemoveRange(_input_data_list.Count - _half_window_size, _half_window_size);
            _input_data_list.InsertRange(0, this._his_input_list);

            //中值滤波
            double[] _mid_data_buf = _midFilter.Process(input_data, args);
            if (_mid_data_buf == null) return null;
            if (_mid_data_buf.Length <= _flat_width) return _mid_data_buf;
            //组织滤波后的数据，数量应该与input_data_list数据一致
            List<double> _mid_data_list = _mid_data_buf.ToList();
            _mid_data_list.InsertRange(0, this._his_mid_list);
            if (_mid_data_list.Count != _input_data_list.Count) return null;

            //寻找并处理平台
            List<FlatInfo> _flat_list = _flatPro.Process(_mid_data_list.ToArray(), args);
            if (_flat_list != null && _flat_list.Count != 0)
            {
                //用原始数据恢复平台              
                foreach (FlatInfo fi in _flat_list)
                {
                    _mid_data_list.RemoveRange(fi.StartIndex, fi.FlatWidth);
                    _mid_data_list.InsertRange(fi.StartIndex, _input_data_list.GetRange(fi.StartIndex, fi.FlatWidth));
                }
            }
            //处理历史数据
            _his_mid_list.Clear();
            _his_input_list.Clear();
            
            if ((_flat_list == null) || (_flat_list.Count == 0))
            {
                _his_mid_list.AddRange(_mid_data_list.GetRange(_mid_data_list.Count - (_half_window_size + 2), _half_window_size + 2));
                _his_input_list.AddRange(_input_data_list.GetRange(_input_data_list.Count - (_half_window_size + 2), _half_window_size + 2));
                _mid_data_list.RemoveRange(_mid_data_list.Count - (_half_window_size + 2), _half_window_size + 2);
            }
            else
            { 
                FlatInfo _flat_info = _flat_list[_flat_list.Count - 1];
                int _end_index = _flat_info.StopIndex + 1;

                _his_mid_list.AddRange(_mid_data_list.GetRange(_end_index, _mid_data_list.Count - _end_index));
                _his_input_list.AddRange(_input_data_list.GetRange(_end_index, _input_data_list.Count - _end_index));
                _mid_data_list.RemoveRange(_end_index, _mid_data_list.Count - _end_index);
            }

            //for (int i = _mid_data_list.Count - 1; i >= _mid_data_list.Count - _flat_width; i--)
            //{
            //    if (_mid_data_list[i - 1] == _mid_data_list[i])
            //    {
            //        this._his_mid_list.Clear();
            //        this._his_input_list.Clear();
            //    }
            //    else
            //    {
            //        this._his_mid_list.Clear();
            //        int count = _mid_data_list.Count - i + 1;
            //        this._his_mid_list.AddRange(_mid_data_list.GetRange(i - 1, count));
            //        _mid_data_list.RemoveRange(i - 1, count);

            //        this._his_input_list.Clear();
            //        this._his_input_list.AddRange(_input_data_list.GetRange(i - 1, count));
            //        break;
            //    }
            //}
            return _mid_data_list.ToArray();
        }
        #region interface
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcData"></param>
        /// <param name="arges"></param>
        /// <returns></returns>
        public override double[] Process(double[] input_data, FilterArgs args)
        {
            double[] sData = base.Process(input_data, args);
            if (sData == null) return null;
            if (!(args is MedianFilterArgs)) return null;
            MedianFilterArgs e = args as MedianFilterArgs;
            return this.Process(sData, e);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public override bool Init()
        {
            _his_mid_list.Clear();
            _his_input_list.Clear();
            _his_input_nofilting.Clear();

            return _midFilter.Init();
        }
        #endregion
    }
}
