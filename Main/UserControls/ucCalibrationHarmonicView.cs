﻿using System;
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
using DevExpress.XtraCharts;
using DevExpress.Utils.MVVM;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucCalibrationHarmonicView : ucBase
    {
        private MVVMContextFluentAPI<CalibrationViewModel> fluent;
        public ucCalibrationHarmonicView()
        {
            InitializeComponent();
            InitializeUI();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }

        private void ucCalibrationHarmonicView_Resize(object sender, EventArgs e)
        {
            try
            {
                ccUltraviolet.Height = this.Parent.Height / 2 - 3;
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
                Utils.SetChart(ccUltraviolet);
                Utils.SetSeries(ccUltraviolet.Series[0]);
                Utils.SetSeries(ccUltraviolet.Series[1]);
                Utils.SetSeries(ccUltraviolet.Series[2]);
                Utils.SetSeries(ccUltraviolet.Series[3]);
                Utils.SetChart(ccInfrared);
                Utils.SetSeries(ccInfrared.Series[0]);
                Utils.SetSeries(ccInfrared.Series[1]);
                Utils.SetSeries(ccInfrared.Series[2]);
                Utils.SetSeries(ccInfrared.Series[3]);
                Utils.SetSeries(ccInfrared.Series[4]);

                mvvmContext1.SetViewModel(typeof(CalibrationViewModel), CalibrationViewModel.VM);
                fluent = mvvmContext1.OfType<CalibrationViewModel>();

                AddBinding(fluent.SetBinding(ccUltraviolet.Series[0], g => g.DataSource, x => x.AbsortHarmonicData.UltravioletSpectrum, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccUltraviolet.Series[1], g => g.DataSource, x => x.AbsortHarmonicData.UltravioletNO, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccUltraviolet.Series[2], g => g.DataSource, x => x.AbsortHarmonicData.UltravioletHC, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccUltraviolet.Series[3], g => g.DataSource, x => x.AbsortHarmonicData.UltravioletTelemetry, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccInfrared.Series[0], g => g.DataSource, x => x.AbsortHarmonicData.InfraredSpectrum, model => { calcMax(); return Utils.FillDataSource(model); }));

                AddBinding(fluent.SetBinding(ccInfrared.Series[1], g => g.DataSource, x => x.AbsortHarmonicData.InfraredCO, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccInfrared.Series[2], g => g.DataSource, x => x.AbsortHarmonicData.InfraredCO2, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccInfrared.Series[3], g => g.DataSource, x => x.AbsortHarmonicData.InfraredBgSpectrum, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccInfrared.Series[4], g => g.DataSource, x => x.AbsortHarmonicData.InfraredTelemetry, model => { return Utils.FillDataSource(model); }));

                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltraviolet.Diagram).AxisX.ConstantLines[0], d => d.AxisValue, x => x.Ultraviolet.AbsorptionBand1Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltraviolet.Diagram).AxisX.ConstantLines[2], d => d.AxisValue, x => x.Ultraviolet.AbsorptionBand1End));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltraviolet.Diagram).AxisX.ConstantLines[3], d => d.AxisValue, x => x.Ultraviolet.AbsorptionBand2Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltraviolet.Diagram).AxisX.ConstantLines[5], d => d.AxisValue, x => x.Ultraviolet.AbsorptionBand2End));

                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfrared.Diagram).AxisX.ConstantLines[0], d => d.AxisValue, x => x.Infrared.AbsorptionBand1Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfrared.Diagram).AxisX.ConstantLines[2], d => d.AxisValue, x => x.Infrared.AbsorptionBand1End));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfrared.Diagram).AxisX.ConstantLines[3], d => d.AxisValue, x => x.Infrared.AbsorptionBand2Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfrared.Diagram).AxisX.ConstantLines[5], d => d.AxisValue, x => x.Infrared.AbsorptionBand2End));

                Messenger.Default.Register<string>(this, typeof(CalibrationViewModel.AbsortHarmonicModel).Name, action);
                CalibrationViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(CalibrationViewModel).Name || arg.ModelName == typeof(CalibrationViewModel.AbsortHarmonicModel).Name ||
                    arg.ModelName == typeof(CalibrationViewModel.InfraredModel).Name) action();
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
            ((SwiftPlotDiagram)ccUltraviolet.Diagram).AxisX.ConstantLines[0].Color = Color.FromArgb(192, 0, 0);
            ((SwiftPlotDiagram)ccUltraviolet.Diagram).AxisX.ConstantLines[2].Color = Color.FromArgb(192, 0, 0);
            ((SwiftPlotDiagram)ccUltraviolet.Diagram).AxisX.ConstantLines[3].Color = Color.FromArgb(79,97,40);
            ((SwiftPlotDiagram)ccUltraviolet.Diagram).AxisX.ConstantLines[5].Color = Color.FromArgb(79, 97, 40);

            ((SwiftPlotDiagram)ccInfrared.Diagram).AxisX.ConstantLines[0].Color = Color.FromArgb(192, 0, 0);
            ((SwiftPlotDiagram)ccInfrared.Diagram).AxisX.ConstantLines[2].Color = Color.FromArgb(192, 0, 0);
            ((SwiftPlotDiagram)ccInfrared.Diagram).AxisX.ConstantLines[3].Color = Color.FromArgb(79, 97, 40);
            ((SwiftPlotDiagram)ccInfrared.Diagram).AxisX.ConstantLines[5].Color = Color.FromArgb(79, 97, 40);
        }
        /// <summary>
        /// 计算区间最大最小值
        /// </summary>
        private void calcMax()
        {
            if (CalibrationViewModel.VM.AbsortHarmonicData.InfraredSpectrum != null)
            {
                double max = 0;
                double min = 0;
                double max1 = 0;
                double min1 = 0;
                Axis2D ax = ((SwiftPlotDiagram)ccInfrared.Diagram).AxisX;
                int s = int.Parse(ax.ConstantLines[0].AxisValue.ToString());
                int e = int.Parse(ax.ConstantLines[2].AxisValue.ToString());
                int s1 = int.Parse(ax.ConstantLines[3].AxisValue.ToString());
                int e1 = int.Parse(ax.ConstantLines[5].AxisValue.ToString());
                double[] ps = CalibrationViewModel.VM.AbsortHarmonicData.InfraredSpectrum;
                for (int i = 0; i < ps.Length; i++)
                {
                    if (i > s && i < e)
                    {
                        if (max < ps[i]) max = ps[i];
                        if (min > ps[i]) min = ps[i];
                    }
                    if (i > s1 && i < e1)
                    {
                        if (max1 < ps[i]) max1 = ps[i];
                        if (min1 > ps[i]) min1 = ps[i];
                    }
                }
                ax.ConstantLines[0].Title.Text = (max - min).ToString("f2");
                ax.ConstantLines[3].Title.Text = (max1 - min1).ToString("f2");
            }
        }
    }
}
