using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WHC.Framework.BaseUI.Settings;
using WHC.Framework.Commons;
using WHC.Framework.BaseUI;
using SettingsProviderNet;

namespace WHC.WareHouseMis.UI.Settings
{
    public partial class PageGlobal : PropertyPage
    {
        private SettingsProvider settings;
        private ISettingsStorage store;

        public PageGlobal()
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                //DatabaseStorage：在数据库里面，以指定用户标识保存参数数据
                string creator = null;// Portal.gc.LoginUserInfo.Name;
                store = new DatabaseStorage(creator);
                settings = new SettingsProvider(store);
            }
        }

        public override void OnInit()
        {
            GlobalParameter parameter = settings.GetSettings<GlobalParameter>();
            if (parameter != null)
            {
                this.chkAllowEnterCardNo.Checked = parameter.AllowEnterCardNo;
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
                GlobalParameter parameter = settings.GetSettings<GlobalParameter>();
                if (parameter != null)
                {
                    parameter.AllowEnterCardNo = this.chkAllowEnterCardNo.Checked;

                    settings.SaveSettings<GlobalParameter>(parameter);
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
