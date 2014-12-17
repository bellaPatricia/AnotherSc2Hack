using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;
using AnotherSc2Hack.Classes.FrontEnds.Container;

namespace AnotherSc2Hack.Classes.FrontEnds.MainHandler
{
    public partial class NewMainHandler : Form
    {
        

        private Preferences _pSettings = new Preferences();
        public ApplicationStartOptions ApplicationOptions { get; private set; }

        public NewMainHandler(ApplicationStartOptions app)
        {
            InitializeComponent();

            ControlsFill();
            Init();

            ApplicationOptions = app;
        }

        private void Init()
        {
            cpnlApplication.IsClicked = true;
            cpnlOverlaysResources.IsClicked = true;

            
        }

        private void ControlsFill()
        {
            //Application / Global
            ntxtMemoryRefresh.Number = _pSettings.GlobalDataRefresh;
            ntxtGraphicsRefresh.Number = _pSettings.GlobalDrawingRefresh;
            ktxtReposition.Text = _pSettings.GlobalChangeSizeAndPosition.ToString();
            chBxOnlyDrawInForeground.Checked = _pSettings.GlobalDrawOnlyInForeground;

            InitializeResources();
            InitializeIncome();
            InitializeApm();
            InitializeArmy();
            InitializeWorker();
            InitializeMaphack();
        }


        //Rethink this
        private void InitializeResources()
        {
            pnlOverlayResource.pnlBasics.aChBxDrawBackground.Checked = _pSettings.ResourceDrawBackground;
            pnlOverlayResource.pnlBasics.aChBxRemoveAi.Checked = _pSettings.ResourceRemoveAi;
            pnlOverlayResource.pnlBasics.aChBxRemoveAllie.Checked = _pSettings.ResourceRemoveAllie;
            pnlOverlayResource.pnlBasics.aChBxRemoveClantags.Checked = _pSettings.ResourceRemoveClanTag;
            pnlOverlayResource.pnlBasics.aChBxRemoveNeutral.Checked = _pSettings.ResourceRemoveNeutral;
            pnlOverlayResource.pnlBasics.aChBxRemoveYourself.Checked = _pSettings.ResourceRemoveLocalplayer;
            pnlOverlayResource.pnlBasics.btnSetFont.Text = _pSettings.ResourceFontName;
            pnlOverlayResource.pnlBasics.OpacityControl.tbOpacity.Value = (int)(100 * _pSettings.ResourceOpacity);

            pnlOverlayResource.pnlLauncher.ktxtHotkey1.Text = _pSettings.ResourceHotkey1.ToString();
            pnlOverlayResource.pnlLauncher.ktxtHotkey2.Text = _pSettings.ResourceHotkey2.ToString();
            pnlOverlayResource.pnlLauncher.ktxtHotkey3.Text = _pSettings.ResourceHotkey3.ToString();

            pnlOverlayResource.pnlLauncher.txtReposition.Text = _pSettings.ResourceChangePositionPanel;
            pnlOverlayResource.pnlLauncher.txtResize.Text = _pSettings.ResourceChangeSizePanel;
            pnlOverlayResource.pnlLauncher.txtToggle.Text = _pSettings.ResourceTogglePanel;
        }

        private void InitializeIncome()
        {
            pnlOverlayIncome.pnlBasics.aChBxDrawBackground.Checked = _pSettings.IncomeDrawBackground;
            pnlOverlayIncome.pnlBasics.aChBxRemoveAi.Checked = _pSettings.IncomeRemoveAi;
            pnlOverlayIncome.pnlBasics.aChBxRemoveAllie.Checked = _pSettings.IncomeRemoveAllie;
            pnlOverlayIncome.pnlBasics.aChBxRemoveClantags.Checked = _pSettings.IncomeRemoveClanTag;
            pnlOverlayIncome.pnlBasics.aChBxRemoveNeutral.Checked = _pSettings.IncomeRemoveNeutral;
            pnlOverlayIncome.pnlBasics.aChBxRemoveYourself.Checked = _pSettings.IncomeRemoveLocalplayer;
            pnlOverlayIncome.pnlBasics.btnSetFont.Text = _pSettings.IncomeFontName;
            pnlOverlayIncome.pnlBasics.OpacityControl.tbOpacity.Value = (int)(100 * _pSettings.IncomeOpacity);

            pnlOverlayIncome.pnlLauncher.ktxtHotkey1.Text = _pSettings.IncomeHotkey1.ToString();
            pnlOverlayIncome.pnlLauncher.ktxtHotkey2.Text = _pSettings.IncomeHotkey2.ToString();
            pnlOverlayIncome.pnlLauncher.ktxtHotkey3.Text = _pSettings.IncomeHotkey3.ToString();

            pnlOverlayIncome.pnlLauncher.txtReposition.Text = _pSettings.IncomeChangePositionPanel;
            pnlOverlayIncome.pnlLauncher.txtResize.Text = _pSettings.IncomeChangeSizePanel;
            pnlOverlayIncome.pnlLauncher.txtToggle.Text = _pSettings.IncomeTogglePanel;
        }

