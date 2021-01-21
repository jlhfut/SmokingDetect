//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: StaticMethods.cs
// 日期：2011/04/07
// 描述：定义手动处理算法需要的公共算法：基线匹配、序列化和反序列化
// 版本：1.00
// 修改历史纪录
// 版本         修改时间         修改人           修改内容
// 
//==============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using LocalPeakObject = Wayee.PeakObject.Peak;//给峰对象类型起个别名

namespace Wayee.ManualProcessor
{
    /// <summary>
    /// 手动处理算法需要的公共算法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StaticMethods
    {
        /// <summary "基线匹配">
        /// 基线匹配算法：按照IsForWard标志进行前向或者后向匹配峰对象的起止点和基线的起止点是否匹配
        /// </summary>
        /// <param name="PeakList">峰对象列表</param>
        /// <param name="PeakNum">目标峰索引</param>
        /// <param name="IsForWard">前后向标志：True 前向；False 后向</param>
        /// <returns></returns>
        public static int MatchBaseLine(List<LocalPeakObject> PeakList, int PeakNum, bool IsForWard)
        {
            int _resultindex = -1;

            if (IsForWard)
            {
                for (int i = PeakNum-1; i >= 0; i--)
                {
                    LocalPeakObject midpeakobj = PeakList[i] as LocalPeakObject;

                    if (midpeakobj.EndPoint.Equals(midpeakobj.EndBaseLine) || midpeakobj.StartPoint.Equals(midpeakobj.StartBaseLine))
                    {
                        _resultindex = i;

                        break;//符合条件，跳出循环
                    }
                }

                return _resultindex;
            }
            else
            {
                for (int i = PeakNum+1; i < PeakList.Count; i++)
                {
                    LocalPeakObject midpeakobj = PeakList[i] as LocalPeakObject;

                    if (midpeakobj.EndPoint.Equals(midpeakobj.EndBaseLine) || midpeakobj.StartPoint.Equals(midpeakobj.StartBaseLine))
                    {
                        _resultindex = i;

                        break;//符合条件，跳出循环
                    }
                }

                return _resultindex;
            }


            
        }
        /// <summary "序列化">
        /// 给定的object对象进行序列化为字符串
        /// </summary>
        /// <param name="obj"> 序列化的目标源</param>
        /// <returns>序列化过的字符串</returns>
        public static string SerialObject(object obj)//序列化到字符串
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
        public static object DSerialObject(string val)//反序列化到object
        {
            byte[] V = Convert.FromBase64String(val);
            MemoryStream sb = new MemoryStream();
            BinaryFormatter ser = new BinaryFormatter();
            sb = new MemoryStream(V);
            return ser.Deserialize(sb);

        }
    }
}
