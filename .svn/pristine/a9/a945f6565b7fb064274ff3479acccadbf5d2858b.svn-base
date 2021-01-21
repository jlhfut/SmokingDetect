//===============================================================
// Copyright (C) 2010-2013 皖仪科技研发中心
// 文件名: CalculatePeak.cs
// 日期：2013/10/10
// 描述：峰信息计算
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wayee.PeakObject;
using System.Drawing;
using System.Diagnostics;

namespace Wayee.ResultAnalyzer
{
    #region 计算峰信息

    #region 基类
    internal class CCalculationBase
    {
        #region 二分法比较器
        public class PointFComparer : IComparer<PointF>
        {
            public int Compare(PointF x, PointF y)
            {
                if (x == null)
                {
                    if (y == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    if (y == null)
                    {
                        return 1;
                    }
                    else
                    {
                        if (Math.Abs(x.X - y.X) <= (float)0.025)
                        {
                            return 0;
                        }
                        else if (x.X < y.X)
                        {
                            return -1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
            }
        }
        #endregion

        private static PointFComparer _mPointFComparer = new PointFComparer();

        private const double _mTailingFactorHeight = 0.05;
        private const double _mSymmetryFactorHeight = 0.1;

        #region 私有方法
        /// <summary>
        /// 获取峰起点
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        private PointF GetPeakStartPoint(Peak p)
        {
            if (p.StartBaseLine == null || p.StartBaseLine == PointF.Empty)
                return p.StartPoint;
            else
                return p.StartBaseLine;
        }
        /// <summary>
        /// 获取峰终点
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        private PointF GetPeakEndPoint(Peak p)
        {
            if (p.EndBaseLine == null || p.EndBaseLine == PointF.Empty)
                return p.EndPoint;
            else
                return p.EndBaseLine;
        }

        /// <summary>获取峰列表第一个有效峰</summary>
        /// <param name="peak_list">峰对象列表</param>
        /// <returns>返回第一个峰</returns>
        //private Peak GetFirstPeak(List<Peak> peak_list)
        //{
        //    Peak _first_peak = null;

        //    foreach (Peak _p in peak_list)
        //    {
        //        if (_p.PeakState != Peak.PeakStates.ps_noise)
        //        {
        //            _first_peak = _p;
        //            break;
        //        }
        //    }

        //    return _first_peak;
        //}

        #region 原有代码
        //#region 二分查找法
        ///// <summary>
        ///// Find a value in the list with Binary Search Method
        ///// </summary>
        ///// <param name="pList">PointF list</param>
        ///// <param name="key">value of key</param>
        ///// <returns>index of key</returns>
        //private int BinarySearch(List<PointF> pList, Double key)
        //{
        //    int bingo = -1;
        //    int low = 0;
        //    int high = pList.Count - 1;
        //    while (low <= high)
        //    {
        //        int mid = (low + high) / 2;
        //        if (Math.Abs(key - pList[mid].X) < 0.1)
        //        {
        //            bingo = mid;
        //            break;
        //        }
        //        else
        //        {
        //            if (key < pList[mid].X)
        //            {
        //                high = mid - 1;
        //            }
        //            else
        //            {
        //                low = mid + 1;
        //            }
        //        }
        //    }
        //    return bingo;
        //}
        //#endregion
        #endregion

        #region 计算任意峰高宽两端点与峰顶组成的三角形
        /// <summary>获取两点间的距离</summary>
        /// <param name="A">点A</param>
        /// <param name="B">点B</param>
        /// <returns>两点间的距离</returns>
        private double ComputeDistance(PointF A, PointF B)
        {
            double _delta_x = A.X - B.X;
            double _delta_y = A.Y - B.Y;

            return Math.Sqrt(_delta_x * _delta_x + _delta_y * _delta_y);
        }

        /// <summary>获取任意峰高宽两端点与峰高线的交点</summary>
        /// <param name="peak">峰对象</param>
        /// <param name="peak_curve">峰曲线</param>
        /// <param name="height">高度</param>
        /// <returns>顶点列表，顺序：左端点(A)->右端点(B)->与高的交点(C)</returns>
        private List<PointF> GetWidthOfAnyPeakHeight(Peak peak, List<PointF> peak_curve, double height)
        {
            if ((peak == null) || (peak_curve == null) || (peak_curve.Count == 0) || (height == 0))
                return null;

            //建立基线方程 Y = aX + b
            PointF _sp = GetPeakStartPoint(peak);
            PointF _ep = GetPeakEndPoint(peak);
            List<PointF> _width_line = new List<PointF>();
            //求解一次方程的系数x
            double _a = (_ep.Y - _sp.Y) / (_ep.X - _sp.X);
            double _b = _sp.Y - _a * _sp.X;

            //在峰曲线中找到峰顶点在数组中的位置
            int _vertex_index = peak_curve.BinarySearch(peak.PeakPoint, _mPointFComparer);
            if (_vertex_index < 0)
                return null;

            //峰的指定高度宽的方程应与基线方程平行，并在Y轴上有位移，且位移大小为height
            if (peak.PeakPoint.Y >= _ep.Y)
            {
                //正峰
                _b += height;

                //分别从峰的两端开始搜索，峰宽线与曲线的交点
                for (int i = 0; i < _vertex_index; i++)
                {
                    double _y = _a * peak_curve[i].X + _b;
                    if (_y < peak_curve[i].Y)
                    {
                        _width_line.Add(new PointF(peak_curve[i].X, (float)_y));
                        break;
                    }
                }

                if (_width_line.Count == 0) return null;

                for (int i = peak_curve.Count - 1; i > _vertex_index; i--)
                {
                    double _y = _a * peak_curve[i].X + _b;
                    if (_y < peak_curve[i].Y)
                    {
                        _width_line.Add(new PointF(peak_curve[i].X, (float)_y));
                        break;
                    }
                }

                if (_width_line.Count == 1) return null;
            }
            else
            {
                //负峰
                _b -= height;

                //分别从峰的两端开始搜索，峰宽线与曲线的交点
                for (int i = 0; i < _vertex_index; i++)
                {
                    double _y = _a * peak_curve[i].X + _b;
                    if (_y > peak_curve[i].Y)
                    {
                        _width_line.Add(new PointF(peak_curve[i].X, (float)_y));
                        break;
                    }
                }

                if (_width_line.Count == 0) return null;

                for (int i = peak_curve.Count - 1; i > _vertex_index; i--)
                {
                    double _y = _a * peak_curve[i].X + _b;
                    if (_y > peak_curve[i].Y)
                    {
                        _width_line.Add(new PointF(peak_curve[i].X, (float)_y));
                        break;
                    }
                }

                if (_width_line.Count == 1) return null;
            }

            //此时找到了峰宽线与峰形曲线的两个焦点
            double _ratio = 1;

            if ((peak.PeakHeight > 0) && (peak.PeakWidth1 > 0))
                _ratio = peak.PeakHeight / peak.PeakWidth1;

            double _cross_x = 0, _cross_y = 0;

            if (_ratio >= 3)
            {
                _cross_x = peak.PeakPoint.X;
                _cross_y = _a * _cross_x + _b;
            }
            else
            {
                //建立垂直于基线的高的方程Y = -1/a * X + b0
                double _b0 = peak.PeakPoint.Y + 1 / _a * peak.PeakPoint.X;

                //求解Y = aX + b 与 Y = -1/a * X + b0的交点
                _cross_x = (_b0 - _b) / (_a + 1 / _a);

                //检查交点是否在峰宽的端点之间
                if ((_cross_x <= _width_line[0].X) || (_cross_x >= _width_line[1].X))
                    return _width_line;

                _cross_y = _a * _cross_x + _b;
            }
            _width_line.Add(new PointF((float)_cross_x, (float)_cross_y));

            return _width_line;
        }

        /// <summary>
        /// 获取任意峰高宽两端点与峰顶点组成的三角形
        /// </summary>
        /// <param name="pList">曲线点列表</param>
        /// <param name="obj">峰对象</param>
        /// <param name="height">高度</param>
        /// <returns>三角形顶点列表，顺序：顶点(A)->左顶点(B)->右顶点(C)</returns>
        //protected List<PointF> GetAnyPeakWidthPoint(Peak peak, List<PointF> peak_curve, double height)
        //{
        //    List<PointF> _pList = new List<PointF>();

        //    PointF pLeft = PointF.Empty;
        //    PointF pRight = PointF.Empty;

        //    PointF _start = GetPeakStartPoint(peak);
        //    PointF _end = GetPeakEndPoint(peak);


        //    int _startIndex = BinarySearch(peak_curve, peak.StartPoint.X);
        //    int _endIndex = BinarySearch(peak_curve, peak.EndPoint.X);
        //    for (int i = _startIndex; i < _endIndex; i++)
        //    {
        //        PointF p1 = peak_curve[i];
        //        PointF p2 = peak_curve[i + 1];

        //        Double h1 = ComputePeakHeight(p1, _start, _end);
        //        Double h2 = ComputePeakHeight(p2, _start, _end);

        //        if (h1 <= height && h2 > height)
        //        {
        //            //if (Math.Abs(h1 - height) <= Math.Abs(h2 - height))
        //            //{
        //            pLeft = p1;
        //            //}
        //            //else
        //            //{
        //            //    pLeft = p2;
        //            //}
        //        }
        //        else if (h1 > height && h2 <= height)
        //        {
        //            //if (Math.Abs(h1 - height) <= Math.Abs(h2 - height))
        //            //{
        //            //    pRight = p1;
        //            //}
        //            //else
        //            //{
        //            pRight = p2;
        //            //}
        //        }
        //    }
        //    // 当某峰与前后峰严重重叠时
        //    if (pLeft.IsEmpty && !pRight.IsEmpty)
        //    {
        //        pLeft = new PointF(_start.X + _end.X - pRight.X, pRight.Y);
        //    }
        //    if (pLeft.IsEmpty && pRight.IsEmpty)
        //    {
        //        pLeft = _start;
        //        pRight = _end;
        //    }
        //    if (!pLeft.IsEmpty && pRight.IsEmpty)
        //    {
        //        pRight = new PointF(_start.X + _end.X - pLeft.X, pLeft.Y);
        //    }
        //    _pList.Add(peak.PeakPoint);
        //    _pList.Add(pLeft);
        //    _pList.Add(pRight);
        //    return _pList;
        //}
        #endregion

        #region 获取峰对象曲线点列表
        private List<PointF> RebuildPartPeakCurve(List<PointF> peak_group_curve, List<PointF> valley_point, int start, int end)
        {
            List<PointF> _part_peak_curve = new List<PointF>();

            if (valley_point.Count <= 1) return null;

            float[] _slope_array = new float[valley_point.Count - 1];

            for (int k = 0; k < valley_point.Count - 2; k++)
            {
                _slope_array[k] = (valley_point[k + 1].Y - valley_point[k].Y) / (valley_point[k + 1].X - valley_point[k].X);
            }
            //拖尾部分曲线列表
            for (int i = start; i < end; i++)
            {
                for (int k = 0; k < valley_point.Count - 2; k++)
                {
                    if (peak_group_curve[i].X >= valley_point[k].X && peak_group_curve[i].X <= valley_point[k + 1].X)
                    {
                        float _x = peak_group_curve[i].X;
                        float _y = _slope_array[k] * (_x - valley_point[k].X) + valley_point[k].Y;

                        _part_peak_curve.Add(new PointF(_x, _y));
                        break;
                    }
                }
            }

            return _part_peak_curve;
        }
        /// <summary>
        /// 根据原始点列表和峰标记，计算针对拖尾和前伸的点列表
        /// </summary>
        /// <param name="pList">原始点列表</param>
        /// <param name="obj">峰对象</param>
        /// <returns></returns>
        private List<PointF> GetPeakCurve(Peak peak, List<PointF> peak_group_curve)
        {
            if ((peak_group_curve == null) || (peak_group_curve.Count == 0))
                return null;

            //峰曲线点列表
            List<PointF> _peak_curve = new List<PointF>();

            //int _start_index = BinarySearch(peak_group_curve, peak.StartPoint);//BinarySearch(pList, peak.StartPoint.X);
            //int _end_index = BinarySearch(peak_group_curve, peak.EndPoint.X);
            int _start_index = peak_group_curve.BinarySearch(peak.StartPoint, _mPointFComparer);
            int _end_index = peak_group_curve.BinarySearch(peak.EndPoint, _mPointFComparer);

            if (peak.StartPoint.X > peak.EndPoint.X)
            {
                Debug.WriteLine("StartPoint > EndPoint in " + "Peak_" + peak.Index);
                return null;
            }

            _start_index = Math.Abs(_start_index);
            _end_index = Math.Abs(_end_index);

            if (_start_index >= peak_group_curve.Count) return null;
            if (_end_index >= peak_group_curve.Count) _end_index = peak_group_curve.Count - 1;

            if (!(_start_index >= 0 && _end_index >= 0 && _start_index <= _end_index))
            {
                Debug.WriteLine("Exceptional peak !");
                return null;
            }

            //前伸曲线点列表
            if (peak.ProtractList != null && peak.ProtractList.Count > 0)
            {
                List<PointF> _valley_point = CheckPointList(peak.ProtractList);
                //int _startEx = BinarySearch(peak_group_curve, _valley_point[_valley_point.Count - 1].X);
                int _startEx = peak_group_curve.BinarySearch(_valley_point[_valley_point.Count - 1], _mPointFComparer);

                List<PointF> _new_valley_point = new List<PointF>();

                for (int i = _valley_point.Count - 1; i >= 0; i--)
                {
                    _new_valley_point.Add(new PointF(_valley_point[i].X, _valley_point[i].Y));
                }

                List<PointF> _part_prak_curve = RebuildPartPeakCurve(peak_group_curve, _new_valley_point, _startEx, _start_index);

                if ((_part_prak_curve != null) && (_part_prak_curve.Count != 0))
                    _peak_curve.AddRange(_part_prak_curve.GetRange(0, _part_prak_curve.Count));

                #region 原有代码
                //float[] _slope_array = new float[_valley_point.Count - 1];

                //if (_valley_point.Count >= 1)
                //{
                //    for (int k = _valley_point.Count - 2; k >= 0; k--)
                //    {
                //        _slope_array[k] = (_valley_point[k].Y - _valley_point[k + 1].Y) / (_valley_point[k].X - _valley_point[k + 1].X);
                //    }
                //    //加点
                //    for (int j = _startEx; j < _start_index; j++)
                //    {
                //        for (int k = _valley_point.Count - 2; k >= 0; k--)
                //        {
                //            if ((peak_group_curve[j].X >= _valley_point[k + 1].X) && (peak_group_curve[j].X <= _valley_point[k].X))
                //            {
                //                float x = peak_group_curve[j].X;
                //                float y = _slope_array[k] * (x - _valley_point[k + 1].X) + _valley_point[k + 1].Y;
                //                _peak_curve.Add(new PointF(x, y));
                //                break;
                //            }
                //        }
                //    }
                //}
                //else
                //{ 
                //    Debug.WriteLine("Protract List count <= 1 !");
                //}
                #endregion
            }

            #region 原有代码
            //原始峰曲线点列表
            //for (int j = _start_index; j <= _end_index; j++)
            //{
            //    _peak_curve.Add(peak_group_curve[j]);
            //}
            #endregion

            _peak_curve.AddRange(peak_group_curve.GetRange(_start_index, _end_index - _start_index + 1));

            //拖尾曲线点列表
            if (peak.TailingList != null && peak.TailingList.Count > 0)
            {
                List<PointF> _valley_point = CheckPointList(peak.TailingList);

                //int _endEx = BinarySearch(peak_group_curve, _valley_point[_valley_point.Count - 1].X);
                int _endEx = peak_group_curve.BinarySearch(_valley_point[_valley_point.Count - 1], _mPointFComparer);

                List<PointF> _part_prak_curve = RebuildPartPeakCurve(peak_group_curve, _valley_point, _end_index, _endEx);
                if ((_part_prak_curve != null) && (_part_prak_curve.Count != 0))
                    _peak_curve.AddRange(_part_prak_curve.GetRange(0, _part_prak_curve.Count));

                #region 原有代码
                //float[] _slope_array = new float[_valley_point.Count - 1];

                //if (_valley_point.Count > 1)
                //{
                //    for (int k = 1; k <= _valley_point.Count - 1; k++)
                //    {
                //        _slope_array[k - 1] = (_valley_point[k].Y - _valley_point[k - 1].Y) / (_valley_point[k].X - _valley_point[k - 1].X);
                //    }
                //    //拖尾部分曲线列表
                //    for (int j = _end_index; j < _endEx; j++)
                //    {
                //        for (int k = 1; k <= _valley_point.Count - 1; k++)
                //        {
                //            if (peak_group_curve[j].X >= _valley_point[k - 1].X && peak_group_curve[j].X <= _valley_point[k].X)
                //            {
                //                float x = peak_group_curve[j].X;
                //                float y = _slope_array[k - 1] * (x - _valley_point[k - 1].X) + _valley_point[k - 1].Y;
                //                _peak_curve.Add(new PointF(x, y));
                //                break;
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    Debug.WriteLine("TailingList List count <= 1 !");
                //}
                #endregion
            }
            return _peak_curve;
        }
        #endregion

        #region 拖尾、前伸预处理
        /// <summary>解决拖尾、前伸列表有重复点的情况</summary>
        /// <param name="pList"> 原始点列表</param>
        /// <returns>修正后的点列表</returns>
        private List<PointF> CheckPointList(List<PointF> point_curve)
        {
            if ((point_curve == null) || (point_curve.Count == 0))
                return null;

            List<PointF> _point_list = new List<PointF>();

            _point_list.Add(point_curve[0]);

            for (int i = 1; i < point_curve.Count; i++)
            {
                int j = 0;

                for (j = 0; j < _point_list.Count; j++)
                {
                    if (point_curve[i].X == _point_list[j].X) continue;
                }

                if (j >= _point_list.Count)
                {
                    _point_list.Add(point_curve[i]);
                }
            }
            return _point_list;
        }
        #endregion

        #endregion

        #region 计算峰面积
        /// <summary>
        /// 计算峰面积
        /// </summary>
        /// <param name="pList">峰曲线列表</param>
        /// <returns>峰面积</returns>
        private Double ComputePeakArea(Peak peak, List<PointF> peak_curve)
        {
            double _peak_area = 0.0, area_below_baseline = 0.0;
            PointF _sp, _ep;

            _sp = GetPeakStartPoint(peak);
            _ep = GetPeakEndPoint(peak);

            double fAdjustH = 0;

            if (peak.PeakPoint.Y >= _ep.Y)
            {
                //正峰
                fAdjustH = (_ep.Y - _sp.Y) > 0 ? _sp.Y : _ep.Y;
            }
            else
            {
                //负峰
                fAdjustH = (_ep.Y - _sp.Y) > 0 ? _ep.Y : _sp.Y;
            }

            for (int i = 0; i < peak_curve.Count - 1; i++)
            {
                PointF _p1 = peak_curve[i];
                PointF _p2 = peak_curve[i + 1];

                _peak_area += Math.Abs((_p2.X - _p1.X) * (_p1.Y + _p2.Y - fAdjustH * 2));
            }

            area_below_baseline = Math.Abs((_ep.X - _sp.X) * (_ep.Y + _sp.Y - fAdjustH * 2));

            return Math.Abs((_peak_area - area_below_baseline) * 0.5);

            #region 原有代码
            //Double area = 0;
            //PointF p1, p2, p3, p4;
            //float factor = (GetPeakEndPoint(peak).Y - GetPeakStartPoint(peak).Y) / (GetPeakEndPoint(peak).X - GetPeakStartPoint(peak).X);//(peak.EndBaseLine.Y - peak.StartBaseLine.Y) / (peak.EndBaseLine.X - peak.StartBaseLine.X);
            //if (double.IsNaN(factor))
            //{
            //    factor = 0;
            //}
            //for (int i = 0; i < pList.Count - 1; i++)
            //{
            //    p3 = new PointF();
            //    p4 = new PointF();
            //    p1 = pList[i];
            //    p2 = pList[i + 1];
            //    p3.X = p1.X;
            //    p3.Y = factor * (p3.X - GetPeakStartPoint(peak).X) + GetPeakStartPoint(peak).Y;
            //    p4.X = p2.X;
            //    p4.Y = factor * (p4.X - GetPeakStartPoint(peak).X) + GetPeakStartPoint(peak).Y;
            //    Double deltaY1 = Math.Abs(p1.Y - p3.Y);
            //    Double deltaY2 = Math.Abs(p2.Y - p4.Y);
            //    Double deltaX = Math.Abs(p2.X - p1.X);
            //    area += 0.5 * deltaX * (deltaY1 + deltaY2);
            //}
            //return area;
            #endregion
        }
        #endregion

        #region 计算峰高
        private double ComputePeakHeight(Peak p)
        {
            PointF _start = GetPeakStartPoint(p);
            PointF _end = GetPeakEndPoint(p);
            PointF _vertex = p.PeakPoint;

            return Math.Abs(_vertex.Y - (_end.Y - (_end.X - _vertex.X) * (_end.Y - _start.Y) / (_end.X - _start.X)));
        }

        #region 原有代码
        /// <summary>
        /// 已知三角形的三个顶点坐标，计算三角形的高
        /// </summary>
        /// <param name="A">顶点</param>
        /// <param name="B">左顶点</param>
        /// <param name="C">右顶点</param>
        /// <returns>高</returns>
        //private Double ComputePeakHeight(PointF A, PointF B, PointF C)
        //{
        //    Double height = 0;
        //    //垂直基线求高
        //    //Double a = Math.Sqrt(Math.Pow((C.Y - B.Y), 2) + Math.Pow((C.X - B.X), 2));
        //    //Double b = Math.Sqrt(Math.Pow((A.Y - C.Y), 2) + Math.Pow((A.X - C.X), 2));
        //    //Double c = Math.Sqrt(Math.Pow((B.Y - A.Y), 2) + Math.Pow((B.X - A.X), 2));
        //    //Double p = 0.5 * (a + b + c);
        //    //height = Math.Sqrt(p * (p - a) * (p - b) * (p - c)) * 2 / a;

        //    //顶点纵坐标值求高
        //    //height = A.Y - B.Y;

        //    //垂线与基线相交求高
        //    Double factor = (C.Y - B.Y) / (C.X - B.X);
        //    Double _y = (A.X - B.X) * factor + B.Y;
        //    height = A.Y - _y;
        //    //如果采用第一种求高未获取结果，采用如下第二种处理方法
        //    if (double.IsNaN(height) || height == 0)
        //    {
        //        height = Math.Min(Math.Abs(B.Y - A.Y), Math.Abs(C.Y - A.Y));
        //        height += Math.Abs(B.Y - C.Y) / 2;
        //    }
        //    return height;
        //}
        #endregion

        #endregion

        #region 原有代码
        //#region 计算半峰宽
        ///// <summary>
        ///// 已知峰对象的高、峰曲线列表、基线起点和基线终点，计算半峰高宽
        ///// </summary>
        ///// <param name="height">峰高</param>
        ///// <param name="pList">峰曲线列表</param>
        ///// <param name="startBase">基线起点</param>
        ///// <param name="endBase">基线终点</param>
        ///// <returns>半峰宽</returns>
        //private Double ComputeAnyHeightWidth(Double height, List<PointF> pList, Peak peak)
        //{
        //    Double semiWidth = -1;
        //    List<PointF> _tmp = GetAnyPeakWidthPoint(peak, pList, height);
        //    semiWidth = Math.Abs(_tmp[2].X - _tmp[1].X);
        //    //semiWidth = Math.Sqrt(Math.Pow((_tmp[2].X - _tmp[1].X), 2) + Math.Pow((_tmp[2].Y - _tmp[1].Y), 2));
        //    return semiWidth;
        //}
        //#endregion
        #endregion

        #region 死时间
        protected double GetDeadTime(List<Peak> peak_list, PeakCalculationMethod pcm)
        {
            double _dead_time = 0.0;
            if (pcm.DeadTime_Method == PeakCalculationMethod.DeadTimeMethod.dtm_first_peak)
            {
                Peak _first_peak = peak_list.Find(CPeakFilter.FindNaturalPeak);
                if (_first_peak != null)
                    _dead_time = _first_peak.PeakPoint.X;
                else
                    _dead_time = pcm.DeadTime;
            }
            else
            {
                _dead_time = pcm.DeadTime;
            }

            return _dead_time;
        }
        #endregion

        #region 计算分离度
        /// <summary>
        /// 计算峰分离度
        /// </summary>
        /// <param name="peak_list">峰列表</param>
        /// <returns>分离度</returns>
        public void ComputeResolution(List<Peak> peak_list)
        {
            if ((peak_list == null) || (peak_list.Count == 0))
                return;

            List<Peak> _valid_peak_list = peak_list.FindAll(CPeakFilter.FindNaturalPeak);
            if (_valid_peak_list == null)
                return;

            Peak _p0 = null, _p1 = null;
            if (_valid_peak_list.Count > 1)
            {
                for (int i = 0; i < _valid_peak_list.Count - 1; i++)
                {
                    _p0 = _valid_peak_list[i];
                    _p1 = _valid_peak_list[i + 1];

                    _p0.SeparatingDegree = ComputeResolution(_p0, _p1);
                }
            }
            else if (_valid_peak_list.Count == 1)
            {
                _valid_peak_list[0].SeparatingDegree = 0;
            }

            return;
        }
        #endregion

        #region 计算对称因子
        /// <summary>计算对称因子</summary>
        /// <param name="peak">峰对象</param>
        /// <param name="peak_curve">峰曲线</param>
        /// <returns>对称因子</returns>
        private double ComputeSymmetryFactor(Peak peak, List<PointF> peak_curve)
        {
            #region 原有代码
            //double _height = Double.Parse((peak.PeakPoint.Y - peak.StartPoint.Y).ToString("f3"));
            //List<PointF> _vertex = GetAnyPeakWidthPoint(peak, peak_curve, _height / 10);
            //Double _leftW = Math.Abs(_vertex[0].X - _vertex[1].X);
            //Double _rightW = Math.Abs(_vertex[2].X - _vertex[0].X);
            //return _leftW / _rightW;
            #endregion

            List<PointF> _point_list = GetWidthOfAnyPeakHeight(peak, peak_curve, peak.PeakHeight * _mSymmetryFactorHeight);

            if ((_point_list != null) && (_point_list.Count == 3))
            {
                double _leftW = 0, _rightW = 0;

                _leftW = ComputeDistance(_point_list[0], _point_list[2]);
                _rightW = ComputeDistance(_point_list[1], _point_list[2]);

                return (_leftW / _rightW);
            }
            return (-1);
        }
        #endregion

        #region 计算拖尾因子
        /// <summary>计算拖尾因子</summary>
        /// <param name="peak">峰对象</param>
        /// <param name="peak_curve">峰曲线</param>
        /// <returns>拖尾因子</returns>
        private double ComputeTailingFactor(Peak peak, List<PointF> peak_curve)
        {
            List<PointF> _point_list = GetWidthOfAnyPeakHeight(peak, peak_curve, peak.PeakHeight * _mTailingFactorHeight);

            if ((_point_list != null) && (_point_list.Count == 3))
            {
                double _leftW = 0, _W = 0;

                //_leftW = ComputeDistance(_point_list[0], _point_list[2]);
                //_rightW = ComputeDistance(_point_list[1], _point_list[2]);
                _leftW = Math.Abs(_point_list[0].X - _point_list[2].X);
                _W = Math.Abs(_point_list[0].X - _point_list[1].X);

                return ((_W) / (2 * _leftW));
            }
            return (-1);
        }
        #endregion

        #region 计算峰信息
        /// <summary>计算峰信息</summary>
        /// <param name="peak">峰对象</param>
        /// <param name="dead_time">死时间</param>
        /// <param name="curve_point">峰曲线列表</param>
        /// <returns>QualitativeErrorInfo枚举</returns>
        private QualitativeErrorInfo ComputePeakInfo(Peak peak, double dead_time, List<PointF> peak_group_curve)
        {
            QualitativeErrorInfo _rc = QualitativeErrorInfo.Success;

            if ((peak == null) || (peak_group_curve == null))
                return QualitativeErrorInfo.PeakObjectError;

            List<PointF> _peak_curve = GetPeakCurve(peak, peak_group_curve);
            if (_peak_curve == null)
            {
                Debug.WriteLine("Peak_" + peak.Index + " can't be calculated !");
                return QualitativeErrorInfo.PeakCurveError;
            }

            //计算容量因子，组分在两相中的总量之比称分配比，又称容量因子,k = (Tr - T0)/T0
            peak.CapacityFactor = (dead_time == 0) ? (-1) : ((peak.PeakPoint.X - dead_time) / dead_time);
            //计算峰面积
            peak.PeakArea = ComputePeakArea(peak, _peak_curve);
            //计算峰高
            //peak.PeakHeight = ComputePeakHeight(peak.PeakPoint, GetPeakStartPoint(peak), GetPeakEndPoint(peak));
            peak.PeakHeight = ComputePeakHeight(peak);

            peak.PeakWidth1 = peak.PeakWidth2 = peak.PeakWidth4 = -1;
            peak.PlateIdealNum = peak.PlateRealNum = -1;
            peak.TailingFactor = peak.AsymmetricDegree = -1;

            List<PointF> _point_line = GetWidthOfAnyPeakHeight(peak, _peak_curve, peak.PeakHeight / 2);
            if ((_point_line == null) || (_point_line.Count < 2))
                return QualitativeErrorInfo.ComputePeakInfoError;

            //peak.PeakWidth2 = ComputeDistance(_point_line[0], _point_line[1]);
            peak.PeakWidth2 = Math.Abs(_point_line[0].X - _point_line[1].X);
            peak.PeakWidth1 = peak.PeakWidth2 * 4 / 2.35;

            _point_line = GetWidthOfAnyPeakHeight(peak, _peak_curve, peak.PeakHeight / 4);
            if ((_point_line == null) || (_point_line.Count < 2))
                return QualitativeErrorInfo.ComputePeakInfoError;

            //peak.PeakWidth4 = ComputeDistance(_point_line[0], _point_line[1]);
            peak.PeakWidth4 = Math.Abs(_point_line[0].X - _point_line[1].X);

            peak.PlateIdealNum = ComputeTheoreticalPlates(peak);
            peak.PlateRealNum = ComputeEffectivePlates(peak, dead_time);
            peak.TailingFactor = ComputeTailingFactor(peak, _peak_curve);
            peak.AsymmetricDegree = ComputeSymmetryFactor(peak, _peak_curve);

            #region OLD_CODE
            ////计算半高峰宽
            //peak.PeakWidth2 = (peak.PeakArea / peak.PeakHeight / 1.065);
            ////计算峰宽
            //peak.PeakWidth1 = peak.PeakWidth2 * 4 / 2.35;
            ////计算四分之一峰宽
            //double _height = Double.Parse((peak.PeakPoint.Y - peak.StartPoint.Y).ToString("f3"));            
            //peak.PeakWidth4 = Double.Parse(ComputeAnyHeightWidth(_height / 4, _peak_curve, peak).ToString("f3"));           
            ////计算理论塔板数
            //peak.PlateIdealNum = ComputeTheoreticalPlates(peak);
            ////计算有效塔板数
            //peak.PlateRealNum = ComputeEffectivePlates(peak, dead_time);
            ////计算拖尾因子，5%高度处全峰宽与左峰宽两倍的比值
            //peak.TailingFactor = ComputeTailingFactor(peak, peak_group_curve);
            ////计算不对称度，10%高度处左峰宽与右峰宽的比值
            //peak.AsymmetricDegree = ComputeSymmetryFactor(peak, peak_group_curve);
            #endregion

            return _rc;
        }

        /// <summary>计算峰对象列表中所有峰对象的属性</summary>
        /// <param name="peak_list">峰对象列表</param>
        /// <param name="peak_group_curve">峰组曲线点列表</param>
        /// <param name="pcm">计算方法参数</param>
        /// <param name="filterMethod">过滤器方法</param>
        /// <returns>QualitativeErrorInfo枚举</returns>
        public QualitativeErrorInfo ComputePeakInfo(List<Peak> peak_list, List<PointF> peak_group_curve, PeakCalculationMethod pcm, System.Predicate<Peak> filterMethod)
        {
            if ((peak_list == null) || (peak_list.Count == 0) || (peak_group_curve == null))
                return QualitativeErrorInfo.PeakListError;

            //获得需要计算的峰列表
            List<Peak> _valid_peak_list = null;
            if (filterMethod != null)
            {
                //_valid_peak_list = peak_list.FindAll(CPeakFilter.FindNaturalPeak);
                _valid_peak_list = peak_list.FindAll(filterMethod);
                if (_valid_peak_list == null)
                    return QualitativeErrorInfo.PeakListError;
            }
            else
            {
                _valid_peak_list = peak_list;
            }

            //死时间
            double _dead_time = GetDeadTime(peak_list, pcm);

            //依次计算每个峰（有效峰）
            foreach (Peak _p in _valid_peak_list)
            {
                ComputePeakInfo(_p, _dead_time, peak_group_curve);
            }

            //计算分离度，相邻两组分的色谱峰保留值之差与峰底宽总和一半的比值
            ComputeResolution(_valid_peak_list);

            return QualitativeErrorInfo.Success;
        }

        #endregion

        #region 虚拟方法
        /// <summary>计算两个峰对象的分离度</summary>
        /// <param name="peak0">峰对象0</param>
        /// <param name="peak1">峰对象1</param>
        /// <returns>分离度</returns>
        protected virtual double ComputeResolution(Peak peak0, Peak peak1)
        {
            return -1;
        }
        /// <summary>计算理论塔板数</summary>
        /// <param name="peak">峰对象</param>
        /// <returns>理论塔板数</returns>
        protected virtual long ComputeTheoreticalPlates(Peak peak)
        {
            return -1;
        }
        /// <summary>计算有效塔板数</summary>
        /// <param name="peak">峰对象</param>
        /// <param name="dead_time">死时间</param>
        /// <returns>有效塔板数</returns>
        protected virtual long ComputeEffectivePlates(Peak peak, double dead_time)
        {
            return -1;
        }

        #endregion
    }
    #endregion

    #region 美国药典
    internal class CCalculationUSP : CCalculationBase
    {
        #region 重载虚拟方法

        private const double _resolution_factor = 2;
        private const double _plates_factor = 16;

        #region 计算峰分离度
        /// <summary>计算两个峰对象的分离度</summary>
        /// <param name="peak0">峰对象0</param>
        /// <param name="peak1">峰对象1</param>
        /// <returns>分离度</returns>
        protected override double ComputeResolution(Peak peak0, Peak peak1)
        {
            return (_resolution_factor * (peak1.PeakPoint.X - peak0.PeakPoint.X) / (peak0.PeakWidth1 + peak1.PeakWidth1));
        }
        #endregion

        #region 计算塔板数
        /// <summary>计算理论塔板数</summary>
        /// <param name="peak">峰对象</param>
        /// <returns>理论塔板数</returns>
        protected override long ComputeTheoreticalPlates(Peak peak)
        {
            return (Int64)(_plates_factor * Math.Pow(peak.PeakPoint.X / peak.PeakWidth1, 2));
        }
        /// <summary>计算有效塔板数</summary>
        /// <param name="peak">峰对象</param>
        /// <param name="dead_time">死时间</param>
        /// <returns>有效塔板数</returns>
        protected override long ComputeEffectivePlates(Peak peak, double dead_time)
        {
            return (Int64)(_plates_factor * Math.Pow((peak.PeakPoint.X - dead_time) / peak.PeakWidth1, 2));
        }
        #endregion

        #endregion
    }
    #endregion

    #region 中国药典
    internal class CCalculationChina : CCalculationBase
    {
        #region 重载虚拟方法

        private const double _resolution_factor = 2;
        private const double _plates_factor = 16;

        #region 计算峰分离度
        /// <summary>计算两个峰对象的分离度</summary>
        /// <param name="peak0">峰对象0</param>
        /// <param name="peak1">峰对象1</param>
        /// <returns>分离度</returns>
        protected override double ComputeResolution(Peak peak0, Peak peak1)
        {
            return (_resolution_factor * (peak1.PeakPoint.X - peak0.PeakPoint.X) / (peak0.PeakWidth1 + peak1.PeakWidth1));
        }
        #endregion

        #region 计算塔板数
        /// <summary>计算理论塔板数</summary>
        /// <param name="peak">峰对象</param>
        /// <returns>理论塔板数</returns>
        protected override long ComputeTheoreticalPlates(Peak peak)
        {
            return (Int64)(_plates_factor * Math.Pow(peak.PeakPoint.X / peak.PeakWidth1, 2));
        }
        /// <summary>计算有效塔板数</summary>
        /// <param name="peak">峰对象</param>
        /// <param name="dead_time">死时间</param>
        /// <returns>有效塔板数</returns>
        protected override long ComputeEffectivePlates(Peak peak, double dead_time)
        {
            return (Int64)(_plates_factor * Math.Pow((peak.PeakPoint.X - dead_time) / peak.PeakWidth1, 2));
        }
        #endregion
        #endregion
    }
    #endregion

    #region 日本药典
    internal class CCalculationJP : CCalculationBase
    {
        #region 重载虚拟方法

        private const double _resolution_factor = 1.18;
        private const double _plates_factor = 5.54;

        #region 计算峰分离度
        /// <summary>计算两个峰对象的分离度</summary>
        /// <param name="peak0">峰对象0</param>
        /// <param name="peak1">峰对象1</param>
        /// <returns>分离度</returns>
        protected override double ComputeResolution(Peak peak0, Peak peak1)
        {
            return (_resolution_factor * (peak1.PeakPoint.X - peak0.PeakPoint.X) / (peak0.PeakWidth2 + peak1.PeakWidth2));
        }
        #endregion

        #region 计算塔板数
        /// <summary>计算理论塔板数</summary>
        /// <param name="peak">峰对象</param>
        /// <returns>理论塔板数</returns>
        protected override long ComputeTheoreticalPlates(Peak peak)
        {
            return (Int64)(_plates_factor * Math.Pow(peak.PeakPoint.X / peak.PeakWidth2, 2));
        }
        /// <summary>计算有效塔板数</summary>
        /// <param name="peak">峰对象</param>
        /// <param name="dead_time">死时间</param>
        /// <returns>有效塔板数</returns>
        protected override long ComputeEffectivePlates(Peak peak, double dead_time)
        {
            return (Int64)(_plates_factor * Math.Pow((peak.PeakPoint.X - dead_time) / peak.PeakWidth2, 2));
        }
        #endregion
        #endregion
    }
    #endregion

    #region 日本药典2
    internal class CCalculationJP2 : CCalculationBase
    {
        #region 重载虚拟方法

        private const double _resolution_factor = 1.18;
        private const double _plates_factor = 5.55;

        #region 计算峰分离度
        /// <summary>计算两个峰对象的分离度</summary>
        /// <param name="peak0">峰对象0</param>
        /// <param name="peak1">峰对象1</param>
        /// <returns>分离度</returns>
        protected override double ComputeResolution(Peak peak0, Peak peak1)
        {
            return (_resolution_factor * (peak1.PeakPoint.X - peak0.PeakPoint.X) / (peak0.PeakWidth2 + peak1.PeakWidth2));
        }
        #endregion

        #region 计算塔板数
        /// <summary>计算理论塔板数</summary>
        /// <param name="peak">峰对象</param>
        /// <returns>理论塔板数</returns>
        protected override long ComputeTheoreticalPlates(Peak peak)
        {
            return (Int64)(_plates_factor * Math.Pow(peak.PeakPoint.X / peak.PeakWidth2, 2));
        }
        /// <summary>计算有效塔板数</summary>
        /// <param name="peak">峰对象</param>
        /// <param name="dead_time">死时间</param>
        /// <returns>有效塔板数</returns>
        protected override long ComputeEffectivePlates(Peak peak, double dead_time)
        {
            return (Int64)(_plates_factor * Math.Pow((peak.PeakPoint.X - dead_time) / peak.PeakWidth2, 2));
        }
        #endregion
        #endregion
    }
    #endregion

    #region 工厂
    public class CCalculationFactory
    {
        private static CCalculationUSP mCUSP = new CCalculationUSP();
        private static CCalculationJP mCJP = new CCalculationJP();
        private static CCalculationJP2 mCJP2 = new CCalculationJP2();
        private static CCalculationChina mCChina = new CCalculationChina();

        public static QualitativeErrorInfo ComputePeakInfo(List<Peak> peak_list, List<PointF> curve_point, PeakCalculationMethod pcm)
        {
            return ComputePeakInfo(peak_list, curve_point, pcm, CPeakFilter.FindNaturalPeak);
        }

        public static QualitativeErrorInfo ComputePeakInfo(List<Peak> peak_list, List<PointF> curve_point, PeakCalculationMethod pcm, System.Predicate<Peak> filterMethod)
        {
            CCalculationBase _calculation = null;

            switch (pcm.Pharmacopeia_Method)
            {
                case PeakCalculationMethod.PharmacopeiaMethod.pm_china:
                    _calculation = mCChina;
                    break;
                case PeakCalculationMethod.PharmacopeiaMethod.pm_japan:
                    _calculation = mCJP;
                    break;
                case PeakCalculationMethod.PharmacopeiaMethod.pm_japan2:
                    _calculation = mCJP2;
                    break;
                case PeakCalculationMethod.PharmacopeiaMethod.pm_usp:
                default:
                    _calculation = mCUSP;
                    break;
            }

            return _calculation.ComputePeakInfo(peak_list, curve_point, pcm, filterMethod);
        }
    }
    #endregion

    #endregion
}
