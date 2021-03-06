﻿namespace wayeal.os.exhaust.Forms
{
    partial class wfNonlinearCorrection
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wfNonlinearCorrection));
            this.lcGasName = new DevExpress.XtraEditors.LabelControl();
            this.cbeGasName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lcCorrection = new DevExpress.XtraEditors.LabelControl();
            this.ceCorrection = new DevExpress.XtraEditors.CheckEdit();
            this.gcCorrectionData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcPreConcentration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPostConcentration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcConcOperation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribe = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.sbNew = new DevExpress.XtraEditors.SimpleButton();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext();
            this.sbSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbeGasName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceCorrection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCorrectionData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcGasName
            // 
            this.lcGasName.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcGasName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcGasName.Appearance.Options.UseFont = true;
            this.lcGasName.Appearance.Options.UseForeColor = true;
            this.lcGasName.Appearance.Options.UseTextOptions = true;
            this.lcGasName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcGasName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcGasName.Location = new System.Drawing.Point(15, 15);
            this.lcGasName.Name = "lcGasName";
            this.lcGasName.Size = new System.Drawing.Size(78, 16);
            this.lcGasName.TabIndex = 7;
            this.lcGasName.Text = "Gas Name";
            // 
            // cbeGasName
            // 
            this.cbeGasName.EditValue = "";
            this.cbeGasName.Location = new System.Drawing.Point(99, 12);
            this.cbeGasName.Name = "cbeGasName";
            this.cbeGasName.Properties.AllowFocused = false;
            this.cbeGasName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbeGasName.Properties.Appearance.Options.UseFont = true;
            this.cbeGasName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeGasName.Properties.Items.AddRange(new object[] {
            "NO",
            "HC"});
            this.cbeGasName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbeGasName.Size = new System.Drawing.Size(119, 22);
            this.cbeGasName.TabIndex = 8;
            this.cbeGasName.SelectedIndexChanged += new System.EventHandler(this.cbeGasName_SelectedIndexChanged);
            // 
            // lcCorrection
            // 
            this.lcCorrection.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcCorrection.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcCorrection.Appearance.Options.UseFont = true;
            this.lcCorrection.Appearance.Options.UseForeColor = true;
            this.lcCorrection.Appearance.Options.UseTextOptions = true;
            this.lcCorrection.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcCorrection.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcCorrection.Location = new System.Drawing.Point(224, 15);
            this.lcCorrection.Name = "lcCorrection";
            this.lcCorrection.Size = new System.Drawing.Size(97, 16);
            this.lcCorrection.TabIndex = 10;
            this.lcCorrection.Text = "Correction";
            // 
            // ceCorrection
            // 
            this.ceCorrection.Location = new System.Drawing.Point(327, 13);
            this.ceCorrection.Name = "ceCorrection";
            this.ceCorrection.Properties.AllowFocused = false;
            this.ceCorrection.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ceCorrection.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(106)))), ((int)(((byte)(170)))));
            this.ceCorrection.Properties.Appearance.Options.UseFont = true;
            this.ceCorrection.Properties.Appearance.Options.UseForeColor = true;
            this.ceCorrection.Properties.Caption = "Air Pump";
            this.ceCorrection.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.ceCorrection.Properties.ImageOptions.ImageChecked = global::wayeal.os.exhaust.Properties.Resources.开启;
            this.ceCorrection.Properties.ImageOptions.ImageUnchecked = global::wayeal.os.exhaust.Properties.Resources.关闭;
            this.ceCorrection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ceCorrection.Size = new System.Drawing.Size(42, 22);
            this.ceCorrection.TabIndex = 9;
            this.ceCorrection.EditValueChanged += new System.EventHandler(this.ceCorrection_EditValueChanged);
            // 
            // gcCorrectionData
            // 
            this.gcCorrectionData.Location = new System.Drawing.Point(12, 50);
            this.gcCorrectionData.MainView = this.gridView1;
            this.gcCorrectionData.Name = "gcCorrectionData";
            this.gcCorrectionData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ribe});
            this.gcCorrectionData.Size = new System.Drawing.Size(483, 257);
            this.gcCorrectionData.TabIndex = 33;
            this.gcCorrectionData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcPreConcentration,
            this.gcPostConcentration,
            this.gcConcOperation});
            this.gridView1.GridControl = this.gcCorrectionData;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gcPreConcentration
            // 
            this.gcPreConcentration.Caption = "Pre Concentration";
            this.gcPreConcentration.DisplayFormat.FormatString = "f2";
            this.gcPreConcentration.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPreConcentration.FieldName = "PreConcentration";
            this.gcPreConcentration.Name = "gcPreConcentration";
            this.gcPreConcentration.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gcPreConcentration.Visible = true;
            this.gcPreConcentration.VisibleIndex = 0;
            this.gcPreConcentration.Width = 201;
            // 
            // gcPostConcentration
            // 
            this.gcPostConcentration.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcPostConcentration.AppearanceCell.Options.UseFont = true;
            this.gcPostConcentration.Caption = "Post Concentration";
            this.gcPostConcentration.DisplayFormat.FormatString = "f2";
            this.gcPostConcentration.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPostConcentration.FieldName = "PostConcentration";
            this.gcPostConcentration.Name = "gcPostConcentration";
            this.gcPostConcentration.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gcPostConcentration.Visible = true;
            this.gcPostConcentration.VisibleIndex = 1;
            this.gcPostConcentration.Width = 201;
            // 
            // gcConcOperation
            // 
            this.gcConcOperation.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcConcOperation.AppearanceCell.Options.UseFont = true;
            this.gcConcOperation.Caption = "Option";
            this.gcConcOperation.ColumnEdit = this.ribe;
            this.gcConcOperation.Name = "gcConcOperation";
            this.gcConcOperation.Visible = true;
            this.gcConcOperation.VisibleIndex = 2;
            this.gcConcOperation.Width = 70;
            // 
            // ribe
            // 
            this.ribe.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ribe.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.ribe.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.ribe.Appearance.Options.UseBackColor = true;
            this.ribe.Appearance.Options.UseBorderColor = true;
            this.ribe.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.ribe.AppearanceDisabled.Options.UseBorderColor = true;
            this.ribe.AppearanceFocused.BorderColor = System.Drawing.Color.Transparent;
            this.ribe.AppearanceFocused.Options.UseBorderColor = true;
            this.ribe.AppearanceReadOnly.BorderColor = System.Drawing.Color.Transparent;
            this.ribe.AppearanceReadOnly.Options.UseBorderColor = true;
            this.ribe.AutoHeight = false;
            this.ribe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Transparent;
            serializableAppearanceObject1.BackColor2 = System.Drawing.Color.Transparent;
            serializableAppearanceObject1.BorderColor = System.Drawing.Color.Transparent;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Underline);
            serializableAppearanceObject1.ForeColor = System.Drawing.SystemColors.Highlight;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject1.Options.UseBorderColor = true;
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject1.Options.UseForeColor = true;
            serializableAppearanceObject2.BorderColor = System.Drawing.Color.Transparent;
            serializableAppearanceObject2.Options.UseBorderColor = true;
            serializableAppearanceObject3.BorderColor = System.Drawing.Color.Transparent;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Underline);
            serializableAppearanceObject3.ForeColor = System.Drawing.Color.Navy;
            serializableAppearanceObject3.Options.UseBorderColor = true;
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject3.Options.UseForeColor = true;
            serializableAppearanceObject4.BorderColor = System.Drawing.Color.Transparent;
            serializableAppearanceObject4.Options.UseBorderColor = true;
            this.ribe.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Delete", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.ribe.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.ribe.Name = "ribe";
            this.ribe.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.ribe.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ribe_ButtonClick);
            // 
            // sbNew
            // 
            this.sbNew.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.sbNew.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbNew.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbNew.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("sbNew.Appearance.Image")));
            this.sbNew.Appearance.Options.UseBackColor = true;
            this.sbNew.Appearance.Options.UseFont = true;
            this.sbNew.Appearance.Options.UseForeColor = true;
            this.sbNew.Appearance.Options.UseImage = true;
            this.sbNew.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbNew.AppearanceHovered.Options.UseBackColor = true;
            this.sbNew.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbNew.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbNew.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbNew.AppearancePressed.Image")));
            this.sbNew.AppearancePressed.Options.UseBackColor = true;
            this.sbNew.AppearancePressed.Options.UseFont = true;
            this.sbNew.AppearancePressed.Options.UseImage = true;
            this.sbNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbNew.Location = new System.Drawing.Point(303, 316);
            this.sbNew.Name = "sbNew";
            this.sbNew.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbNew.Size = new System.Drawing.Size(93, 28);
            this.sbNew.TabIndex = 77;
            this.sbNew.Text = "New";
            this.sbNew.Click += new System.EventHandler(this.sbNew_Click);
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
            this.sbSave.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("sbSave.Appearance.Image")));
            this.sbSave.Appearance.Options.UseBackColor = true;
            this.sbSave.Appearance.Options.UseFont = true;
            this.sbSave.Appearance.Options.UseForeColor = true;
            this.sbSave.Appearance.Options.UseImage = true;
            this.sbSave.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbSave.AppearanceHovered.Options.UseBackColor = true;
            this.sbSave.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.sbSave.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbSave.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbSave.AppearancePressed.Image")));
            this.sbSave.AppearancePressed.Options.UseBackColor = true;
            this.sbSave.AppearancePressed.Options.UseFont = true;
            this.sbSave.AppearancePressed.Options.UseImage = true;
            this.sbSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbSave.Location = new System.Drawing.Point(402, 316);
            this.sbSave.Name = "sbSave";
            this.sbSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.sbSave.Size = new System.Drawing.Size(93, 28);
            this.sbSave.TabIndex = 78;
            this.sbSave.Text = "Save";
            this.sbSave.Click += new System.EventHandler(this.sbSave_Click);
            // 
            // wfNonlinearCorrection
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 356);
            this.Controls.Add(this.sbSave);
            this.Controls.Add(this.sbNew);
            this.Controls.Add(this.gcCorrectionData);
            this.Controls.Add(this.lcCorrection);
            this.Controls.Add(this.ceCorrection);
            this.Controls.Add(this.cbeGasName);
            this.Controls.Add(this.lcGasName);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wfNonlinearCorrection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nonlinear Correction";
            ((System.ComponentModel.ISupportInitialize)(this.cbeGasName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceCorrection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCorrectionData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lcGasName;
        private DevExpress.XtraEditors.ComboBoxEdit cbeGasName;
        private DevExpress.XtraEditors.LabelControl lcCorrection;
        private DevExpress.XtraEditors.CheckEdit ceCorrection;
        private DevExpress.XtraGrid.GridControl gcCorrectionData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcPreConcentration;
        private DevExpress.XtraGrid.Columns.GridColumn gcPostConcentration;
        private DevExpress.XtraGrid.Columns.GridColumn gcConcOperation;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ribe;
        private DevExpress.XtraEditors.SimpleButton sbNew;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraEditors.SimpleButton sbSave;
    }
}