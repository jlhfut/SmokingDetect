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

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucCalibrationUltravioletController : ucSettingsBase
    {
        private MVVMContextFluentAPI<CalibrationViewModel.UltravioletModel> fluent;
        public ucCalibrationUltravioletController()
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
                mvvmContext1.SetViewModel(typeof(CalibrationViewModel.UltravioletModel), CalibrationViewModel.VM.Ultraviolet);
                fluent= mvvmContext1.OfType<CalibrationViewModel.UltravioletModel>();
                AddBinding(teCalibrationAverageNumber.Name, fluent.SetBinding(teCalibrationAverageNumber, ce => ce.Text, x => x.CalibrateAverageNumber));
                AddBinding(teMainBoardAverageNumber.Name, fluent.SetBinding(teMainBoardAverageNumber, ce => ce.Text, x => x.MainBoardAverageNumber));
                AddBinding(teSpectrometerAverageNumber.Name, fluent.SetBinding(teSpectrometerAverageNumber, ce => ce.Text, x => x.SpectrometerAverageNumber));
                AddBinding(teNOAbsorptionBandStart.Name, fluent.SetBinding(teNOAbsorptionBandStart, ce => ce.Text, x => x.AbsorptionBand1Start));
                AddBinding(teNOAbsorptionBandEnd.Name, fluent.SetBinding(teNOAbsorptionBandEnd, ce => ce.Text, x => x.AbsorptionBand1End));
                AddBinding(teHCAbsorptionBandStart.Name, fluent.SetBinding(teHCAbsorptionBandStart, ce => ce.Text, x => x.AbsorptionBand2Start));
                AddBinding(teHCAbsorptionBandEnd.Name, fluent.SetBinding(teHCAbsorptionBandEnd, ce => ce.Text, x => x.AbsorptionBand2End));
                AddBinding(teIntegralTime.Name, fluent.SetBinding(teIntegralTime, ce => ce.Text, x => x.IntegralTime));

                AddBinding(fluent.SetBinding(lcAverageIntensityValue, ce => ce.Text, x => x.AverageIntensity, m => { return m.ToString("f2"); }));
                AddBinding(teIntensityFullRange.Name, fluent.SetBinding(teIntensityFullRange, ce => ce.Text, x => x.IntensityFullRange));
                AddBinding(teIntensityAlarmRangeStart.Name, fluent.SetBinding(teIntensityAlarmRangeStart, ce => ce.Text, x => x.IntensityAlarmStart));
                AddBinding(teIntensityAlarmRangeEnd.Name, fluent.SetBinding(teIntensityAlarmRangeEnd, ce => ce.Text, x => x.IntensityAlarmEnd));
                AddBinding(teIntensityRangeStart.Name, fluent.SetBinding(teIntensityRangeStart, ce => ce.Text, x => x.IntensityRangeStart));
                AddBinding(teIntensityRangeEnd.Name, fluent.SetBinding(teIntensityRangeEnd, ce => ce.Text, x => x.IntensityRangeEnd));
                AddBinding(teFilteringTimeConstant.Name, fluent.SetBinding(teFilteringTimeConstant, ce => ce.Text, x => x.FilteringTimeConstant));

          //      sbSetup.BindCommand(CalibrationViewModel.VM, () => CalibrationViewModel.ExecuteCommand.ec_SetUltraviolet);
                sbRefresh.BindCommand(CalibrationViewModel.VM, () => CalibrationViewModel.ExecuteCommand.ec_RefreshUltraviolet);
                Messenger.Default.Register<string>(this, typeof(CalibrationViewModel.UltravioletModel).Name, action);
                CalibrationViewModel.VM.ModelChanged += (sender, arg) => {
                    if (arg.ModelName == typeof(CalibrationViewModel).Name || arg.ModelName == typeof(CalibrationViewModel.UltravioletModel).Name) action();
                };
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }

        }
        public override void sbSetup_Click(object sender, EventArgs e)
        {
            CalibrationViewModel.VM.Execute(CalibrationViewModel.ExecuteCommand.ec_SetUltraviolet);
            base.sbSetup_Click(sender, e);
        }
    }
}
