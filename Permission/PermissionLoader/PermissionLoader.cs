using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wayeal.permission
{
    /// <summary>
    /// 权限模式
    /// </summary>
    public enum PermissionModes
    {
        pm_Enabled,
        pm_Visible
    }
    /// <summary>
    /// 权限对象
    /// </summary>
    public struct PermissionObject
    {
        public PermissionModes PermissionMode;
        public int PermissionValue;

        public PermissionObject(int pv)
        {
            PermissionMode = PermissionModes.pm_Enabled;
            PermissionValue = pv;
        }

        public PermissionObject(int pv,PermissionModes pm)
        {
            PermissionMode = pm;
            PermissionValue = pv;
            
        }
    }

    public class PermissionLoader<T> where T:struct
    {
        private SortedList<string, List<PermissionObject>> _PermissionTable = new SortedList<string, List<PermissionObject>>();
        private SortedList<T, List<PermissionObject>> _PermissionTable2 = new SortedList<T, List<PermissionObject>>();

        public PermissionLoader()
        {
            PopulatePermissionTable();
        }

        protected virtual void AddString(string key, PermissionObject value)
        {
            AddString(key, new List<PermissionObject>() { value });
        }
        protected virtual void AddString(string key, List<PermissionObject> values)
        {
            if (values == null && _PermissionTable.ContainsKey(key)) return;
            _PermissionTable.Add(key, values);
        }

        protected virtual void AddString(T key, PermissionObject value)
        {
            AddString(key,new List<PermissionObject>() { value });
        }

        protected virtual void AddString(T key, List<PermissionObject> values)
        {
            if (values == null && _PermissionTable2.ContainsKey(key)) return;
            _PermissionTable2.Add(key, values);
        }

        public virtual List<PermissionObject> GetPermission(string name)
        {
            if (_PermissionTable.ContainsKey(name))
                return _PermissionTable[name];
            if (Enum.IsDefined(typeof(T), name))
            {
                T constantName = (T)Enum.Parse(typeof(T), name);
                if (_PermissionTable2.ContainsKey(constantName)) return _PermissionTable2[constantName];
            }
            return null;
        }


        #region PopulatePermissionTable
        protected virtual void PopulatePermissionTable()
        {
        }
        #endregion
    }
}
