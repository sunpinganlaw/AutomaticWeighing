namespace WHC.WareHouseMis.UI.Settings
{
    partial class PageGlobal
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkAllowEnterCardNo = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowEnterCardNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.chkAllowEnterCardNo);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(580, 347);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "系统设置";
            // 
            // chkAllowEnterCardNo
            // 
            this.chkAllowEnterCardNo.EditValue = true;
            this.chkAllowEnterCardNo.Location = new System.Drawing.Point(28, 38);
            this.chkAllowEnterCardNo.Name = "chkAllowEnterCardNo";
            this.chkAllowEnterCardNo.Properties.Caption = "操作会员数据允许手工输入卡号";
            this.chkAllowEnterCardNo.Size = new System.Drawing.Size(351, 19);
            this.chkAllowEnterCardNo.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl1.Location = new System.Drawing.Point(51, 63);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(288, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "如果不勾选，那么操作卡号只能通过刷卡方式读取卡号";
            // 
            // PageSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "PageSystem";
            this.Size = new System.Drawing.Size(580, 347);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowEnterCardNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit chkAllowEnterCardNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
