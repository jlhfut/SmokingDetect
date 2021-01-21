using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using wayeal.utils;

namespace wayeal.language
{
    public class FontManager : ControlIterate
    {
        private string _FontName="Tahoma";
        public FontManager(string fontName)
        {
            _FontName = fontName;
        }

        protected override void Apply(object obj, string objectName)
        {
            PropertyInfo pinfo = obj.GetType().GetProperty("Font");
            PropertyInfo ptag = obj.GetType().GetProperty("Tag");
            if (pinfo != null && ptag!=null && ptag.GetValue(obj)!=null)
            {
                Font f = new Font(new FontFamily(_FontName), 20);
                if (f != null && pinfo!=null && pinfo.CanWrite)
                    pinfo.SetValue(obj, f);

            }
            
        }

        protected override void Iterate(Control parent)
        {
            base.Iterate(parent);
        }

        public void ApplyFont(Control parent)
        {
            base.Iterate(parent);
        }
    }
}