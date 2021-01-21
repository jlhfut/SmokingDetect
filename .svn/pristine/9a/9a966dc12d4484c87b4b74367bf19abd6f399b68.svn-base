using DevExpress.XtraBars.Ribbon;
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
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraBars;
using wayeal.utils;
using DevExpress.XtraBars.Navigation;

namespace wayeal.permission
{
    public class PermissionManager<T> : ControlIterate  where T : struct
    {
        #region definds
        private PermissionLoader<T> permissionLoader;
        #endregion

        #region perperties
        private int activePermission = 3;
        /// <summary>
        /// active permission value.
        /// </summary>
        public int ActivePermission
        {
            get { return activePermission; }
            set { activePermission = value; }
        }
        #endregion

        public PermissionManager(PermissionLoader<T> pl)
        {
            permissionLoader = pl;
        }

        protected override void Apply(object obj, string objectName)
        {
            if (obj == null || objectName == "") return;
            System.Console.WriteLine(objectName);
            List<PermissionObject> po = null;
            if (permissionLoader != null) po = permissionLoader.GetPermission(objectName);
            if (po == null) return;
            foreach (PermissionObject p in po)
            {
                PropertyInfo pinfo = obj.GetType().GetProperty(p.PermissionMode == PermissionModes.pm_Enabled ? "Enabled" : "Visible");
                if (obj is TabNavigationPage)
                {
                    pinfo = obj.GetType().GetProperty("PageVisible");
                    if (pinfo != null && pinfo.CanWrite)
                        pinfo.SetValue(obj, p.PermissionValue >= ActivePermission );
                    continue;
                }
                if (pinfo != null && pinfo.CanWrite)
                    pinfo.SetValue(obj, p.PermissionValue >= ActivePermission);
                else if (p.PermissionMode == PermissionModes.pm_Visible)
                {
                    pinfo = obj.GetType().GetProperty("Visibility");
                    if (pinfo != null && pinfo.CanWrite)
                    {
                        pinfo.SetValue(obj, p.PermissionValue >= ActivePermission ? BarItemVisibility.Always : BarItemVisibility.Never);
                        continue;
                    }
                }
            }
        }

        protected override void Iterate(Control parent)
        {
            base.Iterate(parent);
        }

        public void ApplyPermission(Control parent)
        {
            base.Iterate(parent);
        }
    }
}