        private void InitializeApm()
        {
            pnlOverlayApm.pnlBasics.aChBxDrawBackground.Checked = _pSettings.ApmDrawBackground;
            pnlOverlayApm.pnlBasics.aChBxRemoveAi.Checked = _pSettings.ApmRemoveAi;
            pnlOverlayApm.pnlBasics.aChBxRemoveAllie.Checked = _pSettings.ApmRemoveAllie;
            pnlOverlayApm.pnlBasics.aChBxRemoveClantags.Checked = _pSettings.ApmRemoveClanTag;
            pnlOverlayApm.pnlBasics.aChBxRemoveNeutral.Checked = _pSettings.ApmRemoveNeutral;
            pnlOverlayApm.pnlBasics.aChBxRemoveYourself.Checked = _pSettings.ApmRemoveLocalplayer;
            pnlOverlayApm.pnlBasics.btnSetFont.Text = _pSettings.ApmFontName;
            pnlOverlayApm.pnlBasics.OpacityControl.tbOpacity.Value = (int)(100 * _pSettings.ApmOpacity);

            pnlOverlayApm.pnlLauncher.ktxtHotkey1.Text = _pSettings.ApmHotkey1.ToString();
            pnlOverlayApm.pnlLauncher.ktxtHotkey2.Text = _pSettings.ApmHotkey2.ToString();
            pnlOverlayApm.pnlLauncher.ktxtHotkey3.Text = _pSettings.ApmHotkey3.ToString();

            pnlOverlayApm.pnlLauncher.txtReposition.Text = _pSettings.ApmChangePositionPanel;
            pnlOverlayApm.pnlLauncher.txtResize.Text = _pSettings.ApmChangeSizePanel;
            pnlOverlayApm.pnlLauncher.txtToggle.Text = _pSettings.ApmTogglePanel;
        }

        private void InitializeArmy()
        {
            pnlOverlayArmy.pnlBasics.aChBxDrawBackground.Checked = _pSettings.ArmyDrawBackground;
            pnlOverlayArmy.pnlBasics.aChBxRemoveAi.Checked = _pSettings.ArmyRemoveAi;
            pnlOverlayArmy.pnlBasics.aChBxRemoveAllie.Checked = _pSettings.ArmyRemoveAllie;
            pnlOverlayArmy.pnlBasics.aChBxRemoveClantags.Checked = _pSettings.ArmyRemoveClanTag;
            pnlOverlayArmy.pnlBasics.aChBxRemoveNeutral.Checked = _pSettings.ArmyRemoveNeutral;
            pnlOverlayArmy.pnlBasics.aChBxRemoveYourself.Checked = _pSettings.ArmyRemoveLocalplayer;
            pnlOverlayArmy.pnlBasics.btnSetFont.Text = _pSettings.ArmyFontName;
            pnlOverlayArmy.pnlBasics.OpacityControl.tbOpacity.Value = (int)(100 * _pSettings.ArmyOpacity);

            pnlOverlayArmy.pnlLauncher.ktxtHotkey1.Text = _pSettings.ArmyHotkey1.ToString();
            pnlOverlayArmy.pnlLauncher.ktxtHotkey2.Text = _pSettings.ArmyHotkey2.ToString();
            pnlOverlayArmy.pnlLauncher.ktxtHotkey3.Text = _pSettings.ArmyHotkey3.ToString();

            pnlOverlayArmy.pnlLauncher.txtReposition.Text = _pSettings.ArmyChangePositionPanel;
            pnlOverlayArmy.pnlLauncher.txtResize.Text = _pSettings.ArmyChangeSizePanel;
            pnlOverlayArmy.pnlLauncher.txtToggle.Text = _pSettings.ArmyTogglePanel;
        }

