using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.BackEnds
{
    class Constants
    {
        public static String StrPluginFolder = Application.StartupPath + "\\Plugins\\";
        public static String StrAlertsSettings = Application.StartupPath + "\\Alerts.dat";
        public static String StrPreferencesFile = Application.StartupPath + "\\Preferences.dat";
        public static String StrLogFile = Application.StartupPath + "\\AnotherLogFile.rtf";
        public static String StrUpdateManager = Application.StartupPath + "\\Sc2Hack UpdateManager.exe";
        public static String StrPluginInterface = Application.StartupPath + "\\PluginInterface.dll";
        public static String StrPredefinedTypes = Application.StartupPath + "\\PredefinedTypes.dll";
        public static Pen PBlack1 = new Pen(Brushes.Black, 1);
        public static Pen PBlack2 = new Pen(Brushes.Black, 2);
        public static Pen PBlack3 = new Pen(Brushes.Black, 3);
        public static Pen PBlack4 = new Pen(Brushes.Black, 4);
        public static Pen PBlack5 = new Pen(Brushes.Black, 5);
        public static Pen PGray1 = new Pen(Brushes.Gray, 1);
        public static Pen PGray2 = new Pen(Brushes.Gray, 2);
        public static Pen PGray3 = new Pen(Brushes.Gray, 3);
        public static Pen PGray4 = new Pen(Brushes.Gray, 4);
        public static Pen PGray5 = new Pen(Brushes.Gray, 5);
        public static Pen PRed2 = new Pen(Brushes.Red, 2);
        public static Pen PYellowGreen2 = new Pen(Brushes.YellowGreen, 2);
        public static Pen PBound = new Pen(Brushes.Black);
        public static Pen PArea = new Pen(Brushes.Red);
        public static Font FArial1 = new Font("Arial", 12, FontStyle.Bold);
        public static Font FCenturyGothic12 = new Font("Centruy Gothic", 12, FontStyle.Regular);
        public static String StrStarcraft2ProcessName = "SC2";
        public static String[] StrRedundantSigns = {"\r", " = "};
        public static String StrDummyPref = Application.StartupPath + "\\dPreferences.dat";
        public static String StrPreferenceKeywordResource = "Resource";
        public static String StrPreferenceKeywordIncome = "Income";
        public static String StrPreferenceKeywordWorker = "Worker";
        public static String StrPreferenceKeywordApm = "Apm";
        public static String StrPreferenceKeywordArmy = "Army";
        public static String StrPreferenceKeywordUnitTab = "UnitTab";
        public static String StrPreferenceKeywordProdTab = "Production";
        public static String StrPreferenceKeywordMaphack = "Maphack";
        public static String StrPreferenceKeywordMaphackUnits = "Maphack Units";
        public static String StrPreferenceKeywordGlobal = "Global";
        public static String StrPreferenceKeywordVarious = "Various";
        public static String StrPreferenceKeywordWorkerAutomation = "Worker Automation";
        public static String StrUpdaterPath = Application.StartupPath + "\\Sc2Hack UpdateManager.exe";
        public static String StrFontFamilyNameMonospace = "DejaVu Sans Mono";

        public static String StrPreferenceRemoveAi = "Remove Ai";
        public static String StrPreferenceRemoveLocalplayer = "Remove Localplayer";
        public static String StrPreferenceRemoveNeutral = "Remove Neutral";
        public static String StrPreferenceRemoveAllie = "Remove Allie";
        public static String StrPreferenceRemoveClanTag = "Remove ClanTag";
        public static String StrPreferenceDisableBackground = "Draw Background";
        public static String StrPreferencePosX = "PosX";
        public static String StrPreferencePosY = "PosY";
        public static String StrPreferenceWidth = "Width";
        public static String StrPreferenceHeight = "Height";
        public static String StrPreferenceOpacity = "Opacity";
        public static String StrPreferenceHotkey1 = "Hotkey 1";
        public static String StrPreferenceHotkey2 = "Hotkey 2";
        public static String StrPreferenceHotkey3 = "Hotkey 3";
        public static String StrPreferenceOnOffText = "On/Off Text";
        public static String StrPreferenceChangePositionText = "Change Position Text";
        public static String StrPreferenceChangeSizeText = "Change Size Text";
        public static String StrPreferenceFontText = "FontName";

        /* Stuff to get the information from SC2Ranks.com */
        public static String StrWebSpacer = "<div class=\"spacer\">";
        public static String StrWebLeague = "<span class=\"badge";
        public static String StrWebPoints = "<td class=\"summary topborder\" colspan=\"2\"><span class=\"number\">";
        public static String StrWebRankInDiv = "Rank <span class=\"number\">";

        public static String StrWebLeagueTerm = "\">";
        public static String StrWebPointsTerm = "</span>";
        public static String StrWebRankInDivTerm = "</span>";

        public class TooltipConsts
        {
            public static String StrRefreshrateTitle = "Refreshrate";
            public static String StrRefreshrate = "Attention, setting\n" +
                                                  "the refreshrate below\n" +
                                                  "47 ms has no effect.\n" +
                                                  "47 ms equals ~21 FPS\n" +
                                                  "which is enough to get\n" +
                                                  "a \"smoothing\" effect";

            public static String StrOnlyDigitsTitle = "Digits";
            public static String StrOnlyDigits = "Attention, you must enter\n" +
                                                 "digits in this box!\n\0";

            public static String StrDoNotEditTitle = "Do not Edit";
            public static String StrDoNotEdit = "Attention, writing manually\n" +
                                                "into this box will screw up\n" +
                                                "the saving and loading mechanism\n" +
                                                "and will probably result in\n" +
                                                "a broken application!";

            public static Int32 IremoveTime = 3000;
        }
    }
}
