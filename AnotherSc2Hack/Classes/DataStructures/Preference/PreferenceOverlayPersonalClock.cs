namespace AnotherSc2Hack.Classes.DataStructures.Preference
{
    public class PreferenceOverlayPersonalClock : PreferenceBase
    {
        public PreferenceOverlayPersonalClock()
        {
            X = 300;
            Y = 50;
            Width = 200;
            Height = 50;
            Use24Format = true;
            ElementName = "PersonalClock";
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Use24Format { get; set; }
    }
}
