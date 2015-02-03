using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.DataStructures.Preference
{
    public class PreferenceBaseOverlay : PreferenceBase
    {
        public PreferenceBaseOverlay()
        {
            Hotkey1 = Keys.ControlKey;
            Hotkey2 = Keys.Menu;
            FontName = "Century Gothic";
            DrawBackground = true;
            Opacity = 100;
            ElementName = "Overlays";
        }

        public Keys Hotkey1 { get; set; }
        public Keys Hotkey2 { get; set; }
        public Keys Hotkey3 { get; set; }
        public string TogglePanel { get; set; }
        public string ChangePosition { get; set; }
        public string ChangeSize { get; set; }
        public string FontName { get; set; }
        public bool DrawBackground { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public double Opacity { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool RemoveAi { get; set; }
        public bool RemoveAllie { get; set; }
        public bool RemoveNeutral { get; set; }
        public bool RemoveClanTag { get; set; }
        public bool RemoveLocalplayer { get; set; }
    }
}
