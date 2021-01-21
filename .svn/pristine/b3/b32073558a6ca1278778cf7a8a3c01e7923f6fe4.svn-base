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
    public partial class wfNewUser :wfBase 
    {
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        public wfNewUser()
        {
            InitializeComponent();
            InitializeUI();
            InitCombobox();
            if(!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitCombobox()
        {
            cbePermission.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.Manager));
            cbePermission.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.Operator));
            cbePermission.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.Tourist));
            cbePermission.SelectedIndex = 0;
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
            this.DialogResult = DialogResult.Cancel ;
        }

        private void sbConfirm_Click(object sender, EventArgs e)
        {
            if (teNewUserName.Text.Equals(string.Empty)|| cbePermission.SelectedIndex < 0)
            {
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.InputNotNull), "", MessageBoxButtons.OK);
            }
            else
            {
                if (!CheckUserName(teNewUserName.Text.Trim()))
                {
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.UserNameNotAllowed));
                    return;
                }
                ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryUserAndPwd,teNewUserName.Text});
                if (ResultDataViewModel.VM.QueryUserAndPwdEntities.Count>0)
                {
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.UserNameExist), "", MessageBoxButtons.OK);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        /// <summary>
        /// 检验用户名是否合法
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CheckUserName(string userName)
        {
            string[] ReservedField = { "游客", "管理员", "操作员", "Manager", "Operator", "Tourist" };
            return !ReservedField.Contains(userName);
        }
        public string returnPermission()
        {
            return (cbePermission.SelectedIndex+1).ToString ();
        }
        public string returnUserName()
        {
            return teNewUserName.Text.ToString();
        }
        public string returnStatue()
        {
            return ceEnableAccount.EditValue.ToString();
        }
        private void wfNewUser_Load(object sender, EventArgs e)
        {

        }

        public void cbePermission_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null) return;
            switch (e.Value.ToString())
            {
                case "0":
                    e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Manager);
                    return;
                case "1":
                    e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Operator);
                    return;
                case "2":
                    e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Tourist);
                    return;
            }
        }
    }
}
