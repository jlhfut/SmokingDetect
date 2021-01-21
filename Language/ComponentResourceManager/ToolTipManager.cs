using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.utils;

namespace wayeal.language
{
    public class ToolTipManager<T> : ControlIterate where T : struct
    {
        private ResourecLocalizer<T> _localizer = null;
        public ToolTipManager(ResourecLocalizer<T> localizer)
        {
            _localizer = localizer;
        }

        protected override void Apply(object obj, string objectName)
        {
            if (objectName == "") return;
            string objectText = "";
            System.Reflection.PropertyInfo pinfo = obj.GetType().GetProperty("ToolTip");
            if (pinfo == null) return;

            if (_localizer != null) objectText = _localizer.GetLocalizedText(objectName);
            if (objectText == "" && objectName.IndexOf("_") != -1) objectText = _localizer.GetLocalizedText(objectName.Substring(0, objectName.IndexOf("_")));
            if (objectText != "" && pinfo.CanWrite) pinfo.SetValue(obj, objectText);
        }

        protected override void Iterate(Control parent)
        {
            base.Iterate(parent);
        }

        public void ApplyLanguage(Control parent)
        {
            base.Iterate(parent);
        }
    }
}
