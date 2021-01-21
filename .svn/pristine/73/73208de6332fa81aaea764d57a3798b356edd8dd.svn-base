//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: ContentSection.cs
// 作者：软件部
// 日期：2011/5/10
// 描述：内容段的序列化和反序列化
// 版本：1.0
// 修改历史纪录
// 版本         修改时间         修改人                     修改内容
// 1.0          2011-05-10       倪玉宝                     建立
//
//
//==============================================================
using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace Wayee.WaveReadWrite
{
    #region abstract content section base class
    /// <summary>
    /// 内容段抽象基类
    /// </summary>
    [Serializable]
    abstract class ContentSection
    {
        #region abstract functions
        /// <summary>
        /// 序列化文件流
        /// </summary>
        /// <param name="fStream">文件流引用对象</param>
        /// <returns>成功->true, 反之->false</returns>
        abstract public bool Serialize(ref FileStream fStream);
        /// <summary>
        /// 反序列化文件流
        /// </summary>
        /// <param name="fStream">文件流引用对象</param>
        /// <returns>成功->true, 反之->false</returns>
        abstract public bool Deserialize(ref FileStream fStream);
        #endregion
        /// <summary>
        /// 自我克隆
        /// </summary>
        /// <param name="src">克隆源</param>
        /// <returns>类对象自身</returns>
        protected object SelfClone(ContentSection src)
        {
            _con._nIndex = src._con._nIndex;
            _con._lStartPos = src._con._lStartPos;
            _con._lSecLen = src._con._lSecLen;
            _con._lEndPos = src._con._lEndPos;
            return this;
        }

        #region base public functions
        /// <summary>
        /// 设置文件内容段标识
        /// </summary>
        /// <param name="nIndex">标识序号</param>
        public void SetIndex(int nIndex)
        {
            _con._nIndex = nIndex;
        }
        /// <summary>
        /// 设置文件内容段起始位置
        /// </summary>
        /// <param name="lPos">起始位置</param>
        public void SetStartPos(long lPos)
        {
            _con._lStartPos = lPos;
        }
        /// <summary>
        /// 设置文件段中每小节的长度
        /// </summary>
        /// <param name="lLen">小节长度</param>
        public void SetSectionLen(long lLen)
        {
            _con._lSecLen = lLen;
        }
        /// <summary>
        /// 设置文件内容段结束位置
        /// </summary>
        /// <param name="lPos">文件内容段结束位置</param>
        public void SetEndPos(long lPos)
        {
            _con._lEndPos = lPos;
        }
        /// <summary>
        /// 获取文件内容标识
        /// </summary>
        /// <returns>文件内容标识</returns>
        public int GetIndex()
        {
            return _con._nIndex;
        }
        /// <summary>
        /// 获取文件内容段开始位置
        /// </summary>
        /// <returns>文件内容段开始位置</returns>
        public long GetStartPos()
        {
            return _con._lStartPos;
        }
        /// <summary>
        /// 获取文件内容段中每个小节的长度
        /// </summary>
        /// <returns>文件内容段中每个小节的长度</returns>
        public long GetSectionLen()
        {
            return _con._lSecLen;
        }
        /// <summary>
        /// 获取文件内容段结束位置
        /// </summary>
        /// <returns>文件内容段结束位置</returns>
        public long GetEndPos()
        {
            return _con._lEndPos;
        }
        /// <summary>
        /// 获取内容类对象
        /// </summary>
        /// <returns>内容类对象</returns>
        public Content GetContent()
        {
            return _con;
        }
        #endregion
        /// <summary>
        /// 私有的文件内容对象
        /// </summary>
        private Content _con = new Content();
    }
    #endregion

    #region  binary serialize/deserialize section class
    /// <summary>
    /// Binary序列化内容段类
    /// </summary>
    [Serializable]
    internal class BinaryContentSection : ContentSection
    {
        #region override base class virtual funcs
        /// <summary>
        /// 序列化内容段
        /// </summary>
        /// <param name="fStream">文件流对象</param>
        /// <returns>成功->true,反之->false</returns>
        public override bool Serialize(ref FileStream fStream)
        {
            try
            {
                _iFormatter.Serialize(fStream, (ContentSection)this);
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return false;
        }
        /// <summary>
        /// 反序列化内容段类
        /// </summary>
        /// <param name="fStream">文件流对象</param>
        /// <returns>成功->true,反之->false</returns>
        public override bool Deserialize(ref FileStream fStream)
        {
            try
            {
                SelfClone((ContentSection)(_iFormatter.Deserialize(fStream)));
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return false;
        }
        #endregion

        /// <summary>
        /// 序列化/反序列化对象
        /// </summary>
        [NonSerialized]
        private BinaryFormatter _iFormatter = new BinaryFormatter();
        
    }

    #endregion
}
