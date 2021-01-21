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
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.BAL.ImBAL;
using wayeal.os.exhaust.Models;
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
        //第一步声明委托
        public delegate void setTexVaule(string username,int permiss);
        //第二步声明一个委托类型的事件
        public event setTexVaule setFormTextVaule;


        public wfLogin()
        {
            InitializeComponent();
            InitializeUI();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbLogin_Click(object sender, EventArgs e)
        {
            UserList user = new UserList();
            user.uname = teName.Text.Trim();
            user.upwd = tePassword.Text.Trim();
            IUserListBAL bal = new ImUserListBAL();
            int? perss= bal.UserLogin(user);
            if (perss <10)
            {
                MessageBox.Show("登录成功"+perss);

                //第三步准备相关数据
                setFormTextVaule(teName.Text,(int)perss);
                this.Dispose();
               
            }
            else
            {
                MessageBox.Show("登陆失败" + perss);
                this.Dispose();
            }
        }

        private void tePassword_KeyDown(object sender, KeyEventArgs e)
        {
        }

      
        private void RememberPassword(string name,string pass,bool IsRem)
        {
        }

        private void wfLogin_Load(object sender, EventArgs e)
        {
           
        }
      
    }
}
