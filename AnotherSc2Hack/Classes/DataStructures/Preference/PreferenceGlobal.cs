using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.DataStructures.Preference
{
    public class PreferenceGlobal : PreferenceBase
    {
        public int DataRefresh { get; set; }
        public int DrawingRefresh { get; set; }
        public string Language { get; set; }
        public Keys ChangeSizeAndPosition { get; set; }
        public bool DrawOnlyInForeground { get; set; }

        public PreferenceGlobal()
        {
            DataRefresh = 100;
            DrawingRefresh = 100;
            Language = "English";
            ChangeSizeAndPosition = Keys.NumPad0;
            ElementName = "Global";
        }
    }
}
