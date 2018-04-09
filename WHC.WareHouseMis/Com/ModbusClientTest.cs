using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyModbus;

namespace WHC.WareHouseMis.Com
{
    public  class ModbusClientTest
    {
       


        EasyModbus.ModbusClient seww = new EasyModbus.ModbusClient("127.0.0.1", 501);
       
         
         private void setText()
        {
              seww.Connect();
              seww.receiveDataChanged += new ModbusClient.ReceiveDataChanged(get);


             
        }


          private  void get(object  d)
         {


         }

    }
}
