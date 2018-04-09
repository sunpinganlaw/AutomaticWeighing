using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using WHC.OrderWater.Commons;
using WHC.Pager.Entity;

namespace WHC.WareHouseMis.UI
{
    public partial class FrmStock : BaseForm
    {
        public FrmStock()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmEditStorage dlg = new FrmEditStorage();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                BindStockData();
                BindStorageData();
                BindTakeOutData();
            }
        }

        public override void RefreshForm()
        {
                BindStockData();
                BindStorageData();
                BindTakeOutData();
        }

        private void btnTakeOut_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void FrmStock_Load(object sender, EventArgs e)
        {
            this.winGridView1.ProgressBar = this.toolStripProgressBar1.ProgressBar;
            this.winGridView1.AppendedMenu = this.menuStock;

            InitShopNames();

            InitStorageData();
            InitTakeOutData();

            BindStockData();
            BindStorageData();
            BindTakeOutData();

            this.btnAddNew.Enabled = Portal.gc.HasFunction("Stock/Add");
            this.btnTakeOut.Enabled = Portal.gc.HasFunction("Stock/Dispatch");
            this.menu_Stock_Modify.Enabled = Portal.gc.HasFunction("Stock/Modify");
            this.menu_StockAlert.Enabled = Portal.gc.HasFunction("Stock/Setting");
        }

        private void InitShopNames()
        {
            List<ShopInfo> shopList = BLLFactory<Shop>.Instance.GetAll();
            this.cmbShopName.Items.Clear();
            //this.cmbShopName.Items.Add(new CListItem("所有分店", ""));
            foreach (ShopInfo shopInfo in shopList)
            {
                this.cmbShopName.Items.Add(new CListItem(shopInfo.ShopName, shopInfo.ID));
            }
            if (this.cmbShopName.Items.Count > 0)
            {
                this.cmbShopName.SelectedIndex = 0;
            }
            int index = this.cmbShopName.FindStringExact(Portal.gc.CurrentShop.ShopName);
            if (index != -1)
            {
                this.cmbShopName.SelectedIndex = index;
            }
        }

        private string GetShopID()
        {
            string shopID = string.Empty;
            CListItem item = this.cmbShopName.SelectedItem as CListItem;
            if (item != null)
            {
                shopID = item.Value;
            }
            return shopID;
        }

        private DataTable CreateTable()
        {
            DataTable myDataTable = new DataTable("ParentTable");
            DataColumn myDataColumn;

            myDataColumn = new DataColumn("ID", typeof(string));
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn("Product_ID", typeof(string));
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn("ProductName", typeof(string));
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn("StockAmount", typeof(int));
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn("StockMoney", typeof(decimal));
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn("SaleMoney", typeof(decimal));
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn("LowWarning", typeof(int));
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn("HighWarning", typeof(int));
            myDataTable.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn("Note", typeof(string));
            myDataTable.Columns.Add(myDataColumn);
            return myDataTable;
        }

        private void BindStockData()
        {
            string shop_ID = GetShopID();
            List<StockInfo> stockList = BLLFactory<Stock>.Instance.GetAll(shop_ID);

            #region 刷新无效的库存量
            foreach (StockInfo info in stockList)
            {
                try
                {
                    ProductInfo productInfo = BLLFactory<Product>.Instance.FindByID(info.Product_ID);
                    if (productInfo == null)
                    {
                        BLLFactory<Stock>.Instance.Delete(info.ID);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex);
                    MessageUtil.ShowError(ex.Message);
                    return;
                }
            } 
            #endregion

            #region 添加别名解析
            this.winGridView1.AddColumnAlias("ID", "编号");
            this.winGridView1.AddColumnAlias("Product_ID", "产品ID");
            this.winGridView1.AddColumnAlias("ProductName", "产品名称");
            this.winGridView1.AddColumnAlias("StockAmount", "库存量");
            this.winGridView1.AddColumnAlias("StockMoney", "库存金额");
            this.winGridView1.AddColumnAlias("SaleMoney", "零售金额");
            this.winGridView1.AddColumnAlias("LowWarning", "低储预警库存数");
            this.winGridView1.AddColumnAlias("HighWarning", "超储预警库存数");
            this.winGridView1.AddColumnAlias("Note", "备注信息");
            this.winGridView1.DisplayColumns = "ProductName,StockAmount,StockMoney,SaleMoney,LowWarning,HighWarning,Note";
            #endregion

            #region 绑定剩余库存报表
            int StockAmount = 0;
            decimal StockMoney = 0M;
            decimal SaleMoney = 0M;
            DataTable dt = CreateTable();
            foreach (StockInfo info in stockList)
            {
                DataRow row = dt.NewRow();
                row["ID"] = info.ID;
                row["Product_ID"] = info.Product_ID;
                row["ProductName"] = info.ProductName;
                row["StockAmount"] = info.StockAmount;
                row["StockMoney"] = info.StockMoney;
                row["SaleMoney"] = info.SaleMoney;
                row["LowWarning"] = info.LowWarning;
                row["HighWarning"] = info.HighWarning;
                row["Note"] = info.Note;
                dt.Rows.Add(row);

                StockAmount += info.StockAmount;
                StockMoney += info.StockMoney;
                SaleMoney += info.SaleMoney;
            }

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["ProductName"] = "合计：";

                dr["StockAmount"] = StockAmount;
                dr["StockMoney"] = StockMoney;
                dr["SaleMoney"] = SaleMoney;

                dt.Rows.Add(dt.NewRow());
                dt.Rows.Add(dt.NewRow());
                dt.Rows.Add(dr);
            }
            this.winGridView1.DataSource = dt.DefaultView;
            this.winGridView1.PrintTitle = Portal.gc.gAppUnit + " -- " + "剩余库存查询报表"; 
            #endregion
        }

        private void menu_UpdateStock_Click(object sender, EventArgs e)
        {
            BindStockData();
        }

        #region 入库记录操作
        private void InitStorageData()
        {
            this.winGridStorage.ProgressBar = this.toolStripProgressBar1.ProgressBar;
            this.winGridStorage.OnPageChanged += new EventHandler(winGridStorage_OnPageChanged);
            this.winGridStorage.OnStartExport += new EventHandler(winGridStorage_OnStartExport);
            this.winGridStorage.OnRefresh += new EventHandler(winGridStorage_OnRefresh);
            this.winGridStorage.OnEditSelected += new EventHandler(winGridStorage_OnEditSelected);
            this.winGridStorage.OnDeleteSelected += new EventHandler(winGridStorage_OnDeleteSelected);
            this.winGridStorage.AppendedMenu = this.contextMenuStrip1;
        }

        private void winGridStorage_OnDeleteSelected(object sender, EventArgs e)
        {
             DataGridView grid = sender as DataGridView;
             if (grid != null)
             {
                 foreach (DataGridViewRow row in grid.SelectedRows)
                 {
                     BLLFactory<Storage>.Instance.Delete(row.Cells["ID"].Value.ToString());
                 }
                 BindStockData();
                 BindStorageData();
                 BindTakeOutData();
             }
        }
        private void winGridStorage_OnRefresh(object sender, EventArgs e)
        {
            BindStorageData();
        }
        private void winGridStorage_OnEditSelected(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid != null)
            {
                foreach (DataGridViewRow row in grid.SelectedRows)
                {
                    FrmEditStorage dlg = new FrmEditStorage();
                    dlg.ID = row.Cells["ID"].Value.ToString();
                    if (DialogResult.OK == dlg.ShowDialog())
                    {
                        BindStockData();
                        BindStorageData();
                        BindTakeOutData();
                    }

                    break;
                }
            }
        }
        private void winGridStorage_OnStartExport(object sender, EventArgs e)
        {
            PagerInfo pagerInfo = new PagerInfo();
            pagerInfo.CurrenetPageIndex = 1;
            pagerInfo.PageSize = int.MaxValue;
            this.winGridStorage.AllToExport = BLLFactory<Storage>.Instance.GetAllToDataSet(pagerInfo).Tables[0];//product.GetAllToDataSet(pagerInfo).Tables[0];
        }

        private void winGridStorage_OnPageChanged(object sender, EventArgs e)
        {
            BindStorageData();
        }

        private void BindStorageData()
        {
            this.winGridStorage.DisplayColumns = "CreateDate,Operator,Note,LastUpdated";
            #region 添加别名解析
            this.winGridStorage.AddColumnAlias("ID", "编号");
            this.winGridStorage.AddColumnAlias("CreateDate", "创建日期");
            this.winGridStorage.AddColumnAlias("Operator", "操作人");
            this.winGridStorage.AddColumnAlias("Shop_ID", "分店ID");
            this.winGridStorage.AddColumnAlias("Note", "备注");
            this.winGridStorage.AddColumnAlias("LastUpdated", "更新日期");
            #endregion

            string shop_ID = GetShopID();
            List <StorageInfo> collection = BLLFactory<Storage>.Instance.GetAll(shop_ID, this.winGridStorage.PagerInfo);
            //DataView collection = BLLFactory<Storage>.Instance.GetAllToDataSet(this.winGridStorage.PagerInfo).Tables[0].DefaultView;
            this.winGridStorage.DataSource = new WHC.Pager.WinControl.SortableBindingList<StorageInfo>(collection);
        } 
        #endregion

        #region 库存调拨操作

        private void InitTakeOutData()
        {
            this.winGridTakeOut.ProgressBar = this.toolStripProgressBar1.ProgressBar;
            this.winGridTakeOut.OnPageChanged += new EventHandler(winGridTakeOut_OnPageChanged);
            this.winGridTakeOut.OnStartExport += new EventHandler(winGridTakeOut_OnStartExport);
            this.winGridTakeOut.OnEditSelected += new EventHandler(winGridTakeOut_OnEditSelected);
            this.winGridTakeOut.OnRefresh += new EventHandler(winGridTakeOut_OnRefresh);
            this.winGridTakeOut.OnDeleteSelected += new EventHandler(winGridTakeOut_OnDeleteSelected);
            this.winGridTakeOut.AppendedMenu = this.contextMenuStrip1;
        }

        private void winGridTakeOut_OnDeleteSelected(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (grid != null)
            {
                foreach (DataGridViewRow row in grid.SelectedRows)
                {
                    BLLFactory<TakeOut>.Instance.Delete(row.Cells["ID"].Value.ToString());
                }
                BindTakeOutData();
            }
        }

        private void winGridTakeOut_OnRefresh(object sender, EventArgs e)
        {
            BindTakeOutData();
        }

        private void winGridTakeOut_OnEditSelected(object sender, EventArgs e)
        {
            //DataGridView grid = sender as DataGridView;
            //if (grid != null)
            //{
            //    foreach (DataGridViewRow row in grid.SelectedRows)
            //    {
            //        FrmEditProduct dlg = new FrmEditProduct();
            //        dlg.ID = row.Cells["ID"].Value.ToString();
            //        if (DialogResult.OK == dlg.ShowDialog())
            //        {
            //            BindTakeOutData();
            //        }

            //        break;
            //    }
            //}
        }

        private void winGridTakeOut_OnStartExport(object sender, EventArgs e)
        {
            PagerInfo pagerInfo = new PagerInfo();
            pagerInfo.CurrenetPageIndex = 1;
            pagerInfo.PageSize = int.MaxValue;
            this.winGridTakeOut.AllToExport = BLLFactory<TakeOut>.Instance.GetAllToDataSet(pagerInfo).Tables[0];//product.GetAllToDataSet(pagerInfo).Tables[0];
        }

        private void winGridTakeOut_OnPageChanged(object sender, EventArgs e)
        {
            BindTakeOutData();
        }

        private void BindTakeOutData()
        {
            this.winGridTakeOut.DisplayColumns = "CreateDate,Operator,Note,LastUpdated";
            #region 添加别名解析
            this.winGridTakeOut.AddColumnAlias("ID", "编号");
            this.winGridTakeOut.AddColumnAlias("CreateDate", "创建日期");
            this.winGridTakeOut.AddColumnAlias("Operator", "操作人");
            this.winGridTakeOut.AddColumnAlias("Shop_ID", "分店ID");
            this.winGridTakeOut.AddColumnAlias("Note", "备注");
            this.winGridTakeOut.AddColumnAlias("LastUpdated", "更新日期");

            #endregion

            string shop_ID = GetShopID();
            //List<TakeOutInfo> collection = BLLFactory<TakeOut>.Instance.GetAll(shop_ID, this.winGridTakeOut.PagerInfo);
            DataView collection = BLLFactory<TakeOut>.Instance.GetAllToDataSet(this.winGridTakeOut.PagerInfo).Tables[0].DefaultView;
            this.winGridTakeOut.DataSource = collection;
        } 

        #endregion

        private void btnUpdateAll_Click(object sender, EventArgs e)
        {
            BindStockData();
            BindStorageData();
            BindTakeOutData();
        }

        private void cmbShopName_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdateAll_Click(null, null);
        }

        private void menu_StockAlert_Click(object sender, EventArgs e)
        {
            if (this.winGridView1.dataGridView1.SelectedRows.Count < 0)
                return;

            foreach (DataGridViewRow item in this.winGridView1.dataGridView1.SelectedRows)
            {
                string ID = item.Cells["ID"].Value.ToString();
                if (!string.IsNullOrEmpty(ID))
                {
                    FrmStockAlert dlg = new FrmStockAlert();
                    dlg.ID = ID;
                    if (DialogResult.OK == dlg.ShowDialog())
                    {
                        BindStockData();
                    }
                }
                break;
            }
        }

        private void menu_Stock_Modify_Click(object sender, EventArgs e)
        {
            if (this.winGridView1.dataGridView1.SelectedRows.Count < 0)
                return;

            string message = string.Format("您是否确认是进行平仓？");
            if (MessageUtil.ShowYesNoAndWarning(message) == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.winGridView1.dataGridView1.SelectedRows)
                {
                    string ID = item.Cells["ID"].Value.ToString();
                    if (!string.IsNullOrEmpty(ID))
                    {
                        FrmEditStock dlg = new FrmEditStock();
                        dlg.ID = ID;
                        if (DialogResult.OK == dlg.ShowDialog())
                        {
                            BindStockData();
                        }
                    }
                    break;
                }
            }
        }
    }
}
