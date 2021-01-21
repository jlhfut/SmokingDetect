using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wayeal.os.exhaust.Modules
{
    public partial class ucLogManager : ucManagerBase
    {
        public ucLogManager(UserControl view)
        {
            InitializeComponent();
            if(view!=null)
            {
                view.Parent = this;
                view.Dock = DockStyle.Fill;
                view.BringToFront();
            }
            InitializeUI();
        }
    }
}
