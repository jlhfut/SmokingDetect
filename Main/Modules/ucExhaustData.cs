﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.Forms;
using wayeal.os.exhaust.ViewModel;
using DevExpress.Utils.MVVM;
using DevExpress.XtraRichEdit.Utils;
using System.Collections;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Newtonsoft.Json.Linq;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Reflection;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using System.IO;
using System.Threading;
using static wayeal.os.exhaust.ClassEnum;
using System.Diagnostics;
using DevExpress.XtraReports.UI;
//using Wayeal.Services.Configs;

namespace wayeal.os.exhaust.Modules
{
    public partial class ucExhaustData :ucManagerBase
    {
        #region enum
        
        #endregion
        public static int SelectedIndex=0;
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        int currentPage = 1;
        bool IsQueryOver = true;
        bool IsSortStart = false;
        bool IsSkipParse = false;
        /// <summary>
        /// 排序因子 0：时间  1：NO  2:HC  3:CO 4:CO2 5:OpSmoke 6：Blackness 7:Speed 8:Accelerate 9:VSP
        /// </summary>
        int _sortFactor = 0;
        /// <summary>
        /// 排序顺序 0：不排序 1：正序（递增） 2：倒序（递减）
        /// </summary>
        int _sortOrder = 2;
        int curFactor = 0;
        int curOrder = 2;
        SuperToolTip _stTipPicture = new SuperToolTip();
        Dictionary<EditorButton, ButtonEdit> textClear = new Dictionary<EditorButton, ButtonEdit>();
        private OverlayWindowOptions options = new OverlayWindowOptions();
        wfDetialMessage frmDetialMessage = null;
        wfDataAnalysis frmDataAnalysis = null;
        wfDataAnalysisVertical frmDataAnalysisVertical = null;
        ComboBoxEdit cbeVehicleType = new ComboBoxEdit();
        SimpleButton sbOneButtonPrint = new DevExpress.XtraEditors.SimpleButton();
        public ucExhaustData()
        {
            InitializeComponent();
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            dtpBegin.Value = dt;//.AddMonths(-1);
            DateTime dt2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            dtpEnd.Value = dt2;
            InitComboBox();
            InitSuperToolTip();
            InitOptions();
            InitCbeVehicleType();
            InitOneButtonPrint();
            InitializeUI();
            
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        [Conditional("VerticalDistribution")]
        private void InitCbeVehicleType()
        {
            // label style
            LabelControl lcVehicleType = new LabelControl();
            pcQueryCondition.Controls.Add(lcVehicleType);
            lcVehicleType.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            lcVehicleType.Appearance.ForeColor = System.Drawing.Color.FromArgb(33,33,33);
            lcVehicleType.Appearance.Options.UseFont = true;
            lcVehicleType.Appearance.Options.UseForeColor = true;
            lcVehicleType.Appearance.Options.UseTextOptions = true;
            lcVehicleType.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            lcVehicleType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            Point p = cbeFuelType.Location;
            p.X += 138;
            lcVehicleType.Location = p;
            lcVehicleType.Size = new System.Drawing.Size(70, 16);
            lcVehicleType.TabIndex = 48;
            lcVehicleType.Text = "车辆类型";
            //style
            pcQueryCondition.Controls.Add(cbeVehicleType);
            Point cbeP = lcVehicleType.Location;
            cbeP.X += lcVehicleType.Size.Width + 5;
            cbeVehicleType.Location = cbeP;
            cbeVehicleType.Properties.AllowFocused = false;
            cbeVehicleType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            cbeVehicleType.Properties.Appearance.Options.UseFont = true;
            cbeVehicleType.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            cbeVehicleType.Properties.Buttons[0].Appearance.BackColor = Color.White;
            cbeVehicleType.Properties.Buttons[0].Appearance.BorderColor = Color.White;
            cbeVehicleType.Properties.Buttons[0].AppearanceHovered.BackColor = Color.White;
            cbeVehicleType.Properties.Buttons[0].AppearanceHovered.BorderColor = Color.White;
            cbeVehicleType.Properties.Buttons[0].AppearanceDisabled.BackColor = Color.White;
            cbeVehicleType.Properties.Buttons[0].AppearanceDisabled.BorderColor = Color.White;
            cbeVehicleType.Properties.Buttons[0].AppearancePressed.BackColor = Color.White;
            cbeVehicleType.Properties.Buttons[0].AppearancePressed.BorderColor = Color.White;
            cbeVehicleType.Properties.AllowFocused = false;
            cbeVehicleType.Properties.ItemPadding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            cbeVehicleType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cbeVehicleType.Size = new System.Drawing.Size(136, 22);
            //items
            cbeVehicleType.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.All));
            cbeVehicleType.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.VTR_RESULT_CLASSIFY_OTHER));
            cbeVehicleType.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.VTR_RESULT_CLASSIFY_COACH));
            cbeVehicleType.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.VTR_RESULT_CLASSIFY_CAR));
            cbeVehicleType.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.VTR_RESULT_CLASSIFY_VAN));
            cbeVehicleType.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.VTR_RESULT_CLASSIFY_NONMOTOR));
            cbeVehicleType.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.VTR_RESULT_CLASSIFY_MINIBUS));
            cbeVehicleType.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.VTR_RESULT_CLASSIFY_TRUCK));
        }
        [Conditional("VerticalDistribution")]
        private void InitOneButtonPrint()
        {
            sbOneButtonPrint.Appearance.BackColor = System.Drawing.Color.Transparent;
            sbOneButtonPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            sbOneButtonPrint.Appearance.ForeColor = System.Drawing.Color.White;
            sbOneButtonPrint.Appearance.Image = global::wayeal.os.exhaust.Properties.Resources.创建报告;
            sbOneButtonPrint.Appearance.Options.UseBackColor = true;
            sbOneButtonPrint.Appearance.Options.UseFont = true;
            sbOneButtonPrint.Appearance.Options.UseForeColor = true;
            sbOneButtonPrint.Appearance.Options.UseImage = true;
            sbOneButtonPrint.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(77, 121, 183);
            sbOneButtonPrint.AppearanceHovered.Options.UseBackColor = true;
            sbOneButtonPrint.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            sbOneButtonPrint.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            sbOneButtonPrint.AppearancePressed.Image = global::wayeal.os.exhaust.Properties.Resources.创建报告按下;
            sbOneButtonPrint.AppearancePressed.Options.UseBackColor = true;
            sbOneButtonPrint.AppearancePressed.Options.UseFont = true;
            sbOneButtonPrint.AppearancePressed.Options.UseImage = true;
            sbOneButtonPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            Point point = sbCreateReport.Location;
            point.X += 132;
            sbOneButtonPrint.Location = point;
            sbOneButtonPrint.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            sbOneButtonPrint.Size = new System.Drawing.Size(124, 28);
            sbOneButtonPrint.TabIndex = 50;
            sbOneButtonPrint.Text = "一键打印";
            sbOneButtonPrint.Click += new System.EventHandler(this.sbOneButtonPrint_Click);
            pcQuary.Controls.Add(sbOneButtonPrint);
        }

        private void InitOptions()
        {
            options.BackColor = Color.FromArgb(216,216,216);
            options.Opacity = 0.5;
            options.ForeColor = Color.Transparent;
        }

        //private static ucExhaustData _uc = null;
        //public static ucExhaustData uc {get{
        //        if (_uc == null) _uc = new ucExhaustData();
        //        return _uc; } }

        

        /// <summary>
        /// 初始化下拉菜单
        /// </summary>
        private void InitComboBox()
        {
            cbeDetectionResult.Properties.Items.Clear();
            cbeDetectionResult.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.All));
            cbeDetectionResult.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.Disqualified));
            cbeDetectionResult.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.Qualified));
            cbeDetectionResult.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.Invalid));
            cbeDetectionResult.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.valid));
            cbeDetectionResult.SelectedIndex = 0;
            cbePageRecord.SelectedIndex = 0;
            cbePageRecord.SelectedIndexChanged += new System.EventHandler(this.cbePageRecord_SelectedIndexChanged);
            cbeDetectionResult.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            enableControl(false);
            cbeFactor.Properties.Items.Insert(0,Program.infoResource.GetLocalizedString(language.InfoId.All));
            cbeFactor.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.Ringelman));
            cbeFactor.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.Opsmoke));
            cbeFactor.Enabled = false;

            //  gcExhaustData.UseEmbeddedNavigator = true;
            pcQueryCondition.Height = 0;
            cbeLane.SelectedIndex = 0;
            cbeFuelType.SelectedIndex = 0;
            Query(1);
            pageControl();
        }
        /// <summary>
        /// 初始化提示框
        /// </summary>
        private void InitSuperToolTip()
        {
            ToolTipItem item = new ToolTipItem();
            item.Text = Program.infoResource.GetLocalizedString(language.InfoId.NoPicture);
            _stTipPicture.Items.Add(item);
            _stTipPicture.Padding = new Padding(5);
            _stTipPicture.MaxWidth = 430;
            _stTipPicture.FixedTooltipWidth = false;
            ribePicture.Buttons[0].SuperTip = _stTipPicture;
        }
      
        /// <summary>
        /// Init
        /// </summary>
        protected override void InitializeBindings()
        {
            try
            {
                mvvmContext1.SetViewModel(typeof(ResultDataViewModel), ResultDataViewModel.VM);
                fluent = mvvmContext1.OfType<ResultDataViewModel>();
                AddBinding(fluent.SetBinding(gcExhaustData, gControl => gControl.DataSource, x => x.ExhuastEntities, m => {
                    if (IsSkipParse)
                    {
                        return m;
                    }
                    JToken token;
                    ArrayList al = new ArrayList();
                    for (int i = 0; i < m.Count; i++)
                    {
                        JObject ri = Newtonsoft.Json.Linq.JObject.Parse(m[i].ToString());
                        ExhaustData obj = new ExhaustData();
                        PropertyInfo[] pinf = obj.GetType().GetProperties();
                        foreach (PropertyInfo pi in pinf)
                        {
                            try
                            {
                                if ((ri as JObject).TryGetValue(pi.Name, out token) && pi.CanWrite)
                                    pi.SetValue(obj, token.ToObject(pi.PropertyType));
                            }
                            catch { }
                        }
                        obj.Serial = i + 1;
                        al.Add(obj);
                    }
                    return al;
                }));

                AddBinding(fluent.SetBinding(tslTotalPage, page => page.Text, x => x.ExhuastTotalPage, m =>
                {
                    if (m > 0) tslCurrentPage.Text = currentPage.ToString();
                    if (Convert.ToInt32(tslCurrentPage.Text) > m) tslCurrentPage.Text = m.ToString();
                    return m.ToString();
                }));
                AddBinding(fluent.SetBinding(tslCount, count => count.Text, x => x.ExhuastTotalCount, m =>{ return m.ToString();}));



                ResultDataViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == "ExhaustHistoryData") action();
                };

                base.InitializeBindings();

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
            gcExhaustData.DataSource = null;
            base.doAction();
        }
        /// <summary>
        /// 创建报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbCreateReport_Click(object sender, EventArgs e)
        {
            DialogResult rs=XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.CreateReport) +gridView1.DataRowCount
                +"?" , Program.infoResource.GetLocalizedString(language.InfoId.Report ), MessageBoxButtons.OKCancel);
            if (rs == DialogResult.OK)
            {
                wfPrint wf = new wfPrint(ResultDataViewModel.VM.ExhuastEntities,this.OwnerForm.GetUserName());
                wf.WindowState = FormWindowState.Maximized;
           //     wf.TopMost = true;
                wf.Show();
            }
        }
      
        private void ribe_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            IOverlaySplashScreenHandle handle = SplashScreenManager.ShowOverlayForm(this.OwnerForm, options);
            try
            {
                //获取所在行的序号
                int index = gridView1.FocusedRowHandle;
                string uniqueKey = gridView1.GetRowCellValue(index, gcTestingNumber).ToString();
               
                if (e.Button.Index == 0)
                {
                    //详情
                    if (frmDetialMessage == null)
                    {
                        frmDetialMessage = new wfDetialMessage(index, 0,this);
                    }
                    else
                    {
                        frmDetialMessage.ShowUC(index);
                    }
                    frmDetialMessage.ShowDialog();
                    handle.Close();
                    gridView1.UpdateCurrentRow();
                    sbQuary.Focus();
                }
                else if (e.Button.Index == 1)
                {
#if VerticalDistribution
                    if (frmDataAnalysisVertical == null)
                    {
                        frmDataAnalysisVertical = new wfDataAnalysisVertical(index,this);
                    }
                    else
                    {
                        frmDataAnalysisVertical.InitUI(index,this);
                    }
                    frmDataAnalysisVertical.ShowDialog();
#else

                    //数据分析
                    if (frmDataAnalysis == null)
                    {
                        frmDataAnalysis = new wfDataAnalysis(index,this);
                    }
                    else
                    {
                        frmDataAnalysis.RefreshChartInfo(index);
                    }
                    frmDataAnalysis.ShowDialog();
#endif
                    handle.Close();
                    sbQuary.Focus();
                }
            }
            catch (Exception ex)
            {
                if (handle != null) handle.Close();
                ErrorLog.Error(ex.ToString());
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Result")
                {
                    if (e.Value == null || e.Value.ToString() == "") return;
                    if (e.Value.ToString().Equals("0"))
                    {
                        //合格
                        e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Disqualified);
                    }
                    else if (e.Value.ToString().Equals("1"))
                    {
                        //不合格
                        e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Qualified);
                    }
                    else if (e.Value.ToString().Equals("2"))
                    {
                        //无效
                        e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Invalid);
                    }
                }
                else if (e.Column.FieldName == "CarNumberColor")
                {
                    if (e.Value == null || e.Value.ToString() == "") return;
                    if (e.Value.ToString() == "-1")
                    {
                        e.DisplayText = "";
                        return;
                    }
                    enumCarNumberColor rs;
                    Enum.TryParse<enumCarNumberColor>(e.Value.ToString(), out rs);
                    switch (rs)
                    {
                        case enumCarNumberColor.Color_Blue:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Blue);
                            break;
                        case enumCarNumberColor.Color_Yellow:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Yellow);
                            break;
                        case enumCarNumberColor.Color_White:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.White);
                            break;
                        case enumCarNumberColor.Color_Black:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Black);
                            break;
                        case enumCarNumberColor.Color_Green:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Green);
                            break;
                        case enumCarNumberColor.Color_Blackness:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Blackness);
                            break;
                        default:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.OtherColor);
                            break;
                    }
                }
                else if (e.Column.FieldName == "CarColor")
                {
                    if (e.Value == null || e.Value.ToString() == "") return;
                    if (e.Value.ToString() == "-1")
                    {
                        e.DisplayText = "";
                        return;
                    }
                    enumBodyColor rs;
                    Enum.TryParse<enumBodyColor>(e.Value.ToString().Trim(), out rs);
                    switch (rs)
                    {
                        case enumBodyColor.Color_Other:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.OtherColor);
                            break;
                        case enumBodyColor.Color_White:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.White);
                            break;
                        case enumBodyColor.Color_Silvery:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Silvery);
                            break;
                        case enumBodyColor.Color_Gray:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Gray);
                            break;
                        case enumBodyColor.Color_Black:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Black);
                            break;
                        case enumBodyColor.Color_Red:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Red);
                            break;
                        case enumBodyColor.Color_Darkblue:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.DarkBlue);
                            break;
                        case enumBodyColor.Color_Blue:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Blue);
                            break;
                        case enumBodyColor.Color_Yellow:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Yellow);
                            break;
                        case enumBodyColor.Color_Green:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Green);
                            break;
                        case enumBodyColor.Color_Brown:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Brown);
                            break;
                        case enumBodyColor.Color_Pink:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Pink);
                            break;
                        case enumBodyColor.Color_Violet:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Violet);
                            break;
                        case enumBodyColor.Color_Darkgrey:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.DarkGrey);
                            break;
                        case enumBodyColor.Color_Cyan:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.Cyan);
                            break;
                        default:
                            e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.UnfindColor);
                            break;
                    }
                }
                else if (e.Column.FieldName == "Blackness")
                {
                    if (e.Value == null || e.Value.ToString() == "") return;
                    switch (e.Value.ToString())
                    {
                        case "0":
                            e.DisplayText = "0";
                            break;
                        case "1":
                            e.DisplayText = "Ⅰ";
                            break;
                        case "2":
                            e.DisplayText = "Ⅱ";
                            break;
                        case "3":
                            e.DisplayText = "Ⅲ";
                            break;
                        case "4":
                            e.DisplayText = "Ⅳ";
                            break;
                        case "5":
                            e.DisplayText = "Ⅴ";
                            break;
                        case "6":
                            e.DisplayText = "Ⅵ";
                            break;
                    }
                }
                else if (e.Column.FieldName == "NO" || e.Column.FieldName == "CO" || e.Column.FieldName == "HC" || e.Column.FieldName == "CO2" || e.Column.FieldName == "OpSmoke"
                    || e.Column == gcTemperature || e.Column == gcVSP || e.Column == gcWindSpeed || e.Column == gcHumidity || e.Column == gcPressure || e.Column == gcAcceleration || e.Column == gcWindDirection)
                {
                    try
                    {
                        if (e.Value == null || e.Value.ToString() == "") return;
                        e.DisplayText = (Convert.ToDouble(e.Value.ToString())).ToString("f2");
                    }
                    catch { }
                }
                else if (e.Column.FieldName == "Speed")
                {
                    try
                    {
                        if (e.Value == null || e.Value.ToString() == "") return;
                        e.DisplayText = ((Convert.ToDouble(e.Value.ToString())) * 3.6).ToString("f2");
                    }
                    catch { }
                }
                else if (e.Column == gcCarType)
                {
                    try
                    {
                        if (e.Value == null || e.Value.ToString() == "") return;
                        switch (e.Value.ToString().Trim())
                        {
                            case "A": e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.GasolineCar); break;
                            case "B": e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.DieselCar); break;
                            case "Z": e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.OtherFuelCar); break;
                            default: break;
                        }
                    }
                    catch { }
                }
                else if (e.Column == gcLatitude || e.Column == gcLongitude)
                {
                    e.DisplayText = Convert.ToSingle(e.Value).ToString("f5");
                }
                else if (e.Column == gcNumber)
                {
                    e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
                }
                else if (e.Column == gcVehicleType)
                {
                    if (e.Value == null || e.Value.ToString() == "")
                    {
                        e.DisplayText = "";
                        return;
                    }
                    int index = Convert.ToInt32(e.Value);
                    //int classifyIndex = -1;
                    //dicVehicleTypeClassify.TryGetValue(index, out classifyIndex);
                    //if (classifyIndex==-1)
                    //{
                    //    e.DisplayText = Program.infoResource.GetLocalizedString(language.InfoId.VTR_RESULT_OTHER);
                    //    return;
                    //}
                    language.InfoId infoId = language.InfoId.VTR_RESULT_OTHER;
                    infoId += index - 1;
                    e.DisplayText = Program.infoResource.GetLocalizedString(infoId);
                    ClassifyDisText(e, index);
                }
                else if (e.Column == gcTrackNumber)
                {
                    if (e.Value == null || e.Value.ToString() == ""||e.Value.ToString()=="0") e.DisplayText ="";
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
        }
        [Conditional("VerticalDistribution")]
        private void ClassifyDisText(DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e,int index)
        {
            language.InfoId infoId = language.InfoId.VTR_RESULT_CLASSIFY_OTHER;
            int outIndex =Utils.ClassifyVehicleType(index);
            e.DisplayText = Program.infoResource.GetLocalizedString(infoId + outIndex-1);
        }

        #region DeriveDataToExcel
        private void sbDerive_Click(object sender, EventArgs e)
        {
            DialogResult result= XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.DrivePDF), "",MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                SaveToPDF();
            }
            else if (result == DialogResult.No)
            {
                SaveToExcel();
            }
        }
        /// <summary>
        /// 导出pdf格式
        /// </summary>
        private void SaveToPDF()
        {
            if (ResultDataViewModel.VM.ExhuastEntities == null || ResultDataViewModel.VM.ExhuastEntities.Count == 0)
            {
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.SelectNone));
                return;
            }
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "PDF文件|*.pdf;";
            fileDialog.FileName = "WYExhaust_EH_" + DateTime.Now.ToString("yyMMddHHmmss");
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                IsSkipParse = true;
                Query(-1);
                gcOperation.Visible = false;

                foreach (GridColumn gc in gridView1.Columns)
                {
                    gc.AppearanceCell.Font = new Font("宋体", 8);
                }
                gcExhaustData.ExportToPdf(fileDialog.FileName);
                IsSkipParse = false;
                Query(currentPage);
                gcExhaustData.DataSource = ResultDataViewModel.VM.ExhuastEntities;
                gcOperation.Visible = true;
                foreach (GridColumn gc in gridView1.Columns)
                {
                    gc.AppearanceCell.Font = new Font("Tahoma", 9);
                }

                base.doAction();
                string log = Program.infoResource.GetLocalizedString(language.InfoId.DriveData) + fileDialog.FileName;
                ErrorLog.SystemLog(DateTime.Now, log, this.OwnerForm.GetUserName());
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess), "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>
        ///  用excel格式导出信息
        /// </summary>
        private void SaveToExcel()
        {
            if (ResultDataViewModel.VM.ExhuastEntities == null || ResultDataViewModel.VM.ExhuastEntities.Count == 0)
            {
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.SelectNone));
                return;
            }
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Excel文件|*.xls;";
            fileDialog.FileName = "WYExhaust_EH_" + DateTime.Now.ToString("yyMMddHHmmss");
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                XlsExportOptions options = new XlsExportOptions();
                options.TextExportMode = TextExportMode.Text;
                IsSkipParse = true;
                Query(-1);
                gcOperation.Visible = false;
                gcExhaustData.ExportToXls(fileDialog.FileName, options);
                IsSkipParse = false;
                Query(currentPage);
                gcExhaustData.DataSource = ResultDataViewModel.VM.ExhuastEntities;
                gcOperation.Visible = true;
                base.doAction();
                string log = Program.infoResource.GetLocalizedString(language.InfoId.DriveData) + fileDialog.FileName;
                ErrorLog.SystemLog(DateTime.Now, log, this.OwnerForm.GetUserName());
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess), "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
       
