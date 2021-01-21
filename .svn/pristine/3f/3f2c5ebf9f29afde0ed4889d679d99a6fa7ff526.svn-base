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
using wayeal.os.exhaust.ViewModel;

namespace wayeal.os.exhaust.UserControls
{
    enum labelName
    {
        gasoline=0,
        diesel=1,
        history=2
    }

    public delegate void OnLabelClickEvent(int labelName);
    public partial class ucLimtingLabel : ucBase
    {
        public event OnLabelClickEvent LabelClick;
        public ucLimtingLabel()
        {
            InitializeComponent();
            Program.resourceManager.ApplyLanguage(this);
        }

        private void ucLimtingLabel_Load(object sender, EventArgs e)
        {
            //初始化颜色
            lcGasolineCar.ForeColor = Color.DodgerBlue;
            lcGasolineCar.Font = new Font(lcGasolineCar.Font, FontStyle.Bold);
            lcDieselCar.ForeColor = Color.Black;
            lcHistoryRecord.ForeColor = Color.Black;
        }

        private  void lblGasolineCar_Click(object sender, EventArgs e)
        {
         
            lcGasolineCar.ForeColor = Color.DodgerBlue;
            lcGasolineCar.Font=new Font(lcGasolineCar.Font,FontStyle.Bold);
            lcDieselCar.ForeColor = Color.Black;
            lcDieselCar.Font = new Font(lcDieselCar.Font, FontStyle.Regular);
            lcHistoryRecord.ForeColor = Color.Black;
            lcHistoryRecord.Font = new Font(lcHistoryRecord.Font, FontStyle.Regular);

            if (LabelClick != null)
            {
                LabelClick((int)(labelName.gasoline));
            }
        }

        private void lblDieselCar_Click(object sender, EventArgs e)
        {
            lcGasolineCar.ForeColor = Color.Black;
            lcGasolineCar.Font = new Font(lcGasolineCar.Font, FontStyle.Regular);
            lcDieselCar.ForeColor = Color.DodgerBlue;
            lcDieselCar.Font = new Font(lcDieselCar.Font, FontStyle.Bold);
            lcHistoryRecord.ForeColor = Color.Black;
            lcHistoryRecord.Font = new Font(lcHistoryRecord.Font, FontStyle.Regular);

            if (LabelClick != null)
            {
                LabelClick((int)(labelName.diesel));
            }
        }

        private void lblHistoryRecord_Click(object sender, EventArgs e)
        {
            lcGasolineCar.ForeColor = Color.Black;
            lcGasolineCar.Font = new Font(lcGasolineCar.Font, FontStyle.Regular);
            lcDieselCar.ForeColor = Color.Black;
            lcDieselCar.Font = new Font(lcDieselCar.Font, FontStyle.Regular);
            lcHistoryRecord.ForeColor = Color.DodgerBlue;
            lcHistoryRecord.Font = new Font(lcHistoryRecord.Font, FontStyle.Bold);
            if (LabelClick != null)
            {
                LabelClick((int)(labelName.history));
            }
        }
    }
}
