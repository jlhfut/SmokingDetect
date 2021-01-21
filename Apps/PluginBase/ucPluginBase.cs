using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wayeal.plugin
{
    public partial class ucPluginBase : UserControl
    {
        public ucPluginBase()
        {
            InitializeComponent();
        }
        /// <summary>
        /// set params to plugin object 
        /// </summary>
        public virtual object Params { get; set; }

        public class DeviceNotifyEventArgs : EventArgs
        {
            public string Key { get; set; }
            public object Param { get; set; }
            public bool Result { get; set; }
        }
        public delegate void DeviceNotifyEventHandler(object sender, DeviceNotifyEventArgs e);
        /// <summary>
        /// notify to parent
        /// </summary>
        public event DeviceNotifyEventHandler DeviceNotify;
        /// <summary>
        /// notify to parent
        /// </summary>
        protected bool onDeviceNotify(DeviceNotifyEventArgs e)
        {
            e.Result = true;
            if (DeviceNotify != null) DeviceNotify(this, e);
            return e.Result;
        }

        

    }
}
