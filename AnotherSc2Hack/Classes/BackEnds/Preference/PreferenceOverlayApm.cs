using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.BackEnds.Preference
{
    public class PreferenceOverlayApm : PreferenceBaseOverlay
    {
        public PreferenceOverlayApm()
        {
            Hotkey3 = Keys.NumPad7;
            TogglePanel = "/apm";
            ChangePosition = "/acp";
            ChangeSize = "/acs";
            Width = 600;
            Height = 50;
            ElementName = "OverlayApm";
        }
    }
}
