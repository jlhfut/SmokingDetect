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
using wayeal.os.exhaust.From;
using wayeal.os.exhaust.DAL.IDAL;
using wayeal.os.exhaust.DAL.ImDAL;
using wayeal.os.exhaust.Models;
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.BAL.ImBAL;
using wayeal.os.exhaust.Forms;
using wayeal.os.exhaust.LogUtils;

namespace wayeal.os.exhaust.Modules
{
    
    public partial class ucUserManager : ucManagerBase
    {

        IUserListBAL userListBAL = new ImUserListBAL();
    
        UserList user = new UserList();

        private int currentIndex = 1;



        public ucUserManager()
        {
            InitializeComponent();
        }

        private void beUserName_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        //新建用户
        private void sbNew_Click(object sender, EventArgs e)
        {
            
                add a = new add();
                a.Show();
            
           
            
        }

        /// <summary>
        /// 窗体加载是
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucUserManager_Load(object sender, EventArgs e)
        {
            try
            {
                int totalPage = 0;
                //数据绑定
                gcuserlist.DataSource = userListBAL.SelectUserPage(null,null,1,5,ref totalPage);
            }catch(Exception ex)
            {
                LogHelper.LogUtlis("usermanager-数据绑定", ex);
            }
         
           
           
        }


       

        private void riUserOperate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var index = gvUserManage.GetFocusedDataSourceRowIndex();//获取行的索引值，从0开始
                string uname = gvUserManage.GetRowCellValue(index, "uname").ToString();

                // MessageBox.Show(e.Button.Caption);//选中了哪一个按钮
                string btnName = e.Button.Caption.Trim();
                switch (btnName)
                {
                    case "initialize":
                        wfChangeUser wcu = new wfChangeUser(uname);
                        wcu.Show();
                        break;
                    case "edit":
                        wfModifyPassword wfp = new wfModifyPassword(uname);
                        wfp.Show();
                        break;
                    case "delete":
                        wfDelte wfd = new wfDelte(uname);
                        wfd.Show();
                        break;
                    default:
                        break;
                }
            }catch(Exception ex)
            {
                LogHelper.LogUtlis("usermanager_用户操作", ex);
            }
           
                
            //if (btnName== "initialize")
            //{
            //    wfChangeUser wcu = new wfChangeUser(uname);
            //    wcu.Show();
            //}
            //if (btnName == "")
            //{

