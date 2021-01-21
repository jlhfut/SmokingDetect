//namespace wayeal.exdevice
//{
//    partial class ucAirQualityDevice
//    {
//        /// <summary> 
//        /// 必需的设计器变量。
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary> 
//        /// 清理所有正在使用的资源。
//        /// </summary>
//        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region 组件设计器生成的代码

//        /// <summary> 
//        /// 设计器支持所需的方法 - 不要修改
//        /// 使用代码编辑器修改此方法的内容。
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAirQualityDevice));
//            this.cbeO3 = new DevExpress.XtraEditors.ComboBoxEdit();
//            this.cbeNO2 = new DevExpress.XtraEditors.ComboBoxEdit();
//            this.cbeSO2 = new DevExpress.XtraEditors.ComboBoxEdit();
//            this.cbeCO = new DevExpress.XtraEditors.ComboBoxEdit();
//            this.cbePM10 = new DevExpress.XtraEditors.ComboBoxEdit();
//            this.cbePM25 = new DevExpress.XtraEditors.ComboBoxEdit();
//            this.lcO3Value = new DevExpress.XtraEditors.LabelControl();
//            this.lcO3Device = new DevExpress.XtraEditors.LabelControl();
//            this.ceUsedPm = new DevExpress.XtraEditors.CheckEdit();
//            this.lcUsedPm = new DevExpress.XtraEditors.LabelControl();
//            this.sbRefresh = new DevExpress.XtraEditors.SimpleButton();
//            this.lcNO2Value = new DevExpress.XtraEditors.LabelControl();
//            this.lcSO2Value = new DevExpress.XtraEditors.LabelControl();
//            this.lcCOValue = new DevExpress.XtraEditors.LabelControl();
//            this.lcPM10Value = new DevExpress.XtraEditors.LabelControl();
//            this.lcPM25Value = new DevExpress.XtraEditors.LabelControl();
//            this.lcSO2Device = new DevExpress.XtraEditors.LabelControl();
//            this.lcNO2Devcie = new DevExpress.XtraEditors.LabelControl();
//            this.lcCODevice = new DevExpress.XtraEditors.LabelControl();
//            this.lcPM2point5 = new DevExpress.XtraEditors.LabelControl();
//            this.sbSave = new DevExpress.XtraEditors.SimpleButton();
//            this.cbeCommunication = new DevExpress.XtraEditors.ComboBoxEdit();
//            this.lcPM10Device = new DevExpress.XtraEditors.LabelControl();
//            this.lcCommunication = new DevExpress.XtraEditors.LabelControl();
//            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
//            ((System.ComponentModel.ISupportInitialize)(this.cbeO3.Properties)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.cbeNO2.Properties)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.cbeSO2.Properties)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.cbeCO.Properties)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.cbePM10.Properties)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.cbePM25.Properties)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.ceUsedPm.Properties)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.cbeCommunication.Properties)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // cbeO3
//            // 
//            this.cbeO3.Location = new System.Drawing.Point(350, 273);
//            this.cbeO3.Name = "cbeO3";
//            this.cbeO3.Properties.AllowFocused = false;
//            this.cbeO3.Properties.AllowMouseWheel = false;
//            this.cbeO3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.cbeO3.Properties.Appearance.Options.UseFont = true;
//            this.cbeO3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
//            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
//            this.cbeO3.Properties.Items.AddRange(new object[] {
//            "ppm",
//            "ppb",
//            "ug/m³",
//            "mg/m³"});
//            this.cbeO3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
//            this.cbeO3.Size = new System.Drawing.Size(83, 22);
//            this.cbeO3.TabIndex = 81;
//            // 
//            // cbeNO2
//            // 
//            this.cbeNO2.Location = new System.Drawing.Point(350, 239);
//            this.cbeNO2.Name = "cbeNO2";
//            this.cbeNO2.Properties.AllowFocused = false;
//            this.cbeNO2.Properties.AllowMouseWheel = false;
//            this.cbeNO2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.cbeNO2.Properties.Appearance.Options.UseFont = true;
//            this.cbeNO2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
//            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
//            this.cbeNO2.Properties.Items.AddRange(new object[] {
//            "ppm",
//            "ppb",
//            "ug/m³",
//            "mg/m³"});
//            this.cbeNO2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
//            this.cbeNO2.Size = new System.Drawing.Size(83, 22);
//            this.cbeNO2.TabIndex = 80;
//            // 
//            // cbeSO2
//            // 
//            this.cbeSO2.Location = new System.Drawing.Point(350, 205);
//            this.cbeSO2.Name = "cbeSO2";
//            this.cbeSO2.Properties.AllowFocused = false;
//            this.cbeSO2.Properties.AllowMouseWheel = false;
//            this.cbeSO2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.cbeSO2.Properties.Appearance.Options.UseFont = true;
//            this.cbeSO2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
//            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
//            this.cbeSO2.Properties.Items.AddRange(new object[] {
//            "ppm",
//            "ppb",
//            "ug/m³",
//            "mg/m³"});
//            this.cbeSO2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
//            this.cbeSO2.Size = new System.Drawing.Size(83, 22);
//            this.cbeSO2.TabIndex = 79;
//            // 
//            // cbeCO
//            // 
//            this.cbeCO.Location = new System.Drawing.Point(350, 171);
//            this.cbeCO.Name = "cbeCO";
//            this.cbeCO.Properties.AllowFocused = false;
//            this.cbeCO.Properties.AllowMouseWheel = false;
//            this.cbeCO.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.cbeCO.Properties.Appearance.Options.UseFont = true;
//            this.cbeCO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
//            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
//            this.cbeCO.Properties.Items.AddRange(new object[] {
//            "ppm",
//            "ppb",
//            "ug/m³",
//            "mg/m³"});
//            this.cbeCO.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
//            this.cbeCO.Size = new System.Drawing.Size(83, 22);
//            this.cbeCO.TabIndex = 78;
//            // 
//            // cbePM10
//            // 
//            this.cbePM10.Location = new System.Drawing.Point(350, 137);
//            this.cbePM10.Name = "cbePM10";
//            this.cbePM10.Properties.AllowFocused = false;
//            this.cbePM10.Properties.AllowMouseWheel = false;
//            this.cbePM10.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.cbePM10.Properties.Appearance.Options.UseFont = true;
//            this.cbePM10.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
//            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
//            this.cbePM10.Properties.Items.AddRange(new object[] {
//            "ug/m³",
//            "mg/m³"});
//            this.cbePM10.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
//            this.cbePM10.Size = new System.Drawing.Size(83, 22);
//            this.cbePM10.TabIndex = 77;
//            // 
//            // cbePM25
//            // 
//            this.cbePM25.Location = new System.Drawing.Point(350, 100);
//            this.cbePM25.Name = "cbePM25";
//            this.cbePM25.Properties.AllowFocused = false;
//            this.cbePM25.Properties.AllowMouseWheel = false;
//            this.cbePM25.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.cbePM25.Properties.Appearance.Options.UseFont = true;
//            this.cbePM25.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
//            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
//            this.cbePM25.Properties.Items.AddRange(new object[] {
//            "ug/m³",
//            "mg/m³"});
//            this.cbePM25.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
//            this.cbePM25.Size = new System.Drawing.Size(83, 22);
//            this.cbePM25.TabIndex = 76;
//            // 
//            // lcO3Value
//            // 
//            this.lcO3Value.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.lcO3Value.Appearance.ForeColor = System.Drawing.Color.Black;
//            this.lcO3Value.Appearance.Options.UseFont = true;
//            this.lcO3Value.Appearance.Options.UseForeColor = true;
//            this.lcO3Value.Location = new System.Drawing.Point(285, 276);
//            this.lcO3Value.Name = "lcO3Value";
//            this.lcO3Value.Size = new System.Drawing.Size(15, 16);
//            this.lcO3Value.TabIndex = 75;
//            this.lcO3Value.Text = "---";
//            // 
//            // lcO3Device
//            // 
//            this.lcO3Device.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lcO3Device.Appearance.ForeColor = System.Drawing.Color.Black;
//            this.lcO3Device.Appearance.Options.UseFont = true;
//            this.lcO3Device.Appearance.Options.UseForeColor = true;
//            this.lcO3Device.Appearance.Options.UseTextOptions = true;
//            this.lcO3Device.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
//            this.lcO3Device.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
//            this.lcO3Device.Location = new System.Drawing.Point(253, 273);
//            this.lcO3Device.Name = "lcO3Device";
//            this.lcO3Device.Size = new System.Drawing.Size(26, 22);
//            this.lcO3Device.TabIndex = 74;
//            this.lcO3Device.Text = "O3:";
//            // 
//            // ceUsedPm
//            // 
//            this.ceUsedPm.EditValue = 0;
//            this.ceUsedPm.Location = new System.Drawing.Point(285, 36);
//            this.ceUsedPm.Name = "ceUsedPm";
//            this.ceUsedPm.Properties.AllowFocused = false;
//            this.ceUsedPm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.ceUsedPm.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("ceUsedPm.Properties.Appearance.Image")));
//            this.ceUsedPm.Properties.Appearance.Options.UseFont = true;
//            this.ceUsedPm.Properties.Appearance.Options.UseImage = true;
//            this.ceUsedPm.Properties.Caption = "";
//            this.ceUsedPm.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
//            this.ceUsedPm.Properties.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("ceUsedPm.Properties.ImageOptions.ImageChecked")));
//            this.ceUsedPm.Properties.ImageOptions.ImageUnchecked = ((System.Drawing.Image)(resources.GetObject("ceUsedPm.Properties.ImageOptions.ImageUnchecked")));
//            this.ceUsedPm.Properties.ValueChecked = 1;
//            this.ceUsedPm.Properties.ValueUnchecked = 0;
//            this.ceUsedPm.Size = new System.Drawing.Size(58, 22);
//            this.ceUsedPm.TabIndex = 73;
//            // 
//            // lcUsedPm
//            // 
//            this.lcUsedPm.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lcUsedPm.Appearance.ForeColor = System.Drawing.Color.Black;
//            this.lcUsedPm.Appearance.Options.UseFont = true;
//            this.lcUsedPm.Appearance.Options.UseForeColor = true;
//            this.lcUsedPm.Appearance.Options.UseTextOptions = true;
//            this.lcUsedPm.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
//            this.lcUsedPm.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
//            this.lcUsedPm.Location = new System.Drawing.Point(237, 35);
//            this.lcUsedPm.Name = "lcUsedPm";
//            this.lcUsedPm.Size = new System.Drawing.Size(42, 22);
//            this.lcUsedPm.TabIndex = 72;
//            this.lcUsedPm.Text = "Used:";
//            // 
//            // sbRefresh
//            // 
//            this.sbRefresh.Appearance.BackColor = System.Drawing.Color.Transparent;
//            this.sbRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.sbRefresh.Appearance.ForeColor = System.Drawing.Color.White;
//            this.sbRefresh.Appearance.Image = global::wayeal.exdevice.Properties.Resources.普通按钮;
//            this.sbRefresh.Appearance.Options.UseBackColor = true;
//            this.sbRefresh.Appearance.Options.UseFont = true;
//            this.sbRefresh.Appearance.Options.UseForeColor = true;
//            this.sbRefresh.Appearance.Options.UseImage = true;
//            this.sbRefresh.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
//            this.sbRefresh.AppearanceDisabled.Options.UseBackColor = true;
//            this.sbRefresh.AppearanceHovered.BackColor = System.Drawing.Color.Transparent;
//            this.sbRefresh.AppearanceHovered.Image = global::wayeal.exdevice.Properties.Resources.普通按钮;
//            this.sbRefresh.AppearanceHovered.Options.UseBackColor = true;
//            this.sbRefresh.AppearanceHovered.Options.UseImage = true;
//            this.sbRefresh.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
//            this.sbRefresh.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.sbRefresh.AppearancePressed.Image = global::wayeal.exdevice.Properties.Resources.普通按钮按下;
//            this.sbRefresh.AppearancePressed.Options.UseBackColor = true;
//            this.sbRefresh.AppearancePressed.Options.UseFont = true;
//            this.sbRefresh.AppearancePressed.Options.UseImage = true;
//            this.sbRefresh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
//            this.sbRefresh.Location = new System.Drawing.Point(267, 304);
//            this.sbRefresh.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
//            this.sbRefresh.Name = "sbRefresh";
//            this.sbRefresh.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
//            this.sbRefresh.Size = new System.Drawing.Size(78, 28);
//            this.sbRefresh.TabIndex = 71;
//            this.sbRefresh.Text = "Refresh";
//            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
//            // 
//            // lcNO2Value
//            // 
//            this.lcNO2Value.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.lcNO2Value.Appearance.ForeColor = System.Drawing.Color.Black;
//            this.lcNO2Value.Appearance.Options.UseFont = true;
//            this.lcNO2Value.Appearance.Options.UseForeColor = true;
//            this.lcNO2Value.Location = new System.Drawing.Point(285, 242);
//            this.lcNO2Value.Name = "lcNO2Value";
//            this.lcNO2Value.Size = new System.Drawing.Size(15, 16);
//            this.lcNO2Value.TabIndex = 70;
//            this.lcNO2Value.Text = "---";
//            // 
//            // lcSO2Value
//            // 
//            this.lcSO2Value.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.lcSO2Value.Appearance.ForeColor = System.Drawing.Color.Black;
//            this.lcSO2Value.Appearance.Options.UseFont = true;
//            this.lcSO2Value.Appearance.Options.UseForeColor = true;
//            this.lcSO2Value.Location = new System.Drawing.Point(285, 208);
//            this.lcSO2Value.Name = "lcSO2Value";
//            this.lcSO2Value.Size = new System.Drawing.Size(15, 16);
//            this.lcSO2Value.TabIndex = 69;
//            this.lcSO2Value.Text = "---";
//            // 
//            // lcCOValue
//            // 
//            this.lcCOValue.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.lcCOValue.Appearance.ForeColor = System.Drawing.Color.Black;
//            this.lcCOValue.Appearance.Options.UseFont = true;
//            this.lcCOValue.Appearance.Options.UseForeColor = true;
//            this.lcCOValue.Location = new System.Drawing.Point(285, 174);
//            this.lcCOValue.Name = "lcCOValue";
//            this.lcCOValue.Size = new System.Drawing.Size(15, 16);
//            this.lcCOValue.TabIndex = 68;
//            this.lcCOValue.Text = "---";
//            // 
//            // lcPM10Value
//            // 
//            this.lcPM10Value.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.lcPM10Value.Appearance.ForeColor = System.Drawing.Color.Black;
//            this.lcPM10Value.Appearance.Options.UseFont = true;
//            this.lcPM10Value.Appearance.Options.UseForeColor = true;
//            this.lcPM10Value.Location = new System.Drawing.Point(285, 140);
//            this.lcPM10Value.Name = "lcPM10Value";
//            this.lcPM10Value.Size = new System.Drawing.Size(15, 16);
//            this.lcPM10Value.TabIndex = 67;
//            this.lcPM10Value.Text = "---";
//            // 
//            // lcPM25Value
//            // 
//            this.lcPM25Value.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.lcPM25Value.Appearance.ForeColor = System.Drawing.Color.Black;
//            this.lcPM25Value.Appearance.Options.UseFont = true;
//            this.lcPM25Value.Appearance.Options.UseForeColor = true;
//            this.lcPM25Value.Location = new System.Drawing.Point(285, 106);
//            this.lcPM25Value.Name = "lcPM25Value";
//            this.lcPM25Value.Size = new System.Drawing.Size(15, 16);
//            this.lcPM25Value.TabIndex = 66;
//            this.lcPM25Value.Text = "---";
//            // 
//            // lcSO2Device
//            // 
//            this.lcSO2Device.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lcSO2Device.Appearance.ForeColor = System.Drawing.Color.Black;
//            this.lcSO2Device.Appearance.Options.UseFont = true;
//            this.lcSO2Device.Appearance.Options.UseForeColor = true;
//            this.lcSO2Device.Appearance.Options.UseTextOptions = true;
//            this.lcSO2Device.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
//            this.lcSO2Device.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
//            this.lcSO2Device.Location = new System.Drawing.Point(244, 205);
//            this.lcSO2Device.Name = "lcSO2Device";
//            this.lcSO2Device.Size = new System.Drawing.Size(35, 22);
//            this.lcSO2Device.TabIndex = 65;
//            this.lcSO2Device.Text = "SO2:";
//            // 
//            // lcNO2Devcie
//            // 
//            this.lcNO2Devcie.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lcNO2Devcie.Appearance.ForeColor = System.Drawing.Color.Black;
//            this.lcNO2Devcie.Appearance.Options.UseFont = true;
//            this.lcNO2Devcie.Appearance.Options.UseForeColor = true;
//            this.lcNO2Devcie.Appearance.Options.UseTextOptions = true;
//            this.lcNO2Devcie.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
//            this.lcNO2Devcie.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
//            this.lcNO2Devcie.Location = new System.Drawing.Point(244, 239);
//            this.lcNO2Devcie.Name = "lcNO2Devcie";
//            this.lcNO2Devcie.Size = new System.Drawing.Size(35, 22);
//            this.lcNO2Devcie.TabIndex = 64;
//            this.lcNO2Devcie.Text = "NO2:";
//            // 
//            // lcCODevice
//            // 
//            this.lcCODevice.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lcCODevice.Appearance.ForeColor = System.Drawing.Color.Black;
//            this.lcCODevice.Appearance.Options.UseFont = true;
//            this.lcCODevice.Appearance.Options.UseForeColor = true;
//            this.lcCODevice.Appearance.Options.UseTextOptions = true;
//            this.lcCODevice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
//            this.lcCODevice.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
//            this.lcCODevice.Location = new System.Drawing.Point(253, 171);
//            this.lcCODevice.Name = "lcCODevice";
//            this.lcCODevice.Size = new System.Drawing.Size(26, 22);
//            this.lcCODevice.TabIndex = 63;
//            this.lcCODevice.Text = "CO:";
//            // 
//            // lcPM2point5
//            // 
//            this.lcPM2point5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lcPM2point5.Appearance.ForeColor = System.Drawing.Color.Black;
//            this.lcPM2point5.Appearance.Options.UseFont = true;
//            this.lcPM2point5.Appearance.Options.UseForeColor = true;
//            this.lcPM2point5.Appearance.Options.UseTextOptions = true;
//            this.lcPM2point5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
//            this.lcPM2point5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
//            this.lcPM2point5.Location = new System.Drawing.Point(228, 103);
//            this.lcPM2point5.Name = "lcPM2point5";
//            this.lcPM2point5.Size = new System.Drawing.Size(51, 22);
//            this.lcPM2point5.TabIndex = 62;
//            this.lcPM2point5.Text = "PM2.5:";
//            // 
//            // sbSave
//            // 
//            this.sbSave.Appearance.BackColor = System.Drawing.Color.Transparent;
//            this.sbSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.sbSave.Appearance.ForeColor = System.Drawing.Color.White;
//            this.sbSave.Appearance.Image = global::wayeal.exdevice.Properties.Resources.普通按钮;
//            this.sbSave.Appearance.Options.UseBackColor = true;
//            this.sbSave.Appearance.Options.UseFont = true;
//            this.sbSave.Appearance.Options.UseForeColor = true;
//            this.sbSave.Appearance.Options.UseImage = true;
//            this.sbSave.AppearanceHovered.BackColor = System.Drawing.Color.Transparent;
//            this.sbSave.AppearanceHovered.Image = global::wayeal.exdevice.Properties.Resources.普通按钮;
//            this.sbSave.AppearanceHovered.Options.UseBackColor = true;
//            this.sbSave.AppearanceHovered.Options.UseImage = true;
//            this.sbSave.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
//            this.sbSave.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.sbSave.AppearancePressed.Image = global::wayeal.exdevice.Properties.Resources.普通按钮按下;
//            this.sbSave.AppearancePressed.Options.UseBackColor = true;
//            this.sbSave.AppearancePressed.Options.UseFont = true;
//            this.sbSave.AppearancePressed.Options.UseImage = true;
//            this.sbSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
//            this.sbSave.Location = new System.Drawing.Point(355, 304);
//            this.sbSave.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
//            this.sbSave.Name = "sbSave";
//            this.sbSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
//            this.sbSave.Size = new System.Drawing.Size(78, 28);
//            this.sbSave.TabIndex = 61;
//            this.sbSave.Text = "Save";
//            this.sbSave.Click += new System.EventHandler(this.sbSave_Click);
//            // 
//            // cbeCommunication
//            // 
//            this.cbeCommunication.Location = new System.Drawing.Point(285, 69);
//            this.cbeCommunication.Name = "cbeCommunication";
//            this.cbeCommunication.Properties.AllowFocused = false;
//            this.cbeCommunication.Properties.AllowMouseWheel = false;
//            this.cbeCommunication.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.cbeCommunication.Properties.Appearance.Options.UseFont = true;
//            this.cbeCommunication.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
//            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
//            this.cbeCommunication.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
//            this.cbeCommunication.Size = new System.Drawing.Size(148, 22);
//            this.cbeCommunication.TabIndex = 60;
//            // 
//            // lcPM10Device
//            // 
//            this.lcPM10Device.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lcPM10Device.Appearance.ForeColor = System.Drawing.Color.Black;
//            this.lcPM10Device.Appearance.Options.UseFont = true;
//            this.lcPM10Device.Appearance.Options.UseForeColor = true;
//            this.lcPM10Device.Appearance.Options.UseTextOptions = true;
//            this.lcPM10Device.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
//            this.lcPM10Device.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
//            this.lcPM10Device.Location = new System.Drawing.Point(232, 137);
//            this.lcPM10Device.Name = "lcPM10Device";
//            this.lcPM10Device.Size = new System.Drawing.Size(47, 22);
//            this.lcPM10Device.TabIndex = 59;
//            this.lcPM10Device.Text = "PM10:";
//            // 
//            // lcCommunication
//            // 
//            this.lcCommunication.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lcCommunication.Appearance.ForeColor = System.Drawing.Color.Black;
//            this.lcCommunication.Appearance.Options.UseFont = true;
//            this.lcCommunication.Appearance.Options.UseForeColor = true;
//            this.lcCommunication.Appearance.Options.UseTextOptions = true;
//            this.lcCommunication.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
//            this.lcCommunication.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
//            this.lcCommunication.Location = new System.Drawing.Point(242, 69);
//            this.lcCommunication.Name = "lcCommunication";
//            this.lcCommunication.Size = new System.Drawing.Size(37, 22);
//            this.lcCommunication.TabIndex = 58;
//            this.lcCommunication.Text = "Com:";
//            // 
//            // mvvmContext1
//            // 
//            this.mvvmContext1.ContainerControl = this;
//            // 
//            // ucAirQualityDevice
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.White;
//            this.Controls.Add(this.lcO3Device);
//            this.Controls.Add(this.lcNO2Devcie);
//            this.Controls.Add(this.lcSO2Device);
//            this.Controls.Add(this.cbeO3);
//            this.Controls.Add(this.cbeNO2);
//            this.Controls.Add(this.cbeSO2);
//            this.Controls.Add(this.cbeCO);
//            this.Controls.Add(this.cbePM10);
//            this.Controls.Add(this.cbePM25);
//            this.Controls.Add(this.lcO3Value);
//            this.Controls.Add(this.ceUsedPm);
//            this.Controls.Add(this.lcUsedPm);
//            this.Controls.Add(this.sbRefresh);
//            this.Controls.Add(this.lcNO2Value);
//            this.Controls.Add(this.lcSO2Value);
//            this.Controls.Add(this.lcCOValue);
//            this.Controls.Add(this.lcPM10Value);
//            this.Controls.Add(this.lcPM25Value);
//            this.Controls.Add(this.lcCODevice);
//            this.Controls.Add(this.lcPM2point5);
//            this.Controls.Add(this.sbSave);
//            this.Controls.Add(this.cbeCommunication);
//            this.Controls.Add(this.lcPM10Device);
//            this.Controls.Add(this.lcCommunication);
//            this.Font = new System.Drawing.Font("Tahoma", 10F);
//            this.ForeColor = System.Drawing.Color.Black;
//            this.Name = "ucAirQualityDevice";
//            this.Size = new System.Drawing.Size(641, 440);
//            this.Controls.SetChildIndex(this.lcCommunication, 0);
//            this.Controls.SetChildIndex(this.lcPM10Device, 0);
//            this.Controls.SetChildIndex(this.cbeCommunication, 0);
//            this.Controls.SetChildIndex(this.sbSave, 0);
//            this.Controls.SetChildIndex(this.lcPM2point5, 0);
//            this.Controls.SetChildIndex(this.lcCODevice, 0);
//            this.Controls.SetChildIndex(this.lcPM25Value, 0);
//            this.Controls.SetChildIndex(this.lcPM10Value, 0);
//            this.Controls.SetChildIndex(this.lcCOValue, 0);
//            this.Controls.SetChildIndex(this.lcSO2Value, 0);
//            this.Controls.SetChildIndex(this.lcNO2Value, 0);
//            this.Controls.SetChildIndex(this.sbRefresh, 0);
//            this.Controls.SetChildIndex(this.lcUsedPm, 0);
//            this.Controls.SetChildIndex(this.ceUsedPm, 0);
//            this.Controls.SetChildIndex(this.lcO3Value, 0);
//            this.Controls.SetChildIndex(this.cbePM25, 0);
//            this.Controls.SetChildIndex(this.cbePM10, 0);
//            this.Controls.SetChildIndex(this.cbeCO, 0);
//            this.Controls.SetChildIndex(this.cbeSO2, 0);
//            this.Controls.SetChildIndex(this.cbeNO2, 0);
//            this.Controls.SetChildIndex(this.cbeO3, 0);
//            this.Controls.SetChildIndex(this.lcSO2Device, 0);
//            this.Controls.SetChildIndex(this.lcNO2Devcie, 0);
//            this.Controls.SetChildIndex(this.lcO3Device, 0);
//            ((System.ComponentModel.ISupportInitialize)(this.cbeO3.Properties)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.cbeNO2.Properties)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.cbeSO2.Properties)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.cbeCO.Properties)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.cbePM10.Properties)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.cbePM25.Properties)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.ceUsedPm.Properties)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.cbeCommunication.Properties)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private DevExpress.XtraEditors.SimpleButton sbRefresh;
//        private DevExpress.XtraEditors.LabelControl lcNO2Value;
//        private DevExpress.XtraEditors.LabelControl lcSO2Value;
//        private DevExpress.XtraEditors.LabelControl lcCOValue;
//        private DevExpress.XtraEditors.LabelControl lcPM10Value;
//        private DevExpress.XtraEditors.LabelControl lcPM25Value;
//        private DevExpress.XtraEditors.LabelControl lcSO2Device;
//        private DevExpress.XtraEditors.LabelControl lcNO2Devcie;
//        private DevExpress.XtraEditors.LabelControl lcCODevice;
//        private DevExpress.XtraEditors.LabelControl lcPM2point5;
//        private DevExpress.XtraEditors.SimpleButton sbSave;
//        private DevExpress.XtraEditors.ComboBoxEdit cbeCommunication;
//        private DevExpress.XtraEditors.LabelControl lcPM10Device;
//        private DevExpress.XtraEditors.LabelControl lcCommunication;
//        private DevExpress.XtraEditors.LabelControl lcUsedPm;
//        private DevExpress.XtraEditors.CheckEdit ceUsedPm;
//        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
//        private DevExpress.XtraEditors.ComboBoxEdit cbeO3;
//        private DevExpress.XtraEditors.ComboBoxEdit cbeNO2;
//        private DevExpress.XtraEditors.ComboBoxEdit cbeSO2;
//        private DevExpress.XtraEditors.ComboBoxEdit cbeCO;
//        private DevExpress.XtraEditors.ComboBoxEdit cbePM10;
//        private DevExpress.XtraEditors.ComboBoxEdit cbePM25;
//        private DevExpress.XtraEditors.LabelControl lcO3Value;
//        private DevExpress.XtraEditors.LabelControl lcO3Device;
//    }
//}
