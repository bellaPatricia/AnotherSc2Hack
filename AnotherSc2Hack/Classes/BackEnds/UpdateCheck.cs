using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using PluginInterface;

namespace AnotherSc2Hack.Classes.BackEnds
{
    public static class UpdateCheck
    {
        /// <summary>
        /// Checks if a plugin needs an update and if it does, returns true
        /// </summary>
        /// <returns>Returns true whenever an update for an available (e.g. downloaded) plugin is available</returns>
        public static bool CheckPlugins()
        {
            var _strUrlPlugins = @"https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack/UpdateFiles/Plugins.txt";
            var lstPlugins = new List<Plugin>();
            var _lPlugins = new List<IPlugins>();

            var wc = new WebClient();
            var strSource = wc.DownloadString(_strUrlPlugins);
            // Info: Plugin- Names start with '#'
            // Plugin- Descriptions start with '+'
            // Plugin- Downloadlinks start with '*'
            // Plugin- Pictures start with '-'
            // Plugin- Versions start with 'V'

            var strSpltted = strSource.Split('\n');
            foreach (var str in strSpltted)
            {

                if (str.StartsWith("#"))
                {
                    lstPlugins.Add(new Plugin());
                    lstPlugins[lstPlugins.Count - 1].Name = str.Substring(1).Trim();
                }

                else if (str.StartsWith("+"))
                    lstPlugins[lstPlugins.Count - 1].Description = str.Substring(1).Trim();

                else if (str.StartsWith("*"))
                    lstPlugins[lstPlugins.Count - 1].DownloadLink = str.Substring(1).Trim();

                else if (str.StartsWith("-"))
                    lstPlugins[lstPlugins.Count - 1].ImageLinks.Add(str.Substring(1).Trim());

                else if (str.StartsWith("V"))
                    lstPlugins[lstPlugins.Count - 1].Version = new Version(str.Substring(1).Trim());
            }

            /* List all Plugins */
            var strPlugins = Directory.GetFiles(Constants.StrPluginFolder, "*.exe");
            var strTmpPlugins = Directory.GetFiles(Constants.StrPluginFolder, "*.dll");
            var lTmpPlugins = new List<String>();
            foreach (var s in strPlugins)
                lTmpPlugins.Add(s);

            foreach (var s in strTmpPlugins)
                lTmpPlugins.Add(s);


            foreach (var strPlugin in lTmpPlugins)
            {
                try
                {
                    var fileInfo = FileVersionInfo.GetVersionInfo(strPlugin);
                    var version = new Version(fileInfo.FileVersion);
                    var pluginTypes = Assembly.LoadFile(strPlugin).GetTypes();

                    foreach (var pluginType in pluginTypes)
                    {
                        /* Search for main- plugin method */
                        if (pluginType.ToString().Contains("AnotherSc2HackPlugin"))
                        {
                            var plugin = Activator.CreateInstance(pluginType) as IPlugins;


                            if (plugin == null)
                                break;

                            for (int index = 0; index < lstPlugins.Count; index++)
                            {
                                var onlinePlug = lstPlugins[index];
                                if (onlinePlug.Name == plugin.GetPluginName())
                                {
                                    //Cool
                                    if (onlinePlug.Version > version)
                                    {
                                        lstPlugins[index].RequiresUpdate = true;
                                        lstPlugins[index].LocalPath = strPlugin;
                                    }
                                }
                            }

                            _lPlugins.Add(plugin);

                            break;
                        }
                    }
                }

                catch
                {
                    //Means the plugin couldn't be loaded so we download the newest version of it!
                    for (var i = 0; i < lstPlugins.Count; i++)
                    {
                        if (strPlugin.Contains(lstPlugins[i].Name))
                        {
                            lstPlugins[i].RequiresUpdate = true;
                            lstPlugins[i].LocalPath = strPlugin;
                        }
                    }
                }
            }

            if (lstPlugins.Count(x => x.RequiresUpdate) > 0)
            {
                return true;
                /*
                var strPluginNames = String.Empty;
                foreach (var plug in lstPlugins)
                {
                    if (plug.RequiresUpdate)
                    {
                        strPluginNames += plug.Name + "\n";
                    }
                }

                var result = MessageBox.Show("It seems like there are new updates for some of your plugins available!\n\n" + strPluginNames + "\n\nDo you wish to update them?", "New Updates", MessageBoxButtons.YesNo);


                if (result == DialogResult.Yes)
                {
                    //This is where we close the application and call the updater!
                }*/
            }

            return false;
        }

        /// <summary>
        /// Downloads the newest Download Manager and replaces the old one...
        /// </summary>
        /// <returns>Returns false if the Download failed</returns>
        public static bool DownloadUpdateManager()
        {
            var strUrlUpdater =
                @"https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack/UpdateFiles/Sc2Hack_Updater";

            var wc = new WebClient();

            var strSource = DownloadString(strUrlUpdater, 5);

            if (strSource == String.Empty)
                return false;

            var strSplitted = strSource.Split('\n');

            var version = new Version(strSplitted[0].Trim());
            var path = strSplitted[1].Trim();

            if (!File.Exists(Constants.StrUpdateManager))
            {
                try
                {
                    wc.DownloadFile(new Uri(path), Constants.StrUpdateManager);
                }

                catch
                {
                    //fml
                    return false;
                }
            }

            else
            {
                //Check if a new version can be downloaded
                var fileVersionInfo = FileVersionInfo.GetVersionInfo(Constants.StrUpdateManager);

                if (version > new Version(fileVersionInfo.FileVersion))
                {
                    try
                    {
                        wc.DownloadFile(new Uri(path), Constants.StrUpdateManager);
                    }

                    catch
                    {
                        //fml
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Downloads a string from an online environment.
        /// If the Download fails, it tries to redo the action.
        /// </summary>
        /// <param name="url">The Url to download the string from</param>
        /// <param name="times">The amount you already tried</param>
        /// <param name="maxTimes">The maximum amount of tries</param>
        /// <returns></returns>
        public static String DownloadString(string url, int maxTimes, int times = 0)
        {
            if (times >= maxTimes)
                return String.Empty;

            var wc = new WebClient();

            try
            {
                return
                    wc.DownloadString(
                        url);
            }

            catch
            {
                return DownloadString(url, maxTimes, ++times);
            }
        }
    }

    [DebuggerDisplay("Name: {Name}; Description: {Description}; Version: {Version}; Link: {DownloadLink}")]
    public class Plugin
    {
        
        public Plugin()
        {
            InitCode();
        }

        public Plugin(string name, string desc, List<String> images, Version version, bool reqUpdate, string localpath)
        {
            Name = name;
            Description = desc;
            ImageLinks = images;
            Version = version;
            RequiresUpdate = reqUpdate;
            LocalPath = localpath;
        }

        private void InitCode()
        {
            ImageLinks = new List<String>();
            Name = String.Empty;
            Description = String.Empty;
            Version = new Version(0, 0, 0, 0);
            RequiresUpdate = false;
            LocalPath = string.Empty;
        }

        public String Name { get; set; }
        public String Description { get; set; }
        public List<String> ImageLinks { get; set; }
        public Version Version { get; set; }
        public String DownloadLink { get; set; }
        public Boolean RequiresUpdate { get; set; }
        public String LocalPath { get; set; }
    }
}
