using System;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public class NumberTextBox : TextBox
    {
        public Int32 Number { get; set; }

        public NumberTextBox()
        {
            TextChanged += NumberTextBox_TextChanged;
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
