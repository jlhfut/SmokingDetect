using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace wayeal.os.exhaust.Models
{
    /// <summary>
    /// 类Log。
    /// </summary>
    [Serializable]
    public partial class Log
    {

        #region Model
        private int _id;
        private DateTime _date;
        private string _thread;
        private string _level;
        private string _logger;
        private string _message;
        private string _exception;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Thread
        {
            set { _thread = value; }
            get { return _thread; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Level
        {
            set { _level = value; }
            get { return _level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Logger
        {
            set { _logger = value; }
            get { return _logger; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Exception
        {
            set { _exception = value; }
            get { return _exception; }
        }
        #endregion Model



    }
}

