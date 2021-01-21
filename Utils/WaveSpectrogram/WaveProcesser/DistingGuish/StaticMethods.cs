using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Wayee.WaveProcesser
{
    public class StaticMethods
    {

        ///// <summary>
        ///// 计算一阶微分
        ///// </summary>
        ///// <param name="SourceBuf">原始数据数组</param>
        ///// <returns>返回一阶微分数据数组</returns>
        //public static double  [] GetDiff1(int[] SourceBuf)
        //{
        //    double [] Diff1 = new double  [SourceBuf.Length];

        //    for (int i = 1; i < Diff1.Length; i++)
        //    {
        //        Diff1[i] = Convert .ToDouble (SourceBuf[i] - SourceBuf[i - 1]);
        //    }
        //    Diff1[0] = Diff1[1];
        //    return Diff1;
        //}

        ///// <summary>
        ///// 计算一阶微分
        ///// </summary>
        ///// <param name="SourceBuf">原始数据数组</param>
        ///// <returns>返回一阶微分数据数组</returns>
        //public static double [] GetDiff1(double [] SourceBuf)
        //{
        //    double [] Diff1 = new double [SourceBuf.Length];

        //    for (int i = 1; i < Diff1.Length; i++)
        //    {
        //        Diff1[i] = SourceBuf[i] - SourceBuf[i - 1];
        //    }
        //    Diff1[0] = Diff1[1];

        //    return Diff1;
        //}

        ///// <summary>
        ///// 队列插入函数
        ///// </summary>
        ///// <param name="QueBuf">队列数组</param>
        ///// <param name="InsertVal">要插入的值</param>
        //public static  void QueAdd(int  [] QueBuf, int InsertVal)
        //{
        //    for (int i = 0; i < QueBuf.Length - 1; i++)
        //    {
        //        QueBuf[i] = QueBuf[i + 1];
        //    }
        //    QueBuf[QueBuf.Length - 1] = InsertVal;
        //}
        /// <summary>
        /// 点队列插入
        /// </summary>
        /// <param name="QueBuf"></param>
        /// <param name="InsertVal"></param>
        public static void QueAdd(List<PointF> QueBuf, PointF InsertVal, int length)
        {
            QueBuf.Add(InsertVal);
            if (QueBuf.Count > length)
                QueBuf.RemoveAt(0);

        }
        ///// <summary>
        /////  获得数据的符号：1 大于0；-1 小于0；0 等于0
        ///// </summary>
        ///// <param name="Data"></param>
        ///// <returns></returns>
        //public static int GetSign(double  Data)
        //{  
        //    int sign = 0;
        //    if (Data > 0)
        //        sign = 1;
        //    else if (Data < 0)
        //        sign = -1;

        //    return sign;
        //}
        ///// <summary>
        ///// 在数组中查询特定值的索引：成功则返回索引值，不成功则返回-1
        ///// </summary>
        ///// <param name="Data"></param>
        ///// <param name="Val"></param>
        ///// <returns></returns>
        //public static  int  FindIndex(double[] Data, double Val)
        //{
        //    int index = -1;
        //    for (int i = 0; i < Data.Length; i++)
        //    {
        //        if (Data[i] == Val)
        //            index = i;

        //    }
        //    return index;
        //}

        /// <summary>
        /// 以y=a+bx；最小二乘法拟合数据
        /// </summary>
        /// <param name="PointData"></param>
        /// <returns></returns>
        public static float[] LineFit(List<PointF> PointData)
        {
            float Xmean = 0f;
            float Ymean = 0f;
            float XYmean = 0f;
            float XXmean = 0f;
            int X = 0;
            int count = PointData.Count;
            PointF point;
            //foreach (PointF point in PointData)
            for(int i=0;i<count;i++)
            {
                point = PointData[i];
                Xmean += X;
                Ymean += point.Y;
                XYmean += X * point.Y;
                XXmean += X * X;
                X++;
            }
            float length = PointData.Count;
            Xmean = Xmean / length;
            Ymean = Ymean / length;
            XYmean = XYmean / length;
            XXmean = XXmean / length;
            float b = (float)(XYmean - Xmean * Ymean) / (XXmean - Xmean * Xmean);
            float a = (float)(Ymean - b * Xmean);
            float[] res = { a, b };
            X = 0;
            return res;
        }

        ///// <summary>
        ///// 以y=a+bx；最小二乘法拟合数据
        ///// </summary>
        ///// <param name="PointData"></param>
        ///// <returns></returns>
        //public static float[] LineFit(int [] PointData)
        //{
        //    float Xmean = 0f;
        //    float Ymean = 0f;
        //    float XYmean = 0f;
        //    float XXmean = 0f;
        //    int X = 0;
        //    foreach (int  point in PointData)
        //    {
        //        Xmean += X;
        //        Ymean += point;
        //        XYmean += X * point;
        //        XXmean += X * X;
        //        X++;
        //    }
        //    float length = PointData.Length;
        //    Xmean = Xmean / length;
        //    Ymean = Ymean / length;
        //    XYmean = XYmean / length;
        //    XXmean = XXmean / length;
        //    float b = (float)(XYmean - Xmean * Ymean) / (XXmean - Xmean * Xmean);
        //    float a = (float)(Ymean - b * Xmean);
        //    float[] res = { a, b };
        //    X = 0;
        //    return res;
        //}
        /// <summary>
        /// 由点数组中找出最大值
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static PointF GetMax(List<PointF> buf)
        {
            PointF index = new PointF(-1, 0);
            if (buf.Count>0)
            {
                float mid = buf[0].Y;

                for (int i = 0; i < buf.Count; i++)
                {
                    if (buf[i].Y >= mid)
                    {
                        index = new PointF(buf[i].X, buf[i].Y);

                        mid = buf[i].Y;
                    }

                }
            }
           
            return index;
        }

        /// <summary>
        /// 由点数组中找出最大值
        /// </summary>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static PointF GetMin(List<PointF> buf)
        { 
            PointF index = new PointF(-1, 0);
            if (buf.Count >0)
            {
                float mid = buf[0].Y;

                for (int i = 0; i < buf.Count; i++)
                {
                    if (buf[i].Y <= mid)
                    {
                        index = new PointF(buf[i].X, buf[i].Y);

                        mid = buf[i].Y;
                    }

                }
            }
           
            return index;
        }
    }
}
