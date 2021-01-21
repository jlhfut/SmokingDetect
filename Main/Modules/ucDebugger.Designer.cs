namespace wayeal.os.exhaust.Modules
{
    partial class ucDebugger
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
        private UserControls.ucDebuggingDevices ucDevices;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl pcClient;
        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ucDevices = new wayeal.os.exhaust.UserControls.ucDebuggingDevices();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.pcClient = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcClient)).BeginInit();
            this.SuspendLayout();
            // 
            // ucDevices
            // 
            this.ucDevices.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucDevices.ExecMergeRibbon = false;
            this.ucDevices.Location = new System.Drawing.Point(5, 5);
            this.ucDevices.Margin = new System.Windows.Forms.Padding(0);
            this.ucDevices.Name = "ucDevices";
            this.ucDevices.Padding = new System.Windows.Forms.Padding(8);
            this.ucDevices.Size = new System.Drawing.Size(261, 563);
            this.ucDevices.TabIndex = 1;
            this.ucDevices.ZoomFactor = 1F;
            this.ucDevices.DeviceClick += new wayeal.os.exhaust.UserControls.ucDebuggingDevices.DeviceClickEventHandler(this.ucDevices_DeviceClick);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Gray;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(266, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1, 563);
            this.panelControl2.TabIndex = 3;
            // 
            // pcClient
            // 
            this.pcClient.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcClient.Location = new System.Drawing.Point(267, 5);
            this.pcClient.Name = "pcClient";
            this.pcClient.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.pcClient.Size = new System.Drawing.Size(871, 563);
            this.pcClient.TabIndex = 4;
            // 
            // ucDebugger
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcClient);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.ucDevices);
            this.Name = "ucDebugger";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1143, 573);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcClient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        
    }
}
