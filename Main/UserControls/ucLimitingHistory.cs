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
using Wayee.Services;
using System.Collections;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucLimitingHistory : ucBase
    {
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        public ucLimitingHistory()
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
                mvvmContext1.SetViewModel(typeof(ResultDataViewModel), ResultDataViewModel.VM);
                fluent = mvvmContext1.OfType<ResultDataViewModel>();
                AddBinding(fluent.SetBinding(gcDieselHistory, gControl => gControl.DataSource, x => x.DieselCarLimitingEntities, m => {
                    if (m == null) return m;
                    string s = "";
                    for (int i = 0; i < m.Count; i++)
                    {
                        s = string.Empty;
                        if (((DTDieselCarLimitingInfo)m[i]).JudgeOpSmoke.Value.ToString()=="1")
                            s += Program.infoResource.GetLocalizedString(language.InfoId.OpacitySmaking) + ">" + ((DTDieselCarLimitingInfo)m[i]).JudgeOpSmokeValue.ToString() + "%";
                        if (((DTDieselCarLimitingInfo)m[i]).JudgeYellowCar.Value.ToString() == "1")
                            s += (s != string.Empty ? "," : "" )+ Program.infoResource.GetLocalizedString(language.InfoId.YellowCar);
                        ((DTDieselCarLimitingInfo)m[i]).Description.Value = s;
                        ((DTDieselCarLimitingInfo)m[i]).Serial.Value = i+1;
                    }
                    return m;
                }));
                AddBinding(fluent.SetBinding(gcGasolineHistory, gControl => gControl.DataSource, x => x.GasolineLimitingEntities, m => {
                    if (m == null) return m;
                    for (int j = 0; j < m.Count; j++)
                    {
                        ((DTGasolineLimitingInfo)m[j]).Serial.Value = j+1;
                    }
                    return m;
                }));
                QueryForReflash();
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        public void QueryForReflash()
        {
            //ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryDieselCarLimiting });
            //ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryGasolineLimiting });
            ResultDataViewModel.VM.ModelChanged += (sender, arg) =>
            {
                if (arg.ModelName == typeof(ResultDataViewModel).Name) action();
            };
        }
        /// <summary>
        /// mvvm action
        /// </summary>
        /// <param name="json"></param>
        protected override void doAction(string json = "")
        {
            base.doAction();
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "BlacknessLimiting" || e.Value==null) return;
            switch (e.Value.ToString ())
            {
                case "1":
                    e.DisplayText = "Ⅰ";
                    break;
                case "2":
                    e.DisplayText = "Ⅱ";
                    break;
                case "3":
                    e.DisplayText = "Ⅲ";
                    break;
                case "4":
                    e.DisplayText = "Ⅳ";
                    break;
                case "5":
                    e.DisplayText = "Ⅴ";
                    break;
                case "6":
                    e.DisplayText = "Ⅵ";
                    break;
            }
        }
    }
}
