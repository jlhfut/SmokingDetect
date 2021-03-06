﻿namespace wayeal.os.exhaust.Modules
{
    partial class ucRealtimeMonitor
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
            this.pcInfo = new DevExpress.XtraEditors.PanelControl();
            this.pcMid = new DevExpress.XtraEditors.PanelControl();
            this.ucMonitoringStation1 = new wayeal.os.exhaust.UserControls.ucMonitoringStation();
            this.pcRight = new DevExpress.XtraEditors.PanelControl();
            this.ucDeviceStatus1 = new wayeal.os.exhaust.UserControls.ucDeviceStatus();
            this.ucStatisticalInformation1 = new wayeal.os.exhaust.UserControls.ucStatisticalInformation();
            this.pcLeft = new DevExpress.XtraEditors.PanelControl();
            this.ucMonitoringComponent = new wayeal.os.exhaust.UserControls.ucMonitoringComponent();
            this.ucRealtimeMonitorInfo = new wayeal.os.exhaust.UserControls.ucMonitoringInfo();
            this.ucMonitoringResult1 = new wayeal.os.exhaust.UserControls.ucMonitoringResult();
            this.ucMonitoringPicture1 = new wayeal.os.exhaust.UserControls.ucMonitoringPicture();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcInfo)).BeginInit();
            this.pcInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcMid)).BeginInit();
            this.pcMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcRight)).BeginInit();
            this.pcRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcLeft)).BeginInit();
            this.pcLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcInfo
            // 
            this.pcInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pcInfo.Controls.Add(this.pcMid);
            this.pcInfo.Controls.Add(this.pcRight);
            this.pcInfo.Controls.Add(this.pcLeft);
            this.pcInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcInfo.Location = new System.Drawing.Point(3, 0);
            this.pcInfo.Name = "pcInfo";
            this.pcInfo.Size = new System.Drawing.Size(1432, 500);
            this.pcInfo.TabIndex = 0;
            // 
            // pcMid
            // 
            this.pcMid.Appearance.BackColor = System.Drawing.Color.White;
            this.pcMid.Appearance.Options.UseBackColor = true;
            this.pcMid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcMid.Controls.Add(this.ucMonitoringPicture1);
            this.pcMid.Controls.Add(this.ucMonitoringStation1);
            this.pcMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcMid.Location = new System.Drawing.Point(665, 2);
            this.pcMid.Name = "pcMid";
            this.pcMid.Size = new System.Drawing.Size(428, 496);
            this.pcMid.TabIndex = 8;
            // 
            // ucMonitoringStation1
            // 
            this.ucMonitoringStation1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucMonitoringStation1.ExecMergeRibbon = false;
            this.ucMonitoringStation1.Location = new System.Drawing.Point(0, 412);
            this.ucMonitoringStation1.Margin = new System.Windows.Forms.Padding(0);
            this.ucMonitoringStation1.Name = "ucMonitoringStation1";
            this.ucMonitoringStation1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.ucMonitoringStation1.Size = new System.Drawing.Size(428, 84);
            this.ucMonitoringStation1.TabIndex = 8;
            this.ucMonitoringStation1.ZoomFactor = 1F;
            // 
            // pcRight
            // 
            this.pcRight.Appearance.BackColor = System.Drawing.Color.White;
            this.pcRight.Appearance.Options.UseBackColor = true;
            this.pcRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcRight.Controls.Add(this.ucDeviceStatus1);
            this.pcRight.Controls.Add(this.ucStatisticalInformation1);
            this.pcRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pcRight.Location = new System.Drawing.Point(1093, 2);
            this.pcRight.Name = "pcRight";
            this.pcRight.Padding = new System.Windows.Forms.Padding(0, 6, 3, 3);
            this.pcRight.Size = new System.Drawing.Size(337, 496);
            this.pcRight.TabIndex = 6;
            // 
            // ucDeviceStatus1
            // 
            this.ucDeviceStatus1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucDeviceStatus1.Appearance.Options.UseBackColor = true;
            this.ucDeviceStatus1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucDeviceStatus1.ExecMergeRibbon = false;
            this.ucDeviceStatus1.Location = new System.Drawing.Point(0, 373);
            this.ucDeviceStatus1.Margin = new System.Windows.Forms.Padding(0);
            this.ucDeviceStatus1.Name = "ucDeviceStatus1";
            this.ucDeviceStatus1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.ucDeviceStatus1.Size = new System.Drawing.Size(334, 118);
            this.ucDeviceStatus1.TabIndex = 1;
            this.ucDeviceStatus1.ZoomFactor = 1F;
            // 
            // ucStatisticalInformation1
            // 
            this.ucStatisticalInformation1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucStatisticalInformation1.ExecMergeRibbon = false;
            this.ucStatisticalInformation1.Location = new System.Drawing.Point(0, 6);
            this.ucStatisticalInformation1.Margin = new System.Windows.Forms.Padding(0);
            this.ucStatisticalInformation1.Name = "ucStatisticalInformation1";
            this.ucStatisticalInformation1.Size = new System.Drawing.Size(334, 367);
            this.ucStatisticalInformation1.TabIndex = 0;
            this.ucStatisticalInformation1.ZoomFactor = 1F;
            // 
            // pcLeft
            // 
            this.pcLeft.Appearance.BackColor = System.Drawing.Color.White;
            this.pcLeft.Appearance.Options.UseBackColor = true;
            this.pcLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcLeft.Controls.Add(this.ucMonitoringComponent);
            this.pcLeft.Controls.Add(this.ucRealtimeMonitorInfo);
            this.pcLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pcLeft.Location = new System.Drawing.Point(2, 2);
            this.pcLeft.Name = "pcLeft";
            this.pcLeft.Size = new System.Drawing.Size(663, 496);
            this.pcLeft.TabIndex = 4;
            // 
            // ucMonitoringComponent
            // 
            this.ucMonitoringComponent.Appearance.BackColor = System.Drawing.Color.White;
            this.ucMonitoringComponent.Appearance.Options.UseBackColor = true;
            this.ucMonitoringComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMonitoringComponent.ExecMergeRibbon = false;
            this.ucMonitoringComponent.Location = new System.Drawing.Point(0, 323);
            this.ucMonitoringComponent.Margin = new System.Windows.Forms.Padding(0);
            this.ucMonitoringComponent.MinimumSize = new System.Drawing.Size(100, 0);
            this.ucMonitoringComponent.Name = "ucMonitoringComponent";
            this.ucMonitoringComponent.Padding = new System.Windows.Forms.Padding(3, 2, 3, 6);
            this.ucMonitoringComponent.Size = new System.Drawing.Size(663, 173);
            this.ucMonitoringComponent.TabIndex = 4;
            this.ucMonitoringComponent.ZoomFactor = 1F;
            // 
            // ucRealtimeMonitorInfo
            // 
            this.ucRealtimeMonitorInfo.Appearance.BackColor = System.Drawing.Color.White;
            this.ucRealtimeMonitorInfo.Appearance.Options.UseBackColor = true;
            this.ucRealtimeMonitorInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucRealtimeMonitorInfo.ExecMergeRibbon = false;
            this.ucRealtimeMonitorInfo.Location = new System.Drawing.Point(0, 0);
            this.ucRealtimeMonitorInfo.Margin = new System.Windows.Forms.Padding(5);
            this.ucRealtimeMonitorInfo.MinimumSize = new System.Drawing.Size(100, 0);
            this.ucRealtimeMonitorInfo.MonitorPanelEnabled = true;
            this.ucRealtimeMonitorInfo.Name = "ucRealtimeMonitorInfo";
            this.ucRealtimeMonitorInfo.Padding = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.ucRealtimeMonitorInfo.Size = new System.Drawing.Size(663, 323);
            this.ucRealtimeMonitorInfo.TabIndex = 3;
            this.ucRealtimeMonitorInfo.ZoomFactor = 1F;
            // 
            // ucMonitoringResult1
            // 
            this.ucMonitoringResult1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMonitoringResult1.ExecMergeRibbon = false;
            this.ucMonitoringResult1.Location = new System.Drawing.Point(3, 500);
            this.ucMonitoringResult1.Margin = new System.Windows.Forms.Padding(0);
            this.ucMonitoringResult1.Name = "ucMonitoringResult1";
            this.ucMonitoringResult1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.ucMonitoringResult1.Size = new System.Drawing.Size(1432, 260);
            this.ucMonitoringResult1.TabIndex = 1;
            this.ucMonitoringResult1.ZoomFactor = 1F;
            // 
            // ucMonitoringPicture1
            // 
            this.ucMonitoringPicture1.Appearance.BackColor = System.Drawing.Color.White;
            this.ucMonitoringPicture1.Appearance.Options.UseBackColor = true;
            this.ucMonitoringPicture1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ucMonitoringPicture1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMonitoringPicture1.ExecMergeRibbon = false;
            this.ucMonitoringPicture1.FarPicturePath = "";
            this.ucMonitoringPicture1.Location = new System.Drawing.Point(0, 0);
            this.ucMonitoringPicture1.Margin = new System.Windows.Forms.Padding(0);
            this.ucMonitoringPicture1.Name = "ucMonitoringPicture1";
            this.ucMonitoringPicture1.NearPicturePath = "";
            this.ucMonitoringPicture1.Padding = new System.Windows.Forms.Padding(5);
            this.ucMonitoringPicture1.Size = new System.Drawing.Size(428, 412);
            this.ucMonitoringPicture1.TabIndex = 9;
            this.ucMonitoringPicture1.ZoomFactor = 1F;
            // 
            // ucRealtimeMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucMonitoringResult1);
            this.Controls.Add(this.pcInfo);
            this.Name = "ucRealtimeMonitor";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Size = new System.Drawing.Size(1438, 760);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcInfo)).EndInit();
            this.pcInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcMid)).EndInit();
            this.pcMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcRight)).EndInit();
            this.pcRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcLeft)).EndInit();
            this.pcLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcInfo;
        private UserControls.ucMonitoringResult ucMonitoringResult1;
        private DevExpress.XtraEditors.PanelControl pcLeft;
        private DevExpress.XtraEditors.PanelControl pcRight;
        private UserControls.ucMonitoringInfo ucRealtimeMonitorInfo;
        private UserControls.ucStatisticalInformation ucStatisticalInformation1;
        private UserControls.ucDeviceStatus ucDeviceStatus1;
        private UserControls.ucMonitoringComponent ucMonitoringComponent;
        private DevExpress.XtraEditors.PanelControl pcMid;
        private UserControls.ucMonitoringStation ucMonitoringStation1;
        private UserControls.ucMonitoringPicture ucMonitoringPicture1;
    }
}
