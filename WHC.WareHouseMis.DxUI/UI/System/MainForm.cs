using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.LookAndFeel;
using DevExpress.XtraTabbedMdi;

using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using WHC.WareHouseMis.Entity;
using WHC.WareHouseMis.BLL;
using WHC.Dictionary;
using WHC.Dictionary.UI;
using WHC.Framework.BaseUI;
using WHC.ContactBook.UI;
using WHC.StaffData.UI;
using WHC.WareHouseMis.UI.Settings;

namespace WHC.WareHouseMis.UI
{
    public partial class MainForm : RibbonForm
    {
        #region 属性变量
        private AppConfig config = new AppConfig();
        //月结线程
        private BackgroundWorker worker;
        private BackgroundWorker annualWorker;
        //全局热键
        private RegisterHotKeyHelper hotKey2 = new RegisterHotKeyHelper();

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
        /// <summary>
        /// Sets command status
        /// </summary>
        public string CommandStatus
        {
            get { return lblCommandStatus.Caption; }
            set { lblCommandStatus.Caption = value; }
        }
        /// <summary>
        /// Sets user status
        /// </summary>
        public string UserStatus
        {
            get { return lblCurrentUser.Caption; }
            set { lblCurrentUser.Caption = value; }
        } 
        #endregion 

        public MainForm()
        {
            InitializeComponent();

            SplashScreen.Splasher.Status = "正在展示相关的内容...";
            System.Threading.Thread.Sleep(100);

            InitUserRelated();

            #region 月结及年度结算线程操作
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);

            annualWorker = new BackgroundWorker();
            annualWorker.DoWork += new DoWorkEventHandler(annualWorker_DoWork);
            annualWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(annualWorker_RunWorkerCompleted);
            annualWorker.WorkerReportsProgress = true;
            annualWorker.WorkerSupportsCancellation = true;
            annualWorker.ProgressChanged += new ProgressChangedEventHandler(annualWorker_ProgressChanged);
            #endregion

            InitSkinGallery();
            UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");

            SplashScreen.Splasher.Status = "初始化完毕...";
            System.Threading.Thread.Sleep(50);

            SplashScreen.Splasher.Close();
            SetHotKey();
        }
                 
        /// <summary>
        /// 初始化用户相关的系统信息
        /// </summary>
        private void InitUserRelated()
        {            
            #region 根据权限显示对象的初始化窗体
            if (Portal.gc.HasFunction("ItemDetail"))
            {
                ChildWinManagement.LoadMdiForm(this, typeof(FrmItemDetail));
            }  
            if (Portal.gc.HasFunction("Purchase"))
            {
                ChildWinManagement.LoadMdiForm(this, typeof(FrmPurchase));
            }
            if (Portal.gc.HasFunction("TakeOut"))
            {
                ChildWinManagement.LoadMdiForm(this, typeof(FrmTakeOut));
            }
            ////比较慢，不加载
            //if (Portal.gc.HasFunction("StockSearch"))
            //{
            //    ChildWinManagement.LoadMdiForm(this, typeof(FrmStockSearch));
            //}

            #endregion

            #region 初始化系统名称
            try
            {
                string Manufacturer = config.AppConfigGet("Manufacturer");
                string ApplicationName = config.AppConfigGet("ApplicationName");
                string AppWholeName = string.Format("{0}-{1}", Manufacturer, ApplicationName);
                Portal.gc.gAppUnit = Manufacturer;
                Portal.gc.gAppMsgboxTitle = AppWholeName;
                Portal.gc.gAppWholeName = AppWholeName;

                this.Text = AppWholeName;
                this.notifyIcon1.BalloonTipText = AppWholeName;
                this.notifyIcon1.BalloonTipTitle = AppWholeName;
                this.notifyIcon1.Text = AppWholeName;

                UserStatus = string.Format("当前用户：{0}({1})", Portal.gc.UserInfo.FullName, Portal.gc.UserInfo.Name);
                CommandStatus = string.Format("欢迎使用 {0}", Portal.gc.gAppWholeName);
            }
            catch { }

            #endregion

            InitAuthorizedUI();//根据权限屏蔽
            if (this.ribbonControl.Pages.Count > 0)
            {
                ribbonControl.SelectedPage = ribbonControl.Pages[0];
            }
        }

        /// <summary>
        /// 设置Alt+S的显示/隐藏窗体全局热键
        /// </summary>
        private void SetHotKey()
        {
            try
            {
                hotKey2.Keys = Keys.S;
                hotKey2.ModKey = RegisterHotKeyHelper.MODKEY.MOD_ALT;
                hotKey2.WindowHandle = this.Handle;
                hotKey2.WParam = 10003;
                hotKey2.HotKey += new RegisterHotKeyHelper.HotKeyPass(hotKey2_HotKey);
                hotKey2.StarHotKey();
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
                LogTextHelper.WriteLine(ex.ToString());
            }
        }

        void hotKey2_HotKey()
        {
            notifyMenu_Show_Click(null, null);
        }

        void InitSkinGallery()
        {
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(rgbiSkins, true);
            this.ribbonControl.Toolbar.ItemLinks.Clear();
            this.ribbonControl.Toolbar.ItemLinks.Add(rgbiSkins);
        }
        
        #region 托盘菜单操作

        private void notifyMenu_About_Click(object sender, EventArgs e)
        {
            Portal.gc.About();
        }

