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
using wayeal.os.exhaust.BAL.ImBAL;
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.From;

namespace wayeal.os.exhaust.Modules
{
    public partial class ucRealHistory :ucManagerBase
    {
        IVehicleBAL BAL = new ImVehicleBAL();

        int resultTotal = 0;  //总共记录条数


        int pageCurrIndex = 1;//当前页码
        public ucRealHistory()
        {
            InitializeComponent();
            gcVehicleInfo.DataSource = BAL.SelectAllVehicle();
            lblTotal.Text = BAL.GetTotal().ToString();
            lblResultTotal.Text = PageTotal(5, 5).ToString();
            lblIndex.Text = "1";
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            
           int index= gridView1.GetFocusedDataSourceRowIndex();
            int id = Convert.ToInt32(gridView1.GetRowCellValue(index, "vid"));
            int total = BAL.GetTotal();
          

          
            

            wfVehileDetails vehileDetails = new wfVehileDetails(id,total);
            vehileDetails.Show();
           
           
        }

        private void gcVehicleInfo_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 多条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbQuary_Click(object sender, EventArgs e)
        {

            DateTime startTime = Convert.ToDateTime(dtpBegin.Text);
            DateTime endTime = Convert.ToDateTime(dtpBegin.Text);
            string vno = txtvNo.Text.Trim();//车牌号
            string vcolo=null;//车身颜色
            int ? vrin=null;//林格曼系数

            int total = 0;
            
            if(cbeColor.SelectedItem.ToString() == "所有")
            {
                vcolo = null;
            }
            else
            {
               
                vcolo = cbeColor.SelectedItem.ToString();

               
            }
            switch (cbeRegin.SelectedIndex)
            {
                case 0:
                    vrin = null;
                   
                    break;
                case 1:
                    vrin = 1;
                    break;
                case 2:
                    vrin = 2;
                    break;
                case 3:
                    vrin = 3;
                    break;
                case 4:
                    vrin = 4;
                    break;
                case 5:
                    vrin = 5;
                    break;

            }
            DataTable dt = BAL.GetVehiclesByMulCondition(startTime, endTime, vno, vcolo, vrin, 1, 5, ref total);
            

            gcVehicleInfo.DataSource = dt;
            resultTotal = total;


            //设置底部信息

            //总共条数
            lblTotal.Text = total.ToString();
            //总共页数
            lblResultTotal.Text = PageTotal(total, 5).ToString();
            //当前页
            lblIndex.Text = "1";
            lblTotal.Text = total.ToString();

            //为全局当前页设最新值
            pageCurrIndex = 1;

        }

        /// <summary>
        /// 跳转页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startTime = Convert.ToDateTime(dtpBegin.Text);
            DateTime endTime = Convert.ToDateTime(dtpBegin.Text);
            string vno = txtvNo.Text.Trim();//车牌号
            string vcolo;//车身颜色
           
            int? vrin = null;//林格曼系数

            int pageSize = Convert.ToInt32(cbeSelectpage.SelectedItem);
            int pageIndex = Convert.ToInt32(txtpage.Text);

            int total = 0;

            if (cbeColor.SelectedItem.ToString() == "所有")
            {
                vcolo = null;
            }
            else
            {
                vcolo = cbeColor.SelectedItem.ToString();
            }
            switch (cbeRegin.SelectedIndex)
            {
                case 0:
                    vrin = 0;
                    break;
                case 1:
                    vrin = 1;
                    break;
                case 2:
                    vrin = 2;
                    break;
                case 3:
                    vrin = 3;
                    break;
                case 4:
                    vrin = 4;
                    break;
                case 5:
                    vrin = 5;
                    break;

            }

            int pIndex = Convert.ToInt32(txtpage.Text);

           


            //输入的页数应该有防范机制

            if (pIndex > PageTotal(total, pageSize))   //输入的页数超过最大页数
            {
                pIndex = PageTotal(total, pageSize);
                gcVehicleInfo.DataSource = BAL.GetVehiclesByMulCondition(startTime, endTime, vno, vcolo, vrin, pIndex, pageSize, ref total);

                lblTotal.Text = total.ToString();

                lblResultTotal.Text = PageTotal(total, pageSize).ToString();//总共多少页
            }
            else
            {
                gcVehicleInfo.DataSource = BAL.GetVehiclesByMulCondition(startTime, endTime, vno, vcolo, vrin, pIndex, pageSize, ref total);

                lblTotal.Text = total.ToString();

                lblResultTotal.Text = PageTotal(total, pageSize).ToString();//总共多少页
            }

            resultTotal = total;//总记录的条数
           
        }


        //导出查询结果  excel
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "历史数据统计";
            fileDialog.Filter = "Excel文件(#.xls)|*.xls";
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                gcVehicleInfo.ExportToXls(fileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功", "提示",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            
        }

        private void gridView1_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DataView bindingSource = gv.DataSource as DataView;

