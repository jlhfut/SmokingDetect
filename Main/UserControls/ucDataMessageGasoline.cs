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
using DevExpress.Utils.MVVM;
using Wayee.Services;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucDataMessageGasoline : ucBase
    {
       // private int index;
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        public ucDataMessageGasoline()
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
                //ResultDataViewModel.ExecuteCommand.ec_QueryGasolineLimiting});
                AddBinding(fluent.SetBinding(lcCOValue, lc => lc.Text , x => x.QueryCarLimitingInfoEntities, m =>
                {
                    if (m == null || m.GasolimitCarInfo == null) return "0";
                    return m.GasolimitCarInfo.COLimiting.ToString();
                }));
                AddBinding(fluent.SetBinding(lcNOValue, lc => lc.Text, x => x.QueryCarLimitingInfoEntities, m =>
                {
                    if (m == null || m.GasolimitCarInfo == null) return "0";
                    return m.GasolimitCarInfo.NOLimiting.ToString();
                }));
                AddBinding(fluent.SetBinding(lcHCValue, lc => lc.Text, x => x.QueryCarLimitingInfoEntities, m =>
                {
                    if (m == null || m.GasolimitCarInfo == null) return "0";
                    return m.GasolimitCarInfo.HCLimiting.ToString();
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
    }
}
