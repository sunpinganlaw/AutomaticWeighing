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
	public class ReportAnnualCostHeader : BaseBLL<ReportAnnualCostHeaderInfo>
    {
        public ReportAnnualCostHeader() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary>
        /// ��ȡ����û��ܱ���
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetAnnualReport(string condition)
        {
            string sql = string.Format(@"Select * from WM_ReportAnnualCostHeader {0} order by ReportYear", condition);
            return SqlTable(sql);
        }

        /// <summary>
        /// �����½ᱨ����Ը��ǣ����������£��������
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertOrUpdate(ReportAnnualCostHeaderInfo info)
        {
            int headerID = 0;
            string condition = string.Format(" ReportYear={0} AND ReportType={1} ",
                info.ReportYear, info.ReportType);
            ReportAnnualCostHeaderInfo existInfo = base.FindSingle(condition);
            if (existInfo == null)
            {
                headerID = baseDal.Insert2(info);
            }
            else
            {
                existInfo.Note = info.Note;
                existInfo.CreateDate = DateTime.Now;
                existInfo.Creator = info.Creator;
                existInfo.ReportTitle = info.ReportTitle;
                baseDal.Update(existInfo, existInfo.ID.ToString());
                headerID = existInfo.ID;
            }
            return headerID;
        }
    }
}
