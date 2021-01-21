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
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.BAL.ImBAL;
using System.Reflection;
using System.IO;

namespace wayeal.os.exhaust.From
{
    public partial class wfVehileDetails : wfBase
    {
        IVehicleBAL BAL = new ImVehicleBAL();
        Vehicle vehicle = new Vehicle();
        int id;

        int total = 0;//共有多少条记录

        public wfVehileDetails(int id,int total)
        {
            this.id = id;
            this.total = total;
            InitializeComponent();
        }
        public wfVehileDetails()
        {
            

            
           
        }


        private void SetBaseInfo(Vehicle vehicle)
        {
            //车辆Id
            lblvid.Text = id.ToString();
            //站点名称
            lblvstationname.Text = vehicle.vstationname;
            //车辆颜色
            lblvcolor.Text = vehicle.vcolor;
            //车牌置信度
            lblvboardcredi.Text = vehicle.vboardcredi.ToString();//车牌置信度
            //林格曼置信度
            lblvringelmancredi.Text = vehicle.vringelmancredi.ToString();
            //查验日期
            lblvcheckdate.Text = vehicle.vcheckdate.ToString();
            //车牌号
            lblvno.Text = vehicle.vno;
            //车辆类型
            lblvboardtype.Text = vehicle.vboardtype;

            lblvtype.Text = vehicle.vtype;
            //林格曼黑度
            lblvringelman.Text = vehicle.vringelman.ToString();
            //车道号
            lblvroadno.Text = vehicle.vroadno.ToString();
            

            


        }

        private void btnImage2_Click(object sender, EventArgs e)
        {
            vlcControl1.SetMedia(new System.IO.FileInfo(vehicle.vimage2));//本地图片2
            vlcControl1.Play();
        }

        private void btncaptureVideo_Click(object sender, EventArgs e)
        {
            vlcControl1.SetMedia(new System.IO.FileInfo(vehicle.vvideo));//本地视频
            vlcControl1.Play();
        }

        private void btnImage1_Click(object sender, EventArgs e)
        {

            vlcControl1.SetMedia(new System.IO.FileInfo(vehicle.vimage1));//本地图片1
            vlcControl1.Play();
        }

        private void btnCarHead_Click(object sender, EventArgs e)
        {

            vlcControl1.SetMedia(new System.IO.FileInfo(vehicle.vheadimage));//车头图片
            vlcControl1.Play();
        }

        private void vlcControl1_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;

            if (currentDirectory == null)
                return;
            if (IntPtr.Size == 4)
                e.VlcLibDirectory = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x86\"));
            else
                e.VlcLibDirectory = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x64\"));

            if (!e.VlcLibDirectory.Exists)
            {
                var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
                folderBrowserDialog.Description = "Select Vlc libraries folder.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void wfVehileDetails_Load(object sender, EventArgs e)
        {
            vehicle = BAL.SelectVehicleById(id);
            SetBaseInfo(vehicle);
            vlcControl1.SetMedia(new System.IO.FileInfo(vehicle.vimage2));//本地图片2
            vlcControl1.Play();
            InitializeComponent();
        }

        private void vlcControl1_Click(object sender, EventArgs e)
        {

        }

        //上一条信息
        private void button2_Click(object sender, EventArgs e)
        {

           
            //判断他是否小于1
            if(id > 1){
                //每点击一次上一条 Id减1 
                id -= 1;
                wfVehileDetails wfVehileDetails = new wfVehileDetails(id, total);
                wfVehileDetails.Show();

                
            }
            else
            {
                MessageBox.Show("已经是第一条！");
            }

           

        }


        //下一条信息
        private void button1_Click(object sender, EventArgs e)
        {
           

            //id号是否大于总记录条数

            if (id < total)
            {
                id += 1;
                wfVehileDetails wfVehileDetails = new wfVehileDetails(id, total);
                wfVehileDetails.Show();
            }
            else
            {
                MessageBox.Show("已经是最后一条记录了！");
                
            }

            //下一条  id增加1

        }


        //private void setEnvInfo()


    }
}