        private void notifyMenu_Show_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.Show();
                this.BringToFront();
                this.Activate();
                this.Focus();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
        }

        private void notifyMenu_Exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowInTaskbar = false;
                Portal.gc.Quit();
            }
            catch
            {
                // Nothing to do.
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyMenu_Show_Click(sender, e);
        }

        private void MainForm_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// 缩小到托盘中，不退出
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //如果我们操作【×】按钮，那么不关闭程序而是缩小化到托盘，并提示用户.
            if (this.WindowState != FormWindowState.Minimized)
            {
                e.Cancel = true;//不关闭程序

                //最小化到托盘的时候显示图标提示信息，提示用户并未关闭程序
                this.WindowState = FormWindowState.Minimized;
                notifyIcon1.ShowBalloonTip(3000, "程序最小化提示",
                     "图标已经缩小到托盘，打开窗口请双击图标即可。也可以使用Alt+S键来显示/隐藏窗体。",
                     ToolTipIcon.Info);
            }
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            if (this == null)
            {
                return;
            }

            //最小化到托盘的时候显示图标提示信息
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(3000, "程序最小化提示",
                    "图标已经缩小到托盘，打开窗口请双击图标即可。也可以使用Alt+S键来显示/隐藏窗体。",
                    ToolTipIcon.Info);
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Portal.gc.Notify("系统信息提示", "图标已经缩小到托盘，打开窗口请双击图标即可。\r\n软件来自爱启迪技术有限公司！\r\n软件支持网站：Http://www.iqidi.com");

        }

        #endregion

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Exit(object sender, EventArgs args)
        {
            DialogResult dr = MessageDxUtil.ShowYesNoAndTips("点击“Yes”退出系统，点击“No”返回");

            if (dr == DialogResult.Yes)
            {
                notifyIcon1.Visible = false;
                Application.ExitThread();
            }
            else if (dr == DialogResult.No)
            {
                return;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        /// <summary>
        /// 根据权限屏蔽功能
        /// </summary>
        private void InitAuthorizedUI()
        {
            this.tool_Report.Enabled = Portal.gc.HasFunction("Report");
            this.tool_Dict.Enabled = Portal.gc.HasFunction("Dictionary");

            this.tool_ItemDetail.Enabled = Portal.gc.HasFunction("ItemDetail");
            this.tool_Purchase.Enabled = Portal.gc.HasFunction("Purchase");
            this.tool_StockSearch.Enabled = Portal.gc.HasFunction("StockSearch");
            this.tool_TakeOut.Enabled = Portal.gc.HasFunction("TakeOut");
            this.tool_WareHouse.Enabled = Portal.gc.HasFunction("WareHouse");
            //this.tool_Settings.Enabled = Portal.gc.HasFunction("Parameters");
            this.tool_MonthlyStatistic.Enabled = Portal.gc.HasFunction("MonthlyStatistic");
            this.tool_AnnualStatistic.Enabled = Portal.gc.HasFunction("AnnualStatistic");
            this.tool_ClearAll.Enabled = Portal.gc.HasFunction("ClearAllData");
            this.tool_ImportItemDetail.Enabled = Portal.gc.HasFunction("ImportItemDetail");
        }

        private void Init()
        {
            CCalendar cal = new CCalendar();
            this.lblCalendar.Caption = cal.GetDateInfo(System.DateTime.Now).Fullinfo;
        }

        #region Tab顶部右键菜单

        private void xtraTabbedMdiManager1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            DevExpress.XtraTab.ViewInfo.BaseTabHitInfo hi = xtraTabbedMdiManager1.CalcHitInfo(new Point(e.X, e.Y));
            if (hi.HitTest == DevExpress.XtraTab.ViewInfo.XtraTabHitTest.PageHeader)
            {
                //Form f = (hi.Page as DevExpress.XtraTabbedMdi.XtraMdiTabPage).MdiChild;
                //do something
                popupMenu1.ShowPopup(Cursor.Position);
            }
        }

        private void popMenuCloseCurrent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMdiTabPage page = xtraTabbedMdiManager1.SelectedPage;
            if (page != null && page.MdiChild != null)
            {
                page.MdiChild.Close();
            }
        }

        private void popMenuCloseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseAllDocuments();
        }

        private void popMenuCloseOther_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMdiTabPage selectedPage = xtraTabbedMdiManager1.SelectedPage;
            Type currentType = selectedPage.MdiChild.GetType();

            for (int i = xtraTabbedMdiManager1.Pages.Count - 1; i >= 0; i--)
            {
                XtraMdiTabPage page = xtraTabbedMdiManager1.Pages[i];
                if (page != null && page.MdiChild != null)
                {
                    Form form = page.MdiChild;
                    if (form.GetType() != currentType)
                    {
                        form.Close();
                        if (form != null && !form.IsDisposed)
                        {
                            form.Dispose();
                        }
                    }
                }
            }
        }

        public void CloseAllDocuments()
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
                if (form != null && !form.IsDisposed)
                {
                    form.Dispose();
                }
            }
        }
        #endregion

        #region 工具条操作
        private void barItemExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Exit(null, null);
        }

        private void btnHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Portal.gc.Help();
        }

        private void btnAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Portal.gc.About();
        }

        private void btnRegister_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Portal.gc.ShowRegDlg();
        }

        private void btnBug_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmFeeBack dlg = new FrmFeeBack();
            dlg.ShowDialog();
        }

        private void btnMyWeb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("http://www.iqidi.com");
        }

        private void menuLogo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Process.Start("http://www.iqidi.com");
            }
            catch (Exception)
            {
                MessageDxUtil.ShowError("打开浏览器失败");
            }
        }

        private void tool_Purchase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildWinManagement.LoadMdiForm(this, typeof(FrmPurchase));
        }

        private void tool_TakeOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildWinManagement.LoadMdiForm(this, typeof(FrmTakeOut));
        }

        private void tool_StockSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildWinManagement.LoadMdiForm(this, typeof(FrmStockSearch));
        }

        private void tool_ItemDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildWinManagement.LoadMdiForm(this, typeof(FrmItemDetail));
        }

        private void tool_ClearAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageDxUtil.ShowYesNoAndWarning("本操作是危险操作，仅在系统使用的时候初始化数据库使用，请在操作前确保数据库做了备份或不需备份！\r\n按【是】执行，【否】退出操作。") == DialogResult.Yes)
            {
                try
                {
                    string condition = " 1= 1";
                    BLLFactory<ItemDetail>.Instance.DeleteByCondition(condition);
                    BLLFactory<PurchaseHeader>.Instance.DeleteByCondition(condition);
                    BLLFactory<PurchaseDetail>.Instance.DeleteByCondition(condition);
                    BLLFactory<ReportAnnualCostHeader>.Instance.DeleteByCondition(condition);
                    BLLFactory<ReportAnnualCostDetail>.Instance.DeleteByCondition(condition);
                    BLLFactory<ReportMonthlyHeader>.Instance.DeleteByCondition(condition);
                    BLLFactory<ReportMonthlyDetail>.Instance.DeleteByCondition(condition);
                    BLLFactory<ReportMonthlyCostDetail>.Instance.DeleteByCondition(condition);
                    BLLFactory<Stock>.Instance.DeleteByCondition(condition);
                    //BLLFactory<WareHouse>.Instance.DeleteByCondition(condition);

                    MessageDxUtil.ShowTips("基础业务数据已经清除，不过保留字典及库房信息。\r\n如需删除字典及库房资料，请进入相应的界面进行删除即可。");

                }
                catch (Exception ex)
                {
                    MessageDxUtil.ShowError(ex.Message);
                    LogTextHelper.Error(ex);
                }
            }
        }

        private void tool_ImportItemDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmImportItemStock dlg = new FrmImportItemStock();
            dlg.ShowDialog();
        }

        private void tool_Settings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmSettings dlg = new FrmSettings();
            dlg.ShowDialog();
        }

        private void tool_Dict_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDictionary dlg = new FrmDictionary();
            dlg.ShowDialog();
        }

        private void tool_WareHouse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmWareHouse dlg = new FrmWareHouse();
            dlg.ShowDialog();
        }

        private void tool_Security_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WHC.Security.UI.Portal.StartLogin();
        }

        private void tool_ModifyPass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmModifyPassword dlg = new FrmModifyPassword();
            dlg.ShowDialog();
        }

        private void tool_Report_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmReports dlgReport = new FrmReports();
            dlgReport.ShowDialog();
        }


        private void tool_Statistics_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildWinManagement.LoadMdiForm(this, typeof(FrmStatisticReport));
        }

        private void tool_SystemMessage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string wareHouse = Portal.gc.ManagedWareHouse[0].Value;

            //低库存预警检查
            bool lowWarning = BLLFactory<Stock>.Instance.CheckStockLowWarning(wareHouse);
            if (lowWarning)
            {
                string message = string.Format("{0} 库存已经处于低库存预警状态\r\n请及时补充库存", wareHouse);
                Portal.gc.Notify(string.Format("{0} 低库存预警", wareHouse), message);
            }

            //超库存预警检查
            bool highWarning = BLLFactory<Stock>.Instance.CheckStockHighWarning(wareHouse);
            if (highWarning)
            {
                string message = string.Format("{0} 库存量已经高过超预警库存量\r\n请注意减少库存积压", wareHouse);
                Portal.gc.Notify(string.Format("{0} 超库存预警", wareHouse), message);
            }

            if (!lowWarning && !highWarning)
            {
                string message = string.Format("暂无相关的系统提示信息");
                Portal.gc.Notify(message, message);
            }
        }

        private void lblCurrentUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tool_CurrentUserInfo_ItemClick(null, null);
        }

        private void tool_CurrentUserInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmEditUser dlg = new FrmEditUser();
            dlg.ID = Portal.gc.UserInfo.ID.ToString();
            dlg.ShowDialog();
        }


        private void tool_MyAddress_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildWinManagement.LoadMdiForm(this, typeof(FrmAddress));
        }

        private void tool_PublicAddress_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildWinManagement.LoadMdiForm(this, typeof(FrmAddressCompany));
        }

        private void tool_Staff_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildWinManagement.LoadMdiForm(this, typeof(FrmStaff));
        }

        #endregion

        #region 月结线程操作

        /// <summary>
        /// 构造月结报表表头相同部分
        /// </summary>
        /// <returns></returns>
        private ReportMonthlyHeaderInfo GetMainHeader()
        {
            ReportMonthlyHeaderInfo headerInfo = new ReportMonthlyHeaderInfo();
            headerInfo.CreateDate = DateTime.Now;
            headerInfo.Creator = Portal.gc.UserInfo.FullName;
            headerInfo.ReportMonth = DateTime.Now.Month;
            headerInfo.ReportYear = DateTime.Now.Year;
            headerInfo.YearMonth = DateTime.Now.ToString("yyyy年MM月");
            return headerInfo;
        }

        private void ExecuteDeptMonthReport()
        {
            #region 构造库房部门结存月结报表
            CListItem[] deptArray = DictItemUtil.GetDictByDictType("部门");
            ReportMonthlyHeaderInfo deptHeaderInfo = GetMainHeader();
            deptHeaderInfo.ReportTitle = string.Format("{0}部门结存月报表", DateTime.Now.ToString("yyyy年MM月"));
            deptHeaderInfo.ReportType = 1;
            int headerID = BLLFactory<ReportMonthlyHeader>.Instance.InsertOrUpdate(deptHeaderInfo);
            if (headerID > 0)
            {
                worker.ReportProgress(10);
                int i = 1;

                //先删除当月月结的数据，防止重复写入
                BLLFactory<ReportMonthlyDetail>.Instance.DeleteByHeaderID(headerID);

                //重新写入记录
                foreach (CListItem deptItem in deptArray)
                {
                    ReportMonthlyDetailInfo detailInfo = new ReportMonthlyDetailInfo();
                    detailInfo.Header_ID = headerID;
                    detailInfo.ReportYear = DateTime.Now.Year;
                    detailInfo.ReportMonth = DateTime.Now.Month;
                    detailInfo.YearMonth = DateTime.Now.ToString("yyyy年MM月");
                    detailInfo.ItemName = deptItem.Value;//项目名称为部门名称
                    detailInfo.CurrentCount = BLLFactory<ReportMonthlyDetail>.Instance.GetDeptCount(StatisticValueType.CurrentCount, deptItem.Value);
                    detailInfo.CurrentInCount = BLLFactory<ReportMonthlyDetail>.Instance.GetDeptCount(StatisticValueType.CurrentInCount, deptItem.Value);
                    detailInfo.CurrentInMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetDeptMoney(StatisticValueType.CurrentInMoney, deptItem.Value);
                    detailInfo.CurrentMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetDeptMoney(StatisticValueType.CurrentMoney, deptItem.Value);
                    detailInfo.CurrentOutCount = BLLFactory<ReportMonthlyDetail>.Instance.GetDeptCount(StatisticValueType.CurrentOutCount, deptItem.Value);
                    detailInfo.CurrentOutMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetDeptMoney(StatisticValueType.CurrentOutMoney, deptItem.Value); ;
                    detailInfo.LastCount = BLLFactory<ReportMonthlyDetail>.Instance.GetDeptCount(StatisticValueType.LastCount, deptItem.Value);
                    detailInfo.LastMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetDeptMoney(StatisticValueType.LastMoney, deptItem.Value); ;
                    BLLFactory<ReportMonthlyDetail>.Instance.Insert(detailInfo);

                    i++;
                }
                worker.ReportProgress(20);
            }
            #endregion
        }

        private void ExecuteEachWareMonthlyReport()
        {
            #region 构造库房结存月报表（单库房）
            List<WareHouseInfo> wareList = BLLFactory<WareHouse>.Instance.GetAll();
            ReportMonthlyHeaderInfo eachWareHeaderInfo = GetMainHeader();
            eachWareHeaderInfo.ReportTitle = string.Format("{0}库房结存月报表", DateTime.Now.ToString("yyyy年MM月"));
            eachWareHeaderInfo.ReportType = 2;
            int headerID = BLLFactory<ReportMonthlyHeader>.Instance.InsertOrUpdate(eachWareHeaderInfo);
            if (headerID > 0)
            {
                worker.ReportProgress(30);
                int i = 1;

                //先删除当月月结的数据，防止重复写入
                BLLFactory<ReportMonthlyDetail>.Instance.DeleteByHeaderID(headerID);

                //重新写入记录
                foreach (WareHouseInfo wareInfo in wareList)
                {
                    ReportMonthlyDetailInfo detailInfo = new ReportMonthlyDetailInfo();
                    detailInfo.Header_ID = headerID;
                    detailInfo.ReportYear = DateTime.Now.Year;
                    detailInfo.ReportMonth = DateTime.Now.Month;
                    detailInfo.YearMonth = DateTime.Now.ToString("yyyy年MM月");
                    detailInfo.ItemName = wareInfo.Name;//项目名称为库房名称
                    detailInfo.CurrentCount = BLLFactory<ReportMonthlyDetail>.Instance.GetEachWareCount(StatisticValueType.CurrentCount, wareInfo.Name);
                    detailInfo.CurrentInCount = BLLFactory<ReportMonthlyDetail>.Instance.GetEachWareCount(StatisticValueType.CurrentInCount, wareInfo.Name);
                    detailInfo.CurrentInMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetEachWareMoney(StatisticValueType.CurrentInMoney, wareInfo.Name);
                    detailInfo.CurrentMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetEachWareMoney(StatisticValueType.CurrentMoney, wareInfo.Name);
                    detailInfo.CurrentOutCount = BLLFactory<ReportMonthlyDetail>.Instance.GetEachWareCount(StatisticValueType.CurrentOutCount, wareInfo.Name);
                    detailInfo.CurrentOutMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetEachWareMoney(StatisticValueType.CurrentOutMoney, wareInfo.Name); ;
                    detailInfo.LastCount = BLLFactory<ReportMonthlyDetail>.Instance.GetEachWareCount(StatisticValueType.LastCount, wareInfo.Name);
                    detailInfo.LastMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetEachWareMoney(StatisticValueType.LastMoney, wareInfo.Name); ;

                    BLLFactory<ReportMonthlyDetail>.Instance.Insert(detailInfo);

                    i++;
                }
                worker.ReportProgress(40);
            }
            #endregion
        }

        private void ExecuteAllWareItemTypeMonthlyReport()
        {
            #region 构造所有库房结存月结报表(含备件属类、备件类别分类）
            CListItem[] itemBigTypeArray = DictItemUtil.GetDictByDictType("备件属类");
            CListItem[] itemTypeArray = DictItemUtil.GetDictByDictType("备件类别");
            ReportMonthlyHeaderInfo allWareHeaderInfo = GetMainHeader();
            allWareHeaderInfo.ReportTitle = string.Format("{0}库房结存月报表", DateTime.Now.ToString("yyyy年MM月"));
            allWareHeaderInfo.ReportType = 3;
            int headerID = BLLFactory<ReportMonthlyHeader>.Instance.InsertOrUpdate(allWareHeaderInfo);
            if (headerID > 0)
            {
                worker.ReportProgress(50);
                int i = 1;

                //先删除当月月结的数据，防止重复写入
                BLLFactory<ReportMonthlyDetail>.Instance.DeleteByHeaderID(headerID);

                //重新写入记录
                foreach (CListItem bigItem in itemBigTypeArray)
                {
                    ReportMonthlyDetailInfo detailInfo = new ReportMonthlyDetailInfo();
                    detailInfo.Header_ID = headerID;
                    detailInfo.ReportYear = DateTime.Now.Year;
                    detailInfo.ReportMonth = DateTime.Now.Month;
                    detailInfo.YearMonth = DateTime.Now.ToString("yyyy年MM月");
                    detailInfo.ItemName = bigItem.Value;//项目名称为部门名称
                    detailInfo.CurrentCount = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemBigTypeCount(StatisticValueType.CurrentCount, bigItem.Value);
                    detailInfo.CurrentInCount = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemBigTypeCount(StatisticValueType.CurrentInCount, bigItem.Value);
                    detailInfo.CurrentInMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemBigTypeMoney(StatisticValueType.CurrentInMoney, bigItem.Value);
                    detailInfo.CurrentMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemBigTypeMoney(StatisticValueType.CurrentMoney, bigItem.Value);
                    detailInfo.CurrentOutCount = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemBigTypeCount(StatisticValueType.CurrentOutCount, bigItem.Value);
                    detailInfo.CurrentOutMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemBigTypeMoney(StatisticValueType.CurrentOutMoney, bigItem.Value); ;
                    detailInfo.LastCount = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemBigTypeCount(StatisticValueType.LastCount, bigItem.Value);
                    detailInfo.LastMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemBigTypeMoney(StatisticValueType.LastMoney, bigItem.Value); ;

                    detailInfo.ReportCode = "ItemBigType";//备件属类数据用001表示
                    BLLFactory<ReportMonthlyDetail>.Instance.Insert(detailInfo);

                    i++;
                }

                i = 0;
                foreach (CListItem itemType in itemTypeArray)
                {
                    ReportMonthlyDetailInfo detailInfo = new ReportMonthlyDetailInfo();
                    detailInfo.Header_ID = headerID;
                    detailInfo.ReportYear = DateTime.Now.Year;
                    detailInfo.ReportMonth = DateTime.Now.Month;
                    detailInfo.YearMonth = DateTime.Now.ToString("yyyy年MM月");
                    detailInfo.ItemName = itemType.Value;//项目名称为部门名称
                    detailInfo.CurrentCount = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemTypeCount(StatisticValueType.CurrentCount, itemType.Value);
                    detailInfo.CurrentInCount = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemTypeCount(StatisticValueType.CurrentInCount, itemType.Value);
                    detailInfo.CurrentInMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemTypeMoney(StatisticValueType.CurrentInMoney, itemType.Value);
                    detailInfo.CurrentMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemTypeMoney(StatisticValueType.CurrentMoney, itemType.Value);
                    detailInfo.CurrentOutCount = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemTypeCount(StatisticValueType.CurrentOutCount, itemType.Value);
                    detailInfo.CurrentOutMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemTypeMoney(StatisticValueType.CurrentOutMoney, itemType.Value); ;
                    detailInfo.LastCount = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemTypeCount(StatisticValueType.LastCount, itemType.Value);
                    detailInfo.LastMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetWareItemTypeMoney(StatisticValueType.LastMoney, itemType.Value); ;

                    detailInfo.ReportCode = "ItemType";//备件类别数据用002表示
                    BLLFactory<ReportMonthlyDetail>.Instance.Insert(detailInfo);

                    i++;
                }
                worker.ReportProgress(60);
            }
            #endregion
        }

        private void ExecuteEachPartCostMonthlyReport()
        {
            #region 构造各车间成本月报表
            CListItem[] deptArray = DictItemUtil.GetDictByDictType("部门");
            CListItem[] itemTypeArray = DictItemUtil.GetDictByDictType("备件类别");
            ReportMonthlyHeaderInfo deptCostHeaderInfo = GetMainHeader();
            deptCostHeaderInfo.ReportTitle = string.Format("{0}各车间成本月报表", DateTime.Now.ToString("yyyy年MM月"));
            deptCostHeaderInfo.ReportType = 4;
            int headerID = BLLFactory<ReportMonthlyHeader>.Instance.InsertOrUpdate(deptCostHeaderInfo);
            if (headerID > 0)
            {
                worker.ReportProgress(70);
                int i = 1;
                int j = 1;

                //先删除当月月结的数据，防止重复写入
                BLLFactory<ReportMonthlyCostDetail>.Instance.DeleteByHeaderID(headerID);

                //重新写入记录
                foreach (CListItem deptItem in deptArray)
                {
                    foreach (CListItem itemType in itemTypeArray)
                    {
                        ReportMonthlyCostDetailInfo detailInfo = new ReportMonthlyCostDetailInfo();
                        detailInfo.Header_ID = headerID;
                        detailInfo.ReportYear = DateTime.Now.Year;
                        detailInfo.ReportMonth = DateTime.Now.Month;
                        detailInfo.YearMonth = DateTime.Now.ToString("yyyy年MM月");
                        detailInfo.DeptName = deptItem.Value;
                        detailInfo.ItemType = itemType.Value;
                        detailInfo.TotalMoney = BLLFactory<ReportMonthlyDetail>.Instance.GetPartMonthlyCost(deptItem.Value, itemType.Value, DateTime.Now.Year, DateTime.Now.Month);
                        //detailInfo.ReportCode = "";//
                        BLLFactory<ReportMonthlyCostDetail>.Instance.Insert(detailInfo);

                        j++;
                    }
                    i++;
                }

                worker.ReportProgress(90);
            }
            #endregion
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.EditValue = e.ProgressPercentage;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ExecuteDeptMonthReport();

            ExecuteEachWareMonthlyReport();

            ExecuteAllWareItemTypeMonthlyReport();

            ExecuteEachPartCostMonthlyReport();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageDxUtil.ShowTips("月结操作顺利完成！");
            this.tool_MonthlyStatistic.Enabled = true;
            this.progressBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        private void tool_MonthlyStatistic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageDxUtil.ShowYesNoAndTips("您是否需要执行月结？\r\n月结可能会比较耗时，任务执行过程中请勿退出。") == DialogResult.Yes)
            {
                if (!worker.IsBusy)
                {
                    this.tool_MonthlyStatistic.Enabled = false;//不能重复月结操作
                    this.progressBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    worker.RunWorkerAsync();//开始任务
                }
            }
        }

        #endregion

        #region 年度结算操作
        private void annualWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.EditValue = e.ProgressPercentage;
        }

        private void annualWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageDxUtil.ShowTips("年度汇总操作顺利完成！");
            this.tool_AnnualStatistic.Enabled = true;
            this.progressBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private ReportAnnualCostHeaderInfo GetAnnualMainHeader()
        {
            ReportAnnualCostHeaderInfo headerInfo = new ReportAnnualCostHeaderInfo();
            headerInfo.CreateDate = DateTime.Now;
            headerInfo.Creator = Portal.gc.UserInfo.FullName;
            headerInfo.ReportYear = DateTime.Now.Year;
            return headerInfo;
        }

        private void ExecuteAnnualCostReport()
        {
            #region 构造全年费用汇总报表
            CListItem[] itemTypeArray = DictItemUtil.GetDictByDictType("备件类别");
            CListItem[] costCenterArray = DictItemUtil.GetDictByDictType("成本中心");
            CListItem[] deptArray = DictItemUtil.GetDictByDictType("部门");
            ReportAnnualCostHeaderInfo annualHeaderInfo = GetAnnualMainHeader();
            annualHeaderInfo.ReportTitle = string.Format("{0}年费用汇总表", DateTime.Now.Year);
            annualHeaderInfo.ReportType = 100;
            int headerID = BLLFactory<ReportAnnualCostHeader>.Instance.InsertOrUpdate(annualHeaderInfo);
            if (headerID > 0)
            {
                annualWorker.ReportProgress(10);

                //先删除当年汇总的数据，防止重复写入
                BLLFactory<ReportAnnualCostDetail>.Instance.DeleteByHeaderID(headerID);
                annualWorker.ReportProgress(20);

                #region 备件类型-成本中心汇总
                //重新写入记录
                int i = 1;
                int j = 1;
                foreach (CListItem itemTypeItem in itemTypeArray)
                {
                    //合计项目
                    ReportAnnualCostDetailInfo totalInfo = new ReportAnnualCostDetailInfo();
                    totalInfo.Header_ID = headerID;
                    totalInfo.ReportYear = DateTime.Now.Year;
                    totalInfo.ItemType = itemTypeItem.Value;
                    totalInfo.CostCenterOrDept = string.Format("{0} 汇总", itemTypeItem.Value);
                    totalInfo.ReportCode = "001";

                    foreach (CListItem costCenterItem in costCenterArray)
                    {
                        #region 十二个月的记录
                        ReportAnnualCostDetailInfo detailInfo = new ReportAnnualCostDetailInfo();
                        detailInfo.Header_ID = headerID;
                        detailInfo.ReportYear = DateTime.Now.Year;
                        detailInfo.ItemType = itemTypeItem.Value;
                        detailInfo.CostCenterOrDept = costCenterItem.Value;
                        detailInfo.One = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeCostCenterSumMoney(itemTypeItem.Value, costCenterItem.Value, DateTime.Now.Year, 1);
                        detailInfo.Two = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeCostCenterSumMoney(itemTypeItem.Value, costCenterItem.Value, DateTime.Now.Year, 2);
                        detailInfo.Three = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeCostCenterSumMoney(itemTypeItem.Value, costCenterItem.Value, DateTime.Now.Year, 3);
                        detailInfo.Four = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeCostCenterSumMoney(itemTypeItem.Value, costCenterItem.Value, DateTime.Now.Year, 4);
                        detailInfo.Five = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeCostCenterSumMoney(itemTypeItem.Value, costCenterItem.Value, DateTime.Now.Year, 5);
                        detailInfo.Six = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeCostCenterSumMoney(itemTypeItem.Value, costCenterItem.Value, DateTime.Now.Year, 6);
                        detailInfo.Seven = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeCostCenterSumMoney(itemTypeItem.Value, costCenterItem.Value, DateTime.Now.Year, 7);
                        detailInfo.Eight = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeCostCenterSumMoney(itemTypeItem.Value, costCenterItem.Value, DateTime.Now.Year, 8);
                        detailInfo.Nine = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeCostCenterSumMoney(itemTypeItem.Value, costCenterItem.Value, DateTime.Now.Year, 9);
                        detailInfo.Ten = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeCostCenterSumMoney(itemTypeItem.Value, costCenterItem.Value, DateTime.Now.Year, 10);
                        detailInfo.Eleven = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeCostCenterSumMoney(itemTypeItem.Value, costCenterItem.Value, DateTime.Now.Year, 11);
                        detailInfo.Twelve = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeCostCenterSumMoney(itemTypeItem.Value, costCenterItem.Value, DateTime.Now.Year, 12);
                        detailInfo.Total = detailInfo.One + detailInfo.Two + detailInfo.Three + detailInfo.Four
                            + detailInfo.Five + detailInfo.Six + detailInfo.Seven + detailInfo.Eight + detailInfo.Nine
                            + detailInfo.Ten + detailInfo.Eleven + detailInfo.Twelve;
                        detailInfo.ReportCode = "001";

                        BLLFactory<ReportAnnualCostDetail>.Instance.Insert(detailInfo);

                        //合计项目的累积
                        totalInfo.One += detailInfo.One;
                        totalInfo.Two += detailInfo.Two;
                        totalInfo.Three += detailInfo.Three;
                        totalInfo.Four += detailInfo.Four;
                        totalInfo.Five += detailInfo.Five;
                        totalInfo.Six += detailInfo.Six;
                        totalInfo.Seven += detailInfo.Seven;
                        totalInfo.Eight += detailInfo.Eight;
                        totalInfo.Nine += detailInfo.Nine;
                        totalInfo.Ten += detailInfo.Ten;
                        totalInfo.Eleven += detailInfo.Eleven;
                        totalInfo.Twelve += detailInfo.Twelve;
                        totalInfo.Total += detailInfo.Total;
                        j++;
                        #endregion
                    }

                    BLLFactory<ReportAnnualCostDetail>.Instance.Insert(totalInfo);
                    i++;
                }
                annualWorker.ReportProgress(50);
                #endregion

                #region 备件类型-部门汇总
                i = 1;
                j = 1;
                foreach (CListItem itemTypeItem in itemTypeArray)
                {
                    //合计项目
                    ReportAnnualCostDetailInfo totalInfo = new ReportAnnualCostDetailInfo();
                    totalInfo.Header_ID = headerID;
                    totalInfo.ReportYear = DateTime.Now.Year;
                    totalInfo.ItemType = itemTypeItem.Value;
                    totalInfo.CostCenterOrDept = string.Format("{0} 汇总", itemTypeItem.Value);
                    totalInfo.ReportCode = "002";

                    foreach (CListItem deptItem in deptArray)
                    {
                        #region 十二个月纪录
                        ReportAnnualCostDetailInfo detailInfo = new ReportAnnualCostDetailInfo();
                        detailInfo.Header_ID = headerID;
                        detailInfo.ReportYear = DateTime.Now.Year;
                        detailInfo.ItemType = itemTypeItem.Value;
                        detailInfo.CostCenterOrDept = deptItem.Value;
                        detailInfo.One = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeDeptSumMoney(itemTypeItem.Value, deptItem.Value, DateTime.Now.Year, 1);
                        detailInfo.Two = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeDeptSumMoney(itemTypeItem.Value, deptItem.Value, DateTime.Now.Year, 2);
                        detailInfo.Three = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeDeptSumMoney(itemTypeItem.Value, deptItem.Value, DateTime.Now.Year, 3);
                        detailInfo.Four = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeDeptSumMoney(itemTypeItem.Value, deptItem.Value, DateTime.Now.Year, 4);
                        detailInfo.Five = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeDeptSumMoney(itemTypeItem.Value, deptItem.Value, DateTime.Now.Year, 5);
                        detailInfo.Six = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeDeptSumMoney(itemTypeItem.Value, deptItem.Value, DateTime.Now.Year, 6);
                        detailInfo.Seven = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeDeptSumMoney(itemTypeItem.Value, deptItem.Value, DateTime.Now.Year, 7);
                        detailInfo.Eight = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeDeptSumMoney(itemTypeItem.Value, deptItem.Value, DateTime.Now.Year, 8);
                        detailInfo.Nine = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeDeptSumMoney(itemTypeItem.Value, deptItem.Value, DateTime.Now.Year, 9);
                        detailInfo.Ten = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeDeptSumMoney(itemTypeItem.Value, deptItem.Value, DateTime.Now.Year, 10);
                        detailInfo.Eleven = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeDeptSumMoney(itemTypeItem.Value, deptItem.Value, DateTime.Now.Year, 11);
                        detailInfo.Twelve = BLLFactory<ReportAnnualCostDetail>.Instance.GetItemTypeDeptSumMoney(itemTypeItem.Value, deptItem.Value, DateTime.Now.Year, 12);
                        detailInfo.Total = detailInfo.One + detailInfo.Two + detailInfo.Three + detailInfo.Four
                            + detailInfo.Five + detailInfo.Six + detailInfo.Seven + detailInfo.Eight + detailInfo.Nine
                            + detailInfo.Ten + detailInfo.Eleven + detailInfo.Twelve;
                        detailInfo.ReportCode = "002";

                        BLLFactory<ReportAnnualCostDetail>.Instance.Insert(detailInfo);

                        //合计项目的累积
                        totalInfo.One += detailInfo.One;
                        totalInfo.Two += detailInfo.Two;
                        totalInfo.Three += detailInfo.Three;
                        totalInfo.Four += detailInfo.Four;
                        totalInfo.Five += detailInfo.Five;
                        totalInfo.Six += detailInfo.Six;
                        totalInfo.Seven += detailInfo.Seven;
                        totalInfo.Eight += detailInfo.Eight;
                        totalInfo.Nine += detailInfo.Nine;
                        totalInfo.Ten += detailInfo.Ten;
                        totalInfo.Eleven += detailInfo.Eleven;
                        totalInfo.Twelve += detailInfo.Twelve;
                        totalInfo.Total += detailInfo.Total;

                        j++;
                        #endregion
                    }

                    BLLFactory<ReportAnnualCostDetail>.Instance.Insert(totalInfo);
                    i++;
                }
                annualWorker.ReportProgress(80);
                #endregion

                #region 特殊部门分月汇总
                i = 1;
                j = 1;

                //合计项目
                ReportAnnualCostDetailInfo totalInfo2 = new ReportAnnualCostDetailInfo();
                totalInfo2.Header_ID = headerID;
                totalInfo2.ReportYear = DateTime.Now.Year;
                totalInfo2.CostCenterOrDept = string.Format("{0} 汇总", "功能性承包");
                totalInfo2.ReportCode = "003";
                foreach (CListItem deptItem in deptArray)
                {
                    #region 十二个月纪录
                    ReportAnnualCostDetailInfo detailInfo = new ReportAnnualCostDetailInfo();
                    detailInfo.Header_ID = headerID;
                    detailInfo.ReportYear = DateTime.Now.Year;
                    detailInfo.ItemType = "";
                    detailInfo.CostCenterOrDept = deptItem.Value;
                    detailInfo.One = BLLFactory<ReportAnnualCostDetail>.Instance.GetDeptSumMoney(deptItem.Value, DateTime.Now.Year, 1);
                    detailInfo.Two = BLLFactory<ReportAnnualCostDetail>.Instance.GetDeptSumMoney(deptItem.Value, DateTime.Now.Year, 2);
                    detailInfo.Three = BLLFactory<ReportAnnualCostDetail>.Instance.GetDeptSumMoney(deptItem.Value, DateTime.Now.Year, 3);
                    detailInfo.Four = BLLFactory<ReportAnnualCostDetail>.Instance.GetDeptSumMoney(deptItem.Value, DateTime.Now.Year, 4);
                    detailInfo.Five = BLLFactory<ReportAnnualCostDetail>.Instance.GetDeptSumMoney(deptItem.Value, DateTime.Now.Year, 5);
                    detailInfo.Six = BLLFactory<ReportAnnualCostDetail>.Instance.GetDeptSumMoney(deptItem.Value, DateTime.Now.Year, 6);
                    detailInfo.Seven = BLLFactory<ReportAnnualCostDetail>.Instance.GetDeptSumMoney(deptItem.Value, DateTime.Now.Year, 7);
                    detailInfo.Eight = BLLFactory<ReportAnnualCostDetail>.Instance.GetDeptSumMoney(deptItem.Value, DateTime.Now.Year, 8);
                    detailInfo.Nine = BLLFactory<ReportAnnualCostDetail>.Instance.GetDeptSumMoney(deptItem.Value, DateTime.Now.Year, 9);
                    detailInfo.Ten = BLLFactory<ReportAnnualCostDetail>.Instance.GetDeptSumMoney(deptItem.Value, DateTime.Now.Year, 10);
                    detailInfo.Eleven = BLLFactory<ReportAnnualCostDetail>.Instance.GetDeptSumMoney(deptItem.Value, DateTime.Now.Year, 11);
                    detailInfo.Twelve = BLLFactory<ReportAnnualCostDetail>.Instance.GetDeptSumMoney(deptItem.Value, DateTime.Now.Year, 12);
                    detailInfo.Total = detailInfo.One + detailInfo.Two + detailInfo.Three + detailInfo.Four
                            + detailInfo.Five + detailInfo.Six + detailInfo.Seven + detailInfo.Eight + detailInfo.Nine
                            + detailInfo.Ten + detailInfo.Eleven + detailInfo.Twelve;
                    detailInfo.ReportCode = "003";

                    BLLFactory<ReportAnnualCostDetail>.Instance.Insert(detailInfo);

                    //合计项目的累积
                    totalInfo2.One += detailInfo.One;
                    totalInfo2.Two += detailInfo.Two;
                    totalInfo2.Three += detailInfo.Three;
                    totalInfo2.Four += detailInfo.Four;
                    totalInfo2.Five += detailInfo.Five;
                    totalInfo2.Six += detailInfo.Six;
                    totalInfo2.Seven += detailInfo.Seven;
                    totalInfo2.Eight += detailInfo.Eight;
                    totalInfo2.Nine += detailInfo.Nine;
                    totalInfo2.Ten += detailInfo.Ten;
                    totalInfo2.Eleven += detailInfo.Eleven;
                    totalInfo2.Twelve += detailInfo.Twelve;
                    totalInfo2.Total += detailInfo.Total;

                    i++;
                    #endregion
                }
                BLLFactory<ReportAnnualCostDetail>.Instance.Insert(totalInfo2);
                #endregion
            }
            #endregion
        }

        private void annualWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ExecuteAnnualCostReport();
        }

        private void tool_AnnualStatistic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageDxUtil.ShowYesNoAndTips("您是否需要执行年度汇总操作？\r\n年度汇总可能会比较耗时，任务执行过程中请勿退出。") == DialogResult.Yes)
            {
                if (!annualWorker.IsBusy)
                {
                    this.tool_AnnualStatistic.Enabled = false;//不能重复操作
                    this.progressBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    annualWorker.RunWorkerAsync();//开始任务
                }
            }
        }

        #endregion

        private void btnRelogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageDxUtil.ShowYesNoAndWarning("您确定需要重新登录吗？") != DialogResult.Yes)
                return;


            Portal.gc.MainDialog.Hide();

            Logon dlg = new Logon();
            dlg.StartPosition = FormStartPosition.CenterScreen;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                if (dlg.bLogin)
                {
                    CloseAllDocuments();
                    InitUserRelated();
                }

            }
            dlg.Dispose();
            Portal.gc.MainDialog.Show();
        }

        private void btnFeeBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //使用QQ开放平台的发邮件界面
            string mailUrl = string.Format("http://mail.qq.com/cgi-bin/qm_share?t=qm_mailme&email=S31yfX15fn8LOjplKCQm");
            Process.Start(mailUrl);
        }

        private void tool_Customer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildWinManagement.LoadMdiForm(this, typeof(WHC.TestProject.UI.FrmCustomer));
        }


    }
}
