using System;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public partial class OpacityControl : UserControl
    {
        public OpacityControl()
        {
            InitializeComponent();
        }

        private void tbOpacity_Scroll(object sender, EventArgs e)
        {
            SetLabelText(tbOpacity.Value);
        }

        public void SetLabelText(double opacityValue)
        {
            lblOpacity.Text = "Opacity: " + tbOpacity.Value + " %";
        }
    }
}
