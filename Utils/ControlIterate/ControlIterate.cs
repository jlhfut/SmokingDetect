using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using DevExpress.Charts.Model;
using DevExpress.XtraLayout;
using DevExpress.XtraTreeList;

namespace wayeal.utils
{
    public class ControlIterate
    {
        protected virtual void Apply(object obj, string objectName)
        {

        }

        protected virtual void Iterate(Control parent)
        {
            foreach (Control p in parent.Controls)
            {
                if (p is RibbonControl) IterateRibbon(p as RibbonControl);
                if (p is GridControl) IterateGridControl(p as GridControl);
                if (p is PropertyGridControl) IteratePropertyGridControl(p as PropertyGridControl);
                if (p is RadioGroup) IterateRadioGroup((p as RadioGroup).Properties.Items);
                if (p is ChartControl) IterateChartControl(p as ChartControl);
                if (p is ToolStrip) IterateToolStrip(p as ToolStrip);
                if (p.HasChildren) Iterate(p);
                Apply(p, p.Name);
            }
            Apply(parent, parent.Name);
            if (parent is RibbonControl) IterateRibbon(parent as RibbonControl);
            if (parent is GridControl) IterateGridControl(parent as GridControl);
            if (parent is PropertyGridControl) IteratePropertyGridControl(parent as PropertyGridControl);
            if (parent is BackstageViewControl) IterateBackstageViewControl(parent as BackstageViewControl);
            if (parent is LayoutControl) IterateLayoutControl(parent as LayoutControl);
           
        }

        private void IterateToolStrip(ToolStrip toolStrip)
        {
            if (toolStrip == null) return;
            foreach (ToolStripItem t in toolStrip.Items)
            {
                Apply(t, t.Name);
            }
        }

        private void IterateBackstageViewControl(BackstageViewControl bv)
        {
            foreach (BackstageViewItemBase b in bv.Items)
            {
                Apply(b, b.Name);
            }
        }

        private void IterateGridControl(GridControl pg)
        {
            GridView g = (GridView)pg.MainView;
            foreach (GridColumn c in g.Columns)
            {
                if(c.ColumnEdit!=null && c.ColumnEdit is RepositoryItemButtonEdit)
                {
                    foreach(EditorButton b in (c.ColumnEdit as RepositoryItemButtonEdit).Buttons)
                    {
                        Apply(b, c.Name+b.Index);
                    }
                    Apply(c.ColumnEdit, c.ColumnEdit.Name);
                }
                Apply(c, c.Name);
            }
            Apply(pg.EmbeddedNavigator, pg.Name+"TextStringFormat");
            
        }

        private void IteratePropertyGridControl(PropertyGridControl pgc)
        {
            IteratePropertyGridControl(pgc.Rows);
        }

        private void IteratePropertyGridControl(VGridRows rows)
        {
            foreach (BaseRow r in rows)
            {
                if (r.HasChildren) IteratePropertyGridControl(r.ChildRows);
                Apply(r.Properties, r.Properties.FieldName);
            }
        }

        private void IterateRibbon(RibbonControl rc)
        {
            for (int i = 0; i < rc.Manager.Items.Count; i++)
            {
                Apply(rc.Manager.Items[i], rc.Manager.Items[i].Name);
            }

            foreach (RibbonPage page in rc.Pages)
            {
                foreach (RibbonPageGroup group in page.Groups)
                {
                    Apply(group, group.Name);
                }
                Apply(page, page.Name);
            }
        }

        private void IterateRadioGroup(RadioGroupItemCollection items)
        {
            if (items == null || items.Count == 0) return;
            foreach(RadioGroupItem item in items)
            {
                if (item.Value == null) continue;
                Apply(item, item.Value.ToString());
            }

        }

        private void IterateChartControl(ChartControl chartControl)
        {
            if (chartControl == null) return;
            if (chartControl.Series != null && chartControl.Series.Count > 0)
            {
                Series item = null;
                for (int i=0;i<chartControl.Series.Count;i++)
                {
                    item = chartControl.Series[i];
                    if (item == null) continue;
                    Apply(item, chartControl.Name+"Series"+(i+1).ToString());
                }
            }
            if (chartControl.Titles != null && chartControl.Titles.Count > 0)
            {
                DevExpress.XtraCharts.ChartTitle item = null;
                for (int i = 0; i < chartControl.Titles.Count; i++)
                {
                    item = chartControl.Titles[i];
                    if (item == null) continue;
                    Apply(item, chartControl.Name + "Title" + (i + 1).ToString());
                }
            }
        }

        private void IterateLayoutControl(LayoutControl layoutControl)
        {
            if (layoutControl == null || layoutControl.Items.Count == 0) return;
            foreach (BaseLayoutItem item in layoutControl.Items)
            {
                Apply(item, item.Name);
            }

        }

    }
}
