using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WHC.Pager.Entity;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using WHC.WareHouseMis.BLL;
using WHC.WareHouseMis.Entity;
using WHC.Dictionary;
using WHC.Framework.BaseUI;
using DevExpress.XtraPrinting;
using SettingsProviderNet;



namespace WHC.WareHouseMis.UI
{
    /// <summary>
    /// Weight
    /// </summary>	
    public partial class FrmManualWeight : WHC.Framework.BaseUI.BaseDock
    {
        public FrmManualWeight()
        {
            InitializeComponent();
      
            InitDictItem();

            this.winGridViewPager1.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            this.winGridViewPager1.OnStartExport += new EventHandler(winGridViewPager1_OnStartExport);
            this.winGridViewPager1.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
            this.winGridViewPager1.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);
            this.winGridViewPager1.OnDeleteSelected += new EventHandler(winGridViewPager1_OnDeleteSelected);
            this.winGridViewPager1.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            //this.winGridViewPager1.AppendedMenu = this.contextMenuStrip1;
            this.winGridViewPager1.ShowLineNumber = true;
            this.winGridViewPager1.BestFitColumnWith = true;//是否设置为自动调整宽度，false为不设置
			this.winGridViewPager1.gridView1.DataSourceChanged +=new EventHandler(gridView1_DataSourceChanged);
            this.winGridViewPager1.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.winGridViewPager1.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);

