using System;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.FrontEnds.MainHandler;
using Utilities.ArgumentManager;
using Utilities.Logger;

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
            Logger.LogFile = Constants.StrLogFile;

            ArgumentManager.ParseArguments(args);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NewMainHandler());
        }
    }
}
