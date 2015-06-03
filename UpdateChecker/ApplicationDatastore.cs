using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AnotherSc2Hack.Classes.DataStructures.Versioning
{
    public class ApplicationDatastore
    {
        public ApplicationDatastore()
        {
            ApplicationChangesPath = String.Empty;
            ApplicationDownloadCounterPath = String.Empty;
            ApplicationDownloadPath = String.Empty;
            ApplicationVersion = String.Empty;
            DllDynamicLinkLibraries = new List<DynamicLinkLibrary>();
        }

        public string ApplicationDownloadPath { get; set; }
        public string ApplicationChangesPath { get; set; }
        public string ApplicationDownloadCounterPath { get; set; }
        public string ApplicationVersion { get; set; }
        public List<DynamicLinkLibrary> DllDynamicLinkLibraries { get; set; }

    }

    [DebuggerDisplay("DllName: {DllName}, DllVersion: {DllVersion}")]
    public class DynamicLinkLibrary
    {
        public DynamicLinkLibrary()
        {
            DllName = String.Empty;
            DllDownloadPath = String.Empty;
            DllVersion = String.Empty;
        }

        public DynamicLinkLibrary(string dllName, string downloadPath, string version)
        {
            DllName = dllName;
            DllDownloadPath = downloadPath;
            DllVersion = version;
        }

        public string DllDownloadPath { get; set; }
        public string DllVersion { get; set; }
        public string DllName { get; set; }
    }
}
