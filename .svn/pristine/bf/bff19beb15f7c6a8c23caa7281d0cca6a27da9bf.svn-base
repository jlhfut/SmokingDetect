//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: SpecCalc.cs
// 日期：2011/05/10
// 描述：定义谱图加减算法类：静态方法，实现思路为：
//                                                  1. 判断给定的两个点集的时间长度
//                                                  2. 根据时间持续短的点集的横坐标，在另一个点集中进行插值计算
//                                                  3. 将插值得到的数据和原持续时间短的数据进行相加减并返回结果
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
namespace Wayee.Spectrogram
{
    /// <summary>
    /// 定义谱图加减运算的数据结构
    /// </summary>
    struct PeakStr
    {
        public double[] _TSX;//目标插值点横坐标
        public double[] _TSY;//目标原始数据
        public double[] _SX;//原始数据横坐标
        public double[] _SY;//原始数据纵坐标
    }

    public class SpectrogramProcessor
   {

        #region 谱图加减

        /// <summary>
        /// 进行两个点集的相加运算
        /// </summary>
        /// <param name="Peakdatalist1"></param>
        /// <param name="Peakdatalist2"></param>
        /// <returns></returns>
        public static List<PointF> Add(List<PointF> Peakdatalist1, List<PointF> Peakdatalist2)
        {
            List<PointF> res = new List<PointF>();

            PeakStr _peskstr = GetData(Peakdatalist1, Peakdatalist2);

            #region 进行插值计算

            double[] _TY = InterPolator(_peskstr._SX, _peskstr._SY, _peskstr._TSX);

            #endregion

            #region 进行相加计算

            for (int i = 0; i < _TY.Length; i++)
            {
                res.Add(new PointF((float)_peskstr._TSX[i], (float)(_peskstr._TSY[i] + _TY[i])));
            }

            #endregion

            return res;


        }

        /// <summary>
        /// 进行两个点集的相减运算
        /// </summary>
        /// <param name="Peakdatalist1"></param>
        /// <param name="Peakdatalist2"></param>
        /// <returns></returns>
        public static List<PointF> Sub(List<PointF> Peakdatalist1, List<PointF> Peakdatalist2)
        {
            List<PointF> res = new List<PointF>();

            PeakStr _peskstr = GetData(Peakdatalist1, Peakdatalist2);

            #region 进行插值计算

            double[] _TY = InterPolator(_peskstr._SX, _peskstr._SY, _peskstr._TSX);

            #endregion

            #region 进行相加计算

            for (int i = 0; i < _TY.Length; i++)
            {
                res.Add(new PointF((float)_peskstr._TSX[i], (float)(_peskstr._TSY[i] - _TY[i])));
            }

            #endregion

            return res;


        }

        /// <summary>
        /// 根据提供的两个点集进行计算得到两个点集的横坐标和纵坐标并分类返回
        /// </summary>
        /// <param name="Peakdatalist1"></param>
        /// <param name="Peakdatalist2"></param>
        /// <returns></returns>
        private static PeakStr GetData(List<PointF> Peakdatalist1, List<PointF> Peakdatalist2)
        {
            PeakStr Resstr = new PeakStr();

            float _peak1length = Peakdatalist1[Peakdatalist1.Count - 1].X;//队列1持续时间
            float _peak2length = Peakdatalist2[Peakdatalist2.Count - 1].X;//队列2持续时间

            double[] _TSX;//目标插值点横坐标
            double[] _TSY;//目标原始数据
            double[] _TY;//目标原始数据
            double[] _SX;//原始数据横坐标
            double[] _SY;//原始数据纵坐标

            #region 获得原始数据：2012-06-01增加

            int dataCount = _peak1length >= _peak2length ? Peakdatalist2.Count : Peakdatalist1.Count;

            _TSX = new double[dataCount];
            _TSY = new double[dataCount];
            _SX = new double[Peakdatalist2.Count];
            _SY = new double[Peakdatalist2.Count];

            for (int i = 0; i < dataCount; i++)
            {
                if (i >= Peakdatalist1.Count) break;
                _TSX[i] = Convert.ToDouble(Peakdatalist1[i].X);
                _TSY[i] = Convert.ToDouble(Peakdatalist1[i].Y);
            }
            for (int i = 0; i < Peakdatalist2.Count; i++)
            {
                _SX[i] = Convert.ToDouble(Peakdatalist2[i].X);
                _SY[i] = Convert.ToDouble(Peakdatalist2[i].Y);

            }
            #endregion


            #region 获得原始数据：2012-06-01删除
            //if (_peak1length >= _peak2length)
            //{

            //    _TSX = new double[Peakdatalist2.Count];
            //    _TSY = new double[Peakdatalist2.Count];
            //    _SX = new double[Peakdatalist1.Count];
            //    _SY = new double[Peakdatalist1.Count];
            //    int i = 0;
            //    foreach (PointF data in Peakdatalist2)
            //    {
            //        _TSX[i] = Convert.ToDouble(data.X);
            //        _TSY[i] = Convert.ToDouble(data.Y);
            //        i++;
            //    }
            //    i = 0;
            //    foreach (PointF data in Peakdatalist1)
            //    {
            //        _SX[i] = Convert.ToDouble(data.X);
            //        _SY[i] = Convert.ToDouble(data.Y);
            //        i++;
            //    }
            //    i = 0;


            //}
            //else
            //{
            //    _TSX = new double[Peakdatalist1.Count];
            //    _TSY = new double[Peakdatalist1.Count];
            //    _SX = new double[Peakdatalist2.Count];
            //    _SY = new double[Peakdatalist2.Count];
            //    int i = 0;
            //    foreach (PointF data in Peakdatalist1)
            //    {
            //        _TSX[i] = Convert.ToDouble(data.X);
            //        _TSY[i] = Convert.ToDouble(data.Y);
            //        i++;
            //    }
            //    i = 0;
            //    foreach (PointF data in Peakdatalist2)
            //    {
            //        _SX[i] = Convert.ToDouble(data.X);
            //        _SY[i] = Convert.ToDouble(data.Y);
            //        i++;
            //    }
            //    i = 0;
            //}
            #endregion

            Resstr._TSX = _TSX;
            Resstr._TSY = _TSY;
            Resstr._SX = _SX;
            Resstr._SY = _SY;

            return Resstr;

        }
        
        
        #endregion

