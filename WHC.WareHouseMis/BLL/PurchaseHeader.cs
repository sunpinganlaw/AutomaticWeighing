using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using WHC.WareHouseMis.Entity;
using WHC.WareHouseMis.IDAL;
using WHC.Pager.Entity;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;

namespace WHC.WareHouseMis.BLL
{
    public class PurchaseHeader : BaseBLL<PurchaseHeaderInfo>
    {
        public PurchaseHeader()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary>
        /// 规则是前缀2位+日期年月日8位+数据库数量4位+随机数字2位
        /// </summary>
        /// <param name="isPurchase">入库为True，否则出库为False</param>
        /// <returns></returns>
        public string GetHandNumber(bool isPurchase)
        {
            //获取今天的结账数量 + 1
            SearchCondition condition = new SearchCondition();
            condition.AddCondition("CreateDate", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), SqlOperator.MoreThanOrEqual);
            string filter = condition.BuildConditionSql().Replace("Where", "");
            int count = baseDal.GetRecordCount(filter);
            count += 1;

            string result = string.Format("{0}{1}{2}{3}", isPurchase ? "RK" : "CK",
                DateTime.Now.ToString("yyyyMMdd"), count.ToString().PadLeft(4, '0'),
                new Random().Next(100).ToString().PadLeft(2, '0'));
            return result;
        }

        /// <summary>
        /// 获取采购单报表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetPurchaseReport(string condition)
        {
            string sql = string.Format(@"Select h.ID,h.HandNo,h.OperationType,h.Manufacture,h.WareHouse,d.Dept,h.CostCenter,h.Note,h.CreateDate,h.Creator,h.PickingPeople  
            from WM_PurchaseHeader h inner join WM_PurchaseDetail d on h.ID = d.PurchaseHead_ID {0} order by h.CreateDate", condition);
            return SqlTable(sql);
        }

        /// <summary>
        /// 获取日期字段的年份列表（不重复）
        /// </summary>
        /// <param name="fieldName">日期字段</param>
        /// <returns></returns>
        public List<string> GetYearList(string fieldName)
        {
            IPurchaseHeader dal = baseDal as IPurchaseHeader;
            return dal.GetYearList(fieldName);
        }

        /// <summary>
        /// 获取指定条件的入库、出库数量
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="isIn">入库还是出库，true为入库，否则为出库</param>
        /// <returns></returns>
        public int GetPurchaseQuantity(string condition, bool isIn)
        {
            IPurchaseHeader dal = baseDal as IPurchaseHeader;
            return dal.GetPurchaseQuantity(condition, isIn);
        }
    }
}
