using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.BackEnds
{
    class Constants
    {
        public static string StrPluginFolder = Application.StartupPath + "\\Plugins\\";
        public static string StrAlertsSettings = Application.StartupPath + "\\Alerts.dat";
        public static string StrPreferencesFile = Application.StartupPath + "\\Preferences.dat";
        public static string StrLogFile = Application.StartupPath + "\\AnotherLogFile.rtf";
        public static string StrUpdateManager = Application.StartupPath + "\\Sc2Hack UpdateManager.exe";
        public static string StrDownloadManager = Application.StartupPath + "\\AnotherSc2Hack DownloadManager.exe";
        public static string StrPluginInterface = Application.StartupPath + "\\PluginInterface.dll";
        public static string StrPredefinedTypes = Application.StartupPath + "\\PredefinedTypes.dll";
        public static string StrXmlPreferences = Application.StartupPath + "\\Settings.xml";
        public static Random RndRandom = new Random();
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
        public static string StrStarcraft2ProcessName = "SC2";
        public static string[] StrRedundantSigns = { "\r", " = " };
        public static string StrDummyPref = Application.StartupPath + "\\dPreferences.dat";
        public static string StrPreferenceKeywordResource = "Resource";
        public static string StrPreferenceKeywordIncome = "Income";
        public static string StrPreferenceKeywordWorker = "Worker";
        public static string StrPreferenceKeywordApm = "Apm";
        public static string StrPreferenceKeywordArmy = "Army";
        public static string StrPreferenceKeywordUnitTab = "UnitTab";
        public static string StrPreferenceKeywordProdTab = "Production";
        public static string StrPreferenceKeywordMaphack = "Maphack";
        public static string StrPreferenceKeywordMaphackUnits = "Maphack Units";
        public static string StrPreferenceKeywordGlobal = "Global";
        public static string StrPreferenceKeywordVarious = "Various";
        public static string StrPreferenceKeywordWorkerAutomation = "Worker Automation";
        public static string StrUpdaterPath = Application.StartupPath + "\\Sc2Hack UpdateManager.exe";
        public static string StrLanguageFolder = Application.StartupPath + "\\Language\\";
        public static string StrFontFamilyNameMonospace = "DejaVu Sans Mono";

        public static char ChrLanguageSplitSign = ':';
        public static char ChrLanguageControlSplitSign = '#';
        public static string StrPreferenceRemoveAi = "Remove Ai";
        public static string StrPreferenceRemoveLocalplayer = "Remove Localplayer";
        public static string StrPreferenceRemoveNeutral = "Remove Neutral";
        public static string StrPreferenceRemoveAllie = "Remove Allie";
        public static string StrPreferenceRemoveClanTag = "Remove ClanTag";
        public static string StrPreferenceDisableBackground = "Draw Background";
        public static string StrPreferencePosX = "PosX";
        public static string StrPreferencePosY = "PosY";
        public static string StrPreferenceWidth = "Width";
        public static string StrPreferenceHeight = "Height";
        public static string StrPreferenceOpacity = "Opacity";
        public static string StrPreferenceHotkey1 = "Hotkey 1";
        public static string StrPreferenceHotkey2 = "Hotkey 2";
        public static string StrPreferenceHotkey3 = "Hotkey 3";
        public static String StrPreferenceOnOffText = "On/Off Text";
        public static string StrPreferenceChangePositionText = "Change Position Text";
        public static string StrPreferenceChangeSizeText = "Change Size Text";
        public static string StrPreferenceFontText = "FontName";

        /* Stuff to get the information from SC2Ranks.com */
        public static string StrWebSpacer = "<div class=\"spacer\">";
        public static string StrWebLeague = "<span class=\"badge";
        public static string StrWebPoints = "<td class=\"summary topborder\" colspan=\"2\"><span class=\"number\">";
        public static string StrWebRankInDiv = "Rank <span class=\"number\">";

        public static string StrWebLeagueTerm = "\">";
        public static string StrWebPointsTerm = "</span>";
        public static string StrWebRankInDivTerm = "</span>";

        public class TooltipConsts
        {
            public static string StrRefreshrateTitle = "Refreshrate";
            public static string StrRefreshrate = "Attention, setting\n" +
                                                  "the refreshrate below\n" +
                                                  "47 ms has no effect.\n" +
                                                  "47 ms equals ~21 FPS\n" +
                                                  "which is enough to get\n" +
                                                  "a \"smoothing\" effect";

            public static string StrOnlyDigitsTitle = "Digits";
            public static string StrOnlyDigits = "Attention, you must enter\n" +
                                                 "digits in this box!\n\0";

            public static string StrDoNotEditTitle = "Do not Edit";
            public static string StrDoNotEdit = "Attention, writing manually\n" +
                                                "into this box will screw up\n" +
                                                "the saving and loading mechanism\n" +
                                                "and will probably result in\n" +
                                                "a broken application!";

            public static Int32 IremoveTime = 3000;
        }
    }
}
