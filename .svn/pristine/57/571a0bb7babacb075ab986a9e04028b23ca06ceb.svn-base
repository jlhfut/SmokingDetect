using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.MVVM;
using Wayee.Services;
using DevExpress.XtraEditors;

namespace wayeal.plugin
{
    public partial class ucRunningLog : ucBase
    {
        private MVVMContextFluentAPI<LogManagerViewModel> fluent;
        public ucRunningLog()
        {
            InitializeComponent();
            InitComboBox();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        /// <summary>
        /// Init
        /// </summary>
        protected override void InitializeBindings()
        {
            try
            {
                mvvmContext1.SetViewModel(typeof(LogManagerViewModel), LogManagerViewModel.VM);
                fluent = mvvmContext1.OfType<LogManagerViewModel>();
                AddBinding(fluent.SetBinding(gcRunningLog, gControl => gControl.DataSource, x => x.RunningLogEntities, m =>
                {
                    int count = Convert.ToInt16(cbePageRecord.Text);
                    int currentPage = Convert.ToInt16(tslCurrentPage.Text) - 1;
                    for (int i = 0; i < m.Count; i++)
                    {
                        ((DTRunningLogInfo)m[i]).Serial.Value = count * (currentPage < 0 ? 0 : currentPage) + i + 1;
                    }
                    return m;
                }));
                AddBinding(fluent.SetBinding(tslTotalPage, lc => lc.Text, x => x.RunningTotalPage,
                   m =>
                   {
                       return m.ToString();
                   }));
                LogManagerViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(LogManagerViewModel).Name) action();
                };

                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                //ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        public void InitComboBox()
        {
            // cbeLogType.Properties.Items.Add();
            dtpBegin.Value = System.DateTime.Now.AddMonths(-1);
            dtpEnd.Value = DateTime.Now;

            int[] PageRecord = { 20, 40, 60, 80, 100 };
            cbePageRecord.Items.Add(PageRecord[0]);
            cbePageRecord.SelectedItem = PageRecord[0];
            cbePageRecord.Items.Add(PageRecord[1]);
            cbePageRecord.Items.Add(PageRecord[2]);
            cbePageRecord.Items.Add(PageRecord[3]);
            cbePageRecord.Items.Add(PageRecord[4]);

            enableControl(false);
        }

        /// <summary>
        /// mvvm action
        /// </summary>
        /// <param name="json"></param>
        protected override void doAction(string json = "")
        {
            if (gcRunningLog != null && gcRunningLog.DataSource != null) gcRunningLog.DataSource = null;
            base.doAction();
        }

        #region TextEdit
        private void beLogContent_EditValueChanged(object sender, EventArgs e)
        {
            beLogContent.Properties.Buttons[0].Visible = beLogContent.Text != "" ? true : false;
            beLogContent.Properties.Buttons[0].Enabled = beLogContent.Text != "" ? true : false;
        }

        private void ucRunningLog_Load(object sender, EventArgs e)
        {
            beLogContent.Properties.Buttons[0].Visible = false;
            beLogContent.Properties.Buttons[0].Enabled = false;
        }

        private void beLogContent_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Clear") { beLogContent.Text = ""; }
        }
        #endregion

