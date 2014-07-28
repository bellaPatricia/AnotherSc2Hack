using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AnotherSc2Hack.Classes.BackEnds
{
    public static class Drawing
    {
        public static void DrawString(Graphics g, string text, Font font, Brush textBrush, Brush shadowBrush, float x, float y, float shadowXOffset, float shadowYOffset, bool addShadow)
        {
            if (addShadow)
            {
                /* Shadow */
                g.DrawString(text, font, shadowBrush, x + shadowXOffset, y + shadowYOffset);
            }


            /* Text */
            g.DrawString(text, font, textBrush, x, y);
        }

        public static void DrawImage(Graphics g, Image img, float x, float y, float width, float height,
            Brush shadowBrush, float shadowXOffset, float shadowYOffset, bool addShadow)
        {
            if (addShadow)
            {
                g.FillRectangle(shadowBrush, x + shadowXOffset, y + shadowYOffset, width, height);
            }

            g.DrawImage(img, x, y, width, height);
        }
    }
}