#endregion
#region TextClear
        private void beUserName_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Clear")
            {
                ButtonEdit be = new ButtonEdit();
                textClear.TryGetValue(e.Button, out be);
                be.Text = "";
            }
        }
        private void beUserName_EditValueChanged(object sender, EventArgs e)
        {
            if (!(sender is ButtonEdit)) return;
            ButtonEdit be = sender as ButtonEdit;
            be.Properties.Buttons[0].Visible = be.Text != "";
            be.Properties.Buttons[0].Enabled = be.Text != "";
        }

        private void ucExhaustData_Load(object sender, EventArgs e)
        {
            //加载所有键值对
            textClear.Clear();
            textClear.Add(beLicense.Properties.Buttons[0],beLicense);
            textClear.Add(beNOBegin.Properties.Buttons[0], beNOBegin);
            textClear.Add(beNOEnd.Properties.Buttons[0], beNOEnd);
            textClear.Add(beHCBegin.Properties.Buttons[0], beHCBegin);
            textClear.Add(beHCEnd.Properties.Buttons[0], beHCEnd);
            textClear.Add(beCOBegin.Properties.Buttons[0], beCOBegin);
            textClear.Add(beCOEnd.Properties.Buttons[0], beCOEnd);
            textClear.Add(beOpSmokeBegin.Properties.Buttons[0], beOpSmokeBegin);
            textClear.Add(beOpSmokeEnd.Properties.Buttons[0], beOpSmokeEnd);
            foreach (KeyValuePair<EditorButton, ButtonEdit> pair in textClear)
            {
                pair.Key.Visible = false;
                pair.Key.Enabled = false;
            }
        }
