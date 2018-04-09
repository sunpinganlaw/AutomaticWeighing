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
        /// ������ǰ׺2λ+����������8λ+���ݿ�����4λ+�������2λ
        /// </summary>
        /// <param name="isPurchase">���ΪTrue���������ΪFalse</param>
        /// <returns></returns>
        public string GetHandNumber(bool isPurchase)
        {
            //��ȡ����Ľ������� + 1
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
        /// ��ȡ�ɹ�������
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
        /// ��ȡ�����ֶε�����б����ظ���
        /// </summary>
        /// <param name="fieldName">�����ֶ�</param>
        /// <returns></returns>
        public List<string> GetYearList(string fieldName)
        {
            IPurchaseHeader dal = baseDal as IPurchaseHeader;
            return dal.GetYearList(fieldName);
        }

        /// <summary>
        /// ��ȡָ����������⡢��������
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <param name="isIn">��⻹�ǳ��⣬trueΪ��⣬����Ϊ����</param>
        /// <returns></returns>
        public int GetPurchaseQuantity(string condition, bool isIn)
        {
            IPurchaseHeader dal = baseDal as IPurchaseHeader;
            return dal.GetPurchaseQuantity(condition, isIn);
        }
    }
}
