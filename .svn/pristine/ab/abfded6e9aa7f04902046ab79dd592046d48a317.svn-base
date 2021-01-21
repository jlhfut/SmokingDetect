using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.Modules;
using wayeal.os.exhaust.UserControls;

namespace wayeal.os.exhaust.Forms
{
    public partial class wfDataAnalysisVertical : wfBase
    {
        ucDataAnalysisTagPage ucpage = null;
        public wfDataAnalysisVertical()
        {
            InitializeComponent();
        }
        public wfDataAnalysisVertical( int index,ucExhaustData uc)
        {
            InitializeComponent();
            InitUI(index,uc);
            InitializeUI();
        }

        public void InitUI(int index,ucExhaustData uc)
        {
            if (ucpage == null)
            {
                ucpage = new ucDataAnalysisTagPage(index,uc);
                this.Controls.Add(ucpage);
                ucpage.Dock = DockStyle.Fill;
            }
            else
            {
                ucpage.RefrushData(index);
            }
        }
    }
}
