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
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.DAL.ImDAL;
using wayeal.os.exhaust.BAL.ImBAL;
using wayeal.os.exhaust.LogUtils;

namespace wayeal.os.exhaust.Modules
{
    public partial class ucSystemLog :ucManagerBase
    {

        DateTime startTime; //开始时间
        DateTime endTime;  //结束时间
        ILogBAL BAL = new ImLogBAL();

        //当前页面索引
        int currentIndex = 1;


        public ucSystemLog()
        {
            InitializeComponent();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                gcLogList.DataSource = BAL.SelectAllLog(new Models.Log());
            }
            catch(Exception ex)
            {
                LogHelper.LogUtlis("SystemLog",ex);
            }
           
        }


        /// <summary>
        /// 多条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbQuary_Click(object sender, EventArgs e)
        {
            //多条件查询
            startTime = Convert.ToDateTime(dtpBegin.Text);
            endTime = Convert.ToDateTime(dtpEnd.Text);
            int pageTotal = 0;
            DataTable logtable=  BAL.SelectByTimeNameContentPagelist(startTime, endTime, txtName.Text.ToString().Trim(), txtLogContent.Text.ToString().Trim(),1,5,ref pageTotal);
            //绑定数据源
            gcLogList.DataSource = logtable;

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

        private void dtpBegin_ValueChanged(object sender, EventArgs e)
        {
            startTime= Convert.ToDateTime(dtpBegin.Text);  //开始时间
           
           
    }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            endTime = Convert.ToDateTime(dtpEnd.Text);//结束时间
        }


        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="uName"></param>
        /// <param name="logContent"></param>
        private void setQueryCondition(DateTime startTime,DateTime endTime,string uName,string logContent)
        {

        }


        /// <summary>
        /// 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {

            //多条件查询
            startTime = Convert.ToDateTime(dtpBegin.Text);
            endTime = Convert.ToDateTime(dtpEnd.Text);
            int pageTotal = 0;
            DataTable logtable = BAL.SelectByTimeNameContentPagelist(startTime, endTime, txtName.Text.ToString().Trim(), txtLogContent.Text.ToString().Trim(), 1, 5, ref pageTotal);
            //绑定数据源
            gcLogList.DataSource = logtable;

            //共多少条数据
            lblTotal.Text = pageTotal.ToString();


            //共多少页
           int totalPage = (pageTotal + 5 - 1) / 5;
            lblResultTotal.Text = totalPage.ToString();

            //当前页
            lblIndex.Text = "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //多条件查询
            startTime = Convert.ToDateTime(dtpBegin.Text);
            endTime = Convert.ToDateTime(dtpEnd.Text);
            int pageTotal = 0;
            DataTable logtable = BAL.SelectByTimeNameContentPagelist(startTime, endTime, txtName.Text.ToString().Trim(), txtLogContent.Text.ToString().Trim(), 1, 5, ref pageTotal);

            int totalPage = (pageTotal + 5 - 1) / 5;

            gcLogList.DataSource=BAL.SelectByTimeNameContentPagelist(startTime, endTime, txtName.Text.ToString().Trim(), txtLogContent.Text.ToString().Trim(), totalPage, 5, ref pageTotal);

            //绑定数据源
            //gcLogList.DataSource = logtable;

            //共多少条数据
            lblTotal.Text = pageTotal.ToString();


            //共多少页
           
            lblResultTotal.Text = totalPage.ToString();

            //当前页
            lblIndex.Text = "1";
        }


        private int TotalPageIndex(int totalPage,int pageSize)
        {
            return (totalPage + pageSize - 1) / pageSize;
        }


        /// <summary>
        /// 上一条记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //多条件查询
            startTime = Convert.ToDateTime(dtpBegin.Text);
            endTime = Convert.ToDateTime(dtpEnd.Text);

            int pageTotal = 0;
            DataTable logtable = BAL.SelectByTimeNameContentPagelist(startTime, endTime, txtName.Text.ToString().Trim(), txtLogContent.Text.ToString().Trim(), 1, 5, ref pageTotal);

            int totalPage = (pageTotal + 5 - 1) / 5;


            if (currentIndex <= 1)
            {
                currentIndex = 1;//当前页
                gcLogList.DataSource = BAL.SelectByTimeNameContentPagelist(startTime, endTime, txtName.Text.ToString().Trim(), txtLogContent.Text.ToString().Trim(), totalPage, 5, ref pageTotal);
                //共多少条数据
                lblTotal.Text = pageTotal.ToString();


                //共多少页

                lblResultTotal.Text = totalPage.ToString();

                //当前页
                lblIndex.Text = currentIndex.ToString();
            }
            else if(currentIndex>1&&currentIndex<=totalPage)

            {
                currentIndex -= 1;
                gcLogList.DataSource = BAL.SelectByTimeNameContentPagelist(startTime, endTime, txtName.Text.ToString().Trim(), txtLogContent.Text.ToString().Trim(), currentIndex, 5, ref pageTotal);
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
           
            //多条件查询
            startTime = Convert.ToDateTime(dtpBegin.Text);
            endTime = Convert.ToDateTime(dtpEnd.Text);
           
            int pageTotal = 0;
            DataTable logtable = BAL.SelectByTimeNameContentPagelist(startTime, endTime, txtName.Text.ToString().Trim(), txtLogContent.Text.ToString().Trim(), 1, 5, ref pageTotal);

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
                    gcLogList.DataSource = BAL.SelectByTimeNameContentPagelist(startTime, endTime, txtName.Text.ToString().Trim(), txtLogContent.Text.ToString().Trim(), currentIndex + 1, 5, ref pageTotal);
                }
                else
                {
                    gcLogList.DataSource = BAL.SelectByTimeNameContentPagelist(startTime, endTime, txtName.Text.ToString().Trim(), txtLogContent.Text.ToString().Trim(), totalPage, 5, ref pageTotal);
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
        /// 跳转页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //多条件查询
            startTime = Convert.ToDateTime(dtpBegin.Text);
            endTime = Convert.ToDateTime(dtpEnd.Text);
            int pageNo = Convert.ToInt32(txtpage.Text);

            int pageTotal = 0;
             BAL.SelectByTimeNameContentPagelist(startTime, endTime, txtName.Text.ToString().Trim(), txtLogContent.Text.ToString().Trim(), 1, 5, ref pageTotal);

            if (pageNo > pageTotal)
            {
                pageNo = pageTotal;
                gcLogList.DataSource = BAL.SelectByTimeNameContentPagelist(startTime, endTime, txtName.Text.ToString().Trim(), txtLogContent.Text.ToString().Trim(), pageTotal, 5, ref pageTotal);
                currentIndex = pageNo;

                //共多少条数据
                lblTotal.Text = pageTotal.ToString();


                //共多少页

                lblResultTotal.Text = ((pageTotal + 5 - 1) / 5).ToString();

                //当前页
                lblIndex.Text = currentIndex.ToString();

            }
            else
            {
                currentIndex = pageNo;
                gcLogList.DataSource = BAL.SelectByTimeNameContentPagelist(startTime, endTime, txtName.Text.ToString().Trim(), txtLogContent.Text.ToString().Trim(), pageTotal, 5, ref pageTotal);

                //共多少条数据
                lblTotal.Text = pageTotal.ToString();


                //共多少页

                lblResultTotal.Text = ((pageTotal + 5 - 1) / 5).ToString();

                //当前页
                lblIndex.Text = currentIndex.ToString();
            }
        }

        private void ucSystemLog_Load(object sender, EventArgs e)
        {

        }

        private void gcLogList_Click(object sender, EventArgs e)
        {

        }
    }
    }
