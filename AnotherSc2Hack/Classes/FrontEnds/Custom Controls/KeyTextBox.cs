using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public class KeyTextBox : TextBox
    {
        public Keys HotKeyValue { get; set; }

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

        /* Make it possible to use TAB */
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyTextBox_KeyDown(new object(), new KeyEventArgs(keyData));

            //return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

    
    }
}
