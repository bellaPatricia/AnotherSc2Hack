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

        public Boolean IsClicked
        {
            get { return _isClicked; }
            set
            {
                _isClicked = value;

                if (value)
                {
                    foreach (var panel in Parent.Controls)
                    {
                        if (panel == this)
                        {
                            DisplayColor = _activeForegroundColor;
                            continue;
                        }

                        if (panel.GetType() == typeof (ClickablePanel))
                        {
                            ((ClickablePanel) panel).IsClicked = false;
                            ((ClickablePanel) panel).DisplayColor = _inactiveForegroundColor;
                        }
                    }
                }


                Invalidate();
            }
        }

        private String _displayText = String.Empty;

        public String DisplayText
        {
            get { return _displayText; }
            set
            {
                _displayText = value;
                _lMainText.Text = _displayText;
            }
        }

        private Color _displayColor = Color.Wheat;

        public Color DisplayColor
        {
            get { return _displayColor; }
            set
            {
                _displayColor = value;

                if (_lMainText != null)
                    _lMainText.ForeColor = _displayColor;
            }
        }

        private float _textSize = 9f;

        public float TextSize
        {
            get { return _textSize; }
            set
            {
                _textSize = value;

                if (_lMainText != null)
                    _lMainText.Font = new Font(Font.Name, _textSize);
            }
        }

        public Boolean IsHovering { get; set; }

        private Color _inactiveBackgroundColor = Color.FromArgb(255, 66, 79, 90);
        private Color _activeBackgroundColor = Color.FromArgb(255, 52, 63, 72);
        private Color _hoverBackgroundColor = Color.FromArgb(255, 94, 105, 114);
        private Color _inactiveForegroundColor = Color.FromArgb(255, 193, 193, 193);
        private Color _activeForegroundColor = Color.FromArgb(255, 242, 242, 242);
        private Color _newBackgroundColor = Color.Wheat;
        private Label _lMainText = new Label();

        private Brush _inactiveBackground = new SolidBrush(Color.FromArgb(255, 66, 79, 90));
        private Brush _activeBackground = new SolidBrush(Color.FromArgb(255, 52, 63, 72));
        private Brush _inactiveForeground = new SolidBrush(Color.FromArgb(255, 193, 193, 193));
        private Brush _activeForeground = new SolidBrush(Color.FromArgb(255, 242, 242, 242));
        private Brush _hoverBackground = new SolidBrush(Color.FromArgb(255, 94, 105, 114));
        private Brush _selectionColor = Brushes.Orange;
        private Boolean _bInitCalled = false;

        public ClickablePanel()
        {
           // Init();
        }

        private void Init()
        {
            SetStyle(ControlStyles.DoubleBuffer |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint, true);

            BackColor = _inactiveBackgroundColor;

            if (DisplayText.Length <= 0)
                DisplayText = "[SampleText]";

            TextSize = 13;
            DisplayColor = _inactiveForegroundColor;

            var fTextHeight = TextRenderer.MeasureText("dummy", _lMainText.Font).Height;
            var fHeight = (float)Size.Height / 2;
            var fY = fHeight - ((float)fTextHeight / 2);

            _lMainText.Location = new Point(15, (int)fY);
            _lMainText.MouseEnter += _lMainText_MouseEnter;
            _lMainText.Click += _lMainText_Click;
            

            Controls.Add(_lMainText);


            _bInitCalled = true;
        }

        void _lMainText_Click(object sender, EventArgs e)
        {
            if (!IsClicked)
                IsClicked = true;
            
        }

        void _lMainText_MouseEnter(object sender, EventArgs e)
        {
            IsHovering = true;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            
            if (!IsClicked)
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

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (!_bInitCalled)
                Init();
        }
    }
}