#endregion
#region 分页查询
        //增删改查后刷新界面
        private void RefreshUI()
        {
            Query(currentPage);
            pageControl();
            if (ResultDataViewModel.VM.ExhuastEntities == null || ResultDataViewModel.VM.ExhuastEntities.Count == 0)
            {
                gcExhaustData.DataSource = null;
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.SelectNull));
            }
        }

        private void QueryExhaustPage(int currentPage)
        {
            List<object> list = new List<object>
                {
                    //ResultDataViewModel.ExecuteCommand.ec_QueryExhaustPage,
                    //currentPage,
                    //cbePageRecord.SelectedItem
                     ResultDataViewModel.ExecuteCommand.ec_QueryExhuast,
                    dtpBegin.Value,
                    dtpEnd.Value,
                    beLicense.Text,
                    cbeDetectionResult.SelectedIndex==0? "":(cbeDetectionResult.SelectedIndex-1).ToString(),
                    cbeFactor.Enabled?ConvertToABCD(cbeFactor.SelectedIndex):"",
                    beNOBegin.Text,
                    beNOEnd.Text,
                    beCOBegin.Text,
                    beCOEnd.Text,
                    beHCBegin.Text,
                    beHCEnd.Text,
                    beOpSmokeBegin.Text,
                    beOpSmokeEnd.Text,
                    cbeBlacknessBegin.SelectedIndex==-1?"":(cbeBlacknessBegin.SelectedIndex).ToString(),
                    cbeBlacknessEnd.SelectedIndex==-1?"":(cbeBlacknessEnd.SelectedIndex).ToString(),
                    _sortFactor,
                    _sortOrder,
                    cbePageRecord.SelectedItem.ToString(),
                    currentPage,
                    cbeLane.SelectedIndex,
                    cbeFuelType.SelectedIndex,
                    cbeVehicleType.SelectedIndex,
                };
            ResultDataViewModel.VM.Execute(list);
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
            currentPage = 1;
            tslCurrentPage.Text = currentPage.ToString();
            QueryExhaustPage(currentPage);
        }

        private void tsbLastPage_Click(object sender, EventArgs e)
        {
            if (tsbNextPage.Enabled == false) tsbNextPage.Enabled = true;
            currentPage = Convert.ToInt16(tslCurrentPage.Text) - 1;
            tslCurrentPage.Text = currentPage.ToString();
            QueryExhaustPage(currentPage);
        }

        private void tsbNextPage_Click(object sender, EventArgs e)
        {
            if (tsbLastPage.Enabled == false) tsbLastPage.Enabled = true;
            currentPage = Convert.ToInt16(tslCurrentPage.Text) + 1;
            tslCurrentPage.Text = currentPage.ToString();
            QueryExhaustPage(currentPage);
        }

        private void tsbEndPage_Click(object sender, EventArgs e)
        {
            currentPage = ResultDataViewModel.VM.ExhuastTotalPage;
            tslCurrentPage.Text = currentPage.ToString();
            if (Convert.ToInt16(tslCurrentPage.Text) > 1)
                QueryExhaustPage(currentPage);
        }

        private void tsbGotoPage_Click_1(object sender, EventArgs e)
        {
            if (numGoPage.Text == "") XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.InputNotNull));
            int Page = (int)numGoPage.Value;
            if (Page == 0 || Page > ResultDataViewModel.VM.ExhuastTotalPage || Page < 0)
            {
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.PageNotExist));
                return;
            }
            currentPage = Page;
            tslCurrentPage.Text = currentPage.ToString();
            QueryExhaustPage(currentPage);
        }
