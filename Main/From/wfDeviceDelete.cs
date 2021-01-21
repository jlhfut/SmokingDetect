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
using wayeal.os.exhaust.Forms;
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.BAL.ImBAL;

namespace wayeal.os.exhaust.From
{
    public partial class wfDeviceDelete :wfBase
    {
        string dname;
        IDeviceListBAL BAL = new ImDeviceListBAL();
       
        public wfDeviceDelete(string dname)
        {
            InitializeComponent();
            this.dname = dname;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dname);
            //this.Close();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dname);
            int isb=BAL.DeleteByDName(dname);
            if (isb < 0)
            {
                MessageBox.Show("删除失败");
            }
            else
            {
                MessageBox.Show("删除成功");
                this.Close();
            }
        }

       
    }
}
