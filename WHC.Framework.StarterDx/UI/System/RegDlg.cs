using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using WHC.Framework.BaseUI;

namespace WHC.Framework.Starter
{
    /// <summary>
    /// RegDlg ��ժҪ˵����
    /// </summary>
    public class RegDlg : BaseForm
    {
        public Label label1;
        private TextBox tbMachineCode;
        private Label label2;
        private TextBox tbSerialNumber;
        private Label label3;
        private Container components = null;
        private LinkLabel linkLabel1;
        private Label label4;
        private DevExpress.XtraEditors.SimpleButton btRegister;
        private DevExpress.XtraEditors.SimpleButton btnCopy;

        private static RegDlg instance;

        public static RegDlg Instance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new RegDlg();
            return instance;
        }

        protected RegDlg()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegDlg));
            this.label1 = new System.Windows.Forms.Label();
            this.tbMachineCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btRegister = new DevExpress.XtraEditors.SimpleButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("����", 9F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(547, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "�������Ļ����룬��ʹ��������ʼ���ַ����ϵ���߻�ȡ��ȷ�����к�";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbMachineCode
            // 
            this.tbMachineCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMachineCode.Location = new System.Drawing.Point(104, 93);
            this.tbMachineCode.Name = "tbMachineCode";
            this.tbMachineCode.ReadOnly = true;
            this.tbMachineCode.Size = new System.Drawing.Size(419, 22);
            this.tbMachineCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(8, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "�����룺";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSerialNumber.Location = new System.Drawing.Point(104, 144);
            this.tbSerialNumber.MinimumSize = new System.Drawing.Size(286, 100);
            this.tbSerialNumber.Multiline = true;
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSerialNumber.Size = new System.Drawing.Size(481, 107);
            this.tbSerialNumber.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(8, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "���кţ�";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btRegister
            // 
            this.btRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRegister.Location = new System.Drawing.Point(489, 267);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(96, 25);
            this.btRegister.TabIndex = 2;
            this.btRegister.Text = "ע��";
            this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Bold);
            this.linkLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(0, 21);
            this.linkLabel1.Location = new System.Drawing.Point(101, 312);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(230, 26);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "wuhuacong@163.com";
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(24, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "�������䣺";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(530, 93);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(55, 24);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "����";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // RegDlg
            // 
            this.ClientSize = new System.Drawing.Size(606, 350);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btRegister);
            this.Controls.Add(this.tbMachineCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSerialNumber);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(419, 377);
            this.Name = "RegDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ע��";
            this.Load += new System.EventHandler(this.RegDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void btRegister_Click(object sender, EventArgs e)
        {
            bool passed = Portal.gc.Register(tbSerialNumber.Text);
            if (passed)
            {
                Portal.gc.Registed = true;

                SaverInformationToRegedit(tbSerialNumber.Text);
                MessageDxUtil.ShowTips("ף������ע��ɹ�");
                Close();
                Application.Exit();
            }
            else
            {
                MessageDxUtil.ShowWarning("�Բ���ע��ʧ��");
            }
        }

        /// <summary>
        /// �����û���������кŵ�ע�����
        /// </summary>
        /// <param name="mySerail"></param>
        private void SaverInformationToRegedit(string mySerail)
        {
            RegistryKey reg;
            string regkey = UIConstants.SoftwareRegistryKey;
            reg = Registry.CurrentUser.OpenSubKey(regkey, true);
            if (null == reg)
            {
                reg = Registry.CurrentUser.CreateSubKey(regkey);
            }
            if (null != reg)
            {
                reg.SetValue("productName", UIConstants.SoftwareProductName);
                reg.SetValue("version", UIConstants.SoftwareVersion);
                reg.SetValue("SerialNumber", mySerail);
            }
        }

        private void RegDlg_Load(object sender, EventArgs e)
        {
            tbMachineCode.Text = Portal.gc.GetHardNumber();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception)
            {
                MessageBox.Show("���ܴ����ӣ�");
            }
        }

        private void VisitLink()
        {
            linkLabel1.LinkVisited = true;
            Process.Start("mailto:" + "wuhuacong@163.com");
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.tbMachineCode.Text);
        }
    }
}