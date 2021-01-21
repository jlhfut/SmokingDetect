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
    public partial class ucCalibrationSpectrumView : ucBase
    {
        private MVVMContextFluentAPI<CalibrationViewModel> fluent;
        public ucCalibrationSpectrumView()
        {
            InitializeComponent();
            InitializeUI();

            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }

        private void ucCalibrationSpectrumView_Resize(object sender, EventArgs e)
        {
            try
            {
                ccUltravioletSpectrum.Height = this.Parent.Height / 2 - 3;
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
                Utils.SetChart(ccUltravioletSpectrum);
                Utils.SetSeries(ccUltravioletSpectrum.Series[0]);
                Utils.SetSeries(ccUltravioletSpectrum.Series[1]);
                Utils.SetSeries(ccUltravioletSpectrum.Series[2]);
                Utils.SetChart(ccInfraredSpectrum);
                Utils.SetSeries(ccInfraredSpectrum.Series[0]);
                Utils.SetSeries(ccInfraredSpectrum.Series[1]);
                mvvmContext1.SetViewModel(typeof(CalibrationViewModel), CalibrationViewModel.VM);
                fluent = mvvmContext1.OfType<CalibrationViewModel>();
                AddBinding(fluent.SetBinding(ccUltravioletSpectrum.Series[0], g => g.DataSource, x => x.SpectrumData.UltravioletSpectrum, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccUltravioletSpectrum.Series[1], g => g.DataSource, x => x.SpectrumData.UltravioletBgSpectrum, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccUltravioletSpectrum.Series[2], g => g.DataSource, x => x.SpectrumData.TelemetrySpectrum, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccInfraredSpectrum.Series[0], g => g.DataSource, x => x.SpectrumData.InfraredSpectrum, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccInfraredSpectrum.Series[1], g => g.DataSource, x => x.SpectrumData.InfraredBgSpectrum, model => { return Utils.FillDataSource(model); }));

                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletSpectrum.Diagram).AxisX.ConstantLines[0], d => d.AxisValue, x => x.Ultraviolet.AbsorptionBand1Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletSpectrum.Diagram).AxisX.ConstantLines[2], d => d.AxisValue, x => x.Ultraviolet.AbsorptionBand1End));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletSpectrum.Diagram).AxisX.ConstantLines[3], d => d.AxisValue, x => x.Ultraviolet.AbsorptionBand2Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletSpectrum.Diagram).AxisX.ConstantLines[5], d => d.AxisValue, x => x.Ultraviolet.AbsorptionBand2End));

                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredSpectrum.Diagram).AxisX.ConstantLines[0], d => d.AxisValue, x => x.Infrared.AbsorptionBand1Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredSpectrum.Diagram).AxisX.ConstantLines[2], d => d.AxisValue, x => x.Infrared.AbsorptionBand1End));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredSpectrum.Diagram).AxisX.ConstantLines[3], d => d.AxisValue, x => x.Infrared.AbsorptionBand2Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredSpectrum.Diagram).AxisX.ConstantLines[5], d => d.AxisValue, x => x.Infrared.AbsorptionBand2End));

                Messenger.Default.Register<string>(this, typeof(CalibrationViewModel.SpectrumDataModel).Name, action);
                CalibrationViewModel.VM.ModelChanged += (sender, arg) => {
                    if (arg.ModelName == typeof(CalibrationViewModel).Name || arg.ModelName == typeof(CalibrationViewModel.SpectrumDataModel).Name
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
            Axis2D ax = ((SwiftPlotDiagram)ccUltravioletSpectrum.Diagram).AxisX;
            ax.ConstantLines[1].AxisValue = int.Parse(ax.ConstantLines[0].AxisValue.ToString()) + (int.Parse(ax.ConstantLines[2].AxisValue.ToString()) - int.Parse(ax.ConstantLines[0].AxisValue.ToString())) / 2;
            ax.ConstantLines[4].AxisValue = int.Parse(ax.ConstantLines[3].AxisValue.ToString()) + (int.Parse(ax.ConstantLines[5].AxisValue.ToString()) - int.Parse(ax.ConstantLines[3].AxisValue.ToString())) / 2;

            ax = ((SwiftPlotDiagram)ccInfraredSpectrum.Diagram).AxisX;
            ax.ConstantLines[1].AxisValue = int.Parse(ax.ConstantLines[0].AxisValue.ToString()) + (int.Parse(ax.ConstantLines[2].AxisValue.ToString()) - int.Parse(ax.ConstantLines[0].AxisValue.ToString())) / 2;
            ax.ConstantLines[4].AxisValue = int.Parse(ax.ConstantLines[3].AxisValue.ToString()) + (int.Parse(ax.ConstantLines[5].AxisValue.ToString()) - int.Parse(ax.ConstantLines[3].AxisValue.ToString())) / 2;

            ((SwiftPlotDiagram)ccUltravioletSpectrum.Diagram).AxisX.ConstantLines[0].Color = Color.FromArgb(192, 0, 0);
            ((SwiftPlotDiagram)ccUltravioletSpectrum.Diagram).AxisX.ConstantLines[2].Color = Color.FromArgb(192, 0, 0);
            ((SwiftPlotDiagram)ccUltravioletSpectrum.Diagram).AxisX.ConstantLines[3].Color = Color.FromArgb(79, 97, 40);
            ((SwiftPlotDiagram)ccUltravioletSpectrum.Diagram).AxisX.ConstantLines[5].Color = Color.FromArgb(79, 97, 40);

            ((SwiftPlotDiagram)ccInfraredSpectrum.Diagram).AxisX.ConstantLines[0].Color = Color.FromArgb(192, 0, 0);
            ((SwiftPlotDiagram)ccInfraredSpectrum.Diagram).AxisX.ConstantLines[2].Color = Color.FromArgb(192, 0, 0);
            ((SwiftPlotDiagram)ccInfraredSpectrum.Diagram).AxisX.ConstantLines[3].Color = Color.FromArgb(79, 97, 40);
            ((SwiftPlotDiagram)ccInfraredSpectrum.Diagram).AxisX.ConstantLines[5].Color = Color.FromArgb(79, 97, 40);
        }

    }
}
