using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace Sc2Hack_UpdateManager.Classes.Fontend
{
    public partial class MainWindow : Form
    {
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
        }

        private void WcOnDownloadProgressChanged(object sender,
                                                 DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
        {
            pgrBarMain.Value = downloadProgressChangedEventArgs.ProgressPercentage;
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
                _dcPredefinedTypes.VerOnlineFileVersion > _dcPredefinedTypes.VerLocalFileVersion)
            {
                ParseChangesFile();
                btnStartUpdate.Enabled = true;
                
            }

            else
                lblHeader.Text = "You are Up-To-Date!";
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
                    lblHeader.Text = strSplit[i].Substring(7, strSplit[i].Length - 7);
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
    }

    public class DataCompare
    {
        public String StrLocalFilePath { get; set; }
        public Version VerLocalFileVersion { get; set; }
        public String StrOnlineFilePath { get; set; }
        public Version VerOnlineFileVersion { get; set; }
    }
}