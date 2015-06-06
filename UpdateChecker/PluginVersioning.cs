using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UpdateChecker
{
    public class PluginVersioning
    {
        public List<PluginDatastore> Plugins { get; private set; }

        public PluginVersioning()
        {
            Plugins = new List<PluginDatastore>();
        }

        public void Clear()
        {
            Plugins.Clear();
        }

        public void ParseOnlinePluginVersioning(string strPluginUrl)
        {
            var wc = new WebClient { Proxy = null };
            var strSource = wc.DownloadString(strPluginUrl);

            var xmlSerializer = new XmlSerializer(typeof(List<PluginDatastore>));

            Plugins = (List<PluginDatastore>)xmlSerializer.Deserialize(new StringReader(strSource));
        }

        public void ParseOfflinePluginVersioning(PluginVersioning onlineVersion)
        {
            foreach (var plugin in onlineVersion.Plugins)
            {
                var offlinePlugin = new PluginDatastore();

                var strPluginNamesRaw = plugin.DownloadPath.Split('/');
                var strPluginName = strPluginNamesRaw[strPluginNamesRaw.Length - 1];

                offlinePlugin.DownloadPath = Path.Combine(Application.StartupPath, "Plugins", strPluginName);
                if (File.Exists(offlinePlugin.DownloadPath))
                {
                    offlinePlugin.Name = Path.GetFileNameWithoutExtension(offlinePlugin.DownloadPath);

                    if (offlinePlugin.DownloadPath.EndsWith(".lang"))
                    {
                        using (var sr = new StreamReader(offlinePlugin.DownloadPath))
                        {
                            var strVersionLine = sr.ReadLine();

                            if (strVersionLine != null)
                                offlinePlugin.Version = strVersionLine.Substring(1);
                        }
                    }

                    else
                    {
                        offlinePlugin.Version = FileVersionInfo.GetVersionInfo(offlinePlugin.DownloadPath).FileVersion;
                    }

                    Plugins.Add(offlinePlugin);
                }
            }
        }

    }
}
