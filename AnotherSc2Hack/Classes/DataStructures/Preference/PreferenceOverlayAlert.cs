using System.Collections.Generic;
using PredefinedTypes;

namespace AnotherSc2Hack.Classes.DataStructures.Preference
{
    public class PreferenceOverlayAlert : PreferenceBase
    {
        public PreferenceOverlayAlert()
        {
            X = 300;
            Y = 50;
            Width = 200;
            Height = 200;
            IconHeight = 50;
            IconWidth = 50;
            ShowAlert = true;
            Time = 5;
            SoundNotification = true;
            ElementName = "ShowAlert";
            UnitIds = new HashSet<UnitId>();
            UnitIds.Add(UnitId.PuProbe);

        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int IconWidth { get; set; }
        public int IconHeight { get; set; }
        public bool ShowAlert { get; set; }
        public int Time { get; set; }
        public bool SoundNotification { get; set; }
        public HashSet<UnitId> UnitIds { get; set; }
    }
}
