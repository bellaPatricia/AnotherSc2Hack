using System.Windows.Forms;
using AnotherSc2Hack.Properties;
using Utilities.Events;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    public partial class PanelSettingsSpecialUnittab : UserControl
    {
        public PanelSettingsSpecialUnittab()
        {
            InitializeComponent();
        }

        private void ntxtSize_NumberChanged(object o, NumberArgs e)
        {
            pnlPreview.Invalidate();
            pnlPreview.Width = e.Number;
            pnlPreview.Height = e.Number;
        }

        private void pnlPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Resources.tu_raven, 0,0, ntxtSize.Number, ntxtSize.Number);
        }


    }
}
