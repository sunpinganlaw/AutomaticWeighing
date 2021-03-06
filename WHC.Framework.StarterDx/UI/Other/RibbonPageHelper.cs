using System;
using System.Text;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

using WHC.Framework.BaseUI;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using MenuNodeInfo = WHC.Security.Entity.MenuNodeInfo;
using SysMenu = WHC.Security.BLL.Menu;

namespace WHC.Framework.Starter
{
    /// <summary>
    /// 动态创建RibbonPage和其下面的按钮项目辅助类
    /// </summary>
    public class RibbonPageHelper
    {
        private RibbonControl control;
        public MainForm mainForm;

        public RibbonPageHelper(MainForm mainForm, ref RibbonControl control)
        {
            this.mainForm = mainForm;
            this.control = control;
        }

        public void AddPages()
        {
            //约定菜单共有3级，第一级为大的类别，第二级为小模块分组，第三级为具体的菜单
            List<MenuNodeInfo> menuList = BLLFactory<SysMenu>.Instance.GetTree(Portal.gc.SystemType);
            if (menuList.Count == 0) return;

            int i = 0;
            foreach(MenuNodeInfo firstInfo in menuList)
            {
                //如果没有菜单的权限，则跳过
                if (!Portal.gc.HasFunction(firstInfo.FunctionId)) continue;

                //添加页面（一级菜单）
                RibbonPage page = new DevExpress.XtraBars.Ribbon.RibbonPage();
                page.Text = firstInfo.Name;
                page.Name = firstInfo.ID;
                this.control.Pages.Insert(i++, page);
                
                if(firstInfo.Children.Count == 0) continue;
                foreach(MenuNodeInfo secondInfo in firstInfo.Children)
                {
                    //如果没有菜单的权限，则跳过
                    if (!Portal.gc.HasFunction(secondInfo.FunctionId)) continue;

                    //添加RibbonPageGroup（二级菜单）
                    RibbonPageGroup group = new RibbonPageGroup();
                    group.Text = secondInfo.Name;
                    group.Name = secondInfo.ID;
                    page.Groups.Add(group);                

                    if(secondInfo.Children.Count == 0) continue;
                    foreach (MenuNodeInfo thirdInfo in secondInfo.Children)
                    {
                        //如果没有菜单的权限，则跳过
                        if (!Portal.gc.HasFunction(thirdInfo.FunctionId)) continue;

                        //添加功能按钮（三级菜单）
                        BarButtonItem button = new BarButtonItem();
                        button.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                        button.LargeGlyph = LoadIcon(thirdInfo.Icon);
                        button.Glyph = LoadIcon(thirdInfo.Icon);

                        button.Name = thirdInfo.ID;
                        button.Caption = thirdInfo.Name;
                        button.Tag = thirdInfo.WinformType;
                        button.ItemClick += (sender, e) =>
                        {
                            if (button.Tag != null && !string.IsNullOrEmpty(button.Tag.ToString()))
                            {
                                LoadPlugInForm(button.Tag.ToString());
                            }
                            else
                            {
                                MessageDxUtil.ShowTips(button.Caption);
                            }
                        };
                        group.ItemLinks.Add(button);
                    }
                }
            }
        }

        /// <summary>
        /// 加载图标，如果加载不成功，那么使用默认图标
        /// </summary>
        /// <param name="iconPath"></param>
        /// <returns></returns>
        private Image LoadIcon(string iconPath)
        {
            Image result = WHC.Framework.Starter.Properties.Resources.menuIcon.ToBitmap();
            try
            {
                if (!string.IsNullOrEmpty(iconPath))
                {
                    string path = Path.Combine(Application.StartupPath, iconPath);
                    if (File.Exists(path))
                    {
                        result = Image.FromFile(path);
                    }
                }
            }
            catch
            {
                LogTextHelper.Error(string.Format("无法识别图标地址：{0}，请确保该文件存在！", iconPath));
            }

            return result;
        }

        /// <summary>
        /// 加载插件窗体
        /// </summary>
        private void LoadPlugInForm(string typeName)
        {
            try
            {
                string[] itemArray = typeName.Split(new char[]{',',';'});

                string type = itemArray[0].Trim();
                string filePath = itemArray[1].Trim();//必须是相对路径

                //判断是否配置了显示模式，默认窗体为Show非模式显示
                string showDialog = (itemArray.Length > 2) ? itemArray[2].ToLower() : "";
                bool isShowDialog = (showDialog == "1") || (showDialog == "dialog");

                string dllFullPath = Path.Combine(Application.StartupPath, filePath);
                Assembly tempAssembly = System.Reflection.Assembly.LoadFrom(dllFullPath);
                if (tempAssembly != null)
                {
                    Type objType = tempAssembly.GetType(type);
                    if (objType != null)
                    {
                        LoadMdiForm(this.mainForm, objType, isShowDialog);    
                    }
                }
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(string.Format("加载模块【{0}】失败，请检查书写是否正确。", typeName), ex);
            }
        }

        /// <summary>
        /// 唯一加载某个类型的窗体，如果存在则显示，否则创建。
        /// </summary>
        /// <param name="mainDialog">主窗体对象</param>
        /// <param name="formType">待显示的窗体类型</param>
        /// <returns></returns>
        public static Form LoadMdiForm(Form mainDialog, Type formType, bool isShowDialog)
        {
            Form tableForm = null;
            bool bFound = false;
            if (!isShowDialog) //如果是模态窗口，跳过
            {
                foreach (Form form in mainDialog.MdiChildren)
                {
                    if (form.GetType() == formType)
                    {
                        bFound = true;
                        tableForm = form;
                        break;
                    }
                }
            }

            //没有在多文档中找到或者是模态窗口，需要初始化属性
            if (!bFound || isShowDialog)
            {
                tableForm = (Form)Activator.CreateInstance(formType);

                //如果窗体集成了IFunction接口(第一次创建需要设置)
                IFunction function = tableForm as IFunction;
                if (function != null)
                {
                    //初始化权限控制信息
                    function.InitFunction(Portal.gc.LoginUserInfo, Portal.gc.FunctionDict);

                    //记录程序的相关信息
                    function.AppInfo = new AppInfo(Portal.gc.AppUnit, Portal.gc.AppName, Portal.gc.AppWholeName, Portal.gc.SystemType);
                }

            }

            if (isShowDialog)
            {
                tableForm.ShowDialog();
            }
            else
            {
                tableForm.MdiParent = mainDialog;
                tableForm.Show();
            }
            tableForm.BringToFront();
            tableForm.Activate();

            return tableForm;
        }
    }
}
