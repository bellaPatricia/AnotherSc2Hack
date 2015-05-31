using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.ExtensionMethods;

namespace AnotherSc2Hack.Classes.BackEnds
{
    public class UpdateChecker
    {
        #region Properties

        private bool _bUpdatesAvailable;

        public bool BUpdatesAvailable
        {
            get {return _bUpdatesAvailable;}
            set
            {
                if (_bUpdatesAvailable == value)
                    return;

                _bUpdatesAvailable = value;

                if (_bUpdatesAvailable)
                    OnUpdateAvailable(this, new EventArgs());
            }
        }

        #endregion

        #region Events 

        public event EventHandler UpdateAvailable;

        #endregion

        private string _urlToApplicationVersioning =
            @"https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack/UpdateFiles/Sc2Hack_Version";

        private string _urlToPluginVersioning =
            @"https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack/UpdateFiles/Plugins.txt";

        private ApplicationVersioning _offlineVersioning;
        private ApplicationVersioning _onlineVersioning;

        public UpdateChecker()
        {
            
        }

        private void OnUpdateAvailable(object sender, EventArgs e)
        {
            if (UpdateAvailable != null)
                UpdateAvailable(sender, e);
        }

        public void LaunchCheckApplication()
        {
            Task<bool> tsk = new Task<bool>(x => CheckApplication(), null);

            tsk.Start();

        }

        /// <summary>
        /// Check if there are new ApplicationUpdates
        /// </summary>
        /// <returns>True if updates are available</returns>
        private bool CheckApplication()
        {
            BUpdatesAvailable = false;

            var textFile = DownloadApplicationVersioning(_urlToApplicationVersioning);
            _onlineVersioning.ParseOnlineApplicationVersioning(textFile);
            _offlineVersioning.ParseOfflineApplicationVersioning();

            BUpdatesAvailable |= !_onlineVersioning.ApplicationVersion.Equals(_offlineVersioning.ApplicationVersion);
            BUpdatesAvailable |= !_onlineVersioning.PluginInterfaceVersion.Equals(_offlineVersioning.PluginInterfaceVersion);
            BUpdatesAvailable |= !_onlineVersioning.PredefinedTypesVersion.Equals(_offlineVersioning.PredefinedTypesVersion);

            return BUpdatesAvailable;
        }

        public string ShowApplicationUpdates()
        {
            var sb = new StringBuilder();

            if (BUpdatesAvailable)
            {
                if (!_onlineVersioning.ApplicationVersion.Equals(_offlineVersioning.ApplicationVersion))
                {
                    sb.AppendLine(Path.GetFileName(_offlineVersioning.ApplicationUrl).Fill(" ", 30) + 
                                  _offlineVersioning.ApplicationVersion + " => " +
                                  _onlineVersioning.ApplicationVersion);
                }

                if (!_onlineVersioning.PluginInterfaceVersion.Equals(_offlineVersioning.PluginInterfaceVersion))
                {
                    sb.AppendLine(Path.GetFileName(_offlineVersioning.PluginInterfaceUrl).Fill(" ", 30) + 
                                  _offlineVersioning.PluginInterfaceVersion + " => " +
                                  _onlineVersioning.PluginInterfaceVersion);
                }

                if (!_onlineVersioning.PredefinedTypesVersion.Equals(_offlineVersioning.PredefinedTypesVersion))
                {
                    sb.AppendLine(Path.GetFileName(_offlineVersioning.PredefinedTypesUrl).Fill(" ", 30) + 
                                  _offlineVersioning.PredefinedTypesVersion + " => " +
                                  _onlineVersioning.PredefinedTypesVersion);
                }
            }

            return sb.ToString();
        }

        private string DownloadApplicationVersioning(string url)
        {
            var wc = new WebClient{};
            var strContent = wc.DownloadString(new Uri(url));

            strContent = strContent.RemoveAll("\r");

            return strContent;
        }

        

        
    }

    struct ApplicationVersioning
    {
        public Version ApplicationVersion { get; set; }
        public string ApplicationUrl { get; set; }
        public string ApplicationChanges { get; set; }
        public string ApplicationCounter { get; set; }
        public Version PluginInterfaceVersion { get; set; }
        public string PluginInterfaceUrl { get; set; }
        public Version PredefinedTypesVersion { get; set; }
        public string PredefinedTypesUrl { get; set; }

        public void ParseOnlineApplicationVersioning(string onlineSource)
        {
            //Unfortunately, we can not check the consistency of the onlineSource
            //And I don't really wan't to create such a mechanism.
            //So we just access the lines that are available..

            var lines = onlineSource.Split('\n');

            if (lines.Length >= 8)
            {
                ApplicationVersion = new Version(lines[0]);
                ApplicationUrl = lines[1];
                ApplicationChanges = lines[2];
                ApplicationCounter = lines[3];

                PluginInterfaceVersion = new Version(lines[4]);
                PluginInterfaceUrl = lines[5];

                PredefinedTypesVersion = new Version(lines[6]);
                PredefinedTypesUrl = lines[7];
            }
        }

        public void ParseOfflineApplicationVersioning()
        {
            //Unfortunately, we can not check the consistency of the onlineSource
            //And I don't really wan't to create such a mechanism.
            //So we just access the lines that are available..

            ApplicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            ApplicationUrl = Application.ExecutablePath;

            if (File.Exists(Constants.StrPluginInterface))
            {
                PluginInterfaceVersion =
                    new Version(FileVersionInfo.GetVersionInfo(Constants.StrPluginInterface).FileVersion);
                PluginInterfaceUrl = Constants.StrPluginInterface;
            }

            if (File.Exists(Constants.StrPredefinedTypes))
            {
                PredefinedTypesVersion =
                    new Version(FileVersionInfo.GetVersionInfo(Constants.StrPredefinedTypes).FileVersion);
                PredefinedTypesUrl = Constants.StrPredefinedTypes;
            }
        }
    }
}
