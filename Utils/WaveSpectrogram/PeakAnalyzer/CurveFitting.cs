//===============================================================
// Copyright (C) 2010-2013 皖仪科技研发中心
// 文件名: CurveFitting.cs
// 日期：2013/10/10
// 描述：曲线拟合算法
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace Wayee.ResultAnalyzer
{
    #region 最小二乘法拟合
    public class CLeastSquareFitting
    {
        protected class CoeffMatrix
        {
            /// <summary>
            ///超定方程系数矩阵
            /// </summary>
            public double[,] AA;
            /// <summary>
            /// 法方程系数矩阵
            /// </summary>
            public double[,] MM;
            /// <summary>
            /// 方程右端向量
            /// </summary>
            public double[] eq;
        }

        #region 计算系数矩阵
        /// <summary> 建立超定方程组和法方程组</summary>
        /// <param name="pList">数据点列表</param>
        /// <param name="order">待拟合的多项式次数</param>
        /// <param name="zeroPassage">是否过零点</param>
        /// <returns>返回建立的方程组系数矩阵</returns>
        protected static CoeffMatrix CreateCoeffMatrix(List<PointF> point_list, int order, bool zeroPassage)
        {
            if (point_list == null)
                return null;

            if (order < 1)
                return null;

            CoeffMatrix _coeff_matrix = new CoeffMatrix();

            if (zeroPassage == false)
                order += 1;


            _coeff_matrix.AA = new double[point_list.Count, order];
            _coeff_matrix.MM = new double[order, order];
            _coeff_matrix.eq = new double[order];

            //构建超定方程组系数矩阵
            if (zeroPassage)
            {
                for (int i = 0; i < point_list.Count; i++)
                {
                    _coeff_matrix.AA[i, 0] = point_list[i].X;
                }
            }
            else
            {
                for (int i = 0; i < point_list.Count; i++)
                {
                    _coeff_matrix.AA[i, 0] = 1.0;
                }
            }

            for (int j = 1; j < order; j++)
            {
                for (int i = 0; i < point_list.Count; i++)
                {
                    _coeff_matrix.AA[i, j] = _coeff_matrix.AA[i, j - 1] * point_list[i].X;
                }
            }

            //构建法方程系数矩阵
            double _sum;

            for (int i = 0; i < order; i++)
            {
                //计算系数矩阵
                for (int j = 0; j <= i; j++)
                {
                    _sum = 0.0;
                    for (int l = 0; l < point_list.Count; l++)
                    {
                        _sum += (_coeff_matrix.AA[l, i] * _coeff_matrix.AA[l, j]);
                    }
                    _coeff_matrix.MM[i, j] = _sum;
                    _coeff_matrix.MM[j, i] = _sum;
                }

                //计算右端向量
                _sum = 0.0;
                for (int l = 0; l < point_list.Count; l++)
                {
                    _sum += (_coeff_matrix.AA[l, i] * point_list[l].Y);
                }
                _coeff_matrix.eq[i] = _sum;
            }

            return _coeff_matrix;
        }
        #endregion

        #region 线性方程求解
        /// <summary>高斯消元法解线性方程组</summary>
        /// <param name="A">线性方程组系数矩阵/法方程构造矩阵</param>
        /// <param name="xx">解向量</param>
        /// <param name="isZero">是否过零点</param>
        /// <returns>是否有解</returns>
        protected static List<double> GaussianElimination(CoeffMatrix coeff_matrix, bool zeroPassage)
        {
            if ((coeff_matrix == null) || (coeff_matrix.MM == null) || (coeff_matrix.eq == null))
                return null;

            //系数矩阵维数
            int lengthRow = coeff_matrix.MM.GetLength(0);
            int lengthColumn = coeff_matrix.MM.GetLength(1);
            int lengthSolution = coeff_matrix.eq.Length;

            #region 矩阵打印，测试时使用
            //高斯消元前打印矩阵
            for (int i = 0; i < lengthRow; i++)
            {
                for (int j = 0; j < lengthColumn; j++)
                {
                    Debug.Write(coeff_matrix.MM[i, j].ToString().PadLeft(10));
                }
                Debug.WriteLine("\n");
            }
            //打印解向量
            for (int i = 0; i < lengthSolution; i++)
            {
                Debug.Write(coeff_matrix.eq[i].ToString().PadLeft(10));
            }
            Debug.WriteLine("\n");
            #endregion

            //是否超定方程
            if (lengthRow < lengthColumn)
            {
                Debug.WriteLine("The linear equalitions are no solution!");
            }

            for (int k = 0; k < lengthRow; k++)
            {
                if (coeff_matrix.MM[k, k] == 0)
                {
                    Debug.WriteLine("The linear equalitions are no solution!");
                }
                for (int i = k + 1; i < lengthRow; i++)
                {
                    coeff_matrix.MM[i, k] = coeff_matrix.MM[i, k] / coeff_matrix.MM[k, k];
                    for (int j = k + 1; j < lengthColumn; j++)
                    {
                        coeff_matrix.MM[i, j] = coeff_matrix.MM[i, j] - coeff_matrix.MM[i, k] * coeff_matrix.MM[k, j];
                    }
                    coeff_matrix.eq[i] = coeff_matrix.eq[i] - coeff_matrix.MM[i, k] * coeff_matrix.eq[k];
                }
            }
            coeff_matrix.eq[lengthSolution - 1] = coeff_matrix.eq[lengthSolution - 1] / coeff_matrix.MM[lengthRow - 1, lengthColumn - 1];
            for (int i = lengthColumn - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < lengthRow; j++)
                {
                    coeff_matrix.eq[i] = coeff_matrix.eq[i] - coeff_matrix.MM[i, j] * coeff_matrix.eq[j];
                }
                coeff_matrix.eq[i] = coeff_matrix.eq[i] / coeff_matrix.MM[i, i];
            }

            List<double> _coeff_list = new List<double>();

            if (zeroPassage)
            {
                _coeff_list.Add(0);
            }
            for (int i = 0; i < lengthColumn; i++)
            {
                _coeff_list.Add(coeff_matrix.eq[i]);
            }

            #region 矩阵打印，测试时使用

            Debug.WriteLine("高斯消元后矩阵：");
            for (int i = 0; i < lengthRow; i++)
            {
                for (int j = 0; j < lengthColumn; j++)
                {
                    Debug.Write(coeff_matrix.MM[i, j].ToString().PadLeft(20));
                }
                Debug.WriteLine("\n");
            }
            //打印解向量
            for (int i = 0; i < coeff_matrix.eq.Length; i++)
            {
                Debug.WriteLine(coeff_matrix.eq[i]);
            }

            #endregion

            return _coeff_list;
        }
        #endregion

        #region 计算相关系数
        /// <summary>计算相关系数</summary>
        /// <param name="point_list">点列表</param>
        /// <returns>相关系数</returns>
        public static double ComputeCorrelationCoeff(List<PointF> point_list)
        {
            if ((point_list == null) || (point_list.Count == 0))
                return 0;

            double _sumX = 0, _sumY = 0;
            double _Sxx = 0, _Sxy = 0, _Syy = 0;
            double _averX = 0, _averY = 0;

            foreach (PointF _point in point_list)
            {
                _sumX += _point.X;
                _sumY += _point.Y;
            }
            _averX = _sumX / point_list.Count;
            _averY = _sumY / point_list.Count;

            double _deltaX = 0, _deltaY = 0;

            foreach (PointF pf in point_list)
            {
                _deltaX = pf.X - _averX;
                _deltaY = pf.Y - _averY;

                _Sxy += _deltaX * _deltaY;
                _Sxx += _deltaX * _deltaX;
                _Syy += _deltaY * _deltaY;
            }

            return Math.Abs(_Sxy / (Math.Sqrt(_Sxx) * Math.Sqrt(_Syy)));//|r|
        }
        #endregion

        #region 计算决定系数
        /// <summary>计算决定系数</summary>
        /// <param name="pList">点列表</param>
        /// <param name="rList">系数列表</param>
        /// <returns>决定系数</returns>
        public static double ComputeDeterminationCoeff(List<PointF> point_list, List<double> coeff_list)
        {
            if ((point_list == null) || (point_list.Count == 0))
                return 0;
            if ((coeff_list == null) || (coeff_list.Count == 0))
                return 0;
            
            double _sumY = 0;
            for (int i = 0; i < point_list.Count; i++)
            {
                _sumY += point_list[i].Y;
            }

            double _averY = _sumY / point_list.Count;

            double _RSS = 0;
            double _Syy = 0;            
            
            for (int i = 0; i < point_list.Count; i++)
            {
                double _estiY = 0;
                for (int j = 0; j < coeff_list.Count; j++)
                {
                    _estiY += coeff_list[j] * Math.Pow(point_list[i].X, j);
                }
                _RSS += Math.Pow(point_list[i].Y - _estiY, 2);
                _Syy += Math.Pow(point_list[i].Y - _averY, 2);
            }

            if (_Syy == 0)
            {
                return 1;
            }

            return (1 - _RSS / _Syy);
        }
        #endregion

        #region 计算拟合系数
        /// <summary>
        /// 建立超定方程组和法方程组
        /// </summary>
        /// <param name="pList">数据点列表</param>
        /// <param name="rank">待拟合的多项式次数</param>
        /// <param name="isZero">是否过零点</param>
        /// <param name="r2">线性拟合度</param>
        /// <returns>返回拟合系数</returns>
        public static List<Double> Fitting(List<PointF> point_list, int order, bool zeroPassage)
        {          
            CoeffMatrix _coeff_matrix =  CreateCoeffMatrix(point_list, order, zeroPassage);
            return GaussianElimination(_coeff_matrix, zeroPassage);
        }
        #endregion

        #region 获取拟合公式
        /// <summary>
        /// 获取拟合表达式
        /// </summary>
        /// <param name="param"></param>
        /// <param name="isLog"></param>
        /// <param name="isZero"></param>
        /// <returns></returns>
        public static string GetFormula(List<double> coeff, int order)
        {
            try
            {
                if ((coeff == null) || (coeff.Count <= 0)) return null;
                foreach (double _v in coeff)
                {
                    if (Double.IsNaN(_v)) return null;
                }

                String _formula_str = null;

                string exinf = "";
                if (order == 1)
                {
                    if (coeff[0] != 0)
                        exinf = (coeff[0] > 0 ? " + " : " - ") + Math.Abs(coeff[0]).ToString();
                    _formula_str = "Y = " + coeff[1].ToString() + "X" + exinf;
                }
                else if (order > 1)
                {
                    _formula_str = "Y = " + coeff[coeff.Count - 1].ToString() + "X^" + order;
                    for (int i = coeff.Count - 2; i >= 0; i--)
                    {
                        if (coeff[i] == 0) continue;
                        exinf = (coeff[i] > 0 ? " + " : " - ") + Math.Abs(coeff[i]).ToString();
                        switch (i)
                        {
                            case 0:
                                _formula_str += exinf;
                                break;
                            case 1:
                                _formula_str += exinf + "X";
                                break;
                            default:
                                _formula_str += exinf + "X^" + i;
                                break;
                        }
                    }
                }
                return _formula_str;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }
        #endregion

    }
    #endregion

    #region 对数拟合
    public class CLogFitting : CLeastSquareFitting
    {
        public static List<Double> Fitting(List<PointF> point_list, bool zeroPassage)
        {
            if ((point_list == null) || (point_list.Count == 0))
                return null;

            List<PointF> _log_point_list = new List<PointF>();

            foreach (PointF _point in point_list)
            {
                _log_point_list.Add(new PointF((float)Math.Log10(_point.X), (float)Math.Log10(_point.Y)));
            }

            CoeffMatrix _coeff_matrix = CreateCoeffMatrix(_log_point_list, 1, zeroPassage);
            List<double> _coefficients = GaussianElimination(_coeff_matrix, zeroPassage);

            return _coefficients;
        }

        public static string GetFormula(List<double> coeff)
        {
            if ((coeff == null) || (coeff.Count != 2))
                return null;
            //
            foreach (double _value in coeff)
            {
                if (Double.IsNaN(_value)) return null;
            }

            return "ln(Y) = " + coeff[1].ToString("f1") + "ln(X) + " + ((coeff[0] == 0) ? "" : coeff[0].ToString("f1"));
        }
    }
    #endregion
}
