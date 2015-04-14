using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.Events;


namespace AnotherSc2Hack.Classes.FrontEnds
{
    [DefaultEvent("NumberChanged")]
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
                var en = new NumberArgs(_number);
                
                //Sometimes, this method gets called in "Not-a-UI-Thread" context, throwing an exception about cross-threading.
                //So we prevent this by passing the action to the invoker to take care of it.
                MethodInvoker methInvoker = delegate {
                                                         Text = _number.ToString(CultureInfo.InvariantCulture);
                };

                try
                {
                    if (Handle != IntPtr.Zero)
                    Invoke(methInvoker);
                }

                //Like the Window Handle isn't initiated
                catch (InvalidOperationException)
                {
                    //We can't really allows cross-calling so we just swallow this exception
                    //Text = _number.ToString(CultureInfo.InvariantCulture);
                }

                //Ignore all  the other errors
                catch
                {
                    
                }

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
