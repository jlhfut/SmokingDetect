//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: WaveReadWrite.cs
// 作者：软件部
// 日期：2011/04/20
// 描述：文件读写的实现
// 版本：1.0
// 修改历史纪录
// 版本         修改时间         修改人                     修改内容
// 1.0          2011-04-20       倪玉宝                     建立
// 1.1          2011-04-25       倪玉宝                     添加文件加密解密功能
//
//
//==============================================================
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Wayee.WaveReadWrite
{
    #region DataBaseReadWrite
    class DBBase
    {
        
    }
    #endregion

    #region abstracted serialize/deserialize file base class
    /// <summary>
    /// 文件序列化/反序列化抽象基类
    /// </summary>
    abstract class SerialFileBase : IFileReadWrite
    {
        #region implement interface funcs
        /// <summary>
        /// OpenFile接口实现虚函数
        /// </summary>
        /// <param name="sPath">文件路径</param>
        /// <param name="eFlag">打开方式</param>
        /// <returns>成功->true,反之->false</returns>
        public virtual bool OpenFile(string sPath, FileOpenFlag eFlag)
        {
            try
            {
                //指定文件不存在，创建并读写
                if (eFlag == FileOpenFlag.Create)
                {
                    _fStream = new FileStream(sPath, FileMode.Create, FileAccess.ReadWrite);
                }
                else if (eFlag == FileOpenFlag.Open)
                {
                    _fStream = new FileStream(sPath, FileMode.Open, FileAccess.ReadWrite);
                }
                else if (eFlag == FileOpenFlag.OpenOrCreate)
                {
                    _fStream = new FileStream(sPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                }
                if (_fStream != null)
                {
                    return true;
                }
            }
            catch(Exception e)
            {
                e.ToString();
               
            }
            return false;
        }
        /// <summary>
        /// CloseFile接口实现虚函数
        /// 关闭文件
        /// </summary>
        public virtual void CloseFile()
        {
            try
            {
                Dispose();
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
        /// <summary>
        /// WriteContent接口实现虚函数
        /// </summary>
        /// <param name="lsStream">内存流列表</param>
        /// <param name="nContentID">文件内容标识</param>
        /// <returns>成功->true,反之->false</returns>
        public virtual bool WriteContent(List<MemoryStream> lsStream, int nContentID)
        {
            try
            {
                if (_fStream == null)
                {
                    return false;
                }
                if (lsStream.Count == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return false;
        }

        /// <summary>
        /// ReadContent接口实现虚函数
        /// </summary>
        /// <param name="lsStream">内存流列表</param>
        /// <param name="nContentID">文件内容标识</param>
        /// <returns>成功->true,反之->false</returns>
        public virtual bool ReadContent(out List<MemoryStream> lsStream, int nContentID)
        {
            lsStream = new List<MemoryStream>();
            if (_fStream == null)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// ReadContent接口实现虚函数
        /// </summary>
        /// <param name="nListIndex">内容列表索引</param>
        /// <param name="lsStream">内存流列表</param>
        /// <returns>成功->true,反之->false</returns>
        public virtual bool ReadContent(int nListIndex, out List<MemoryStream> lsStream)
        {
            lsStream = new List<MemoryStream>();
            if (_fStream == null)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// ReadContent接口实现虚函数
        /// </summary>
        /// <param name="mStream">内存流对象</param>
        /// <param name="nListIndex">内容列表索引</param>
        /// <param name="nOffset">偏移量</param>
        /// <returns>成功->true,反之->false</returns>
        public virtual bool ReadContent(out MemoryStream mStream, int nListIndex, int nOffset)
        {
            mStream = null;
            if (_fStream == null)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// GetContentList接口实现虚函数
        /// </summary>
        /// <param name="lsContent">文件内容列表</param>
        /// <returns>成功->true,反之->false</returns>
        public virtual bool GetContentList(out List<Content> lsContent)
        {
            lsContent = new List<Content>();
            if (_fStream == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region internal funcs
        /// <summary>
        /// 释放占用的资源，恢复的构造的初始状态
        /// </summary>
        protected virtual void Dispose()
        {
            try
            { 
                if (_fStream != null)
                {
                    _fStream.Close();
                    _fStream = null;
                }
            }
            catch(Exception e)
            {
                e.ToString();
            }
        }
        #endregion

        #region
        //文件流对象
        protected FileStream _fStream = null;

        //文件解密对象
        protected DecryptFile _DecryptFile = new DecryptFile();
        //文件加密对象
        protected EncryptFile _EncryptFile = new EncryptFile();

        #endregion

    }
    #endregion

    #region binary serialize/deserialize file class
    /// <summary>
    /// 二进制流序列化文件
    /// </summary>
    class BinarySerialFile : SerialFileBase
    {
        /// <summary>
        /// 写内容标识的nContentID内容段
        /// </summary>
        /// <param name="lsStream">内存流列表</param>
        /// <param name="nContentID">内容标识</param>
        /// <returns>成功->true,反之->false</returns>
        public override bool WriteContent(List<MemoryStream> lsStream, int nContentID)
        {
            if (!base.WriteContent(lsStream, nContentID))
            {
                return false;
            }
            try
            {
                //解密
                //_DecryptFile.ExecuteDecrypt(ref _fStream);
                if (_fStream.CanWrite && _fStream.CanSeek)
                {
                    _fStream.Seek(0, SeekOrigin.End);
                }
                long lConStartPos = _fStream.Length;
                //序列化一次文件段
                ContentSection conSec = new BinaryContentSection();
                conSec.Serialize(ref _fStream);

                conSec.SetIndex(nContentID);
                conSec.SetStartPos(_fStream.Length);
                conSec.SetSectionLen(lsStream[0].Length);
                conSec.SetEndPos(_fStream.Length + lsStream[0].Length * lsStream.Count);
                _fStream.Seek(lConStartPos, SeekOrigin.Begin);
                //再序列化一次
                conSec.Serialize(ref _fStream);
                for (int i = 0; i < lsStream.Count; i++)
                {
                    lsStream[i].WriteTo(_fStream);
                }
                _fStream.Flush();
                //加密
                //_EncryptFile.ExecuteEncrypt(ref _fStream);
                return true;
            }
            catch(Exception e)
            {
                e.ToString();
            }
            return false;
        }
        /// <summary>
        /// 读取内容标识为nContentID的所有内容
        /// </summary>
        /// <param name="lsStream">内存流列表</param>
        /// <param name="nContentID">内容标识</param>
        /// <returns>成功->true,反之->false</returns>
        public override bool ReadContent(out List<MemoryStream> lsStream, int nContentID)
        {
            if (!base.ReadContent(out lsStream, nContentID))
            {
                return false;
            }
            try
            {
                //解密
                //_DecryptFile.ExecuteDecrypt(ref _fStream);
                if (_fStream.CanSeek && _fStream.CanRead)
                {
                    _fStream.Seek(0, SeekOrigin.Begin);
                }
                List<ContentSection> lsSecs = new List<ContentSection>();
                while (_fStream.Position != _fStream.Length)
                {
                    ContentSection conSec = new BinaryContentSection();
                    if (conSec.Deserialize(ref _fStream))
                    {
                        _fStream.Seek(conSec.GetEndPos(), SeekOrigin.Begin);
                        if (conSec.GetIndex() == nContentID)
                        {
                            lsSecs.Add(conSec);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                if (lsSecs.Count > 0)
                {
                    long lStartPos, lEndPos, lSecLen;
                    for (int i = 0; i < lsSecs.Count; i++)
                    {
                        lStartPos = lsSecs[i].GetStartPos();
                        lEndPos = lsSecs[i].GetEndPos();
                        lSecLen = lsSecs[i].GetSectionLen();
                        _fStream.Seek(lStartPos, SeekOrigin.Begin);
                        while (lStartPos < lEndPos)
                        {
                            byte[] arrContent = new byte[lSecLen];
                            _fStream.Read(arrContent, 0, (int)lSecLen);
                            lStartPos += lSecLen;
                            MemoryStream mStream = new MemoryStream(arrContent);
                            lsStream.Add(mStream);
                        }
                    }
                }
                //加密
                //_EncryptFile.ExecuteEncrypt(ref _fStream);
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return false;
        }
        /// <summary>
        /// 读取文件内容列表索引一整块内容
        /// </summary>
        /// <param name="nListIndex">内容块索引</param>
        /// <param name="lsStream">内存流列表</param>
        /// <returns>成功->true,反之->false</returns>
        public override bool ReadContent(int nListIndex, out List<MemoryStream> lsStream)
        {
            if (!base.ReadContent(nListIndex, out lsStream))
            {
                return false;
            }
            try
            {
                //解密
                //_DecryptFile.ExecuteDecrypt(ref _fStream);
                List<Content> lsContent = null;
                if (!GetContentList(out lsContent))
                {
                    return false;
                }
                if (nListIndex > lsContent.Count - 1)
                {
                    return false;
                }

                long lStartPos = lsContent[nListIndex]._lStartPos;
                long lEndPos = lsContent[nListIndex]._lEndPos;
                long lSecLen = lsContent[nListIndex]._lSecLen;
                _fStream.Seek(lStartPos, SeekOrigin.Begin);
                while (lStartPos < lEndPos)
                {
                    byte[] arrContent = new byte[lSecLen];
                    _fStream.Read(arrContent, 0, (int)lSecLen);
                    lStartPos += lSecLen;
                    MemoryStream mStream = new MemoryStream(arrContent);
                    lsStream.Add(mStream);
                }
                //加密
                //_EncryptFile.ExecuteEncrypt(ref _fStream);
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return false;
        }
        /// <summary>
        /// 读取文件内容列表索引内容块中偏移内容小节
        /// </summary>
        /// <param name="mStream">内存流对象</param>
        /// <param name="nListIndex">文件内容列表</param>
        /// <param name="nOffset">列表内容偏移量</param>
        /// <returns>成功->true,反之->false</returns>
        public override bool ReadContent(out MemoryStream mStream, int nListIndex, int nOffset)
        {
            if (!base.ReadContent(out mStream, nListIndex, nOffset))
            {
                return false;
            }
            try
            {
                //解密
                //_DecryptFile.ExecuteDecrypt(ref _fStream);
                List<Content> lsContent = null;
                if (!GetContentList(out lsContent))
                {
                    return false;
                }
                if (nListIndex > lsContent.Count - 1)
                {
                    return false;
                }
                long lStartPos = lsContent[nListIndex]._lStartPos;
                long lEndPos = lsContent[nListIndex]._lEndPos;
                long lSecLen = lsContent[nListIndex]._lSecLen;
                if (lStartPos + nOffset * lSecLen >= lEndPos)
                {
                    return false;
                }
                _fStream.Seek(lStartPos + nOffset * lSecLen, SeekOrigin.Begin);
                byte[] arrContent = new byte[lSecLen];
                _fStream.Read(arrContent, 0, (int)lSecLen);
                mStream = new MemoryStream(arrContent);
                //加密
                //_EncryptFile.ExecuteEncrypt(ref _fStream);
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return false;
        }
        /// <summary>
        /// 获取内容列表
        /// </summary>
        /// <param name="lsContent">内容列表</param>
        /// <returns>成功->true,反之->false</returns>
        public override bool GetContentList(out List<Content> lsContent)
        {
            if (!base.GetContentList(out lsContent))
            {
                return false;
            }
            try
            {
                //解密
                //_DecryptFile.ExecuteDecrypt(ref _fStream);
                if ( !(_fStream.CanRead && _fStream.CanSeek))
                {
                    return false;
                }
                _fStream.Seek(0, SeekOrigin.Begin);
                while (_fStream.Position != _fStream.Length)
                {
                    ContentSection conSec = new BinaryContentSection();
                    if (conSec.Deserialize(ref _fStream))
                    {
                        _fStream.Seek(conSec.GetEndPos(), SeekOrigin.Begin);
                        lsContent.Add(conSec.GetContent());
                    }
                    else
                    {
                        break;
                    }
                }
                //加密
                //_EncryptFile.ExecuteEncrypt(ref _fStream);
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return false;
        }
    }
    #endregion
}




