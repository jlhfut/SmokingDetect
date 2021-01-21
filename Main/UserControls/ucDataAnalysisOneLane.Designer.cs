namespace wayeal.os.exhaust.UserControls
{
    partial class ucDataAnalysisOneLane
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
            this.pcChart = new DevExpress.XtraEditors.PanelControl();
            this.rgSpectralView = new DevExpress.XtraEditors.RadioGroup();
            this.gcDataCollection = new DevExpress.XtraEditors.GroupControl();
            this.lcCO2DC = new DevExpress.XtraEditors.LabelControl();
            this.lcCO2DCvalue = new DevExpress.XtraEditors.LabelControl();
            this.lcCODC = new DevExpress.XtraEditors.LabelControl();
            this.lcCODCvalue = new DevExpress.XtraEditors.LabelControl();
            this.lcHCDC = new DevExpress.XtraEditors.LabelControl();
            this.lcNODC = new DevExpress.XtraEditors.LabelControl();
            this.lcNODCvalue = new DevExpress.XtraEditors.LabelControl();
            this.lcHCDCvalue = new DevExpress.XtraEditors.LabelControl();
            this.lcLightIntensity = new DevExpress.XtraEditors.LabelControl();
            this.lcLightIntensityValue = new DevExpress.XtraEditors.LabelControl();
            this.lcT13 = new DevExpress.XtraEditors.LabelControl();
            this.lcT12 = new DevExpress.XtraEditors.LabelControl();
            this.lcT1Value = new DevExpress.XtraEditors.LabelControl();
            this.lcT2value = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSpectralView.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDataCollection)).BeginInit();
            this.gcDataCollection.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcChart
            // 
            this.pcChart.Appearance.BackColor = System.Drawing.Color.White;
            this.pcChart.Appearance.Options.UseBackColor = true;
            this.pcChart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pcChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcChart.Location = new System.Drawing.Point(0, 0);
            this.pcChart.Name = "pcChart";
            this.pcChart.Size = new System.Drawing.Size(945, 608);
            this.pcChart.TabIndex = 1;
            // 
            // rgSpectralView
            // 
            this.rgSpectralView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rgSpectralView.EditValue = "riSpectrum";
            this.rgSpectralView.Location = new System.Drawing.Point(0, 608);
            this.rgSpectralView.Margin = new System.Windows.Forms.Padding(5);
            this.rgSpectralView.Name = "rgSpectralView";
            this.rgSpectralView.Properties.AllowFocused = false;
            this.rgSpectralView.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.rgSpectralView.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgSpectralView.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(106)))), ((int)(((byte)(170)))));
            this.rgSpectralView.Properties.Appearance.Options.UseBackColor = true;
            this.rgSpectralView.Properties.Appearance.Options.UseFont = true;
            this.rgSpectralView.Properties.Appearance.Options.UseForeColor = true;
            this.rgSpectralView.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgSpectralView.Properties.ColumnIndent = 12;
            this.rgSpectralView.Properties.Columns = 2;
            this.rgSpectralView.Properties.ItemHorzAlignment = DevExpress.XtraEditors.RadioItemHorzAlignment.Near;
            this.rgSpectralView.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("riSpectrum", "Spectrum"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("riHarmonic", "Abs/Harmonic")});
            this.rgSpectralView.Size = new System.Drawing.Size(945, 40);
            this.rgSpectralView.TabIndex = 3;
            this.rgSpectralView.SelectedIndexChanged += new System.EventHandler(this.rgSpectralView_SelectedIndexChanged);
            // 
            // gcDataCollection
            // 
            this.gcDataCollection.Appearance.BackColor = System.Drawing.Color.White;
            this.gcDataCollection.Appearance.Options.UseBackColor = true;
            this.gcDataCollection.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.gcDataCollection.AppearanceCaption.Options.UseFont = true;
            this.gcDataCollection.Controls.Add(this.lcCO2DC);
            this.gcDataCollection.Controls.Add(this.lcCO2DCvalue);
            this.gcDataCollection.Controls.Add(this.lcCODC);
            this.gcDataCollection.Controls.Add(this.lcCODCvalue);
            this.gcDataCollection.Controls.Add(this.lcHCDC);
            this.gcDataCollection.Controls.Add(this.lcNODC);
            this.gcDataCollection.Controls.Add(this.lcNODCvalue);
            this.gcDataCollection.Controls.Add(this.lcHCDCvalue);
            this.gcDataCollection.Controls.Add(this.lcLightIntensity);
            this.gcDataCollection.Controls.Add(this.lcLightIntensityValue);
            this.gcDataCollection.Controls.Add(this.lcT13);
            this.gcDataCollection.Controls.Add(this.lcT12);
            this.gcDataCollection.Controls.Add(this.lcT1Value);
            this.gcDataCollection.Controls.Add(this.lcT2value);
            this.gcDataCollection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gcDataCollection.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.gcDataCollection.Location = new System.Drawing.Point(0, 648);
            this.gcDataCollection.Name = "gcDataCollection";
            this.gcDataCollection.Size = new System.Drawing.Size(945, 146);
            this.gcDataCollection.TabIndex = 42;
            this.gcDataCollection.Text = "DataCollection";
            // 
            // lcCO2DC
            // 
            this.lcCO2DC.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcCO2DC.Appearance.Options.UseFont = true;
            this.lcCO2DC.Location = new System.Drawing.Point(238, 78);
            this.lcCO2DC.Name = "lcCO2DC";
            this.lcCO2DC.Size = new System.Drawing.Size(45, 16);
            this.lcCO2DC.TabIndex = 48;
            this.lcCO2DC.Text = "CO₂(%)";
            // 
            // lcCO2DCvalue
            // 
            this.lcCO2DCvalue.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcCO2DCvalue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcCO2DCvalue.Appearance.Options.UseFont = true;
            this.lcCO2DCvalue.Appearance.Options.UseForeColor = true;
            this.lcCO2DCvalue.Location = new System.Drawing.Point(365, 78);
            this.lcCO2DCvalue.Name = "lcCO2DCvalue";
            this.lcCO2DCvalue.Size = new System.Drawing.Size(8, 16);
            this.lcCO2DCvalue.TabIndex = 49;
            this.lcCO2DCvalue.Text = "0";
            // 
            // lcCODC
            // 
            this.lcCODC.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcCODC.Appearance.Options.UseFont = true;
            this.lcCODC.Location = new System.Drawing.Point(238, 44);
            this.lcCODC.Name = "lcCODC";
            this.lcCODC.Size = new System.Drawing.Size(39, 16);
            this.lcCODC.TabIndex = 44;
            this.lcCODC.Text = "CO(%)";
            // 
            // lcCODCvalue
            // 
            this.lcCODCvalue.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcCODCvalue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcCODCvalue.Appearance.Options.UseFont = true;
            this.lcCODCvalue.Appearance.Options.UseForeColor = true;
            this.lcCODCvalue.Location = new System.Drawing.Point(365, 44);
            this.lcCODCvalue.Name = "lcCODCvalue";
            this.lcCODCvalue.Size = new System.Drawing.Size(8, 16);
            this.lcCODCvalue.TabIndex = 45;
            this.lcCODCvalue.Text = "0";
            // 
            // lcHCDC
            // 
            this.lcHCDC.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcHCDC.Appearance.Options.UseFont = true;
            this.lcHCDC.Location = new System.Drawing.Point(21, 78);
            this.lcHCDC.Name = "lcHCDC";
            this.lcHCDC.Size = new System.Drawing.Size(51, 16);
            this.lcHCDC.TabIndex = 47;
            this.lcHCDC.Text = "HC(ppm)";
            // 
            // lcNODC
            // 
            this.lcNODC.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcNODC.Appearance.Options.UseFont = true;
            this.lcNODC.Location = new System.Drawing.Point(21, 44);
            this.lcNODC.Name = "lcNODC";
            this.lcNODC.Size = new System.Drawing.Size(52, 16);
            this.lcNODC.TabIndex = 46;
            this.lcNODC.Text = "NO(ppm)";
            // 
            // lcNODCvalue
            // 
            this.lcNODCvalue.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcNODCvalue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcNODCvalue.Appearance.Options.UseFont = true;
            this.lcNODCvalue.Appearance.Options.UseForeColor = true;
            this.lcNODCvalue.Location = new System.Drawing.Point(148, 44);
            this.lcNODCvalue.Name = "lcNODCvalue";
            this.lcNODCvalue.Size = new System.Drawing.Size(8, 16);
            this.lcNODCvalue.TabIndex = 42;
            this.lcNODCvalue.Text = "0";
            // 
            // lcHCDCvalue
            // 
            this.lcHCDCvalue.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcHCDCvalue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcHCDCvalue.Appearance.Options.UseFont = true;
            this.lcHCDCvalue.Appearance.Options.UseForeColor = true;
            this.lcHCDCvalue.Location = new System.Drawing.Point(148, 78);
            this.lcHCDCvalue.Name = "lcHCDCvalue";
            this.lcHCDCvalue.Size = new System.Drawing.Size(8, 16);
            this.lcHCDCvalue.TabIndex = 43;
            this.lcHCDCvalue.Text = "0";
            // 
            // lcLightIntensity
            // 
            this.lcLightIntensity.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcLightIntensity.Appearance.Options.UseFont = true;
            this.lcLightIntensity.Location = new System.Drawing.Point(715, 44);
            this.lcLightIntensity.Name = "lcLightIntensity";
            this.lcLightIntensity.Size = new System.Drawing.Size(83, 16);
            this.lcLightIntensity.TabIndex = 38;
            this.lcLightIntensity.Text = "Light Intensity ";
            // 
            // lcLightIntensityValue
            // 
            this.lcLightIntensityValue.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcLightIntensityValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcLightIntensityValue.Appearance.Options.UseFont = true;
            this.lcLightIntensityValue.Appearance.Options.UseForeColor = true;
            this.lcLightIntensityValue.Location = new System.Drawing.Point(842, 42);
            this.lcLightIntensityValue.Name = "lcLightIntensityValue";
            this.lcLightIntensityValue.Size = new System.Drawing.Size(8, 16);
            this.lcLightIntensityValue.TabIndex = 39;
            this.lcLightIntensityValue.Text = "0";
            // 
            // lcT13
            // 
            this.lcT13.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcT13.Appearance.Options.UseFont = true;
            this.lcT13.Location = new System.Drawing.Point(490, 78);
            this.lcT13.Name = "lcT13";
            this.lcT13.Size = new System.Drawing.Size(45, 16);
            this.lcT13.TabIndex = 41;
            this.lcT13.Text = "T13(μs)";
            // 
            // lcT12
            // 
            this.lcT12.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcT12.Appearance.Options.UseFont = true;
            this.lcT12.Location = new System.Drawing.Point(490, 44);
            this.lcT12.Name = "lcT12";
            this.lcT12.Size = new System.Drawing.Size(45, 16);
            this.lcT12.TabIndex = 40;
            this.lcT12.Text = "T12(μs)";
            // 
            // lcT1Value
            // 
            this.lcT1Value.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcT1Value.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcT1Value.Appearance.Options.UseFont = true;
            this.lcT1Value.Appearance.Options.UseForeColor = true;
            this.lcT1Value.Location = new System.Drawing.Point(617, 44);
            this.lcT1Value.Name = "lcT1Value";
            this.lcT1Value.Size = new System.Drawing.Size(8, 16);
            this.lcT1Value.TabIndex = 36;
            this.lcT1Value.Text = "0";
            // 
            // lcT2value
            // 
            this.lcT2value.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcT2value.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcT2value.Appearance.Options.UseFont = true;
            this.lcT2value.Appearance.Options.UseForeColor = true;
            this.lcT2value.Location = new System.Drawing.Point(617, 78);
            this.lcT2value.Name = "lcT2value";
            this.lcT2value.Size = new System.Drawing.Size(8, 16);
            this.lcT2value.TabIndex = 37;
            this.lcT2value.Text = "0";
            // 
            // ucDataAnalysisOneLane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcChart);
            this.Controls.Add(this.rgSpectralView);
            this.Controls.Add(this.gcDataCollection);
            this.Name = "ucDataAnalysisOneLane";
            this.Size = new System.Drawing.Size(945, 794);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgSpectralView.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDataCollection)).EndInit();
            this.gcDataCollection.ResumeLayout(false);
            this.gcDataCollection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pcChart;
        private DevExpress.XtraEditors.RadioGroup rgSpectralView;
        private DevExpress.XtraEditors.GroupControl gcDataCollection;
        private DevExpress.XtraEditors.LabelControl lcCO2DC;
        private DevExpress.XtraEditors.LabelControl lcCO2DCvalue;
        private DevExpress.XtraEditors.LabelControl lcCODC;
        private DevExpress.XtraEditors.LabelControl lcCODCvalue;
        private DevExpress.XtraEditors.LabelControl lcHCDC;
        private DevExpress.XtraEditors.LabelControl lcNODC;
        private DevExpress.XtraEditors.LabelControl lcNODCvalue;
        private DevExpress.XtraEditors.LabelControl lcHCDCvalue;
        private DevExpress.XtraEditors.LabelControl lcLightIntensity;
        private DevExpress.XtraEditors.LabelControl lcLightIntensityValue;
        private DevExpress.XtraEditors.LabelControl lcT13;
        private DevExpress.XtraEditors.LabelControl lcT12;
        private DevExpress.XtraEditors.LabelControl lcT1Value;
        private DevExpress.XtraEditors.LabelControl lcT2value;
    }
}
