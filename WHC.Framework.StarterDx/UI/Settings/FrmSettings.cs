using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WHC.Framework.BaseUI;

namespace WHC.Framework.Starter
{
    public partial class FrmSettings : BaseForm
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            this.firefoxDialog1.ImageList = this.imageList1;

            //this.firefoxDialog1.AddPage("报表设置", new PageReport());//基于本地文件的参数存储
            //this.firefoxDialog1.AddPage("邮箱设置", new PageEmail());//基于数据库的参数存储

            //下面是陪衬的
            this.firefoxDialog1.AddPage("车卡串口设置",4, new SerialPort("Card"));
            this.firefoxDialog1.AddPage("衡器串口设置",4, new SerialPort("Balance"));
            this.firefoxDialog1.AddPage("Led串口设置", 4,new  SerialPort("Led"));
            this.firefoxDialog1.AddPage("前摄像头设置",5, new Camera("Front"));
            this.firefoxDialog1.AddPage("后摄像头设置",6, new Camera("Rear"));

           
            this.firefoxDialog1.Init();
        }
    }
}
