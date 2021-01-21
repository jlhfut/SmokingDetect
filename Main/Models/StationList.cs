using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wayeal.os.exhaust.Models
{
  public  class StationList
    {
        #region Model
        private string _sno;
        private string _sname;
        private decimal? _slongitude;
        private decimal? _slatitude;
        private decimal? _sssope;
        private string _saddress;
        private string _stip;
        /// <summary>
        /// 
        /// </summary>
        public string sno
        {
            set { _sno = value; }
            get { return _sno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sname
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? slongitude
        {
            set { _slongitude = value; }
            get { return _slongitude; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? slatitude
        {
            set { _slatitude = value; }
            get { return _slatitude; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? sssope
        {
            set { _sssope = value; }
            get { return _sssope; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string saddress
        {
            set { _saddress = value; }
            get { return _saddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stip
        {
            set { _stip = value; }
            get { return _stip; }
        }
        #endregion Model


    }
}
