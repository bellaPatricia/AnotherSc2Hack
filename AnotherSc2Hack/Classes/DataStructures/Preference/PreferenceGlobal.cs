using System.Windows.Forms;
using System.Drawing;
using _ = Utilities.InfoManager.InfoManager;

namespace AnotherSc2Hack.Classes.DataStructures.Preference
{
    public class PreferenceGlobal : PreferenceBase
    {
        public int DataRefresh { get; set; }
        public int DrawingRefresh { get; set; }
        public string Language { get; set; }
        public Keys ChangeSizeAndPosition { get; set; }
        public bool DrawOnlyInForeground { get; set; }
        public int ApplicationCallCounter { get; set; }
        public bool ApplicationAskedForDonation { get; set; }
        public bool ApplicationShowWebContent { get; set; }
        public string ApplicationLastOpenedPanel { get; set; }
        public Size ApplicationSize { get; set; }

        public PreferenceGlobal()
        {
            _.Info("Initialize Global Settings With Default Values", _.InfoImportance.NotImportant);

            DataRefresh = 100;
            DrawingRefresh = 100;
            Language = "English";
            ChangeSizeAndPosition = Keys.NumPad0;
            ElementName = "Global";
            ApplicationCallCounter = 0;
            ApplicationAskedForDonation = false;
            ApplicationShowWebContent = true;
            ApplicationLastOpenedPanel = "cpnlApplication";
            ApplicationSize = new Size(0,0);
        }
    }
}
