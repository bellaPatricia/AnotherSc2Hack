﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace AnotherSc2Hack.Classes.BackEnds
{
    public static class ExtensionMethods
    {
        #region String

        public static Boolean IsNullOrEmpty(this string text)
        {
            return String.IsNullOrEmpty(text);
        }

        public static Boolean IsNullOrWhitespace(this string text)
        {
            return String.IsNullOrWhiteSpace(text);
        }

        public static String RemoveAll(this string sourceText, string findText)
        {
            while (sourceText.Contains(findText))
                sourceText = sourceText.Remove(sourceText.IndexOf(findText, StringComparison.Ordinal), findText.Length);

            return sourceText;
        }

        public static String Fill(this string sourceText, string filler, int maxLength)
        {
            var sb = new StringBuilder(sourceText);

            if (sourceText.Length >= maxLength)
                return sb.ToString();

            var iCurrentLength = sourceText.Length;
            while ((iCurrentLength) < maxLength)
            {
                iCurrentLength += filler.Length;
                sb.Append(filler);
            }

            sb.Remove(maxLength, iCurrentLength - maxLength);

            return sb.ToString();
        }

        #endregion

        /// The following is from Arun Reginald Zaheeruddin
        /// The article about rounded rectangles can be found here:
        /// http://www.codeproject.com/Articles/5649/Extended-Graphics-An-implementation-of-Rounded-Rec
        /// 
        /// All credits go to him and/ or his article!
        public static void FillRoundRectangle(this Graphics g, Brush brush,
            float x, float y,
            float width, float height, float radius)
        {
            var oldQuality = g.SmoothingMode;

            g.SmoothingMode = SmoothingMode.HighQuality;
            var rectangle = new RectangleF(x, y, width, height);
            var path = GetRoundedRect(rectangle, radius);
            g.FillPath(brush, path);
            g.SmoothingMode = oldQuality;
        }

        public static void DrawRoundRect(this Graphics g, Pen p, float x, float y, float width, float height, float radius)
        {
            /*g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;*/
            var gp = new GraphicsPath();

            gp.AddLine(x + radius, y, x + width - (radius*2), y); // Line
            gp.AddArc(x + width - (radius*2), y, radius*2, radius*2, 270, 90); // Corner
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius*2)); // Line
            gp.AddArc(x + width - (radius*2), y + height - (radius*2), radius*2, radius*2, 0, 90); // Corner
            gp.AddLine(x + width - (radius*2), y + height, x + radius, y + height); // Line
            gp.AddArc(x, y + height - (radius*2), radius*2, radius*2, 90, 90); // Corner
            gp.AddLine(x, y + height - (radius*2), x, y + radius); // Line
            gp.AddArc(x, y, radius*2, radius*2, 180, 90); // Corner
            gp.CloseFigure();

            g.DrawPath(p, gp);
            gp.Dispose();

            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
        }




        private static GraphicsPath GetRoundedRect(RectangleF baseRect,
            float radius)
        {
            // if corner radius is less than or equal to zero, 
            // return the original rectangle 
            if (radius <= 0.0F)
            {
                var mPath = new GraphicsPath();
                mPath.AddRectangle(baseRect);
                mPath.CloseFigure();
                return mPath;
            }

            // if the corner radius is greater than or equal to 
            // half the width, or height (whichever is shorter) 
            // then return a capsule instead of a lozenge 
            if (radius >= (Math.Min(baseRect.Width, baseRect.Height))/2.0)
                return GetCapsule(baseRect);

            // create the arc for the rectangle sides and declare 
            // a graphics path object for the drawing 
            var diameter = radius*2.0F;
            var sizeF = new SizeF(diameter, diameter);
            var arc = new RectangleF(baseRect.Location, sizeF);
            var path = new GraphicsPath();

            // top left arc 
            path.AddArc(arc, 180, 90);

            // top right arc 
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc 
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private static GraphicsPath GetCapsule(RectangleF baseRect)
        {
            var path = new GraphicsPath();
            try
            {
                float diameter;
                RectangleF arc;
                if (baseRect.Width > baseRect.Height)
                {
                    // return horizontal capsule 
                    diameter = baseRect.Height;
                    var sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = baseRect.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (baseRect.Width < baseRect.Height)
                {
                    // return vertical capsule 
                    diameter = baseRect.Width;
                    var sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = baseRect.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else
                {
                    // return circle 
                    path.AddEllipse(baseRect);
                }
            }
            catch
            {
                path.AddEllipse(baseRect);
            }

            finally
            {
                path.CloseFigure();
            }


            return path;
        }


    }
}
