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
using wayeal.os.exhaust.Modules;
using wayeal.os.exhaust.Services;
using wayeal.os.exhaust.ViewModel;
using Wayee.Services;

namespace wayeal.os.exhaust.Forms
{ 
    public partial class wfChangeUser :wfBase
    {
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        private string pm;
        string oldpm;
        private string ea;
        string oldea;
        private int index = 0;
        private string UserName;
        DataTable dtRole = new DataTable();

        public wfChangeUser()
        {
            InitializeComponent();
            InitializeUI();
        }
         public wfChangeUser(int RoleIndex,string opratorName)
         {
             index = RoleIndex;
             UserName = opratorName;
             InitializeComponent();
             InitCombobox();
             InitializeUI();
             if (!mvvmContext1.IsDesignMode) InitializeBindings();
         }
        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitCombobox()
        {
            cbePermission.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.Manager));
            cbePermission.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.Operator));
            cbePermission.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.Tourist));
        }
        protected override void InitializeBindings()
        {
            try
            {
                mvvmContext1.SetViewModel(typeof(ResultDataViewModel), ResultDataViewModel.VM);
                fluent = mvvmContext1.OfType<ResultDataViewModel>();
                AddBinding(fluent.SetBinding(cbePermission, cbe => cbe.SelectedIndex, x => x.UserEntities, m =>
                {
                    if (m != null)
                    {
                        return m.Count > index ? Convert.ToInt32(((DTUserInfo)m[index]).Permission.Value)-1 : -1;
                    }
                    return -1;
                }));
                AddBinding(fluent.SetBinding(teUserName, te => te.Text, x => x.UserEntities, m => {
                    if (m != null)
                    {
                        return m.Count > index ? ((DTUserInfo)m[index]).UserName.ToString() : null;
                    }
                    return null;
                }));
                AddBinding(fluent.SetBinding(ceEnableAccount, ce => ce.Checked, x => x.UserEntities, m => {
                    if (m != null&&index<m.Count)
                    {
                        if (((DTUserInfo)m[index]).Statue.Value.ToString().Equals("0")) return false;
                        if (((DTUserInfo)m[index]).Statue.Value.ToString().Equals("1")) return true ;
                    }
                    return false ;
                }));
                
                ResultDataViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(ResultDataViewModel).Name) action();
                };

                base.InitializeBindings();
                oldpm = (cbePermission.SelectedIndex+1).ToString();
                oldea = ceEnableAccount.EditValue.ToString ();
            }
            catch (Exception ex)
            {
                if(DataServiceHelper.Instanse!=null)ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbePermission.SelectedIndex < 0)
            {
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.InputNotNull), "", MessageBoxButtons.OK);
            }
            else
            {
                string log = Program.infoResource.GetLocalizedString(language.InfoId.ChangeUser)+ teUserName.Text;
                pm = (cbePermission.SelectedIndex+1).ToString();
                ea = ceEnableAccount.EditValue.ToString();
                ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_ChangeUserInfo,
                    teUserName.Text,
                    (cbePermission.SelectedIndex+1).ToString(),
                    ceEnableAccount.EditValue.ToString () });
                if (ResultDataViewModel.VM.ChangeUserInfoResult)
                {
                    log += Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess);
                    log += ErrorLog.JointLogContent(Program.infoResource.GetLocalizedString(language.InfoId.Pression), false, false, Utils.ConvertStringPermissionToZNCH(oldpm), Utils.ConvertStringPermissionToZNCH(pm));
                    log += ErrorLog.JointLogContent(Program.infoResource.GetLocalizedString(language.InfoId.Statue), false, false, Utils.ConvertStringStatueToZNCH(oldea), Utils.ConvertStringStatueToZNCH(ea));
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    log += Program.infoResource.GetLocalizedString(language.InfoId.OperateFail);
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.ChangeFail));
                }
                index = 0;
                if (log != "") ErrorLog.SystemLog(DateTime.Now, log, UserName);
            }
        }
        private void sbCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        public string GetUserName()
        {
            return teUserName.Text;
        }
        public string GetPermissionItem()
        {
            return pm;
        }
        public string GetCheckValue()
        {
            return ea;
        }

        private void cbePermission_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
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
