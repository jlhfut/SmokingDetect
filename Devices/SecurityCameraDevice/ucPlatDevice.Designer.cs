namespace wayeal.exdevice
{
    partial class ucPlatDevice
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPlatDevice));
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext();
            this.ceUnloadData = new DevExpress.XtraEditors.CheckEdit();
            this.tePlatNumber = new DevExpress.XtraEditors.TextEdit();
            this.lcPlatNumber = new DevExpress.XtraEditors.LabelControl();
            this.sbRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.sbSave = new DevExpress.XtraEditors.SimpleButton();
            this.cbeCommunication = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lcCommunication = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceUnloadData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePlatNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeCommunication.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            // 
            // ceUnloadData
            // 
            this.ceUnloadData.EditValue = "1";
            this.ceUnloadData.Location = new System.Drawing.Point(285, 97);
            this.ceUnloadData.Name = "ceUnloadData";
            this.ceUnloadData.Properties.AllowFocused = false;
            this.ceUnloadData.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceUnloadData.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.ceUnloadData.Properties.Appearance.Options.UseFont = true;
            this.ceUnloadData.Properties.Appearance.Options.UseForeColor = true;
            this.ceUnloadData.Properties.Caption = "Upload Invalid Data";
            this.ceUnloadData.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.ceUnloadData.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.ceUnloadData.Properties.ImageOptions.ImageChecked = global::wayeal.exdevice.Properties.Resources.复选选中;
            this.ceUnloadData.Properties.ImageOptions.ImageUnchecked = global::wayeal.exdevice.Properties.Resources.复选未选中;
            this.ceUnloadData.Properties.ValueChecked = "1";
            this.ceUnloadData.Properties.ValueUnchecked = "0";
            this.ceUnloadData.Size = new System.Drawing.Size(168, 20);
            this.ceUnloadData.TabIndex = 100;
            // 
            // tePlatNumber
            // 
            this.tePlatNumber.Location = new System.Drawing.Point(285, 36);
            this.tePlatNumber.Margin = new System.Windows.Forms.Padding(0);
            this.tePlatNumber.Name = "tePlatNumber";
            this.tePlatNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tePlatNumber.Properties.Appearance.Options.UseFont = true;
            this.tePlatNumber.Size = new System.Drawing.Size(128, 22);
            this.tePlatNumber.TabIndex = 99;
            // 
            // lcPlatNumber
            // 
            this.lcPlatNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcPlatNumber.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lcPlatNumber.Appearance.Options.UseFont = true;
            this.lcPlatNumber.Appearance.Options.UseForeColor = true;
            this.lcPlatNumber.Appearance.Options.UseTextOptions = true;
            this.lcPlatNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcPlatNumber.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcPlatNumber.Location = new System.Drawing.Point(231, 39);
            this.lcPlatNumber.Name = "lcPlatNumber";
            this.lcPlatNumber.Size = new System.Drawing.Size(48, 16);
            this.lcPlatNumber.TabIndex = 98;
            this.lcPlatNumber.Text = "Num:";
            // 
            // sbRefresh
            // 
            this.sbRefresh.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbRefresh.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbRefresh.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("sbRefresh.Appearance.Image")));
            this.sbRefresh.Appearance.Options.UseBackColor = true;
            this.sbRefresh.Appearance.Options.UseFont = true;
            this.sbRefresh.Appearance.Options.UseForeColor = true;
            this.sbRefresh.Appearance.Options.UseImage = true;
            this.sbRefresh.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbRefresh.AppearanceDisabled.Options.UseBackColor = true;
            this.sbRefresh.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbRefresh.AppearanceHovered.Options.UseBackColor = true;
            this.sbRefresh.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbRefresh.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbRefresh.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbRefresh.AppearancePressed.Image")));
            this.sbRefresh.AppearancePressed.Options.UseBackColor = true;
            this.sbRefresh.AppearancePressed.Options.UseFont = true;
            this.sbRefresh.AppearancePressed.Options.UseImage = true;
            this.sbRefresh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbRefresh.Location = new System.Drawing.Point(248, 124);
            this.sbRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbRefresh.Size = new System.Drawing.Size(78, 28);
            this.sbRefresh.TabIndex = 97;
            this.sbRefresh.Text = "Refresh";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // sbSave
            // 
            this.sbSave.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbSave.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("sbSave.Appearance.Image")));
            this.sbSave.Appearance.Options.UseBackColor = true;
            this.sbSave.Appearance.Options.UseFont = true;
            this.sbSave.Appearance.Options.UseForeColor = true;
            this.sbSave.Appearance.Options.UseImage = true;
            this.sbSave.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbSave.AppearanceDisabled.Options.UseBackColor = true;
            this.sbSave.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbSave.AppearanceHovered.Options.UseBackColor = true;
            this.sbSave.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbSave.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbSave.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbSave.AppearancePressed.Image")));
            this.sbSave.AppearancePressed.Options.UseBackColor = true;
            this.sbSave.AppearancePressed.Options.UseFont = true;
            this.sbSave.AppearancePressed.Options.UseImage = true;
            this.sbSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbSave.Location = new System.Drawing.Point(334, 124);
            this.sbSave.Margin = new System.Windows.Forms.Padding(4);
            this.sbSave.Name = "sbSave";
            this.sbSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbSave.Size = new System.Drawing.Size(78, 28);
            this.sbSave.TabIndex = 96;
            this.sbSave.Text = "Save";
            this.sbSave.Click += new System.EventHandler(this.sbSave_Click);
            // 
            // cbeCommunication
            // 
            this.cbeCommunication.Location = new System.Drawing.Point(285, 68);
            this.cbeCommunication.Name = "cbeCommunication";
            this.cbeCommunication.Properties.AllowFocused = false;
            this.cbeCommunication.Properties.AllowMouseWheel = false;
            this.cbeCommunication.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbeCommunication.Properties.Appearance.Options.UseFont = true;
            this.cbeCommunication.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeCommunication.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbeCommunication.Size = new System.Drawing.Size(127, 22);
            this.cbeCommunication.TabIndex = 95;
            // 
            // lcCommunication
            // 
            this.lcCommunication.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcCommunication.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lcCommunication.Appearance.Options.UseFont = true;
            this.lcCommunication.Appearance.Options.UseForeColor = true;
            this.lcCommunication.Appearance.Options.UseTextOptions = true;
            this.lcCommunication.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcCommunication.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcCommunication.Location = new System.Drawing.Point(231, 71);
            this.lcCommunication.Name = "lcCommunication";
            this.lcCommunication.Size = new System.Drawing.Size(48, 16);
            this.lcCommunication.TabIndex = 94;
            this.lcCommunication.Text = "Com:";
            // 
            // ucPlatDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ceUnloadData);
            this.Controls.Add(this.tePlatNumber);
            this.Controls.Add(this.lcPlatNumber);
            this.Controls.Add(this.sbRefresh);
            this.Controls.Add(this.sbSave);
            this.Controls.Add(this.cbeCommunication);
            this.Controls.Add(this.lcCommunication);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Name = "ucPlatDevice";
            this.Size = new System.Drawing.Size(641, 440);
            this.Controls.SetChildIndex(this.lcCommunication, 0);
            this.Controls.SetChildIndex(this.cbeCommunication, 0);
            this.Controls.SetChildIndex(this.sbSave, 0);
            this.Controls.SetChildIndex(this.sbRefresh, 0);
            this.Controls.SetChildIndex(this.lcPlatNumber, 0);
            this.Controls.SetChildIndex(this.tePlatNumber, 0);
            this.Controls.SetChildIndex(this.ceUnloadData, 0);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceUnloadData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePlatNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeCommunication.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraEditors.CheckEdit ceUnloadData;
        private DevExpress.XtraEditors.TextEdit tePlatNumber;
        private DevExpress.XtraEditors.LabelControl lcPlatNumber;
        private DevExpress.XtraEditors.SimpleButton sbRefresh;
        private DevExpress.XtraEditors.SimpleButton sbSave;
        private DevExpress.XtraEditors.ComboBoxEdit cbeCommunication;
        private DevExpress.XtraEditors.LabelControl lcCommunication;
    }
}
