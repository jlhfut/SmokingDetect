namespace wayeal.os.exhaust.Forms
{
    partial class wfTimingCalibration
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.TableLayout.ItemTemplateBase itemTemplateBase1 = new DevExpress.XtraEditors.TableLayout.ItemTemplateBase();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement1 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            this.lcAutoCalibrateZero = new DevExpress.XtraEditors.LabelControl();
            this.ceAutoCalibrateZero = new DevExpress.XtraEditors.CheckEdit();
            this.ceAutoCalibrateRange = new DevExpress.XtraEditors.CheckEdit();
            this.lcAutoCalibrateRange = new DevExpress.XtraEditors.LabelControl();
            this.teAutoCalibrateZeroInterval = new DevExpress.XtraEditors.TextEdit();
            this.lcAutoCalibrateZeroInterval = new DevExpress.XtraEditors.LabelControl();
            this.lcTimes = new DevExpress.XtraEditors.LabelControl();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.sbSave = new DevExpress.XtraEditors.SimpleButton();
            this.clbcTimes = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.ceAutoCalibrateZero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAutoCalibrateRange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAutoCalibrateZeroInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbcTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // lcAutoCalibrateZero
            // 
            this.lcAutoCalibrateZero.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcAutoCalibrateZero.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcAutoCalibrateZero.Appearance.Options.UseFont = true;
            this.lcAutoCalibrateZero.Appearance.Options.UseForeColor = true;
            this.lcAutoCalibrateZero.Appearance.Options.UseTextOptions = true;
            this.lcAutoCalibrateZero.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcAutoCalibrateZero.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcAutoCalibrateZero.Location = new System.Drawing.Point(15, 15);
            this.lcAutoCalibrateZero.Name = "lcAutoCalibrateZero";
            this.lcAutoCalibrateZero.Size = new System.Drawing.Size(174, 16);
            this.lcAutoCalibrateZero.TabIndex = 6;
            this.lcAutoCalibrateZero.Text = "Auto Calibrate Zero";
            // 
            // ceAutoCalibrateZero
            // 
            this.ceAutoCalibrateZero.Location = new System.Drawing.Point(200, 13);
            this.ceAutoCalibrateZero.Name = "ceAutoCalibrateZero";
            this.ceAutoCalibrateZero.Properties.AllowFocused = false;
            this.ceAutoCalibrateZero.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ceAutoCalibrateZero.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(106)))), ((int)(((byte)(170)))));
            this.ceAutoCalibrateZero.Properties.Appearance.Options.UseFont = true;
            this.ceAutoCalibrateZero.Properties.Appearance.Options.UseForeColor = true;
            this.ceAutoCalibrateZero.Properties.Caption = "Air Pump";
            this.ceAutoCalibrateZero.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.ceAutoCalibrateZero.Properties.ImageOptions.ImageChecked = global::wayeal.os.exhaust.Properties.Resources.开启;
            this.ceAutoCalibrateZero.Properties.ImageOptions.ImageUnchecked = global::wayeal.os.exhaust.Properties.Resources.关闭;
            this.ceAutoCalibrateZero.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ceAutoCalibrateZero.Size = new System.Drawing.Size(42, 22);
            this.ceAutoCalibrateZero.TabIndex = 5;
            // 
            // ceAutoCalibrateRange
            // 
            this.ceAutoCalibrateRange.Location = new System.Drawing.Point(200, 44);
            this.ceAutoCalibrateRange.Name = "ceAutoCalibrateRange";
            this.ceAutoCalibrateRange.Properties.AllowFocused = false;
            this.ceAutoCalibrateRange.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ceAutoCalibrateRange.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(106)))), ((int)(((byte)(170)))));
            this.ceAutoCalibrateRange.Properties.Appearance.Options.UseFont = true;
            this.ceAutoCalibrateRange.Properties.Appearance.Options.UseForeColor = true;
            this.ceAutoCalibrateRange.Properties.Caption = "Air Pump";
            this.ceAutoCalibrateRange.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.ceAutoCalibrateRange.Properties.ImageOptions.ImageChecked = global::wayeal.os.exhaust.Properties.Resources.开启;
            this.ceAutoCalibrateRange.Properties.ImageOptions.ImageUnchecked = global::wayeal.os.exhaust.Properties.Resources.关闭;
            this.ceAutoCalibrateRange.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ceAutoCalibrateRange.Size = new System.Drawing.Size(42, 22);
            this.ceAutoCalibrateRange.TabIndex = 5;
            // 
            // lcAutoCalibrateRange
            // 
            this.lcAutoCalibrateRange.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcAutoCalibrateRange.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcAutoCalibrateRange.Appearance.Options.UseFont = true;
            this.lcAutoCalibrateRange.Appearance.Options.UseForeColor = true;
            this.lcAutoCalibrateRange.Appearance.Options.UseTextOptions = true;
            this.lcAutoCalibrateRange.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcAutoCalibrateRange.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcAutoCalibrateRange.Location = new System.Drawing.Point(15, 46);
            this.lcAutoCalibrateRange.Name = "lcAutoCalibrateRange";
            this.lcAutoCalibrateRange.Size = new System.Drawing.Size(174, 16);
            this.lcAutoCalibrateRange.TabIndex = 6;
            this.lcAutoCalibrateRange.Text = "Auto Calibrate Range";
            // 
            // teAutoCalibrateZeroInterval
            // 
            this.teAutoCalibrateZeroInterval.EditValue = "";
            this.teAutoCalibrateZeroInterval.Location = new System.Drawing.Point(200, 78);
            this.teAutoCalibrateZeroInterval.Name = "teAutoCalibrateZeroInterval";
            this.teAutoCalibrateZeroInterval.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.teAutoCalibrateZeroInterval.Properties.Appearance.Options.UseFont = true;
            this.teAutoCalibrateZeroInterval.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
            this.teAutoCalibrateZeroInterval.Properties.Mask.BeepOnError = true;
            this.teAutoCalibrateZeroInterval.Size = new System.Drawing.Size(241, 22);
            this.teAutoCalibrateZeroInterval.TabIndex = 72;
            // 
            // lcAutoCalibrateZeroInterval
            // 
            this.lcAutoCalibrateZeroInterval.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcAutoCalibrateZeroInterval.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcAutoCalibrateZeroInterval.Appearance.Options.UseFont = true;
            this.lcAutoCalibrateZeroInterval.Appearance.Options.UseForeColor = true;
            this.lcAutoCalibrateZeroInterval.Appearance.Options.UseTextOptions = true;
            this.lcAutoCalibrateZeroInterval.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcAutoCalibrateZeroInterval.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcAutoCalibrateZeroInterval.Location = new System.Drawing.Point(15, 81);
            this.lcAutoCalibrateZeroInterval.Name = "lcAutoCalibrateZeroInterval";
            this.lcAutoCalibrateZeroInterval.Size = new System.Drawing.Size(174, 16);
            this.lcAutoCalibrateZeroInterval.TabIndex = 71;
            this.lcAutoCalibrateZeroInterval.Text = "Auto Calibrate Zero Interval(s)";
            // 
            // lcTimes
            // 
            this.lcTimes.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcTimes.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcTimes.Appearance.Options.UseFont = true;
            this.lcTimes.Appearance.Options.UseForeColor = true;
            this.lcTimes.Appearance.Options.UseTextOptions = true;
            this.lcTimes.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcTimes.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcTimes.Location = new System.Drawing.Point(15, 113);
            this.lcTimes.Name = "lcTimes";
            this.lcTimes.Size = new System.Drawing.Size(174, 16);
            this.lcTimes.TabIndex = 71;
            this.lcTimes.Text = "Auto Calibrate Times";
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            // 
            // sbSave
            // 
            this.sbSave.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbSave.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbSave.Appearance.Image = global::wayeal.os.exhaust.Properties.Resources.弹窗上的按钮;
            this.sbSave.Appearance.Options.UseBackColor = true;
            this.sbSave.Appearance.Options.UseFont = true;
            this.sbSave.Appearance.Options.UseForeColor = true;
            this.sbSave.Appearance.Options.UseImage = true;
            this.sbSave.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbSave.AppearanceHovered.Options.UseBackColor = true;
            this.sbSave.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbSave.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbSave.AppearancePressed.Image = global::wayeal.os.exhaust.Properties.Resources.弹窗上的按钮按下;
            this.sbSave.AppearancePressed.Options.UseBackColor = true;
            this.sbSave.AppearancePressed.Options.UseFont = true;
            this.sbSave.AppearancePressed.Options.UseImage = true;
            this.sbSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbSave.Location = new System.Drawing.Point(348, 368);
            this.sbSave.Name = "sbSave";
            this.sbSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbSave.Size = new System.Drawing.Size(93, 28);
            this.sbSave.TabIndex = 76;
            this.sbSave.Text = "Save";
            this.sbSave.Click += new System.EventHandler(this.sbSave_Click);
            // 
            // clbcTimes
            // 
            this.clbcTimes.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.clbcTimes.Appearance.Options.UseFont = true;
            this.clbcTimes.CheckOnClick = true;
            this.clbcTimes.ColumnWidth = 80;
            this.clbcTimes.ItemHeight = 30;
            this.clbcTimes.Location = new System.Drawing.Point(200, 113);
            this.clbcTimes.MultiColumn = true;
            this.clbcTimes.Name = "clbcTimes";
            this.clbcTimes.Size = new System.Drawing.Size(242, 242);
            this.clbcTimes.TabIndex = 77;
            tableColumnDefinition1.Length.Value = 79D;
            itemTemplateBase1.Columns.Add(tableColumnDefinition1);
            templatedItemElement1.FieldName = "Text";
            templatedItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement1.Text = "Text";
            templatedItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            itemTemplateBase1.Elements.Add(templatedItemElement1);
            itemTemplateBase1.Name = "TimeTemplate";
            tableRowDefinition1.Length.Value = 13D;
            tableRowDefinition1.PaddingBottom = 2;
            itemTemplateBase1.Rows.Add(tableRowDefinition1);
            this.clbcTimes.Templates.Add(itemTemplateBase1);
            this.clbcTimes.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.clbcTimes_ItemCheck);
            this.clbcTimes.DataSourceChanged += new System.EventHandler(this.clbcTimes_DataSourceChanged);
            // 
            // wfTimingCalibration
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 408);
            this.Controls.Add(this.clbcTimes);
            this.Controls.Add(this.sbSave);
            this.Controls.Add(this.teAutoCalibrateZeroInterval);
            this.Controls.Add(this.lcTimes);
            this.Controls.Add(this.lcAutoCalibrateZeroInterval);
            this.Controls.Add(this.lcAutoCalibrateRange);
            this.Controls.Add(this.ceAutoCalibrateRange);
            this.Controls.Add(this.lcAutoCalibrateZero);
            this.Controls.Add(this.ceAutoCalibrateZero);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wfTimingCalibration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Timing Calibration";
            ((System.ComponentModel.ISupportInitialize)(this.ceAutoCalibrateZero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAutoCalibrateRange.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAutoCalibrateZeroInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbcTimes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lcAutoCalibrateZero;
        private DevExpress.XtraEditors.CheckEdit ceAutoCalibrateZero;
        private DevExpress.XtraEditors.CheckEdit ceAutoCalibrateRange;
        private DevExpress.XtraEditors.LabelControl lcAutoCalibrateRange;
        private DevExpress.XtraEditors.TextEdit teAutoCalibrateZeroInterval;
        private DevExpress.XtraEditors.LabelControl lcAutoCalibrateZeroInterval;
        private DevExpress.XtraEditors.LabelControl lcTimes;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraEditors.SimpleButton sbSave;
        private DevExpress.XtraEditors.CheckedListBoxControl clbcTimes;
    }
}