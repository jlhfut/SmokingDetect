using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.ViewModel;
using DevExpress.Utils.MVVM;
using Wayee.Services;
using DevExpress.XtraEditors;
using DevExpress.Mvvm;
using wayeal.plugin;

namespace wayeal.os.exhaust.Modules
{
    public partial class ucAirQuality : ucManagerBase
    {
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        int currentPage = 1;
        const string c_AirQuality = "AirQuality";
        const string c_COName = "CO";
        const string c_NO2Name = "NO₂";
        const string c_O3Name = "O₃";
        const string c_SO2Name = "SO₂";
        const string c_PM25Name = "PM2.5";
        const string c_PM10Name = "PM10";
        const string c_LeftParen = "(";
        const string c_RightParen = ")";
        private AirUnit _unit = new AirUnit();
        public AirUnit Unit  { get{ return _unit; }set { _unit = value; } }
        public ucAirQuality()
        {
            InitializeComponent();
            InitializeUI();
            InitGridViewFont();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        private void InitGridViewFont()
        {
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            dtpBegin.Value = dt;//.AddMonths(-1);
            DateTime dt2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            dtpEnd.Value = dt2;
            cbePageRecord.SelectedIndex = 0;
            enableControl(false);
            //初始化单位
            RealtimeMonitorViewModel.VM.Devices = null;
            SetUnit();
        }
        /// <summary>
        /// Init
        /// </summary>
        protected override void InitializeBindings()
        {
            try
            {
                //ResultDataViewModel.VM.Execute(new List<object> {
                //    ResultDataViewModel.ExecuteCommand.ec_QueryAirQuality,
                //    dtpBegin.Value.ToString(),
                //    dtpEnd.Value.ToString (),
                //    currentPage,
                //    cbePageRecord.SelectedItem,
                //});
                mvvmContext1.SetViewModel(typeof(ResultDataViewModel), ResultDataViewModel.VM);
                fluent = mvvmContext1.OfType<ResultDataViewModel>();
                AddBinding(fluent.SetBinding(gcAirQuality, gControl => gControl.DataSource, x => x.AirQualityEntities, m => {
                    if (m == null) return null ;
                    for (int i = 0; i < m.Count; i++)
                    {
                        ((DTAirQualityInfo)m[i]).Serial.Value = i + 1;
                    }
                    return m; }));
                AddBinding(fluent.SetBinding(tslTotalPage, page => page.Text, x => x.AirQualityTotalPage, m =>
                {
                    if (m > 0) tslCurrentPage.Text = currentPage.ToString();
                    if (Convert.ToInt32(tslCurrentPage.Text) > m) tslCurrentPage.Text = m.ToString();
                    return m.ToString();
                }));

                AddBinding(fluent.SetBinding(gcPM10, ce => ce.Caption, x => x.AirQuality.Param, m => {
                    string unit= RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, gcPM10.Name.Substring(2)).Replace("m3", "m³");
                    return c_PM10Name + c_LeftParen + unit + c_RightParen;
                }));
                AddBinding(fluent.SetBinding(gcPM25, ce => ce.Caption, x => x.AirQuality.Param, m => {
                    string unit = RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, gcPM25.Name.Substring(2)).Replace("m3", "m³");
                    return c_PM25Name + c_LeftParen + unit + c_RightParen;
                }));
                AddBinding(fluent.SetBinding(gcCO, ce => ce.Caption, x => x.AirQuality.Param, m => {
                    string unit = RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, gcCO.Name.Substring(2)).Replace("m3", "m³");
                    return c_COName + c_LeftParen + unit + c_RightParen;
                }));
                AddBinding(fluent.SetBinding(gcSO2, ce => ce.Caption, x => x.AirQuality.Param, m => {
                    string unit = RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, gcSO2.Name.Substring(2)).Replace("m3", "m³");
                    return c_SO2Name + c_LeftParen + unit + c_RightParen;
                }));
                AddBinding(fluent.SetBinding(gcNO2, ce => ce.Caption, x => x.AirQuality.Param, m => {
                    string unit = RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, gcNO2.Name.Substring(2)).Replace("m3", "m³");
                    return c_NO2Name + c_LeftParen + unit + c_RightParen;
                }));
                AddBinding(fluent.SetBinding(gcO3, ce => ce.Caption, x => x.AirQuality.Param, m => {
                    string unit = RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, gcO3.Name.Substring(2)).Replace("m3", "m³");
                    return c_O3Name + c_LeftParen + unit + c_RightParen;
                }));
                AddBinding(fluent.SetBinding(tslCount, count => count.Text, x => x.AirQualityTotalCount, m => { return m.ToString(); }));

                ResultDataViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == typeof(ResultDataViewModel).Name) action();
                };

                base.InitializeBindings();
                Messenger.Default.Register<ucPluginBase.DeviceNotifyEventArgs>(this, (args) => {
                    if (!args.Key.Contains(c_AirQuality)) return;
                    RealtimeMonitorViewModel.VM.Devices = null;
                    SetUnit();
                    action();
                });

                pageControl();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        /// <summary>
        /// mvvm action
        /// </summary>
        /// <param name="json"></param>
        protected override void doAction(string json = "")
        {
            gcAirQuality.DataSource = null;
            base.doAction();
        }
        /// <summary>
        /// 导出 数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbDerive_Click(object sender, EventArgs e)
        {
            if (ResultDataViewModel.VM.AirQualityEntities == null || ResultDataViewModel.VM.AirQualityEntities.Count == 0)
            {
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.SelectNone));
                return;
            }
            SaveToExcel();
        }
        private void SaveToExcel()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Excel文件|*.xls;";
            fileDialog.FileName = "WYExhaust_AQ_" + DateTime.Now.ToString("yyMMddHHmm");
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ResultDataViewModel.VM.Execute(new List<object>
                {
                    ResultDataViewModel.ExecuteCommand.ec_QueryAirQualityDrive,
                    dtpBegin.Value.ToString(),
                    dtpEnd.Value.ToString (),
                });
                gcAirQuality.DataSource = ResultDataViewModel.VM.AirQualityDriveEntities;
                gcAirQuality.ExportToXls(fileDialog.FileName);
                gcAirQuality.DataSource = ResultDataViewModel.VM.AirQualityEntities;
                string log = Program.infoResource.GetLocalizedString(language.InfoId.DriveData)+ fileDialog.FileName;
                ErrorLog.SystemLog(DateTime.Now,log, this.OwnerForm.GetUserName());
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess), "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void sbQuary_Click(object sender, EventArgs e)
        {
            if (dtpBegin.Value > dtpEnd.Value)
            {
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.BeginEndTime), "", MessageBoxButtons.OK);
                return;
            }
            ResultDataViewModel.VM.Execute(new List<object> {
                            ResultDataViewModel.ExecuteCommand.ec_QueryAirQualityPageCount,
                            dtpBegin.Text,
                            dtpEnd.Text,
                            cbePageRecord.SelectedItem
                        });
            ResultDataViewModel.VM.Execute(new List<object> {
                    ResultDataViewModel.ExecuteCommand.ec_QueryAirQuality,
                    dtpBegin.Text,
                    dtpEnd.Text,
                    1,
                    cbePageRecord.SelectedItem
            });
            if (ResultDataViewModel.VM.AirQualityEntities == null || ResultDataViewModel.VM.AirQualityEntities.Count == 0)
            {
                currentPage = 0;
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.SelectNull));
            }
            else
                currentPage = 1;
            tslCurrentPage.Text = currentPage.ToString();
            pageControl();
        }
        #region 分页查询
        //增删改查后刷新界面
        private void RefreshUI()
        {
            
            ResultDataViewModel.VM.Execute(new List<object> {
                            ResultDataViewModel.ExecuteCommand.ec_QueryAirQualityPageCount,
                            dtpBegin.Value.ToString(),
                            dtpEnd.Value.ToString(),
                            cbePageRecord.SelectedItem
                        });
            currentPage = currentPage > ResultDataViewModel.VM.AirQualityTotalPage ? ResultDataViewModel.VM.AirQualityTotalPage : currentPage;
            ResultDataViewModel.VM.Execute(new List<object> {
                            ResultDataViewModel.ExecuteCommand.ec_QueryAirQuality,
                            dtpBegin.Value.ToString(),
                            dtpEnd.Value.ToString(),
                            currentPage.ToString(),
                            cbePageRecord.SelectedItem
                        });
            pageControl();
        }

        private void QueryAirQualityPage(int currentPage)
        {
            List<object> list = new List<object>
                {
                    ResultDataViewModel.ExecuteCommand.ec_QueryAirQualityPageCount,
                    dtpBegin.Text,
                    dtpEnd.Text,
                    cbePageRecord.SelectedItem
                };
            ResultDataViewModel.VM.Execute(list);
            currentPage = currentPage > ResultDataViewModel.VM.AirQualityTotalPage ? ResultDataViewModel.VM.AirQualityTotalPage : currentPage;
            ResultDataViewModel.VM.Execute(new List<object> {
                            ResultDataViewModel.ExecuteCommand.ec_QueryAirQuality,
                            dtpBegin.Text,
                            dtpEnd.Text,
                            currentPage,
                            cbePageRecord.SelectedItem
                        });
            pageControl();
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

        }


        private void tsbFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            tslCurrentPage.Text = currentPage.ToString();
            QueryAirQualityPage(currentPage);
        }

        private void tsbLastPage_Click(object sender, EventArgs e)
        {
            if (tsbNextPage.Enabled == false) tsbNextPage.Enabled = true;
            currentPage = Convert.ToInt16(tslCurrentPage.Text) - 1;
            tslCurrentPage.Text = currentPage.ToString();
            QueryAirQualityPage(currentPage);
        }

        private void tsbNextPage_Click(object sender, EventArgs e)
        {
            if (tsbLastPage.Enabled == false) tsbLastPage.Enabled = true;
            currentPage = Convert.ToInt16(tslCurrentPage.Text) + 1;
            tslCurrentPage.Text = currentPage.ToString();
            QueryAirQualityPage(currentPage);
        }

        private void tsbEndPage_Click(object sender, EventArgs e)
        {
            currentPage = ResultDataViewModel.VM.AirQualityTotalPage;
            tslCurrentPage.Text = currentPage.ToString();
            if (Convert.ToInt16(tslCurrentPage.Text) > 1)
                QueryAirQualityPage(currentPage);
        }

        private void tsbGotoPage_Click_1(object sender, EventArgs e)
        {
            if (numGoPage.Text == "") XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.InputNotNull));
            int Page = (int)numGoPage.Value;
            if (Page == 0 || Page > ResultDataViewModel.VM.AirQualityTotalPage || Page < 0)
            {
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.PageNotExist));
                return;
            }
            currentPage = Page;
            tslCurrentPage.Text = currentPage.ToString();
            QueryAirQualityPage(currentPage);
        }
        #endregion

        private void cbePageRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            sbQuary.Focus();
            RefreshUI();
        }
        //单位换算
        private void gvAirQuality_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                switch (e.Column.FieldName)
                {
                    case "PM10":
                        e.DisplayText= Utils.UnitConvert(Convert.ToSingle(e.Value.ToString()), Utils.UnitTypes.ugm3, Unit.PM10, 1).ToString("f2");
                        break;
                    case "PM2Point5":
                        e.DisplayText = Utils.UnitConvert(Convert.ToSingle(e.Value.ToString()), Utils.UnitTypes.ugm3, Unit.PM25, 1).ToString("f2");
                        break;
                    case "COAir":
                        e.DisplayText = Utils.UnitConvert(Convert.ToSingle(e.Value.ToString()), Utils.UnitTypes.mgm3, Unit.CO, 28).ToString("f2");
                        break;
                    case "SO2":
                        e.DisplayText = Utils.UnitConvert(Convert.ToSingle(e.Value.ToString()), Utils.UnitTypes.ugm3, Unit.SO2, 64).ToString("f2");
                        break;
                    case "NO2":
                        e.DisplayText = Utils.UnitConvert(Convert.ToSingle(e.Value.ToString()), Utils.UnitTypes.ugm3, Unit.NO2, 46).ToString("f2");
                        break;
                    case "O3":
                        e.DisplayText = Utils.UnitConvert(Convert.ToSingle(e.Value.ToString()), Utils.UnitTypes.ugm3, Unit.O3, 48).ToString("f2");
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
        }
        public class AirUnit
        {
            public string PM25 = "ug/m3";
            public string PM10 = "ug/m3";
            public string CO="mg/m3";
            public string SO2 ="ug/m3";
            public string NO2 = "ug/m3";
            public string O3 = "ug/m3";
        }
        private void SetUnit()
        {
            Unit.PM10 = RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality,"PM10");
            Unit.PM25 = RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, "PM25");
            Unit.CO = RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, "CO");
            Unit.SO2 = RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, "SO2");
            Unit.NO2 = RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, "NO2");
            Unit.O3 = RealtimeMonitorViewModel.VM.getDeviceParam(c_AirQuality, "O3");
        }
    }
}
