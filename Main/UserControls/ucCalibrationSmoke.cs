using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.MVVM;
using wayeal.os.exhaust.ViewModel;
using DevExpress.Mvvm;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucCalibrationSmokeController : ucSettingsBase
    {
        private MVVMContextFluentAPI<CalibrationViewModel.SmokeModel> fluent;
        public ucCalibrationSmokeController()
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
                mvvmContext1.SetViewModel(typeof(CalibrationViewModel.SmokeModel), CalibrationViewModel.VM.Smoke);
                fluent = mvvmContext1.OfType<CalibrationViewModel.SmokeModel>();
         //       sbSetup.BindCommand(CalibrationViewModel.VM, () => CalibrationViewModel.ExecuteCommand.ec_SetSmoke);
                sbRefresh.BindCommand(CalibrationViewModel.VM, () => CalibrationViewModel.ExecuteCommand.ec_RefreshSmoke);
                AddBinding(teAverageNumber.Name, fluent.SetBinding(teAverageNumber, ce => ce.Text, x => x.AverageNumber));
                AddBinding(teLightThresholdOfSmoke.Name, fluent.SetBinding(teLightThresholdOfSmoke, ce => ce.Text, x => x.LightThreshold));
                AddBinding(teFilteringTimeConstant.Name, fluent.SetBinding(teFilteringTimeConstant, ce => ce.Text, x => x.FilteringTimeConstant));

                Messenger.Default.Register<string>(this, typeof(CalibrationViewModel.SmokeModel).Name, action);
                CalibrationViewModel.VM.ModelChanged += (sender, arg) => {
                    if (arg.ModelName == typeof(CalibrationViewModel).Name || arg.ModelName == typeof(CalibrationViewModel.SmokeModel).Name) action();
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
            CalibrationViewModel.VM.Execute(CalibrationViewModel.ExecuteCommand.ec_SetSmoke);
            base.sbSetup_Click(sender, e);
        }
    }
}
