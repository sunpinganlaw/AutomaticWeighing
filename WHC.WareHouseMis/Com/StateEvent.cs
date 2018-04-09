using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHC.Framework.Commons;

namespace WHC.WareHouseMis.Com
{
    public class StateEvent
    {
        public string data;
        public SerialPortUtil serialPortUtil;
        public EasyModbus.ModbusClient modbusClient;
        public StateMachine stateMachine;

        public override string ToString()
        {


            return data;

        }

      

    }
}
