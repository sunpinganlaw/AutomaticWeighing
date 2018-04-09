using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using WHC.Pager.Entity;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WHC.WareHouseMis.Entity;
using WHC.WareHouseMis.IDAL;

namespace WHC.WareHouseMis.DALSQL
{
    /// <summary>
    /// Weight
    /// </summary>
	public class Weight : BaseDALSQL<WeightInfo>, IWeight
	{
		#region 对象实例及构造函数

		public static Weight Instance
		{
			get
			{
				return new Weight();
			}
		}
		public Weight() : base("WM_Weight","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override WeightInfo DataReaderToEntity(IDataReader dataReader)
		{
			WeightInfo info = new WeightInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetInt32("ID");
			info.CarNo = reader.GetString("CarNo");
			info.CardID = reader.GetString("CardID");
			info.MzQty = reader.GetDecimal("MZ_QTY");
			info.PzQty = reader.GetDecimal("PZ_QTY");
			info.NetQty = reader.GetDecimal("NET_QTY");
			info.MZ_BalanceNo = reader.GetString("MZ_BalanceNo");
			info.MZ_Time = reader.GetDateTime("MZ_Time");
			info.MZ_Type = reader.GetString("MZ_Type");
			info.MZ_Operator = reader.GetString("MZ_Operator");
			info.PZ_BalanceNo = reader.GetString("PZ_BalanceNo");
			info.PZ_Time = reader.GetDateTime("PZ_Time");
			info.PZ_Type = reader.GetString("PZ_Type");
			info.PZ_Operator = reader.GetString("PZ_Operator");
			info.PrintStatus = reader.GetInt32("PrintStatus");
			info.DataStatus = reader.GetInt32("DataStatus");
			info.Remark = reader.GetString("Remark");
			info.InsertTime = reader.GetDateTime("InsertTime");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(WeightInfo obj)
		{
		    WeightInfo info = obj as WeightInfo;
			Hashtable hash = new Hashtable(); 
			
 			hash.Add("CarNo", info.CarNo);
 			hash.Add("CardID", info.CardID);
 			hash.Add("MZ_QTY", info.MzQty);
 			hash.Add("PZ_QTY", info.PzQty);
 			hash.Add("NET_QTY", info.NetQty);
 			hash.Add("MZ_BalanceNo", info.MZ_BalanceNo);
 			hash.Add("MZ_Time", info.MZ_Time);
 			hash.Add("MZ_Type", info.MZ_Type);
 			hash.Add("MZ_Operator", info.MZ_Operator);
 			hash.Add("PZ_BalanceNo", info.PZ_BalanceNo);
 			hash.Add("PZ_Time", info.PZ_Time);
 			hash.Add("PZ_Type", info.PZ_Type);
 			hash.Add("PZ_Operator", info.PZ_Operator);
 			hash.Add("PrintStatus", info.PrintStatus);
 			hash.Add("DataStatus", info.DataStatus);
 			hash.Add("Remark", info.Remark);
 			hash.Add("InsertTime", info.InsertTime);
 				
			return hash;
		}

        /// <summary>
        /// 获取字段中文别名（用于界面显示）的字典集合
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetColumnNameAlias()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            #region 添加别名解析
            //dict.Add("ID", "编号");
             dict.Add("CarNo", "车牌号");
             dict.Add("CardID", "卡号");
             dict.Add("MzQty", "毛重");
             dict.Add("PzQty", "皮重");
             dict.Add("NetQty", "净重");
             dict.Add("MZ_BalanceNo", "毛重衡器号");
             dict.Add("MZ_Time", "毛重时间");
             dict.Add("MZ_Type", "毛重方式");
             dict.Add("MZ_Operator", "毛重司磅员");
             dict.Add("PZ_BalanceNo", "皮重衡器号");
             dict.Add("PZ_Time", "皮重时间");
             dict.Add("PZ_Type", "皮重方式");
             dict.Add("PZ_Operator", "皮重司磅员");
             dict.Add("PrintStatus", "打印状态");
             dict.Add("DataStatus", "数据状态");
             dict.Add("Remark", "备注");
             dict.Add("InsertTime", "生成时间");
             #endregion

            return dict;
        }

    }
}