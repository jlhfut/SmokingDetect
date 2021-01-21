using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.ViewModel;

namespace wayeal.os.exhaust.Forms
{
    public partial class wfModifyPassword :wfBase
    {
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        public wfModifyPassword()
        {
            InitializeComponent();
            InitializeUI();
            teNewPassword.Properties.Mask.UseMaskAsDisplayFormat = true;
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        protected override void InitializeBindings()
        {
            try
            {
                mvvmContext1.SetViewModel(typeof(ResultDataViewModel), ResultDataViewModel.VM);
                fluent = mvvmContext1.OfType<ResultDataViewModel>();
                
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
        private void sbCancel_Click(object sender, EventArgs e)
        {
            teNewPassword.Properties.Mask.UseMaskAsDisplayFormat = false;
            this.DialogResult = DialogResult.Cancel;
        }

        private void sbModify_Click(object sender, EventArgs e)
        {
            if (frmMain.UserName == "WAYEE")
            {
                //超级管理员无法修改自己的密码
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.NoPowerChangePwd));
                return;
            }
            if (teOldPassword.Text.Trim() == ""||teNewPassword.Text.Trim()=="")
            {
                //用户名和密码不能为空
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.InputNotNull));
                return;
            }
            if (teNewPassword.Text != teAgain.Text)
            {
                //两次输入密码不一样
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.NewPassword));
                return;
            }
            ResultDataViewModel.VM.Execute(new List<object> {
                    ResultDataViewModel.ExecuteCommand.ec_QueryUserAndPwd,
                    wfLogin.userName,
                    teOldPassword.Text });
            if (ResultDataViewModel.VM.QueryUserAndPwdEntities.Count < 1)
            {
                //原密码不正确
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.OldPasswordError));
                return;
            }
            {
                string log = "";
                log += Program.infoResource.GetLocalizedString(language.InfoId.ChangePassword);
                log += wfLogin.userName;
                ResultDataViewModel.VM.Execute(new List<object> {
                    ResultDataViewModel.ExecuteCommand.ec_ChangeUserInfo,
                    wfLogin.userName,
                    "","",
                    teNewPassword.Text,
                    teOldPassword.Text });
                if (ResultDataViewModel.VM.ChangeUserInfoResult)
                {
                    log += Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess);
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.ChangeSuccess));
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    log += Program.infoResource.GetLocalizedString(language.InfoId.OperateFail);
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.ChangeFail));
                }
                ErrorLog.SystemLog(DateTime.Now, log,wfLogin.userName);
            }
        }
    }
}
