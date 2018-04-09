using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using WHC.Pager.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WHC.WareHouseMis.Entity;
using WHC.WareHouseMis.IDAL;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;

namespace WHC.WareHouseMis.DALOracle
{
	/// <summary>
	/// ReportMonthlyCostDetail 的摘要说明。
	/// </summary>
	public class ReportMonthlyCostDetail : BaseDALOracle<ReportMonthlyCostDetailInfo>, IReportMonthlyCostDetail
	{
		#region 对象实例及构造函数

		public static ReportMonthlyCostDetail Instance
		{
			get
			{
				return new ReportMonthlyCostDetail();
			}
		}
		public ReportMonthlyCostDetail() : base("WM_ReportMonthlyCostDetail","ID")
        {
            this.SeqName = string.Format("SEQ_{0}", tableName);//数值型主键，通过序列生成
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override ReportMonthlyCostDetailInfo DataReaderToEntity(IDataReader dataReader)
		{
			ReportMonthlyCostDetailInfo info = new ReportMonthlyCostDetailInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetInt32("ID");
			info.Header_ID = reader.GetInt32("Header_ID");
			info.ReportYear = reader.GetInt32("ReportYear");
			info.ReportMonth = reader.GetInt32("ReportMonth");
			info.YearMonth = reader.GetString("YearMonth");
			info.DeptName = reader.GetString("DeptName");
			info.ItemType = reader.GetString("ItemType");
			info.TotalMoney = reader.GetDecimal("TotalMoney");
			info.ReportCode = reader.GetString("ReportCode");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(ReportMonthlyCostDetailInfo obj)
		{
		    ReportMonthlyCostDetailInfo info = obj as ReportMonthlyCostDetailInfo;
			Hashtable hash = new Hashtable();

            hash.Add("ID", info.ID);
 			hash.Add("Header_ID", info.Header_ID);
 			hash.Add("ReportYear", info.ReportYear);
 			hash.Add("ReportMonth", info.ReportMonth);
 			hash.Add("YearMonth", info.YearMonth);
 			hash.Add("DeptName", info.DeptName);
 			hash.Add("ItemType", info.ItemType);
 			hash.Add("TotalMoney", info.TotalMoney);
 			hash.Add("ReportCode", info.ReportCode);
 				
			return hash;
		}

    }
}