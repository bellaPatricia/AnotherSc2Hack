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

namespace AnotherSc2Hack.Classes.BackEnds
{
    class UpdateChecker
    {
        #region Properties

        public bool UpdatesAvailable { get; set; }

        #endregion


        private string _urlToApplicationVersioning =
            @"https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack/UpdateFiles/Sc2Hack_Version";

        private string _urlToPluginVersioning =
            @"https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack/UpdateFiles/Plugins.txt";

        private ApplicationVersioning _offlineVersioning;
        private ApplicationVersioning _onlineVersioning;

        public UpdateChecker()
        {
            CheckApplication();
        }

        /// <summary>
        /// Check if there are new ApplicationUpdates
        /// </summary>
        /// <returns>True if updates are available</returns>
        public Boolean CheckApplication()
        {
            var textFile = DownloadApplicationVersioning(_urlToApplicationVersioning);
            _onlineVersioning = ParseOnlineApplicationVersioning(textFile);
            _offlineVersioning = ParseOfflineApplicationVersioning();

            UpdatesAvailable |= !_onlineVersioning.ApplicationVersion.Equals(_offlineVersioning.ApplicationVersion);
            UpdatesAvailable |= !_onlineVersioning.PluginInterfaceVersion.Equals(_offlineVersioning.PluginInterfaceVersion);
            UpdatesAvailable |= !_onlineVersioning.PredefinedTypesVersion.Equals(_offlineVersioning.PredefinedTypesVersion);

            return UpdatesAvailable;
        }

        public String ShowApplicationUpdates()
        {
            var sb = new StringBuilder();

            if (UpdatesAvailable)
            {
                if (!_onlineVersioning.ApplicationVersion.Equals(_offlineVersioning.ApplicationVersion))
                {
                    sb.AppendLine(Path.GetFileName(_offlineVersioning.ApplicationUrl).Fill(" ", 30) + "=> " + _onlineVersioning.ApplicationVersion);
                    sb.AppendLine(Path.GetFileName(_offlineVersioning.PluginInterfaceUrl).Fill(" ", 30) + "=> " + _onlineVersioning.PluginInterfaceVersion);
                    sb.AppendLine(Path.GetFileName(_offlineVersioning.PredefinedTypesUrl).Fill(" ", 30) + "=> " + _onlineVersioning.PredefinedTypesVersion);
                }
            }

            return sb.ToString();
        }

        private String DownloadApplicationVersioning(string url)
        {
            var wc = new WebClient{Proxy = null};
            var strContent = wc.DownloadString(new Uri(url));

            strContent = strContent.RemoveAll("\r");

            return strContent;
        }

        private ApplicationVersioning ParseOnlineApplicationVersioning(string applicationFile)
        {
            var appVer = new ApplicationVersioning();

            //Unfortunately, we can not check the consistency of the applicationFile
            //And I don't really wan't to create such a mechanism.
            //So we just access the lines that are available..

            var lines = applicationFile.Split('\n');

            if (lines.Length >= 8)
            {
                appVer.ApplicationVersion = new Version(lines[0]);
                appVer.ApplicationUrl = lines[1];
                appVer.ApplicationChanges = lines[2];
                appVer.ApplicationCounter = lines[3];

                appVer.PluginInterfaceVersion = new Version(lines[4]);
                appVer.PluginInterfaceUrl = lines[5];

                appVer.PredefinedTypesVersion = new Version(lines[6]);
                appVer.PredefinedTypesUrl = lines[7];
            }

            return appVer;
        }

        private ApplicationVersioning ParseOfflineApplicationVersioning()
        {
            var appVer = new ApplicationVersioning();

            //Unfortunately, we can not check the consistency of the applicationFile
            //And I don't really wan't to create such a mechanism.
            //So we just access the lines that are available..

            appVer.ApplicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            appVer.ApplicationUrl = Application.ExecutablePath;

            if (File.Exists(Constants.StrPluginInterface))
            {
                appVer.PluginInterfaceVersion =
                    new Version(FileVersionInfo.GetVersionInfo(Constants.StrPluginInterface).FileVersion);
                appVer.PluginInterfaceUrl = Constants.StrPluginInterface;
            }

            if (File.Exists(Constants.StrPredefinedTypes))
            {
                appVer.PredefinedTypesVersion =
                    new Version(FileVersionInfo.GetVersionInfo(Constants.StrPredefinedTypes).FileVersion);
                appVer.PredefinedTypesUrl = Constants.StrPredefinedTypes;
            }

            return appVer;
        }
    }

    struct ApplicationVersioning
    {
        public Version ApplicationVersion { get; set; }
        public String ApplicationUrl { get; set; }
        public String ApplicationChanges { get; set; }
        public String ApplicationCounter { get; set; }
        public Version PluginInterfaceVersion { get; set; }
        public String PluginInterfaceUrl { get; set; }
        public Version PredefinedTypesVersion { get; set; }
        public String PredefinedTypesUrl { get; set; }
    }
}
