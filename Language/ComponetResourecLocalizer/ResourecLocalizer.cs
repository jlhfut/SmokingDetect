using DevExpress.Utils.Localization;
using System;
using System.Collections.Generic;

namespace wayeal.language
{
    public class ResourecLocalizer<T>: XtraLocalizer<T> where T : struct
    {
        protected SortedList<string, string> _StringTable = new SortedList<string, string>();

        protected virtual void AddString(string key,string value)
        {
            _StringTable.Add(key, value);
        }

        #region string GetLocalizedText(string functionCaption)
        public virtual string GetLocalizedText(string name)
        {
            if (_StringTable.ContainsKey(name)) return _StringTable[name];
            if (Enum.IsDefined(typeof(T), name))
            {
                T constantName = (T)Enum.Parse(typeof(T), name);
                return base.GetLocalizedString(constantName);
            }
            return "";
        }
        #endregion


        public override XtraLocalizer<T> CreateResXLocalizer()
        {
            return null;
        }

        public SortedList<string, string> StringTable { get { return _StringTable; } }

        #region PopulateStringTable
        protected override void PopulateStringTable()
        {
        }
        #endregion
    }
}
