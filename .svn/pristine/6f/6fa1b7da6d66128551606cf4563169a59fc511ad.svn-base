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
using DevExpress.Utils.MVVM;
using Wayee.Services;
using DevExpress.XtraEditors;
using wayeal.os.exhaust;

namespace wayeal.exdevice
{
    public partial class ucCommunicationTCP : ucBase
    {
        //网口名
        string cName = null;
        string _space = "  ";
        string _colon = ":";
        private MVVMContextFluentAPI<DeviceCommViewModel> fluent;
        public ucCommunicationTCP()
        {
            InitializeComponent();
        }
        public ucCommunicationTCP(object comName)
        {
            InitializeComponent();
            Params = comName;
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }

        private object _Params = null;
        public override object Params
        {
            get { return _Params; }
            set {
                _Params = value;
                if (_Params != null) cName = _Params.ToString();
                InitTextBox(cName);
            }
        }
        private void InitTextBox(string cName)
        {
            teComName.Text = cName;
            teCommunicaitonType.Text = "网口_TCP";
            DeviceCommViewModel.VM.Execute(new List<object>
            {
                DeviceCommViewModel.ExecuteCommand.ec_QueryComInfo,
                cName,
            });
        }

        protected override void InitializeBindings()
        {
            mvvmContext1.SetViewModel(typeof(DeviceCommViewModel), DeviceCommViewModel.VM);
            fluent = mvvmContext1.OfType<DeviceCommViewModel>();
            AddBinding(fluent.SetBinding(teIP, ce => ce.Text, x => x.ComInfoEntities, m => {
                if (m == null || m.Count == 0) return "";
                if (((DTCommunicationInfo)m[0]).IP.Value != null)
                {
                    return ((DTCommunicationInfo)m[0]).IP.Value.ToString().Trim();
                }
                return "";
            }));
            AddBinding(fluent.SetBinding(tePortNumber, ce => ce.Text, x => x.ComInfoEntities, m => {
                if (m == null || m.Count == 0) return "";
                if (((DTCommunicationInfo)m[0]).PortNumberTCP.Value != null)
                {
                    return ((DTCommunicationInfo)m[0]).PortNumberTCP.Value.ToString().Trim();
                }
                return "";
            }));
            AddBinding(fluent.SetBinding(rgCSType, ce => ce.SelectedIndex, x => x.ComInfoEntities, m => {
                if (m == null || m.Count == 0) return -1;
                try
                {
                    if (((DTCommunicationInfo)m[0]).CSType.Value != null)
                    {
                        return rgCSType.Properties.Items.GetItemIndexByValue(((DTCommunicationInfo)m[0]).CSType.Value.ToString().Trim());
                    }
                }
                catch { }
                return -1;
            }));
            DeviceCommViewModel.VM.ModelChanged += (sender, arg) =>
            {
                if (arg.ModelName == typeof(DeviceCommViewModel).Name) action();
            };
            base.InitializeBindings();
        }
        /// <summary>
        /// 保存通讯信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(teIP.Text.Trim()) || String.IsNullOrEmpty(tePortNumber.Text.Trim())||rgCSType.SelectedIndex==-1)
            {
                XtraMessageBox.Show(lcNull.Text);
                return;
            }
            DeviceCommViewModel.VM.Execute(new List<object>
            {
                DeviceCommViewModel.ExecuteCommand.ec_SaveComChange,
                teComName.Text,
                teIP.Text,
                tePortNumber.Text,
                rgCSType.EditValue
            });
            WriteLog();
            if (DeviceCommViewModel.VM.SaveComChangeEntities)
            {
                ErrorLog.OperateLog(true);
                XtraMessageBox.Show("保存成功");
            }
            else
            {
                ErrorLog.OperateLog(false);
                XtraMessageBox.Show("保存失败");
            }
        }
        /// <summary>
        /// 删除通讯信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbDelete_Click(object sender, EventArgs e)
        {
            DeviceCommViewModel.VM.Execute(new List<object>
            {
                 DeviceCommViewModel.ExecuteCommand.ec_DeleteComInfo,
                teComName.Text,
            });
            if (DeviceCommViewModel.VM.DeleteComInfoEntities)
            {
                XtraMessageBox.Show("删除成功");
            }
            else
            {
                XtraMessageBox.Show("删除失败");
            }
        }
        private void WriteLog()
        {
            try
            {
                string log = "保存通讯" + _space;
                log += lcComName.Text + _colon + teComName.Text + _space;
                log += cbeCommunicationType.Text + _colon + teCommunicaitonType.Text + _space;
                log += lcIP.Text + _colon + teIP.Text + _space;
                log += lcPortNumber.Text + _colon + tePortNumber.Text + _space;
                log += rgCSType.Properties.Items[rgCSType.SelectedIndex];
                ErrorLog.SystemLog(DateTime.Now, log);
            }
            catch
            { }
        }
    }
}
