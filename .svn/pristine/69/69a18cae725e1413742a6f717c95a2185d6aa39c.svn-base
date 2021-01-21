//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: DistinguishedManager.cs
// 日期：2012/10/18
// 描述：判峰算法管理器
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
// 
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wayee.Filter;
using System.Drawing;

namespace Wayee.PeakLocation
{
    /// <summary>
    /// 判峰算法类型
    /// </summary>
    public enum LocationType
    { 
        /// <summary>
        /// 传统积分，没有二阶导数参与，最后合并到峰谷
        /// </summary>
        TraditionWithMerging,
        /// <summary>
        /// 传统积分，没有二阶导数参与，最后不合并到峰谷,噪声阈值，最小峰宽失效
        /// </summary>
        TraditionWithoutMerging,
        /// <summary>
        /// 一阶二阶混合判峰算法，最后合并到峰谷
        /// </summary>
        AdvancedWithMerging,
        /// <summary>
        /// 一阶二阶混合判峰算法，最后不合并到峰谷,噪声阈值，最小峰宽失效
        /// </summary>
        AdvancedWithoutMerging,

    }
    /// <summary>
    /// 判峰管理器
    /// </summary>
    public class PeakLocationManager : CLocationBase
    {

        private PeakLocationFactory _processFactory = new ActiveProcessorFactory();
        /// <summary>
        /// 判峰器管理器：根据判峰类型管理判峰器
        /// 默认值为本模块提供的算法管理器
        /// </summary>
        public PeakLocationFactory ProcessFactory
        {
            get { return _processFactory; }
            set { _processFactory = value; }
        }


        /// <summary>
        /// 执行判峰
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            if (this.ProcessFactory == null) return false;
            CLocationBase _activeProcess = this.ProcessFactory.CreateProcessor(this.PeakLocationParam.LocationType);

            if (_activeProcess == null) return false;
            _activeProcess.PeakLocationParam = this.PeakLocationParam;
            _activeProcess.OnPeakFound += new PeakFoundEvent.PeakLocationEventHandler(OnPeakOut);
            _activeProcess.Execute();
            
            this.PeakLocationParam = _activeProcess.PeakLocationParam;//用于返回处理中间结果：一阶二阶导数抽样数据原始滤波数据等
            
            return true;
        }

        /// <summary>
        /// 峰传出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPeakOut(object sender, PeakArgs e)
        {
            if (this._Onfoundpeak == null) return;
            if (e == null) return;
            this._Onfoundpeak(this, e);
        }
    }
    /// <summary>
    /// 判峰器管理工厂：根据判峰类型管理判峰器
    /// </summary>
    public abstract class PeakLocationFactory
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public virtual CLocationBase CreateProcessor(LocationType type)
        {
            return null;
        }
    }

    /// <summary>
    /// 具体管理器工厂：根据判峰类型管理判峰器
    /// </summary>
    class ActiveProcessorFactory : PeakLocationFactory
    {
        /// <summary>
        /// 
        /// </summary>
        private static CPeakLocationBase _TraditionMethodWithMerging = null;

        /// <summary>
        /// 
        /// </summary>
        private static CPeakLocationBase _TraditionMethodWithoutMerging = null;

        /// <summary>
        /// 
        /// </summary>
        private static CPeakLocationBase _AdvancedMethodWithMerging = null;
        /// <summary>
        /// 
        /// </summary>
        private static CPeakLocationBase _AdvancedMethodWithoutMerging = null;

        /// <summary>
        /// 创建处理器
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override CLocationBase CreateProcessor(LocationType type)
        {
            switch (type)
            {
                case LocationType.TraditionWithMerging:
                    if (_TraditionMethodWithMerging != null) return _TraditionMethodWithMerging;
                    _TraditionMethodWithMerging = new PeakLocationTraditionWithMerging();
                    return _TraditionMethodWithMerging;

                case LocationType.TraditionWithoutMerging:
                    if (_TraditionMethodWithoutMerging != null) return _TraditionMethodWithoutMerging;
                    _TraditionMethodWithoutMerging = new PeakLocationTraditionWithoutMerging();
                    return _TraditionMethodWithoutMerging;

                case LocationType.AdvancedWithMerging:
                    if (_AdvancedMethodWithMerging != null) return _AdvancedMethodWithMerging;
                    _AdvancedMethodWithMerging = new PeakLocationAdvancedWithMegring();
                    return _AdvancedMethodWithMerging;
                
                case LocationType.AdvancedWithoutMerging:
                    if (_AdvancedMethodWithoutMerging != null) return _AdvancedMethodWithoutMerging;
                    _AdvancedMethodWithoutMerging = new PeakLocationAdvancedWithoutMerging();
                    return _AdvancedMethodWithoutMerging;
                
                default:
                    return null;
            }
        }

    }
}
