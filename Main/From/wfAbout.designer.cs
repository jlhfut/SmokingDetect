namespace wayeal.os.exhaust.Forms
{
    partial class wfAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wfAbout));
            this.lcProductName = new DevExpress.XtraEditors.LabelControl();
            this.pcTop = new DevExpress.XtraEditors.PanelControl();
            this.lcVersion = new DevExpress.XtraEditors.LabelControl();
            this.lcConpany = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pcTop)).BeginInit();
            this.pcTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // lcProductName
            // 
            this.lcProductName.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcProductName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lcProductName.Appearance.Options.UseFont = true;
            this.lcProductName.Appearance.Options.UseForeColor = true;
            this.lcProductName.Location = new System.Drawing.Point(124, 24);
            this.lcProductName.Name = "lcProductName";
            this.lcProductName.Size = new System.Drawing.Size(256, 39);
            this.lcProductName.TabIndex = 0;
            this.lcProductName.Text = "黑烟在线监测系统";
            // 
            // pcTop
            // 
            this.pcTop.Appearance.BackColor = System.Drawing.Color.White;
            this.pcTop.Appearance.Options.UseBackColor = true;
            this.pcTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcTop.Controls.Add(this.lcProductName);
            this.pcTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcTop.Location = new System.Drawing.Point(0, 0);
            this.pcTop.Name = "pcTop";
            this.pcTop.Size = new System.Drawing.Size(623, 78);
            this.pcTop.TabIndex = 1;
            // 
            // lcVersion
            // 
            this.lcVersion.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcVersion.Appearance.Options.UseFont = true;
            this.lcVersion.Location = new System.Drawing.Point(219, 119);
            this.lcVersion.Name = "lcVersion";
            this.lcVersion.Size = new System.Drawing.Size(87, 16);
            this.lcVersion.TabIndex = 3;
            this.lcVersion.Text = "Version 1.0.0.0";
            // 
            // lcConpany
            // 
            this.lcConpany.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcConpany.Appearance.Options.UseFont = true;
            this.lcConpany.Location = new System.Drawing.Point(191, 151);
            this.lcConpany.Name = "lcConpany";
            this.lcConpany.Size = new System.Drawing.Size(157, 16);
            this.lcConpany.TabIndex = 4;
            this.lcConpany.Text = "©2020 Wayeal Corporation";
            // 
            // wfAbout
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 292);
            this.Controls.Add(this.lcConpany);
            this.Controls.Add(this.lcVersion);
            this.Controls.Add(this.pcTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wfAbout";
            this.ShowIcon = false;
            this.Text = "关于系统";
            ((System.ComponentModel.ISupportInitialize)(this.pcTop)).EndInit();
            this.pcTop.ResumeLayout(false);
            this.pcTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lcProductName;
        private DevExpress.XtraEditors.PanelControl pcTop;
        private DevExpress.XtraEditors.LabelControl lcVersion;
        private DevExpress.XtraEditors.LabelControl lcConpany;
    }
}