#endregion
        private void sbQuary_Click(object sender, EventArgs e)
        {
            Query(1);
            pageControl();
            
            if (ResultDataViewModel.VM.ExhuastEntities == null || ResultDataViewModel.VM.ExhuastEntities.Count == 0)
            {
                gcExhaustData.DataSource = null;
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.SelectNull));
            }
        }
       /// <summary>
       /// 查询
       /// </summary>
       /// <param name="pageNumber">0：查询第一页。n：查询第n页。-1：查询所有</param>
        private void Query(int pageNumber=0)
        {
            if (!IsQueryOver) return;
            IsQueryOver = false;
            try
            {
                if (dtpBegin.Value > dtpEnd.Value)
                {

                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.BeginEndTime), "", MessageBoxButtons.OK);
                    IsQueryOver = true;
                    return;
                }
                try
                {
                    SplashScreenManager.ShowForm(this.OwnerForm, typeof(Forms.wfMain), false, true);
                }
                catch
                { }
                ResultDataViewModel.VM.Execute(new List<object> {
                    ResultDataViewModel.ExecuteCommand.ec_QueryExhuast,
                    dtpBegin.Value,
                    dtpEnd.Value,
                    beLicense.Text,
                    cbeDetectionResult.SelectedIndex==0? "":(cbeDetectionResult.SelectedIndex-1).ToString(),
                    cbeFactor.Enabled?ConvertToABCD(cbeFactor.SelectedIndex):"",
                    beNOBegin.Text,
                    beNOEnd.Text,
                    beCOBegin.Text,
                    beCOEnd.Text,
                    beHCBegin.Text,
                    beHCEnd.Text,
                    beOpSmokeBegin.Text,
                    beOpSmokeEnd.Text,
                    cbeBlacknessBegin.SelectedIndex==-1?"":(cbeBlacknessBegin.SelectedIndex).ToString(),
                    cbeBlacknessEnd.SelectedIndex==-1?"":(cbeBlacknessEnd.SelectedIndex).ToString(),
                    _sortFactor,
                    _sortOrder,
                    cbePageRecord.SelectedItem.ToString(),
                    pageNumber==0?  currentPage.ToString() : pageNumber.ToString(),
                    cbeLane.SelectedIndex,
                    cbeFuelType.SelectedIndex,
                    cbeVehicleType.SelectedIndex
            });
                currentPage = pageNumber <= 0 ? 1 : pageNumber;
                if (ResultDataViewModel.VM.ExhuastEntities == null || ResultDataViewModel.VM.ExhuastEntities.Count == 0) currentPage = 0;
                tslCurrentPage.Text = currentPage.ToString();
                SplashScreenManager.CloseForm();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
            IsQueryOver = true;
        }

        private void cbePageRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            sbQuary.Focus();
            RefreshUI();
        }

        private void cbeDetectionResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbeDetectionResult.SelectedItem.ToString() == Program.infoResource.GetLocalizedString(language.InfoId.Disqualified))
            {
                cbeFactor.Enabled = true;
                cbeFactor.SelectedIndex = 0;
            }
            else
            {
                cbeFactor.Enabled = false;
            }
        }
        private string ConvertToABCD(int i)
        {
            if (i == 0) return "";
            char c= (char)(i + 64);
            string s = c.ToString();
            return s;
        }
        
        private void gridView1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                GridHitInfo info;
                Point p = gridView1.GridControl.PointToClient(Control.MousePosition);
                info = gridView1.CalcHitInfo(p);
                //在表头则返回
                if (info.InColumn) return;
                //只在车牌列生效
                if (info.Column != gcLicenseNumber) return;

                //获取行号
                int index = info.RowHandle;
                //获取关键字
                string uniqueKey = gridView1.GetRowCellValue(index, gcTestingNumber).ToString();
                ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryDetialInfo, index, uniqueKey });
                if (ResultDataViewModel.VM.DetialInfoEntities == null || ResultDataViewModel.VM.DetialInfoEntities.Count < 1)
                {
                    RefreshSuperTip(false);
                    return;
                }
                object o = ResultDataViewModel.VM.DetialInfoEntities[0];
                if (o is JObject)
                {
                    JObject jo = (o as JObject);
                    JToken value;
                    jo.TryGetValue("PicNearPath", out value);
                    if (value == null||value.ToString()=="")
                    {
                        RefreshSuperTip(false);
                        return;
                    }
                    if (_stTipPicture.Items != null && _stTipPicture.Items.Count != 0)
                    {
                        Image ima = Image.FromFile(value.ToString());
                        Image ima2= ima.GetThumbnailImage(pcData.Width/4,pcData.Height/3, null, IntPtr.Zero);
                        RefreshSuperTip(true, ima2);
                        ima.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                RefreshSuperTip(false);
                ErrorLog.Error(ex.StackTrace + ex.ToString());
            }
        }
        /// <summary>
        /// 刷新supertip
        /// </summary>
        /// <param name="HasImage">是否有图片</param>
        /// <param name="ima">图片</param>
        private void RefreshSuperTip(bool  HasImage, Image ima = null)
        {
            try
            {
                if (_stTipPicture.Items == null || _stTipPicture.Items.Count == 0) return;
                if (HasImage)
                {
                    (_stTipPicture.Items[0] as ToolTipItem).Text = null;
                    (_stTipPicture.Items[0] as ToolTipItem).ImageOptions.Image = ima;
                }
                else
                {
                    (_stTipPicture.Items[0] as ToolTipItem).Text = Program.infoResource.GetLocalizedString(language.InfoId.NoPicture);
                    (_stTipPicture.Items[0] as ToolTipItem).ImageOptions.Image = null;
                }
            }
            catch(Exception ex)
            {
                ErrorLog.Error(ex.StackTrace+ ex.ToString());
            }
        }
        public string GetUniqueKeyByIndex(int index)
        {
            if (index < 0 || index > ResultDataViewModel.VM.ExhuastEntities.Count - 1) return null;
            return gridView1.GetRowCellValue(index, gcTestingNumber).ToString();
        }
        private class ExhaustData
        {
            /// <summary>
            /// 关键字
            /// </summary>
            private  string _uniqueKey;
            public string UniqueKey { get { return _uniqueKey; }set { _uniqueKey = value; } }
            /// <summary>
            /// 检测时间
            /// </summary>
            private DateTime _dt;
            public DateTime dt { get { return _dt; } set { _dt = value; } }
            /// <summary>
            /// 站点名称
            /// </summary>
            private string _station;
            public string Station { get { return _station; } set { _station = value; } }
            /// <summary>
            /// 经度
            /// </summary>
            private string _longitude;
            public string Longitude { get { return _longitude; } set { _longitude = value; } }
            /// <summary>
            /// 纬度
            /// </summary>
            private string _latitude;
            public string Latitude { get { return _latitude; } set { _latitude = value; } }
            /// <summary>
            /// 坡度
            /// </summary>
            private float _slope;
            public float Slope { get { return _slope; } set { _slope = value; } }
            /// <summary>
            /// 车道
            /// </summary>
            private int _lane;
            public int Lane { get { return _lane; } set { _lane = value; } }
            /// <summary>
            /// 车牌号
            /// </summary>
            private string _carNumber;
            public string CarNumber { get { return _carNumber; } set { _carNumber = value; } }
            /// <summary>
            /// 车牌颜色
            /// </summary>
            private int _carNumberColor=-1;
            public int CarNumberColor { get { return _carNumberColor; } set { _carNumberColor = value; } }
            /// <summary>
            /// 车身颜色
            /// </summary>
            private int _carColor=-1;
            public int CarColor { get { return _carColor; } set { _carColor = value; } }
            /// <summary>
            /// NO
            /// </summary>
            private float _NO;
            public float NO { get { return _NO; } set { _NO = value; } }
            /// <summary>
            /// CO
            /// </summary>
            private float _CO;
            public float CO { get { return _CO; } set { _CO = value; } }
            /// <summary>
            /// CO2
            /// </summary>
            private float _CO2;
            public float CO2 { get { return _CO2; } set { _CO2 = value; } }
            /// <summary>
            /// HC
            /// </summary>
            private float _HC;
            public float HC { get { return _HC; } set { _HC = value; } }
            /// <summary>
            /// 不透光度
            /// </summary>
            private float _opSmoke;
            public float OpSmoke { get { return _opSmoke; } set { _opSmoke = value; } }
            /// <summary>
            /// 林格曼黑度
            /// </summary>
            private float _blackness;
            public float Blackness { get { return _blackness; } set { _blackness = value; } }
            
            /// <summary>
            /// 结果
            /// </summary>
            private int _result=-1;
            public int Result { get { return _result; } set { _result = value; } }
            /// <summary>
            /// 风速
            /// </summary>
            private float _windSpeed;
            public float WindSpeed { get { return _windSpeed; } set { _windSpeed = value; } }
            /// <summary>
            /// 风向
            /// </summary>
            private string _windDirection;
            public string WindDirection { get { return _windDirection; } set { _windDirection = value; } }
            /// <summary>
            /// 气压
            /// </summary>
            private float _pressure;
            public float Pressure { get { return _pressure; } set { _pressure = value; } }
            /// <summary>
            /// 温度
            /// </summary>
            private float _temperature;
            public float Temperature { get { return _temperature; } set { _temperature = value; } }
            /// <summary>
            /// 湿度
            /// </summary>
            private float _humidity;
            public float Humidity { get { return _humidity; } set { _humidity = value; } }
            /// <summary>
            /// 速度
            /// </summary>
            private float _speed;
            public float Speed { get { return _speed; } set { _speed = value; } }
            /// <summary>
            /// 加速度
            /// </summary>
            private float _acceleration;
            public float Acceleration { get { return _acceleration; } set { _acceleration = value; } }
            /// <summary>
            /// VSP
            /// </summary>
            private float _VSP;
            public float VSP { get { return _VSP; } set { _VSP = value; } }

            /// <summary>
            /// 序号
            /// </summary>
            private int _serial = -1;
            public int Serial { get { return _serial; } set { _serial = value; } }

            /// <summary>
            /// 燃油类型
            /// </summary>
            private string _carType ;
            public string CarType { get { return _carType; } set { _carType = value; } }

            /// <summary>
            /// 车辆类型
            /// </summary>
            private int _vehicleType = 0;
            public int VehicleType { get { return _vehicleType; } set { _vehicleType = value; } }

        }
        

        /// <summary>
        /// 展开/收起详细查询条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pcQueryCondition.Height = pcQueryCondition.Height == 0 ? pcQuary.Height*2 : 0;
            sbPopupCondition.ImageOptions.ImageIndex = pcQueryCondition.Height == 0 ? 1 : 0;
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            try
            {
                if (e == null || e.Column == null) return;
                if (IsSortStart) { e.Result = 0; return; }
                IsSortStart = true;
                switch (e.Column.FieldName)
                {
                    case "dt": curFactor = 0; break;
                    case "NO": curFactor = 1; break;
                    case "HC": curFactor = 2; break;
                    case "CO": curFactor = 3; break;
                    case "CO2": curFactor = 4; break;
                    case "OpSmoke": curFactor = 5; break;
                    case "Blackness": curFactor = 6; break;
                    case "Speed": curFactor = 7; break;
                    case "Acceleration": curFactor = 8; break;
                    case "VSP": curFactor = 9; break;
                    default: return;
                }
                curOrder = (int)e.SortOrder;
                e.Result = 0;
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
        }

        private void gridView1_EndSorting(object sender, EventArgs e)
        {
            IsSortStart = false;
            if (curOrder != _sortOrder || curFactor != _sortFactor)
            {
                //  _sortOrder =Math.Abs(curOrder-1);
                _sortOrder = curOrder;
                _sortFactor = curFactor;
                RefreshUI();
             
            }
        }
        /// <summary>
        /// 获取对应行号的图片
        /// </summary>
        /// <param name="index"></param>
        private Image getToolTipsPicture(int index)
        {
            //获取关键字
            string uniqueKey = gridView1.GetRowCellValue(index, gcTestingNumber).ToString();
            ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryDetialInfo, index, uniqueKey });
            if (ResultDataViewModel.VM.DetialInfoEntities == null || ResultDataViewModel.VM.DetialInfoEntities.Count < 1)
            {
              //  RefreshSuperTip(false);
                return null;
            }
            object o = ResultDataViewModel.VM.DetialInfoEntities[0];
            if (o is JObject)
            {
                JObject jo = (o as JObject);
                JToken value;
                jo.TryGetValue("PicNearPath", out value);
                if (value == null || value.ToString() == "")
                {
                   // RefreshSuperTip(false);
                    return null;
                }
                if (_stTipPicture.Items != null && _stTipPicture.Items.Count != 0)
                {
                    if (!File.Exists(value.ToString()))
                    {
                      //  RefreshSuperTip(false);
                        return null;
                    }
                    Image ima = Image.FromFile(value.ToString());
                    Image ima2 = ima.GetThumbnailImage(pcData.Width / 4, pcData.Height / 3, null, IntPtr.Zero);
                    //  RefreshSuperTip(true, ima2);
                    ima.Dispose();
                    return ima2;
                }
            }
            return null;
        }
        /// <summary>
        /// 显示车牌小图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ttcPicture_BeforeShow(object sender, ToolTipControllerShowEventArgs e)
        {
            if (e.SelectedControl != gcExhaustData) return;
            //获取鼠标停留位置
            Point _pt = gridView1.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo _info= gridView1.CalcHitInfo(_pt);
            if (_info==null||_info.InColumn||_info.Column!=gcLicenseNumber) return;
            
            Image ima= getToolTipsPicture(_info.RowHandle);
            if (ima != null)
            {
                (_stTipPicture.Items[0] as ToolTipItem).Text = null;
                (_stTipPicture.Items[0] as ToolTipItem).ImageOptions.Image = ima;
            }
            else
            {
                (_stTipPicture.Items[0] as ToolTipItem).Text = Program.infoResource.GetLocalizedString(language.InfoId.NoPicture);
                (_stTipPicture.Items[0] as ToolTipItem).ImageOptions.Image = null;
            }
            e.SuperTip = _stTipPicture;
        }
        /// <summary>
        /// 清除排序设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_GridMenuItemClick(object sender, GridMenuItemClickEventArgs e)
        {
            if (e.DXMenuItem.Caption == "清除排序设置")
            {
                _sortFactor = 0;
                _sortOrder = 2;
                Query(currentPage);
                pageControl();
            }
        }
        /// <summary>
        /// 一键打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbOneButtonPrint_Click(object sender, EventArgs e)
        {
            //query print pages
            if (dtpBegin.Value > dtpEnd.Value)
            {
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.BeginEndTime), "", MessageBoxButtons.OK);
                IsQueryOver = true;
                return;
            }
            ResultDataViewModel.VM.Execute(new List<object> {
                    ResultDataViewModel.ExecuteCommand.ec_QueryExhaustPage,
                    dtpBegin.Value,
                    dtpEnd.Value,
                    beLicense.Text,
                    cbeDetectionResult.SelectedIndex==0? "":(cbeDetectionResult.SelectedIndex-1).ToString(),
                    cbeFactor.Enabled?ConvertToABCD(cbeFactor.SelectedIndex):"",
                    beNOBegin.Text,
                    beNOEnd.Text,
                    beCOBegin.Text,
                    beCOEnd.Text,
                    beHCBegin.Text,
                    beHCEnd.Text,
                    beOpSmokeBegin.Text,
                    beOpSmokeEnd.Text,
                    cbeBlacknessBegin.SelectedIndex==-1?"":(cbeBlacknessBegin.SelectedIndex).ToString(),
                    cbeBlacknessEnd.SelectedIndex==-1?"":(cbeBlacknessEnd.SelectedIndex).ToString(),
                    _sortFactor,
                    _sortOrder,
                    cbePageRecord.SelectedItem.ToString(),
                    -1,
                    cbeLane.SelectedIndex,
                    cbeFuelType.SelectedIndex,
                    cbeVehicleType.SelectedIndex
            });
            ArrayList al = ResultDataViewModel.VM.ExhuastAllEntities;
            if (al == null || al.Count == 0)
            {
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.SelectNone));
                return;
            }
            else
            {
                wfPrintOneKey wf = new wfPrintOneKey(al);
                wf.ShowDialog();
            }
        }
        /// <summary>
        /// 横向打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {  
            e.Link.PrintingSystemBase.PageSettings.Landscape = true;
        }
    }
}