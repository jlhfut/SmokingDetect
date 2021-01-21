using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace wayeal.os.exhaust.UserControls
{
    public partial class ucComponent : ucBase
    {
        public ucComponent()
        {
            InitializeComponent();
        }
        public override string Text { get => ComponentName; set => ComponentName = value; }
        /// <summary>
        /// component name.
        /// </summary>
        public string ComponentName
        {
            get { return lcTitle.Text; }
            set {
                int idx = value.Replace('（', '(').IndexOf('(');
                int idx2 = value.Replace('）', ')').IndexOf(')');
                if (idx != -1 && idx2 != -1)
                {
                    lcTitle.Text = value.Substring(0, idx);
                    lcUnit.Text = value.Substring(idx + 1, idx2 - idx - 1);
                }
                else
                    lcTitle.Text = value;
            }
        }
        /// <summary>
        /// component value.
        /// </summary>
        public string ComponentValue
        {
            get { return lcValue.Text; }
            set {
                    lcValue.Text = value;
            }
        }

        /// <summary>
        /// component unit.
        /// </summary>
        public string ComponentUnit
        {
            get { return lcUnit.Text; }
            set { lcUnit.Text = value; }
        }


        public override Font Font {
            get => base.Font;
            set
            {
                base.Font = value;
                lcTitle.Font = value;
                lcValue.Font = value;
            }
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                lcTitle.ForeColor = value;
                //lcValue.ForeColor = value;
            }
        }

        public Color ValueForeColor
        {
            get => lcValue.ForeColor;
            set
            {
                //base.ForeColor = value;
                //lcTitle.ForeColor = value;
                lcValue.ForeColor = value;
            }
        }
    }
}
