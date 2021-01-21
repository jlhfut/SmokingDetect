using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Wayee.PeakObject;
using System.IO;

namespace Wayee.BaseLine
{
    public class BaseLineCalculator
    {
        #region 计算基线
        struct SubList
        {
            /// <summary>
            /// 子列表开始索引
            /// </summary>
            public int start;
            /// <summary>
            /// 子列表结束索引
            /// </summary>
            public int end;
            public SubList (int s,int e)
            {
                start=s;
                end=e;
            }
        }
        /// <summary>
        /// 基线计算器
        /// </summary>
        /// <param name="peakObj">峰对象列表</param>
        public static void SetBaseLine(List<Peak> peakList)
        {
            List<SubList> _subList = new List<SubList>();
            _subList = GetSublist(peakList);
            //bool b = false;
            for (int i = 0; i < peakList.Count; i++)
            {
                //2012-03-15 zhangrongzhou
                //for (int j = 0; j < _subList.Count; j++)
                //{
                //    b = (i >= _subList[j].start && i <= _subList[j].end);
                //    if (b) break;
                //}
                //if (!b)
                //{
                peakList[i].StartBaseLine = PointF.Empty;
                peakList[i].EndBaseLine = PointF.Empty;
                //}
                //2012-03-15 zhangrongzhou
            }
            bool changed = false;
            foreach (SubList sl in _subList)
            {
                //2012-03-15 zhangrongzhou
                changed = false;
                for (int i = sl.start; i <= sl.end; i++)
                {
                    if (peakList[i].PeakState == Peak.PeakStates.ps_natural)
                    {
                        changed = true;
                        break;
                    }
                }
                if (changed)
                //2012-03-15 zhangrongzhou
                    ComputeBaseLineEx(peakList, sl.start, sl.end);
            }
        }
        /// <summary>
        /// 获取子列表
        /// </summary>
        /// <param name="peakList">峰列表</param>
        /// <returns>子列表</returns>
        private static List<SubList> GetSublist(List<Peak> peakList)
        {
            List<SubList> lst = new List<SubList>();
            int start = -1;
            int natural = 0;
            int i=0;

            //int j = 0;
            //bool flag = false;
            int peaklistcount = peakList.Count;
            while (i < peaklistcount)
            {
                if (start!=-1)
                {
                    //20141023zhangrongzhou
                    //if (peakList[i].PeakState == Peak.PeakStates.ps_natural) natural = i;
                    if (PeakFilter.MatchBaselinePeak(peakList[i])) natural = i;
                    //20141023
                    if (peakList[i].BaseLineEnd)
                    {
                        if (natural < start) natural = start;
                        lst.Add(new SubList(start, natural));
                        start = -1;
                    }
                }
                else
                {
                    //if (peakList[i].PeakState == Peak.PeakStates.ps_natural)
                    if (PeakFilter.MatchBaselinePeak(peakList[i]))
                    //20141023                    
                    {
                        start = i;
                        continue;
                    }
                }
                i++;
            }
            if (start != -1)
            {
                if (natural < start) natural = start;
                lst.Add(new SubList(start, natural));
            }
            //20120612zhangrongzhou
            ////search first natural peak
            //for (j = 0; j < peaklistcount; j++)
            //    if (peakList[j].PeakState == Peak.PeakStates.ps_natural)
            //    {
            //        start = j;
            //        break;
            //    }
            ////
            //for (i = j; i < peaklistcount; i++)
            //{
            //    if (peakList[i].PeakState == Peak.PeakStates.ps_natural) natural = i;
            //    if (peakList[i].BaseLineEnd)
            //    {
            //        lst.Add(new SubList(start, natural));
            //        flag = true;
            //        start = i + 1;
            //    }
            //    else if (flag)
            //    {
            //        if (peakList[i].PeakState != Peak.PeakStates.ps_natural)
            //            start++;
            //        else
            //            flag = false;
            //    }
            //}
            //if (start < i)
            //    lst.Add(new SubList(start, i - 1));
            return lst;
        }
        /// <summary>
        /// 扩展基线计算方法
        /// </summary>
        /// <param name="peakList">峰列表</param>
        /// <param name="front">前索引</param>
        /// <param name="back">后索引</param>
        private static void ComputeBaseLineEx(List<Peak> peakList, int front, int back)
        {
            if (front > back) return;
            List<int> dList = new List<int>();
            VisitObjListIterator(peakList, front, back, dList);
            if (dList.Count == 0)
            {
                ComputeBaseLine(peakList, front, back);
            }
            else
            {
                dList.Sort();
                //第一个峰起点到第一个最低点峰前一个峰终点（第一个最低点峰起点）
                ComputeBaseLine(peakList, front, dList[0] - 1);
                //前一个峰起点到下一个峰起点
                for (int i = 0; i < dList.Count - 1; i++)
                {
                    int left = dList[i];
                    int right = dList[i + 1];
                    ComputeBaseLine(peakList, left, right - 1);
                }
                //倒数第一个最低点峰到最后一个峰终点
                ComputeBaseLine(peakList, dList[dList.Count - 1], back);
            }
        }
        /// <summary>
        /// 遍历峰对象列表，找出谷点、起始点最小值列表
        /// </summary>
        /// <param name="peakObj">峰对象列表</param>
        /// <param name="start">起始点</param>
        /// <param name="end">终点</param>
        /// <param name="dList">较低点列表</param>
        private static void VisitObjListIterator(List<Peak> peakObj, int start, int last, List<int> dList)
        {
            try
            {
                //less than one peak
                if (start >= last || start < 0 || last > peakObj.Count - 1)
                {
                    Console.WriteLine("Error! The point is not found!");
                    return;
                }
                else//more than two peaks
                {
                    Double factor1 = GetFactor(peakObj[start], peakObj[last]);
                    Double factor2 = 0;
                    int cursor = 0;
                    Double tmp = factor1;
                    for (int i = start + 1; i <= last; i++)
                    {
                        factor2 = (peakObj[i].StartPoint.Y - peakObj[start].StartBaseLine.Y) / (peakObj[i].StartPoint.X - peakObj[start].StartBaseLine.X);
                        if (factor2 < tmp)
                        {
                            tmp = factor2;
                            cursor = i;
                        }
                    }
                    if (tmp < factor1)
                    {
                        if (peakObj[cursor].PeakState != Peak.PeakStates.ps_combine)
                            dList.Add(cursor);
                        VisitObjListIterator(peakObj, start, cursor - 1, dList);
                        VisitObjListIterator(peakObj, cursor, last, dList);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// 计算给定峰对象列表的基线起始点和终点
        /// </summary>
        /// <param name="peakList">峰对象列表</param>
        /// <param name="left">峰对象列表起始对象下标</param>
        /// <param name="right">峰对象列表终点对象下标</param>
        private static void ComputeBaseLine(List<Peak> peakList, int left, int right)
        {
            try
            {
                //Error
                if (left > right)
                {
                    Console.WriteLine("StartPoint > EndPoint, Error!");
                    return;
                }
                Peak startObj = peakList[left];
                Peak lastObj = peakList[right];
                Double factor = GetFactor(startObj,lastObj);
                for (int i = left; i <= right; i++)
                {
                    if (peakList[i].PeakState == Peak.PeakStates.ps_combine) continue;
                    //start point
                    if (SetStartBaseLine(peakList[i]))
                        peakList[i].StartBaseLine = new PointF(peakList[i].StartBaseLine.X, (float)(factor * (peakList[i].StartPoint.X - startObj.StartBaseLine.X) + startObj.StartBaseLine.Y));
                    ////补第一个峰的基线终点
                    //基线终点
                    if (i<right && SetEndBaseLine(peakList[i]))
                        peakList[i].EndBaseLine = new PointF(peakList[i].EndBaseLine.X, (float)(factor * (peakList[i].EndPoint.X - startObj.StartBaseLine.X) + startObj.StartBaseLine.Y));
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        /// <summary>
        /// set startbaseline pointf
        /// </summary>
        /// <param name="peak"></param>
        private static bool SetStartBaseLine(Peak peak)
        {
            if (peak.ProtractList != null && peak.ProtractList.Count > 0)
                peak.StartBaseLine = peak.ProtractList[peak.ProtractList.Count - 1];
            else
            {
                peak.StartBaseLine = peak.StartPoint;
                return true;
            }
            return false;
        }
        /// <summary>
        /// set endbaseline pointf
        /// </summary>
        /// <param name="peak"></param>
        private static bool SetEndBaseLine(Peak peak)
        {
            if (peak.TailingList != null && peak.TailingList.Count > 0)
                peak.EndBaseLine = peak.TailingList[peak.TailingList.Count - 1];
            else
            {
                peak.EndBaseLine = peak.EndPoint;
                return true;
            }
            return false;
        }
        /// <summary>
        /// get factor
        /// </summary>
        /// <param name="sPeak"></param>
        /// <param name="ePeak"></param>
        /// <returns></returns>
        private static float GetFactor(Peak sPeak, Peak ePeak)
        {
            PointF endpt,startpt;
            //拖尾
            if (ePeak.TailingList != null && ePeak.TailingList.Count > 0)
                endpt = ePeak.TailingList[ePeak.TailingList.Count - 1];
            else
                endpt = ePeak.EndPoint;
            //前伸
            if (sPeak.ProtractList != null && sPeak.ProtractList.Count > 0)
                startpt = sPeak.ProtractList[sPeak.ProtractList.Count - 1];
            else
                startpt = sPeak.StartPoint;
            sPeak.StartBaseLine = startpt;
            ePeak.EndBaseLine = endpt;
            return (endpt.Y - startpt.Y) / (endpt.X - startpt.X);
        }
        #endregion

        #region 计算基线噪声
        /// <summary>
        /// 计算基线噪声
        /// </summary>
        /// <param name="plist">点列表</param>
        /// <param name="pNum">每秒钟点数</param>
        /// <returns>噪声</returns>
        public static float ComputeBaseLineNoise(List<PointF> pList, int pNum)
        {
            List<PointF> _pList = new List<PointF>();
            int _start = GetStartIndex(pList.Count, pNum);
            for (int i = _start; i <= pList.Count - pNum; i += pNum / 2)
            {
                float _delta = GetDeviation(pList, i, i + pNum);
                //if (_delta > 200 || _delta <=6 )
                //{
                //    continue;
                //}

                if (_pList.Count == 0)
                {
                    _pList.Add(new PointF(_delta, 0));
                }
                else
                {
                    _pList.Add((new PointF(_delta, Math.Abs(_delta - _pList[_pList.Count - 1].X))));
                }
            }
            var _tmpList =_pList.OrderBy(p => p.X).ToList();
            int idx=(int)(_tmpList.Count * 0.93);
            if (idx < 0 || idx >= _tmpList.Count) return 0f;
            return _tmpList[idx].X;
        }
        #endregion

        #region 计算基线漂移
        /// <summary>
        /// 计算基线漂移
        /// </summary>
        /// <param name="pList">点列表</param>
        /// <param name="pNum">每秒钟点数</param>
        /// <returns>漂移量</returns>
        public static float ComputeBaseLineDrift(List<PointF> pList, int pNum)
        {
            if (pList == null || pList.Count == 0 || pList.Count < pNum * 2)
            {
                return -1;
            }
            int _start = GetStartIndex(pList.Count, pNum);
            float _max = GetMeanValue(pList, _start, _start +pNum);
            float _min = _max;
            for (int i = _start; i <= pList.Count - pNum; i += pNum / 2)
            {
                float _aver = GetMeanValue(pList, i, i + pNum);
                if (_max < _aver)
                {
                    _max = _aver;
                }
                if (_min > _aver)
                {
                    _min = _aver;
                }
            }
            return _max - _min;
        }
        /// <summary>
        /// 获取给定曲线列表的起始点索引
        /// </summary>
        /// <param name="total">点列表总数</param>
        /// <param name="pNum">每秒钟接收点数</param>
        /// <returns>起始点索引</returns>
        private static int GetStartIndex(int total, int pNum)
        {
            int _start;
            int _Number = pNum * 60 * 30;
            if (total > _Number)
            {
                _start = total - _Number;
            }
            else
            {
                _start = 0;
            }
            return _start;
        }
        /// <summary>
        /// 计算点列表平均值
        /// </summary>
        /// <param name="pList">点列表</param>
        /// <param name="start">起始点</param>
        /// <param name="end">终点</param>
        /// <returns>平均值</returns>
        private static float GetMeanValue(List<PointF> pList, int start, int end)
        {
            float _aver = 0;
            for (int i = start; i < end; i++)
            {
                _aver += pList[i].Y;
            }
            _aver /= end - start;
            return _aver;
        }
        /// <summary>
        /// 计算点列表最大离差
        /// </summary>
        /// <param name="pList">点列表</param>
        /// <param name="start">起始点</param>
        /// <param name="end">终点</param>
        /// <returns>最大离差</returns>
        private static float GetDeviation(List<PointF> pList, int start, int end)
        {
            float _max = pList[start].Y;
            float _min = _max;
            for (int i = start; i < end; i++)
            {
                if (_max < pList[i].Y)
                {
                    _max = pList[i].Y;
                }
                if (_min > pList[i].Y)
                {
                    _min = pList[i].Y;
                }
            }
            return _max - _min;
        }
        #endregion
    }
}
