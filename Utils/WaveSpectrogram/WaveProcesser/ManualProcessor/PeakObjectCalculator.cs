using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeakObj = Wayee.PeakObject.Peak;//给峰对象类型起个别名
using Wayee.ManualProcessor;
namespace Wayee.ResultAnalyzer
{
    public class PeakObjectCalculator
    {

        private List<PeakObj> peakObjList = new List<PeakObj>();
        public List<PeakObj> PeakObjList
        {
            get { return peakObjList; }
            set { peakObjList = value; }
        }
        public void InitPeakObjList(List<PeakObj> objList)
        {
            this.peakObjList = objList;
        }

        #region 计算基线
        /// <summary>
        /// 基线计算器
        /// </summary>
        /// <param name="peakObj">峰对象列表</param>
        public static void BaseLineCalculator(List<PeakObj> peakObj)
        {
           
            
        }
        /// <summary>
        /// 遍历峰对象列表，找出谷点、起始点最小值列表
        /// </summary>
        /// <param name="peakObj">峰对象列表</param>
        /// <param name="start">起始点</param>
        /// <param name="end">终点</param>
        /// <param name="dList">较低点列表</param>
        private static void VisitObjListIterator(List<PeakObj> peakObj, int start, int end, List<int> dList)
        {

        }
        #endregion

    }
}

