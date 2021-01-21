using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using wayeal.utils;
using DevExpress.Charts.Native;
using DevExpress.XtraTreeList;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;

namespace wayeal.language
{
    public class LanguageManager<T>:ControlIterate where T : struct
    {
        private ResourecLocalizer<T> _localizer = null;
        public LanguageManager(ResourecLocalizer<T> localizer)
        {
            _localizer = localizer;
        }

        protected override void Apply(object obj, string objectName)
        {
            if (objectName == "") return;
            string objectText = "";
            System.Reflection.PropertyInfo pinfo = obj.GetType().GetProperty("HeaderTitle");
            if (pinfo == null && obj is RepositoryItemButtonEdit) pinfo = obj.GetType().GetProperty("NullText");
            if (pinfo == null) pinfo = obj.GetType().GetProperty("Caption");
            if (pinfo == null) pinfo = obj.GetType().GetProperty("Text");
            if (pinfo == null) pinfo = obj.GetType().GetProperty("Description");
            if (pinfo == null && obj is ISeries) pinfo = obj.GetType().GetProperty("Name");
            if (pinfo == null && obj is TreeList) pinfo = obj.GetType().GetProperty("Name");
            if (pinfo == null) return;

            if (_localizer != null) objectText = _localizer.GetLocalizedText(objectName);
            if(objectText=="" && objectName.IndexOf("_")!=-1) objectText = _localizer.GetLocalizedText(objectName.Substring(0, objectName.IndexOf("_")));
            if(objectText!=null && obj is TreeList)
            {
                string[] node = objectText.Split(',');
                if(node.Length== (obj as TreeList).Nodes.Count)
                {
                    TreeList t = (obj as TreeList);
                    for (int i = 0; i < t.Nodes.Count; i++) t.SetRowCellValue(t.Nodes[i],t.Columns[0],node[i]);
                }
            }
            if (objectText != null && obj is ImageListBoxControl)
            {
                string[] node = objectText.Split(',');
                if (node.Length == (obj as ImageListBoxControl).ItemCount)
                {
                    ImageListBoxControl t = (obj as ImageListBoxControl);
                    for (int i = 0; i < t.ItemCount; i++) t.Items[i].Value = node[i]; //t.SetRowCellValue(t.Nodes[i], t.Columns[0], node[i]);
                }
            }
            if (objectText != null && obj is ComboBoxEdit)
            {
                string[] itms = objectText.Split(',');
                if (itms.Length == (obj as ComboBoxEdit).Properties.Items.Count)
                {
                    for (int i = 0; i < (obj as ComboBoxEdit).Properties.Items.Count; i++) (obj as ComboBoxEdit).Properties.Items[i]=itms[i];
                }
            }
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