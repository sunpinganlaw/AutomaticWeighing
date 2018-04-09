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
    public class RearCameraParameter
    {
     

        /// <summary>
        /// 设备IP地址
        /// </summary>
        [DefaultValue("127.0.0.1")]
        public string IP { get; set; }

        /// <summary>
        /// 设备端口号
        /// </summary>
        [DefaultValue(2002)]
        public int Port { get; set; }

        /// <summary>
        /// 设备用户名
        /// </summary>
        [DefaultValue("admin")]
        public string  User { get; set; }

        /// <summary>
        /// 设备登录密码
        /// </summary>
        [DefaultValue("admin")]
        public string  Pass { get; set; }

        /// <summary>
        /// 照片保存地址
        /// </summary>
        [DefaultValue("C:\\Pic\\")]
        public string  SavePath { get; set; }

        
    }
}
