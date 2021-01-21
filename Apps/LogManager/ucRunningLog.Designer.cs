﻿namespace wayeal.plugin
{
    partial class ucRunningLog
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelQuary = new System.Windows.Forms.Panel();
            this.beLogContent = new DevExpress.XtraEditors.ButtonEdit();
            this.lcLogContent = new DevExpress.XtraEditors.LabelControl();
            this.lcQuaryTime = new DevExpress.XtraEditors.LabelControl();
            this.sbSearch = new DevExpress.XtraEditors.SimpleButton();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.lcTilde = new System.Windows.Forms.Label();
            this.pcData = new DevExpress.XtraEditors.PanelControl();
            this.gcRunningLog = new DevExpress.XtraGrid.GridControl();
            this.gvAirQuality = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTheTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLogContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager();
            this.pcBottom = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tsbGotoPage = new DevExpress.XtraEditors.SimpleButton();
            this.numGoPage = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbePageRecord = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFirstPage = new System.Windows.Forms.ToolStripButton();
            this.tsbLastPage = new System.Windows.Forms.ToolStripButton();
            this.tslCurrentPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.tslTotalPage = new System.Windows.Forms.ToolStripLabel();
            this.tsbNextPage = new System.Windows.Forms.ToolStripButton();
            this.tsbEndPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.panelQuary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beLogContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcData)).BeginInit();
            this.pcData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRunningLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAirQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcBottom)).BeginInit();
            this.pcBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGoPage)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelQuary
            // 
            this.panelQuary.Controls.Add(this.beLogContent);
            this.panelQuary.Controls.Add(this.lcLogContent);
            this.panelQuary.Controls.Add(this.lcQuaryTime);
            this.panelQuary.Controls.Add(this.sbSearch);
            this.panelQuary.Controls.Add(this.dtpEnd);
            this.panelQuary.Controls.Add(this.dtpBegin);
            this.panelQuary.Controls.Add(this.lcTilde);
            this.panelQuary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQuary.Location = new System.Drawing.Point(0, 0);
            this.panelQuary.Name = "panelQuary";
            this.panelQuary.Size = new System.Drawing.Size(1178, 40);
            this.panelQuary.TabIndex = 51;
            // 
            // beLogContent
            // 
            this.beLogContent.Location = new System.Drawing.Point(497, 10);
            this.beLogContent.Name = "beLogContent";
            this.beLogContent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.beLogContent.Properties.Appearance.Options.UseFont = true;
            this.beLogContent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "Clear", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.beLogContent.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beLogContent_Properties_ButtonClick);
            this.beLogContent.Size = new System.Drawing.Size(127, 22);
            this.beLogContent.TabIndex = 52;
            this.beLogContent.EditValueChanged += new System.EventHandler(this.beLogContent_EditValueChanged);
            // 
            // lcLogContent
            // 
            this.lcLogContent.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcLogContent.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(106)))), ((int)(((byte)(170)))));
            this.lcLogContent.Appearance.Options.UseFont = true;
            this.lcLogContent.Appearance.Options.UseForeColor = true;
            this.lcLogContent.Appearance.Options.UseTextOptions = true;
            this.lcLogContent.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcLogContent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcLogContent.Location = new System.Drawing.Point(419, 13);
            this.lcLogContent.Name = "lcLogContent";
            this.lcLogContent.Size = new System.Drawing.Size(74, 17);
            this.lcLogContent.TabIndex = 49;
            this.lcLogContent.Text = "LogContent";
            // 
            // lcQuaryTime
            // 
            this.lcQuaryTime.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcQuaryTime.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(106)))), ((int)(((byte)(170)))));
            this.lcQuaryTime.Appearance.Options.UseFont = true;
            this.lcQuaryTime.Appearance.Options.UseForeColor = true;
            this.lcQuaryTime.Appearance.Options.UseTextOptions = true;
            this.lcQuaryTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcQuaryTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcQuaryTime.Location = new System.Drawing.Point(-1, 13);
            this.lcQuaryTime.Name = "lcQuaryTime";
            this.lcQuaryTime.Size = new System.Drawing.Size(73, 16);
            this.lcQuaryTime.TabIndex = 32;
            this.lcQuaryTime.Text = "QuaryTime";
            // 
            // sbSearch
            // 
            this.sbSearch.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(88)))), ((int)(((byte)(165)))));
            this.sbSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbSearch.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbSearch.Appearance.Options.UseBackColor = true;
            this.sbSearch.Appearance.Options.UseFont = true;
            this.sbSearch.Appearance.Options.UseForeColor = true;
            this.sbSearch.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbSearch.AppearanceDisabled.Options.UseFont = true;
            this.sbSearch.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbSearch.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbSearch.AppearanceHovered.Options.UseBackColor = true;
            this.sbSearch.AppearanceHovered.Options.UseFont = true;
            this.sbSearch.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(177)))), ((int)(((byte)(156)))));
            this.sbSearch.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbSearch.AppearancePressed.Options.UseBackColor = true;
            this.sbSearch.AppearancePressed.Options.UseFont = true;
            this.sbSearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbSearch.Location = new System.Drawing.Point(631, 7);
            this.sbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.sbSearch.Name = "sbSearch";
            this.sbSearch.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbSearch.Size = new System.Drawing.Size(78, 28);
            this.sbSearch.TabIndex = 41;
            this.sbSearch.Text = "Search";
            this.sbSearch.Click += new System.EventHandler(this.sbSearch_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(261, 9);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(158, 24);
            this.dtpEnd.TabIndex = 32;
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBegin.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(75, 9);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(158, 24);
            this.dtpBegin.TabIndex = 31;
            // 
            // lcTilde
            // 
            this.lcTilde.AutoSize = true;
            this.lcTilde.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcTilde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(106)))), ((int)(((byte)(170)))));
            this.lcTilde.Location = new System.Drawing.Point(239, 12);
            this.lcTilde.Name = "lcTilde";
            this.lcTilde.Size = new System.Drawing.Size(18, 17);
            this.lcTilde.TabIndex = 11;
            this.lcTilde.Text = "~";
            // 
            // pcData
            // 
            this.pcData.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pcData.Appearance.Options.UseBackColor = true;
            this.pcData.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcData.Controls.Add(this.gcRunningLog);
            this.pcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcData.Location = new System.Drawing.Point(0, 40);
            this.pcData.Name = "pcData";
            this.pcData.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.pcData.Size = new System.Drawing.Size(1178, 641);
            this.pcData.TabIndex = 53;
            // 
            // gcRunningLog
            // 
            this.gcRunningLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcRunningLog.Location = new System.Drawing.Point(8, 3);
            this.gcRunningLog.MainView = this.gvAirQuality;
            this.gcRunningLog.Name = "gcRunningLog";
            this.gcRunningLog.Size = new System.Drawing.Size(1162, 630);
            this.gcRunningLog.TabIndex = 51;
            this.gcRunningLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAirQuality});
            // 
            // gvAirQuality
            // 
            this.gvAirQuality.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAirQuality.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvAirQuality.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvAirQuality.Appearance.Row.Options.UseFont = true;
            this.gvAirQuality.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvAirQuality.Appearance.SelectedRow.Options.UseFont = true;
            this.gvAirQuality.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcNumber,
            this.gcTheTime,
            this.gcLogContent});
            this.gvAirQuality.DetailHeight = 408;
            this.gvAirQuality.GridControl = this.gcRunningLog;
            this.gvAirQuality.Name = "gvAirQuality";
            this.gvAirQuality.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gvAirQuality.OptionsCustomization.AllowFilter = false;
            this.gvAirQuality.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gvAirQuality.OptionsView.ShowGroupPanel = false;
            // 
            // gcNumber
            // 
            this.gcNumber.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcNumber.AppearanceCell.Options.UseFont = true;
            this.gcNumber.Caption = "Number";
            this.gcNumber.FieldName = "Serial";
            this.gcNumber.MinWidth = 23;
            this.gcNumber.Name = "gcNumber";
            this.gcNumber.OptionsColumn.AllowEdit = false;
            this.gcNumber.OptionsColumn.AllowMove = false;
            this.gcNumber.Visible = true;
            this.gcNumber.VisibleIndex = 0;
            this.gcNumber.Width = 50;
            // 
            // gcTheTime
            // 
            this.gcTheTime.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcTheTime.AppearanceCell.Options.UseFont = true;
            this.gcTheTime.Caption = "Time";
            this.gcTheTime.FieldName = "LogTime";
            this.gcTheTime.MinWidth = 23;
            this.gcTheTime.Name = "gcTheTime";
            this.gcTheTime.OptionsColumn.AllowEdit = false;
            this.gcTheTime.OptionsColumn.AllowMove = false;
            this.gcTheTime.Visible = true;
            this.gcTheTime.VisibleIndex = 1;
            this.gcTheTime.Width = 110;
            // 
            // gcLogContent
            // 
            this.gcLogContent.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcLogContent.AppearanceCell.Options.UseFont = true;
            this.gcLogContent.Caption = "LogContent";
            this.gcLogContent.FieldName = "LogContent";
            this.gcLogContent.MinWidth = 23;
            this.gcLogContent.Name = "gcLogContent";
            this.gcLogContent.OptionsColumn.AllowEdit = false;
            this.gcLogContent.OptionsColumn.AllowMove = false;
            this.gcLogContent.Visible = true;
            this.gcLogContent.VisibleIndex = 2;
            this.gcLogContent.Width = 803;
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            // 
            // pcBottom
            // 
            this.pcBottom.Controls.Add(this.labelControl1);
            this.pcBottom.Controls.Add(this.tsbGotoPage);
            this.pcBottom.Controls.Add(this.numGoPage);
            this.pcBottom.Controls.Add(this.toolStrip1);
            this.pcBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pcBottom.Location = new System.Drawing.Point(0, 681);
            this.pcBottom.Name = "pcBottom";
            this.pcBottom.Size = new System.Drawing.Size(1178, 35);
            this.pcBottom.TabIndex = 54;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(1121, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 14);
            this.labelControl1.TabIndex = 104;
            this.labelControl1.Text = "页";
            // 
            // tsbGotoPage
            // 
            this.tsbGotoPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbGotoPage.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.tsbGotoPage.Appearance.Options.UseBorderColor = true;
            this.tsbGotoPage.AutoSize = true;
            this.tsbGotoPage.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tsbGotoPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tsbGotoPage.Location = new System.Drawing.Point(1136, 8);
            this.tsbGotoPage.Name = "tsbGotoPage";
            this.tsbGotoPage.Size = new System.Drawing.Size(29, 20);
            this.tsbGotoPage.TabIndex = 98;
            this.tsbGotoPage.Text = "跳转";
            this.tsbGotoPage.Click += new System.EventHandler(this.tsbGotoPage_Click_1);
            // 
            // numGoPage
            // 
            this.numGoPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numGoPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGoPage.Location = new System.Drawing.Point(1062, 7);
            this.numGoPage.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numGoPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGoPage.Name = "numGoPage";
            this.numGoPage.Size = new System.Drawing.Size(55, 23);
            this.numGoPage.TabIndex = 97;
            this.numGoPage.Tag = "pageControl7";
            this.numGoPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbePageRecord,
            this.toolStripLabel2,
            this.toolStripSeparator1,
            this.tsbFirstPage,
            this.tsbLastPage,
            this.tslCurrentPage,
            this.toolStripLabel6,
            this.tslTotalPage,
            this.tsbNextPage,
            this.tsbEndPage,
            this.toolStripSeparator2,
            this.toolStripLabel8});
            this.toolStrip1.Location = new System.Drawing.Point(786, 6);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(276, 25);
            this.toolStrip1.TabIndex = 93;
            this.toolStrip1.Text = "toolStrip2";
            // 
            // cbePageRecord
            // 
            this.cbePageRecord.AutoSize = false;
            this.cbePageRecord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbePageRecord.DropDownWidth = 55;
            this.cbePageRecord.MaxDropDownItems = 5;
            this.cbePageRecord.Name = "cbePageRecord";
            this.cbePageRecord.Size = new System.Drawing.Size(55, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel2.Text = "行/页";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbFirstPage
            // 
            this.tsbFirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFirstPage.Image = global::wayeal.plugin.Properties.Resources.首页;
            this.tsbFirstPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirstPage.Name = "tsbFirstPage";
            this.tsbFirstPage.Size = new System.Drawing.Size(23, 22);
            this.tsbFirstPage.Text = "首页";
            this.tsbFirstPage.Click += new System.EventHandler(this.tsbFirstPage_Click);
            // 
            // tsbLastPage
            // 
            this.tsbLastPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLastPage.Image = global::wayeal.plugin.Properties.Resources.上页;
            this.tsbLastPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLastPage.Name = "tsbLastPage";
            this.tsbLastPage.Size = new System.Drawing.Size(23, 22);
            this.tsbLastPage.Text = "上一页";
            this.tsbLastPage.Click += new System.EventHandler(this.tsbLastPage_Click);
            // 
            // tslCurrentPage
            // 
            this.tslCurrentPage.Name = "tslCurrentPage";
            this.tslCurrentPage.Size = new System.Drawing.Size(15, 22);
            this.tslCurrentPage.Text = "0";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel6.Text = "/";
            // 
            // tslTotalPage
            // 
            this.tslTotalPage.Name = "tslTotalPage";
            this.tslTotalPage.Size = new System.Drawing.Size(15, 22);
            this.tslTotalPage.Text = "0";
            // 
            // tsbNextPage
            // 
            this.tsbNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNextPage.Image = global::wayeal.plugin.Properties.Resources.下页;
            this.tsbNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNextPage.Name = "tsbNextPage";
            this.tsbNextPage.Size = new System.Drawing.Size(23, 22);
            this.tsbNextPage.Text = "下一页";
            this.tsbNextPage.Click += new System.EventHandler(this.tsbNextPage_Click);
            // 
            // tsbEndPage
            // 
            this.tsbEndPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEndPage.Image = global::wayeal.plugin.Properties.Resources.末页;
            this.tsbEndPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEndPage.Name = "tsbEndPage";
            this.tsbEndPage.Size = new System.Drawing.Size(23, 22);
            this.tsbEndPage.Text = "末页";
            this.tsbEndPage.Click += new System.EventHandler(this.tsbEndPage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel8.Text = "转至";
            // 
            // ucRunningLog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pcData);
            this.Controls.Add(this.pcBottom);
            this.Controls.Add(this.panelQuary);
            this.Name = "ucRunningLog";
            this.Size = new System.Drawing.Size(1178, 716);
            this.Load += new System.EventHandler(this.ucRunningLog_Load);
            this.panelQuary.ResumeLayout(false);
            this.panelQuary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beLogContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcData)).EndInit();
            this.pcData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRunningLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAirQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcBottom)).EndInit();
            this.pcBottom.ResumeLayout(false);
            this.pcBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGoPage)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelQuary;
        private DevExpress.XtraEditors.LabelControl lcLogContent;
        private DevExpress.XtraEditors.LabelControl lcQuaryTime;
        private DevExpress.XtraEditors.SimpleButton sbSearch;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label lcTilde;
        private DevExpress.XtraEditors.PanelControl pcData;
        private DevExpress.XtraGrid.GridControl gcRunningLog;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAirQuality;
        private DevExpress.XtraGrid.Columns.GridColumn gcNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcTheTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcLogContent;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraEditors.ButtonEdit beLogContent;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.PanelControl pcBottom;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cbePageRecord;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbFirstPage;
        private System.Windows.Forms.ToolStripButton tsbLastPage;
        private System.Windows.Forms.ToolStripLabel tslCurrentPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripLabel tslTotalPage;
        private System.Windows.Forms.ToolStripButton tsbNextPage;
        private System.Windows.Forms.ToolStripButton tsbEndPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private DevExpress.XtraEditors.SimpleButton tsbGotoPage;
        private System.Windows.Forms.NumericUpDown numGoPage;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
