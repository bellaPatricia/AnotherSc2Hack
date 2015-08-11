using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using Utilities.ExtensionMethods;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    internal class PersonalClockRenderer : BaseRenderer
    {
        public PersonalClockRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
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


            var iSingleHeight = Height;
            var fNewFontSize = (float) ((29.0/100)*iSingleHeight);

            var dtTimeStamp = DateTime.Now;

            var strTime = dtTimeStamp.ToLongTimeString();
            g.Graphics.DrawString(
                "Time: " + strTime,
                new Font("Century Gothic", fNewFontSize, FontStyle.Regular),
                Brushes.White,
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
            PSettings.PreferenceAll.OverlayPersonalClock.Height = (Height);
            PSettings.PreferenceAll.OverlayPersonalClock.Width = Width;
            PSettings.PreferenceAll.OverlayPersonalClock.X = Location.X;
            PSettings.PreferenceAll.OverlayPersonalClock.Y = Location.Y;
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
            Location = new Point(PSettings.PreferenceAll.OverlayPersonalClock.X,
                PSettings.PreferenceAll.OverlayPersonalClock.Y);
            Size = new Size(PSettings.PreferenceAll.OverlayPersonalClock.Width,
                PSettings.PreferenceAll.OverlayPersonalClock.Height);
        }

        protected override void MouseUpTransferData()
        {
            PSettings.PreferenceAll.OverlayPersonalClock.X = Location.X;
            PSettings.PreferenceAll.OverlayPersonalClock.Y = Location.Y;
            PSettings.PreferenceAll.OverlayPersonalClock.Width = Width;
            PSettings.PreferenceAll.OverlayPersonalClock.Height = Height;
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