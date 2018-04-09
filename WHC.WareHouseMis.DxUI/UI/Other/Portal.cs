using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

using WHC.Framework.Commons;using WHC.Framework.ControlUtil;
using WHC.WareHouseMis.BLL;
using WHC.WareHouseMis.Entity;
using WHC.Security.Entity;
using WHC.Framework.BaseUI;

namespace WHC.WareHouseMis.UI
{
    public class Portal
    {
        public static GlobalControl gc = new GlobalControl();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            #region MyRegion
            //DateTime dtEnd = Convert.ToDateTime("6/1/2009");
            //if (DateTime.Now.CompareTo(dtEnd) > 0)
            //{
            //    string message = "使用期限已到，请联系作者wuhuacong@163.com";
            //    LogTextHelper.Error(message);
            //    MessageDxUtil.ShowError(message);
            //    Application.Exit();
            //    return;
            //} 
            #endregion

            SetUIConstants();
            GlobalMutex();

            //界面汉化
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();     

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            if (args.Length >= 1)
            {
                LoginByArgs(args);
            }
            else
            {
                LoginNormal(args);
            }            
        }

        private static void LoginNormal(string[] args)
        {
            //登录界面
            Logon dlg = new Logon();
            dlg.StartPosition = FormStartPosition.CenterScreen;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                if (dlg.bLogin)
                {
                    SplashScreen.Splasher.Show(typeof(SplashScreen.frmSplash));

                    gc.MainDialog = new MainForm();
                    gc.MainDialog.StartPosition = FormStartPosition.CenterScreen;
                    Application.Run(gc.MainDialog);
                }

            }
            dlg.Dispose();
        }

        /// <summary>
        /// 使用参数化登录
        /// </summary>
        /// <param name="args"></param>
        private static void LoginByArgs(string[] args)
        {
            CommandArgs commandArgs = CommandLine.Parse(args);
            // 获取用户参数
            string loginName = commandArgs.ArgPairs["U"];
            string password = commandArgs.ArgPairs.ContainsKey("P") ? commandArgs.ArgPairs["P"] : "";

            if (!string.IsNullOrEmpty(loginName))
            {
                string ip = NetworkUtil.GetLocalIP();
                string macAddr = HardwareInfoHelper.GetMacAddress();
                string identity = BLLFactory<WHC.Security.BLL.User>.Instance.VerifyUser(loginName, password, "WareMis", ip, macAddr);
                if (!string.IsNullOrEmpty(identity))
                {
                    UserInfo info = BLLFactory<WHC.Security.BLL.User>.Instance.GetUserByName(loginName);
                    #region 获取用户的功能列表

                    List<FunctionInfo> list = BLLFactory<WHC.Security.BLL.Function>.Instance.GetFunctionsByUser(info.ID, "WareMis");
                    if (list != null && list.Count > 0)
                    {
                        foreach (FunctionInfo functionInfo in list)
                        {
                            if (!Portal.gc.FunctionDict.ContainsKey(functionInfo.ControlID))
                            {
                                Portal.gc.FunctionDict.Add(functionInfo.ControlID, functionInfo.ControlID);
                            }
                        }
                    }

                    #endregion

                    Portal.gc.UserInfo = info;
                    Portal.gc.LoginUserInfo = Portal.gc.ConvertToLoginUser(info);
                    Cache.Instance.Add("LoginUserInfo", Portal.gc.LoginUserInfo);//缓存用户信息，方便后续处理
                    Cache.Instance.Add("FunctionDict", Portal.gc.FunctionDict);//缓存权限信息，方便后续使用

                    #region 获取用户管理的库房
                    Portal.gc.ManagedWareHouse = Portal.gc.GetWareHouse(info);
                    if (Portal.gc.ManagedWareHouse != null && Portal.gc.ManagedWareHouse.Count > 0)
                    {
                        SplashScreen.Splasher.Show(typeof(SplashScreen.frmSplash));

                        gc.MainDialog = new MainForm();
                        gc.MainDialog.StartPosition = FormStartPosition.CenterScreen;
                        Application.Run(gc.MainDialog);
                    }
                    else
                    {
                        MessageUtil.ShowTips("用户登录信息正确，但未授权管理库房信息，请联系组长授权管理");
                        LoginNormal(args);
                    }

                    #endregion
                }
                else
                {
                    MessageUtil.ShowTips("用户帐号密码不正确");
                    LoginNormal(args);
                }
            }
            else
            {
                MessageUtil.ShowTips("命令格式有误");
                LoginNormal(args);
            }
        }

        private static Mutex mutex = null;
        private static void GlobalMutex()
        {
            // 是否第一次创建mutex
            bool newMutexCreated = false;
            string mutexName = "Global\\" + "WareHouseMis";
            try
            {
                mutex = new Mutex(false, mutexName, out newMutexCreated);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(1);
            }

            // 第一次创建mutex
            if (newMutexCreated)
            {
                Console.WriteLine("程序已启动");
                //todo:此处为要执行的任务
            }
            else
            {
                MessageDxUtil.ShowTips("另一个窗口已在运行，不能重复运行。");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(1);//退出程序
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs ex)
        {
            LogTextHelper.Error(ex.Exception);

            string message = string.Format("{0}\r\n操作发生错误，您需要退出系统么？", ex.Exception.Message);
            if (DialogResult.Yes == MessageDxUtil.ShowYesNoAndError(message))
            {
                Application.Exit();
            }
        }

        private static void SetUIConstants()
        {
            //代码设置授权码
            WHC.Security.MyConstants.License = "397cV0hDLlNlY3VybXR5fOS8jeWNjuiBqnzlua-lt57niLHlkK-o_6rmioDmnK-mnInpmZDlhbzlj7h8RmFsc2Uv";
            WHC.Dictionary.MyConstants.License = "37c6V0hDLkRpY3Rpa25hcnl85LyN5Y2O6IGqfOW5_*W3nueIseWQr*i-qubKgObcr*bciemZkOWFrOWPuHxGYWxzZQvv";
            WHC.Pager.WinControl.MyConstants.License = "070eV0hDLlBhZ2VyfOS8jeWNjuiBqnx8RmFsc2Uv"; 
        }
    }
}
