//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: WaveReadWriteFactory.cs
// 作者：软件部
// 日期：2011/04/20
// 描述：文件读写工厂
// 版本：1.0
// 修改历史纪录
// 版本         修改时间         修改人                     修改内容
// 1.0          2011-04-20       倪玉宝                     建立
//
//
//==============================================================
using System;
using System.IO;
using System.Runtime.InteropServices;
namespace Wayee.WaveReadWrite
{
    #region WaveReadWriteFactory
    [ComVisible(false)]
    public class ReadWriteFactory
    {
        /// <summary>
        /// 创建数据库接口实例
        /// </summary>
        /// <returns>数据库存取操作接口</returns>
        public static IWaveReadWrite CreateDBInstance()
        {
            return null;
        }
        /// <summary>
        /// 创建磁盘文件接口实例
        /// </summary>
        /// <param name="eType">序列化类型</param>
        /// <returns>磁盘文件存取操作接口</returns>
        public static IFileReadWrite CreateFileInstance(SerialType eType)
        {
            IFileReadWrite iReadWrite = null;
            try
            {
                switch (eType)
                {
                    case SerialType.Binary:
                        iReadWrite = new BinarySerialFile();
                        break;
                    case SerialType.Soap:
                        //iReadWrite = new SoapSerialFile();
                        break;
                    case SerialType.Xml:
                        //iReadWrite = new XmlSerialFile();
                        break;
                    default:
                        break;
                }

            }
            catch (IOException)
            {
                iReadWrite = null;
            }
            return iReadWrite;
        }
    }
    #endregion
}
