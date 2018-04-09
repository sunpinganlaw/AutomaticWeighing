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
	public class ItemDetail : BaseBLL<ItemDetailInfo>
    {
        public ItemDetail() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary>
        /// ���ݱ��������ȡ�����͵ı����б�
        /// </summary>
        /// <param name="bigType">��������</param>
        /// <returns></returns>
        public List<ItemDetailInfo> FindByBigType(string bigType)
        {
            IItemDetail dal = baseDal as IItemDetail;
            return dal.FindByBigType(bigType);
        }

        /// <summary>
        /// ���ݱ������ͻ�ȡ�����͵ı����б�
        /// </summary>
        /// <param name="itemType">��������</param>
        /// <returns></returns>
        public List<ItemDetailInfo> FindByItemType(string itemType, string wareHouse)
        {
            IItemDetail dal = baseDal as IItemDetail;
            return dal.FindByItemType(itemType, wareHouse);
        }

        /// <summary>
        /// ���ݱ������ƻ�ȡ�б�
        /// </summary>
        /// <param name="itemName">��������</param>
        /// <returns></returns>
        public List<ItemDetailInfo> FindByName(string itemName)
        {
            IItemDetail dal = baseDal as IItemDetail;
            return dal.FindByName(itemName);
        }

        /// <summary>
        /// ���ݱ��������ȡ�б�
        /// </summary>
        /// <param name="itemNo">��������</param>
        /// <returns></returns>
        public ItemDetailInfo FindByItemNo(string itemNo)
        {
            IItemDetail dal = baseDal as IItemDetail;
            return dal.FindByItemNo(itemNo);
        }    
             
        /// <summary>
        /// ���ݱ������ƺͱ�����Ż�ȡ�б�
        /// </summary>
        /// <param name="itemName">��������</param>
        /// <param name="itemNo">��������</param>
        /// <returns></returns>
        public List<ItemDetailInfo> FindByNameAndNo(string itemName, string itemNo, string wareHouse)
        {
            IItemDetail dal = baseDal as IItemDetail;
            return dal.FindByNameAndNo(itemName, itemNo, wareHouse);
        }

        /// <summary>
        /// ����Ƿ������Ŀ������Ŀ���ų�ID����ģ�
        /// </summary>
        /// <param name="itemNo"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool CheckExist(string itemNo, string ID)
        {
            string condition = string.Format("ItemNo ='{0}' and ID <> {1} ", itemNo, ID);
            return IsExistRecord(condition);
        }

        /// <summary>
        /// ��ȡָ���ֿ�ı����б�
        /// </summary>
        /// <param name="wareHouse"></param>
        /// <returns></returns>
        public List<ItemDetailInfo> GetAllByWareHouse(string wareHouse)
        {
            string condition = string.Format("WareHouse ='{0}' ", wareHouse);
            return baseDal.Find(condition);
        }

    }
}
