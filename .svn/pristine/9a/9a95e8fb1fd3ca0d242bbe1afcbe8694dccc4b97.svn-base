//===============================================================
// Copyright (C) 2010-2020 皖仪科技研发中心
// 文件名: DistingGuishFD.cs
// 日期：2013-10-12
// 描述：输入数据位抽样过后的一阶导数数据，根据一阶导数数据进行判峰
// 版本：1.00
//
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
//
//==============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace Wayee.PeakLocation
{
    /// <summary>
    /// 判峰器基类，派生所有判峰算法和管理器相关类
    /// </summary>
    public class CLocationBase:IPeakLocation
    {
        /// <summary>
        /// 
        /// </summary>
        public CLocationBase()
        { 
        
        }
        /// <summary>
        /// construct
        /// </summary>
        /// <param name="arges"></param>
        public CLocationBase(PeakLocationArgs arges)
        {
            if (arges != null)
                this.PeakLocationParam = arges;
        }

        #region interface
        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {
            return;
        }
        /// <summary>
        /// 判峰操作
        /// </summary>
        /// <returns></returns>
        public virtual bool Execute()
        {
            return true;
        }

       
        #endregion

        #region Parameters

        protected PeakFoundEvent.PeakLocationEventHandler _Onfoundpeak;
        /// <summary>
        /// 实现接口，找到峰事件
        /// </summary>
        public event PeakFoundEvent.PeakLocationEventHandler OnPeakFound
        {
            add
            {
                _Onfoundpeak = null;
                _Onfoundpeak += value;
            }
            remove
            {
                _Onfoundpeak = null;
            }
        }

        PeakLocationArgs _PeakLocationArgs = new PeakLocationArgs ();
        /// <summary>
        /// 内部判峰参数:需要通过DistinguishedArges传入外部数据，注意增加参数时，同时更新DistinguishedArges内容
        /// </summary>
        public  PeakLocationArgs PeakLocationParam
        {
            get { return _PeakLocationArgs; }
            set { _PeakLocationArgs = value; }
        }

        #region OLD_CODE
        //private LocationArgs _distinguishedArges = new LocationArgs ();
        ///// <summary>
        ///// 判峰参数需要同步更新内部判峰参数
        ///// 注意：增加外部参数时，同时更新DistinguishedArges内容
        ///// </summary>
        //public LocationArgs LocationParam
        //{
        //    get { return _distinguishedArges; }
        //    set 
        //    { 
        //        _distinguishedArges = value;
        //        if (_distinguishedArges == null) return;
        //        this.PeakLocationParam.EndSLope = _distinguishedArges.EndSLope;
        //        this.PeakLocationParam.StartSLope = _distinguishedArges.StartSLope;
        //        this.PeakLocationParam.SourceData = _distinguishedArges.SourceData;
        //        this.PeakLocationParam.MinimumWidth = _distinguishedArges.MinimumWidth;
        //        this.PeakLocationParam.BaseLineNoiseAmplitude = _distinguishedArges.BaseLineNoiseAmplitude;
        //        this.PeakLocationParam.SampleInterval = _distinguishedArges.SampleInterval;
        //        this.PeakLocationParam.Resolution = _distinguishedArges.Resolution;
        //        this._distinguishedParameters.SDNoiseAmplitude = _distinguishedArges.SDNoiseAmplitude;
        //        this._distinguishedParameters.LocationType = _distinguishedArges.LocationType;
        //        this._distinguishedParameters.TimeSpan = _distinguishedArges.TimeSpan;
        //    }
        //}
        #endregion

        #endregion
    }
}
