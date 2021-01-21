namespace wayeal.exdevice
{
    partial class ucDeviceBase
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
            this.SaveCompleted = new DevExpress.XtraEditors.LabelControl();
            this.SaveFail = new DevExpress.XtraEditors.LabelControl();
            this.lcSaveDevice = new DevExpress.XtraEditors.LabelControl();
            this.lcDeviceName = new DevExpress.XtraEditors.LabelControl();
            this.lcComName = new DevExpress.XtraEditors.LabelControl();
            this.lcUseDevice = new DevExpress.XtraEditors.LabelControl();
            this.lcNotUseDevice = new DevExpress.XtraEditors.LabelControl();
            this.gcUserName = new DevExpress.XtraEditors.LabelControl();
            this.lcPassword2 = new DevExpress.XtraEditors.LabelControl();
            this.lcPlatNum = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // SaveCompleted
            // 
            this.SaveCompleted.Location = new System.Drawing.Point(510, 390);
            this.SaveCompleted.Name = "SaveCompleted";
            this.SaveCompleted.Size = new System.Drawing.Size(157, 14);
            this.SaveCompleted.TabIndex = 83;
            this.SaveCompleted.Text = "Save parameters completed!";
            this.SaveCompleted.Visible = false;
            // 
            // SaveFail
            // 
            this.SaveFail.Location = new System.Drawing.Point(391, 390);
            this.SaveFail.Name = "SaveFail";
            this.SaveFail.Size = new System.Drawing.Size(113, 14);
            this.SaveFail.TabIndex = 84;
            this.SaveFail.Text = "Save parameters fail!";
            this.SaveFail.Visible = false;
            // 
            // lcSaveDevice
            // 
            this.lcSaveDevice.Location = new System.Drawing.Point(323, 390);
            this.lcSaveDevice.Name = "lcSaveDevice";
            this.lcSaveDevice.Size = new System.Drawing.Size(62, 14);
            this.lcSaveDevice.TabIndex = 85;
            this.lcSaveDevice.Text = "SaveDevice";
            this.lcSaveDevice.Visible = false;
            // 
            // lcDeviceName
            // 
            this.lcDeviceName.Location = new System.Drawing.Point(0, 410);
            this.lcDeviceName.Name = "lcDeviceName";
            this.lcDeviceName.Size = new System.Drawing.Size(67, 14);
            this.lcDeviceName.TabIndex = 86;
            this.lcDeviceName.Text = "DeviceName";
            this.lcDeviceName.Visible = false;
            // 
            // lcComName
            // 
            this.lcComName.Location = new System.Drawing.Point(73, 410);
            this.lcComName.Name = "lcComName";
            this.lcComName.Size = new System.Drawing.Size(55, 14);
            this.lcComName.TabIndex = 87;
            this.lcComName.Text = "ComName";
            this.lcComName.Visible = false;
            // 
            // lcUseDevice
            // 
            this.lcUseDevice.Location = new System.Drawing.Point(85, 390);
            this.lcUseDevice.Name = "lcUseDevice";
            this.lcUseDevice.Size = new System.Drawing.Size(56, 14);
            this.lcUseDevice.TabIndex = 88;
            this.lcUseDevice.Text = "UseDevice";
            this.lcUseDevice.Visible = false;
            // 
            // lcNotUseDevice
            // 
            this.lcNotUseDevice.Location = new System.Drawing.Point(3, 390);
            this.lcNotUseDevice.Name = "lcNotUseDevice";
            this.lcNotUseDevice.Size = new System.Drawing.Size(76, 14);
            this.lcNotUseDevice.TabIndex = 89;
            this.lcNotUseDevice.Text = "NotUseDevice";
            this.lcNotUseDevice.Visible = false;
            // 
            // gcUserName
            // 
            this.gcUserName.Location = new System.Drawing.Point(147, 390);
            this.gcUserName.Name = "gcUserName";
            this.gcUserName.Size = new System.Drawing.Size(55, 14);
            this.gcUserName.TabIndex = 90;
            this.gcUserName.Text = "UserName";
            this.gcUserName.Visible = false;
            // 
            // lcPassword2
            // 
            this.lcPassword2.Location = new System.Drawing.Point(208, 390);
            this.lcPassword2.Name = "lcPassword2";
            this.lcPassword2.Size = new System.Drawing.Size(51, 14);
            this.lcPassword2.TabIndex = 91;
            this.lcPassword2.Text = "Password";
            this.lcPassword2.Visible = false;
            // 
            // lcPlatNum
            // 
            this.lcPlatNum.Location = new System.Drawing.Point(268, 390);
            this.lcPlatNum.Name = "lcPlatNum";
            this.lcPlatNum.Size = new System.Drawing.Size(45, 14);
            this.lcPlatNum.TabIndex = 92;
            this.lcPlatNum.Text = "PlatNum";
            this.lcPlatNum.Visible = false;
            // 
            // ucDeviceBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lcPlatNum);
            this.Controls.Add(this.lcPassword2);
            this.Controls.Add(this.gcUserName);
            this.Controls.Add(this.lcNotUseDevice);
            this.Controls.Add(this.lcUseDevice);
            this.Controls.Add(this.lcComName);
            this.Controls.Add(this.lcDeviceName);
            this.Controls.Add(this.lcSaveDevice);
            this.Controls.Add(this.SaveFail);
            this.Controls.Add(this.SaveCompleted);
            this.Name = "ucDeviceBase";
            this.Size = new System.Drawing.Size(785, 429);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl SaveCompleted;
        private DevExpress.XtraEditors.LabelControl SaveFail;
        private DevExpress.XtraEditors.LabelControl lcSaveDevice;
        private DevExpress.XtraEditors.LabelControl lcDeviceName;
        private DevExpress.XtraEditors.LabelControl lcComName;
        private DevExpress.XtraEditors.LabelControl lcUseDevice;
        private DevExpress.XtraEditors.LabelControl lcNotUseDevice;
        private DevExpress.XtraEditors.LabelControl gcUserName;
        private DevExpress.XtraEditors.LabelControl lcPassword2;
        private DevExpress.XtraEditors.LabelControl lcPlatNum;
    }
}
