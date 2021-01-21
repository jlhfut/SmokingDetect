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
using Wayee.Services;
using System.Collections;
using DevExpress.Mvvm;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucMonitoringStation : ucBase
    {
        /// <summary>
        ///站点类型 0：固定式，1：移动式
        /// </summary>
        private int _stnType = -1;
        private MVVMContextFluentAPI<RealtimeMonitorViewModel> fluent;
        public ucMonitoringStation()
        {
            InitializeComponent();
            InitializeUI();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        protected override void InitializeBindings()
        {
            mvvmContext1.SetViewModel(typeof(RealtimeMonitorViewModel), RealtimeMonitorViewModel.VM);
            fluent = mvvmContext1.OfType<RealtimeMonitorViewModel>();
            AddBinding(fluent.SetBinding(lcStationNameValue, ce => ce.Text, x => x.GPSResult, m =>
            {
                return ResultDataViewModel.VM.OtherParamEntities == null || ResultDataViewModel.VM.OtherParamEntities.Count == 0 ?
                    "" : ((DTOtherParamInfo)ResultDataViewModel.VM.OtherParamEntities[0]).Name.ToString();
            }));
            AddBinding(fluent.SetBinding(lcLongitudeValue, ce => ce.Text, x => x.GPSResult, m =>
            {
                if (_stnType == 0)
                {
                    ArrayList rs = ResultDataViewModel.VM.OtherParamEntities;
                    if (rs.Count < 1 || rs[0] == null) return "0";
                    return ((DTOtherParamInfo)rs[0]).Longitude.Value == null ? "0" : ((DTOtherParamInfo)rs[0]).Longitude.Value.ToString();
                }
                else
                {
                    if (m == null) return "0";
                    return m.TESTLNG.ToString("f5");
                }
            }));
            AddBinding(fluent.SetBinding(lcLatitudeValue, ce => ce.Text, x => x.GPSResult, m =>
            {
                if (_stnType == 0)
                {
                    ArrayList rs = ResultDataViewModel.VM.OtherParamEntities;
                    if (rs.Count < 1 || rs[0] == null) return "0";
                    return ((DTOtherParamInfo)rs[0]).Latitude.Value == null ? "0" : ((DTOtherParamInfo)rs[0]).Latitude.Value.ToString();
                }
                else
                {
                    if (m == null) return "0";
                    return m.TESTLAT.ToString("f5");
                }
            }));
            AddBinding(fluent.SetBinding(lcSlopeValue, ce => ce.Text, x => x.GPSResult, m =>
            {return ResultDataViewModel.VM.OtherParamEntities == null || ResultDataViewModel.VM.OtherParamEntities.Count == 0 ?
                   "" : ((DTOtherParamInfo)ResultDataViewModel.VM.OtherParamEntities[0]).Slope.ToString();
            }));
            Messenger.Default.Register<string>(this, typeof(RealtimeMonitorViewModel.MonitoringResultModel).Name, action);
            RealtimeMonitorViewModel.VM.ModelChanged += (sender, arg) =>
            {
                if (arg.ModelName == typeof(RealtimeMonitorViewModel.MonitoringResultModel).Name)
                {
                    if (RealtimeMonitorViewModel.VM.Entities.Count == 0) return;
                    action();
                }
            };

            base.InitializeBindings();
        }
    }
}
