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
using System.IO;
using System.Reflection;
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.BAL.ImBAL;
using wayeal.os.exhaust.Models;

namespace wayeal.os.exhaust.Modules
{
    public partial class ucMain :ucManagerBase
    {
        IVehicleBAL BAL = new ImVehicleBAL();
       Vehicle vehicle = new Vehicle();
      
        private void ucMain_Load(object sender, EventArgs e)
        {
            vehicle = BAL.GetVehicle();
            gridControl2.DataSource = BAL.GetVehicles(5);
            gridControl1.DataSource = BAL.GetSumVehicles();
            vlcControl1.Video.FullScreen = true;
            setInfo(vehicle);
        }


        //赋值
        void setInfo(Vehicle vehicle)
        {

            //车牌号
            labelCarNo.Text = vehicle.vno;
            lblLinLevel.Text = vehicle.vringelman.ToString();
            lblRinC.Text = Convert.ToString(vehicle.vringelmancredi);
           
            //林格曼黑度置信度
          

            //
            vlcControl1.SetMedia(new System.IO.FileInfo(vehicle.vvideo));//本地视频
            vlcControl1.Video.AspectRatio="1:1";
            vlcControl1.Play();




        }
        public ucMain()
        {
            InitializeComponent();
           
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void vlcControl1_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            //LibVlcAPI.libvlc_set_fullscreen(libvlc_media_player_, istrue ? 1 : 0);

            
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

        private void button1_Click(object sender, EventArgs e)
        {
            vlcControl1.SetMedia(new System.IO.FileInfo(vehicle.vvideo));//本地视频
            vlcControl1.Play();
            
        }

        private void btnCarHead_Click(object sender, EventArgs e)
        {
            vlcControl1.SetMedia(new System.IO.FileInfo(vehicle.vheadimage));//本地视频
            vlcControl1.Play();
        }

        private void btnImage1_Click(object sender, EventArgs e)
        {
            vlcControl1.SetMedia(new System.IO.FileInfo(vehicle.vimage1));//本地视频
            vlcControl1.Play();
        }

        string[] level = { "I级", "II级", "III级", "IV级", "V级" };
        string[] descNo = { "5", "4", "3", "2", "1" };
        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {

            if (e.Column.Name == gcRing.Name)
            {
                e.DisplayText = level[e.ListSourceRowIndex].ToString();
            }
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
          
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {

            if (e.Column.Name == gvNo.Name)
            {
                e.DisplayText = descNo[e.ListSourceRowIndex].ToString();
            }
        }

        private void vlcControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnImage2_Click(object sender, EventArgs e)
        {
            vlcControl1.SetMedia(new System.IO.FileInfo(vehicle.vimage2));//本地视频
            vlcControl1.Play();
        }
    }
}
