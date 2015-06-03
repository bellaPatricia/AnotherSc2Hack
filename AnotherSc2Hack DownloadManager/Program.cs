using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateChecker;

namespace AnotherSc2Hack_DownloadManager
{
    class Program
    {
        static void Main(string[] args)
        {
            DownloadManager dm = new DownloadManager();
            dm.UpdateAvailable += dm_UpdateAvailable;
            dm.ApplicationInstallationComplete += dm_ApplicationInstallationComplete;
            dm.NoUpdateAvailable += dm_NoUpdateAvailable;

            dm.LaunchCheckApplication();

            Console.Read();
        }

        static void dm_UpdateAvailable(object sender, EventArgs e)
        {
            var dm = sender as DownloadManager;

            if (dm == null)
                return;

            Console.WriteLine(dm.ShowApplicationUpdates());
            Console.WriteLine("Updating now...");

            dm.InstallApplicationUpdates();
        }

        static void dm_NoUpdateAvailable(object sender, EventArgs e)
        {
            Console.WriteLine("No updates found - closing in 5 seconds!");
        }

        static void dm_ApplicationInstallationComplete(object sender, EventArgs e)
        {
            Console.WriteLine("Installation successful!");
        }
    }
}
