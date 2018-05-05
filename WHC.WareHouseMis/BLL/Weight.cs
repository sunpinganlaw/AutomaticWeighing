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
    /// Weight
    /// </summary>
	public class Weight : BaseBLL<WeightInfo>
    {
        public Weight() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public string AddMZByCardID(string CardID, string MZ_QTY, string MZ_BalanceNo, string MZ_Type, string MZ_Operator)
        {
            IWeight dal = baseDal as IWeight;
            return dal.StorePorc_AddMZByCardID(CardID, MZ_QTY, MZ_BalanceNo, MZ_Type, MZ_Operator);

        }


        public string UpdatePZByCardID(string CardID, string PZ_QTY, string PZ_BalanceNo, string PZ_Type, string PZ_Operator)
        {
            IWeight dal = baseDal as IWeight;
            return dal.StorePorc_UpdatePZByCardID(CardID, PZ_QTY, PZ_BalanceNo, PZ_Type, PZ_Operator);

        }
    }
}
