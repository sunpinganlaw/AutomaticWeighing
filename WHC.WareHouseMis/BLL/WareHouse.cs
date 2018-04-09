using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using WHC.Pager.Entity;
using WHC.WareHouseMis.Entity;
using WHC.WareHouseMis.IDAL;
using WHC.Framework.ControlUtil;
using WHC.Framework.Commons;

namespace WHC.WareHouseMis.BLL
{
	public class WareHouse : BaseBLL<WareHouseInfo>
    {
        public WareHouse() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public List<WareHouseInfo> GetMangedList(string manager)
        {
            List<WareHouseInfo> list = new List<WareHouseInfo>();
            string condition = string.Format("Manager like '%{0}%' ", manager);
            return base.Find(condition);
        }

        public override bool Delete(object key, DbTransaction trans = null)
        {
            string condition = string.Format("ID ={0} and (Reserved = 0 or  Reserved is null)", key);
            return DeleteByCondition(condition, trans);
        }

        public override bool DeleteByCondition(string condition, DbTransaction trans = null)
        {
            string newCondition = string.Format("{0} and Reserved = 0", condition);
            return base.DeleteByCondition(newCondition, trans);
        }

        /// <summary>
        /// 返回所有库房
        /// </summary>
        /// <returns></returns>
        public List<CListItem> GetAllWareHouse()
        {
            List<CListItem> itemList = new List<CListItem>();
            List<WareHouseInfo> wareList = BLLFactory<WareHouse>.Instance.GetAll();
            foreach (WareHouseInfo wareInfo in wareList)
            {
                itemList.Add(new CListItem(wareInfo.Name, wareInfo.Name));
            }
            return itemList;
        }
    }
}
