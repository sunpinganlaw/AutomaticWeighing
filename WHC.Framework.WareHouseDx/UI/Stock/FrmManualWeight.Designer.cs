namespace WHC.WareHouseMis.UI
{
    partial class FrmManualWeight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManualWeight));
            this.btn_daySearch = new DevExpress.XtraEditors.SimpleButton();
            this.winGridViewPager1 = new WHC.Pager.WinControl.WinGridViewPager();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtCarNo = new DevExpress.XtraEditors.TextEdit();
            this.txt_BalanceNo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtWeight = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btn_doorUp = new DevExpress.XtraEditors.SimpleButton();
            this.btn_doorDown = new DevExpress.XtraEditors.SimpleButton();
            this.btn_getCardID = new DevExpress.XtraEditors.SimpleButton();
            this.get_mzQty = new DevExpress.XtraEditors.SimpleButton();
            this.get_pzQty = new DevExpress.XtraEditors.SimpleButton();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BalanceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_daySearch
            // 
            this.btn_daySearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_daySearch.Location = new System.Drawing.Point(1333, 92);
            this.btn_daySearch.Name = "btn_daySearch";
            this.btn_daySearch.Size = new System.Drawing.Size(82, 23);
            this.btn_daySearch.TabIndex = 14;
            this.btn_daySearch.Text = "当天过磅查询";
            this.btn_daySearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // winGridViewPager1
            // 
            this.winGridViewPager1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winGridViewPager1.AppendedMenu = null;
            this.winGridViewPager1.ColumnNameAlias = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("winGridViewPager1.ColumnNameAlias")));
            this.winGridViewPager1.DataSource = null;
            this.winGridViewPager1.DisplayColumns = "";
            this.winGridViewPager1.FixedColumns = null;
            this.winGridViewPager1.Location = new System.Drawing.Point(12, 120);
            this.winGridViewPager1.MinimumSize = new System.Drawing.Size(540, 0);
            this.winGridViewPager1.Name = "winGridViewPager1";
            this.winGridViewPager1.PrintTitle = "";
            this.winGridViewPager1.ShowAddMenu = true;
            this.winGridViewPager1.ShowCheckBox = false;
            this.winGridViewPager1.ShowDeleteMenu = true;
            this.winGridViewPager1.ShowEditMenu = true;
            this.winGridViewPager1.ShowExportButton = true;
            this.winGridViewPager1.Size = new System.Drawing.Size(1416, 555);
            this.winGridViewPager1.TabIndex = 11;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.txtCarNo);
            this.layoutControl1.Controls.Add(this.txt_BalanceNo);
            this.layoutControl1.Controls.Add(this.txtWeight);
            this.layoutControl1.Location = new System.Drawing.Point(12, 8);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(70, 185, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1416, 78);
            this.layoutControl1.TabIndex = 12;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtCarNo
            // 
            this.txtCarNo.Location = new System.Drawing.Point(63, 12);
            this.txtCarNo.Name = "txtCarNo";
            this.txtCarNo.Size = new System.Drawing.Size(197, 20);
            this.txtCarNo.StyleController = this.layoutControl1;
            this.txtCarNo.TabIndex = 1;
            // 
            // txt_BalanceNo
            // 
            this.txt_BalanceNo.Location = new System.Drawing.Point(315, 12);
            this.txt_BalanceNo.Name = "txt_BalanceNo";
            this.txt_BalanceNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_BalanceNo.Size = new System.Drawing.Size(174, 20);
            this.txt_BalanceNo.StyleController = this.layoutControl1;
            this.txt_BalanceNo.TabIndex = 2;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(544, 12);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(860, 20);
            this.txtWeight.StyleController = this.layoutControl1;
            this.txtWeight.TabIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1416, 78);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCarNo;
            this.layoutControlItem1.CustomizationFormText = "车牌号";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(252, 24);
            this.layoutControlItem1.Text = "车牌号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_BalanceNo;
            this.layoutControlItem2.CustomizationFormText = "衡器号";
            this.layoutControlItem2.Location = new System.Drawing.Point(252, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(229, 24);
            this.layoutControlItem2.Text = "衡器号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtWeight;
            this.layoutControlItem3.CustomizationFormText = "衡器读数";
            this.layoutControlItem3.Location = new System.Drawing.Point(481, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(915, 24);
            this.layoutControlItem3.Text = "衡器读数";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1396, 34);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btn_doorUp
            // 
            this.btn_doorUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_doorUp.Location = new System.Drawing.Point(780, 92);
            this.btn_doorUp.Name = "btn_doorUp";
            this.btn_doorUp.Size = new System.Drawing.Size(75, 23);
            this.btn_doorUp.TabIndex = 15;
            this.btn_doorUp.Text = "开道闸";
            // 
            // btn_doorDown
            // 
            this.btn_doorDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_doorDown.Location = new System.Drawing.Point(892, 92);
            this.btn_doorDown.Name = "btn_doorDown";
            this.btn_doorDown.Size = new System.Drawing.Size(75, 23);
            this.btn_doorDown.TabIndex = 16;
            this.btn_doorDown.Text = "落道闸";
            // 
            // btn_getCardID
            // 
            this.btn_getCardID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_getCardID.Location = new System.Drawing.Point(1004, 92);
            this.btn_getCardID.Name = "btn_getCardID";
            this.btn_getCardID.Size = new System.Drawing.Size(75, 23);
            this.btn_getCardID.TabIndex = 17;
            this.btn_getCardID.Text = "获取车号";
            this.btn_getCardID.Click += new System.EventHandler(this.btn_getCardID_Click);
            // 
            // get_mzQty
            // 
            this.get_mzQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.get_mzQty.Location = new System.Drawing.Point(1116, 92);
            this.get_mzQty.Name = "get_mzQty";
            this.get_mzQty.Size = new System.Drawing.Size(75, 23);
            this.get_mzQty.TabIndex = 18;
            this.get_mzQty.Text = "秤毛重";
            this.get_mzQty.Click += new System.EventHandler(this.get_mzQty_Click);
            // 
            // get_pzQty
            // 
            this.get_pzQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.get_pzQty.Location = new System.Drawing.Point(1228, 92);
            this.get_pzQty.Name = "get_pzQty";
            this.get_pzQty.Size = new System.Drawing.Size(75, 23);
            this.get_pzQty.TabIndex = 19;
            this.get_pzQty.Text = "秤皮重";
            this.get_pzQty.Click += new System.EventHandler(this.get_pzQty_Click);
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(196, 89);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSwitch1.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.toggleSwitch1.Properties.Appearance.Options.UseFont = true;
            this.toggleSwitch1.Properties.Appearance.Options.UseForeColor = true;
            this.toggleSwitch1.Properties.OffText = "手动过磅";
            this.toggleSwitch1.Properties.OnText = "自动过磅";
            this.toggleSwitch1.Size = new System.Drawing.Size(159, 30);
            this.toggleSwitch1.TabIndex = 21;
            this.toggleSwitch1.Toggled += new System.EventHandler(this.toggleSwitch1_Toggled);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(12, 92);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(178, 23);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "手动/自动模式切换：";
            // 
            // FrmManualWeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 680);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.toggleSwitch1);
            this.Controls.Add(this.get_pzQty);
            this.Controls.Add(this.get_mzQty);
            this.Controls.Add(this.btn_getCardID);
            this.Controls.Add(this.btn_doorDown);
            this.Controls.Add(this.btn_doorUp);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.winGridViewPager1);
            this.Controls.Add(this.btn_daySearch);
            this.Name = "FrmManualWeight";
            this.Text = "汽车手动过磅信息管理";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCarNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BalanceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_daySearch;
        private WHC.Pager.WinControl.WinGridViewPager winGridViewPager1;

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;


        private DevExpress.XtraEditors.TextEdit txtCarNo; 
 
        private DevExpress.XtraEditors.TextEdit txtWeight;

        private DevExpress.XtraEditors.ComboBoxEdit txt_BalanceNo;  
 
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;    
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
         private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
         private DevExpress.XtraEditors.SimpleButton btn_doorUp;
         private DevExpress.XtraEditors.SimpleButton btn_doorDown;
         private DevExpress.XtraEditors.SimpleButton btn_getCardID;
         private DevExpress.XtraEditors.SimpleButton get_mzQty;
         private DevExpress.XtraEditors.SimpleButton get_pzQty;
         private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
         private DevExpress.XtraEditors.LabelControl labelControl1;  
 
    }
}