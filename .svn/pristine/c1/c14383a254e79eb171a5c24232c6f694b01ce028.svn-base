using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wayeal.Services.Business.Utils
{
    /// <summary>
    /// LED 即时表演节目
    /// </summary>
    public class LedAct
    {
        /// <summary>
        /// 数据长度
        /// </summary>
        private UInt16 _Length = 0;
        /// <summary>
        /// 数据长度
        /// </summary>
        public UInt16 Length
        {
            get { return _Length; }
            set { _Length = value; }
        }
        /// <summary>
        /// 版本号
        /// </summary>
        private UInt16 _Version = 0;
        /// <summary>
        /// 版本号
        /// </summary>
        public UInt16 Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        /// <summary>
        /// 节目编号
        /// </summary>
        private UInt16 _ProgramID = 01;
        /// <summary>
        /// 节目编号
        /// </summary>
        public UInt16 ProgramID
        {
            get { return _ProgramID; }
            set { _ProgramID = value; }
        }

        /// <summary>
        /// 播放类型（0次/1时长)
        /// </summary>
        private byte _PlayType = 0;
        /// <summary>
        /// 播放类型（0次/1时长)
        /// </summary>
        public byte PlayType
        {
            get { return _PlayType; }
            set { _PlayType = value; }
        }

        /// <summary>
        /// 播放次数/时间
        /// </summary>
        private byte _PlayTimes = 1;
        /// <summary>
        /// 播放次数/时间
        /// </summary>
        public byte PlayTimes
        {
            get { return _PlayTimes; }
            set { _PlayTimes = value; }
        }

        /// <summary>
        /// 同步语音输出
        /// </summary>
        private byte _HaveOut = 0;
        /// <summary>
        /// 同步语音输出
        /// </summary>
        public byte HaveOut
        {
            get { return _HaveOut; }
            set { _HaveOut = value; }
        }

        /// <summary>
        /// 固定分区号
        /// </summary>
        private byte _AreaID = 0;
        /// <summary>
        /// 固定分区号
        /// </summary>
        public byte AreaID
        {
            get { return _AreaID; }
            set { _AreaID = value; }
        }

        /// <summary>
        /// 总分区数 默认分区最多3个分区
        /// </summary>
        private byte _AreaCount = 0;
        /// <summary>
        /// 总分区数 默认分区最多3个分区
        /// </summary>
        public byte AreaCount
        {
            get { return _AreaCount; }
            set { _AreaCount = value; }
        }

        /// <summary>
        /// 区域列表
        /// </summary>
        private List<AreaInfo> _AreaList = new List<AreaInfo>();

        public List<AreaInfo> AreaList
        {
            get { return _AreaList; }
            set { _AreaList = value; }
        }

        /// <summary>
        /// 分隔符
        /// </summary>
        private byte SplitInterval = 0x0E;

        /// <summary>
        /// 节目名称
        /// </summary>
        private String _ActName = "prog001";

        public String ActName
        {
            get { return _ActName; }
            set { _ActName = value; }
        }

        public LedAct()
        { 
        }

        /// <summary>
        /// 默认分区
        /// </summary>
        private void DefaultArea()
        {
            this.AreaList.Clear();
            AreaInfo ai = new AreaInfo();
            ai.ID = 0;
            ai.Left = 0;
            ai.Top = 0;
            ai.Width = 64;
            ai.High = 16;
            ai.FontType = 1;
            ai.FontColor = 0;
            ai.InType = 1;
            ai.InSpeed = 0xff;
            ai.StayTime = 10;
            ai.ShowContent = "皖仪科技";
            this.AreaList.Add(ai);

            AreaInfo ai2 = new AreaInfo();
            ai2.ID = 1;
            ai2.Left = 0;
            ai2.Top = 16;
            ai2.Width = 64;
            ai2.High = 16;
            ai2.FontType = 1;
            ai2.FontColor = 1;
            ai2.InType = 2;
            ai2.InSpeed = 0x3c;
            ai2.StayTime = 10;
            ai2.ShowContent = "正在监测";
            this.AreaList.Add(ai2);
        }

        /// <summary>
        /// 转化成字节数组
        /// </summary>
        /// <returns></returns>
        public byte[] ToArray()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(_Version));
            data.AddRange(BitConverter.GetBytes(_ProgramID));
            data.Add(_PlayType);
            data.Add(_PlayTimes);
            data.Add(_HaveOut);
            data.Add(_AreaID);
            _AreaCount = (byte)_AreaList.Count;
            data.Add(AreaCount);
            for (int i = 0; i < _AreaCount; i++)
            {
                data.AddRange(_AreaList[i].ToArray());
            }
            //data.Add(SplitInterval);
            var cntArray = System.Text.Encoding.Unicode.GetBytes(_ActName);
            data.AddRange(cntArray);
            _Length = (UInt16)data.Count;
            data.InsertRange(0, BitConverter.GetBytes(_Length));
            return data.ToArray();
        }
    }
    /// <summary>
    /// 分区类型
    /// </summary>
    public enum AreaType
    {
        /// <summary>
        /// 文本分区
        /// </summary>
        Text,
        /// <summary>
        /// 图片分区
        /// </summary>
        Picture,
        /// <summary>
        /// 时间分区
        /// </summary>
        Time
    }
    /// <summary>
    /// 分区信息
    /// </summary>
    public class AreaInfo
    {

        /// <summary>
        /// 分区ID
        /// </summary>
        private byte _ID = 0;
        /// <summary>
        /// 分区ID
        /// </summary>
        public byte ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        /// <summary>
        /// 内容长度
        /// </summary>
        private UInt16 _Length = 0;
        /// <summary>
        ///  内容长度
        /// </summary>
        public UInt16 Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        /// <summary>
        /// 左边位置
        /// </summary>
        private UInt16 _Left = 0;
        /// <summary>
        /// 左边位置
        /// </summary>
        public UInt16 Left
        {
            get { return _Left; }
            set { _Left = value; }
        }

        /// <summary>
        /// 高度
        /// </summary>
        private UInt16 _Top = 0;
        /// <summary>
        /// 高度
        /// </summary>
        public UInt16 Top
        {
            get { return _Top; }
            set { _Top = value; }
        }

        /// <summary>
        /// 左边位置
        /// </summary>
        private UInt16 _Width = 0;

        /// <summary>
        /// 左边位置
        /// </summary>
        public UInt16 Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        /// <summary>
        /// 高度
        /// </summary>
        private UInt16 _High = 0;

        /// <summary>
        /// 高度
        /// </summary>
        public UInt16 High
        {
            get { return _High; }
            set { _High = value; }
        }

        /// <summary>
        /// 分区类型   0 文本类型
        /// </summary>
        private byte _ActType = 0;

        /// <summary>
        /// 分区类型   0：表明是文本分区。
        ///1：表明是图片分区 
        ///2：GIF（目前不支持） 
        ///3：表盘时钟（目前不支持）
        ///4：数字时间 
        ///5：倒计时 
        ///6 ：基础图形（交通引导、表格等应用） 
        ///7：预存图片格式
        /// </summary>
        public byte ActType
        {
            get { return _ActType; }
            set { _ActType = value; }
        }

        /// <summary>
        /// 分页号
        /// </summary>
        private UInt16 _PageIndex = 0;
        /// <summary>
        /// 分页号
        /// </summary>
        public UInt16 PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }

        /// <summary>
        /// 字体类型   1字节  0或 1=16，2-=24，3=32
        /// </summary>
        private byte _FontType = 1;

        /// <summary>
        /// 字体类型   1字节  0或 1=16，2-=24，3=32
        /// </summary>
        public byte FontType
        {
            get { return _FontType; }
            set { _FontType = value; }
        }

        /// <summary>
        /// 字体颜色   1字节  0=红色 1=绿色 2=黄色
        /// </summary>
        private byte _FontColor = 0;
        /// <summary>
        /// 字体颜色   1字节  0=红色 1=绿色 2=黄色
        /// </summary>
        public byte FontColor
        {
            get { return _FontColor; }
            set { _FontColor = value; }
        }

        /// <summary>
        /// 进入方式
        /// </summary>
        private byte _InType = 0;
        /// <summary>
        /// 进入方式
        /// </summary>
        public byte InType
        {
            get { return _InType; }
            set { _InType = value; }
        }

        /// <summary>
        /// 进入速度
        /// </summary>
        private byte _InSpeed = 0;
        /// <summary>
        /// 进入速度
        /// </summary>
        public byte InSpeed
        {
            get { return _InSpeed; }
            set { _InSpeed = value; }
        }

        /// <summary>
        /// 退出方式 0
        /// </summary>
        private byte _OutType = 0;
        /// <summary>
        /// 退出方式 0
        /// </summary>
        public byte OutType
        {
            get { return _OutType; }
            set { _OutType = value; }
        }

        /// <summary>
        /// 退出速度
        /// </summary>
        private byte _OutSpeed = 0;
        /// <summary>
        /// 退出速度
        /// </summary>
        public byte OutSpeed
        {
            get { return _OutSpeed; }
            set { _OutSpeed = value; }
        }

        /// <summary>
        /// 停留时间, FF为一直显示
        /// </summary>
        private byte _StayTime = 0;
        /// <summary>
        /// 停留时间, FF为一直显示
        /// </summary>
        public byte StayTime
        {
            get { return _StayTime; }
            set { _StayTime = value; }
        }

        /// <summary>
        /// 显示内容
        /// </summary>
        private string _ShowContent = "";
        /// <summary>
        /// 显示内容
        /// </summary>
        public string ShowContent
        {
            get { return _ShowContent; }
            set { _ShowContent = value; }
        }

        /// <summary>
        /// 转化成字节数组
        /// </summary>
        /// <returns></returns>
        public byte[] ToArray()
        {
            List<byte> data = new List<byte>();
            var cntArray = System.Text.Encoding.Unicode.GetBytes(_ShowContent);
            _Length = (UInt16)cntArray.Length;
            //ID 和长度后面加
            data.Add(ID);
            data.AddRange(BitConverter.GetBytes(_Length));
            data.AddRange(BitConverter.GetBytes(_Left));
            data.AddRange(BitConverter.GetBytes(_Top));
            data.AddRange(BitConverter.GetBytes(_Width));
            data.AddRange(BitConverter.GetBytes(_High));
            data.Add(_ActType);
            data.AddRange(BitConverter.GetBytes(_PageIndex));
            data.Add(_FontType);
            data.Add(_FontColor);

            data.Add(_InType);
            data.Add(_InSpeed);
            data.Add(_OutType);
            data.Add(_OutSpeed);
            data.Add(_StayTime);    
            data.AddRange(cntArray);
       
            return data.ToArray();
        }
    }
}
