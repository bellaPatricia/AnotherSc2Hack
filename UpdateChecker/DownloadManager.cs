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
using Utilities.ExtensionMethods;

namespace UpdateChecker
{
    public class DownloadManager
    {
        #region Properties

        private bool? _bUpdatesAvailable = null;

        public bool? BUpdatesAvailable
        {
            get {return _bUpdatesAvailable;}
            set
            {
                if (_bUpdatesAvailable == value)
                    return;

                _bUpdatesAvailable = value;

                if (_bUpdatesAvailable == null)
                    return;

                if (_bUpdatesAvailable.Value)
                    OnUpdateAvailable(this, new EventArgs());

                else
                    OnNoUpdateAvailable(this, new EventArgs());
            }
        }


        #endregion

        #region Events 

        public event EventHandler UpdateAvailable;
        public event EventHandler NoUpdateAvailable;
        public event EventHandler ApplicationInstallationComplete;

        #endregion

        private const string StrApplicationDatastore =
            @"https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack/UpdateFiles/v1.0.0.0/Application.xml";

        private const string StrPluginDatastore =
            @"https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack/UpdateFiles/v1.0.0.0/Plugins.xml";

        private ApplicationVersioning _offlineVersioning = new ApplicationVersioning();
        private ApplicationVersioning _onlineVersioning = new ApplicationVersioning();

        private WebClient _wcDownloader = new WebClient {Proxy = null};

        private void OnUpdateAvailable(object sender, EventArgs e)
        {
            if (UpdateAvailable != null)
                UpdateAvailable(sender, e);
        }

        private void OnNoUpdateAvailable(object sender, EventArgs e)
        {
            if (NoUpdateAvailable != null)
                NoUpdateAvailable(sender, e);
        }

        private void OnApplicationInstallationComplete(object sender, EventArgs e)
        {
            if (ApplicationInstallationComplete != null)
                ApplicationInstallationComplete(sender, e);
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
            _offlineVersioning.ParseOfflineApplicationVersioning(_onlineVersioning);

            var bUpdatesAvailable = !_onlineVersioning.ApplicationVersion.Equals(_offlineVersioning.ApplicationVersion);

            foreach (var onlineLibrary in _onlineVersioning.DynamicLinkLibraries)
            {
                var offlineLibrary = _offlineVersioning.DynamicLinkLibraries.Find(x => x.DllName == onlineLibrary.DllName);

                if (offlineLibrary == null)
                {
                    bUpdatesAvailable = true;
                }

                else
                {
                    bUpdatesAvailable |= new Version(onlineLibrary.DllVersion) > new Version(offlineLibrary.DllVersion);
                }
            }

            BUpdatesAvailable = bUpdatesAvailable;

            return bUpdatesAvailable;
        }

        public string ShowApplicationUpdates()
        {
            var sb = new StringBuilder();

            if (BUpdatesAvailable == null)
                return String.Empty;

            if (BUpdatesAvailable.Value)
            {
                if (!_onlineVersioning.ApplicationVersion.Equals(_offlineVersioning.ApplicationVersion))
                {
                    if (!File.Exists(_offlineVersioning.ApplicationUrl))
                    {
                        sb.Append(Path.GetFileNameWithoutExtension(_offlineVersioning.ApplicationUrl).Fill(" ", 30));
                        sb.Append("New!");
                    }

                    else
                    {
                        sb.Append(Path.GetFileName(_offlineVersioning.ApplicationUrl).Fill(" ", 30) +
                                      _offlineVersioning.ApplicationVersion + " => " +
                                      _onlineVersioning.ApplicationVersion);
                    }
                }

                foreach (var onlineLibrary in _onlineVersioning.DynamicLinkLibraries)
                {
                    var offlineLibrary = _offlineVersioning.DynamicLinkLibraries.Find(x => x.DllName == onlineLibrary.DllName);

                    if (offlineLibrary == null)
                    {
                        sb.Append("\n");
                        sb.Append(onlineLibrary.DllName.Fill(" ", 30));
                        sb.Append("New!");
                    }

                    else
                    {
                        if (new Version(onlineLibrary.DllVersion) > new Version(offlineLibrary.DllVersion))
                        {
                            sb.Append("\n");
                            sb.Append(offlineLibrary.DllName.Fill(" ", 30));
                            sb.Append(offlineLibrary.DllVersion + " => ");
                            sb.Append(onlineLibrary.DllVersion);
                        }
                    }
                }
            }

            return sb.ToString();
        }

        public bool InstallApplicationUpdates()
        {
            if (_onlineVersioning.ApplicationVersion > _offlineVersioning.ApplicationVersion)
            {
                if (File.Exists(_offlineVersioning.ApplicationUrl))
                    File.Delete(_offlineVersioning.ApplicationUrl);

                _wcDownloader.DownloadFile(_onlineVersioning.ApplicationUrl, _offlineVersioning.ApplicationUrl);
            }

            foreach (var dynamicLinkLibrary in _onlineVersioning.DynamicLinkLibraries)
            {
                var availableLibrary =
                    _offlineVersioning.DynamicLinkLibraries.Find(x => x.DllName == dynamicLinkLibrary.DllName);

                if (availableLibrary == null)
                {
                    _wcDownloader.DownloadFile(dynamicLinkLibrary.DllDownloadPath,
                        Path.Combine(Application.StartupPath, dynamicLinkLibrary.DllName + ".dll"));
                }

                else
                {
                    if (new Version(dynamicLinkLibrary.DllVersion) > new Version(availableLibrary.DllVersion))
                    {
                        if (File.Exists(availableLibrary.DllDownloadPath))
                            File.Delete(availableLibrary.DllDownloadPath);

                        _wcDownloader.DownloadFile(dynamicLinkLibrary.DllDownloadPath, Path.Combine(Application.StartupPath, dynamicLinkLibrary.DllName + ".dll"));
                    }
                }
            }

            OnApplicationInstallationComplete(this, new EventArgs());

            return true;
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

        public void ParseOfflineApplicationVersioning(ApplicationVersioning onlineVersion)
        {
            var strApplicationNames = onlineVersion.ApplicationUrl.Split('/');
            var strApplicationName = strApplicationNames[strApplicationNames.Length - 1];

            if (Path.GetFileName(Application.ExecutablePath) != strApplicationName)
            {
                ApplicationUrl = Path.Combine(Application.StartupPath, strApplicationName);
            }
            else
            {
                ApplicationUrl = Application.ExecutablePath;
            }

            if (File.Exists(ApplicationUrl))
                ApplicationVersion = new Version(FileVersionInfo.GetVersionInfo(ApplicationUrl).FileVersion);

            //Get local dlls and get the names
            var localLibraries = Directory.GetFiles(Application.StartupPath, "*.dll");

            foreach (var dll in onlineVersion.DynamicLinkLibraries)
            {
                foreach (var localLibrary in localLibraries)
                {
                    var localLibraryName = Path.GetFileNameWithoutExtension(localLibrary);
                    if (localLibraryName == dll.DllName)
                    {
                        var localLibraryVersion = FileVersionInfo.GetVersionInfo(localLibrary).FileVersion;
                        var localDll = new DynamicLinkLibrary(localLibraryName, localLibrary, localLibraryVersion);
                        DynamicLinkLibraries.Add(localDll);
                        break;
                    }
                }
            }
        }
    }
}
