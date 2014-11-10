using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using PredefinedTypes = Predefined.PredefinedData;
using PluginInterface;

namespace PluginWpf
{

    /* ENTIRE programlogic in here! */
    public partial class MainWindow : Window
    {
        /* Some info here: this was only a short attempt of showing the structs and their data.
         * This is in no way a plugin for the enduser as no exceptions are handled/ catched! 
         * Only use this as an example! */


        private readonly DispatcherTimer _tMainTimer = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();

            /* Timer Data */
            _tMainTimer.Interval = new TimeSpan(0, 0, 0, 0, 16);
            _tMainTimer.Tick += _tMainTimer_Tick;
            _tMainTimer.IsEnabled = true;
        }

        void _tMainTimer_Tick(object sender, EventArgs e)
        {

            if (LstPlayer.Items.Count <= 0)
                SetBasePlayerData();

            if (LstUnit.Items.Count <= 0)
                SetBaseUnitData();

            if (LstGameinfo.Items.Count <= 0)
                SetBaseGameData();

            if (LstMap.Items.Count <= 0)
                SetBaseMapData();

            if (LstSelection.Items.Count <= 0)
                SetBaseSelectionData();

        }

        private void AddSubUnitData(Int32 unitIndex)
        {
            /* Clear everything */
            LstUnit.Items.Clear();

            AddUnitData(0, unitIndex + 1, Units, LstUnit);

            var unit = Units[unitIndex];

            LstUnit.Items.Add("\t \\ Name:             " + unit.Name);
            LstUnit.Items.Add("\t | Id:               0x" + ((int)unit.Id).ToString("X4"));
            LstUnit.Items.Add("\t | Id:               " + ((int)unit.Id));
            LstUnit.Items.Add("\t | Model Pointer:    0x" + ((int)unit.ModelPointer).ToString("X8"));
            LstUnit.Items.Add("\t | Energy            " + unit.Energy);
            LstUnit.Items.Add("\t | Health            " + (unit.MaximumHealth - unit.DamageTaken) / 4096 + "/" + unit.MaximumHealth / 4096);
            LstUnit.Items.Add("\t | Shield            " + (unit.MaximumShield - unit.ShieldDamageTaken) / 4096 + "/" + unit.MaximumShield / 4096);
            LstUnit.Items.Add("\t | Is Alive:         " + unit.IsAlive);
            LstUnit.Items.Add("\t | Position X:       " + unit.PositionX);
            LstUnit.Items.Add("\t | Position Y:       " + unit.PositionY);
            LstUnit.Items.Add("\t | Dest. Position X: " + unit.DestinationPositionX);
            LstUnit.Items.Add("\t | Dest. Position Y: " + unit.DestinationPositionY);

            
            

            AddUnitData(unitIndex + 1,Units.Count, Units, LstUnit);
        }

        private void AddSubSelectionData(Int32 selectionIndex)
        {
            LstSelection.Items.Clear();
            AddSelectionData(0, selectionIndex + 1, Selection, LstSelection);

            var unit = Selection[selectionIndex].Unit;

            LstSelection.Items.Add("\t \\ Name:             " + unit.Name);
            LstSelection.Items.Add("\t | Id:               0x" + ((int)unit.Id).ToString("X4"));
            LstSelection.Items.Add("\t | Id:               " + ((int)unit.Id));
            LstSelection.Items.Add("\t | Model Pointer:    0x" + ((int)unit.ModelPointer).ToString("X8"));
            LstSelection.Items.Add("\t | Energy            " + unit.Energy);
            LstSelection.Items.Add("\t | Health            " + (unit.MaximumHealth - unit.DamageTaken) / 4096 + "/" + unit.MaximumHealth / 4096);
            LstSelection.Items.Add("\t | Shield            " + (unit.MaximumShield - unit.ShieldDamageTaken) / 4096 + "/" + unit.MaximumShield / 4096);
            LstSelection.Items.Add("\t | Is Alive:         " + unit.IsAlive);
            LstSelection.Items.Add("\t | Position X:       " + unit.PositionX);
            LstSelection.Items.Add("\t | Position Y:       " + unit.PositionY);
            LstSelection.Items.Add("\t | Dest. Position X: " + unit.DestinationPositionX);
            LstSelection.Items.Add("\t | Dest. Position Y: " + unit.DestinationPositionY);

            AddSelectionData(selectionIndex + 1, Selection.Count, Selection, LstSelection);
        }

