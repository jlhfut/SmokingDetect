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
using Newtonsoft.Json.Linq;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucDataMessageDieselCar : ucBase
    {
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        public ucDataMessageDieselCar()
        {
            InitializeComponent();
            InitializeUI();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }

        protected override void InitializeBindings()
        {
            try
            {
                mvvmContext1.SetViewModel(typeof(ResultDataViewModel), ResultDataViewModel.VM);
                fluent = mvvmContext1.OfType<ResultDataViewModel>();
                //ResultDataViewModel.VM.Execute(new List<object> {
                //ResultDataViewModel.ExecuteCommand.ec_QueryDieselCarLimiting});
                AddBinding(fluent.SetBinding(lcBlacknessValue, lc => lc.Text, x => x.QueryCarLimitingInfoEntities, m =>
                {
                    if (m == null||m.DieselCarLimitInfo==null) return "0";
                    string s = m.DieselCarLimitInfo.BlacknessLimiting.ToString();
                    return ConvertIntToRoma(s);

                }));
                AddBinding(fluent.SetBinding(lcNoValue, lc => lc.Text, x => x.QueryCarLimitingInfoEntities, m =>
                {
                    if (m == null || m.DieselCarLimitInfo == null) return "0";
                    return m.DieselCarLimitInfo.NOLimiting.ToString("f2");
                }));
                AddBinding(fluent.SetBinding(lcOpSmokeValue, lc => lc.Text, x => x.QueryCarLimitingInfoEntities, m =>
                {
                    if (m == null || m.DieselCarLimitInfo == null) return "0";
                    return m.DieselCarLimitInfo.OpSmokeLimiting.ToString("f2");
                }));


                ResultDataViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(ResultDataViewModel).Name) action();
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
        }
        private string ConvertIntToRoma(string e)
        {
            switch (e)
            {
                case "1":
                    return "Ⅰ";
                case "2":
                    return "Ⅱ";
                case "3":
                    return "Ⅲ";
                case "4":
                    return "Ⅳ";
                case "5":
                    return "Ⅴ";
                case "6":
                    return "Ⅵ";
                default:
                    return "0";
            }
        }
    }
}
