using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using SG_Coefficients;

namespace Wayee.Filter.SG
{
    /// <summary>
    /// SGCoefficientsManager
    /// </summary>
    public class SGCoefficientsManager
    {
        /// <summary "序列化">
        /// 给定的object对象进行序列化为字符串
        /// </summary>
        /// <param name="obj"> 序列化的目标源</param>
        /// <returns>序列化过的字符串</returns>
        static string SerialObject(object obj)//序列化到字符串
        {
            byte[] buf;
            MemoryStream sb = new MemoryStream();
            BinaryFormatter ser = new BinaryFormatter();
            ser.Serialize(sb, obj);
            buf = sb.GetBuffer();
            return Convert.ToBase64String(buf);
        }
        /// <summary"反序列化">
        /// 给定的序列化的字符串进行反序列化为object对象
        /// </summary>
        /// <param name="val">序列化过的字符串</param>
        /// <returns>返回的反序列化的对象</returns>
        static object DSerialObject(string val)//反序列化到object
        {
            byte[] V = Convert.FromBase64String(val);
            MemoryStream sb = new MemoryStream();
            BinaryFormatter ser = new BinaryFormatter();
            sb = new MemoryStream(V);
            return ser.Deserialize(sb);

        }
        /// <summary>
        /// 得到SG滤波器卷积系数
        /// 数据格式：key -- Integers Coefficients
        /// key: order_sidPoint （sidPoint = 数据窗口长度/2）(3阶数据窗口长度15的key是：3_7)
        /// Integers Coefficients：类型为 double[] 数组长度为 sidPoint*2+1
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, double[,]> GetSGCoefficients()
        {
            return DSerialObject(CoefficientsResx.SGCoefficients) as Dictionary <string,double [,]>;
        }
    }
}