        private void InitializeMaphack()
        {
            pnlOverlayMaphack.pnlBasics.aChBxRemoveAi.Checked = _pSettings.MaphackRemoveAi;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveAllie.Checked = _pSettings.MaphackRemoveAllie;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveNeutral.Checked = _pSettings.MaphackRemoveNeutral;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveYourself.Checked = _pSettings.MaphackRemoveLocalplayer;
            pnlOverlayMaphack.pnlBasics.OpacityControl.tbOpacity.Value = (int)(100 * _pSettings.MaphackOpacity);
            pnlOverlayMaphack.pnlBasics.aChBxDefensiveStructures.Checked =
                _pSettings.MaphackColorDefensivestructuresYellow;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveCamera.Checked = _pSettings.MaphackRemoveCamera;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveVisionArea.Checked = _pSettings.MaphackRemoveVisionArea;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveDestinationLine.Checked = _pSettings.MaphackDisableDestinationLine;
            pnlOverlayMaphack.pnlBasics.btnColorDestinationline.BackColor = _pSettings.MaphackDestinationColor;

            pnlOverlayMaphack.pnlLauncher.ktxtHotkey1.Text = _pSettings.MaphackHotkey1.ToString();
            pnlOverlayMaphack.pnlLauncher.ktxtHotkey2.Text = _pSettings.MaphackHotkey2.ToString();
            pnlOverlayMaphack.pnlLauncher.ktxtHotkey3.Text = _pSettings.MaphackHotkey3.ToString();

            pnlOverlayMaphack.pnlLauncher.txtReposition.Text = _pSettings.MaphackChangePositionPanel;
            pnlOverlayMaphack.pnlLauncher.txtResize.Text = _pSettings.MaphackChangeSizePanel;
            pnlOverlayMaphack.pnlLauncher.txtToggle.Text = _pSettings.MaphackTogglePanel;
        }

        private void InitializeWorker()
        {
            pnlOverlayWorker.aChBxDrawBackground.Checked = _pSettings.WorkerDrawBackground;
            pnlOverlayWorker.btnSetFont.Text = _pSettings.WorkerFontName;
            pnlOverlayWorker.OpacityControl.tbOpacity.Value = (int)(100 * _pSettings.WorkerOpacity);

            pnlOverlayWorker.pnlLauncher.ktxtHotkey1.Text = _pSettings.WorkerHotkey1.ToString();
            pnlOverlayWorker.pnlLauncher.ktxtHotkey2.Text = _pSettings.WorkerHotkey2.ToString();
            pnlOverlayWorker.pnlLauncher.ktxtHotkey3.Text = _pSettings.WorkerHotkey3.ToString();

            pnlOverlayWorker.pnlLauncher.txtReposition.Text = _pSettings.WorkerChangePositionPanel;
            pnlOverlayWorker.pnlLauncher.txtResize.Text = _pSettings.WorkerChangeSizePanel;
            pnlOverlayWorker.pnlLauncher.txtToggle.Text = _pSettings.WorkerTogglePanel;
        }



        private void NewMainHandler_Load(object sender, EventArgs e)
        {

        }

        private void cpnlApplication_Click(object sender, EventArgs e)
        {
            lblTabname.Text = "Application";

            pnlApplication.Visible = true;
            foreach (var pnl in pnlMainArea.Controls)
            {
                if (pnl == pnlApplication)
                    continue;

                if (pnl.GetType() == typeof(Panel))
                {
                    ((Panel)pnl).Visible = false;
                }
            }
        }

