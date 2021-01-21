//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: WaveReadWriteInterface.cs
// 作者：软件部
// 日期：2011/04/20
// 描述：波谱数据存取接口声明
// 版本：1.0
// 修改历史纪录
// 版本         修改时间         修改人                     修改内容
// 1.0          2011-04-20       倪玉宝                     建立
//
//
//==============================================================
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Wayee.WaveReadWrite
{
    #region interface

    #region save/read wave data to/from database interface definition
    public interface IWaveReadWrite 
    {
        void Write(string sBuf);

    }
    #endregion

    #region save/read wave data to/from file interface definition
    /// <summary>
    /// 文件存取接口定义
    /// </summary>
    public interface IFileReadWrite 
    {
        bool OpenFile(string sPath, FileOpenFlag eFlag);
        /// <summary>
        /// 关闭文件
        /// </summary>
        void CloseFile();
        /// <summary>
        /// 获取内容列表
        /// </summary>
        /// <param name="lsContent">内容列表</param>
        /// <returns>成功->true,反之->false</returns>
        bool GetContentList(out List<Content> lsContent);
        /// <summary>
        /// 写内容标识的nContentID内容段
        /// </summary>
        /// <param name="lsStream">内存流列表</param>
        /// <param name="nContentID">内容标识</param>
        /// <returns>成功->true,反之->false</returns>
        bool WriteContent(List<MemoryStream> lsStream, int nContentID);
        /// <summary>
        /// 读取内容标识为nContentID的所有内容
        /// </summary>
        /// <param name="lsStream">内存流列表</param>
        /// <param name="nContentID">内容标识</param>
        /// <returns>成功->true,反之->false</returns>
        bool ReadContent(out List<MemoryStream> lsStream, int nContentID);
        /// <summary>
        /// 读取文件内容列表索引一整块内容
        /// </summary>
        /// <param name="nListIndex">内容块索引</param>
        /// <param name="lsStream">内存流列表</param>
        /// <returns>成功->true,反之->false</returns>
        bool ReadContent(int nListIndex, out List<MemoryStream> lsStream);
        /// <summary>
        /// 读取文件内容列表索引内容块中偏移内容小节
        /// </summary>
        /// <param name="mStream">内存流对象</param>
        /// <param name="nListIndex">文件内容列表</param>
        /// <param name="nOffset">列表内容偏移量</param>
        /// <returns>成功->true,反之->false</returns>
        bool ReadContent(out MemoryStream mStream, int nListIndex, int nOffset);
    }
    #endregion

    #endregion
}
