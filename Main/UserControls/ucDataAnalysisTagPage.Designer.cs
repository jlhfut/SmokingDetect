namespace wayeal.os.exhaust.UserControls
{
    partial class ucDataAnalysisTagPage
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
            this.pcBtn = new DevExpress.XtraEditors.PanelControl();
            this.sbRightLane = new DevExpress.XtraEditors.SimpleButton();
            this.sbLeftLane = new DevExpress.XtraEditors.SimpleButton();
            this.pcLeft = new DevExpress.XtraEditors.PanelControl();
            this.pcOnePage = new DevExpress.XtraEditors.PanelControl();
            this.pcPage = new DevExpress.XtraEditors.PanelControl();
            this.lcNextPage = new DevExpress.XtraEditors.LabelControl();
            this.lcPrePage = new DevExpress.XtraEditors.LabelControl();
            this.sbDeriveSpectrogram = new DevExpress.XtraEditors.SimpleButton();
            this.ucDataAnalysisCalculation1 = new wayeal.os.exhaust.UserControls.ucDataAnalysisCalculation();
            this.pcCalData = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcBtn)).BeginInit();
            this.pcBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcLeft)).BeginInit();
            this.pcLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcOnePage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcPage)).BeginInit();
            this.pcPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcCalData)).BeginInit();
            this.pcCalData.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcBtn
            // 
            this.pcBtn.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcBtn.Controls.Add(this.sbRightLane);
            this.pcBtn.Controls.Add(this.sbLeftLane);
            this.pcBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcBtn.Location = new System.Drawing.Point(6, 6);
            this.pcBtn.Name = "pcBtn";
            this.pcBtn.Size = new System.Drawing.Size(927, 28);
            this.pcBtn.TabIndex = 2;
            // 
            // sbRightLane
            // 
            this.sbRightLane.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.sbRightLane.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbRightLane.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbRightLane.Appearance.Options.UseBackColor = true;
            this.sbRightLane.Appearance.Options.UseFont = true;
            this.sbRightLane.Appearance.Options.UseForeColor = true;
            this.sbRightLane.AppearanceHovered.BackColor = System.Drawing.Color.Silver;
            this.sbRightLane.AppearanceHovered.Options.UseBackColor = true;
            this.sbRightLane.AppearancePressed.BackColor = System.Drawing.Color.DarkGray;
            this.sbRightLane.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbRightLane.AppearancePressed.Options.UseBackColor = true;
            this.sbRightLane.AppearancePressed.Options.UseFont = true;
            this.sbRightLane.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbRightLane.Location = new System.Drawing.Point(98, 0);
            this.sbRightLane.Margin = new System.Windows.Forms.Padding(7);
            this.sbRightLane.Name = "sbRightLane";
            this.sbRightLane.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbRightLane.Size = new System.Drawing.Size(93, 28);
            this.sbRightLane.TabIndex = 55;
            this.sbRightLane.Text = "Right Lane";
            this.sbRightLane.Click += new System.EventHandler(this.sbRightLane_Click);
            // 
            // sbLeftLane
            // 
            this.sbLeftLane.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(88)))), ((int)(((byte)(165)))));
            this.sbLeftLane.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbLeftLane.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbLeftLane.Appearance.Options.UseBackColor = true;
            this.sbLeftLane.Appearance.Options.UseFont = true;
            this.sbLeftLane.Appearance.Options.UseForeColor = true;
            this.sbLeftLane.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbLeftLane.AppearanceHovered.Options.UseBackColor = true;
            this.sbLeftLane.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(88)))), ((int)(((byte)(165)))));
            this.sbLeftLane.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbLeftLane.AppearancePressed.Options.UseBackColor = true;
            this.sbLeftLane.AppearancePressed.Options.UseFont = true;
            this.sbLeftLane.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbLeftLane.Location = new System.Drawing.Point(0, 0);
            this.sbLeftLane.Margin = new System.Windows.Forms.Padding(7);
            this.sbLeftLane.Name = "sbLeftLane";
            this.sbLeftLane.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbLeftLane.Size = new System.Drawing.Size(93, 28);
            this.sbLeftLane.TabIndex = 54;
            this.sbLeftLane.Text = "Left Lane";
            this.sbLeftLane.Click += new System.EventHandler(this.sbLeftLane_Click);
            // 
            // pcLeft
            // 
            this.pcLeft.Appearance.BackColor = System.Drawing.Color.White;
            this.pcLeft.Appearance.Options.UseBackColor = true;
            this.pcLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcLeft.Controls.Add(this.pcOnePage);
            this.pcLeft.Controls.Add(this.pcBtn);
            this.pcLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pcLeft.Location = new System.Drawing.Point(0, 0);
            this.pcLeft.Name = "pcLeft";
            this.pcLeft.Padding = new System.Windows.Forms.Padding(6);
            this.pcLeft.Size = new System.Drawing.Size(939, 714);
            this.pcLeft.TabIndex = 3;
            // 
            // pcOnePage
            // 
            this.pcOnePage.Appearance.BackColor = System.Drawing.Color.White;
            this.pcOnePage.Appearance.Options.UseBackColor = true;
            this.pcOnePage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcOnePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcOnePage.Location = new System.Drawing.Point(6, 34);
            this.pcOnePage.Name = "pcOnePage";
            this.pcOnePage.Size = new System.Drawing.Size(927, 674);
            this.pcOnePage.TabIndex = 3;
            // 
            // pcPage
            // 
            this.pcPage.Appearance.BackColor = System.Drawing.Color.White;
            this.pcPage.Appearance.Options.UseBackColor = true;
            this.pcPage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcPage.Controls.Add(this.lcNextPage);
            this.pcPage.Controls.Add(this.lcPrePage);
            this.pcPage.Controls.Add(this.sbDeriveSpectrogram);
            this.pcPage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pcPage.Location = new System.Drawing.Point(0, 714);
            this.pcPage.Margin = new System.Windows.Forms.Padding(5);
            this.pcPage.Name = "pcPage";
            this.pcPage.Padding = new System.Windows.Forms.Padding(14, 12, 14, 12);
            this.pcPage.Size = new System.Drawing.Size(1279, 34);
            this.pcPage.TabIndex = 10;
            // 
            // lcNextPage
            // 
            this.lcNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lcNextPage.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcNextPage.Appearance.Image = global::wayeal.os.exhaust.Properties.Resources.下一页;
            this.lcNextPage.Appearance.Options.UseFont = true;
            this.lcNextPage.Appearance.Options.UseImage = true;
            this.lcNextPage.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lcNextPage.Location = new System.Drawing.Point(1182, 1);
            this.lcNextPage.Margin = new System.Windows.Forms.Padding(5);
            this.lcNextPage.Name = "lcNextPage";
            this.lcNextPage.Size = new System.Drawing.Size(89, 26);
            this.lcNextPage.TabIndex = 10;
            this.lcNextPage.Text = "NextPage";
            this.lcNextPage.Click += new System.EventHandler(this.lcNextPage_Click);
            // 
            // lcPrePage
            // 
            this.lcPrePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lcPrePage.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcPrePage.Appearance.Image = global::wayeal.os.exhaust.Properties.Resources.上一页;
            this.lcPrePage.Appearance.Options.UseFont = true;
            this.lcPrePage.Appearance.Options.UseImage = true;
            this.lcPrePage.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.lcPrePage.Location = new System.Drawing.Point(1094, 1);
            this.lcPrePage.Margin = new System.Windows.Forms.Padding(5);
            this.lcPrePage.Name = "lcPrePage";
            this.lcPrePage.Size = new System.Drawing.Size(82, 26);
            this.lcPrePage.TabIndex = 9;
            this.lcPrePage.Text = "PrePage";
            this.lcPrePage.Click += new System.EventHandler(this.lcPrePage_Click);
            // 
            // sbDeriveSpectrogram
            // 
            this.sbDeriveSpectrogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sbDeriveSpectrogram.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbDeriveSpectrogram.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbDeriveSpectrogram.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbDeriveSpectrogram.Appearance.Image = global::wayeal.os.exhaust.Properties.Resources.创建报告;
            this.sbDeriveSpectrogram.Appearance.Options.UseBackColor = true;
            this.sbDeriveSpectrogram.Appearance.Options.UseFont = true;
            this.sbDeriveSpectrogram.Appearance.Options.UseForeColor = true;
            this.sbDeriveSpectrogram.Appearance.Options.UseImage = true;
            this.sbDeriveSpectrogram.AppearanceHovered.BackColor = System.Drawing.Color.Transparent;
            this.sbDeriveSpectrogram.AppearanceHovered.Image = global::wayeal.os.exhaust.Properties.Resources.创建报告;
            this.sbDeriveSpectrogram.AppearanceHovered.Options.UseBackColor = true;
            this.sbDeriveSpectrogram.AppearanceHovered.Options.UseImage = true;
            this.sbDeriveSpectrogram.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbDeriveSpectrogram.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbDeriveSpectrogram.AppearancePressed.Image = global::wayeal.os.exhaust.Properties.Resources.创建报告按下;
            this.sbDeriveSpectrogram.AppearancePressed.Options.UseBackColor = true;
            this.sbDeriveSpectrogram.AppearancePressed.Options.UseFont = true;
            this.sbDeriveSpectrogram.AppearancePressed.Options.UseImage = true;
            this.sbDeriveSpectrogram.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbDeriveSpectrogram.Location = new System.Drawing.Point(4, 0);
            this.sbDeriveSpectrogram.Margin = new System.Windows.Forms.Padding(5);
            this.sbDeriveSpectrogram.Name = "sbDeriveSpectrogram";
            this.sbDeriveSpectrogram.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbDeriveSpectrogram.Size = new System.Drawing.Size(125, 28);
            this.sbDeriveSpectrogram.TabIndex = 32;
            this.sbDeriveSpectrogram.Text = "DeriveSpectrogram";
            this.sbDeriveSpectrogram.Click += new System.EventHandler(this.sbDeriveSpectrogram_Click);
            // 
            // ucDataAnalysisCalculation1
            // 
            this.ucDataAnalysisCalculation1.Appearance.BackColor = System.Drawing.Color.White;
            this.ucDataAnalysisCalculation1.Appearance.Options.UseBackColor = true;
            this.ucDataAnalysisCalculation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataAnalysisCalculation1.ExecMergeRibbon = false;
            this.ucDataAnalysisCalculation1.Location = new System.Drawing.Point(0, 6);
            this.ucDataAnalysisCalculation1.Margin = new System.Windows.Forms.Padding(0);
            this.ucDataAnalysisCalculation1.Name = "ucDataAnalysisCalculation1";
            this.ucDataAnalysisCalculation1.Size = new System.Drawing.Size(334, 702);
            this.ucDataAnalysisCalculation1.TabIndex = 1;
            this.ucDataAnalysisCalculation1.ZoomFactor = 1F;
            // 
            // pcCalData
            // 
            this.pcCalData.Appearance.BackColor = System.Drawing.Color.White;
            this.pcCalData.Appearance.Options.UseBackColor = true;
            this.pcCalData.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcCalData.Controls.Add(this.ucDataAnalysisCalculation1);
            this.pcCalData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcCalData.Location = new System.Drawing.Point(939, 0);
            this.pcCalData.Name = "pcCalData";
            this.pcCalData.Padding = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.pcCalData.Size = new System.Drawing.Size(340, 714);
            this.pcCalData.TabIndex = 12;
            // 
            // ucDataAnalysisTagPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcCalData);
            this.Controls.Add(this.pcLeft);
            this.Controls.Add(this.pcPage);
            this.Name = "ucDataAnalysisTagPage";
            this.Size = new System.Drawing.Size(1279, 748);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcBtn)).EndInit();
            this.pcBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcLeft)).EndInit();
            this.pcLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcOnePage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcPage)).EndInit();
            this.pcPage.ResumeLayout(false);
            this.pcPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcCalData)).EndInit();
            this.pcCalData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ucDataAnalysisCalculation ucDataAnalysisCalculation1;
        private DevExpress.XtraEditors.PanelControl pcBtn;
        private DevExpress.XtraEditors.SimpleButton sbRightLane;
        private DevExpress.XtraEditors.SimpleButton sbLeftLane;
        private DevExpress.XtraEditors.PanelControl pcLeft;
        private DevExpress.XtraEditors.PanelControl pcOnePage;
        private DevExpress.XtraEditors.PanelControl pcPage;
        private DevExpress.XtraEditors.LabelControl lcNextPage;
        private DevExpress.XtraEditors.LabelControl lcPrePage;
        private DevExpress.XtraEditors.SimpleButton sbDeriveSpectrogram;
        private DevExpress.XtraEditors.PanelControl pcCalData;
    }
}
