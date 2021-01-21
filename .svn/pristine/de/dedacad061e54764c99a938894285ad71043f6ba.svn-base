using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.MVVM;

namespace wayeal.plugin
{
    public partial class ucBase : ucPluginBase
    {
        public ucBase()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

            }
        }
        ~ucBase()
        {
            _Dispose = true;
        }

        protected List<IPropertyBinding> _BindingList = new List<IPropertyBinding>();
        private bool _Dispose = false;
        protected bool _Busy = false;
        /// <summary>
        /// Init
        /// </summary>
        protected virtual void InitializeBindings()
        {
            doAction();
        }
        /// <summary>
        /// 增加绑定
        /// </summary>
        /// <param name="binding">绑定结果</param>
        protected virtual void AddBinding(IPropertyBinding binding)
        {
            _BindingList.Add(binding);
        }

        private delegate void doActionDelegate(string json);
        /// <summary>
        /// mvvm action
        /// </summary>
        /// <param name="json"></param>
        protected virtual void action(string json = "")
        {
            //GC.Collect();
            if (_Dispose) return;
            if (this.InvokeRequired)
            {
                doActionDelegate d = new doActionDelegate(doAction);
                this.BeginInvoke(d, json);
            }
            else
            {
                if (_Busy) return;
                try
                {
                    _Busy = true;
                    doAction(json);
                }
                finally
                {
                    _Busy = false;
                }
            }
        }

        protected virtual void doAction(string json = "")
        {
            foreach (IPropertyBinding b in _BindingList) b.UpdateTarget();
        }
    }
}
