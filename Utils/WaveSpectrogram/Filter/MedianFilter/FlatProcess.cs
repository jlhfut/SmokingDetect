//===============================================================
// Copyright (C) 2010-2011 皖仪科技软件部
// 文件名: MidPointFilter.cs
// 日期：2011/03/03
// 描述：
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
// 
//              
//==============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Wayee.Filter
{
    /// <summary>
    /// 平台信息结构
    /// </summary>
    public class FlatInfo
    {
        private int _startIndex = -1;
        /// <summary>
        /// 平台开始索引
        /// </summary>
        public int StartIndex
        {
            get { return _startIndex; }
            set { _startIndex = value; }
        }
        private int _stopIndex = -1;
        /// <summary>
        /// 平台结束索引
        /// </summary>
        public int StopIndex
        {
            get { return _stopIndex; }
            set { _stopIndex = value; }
        }
        private int _flatWidth = -1;
        /// <summary>
        /// 平台宽度
        /// </summary>
        public int FlatWidth
        {
            get { return _flatWidth; }
            set { _flatWidth = value; }
        }
    }

    /// <summary>
    /// 平台查找类:不处理负峰平台
    /// </summary>
    public class FlatProcess
    {

        #region interface 
        /// <summary>
        /// 平台处理函数
        /// </summary>
        /// <param name="srcData"></param>
        /// <param name="arges"></param>
        /// <returns></returns>
        public List<FlatInfo> Process(double[] input_data, FilterArgs args)
        {
            if (input_data == null) return null;
            if (args == null) return null;
            if (!(args is MedianFilterArgs)) return null;

            MedianFilterArgs arg = args as MedianFilterArgs;
            int _flat_width = arg.FrameSize / 2 + 1;
            if (input_data.Length <= _flat_width) return null;

            //查找平台
            List<FlatInfo> _flat_list = new List<FlatInfo>();

            List<FlatInfo> _flat1 = FindFlat(input_data.ToList(), _flat_width);
            if (_flat1 != null)
                _flat_list.AddRange(_flat1);

            List<FlatInfo> _flat2 = FindFlat(input_data.ToList(), _flat_width + 1);
            if (_flat2 != null)
                _flat_list.AddRange(_flat2);
            
            //List<FlatInfo> _flat3 = FindFlat(input_data.ToList(), _flat_width - 1);
            //if (_flat3 != null)
            //    _flat_list.AddRange(_flat3);

            return _flat_list;
        }
        /// <summary>
        /// 构造一个和平台宽度相同的窗口;
        /// 看窗口内的数据是否相等;
        /// 如果相等，看两边的数据是否满足上升和下降条件;
        /// 如果满足则记录位置;
        /// 否则窗口滑动
        /// </summary>
        /// <param name="srclist"></param>
        /// <param name="faltwidth"></param>
        /// <returns></returns>
        private List<FlatInfo> FindFlat(List<double> input_data, int flat_width)
        {
            if (input_data == null) return null;
            if (input_data.Count == 0) return null;
            if (flat_width < 2) return null;
            if (input_data.Count <= flat_width) return null;

            List<FlatInfo> flist = new List<FlatInfo>();
            List<double> window = input_data.GetRange(0, flat_width);
            for (int i = flat_width - 1; i < input_data.Count; i++)
            {
                //取平台窗口大小的数据
                if (i > flat_width - 1)
                {
                    window.RemoveAt(0);
                    window.Add(input_data[i]);
                }

                FlatInfo _flat = MakeFlat(window, input_data, i);
                if (_flat != null) flist.Add(_flat);

                //FlatInfo _positive_flat = MakeFlat(window, input_data, i, true);
                //if (_positive_flat != null) flist.Add(_positive_flat);
                
                //FlatInfo _negative_flat = MakeFlat(window, input_data, i, false);
                //if (_negative_flat != null) flist.Add(_negative_flat);
            }
            if (flist.Count <= 0) return null;
            return flist;
        }

        /// <summary>
        /// 查找平台
        /// </summary>
        /// <param name="window">平台窗口</param>
        /// <param name="srclist">源数据</param>
        /// <param name="endIndex">源数据中平台窗口最后数据的索引</param>
        /// <param name="bPositiveFlat">查找平台类型：正峰平台，负峰平台</param>
        /// <returns>平台信息，如果没有则返回null</returns>
        //private FlatInfo MakeFlat(List<double> window, List<double> input_data_list, int endIndex, bool bPositiveFlat)
        private FlatInfo MakeFlat(List<double> window, List<double> input_data_list, int endIndex)
        {
            if (window == null) return null;
            if (input_data_list == null) return null;
            if (input_data_list.Count == 0) return null;
            if (window.Count == 0) return null;
            if (endIndex >= input_data_list.Count) return null;
            if (endIndex < window.Count) return null;

            IEnumerable<double> var = from v in window where v == window[0] select v;
            if (var == null) return null;
            if (var.Count() != window.Count) return null;
            
            //检查平台数据是不是比两端的数据大(正平台)或者小(负平台)
            double _flat_value = input_data_list[endIndex];

            int _left_endpoint_index = endIndex - window.Count;
            if (_left_endpoint_index < 0) return null;           

            int _right_endpoint_index = endIndex + 1;
            if (_right_endpoint_index >= input_data_list.Count) return null;
            
            double _left_endpoint_value = input_data_list[_left_endpoint_index];
            double _right_endpoint_value = input_data_list[_right_endpoint_index];

            if (((_left_endpoint_value > _flat_value) && (_right_endpoint_value > _flat_value)) ||
                ((_left_endpoint_value < _flat_value) && (_right_endpoint_value < _flat_value)))
            {
                FlatInfo midflat = new FlatInfo();
                midflat.StartIndex = endIndex - window.Count + 1;
                midflat.StopIndex = endIndex;
                midflat.FlatWidth = window.Count;

                return midflat;
            }
            else
            {
                return null;
            }

            #region OLD_CODE
            //int index = endIndex - window.Count;
            //if (index < 0) return null;

            //if (bPositiveFlat)
            //{
            //    if (input_data_list[index] >= input_data_list[endIndex]) return null;
            //}
            //else
            //{
            //    if (input_data_list[index] <= input_data_list[endIndex]) return null;
            //}

            //index = endIndex + 1;
            //if (index >= input_data_list.Count) return null;

            //if (bPositiveFlat)
            //{
            //    if (input_data_list[index] >= input_data_list[endIndex]) return null;
            //}
            //else
            //{
            //    if (input_data_list[index] <= input_data_list[endIndex]) return null;
            //}
            
            //FlatInfo midflat = new FlatInfo();
            //midflat.StartIndex = endIndex - window.Count + 1;
            //midflat.StopIndex = endIndex;
            //midflat.FlatWidth = window.Count;

            //return midflat;
            #endregion
        }
        #endregion
    }
}
