using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;
using _ = Utilities.InfoManager.InfoManager;

namespace AnotherSc2Hack.Classes.DataStructures.Preference
{
    public class PreferenceManager
    {
        private readonly LanguageString _lstrContributionTitle = new LanguageString("lstrContributionTitle", "Contribution");
        private readonly LanguageString _lstrContributionText = new LanguageString("lstrContributionText", "Looks like you've been using this tool\nfor quite a while. If you like it you can\ncontribute to the project by translations,\ndonations or bug reports.\n\nDo you want to contribute?");
        private readonly LanguageString _lstrWriteErrorTitle = new LanguageString("lstrWriteErrorTitle", "Write error");
        private readonly LanguageString _lstrWriteErrorText = new LanguageString("lstrWriteErrorText", "Couldn't write the settings properly.\nPlease try again!");

        public PreferenceAll PreferenceAll { get; private set; }
        private readonly XmlSerializer _xmlSerializer;

        public PreferenceManager()
        {
            _.Info("Load Preference Manager", _.InfoImportance.Important);

            PreferenceAll = new PreferenceAll();
            _xmlSerializer = new XmlSerializer(PreferenceAll.GetType());

            Read();
        }

        public void Read()
        {
            _.Info("Attempt To Read Existing Settings", _.InfoImportance.Important);

            if (!File.Exists(Constants.StrXmlPreferences))
            {
                _.Info("No Existing Settings Found");
                PreferenceAll.ConvertOldSettings();
                return;
            }

            PreferenceAll.OverlayAlert.UnitIds.Clear();
            PreferenceAll = (PreferenceAll)_xmlSerializer.Deserialize(new StreamReader(Constants.StrXmlPreferences));

            _.Info("Read Of Existing Settings Successful", _.InfoImportance.Important);
        }

        public bool Write()
        {
            _.Info("Attempt To Write Settings To File", _.InfoImportance.Important);

            PreferenceAll.Global.ApplicationCallCounter += 1;

            try
            {
                _xmlSerializer.Serialize(new StreamWriter(Constants.StrXmlPreferences), PreferenceAll);
            }

            catch (IOException)
            {
                //Get's called when two instances close at once
                _.Info("IO Exceptions Found (Do You Try To Close 2 Programs At Once?)", _.InfoImportance.Important);
                new AnotherMessageBox().Show(_lstrWriteErrorText.Text, _lstrWriteErrorTitle.Text);
                return false;
            }

            catch (Exception ex)
            {
                //This shouldn't happen
                _.Info("Generic Exceptions Found - Nothing is Saved", _.InfoImportance.Important);
                throw ex;
            }

            //Remove legacy settings
            if (File.Exists(Constants.StrDummyPref))
                File.Delete(Constants.StrDummyPref);

            return true;
        }

        public void Restore()
        {
            _.Info("Restore Default Settings", _.InfoImportance.Important);

            PreferenceAll = new PreferenceAll();

            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.PbDarkshrine);
            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.PuDarktemplar);
            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.PuOracle);
            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.PuVoidray);
            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.PuWarpprismTransport);
            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.TuBanshee);
            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.TuReaper);
            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.TuWidowMine);
            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.TuMedivac);
            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.ZbBanelingNest);
            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.ZuBaneling);
            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.ZuMutalisk);
            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.ZbSpire);
            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.ZuInfestor);
            PreferenceAll.OverlayAlert.UnitIds.Add(PredefinedTypes.UnitId.ZbHive);
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
