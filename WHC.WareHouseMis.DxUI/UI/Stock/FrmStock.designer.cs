namespace WHC.WareHouseMis.UI
{
    partial class FrmStock
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdateAll = new System.Windows.Forms.Button();
            this.btnTakeOut = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.cmbShopName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.winGridTakeOut = new WHC.Pager.WinControl.WinGridViewPager();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.winGridStorage = new WHC.Pager.WinControl.WinGridViewPager();
            this.menuStock = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_StockAlert = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Stock_Modify = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_UpdateStock = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.winGridView1 = new WHC.Pager.WinControl.WinGridView();
            this.ctxMenuLeftStock = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStock.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnUpdateAll);
            this.groupBox1.Controls.Add(this.btnTakeOut);
            this.groupBox1.Controls.Add(this.btnAddNew);
            this.groupBox1.Controls.Add(this.cmbShopName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 44);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // btnUpdateAll
            // 
            this.btnUpdateAll.Location = new System.Drawing.Point(446, 11);
            this.btnUpdateAll.Name = "btnUpdateAll";
            this.btnUpdateAll.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateAll.TabIndex = 10;
            this.btnUpdateAll.Text = "全部更新";
            this.btnUpdateAll.UseVisualStyleBackColor = true;
            this.btnUpdateAll.Click += new System.EventHandler(this.btnUpdateAll_Click);
            // 
            // btnTakeOut
            // 
            this.btnTakeOut.Location = new System.Drawing.Point(355, 12);
            this.btnTakeOut.Name = "btnTakeOut";
            this.btnTakeOut.Size = new System.Drawing.Size(85, 23);
            this.btnTakeOut.TabIndex = 9;
            this.btnTakeOut.Text = "库存调拨";
            this.btnTakeOut.UseVisualStyleBackColor = true;
            this.btnTakeOut.Click += new System.EventHandler(this.btnTakeOut_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(274, 12);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 8;
            this.btnAddNew.Text = "入库";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // cmbShopName
            // 
            this.cmbShopName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShopName.FormattingEnabled = true;
            this.cmbShopName.Location = new System.Drawing.Point(70, 14);
            this.cmbShopName.Name = "cmbShopName";
            this.cmbShopName.Size = new System.Drawing.Size(158, 20);
            this.cmbShopName.TabIndex = 2;
            this.cmbShopName.SelectedIndexChanged += new System.EventHandler(this.cmbShopName_SelectedIndexChanged);
            this.cmbShopName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "分店名称";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 635);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(795, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // winGridTakeOut
            // 
            this.winGridTakeOut.AppendedMenu = null;
            this.winGridTakeOut.DataSource = null;
            this.winGridTakeOut.DisplayColumns = "";
            this.winGridTakeOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winGridTakeOut.Location = new System.Drawing.Point(3, 17);
            this.winGridTakeOut.MinimumSize = new System.Drawing.Size(540, 0);
            this.winGridTakeOut.Name = "winGridTakeOut";
            this.winGridTakeOut.PrintTitle = "";
            this.winGridTakeOut.Size = new System.Drawing.Size(765, 188);
            this.winGridTakeOut.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.winGridTakeOut);
            this.groupBox2.Location = new System.Drawing.Point(12, 424);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(771, 208);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存调拨记录";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.winGridStorage);
            this.groupBox3.Location = new System.Drawing.Point(12, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(771, 242);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "库存入库记录";
            // 
            // winGridStorage
            // 
            this.winGridStorage.AppendedMenu = null;
            this.winGridStorage.DataSource = null;
            this.winGridStorage.DisplayColumns = "";
            this.winGridStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winGridStorage.Location = new System.Drawing.Point(3, 17);
            this.winGridStorage.MinimumSize = new System.Drawing.Size(540, 0);
            this.winGridStorage.Name = "winGridStorage";
            this.winGridStorage.PrintTitle = "";
            this.winGridStorage.Size = new System.Drawing.Size(765, 222);
            this.winGridStorage.TabIndex = 9;
            // 
            // menuStock
            // 
            this.menuStock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_StockAlert,
            this.menu_Stock_Modify,
            this.toolStripSeparator1,
            this.menu_UpdateStock});
            this.menuStock.Name = "menuStock";
            this.menuStock.Size = new System.Drawing.Size(185, 76);
            // 
            // menu_StockAlert
            // 
            this.menu_StockAlert.Name = "menu_StockAlert";
            this.menu_StockAlert.Size = new System.Drawing.Size(184, 22);
            this.menu_StockAlert.Text = "设置库存警告数量(&Q)";
            this.menu_StockAlert.Click += new System.EventHandler(this.menu_StockAlert_Click);
            // 
            // menu_Stock_Modify
            // 
            this.menu_Stock_Modify.Name = "menu_Stock_Modify";
            this.menu_Stock_Modify.Size = new System.Drawing.Size(184, 22);
            this.menu_Stock_Modify.Text = "库存平仓(&S)";
            this.menu_Stock_Modify.Click += new System.EventHandler(this.menu_Stock_Modify_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // menu_UpdateStock
            // 
            this.menu_UpdateStock.Name = "menu_UpdateStock";
            this.menu_UpdateStock.Size = new System.Drawing.Size(184, 22);
            this.menu_UpdateStock.Text = "更新数据(&U)";
            this.menu_UpdateStock.Click += new System.EventHandler(this.menu_UpdateStock_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.winGridView1);
            this.groupBox4.Location = new System.Drawing.Point(15, 51);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(768, 119);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "剩余库存";
            // 
            // winGridView1
            // 
            this.winGridView1.AppendedMenu = null;
            this.winGridView1.DataSource = null;
            this.winGridView1.DisplayColumns = "";
            this.winGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winGridView1.Location = new System.Drawing.Point(3, 17);
            this.winGridView1.MinimumSize = new System.Drawing.Size(540, 0);
            this.winGridView1.Name = "winGridView1";
            this.winGridView1.PrintTitle = "";
            this.winGridView1.Size = new System.Drawing.Size(762, 99);
            this.winGridView1.TabIndex = 0;
            // 
            // ctxMenuLeftStock
            // 
            this.ctxMenuLeftStock.Name = "ctxMenuLeftStock";
            this.ctxMenuLeftStock.Size = new System.Drawing.Size(153, 26);
            // 
            // FrmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 657);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TabText = "库存管理";
            this.Text = "库存管理";
            this.Load += new System.EventHandler(this.FrmStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.menuStock.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbShopName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private WHC.Pager.WinControl.WinGridViewPager winGridTakeOut;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private WHC.Pager.WinControl.WinGridViewPager winGridStorage;
        private System.Windows.Forms.Button btnTakeOut;
        private System.Windows.Forms.ContextMenuStrip menuStock;
        private System.Windows.Forms.ToolStripMenuItem menu_UpdateStock;
        private System.Windows.Forms.Button btnUpdateAll;
        private System.Windows.Forms.ToolStripMenuItem menu_StockAlert;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menu_Stock_Modify;
        private System.Windows.Forms.GroupBox groupBox4;
        private WHC.Pager.WinControl.WinGridView winGridView1;
        private System.Windows.Forms.ContextMenuStrip ctxMenuLeftStock;
    }
}