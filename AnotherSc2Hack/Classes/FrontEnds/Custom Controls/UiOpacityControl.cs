using System;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public partial class UiOpacityControl : UserControl
    {
        public UiOpacityControl()
        {
            InitializeComponent();
        }

        private void tbOpacity_Scroll(object sender, EventArgs e)
        {
            
        }

        public void SetLabelText(double opacityValue)
        {
            lblOpacity.Text = "Opacity: " + tbOpacity.Value + " %";
        }

        private void tbOpacity_ValueChanged(object sender, EventArgs e)
        {
            SetLabelText(tbOpacity.Value);
        }
    }
}
