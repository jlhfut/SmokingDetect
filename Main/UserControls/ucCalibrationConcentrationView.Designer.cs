namespace wayeal.os.exhaust.UserControls
{
    partial class ucCalibrationConcentrationView
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
            this.cccOpacity = new wayeal.os.exhaust.UserControls.ucCalibrationConcComponent();
            this.cccCO2 = new wayeal.os.exhaust.UserControls.ucCalibrationConcComponent();
            this.cccCO = new wayeal.os.exhaust.UserControls.ucCalibrationConcComponent();
            this.cccHC = new wayeal.os.exhaust.UserControls.ucCalibrationConcComponent();
            this.cccNO = new wayeal.os.exhaust.UserControls.ucCalibrationConcComponent();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            this.SuspendLayout();
            // 
            // cccOpacity
            // 
            this.cccOpacity.Caption = "Opa";
            this.cccOpacity.Dock = System.Windows.Forms.DockStyle.Top;
            this.cccOpacity.ExecMergeRibbon = false;
            this.cccOpacity.Location = new System.Drawing.Point(3, 483);
            this.cccOpacity.Margin = new System.Windows.Forms.Padding(0);
            this.cccOpacity.Name = "cccOpacity";
            this.cccOpacity.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.cccOpacity.Size = new System.Drawing.Size(677, 120);
            this.cccOpacity.TabIndex = 14;
            this.cccOpacity.UnitText = "%";
            this.cccOpacity.Value = "0";
            this.cccOpacity.ZoomFactor = 1F;
            // 
            // cccCO2
            // 
            this.cccCO2.Caption = "CO₂";
            this.cccCO2.Dock = System.Windows.Forms.DockStyle.Top;
            this.cccCO2.ExecMergeRibbon = false;
            this.cccCO2.Location = new System.Drawing.Point(3, 363);
            this.cccCO2.Margin = new System.Windows.Forms.Padding(0);
            this.cccCO2.Name = "cccCO2";
            this.cccCO2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.cccCO2.Size = new System.Drawing.Size(677, 120);
            this.cccCO2.TabIndex = 13;
            this.cccCO2.UnitText = "%";
            this.cccCO2.Value = "0";
            this.cccCO2.ZoomFactor = 1F;
            // 
            // cccCO
            // 
            this.cccCO.Caption = "CO";
            this.cccCO.Dock = System.Windows.Forms.DockStyle.Top;
            this.cccCO.ExecMergeRibbon = false;
            this.cccCO.Location = new System.Drawing.Point(3, 243);
            this.cccCO.Margin = new System.Windows.Forms.Padding(0);
            this.cccCO.Name = "cccCO";
            this.cccCO.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.cccCO.Size = new System.Drawing.Size(677, 120);
            this.cccCO.TabIndex = 12;
            this.cccCO.UnitText = "%";
            this.cccCO.Value = "0";
            this.cccCO.ZoomFactor = 1F;
            // 
            // cccHC
            // 
            this.cccHC.Caption = "HC";
            this.cccHC.Dock = System.Windows.Forms.DockStyle.Top;
            this.cccHC.ExecMergeRibbon = false;
            this.cccHC.Location = new System.Drawing.Point(3, 123);
            this.cccHC.Margin = new System.Windows.Forms.Padding(0);
            this.cccHC.Name = "cccHC";
            this.cccHC.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.cccHC.Size = new System.Drawing.Size(677, 120);
            this.cccHC.TabIndex = 11;
            this.cccHC.UnitText = "ppm";
            this.cccHC.Value = "0";
            this.cccHC.ZoomFactor = 1F;
            // 
            // cccNO
            // 
            this.cccNO.Caption = "NO";
            this.cccNO.Dock = System.Windows.Forms.DockStyle.Top;
            this.cccNO.ExecMergeRibbon = false;
            this.cccNO.Location = new System.Drawing.Point(3, 3);
            this.cccNO.Margin = new System.Windows.Forms.Padding(0);
            this.cccNO.Name = "cccNO";
            this.cccNO.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.cccNO.Size = new System.Drawing.Size(677, 120);
            this.cccNO.TabIndex = 10;
            this.cccNO.UnitText = "ppm";
            this.cccNO.Value = "0";
            this.cccNO.ZoomFactor = 1F;
            // 
            // ucCalibrationConcentrationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cccOpacity);
            this.Controls.Add(this.cccCO2);
            this.Controls.Add(this.cccCO);
            this.Controls.Add(this.cccHC);
            this.Controls.Add(this.cccNO);
            this.Name = "ucCalibrationConcentrationView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(683, 698);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucCalibrationConcComponent cccOpacity;
        private ucCalibrationConcComponent cccCO2;
        private ucCalibrationConcComponent cccCO;
        private ucCalibrationConcComponent cccHC;
        private ucCalibrationConcComponent cccNO;
    }
}