        #region 插值适配函数

        /// <summary>
        /// 给定原始数据横坐标和纵坐标，差值目标横坐标，输出差值目标点上的纵坐标值
        /// </summary>
        /// <param name="SpointX">原始数据横坐标</param>
        /// <param name="SpointY">原始数据纵坐标</param>
        /// <param name="InterX">差值点横坐标</param>
        /// <returns>差值点纵坐标差值数据</returns>
        private static double[] InterPolator(double[] SpointX, double[] SpointY, double[] InterX)
        {
            double[] dify = new double[SpointX.Length];
            double[] diffy = new double[SpointX.Length];
            double[] difz = new double[InterX.Length];
            double[] diffz = new double[InterX.Length];

            return spl1(SpointX, SpointY, dify, diffy, InterX, difz, diffz);

        }

        #endregion

        #region 插值函数
        /// <summary>
        /// 第一类边界条件的三次样条差值
        /// </summary>
        /// <param name="x">原始数据横坐标</param>
        /// <param name="y">原始数据纵坐标</param>
        /// <param name="dy">原始数据一阶导数</param>
        /// <param name="ddy">原始数据二阶导数</param>
        /// <param name="t">目标差值点的横坐标</param>
        /// <param name="dz">目标差值点的一阶导数</param>
        /// <param name="ddz">目标差值点的二阶导数</param>
        /// <returns> 目标差值点的差值数据</returns>
        private static double[] spl1(double[] x, double[] y, double[] dy, double[] ddy, double[] t, double[] dz, double[] ddz)
        {
            int m = t.Length;
            int n = x.Length;
            int i, j;
            double h0, h1, alpha, beta, g;
            double[] s = new double[n];
            double[] z = new double[m];
            s[0] = dy[0];
            dy[0] = 0.0;
            h0 = x[1] - x[0];
            for (j = 1; j <= n - 2; j++)
            {
                h1 = x[j + 1] - x[j];
                alpha = h0 / (h0 + h1);
                beta = (1.0 - alpha) * (y[j] - y[j - 1]) / h0;
                beta = 3.0 * (beta + alpha * (y[j + 1] - y[j]) / h1);
                dy[j] = -alpha / (2.0 + (1.0 - alpha) * dy[j - 1]);
                s[j] = (beta - (1.0 - alpha) * s[j - 1]);
                s[j] = s[j] / (2.0 + (1.0 - alpha) * dy[j - 1]);
                h0 = h1;
            }
            for (j = n - 2; j >= 0; j--)
                dy[j] = dy[j] * dy[j + 1] + s[j];
            for (j = 0; j <= n - 2; j++)
                s[j] = x[j + 1] - x[j];
            for (j = 0; j <= n - 2; j++)
            {
                h1 = s[j] * s[j];

                ddy[j] = 6.0 * (y[j + 1] - y[j]) / h1 - 2.0 * (2.0 * dy[j] + dy[j + 1]) / s[j];
            }
            h1 = s[n - 2] * s[n - 2];
            ddy[n - 1] = 6 * (y[n - 2] - y[n - 1]) / h1 + 2 * (2 * dy[n - 1] + dy[n - 2]) / s[n - 2];
            g = 0.0;
            for (i = 0; i <= n - 2; i++)
            {
                h1 = 0.5 * s[i] * (y[i] + y[i + 1]);
                h1 = h1 - s[i] * s[i] * s[i] * (ddy[i] + ddy[i + 1]) / 24.0;
                g = g + h1;
            }
            for (j = 0; j <= m - 1; j++)
            {
                if (t[j] >= x[n - 1]) i = n - 2;
                else
                {
                    i = 0;
                    while (t[j] > x[i + 1]) i = i + 1;
                }
                h1 = (x[i + 1] - t[j]) / s[i];
                h0 = h1 * h1;
                z[j] = (3.0 * h0 - 2.0 * h0 * h1) * y[i];
                z[j] = z[j] + s[i] * (h0 - h0 * h1) * dy[i];
                dz[j] = 6.0 * (h0 - h1) * y[i] / s[i];
                dz[j] = dz[j] + (3.0 * h0 - 2.0 * h1) * dy[i];
                ddz[j] = (6.0 - 12.0 * h1) * y[i] / (s[i] * s[i]);
                ddz[j] = ddz[j] + (2.0 - 6.0 * h1) * dy[i] / s[i];
                h1 = (t[j] - x[i]) / s[i];
                h0 = h1 * h1;
                z[j] = z[j] + (3.0 * h0 - 2.0 * h0 * h1) * y[i + 1];
                z[j] = z[j] - s[i] * (h0 - h0 * h1) * dy[i + 1];
                dz[j] = dz[j] - 6.0 * (h0 - h1) * y[i + 1] / s[i];
                dz[j] = dz[j] + (3.0 * h0 - 2.0 * h1) * dy[i + 1];
                ddz[j] = ddz[j] + (6.0 - 12.0 * h1) * y[i + 1] / (s[i] * s[i]);
                ddz[j] = ddz[j] - (2.0 - 6.0 * h1) * dy[i + 1] / s[i];
            }
            s = null;
            return z;
        }

        #endregion

   }
}
