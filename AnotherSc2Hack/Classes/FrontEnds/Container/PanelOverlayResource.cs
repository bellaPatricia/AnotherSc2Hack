using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    public partial class PanelOverlayBasics : UserControl
    {
        public PanelOverlayBasics()
        {
            InitializeComponent();
        }

        //ToDo: Gotta rethink this, it's horrible!
        public void InitializeControls(Preferences settings)
        {
            pnlBasics.aChBxDrawBackground.Checked = settings.ResourceDrawBackground;
            pnlBasics.aChBxRemoveAi.Checked = settings.ResourceRemoveAi;
            pnlBasics.aChBxRemoveAllie.Checked = settings.ResourceRemoveAllie;
            pnlBasics.aChBxRemoveClantags.Checked = settings.ResourceRemoveClanTag;
            pnlBasics.aChBxRemoveNeutral.Checked = settings.ResourceRemoveNeutral;
            pnlBasics.aChBxRemoveYourself.Checked = settings.ResourceRemoveLocalplayer;
            pnlBasics.btnSetFont.Text = settings.ResourceFontName;
            pnlBasics.OpacityControl.tbOpacity.Value = (int)(100*settings.ResourceOpacity);

            pnlLauncher.ktxtHotkey1.Text = settings.ResourceHotkey1.ToString();
            pnlLauncher.ktxtHotkey2.Text = settings.ResourceHotkey2.ToString();
            pnlLauncher.ktxtHotkey3.Text = settings.ResourceHotkey3.ToString();

            pnlLauncher.txtReposition.Text = settings.ResourceChangePositionPanel;
            pnlLauncher.txtResize.Text = settings.ResourceChangeSizePanel;
            pnlLauncher.txtToggle.Text = settings.ResourceTogglePanel;

            
        }

        
    }
}
