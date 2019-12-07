using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace SendTransportService
{
    public class SocketEntity
    {

        private string _ip;
        private int _port;
        private Socket _socket;
        private DateTime _firstConnectTime;
        private DateTime _lastConnectTime = DateTime.MinValue;
        private DateTime _lastReceiveTime = DateTime.MinValue;
        private bool _isActived;

        private int _chargeNo;

        public int Port
        {
            get { return this._port; }
            set { this._port = value; }
        }

        public string IP
        {
            get { return this._ip; }
            set { this._ip = value; }
        }

        public Socket Socket
        {
            get { return this._socket; }
            set { this._socket = value; }
        }

        public DateTime FirstConnectTime
        {
            get { return this._firstConnectTime; }
            set { this._firstConnectTime = value; }
        }

        public DateTime LastConnectTime
        {
            get { return this._lastConnectTime; }
            set { this._lastConnectTime = value; }
        }

        public DateTime LastReceiveTime
        {
            get { return this._lastReceiveTime; }
            set { this._lastReceiveTime = value; }
        }

        public bool IsActived
        {
            get { return this._isActived; }
            set { this._isActived = value; }
        }

        public int ChargeNo
        {
            get { return this._chargeNo; }
            set { this._chargeNo = value; }
        }

    }
}
