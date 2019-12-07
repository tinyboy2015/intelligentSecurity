using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using Taih.MessageBus;

namespace SendTransportService
{   
    public class ServerSocket
    {
        private bool _isEnabled = false;
        private TcpServerHelper tcpHelper = null;
        DataTable dt = new DataTable();
        private Hashtable SocketIPTable = new Hashtable();
        private TransportServiceMainTran trans = new TransportServiceMainTran();
        private object receiveLock = new object(); //添加锁对象，防止多线程同时添加对象。  

        public void Open()
        {          
            if (!_isEnabled)
            {
                if (tcpHelper != null)
                {
                    tcpHelper.OnReceive -= new TcpServerHelper.OnReceiveEvent(tcpHelper_OnReceive);
                    tcpHelper.OnConnectSuccess -= new TcpServerHelper.OnConnectSuccessEvent(tcpHelper_OnConnectSuccess);
                    tcpHelper.OnCloseConnection -= new TcpServerHelper.OnCloseConnectionEvent(tcpHelper_OnCloseConnection);
                    tcpHelper.Close();
                    Thread.Sleep(100);
                    tcpHelper = null;
                }
                Message heartMessage = new Message(10);
                heartMessage.SetInt32("CmdType", (int)CmdSocketType.HEARTBEAT);
                byte[] data = trans.Encode2Bytes(heartMessage);
                tcpHelper = new TcpServerHelper(3001, 3, data);   //3001 端口
                tcpHelper.OnReceive += new TcpServerHelper.OnReceiveEvent(tcpHelper_OnReceive);
                tcpHelper.OnConnectSuccess += new TcpServerHelper.OnConnectSuccessEvent(tcpHelper_OnConnectSuccess);
                tcpHelper.OnCloseConnection += new TcpServerHelper.OnCloseConnectionEvent(tcpHelper_OnCloseConnection);
                _isEnabled = tcpHelper.Open();

                //				if(_isEnabled)
                //					StartSend();
            }
        }


        private void tcpHelper_OnReceive(SocketEntity entity, byte[] bytes, int length)
        {
            lock (receiveLock)
            {
                Message[] msgs = trans.Decode(bytes, 0, length);
                foreach (Message msg in msgs)
                {
                    if (msg.GetByte("CmdType") == CmdSocketType.ANSWER_HEARTBEAT)
                    {
                        Message heartMsg = new Message(100);

                        heartMsg.SetInt32("param", (int)CmdSocketType.ANSWER_HEARTBEAT);
                        heartMsg.SetInt32("CmdType", (int)CmdSocketType.ANSWER_HEARTBEAT);

                        this.SendInfoMessage(heartMsg);
                    }
                }
            }
        }

        private void tcpHelper_OnConnectSuccess(SocketEntity entity)
        {

            if (!SocketIPTable.ContainsKey(entity.IP))
            {
                SocketIPTable.Add(entity.IP, entity);
            }
            else
            {
                SocketIPTable[entity.IP] = entity;
            }
        }

        private void tcpHelper_OnCloseConnection(SocketEntity entity)
        {
            if (SocketIPTable.ContainsKey(entity.IP))
            {
                SocketIPTable.Remove(entity.IP);
            }

            SendWarnMessage();
        }


        /// <summary>
		/// 发送信息
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		private bool SendInfoMessage(Message message)
        {
            if (SocketIPTable.ContainsKey(message.GetString("IP").ToString()))
            {
                byte[] data = trans.Encode2Bytes(message);
                foreach (SocketEntity entity in SocketIPTable.Values)
                {
                    if (entity.IP == message.GetString("IP").ToString())
                    {
                        //("向IP" + message.GetString("IP").ToString() + "发送消息");
                        entity.Socket.Send(data, 0, data.Length, System.Net.Sockets.SocketFlags.None);
                        return true;
                    }
                }

            }
            return false;

        }

        //断开报警
        private void SendWarnMessage()
        {
           
        }
    }


   
}
