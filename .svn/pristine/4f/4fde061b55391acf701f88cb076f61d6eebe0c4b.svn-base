using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using wayeal.os.exhaust.ViewModel;
using DevExpress.Mvvm;
using Wayee.Services;
using wayeal.os.exhaust.Services;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraEditors;
using System.Collections;
using System.Threading;
using DevExpress.XtraSplashScreen;

namespace wayeal.os.exhaust.Modules
{
    public partial class ucConcentrationCalibrator : ucManagerBase
    {
        #region defines
        ModulesNavigator viewNavigator = null;
        private ControlCollection _settingControl = null;
        public static List<Control> SettingControl { get; } = new List<Control>();
        ComboBoxEdit cbeAnalysis = null;
        private string _analysisName=null;
        private string AnalysisName
        {
            get { return _analysisName; }
            set {
                int i = Convert.ToInt32(value);
                _analysisName = "Analysis" + (i % 2 == 0 ? "L" : "R") + (i/2 + 1);
                }
        }
        private List<string> analysisNameList = new List<string>() { "1车道左侧","1车道右侧","2车道左侧","2车道右侧","3车道左侧","3车道右侧" };
        private Dictionary<int, bool> dicAnalysisDebugMode=new Dictionary<int, bool>();
        public static Dictionary<Control, string> DicRecordLog
        {
            get { return _dicRecordLog; }
            set { _dicRecordLog = value; }
        }
        static Dictionary<Control, string> _dicRecordLog = new Dictionary<Control, string>();
        #endregion
        public ucConcentrationCalibrator()
        {
            InitializeComponent();
            InitializeUI();
            SetPointCorrectView();
            SetCbeLaneView();
            RefTimer = new System.Threading.Timer((object o) => { InitControlDicValue(); }, null, System.Threading.Timeout.Infinite, 0);
            InitControlDicValue();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }
        public void InitControlDicValue()
        {
            RefTimer.Change(System.Threading.Timeout.Infinite, 0);
        //    ErrorLog.Error("---");
            _dicRecordLog.Clear();
            _settingControl = tpSettings.Controls;
            InitSettingControl(tpSettings.Controls);
            InitDictionary(_settingControl);
        }
        /// <summary>
        /// 设置车道分析仪是否存在
        /// </summary>
        [Conditional("VerticalDistribution")]
        private void SetCbeLaneView()
        {
            cbeAnalysis = new ComboBoxEdit();
            cbeAnalysis.Size = new Size(135, 20);
            foreach (string s in analysisNameList)
            {
                cbeAnalysis.Properties.Items.Add(s);
            }
            panelControl4.Controls.Add(cbeAnalysis);
            cbeAnalysis.Location = new Point(347, 7);
            cbeAnalysis.SelectedIndex = 0;
            cbeAnalysis.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cbeAnalysis.Properties.AllowFocused = false;
            cbeAnalysis.SelectedIndexChanged += cbeAnalysis_SelectedIndexChanged;
            cbeAnalysis.SelectedIndex = 0;

            for (int i = 0; i < analysisNameList.Count; i++)
            {    //默认所有分析仪初始状态均为未进入调试模式
                dicAnalysisDebugMode.Add(i,false);
            }
        }

