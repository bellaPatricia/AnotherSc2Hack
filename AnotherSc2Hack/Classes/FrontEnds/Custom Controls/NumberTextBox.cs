using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using Utilities.Events;
using System.Drawing;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    [DefaultEvent("NumberChanged")]
    public class NumberTextBox : TextBox
    {
        public event NumberChangeHandler NumberChanged;

        private delegate void SetNumberTextboxTextDelegate(int number);

        private void SetNumberTextboxText(int number)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetNumberTextboxTextDelegate(SetNumberTextboxText), number);
                return;
            }

            Text = number.ToString();
        }

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
                var en = new NumberArgs(_number);

                SetNumberTextboxText(_number);

                //Call the Event
                OnNumberChange(this, en);
            }
        }

        public NumberTextBox()
        {
            TextChanged += NumberTextBox_TextChanged;
        }


        public void OnNumberChange(NumberTextBox o, NumberArgs e)
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
