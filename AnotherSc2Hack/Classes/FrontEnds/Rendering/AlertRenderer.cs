using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using Utilities.ExtensionMethods;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    class AlertRenderer : BaseRenderer
    {
        public AlertRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
            : base(gInformation, pSettings, sc2Process)
        {

        }

        protected override void Draw(BufferedGraphics g)
        {
            if (!GInformation.Gameinfo.IsIngame)
                return;

            var iValidPlayerCount = GInformation.Gameinfo.ValidPlayerCount;

            if (iValidPlayerCount == 0)
                return;

            if (GInformation.Player.Count <= 0)
                return;

            if (PredefinedTypes.Player.LocalPlayer == null)
                return;

            var iSingleHeight = Height;
            var fNewFontSize = (float)((29.0 / 100) * iSingleHeight);


           

            BackgroundImage = Properties.Resources.trans_tu_banshee;
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
