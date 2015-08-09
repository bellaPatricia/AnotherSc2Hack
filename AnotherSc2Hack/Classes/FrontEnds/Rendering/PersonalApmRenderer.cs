using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using PredefinedTypes;
using Utilities.ExtensionMethods;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    internal class PersonalApmRenderer : BaseRenderer
    {
        public PersonalApmRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
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

            if (Player.LocalPlayer == null)
                return;

            var iSingleHeight = Height;
            var fNewFontSize = (float) ((29.0/100)*iSingleHeight);


            var clApmColor = Brushes.Green;
            if (PSettings.PreferenceAll.OverlayPersonalApm.EnableAlert)
            {
                if (Player.LocalPlayer.Apm <
                    PSettings.PreferenceAll.OverlayPersonalApm.ApmAlertLimit)
                    clApmColor = Brushes.Red;
            }

            g.Graphics.DrawString(
                "APM: " +
                Player.LocalPlayer.ApmAverage.ToString(
                    CultureInfo.InvariantCulture) + " [" +
                Player.LocalPlayer.Apm.ToString(
                    CultureInfo.InvariantCulture) + "]",
                new Font("Century Gothic", fNewFontSize, FontStyle.Regular),
                clApmColor,
                Brushes.Black, (float) ((13.67/100)*Width),
                (float) ((24.0/100)*iSingleHeight),
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

        protected override void MouseWheelTransferData(MouseEventArgs e)
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