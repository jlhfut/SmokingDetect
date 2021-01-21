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
using Newtonsoft.Json.Linq;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucDataAnalysisCalculation : ucBase
    {
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        public ucDataAnalysisCalculation()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        protected override void InitializeBindings()
        {
            try
            {
                #region AddBinding
                mvvmContext1.SetViewModel(typeof(ResultDataViewModel), ResultDataViewModel.VM);
                fluent = mvvmContext1.OfType<ResultDataViewModel>();
                AddBinding(fluent.SetBinding(lcCOValue, lc => lc.Text, x => x.DetialInfoEntities, m =>
                {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        object o = JsonNewtonsoft.FromJSON(m[0].ToString());
                        if (o is JObject)
                        {
                            JObject jo = (o as JObject);
                            string value = jo["CO"].ToString();
                            if (!string.IsNullOrEmpty(value)) return Convert.ToDouble(value).ToString("f2");
                        }
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); }
                    return "0";
                }));
                AddBinding(fluent.SetBinding(lcNOValue, lc => lc.Text, x => x.DetialInfoEntities, m =>
                {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        object o = JsonNewtonsoft.FromJSON(m[0].ToString());
                        if (o is JObject)
                        {
                            JObject jo = (o as JObject);
                            string value = jo["NO"].ToString();
                            if (!string.IsNullOrEmpty(value)) return Convert.ToDouble(value).ToString("f2");
                        }
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); }

                    return "0";
                }));
                AddBinding(fluent.SetBinding(lcHCValue, lc => lc.Text, x => x.DetialInfoEntities, m =>
                {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        object o = JsonNewtonsoft.FromJSON(m[0].ToString());
                        if (o is JObject)
                        {
                            JObject jo = (o as JObject);
                            string value = jo["HC"].ToString();
                            if (!string.IsNullOrEmpty(value)) return Convert.ToDouble(value).ToString("f2");
                        }
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); }

                    return "0";
                }));
                AddBinding(fluent.SetBinding(lcCO2Value, lc => lc.Text, x => x.DetialInfoEntities, m =>
                {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        object o = JsonNewtonsoft.FromJSON(m[0].ToString());
                        if (o is JObject)
                        {
                            JObject jo = (o as JObject);
                            string value = jo["CO2"].ToString();
                            if (!string.IsNullOrEmpty(value)) return Convert.ToDouble(value.ToString()).ToString("f2");
                        }
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); }

                    return "0";
                }));
                AddBinding(fluent.SetBinding(lcOpsmokeValue, lc => lc.Text, x => x.DetialInfoEntities, m =>
                {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        object o = JsonNewtonsoft.FromJSON(m[0].ToString());
                        if (o is JObject)
                        {
                            JObject jo = (o as JObject);
                            string value = jo["OpSmoke"].ToString();
                            if (!string.IsNullOrEmpty(value)) return Convert.ToDouble(value.ToString()).ToString("f2");
                        }
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); }

                    return "0";
                }));
                AddBinding(fluent.SetBinding(lcBlacknessValue, lc => lc.Text, x => x.DetialInfoEntities, m =>
                {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        object o = JsonNewtonsoft.FromJSON(m[0].ToString());
                        if (o is JObject)
                        {
                            JObject jo = (o as JObject);
                            string value = jo["Blackness"].ToString();
                            if (!string.IsNullOrEmpty(value)) return ConvertIntToRoma(value.ToString());
                        }
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); }

                    return "0";
                }));
                AddBinding(fluent.SetBinding(lcNumberValue, lc => lc.Text, x => x.DetialInfoEntities, m =>
                {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        object o = JsonNewtonsoft.FromJSON(m[0].ToString());
                        if (o is JObject)
                        {
                            JObject jo = (o as JObject);
                            string value = jo["UniqueKey"].ToString();
                            if (!string.IsNullOrEmpty(value)) return value.ToString();
                        }
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); }

                    return "0";
                }));
                AddBinding(fluent.SetBinding(lcResultValue, lc => lc.Text, x => x.DetialInfoEntities, m =>
                {
                    try
                    {
                        if (m == null || m.Count == 0) return "0";
                        object o = JsonNewtonsoft.FromJSON(m[0].ToString());
                        if (o is JObject)
                        {
                            JObject jo = (o as JObject);
                            string value = jo["Result"].ToString();
                            switch (Convert.ToInt32(value) + 1)
                            {
                                case 1:
                                    return Program.infoResource.GetLocalizedString(language.InfoId.Disqualified);
                                case 2:
                                    return Program.infoResource.GetLocalizedString(language.InfoId.Qualified);
                                case 3:
                                    return Program.infoResource.GetLocalizedString(language.InfoId.Invalid);
                            }
                        }
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); }

                    return "0";
                }));
                #endregion
                ResultDataViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(ResultDataViewModel).Name || arg.ModelName == typeof(ResultDataViewModel.ExhaustDetailDataModel).Name) action();
                };
            }
            catch (Exception ex)
            {
            }
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