        private void AddSubPlayerData(Int32 playerIndex)
        {
            /* Clear everything */
            LstPlayer.Items.Clear();

            /* Add all players till the *real* player was selected */
            AddPlayerData(0, playerIndex + 1, Players, LstPlayer);

            //for (var i = 0; i <= playerIndex; i++)
            //{
            //    var p = Players[i];
            //    if (p.NameLength <= 3 ||
            //        p.Type.Equals(PredefinedTypes.PlayerType.Hostile)) continue;

            //    var cl = Color.FromArgb(p.Color.A, p.Color.R, p.Color.G, p.Color.B);

            //    LstPlayer.Items.Add(new ListBoxItem2("[" + i + "]" + p.Name, Brushes.Black, new SolidColorBrush(cl)));
            //}

            
           // var color = Color.FromArgb(Players[playerIndex].Color.A, Players[playerIndex].Color.R, Players[playerIndex].Color.G, Players[playerIndex].Color.B);
            //var listItem = new ListBoxItem2("Stuff", Brushes.Black, new SolidColorBrush(color));

            /* Add all items we want */
            var player = Players[playerIndex];
           

            LstPlayer.Items.Add("\t \\ Name:              " + player.Name);
            LstPlayer.Items.Add("\t | NameLenght:        " + player.NameLength);
            LstPlayer.Items.Add("\t | Race:              " + player.PlayerRace);
            LstPlayer.Items.Add("\t | Color:             " + player.Color);
            LstPlayer.Items.Add("\t | Team:              " + player.Team);
            LstPlayer.Items.Add("\t | Minerals:          " + player.Minerals);
            LstPlayer.Items.Add("\t | Vespine:           " + player.Gas);
            LstPlayer.Items.Add("\t | Supply:            " + player.SupplyMin + "/" + player.SupplyMax);
            LstPlayer.Items.Add("\t | Minerals Income:   " + player.MineralsIncome);
            LstPlayer.Items.Add("\t | Vespine Income:    " + player.GasIncome);
            LstPlayer.Items.Add("\t | Minerals Army:     " + player.MineralsArmy);
            LstPlayer.Items.Add("\t | Vespine Army:      " + player.GasArmy);
            LstPlayer.Items.Add("\t | Worker Count:      " + player.Worker);
            LstPlayer.Items.Add("\t | Type:              " + player.Type);
            LstPlayer.Items.Add("\t | Difficulty:        " + player.Difficulty);
            LstPlayer.Items.Add("\t | Epm Current:       " + player.Epm);
            LstPlayer.Items.Add("\t | Epm Average:       " + player.EpmAverage);
            LstPlayer.Items.Add("\t | Apm Current:       " + player.Apm);
            LstPlayer.Items.Add("\t | Apm Average:       " + player.ApmAverage);
            LstPlayer.Items.Add("\t | Camera Position X: " + player.CameraPositionX);
            LstPlayer.Items.Add("\t | Camera Position Y: " + player.CameraPositionY);
            LstPlayer.Items.Add("\t | Camera Distance:   " + player.CameraDistance);
            LstPlayer.Items.Add("\t | Camera Angle:      " + player.CameraAngle);
            LstPlayer.Items.Add("\t | Camera Rotation:   " + player.CameraRotation);
            var tmpClanTag = player.ClanTag.Contains('\0')
                ? player.ClanTag.Remove(player.ClanTag.IndexOf('\0'))
                : player.ClanTag;
            LstPlayer.Items.Add("\t | Clantag:           " + tmpClanTag);
            var tmpAccountId = player.AccountId.Contains('\0')
                ? player.AccountId.Remove(player.AccountId.IndexOf('\0'))
                : player.AccountId;
            LstPlayer.Items.Add("\t | Account Id:        " + tmpAccountId);
            LstPlayer.Items.Add("\t | Army Supply:       " + player.ArmySupply);
            LstPlayer.Items.Add("\t | Localplayer Index: " + player.Localplayer);
            
            

            /* Add the other players */
            AddPlayerData(playerIndex + 1, Players.Count, Players, LstPlayer);

            //for (var i = playerIndex + 1; i < Players.Count; i++)
            //{
            //    var p = Players[i];
            //    if (p.NameLength <= 3 ||
            //        p.Type.Equals(PredefinedTypes.PlayerType.Hostile)) continue;

            //    var cl = Color.FromArgb(p.Color.A, p.Color.R, p.Color.G, p.Color.B);

            //    LstPlayer.Items.Add(new ListBoxItem2("[" + i + "]" + p.Name, Brushes.Black, new SolidColorBrush(cl)));
            //}
        }

