using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using wayeal.os.exhaust.ViewModel;
using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;

namespace wayeal.os.exhaust.Forms
{
    public partial class wfOpacityCalibration : wfBase
    {
        private MVVMContextFluentAPI<CalibrationViewModel> fluent;
        public wfOpacityCalibration()
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
                InitializeUI();
                mvvmContext1.SetViewModel(typeof(CalibrationViewModel), CalibrationViewModel.VM);
                fluent = mvvmContext1.OfType<CalibrationViewModel>();

                AddBinding(fluent.SetBinding(teRealtimeIntensity_1, ce => ce.Text, x => x.CalibrationIntensity.CalibrationValue1));
                AddBinding(teCalibrationValue_1.Name,fluent.SetBinding(teCalibrationValue_1, ce => ce.Text, x => x.CalibrationIntensity.RealtimeIntensity1));
                AddBinding(fluent.SetBinding(teRealtimeIntensity_2, ce => ce.Text, x => x.CalibrationIntensity.CalibrationValue2));
                AddBinding(teCalibrationValue_2.Name,fluent.SetBinding(teCalibrationValue_2, ce => ce.Text, x => x.CalibrationIntensity.RealtimeIntensity2));
                AddBinding(fluent.SetBinding(teRealtimeIntensity_3, ce => ce.Text, x => x.CalibrationIntensity.CalibrationValue3));
                AddBinding(teCalibrationValue_3.Name,fluent.SetBinding(teCalibrationValue_3, ce => ce.Text, x => x.CalibrationIntensity.RealtimeIntensity3));
                AddBinding(fluent.SetBinding(teRealtimeIntensity_4, ce => ce.Text, x => x.CalibrationIntensity.CalibrationValue4));
                AddBinding(teCalibrationValue_4.Name,fluent.SetBinding(teCalibrationValue_4, ce => ce.Text, x => x.CalibrationIntensity.RealtimeIntensity4));
                AddBinding(fluent.SetBinding(teRealtimeIntensity_5, ce => ce.Text, x => x.CalibrationIntensity.CalibrationValue5));
                AddBinding(teCalibrationValue_5.Name,fluent.SetBinding(teCalibrationValue_5, ce => ce.Text, x => x.CalibrationIntensity.RealtimeIntensity5));

                AddBinding(fluent.SetBinding(lcRealtimeIntensity, lc => lc.Text, x => x.CalibrationIntensity.OpSmoke));

                AddBinding(fluent.SetBinding(teA, ce => ce.Text, x => x.CalibrationIntensity.CoefficientA, model => { return model.ToString("f4"); }));
                AddBinding(fluent.SetBinding(teB, ce => ce.Text, x => x.CalibrationIntensity.CoefficientB, model => { return model.ToString("f4"); }));
                AddBinding(fluent.SetBinding(teC, ce => ce.Text, x => x.CalibrationIntensity.CoefficientC, model => { return model.ToString("f4"); }));
                AddBinding(fluent.SetBinding(teK, ce => ce.Text, x => x.CalibrationIntensity.CoefficientK, model => { return model.ToString("f4"); }));

                AddBinding(fluent.SetBinding(teZeroIntensityCoef, ce => ce.Text, x => x.CalibrationIntensity.ZeroIntensityCoef, model => { return model.ToString("f2"); }));

                //AddBinding(fluent.SetBinding(cbeChannelIndex, lc => lc.SelectedIndex, x => x.CalibrationIntensityIndex));

                sbCalculate.BindCommand(CalibrationViewModel.VM, () => CalibrationViewModel.ExecuteCommand.ec_CalculateCoefficient);
             //   sbSave.BindCommand(CalibrationViewModel.VM, () => CalibrationViewModel.ExecuteCommand.ec_SaveCoefficient);
                cbeChannelIndex.SelectedValueChanged += (sender, args) => {
                    CalibrationViewModel.VM.CalibrationIntensityIndex = cbeChannelIndex.SelectedIndex;
                    action();
                };
                Messenger.Default.Register<string>(this, typeof(CalibrationViewModel.CalibrationIntensityModel).Name, action);
                CalibrationViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(CalibrationViewModel).Name || arg.ModelName == typeof(CalibrationViewModel.CalibrationIntensityModel).Name) action();
                };
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void Calibrate_Click(object sender, EventArgs e)
        {
            try
            {
                string profix = teRealtimeIntensity_1.Name.Substring(0, teRealtimeIntensity_1.Name.Length - 1);
                string name = profix + (sender == sbCalibratei ? "1" : ((SimpleButton)sender).Name.Substring(((SimpleButton)sender).Name.Length - 1, 1));
                Control c = Controls.Find(name, true)[0];
                string old = ((TextEdit)c).Text;
                ((TextEdit)c).Text =  lcRealtimeIntensity.Text;
                
                if(sender==sbCalibratei && float.Parse(old)!=0)
                {
                    float v = (float.Parse(((TextEdit)c).Text) - float.Parse(old)) / float.Parse(old);
                    for (int i = 2; i <= 5; i++)
                    {
                        c = Controls.Find(profix + i.ToString(), true)[0];
                        ((TextEdit)c).Text= (float.Parse(((TextEdit)c).Text) * v+ float.Parse(((TextEdit)c).Text)).ToString("f0");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            CalibrationViewModel.VM.Execute(CalibrationViewModel.ExecuteCommand.ec_SaveCoefficient);
            string log = this.Text + "  " + lcChannelIndex.Text + ":" + cbeChannelIndex.SelectedItem.ToString() + "  ";
            log += sliGroup1.Text + ":" + teCalibrationValue_1.Text + " ";
            log += sliGroup2.Text + ":" + teCalibrationValue_2.Text + " ";
            log += sliGroup3.Text + ":" + teCalibrationValue_3.Text + " ";
            log += sliGroup4.Text + ":" + teCalibrationValue_4.Text + " ";
            log += sliGroup5.Text + ":" + teCalibrationValue_5.Text + " ";
            ErrorLog.ParamChanged(DateTime.Now,log, frmMain.UserName);
        }
    }
}