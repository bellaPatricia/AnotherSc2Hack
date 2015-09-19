using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Events;
using _ = Utilities.InfoManager.InfoManager;

namespace UpdateChecker
{
    public enum UpdateState
    {
        Available = 1,
        NotAvailable = 2,
        None = 4
    };

    public class DownloadManager
    {
        #region Properties

        public UpdateState BUpdatesAvailable { get; private set; }
        public string ApplicationChangesUrl { get; private set; }
        public List<PluginDatastore> PluginDatastoresOnline { get; private set; }
        public List<PluginDatastore> PluginDatastoresOffline { get; private set; }


        #endregion

        #region Events 

        public event UpdateChangeHandler UpdateAvailable;
        public event UpdateChangeHandler NoUpdateAvailable;
        public event EventHandler ApplicationInstallationComplete;
        public event EventHandler CheckComplete;
        public event EventHandler DownloadManagerUpdateRequired;
        public event DownloadManagerProgressHandler DownloadManagerProgressChanged;

        #endregion

        #region Private Fields

        private const string StrApplicationDatastore =
            @"https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack2/UpdateInformation/Application.xml";

        private const string StrPluginDatastore =
            @"https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack2/UpdateInformation/Plugins.xml";

        private readonly ApplicationVersioning _offlineApplicationVersioning = new ApplicationVersioning();
        private readonly ApplicationVersioning _onlineApplicationVersioning = new ApplicationVersioning();
        private readonly PluginVersioning _offlinePluginVersioning = new PluginVersioning();
        private readonly PluginVersioning _onlinePluginVersioning = new PluginVersioning();
        private readonly WebClient _wcDownloader = new WebClient {Proxy = null};
        private string _strDownloadedFileName = String.Empty;

        #endregion

        #region Constructor

        public DownloadManager()
        {
            _wcDownloader.DownloadProgressChanged += _wcDownloader_DownloadProgressChanged;

            BUpdatesAvailable = UpdateState.None;
            PluginDatastoresOnline = new List<PluginDatastore>();
        }

        #endregion

        #region Event Initializers

        private void OnDownloadManagerUpdateRequired(object sender, EventArgs e)
        {
            DownloadManagerUpdateRequired?.Invoke(sender, e);
        }

        private void OnDownloadManagerProgressChanged(object sender, DownloadManagerProgressChangedEventArgs e)
        {
            DownloadManagerProgressChanged?.Invoke(sender, e);
        }

        private void OnUpdateAvailable(object sender, UpdateArgs e)
        {
            BUpdatesAvailable = UpdateState.Available;

            UpdateAvailable?.Invoke(sender, e);
        }

        private void OnNoUpdateAvailable(object sender, UpdateArgs e)
        {
            NoUpdateAvailable?.Invoke(sender, e);
        }

        private void OnApplicationInstallationComplete(object sender, EventArgs e)
        {
            ApplicationInstallationComplete?.Invoke(sender, e);
        }

        private void OnCheckComplete(object sender, EventArgs e)
        {
            CheckComplete?.Invoke(sender, e);
        }

        #endregion

        #region Private Methods

        void _wcDownloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var client = sender as WebClient;

            if (client == null)
            {
                _.Info("Could not parse the webclient", _.InfoImportance.NotImportant);
                return;
            }

            _.Info($"Attempt To Download {client.BaseAddress}", _.InfoImportance.Important);

            OnDownloadManagerProgressChanged(this,
                new DownloadManagerProgressChangedEventArgs(_strDownloadedFileName, e.TotalBytesToReceive,
                    e.BytesReceived, e.ProgressPercentage));
        }

        private void CheckVersions()
        {
            BUpdatesAvailable = UpdateState.None;
            CheckApplication();
            CheckPlugins();

            OnCheckComplete(this, new EventArgs());
        }

