using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.BackEnds.Gameinfo;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;
using AnotherSc2Hack.Classes.FrontEnds.Container;
using Predefined;

namespace AnotherSc2Hack.Classes.FrontEnds.MainHandler
{
    public partial class NewMainHandler : Form
    {
        

        private Preferences _pSettings = new Preferences();
        private Timer _tmrMainTick = new Timer();
        private Int32 _iDebugPlayerIndex = 0;

        private Int32 IDebugPlayerIndex
        {
            get {  return _iDebugPlayerIndex; }
            set
            {
                _iDebugPlayerIndex = value;

                if (Gameinfo != null && Gameinfo.Player != null)
                    lblDebugPlayerLocation.Text = _iDebugPlayerIndex + "/" + (Gameinfo.Player.Count - 1);

                DebugPlayerRefresh();
            }
        }

        public GameInfo Gameinfo { get; private set; }
        public ApplicationStartOptions ApplicationOptions { get; private set; }

        public NewMainHandler(ApplicationStartOptions app)
        {
            InitializeComponent();

            ControlsFill();
            Init();

            ApplicationOptions = app;

            Gameinfo = new GameInfo(_pSettings.GlobalDataRefresh);
        }

        private void Init()
        {
            cpnlApplication.PerformClick();
            cpnlOverlaysResources.PerformClick();

            _tmrMainTick.Interval = _pSettings.GlobalDataRefresh;
            _tmrMainTick.Tick += _tmrMainTick_Tick;
            _tmrMainTick.Enabled = true;
        }

        void _tmrMainTick_Tick(object sender, EventArgs e)
        {
          /*  aChBxStarcraftFound.Checked = Gameinfo.CStarcraft2 != null ? true : false;
            aChBxIngame.Checked = Gameinfo.Gameinfo.IsIngame;*/


            
        }

        private void DebugPlayerRefresh()
        {
            if (Gameinfo == null || Gameinfo.Player == null)
                return;

            var player = Gameinfo.Player[IDebugPlayerIndex];
            var properties = TypeDescriptor.GetProperties(player);

            if (lstvDebugPlayderdata.Items.Count > 0)
            {
                //Actually refresh, not insert new ones!
                for (var i = 0; i < properties.Count; i++)
                {
                    var property = properties[i];

                    lstvDebugPlayderdata.Items[i].SubItems[1].Text = property.GetValue(player).ToString();
                }

                

            }

            else
            {
                //Insert new ones
                foreach (PropertyDescriptor property in properties)
                {
                    var lwi = new ListViewItem();

                    lwi.Text = property.Name;
                    lwi.SubItems.Add(new ListViewItem.ListViewSubItem(lwi, property.GetValue(player).ToString()));

                    lstvDebugPlayderdata.Items.Add(lwi);
                }

            }

            


        }

        #region Load Settings Into Controls

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
            InitializeUnittab();
            InitializeProductiontab();
        }

