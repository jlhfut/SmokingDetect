using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wayeal.os.exhaust.Forms;
using wayeal.os.exhaust.Modules;
using wayeal.os.exhaust.UserControls;
using wayeal.os.exhaust.ViewModel;

namespace wayeal.os.exhaust
{
    public partial class wfDetialMessage : wfBase
    {
        int iIndex;
        string iType;
        //ucDataMessageGasoline ucGaso = new ucDataMessageGasoline();
        //ucDataMessageDieselCar ucDiesel = new ucDataMessageDieselCar();
        private GalleryItemGroup _GalleryItemGroup = new GalleryItemGroup();
        private GalleryItem _farPicture = new GalleryItem(null, "far", "");
        private GalleryItem _nearPicture = new GalleryItem(null, "near", "");
        private MVVMContextFluentAPI<ResultDataViewModel> fluent;
        private ucExhaustData ucEdata = null;

        public wfDetialMessage()
        {
            InitializeComponent();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }

        public wfDetialMessage(int index, int cartype,ucExhaustData uc)
        {
            InitializeComponent();
            iIndex = index;
            if (uc != null) ucEdata = uc;
            ucDataMessageView ucDM = new ucDataMessageView();
            ucDM.Dock = DockStyle.Fill;
            pcDataMessage.Controls.Add(ucDM);
            ShowUC(iIndex);
            
            
            InitializeUI();
            if (!mvvmContext1.IsDesignMode) InitializeBindings();
        }


