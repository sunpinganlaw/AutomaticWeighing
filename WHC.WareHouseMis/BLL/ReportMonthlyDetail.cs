using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using WHC.WareHouseMis.Entity;
using WHC.WareHouseMis.IDAL;
using WHC.Pager.Entity;
using WHC.Framework.ControlUtil;

namespace WHC.WareHouseMis.BLL
{
	public class ReportMonthlyDetail : BaseBLL<ReportMonthlyDetailInfo>
    {
        public ReportMonthlyDetail() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary>
        /// ɾ��ָ����ͷID��������ϸ��Ŀ
        /// </summary>
        /// <param name="headerID"></param>
        public void DeleteByHeaderID(int headerID)
        {
            string condition = string.Format("Header_ID={0}", headerID);
            baseDal.DeleteByCondition(condition);
        }

        public DataTable GetReportDetail(string headerID)
        {
            string sql = string.Format(@"Select Select [LastCount] as LC, [LastMoney] as LM, [CurrentInCount] as CIC, [CurrentInMoney] as CIM, 
                           [CurrentOutCount] as COC, [CurrentOutMoney] as COM, [CurrentCount] as CC, [CurrentMoney] as CM
                           from WM_ReportMonthlyDetail Where Header_ID='{0}' order by ID", headerID);
            return SqlTable(sql);
        }

        /// <summary>
        /// �������ͻ�ȡ���ŵĻ�������
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public int GetDeptCount(StatisticValueType valueType, string deptName)
        {
            int result = 0;
            string sql = string.Format("Select Sum(Quantity) from WM_PurchaseDetail d inner join WM_PurchaseHeader h on d.PurchaseHead_ID = h.ID Where d.Dept='{0}' ", deptName);
            if (valueType == StatisticValueType.CurrentCount)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentInCount)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='���' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentOutCount)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='����' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.LastCount)
            {
                DateTime lastMonth = DateTime.Now.AddMonths(-1);
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", lastMonth.Year, lastMonth.Month);
            }

            string value = baseDal.SqlValueList(sql);
            if (!string.IsNullOrEmpty(value))
            {
                result = Convert.ToInt32(value);
            }

