using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WHC.WareHouseMis.UI.Settings
{
    /// <summary>
    /// 系统参数设置
    /// </summary>
    public class GlobalParameter
    {
        /// <summary>
        /// 操作会员数据允许手工输入卡号
        /// </summary>
        [DefaultValue(true)]
        public bool AllowEnterCardNo { get; set; }
    }
}
