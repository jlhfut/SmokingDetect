using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.ViewModel;
using Wayee.Services;

namespace wayeal.os.exhaust.Forms
{
    public partial class wfLogin : wfBase
    {
        public static string userName;
        public static int permission;
        public const string uName = "userName";
        public const string pwd = "password";
        public const string isRemember = "isRemember";

        public wfLogin()
        {
            InitializeComponent();
            InitializeUI();
        }
        private void sbExit_Click(object sender, EventArgs e)
        {
            tePassword.Properties.Mask.UseMaskAsDisplayFormat = false;
            this.DialogResult = DialogResult.Cancel;
        }

        private void sbLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void tePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)   //  if (e.KeyValue == 13) 判断是回车键
            {
                this.Focus();
                Login();
            }
        }

        private void Login()
        {
            try
            {
                string name = teName.Text;
                string pwd = tePassword.Text;
                if (teName.Text.Trim() != "" && tePassword.Text.Trim() != "")
                {
                    ResultDataViewModel.VM.Execute(new List<object> {
                    ResultDataViewModel.ExecuteCommand.ec_QueryLogin,
                    name,
                    pwd
                    });
                    if (ResultDataViewModel.VM.LoginEntities.Count > 0 && ResultDataViewModel.VM.LoginEntities[0] != null)
                    {
                        string log = Program.infoResource.GetLocalizedString(language.InfoId.Login);
                        if (ResultDataViewModel.VM.LoginEntities == null || ResultDataViewModel.VM.LoginEntities.Count < 2)
                        {
                            log += Program.infoResource.GetLocalizedString(language.InfoId.OperateFail);
                            XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.LoginFail));
                            return;
                        }
                        if ((bool)ResultDataViewModel.VM.LoginEntities[0] == true)
                        {
                            log += Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess);
                            permission = Convert.ToInt32(ResultDataViewModel.VM.LoginEntities[1].ToString());
                            userName = name;
                            RememberPassword(userName,tePassword.Text,ceRememberPassword.Checked);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            string str = Program.infoResource.GetLocalizedString((int)ResultDataViewModel.VM.LoginEntities[1] == 3 ? language.InfoId.AccountDisabled : language.InfoId.OperateFail);
                            log += str;
                            XtraMessageBox.Show(Program.infoResource.GetLocalizedString((int)ResultDataViewModel.VM.LoginEntities[1] == 3 ? language.InfoId.AccountDisabled : language.InfoId.LoginFail));
                        }
                        ErrorLog.SystemLog(System.DateTime.Now, log, name);
                    }
                    else
                    {
                        XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.LoginFail));
                    }
                }
                else
                {
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.InputNotNull));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                ErrorLog.Error(ex.ToString());
            }
        }
        private void RememberPassword(string name,string pass,bool IsRem)
        {
            SetSettingString(uName, name);
            SetSettingString(pwd,pass);
            SetSettingString(isRemember,IsRem.ToString());
        }

        private void wfLogin_Load(object sender, EventArgs e)
        {
            string s = GetSettingString(isRemember);
            if (s == null) return;
            if (s.ToLower()== "true")
            {
                ceRememberPassword.Checked = true;
                teName.Text = GetSettingString(uName);
                tePassword.Text = GetSettingString(pwd);
            }
            else
            {
                ceRememberPassword.Checked = false;
            }
        }
        //从配置文件中读节点值
        private string GetSettingString(string settingName)
        {
            try
            {
                string settingString = ConfigurationManager.AppSettings[settingName].ToString();
                return settingString;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void SetSettingString(string settingName, string settingValue)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (ConfigurationManager.AppSettings[settingName] != null)
                {
                    config.AppSettings.Settings.Remove(settingName);
                }
                config.AppSettings.Settings.Add(settingName, settingValue);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
        }
    }
}
