using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wayeal.os.exhaust.Forms
{
    public partial class wfPrintOneKey : Form
    {
        XtraReport ReportSendToPrinter = null;
        Thread StartPrintThread = null;
        int CurrentPage = 0;
        

        /// <summary>
        /// 未手动停止
        /// </summary>
        bool hasManualStop = true;
        public wfPrintOneKey(ArrayList al)
        {
            InitializeComponent();
            pbcPrint.Properties.Maximum = al.Count;
            if (StartPrintThread == null)
            {
                StartPrintThread = new Thread(new ParameterizedThreadStart(InitPrintDocument));
            }
            StartPrintThread.Start(al);
        }
        private void InitPrintDocument(object o)
        {
            try
            {
                if (!(o is ArrayList)) return;
                ArrayList al = o as ArrayList;

                hasManualStop = true;
                CurrentPage = 0;
                while (CurrentPage < al.Count && hasManualStop)
                {
                    PrintOnePage(al[CurrentPage]);
                    //ReportSendToPrinter = new VehicleInfoReportZNCH(al[0]);
                    //ReportSendToPrinter.CreateDocument();
                    //ReportSendToPrinter.BeforePrint += new PrintEventHandler(PrintOnPageEventHandler);
                    //ReportSendToPrinter.Print();
                    CurrentPage++;
                    pbcPrint.BeginInvoke(new Action(UpdateProcess));
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
        }
        private void UpdateProcess()
        {
            pbcPrint.Position = CurrentPage+1;
        }

        //private void PrintOnPageEventHandler(object sender, PrintEventArgs e)
        //{
        //    //每次打印往后加一张
        //    if (CurrentIndex <= AllPagesCount)
        //    {
        //        ReportSendToPrinter.print;
        //    }
        //    CurrentIndex++;
        //    if (CurrentIndex > AllPagesCount)
        //    {
        //        //打印结束
        //    }
        //}

        private void sbStopPrint_Click(object sender, EventArgs e)
        {
            hasManualStop = false;
            this.DialogResult = DialogResult.OK;
        }

        private void PrintOnePage(object o)
        {
            XtraReport report = new VehicleInfoReportZNCH(o);
            report.CreateDocument();
            report.Print();
        }
        
    }
}
