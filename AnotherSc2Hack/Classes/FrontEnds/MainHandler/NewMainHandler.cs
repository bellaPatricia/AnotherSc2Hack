using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.BackEnds.Gameinfo;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;
using AnotherSc2Hack.Classes.FrontEnds.Container;
using AnotherSc2Hack.Classes.FrontEnds.Rendering;
using PluginInterface;
using Predefined;
using Timer = System.Windows.Forms.Timer;

namespace AnotherSc2Hack.Classes.FrontEnds.MainHandler
{
    public partial class NewMainHandler : Form
    {
        public Preferences PSettings { get; private set; }
        private readonly Timer _tmrMainTick = new Timer();
        
        private readonly RendererContainer _lContainer = new RendererContainer();
        private readonly List<AppDomain> _lPluginContainer = new List<AppDomain>();
        private readonly List<LocalPlugins> _lPlugins = new List<LocalPlugins>();
        private readonly List<OnlinePlugin> _lOnlinePlugins = new List<OnlinePlugin>();
        private readonly WebClient _wcMainWebClient = new WebClient();

        private Boolean _bProcessSet;

        public Process PSc2Process { get; set; }

        #region Getter and setter with advanced codeexecution

        private Int32 _iPluginsSelectedPluginIndex = -1;
        private Int32 IPluginsSelectedPluginIndex
        {
            get { return _iPluginsSelectedPluginIndex; }
            set
            {
                _iPluginsSelectedPluginIndex = value;

                rtbPluginsDescription.Enabled = true;
                btnPluginsImagesPrevious.Enabled = false;
                if (_lOnlinePlugins[_iPluginsSelectedPluginIndex].ImageLinks.Count <= 1)
                    btnPluginsImagesNext.Enabled = false;
                else
                    btnPluginsImagesNext.Enabled = true;

            }
        }

        private Int32 _iPluginsImageIndex;
        private Int32 IPluginsImageIndex
        {
            get { return _iPluginsImageIndex; }
            set
            {
                _iPluginsImageIndex = value;

                if (_lOnlinePlugins.Count > 0)
                {
                    lblPluginsImageposition.Text = (_iPluginsImageIndex + 1) + "/" + (_lOnlinePlugins[IPluginsSelectedPluginIndex].Images.Count);
                    pcbPluginsImages.Image = _lOnlinePlugins[IPluginsSelectedPluginIndex].Images[_iPluginsImageIndex];

                    btnPluginsImagesPrevious.Enabled = IPluginsImageIndex > 0;
                    btnPluginsImagesNext.Enabled = IPluginsImageIndex < _lOnlinePlugins[IPluginsSelectedPluginIndex].Images.Count - 1;
                }
            }
        }

        private Int32 _iDebugPlayerIndex;
        private Int32 IDebugPlayerIndex
        {
            get { return _iDebugPlayerIndex; }
            set
            {
                _iDebugPlayerIndex = value;

                if (Gameinfo != null && Gameinfo.Player != null)
                    lblDebugPlayerLocation.Text = _iDebugPlayerIndex + "/" + (Gameinfo.Player.Count - 1);

                DebugPlayerRefresh();
            }
        }

        private Int32 _iDebugUnitIndex;
        private Int32 IDebugUnitIndex
        {
            get { return _iDebugUnitIndex; }
            set
            {
                _iDebugUnitIndex = value;

                if (Gameinfo != null && Gameinfo.Unit != null)
                    lblDebugUnitLocation.Text = _iDebugUnitIndex + "/" + (Gameinfo.Unit.Count - 1);

                DebugUnitRefresh();
            }
        }

        #endregion

        public GameInfo Gameinfo { get; private set; }
        public ApplicationStartOptions ApplicationOptions { get; private set; }

        public NewMainHandler(ApplicationStartOptions app)
        {
            InitializeComponent();

            
            Init();
            ControlsFill();
            EventMapping();
            

            
            

            ApplicationOptions = app;

            Gameinfo = new GameInfo(PSettings.GlobalDataRefresh);

            //PluginsLocalLoadPlugins();
            new Thread(PluginLoadAvailablePlugins).Start();
            
        }

        private void Init()
        {
            PSettings = new Preferences();

            cpnlApplication.PerformClick();
            cpnlOverlaysResources.PerformClick();

            _tmrMainTick.Interval = PSettings.GlobalDataRefresh;
            _tmrMainTick.Tick += _tmrMainTick_Tick;
            _tmrMainTick.Enabled = true;

            _wcMainWebClient.Proxy = null;
            _wcMainWebClient.DownloadProgressChanged += _wcMainWebClient_DownloadProgressChanged;
            _wcMainWebClient.DownloadFileCompleted += _wcMainWebClient_DownloadFileCompleted;
            

            /* Add all the panels to the container... */
         /*   _lContainer.Add(new ResourcesRenderer(this));
            _lContainer.Add(new IncomeRenderer(this));
            _lContainer.Add(new WorkerRenderer(this));
            _lContainer.Add(new ArmyRenderer(this));
            _lContainer.Add(new ApmRenderer(this));
            _lContainer.Add(new MaphackRenderer(this));
            _lContainer.Add(new UnitRenderer(this));
            _lContainer.Add(new ProductionRenderer(this));
            _lContainer.Add(new PersonalApmRenderer(this));
            _lContainer.Add(new PersonalClockRenderer(this));*/

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);


        }

        void _wcMainWebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pbMainProgress.Value = 0;

            if (e.UserState.Equals("Plugin"))
            {
                PluginsLocalLoadPlugins();
            }

