﻿using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.DataStructures.Preference
{
    public class PreferenceOverlayIncome : PreferenceBaseOverlay
    {
        public PreferenceOverlayIncome()
        {
            Hotkey3 = Keys.NumPad2;
            TogglePanel = "/inc";
            ChangePosition = "/icp";
            ChangeSize = "/ics";
            Width = 600;
            Height = 50;
            ElementName = "OverlayIncome";
        }
    }
}
