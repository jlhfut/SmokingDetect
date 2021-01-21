using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Resources;
using Wayee.BaseLine;
using Wayee.ManualProcessor;
using Wayee.PeakObject;
using System.Windows.Forms;

namespace Wayee.WaveSpectrogram
{
    /// <summary>
    /// 峰管理器
    /// </summary>
    public class PeakHelper
    {
        #region defined
        /// <summary>
        /// 峰对象列表
        /// </summary>
        private List<Peak> _list = new List<Peak>();
        /// <summary>
        /// 禁判峰索引
        /// </summary>
        private int _interdictindex = -1;
        /// <summary>
        /// 手动增加峰开始
        /// </summary>
        private PointF _peakstart = PointF.Empty;
        #endregion

        #region init
        public PeakHelper()
        {
            try
            {
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
        }
        ~PeakHelper()
        {
            try
            {
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
        }
        #endregion

        #region proporties
        /// <summary>
        /// 获取或设置相应峰对象
        /// </summary>
        /// <param name="index"></param>
        public Peak this[int index]
        {
            get
            {
                if (index >= 0 && index < _list.Count)
                    return _list[index];
                else
                    return null;
            }
            set
            {
                if (index >= 0 && index < _list.Count)
                    _list[index] = value;
            }
        }
        /// <summary>
        /// 获取指定保留时间的峰对象
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public Peak this[float time]
        {
            get
            {
                for (int i = 0; i < _list.Count;i++ )
                {
                    if (_list[i].StartPoint.X < time && _list[i].EndPoint.X > time)
                        return _list[i];
                }
                return null;
            }
        }
        /// <summary>
        /// 获取指定区域中的峰列表
        /// </summary>
        /// <returns></returns>
        public List<Peak> Peaks
        {
            get { return _list;  }
        }
        private List<List<Peak>> _grouplist = null;
        /// <summary>
        /// 集合峰集
        /// </summary>
        public List<List<Peak>> GroupList
        {
            get { return _grouplist; }
            set { _grouplist = value; }
        }
        /// <summary>
        /// 获取当前峰数
        /// </summary>
        public int PeakCount
        {
            get 
            {
                return (_list == null ? -1 : _list.Count); 
            }
        }
        private Graph _parent = null;
        /// <summary>
        /// 父对象
        /// </summary>
        public Graph Parent
        {
            get { return _parent; }
            set 
            { 
                _parent = value;
            }
        }
        private int _activateindex = -1;
        /// <summary>
        /// 活动峰索引
        /// </summary>
        public int ActivateIndex
        {
            get { return _activateindex; }
            set 
            {
                _activateindex = value;
            }
        }
        /// <summary>
        /// 当前活动峰
        /// </summary>
        public Peak CurrentPeek
        {
            get
            {
                if (ActivateIndex >= _list.Count || ActivateIndex < 0) return null;
                return _list[ActivateIndex];
            }
        }
        /// <summary>
        /// 当前鼠标选中下方的峰
        /// </summary>
        public Peak SelectedPeak
        {
            get
            {
                Peak peak = CurrentPeek;
                if(peak==null && ActivateIndex<-1)
                    peak=this[Math.Abs(ActivateIndex+2)];
                return peak;
            }
        }
        
        #endregion

        #region public function
        /// <summary>
        /// 峰表序列化
        /// </summary>
        /// <param name="stream">序列化到流对象</param>
        /// <param name="format"></param>
        public void SerializePeaks(ref MemoryStream stream)
        {
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(stream, _list);
        }
        /// <summary>
        /// 峰表反序列化
        /// </summary>
        /// <param name="stream">从流对象反序列化</param>
        public void DeserializePeaks(MemoryStream stream)
        {
            BinaryFormatter format =new BinaryFormatter();
            _list = (List<Peak>)format.Deserialize(stream);
        }

        /// <summary>
        /// 增加峰对象
        /// </summary>
        /// <param name="peek"></param>
        /// <returns>失败返回-1,成功返回当前峰索引</returns>
        public int Add(Peak peek)
        {
            try
            {
                if (peek != null)
                {
                    _list.Add(peek);
                    return _list.Count - 1;
                }else
                   return -1;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return -1;
            }
        }
        /// <summary>
        /// 插入峰到列表
        /// </summary>
        /// <param name="index">插入位置</param>
        /// <param name="start">峰起点</param>
        /// <param name="top">峰顶点</param>
        /// <param name="end">峰终点</param>
        /// <returns></returns>
        public bool Insert(int index,PointF start,PointF top,PointF end ,Peak.PeakStates state)
        {
            try
            {
                if (_list != null)
                {
                    Peak pk = new Peak();
                    pk.StartPoint = start;
                    pk.EndPoint = end;
                    if (top == PointF.Empty)
                        pk.PeakPoint = Parent[Parent[pk]][0];
                    else
                        pk.PeakPoint = top;
                    pk.PeakState = state;
                    pk.Index = index;
                    _list.Insert(index, pk);

                    for (int i = index; i < _list.Count; i++)
                    {
                        _list[i].Index = i;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
        /// <summary>
        /// 删除指定峰
        /// </summary>
        /// <param name="index">当前峰索引</param>
        /// <returns></returns>
        public bool RemoveAt(int index)
        {
            try
            {
                if (index >= 0 && index < _list.Count)
                {
                    _list.RemoveAt(index);
                    return true;
                }else 
                    return false;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
        /// <summary>
        /// 清除所有峰
        /// </summary>
        /// <returns></returns>
        public bool Flush()
        {
            try
            {
                _list.Clear();
                _grouplist = null;
                ActivateIndex = -1;
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
        /// <summary>
        /// 获取指定区域中的峰列表
        /// </summary>
        /// <param name="start">峰起点</param>
        /// <param name="end">峰终点</param>
        /// <returns></returns>
        public List<Peak> GetPeaks(float start, float end)
        {
            try
            {
                List<Peak> lst=new List<Peak>();
                for (int i = 0; i < _list.Count; i++)
                {
                    if ((_list[i].StartPoint.X - start) >= 0.00001 || (_list[i].EndPoint.X - end) <= -0.00001)
                        lst.Add(_list[i]);
                    if ((_list[i].EndPoint.X - end) >= 0.00001) break; 
                }
                return lst;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return null;
            }
        }
        /// <summary>
        /// 获取当前鼠标下的峰对象
        /// </summary>
        /// <param name="mousepoint"></param>
        /// <returns></returns>
        public int GetPeakAtPoint(Point mousepoint)
        {
            try
            {
                int index=0;
                bool rs = GetPeakAtPoint(mousepoint, out index);
                if (!rs)
                    return -1;
                return index;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return -1;
            }
        }
        /// <summary>
        /// 获取当前索引峰前面的第一个有效峰
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public int FrontIndexOf(int index)
        {            
            try
            {
                for (int i = index - 1; i >= 0; i--)
                {
                    if (this[i].PeakState != Peak.PeakStates.ps_natural) continue;
                    if (this[i].BaseLineEnd) return -1;
                    return i;
                }
                return -1;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return -1;
            }
        }
        /// <summary>
        /// 获取当前索引峰后面第一个有效峰
        /// </summary>
        /// <param name="index">峰索引</param>
        /// <returns></returns>
        public int BackIndexOf(int index)
        {
            try
            {
                for (int i = index + 1; i <_list.Count; i++)
                {
                    if (this[i].PeakState == Peak.PeakStates.ps_natural) continue ;
                    if (this[i].BaseLineEnd) return -1;
                    return i;
                }
                return -1;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return -1;
            }
        }
        /// <summary>
        /// 获取当前鼠标下峰对象
        /// 2012-02-04加入，保证总是返回index（可能是近似值）
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool GetPeakAtPoint(Point mousepoint,out int index)
        {
            index = 0;
            try
            {
                bool rs=DichotomySearch(mousepoint, out index);
                if (!rs)
                    return false;
                //以下代码解决选取峰时，大峰优先处理的目的。(2011-07-21)
                else
                {
                    int i=0;
                    //向前搜索第一个峰，判断当前鼠标是否在其范围之内
                    for (i = index-1; i >= 0; i--)
                        if (_list[i].EndPoint.X >= mousepoint.X)
                        {
                            index = i;
                            return true;
                        }
                    //向后搜索第一个峰，判断当前鼠标是否在其范围之内
                    for (i = index+1; i < _list.Count; i++)
                        if (_list[i].PeakState!= Peak.PeakStates.ps_combine && _list[i].StartPoint.X < mousepoint.X)
                        {
                            index = i;
                            return true;
                        }
                }
                //
                //Peak peak=_list[index];
                //if ((peak.StartBaseLine.Y > mousepoint.Y || peak.StartBaseLine.Y > mousepoint.Y) || peak.PeakPoint.Y < mousepoint.Y) return -1;
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
        
        #endregion

        #region private function

        /// <summary>
        /// 通过模板设置峰组份名
        /// </summary>
        /// <param name="templatePeakList"></param>
        /// <param name="pk"></param>
        /// <returns></returns>
        private void DoPeakNameByTemplate(List<Peak> templatePeakList, TemplateOperateArgs arg)
        {
            Wayee.ResultAnalyzer.PeakIdentificationMethod pm = new Wayee.ResultAnalyzer.PeakIdentificationMethod();
            pm.TimeBand = arg.TimeBand;
            pm.Time_Method = Wayee.ResultAnalyzer.PeakIdentificationMethod.TimeMethod.tm_band;

            Wayee.ResultAnalyzer.CIdentificationFactory.Identify(templatePeakList, _list, pm);
        }        

        /// <summary>
        /// 匹配两个峰的相似性
        /// </summary>
        /// <param name="soc">原始峰</param>
        /// <param name="des">目标峰</param>
        /// <returns>-1:原始峰在目标峰的左肩,0:原始峰包含目标峰,1:原始峰在目标峰的右肩</returns>
        private int? DoMatchPeak(Peak soc, Peak des)
        {
            if (soc == null || des == null) return null;
            if (soc.EndPoint.X < des.PeakPoint.X) return -1;
            if (soc.StartPoint.X > des.PeakPoint.X) return 1;
            return 0;
        }
        /// <summary>
        /// 匹配下个峰
        /// </summary>
        /// <param name="time">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <returns></returns>
        private Peak DoMatchPrePeak(float time, float endtime)
        {
            Peak pk = null;
            float step = 1f;
            while (time <= endtime)
            {
                pk = this[endtime- step];
                if (pk != null) break;
                endtime -= step;
            }
            return pk;
        }
        /// <summary>
        /// 匹配下个峰
        /// </summary>
        /// <param name="time">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <returns></returns>
        private Peak DoMatchNextPeak(float time, float endtime)
        {
            Peak pk = null;
            float step = 1f;
            while (time <= endtime || (this[_list.Count - 1] != null && time <= this[_list.Count - 1].EndPoint.X))
            {
                pk = this[time + step];
                if (pk != null) break;
                time += step;
            }
            return pk;
        }
        
        /// <summary>
        /// 分离所有峰
        /// </summary>
        /// <returns></returns>
        private string SeparatePeak(int end)
        {
            int idx =Math.Abs( GetPeakIndex());
            string operates ="";
            string operate = "";
            _list[idx].BaseLineEnd = false;
            for (int i = idx; i <= end; i++)
            {
                //if (_list[i].BaseLineEnd) break;
                if (_list[i].PeakState == Peak.PeakStates.ps_natural)
                {
                    if (!_list[i].BaseLineEnd) operate = PeakProcessor.SeparatePeak(_list, i);
                    if (operate != "") operates += operate;
                    operate = BaselineCrossOperate(i);
                    if (operate != "") operates += operate;
                }
            }
            return operates;
        }

        /// <summary>
        /// 基线与峰相交处理
        /// 
        /// 保证基线不与峰上的点相交
        /// </summary>
        /// <returns></returns>
        private string BaselineCrossOperate(int index)
        {
            try
            {
                if (index < 0 || index >= _list.Count) return "";           
                bool negative = (this[index].PeakPoint.Y < this[index].StartPoint.Y && this[index].PeakPoint.Y < this[index].EndPoint.Y);
                if (negative) return "";

                string operates = "";
                string operate = "";
                PointF pt = PointF.Empty;
                //结束基线与峰相交
                if (_list[index].PeakState != Peak.PeakStates.ps_natural) return "";
                bool BaseLineStart = (FrontIndexOf(index) == -1);

                pt = GetStartBaselineCrossPoint(this[index],BaseLineStart);
                if (pt != PointF.Empty && !pt.Equals(this[index].StartPoint))
                    operates = PeakProcessor.ChangeSEPoint(_list, index, Parent[pt.X], true);
                pt = GetEndBaselineCrossPoint(this[index], BaseLineStart);
                if (pt != PointF.Empty && !pt.Equals(this[index].EndPoint))
                    operate = PeakProcessor.ChangeSEPoint(_list, index, Parent[pt.X], false);
                operates += operate;
                return operates;
            }
            catch
            {
                return "";
            }
        }
        
        /// <summary>
        /// 获取峰开始基线与峰相交点
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        private PointF GetStartBaselineCrossPoint(Peak pk,bool BaseLineStart)
        {
            List<PointF> lst = Parent[pk];
            if (lst == null) return PointF.Empty;

            float rs = 0f;
            PointF pt = (BaseLineStart ? pk.StartPoint : pk.StartBaseLine);
            PointF pt1 = pk.EndPoint;
            for (int i = 0; i < lst.Count - 1; i++)
            {
                if (lst[i].X >= pk.PeakPoint.X) break;
                //rs = (pk.EndPoint.X - pt.X) * (lst[i].Y - pt.Y) -
                //     (lst[i].X - pt.X) * (pk.EndPoint.Y - pt.Y);
                //if (rs < 0) pt = lst[i];
                rs = ((pt1.Y - pt.Y) / (pt1.X - pt.X)) * (lst[i].X - pt.X) + pt.Y;
                if (rs > lst[i].Y) pt = lst[i];
            }
            return pt;            
        }
        /// <summary>
        /// 获取峰结束基线与峰相交点
        /// 根据点到直线的距离确定
        /// 采用两点式直线方程，把给定的点的x值带入方程，求出y，如果y大于给定点的y值表示在直线下方。
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        private PointF GetEndBaselineCrossPoint(Peak pk,bool BaseLineStart)
        {
            List<PointF> lst = Parent[pk];
            if (lst == null) return PointF.Empty;
            float rs = 0f;
            PointF pt = pk.EndPoint;
            PointF pt1 = (BaseLineStart ? pk.StartPoint : pk.StartBaseLine);
            for (int i = lst.Count - 1; i > 0; i--)
            {
                if (lst[i].X <= pk.PeakPoint.X) break;
                //rs = (pt.X - pk.StartPoint.X) * (lst[i].Y - pk.StartPoint.Y) -
                //     (lst[i].X - pk.StartPoint.X) * (pt.Y - pk.StartPoint.Y);
                //if (rs < 0) pt = lst[i];
                rs = ((pt.Y - pt1.Y) / (pt.X - pt1.X)) * (lst[i].X - pt.X) + pt.Y;
                if (rs > lst[i].Y) pt = lst[i];
            }
            return pt;
        }

        /// <summary>
        /// 开始禁止判峰
        /// </summary>
        private string StartInterdictPeak()
        {
            int idx =Math.Abs( GetPeakIndex());
            string operates = "";
            string operate = "";

            if (SelectedPeak != null && SelectedPeak.PeakState == Peak.PeakStates.ps_noise)
            {
                operate = PeakProcessor.AddPeak(_list, idx);
                if (operate != "") operates += operate;
            }
            operate = BaselineCrossOperate(this.FrontIndexOf(idx));
            if (operate != "") operates += operate;
            operate = PeakProcessor.DisableCheckPeak(_list, idx);
            if (operate != "") operates += operate;
            _interdictindex = idx;
            return operates;
        }
        /// <summary>
        /// 结束禁止判峰
        /// </summary>
        private string EndInterdictPeak()
        {
            int idx =Math.Abs(GetPeakIndex());           
            string operate = "";
            string operates ="";
            operate = BaselineCrossOperate(this.BackIndexOf(idx));
            if (operate != "") operates += operate;
            for (int i = idx;i>=_interdictindex ; i--)
            {
                if (_interdictindex == -1) continue;
                if (_list[i].PeakState == Peak.PeakStates.ps_noise)
                {
                    operate = PeakProcessor.AddPeak(_list, i);
                    if (operate != "") operates += operate;
                }
                if (_list[i].PeakState == Peak.PeakStates.ps_natural)
                {
                    operate = PeakProcessor.DisableCheckPeak(_list, i);
                    if (operate != "") operates += operate;
                }
            }

            return operates;
        }
 
        /// <summary>
        /// 获得峰（忽略峰的状态）索引
        /// </summary>
        /// <returns></returns>
        private int GetPeakIndex()
        {
            int idx = ActivateIndex;
            if (idx < -1)
            {
                idx = Math.Abs(idx + 2);
                return -idx;
            }
            return idx;
        }
        /// <summary>
        /// 二分法查找数据
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool DichotomySearch(Point mousepoint, out int index)
        {
            if (_list.Count == 0)
            {
                index = 0;
                return false;
            }
            //处理鼠标超出峰前后范围
            if (mousepoint.X < 0)
            {
                index = 0;
                return true;
            }
            if (mousepoint.X > _list[_list.Count - 1].EndPoint.X)
            {
                index = _list.Count - 1;
                return true;
            }
            //
            int low = 0;
            int high = _list.Count - 1;
            int middle = 0;
            while (low <= high)
            {
                middle = (low + high) / 2;
                if (mousepoint.X >= (int)_list[middle].StartPoint.X && mousepoint.X <= (int)_list[middle].EndPoint.X)
                    break;
                if (mousepoint.X > (int)_list[middle].EndPoint.X)
                    low = middle + 1;
                else
                    high = middle - 1;

            }
            index = middle;
            if (low <= high)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 格式化浮点字符串
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string FormatFloatString(string text)
        {
            string rs = text;
            try
            {
                while (rs.IndexOf('.') != -1)
                {
                    if (rs.EndsWith("0") || rs.EndsWith("."))
                        rs = text.Substring(0, rs.Length - 1);
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return text;
            }
            return rs;
        }
 
        /// <summary>
        /// 获取峰描述
        /// </summary>
        /// <returns></returns>
        private string GetPeakString()
        {
            try
            {
                string rs = "[";
                rs += DateTime.Now.ToString() + " ] ";
                return rs;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return "";
            }
        }
        #endregion
    }
}