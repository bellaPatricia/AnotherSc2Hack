using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    public class ClickablePanel : Panel
    {
        private Boolean _isClicked = false;
        public Boolean IsClicked { get { return _isClicked; } set { _isClicked = value;
            Invalidate();
        } }
        public Boolean IsHovering { get; set; }

        private Color _inactiveBackgroundColor = Color.FromArgb(255, 66, 79, 90);
        private Color _activeBackgroundColor = Color.FromArgb(255, 52, 63, 72);
        private Color _hoverBackgroundColor = Color.FromArgb(255, 94, 105, 114);
        private Color _inactiveForegroundColor = Color.FromArgb(255, 193, 193, 193);
        private Color _activeForegroundColor = Color.FromArgb(255, 242, 242, 242);
        private Color _newBackgroundColor = Color.Wheat;

        private Brush _inactiveBackground = new SolidBrush(Color.FromArgb(255, 66, 79, 90));
        private Brush _activeBackground = new SolidBrush(Color.FromArgb(255, 52, 63, 72));
        private Brush _inactiveForeground = new SolidBrush(Color.FromArgb(255, 193, 193, 193));
        private Brush _activeForeground = new SolidBrush(Color.FromArgb(255, 242, 242, 242));
        private Brush _hoverBackground = new SolidBrush(Color.FromArgb(255, 94, 105, 114));
        private Brush _selectionColor = Brushes.Orange;

        public ClickablePanel()
        {
            Init();
        }

        private void Init()
        {
            SetStyle(ControlStyles.DoubleBuffer |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint, true);

            BackColor = _inactiveBackgroundColor;

            
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            foreach (var panel in Parent.Controls)
            {
                if (panel.GetType() == typeof(ClickablePanel))
                {
                    ((ClickablePanel)panel).IsClicked = false;
                }
            }

            IsClicked = true;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            IsHovering = true;

            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            IsHovering = false;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            if (IsClicked)
            {
                e.Graphics.FillRectangle(_selectionColor, 0, 0, 5, Height);
                _newBackgroundColor = _activeBackgroundColor;
            }

            else if (!IsClicked && IsHovering)
            {
                _newBackgroundColor = _hoverBackgroundColor;
            }

            else if (!IsClicked && !IsHovering)
            {
                _newBackgroundColor = _inactiveBackgroundColor;
            }

            BackColor = _newBackgroundColor;
        }
    }
}
