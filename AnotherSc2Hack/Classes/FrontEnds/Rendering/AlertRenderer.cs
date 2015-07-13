using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using PredefinedTypes;
using Utilities.ExtensionMethods;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    class AlertRenderer : BaseRenderer
    {
        private List<List<Unit>> _lListedPlayerUnits = new List<List<Unit>>(); 
 
        public AlertRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
            : base(gInformation, pSettings, sc2Process)
        {
            gInformation.NewMatch += gInformation_NewMatch;
        }

        void gInformation_NewMatch(object sender, EventArgs e)
        {
            _lListedPlayerUnits.Clear();
        }

        protected override void Draw(BufferedGraphics g)
        {
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

            for (int index = 0; index < GInformation.Player.Count; index++)
            {
                if (_lListedPlayerUnits.Count <= index)
                    _lListedPlayerUnits.Add(new List<Unit>());

                var player = GInformation.Player[index];
                if (player == Player.LocalPlayer)
                    continue;

                if (player.Team == Player.LocalPlayer.Team)
                    continue;

                if (player.Type != PlayerType.Ai &&
                    player.Type != PlayerType.Human)
                    continue;

                foreach (var unitId in PSettings.PreferenceAll.OverlayAlert.UnitIds)
                {
                    if (_lListedPlayerUnits[index].FindIndex(x => x.Id == unitId) > -1)
                        continue;
                    


                    var unit = player.Units.Find(x => x.Id == (UnitId)unitId);
                    if (unit == null)
                        continue;

                    g.Graphics.DrawImage(Properties.Resources.trans_tu_banshee, 10, 10, ClientRectangle.Width - 20, ClientRectangle.Height - 20);
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
}
