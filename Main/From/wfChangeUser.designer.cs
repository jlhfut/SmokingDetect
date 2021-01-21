namespace wayeal.os.exhaust.Forms
{
    partial class wfChangeUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wfChangeUser));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.ceischeck = new DevExpress.XtraEditors.CheckEdit();
            this.lcPermission = new DevExpress.XtraEditors.LabelControl();
            this.lcUserName = new DevExpress.XtraEditors.LabelControl();
            this.cbPermi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.teUserName = new DevExpress.XtraEditors.TextEdit();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceischeck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPermi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // sbCancel
            // 
            this.sbCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sbCancel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbCancel.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbCancel.Appearance.Options.UseBackColor = true;
            this.sbCancel.Appearance.Options.UseFont = true;
            this.sbCancel.Appearance.Options.UseForeColor = true;
            this.sbCancel.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sbCancel.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbCancel.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sbCancel.AppearanceDisabled.Options.UseBackColor = true;
            this.sbCancel.AppearanceDisabled.Options.UseFont = true;
            this.sbCancel.AppearanceDisabled.Options.UseForeColor = true;
            this.sbCancel.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sbCancel.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbCancel.AppearanceHovered.Options.UseBackColor = true;
            this.sbCancel.AppearanceHovered.Options.UseFont = true;
            this.sbCancel.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbCancel.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbCancel.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbCancel.AppearancePressed.Image")));
            this.sbCancel.AppearancePressed.Options.UseBackColor = true;
            this.sbCancel.AppearancePressed.Options.UseFont = true;
            this.sbCancel.AppearancePressed.Options.UseImage = true;
            this.sbCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sbCancel.BackgroundImage")));
            this.sbCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sbCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbCancel.Location = new System.Drawing.Point(162, 164);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbCancel.Size = new System.Drawing.Size(93, 28);
            this.sbCancel.TabIndex = 54;
            this.sbCancel.Text = "取消";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click);
            // 
            // sbConfirm
            // 
            this.sbConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sbConfirm.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbConfirm.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbConfirm.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbConfirm.Appearance.Options.UseBackColor = true;
            this.sbConfirm.Appearance.Options.UseFont = true;
            this.sbConfirm.Appearance.Options.UseForeColor = true;
            this.sbConfirm.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbConfirm.AppearanceHovered.Options.UseBackColor = true;
            this.sbConfirm.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbConfirm.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbConfirm.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbConfirm.AppearancePressed.Image")));
            this.sbConfirm.AppearancePressed.Options.UseBackColor = true;
            this.sbConfirm.AppearancePressed.Options.UseFont = true;
            this.sbConfirm.AppearancePressed.Options.UseImage = true;
            this.sbConfirm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sbConfirm.BackgroundImage")));
            this.sbConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sbConfirm.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbConfirm.Location = new System.Drawing.Point(264, 164);
            this.sbConfirm.Margin = new System.Windows.Forms.Padding(6);
            this.sbConfirm.Name = "sbConfirm";
            this.sbConfirm.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbConfirm.Size = new System.Drawing.Size(93, 28);
            this.sbConfirm.TabIndex = 53;
            this.sbConfirm.Text = "确认";
            this.sbConfirm.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ceischeck
            // 
            this.ceischeck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ceischeck.EditValue = "1";
            this.ceischeck.Location = new System.Drawing.Point(162, 130);
            this.ceischeck.Name = "ceischeck";
            this.ceischeck.Properties.AllowFocused = false;
            this.ceischeck.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ceischeck.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ceischeck.Properties.Appearance.Options.UseFont = true;
            this.ceischeck.Properties.Appearance.Options.UseForeColor = true;
            this.ceischeck.Properties.Caption = "启用账户";
            this.ceischeck.Properties.ValueChecked = "1";
            this.ceischeck.Properties.ValueUnchecked = "0";
            this.ceischeck.Size = new System.Drawing.Size(150, 21);
            this.ceischeck.TabIndex = 52;
            // 
            // lcPermission
            // 
            this.lcPermission.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lcPermission.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcPermission.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcPermission.Appearance.Options.UseFont = true;
            this.lcPermission.Appearance.Options.UseForeColor = true;
            this.lcPermission.Appearance.Options.UseTextOptions = true;
            this.lcPermission.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcPermission.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcPermission.Location = new System.Drawing.Point(88, 99);
            this.lcPermission.Name = "lcPermission";
            this.lcPermission.Size = new System.Drawing.Size(69, 19);
            this.lcPermission.TabIndex = 51;
            this.lcPermission.Text = "权限级别";
            // 
            // lcUserName
            // 
            this.lcUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lcUserName.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcUserName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcUserName.Appearance.Options.UseFont = true;
            this.lcUserName.Appearance.Options.UseForeColor = true;
            this.lcUserName.Appearance.Options.UseTextOptions = true;
            this.lcUserName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcUserName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcUserName.Location = new System.Drawing.Point(88, 54);
            this.lcUserName.Name = "lcUserName";
            this.lcUserName.Size = new System.Drawing.Size(69, 19);
            this.lcUserName.TabIndex = 50;
            this.lcUserName.Text = "用户名";
            // 
            // cbPermi
            // 
            this.cbPermi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbPermi.Location = new System.Drawing.Point(162, 96);
            this.cbPermi.Name = "cbPermi";
            this.cbPermi.Properties.AllowFocused = false;
            this.cbPermi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbPermi.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.White;
            serializableAppearanceObject1.BackColor2 = System.Drawing.Color.White;
            serializableAppearanceObject1.BorderColor = System.Drawing.Color.White;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject1.Options.UseBorderColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.White;
            serializableAppearanceObject2.BackColor2 = System.Drawing.Color.White;
            serializableAppearanceObject2.BorderColor = System.Drawing.Color.White;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject2.Options.UseBorderColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.White;
            serializableAppearanceObject3.BackColor2 = System.Drawing.Color.White;
            serializableAppearanceObject3.BorderColor = System.Drawing.Color.White;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject3.Options.UseBorderColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.White;
            serializableAppearanceObject4.BackColor2 = System.Drawing.Color.White;
            serializableAppearanceObject4.BorderColor = System.Drawing.Color.White;
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject4.Options.UseBorderColor = true;
            this.cbPermi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.cbPermi.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.cbPermi.Properties.ItemPadding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.cbPermi.Properties.Items.AddRange(new object[] {
            "操作员",
            "管理员",
            "游客"});
            this.cbPermi.Properties.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cbPermi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPermi.Size = new System.Drawing.Size(238, 28);
            this.cbPermi.TabIndex = 49;
            this.cbPermi.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.cbePermission_CustomDisplayText);
            // 
            // teUserName
            // 
            this.teUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.teUserName.Enabled = false;
            this.teUserName.Location = new System.Drawing.Point(162, 49);
            this.teUserName.Name = "teUserName";
            this.teUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.teUserName.Properties.Appearance.Options.UseFont = true;
            this.teUserName.Properties.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.teUserName.Size = new System.Drawing.Size(238, 28);
            this.teUserName.TabIndex = 48;
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            // 
            // wfChangeUser
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 258);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.sbConfirm);
            this.Controls.Add(this.ceischeck);
            this.Controls.Add(this.lcPermission);
            this.Controls.Add(this.lcUserName);
            this.Controls.Add(this.cbPermi);
            this.Controls.Add(this.teUserName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wfChangeUser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改用户";
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceischeck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPermi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton sbConfirm;
        private DevExpress.XtraEditors.CheckEdit ceischeck;
        private DevExpress.XtraEditors.LabelControl lcPermission;
        private DevExpress.XtraEditors.LabelControl lcUserName;
        private DevExpress.XtraEditors.ComboBoxEdit cbPermi;
        private DevExpress.XtraEditors.TextEdit teUserName;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}