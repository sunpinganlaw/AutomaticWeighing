﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WHC.Framework.BaseUI;
using WHC.WareHouseMis.BLL;
using WHC.Framework.Commons;using WHC.Framework.ControlUtil;

namespace WHC.WareHouseMis.UI
{
    public partial class FrmClearAll : BaseForm
    {
        public FrmClearAll()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageDxUtil.ShowYesNoAndWarning("本操作是危险操作，仅在系统使用的时候初始化数据库使用，请在操作前确保数据库做了备份或不需备份！\r\n按【是】执行，【否】退出操作。") == DialogResult.Yes)
            {
                try
                {
                    string condition = " 1= 1";
                    BLLFactory<ItemDetail>.Instance.DeleteByCondition(condition);
                    BLLFactory<PurchaseHeader>.Instance.DeleteByCondition(condition);
                    BLLFactory<PurchaseDetail>.Instance.DeleteByCondition(condition);
                    BLLFactory<ReportAnnualCostHeader>.Instance.DeleteByCondition(condition);
                    BLLFactory<ReportAnnualCostDetail>.Instance.DeleteByCondition(condition);
                    BLLFactory<ReportMonthlyHeader>.Instance.DeleteByCondition(condition);
                    BLLFactory<ReportMonthlyDetail>.Instance.DeleteByCondition(condition);
                    BLLFactory<ReportMonthlyCostDetail>.Instance.DeleteByCondition(condition);
                    BLLFactory<Stock>.Instance.DeleteByCondition(condition);
                    //BLLFactory<WareHouse>.Instance.DeleteByCondition(condition);

                    MessageDxUtil.ShowTips("基础业务数据已经清除，不过保留字典及库房信息。\r\n如需删除字典及库房资料，请进入相应的界面进行删除即可。");

                }
                catch (Exception ex)
                {
                    MessageDxUtil.ShowError(ex.Message);
                    LogTextHelper.Error(ex);
                }
            }
        }
    }
}
