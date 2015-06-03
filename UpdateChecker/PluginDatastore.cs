using System;
using System.Collections.Generic;

namespace AnotherSc2Hack.Classes.DataStructures.Versioning
{
    /// <summary>
    /// Class used to grab the online information of the plugins
    /// </summary>
    public class PluginDatastore
    {
        public PluginDatastore()
        {
            Name = String.Empty;
            Description = String.Empty;
            DownloadPath = String.Empty;
            ImagePaths = new List<string>();
            Version = String.Empty;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string DownloadPath { get; set; }
        public List<string> ImagePaths { get; set; }
        public string Version { get; set; }
    }
}
