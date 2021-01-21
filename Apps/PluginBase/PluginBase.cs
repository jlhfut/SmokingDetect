using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wayeal.plugin
{
    public class PluginBase
    {
        protected ucPluginBase _SetupUI = null;
        protected string _Key = "";
        protected object _Param = null;
        /// <summary>
        /// 获取设置UI
        /// </summary>
        /// <returns></returns>
        public ucPluginBase GetSetupUI
        {
            get { return _SetupUI; }
        }
        /// <summary>
        /// 设备关键字
        /// </summary>
        public string Key { get { return _Key; } }

        public object Param { get { return _Param; } set { _Param = value; } }

    }
}
