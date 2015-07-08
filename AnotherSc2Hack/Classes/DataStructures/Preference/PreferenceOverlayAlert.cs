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
            ShowAlert = true;
            Time = 5;
            SoundNotification = true;
            ElementName = "ShowAlert";
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool ShowAlert { get; set; }
        public int Time { get; set; }
        public bool SoundNotification { get; set; }
    }
}
