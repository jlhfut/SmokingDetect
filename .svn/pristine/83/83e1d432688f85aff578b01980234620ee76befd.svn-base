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
using Wayeal.Services.Configs;
using wayeal.os.exhaust.Services;
using Wayeal.Services.Business.Utils;
using DevExpress.XtraEditors;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucLimitingInfoOfGasolineCar : ucBase
    {
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        public ucLimitingInfoOfGasolineCar()
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
                ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryGasolineLimiting });

                AddBinding(fluent.SetBinding(txtNO, x => x.Text, y => y.GasolineLimitingEntities, m => {
                    if (m.Count!=0 && ((DTGasolineLimitingInfo)m[0]).NOLimiting.Value != null) { return ((DTGasolineLimitingInfo)m[0]).NOLimiting.Value.ToString(); }
                    return "2000";
                }));
                AddBinding(fluent.SetBinding(txtCO, x => x.Text, y => y.GasolineLimitingEntities, m => {
                    if (m.Count != 0 && ((DTGasolineLimitingInfo)m[0]).COLimiting.Value != null) { return ((DTGasolineLimitingInfo)m[0]).COLimiting.Value.ToString(); }
                    return "3.0";
                }));
                AddBinding(fluent.SetBinding(txtHC, x => x.Text, y => y.GasolineLimitingEntities, m => {
                    if (m.Count != 0 && ((DTGasolineLimitingInfo)m[0]).HCLimiting.Value != null) { return ((DTGasolineLimitingInfo)m[0]).HCLimiting.Value.ToString(); }
                    return "600";
                }));
                AddBinding(fluent.SetBinding(mmTips, x => x.Text, y => y.GasolineLimitingEntities, m => {
                    if (m.Count != 0 && ((DTGasolineLimitingInfo)m[0]).Tips.Value != null) { return ((DTGasolineLimitingInfo)m[0]).Tips.Value.ToString(); }
                    return null;
                }));
                ResultDataViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == ResultDataViewModel.ExecuteCommand.ec_QueryDieselCarLimiting.ToString()) action();
                };
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNO.Text.Trim() == "" || txtCO.Text.Trim() == "" || txtHC.Text.Trim() == "" || mmTips.Text.Trim() == "")
                {
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.InputNotNull));
                }
                else
                {
                    string log = Program.infoResource.GetLocalizedString(language.InfoId.LimitingInfoChange);
                    CarLimitingInfo info = new CarLimitingInfo();
                    GasolineCarInfo gaso = new GasolineCarInfo();
                    gaso.NOLimiting = Convert.ToDouble(txtNO.Text);
                    gaso.COLimiting = Convert.ToDouble(txtCO.Text);
                    gaso.HCLimiting = Convert.ToDouble(txtHC.Text);
                    info.GasolimitCarInfo = gaso;
                    string str = JsonNewtonsoft.ToJSON(info);
                    if (str != "")
                    {
                        BusinessResult br = BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.SetCarLimitInfo, str, BusinessType.Set);
                        if (br == null || !br.Result)
                        {
                            XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.SaveFail));
                            log += Program.infoResource.GetLocalizedString(language.InfoId.OperateFail);
                            ErrorLog.SystemLog(DateTime.Now, log, this.OwnerForm.GetUserName());
                            return;
                        }
                    }
                    ResultDataViewModel.VM.Execute(new List<object>{
                    ResultDataViewModel.ExecuteCommand.ec_InsertGasolineLimiting,
                    System.DateTime.Now,
                    txtNO.Text,
                    txtCO.Text,
                    txtHC.Text,
                    mmTips.Text});
                    log += lcNOLimiting.Text + ":" + txtNO.Text;
                    log += lcCOLimiting.Text + ":" + txtCO.Text;
                    log += lcHCLimiting.Text + ":" + txtHC.Text;
                    log += lcTips.Text + ":" + mmTips.Text;
                    if (ResultDataViewModel.VM.InsertGasolineLimitingResult)
                    {
                        log += Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess);
                        XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.SaveCompleted));

                    }
                    else
                    {
                        log += Program.infoResource.GetLocalizedString(language.InfoId.OperateFail);
                        XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.SaveFail));
                    }
                    ErrorLog.SystemLog(DateTime.Now, log, this.OwnerForm.GetUserName());
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            //if (ResultDataViewModel.VM.GasolineLimitingEntities.Count > 0)
            //{
                action();
            //}
        }
    }
}
