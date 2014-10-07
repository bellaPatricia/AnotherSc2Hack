/// This sucks...
/// Bad code is bad
/// 
/// Whatever - this draws some rainbow'ish colors around the donation button.
/// So the user get's annoyed! :)

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public partial class ControlGlobal : AbstractUserControl
    {
        public ControlGlobal()
        {
            InitializeComponent();

            Timer tmr = new Timer();
            tmr.Interval = 60;
            tmr.Enabled = true;
            tmr.Tick += tmr_Tick;
        }

        

        void tmr_Tick(object sender, EventArgs e)
        {
            btnGlobalDonations.Invalidate();

            if (_colorA == 0)
                _bColorA = false;

            else if (_colorA == 255)
                _bColorA = true;

            if (_bColorA)
                _colorA -= 1;

            else
                _colorA += 1;


            if (_colorB == 0)
                _bColorB = false;

            else if (_colorB == 255)
                _bColorB = true;

            if (_bColorB)
                _colorB -= 1;

            else
                _colorB += 1;

            _colorC = (byte)rnd.Next(0, 256);


        }

        private byte _colorA = 255, _colorB, _colorC;
        private bool _bColorA = true, _bColorB;
        private readonly Random rnd = new Random();
        private void btnGlobalDonations_Paint(object sender, PaintEventArgs e)
        {
            var btn = (Button)sender;

            var br = new LinearGradientBrush(new Point(0, 0),
                new Point(btn.Width, btn.Height), Color.FromArgb(255, _colorA, _colorB, _colorC), Color.FromArgb(255, 255 - _colorA, 255 - _colorB, 255 - _colorC));

            const float width = 2f;

            e.Graphics.DrawRectangle(new Pen(br, width), 0 + width / 2, 0 + width / 2, btn.Width - width, btn.Height - width);
        }
    }
}
