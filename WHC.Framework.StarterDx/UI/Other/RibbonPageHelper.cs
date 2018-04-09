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
    /// ��̬����RibbonPage��������İ�ť��Ŀ������
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
            //Լ���˵�����3������һ��Ϊ�����𣬵ڶ���ΪСģ����飬������Ϊ����Ĳ˵�
            List<MenuNodeInfo> menuList = BLLFactory<SysMenu>.Instance.GetTree(Portal.gc.SystemType);
            if (menuList.Count == 0) return;

            int i = 0;
            foreach(MenuNodeInfo firstInfo in menuList)
            {
                //���û�в˵���Ȩ�ޣ�������
                if (!Portal.gc.HasFunction(firstInfo.FunctionId)) continue;

                //���ҳ�棨һ���˵���
                RibbonPage page = new DevExpress.XtraBars.Ribbon.RibbonPage();
                page.Text = firstInfo.Name;
                page.Name = firstInfo.ID;
                this.control.Pages.Insert(i++, page);
                
                if(firstInfo.Children.Count == 0) continue;
                foreach(MenuNodeInfo secondInfo in firstInfo.Children)
                {
                    //���û�в˵���Ȩ�ޣ�������
                    if (!Portal.gc.HasFunction(secondInfo.FunctionId)) continue;

                    //���RibbonPageGroup�������˵���
                    RibbonPageGroup group = new RibbonPageGroup();
                    group.Text = secondInfo.Name;
                    group.Name = secondInfo.ID;
                    page.Groups.Add(group);                

                    if(secondInfo.Children.Count == 0) continue;
                    foreach (MenuNodeInfo thirdInfo in secondInfo.Children)
                    {
                        //���û�в˵���Ȩ�ޣ�������
                        if (!Portal.gc.HasFunction(thirdInfo.FunctionId)) continue;

                        //��ӹ��ܰ�ť�������˵���
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
        /// ����ͼ�꣬������ز��ɹ�����ôʹ��Ĭ��ͼ��
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
                LogTextHelper.Error(string.Format("�޷�ʶ��ͼ���ַ��{0}����ȷ�����ļ����ڣ�", iconPath));
            }

            return result;
        }

        /// <summary>
        /// ���ز������
        /// </summary>
        private void LoadPlugInForm(string typeName)
        {
            try
            {
                string[] itemArray = typeName.Split(new char[]{',',';'});

                string type = itemArray[0].Trim();
                string filePath = itemArray[1].Trim();//���������·��

                //�ж��Ƿ���������ʾģʽ��Ĭ�ϴ���ΪShow��ģʽ��ʾ
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
                LogTextHelper.Error(string.Format("����ģ�顾{0}��ʧ�ܣ�������д�Ƿ���ȷ��", typeName), ex);
            }
        }

        /// <summary>
        /// Ψһ����ĳ�����͵Ĵ��壬�����������ʾ�����򴴽���
        /// </summary>
        /// <param name="mainDialog">���������</param>
        /// <param name="formType">����ʾ�Ĵ�������</param>
        /// <returns></returns>
        public static Form LoadMdiForm(Form mainDialog, Type formType, bool isShowDialog)
        {
            Form tableForm = null;
            bool bFound = false;
            if (!isShowDialog) //�����ģ̬���ڣ�����
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

            //û���ڶ��ĵ����ҵ�������ģ̬���ڣ���Ҫ��ʼ������
            if (!bFound || isShowDialog)
            {
                tableForm = (Form)Activator.CreateInstance(formType);

                //������弯����IFunction�ӿ�(��һ�δ�����Ҫ����)
                IFunction function = tableForm as IFunction;
                if (function != null)
                {
                    //��ʼ��Ȩ�޿�����Ϣ
                    function.InitFunction(Portal.gc.LoginUserInfo, Portal.gc.FunctionDict);

                    //��¼����������Ϣ
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
