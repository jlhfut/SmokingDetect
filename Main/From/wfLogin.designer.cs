namespace wayeal.os.exhaust.Forms
{
    partial class wfLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wfLogin));
            this.sbExit = new DevExpress.XtraEditors.SimpleButton();
            this.sbLogin = new DevExpress.XtraEditors.SimpleButton();
            this.tePassword = new DevExpress.XtraEditors.TextEdit();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.lcPassword = new DevExpress.XtraEditors.LabelControl();
            this.lcName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sbExit
            // 
            this.sbExit.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbExit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbExit.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbExit.Appearance.Options.UseBackColor = true;
            this.sbExit.Appearance.Options.UseFont = true;
            this.sbExit.Appearance.Options.UseForeColor = true;
            this.sbExit.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sbExit.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbExit.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sbExit.AppearanceDisabled.Options.UseBackColor = true;
            this.sbExit.AppearanceDisabled.Options.UseFont = true;
            this.sbExit.AppearanceDisabled.Options.UseForeColor = true;
            this.sbExit.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sbExit.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbExit.AppearanceHovered.Options.UseBackColor = true;
            this.sbExit.AppearanceHovered.Options.UseFont = true;
            this.sbExit.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbExit.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbExit.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbExit.AppearancePressed.Image")));
            this.sbExit.AppearancePressed.Options.UseBackColor = true;
            this.sbExit.AppearancePressed.Options.UseFont = true;
            this.sbExit.AppearancePressed.Options.UseImage = true;
            this.sbExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sbExit.BackgroundImage")));
            this.sbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sbExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbExit.Location = new System.Drawing.Point(161, 171);
            this.sbExit.Name = "sbExit";
            this.sbExit.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbExit.Size = new System.Drawing.Size(73, 31);
            this.sbExit.TabIndex = 4;
            this.sbExit.Text = "取消";
            this.sbExit.Click += new System.EventHandler(this.sbExit_Click);
            // 
            // sbLogin
            // 
            this.sbLogin.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbLogin.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbLogin.Appearance.Options.UseBackColor = true;
            this.sbLogin.Appearance.Options.UseFont = true;
            this.sbLogin.Appearance.Options.UseForeColor = true;
            this.sbLogin.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sbLogin.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sbLogin.AppearanceDisabled.Options.UseBackColor = true;
            this.sbLogin.AppearanceDisabled.Options.UseForeColor = true;
            this.sbLogin.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbLogin.AppearanceHovered.Options.UseBackColor = true;
            this.sbLogin.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbLogin.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbLogin.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbLogin.AppearancePressed.Image")));
            this.sbLogin.AppearancePressed.Options.UseBackColor = true;
            this.sbLogin.AppearancePressed.Options.UseFont = true;
            this.sbLogin.AppearancePressed.Options.UseImage = true;
            this.sbLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sbLogin.BackgroundImage")));
            this.sbLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sbLogin.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbLogin.Location = new System.Drawing.Point(262, 171);
            this.sbLogin.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.sbLogin.LookAndFeel.UseDefaultLookAndFeel = false;
            this.sbLogin.Name = "sbLogin";
            this.sbLogin.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbLogin.Size = new System.Drawing.Size(81, 31);
            this.sbLogin.TabIndex = 3;
            this.sbLogin.Text = "登录";
            this.sbLogin.Click += new System.EventHandler(this.sbLogin_Click);
            // 
            // tePassword
            // 
            this.tePassword.EditValue = "";
            this.tePassword.EnterMoveNextControl = true;
            this.tePassword.Location = new System.Drawing.Point(196, 111);
            this.tePassword.Name = "tePassword";
            this.tePassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tePassword.Properties.Appearance.Options.UseFont = true;
            this.tePassword.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
            this.tePassword.Properties.Mask.BeepOnError = true;
            this.tePassword.Properties.Mask.ShowPlaceHolders = false;
            this.tePassword.Properties.MaxLength = 100;
            this.tePassword.Properties.PasswordChar = '*';
            this.tePassword.Size = new System.Drawing.Size(116, 22);
            this.tePassword.TabIndex = 2;
            this.tePassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tePassword_KeyDown);
            // 
            // teName
            // 
            this.teName.EditValue = "";
            this.teName.EnterMoveNextControl = true;
            this.teName.Location = new System.Drawing.Point(196, 73);
            this.teName.Name = "teName";
            this.teName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.teName.Properties.Appearance.Options.UseFont = true;
            this.teName.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
            this.teName.Properties.Mask.BeepOnError = true;
            this.teName.Properties.Mask.ShowPlaceHolders = false;
            this.teName.Properties.MaxLength = 100;
            this.teName.Properties.Name = "teName";
            this.teName.Size = new System.Drawing.Size(116, 22);
            this.teName.TabIndex = 1;
            // 
            // lcPassword
            // 
            this.lcPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcPassword.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcPassword.Appearance.Options.UseFont = true;
            this.lcPassword.Appearance.Options.UseForeColor = true;
            this.lcPassword.Appearance.Options.UseTextOptions = true;
            this.lcPassword.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcPassword.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcPassword.Location = new System.Drawing.Point(84, 114);
            this.lcPassword.Name = "lcPassword";
            this.lcPassword.Size = new System.Drawing.Size(106, 16);
            this.lcPassword.TabIndex = 34;
            this.lcPassword.Text = "密码";
            // 
            // lcName
            // 
            this.lcName.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcName.Appearance.Options.UseFont = true;
            this.lcName.Appearance.Options.UseForeColor = true;
            this.lcName.Appearance.Options.UseTextOptions = true;
            this.lcName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcName.Location = new System.Drawing.Point(84, 76);
            this.lcName.Name = "lcName";
            this.lcName.Size = new System.Drawing.Size(106, 16);
            this.lcName.TabIndex = 34;
            this.lcName.Text = "用户名";
            // 
            // wfLogin
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 297);
            this.ControlBox = false;
            this.Controls.Add(this.sbExit);
            this.Controls.Add(this.sbLogin);
            this.Controls.Add(this.tePassword);
            this.Controls.Add(this.teName);
            this.Controls.Add(this.lcPassword);
            this.Controls.Add(this.lcName);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wfLogin";
            this.Opacity = 0.92D;
            this.ShowIcon = false;
            this.Text = "WY-Exhaust";
            this.Load += new System.EventHandler(this.wfLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraEditors.LabelControl lcName;
        private DevExpress.XtraEditors.LabelControl lcPassword;
        private DevExpress.XtraEditors.TextEdit tePassword;
        private DevExpress.XtraEditors.SimpleButton sbLogin;
        private DevExpress.XtraEditors.SimpleButton sbExit;
    }
}