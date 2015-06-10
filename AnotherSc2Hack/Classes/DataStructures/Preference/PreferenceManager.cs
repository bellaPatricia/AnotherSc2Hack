using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;

namespace AnotherSc2Hack.Classes.DataStructures.Preference
{
    public class PreferenceManager
    {
        private readonly LanguageString _lstrContributionTitle = new LanguageString("lstrContributionTitle", "Contribution");
        private readonly LanguageString _lstrContributionText = new LanguageString("lstrContributionText", "Looks like you've been using this tool\nfor quite a while. If you like it you can\ncontribute to the project by translations,\ndonations or bug reports.\n\nDo you want to contribute?");

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
            PreferenceAll.Global.ApplicationCallCounter += 1;

            _xmlSerializer.Serialize(new StreamWriter(Constants.StrXmlPreferences), PreferenceAll);

            if (File.Exists(Constants.StrDummyPref))
                File.Delete(Constants.StrDummyPref);
        }

        public void Restore()
        {
            PreferenceAll = new PreferenceAll();
        }

        public bool AskForDonation()
        {
            if (!PreferenceAll.Global.ApplicationAskedForDonation && PreferenceAll.Global.ApplicationCallCounter > 50)
            {
                var result = new AnotherMessageBox().Show(_lstrContributionText.Text, _lstrContributionTitle.Text,
                    MessageBoxButtons.YesNo);

                PreferenceAll.Global.ApplicationAskedForDonation = true;

                if (result == DialogResult.Yes)
                    return true;
            }

            return false;
        }
    }
}