            //关联回车键进行查询
            foreach (Control control in this.layoutControl1.Controls)
            {
                control.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchControl_KeyUp);
            }
        }
        void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //if (e.Column.FieldName == "OrderStatus")
            //{
            //    string status = this.winGridViewPager1.gridView1.GetRowCellValue(e.RowHandle, "OrderStatus").ToString();
            //    Color color = Color.White;
            //    if (status == "已审核")
            //    {
            //        e.Appearance.BackColor = Color.Red;
            //        e.Appearance.BackColor2 = Color.LightCyan;
            //    }
            //}
        }
        void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
        	string columnName = e.Column.FieldName;
            if (e.Column.ColumnType == typeof(DateTime))
            {   
                if (e.Value != null)
                {
                    if (e.Value == DBNull.Value || Convert.ToDateTime(e.Value) <= Convert.ToDateTime("1900-1-1"))
                    {
                        e.DisplayText = "";
                    }
                    else
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd HH:mm");//yyyy-MM-dd
                    }
                }
            }
            //else if (columnName == "Age")
            //{
            //    e.DisplayText = string.Format("{0}岁", e.Value);
            //}
            //else if (columnName == "ReceivedMoney")
            //{
            //    if (e.Value != null)
            //    {
            //        e.DisplayText = e.Value.ToString().ToDecimal().ToString("C");
            //    }
            //}
        }
        
        /// <summary>
        /// 绑定数据后，分配各列的宽度
        /// </summary>
        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.winGridViewPager1.gridView1.Columns.Count > 0 && this.winGridViewPager1.gridView1.RowCount > 0)
            {
                //统一设置100宽度
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in this.winGridViewPager1.gridView1.Columns)
                {
                    column.Width = 100;
                }

                //可特殊设置特别的宽度
                //SetGridColumWidth("Note", 200);
            }
        }

        private void SetGridColumWidth(string columnName, int width)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = this.winGridViewPager1.gridView1.Columns.ColumnByFieldName(columnName);
            if (column != null)
            {
                column.Width = width;
            }
        }

        /// <summary>
        /// 编写初始化窗体的实现，可以用于刷新
        /// </summary>
        public override void  FormOnLoad()
        {   
            BindData();
        }
        
        /// <summary>
        /// 初始化字典列表内容
        /// </summary>
        private void InitDictItem()
        {
			//初始化代码
     
            
        }
        
        /// <summary>
        /// 分页控件刷新操作
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// 分页控件删除操作
        /// </summary>
        private void winGridViewPager1_OnDeleteSelected(object sender, EventArgs e)
        {
            if (MessageDxUtil.ShowYesNoAndTips("您确定删除选定的记录么？") == DialogResult.No)
            {
                return;
            }

            int[] rowSelected = this.winGridViewPager1.GridView1.GetSelectedRows();
            foreach (int iRow in rowSelected)
            {
                string ID = this.winGridViewPager1.GridView1.GetRowCellDisplayText(iRow, "ID");
                BLLFactory<Weight>.Instance.Delete(ID);
            }
             
            BindData();
        }
        
        /// <summary>
        /// 分页控件编辑项操作
        /// </summary>
        private void winGridViewPager1_OnEditSelected(object sender, EventArgs e)
        {
            string ID = this.winGridViewPager1.gridView1.GetFocusedRowCellDisplayText("ID");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.winGridViewPager1.gridView1.RowCount; i++)
            {
                string strTemp = this.winGridViewPager1.GridView1.GetRowCellDisplayText(i, "ID");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditWeight dlg = new FrmEditWeight();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
                dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息
                
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    BindData();
                }
            }
        }        
        
        void dlg_OnDataSaved(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// 分页控件新增操作
        /// </summary>        
        private void winGridViewPager1_OnAddNew(object sender, EventArgs e)
        {
            btnAddNew_Click(null, null);
        }
        
        /// <summary>
        /// 分页控件全部导出操作前的操作
        /// </summary> 
        private void winGridViewPager1_OnStartExport(object sender, EventArgs e)
        {
            string where = GetConditionSql();
            this.winGridViewPager1.AllToExport = BLLFactory<Weight>.Instance.FindToDataTable(where);
         }

        /// <summary>
        /// 分页控件翻页的操作
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// 高级查询条件语句对象
        /// </summary>
        private SearchCondition advanceCondition;
        
        /// <summary>
        /// 根据查询条件构造查询语句
        /// </summary> 
        private string GetConditionSql()
        {
            //如果存在高级查询对象信息，则使用高级查询条件，否则使用主表条件查询
            SearchCondition condition = advanceCondition;
            if (condition == null)
            {

                string startTime = DateTime.Now.AddDays(-1).ToString();
                string endTime = DateTime.Now.AddDays(0).ToString();
                condition = new SearchCondition();
                condition.AddCondition("CarNo", this.txtCarNo.Text.Trim(), SqlOperator.Like);
                condition.AddDateCondition("MZ_Time", startTime, endTime); //日期类型
                //condition.AddCondition("CardID", this.txtCardID.Text.Trim(), SqlOperator.Like);
                //condition.AddCondition("MZ_BalanceNo", this.txtMZ_BalanceNo.Text.Trim(), SqlOperator.Like);
                //condition.AddDateCondition("MZ_Time", this.txtMZ_Time1, this.txtMZ_Time2); //日期类型
                //condition.AddCondition("PZ_BalanceNo", this.txtPZ_BalanceNo.Text.Trim(), SqlOperator.Like);
                //condition.AddDateCondition("PZ_Time", this.txtPZ_Time1, this.txtPZ_Time2); //日期类型
                //condition.AddDateCondition("MZ_Time", this.txtMZ_Time1.Text.ToString(), this.txtMZ_Time2.Text.ToString()); //日期类型
           
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }
        
        /// <summary>
        /// 绑定列表数据
        /// </summary>
        private void BindData()
        {
        	//entity
            this.winGridViewPager1.DisplayColumns = "CarNo,CardID,MzQty,PzQty,NetQty,MZ_BalanceNo,MZ_Time,MZ_Type,MZ_Operator,PZ_BalanceNo,PZ_Time,PZ_Type,PZ_Operator,PrintStatus,Remark";
            this.winGridViewPager1.ColumnNameAlias = BLLFactory<Weight>.Instance.GetColumnNameAlias();//字段列显示名称转义

            #region 添加别名解析

            //this.winGridViewPager1.AddColumnAlias("CarNo", "CarNo");
            //this.winGridViewPager1.AddColumnAlias("CardID", "CardID");
            //this.winGridViewPager1.AddColumnAlias("MzQty", "MzQty");
            //this.winGridViewPager1.AddColumnAlias("PzQty", "PzQty");
            //this.winGridViewPager1.AddColumnAlias("NetQty", "NetQty");
            //this.winGridViewPager1.AddColumnAlias("MZ_BalanceNo", "MZ_BalanceNo");
            //this.winGridViewPager1.AddColumnAlias("MZ_Time", "MZ_Time");
            //this.winGridViewPager1.AddColumnAlias("MZ_Type", "MZ_Type");
            //this.winGridViewPager1.AddColumnAlias("MZ_Operator", "MZ_Operator");
            //this.winGridViewPager1.AddColumnAlias("PZ_BalanceNo", "PZ_BalanceNo");
            //this.winGridViewPager1.AddColumnAlias("PZ_Time", "PZ_Time");
            //this.winGridViewPager1.AddColumnAlias("PZ_Type", "PZ_Type");
            //this.winGridViewPager1.AddColumnAlias("PZ_Operator", "PZ_Operator");
            //this.winGridViewPager1.AddColumnAlias("PrintStatus", "PrintStatus");
            //this.winGridViewPager1.AddColumnAlias("Remark", "Remark");

            #endregion

            string where = GetConditionSql();
	            List<WeightInfo> list = BLLFactory<Weight>.Instance.FindWithPager(where, this.winGridViewPager1.PagerInfo);
            this.winGridViewPager1.DataSource = new WHC.Pager.WinControl.SortableBindingList<WeightInfo>(list);
                this.winGridViewPager1.PrintTitle = "Weight报表";
         }
        
        /// <summary>
        /// 查询数据操作
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
        	advanceCondition = null;//必须重置查询条件，否则可能会使用高级查询条件了
            BindData();
        }
        
        /// <summary>
        /// 新增数据操作
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmEditWeight dlg = new FrmEditWeight();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息
            
            if (DialogResult.OK == dlg.ShowDialog())
            {
                BindData();
            }
        }
        
        /// <summary>
        /// 提供给控件回车执行查询的操作
        /// </summary>
        private void SearchControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }        

 		 		 		 		 		 		 		 		 		 		 		 		 		 		 		 		 		 
        private string moduleName = "Weight";
        /// <summary>
        /// 导入Excel的操作
        /// </summary>          
        private void btnImport_Click(object sender, EventArgs e)
        {
            string templateFile = string.Format("{0}-模板.xls", moduleName);
            FrmImportExcelData dlg = new FrmImportExcelData();
            dlg.SetTemplate(templateFile, System.IO.Path.Combine(Application.StartupPath, templateFile));
            dlg.OnDataSave += new FrmImportExcelData.SaveDataHandler(ExcelData_OnDataSave);
            dlg.OnRefreshData += new EventHandler(ExcelData_OnRefreshData);
            dlg.ShowDialog();
        }

        void ExcelData_OnRefreshData(object sender, EventArgs e)
        {
            BindData();
        }
        
        bool ExcelData_OnDataSave(DataRow dr)
        {
            bool success = false;
            bool converted = false;
            DateTime dtDefault = Convert.ToDateTime("1900-01-01");
            DateTime dt;
            WeightInfo info = new WeightInfo();
             info.CarNo = dr["CarNo"].ToString();
              info.CardID = dr["CardID"].ToString();
              info.MzQty = dr["MzQty"].ToString().ToDecimal();
              info.PzQty = dr["PzQty"].ToString().ToDecimal();
              info.NetQty = dr["NetQty"].ToString().ToDecimal();
              info.MZ_BalanceNo = dr["MZ_BalanceNo"].ToString();
              converted = DateTime.TryParse(dr["MZ_Time"].ToString(), out dt);
            if (converted && dt > dtDefault)
            {
                info.MZ_Time = dt;
            }
              info.MZ_Type = dr["MZ_Type"].ToString();
              info.MZ_Operator = dr["MZ_Operator"].ToString();
              info.PZ_BalanceNo = dr["PZ_BalanceNo"].ToString();
              converted = DateTime.TryParse(dr["PZ_Time"].ToString(), out dt);
            if (converted && dt > dtDefault)
            {
                info.PZ_Time = dt;
            }
              info.PZ_Type = dr["PZ_Type"].ToString();
              info.PZ_Operator = dr["PZ_Operator"].ToString();
              info.PrintStatus = dr["PrintStatus"].ToString().ToInt32();
              info.DataStatus = dr["DataStatus"].ToString().ToInt32();
              info.Remark = dr["Remark"].ToString();
              converted = DateTime.TryParse(dr["InsertTime"].ToString(), out dt);
            if (converted && dt > dtDefault)
            {
                info.InsertTime = dt;
            }
  
            success = BLLFactory<Weight>.Instance.Insert(info);
             return success;
        }

        /// <summary>
        /// 导出Excel的操作
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string file = FileDialogHelper.SaveExcel(string.Format("{0}.xls", moduleName));
            if (!string.IsNullOrEmpty(file))
            {
                string where = GetConditionSql();
                List<WeightInfo> list = BLLFactory<Weight>.Instance.Find(where);
                DataTable dtNew = DataTableHelper.CreateTable("序号|int,车牌号|CarNo,车卡号|CardID,毛重|MzQty,皮重|PzQty,净重|NetQty,毛重衡器号|MZ_BalanceNo,毛重时间|MZ_Time,毛重方式|MZ_Type,毛重司磅员|MZ_Operator,皮重衡器号|PZ_BalanceNo,皮重时间|PZ_Time,皮重方式|PZ_Type,皮重司磅员|PZ_Operator,打印状态|PrintStatus,数据状态|DataStatus,备注|Remark,建立时间|InsertTime");
                DataRow dr;
                int j = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    dr = dtNew.NewRow();
                     dr["序号"] = j++;
                     dr["车牌号"] = list[i].CarNo;
                     dr["车卡号"] = list[i].CardID;
                     dr["毛重"] = list[i].MzQty;
                     dr["皮重"] = list[i].PzQty;
                     dr["净重"] = list[i].NetQty;
                     dr["毛重衡器号"] = list[i].MZ_BalanceNo;
                     dr["毛重时间"] = list[i].MZ_Time;
                     dr["毛重方式"] = list[i].MZ_Type;
                     dr["毛重司磅员"] = list[i].MZ_Operator;
                     dr["皮重衡器号"] = list[i].PZ_BalanceNo;
                     dr["皮重时间"] = list[i].PZ_Time;
                     dr["皮重方式"] = list[i].PZ_Type;
                     dr["皮重司磅员"] = list[i].PZ_Operator;
                     dr["打印状态"] = list[i].PrintStatus;
                     dr["数据状态"] = list[i].DataStatus;
                     dr["备注"] = list[i].Remark;
                     dr["建立时间"] = list[i].InsertTime;
                     dtNew.Rows.Add(dr);
                }

                try
                {
                    string error = "";
                    AsposeExcelTools.DataTableToExcel2(dtNew, file, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageDxUtil.ShowError(string.Format("导出Excel出现错误：{0}", error));
                    }
                    else
                    {
                        if (MessageDxUtil.ShowYesNoAndTips("导出成功，是否打开文件？") == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(file);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex);
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
         }
         
        private FrmAdvanceSearch dlg;
        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            if (dlg == null)
            {
                dlg = new FrmAdvanceSearch();
                dlg.FieldTypeTable = BLLFactory<Weight>.Instance.GetFieldTypeList();
                dlg.ColumnNameAlias = BLLFactory<Weight>.Instance.GetColumnNameAlias();                
                 dlg.DisplayColumns = "CarNo,CardID,MZ_QTY,PZ_QTY,NET_QTY,MZ_BalanceNo,MZ_Time,MZ_Type,MZ_Operator,PZ_BalanceNo,PZ_Time,PZ_Type,PZ_Operator,PrintStatus,DataStatus,Remark,InsertTime";

                #region 下拉列表数据

                //dlg.AddColumnListItem("UserType", Portal.gc.GetDictData("人员类型"));//字典列表
                //dlg.AddColumnListItem("Sex", "男,女");//固定列表
                //dlg.AddColumnListItem("Credit", BLLFactory<Weight>.Instance.GetFieldList("Credit"));//动态列表

                #endregion

                dlg.ConditionChanged += new FrmAdvanceSearch.ConditionChangedEventHandler(dlg_ConditionChanged);
            }
            dlg.ShowDialog();
        }

        void dlg_ConditionChanged(SearchCondition condition)
        {
            advanceCondition = condition;
            BindData();
           
            
        }

        private void get_mzQty_Click(object sender, EventArgs e)
        {
            LoginUserInfo st = (LoginUserInfo)Cache.Instance["LoginUserInfo"];
            BLLFactory<Weight>.Instance.AddMZByCardID("435", "75000", "hh1", "手动", st.FullName);
        }

        private void get_pzQty_Click(object sender, EventArgs e)
        {

        }

        private void btn_getCardID_Click(object sender, EventArgs e)
        {
           txtCarNo.Text= BLLFactory<Card>.Instance.StorePorc_SelectNoByID("123");
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if(toggleSwitch1.IsOn)
            {

                Cache.Instance["WeightModel"] = "自动";
              

            }
            else
            {
                Cache.Instance["WeightModel"] = "手动";

            }
        }

      
    }
}
