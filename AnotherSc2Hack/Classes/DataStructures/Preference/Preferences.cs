using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using PredefinedTypes;

namespace AnotherSc2Hack.Classes.DataStructures.Preference
{
    public class Preferences : PreferencesStruct
    {
        public Preferences()
        {
            MaphackUnitColors = new List<Color>();
            MaphackUnitIds = new List<UnitId>();

            ReadPreferences();
        }

        public void WritePreferences()
        {

            if (File.Exists(Constants.StrDummyPref))
                File.Delete(Constants.StrDummyPref);

            var sw = new StreamWriter(Constants.StrDummyPref);

            #region Global

            sw.WriteLine("[Global]");
            sw.WriteLine(";Boolean");
            sw.WriteLine("DrawOnlyInForeground = " + GlobalDrawOnlyInForeground);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey Resize = " + GlobalChangeSizeAndPosition);
            sw.WriteLine(";Int32");
            sw.WriteLine("Data Refresh = " + GlobalDataRefresh);
            sw.WriteLine(";Int32");
            sw.WriteLine("Drawing Refresh = " + GlobalDrawingRefresh);
            WriteSubSetting(sw, GlobalLanguage, "Language");

            #endregion


            sw.WriteLine("");
            sw.WriteLine("");

            #region Resource

            sw.WriteLine("[Resource]");
            sw.WriteLine(";Int32");
            sw.WriteLine("PosX = " + ResourcePositionX.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("PosY = " + ResourcePositionY.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Width = " + ResourceWidth.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Height = " + ResourceHeight.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Ai = " + ResourceRemoveAi);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Neutral = " + ResourceRemoveNeutral);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Allie = " + ResourceRemoveAllie);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Localplayer = " + ResourceRemoveLocalplayer);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove ClanTag = " + ResourceRemoveClanTag);
            sw.WriteLine(";String");
            sw.WriteLine("FontName = " + ResourceFontName);
            sw.WriteLine(";float");
            sw.WriteLine("Opacity = " + ResourceOpacity);
            sw.WriteLine(";String");
            sw.WriteLine("On/Off Text = " + ResourceTogglePanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Position Text = " + ResourceChangePositionPanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Size Text = " + ResourceChangeSizePanel);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 1 = " + ResourceHotkey1);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 2 = " + ResourceHotkey2);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 3 = " + ResourceHotkey3);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Draw Background = " + ResourceDrawBackground);

            #endregion


            sw.WriteLine("");
            sw.WriteLine("");

            #region Income

