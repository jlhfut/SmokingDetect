using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.Modules;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucSettingsBase : ucBase
    {
        public ucSettingsBase()
        {
            InitializeComponent();
        }

        public virtual void sbSetup_Click(object sender, EventArgs e)
        {
            //记录参数更改日志,遍历dictionary获取text值是否改变了
            if (ucConcentrationCalibrator.DicRecordLog == null || ucConcentrationCalibrator.DicRecordLog.Count == 0) return;
            string log = null;
            Dictionary<Control, string>.KeyCollection kc = ucConcentrationCalibrator.DicRecordLog.Keys;
            for (int i = 0; i < kc.Count; i++)
            {
                string change = null;
                string value = null;
                Control c = kc.ElementAtOrDefault(i);
                if (!ucConcentrationCalibrator.DicRecordLog.TryGetValue(c, out value)) return;
                change = JointLog(c, value);
                if (change != null)
                {
                    if(c is DevExpress.XtraEditors.CheckEdit)
                        ucConcentrationCalibrator.DicRecordLog[c] =( c as DevExpress.XtraEditors.CheckEdit).EditValue.ToString();
                    if(c is DevExpress.XtraEditors.TextEdit)
                        ucConcentrationCalibrator.DicRecordLog[c] = c.Text;
                    if(c is DevExpress.XtraEditors.ComboBoxEdit)
                        ucConcentrationCalibrator.DicRecordLog[c] = (c as DevExpress.XtraEditors.ComboBoxEdit).SelectedItem.ToString();
                    log += change;
                }
            }
            if (log == null) return;
            ErrorLog.ParamChanged(DateTime.Now, log, this.OwnerForm.GetUserName());

        }
        /// <summary>
        /// 拼接日志字符串
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string JointLog(Control key, string value)
        {
            string NowValue=value;
            string log = null;
            try
            {
                if (key is DevExpress.XtraEditors.CheckEdit)
                {
                    NowValue = (key as DevExpress.XtraEditors.CheckEdit).EditValue.ToString();
                }
                if (key is DevExpress.XtraEditors.TextEdit)
                {
                    NowValue = key.Text;
                }
                if (key is DevExpress.XtraEditors.ComboBoxEdit)
                {
                    NowValue = (key as DevExpress.XtraEditors.ComboBoxEdit).SelectedItem.ToString();
                }
                if (NowValue == value) return null;
                if (key.Tag != null)
                {
                    bool IsControlExist = false;
                    //用tag将对应的label和text绑定起来，便于中英文切换记日志
                    foreach (Control c in ucConcentrationCalibrator.SettingControl)
                    {
                        if (c.Name == key.Tag.ToString())
                        {
                            IsControlExist = true;
                            log += c.Text + ":" + value + "->" + NowValue+" ";
                            return log;
                        }
                    }
                    //如果不方便绑控件，就直接用tag里的值
                    if (IsControlExist == false)
                        log += key.Tag + ":" + value + "->" + NowValue+" ";
                    IsControlExist = false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
            return log;
        }
       
    }
}
