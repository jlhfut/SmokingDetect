using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.ViewModel;

namespace wayeal.os.exhaust.Forms
{
    public partial class wfPointCorrect : wfBase
    {
        private MVVMContextFluentAPI<CalibrationViewModel> fluent;
        string log = null;
        string ChangeLog = null;
        string logCheckedToUnchecked = Program.infoResource.GetLocalizedString(language.InfoId.Checked) + "->" + Program.infoResource.GetLocalizedString(language.InfoId.Unchecked);
        string logUncheckedToChecked = Program.infoResource.GetLocalizedString(language.InfoId.Unchecked) + "->" + Program.infoResource.GetLocalizedString(language.InfoId.Checked);
        Regex regex0To100000= new Regex(@"^(([0-9]|[1-9][0-9]{0,4})(\.\d{1,2})?)|100000$");
        Regex regex0To100 = new Regex(@"^(([0-9]|[1-9][0-9])(\.\d{1,2})?)|100$");
        Regex curRex = null;

        public wfPointCorrect()
        {
            InitializeComponent();
            curRex = regex0To100000;
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
            ChangeLog = InitFirstChangeLog();
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

                AddBinding(cbeGasName.Name, fluent.SetBinding(cbeGasName, ce => ce.Text, x => x.PointCorrection.GasName));
                AddBinding(ceCorrection.Name, fluent.SetBinding(ceCorrection, ce => ce.Checked, x => x.PointCorrection.Correction));
                AddBinding(gcCorrectionData.Name, fluent.SetBinding(gcCorrectionData, ce => ce.DataSource, x =>
                x.PointCorrection.Concentration, m => { return m; }));

                //         sbSave.BindCommand(CalibrationViewModel.VM, () => CalibrationViewModel.ExecuteCommand.ec_SaveNonlinearCorrection);

                Messenger.Default.Register<string>(this, typeof(CalibrationViewModel.PointCorrectionModel).Name, action);
                CalibrationViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(CalibrationViewModel.PointCorrectionModel).Name) action();
                };
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        /// <summary>
        /// 修正气体表转文字
        /// </summary>
        /// <returns></returns>
        private string InitFirstChangeLog()
        {
            int i = 0, j = 0;
            string logcon = "NO气体:";
            if (CalibrationViewModel.VM.PointCorrection.NOConcentration == null || CalibrationViewModel.VM.PointCorrection.NOConcentration.Count == 0)
                logcon += "无数据";
            else
            {
                foreach (CalibrationViewModel.PointCorrectionModel.CorrectConcentration cc in CalibrationViewModel.VM.PointCorrection.NOConcentration)
                {
                    logcon += "第" + (++i) + "组[修正前浓度:" + cc.PreConcentration + ",修正范围:" + cc.ConcentrationRange + ",修正系数:"+cc.ConcentrationCoefficient+"]";
                }
            }
            logcon += "HC气体:";
            if (CalibrationViewModel.VM.PointCorrection.HCConcentration == null || CalibrationViewModel.VM.PointCorrection.HCConcentration.Count == 0)
                logcon += "无数据";
            else
            {
                foreach (CalibrationViewModel.PointCorrectionModel.CorrectConcentration cc in CalibrationViewModel.VM.PointCorrection.HCConcentration)
                {
                    logcon += "第" + (++i) + "组[修正前浓度:" + cc.PreConcentration + ",修正范围:" + cc.ConcentrationRange + ",修正系数:" + cc.ConcentrationCoefficient + "]";

                }
            }
            logcon += "CO气体:";
            if (CalibrationViewModel.VM.PointCorrection.HCConcentration == null || CalibrationViewModel.VM.PointCorrection.HCConcentration.Count == 0)
                logcon += "无数据";
            else
            {
                foreach (CalibrationViewModel.PointCorrectionModel.CorrectConcentration cc in CalibrationViewModel.VM.PointCorrection.HCConcentration)
                {
                    logcon += "第" + (++i) + "组[修正前浓度:" + cc.PreConcentration + ",修正范围:" + cc.ConcentrationRange + ",修正系数:" + cc.ConcentrationCoefficient + "]";

                }
            }
            logcon += "CO2气体:";
            if (CalibrationViewModel.VM.PointCorrection.HCConcentration == null || CalibrationViewModel.VM.PointCorrection.HCConcentration.Count == 0)
                logcon += "无数据";
            else
            {
                foreach (CalibrationViewModel.PointCorrectionModel.CorrectConcentration cc in CalibrationViewModel.VM.PointCorrection.HCConcentration)
                {
                    logcon += "第" + (++i) + "组[修正前浓度:" + cc.PreConcentration + ",修正范围:" + cc.ConcentrationRange + ",修正系数:" + cc.ConcentrationCoefficient + "]";
                }
            }
            return logcon;
        }

       
        
        private void sbNew_Click(object sender, EventArgs e)
        {
            try
            {
                CalibrationViewModel.PointCorrectionModel.CorrectConcentration cc;
                cc = new CalibrationViewModel.PointCorrectionModel.CorrectConcentration(0, 100000);
                cc.PreConcentration = 0f;
                cc.ConcentrationCoefficient = 0f;
                cc.ConcentrationRange = 0f;
                ArrayList args = new ArrayList() { CalibrationViewModel.ExecuteCommand.ec_NewPointConcentration, cc };
                CalibrationViewModel.VM.Execute(args);

                _BindingList2[gcCorrectionData.Name].UpdateTarget();
                gcCorrectionData.MainView.RefreshData();
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
                if (cbeGasName.SelectedIndex > 1)
                {
                    gcPreConcentration.Caption=gcPreConcentration.Caption.Replace("ppm","%");
                    gcConcentrationRange.Caption= gcConcentrationRange.Caption.Replace("ppm","%");
                }
                else
                {
                    gcPreConcentration.Caption = gcPreConcentration.Caption.Replace("%", "ppm");
                    gcConcentrationRange.Caption = gcConcentrationRange.Caption.Replace("%", "ppm");
                }
                curRex = cbeGasName.SelectedIndex > 1 ? regex0To100 : regex0To100000;
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
            log += lcCorrection.Text + "  " + (ceCorrection.Checked ? logUncheckedToChecked : logCheckedToUnchecked) + ";";
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            CalibrationViewModel.VM.Execute(CalibrationViewModel.ExecuteCommand.ec_SavePointCorrection);
            if (log != null)
            {
                string[] logs = log.Split(';');
                for (int i = 0; i < logs.Count() - 1; i++)
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
        /// <summary>
        /// 输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //获取所在列是否为修正范围
            try
            {
                var gc = ((DevExpress.XtraGrid.Views.Grid.GridView)sender).FocusedColumn;
                if (gc == null || gc != gcConcentrationRange)
                {
                    e.Valid = true;
                    return;
                }
                Regex regex = curRex;
                if (regex == null || (regex != regex0To100 && regex != regex0To100000))
                {
                    e.Valid = true;
                    return;
                }
                e.Valid = regex.IsMatch(e.Value.ToString());
                e.ErrorText = Program.infoResource.GetLocalizedString(regex == regex0To100 ? language.InfoId.vad0To100 : language.InfoId.vad0To100000);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
        }
    }
}
