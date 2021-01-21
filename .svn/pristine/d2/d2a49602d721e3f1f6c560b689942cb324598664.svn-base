using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.plugin;
using DevExpress.Utils.MVVM;
using Wayee.Services;
using DevExpress.XtraEditors;
using wayeal.os.exhaust.Forms;
using DevExpress.XtraSplashScreen;
using wayeal.os.exhaust;
using Newtonsoft.Json.Linq;

namespace wayeal.exdevice
{
    public partial class ucDeviceBase : ucPluginBase
    {
        private bool _Dispose = false;
        protected bool _Busy = false;
        protected List<IPropertyBinding> _BindingList = new List<IPropertyBinding>();
        protected Dictionary<string, IPropertyBinding> _BindingList2 = new Dictionary<string, IPropertyBinding>();
        string _colon = ":";
        string _space = "  ";
        public ucDeviceBase()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
               // ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        ~ucDeviceBase()
        {
            _Dispose = true;
        }

        //protected override void OnVisibleChanged(EventArgs e)
        //{
        //    if (this.Visible) action();
        //    base.OnVisibleChanged(e);            
        //}
        
        /// <summary>
        /// Init
        /// </summary>
        protected virtual void InitializeBindings()
        {
            doAction();
        }
        /// <summary>
        /// 增加绑定
        /// </summary>
        /// <param name="binding">绑定结果</param>
        protected virtual void AddBinding(IPropertyBinding binding)
        {
            _BindingList.Add(binding);
        }
        /// <summary>
        /// 增加绑定
        /// </summary>
        /// <param name="controlName">控件名</param>
        /// <param name="binding">绑定结果</param>
        protected virtual void AddBinding(string controlName, IPropertyBinding binding)
        {
            _BindingList2.Add(controlName, binding);
        }

        private delegate void doActionDelegate(string json);
        /// <summary>
        /// mvvm action
        /// </summary>
        /// <param name="json"></param>
        protected virtual void action(string json = "")
        {
            //GC.Collect();
            if (_Dispose) return;

            if (this.InvokeRequired)
            {
                doActionDelegate d = new doActionDelegate(doAction);
                this.BeginInvoke(d, json);
            }
            else
            {
                if (_Busy) return;
                try
                {
                    _Busy = true;
                    doAction(json);
                }
                finally
                {
                    _Busy = false;
                }
            }
        }

        protected virtual void doAction(string json = "")
        {
            if (json != "")
            {
                string[] controlsName= json.Split(',');
                foreach (string name in controlsName)
                {
                    try
                    {
                        IPropertyBinding b;
                        _BindingList2.TryGetValue(name, out b);
                        b.UpdateTarget();
                    }
                    catch
                    {
                        continue;
                    }
                }
                return;
            }
            foreach (IPropertyBinding b in _BindingList) if (b != null) b.UpdateTarget();
            object o = null;
            foreach (string k in _BindingList2.Keys)
            {
                o = this.GetType().GetField(k, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                if ((o is TextEdit && !(o as TextEdit).IsEditorActive) || (o is ComboBoxEdit && !(o as ComboBoxEdit).IsPopupOpen) || (o is CheckEdit && !(o as CheckEdit).IsEditorActive))
                {
                    try
                    {
                        if (_BindingList2[k] != null) _BindingList2[k].UpdateTarget();
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
        }
        /// <summary>
        /// 保存设备参数修改
        /// </summary>
        /// <param name="diviceName">设备名</param>
        /// <param name="com">设备通讯</param>
        /// <param name="intUsed">是否启用</param>
        /// <param name="Param">其他参数</param>
        protected virtual bool SaveDeviceComChanges(DeviceCommViewModel.DeviceName diviceName,string com=null,string intUsed=null,string Param=null)
        {
            //开启等待窗口
            //SplashScreenManager.ShowForm(this.ParentForm, typeof(wfMain), false, true);
            DeviceCommViewModel.VM.Execute(new List<object> {
               DeviceCommViewModel.ExecuteCommand.ec_SaveDeviceChange,
               diviceName.ToString(),
               com,
               intUsed,
               Param,
           });
            WriteLog(diviceName, com, intUsed, Param);
            if (!DeviceCommViewModel.VM.SaveDeviceChangeEntities /*&& DeviceCommViewModel.VM.SendDeviceToSOAEntities.Result*/)
            {
                //XtraMessageBox.Show(SaveCompleted.Text);
                //return true;
                ErrorLog.Error(SaveFail.Text);
                XtraMessageBox.Show(SaveFail.Text);
                return false;
            }
            //XtraMessageBox.Show(SaveFail.Text);
            //return false;
            return true;
         }
        /// <summary>
        /// 回溯更改
        /// </summary>
        /// <returns></returns>
        protected virtual bool BackDeviceComChanges(DTDeviceInfo dt)
        {
            if (dt == null || dt.Name == null||dt.Name.Value==null) return false;
            DeviceCommViewModel.VM.Execute(new List<object> {
               DeviceCommViewModel.ExecuteCommand.ec_SaveDeviceChange,
               dt.Name.Value.ToString(),
               dt.Commuunication.Value,
               dt.Used.Value,
               dt.Param.Value,
           });
            return DeviceCommViewModel.VM.SaveComChangeEntities;
        }
        /// <summary>
        /// 按钮使能
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="buttons"></param>
        protected virtual void ButtonEnable(bool enable,SimpleButton[] buttons)
        {
            if (buttons == null || buttons.Count() == 0) return;
            for (int i = 0; i < buttons.Count(); i++)
            {
                buttons[i].Enabled = enable;
                buttons[i].Appearance.BackColor =enable? Color.FromArgb(32, 88, 165) : Color.DarkGray;
            }
        }
        private void WriteLog(DeviceCommViewModel.DeviceName diviceName, string com = null, string intUsed = null, string Param = null)
        {
            string log = lcSaveDevice.Text + _space;
            log += lcDeviceName.Text + _colon + diviceName.ToString() + _space;
            log += lcComName.Text + _colon + com + _space;
            if (intUsed != null) log += lcUseDevice.Text + _colon +( intUsed.Trim() == "1" ? lcUseDevice.Text : lcNotUseDevice.Text);
            if (Param != null)
            {
                try
                {
                    if (diviceName == DeviceCommViewModel.DeviceName.LicenseRecog || diviceName == DeviceCommViewModel.DeviceName.SecurityCamera)
                    {
                        object o = JsonNewtonsoft.FromJSON(Param);
                        if (o is JObject && o != null)
                        {
                            log +=_space+ gcUserName.Text + _colon + (o as JObject)["userName"].ToString() + _space;
                            log +=_space+ lcPassword2.Text + _colon + (o as JObject)["Password"].ToString() + _space;
                        }

                    }
                    if (diviceName == DeviceCommViewModel.DeviceName.Plat)
                    {
                        log += lcPlatNum.Text + _colon + Param + _space;
                    }
                }
                catch { }
            }
            ErrorLog.SystemLog(DateTime.Now, log);
        }
        class DeviceInfo
        {
            /// <summary>
            /// 设备名称
            /// </summary>
            public string Name;
            /// <summary>
            /// 通讯名
            /// </summary>
            public string Communication;
            /// <summary>
            /// 是否启用
            /// </summary>
            public int Used;
            /// <summary>
            /// 参数
            /// </summary>
            public string Param;
        }
    }
}
