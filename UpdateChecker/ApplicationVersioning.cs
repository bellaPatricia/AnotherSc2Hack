using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UpdateChecker
{
    public class ApplicationVersioning
    {
        public Version ApplicationVersion { get; set; }
        public string ApplicationUrl { get; set; }
        public string ApplicationChanges { get; set; }
        public string ApplicationCounter { get; set; }
        public List<DynamicLinkLibrary> DynamicLinkLibraries { get; set; }

        public ApplicationVersioning()
        {
            ApplicationVersion = new Version(0, 0, 0, 0);
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

        public void ParseOnlineApplicationVersioning(string strApplicationUrl)
        {
            var wc = new WebClient { Proxy = null };
            var strSource = wc.DownloadString(strApplicationUrl);

            var xmlSerializer = new XmlSerializer(typeof(ApplicationDatastore));

            var appDatastore = (ApplicationDatastore)xmlSerializer.Deserialize(new StringReader(strSource));


            ApplicationVersion = new Version(appDatastore.ApplicationVersion);
            ApplicationUrl = appDatastore.ApplicationDownloadPath;
            ApplicationChanges = appDatastore.ApplicationChangesPath;
            ApplicationCounter = appDatastore.ApplicationDownloadCounterPath;

            foreach (var dll in appDatastore.DynamicLinkLibraries)
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
