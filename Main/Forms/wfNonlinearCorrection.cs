using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using System;
using System.Collections;
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
    public partial class wfNonlinearCorrection : wfBase
    {
        private MVVMContextFluentAPI<CalibrationViewModel> fluent;
        string log = null;
        string ChangeLog = null;
        string logCheckedToUnchecked = Program.infoResource.GetLocalizedString(language.InfoId.Checked) + "->" + Program.infoResource.GetLocalizedString(language.InfoId.Unchecked);
        string logUncheckedToChecked = Program.infoResource.GetLocalizedString(language.InfoId.Unchecked) + "->" + Program.infoResource.GetLocalizedString(language.InfoId.Checked);

        public wfNonlinearCorrection()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
            ChangeLog=InitFirstChangeLog();
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

                AddBinding(cbeGasName.Name ,fluent.SetBinding(cbeGasName, ce => ce.Text, x => x.NonlinearCorrection.GasName));
                AddBinding(ceCorrection.Name, fluent.SetBinding(ceCorrection, ce => ce.Checked, x => x.NonlinearCorrection.Correction));
                AddBinding(gcCorrectionData.Name, fluent.SetBinding(gcCorrectionData, ce => ce.DataSource, x => 
                x.NonlinearCorrection.Concentration,m=> { return m; }));

       //         sbSave.BindCommand(CalibrationViewModel.VM, () => CalibrationViewModel.ExecuteCommand.ec_SaveNonlinearCorrection);

                Messenger.Default.Register<string>(this, typeof(CalibrationViewModel.NonlinearCorrectionModel).Name, action);
                CalibrationViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(CalibrationViewModel).Name || arg.ModelName == typeof(CalibrationViewModel.NonlinearCorrectionModel).Name) action();
                };
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        /// <summary>
        /// 修真气体表转文字
        /// </summary>
        /// <returns></returns>
        private string InitFirstChangeLog()
        {
            int i = 0,j=0;
            string logcon = "NO气体:";
            if (CalibrationViewModel.VM.NonlinearCorrection.NOConcentration == null || CalibrationViewModel.VM.NonlinearCorrection.NOConcentration.Count == 0)
                logcon += "无数据";
            else
            {
                foreach (CalibrationViewModel.NonlinearCorrectionModel.CorrectConcentration cc in CalibrationViewModel.VM.NonlinearCorrection.NOConcentration)
                {
                    logcon += "第" + (++i) + "组[修正前浓度:" + cc.PreConcentration + ",修正后浓度:" + cc.PostConcentration + "] ";
                   
                }
            }
            logcon += "HC气体:";
            if (CalibrationViewModel.VM.NonlinearCorrection.HCConcentration == null || CalibrationViewModel.VM.NonlinearCorrection.HCConcentration.Count == 0)
                logcon += "无数据";
            else
            {
                foreach (CalibrationViewModel.NonlinearCorrectionModel.CorrectConcentration cc in CalibrationViewModel.VM.NonlinearCorrection.HCConcentration)
                {
                    logcon += "第" + (++j)+ "组[修正前浓度:" + cc.PreConcentration + ",修正后浓度:" + cc.PostConcentration + "] ";
                 
                }
            }
            return logcon;
        }

        private void sbNew_Click(object sender, EventArgs e)
        {
            try
            {
                CalibrationViewModel.NonlinearCorrectionModel.CorrectConcentration cc = new CalibrationViewModel.NonlinearCorrectionModel.CorrectConcentration();
                cc.PreConcentration = 0f;
                cc.PostConcentration = 0f;
                ArrayList args = new ArrayList() { CalibrationViewModel.ExecuteCommand.ec_NewNonlinearConcentration,cc };
                CalibrationViewModel.VM.Execute(args);
                
                _BindingList2[gcCorrectionData.Name].UpdateTarget();
                gcCorrectionData.MainView.RefreshData();
              //  log += "新增修正气体  " + lcGasName.Text + ":" + cbeGasName.SelectedItem.ToString() + ";";
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void ribe_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int index = gridView1.FocusedRowHandle;
                if (index < 0 || index >= gridView1.RowCount) return;
                //log += "删除修正气体  ";
                //log += lcGasName.Text + ":" + cbeGasName.SelectedItem.ToString() + " ";
                //log += "所处行号:" + (index+1);
                //log +=gcPreConcentration.Caption+":"+gridView1.GetFocusedRowCellValue(gcPreConcentration).ToString();
                //log += gcPostConcentration.Caption + ":" + gridView1.GetFocusedRowCellValue(gcPostConcentration).ToString()+";";
                gridView1.DeleteRow(index);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void cbeGasName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                action();
                gcCorrectionData.MainView.RefreshData();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void ceCorrection_EditValueChanged(object sender, EventArgs e)
        {
            log +=lcCorrection.Text+"  "+( ceCorrection.Checked ? logUncheckedToChecked : logCheckedToUnchecked )+";";
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            CalibrationViewModel.VM.Execute(CalibrationViewModel.ExecuteCommand.ec_SaveNonlinearCorrection);
            if (log != null)
            {
                string[] logs = log.Split(';');
                for (int i=0; i<logs.Count()-1;i++)
                {
                   
                    ErrorLog.ParamChanged(DateTime.Now, logs[i], frmMain.UserName);
                }
               
                log = null;
            }
            string OldChangeLog = ChangeLog;
            string NewChangeLog = InitFirstChangeLog();
            if (OldChangeLog != NewChangeLog)
            {
                ErrorLog.ParamChanged(DateTime.Now, OldChangeLog + "->" + NewChangeLog, frmMain.UserName);
                ChangeLog = NewChangeLog;
            }
        }
    }
}
