using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
namespace wayeal.os.exhaust.Models
{
    /// <summary>
	/// 类Vehicle。
	/// </summary>
	[Serializable]
    public partial class Vehicle
    {
        public Vehicle()
        { }
        #region Model
       
        private int _vid;
        private DateTime? _vcheckdate;
        private string _vstationname;
        private string _vno;
        private string _vcolor;
        private string _vtype;
        private int? _vroadno;
        private string _vboardtype;
        private float _vboardcredi;
        private int? _vringelman;
        private float _vringelmancredi;
        private string _vimage1;
        private string _vimage2;
        private string _vheadimage;
        private string _vvideo;
        /// <summary>
        /// 
        /// </summary>
        /// 
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int vid
        {
            set { _vid = value; }
            get { return _vid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? vcheckdate
        {
            set { _vcheckdate = value; }
            get { return _vcheckdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vstationname
        {
            set { _vstationname = value; }
            get { return _vstationname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vno
        {
            set { _vno = value; }
            get { return _vno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vcolor
        {
            set { _vcolor = value; }
            get { return _vcolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vtype
        {
            set { _vtype = value; }
            get { return _vtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? vroadno
        {
            set { _vroadno = value; }
            get { return _vroadno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vboardtype
        {
            set { _vboardtype = value; }
            get { return _vboardtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float vboardcredi
        {
            set { _vboardcredi = value; }
            get { return _vboardcredi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? vringelman
        {
            set { _vringelman = value; }
            get { return _vringelman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float vringelmancredi
        {
            set { _vringelmancredi = value; }
            get { return _vringelmancredi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vimage1
        {
            set { _vimage1 = value; }
            get { return _vimage1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vimage2
        {
            set { _vimage2 = value; }
            get { return _vimage2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vheadimage
        {
            set { _vheadimage = value; }
            get { return _vheadimage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vvideo
        {
            set { _vvideo = value; }
            get { return _vvideo; }
        }
        #endregion Model



    }
}
