using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.ViewModel;

namespace wayeal.os.exhaust.Forms
{
    public partial class wfNewCom : wfBase
    {
        string[] IllelegalCharacter = { " ", };

        public wfNewCom()
        {
            InitializeComponent();
            InitializeUI();
            InitCombobox();
        }
        /// <summary>
        /// 初始化下拉框
        /// </summary>
        private void InitCombobox()
        {
            cbeComType.Properties.Items.Clear();
            cbeComType.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.ComCOM));
            cbeComType.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.ComTCP));
            cbeComType.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.ComUDP));
            cbeComType.SelectedIndex = 0;
        }
        private void sbConfirm_Click(object sender, EventArgs e)
        {
            //通讯名和下拉选项不能为空
            if (teNewComName.Text.Equals(string.Empty) || cbeComType.SelectedIndex < 0)
            {
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.InputNotNull), "", MessageBoxButtons.OK);
                return;
            }
            //不能含有空格等非法字符
            foreach (string s in IllelegalCharacter)
            {
                if (teNewComName.Text.Contains(s))
                {
                    XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.CheckInput), "", MessageBoxButtons.OK);
                    return;
                }
            }
            //查询该通讯名是否已存在
            ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryCommunicationInfo, teNewComName.Text});
            if (ResultDataViewModel.VM.QueryComSingleEntities != null && ResultDataViewModel.VM.QueryComSingleEntities.Count != 0)
            {
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.UserNameExist), "", MessageBoxButtons.OK);
                return;
            }
            string comType = null;
            switch (cbeComType.SelectedIndex)
            {
                case 0: comType = "ComCOM"; break;
                case 1: comType = "ComTCP"; break;
                case 2: comType = "ComUDP"; break;
                default: break;
            }
            ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_InsertCommunicationInfo, teNewComName.Text, comType });
            if (ResultDataViewModel.VM.NewComInfoEntities)
            {
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess), "", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.OperateFail), "", MessageBoxButtons.OK);
            }
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
