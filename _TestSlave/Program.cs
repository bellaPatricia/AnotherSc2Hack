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
            var strline = Console.ReadLine();

            try
            {
                var iNumber = int.Parse(strline);

                var result = 55/iNumber;

                Console.WriteLine("Result: {0}", result);
            }

            catch (Exception ex)
            {
                Logger.Emit(ex);
            }


        }
    }
}
