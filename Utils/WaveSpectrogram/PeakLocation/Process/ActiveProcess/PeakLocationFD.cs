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
using System.Drawing;
using System.Threading;

namespace Wayee.PeakLocation
{
    /// <summary>
    /// 一阶导数的判峰状态
    /// </summary>
    enum CheckStage : int
    {
        StartPointChecked = 1,
        PeakPointChecked = 2,
        EndPointChecked = 3,

    }

    /// <summary>
    /// 一阶导数的判峰算法
    /// </summary>
    class CPeakLocationFD : CLocationBase
    {
        #region Define
        /// <summary>
        /// 程序状态标志
        /// </summary>
        private CheckStage _mState = CheckStage.StartPointChecked;
        /// <summary>
        /// 找到峰事件中的传递的参数
        /// </summary>
        private PeakArgs _mPeak = new PeakArgs();
        /// <summary>
        /// 判峰窗口宽度
        /// </summary>
        private int _mWindowSize = 3;
        #endregion

        #region constructor
        /// <summary>
        /// 构造函数，以特定的窗口长度实例化对象
        /// </summary>
        /// <param name="args">判峰参数</param>
        public CPeakLocationFD(PeakLocationArgs args)
            : base(args)
        {

        }

        #endregion

        #region MainMethod

        /// <summary>
        /// 判峰执行
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            Init();

            if (this.PeakLocationParam == null) return false;
            if (this.PeakLocationParam.First_Order_Derivative == null) return false;
            if (this.PeakLocationParam.First_Order_Derivative.Length < _mWindowSize) return false;

            for (int i = 0; i < this.PeakLocationParam.First_Order_Derivative.Length - _mWindowSize + 1; i++)
            {
                CheckPeak(this.PeakLocationParam.First_Order_Derivative, i);
            }

            if (_mState == CheckStage.EndPointChecked)
            {
                _mPeak.EndPoint = this.PeakLocationParam.First_Order_Derivative[this.PeakLocationParam.First_Order_Derivative.Length - 1];

                if (_Onfoundpeak != null)
                {
                    PeakArgs _new_peak = CopyPeak(_mPeak);
                    if (_new_peak != null)
                    {
                        _Onfoundpeak(this, _new_peak);//触发事件，读取峰数据
                    }
                }

                _mState = CheckStage.StartPointChecked;
            }

            return true;
        }
        /// <summary>
        /// 清空历史数据
        /// </summary>
        public override void Init()
        {
            _mState = CheckStage.StartPointChecked;
            _mPeak = new PeakArgs();
        }

        /// <summary>
        /// 进行峰判别
        /// </summary>
        /// <param name="fd_data">输入数据</param>
        /// <param name="index"></param>
        /// <returns>检测到峰的标志：检测到峰后返回true，否则返回false</returns>
        protected virtual bool CheckPeak(PointF[] fd_data, int index)
        {
            switch (_mState)
            {
                case CheckStage.StartPointChecked:
                    _mState = CheckStartingPoint(fd_data, index);
                    if (_mState != CheckStage.PeakPointChecked) break;
                    _mPeak.StartPoint = fd_data[index + 0];
                    break;

                case CheckStage.PeakPointChecked:
                    _mState = CheckPeakPoint(fd_data, index);
                    if (_mState != CheckStage.EndPointChecked) break;
                    _mPeak.PeakPoint = fd_data[index + 1];
                    break;

                case CheckStage.EndPointChecked:
                    _mState = CheckEndingPoint(fd_data, index);
                    if (_mState != CheckStage.StartPointChecked) break;
                    _mPeak.EndPoint = fd_data[index + 2];

                    if (_Onfoundpeak == null) break;

                    PeakArgs _new_peak = CopyPeak(_mPeak);
                    if (_new_peak == null) break;
                    _Onfoundpeak(this, _new_peak);//触发事件，读取峰数据
                    break;
            }
            return true;
        }

        #endregion

        #region PrivateSupportMethods

        /// <summary>
        ///  峰起始位置判断
        /// </summary>
        /// <param name="DiffBuf">输入一阶微分数组</param>
        /// <param name="GatePro">事先设定好的起始位置标志的门限阈值</param>
        /// <returns>返回程序所处的阶段标志：1 表示处于判断起始位置阶段；2 表示起始位置判断结束，进入第二阶段，判断前拐点</returns>
        private CheckStage CheckStartingPoint(PointF[] fd_data, int index)
        {
            float val1 = fd_data[index + 0].Y;
            float val2 = fd_data[index + 1].Y;
            float val3 = fd_data[index + 2].Y;

            if (val1 > PeakLocationParam.StartSLope && val2 > val1 && val3 > val2)
                return CheckStage.PeakPointChecked;
            else
                return CheckStage.StartPointChecked;
        }

        /// <summary>
        /// 判峰函数,同时判定是否有前剑锋和峰顶
        /// </summary>
        /// <param name="DiffBuf">输入一阶微分数据</param>
        /// <param name="GatePro">判峰门限</param>
        /// <returns>返回程序所处的阶段：2 有肩峰；4 检测到峰顶；3 继续检测峰顶</returns>
        private CheckStage CheckPeakPoint(PointF[] fd_data, int index)
        {
            float val1 = fd_data[index + 0].Y;
            float val2 = fd_data[index + 1].Y;
            float val3 = fd_data[index + 2].Y;

            if (val1 > 0 && val3 < 0)
                return CheckStage.EndPointChecked;
            else
                return CheckStage.PeakPointChecked;
        }

        /// <summary>
        /// 终点判别，同时判断重叠峰谷点，后肩峰
        /// </summary>
        /// <param name="DiffBuf">输入一阶微分数据</param>
        /// <param name="SourceBuf">输入原始数据</param>
        /// <param name="GatePro">预设门限阈值</param>
        /// <returns>返回程序所处的阶段：1 检测到终点，本次峰判断结束；2 检测到重叠峰的谷点；4 检测到后峰肩；5 本次未能检测到终点，继续检测</returns>
        private CheckStage CheckEndingPoint(PointF[] fd_data, int index)
        {
            float val1 = fd_data[index + 0].Y;
            float val2 = fd_data[index + 1].Y;
            float val3 = fd_data[index + 2].Y;

            if (val3 > PeakLocationParam.EndSLope && val3 > val2 && val2 > val1)
                return CheckStage.StartPointChecked;//找到峰
            else
                return CheckStage.EndPointChecked;//继续找峰终点
        }
        /// <summary>
        /// 复制峰对象
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private PeakArgs CopyPeak(PeakArgs peak)
        {
            if (peak == null) return null;
            PeakArgs _new_peak = new PeakArgs();

            _new_peak.StartPoint = new PointF(peak.StartPoint.X, peak.StartPoint.Y);
            _new_peak.PeakPoint = new PointF(peak.PeakPoint.X, peak.PeakPoint.Y);
            _new_peak.EndPoint = new PointF(peak.EndPoint.X, peak.EndPoint.Y);

            return _new_peak;
        }
        #endregion
    }
}