        private void SetBaseMapData()
        {
            if (Map.PlayableHeight == 0 &&
                Map.PlayableWidth == 0)
                return;

            LstMap.Items.Add("\\ Right:           " + Map.Right);
            LstMap.Items.Add("| Left:            " + Map.Left);
            LstMap.Items.Add("| Top:             " + Map.Top);
            LstMap.Items.Add("| Bottom:          " + Map.Bottom);
            LstMap.Items.Add("| Playable Height: " + Map.PlayableHeight);
            LstMap.Items.Add("| Playable Width:  " + Map.PlayableWidth);
        }

        private void SetBaseGroupData()
        {
            if (Groups == null ||
                Groups.Count <= 0)
                return;

        }

        private void SetBasePlayerData()
        {
            if (Players == null ||
                Players.Count <= 0)
                return;

            AddPlayerData(0, Players.Count, Players, LstPlayer);
        }

        private void SetBaseSelectionData()
        {
            if (Selection == null ||
                Selection.Count <= 0)
                return;

            AddSelectionData(0, Selection.Count, Selection, LstSelection);
            //AddUnitData(0, Selection.Count, Selection[0].un)
        }

        private void SetBaseGameData()
        {
            if (Gameinfo.Timer <= 0)
                return;

            LstGameinfo.Items.Add("\\ Timer:        " + Gameinfo.Timer);
            var strChatInput = Gameinfo.ChatInput;
            if (Gameinfo.ChatInput.Contains("\0"))
                strChatInput = strChatInput.Substring(0, strChatInput.IndexOf("\0", StringComparison.Ordinal));

            LstGameinfo.Items.Add("| Chat Input:   " + strChatInput);
            LstGameinfo.Items.Add("| Chat Open:    " + Gameinfo.ChatIsOpen);
            LstGameinfo.Items.Add("| Fps:          " + Gameinfo.Fps);
            LstGameinfo.Items.Add("| IsIngame:     " + Gameinfo.IsIngame);
            LstGameinfo.Items.Add("| Is Teamcolor: " + Gameinfo.IsTeamcolor);
            LstGameinfo.Items.Add("| Is Paused:    " + Gameinfo.Pause);
            LstGameinfo.Items.Add("| Gamespeed:    " + Gameinfo.Speed);
            LstGameinfo.Items.Add("| Windowstyle:  " + Gameinfo.Style);
            LstGameinfo.Items.Add("| Matchtype:    " + Gameinfo.Type);

        }

        private void AddPlayerData(int startIndex, int endIndex, PredefinedTypes.PList list, ListBox lstBx)
        {
            for (var index = startIndex; index < endIndex; index++)
            {
                var p = list[index];
                if (p.NameLength <= 3 ||
                    p.Type.Equals(PredefinedTypes.PlayerType.Hostile)) continue;

                var cl = Color.FromArgb(p.Color.A, p.Color.R, p.Color.G, p.Color.B);

                var iPlayerCountLenght = Players.Count.ToString(CultureInfo.InvariantCulture).Length;
                var strResult = "[" + index + "]";

                for (var i = 0; i <= iPlayerCountLenght - index.ToString(CultureInfo.InvariantCulture).Length; i++)
                    strResult += " ";

                strResult += p.Name;

                lstBx.Items.Add(new ListBoxItem2(strResult, Brushes.Black, new SolidColorBrush(cl)));
            }
        }

