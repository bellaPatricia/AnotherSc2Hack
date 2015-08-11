using System;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.FrontEnds;
using AnotherSc2Hack.Classes.FrontEnds.MainHandler;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;
using Utilities.ApplicationStartOptions;
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
            Logger.LogToConsole = true;

            ApplicationStartOptions.ParseStartupArguments(args);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MaphackFilter());
            Application.Run(new NewMainHandler());
            //Application.Run(new MainHandler(new ApplicationStartOptions(args)));
        }
    }
}
