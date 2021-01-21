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
using Newtonsoft.Json.Linq;
using DevExpress.Mvvm;
using DevExpress.XtraCharts;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucHistoryHarmenic : ucBase
    {
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        private int index = -1;
        public ucHistoryHarmenic()
        {
            InitializeComponent();
            InitializeUI();

            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        public ucHistoryHarmenic(int iIndex)
        {
            InitializeComponent();
            InitializeUI();
            index = iIndex;
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }

        private void ucHistoryHarmenic_Resize(object sender, EventArgs e)
        {
            try
            {
                ccUltravioletHT.Height = this.Parent.Height / 2 - 3;
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
                Utils.SetChart(ccUltravioletHT);
                Utils.SetSeries(ccUltravioletHT.Series[0]);
                Utils.SetSeries(ccUltravioletHT.Series[1]);
                Utils.SetSeries(ccUltravioletHT.Series[2]);
        //        Utils.SetSeries(ccUltravioletHT.Series[3]);
                Utils.SetChart(ccInfraredHT);
                Utils.SetSeries(ccInfraredHT.Series[0]);
                Utils.SetSeries(ccInfraredHT.Series[1]);
                Utils.SetSeries(ccInfraredHT.Series[2]);
                Utils.SetSeries(ccInfraredHT.Series[3]);
          //      Utils.SetSeries(ccInfraredHT.Series[4]);

                mvvmContext1.SetViewModel(typeof(ResultDataViewModel), ResultDataViewModel.VM);
                fluent = mvvmContext1.OfType<ResultDataViewModel>();

                ucHistorySpectrum uc = new ucHistorySpectrum();
                //   AddBinding(fluent.SetBinding(ccUltraviolet.Series[0], g => g.DataSource, x => x.QueryChartEntities.UltravioletSpectrum, model => { return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccUltravioletHT.Series[0], g => g.DataSource, x => x.ExhaustDetailData, model => {
                    if (model == null || model.UVSNOCalParam == null || model.UVSNOCalParam.Absorb == null) return null;
                    return uc.FillDataSource(model.UVSNOCalParam.Absorb); }));
                AddBinding(fluent.SetBinding(ccUltravioletHT.Series[1], g => g.DataSource, x => x.ExhaustDetailData, model => {
                    if (model == null || model.UVSHCCalParam == null || model.UVSHCCalParam.Absorb == null) return null;
                    return uc.FillDataSource(model.UVSHCCalParam.Absorb); }));
                AddBinding(fluent.SetBinding(ccUltravioletHT.Series[2], g => g.DataSource, x => x.ExhaustDetailData, model => {
                    if (model == null || model.AbsorbData == null ) return null;
                    return uc.FillDataSource(model.AbsorbData); }));
               // AddBinding(fluent.SetBinding(ccInfrared.Series[0], g => g.DataSource, x => x.QueryChartEntities.InfraredSpectrum, model => { calcMax(); return Utils.FillDataSource(model); }));
                AddBinding(fluent.SetBinding(ccInfraredHT.Series[0], g => g.DataSource, x => x.ExhaustDetailData, model => {
                    if (model == null || model.TDLASCOCalParam == null || model.TDLASCOCalParam.Harm == null) return null;
                    return uc.FillDataSource(model.TDLASCOCalParam.Harm); }));
                AddBinding(fluent.SetBinding(ccInfraredHT.Series[1], g => g.DataSource, x => x.ExhaustDetailData, model => {
                    if (model == null || model.TDLASCO2CalParam == null || model.TDLASCO2CalParam.Harm == null) return null;
                    return uc.FillDataSource(model.TDLASCO2CalParam.Harm);
                }));
                AddBinding(fluent.SetBinding(ccInfraredHT.Series[2], g => g.DataSource, x => x.ExhaustDetailData, model => {
                    if (model == null || model.TDLASCalParam == null || model.TDLASCalParam.Harm == null) return null;
                    return uc.FillDataSource(model.TDLASCalParam.Harm);
                }));
                AddBinding(fluent.SetBinding(ccInfraredHT.Series[3], g => g.DataSource, x => x.ExhaustDetailData, model => {
                    if (model == null || model.HarmData == null ) return null;
                    return uc.FillDataSource(model.HarmData);
                }));

                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletHT.Diagram).AxisX.ConstantLines[0], d => d.AxisValue, x => x.uvNOParam.Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletHT.Diagram).AxisX.ConstantLines[2], d => d.AxisValue, x => x.uvNOParam.End));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletHT.Diagram).AxisX.ConstantLines[3], d => d.AxisValue, x => x.uvHCParam.Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletHT.Diagram).AxisX.ConstantLines[5], d => d.AxisValue, x => x.uvHCParam.End));

                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredHT.Diagram).AxisX.ConstantLines[0], d => d.AxisValue, x => x.tdlasCOParam.Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredHT.Diagram).AxisX.ConstantLines[2], d => d.AxisValue, x => x.tdlasCOParam.End));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredHT.Diagram).AxisX.ConstantLines[3], d => d.AxisValue, x => x.tdlasCO2Param.Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredHT.Diagram).AxisX.ConstantLines[5], d => d.AxisValue, x => x.tdlasCO2Param.End));

                ResultDataViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(ResultDataViewModel).Name || arg.ModelName == typeof(ResultDataViewModel.ExhaustDetailDataModel).Name) action();
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
            //Axis2D ax = ((SwiftPlotDiagram)ccUltravioletSpectrum.Diagram).AxisX;
            //ax.ConstantLines[1].AxisValue = int.Parse(ax.ConstantLines[0].AxisValue.ToString()) + (int.Parse(ax.ConstantLines[2].AxisValue.ToString()) - int.Parse(ax.ConstantLines[0].AxisValue.ToString())) / 2;
            //ax.ConstantLines[4].AxisValue = int.Parse(ax.ConstantLines[3].AxisValue.ToString()) + (int.Parse(ax.ConstantLines[5].AxisValue.ToString()) - int.Parse(ax.ConstantLines[3].AxisValue.ToString())) / 2;

            //ax = ((SwiftPlotDiagram)ccInfraredSpectrum.Diagram).AxisX;
            //ax.ConstantLines[1].AxisValue = int.Parse(ax.ConstantLines[0].AxisValue.ToString()) + (int.Parse(ax.ConstantLines[2].AxisValue.ToString()) - int.Parse(ax.ConstantLines[0].AxisValue.ToString())) / 2;
            //ax.ConstantLines[4].AxisValue = int.Parse(ax.ConstantLines[3].AxisValue.ToString()) + (int.Parse(ax.ConstantLines[5].AxisValue.ToString()) - int.Parse(ax.ConstantLines[3].AxisValue.ToString())) / 2;
            ((SwiftPlotDiagram)ccUltravioletHT.Diagram).AxisX.ConstantLines[0].Color = Color.FromArgb(129, 0, 0);
            ((SwiftPlotDiagram)ccUltravioletHT.Diagram).AxisX.ConstantLines[2].Color = Color.FromArgb(129, 0, 0);
            ((SwiftPlotDiagram)ccUltravioletHT.Diagram).AxisX.ConstantLines[3].Color = Color.FromArgb(79,97,40);
            ((SwiftPlotDiagram)ccUltravioletHT.Diagram).AxisX.ConstantLines[5].Color = Color.FromArgb(79, 97, 40);
            ((SwiftPlotDiagram)ccInfraredHT.Diagram).AxisX.ConstantLines[0].Color = Color.FromArgb(129, 0, 0);
            ((SwiftPlotDiagram)ccInfraredHT.Diagram).AxisX.ConstantLines[2].Color = Color.FromArgb(129, 0, 0);
            ((SwiftPlotDiagram)ccInfraredHT.Diagram).AxisX.ConstantLines[3].Color = Color.FromArgb(79, 97, 40);
            ((SwiftPlotDiagram)ccInfraredHT.Diagram).AxisX.ConstantLines[5].Color = Color.FromArgb(79, 97, 40);
        }
        private void calcMax()
        {
            if (CalibrationViewModel.VM.AbsortHarmonicData.InfraredSpectrum != null)
            {
                double max = 0;
                double min = 0;
                double max1 = 0;
                double min1 = 0;
                Axis2D ax = ((SwiftPlotDiagram)ccInfraredHT.Diagram).AxisX;
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
        public void ExportToExcel()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Excel文件|*.xls";
            fileDialog.FileName = "WYExhaust_HC_" + DateTime.Now.ToString("yyMMddHHmm");
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ccInfraredHT.ExportToXls(fileDialog.FileName);
                ccUltravioletHT.ExportToXls(fileDialog.FileName);
                string log = Program.infoResource.GetLocalizedString(language.InfoId.DriveData) + fileDialog.FileName;
                ErrorLog.SystemLog(DateTime.Now,log, this.OwnerForm.GetUserName());
            }
        }
    }
}
