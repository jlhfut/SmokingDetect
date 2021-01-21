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
using DevExpress.Mvvm;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucCalibrationParamter : ucBase
    {
        private bool _Click = false;
        private MVVMContextFluentAPI<CalibrationViewModel.ParamterModel> fluent;
        public ucCalibrationParamter()
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
                mvvmContext1.SetViewModel(typeof(CalibrationViewModel.ParamterModel), CalibrationViewModel.VM.CalibrationParamter);
                fluent = mvvmContext1.OfType<CalibrationViewModel.ParamterModel>();
                AddBinding(fluent.SetBinding(ceStandardValve1, ce => ce.Checked, x => x.StandardValve1));
                AddBinding(fluent.SetBinding(ceStandardValve2, ce => ce.Checked, x => x.StandardValve2));
                AddBinding(fluent.SetBinding(ceAirPump, ce => ce.Checked, x => x.AirPump));
                AddBinding(fluent.SetBinding(ceDeuteriumLamp, ce => ce.Checked, x => x.DeuteriumLamp));
                AddBinding(fluent.SetBinding(lcOpacityValue, lc => lc.Text, x => x.OpSmoke, m => { return m.ToString("f2"); }));

                Messenger.Default.Register<string>(this, typeof(CalibrationViewModel.ParamterModel).Name, action);
                CalibrationViewModel.VM.ModelChanged += (sender, arg) => {
                    if (arg.ModelName == typeof(CalibrationViewModel).Name || arg.ModelName == typeof(CalibrationViewModel.InfraredModel).Name) action();
                };
                
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void ce_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            string logCheckedToUnchecked = Program.infoResource.GetLocalizedString(language.InfoId.Checked) + "->" + Program.infoResource.GetLocalizedString(language.InfoId.Unchecked);
            string logUncheckedToChecked = Program.infoResource.GetLocalizedString(language.InfoId.Unchecked) + "->" + Program.infoResource.GetLocalizedString(language.InfoId.Checked);
            try
            {
                if(_Click)
                {
                    if (sender == ceStandardValve1)
                    {
                        CalibrationViewModel.VM.CalibrationParamter.SetValve(1, !ceStandardValve1.Checked);
                        ErrorLog.ParamChanged(DateTime.Now, 
                            lcStandardValve1.Text + ":" + (ceStandardValve1.Checked ? logCheckedToUnchecked : logUncheckedToChecked), 
                            this.OwnerForm.GetUserName());
                    }
                    if (sender == ceStandardValve2)
                    {
                        CalibrationViewModel.VM.CalibrationParamter.SetValve(2, !ceStandardValve2.Checked);
                        ErrorLog.ParamChanged(DateTime.Now,
                           lcStandardValve2.Text + ":" + (ceStandardValve2.Checked ? logCheckedToUnchecked : logUncheckedToChecked),
                           this.OwnerForm.GetUserName());
                    }
                    if (sender == ceAirPump)
                    {
                        CalibrationViewModel.VM.CalibrationParamter.SetAirPump(!ceAirPump.Checked);
                        ErrorLog.ParamChanged(DateTime.Now,
                         lcAirPump.Text + ":" + (ceAirPump.Checked ? logCheckedToUnchecked : logUncheckedToChecked),
                         this.OwnerForm.GetUserName());
                    }
                    if (sender == ceDeuteriumLamp)
                    {
                        CalibrationViewModel.VM.CalibrationParamter.SetDeuteriumLamp(!ceDeuteriumLamp.Checked);
                        ErrorLog.ParamChanged(DateTime.Now,
                       lcDeuteriumLamp.Text + ":" + (ceDeuteriumLamp.Checked ? logCheckedToUnchecked : logUncheckedToChecked),
                       this.OwnerForm.GetUserName());
                    }
                    e.Cancel = true;
                    _Click = false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void ce_Click(object sender, EventArgs e)
        {
            _Click = true;
        }
    }
}