        private void cpnlOverlays_Click(object sender, EventArgs e)
        {
            lblTabname.Text = "Overlays";

            pnlOverlays.Visible = true;
            foreach (var pnl in pnlMainArea.Controls)
            {
                if (pnl == pnlOverlays)
                    continue;

                if (pnl.GetType() == typeof(Panel))
                {
                    ((Panel)pnl).Visible = false;
                }
            }
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

        private void cpnlDebug_Click(object sender, EventArgs e)
        {
            lblTabname.Text = "Debug";
        }

        private void pnlLeftSelection_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cpnlApplication_Paint(object sender, PaintEventArgs e)
        {
            
        }

        //Draw a new border on the top and bottom of the panel
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var send = (Panel)sender;

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, 0, Width, 0);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, send.Height - 1, Width, send.Height - 1);
        }

        private void chBxOnlyDrawInForeground_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {

        }

        private void cpnlOverlaysResources_Click(object sender, EventArgs e)
        {
            pnlOverlayResource.Visible = true;

            foreach (var pnl in pnlOverlays.Controls)
            {
                if (pnl == pnlPanelContainer ||
                    pnl == pnlOverlayResource)
                    continue;

                if (pnl.GetType() == typeof(PanelOverlayBasics))
                    ((PanelOverlayBasics)pnl).Visible = false;

                    
                else if (pnl.GetType() == typeof(PanelOverlayWorker))
                    ((PanelOverlayWorker)pnl).Visible = false;

                else if (pnl.GetType() == typeof (PanelOverlayMaphack))
                    ((PanelOverlayMaphack) pnl).Visible = false;
            }
        }

        private void cpnlOverlaysIncome_Click(object sender, EventArgs e)
        {
            pnlOverlayIncome.Visible = true;

            foreach (var pnl in pnlOverlays.Controls)
            {
                if (pnl == pnlPanelContainer ||
                    pnl == pnlOverlayIncome)
                    continue;

                if (pnl.GetType() == typeof(PanelOverlayBasics))
                    ((PanelOverlayBasics)pnl).Visible = false;

                else if (pnl.GetType() == typeof(PanelOverlayWorker))
                    ((PanelOverlayWorker)pnl).Visible = false;

                else if (pnl.GetType() == typeof(PanelOverlayMaphack))
                    ((PanelOverlayMaphack)pnl).Visible = false;
            }
        }

        private void cpnlOverlaysWorker_Click(object sender, EventArgs e)
        {
            pnlOverlayWorker.Visible = true;

            foreach (var pnl in pnlOverlays.Controls)
            {
                if (pnl == pnlPanelContainer ||
                    pnl == pnlOverlayWorker)
                    continue;

                if (pnl.GetType() == typeof(PanelOverlayBasics))
                    ((PanelOverlayBasics)pnl).Visible = false;

                else if (pnl.GetType() == typeof(PanelOverlayWorker))
                    ((PanelOverlayWorker)pnl).Visible = false;

                else if (pnl.GetType() == typeof(PanelOverlayMaphack))
                    ((PanelOverlayMaphack)pnl).Visible = false;
            }
        }

        private void cpnlOverlaysArmy_Click(object sender, EventArgs e)
        {
            pnlOverlayArmy.Visible = true;

            foreach (var pnl in pnlOverlays.Controls)
            {
                if (pnl == pnlPanelContainer ||
                    pnl == pnlOverlayArmy)
                    continue;

                if (pnl.GetType() == typeof(PanelOverlayBasics))
                    ((PanelOverlayBasics)pnl).Visible = false;

                else if (pnl.GetType() == typeof(PanelOverlayWorker))
                    ((PanelOverlayWorker)pnl).Visible = false;

                else if (pnl.GetType() == typeof(PanelOverlayMaphack))
                    ((PanelOverlayMaphack)pnl).Visible = false;
            }
        }

        private void cpnlOverlaysApm_Click(object sender, EventArgs e)
        {
            pnlOverlayApm.Visible = true;

            foreach (var pnl in pnlOverlays.Controls)
            {
                if (pnl == pnlPanelContainer ||
                    pnl == pnlOverlayApm)
                    continue;

                if (pnl.GetType() == typeof(PanelOverlayBasics))
                    ((PanelOverlayBasics)pnl).Visible = false;

                else if (pnl.GetType() == typeof(PanelOverlayWorker))
                    ((PanelOverlayWorker)pnl).Visible = false;

                else if (pnl.GetType() == typeof(PanelOverlayMaphack))
                    ((PanelOverlayMaphack)pnl).Visible = false;
            }
        }

        private void cpnlOverlaysMaphack_Click(object sender, EventArgs e)
        {
            pnlOverlayMaphack.Visible = true;

            foreach (var pnl in pnlOverlays.Controls)
            {
                if (pnl == pnlPanelContainer ||
                    pnl == pnlOverlayMaphack)
                    continue;

                if (pnl.GetType() == typeof(PanelOverlayBasics))
                    ((PanelOverlayBasics)pnl).Visible = false;

                else if (pnl.GetType() == typeof(PanelOverlayWorker))
                    ((PanelOverlayWorker)pnl).Visible = false;

                else if (pnl.GetType() == typeof(PanelOverlayMaphack))
                    ((PanelOverlayMaphack)pnl).Visible = false;
            }
        }

        private void cpnlOverlaysUnits_Click(object sender, EventArgs e)
        {

        }

        private void cpnlOverlaysProduction_Click(object sender, EventArgs e)
        {

        }
    }

    
}
