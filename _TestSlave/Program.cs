using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Logger;


namespace _TestSlave
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.LogFile = "file.dump";
            Logger.LogToFile = true;

            for (var i = 0; i < 100000; i++)
                Logger.Emit(new LogMessage("TestTitle", new Exception("kek")));


        }
    }
}
