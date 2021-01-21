//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: ManualProcessor.cs
// 日期：2011/04/07
// 描述：实现手动处理算法；移植提示：移植时需要修稿变量
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
using System.Reflection;
using Wayee.BaseLine;
using Wayee.PeakObject;

namespace Wayee.ManualProcessor
{
    public class PeakProcessor
    {
        public enum PeakExtendOperates { peo_PeakListChange = -2, peo_PeakTextChange=-3 };
        #region public functions
        /// <summary>
        /// 撤销操作
        /// </summary>
        /// <param name="PeakList">峰列表</param>
        /// <param name="operate">操作字符串</param>
        public static void Undo(List<Peak> PeakList, string operate)
        {
            if (operate.Trim() == "") return;
            string[] oprs = operate.Split(';');
            int idx = -1;
            string opr = "";
            string propname = "";
            string value = "";
            PropertyInfo pinf = null;
            bool extend = false;
            Peak peak = null;

            for (int i = oprs.GetLength(0) - 1; i >= 0; i--)
            {
                opr = oprs[i];
                //operate="1:BaseLineEnd=True"
                //get peak object
                idx = opr.IndexOf(":");
                if (idx == -1) continue;
                string peaknum = opr.Substring(0, idx);
                opr = opr.Substring(idx + 1);
                extend = (int.Parse(peaknum) <= (int)PeakExtendOperates.peo_PeakListChange);
                if (extend)
                {
                    List<Peak> pks = (List<Peak>)StaticMethods.DSerialObject(opr);
                    if (pks != null)
                    {
                        PeakList.Clear();
                        PeakList.AddRange(pks);
                    }
                    continue;
                }

                peak = PeakList[int.Parse(peaknum)];
                if (peak == null) continue;
                //get property name and value
                idx = opr.IndexOf("=");
                if (idx == -1) continue;
                value = opr.Substring(idx + 1);
                propname = opr.Substring(0, idx);

                pinf = peak.GetType().GetProperty(propname);
                pinf.SetValue(peak, StaticMethods.DSerialObject(value), null);
            }
        }
        /// <summary>
        /// 还原所有操作
        /// </summary>
        /// <param name="PeakList">峰对象列表</param>
        /// <param name="operatelist">操作列表</param>
        public static void Restore(List<Peak> PeakList, List<string> operatelist)
        {
            for (int i = operatelist.Count - 1; i >= 0; i--)
                Undo(PeakList, operatelist[i]);
        }
        /// <summary "峰分离">
        /// 峰分离算法
        /// </summary>
        /// <param name="PeakList">峰对象列表</param>
        /// <param name="PeakNum">目标峰索引</param>
        public static string SeparatePeak(List<Peak> PeakList, int PeakNum)
        {
            if (PeakNum < 0 || PeakNum >= PeakList.Count) return "";
            if (PeakList[PeakNum].BaseLineEnd) return "";
            string rs = "";
            FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "PeakState", (object)PeakList[PeakNum].PeakState), ref rs);
            int idx = GetNextNatural(PeakList, PeakNum);
            if (idx != -1)
                FromatOperateResult(idx, SetPeakProperty(PeakList[idx], "PeakState", (object)PeakList[idx].PeakState), ref rs);

            FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "BaseLineEnd", (object)true), ref rs);
            return rs;
        }

        /// <summary>
        /// 禁止判峰算法:由目标峰开始向后禁止一个判峰，将目标峰标记终点，向后寻找到第一个真实峰，将其标记为禁判（Peak.PeakStates.ps_inderdict）
        /// </summary>
        /// <param name="PeakList">峰对象列表</param>
        /// <param name="PeakNum">目标峰索引</param>
        public static string DisableCheckPeak(List<Peak> PeakList, int PeakNum)
        {
            if (PeakNum < 0 || PeakNum >= PeakList.Count) return "";
            if (PeakList[PeakNum].PeakState == Peak.PeakStates.ps_inderdict) return "";
            string rs = "";
            for (int i = PeakNum - 1; i >= 0; i--)
            {
                if (PeakList[i].PeakState == Peak.PeakStates.ps_natural)
                {
                    if(!PeakList[i].BaseLineEnd)
                        FromatOperateResult(i, SetPeakProperty(PeakList[i], "BaseLineEnd", (object)true), ref rs);
                    break;
                }
            }
            int idx = GetNextNatural(PeakList, PeakNum);
            if (idx != -1)
                FromatOperateResult(idx, SetPeakProperty(PeakList[idx], "PeakState", (object)PeakList[idx].PeakState), ref rs);
            FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "PeakState", (object)Peak.PeakStates.ps_inderdict), ref rs);
            return rs;
        }
        /// <summary>
        /// 取消禁判
        /// </summary>
        /// <param name="PeakList">峰对象列表</param>
        /// <param name="PeakNum">目标峰索引</param>
        /// <param name="MethodsFlag">上一步操作标志：参考enum  ProcessFlag中定义算法标志</param>
        public static string EnableCheckPeak(List<Peak> PeakList, int PeakNum)
        {
            if (PeakNum < 0 || PeakNum >= PeakList.Count) return "";
            if (PeakList[PeakNum].PeakState != Peak.PeakStates.ps_inderdict) return "";
            string rs = "";
            FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "PeakState", (object)Peak.PeakStates.ps_natural), ref rs);
            //for (int i = PeakNum - 1; i >= 0; i--)
            //{
            //    if (PeakList[i].PeakState == Peak.PeakStates.ps_natural)
            //    {
            //        if (PeakList[i].BaseLineEnd)
            //            FromatOperateResult(i, SetPeakProperty(PeakList[i], "BaseLineEnd", (object)false), ref rs);
            //        break;
            //    }
            //}
            return rs;

        }
        /// <summary>
        /// 负峰倒置
        /// </summary>
        /// <param name="PeakList">峰对象列表</param>
        /// <param name="PeakNum">目标峰索引</param>
        public static string ExtendPeak(List<Peak> PeakList,PeakExtendOperates peo)
        {
            string rs = "";
            string pks = StaticMethods.SerialObject(PeakList);
            FromatOperateResult((int)peo, pks, ref rs);
            return rs;
        }

        /// <summary>
        /// 峰重叠算法:目标峰标记为基线终点
        /// </summary>
        /// <param name="PeakList">峰对象列表</param>
        /// <param name="PeakNum">目标峰索引</param>
        public static string OverLapPeak(List<Peak> PeakList, int PeakNum)
        {
            string rs = "";
            if (PeakNum < 0 || PeakNum >= PeakList.Count) return "";
            if (!PeakList[PeakNum].BaseLineEnd) return "";
            Peak peak = new Peak();

            FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "PeakState", (object)PeakList[PeakNum].PeakState), ref rs);
            FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "BaseLineEnd", (object)false), ref rs);
            return rs;
        }

        /// <summary>
        /// 合并峰算法:将后边一个真实峰合并到目标峰，即，将后一个峰标记为已合并
        /// </summary>
        /// <param name="PeakList">峰对象列表</param>
        /// <param name="PeakNum">目标峰索引</param>
        public static string CombinePeak(List<Peak> PeakList, int PeakNum)
        {
            if (PeakNum < 0 || PeakNum >= PeakList.Count) return "";
            if (PeakList[PeakNum].PeakState == Peak.PeakStates.ps_combine) return "";
            string rs = "";
            int i = PeakNum + 1;
            bool flag = false;
            while (i < PeakList.Count)
            {
                //if (PeakList[i - 1].BaseLineEnd) break;
                flag = (PeakList[i].PeakState == Peak.PeakStates.ps_natural);
                FromatOperateResult(i, SetPeakProperty(PeakList[i], "PeakState", (object)Peak.PeakStates.ps_combine), ref rs);//修改后一个峰的状态
                if (flag)
                {
                    FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "EndPoint", (object)PeakList[i].EndPoint), ref rs);//修改目标峰的终点
                    FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "TailingList", (object)new List<PointF>()), ref rs);//修改目标峰的终点
                    break;
                }
                i++;
            }
            if (!flag) rs = "";
            return rs;
        }
        /// <summary>
        /// 合并峰算法:合并index起始峰开始的count个峰，即，将后的峰标记为已合并
        /// </summary>
        /// <param name="PeakList"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string CombinePeak(List<Peak> PeakList, int PeakNum, int EndNum)
        {
            if (PeakNum < 0 || PeakNum >= EndNum) return "";            
            string rs = "";
            PointF maxy = PeakList[PeakNum].PeakPoint;
            int i = PeakNum + 1;
            while (i <= EndNum)
            {
                if (PeakList[i - 1].BaseLineEnd)
                    FromatOperateResult(i - 1, SetPeakProperty(PeakList[i - 1], "BaseLineEnd", (object)false), ref rs);       //修改当前峰的为非终点
                FromatOperateResult(i, SetPeakProperty(PeakList[i], "PeakState", (object)Peak.PeakStates.ps_combine), ref rs);//修改峰的状态
                if (maxy.Y < PeakList[i].PeakPoint.Y) maxy = PeakList[i].PeakPoint;
                i++;
            }
            FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "PeakState", (object)Peak.PeakStates.ps_natural), ref rs);//修改当前峰的状态为有效峰
            FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "EndPoint", (object)PeakList[EndNum].EndPoint), ref rs);  //修改目标峰的终点
            FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "TailingList", (object)new List<PointF>()), ref rs);      //清除当前锋的拖尾因子
            FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "PeakPoint", (object)maxy), ref rs);                      //清除当前锋的拖尾因子
            return rs;
        }
        ///// <summary>
        ///// 合并峰算法:将后边一个峰合并到目标峰，即，将后一个峰标记为无效
        ///// </summary>
        ///// <param name="PeakList">峰对象列表</param>
        ///// <param name="PeakNum">目标峰索引</param>
        //public static string CombinePeak(List<Peak> PeakList, int PeakNum,bool tonatural)
        //{
        //    if (PeakNum < 0 || PeakNum >= PeakList.Count) return "";
        //    if (PeakList[PeakNum].PeakState == Peak.PeakStates.ps_combine) return "";
        //    string rs = "";
        //    int i = PeakNum + 1;
        //    bool flag = false;
        //    while (i < PeakList.Count)
        //    {
        //        if (PeakList[i-1].BaseLineEnd) break;
        //        flag = (PeakList[i].PeakState == Peak.PeakStates.ps_natural);
        //        FromatOperateResult(i, SetPeakProperty(PeakList[i], "PeakState", (object)Peak.PeakStates.ps_combine), ref rs);//修改后一个峰的状态
        //        if (flag)
        //        {
        //            if (tonatural) i--;
        //            FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "EndPoint", (object)PeakList[i].EndPoint), ref rs);//修改目标峰的终点
        //            FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "TailingList", (object)new List<PointF>()), ref rs);//修改目标峰的终点
        //            break;
        //        }
        //        i++;
        //    }
        //    if (!flag) rs = "";
        //    return rs;
        //}
        /// <summary>
        /// 峰拖尾算法, 计算后续峰的轮廓并将轮廓数据加入原始数据中去
        /// </summary>
        /// <param name="PeakList">峰对象列表</param>
        /// <param name="PeakNum">目标峰索引</param>     
        public static string TrialPeak(List<Peak> PeakList, int PeakNum)
        {
            if (PeakNum < 0 || PeakNum >= PeakList.Count) return "";
            if (PeakList[PeakNum].EndPoint.Equals(PeakList[PeakNum].EndBaseLine) ||
                (PeakList[PeakNum].BaseLineEnd && PeakList[PeakNum].TailingList != null && PeakList[PeakNum].TailingList.Count!=0))
            {
                return "";
            }
            string rs = "";
            PeakList[PeakNum].TailingList.Clear();
            List<PointF> lst = new List<PointF>();
            int Swpindex = StaticMethods.MatchBaseLine(PeakList, PeakNum, false);//获得后向匹配索引
            PointF StartP = new PointF(PeakList[PeakNum].EndPoint.X, PeakList[PeakNum].EndPoint.Y);
            List<Peak> midlist = new List<Peak>();

            for (int i = PeakNum + 1; i <= Swpindex; i++)
            {
                if (PeakList[i].PeakState == Peak.PeakStates.ps_combine) continue;

                midlist.Add(StaticMethods.DSerialObject(StaticMethods.SerialObject(PeakList[i])) as Peak);

                FromatOperateResult(i, SetPeakProperty(PeakList[i], "PeakState", (object)PeakList[i].PeakState), ref rs);

                if (PeakList[i].TailingList.Count > 0)
                    break;
            }
            BaseLine.BaseLineCalculator.SetBaseLine(midlist);
            PointF forestbaseline = midlist[0].StartBaseLine;
            foreach (Peak p in midlist)
            {
                if (p.StartBaseLine.X > forestbaseline.X)
                    lst.Add(p.StartBaseLine);
                forestbaseline = p.StartBaseLine;
                if (p.EndBaseLine.X > forestbaseline.X)
                    lst.Add(p.EndBaseLine);
                forestbaseline = p.EndBaseLine;
            }

            if (lst.Count > 0)
            {
                FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "TailingList", (object)lst), ref rs);
                FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "BaseLineEnd", (object)true), ref rs);
            }
            return rs;
        }

        /// <summary>
        /// 峰前伸算法
        /// </summary>
        /// <param name="PeakList">峰对象列表</param>
        /// <param name="PeakNum">目标峰索引</param>
        /// <param name="xunit">数据横坐标（时间坐标）的步进值</param>
        public static string LeadPeak(List<Peak> PeakList, int PeakNum)
        {
            if (PeakNum < 0 || PeakNum >= PeakList.Count) return "";
            if (PeakList[PeakNum].StartPoint.Equals(PeakList[PeakNum].StartBaseLine) || (PeakList[PeakNum].ProtractList != null && PeakList[PeakNum].ProtractList.Count!=0))
            {
                return "";
            }
            string rs = "";
            int Swpindex = StaticMethods.MatchBaseLine(PeakList, PeakNum, true);//获得前向匹配索引
            if (Swpindex == -1) return rs;
            PeakList[PeakNum].ProtractList.Clear();
            List<PointF> lst = new List<PointF>();
            PointF EndP = new PointF(PeakList[PeakNum].StartPoint.X, PeakList[PeakNum].StartPoint.Y);
            List<Peak> midlist = new List<Peak>();
            for (int i = PeakNum - 1; i >= Swpindex; i--)
            {
                //if (PeakList[i].PeakState == Peak.PeakStates.ps_combine) continue;
                if (PeakList[i].PeakState != Peak.PeakStates.ps_natural) continue;

                FromatOperateResult(i, SetPeakProperty(PeakList[i], "PeakState", (object)PeakList[i].PeakState), ref rs);

                midlist.Insert(0, StaticMethods.DSerialObject(StaticMethods.SerialObject(PeakList[i])) as Peak);
                if (PeakList[i].ProtractList.Count > 0)
                    break;
            }
            BaseLine.BaseLineCalculator.SetBaseLine(midlist);
            for (int i = midlist.Count - 1; i >= 0; i--)
            {
                lst.Add(midlist[i].EndBaseLine);
                lst.Add(midlist[i].StartBaseLine);

            }
            if (lst.Count > 0)
            {
                FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "ProtractList", (object)lst), ref rs);
                if (PeakNum > 0)
                    FromatOperateResult(PeakNum - 1, SetPeakProperty(PeakList[PeakNum - 1], "BaseLineEnd", (object)true), ref rs);
            }
            return rs;
        }
        /// <summary>
        /// 手动改变峰起始点
        /// </summary>
        /// <param name="PeakList">峰对象列表</param>
        /// <param name="PeakNum">目标峰索引</param>
        /// <param name="XCoordinat">目标横坐标</param>
        public static string ChangeSEPoint(List<Peak> PeakList, int PeakNum, PointF pt, bool start)
        {
            if (PeakNum < 0 || PeakNum >= PeakList.Count || pt.IsEmpty) return "";
            //if (PeakList[PeakNum].PeakState != Peak.PeakStates.ps_natural) return "";
            //if (start && PeakList[PeakNum].StartPoint.X.Equals(pt.X)) return "";
            //if (!start && PeakList[PeakNum].EndPoint.X.Equals(pt.X)) return "";

            Peak fpk = null;
            Peak bpk = null;
            string rs = "";
            Peak peak = PeakList[PeakNum];
            if (start)
            {
                //当前峰的峰高点
                if (pt.X > peak.PeakPoint.X) return "";
                if (PeakNum > 0) fpk = PeakList[PeakNum - 1];
                if (fpk != null)
                {
                    //向前有效峰的终点
                    if (fpk.PeakState == Peak.PeakStates.ps_natural && pt.X < fpk.EndPoint.X)
                    {
                        rs = ChangeSEPoint(PeakList, fpk.Index, pt, false);
                        if (rs == "") return "";
                    }
                    //向前无效峰的起点
                    for (int i = fpk.Index; i >= 0; i--)
                    {
                        if (PeakList[i] == null || PeakList[i].PeakState == Peak.PeakStates.ps_natural)
                        {
                            if (pt.X < PeakList[i].EndPoint.X) return "";
                            break;
                        }
                        fpk = PeakList[i];
                    }
                    if (fpk.PeakState != Peak.PeakStates.ps_natural && pt.X < fpk.StartPoint.X) return "";
                }
            }
            else
            {
                //当前峰的峰高点
                if (pt.X < peak.PeakPoint.X) return "";
                if ((PeakNum + 1) < PeakList.Count) bpk = PeakList[PeakNum + 1];
                if (bpk != null)
                {
                    //随后有效峰的起点
                    if (bpk.PeakState == Peak.PeakStates.ps_natural && pt.X > bpk.StartPoint.X)
                    {
                        rs = ChangeSEPoint(PeakList, bpk.Index, pt, true);
                        if (rs == "") return "";
                    }
                    //随后无效峰的终点
                    for (int i = bpk.Index; i < PeakList.Count; i++)
                    {
                        if (PeakList[i] == null || PeakList[i].PeakState == Peak.PeakStates.ps_natural)
                        {
                            if (pt.X > PeakList[i].StartPoint.X) return "";
                            break;
                        }
                        bpk = PeakList[i];
                    }
                    if (bpk.PeakState != Peak.PeakStates.ps_natural && pt.X > bpk.EndPoint.X) return "";
                }
            }
            if (start)
            {
                if (PeakNum > 0)//备份前一个峰的拖尾数组并清零
                    FromatOperateResult(PeakNum - 1, SetPeakProperty(PeakList[PeakNum - 1], "TailingList", (object)new List<PointF>()), ref rs);//备份并清零拖尾数组
                FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "ProtractList", (object)new List<PointF>()), ref rs);//备份并清零前伸数组
                FromatOperateResult(PeakNum, SetPeakProperty(peak, "StartPoint", (object)pt), ref rs);
                //if (fpk != null && fpk.PeakState != Peak.PeakStates.ps_natural)
                //    FromatOperateResult(PeakNum - 1, SetPeakProperty(fpk, "EndPoint", (object)pt), ref rs);
                if (PeakNum>=0 && PeakList[PeakNum - 1].PeakState != Peak.PeakStates.ps_natural &&
                    (PeakList[PeakNum - 1].EndPoint.X < PeakList[PeakNum].StartPoint.X || PeakList[PeakNum - 1].StartPoint.X < PeakList[PeakNum].StartPoint.X))
                    FromatOperateResult(PeakNum - 1, SetPeakProperty(PeakList[PeakNum - 1], "EndPoint", (object)PeakList[PeakNum].StartPoint), ref rs);
            }
            else
            {
                if (PeakNum < PeakList.Count - 1)//备份后一个峰的前伸数组并清零
                    FromatOperateResult(PeakNum + 1, SetPeakProperty(PeakList[PeakNum + 1], "ProtractList", (object)new List<PointF>()), ref rs);//备份并清零前伸数组
                FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "TailingList", (object)new List<PointF>()), ref rs);//备份并清零拖尾数组

                FromatOperateResult(PeakNum, SetPeakProperty(peak, "EndPoint", (object)pt), ref rs);
                //if (bpk != null && bpk.PeakState != Peak.PeakStates.ps_natural)
                //    FromatOperateResult(PeakNum + 1, SetPeakProperty(bpk, "StartPoint", (object)pt), ref rs);
                if ((PeakNum+1) <PeakList.Count && PeakList[PeakNum + 1].PeakState != Peak.PeakStates.ps_natural &&
                    (PeakList[PeakNum + 1].StartPoint.X > PeakList[PeakNum].EndPoint.X || PeakList[PeakNum + 1].EndPoint.X > PeakList[PeakNum].EndPoint.X))
                    FromatOperateResult(PeakNum + 1, SetPeakProperty(PeakList[PeakNum + 1], "StartPoint", (object)PeakList[PeakNum].EndPoint), ref rs);
            }

            return rs;//手动调整后去掉拖尾和前伸的结果
        }

        /// <summary>
        /// 将中间峰增加为真实峰
        /// </summary>
        /// <param name="PeakList"></param>
        /// <param name="PeakNum"></param>
        public static string AddPeak(List<Peak> PeakList, int PeakNum)
        {
            string rs = "";

            if (PeakList[PeakNum].PeakState == Peak.PeakStates.ps_noise || PeakList[PeakNum].PeakState == Peak.PeakStates.ps_hide)
            {
                FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "PeakState", (object)Peak.PeakStates.ps_natural), ref rs);
            }
            return rs;

        }
        /// <summary>
        /// 将真实峰判断为中间峰，无效峰
        /// </summary>
        /// <param name="PeakList"></param>
        /// <param name="PeakNum"></param>
        public static string DelPeak(List<Peak> PeakList, int PeakNum)
        {
            string rs = "";

            if (PeakList[PeakNum].PeakState == Peak.PeakStates.ps_natural)
                FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "PeakState", (object)Peak.PeakStates.ps_hide), ref rs);
            return rs;
        }
        /// <summary>
        /// 将真实峰判断为直线
        /// </summary>
        /// <param name="PeakList"></param>
        /// <param name="PeakNum"></param>
        public static string CancelPeak(List<Peak> PeakList, int PeakNum)
        {
            string rs = "";
            FromatOperateResult(PeakNum, SetPeakProperty(PeakList[PeakNum], "PeakState", (object)Peak.PeakStates.ps_delete), ref rs);
            return rs;
        }


        #endregion

        #region Private functions

        /// <summary>
        /// 获得子列表
        /// </summary>
        /// <param name="PeakList">源数据列表</param>
        /// <param name="StartPeakNum">开始索引</param>
        /// <param name="EndPeakNum">截止索引</param>
        /// <returns></returns>
        private static List<Peak> GetSubPeakList(List<Peak> PeakList, int StartPeakNum, int EndPeakNum)
        {
            List<Peak> Swplist = new List<Peak>();//交换子列表定义

            for (int i = StartPeakNum; i <= EndPeakNum; i++)//得到前向子列表
            {
                Peak swppeak = new Peak();
                swppeak = StaticMethods.DSerialObject(StaticMethods.SerialObject(PeakList[i])) as Peak;
                Swplist.Add(swppeak);
            }

            return Swplist;
        }

        /// <summary>
        /// 更新数据列表：用源数据列表，更新目标数据列表，安照目标数据列表的索引进行更新
        /// </summary>
        /// <param name="SourcePeakList">源数据列表</param>
        /// <param name="TargetPeakList">目标数据列表</param>
        /// <param name="StartPeakNum">起始索引</param>
        private static void RefreshList(List<Peak> SourcePeakList, List<Peak> TargetPeakList, int StartPeakNum)
        {

            for (int i = StartPeakNum; i < SourcePeakList.Count; i++)
            {
                Peak swppeak = new Peak();
                swppeak = StaticMethods.DSerialObject(StaticMethods.SerialObject(SourcePeakList[i - StartPeakNum])) as Peak;
                TargetPeakList.RemoveAt(i);
                TargetPeakList.Insert(i, swppeak);
            }

        }

        /// <summary>
        /// 设置峰参数,并且返回设置前的参数值，格式为：“属性名称=属性值；”
        /// </summary>
        /// <param name="peak">当前峰</param>
        /// <param name="propname">属性名</param>
        /// <param name="value">属性值</param>
        /// <returns></returns>
        private static string SetPeakProperty(Peak peak, string propname, object value)
        {
            string rs = null;
            if (peak == null) return "";
            PropertyInfo pinf = peak.GetType().GetProperty(propname);
            if (pinf == null) return "";
            rs += propname + "=" + StaticMethods.SerialObject(pinf.GetValue(peak, null)) + ";";
            pinf.SetValue(peak, value, null);
            return rs;
        }
        /// <summary>
        /// 格式化操作结果：在rs的基础上，加上峰索引和冒号并直接修改operates字符串
        /// </summary>
        /// <param name="peakindex">峰索引</param>
        /// <param name="rs">操作结果</param>
        /// <returns></returns>
        private static void FromatOperateResult(int peakindex, string rs, ref string operates)
        {
            if (rs.Trim() == "") return;
            operates.Trim();
            operates += peakindex.ToString() + ":" + rs;
        }

        /// <summary>
        /// 获取下一个有效峰
        /// </summary>
        /// <param name="PeakList"></param>
        /// <param name="PeakNum"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        private static int GetNextNatural(List<Peak> PeakList, int StartIndex)
        {
            for (int i = StartIndex + 1; i < PeakList.Count; i++)
            {
                if (PeakList[i].BaseLineEnd && i != (StartIndex + 1)) break;
                if (PeakList[i].PeakState != Peak.PeakStates.ps_natural) continue;
                return i;
            }
            return -1;
        }
        #endregion
    }
}
