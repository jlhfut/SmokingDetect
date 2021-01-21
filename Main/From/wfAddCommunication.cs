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
using wayeal.os.exhaust.Models;
using wayeal.os.exhaust.LogUtils;
using wayeal.os.exhaust.BAL.ImBAL;
using wayeal.os.exhaust.DAL.IDAL;
using wayeal.os.exhaust.BAL.IBAL;

namespace wayeal.os.exhaust.From
{
    public partial class wfAddCommunication  :wfBase
    {
        public wfAddCommunication()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        /// <summary>
        /// 添加通讯设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbConfirm_Click(object sender, EventArgs e)
        {
            

                DeviceList device = new DeviceList();

                device.dname = teNewComName.Text;
                if (cbeComType.SelectedIndex == 0)
                {
                    device.dtype = "TCP";
                }
                else
                {
                    device.dtype = "串口";
                }

               IDeviceListBAL BAL= new ImDeviceListBAL();
              int flag=  BAL.addDevice(device);
                if (flag > 0)
                {
                    MessageBox.Show("新增成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("新增失败！");
                    this.Close();
                }


               // LogHelper.LogUtlis("wfAddCommunication", ex);

            
           
        }
    }
}
