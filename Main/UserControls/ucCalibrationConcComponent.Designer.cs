namespace wayeal.os.exhaust.UserControls
{
    partial class ucCalibrationConcComponent
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
            DevExpress.XtraCharts.SwiftPlotDiagram swiftPlotDiagram1 = new DevExpress.XtraCharts.SwiftPlotDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView1 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView2 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lcConponent = new DevExpress.XtraEditors.LabelControl();
            this.lcValue = new DevExpress.XtraEditors.LabelControl();
            this.lcUnit = new DevExpress.XtraEditors.LabelControl();
            this.ccSpectrum = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ccSpectrum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.lcConponent);
            this.panelControl1.Controls.Add(this.lcValue);
            this.panelControl1.Controls.Add(this.lcUnit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl1.Size = new System.Drawing.Size(200, 113);
            this.panelControl1.TabIndex = 0;
            // 
            // lcConponent
            // 
            this.lcConponent.Appearance.Font = new System.Drawing.Font("Tahoma", 26F, System.Drawing.FontStyle.Bold);
            this.lcConponent.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lcConponent.Appearance.Options.UseFont = true;
            this.lcConponent.Appearance.Options.UseForeColor = true;
            this.lcConponent.Appearance.Options.UseTextOptions = true;
            this.lcConponent.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lcConponent.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lcConponent.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lcConponent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcConponent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcConponent.Location = new System.Drawing.Point(10, 10);
            this.lcConponent.Name = "lcConponent";
            this.lcConponent.Size = new System.Drawing.Size(180, 45);
            this.lcConponent.TabIndex = 2;
            this.lcConponent.Text = "--";
            // 
            // lcValue
            // 
            this.lcValue.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            this.lcValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lcValue.Appearance.Options.UseFont = true;
            this.lcValue.Appearance.Options.UseForeColor = true;
            this.lcValue.Appearance.Options.UseTextOptions = true;
            this.lcValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lcValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lcValue.Location = new System.Drawing.Point(10, 55);
            this.lcValue.Name = "lcValue";
            this.lcValue.Size = new System.Drawing.Size(180, 29);
            this.lcValue.TabIndex = 1;
            this.lcValue.Text = "0";
            // 
            // lcUnit
            // 
            this.lcUnit.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lcUnit.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lcUnit.Appearance.Options.UseFont = true;
            this.lcUnit.Appearance.Options.UseForeColor = true;
            this.lcUnit.Appearance.Options.UseTextOptions = true;
            this.lcUnit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcUnit.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lcUnit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lcUnit.Location = new System.Drawing.Point(10, 84);
            this.lcUnit.Name = "lcUnit";
            this.lcUnit.Size = new System.Drawing.Size(180, 19);
            this.lcUnit.TabIndex = 0;
            this.lcUnit.Text = "ppm";
            // 
            // ccSpectrum
            // 
            swiftPlotDiagram1.AxisX.GridLines.MinorLineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            swiftPlotDiagram1.AxisX.GridLines.Visible = true;
            swiftPlotDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.False;
            swiftPlotDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.False;
            swiftPlotDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.DefaultPane.BorderVisible = false;
            swiftPlotDiagram1.DefaultPane.SelectionRectangle.BorderVisible = false;
            swiftPlotDiagram1.DependentAxesYRange = DevExpress.Utils.DefaultBoolean.False;
            swiftPlotDiagram1.Margins.Bottom = 0;
            swiftPlotDiagram1.Margins.Left = 0;
            swiftPlotDiagram1.Margins.Right = 0;
            swiftPlotDiagram1.Margins.Top = 0;
            swiftPlotDiagram1.PaneLayoutDirection = DevExpress.XtraCharts.PaneLayoutDirection.Horizontal;
            this.ccSpectrum.Diagram = swiftPlotDiagram1;
            this.ccSpectrum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ccSpectrum.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left;
            this.ccSpectrum.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
            this.ccSpectrum.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.ccSpectrum.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.ccSpectrum.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBox;
            this.ccSpectrum.Legend.Name = "Default Legend";
            this.ccSpectrum.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.ccSpectrum.Location = new System.Drawing.Point(200, 0);
            this.ccSpectrum.Margin = new System.Windows.Forms.Padding(0);
            this.ccSpectrum.Name = "ccSpectrum";
            series1.Name = "Active Spectrum";
            swiftPlotSeriesView1.AggregateFunction = DevExpress.XtraCharts.SeriesAggregateFunction.None;
            swiftPlotSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            series1.View = swiftPlotSeriesView1;
            this.ccSpectrum.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            swiftPlotSeriesView2.LineStyle.Thickness = 2;
            this.ccSpectrum.SeriesTemplate.View = swiftPlotSeriesView2;
            this.ccSpectrum.Size = new System.Drawing.Size(617, 113);
            this.ccSpectrum.TabIndex = 5;
            // 
            // ucCalibrationConcComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ccSpectrum);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucCalibrationConcComponent";
            this.Size = new System.Drawing.Size(817, 113);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(swiftPlotDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ccSpectrum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lcConponent;
        private DevExpress.XtraEditors.LabelControl lcValue;
        private DevExpress.XtraEditors.LabelControl lcUnit;
        public DevExpress.XtraCharts.ChartControl ccSpectrum;
    }
}
