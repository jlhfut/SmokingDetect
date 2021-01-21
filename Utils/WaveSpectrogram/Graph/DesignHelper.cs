using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Wayee.WaveSpectrogram
{

    #region detect peak parameter class
    [Serializable]
    public class DetectPeakParameter
    {
        private float _minwidth = 5;
        /// <summary>
        /// 最小峰宽
        /// </summary>
        public float MinWidth
        {
            get { return _minwidth; }
            set { _minwidth = value; }
        }
        private float _minheight = 0;
        /// <summary>
        /// 最小峰高
        /// </summary>
        public float MinHeight
        {
            get { return _minheight; }
            set { _minheight = value; }
        }
        private float _minarea = 0;
        /// <summary>
        /// 最小峰面积
        /// </summary>
        public float MinArea
        {
            get { return _minarea; }
            set { _minarea = value; }
        }
        private int _checklevel = 500;
        /// <summary>
        /// 窗宽阀值
        /// </summary>
        public int CheckLevel
        {
            get { return _checklevel; }
            set { _checklevel = value; }
        }

        private float _startslope = 0.06f;
        /// <summary>
        /// 峰起点斜率
        /// </summary>
        public float StartSlope
        {
            get { return _startslope; }
            set { _startslope = value; }
        }

        private float _endslope = -0.02f;
        /// <summary>
        /// 峰终点斜率
        /// </summary>
        public float EndSlope
        {
            get { return _endslope; }
            set { _endslope = value; }
        }

        private double _timeSpan = 0.05;
        /// <summary>
        /// 数据间隔
        /// </summary>
        public double TimeSpan
        {
            get { return _timeSpan; }
            set { _timeSpan = value; }
        }

        private int _SG_Order = 3;
        /// <summary>
        /// SG滤波器阶数
        /// </summary>
        public int SG_Order
        {
            get { return _SG_Order; }
            set { _SG_Order = value; }
        }

        private int _SG_SideWindowLength = 20;
        /// <summary>
        /// SG滤波器半窗口宽度
        /// </summary>
        public int SG_SideWindowLength
        {
            get { return _SG_SideWindowLength; }
            set { _SG_SideWindowLength = value; }
        }

        /// <summary>
        /// 判峰参数序列化
        /// </summary>
        /// <param name="stream">序列化到流对象</param>
        /// <param name="format"></param>
        public void Serialize(ref MemoryStream stream)
        {
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(stream, this);
        }
        /// <summary>
        /// 峰表反序列化
        /// </summary>
        /// <param name="stream">从流对象反序列化</param>
        public void Deserialize(MemoryStream stream)
        {
            BinaryFormatter format = new BinaryFormatter();
            DetectPeakParameter dpp = (DetectPeakParameter)format.Deserialize(stream);
            this.MinArea = dpp.MinArea;
            this.MinWidth = dpp.MinWidth;
            this.MinHeight = dpp.MinHeight;
            this.CheckLevel = dpp.CheckLevel;
            this.StartSlope = dpp.StartSlope;
            this.EndSlope = dpp.EndSlope;
            this.TimeSpan = dpp.TimeSpan;
            this.SG_Order = dpp.SG_Order;
            this.SG_SideWindowLength = dpp.SG_SideWindowLength;
        }
    }
    #endregion

    #region Calculate parameter class
    /// <summary>
    /// 计算参数
    /// </summary>
    public class CalculateParameter
    {
        private int _degree = 1;
        /// <summary>
        /// 阶次
        /// </summary>
        public int Degree
        {
            get { return _degree; }
            set { _degree = value; }
        }
        private bool _zerepoint = false;
        /// <summary>
        /// 是否过零点
        /// </summary>
        public bool ZeroPoint
        {
            get { return _zerepoint; }
            set { _zerepoint = value; }
        }
        private bool _logarithm = false;
        /// <summary>
        /// 是否为对数
        /// </summary>
        public bool Logarithm
        {
            get { return _logarithm; }
            set { _logarithm = value; }
        }
        private float _timeprecision = 3;
        /// <summary>
        /// 保留时间精度
        /// </summary>
        public float TimePrecision
        {
            get { return _timeprecision; }
            set { _timeprecision = value; }
        }
    }
    #endregion

    #region baseline noise and drift
    public class BaseLineInfo   
    {
        private double _baselinenoise = 0.0;
        /// <summary>
        /// 基线噪声
        /// </summary>
        public double BaseLineNoise
        {
            get { return _baselinenoise; }
            set { _baselinenoise = value; }
        }
        private double _baselinedrift = 0.0;
        /// <summary>
        /// 基线漂移
        /// </summary>
        public double BaseLineDrift
        {
            get { return _baselinedrift; }
            set { _baselinedrift = value; }
        }
    }
    #endregion

    #region draw interface
    public interface IDrawImage
    {
        void DrawImage(Graphics g,PointF pt);
    }
    #endregion

    #region mouse hook
    /// <summary>
    /// MouseHook
    /// </summary>
    public class MouseHook
    {
        #region define
        private const int WH_MOUSE_LL = 14;
        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_MOUSEHWHEEL = 0x020E,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private LowLevelMouseProc _proc;
        private MouseWheelEventHandle _mousewheel;
        private IntPtr _hookID = IntPtr.Zero;
        #endregion

        #region define event
        public delegate void MouseWheelEventHandle(MouseEventArgs e);
        #endregion

        #region public function
        public IntPtr LoadHook(MouseWheelEventHandle proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                _proc = HookCallback;
                _mousewheel = proc;
                _hookID = SetWindowsHookEx(WH_MOUSE_LL, _proc, GetModuleHandle(curModule.ModuleName), 0);
                return _hookID;
            }
        }
        public bool UnLoadHook()
        {
            if (_hookID != IntPtr.Zero) return UnhookWindowsHookEx(_hookID);
            return false;
        }
        #endregion

        #region private function
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            IntPtr rs = CallNextHookEx(_hookID, nCode, wParam, lParam);
            if (nCode >= 0 && (MouseMessages.WM_MOUSEWHEEL == (MouseMessages)wParam || MouseMessages.WM_MOUSEHWHEEL == (MouseMessages)wParam))
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                Point pt = new Point(hookStruct.pt.x, hookStruct.pt.y);
                if (_mousewheel != null)
                {
                    MouseEventArgs args = new MouseEventArgs(MouseButtons.Middle, 0, pt.X, pt.Y, (int)hookStruct.mouseData >> 16);
                    _mousewheel(args);
                }
            }
            return rs;
        }
        #endregion
    }
    #endregion

    //#region SerializePropertyAttribute
    ///// <summary>
    /////Attribute of control whether to show in the propertygrid.
    ///// </summary>
    //[AttributeUsage(AttributeTargets.Property)]
    //public class SerializePropertyAttribute : Attribute
    //{
    //}
    //#endregion

    #region log
    /// <summary>
    /// Log Helper.
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// write exception in log.
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteError(Exception ex)
        {
            WriteError(ex.Message+"\r"+ex.StackTrace.ToString());
        }

        /// <summary>
        /// write error in log.
        /// </summary>
        /// <param name="err"></param>
        public static void WriteError(string err)
        {
            //MessageBox.Show(err);
            return;
        }
    }
    #endregion

    #region 谱图数据单位
    /// <summary>
    /// 数据单位说明
    /// </summary>
    public class DataUnitDescription
    {
        private const string c_Name = "DataUnitDescription";
        private string _DataUnit = "";
        /// <summary>
        /// 数据单位
        /// </summary>
        //[SerializePropertyAttribute]
        public string DataUnit
        {
            get { return _DataUnit; }
            set { _DataUnit = value; }
        }

        private string _ViewUnit = "";
        /// <summary>
        /// 查看单位
        /// </summary>
        //[SerializePropertyAttribute]
        public string ViewUnit
        {
            get { return _ViewUnit; }
            set { _ViewUnit = value; }
        }

        private int _Multiple = 0;
        /// <summary>
        /// 查看倍数
        /// </summary>
        //[SerializePropertyAttribute]
        public int Multiple
        {
            get { return _Multiple; }
            set { _Multiple = value; }
        }
        private int _DataMultiple = 1;
        /// <summary>
        /// 与数据最小单位之间倍数
        /// </summary>
        //[SerializePropertyAttribute]
        public int DataMultiple
        {
            get { return _DataMultiple; }
            set { _DataMultiple = value; }
        }
        private string _Description = "";
        /// <summary>
        /// 数据描述
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public override bool Equals(object obj)
        {
            if(!(obj is DataUnitDescription)) return false;
            bool rs = ((obj as DataUnitDescription).ViewUnit == ViewUnit);
            rs &= ((obj as DataUnitDescription).Multiple == Multiple);
            rs &= ((obj as DataUnitDescription).DataUnit == DataUnit);
            rs &= ((obj as DataUnitDescription).Description == Description);
            return rs;
        }

        /// <summary "序列化">
        /// 给定的object对象进行序列化为字符串
        /// </summary>
        /// <param name="obj"> 序列化的目标源</param>
        /// <returns>序列化过的字符串</returns>
        public static string Serialize(DataUnitDescription dud)
        {
            if (dud == null) return "";
            string rs = c_Name;
            string value = "";
            System.Reflection.PropertyInfo[] pinfs = dud.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo pinf in pinfs)
            {
                //if (pinf.Attributes.ToString() != "SerializePropertyAttribute") continue;
                value = pinf.GetValue(dud, null).ToString();
                value = value.Replace("=", "");
                value = value.Replace("\r", "");
                rs += "\r" + pinf.Name + "=" + value;
            }
            return rs;
        }
        /// <summary"反序列化">
        /// 给定的序列化的字符串进行反序列化为object对象
        /// </summary>
        /// <param name="val">序列化过的字符串</param>
        /// <returns>返回的反序列化的对象</returns>
        public static DataUnitDescription Deserialize(string val)
        {
            try
            {
                if (!val.StartsWith(c_Name)) return null;
                string rs = val.Substring(c_Name.Length, val.Length - c_Name.Length);
                string[] pinfs = rs.Split(new string[] { "\r" }, StringSplitOptions.RemoveEmptyEntries);
                if (pinfs == null || pinfs.GetLength(0) == 0) return null;
                string[] values = null;
                DataUnitDescription dud = new DataUnitDescription();
                System.Reflection.PropertyInfo pinf = null;
                object vs = null;
                foreach (string prop in pinfs)
                {
                    if (prop == null) continue;
                    values = prop.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    if (values == null || values.GetLength(0) != 2) continue;
                    pinf = dud.GetType().GetProperty(values[0]);
                    if (pinf == null) continue;
                    vs = Convert.ChangeType(values[1], pinf.PropertyType);
                    pinf.SetValue(dud, vs, null);
                }
                return dud;
            }
            catch
            {
                return null;
            }
        }
    }
    #endregion

    #region 模板自动操作参数
    public class TemplateOperateArgs
    {
        private bool _LoadDetectParam = false;
        /// <summary>
        /// 是否加载判峰参数
        /// </summary>
        public bool LoadDetectParam
        {
            get { return _LoadDetectParam; }
            set { _LoadDetectParam = value; }
        }
        private int _TimeBand = 10;
        /// <summary>
        /// 时间带
        /// </summary>
        public int TimeBand
        {
            get { return _TimeBand; }
            set { _TimeBand = value; }
        }


        public static TemplateOperateArgs Empty
        {
            get { return new TemplateOperateArgs(); }
        }
    }
    #endregion

    #region Global functions.


    /// <summary>
    /// Global functions.
    /// </summary>
    public class GlobalFunction
    {
        private const uint PM_NOREMOVE = 0;
        private const uint PM_REMOVE = 1;
        private const uint PM_NOYIELD = 2;
        struct MSG  //structure MSG
        {
            public IntPtr handle;
            public uint msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }
        [DllImport("user32", EntryPoint = "PeekMessage")]
        private static extern bool PeekMessageA(ref MSG lpMsg, IntPtr hwnd, int wMsgFilterMin, int wMsgFilterMax, uint wRemoveMsg);
        [DllImport("user32")]
        private static extern int TranslateMessage(ref MSG lpMsg);
        [DllImport("user32", EntryPoint = "DispatchMessage")]
        private static extern int DispatchMessageA(ref MSG lpMsg);

        private static bool _busy = false;
        /// <summary>
        /// doevents.
        /// </summary>
        public static void DoEvents()
        {
            if (_busy) return;
            _busy = true;
            try
            {
                MSG msg = new MSG();
                int count = 0;
                while (PeekMessageA(ref msg, IntPtr.Zero, 0, 0, PM_REMOVE))
                {
                    TranslateMessage(ref msg);
                    DispatchMessageA(ref msg);
                    count++;
                    if (count > 50) break;
                }
            }
            finally
            {
                _busy = false;
            }
        }
    }
    #endregion
}
