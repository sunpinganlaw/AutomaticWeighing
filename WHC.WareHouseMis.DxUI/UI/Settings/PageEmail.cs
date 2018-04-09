﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WHC.Framework.BaseUI.Settings;
using SettingsProviderNet;
using WHC.Framework.Commons;
using WHC.Framework.BaseUI;

namespace WHC.WareHouseMis.UI.Settings
{
    public partial class PageEmail : PropertyPage
    {
        private SettingsProvider settings;
        private ISettingsStorage store;

        public PageEmail()
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                //DatabaseStorage：在数据库里面，以指定用户标识保存参数数据
                string creator = LoginUserInfo.Name;
                store = new DatabaseStorage(creator);
                settings = new SettingsProvider(store);
            }
        }

        public override void OnInit()
        {
            EmailParameter parameter = settings.GetSettings<EmailParameter>();
            if (parameter != null)
            {
                this.txtEmail.Text = parameter.Email;
                this.txtLoginId.Text = parameter.LoginId;
                this.txtPassword.Text = parameter.Password;
                this.txtPassword.Tag = parameter.Password;
                this.txtPop3Port.Value = parameter.Pop3Port;
                this.txtPop3Server.Text = parameter.Pop3Server;
                this.txtSmtpPort.Value = parameter.SmtpPort;
                this.txtSmtpServer.Text = parameter.SmtpServer;
                this.txtUseSSL.Checked = parameter.UseSSL;
            }
        }

        public override void OnSetActive()
        {
        }

        public override bool OnApply()
        {
            bool result = false;
            try
            {
                //如果密码修改，需要确认密码
                if (this.txtPassword.Tag != null && this.txtPassword.Tag.ToString() != this.txtPassword.Text)
                {
                    string confirmPassword = MessageDxUtil.QueryInputStr("请确认密码", "", true);
                    if (confirmPassword != this.txtPassword.Text)
                    {
                        MessageDxUtil.ShowTips("两次密码输入不一致");
                        this.txtPassword.Focus();
                        return result;
                    }
                }

                EmailParameter parameter = settings.GetSettings<EmailParameter>();
                if (parameter != null)
                {                    
                    parameter.Email = this.txtEmail.Text;
                    parameter.LoginId = this.txtLoginId.Text;
                    parameter.Password = this.txtPassword.Text;
                    parameter.Pop3Port = Convert.ToInt32(this.txtPop3Port.Value);
                    parameter.Pop3Server = this.txtPop3Server.Text;
                    parameter.SmtpPort = Convert.ToInt32(this.txtSmtpPort.Value);
                    parameter.SmtpServer = this.txtSmtpServer.Text;
                    parameter.UseSSL = this.txtUseSSL.Checked;

                    settings.SaveSettings<EmailParameter>(parameter);
                }
                result = true;
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }

            return result;
        }
    }
}
