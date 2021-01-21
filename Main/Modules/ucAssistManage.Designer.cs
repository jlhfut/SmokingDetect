namespace wayeal.os.exhaust.Modules
{
    partial class ucAssistManage
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAssistManage));
            this.icAssistManage = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.rgRunningModel = new DevExpress.XtraEditors.RadioGroup();
            this.ceAddToAutoStart = new DevExpress.XtraEditors.CheckEdit();
            this.sbConfirmBK = new DevExpress.XtraEditors.SimpleButton();
            this.sbConfirmRS = new DevExpress.XtraEditors.SimpleButton();
            this.lcAddToAutoStart = new DevExpress.XtraEditors.LabelControl();
            this.lcDataBaseBackups = new DevExpress.XtraEditors.LabelControl();
            this.lcDataBaseRestore = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icAssistManage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgRunningModel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAddToAutoStart.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // icAssistManage
            // 
            this.icAssistManage.ImageSize = new System.Drawing.Size(32, 32);
            this.icAssistManage.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("icAssistManage.ImageStream")));
            this.icAssistManage.Images.SetKeyName(0, "数据库还原.png");
            this.icAssistManage.Images.SetKeyName(1, "数据库备份.png");
            this.icAssistManage.Images.SetKeyName(2, "关机.png");
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.rgRunningModel);
            this.panelControl1.Controls.Add(this.ceAddToAutoStart);
            this.panelControl1.Controls.Add(this.sbConfirmBK);
            this.panelControl1.Controls.Add(this.sbConfirmRS);
            this.panelControl1.Controls.Add(this.lcAddToAutoStart);
            this.panelControl1.Controls.Add(this.lcDataBaseBackups);
            this.panelControl1.Controls.Add(this.lcDataBaseRestore);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(35, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1403, 737);
            this.panelControl1.TabIndex = 37;
            // 
            // rgRunningModel
            // 
            this.rgRunningModel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rgRunningModel.EditValue = "riFullScreen";
            this.rgRunningModel.Location = new System.Drawing.Point(516, 366);
            this.rgRunningModel.Name = "rgRunningModel";
            this.rgRunningModel.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgRunningModel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgRunningModel.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.rgRunningModel.Properties.Appearance.Options.UseBackColor = true;
            this.rgRunningModel.Properties.Appearance.Options.UseFont = true;
            this.rgRunningModel.Properties.Appearance.Options.UseForeColor = true;
            this.rgRunningModel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgRunningModel.Properties.Columns = 2;
            this.rgRunningModel.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("riFullScreen", "全屏独占"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("riBackground", "后台模式")});
            this.rgRunningModel.Size = new System.Drawing.Size(405, 56);
            this.rgRunningModel.TabIndex = 43;
            // 
            // ceAddToAutoStart
            // 
            this.ceAddToAutoStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ceAddToAutoStart.EditValue = 0;
            this.ceAddToAutoStart.Location = new System.Drawing.Point(757, 310);
            this.ceAddToAutoStart.Name = "ceAddToAutoStart";
            this.ceAddToAutoStart.Properties.AllowFocused = false;
            this.ceAddToAutoStart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceAddToAutoStart.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("ceAddToAutoStart.Properties.Appearance.Image")));
            this.ceAddToAutoStart.Properties.Appearance.Options.UseFont = true;
            this.ceAddToAutoStart.Properties.Appearance.Options.UseImage = true;
            this.ceAddToAutoStart.Properties.Caption = "";
            this.ceAddToAutoStart.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.ceAddToAutoStart.Properties.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("ceAddToAutoStart.Properties.ImageOptions.ImageChecked")));
            this.ceAddToAutoStart.Properties.ImageOptions.ImageUnchecked = ((System.Drawing.Image)(resources.GetObject("ceAddToAutoStart.Properties.ImageOptions.ImageUnchecked")));
            this.ceAddToAutoStart.Properties.ValueChecked = 1;
            this.ceAddToAutoStart.Properties.ValueUnchecked = 0;
            this.ceAddToAutoStart.Size = new System.Drawing.Size(50, 22);
            this.ceAddToAutoStart.TabIndex = 42;
            // 
            // sbConfirmBK
            // 
            this.sbConfirmBK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.sbConfirmBK.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbConfirmBK.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbConfirmBK.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbConfirmBK.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("sbConfirmBK.Appearance.Image")));
            this.sbConfirmBK.Appearance.Options.UseBackColor = true;
            this.sbConfirmBK.Appearance.Options.UseFont = true;
            this.sbConfirmBK.Appearance.Options.UseForeColor = true;
            this.sbConfirmBK.Appearance.Options.UseImage = true;
            this.sbConfirmBK.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbConfirmBK.AppearanceHovered.Options.UseBackColor = true;
            this.sbConfirmBK.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbConfirmBK.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbConfirmBK.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbConfirmBK.AppearancePressed.Image")));
            this.sbConfirmBK.AppearancePressed.Options.UseBackColor = true;
            this.sbConfirmBK.AppearancePressed.Options.UseFont = true;
            this.sbConfirmBK.AppearancePressed.Options.UseImage = true;
            this.sbConfirmBK.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbConfirmBK.Location = new System.Drawing.Point(723, 225);
            this.sbConfirmBK.Margin = new System.Windows.Forms.Padding(5);
            this.sbConfirmBK.Name = "sbConfirmBK";
            this.sbConfirmBK.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbConfirmBK.Size = new System.Drawing.Size(118, 30);
            this.sbConfirmBK.TabIndex = 41;
            this.sbConfirmBK.Text = "确认";
            // 
            // sbConfirmRS
            // 
            this.sbConfirmRS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.sbConfirmRS.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbConfirmRS.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sbConfirmRS.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbConfirmRS.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("sbConfirmRS.Appearance.Image")));
            this.sbConfirmRS.Appearance.Options.UseBackColor = true;
            this.sbConfirmRS.Appearance.Options.UseFont = true;
            this.sbConfirmRS.Appearance.Options.UseForeColor = true;
            this.sbConfirmRS.Appearance.Options.UseImage = true;
            this.sbConfirmRS.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbConfirmRS.AppearanceHovered.Options.UseBackColor = true;
            this.sbConfirmRS.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbConfirmRS.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbConfirmRS.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbConfirmRS.AppearancePressed.Image")));
            this.sbConfirmRS.AppearancePressed.Options.UseBackColor = true;
            this.sbConfirmRS.AppearancePressed.Options.UseFont = true;
            this.sbConfirmRS.AppearancePressed.Options.UseImage = true;
            this.sbConfirmRS.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbConfirmRS.Location = new System.Drawing.Point(723, 154);
            this.sbConfirmRS.Margin = new System.Windows.Forms.Padding(5);
            this.sbConfirmRS.Name = "sbConfirmRS";
            this.sbConfirmRS.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbConfirmRS.Size = new System.Drawing.Size(118, 30);
            this.sbConfirmRS.TabIndex = 40;
            this.sbConfirmRS.Text = "确认";
            // 
            // lcAddToAutoStart
            // 
            this.lcAddToAutoStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lcAddToAutoStart.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcAddToAutoStart.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lcAddToAutoStart.Appearance.ImageIndex = 2;
            this.lcAddToAutoStart.Appearance.ImageList = this.icAssistManage;
            this.lcAddToAutoStart.Appearance.Options.UseFont = true;
            this.lcAddToAutoStart.Appearance.Options.UseForeColor = true;
            this.lcAddToAutoStart.Appearance.Options.UseImageIndex = true;
            this.lcAddToAutoStart.Appearance.Options.UseImageList = true;
            this.lcAddToAutoStart.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lcAddToAutoStart.Location = new System.Drawing.Point(510, 303);
            this.lcAddToAutoStart.Name = "lcAddToAutoStart";
            this.lcAddToAutoStart.Size = new System.Drawing.Size(122, 36);
            this.lcAddToAutoStart.TabIndex = 39;
            this.lcAddToAutoStart.Text = "开机自启动";
            // 
            // lcDataBaseBackups
            // 
            this.lcDataBaseBackups.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lcDataBaseBackups.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcDataBaseBackups.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lcDataBaseBackups.Appearance.ImageIndex = 1;
            this.lcDataBaseBackups.Appearance.ImageList = this.icAssistManage;
            this.lcDataBaseBackups.Appearance.Options.UseFont = true;
            this.lcDataBaseBackups.Appearance.Options.UseForeColor = true;
            this.lcDataBaseBackups.Appearance.Options.UseImageIndex = true;
            this.lcDataBaseBackups.Appearance.Options.UseImageList = true;
            this.lcDataBaseBackups.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lcDataBaseBackups.Location = new System.Drawing.Point(510, 225);
            this.lcDataBaseBackups.Name = "lcDataBaseBackups";
            this.lcDataBaseBackups.Size = new System.Drawing.Size(122, 36);
            this.lcDataBaseBackups.TabIndex = 38;
            this.lcDataBaseBackups.Text = "数据库备份";
            // 
            // lcDataBaseRestore
            // 
            this.lcDataBaseRestore.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lcDataBaseRestore.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcDataBaseRestore.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lcDataBaseRestore.Appearance.ImageIndex = 0;
            this.lcDataBaseRestore.Appearance.ImageList = this.icAssistManage;
            this.lcDataBaseRestore.Appearance.Options.UseFont = true;
            this.lcDataBaseRestore.Appearance.Options.UseForeColor = true;
            this.lcDataBaseRestore.Appearance.Options.UseImageIndex = true;
            this.lcDataBaseRestore.Appearance.Options.UseImageList = true;
            this.lcDataBaseRestore.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lcDataBaseRestore.Location = new System.Drawing.Point(510, 148);
            this.lcDataBaseRestore.Name = "lcDataBaseRestore";
            this.lcDataBaseRestore.Size = new System.Drawing.Size(122, 36);
            this.lcDataBaseRestore.TabIndex = 37;
            this.lcDataBaseRestore.Text = "数据库还原";
            // 
            // ucAssistManage
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "ucAssistManage";
            this.Padding = new System.Windows.Forms.Padding(35, 12, 0, 0);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icAssistManage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgRunningModel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAddToAutoStart.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.ImageCollection icAssistManage;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.RadioGroup rgRunningModel;
        private DevExpress.XtraEditors.CheckEdit ceAddToAutoStart;
        private DevExpress.XtraEditors.SimpleButton sbConfirmBK;
        private DevExpress.XtraEditors.SimpleButton sbConfirmRS;
        private DevExpress.XtraEditors.LabelControl lcAddToAutoStart;
        private DevExpress.XtraEditors.LabelControl lcDataBaseBackups;
        private DevExpress.XtraEditors.LabelControl lcDataBaseRestore;
    }
}
