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
    public partial class ucBackgroundLog : ucBase
    {
        private MVVMContextFluentAPI<LogManagerViewModel> fluent;
        public ucBackgroundLog()
        {
            InitializeComponent();
            InitComboBox();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        public void InitComboBox()
        {
            // cbeLogType.Properties.Items.Add();
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            dtpBegin.Value = dt.AddMonths(-1);
            DateTime dt2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            dtpEnd.Value = dt2;

            cbePageRecord.SelectedIndex = 0;

            enableControl(false);
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
                AddBinding(fluent.SetBinding(gcBackGroundLog, gControl => gControl.DataSource, x => x.BackgroundLogEntities, m =>
                {
                    int count = Convert.ToInt16(cbePageRecord.SelectedItem);
                    int currentPage = Convert.ToInt16(tslCurrentPage.Text) - 1;
                    if (m == null) return m;
                    for (int i = 0; i < m.Count; i++)
                    {
                        ((DTBackgroundLogInfo)m[i]).Serial.Value = count * (currentPage < 0 ? 0 : currentPage) + i + 1;
                    }
                    return m;
                }));
                AddBinding(fluent.SetBinding(tslTotalPage, lc => lc.Text, x => x.BackgroundTotalPage,m =>{
                       return m.ToString();
                   }));
                AddBinding(fluent.SetBinding(tslCount, lc => lc.Text, x => x.BackgroundTotalCount, m => { return m.ToString(); }));
                //显示最近一个月的日志，倒序排列
                List<object> list = new List<object>
                    {
                    LogManagerViewModel.ExecuteCommand.ec_QueryBackgroundLog,
                    dtpBegin.Value,
                    dtpEnd.Value,
                    cbePageRecord.Text,
                    cbeLogType.SelectedIndex==0?"":cbeLogType.SelectedIndex.ToString(),
                    beLogContent.Text
                    };
                LogManagerViewModel.VM.Execute(list);
                LogManagerViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(LogManagerViewModel).Name) action();
                };

                if (LogManagerViewModel.VM.BackgroundLogEntities != null && LogManagerViewModel.VM.BackgroundLogEntities.Count != 0) tslCurrentPage.Text = "1";
               
                base.InitializeBindings();
                pageControl();
            }
            catch (Exception ex)
            {
                //  ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        /// <summary>
        /// mvvm action
        /// </summary>
        /// <param name="json"></param>
        protected override void doAction(string json = "")
        {
            if(gcBackGroundLog != null && gcBackGroundLog.DataSource != null) gcBackGroundLog.DataSource = null;
            base.doAction();
        }

        private void gvAirQuality_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "LogType") return;
            if (e.Value == null) return;
            LogTypeString logType = new LogTypeString();
            switch (e.Value.ToString())
            {
                case "1":
                    e.DisplayText = logType.Debug;
                    break;
                case "2":
                    e.DisplayText = logType.Warnning;
                    break;
                case "3":
                    e.DisplayText = logType.Bug;
                    break;
                case "4":
                    e.DisplayText = logType.Error;
                    break;
            }
        }

        #region Text Clear
        private void beLogContent_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Clear") { beLogContent.Text = ""; }
        }

        private void beLogContent_EditValueChanged(object sender, EventArgs e)
        {
            beLogContent.Properties.Buttons[0].Visible = beLogContent.Text != "" ? true : false;
            beLogContent.Properties.Buttons[0].Enabled = beLogContent.Text != "" ? true : false;
        }

        private void ucBackgroundLog_Load(object sender, EventArgs e)
        {
            beLogContent.Properties.Buttons[0].Visible = false;
            beLogContent.Properties.Buttons[0].Enabled = false;
        }

        #endregion

        private void sbSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime beginDate = Convert.ToDateTime(dtpBegin.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                DateTime endDate = Convert.ToDateTime(dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                tslCurrentPage.Text = "0";
                if (DateTime.Compare(beginDate, endDate) > 0) XtraMessageBox.Show("时间错误！");//开始日期大于结束日期 返回false
                else
                {
                    
                    List<object> list = new List<object>
                    {
                    LogManagerViewModel.ExecuteCommand.ec_QueryBackgroundLog,
                    dtpBegin.Text,
                    dtpEnd.Text,
                    cbePageRecord.Text,
                    cbeLogType.SelectedIndex==0?"":cbeLogType.SelectedIndex.ToString(),
                    beLogContent.Text
                    };
                    LogManagerViewModel.VM.Execute(list);
                    if(LogManagerViewModel.VM.BackgroundLogEntities==null|| LogManagerViewModel.VM.BackgroundLogEntities.Count==0)
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
                    LogManagerViewModel.ExecuteCommand.ec_QueryBackgroundLogPage,
                    dtpBegin.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    currentPage,
                    cbePageRecord.Text,
                    cbeLogType.SelectedIndex==0?"":cbeLogType.SelectedIndex.ToString(),
                    beLogContent.Text
                };
                LogManagerViewModel.VM.Execute(list);
            }
            if (LogManagerViewModel.VM.BackgroundLogEntities != null && LogManagerViewModel.VM.BackgroundLogEntities.Count != 0) tslCurrentPage.Text = currentPage.ToString();
            pageControl();
        }

        private void enableControl(bool status)
        {
            tsbFirstPage.Enabled = status;
            tsbEndPage.Enabled = status;
            tsbLastPage.Enabled = status;
            tsbNextPage.Enabled = status;
      //      tsbGotoPage.Enabled = status;
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
                else if (tslCurrentPage.Text == "1" && Convert.ToInt16(tslTotalPage.Text) > 1)
                {
                    tsbNextPage.Enabled = true;
                    tsbLastPage.Enabled = false;
                }
                //当前页为中间页
                else
                {
                    tsbNextPage.Enabled = true;
                    tsbLastPage.Enabled = true;
                }
            }
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
            int currentPage = LogManagerViewModel.VM.BackgroundTotalPage;
            tslCurrentPage.Text = currentPage.ToString();
            if (Convert.ToInt16(tslCurrentPage.Text) > 1)
            QueryRunningLogPage(currentPage);
        }

        private void tsbGotoPage_Click_1(object sender, EventArgs e)
        {
            if (numGoPage.Text == "") XtraMessageBox.Show("输入不能为空！");
            int currentPage = (int)numGoPage.Value;
            if (currentPage == 0 || currentPage > LogManagerViewModel.VM.BackgroundTotalPage)
            {
                XtraMessageBox.Show("该页面不存在！");
                return;
            }
            tslCurrentPage.Text = currentPage.ToString();
            QueryRunningLogPage(currentPage);
        }

        #endregion

        private void cbePageRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryRunningLogPage(1);
            sbSearch.Focus();
        }
    }
}
public class LogTypeString
{
    private string _Debug = "调试";
    public string Debug { get { return _Debug; } }
    private string _Warnning = "警告";
    public string Warnning { get { return _Warnning; } }
    private string _Bug = "错误";
    public string Bug { get { return _Bug; } }
    private string _Error = "致命错误";
    public string Error { get { return _Error; } }

}

