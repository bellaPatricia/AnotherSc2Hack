using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.BackEnds.Preference
{
    public class PreferenceOverlayWorker : PreferenceBase
    {
        public Keys Hotkey1 { get; set; }
        public Keys Hotkey2 { get; set; }
        public Keys Hotkey3 { get; set; }
        public string TogglePanel { get; set; }
        public string ChangePosition { get; set; }
        public string ChangeSize{ get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string FontName { get; set; }



        public PreferenceOverlayWorker()
        {
            Hotkey1 = Keys.ControlKey;
            Hotkey2 = Keys.Menu;
            Hotkey3 = Keys.NumPad3;
            TogglePanel = "/wor";
            ChangePosition = "/wcp";
            ChangeSize = "/wcs";
            FontName = "Century Gothic";
            Width = 200;
            Height = 50;
            ElementName = "OverlayWorker";
        }
    }
}
