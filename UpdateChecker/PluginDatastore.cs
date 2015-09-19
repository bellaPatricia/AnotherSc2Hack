using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UpdateChecker
{
    /// <summary>
    /// Class used to grab the online information of the plugins
    /// </summary>
    [DebuggerDisplay("Name: {Name}, Version: {Version}")]
    public class PluginDatastore
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DownloadPath { get; set; }
        public List<string> ImagePaths { get; set; }
        public string Version { get; set; }
        public string Hash { get; set; }

        public PluginDatastore()
        {
            Name = string.Empty;
            Description = string.Empty;
            DownloadPath = string.Empty;
            ImagePaths = new List<string>();
            Version = string.Empty;
            Hash = string.Empty;
        }
    }
}
