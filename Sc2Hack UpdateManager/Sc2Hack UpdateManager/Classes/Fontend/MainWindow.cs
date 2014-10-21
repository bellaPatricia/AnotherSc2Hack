using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using PluginInterface;
using System.Linq;

namespace Sc2Hack_UpdateManager.Classes.Fontend
{
    public partial class MainWindow : Form
    {
        public static String StrPluginFolder = Application.StartupPath + "\\Plugins\\";
        public String StrOnlinePath =
            "https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack/UpdateFiles/Sc2Hack_Version";

        private Font _fBold = new Font("Arial", 12, FontStyle.Bold);
        private Font _fRegular = new Font("Arial", 10, FontStyle.Regular);
        private string _strCurrentFile = @"AnotherSc2Hack.exe";
        private String _strPathToChanges = String.Empty;
        private String _strPathToCounter = String.Empty;
        private String _strPathToExecutable = String.Empty;
        private Version _vCurrentVersion;
        private Version _vOnlineVersion;

        private DataCompare _dcPredefinedTypes = new DataCompare();
        private DataCompare _dcPluginInterface = new DataCompare();

        List<VersionFile> _lStrVersionFiles = new List<VersionFile>();

        private class VersionFile
        {
            public String File { get; set; }
            public Version Version { get; set; }
        };

        private void SetupFilelist()
        {
            #region Get all files and versions

            var files = Directory.GetFiles(Application.StartupPath);
            foreach (var s in files)
            {
                if (s.ToLower().EndsWith("anothersc2hack.exe") ||
                    s.ToLower().EndsWith("predefinedtypes.dll") ||
                    s.ToLower().EndsWith("plugininterface.dll"))
                {
                    var tmp = new VersionFile();
                    tmp.File = s;
                    tmp.Version = new Version(FileVersionInfo.GetVersionInfo(s).FileVersion);

                    _lStrVersionFiles.Add(tmp);
                }
                
            }

            var plugins1 = Directory.GetFiles(Application.StartupPath, "*.dll");

            foreach (var s in plugins1)
            {
                var tmp = new VersionFile();
                tmp.File = s;
                tmp.Version = new Version(FileVersionInfo.GetVersionInfo(s).FileVersion);

                _lStrVersionFiles.Add(tmp);
            }

            #endregion
        }

        public MainWindow()
        {
            InitializeComponent();
            SetupDataCompare();
            CheckForIllegalCrossThreadCalls = false;
            new Thread(UpdateThread).Start();

            SetStyle(ControlStyles.DoubleBuffer |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint, true);

            SetupFilelist();

        }

        private void SetupDataCompare()
        {
            _dcPluginInterface.StrLocalFilePath = Application.StartupPath + "\\PluginInterface.dll";
            _dcPredefinedTypes.StrLocalFilePath = Application.StartupPath + "\\PredefinedTypes.dll";

            if (!File.Exists(_dcPluginInterface.StrLocalFilePath))
                _dcPluginInterface.VerLocalFileVersion = new Version(0, 0, 0, 0);

            else
            {
                try
                {

                

                _dcPluginInterface.VerLocalFileVersion =
                    new Version(FileVersionInfo.GetVersionInfo(_dcPluginInterface.StrLocalFilePath).FileVersion);
                }
                catch (Exception)
                {
                    _dcPluginInterface.VerLocalFileVersion = new Version(0,0,0,0);
                }
            }

            if (!File.Exists(_dcPredefinedTypes.StrLocalFilePath))
                _dcPredefinedTypes.VerLocalFileVersion = new Version(0, 0, 0, 0);

            else
            {
                try { 
                _dcPredefinedTypes.VerLocalFileVersion =
                    new Version(FileVersionInfo.GetVersionInfo(_dcPredefinedTypes.StrLocalFilePath).FileVersion);
                }
                catch (Exception)
                {
                    _dcPredefinedTypes.VerLocalFileVersion = new Version(0, 0, 0, 0);
                }
            }
        }

        /* Download file and replace */

        private void btnStartUpdate_Click(object sender, EventArgs e)
        {
            /* Call Webbrowser to increase download counter @ goo.gl */
            var wb = new WebBrowser();
            wb.Url = new Uri(_strPathToCounter);
            wb.Refresh();

            /* Download the file */
            var wc = new WebClient();
            wc.Proxy = null;

            if (_dcPluginInterface.VerOnlineFileVersion > _dcPluginInterface.VerLocalFileVersion)
            {
                if (File.Exists(_dcPluginInterface.StrLocalFilePath))
                    File.Delete(_dcPluginInterface.StrLocalFilePath);
                wc.DownloadFile(new Uri(_dcPluginInterface.StrOnlineFilePath), _dcPluginInterface.StrLocalFilePath);
            }
            

            if (_dcPredefinedTypes.VerOnlineFileVersion > _dcPredefinedTypes.VerLocalFileVersion)
            {
                if (File.Exists(_dcPredefinedTypes.StrLocalFilePath))
                    File.Delete(_dcPredefinedTypes.StrLocalFilePath);
                wc.DownloadFile(new Uri(_dcPredefinedTypes.StrOnlineFilePath), _dcPredefinedTypes.StrLocalFilePath);
            }
            wc.DownloadFileAsync(new Uri(_strPathToExecutable), _strCurrentFile + "tmp");
            wc.DownloadProgressChanged += WcOnDownloadProgressChanged;
            wc.DownloadFileCompleted += wc_DownloadFileCompleted;

            if (CheckPlugins())
                DownloadPlugins();
        }

