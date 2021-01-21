using System;
using System.Collections.Generic;
using wayeal.language;

namespace wayeal.language
{
    public class ControlLocalizer : ResourecLocalizer<ControlStringId>
    {
        public override string Language { get { return "English"; } }

        #region PopulateStringTable
        protected override void PopulateStringTable()
        {
            AddString(ControlStringId.None,"");
        }
        #endregion
    }

    #region enum ControlStringId
    public enum ControlStringId
    {
        None,
        menuHelp,
    }
    #endregion
}
