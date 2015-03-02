using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.Events;

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
            e.Graphics.DrawImage(Properties.Resources.tu_raven, 0,0, ntxtSize.Number, ntxtSize.Number);
        }


    }
}
