using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using WHC.Pager.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WHC.WareHouseMis.Entity;
using WHC.WareHouseMis.IDAL;
using WHC.Framework.Commons;using WHC.Framework.ControlUtil;

namespace WHC.WareHouseMis.DALSQLite
{
	/// <summary>
	/// PurchaseHeader 的摘要说明。
	/// </summary>
	public class PurchaseHeader : BaseDALSQLite<PurchaseHeaderInfo>, IPurchaseHeader
	{
		#region 对象实例及构造函数

		public static PurchaseHeader Instance
		{
			get
			{
				return new PurchaseHeader();
			}
		}
		public PurchaseHeader() : base("WM_PurchaseHeader","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override PurchaseHeaderInfo DataReaderToEntity(IDataReader dataReader)
		{
			PurchaseHeaderInfo purchaseHeaderInfo = new PurchaseHeaderInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			purchaseHeaderInfo.ID = reader.GetInt32("ID");
			purchaseHeaderInfo.HandNo = reader.GetString("HandNo");
			purchaseHeaderInfo.OperationType = reader.GetString("OperationType");
			purchaseHeaderInfo.Manufacture = reader.GetString("Manufacture");
			purchaseHeaderInfo.WareHouse = reader.GetString("WareHouse");
            purchaseHeaderInfo.CostCenter = reader.GetString("CostCenter");
			purchaseHeaderInfo.Note = reader.GetString("Note");
			purchaseHeaderInfo.CreateDate = reader.GetDateTime("CreateDate");
			purchaseHeaderInfo.Creator = reader.GetString("Creator");
            purchaseHeaderInfo.CreateYear = reader.GetInt32("CreateYear");
            purchaseHeaderInfo.CreateMonth = reader.GetInt32("CreateMonth");
            purchaseHeaderInfo.PickingPeople = reader.GetString("PickingPeople");			
			return purchaseHeaderInfo;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(PurchaseHeaderInfo obj)
		{
		    PurchaseHeaderInfo info = obj as PurchaseHeaderInfo;
			Hashtable hash = new Hashtable(); 
			
 			hash.Add("HandNo", info.HandNo);
 			hash.Add("OperationType", info.OperationType);
 			hash.Add("Manufacture", info.Manufacture);
 			hash.Add("WareHouse", info.WareHouse);
            hash.Add("CostCenter", info.CostCenter);
 			hash.Add("Note", info.Note);
 			hash.Add("CreateDate", info.CreateDate);
 			hash.Add("Creator", info.Creator);
            hash.Add("CreateYear", info.CreateYear);
            hash.Add("CreateMonth", info.CreateMonth);
            hash.Add("PickingPeople", info.PickingPeople);
 				
			return hash;
		}

        /// <summary>
        /// 获取日期字段的年份列表（不重复）
        /// </summary>
        /// <param name="fieldName">日期字段</param>
        /// <returns></returns>
        public List<string> GetYearList(string fieldName)
        {
            List<string> list = new List<string>();
            string sql = string.Format("select distinct strftime('%Y', {0}) from {1} order by strftime('%Y', {0}) ", fieldName, tableName);
            Database db = CreateDatabase();
            DbCommand command = db.GetSqlStringCommand(sql);

            using (IDataReader dr = db.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    list.Add(dr[0].ToString());
                }
            }
            return list;
        }

        /// <summary>
        /// 获取指定条件的入库、出库数量
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="isIn">入库还是出库，true为入库，否则为出库</param>
        /// <returns></returns>
        public int GetPurchaseQuantity(string condition, bool isIn)
        {
            string subWhere = "h.OperationType='入库' ";
            if (!isIn)
            {
                subWhere = "h.OperationType='出库' ";
            }

            string sql = string.Format(@"SELECT SUM(d.Quantity) AS SumQuantity FROM WM_PurchaseDetail AS d 
            INNER JOIN WM_PurchaseHeader AS h ON d.PurchaseHead_ID = h.ID Where {0} AND {1}", subWhere, condition);
            string value = SqlValueList(sql);
            if (string.IsNullOrEmpty(value))
            {
                value = "0";
            }

            return Convert.ToInt32(value);
        }
    }
}