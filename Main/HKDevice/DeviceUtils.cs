using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wayeal.os.exhaust.HKDevice
{
   public class DeviceUtils
    {
        /// 1.初始化SDK
        /// 2.设置回调函数
        /// 3.用户注册
        /// 4.配置报警条件
        /// 5.报警布防
        /// 6.报警函数里面接收和处理数据
        /// 7.报警撤防
        /// 8.注销用户
        /// 9.释放SDK资源
        /// 
        /// 
        /// 

        //设备注册-用户登录  

        ///

        /// <summary>
        /// 设备注册-用户登录 
        /// </summary>
        /// <param name="sDVRIP">登录IP</param>
        /// <param name="wDVRPort">端口</param>
        /// <param name="sUserName">用户名</param>
        /// <param name="sPassword">密码</param>
        /// <returns>返回值小于0登录注册失败</returns>
        public int RegisterDevice(string sDVRIP, Int32 wDVRPort, string sUserName, string sPassword)
        {
            //设备信息输出参数
            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();




            int m_lUserID = CHCNetSDK.NET_DVR_Login_V30(sDVRIP, wDVRPort, sUserName, sPassword, ref DeviceInfo);

            if (m_lUserID < 0)
            {
                MessageBox.Show("登陆失败");
                return -1;
            }




            //4.5.启用布防设置布防条件
            CHCNetSDK.NET_DVR_SETUPALARM_PARAM structSetUpParam = new CHCNetSDK.NET_DVR_SETUPALARM_PARAM();
            structSetUpParam.dwSize = (uint)Marshal.SizeOf(structSetUpParam);
            structSetUpParam.byLevel = 1;//布防优先级：0-一级（高） ，1- 二等级（中）
            structSetUpParam.byAlarmInfoType = 1;//上传报警信息类型 1- 新报警信息(NET_ITS_PLATE_RESULT)

            int lhandle = CHCNetSDK.NET_DVR_SetupAlarmChan_V41(m_lUserID, ref structSetUpParam);
            if (lhandle < 0)
            {
                MessageBox.Show("布防失败");
                return -1;
            }
            return m_lUserID;//返回用户登陆成功句柄

        }


        /// <summary>
        /// 预览窗口
        /// </summary>
        /// <param name="m_lUserID">登录成功后返回的句柄</param>
        /// <param name="picLive">picture box</param>
        /// <returns>窗口句柄  m_RealHandle</returns>

        public int display(int m_lUserID ,PictureBox picLive )
        {
            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            lpPreviewInfo.hPlayWnd = picLive.Handle;//预览窗口
            lpPreviewInfo.lChannel = Int16.Parse("1");//预te览的设备通道
            lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            lpPreviewInfo.dwDisplayBufNum = 15; //播放库播放缓冲区最大缓冲帧数

            CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
            IntPtr pUser = new IntPtr();//用户数据

            //打开预览 Start live view 
          int  m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);

            if (m_lRealHandle < 0)
            {
                MessageBox.Show("预览失败");
                return -1;
            }
            return m_lRealHandle;
        }

        private void RealDataCallBack(int lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr pUser)
        {
            throw new NotImplementedException();
        }
    }
    
    }

