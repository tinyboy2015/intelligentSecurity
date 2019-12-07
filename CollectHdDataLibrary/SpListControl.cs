using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectHdDataLib
{
    public class SpListControl
    {
        private static List<SerialPortInput> listSerialPorts;
        public SpListControl()
        {
            listSerialPorts = new List<SerialPortInput>();
            foreach (spinfo si in SpToAreaTbl.listSp)
            {
                if(si._type == SerialCommuType.Alarm)
                {
                    SpAreaAlarm spa = new SpAreaAlarm(si._spName);
                    listSerialPorts.Add(spa);
                }
                else if(si._type == SerialCommuType.Wave)
                {
                    SpWaveView spw = new SpWaveView(si._spName);
                    listSerialPorts.Add(spw);
                }
            }
        }
        public void ConnectAll()
        {
            foreach (SerialPortInput sp in listSerialPorts)
            {
                sp.Connect();
            }
        }
        public void DisconnectAll()
        {
            foreach (SerialPortInput sp in listSerialPorts)
            {
                sp.Disconnect();
            }
        }
    }
}
