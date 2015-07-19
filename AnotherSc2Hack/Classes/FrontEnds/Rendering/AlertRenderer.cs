using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using PredefinedTypes;
using Utilities.ExtensionMethods;
using Utilities.Logger;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    class AlertRenderer : BaseRenderer
    {
        private List<PlayerStore> _playerStores = new List<PlayerStore>(16); 
 
        
        public AlertRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
            : base(gInformation, pSettings, sc2Process)
        {
            gInformation.NewMatch += gInformation_NewMatch;
        }

        void gInformation_NewMatch(object sender, EventArgs e)
        {
            _playerStores.Clear();
        }

        private bool _bWorkerState = true;

        private void UnitWorker()
        {
           
                #region Exceptions

                if (GInformation == null)
                    return;

                if (GInformation.Gameinfo == null)
                    return;

                if (!GInformation.Gameinfo.IsIngame)
                    return;

                if (PSettings.PreferenceAll.OverlayAlert.UnitIds.Count <= 0)
                    return;

                if (GInformation.Player.Count <= 0)
                    return;

                if (GInformation.Unit.Count <= 0)
                    return;

                #endregion


                var players = new List<PlayerStore>(_playerStores);

                for (var index = 0; index < GInformation.Player.Count; index++)
                {
                    var player = GInformation.Player[index];
                    if (index >= players.Count)
                    {
                        players.Add(new PlayerStore(player.Name));
                        players[index].Color = player.Color;
                    }

                    #region Exceptions 
                    
                    if (player == Player.LocalPlayer)
                        continue;

                    if (player.Team == Player.LocalPlayer.Team)
                        continue;

                    if (player.Type != PlayerType.Ai &&
                        player.Type != PlayerType.Human)
                        continue;

                    #endregion

                    foreach (var unitId in PSettings.PreferenceAll.OverlayAlert.UnitIds)
                    {
                        DateTime initDate;

                        try
                        {

                            initDate = players[index].Units[unitId];

                            
                        }

                        catch (KeyNotFoundException ex)
                        {
                            //Console.WriteLine(unitId);
                            var unit = player.Units.Find(x => x.Id == unitId);
                            players[index].Units.Add(unitId, DateTime.Now);

                        }

                        catch (Exception ex)
                        {
                            //Console.WriteLine(ex);
                        }
                    }

                }

                _playerStores = players;

                


        }

        protected override void Draw(BufferedGraphics g)
        {          
            
            UnitWorker();

            Console.WriteLine(_playerStores.Count);

            foreach (var playerStore in _playerStores)
            {
                foreach (var playerUnit in playerStore.Units)
                {
                    if ((DateTime.Now - playerUnit.Value).Seconds >= PSettings.PreferenceAll.OverlayAlert.Time)
                        continue;

                    if (playerUnit.Key == UnitId.PuProbe)
                    {
                        g.Graphics.DrawImage(Properties.Resources.trans_pu_probe,
                            2,
                            2,
                            50,
                            50);

                        g.Graphics.DrawRectangle(new Pen(playerStore.Color, 2), 1, 1, 52, 52);
                    }

                }
            }
        }

        protected override void LoadSpecificData()
        {
            /* Nothing */
        }

        protected override void BaseRenderer_ResizeEnd(object sender, EventArgs e)
        {
            PSettings.PreferenceAll.OverlayAlert.Height = Height;
            PSettings.PreferenceAll.OverlayAlert.Width = Width;
            PSettings.PreferenceAll.OverlayAlert.X = Location.X;
            PSettings.PreferenceAll.OverlayAlert.Y = Location.Y;
        }

        protected override void AdjustPanelSize()
        {
            /* Nothing */
        }

        protected override void AdjustPanelPosition()
        {
            /* Nothing */
        }

        protected override void LoadPreferencesIntoControls()
        {
            Location = new Point(PSettings.PreferenceAll.OverlayAlert.X,
                                     PSettings.PreferenceAll.OverlayAlert.Y);
            Size = new Size(PSettings.PreferenceAll.OverlayAlert.Width,
                            PSettings.PreferenceAll.OverlayAlert.Height);
        }

        protected override void MouseUpTransferData()
        {
            PSettings.PreferenceAll.OverlayAlert.X = Location.X;
            PSettings.PreferenceAll.OverlayAlert.Y = Location.Y;
            PSettings.PreferenceAll.OverlayAlert.Width = Width;
            PSettings.PreferenceAll.OverlayAlert.Height = Height; 
        }

        protected override void MouseWheelTransferData(System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta.Equals(120))
            {
                Width += 1;
                Height += 1;
            }

            else if (e.Delta.Equals(-120))
            {
                Width -= 1;
                Height -= 1;
            }
        }
    }

    internal class PlayerStore
    {
        public Dictionary<UnitId, DateTime> Units { get; set; }
        public string PlayerName { get; set; }
        public Color Color { get; set; }

        public PlayerStore(string playerName)
        {
            Units = new Dictionary<UnitId, DateTime>();
            PlayerName = playerName;
            Color = Color.Red;
            
        }
    }
}
