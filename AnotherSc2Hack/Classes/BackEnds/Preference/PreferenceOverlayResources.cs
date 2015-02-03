using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.BackEnds.Preference
{
    public class PreferenceOverlayResources : PreferenceBaseOverlay
    {
        public PreferenceOverlayResources()
        {
            Hotkey3 = Keys.NumPad1;
            TogglePanel = "/res";
            ChangePosition = "/rcp";
            ChangeSize = "/rcs";
            Width = 600;
            Height = 50;
            ElementName = "OverlayResources";
        }
    }
}
