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
    public partial class ucCalibrationConcentrationView : ucBase
    {
        private MVVMContextFluentAPI<CalibrationViewModel.ComponentModel> fluent;
        public ucCalibrationConcentrationView()
        {
            InitializeComponent();
            InitializeUI();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }

        /// <summary>
        /// Init
        /// </summary>
        protected override void InitializeBindings()
        {
            try
            {
                Utils.SetSeries(cccCO.ccSpectrum.Series[0]);
                Utils.SetSeries(cccCO2.ccSpectrum.Series[0]);
                Utils.SetSeries(cccHC.ccSpectrum.Series[0]);
                Utils.SetSeries(cccNO.ccSpectrum.Series[0]);
                Utils.SetSeries(cccOpacity.ccSpectrum.Series[0]);
                mvvmContext1.SetViewModel(typeof(CalibrationViewModel.ComponentModel), CalibrationViewModel.VM.Component);
                fluent = mvvmContext1.OfType<CalibrationViewModel.ComponentModel>();
                AddBinding(fluent.SetBinding(cccCO.ccSpectrum.Series[0], g => g.DataSource, x => x.OriginalCO, model => { return Utils.FillDataSource(model.ToArray()); }));          
                AddBinding(fluent.SetBinding(cccCO2.ccSpectrum.Series[0], g => g.DataSource, x => x.OriginalCO2, model => { return Utils.FillDataSource(model.ToArray()); }));
                AddBinding(fluent.SetBinding(cccHC.ccSpectrum.Series[0], g => g.DataSource, x => x.OriginalHC, model => { return Utils.FillDataSource(model.ToArray()); }));
                AddBinding(fluent.SetBinding(cccNO.ccSpectrum.Series[0], g => g.DataSource, x => x.OriginalNO, model => { return Utils.FillDataSource(model.ToArray()); }));
                AddBinding(fluent.SetBinding(cccOpacity.ccSpectrum.Series[0], g => g.DataSource, x => x.OpSmoke, model => { return Utils.FillDataSource(model.ToArray()); }));

                AddBinding(fluent.SetBinding(cccCO, c => c.Value, x => x.OriginalCO, m => { return m.Count == 0 ? "0" : m[m.Count - 1].ToString("f2"); }));
                AddBinding(fluent.SetBinding(cccCO2, c => c.Value, x => x.OriginalCO2, m => { return m.Count == 0 ? "0" : m[m.Count - 1].ToString("f2"); }));
                AddBinding(fluent.SetBinding(cccHC, c => c.Value, x => x.OriginalHC, m => { return m.Count == 0 ? "0" : m[m.Count - 1].ToString("f2"); }));
                AddBinding(fluent.SetBinding(cccNO, c => c.Value, x => x.OriginalNO, m => { return m.Count == 0 ? "0" : m[m.Count - 1].ToString("f2"); }));
                AddBinding(fluent.SetBinding(cccOpacity, c => c.Value, x => x.OpSmoke, m => { return m.Count == 0 ? "0" : m[m.Count - 1].ToString("f2"); }));

                Messenger.Default.Register<string>(this, typeof(CalibrationViewModel.ComponentModel).Name, action);
                CalibrationViewModel.VM.ModelChanged += (sender, arg) => {
                    if (arg.ModelName == typeof(CalibrationViewModel).Name || arg.ModelName == typeof(CalibrationViewModel.ComponentModel).Name) action();
                };
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            foreach(ucBase uc in this.Controls )
            {
                uc.Height = (this.Height-this.Padding.Top-this.Padding.Bottom) / this.Controls.Count;
            }
        }
    }
}
