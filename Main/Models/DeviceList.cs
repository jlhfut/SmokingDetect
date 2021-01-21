using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wayeal.os.exhaust.Models
{
   public class DeviceList
    {
        public DeviceList()
        { }
        #region Model
        private int _did;
        private string _dname;
        private string _dtype;
        private string _dport;
        private int? _dbaud;
        private int? _ddata;
        private int? _dstop;
        private string _dcheck;
        private string _dip;
        private bool _dstate;
        private string _dpwd;
        private string _duname;
        /// <summary>
        /// 
        /// </summary>

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//主键并且自增 （string不能设置自增）
      
        public int did
        {
            set { _did = value; }
            get { return _did; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dname
        {
            set { _dname = value; }
            get { return _dname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dtype
        {
            set { _dtype = value; }
            get { return _dtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dport
        {
            set { _dport = value; }
            get { return _dport; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? dbaud
        {
            set { _dbaud = value; }
            get { return _dbaud; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ddata
        {
            set { _ddata = value; }
            get { return _ddata; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? dstop
        {
            set { _dstop = value; }
            get { return _dstop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dcheck
        {
            set { _dcheck = value; }
            get { return _dcheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dip
        {
            set { _dip = value; }
            get { return _dip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool dstate
        {
            set { _dstate = value; }
            get { return _dstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dpwd
        {
            set { _dpwd = value; }
            get { return _dpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string duname
        {
            set { _duname = value; }
            get { return _duname; }
        }
        #endregion Model
    }
}
