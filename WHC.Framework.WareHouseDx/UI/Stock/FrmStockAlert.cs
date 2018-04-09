using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using WHC.Framework.Commons;using WHC.Framework.ControlUtil;
using WHC.WareHouseMis.Entity;
using WHC.WareHouseMis.BLL;
using WHC.Framework.BaseUI;

namespace WHC.WareHouseMis.UI
{
    public partial class FrmStockAlert : BaseDock
    {
        public string ID = string.Empty;
        public string ItemName = string.Empty;
        public string ItemNo = string.Empty;
        public string WareHouse = string.Empty;

        public FrmStockAlert()
        {
            InitializeComponent();
        }

        private void SetInfo(StockInfo info)
        {
            info.LowWarning = Convert.ToInt32(txtLowWarning.Text);
            info.HighWarning = Convert.ToInt32(txtHighWarning.Text);
        }

        private void FrmStockAlert_Load(object sender, EventArgs e)
        {
            //this.btnOK.Enabled = HasFunction("Stock/Setting");
            if (!string.IsNullOrEmpty(ID))
            {
                this.Text = "编辑 " + this.Text;
                StockInfo info = BLLFactory<Stock>.Instance.FindByID(ID);
                if (info != null)
                {
                    txtLowWarning.Text = info.LowWarning.ToString();
                    txtHighWarning.Text = info.HighWarning.ToString();
                }
            }
            else
            {
                this.Text = "新建 " + this.Text;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                StockInfo info = BLLFactory<Stock>.Instance.FindByID(ID);
                if (info != null)
                {
                    SetInfo(info);

                    try
                    {
                        bool succeed = BLLFactory<Stock>.Instance.Update(info, info.ID.ToString());
                        if (succeed)
                        {
                            MessageDxUtil.ShowTips("保存成功");
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogTextHelper.Error(ex);
                        MessageDxUtil.ShowError(ex.Message);
                    }
                }
            }
        }
    }
}
