using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    public delegate void KeyValueChangeHandler(KeyTextBox o, EventKey e);

    public class EventKey : EventArgs
    {
        public Keys KeyValue;

        public EventKey(Keys key)
        {
            KeyValue = key;
        }
    }

    [DefaultEvent("KeyChanged")]
    public class KeyTextBox : TextBox
    {
        public event KeyValueChangeHandler KeyChanged;

        private Keys _hotKeyValue;

        public Keys HotKeyValue
        {
            get { return _hotKeyValue; }
            set
            {
                //If it's the same number...
                if (_hotKeyValue == value)
                    return;

                _hotKeyValue = value;
                var en = new EventKey(_hotKeyValue);

                //Call the Event
                OnKeyValueChange(this, en);

                Text = _hotKeyValue.ToString();
            }
        }

        public KeyTextBox()
        {
            /* Set Key_Down */
            KeyDown += KeyTextBox_KeyDown;
        }

        private void KeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Text = e.KeyCode.ToString();
            HotKeyValue = e.KeyCode;
            e.SuppressKeyPress = true;

            
        }

        public void OnKeyValueChange(KeyTextBox o, EventKey e)
        {
            if (KeyChanged != null)
                KeyChanged(o, e);
        }

        /* Make it possible to use TAB */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyTextBox_KeyDown(new object(), new KeyEventArgs(keyData));

            //return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

    
    }
}
