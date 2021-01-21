//===============================================================
// Copyright (C) 2010-2011 皖仪科技研发中心
// 文件名: WaveReadWriteDefines.cs
// 作者：软件部
// 日期：2011/04/20
// 描述：定义模块
// 版本：1.0
// 修改历史纪录
// 版本         修改时间         修改人                     修改内容
// 1.0          2011-04-20       倪玉宝                     建立
// 1.1          2011-05-10       倪玉宝                     添加新的定义
//
//==============================================================
using System;
namespace Wayee.WaveReadWrite
{
    #region enums
    /// <summary>
    /// 序列化枚举类型
    /// </summary>
    public enum SerialType
    { 
        /// <summary>
        /// 二进制序列化
        /// </summary>
        Binary,
        /// <summary>
        /// Soap序列化
        /// </summary>
        Soap,       
        /// <summary>
        /// Xml序列化
        /// </summary>
        Xml
    }
    //add by nyb 2011-5-10 begin
    /// <summary>
    /// 打开文件枚举类型
    /// </summary>
    public enum FileOpenFlag
    { 
        /// <summary>
        /// 指定文件存在，覆盖原有文件
        /// 指定文件不村子，创建新文件
        /// </summary>
        Create,
        /// <summary>
        /// 指定文件不存在，返回错误
        /// </summary>
        Open,
        /// <summary>
        /// 指定文件存在，打开文件
        /// 指定文件不存在，创建新文件
        /// </summary>
        OpenOrCreate
    }
    //add by nyb 2011-5-10 end
    #endregion
    [Serializable]
    public class Content
    {
        /// <summary>
        /// 段内容标识
        /// </summary>
        public int _nIndex = 0;
        /// <summary>
        /// 段内容起始位置
        /// </summary>
        public long _lStartPos = 0;
        /// <summary>
        /// 段内容每小节内容长度
        /// </summary>
        public long _lSecLen = 0;
        /// <summary>
        /// 段内容结束位置
        /// </summary>
        public long _lEndPos = 0;
    }
}
