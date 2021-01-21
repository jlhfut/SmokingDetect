using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wayeal.plugin
{
    public class PluginManager
    {
        private string c_PluginIdName = "PluginBase";
        private string c_Key = "Key";
        private string c_SetupUI = "GetSetupUI";
        /// <summary>
        /// 插件所在目录
        /// </summary>
        public static string PluginDir { get; set; }
        private static PluginManager _Instance = null;
        /// <summary>
        /// 插件管理器实例
        /// </summary>
        public static PluginManager Instance
        {
            get {
                if (_Instance == null) _Instance = new PluginManager(PluginDir);
                return _Instance;
            }
        }

        private List<PluginInfo> _PluginList = new List<PluginInfo>();
        public PluginManager(string pluginDir)
        {
            LoadPlugin(pluginDir, _PluginList);
        }

        /// <summary>
        /// 插件列表
        /// </summary>
        public List<PluginInfo> PluginList { get { return _PluginList; } }

        /// <summary>
        /// 通过关键字获取插件
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        public PluginInfo GetPlugin(string key)
        {
            foreach(PluginInfo p in PluginList)
            {
                if (p.Key == key) return p;
            }
            return null;
        }
        /// <summary>
        /// load plugin from plugin dir.
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="pi"></param>
        private void LoadPlugin(string dir, List<PluginInfo> pi)
        {
            try
            {
                GC.Collect();
                pi.Clear();
                List<string> fns = new List<string>();
                if (Directory.Exists(dir))
                {
                    string[] pifns = Directory.GetFiles(dir);
                    fns.AddRange(pifns);
                }
                if (fns.Count > 0)
                {
                    if (fns != null && fns.Count > 0)
                    {
                        string key = "";
                        PropertyInfo pinf = null;

                        for (int i = 0; i < fns.Count; i++)
                        {
                            if (Path.GetExtension(fns[i]) != ".dll") continue;
                            Assembly amb = System.Reflection.Assembly.LoadFrom(fns[i]);
                            List<object> _PluginInstanceLst = new List<object>();
                            _PluginInstanceLst = GetPluginInstanceList(amb);
                            foreach (object pins in _PluginInstanceLst)
                            {
                                pinf=pins.GetType().GetProperty(c_Key);
                                if (pinf != null)
                                {
                                    key = pinf.GetValue(pins).ToString();
                                    PluginInfo p = new PluginInfo(key);
                                    p.FileName = fns[i];
                                    pinf = pins.GetType().GetProperty(c_SetupUI);
                                    if (pinf != null) p.SetupUI = (UserControl)pinf.GetValue(pins);
                                    pi.Add(p);
                                }
                            }
                        }
                    }
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                
            }
        }
        /// <summary>
        /// get plugin instance list by custom attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="amb"></param>
        /// <returns></returns>
        private List<object> GetPluginInstanceList(Assembly amb)
        {
            List<object> lst = new List<object>();
            Type[] ts = amb.GetTypes();
            foreach (Type type in ts)
            {
                try
                {
                    if (type == null) continue;
                    if (!type.BaseType.FullName.EndsWith(c_PluginIdName)) continue;
                    lst.Add(Activator.CreateInstance(type));
                }
                catch
                {
                    continue;
                }
            }
            return lst;
        }

    }

    public class PluginInfo
    {
        public PluginInfo(string key)
        {
            Key = key;
        }
        /// <summary>
        /// Object key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Object from file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Setup ui
        /// </summary>
        public UserControl SetupUI { get; set; }
        /// <summary>
        /// Registed notify event
        /// </summary>
        public bool RegistNotify { get; set; }
    }
}
