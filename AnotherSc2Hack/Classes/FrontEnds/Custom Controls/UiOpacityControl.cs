using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.Events;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public delegate void ValueChangeHandler(UiOpacityControl o, NumberArgs e);

    [DefaultEvent("ValueChanged")]
    public partial class UiOpacityControl : UserControl
    {
        public event ValueChangeHandler ValueChanged;

        private Int32 _number;
        private LanguageString _lstrOpacity = new LanguageString("lstrOpacity");

        public Int32 Number
        {
            get { return _number; }
            set
            {
                //If it's the same number...
                if (_number == value)
                    return;

                _number = value;
                var en = new NumberArgs(_number);

                //Call the Event
                OnValueChange(this, en);

                Text = _number.ToString(CultureInfo.InvariantCulture);
            }
        }

        public void OnValueChange(UiOpacityControl o, NumberArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(o, e);
        }

        public UiOpacityControl()
        {
            InitializeComponent();

            _lstrOpacity.TextChanged += _lstrOpacity_TextChanged;
        }

        void _lstrOpacity_TextChanged(object sender, EventArgs e)
        {
            SetLabelText();   
        }

        private void tbOpacity_Scroll(object sender, EventArgs e)
        {
            Number = tbOpacity.Value;
        }

        public void SetLabelText()
        {
            lblOpacity.Text = _lstrOpacity + " " + tbOpacity.Value + "%";
        }

        private void tbOpacity_ValueChanged(object sender, EventArgs e)
        {
            SetLabelText();
        }
    }

    
}
