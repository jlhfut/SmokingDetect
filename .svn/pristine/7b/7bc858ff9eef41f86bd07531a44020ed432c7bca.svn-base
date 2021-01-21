using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wayee.Services;

namespace wayeal.os.exhaust.Forms
{
    public partial class wfWaitSOA : wfBase
    {
        int count = 0;
        private string title;

        public wfWaitSOA()
        {
            InitializeComponent();
            InitializeUI();
            title = lcSOAConnection.Text + "...";
            lcSOAConnection.Text = title;
        }

        private void sbExit_Click(object sender, EventArgs e)
        {
            tm.Enabled = false;
            this.DialogResult = DialogResult.Cancel;
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            count++;
            lcSOAConnection.Text = title.Substring(0, title.Length - 3 + count) + "   ".Substring(0, 3 - count);
            count = count % 3;
            if (count > 0) return;
            string soa = "Wayee.Services.RemotingServer";
            System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processList)
            {
                if (process.ProcessName.ToLower() == soa.ToLower())
                {
                    //查看连接的服务数量是否大于4
                    CheckServerCount();
                    tm.Enabled = false;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void CheckServerCount()
        {
            int serverCount = 0;
            while (serverCount < 4)
            {
                try
                {
                    if (SOAClient.Instance != null)
                    {
                        SOAClient.Instance.LoadServices();
                        serverCount = SOAClient.Instance.ServerCount;
                    }
                }
                catch
                {

                }
            }
        }
    }
}
