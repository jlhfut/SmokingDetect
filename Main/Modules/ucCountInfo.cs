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
using wayeal.os.exhaust.BAL.ImBAL;
using DevExpress.XtraCharts;

namespace wayeal.os.exhaust.Modules
{
    public partial class ucCountInfo : ucManagerBase
    {
        //开始时间
        DateTime startTime = Convert.ToDateTime("2020-12-25");
        //结束时间
        DateTime endTime = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        IVehicleBAL BAL = new ImVehicleBAL();

        public ucCountInfo()
        {
            InitializeComponent();
           
            DataTable table = BAL.GetVehicleByDateTime(Convert.ToDateTime("2020-12-25"), Convert.ToDateTime("2020-12-25"));

            DrawVehicleCount(table);

        }



        private void DrawVehicleCount(DataTable table)
        {
           
            Series _pieSeries = new Series("黑烟统计信息", ViewType.Pie);
            SeriesPoint point;
            string title1="";
            double title2=0.0;

            for (int i = 0; i < table.Rows.Count; i++)


            {


                switch (table.Rows[i]["vringelman"])
                {
                    case 1:
                         title1 = "林格曼黑度Ⅰ级";
                        //title2 = "林格曼黑度Ⅰ级:" + (Convert.ToDouble(table.Rows[i]["count"].ToString()));
                        title2 = Convert.ToDouble(table.Rows[i]["count"].ToString());
                        break;
                    case 2:
                        title1 = "林格曼黑度Ⅱ级";
                        //title2 = "林格曼黑度Ⅱ级:" + (Convert.ToDouble(table.Rows[i]["count"].ToString()));
                        title2 = Convert.ToDouble(table.Rows[i]["count"].ToString());
                        break;


                    case 3:
                        title1 = "林格曼黑度Ⅲ级";
                        // title2 = "林格曼黑度Ⅲ级:" + (Convert.ToDouble(table.Rows[i]["count"].ToString()));
                        title2 = Convert.ToDouble(table.Rows[i]["count"].ToString());
                        break;

                    case 4:
                        title1 = "林格曼黑度Ⅳ级";
                        //title2 = "林格曼黑度Ⅳ级:" + (Convert.ToDouble(table.Rows[i]["count"].ToString()));
                        title2 = Convert.ToDouble(table.Rows[i]["count"].ToString());
                        break;

                    case 5:
                        title1 = "林格曼黑度Ⅴ级";
                        //title2 = "林格曼黑度Ⅴ级:" + (Convert.ToDouble(table.Rows[i]["count"].ToString()));
                        title2 =  Convert.ToDouble(table.Rows[i]["count"].ToString());
                        break;

                   

                }
                point = new SeriesPoint(title1, title2);
                
                _pieSeries.Points.Add(point);
                //针对每一项作出解释
                _pieSeries.PointOptions.PointView = PointView.ArgumentAndValues;
                

            }

            // _pieSeries.LegendPointOptions.PointView = PointView.ArgumentAndValues;
            _pieSeries.Label.Font = new Font("Microsoft YaHei UI", 12);
            _pieSeries.Label.LineLength = 50;
           
            _pieSeries.DataSource = table;
            chartControl1.Series.Add(_pieSeries);
            
        }


        /// <summary>
        /// 导出结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"d:\DevS\黑烟级别统计信息.png";

            if (chartControl1.IsPrintingAvailable)
            {
                chartControl1.ExportToImage(path, System.Drawing.Imaging.ImageFormat.Png);
                MessageBox.Show("保存成功！保存位置："+path);
            }
            //if (chartControlidx.IsPrintingAvailable) //是否能被打印或输出
            //{
            //    // Create an image in the specified format from the chart and save it to the specified path.
            //    chartControlidx.ExportToImage(path, System.Drawing.Imaging.ImageFormat.Png);   //png格式
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {

            chartControl1.Series.Clear();
            //开始时间
            startTime = Convert.ToDateTime(dtpBegin.Text);


            //结束时间
            endTime = Convert.ToDateTime(dtpEnd.Text);
            DataTable table = BAL.GetVehicleByDateTime(startTime,endTime);

            if (table.Rows.Count > 0)
            {
                DrawVehicleCount(table);
            }
            else
            {
                MessageBox.Show("未查到记录！请确认查询条件");
            }
            

          



        }
    }
}
