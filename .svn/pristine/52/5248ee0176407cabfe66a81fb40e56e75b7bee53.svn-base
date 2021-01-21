using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.UserControls;

namespace wayeal.os.exhaust.Forms
{
    public partial class wfPrint : DevExpress.XtraBars.Ribbon.RibbonForm
    { 
        public wfPrint(ArrayList al,string userName)
        {
            InitializeComponent();
            Program.resourceManager.ApplyLanguage(this);
            Program.permissionManager.ApplyPermission(this);
            
            Initpdf(al, userName);
        }
        private void Initpdf(ArrayList al,string userName)
        {
            ucpdf pdf = new ucpdf( al, userName);
            pcPrint.Controls.Add(pdf);
            pdf.Dock = DockStyle.Fill;
        }

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           XtraReport report = ucpdf.GetPrintDocument();
            if (report.PrintDialog() == DialogResult.OK)
            {
                // report.Print();
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess));
            }
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport report = ucpdf.GetPrintDocument();
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "便携式文件(*.pdf)|*.pdf";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                report.ExportToPdf(dialog.FileName);
            }
        }
    }
}