        private void CheckApplication()
        {
            _.Info("Checking Application Version", _.InfoImportance.Important);

            _onlineApplicationVersioning.Clear();
            _offlineApplicationVersioning.Clear();
            
            _onlineApplicationVersioning.ParseOnlineApplicationVersioning(StrApplicationDatastore);
            _offlineApplicationVersioning.ParseOfflineApplicationVersioning(_onlineApplicationVersioning);

            ApplicationChangesUrl = _onlineApplicationVersioning.ApplicationChanges;
            

            if (_onlineApplicationVersioning.ApplicationVersion > _offlineApplicationVersioning.ApplicationVersion)
            {
                _.Info("Update For The Application Available!", _.InfoImportance.VeryImportant);

                OnUpdateAvailable(this,
                    new UpdateArgs(Path.GetFileNameWithoutExtension(_offlineApplicationVersioning.ApplicationUrl),
                        _offlineApplicationVersioning.ApplicationVersion.ToString(),
                        _onlineApplicationVersioning.ApplicationVersion.ToString()));
            }

            else
            {
                _.Info("Update For The Application *NOT* Available!", _.InfoImportance.Important);

                OnNoUpdateAvailable(this,
                    new UpdateArgs(Path.GetFileNameWithoutExtension(_offlineApplicationVersioning.ApplicationUrl),
                        _offlineApplicationVersioning.ApplicationVersion.ToString(),
                        _onlineApplicationVersioning.ApplicationVersion.ToString()));
            }

            if (_onlineApplicationVersioning.DownloadManagerVersion >
                _offlineApplicationVersioning.DownloadManagerVersion)
            {
                _.Info("Update For The Download Manager Available!", _.InfoImportance.Important);

                OnDownloadManagerUpdateRequired(this, new EventArgs());
            }

            else
            {
                _.Info("Update For The Download Manager *NOT* Available!", _.InfoImportance.Important);

                OnNoUpdateAvailable(this,
                    new UpdateArgs(Path.GetFileNameWithoutExtension(_offlineApplicationVersioning.DownloadManagerUrl),
                        _offlineApplicationVersioning.DownloadManagerVersion.ToString(),
                        _onlineApplicationVersioning.DownloadManagerVersion.ToString()));
            }

            foreach (var onlineLibrary in _onlineApplicationVersioning.DynamicLinkLibraries)
            {
                var offlineLibrary = _offlineApplicationVersioning.DynamicLinkLibraries.Find(x => x.DllName == onlineLibrary.DllName);

                if (offlineLibrary == null)
                {
                    _.Info($"Update For {onlineLibrary.DllName} Available!", _.InfoImportance.Important);

                    OnUpdateAvailable(this,
                        new UpdateArgs(onlineLibrary.DllName, String.Empty, onlineLibrary.DllVersion));
                }

                else
                {
                    if (new Version(onlineLibrary.DllVersion) > new Version(offlineLibrary.DllVersion))
                    {
                        _.Info($"Update For {onlineLibrary.DllName} Available!", _.InfoImportance.Important);

                        OnUpdateAvailable(this,
                            new UpdateArgs(onlineLibrary.DllName, offlineLibrary.DllVersion, onlineLibrary.DllVersion));
                    }

                    else
                    {
                        _.Info($"Update For {onlineLibrary.DllName} *NOT* Available!", _.InfoImportance.Important);

                        OnNoUpdateAvailable(this,
                            new UpdateArgs(onlineLibrary.DllName, offlineLibrary.DllVersion, onlineLibrary.DllVersion));
                    }

                }
            }
        }

        private void CheckPlugins()
        {
            _offlinePluginVersioning.Clear();
            _onlinePluginVersioning.Clear();

            _onlinePluginVersioning.ParseOnlinePluginVersioning(StrPluginDatastore);
            _offlinePluginVersioning.ParseOfflinePluginVersioning(_onlinePluginVersioning);

            PluginDatastoresOnline = _onlinePluginVersioning.Plugins;
            PluginDatastoresOffline = _offlinePluginVersioning.Plugins;

            foreach (var onlinePlugin in _onlinePluginVersioning.Plugins)
            {
                var offlinePlugin = _offlinePluginVersioning.Plugins.Find(x => x.Name == onlinePlugin.Name);

                if (offlinePlugin == null)
                    continue;

                if (new Version(onlinePlugin.Version) > new Version(offlinePlugin.Version))
                {
                    _.Info($"Update For Plugin {onlinePlugin.Name} Available!", _.InfoImportance.Important);

                    OnUpdateAvailable(this,
                        new UpdateArgs(onlinePlugin.Name, offlinePlugin.Version, onlinePlugin.Version));
                }

                else
                {
                    _.Info($"Update For Plugin {onlinePlugin.Name} *NOT* Available!", _.InfoImportance.Important);

                    OnNoUpdateAvailable(this,
                        new UpdateArgs(onlinePlugin.Name, offlinePlugin.Version, onlinePlugin.Version));
                }

            }
        }

        #endregion

        #region Public Methods

        public void CheckUpdates()
        {
            Task tsk = new Task(x => CheckVersions(), null);

            tsk.Start();
        }

