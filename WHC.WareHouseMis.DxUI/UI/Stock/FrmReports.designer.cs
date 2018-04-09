﻿using WHC.Framework.BaseUI.Controls;
namespace WHC.WareHouseMis.UI
{
    partial class FrmReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReports));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStatistic = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAnnualReport = new WHC.Framework.BaseUI.Controls.VistaButton();
            this.btnAllMonthReport = new WHC.Framework.BaseUI.Controls.VistaButton();
            this.btnWareMonthlyReport = new WHC.Framework.BaseUI.Controls.VistaButton();
            this.btnDeptMonthlyReport = new WHC.Framework.BaseUI.Controls.VistaButton();
            this.btnPartMonthlyReport = new WHC.Framework.BaseUI.Controls.VistaButton();
            this.tabControl1.SuspendLayout();
            this.tabStatistic.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStatistic);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(872, 294);
            this.tabControl1.TabIndex = 0;
            // 
            // tabStatistic
            // 
            this.tabStatistic.Controls.Add(this.groupBox1);
            this.tabStatistic.Location = new System.Drawing.Point(4, 23);
            this.tabStatistic.Name = "tabStatistic";
            this.tabStatistic.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatistic.Size = new System.Drawing.Size(864, 267);
            this.tabStatistic.TabIndex = 0;
            this.tabStatistic.Text = "报表管理";
            this.tabStatistic.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnAnnualReport);
            this.groupBox1.Controls.Add(this.btnAllMonthReport);
            this.groupBox1.Controls.Add(this.btnWareMonthlyReport);
            this.groupBox1.Controls.Add(this.btnDeptMonthlyReport);
            this.groupBox1.Controls.Add(this.btnPartMonthlyReport);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 255);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户类报表";
            // 
            // btnAnnualReport
            // 
            this.btnAnnualReport.BackColor = System.Drawing.Color.Transparent;
            this.btnAnnualReport.ButtonColor = System.Drawing.Color.Blue;
            this.btnAnnualReport.ButtonText = "全年费用汇总报表";
            this.btnAnnualReport.Image = ((System.Drawing.Image)(resources.GetObject("btnAnnualReport.Image")));
            this.btnAnnualReport.ImageSize = new System.Drawing.Size(48, 48);
            this.btnAnnualReport.Location = new System.Drawing.Point(295, 41);
            this.btnAnnualReport.Name = "btnAnnualReport";
            this.btnAnnualReport.Size = new System.Drawing.Size(216, 78);
            this.btnAnnualReport.TabIndex = 2;
            this.btnAnnualReport.Click += new System.EventHandler(this.btnAnnualReport_Click);
            // 
            // btnAllMonthReport
            // 
            this.btnAllMonthReport.BackColor = System.Drawing.Color.Transparent;
            this.btnAllMonthReport.ButtonColor = System.Drawing.Color.Blue;
            this.btnAllMonthReport.ButtonText = "库房结存月报表（所有库房）";
            this.btnAllMonthReport.Image = ((System.Drawing.Image)(resources.GetObject("btnAllMonthReport.Image")));
            this.btnAllMonthReport.ImageSize = new System.Drawing.Size(48, 48);
            this.btnAllMonthReport.Location = new System.Drawing.Point(538, 160);
            this.btnAllMonthReport.Name = "btnAllMonthReport";
            this.btnAllMonthReport.Size = new System.Drawing.Size(238, 67);
            this.btnAllMonthReport.TabIndex = 1;
            this.btnAllMonthReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAllMonthReport.Click += new System.EventHandler(this.btnAllMonthReport_Click);
            // 
            // btnWareMonthlyReport
            // 
            this.btnWareMonthlyReport.BackColor = System.Drawing.Color.Transparent;
            this.btnWareMonthlyReport.ButtonColor = System.Drawing.Color.Blue;
            this.btnWareMonthlyReport.ButtonText = "库房结存月报表（单库房）";
            this.btnWareMonthlyReport.Image = ((System.Drawing.Image)(resources.GetObject("btnWareMonthlyReport.Image")));
            this.btnWareMonthlyReport.ImageSize = new System.Drawing.Size(48, 48);
            this.btnWareMonthlyReport.Location = new System.Drawing.Point(295, 160);
            this.btnWareMonthlyReport.Name = "btnWareMonthlyReport";
            this.btnWareMonthlyReport.Size = new System.Drawing.Size(216, 67);
            this.btnWareMonthlyReport.TabIndex = 1;
            this.btnWareMonthlyReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWareMonthlyReport.Click += new System.EventHandler(this.btnWareMonthlyReport_Click);
            // 
            // btnDeptMonthlyReport
            // 
            this.btnDeptMonthlyReport.BackColor = System.Drawing.Color.Transparent;
            this.btnDeptMonthlyReport.ButtonColor = System.Drawing.Color.Blue;
            this.btnDeptMonthlyReport.ButtonText = "部门结存月报表（所有库房）";
            this.btnDeptMonthlyReport.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeptMonthlyReport.Image = ((System.Drawing.Image)(resources.GetObject("btnDeptMonthlyReport.Image")));
            this.btnDeptMonthlyReport.ImageSize = new System.Drawing.Size(48, 48);
            this.btnDeptMonthlyReport.Location = new System.Drawing.Point(23, 160);
            this.btnDeptMonthlyReport.Name = "btnDeptMonthlyReport";
            this.btnDeptMonthlyReport.Size = new System.Drawing.Size(250, 67);
            this.btnDeptMonthlyReport.TabIndex = 1;
            this.btnDeptMonthlyReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeptMonthlyReport.Click += new System.EventHandler(this.btnDeptMonthlyReport_Click);
            // 
            // btnPartMonthlyReport
            // 
            this.btnPartMonthlyReport.BackColor = System.Drawing.Color.Transparent;
            this.btnPartMonthlyReport.ButtonColor = System.Drawing.Color.Blue;
            this.btnPartMonthlyReport.ButtonText = "各车间月报表";
            this.btnPartMonthlyReport.Image = ((System.Drawing.Image)(resources.GetObject("btnPartMonthlyReport.Image")));
            this.btnPartMonthlyReport.ImageSize = new System.Drawing.Size(48, 48);
            this.btnPartMonthlyReport.Location = new System.Drawing.Point(23, 41);
            this.btnPartMonthlyReport.Name = "btnPartMonthlyReport";
            this.btnPartMonthlyReport.Size = new System.Drawing.Size(210, 67);
            this.btnPartMonthlyReport.TabIndex = 0;
            this.btnPartMonthlyReport.Click += new System.EventHandler(this.btnPartMonthlyReport_Click);
            // 
            // FrmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 294);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReports";
            this.Text = "报表管理";
            this.tabControl1.ResumeLayout(false);
            this.tabStatistic.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStatistic;
        private System.Windows.Forms.GroupBox groupBox1;
        private VistaButton btnPartMonthlyReport;
        private VistaButton btnAnnualReport;
        private VistaButton btnDeptMonthlyReport;
        private VistaButton btnWareMonthlyReport;
        private VistaButton btnAllMonthReport;
    }
}