        private void InitializeResources()
        {
            pnlOverlayResource.pnlBasics.aChBxDrawBackground.Checked = _pSettings.ResourceDrawBackground;
            pnlOverlayResource.pnlBasics.aChBxRemoveAi.Checked = _pSettings.ResourceRemoveAi;
            pnlOverlayResource.pnlBasics.aChBxRemoveAllie.Checked = _pSettings.ResourceRemoveAllie;
            pnlOverlayResource.pnlBasics.aChBxRemoveClantags.Checked = _pSettings.ResourceRemoveClanTag;
            pnlOverlayResource.pnlBasics.aChBxRemoveNeutral.Checked = _pSettings.ResourceRemoveNeutral;
            pnlOverlayResource.pnlBasics.aChBxRemoveYourself.Checked = _pSettings.ResourceRemoveLocalplayer;
            pnlOverlayResource.pnlBasics.btnSetFont.Text = _pSettings.ResourceFontName;
            pnlOverlayResource.pnlBasics.OpacityControl.tbOpacity.Value = _pSettings.ResourceOpacity > 1.0
                ? (Int32)_pSettings.ResourceOpacity
                : (Int32)(_pSettings.ResourceOpacity * 100);

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
            pnlOverlayIncome.pnlBasics.OpacityControl.tbOpacity.Value = _pSettings.IncomeOpacity > 1.0
                ? (Int32)_pSettings.IncomeOpacity
                : (Int32)(_pSettings.IncomeOpacity * 100);

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
            pnlOverlayApm.pnlBasics.OpacityControl.tbOpacity.Value = _pSettings.ApmOpacity > 1.0
                ? (Int32)_pSettings.ApmOpacity
                : (Int32)(_pSettings.ApmOpacity * 100);

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
            pnlOverlayArmy.pnlBasics.OpacityControl.tbOpacity.Value = _pSettings.ArmyOpacity > 1.0
                ? (Int32)_pSettings.ArmyOpacity
                : (Int32)(_pSettings.ArmyOpacity * 100);

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
            pnlOverlayMaphack.pnlBasics.OpacityControl.tbOpacity.Value = _pSettings.MaphackOpacity > 1.0
                ? (Int32)_pSettings.MaphackOpacity
                : (Int32)(_pSettings.MaphackOpacity * 100);
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
            pnlOverlayWorker.OpacityControl.tbOpacity.Value = _pSettings.WorkerOpacity > 1.0
                ? (Int32)_pSettings.WorkerOpacity
                : (Int32)(_pSettings.WorkerOpacity * 100);

            pnlOverlayWorker.pnlLauncher.ktxtHotkey1.Text = _pSettings.WorkerHotkey1.ToString();
            pnlOverlayWorker.pnlLauncher.ktxtHotkey2.Text = _pSettings.WorkerHotkey2.ToString();
            pnlOverlayWorker.pnlLauncher.ktxtHotkey3.Text = _pSettings.WorkerHotkey3.ToString();

            pnlOverlayWorker.pnlLauncher.txtReposition.Text = _pSettings.WorkerChangePositionPanel;
            pnlOverlayWorker.pnlLauncher.txtResize.Text = _pSettings.WorkerChangeSizePanel;
            pnlOverlayWorker.pnlLauncher.txtToggle.Text = _pSettings.WorkerTogglePanel;
        }

        private void InitializeUnittab()
        {
            pnlOverlayUnittab.pnlBasics.aChBxRemoveAi.Checked = _pSettings.UnitTabRemoveAi;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveAllie.Checked = _pSettings.UnitTabRemoveAllie;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveClantags.Checked = _pSettings.UnitTabRemoveClanTag;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveNeutral.Checked = _pSettings.UnitTabRemoveNeutral;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveYourself.Checked = _pSettings.UnitTabRemoveLocalplayer;
            pnlOverlayUnittab.pnlBasics.btnSetFont.Text = _pSettings.UnitTabFontName;
            pnlOverlayUnittab.pnlBasics.OpacityControl.tbOpacity.Value = _pSettings.UnitTabOpacity > 1.0
                ? (Int32)_pSettings.UnitTabOpacity
                : (Int32)(_pSettings.UnitTabOpacity * 100);
            pnlOverlayUnittab.pnlBasics.aChBxDisplayBuildings.Checked = _pSettings.UnitTabShowBuildings;
            pnlOverlayUnittab.pnlBasics.aChBxDisplayUnits.Checked = _pSettings.UnitTabShowUnits;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveChronoboost.Checked = _pSettings.UnitTabRemoveChronoboost;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveProductionstatus.Checked = _pSettings.UnitTabRemoveProdLine;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveSpellcounter.Checked = _pSettings.UnitTabRemoveSpellCounter;
            pnlOverlayUnittab.pnlBasics.aChBxSplitUnitsBuildings.Checked = _pSettings.UnitTabSplitUnitsAndBuildings;
            pnlOverlayUnittab.pnlBasics.aChBxTransparentImages.Checked = _pSettings.UnitTabUseTransparentImages;
            

            pnlOverlayUnittab.pnlLauncher.ktxtHotkey1.Text = _pSettings.UnitHotkey1.ToString();
            pnlOverlayUnittab.pnlLauncher.ktxtHotkey2.Text = _pSettings.UnitHotkey2.ToString();
            pnlOverlayUnittab.pnlLauncher.ktxtHotkey3.Text = _pSettings.UnitHotkey3.ToString();

            pnlOverlayUnittab.pnlLauncher.txtReposition.Text = _pSettings.UnitChangePositionPanel;
            pnlOverlayUnittab.pnlLauncher.txtResize.Text = _pSettings.UnitChangeSizePanel;
            pnlOverlayUnittab.pnlLauncher.txtToggle.Text = _pSettings.UnitTogglePanel;

            pnlOverlayUnittab.pnlSpecial.ntxtSize.Text = _pSettings.UnitPictureSize.ToString();
        }