        /// <summary>
        /// 设置是否存在点修正按钮
        /// </summary>
        private void SetPointCorrectView()
        {
            try
            {
                string dbPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                if (!File.Exists(dbPath + "certification.txt"))
                {
                    (ucCalibration.Controls.Find("sbPointCorrect", true)[0]).Size = new Size(0,0);
                    (ucCalibration.Controls.Find("sbPointCorrect", true)[0]).Enabled = false;
                    ucCalibration.Controls.Remove(ucCalibration.Controls.Find("sbPointCorrect", true)[0]);
                }
            }
            catch(Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Init
        /// </summary>
        protected override void InitializeBindings()
        {
            try
            {
                viewNavigator = new ModulesNavigator(Program.frmMain.Ribbon, pcClient);
               
                InitBarItemLinks();

                mvvmContext1.SetViewModel(typeof(CalibrationViewModel.DebugModel), CalibrationViewModel.VM.Debug);
                var fluent = mvvmContext1.OfType<CalibrationViewModel.DebugModel>();
     //           AddBinding(fluent.SetBinding(sbExitCalibrationMode, uc => uc.Visible, x => x.Mode));
                AddBinding(fluent.SetBinding(rgSpectralView, r => r.SelectedIndex, x => x.Type));

                Messenger.Default.Register<string>(this, typeof(CalibrationViewModel.DebugModel).Name, action);
                Messenger.Default.Register(this, typeof(CalibrationViewModel.AccelerationModel).Name, (CalibrationViewModel.AccelerationModel m)=> {
                    ErrorLog.Error("刷新控件目录："+DateTime.Now.ToString("HH:mm:ss fff"));
                    InitControlDicValue(); });
                CalibrationViewModel.VM.ModelChanged += (sender, arg) => {
                    if (arg.ModelName == typeof(CalibrationViewModel.DebugModel).Name)
                        action();
                };
                ResultDataViewModel.VM.ModelChanged += (sender, arg) =>
                {
                    if (arg.ModelName == "CloseAPP") ExitCalibrationMode();
                };
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }

        private void ExitCalibrationMode()
        {
            try
            {
                string strLog = "";
                for (int i = 0; i < dicAnalysisDebugMode.Count; i++)
                {
                    if (dicAnalysisDebugMode[i])
                    {
                        AnalysisName = i.ToString();
                        bool rs = CalibrationViewModel.VM.SwitchDebugMode(false, _analysisName);
                        strLog += analysisNameList[i] +Program.infoResource.GetLocalizedString(language.InfoId.OutCalibrationMode)+
                            (rs ? Program.infoResource.GetLocalizedString(language.InfoId.OpearteSuccess) : Program.infoResource.GetLocalizedString(language.InfoId.OperateFail)) + ";";
                    }
                }
                if(!String.IsNullOrEmpty(strLog.Trim())) ErrorLog.SystemLog(DateTime.Now, strLog);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
        }

        /// <summary>
        /// mvvm action
        /// </summary>
        /// <param name="json"></param>
        protected override void doAction(string json = "")
        {
            base.doAction(json);
            tmCalibrateMonitor.Enabled = false;
            SetUI();
        }
        /// <summary>
        /// 设置UI状态 
        /// </summary>
        /// <param name="flag"></param>
        private void SetUI(bool flag=true)
        {
            bool v = sbExitCalibrationMode.Visible;
            sbExitCalibrationMode.Enabled = v & flag;
            sbEnterCalibrationMode.Visible = !v;
            sbEnterCalibrationMode.Enabled = !v & flag;

            bool e = sbExitCalibrationMode.Enabled;
            ucCalibrationParamter.Enabled = v & e;
            ucCalibration.Enabled = v & e;
            gcUnitSettings.Enabled = v & e;
        }

        /// <summary>
        /// init expriment mode
        /// </summary>
        void InitBarItemLinks()
        {
            rgSpectralView.Properties.Items[0].Tag = new NavBarGroupTagObject(rgSpectralView.Properties.Items[0].Value.ToString(), typeof(UserControls.ucCalibrationHarmonicView));
            rgSpectralView.Properties.Items[1].Tag = new NavBarGroupTagObject(rgSpectralView.Properties.Items[1].Value.ToString(), typeof(UserControls.ucCalibrationSpectrumView));
            rgSpectralView.Properties.Items[2].Tag = new NavBarGroupTagObject(rgSpectralView.Properties.Items[2].Value.ToString(), typeof(UserControls.ucCalibrationConcentrationView));
            rgSpectralView.Properties.Items[3].Tag = new NavBarGroupTagObject(rgSpectralView.Properties.Items[2].Value.ToString(), typeof(UserControls.ucCalibrationDebugView));
            rgSpectralView.SelectedIndex = 0;
        }

        private void rgSpectralView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rgSpectralView.Properties.Items[rgSpectralView.SelectedIndex].Tag != null)
                {
                    NavBarItemLink link = new NavBarItemLink(new NavBarItem(rgSpectralView.Properties.Items[rgSpectralView.SelectedIndex].Value.ToString()));
                    link.Item.Tag = rgSpectralView.Properties.Items[rgSpectralView.SelectedIndex].Tag;
                    viewNavigator.ChangeSelectedItem(link, null);
                    rgSpectralView.Enabled = false;
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
            finally
            {
                rgSpectralView.Enabled = true;
            }
        }
        /// <summary>
        /// 进入-退出校准模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbCalibrationMode_Click(object sender, EventArgs e)
        {
            try
            {
                (sender as SimpleButton).Enabled = false;
                bool rs= CalibrationViewModel.VM.SwitchDebugMode(sender == sbEnterCalibrationMode, _analysisName);
                

                if (sender == sbEnterCalibrationMode)
                {
                    //  sbEnterCalibrationMode.Enabled = !rs;
                    sbExitCalibrationMode.Visible = rs;
                    sbExitCalibrationMode.Enabled = rs;
                    ErrorLog.SystemLog(DateTime.Now, Program.infoResource.GetLocalizedString(language.InfoId.EnterCalibrationMode)+cbeAnalysis.SelectedText+(rs?"":"进入校准模式失败"), this.OwnerForm.GetUserName());
                    tmCalibrateMonitor.Enabled = true;
                    if (cbeAnalysis != null)
                    {
                        dicAnalysisDebugMode[cbeAnalysis.SelectedIndex]=rs;
                    }
                }
                else
                {
                    // sbExitCalibrationMode.Enabled = !rs;
                    sbExitCalibrationMode.Visible = !rs;
                    sbExitCalibrationMode.Enabled = !rs;
                    ErrorLog.SystemLog(DateTime.Now, Program.infoResource.GetLocalizedString(language.InfoId.OutCalibrationMode) + cbeAnalysis.SelectedText, this.OwnerForm.GetUserName());
                    if (cbeAnalysis != null)
                    {
                        dicAnalysisDebugMode[cbeAnalysis.SelectedIndex] = !rs;
                    }
                }
                SetUI();
                
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        /// <summary>
        /// 初始化目录，获取所有待校准控件的值
        /// </summary>
        private void InitDictionary(ControlCollection cc)
        {
            try
            {
                foreach (Control uc in cc)
                {
                    if (uc.Controls != null) InitDictionary(uc.Controls);
                    if (uc is DevExpress.XtraEditors.TextEdit)
                        _dicRecordLog.Add(uc, uc.Text);
                    if (uc is DevExpress.XtraEditors.CheckEdit)
                        _dicRecordLog.Add(uc, (uc as DevExpress.XtraEditors.CheckEdit).EditValue.ToString());
                    if (uc is DevExpress.XtraEditors.ComboBoxEdit)
                        _dicRecordLog.Add(uc, (uc as DevExpress.XtraEditors.ComboBoxEdit).SelectedItem.ToString());
                }
            }
            catch(Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
        }
        private void InitSettingControl(ControlCollection cc)
        {
            foreach (Control uc in cc)
            {
                if (uc.Controls != null) InitSettingControl(uc.Controls);
                if (uc is DevExpress.XtraEditors.LabelControl&&!SettingControl.Contains(uc))
                    SettingControl.Add(uc);
            }
        }

        private void tmCalibrateMonitor_Tick(object sender, EventArgs e)
        {
            try
            {
                tmCalibrateMonitor.Enabled = false;
                //进入按钮不使能，进入按钮可见=>进入按钮使能
                if (!sbEnterCalibrationMode.Enabled && sbEnterCalibrationMode.Visible) sbEnterCalibrationMode.Enabled = true ;
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
        }
        System.Threading.Timer RefTimer = null;
        
        /// <summary>
        /// 切换车道
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbeAnalysis_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender is ComboBoxEdit)
                {
                    int i = (sender as ComboBoxEdit).SelectedIndex;
                    if (i < 0) return;
                    AnalysisName = i.ToString();
                    CalibrationViewModel.AnalysisName = _analysisName;
                    
                    //根据车道切换调试按钮状态,默认未进入调试模式
                    bool buttonStatue = false;
                    dicAnalysisDebugMode.TryGetValue(i, out buttonStatue);

                    ErrorLog.SystemLog(DateTime.Now, "切换至车道:" + analysisNameList[i]);

                    sbExitCalibrationMode.Visible = buttonStatue;
                    sbExitCalibrationMode.Enabled = buttonStatue;
                    SetUI();
                    sbExitCalibrationMode.Focus();
                    //设备切换后刷新一下
                    CalibrationViewModel.VM.Execute(new ArrayList() { CalibrationViewModel.ExecuteCommand.ec_RefreshAll });
                    RefTimer.Change(1500,0);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.ToString());
            }
        }

    }
}
