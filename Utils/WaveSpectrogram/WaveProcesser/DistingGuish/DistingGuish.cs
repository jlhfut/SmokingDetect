//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: DistingGuish.cs
// 作者：胡凡平
// 日期：2011/03/09
// 描述：根据文献资料设计的介于一阶微分和二阶微分的判峰算法：
//       设定一个窗口，进行滑动，求取串口内的数据的一阶微分
//       根据一阶微分的变化趋势进行峰值的判定。
//       参考文献《一阶和二阶导数相综合的色谱峰检测法》。
// 版本：1.00
//
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
//
//              2011-03-22       胡凡平           增加找到峰后的
//                                                触发事件代码，并重新定义
//                                                峰数据结构：
//                                                增加峰的起点和终点，原来的起点和终点定义为零起点和零终点
//
//              2011-03-25       胡凡平           增加最小峰宽的设定和峰增长速度的设定参数
//              2011-04-19       胡凡平           将起止点和峰值点修改为PointF类型
//              2011-04-25       胡凡平           改检测流程放弃检测前后拐点，直接进行起止点和峰顶点的检测
//              2011-04-25       胡凡平           增加微分队列的中值滤波操作，对微分队列进行中值滤波可以增加检测效率
//              2011-04-27       胡凡平           废弃原有的寻峰方法，直接利用斜率关系进行寻峰
//              2011-07-04       胡凡平           清理不用的东西，将所有变量修改为私有，去掉静态属性
//==============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Threading;
namespace Wayee.WaveProcesser
{
    public enum CheckStage : int
    {
        StartPointChecke = 1,
        PeakPointChecke = 2,
        EndPointChecke = 3,

    }

    /// <summary>
    /// 介于一阶微分和二阶微分的判峰算法
    /// </summary>
    public class DistingGuish : ICheckPeak
    {
        #region variables
        /// <summary>
        /// 程序状态标志
        /// </summary>
        CheckStage ProgrameStage = CheckStage.StartPointChecke;
        /// <summary>
        /// 定义判峰数据窗口长度
        /// </summary>
        int WindowLength = 0;
        /// <summary>
        /// 窗口数组     
        /// </summary>
        List<PointF> Window = new List<PointF>();
        /// <summary>
        /// 起点斜率阈值
        /// </summary>
        float startslopegate = 0.06f;
        /// <summary>
        /// 终点斜率阈值
        /// </summary>
        float endslopegate = -0.02f;
        /// <summary>
        /// 历史终点备份
        /// </summary>
        PointF HisEnd = new PointF(0, 0);
        /// <summary>
        /// 当前数据存储列表
        /// </summary>
        List<PointF> SorData = new List<PointF>();
        /// <summary>
        /// 最大数据窗口定义
        /// </summary>
        int MaxWndLength = 20;
        /// <summary>
        /// 数据点与时间对应的列表
        /// </summary>
        Hashtable pointHash = new Hashtable();
        /// <summary>
        /// 数据点横坐标
        /// </summary>
        int PointX = 0;
        /// <summary>
        /// 中间峰检测标志
        /// </summary>
        bool CheckMidPeak = false;
        /// <summary>
        /// 原始峰数据
        /// </summary>
        volatile List<PointF> SourceData = new List<PointF>();
        /// <summary>
        /// 检测结束标志
        /// </summary>
        volatile bool IsOver = true;
        /// <summary>
        /// 检测到得峰数据列表
        /// </summary>
        volatile List<PeakFoundEventArgs> peaklist = new List<PeakFoundEventArgs>();
        /// <summary>
        /// 定义找到峰事件，用于实现接口
        /// </summary>
        PeakFoundEvent.PeakfoundeventHandler foundpeak;
        /// <summary>
        /// 找到峰事件中的传递的参数
        /// </summary>
        PeakFoundEventArgs peakfounde = new PeakFoundEventArgs();
        /// <summary>
        /// 找到峰事件中的传递的参数
        /// </summary>
        PeakFoundEventArgs midpeak = new PeakFoundEventArgs();
        /// <summary>
        /// 手动停止标志
        /// </summary>
        bool _isStoped = false;

        #endregion

