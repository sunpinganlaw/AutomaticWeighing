using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


namespace WHC.Framework.Starter
{
    /// <summary>
    /// 邮箱设置
    /// </summary>
    public class BalanceSerialPortParameter
    {
     

        /// <summary>
        /// 串口名称
        /// </summary>
        [DefaultValue("COM1")]
        public string PortName { get; set; }

        /// <summary>
        /// 波特率
        /// </summary>
        [DefaultValue("9600")]
        public string BaudRate { get; set; }

        /// <summary>
        /// 数据位
        /// </summary>
        [DefaultValue(8)]
        public int DataBits { get; set; }

        /// <summary>
        /// 停止位
        /// </summary>
        [DefaultValue(1)]
        public int StopBits { get; set; }

        /// <summary>
        /// 校验位
        /// </summary>
        [DefaultValue(0)]
        public int CheckBits { get; set; }

        
    }
}
