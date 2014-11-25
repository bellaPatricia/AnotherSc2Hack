using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnotherSc2Hack;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public delegate void CheckedChangeHandler(AnotherCheckbox o, EventChecked e);

    public class EventChecked : EventArgs
    {
        public Boolean Value;

        public EventChecked(Boolean value)
        {
            Value = value;
        }
    }

    [DefaultEvent("CheckedChanged")]
    public class AnotherCheckbox : Panel
    {
        private String _displayText = string.Empty;

        private readonly Pen _pInactiveBpxBorder = new Pen(new SolidBrush(Color.FromArgb(193, 193, 193)));
        private readonly Pen _pActiveBpxBorder = new Pen(new SolidBrush(Color.FromArgb(0, 149, 221)));

        public event CheckedChangeHandler CheckedChanged;

        public void OnCheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            if (CheckedChanged != null)
                CheckedChanged(o, e);
        }

        public String DisplayText
        {
            get { return _displayText;  }
            set
            {
                _displayText = value;
                if (_lMainText != null)
                    _lMainText.Text = _displayText;
            }
        }

        private Boolean _checked = false;

        public Boolean Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                OnCheckedChanged(this, new EventChecked(_checked));
                Invalidate();
            }
        }

        private Boolean _bMouseOver = false;
        private Label _lMainText = new Label();

        private void Init()
        {
            _lMainText.AutoSize = true;
            _lMainText.MouseEnter += _lMainText_MouseEnter;
            _lMainText.Click += _lMainText_Click;

            Controls.Add(_lMainText);
        }

        void _lMainText_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        void _lMainText_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        public AnotherCheckbox()
        {
            Init();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            _bMouseOver = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            _bMouseOver = false;
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            Checked ^= true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);

            var fTextHeight = TextRenderer.MeasureText("dummy", _lMainText.Font).Height;
            var fHeight = (float)Size.Height / 2;
            var fY = fHeight - ((float)fTextHeight / 2);

            _lMainText.Location = new Point(0, (int)fY);



            var posX = TextRenderer.MeasureText(DisplayText, Font).Width + 5;
            var posY = 5;
            var width = 20;
            var height = 20;

            //e.Graphics.DrawRoundRect(new Pen(new SolidBrush(Color.Gray)), Width - 50, 10, 20, 20, 1f);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(251, 251, 251)), posX, posY, width, height);

            if (_bMouseOver)
                e.Graphics.DrawRoundRect(_pActiveBpxBorder, posX, posY, width, height, 1);

            else
                e.Graphics.DrawRoundRect(_pInactiveBpxBorder, posX, posY, width, height, 1);

            if (Checked)
                e.Graphics.DrawImage(Properties.Resources.checkmark, posX + ((width - 12) / 2), posY + ((height - 12) / 2));

            Height = height + 10;
            Width = TextRenderer.MeasureText(DisplayText, Font).Width + 5 + width + 5;
        }
    }
}
