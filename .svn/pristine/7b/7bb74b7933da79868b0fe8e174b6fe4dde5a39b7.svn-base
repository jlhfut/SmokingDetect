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

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucDataAnalysisData : ucBase
    {
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        public ucDataAnalysisData()
        {
            InitializeComponent();
            InitializeUI();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        protected override void InitializeBindings()
        {
            mvvmContext1.SetViewModel(typeof(ResultDataViewModel), ResultDataViewModel.VM);
            fluent = mvvmContext1.OfType<ResultDataViewModel>();
            AddBinding(fluent.SetBinding(lcNODCvalue, lc => lc.Text, x => x.ExhaustDetailData, m =>
            {
                if (m == null) return "0";
                return m.OriginalNO.ToString("f2");
            }));
            AddBinding(fluent.SetBinding(lcHCDCvalue, lc => lc.Text, x => x.ExhaustDetailData, m =>
            {
                if (m == null) return "0";
                return m.OriginalHC.ToString("f2");
            }));
            AddBinding(fluent.SetBinding(lcCODCvalue, lc => lc.Text, x => x.ExhaustDetailData, m =>
            {
                if (m == null) return "0";
                return m.OriginalCO.ToString("f2");
            }));
            AddBinding(fluent.SetBinding(lcCO2DCvalue, lc => lc.Text, x => x.ExhaustDetailData, m =>
            {
                if (m == null) return "0";
                return m.OriginalCO2.ToString("f2");
            }));
        }
    }
}
