using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.BackEnds.Preference
{
    public class PreferenceOverlayUnits : PreferenceBaseOverlay
    {
        public bool RemoveProductionLine { get; set; }
        public bool RemoveChronoboost { get; set; }
        public bool RemoveSpellCounter { get; set; }
        public bool SplitBuildingsAndUnits { get; set; }
        public bool ShowBuildings { get; set; }
        public bool ShowUnits { get; set; }
        public bool UseTransparentImages { get; set; }
        public int PictureSize { get; set; }

        public PreferenceOverlayUnits()
        {
            Hotkey3 = Keys.NumPad9;
            TogglePanel = "/uni";
            ChangePosition = "/ucp";
            ChangeSize = "/ucs";
            Width = 300;
            Height = 50;
            SplitBuildingsAndUnits = true;
            ShowBuildings = true;
            ShowUnits = true;
            UseTransparentImages = true;
            PictureSize = 45;
        }
    }
}
