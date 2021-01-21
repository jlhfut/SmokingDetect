using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraNavBar;

namespace wayeal.os.exhaust.Modules
{
    public partial class ucDebugger : ucManagerBase
    {
        public ucDebugger()
        {
            try
            {
                InitializeComponent();
                InitializeUI();
                InitPcClient();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        /// <summary>
        /// 响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucDevices_DeviceClick(object sender, UserControls.ucDebuggingDevices.DeviceClickEventArgs e)
        {
            try
            {
                if (e.SetupUI == null) return;
                pcClient.Controls.Clear();
                pcClient.Controls.Add(e.SetupUI);
                e.SetupUI.Dock = DockStyle.Fill;
                Program.resourceManager.ApplyLanguage(pcClient);
                Program.permissionManager.ApplyPermission(pcClient);
            }
            catch(Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        //默认显示一个界面
        private void InitPcClient()
        {
            ucDevices_DeviceClick(this, ucDevices.FirstEvent);
        }
    }
}
