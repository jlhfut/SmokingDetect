namespace wayeal.os.exhaust.From
{
    partial class add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ll = new DevExpress.XtraEditors.LabelControl();
            this.cbPermi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ceischeck = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.sbadd = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtuname = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPermi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceischeck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtuname.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(95, 89);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 21);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "用户名：";
            // 
            // ll
            // 
            this.ll.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll.Appearance.Options.UseFont = true;
            this.ll.Location = new System.Drawing.Point(78, 130);
            this.ll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ll.Name = "ll";
            this.ll.Size = new System.Drawing.Size(68, 21);
            this.ll.TabIndex = 2;
            this.ll.Text = "权限级别:";
            // 
            // cbPermi
            // 
            this.cbPermi.Location = new System.Drawing.Point(169, 128);
            this.cbPermi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbPermi.Name = "cbPermi";
            this.cbPermi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPermi.Properties.Items.AddRange(new object[] {
            "操作员",
            "管理员",
            "游客"});
            this.cbPermi.Size = new System.Drawing.Size(143, 24);
            this.cbPermi.TabIndex = 3;
            // 
            // ceischeck
            // 
            this.ceischeck.Location = new System.Drawing.Point(169, 175);
            this.ceischeck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ceischeck.Name = "ceischeck";
            this.ceischeck.Properties.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceischeck.Properties.Appearance.Options.UseFont = true;
            this.ceischeck.Properties.Caption = "启用账户";
            this.ceischeck.Size = new System.Drawing.Size(92, 25);
            this.ceischeck.TabIndex = 4;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.AppearancePressed.Image")));
            this.simpleButton1.AppearancePressed.Options.UseImage = true;
            this.simpleButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simpleButton1.BackgroundImage")));
            this.simpleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.simpleButton1.Location = new System.Drawing.Point(141, 226);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(63, 28);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "取消";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // sbadd
            // 
            this.sbadd.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.sbadd.Appearance.ForeColor = System.Drawing.Color.White;
            this.sbadd.Appearance.Options.UseFont = true;
            this.sbadd.Appearance.Options.UseForeColor = true;
            this.sbadd.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("sbadd.AppearancePressed.Image")));
            this.sbadd.AppearancePressed.Options.UseImage = true;
            this.sbadd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sbadd.BackgroundImage")));
            this.sbadd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sbadd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbadd.Location = new System.Drawing.Point(225, 226);
            this.sbadd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sbadd.Name = "sbadd";
            this.sbadd.Size = new System.Drawing.Size(87, 28);
            this.sbadd.TabIndex = 6;
            this.sbadd.Text = "确认";
            this.sbadd.Click += new System.EventHandler(this.sbadd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // txtuname
            // 
            this.txtuname.Location = new System.Drawing.Point(169, 87);
            this.txtuname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtuname.Name = "txtuname";
            this.txtuname.Size = new System.Drawing.Size(143, 24);
            this.txtuname.TabIndex = 9;
            // 
            // add
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 369);
            this.Controls.Add(this.txtuname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sbadd);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.ceischeck);
            this.Controls.Add(this.cbPermi);
            this.Controls.Add(this.ll);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "add";
            this.Text = "新建用户";
            ((System.ComponentModel.ISupportInitialize)(this.cbPermi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceischeck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtuname.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl ll;
        private DevExpress.XtraEditors.ComboBoxEdit cbPermi;
        private DevExpress.XtraEditors.CheckEdit ceischeck;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton sbadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtuname;
    }
}