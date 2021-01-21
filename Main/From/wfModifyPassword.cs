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
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.BAL.ImBAL;
using wayeal.os.exhaust.LogUtils;
using wayeal.os.exhaust.Models;
using wayeal.os.exhaust.ViewModel;

namespace wayeal.os.exhaust.Forms
{
    public partial class wfModifyPassword : wfBase
    {
        

        string uname;
        IUserListBAL bal =new ImUserListBAL();
        UserList userlist = new UserList();
        public wfModifyPassword(string uname)
        {
            InitializeComponent();
            InitializeUI();
            this.uname = uname;
           
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {

        }

        private void sbModify_Click(object sender, EventArgs e)
        {
            try
            {

            }catch(Exception ex)
            {

                LogHelper.LogUtlis("wfModifyPassword", ex);
            }
            userlist.uname = uname;
            userlist.upwd = teOldPassword.Text.Trim();
            int isbool1 = bal.QueryPwdByName(userlist);
            
            if (isbool1>0)
            {
                if (teNewPassword.Text.Trim() == teAgain.Text.Trim())
                {
                    userlist.upwd = teNewPassword.Text.Trim();
                   int isbool= bal.UpdataByPwd(userlist);
                    if (isbool>0)
                    {
                        MessageBox.Show("密码更新成功！");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("两次输入密码不一致！");
                    teAgain.Text = "";
                    teNewPassword.Text = "";
                }
            }
            else
            {
                MessageBox.Show("密码错误,请重新输入！");
                teOldPassword.Text = "";
            }
        }
    }
}
