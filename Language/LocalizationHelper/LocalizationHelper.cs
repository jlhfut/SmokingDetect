using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace wayeal.language
{
    public class LocalizationHelper
    {
        //static string _Path = System.AppDomain.CurrentDomain.BaseDirectory + CultureInfo.CurrentCulture.Name + "\\%s.%s.dll";
        /// <summary>
        /// 获取信息本地化器
        /// </summary>
        public static InfoLocalizer InfoLocalizer
        {
            get
            {
                switch(CultureInfo.CurrentCulture.Name)
                {
                    case "zh-CN":
                        return new InfoCNLocalizer();
                }
                return new InfoLocalizer();

            }
        }
        /// <summary>
        /// 获取UI显示本地化器
        /// </summary>
        public static ControlLocalizer ControlLocalizer
        {
            get
            {
                switch (CultureInfo.CurrentCulture.Name)
                {
                    case "zh-CN":
                        return new ControlCNLocalizer();
                }
                return new ControlLocalizer();

            }
        }
        /// <summary>
        /// 获取验证错误文本本地化器
        /// </summary>
        public static ValidErrorTextLocalizer ValidErrorTextLocalizer
        {
            get
            {
                switch (CultureInfo.CurrentCulture.Name)
                {
                    case "zh-CN":
                        return new ValidErrorTextCNLocalizer();
                }
                return new ValidErrorTextLocalizer();

            }
        }        
        /// <summary>
        /// 获取dev控件内含本地化器
        /// </summary>
        public static XtraLocalizer XtraLocalizer
        {
            get
            {
                switch (CultureInfo.CurrentCulture.Name)
                {
                    case "zh-CN":
                        return new XtraCNLocalizer();
                }
                return new XtraLocalizer();

            }
        }
    }
}