            return result;
        }

        /// <summary>
        /// �������ͻ�ȡ���ŵĻ��ܽ��
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public decimal GetDeptMoney(StatisticValueType valueType, string deptName)
        {
            decimal result = 0M;
            string sql = string.Format("Select Sum(Amount) from WM_PurchaseDetail d inner join WM_PurchaseHeader h on d.PurchaseHead_ID = h.ID Where d.Dept='{0}' ", deptName);
            if (valueType == StatisticValueType.CurrentMoney)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentInMoney)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='���' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentOutMoney)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='����' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.LastMoney)
            {
                DateTime lastMonth = DateTime.Now.AddMonths(-1);
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", lastMonth.Year, lastMonth.Month);
            }

            string value = baseDal.SqlValueList(sql);
            if (!string.IsNullOrEmpty(value))
            {
                result = Convert.ToDecimal(value);
            }

            return result;
        }

        /// <summary>
        /// �������ͻ�ȡ���ⷿ�Ļ�������
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public int GetEachWareCount(StatisticValueType valueType, string wareHouseName)
        {
            int result = 0;
            string sql = string.Format("Select Sum(Quantity) from WM_PurchaseDetail d inner join WM_PurchaseHeader h on d.PurchaseHead_ID = h.ID Where d.WareHouse='{0}' ", wareHouseName);
            if (valueType == StatisticValueType.CurrentCount)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentInCount)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='���' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentOutCount)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='����' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.LastCount)
            {
                DateTime lastMonth = DateTime.Now.AddMonths(-1);
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", lastMonth.Year, lastMonth.Month);
            }

            string value = baseDal.SqlValueList(sql);
            if (!string.IsNullOrEmpty(value))
            {
                result = Convert.ToInt32(value);
            }

            return result;
        }

        /// <summary>
        /// �������ͻ�ȡ���ⷿ�Ļ��ܽ��
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public decimal GetEachWareMoney(StatisticValueType valueType, string wareHouseName)
        {
            decimal result = 0M;
            string sql = string.Format("Select Sum(Amount) from WM_PurchaseDetail d inner join WM_PurchaseHeader h on d.PurchaseHead_ID = h.ID Where d.WareHouse='{0}' ", wareHouseName);
            if (valueType == StatisticValueType.CurrentMoney)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentInMoney)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='���' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentOutMoney)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='����' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.LastMoney)
            {
                DateTime lastMonth = DateTime.Now.AddMonths(-1);
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", lastMonth.Year, lastMonth.Month);
            }

            string value = baseDal.SqlValueList(sql);
            if (!string.IsNullOrEmpty(value))
            {
                result = Convert.ToDecimal(value);
            }

            return result;
        }

        /// <summary>
        /// �������ͻ�ȡ���пⷿ�ı������Ļ�������
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public int GetWareItemTypeCount(StatisticValueType valueType, string itemType)
        {
            int result = 0;
            string sql = string.Format("Select Sum(Quantity) from WM_PurchaseDetail d inner join WM_PurchaseHeader h on d.PurchaseHead_ID = h.ID Where ItemType='{0}' ", itemType);
            if (valueType == StatisticValueType.CurrentCount)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentInCount)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='���' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentOutCount)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='����' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.LastCount)
            {
                DateTime lastMonth = DateTime.Now.AddMonths(-1);
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", lastMonth.Year, lastMonth.Month);
            }

            string value = baseDal.SqlValueList(sql);
            if (!string.IsNullOrEmpty(value))
            {
                result = Convert.ToInt32(value);
            }

            return result;
        }

        /// <summary>
        /// �������ͻ�ȡ���пⷿ�ı������Ļ��ܽ��
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public decimal GetWareItemTypeMoney(StatisticValueType valueType, string itemType)
        {
            decimal result = 0M;
            string sql = string.Format("Select Sum(Amount) from WM_PurchaseDetail d inner join WM_PurchaseHeader h on d.PurchaseHead_ID = h.ID Where ItemType='{0}' ", itemType);
            if (valueType == StatisticValueType.CurrentMoney)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentInMoney)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='���' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentOutMoney)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='����' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.LastMoney)
            {
                DateTime lastMonth = DateTime.Now.AddMonths(-1);
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", lastMonth.Year, lastMonth.Month);
            }

            string value = baseDal.SqlValueList(sql);
            if (!string.IsNullOrEmpty(value))
            {
                result = Convert.ToDecimal(value);
            }

            return result;
        }

        /// <summary>
        /// �������ͻ�ȡ���пⷿ�ı�������Ļ�������
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public int GetWareItemBigTypeCount(StatisticValueType valueType, string itemBigType)
        {
            int result = 0;
            string sql = string.Format("Select Sum(Quantity) from WM_PurchaseDetail d inner join WM_PurchaseHeader h on d.PurchaseHead_ID = h.ID Where ItemBigType='{0}' ", itemBigType);
            if (valueType == StatisticValueType.CurrentCount)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentInCount)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='���' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentOutCount)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='����' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.LastCount)
            {
                DateTime lastMonth = DateTime.Now.AddMonths(-1);
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", lastMonth.Year, lastMonth.Month);
            }

            string value = baseDal.SqlValueList(sql);
            if (!string.IsNullOrEmpty(value))
            {
                result = Convert.ToInt32(value);
            }

            return result;
        }

        /// <summary>
        /// �������ͻ�ȡ���пⷿ�ı�������Ļ��ܽ��
        /// </summary>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public decimal GetWareItemBigTypeMoney(StatisticValueType valueType, string itemBigType)
        {
            decimal result = 0M;
            string sql = string.Format("Select Sum(Amount) from WM_PurchaseDetail d inner join WM_PurchaseHeader h on d.PurchaseHead_ID = h.ID Where ItemBigType='{0}' ", itemBigType);
            if (valueType == StatisticValueType.CurrentMoney)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentInMoney)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='���' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.CurrentOutMoney)
            {
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} and h.OperationType='����' ", DateTime.Now.Year, DateTime.Now.Month);
            }
            else if (valueType == StatisticValueType.LastMoney)
            {
                DateTime lastMonth = DateTime.Now.AddMonths(-1);
                sql += string.Format(" AND h.CreateYear={0} and h.CreateMonth={1} ", lastMonth.Year, lastMonth.Month);
            }

            string value = baseDal.SqlValueList(sql);
            if (!string.IsNullOrEmpty(value))
            {
                result = Convert.ToDecimal(value);
            }

            return result;
        }

        /// <summary>
        /// ����������ȡ�ɱ�����ÿ�µķ���
        /// </summary>
        /// <param name="itemType">��������</param>
        /// <param name="costCenter">�ɱ�����</param>
        /// <param name="year">��</param>
        /// <param name="month">��</param>
        /// <returns></returns>
        public decimal GetPartMonthlyCost(string deptName, string itemType, int year, int month)
        {
            decimal result = 0M;
            string sql = string.Format(@"Select Sum(Amount) from WM_PurchaseDetail d inner join WM_PurchaseHeader h on d.PurchaseHead_ID = h.ID 
                Where h.OperationType='����' and ItemType='{0}' and d.Dept='{1}' and h.CreateYear={2} and h.CreateMonth={3}", itemType, deptName, year, month);
            string value = baseDal.SqlValueList(sql);
            if (!string.IsNullOrEmpty(value))
            {
                result = Convert.ToDecimal(value);
            }

            return result;
        }
    }

    public enum StatisticValueType
    {
        /// <summary>
        /// ���½������
        /// </summary>
        CurrentCount,

        /// <summary>
        /// �����������
        /// </summary>
        CurrentInCount,

        /// <summary>
        /// ���³�������
        /// </summary>
        CurrentOutCount,

        /// <summary>
        /// ���½������
        /// </summary>
        LastCount,

        /// <summary>
        /// ���������
        /// </summary>
        CurrentInMoney,

        /// <summary>
        /// ���½����
        /// </summary>
        CurrentMoney,

        /// <summary>
        /// ���³�����
        /// </summary>
        CurrentOutMoney,

        /// <summary>
        /// ���½����
        /// </summary>
        LastMoney
    }
}