        private void WcOnDownloadProgressChanged(object sender,
                                                 DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
        {
            pgrBarMain.Value = downloadProgressChangedEventArgs.ProgressPercentage;


            Text = downloadProgressChangedEventArgs.ProgressPercentage + "%\t[" +
                   downloadProgressChangedEventArgs.BytesReceived + "/" +
                   downloadProgressChangedEventArgs.TotalBytesToReceive + "]";

        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (File.Exists(_strCurrentFile + "tmp"))
            {
                if (File.Exists(_strCurrentFile))
                {
                    File.Replace(_strCurrentFile + "tmp", _strCurrentFile,
                                 _strCurrentFile + "Backup_" + DateTime.Now.Date.Year + "-" + DateTime.Now.Date.Month +
                                 "-" +
                                 DateTime.Now.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" +
                                 DateTime.Now.Second);
                }

                else
                    File.Move(_strCurrentFile + "tmp", _strCurrentFile);


                Process[] procs = Process.GetProcesses();
                foreach (Process process in procs)
                {
                    if (process.ProcessName == "AnotherSc2Hack")
                    {
                        process.CloseMainWindow();
                    }
                }

                try
                {
                    Process.Start("AnotherSc2Hack.exe");
                }

                catch
                {
                }


                Environment.Exit(0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateThread()
        {
            GetInformation();

            if (_vOnlineVersion > _vCurrentVersion ||
                _dcPluginInterface.VerOnlineFileVersion > _dcPluginInterface.VerLocalFileVersion ||
                _dcPredefinedTypes.VerOnlineFileVersion > _dcPredefinedTypes.VerLocalFileVersion ||
                CheckPlugins())
            {
                ParseChangesFile();
                btnStartUpdate.Enabled = true;
                
            }

            else
                Text = "You are Up-To-Date!";
        }


        private void GetInformation()
        {
            int iCountTimeOuts = 0;

            TryAnotherRound:

            /* We ping the Server first to exclude exceptions! */
            var myPing = new Ping();

            PingReply myResult;


            try
            {
                myResult = myPing.Send("Dropbox.com", 10);
            }

            catch
            {
                goto TryAnotherRound;
            }

            if (myResult != null && myResult.Status != IPStatus.Success)
            {
                if (iCountTimeOuts >= 10)
                {
                    MessageBox.Show("Can not reach Server!\n\nTry later!", "FAILED");
                    Close();
                    return;
                }

                iCountTimeOuts++;
                goto TryAnotherRound;
            }


            /* Connect to server */
            var privateWebClient = new WebClient();
            privateWebClient.Proxy = null;

            string strSource = string.Empty;

            try
            {
                strSource = privateWebClient.DownloadString(StrOnlinePath);
            }

            catch
            {
                MessageBox.Show("Can not reach Server!\n\nTry later!", "FAILED");
                Close();
                return;
            }

            FileVersionInfo fi = null;
            try
            {
                fi = FileVersionInfo.GetVersionInfo(_strCurrentFile);
                _vCurrentVersion = new Version(fi.FileVersion);
            }

            catch
            {
                _vCurrentVersion = new Version(0, 0, 0, 0);
            }


            /* Build version from online- file (string) */
            _vOnlineVersion = new Version(GetStringItems(0, strSource));
            _strPathToExecutable = GetStringItems(1, strSource);
            _strPathToChanges = GetStringItems(2, strSource);
            _strPathToCounter = GetStringItems(3, strSource);

            _dcPluginInterface.VerOnlineFileVersion = new Version(GetStringItems(4, strSource));
            _dcPluginInterface.StrOnlineFilePath = GetStringItems(5, strSource);
            _dcPredefinedTypes.VerOnlineFileVersion = new Version(GetStringItems(6, strSource));
            _dcPredefinedTypes.StrOnlineFilePath = GetStringItems(7, strSource);
        }

        /* Parses out a string of Line x */

        private string GetStringItems(int line, string source)
        {
            /* Is Like
              1  Version=0.0.1.0
              2  Path=https://dl.dropbox.com/u/62845853/AnotherSc2Hack/Binaries/Another%20SC2%20Hack.exe
              3  Changes=https://dl.dropbox.com/u/62845853/AnotherSc2Hack/UpdateFiles/Changes 
              4  Counter=http://goo.gl/N0UZiu
              5  Version Plugininterface
              6  Path
              7  Version PredefinedTypes
              8  Path
             */

            string[] strmoreSource = source.Split('\n');
            if (strmoreSource[line].Contains("\r"))
                strmoreSource[line] = strmoreSource[line].Substring(0, strmoreSource[line].IndexOf('\r'));

            return strmoreSource[line];
        }

        /* Parse the changes File */
        
        private void ParseChangesFile()
        {
            Graphics g = CreateGraphics();

            /* Connect to server */
            var privateWebClient = new WebClient();
            privateWebClient.Proxy = null;

            string strSource = string.Empty;

            try
            {
                strSource = privateWebClient.DownloadString(_strPathToChanges);
            }

            catch
            {
                MessageBox.Show("Can not reach Server!\n\nTry later!", "FAILED");
                Close();
                return;
            }

            string[] strSplit = strSource.Split('\n');


            for (int i = 0; i < strSplit.Length; i++)
            {
                if (strSplit[i].EndsWith("\r"))
                    strSplit[i] = strSplit[i].Substring(0, strSplit[i].IndexOf('\r'));
            }


            for (int i = 0; i < strSplit.Length; i++)
            {
                if (strSplit[i].StartsWith("Header"))
                {
                    Text = strSplit[i].Substring(7, strSplit[i].Length - 7);
                    continue;
                }

                rtbItems.Text += strSplit[i];
                rtbItems.Text += "\n";
            }

            return;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
        }

        public static bool CheckPlugins()
        {
            if (!Directory.Exists(StrPluginFolder))
                return false;

            var domain = AppDomain.CreateDomain("tmp");
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
            var strPlugins = Directory.GetFiles(StrPluginFolder, "*.exe");
            var strTmpPlugins = Directory.GetFiles(StrPluginFolder, "*.dll");
            var lTmpPlugins = new List<String>();
            foreach (var s in strPlugins)
                lTmpPlugins.Add(s);

            foreach (var s in strTmpPlugins)
                lTmpPlugins.Add(s);


            foreach (var strPlugin in lTmpPlugins)
            {
                try
                {
                    var name = new AssemblyName();
                    name.CodeBase = strPlugin;
                    var pluginTypes = domain.Load(name).GetTypes();
                    var fileInfo = FileVersionInfo.GetVersionInfo(strPlugin);
                    var version = new Version(fileInfo.FileVersion);
                    //var pluginTypes = Assembly.LoadFile(strPlugin).GetTypes();

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

            AppDomain.Unload(domain);

            if (lstPlugins.Count(x => x.RequiresUpdate) > 0)
            {
                return true;
            }

            return false;
        }

        public void DownloadPlugins()
        {
            var domain = AppDomain.CreateDomain("tmp");
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
            var strPlugins = Directory.GetFiles(StrPluginFolder, "*.exe");
            var strTmpPlugins = Directory.GetFiles(StrPluginFolder, "*.dll");
            var lTmpPlugins = new List<String>();
            foreach (var s in strPlugins)
                lTmpPlugins.Add(s);

            foreach (var s in strTmpPlugins)
                lTmpPlugins.Add(s);

            

            foreach (var strPlugin in lTmpPlugins)
            {
                try
                {
                    
                    var name = new AssemblyName();
                    name.CodeBase = strPlugin;
                    var pluginTypes = domain.Load(name).GetTypes();

                    var fileInfo = FileVersionInfo.GetVersionInfo(strPlugin);
                    var version = new Version(fileInfo.FileVersion);
                    //var pluginTypes = Assembly.LoadFile(strPlugin).GetTypes();

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

            AppDomain.Unload(domain);


            if (lstPlugins.Count(x => x.RequiresUpdate) > 0)
            {
                
                
                var strPluginNames = String.Empty;
                foreach (var plug in lstPlugins)
                {
                    if (plug.RequiresUpdate)
                    {
                        strPluginNames += plug.Name + "\n";

                        if (File.Exists(plug.LocalPath))
                            File.Delete(plug.LocalPath);

                        wc.DownloadFileAsync(new Uri(plug.DownloadLink), plug.LocalPath);
                        wc.DownloadProgressChanged += WcOnDownloadProgressChanged;
                    }
                }               
            }


        }

    }

    public class DataCompare
    {
        public String StrLocalFilePath { get; set; }
        public Version VerLocalFileVersion { get; set; }
        public String StrOnlineFilePath { get; set; }
        public Version VerOnlineFileVersion { get; set; }
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