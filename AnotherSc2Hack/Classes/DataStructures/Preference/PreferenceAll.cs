namespace AnotherSc2Hack.Classes.DataStructures.Preference
{
    public class PreferenceAll
    {
        public PreferenceGlobal Global { get; set; }
        public PreferenceOverlayResources OverlayResources { get; set; }
        public PreferenceOverlayWorker OverlayWorker { get; set; }
        public PreferenceOverlayUnits OverlayUnits { get; set; }
        public PreferenceOverlayProduction OverlayProduction { get; set; }
        public PreferenceOverlayIncome OverlayIncome { get; set; }
        public PreferenceOverlayArmy OverlayArmy { get; set; }
        public PreferenceOverlayApm OverlayApm { get; set; }
        public PreferenceOverlayMaphack OverlayMaphack { get; set; }
        public PreferenceOverlayPersonalApm OverlayPersonalApm { get; set; }
        public PreferenceOverlayPersonalClock OverlayPersonalClock { get; set; }

        public PreferenceAll()
        {
            Global = new PreferenceGlobal();
            OverlayResources = new PreferenceOverlayResources();
            OverlayIncome = new PreferenceOverlayIncome();
            OverlayWorker = new PreferenceOverlayWorker();
            OverlayApm = new PreferenceOverlayApm();
            OverlayArmy = new PreferenceOverlayArmy();
            OverlayProduction = new PreferenceOverlayProduction();
            OverlayUnits = new PreferenceOverlayUnits();
            OverlayMaphack = new PreferenceOverlayMaphack();
            OverlayPersonalApm = new PreferenceOverlayPersonalApm();
            OverlayPersonalClock = new PreferenceOverlayPersonalClock();
        }
    }

    
}
