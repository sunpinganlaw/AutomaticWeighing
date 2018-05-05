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
    /// <summary>
    /// Card
    /// </summary>
	public class Card : BaseBLL<CardInfo>
    {
        public Card() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public string StorePorc_SelectNoByID(string ID, DbTransaction trans = null)
        {
            ICard dal = baseDal as ICard;
            return dal.StorePorc_SelectNoByID(ID, trans);
        }


    }
}
