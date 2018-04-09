using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WHC.Framework.Starter
{
    /// <summary>
    /// 报表设置
    /// </summary>
    public class ReportParameter
    {
        /// <summary>
        /// 派车单报表文件
        /// </summary>
        [DefaultValue("WHC.CarDispatch.CarSendBill2.rdlc")]
        public string CarSendReportFile { get; set; }
    }
}
