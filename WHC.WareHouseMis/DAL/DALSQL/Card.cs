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
    /// Card
    /// </summary>
	public class Card : BaseDALSQL<CardInfo>, ICard
	{
		#region 对象实例及构造函数

		public static Card Instance
		{
			get
			{
				return new Card();
			}
		}
		public Card() : base("WM_Card","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override CardInfo DataReaderToEntity(IDataReader dataReader)
		{
			CardInfo info = new CardInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetInt32("ID");
			info.CardID = reader.GetString("CardID");
			info.CarNo = reader.GetString("CarNo");
			info.Driver = reader.GetString("Driver");
			info.TransportUnit = reader.GetString("TransportUnit");
			info.RegisterTime = reader.GetDateTime("RegisterTime");
			info.ExpireTime = reader.GetDateTime("ExpireTime");
			info.Operator = reader.GetString("Operator");
			info.Goods = reader.GetString("Goods");
			info.TelNo = reader.GetString("TelNo");
			info.InsertTime = reader.GetDateTime("InsertTime");
			info.DataStatus = reader.GetInt32("DataStatus");
			info.Reamark = reader.GetString("Reamark");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(CardInfo obj)
		{
		    CardInfo info = obj as CardInfo;
			Hashtable hash = new Hashtable(); 
			
 			hash.Add("CardID", info.CardID);
 			hash.Add("CarNo", info.CarNo);
 			hash.Add("Driver", info.Driver);
 			hash.Add("TransportUnit", info.TransportUnit);
 			hash.Add("RegisterTime", info.RegisterTime);
 			hash.Add("ExpireTime", info.ExpireTime);
 			hash.Add("Operator", info.Operator);
 			hash.Add("Goods", info.Goods);
 			hash.Add("TelNo", info.TelNo);
 			hash.Add("InsertTime", info.InsertTime);
 			hash.Add("DataStatus", info.DataStatus);
 			hash.Add("Reamark", info.Reamark);
 				
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
             dict.Add("CardID", "车卡号");
             dict.Add("CarNo", "车牌号");
             dict.Add("Driver", "司机");
             dict.Add("TransportUnit", "运输单位");
             dict.Add("RegisterTime", "注册时间");
             dict.Add("ExpireTime", "过期时间");
             dict.Add("Operator", "操作员");
             dict.Add("Goods", "货物种类");
             dict.Add("TelNo", "联系电话");
             dict.Add("InsertTime", "生成时间");
             dict.Add("DataStatus", "数据状态");
             dict.Add("Reamark", "备注");
             #endregion

            return dict;
        }


        public  String StorePorc_SelectNoByID(string ID, DbTransaction trans = null)
        {
            string result = "";
            string procName = "T_Card_SelectNoByID";

            Database db = CreateDatabase();
            DbCommand command = db.GetStoredProcCommand(procName);
            db.AddInParameter(command, "@ID", DbType.String, ID);
            db.AddOutParameter(command, "@CarNo", DbType.String, 50);//输出参数

            if (trans != null)
            {
                db.ExecuteNonQuery(command, trans);
            }
            else
            {
                db.ExecuteNonQuery(command);
            }

            string temp = db.GetParameterValue(command, "@CarNo").ToString();
            if( temp.Length==0)
            {
                result = "查无此卡";

            }
            else
            {
                result = temp;

            }
       
            return result;
        }


    }
}