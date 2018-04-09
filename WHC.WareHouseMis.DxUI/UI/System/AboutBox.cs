using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using WHC.Framework.Commons;using WHC.Framework.ControlUtil;

namespace WHC.WareHouseMis.UI
{
    partial class AboutBox : DevExpress.XtraEditors.XtraForm
    {
        public AboutBox()
        {
            InitializeComponent();

            //this.Text = String.Format("关于 {0} ", AssemblyTitle);
            //this.labelProductName.Text = AssemblyProduct;
            //this.labelVersion.Text = String.Format("版本 {0} ", AssemblyVersion);
            //this.labelCopyright.Text = AssemblyCopyright;
            //this.labelCompanyName.Text = AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;

            #region 初始化系统名称
            try
            {
                AppConfig config = new AppConfig();
                string Manufacturer = config.AppConfigGet("Manufacturer");
                string ApplicationName = config.AppConfigGet("ApplicationName");
                this.Text = string.Format("{0}-{1}", Manufacturer, ApplicationName);
                this.labelProductName.Text = ApplicationName;
                this.labelVersion.Text = String.Format("版本 {0}", AssemblyVersion);
                //this.labelCopyright.Text = AssemblyCopyright;
                this.labelCompanyName.Text = Manufacturer;
                this.textBoxDescription.Text = ApplicationName + "，好用的备件仓库管理系统。具有备件信息管理、备件入库、备件出库、库存查询、库房管理、业务报表等功能，是一款优秀易用的仓库管理软件。";
            }
            catch { }

            #endregion 
        }

        #region 程序集属性访问器

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
