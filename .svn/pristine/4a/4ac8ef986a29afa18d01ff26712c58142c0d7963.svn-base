// 作者：软件部
// 日期：2011/04/25
// 描述：文件读写工厂
// 版本：1.0
// 修改历史纪录
// 版本         修改时间         修改人                     修改内容
// 1.0          2011-04-25       倪玉宝                     建立
//
//
//==============================================================
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Wayee.WaveReadWrite
{
    class DeEncryptBase
    {
        #region construction function
        //静态构造函数
        static DeEncryptBase()
        {
            byte[] bytKeyArray = Encoding.Default.GetBytes(_sEncrypteKey);
            SHA1 _ha = new SHA1Managed();
            byte[] hb = _ha.ComputeHash(bytKeyArray);
            for (int i = 0; i < 8; i++)
            {
                _bytKey[i] = hb[i];
            }
            for (int i = 8; i < 16; i++)
            {
                _bytIV[i - 8] = hb[i];
            }
        }
        #endregion
        //加解密对象
        protected static DESCryptoServiceProvider _Des = new DESCryptoServiceProvider();
        
        //密钥键值
        protected static byte[] _bytKey = new byte[8];
        //密钥矢量
        protected static byte[] _bytIV = new byte[8];

        //默认密钥字符串
        protected static  string _sEncrypteKey = "WAYEE Science & Techonlogy Co.,Ltd.";
        //内存流
        protected MemoryStream _mStream = new MemoryStream();

    }
    class EncryptFile : DeEncryptBase
    {
        #region construction function
        /// <summary>
        /// 加密文件构造函数
        /// </summary>
        public EncryptFile()
        {
            _csEncrypt = new CryptoStream(_mStream, _Des.CreateEncryptor(_bytKey, _bytIV), CryptoStreamMode.Write);
        }
        #endregion
        /// <summary>
        /// 执行文件加密
        /// </summary>
        /// <param name="fStream">文件流对象</param>
        /// <returns>成功返回true ,否则返回false</returns>
        public bool ExecuteEncrypt(ref FileStream fStream)
        {
            try
            {
                if (fStream.Length == 0)
                {
                    return false;
                }
                if (fStream.CanSeek && fStream.CanWrite)
                {
                    byte[] bytearrayinput = new byte[fStream.Length];
                    fStream.Seek(0, SeekOrigin.Begin);
                    fStream.Read(bytearrayinput, 0, bytearrayinput.Length);
                    _csEncrypt.Write(bytearrayinput, 0, bytearrayinput.Length);
                    _csEncrypt.FlushFinalBlock();

                    fStream.SetLength(0);
                    foreach (byte byt in _mStream.ToArray())
                    {
                        fStream.WriteByte(byt);
                    }
                    _csEncrypt.Close();
                    _mStream.Close();
                    return true;

                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return false;
        }
        //解密流对象
        private CryptoStream _csEncrypt = null;
    }
    class DecryptFile : DeEncryptBase
    {
        #region construction function
        /// <summary>
        /// 文件解密构造函数
        /// </summary>
        public DecryptFile()
        { 
             _csDecrypt = new CryptoStream(_mStream, _Des.CreateDecryptor(_bytKey, _bytIV), CryptoStreamMode.Write);
        }
        #endregion
        /// <summary>
        /// 执行文件解密
        /// </summary>
        /// <param name="fStream">文件流引用</param>
        public bool ExecuteDecrypt(ref FileStream fStream)
        {
            try
            {
                if (fStream.Length == 0)
                {
                    return false;
                }
                fStream.Seek(0, SeekOrigin.Begin);
                byte[] bytearrayinput = new byte[fStream.Length];
                fStream.Read(bytearrayinput, 0, bytearrayinput.Length);
                _csDecrypt.Write(bytearrayinput, 0, bytearrayinput.Length);
                _csDecrypt.FlushFinalBlock();

                if (fStream.CanRead && fStream.CanSeek)
                {
                    fStream.SetLength(0);
                    fStream.Seek(0, SeekOrigin.Begin);
                    foreach (byte byt in _mStream.ToArray())
                    {
                        fStream.WriteByte(byt);
                    }
                }
                _csDecrypt.Close();
                _mStream.Close();
                return true;

            }
            catch (Exception e)
            {
                e.ToString();
            }
            return false;
        }
        //解密流对象
        private CryptoStream _csDecrypt = null;
    }
}
