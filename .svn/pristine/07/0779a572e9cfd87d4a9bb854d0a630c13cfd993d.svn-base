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
    public partial class ucStatisticalInformation : ucBase
    {
        private MVVMContextFluentAPI<RealtimeMonitorViewModel> fluent;
        public ucStatisticalInformation()
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
                mvvmContext1.SetViewModel(typeof(RealtimeMonitorViewModel), RealtimeMonitorViewModel.VM);
                fluent = mvvmContext1.OfType<RealtimeMonitorViewModel>();
                AddBinding(fluent.SetBinding(gcDailyStatistic, gControl => gControl.DataSource, x => x.DailyStatistics,m=>m));
                AddBinding(fluent.SetBinding(gcComplexStatistic, gControl => gControl.DataSource, x => x.ComplexStatistics,m=>m));

                Messenger.Default.Register<string>(this, typeof(RealtimeMonitorViewModel.StatisticResultModel).Name, action);
                RealtimeMonitorViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(RealtimeMonitorViewModel.MonitoringResultModel).Name||
                    arg.ModelName == typeof(RealtimeMonitorViewModel.StatisticResultModel).Name)
                    {
                        action();
                    }
                };
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        protected override void doAction(string json = "")
        {
            gcDailyStatistic.DataSource = null;
            gcComplexStatistic.DataSource = null;
            base.doAction(json);
        }
        
        private void lcRefresh_Click(object sender, EventArgs e)
        {
            RealtimeMonitorViewModel.VM.UpdateStatisticList(-1,"",true);
        }
    }
}
