using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using wayeal.os.exhaust.Forms;
using wayeal.os.exhaust.DAL.IDAL;
using wayeal.os.exhaust.DAL.ImDAL;
using wayeal.os.exhaust.Models;
using wayeal.os.exhaust.LogUtils;

namespace wayeal.os.exhaust.From
{
    public partial class wfDelte :wfBase
    {
        string uname;
        public wfDelte(string uname)
        {
            InitializeComponent();
            this.uname = uname;
          
        }

        private void sbdelete_Click(object sender, EventArgs e)
        {
            try
            {
                IUserListDAL dal = new ImUserListDAL();
                UserList userlist = new UserList();
                userlist.uname = uname;

                int isbool = dal.DeleteByName(userlist);
                if (isbool > 0)
                {
                    MessageBox.Show("删除成功！");
                    this.Close();
                }

            }
            catch(Exception ex)
            {
                LogHelper.LogUtlis("删除用户", ex);
            }
           


        }

        private void wpfDelte_Load(object sender, EventArgs e)
        {
            teUserName.Text = uname;
        }

        private void sbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
