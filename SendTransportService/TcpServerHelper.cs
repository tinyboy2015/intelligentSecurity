using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SendTransportService
{
    /// <summary>
    /// TcpServerHelper 的摘要说明。
    /// </summary>
    public class TcpServerHelper
    {
        private Socket m_Sock = null;
        private int m_iPort = 0;   // 监听的端口
        private int m_iMaxConn = 15;  // 最大连接数
        private bool m_bActive = false;
        private int m_iSendTimeout = 5000;
        private int m_iRecvTimeout = 5000;
        private Thread _thread = null;
        private Hashtable runSockettable = new Hashtable();
        private ArrayList clearEntitylist = new ArrayList();
        private object synObj = new object();
        private byte[] sendBytes = new byte[1024];
        private byte[] _heartBytes = null;

        public delegate void OnConnectSuccessEvent(SocketEntity entity);
        public event OnConnectSuccessEvent OnConnectSuccess = null;

        public delegate void OnCloseConnectionEvent(SocketEntity entity);
        public event OnCloseConnectionEvent OnCloseConnection = null;

        public delegate void OnReceiveEvent(SocketEntity entity, byte[] bytes, int length);
        public event OnReceiveEvent OnReceive = null;

        private void StartExecute(Socket socket)
        {
            IPEndPoint clientipe = (IPEndPoint)socket.RemoteEndPoint;
            string clientIP = clientipe.Address.ToString();

            SocketEntity entity = new SocketEntity();
            entity.Socket = socket;
            entity.IP = clientIP;
            entity.Port = clientipe.Port;
            entity.IsActived = true;
            entity.FirstConnectTime = DateTime.Now;

            if (!runSockettable.ContainsKey(clientIP))
            {
                runSockettable.Add(clientIP, entity);
            }
            else
            {
                runSockettable[clientIP] = entity;
            }
            if (OnConnectSuccess != null)
                OnConnectSuccess(entity);

            ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveData), entity);
        }

        private void ReceiveData(object obj)
        {
            if (obj == null)
            {
                return;
            }
            if (!(obj is SocketEntity))
            {
                return;
            }
            byte[] buffer1 = new byte[1024];
            byte[] buffer2 = new byte[1024];
            int bufLen = 0;
            while (true)
            {
                SocketEntity s = obj as SocketEntity;
                if (s == null || s.Socket == null)
                {
                    break;
                }
                if (!s.IsActived)
                {
                    break;
                }
                bufLen = 0;
                try
                {
                    if (s.Socket.Available <= 0)
                    {
                        Thread.Sleep(20);
                        continue;
                    }
                    bufLen = 0;
                    Array.Clear(buffer1, 0, buffer1.Length);
                    bufLen = s.Socket.Receive(buffer1, 1024, SocketFlags.None);
                    if (bufLen <= 0)
                    {
                        continue;
                    }
                    Array.Clear(buffer2, 0, buffer2.Length);
                    Array.Copy(buffer1, 0, buffer2, 0, bufLen);
                    s.LastReceiveTime = DateTime.Now;
                    if (OnReceive != null)
                        OnReceive(s, buffer2, bufLen);

                }
                catch
                {
                    continue;
                }
            }
        }

        public int SendTimeout
        {
            get { return m_iSendTimeout; }
            set { m_iSendTimeout = value > 0 ? value : m_iSendTimeout; }
        }
        public int RecvTimeout
        {
            get { return m_iRecvTimeout; }
            set { m_iRecvTimeout = value > 0 ? value : m_iRecvTimeout; }
        }
        /// <summary>
        /// 当前连接的通信map
        /// </summary>
        public Hashtable CurrAcitvedSocketTable
        {
            get { return this.runSockettable; }
        }
        public bool IsActived
        {
            get { return m_bActive; }
        }
        public int Port
        {
            get { return m_iPort; }
            set { m_iPort = value > 0 ? value : m_iPort; }
        }
        public int MaxConn
        {
            get { return m_iMaxConn; }
            set { m_iMaxConn = value > 0 ? value : m_iMaxConn; }
        }

        public bool Send(string ip, byte[] data)
        {
            if (runSockettable.Count == 0 || !runSockettable.ContainsKey(ip))
            {
                return true;
            }

            try
            {
                SocketEntity entity = runSockettable[ip] as SocketEntity;
                if (!entity.IsActived)
                {
                    return false;
                }
                lock (synObj)
                {
                    entity.Socket.Send(sendBytes, 0, data.Length + 6, SocketFlags.None);
                }

            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Open()
        {
            try
            {
                IPEndPoint localEP = new IPEndPoint(IPAddress.Any, m_iPort);

                // 创建Socket对象
                m_Sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // 设置为发送合并禁用 Nagle 算法
                m_Sock.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, 1);
                LingerOption lo = new LingerOption(false, 0);
                // 如果存在未发送的数据，则在关闭时不逗留。
                m_Sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, lo);
                // 绑定Socket本地IP地址和端口号
                m_Sock.Bind(localEP);
                // 启动侦听
                m_Sock.Listen(m_iMaxConn);
            }
            catch
            {
                return false;
            }

            m_bActive = true;

            _thread = new Thread(new ThreadStart(this.AcceptConnect));
            _thread.Start();

            Thread clientThread = new Thread(new ThreadStart(CheckClientSocket));
            clientThread.Start();

            return true;
        }

        private void CheckClientSocket()
        {
            while (m_bActive)
            {
                try
                {
                    if (runSockettable.Count == 0)
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                    clearEntitylist.Clear();
                    foreach (SocketEntity entity in runSockettable.Values)
                    {
                        TimeSpan ts1 = DateTime.Now - entity.LastReceiveTime;
                        if (ts1.Seconds > 120 && entity.LastReceiveTime != DateTime.MinValue)
                        {
                            clearEntitylist.Add(entity);
                            continue;
                        }

                        TimeSpan ts2 = DateTime.Now - entity.LastConnectTime;
                        if (ts2.Seconds < 30 && entity.LastConnectTime != DateTime.MinValue)
                        {
                            continue;
                        }

                        try
                        {
                            lock (synObj)
                            {
                                entity.Socket.Send(_heartBytes);
                            }
                            entity.LastConnectTime = DateTime.Now;
                            continue;
                        }
                        catch
                        {
                            entity.IsActived = false;
                        }

                        clearEntitylist.Add(entity);
                    }

                    foreach (SocketEntity s in clearEntitylist)
                    {
                        try
                        {
                            s.Socket.Close();
                            Thread.Sleep(50);
                            s.IsActived = false;
                        }
                        catch
                        {
                            s.IsActived = false;
                        }
                        runSockettable.Remove(s.IP);

                        if (OnCloseConnection != null)
                            OnCloseConnection(s);
                    }

                    Thread.Sleep(100);
                }
                catch
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 关闭服务对象
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            m_bActive = false;
            foreach (SocketEntity entity in runSockettable.Values)
            {
                if (entity != null)
                {
                    entity.IsActived = false;
                    entity.Socket.Close();
                    Thread.Sleep(50);
                }
            }

            if (m_Sock != null)
            {
                m_Sock.Close();
                Thread.Sleep(50);
            }
            m_Sock = null;
            if (_thread != null)
            {
                _thread.Abort();
                Thread.Sleep(50);
            }
            _thread = null;
            return true;
        }

        private void AcceptConnect()
        {
            while (m_bActive)
            {
                try
                {
                    Socket _sock = m_Sock.Accept();
                    _sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, m_iSendTimeout);
                    _sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, m_iRecvTimeout);
                    StartExecute(_sock);
                }
                catch
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// 创建服务对象，创建后需调用Open方法。
        /// </summary>
        /// <param name="iPort">端口</param>
        /// <param name="maxConnect">最大连接数</param>
        public TcpServerHelper(int iPort, int maxConnect, byte[] heartBytes)
        {
            this.m_iPort = iPort;
            this.m_iMaxConn = maxConnect;
            this._heartBytes = heartBytes;
        }
    }
}
