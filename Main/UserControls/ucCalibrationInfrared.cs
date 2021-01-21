using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.ViewModel;
using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using System.Collections;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucCalibrationInfraredController : ucSettingsBase
    {
        private MVVMContextFluentAPI<CalibrationViewModel.InfraredModel> fluent;
        public ucCalibrationInfraredController()
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
                mvvmContext1.SetViewModel(typeof(CalibrationViewModel.InfraredModel), CalibrationViewModel.VM.Infrared);
                fluent = mvvmContext1.OfType<CalibrationViewModel.InfraredModel>();
                sbRefresh.BindCommand(CalibrationViewModel.VM, () => CalibrationViewModel.ExecuteCommand.ec_RefreshInfrared);
                AddBinding(teCalibrationAverageNumber.Name, fluent.SetBinding(teCalibrationAverageNumber, ce => ce.Text, x => x.CalibrateAverageNumber, m => { return m.ToString(); }));
                AddBinding(teAverageNumber.Name, fluent.SetBinding(teAverageNumber, ce => ce.Text, x => x.AverageNumber, m => { return m.ToString(); }));
                AddBinding(tePhase.Name, fluent.SetBinding(tePhase, ce => ce.Text, x => x.Phase, m => { return m.ToString(); }));
                AddBinding(teGain.Name, fluent.SetBinding(teGain, ce => ce.Text, x => x.Gain, m => { return m.ToString(); }));
                AddBinding(teSamplingPeriod.Name, fluent.SetBinding(teSamplingPeriod, ce => ce.Text, x => x.SamplingPeriod, m => { return m.ToString(); }));
                AddBinding(teCoreTemperature.Name, fluent.SetBinding(teCoreTemperature, ce => ce.Text, x => x.CoreTemperature, m => { return m.ToString(); }));
                AddBinding(teWorkingCurrent.Name, fluent.SetBinding(teWorkingCurrent, ce => ce.Text, x => x.WorkingCurrent, m => { return m.ToString(); }));
                AddBinding(teScanningCurrent.Name, fluent.SetBinding(teScanningCurrent, ce => ce.Text, x => x.ScanningCurrent, m => { return m.ToString(); }));
                AddBinding(teSineCurrent.Name, fluent.SetBinding(teSineCurrent, ce => ce.Text, x => x.SineCurrent, m => { return m.ToString(); }));
                AddBinding(teCOAbsorptionBandStart.Name, fluent.SetBinding(teCOAbsorptionBandStart, ce => ce.Text, x => x.AbsorptionBand1Start, m => { return m.ToString(); }));
                AddBinding(teCOAbsorptionBandEnd.Name, fluent.SetBinding(teCOAbsorptionBandEnd, ce => ce.Text, x => x.AbsorptionBand1End, m => { return m.ToString(); }));
                AddBinding(teCO2AbsorptionBandStart.Name, fluent.SetBinding(teCO2AbsorptionBandStart, ce => ce.Text, x => x.AbsorptionBand2Start, m => { return m.ToString(); }));
                AddBinding(teCO2AbsorptionBandEnd.Name, fluent.SetBinding(teCO2AbsorptionBandEnd, ce => ce.Text, x => x.AbsorptionBand2End, m => { return m.ToString(); }));
                AddBinding(fluent.SetBinding(lcAverageIntensityValue, ce => ce.Text, x => x.AverageIntensity, m => { return m.ToString("f2"); }));
                AddBinding(teIntensityFullRangeOfInfrared.Name, fluent.SetBinding(teIntensityFullRangeOfInfrared, ce => ce.Text, x => x.IntensityFullRange, m => { return m.ToString(); }));
                AddBinding(teIntensityAlarmRangeStartOfInfrared.Name, fluent.SetBinding(teIntensityAlarmRangeStartOfInfrared, ce => ce.Text, x => x.IntensityAlarmStart, m => { return m.ToString(); }));
                AddBinding(teIntensityAlarmRangeEndOfInfrared.Name, fluent.SetBinding(teIntensityAlarmRangeEndOfInfrared, ce => ce.Text, x => x.IntensityAlarmEnd, m => { return m.ToString(); }));
                AddBinding(teLightThresholdOfInfrared.Name, fluent.SetBinding(teLightThresholdOfInfrared, ce => ce.Text, x => x.LightThreshold, m => { return m.ToString(); }));
                AddBinding(ceAutoPhaseLocking.Name, fluent.SetBinding(ceAutoPhaseLocking, ce => ce.Checked, x => x.AutoPhaseLocking, m => { return m; }));
                AddBinding(teFilteringTimeConstant.Name, fluent.SetBinding(teFilteringTimeConstant, ce => ce.Text, x => x.FilteringTimeConstant, m => { return m.ToString(); }));
                AddBinding(teTriggerDelay.Name, fluent.SetBinding(teTriggerDelay, ce => ce.Text, x => x.TriggerDelay, m => { return m.ToString(); }));
                AddBinding(tePhaseLockCoefficient.Name, fluent.SetBinding(tePhaseLockCoefficient, ce => ce.Text, x => x.PhaseCorrectCoef, m => { return m.ToString(); }));

                Messenger.Default.Register<string>(this, typeof(CalibrationViewModel.InfraredModel).Name, action);
                CalibrationViewModel.VM.ModelChanged += (sender, arg) => {
                    if (arg.ModelName == typeof(CalibrationViewModel).Name || arg.ModelName == typeof(CalibrationViewModel.InfraredModel).Name) action();
                };
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        //public override void sbSetup_Click(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    CalibrationViewModel.VM.Execute(new ArrayList() { CalibrationViewModel.ExecuteCommand.ec_SetInfrared });
        //    //    string log = "";
        //    //    log += lcCOAbsorptionBand.Text + ":" + teCOAbsorptionBandStart.Text + "-" + teCOAbsorptionBandEnd.Text+" ";
        //    //    log += lcCO2AbsorptionBand.Text + ":" + teCO2AbsorptionBandStart.Text + "-" + teCO2AbsorptionBandEnd.Text + " ";
        //    //    log += lcSamplingPeriod.Text + ":" + teSamplingPeriod.Text + " ";
        //    //    log += lcCalibrationAverageNumber.Text + ":" + teCalibrationAverageNumber.Text + " ";
        //    //    log += lcAverageNumber.Text + ":" + teAverageNumber.Text + " ";
        //    //    log += lcWorkingCurrent.Text + ":" + teWorkingCurrent.Text + " ";
        //    //    log += lcScanningCurrent.Text + ":" + teScanningCurrent.Text + " ";
        //    //    log += lcSineCurrent.Text + ":" + teSineCurrent.Text + " ";
        //    //    log += lcFilteringTimeConstant.Text + ":" + teFilteringTimeConstant.Text + " ";
        //    //    log += lcTriggerDelay.Text + ":" + teTriggerDelay.Text + " ";
        //    //    log += lcIntensityFullRange.Text + ":" + teIntensityFullRangeOfInfrared.Text + " ";
        //    //    log += lcIntensityAlarmRange.Text + ":" + teIntensityAlarmRangeStartOfInfrared.Text + "-" + teIntensityAlarmRangeEndOfInfrared.Text + " ";
        //    //    log += lcAutoPhaseLocking.Text + ":" + ceAutoPhaseLocking.Checked.ToString () + " ";
        //    //    log += lcPhaseLockCoefficient.Text + ":" + tePhaseLockCoefficient.Text + " ";
        //    //    log += lcPhase.Text + ":" + tePhase.Text + " ";
        //    //    log += lcGain.Text + ":" + teGain.Text + " ";
        //    //    log += lcCoreTemperature.Text + ":" + teCoreTemperature.Text + " ";
        //    //    log += lcLightThreshold.Text + ":" + teLightThresholdOfInfrared.Text + " ";
        //    //    if (log != "") ErrorLog.ParamChanged(System.DateTime.Now, log, this.OwnerForm.GetUserName());
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    ErrorLog.Error(ex.ToString ());
        //    //}
        //}
        public override void sbSetup_Click(object sender, EventArgs e)
        {
            CalibrationViewModel.VM.Execute(CalibrationViewModel.ExecuteCommand.ec_SetInfrared);
            base.sbSetup_Click(sender,e);
        }
    }
}
