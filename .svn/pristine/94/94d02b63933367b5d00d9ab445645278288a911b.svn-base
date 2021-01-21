using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Wayee.FileParameter
{
    #region struct
    [Serializable]
    public struct SavedParam
    {
        /// <summary>
        /// 是否为空
        /// </summary>
        public bool Empty;
        /// <summary>
        /// 时间精度
        /// </summary>
        public string TimePrecision;
        /// <summary>
        /// 阶次
        /// </summary>
        public string Degree;
        /// <summary>
        /// 是否过零点
        /// </summary>
        public bool ZeroPoint;
        /// <summary>
        /// 是否对数
        /// </summary>
        public bool Log;
        /// <summary>
        /// 定量方法
        /// </summary>
        public int QualitativeMethod;
        /// <summary>
        /// 计算方法
        /// </summary>
        public int QualitativeThereunder;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="empty"></param>
        public SavedParam(bool empty)
        {
            Empty = empty;
            TimePrecision = "";
            Degree = "";
            ZeroPoint = false;
            Log = false;
            QualitativeMethod = 0;
            QualitativeThereunder = 0;
        }
    }
    #endregion

    #region class
    /// <summary>
    /// template operator
    /// </summary>
    public class SavedParamOperator
    {
        #region defineds
        private const string c_paramname = "_param";
        private const string c_samplename = "_sample";
        private const string c_pressurename = "_pressure";
        private const string c_stddirname = "stdsample";
        #endregion

        #region properties
        /// <summary>
        /// config file name
        /// </summary>
        public static string ConfigName
        {
            get { return c_paramname; }
        }
        /// <summary>
        /// sample file name
        /// </summary>
        public static string SampleName
        {
            get { return c_samplename; }
        }
        /// <summary>
        /// pressure file name
        /// </summary>
        public static string PressureName
        {
            get { return c_pressurename; }
        }
        /// <summary>
        /// standard sample direction name
        /// </summary>
        public static string StdSampleDirName
        {
            get { return c_stddirname; }
        }
        #endregion

        #region public functions
        /// <summary>
        /// save template file
        /// </summary>
        /// <returns></returns>
        public static bool SaveParam(string fn, SavedParam tp)
        {
            try
            {
                return DoSave(fn, tp);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// load template file
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="path"></param>
        public static SavedParam OpenParam(string fn)
        {
            try
            {
                //BinaryFormatter ser = new BinaryFormatter();
                //Stream file = new FileStream(fn, FileMode.Open, FileAccess.Read, FileShare.Read);
                //SavedParam tp = ((SavedParam)(ser.Deserialize(file)));
                //file.Close();
                //return tp;
                return (SavedParam)DoOpen(fn);
            }
            catch
            {
                return new SavedParam(true);
            }
        }
        /// <summary>
        /// save pressure values
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
        public static bool SavePressure(string fn,string value)
        {
            try
            {
                return DoSave(fn, value);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// open pressure values
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
        public static string OpenPressure(string fn)
        {
            try
            {
                return (string)DoOpen(fn);
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region private function
        /// <summary>
        /// save
        /// </summary>
        /// <param name="fn"></param>
        /// <param name="tp"></param>
        /// <returns></returns>
        private static bool DoSave(string fn, object tp)
        {
            BinaryFormatter ser = new BinaryFormatter();
            Stream file = new FileStream(fn, FileMode.Create);
            ser.Serialize(file, tp);
            file.Close();
            return true;
        }
        /// <summary>
        /// open
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private static object DoOpen(string fn)
        {
            BinaryFormatter ser = new BinaryFormatter();
            Stream file = new FileStream(fn, FileMode.Open, FileAccess.Read, FileShare.Read);
            object tp = ((object)(ser.Deserialize(file)));
            file.Close();
            return tp;
        }
        #endregion
    }
    #endregion
}