            Console.WriteLine("Filedownload complete!");
        }

        void _wcMainWebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pbMainProgress.Value = e.ProgressPercentage;
            Console.WriteLine("We are at the ProgressChanged!");
        }

        void _tmrMainTick_Tick(object sender, EventArgs e)
        {
            if (cpnlDebug.IsClicked)
            {
                DebugPlayerRefresh();
                DebugUnitRefresh();
                DebugMapRefresh();
                DebugMatchinformationRefresh();
            }

            PluginDataRefresh();

            #region Reset Process and gameinfo if Sc2 is not started

            if (!Processing.GetProcess(Constants.StrStarcraft2ProcessName))
            {
                ChangeVisibleState(false);
                _bProcessSet = false;
                Gameinfo.HandleThread(false);

                _tmrMainTick.Interval = 300;
                Debug.WriteLine("Process not found - 300ms Delay!");
            }


            else
            {
                if (!_bProcessSet)
                {
                    _bProcessSet = true;

                    Process proc;
                    if (Processing.GetProcess(Constants.StrStarcraft2ProcessName, out proc))
                        PSc2Process = proc;


                    if (Gameinfo == null)
                    {
                        Gameinfo = new GameInfo(PSettings.GlobalDataRefresh)
                        {
                            Of = new Offsets()
                        };
                    }

                    else if (Gameinfo != null &&
                             !Gameinfo.CThreadState)
                    {
                        Gameinfo.Memory.Handle = IntPtr.Zero;
                        Gameinfo.CStarcraft2 = PSc2Process;
                        Gameinfo.Of = new Offsets();
                        Gameinfo.HandleThread(true);
                    }


                    ChangeVisibleState(true);
                    _tmrMainTick.Interval = PSettings.GlobalDataRefresh;

                    Debug.WriteLine("Process found - " + PSettings.GlobalDataRefresh + "ms Delay!");
                }
            }

            #endregion
            
        }



        private void PluginDataRefresh()
        {
            if (_lPlugins == null || _lPlugins.Count <= 0)
                return;


            foreach (var plugin in _lPlugins)
            {
                /* Refresh some Data */
                plugin.Plugin.SetMap(Gameinfo.Map);
                plugin.Plugin.SetPlayers(Gameinfo.Player);
                plugin.Plugin.SetUnits(Gameinfo.Unit);
                plugin.Plugin.SetSelection(Gameinfo.Selection);
                plugin.Plugin.SetGroups(Gameinfo.Group);
                plugin.Plugin.SetGameinfo(Gameinfo.Gameinfo);

                /* Set Access values for Gameinfo */
                Gameinfo.CAccessPlayers |= plugin.Plugin.GetRequiresPlayer();
                Gameinfo.CAccessSelection |= plugin.Plugin.GetRequiresSelection();
                Gameinfo.CAccessUnits |= plugin.Plugin.GetRequiresUnit();
                Gameinfo.CAccessUnitCommands |= plugin.Plugin.GetRequiresUnit();
                Gameinfo.CAccessGameinfo |= plugin.Plugin.GetRequiresGameinfo();
                Gameinfo.CAccessGroups |= plugin.Plugin.GetRequiresGroups();
                Gameinfo.CAccessMapInfo |= plugin.Plugin.GetRequiresMap();
            }
        }

        #region Side - Clickable Panels

        #region Event methods

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

        private void cpnlPlugins_Click(object sender, EventArgs e)
        {
            lblTabname.Text = "Plugins";

            pnlPlugins.Visible = true;
            foreach (var pnl in pnlMainArea.Controls)
            {
                if (pnl == pnlPlugins)
                    continue;

                if (pnl.GetType() == typeof(Panel))
                {
                    ((Panel)pnl).Visible = false;
                }
            }
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

        #endregion

        #endregion

        #region Application Panel Data

        #region Event methods

        private void ntxtMemoryRefresh_NumberChanged(NumberTextBox o, EventNumber e)
        {
            if (o.Number == 0)
            {
                o.Number = 1;
                o.Select(1, 0);
                return;
            }

            PSettings.GlobalDataRefresh = o.Number;
        }

        private void ntxtGraphicsRefresh_NumberChanged(NumberTextBox o, EventNumber e)
        {
            if (o.Number == 0)
            {
                o.Number = 1;
                o.Select(1, 0);
                return;
            }

            PSettings.GlobalDrawingRefresh = o.Number;
        }

        void ktxtReposition_KeyChanged(KeyTextBox o, EventKey e)
        {
            PSettings.GlobalChangeSizeAndPosition = o.HotKeyValue;
        }

        private void chBxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.GlobalLanguage = chBxLanguage.SelectedItem.ToString();
        }

        private void btnReposition_Click(object sender, EventArgs e)
        {
            var tmpPreferences = PSettings;

            HelpFunctions.InitResolution(ref tmpPreferences);
            PSettings = tmpPreferences;
        }

        #endregion

        #endregion

        #region Overlays Panel Data

        private void EventMappingResource()
        {
            pnlOverlayResource.pnlBasics.aChBxDrawBackground.CheckedChanged += aChBxOverlaysDrawBackground_CheckedChanged;
            pnlOverlayResource.pnlBasics.aChBxRemoveAi.CheckedChanged += aChBxOverlaysRemoveAi_CheckedChanged;
            pnlOverlayResource.pnlBasics.aChBxRemoveAllie.CheckedChanged += aChBxOverlaysRemoveAllie_CheckedChanged;
            pnlOverlayResource.pnlBasics.aChBxRemoveClantags.CheckedChanged += aChBxOverlaysRemoveClantags_CheckedChanged;
            pnlOverlayResource.pnlBasics.aChBxRemoveNeutral.CheckedChanged += aChBxOverlaysRemoveNeutral_CheckedChanged;
            pnlOverlayResource.pnlBasics.aChBxRemoveYourself.CheckedChanged += aChBxOverlaysRemoveYourself_CheckedChanged;
            pnlOverlayResource.pnlBasics.btnSetFont.Click += btnOverlaysSetFont_Click;
            pnlOverlayResource.pnlBasics.OpacityControl.ValueChanged += ocOverlaysOpacity_ValueChanged;

            pnlOverlayResource.pnlLauncher.ktxtHotkey1.KeyChanged += ktxtOverlaysHotkey1_KeyChanged;
            pnlOverlayResource.pnlLauncher.ktxtHotkey2.KeyChanged += ktxtOverlaysHotkey2_KeyChanged;
            pnlOverlayResource.pnlLauncher.ktxtHotkey3.KeyChanged += ktxtOverlaysHotkey3_KeyChanged;
            pnlOverlayResource.pnlLauncher.txtReposition.TextChanged += txtOverlaysReposition_TextChanged;
            pnlOverlayResource.pnlLauncher.txtResize.TextChanged += txtOverlaysResize_TextChanged;
            pnlOverlayResource.pnlLauncher.txtToggle.TextChanged += txtOverlaysToggle_TextChanged;
        }

        private void EventMappingIncome()
        {
            pnlOverlayIncome.pnlBasics.aChBxDrawBackground.CheckedChanged += aChBxOverlaysDrawBackground_CheckedChanged;
            pnlOverlayIncome.pnlBasics.aChBxRemoveAi.CheckedChanged += aChBxOverlaysRemoveAi_CheckedChanged;
            pnlOverlayIncome.pnlBasics.aChBxRemoveAllie.CheckedChanged += aChBxOverlaysRemoveAllie_CheckedChanged;
            pnlOverlayIncome.pnlBasics.aChBxRemoveClantags.CheckedChanged += aChBxOverlaysRemoveClantags_CheckedChanged;
            pnlOverlayIncome.pnlBasics.aChBxRemoveNeutral.CheckedChanged += aChBxOverlaysRemoveNeutral_CheckedChanged;
            pnlOverlayIncome.pnlBasics.aChBxRemoveYourself.CheckedChanged += aChBxOverlaysRemoveYourself_CheckedChanged;
            pnlOverlayIncome.pnlBasics.btnSetFont.Click += btnOverlaysSetFont_Click;
            pnlOverlayIncome.pnlBasics.OpacityControl.ValueChanged += ocOverlaysOpacity_ValueChanged;

            pnlOverlayIncome.pnlLauncher.ktxtHotkey1.KeyChanged += ktxtOverlaysHotkey1_KeyChanged;
            pnlOverlayIncome.pnlLauncher.ktxtHotkey2.KeyChanged += ktxtOverlaysHotkey2_KeyChanged;
            pnlOverlayIncome.pnlLauncher.ktxtHotkey3.KeyChanged += ktxtOverlaysHotkey3_KeyChanged;
            pnlOverlayIncome.pnlLauncher.txtReposition.TextChanged += txtOverlaysReposition_TextChanged;
            pnlOverlayIncome.pnlLauncher.txtResize.TextChanged += txtOverlaysResize_TextChanged;
            pnlOverlayIncome.pnlLauncher.txtToggle.TextChanged += txtOverlaysToggle_TextChanged;
        }

        private void EventMappingWorker()
        {
            pnlOverlayWorker.aChBxDrawBackground.CheckedChanged += aChBxOverlaysDrawBackground_CheckedChanged;
            pnlOverlayWorker.btnSetFont.Click += btnOverlaysSetFont_Click;
            pnlOverlayWorker.OpacityControl.ValueChanged += ocOverlaysOpacity_ValueChanged;

            pnlOverlayWorker.pnlLauncher.ktxtHotkey1.KeyChanged += ktxtOverlaysHotkey1_KeyChanged;
            pnlOverlayWorker.pnlLauncher.ktxtHotkey2.KeyChanged += ktxtOverlaysHotkey2_KeyChanged;
            pnlOverlayWorker.pnlLauncher.ktxtHotkey3.KeyChanged += ktxtOverlaysHotkey3_KeyChanged;
            pnlOverlayWorker.pnlLauncher.txtReposition.TextChanged += txtOverlaysReposition_TextChanged;
            pnlOverlayWorker.pnlLauncher.txtResize.TextChanged += txtOverlaysResize_TextChanged;
            pnlOverlayWorker.pnlLauncher.txtToggle.TextChanged += txtOverlaysToggle_TextChanged;
        }

        private void EventMappingApm()
        {
            pnlOverlayApm.pnlBasics.aChBxDrawBackground.CheckedChanged += aChBxOverlaysDrawBackground_CheckedChanged;
            pnlOverlayApm.pnlBasics.aChBxRemoveAi.CheckedChanged += aChBxOverlaysRemoveAi_CheckedChanged;
            pnlOverlayApm.pnlBasics.aChBxRemoveAllie.CheckedChanged += aChBxOverlaysRemoveAllie_CheckedChanged;
            pnlOverlayApm.pnlBasics.aChBxRemoveClantags.CheckedChanged += aChBxOverlaysRemoveClantags_CheckedChanged;
            pnlOverlayApm.pnlBasics.aChBxRemoveNeutral.CheckedChanged += aChBxOverlaysRemoveNeutral_CheckedChanged;
            pnlOverlayApm.pnlBasics.aChBxRemoveYourself.CheckedChanged += aChBxOverlaysRemoveYourself_CheckedChanged;
            pnlOverlayApm.pnlBasics.btnSetFont.Click += btnOverlaysSetFont_Click;
            pnlOverlayApm.pnlBasics.OpacityControl.ValueChanged += ocOverlaysOpacity_ValueChanged;

            pnlOverlayApm.pnlLauncher.ktxtHotkey1.KeyChanged += ktxtOverlaysHotkey1_KeyChanged;
            pnlOverlayApm.pnlLauncher.ktxtHotkey2.KeyChanged += ktxtOverlaysHotkey2_KeyChanged;
            pnlOverlayApm.pnlLauncher.ktxtHotkey3.KeyChanged += ktxtOverlaysHotkey3_KeyChanged;
            pnlOverlayApm.pnlLauncher.txtReposition.TextChanged += txtOverlaysReposition_TextChanged;
            pnlOverlayApm.pnlLauncher.txtResize.TextChanged += txtOverlaysResize_TextChanged;
            pnlOverlayApm.pnlLauncher.txtToggle.TextChanged += txtOverlaysToggle_TextChanged;
        }

        private void EventMappingArmy()
        {
            pnlOverlayArmy.pnlBasics.aChBxDrawBackground.CheckedChanged += aChBxOverlaysDrawBackground_CheckedChanged;
            pnlOverlayArmy.pnlBasics.aChBxRemoveAi.CheckedChanged += aChBxOverlaysRemoveAi_CheckedChanged;
            pnlOverlayArmy.pnlBasics.aChBxRemoveAllie.CheckedChanged += aChBxOverlaysRemoveAllie_CheckedChanged;
            pnlOverlayArmy.pnlBasics.aChBxRemoveClantags.CheckedChanged += aChBxOverlaysRemoveClantags_CheckedChanged;
            pnlOverlayArmy.pnlBasics.aChBxRemoveNeutral.CheckedChanged += aChBxOverlaysRemoveNeutral_CheckedChanged;
            pnlOverlayArmy.pnlBasics.aChBxRemoveYourself.CheckedChanged += aChBxOverlaysRemoveYourself_CheckedChanged;
            pnlOverlayArmy.pnlBasics.btnSetFont.Click += btnOverlaysSetFont_Click;
            pnlOverlayArmy.pnlBasics.OpacityControl.ValueChanged += ocOverlaysOpacity_ValueChanged;

            pnlOverlayArmy.pnlLauncher.ktxtHotkey1.KeyChanged += ktxtOverlaysHotkey1_KeyChanged;
            pnlOverlayArmy.pnlLauncher.ktxtHotkey2.KeyChanged += ktxtOverlaysHotkey2_KeyChanged;
            pnlOverlayArmy.pnlLauncher.ktxtHotkey3.KeyChanged += ktxtOverlaysHotkey3_KeyChanged;
            pnlOverlayArmy.pnlLauncher.txtReposition.TextChanged += txtOverlaysReposition_TextChanged;
            pnlOverlayArmy.pnlLauncher.txtResize.TextChanged += txtOverlaysResize_TextChanged;
            pnlOverlayArmy.pnlLauncher.txtToggle.TextChanged += txtOverlaysToggle_TextChanged;
        }

        private void EventMappingMaphack()
        {
            pnlOverlayMaphack.pnlBasics.aChBxRemoveAi.CheckedChanged += aChBxOverlaysRemoveAi_CheckedChanged;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveAllie.CheckedChanged += aChBxOverlaysRemoveAllie_CheckedChanged;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveNeutral.CheckedChanged += aChBxOverlaysRemoveNeutral_CheckedChanged;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveYourself.CheckedChanged += aChBxOverlaysRemoveYourself_CheckedChanged;
            pnlOverlayMaphack.pnlBasics.OpacityControl.ValueChanged += ocOverlaysOpacity_ValueChanged;
            pnlOverlayMaphack.pnlBasics.aChBxDefensiveStructures.CheckedChanged += aChBxOverlaysDefensiveStructures_CheckedChanged;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveCamera.CheckedChanged += aChBxOverlaysRemoveCamera_CheckedChanged;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveDestinationLine.CheckedChanged += aChBxOverlaysRemoveDestinationLine_CheckedChanged;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveVisionArea.CheckedChanged += aChBxOverlaysRemoveVisionArea_CheckedChanged;
            pnlOverlayMaphack.pnlBasics.btnColorDestinationline.Click += btnOverlaysColorDestinationline_Click;

            pnlOverlayMaphack.pnlLauncher.ktxtHotkey1.KeyChanged += ktxtOverlaysHotkey1_KeyChanged;
            pnlOverlayMaphack.pnlLauncher.ktxtHotkey2.KeyChanged += ktxtOverlaysHotkey2_KeyChanged;
            pnlOverlayMaphack.pnlLauncher.ktxtHotkey3.KeyChanged += ktxtOverlaysHotkey3_KeyChanged;
            pnlOverlayMaphack.pnlLauncher.txtReposition.TextChanged += txtOverlaysReposition_TextChanged;
            pnlOverlayMaphack.pnlLauncher.txtResize.TextChanged += txtOverlaysResize_TextChanged;
            pnlOverlayMaphack.pnlLauncher.txtToggle.TextChanged += txtOverlaysToggle_TextChanged;
        }

        private void EventMappingUnittab()
        {
            pnlOverlayUnittab.pnlBasics.aChBxRemoveAi.CheckedChanged += aChBxOverlaysRemoveAi_CheckedChanged;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveAllie.CheckedChanged += aChBxOverlaysRemoveAllie_CheckedChanged;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveClantags.CheckedChanged += aChBxOverlaysRemoveClantags_CheckedChanged;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveNeutral.CheckedChanged += aChBxOverlaysRemoveNeutral_CheckedChanged;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveYourself.CheckedChanged += aChBxOverlaysRemoveYourself_CheckedChanged;
            pnlOverlayUnittab.pnlBasics.aChBxDisplayUnits.CheckedChanged += aChBxOverlaysDisplayUnits_CheckedChanged;
            pnlOverlayUnittab.pnlBasics.aChBxDisplayBuildings.CheckedChanged += aChBxOverlaysDisplayBuildings_CheckedChanged;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveChronoboost.CheckedChanged += aChBxOverlaysRemoveChronoboost_CheckedChanged;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveProductionstatus.CheckedChanged += aChBxOverlaysRemoveProductionstatus_CheckedChanged;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveSpellcounter.CheckedChanged += aChBxOverlaysRemoveSpellcounter_CheckedChanged;
            pnlOverlayUnittab.pnlBasics.aChBxSplitUnitsBuildings.CheckedChanged += aChBxOverlaysSplitUnitsBuildings_CheckedChanged;
            pnlOverlayUnittab.pnlBasics.aChBxTransparentImages.CheckedChanged += aChBxOverlaysTransparentImages_CheckedChanged;
            pnlOverlayUnittab.pnlBasics.btnSetFont.Click += btnOverlaysSetFont_Click;
            pnlOverlayUnittab.pnlBasics.OpacityControl.ValueChanged += ocOverlaysOpacity_ValueChanged;

            pnlOverlayUnittab.pnlLauncher.ktxtHotkey1.KeyChanged += ktxtOverlaysHotkey1_KeyChanged;
            pnlOverlayUnittab.pnlLauncher.ktxtHotkey2.KeyChanged += ktxtOverlaysHotkey2_KeyChanged;
            pnlOverlayUnittab.pnlLauncher.ktxtHotkey3.KeyChanged += ktxtOverlaysHotkey3_KeyChanged;
            pnlOverlayUnittab.pnlLauncher.txtReposition.TextChanged += txtOverlaysReposition_TextChanged;
            pnlOverlayUnittab.pnlLauncher.txtResize.TextChanged += txtOverlaysResize_TextChanged;
            pnlOverlayUnittab.pnlLauncher.txtToggle.TextChanged += txtOverlaysToggle_TextChanged;

            pnlOverlayUnittab.pnlSpecial.ntxtSize.NumberChanged += ntxtOverlaysSize_NumberChanged;
        }

        private void EventMappingProductiontab()
        {
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveAi.CheckedChanged += aChBxOverlaysRemoveAi_CheckedChanged;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveAllie.CheckedChanged += aChBxOverlaysRemoveAllie_CheckedChanged;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveClantags.CheckedChanged += aChBxOverlaysRemoveClantags_CheckedChanged;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveNeutral.CheckedChanged += aChBxOverlaysRemoveNeutral_CheckedChanged;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveYourself.CheckedChanged += aChBxOverlaysRemoveYourself_CheckedChanged;
            pnlOverlayProductiontab.pnlBasics.aChBxDisplayUnits.CheckedChanged += aChBxOverlaysDisplayUnits_CheckedChanged;
            pnlOverlayProductiontab.pnlBasics.aChBxDisplayBuildings.CheckedChanged += aChBxOverlaysDisplayBuildings_CheckedChanged;
            pnlOverlayProductiontab.pnlBasics.aChBxDisplayUpgrades.CheckedChanged += aChBxOverlaysDisplayUpgrades_CheckedChanged;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveChronoboost.CheckedChanged += aChBxOverlaysRemoveChronoboost_CheckedChanged;
            pnlOverlayProductiontab.pnlBasics.aChBxSplitUnitsBuildings.CheckedChanged += aChBxOverlaysSplitUnitsBuildings_CheckedChanged;
            pnlOverlayProductiontab.pnlBasics.aChBxTransparentImages.CheckedChanged += aChBxOverlaysTransparentImages_CheckedChanged;
            pnlOverlayProductiontab.pnlBasics.btnSetFont.Click += btnOverlaysSetFont_Click;
            pnlOverlayProductiontab.pnlBasics.OpacityControl.ValueChanged += ocOverlaysOpacity_ValueChanged;

            pnlOverlayProductiontab.pnlLauncher.ktxtHotkey1.KeyChanged += ktxtOverlaysHotkey1_KeyChanged;
            pnlOverlayProductiontab.pnlLauncher.ktxtHotkey2.KeyChanged += ktxtOverlaysHotkey2_KeyChanged;
            pnlOverlayProductiontab.pnlLauncher.ktxtHotkey3.KeyChanged += ktxtOverlaysHotkey3_KeyChanged;
            pnlOverlayProductiontab.pnlLauncher.txtReposition.TextChanged += txtOverlaysReposition_TextChanged;
            pnlOverlayProductiontab.pnlLauncher.txtResize.TextChanged += txtOverlaysResize_TextChanged;
            pnlOverlayProductiontab.pnlLauncher.txtToggle.TextChanged += txtOverlaysToggle_TextChanged;

            pnlOverlayProductiontab.pnlSpecial.ntxtSize.NumberChanged += ntxtOverlaysSize_NumberChanged;
        }

        private void EventMapping()
        {
            EventMappingApm();
            EventMappingArmy();
            EventMappingIncome();
            EventMappingMaphack();
            EventMappingProductiontab();
            EventMappingResource();
            EventMappingUnittab();
            EventMappingWorker();
        }

        #region Global Event methods

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

        #endregion

        #region Event- methods

        #region Overlays

        void txtOverlaysToggle_TextChanged(object sender, EventArgs e)
        {
            var senda = (TextBox)sender;

            var parent = HelpFunctions.findParentByName(senda, "pnlOverlays");
            if (parent.Name.Contains("Resource"))
                PSettings.ResourceTogglePanel = senda.Text;

            else if (parent.Name.Contains("Income"))
                PSettings.IncomeTogglePanel = senda.Text;

            else if (parent.Name.Contains("Worker"))
                PSettings.WorkerTogglePanel = senda.Text;

            else if (parent.Name.Contains("Apm"))
                PSettings.ApmTogglePanel = senda.Text;

            else if (parent.Name.Contains("Army"))
                PSettings.ArmyTogglePanel = senda.Text;

            else if (parent.Name.Contains("Maphack"))
                PSettings.MaphackTogglePanel = senda.Text;

            else if (parent.Name.Contains("Production"))
                PSettings.ProdTogglePanel = senda.Text;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitTogglePanel = senda.Text;

            else
                Messages.Show("Couldn't find parent!");
        }

        void txtOverlaysResize_TextChanged(object sender, EventArgs e)
        {
            var senda = (TextBox)sender;

            var parent = HelpFunctions.findParentByName(senda, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.ResourceChangeSizePanel = senda.Text;

            else if (parent.Name.Contains("Income"))
                PSettings.IncomeChangeSizePanel = senda.Text;

            else if (parent.Name.Contains("Worker"))
                PSettings.WorkerChangeSizePanel = senda.Text;

            else if (parent.Name.Contains("Apm"))
                PSettings.ApmChangeSizePanel = senda.Text;

            else if (parent.Name.Contains("Army"))
                PSettings.ArmyChangeSizePanel = senda.Text;

            else if (parent.Name.Contains("Maphack"))
                PSettings.MaphackChangeSizePanel = senda.Text;

            else if (parent.Name.Contains("Production"))
                PSettings.ProdChangeSizePanel = senda.Text;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitChangeSizePanel = senda.Text;

            else
                Messages.Show("Couldn't find parent!");
        }

        void txtOverlaysReposition_TextChanged(object sender, EventArgs e)
        {
            var senda = (TextBox)sender;

            var parent = HelpFunctions.findParentByName(senda, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.ResourceChangePositionPanel = senda.Text;

            else if (parent.Name.Contains("Income"))
                PSettings.IncomeChangePositionPanel = senda.Text;

            else if (parent.Name.Contains("Worker"))
                PSettings.WorkerChangePositionPanel = senda.Text;

            else if (parent.Name.Contains("Apm"))
                PSettings.ApmChangePositionPanel = senda.Text;

            else if (parent.Name.Contains("Army"))
                PSettings.ArmyChangePositionPanel = senda.Text;

            else if (parent.Name.Contains("Maphack"))
                PSettings.MaphackChangePositionPanel = senda.Text;

            else if (parent.Name.Contains("Production"))
                PSettings.ProdChangePositionPanel = senda.Text;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitChangePositionPanel = senda.Text;

            else
                Messages.Show("Couldn't find parent!");
        }

        void ktxtOverlaysHotkey3_KeyChanged(KeyTextBox o, EventKey e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.ResourceHotkey3 = o.HotKeyValue;

            else if (parent.Name.Contains("Income"))
                PSettings.IncomeHotkey3 = o.HotKeyValue;

            else if (parent.Name.Contains("Worker"))
                PSettings.WorkerHotkey3 = o.HotKeyValue;

            else if (parent.Name.Contains("Apm"))
                PSettings.ApmHotkey3 = o.HotKeyValue;

            else if (parent.Name.Contains("Army"))
                PSettings.ArmyHotkey3 = o.HotKeyValue;

            else if (parent.Name.Contains("Maphack"))
                PSettings.MaphackHotkey3 = o.HotKeyValue;

            else if (parent.Name.Contains("Production"))
                PSettings.ProdHotkey3 = o.HotKeyValue;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitHotkey3 = o.HotKeyValue;

            else
                Messages.Show("Couldn't find parent!");
        }

        void ktxtOverlaysHotkey2_KeyChanged(KeyTextBox o, EventKey e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.ResourceHotkey2 = o.HotKeyValue;

            else if (parent.Name.Contains("Income"))
                PSettings.IncomeHotkey2 = o.HotKeyValue;

            else if (parent.Name.Contains("Worker"))
                PSettings.WorkerHotkey2 = o.HotKeyValue;

            else if (parent.Name.Contains("Apm"))
                PSettings.ApmHotkey2 = o.HotKeyValue;

            else if (parent.Name.Contains("Army"))
                PSettings.ArmyHotkey2 = o.HotKeyValue;

            else if (parent.Name.Contains("Maphack"))
                PSettings.MaphackHotkey2 = o.HotKeyValue;

            else if (parent.Name.Contains("Production"))
                PSettings.ProdHotkey2 = o.HotKeyValue;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitHotkey2 = o.HotKeyValue;

            else
                Messages.Show("Couldn't find parent!");
        }

        void ktxtOverlaysHotkey1_KeyChanged(KeyTextBox o, EventKey e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.ResourceHotkey1 = o.HotKeyValue;

            else if (parent.Name.Contains("Income"))
                PSettings.IncomeHotkey1 = o.HotKeyValue;

            else if (parent.Name.Contains("Worker"))
                PSettings.WorkerHotkey1 = o.HotKeyValue;

            else if (parent.Name.Contains("Apm"))
                PSettings.ApmHotkey1 = o.HotKeyValue;

            else if (parent.Name.Contains("Army"))
                PSettings.ArmyHotkey1 = o.HotKeyValue;

            else if (parent.Name.Contains("Maphack"))
                PSettings.MaphackHotkey1 = o.HotKeyValue;

            else if (parent.Name.Contains("Production"))
                PSettings.ProdHotkey1 = o.HotKeyValue;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitHotkey1 = o.HotKeyValue;

            else
                Messages.Show("Couldn't find parent!");
        }

        void ocOverlaysOpacity_ValueChanged(UiOpacityControl uiOpacityControl, EventNumber eventNumber)
        {
            var parent = HelpFunctions.findParentByName(uiOpacityControl, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.ResourceOpacity = (float)uiOpacityControl.Number / 100;

            else if (parent.Name.Contains("Income"))
                PSettings.IncomeOpacity = (float)uiOpacityControl.Number / 100;

            else if (parent.Name.Contains("Worker"))
                PSettings.WorkerOpacity = (float)uiOpacityControl.Number / 100;

            else if (parent.Name.Contains("Apm"))
                PSettings.ApmOpacity = (float)uiOpacityControl.Number / 100;

            else if (parent.Name.Contains("Army"))
                PSettings.ArmyOpacity = (float)uiOpacityControl.Number / 100;

            else if (parent.Name.Contains("Maphack"))
                PSettings.MaphackOpacity = (float)uiOpacityControl.Number / 100;

            else if (parent.Name.Contains("Production"))
                PSettings.ProdTabOpacity = (float)uiOpacityControl.Number / 100;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitTabOpacity = (float)uiOpacityControl.Number / 100;

            else
                Messages.Show("Couldn't find parent!");
        }

        void btnOverlaysSetFont_Click(object sender, EventArgs e)
        {
            var ftDialog = new FontDialog();
            ftDialog.ShowDialog();

            var senda = ((Control) sender);
            var parent = HelpFunctions.findParentByName(senda, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.ResourceFontName = ftDialog.Font.Name;

            else if (parent.Name.Contains("Income"))
                PSettings.IncomeFontName = ftDialog.Font.Name;

            else if (parent.Name.Contains("Worker"))
                PSettings.WorkerFontName = ftDialog.Font.Name;

            else if (parent.Name.Contains("Apm"))
                PSettings.ApmFontName = ftDialog.Font.Name;

            else if (parent.Name.Contains("Army"))
                PSettings.ArmyFontName = ftDialog.Font.Name;

            else if (parent.Name.Contains("Production"))
                PSettings.ProdTabFontName = ftDialog.Font.Name;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitTabFontName = ftDialog.Font.Name;

            else 
                Messages.Show("Couldn't find parent!");

            senda.Text = ftDialog.Font.Name;
        }

        void aChBxOverlaysRemoveYourself_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.ResourceRemoveLocalplayer = o.Checked;
            
            else if (parent.Name.Contains("Income"))
                PSettings.IncomeRemoveLocalplayer = o.Checked;

            else if (parent.Name.Contains("Apm"))
                PSettings.ApmRemoveLocalplayer = o.Checked;

            else if (parent.Name.Contains("Army"))
                PSettings.ArmyRemoveLocalplayer = o.Checked;

            else if (parent.Name.Contains("Maphack"))
                PSettings.MaphackRemoveLocalplayer = o.Checked;

            else if (parent.Name.Contains("Production"))
                PSettings.ProdTabRemoveLocalplayer = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitTabRemoveLocalplayer = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysRemoveNeutral_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.ResourceRemoveNeutral = o.Checked;

            else if (parent.Name.Contains("Income"))
                PSettings.IncomeRemoveNeutral = o.Checked;

            else if (parent.Name.Contains("Apm"))
                PSettings.ApmRemoveNeutral = o.Checked;

            else if (parent.Name.Contains("Army"))
                PSettings.ArmyRemoveNeutral = o.Checked;

            else if (parent.Name.Contains("Maphack"))
                PSettings.MaphackRemoveNeutral = o.Checked;

            else if (parent.Name.Contains("Production"))
                PSettings.ProdTabRemoveNeutral = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitTabRemoveNeutral = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysRemoveClantags_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.ResourceRemoveClanTag = o.Checked;

            else if (parent.Name.Contains("Income"))
                PSettings.IncomeRemoveClanTag = o.Checked;

            else if (parent.Name.Contains("Apm"))
                PSettings.ApmRemoveClanTag = o.Checked;

            else if (parent.Name.Contains("Army"))
                PSettings.ArmyRemoveClanTag = o.Checked;

            else if (parent.Name.Contains("Production"))
                PSettings.ProdTabRemoveClanTag = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitTabRemoveClanTag = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysRemoveAllie_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.ResourceRemoveAllie = o.Checked;

            else if (parent.Name.Contains("Income"))
                PSettings.IncomeRemoveAllie = o.Checked;

            else if (parent.Name.Contains("Apm"))
                PSettings.ApmRemoveAllie = o.Checked;

            else if (parent.Name.Contains("Army"))
                PSettings.ArmyRemoveAllie = o.Checked;

            else if (parent.Name.Contains("Maphack"))
                PSettings.MaphackRemoveAllie = o.Checked;

            else if (parent.Name.Contains("Production"))
                PSettings.ProdTabRemoveAllie = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitTabRemoveAllie = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysRemoveAi_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.ResourceRemoveAi = o.Checked;

            else if (parent.Name.Contains("Income"))
                PSettings.IncomeRemoveAi = o.Checked;

            else if (parent.Name.Contains("Apm"))
                PSettings.ApmRemoveAi = o.Checked;

            else if (parent.Name.Contains("Army"))
                PSettings.ArmyRemoveAi = o.Checked;

            else if (parent.Name.Contains("Maphack"))
                PSettings.MaphackRemoveAi = o.Checked;

            else if (parent.Name.Contains("Production"))
                PSettings.ProdTabRemoveAi = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitTabRemoveAi = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysDrawBackground_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.ResourceDrawBackground = o.Checked;

            else if (parent.Name.Contains("Income"))
                PSettings.IncomeDrawBackground = o.Checked;

            else if (parent.Name.Contains("Apm"))
                PSettings.ApmDrawBackground = o.Checked;

            else if (parent.Name.Contains("Army"))
                PSettings.ArmyDrawBackground = o.Checked;

            else if (parent.Name.Contains("Worker"))
                PSettings.WorkerDrawBackground = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void ntxtOverlaysSize_NumberChanged(NumberTextBox o, EventNumber e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Production"))
                PSettings.ProdPictureSize = o.Number;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitPictureSize = o.Number;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysDisplayUpgrades_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.ProdTabShowUpgrades = o.Checked;
        }

        void aChBxOverlaysTransparentImages_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Production"))
                PSettings.ProdTabUseTransparentImages = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitTabUseTransparentImages = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysSplitUnitsBuildings_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Production"))
                PSettings.ProdTabSplitUnitsAndBuildings = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitTabSplitUnitsAndBuildings = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysRemoveSpellcounter_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.UnitTabRemoveSpellCounter = o.Checked;
        }

        void aChBxOverlaysRemoveProductionstatus_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.UnitTabRemoveProdLine = o.Checked;
        }

        void aChBxOverlaysRemoveChronoboost_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Production"))
                PSettings.ProdTabRemoveChronoboost = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitTabRemoveChronoboost = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysDisplayBuildings_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Production"))
                PSettings.ProdTabShowBuildings = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitTabShowBuildings = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysDisplayUnits_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Production"))
                PSettings.ProdTabShowUnits = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitTabShowUnits = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void btnOverlaysColorDestinationline_Click(object sender, EventArgs e)
        {
            var cl = new ColorDialog();
            cl.Color = Color.YellowGreen;
            cl.FullOpen = true;
            cl.ShowDialog();

            PSettings.MaphackDestinationColor = cl.Color;
            pnlOverlayMaphack.pnlBasics.btnColorDestinationline.BackColor = cl.Color;
        }

        void aChBxOverlaysRemoveVisionArea_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.MaphackRemoveVisionArea = o.Checked;
        }

        void aChBxOverlaysRemoveDestinationLine_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.MaphackDisableDestinationLine = o.Checked;
        }

        void aChBxOverlaysRemoveCamera_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.MaphackRemoveCamera = o.Checked;
        }

        void aChBxOverlaysDefensiveStructures_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.MaphackColorDefensivestructuresYellow = o.Checked;
        }

        #endregion

        #endregion

        #endregion

        #region Plugins Panel Data

        #region Load Data into listviews

        private void PluginsLocalLoadPlugins()
        {
            if (!Directory.Exists(Constants.StrPluginFolder))
                Directory.CreateDirectory(Constants.StrPluginFolder);

            var files = Directory.GetFiles(Constants.StrPluginFolder, "*.dll");

            for (var i = 0; i < files.Length; i++)
            {
                var strTempAppdomainName = "TempAppDomainNo." + i;


                var tmpAppDomain = AppDomain.CreateDomain(strTempAppdomainName);

                try
                {
                    var foo =
                        (IPlugins)
                            tmpAppDomain.CreateInstanceFromAndUnwrap(files[i], "Plugin.Extensions.AnotherSc2HackPlugin");

                    if (_lPlugins.Exists(x => x.Plugin.GetPluginName() == foo.GetPluginName()))
                       throw new TypeLoadException("Fuck you");
                    

                    _lPlugins.Add(new LocalPlugins(foo, files[i]));
                    _lPluginContainer.Add(tmpAppDomain);
                }

                catch (TypeLoadException typeEx)
                {
                    //If we are here, we couldn't load illegal .dll- files
                    //It's all good here!
                    AppDomain.Unload(tmpAppDomain);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't load plugin '" + files[i] + "'");
                }
            }

            PluginsLocalLoadedPluginsRefresh();

            //Launch Plugins
            foreach (var plugin in _lPlugins)
            {
                plugin.Plugin.StartPlugin();
            }

            //Mark Plugins "checked"
            foreach (ListViewItem item in lstvPluginsLoadedPlugins.Items)
            {
                item.Checked = true;
            }
        }

        private void PluginsLocalLoadedPluginsRefresh()
        {
            lstvPluginsLoadedPlugins.Items.Clear();
            lstvPluginsLoadedPlugins.Enabled = true;

            foreach (var plugin in _lPlugins)
            {
                var lwi = new ListViewItem();

                lwi.BackColor = lstvPluginsLoadedPlugins.Items.Count % 2 == 0 ? lwi.BackColor : Color.WhiteSmoke;
                lwi.Text = plugin.Plugin.GetPluginName();

                lwi.SubItems.Add(new ListViewItem.ListViewSubItem(lwi, plugin.Plugin.GetPluginVersion().ToString()));

                lstvPluginsLoadedPlugins.Items.Add(lwi);
            }
        }

        /// <summary>
        /// This will fetch the plugins from a webserver.
        /// That means you will be able to load plugins right away!
        /// </summary>
        private void PluginLoadAvailablePlugins()
        {
            Console.WriteLine("Worker \"PluginLoadAvailablePlugins()\" started!");

            const string strUrlPlugins = @"https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack/UpdateFiles/Plugins.txt";

            var strSource = _wcMainWebClient.DownloadString(strUrlPlugins);
            // Info: Plugin- Names start with '#'
            // Plugin- Descriptions start with '+'
            // Plugin- Downloadlinks start with '*'
            // Plugin- Pictures start with '-'
            // Plugin- Versions start with 'V'

            var strSpltted = strSource.Split('\n');
            foreach (var str in strSpltted)
            {
                if (str.StartsWith("#"))
                {
                    _lOnlinePlugins.Add(new OnlinePlugin());
                    _lOnlinePlugins[_lOnlinePlugins.Count - 1].Name = str.Substring(1).Trim();
                }

                else if (str.StartsWith("+"))
                    _lOnlinePlugins[_lOnlinePlugins.Count - 1].Description = str.Substring(1).Trim();

                else if (str.StartsWith("*"))
                    _lOnlinePlugins[_lOnlinePlugins.Count - 1].DownloadLink = str.Substring(1).Trim();

                else if (str.StartsWith("-"))
                    _lOnlinePlugins[_lOnlinePlugins.Count - 1].ImageLinks.Add(str.Substring(1).Trim());

                else if (str.StartsWith("V"))
                    _lOnlinePlugins[_lOnlinePlugins.Count - 1].Version = new Version(str.Substring(1).Trim());

                else if (str.StartsWith("@"))
                    _lOnlinePlugins[_lOnlinePlugins.Count - 1].Md5Hash = str.Substring(1).Trim();
            }

            //We have to operate cross-thread wide. So we have to create an invoker...
            MethodInvoker myInvoker = delegate
            {
                foreach (var plugin in _lOnlinePlugins)
                {
                    var lwi = new ListViewItem();

                    lwi.BackColor = lstvPluginsAvailablePlugins.Items.Count % 2 == 0 ? lwi.BackColor : Color.WhiteSmoke;
                    lwi.Text = plugin.Name;

                    lwi.SubItems.Add(new ListViewItem.ListViewSubItem(lwi, plugin.Version.ToString()));

                    lstvPluginsAvailablePlugins.Items.Add(lwi);
                }

                lstvPluginsAvailablePlugins.Enabled = true;
            };

            
            //...and invoke it here
            var bFailed = true;

            while (bFailed)
            {
                try
                {
                    //Actual invoking
                    Invoke(myInvoker);
                    bFailed = false;
                }

                catch (InvalidOperationException)
                {
                    //If this gets called, the calling thread wasn't ready yet..
                    //..and since this is a while loop, we wait a bit to not bloat everything..
                    Thread.Sleep(100);
                }

                catch
                {
                    //If we reach this point, something horrible happened.
                    Thread.Sleep(30);
                }
            }

            

            Console.WriteLine("Worker \"PluginLoadAvailablePlugins()\" finished!");
        }

        #endregion

        #region Event methods

        private void lstvPluginsLoadedPlugins_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.ItemIndex <= -1 || !e.IsSelected)
                return;

            e.Item.Checked ^= true;
        }

        private void lstvPluginsLoadedPlugins_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Index <= -1)
                return;

            if (_lPlugins.Count <= 0)
                return;

            if (e.Item.Checked)
                _lPlugins[e.Item.Index].Plugin.StartPlugin();

            else
                _lPlugins[e.Item.Index].Plugin.StopPlugin();
        }

        private void lstvPluginsAvailablePlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            var senda = ((ListView)sender);

            #region Exception handling

            if (senda.Items.Count <= 0)
                return;

            if (senda.SelectedItems.Count <= 0)
                return;

            if (senda.SelectedItems[0].Index >= senda.Items.Count)
                return;

            #endregion

            IPluginsSelectedPluginIndex = senda.SelectedItems[0].Index;

            PluginsLoadImages(senda);
        }

        private void btnPluginsImagesPrevious_Click(object sender, EventArgs e)
        {
            if (IPluginsImageIndex >= 1)
                IPluginsImageIndex -= 1;
        }

        private void btnPluginsImagesNext_Click(object sender, EventArgs e)
        {
            if (_lOnlinePlugins.Count <= 0)
                return;

            if (_lOnlinePlugins[IPluginsSelectedPluginIndex].Images.Count <= 0)
                return;

            if (IPluginsImageIndex < _lOnlinePlugins[IPluginsSelectedPluginIndex].Images.Count - 1)
                IPluginsImageIndex += 1;
        }

        private void btnPluginsInstallPlugin_Click(object sender, EventArgs e)
        {
            if (IPluginsSelectedPluginIndex < 0 ||
                _lOnlinePlugins.Count <= 0)
                return;

            if (_lPlugins.Find(x => x.Md5Hash == _lOnlinePlugins[IPluginsSelectedPluginIndex].Md5Hash) != null)
            {
                MessageBox.Show("Plugin already installed!\n\nPlease select another plugin!", "Plugin Error");
                return;
            }

            var strOnlinePath = _lOnlinePlugins[IPluginsSelectedPluginIndex].DownloadLink;
            var strLocalPath =
                _lOnlinePlugins[IPluginsSelectedPluginIndex].DownloadLink.Split('/')[
                    _lOnlinePlugins[IPluginsSelectedPluginIndex].DownloadLink.Split('/').Length - 1];

            PluginsInstallPlugin(strOnlinePath + "#" + strLocalPath);

        }

        #endregion

        private void PluginsInstallPlugin(object path)
        {
            var strOnlinePath = path.ToString().Split('#')[0];
            var strLocalPath = path.ToString().Split('#')[1];
            strLocalPath = Path.Combine(Application.StartupPath, Constants.StrPluginFolder, strLocalPath);

            try
            {
                _wcMainWebClient.DownloadFileAsync(new Uri(strOnlinePath), strLocalPath, "Plugin");
                /*_wcMainWebClient.DownloadFile(strOnlinePath,
                    Path.Combine(Application.StartupPath, Constants.StrPluginFolder, strLocalPath));*/
            }

            catch (Exception ex)
            {
                MessageBox.Show("Couldn't install Plugin!", "Something went wrong!");
            }
        }

        private void PluginsLoadImages(ListView senda)
        {
            if (_lOnlinePlugins[IPluginsSelectedPluginIndex].Images.Count > 0)
            {
                pcbPluginsImages.Image = _lOnlinePlugins[IPluginsSelectedPluginIndex].Images[0];
                IPluginsImageIndex = 0;
            }

            var onlinePlugin = _lOnlinePlugins[IPluginsSelectedPluginIndex];

            rtbPluginsDescription.Text = onlinePlugin.Description;

            //Download images if available AND they were not downloaded already!
            if (_lOnlinePlugins[IPluginsSelectedPluginIndex].Images.Count !=
                _lOnlinePlugins[IPluginsSelectedPluginIndex].ImageLinks.Count)
            {
                pbMainProgress.Style = ProgressBarStyle.Marquee;
                var context = TaskScheduler.FromCurrentSynchronizationContext();


                var task = Task.Factory.StartNew(() =>
                {
                    var token = Task.Factory.CancellationToken;


                    _lOnlinePlugins[IPluginsSelectedPluginIndex].Images.Clear();

                    for (var j = 0; j < _lOnlinePlugins[IPluginsSelectedPluginIndex].ImageLinks.Count; j++)
                    {
                        var rawImg =
                            new WebClient { Proxy = null }.DownloadData(
                                _lOnlinePlugins[IPluginsSelectedPluginIndex].ImageLinks[j]);
                        var img = HelpFunctions.ByteArrayToImage(rawImg);

                        _lOnlinePlugins[IPluginsSelectedPluginIndex].Images.Add(img);

                        Task.Factory.StartNew(() =>
                        {
                            //Refresh Imageposition
                            lblPluginsImageposition.Text = (IPluginsImageIndex + 1) + "/" +
                                                           _lOnlinePlugins[IPluginsSelectedPluginIndex].Images.Count;

                            //Load the first image into the picture- box
                            if (_lOnlinePlugins[IPluginsSelectedPluginIndex].Images.Count < 2)
                                pcbPluginsImages.Image = img;

                            if (_lOnlinePlugins[IPluginsSelectedPluginIndex].Images.Count ==
                                _lOnlinePlugins[IPluginsSelectedPluginIndex].ImageLinks.Count)
                            {
                                lstvPluginsAvailablePlugins_SelectedIndexChanged(senda, new EventArgs());

                                pbMainProgress.Style = ProgressBarStyle.Blocks;
                                senda.Enabled = true;
                            }

                        }, token, TaskCreationOptions.None, context);
                    }

                });
            }
        }

        

        #endregion

        #region Debug Panel Data

        #region Load Data into listviews

        private void DebugPlayerRefresh()
        {
            if (Gameinfo == null || Gameinfo.Player == null)
                return;

            if (IDebugPlayerIndex > Gameinfo.Player.Count)
                IDebugPlayerIndex = Gameinfo.Player.Count - 1;

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
                lstvDebugPlayderdata.Columns[lstvDebugPlayderdata.Columns.Count - 1].Width = -2;

                //Insert new ones
                foreach (PropertyDescriptor property in properties)
                {
                    var lwi = new ListViewItem();

                    lwi.BackColor = lstvDebugPlayderdata.Items.Count % 2 == 0 ? lwi.BackColor : Color.WhiteSmoke;
                    lwi.Text = property.Name;

                    lwi.SubItems.Add(new ListViewItem.ListViewSubItem(lwi, property.GetValue(player).ToString()));

                    lstvDebugPlayderdata.Items.Add(lwi);
                }

            }

            txtDebugPlayerMemory.Text = PredefinedData.PlayerStruct.ClassObjectCount.ToString();
        }

        private void DebugUnitRefresh()
        {
            if (Gameinfo == null || Gameinfo.Unit == null)
                return;

            if (IDebugUnitIndex > Gameinfo.Unit.Count)
                IDebugUnitIndex = Gameinfo.Unit.Count - 1;

            var player = Gameinfo.Unit[IDebugUnitIndex];
            var properties = TypeDescriptor.GetProperties(player);

            if (lstvDebugUnitdata.Items.Count > 0)
            {
                //Actually refresh, not insert new ones!
                for (var i = 0; i < properties.Count; i++)
                {
                    var property = properties[i];

                    lstvDebugUnitdata.Items[i].SubItems[1].Text = property.GetValue(player).ToString();
                }



            }

            else
            {
                lstvDebugUnitdata.Columns[lstvDebugUnitdata.Columns.Count - 1].Width = -2;

                //Insert new ones
                foreach (PropertyDescriptor property in properties)
                {
                    var lwi = new ListViewItem();

                    lwi.BackColor = lstvDebugUnitdata.Items.Count % 2 == 0 ? lwi.BackColor : Color.WhiteSmoke;
                    lwi.Text = property.Name;
                    lwi.SubItems.Add(new ListViewItem.ListViewSubItem(lwi, property.GetValue(player).ToString()));

                    lstvDebugUnitdata.Items.Add(lwi);
                }

            }

            txtDebugUnitMemory.Text = PredefinedData.Unit.ClassObjectCount.ToString();
        }

        private void DebugMapRefresh()
        {
            if (Gameinfo == null)
                return;

            var fields = typeof(PredefinedData.Map).GetFields(BindingFlags.Public | BindingFlags.Instance);

            if (lstvDebugMapdata.Items.Count > 0)
            {
                //Actually refresh, not insert new ones!
                for (var i = 0; i < fields.Length; i++)
                {
                    var field = fields[i];

                    lstvDebugMapdata.Items[i].SubItems[1].Text = field.GetValue(Gameinfo.Map).ToString();
                }



            }

            else
            {
                if (lstvDebugMapdata.Columns.Count > 1)
                    lstvDebugMapdata.Columns[lstvDebugMapdata.Columns.Count - 1].Width = -2;

                //Insert new ones
                foreach (var field in fields)
                {
                    var lwi = new ListViewItem();

                    lwi.BackColor = lstvDebugMapdata.Items.Count % 2 == 0 ? lwi.BackColor : Color.WhiteSmoke;
                    lwi.Text = field.Name;
                    lwi.SubItems.Add(new ListViewItem.ListViewSubItem(lwi, field.GetValue(Gameinfo.Map).ToString()));

                    lstvDebugMapdata.Items.Add(lwi);
                }

            }
        }

        private void DebugMatchinformationRefresh()
        {
            if (Gameinfo == null || Gameinfo.Gameinfo == null)
                return;

            var properties = TypeDescriptor.GetProperties(Gameinfo.Gameinfo);

            if (lstvDebugMatchdata.Items.Count > 0)
            {
                //Actually refresh, not insert new ones!
                for (var i = 0; i < properties.Count; i++)
                {
                    var property = properties[i];

                    lstvDebugMatchdata.Items[i].SubItems[1].Text = property.GetValue(Gameinfo.Gameinfo).ToString();
                }



            }

            else
            {
                lstvDebugMatchdata.Columns[lstvDebugMatchdata.Columns.Count - 1].Width = -2;

                //Insert new ones
                foreach (PropertyDescriptor property in properties)
                {
                    var lwi = new ListViewItem();

                    lwi.BackColor = lstvDebugMatchdata.Items.Count % 2 == 0 ? lwi.BackColor : Color.WhiteSmoke;
                    lwi.Text = property.Name;
                    lwi.SubItems.Add(new ListViewItem.ListViewSubItem(lwi, property.GetValue(Gameinfo.Gameinfo).ToString()));

                    lstvDebugMatchdata.Items.Add(lwi);
                }

            }
        }

        #endregion

        #region Event- methods

        private void btnDebugPlayerBack_Click(object sender, EventArgs e)
        {
            if (IDebugPlayerIndex > 0)
                IDebugPlayerIndex -= 1;
        }

        private void btnDebugPlayerForward_Click(object sender, EventArgs e)
        {
            if (Gameinfo != null &&
                Gameinfo.Player != null &&
                IDebugPlayerIndex < Gameinfo.Player.Count - 1)
                IDebugPlayerIndex += 1;
        }

        private void btnDebugUnitBack_Click(object sender, EventArgs e)
        {
            if (IDebugUnitIndex > 0)
                IDebugUnitIndex -= 1;
        }

        private void btnDebugUnitForward_Click(object sender, EventArgs e)
        {
            if (Gameinfo != null &&
                Gameinfo.Unit != null &&
                IDebugUnitIndex < Gameinfo.Unit.Count - 1)
                IDebugUnitIndex += 1;
        }

        private void ntxtDebugPlayerLocation_NumberChanged(NumberTextBox o, EventNumber e)
        {
            IDebugPlayerIndex = (Int32)e.TheNumber;
        }

        private void ntxtDebugUnitLocation_NumberChanged(NumberTextBox o, EventNumber e)
        {
            IDebugUnitIndex = (Int32)e.TheNumber;
        }

        private void txtDebugPlayername_TextChanged(object sender, EventArgs e)
        {
            if (Gameinfo == null || Gameinfo.Player == null)
                return;

            var tmpTextbox = (TextBox)sender;

            if (tmpTextbox.Text.Length <= 0)
                return;

            var pew = Gameinfo.Player.FindIndex(x => x.Name.Contains(tmpTextbox.Text));

            if (pew == -1)
                tmpTextbox.ForeColor = Color.Red;

            else
            {
                tmpTextbox.ForeColor = Color.Green;
                IDebugPlayerIndex = pew;
            }
        }

        private void txtDebugUnitname_TextChanged(object sender, EventArgs e)
        {
            if (Gameinfo == null || Gameinfo.Unit == null)
                return;

            var tmpTextbox = (TextBox)sender;

            if (tmpTextbox.Text.Length <= 0)
                return;


            var pew = Gameinfo.Unit.FindIndex(x => x.Name.Contains(tmpTextbox.Text));

            if (pew == -1)
                tmpTextbox.ForeColor = Color.Red;

            else
            {
                tmpTextbox.ForeColor = Color.Green;
                IDebugUnitIndex = pew;
            }
        }

        #endregion

        #endregion

        #region Load Settings Into Controls

        private void ControlsFill()
        {
            //Application / Global
            ntxtMemoryRefresh.Number = PSettings.GlobalDataRefresh;
            ntxtGraphicsRefresh.Number = PSettings.GlobalDrawingRefresh;
            ktxtReposition.Text = PSettings.GlobalChangeSizeAndPosition.ToString();
            chBxOnlyDrawInForeground.Checked = PSettings.GlobalDrawOnlyInForeground;
            chBxLanguage.SelectedIndex = chBxLanguage.Items.IndexOf(PSettings.GlobalLanguage) > -1
                ? chBxLanguage.Items.IndexOf(PSettings.GlobalLanguage)
                : 0;

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
            pnlOverlayResource.pnlBasics.aChBxDrawBackground.Checked = PSettings.ResourceDrawBackground;
            pnlOverlayResource.pnlBasics.aChBxRemoveAi.Checked = PSettings.ResourceRemoveAi;
            pnlOverlayResource.pnlBasics.aChBxRemoveAllie.Checked = PSettings.ResourceRemoveAllie;
            pnlOverlayResource.pnlBasics.aChBxRemoveClantags.Checked = PSettings.ResourceRemoveClanTag;
            pnlOverlayResource.pnlBasics.aChBxRemoveNeutral.Checked = PSettings.ResourceRemoveNeutral;
            pnlOverlayResource.pnlBasics.aChBxRemoveYourself.Checked = PSettings.ResourceRemoveLocalplayer;
            pnlOverlayResource.pnlBasics.btnSetFont.Text = PSettings.ResourceFontName;
            pnlOverlayResource.pnlBasics.OpacityControl.tbOpacity.Value = PSettings.ResourceOpacity > 1.0
                ? (Int32)PSettings.ResourceOpacity
                : (Int32)(PSettings.ResourceOpacity * 100);

            pnlOverlayResource.pnlLauncher.ktxtHotkey1.Text = PSettings.ResourceHotkey1.ToString();
            pnlOverlayResource.pnlLauncher.ktxtHotkey2.Text = PSettings.ResourceHotkey2.ToString();
            pnlOverlayResource.pnlLauncher.ktxtHotkey3.Text = PSettings.ResourceHotkey3.ToString();

            pnlOverlayResource.pnlLauncher.txtReposition.Text = PSettings.ResourceChangePositionPanel;
            pnlOverlayResource.pnlLauncher.txtResize.Text = PSettings.ResourceChangeSizePanel;
            pnlOverlayResource.pnlLauncher.txtToggle.Text = PSettings.ResourceTogglePanel;
        }

        private void InitializeIncome()
        {
            pnlOverlayIncome.pnlBasics.aChBxDrawBackground.Checked = PSettings.IncomeDrawBackground;
            pnlOverlayIncome.pnlBasics.aChBxRemoveAi.Checked = PSettings.IncomeRemoveAi;
            pnlOverlayIncome.pnlBasics.aChBxRemoveAllie.Checked = PSettings.IncomeRemoveAllie;
            pnlOverlayIncome.pnlBasics.aChBxRemoveClantags.Checked = PSettings.IncomeRemoveClanTag;
            pnlOverlayIncome.pnlBasics.aChBxRemoveNeutral.Checked = PSettings.IncomeRemoveNeutral;
            pnlOverlayIncome.pnlBasics.aChBxRemoveYourself.Checked = PSettings.IncomeRemoveLocalplayer;
            pnlOverlayIncome.pnlBasics.btnSetFont.Text = PSettings.IncomeFontName;
            pnlOverlayIncome.pnlBasics.OpacityControl.tbOpacity.Value = PSettings.IncomeOpacity > 1.0
                ? (Int32)PSettings.IncomeOpacity
                : (Int32)(PSettings.IncomeOpacity * 100);

            pnlOverlayIncome.pnlLauncher.ktxtHotkey1.Text = PSettings.IncomeHotkey1.ToString();
            pnlOverlayIncome.pnlLauncher.ktxtHotkey2.Text = PSettings.IncomeHotkey2.ToString();
            pnlOverlayIncome.pnlLauncher.ktxtHotkey3.Text = PSettings.IncomeHotkey3.ToString();

            pnlOverlayIncome.pnlLauncher.txtReposition.Text = PSettings.IncomeChangePositionPanel;
            pnlOverlayIncome.pnlLauncher.txtResize.Text = PSettings.IncomeChangeSizePanel;
            pnlOverlayIncome.pnlLauncher.txtToggle.Text = PSettings.IncomeTogglePanel;
        }

        private void InitializeApm()
        {
            pnlOverlayApm.pnlBasics.aChBxDrawBackground.Checked = PSettings.ApmDrawBackground;
            pnlOverlayApm.pnlBasics.aChBxRemoveAi.Checked = PSettings.ApmRemoveAi;
            pnlOverlayApm.pnlBasics.aChBxRemoveAllie.Checked = PSettings.ApmRemoveAllie;
            pnlOverlayApm.pnlBasics.aChBxRemoveClantags.Checked = PSettings.ApmRemoveClanTag;
            pnlOverlayApm.pnlBasics.aChBxRemoveNeutral.Checked = PSettings.ApmRemoveNeutral;
            pnlOverlayApm.pnlBasics.aChBxRemoveYourself.Checked = PSettings.ApmRemoveLocalplayer;
            pnlOverlayApm.pnlBasics.btnSetFont.Text = PSettings.ApmFontName;
            pnlOverlayApm.pnlBasics.OpacityControl.tbOpacity.Value = PSettings.ApmOpacity > 1.0
                ? (Int32)PSettings.ApmOpacity
                : (Int32)(PSettings.ApmOpacity * 100);

            pnlOverlayApm.pnlLauncher.ktxtHotkey1.Text = PSettings.ApmHotkey1.ToString();
            pnlOverlayApm.pnlLauncher.ktxtHotkey2.Text = PSettings.ApmHotkey2.ToString();
            pnlOverlayApm.pnlLauncher.ktxtHotkey3.Text = PSettings.ApmHotkey3.ToString();

            pnlOverlayApm.pnlLauncher.txtReposition.Text = PSettings.ApmChangePositionPanel;
            pnlOverlayApm.pnlLauncher.txtResize.Text = PSettings.ApmChangeSizePanel;
            pnlOverlayApm.pnlLauncher.txtToggle.Text = PSettings.ApmTogglePanel;
        }

        private void InitializeArmy()
        {
            pnlOverlayArmy.pnlBasics.aChBxDrawBackground.Checked = PSettings.ArmyDrawBackground;
            pnlOverlayArmy.pnlBasics.aChBxRemoveAi.Checked = PSettings.ArmyRemoveAi;
            pnlOverlayArmy.pnlBasics.aChBxRemoveAllie.Checked = PSettings.ArmyRemoveAllie;
            pnlOverlayArmy.pnlBasics.aChBxRemoveClantags.Checked = PSettings.ArmyRemoveClanTag;
            pnlOverlayArmy.pnlBasics.aChBxRemoveNeutral.Checked = PSettings.ArmyRemoveNeutral;
            pnlOverlayArmy.pnlBasics.aChBxRemoveYourself.Checked = PSettings.ArmyRemoveLocalplayer;
            pnlOverlayArmy.pnlBasics.btnSetFont.Text = PSettings.ArmyFontName;
            pnlOverlayArmy.pnlBasics.OpacityControl.tbOpacity.Value = PSettings.ArmyOpacity > 1.0
                ? (Int32)PSettings.ArmyOpacity
                : (Int32)(PSettings.ArmyOpacity * 100);

            pnlOverlayArmy.pnlLauncher.ktxtHotkey1.Text = PSettings.ArmyHotkey1.ToString();
            pnlOverlayArmy.pnlLauncher.ktxtHotkey2.Text = PSettings.ArmyHotkey2.ToString();
            pnlOverlayArmy.pnlLauncher.ktxtHotkey3.Text = PSettings.ArmyHotkey3.ToString();

            pnlOverlayArmy.pnlLauncher.txtReposition.Text = PSettings.ArmyChangePositionPanel;
            pnlOverlayArmy.pnlLauncher.txtResize.Text = PSettings.ArmyChangeSizePanel;
            pnlOverlayArmy.pnlLauncher.txtToggle.Text = PSettings.ArmyTogglePanel;
        }

        private void InitializeMaphack()
        {
            pnlOverlayMaphack.pnlBasics.aChBxRemoveAi.Checked = PSettings.MaphackRemoveAi;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveAllie.Checked = PSettings.MaphackRemoveAllie;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveNeutral.Checked = PSettings.MaphackRemoveNeutral;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveYourself.Checked = PSettings.MaphackRemoveLocalplayer;
            pnlOverlayMaphack.pnlBasics.OpacityControl.tbOpacity.Value = PSettings.MaphackOpacity > 1.0
                ? (Int32)PSettings.MaphackOpacity
                : (Int32)(PSettings.MaphackOpacity * 100);
            pnlOverlayMaphack.pnlBasics.aChBxDefensiveStructures.Checked =
                PSettings.MaphackColorDefensivestructuresYellow;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveCamera.Checked = PSettings.MaphackRemoveCamera;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveVisionArea.Checked = PSettings.MaphackRemoveVisionArea;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveDestinationLine.Checked = PSettings.MaphackDisableDestinationLine;
            pnlOverlayMaphack.pnlBasics.btnColorDestinationline.BackColor = PSettings.MaphackDestinationColor;

            pnlOverlayMaphack.pnlLauncher.ktxtHotkey1.Text = PSettings.MaphackHotkey1.ToString();
            pnlOverlayMaphack.pnlLauncher.ktxtHotkey2.Text = PSettings.MaphackHotkey2.ToString();
            pnlOverlayMaphack.pnlLauncher.ktxtHotkey3.Text = PSettings.MaphackHotkey3.ToString();

            pnlOverlayMaphack.pnlLauncher.txtReposition.Text = PSettings.MaphackChangePositionPanel;
            pnlOverlayMaphack.pnlLauncher.txtResize.Text = PSettings.MaphackChangeSizePanel;
            pnlOverlayMaphack.pnlLauncher.txtToggle.Text = PSettings.MaphackTogglePanel;
        }

        private void InitializeWorker()
        {
            pnlOverlayWorker.aChBxDrawBackground.Checked = PSettings.WorkerDrawBackground;
            pnlOverlayWorker.btnSetFont.Text = PSettings.WorkerFontName;
            pnlOverlayWorker.OpacityControl.tbOpacity.Value = PSettings.WorkerOpacity > 1.0
                ? (Int32)PSettings.WorkerOpacity
                : (Int32)(PSettings.WorkerOpacity * 100);

            pnlOverlayWorker.pnlLauncher.ktxtHotkey1.Text = PSettings.WorkerHotkey1.ToString();
            pnlOverlayWorker.pnlLauncher.ktxtHotkey2.Text = PSettings.WorkerHotkey2.ToString();
            pnlOverlayWorker.pnlLauncher.ktxtHotkey3.Text = PSettings.WorkerHotkey3.ToString();

            pnlOverlayWorker.pnlLauncher.txtReposition.Text = PSettings.WorkerChangePositionPanel;
            pnlOverlayWorker.pnlLauncher.txtResize.Text = PSettings.WorkerChangeSizePanel;
            pnlOverlayWorker.pnlLauncher.txtToggle.Text = PSettings.WorkerTogglePanel;
        }

        private void InitializeUnittab()
        {
            pnlOverlayUnittab.pnlBasics.aChBxRemoveAi.Checked = PSettings.UnitTabRemoveAi;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveAllie.Checked = PSettings.UnitTabRemoveAllie;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveClantags.Checked = PSettings.UnitTabRemoveClanTag;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveNeutral.Checked = PSettings.UnitTabRemoveNeutral;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveYourself.Checked = PSettings.UnitTabRemoveLocalplayer;
            pnlOverlayUnittab.pnlBasics.btnSetFont.Text = PSettings.UnitTabFontName;
            pnlOverlayUnittab.pnlBasics.OpacityControl.tbOpacity.Value = PSettings.UnitTabOpacity > 1.0
                ? (Int32)PSettings.UnitTabOpacity
                : (Int32)(PSettings.UnitTabOpacity * 100);
            pnlOverlayUnittab.pnlBasics.aChBxDisplayBuildings.Checked = PSettings.UnitTabShowBuildings;
            pnlOverlayUnittab.pnlBasics.aChBxDisplayUnits.Checked = PSettings.UnitTabShowUnits;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveChronoboost.Checked = PSettings.UnitTabRemoveChronoboost;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveProductionstatus.Checked = PSettings.UnitTabRemoveProdLine;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveSpellcounter.Checked = PSettings.UnitTabRemoveSpellCounter;
            pnlOverlayUnittab.pnlBasics.aChBxSplitUnitsBuildings.Checked = PSettings.UnitTabSplitUnitsAndBuildings;
            pnlOverlayUnittab.pnlBasics.aChBxTransparentImages.Checked = PSettings.UnitTabUseTransparentImages;
            

            pnlOverlayUnittab.pnlLauncher.ktxtHotkey1.Text = PSettings.UnitHotkey1.ToString();
            pnlOverlayUnittab.pnlLauncher.ktxtHotkey2.Text = PSettings.UnitHotkey2.ToString();
            pnlOverlayUnittab.pnlLauncher.ktxtHotkey3.Text = PSettings.UnitHotkey3.ToString();

            pnlOverlayUnittab.pnlLauncher.txtReposition.Text = PSettings.UnitChangePositionPanel;
            pnlOverlayUnittab.pnlLauncher.txtResize.Text = PSettings.UnitChangeSizePanel;
            pnlOverlayUnittab.pnlLauncher.txtToggle.Text = PSettings.UnitTogglePanel;

            pnlOverlayUnittab.pnlSpecial.ntxtSize.Text = PSettings.UnitPictureSize.ToString();
        }

        private void InitializeProductiontab()
        {
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveAi.Checked = PSettings.ProdTabRemoveAi;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveAllie.Checked = PSettings.ProdTabRemoveAllie;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveClantags.Checked = PSettings.ProdTabRemoveClanTag;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveNeutral.Checked = PSettings.ProdTabRemoveNeutral;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveYourself.Checked = PSettings.ProdTabRemoveLocalplayer;
            pnlOverlayProductiontab.pnlBasics.btnSetFont.Text = PSettings.ProdTabFontName;
            pnlOverlayProductiontab.pnlBasics.OpacityControl.tbOpacity.Value = PSettings.ProdTabOpacity > 1.0
                ? (Int32)PSettings.ProdTabOpacity
                : (Int32)(PSettings.ProdTabOpacity * 100);
            pnlOverlayProductiontab.pnlBasics.aChBxDisplayBuildings.Checked = PSettings.ProdTabShowBuildings;
            pnlOverlayProductiontab.pnlBasics.aChBxDisplayUnits.Checked = PSettings.ProdTabShowUnits;
            pnlOverlayProductiontab.pnlBasics.aChBxDisplayUpgrades.Checked = PSettings.ProdTabShowUpgrades;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveChronoboost.Checked = PSettings.ProdTabRemoveChronoboost;
            pnlOverlayProductiontab.pnlBasics.aChBxSplitUnitsBuildings.Checked = PSettings.ProdTabSplitUnitsAndBuildings;
            pnlOverlayProductiontab.pnlBasics.aChBxTransparentImages.Checked = PSettings.ProdTabUseTransparentImages;


            pnlOverlayProductiontab.pnlLauncher.ktxtHotkey1.Text = PSettings.ProdHotkey1.ToString();
            pnlOverlayProductiontab.pnlLauncher.ktxtHotkey2.Text = PSettings.ProdHotkey2.ToString();
            pnlOverlayProductiontab.pnlLauncher.ktxtHotkey3.Text = PSettings.ProdHotkey3.ToString();

            pnlOverlayProductiontab.pnlLauncher.txtReposition.Text = PSettings.ProdChangePositionPanel;
            pnlOverlayProductiontab.pnlLauncher.txtResize.Text = PSettings.ProdChangeSizePanel;
            pnlOverlayProductiontab.pnlLauncher.txtToggle.Text = PSettings.ProdTogglePanel;

            pnlOverlayProductiontab.pnlSpecial.ntxtSize.Text = PSettings.ProdPictureSize.ToString();
        }

        #endregion


        /* Make panels in/ visible */
        private void ChangeVisibleState(Boolean state)
        {
            foreach (var renderer in _lContainer)
            {
                if (!renderer.IsHidden)
                    renderer.Visible = state;
            }
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


        //Draw a new border on the top and bottom of the panel
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var send = (Panel)sender;

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, 0, Width, 0);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, send.Height - 1, Width, send.Height - 1);
        }

        private void chBxOnlyDrawInForeground_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.GlobalDrawOnlyInForeground = o.Checked;
        }

        private void NewMainHandler_FormClosing(object sender, FormClosingEventArgs e)
        {
            PSettings.WritePreferences();

            foreach (var plugin in _lPlugins)
            {
                plugin.Plugin.StopPlugin();
            }

            foreach (var appDomain in _lPluginContainer)
            {
                AppDomain.Unload(appDomain);
            }

            _tmrMainTick.Enabled = false;
            Gameinfo.HandleThread(false);
        }

        private void btnLaunchResource_Click(object sender, EventArgs e)
        {

        }

        private void btnLaunchIncome_Click(object sender, EventArgs e)
        {

        }

        private void btnLaunchWorker_Click(object sender, EventArgs e)
        {

        }

        private void btnLaunchMaphack_Click(object sender, EventArgs e)
        {

        }

        private void btnLaunchApm_Click(object sender, EventArgs e)
        {

        }

        private void btnLaunchArmy_Click(object sender, EventArgs e)
        {

        }

        private void btnLaunchUnit_Click(object sender, EventArgs e)
        {

        }

        private void btnLaunchProduction_Click(object sender, EventArgs e)
        {

        }
    }

   

    
}
