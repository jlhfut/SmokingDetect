using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace wayeal.os.exhaust.ViewModel
{
    public enum ViewModelMessages
    {
        CalibrationParamter,
    }

    public class BaseViewModel
    {
        #region Model Event 
        public class ModelEventArgs : EventArgs
        {
            public ModelEventArgs(string name)
            {
                ModelName = name;
            }
            public string ModelName { get; set; }
        }
        public delegate void ModelEventHandler(object sender, ModelEventArgs e);
        
        #endregion
    }


}
