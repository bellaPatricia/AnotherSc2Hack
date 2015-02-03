using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.DataStructures.Xml;
using Predefined;

namespace AnotherSc2Hack.Classes.DataStructures.Preference
{
    public class PreferenceOverlayMaphack : PreferenceBase
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
        public bool RemoveAi { get; set; }
        public bool RemoveAllie { get; set; }
        public bool RemoveNeutral { get; set; }
        public bool RemoveLocalplayer { get; set; }
        public bool RemoveDestinationLine { get; set; }
        public Color DestinationLine { get; set; }
        public bool ColorDefensifeStructures { get; set; }
        public bool RemoveVisionArea { get; set; }
        public bool RemoveCamera { get; set; }
        public List<XmlColor> UnitColors { get; set; }
        public List<PredefinedData.UnitId> UnitIds { get; set; }



        public PreferenceOverlayMaphack()
        {
            Hotkey1 = Keys.ControlKey;
            Hotkey2 = Keys.Menu;
            Hotkey3 = Keys.NumPad5;
            TogglePanel = "/map";
            ChangePosition = "/mcp";
            ChangeSize = "/mcs";
            Width = 261;
            Height = 255;
            ColorDefensifeStructures = true;
            DestinationLine = Color.Yellow;
            ElementName = "OverlayMaphack";
            UnitColors = new List<XmlColor>();
            UnitIds = new List<PredefinedData.UnitId>();
        }
    }
}
