using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnotherSc2Hack;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.ExtensionMethods;

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
        private static readonly List<AnotherCheckbox> Instances = new List<AnotherCheckbox>();

        ~AnotherCheckbox()
        {
            var index = Instances.FindIndex(x => x.GetHashCode().Equals(GetHashCode()));
            Instances.RemoveAt(index);
        }


        public static void OutputPath()
        {
            foreach (var anotherCheckbox in Instances)
            {
                Console.WriteLine(HelpFunctions.GetParent(anotherCheckbox));
            }
        }

        public enum TextAlignment
        {
            Left,
            Right
        };

        private string _displayText = String.Empty;

        private readonly Pen _pInactiveBpxBorder = new Pen(new SolidBrush(Color.FromArgb(193, 193, 193)));
        private readonly Pen _pActiveBpxBorder = new Pen(new SolidBrush(Color.FromArgb(0, 149, 221)));

        public event CheckedChangeHandler CheckedChanged;

        public void OnCheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            if (CheckedChanged != null)
                CheckedChanged(o, e);
        }

        public string DisplayText
        {
            get { return _displayText;  }
            set
            {
                _displayText = value;
                if (_lMainText != null)
                    _lMainText.Text = _displayText;
            }
        }

        private Cursor _cursor = Cursors.Hand;
        public new Cursor Cursor
        {
            get { return _cursor; }
            set { _cursor = value;
            base.Cursor = value;
            }
        }

        private TextAlignment _textAlign = TextAlignment.Left;
        public TextAlignment TextAlign
        {
            get { return _textAlign; }
            set { _textAlign = value; }
        }

        private Boolean _checked = false;

        public Boolean Checked
        {
            get { return _checked; }
            set
            {
                if (value != _checked)
                {
                    _checked = value;
                    OnCheckedChanged(this, new EventChecked(_checked));
                    Invalidate();
                }
            }
        }

        private Boolean _clickable = true;
        public Boolean Clickable
        {
            get { return _clickable; }
            set { _clickable = value; }
        }

        private Boolean _bMouseOver = false;
        private Label _lMainText = new Label();

        private void Init()
        {
            base.Cursor = Cursor;

            Instances.Add(this);

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint, true);
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
            if (Clickable)
            {

                base.OnClick(e);

                Checked ^= true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);

            var fTextHeight = TextRenderer.MeasureText("dummy", Font).Height;
            var fHeight = (float)Size.Height / 2;
            var fY = fHeight - ((float)fTextHeight / 2);




            var posX = TextRenderer.MeasureText(DisplayText, Font).Width + 5;
            var posY = 5;
            var width = 20;
            var height = 20;

            if (TextAlign == TextAlignment.Right)
            {
                e.Graphics.DrawString(DisplayText, Font, new SolidBrush(_lMainText.ForeColor), new Point(width + 5, (int)fY));
                posX = 0;
            }

            else
                e.Graphics.DrawString(DisplayText, Font, new SolidBrush(_lMainText.ForeColor), new Point(0, (int)fY));

            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(251, 251, 251)), posX, posY, width, height);

            if (_bMouseOver && Clickable)
                e.Graphics.DrawRoundRect(_pActiveBpxBorder, posX, posY, width, height, 1);

            else
                e.Graphics.DrawRoundRect(_pInactiveBpxBorder, posX, posY, width, height, 1);

            if (Checked)
                e.Graphics.DrawImage(Properties.Resources.checkmark, posX + ((width - 12) / 2), posY + ((height - 12) / 2), 12, 12);

            Height = height + 10;
            Width = TextRenderer.MeasureText(DisplayText, Font).Width + 5 + width + 5;
        }
    }
}
