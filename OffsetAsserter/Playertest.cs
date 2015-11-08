using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AnotherSc2Hack.Classes.BackEnds;


namespace OffsetAsserter
{
    public static class Playertest
    {
        public static void TestIt(Memory mem)
        {
            var sc2 = (uint)mem.Process.MainModule.BaseAddress;
            var playerindex = 5;

            var edx = mem.ReadUInt32(sc2 + 0x1889130);
            Console.WriteLine($"edx >> {edx.ToString("X2")}");

            edx = edx ^ mem.ReadUInt32(sc2 + 0x1F17828);
            Console.WriteLine($"edx >> {edx.ToString("X2")}");

            edx = edx ^ 0x0246D359;
            Console.WriteLine($"edx >> {edx.ToString("X2")}");

            var ecx = mem.ReadUInt32(edx);
            Console.WriteLine($"ecx >> {ecx.ToString("X2")}");

            var eax = ecx + playerindex*4;
            Console.WriteLine($"eax >> {eax.ToString("X2")}");

            eax = mem.ReadUInt32(eax);
            Console.WriteLine($"eax >> {eax.ToString("X2")}");

            eax = eax ^ mem.ReadUInt32(sc2 + 0x188c68c);
            Console.WriteLine($"eax >> {eax.ToString("X2")}");

            eax = eax ^ 0x772BBADC;
            Console.WriteLine($"eax >> {eax.ToString("X2")}");

            while (true)
            {
                Thread.Sleep(100);

                var minerals = mem.ReadUInt32(eax + 0x800);
                Console.WriteLine($"minerals >> {minerals}");
            }
        }
    }
}
