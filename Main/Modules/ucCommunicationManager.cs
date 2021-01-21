using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.UserControls;

namespace wayeal.os.exhaust.Modules
{
    public partial class ucCommunicationManager : ucManagerBase
    {
        public ucCommunicationManager()
        {
            InitializeComponent();
        }
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                pnCommunication.Enabled = rbSerial.Checked;
                pnNetwork.Enabled = rbNetwork.Checked;
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
    }
}
