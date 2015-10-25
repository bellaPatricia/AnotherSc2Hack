using System.IO;
using System.Xml.Serialization;

namespace DataSimulator
{
    public static class ConfigurationManager
    {
        public static Configuration Config { get; private set; } = new Configuration();

        public static  void ReadConfig()
        {
            Configuration config;

            if (File.Exists(Constants.SettingsFile))
            {
                var serializer = new XmlSerializer(typeof (Configuration));
                config = (Configuration) serializer.Deserialize(new StreamReader(Constants.SettingsFile));
            }

            else
            {
                config = Configuration.SetDefaultValues();
            }

            Config = config;
        }

        public static void WriteConfig()
        {
            var serializer = new XmlSerializer(typeof(Configuration));
            serializer.Serialize(new StreamWriter(Constants.SettingsFile), Config);
        }
    }
}
