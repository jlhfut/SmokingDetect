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
    public partial class ucCommunicationCOM : ucBase
    {
        string COMName = null;
        string _space = "  ";
        string _colon = ":";
        private MVVMContextFluentAPI<DeviceCommViewModel> fluent;
        public ucCommunicationCOM()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param">端口名</param>
        public ucCommunicationCOM(object param)
        {
            InitializeComponent();
            Params = param;
            if(!mvvmContext1.IsDesignMode)InitializeBindings();
        }
        private object _Params = null;
        public override object Params
        {
            get { return _Params; }
            set
            {
                _Params = value;
                if (_Params != null) COMName = _Params.ToString();
                InitTextBox(COMName);
            }
        }

        protected override void InitializeBindings()
        {
            mvvmContext1.SetViewModel(typeof(DeviceCommViewModel), DeviceCommViewModel.VM);
            fluent = mvvmContext1.OfType<DeviceCommViewModel>();
            AddBinding(fluent.SetBinding(cbePortNumber, ce => ce.Text, x => x.ComInfoEntities, m => {
                if (m == null || m.Count == 0) return "";
                if (((DTCommunicationInfo)m[0]).PortNumber.Value != null)
                {
                    return ((DTCommunicationInfo)m[0]).PortNumber.Value.ToString().Trim();
                }
                return "";
            }));
            AddBinding(fluent.SetBinding(cbeBaudRate, ce => ce.Text, x => x.ComInfoEntities, m => {
                if (m == null || m.Count == 0) return "";
                if (((DTCommunicationInfo)m[0]).BaudRate.Value != null)
                {
                    return ((DTCommunicationInfo)m[0]).BaudRate.Value.ToString();
                }
                return "";
            }));
            AddBinding(fluent.SetBinding(cbeDataBits, ce => ce.Text, x => x.ComInfoEntities, m => {
                if (m == null || m.Count == 0) return "";
                if (((DTCommunicationInfo)m[0]).DataBit.Value != null)
                {
                    return ((DTCommunicationInfo)m[0]).DataBit.Value.ToString();
                }
                return "";
            }));
            AddBinding(fluent.SetBinding(cbeStopBits, ce => ce.Text, x => x.ComInfoEntities, m => {
                if (m == null || m.Count == 0) return "";
                if (((DTCommunicationInfo)m[0]).StopBit.Value != null)
                {
                    return ((DTCommunicationInfo)m[0]).StopBit.Value.ToString();
                }
                return "";
            }));
            AddBinding(fluent.SetBinding(cbeCheckBits, ce => ce.SelectedIndex, x => x.ComInfoEntities, m => {
                if (m == null || m.Count == 0) return -1;
                try
                {
                    if (((DTCommunicationInfo)m[0]).CheckBit.Value != null)
                    {
                        return Convert.ToInt32(((DTCommunicationInfo)m[0]).CheckBit.Value.ToString());
                    }
                }
                catch
                { }
                return -1;
            }));
            base.InitializeBindings();
            DeviceCommViewModel.VM.ModelChanged += (sender, arg) =>
            {
                if (arg.ModelName == typeof(DeviceCommViewModel).Name) action();
            };
        }
        private void InitTextBox(string COMname)
        {
            teComName.Text = COMName;
            teCommunicaitonType.Text = "串口";
            DeviceCommViewModel.VM.Execute(new List<object>
            {
                DeviceCommViewModel.ExecuteCommand.ec_QueryComInfo,
                COMName,
            });
        }
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbePortNumber.Text.Trim()) || String.IsNullOrEmpty(cbeBaudRate.Text.Trim()) || String.IsNullOrEmpty(cbeDataBits.Text.Trim())
                || String.IsNullOrEmpty(cbeStopBits.Text.Trim()) || String.IsNullOrEmpty(cbeCheckBits.Text.Trim()))
            {
                XtraMessageBox.Show(lcNull.Text);
                return;
            }
            DeviceCommViewModel.VM.Execute(new List<object>
            {
                DeviceCommViewModel.ExecuteCommand.ec_SaveComChange,
                teComName.Text,
                cbePortNumber.Text,
                cbeBaudRate.Text,
                cbeDataBits.Text,
                cbeStopBits.Text,
                cbeCheckBits.SelectedIndex
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
        private void WriteLog()
        {
            string log = "保存通讯"+_space;
            log += lcComName.Text + _colon + teComName.Text + _space;
            log += cbeCommunicationType.Text + _colon + teCommunicaitonType.Text + _space;
            log += lcPortNumber.Text + _colon + cbePortNumber.Text + _space;
            log += lcBaudRate.Text + _colon + cbeBaudRate.Text + _space;
            log += lcDataBits.Text + _colon + cbeDataBits.Text + _space;
            log += lcStopBits.Text + _colon + cbeStopBits.Text + _space;
            log += lcCheckBits.Text + _colon + cbeCheckBits.Text + _space;
            ErrorLog.SystemLog(DateTime.Now, log);
        }

    }
}
