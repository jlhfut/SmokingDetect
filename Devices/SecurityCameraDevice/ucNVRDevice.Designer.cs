namespace wayeal.exdevice
{
    partial class ucNVRDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucNVRDevice));
            this.lcUsed = new DevExpress.XtraEditors.LabelControl();
            this.lcIPAddress = new DevExpress.XtraEditors.LabelControl();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ceUsedPm = new DevExpress.XtraEditors.CheckEdit();
            this.lcUsedPm = new DevExpress.XtraEditors.LabelControl();
            this.sbRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.cbeCommunication = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lcCommunication = new DevExpress.XtraEditors.LabelControl();
            this.sbSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUsedPm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeCommunication.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lcUsed
            // 
            this.lcUsed.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcUsed.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lcUsed.Appearance.Options.UseFont = true;
            this.lcUsed.Appearance.Options.UseForeColor = true;
            this.lcUsed.Location = new System.Drawing.Point(6, -64);
            this.lcUsed.Name = "lcUsed";
            this.lcUsed.Size = new System.Drawing.Size(33, 17);
            this.lcUsed.TabIndex = 65;
            this.lcUsed.Text = "启用:";
            // 
            // lcIPAddress
            // 
            this.lcIPAddress.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcIPAddress.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lcIPAddress.Appearance.Options.UseFont = true;
            this.lcIPAddress.Appearance.Options.UseForeColor = true;
            this.lcIPAddress.Location = new System.Drawing.Point(6, -31);
            this.lcIPAddress.Name = "lcIPAddress";
            this.lcIPAddress.Size = new System.Drawing.Size(33, 17);
            this.lcIPAddress.TabIndex = 64;
            this.lcIPAddress.Text = "通讯:";
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 36);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(641, 404);
            this.webBrowser.TabIndex = 93;
            this.webBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.ceUsedPm);
            this.panelControl1.Controls.Add(this.lcUsedPm);
            this.panelControl1.Controls.Add(this.sbRefresh);
            this.panelControl1.Controls.Add(this.cbeCommunication);
            this.panelControl1.Controls.Add(this.lcCommunication);
            this.panelControl1.Controls.Add(this.sbSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(641, 36);
            this.panelControl1.TabIndex = 94;
            // 
            // ceUsedPm
            // 
            this.ceUsedPm.EditValue = 1;
            this.ceUsedPm.Location = new System.Drawing.Point(50, 7);
            this.ceUsedPm.Name = "ceUsedPm";
            this.ceUsedPm.Properties.AllowFocused = false;
            this.ceUsedPm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceUsedPm.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("ceUsedPm.Properties.Appearance.Image")));
            this.ceUsedPm.Properties.Appearance.Options.UseFont = true;
            this.ceUsedPm.Properties.Appearance.Options.UseImage = true;
            this.ceUsedPm.Properties.Caption = "";
            this.ceUsedPm.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.ceUsedPm.Properties.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("ceUsedPm.Properties.ImageOptions.ImageChecked")));
            this.ceUsedPm.Properties.ImageOptions.ImageUnchecked = ((System.Drawing.Image)(resources.GetObject("ceUsedPm.Properties.ImageOptions.ImageUnchecked")));
            this.ceUsedPm.Properties.ValueChecked = 1;
            this.ceUsedPm.Properties.ValueUnchecked = 0;
            this.ceUsedPm.Size = new System.Drawing.Size(50, 22);
            this.ceUsedPm.TabIndex = 65;
            // 
            // lcUsedPm
            // 
            this.lcUsedPm.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcUsedPm.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lcUsedPm.Appearance.Options.UseFont = true;
            this.lcUsedPm.Appearance.Options.UseForeColor = true;
            this.lcUsedPm.Location = new System.Drawing.Point(11, 10);
            this.lcUsedPm.Name = "lcUsedPm";
            this.lcUsedPm.Size = new System.Drawing.Size(36, 16);
            this.lcUsedPm.TabIndex = 64;
            this.lcUsedPm.Text = "Used:";
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
            this.sbRefresh.Location = new System.Drawing.Point(285, 4);
            this.sbRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbRefresh.Size = new System.Drawing.Size(78, 28);
            this.sbRefresh.TabIndex = 63;
            this.sbRefresh.Text = "Refresh";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // cbeCommunication
            // 
            this.cbeCommunication.Location = new System.Drawing.Point(144, 7);
            this.cbeCommunication.Name = "cbeCommunication";
            this.cbeCommunication.Properties.AllowFocused = false;
            this.cbeCommunication.Properties.AllowMouseWheel = false;
            this.cbeCommunication.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbeCommunication.Properties.Appearance.Options.UseFont = true;
            this.cbeCommunication.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeCommunication.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbeCommunication.Size = new System.Drawing.Size(127, 22);
            this.cbeCommunication.TabIndex = 58;
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
            this.lcCommunication.Location = new System.Drawing.Point(85, 10);
            this.lcCommunication.Name = "lcCommunication";
            this.lcCommunication.Size = new System.Drawing.Size(53, 16);
            this.lcCommunication.TabIndex = 59;
            this.lcCommunication.Text = "Com:";
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
            this.sbSave.Location = new System.Drawing.Point(371, 4);
            this.sbSave.Margin = new System.Windows.Forms.Padding(4);
            this.sbSave.Name = "sbSave";
            this.sbSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbSave.Size = new System.Drawing.Size(78, 28);
            this.sbSave.TabIndex = 62;
            this.sbSave.Text = "Save";
            this.sbSave.Click += new System.EventHandler(this.sbSave_Click);
            // 
            // ucNVRDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.lcUsed);
            this.Controls.Add(this.lcIPAddress);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Name = "ucNVRDevice";
            this.Size = new System.Drawing.Size(641, 440);
            this.Controls.SetChildIndex(this.lcIPAddress, 0);
            this.Controls.SetChildIndex(this.lcUsed, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.webBrowser, 0);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUsedPm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeCommunication.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lcUsed;
        private DevExpress.XtraEditors.LabelControl lcIPAddress;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private System.Windows.Forms.WebBrowser webBrowser;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit ceUsedPm;
        private DevExpress.XtraEditors.LabelControl lcUsedPm;
        private DevExpress.XtraEditors.SimpleButton sbRefresh;
        private DevExpress.XtraEditors.ComboBoxEdit cbeCommunication;
        private DevExpress.XtraEditors.LabelControl lcCommunication;
        private DevExpress.XtraEditors.SimpleButton sbSave;
    }
}
