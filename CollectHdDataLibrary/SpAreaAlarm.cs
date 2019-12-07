using DatabaseOpClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CollectHdDataLib
{
    public class SpAreaAlarm : SerialPortInput
    {
        private string remoteIp = "";
        private int port;
        private int _defaultBaudRate = 115200;
        private List<TransferData> listTd;
        private DataBase dbop = new DataBase();
        public SpAreaAlarm(string portName)
        {
            SetPortBase(portName, _defaultBaudRate);
            remoteIp = "127.0.0.1";
            port = 3001;
            listTd = new List<TransferData>();
            MessageReceived += SerialPort_MessageReceived;
        }
        void SerialPort_MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            Console.WriteLine("Received message: {0}", BitConverter.ToString(args.Data));
            byte[] d = args.Data;
            string areaNo;
            for (int i = 0; i < d.Length; i++)
            {
                //入侵消息
                if (d[i] > 0 && d[i] < 9)
                {
                    areaNo = SpToAreaTbl.dicSptoArea[string.Format("{0}_{1}", PortName, d[i])];
                    listTd.Add(new TransferData(dbop,areaNo, AlarmType.Intrusion, ""));
                }
                //断缆消息
                if (d[i] > 0xF0 && d[i] < 0xF9)
                {
                    areaNo = SpToAreaTbl.dicSptoArea[string.Format("{0}_{1}", PortName, d[i] - 0xF0)];
                    listTd.Add(new TransferData(dbop,areaNo, AlarmType.Broken, ""));
                }
            }
            string jsonData = JsonConvert.SerializeObject(listTd);
            //List<TransferData> listTd2 = JsonConvert.DeserializeObject<List<TransferData>>(jsonData);
            tcpSendAlamInfo(Encoding.ASCII.GetBytes(jsonData));
            listTd.Clear();

        }

        private void tcpSendAlamInfo(Byte[] sendBytes)
        {
            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(remoteIp, port);
                NetworkStream stream = tcpClient.GetStream();
                stream.Write(sendBytes, 0, sendBytes.Length);
                tcpClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }

        }
    }
}
