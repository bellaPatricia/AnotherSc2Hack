using System;

namespace Utilities.Events
{
    public delegate void NumberChangeHandler(object sender, NumberArgs e);

    public class NumberArgs : EventArgs
    {
        public int Number { get; set; }

        public NumberArgs(int number)
        {
            Number = number;
        }
    }
}
