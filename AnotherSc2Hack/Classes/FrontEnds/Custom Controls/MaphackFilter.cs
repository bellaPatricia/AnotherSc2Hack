using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.FrontEnds;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    public partial class MaphackFilter : Form
    {
        public MaphackFilter()
        {
            InitializeComponent();

            
        }

        private void pnlFooter_Paint(object sender, PaintEventArgs e)
        {
            var send = (Panel)sender;

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, 0, Width, 0);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, send.Height - 1, Width, send.Height - 1);
        }
    }
}
