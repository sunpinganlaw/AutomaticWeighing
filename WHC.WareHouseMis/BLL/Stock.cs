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
	public class Stock : BaseBLL<StockInfo>
    {
        public Stock() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
                        
        /// <summary>
        /// 获取当前库存报表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetCurrentStockReport(string condition)
        {
            //ID,ItemNo,ItemName,Manufacture,MapNo,Specification,Material,ItemBigType,ItemType,Unit,Price,(UnitCost * StockQuantity) StockAmount, (Price * StockQuantity) Amount, Source,StoragePos,UsagePos,StockQuantity,AlarmQuantity,Note
            string sql = string.Format(@"Select t.ID,d.ItemNo,d.ItemName,Price,t.StockQuantity,(Price * t.StockQuantity) as StockAmount,d.Manufacture,d.MapNo,d.Specification,d.Material,d.ItemBigType,d.ItemType,d.Unit, Source,StoragePos,UsagePos,LowWarning,HighWarning,t.Note,t.WareHouse,d.Dept
                                         From WM_Stock t inner join WM_ItemDetail d on t.ItemNo = d.ItemNo  {0} order by t.id ", condition);
            return baseDal.SqlTable(sql);
        }

        /// <summary>
        /// 获取当期库存报表的记录数量
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int GetCurrentStockReportCount(string condition)
        {
            string sql = string.Format(@"Select count(*) From WM_Stock t inner join WM_ItemDetail d on t.ItemNo = d.ItemNo  {0} ", condition);
            string value = baseDal.SqlValueList(sql);
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// 检查该库房是否可以进行期初建账
        /// </summary>
        /// <param name="wareHouse"></param>
        /// <returns></returns>
        public bool CheckIsInitedWareHouse(string wareHouse, string itemNo)
        {
            bool result = false;
            string condition = string.Format("WareHouse='{0}' And ItemNo='{1}' ", wareHouse, itemNo);
            result = baseDal.IsExistRecord(condition);
            return result;
        }
                        
        /// <summary>
        /// 初始化库房信息
        /// </summary>
        /// <param name="detailInfo">备件详细信息</param>
        /// <param name="quantity">期初数量</param>
        /// <param name="wareHouse">库房名称</param>
        /// <returns></returns>
        public bool InitStockQuantity(ItemDetailInfo detailInfo, int quantity, string wareHouse)
        {
             IStock dal = baseDal as IStock;
             return dal.InitStockQuantity(detailInfo, quantity, wareHouse);
        }

        /// <summary>
        /// 增加库存
        /// </summary>
        /// <param name="ItemNo">备件编号</param>
        /// <param name="itemName">备件名称</param>
        /// <param name="quantity">库存属类</param>
        /// <returns></returns>
        public bool AddStockQuantiy(string ItemNo, string itemName, int quantity, string wareHouse)
        {
            IStock dal = baseDal as IStock;
            return dal.AddStockQuantiy(ItemNo, itemName, quantity, wareHouse);
        }

        /// <summary>
        /// 检查高库存预警状态
        /// </summary>
        /// <param name="wareHouse"></param>
        /// <returns></returns>
        public bool CheckStockHighWarning(string wareHouse)
        {
            bool result = false;
            string condition = string.Format("WareHouse='{0}' ", wareHouse);
            IStock dal = baseDal as IStock;
            List<StockInfo> stockList = dal.Find(condition);
            foreach (StockInfo info in stockList)
            {
                if (info.HighWarning > 0 && info.StockQuantity >= info.HighWarning)
                {
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// 检查库存的低库存预警情况，有预警返回True，否则False
        /// </summary>
        /// <returns></returns>
        public bool CheckStockLowWarning(string wareHouse)
        {
            bool result = false;
            string condition = string.Format("WareHouse='{0}' ", wareHouse);
            IStock dal = baseDal as IStock;
            List<StockInfo> stockList = dal.Find(condition);
            foreach (StockInfo info in stockList)
            {
                if (info.LowWarning > 0 && info.StockQuantity <= info.LowWarning)
                {
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// 根据备件编号获取库房信息
        /// </summary>
        /// <returns></returns>
        public StockInfo FindByItemNo(string itemNo, string wareHouse)
        {
            string condition = string.Format("ItemNo ='{0}' AND WareHouse='{1}'", itemNo, wareHouse);
            return baseDal.FindSingle(condition);
        }

        /// <summary>
        /// 根据备件编号获取库房信息
        /// </summary>
        /// <returns></returns>
        public StockInfo FindByItemNo(string itemNo)
        {
            string condition = string.Format("ItemNo ='{0}' ", itemNo);
            return baseDal.FindSingle(condition);
        }

        /// <summary>
        /// 根据备件编码查询库存数量
        /// </summary>
        /// <returns></returns>
        public int GetStockQuantity(string itemNo, string wareHouse)
        {
            int result = 0;
            StockInfo stockInfo = FindByItemNo(itemNo, wareHouse);
            if (stockInfo != null)
            {
                result = stockInfo.StockQuantity;
            }
            return result;
        }
                        
        /// <summary>
        /// 获取备件名称的库存数量列表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetItemStockQuantityReport(string condition, string fieldName)
        {
            IStock dal = baseDal as IStock;
            return dal.GetItemStockQuantityReport(condition, fieldName);
        }
    }
}