        private void AddGroupData(int startIndex, int endIndex, List<PredefinedTypes.Groups> list, ListBox lstBx)
        {
            var lstResults = new List<String>();
            for (var index = startIndex; index < endIndex; index++)
            {
                var strResult = "[" + index + "] Group " + (index + 1);// + " - Units: " + list[index].Units.Count;
                lstResults.Add(strResult);
            }

            var lstTmpResult = new List<String>();
            foreach (var s in lstResults)
                lstTmpResult.Add(s);

            lstTmpResult.Sort((x, y) => x.Length.CompareTo(y.Length));

            var iMaxLenght = lstTmpResult[lstTmpResult.Count - 1].Length;

            for (var j = 0; j < lstTmpResult.Count; j++)
            {
                for (var i = 0; i < iMaxLenght - lstResults[j].Length; i++)
                {
                    lstResults[j] += " ";
                }

                lstResults[j] += " - Units: " + list[j].Units.Count;
                lstBx.Items.Add(lstResults[j]);
            }

        }

        private void AddSelectionData(int startIndex, int endIndex, PredefinedTypes.LSelection list, ListBox lstBx)
        {
            if (list == null ||
                list.Count <= 0)
                return;

            var lUnitNames = new List<String>();

            for (var index = startIndex; index < endIndex; index++)
            {
                var u = list[index].Unit;

                //var cl = Color.FromArgb(p.Color.A, p.Color.R, p.Color.G, p.Color.B);

                #region Add ' ' to line the unitnames up [between [INDEX] UNITNAME]

                var iUnitCountLenght = list.Count.ToString(CultureInfo.InvariantCulture).Length;
                var strResult = "[" + index + "]";

                for (var i = 0; i <= iUnitCountLenght - index.ToString(CultureInfo.InvariantCulture).Length; i++)
                    strResult += " ";

                strResult += u.Name;

                #endregion

                lUnitNames.Add(strResult);



                //LstUnit.Items.Add(new ListBoxItem2(strResult, Brushes.Black, new SolidColorBrush(cl)));
            }

            var tmpUnitNames = new List<String>();
            for (var i = 0; i < list.Count; i++)
                tmpUnitNames.Add(list[i].Unit.Name);

            /* Sort the string- lenght - short to long */
            tmpUnitNames.Sort((x, y) => (x.Length.CompareTo(y.Length)));

            var iMinLenght = tmpUnitNames[0].Length;
            var iMaxLenght = tmpUnitNames[tmpUnitNames.Count - 1].Length + 2 + list.Count.ToString(CultureInfo.InvariantCulture).Length;

            for (int index = 0; index < lUnitNames.Count; index++)
            {
                var s = lUnitNames[index];

                for (var i = 0; i <= iMaxLenght - s.Length; i++)
                {
                    lUnitNames[index] += " ";
                }

                lUnitNames[index] += " Owner: " + Players[list[index + startIndex].Unit.Owner].Name;
            }


            foreach (var s in lUnitNames)
                lstBx.Items.Add(s);
        }

        private void AddUnitData(int startIndex, int endIndex, List<PredefinedTypes.Unit> list, ListBox lstBx)
        {
            if (list == null ||
                list.Count <= 0)
                return;

            var lUnitNames = new List<String>();

            for (var index = startIndex; index < endIndex; index++)
            {
                var u = list[index];

                //var cl = Color.FromArgb(p.Color.A, p.Color.R, p.Color.G, p.Color.B);

                #region Add ' ' to line the unitnames up [between [INDEX] UNITNAME]

                var iUnitCountLenght = Units.Count.ToString(CultureInfo.InvariantCulture).Length;
                var strResult = "[" + index + "]";

                for (var i = 0; i <= iUnitCountLenght - index.ToString(CultureInfo.InvariantCulture).Length; i++)
                    strResult += " ";

                strResult += u.Name;

                #endregion

                lUnitNames.Add(strResult);



                //LstUnit.Items.Add(new ListBoxItem2(strResult, Brushes.Black, new SolidColorBrush(cl)));
            }

            var tmpUnitNames = new List<String>();
            for (var i = 0; i < list.Count; i++)
                tmpUnitNames.Add(list[i].Name);

            /* Sort the string- lenght - short to long */
            tmpUnitNames.Sort((x, y) => (x.Length.CompareTo(y.Length)));

            var iMinLenght = tmpUnitNames[0].Length;
            var iMaxLenght = tmpUnitNames[tmpUnitNames.Count - 1].Length + 2 + list.Count.ToString(CultureInfo.InvariantCulture).Length;

            for (int index = 0; index < lUnitNames.Count; index++)
            {
                var s = lUnitNames[index];

                for (var i = 0; i <= iMaxLenght - s.Length; i++)
                {
                    lUnitNames[index] += " ";
                }

                lUnitNames[index] += " Owner: " + Players[Units[index + startIndex].Owner].Name;
            }


            foreach (var s in lUnitNames)
                lstBx.Items.Add(s);
        }

