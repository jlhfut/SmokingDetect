using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wayeal.os.exhaust.Forms
{
    public partial class wfBase : DevExpress.XtraEditors.XtraForm
    {
        protected List<IPropertyBinding> _BindingList = new List<IPropertyBinding>();
        protected Dictionary<string, IPropertyBinding> _BindingList2 = new Dictionary<string, IPropertyBinding>();
        public wfBase()
        {
            InitializeComponent();
        }

        protected virtual void InitializeUI()
        {
            Program.resourceManager.ApplyLanguage(this);
            Program.permissionManager.ApplyPermission(this);
            Program.toolTipManager.ApplyLanguage(this);
            Program.validateManager.ApplyRegex(this);
        }

        /// <summary>
        /// Init
        /// </summary>
        protected virtual void InitializeBindings()
        {
            try
            {
                action();
            }
            catch { }
        }

        /// <summary>
        /// 增加绑定
        /// </summary>
        /// <param name="binding">绑定结果</param>
        protected virtual void AddBinding(IPropertyBinding binding)
        {
            _BindingList.Add(binding);
        }
        /// <summary>
        /// 增加绑定
        /// </summary>
        /// <param name="controlName">控件名</param>
        /// <param name="binding">绑定结果</param>
        protected virtual void AddBinding(string controlName, IPropertyBinding binding)
        {
            _BindingList2.Add(controlName, binding);
        }
        private delegate void doActionDelegate(string json);
        /// <summary>
        /// mvvm action
        /// </summary>
        /// <param name="json"></param>
        protected virtual void action(string json = "")
        {
            if (this.InvokeRequired)
            {
                doActionDelegate d = new doActionDelegate(doAction);
                this.BeginInvoke(d, json);
            }
            else
            {
                doAction(json);
            }
        }

        protected virtual void doAction(string json = "")
        {
            try
            {
                foreach (IPropertyBinding b in _BindingList) if (b != null) b.UpdateTarget();
                object o = null;
                foreach (string k in _BindingList2.Keys)
                {
                    o = this.GetType().GetField(k, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                    if (o is GridControl || (o is TextEdit && !(o as TextEdit).IsEditorActive) || (o is ComboBoxEdit && !(o as ComboBoxEdit).IsPopupOpen) || (o is CheckEdit && !(o as CheckEdit).IsEditorActive) || o is CheckedListBoxControl)
                        if (_BindingList2[k] != null) _BindingList2[k].UpdateTarget();
                }
            }
            catch { }
        }

        protected  override void OnLoad(EventArgs e)
        {
            //弹窗overlay，暂不用实现。
            base.OnLoad(e);
        }
    }
}
