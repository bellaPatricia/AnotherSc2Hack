 //This file will be an executable which manages
 //basic application updating.
 
 //NOTE: If you want to compile and use this executable,
 //make sure you merge the libraries 'UpdateChecker.dll' and
 //'Utilities.dll' with it! 
 
 //Tools like ILMerge will help you with this.
 
 
 //If you don't do this, you'll never be able to update the UpdateChecker.dll
 //and Utilities.dll!
 
 //Written by bellaPatricia
 //2015-June-05


using System;
using System.Collections.Generic;
using System.Reflection;
using UpdateChecker;
using Utilities.Events;

namespace AnotherSc2Hack_DownloadManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to {0}. Downloading process will start shortly. Hang in tight!", Assembly.GetExecutingAssembly().GetName().Name);

            var dm = new DownloadManager();
            dm.UpdateAvailable += dm_UpdateAvailable;
            dm.NoUpdateAvailable += dm_NoUpdateAvailable;
            dm.CheckComplete += dm_CheckComplete;
            dm.DownloadManagerProgressChanged += dm_DownloadManagerProgressChanged;

            dm.CheckUpdates();

            Console.ReadKey();
            dm.LaunchApplication();
        }

        private static int _iConsoleCursorTop = 0;
        private static readonly Dictionary<string, int> DFilenames = new Dictionary<string, int>(); 

        static void dm_DownloadManagerProgressChanged(object sender, DownloadManagerProgressChangedEventArgs e)
        {
            if (!DFilenames.ContainsKey(e.FileName))
                //The directory doesn't seem to be threadsafe.
                //So we'll just put it into the try-catch and ignore the exception
                try
                {
                    DFilenames.Add(e.FileName, e.PercentageCompleted);
                }
                catch (ArgumentException)
                {
                    //Ignore - Will say there's a key already available
                }

            else
                DFilenames[e.FileName] = e.PercentageCompleted;

            DrawConsoleOutput();   
        }

        private static void DrawConsoleOutput()
        {
            //The directory doesn't seem to be threadsafe.
            //So we'll just put it into the try-catch and ignore the exception
            Dictionary<string, int> localDict = null;
            try
            {
                localDict = new Dictionary<string, int>(DFilenames);
            }

            catch (ArgumentException)
            {
                //Ignore - Will say there's a key already available
            }

            if (localDict == null)
                return;

            var iIndex = 0;            
            foreach (var localDic in localDict)
            {
                Console.SetCursorPosition(0, _iConsoleCursorTop + iIndex);
                Console.Write("\n{0}: {1} %\0", localDic.Key, localDic.Value);

                iIndex += 1;
            }            
        }

        private static void dm_CheckComplete(object sender, EventArgs eventArgs)
        {
            var dm = sender as DownloadManager;

            if (dm == null)
                return;

            if (dm.BUpdatesAvailable == UpdateState.Available)
            {
                Console.Write("\n- Updates will be installed now -");
                _iConsoleCursorTop = Console.CursorTop;
                dm.InstallApplicationUpdates();
                dm.InstallPluginUpdates();
            }

            Console.Write("\nPress any key to exit and launch AnotherSc2Hack!");
            
        }

        static void dm_UpdateAvailable(object sender, UpdateArgs e)
        {
            var dm = sender as DownloadManager;

            if (dm == null)
                return;

            if (e.OldVersion == string.Empty || e.OldVersion == "0.0.0.0")
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
