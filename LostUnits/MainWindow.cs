using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PredefinedTypes = Predefined.PredefinedData;
using PluginInterface;

namespace LostUnits
{
    public partial class MainWindow : Form
    {
        public PredefinedTypes.Map Map { get; set; }
        public PredefinedTypes.Gameinformation Gameinfo { get; set; }
        public PredefinedTypes.PList Players { get; set; }
        public List<PredefinedTypes.Unit> Units { get; set; }
        public PredefinedTypes.LSelection Selection { get; set; }
        public List<PredefinedTypes.Groups> Groups { get; set; }

        private List<PlayerUnits> _lPlayers = new List<PlayerUnits>();
        private List<PlayerUnits> _lPlayersWithLostUnits = new List<PlayerUnits>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<PlayerUnits> ResetPlayerstruct()
        {
            if (Players == null ||
                Players.Count <= 0 ||
                Units == null ||
                Units.Count <= 0)
            {
                return new List<PlayerUnits>();   
            }

            List<PlayerUnits> lPlayers = new List<PlayerUnits>();

            #region convert old Playerdata to new Playerdata

            for (var i = 0; i < Players.Count; i++)
            {
                var tmpPlayer = new PlayerUnits();
                tmpPlayer.AccountId = Players[i].AccountId;
                tmpPlayer.Apm = Players[i].Apm;
                tmpPlayer.ApmAverage = Players[i].ApmAverage;
                tmpPlayer.ArmySupply = Players[i].ArmySupply;
                tmpPlayer.CameraAngle = Players[i].CameraAngle;
                tmpPlayer.CameraDistance = Players[i].CameraDistance;
                tmpPlayer.CameraPositionX = Players[i].CameraPositionX;
                tmpPlayer.CameraPositionY = Players[i].CameraPositionY;
                tmpPlayer.CameraRotation = Players[i].CameraRotation;
                tmpPlayer.ClanTag = Players[i].ClanTag;
                tmpPlayer.Color = Players[i].Color;
                tmpPlayer.CurrentBuildings = Players[i].CurrentBuildings;
                tmpPlayer.Difficulty = Players[i].Difficulty;
                tmpPlayer.Epm = Players[i].Epm;
                tmpPlayer.EpmAverage = Players[i].EpmAverage;
                tmpPlayer.Gas = Players[i].Gas;
                tmpPlayer.GasArmy = Players[i].GasArmy;
                tmpPlayer.GasIncome = Players[i].GasIncome;
                tmpPlayer.IsLocalplayer = Players[i].IsLocalplayer;
                tmpPlayer.Localplayer = Players[i].Localplayer;
                tmpPlayer.Minerals = Players[i].Minerals;
                tmpPlayer.MineralsArmy = Players[i].MineralsArmy;
                tmpPlayer.MineralsIncome = Players[i].MineralsIncome;
                tmpPlayer.Name = Players[i].Name;
                tmpPlayer.NameLength = Players[i].NameLength;
                tmpPlayer.PlayerRace = Players[i].PlayerRace;
                tmpPlayer.Status = Players[i].Status;
                tmpPlayer.SupplyMax = Players[i].SupplyMax;
                tmpPlayer.SupplyMaxRaw = Players[i].SupplyMaxRaw;
                tmpPlayer.SupplyMin = Players[i].SupplyMin;
                tmpPlayer.SupplyMinRaw = Players[i].SupplyMinRaw;
                tmpPlayer.Team = Players[i].Team;
                tmpPlayer.Type = Players[i].Type;
                tmpPlayer.ValidSize = Players[i].ValidSize;
                tmpPlayer.Worker = Players[i].Worker;
                tmpPlayer.Units = new List<PredefinedTypes.Unit>();

                lPlayers.Add(tmpPlayer);
            }

            #endregion

            #region Add Units to the Playerdata

            
                foreach (var tmpUnit in Units)
                {
                    if (tmpUnit.Owner >= 0 &&
                        tmpUnit.Owner < 16)
                    {
                        lPlayers[tmpUnit.Owner].Units.Add(tmpUnit);
                    }
                }
            

            #endregion

            return lPlayers;
        }

        

        private void tmrMainTimer_Tick(object sender, EventArgs e)
        {
            _lPlayers = ResetPlayerstruct();

            
        }
    }

    public class PlayerUnits : PredefinedTypes.PlayerStruct
    {
        public List<PredefinedTypes.Unit> Units { get; set; }
    }

    public class AnotherSc2HackPlugin : IPlugins
    {

        private MainWindow _frmExternal = null;

        public string GetPluginDescription()
        {
            return "Lists all lost units";
        }

        public string GetPluginName()
        {
            return "LostUnits";
        }

        public bool GetRequiresGameinfo()
        {
            return true;
        }

        public bool GetRequiresGroups()
        {
            return false;
        }

        public bool GetRequiresMap()
        {
            return false;
        }

        public bool GetRequiresPlayer()
        {
            return true;
        }

        public bool GetRequiresSelection()
        {
            return false;
        }

        public bool GetRequiresUnit()
        {
            return true;
        }

        public void SetGameinfo(PredefinedTypes.Gameinformation gameinfo)
        {
            _frmExternal.Gameinfo = gameinfo;
        }

        public void SetGroups(List<PredefinedTypes.Groups> groups)
        {
            _frmExternal.Groups = groups;
        }

        public void SetMap(PredefinedTypes.Map map)
        {
            _frmExternal.Map = map;
        }

        public void SetPlayers(PredefinedTypes.PList players)
        {
            _frmExternal.Players = players;
        }

        public void SetSelection(PredefinedTypes.LSelection selection)
        {
            _frmExternal.Selection = selection;
        }

        public void SetUnits(List<PredefinedTypes.Unit> units)
        {
            _frmExternal.Units = units;
        }

        public void StartPlugin()
        {
            if (_frmExternal == null)
                _frmExternal = new MainWindow();


            if (_frmExternal.Created)
                _frmExternal.Close();

            else
            {

                _frmExternal = new MainWindow();
                _frmExternal.Show();
            }
        }

        public void StopPlugin()
        {
            if (_frmExternal != null)
                _frmExternal.Close();
        }
    }
}
