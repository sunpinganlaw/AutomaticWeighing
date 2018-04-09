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
using WHC.Framework.ControlUtil;
using WHC.WareHouseMis.Entity;
using WHC.WareHouseMis.BLL;
using WHC.Security.Entity;
using WHC.Framework.BaseUI;

namespace WHC.WareHouseMis.UI
{
    public class GlobalControl
    {
        #region 系统全局变量
        public MainForm MainDialog;
        public List<CListItem> ManagedWareHouse = new List<CListItem>();

        public string Login_Name_Key = "WareHouseMis_LoginName";
        public string gAppMsgboxTitle = string.Empty;   //程序的对话框标题
        public string gAppUnit = string.Empty; //单位名称
        public string gAppWholeName = "";

        public LoginUserInfo LoginUserInfo = null;//登陆用户基础信息        
        public Dictionary<string, string> FunctionDict = new Dictionary<string, string>();//登录用户具有的功能字典集合
        public UserInfo UserInfo = null;//登录用户信息

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
            if (FunctionDict.ContainsKey(controlID))
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
                 
        /// <summary>
        /// 弹出提示消息窗口
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="content"></param>
        public void Notify(string caption, string content)
        {
            Notify(caption, content, 400, 200, 5000);
        }

        /// <summary>
        /// 弹出提示消息窗口
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="content"></param>
        public void Notify(string caption, string content, int width, int height, int waitTime)
        {
            NotifyWindow notifyWindow = new NotifyWindow(caption, content);
            notifyWindow.TitleClicked += new System.EventHandler(notifyWindowClick);
            notifyWindow.TextClicked += new EventHandler(notifyWindowClick);
            notifyWindow.SetDimensions(width, height);
            notifyWindow.WaitTime = waitTime;
            notifyWindow.Notify();

            //保存到系统消息表
            //SystemMessageInfo messageInfo = new SystemMessageInfo();
            //messageInfo.ID = Guid.NewGuid().ToString();
            //messageInfo.Title = caption;
            //messageInfo.Content = content;
            //try
            //{
            //    BLLFactory<SystemMessage>.Instance.Insert(messageInfo);
            //}
            //catch (Exception ex)
            //{
            //    LogTextHelper.Error(ex);
            //    MessageDxUtil.ShowError(ex.Message);
            //}
        }

        private void notifyWindowClick(object sender, EventArgs e)
        {
            //SystemMessageInfo info = BLLFactory<SystemMessage>.Instance.FindLast();
            //if (info != null)
            //{
            //    //FrmEditMessage dlg = new FrmEditMessage();
            //    //dlg.ID = info.ID;
            //    //dlg.ShowDialog();
            //}
        }

        #endregion

        public List<CListItem> GetWareHouse(UserInfo loginInfo)
        {
            List<CListItem> itemList = new List<CListItem>();
            List<WareHouseInfo> wareList = new List<WareHouseInfo>();

            List<RoleInfo> roleList = BLLFactory<WHC.Security.BLL.Role>.Instance.GetRolesByUser(loginInfo.ID);
            bool found = false;
            foreach (RoleInfo roleInfo in roleList)
            {
                if (roleInfo.Name == "组长" || roleInfo.Name == "超级管理员" || roleInfo.Name == "系统管理员" || roleInfo.Name == "普通用户")
                {
                    found = true;
                }
            }

            if (found)
            {
                //如果是组长，获取所有可以管理的库房
                wareList = BLLFactory<WareHouse>.Instance.GetAll();
                foreach (WareHouseInfo wareInfo in wareList)
                {
                    itemList.Add(new CListItem(wareInfo.Name, wareInfo.Name));
                }
            }
            else
            {
                //非组长只能管理负责的
                wareList = BLLFactory<WareHouse>.Instance.GetMangedList(loginInfo.Name);
                foreach (WareHouseInfo wareInfo in wareList)
                {
                    itemList.Add(new CListItem(wareInfo.Name, wareInfo.Name));
                }
            }

            return itemList;
        }
        
        /// <summary>
        /// 获取指定字典类型的字典列表，返回CListItem列表集合
        /// </summary>
        /// <param name="dictTypeName">数据字典类型名称</param>
        /// <returns></returns>
        public List<CListItem> GetDictData(string dictTypeName)
        {
            List<CListItem> list = new List<CListItem>();
            Dictionary<string, string> dict = BLLFactory<WHC.Dictionary.BLL.DictData>.Instance.GetDictByDictType(dictTypeName);
            foreach (string key in dict.Keys)
            {
                list.Add(new CListItem(key, dict[key]));
            }
            return list;
        }
    }
}
