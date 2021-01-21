using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static wayeal.os.exhaust.Services.CHCNetSDK;

namespace wayeal.os.exhaust.Services
{
    public class HKDVRServiceHelper
    {
        public string DVRUserName;
        public string DVRPassword;
        public string DVRIP;
        public int DVRPort;
        CHCNetSDK.SETREALDATACALLBACK realDataCallBackEvent = null;
        /// <summary>
        /// 启用实时预览
        /// </summary>
        public void SDKRealPlay()
        {
            //登录
            int m_UserID = DVRLogin(DVRIP,DVRPort,DVRUserName,DVRPassword);
            //实时预览
            CHCNetSDK.NET_DVR_CLIENTINFO clientInfo = new CHCNetSDK.NET_DVR_CLIENTINFO();
            clientInfo.lChannel = 1;
            clientInfo.lLinkMode = 0;
            int iRealPlayHandle= CHCNetSDK.NET_DVR_RealPlay_V30(m_UserID,ref clientInfo,null,IntPtr.Zero,0);
            //注册回调函数
          //  if(realDataCallBackEvent==null)  realDataCallBackEvent = new SETREALDATACALLBACK(iRealPlayHandle,2,);
        }


        /// <summary>
        /// DVR用户登录
        /// </summary>
        /// <param name="DVRIPAddress">设备IP地址或者域名 Device IP</param>
        /// <param name="DVRPortNumber">设备服务端口号 Device Port</param>
        /// <param name="DVRUserName">设备登录用户名 User name to login</param>
        /// <param name="DVRPassword">设备登录密码 Password to login</param>
        /// <returns>登录成功则返回用户id（int），失败则返回-1</returns>
        private int DVRLogin(string DVRIPAddress, int DVRPortNumber, string DVRUserName, string DVRPassword)
        {
            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
            int m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
            return m_lUserID;
        }
    }
}