            //}
            //if(btnName=="1"){

            }

        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbSearch_Click(object sender, EventArgs e)
        {
            int? selectPermiss = null;

            if (cbePermission.SelectedIndex == 3)
            {
                selectPermiss = null;
            }
            else
            {
                selectPermiss = cbePermission.SelectedIndex;
            }
            string txtname = beUserName.Text.Trim();
            int pageTotal = 0;

            gcuserlist.DataSource = gcuserlist.DataSource = userListBAL.SelectUserPage(txtname, selectPermiss, 1, 5,ref pageTotal);

            //一共有多少条数据
            lblTotal.Text = pageTotal.ToString();


            //一共有多少页
            lblResultTotal.Text = TotalPageIndex(pageTotal, 5).ToString();


            lblIndex.Text = "1";
            if (currentIndex < 0)
            {
                currentIndex = 1;
            }
            else
            {
                currentIndex = 1;


            }

        }


        /// <summary>
        /// 求总页数
        /// </summary>
        /// <param name="totalPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private int TotalPageIndex(int totalPage, int pageSize)
        {
            return (totalPage + pageSize - 1) / pageSize;
        }


        /// <summary>
        /// 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            int? selectPermiss = null;

            if (cbePermission.SelectedIndex == 3)
            {
                selectPermiss = null;
            }
            else
            {
                selectPermiss = cbePermission.SelectedIndex;
            }
            string txtname = beUserName.Text.Trim();

            int pageTotal = 0;
            DataTable logtable = userListBAL.SelectUserPage(txtname, selectPermiss, 1, 5, ref pageTotal);

            //绑定数据源
            gcuserlist.DataSource = logtable;

            //共多少条数据
            lblTotal.Text = pageTotal.ToString();


            //共多少页
            int totalPage = (pageTotal + 5 - 1) / 5;
            lblResultTotal.Text = totalPage.ToString();

            //当前页
            lblIndex.Text = "1";
        }


        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            int? selectPermiss = null;

            if (cbePermission.SelectedIndex == 3)
            {
                selectPermiss = null;
            }
            else
            {
                selectPermiss = cbePermission.SelectedIndex;
            }
            string txtname = beUserName.Text.Trim();

            int pageTotal = 0;
            DataTable logtable = userListBAL.SelectUserPage(txtname, selectPermiss, 1, 5, ref pageTotal);

            int totalPage = (pageTotal + 5 - 1) / 5;


            if (currentIndex <= 1)
            {
                currentIndex = 1;//当前页
                                 //绑定数据源
                gcuserlist.DataSource = userListBAL.SelectUserPage(txtname, selectPermiss, 1, totalPage, ref pageTotal);



                //共多少条数据
                lblTotal.Text = pageTotal.ToString();


                //共多少页

                lblResultTotal.Text = totalPage.ToString();

                //当前页
                lblIndex.Text = currentIndex.ToString();
            }
            else if (currentIndex > 1 && currentIndex <= totalPage)

            {
                currentIndex -= 1;
                gcuserlist.DataSource = userListBAL.SelectUserPage(txtname, selectPermiss, currentIndex, 5, ref pageTotal);
                //共多少条数据
                lblTotal.Text = pageTotal.ToString();


                //共多少页

                lblResultTotal.Text = totalPage.ToString();

                //当前页
                lblIndex.Text = currentIndex.ToString();

            }
        }


        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            int? selectPermiss = null;

            if (cbePermission.SelectedIndex == 3)
            {
                selectPermiss = null;
            }
            else
            {
                selectPermiss = cbePermission.SelectedIndex;
            }
            string txtname = beUserName.Text.Trim();

            int pageTotal = 0;
            DataTable logtable = userListBAL.SelectUserPage(txtname, selectPermiss, 1, 5, ref pageTotal);

            int totalPage = (pageTotal + 5 - 1) / 5;

            if (currentIndex > totalPage)
            {
                button4.Enabled = false;
                currentIndex = totalPage;
                //共多少条数据
                lblTotal.Text = pageTotal.ToString();


                //共多少页

                lblResultTotal.Text = totalPage.ToString();

                //当前页
                lblIndex.Text = currentIndex.ToString();

            }
            else
            {
                button4.Enabled = true;
                if (currentIndex > 1 && currentIndex < pageTotal)
                {
                    gcuserlist.DataSource = userListBAL.SelectUserPage(txtname, selectPermiss, currentIndex + 1, 5, ref pageTotal);
                }
                else
                {
                    gcuserlist.DataSource = userListBAL.SelectUserPage(txtname, selectPermiss, totalPage, 5, ref pageTotal);
                }
                if (currentIndex < totalPage)
                {

                }
                else
                {
                    currentIndex = totalPage;
                }
                //当前页


                //共多少条数据
                lblTotal.Text = pageTotal.ToString();


                //共多少页

                lblResultTotal.Text = totalPage.ToString();

                //当前页
                lblIndex.Text = currentIndex.ToString();
            }
        }


        /// <summary>
        /// 最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

            int? selectPermiss = null;

            if (cbePermission.SelectedIndex == 3)
            {
                selectPermiss = null;
            }
            else
            {
                selectPermiss = cbePermission.SelectedIndex;
            }
            string txtname = beUserName.Text.Trim();
            int pageTotal = 0;
            DataTable logtable = userListBAL.SelectUserPage(txtname, selectPermiss, 1, 5, ref pageTotal);

            int totalPage = (pageTotal + 5 - 1) / 5;

            gcuserlist.DataSource = userListBAL.SelectUserPage(txtname, selectPermiss, totalPage, 5, ref pageTotal);

            //绑定数据源
            //gcLogList.DataSource = logtable;

            //共多少条数据
            lblTotal.Text = pageTotal.ToString();


            //共多少页

            lblResultTotal.Text = totalPage.ToString();

            //当前页
            lblIndex.Text = "1";
        }
    }

    


    
}

