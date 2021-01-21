using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wayeal.validate
{
    public class ValidateManager<T> where T : struct
    {
        private ValidateLoader<T> _localizer = null;
        public ValidateManager(ValidateLoader<T> localizer)
        {
            _localizer = localizer;
        }
        /// <summary>
        /// get validor by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetValidor(string name)
        {
            return _localizer.GetValidor(name);
        }
        /// <summary>
        /// validate
        /// </summary>
        /// <param name="name">validor' name or regex string</param>
        /// <param name="value">value</param>
        /// <returns></returns>
        public ValidateResult Validate(string name, object value)
        {
            ValidateResult r = new ValidateResult();
            r.Valid = true;

            object func = _localizer.GetValidor(name);
            if (func != null && !(func is IValidate))
            {
                string pattern = func.ToString();
                func = _localizer.GetValidor("Regex");
                if (func != null && func is IValidate)
                    return (func as IValidate).Validate(pattern, value);
                return r;
            }
            if (func == null || !(func is IValidate)) return r;
            return (func as IValidate).Validate(value);
        }
        /// <summary>
        /// apply regex string
        /// </summary>
        /// <param name="parent"></param>
        public void ApplyRegex(Control parent)
        {
            Iterate(parent);
        }
        /// <summary>
        /// iterate apply regex
        /// </summary>
        /// <param name="parent"></param>
        protected virtual void Iterate(Control parent)
        {
            foreach (Control p in parent.Controls)
            {
                if (p.HasChildren && !(p is TextEdit))
                    Iterate(p);
                else
                {
                    if (!(p is TextEdit)) continue;

                    object pattern = _localizer.GetValidor(p.Name);
                    if(pattern==null && p.Name.IndexOf("_")!=-1)
                        pattern = _localizer.GetValidor(p.Name.Substring(0, p.Name.IndexOf("_")));
                    if (pattern != null && pattern is string && pattern.ToString()!="")
                    {
                        (p as TextEdit).Properties.Mask.BeepOnError = true;
                        (p as TextEdit).Properties.Mask.EditMask = pattern.ToString().Replace("^","").Replace("$","");
                        (p as TextEdit).Properties.Mask.MaskType = MaskType.RegEx;
                        
                    }
                }
            }
        }
    }
}