        private void sbSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime beginDate = Convert.ToDateTime(dtpBegin.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                DateTime endDate = Convert.ToDateTime(dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                tslCurrentPage.Text = "0";//清空tslcurrentpage，用于计算序号

                if (DateTime.Compare(beginDate, endDate) > 0) XtraMessageBox.Show("时间错误！");//开始日期大于结束日期 返回false
                else
                {
                    List<object> list = new List<object>
                    {
                     LogManagerViewModel.ExecuteCommand.ec_QueryRunningLog,
                    dtpBegin.Text ,
                    dtpEnd.Text ,
                    cbePageRecord.SelectedItem,
                    beLogContent.Text
                    };
                    LogManagerViewModel.VM.Execute(list);
                    if (LogManagerViewModel.VM.RunningLogEntities == null || LogManagerViewModel.VM.RunningLogEntities.Count == 0)
                        XtraMessageBox.Show("查询结果为空！");
                    if (tslTotalPage.Text != "0") tslCurrentPage.Text = "1";

                    tsbGotoPage.Enabled = true;
                    pageControl();
                }
            }
            catch (Exception ex)
            {

            }
        }
        #region 分页查询
        private void QueryRunningLogPage(int currentPage)
        {
            DateTime beginDate = Convert.ToDateTime(dtpBegin.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            DateTime endDate = Convert.ToDateTime(dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            if (DateTime.Compare(beginDate, endDate) > 0) XtraMessageBox.Show("时间错误！");//开始日期大于结束日期 返回false
            else
            {
                List<object> list = new List<object>
                {
                     LogManagerViewModel.ExecuteCommand.ec_QueryRunningLogPage,
                    dtpBegin.Text ,
                    dtpEnd.Text ,
                    currentPage,
                    cbePageRecord.Text,
                    beLogContent.Text
                };
                LogManagerViewModel.VM.Execute(list);
                pageControl();
            }
        }

        private void enableControl(bool status)
        {
            tsbFirstPage.Enabled = status;
            tsbEndPage.Enabled = status;
            tsbLastPage.Enabled = status;
            tsbNextPage.Enabled = status;
         //   tsbGotoPage.Enabled = status;
        }

        /// <summary>
        /// 控制翻页按钮使能
        /// </summary>
        private void pageControl()
        {
            if (tslTotalPage.Text == "0")
            {
                tsbFirstPage.Enabled = false;
                tsbEndPage.Enabled = false;
            }
            else
            {
                tsbFirstPage.Enabled = true;
                tsbEndPage.Enabled = true;
            }

            //总页数为1（或0）页
            if (tslTotalPage.Text == "1" || tslTotalPage.Text == "0")
            {
                tsbNextPage.Enabled = false;
                tsbLastPage.Enabled = false;
            }
            else
            {
                //当前页为末页
                if (tslCurrentPage.Text != "1" && tslTotalPage.Text == tslCurrentPage.Text)
                {
                    tsbNextPage.Enabled = false;
                    tsbLastPage.Enabled = true;
                }
                //当前页为首页
                if (tslCurrentPage.Text == "1" && Convert.ToInt16(tslTotalPage.Text) > 1)
                {
                    tsbNextPage.Enabled = true;
                    tsbLastPage.Enabled = false;
                }
            }
        }

        private void tsbFirstPage_Click(object sender, EventArgs e)
        {
            int currentPage = 1;
            tslCurrentPage.Text = currentPage.ToString();
            QueryRunningLogPage(currentPage);
        }

        private void tsbLastPage_Click(object sender, EventArgs e)
        {
            if (tsbNextPage.Enabled == false) tsbNextPage.Enabled = true;
            int currentPage = Convert.ToInt16(tslCurrentPage.Text) - 1;
            tslCurrentPage.Text = currentPage.ToString();
            QueryRunningLogPage(currentPage);
        }

        private void tsbNextPage_Click(object sender, EventArgs e)
        {
            if (tsbLastPage.Enabled == false) tsbLastPage.Enabled = true;
            int currentPage = Convert.ToInt16(tslCurrentPage.Text) + 1;
            tslCurrentPage.Text = currentPage.ToString();
            QueryRunningLogPage(currentPage);
        }

        private void tsbEndPage_Click(object sender, EventArgs e)
        {
            int currentPage = LogManagerViewModel.VM.RunningTotalPage;
            tslCurrentPage.Text = currentPage.ToString();
            QueryRunningLogPage(currentPage);
        }

        private void tsbGotoPage_Click_1(object sender, EventArgs e)
        {
            if (numGoPage.Text == "") XtraMessageBox.Show("输入不能为空！");
            int currentPage = (int)numGoPage.Value;
            if (currentPage == 0 || currentPage > LogManagerViewModel.VM.RunningTotalPage)
            {
                XtraMessageBox.Show("该页面不存在！");
                return;
            }
            tslCurrentPage.Text = currentPage.ToString();
            QueryRunningLogPage(currentPage);
        }

        private void toolStrip1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if ((sender as ToolStrip).RenderMode == ToolStripRenderMode.System)
                {
                    Rectangle rect = new Rectangle(0, 0, this.toolStrip1.Width, this.toolStrip1.Height - 2);
                    e.Graphics.SetClip(rect);
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion


    }
}
