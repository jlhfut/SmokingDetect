using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Wayee.WaveSpectrogram
{
    class DataHelper
    {
        #region defined
        private List<PointF> _list = new List<PointF>();
        #endregion

        #region properties
        /// <summary>
        /// 获取当前数据点总数
        /// </summary>
        public int Count
        {
            get { return _list.Count; }
        }
        /// <summary>
        /// 获取点集
        /// </summary>
        public List<PointF> List
        {
            get { return _list; }
            set { _list = value; }
        }
        private List<List<PointF>> _grouplist = null;
        /// <summary>
        /// 集合点集
        /// </summary>
        public List<List<PointF>> GroupList
        {
            get { return _grouplist; }
            set { _grouplist = value; }
        }
        private PointF _ylimitvalue = PointF.Empty; //new PointF();
        /// <summary>
        /// y轴最大/最小值
        /// </summary>
        public PointF YLimitValue
        {
            get { return _ylimitvalue; }
            set { _ylimitvalue = value; }
        }
        private PointF _xlimitvalue = PointF.Empty;
        /// <summary>
        /// x轴最大/最小值
        /// </summary>
        public PointF XLimitValue
        {
            get 
            {
                if (Count > 0)
                {
                    _xlimitvalue.X = _list.Min(pt => pt.X);
                    _xlimitvalue.Y = _list.Max(pt => pt.X);
                    //if (_list[0].X < _list[Count - 1].X)
                    //{
                    //    _xlimitvalue.X = _list[0].X;
                    //    _xlimitvalue.Y = _list[Count - 1].X;
                    //}
                    //else
                    //{
                    //    _xlimitvalue.Y = _list[0].X;
                    //    _xlimitvalue.X = _list[Count - 1].X;
                    //}
                }
                return _xlimitvalue; 
            }
            set { _xlimitvalue = value; }
        }

        private DataUnitDescription _DataUnit = null;
        /// <summary>
        /// 数据单位
        /// </summary>
        public DataUnitDescription DataUnit
        {
            get { return _DataUnit; }
            set { _DataUnit = value; }
        }
        #endregion

        #region public function
        /// <summary>
        /// 加入数据点
        /// </summary>
        /// <param name="pt"></param>
        /// <returns>当前数据点索引</returns>
        public int AddPoint(PointF pt)
        {
            try
            {
                _list.Add(pt);
                if (_ylimitvalue.IsEmpty)
                {
                    _ylimitvalue.X = pt.Y;
                    _ylimitvalue.Y = pt.Y;
                }
                if (pt.Y < _ylimitvalue.X)
                    _ylimitvalue.X = pt.Y;
                if (pt.Y > _ylimitvalue.Y)
                    _ylimitvalue.Y = pt.Y;
                return Count - 1;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return -1;
            }
        }
        /// <summary>
        /// 获取数据点集
        /// </summary>
        /// <param name="index">起始点索引</param>
        /// <returns>点集,失败返回null</returns>
        public PointF[] GetPoints(int index)
        {
            return GetPoints(index, index);
        }
        /// <summary>
        /// 获取数据点集
        /// </summary>
        /// <param name="index">起始点索引</param>
        /// <param name="max">终点索引</param>
        /// <returns>点集,失败返回null</returns>
        public PointF[] GetPoints(int index, int end)
        {
            if (index > end)
                return null;
            if (index < 0 || index >= Count || end>=Count)
                return null;
            //List<PointF> lst = new List<PointF>();           
            //for (int i = index; i <= end; i++)
            //    lst.Add(_list[i]);
            int max = end - index + 1;
            if (max <= 0) max = 1;
            if (max > Count) max = Count;
            return _list.GetRange(index, max).ToArray();
        }
        /// <summary>
        /// 获取x轴相应区域数据点集
        /// </summary>
        /// <param name="xmin">x轴起始数据点值</param>
        /// <param name="xmax">x轴终止数据点值</param>
        /// <returns></returns>
        public PointF[] GetPoints(float xmin, float xmax)
        {
            if (Count == 0)
                return null;
            //20140612zhangrongzhou
            //解决全屏时无法获取全部数据集的问题
            if (xmin == 0f && xmax >= _list[Count - 1].X) return _list.ToArray();
            //20140612

            int start = -1;
            int end = -1;
            bool bsucc = GetIndex(xmin, xmax, out start, out end);
            if (bsucc == false && (end < 0 || end >= Count))// || end<start))
                return null;
            //2012-02-04
            return GetPoints(start, end);
        }
        /// <summary>
        /// 根据x轴值获取y轴值
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public PointF GetPoint(float x)
        {
            if (Count == 0)
                return PointF.Empty;
            int index = 0;
            bool bsucc = DichotomySearch(x,1, out index);
            if (bsucc) return _list[index];
            return PointF.Empty;
        }
        /// <summary>
        /// 获取点集中Y坐标最大、小值点
        /// </summary>
        /// <param name="pts"></param>
        /// <returns></returns>
        public PointF[] GetPoints(PointF[] pts)
        {
            PointF[] pt = new PointF[2] { PointF.Empty, PointF.Empty };
            if (pts == null || pts.Length < 2)
                return pt;
            var values = from p in pts
                         //where
                         orderby p.Y descending
                         select p;
            if (values == null) return pt;

            pt[0] = values.ToArray()[0];
            pt[1] = values.ToArray()[pts.Length - 1];
            return pt;
        }
        ///// <summary>
        ///// 获取点集中Y坐标最大值点
        ///// </summary>
        ///// <param name="pts">点集</param>
        ///// <returns></returns>
        //public PointF GetMaxPoint(PointF[] pts)
        //{
        //    if (pts == null || pts.Length == 0)
        //        return PointF.Empty;
        //    var values = from pt in pts
        //                 //where
        //                 orderby pt.Y descending
        //                 select pt;
        //    if (values == null) return PointF.Empty;
        //    return values.ToArray()[0];
        //}

        ///// <summary>
        ///// 获取点集中Y坐标最小值点
        ///// </summary>
        ///// <param name="pts">点集</param>
        ///// <returns></returns>
        //public PointF GetMinPoint(PointF[] pts)
        //{
        //    if (pts == null || pts.Length == 0)
        //        return PointF.Empty;
        //    var values = from pt in pts
        //                 //where
        //                 orderby pt.Y descending
        //                 select pt;
        //    if (values == null) return PointF.Empty;
        //    return values.ToArray()[pts.Length - 1];
        //}
        /// <summary>
        /// 反转点集以基点为准
        /// </summary>
        /// <param name="start">点集的开始索引</param>
        /// <param name="end">点集的结束索引</param>
        /// <returns></returns>
        public bool ReversalPoints(float xmin, float xmax)
        {
            int start = -1;
            int end = -1;
            bool bsucc = GetIndex(xmin, xmax, out start, out end);
            if (bsucc == false && (end < 0 || end >= Count))// || end<start))
                return false;
            float basepoint = _list[start].Y;
            float tg = Math.Abs(_list[start].Y - _list[end].Y) / Math.Abs(_list[start].X - _list[end].X);
            float y = 0;
            int sign = (_list[start].Y > _list[end].Y ? 1 : -1);

            for (int i = start; i < end; i++)
            {
                y=basepoint-2*sign*Math.Abs(tg* (_list[i].X - _list[start].X));
                _list[i] = new PointF(_list[i].X,y- (_list[i].Y-basepoint));
            }
            return true;
        }
        /// <summary>
        /// 清除点集数据
        /// </summary>
        public void Flush()
        {
            _list.Clear();
            _list = new List<PointF>();
            _grouplist = null;
            _ylimitvalue = new PointF(0, 0);
            _DataUnit = null;
        }
        /// <summary>
        /// 对象序列化
        /// </summary>
        /// <param name="stream">序列化到流对象</param>
        /// <param name="format"></param>
        public void Serialize(ref MemoryStream stream)
        {
            BinaryFormatter format = new BinaryFormatter();
            _list.Add(YLimitValue);
            StringBuilder value = new StringBuilder();
            for (int i = 0; i < _list.Count; i++)
                value.Append( _list[i].X.ToString()+","+_list[i].Y.ToString()+";");

            if (DataUnit != null)
            {
                string dunit = DataUnitDescription.Serialize(DataUnit);
                value.Append(dunit + ";");
            }

            format.Serialize(stream, value);
            //format.Serialize(stream, _list);
            _list.RemoveAt(_list.Count - 1);
        }
        /// <summary>
        /// 对象反序列化
        /// </summary>
        /// <param name="stream">从流对象反序列化</param>
        public void Deserialize(MemoryStream stream)
        {
            try
            {
                BinaryFormatter format = new BinaryFormatter();
                try
                {                    
                    stream.Position = 0;
                    StringBuilder value = (StringBuilder)format.Deserialize(stream);
                    string[] pts = value.ToString().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    string[] pt = new string[2];
                    int count=pts.GetLength(0);

                    DataUnitDescription dud=DataUnitDescription.Deserialize(pts[count-1]);
                    if (dud != null)
                    {
                        DataUnit = dud;
                        count--;
                    }

                    for (int i = 0; i < count; i++)
                    {
                        pt = pts[i].Split(',');
                        _list.Add(new PointF(float.Parse(pt[0]), float.Parse(pt[1])));
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError(ex);
                    stream.Position = 0;
                    _list = (List<PointF>)format.Deserialize(stream);
                }
                _ylimitvalue = _list[_list.Count - 1];
                _list.RemoveAt(_list.Count - 1);
            }
            catch(Exception ex)
            {
                LogHelper.WriteError(ex);
            }
        }
        #endregion

        #region private function
        /// <summary>
        /// 获取点集的起止索引
        /// </summary>
        /// <param name="xmin"></param>
        /// <param name="xmax"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private bool GetIndex(float xmin, float xmax,out int start,out int end)
        {
            start = -1;
            end = -1;
            bool bsucc = DichotomySearch(Math.Ceiling(xmin), out start);
            if (bsucc == false && (start < 0 || start >= Count))
                return false;
            //int end = 0;
            bsucc = DichotomySearch(Math.Floor(xmax), out end);
            //2012-02-04 保证不会返回空集
            if (end < start)
            {
                int tmp = start;
                start = end;
                end = tmp;
            }
            return true;
        }
        /// <summary>
        /// 二分法查找数据
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool DichotomySearch(double value, out int index)
        {
            return DichotomySearch(value, 5, out index);
        }
        /// <summary>
        /// 二分法查找数据
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool DichotomySearch(double value, int digits, out int index)
        {
            int low = 0;
            int high = Count - 1;
            int middle =0;
            bool bend = false;
            while (low <= high && !bend)
            {
                middle = (low + high) / 2;
                switch (Math.Round(value, digits).CompareTo(Math.Round(_list[middle].X, digits)))
                {
                    case 0:
                        bend = true;
                        break;
                    case 1:
                        low = middle + 1;
                        break;
                    case -1:
                        high = middle - 1;
                        break;
                }
                //if ((int)value == _list[middle].X.CompareTo)
                //   break;
                //if ((int)value > (int)_list[middle].X)
                //    low = middle + 1; 
                //else
                //    high = middle - 1;
            }
            index = middle;
            if (low <= high)
                return true;
            else
                return false;
        }
        #endregion

    }
}
