namespace WHC.WareHouseMis.UI
{
    partial class FrmCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCard));
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.winGridViewPager1 = new WHC.Pager.WinControl.WinGridViewPager();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCardID = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCarNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtTransportUnit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtRegisterTime1 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtRegisterTime2 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtExpireTime1 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtExpireTime2 = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransportUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterTime1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterTime1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterTime2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterTime2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpireTime1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpireTime1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpireTime2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpireTime2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Location = new System.Drawing.Point(773, 90);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(69, 22);
            this.btnAddNew.TabIndex = 15;
            this.btnAddNew.Text = "新建";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(698, 90);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 22);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(923, 90);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(69, 22);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(848, 90);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(69, 22);
            this.btnImport.TabIndex = 15;
            this.btnImport.Text = "导入";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
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
            this.winGridViewPager1.Size = new System.Drawing.Size(980, 555);
            this.winGridViewPager1.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.txtCardID);
            this.layoutControl1.Controls.Add(this.txtCarNo);
            this.layoutControl1.Controls.Add(this.txtTransportUnit);
            this.layoutControl1.Controls.Add(this.txtRegisterTime1);
            this.layoutControl1.Controls.Add(this.txtRegisterTime2);
            this.layoutControl1.Controls.Add(this.txtExpireTime1);
            this.layoutControl1.Controls.Add(this.txtExpireTime2);
            this.layoutControl1.Location = new System.Drawing.Point(12, 8);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(70, 185, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(980, 78);
            this.layoutControl1.TabIndex = 12;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(980, 78);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCardID;
            this.layoutControlItem1.CustomizationFormText = "汽车车卡";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(160, 24);
            this.layoutControlItem1.Text = "汽车车卡";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // txtCardID
            // 
            this.txtCardID.Location = new System.Drawing.Point(65, 12);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(103, 20);
            this.txtCardID.StyleController = this.layoutControl1;
            this.txtCardID.TabIndex = 1;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCarNo;
            this.layoutControlItem2.CustomizationFormText = "汽车车牌号";
            this.layoutControlItem2.Location = new System.Drawing.Point(160, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(160, 24);
            this.layoutControlItem2.Text = "汽车车牌号";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // txtCarNo
            // 
            this.txtCarNo.Location = new System.Drawing.Point(225, 12);
            this.txtCarNo.Name = "txtCarNo";
            this.txtCarNo.Size = new System.Drawing.Size(103, 20);
            this.txtCarNo.StyleController = this.layoutControl1;
            this.txtCarNo.TabIndex = 2;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtTransportUnit;
            this.layoutControlItem3.CustomizationFormText = "运输单位";
            this.layoutControlItem3.Location = new System.Drawing.Point(320, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(160, 24);
            this.layoutControlItem3.Text = "运输单位";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // txtTransportUnit
            // 
            this.txtTransportUnit.Location = new System.Drawing.Point(385, 12);
            this.txtTransportUnit.Name = "txtTransportUnit";
            this.txtTransportUnit.Size = new System.Drawing.Size(103, 20);
            this.txtTransportUnit.StyleController = this.layoutControl1;
            this.txtTransportUnit.TabIndex = 3;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtRegisterTime1;
            this.layoutControlItem4.CustomizationFormText = "1";
            this.layoutControlItem4.Location = new System.Drawing.Point(480, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(160, 24);
            this.layoutControlItem4.Text = "注册时间";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // txtRegisterTime1
            // 
            this.txtRegisterTime1.EditValue = new System.DateTime(2018, 4, 8, 0, 0, 0, 0);
            this.txtRegisterTime1.Location = new System.Drawing.Point(545, 12);
            this.txtRegisterTime1.Name = "txtRegisterTime1";
            this.txtRegisterTime1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtRegisterTime1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtRegisterTime1.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtRegisterTime1.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtRegisterTime1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtRegisterTime1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtRegisterTime1.Size = new System.Drawing.Size(103, 20);
            this.txtRegisterTime1.StyleController = this.layoutControl1;
            this.txtRegisterTime1.TabIndex = 4;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtRegisterTime2;
            this.layoutControlItem5.CustomizationFormText = "2";
            this.layoutControlItem5.Location = new System.Drawing.Point(640, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(160, 24);
            this.layoutControlItem5.Text = "注册时间";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // txtRegisterTime2
            // 
            this.txtRegisterTime2.EditValue = new System.DateTime(2018, 4, 8, 0, 0, 0, 0);
            this.txtRegisterTime2.Location = new System.Drawing.Point(705, 12);
            this.txtRegisterTime2.Name = "txtRegisterTime2";
            this.txtRegisterTime2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtRegisterTime2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtRegisterTime2.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtRegisterTime2.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtRegisterTime2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtRegisterTime2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtRegisterTime2.Size = new System.Drawing.Size(103, 20);
            this.txtRegisterTime2.StyleController = this.layoutControl1;
            this.txtRegisterTime2.TabIndex = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtExpireTime1;
            this.layoutControlItem6.CustomizationFormText = "1";
            this.layoutControlItem6.Location = new System.Drawing.Point(800, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(160, 24);
            this.layoutControlItem6.Text = "过期时间";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // txtExpireTime1
            // 
            this.txtExpireTime1.EditValue = new System.DateTime(2018, 4, 8, 0, 0, 0, 0);
            this.txtExpireTime1.Location = new System.Drawing.Point(865, 12);
            this.txtExpireTime1.Name = "txtExpireTime1";
            this.txtExpireTime1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtExpireTime1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtExpireTime1.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtExpireTime1.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtExpireTime1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtExpireTime1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtExpireTime1.Size = new System.Drawing.Size(103, 20);
            this.txtExpireTime1.StyleController = this.layoutControl1;
            this.txtExpireTime1.TabIndex = 6;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtExpireTime2;
            this.layoutControlItem7.CustomizationFormText = "2";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(960, 34);
            this.layoutControlItem7.Text = "过期时间";
            this.layoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem7.TextToControlDistance = 5;
            // 
            // txtExpireTime2
            // 
            this.txtExpireTime2.EditValue = new System.DateTime(2018, 4, 8, 0, 0, 0, 0);
            this.txtExpireTime2.Location = new System.Drawing.Point(65, 36);
            this.txtExpireTime2.Name = "txtExpireTime2";
            this.txtExpireTime2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtExpireTime2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtExpireTime2.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtExpireTime2.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtExpireTime2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtExpireTime2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtExpireTime2.Size = new System.Drawing.Size(903, 20);
            this.txtExpireTime2.StyleController = this.layoutControl1;
            this.txtExpireTime2.TabIndex = 7;
            // 
            // FrmCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 680);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.winGridViewPager1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Name = "FrmCard";
            this.Text = "汽车车卡信息管理";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransportUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterTime1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterTime1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterTime2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegisterTime2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpireTime1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpireTime1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpireTime2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpireTime2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private WHC.Pager.WinControl.WinGridViewPager winGridViewPager1;

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;


        private DevExpress.XtraEditors.TextEdit txtCardID; 
 
        private DevExpress.XtraEditors.TextEdit txtCarNo; 
 
        private DevExpress.XtraEditors.TextEdit txtTransportUnit; 
 
        private DevExpress.XtraEditors.DateEdit txtRegisterTime1;  
        private DevExpress.XtraEditors.DateEdit txtRegisterTime2;  
 
        private DevExpress.XtraEditors.DateEdit txtExpireTime1;  
        private DevExpress.XtraEditors.DateEdit txtExpireTime2;  
 
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;    
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;    
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;    
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;    
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;  
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;    
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;  
 
    }
}