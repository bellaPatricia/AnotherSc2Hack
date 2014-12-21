using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    public partial class PanelSettingsSpecialUnittab : UserControl
    {
        public PanelSettingsSpecialUnittab()
        {
            InitializeComponent();
        }

        private void ntxtSize_NumberChanged(NumberTextBox o, EventNumber e)
        {
            pnlPreview.Invalidate();
            pnlPreview.Width = (int)e.TheNumber;
            pnlPreview.Height = (int)e.TheNumber;
        }

        private void pnlPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.tu_raven, 0,0, ntxtSize.Number, ntxtSize.Number);
        }


    }
}
