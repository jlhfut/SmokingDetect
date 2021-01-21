﻿namespace wayeal.os.exhaust.UserControls
{
    partial class ucDataMessageGasoline
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lcCOValue = new DevExpress.XtraEditors.LabelControl();
            this.lcCOLimitingper = new DevExpress.XtraEditors.LabelControl();
            this.lcHCValue = new DevExpress.XtraEditors.LabelControl();
            this.lcHCLimitingppm = new DevExpress.XtraEditors.LabelControl();
            this.lcNOValue = new DevExpress.XtraEditors.LabelControl();
            this.lcNOLimitingppm = new DevExpress.XtraEditors.LabelControl();
            this.gcLimitingInfo = new DevExpress.XtraEditors.GroupControl();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLimitingInfo)).BeginInit();
            this.gcLimitingInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCOValue
            // 
            this.lcCOValue.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcCOValue.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lcCOValue.Appearance.Options.UseFont = true;
            this.lcCOValue.Appearance.Options.UseForeColor = true;
            this.lcCOValue.Location = new System.Drawing.Point(128, 114);
            this.lcCOValue.Name = "lcCOValue";
            this.lcCOValue.Size = new System.Drawing.Size(8, 16);
            this.lcCOValue.TabIndex = 12;
            this.lcCOValue.Text = "0";
            // 
            // lcCOLimitingper
            // 
            this.lcCOLimitingper.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcCOLimitingper.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcCOLimitingper.Appearance.Options.UseFont = true;
            this.lcCOLimitingper.Appearance.Options.UseForeColor = true;
            this.lcCOLimitingper.Location = new System.Drawing.Point(24, 114);
            this.lcCOLimitingper.Name = "lcCOLimitingper";
            this.lcCOLimitingper.Size = new System.Drawing.Size(83, 16);
            this.lcCOLimitingper.TabIndex = 11;
            this.lcCOLimitingper.Text = "COLimiting(%)";
            // 
            // lcHCValue
            // 
            this.lcHCValue.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcHCValue.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lcHCValue.Appearance.Options.UseFont = true;
            this.lcHCValue.Appearance.Options.UseForeColor = true;
            this.lcHCValue.Location = new System.Drawing.Point(128, 75);
            this.lcHCValue.Name = "lcHCValue";
            this.lcHCValue.Size = new System.Drawing.Size(8, 16);
            this.lcHCValue.TabIndex = 10;
            this.lcHCValue.Text = "0";
            // 
            // lcHCLimitingppm
            // 
            this.lcHCLimitingppm.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcHCLimitingppm.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcHCLimitingppm.Appearance.Options.UseFont = true;
            this.lcHCLimitingppm.Appearance.Options.UseForeColor = true;
            this.lcHCLimitingppm.Location = new System.Drawing.Point(24, 75);
            this.lcHCLimitingppm.Name = "lcHCLimitingppm";
            this.lcHCLimitingppm.Size = new System.Drawing.Size(95, 16);
            this.lcHCLimitingppm.TabIndex = 9;
            this.lcHCLimitingppm.Text = "HCLimiting(ppm)";
            // 
            // lcNOValue
            // 
            this.lcNOValue.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcNOValue.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lcNOValue.Appearance.Options.UseFont = true;
            this.lcNOValue.Appearance.Options.UseForeColor = true;
            this.lcNOValue.Location = new System.Drawing.Point(128, 36);
            this.lcNOValue.Name = "lcNOValue";
            this.lcNOValue.Size = new System.Drawing.Size(8, 16);
            this.lcNOValue.TabIndex = 8;
            this.lcNOValue.Text = "0";
            // 
            // lcNOLimitingppm
            // 
            this.lcNOLimitingppm.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lcNOLimitingppm.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lcNOLimitingppm.Appearance.Options.UseFont = true;
            this.lcNOLimitingppm.Appearance.Options.UseForeColor = true;
            this.lcNOLimitingppm.Location = new System.Drawing.Point(24, 36);
            this.lcNOLimitingppm.Name = "lcNOLimitingppm";
            this.lcNOLimitingppm.Size = new System.Drawing.Size(96, 16);
            this.lcNOLimitingppm.TabIndex = 7;
            this.lcNOLimitingppm.Text = "NOLimiting(ppm)";
            // 
            // gcLimitingInfo
            // 
            this.gcLimitingInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gcLimitingInfo.Appearance.Options.UseFont = true;
            this.gcLimitingInfo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcLimitingInfo.AppearanceCaption.Options.UseFont = true;
            this.gcLimitingInfo.Controls.Add(this.lcNOValue);
            this.gcLimitingInfo.Controls.Add(this.lcCOValue);
            this.gcLimitingInfo.Controls.Add(this.lcNOLimitingppm);
            this.gcLimitingInfo.Controls.Add(this.lcHCLimitingppm);
            this.gcLimitingInfo.Controls.Add(this.lcCOLimitingper);
            this.gcLimitingInfo.Controls.Add(this.lcHCValue);
            this.gcLimitingInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLimitingInfo.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.gcLimitingInfo.Location = new System.Drawing.Point(0, 0);
            this.gcLimitingInfo.Name = "gcLimitingInfo";
            this.gcLimitingInfo.Size = new System.Drawing.Size(667, 170);
            this.gcLimitingInfo.TabIndex = 13;
            this.gcLimitingInfo.Text = "LimitingInfo";
            // 
            // ucDataMessageGasoline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcLimitingInfo);
            this.Name = "ucDataMessageGasoline";
            this.Size = new System.Drawing.Size(667, 170);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLimitingInfo)).EndInit();
            this.gcLimitingInfo.ResumeLayout(false);
            this.gcLimitingInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lcCOValue;
        private DevExpress.XtraEditors.LabelControl lcCOLimitingper;
        private DevExpress.XtraEditors.LabelControl lcHCValue;
        private DevExpress.XtraEditors.LabelControl lcHCLimitingppm;
        private DevExpress.XtraEditors.LabelControl lcNOValue;
        private DevExpress.XtraEditors.LabelControl lcNOLimitingppm;
        private DevExpress.XtraEditors.GroupControl gcLimitingInfo;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}
