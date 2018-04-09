using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.Win32;

using WHC.Framework.Commons;
using WHC.Security.Entity;
using WHC.Framework.BaseUI;

namespace WHC.Framework.Starter
{
    public class GlobalControl
    {
        #region 系统全局变量
        public MainForm MainDialog;

        public string AppUnit = string.Empty; //单位名称
        public string AppName = string.Empty;  //程序名称
        public string AppWholeName = string.Empty;//单位名称+程序名称
        public string SystemType = "WareMis";//系统类型

        public LoginUserInfo LoginUserInfo = null;//登陆用户基础信息        
        public Dictionary<string, string> FunctionDict = new Dictionary<string, string>();//登录用户具有的功能字典集合
        public UserInfo UserInfo = null;//登录用户信息

        public bool Registed{ get; set;}// 判断是否注册了        
        public bool EnableRegister = false;//设置一个开关，确定是否要求注册后才能使用软件

        #endregion

        #region 基本操作函数

        /// <summary>
        /// 转换框架通用的用户基础信息，方便框架使用
        /// </summary>
        /// <param name="info">权限系统定义的用户信息</param>
        /// <returns></returns>
        public LoginUserInfo ConvertToLoginUser(UserInfo info)
        {
            LoginUserInfo loginInfo = new LoginUserInfo();
            loginInfo.ID = info.ID;
            loginInfo.Name = info.Name;
            loginInfo.FullName = info.FullName;
            loginInfo.IdentityCard = info.IdentityCard;
            loginInfo.MobilePhone = info.MobilePhone;
            loginInfo.QQ = info.QQ;
            loginInfo.Email = info.Email;
            loginInfo.Gender = info.Gender;

            loginInfo.DeptId = info.Dept_ID;
            loginInfo.CompanyId = info.Company_ID;
            return loginInfo;
        }

        /// <summary>
        /// 看用户是否具有某个功能
        /// </summary>
        /// <param name="controlID"></param>
        /// <returns></returns>
        public bool HasFunction(string controlID)
        {
            bool result = false;

            if (string.IsNullOrEmpty(controlID))
            {
                result = true;
            }
            else if (FunctionDict != null && FunctionDict.ContainsKey(controlID))
            {
                result = true;
            }

            return result;
        }
        
        /// <summary>
        /// 退出系统
        /// </summary>
        public void Quit()
        {
            if (Portal.gc.MainDialog != null)
            {
                Portal.gc.MainDialog.Hide();
                Portal.gc.MainDialog.CloseAllDocuments();
            }

            Application.Exit();
        }

        /// <summary>
        /// 打开帮助文档
        /// </summary>
        public void Help()
        {
            try
            {
                const string helpfile = "Help.chm";
                Process.Start(helpfile);
            }
            catch (Exception)
            {
                MessageDxUtil.ShowWarning("文件打开失败");
            }
        }

        /// <summary>
        /// 关于对话框信息
        /// </summary>
        public void About()
        {
            AboutBox dlg = new AboutBox();
            dlg.StartPosition = FormStartPosition.CenterScreen;
            dlg.ShowDialog();
        }

        #endregion

        #region 注册相关的函数

        /// <summary>
        /// 如果用户没有注册，提示用户注册
        /// </summary>
        public void ShowRegDlg()
        {
            RegDlg myRegdlg = RegDlg.Instance();
            myRegdlg.StartPosition = FormStartPosition.CenterScreen;
            myRegdlg.TopMost = true;
            myRegdlg.Hide();
            myRegdlg.Show();
            myRegdlg.BringToFront();
        }

        /// <summary>
        /// 每次程序运行时候,检查用户是否注册(如果第一次, 那么写入第一次运行时间)
        /// </summary>
        /// <returns>如果用户已经注册, 那么返回True, 否则为False</returns>
        public bool CheckRegister()
        {
            // 先获取用户的注册码进行比较
            string serialNumber = string.Empty; //注册码
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(UIConstants.SoftwareRegistryKey, true);
            if (null != reg)
            {
                serialNumber = (string)reg.GetValue("SerialNumber");
                Portal.gc.Registed = Portal.gc.Register(serialNumber);
            }

            return Portal.gc.Registed;
        }

        /// <summary>
        /// 调用非对称加密方式对序列号进行验证
        /// </summary>
        /// <param name="serialNumber">正确的序列号</param>
        /// <returns>如果成功返回True，否则为False</returns>
        public bool Register(String serialNumber)
        {
            string hardNumber = HardwareInfoHelper.GetCPUId();
            return RSASecurityHelper.Validate(hardNumber, serialNumber);
        }

        public string GetHardNumber()
        {
            return HardwareInfoHelper.GetCPUId();
        }

        #endregion

    }
}
