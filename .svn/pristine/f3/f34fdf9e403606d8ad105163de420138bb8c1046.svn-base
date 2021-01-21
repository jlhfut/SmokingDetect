//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: SavitzkyGolay.cs
// 日期：2012/10/18
// 描述：SavitzkyGolay滤波器
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
// 
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Wayee.Filter.SG
{
    /// <summary>
    /// SavitzkyGolay滤波:2-10阶;窗口宽度:5-121
    /// </summary>
    public class SavitzkyGolay:Wayee.Filter.FilterBase
    {       
        /// <summary>
        /// 卷积系数表
        /// </summary>
        static private Dictionary<string, double[,]> SG_Coeff = null;
        /// <summary>
        /// construct
        /// </summary>
        public SavitzkyGolay()
        {
            Init();
        }
        /// <summary>
        /// 提供SG滤波操作
        /// </summary>
        /// <param name="order">SG滤波器阶数（最小二乘法拟合，多项式阶数）；数据范围：2-10；</param>
        /// <param name="half_window_size">窗口半宽度数据范围：2-60；framsize = sidPointLength*2+1</param>
        /// <param name="srcData">需要滤波的原始数据</param>
        /// <returns></returns>
        protected virtual double[] Filter(double[] input_data, int order, int half_window_size)
        {
            if (input_data == null) return null;
            if (SG_Coeff == null) return null;
            if (order < 0) return null;             //阶数至少为1
            if (half_window_size < 1) return null;  //窗口宽度至少为3

            int _data_len = input_data.Length;
            if (_data_len == 0) return null;

            string key = order.ToString() + "_" + half_window_size.ToString();
            if (!SG_Coeff.ContainsKey(key)) return null;

            double[,] _coeff = SG_Coeff[key];
            if (_coeff == null) return null;

            int window_size = 2 * half_window_size + 1;
            if (input_data.Length < window_size) return null;

            if (window_size <= order) return null;
            if (_coeff.GetLength(0) != window_size) return null;
            if (_coeff.GetLength(1) != window_size) return null;

            double[] _output_data = new double[_data_len];
            double[] _mid_coeff = null;
            double midval = 0.0;

            for (int i = 0; i < half_window_size; i++)
            {                
                _mid_coeff = SampleCoff(_coeff, i);
                midval = Convolution(_mid_coeff, input_data, 0);
                if (midval == double.MinValue) return null;
                _output_data[i] = midval;
            }

            _mid_coeff = SampleCoff(_coeff, half_window_size);//midcoff 为稳定卷积系数，共本步骤和计算中间稳定点用 

            //计算中间稳定点的数据滤波
            for (int i = half_window_size; i < _data_len - half_window_size; i++)
            {
                midval = Convolution(_mid_coeff, input_data, i - half_window_size);
                _output_data[i] = midval;
            }
            int j = _data_len - half_window_size;
            for (int i = half_window_size + 1; i < window_size; i++)
            {
                _mid_coeff = SampleCoff(_coeff, i);
                midval = Convolution(_mid_coeff, input_data, _data_len - window_size);
                _output_data[j] = midval;
                j++;
            }

            return _output_data;
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coeff"></param>
        /// <param name="data"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        private double Convolution(double[] coeff, double[] data, int start)
        {
            double _out_value = 0;
            
            for (int j = 0; j < coeff.Length; j++)
            {
                _out_value += coeff[j] * data[j + start];
            }

            return _out_value;
        }

        /// <summary>
        /// 抽取二维数组的一维
        /// </summary>
        /// <param name="srcbuffer"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private double[] SampleCoff(double[,] coeff_matrix, int rowIndex)
        {
            double[] _coeff = new double[coeff_matrix.GetLength(1)];

            for (int i = 0; i < _coeff.Length; i++)
            {
                _coeff[i] = coeff_matrix[rowIndex, i];
            }
            return _coeff;
        }

        #region IDSP 成员
        /// <summary>
        /// SG滤波
        /// </summary>
        /// <param name="srcData"></param>
        /// <param name="arges"></param>
        /// <returns></returns>
        public override double[] Process(double[] srcData, FilterArgs args)
        {

            double[] sData = base.Process(srcData, args);
            if (sData == null) return null;
            if (!(args is SGFilterArgs)) return null;
            SGFilterArgs e = args as SGFilterArgs;
            return this.Filter(sData, e.Order, e.SidePoint);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public override bool Init()
        {
            if (SG_Coeff == null)
            {
                SG_Coeff = SGCoefficientsManager.GetSGCoefficients();
            }
            return true;
        }

        #endregion
    }
}
