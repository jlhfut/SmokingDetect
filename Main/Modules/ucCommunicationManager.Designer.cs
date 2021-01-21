namespace wayeal.os.exhaust.Modules
{
    partial class ucCommunicationManager
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
            this.rbSerial = new System.Windows.Forms.RadioButton();
            this.rbNetwork = new System.Windows.Forms.RadioButton();
            this.pnCommunication = new DevExpress.XtraEditors.PanelControl();
            this.btSerialApply = new DevExpress.XtraEditors.SimpleButton();
            this.btSearchSerial = new DevExpress.XtraEditors.SimpleButton();
            this.cbParityBits = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbParityBits = new DevExpress.XtraEditors.LabelControl();
            this.cbStopBits = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbStopBits = new DevExpress.XtraEditors.LabelControl();
            this.cbDataBits = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbDataBits = new DevExpress.XtraEditors.LabelControl();
            this.cbBoudRate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbBaudrate = new DevExpress.XtraEditors.LabelControl();
            this.cbSerialNumber = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbSerialNumber = new DevExpress.XtraEditors.LabelControl();
            this.pnNetwork = new DevExpress.XtraEditors.PanelControl();
            this.btNetworkApply = new DevExpress.XtraEditors.SimpleButton();
            this.tbPort = new DevExpress.XtraEditors.TextEdit();
            this.lbPort = new DevExpress.XtraEditors.LabelControl();
            this.tbIPAddr = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnCommunication)).BeginInit();
            this.pnCommunication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbParityBits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStopBits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDataBits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBoudRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSerialNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnNetwork)).BeginInit();
            this.pnNetwork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbIPAddr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rbSerial
            // 
            this.rbSerial.AutoSize = true;
            this.rbSerial.Checked = true;
            this.rbSerial.Location = new System.Drawing.Point(37, 68);
            this.rbSerial.Name = "rbSerial";
            this.rbSerial.Size = new System.Drawing.Size(88, 18);
            this.rbSerial.TabIndex = 2;
            this.rbSerial.TabStop = true;
            this.rbSerial.Text = "Serial(COM)";
            this.rbSerial.UseVisualStyleBackColor = true;
            this.rbSerial.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbNetwork
            // 
            this.rbNetwork.AutoSize = true;
            this.rbNetwork.Location = new System.Drawing.Point(37, 407);
            this.rbNetwork.Name = "rbNetwork";
            this.rbNetwork.Size = new System.Drawing.Size(72, 18);
            this.rbNetwork.TabIndex = 2;
            this.rbNetwork.Text = "Network";
            this.rbNetwork.UseVisualStyleBackColor = true;
            this.rbNetwork.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // pnCommunication
            // 
            this.pnCommunication.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnCommunication.Controls.Add(this.btSerialApply);
            this.pnCommunication.Controls.Add(this.btSearchSerial);
            this.pnCommunication.Controls.Add(this.cbParityBits);
            this.pnCommunication.Controls.Add(this.lbParityBits);
            this.pnCommunication.Controls.Add(this.cbStopBits);
            this.pnCommunication.Controls.Add(this.lbStopBits);
            this.pnCommunication.Controls.Add(this.cbDataBits);
            this.pnCommunication.Controls.Add(this.lbDataBits);
            this.pnCommunication.Controls.Add(this.cbBoudRate);
            this.pnCommunication.Controls.Add(this.lbBaudrate);
            this.pnCommunication.Controls.Add(this.cbSerialNumber);
            this.pnCommunication.Controls.Add(this.lbSerialNumber);
            this.pnCommunication.Location = new System.Drawing.Point(34, 93);
            this.pnCommunication.Name = "pnCommunication";
            this.pnCommunication.Size = new System.Drawing.Size(643, 303);
            this.pnCommunication.TabIndex = 3;
            // 
            // btSerialApply
            // 
            this.btSerialApply.Location = new System.Drawing.Point(4, 266);
            this.btSerialApply.Name = "btSerialApply";
            this.btSerialApply.Size = new System.Drawing.Size(75, 23);
            this.btSerialApply.TabIndex = 3;
            this.btSerialApply.Text = "Apply";
            // 
            // btSearchSerial
            // 
            this.btSearchSerial.Location = new System.Drawing.Point(161, 24);
            this.btSearchSerial.Name = "btSearchSerial";
            this.btSearchSerial.Size = new System.Drawing.Size(75, 23);
            this.btSearchSerial.TabIndex = 2;
            this.btSearchSerial.Text = "Search";
            // 
            // cbParityBits
            // 
            this.cbParityBits.Location = new System.Drawing.Point(4, 224);
            this.cbParityBits.Name = "cbParityBits";
            this.cbParityBits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbParityBits.Size = new System.Drawing.Size(150, 20);
            this.cbParityBits.TabIndex = 1;
            // 
            // lbParityBits
            // 
            this.lbParityBits.Location = new System.Drawing.Point(4, 203);
            this.lbParityBits.Name = "lbParityBits";
            this.lbParityBits.Size = new System.Drawing.Size(53, 14);
            this.lbParityBits.TabIndex = 0;
            this.lbParityBits.Text = "Parity Bits";
            // 
            // cbStopBits
            // 
            this.cbStopBits.Location = new System.Drawing.Point(4, 172);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbStopBits.Size = new System.Drawing.Size(150, 20);
            this.cbStopBits.TabIndex = 1;
            // 
            // lbStopBits
            // 
            this.lbStopBits.Location = new System.Drawing.Point(4, 151);
            this.lbStopBits.Name = "lbStopBits";
            this.lbStopBits.Size = new System.Drawing.Size(49, 14);
            this.lbStopBits.TabIndex = 0;
            this.lbStopBits.Text = "Stop Bits";
            // 
            // cbDataBits
            // 
            this.cbDataBits.Location = new System.Drawing.Point(4, 121);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDataBits.Size = new System.Drawing.Size(150, 20);
            this.cbDataBits.TabIndex = 1;
            // 
            // lbDataBits
            // 
            this.lbDataBits.Location = new System.Drawing.Point(4, 100);
            this.lbDataBits.Name = "lbDataBits";
            this.lbDataBits.Size = new System.Drawing.Size(48, 14);
            this.lbDataBits.TabIndex = 0;
            this.lbDataBits.Text = "Data Bits";
            // 
            // cbBoudRate
            // 
            this.cbBoudRate.Location = new System.Drawing.Point(4, 73);
            this.cbBoudRate.Name = "cbBoudRate";
            this.cbBoudRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBoudRate.Size = new System.Drawing.Size(150, 20);
            this.cbBoudRate.TabIndex = 1;
            // 
            // lbBaudrate
            // 
            this.lbBaudrate.Location = new System.Drawing.Point(4, 52);
            this.lbBaudrate.Name = "lbBaudrate";
            this.lbBaudrate.Size = new System.Drawing.Size(57, 14);
            this.lbBaudrate.TabIndex = 0;
            this.lbBaudrate.Text = "Boud Rate";
            // 
            // cbSerialNumber
            // 
            this.cbSerialNumber.Location = new System.Drawing.Point(4, 25);
            this.cbSerialNumber.Name = "cbSerialNumber";
            this.cbSerialNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSerialNumber.Size = new System.Drawing.Size(150, 20);
            this.cbSerialNumber.TabIndex = 1;
            // 
            // lbSerialNumber
            // 
            this.lbSerialNumber.Location = new System.Drawing.Point(4, 4);
            this.lbSerialNumber.Name = "lbSerialNumber";
            this.lbSerialNumber.Size = new System.Drawing.Size(75, 14);
            this.lbSerialNumber.TabIndex = 0;
            this.lbSerialNumber.Text = "Serial Number";
            // 
            // pnNetwork
            // 
            this.pnNetwork.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnNetwork.Controls.Add(this.btNetworkApply);
            this.pnNetwork.Controls.Add(this.tbPort);
            this.pnNetwork.Controls.Add(this.lbPort);
            this.pnNetwork.Controls.Add(this.tbIPAddr);
            this.pnNetwork.Controls.Add(this.labelControl1);
            this.pnNetwork.Enabled = false;
            this.pnNetwork.Location = new System.Drawing.Point(34, 432);
            this.pnNetwork.Name = "pnNetwork";
            this.pnNetwork.Size = new System.Drawing.Size(643, 157);
            this.pnNetwork.TabIndex = 4;
            // 
            // btNetworkApply
            // 
            this.btNetworkApply.Location = new System.Drawing.Point(4, 117);
            this.btNetworkApply.Name = "btNetworkApply";
            this.btNetworkApply.Size = new System.Drawing.Size(75, 23);
            this.btNetworkApply.TabIndex = 3;
            this.btNetworkApply.Text = "Apply";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(4, 77);
            this.tbPort.Name = "tbPort";
            this.tbPort.Properties.Mask.EditMask = "[1-9][0-9]{0,3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]{1}|655" +
    "3[0-5]";
            this.tbPort.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.tbPort.Size = new System.Drawing.Size(150, 20);
            this.tbPort.TabIndex = 2;
            // 
            // lbPort
            // 
            this.lbPort.Location = new System.Drawing.Point(4, 56);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(23, 14);
            this.lbPort.TabIndex = 0;
            this.lbPort.Text = "Port";
            // 
            // tbIPAddr
            // 
            this.tbIPAddr.Location = new System.Drawing.Point(4, 28);
            this.tbIPAddr.Name = "tbIPAddr";
            this.tbIPAddr.Properties.Mask.EditMask = "((([1-9]?|1\\d)\\d|2([0-4]\\d|5[0-5]))\\.){3}(([1-9]?|1\\d)\\d|2([0-4]\\d|5[0-5]))";
            this.tbIPAddr.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.tbIPAddr.Size = new System.Drawing.Size(150, 20);
            this.tbIPAddr.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "IP Address";
            // 
            // ucCommunicationManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnNetwork);
            this.Controls.Add(this.pnCommunication);
            this.Controls.Add(this.rbNetwork);
            this.Controls.Add(this.rbSerial);
            this.Name = "ucCommunicationManager";
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnCommunication)).EndInit();
            this.pnCommunication.ResumeLayout(false);
            this.pnCommunication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbParityBits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStopBits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDataBits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBoudRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSerialNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnNetwork)).EndInit();
            this.pnNetwork.ResumeLayout(false);
            this.pnNetwork.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbIPAddr.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbSerial;
        private System.Windows.Forms.RadioButton rbNetwork;
        private DevExpress.XtraEditors.PanelControl pnCommunication;
        private DevExpress.XtraEditors.ComboBoxEdit cbParityBits;
        private DevExpress.XtraEditors.LabelControl lbParityBits;
        private DevExpress.XtraEditors.ComboBoxEdit cbStopBits;
        private DevExpress.XtraEditors.LabelControl lbStopBits;
        private DevExpress.XtraEditors.ComboBoxEdit cbDataBits;
        private DevExpress.XtraEditors.LabelControl lbDataBits;
        private DevExpress.XtraEditors.ComboBoxEdit cbBoudRate;
        private DevExpress.XtraEditors.LabelControl lbBaudrate;
        private DevExpress.XtraEditors.ComboBoxEdit cbSerialNumber;
        private DevExpress.XtraEditors.LabelControl lbSerialNumber;
        private DevExpress.XtraEditors.SimpleButton btSerialApply;
        private DevExpress.XtraEditors.SimpleButton btSearchSerial;
        private DevExpress.XtraEditors.PanelControl pnNetwork;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit tbIPAddr;
        private DevExpress.XtraEditors.TextEdit tbPort;
        private DevExpress.XtraEditors.LabelControl lbPort;
        private DevExpress.XtraEditors.SimpleButton btNetworkApply;
    }
}
