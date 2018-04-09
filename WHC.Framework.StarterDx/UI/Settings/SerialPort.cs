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
    public partial class SerialPort : PropertyPage
    {
        private SettingsProvider settings;
        private ISettingsStorage store;
        private String Type="";

        public SerialPort()
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


        public SerialPort(string type)
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
           
            if(this.Type=="Card")
            {
                CardSerialPortParameter parameter = settings.GetSettings<CardSerialPortParameter>();

                if (parameter != null)
                {

                    this.txtComName.Text = parameter.PortName.ToString();
                    this.txtBoaud.Text = parameter.BaudRate.ToString();
                    this.txtDataBits.Text = parameter.DataBits.ToString();
                    this.txtCheckBits.Text = parameter.CheckBits.ToString();
                    this.txtStopBits.Text = parameter.StopBits.ToString();
                }

            }else if (this.Type == "Balance")
            {
                BalanceSerialPortParameter parameter = settings.GetSettings<BalanceSerialPortParameter>();
                if (parameter != null)
                {

                    this.txtComName.Text = parameter.PortName.ToString();
                    this.txtBoaud.Text = parameter.BaudRate.ToString();
                    this.txtDataBits.Text = parameter.DataBits.ToString();
                    this.txtCheckBits.Text = parameter.CheckBits.ToString();
                    this.txtStopBits.Text = parameter.StopBits.ToString();
                }

            }else if(this.Type=="Led")
            {

                LedSerialPortParameter parameter = settings.GetSettings<LedSerialPortParameter>();
                if (parameter != null)
                {

                    this.txtComName.Text = parameter.PortName.ToString();
                    this.txtBoaud.Text = parameter.BaudRate.ToString();
                    this.txtDataBits.Text = parameter.DataBits.ToString();
                    this.txtCheckBits.Text = parameter.CheckBits.ToString();
                    this.txtStopBits.Text = parameter.StopBits.ToString();
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
                 if(this.Type=="Card")
                 {

                     CardSerialPortParameter parameter = settings.GetSettings<CardSerialPortParameter>();
                     if (parameter != null)
                     {
                         parameter.PortName = this.txtComName.Text;
                         parameter.DataBits = Convert.ToInt32(this.txtDataBits.Text);
                         parameter.BaudRate = this.txtBoaud.Text;
                         parameter.StopBits = Convert.ToInt32(this.txtStopBits.Text);
                         parameter.CheckBits = Convert.ToInt32(this.txtCheckBits.Text);

                         settings.SaveSettings<CardSerialPortParameter>(parameter);
                     }
                 }else if(this.Type=="Balance")
                 {
                     BalanceSerialPortParameter parameter = settings.GetSettings<BalanceSerialPortParameter>();
                     if (parameter != null)
                     {
                         parameter.PortName = this.txtComName.Text;
                         parameter.DataBits = Convert.ToInt32(this.txtDataBits.Text);
                         parameter.BaudRate = this.txtBoaud.Text;
                         parameter.StopBits = Convert.ToInt32(this.txtStopBits.Text);
                         parameter.CheckBits = Convert.ToInt32(this.txtCheckBits.Text);

                         settings.SaveSettings<BalanceSerialPortParameter>(parameter);
                     }


                 }else if(this.Type=="Led")
                 {
                     LedSerialPortParameter parameter = settings.GetSettings<LedSerialPortParameter>();
                     if (parameter != null)
                     {
                         parameter.PortName = this.txtComName.Text;
                         parameter.DataBits = Convert.ToInt32(this.txtDataBits.Text);
                         parameter.BaudRate = this.txtBoaud.Text;
                         parameter.StopBits = Convert.ToInt32(this.txtStopBits.Text);
                         parameter.CheckBits = Convert.ToInt32(this.txtCheckBits.Text);

                         settings.SaveSettings<LedSerialPortParameter>(parameter);
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
