﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using wayeal.os.exhaust.Modules;
using System.Collections;
using Newtonsoft.Json.Linq;
using wayeal.os.exhaust.ViewModel;
using Wayee.Services;
using System.Drawing.Printing;
using System.Threading;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucpdf : ucBase
    {
        public static XtraReport xtraReport = new XtraReport();
        int pdfCount = 2;
        string moniName = "";
        List<object> _listLimit = new List<object>();
        DTDieselCarLimitingInfo dtDiesel = new DTDieselCarLimitingInfo();
        DTGasolineLimitingInfo dtGaso = new DTGasolineLimitingInfo();
        DTOtherParamInfo dtOther = new DTOtherParamInfo();
        Thread LoadPdfThread = null;
        public ucpdf(ArrayList al,string userName)
        {
            InitializeComponent();
            InitializeUI();
            if (al == null || al.Count == 0) return;
            pdfCount = al.Count;
            moniName = userName;
       //     QueryStationAndLimitInfo();
            if (LoadPdfThread == null)
            {
                LoadPdfThread = new Thread(new ParameterizedThreadStart(ShowNewPdf));
                LoadPdfThread.Start(al);
            }
            //ShowNewPdf(al);
        }
        /// <summary>
        /// 显示pdf
        /// </summary>
        /// <param name="al"></param>
        private void ShowNewPdf(object o)
        {
            while (!this.IsHandleCreated)
            {
                ;
            }
            this.Invoke(new Action(() =>
            {
                ArrayList al = o as ArrayList;
                pbLoad.Visible = true;
                pbLoad.Minimum = 0;
                pbLoad.Maximum = al.Count;
                pbLoad.Value = 0;
                

                XtraReport report = new VehicleInfoReportZNCH(al[0]);
                report.CreateDocument();
                pbLoad.Value = 1;

                for (int i = 1; i < al.Count; i++)
                {
                    XtraReport report2 = new VehicleInfoReportZNCH(al[i]);
                    report2.Landscape = false;   //纵向
                    report2.PrintingSystem.ContinuousPageNumbering = true;
                    report2.CreateDocument();
                    report.Pages.AddRange(report2.Pages);
                    pbLoad.Value = i + 1;
                }
                documentViewer1.DocumentSource = report;//指定文档源
                xtraReport = report;
                pbLoad.Visible = false;
            }
            ));
        }
        /// <summary>
        /// 查询站点信息和限值信息
        /// </summary>
        private void QueryStationAndLimitInfo()
        {
            //查询限值信息
            _listLimit.Clear();
            ResultDataViewModel.VM.Execute(new List<object> {
                ResultDataViewModel.ExecuteCommand.ec_QueryDieselCarLimiting });
            if(ResultDataViewModel.VM.DieselCarLimitingEntities!=null&& ResultDataViewModel.VM.DieselCarLimitingEntities.Count>0)
                dtDiesel = (DTDieselCarLimitingInfo) ResultDataViewModel.VM.DieselCarLimitingEntities[0];

            ResultDataViewModel.VM.Execute(new List<object> {
                ResultDataViewModel.ExecuteCommand.ec_QueryGasolineLimiting });
            if (ResultDataViewModel.VM.GasolineLimitingEntities != null && ResultDataViewModel.VM.GasolineLimitingEntities.Count > 0)
                dtGaso = (DTGasolineLimitingInfo)ResultDataViewModel.VM.GasolineLimitingEntities[0];
            _listLimit.Add(dtDiesel);
            _listLimit.Add(dtGaso);
        }
        public static XtraReport GetPrintDocument()
        {
            return xtraReport;
        }
    }
}
