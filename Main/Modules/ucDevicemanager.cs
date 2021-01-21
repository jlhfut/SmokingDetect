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
using wayeal.os.exhaust.BAL.IBAL;
using wayeal.os.exhaust.BAL.ImBAL;
using wayeal.os.exhaust.Models;
using wayeal.os.exhaust.From;
using wayeal.os.exhaust.HKDevice;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace wayeal.os.exhaust.Modules
{
    public partial class ucDevicemanager : ucManagerBase
    {



        private int iFileNumber = 0; //保存的文件个数
        private Int32 m_lUserID = -1;  //是否登陆成功
        private int m_lRealHandle;
       
        private CHCNetSDK.MSGCallBack_V31 m_falarmData_V31 = null;
        private CHCNetSDK.MSGCallBack m_falarmData = null;
        private delegate void setLabeltext(string str);


        private Int32 m_lUserID2 = -1;
        private int m_lRealHandle2;
        //业务层
        IDeviceListBAL BAL = new ImDeviceListBAL();

        public ucDevicemanager()
        {
            InitializeComponent();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {


        }

        private void sbtnHead_Click(object sender, EventArgs e)
        {

        }

        private void sbtnSmoke_Click(object sender, EventArgs e)
        {


        }

        private void sbtnAstome_Click(object sender, EventArgs e)
        {

        }

        private void tpConnectList_Paint(object sender, PaintEventArgs e)
        {

        }


        /// <summary>
        /// 加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void ucDevicemanager_Load(object sender, EventArgs e)
        {


            //1.初始化SDK
            bool m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                MessageBox.Show("SDK 初始化失败");
                return;
            }

            //2.设置回调函数

            if (m_falarmData_V31 == null)
            {
                m_falarmData_V31 = new CHCNetSDK.MSGCallBack_V31(MSgCallback_V31);
            }
            CHCNetSDK.NET_DVR_SetDVRMessageCallBack_V31(m_falarmData_V31, IntPtr.Zero);
            



            pcAstome.Hide();
            panelCom.Hide();
            pTcp.Hide();
            listBoxControl1.DataSource = BAL.GetAllDeviceInfo(new Models.DeviceList());
            listBoxControl1.DisplayMember = "dname";
            //选择方式
            //listBoxControl1.SelectionMode = SelectionMode.One;

            List<DeviceList> list = BAL.GetAllDeviceInfo();
            DeviceList s = new DeviceList();


            for (int i = 0; i < list.Count; i++)
            {
                //imagecontrolist
                ilbcDevice.Items.Add(list.ElementAt(i).dname);
                if (s.dstate == true)
                {
                    ilbcDevice.Items[i].ImageIndex = 1;
                }
                else
                {
                    ilbcDevice.Items[i].ImageIndex = 0;
                }
            }

            List<DeviceList> list2 = BAL.GetAllDeviceInfo();
            DeviceList s2 = new DeviceList();


            for (int i = 0; i < list2.Count; i++)
            {
                //imagecontrolist
                ilbcConnectList.Items.Add(list.ElementAt(i).dname);

                ilbcConnectList.Items[i].ImageIndex = 0;

            }





        }


        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="lCommand">报警信息类型</param>
        /// <param name="pAlarmer"></param>
        /// <param name="pAlarmInfo"></param>
        /// <param name="dwBufLen"></param>
        /// <param name="pUser"></param>
        /// <returns></returns>
        private bool MSgCallback_V31(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {



            switch (lCommand)  //不同的lCommand对应不同的pAlarmInfo内容
            {
                case CHCNetSDK.COMM_ITS_PLATE_RESULT://交通抓拍结果上传（新类型）

                   

                    {



                        #region 车头相片  第一部相机
                        CHCNetSDK.NET_ITS_PLATE_RESULT struITSPlateResult2 = new CHCNetSDK.NET_ITS_PLATE_RESULT();
                        uint dwSize2 = (uint)Marshal.SizeOf(struITSPlateResult2);
                        struITSPlateResult2 = (CHCNetSDK.NET_ITS_PLATE_RESULT)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_ITS_PLATE_RESULT));
                        int lChannel2 = 1; //通道号 Channel number
                        CHCNetSDK.NET_DVR_MakeKeyFrame(m_lUserID, lChannel2);

                        //保存车头相片
                        byte[] Carno = struITSPlateResult2.struPlateInfo.sLicense; //车牌号码
                        byte roudNo = struITSPlateResult2.byDriveChan;//车道号


                        byte secondCam = struITSPlateResult2.bySecondCam;

                        string carNumber = System.Text.Encoding.Default.GetString(Carno);
                        string nocar = roudNo.ToString();
                        string strSecondCam = secondCam.ToString();
                        string chepaihao = System.Text.Encoding.GetEncoding("GBK").GetString(struITSPlateResult2.struPlateInfo.sLicense).TrimEnd('\0');
                        string headpath= "F:\\VideoCapture\\picture\\NoCar.jpg";
                        //保存抓拍图片
                        for (int i = 0; i < struITSPlateResult2.dwPicNum; i++)
                        {
                            if (struITSPlateResult2.struPicInfo[i].dwDataLen != 0)
                            {
                                // label7.Text = nocar;

                                //iFileNumber

                              

                                string path = "F:\\VideoCapture\\picture";


                                if (System.IO.Directory.Exists(path) == false)
                                {
                                    System.IO.Directory.CreateDirectory(path);
                                }

                               headpath = "\\" + "G" + chepaihao + "G2" + secondCam + ".jpg";
                                if (struITSPlateResult2.struPicInfo[i].byType == 1)
                                {
                                    FileStream fs = new FileStream(headpath, FileMode.Create);
                                    int iLen = (int)struITSPlateResult2.struPicInfo[i].dwDataLen;
                                    byte[] by = new byte[iLen];
                                    Marshal.Copy(struITSPlateResult2.struPicInfo[i].pBuffer, by, 0, iLen);
                                    fs.Write(by, 0, iLen);
                                    fs.Close();

                                }
                                iFileNumber++;

                            }
                        }


                        #endregion

                    



                        #region 保存视频 黑烟相机  第二部相机


                        CHCNetSDK.NET_ITS_PLATE_RESULT struITSPlateResult = new CHCNetSDK.NET_ITS_PLATE_RESULT();
                        uint dwSize = (uint)Marshal.SizeOf(struITSPlateResult);
                        struITSPlateResult = (CHCNetSDK.NET_ITS_PLATE_RESULT)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_ITS_PLATE_RESULT));

                        //获取黄色车牌才抓拍以及录视频




                        //车牌颜色
                        byte plateColor = struITSPlateResult.struPlateInfo.byColor; //1黄色

                        //录像保存路径和文件名 the path and file name to save
                        string sVideoFileName;
                        string path2 = "F:\\VideoCapture";
                        if (System.IO.Directory.Exists(path2) == false)
                        {
                            System.IO.Directory.CreateDirectory(path2);
                        }
                        sVideoFileName = "\\" + DateTime.Now.ToString("hhmmss") + ".mp4";



                        //强制I帧 Make a I frame
                        //  int lChannel = Int16.Parse(textBoxChannel.Text); //通道号 Channel number
                        int lChannel = 2; //通道号 Channel number
                        CHCNetSDK.NET_DVR_MakeKeyFrame(m_lUserID2, lChannel);

                        //开始录像 Start recording
                        CHCNetSDK.NET_DVR_SaveRealData(m_lUserID2, sVideoFileName);
                        Thread.Sleep(5000);
                        //停止录像
                        CHCNetSDK.NET_DVR_StopSaveRealData(m_lUserID2);
                        #endregion


                        #region  调用黑烟检测函数     如果满足要求将 先关信息存入到数据库

                        string ss = HttpGet("http://192.168.200.8:5000/parse/");




                        JsonReader reader = new JsonTextReader(new StringReader(ss));

                        while (reader.Read())
                        {


                            ss = reader.Value.ToString();
                        }
                        Console.WriteLine("处理后：" + ss);


                        JArray jArray = (JArray)JsonConvert.DeserializeObject(ss);


                        string vLicenceNo = jArray[0]["vLicenceNo"].ToString();
                        float vLicenceNoCer = (float)Convert.ToDouble(jArray[0]["vLicenceNoCer"]);
                        int vRingelLevel = Convert.ToInt32(jArray[0]["vRingelLevel"]);//jArray[0]["vRingelLevel"].ToString();

                        float vRingelLevelCer = (float)Convert.ToDouble(jArray[0]["vRingelLevelCer"]);
                        string vType = jArray[0]["vType"].ToString();
                        string vLicenceColor = jArray[0]["vLicenceColor"].ToString();
                        string vLicenceType = jArray[0]["vLicenceType"].ToString();
                        string vimage11= jArray[0]["vImage1"].ToString();
                        string vimage21= jArray[0]["vImage2"].ToString();

                        #endregion

                        #region 保存数据



                        DateTime vchecktime = System.DateTime.Now;//检测的时间
                        string vstation = "文曲路";//站点
                        string vno = vLicenceNo;//车牌号
                        float vnocer = vLicenceNoCer;
                        string vcolor = vLicenceColor;//车牌颜色
                        string vtype = vType;
                        int vroadno = roudNo;
                        string vboadtype = vLicenceType;
                        float vboardcer = vLicenceNoCer;//车牌置信度
                        int vrigel = vRingelLevel;//林格曼黑度

                        float vrigelcer = vRingelLevelCer;//置信度
                        string vimage1 = vimage11; //车尾照片1
                        string vimage2 =vimage21;//车尾照片2
                        string vimage = headpath;
                        string vvideo = sVideoFileName;


                        Vehicle v = new Vehicle();
                        v.vcheckdate = vchecktime;
                        v.vstationname = vstation;
                        v.vno = vno;
                        v.vboardcredi =  (float)vnocer;
                        v.vcolor = vcolor;
                        v.vroadno = vroadno;
                        v.vboardtype = vboadtype;
                        v.vringelman = vrigel;
                        v.vringelmancredi =(float) vrigelcer;
                        
                        v.vimage1 = vimage1;
                        v.vheadimage = vimage;
                        v.vimage2 = vimage2;

                        v.vvideo = vvideo;

                        IVehicleBAL vehicleBAL = new ImVehicleBAL();
                        if (vehicleBAL.AddVehicle(v) < 0)
                        {
                            MessageBox.Show("添加失败");
                        }





                        #endregion


                    }
                    break;
            }

            return true;
        }


    /// <summary>
    /// TCP 模式填充
    /// </summary>
    /// <param name="device"></param>
    public void setPanelTcpInfo(DeviceList device)
        {

            txtDeviceName.Text = device.dname;
            cbxConnectType.SelectedIndex = 0;

            txtIP.Text = device.dip;
            txtPort.Text = device.dport;

        }

        public void setPanelCommInfo(DeviceList device)
        {
            txtName.Text = device.dname;

            cbxType.SelectedIndex = 1;

            cbePortNo.SelectedItem = device.dport;
            cbxBoadRate.SelectedItem = device.dbaud;
            cbxData.SelectedItem = device.ddata;
            cbxStop.SelectedItem = device.dstop;
            cbxCheck.SelectedItem = device.dcheck;

            //cbxBoadRate;
            //cbxData;
            //cbxStop;
            //cbxCheck;


        }

        private void listBoxControl1_SelectedValueChanged(object sender, EventArgs e)
        {





        }

        private void listBoxControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            wfAddCommunication wfac = new wfAddCommunication();
            wfac.Show();

        }


        /// <summary>
        /// 修改TCP模式设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            DeviceList device = new DeviceList();
            device.dname = txtDeviceName.Text;
            device.dport = cbxConnectType.SelectedText;

            switch (cbxConnectType.SelectedIndex)
            {
                case 0:
                    device.dtype = "TCP";
                    break;
                case 1:
                    device.dtype = "串口";
                    break;

            }
            device.dip = txtIP.Text.ToString();
            device.dport = txtPort.Text;
            int flag = BAL.UpDataByName(device);
            if (flag > 0)
            {
                MessageBox.Show("保存成功");
                listBoxControl1.DataSource = BAL.GetAllDeviceInfo(new Models.DeviceList());
                listBoxControl1.DisplayMember = "dname";
                //选择方式
                listBoxControl1.SelectionMode = SelectionMode.One;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

            DeviceList device = new DeviceList();

            device.dname = txtName.Text.ToString();
            switch (cbxType.SelectedIndex)
            {
                case 0:
                    device.dtype = "TCP";
                    break;
                case 1:
                    device.dtype = "串口";
                    break;
            }
            //端口号
            switch (cbePortNo.SelectedIndex)
            {
                case 0:
                    device.dport = "COM1";
                    break;
                case 1:
                    device.dport = "COM2";
                    break;
                case 2:
                    device.dport = "COM3";
                    break;
                case 3:
                    device.dport = "COM4";
                    break;
                case 4:
                    device.dport = "COM5";
                    break;
                case 5:
                    device.dport = "COM6";
                    break;
                case 6:
                    device.dport = "COM7";
                    break;
                case 7:
                    device.dport = "COM8";
                    break;
                case 8:
                    device.dport = "COM9";
                    break;


            }

            switch (cbxBoadRate.SelectedIndex)
            {
                case 0:
                    device.dbaud = 4800;
                    break;
                case 1:
                    device.dbaud = 9600;
                    break;
                case 2:
                    device.dbaud = 14400;
                    break;
                case 3:
                    device.dbaud = 19200;
                    break;
                case 4:
                    device.dbaud = 1152;
                    break;
            }
            switch (cbxData.SelectedIndex)
            {
                case 0:
                    device.ddata = 5;
                    break;
                case 1:
                    device.ddata = 6;
                    break;
                case 2:
                    device.ddata = 7;
                    break;
                case 3:
                    device.ddata = 8;
                    break;
            }
            switch (cbxStop.SelectedIndex)
            {
                case 0:
                    device.dstop = 1;
                    break;
                case 1:
                    device.dstop = 2;
                    break;
            }

            switch (cbxCheck.SelectedIndex)
            {
                case 0:
                    device.dcheck = "None";
                    break;
                case 1:
                    device.dcheck = "Odd";
                    break;
                case 2:
                    device.dcheck = "Even";
                    break;
                case 3:
                    device.dcheck = "Mark";
                    break;
                case 4:
                    device.dcheck = "Space";
                    break;
            }

            int flag = BAL.UpDataByName(device);
            if (flag > 0)
            {
                MessageBox.Show("添加成功");
            }
        }

        private void ilbcDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

            DeviceList device = new DeviceList();
            //获得选中的值
            string dname = ilbcDevice.SelectedItem.ToString().Trim();

            int i = ilbcDevice.SelectedIndex;

            

            //根据网口来决定显示哪一个pannel
            device = BAL.GetDeviceByName(dname);


            if (device.dtype == "TCP")
            {
                pchead.Show();
                pcAstome.Hide();
                SetHeadInfo(device);
            }
            else
            {
                pchead.Hide();
                pcAstome.Show();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 串口删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncom_delete_Click(object sender, EventArgs e)
        {
            wfDeviceDelete wfd = new wfDeviceDelete(txtDeviceName.Text.Trim());
            wfd.Show();

        }
        /// <summary>
        /// 串口保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncom_save_Click(object sender, EventArgs e)
        {
            DeviceList device = new DeviceList();

            device.dname = txtName.Text.ToString();
            switch (cbxType.SelectedIndex)
            {
                case 0:
                    device.dtype = "TCP";
                    break;
                case 1:
                    device.dtype = "串口";
                    break;
            }
            //端口号
            switch (cbePortNo.SelectedIndex)
            {
                case 0:
                    device.dport = "COM1";
                    break;
                case 1:
                    device.dport = "COM2";
                    break;
                case 2:
                    device.dport = "COM3";
                    break;
                case 3:
                    device.dport = "COM4";
                    break;
                case 4:
                    device.dport = "COM5";
                    break;
                case 5:
                    device.dport = "COM6";
                    break;
                case 6:
                    device.dport = "COM7";
                    break;
                case 7:
                    device.dport = "COM8";
                    break;
                case 8:
                    device.dport = "COM9";
                    break;


            }

            switch (cbxBoadRate.SelectedIndex)
            {
                case 0:
                    device.dbaud = 4800;
                    break;
                case 1:
                    device.dbaud = 9600;
                    break;
                case 2:
                    device.dbaud = 14400;
                    break;
                case 3:
                    device.dbaud = 19200;
                    break;
                case 4:
                    device.dbaud = 1152;
                    break;
            }
            switch (cbxData.SelectedIndex)
            {
                case 0:
                    device.ddata = 5;
                    break;
                case 1:
                    device.ddata = 6;
                    break;
                case 2:
                    device.ddata = 7;
                    break;
                case 3:
                    device.ddata = 8;
                    break;
            }
            switch (cbxStop.SelectedIndex)
            {
                case 0:
                    device.dstop = 1;
                    break;
                case 1:
                    device.dstop = 2;
                    break;
            }

            switch (cbxCheck.SelectedIndex)
            {
                case 0:
                    device.dcheck = "None";
                    break;
                case 1:
                    device.dcheck = "Odd";
                    break;
                case 2:
                    device.dcheck = "Even";
                    break;
                case 3:
                    device.dcheck = "Mark";
                    break;
                case 4:
                    device.dcheck = "Space";
                    break;
            }

            int flag = BAL.UpDataByName(device);
            if (flag > 0)
            {
                MessageBox.Show("添加成功");
            }
        }

        /// <summary>
        /// 网口删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btntcp_delete_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 网口保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btntcp_save_Click(object sender, EventArgs e)
        {

        }

        private void ilbcConnectList_SelectedIndexChanged(object sender, EventArgs e)
        {

            string dname = ilbcConnectList.SelectedItem.ToString().Trim();
            DeviceList device = new DeviceList();
            device = BAL.GetDeviceByName(dname);


            ////devicelist dl = new devicelist();
            ////string dname = ilbcconnectlist.selecteditem.tostring().trim();


            ////dl = bal.getdevicebyname(dname);
            if (device.dtype == "串口")
            {

                panelCom.Show();
                pTcp.Hide();
                setPanelCommInfo(device);

            }
            else
            {
                pTcp.Show();
                panelCom.Hide();

                setPanelTcpInfo(device);
            }
        }


        /// <summary>
        /// 新建通讯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_new_Click(object sender, EventArgs e)
        {
            wfAddCommunication wfc = new wfAddCommunication();
            wfc.Show();
        }


        /// <summary>
        /// tcp增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbtn_tcpSave_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// TCP删除label3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbtn_tcpDelete_Click(object sender, EventArgs e)
        {

            wfDeviceDelete wfd = new wfDeviceDelete(txtDeviceName.Text.Trim());
            wfd.Show();
        }


        private void SetHeadInfo(DeviceList device)
        {
            cbeConnectTCP.SelectedIndex = 0;

            txtUserNameTCP.Text = device.duname;
            label3.Text = device.did.ToString();
            label4IP.Text = device.dip;
            label5Port.Text = device.dport;


        }


        //更新指定列
        private void btn_SaveTCP_Click(object sender, EventArgs e)
        {
            DeviceList device = new DeviceList();
            device.did = Convert.ToInt16(label3.Text);
            device.duname = txtUserNameTCP.Text.ToString();
            device.dpwd = txtPWDTCP.Text;
            int isS = BAL.InsertDNameDPwd(device);
            if (isS > 0)
            {
                MessageBox.Show("插入成功！");
            }
        }


        /// <summary>
        /// 设备登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LoginTCP_Click(object sender, EventArgs e)
        {


            //第一次登陆

            if (m_lUserID == -1)
            {
                //设备登录IP
                string sDVRIP = label4IP.Text.Trim(); //txtIP.Text.Trim();
                                                      //设备端口
                Int32 wDVRPort = 8000;
                //用户名
                string sUserName = txtUserNameTCP.Text.Trim();//txtName.Text.Trim();
                                                              //登录密码
                string sPassword = txtPWDTCP.Text.Trim();//txtPWD.Text.Trim();
                                                         //设备登录  设置布防函数
                m_lUserID = new DeviceUtils().RegisterDevice(sDVRIP, wDVRPort, sUserName, sPassword);
                //设置回调函数
            }





            //第一次已经登陆第二次登陆
            if (m_lUserID != -1&&m_lUserID2==-1)//说明第一次登陆过了，第二次正在登陆
            {
                //设备登录IP
                string sDVRIP = label4IP.Text.Trim(); //txtIP.Text.Trim();
                                                      //设备端口
                Int32 wDVRPort = 8000;
                //用户名
                string sUserName = txtUserNameTCP.Text.Trim();//txtName.Text.Trim();
                                                              //登录密码
                string sPassword = txtPWDTCP.Text.Trim();//txtPWD.Text.Trim();
                                                         //设备登录  设置布防函数
                m_lUserID2 = new DeviceUtils().RegisterDevice(sDVRIP, wDVRPort, sUserName, sPassword);
                //设置回调函数

            }


        }


        /// <summary>
        /// WebApi 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string HttpGet(string url)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);   //请求


            request.Method = "GET";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";
            request.ReadWriteTimeout = 10000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        private void panelCom_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
