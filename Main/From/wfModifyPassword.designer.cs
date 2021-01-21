namespace wayeal.os.exhaust.Forms
{
    partial class wfModifyPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wfModifyPassword));
            this.lcOldPassword = new DevExpress.XtraEditors.LabelControl();
            this.lcNewPassword = new DevExpress.XtraEditors.LabelControl();
            this.lcNewAgain = new DevExpress.XtraEditors.LabelControl();
            this.teOldPassword = new DevExpress.XtraEditors.TextEdit();
            this.teNewPassword = new DevExpress.XtraEditors.TextEdit();
            this.teAgain = new DevExpress.XtraEditors.TextEdit();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbModify = new DevExpress.XtraEditors.SimpleButton();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.teOldPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAgain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcOldPassword
            // 
            this.lcOldPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcOldPassword.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcOldPassword.Appearance.Options.UseFont = true;
            this.lcOldPassword.Appearance.Options.UseForeColor = true;
            this.lcOldPassword.Appearance.Options.UseTextOptions = true;
            this.lcOldPassword.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcOldPassword.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcOldPassword.Location = new System.Drawing.Point(98, 40);
            this.lcOldPassword.Name = "lcOldPassword";
            this.lcOldPassword.Size = new System.Drawing.Size(100, 28);
            this.lcOldPassword.TabIndex = 0;
            this.lcOldPassword.Text = "旧密码";
            // 
            // lcNewPassword
            // 
            this.lcNewPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcNewPassword.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcNewPassword.Appearance.Options.UseFont = true;
            this.lcNewPassword.Appearance.Options.UseForeColor = true;
            this.lcNewPassword.Appearance.Options.UseTextOptions = true;
            this.lcNewPassword.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcNewPassword.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcNewPassword.Location = new System.Drawing.Point(98, 77);
            this.lcNewPassword.Name = "lcNewPassword";
            this.lcNewPassword.Size = new System.Drawing.Size(100, 28);
            this.lcNewPassword.TabIndex = 1;
            this.lcNewPassword.Text = "新密码";
            // 
            // lcNewAgain
            // 
            this.lcNewAgain.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcNewAgain.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcNewAgain.Appearance.Options.UseFont = true;
            this.lcNewAgain.Appearance.Options.UseForeColor = true;
            this.lcNewAgain.Appearance.Options.UseTextOptions = true;
            this.lcNewAgain.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcNewAgain.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcNewAgain.Location = new System.Drawing.Point(98, 114);
            this.lcNewAgain.Name = "lcNewAgain";
            this.lcNewAgain.Size = new System.Drawing.Size(100, 28);
            this.lcNewAgain.TabIndex = 2;
            this.lcNewAgain.Text = "新密码再输一遍";
            // 
            // teOldPassword
            // 
            this.teOldPassword.Location = new System.Drawing.Point(204, 44);
            this.teOldPassword.Name = "teOldPassword";
            this.teOldPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.teOldPassword.Properties.Appearance.Options.UseFont = true;
            this.teOldPassword.Properties.PasswordChar = '*';
            this.teOldPassword.Size = new System.Drawing.Size(159, 22);
            this.teOldPassword.TabIndex = 3;
            // 
            // teNewPassword
            // 
            this.teNewPassword.Location = new System.Drawing.Point(204, 80);
            this.teNewPassword.Name = "teNewPassword";
            this.teNewPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.teNewPassword.Properties.Appearance.Options.UseFont = true;
            this.teNewPassword.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.teNewPassword.Properties.Mask.ShowPlaceHolders = false;
            this.teNewPassword.Properties.MaxLength = 18;
            this.teNewPassword.Properties.PasswordChar = '*';
            this.teNewPassword.Size = new System.Drawing.Size(159, 22);
            this.teNewPassword.TabIndex = 4;
            // 
            // teAgain
            // 
            this.teAgain.Location = new System.Drawing.Point(204, 116);
            this.teAgain.Name = "teAgain";
            this.teAgain.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.teAgain.Properties.Appearance.Options.UseFont = true;
            this.teAgain.Properties.PasswordChar = '*';
            this.teAgain.Size = new System.Drawing.Size(159, 22);
            this.teAgain.TabIndex = 5;
            // 
            // sbCancel
            // 
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
            this.sbCancel.Location = new System.Drawing.Point(168, 158);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbCancel.Size = new System.Drawing.Size(93, 28);
            this.sbCancel.TabIndex = 56;
            this.sbCancel.Text = "取消";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click);
            // 
            // sbModify
            // 
            this.sbModify.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbModify.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbModify.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbModify.Appearance.Options.UseBackColor = true;
            this.sbModify.Appearance.Options.UseFont = true;
            this.sbModify.Appearance.Options.UseForeColor = true;
            this.sbModify.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbModify.AppearanceHovered.Options.UseBackColor = true;
            this.sbModify.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbModify.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbModify.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbModify.AppearancePressed.Image")));
            this.sbModify.AppearancePressed.Options.UseBackColor = true;
            this.sbModify.AppearancePressed.Options.UseFont = true;
            this.sbModify.AppearancePressed.Options.UseImage = true;
            this.sbModify.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sbModify.BackgroundImage")));
            this.sbModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sbModify.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbModify.Location = new System.Drawing.Point(270, 158);
            this.sbModify.Margin = new System.Windows.Forms.Padding(6);
            this.sbModify.Name = "sbModify";
            this.sbModify.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbModify.Size = new System.Drawing.Size(93, 28);
            this.sbModify.TabIndex = 55;
            this.sbModify.Text = "修改";
            this.sbModify.Click += new System.EventHandler(this.sbModify_Click);
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            // 
            // wfModifyPassword
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 258);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.sbModify);
            this.Controls.Add(this.teAgain);
            this.Controls.Add(this.teNewPassword);
            this.Controls.Add(this.teOldPassword);
            this.Controls.Add(this.lcNewAgain);
            this.Controls.Add(this.lcNewPassword);
            this.Controls.Add(this.lcOldPassword);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wfModifyPassword";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改密码";
            ((System.ComponentModel.ISupportInitialize)(this.teOldPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAgain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lcOldPassword;
        private DevExpress.XtraEditors.LabelControl lcNewPassword;
        private DevExpress.XtraEditors.LabelControl lcNewAgain;
        private DevExpress.XtraEditors.TextEdit teOldPassword;
        private DevExpress.XtraEditors.TextEdit teNewPassword;
        private DevExpress.XtraEditors.TextEdit teAgain;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraEditors.SimpleButton sbModify;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
    }
}