        private void SetBaseUnitData()
        {
            

            if (Units == null ||
                Units.Count <= 0)
                return;

            AddUnitData(0, Units.Count, Units, LstUnit);

            //var lUnitNames = new List<String>();

            //for (var index = 0; index < Units.Count; index++)
            //{
            //    var u = Units[index];
            //    var p = Players[u.Owner];

            //    //var cl = Color.FromArgb(p.Color.A, p.Color.R, p.Color.G, p.Color.B);

            //    #region Add ' ' to line the unitnames up [between [INDEX] UNITNAME]

            //    var iUnitCountLenght = Units.Count.ToString(CultureInfo.InvariantCulture).Length;
            //    var strResult = "[" + index + "]";

            //    for (var i = 0; i <= iUnitCountLenght - index.ToString(CultureInfo.InvariantCulture).Length; i++)
            //        strResult += " ";

            //    strResult += u.Name;

            //    #endregion

            //    lUnitNames.Add(strResult);



            //    //LstUnit.Items.Add(new ListBoxItem2(strResult, Brushes.Black, new SolidColorBrush(cl)));
            //}

            //var tmpUnitNames = new List<String>();
            //for (var i = 0; i < lUnitNames.Count; i++)
            //    tmpUnitNames.Add(lUnitNames[i]);

            ///* Sort the string- lenght - short to long */
            //tmpUnitNames.Sort((x, y) => (x.Length.CompareTo(y.Length)));

            //var iMinLenght = tmpUnitNames[0].Length;
            //var iMaxLenght = tmpUnitNames[tmpUnitNames.Count - 1].Length;

            //for (int index = 0; index < lUnitNames.Count; index++)
            //{
            //    var s = lUnitNames[index];

            //    for (var i = 0; i <= iMaxLenght - s.Length; i++)
            //    {
            //        lUnitNames[index] += " ";
            //    }

            //    lUnitNames[index] += "Owner: " + Players[Units[index].Owner].Name;
            //}


            //foreach (var s in lUnitNames)
            //    LstUnit.Items.Add(s);
        }

        private void RefreshPlayerData()
        {
            
        }


