using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wayeal.validate;

namespace wayeal.os.exhaust.ViewModel
{
    public class BaseModel//: ViewModelBase
    {
        protected virtual bool Validate(string name, object value)
        {
            string key = name;// this.GetType().Name + "." + name;
            ValidateResult vs = Program.validateManager.Validate(key, value);
            return vs.Valid;
        }

        public string GetValidor(string name)
        {
            object rs= Program.validateManager.GetValidor(name);
            if (rs != null && rs is string) return rs.ToString();
            return null;
        }
    }
}
