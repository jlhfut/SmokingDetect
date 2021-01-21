namespace wayeal.os.exhaust.Modules
{
    partial class ucBackgroundLog
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBackgroundLog));
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.panelQuary = new System.Windows.Forms.Panel();
            this.cbcategory = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtLogContent = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lcQuaryTime = new DevExpress.XtraEditors.LabelControl();
            this.sbQuary = new DevExpress.XtraEditors.SimpleButton();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.lcTilde = new System.Windows.Forms.Label();
            this.gcBackgroundLogList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLogNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLogDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLogCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLogContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtpage = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.lblResultTotal = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.lblIndex = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cbeSelectpage = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.panelQuary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbcategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBackgroundLogList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeSelectpage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelQuary
            // 
            this.panelQuary.BackColor = System.Drawing.Color.White;
            this.panelQuary.Controls.Add(this.cbcategory);
            this.panelQuary.Controls.Add(this.txtLogContent);
            this.panelQuary.Controls.Add(this.labelControl2);
            this.panelQuary.Controls.Add(this.labelControl1);
            this.panelQuary.Controls.Add(this.lcQuaryTime);
            this.panelQuary.Controls.Add(this.sbQuary);
            this.panelQuary.Controls.Add(this.dtpEnd);
            this.panelQuary.Controls.Add(this.dtpBegin);
            this.panelQuary.Controls.Add(this.lcTilde);
            this.panelQuary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQuary.Location = new System.Drawing.Point(30, 15);
            this.panelQuary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelQuary.Name = "panelQuary";
            this.panelQuary.Size = new System.Drawing.Size(1342, 50);
            this.panelQuary.TabIndex = 51;
            // 
            // cbcategory
            // 
            this.cbcategory.EditValue = "所有";
            this.cbcategory.Location = new System.Drawing.Point(670, 13);
            this.cbcategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbcategory.Name = "cbcategory";
            this.cbcategory.Properties.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.cbcategory.Properties.Appearance.Options.UseFont = true;
            this.cbcategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbcategory.Properties.Items.AddRange(new object[] {
            "所有",
            "调试",
            "警告",
            "错误",
            "致命错误"});
            this.cbcategory.Size = new System.Drawing.Size(100, 26);
            this.cbcategory.TabIndex = 46;
            // 
            // txtLogContent
            // 
            this.txtLogContent.Location = new System.Drawing.Point(919, 15);
            this.txtLogContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLogContent.Name = "txtLogContent";
            this.txtLogContent.Properties.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.txtLogContent.Properties.Appearance.Options.UseFont = true;
            this.txtLogContent.Size = new System.Drawing.Size(125, 26);
            this.txtLogContent.TabIndex = 45;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(799, 16);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 19);
            this.labelControl2.TabIndex = 44;
            this.labelControl2.Text = "日志内容";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(556, 19);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 19);
            this.labelControl1.TabIndex = 42;
            this.labelControl1.Text = "日志类别";
            // 
            // lcQuaryTime
            // 
            this.lcQuaryTime.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.lcQuaryTime.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcQuaryTime.Appearance.Options.UseFont = true;
            this.lcQuaryTime.Appearance.Options.UseForeColor = true;
            this.lcQuaryTime.Appearance.Options.UseTextOptions = true;
            this.lcQuaryTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcQuaryTime.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcQuaryTime.Location = new System.Drawing.Point(17, 16);
            this.lcQuaryTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lcQuaryTime.Name = "lcQuaryTime";
            this.lcQuaryTime.Size = new System.Drawing.Size(73, 19);
            this.lcQuaryTime.TabIndex = 32;
            this.lcQuaryTime.Text = "查询时间";
            // 
            // sbQuary
            // 
            this.sbQuary.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbQuary.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbQuary.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbQuary.Appearance.Options.UseBackColor = true;
            this.sbQuary.Appearance.Options.UseFont = true;
            this.sbQuary.Appearance.Options.UseForeColor = true;
            this.sbQuary.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbQuary.AppearanceHovered.Options.UseBackColor = true;
            this.sbQuary.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbQuary.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbQuary.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbQuary.AppearancePressed.Image")));
            this.sbQuary.AppearancePressed.Options.UseBackColor = true;
            this.sbQuary.AppearancePressed.Options.UseFont = true;
            this.sbQuary.AppearancePressed.Options.UseImage = true;
            this.sbQuary.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sbQuary.BackgroundImage")));
            this.sbQuary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.sbQuary.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbQuary.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbQuary.Location = new System.Drawing.Point(1264, 0);
            this.sbQuary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sbQuary.Name = "sbQuary";
            this.sbQuary.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbQuary.Size = new System.Drawing.Size(78, 50);
            this.sbQuary.TabIndex = 41;
            this.sbQuary.Text = "查询";
            this.sbQuary.Click += new System.EventHandler(this.sbQuary_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFont = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(350, 18);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(158, 24);
            this.dtpEnd.TabIndex = 32;
            // 
            // dtpBegin
            // 
            this.dtpBegin.CalendarFont = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.dtpBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBegin.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(145, 19);
            this.dtpBegin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(158, 24);
            this.dtpBegin.TabIndex = 31;
            // 
            // lcTilde
            // 
            this.lcTilde.AutoSize = true;
            this.lcTilde.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcTilde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(106)))), ((int)(((byte)(170)))));
            this.lcTilde.Location = new System.Drawing.Point(309, 18);
            this.lcTilde.Name = "lcTilde";
            this.lcTilde.Size = new System.Drawing.Size(18, 17);
            this.lcTilde.TabIndex = 11;
            this.lcTilde.Text = "~";
            // 
            // gcBackgroundLogList
            // 
            this.gcBackgroundLogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBackgroundLogList.EmbeddedNavigator.Appearance.BorderColor = System.Drawing.Color.White;
            this.gcBackgroundLogList.EmbeddedNavigator.Appearance.Options.UseBorderColor = true;
            this.gcBackgroundLogList.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcBackgroundLogList.Location = new System.Drawing.Point(30, 65);
            this.gcBackgroundLogList.MainView = this.gridView1;
            this.gcBackgroundLogList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcBackgroundLogList.Name = "gcBackgroundLogList";
            this.gcBackgroundLogList.Size = new System.Drawing.Size(1342, 716);
            this.gcBackgroundLogList.TabIndex = 52;
            this.gcBackgroundLogList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.ColumnPanelRowHeight = 49;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLogNo,
            this.gcLogDate,
            this.gcLogCategory,
            this.gcLogContent});
            this.gridView1.DetailHeight = 425;
            this.gridView1.GridControl = this.gcBackgroundLogList;
            this.gridView1.GroupRowHeight = 49;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.PaintStyleName = "Web";
            // 
            // gcLogNo
            // 
            this.gcLogNo.AppearanceCell.Options.UseFont = true;
            this.gcLogNo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.gcLogNo.AppearanceHeader.Options.UseFont = true;
            this.gcLogNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gcLogNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcLogNo.Caption = "序号";
            this.gcLogNo.FieldName = "Id";
            this.gcLogNo.MinWidth = 40;
            this.gcLogNo.Name = "gcLogNo";
            this.gcLogNo.Visible = true;
            this.gcLogNo.VisibleIndex = 0;
            this.gcLogNo.Width = 392;
            // 
            // gcLogDate
            // 
            this.gcLogDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.gcLogDate.AppearanceHeader.Options.UseFont = true;
            this.gcLogDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gcLogDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcLogDate.Caption = "时间";
            this.gcLogDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcLogDate.FieldName = "Date";
            this.gcLogDate.Name = "gcLogDate";
            this.gcLogDate.Visible = true;
            this.gcLogDate.VisibleIndex = 1;
            this.gcLogDate.Width = 321;
            // 
            // gcLogCategory
            // 
            this.gcLogCategory.AppearanceCell.Options.UseTextOptions = true;
            this.gcLogCategory.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcLogCategory.AppearanceHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.gcLogCategory.AppearanceHeader.Options.UseFont = true;
            this.gcLogCategory.Caption = "类别";
            this.gcLogCategory.FieldName = "Level";
            this.gcLogCategory.Name = "gcLogCategory";
            this.gcLogCategory.Visible = true;
            this.gcLogCategory.VisibleIndex = 2;
            this.gcLogCategory.Width = 321;
            // 
            // gcLogContent
            // 
            this.gcLogContent.AppearanceCell.Options.UseTextOptions = true;
            this.gcLogContent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcLogContent.AppearanceHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.gcLogContent.AppearanceHeader.Options.UseFont = true;
            this.gcLogContent.Caption = "日志内容";
            this.gcLogContent.FieldName = "Message";
            this.gcLogContent.Name = "gcLogContent";
            this.gcLogContent.Visible = true;
            this.gcLogContent.VisibleIndex = 3;
            this.gcLogContent.Width = 326;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.button5);
            this.panelControl2.Controls.Add(this.button4);
            this.panelControl2.Controls.Add(this.button3);
            this.panelControl2.Controls.Add(this.button2);
            this.panelControl2.Controls.Add(this.button1);
            this.panelControl2.Controls.Add(this.labelControl12);
            this.panelControl2.Controls.Add(this.txtpage);
            this.panelControl2.Controls.Add(this.labelControl11);
            this.panelControl2.Controls.Add(this.lblResultTotal);
            this.panelControl2.Controls.Add(this.labelControl9);
            this.panelControl2.Controls.Add(this.lblIndex);
            this.panelControl2.Controls.Add(this.labelControl7);
            this.panelControl2.Controls.Add(this.cbeSelectpage);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Controls.Add(this.lblTotal);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(30, 721);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1342, 60);
            this.panelControl2.TabIndex = 55;
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(590, 14);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(39, 26);
            this.button5.TabIndex = 15;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(728, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 27);
            this.button4.TabIndex = 14;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(764, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 23);
            this.button3.TabIndex = 13;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(635, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 26);
            this.button2.TabIndex = 12;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(1262, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 11;
            this.button1.Text = "跳转";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(1066, 19);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(16, 21);
            this.labelControl12.TabIndex = 10;
            this.labelControl12.Text = "页";
            // 
            // txtpage
            // 
            this.txtpage.Location = new System.Drawing.Point(944, 17);
            this.txtpage.Name = "txtpage";
            this.txtpage.Size = new System.Drawing.Size(100, 24);
            this.txtpage.TabIndex = 9;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(862, 15);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(32, 21);
            this.labelControl11.TabIndex = 8;
            this.labelControl11.Text = "转至";
            // 
            // lblResultTotal
            // 
            this.lblResultTotal.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.lblResultTotal.Appearance.Options.UseFont = true;
            this.lblResultTotal.Location = new System.Drawing.Point(713, 15);
            this.lblResultTotal.Name = "lblResultTotal";
            this.lblResultTotal.Size = new System.Drawing.Size(9, 21);
            this.lblResultTotal.TabIndex = 7;
            this.lblResultTotal.Text = "2";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.LineVisible = true;
            this.labelControl9.Location = new System.Drawing.Point(699, 14);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(8, 21);
            this.labelControl9.TabIndex = 6;
            this.labelControl9.Text = "/";
            // 
            // lblIndex
            // 
            this.lblIndex.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.lblIndex.Appearance.Options.UseFont = true;
            this.lblIndex.Location = new System.Drawing.Point(670, 14);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(9, 21);
            this.lblIndex.TabIndex = 5;
            this.lblIndex.Text = "1";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(498, 16);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(39, 21);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "行/页";
            // 
            // cbeSelectpage
            // 
            this.cbeSelectpage.EditValue = "5";
            this.cbeSelectpage.Location = new System.Drawing.Point(392, 17);
            this.cbeSelectpage.Name = "cbeSelectpage";
            this.cbeSelectpage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeSelectpage.Properties.Items.AddRange(new object[] {
            "5",
            "10"});
            this.cbeSelectpage.Size = new System.Drawing.Size(100, 24);
            this.cbeSelectpage.TabIndex = 3;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(327, 20);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(16, 21);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "条";
            // 
            // lblTotal
            // 
            this.lblTotal.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.lblTotal.Appearance.Options.UseFont = true;
            this.lblTotal.Location = new System.Drawing.Point(312, 19);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(9, 21);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "1";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(290, 19);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(16, 21);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "共";
            // 
            // ucBackgroundLog
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.gcBackgroundLogList);
            this.Controls.Add(this.panelQuary);
            this.Name = "ucBackgroundLog";
            this.Padding = new System.Windows.Forms.Padding(30, 15, 0, 0);
            this.Size = new System.Drawing.Size(1372, 781);
            this.Load += new System.EventHandler(this.ucBackgroundLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.panelQuary.ResumeLayout(false);
            this.panelQuary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbcategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBackgroundLogList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeSelectpage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.Panel panelQuary;
        private DevExpress.XtraEditors.ComboBoxEdit cbcategory;
        private DevExpress.XtraEditors.TextEdit txtLogContent;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lcQuaryTime;
        private DevExpress.XtraEditors.SimpleButton sbQuary;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label lcTilde;
        private DevExpress.XtraGrid.GridControl gcBackgroundLogList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcLogNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcLogDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcLogCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gcLogContent;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtpage;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl lblResultTotal;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl lblIndex;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ComboBoxEdit cbeSelectpage;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
