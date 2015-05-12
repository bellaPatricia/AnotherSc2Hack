using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using AnotherSc2Hack.Classes.ExtensionMethods;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    class PersonalApmRenderer : BaseRenderer
    {
        public PersonalApmRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
            : base(gInformation, pSettings, sc2Process)
        {

        }

        protected override void Draw(System.Drawing.BufferedGraphics g)
        {
            GInformation.CAccessPlayers = true;

            if (!GInformation.Gameinfo.IsIngame)
                return;

            var iValidPlayerCount = GInformation.Gameinfo.ValidPlayerCount;

            if (iValidPlayerCount == 0)
                return;

            if (GInformation.Player.Count <= 0)
                return;

            if (GInformation.Player[0].Localplayer == 16)
                return;

            var iSingleHeight = Height;
            var fNewFontSize = (float)((29.0 / 100) * iSingleHeight);


            var clApmColor = Brushes.Green;
            if (PSettings.PreferenceAll.OverlayPersonalApm.EnableAlert)
            {
                if (GInformation.Player[GInformation.Player[0].Localplayer].Apm <
                    PSettings.PreferenceAll.OverlayPersonalApm.ApmAlertLimit)
                    clApmColor = Brushes.Red;
            }

            g.Graphics.DrawString(
                "APM: " +
                GInformation.Player[GInformation.Player[0].Localplayer].ApmAverage.ToString(
                    CultureInfo.InvariantCulture) + " [" +
                GInformation.Player[GInformation.Player[0].Localplayer].Apm.ToString(
                    CultureInfo.InvariantCulture) + "]",
                new Font("Century Gothic", fNewFontSize, FontStyle.Regular),
                clApmColor,
                Brushes.Black, (float)((13.67 / 100) * Width),
                (float)((24.0 / 100) * iSingleHeight),
                1f, 1f, true);
        }

        protected override void LoadSpecificData()
        {
            /* Nothing */
        }

        protected override void BaseRenderer_ResizeEnd(object sender, EventArgs e)
        {
            PSettings.PreferenceAll.OverlayPersonalApm.Height = (Height);
            PSettings.PreferenceAll.OverlayPersonalApm.Width = Width;
            PSettings.PreferenceAll.OverlayPersonalApm.X = Location.X;
            PSettings.PreferenceAll.OverlayPersonalApm.Y = Location.Y;
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
            Location = new Point(PSettings.PreferenceAll.OverlayPersonalApm.X,
                                     PSettings.PreferenceAll.OverlayPersonalApm.Y);
            Size = new Size(PSettings.PreferenceAll.OverlayPersonalApm.Width,
                            PSettings.PreferenceAll.OverlayPersonalApm.Height);
        }

        protected override void MouseUpTransferData()
        {
            PSettings.PreferenceAll.OverlayPersonalApm.X = Location.X;
            PSettings.PreferenceAll.OverlayPersonalApm.Y = Location.Y;
            PSettings.PreferenceAll.OverlayPersonalApm.Width = Width;
            PSettings.PreferenceAll.OverlayPersonalApm.Height = Height; 
        }

        protected override void MouseWheelTransferData(System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta.Equals(120))
            {
                Width += 3;
                Height += 1;
            }

            else if (e.Delta.Equals(-120))
            {
                Width -= 3;
                Height -= 1;
            }
        }
    }
}
