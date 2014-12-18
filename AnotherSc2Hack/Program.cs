using System;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.FrontEnds;
using AnotherSc2Hack.Classes.FrontEnds.MainHandler;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainHandler(new ApplicationStartOptions(args)));
        }
    }
}
