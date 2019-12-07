using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SendTransportService
{
    public partial class Form1 : Form
    {
        private bool _isEnabled = false;
        private TcpServerHelper tcpHelper = null;       
        DataTable dt = new DataTable();
        private Hashtable SocketIPTable = new Hashtable();

        private object receiveLock = new object(); //添加锁对象，防止多线程同时添加对象。  
        public Form1()
        {
            InitializeComponent();
        }



        public void OpenSocket()
        {
            ServerSocket ss = new ServerSocket();
            ss.Open();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenSocket();
        }
    }
}
