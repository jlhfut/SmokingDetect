﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.plugin;
using DevExpress.Utils.MVVM;
using Wayee.Services;
using DevExpress.XtraEditors;
using wayeal.os.exhaust.ViewModel;
using static wayeal.exdevice.DeviceCommViewModel;

namespace wayeal.exdevice
{
    public partial class ucAnalysisDevice : ucDeviceBase
    {
        private string cName = "Analysis";
        private MVVMContextFluentAPI<DeviceCommViewModel> fluent;
        public ucAnalysisDevice()
        {
            InitializeComponent();
            InitComboBox();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
            ResultDataViewModel.VM.UpdateDeviceCombx += new ComboboxEventHandler(InitComboBox);
        }
        public ucAnalysisDevice(object param)
        {
            InitializeComponent();
            Params = param;
            InitComboBox();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
            ResultDataViewModel.VM.UpdateDeviceCombx += new ComboboxEventHandler(InitComboBox);
        }
        private object _Params = null;
        public override object Params
        {
            get { return _Params; }
            set
            {
                _Params = value;
                if (_Params != null) cName = _Params.ToString();
                InitAnalysisInfo(cName);
            }
        }
        private void InitAnalysisInfo(string aName )
        {
            DeviceCommViewModel.VM.Execute(new List<Object> {
                DeviceCommViewModel.ExecuteCommand.ec_QueryDeviceInfo,
                (DeviceName)Enum.Parse(typeof(DeviceName),cName)
            });
        }
        protected override void InitializeBindings()
        {
            try
            {
                mvvmContext1.SetViewModel(typeof(DeviceCommViewModel), DeviceCommViewModel.VM);
                fluent = mvvmContext1.OfType<DeviceCommViewModel>();
                AddBinding(fluent.SetBinding(cbeCommunication, ce => ce.Text, x => x.AnalysisEntities, m =>
                {
                    if (m == null ||m.Commuunication==null|| m.Commuunication.Value == null) return "";
                    return m.Commuunication.Value.ToString();
                }));
                AddBinding(fluent.SetBinding(ceUsedPm, ce => ce.CheckState, x => x.AnalysisEntities, m =>
                {
                    if (m == null || m.Used.Value == null) return CheckState.Unchecked;
                    return m.Used.Value.ToString() == "1" ? CheckState.Checked : CheckState.Unchecked;
                }));
            }
            catch(Exception ex)
            {
            }
            DeviceCommViewModel.VM.ModelChanged += (sender, arg) =>
            {
                if (arg.ModelName == typeof(DeviceCommViewModel).Name) action();
            };
            RefreshUI();
            base.InitializeBindings();
        }
        /// <summary>
        /// 初始化下拉列表（可用作刷新）
        /// </summary>
        private void InitComboBox()
        {
            cbeCommunication.Properties.Items.Clear();
            DeviceCommViewModel.VM.Execute(new List<Object> {
                DeviceCommViewModel.ExecuteCommand.ec_QueryComInfo
            });
            if (DeviceCommViewModel.VM.ComInfoEntities == null || DeviceCommViewModel.VM.ComInfoEntities.Count == 0) return;

            for (int i = 0; i < DeviceCommViewModel.VM.ComInfoEntities.Count; i++)
            {
                try
                {
                    cbeCommunication.Properties.Items.Add(((DTCommunicationInfo)DeviceCommViewModel.VM.ComInfoEntities[i]).Name.Value.ToString());
                }
                catch
                {

                }
            }
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }
        /// <summary>
        /// 刷新界面
        /// </summary>
        private void RefreshUI()
        {
            DeviceCommViewModel.VM.Execute(new List<Object> {
                DeviceCommViewModel.ExecuteCommand.ec_QueryDeviceInfo,
                (DeviceName)Enum.Parse(typeof(DeviceName),cName),
            });
            InitComboBox();
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            SimpleButton[] buttons = { sbRefresh, sbSave };
            ButtonEnable(false, buttons);
            //获取旧的参数，保存失败则回溯
            DTDeviceInfo dt = DeviceCommViewModel.VM.AnalysisEntities;

            bool rs = SaveDeviceComChanges(
               (DeviceName)Enum.Parse(typeof(DeviceName),cName),
             cbeCommunication.Text,
             ceUsedPm.Checked ? "1" : "0"
             );
            if (!rs) { BackDeviceComChanges(dt); }
            ButtonEnable(true, buttons);
            RefreshUI();
            if (!rs) return;

            DeviceNotifyEventArgs args = new DeviceNotifyEventArgs();
            args.Key = "AnalysisDevice";
            args.Param = rs;
            onDeviceNotify(args);
        }
    }
}
