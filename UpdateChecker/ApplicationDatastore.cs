using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UpdateChecker
{
    public class ApplicationDatastore
    {
        public ApplicationDatastore()
        {
            ApplicationChangesPath = string.Empty;
            ApplicationDownloadCounterPath = string.Empty;
            ApplicationDownloadPath = string.Empty;
            ApplicationVersion = string.Empty;
            DownloadManagerDownloadPath = string.Empty;
            DownloadManagerVersion = string.Empty;
            DynamicLinkLibraries = new List<DynamicLinkLibrary>();
        }

        public string ApplicationDownloadPath { get; set; }
        public string ApplicationChangesPath { get; set; }
        public string ApplicationDownloadCounterPath { get; set; }
        public string ApplicationVersion { get; set; }
        public string DownloadManagerDownloadPath { get; set; }
        public string DownloadManagerVersion { get; set; }
        public List<DynamicLinkLibrary> DynamicLinkLibraries { get; set; }
    }

    [DebuggerDisplay("DllName: {DllName}, DllVersion: {DllVersion}")]
    public class DynamicLinkLibrary
    {
        public string DllDownloadPath { get; set; }
        public string DllVersion { get; set; }
        public string DllName { get; set; }

        public DynamicLinkLibrary()
        {
            DllName = string.Empty;
            DllDownloadPath = string.Empty;
            DllVersion = string.Empty;
        }

        public DynamicLinkLibrary(string dllName, string downloadPath, string version)
        {
            DllName = dllName;
            DllDownloadPath = downloadPath;
            DllVersion = version;
        }
    }
}
