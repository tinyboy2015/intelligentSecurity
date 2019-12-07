using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CollectHdDataLib
{
    public class SpWaveView : SerialPortInput
    {
        private int _defaultBaudRate = 115200;
        public SpWaveView(string portName)
        {
            SetPortBase(portName, _defaultBaudRate);
            MessageReceived += SerialPort_MessageReceived;
        }

        void SerialPort_MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            Console.WriteLine("Received message: {0}", BitConverter.ToString(args.Data));
        }
    }
}
