using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.DataStructures.Preference
{
    public class PreferenceManager
    {
        public PreferenceAll PreferenceAll { get; private set; }
        private readonly XmlSerializer _xmlSerializer;

        public PreferenceManager()
        {
            PreferenceAll = new PreferenceAll();
            _xmlSerializer = new XmlSerializer(PreferenceAll.GetType());

            Read();
        }

        public void Read()
        {
            if (!File.Exists(Constants.StrXmlPreferences))
            {
                PreferenceAll.ConvertOldSettings();
                return;
            }

            PreferenceAll = (PreferenceAll)_xmlSerializer.Deserialize(new StreamReader(Constants.StrXmlPreferences));
        }

        public void Write()
        {
            _xmlSerializer.Serialize(new StreamWriter(Constants.StrXmlPreferences), PreferenceAll);

            if (File.Exists(Constants.StrDummyPref))
                File.Delete(Constants.StrDummyPref);
        }
    }
}