        public void InstallApplicationUpdates()
        {
            if (_onlineApplicationVersioning.ApplicationVersion > _offlineApplicationVersioning.ApplicationVersion)
            {
                if (File.Exists(_offlineApplicationVersioning.ApplicationUrl))
                    File.Delete(_offlineApplicationVersioning.ApplicationUrl);

                _strDownloadedFileName = Path.GetFileNameWithoutExtension(_offlineApplicationVersioning.ApplicationUrl);
                _wcDownloader.DownloadFileAsync(new Uri(_onlineApplicationVersioning.ApplicationUrl), _offlineApplicationVersioning.ApplicationUrl);
                while (_wcDownloader.IsBusy) { Thread.Sleep(30);}

                //Increment download counter
                var webRequest = WebRequest.Create(_onlineApplicationVersioning.ApplicationCounter);
                webRequest.Proxy = _wcDownloader.Proxy;
                webRequest.GetResponse();
            }

            if (_onlineApplicationVersioning.DownloadManagerVersion > _offlineApplicationVersioning.DownloadManagerVersion)
            {
                if (File.Exists(_offlineApplicationVersioning.DownloadManagerUrl))
                {
                    var strTempFile =
                        Path.GetFileNameWithoutExtension(_offlineApplicationVersioning.DownloadManagerUrl) + ".TEMP";
                    if (File.Exists(strTempFile))
                        File.Delete(strTempFile);

                    File.Move(_offlineApplicationVersioning.DownloadManagerUrl, strTempFile);
                    File.SetAttributes(strTempFile, File.GetAttributes(strTempFile) | FileAttributes.Hidden);
                }

                _strDownloadedFileName = Path.GetFileNameWithoutExtension(_offlineApplicationVersioning.DownloadManagerUrl);
                _wcDownloader.DownloadFileAsync(new Uri(_onlineApplicationVersioning.DownloadManagerUrl), _offlineApplicationVersioning.DownloadManagerUrl);
                while (_wcDownloader.IsBusy) { Thread.Sleep(30); }
            }

            foreach (var dynamicLinkLibrary in _onlineApplicationVersioning.DynamicLinkLibraries)
            {
                var availableLibrary =
                    _offlineApplicationVersioning.DynamicLinkLibraries.Find(x => x.DllName == dynamicLinkLibrary.DllName);

                if (availableLibrary == null)
                {
                    _strDownloadedFileName = dynamicLinkLibrary.DllName;
                    _wcDownloader.DownloadFileAsync(new Uri(dynamicLinkLibrary.DllDownloadPath),
                        Path.Combine(Application.StartupPath, dynamicLinkLibrary.DllName + ".dll"));
                    while (_wcDownloader.IsBusy) { Thread.Sleep(30); }
                }

                else
                {
                    if (new Version(dynamicLinkLibrary.DllVersion) > new Version(availableLibrary.DllVersion))
                    {
                        if (File.Exists(availableLibrary.DllDownloadPath))
                        File.Delete(availableLibrary.DllDownloadPath);

                        _strDownloadedFileName = dynamicLinkLibrary.DllName;
                        _wcDownloader.DownloadFileAsync(new Uri(dynamicLinkLibrary.DllDownloadPath), Path.Combine(Application.StartupPath, dynamicLinkLibrary.DllName + ".dll"));
                        while (_wcDownloader.IsBusy) { Thread.Sleep(30); }
                    }
                }
            }

            OnApplicationInstallationComplete(this, new EventArgs());
        }

        public void InstallPluginUpdates()
        {
            foreach (var onlinePlugin in _onlinePluginVersioning.Plugins)
            {
                var installedPlugin = _offlinePluginVersioning.Plugins.Find(x => x.Name == onlinePlugin.Name);

                if (installedPlugin == null)
                    continue;

                if (new Version(onlinePlugin.Version) > new Version(installedPlugin.Version))
                {
                    if (File.Exists(installedPlugin.DownloadPath))
                        File.Delete(installedPlugin.DownloadPath);

                    _strDownloadedFileName = Path.GetFileNameWithoutExtension(installedPlugin.DownloadPath);
                    _wcDownloader.DownloadFileAsync(new Uri(onlinePlugin.DownloadPath), installedPlugin.DownloadPath);
                    while (_wcDownloader.IsBusy) { Thread.Sleep(10); }
                }
            }
        }

        public void InstallDownloadManager()
        {
            if (_onlineApplicationVersioning.DownloadManagerVersion >
                _offlineApplicationVersioning.DownloadManagerVersion)
            {
                if (File.Exists(_offlineApplicationVersioning.DownloadManagerUrl))
                    File.Delete(_offlineApplicationVersioning.DownloadManagerUrl);

                _strDownloadedFileName = Path.GetFileNameWithoutExtension(_offlineApplicationVersioning.DownloadManagerUrl);
                _wcDownloader.DownloadFileAsync(new Uri(_onlineApplicationVersioning.DownloadManagerUrl), _offlineApplicationVersioning.DownloadManagerUrl);
                while (_wcDownloader.IsBusy) { Thread.Sleep(10); }
            }
        }

        public void LaunchApplication()
        {
            if (File.Exists(_offlineApplicationVersioning.ApplicationUrl))
                Process.Start(_offlineApplicationVersioning.ApplicationUrl);
        }

        #endregion
    }
}