//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: Differentiate.cs
// 日期：2011/03/09
// 描述：微分计算器
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
    /// 一阶微分计算
    /// </summary>
    public class Differentiate : FilterBase 
    {

        /// <summary>
        /// 计算给定数据的一阶微分
        ///        d
        /// f(t) = — F(t)
        ///        dt
        ///      1
        /// Yi = —（Xi+1 - Xi-1）
        ///     2dt
        /// </summary>
        /// <param name="inputData">输入数据</param>
        /// <param name="dt">时间间隔</param>
        /// <param name="initialCondition">初始条件，用于处理第一个点</param>
        /// <param name="finalCondition">结束条件，用于处理最后一个点</param>
        /// <returns>一阶微分数据</returns>
        protected virtual double [] Process(double [] inputData,double dt,double initialCondition,double finalCondition)
        {
            if ((inputData == null) || (inputData.Length <= 1)) return null;
            if (dt <= 0.0) return null;

            double[] _output_data = new double[inputData.Length];
            double _dt = 2.0 * dt;
            int _size = inputData.Length;

            _output_data[0] = (inputData[1] - initialCondition) / _dt;
            _output_data[_size - 1] = (finalCondition - inputData[_size - 2]) / _dt;

            for (int i = 1; i < _size - 1; i++)
            {
                _output_data[i] = (inputData[i + 1] - inputData[i - 1]) / _dt;
            }

            return _output_data;
        }

        #region interface

        /// <summary>
        /// 执行微分计算
        /// </summary>
        /// <param name="srcData"></param>
        /// <param name="arges"></param>
        /// <returns></returns>
        public override double[] Process(double[] srcData, FilterArgs args)
        {
            double[] sData = base.Process(srcData ,args );
            if (sData == null) return null;
            if (!(args is DifferentiateFilterArgs)) return null;
            DifferentiateFilterArgs e = args as DifferentiateFilterArgs;
            return this.Process(sData, e.Dt, e.InitialCondition, e.FinalCondition);
        }
        #endregion
    }
}
