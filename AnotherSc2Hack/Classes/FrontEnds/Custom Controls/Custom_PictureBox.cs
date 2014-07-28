using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    class CustomPictureBox : PictureBox
    {
        public CustomPictureBox()
        {
            DrawingPoint = new PointF(0, 0);
            DrawingText = "";
            DrawingFont = Font;
            DrawingBrush = Brushes.Transparent;
        }

        public override sealed Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            pe.Graphics.DrawString(DrawingText, DrawingFont, DrawingBrush, DrawingPoint);
            pe.Graphics.DrawRectangle(new Pen(Brushes.Red, 2), 1, 1, Width - 2, Height - 2);
        }

        public PointF DrawingPoint { get; set; }
        public Font DrawingFont { get; set; }
        public Brush DrawingBrush { get; set; }
        public String DrawingText { get; set; }
    }
}
