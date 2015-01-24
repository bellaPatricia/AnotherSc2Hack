using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.BackEnds.Preference
{
    public class PreferenceOverlayProduction : PreferenceBaseOverlay
    {
        public bool RemoveChronoboost { get; set; }
        public bool SplitBuildingsAndUnits { get; set; }
        public bool ShowBuildings { get; set; }
        public bool ShowUnits { get; set; }
        public bool ShowUpgrades { get; set; }
        public bool UseTransparentImages { get; set; }
        public int PictureSize { get; set; }

        public PreferenceOverlayProduction()
        {
            Hotkey3 = Keys.NumPad4;
            TogglePanel = "/pro";
            ChangePosition = "/pcp";
            ChangeSize = "/pcs";
            Width = 300;
            Height = 50;
            SplitBuildingsAndUnits = true;
            ShowBuildings = true;
            ShowUnits = true;
            ShowUpgrades = true;
            UseTransparentImages = true;
            PictureSize = 45;
        }
    }
}
