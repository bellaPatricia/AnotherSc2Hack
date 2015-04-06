namespace AnotherSc2Hack.Classes.DataStructures.Preference
{
    public class PreferenceOverlayPersonalApm : PreferenceBase
    {
        public PreferenceOverlayPersonalApm()
        {
            X = 50;
            Y = 50;
            Width = 200;
            Height = 50;
            EnableAlert = true;
            ApmAlertLimit = 100;
            ElementName = "PersonalApm";
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool EnableAlert { get; set; }
        public int ApmAlertLimit { get; set; }
    }
}
