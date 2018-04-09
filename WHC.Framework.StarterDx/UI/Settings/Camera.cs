using System;
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


namespace WHC.Framework.Starter
{
    public partial class Camera : PropertyPage
    {
        private SettingsProvider settings;
        private ISettingsStorage store;
        private String Type="";

        public Camera()
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                //DatabaseStorage：在数据库里面，以指定用户标识保存参数数据
                string creator = Portal.gc.LoginUserInfo.Name;
                store = new DatabaseStorage(creator);
                settings = new SettingsProvider(store);
            }
        }


        public Camera(string type)
        {
            InitializeComponent();
            this.Type = type;
            if (!this.DesignMode)
            {
                //DatabaseStorage：在数据库里面，以指定用户标识保存参数数据
                string creator = Portal.gc.LoginUserInfo.Name;
                store = new DatabaseStorage(creator);
                settings = new SettingsProvider(store);
            }
        }
        public override void OnInit()
        {
           
            if(this.Type=="Front")
            {
                FrontCameraParameter parameter = settings.GetSettings<FrontCameraParameter>();

                if (parameter != null)
                {
                    this.txtIP.Text = parameter.IP;
                    this.txtPort.Text = parameter.Port.ToString();
                    this.txtPicPath.Text = parameter.SavePath;
                    this.txtUser.Text = parameter.User;
                    this.txtPass.Text = parameter.Pass;
                 
                }

            }else if (this.Type == "Rear")
            {
                RearCameraParameter parameter = settings.GetSettings<RearCameraParameter>();
                if (parameter != null)
                {
                    this.txtIP.Text = parameter.IP;
                    this.txtPort.Text = parameter.Port.ToString();
                    this.txtPicPath.Text = parameter.SavePath;
                    this.txtUser.Text = parameter.User;
                    this.txtPass.Text = parameter.Pass;
                   
                }

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
                 if(this.Type=="Front")
                 {

                     FrontCameraParameter parameter = settings.GetSettings<FrontCameraParameter>();
                     if (parameter != null)
                     {
                         parameter.SavePath = this.txtPicPath.Text;
                         parameter.IP = this.txtIP.Text;
                         parameter.Port = Convert.ToInt32(this.txtPort.Text);
                         parameter.User = this.txtUser.Text;
                         parameter.Pass = this.txtPass.Text;


                         settings.SaveSettings<FrontCameraParameter>(parameter);
                     }
                 }else if(this.Type=="Rear")
                 {
                     RearCameraParameter parameter = settings.GetSettings<RearCameraParameter>();
                     if (parameter != null)
                     {
                         parameter.SavePath = this.txtPicPath.Text;
                         parameter.IP = this.txtIP.Text;
                         parameter.Port = Convert.ToInt32(this.txtPort.Text);
                         parameter.User = this.txtUser.Text;
                         parameter.Pass = this.txtPass.Text;

                         settings.SaveSettings<RearCameraParameter>(parameter);
                     }


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
