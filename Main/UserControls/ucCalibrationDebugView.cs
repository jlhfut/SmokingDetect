using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wayee.Services;
using wayeal.os.exhaust.Services;
using DevExpress.XtraCharts;
using wayeal.utils;
using wayeal.os.exhaust.ViewModel;
using DevExpress.Utils.MVVM;
using DevExpress.Mvvm;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucCalibrationDebugView : ucBase
    {
        private MVVMContextFluentAPI<CalibrationViewModel> fluent;
        public ucCalibrationDebugView ()
        {
            InitializeComponent();
            InitializeUI();

            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }

        private void ucCalibrationDebugView_Resize(object sender, EventArgs e)
        {
            try
            {
                ccUltravioletDebug.Height = this.Parent.Height / 2 - 3;
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        /// <summary>
        /// Init
        /// </summary>
        protected override void InitializeBindings()
        {
            try
            {
                Utils.SetChart(ccUltravioletDebug);
                Utils.SetSeries(ccUltravioletDebug.Series[0]);
                Utils.SetSeries(ccUltravioletDebug.Series[1]);
                Utils.SetSeries(ccUltravioletDebug.Series[2]);
                Utils.SetChart(ccInfraredDebug);
                Utils.SetSeries(ccInfraredDebug.Series[0]);
                Utils.SetSeries(ccInfraredDebug.Series[1]);
                mvvmContext1.SetViewModel(typeof(CalibrationViewModel), CalibrationViewModel.VM);
                fluent = mvvmContext1.OfType<CalibrationViewModel>();
                //AddBinding(fluent.SetBinding(ccUltravioletDebug.Series[0], g => g.DataSource, x => x.SpectrumData.UltravioletSpectrum, model => { return Utils.FillDataSource(model); }));
                //AddBinding(fluent.SetBinding(ccUltravioletDebug.Series[1], g => g.DataSource, x => x.SpectrumData.UltravioletBgSpectrum, model => { return Utils.FillDataSource(model); }));
                //AddBinding(fluent.SetBinding(ccUltravioletDebug.Series[2], g => g.DataSource, x => x.SpectrumData.TelemetrySpectrum, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccInfraredDebug.Series[0], g => g.DataSource, x => x.DebugData.InfraredActiveOriginalHarmonic, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccInfraredDebug.Series[1], g => g.DataSource, x => x.DebugData.InfraredTelemetryOriginalHarmonic, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(meHandShakeData, g => g.Text, x => x.DebugData.HandShakeData,m=> { return m!=null? m.Replace("\r\n", ""):""; }));

                //AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletDebug.Diagram).AxisX.ConstantLines[0], d => d.AxisValue, x => x.Ultraviolet.AbsorptionBand1Start));
                //AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletDebug.Diagram).AxisX.ConstantLines[2], d => d.AxisValue, x => x.Ultraviolet.AbsorptionBand1End));
                //AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletDebug.Diagram).AxisX.ConstantLines[3], d => d.AxisValue, x => x.Ultraviolet.AbsorptionBand2Start));
                //AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletDebug.Diagram).AxisX.ConstantLines[5], d => d.AxisValue, x => x.Ultraviolet.AbsorptionBand2End));

                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredDebug.Diagram).AxisX.ConstantLines[0], d => d.AxisValue, x => x.Infrared.AbsorptionBand1Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredDebug.Diagram).AxisX.ConstantLines[2], d => d.AxisValue, x => x.Infrared.AbsorptionBand1End));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredDebug.Diagram).AxisX.ConstantLines[3], d => d.AxisValue, x => x.Infrared.AbsorptionBand2Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredDebug.Diagram).AxisX.ConstantLines[5], d => d.AxisValue, x => x.Infrared.AbsorptionBand2End));

                Messenger.Default.Register<string>(this, typeof(CalibrationViewModel.DebugDataModel).Name, action);
                CalibrationViewModel.VM.ModelChanged += (sender, arg) => {
                    if (arg.ModelName == typeof(CalibrationViewModel).Name || arg.ModelName == typeof(CalibrationViewModel.DebugDataModel).Name
                     || arg.ModelName == typeof(CalibrationViewModel.InfraredModel).Name) action();
                };
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        /// <summary>
        /// mvvm action
        /// </summary>
        /// <param name="json"></param>
        protected override void doAction(string json = "")
        {
            base.doAction();
            Axis2D ax = null;
            //ax = ((SwiftPlotDiagram)ccUltravioletDebug.Diagram).AxisX;
            //ax.ConstantLines[1].AxisValue = int.Parse(ax.ConstantLines[0].AxisValue.ToString()) + (int.Parse(ax.ConstantLines[2].AxisValue.ToString()) - int.Parse(ax.ConstantLines[0].AxisValue.ToString())) / 2;
            //ax.ConstantLines[4].AxisValue = int.Parse(ax.ConstantLines[3].AxisValue.ToString()) + (int.Parse(ax.ConstantLines[5].AxisValue.ToString()) - int.Parse(ax.ConstantLines[3].AxisValue.ToString())) / 2;

            ax = ((SwiftPlotDiagram)ccInfraredDebug.Diagram).AxisX;
            ax.ConstantLines[1].AxisValue = int.Parse(ax.ConstantLines[0].AxisValue.ToString()) + (int.Parse(ax.ConstantLines[2].AxisValue.ToString()) - int.Parse(ax.ConstantLines[0].AxisValue.ToString())) / 2;
            ax.ConstantLines[4].AxisValue = int.Parse(ax.ConstantLines[3].AxisValue.ToString()) + (int.Parse(ax.ConstantLines[5].AxisValue.ToString()) - int.Parse(ax.ConstantLines[3].AxisValue.ToString())) / 2;
        }
    }
}
