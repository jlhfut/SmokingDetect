using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.ViewModel;

namespace wayeal.os.exhaust.Forms
{
    public partial class wfTimingCalibration : wfBase
    {
        private bool bSave = false;
        string logChecked = Program.infoResource.GetLocalizedString(language.InfoId.Checked);
        string logUnchecked = Program.infoResource.GetLocalizedString(language.InfoId.Unchecked);

        private MVVMContextFluentAPI<CalibrationViewModel> fluent;
        private Dictionary<int, CheckState> operates = new Dictionary<int, CheckState>();
        public wfTimingCalibration()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        /// <summary>
        /// Init
        /// </summary>
        protected override void InitializeBindings()
        {
            try
            {
                InitializeUI();
                mvvmContext1.SetViewModel(typeof(CalibrationViewModel), CalibrationViewModel.VM);
                fluent = mvvmContext1.OfType<CalibrationViewModel>();

                AddBinding(fluent.SetBinding(ceAutoCalibrateZero, ce => ce.Checked, x => x.TimingCalibration.AutoCalibrateZero,m=> { return m; },v=> {return bSave?v:CalibrationViewModel.VM.TimingCalibration.AutoCalibrateZero; }));
                AddBinding(fluent.SetBinding(ceAutoCalibrateRange, ce => ce.Checked, x => x.TimingCalibration.AutoCalibrateRange, m => { return m; }, v => { return bSave ? v : CalibrationViewModel.VM.TimingCalibration.AutoCalibrateRange; }));
                AddBinding(fluent.SetBinding(teAutoCalibrateZeroInterval, ce => ce.Text, x => x.TimingCalibration.AutoCalibrateZeroInterval, m => { return m.ToString(); }, v => { return bSave ? int.Parse(v) : CalibrationViewModel.VM.TimingCalibration.AutoCalibrateZeroInterval; }));
                AddBinding(clbcTimes.Name, fluent.SetBinding(clbcTimes, ce => ce.DataSource, x => x.TimingCalibration.Times, m => { return m; }, v => { return bSave ?(List<CalibrationViewModel.TimingCalibrationModel.TimeItem>)v : CalibrationViewModel.VM.TimingCalibration.Times; }));
                //sbSave.BindCommand(CalibrationViewModel.VM, () => {
                   
                //    return CalibrationViewModel.ExecuteCommand.ec_SaveTimingCalibration;
                //});

                //Messenger.Default.Register<string>(this, typeof(CalibrationViewModel.TimingCalibrationModel).Name, action);
                //CalibrationViewModel.VM.ModelChanged += (sender, arg) =>
                //{
                //    if (arg.ModelName == typeof(CalibrationViewModel).Name || arg.ModelName == typeof(CalibrationViewModel.TimingCalibrationModel).Name) action();
                //};
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        protected override void OnShown(EventArgs e)
        {
            try
            {
                base.OnShown(e);
                action();
                //foreach (int key in operates.Keys)
                //    clbcTimes.SetItemChecked(key, !(operates[key] == CheckState.Checked));
                clbcTimes_DataSourceChanged(clbcTimes, null);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        private void clbcTimes_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {            
            try
            {
                CalibrationViewModel.TimingCalibrationModel.TimeItem item = ((List<CalibrationViewModel.TimingCalibrationModel.TimeItem>)clbcTimes.DataSource)[e.Index];
                if (operates.ContainsKey(item.Index))
                    operates[item.Index] = e.State;
                else
                    operates.Add(item.Index, e.State);
                item.CheckState = e.State;
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void clbcTimes_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {                
                List<CalibrationViewModel.TimingCalibrationModel.TimeItem> ls = ((List<CalibrationViewModel.TimingCalibrationModel.TimeItem>)clbcTimes.DataSource);
                for(int i=0;i<ls.Count;i++)
                {
                    clbcTimes.SetItemChecked(i, ls[i].CheckState == CheckState.Checked);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            bSave = true;
            try
            {
                foreach (IPropertyBinding b in _BindingList) if (b != null) b.UpdateSource();
                foreach (string k in _BindingList2.Keys)
                {
                    if (_BindingList2[k] != null) _BindingList2[k].UpdateSource();
                }
                string log = null;
                log += this.Text + "  " + lcAutoCalibrateZero.Text + ":" + (ceAutoCalibrateZero.Checked ? logChecked : logUnchecked) + "  ";
                log += lcAutoCalibrateRange.Text + ":" + (ceAutoCalibrateRange.Checked ? logChecked : logUnchecked) + "  ";
                log += lcAutoCalibrateZeroInterval.Text + ":" + teAutoCalibrateZeroInterval.Text + "  ";
                log += lcTimes.Text + ":";
                string checkedTime = null;
                List<CalibrationViewModel.TimingCalibrationModel.TimeItem> ls = ((List<CalibrationViewModel.TimingCalibrationModel.TimeItem>)clbcTimes.DataSource);
                for (int i = 0; i < ls.Count; i++)
                {
                    if (ls[i].CheckState == CheckState.Checked)
                        checkedTime += ls[i].Text+"  ";
                }
                if (checkedTime == null) checkedTime = "无";
                ErrorLog.ParamChanged(DateTime.Now, log+checkedTime, frmMain.UserName);
            }
            finally
            {
                bSave = false;
                operates.Clear();
            }
            CalibrationViewModel.VM.Execute( CalibrationViewModel.ExecuteCommand.ec_SaveTimingCalibration);
        }
    }
}
