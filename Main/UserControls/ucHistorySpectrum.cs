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
using DevExpress.XtraCharts;
using DevExpress.Mvvm;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucHistorySpectrum : ucBase
    {
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        public ucHistorySpectrum()
        {
            InitializeComponent();
            InitializeUI();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        private void ucCalibrationSpectrumView_Resize(object sender, EventArgs e)
        {
            try
            {
                ccUltravioletSpectrumHT.Height = this.Parent.Height / 2 - 3;
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
                Utils.SetChart(ccUltravioletSpectrumHT);
                Utils.SetSeries(ccUltravioletSpectrumHT.Series[0]);
                Utils.SetSeries(ccUltravioletSpectrumHT.Series[1]);
     //           Utils.SetSeries(ccUltravioletSpectrumHT.Series[2]);
                Utils.SetChart(ccInfraredSpectrumHT);
                Utils.SetSeries(ccInfraredSpectrumHT.Series[0]);
         //       Utils.SetSeries(ccInfraredSpectrumHT.Series[1]);
                mvvmContext1.SetViewModel(typeof(ResultDataViewModel), ResultDataViewModel.VM);
                fluent = mvvmContext1.OfType<ResultDataViewModel>();

                //紫外实时光谱无  
                //AddBinding(fluent.SetBinding(ccUltravioletSpectrum.Series[0], g => g.DataSource, x => x.QuerySpectrumEntities.ZeroIntensity, model => { return Utils.FillDataSource(model); }));
                //紫外背景谱图
                AddBinding(fluent.SetBinding(ccUltravioletSpectrumHT.Series[0], g => g.DataSource, x => x.ExhaustDetailData, model => {
                    if (model == null || model.UVSCalParam == null || model.UVSCalParam.ZeroIntensity == null) return null;
                    return this.FillDataSource(model.UVSCalParam.ZeroIntensity); }));
                //紫外遥测光谱暂无
                AddBinding(fluent.SetBinding(ccUltravioletSpectrumHT.Series[1], g => g.DataSource, x => x.ExhaustDetailData, model => {
                    if (model == null || model.UVSData == null ) return null;
                    return this.FillDataSource(model.UVSData); }));
                //红外实时光谱无   
                //AddBinding(fluent.SetBinding(ccInfraredSpectrum.Series[0], g => g.DataSource, x => x.QuerySpectrumEntities.InfraredSpectrum, model => { return Utils.FillDataSource(model); }));
                //红外背景谱图
                AddBinding(fluent.SetBinding(ccInfraredSpectrumHT.Series[0], g => g.DataSource, x => x.ExhaustDetailData, model => {
                    if (model == null || model.TDLASCalParam == null || model.TDLASCalParam.ZeroIntensity == null) return null;
                    return this.FillDataSource(model.TDLASCalParam.ZeroIntensity); }));

                //紫外吸收带起点
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletSpectrumHT.Diagram).AxisX.ConstantLines[0], d => d.AxisValue, x => x.uvNOParam.Start));
                //紫外吸收带终点
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletSpectrumHT.Diagram).AxisX.ConstantLines[2], d => d.AxisValue, x => x.uvNOParam.End));
                // 红外吸收带起点
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletSpectrumHT.Diagram).AxisX.ConstantLines[3], d => d.AxisValue, x => x.uvHCParam.Start));
                //红外吸收带终点
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccUltravioletSpectrumHT.Diagram).AxisX.ConstantLines[5], d => d.AxisValue, x => x.uvHCParam.End));

                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredSpectrumHT.Diagram).AxisX.ConstantLines[0], d => d.AxisValue, x => x.tdlasCOParam.Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredSpectrumHT.Diagram).AxisX.ConstantLines[2], d => d.AxisValue, x => x.tdlasCOParam.End));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredSpectrumHT.Diagram).AxisX.ConstantLines[3], d => d.AxisValue, x => x.tdlasCO2Param.Start));
                AddBinding(fluent.SetBinding(((SwiftPlotDiagram)ccInfraredSpectrumHT.Diagram).AxisX.ConstantLines[5], d => d.AxisValue, x => x.tdlasCO2Param.End));

                Messenger.Default.Register<string>(this, typeof(ResultDataViewModel.ExhaustDetailDataModel).Name, action);
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
            ((SwiftPlotDiagram)ccUltravioletSpectrumHT.Diagram).AxisX.ConstantLines[0].Color = Color.FromArgb(129, 0, 0);
            ((SwiftPlotDiagram)ccUltravioletSpectrumHT.Diagram).AxisX.ConstantLines[2].Color = Color.FromArgb(129, 0, 0);
            ((SwiftPlotDiagram)ccUltravioletSpectrumHT.Diagram).AxisX.ConstantLines[3].Color = Color.FromArgb(79, 97, 40);
            ((SwiftPlotDiagram)ccUltravioletSpectrumHT.Diagram).AxisX.ConstantLines[5].Color = Color.FromArgb(79, 97, 40);
            ((SwiftPlotDiagram)ccInfraredSpectrumHT.Diagram).AxisX.ConstantLines[0].Color = Color.FromArgb(129, 0, 0);
            ((SwiftPlotDiagram)ccInfraredSpectrumHT.Diagram).AxisX.ConstantLines[2].Color = Color.FromArgb(129, 0, 0);
            ((SwiftPlotDiagram)ccInfraredSpectrumHT.Diagram).AxisX.ConstantLines[3].Color = Color.FromArgb(79, 97, 40);
            ((SwiftPlotDiagram)ccInfraredSpectrumHT.Diagram).AxisX.ConstantLines[5].Color = Color.FromArgb(79, 97, 40);
        }

        public DataTable FillDataSource<T>(T ls)
        {
            if (ls == null) return null;
            if (ls is List<double>)
            {
                List<double> lf = ls as List<double>;
                if (lf == null || lf.Count == 0) return null;
                string x = "Argument";
                string y = "Value";
                DataTable table = new DataTable("Table");
                table.Columns.Add(x, typeof(int));
                table.Columns.Add(y, typeof(double));
                DataRow row = null;
                for (int i = 0; i < lf.Count; i++)
                {
                    row = table.NewRow();
                    row[x] = i;
                    row[y] = lf[i];
                    table.Rows.Add(row);
                }
                return table;
            }
            if (ls is List<short>)
            {
                List<short> lf = ls as List<short>;
                if (lf == null || lf.Count == 0) return null;
                string x = "Argument";
                string y = "Value";
                DataTable table = new DataTable("Table");
                table.Columns.Add(x, typeof(int));
                table.Columns.Add(y, typeof(short));
                DataRow row = null;
                for (int i = 0; i < lf.Count; i++)
                {
                    row = table.NewRow();
                    row[x] = i;
                    row[y] = lf[i];
                    table.Rows.Add(row);
                }
                return table;
            }
            return null;
        }
    }
}

 
