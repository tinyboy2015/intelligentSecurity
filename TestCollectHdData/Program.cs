using CollectHdDataLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCollectHdData
{
    class Program
    {
        private static SpListControl spc;
        static void Main(string[] args)
        {
            // NOTE: To disable debug output uncomment the following two lines
            //LogManager.Configuration.LoggingRules.RemoveAt(0);
            //LogManager.Configuration.Reload();
            //Debugger.Launch();
            spc = new SpListControl();
            spc.ConnectAll();
            Console.WriteLine("begin receive");
        }
    }
}
