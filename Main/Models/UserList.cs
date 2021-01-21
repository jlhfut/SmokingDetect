using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SqlSugar;

namespace wayeal.os.exhaust.Models
{
    /// <summary>
    /// 类UserList。
    /// </summary>
    public class UserList
    {
        #region Model
        private string _uname;
        private int? _uisalive;
        private int? _upermission;
        private string _ucreateor;
        private string _udata;
        private string _upwd;
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public string uname
        {
            set { _uname = value; }
            get { return _uname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? uisAlive
        {
            set { _uisalive = value; }
            get { return _uisalive; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? upermission
        {
            set { _upermission = value; }
            get { return _upermission; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ucreateor
        {
            set { _ucreateor = value; }
            get { return _ucreateor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string udata
        {
            set { _udata = value; }
            get { return _udata; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string upwd
        {
            set { _upwd = value; }
            get { return _upwd; }
        }
        #endregion Model
    }
}

