using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    class PersonalApmRenderer : BaseRenderer
    {
        public PersonalApmRenderer(MainHandler.MainHandler hnd) : base(hnd)
        {

        }

        protected override void Draw(System.Drawing.BufferedGraphics g)
        {
            if (!HMainHandler.GInformation.Gameinfo.IsIngame)
                return;

            var iValidPlayerCount = HMainHandler.GInformation.Gameinfo.ValidPlayerCount;

            if (iValidPlayerCount == 0)
                return;

            if (HMainHandler.GInformation.Player.Count <= 0)
                return;

            if (HMainHandler.GInformation.Player[0].Localplayer == 16)
                return;

            var iSingleHeight = Height;
            var fNewFontSize = (float)((29.0 / 100) * iSingleHeight);


            var clApmColor = Brushes.Green;
            if (PSettings.PersonalApmAlert)
            {
                if (HMainHandler.GInformation.Player[HMainHandler.GInformation.Player[0].Localplayer].Apm <
                    PSettings.PersonalApmAlertLimit)
                    clApmColor = Brushes.Red;
            }

            Drawing.DrawString(g.Graphics,
                "APM: " +
                HMainHandler.GInformation.Player[HMainHandler.GInformation.Player[0].Localplayer].ApmAverage.ToString(
                    CultureInfo.InvariantCulture) + " [" +
                HMainHandler.GInformation.Player[HMainHandler.GInformation.Player[0].Localplayer].Apm.ToString(
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

        protected override void ChangeForecolorOfButton(System.Drawing.Color cl)
        {
            /* Nothing */
        }

        protected override void BaseRenderer_ResizeEnd(object sender, EventArgs e)
        {
            HMainHandler.PSettings.PersonalApmHeight = (Height);
            HMainHandler.PSettings.PersonalApmWidth = Width;
            HMainHandler.PSettings.PersonalApmPositionX = Location.X;
            HMainHandler.PSettings.PersonalApmPositionY = Location.Y;
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
            Location = new Point(PSettings.PersonalApmPositionX,
                                     PSettings.PersonalApmPositionY);
            Size = new Size(PSettings.PersonalApmWidth,
                            PSettings.PersonalApmHeight);
        }

        protected override void MouseUpTransferData()
        {
            HMainHandler.PSettings.PersonalApmPositionX = Location.X;
            HMainHandler.PSettings.PersonalApmPositionY = Location.Y;
            HMainHandler.PSettings.PersonalApmWidth = Width;
            HMainHandler.PSettings.PersonalApmHeight = Height; 
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
