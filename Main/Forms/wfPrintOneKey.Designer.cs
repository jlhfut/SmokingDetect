namespace wayeal.os.exhaust.Forms
{
    partial class wfPrintOneKey
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
            this.lcBack = new DevExpress.XtraEditors.LabelControl();
            this.sbStopPrint = new DevExpress.XtraEditors.SimpleButton();
            this.pbcPrint = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.pbcPrint.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lcBack
            // 
            this.lcBack.Appearance.BackColor = System.Drawing.Color.White;
            this.lcBack.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lcBack.Appearance.ForeColor = System.Drawing.Color.White;
            this.lcBack.Appearance.Options.UseBackColor = true;
            this.lcBack.Appearance.Options.UseFont = true;
            this.lcBack.Appearance.Options.UseForeColor = true;
            this.lcBack.Appearance.Options.UseTextOptions = true;
            this.lcBack.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lcBack.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcBack.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lcBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcBack.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lcBack.Location = new System.Drawing.Point(0, 0);
            this.lcBack.Name = "lcBack";
            this.lcBack.Size = new System.Drawing.Size(320, 87);
            this.lcBack.TabIndex = 2;
            // 
            // sbStopPrint
            // 
            this.sbStopPrint.AllowFocus = false;
            this.sbStopPrint.Appearance.BackColor = System.Drawing.Color.White;
            this.sbStopPrint.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.sbStopPrint.Appearance.Options.UseBackColor = true;
            this.sbStopPrint.Appearance.Options.UseForeColor = true;
            this.sbStopPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.sbStopPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sbStopPrint.Location = new System.Drawing.Point(122, 56);
            this.sbStopPrint.Name = "sbStopPrint";
            this.sbStopPrint.Size = new System.Drawing.Size(79, 20);
            this.sbStopPrint.TabIndex = 3;
            this.sbStopPrint.Text = "Exit";
            this.sbStopPrint.Click += new System.EventHandler(this.sbStopPrint_Click);
            // 
            // pbcPrint
            // 
            this.pbcPrint.Location = new System.Drawing.Point(19, 34);
            this.pbcPrint.Name = "pbcPrint";
            this.pbcPrint.Properties.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.pbcPrint.Properties.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(121)))), ((int)(((byte)(183)))));
            this.pbcPrint.Properties.Step = 1;
            this.pbcPrint.Size = new System.Drawing.Size(283, 18);
            this.pbcPrint.TabIndex = 4;
            // 
            // wfPrintOneKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 87);
            this.ControlBox = false;
            this.Controls.Add(this.pbcPrint);
            this.Controls.Add(this.sbStopPrint);
            this.Controls.Add(this.lcBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wfPrintOneKey";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "wfPrintOneKey";
            ((System.ComponentModel.ISupportInitialize)(this.pbcPrint.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lcBack;
        private DevExpress.XtraEditors.SimpleButton sbStopPrint;
        private DevExpress.XtraEditors.ProgressBarControl pbcPrint;
    }
}