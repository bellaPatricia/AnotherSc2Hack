using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnotherSc2Hack.Classes.BackEnds;

namespace OffsetAsserter
{
    class Program
    {
        static void Main(string[] args)
        {
            var procs = Process.GetProcessesByName("SC2");

            Memory mem = new Memory(procs[0]);
            mem.DesiredAccess = Memory.VmRead;

            Playertest.TestIt(mem);
        }
    }
}
