using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.ViewModel;
using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using Wayee.Services;
using static wayeal.os.exhaust.SystemParamInfo;
using wayeal.os.exhaust.Services;
using Wayeal.Services.Business.Utils;
using DevExpress.XtraEditors;

namespace wayeal.os.exhaust.Modules
{
    public partial class ucStationSettings : ucManagerBase
    {
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        public ucStationSettings()
        {
            InitializeComponent();
            InitializeUI();
            InitComboBox();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        private void InitComboBox()
        {
            cbeStationType.Properties.Items.Clear();
            cbeStationType.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.Fixed));
            cbeStationType.Properties.Items.Add(Program.infoResource.GetLocalizedString(language.InfoId.Moved));
        }
        /// <summary>
        /// Init
        /// </summary>
        protected override void InitializeBindings()
        {
            try
            {
                string s = "";
                mvvmContext1.SetViewModel(typeof(ResultDataViewModel), ResultDataViewModel.VM);
                fluent = mvvmContext1.OfType<ResultDataViewModel>();
                ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryOtherParam });
                AddBinding(fluent.SetBinding(teID, ce => ce.Text, x => x.OtherParamEntities, m =>
                {
                    if (m.Count < 1||m[0]==null) return "";
                    return ((DTOtherParamInfo)m[0]).StationNumber.Value == null ? "" : ((DTOtherParamInfo)m[0]).StationNumber.Value.ToString();
                }));
                AddBinding(fluent.SetBinding(teStationName, ce => ce.Text, x => x.OtherParamEntities, m =>
                {
                    if (m.Count < 1 || m[0] == null) return "";
                    return ((DTOtherParamInfo)m[0]).Name.Value == null ? "" : ((DTOtherParamInfo)m[0]).Name.Value.ToString ();
                }));
                AddBinding(fluent.SetBinding(teLangitude, ce => ce.Text, x => x.OtherParamEntities, m =>
                {
                    if (m.Count < 1 || m[0] == null) return "0";
                    return ((DTOtherParamInfo)m[0]).Longitude.Value == null ? "0" : ((DTOtherParamInfo)m[0]).Longitude.Value.ToString ();
                }));
                AddBinding(fluent.SetBinding(teLatitude, ce => ce.Text, x => x.OtherParamEntities, m =>
                {
                    if (m.Count < 1 || m[0] == null) return "0";
                    return ((DTOtherParamInfo)m[0]).Latitude.Value == null ? "0" : ((DTOtherParamInfo)m[0]).Latitude.Value.ToString ();
                }));
                AddBinding(fluent.SetBinding(teSlope, ce => ce.Text, x => x.OtherParamEntities, m =>
                {
                    if (m.Count < 1 || m[0] == null) return "0";
                    return ((DTOtherParamInfo)m[0]).Slope.Value == null ? "0" :((DTOtherParamInfo)m[0]).Slope.Value.ToString ();
                }));
                AddBinding(fluent.SetBinding(teHighly, ce => ce.Text, x => x.OtherParamEntities, m =>
                {
                    if (m.Count < 1 || m[0] == null) return "0";
                    return ((DTOtherParamInfo)m[0]).Highly.Value == null ? "0" : ((DTOtherParamInfo)m[0]).Highly.Value.ToString ();
                }));
                AddBinding(fluent.SetBinding(teDetialedAddress, ce => ce.Text, x => x.OtherParamEntities, m =>
                {
                    if (m.Count < 1 || m[0] == null) return "";
                    return ((DTOtherParamInfo)m[0]).DetialedAddress.Value == null ? "" : ((DTOtherParamInfo)m[0]).DetialedAddress.Value.ToString ();
                }));
                AddBinding(fluent.SetBinding(meTips, ce => ce.Text, x => x.OtherParamEntities, m =>
                {
                    if (m.Count < 1 || m[0] == null) return "";
                    return ((DTOtherParamInfo)m[0]).Tips.Value == null ? "" : ((DTOtherParamInfo)m[0]).Tips.Value.ToString ();
                }));
                AddBinding(fluent.SetBinding(cbeStationType, ce => ce.SelectedIndex, x => x.OtherParamEntities, m =>
                {
                    if (m.Count < 1 || m[0] == null) return -1;
                    return ((DTOtherParamInfo)m[0]).StationType.Value == null ? -1: Convert.ToInt32(((DTOtherParamInfo)m[0]).StationType.Value.ToString());
                }));
                ResultDataViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == ResultDataViewModel.ExecuteCommand.ec_QueryOtherParam.ToString()) action();
                };

                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        /// <summary>
        /// mvvm action
        /// </summary>
        /// <param name="json"></param>
        protected override void doAction(string json = "")
        {
            base.doAction();
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            if (teID.Text.Trim() == "" || teStationName.Text.Trim() == "" || teLangitude.Text.Trim() == "" || teLatitude.Text.Trim() == "" || teSlope.Text.Trim() == "" || teHighly.Text.Trim() == "" || teDetialedAddress.Text.Trim() == ""||meTips.Text.Trim() == ""||cbeStationType.SelectedIndex==-1)
            {
                //必填项不能为空
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.InputNotNull));
            }
            else
            { 
                DialogResult rs= XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.SaveChange),"",MessageBoxButtons.OKCancel);
                if (rs == DialogResult.OK)
                {
                    string log = Program.infoResource.GetLocalizedString(language.InfoId.ChangeOtherParam);
                    //表中有数据则调用修改，无数据则调用插入
                    if (ResultDataViewModel.VM.OtherParamEntities.Count > 0)
                    {
                        try
                        {
                            log += ErrorLog.JointLogContent(lcID.Text, false, false, ((DTOtherParamInfo)ResultDataViewModel.VM.OtherParamEntities[0]).StationNumber.ToString(), teID.Text);
                            log += ErrorLog.JointLogContent(lcStationName.Text, false, false, ((DTOtherParamInfo)ResultDataViewModel.VM.OtherParamEntities[0]).Name.ToString(), teStationName.Text);
                            log += ErrorLog.JointLogContent(lcLongitude.Text, false, false, ((DTOtherParamInfo)ResultDataViewModel.VM.OtherParamEntities[0]).Longitude.ToString(), teLangitude.Text);
                            log += ErrorLog.JointLogContent(lcLatitude.Text, false, false, ((DTOtherParamInfo)ResultDataViewModel.VM.OtherParamEntities[0]).Latitude.ToString(), teLatitude.Text);
                            log += ErrorLog.JointLogContent(lcHighly.Text, false, false, ((DTOtherParamInfo)ResultDataViewModel.VM.OtherParamEntities[0]).Highly.ToString(), teHighly.Text);
                            log += ErrorLog.JointLogContent(lcSSlope.Text, false, false, ((DTOtherParamInfo)ResultDataViewModel.VM.OtherParamEntities[0]).Slope.ToString(), teSlope.Text);
                            log += ErrorLog.JointLogContent(lcDetailedAddress.Text, false, false, ((DTOtherParamInfo)ResultDataViewModel.VM.OtherParamEntities[0]).DetialedAddress.ToString(), teDetialedAddress.Text);
                            log += ErrorLog.JointLogContent(lcTips.Text, false, false, ((DTOtherParamInfo)ResultDataViewModel.VM.OtherParamEntities[0]).Tips.ToString(), meTips.Text);
                            log += ErrorLog.JointLogContent(cbeStationType.Text, false, false, cbeStationType.Properties.Items[Convert.ToInt32(((DTOtherParamInfo)ResultDataViewModel.VM.OtherParamEntities[0]).StationType.Value.ToString())].ToString(), meTips.Text);

                        }
                        catch
                        { }
                        ResultDataViewModel.VM.Execute(new List<object> {
                    ResultDataViewModel.ExecuteCommand.ec_ChangeOtherParam,
                    teID.Text,
                    teStationName.Text,
                    teLangitude.Text,
                    teLatitude.Text,
                    teHighly.Text,
                    teSlope.Text,
                    teDetialedAddress.Text,
                    meTips.Text,
                    cbeStationType.SelectedIndex
                    });
                        if (ResultDataViewModel.VM.ChangeOtherParamResult)
                        {
                            log += Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess);
                            XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.ChangeSuccess));
                            SendCmdToSOA();
                        }
                        else
                        {
                            log += Program.infoResource.GetLocalizedString(language.InfoId.OperateFail);
                            XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.ChangeFail));
                        }
                    }
                    else
                    {
                        log += ErrorLog.JointLogContent(lcID.Text, false, false, "", teID.Text);
                        log += ErrorLog.JointLogContent(lcStationName.Text, false, false, "", teStationName.Text);
                        log += ErrorLog.JointLogContent(lcLongitude.Text, false, false, "", teLangitude.Text);
                        log += ErrorLog.JointLogContent(lcLatitude.Text, false, false, "", teLatitude.Text);
                        log += ErrorLog.JointLogContent(lcHighly.Text, false, false,"", teHighly.Text);
                        log += ErrorLog.JointLogContent(lcSSlope.Text, false, false, "", teSlope.Text);
                        log += ErrorLog.JointLogContent(lcDetailedAddress.Text, false, false, "", teDetialedAddress.Text);
                        log += ErrorLog.JointLogContent(lcTips.Text, false, false, "", meTips.Text);
                        log += ErrorLog.JointLogContent(cbeStationType.Text, false, false, "", meTips.Text);

                        ResultDataViewModel.VM.Execute(new List<object> {
                    ResultDataViewModel.ExecuteCommand.ec_InsertOtherParam,
                    teID.Text,
                    teStationName.Text,
                    teLangitude.Text,
                    teLatitude.Text,
                    teHighly.Text,
                    teSlope.Text,
                    teDetialedAddress.Text,
                    meTips.Text,
                    cbeStationType.SelectedIndex
                    });
                        if (ResultDataViewModel.VM.InserOtherParamResult)
                        {
                            log += Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess);
                            XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.SaveCompleted));
                            SendCmdToSOA();
                        }
                        else
                        {
                            log += Program.infoResource.GetLocalizedString(language.InfoId.OperateFail);
                            XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.SaveFail));
                        }
                    }
                    ErrorLog.SystemLog(DateTime.Now, log, this.OwnerForm.GetUserName());
                }
            }
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            if (ResultDataViewModel.VM.OtherParamEntities.Count > 0 && ResultDataViewModel.VM.OtherParamEntities[0] != null)
            {
                action();
            }
        }
        /// <summary>
        /// 站点设置被修改后下发命令通知服务端
        /// </summary>
        private void SendCmdToSOA()
        {
            try
            {
                OtherParamInfo oth = new OtherParamInfo();
                oth.StationNumber = teID.Text;
                oth.Name = teStationName.Text;
                oth.Longitude = teLangitude.Text;
                oth.Latitude = teLatitude.Text;
                oth.Highly = Convert.ToDouble(teHighly.Text);
                oth.Slope = Convert.ToDouble(teSlope.Text);
                oth.DetialedAddress = teDetialedAddress.Text;
                oth.Tips = meTips.Text;
                oth.StationType = cbeStationType.SelectedIndex;
                string str = JsonNewtonsoft.ToJSON(oth);
                if (str != "") BusinessServiceHelper.Instanse.ExecuteBusiness(ExternalBusinessCmd.SetStationInfo, str);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }

        }
        /// <summary>
        /// 移动式不需要经纬度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbeStationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbeStationType.SelectedIndex == 1)
            {
                teLangitude.Enabled = false;
                teLatitude.Enabled = false;
            }
            else
            {
                teLangitude.Enabled = true;
                teLatitude.Enabled = true;
            }
        }
    }
}