            if (bindingSource != null & bindingSource.Count ==0 )
            {
                Font f = new Font("宋体", 9, FontStyle.Bold);
                Rectangle r = new Rectangle(gv.GridControl.Width /2 -100 , gv.GridControl.Height /2 , e.Bounds.Right -5 , e.Bounds.Height -5 );
                e.Graphics.DrawString("没有查询到数据!", f, Brushes.Red, r);
            }
        }


        /// <summary>
        /// 计算总页数
        /// </summary>
        /// <param name="totalRecord"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
       private int PageTotal(int totalRecord,int pageSize)
        {
            

            return (totalRecord + pageSize - 1) / pageSize;

        }


        /// <summary>
        /// 首页数据展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            /**
             * 1.获取所有查询条件
             * 2.查询结果   将index置为1
             * 
             **/

            //获取开始时间
            DateTime startTime = Convert.ToDateTime(dtpBegin.Text);
            //获取截止时间
            DateTime endTime = Convert.ToDateTime(dtpBegin.Text);
            //车牌号
            string vno = txtvNo.Text.Trim();
            //车身颜色
            string vcolo;

            int? vrin = null;

            //每页展示的数据条数
            int pageSize =5;
            

            int total = 0;
            //林格曼系数
            if (cbeColor.SelectedItem.ToString() == "所有")
            {
                vcolo = null;
            }
            else
            {
                vcolo = cbeColor.SelectedItem.ToString();
            }
            switch (cbeRegin.SelectedIndex)
            {
                case 0:
                    vrin = 0;
                    break;
                case 1:
                    vrin = 1;
                    break;
                case 2:
                    vrin = 2;
                    break;
                case 3:
                    vrin = 3;
                    break;
                case 4:
                    vrin = 4;
                    break;
                case 5:
                    vrin = 5;
                    break;

            }



            //查询数据

            gcVehicleInfo.DataSource = BAL.GetVehiclesByMulCondition(startTime, endTime, vno, vcolo, vrin,1, pageSize, ref total);//展示查询数据



            //设置底部信息

            //总共条数
            lblTotal.Text = total.ToString();
            //总共页数
            lblResultTotal.Text = PageTotal(total, pageSize).ToString();
            //当前页
            lblIndex.Text = "1";
            lblTotal.Text = total.ToString();

            //为全局当前页设最新值
            pageCurrIndex = 1;


        }


        /// <summary>
        /// 最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {


            /***
             * 1.保存查询记录的条件
             * 2.查询记录
             * 3.更新公共值
             * 
             * */

            //开始时间
            DateTime startTime = Convert.ToDateTime(dtpBegin.Text);
            //结束时间
            DateTime endTime = Convert.ToDateTime(dtpBegin.Text);
            //车牌号
            string vno = txtvNo.Text.Trim();
            //车身颜色
            string vcolo=null;
            //林格曼系数
            int? vrin = null;

            int pageSize = Convert.ToInt32(cbeSelectpage.SelectedItem);
            

            int total = 0;

            if (cbeColor.SelectedItem.ToString() == "所有")
            {
                vcolo = null;
            }
            else
            {
                vcolo = cbeColor.SelectedItem.ToString();
            }
            switch (cbeRegin.SelectedIndex)
            {
                case 0:
                    vrin = 0;
                    break;
                case 1:
                    vrin = 1;
                    break;
                case 2:
                    vrin = 2;
                    break;
                case 3:
                    vrin = 3;
                    break;
                case 4:
                    vrin = 4;
                    break;
                case 5:
                    vrin = 5;
                    break;

            }
            
            int pIndex = Convert.ToInt32(lblIndex.Text);




            //查询数据

             BAL.GetVehiclesByMulCondition(startTime, endTime, vno, vcolo, vrin, 1, pageSize, ref total);//展示查询数据
            int pageIndex = PageTotal(total,pageSize);


            //查询数据

            gcVehicleInfo.DataSource = BAL.GetVehiclesByMulCondition(startTime, endTime, vno, vcolo, vrin, pageIndex, pageSize, ref total);//展示查询数据
            //设置底部信息

            //总共条数
            lblTotal.Text = total.ToString();
            //总共页数
            lblResultTotal.Text = PageTotal(total, pageSize).ToString();
            //当前页
            lblIndex.Text = pageIndex.ToString();
            lblTotal.Text = total.ToString();
            //为全局当前页设最新值
            pageCurrIndex = pageIndex;
            
        }


        //前一页
        private void button2_Click(object sender, EventArgs e)
        {

            /***
             * 1.获取查询信息
             * 2.判断页面索引是否正确
             * 
             * */

            //获取开始时间
            DateTime startTime = Convert.ToDateTime(dtpBegin.Text);
            //获取结束时间
            DateTime endTime = Convert.ToDateTime(dtpBegin.Text);
            //获取车牌号
            string vno = txtvNo.Text.Trim();
            //获取车身颜色
            string vcolo=null;
            //林格曼系数
            int? vrin = null;

            int pageSize = Convert.ToInt32(cbeSelectpage.SelectedItem);
          
            int total = 0;

            int pIndex = pageCurrIndex - 1;
            if (cbeColor.SelectedItem.ToString() == "所有")
            {
                vcolo = null;
            }
            else
            {
                vcolo = cbeColor.SelectedItem.ToString();
            }
            switch (cbeRegin.SelectedIndex)
            {
                case 0:
                    vrin = 0;
                    break;
                case 1:
                    vrin = 1;
                    break;
                case 2:
                    vrin = 2;
                    break;
                case 3:
                    vrin = 3;
                    break;
                case 4:
                    vrin = 4;
                    break;
                case 5:
                    vrin = 5;
                    break;

            }

            if (cbeColor.SelectedItem.ToString() == "所有")
            {
                vcolo = null;
            }
            else
            {
                vcolo = cbeColor.SelectedItem.ToString();
            }
            switch (cbeRegin.SelectedIndex)
            {
                case 0:
                    vrin = 0;
                    break;
                case 1:
                    vrin = 1;
                    break;
                case 2:
                    vrin = 2;
                    break;
                case 3:
                    vrin = 3;
                    break;
                case 4:
                    vrin = 4;
                    break;
                case 5:
                    vrin = 5;
                    break;

            }


            ///判断上一页是否超标

            if (pageCurrIndex > 1)  //当前索引是否大于1  大于1意味着可以减
            {

                pIndex = pageCurrIndex - 1;
                    gcVehicleInfo.DataSource = BAL.GetVehiclesByMulCondition(startTime, endTime, vno, vcolo, vrin, pIndex, pageSize, ref total);

                    lblTotal.Text = total.ToString();

               
            }
            else
            {
                gcVehicleInfo.DataSource = BAL.GetVehiclesByMulCondition(startTime, endTime, vno, vcolo, vrin, pageCurrIndex, pageSize, ref total);

                
            }


            //总共条数
            lblTotal.Text = total.ToString();
            //总共页数
            lblResultTotal.Text = PageTotal(total, pageSize).ToString();
            //当前页
            lblIndex.Text = (pageCurrIndex - 1).ToString();
            lblTotal.Text = total.ToString();
            //为全局当前页设最新值

            if (pageCurrIndex < 0)
            {
                pageCurrIndex = 1;
            }
            else
            {
                pageCurrIndex = pageCurrIndex - 1;
            }
            

        }


        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {

            /***
             * 1.获取查询的基本条件信息
             * 2.判断页面条件，是否大于总页数
             *      如果大于只显示当前页数
             *      如果小于页面索引加1
             * **/

            DateTime startTime = Convert.ToDateTime(dtpBegin.Text);  //获取查询开始时间
            DateTime endTime = Convert.ToDateTime(dtpBegin.Text);//获取查询最晚时间
            string vno = txtvNo.Text.Trim();//车牌号
            string vcolo = null;//车身颜色
            int? vrin = null;//林格曼系数

            int total = 0;   //记录的总条数

            //获取颜色信息

            if (cbeColor.SelectedItem.ToString() == "所有")
            {
                vcolo = null;
            }
            else
            {

                vcolo = cbeColor.SelectedItem.ToString();

              
            }

            //获取林格曼系数信息
            switch (cbeRegin.SelectedIndex)
            {
                case 0:
                    vrin = null;

                    break;
                case 1:
                    vrin = 1;
                    break;
                case 2:
                    vrin = 2;
                    break;
                case 3:
                    vrin = 3;
                    break;
                case 4:
                    vrin = 4;
                    break;
                case 5:
                    vrin = 5;
                    break;

            }

            //获取页面条数

            int pageSize = Convert.ToInt32(cbeSelectpage.SelectedItem);
             BAL.GetVehiclesByMulCondition(startTime, endTime, vno, vcolo, vrin, 1, 5, ref total);
            int temp = pageCurrIndex + 1;

            int index = PageTotal(total, pageSize);

            
            if(temp < index)
            {
                //多条件查询
                gcVehicleInfo.DataSource = BAL.GetVehiclesByMulCondition(startTime, endTime, vno, vcolo, vrin, temp, pageSize, ref total);
                //为全局当前页设最新值
                pageCurrIndex = temp;
            }
            else
            {
                //多条件查询
                gcVehicleInfo.DataSource = BAL.GetVehiclesByMulCondition(startTime, endTime, vno, vcolo, vrin, index, pageSize, ref total);
                //为全局当前页设最新值
                pageCurrIndex = pageCurrIndex+0 ;
            }

            //总共条数
            lblTotal.Text = total.ToString();
            //总共页数
            lblResultTotal.Text = PageTotal(total, pageSize).ToString();
            //当前页
            lblIndex.Text = (pageCurrIndex - 1).ToString();
            lblTotal.Text = total.ToString();
            
           




        }
    }

    
       

    }


