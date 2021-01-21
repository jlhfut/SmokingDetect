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
using wayeal.os.exhaust.Modules;
using Newtonsoft.Json.Linq;
using DevExpress.XtraNavBar;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucDataAnalysisOneLane : ucBase
    {
        private string _strLane = "Left";
        int index = 0;
        ModulesNavigator viewNavigator = null;
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        private ucExhaustData ucEdata = null;
        public ucDataAnalysisOneLane()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        public ucDataAnalysisOneLane(int iIndex,ucExhaustData uc)
        {
            InitializeComponent();
            ucEdata = uc;
            index = iIndex;
            viewNavigator = new ModulesNavigator(Program.frmMain.Ribbon, pcChart);
            InitBarItemLinks();
            InitializeUI();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        protected override void InitializeBindings()
        {
            try
            {
                mvvmContext1.SetViewModel(typeof(ResultDataViewModel), ResultDataViewModel.VM);
                fluent = mvvmContext1.OfType<ResultDataViewModel>();
                #region AddBinding
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


                AddBinding(fluent.SetBinding(lcT1Value, lc => lc.Text, x => x.ExhaustDetailData, m =>
                {
                    if (m == null) return "0";
                    return m.T12.ToString();
                }));
                AddBinding(fluent.SetBinding(lcT2value, lc => lc.Text, x => x.ExhaustDetailData, m =>
                {
                    if (m == null) return "0";
                    return m.T13.ToString();
                }));
                AddBinding(fluent.SetBinding(lcLightIntensityValue, lc => lc.Text, x => x.ExhaustDetailData, m =>
                {
                    if (m == null) return "0";
                    return m.RealIntensity.ToString();
                }));
                
                AddBinding(fluent.SetBinding(lcT1Value, lc => lc.Text, x => x.ExhaustDetailData, m => { return m.T12.ToString(); }));
                AddBinding(fluent.SetBinding(lcT2value, lc => lc.Text, x => x.ExhaustDetailData, m => { return m.T13.ToString(); }));
                AddBinding(fluent.SetBinding(lcLightIntensityValue, lc => lc.Text, x => x.ExhaustDetailData, m => { return m.RealIntensity.ToString(); }));
                ResultDataViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(ResultDataViewModel).Name || arg.ModelName == typeof(ResultDataViewModel.ExhaustDetailDataModel).Name) action();
                };
                #endregion
                base.InitializeBindings();

                RefreshChartInfo(index);
            }
            catch (Exception ex)
            {
            }
        }
        public void SetLane(string Lane,int uniKeyIndex=-1)
        {
            if (Lane == "Right" || Lane == "Left")
            {
                _strLane = Lane;
            }
            if (uniKeyIndex != -1) { index = uniKeyIndex; }
            RefreshChartInfo(index);
        }
        public void RefreshChartInfo(int idx)
        {
            index = idx;
            string uniquekey =ucEdata.GetUniqueKeyByIndex(index);
            ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryDetialInfo, index, uniquekey });
            if (ResultDataViewModel.VM.DetialInfoEntities == null || ResultDataViewModel.VM.DetialInfoEntities.Count == 0) return;
            object o = ResultDataViewModel.VM.DetialInfoEntities[0];
            if (o is JObject)
            {
                JObject jo = (o as JObject);
                string value = jo["DataPath"].ToString();
                if (!string.IsNullOrEmpty(value)) ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryChartInfo, value.ToString(),_strLane });
            }
            action();
        }
        void InitBarItemLinks()
        {
            rgSpectralView.Properties.Items[0].Tag = new NavBarGroupTagObject(rgSpectralView.Properties.Items[0].Value.ToString(), typeof(UserControls.ucHistorySpectrum));
            rgSpectralView.Properties.Items[1].Tag = new NavBarGroupTagObject(rgSpectralView.Properties.Items[1].Value.ToString(), typeof(UserControls.ucHistoryHarmenic));
            rgSpectralView.SelectedIndex = 0;
        }

        private void rgSpectralView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rgSpectralView.Properties.Items[rgSpectralView.SelectedIndex].Tag != null)
                {
                    NavBarItemLink link = new NavBarItemLink(new NavBarItem(rgSpectralView.Properties.Items[rgSpectralView.SelectedIndex].Value.ToString()));
                    link.Item.Tag = rgSpectralView.Properties.Items[rgSpectralView.SelectedIndex].Tag;
                    viewNavigator.ChangeSelectedItem(link, null);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
    }
}
