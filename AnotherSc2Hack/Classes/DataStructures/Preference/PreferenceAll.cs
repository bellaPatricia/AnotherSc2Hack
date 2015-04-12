using System.IO;
using AnotherSc2Hack.Classes.BackEnds;

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
        public PreferenceWorkerCoach OverlayWorkerCoach { get; set; }


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
            OverlayWorkerCoach = new PreferenceWorkerCoach();
        }

        public void ConvertOldSettings()
        {
            //Init and read
            var oldPreferences = new Preferences();

            #region Global

            Global.ChangeSizeAndPosition = oldPreferences.GlobalChangeSizeAndPosition;
            Global.DataRefresh = oldPreferences.GlobalDataRefresh;
            Global.DrawOnlyInForeground = oldPreferences.GlobalDrawOnlyInForeground;
            Global.DrawingRefresh = oldPreferences.GlobalDrawingRefresh;
            Global.Language = oldPreferences.GlobalLanguage;

            #endregion

            #region Resources

            OverlayResources.ChangePosition = oldPreferences.ResourceChangePositionPanel;
            OverlayResources.ChangeSize =
            oldPreferences.ResourceChangeSizePanel;
            OverlayResources.DrawBackground = oldPreferences.ResourceDrawBackground;
            OverlayResources.FontName = oldPreferences.ResourceFontName;
            OverlayResources.Height = oldPreferences.ResourceHeight;
            OverlayResources.Hotkey1 = oldPreferences.ResourceHotkey1;
            OverlayResources.Hotkey2 = oldPreferences.ResourceHotkey2;
            OverlayResources.Hotkey3 = oldPreferences.ResourceHotkey3;
            OverlayResources.Opacity = oldPreferences.ResourceOpacity;
            OverlayResources.RemoveAi = oldPreferences.ResourceRemoveAi;
            OverlayResources.RemoveAllie = oldPreferences.ResourceRemoveAllie;
            OverlayResources.RemoveClanTag = oldPreferences.ResourceRemoveClanTag;
            OverlayResources.RemoveLocalplayer = oldPreferences.ResourceRemoveLocalplayer;
            OverlayResources.RemoveNeutral = oldPreferences.ResourceRemoveNeutral;
            OverlayResources.TogglePanel = oldPreferences.ResourceTogglePanel;
            OverlayResources.Width = oldPreferences.ResourceWidth;
            OverlayResources.X = oldPreferences.ResourcePositionX;
            OverlayResources.Y = oldPreferences.ResourcePositionY;

            #endregion

            #region Income

            OverlayIncome.ChangePosition = oldPreferences.IncomeChangePositionPanel;
            OverlayIncome.ChangeSize =
            oldPreferences.IncomeChangeSizePanel;
            OverlayIncome.DrawBackground = oldPreferences.IncomeDrawBackground;
            OverlayIncome.FontName = oldPreferences.IncomeFontName;
            OverlayIncome.Height = oldPreferences.IncomeHeight;
            OverlayIncome.Hotkey1 = oldPreferences.IncomeHotkey1;
            OverlayIncome.Hotkey2 = oldPreferences.IncomeHotkey2;
            OverlayIncome.Hotkey3 = oldPreferences.IncomeHotkey3;
            OverlayIncome.Opacity = oldPreferences.IncomeOpacity;
            OverlayIncome.RemoveAi = oldPreferences.IncomeRemoveAi;
            OverlayIncome.RemoveAllie = oldPreferences.IncomeRemoveAllie;
            OverlayIncome.RemoveClanTag = oldPreferences.IncomeRemoveClanTag;
            OverlayIncome.RemoveLocalplayer = oldPreferences.IncomeRemoveLocalplayer;
            OverlayIncome.RemoveNeutral = oldPreferences.IncomeRemoveNeutral;
            OverlayIncome.TogglePanel = oldPreferences.IncomeTogglePanel;
            OverlayIncome.Width = oldPreferences.IncomeWidth;
            OverlayIncome.X = oldPreferences.IncomePositionX;
            OverlayIncome.Y = oldPreferences.IncomePositionY;

            #endregion

            #region Army

            OverlayArmy.ChangePosition = oldPreferences.ArmyChangePositionPanel;
            OverlayArmy.ChangeSize =
            oldPreferences.ArmyChangeSizePanel;
            OverlayArmy.DrawBackground = oldPreferences.ArmyDrawBackground;
            OverlayArmy.FontName = oldPreferences.ArmyFontName;
            OverlayArmy.Height = oldPreferences.ArmyHeight;
            OverlayArmy.Hotkey1 = oldPreferences.ArmyHotkey1;
            OverlayArmy.Hotkey2 = oldPreferences.ArmyHotkey2;
            OverlayArmy.Hotkey3 = oldPreferences.ArmyHotkey3;
            OverlayArmy.Opacity = oldPreferences.ArmyOpacity;
            OverlayArmy.RemoveAi = oldPreferences.ArmyRemoveAi;
            OverlayArmy.RemoveAllie = oldPreferences.ArmyRemoveAllie;
            OverlayArmy.RemoveClanTag = oldPreferences.ArmyRemoveClanTag;
            OverlayArmy.RemoveLocalplayer = oldPreferences.ArmyRemoveLocalplayer;
            OverlayArmy.RemoveNeutral = oldPreferences.ArmyRemoveNeutral;
            OverlayArmy.TogglePanel = oldPreferences.ArmyTogglePanel;
            OverlayArmy.Width = oldPreferences.ArmyWidth;
            OverlayArmy.X = oldPreferences.ArmyPositionX;
            OverlayArmy.Y = oldPreferences.ArmyPositionY;

            #endregion

            #region Apm

            OverlayApm.ChangePosition = oldPreferences.ApmChangePositionPanel;
            OverlayApm.ChangeSize =
            oldPreferences.ApmChangeSizePanel;
            OverlayApm.DrawBackground = oldPreferences.ApmDrawBackground;
            OverlayApm.FontName = oldPreferences.ApmFontName;
            OverlayApm.Height = oldPreferences.ApmHeight;
            OverlayApm.Hotkey1 = oldPreferences.ApmHotkey1;
            OverlayApm.Hotkey2 = oldPreferences.ApmHotkey2;
            OverlayApm.Hotkey3 = oldPreferences.ApmHotkey3;
            OverlayApm.Opacity = oldPreferences.ApmOpacity;
            OverlayApm.RemoveAi = oldPreferences.ApmRemoveAi;
            OverlayApm.RemoveAllie = oldPreferences.ApmRemoveAllie;
            OverlayApm.RemoveClanTag = oldPreferences.ApmRemoveClanTag;
            OverlayApm.RemoveLocalplayer = oldPreferences.ApmRemoveLocalplayer;
            OverlayApm.RemoveNeutral = oldPreferences.ApmRemoveNeutral;
            OverlayApm.TogglePanel = oldPreferences.ApmTogglePanel;
            OverlayApm.Width = oldPreferences.ApmWidth;
            OverlayApm.X = oldPreferences.ApmPositionX;
            OverlayApm.Y = oldPreferences.ApmPositionY;

            #endregion

            #region Maphack

            OverlayMaphack.ChangePosition = oldPreferences.MaphackChangePositionPanel;
            OverlayMaphack.ChangeSize =
            oldPreferences.MaphackChangeSizePanel;
            OverlayMaphack.Height = oldPreferences.MaphackHeight;
            OverlayMaphack.Hotkey1 = oldPreferences.MaphackHotkey1;
            OverlayMaphack.Hotkey2 = oldPreferences.MaphackHotkey2;
            OverlayMaphack.Hotkey3 = oldPreferences.MaphackHotkey3;
            OverlayMaphack.Opacity = oldPreferences.MaphackOpacity;
            OverlayMaphack.RemoveAi = oldPreferences.MaphackRemoveAi;
            OverlayMaphack.RemoveAllie = oldPreferences.MaphackRemoveAllie;
            OverlayMaphack.RemoveLocalplayer = oldPreferences.MaphackRemoveLocalplayer;
            OverlayMaphack.RemoveNeutral = oldPreferences.MaphackRemoveNeutral;
            OverlayMaphack.TogglePanel = oldPreferences.MaphackTogglePanel;
            OverlayMaphack.Width = oldPreferences.MaphackWidth;
            OverlayMaphack.X = oldPreferences.MaphackPositionX;
            OverlayMaphack.Y = oldPreferences.MaphackPositionY;
            OverlayMaphack.UnitIds = oldPreferences.MaphackUnitIds;
            foreach (var maphackUnitColor in oldPreferences.MaphackUnitColors)
            {
                OverlayMaphack.UnitColors.Add(maphackUnitColor);
            }
            OverlayMaphack.ColorDefensiveStructures = oldPreferences.MaphackColorDefensivestructuresYellow;
            OverlayMaphack.DestinationLine = oldPreferences.MaphackDestinationColor;
            OverlayMaphack.RemoveCamera = oldPreferences.MaphackRemoveCamera;
            OverlayMaphack.RemoveDestinationLine = oldPreferences.MaphackDisableDestinationLine;
            OverlayMaphack.RemoveVisionArea = oldPreferences.MaphackRemoveVisionArea;


            #endregion

            #region Unittab

            OverlayUnits.ChangePosition = oldPreferences.UnitChangePositionPanel;
            OverlayUnits.ChangeSize =
            oldPreferences.UnitChangeSizePanel;
            OverlayUnits.FontName = oldPreferences.UnitTabFontName;
            OverlayUnits.Height = oldPreferences.UnitTabHeight;
            OverlayUnits.Hotkey1 = oldPreferences.UnitHotkey1;
            OverlayUnits.Hotkey2 = oldPreferences.UnitHotkey2;
            OverlayUnits.Hotkey3 = oldPreferences.UnitHotkey3;
            OverlayUnits.Opacity = oldPreferences.UnitTabOpacity;
            OverlayUnits.RemoveAi = oldPreferences.UnitTabRemoveAi;
            OverlayUnits.RemoveAllie = oldPreferences.UnitTabRemoveAllie;
            OverlayUnits.RemoveClanTag = oldPreferences.UnitTabRemoveClanTag;
            OverlayUnits.RemoveLocalplayer = oldPreferences.UnitTabRemoveLocalplayer;
            OverlayUnits.RemoveNeutral = oldPreferences.UnitTabRemoveNeutral;
            OverlayUnits.TogglePanel = oldPreferences.UnitTogglePanel;
            OverlayUnits.Width = oldPreferences.UnitTabWidth;
            OverlayUnits.X = oldPreferences.UnitTabPositionX;
            OverlayUnits.Y = oldPreferences.UnitTabPositionY;
            OverlayUnits.UseTransparentImages = oldPreferences.UnitTabUseTransparentImages;
            OverlayUnits.SplitBuildingsAndUnits = oldPreferences.UnitTabSplitUnitsAndBuildings;
            OverlayUnits.ShowUnits = oldPreferences.UnitTabShowUnits;
            OverlayUnits.ShowBuildings = oldPreferences.UnitTabShowBuildings;
            OverlayUnits.RemoveSpellCounter = oldPreferences.UnitTabRemoveSpellCounter;
            OverlayUnits.RemoveProductionLine = oldPreferences.UnitTabRemoveProdLine;
            OverlayUnits.RemoveChronoboost = oldPreferences.UnitTabRemoveChronoboost;
            OverlayUnits.PictureSize = oldPreferences.UnitPictureSize;

            #endregion

            #region Prouctiontab

            OverlayProduction.ChangePosition = oldPreferences.ProdChangePositionPanel;
            OverlayProduction.ChangeSize =
            oldPreferences.ProdChangeSizePanel;
            OverlayProduction.FontName = oldPreferences.ProdTabFontName;
            OverlayProduction.Height = oldPreferences.ProdTabHeight;
            OverlayProduction.Hotkey1 = oldPreferences.ProdHotkey1;
            OverlayProduction.Hotkey2 = oldPreferences.ProdHotkey2;
            OverlayProduction.Hotkey3 = oldPreferences.ProdHotkey3;
            OverlayProduction.Opacity = oldPreferences.ProdTabOpacity;
            OverlayProduction.RemoveAi = oldPreferences.ProdTabRemoveAi;
            OverlayProduction.RemoveAllie = oldPreferences.ProdTabRemoveAllie;
            OverlayProduction.RemoveClanTag = oldPreferences.ProdTabRemoveClanTag;
            OverlayProduction.RemoveLocalplayer = oldPreferences.ProdTabRemoveLocalplayer;
            OverlayProduction.RemoveNeutral = oldPreferences.ProdTabRemoveNeutral;
            OverlayProduction.TogglePanel = oldPreferences.ProdTogglePanel;
            OverlayProduction.Width = oldPreferences.ProdTabWidth;
            OverlayProduction.X = oldPreferences.ProdTabPositionX;
            OverlayProduction.Y = oldPreferences.ProdTabPositionY;
            OverlayProduction.UseTransparentImages = oldPreferences.ProdTabUseTransparentImages;
            OverlayProduction.SplitBuildingsAndUnits = oldPreferences.ProdTabSplitUnitsAndBuildings;
            OverlayProduction.ShowUnits = oldPreferences.ProdTabShowUnits;
            OverlayProduction.ShowBuildings = oldPreferences.ProdTabShowBuildings;
            OverlayProduction.ShowUpgrades = oldPreferences.ProdTabShowUpgrades;
            OverlayProduction.RemoveChronoboost = oldPreferences.ProdTabRemoveChronoboost;
            OverlayProduction.PictureSize = oldPreferences.ProdPictureSize;

            #endregion

            #region Worker

            OverlayWorker.Height = oldPreferences.WorkerHeight;
            OverlayWorker.Width = oldPreferences.WorkerWidth;
            OverlayWorker.X = oldPreferences.WorkerPositionX;
            OverlayWorker.Y = oldPreferences.WorkerPositionY;
            OverlayWorker.FontName = oldPreferences.WorkerFontName;
            OverlayWorker.DrawBackground = oldPreferences.WorkerDrawBackground;
            OverlayWorker.Hotkey1 = oldPreferences.WorkerHotkey1;
            OverlayWorker.Hotkey2 = oldPreferences.WorkerHotkey2;
            OverlayWorker.Hotkey3 = oldPreferences.WorkerHotkey3;
            OverlayWorker.Opacity = oldPreferences.WorkerOpacity;
            OverlayWorker.TogglePanel = oldPreferences.WorkerTogglePanel;
            OverlayWorker.ChangePosition = oldPreferences.WorkerChangePositionPanel;
            OverlayWorker.ChangeSize = oldPreferences.WorkerChangeSizePanel;

            #endregion

            #region PersonalApm

            OverlayPersonalApm.Height = oldPreferences.PersonalApmHeight;
            OverlayPersonalApm.Width = oldPreferences.PersonalApmWidth;
            OverlayPersonalApm.X = oldPreferences.PersonalApmPositionX;
            OverlayPersonalApm.Y = oldPreferences.PersonalApmPositionY;
            OverlayPersonalApm.ApmAlertLimit = oldPreferences.PersonalApmAlertLimit;
            OverlayPersonalApm.EnableAlert = oldPreferences.PersonalApmAlert;
            OverlayPersonalApm.PersonalApm = oldPreferences.PersonalApm;

            #endregion

            #region PersonalClock

            OverlayPersonalClock.Height = oldPreferences.PersonalClockHeight;
            OverlayPersonalClock.Width = oldPreferences.PersonalClockWidth;
            OverlayPersonalClock.X = oldPreferences.PersonalClockPositionX;
            OverlayPersonalClock.Y = oldPreferences.PersonalClockPositionY;
            OverlayPersonalClock.PersonalClock = oldPreferences.PersonalClock;

            #endregion
        }
    }
}
