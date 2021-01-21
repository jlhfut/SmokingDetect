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
using wayeal.os.exhaust.LogUtils;
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.BAL.ImBAL;

namespace wayeal.os.exhaust.Modules
{
    public partial class ucBackgroundLog :ucManagerBase
    {
        DateTime startTime;
        DateTime endTime;
        private ILogBAL BAL = new ImLogBAL();
        private int currentIndex = 1;
        int pageTotal = 0;
        public ucBackgroundLog()
        {

          
            
            InitializeComponent();
            gcBackgroundLogList.DataSource = BAL.SelectByTimeCategoryContentPagelist(System.DateTime.Now, System.DateTime.Now, null, null, 1, 5, ref pageTotal);

        }

        private void dtpBegin_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                startTime = Convert.ToDateTime(dtpBegin.Text.ToString().Trim()); //开始时间
                endTime = Convert.ToDateTime(dtpBegin.Text.ToString().Trim());//结束时间


                string logContent = txtLogContent.Text.ToString().Trim();
                int selectCategory=cbcategory.SelectedIndex;
                string category="INFO";
                switch (selectCategory)
                {
                    case 0:  //所有
                        category = "INFO";
                        break;
                    case 1://调试
                        category = "INFO";
                        break;
                    case 2://警告
                        category = "INFO";
                        break;
                    case 3: //错误
                        category = "INFO";
                        break;
                    case 4: //致命错误
                        category = "INFO";
                        break;
                    default:
                        break;

                }

