using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wayeal.validate
{
    public class ValidateLoader<T> where T : struct
    {
        private SortedList<string, object> _ValidTable = new SortedList<string, object>();
        private SortedList<T, object> _ValidTable2 = new SortedList<T, object>();

        public ValidateLoader()
        {
            PopulateStringTable();
        }

        protected virtual void AddString(string key, object fun)
        {
            if (fun == null && _ValidTable.ContainsKey(key)) return;
            _ValidTable.Add(key, fun);
        }

        protected virtual void AddString(T key, object fun)
        {
            if (fun == null && _ValidTable2.ContainsKey(key)) return;
            _ValidTable2.Add(key, fun);
        }

        public virtual object GetValidor(string name)
        {
            if (_ValidTable.ContainsKey(name))
                return _ValidTable[name];
            if (Enum.IsDefined(typeof(T), name))
            {
                T constantName = (T)Enum.Parse(typeof(T), name);
                if (_ValidTable2.ContainsKey(constantName)) return _ValidTable2[constantName];
            }
            return null;
        }


        #region PopulateValidateTable
        protected virtual void PopulateStringTable()
        {
        }
        #endregion
    }
}
