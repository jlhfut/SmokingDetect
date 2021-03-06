﻿#define VerticalDistribution
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.plugin;
using wayeal.os.exhaust.ViewModel;
using Wayee.Services;
using wayeal.os.exhaust.Forms;
using DevExpress.XtraEditors;
using DevExpress.Mvvm;
using System.Reflection;
using DevExpress.XtraTreeList;
using System.Diagnostics;
using DevExpress.XtraTreeList.Nodes;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucDebuggingDevices : ucBase
    {
        public class DeviceClickEventArgs : EventArgs
        {
            public string Key { get; set; }
            public string Title { get; set; }
            public UserControl SetupUI { get; set; }
            public object Param { get; set; }
        }
        private DeviceClickEventArgs _firstEvent = new DeviceClickEventArgs();
        public DeviceClickEventArgs FirstEvent { get { return _firstEvent; }  set { _firstEvent = value; } }
        public delegate void DeviceClickEventHandler(object sender, DeviceClickEventArgs e);
        public event DeviceClickEventHandler DeviceClick;
        

        public ucDebuggingDevices()
        {
            InitializeComponent();
            AddAnalysisNodes();
            InitDeviceList();
            InitComList();
            InitializeUI();
        }
        [Conditional("VerticalDistribution")]
        private void AddAnalysisNodes()
        {
            for (int i = 0; i < 6; i++)
            {
                string name = "Analysis"+(i%2==0?"L":"R")+(i/2+1);
                string tag = "AnalysisDevice|"+ name;
                tlDeviceDebug.AppendNode(new object[] { name, "1"}, -1, 0, 0, 0, tag);
            }
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            try
            {
                if (base.Visible)
                {
                    RealtimeMonitorViewModel.VM.Devices = null;
                    for (int i = 0; i < tlDeviceDebug.Nodes.Count; i++)
                    {
                        tlDeviceDebug.Nodes[i].StateImageIndex = (tlDeviceDebug.Nodes[i].Tag != null && RealtimeMonitorViewModel.VM.getDeviceUsed(tlDeviceDebug.Nodes[i].Tag.ToString().Split('|')[1])) ? 1 : 0;
                        tlDeviceDebug.Nodes[i][1] = i >= 5 || Program.permissionManager.ActivePermission < 1 ? 1 : tlDeviceDebug.Nodes[i].StateImageIndex;
                    }
                }
            }
            catch(Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        public void InitDeviceList()
        {
            try
            {
                TreeList tl = tlDeviceDebug;
                List<UserControl> lstUI = new List<UserControl>();
                for (int i =0;i<tl.Nodes.Count ; i++)
                {
                    tl.Nodes[i].StateImageIndex = (tl.Nodes[i].Tag != null && RealtimeMonitorViewModel.VM.getDeviceUsed(tl.Nodes[i].Tag.ToString().Split('|')[1])) ? 1 : 0;
                    tl.Nodes[i][1] = i >= 5 || Program.permissionManager.ActivePermission < 1 ? 1 : tl.Nodes[i].StateImageIndex;
                    string plugName = tl.Nodes[i].Tag == null ? "" : tl.Nodes[i].Tag.ToString().Split('|')[0];
                    PluginInfo p = Program.devicePluginManager.GetPlugin(plugName);
                    if (lstUI.Contains(p.SetupUI)) continue;
                    if (p != null && !p.RegistNotify && p.SetupUI != null) (p.SetupUI as ucPluginBase).DeviceNotify += UcDebuggingDevices_DeviceNotify;
                    lstUI.Add(p.SetupUI);
                }

                if (tlDeviceDebug.Nodes.Count > 0)
                {
                    try
                    {
                        FirstEvent.Key = tlDeviceDebug.Nodes[0].Tag == null ? "" : tlDeviceDebug.Nodes[0].Tag.ToString().Split('|')[0];
                        PluginInfo p = Program.devicePluginManager.GetPlugin(FirstEvent.Key.Trim());
                        FirstEvent.SetupUI = p != null ? p.SetupUI : null;
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.Error(ex.StackTrace.ToString());
                    }
                }
                
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }

        }
        /// <summary>
        /// 初始化通讯列表（可用于刷新）
        /// </summary>
        /// <param name="IsRightControlsRefresh">右侧控件是否需要同步刷新</param>
        /// <param name="isFirst">true：右侧列表显示第一个，false：显示最后一个</param>
        private void InitComList(bool IsRightControlsRefresh = false, bool isFirst = true)
        {
            tlCommunication.Nodes.Clear();
            ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryCommunicationInfo });
            if (ResultDataViewModel.VM.QueryCommunicationEntities == null || ResultDataViewModel.VM.QueryCommunicationEntities.Count == 0) return;
            for (int i = 0; i < ResultDataViewModel.VM.QueryCommunicationEntities.Count; i++)
            {
                try
                {
                    DTCommunicationInfo dt = (DTCommunicationInfo)ResultDataViewModel.VM.QueryCommunicationEntities[i];
                    tlCommunication.AppendNode(new object[] { dt.Name.Value.ToString() }, -1, CheckState.Unchecked, dt.ComType.Value.ToString());
                }
                catch
                {
                }
            }
            //右侧列表是否需要刷新
            if (IsRightControlsRefresh)
            {
                try
                {
                    int n = ResultDataViewModel.VM.QueryCommunicationEntities.Count - 1;
                    DeviceClickEventArgs args = new DeviceClickEventArgs();
                    args.Key = tlCommunication.Nodes[isFirst ? 0 : n].Tag == null ? "" : tlCommunication.Nodes[isFirst ? 0 : n].Tag.ToString().Trim();
                    args.Param = tlCommunication.Nodes[isFirst ? 0 : n].GetDisplayText(tlCommunication.Columns[0]);
                    SelectedNodeChanged(args,true);
                }
                catch (Exception ex)
                {
                    ErrorLog.Error(ex.StackTrace.ToString());
                }
            }
        }
        /// <summary>
        /// 切换选中行事件——设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlDevice_RowClick(object sender, DevExpress.XtraTreeList.RowClickEventArgs e)
        {
            try
            {
                DeviceClickEventArgs args = new DeviceClickEventArgs();
                args.Key = e.Node.Tag == null ? "" : e.Node.Tag.ToString().Split('|')[0];
                if (args.Key.Contains("Analysis"))
                {
                    args.Param = e.Node.Tag.ToString().Split('|')[1];
                    SelectedNodeChanged(args, true);
                    return;
                }
                PluginInfo p = Program.devicePluginManager.GetPlugin(args.Key);
                args.SetupUI = p != null ? p.SetupUI : null;
                if (DeviceClick != null) DeviceClick(this, args);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void UcDebuggingDevices_DeviceNotify(object sender, ucPluginBase.DeviceNotifyEventArgs e)
        {
            try
            {
                //注册了多个，防止发多次
                PropertyInfo p = sender.GetType().GetProperty("Name");
                if (p == null) return;
                if (p.GetValue(sender).ToString().Contains(e.Key))
                {
                   Messenger.Default.Send(e);
                }

            }
            catch(Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        /// <summary>
        ///  切换选中行事件——通讯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlCommunication_RowClick(object sender, DevExpress.XtraTreeList.RowClickEventArgs e)
        {
            try
            {
                DeviceClickEventArgs args = new DeviceClickEventArgs();
                args.Key = e.Node.Tag == null ? "" : e.Node.Tag.ToString().Trim();
                args.Param = e.Node.GetDisplayText(tlCommunication.Columns[0]);
                SelectedNodeChanged(args, true);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void tcList_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tcList.SelectedTabPageIndex == 0)
            {
                DeviceClickEventArgs args = new DeviceClickEventArgs();
                if (tlDeviceDebug.FocusedNode == null) return;
                args.Key = tlDeviceDebug.FocusedNode.Tag == null ? "" : tlDeviceDebug.FocusedNode.Tag.ToString();
                SelectedNodeChanged(args, true);
            }
            else
            {
                DeviceClickEventArgs args = new DeviceClickEventArgs();
                if (tlCommunication.FocusedNode == null) return;
                args.Key = tlCommunication.FocusedNode.Tag == null ? "" : tlCommunication.FocusedNode.Tag.ToString().Trim();
                args.Param = tlCommunication.FocusedNode.GetDisplayText(tlCommunication.Columns[0]);
                SelectedNodeChanged(args, true);
            }
        }
        private void NewComInfo()
        {
            wfNewCom from = new wfNewCom();
            DialogResult dr = from.ShowDialog();
            if (dr == DialogResult.OK)
            {
                InitComList(true, true);
            }
        }
        /// <summary>
        /// 新建通讯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void peNew_Click(object sender, EventArgs e)
        {
            NewComInfo();
        }

        private void lcDelete_Click(object sender, EventArgs e)
        {
            //确认删除
            DialogResult dr = XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.SureDelete), "", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                ResultDataViewModel.VM.Execute(new List<object>
                {
                    ResultDataViewModel.ExecuteCommand.ec_DeleteComInfo,
                    tlCommunication.FocusedNode.GetDisplayText(tlCommunication.Columns[0])
                });
                if (ResultDataViewModel.VM.DeleteComInfoEntities)
                {
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess));
                    InitComList(true, true);
                }
                else
                {
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.OperateFail));
                }
            }
        }
        /// <summary>
        /// 选中的节点发生改变时切换界面
        /// </summary>
        /// <param name="args"></param>
        /// <param name="hasParam">是否带参数</param>
        private void SelectedNodeChanged(DeviceClickEventArgs args,bool hasParam=false)
        {
            PluginInfo p = Program.devicePluginManager.GetPlugin(args.Key.Trim());
            args.SetupUI = p != null ? p.SetupUI : null;
            if (hasParam)
            {
                if (p != null && p.SetupUI != null && p.SetupUI is ucPluginBase) (p.SetupUI as ucPluginBase).Params = args.Param;
            }
            if (DeviceClick != null) DeviceClick(this, args);
        }
    }
}
