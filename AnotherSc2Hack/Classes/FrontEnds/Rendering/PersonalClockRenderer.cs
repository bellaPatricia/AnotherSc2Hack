using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    class PersonalClockRenderer : BaseRenderer
    {
        public PersonalClockRenderer(GameInfo gInformation, Preferences pSettings, Process sc2Process)
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
            var fNewFontSize = (float)((29.0 / 100) * iSingleHeight);

            var dtTimeStamp = DateTime.Now;
            var strTime = dtTimeStamp.TimeOfDay.ToString().Substring(0, 8);

            Drawing.DrawString(g.Graphics,
               "Time: " + strTime,
               new Font("Century Gothic", fNewFontSize, FontStyle.Regular),
               Brushes.White,
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
            PSettings.PersonalClockHeight = (Height);
            PSettings.PersonalClockWidth = Width;
            PSettings.PersonalClockPositionX = Location.X;
            PSettings.PersonalClockPositionY = Location.Y;
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
            Location = new Point(PSettings.PersonalClockPositionX,
                                     PSettings.PersonalClockPositionY);
            Size = new Size(PSettings.PersonalClockWidth,
                            PSettings.PersonalClockHeight);
        }

        protected override void MouseUpTransferData()
        {
            PSettings.PersonalClockPositionX = Location.X;
            PSettings.PersonalClockPositionY = Location.Y;
            PSettings.PersonalClockWidth = Width;
            PSettings.PersonalClockHeight = Height; 
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
