using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.FrontEnds.MainHandler
{
    public partial class NewMainHandler : Form
    {
        private Preferences _pSettings = new Preferences();

        public NewMainHandler()
        {
            InitializeComponent();

            ControlsFill();
        }

        private void ControlsFill()
        {
            ntxtMemoryRefresh.Number = _pSettings.GlobalDataRefresh;
            ntxtGraphicsRefresh.Number = _pSettings.GlobalDrawingRefresh;
            ktxtReposition.Text = _pSettings.GlobalChangeSizeAndPosition.ToString();
            chBxOnlyDrawInForeground.Checked = _pSettings.GlobalDrawOnlyInForeground;
        }

        private void NewMainHandler_Load(object sender, EventArgs e)
        {

        }

        private void cpnlApplication_Click(object sender, EventArgs e)
        {
            pnlApplication.Visible = true;
            lblTabname.Text = "Application";
        }

        private void cpnlOverlays_Click(object sender, EventArgs e)
        {
            lblTabname.Text = "Overlays";
        }

        private void cpnlAutomation_Click(object sender, EventArgs e)
        {
            lblTabname.Text = "Automation";
        }

        private void cpnlPlugins_Click(object sender, EventArgs e)
        {
            lblTabname.Text = "Plugins";
        }

        private void pnlMainArea_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(200, 200, 200))), new Point(15, 60),
                new Point(pnlMainArea.Width - 15, 60));
        }

        private void NewMainHandler_Resize(object sender, EventArgs e)
        {
            pnlMainArea.Invalidate();
        }
    }
}