                gcBackgroundLogList.DataSource = BAL.SelectByTimeCategoryContent(startTime, endTime, category, logContent);
          


            }catch(Exception ex)
            {
                LogHelper.LogUtlis("backgrount-ui", ex);
            }




        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            startTime = Convert.ToDateTime(dtpBegin.Text.ToString().Trim());
            endTime = Convert.ToDateTime(dtpBegin.Text.ToString().Trim());
        }


        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbQuary_Click(object sender, EventArgs e)
        {
            startTime = Convert.ToDateTime(dtpBegin.Text.ToString().Trim()); //开始时间
            endTime = Convert.ToDateTime(dtpBegin.Text.ToString().Trim());//结束时间

            int pageTotal = 0;
            string logContent = txtLogContent.Text.ToString().Trim();
            int selectCategory = cbcategory.SelectedIndex;
            string category = "INFO";
            switch (selectCategory)
            {
                case 0:  //所有
                    category = null;
                    break;
                case 1://调试
                    category = "INFO";
                    break;
                case 2://警告
                    category = "INFO";
                    break;
                case 3: //错误
                    category = "INFO";
                    break;
                case 4: //致命错误
                    category = "INFO";
                    break;
                default:
                    break;

            }

            gcBackgroundLogList.DataSource = BAL.SelectByTimeCategoryContentPagelist(startTime, endTime, category, logContent, 1, 5, ref pageTotal); 

            BAL.SelectByTimeCategoryContentPagelist(startTime, endTime, category, category, 1, 5, ref pageTotal);

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


        private void ucBackgroundLog_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            //多条件查询
            startTime = Convert.ToDateTime(dtpBegin.Text);
            endTime = Convert.ToDateTime(dtpEnd.Text);
            int pageNo = Convert.ToInt32(txtpage.Text);

            string category = "INFO";
            int selectCategory = cbcategory.SelectedIndex;
            switch (selectCategory)
            {
                case 0:  //所有
                    category = null;
                    break;
                case 1://调试
                    category = "INFO";
                    break;
                case 2://警告
                    category = "INFO";
                    break;
                case 3: //错误
                    category = "INFO";
                    break;
                case 4: //致命错误
                    category = "INFO";
                    break;
                default:
                    break;

            }


            int pageTotal = 0;
            BAL.SelectByTimeCategoryContentPagelist(startTime, endTime, category, txtLogContent.ToString(), 1, 5, ref pageTotal);

            if (pageNo > pageTotal)
            {
                pageNo = pageTotal;
                gcBackgroundLogList.DataSource = BAL.SelectByTimeCategoryContentPagelist(startTime, endTime, category, txtLogContent.ToString(), 1, 5, ref pageTotal);
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
                gcBackgroundLogList.DataSource = BAL.SelectByTimeCategoryContentPagelist(startTime, endTime, category, txtLogContent.ToString(), 1, 5, ref pageTotal);

                //共多少条数据
                lblTotal.Text = pageTotal.ToString();


                //共多少页

                lblResultTotal.Text = ((pageTotal + 5 - 1) / 5).ToString();

                //当前页
                lblIndex.Text = currentIndex.ToString();
            }

        }


        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //多条件查询
            startTime = Convert.ToDateTime(dtpBegin.Text);
            endTime = Convert.ToDateTime(dtpEnd.Text);
            int pageNo = Convert.ToInt32(txtpage.Text);

            string category = "INFO";
            int selectCategory = cbcategory.SelectedIndex;
            switch (selectCategory)
            {
                case 0:  //所有
                    category = null;
                    break;
                case 1://调试
                    category = "INFO";
                    break;
                case 2://警告
                    category = "INFO";
                    break;
                case 3: //错误
                    category = "INFO";
                    break;
                case 4: //致命错误
                    category = "INFO";
                    break;
                default:
                    break;

            }


            int pageTotal = 0;
            DataTable logtable = BAL.SelectByTimeCategoryContentPagelist(startTime, endTime, category, txtLogContent.ToString(), 1, 5, ref pageTotal);

            //绑定数据源
            gcBackgroundLogList.DataSource = logtable;

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
           
            //多条件查询
            startTime = Convert.ToDateTime(dtpBegin.Text);
            endTime = Convert.ToDateTime(dtpEnd.Text);
            int pageNo = Convert.ToInt32(txtpage.Text);

            string category = "INFO";
            int selectCategory = cbcategory.SelectedIndex;
            switch (selectCategory)
            {
                case 0:  //所有
                    category = null;
                    break;
                case 1://调试
                    category = "INFO";
                    break;
                case 2://警告
                    category = "INFO";
                    break;
                case 3: //错误
                    category = "INFO";
                    break;
                case 4: //致命错误
                    category = "INFO";
                    break;
                default:
                    break;

            }


            int pageTotal = 0;
            DataTable logtable = BAL.SelectByTimeCategoryContentPagelist(startTime, endTime,category, txtLogContent.Text.ToString().Trim(), 1, 5, ref pageTotal);

            int totalPage = (pageTotal + 5 - 1) / 5;


            if (currentIndex <= 1)
            {
                currentIndex = 1;//当前页
                                 //绑定数据源
               gcBackgroundLogList.DataSource= BAL.SelectByTimeCategoryContentPagelist(startTime, endTime, category, txtLogContent.ToString(), 1, totalPage, ref pageTotal);

               
               
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
                gcBackgroundLogList.DataSource = BAL.SelectByTimeCategoryContentPagelist(startTime, endTime, category, txtLogContent.Text.ToString().Trim(), currentIndex, 5, ref pageTotal);
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
            ///多条件查询
            startTime = Convert.ToDateTime(dtpBegin.Text);
            endTime = Convert.ToDateTime(dtpEnd.Text);
            int pageNo = Convert.ToInt32(txtpage.Text);

            string category = "INFO";
            int selectCategory = cbcategory.SelectedIndex;
            switch (selectCategory)
            {
                case 0:  //所有
                    category = null;
                    break;
                case 1://调试
                    category = "INFO";
                    break;
                case 2://警告
                    category = "INFO";
                    break;
                case 3: //错误
                    category = "INFO";
                    break;
                case 4: //致命错误
                    category = "INFO";
                    break;
                default:
                    break;

            }


            int pageTotal = 0;
            DataTable logtable = BAL.SelectByTimeCategoryContentPagelist(startTime, endTime, category, txtLogContent.Text.ToString().Trim(), 1, 5, ref pageTotal);

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
                    gcBackgroundLogList.DataSource = BAL.SelectByTimeCategoryContentPagelist(startTime, endTime, category, txtLogContent.Text.ToString().Trim(), currentIndex + 1, 5, ref pageTotal);
                }
                else
                {
                    gcBackgroundLogList.DataSource = BAL.SelectByTimeCategoryContentPagelist(startTime, endTime, category, txtLogContent.Text.ToString().Trim(), totalPage, 5, ref pageTotal);
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
            ///多条件查询
            startTime = Convert.ToDateTime(dtpBegin.Text);
            endTime = Convert.ToDateTime(dtpEnd.Text);
            int pageNo = Convert.ToInt32(txtpage.Text);

            string category = "INFO";
            int selectCategory = cbcategory.SelectedIndex;
            switch (selectCategory)
            {
                case 0:  //所有
                    category = null;
                    break;
                case 1://调试
                    category = "INFO";
                    break;
                case 2://警告
                    category = "INFO";
                    break;
                case 3: //错误
                    category = "INFO";
                    break;
                case 4: //致命错误
                    category = "INFO";
                    break;
                default:
                    break;

            }
            int pageTotal = 0;
            DataTable logtable = BAL.SelectByTimeCategoryContentPagelist(startTime, endTime, category, txtLogContent.Text.ToString().Trim(), 1, 5, ref pageTotal);

            int totalPage = (pageTotal + 5 - 1) / 5;

            gcBackgroundLogList.DataSource = BAL.SelectByTimeNameContentPagelist(startTime, endTime, category, txtLogContent.Text.ToString().Trim(), totalPage, 5, ref pageTotal);

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
