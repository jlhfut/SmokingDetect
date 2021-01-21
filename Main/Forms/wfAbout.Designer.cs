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
            this.lcProductName = new DevExpress.XtraEditors.LabelControl();
            this.pcTop = new DevExpress.XtraEditors.PanelControl();
            this.hclLearnMore = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lcProduct = new DevExpress.XtraEditors.LabelControl();
            this.lcVersion = new DevExpress.XtraEditors.LabelControl();
            this.lcConpany = new DevExpress.XtraEditors.LabelControl();
            this.lcCopyright = new DevExpress.XtraEditors.LabelControl();
            this.sbConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.lcWarning1 = new DevExpress.XtraEditors.LabelControl();
            this.lcWarning2 = new DevExpress.XtraEditors.LabelControl();
            this.lcWarning3 = new DevExpress.XtraEditors.LabelControl();
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
            this.lcProductName.Location = new System.Drawing.Point(21, 27);
            this.lcProductName.Name = "lcProductName";
            this.lcProductName.Size = new System.Drawing.Size(159, 39);
            this.lcProductName.TabIndex = 0;
            this.lcProductName.Text = "WYExhaust";
            // 
            // pcTop
            // 
            this.pcTop.Appearance.BackColor = System.Drawing.Color.White;
            this.pcTop.Appearance.Options.UseBackColor = true;
            this.pcTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcTop.Controls.Add(this.hclLearnMore);
            this.pcTop.Controls.Add(this.lcProductName);
            this.pcTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcTop.Location = new System.Drawing.Point(0, 0);
            this.pcTop.Name = "pcTop";
            this.pcTop.Size = new System.Drawing.Size(623, 78);
            this.pcTop.TabIndex = 1;
            // 
            // hclLearnMore
            // 
            this.hclLearnMore.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.hclLearnMore.Appearance.ForeColor = System.Drawing.SystemColors.Highlight;
            this.hclLearnMore.Appearance.Options.UseFont = true;
            this.hclLearnMore.Appearance.Options.UseForeColor = true;
            this.hclLearnMore.Appearance.Options.UseTextOptions = true;
            this.hclLearnMore.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.hclLearnMore.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.hclLearnMore.AppearanceDisabled.ForeColor = System.Drawing.Color.Blue;
            this.hclLearnMore.AppearanceDisabled.Options.UseFont = true;
            this.hclLearnMore.AppearanceDisabled.Options.UseForeColor = true;
            this.hclLearnMore.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.hclLearnMore.AppearancePressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.hclLearnMore.AppearancePressed.Options.UseFont = true;
            this.hclLearnMore.AppearancePressed.Options.UseForeColor = true;
            this.hclLearnMore.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.hclLearnMore.Location = new System.Drawing.Point(443, 43);
            this.hclLearnMore.Name = "hclLearnMore";
            this.hclLearnMore.Size = new System.Drawing.Size(153, 16);
            this.hclLearnMore.TabIndex = 1;
            this.hclLearnMore.Text = "Learn About Company？";
            this.hclLearnMore.Click += new System.EventHandler(this.hyperlinkLabelControl1_Click);
            // 
            // lcProduct
            // 
            this.lcProduct.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcProduct.Appearance.Options.UseFont = true;
            this.lcProduct.Location = new System.Drawing.Point(23, 107);
            this.lcProduct.Name = "lcProduct";
            this.lcProduct.Size = new System.Drawing.Size(228, 16);
            this.lcProduct.TabIndex = 2;
            this.lcProduct.Text = "Exhauast Upper Machine Softword 2020";
            // 
            // lcVersion
            // 
            this.lcVersion.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcVersion.Appearance.Options.UseFont = true;
            this.lcVersion.Location = new System.Drawing.Point(23, 127);
            this.lcVersion.Name = "lcVersion";
            this.lcVersion.Size = new System.Drawing.Size(87, 16);
            this.lcVersion.TabIndex = 3;
            this.lcVersion.Text = "Version 1.0.0.0";
            // 
            // lcConpany
            // 
            this.lcConpany.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcConpany.Appearance.Options.UseFont = true;
            this.lcConpany.Location = new System.Drawing.Point(23, 147);
            this.lcConpany.Name = "lcConpany";
            this.lcConpany.Size = new System.Drawing.Size(157, 16);
            this.lcConpany.TabIndex = 4;
            this.lcConpany.Text = "©2020 Wayeal Corporation";
            // 
            // lcCopyright
            // 
            this.lcCopyright.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcCopyright.Appearance.Options.UseFont = true;
            this.lcCopyright.Location = new System.Drawing.Point(23, 167);
            this.lcCopyright.Name = "lcCopyright";
            this.lcCopyright.Size = new System.Drawing.Size(54, 16);
            this.lcCopyright.TabIndex = 5;
            this.lcCopyright.Text = "Copyright";
            // 
            // sbConfirm
            // 
            this.sbConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbConfirm.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbConfirm.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbConfirm.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbConfirm.Appearance.Image = global::wayeal.os.exhaust.Properties.Resources.关于外界的按钮;
            this.sbConfirm.Appearance.Options.UseBackColor = true;
            this.sbConfirm.Appearance.Options.UseFont = true;
            this.sbConfirm.Appearance.Options.UseForeColor = true;
            this.sbConfirm.Appearance.Options.UseImage = true;
            this.sbConfirm.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sbConfirm.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sbConfirm.AppearanceDisabled.Options.UseBackColor = true;
            this.sbConfirm.AppearanceDisabled.Options.UseForeColor = true;
            this.sbConfirm.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbConfirm.AppearanceHovered.Options.UseBackColor = true;
            this.sbConfirm.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbConfirm.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbConfirm.AppearancePressed.Image = global::wayeal.os.exhaust.Properties.Resources.关于外界的按钮按下;
            this.sbConfirm.AppearancePressed.Options.UseBackColor = true;
            this.sbConfirm.AppearancePressed.Options.UseFont = true;
            this.sbConfirm.AppearancePressed.Options.UseImage = true;
            this.sbConfirm.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sbConfirm.Location = new System.Drawing.Point(514, 243);
            this.sbConfirm.Name = "sbConfirm";
            this.sbConfirm.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbConfirm.Size = new System.Drawing.Size(82, 26);
            this.sbConfirm.TabIndex = 6;
            this.sbConfirm.Text = "Confirm";
            // 
            // lcWarning1
            // 
            this.lcWarning1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lcWarning1.Location = new System.Drawing.Point(23, 217);
            this.lcWarning1.Name = "lcWarning1";
            this.lcWarning1.Size = new System.Drawing.Size(489, 14);
            this.lcWarning1.TabIndex = 7;
            this.lcWarning1.Text = "Warning: This computer program is protected by copyright law and international tr" +
    "eaties.";
            // 
            // lcWarning2
            // 
            this.lcWarning2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lcWarning2.Location = new System.Drawing.Point(23, 236);
            this.lcWarning2.Name = "lcWarning2";
            this.lcWarning2.Size = new System.Drawing.Size(487, 14);
            this.lcWarning2.TabIndex = 8;
            this.lcWarning2.Text = "Unauthorized reproduction or distribution may result in severe civil and criminal" +
    " penalties, ";
            // 
            // lcWarning3
            // 
            this.lcWarning3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lcWarning3.Location = new System.Drawing.Point(23, 255);
            this.lcWarning3.Name = "lcWarning3";
            this.lcWarning3.Size = new System.Drawing.Size(390, 14);
            this.lcWarning3.TabIndex = 9;
            this.lcWarning3.Text = "and will be prosecuted to the maximum extent possible under the law.";
            // 
            // wfAbout
            // 
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 292);
            this.Controls.Add(this.lcWarning3);
            this.Controls.Add(this.lcWarning2);
            this.Controls.Add(this.lcWarning1);
            this.Controls.Add(this.sbConfirm);
            this.Controls.Add(this.lcCopyright);
            this.Controls.Add(this.lcConpany);
            this.Controls.Add(this.lcVersion);
            this.Controls.Add(this.lcProduct);
            this.Controls.Add(this.pcTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wfAbout";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pcTop)).EndInit();
            this.pcTop.ResumeLayout(false);
            this.pcTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lcProductName;
        private DevExpress.XtraEditors.PanelControl pcTop;
        private DevExpress.XtraEditors.LabelControl lcProduct;
        private DevExpress.XtraEditors.LabelControl lcVersion;
        private DevExpress.XtraEditors.LabelControl lcConpany;
        private DevExpress.XtraEditors.LabelControl lcCopyright;
        private DevExpress.XtraEditors.SimpleButton sbConfirm;
        private DevExpress.XtraEditors.HyperlinkLabelControl hclLearnMore;
        private DevExpress.XtraEditors.LabelControl lcWarning1;
        private DevExpress.XtraEditors.LabelControl lcWarning2;
        private DevExpress.XtraEditors.LabelControl lcWarning3;
    }
}