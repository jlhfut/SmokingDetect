using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.Forms;
using DevExpress.Mvvm;
using wayeal.os.exhaust.ViewModel;
using DevExpress.Utils.MVVM;
using System.Collections;
using DevExpress.XtraEditors;
using System.IO;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucCalibrationControl : ucBase
    {
        #region defines
        wfOpacityCalibration frmOpacityCalibration = null;
        wfTimingCalibration frmTimingCalibration = null;
        wfNonlinearCorrection frmNonlinear = null;
        wfPointCorrect frmPoint = null;
        private MVVMContextFluentAPI<CalibrationViewModel.CalibrationValueModel> fluent;
        #endregion

        public ucCalibrationControl()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        public void  SetPointCorrectVisible()
        {
            string dbPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!File.Exists(dbPath+"certification.txt"))
            {
                sbPointCorrect.Visible = false;
            }
        }
        /// <summary>
        /// Init
        /// </summary>
        protected override void InitializeBindings()
        {
            try
            {
                mvvmContext1.SetViewModel(typeof(CalibrationViewModel.CalibrationValueModel), CalibrationViewModel.VM.CalibrationValue);
           //     sbCorrect.BindCommand(CalibrationViewModel.VM, () => CalibrationViewModel.ExecuteCommand.ec_Calibrate);
                fluent = mvvmContext1.OfType<CalibrationViewModel.CalibrationValueModel>();
                AddBinding(teNOValue.Name,fluent.SetBinding(teNOValue, ce => ce.Text, x => x.ActualNO));
                AddBinding(fluent.SetBinding(teNOValue2, ce => ce.Text, x => x.NO, m => { return m.ToString("f2"); }));
                AddBinding(teCOValue.Name, fluent.SetBinding(teCOValue, ce => ce.Text, x => x.ActualCO));
                AddBinding(fluent.SetBinding(teCOValue2, ce => ce.Text, x => x.CO, m => { return m.ToString("f2"); }));
                AddBinding(teHCValue.Name, fluent.SetBinding(teHCValue, ce => ce.Text, x => x.ActualHC));
                AddBinding(fluent.SetBinding(teHCValue2, ce => ce.Text, x => x.HC, m => { return m.ToString("f2"); }));
                AddBinding(teCO2Value.Name, fluent.SetBinding(teCO2Value, ce => ce.Text, x => x.ActualCO2));
                AddBinding(fluent.SetBinding(teCO2Value2, ce => ce.Text, x => x.CO2, m => { return m.ToString("f2"); }));

                AddBinding(fluent.SetBinding(ceUltravioletBgSpectrogram, ce => ce.Checked, x => x.UltravioletBgSelected));
                AddBinding(fluent.SetBinding(ceInfraredBgSpectrogram, ce => ce.Checked, x => x.InfraredBgSelected));
                AddBinding(fluent.SetBinding(ceNO, ce => ce.Checked, x => x.NOSelected));
                AddBinding(fluent.SetBinding(ceHC, ce => ce.Checked, x => x.HCSelected));
                AddBinding(fluent.SetBinding(ceCO, ce => ce.Checked, x => x.COSelected));
                AddBinding(fluent.SetBinding(ceCO2, ce => ce.Checked, x => x.CO2Selected));

                AddBinding(fluent.SetBinding(sbCorrect, sb => sb.Enabled, x => x.IsCalibrate, m => { return !m; },v=> { return !this.Enabled ? false : !v; }));

                Messenger.Default.Register<string>(this, typeof(CalibrationViewModel.CalibrationValueModel).Name, action);
                CalibrationViewModel.VM.ModelChanged += (sender, arg) => {
                    if (arg.ModelName == typeof(CalibrationViewModel).Name || arg.ModelName == typeof(CalibrationViewModel.CalibrationValueModel).Name)
                    {
                        action();
                    }
                };
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void sbOpacityCorrect_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmOpacityCalibration == null) frmOpacityCalibration = new wfOpacityCalibration();
                frmOpacityCalibration.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }


        private void sbTimingCalibrate_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmTimingCalibration == null) frmTimingCalibration = new wfTimingCalibration();
                frmTimingCalibration.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void sbNonlinearCorrection_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmNonlinear == null) frmNonlinear = new wfNonlinearCorrection();
                frmNonlinear.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void sbCorrect_Click(object sender, EventArgs e)
        {
            try
            {
                CalibrationViewModel.VM.Execute(new ArrayList() { CalibrationViewModel.ExecuteCommand.ec_Calibrate });
                string logcontent = "";
                if (ceUltravioletBgSpectrogram.Checked) logcontent += ceUltravioletBgSpectrogram.Text+" "; /*+ ":" + teNOValue + "," + "teNOValue2" + "ppm";*/
                if (ceInfraredBgSpectrogram.Checked) logcontent += ceInfraredBgSpectrogram.Text + " ";
                if (ceNO.Checked) logcontent += ceNO.Text + ":" + teNOValue.Text + "," + teNOValue2.Text + "ppm" + " ";
                if (ceHC.Checked) logcontent += ceHC.Text + ":" + teHCValue.Text + "," + teHCValue2.Text + "ppm" + " ";
                if (ceCO.Checked) logcontent += ceCO.Text + ":" + teCOValue.Text + "," + teCOValue2.Text + "%" + " ";
                if (ceCO2.Checked) logcontent += ceCO2.Text.Replace("₂", "2") + ":" + teCO2Value.Text + "," + teCO2Value2.Text + "%";
                if (logcontent!="")
                    ErrorLog.ParamChanged(System.DateTime.Now, 
                        /*Program.infoResource.GetLocalizedString(language.InfoId.)+*/logcontent,
                        this.OwnerForm.GetUserName());
                else
                {
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.CorrectItemIsEmpty), "", MessageBoxButtons.OK);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString ());
            }
        }

        private void sbPointCorrect_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmPoint == null) frmPoint = new wfPointCorrect();
                frmPoint.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
    }
}
