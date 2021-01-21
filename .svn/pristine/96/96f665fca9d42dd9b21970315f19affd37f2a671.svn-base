//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: Sample.cs
// 日期：2012/10/18
// 描述：抽样类
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
// 
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wayee.Filter
{
    /// <summary>
    /// 实现数据抽样
    /// </summary>
    public class Sample : FilterBase 
    {
        #region interface
        /// <summary>
        /// 抽样
        /// </summary>
        /// <param name="srcData"></param>
        /// <param name="arges"></param>
        /// <returns></returns>
        public override double[] Process(double[] srcData, FilterArgs args)
        {
            double[] sData = base.Process(srcData, args);
            if (sData == null) return null;
            if (!(args is SampleArgs)) return null;
            SampleArgs e = args as SampleArgs;
            return this.SampleData(sData ,e.Interval );

        }
        #endregion

        /// <summary>
        /// 数据抽样
        /// </summary>
        /// <param name="srcdata"></param>
        /// <param name="SampleInterValue"></param>
        /// <returns></returns>
        protected virtual double[] SampleData(double[] input_data, int bunch_size)
        {
            if (input_data == null) return null;
            if (input_data.Length == 0) return null;
            if (bunch_size < 1) return null;

            int _group_num = input_data.Length / bunch_size;

            double[] _output_data = new double[_group_num];

            for (int i = 0; i < _group_num; i++)
            {
                double _sum = 0;
                int _start = i * bunch_size;

                for (int j = _start; j < _start + bunch_size; j++)
                {
                    _sum += input_data[j];
                }

                _output_data[i] = _sum / bunch_size;
            }

            return _output_data;

            #region OLD_CODE
            if (input_data == null) return null;
            if (input_data.Length == 0) return null;
            List<double> resList = new List<double>();
            int Step = input_data.Length / bunch_size;
            double midval = 0.0;
            List<double> middList = new List<double>();
            List<double> srclist = input_data.ToList();
            for (int i = 0; i < Step; i++)
            {
                midval = srclist.GetRange(i * bunch_size, bunch_size).Average();
                resList.Add(midval);
            }
            return resList.ToArray();
            #endregion
        }

    }
}