        protected override void InitializeBindings()
        {
            try
            {
                string uniqueKey = ucEdata.GetUniqueKeyByIndex(iIndex);
                _GalleryItemGroup.Items.Add(_farPicture);
                _GalleryItemGroup.Items.Add(_nearPicture);
                gcPicture.Gallery.Groups.Add(_GalleryItemGroup);
                gcPicture.Gallery.ItemSize = new Size(gcPicture.Width - 6, gcPicture.Height / 2 - 6);
                //      ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryDetialInfo, iIndex,uniqueKey });
                //       ShowUC(iIndex);
                mvvmContext1.SetViewModel(typeof(ResultDataViewModel), ResultDataViewModel.VM);
                Messenger.Default.Register<string>(this, typeof(ResultDataViewModel).Name, action);
                fluent = mvvmContext1.OfType<ResultDataViewModel>();

                AddBinding(fluent.SetBinding(this, t => t.FarPicturePath, x => x.DetialInfoEntities, m =>
                {
                    if (m == null || m.Count ==0) return "";
                    object o = JsonNewtonsoft.FromJSON(m[0].ToString());
                    if (o is JObject)
                    {
                        JObject jo = (o as JObject);
                        JToken value;
                        if (jo.TryGetValue("PicFarPath", out value)) return value.ToString();
                    }
                    return "";
                }));
                AddBinding(fluent.SetBinding(this, t => t.NearPicturePath, x => x.DetialInfoEntities, m =>
                {
                    if (m == null || m.Count == 0) return "";
                    object o = JsonNewtonsoft.FromJSON(m[0].ToString());
                    if (o is JObject)
                    {
                        JObject jo = (o as JObject);
                        JToken value;
                        if (jo.TryGetValue("PicNearPath", out value)) return value.ToString();
                    }
                    return "";
                }));
                AddBinding(fluent.SetBinding(lcStationNameValue, lc => lc.Text, x => x.DetialInfoEntities, m =>
                {
                    if (m == null || m.Count == 0) return "0";
                    object o = JsonNewtonsoft.FromJSON(m[0].ToString());
                    if (o is JObject)
                    {
                        JObject jo = (o as JObject);
                        JToken value;
                        if (jo.TryGetValue("Station", out value) && value.ToString() != "")
                        {
                            return value.ToString();
                        }
                    }
                    return "0";
                }));
                AddBinding(fluent.SetBinding(lcLongitudeValue, lc => lc.Text, x => x.DetialInfoEntities, m =>
                {
                    if (m == null || m.Count == 0) return "0";
                    object o = JsonNewtonsoft.FromJSON(m[0].ToString());
                    if (o is JObject)
                    {
                        JObject jo = (o as JObject);
                        JToken value;
                        if (jo.TryGetValue("Longitude", out value) && value.ToString() != "")
                        {
                            return value.ToString();
                        }
                    }
                    return "0";
                }));
                AddBinding(fluent.SetBinding(lcLatitudeValue, lc => lc.Text, x => x.DetialInfoEntities, m =>
                {
                    if (m == null || m.Count == 0) return "0";
                    object o = JsonNewtonsoft.FromJSON(m[0].ToString());
                    if (o is JObject)
                    {
                        JObject jo = (o as JObject);
                        JToken value;
                        if (jo.TryGetValue("Latitude", out value) && value.ToString() != "")
                        {
                            return value.ToString();
                        }
                    }
                    return "0";
                }));
                AddBinding(fluent.SetBinding(lcSlopeValue, lc => lc.Text, x => x.DetialInfoEntities, m =>
                {
                    if (m == null || m.Count == 0) return "0";
                    object o = JsonNewtonsoft.FromJSON(m[0].ToString());
                    if (o is JObject)
                    {
                        JObject jo = (o as JObject);
                        JToken value;
                        if (jo.TryGetValue("Slope", out value) && value.ToString() != "")
                        {
                            return value.ToString();
                        }
                    }
                    return "0";
                }));


                RealtimeMonitorViewModel.VM.ModelChanged += (sender, arg) => {
                    if (arg.ModelName == typeof(ResultDataViewModel).Name) action();
                };
                base.InitializeBindings();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex.StackTrace.ToString());
            }
        }
        public void ShowUC(int idx)
        {
            iIndex = idx;
            string uniqueKey = ucEdata.GetUniqueKeyByIndex(idx);
            ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryDetialInfo, idx, uniqueKey });
            if (ResultDataViewModel.VM.DetialInfoEntities.Count > 0 && ResultDataViewModel.VM.DetialInfoEntities[0] != null)
            {
                object o = ResultDataViewModel.VM.DetialInfoEntities[0];
                if (o is JObject)
                {
                    JObject jo = (o as JObject);
                    iType = jo.Value<string>("CarType").Trim();
                    string path = jo.Value<string>("DataPath");
                    if (path != null && path != "") { ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryCarLimitingInfo, path }); }
                }
            }
            else
            {
                return;
            }
            //汽油车
            if (iType == "A")
            {
                pcCarType.Controls.Clear();
                //pcCartype.Controls.Add(ucGaso);
                //ucGaso.Dock = DockStyle.Fill;
                ucDataMessageGasoline ucGaso = new ucDataMessageGasoline();
                pcCarType.Controls.Add(ucGaso);
                ucGaso.Dock = DockStyle.Fill;
                pcCarType.Visible=true;
                pcCarType.BringToFront();
            }
            //柴油车
            else if (iType == "B")
            {
                pcCarType.Controls.Clear();
                //pcCartype.Controls.Add(ucDiesel);
                //ucDiesel.Dock = DockStyle.Fill;
                ucDataMessageDieselCar ucDiesl = new ucDataMessageDieselCar();
                pcCarType.Controls.Add(ucDiesl);
                ucDiesl.Dock = DockStyle.Fill;
                pcCarType.Visible = true;
                pcCarType.BringToFront();
            }
            else
            {
                pcCarType.Controls.Clear();
                pcCarType.Visible = false;
            }
            doAction();
        }
        private void pePre_Click(object sender, EventArgs e)
        {
            if (--iIndex < 0)
            {
                iIndex++;
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.FirstInfo), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string uniquekey = ucEdata.GetUniqueKeyByIndex(iIndex);
                ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryDetialInfo, iIndex, uniquekey });
                ShowUC(iIndex);
            }
            action();
        }
        private void peNext_Click(object sender, EventArgs e)
        {
            if (++iIndex >= ResultDataViewModel.VM.ExhuastEntities.Count)
            {
                iIndex--;
                XtraMessageBox.Show(Program.infoResource.GetLocalizedString(language.InfoId.LastInfo), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string uniqueKey = ucEdata.GetUniqueKeyByIndex(iIndex);
                ResultDataViewModel.VM.Execute(new List<object> { ResultDataViewModel.ExecuteCommand.ec_QueryDetialInfo, iIndex, uniqueKey });
                ShowUC(iIndex);
            }
            action();
        }
        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            ArrayList rs = new ArrayList();
            rs.Add(ResultDataViewModel.VM.DetialInfoEntities[0]);
            wfPrint frmprint = new wfPrint(rs, frmMain.UserName);
            frmprint.WindowState = FormWindowState.Maximized;
            frmprint.Show();
        }
        private string _FarPicturePath = "";
        /// <summary>
        /// 车辆远景照片
        /// </summary>
        public string FarPicturePath
        {
            get { return _FarPicturePath; }
            set
            {
                _FarPicturePath = value;
                if (File.Exists(value))
                {
                    try
                    {
                        if (_farPicture.ImageOptions.Image!=null&&_farPicture.Caption == value) return;
                        _farPicture.Caption = value;
                        if (_farPicture.ImageOptions.Image != null) _farPicture.ImageOptions.Image.Dispose();
                        _farPicture.ImageOptions.Image = Utils.FileToBitmap(value);
                    }
                    catch(Exception ex) { ErrorLog.Error(ex.ToString()); }
                }
                else
                {
                    _farPicture.Caption = "";
                    if (_farPicture.ImageOptions.Image != null) _farPicture.ImageOptions.Image.Dispose();
                    _farPicture.ImageOptions.Image = null;
                }
            }
        }

        private string _NearPicturePath = "";
        /// <summary>
        /// 车辆近景照片
        /// </summary>
        public string NearPicturePath
        {
            get { return _NearPicturePath; }
            set
            {
                _NearPicturePath = value;
                if (File.Exists(value))
                {
                    try
                    {
                        if (_nearPicture.ImageOptions.Image !=null&& _nearPicture.Caption == value) return;
                        _nearPicture.Caption = value;
                        if (_nearPicture.ImageOptions.Image != null) _nearPicture.ImageOptions.Image.Dispose();
                        _nearPicture.ImageOptions.Image =Utils.FileToBitmap(value);
                    }
                    catch (Exception ex) { ErrorLog.Error(ex.ToString()); }
                }
                else
                {
                    _nearPicture.Caption = "";
                    if (_nearPicture.ImageOptions.Image != null) _nearPicture.ImageOptions.Image.Dispose();
                    _nearPicture.ImageOptions.Image = null;
                }
            }
        }
        /// <summary>
        /// 清除画布
        /// </summary>
        public void ClearGallery()
        {
            _GalleryItemGroup.Items.Clear();
        }
        /// <summary>
        /// 清除画布
        /// </summary>
        public void AddImages(List<Image> images)
        {
            try
            {
                if (images == null || images.Count == 0) return;
                for (int i = 0; i < images.Count; i++)
                    _GalleryItemGroup.Items.Add(new GalleryItem(images[i], i.ToString(), ""));
            }
            catch (Exception ex)
            {
            }
        }

        private void wfDetialMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_nearPicture.ImageOptions.Image != null)
            {
                _nearPicture.ImageOptions.Image.Dispose();
                _nearPicture.ImageOptions.Image = null;
            }
            if (_nearPicture.ImageOptions.Image != null)
            {
                _nearPicture.ImageOptions.Image.Dispose();
                _nearPicture.ImageOptions.Image = null;
            }
            //this.Dispose();
            //this.Close();
        }
    }
}
