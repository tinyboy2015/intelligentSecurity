using CollectHdDataLib;
using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace CollectHdDataService
{
    public partial class CollectHdDataService : ServiceBase
    {
        private SpListControl spc;
        public CollectHdDataService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // NOTE: To disable debug output uncomment the following two lines
            //LogManager.Configuration.LoggingRules.RemoveAt(0);
            //LogManager.Configuration.Reload();
            Debugger.Launch();
            spc = new SpListControl();
            spc.ConnectAll();
            Console.WriteLine("begin receive");
        }

        protected override void OnStop()
        {
            spc.DisconnectAll();
        }
    }
}
