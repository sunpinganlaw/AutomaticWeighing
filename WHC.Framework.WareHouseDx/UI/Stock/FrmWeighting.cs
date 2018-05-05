using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WHC.Pager.Entity;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using WHC.WareHouseMis.BLL;
using WHC.WareHouseMis.Entity;
using WHC.Dictionary;
using WHC.Framework.BaseUI;
using DevExpress.XtraPrinting;
using SettingsProviderNet;
using WHC.Security.UI;

namespace WHC.WareHouseMis.UI
{
    public partial class FrmWeighting : WHC.Framework.BaseUI.BaseDock
    {
        
        public FrmWeighting()
        {

            
            InitializeComponent();
            //pictureFrontDoor.Image = WHC.WareHouseMis.UI.Properties.Resources.UP;
            //pictureFrontLed.Image = WHC.WareHouseMis.UI.Properties.Resources.RL;
            //pictureRearInfrared1.Image = WHC.WareHouseMis.UI.Properties.Resources.red;
        
        }

        private void FrmWeighting_Enter(object sender, EventArgs e)
        {
           textContrlState.Text= (string)Cache.Instance["WeightModel"];
          
        }

        



    }
}