            sw.WriteLine("[Income]");
            sw.WriteLine(";Int32");
            sw.WriteLine("PosX = " + IncomePositionX.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("PosY = " + IncomePositionY.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Width = " + IncomeWidth.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Height = " + IncomeHeight.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Ai = " + IncomeRemoveAi);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Neutral = " + IncomeRemoveNeutral);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Allie = " + IncomeRemoveAllie);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Localplayer = " + IncomeRemoveLocalplayer);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove ClanTag = " + IncomeRemoveClanTag);
            sw.WriteLine(";String");
            sw.WriteLine("FontName = " + IncomeFontName);
            sw.WriteLine(";float");
            sw.WriteLine("Opacity = " + IncomeOpacity);
            sw.WriteLine(";String");
            sw.WriteLine("On/Off Text = " + IncomeTogglePanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Position Text = " + IncomeChangePositionPanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Size Text = " + IncomeChangeSizePanel);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 1 = " + IncomeHotkey1);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 2 = " + IncomeHotkey2);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 3 = " + IncomeHotkey3);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Draw Background = " + IncomeDrawBackground);

            #endregion


            sw.WriteLine("");
            sw.WriteLine("");

            #region Apm

            sw.WriteLine("[Apm]");
            sw.WriteLine(";Int32");
            sw.WriteLine("PosX = " + ApmPositionX.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("PosY = " + ApmPositionY.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Width = " + ApmWidth.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Height = " + ApmHeight.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Ai = " + ApmRemoveAi);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Neutral = " + ApmRemoveNeutral);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Allie = " + ApmRemoveAllie);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Localplayer = " + ApmRemoveLocalplayer);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove ClanTag = " + ApmRemoveClanTag);
            sw.WriteLine(";String");
            sw.WriteLine("FontName = " + ApmFontName);
            sw.WriteLine(";float");
            sw.WriteLine("Opacity = " + ApmOpacity);
            sw.WriteLine(";String");
            sw.WriteLine("On/Off Text = " + ApmTogglePanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Position Text = " + ApmChangePositionPanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Size Text = " + ApmChangeSizePanel);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 1 = " + ApmHotkey1);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 2 = " + ApmHotkey2);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 3 = " + ApmHotkey3);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Draw Background = " + ApmDrawBackground);

            #endregion


            sw.WriteLine("");
            sw.WriteLine("");

            #region Army

            sw.WriteLine("[Army]");
            sw.WriteLine(";Int32");
            sw.WriteLine("PosX = " + ArmyPositionX.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("PosY = " + ArmyPositionY.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Width = " + ArmyWidth.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Height = " + ArmyHeight.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Ai = " + ArmyRemoveAi);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Neutral = " + ArmyRemoveNeutral);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Allie = " + ArmyRemoveAllie);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Localplayer = " + ArmyRemoveLocalplayer);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove ClanTag = " + ArmyRemoveClanTag);
            sw.WriteLine(";String");
            sw.WriteLine("FontName = " + ArmyFontName);
            sw.WriteLine(";float");
            sw.WriteLine("Opacity = " + ArmyOpacity);
            sw.WriteLine(";String");
            sw.WriteLine("On/Off Text = " + ArmyTogglePanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Position Text = " + ArmyChangePositionPanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Size Text = " + ArmyChangeSizePanel);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 1 = " + ArmyHotkey1);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 2 = " + ArmyHotkey2);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 3 = " + ArmyHotkey3);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Draw Background = " + ArmyDrawBackground);

            #endregion


            sw.WriteLine("");
            sw.WriteLine("");

            #region Worker

            sw.WriteLine("[Worker]");
            sw.WriteLine(";Int32");
            sw.WriteLine("PosX = " + WorkerPositionX.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("PosY = " + WorkerPositionY.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Width = " + WorkerWidth.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Height = " + WorkerHeight.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";String");
            sw.WriteLine("FontName = " + WorkerFontName);
            sw.WriteLine(";float");
            sw.WriteLine("Opacity = " + WorkerOpacity);
            sw.WriteLine(";String");
            sw.WriteLine("On/Off Text = " + WorkerTogglePanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Position Text = " + WorkerChangePositionPanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Size Text = " + WorkerChangeSizePanel);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 1 = " + WorkerHotkey1);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 2 = " + WorkerHotkey2);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 3 = " + WorkerHotkey3);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Draw Background = " + WorkerDrawBackground);

            #endregion


            sw.WriteLine("");
            sw.WriteLine("");

            #region Various

            sw.WriteLine("[Various]");
            sw.WriteLine(";Boolean");
            sw.WriteLine("Apm Enable = " + PersonalApm);
            sw.WriteLine(";Boolean");
            sw.WriteLine("ApmAlert Enable = " + PersonalApmAlert);
            sw.WriteLine(";Int32");
            sw.WriteLine("ApmAlert Limit = " + PersonalApmAlertLimit.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("ApmPosX = " + PersonalApmPositionX.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("ApmPosY = " + PersonalApmPositionY.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("ApmWidth = " + PersonalApmWidth.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("ApmHeight = " + PersonalApmHeight.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Boolean");
            sw.WriteLine("Clock Enable = " + PersonalClock);
            sw.WriteLine(";Int32");
            sw.WriteLine("ClockPosX = " + PersonalClockPositionX.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("ClockPosY = " + PersonalClockPositionY.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("ClockWidth = " + PersonalClockWidth.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("ClockHeight = " + PersonalClockHeight.ToString(CultureInfo.InvariantCulture));

            #endregion

            sw.WriteLine("");
            sw.WriteLine("");

            #region UnitTab

            sw.WriteLine("[UnitTab]");
            sw.WriteLine(";Int32");
            sw.WriteLine("PosX = " + UnitTabPositionX.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("PosY = " + UnitTabPositionY.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Width = " + UnitTabWidth.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Height = " + UnitTabHeight.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Picture Size = " + UnitPictureSize.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Ai = " + UnitTabRemoveAi);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Neutral = " + UnitTabRemoveNeutral);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Allie = " + UnitTabRemoveAllie);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Localplayer = " + UnitTabRemoveLocalplayer);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Prod. Line = " + UnitTabRemoveProdLine);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove ClanTag = " + UnitTabRemoveClanTag);
            sw.WriteLine(";float");
            sw.WriteLine("Opacity = " + UnitTabOpacity);
            sw.WriteLine(";String");
            sw.WriteLine("FontName = " + UnitTabFontName);
            sw.WriteLine(";String");
            sw.WriteLine("On/Off Text = " + UnitTogglePanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Position Text = " + UnitChangePositionPanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Size Text = " + UnitChangeSizePanel);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 1 = " + UnitHotkey1);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 2 = " + UnitHotkey2);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 3 = " + UnitHotkey3);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Split Buildings/ Units = " + UnitTabSplitUnitsAndBuildings);
            WriteSubSetting(sw, UnitTabShowBuildings, "Show Buildings");
            WriteSubSetting(sw, UnitTabShowUnits, "Show Units");
            WriteSubSetting(sw, UnitTabRemoveChronoboost, "Remove Chronoboost");
            WriteSubSetting(sw, UnitTabRemoveSpellCounter, "Remove Spellcounter");
            WriteSubSetting(sw, UnitTabUseTransparentImages, "Use Transparent Images");


            #endregion


            sw.WriteLine("");
            sw.WriteLine("");

            #region Production

            sw.WriteLine("[Production]");
            sw.WriteLine(";Int32");
            sw.WriteLine("PosX = " + ProdTabPositionX.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("PosY = " + ProdTabPositionY.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Width = " + ProdTabWidth.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Height = " + ProdTabHeight.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Picture Size = " + ProdPictureSize.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Ai = " + ProdTabRemoveAi);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Neutral = " + ProdTabRemoveNeutral);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Allie = " + ProdTabRemoveAllie);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Localplayer = " + ProdTabRemoveLocalplayer);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove ClanTag = " + ProdTabRemoveClanTag);
            sw.WriteLine(";float");
            sw.WriteLine("Opacity = " + ProdTabOpacity);
            sw.WriteLine(";String");
            sw.WriteLine("FontName = " + ProdTabFontName);
            sw.WriteLine(";String");
            sw.WriteLine("On/Off Text = " + ProdTogglePanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Position Text = " + ProdChangePositionPanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Size Text = " + ProdChangeSizePanel);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 1 = " + ProdHotkey1);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 2 = " + ProdHotkey2);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 3 = " + ProdHotkey3);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Split Buildings/ Units = " + ProdTabSplitUnitsAndBuildings);
            WriteSubSetting(sw, ProdTabShowBuildings, "Show Buildings");
            WriteSubSetting(sw, ProdTabShowUnits, "Show Units");
            WriteSubSetting(sw, ProdTabShowUpgrades, "Show Upgrades");
            WriteSubSetting(sw, ProdTabRemoveChronoboost, "Remove Chronoboost");
            WriteSubSetting(sw, ProdTabUseTransparentImages, "Use Transparent Images");


            #endregion


            sw.WriteLine("");
            sw.WriteLine("");

            #region Maphack

            sw.WriteLine("[Maphack]");
            sw.WriteLine(";Int32");
            sw.WriteLine("PosX = " + MaphackPositionX.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("PosY = " + MaphackPositionY.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Width = " + MaphackWidth.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Int32");
            sw.WriteLine("Height = " + MaphackHeight.ToString(CultureInfo.InvariantCulture));
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Ai = " + MaphackRemoveAi);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Neutral = " + MaphackRemoveNeutral);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Allie = " + MaphackRemoveAllie);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Localplayer = " + MaphackRemoveLocalplayer);
            sw.WriteLine(";float");
            sw.WriteLine("Opacity = " + MaphackOpacity);
            sw.WriteLine(";String");
            sw.WriteLine("On/Off Text = " + MaphackTogglePanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Position Text = " + MaphackChangePositionPanel);
            sw.WriteLine(";String");
            sw.WriteLine("Change Size Text = " + MaphackChangeSizePanel);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 1 = " + MaphackHotkey1);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 2 = " + MaphackHotkey2);
            sw.WriteLine(";Keys");
            sw.WriteLine("Hotkey 3 = " + MaphackHotkey3);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Disable Destination Line = " + MaphackDisableDestinationLine);
            sw.WriteLine(";Color");
            sw.WriteLine("Destination Line Color = " + ColorTranslator.ToHtml(MaphackDestinationColor));
            sw.WriteLine(";Boolean");
            sw.WriteLine("Color Def Structures = " + MaphackColorDefensivestructuresYellow);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Vision Area = " + MaphackRemoveVisionArea);
            sw.WriteLine(";Boolean");
            sw.WriteLine("Remove Camera = " + MaphackRemoveCamera);

            #endregion


            sw.WriteLine("");
            sw.WriteLine("");

            #region WorkerAutomation

            sw.WriteLine("[Worker Automation]");
            WriteSubSetting(sw, WorkerAutomation, "Worker Automation");
            WriteSubSetting(sw, WorkerAutomationApmProtection, "Apm Protection");
            WriteSubSetting(sw, WorkerAutomationStartNextWorkerAt, "Start Next Worker At");
            WriteSubSetting(sw, WorkerAutomationAutoupgradeToOc, "Autoupgrade To Oc");
            WriteSubSetting(sw, WorkerAutomationBackupGroup, "Backup Key");
            WriteSubSetting(sw, WorkerAutomationDisableWhenSelecting, "Selecting");
            WriteSubSetting(sw, WorkerAutomationDisableWhenWorkerIsSelected, "Worker Selected");
            WriteSubSetting(sw, WorkerAutomationHotkey1, Constants.StrPreferenceHotkey1);
            WriteSubSetting(sw, WorkerAutomationHotkey2, Constants.StrPreferenceHotkey2);
            WriteSubSetting(sw, WorkerAutomationHotkey3, Constants.StrPreferenceHotkey3);
            WriteSubSetting(sw, WorkerAutomationMainbuildingGroup, "Mainbuilding Key");
            WriteSubSetting(sw, WorkerAutomationMaximumWorkers, "Maximum Workers in game");
            WriteSubSetting(sw, WorkerAutomationMaximumWorkersPerBase, "Maximum Workers per Base");
            WriteSubSetting(sw, WorkerAutomationModeDirect, "Direct Mode");
            WriteSubSetting(sw, WorkerAutomationModeRound, "Round Mode");
            WriteSubSetting(sw, WorkerAutomationOrbitalKey, "Orbital Key");
            WriteSubSetting(sw, WorkerAutomationProbeKey, "Probe Key");
            WriteSubSetting(sw, WorkerAutomationPufferWorker, "Worker Puffer");
            WriteSubSetting(sw, WorkerAutomationScvKey, "Scv Key");



            #endregion

            sw.WriteLine("");
            sw.WriteLine("");

            #region Maphack UnitIds

            sw.WriteLine("[Maphack Units]");

            if (MaphackUnitIds == null)
            {
                sw.Close();
                return;
            }

            if (MaphackUnitIds.Count <= 0)
            {
                sw.Close();
                return;
            }

            for (var i = 0; i < MaphackUnitIds.Count; i++)
            {
                sw.WriteLine(";UnitId");
                sw.WriteLine("UnitId = " + MaphackUnitIds[i]);
                sw.WriteLine(";Color");
                sw.WriteLine("Unit Color = " + ColorTranslator.ToHtml(MaphackUnitColors[i]));
            }

            #endregion

            sw.Close();
        }

        public void ReadPreferences()
        {
            #region Initialize variables for settings which are not called

            var bLanguage = false;

            var bResourceRemoveClanTagSet = false;
            var bIncomeRemoveClanTagSet = false;
            var bApmRemoveClanTagSet = false;
            var bArmyRemoveClanTagSet = false;
            var bUnitTabRemoveClanTagSet = false;
            var bUnitTabPictureSizeSet = false;
            var bUnitTabFontNameSet = false;
            var bUnitTabRemoveProdLineSet = false;
            var bUnitTabShowUnits = false;
            var bUnitTabShowBuildings = false;
            var bUnitTabChronoboost = false;
            var bUnitTabSpellCounter = false;

            var bProdTabPositionXSet = false;
            var bProdTabPositionYSet = false;
            var bProdTabWidthSet = false;
            var bProdTabHeightSet = false;
            var bProdTabFontNameSet = false;
            var bProdTabRemoveClanTagSet = false;
            var bProdTabPictureSizeSet = false;
            var bProdTabHotkey1Set = false;
            var bProdTabHotkey2Set = false;
            var bProdTabHotkey3Set = false;
            var bProdTabShortcutTgSet = false;
            var bProdTabShortcutCsSet = false;
            var bProdTabShortcutCpSet = false;
            var bProdTabRemAiSet = false;
            var bProdTabRemLocalplayerSet = false;
            var bProdTabRemNeutralSet = false;
            var bProdTabRemAllieSet = false;
            var bProdTabSplitBuilldingsSet = false;
            var bProdTabOpacitySet = false;
            var bProdTabShowUnits = false;
            var bProdTabShowBuildings = false;
            var bProdTabShowUpgrades = false;
            var bProdChronoboost = false;

            var bPersonalApm = false;
            var bPersonalClock = false;
            var bPersonalApmWidth = false;
            var bPersonalApmHeight = false;
            var bPersonalClockWidth = false;
            var bPersonalClockHeight = false;
            var bPersonalApmPositionX = false;
            var bPersonalApmPositionY = false;
            var bPersonalClockPositionX = false;
            var bPersonalClockPositionY = false;
            var bPersonalApmAlert = false;
            var bPersonalApmAlertLimit = false;

            var bWorkerAutomation = false;
            var bWorkerAutomationMaximumWorkers = false;
            var bWorkerAutomationMaximumWorkersPerBase = false;
            var bWorkerAutomationPufferWorkers = false;
            var bWorkerAutomationApmProtection = false;
            var bWorkerAutomationModeDirect = false;
            var bWorkerAutomationModeRound = false;
            var bWorkerAutomationDisableWhenSelecting = false;
            var bWorkerAutomationDisableWhenWorkerIsSelected = false;
            var bWorkerAutomationAutoupgradeToOc = false;
            var bWorkerAutomationScvKey = false;
            var bWorkerAutomationProbeKey = false;
            var bWorkerAutomationOrbitalKey = false;
            var bWorkerAutomationMainbuildingGroupKey = false;
            var bWorkerAutomationBackupGroupKey = false;
            var bWorkerAutomationHotKey1 = false;
            var bWorkerAutomationHotKey2 = false;
            var bWorkerAutomationHotKey3 = false;
            var bWorkerAutomationStartNextWorkerAt = false;

            #endregion

            #region Introduction

            if (!File.Exists(Constants.StrDummyPref))
            {
                GetStandardPreferences();

                return;
            }

            var fileInformation = new FileInfo(Constants.StrDummyPref);
            if (fileInformation.Length > 1024 * 1024)
            {
                Messages.LogFile("Preferencefile too big! [" + fileInformation.Length + " Bytes]", null);
                GetStandardPreferences();

                return;
            }


            var sr = new StreamReader(Constants.StrDummyPref);
            var strSource = sr.ReadToEnd();
            sr.Close();

            var strSplit = strSource.Split('\n');

            /* Defined variables 
             * '['  is the beginning of a keyword e.g. [Resource] 
             * ';'  is the indicator of a comment 
             * */

            /* remove redundant content */
            for (var i = 0; i < strSplit.Length; i++)
            {
                foreach (var t in Constants.StrRedundantSigns)
                {
                    if (strSplit[i].Contains(t))
                        strSplit[i] = strSplit[i].Remove(strSplit[i].IndexOf(t, StringComparison.Ordinal),
                            t.Length);
                }
            }

            #endregion

            #region Important part

            var strKeyword = string.Empty;
            foreach (var t in strSplit)
            {
                var strInnerValue = t;


                if (strInnerValue.StartsWith(";"))
                    continue;

                if (strInnerValue.StartsWith("["))
                {
                    strKeyword = strInnerValue.Substring(1, strInnerValue.Length - 2);
                    continue;
                }

                if (strInnerValue.Length <= 0)
                    continue;


                #region Global

                if (strKeyword.Equals(Constants.StrPreferenceKeywordGlobal))
                {
                    GlobalDrawOnlyInForeground =
                         ReadSubSetting(GlobalDrawOnlyInForeground, "DrawOnlyInForeground", strInnerValue);
                    GlobalDataRefresh = ReadSubSetting(GlobalDataRefresh, "Data Refresh", strInnerValue);
                    GlobalDrawingRefresh =
                         ReadSubSetting(GlobalDrawingRefresh, "Drawing Refresh", strInnerValue);
                    GlobalChangeSizeAndPosition =
                         ReadSubSetting(GlobalChangeSizeAndPosition, "Hotkey Resize", strInnerValue);

                    /* Font Name */
                    if (strInnerValue.StartsWith("Language"))
                    {
                        strInnerValue = strInnerValue.Substring("Language".Length,
                            strInnerValue.Length -
                            "Language".Length);


                        GlobalLanguage = strInnerValue.Length <= 0 ? "English" : strInnerValue;
                        bLanguage = true;
                    }

                }

                #endregion

                #region Resource

                else if (strKeyword.Equals(Constants.StrPreferenceKeywordResource))
                {
                    #region Boolean values

                    /* Remove Ai */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveAi))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveAi.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveAi.Length);

                        bool bRemoveAi;
                        Boolean.TryParse(strInnerValue, out bRemoveAi);

                        ResourceRemoveAi = bRemoveAi;
                    }

                    /* Remove Localplayer */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveLocalplayer))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveLocalplayer.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveLocalplayer.Length);

                        bool bRemoveLocalplayer;
                        Boolean.TryParse(strInnerValue, out bRemoveLocalplayer);

                        ResourceRemoveLocalplayer = bRemoveLocalplayer;
                    }

                    /* Remove Neutral */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveNeutral))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveNeutral.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveNeutral.Length);

                        bool bRemoveNeutral;
                        Boolean.TryParse(strInnerValue, out bRemoveNeutral);

                        ResourceRemoveNeutral = bRemoveNeutral;
                    }

                    /* Remove Allie */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveAllie))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveAllie.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveAllie.Length);

                        bool bRemoveAllie;
                        Boolean.TryParse(strInnerValue, out bRemoveAllie);

                        ResourceRemoveAllie = bRemoveAllie;
                    }

                    /* Disable Background */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceDisableBackground))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceDisableBackground.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceDisableBackground.Length);

                        bool bDisableBackground;
                        Boolean.TryParse(strInnerValue, out bDisableBackground);

                        ResourceDrawBackground = bDisableBackground;
                    }

                    /* ClanTag */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveClanTag))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveClanTag.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveClanTag.Length);

                        bool bRemoveClanTag;
                        Boolean.TryParse(strInnerValue, out bRemoveClanTag);

                        ResourceRemoveClanTag = bRemoveClanTag;

                        bResourceRemoveClanTagSet = true;
                    }

                    #endregion

                    #region Int32 values

                    /* Pos X */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosX))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosX.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosX.Length);

                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosX;
                            Int32.TryParse(strInnerValue, out iPosX);

                            ResourcePositionX = iPosX;
                        }

                        else
                            ResourcePositionX = 50;
                    }

                    /* Pos Y */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosY))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosY.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosY.Length);

                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosY;
                            Int32.TryParse(strInnerValue, out iPosY);

                            ResourcePositionY = iPosY;
                        }

                        else
                            ResourcePositionY = 50;
                    }

                    /* Width */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceWidth))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceWidth.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceWidth.Length);


                        Int32 iWidth;
                        Int32.TryParse(strInnerValue, out iWidth);

                        ResourceWidth = iWidth <= 10 ? 600 : iWidth;

                    }

                    /* Height */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHeight))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHeight.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHeight.Length);


                        Int32 iHeight;
                        Int32.TryParse(strInnerValue, out iHeight);

                        ResourceHeight = iHeight <= 10 ? 50 : iHeight;
                    }


                    #endregion

                    #region String

                    /* Font Name */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceFontText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceFontText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceFontText.Length);


                        ResourceFontName = strInnerValue.Length <= 0 ? "Century Gothic" : strInnerValue;
                    }

                    /* On/ Off Panel */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOnOffText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOnOffText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOnOffText.Length);


                        ResourceTogglePanel = strInnerValue.Length <= 0 ? "/res" : strInnerValue;
                    }

                    /* Change Position */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangePositionText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangePositionText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangePositionText.Length);


                        ResourceChangePositionPanel = strInnerValue.Length <= 0 ? "/rcp" : strInnerValue;
                    }

                    /* Change Size */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangeSizeText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangeSizeText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangeSizeText.Length);


                        ResourceChangeSizePanel = strInnerValue.Length <= 0 ? "/rcs" : strInnerValue;
                    }

                    #endregion

                    #region Keys

                    /* UiHotkeys 1 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey1))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey1.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey1.Length);

                        Keys kHotkey1;
                        Enum.TryParse(strInnerValue, out kHotkey1);

                        ResourceHotkey1 = kHotkey1;
                    }

                    /* UiHotkeys 2 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey2))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey2.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey2.Length);

                        Keys kHotkey2;
                        Enum.TryParse(strInnerValue, out kHotkey2);

                        ResourceHotkey2 = kHotkey2;
                    }

                    /* UiHotkeys 3 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey3))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey3.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey3.Length);

                        Keys kHotkey3;
                        Enum.TryParse(strInnerValue, out kHotkey3);

                        ResourceHotkey3 = kHotkey3;
                    }

                    #endregion

                    #region Other

                    /* Opacity */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOpacity))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOpacity.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOpacity.Length);

                        Double dOpacity;
                        Double.TryParse(strInnerValue, out dOpacity);

                        ResourceOpacity = dOpacity;
                    }

                    #endregion
                }

                #endregion

                #region Income

                else if (strKeyword.Equals(Constants.StrPreferenceKeywordIncome))
                {
                    #region Boolean values

                    /* Remove Ai */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveAi))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveAi.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveAi.Length);

                        bool bRemoveAi;
                        Boolean.TryParse(strInnerValue, out bRemoveAi);

                        IncomeRemoveAi = bRemoveAi;
                    }

                    /* Remove Localplayer */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveLocalplayer))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveLocalplayer.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveLocalplayer.Length);

                        bool bRemoveLocalplayer;
                        Boolean.TryParse(strInnerValue, out bRemoveLocalplayer);

                        IncomeRemoveLocalplayer = bRemoveLocalplayer;
                    }

                    /* Remove Neutral */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveNeutral))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveNeutral.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveNeutral.Length);

                        bool bRemoveNeutral;
                        Boolean.TryParse(strInnerValue, out bRemoveNeutral);

                        IncomeRemoveNeutral = bRemoveNeutral;
                    }

                    /* Remove Allie */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveAllie))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveAllie.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveAllie.Length);

                        bool bRemoveAllie;
                        Boolean.TryParse(strInnerValue, out bRemoveAllie);

                        IncomeRemoveAllie = bRemoveAllie;
                    }

                    /* Disable Background */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceDisableBackground))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceDisableBackground.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceDisableBackground.Length);

                        bool bDisableBackground;
                        Boolean.TryParse(strInnerValue, out bDisableBackground);

                        IncomeDrawBackground = bDisableBackground;
                    }

                    /* ClanTag */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveClanTag))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveClanTag.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveClanTag.Length);

                        bool bRemoveClanTag;
                        Boolean.TryParse(strInnerValue, out bRemoveClanTag);

                        IncomeRemoveClanTag = bRemoveClanTag;

                        bIncomeRemoveClanTagSet = true;
                    }

                    #endregion

                    #region Int32 values

                    /* Pos X */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosX))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosX.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosX.Length);
                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosX;
                            Int32.TryParse(strInnerValue, out iPosX);

                            IncomePositionX = iPosX;
                        }

                        else
                            IncomePositionX = 50;
                    }

                    /* Pos Y */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosY))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosY.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosY.Length);
                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosY;
                            Int32.TryParse(strInnerValue, out iPosY);

                            IncomePositionY = iPosY;
                        }

                        else
                            IncomePositionY = 50;
                    }

                    /* Width */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceWidth))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceWidth.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceWidth.Length);

                        Int32 iWidth;
                        Int32.TryParse(strInnerValue, out iWidth);

                        IncomeWidth = iWidth <= 10 ? 600 : iWidth;
                    }

                    /* Height */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHeight))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHeight.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHeight.Length);

                        Int32 iHeight;
                        Int32.TryParse(strInnerValue, out iHeight);

                        IncomeHeight = iHeight <= 10 ? 50 : iHeight;
                    }


                    #endregion

                    #region String

                    /* Font Name */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceFontText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceFontText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceFontText.Length);


                        IncomeFontName = strInnerValue.Length <= 0 ? "Century Gothic" : strInnerValue;
                    }

                    /* On/ Off Panel */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOnOffText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOnOffText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOnOffText.Length);


                        IncomeTogglePanel = strInnerValue.Length <= 0 ? "/res" : strInnerValue;
                    }

                    /* Change Position */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangePositionText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangePositionText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangePositionText.Length);


                        IncomeChangePositionPanel = strInnerValue.Length <= 0 ? "/rcp" : strInnerValue;
                    }

                    /* Change Size */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangeSizeText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangeSizeText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangeSizeText.Length);


                        IncomeChangeSizePanel = strInnerValue.Length <= 0 ? "/rcs" : strInnerValue;
                    }

                    #endregion

                    #region Keys

                    /* UiHotkeys 1 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey1))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey1.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey1.Length);

                        Keys kHotkey1;
                        Enum.TryParse(strInnerValue, out kHotkey1);

                        IncomeHotkey1 = kHotkey1;
                    }

                    /* UiHotkeys 2 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey2))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey2.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey2.Length);

                        Keys kHotkey2;
                        Enum.TryParse(strInnerValue, out kHotkey2);

                        IncomeHotkey2 = kHotkey2;
                    }

                    /* UiHotkeys 3 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey3))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey3.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey3.Length);

                        Keys kHotkey3;
                        Enum.TryParse(strInnerValue, out kHotkey3);

                        IncomeHotkey3 = kHotkey3;
                    }

                    #endregion

                    #region Other

                    /* Opacity */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOpacity))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOpacity.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOpacity.Length);

                        Double dOpacity;
                        Double.TryParse(strInnerValue, out dOpacity);

                        IncomeOpacity = dOpacity;
                    }

                    #endregion
                }

                #endregion

                #region Apm

                else if (strKeyword.Equals(Constants.StrPreferenceKeywordApm))
                {
                    #region Boolean values

                    /* Remove Ai */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveAi))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveAi.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveAi.Length);

                        bool bRemoveAi;
                        Boolean.TryParse(strInnerValue, out bRemoveAi);

                        ApmRemoveAi = bRemoveAi;
                    }

                    /* Remove Localplayer */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveLocalplayer))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveLocalplayer.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveLocalplayer.Length);

                        bool bRemoveLocalplayer;
                        Boolean.TryParse(strInnerValue, out bRemoveLocalplayer);

                        ApmRemoveLocalplayer = bRemoveLocalplayer;
                    }

                    /* Remove Neutral */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveNeutral))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveNeutral.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveNeutral.Length);

                        bool bRemoveNeutral;
                        Boolean.TryParse(strInnerValue, out bRemoveNeutral);

                        ApmRemoveNeutral = bRemoveNeutral;
                    }

                    /* Remove Allie */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveAllie))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveAllie.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveAllie.Length);

                        bool bRemoveAllie;
                        Boolean.TryParse(strInnerValue, out bRemoveAllie);

                        ApmRemoveAllie = bRemoveAllie;
                    }

                    /* Disable Background */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceDisableBackground))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceDisableBackground.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceDisableBackground.Length);

                        bool bDisableBackground;
                        Boolean.TryParse(strInnerValue, out bDisableBackground);

                        ApmDrawBackground = bDisableBackground;
                    }

                    /* ClanTag */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveClanTag))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveClanTag.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveClanTag.Length);

                        bool bRemoveClanTag;
                        Boolean.TryParse(strInnerValue, out bRemoveClanTag);

                        ApmRemoveClanTag = bRemoveClanTag;

                        bApmRemoveClanTagSet = true;
                    }

                    #endregion

                    #region Int32 values

                    /* Pos X */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosX))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosX.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosX.Length);
                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosX;
                            Int32.TryParse(strInnerValue, out iPosX);

                            ApmPositionX = iPosX;
                        }

                        else
                            ApmPositionX = 50;
                    }

                    /* Pos Y */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosY))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosY.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosY.Length);

                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosY;
                            Int32.TryParse(strInnerValue, out iPosY);

                            ApmPositionY = iPosY;
                        }

                        else
                            ApmPositionY = 50;
                    }

                    /* Width */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceWidth))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceWidth.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceWidth.Length);

                        Int32 iWidth;
                        Int32.TryParse(strInnerValue, out iWidth);

                        ApmWidth = iWidth <= 10 ? 600 : iWidth;
                    }

                    /* Height */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHeight))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHeight.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHeight.Length);

                        Int32 iHeight;
                        Int32.TryParse(strInnerValue, out iHeight);

                        ApmHeight = iHeight <= 10 ? 50 : iHeight;
                    }


                    #endregion

                    #region String

                    /* Font Name */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceFontText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceFontText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceFontText.Length);


                        ApmFontName = strInnerValue.Length <= 0 ? "Century Gothic" : strInnerValue;
                    }

                    /* On/ Off Panel */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOnOffText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOnOffText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOnOffText.Length);


                        ApmTogglePanel = strInnerValue.Length <= 0 ? "/res" : strInnerValue;
                    }

                    /* Change Position */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangePositionText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangePositionText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangePositionText.Length);


                        ApmChangePositionPanel = strInnerValue.Length <= 0 ? "/rcp" : strInnerValue;
                    }

                    /* Change Size */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangeSizeText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangeSizeText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangeSizeText.Length);


                        ApmChangeSizePanel = strInnerValue.Length <= 0 ? "/rcs" : strInnerValue;
                    }

                    #endregion

                    #region Keys

                    /* UiHotkeys 1 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey1))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey1.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey1.Length);

                        Keys kHotkey1;
                        Enum.TryParse(strInnerValue, out kHotkey1);

                        ApmHotkey1 = kHotkey1;
                    }

                    /* UiHotkeys 2 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey2))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey2.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey2.Length);

                        Keys kHotkey2;
                        Enum.TryParse(strInnerValue, out kHotkey2);

                        ApmHotkey2 = kHotkey2;
                    }

                    /* UiHotkeys 3 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey3))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey3.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey3.Length);

                        Keys kHotkey3;
                        Enum.TryParse(strInnerValue, out kHotkey3);

                        ApmHotkey3 = kHotkey3;
                    }

                    #endregion

                    #region Other

                    /* Opacity */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOpacity))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOpacity.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOpacity.Length);

                        Double dOpacity;
                        Double.TryParse(strInnerValue, out dOpacity);

                        ApmOpacity = dOpacity;
                    }

                    #endregion
                }

                #endregion

                #region Army

                else if (strKeyword.Equals(Constants.StrPreferenceKeywordArmy))
                {
                    #region Boolean values

                    /* Remove Ai */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveAi))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveAi.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveAi.Length);

                        bool bRemoveAi;
                        Boolean.TryParse(strInnerValue, out bRemoveAi);

                        ArmyRemoveAi = bRemoveAi;
                    }

                    /* Remove Localplayer */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveLocalplayer))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveLocalplayer.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveLocalplayer.Length);

                        bool bRemoveLocalplayer;
                        Boolean.TryParse(strInnerValue, out bRemoveLocalplayer);

                        ArmyRemoveLocalplayer = bRemoveLocalplayer;
                    }

                    /* Remove Neutral */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveNeutral))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveNeutral.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveNeutral.Length);

                        bool bRemoveNeutral;
                        Boolean.TryParse(strInnerValue, out bRemoveNeutral);

                        ArmyRemoveNeutral = bRemoveNeutral;
                    }

                    /* Remove Allie */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveAllie))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveAllie.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveAllie.Length);

                        bool bRemoveAllie;
                        Boolean.TryParse(strInnerValue, out bRemoveAllie);

                        ArmyRemoveAllie = bRemoveAllie;
                    }

                    /* Disable Background */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceDisableBackground))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceDisableBackground.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceDisableBackground.Length);

                        bool bDisableBackground;
                        Boolean.TryParse(strInnerValue, out bDisableBackground);

                        ArmyDrawBackground = bDisableBackground;
                    }

                    /* ClanTag */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveClanTag))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveClanTag.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveClanTag.Length);

                        bool bRemoveClanTag;
                        Boolean.TryParse(strInnerValue, out bRemoveClanTag);

                        ArmyRemoveClanTag = bRemoveClanTag;

                        bArmyRemoveClanTagSet = true;
                    }

                    #endregion

                    #region Int32 values

                    /* Pos X */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosX))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosX.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosX.Length);
                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosX;
                            Int32.TryParse(strInnerValue, out iPosX);

                            ArmyPositionX = iPosX;
                        }

                        else
                            ArmyPositionX = 50;

                    }

                    /* Pos Y */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosY))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosY.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosY.Length);

                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosY;
                            Int32.TryParse(strInnerValue, out iPosY);

                            ArmyPositionY = iPosY;
                        }

                        else
                            ArmyPositionY = 50;
                    }

                    /* Width */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceWidth))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceWidth.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceWidth.Length);

                        Int32 iWidth;
                        Int32.TryParse(strInnerValue, out iWidth);

                        ArmyWidth = iWidth <= 10 ? 600 : iWidth;
                    }

                    /* Height */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHeight))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHeight.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHeight.Length);

                        Int32 iHeight;
                        Int32.TryParse(strInnerValue, out iHeight);

                        ArmyHeight = iHeight <= 10 ? 50 : iHeight;
                    }


                    #endregion

                    #region String

                    /* Font Name */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceFontText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceFontText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceFontText.Length);


                        ArmyFontName = strInnerValue.Length <= 0 ? "Century Gothic" : strInnerValue;
                    }

                    /* On/ Off Panel */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOnOffText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOnOffText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOnOffText.Length);


                        ArmyTogglePanel = strInnerValue.Length <= 0 ? "/res" : strInnerValue;
                    }

                    /* Change Position */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangePositionText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangePositionText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangePositionText.Length);


                        ArmyChangePositionPanel = strInnerValue.Length <= 0 ? "/rcp" : strInnerValue;
                    }

                    /* Change Size */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangeSizeText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangeSizeText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangeSizeText.Length);


                        ArmyChangeSizePanel = strInnerValue.Length <= 0 ? "Century Gothic" : strInnerValue;
                    }

                    #endregion

                    #region Keys

                    /* UiHotkeys 1 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey1))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey1.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey1.Length);

                        Keys kHotkey1;
                        Enum.TryParse(strInnerValue, out kHotkey1);

                        ArmyHotkey1 = kHotkey1;
                    }

                    /* UiHotkeys 2 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey2))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey2.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey2.Length);

                        Keys kHotkey2;
                        Enum.TryParse(strInnerValue, out kHotkey2);

                        ArmyHotkey2 = kHotkey2;
                    }

                    /* UiHotkeys 3 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey3))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey3.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey3.Length);

                        Keys kHotkey3;
                        Enum.TryParse(strInnerValue, out kHotkey3);

                        ArmyHotkey3 = kHotkey3;
                    }

                    #endregion

                    #region Other

                    /* Opacity */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOpacity))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOpacity.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOpacity.Length);

                        Double dOpacity;
                        Double.TryParse(strInnerValue, out dOpacity);

                        ArmyOpacity = dOpacity;
                    }

                    #endregion
                }

                #endregion

                #region Worker

                else if (strKeyword.Equals(Constants.StrPreferenceKeywordWorker))
                {
                    #region Boolean values

                    /* Disable Background */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceDisableBackground))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceDisableBackground.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceDisableBackground.Length);

                        bool bDisableBackground;
                        Boolean.TryParse(strInnerValue, out bDisableBackground);

                        WorkerDrawBackground = bDisableBackground;
                    }

                    #endregion

                    #region Int32 values

                    /* Pos X */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosX))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosX.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosX.Length);
                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosX;
                            Int32.TryParse(strInnerValue, out iPosX);

                            WorkerPositionX = iPosX;
                        }

                        else
                            WorkerPositionX = 50;
                    }

                    /* Pos Y */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosY))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosY.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosY.Length);
                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosY;
                            Int32.TryParse(strInnerValue, out iPosY);

                            WorkerPositionY = iPosY;
                        }

                        else
                            WorkerPositionY = 50;
                    }

                    /* Width */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceWidth))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceWidth.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceWidth.Length);

                        Int32 iWidth;
                        Int32.TryParse(strInnerValue, out iWidth);

                        WorkerWidth = iWidth <= 10 ? 200 : iWidth;
                    }

                    /* Height */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHeight))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHeight.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHeight.Length);

                        Int32 iHeight;
                        Int32.TryParse(strInnerValue, out iHeight);

                        WorkerHeight = iHeight <= 10 ? 50 : iHeight;
                    }


                    #endregion

                    #region String

                    /* Font Name */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceFontText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceFontText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceFontText.Length);


                        WorkerFontName = strInnerValue.Length <= 0 ? "Century Gothic" : strInnerValue;
                    }

                    /* On/ Off Panel */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOnOffText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOnOffText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOnOffText.Length);


                        WorkerTogglePanel = strInnerValue.Length <= 0 ? "/res" : strInnerValue;
                    }

                    /* Change Position */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangePositionText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangePositionText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangePositionText.Length);


                        WorkerChangePositionPanel = strInnerValue.Length <= 0 ? "/rcp" : strInnerValue;
                    }

                    /* Change Size */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangeSizeText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangeSizeText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangeSizeText.Length);


                        WorkerChangeSizePanel = strInnerValue.Length <= 0 ? "/rcs" : strInnerValue;
                    }

                    #endregion

                    #region Keys

                    /* UiHotkeys 1 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey1))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey1.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey1.Length);

                        Keys kHotkey1;
                        Enum.TryParse(strInnerValue, out kHotkey1);

                        WorkerHotkey1 = kHotkey1;
                    }

                    /* UiHotkeys 2 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey2))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey2.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey2.Length);

                        Keys kHotkey2;
                        Enum.TryParse(strInnerValue, out kHotkey2);

                        WorkerHotkey2 = kHotkey2;
                    }

                    /* UiHotkeys 3 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey3))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey3.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey3.Length);

                        Keys kHotkey3;
                        Enum.TryParse(strInnerValue, out kHotkey3);

                        WorkerHotkey3 = kHotkey3;
                    }

                    #endregion

                    #region Other

                    /* Opacity */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOpacity))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOpacity.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOpacity.Length);

                        Double dOpacity;
                        Double.TryParse(strInnerValue, out dOpacity);

                        WorkerOpacity = dOpacity;
                    }

                    #endregion
                }

                #endregion

                #region UnitTab

                else if (strKeyword.Equals(Constants.StrPreferenceKeywordUnitTab))
                {
                    #region Boolean values

                    /* Remove Ai */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveAi))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveAi.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveAi.Length);

                        bool bRemoveAi;
                        Boolean.TryParse(strInnerValue, out bRemoveAi);

                        UnitTabRemoveAi = bRemoveAi;
                    }

                    /* Remove Localplayer */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveLocalplayer))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveLocalplayer.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveLocalplayer.Length);

                        bool bRemoveLocalplayer;
                        Boolean.TryParse(strInnerValue, out bRemoveLocalplayer);

                        UnitTabRemoveLocalplayer = bRemoveLocalplayer;
                    }

                    /* Remove Neutral */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveNeutral))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveNeutral.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveNeutral.Length);

                        bool bRemoveNeutral;
                        Boolean.TryParse(strInnerValue, out bRemoveNeutral);

                        UnitTabRemoveNeutral = bRemoveNeutral;
                    }

                    /* Remove Allie */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveAllie))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveAllie.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveAllie.Length);

                        bool bRemoveAllie;
                        Boolean.TryParse(strInnerValue, out bRemoveAllie);

                        UnitTabRemoveAllie = bRemoveAllie;
                    }

                    /* Remove Prod. Line */
                    if (strInnerValue.StartsWith("Remove Prod. Line"))
                    {
                        strInnerValue = strInnerValue.Substring("Remove Prod. Line".Length,
                            strInnerValue.Length -
                            "Remove Prod. Line".Length);

                        bool bRemProdLine;
                        Boolean.TryParse(strInnerValue, out bRemProdLine);

                        UnitTabRemoveProdLine = bRemProdLine;
                        bUnitTabRemoveProdLineSet = true;
                    }

                    /* DSplit Buildings */
                    const string strSplitBuildings = "Split Buildings/ Units";
                    if (strInnerValue.StartsWith(strSplitBuildings))
                    {
                        strInnerValue = strInnerValue.Substring(strSplitBuildings.Length,
                            strInnerValue.Length - strSplitBuildings.Length);

                        bool bSplitBuildings;
                        Boolean.TryParse(strInnerValue, out bSplitBuildings);

                        UnitTabSplitUnitsAndBuildings = bSplitBuildings;
                    }

                    /* ClanTag */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveClanTag))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveClanTag.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveClanTag.Length);

                        bool bRemoveClanTag;
                        Boolean.TryParse(strInnerValue, out bRemoveClanTag);

                        UnitTabRemoveClanTag = bRemoveClanTag;

                        bUnitTabRemoveClanTagSet = true;
                    }

                    /* Show Units */
                    if (strInnerValue.StartsWith("Show Units"))
                    {
                        strInnerValue = strInnerValue.Substring("Show Units".Length,
                            strInnerValue.Length -
                            "Show Units".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        UnitTabShowUnits = bDummy;
                        bUnitTabShowUnits = true;
                    }

                    /* Show Units */
                    if (strInnerValue.StartsWith("Show Buildings"))
                    {
                        strInnerValue = strInnerValue.Substring("Show Buildings".Length,
                            strInnerValue.Length -
                            "Show Buildings".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        UnitTabShowBuildings = bDummy;
                        bUnitTabShowBuildings = true;
                    }

                    /* Remove Chronoboost */
                    if (strInnerValue.StartsWith("Remove Chronoboost"))
                    {
                        strInnerValue = strInnerValue.Substring("Remove Chronoboost".Length,
                            strInnerValue.Length -
                            "Remove Chronoboost".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        UnitTabRemoveChronoboost = bDummy;
                        bUnitTabChronoboost = true;
                    }

                    /* Remove SpellCounter */
                    if (strInnerValue.StartsWith("Remove Spellcounter"))
                    {
                        strInnerValue = strInnerValue.Substring("Remove Spellcounter".Length,
                            strInnerValue.Length -
                            "Remove Spellcounter".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        UnitTabRemoveSpellCounter = bDummy;
                        bUnitTabSpellCounter = true;
                    }

                    /* Use Transparent Images */
                    if (strInnerValue.StartsWith("Use Transparent Images"))
                    {
                        strInnerValue = strInnerValue.Substring("Use Transparent Images".Length,
                            strInnerValue.Length -
                            "Use Transparent Images".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        UnitTabUseTransparentImages = bDummy;
                    }

                    #endregion

                    #region Int32 values

                    /* Pos X */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosX))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosX.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosX.Length);

                        Int32 iPosX;
                        Int32.TryParse(strInnerValue, out iPosX);

                        UnitTabPositionX = iPosX;
                    }

                    /* Pos Y */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosY))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosY.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosY.Length);

                        Int32 iPosY;
                        Int32.TryParse(strInnerValue, out iPosY);

                        UnitTabPositionY = iPosY;
                    }

                    /* Width */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceWidth))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceWidth.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceWidth.Length);

                        Int32 iWidth;
                        Int32.TryParse(strInnerValue, out iWidth);

                        UnitTabWidth = iWidth;
                    }

                    /* Height */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHeight))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHeight.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHeight.Length);

                        Int32 iHeight;
                        Int32.TryParse(strInnerValue, out iHeight);

                        UnitTabHeight = iHeight;
                    }

                    /* Picture Size */
                    if (strInnerValue.StartsWith("Picture Size"))
                    {
                        strInnerValue = strInnerValue.Substring("Picture Size".Length,
                            strInnerValue.Length -
                            "Picture Size".Length);

                        Int32 iPictureSize;
                        Int32.TryParse(strInnerValue, out iPictureSize);

                        UnitPictureSize = iPictureSize;

                        bUnitTabPictureSizeSet = true;
                    }


                    #endregion

                    #region String

                    /* On/ Off Panel */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOnOffText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOnOffText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOnOffText.Length);


                        UnitTogglePanel = strInnerValue.Length <= 0 ? "/res" : strInnerValue;
                    }

                    /* Change Position */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangePositionText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangePositionText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangePositionText.Length);


                        UnitChangePositionPanel = strInnerValue.Length <= 0 ? "/rcp" : strInnerValue;
                    }

                    /* Change Size */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangeSizeText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangeSizeText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangeSizeText.Length);


                        UnitChangeSizePanel = strInnerValue.Length <= 0 ? "/rcs" : strInnerValue;
                    }

                    /* Fontname */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceFontText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceFontText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceFontText.Length);


                        UnitTabFontName = strInnerValue.Length <= 0 ? "Century Gothic" : strInnerValue;

                        bUnitTabFontNameSet = true;
                    }

                    #endregion

                    #region Keys

                    /* UiHotkeys 1 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey1))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey1.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey1.Length);

                        Keys kHotkey1;
                        Enum.TryParse(strInnerValue, out kHotkey1);

                        UnitHotkey1 = kHotkey1;
                    }

                    /* UiHotkeys 2 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey2))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey2.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey2.Length);

                        Keys kHotkey2;
                        Enum.TryParse(strInnerValue, out kHotkey2);

                        UnitHotkey2 = kHotkey2;
                    }

                    /* UiHotkeys 3 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey3))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey3.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey3.Length);

                        Keys kHotkey3;
                        Enum.TryParse(strInnerValue, out kHotkey3);

                        UnitHotkey3 = kHotkey3;
                    }

                    #endregion

                    #region Other

                    /* Opacity */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOpacity))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOpacity.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOpacity.Length);

                        Double dOpacity;
                        Double.TryParse(strInnerValue, out dOpacity);

                        UnitTabOpacity = dOpacity;
                    }

                    #endregion
                }

                #endregion

                #region Production

                else if (strKeyword.Equals(Constants.StrPreferenceKeywordProdTab))
                {
                    #region Boolean values

                    /* Remove Ai */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveAi))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveAi.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveAi.Length);

                        bool bRemoveAi;
                        Boolean.TryParse(strInnerValue, out bRemoveAi);

                        ProdTabRemoveAi = bRemoveAi;
                        bProdTabRemAiSet = true;
                    }

                    /* Remove Localplayer */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveLocalplayer))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveLocalplayer.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveLocalplayer.Length);

                        bool bRemoveLocalplayer;
                        Boolean.TryParse(strInnerValue, out bRemoveLocalplayer);

                        ProdTabRemoveLocalplayer = bRemoveLocalplayer;
                        bProdTabRemLocalplayerSet = true;
                    }

                    /* Remove Neutral */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveNeutral))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveNeutral.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveNeutral.Length);

                        bool bRemoveNeutral;
                        Boolean.TryParse(strInnerValue, out bRemoveNeutral);

                        ProdTabRemoveNeutral = bRemoveNeutral;
                        bProdTabRemNeutralSet = true;
                    }

                    /* Remove Allie */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveAllie))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveAllie.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveAllie.Length);

                        bool bRemoveAllie;
                        Boolean.TryParse(strInnerValue, out bRemoveAllie);

                        ProdTabRemoveAllie = bRemoveAllie;
                        bProdTabRemAllieSet = true;
                    }


                    /* DSplit Buildings */
                    const string strSplitBuildings = "Split Buildings/ Units";
                    if (strInnerValue.StartsWith(strSplitBuildings))
                    {
                        strInnerValue = strInnerValue.Substring(strSplitBuildings.Length,
                            strInnerValue.Length - strSplitBuildings.Length);

                        bool bSplitBuildings;
                        Boolean.TryParse(strInnerValue, out bSplitBuildings);

                        ProdTabSplitUnitsAndBuildings = bSplitBuildings;
                        bProdTabSplitBuilldingsSet = true;
                    }

                    /* ClanTag */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveClanTag))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveClanTag.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveClanTag.Length);

                        bool bRemoveClanTag;
                        Boolean.TryParse(strInnerValue, out bRemoveClanTag);

                        ProdTabRemoveClanTag = bRemoveClanTag;
                        bProdTabRemoveClanTagSet = true;
                    }

                    /* Show Units */
                    if (strInnerValue.StartsWith("Show Units"))
                    {
                        strInnerValue = strInnerValue.Substring("Show Units".Length,
                            strInnerValue.Length -
                            "Show Units".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        ProdTabShowUnits = bDummy;
                        bProdTabShowUnits = true;
                    }

                    /* Show Buildings */
                    if (strInnerValue.StartsWith("Show Buildings"))
                    {
                        strInnerValue = strInnerValue.Substring("Show Buildings".Length,
                            strInnerValue.Length -
                            "Show Buildings".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        ProdTabShowBuildings = bDummy;
                        bProdTabShowBuildings = true;
                    }

                    /* Show Upgrades */
                    if (strInnerValue.StartsWith("Show Upgrades"))
                    {
                        strInnerValue = strInnerValue.Substring("Show Upgrades".Length,
                            strInnerValue.Length -
                            "Show Upgrades".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        ProdTabShowUpgrades = bDummy;
                        bProdTabShowUpgrades = true;
                    }

                    /* Remove Chronoboost */
                    if (strInnerValue.StartsWith("Remove Chronoboost"))
                    {
                        strInnerValue = strInnerValue.Substring("Remove Chronoboost".Length,
                            strInnerValue.Length -
                            "Remove Chronoboost".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        ProdTabRemoveChronoboost = bDummy;
                        bProdChronoboost = true;
                    }

                    /* Use Transparent Images */
                    if (strInnerValue.StartsWith("Use Transparent Images"))
                    {
                        strInnerValue = strInnerValue.Substring("Use Transparent Images".Length,
                            strInnerValue.Length -
                            "Use Transparent Images".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        ProdTabUseTransparentImages = bDummy;
                    }

                    #endregion

                    #region Int32 values

                    /* Pos X */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosX))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosX.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosX.Length);

                        Int32 iPosX;
                        Int32.TryParse(strInnerValue, out iPosX);

                        ProdTabPositionX = iPosX;
                        bProdTabPositionXSet = true;
                    }

                    /* Pos Y */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosY))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosY.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosY.Length);

                        Int32 iPosY;
                        Int32.TryParse(strInnerValue, out iPosY);

                        ProdTabPositionY = iPosY;
                        bProdTabPositionYSet = true;
                    }

                    /* Width */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceWidth))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceWidth.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceWidth.Length);

                        Int32 iWidth;
                        Int32.TryParse(strInnerValue, out iWidth);

                        ProdTabWidth = iWidth;
                        bProdTabWidthSet = true;
                    }

                    /* Height */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHeight))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHeight.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHeight.Length);

                        Int32 iHeight;
                        Int32.TryParse(strInnerValue, out iHeight);

                        ProdTabHeight = iHeight;
                        bProdTabHeightSet = true;
                    }

                    /* Picture Size */
                    if (strInnerValue.StartsWith("Picture Size"))
                    {
                        strInnerValue = strInnerValue.Substring("Picture Size".Length,
                            strInnerValue.Length -
                            "Picture Size".Length);

                        Int32 iPictureSize;
                        Int32.TryParse(strInnerValue, out iPictureSize);

                        ProdPictureSize = iPictureSize;

                        bProdTabPictureSizeSet = true;
                    }


                    #endregion

                    #region String

                    /* On/ Off Panel */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOnOffText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOnOffText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOnOffText.Length);


                        ProdTogglePanel = strInnerValue.Length <= 0 ? "/pro" : strInnerValue;
                        bProdTabShortcutTgSet = true;
                    }

                    /* Change Position */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangePositionText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangePositionText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangePositionText.Length);


                        ProdChangePositionPanel = strInnerValue.Length <= 0 ? "/pcp" : strInnerValue;
                        bProdTabShortcutCpSet = true;
                    }

                    /* Change Size */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangeSizeText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangeSizeText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangeSizeText.Length);


                        ProdChangeSizePanel = strInnerValue.Length <= 0 ? "/pcs" : strInnerValue;
                        bProdTabShortcutCsSet = true;
                    }

                    /* Fontname */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceFontText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceFontText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceFontText.Length);


                        ProdTabFontName = strInnerValue.Length <= 0 ? "Century Gothic" : strInnerValue;
                        bProdTabFontNameSet = true;
                    }

                    #endregion

                    #region Keys

                    /* UiHotkeys 1 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey1))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey1.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey1.Length);

                        Keys kHotkey1;
                        Enum.TryParse(strInnerValue, out kHotkey1);

                        ProdHotkey1 = kHotkey1;
                        bProdTabHotkey1Set = true;
                    }

                    /* UiHotkeys 2 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey2))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey2.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey2.Length);

                        Keys kHotkey2;
                        Enum.TryParse(strInnerValue, out kHotkey2);

                        ProdHotkey2 = kHotkey2;
                        bProdTabHotkey2Set = true;
                    }

                    /* UiHotkeys 3 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey3))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey3.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey3.Length);

                        Keys kHotkey3;
                        Enum.TryParse(strInnerValue, out kHotkey3);

                        ProdHotkey3 = kHotkey3;
                        bProdTabHotkey3Set = true;
                    }

                    #endregion

                    #region Other

                    /* Opacity */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOpacity))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOpacity.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOpacity.Length);

                        Double dOpacity;
                        Double.TryParse(strInnerValue, out dOpacity);

                        ProdTabOpacity = dOpacity;
                        bProdTabOpacitySet = true;

                    }

                    #endregion
                }

                #endregion

                #region Various

                else if (strKeyword.Equals(Constants.StrPreferenceKeywordVarious))
                {
                    #region Boolean values

                    /* Apm */
                    if (strInnerValue.StartsWith("Apm Enable"))
                    {
                        strInnerValue = strInnerValue.Substring("Apm Enable".Length,
                            strInnerValue.Length -
                            "Apm Enable".Length);

                        bool bShowApm;
                        Boolean.TryParse(strInnerValue, out bShowApm);

                        PersonalApm = bShowApm;
                        bPersonalApm = true;
                    }

                    /* Apm Alert */
                    if (strInnerValue.StartsWith("ApmAlert Enable"))
                    {
                        strInnerValue = strInnerValue.Substring("ApmAlert Enable".Length,
                            strInnerValue.Length -
                            "ApmAlert Enable".Length);

                        bool bShowApmAlert;
                        Boolean.TryParse(strInnerValue, out bShowApmAlert);

                        PersonalApmAlert = bShowApmAlert;
                        bPersonalApmAlert = true;
                    }

                    /* Clock */
                    if (strInnerValue.StartsWith("Clock Enable"))
                    {
                        strInnerValue = strInnerValue.Substring("Clock Enable".Length,
                            strInnerValue.Length -
                            "Clock Enable".Length);

                        bool bShowClock;
                        Boolean.TryParse(strInnerValue, out bShowClock);

                        PersonalClock = bShowClock;
                        bPersonalClock = true;
                    }

                    #endregion

                    #region Int32 values

                    /* Apm - Pos X */
                    if (strInnerValue.StartsWith("ApmPosX"))
                    {
                        strInnerValue = strInnerValue.Substring("ApmPosX".Length,
                            strInnerValue.Length -
                            "ApmPosX".Length);

                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosX;
                            Int32.TryParse(strInnerValue, out iPosX);

                            PersonalApmPositionX = iPosX;
                        }

                        else
                            PersonalApmPositionX = 50;

                        bPersonalApmPositionX = true;
                    }

                    /* Apm - Pos Y */
                    if (strInnerValue.StartsWith("ApmPosY"))
                    {
                        strInnerValue = strInnerValue.Substring("ApmPosY".Length,
                            strInnerValue.Length -
                            "ApmPosY".Length);

                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosY;
                            Int32.TryParse(strInnerValue, out iPosY);

                            PersonalApmPositionY = iPosY;
                        }

                        else
                            PersonalApmPositionY = 50;

                        bPersonalApmPositionY = true;
                    }

                    /* Apm - Width */
                    if (strInnerValue.StartsWith("ApmWidth"))
                    {
                        strInnerValue = strInnerValue.Substring("ApmWidth".Length,
                            strInnerValue.Length -
                            "ApmWidth".Length);

                        if (strInnerValue.Length > 0)
                        {
                            Int32 iWidth;
                            Int32.TryParse(strInnerValue, out iWidth);

                            PersonalApmWidth = iWidth;
                        }

                        else
                            PersonalApmWidth = 200;

                        bPersonalApmWidth = true;
                    }

                    /* Apm - Height */
                    if (strInnerValue.StartsWith("ApmHeight"))
                    {
                        strInnerValue = strInnerValue.Substring("ApmHeight".Length,
                            strInnerValue.Length -
                            "ApmHeight".Length);

                        if (strInnerValue.Length > 0)
                        {
                            Int32 iHeight;
                            Int32.TryParse(strInnerValue, out iHeight);

                            PersonalApmHeight = iHeight;
                        }

                        else
                            PersonalApmHeight = 50;

                        bPersonalApmHeight = true;
                    }

                    /* Apm Alert Limit */
                    if (strInnerValue.StartsWith("ApmAlert Limit"))
                    {
                        strInnerValue = strInnerValue.Substring("ApmAlert Limit".Length,
                            strInnerValue.Length -
                            "ApmAlert Limit".Length);

                        if (strInnerValue.Length > 0)
                        {
                            Int32 iAlertLimit;
                            Int32.TryParse(strInnerValue, out iAlertLimit);

                            PersonalApmAlertLimit = iAlertLimit;
                        }

                        else
                            PersonalApmAlertLimit = 50;

                        bPersonalApmAlertLimit = true;
                    }

                    /* Clock - Pos X */
                    if (strInnerValue.StartsWith("ClockPosX"))
                    {
                        strInnerValue = strInnerValue.Substring("ClockPosX".Length,
                            strInnerValue.Length -
                            "ClockPosX".Length);

                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosX;
                            Int32.TryParse(strInnerValue, out iPosX);

                            PersonalClockPositionX = iPosX;
                        }

                        else
                            PersonalClockPositionX = 300;

                        bPersonalClockPositionX = true;
                    }

                    /* Clock - Pos Y */
                    if (strInnerValue.StartsWith("ClockPosY"))
                    {
                        strInnerValue = strInnerValue.Substring("ClockPosY".Length,
                            strInnerValue.Length -
                            "ClockPosY".Length);

                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosY;
                            Int32.TryParse(strInnerValue, out iPosY);

                            PersonalClockPositionY = iPosY;
                        }

                        else
                            PersonalClockPositionY = 50;

                        bPersonalClockPositionY = true;
                    }

                    /* Clock - Width */
                    if (strInnerValue.StartsWith("ClockWidth"))
                    {
                        strInnerValue = strInnerValue.Substring("ClockWidth".Length,
                            strInnerValue.Length -
                            "ClockWidth".Length);

                        if (strInnerValue.Length > 0)
                        {
                            Int32 iWidth;
                            Int32.TryParse(strInnerValue, out iWidth);

                            PersonalClockWidth = iWidth;
                        }

                        else
                            PersonalClockWidth = 200;

                        bPersonalClockWidth = true;
                    }

                    /* Clock - Height */
                    if (strInnerValue.StartsWith("ClockHeight"))
                    {
                        strInnerValue = strInnerValue.Substring("ClockHeight".Length,
                            strInnerValue.Length -
                            "ClockHeight".Length);

                        if (strInnerValue.Length > 0)
                        {
                            Int32 iHeight;
                            Int32.TryParse(strInnerValue, out iHeight);

                            PersonalClockHeight = iHeight;
                        }

                        else
                            PersonalClockHeight = 50;

                        bPersonalClockHeight = true;
                    }


                    #endregion


                }

                #endregion

                #region Maphack

                else if (strKeyword.Equals(Constants.StrPreferenceKeywordMaphack))
                {
                    #region Boolean values

                    /* Remove Ai */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveAi))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveAi.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveAi.Length);

                        bool bRemoveAi;
                        Boolean.TryParse(strInnerValue, out bRemoveAi);

                        MaphackRemoveAi = bRemoveAi;
                    }

                    /* Remove Localplayer */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveLocalplayer))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveLocalplayer.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveLocalplayer.Length);

                        bool bRemoveLocalplayer;
                        Boolean.TryParse(strInnerValue, out bRemoveLocalplayer);

                        MaphackRemoveLocalplayer = bRemoveLocalplayer;
                    }

                    /* Remove Neutral */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveNeutral))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveNeutral.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveNeutral.Length);

                        bool bRemoveNeutral;
                        Boolean.TryParse(strInnerValue, out bRemoveNeutral);

                        MaphackRemoveNeutral = bRemoveNeutral;
                    }

                    /* Remove Allie */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceRemoveAllie))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceRemoveAllie.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceRemoveAllie.Length);

                        bool bRemoveAllie;
                        Boolean.TryParse(strInnerValue, out bRemoveAllie);

                        MaphackRemoveAllie = bRemoveAllie;
                    }

                    /* Disable DestinationLine */
                    if (strInnerValue.StartsWith("Disable Destination Line"))
                    {
                        strInnerValue = strInnerValue.Substring("Disable Destination Line".Length,
                            strInnerValue.Length - "Disable Destination Line".Length);

                        bool bDisableDestinationLine;
                        Boolean.TryParse(strInnerValue, out bDisableDestinationLine);

                        MaphackDisableDestinationLine = bDisableDestinationLine;
                    }

                    /* Color Defensive structures */
                    if (strInnerValue.StartsWith("Color Def Structures"))
                    {
                        strInnerValue = strInnerValue.Substring("Color Def Structures".Length,
                            strInnerValue.Length - "Color Def Structures".Length);

                        bool bColorDefensiveStructures;
                        Boolean.TryParse(strInnerValue, out bColorDefensiveStructures);

                        MaphackColorDefensivestructuresYellow = bColorDefensiveStructures;
                    }

                    /* Remove Vision Area */
                    if (strInnerValue.StartsWith("Remove Vision Area"))
                    {
                        strInnerValue = strInnerValue.Substring("Remove Vision Area".Length,
                            strInnerValue.Length - "Remove Vision Area".Length);

                        bool bRemoveVisionArea;
                        Boolean.TryParse(strInnerValue, out bRemoveVisionArea);

                        MaphackRemoveVisionArea = bRemoveVisionArea;
                    }

                    /* Remove Camera */
                    if (strInnerValue.StartsWith("Remove Camera"))
                    {
                        strInnerValue = strInnerValue.Substring("Remove Camera".Length,
                            strInnerValue.Length - "Remove Camera".Length);

                        bool bRemoveCamera;
                        Boolean.TryParse(strInnerValue, out bRemoveCamera);

                        MaphackRemoveCamera = bRemoveCamera;
                    }

                    #endregion

                    #region Int32 values

                    /* Pos X */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosX))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosX.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosX.Length);
                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosX;
                            Int32.TryParse(strInnerValue, out iPosX);

                            MaphackPositionX = iPosX;
                        }

                        else
                            MaphackPositionX = 50;
                    }

                    /* Pos Y */
                    if (strInnerValue.StartsWith(Constants.StrPreferencePosY))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferencePosY.Length,
                            strInnerValue.Length -
                            Constants.StrPreferencePosY.Length);
                        if (strInnerValue.Length > 0)
                        {
                            Int32 iPosY;
                            Int32.TryParse(strInnerValue, out iPosY);

                            MaphackPositionY = iPosY;
                        }

                        else
                            MaphackHeight = 50;
                    }

                    /* Width */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceWidth))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceWidth.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceWidth.Length);

                        Int32 iWidth;
                        Int32.TryParse(strInnerValue, out iWidth);

                        if (iWidth <= 10)
                            WorkerWidth = 300;

                        else
                            MaphackWidth = iWidth;
                    }

                    /* Height */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHeight))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHeight.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHeight.Length);

                        Int32 iHeight;
                        Int32.TryParse(strInnerValue, out iHeight);

                        MaphackHeight = iHeight <= 10 ? 300 : iHeight;
                    }


                    #endregion

                    #region String

                    /* On/ Off Panel */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOnOffText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOnOffText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOnOffText.Length);


                        MaphackTogglePanel = strInnerValue.Length <= 0 ? "/res" : strInnerValue;
                    }

                    /* Change Position */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangePositionText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangePositionText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangePositionText.Length);


                        MaphackChangePositionPanel = strInnerValue.Length <= 0 ? "/rcp" : strInnerValue;
                    }

                    /* Change Size */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceChangeSizeText))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceChangeSizeText.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceChangeSizeText.Length);


                        MaphackChangeSizePanel = strInnerValue.Length <= 0 ? "/rcs" : strInnerValue;
                    }

                    #endregion

                    #region Keys

                    /* UiHotkeys 1 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey1))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey1.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey1.Length);

                        Keys kHotkey1;
                        Enum.TryParse(strInnerValue, out kHotkey1);

                        MaphackHotkey1 = kHotkey1;
                    }

                    /* UiHotkeys 2 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey2))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey2.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey2.Length);

                        Keys kHotkey2;
                        Enum.TryParse(strInnerValue, out kHotkey2);

                        MaphackHotkey2 = kHotkey2;
                    }

                    /* UiHotkeys 3 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey3))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey3.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey3.Length);

                        Keys kHotkey3;
                        Enum.TryParse(strInnerValue, out kHotkey3);

                        MaphackHotkey3 = kHotkey3;
                    }

                    #endregion

                    #region Other

                    /* Opacity */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceOpacity))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceOpacity.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceOpacity.Length);

                        Double dOpacity;
                        Double.TryParse(strInnerValue, out dOpacity);

                        MaphackOpacity = dOpacity;
                    }

                    /* Color */
                    if (strInnerValue.StartsWith("Destination Line Color"))
                    {
                        strInnerValue = strInnerValue.Substring("Destination Line Color".Length,
                            strInnerValue.Length - "Destination Line Color".Length);

                        Color cDefColor = ColorTranslator.FromHtml(strInnerValue);

                        MaphackDestinationColor = cDefColor;
                    }

                    #endregion
                }



                #endregion

                #region Worker Automation

                else if (strKeyword.Equals(Constants.StrPreferenceKeywordWorkerAutomation))
                {
                    #region Boolean values

                    /* Worker Automation */
                    if (strInnerValue.StartsWith("Worker Automation"))
                    {
                        strInnerValue = strInnerValue.Substring("Worker Automation".Length,
                            strInnerValue.Length -
                            "Worker Automation".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        WorkerAutomation = bDummy;
                        bWorkerAutomation = true;
                    }

                    /* Direct Mode */
                    if (strInnerValue.StartsWith("Direct Mode"))
                    {
                        strInnerValue = strInnerValue.Substring("Direct Mode".Length,
                            strInnerValue.Length -
                            "Direct Mode".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        WorkerAutomationModeDirect = bDummy;
                        bWorkerAutomationModeDirect = true;
                    }

                    /* Round Mode */
                    if (strInnerValue.StartsWith("Round Mode"))
                    {
                        strInnerValue = strInnerValue.Substring("Round Mode".Length,
                            strInnerValue.Length -
                            "Round Mode".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        WorkerAutomationModeRound = bDummy;
                        bWorkerAutomationModeRound = true;
                    }

                    /* Disable when selecting */
                    if (strInnerValue.StartsWith("Selecting"))
                    {
                        strInnerValue = strInnerValue.Substring("Selecting".Length,
                            strInnerValue.Length -
                            "Selecting".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        WorkerAutomationDisableWhenSelecting = bDummy;
                        bWorkerAutomationDisableWhenSelecting = true;
                    }

                    /* Disable When Worker is selected */
                    if (strInnerValue.StartsWith("Worker Selected"))
                    {
                        strInnerValue = strInnerValue.Substring("Worker Selected".Length,
                            strInnerValue.Length -
                            "Worker Selected".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        WorkerAutomationDisableWhenWorkerIsSelected = bDummy;
                        bWorkerAutomationDisableWhenWorkerIsSelected = true;
                    }

                    /* Autoupgrade to OC */
                    if (strInnerValue.StartsWith("Autoupgrade To Oc"))
                    {
                        strInnerValue = strInnerValue.Substring("Autoupgrade To Oc".Length,
                            strInnerValue.Length -
                            "Autoupgrade To Oc".Length);

                        bool bDummy;
                        Boolean.TryParse(strInnerValue, out bDummy);

                        WorkerAutomationAutoupgradeToOc = bDummy;
                        bWorkerAutomationAutoupgradeToOc = true;
                    }

                    #endregion

                    #region Int32 values

                    /* Max. Workers */
                    if (strInnerValue.StartsWith("Maximum Workers in game"))
                    {
                        strInnerValue = strInnerValue.Substring("Maximum Workers in game".Length,
                            strInnerValue.Length -
                            "Maximum Workers in game".Length);
                        if (strInnerValue.Length > 0)
                        {
                            Int32 iDummy;
                            Int32.TryParse(strInnerValue, out iDummy);

                            WorkerAutomationMaximumWorkers = iDummy;
                        }

                        else
                            WorkerAutomationMaximumWorkers = 80;

                        bWorkerAutomationMaximumWorkers = true;
                    }

                    /* Max. Workers Per Base */
                    if (strInnerValue.StartsWith("Maximum Workers per Base"))
                    {
                        strInnerValue = strInnerValue.Substring("Maximum Workers per Base".Length,
                            strInnerValue.Length -
                            "Maximum Workers per Base".Length);
                        if (strInnerValue.Length > 0)
                        {
                            Int32 iDummy;
                            Int32.TryParse(strInnerValue, out iDummy);

                            WorkerAutomationMaximumWorkersPerBase = iDummy;
                        }

                        else
                            WorkerAutomationMaximumWorkersPerBase = 30;

                        bWorkerAutomationMaximumWorkersPerBase = true;
                    }

                    /* Max. Worker Puffer */
                    if (strInnerValue.StartsWith("Worker Puffer"))
                    {
                        strInnerValue = strInnerValue.Substring("Worker Puffer".Length,
                            strInnerValue.Length -
                            "Worker Puffer".Length);

                        if (strInnerValue.Length > 0)
                        {
                            Int32 iDummy;
                            Int32.TryParse(strInnerValue, out iDummy);

                            WorkerAutomationPufferWorker = iDummy;
                        }

                        else
                            WorkerAutomationPufferWorker = 5;

                        bWorkerAutomationPufferWorkers = true;
                    }

                    /* Apm Protection */
                    if (strInnerValue.StartsWith("Apm Protection"))
                    {
                        strInnerValue = strInnerValue.Substring("Apm Protection".Length,
                            strInnerValue.Length -
                            "Apm Protection".Length);
                        if (strInnerValue.Length > 0)
                        {
                            Int32 iDummy;
                            Int32.TryParse(strInnerValue, out iDummy);

                            WorkerAutomationApmProtection = iDummy;
                        }

                        else
                        {
                            WorkerAutomationApmProtection = 150;
                        }

                        bWorkerAutomationApmProtection = true;
                    }


                    /* Start Next Worker At */
                    if (strInnerValue.StartsWith("Start Next Worker At"))
                    {
                        strInnerValue = strInnerValue.Substring("Start Next Worker At".Length,
                            strInnerValue.Length -
                            "Start Next Worker At".Length);
                        if (strInnerValue.Length > 0)
                        {
                            Int32 iDummy;
                            Int32.TryParse(strInnerValue, out iDummy);

                            WorkerAutomationStartNextWorkerAt = iDummy;
                        }

                        else
                        {
                            WorkerAutomationStartNextWorkerAt = 95;
                        }

                        bWorkerAutomationStartNextWorkerAt = true;
                    }


                    #endregion

                    #region Keys

                    /* UiHotkeys 1 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey1))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey1.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey1.Length);

                        Keys kHotkey1;
                        Enum.TryParse(strInnerValue, out kHotkey1);

                        WorkerAutomationHotkey1 = kHotkey1;

                        bWorkerAutomationHotKey1 = true;
                    }

                    /* UiHotkeys 2 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey2))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey2.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey2.Length);

                        Keys kHotkey2;
                        Enum.TryParse(strInnerValue, out kHotkey2);

                        WorkerAutomationHotkey2 = kHotkey2;

                        bWorkerAutomationHotKey2 = true;
                    }

                    /* UiHotkeys 3 */
                    if (strInnerValue.StartsWith(Constants.StrPreferenceHotkey3))
                    {
                        strInnerValue = strInnerValue.Substring(Constants.StrPreferenceHotkey3.Length,
                            strInnerValue.Length -
                            Constants.StrPreferenceHotkey3.Length);

                        Keys kHotkey3;
                        Enum.TryParse(strInnerValue, out kHotkey3);

                        WorkerAutomationHotkey3 = kHotkey3;
                        bWorkerAutomationHotKey3 = true;
                    }

                    /* Orbital Key */
                    if (strInnerValue.StartsWith("Orbital Key"))
                    {
                        strInnerValue = strInnerValue.Substring("Orbital Key".Length,
                            strInnerValue.Length -
                            "Orbital Key".Length);

                        Keys kDummy;
                        Enum.TryParse(strInnerValue, out kDummy);

                        WorkerAutomationOrbitalKey = kDummy;
                        bWorkerAutomationOrbitalKey = true;
                    }

                    /* Probe Key */
                    if (strInnerValue.StartsWith("Probe Key"))
                    {
                        strInnerValue = strInnerValue.Substring("Probe Key".Length,
                            strInnerValue.Length -
                            "Probe Key".Length);

                        Keys kDummy;
                        Enum.TryParse(strInnerValue, out kDummy);

                        WorkerAutomationProbeKey = kDummy;
                        bWorkerAutomationProbeKey = true;
                    }

                    /* Scv Key */
                    if (strInnerValue.StartsWith("Scv Key"))
                    {
                        strInnerValue = strInnerValue.Substring("Scv Key".Length,
                            strInnerValue.Length -
                            "Scv Key".Length);

                        Keys kDummy;
                        Enum.TryParse(strInnerValue, out kDummy);

                        WorkerAutomationScvKey = kDummy;
                        bWorkerAutomationScvKey = true;
                    }

                    /* Group [Mainbuilding] Key */
                    if (strInnerValue.StartsWith("Mainbuilding Key"))
                    {
                        strInnerValue = strInnerValue.Substring("Mainbuilding Key".Length,
                            strInnerValue.Length -
                            "Mainbuilding Key".Length);

                        Keys kDummy;
                        Enum.TryParse(strInnerValue, out kDummy);

                        WorkerAutomationMainbuildingGroup = kDummy;
                        bWorkerAutomationMainbuildingGroupKey = true;
                    }

                    /* Group [Backup] Group */
                    if (strInnerValue.StartsWith("Backup Key"))
                    {
                        strInnerValue = strInnerValue.Substring("Backup Key".Length,
                            strInnerValue.Length -
                            "Backup Key".Length);

                        Keys kDummy;
                        Enum.TryParse(strInnerValue, out kDummy);

                        WorkerAutomationBackupGroup = kDummy;
                        bWorkerAutomationBackupGroupKey = true;
                    }

                    #endregion


                }

                #endregion

                #region UnitId's

                else if (strKeyword.Equals(Constants.StrPreferenceKeywordMaphackUnits))
                {
                    /* UnitId */
                    if (strInnerValue.StartsWith("UnitId"))
                    {
                        strInnerValue = strInnerValue.Substring("UnitId".Length,
                            strInnerValue.Length - "UnitId".Length);

                        if (strInnerValue.Length <= 0)
                        {
                            const UnitId uId = UnitId.TuScv;
                            MaphackUnitIds.Add(uId);
                        }

                        else
                        {
                            var id =
                                (UnitId)Enum.Parse(typeof(UnitId), strInnerValue);

                            MaphackUnitIds.Add(id);
                        }
                    }

                    /* UnitColor Color */
                    if (strInnerValue.StartsWith("Unit Color"))
                    {
                        strInnerValue = strInnerValue.Substring("Unit Color".Length,
                            strInnerValue.Length - "Unit Color".Length);

                        if (strInnerValue.Length <= 0)
                            MaphackUnitColors.Add(Color.Transparent);

                        else
                        {
                            var color = ColorTranslator.FromHtml(strInnerValue);

                            MaphackUnitColors.Add(color);
                        }
                    }
                }

                #endregion


            }

            #endregion

            #region Check if a setting was not called

            #region Various

            /* [Resource] Clantag */
            if (!bResourceRemoveClanTagSet)
                ResourceRemoveClanTag = false;

            /* [Income] Clantag */
            if (!bIncomeRemoveClanTagSet)
                IncomeRemoveClanTag = false;

            /* [Apm] Clantag */
            if (!bApmRemoveClanTagSet)
                ApmRemoveClanTag = false;

            /* [Army] Clantag */
            if (!bArmyRemoveClanTagSet)
                ArmyRemoveClanTag = false;

            /* [UnitTab] Clantag */
            if (!bUnitTabRemoveClanTagSet)
                UnitTabRemoveClanTag = false;

            /* [UnitTab] Prod Line */
            if (!bUnitTabRemoveProdLineSet)
                UnitTabRemoveProdLine = false;

            /* [UnitTab] Picturesize */
            if (!bUnitTabPictureSizeSet)
                UnitPictureSize = 45;

            /* [UnitTab] Fontname */
            if (!bUnitTabFontNameSet)
                UnitTabFontName = "Century Gothic";

            if (!bUnitTabShowBuildings)
                UnitTabShowBuildings = true;

            if (!bUnitTabShowUnits)
                UnitTabShowUnits = true;

            if (!bUnitTabChronoboost)
                UnitTabRemoveChronoboost = false;

            if (!bUnitTabSpellCounter)
                UnitTabRemoveSpellCounter = false;

            if (!bLanguage)
                GlobalLanguage = "English";

            #endregion

            #region Personal APM/ Clock

            if (!bPersonalApm)
                PersonalApm = true;

            if (!bPersonalClock)
                PersonalClock = true;

            if (!bPersonalApmAlert)
                PersonalApmAlert = false;

            if (!bPersonalApmAlertLimit)
                PersonalApmAlertLimit = 50;

            if (!bPersonalApmHeight)
                PersonalApmHeight = 50;

            if (!bPersonalApmPositionX)
                PersonalApmPositionX = 50;

            if (!bPersonalApmPositionY)
                PersonalApmPositionY = 50;

            if (!bPersonalApmWidth)
                PersonalApmWidth = 200;

            if (!bPersonalClockHeight)
                PersonalClockHeight = 50;

            if (!bPersonalClockPositionX)
                PersonalClockPositionX = 50;

            if (!bPersonalClockPositionY)
                PersonalClockPositionY = 100;

            if (!bPersonalClockWidth)
                PersonalClockWidth = 200;

            #endregion

            #region Production

            if (!bProdTabFontNameSet)
                ProdTabFontName = "Century Gothic";

            if (!bProdTabHeightSet)
                ProdTabHeight = 50;

            if (!bProdTabHotkey1Set)
                ProdHotkey1 = Keys.ControlKey;

            if (!bProdTabHotkey2Set)
                ProdHotkey2 = Keys.Menu;

            if (!bProdTabHotkey3Set)
                ProdHotkey3 = Keys.NumPad4;

            if (!bProdTabOpacitySet)
                ProdTabOpacity = 1;

            if (!bProdTabPictureSizeSet)
                ProdPictureSize = 45;

            if (!bProdTabPositionXSet)
                ProdTabPositionX = 50;

            if (!bProdTabPositionYSet)
                ResourcePositionY = 50;

            if (!bProdTabRemAiSet)
                ProdTabRemoveAi = false;

            if (!bProdTabRemAllieSet)
                ResourceRemoveAllie = false;

            if (!bProdTabRemLocalplayerSet)
                ResourceRemoveLocalplayer = false;

            if (!bProdTabRemNeutralSet)
                ProdTabRemoveNeutral = true;

            if (!bProdTabRemoveClanTagSet)
                ProdTabRemoveClanTag = false;

            if (!bProdTabShortcutCpSet)
                ProdChangePositionPanel = "/pcp";

            if (!bProdTabShortcutCsSet)
                ProdChangeSizePanel = "/pcs";

            if (!bProdTabShortcutTgSet)
                ProdTogglePanel = "/pro";

            if (!bProdTabSplitBuilldingsSet)
                ProdTabSplitUnitsAndBuildings = true;

            if (!bProdTabWidthSet)
                ProdTabWidth = 50;

            if (!bProdTabShowUpgrades)
                ProdTabShowUpgrades = true;

            if (!bProdTabShowUnits)
                ProdTabShowUnits = true;

            if (!bProdTabShowBuildings)
                ProdTabShowBuildings = true;

            if (!bProdChronoboost)
                ProdTabRemoveChronoboost = false;

            #endregion

            #region Worker Automation

            if (!bWorkerAutomation)
                WorkerAutomation = false;

            if (!bWorkerAutomationApmProtection)
                WorkerAutomationApmProtection = 150;

            if (!bWorkerAutomationStartNextWorkerAt)
                WorkerAutomationStartNextWorkerAt = 95;

            if (!bWorkerAutomationMaximumWorkers)
                WorkerAutomationMaximumWorkers = 80;

            if (!bWorkerAutomationMaximumWorkersPerBase)
                WorkerAutomationMaximumWorkersPerBase = 30;

            if (!bWorkerAutomationPufferWorkers)
                WorkerAutomationPufferWorker = 5;

            if (!bWorkerAutomationModeDirect)
                WorkerAutomationModeDirect = true;

            if (!bWorkerAutomationModeRound)
                WorkerAutomationModeRound = false;

            if (!bWorkerAutomationDisableWhenSelecting)
                WorkerAutomationDisableWhenSelecting = true;

            if (!bWorkerAutomationDisableWhenWorkerIsSelected)
                WorkerAutomationDisableWhenWorkerIsSelected = true;

            if (!bWorkerAutomationAutoupgradeToOc)
                WorkerAutomationAutoupgradeToOc = true;

            if (!bWorkerAutomationScvKey)
                WorkerAutomationScvKey = Keys.S;

            if (!bWorkerAutomationProbeKey)
                WorkerAutomationProbeKey = Keys.E;

            if (!bWorkerAutomationOrbitalKey)
                WorkerAutomationOrbitalKey = Keys.B;

            if (!bWorkerAutomationMainbuildingGroupKey)
                WorkerAutomationMainbuildingGroup = Keys.D3;

            if (!bWorkerAutomationBackupGroupKey)
                WorkerAutomationBackupGroup = Keys.D0;

            if (!bWorkerAutomationHotKey1)
                WorkerAutomationHotkey1 = Keys.ControlKey;

            if (!bWorkerAutomationHotKey2)
                WorkerAutomationHotkey2 = Keys.Menu;

            if (!bWorkerAutomationHotKey3)
                WorkerAutomationHotkey3 = Keys.NumPad0;


            #endregion

            #endregion


            PreferencesSet = 1;
        }

        private void GetStandardPreferences()
        {
            PreferencesSet = 1;
            UnitTabRemoveAi = false;
            UnitTabRemoveAllie = false;
            UnitTabRemoveReferee = true;
            UnitTabRemoveObserver = true;
            UnitTabRemoveNeutral = true;
            UnitTabRemoveLocalplayer = false;
            UnitTabSplitUnitsAndBuildings = true;
            UnitTabRemoveClanTag = false;
            UnitTabPositionX = 50;
            UnitTabPositionY = 50;
            UnitTabWidth = 300;
            UnitTabHeight = 50;
            UnitTabOpacity = 1;
            UnitPictureSize = 45;
            UnitTabShowBuildings = true;
            UnitTabShowUnits = true;
            UnitTabRemoveSpellCounter = false;
            UnitTabRemoveChronoboost = false;
            MaphackRemoveAi = false;
            MaphackRemoveAllie = false;
            MaphackRemoveReferee = true;
            MaphackRemoveObserver = true;
            MaphackRemoveNeutral = true;
            MaphackRemoveLocalplayer = false;
            MaphackRemoveVisionArea = true;
            MaphackRemoveCamera = false;
            MaphackDestinationColor = Color.Orange;
            MaphackPositionX = 28;
            MaphackPositionY = 811;
            MaphackWidth = 261;
            MaphackHeight = 255;
            MaphackColorUnit1 = Color.Transparent;
            MaphackColorUnit2 = Color.Transparent;
            MaphackColorUnit3 = Color.Transparent;
            MaphackColorUnit4 = Color.Transparent;
            MaphackColorUnit5 = Color.Transparent;
            MaphackUnitId1 = UnitId.TuScv;
            MaphackUnitId2 = UnitId.TuScv;
            MaphackUnitId3 = UnitId.TuScv;
            MaphackUnitId4 = UnitId.TuScv;
            MaphackUnitId5 = UnitId.TuScv;
            MaphackOpacity = 1;
            ResourcePositionX = 500;
            ResourcePositionY = 50;
            ResourceWidth = 600;
            ResourceHeight = 50;
            ResourceRemoveAi = false;
            ResourceRemoveAllie = false;
            ResourceRemoveLocalplayer = false;
            ResourceRemoveNeutral = true;
            ResourceRemoveClanTag = false;
            ResourceFontName = "Century Gothic";
            ResourceOpacity = 0.75;
            IncomePositionX = 1500;
            IncomePositionY = 300;
            IncomeWidth = 600;
            IncomeHeight = 50;
            IncomeRemoveAi = false;
            IncomeRemoveAllie = false;
            IncomeRemoveLocalplayer = false;
            IncomeRemoveNeutral = true;
            IncomeRemoveClanTag = false;
            IncomeFontName = "Century Gothic";
            IncomeOpacity = 0.75;
            ArmyPositionX = 500;
            ArmyPositionY = 300;
            ArmyWidth = 600;
            ArmyHeight = 50;
            ArmyRemoveAi = false;
            ArmyRemoveAllie = false;
            ArmyRemoveLocalplayer = false;
            ArmyRemoveNeutral = true;
            ArmyRemoveClanTag = false;
            ArmyFontName = "Century Gothic";
            ArmyOpacity = 0.75;
            ApmPositionX = 500;
            ApmPositionY = 300;
            ApmWidth = 600;
            ApmHeight = 50;
            ApmRemoveAi = false;
            ApmRemoveAllie = false;
            ApmRemoveLocalplayer = false;
            ApmRemoveNeutral = true;
            ApmRemoveClanTag = false;
            ApmFontName = "Century Gothic";
            ApmOpacity = 0.75;
            WorkerPositionX = 500;
            WorkerPositionY = 300;
            WorkerWidth = 200;
            WorkerHeight = 50;
            WorkerFontName = "Century Gothic";
            WorkerOpacity = 0.75;
            GlobalDataRefresh = 100;
            GlobalDrawingRefresh = 100;
            GlobalDrawOnlyInForeground = false;
            ResourceTogglePanel = "/res";
            ResourceChangePositionPanel = "/rcp";
            ResourceChangeSizePanel = "/rcs";
            ResourceHotkey1 = Keys.ControlKey;
            ResourceHotkey2 = Keys.Menu;
            ResourceHotkey3 = Keys.NumPad1;
            IncomeTogglePanel = "/inc";
            IncomeChangePositionPanel = "/icp";
            IncomeChangeSizePanel = "/ics";
            IncomeHotkey1 = Keys.ControlKey;
            IncomeHotkey2 = Keys.Menu;
            IncomeHotkey3 = Keys.NumPad2;
            WorkerTogglePanel = "/wor";
            WorkerChangePositionPanel = "/wcp";
            WorkerChangeSizePanel = "/wcs";
            WorkerHotkey1 = Keys.ControlKey;
            WorkerHotkey2 = Keys.Menu;
            WorkerHotkey3 = Keys.NumPad3;
            MaphackTogglePanel = "/map";
            MaphackChangePositionPanel = "/mcp";
            MaphackChangeSizePanel = "/mcs";
            MaphackHotkey1 = Keys.ControlKey;
            MaphackHotkey2 = Keys.Menu;
            MaphackHotkey3 = Keys.NumPad5;
            ApmTogglePanel = "/apm";
            ApmChangePositionPanel = "/acp";
            ApmChangeSizePanel = "/acs";
            ApmHotkey1 = Keys.ControlKey;
            ApmHotkey2 = Keys.Menu;
            ApmHotkey3 = Keys.NumPad7;
            ArmyTogglePanel = "/arm";
            ArmyChangePositionPanel = "/amcp";
            ArmyChangeSizePanel = "/amcs";
            ArmyHotkey1 = Keys.ControlKey;
            ArmyHotkey2 = Keys.Menu;
            ArmyHotkey3 = Keys.NumPad8;
            UnitTogglePanel = "/uni";
            UnitChangePositionPanel = "/ucp";
            UnitChangeSizePanel = "/ucs";
            UnitHotkey1 = Keys.ControlKey;
            UnitHotkey2 = Keys.Menu;
            UnitHotkey3 = Keys.NumPad9;
            GlobalChangeSizeAndPosition = Keys.NumPad0;
            MaphackDisableDestinationLine = false;
            GlobalOnlyDrawWhenUnpaused = true;
            ResourceDrawBackground = true;
            IncomeDrawBackground = true;
            WorkerDrawBackground = true;
            ApmDrawBackground = true;
            ArmyDrawBackground = true;
            MaphackColorDefensivestructuresYellow = true;
            StealUnits = true;
            StealUnitsInstant = false;
            StealUnitsHotkey = true;
            StealUnitsHotkey1 = Keys.ControlKey;
            StealUnitsHotkey2 = Keys.Menu;
            StealUnitsHotkey3 = Keys.Add;
            UnitTabFontName = "Century Gothic";
            UnitTabRemoveProdLine = false;
            ProdChangePositionPanel = "/pcp";
            ProdChangeSizePanel = "/pcs";
            ProdHotkey1 = Keys.ControlKey;
            ProdHotkey2 = Keys.Menu;
            ProdHotkey3 = Keys.NumPad4;
            ProdPictureSize = 45;
            ProdTabFontName = "Century Gothic";
            ProdTabHeight = 666;
            ProdTabOpacity = 1;
            ProdTabPositionX = 0;
            ProdTabPositionY = 0;
            ProdTabShowBuildings = true;
            ProdTabShowUnits = true;
            ProdTabShowUpgrades = true;
            ProdTabRemoveAi = false;
            ProdTabRemoveAllie = false;
            ProdTabRemoveClanTag = true;
            ProdTabRemoveLocalplayer = false;
            ProdTabRemoveNeutral = true;
            ProdTabRemoveObserver = true;
            ProdTabRemoveReferee = true;
            ProdTabSplitUnitsAndBuildings = true;
            ProdTabWidth = 666;
            ProdTabRemoveChronoboost = false;
            ProdTogglePanel = "/pro";
            PersonalApm = true;
            PersonalApmPositionX = 50;
            PersonalApmPositionY = 50;
            PersonalClock = true;
            PersonalClockPositionX = 300;
            PersonalClockPositionY = 50;
            PersonalApmHeight = 50;
            PersonalApmWidth = 200;
            PersonalClockHeight = 50;
            PersonalClockWidth = 200;
            PersonalApmAlert = false;
            PersonalApmAlertLimit = 5;
            WorkerAutomation = false;
            WorkerAutomationApmProtection = 150;
            WorkerAutomationAutoupgradeToOc = true;
            WorkerAutomationBackupGroup = Keys.D0;
            WorkerAutomationDisableWhenSelecting = true;
            WorkerAutomationDisableWhenWorkerIsSelected = true;
            WorkerAutomationHotkey1 = Keys.ControlKey;
            WorkerAutomationHotkey2 = Keys.Menu;
            WorkerAutomationHotkey3 = Keys.NumPad0;
            WorkerAutomationMainbuildingGroup = Keys.D3;
            WorkerAutomationMaximumWorkers = 80;
            WorkerAutomationMaximumWorkersPerBase = 30;
            WorkerAutomationModeDirect = false;
            WorkerAutomationModeRound = true;
            WorkerAutomationOrbitalKey = Keys.B;
            WorkerAutomationProbeKey = Keys.E;
            WorkerAutomationPufferWorker = 5;
            WorkerAutomationScvKey = Keys.S;
            WorkerAutomationStartNextWorkerAt = 90;
            GlobalLanguage = "English";


            //HelpFunctions.InitResolution(ref pSettings);


        }

        private static void WriteSubSetting(StreamWriter sw, object variable, string definition)
        {
            sw.WriteLine(";Type = " + variable.GetType());
            sw.WriteLine(definition + " = " + variable);

            //var Vars = (type.GetType())Convert.ChangeType(variable, variable.GetType());
        }

        private static T ReadSubSetting<T>(T variable, string definition, string innerString)
        {
            if (variable is bool)
            {
                var tmp = Convert.ToBoolean(variable);
                if (tmp)
                    return variable;//(T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom("true");

                if (innerString.StartsWith(definition))
                {
                    innerString = innerString.Substring(definition.Length,
                            innerString.Length -
                            definition.Length);

                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(innerString);
                }
            }

            else if (variable is Int32)
            {
                if (Convert.ToInt32(variable) != 0)
                    return variable;

                if (innerString.StartsWith(definition))
                {
                    innerString = innerString.Substring(definition.Length,
                            innerString.Length -
                            definition.Length);

                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(innerString);
                }
            }

            else if (variable is Keys)
            {
                if (Convert.ToInt32(variable) != 0)
                    return variable;

                if (innerString.StartsWith(definition))
                {
                    innerString = innerString.Substring(definition.Length,
                            innerString.Length -
                            definition.Length);

                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(innerString);
                }
            }

            else if (variable is string)
            {
                if (variable.ToString().Length > 0)
                    return variable;

                if (innerString.StartsWith(definition))
                {
                    innerString = innerString.Substring(definition.Length,
                            innerString.Length -
                            definition.Length);

                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(innerString);
                }
            }

            return variable;
        }
    }

    public class PreferencesStruct
    {
        /// <summary>
        /// Setting up default values..
        /// </summary>
        public PreferencesStruct()
        {
            ProdTabUseTransparentImages = true;

            UnitTabUseTransparentImages = true;
        }

        public Byte PreferencesSet { get; set; }
        public IsDeveloper GlobalIsDeveloper { get; set; }
        public Boolean ProdTabRemoveAi { get; set; }
        public Boolean ProdTabRemoveAllie { get; set; }
        public Boolean ProdTabRemoveReferee { get; set; }
        public Boolean ProdTabRemoveObserver { get; set; }
        public Boolean ProdTabRemoveNeutral { get; set; }
        public Boolean ProdTabRemoveLocalplayer { get; set; }
        public Boolean ProdTabSplitUnitsAndBuildings { get; set; }
        public Boolean ProdTabUseTransparentImages { get; set; }
        public Boolean ProdTabRemoveClanTag { get; set; }
        public Boolean ProdTabRemoveChronoboost { get; set; }
        public Int32 ProdTabPositionX { get; set; }
        public Int32 ProdTabPositionY { get; set; }
        public Int32 ProdTabWidth { get; set; }
        public Int32 ProdTabHeight { get; set; }
        public Double ProdTabOpacity { get; set; }
        public Int32 ProdPictureSize { get; set; }
        public string ProdTabFontName { get; set; }
        public string ProdTogglePanel { get; set; }
        public string ProdChangePositionPanel { get; set; }
        public string ProdChangeSizePanel { get; set; }
        public Boolean ProdTabShowUnits { get; set; }
        public Boolean ProdTabShowBuildings { get; set; }
        public Boolean ProdTabShowUpgrades { get; set; }
        public Keys ProdHotkey1 { get; set; }
        public Keys ProdHotkey2 { get; set; }
        public Keys ProdHotkey3 { get; set; }
        public Boolean UnitTabRemoveAi { get; set; }
        public Boolean UnitTabRemoveAllie { get; set; }
        public Boolean UnitTabRemoveReferee { get; set; }
        public Boolean UnitTabRemoveObserver { get; set; }
        public Boolean UnitTabRemoveNeutral { get; set; }
        public Boolean UnitTabRemoveLocalplayer { get; set; }
        public Boolean UnitTabSplitUnitsAndBuildings { get; set; }
        public Boolean UnitTabRemoveClanTag { get; set; }
        public Boolean UnitTabRemoveProdLine { get; set; }
        public Boolean UnitTabRemoveChronoboost { get; set; }
        public Boolean UnitTabRemoveSpellCounter { get; set; }
        public Boolean UnitTabUseTransparentImages { get; set; }
        public Int32 UnitTabPositionX { get; set; }
        public Int32 UnitTabPositionY { get; set; }
        public Int32 UnitTabWidth { get; set; }
        public Int32 UnitTabHeight { get; set; }
        public Double UnitTabOpacity { get; set; }
        public Int32 UnitPictureSize { get; set; }
        public Boolean UnitTabShowUnits { get; set; }
        public Boolean UnitTabShowBuildings { get; set; }
        public string UnitTabFontName { get; set; }
        public Boolean MaphackRemoveAi { get; set; }
        public Boolean MaphackRemoveAllie { get; set; }
        public Boolean MaphackRemoveReferee { get; set; }
        public Boolean MaphackRemoveObserver { get; set; }
        public Boolean MaphackRemoveNeutral { get; set; }
        public Boolean MaphackRemoveLocalplayer { get; set; }
        public Boolean MaphackRemoveVisionArea { get; set; }
        public Boolean MaphackRemoveCamera { get; set; }
        public Color MaphackDestinationColor { get; set; }
        public Int32 MaphackPositionX { get; set; }
        public Int32 MaphackPositionY { get; set; }
        public Int32 MaphackWidth { get; set; }
        public Int32 MaphackHeight { get; set; }
        public Color MaphackColorUnit1 { get; set; }
        public Color MaphackColorUnit2 { get; set; }
        public Color MaphackColorUnit3 { get; set; }
        public Color MaphackColorUnit4 { get; set; }
        public Color MaphackColorUnit5 { get; set; }
        public UnitId MaphackUnitId1 { get; set; }
        public UnitId MaphackUnitId2 { get; set; }
        public UnitId MaphackUnitId3 { get; set; }
        public UnitId MaphackUnitId4 { get; set; }
        public UnitId MaphackUnitId5 { get; set; }
        public Double MaphackOpacity { get; set; }
        public Int32 ResourcePositionX { get; set; }
        public Int32 ResourcePositionY { get; set; }
        public Int32 ResourceWidth { get; set; }
        public Int32 ResourceHeight { get; set; }
        public Boolean ResourceRemoveAi { get; set; }
        public Boolean ResourceRemoveNeutral { get; set; }
        public Boolean ResourceRemoveAllie { get; set; }
        public Boolean ResourceRemoveLocalplayer { get; set; }
        public Boolean ResourceRemoveClanTag { get; set; }
        public string ResourceFontName { get; set; }
        public Double ResourceOpacity { get; set; }
        public Int32 IncomePositionX { get; set; }
        public Int32 IncomePositionY { get; set; }
        public Int32 IncomeWidth { get; set; }
        public Int32 IncomeHeight { get; set; }
        public Boolean IncomeRemoveAi { get; set; }
        public Boolean IncomeRemoveNeutral { get; set; }
        public Boolean IncomeRemoveAllie { get; set; }
        public Boolean IncomeRemoveLocalplayer { get; set; }
        public Boolean IncomeRemoveClanTag { get; set; }
        public string IncomeFontName { get; set; }
        public Double IncomeOpacity { get; set; }
        public Int32 ArmyPositionX { get; set; }
        public Int32 ArmyPositionY { get; set; }
        public Int32 ArmyWidth { get; set; }
        public Int32 ArmyHeight { get; set; }
        public Boolean ArmyRemoveAi { get; set; }
        public Boolean ArmyRemoveNeutral { get; set; }
        public Boolean ArmyRemoveAllie { get; set; }
        public Boolean ArmyRemoveLocalplayer { get; set; }
        public Boolean ArmyRemoveClanTag { get; set; }
        public string ArmyFontName { get; set; }
        public Double ArmyOpacity { get; set; }
        public Int32 ApmPositionX { get; set; }
        public Int32 ApmPositionY { get; set; }
        public Int32 ApmWidth { get; set; }
        public Int32 ApmHeight { get; set; }
        public Boolean ApmRemoveAi { get; set; }
        public Boolean ApmRemoveNeutral { get; set; }
        public Boolean ApmRemoveAllie { get; set; }
        public Boolean ApmRemoveLocalplayer { get; set; }
        public Boolean ApmRemoveClanTag { get; set; }
        public string ApmFontName { get; set; }
        public Double ApmOpacity { get; set; }
        public Int32 WorkerPositionX { get; set; }
        public Int32 WorkerPositionY { get; set; }
        public Int32 WorkerWidth { get; set; }
        public Int32 WorkerHeight { get; set; }
        public string WorkerFontName { get; set; }
        public Double WorkerOpacity { get; set; }
        public Int32 GlobalDataRefresh { get; set; }
        public Int32 GlobalDrawingRefresh { get; set; }
        public Boolean GlobalDrawOnlyInForeground { get; set; }
        public string ResourceTogglePanel { get; set; }
        public string ResourceChangePositionPanel { get; set; }
        public string ResourceChangeSizePanel { get; set; }
        public Keys ResourceHotkey1 { get; set; }
        public Keys ResourceHotkey2 { get; set; }
        public Keys ResourceHotkey3 { get; set; }
        public string IncomeTogglePanel { get; set; }
        public string IncomeChangePositionPanel { get; set; }
        public string IncomeChangeSizePanel { get; set; }
        public Keys IncomeHotkey1 { get; set; }
        public Keys IncomeHotkey2 { get; set; }
        public Keys IncomeHotkey3 { get; set; }
        public string WorkerTogglePanel { get; set; }
        public string WorkerChangePositionPanel { get; set; }
        public string WorkerChangeSizePanel { get; set; }
        public Keys WorkerHotkey1 { get; set; }
        public Keys WorkerHotkey2 { get; set; }
        public Keys WorkerHotkey3 { get; set; }
        public string MaphackTogglePanel { get; set; }
        public string MaphackChangePositionPanel { get; set; }
        public string MaphackChangeSizePanel { get; set; }
        public Keys MaphackHotkey1 { get; set; }
        public Keys MaphackHotkey2 { get; set; }
        public Keys MaphackHotkey3 { get; set; }
        public string ApmTogglePanel { get; set; }
        public string ApmChangePositionPanel { get; set; }
        public string ApmChangeSizePanel { get; set; }
        public Keys ApmHotkey1 { get; set; }
        public Keys ApmHotkey2 { get; set; }
        public Keys ApmHotkey3 { get; set; }
        public string ArmyTogglePanel { get; set; }
        public string ArmyChangePositionPanel { get; set; }
        public string ArmyChangeSizePanel { get; set; }
        public Keys ArmyHotkey1 { get; set; }
        public Keys ArmyHotkey2 { get; set; }
        public Keys ArmyHotkey3 { get; set; }
        public string UnitTogglePanel { get; set; }
        public string UnitChangePositionPanel { get; set; }
        public string UnitChangeSizePanel { get; set; }
        public Keys UnitHotkey1 { get; set; }
        public Keys UnitHotkey2 { get; set; }
        public Keys UnitHotkey3 { get; set; }
        public Keys GlobalChangeSizeAndPosition { get; set; }
        public Boolean MaphackDisableDestinationLine { get; set; }
        public Boolean GlobalOnlyDrawWhenUnpaused { get; set; }
        public Boolean ResourceDrawBackground { get; set; }
        public Boolean IncomeDrawBackground { get; set; }
        public Boolean WorkerDrawBackground { get; set; }
        public Boolean ApmDrawBackground { get; set; }
        public Boolean ArmyDrawBackground { get; set; }
        public Boolean MaphackColorDefensivestructuresYellow { get; set; }
        public Boolean StealUnits { get; set; }
        public Boolean StealUnitsInstant { get; set; }
        public Boolean StealUnitsHotkey { get; set; }
        public Keys StealUnitsHotkey1 { get; set; }
        public Keys StealUnitsHotkey2 { get; set; }
        public Keys StealUnitsHotkey3 { get; set; }
        public List<UnitId> MaphackUnitIds { get; set; }
        public List<Color> MaphackUnitColors { get; set; }
        public Boolean PersonalApm { get; set; }
        public Int32 PersonalApmPositionX { get; set; }
        public Int32 PersonalApmPositionY { get; set; }
        public Int32 PersonalApmWidth { get; set; }
        public Int32 PersonalApmHeight { get; set; }
        public Boolean PersonalClock { get; set; }
        public Int32 PersonalClockPositionX { get; set; }
        public Int32 PersonalClockPositionY { get; set; }
        public Int32 PersonalClockWidth { get; set; }
        public Int32 PersonalClockHeight { get; set; }
        public Boolean PersonalApmAlert { get; set; }
        public Int32 PersonalApmAlertLimit { get; set; }
        public Boolean WorkerAutomation { get; set; }
        public Int32 WorkerAutomationMaximumWorkers { get; set; }
        public Int32 WorkerAutomationMaximumWorkersPerBase { get; set; }
        public Int32 WorkerAutomationPufferWorker { get; set; }
        public Int32 WorkerAutomationApmProtection { get; set; }
        public Int32 WorkerAutomationStartNextWorkerAt { get; set; }
        public Boolean WorkerAutomationModeDirect { get; set; }
        public Boolean WorkerAutomationModeRound { get; set; }
        public Boolean WorkerAutomationDisableWhenSelecting { get; set; }
        public Boolean WorkerAutomationDisableWhenWorkerIsSelected { get; set; }
        public Boolean WorkerAutomationAutoupgradeToOc { get; set; }
        public Keys WorkerAutomationScvKey { get; set; }
        public Keys WorkerAutomationProbeKey { get; set; }
        public Keys WorkerAutomationOrbitalKey { get; set; }
        public Keys WorkerAutomationMainbuildingGroup { get; set; }
        public Keys WorkerAutomationBackupGroup { get; set; }
        public Keys WorkerAutomationHotkey1 { get; set; }
        public Keys WorkerAutomationHotkey2 { get; set; }
        public Keys WorkerAutomationHotkey3 { get; set; }
        public string GlobalLanguage { get; set; }
    };
}