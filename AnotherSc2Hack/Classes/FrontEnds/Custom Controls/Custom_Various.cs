using System;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public partial class CustomVarious : AbstractUserControl
    {
        public CustomVarious()
        {
            InitializeComponent();
        }

        private void txtApmAlertLimit_TextChanged(object sender, EventArgs e)
        {
            if (txtApmAlertLimit.Text.Length <= 0)
                return;

            HelpFunctions.RemoveNonDigits(txtApmAlertLimit);
        }
    }
}
