using System;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.Events
{
    public delegate void OffsetChangeHandler(object sender, OffsetArgs e);

    public class OffsetArgs : EventArgs
    {
        public BaseAddresses Addresses { get; set; }

        public OffsetArgs(BaseAddresses addresses)
        {
            Addresses = addresses;
        }
    }

    
}
