namespace AnotherSc2Hack.Classes.DataStructures.Preference
{
    public class PreferenceWorkerCoach : PreferenceBase
    {
        public PreferenceWorkerCoach()
        {
            X = 0;
            Y = 0;
            Height = 126;
            Width = 250;
            DisableAfter = 12;
            WorkerCoach = true;
            ElementName = "WorkerCoach";
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int DisableAfter { get; set; }
        public bool WorkerCoach { get; set; }
    }
}
