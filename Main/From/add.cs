using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using wayeal.os.exhaust.Models;
using wayeal.os.exhaust.DAL.IDAL;
using wayeal.os.exhaust.BAL.ImBAL;
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.LogUtils;

namespace wayeal.os.exhaust.From
{
    public partial class add : DevExpress.XtraEditors.XtraForm
    {
        public add()
        {
            InitializeComponent();
        }

        private void sbadd_Click(object sender, EventArgs e)
        {
            try
            {
                int isAlive;
                if (ceischeck.Checked == true)
                {
                    //是否启用  true  false
                    isAlive = 1;
                    label1.Text = isAlive.ToString();
                }
                else
                {
                    isAlive = 0;
                    label1.Text = isAlive.ToString();
                }



                UserList userList = new UserList();
                string pwd = "12345"; //默认密码
                string datetime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");//创建日期

                string ucreator = "admin";//创建者


                userList.ucreateor = ucreator;
                userList.upermission = cbPermi.SelectedIndex;
                userList.udata = datetime;
                userList.upwd = pwd;
                userList.uname = txtuname.Text.ToString();
                userList.uisAlive = isAlive;


                IUserListBAL userListDAL = new ImUserListBAL();
                int isSuccess =
                userListDAL.AddUser(userList);

                if (isSuccess > 0)
                {
                    MessageBox.Show("添加成功！");
                }

            }catch(Exception ex)
            {
                LogHelper.LogUtlis("AddUser", ex);
            }






        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}