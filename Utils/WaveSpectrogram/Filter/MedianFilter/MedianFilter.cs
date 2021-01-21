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
    /// 实现接口，IFilter：提供高保真中值滤波
    /// </summary>
    public class MedianFilter : FilterBase
    {
        List<double> m_input_data_list = new List<double>();
        List<double> m_out_data_list = new List<double>();
        List<double> m_sort_data_list = new List<double>();
        List<double> m_his_input_list = new List<double>();
        //List<double> m_his_output_list = new List<double>();

        /// <summary>
        /// 中值滤波，进行数据扩展，并且取中值
        /// </summary>
        /// <param name="srcData"></param>
        /// <param name="FrameSize"></param>
        /// <returns></returns>
        protected virtual double[] FilterData(double[] input_data, int window_size)
        {
            if (window_size % 2 != 1) return null;
            if (input_data.Length < window_size) return input_data;

            m_input_data_list = input_data.ToList();
            int _half_window_size = window_size / 2;
            int _history_data_len = _half_window_size * 2;

            if (m_his_input_list.Count == 0)
            {
                m_his_input_list.AddRange(m_input_data_list.GetRange(0, _half_window_size));
            }
            m_input_data_list.InsertRange(0, m_his_input_list);
            m_out_data_list.Clear();
            //中值滤波
            for (int i = _half_window_size; i < m_input_data_list.Count - _half_window_size; i++)
            {
                m_sort_data_list.Clear();
                m_sort_data_list = m_input_data_list.GetRange(i - _half_window_size, window_size);
                m_sort_data_list.Sort();
                m_out_data_list.Add(m_sort_data_list[_half_window_size]);
            }
            m_his_input_list.Clear();
            m_his_input_list.AddRange(m_input_data_list.GetRange(m_input_data_list.Count - _history_data_len, _history_data_len));

            return m_out_data_list.ToArray();
        }
        /// <summary>
        ///  实现接口IFilter：实现高保真中值滤波
        /// </summary>
        /// <param name="DataSource">数据源数组</param>
        /// <param name="Grade">窗口宽度</param>
        /// <returns></returns>
        protected virtual double[] Process(double[] input_data, int window_size)
        {
            if (input_data == null) return null;
            if (input_data.Length == 0) return null;
            int _adjust_window_size = window_size;
            if (_adjust_window_size % 2 == 0) _adjust_window_size -= 1;
            if (_adjust_window_size < 3) _adjust_window_size = 3;

            return FilterData(input_data, _adjust_window_size);
        }
        #region interface
        /// <summary>
        /// 数据处理：中值滤波
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
            return this.Process(sData, e.FrameSize);
        }
        /// <summary>
        /// 初始化中值滤波器：清空历史数据
        /// </summary>
        /// <returns></returns>
        public override bool Init()
        {
            m_input_data_list.Clear();
            m_out_data_list.Clear();
            m_sort_data_list.Clear();
            m_his_input_list.Clear();
            return true;
        }
        #endregion
    }
}
