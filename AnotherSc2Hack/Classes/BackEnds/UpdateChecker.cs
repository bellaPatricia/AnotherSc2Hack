using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using AnotherSc2Hack.Classes.DataStructures.Versioning;
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

        private const string StrApplicationDatastore =
            @"https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack/UpdateFiles/v1.0.0.0/Application.xml";

        private const string StrPluginDatastore =
            @"https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack/UpdateFiles/v1.0.0.0/Plugins.xml";

        private ApplicationVersioning _offlineVersioning = new ApplicationVersioning();
        private ApplicationVersioning _onlineVersioning = new ApplicationVersioning();

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
            _onlineVersioning = new ApplicationVersioning();
            _offlineVersioning = new ApplicationVersioning();

            _onlineVersioning.ParseOnlineApplicationVersioning(StrApplicationDatastore);
            _offlineVersioning.ParseOfflineApplicationVersioning();

            var bUpdatesAvailable = !_onlineVersioning.ApplicationVersion.Equals(_offlineVersioning.ApplicationVersion);

            foreach (var dll in _onlineVersioning.DynamicLinkLibraries)
            {
                var library = _offlineVersioning.DynamicLinkLibraries.Find(x => x.DllName == dll.DllName);

                if (library == null)
                {
                    bUpdatesAvailable = true;
                }

                else
                {
                    bUpdatesAvailable |= dll.DllVersion != library.DllVersion;
                }
            }

            BUpdatesAvailable = bUpdatesAvailable;

            return bUpdatesAvailable;
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

                foreach (var dll in _onlineVersioning.DynamicLinkLibraries)
                {
                    var library = _offlineVersioning.DynamicLinkLibraries.Find(x => x.DllName == dll.DllName);

                    if (library == null)
                    {
                        sb.Append("\n");
                        sb.Append(dll.DllName.Fill(" ", 30));
                        sb.Append("New!");
                    }

                    else
                    {
                        if (library.DllVersion != dll.DllVersion)
                        {
                            sb.Append("\n");
                            sb.Append(library.DllName.Fill(" ", 30));
                            sb.Append(library.DllVersion + " => ");
                            sb.Append(dll.DllVersion);
                        }
                    }
                }
            }

            return sb.ToString();
        }
        
    }

    public class ApplicationVersioning
    {
        public Version ApplicationVersion { get; set; }
        public string ApplicationUrl { get; set; }
        public string ApplicationChanges { get; set; }
        public string ApplicationCounter { get; set; }
        public List<DynamicLinkLibrary> DynamicLinkLibraries { get; set; }

        public ApplicationVersioning()
        {
            ApplicationVersion = new Version(0,0,0,0);
            ApplicationChanges = String.Empty;
            ApplicationCounter = String.Empty;
            ApplicationUrl = String.Empty;
            DynamicLinkLibraries = new List<DynamicLinkLibrary>();
        }

        public void Clear()
        {
            ApplicationVersion = new Version(0, 0, 0, 0);
            ApplicationChanges = String.Empty;
            ApplicationCounter = String.Empty;
            ApplicationUrl = String.Empty;
            DynamicLinkLibraries.Clear();
        }

        public void ParseOnlineApplicationVersioning(string strApplicationPath)
        {
            var wc = new WebClient {Proxy = null};
            var strSource = wc.DownloadString(strApplicationPath);

            var xmlSerializer = new XmlSerializer(typeof(ApplicationDatastore));

            var appDatastore = (ApplicationDatastore) xmlSerializer.Deserialize(new StringReader(strSource));


            ApplicationVersion = new Version(appDatastore.ApplicationVersion);
            ApplicationUrl = appDatastore.ApplicationDownloadPath;
            ApplicationChanges = appDatastore.ApplicationChangesPath;
            ApplicationCounter = appDatastore.ApplicationDownloadCounterPath;

            foreach (var dll in appDatastore.DllDynamicLinkLibraries)
            {
                DynamicLinkLibraries.Add(dll);
            }
        }

        public void ParseOfflineApplicationVersioning()
        {
            ApplicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            ApplicationUrl = Application.ExecutablePath;

            if (File.Exists(Constants.StrPluginInterface))
            {
                var dll = new DynamicLinkLibrary(Path.GetFileNameWithoutExtension(Constants.StrPluginInterface), Constants.StrPluginInterface,
                    FileVersionInfo.GetVersionInfo(Constants.StrPluginInterface).FileVersion);

                DynamicLinkLibraries.Add(dll);
            }

            if (File.Exists(Constants.StrPredefinedTypes))
            {
                var dll = new DynamicLinkLibrary(Path.GetFileNameWithoutExtension(Constants.StrPredefinedTypes), Constants.StrPredefinedTypes,
                    FileVersionInfo.GetVersionInfo(Constants.StrPredefinedTypes).FileVersion);

                DynamicLinkLibraries.Add(dll);
            }
        }
    }
}
