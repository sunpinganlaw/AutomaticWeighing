using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using WHC.Pager.Entity;
using WHC.Framework.ControlUtil;
using WHC.WareHouseMis.Entity;

namespace WHC.WareHouseMis.IDAL
{
    /// <summary>
    /// Weight
    /// </summary>
	public interface IWeight : IBaseDAL<WeightInfo>
	{
        string StorePorc_AddMZByCardID(string CardID,string MZ_QTY,string MZ_BalanceNo,string MZ_Type,string MZ_Operator, DbTransaction trans = null);
        string StorePorc_UpdatePZByCardID(string CardID, string PZ_QTY, string PZ_BalanceNo, string PZ_Type, string PZ_Operator, DbTransaction trans = null);
    }
}