        #region event
        /// <summary>
        /// 实现接口，找到峰事件
        /// </summary>
        public event PeakFoundEvent.PeakfoundeventHandler PeakFoundEvent
        {
            add
            {
                foundpeak += value;
            }
            remove
            {
                foundpeak -= value;
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// 构造函数，以特定的窗口长度实例化对象,初始化参数为最小峰宽
        /// </summary>
        /// <param name="WinLength">定义窗口长度</param>
        public DistingGuish()
        {

            WindowLength = 10;
            midpeak.IsMidPeak = true;
        }

        #endregion

        #region MainMethod

        /// <summary>
        /// 清空历史数据
        /// </summary>
        public void ClearData()
        {
            WindowLength = 20;
            PointX = 0;
            CheckMidPeak = false;
            ProgrameStage = CheckStage.StartPointChecke;
            Window.Clear();
            Window = new List<PointF>();
            HisEnd = new PointF(0, 0);
            SorData.Clear();
            SorData = new List<PointF>();
            pointHash.Clear();
            pointHash = new Hashtable();
            SourceData.Clear();
            SourceData = new List<PointF>();

            peakfounde = new PeakFoundEventArgs();
            midpeak = new PeakFoundEventArgs();

        }

        /// <summary>
        /// 进行峰判别
        /// </summary>
        /// <param name="Buf">输入数据</param>
        /// <param name="PWidthStep">峰宽的增长幅度
        /// <returns>检测到峰的标志：检测到峰后返回true，否则返回false</returns>
        public bool CheckPeak(PointF PointData)
        {

            pointHash.Add(PointX, PointData.X);
            PointData = new PointF(PointX, PointData.Y);
            PointX++;
            StaticMethods.QueAdd(Window, PointData, WindowLength);//数据加入队列 
            SorData.Add(PointData);//当前数据存储，用于每个峰数据定点的查询
            switch (ProgrameStage)
            {
                case CheckStage.StartPointChecke:
                    ProgrameStage = _CheckStartingPoint(Window);

                    if (ProgrameStage == CheckStage.PeakPointChecke)
                    {
                      //  peakfounde.StartPoint = StaticMethods.GetMin(Window);
                        peakfounde.StartPoint = Window[0];
                        if (CheckMidPeak)
                        {
                            CheckMidPeak = false;
                            if (peakfounde.StartPoint.X > HisEnd.X)
                            {
                                midpeak.StartPoint = new PointF(HisEnd.X, HisEnd.Y);
                                midpeak.EndingPoint = new PointF(peakfounde.StartPoint.X, peakfounde.StartPoint.Y);
                                midpeak.PeakPoint = StaticMethods.GetMax(getpeakdata(SorData, midpeak.StartPoint.X, midpeak.EndingPoint.X));
                                peaklist.Add(_excangepeak(copypeak(midpeak), pointHash));
                                delhash((int)(midpeak.EndingPoint.X), pointHash);

                            }
                            else
                            {
                                peakfounde.StartPoint = new PointF(HisEnd.X, HisEnd.Y);
                            }
                        }

                    }
                    break;
                case CheckStage.PeakPointChecke:
                    ProgrameStage = _CheckPeakPoint(Window);
                    break;
                case CheckStage.EndPointChecke:
                    ProgrameStage = _CheckEndingPoint(Window);
                    if (Stoped)//如果手动停止，直接将状态改变为判别到峰的状态，直接输出数据
                    {
                        ProgrameStage = CheckStage.StartPointChecke;
                        _isStoped = false;
                    }

                    if (ProgrameStage == CheckStage.StartPointChecke)
                    {
                        peakfounde.EndingPoint = StaticMethods.GetMin(Window);//写终点
                        HisEnd = new PointF(peakfounde.EndingPoint.X, peakfounde.EndingPoint.Y);
                        peakfounde.PeakPoint = StaticMethods.GetMax(getpeakdata(SorData, peakfounde.StartPoint.X, peakfounde.EndingPoint.X));
                        //   peakfounde.StartPoint = new PointF(SorData[0].X, SorData[0].Y);
                        //   PeakWidth += PWidthStep;//最小峰宽自增
                        //if(peakfounde .EndingPoint .X >=4512f)
                        //    peakfounde.EndingPoint = StaticMethods.GetMin(Window);//写终点;
                        if (foundpeak != null)
                        {
                            peaklist.Add(_excangepeak(copypeak(peakfounde), pointHash));
                            foundpeak(this, peaklist);//触发事件，读取峰数据
                            peaklist.Clear();
                            delhash((int)(peakfounde.EndingPoint.X), pointHash);
                            ReCheckWindowlength(peakfounde);
                            CheckMidPeak = true;
                        }

                        delforestdata(SorData, peakfounde.EndingPoint.X);//删除峰终点以前的数据

                    }

                    break;
            }
            IsOver = true;//判别结束 
            return IsOver;
        }

        #endregion

        #region PrivateSupportMethods

        /// <summary>
        ///  峰起始位置判断
        /// </summary>
        /// <param name="DiffBuf">输入一阶微分数组</param>
        /// <param name="GatePro">事先设定好的起始位置标志的门限阈值</param>
        /// <returns>返回程序所处的阶段标志：1 表示处于判断起始位置阶段；2 表示起始位置判断结束，进入第二阶段，判断前拐点</returns>
        private CheckStage _CheckStartingPoint(List<PointF> DiffBuf)
        {

            float[] res = StaticMethods.LineFit(DiffBuf);
            if (res[1] > startslopegate)
            {
                return CheckStage.PeakPointChecke;
            }
            else
                return CheckStage.StartPointChecke;

        }

        /// <summary>
        /// 判峰函数,同时判定是否有前剑锋和峰顶
        /// </summary>
        /// <param name="DiffBuf">输入一阶微分数据</param>
        /// <param name="GatePro">判峰门限</param>
        /// <returns>返回程序所处的阶段：2 有肩峰；4 检测到峰顶；3 继续检测峰顶</returns>
        private CheckStage _CheckPeakPoint(List<PointF> DiffBuf)
        {
            //前肩峰判定
            float slope = StaticMethods.LineFit(DiffBuf)[1];
            if (slope < endslopegate)
            {

                return CheckStage.EndPointChecke;
            }
            else
            {

                return CheckStage.PeakPointChecke;
            }

        }

        /// <summary>
        /// 终点判别，同时判断重叠峰谷点，后肩峰
        /// </summary>
        /// <param name="DiffBuf">输入一阶微分数据</param>
        /// <param name="SourceBuf">输入原始数据</param>
        /// <param name="GatePro">预设门限阈值</param>
        /// <returns>返回程序所处的阶段：1 检测到终点，本次峰判断结束；2 检测到重叠峰的谷点；4 检测到后峰肩；5 本次未能检测到终点，继续检测</returns>
        private CheckStage _CheckEndingPoint(List<PointF> DiffBuf)
        {

            float rs = StaticMethods.LineFit(DiffBuf)[1];
            if (rs > endslopegate)
            {

                return CheckStage.StartPointChecke;//找到峰

            }
            else
            {
                return CheckStage.EndPointChecke;//继续找峰终点

            }


        }

        #endregion

        #region Property
        ///// <summary>
        ///// 数据处理的窗口长度，可以不设置，如果效果不理想可以设置，最好不要太小，默认值为17
        ///// </summary>
        //public int ProWinLength
        //{
        //    get
        //    {
        //        return WindowLength;
        //    }
        //    set
        //    {
        //        WindowLength = value;
        //    }
        //}

        /// <summary>
        /// 起点斜率阈值
        /// </summary>
        public float StartSlopeGate
        {
            get
            {
                return startslopegate;
            }
            set
            {
                  startslopegate = value;
            }
        }
        /// <summary>
        /// 终点斜率阈值
        /// </summary>
        public float EndSlopeGate
        {
            get
            {
                return endslopegate;
            }
            set
            {
                //if (value >= 0)
                //    endslopegate = value;
                //else endslopegate = 0;

                endslopegate = value;
            }
        }
        /// <summary>
        /// 是否已经手动停止
        /// </summary>
        public bool Stoped
        {
            get
            {
                return _isStoped;
            }
            set
            {
                _isStoped = value;

                CheckPeak(new PointF((float ) pointHash[Convert.ToInt32(SorData[SorData.Count - 1].X)],SorData [SorData.Count -1].Y ));
            }
        }
        /// <summary>
        /// 设置最大窗口长度，默认值为500；
        /// 用于调整判峰分辨率
        /// </summary>
        public int WindowLengthMax
        {
            get { return MaxWndLength; }
            set { MaxWndLength = value; }
        }
        #endregion

        #region Private
        /// <summary>
        /// 根据给定的峰起止点，去掉峰数据列表中的冗余数据，直接改变峰数据列表的内容
        /// </summary>
        /// <param name="datalist"></param>
        /// <param name="startX"></param>
        /// <param name="endX"></param>
        private List<PointF> getpeakdata(List<PointF> datalist, float startX, float endX)
        {
            List<PointF> peakdatalist = new List<PointF>();
            for (int i = datalist.Count - 1; i >= 0; i--)
            {
                if (datalist[i].X <= endX && datalist[i].X >= startX)

                    peakdatalist.Add(new PointF(datalist[i].X, datalist[i].Y));

            }

            return peakdatalist;
        }
        /// <summary>
        /// 删除给定的横坐标以前的数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="forestX"></param>
        private void delforestdata(List<PointF> list, float forestX)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].X < forestX)
                    list.RemoveAt(i);
            }
        }
        /// <summary>
        /// 删除后向数据
        /// </summary>
        /// <param name="list"></param>
        /// <param name="endX"></param>
        private void dellaterdata(List<PointF> list, float endX)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].X > endX)
                    list.RemoveAt(i);
            }
        }
        /// <summary>
        /// 交换峰对象数据
        /// </summary>
        /// <param name="sourcepeak"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        private PeakFoundEventArgs _excangepeak(PeakFoundEventArgs sourcepeak, Hashtable mode)
        {
            PeakFoundEventArgs tarpeak = new PeakFoundEventArgs();
            int xkey = Convert.ToInt32(sourcepeak.StartPoint.X);
            if (mode.Contains(xkey))
                tarpeak.StartPoint = new PointF((float)mode[xkey], sourcepeak.StartPoint.Y);
            xkey = Convert.ToInt32(sourcepeak.PeakPoint.X);
            if (mode.Contains(xkey))
                tarpeak.PeakPoint = new PointF((float)mode[xkey], sourcepeak.PeakPoint.Y);
            xkey = Convert.ToInt32(sourcepeak.EndingPoint.X);
            if (mode.Contains(xkey))
                tarpeak.EndingPoint = new PointF((float)mode[xkey], sourcepeak.EndingPoint.Y);
            tarpeak.IsMidPeak = sourcepeak.IsMidPeak;
            tarpeak.LeftTrendPointNum = sourcepeak.LeftTrendPointNum;
            tarpeak.BackTrendPointNum = sourcepeak.BackTrendPointNum;

            return tarpeak;
        }
        /// <summary>
        /// 删除哈希表冗余数据
        /// </summary>
        /// <param name="endX"></param>
        /// <param name="hastable"></param>
        private void delhash(float endX, Hashtable hastable)
        {
            List<int> arraryX = new List<int>();
            foreach (DictionaryEntry de in hastable)
            {
                if ((int)(de.Key) < (int)endX)
                    arraryX.Add((int)de.Key);
            }
            for (int i = 0; i < arraryX.Count; i++)
                hastable.Remove(arraryX[i]);
            arraryX.Clear();
        }

        /// <summary>
        /// 峰对象格式检查
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool check(PeakFoundEventArgs e)
        {
            if (e.StartPoint.X <= e.PeakPoint.X && e.PeakPoint.X <= e.EndingPoint.X)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 复制峰对象
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private PeakFoundEventArgs copypeak(PeakFoundEventArgs e)
        {
            PeakFoundEventArgs newpeak = new PeakFoundEventArgs();
            newpeak.StartPoint = new PointF(e.StartPoint.X, e.StartPoint.Y);
            newpeak.PeakPoint = new PointF(e.PeakPoint.X, e.PeakPoint.Y);
            newpeak.EndingPoint = new PointF(e.EndingPoint.X, e.EndingPoint.Y);
            newpeak.IsMidPeak = e.IsMidPeak;
            return newpeak;
        }
        /// <summary>
        /// 将峰对象加入列表中
        /// </summary>
        /// <param name="sourcepeak"></param>
        /// <param name="targetpeak"></param>
        private void addpeak(PeakFoundEventArgs sourcepeak, PeakFoundEventArgs targetpeak)
        {
            if (sourcepeak.StartPoint.X != 0f)
            {
                if (targetpeak.StartPoint.X != sourcepeak.EndingPoint.X)
                    targetpeak.StartPoint = new PointF(sourcepeak.StartPoint.X, sourcepeak.StartPoint.Y);
            }

        }
        #endregion

        #region test


        //private void savfile(PointF Da)
        //{
        //    StreamWriter sav = new StreamWriter("Peak_Test.txt", true);            
        //    sav.WriteLine(Da.Y.ToString ());
        //    sav.Dispose();
        //}
        /// <summary>
        /// 重新检查数据窗口长度
        /// </summary>
        /// <param name="peakfounde"></param>
        /// <returns></returns>
        private void  ReCheckWindowlength(PeakFoundEventArgs peakfounde)
        {
            int length = Convert.ToInt32(Convert.ToDouble(peakfounde.PeakPoint.X) - Convert.ToDouble(peakfounde.StartPoint.X));
         //   length = Convert.ToInt32((WindowLength * Window.Count * 1.0) / ((Window[Window.Count - 1].X - Window[0].X) * 1.0));
            WindowLength = length > MaxWndLength ?  MaxWndLength:length ;
            WindowLength = WindowLength > 20 ? WindowLength : 20;

          //  return length;
        }

        //private float checkpeakheight(PeakFoundEventArgs peakfounde)
        //{
        //    float minpeakheight = peakfounde.PeakPoint.Y - peakfounde.StartPoint.Y;
        //    float midheight = (peakfounde.PeakPoint.Y - peakfounde.EndingPoint.Y);
        //    return minpeakheight > midheight ? minpeakheight : midheight;
        //}
        #endregion

    }
}
