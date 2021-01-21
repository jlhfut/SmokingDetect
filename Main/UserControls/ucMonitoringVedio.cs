using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.ViewModel;
using Wayee.Services;
using Newtonsoft.Json.Linq;
using System.Threading;
using wayeal.os.exhaust.Services;
using System.Runtime.InteropServices;
using DevExpress.Utils.MVVM;
using System.IO;
using DevExpress.XtraBars.Ribbon;
using DevExpress.Mvvm;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucMonitoringVedio : ucBase
    {
        string CameraName = "LicenseRecog";
        string TIPS_QueryConfigParam = "正在查询配置参数...";
        string TIPS_DeviceListIsNull= "加载失败，设备列表为空";
        string TIPS_CommInfoIsNull = "加载失败，未配置通讯端口";
        string TIPS_Error = "加载失败";
        string TIPS_InitSDKErr = "初始化SDK失败";
        string TIPS_LoginErr = "登录失败，错误代码：";
        string TIPS_OpenRealDataErr = "打开预览失败, 错误代码：";

        private GalleryItemGroup _GalleryItemGroup = new GalleryItemGroup();
        private GalleryItem _nearPicture = new GalleryItem(null, "near", "");


        string UserName, PassWord, IpAddress;
        int Port, userID=-1, preHandle=-1;
        public ucMonitoringVedio()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
            sbPlay.Enabled = true;
            sbStop.Enabled = false;
        }
        #region Preview

        protected override void InitializeBindings()
        {
            ResultDataViewModel.VM.ModelChanged += (sender, arg) =>
            {
                if (arg.ModelName == "CloseAPP") StopRealView();
            };
            base.InitializeBindings();
        }

        //private void ucMonitoringVedio_Load(object sender, EventArgs e)
        //{
        //    Thread LoadCameraThread = new Thread(AsyncLoading);
        //    LoadCameraThread.Start();
        //}
        //private void AsyncLoading()
        //{
        //    Action loadRealDataDele = new Action(LoadRealData);
        //    this.BeginInvoke(loadRealDataDele);
        //}
        /// <summary>
        /// 加载实时数据
        /// 1、查询相机的ip，端口号，用户名和密码
        /// 2、相机SDK初始化、登录
        /// 3、开启预览
        /// </summary>
        private void LoadRealData()
        {
           
         //   lcVedioTips.Text = TIPS_QueryConfigParam;
            if (LoadCameraParam())
            {
                InitCameraSDK();
            }
        }

        private void sbPlay_Click(object sender, EventArgs e)
        {
            if(userID<0) LoadRealData();
            if (preHandle < 0) InitPlay();
            if (preHandle >= 0)
            {
                sbPlay.Enabled = false;
                sbStop.Enabled = true;
            }
        }

        /// <summary>
        /// 初始化相机SDK
        /// </summary>
        private void InitCameraSDK()
        {
            //初始化SDK
            if (!CHCNetSDK.NET_DVR_Init())
            {
                ErrorLog.Error(TIPS_InitSDKErr);
            }
            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

            //登录设备 Login the device
            userID = CHCNetSDK.NET_DVR_Login_V30(IpAddress, Port, UserName, PassWord, ref DeviceInfo);
            if (userID < 0)
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                ErrorLog.Error( TIPS_LoginErr + iLastErr); //登录失败，输出错误号
                return;
            }
            else
            {
         //       lcVedioTips.Visible = false;
            }
            //准备预览参数
            InitPlay();
        }

        private void sbStop_Click(object sender, EventArgs e)
        {
            //停止预览
            if (preHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopRealPlay(preHandle);
                preHandle = -1;
            }
            sbStop.Enabled = false;
            sbPlay.Enabled = true;
        }

        private void InitPlay()
        {
            //准备预览参数
            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            lpPreviewInfo.hPlayWnd = pbVedio.Handle;//预览窗口
            lpPreviewInfo.lChannel = 1;//预览的设备通道
            lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            lpPreviewInfo.byProtoType = 0;
            lpPreviewInfo.byPreviewMode = 0;


            IntPtr pUser = new IntPtr();//用户数据

            //打开预览 Start live view 
            preHandle = CHCNetSDK.NET_DVR_RealPlay_V40(userID, ref lpPreviewInfo, null/*RealData*/, pUser);
            if (preHandle < 0)
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
               ErrorLog.Error( TIPS_OpenRealDataErr + iLastErr); //预览失败，输出错误号
                return;
            }
        }
        
        /// <summary>
        /// 查询相机 ip，用户名，密码，端口号
        /// </summary>
        /// <returns></returns>
        private bool LoadCameraParam()
        {
            List<object> lsDevice = ResultDataViewModel.VM.Devices;
            if (lsDevice == null || lsDevice.Count < 1)
            {
                ErrorLog.Error(TIPS_DeviceListIsNull);
                return false;
            }
            for (int i = 0; i < lsDevice.Count; i++)
            {
                if (lsDevice[i] is DTDeviceInfo)
                {
                    try
                    {
                        DTDeviceInfo dt = lsDevice[i] as DTDeviceInfo;
                        if (dt.Name.Value.ToString().Trim() == CameraName)
                        {
                            string param = dt.Param.Value.ToString();
                            JObject dp = JsonNewtonsoft.FromJSON(param) as JObject;
                            JToken jt;
                            dp.TryGetValue("userName", out jt);
                            UserName = jt.ToString();
                            dp.TryGetValue("Password", out jt);
                            PassWord = jt.ToString();
                            string CommInfo = dt.Commuunication.Value.ToString();
                            if (String.IsNullOrEmpty(CommInfo))
                            {
                                ErrorLog.Error(TIPS_CommInfoIsNull);
                                return false;
                            }
                            ResultDataViewModel.VM.Execute(new List<object> {
                                ResultDataViewModel.ExecuteCommand.ec_QueryCommunicationInfo,
                                CommInfo
                            });
                            if (ResultDataViewModel.VM.QueryComSingleEntities == null || ResultDataViewModel.VM.QueryComSingleEntities.Count < 1)
                            {
                                ErrorLog.Error(TIPS_CommInfoIsNull);
                                //          lcVedioTips.Text = ;
                                return false;
                            }
                            DTCommunicationInfo dtCom = ResultDataViewModel.VM.QueryComSingleEntities[0] as DTCommunicationInfo;
                            IpAddress = dtCom.IP.Value.ToString().Trim();
                            Port = Convert.ToInt32(dtCom.PortNumberTCP.Value.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.Error(ex.ToString());
                        //      lcVedioTips.Text = TIPS_Error;
                        return false;
                    }
                }
                
            }
            return true;
        }
        #endregion
     
        private MVVMContextFluentAPI<RealtimeMonitorViewModel> fluent;

        public void StopRealView()
        {
            //停止预览
            if (preHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopRealPlay(preHandle);
                preHandle = -1;
            }

            //注销登录
            if (userID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(userID);
                userID = -1;
            }

            CHCNetSDK.NET_DVR_Cleanup();
        }
    }
}
