using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wayee.Services;
using wayeal.os.exhaust.Services;
using DevExpress.Mvvm;
using wayeal.os.exhaust.ViewModel;
using DevExpress.Utils.MVVM;
using Newtonsoft.Json.Linq;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucMonitoringComponent : ucBase
    {
        private string[] Lingmann = new string[6] { "Ⅰ", "Ⅱ", "Ⅲ", "Ⅳ", "Ⅴ", "Ⅵ" };
        private MVVMContextFluentAPI<RealtimeMonitorViewModel> fluent;
        public ucMonitoringComponent()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            doResize(this);
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
                AddBinding(fluent.SetBinding(uccCO, ce => ce.ComponentValue, x => x.Entities, m => {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        return ((m[0] as JObject)["CO"]) == null ? "" : Convert.ToDouble((m[0] as JObject)["CO"]).ToString("f2");
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); return "0"; }
                }));
                AddBinding(fluent.SetBinding(uccCO2, ce => ce.ComponentValue, x => x.Entities, m => {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        return ((m[0] as JObject)["CO2"]) == null ? "" : Convert.ToDouble((m[0] as JObject)["CO2"]).ToString("f2");
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); return "0"; }
                }));
                AddBinding(fluent.SetBinding(uccHC, ce => ce.ComponentValue, x => x.Entities, m => {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        return ((m[0] as JObject)["HC"]) == null ? "" : Convert.ToDouble((m[0] as JObject)["HC"]).ToString("f2");
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); return "0"; }
                }));
                AddBinding(fluent.SetBinding(uccNO, ce => ce.ComponentValue, x => x.Entities, m => {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        return ((m[0] as JObject)["NO"]) == null ? "" : Convert.ToDouble((m[0] as JObject)["NO"]).ToString("f2");
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); return "0"; }
                }));
                AddBinding(fluent.SetBinding(uccLingmannblackness, ce => ce.ComponentValue, x => x.Entities, m => 
                {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        string s = ((m[0] as JObject)["Blackness"]) == null ? "0" : ((m[0] as JObject)["Blackness"]).ToString();
                        switch (s)
                        {
                            case "0":
                                return "0";
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
                            default: return s;
                        }
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); return "0"; }
                }));
                AddBinding(fluent.SetBinding(uccOpaquesSmoke, ce => ce.ComponentValue, x => x.Entities, m => {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        return ((m[0] as JObject)["OpSmoke"]) == null ? "" : Convert.ToDouble((m[0] as JObject)["OpSmoke"]).ToString("f2");
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); return "0"; }
                }));
                AddBinding(fluent.SetBinding(uccResult, ce => ce.ComponentValue, x => x.Entities, m =>
                {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        int i= ((m[0] as JObject)["Result"]) == null ? -1 : Convert.ToInt32((m[0] as JObject)["Result"]);
                    
                    string rs = Program.infoResource.GetLocalizedString(language.InfoId.Invalid);
                    switch (i)
                    {
                        case -1:
                            break;
                        case 0:
                            rs = Program.infoResource.GetLocalizedString(language.InfoId.Disqualified);
                            break;
                        case 1:
                            rs = Program.infoResource.GetLocalizedString(language.InfoId.Qualified);
                            break;
                    }
                    uccResult.ValueForeColor = rs == Program.infoResource.GetLocalizedString(language.InfoId.Disqualified) ? Color.Red : uccResult.ForeColor;
                    return rs;
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); return Program.infoResource.GetLocalizedString(language.InfoId.Invalid); }
                }));

                AddBinding(fluent.SetBinding(uccCO, ce => ce.ValueForeColor, x => x.Component.COPollution, m => { return m ? Color.Red : uccCO.ForeColor; }));
                AddBinding(fluent.SetBinding(uccHC, ce => ce.ValueForeColor, x => x.Component.HCPollution, m => { return m ? Color.Red : uccHC.ForeColor; }));
                AddBinding(fluent.SetBinding(uccNO, ce => ce.ValueForeColor, x => x.Component.NOPollution, m => { return m ? Color.Red : uccNO.ForeColor; }));
                AddBinding(fluent.SetBinding(uccLingmannblackness, ce => ce.ValueForeColor, x => x.Component.BlacknessPollution, m => { return m ? Color.Red : uccLingmannblackness.ForeColor; }));
                AddBinding(fluent.SetBinding(uccOpaquesSmoke, ce => ce.ValueForeColor, x => x.Component.OpSmokePollution, m => { return m ? Color.Red : uccOpaquesSmoke.ForeColor; }));

                Messenger.Default.Register<string>(this, typeof(RealtimeMonitorViewModel.ComponentModel).Name, action);
                RealtimeMonitorViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(RealtimeMonitorViewModel.MonitoringResultModel).Name || arg.ModelName == typeof(RealtimeMonitorViewModel.ComponentModel).Name) action();
                };
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        /// <summary>
        /// resize companent
        /// </summary>
        private void doResize(Control p)
        {
            try
            {
                int h = (this.Height - 20) / 4;
                foreach (Control c in p.Controls)
                {
                    if (c.Controls.Count > 0) doResize(c);
                    if (c is ucComponent)
                    {
                        (c as ucComponent).Height = h;
                    }
                }
                pcClient1.Width = this.ClientSize.Width / 2-4;
                pcClient2.Width = pcClient1.Width;
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
    }
}
