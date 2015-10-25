using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSimulator
{
    public class Configuration
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public int Interval { get; set; }

        public static Configuration SetDefaultValues()
        {
            var config = new Configuration();

            config.Interval = 100;
            config.IpAddress = "127.0.0.1";
            config.Port = 55555;

            return config;
        }
    }
}
