namespace WHC.WareHouseMis.UI
{
    partial class FrmWeight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWeight));
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.winGridViewPager1 = new WHC.Pager.WinControl.WinGridViewPager();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtCarNo = new DevExpress.XtraEditors.TextEdit();
            this.txtCardID = new DevExpress.XtraEditors.TextEdit();
            this.txtMZ_BalanceNo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtMZ_Time1 = new DevExpress.XtraEditors.DateEdit();
            this.txtMZ_Time2 = new DevExpress.XtraEditors.DateEdit();
            this.txtPZ_BalanceNo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtPZ_Time1 = new DevExpress.XtraEditors.DateEdit();
            this.txtPZ_Time2 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMZ_BalanceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMZ_Time1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMZ_Time1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMZ_Time2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMZ_Time2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPZ_BalanceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPZ_Time1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPZ_Time1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPZ_Time2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPZ_Time2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Location = new System.Drawing.Point(1209, 90);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(69, 22);
            this.btnAddNew.TabIndex = 15;
            this.btnAddNew.Text = "新建";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(1134, 90);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 22);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(1359, 90);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(69, 22);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(1284, 90);
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
            this.winGridViewPager1.Size = new System.Drawing.Size(1416, 555);
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
            this.layoutControl1.Controls.Add(this.txtCarNo);
            this.layoutControl1.Controls.Add(this.txtCardID);
            this.layoutControl1.Controls.Add(this.txtMZ_BalanceNo);
            this.layoutControl1.Controls.Add(this.txtMZ_Time1);
            this.layoutControl1.Controls.Add(this.txtMZ_Time2);
            this.layoutControl1.Controls.Add(this.txtPZ_BalanceNo);
            this.layoutControl1.Controls.Add(this.txtPZ_Time1);
            this.layoutControl1.Controls.Add(this.txtPZ_Time2);
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
            this.txtCarNo.Location = new System.Drawing.Point(87, 12);
            this.txtCarNo.Name = "txtCarNo";
            this.txtCarNo.Size = new System.Drawing.Size(154, 20);
            this.txtCarNo.StyleController = this.layoutControl1;
            this.txtCarNo.TabIndex = 1;
            // 
            // txtCardID
            // 
            this.txtCardID.Location = new System.Drawing.Point(320, 12);
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.Size = new System.Drawing.Size(154, 20);
            this.txtCardID.StyleController = this.layoutControl1;
            this.txtCardID.TabIndex = 2;
            // 
            // txtMZ_BalanceNo
            // 
            this.txtMZ_BalanceNo.Location = new System.Drawing.Point(553, 12);
            this.txtMZ_BalanceNo.Name = "txtMZ_BalanceNo";
            this.txtMZ_BalanceNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMZ_BalanceNo.Size = new System.Drawing.Size(153, 20);
            this.txtMZ_BalanceNo.StyleController = this.layoutControl1;
            this.txtMZ_BalanceNo.TabIndex = 3;
            // 
            // txtMZ_Time1
            // 
            this.txtMZ_Time1.EditValue = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            this.txtMZ_Time1.Location = new System.Drawing.Point(785, 12);
            this.txtMZ_Time1.Name = "txtMZ_Time1";
            this.txtMZ_Time1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMZ_Time1.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.txtMZ_Time1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtMZ_Time1.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtMZ_Time1.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMZ_Time1.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.txtMZ_Time1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.txtMZ_Time1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMZ_Time1.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.txtMZ_Time1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMZ_Time1.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.txtMZ_Time1.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.txtMZ_Time1.Size = new System.Drawing.Size(154, 20);
            this.txtMZ_Time1.StyleController = this.layoutControl1;
            this.txtMZ_Time1.TabIndex = 4;
            // 
            // txtMZ_Time2
            // 
            this.txtMZ_Time2.EditValue = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            this.txtMZ_Time2.Location = new System.Drawing.Point(1018, 12);
            this.txtMZ_Time2.Name = "txtMZ_Time2";
            this.txtMZ_Time2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMZ_Time2.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.txtMZ_Time2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtMZ_Time2.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtMZ_Time2.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMZ_Time2.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.txtMZ_Time2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.txtMZ_Time2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMZ_Time2.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.txtMZ_Time2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtMZ_Time2.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.txtMZ_Time2.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.txtMZ_Time2.Size = new System.Drawing.Size(153, 20);
            this.txtMZ_Time2.StyleController = this.layoutControl1;
            this.txtMZ_Time2.TabIndex = 5;
            // 
            // txtPZ_BalanceNo
            // 
            this.txtPZ_BalanceNo.Location = new System.Drawing.Point(1250, 12);
            this.txtPZ_BalanceNo.Name = "txtPZ_BalanceNo";
            this.txtPZ_BalanceNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPZ_BalanceNo.Size = new System.Drawing.Size(154, 20);
            this.txtPZ_BalanceNo.StyleController = this.layoutControl1;
            this.txtPZ_BalanceNo.TabIndex = 6;
            // 
            // txtPZ_Time1
            // 
            this.txtPZ_Time1.EditValue = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            this.txtPZ_Time1.Location = new System.Drawing.Point(87, 36);
            this.txtPZ_Time1.Name = "txtPZ_Time1";
            this.txtPZ_Time1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPZ_Time1.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.txtPZ_Time1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPZ_Time1.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtPZ_Time1.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtPZ_Time1.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.txtPZ_Time1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.txtPZ_Time1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtPZ_Time1.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.txtPZ_Time1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtPZ_Time1.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.txtPZ_Time1.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.txtPZ_Time1.Size = new System.Drawing.Size(154, 20);
            this.txtPZ_Time1.StyleController = this.layoutControl1;
            this.txtPZ_Time1.TabIndex = 7;
            // 
            // txtPZ_Time2
            // 
            this.txtPZ_Time2.EditValue = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            this.txtPZ_Time2.Location = new System.Drawing.Point(320, 36);
            this.txtPZ_Time2.Name = "txtPZ_Time2";
            this.txtPZ_Time2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPZ_Time2.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.txtPZ_Time2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPZ_Time2.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtPZ_Time2.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtPZ_Time2.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.txtPZ_Time2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.txtPZ_Time2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtPZ_Time2.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.txtPZ_Time2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtPZ_Time2.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.txtPZ_Time2.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.txtPZ_Time2.Size = new System.Drawing.Size(1084, 20);
            this.txtPZ_Time2.StyleController = this.layoutControl1;
            this.txtPZ_Time2.TabIndex = 8;
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
            this.layoutControlItem7,
            this.layoutControlItem8});
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
            this.layoutControlItem1.Size = new System.Drawing.Size(233, 24);
            this.layoutControlItem1.Text = "车牌号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCardID;
            this.layoutControlItem2.CustomizationFormText = "车卡号";
            this.layoutControlItem2.Location = new System.Drawing.Point(233, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(233, 24);
            this.layoutControlItem2.Text = "车卡号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtMZ_BalanceNo;
            this.layoutControlItem3.CustomizationFormText = "毛重衡器号";
            this.layoutControlItem3.Location = new System.Drawing.Point(466, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(232, 24);
            this.layoutControlItem3.Text = "毛重衡器号";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtMZ_Time1;
            this.layoutControlItem4.CustomizationFormText = "1";
            this.layoutControlItem4.Location = new System.Drawing.Point(698, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(233, 24);
            this.layoutControlItem4.Text = "毛重开始时间";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtMZ_Time2;
            this.layoutControlItem5.CustomizationFormText = "2";
            this.layoutControlItem5.Location = new System.Drawing.Point(931, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(232, 24);
            this.layoutControlItem5.Text = "毛重结束时间";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtPZ_BalanceNo;
            this.layoutControlItem6.CustomizationFormText = "皮重衡器号";
            this.layoutControlItem6.Location = new System.Drawing.Point(1163, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(233, 24);
            this.layoutControlItem6.Text = "皮重衡器号";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtPZ_Time1;
            this.layoutControlItem7.CustomizationFormText = "1";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(233, 34);
            this.layoutControlItem7.Text = "皮重开始时间";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtPZ_Time2;
            this.layoutControlItem8.CustomizationFormText = "2";
            this.layoutControlItem8.Location = new System.Drawing.Point(233, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(1163, 34);
            this.layoutControlItem8.Text = "皮重结束时间";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(72, 14);
            // 
            // FrmWeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 680);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.winGridViewPager1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Name = "FrmWeight";
            this.Text = "汽车自动过磅信息管理";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCarNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMZ_BalanceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMZ_Time1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMZ_Time1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMZ_Time2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMZ_Time2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPZ_BalanceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPZ_Time1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPZ_Time1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPZ_Time2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPZ_Time2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
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


        private DevExpress.XtraEditors.TextEdit txtCarNo; 
 
        private DevExpress.XtraEditors.TextEdit txtCardID;

        private DevExpress.XtraEditors.ComboBoxEdit txtMZ_BalanceNo; 
 
        private DevExpress.XtraEditors.DateEdit txtMZ_Time1;  
        private DevExpress.XtraEditors.DateEdit txtMZ_Time2;

        private DevExpress.XtraEditors.ComboBoxEdit txtPZ_BalanceNo; 
 
        private DevExpress.XtraEditors.DateEdit txtPZ_Time1;  
        private DevExpress.XtraEditors.DateEdit txtPZ_Time2;  
 
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;    
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;    
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;    
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;    
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;  
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;    
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;    
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;  
 
    }
}