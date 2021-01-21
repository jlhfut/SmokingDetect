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
using wayeal.os.exhaust.DAL.IDAL;
using wayeal.os.exhaust.DAL.ImDAL;
using wayeal.os.exhaust.LogUtils;
using wayeal.os.exhaust.Models;
using wayeal.os.exhaust.Modules;

using wayeal.os.exhaust.ViewModel;
using Wayee.Services;

namespace wayeal.os.exhaust.Forms
{ 
    public partial class wfChangeUser :wfBase
    {
        private string uname;
        UserList userlist = new UserList();

        public wfChangeUser( string uname)
        {
            InitializeComponent();
            InitializeUI();
            this.uname = uname;
            teUserName.Text = uname;
        }
        
      
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int isAlive;
                if (ceischeck.Checked == true)
                {
                    //是否启用  true  false
                    isAlive = 1;

                }
                else
                {
                    isAlive = 0;

                }

                userlist.uname = uname;
                userlist.upermission = cbPermi.SelectedIndex;
                userlist.uisAlive = isAlive;

                IUserListDAL dal = new ImUserListDAL();
                int isFlag = dal.UpdataByUName(userlist);
                if (isFlag > 0)
                {
                    MessageBox.Show("更新成功");

                }
            }catch(Exception ex)
            {
                LogHelper.LogUtlis("wfChangeUser", ex);
            }
           


        }
        private void sbCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
      

        private void cbePermission_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
        }
    }
}