        private void InitializeProductiontab()
        {
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveAi.Checked = _pSettings.ProdTabRemoveAi;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveAllie.Checked = _pSettings.ProdTabRemoveAllie;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveClantags.Checked = _pSettings.ProdTabRemoveClanTag;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveNeutral.Checked = _pSettings.ProdTabRemoveNeutral;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveYourself.Checked = _pSettings.ProdTabRemoveLocalplayer;
            pnlOverlayProductiontab.pnlBasics.btnSetFont.Text = _pSettings.ProdTabFontName;
            pnlOverlayProductiontab.pnlBasics.OpacityControl.tbOpacity.Value = _pSettings.ProdTabOpacity > 1.0
                ? (Int32)_pSettings.ProdTabOpacity
                : (Int32)(_pSettings.ProdTabOpacity * 100);
            pnlOverlayProductiontab.pnlBasics.aChBxDisplayBuildings.Checked = _pSettings.ProdTabShowBuildings;
            pnlOverlayProductiontab.pnlBasics.aChBxDisplayUnits.Checked = _pSettings.ProdTabShowUnits;
            pnlOverlayProductiontab.pnlBasics.aChBxDisplayUpgrades.Checked = _pSettings.ProdTabShowUpgrades;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveChronoboost.Checked = _pSettings.ProdTabRemoveChronoboost;
            pnlOverlayProductiontab.pnlBasics.aChBxSplitUnitsBuildings.Checked = _pSettings.ProdTabSplitUnitsAndBuildings;
            pnlOverlayProductiontab.pnlBasics.aChBxTransparentImages.Checked = _pSettings.ProdTabUseTransparentImages;


            pnlOverlayProductiontab.pnlLauncher.ktxtHotkey1.Text = _pSettings.ProdHotkey1.ToString();
            pnlOverlayProductiontab.pnlLauncher.ktxtHotkey2.Text = _pSettings.ProdHotkey2.ToString();
            pnlOverlayProductiontab.pnlLauncher.ktxtHotkey3.Text = _pSettings.ProdHotkey3.ToString();

            pnlOverlayProductiontab.pnlLauncher.txtReposition.Text = _pSettings.ProdChangePositionPanel;
            pnlOverlayProductiontab.pnlLauncher.txtResize.Text = _pSettings.ProdChangeSizePanel;
            pnlOverlayProductiontab.pnlLauncher.txtToggle.Text = _pSettings.ProdTogglePanel;

            pnlOverlayProductiontab.pnlSpecial.ntxtSize.Text = _pSettings.ProdPictureSize.ToString();
        }

        #endregion

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


            pnlDebug.Visible = true;
            foreach (var pnl in pnlMainArea.Controls)
            {
                if (pnl == pnlDebug)
                    continue;

                if (pnl.GetType() == typeof(Panel))
                {
                    ((Panel)pnl).Visible = false;
                }
            }
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

                ((UserControl)pnl).Visible = false;
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

                ((UserControl)pnl).Visible = false;
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

                ((UserControl)pnl).Visible = false;
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

                ((UserControl)pnl).Visible = false;
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

                ((UserControl)pnl).Visible = false;
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

                ((UserControl)pnl).Visible = false;
            }
        }

        private void cpnlOverlaysUnits_Click(object sender, EventArgs e)
        {
            pnlOverlayUnittab.Visible = true;

            foreach (var pnl in pnlOverlays.Controls)
            {
                if (pnl == pnlPanelContainer ||
                    pnl == pnlOverlayUnittab)
                    continue;

                ((UserControl)pnl).Visible = false;
            }
        }

        private void cpnlOverlaysProduction_Click(object sender, EventArgs e)
        {
            pnlOverlayProductiontab.Visible = true;

            foreach (var pnl in pnlOverlays.Controls)
            {
                if (pnl == pnlPanelContainer ||
                    pnl == pnlOverlayProductiontab)
                    continue;

                ((UserControl)pnl).Visible = false;
            }
        }

        private void btnDebugPlayerBack_Click(object sender, EventArgs e)
        {
            if (IDebugPlayerIndex > 0)
                IDebugPlayerIndex -= 1;
        }

        private void btnDebugPlayerForward_Click(object sender, EventArgs e)
        {
            if (Gameinfo.Player != null &&
                IDebugPlayerIndex < Gameinfo.Player.Count - 1)
                IDebugPlayerIndex += 1;
        }
    }

    
}
