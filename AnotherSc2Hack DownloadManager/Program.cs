/// This file will be an executable which manages
/// basic application updating.
/// 
/// NOTE: If you want to compile and use this executable,
/// make sure you merge the libraries 'UpdateChecker.dll' and
/// 'Utilities.dll' with it! 
/// 
/// Tools like ILMerge will help you with this.
/// 
/// 
/// If you don't do this, you'll never be able to update the UpdateChecker.dll
/// and Utilities.dll!
/// 
/// Written by bellaPatricia 
/// 2015-June-05


using System;
using UpdateChecker;
using Utilities.Events;


namespace AnotherSc2Hack_DownloadManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var dm = new DownloadManager();
            dm.UpdateAvailable += dm_UpdateAvailable;
            dm.NoUpdateAvailable += dm_NoUpdateAvailable;
            dm.CheckComplete += dm_CheckComplete;
            dm.DownloadManagerProgressChanged += dm_DownloadManagerProgressChanged;

            dm.CheckUpdates();

            Console.ReadKey();
            dm.LaunchApplication();
        }

        static void dm_DownloadManagerProgressChanged(object sender, DownloadManagerProgressChangedEventArgs e)
        {
            Console.WriteLine("{0}: {1}%", e.FileName, e.PercentageCompleted);
        }

        private static void dm_CheckComplete(object sender, EventArgs eventArgs)
        {
            var dm = sender as DownloadManager;

            if (dm == null)
                return;

            if (dm.BUpdatesAvailable == UpdateState.Available)
            {
                Console.WriteLine("- Updates will be installed now -");
                dm.InstallApplicationUpdates();
                dm.InstallPluginUpdates();
            }

            Console.WriteLine("Press any key to exit and launch AnotherSc2Hack!");
            
        }

        static void dm_UpdateAvailable(object sender, UpdateArgs e)
        {
            var dm = sender as DownloadManager;

            if (dm == null)
                return;

            if (e.OldVersion == String.Empty || e.OldVersion == "0.0.0.0")
                Console.WriteLine("[{0}] !New! -> {1}", e.UpdateName, e.NewVersion);

            else
                Console.WriteLine("[{0}] {1} -> {2}", e.UpdateName, e.OldVersion, e.NewVersion);
        }

        static void dm_NoUpdateAvailable(object sender, UpdateArgs e)
        {
            Console.WriteLine("[{0}] -> up-to-date!", e.UpdateName);
        }
    }
}
