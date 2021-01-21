using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using wayeal.os.exhaust.ViewModel;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using Microsoft.Office.Interop.Excel;
using wayeal.os.exhaust.Modules;
using Newtonsoft.Json.Linq;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucDataAnalysisTagPage : ucBase
    {
        int index = 0;
        string curLane = "Left";
        private string _defaultFileName= "WYExhaust_PT_";
        string[] _UVTitle = { "紫外背景光谱", "遥测光谱", "NO吸光度", "HC吸光度", "遥测吸光度" };
        string[] _TDTitle = { "红外背景光谱", "CO谐波", "CO2谐波", "红外背景谐波", "遥测谐波" };
        ucDataAnalysisOneLane oneLane = null;
        private ucExhaustData ucEdata = null;

        public ucDataAnalysisTagPage()
        {
            InitializeComponent();
            oneLane = new ucDataAnalysisOneLane();
            
        }
        public ucDataAnalysisTagPage( int iIndex,ucExhaustData uc)
        {
            InitializeComponent();
            ucEdata = uc;
            index = iIndex;
            oneLane = new ucDataAnalysisOneLane(iIndex,uc);
            pcOnePage.Controls.Add(oneLane);
            oneLane.Dock = DockStyle.Fill;
            oneLane.SetLane(curLane);
            InitializeUI();
        }
        #region refrush
        public void RefrushData(int iIndex)
        {
            index = iIndex;
            string uniquekey = ucEdata.GetUniqueKeyByIndex(index);
            ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryDetialInfo, index, uniquekey });
            if (ResultDataViewModel.VM.DetialInfoEntities == null || ResultDataViewModel.VM.DetialInfoEntities.Count == 0) return;
            object o = ResultDataViewModel.VM.DetialInfoEntities[0];
            if (o is JObject)
            {
                JObject jo = (o as JObject);
                string value = jo["DataPath"].ToString();
                if (!string.IsNullOrEmpty(value)) ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryChartInfo, value.ToString(), curLane });
            }
        }
        #endregion
        #region Switch Lane
        private void SetBtnColor(SimpleButton btn,bool IsUsed)
        {
            if (IsUsed)
            {
                btn.Appearance.BackColor = Color.FromArgb(32, 88, 165);
                btn.AppearanceHovered.BackColor = Color.FromArgb(77, 121, 183);
                btn.AppearancePressed.BackColor = Color.FromArgb(32, 88, 165);
            }
            else
            {
                btn.Appearance.BackColor = Color.DarkGray;
                btn.AppearanceHovered.BackColor = Color.Silver;
                btn.AppearancePressed.BackColor = Color.DarkGray;
            }
        }
        private void sbLeftLane_Click(object sender, EventArgs e)
        {
            SetBtnColor(sbLeftLane, true);
            SetBtnColor(sbRightLane, false);
            curLane = "Left";
            if(oneLane!=null) oneLane.SetLane(curLane,index);
        }

        private void sbRightLane_Click(object sender, EventArgs e)
        {
            SetBtnColor(sbLeftLane, false);
            SetBtnColor(sbRightLane, true);
            curLane = "Right";
            if (oneLane != null) oneLane.SetLane(curLane,index);
        }
        #endregion
        #region Turn Page
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lcNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (++index >= ResultDataViewModel.VM.ExhuastEntities.Count)
                {
                    index--;
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.LastInfo), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (oneLane != null) oneLane.RefreshChartInfo(index);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lcPrePage_Click(object sender, EventArgs e)
        {
            try
            {
                if (--index < 0)
                {
                    index++;
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.FirstInfo), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (oneLane != null) oneLane.RefreshChartInfo(index);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        #endregion
        #region Drive Data
        private void sbDeriveSpectrogram_Click(object sender, EventArgs e)
        {
            SaveDataToExcel();
        }
        
        public void SaveDataToExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "导出Excel文件";
            saveFileDialog.Filter = "Excel 工作簿(*.xlsx)|*.xlsx|Excel 97-2003 工作簿(*.xls)|*.xls";
            //设置默认文件类型显示顺序  
            saveFileDialog.FilterIndex = 1;
            //是否自动在文件名中添加扩展名
            saveFileDialog.AddExtension = true;
            //是否记忆上次打开的目录
            saveFileDialog.RestoreDirectory = true;
            //设置默认文件名
            saveFileDialog.FileName = _defaultFileName;
            //按下确定选择的按钮  
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获得文件路径 
                string localFilePath = saveFileDialog.FileName.ToString();

                ////数据初始化
                //int TotalCount;     //总行数
                //int RowRead = 0;    //已读行数
                //int Percent = 0;    //百分比

                //NPOI
                IWorkbook workbook;
                string FileExt = Path.GetExtension(localFilePath).ToLower();
                if (FileExt == ".xlsx")
                {
                    workbook = new XSSFWorkbook();
                }
                else if (FileExt == ".xls")
                {
                    workbook = new HSSFWorkbook();
                }
                else
                {
                    workbook = null;
                }
                if (workbook == null)
                {
                    return;
                }

                ISheet sheet = workbook.CreateSheet("紫外设备");

                try
                {
                    //读取标题  
                    IRow rowHeader = sheet.CreateRow(0);
                    ICell cell = rowHeader.CreateCell(0);
                    cell.SetCellValue("紫外");
                    rowHeader = sheet.CreateRow(1);
                    for (int i = 0; i < _UVTitle.Count(); i++)
                    {
                        cell = rowHeader.CreateCell(i);
                        cell.SetCellValue(_UVTitle[i]);
                    }
                    //合并单元格
                    CellRangeAddress region = new CellRangeAddress(0, 0, 0, 4);
                    sheet.AddMergedRegion(region);
                    //导出数据
                    if (ResultDataViewModel.VM.ExhaustDetailData.UVSCalParam != null)
                        DriveDataToSheet(sheet, ResultDataViewModel.VM.ExhaustDetailData.UVSCalParam.ZeroIntensity, 0);
                    DriveDataToSheet(sheet, ResultDataViewModel.VM.ExhaustDetailData.UVSData, 1);
                    if (ResultDataViewModel.VM.ExhaustDetailData.UVSNOCalParam != null)
                        DriveDataToSheet(sheet, ResultDataViewModel.VM.ExhaustDetailData.UVSNOCalParam.Absorb, 2);
                    if (ResultDataViewModel.VM.ExhaustDetailData.UVSHCCalParam != null)
                        DriveDataToSheet(sheet, ResultDataViewModel.VM.ExhaustDetailData.UVSHCCalParam.Absorb, 3);
                    DriveDataToSheet(sheet, ResultDataViewModel.VM.ExhaustDetailData.AbsorbData, 4);

                    sheet = workbook.CreateSheet("红外设备");

                    //读取标题  
                    rowHeader = sheet.CreateRow(0);
                    cell = rowHeader.CreateCell(0);
                    cell.SetCellValue("红外");
                    rowHeader = sheet.CreateRow(1);
                    for (int i = 0; i < _TDTitle.Count(); i++)
                    {
                        cell = rowHeader.CreateCell(i);
                        cell.SetCellValue(_TDTitle[i]);
                    }
                    //合并单元格
                    region = new CellRangeAddress(0, 0, 0, 4);
                    sheet.AddMergedRegion(region);
                    //导出数据
                    if (ResultDataViewModel.VM.ExhaustDetailData.TDLASCalParam != null)
                        DriveDataToSheet(sheet, ResultDataViewModel.VM.ExhaustDetailData.TDLASCalParam.ZeroIntensity, 0);
                    if (ResultDataViewModel.VM.ExhaustDetailData.TDLASCOCalParam != null)
                        DriveDataToSheet(sheet, ResultDataViewModel.VM.ExhaustDetailData.TDLASCOCalParam.Harm, 1);
                    if (ResultDataViewModel.VM.ExhaustDetailData.TDLASCO2CalParam != null)
                        DriveDataToSheet(sheet, ResultDataViewModel.VM.ExhaustDetailData.TDLASCO2CalParam.Harm, 2);
                    if (ResultDataViewModel.VM.ExhaustDetailData.TDLASCalParam != null)
                        DriveDataToSheet(sheet, ResultDataViewModel.VM.ExhaustDetailData.TDLASCalParam.Harm, 3);
                    DriveDataToSheet(sheet, ResultDataViewModel.VM.ExhaustDetailData.HarmData, 4);

                    System.Windows.Forms.Application.DoEvents();

                    //转为字节数组  
                    MemoryStream stream = new MemoryStream();
                    workbook.Write(stream);
                    var buf = stream.ToArray();

                    //保存为Excel文件
                    using (FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(buf, 0, buf.Length);
                        fs.Flush();
                        fs.Close();
                    }

                    //成功提示
                    if (MessageBox.Show("导出成功，是否立即打开？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(localFilePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {

                }
            }

        }

        private void DriveDataToSheet<T>(ISheet sheet, List<T> list, int column)
        {
            if (list == null || list.Count == 0) return;
            for (int i = 0; i < list.Count; i++)
            {
                IRow row = sheet.LastRowNum >= i + 2 ? sheet.GetRow(i + 2) : sheet.CreateRow(i + 2);
                ICell cell = row.CreateCell(column);
                cell.SetCellValue(list[i].ToString());
            }
        }
        #endregion
    }
}
