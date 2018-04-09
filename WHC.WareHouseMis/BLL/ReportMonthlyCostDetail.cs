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
	public class ReportMonthlyCostDetail : BaseBLL<ReportMonthlyCostDetailInfo>
    {
        public ReportMonthlyCostDetail() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public void DeleteByHeaderID(int headerID)
        {
            string condition = string.Format("Header_ID={0}", headerID);
            baseDal.DeleteByCondition(condition);
        }
    }
}
