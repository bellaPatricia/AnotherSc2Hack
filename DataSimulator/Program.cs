using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationManager.ReadConfig();

            var sender = new Sender();

            while (true)
            {
                Thread.Sleep(ConfigurationManager.Config.Interval);

                sender.SendSimulatedData();
            }
        }
    }
}
