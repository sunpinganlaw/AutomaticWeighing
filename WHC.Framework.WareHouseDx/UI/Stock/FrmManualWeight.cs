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
            this.winGridViewPager1.BestFitColumnWith = true;//�Ƿ�����Ϊ�Զ�������ȣ�falseΪ������
			this.winGridViewPager1.gridView1.DataSourceChanged +=new EventHandler(gridView1_DataSourceChanged);
            this.winGridViewPager1.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.winGridViewPager1.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);

            //�����س������в�ѯ
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
            //    if (status == "�����")
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
            //    e.DisplayText = string.Format("{0}��", e.Value);
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
        /// �����ݺ󣬷�����еĿ��
        /// </summary>
        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.winGridViewPager1.gridView1.Columns.Count > 0 && this.winGridViewPager1.gridView1.RowCount > 0)
            {
                //ͳһ����100���
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in this.winGridViewPager1.gridView1.Columns)
                {
                    column.Width = 100;
                }

                //�����������ر�Ŀ��
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
        /// ��д��ʼ�������ʵ�֣���������ˢ��
        /// </summary>
        public override void  FormOnLoad()
        {   
            BindData();
        }
        
        /// <summary>
        /// ��ʼ���ֵ��б�����
        /// </summary>
        private void InitDictItem()
        {
			//��ʼ������
     
            
        }
        
        /// <summary>
        /// ��ҳ�ؼ�ˢ�²���
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// ��ҳ�ؼ�ɾ������
        /// </summary>
        private void winGridViewPager1_OnDeleteSelected(object sender, EventArgs e)
        {
            if (MessageDxUtil.ShowYesNoAndTips("��ȷ��ɾ��ѡ���ļ�¼ô��") == DialogResult.No)
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
        /// ��ҳ�ؼ��༭�����
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
                dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ
                
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
        /// ��ҳ�ؼ���������
        /// </summary>        
        private void winGridViewPager1_OnAddNew(object sender, EventArgs e)
        {
            btnAddNew_Click(null, null);
        }
        
        /// <summary>
        /// ��ҳ�ؼ�ȫ����������ǰ�Ĳ���
        /// </summary> 
        private void winGridViewPager1_OnStartExport(object sender, EventArgs e)
        {
            string where = GetConditionSql();
            this.winGridViewPager1.AllToExport = BLLFactory<Weight>.Instance.FindToDataTable(where);
         }

        /// <summary>
        /// ��ҳ�ؼ���ҳ�Ĳ���
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// �߼���ѯ����������
        /// </summary>
        private SearchCondition advanceCondition;
        
        /// <summary>
        /// ���ݲ�ѯ���������ѯ���
        /// </summary> 
        private string GetConditionSql()
        {
            //������ڸ߼���ѯ������Ϣ����ʹ�ø߼���ѯ����������ʹ������������ѯ
            SearchCondition condition = advanceCondition;
            if (condition == null)
            {

                string startTime = DateTime.Now.AddDays(-1).ToString();
                string endTime = DateTime.Now.AddDays(0).ToString();
                condition = new SearchCondition();
                condition.AddCondition("CarNo", this.txtCarNo.Text.Trim(), SqlOperator.Like);
                condition.AddDateCondition("MZ_Time", startTime, endTime); //��������
                //condition.AddCondition("CardID", this.txtCardID.Text.Trim(), SqlOperator.Like);
                //condition.AddCondition("MZ_BalanceNo", this.txtMZ_BalanceNo.Text.Trim(), SqlOperator.Like);
                //condition.AddDateCondition("MZ_Time", this.txtMZ_Time1, this.txtMZ_Time2); //��������
                //condition.AddCondition("PZ_BalanceNo", this.txtPZ_BalanceNo.Text.Trim(), SqlOperator.Like);
                //condition.AddDateCondition("PZ_Time", this.txtPZ_Time1, this.txtPZ_Time2); //��������
                //condition.AddDateCondition("MZ_Time", this.txtMZ_Time1.Text.ToString(), this.txtMZ_Time2.Text.ToString()); //��������
           
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }
        
        /// <summary>
        /// ���б�����
        /// </summary>
        private void BindData()
        {
        	//entity
            this.winGridViewPager1.DisplayColumns = "CarNo,CardID,MzQty,PzQty,NetQty,MZ_BalanceNo,MZ_Time,MZ_Type,MZ_Operator,PZ_BalanceNo,PZ_Time,PZ_Type,PZ_Operator,PrintStatus,Remark";
            this.winGridViewPager1.ColumnNameAlias = BLLFactory<Weight>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��

            #region ��ӱ�������

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
                this.winGridViewPager1.PrintTitle = "Weight����";
         }
        
        /// <summary>
        /// ��ѯ���ݲ���
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
        	advanceCondition = null;//�������ò�ѯ������������ܻ�ʹ�ø߼���ѯ������
            BindData();
        }
        
        /// <summary>
        /// �������ݲ���
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmEditWeight dlg = new FrmEditWeight();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ
            
            if (DialogResult.OK == dlg.ShowDialog())
            {
                BindData();
            }
        }
        
        /// <summary>
        /// �ṩ���ؼ��س�ִ�в�ѯ�Ĳ���
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
        /// ����Excel�Ĳ���
        /// </summary>          
        private void btnImport_Click(object sender, EventArgs e)
        {
            string templateFile = string.Format("{0}-ģ��.xls", moduleName);
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
        /// ����Excel�Ĳ���
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string file = FileDialogHelper.SaveExcel(string.Format("{0}.xls", moduleName));
            if (!string.IsNullOrEmpty(file))
            {
                string where = GetConditionSql();
                List<WeightInfo> list = BLLFactory<Weight>.Instance.Find(where);
                DataTable dtNew = DataTableHelper.CreateTable("���|int,���ƺ�|CarNo,������|CardID,ë��|MzQty,Ƥ��|PzQty,����|NetQty,ë�غ�����|MZ_BalanceNo,ë��ʱ��|MZ_Time,ë�ط�ʽ|MZ_Type,ë��˾��Ա|MZ_Operator,Ƥ�غ�����|PZ_BalanceNo,Ƥ��ʱ��|PZ_Time,Ƥ�ط�ʽ|PZ_Type,Ƥ��˾��Ա|PZ_Operator,��ӡ״̬|PrintStatus,����״̬|DataStatus,��ע|Remark,����ʱ��|InsertTime");
                DataRow dr;
                int j = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    dr = dtNew.NewRow();
                     dr["���"] = j++;
                     dr["���ƺ�"] = list[i].CarNo;
                     dr["������"] = list[i].CardID;
                     dr["ë��"] = list[i].MzQty;
                     dr["Ƥ��"] = list[i].PzQty;
                     dr["����"] = list[i].NetQty;
                     dr["ë�غ�����"] = list[i].MZ_BalanceNo;
                     dr["ë��ʱ��"] = list[i].MZ_Time;
                     dr["ë�ط�ʽ"] = list[i].MZ_Type;
                     dr["ë��˾��Ա"] = list[i].MZ_Operator;
                     dr["Ƥ�غ�����"] = list[i].PZ_BalanceNo;
                     dr["Ƥ��ʱ��"] = list[i].PZ_Time;
                     dr["Ƥ�ط�ʽ"] = list[i].PZ_Type;
                     dr["Ƥ��˾��Ա"] = list[i].PZ_Operator;
                     dr["��ӡ״̬"] = list[i].PrintStatus;
                     dr["����״̬"] = list[i].DataStatus;
                     dr["��ע"] = list[i].Remark;
                     dr["����ʱ��"] = list[i].InsertTime;
                     dtNew.Rows.Add(dr);
                }

                try
                {
                    string error = "";
                    AsposeExcelTools.DataTableToExcel2(dtNew, file, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageDxUtil.ShowError(string.Format("����Excel���ִ���{0}", error));
                    }
                    else
                    {
                        if (MessageDxUtil.ShowYesNoAndTips("�����ɹ����Ƿ���ļ���") == System.Windows.Forms.DialogResult.Yes)
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

                #region �����б�����

                //dlg.AddColumnListItem("UserType", Portal.gc.GetDictData("��Ա����"));//�ֵ��б�
                //dlg.AddColumnListItem("Sex", "��,Ů");//�̶��б�
                //dlg.AddColumnListItem("Credit", BLLFactory<Weight>.Instance.GetFieldList("Credit"));//��̬�б�

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
            BLLFactory<Weight>.Instance.AddMZByCardID("435", "75000", "hh1", "�ֶ�", st.FullName);
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

                Cache.Instance["WeightModel"] = "�Զ�";
              

            }
            else
            {
                Cache.Instance["WeightModel"] = "�ֶ�";

            }
        }

      
    }
}
