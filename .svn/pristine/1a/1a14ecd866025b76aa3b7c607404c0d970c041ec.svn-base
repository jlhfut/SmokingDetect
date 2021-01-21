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
    public partial class ucCommunicationUDP : ucBase
    {
        //网口名
        string cName = null;
        string _space = "  ";
        string _colon = ":";
        private MVVMContextFluentAPI<DeviceCommViewModel> fluent;

        public ucCommunicationUDP()
        {
            InitializeComponent();
        }
        public ucCommunicationUDP(object comName)
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
            teCommunicaitonType.Text = "网口_UDP";
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
            AddBinding(fluent.SetBinding(tePortNumber, ce => ce.Text, x => x.ComInfoEntities, m => {
                if (m == null || m.Count == 0) return "";
                if (((DTCommunicationInfo)m[0]).PortNumberTCP.Value != null)
                {
                    return ((DTCommunicationInfo)m[0]).PortNumberTCP.Value.ToString().Trim();
                }
                return "";
            }));
            DeviceCommViewModel.VM.ModelChanged += (sender, arg) =>
            {
                if (arg.ModelName == typeof(DeviceCommViewModel).Name) action();
            };
            base.InitializeBindings();
        }
        private void sbSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tePortNumber.Text.Trim()) || rgCSType.SelectedIndex == -1)
            {
                XtraMessageBox.Show(lcNull.Text);
                return;
            }
            DeviceCommViewModel.VM.Execute(new List<object>
            {
                DeviceCommViewModel.ExecuteCommand.ec_SaveComChange,
                teComName.Text,
                null,
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
        private void WriteLog()
        {
            try
            {
                string log = "保存通讯" + _space;
                log += lcComName.Text+_colon + teComName.Text + _space;
                log += cbeCommunicationType.Text + _colon + teCommunicaitonType.Text + _space;
                log += lcPortNumber.Text + _colon + tePortNumber.Text + _space;
                log += rgCSType.Properties.Items[rgCSType.SelectedIndex];
                ErrorLog.SystemLog(DateTime.Now, log);
            }
            catch
            { }
        }
    }
}
