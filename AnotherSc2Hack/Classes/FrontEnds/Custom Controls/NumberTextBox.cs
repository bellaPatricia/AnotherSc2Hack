using System;
using System.Globalization;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public delegate void NumberChangeHandler(NumberTextBox o, EventNumber e);

    public class EventNumber : EventArgs
    {
        public Int64 TheNumber;

        public EventNumber(Int64 number)
        {
            TheNumber = number;
        }
    }

    public class NumberTextBox : TextBox
    {
        public event NumberChangeHandler NumberChanged;

        private Int32 _number;

        public Int32 Number
        {
            get { return _number; }
            set
            {
                //If it's the same number...
                if (_number == value)
                    return;

                _number = value;
                var en = new EventNumber(_number);

                //Call the Event
                OnNumberChange(this, en);

                Text = _number.ToString(CultureInfo.InvariantCulture);
            }
        }

        public NumberTextBox()
        {
            TextChanged += NumberTextBox_TextChanged;
        }

        public void OnNumberChange(NumberTextBox o, EventNumber e)
        {
            if (NumberChanged != null)
                NumberChanged(o, e);
        }

        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
            #region Parse the Number

            if (Text.Length <= 0)
                return;

            int iDummy;
            if (Int32.TryParse(Text, out iDummy))
            {
                Number = iDummy;
            }

            #endregion

            #region Remove Non- digits

            if (Text.Length <= 0)
                return;

            if (Text.StartsWith("\0"))
                return;

            for (var i = 0; i < Text.Length; i++)
            {
                if (char.IsDigit(Text[i]))
                    continue;

                Text = Text.Remove(i, 1);
                Select(i, 0);
            }

            #endregion
        }


    }
}