        private void LstPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstPlayer.Items.Count <= 0)
                return;

            if (Players == null ||
                Players.Count <= 0)
                return;

            var bValidItem = false;
            var iIndex = 0;
            for (int index = 0; index < Players.Count; index++)
            {
                var p = Players[index];
                var tmp = LstPlayer.SelectedItem.ToString();
                if (tmp.Contains(p.Name) && p.NameLength > 3)
                {
                    bValidItem = true;
                    iIndex = index;
                    break;
                }
            }

            if (bValidItem)
                AddSubPlayerData(iIndex);
        }

        private void LstUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstUnit.Items.Count <= 0)
                return;

            if (Units == null ||
                Units.Count <= 0)
                return;

            var bValidItem = false;
            var iIndex = 0;
            for (var index = 0; index < Units.Count; index++)
            {
                var tmp = LstUnit.SelectedItem.ToString();
                if (tmp.Contains("[" + index + "]"))
                {
                    bValidItem = true;
                    iIndex = index;
                    break;
                }
            }

            if (bValidItem)
                AddSubUnitData(iIndex);
        }


        public PredefinedTypes.Map Map { get; set; }
        public PredefinedTypes.Gameinformation Gameinfo { get; set; }
        public PredefinedTypes.PList Players { get; set; }
        public List<PredefinedTypes.Unit> Units { get; set; }
        public PredefinedTypes.LSelection Selection { get; set; }
        public List<PredefinedTypes.Groups> Groups { get; set; }

        private void LstSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LstSelection.Items.Count <= 0)
                return;

            if (Selection == null ||
                Selection.Count <= 0)
                return;

            var bValidItem = false;
            var iIndex = 0;
            for (var index = 0; index < Selection.Count; index++)
            {
                var tmp = LstSelection.SelectedItem.ToString();
                if (tmp.Contains("[" + index + "]"))
                {
                    bValidItem = true;
                    iIndex = index;
                    break;
                }
            }

            if (bValidItem)
                AddSubSelectionData(iIndex);
        }

       
    }

    /* Custom listbox- control, not needed */
    public class ListBoxItem2 : ListBoxItem
    {
        public ListBoxItem2()
        {
            
        }

        public ListBoxItem2(String content, Brush foreground, Brush background)
        {
            Content = content;
            Foreground = foreground;
            Background = background;
        }
    }

    /* Actual class which is needed to identify compatible plugins! */
    public class AnotherSc2HackPlugin : IPlugins
    {
        /* Reference to the Mainwindow - so you can launch it and refresh data */
        private MainWindow _mMainForm = null;

        /* Base describption of the plugin */
        public string GetPluginDescription()
        {
            return "This is an example of the usage for the WPF Plugin";
        }

        /* Name of the plugin */
        public string GetPluginName()
        {
            return "Sample WPF Plugin";
        }

        /* get the gameinfo */
        public void SetGameinfo(PredefinedTypes.Gameinformation gameinfo)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Gameinfo = gameinfo;
            }
        }

        /* get the groups */
        public void SetGroups(List<PredefinedTypes.Groups> groups)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Groups = groups;
            }
        }

        /* get the map */
        public void SetMap(PredefinedTypes.Map map)
        {
            if (_mMainForm != null &&
                 _mMainForm.IsLoaded)
            {
                _mMainForm.Map = map;
            }
        }

        /* get the players */
        public void SetPlayers(PredefinedTypes.PList players)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Players  = players;
            }
        }

        /* get the selections */
        public void SetSelection(PredefinedTypes.LSelection selection)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Selection = selection;
            }
        }

        /* get the units */
        public void SetUnits(List<PredefinedTypes.Unit> units)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Units = units;
            }
        }

        /* Starting the plugin - get's called when the checkbox in the mainprogramm is checked */
        public void StartPlugin()
        {

            if (_mMainForm == null)
                _mMainForm = new MainWindow();


            if (_mMainForm.IsLoaded)
                _mMainForm.Close();

            else
            {

                _mMainForm = new MainWindow();
                _mMainForm.Show();
            }

            
         
            
        }

        /* Stops the plugin/ your logic in the plugin */
        public void StopPlugin()
        {
            if (_mMainForm != null)
                _mMainForm.Close();
        }




        /* Tells the Hostapplication what data is needed.
         ONLY SELECT WHAT YOU NEED TO IMPROVE PERFORMANCE! */
        public bool GetRequiresGameinfo()
        {
            return true;
        }

        /* Tells the Hostapplication what data is needed.
         ONLY SELECT WHAT YOU NEED TO IMPROVE PERFORMANCE! */
        public bool GetRequiresGroups()
        {
            return true;
        }

        /* Tells the Hostapplication what data is needed.
         ONLY SELECT WHAT YOU NEED TO IMPROVE PERFORMANCE! */
        public bool GetRequiresMap()
        {
            return true;
        }

        /* Tells the Hostapplication what data is needed.
         ONLY SELECT WHAT YOU NEED TO IMPROVE PERFORMANCE! */
        public bool GetRequiresPlayer()
        {
            return true;
        }

        /* Tells the Hostapplication what data is needed.
         ONLY SELECT WHAT YOU NEED TO IMPROVE PERFORMANCE! */
        public bool GetRequiresSelection()
        {
            return true;
        }

        /* Tells the Hostapplication what data is needed.
         ONLY SELECT WHAT YOU NEED TO IMPROVE PERFORMANCE! */
        public bool GetRequiresUnit()
        {
            return true;
        }
    }
}
