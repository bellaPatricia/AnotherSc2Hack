using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Plugin;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;
using AnotherSc2Hack.Classes.FrontEnds.Rendering;
using AnotherSc2Hack.Properties;
using PluginInterface;
using PredefinedTypes;
using UpdateChecker;
using Utilities.Events;
using Utilities.Logger;
using Utilities.VariousClasses.Hashes;
using Timer = System.Windows.Forms.Timer;
using _ = Utilities.InfoManager.InfoManager;

namespace AnotherSc2Hack.Classes.FrontEnds.MainHandler
{
    public partial class NewMainHandler : Form
    {
        #region Private Variables

        private readonly Timer _tmrMainTick = new Timer();
        
        private readonly RendererContainer _lContainer = new RendererContainer();
        private readonly List<AppDomain> _lPluginContainer = new List<AppDomain>();
        private readonly List<LocalPlugins> _lPlugins = new List<LocalPlugins>();
        private readonly List<OnlinePlugin> _lOnlinePlugins = new List<OnlinePlugin>();
        private readonly List<PluginDatastore> _lPluginDatastores = new List<PluginDatastore>(); 
        private readonly WebClient _wcMainWebClient = new WebClient();
        private DateTime _dtSecond = DateTime.Now;
        private readonly Dictionary<string, string> _dictLanguageFile = new Dictionary<string, string>();
        private readonly DownloadManager _ucDownloadManager = new DownloadManager();
        private string _strUpdateFiles = String.Empty;
        private bool _bLaunchDownloadManager;
        private bool _bAdjustPanels;

        #region LanguageString

        private readonly LanguageString _lstrChCreditsContributer = new LanguageString("lstrChCreditsContributer", "Contributor");
        private readonly LanguageString _lstrChCreditsReason = new LanguageString("lstrChCreditsReason", "But.. why?");
        private readonly LanguageString _lstrChPluginsPluginName = new LanguageString("lstrChPluginsPluginName", "Plugin");
        private readonly LanguageString _lstrChPluginsPluginVersion = new LanguageString("lstrChPluginsPluginVersion", "Version");
        private readonly LanguageString _lstrChDebugAttribute = new LanguageString("lstrChDebugAttribute", "Attribute");
        private readonly LanguageString _lstrChDebugValue = new LanguageString("lstrChDebugValue", "Value");

        private readonly LanguageString _lstrCreditsReasonRhcp = new LanguageString("lstrCreditsReasonRhcp", "Open Source MH, Gameinteraction, Minimap drawing and extremely helpful");
        private readonly LanguageString _lstrCreditsReasonBeaving = new LanguageString("lstrCreditsReasonBeaving", "Various hacking information, Concepts, Suggestions and good chats");
        private readonly LanguageString _lstrCreditsReasonMrnukealizer = new LanguageString("lstrCreditsReasonMrnukealizer", "Open Source MH, Ideas and concepts");
        private readonly LanguageString _lstrCreditsReasonMyteewun = new LanguageString("lstrCreditsReasonMyteewun", "Production-Tag (Unit and Upgrades) and good research in SC2 memory");
        private readonly LanguageString _lstrCreditsReasonMischa = new LanguageString("lstrCreditsReasonMischa", "Great SC2 memory research with Upgrades, production and unitlists");
        private readonly LanguageString _lstrCreditsReasonMrice = new LanguageString("lstrCreditsReasonMrice", "Graphical help");
        private readonly LanguageString _lstrCreditsReasonTracky = new LanguageString("lstrCreditsReasonTracky", "Suggestions and ideas");
        private readonly LanguageString _lstrCreditsReasonD3Scene = new LanguageString("lstrCreditsReasonD3Scene", "Good environment with a lot helpful people");
        private readonly LanguageString _lstrCreditsReasonVariousPeople = new LanguageString("lstrCreditsReasonVariousPeople", "...that gave ideas, suggestions and critism - thank you!");
        private readonly LanguageString _lstrCreditsReasonDonators = new LanguageString("lstrCreditsReasonDonators", "Because you people make me buy some candy :3");
        private readonly LanguageString _lstrCreditsTranslators = new LanguageString("lstrCreditsTranslators", "kk321010 (Chinese), ironer1 (Korean), B.T. (French), O.Ж. (Russian)");

        private readonly LanguageString _lstrApplicationRestoreSettingsText = new LanguageString("lstrApplicationRestoreSettingsText", "Do you really want to reset your settings?");
        private readonly LanguageString _lstrApplicationRestoreSettingsHeader = new LanguageString("lstrApplicationRestoreSettingsHeader", "Are you sure?");
        private readonly LanguageString _lstrApplicationRestorePanelPositionText = new LanguageString("lstrApplicationRestorePanelPositionText", "Panel's size and position\nwere adjusted successfully!");
        private readonly LanguageString _lstrApplicationRestorePanelPositionHeader = new LanguageString("lstrApplicationRestorePanelPositionHeader", "Panelposition changed!");
        private readonly LanguageString _lstrApplicationUpdateTitle = new LanguageString("lstrApplicationUpdateTitle", "Updates available!");
        private readonly LanguageString _lstrApplicationDoYouWishToUpdate = new LanguageString("lstrApplicationDoYouWishToUpdate", "Do you wish to update?");

        private readonly LanguageString _lstrPluginContextInstallPlugin = new LanguageString("lstrPluginContextInstallPlugin", "Install plugin");
        private readonly LanguageString _lstrPluginContextRemovePlugin = new LanguageString("lstrPluginContextRemovePlugin", "Remove plugin");

        



        #endregion

        #endregion

        #region Getter and setter with advanced codeexecution

        private PreferenceManager _pSettings = new PreferenceManager();

        public PreferenceManager PSettings
        {
            get { return _pSettings; }
            set
            {
                _pSettings = value;
                foreach (var renderer in _lContainer)
                {
                    renderer.PSettings = _pSettings;
                }
            }
        }

        private GameInfo _gameinfo;

        public GameInfo Gameinfo
        {
            get
            {
                return _gameinfo;
            }

            set
            {
                _gameinfo = value;

                foreach (var renderer in _lContainer)
                {
                    renderer.GInformation = _gameinfo;
                }
            }
        }

        private Process _pSc2Process = null;

        public Process PSc2Process
        {
            get
            {
                return _pSc2Process;
            }
            set
            {
                _pSc2Process = value;
                foreach (var renderer in _lContainer)
                {
                    renderer.PSc2Process = _pSc2Process;
                }
            }
        }

        #region GUI getter and setter

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

        #endregion

        #region Constructors

        public NewMainHandler()
        {
            

            _.Info("Initialize The UI", _.InfoImportance.VeryImportant);

            InitializeComponent();

            Gameinfo = new GameInfo();
            Gameinfo.CSleepTime = PSettings.PreferenceAll.Global.DataRefresh;
            Gameinfo.IterationPerSecondChanged += Gameinfo_IterationPerSecondChanged;
            Gameinfo.ProcessFound += Gameinfo_ProcessFound;
            
            Init();
            OverlaysEventMapping();
            LanguageStringEventMapping();
            ControlsFill();
            
            

            PluginsLocalLoadPlugins();
            
            LoadContributers();
            LaunchOnStartup();

            _.Info("UI Initialization Successful", _.InfoImportance.VeryImportant);
        }

      

        #endregion

        #region Delegates to handle multithreaded UI calls

        private delegate void ShowAvailableUpdatesDelegate();

        private delegate void CheckWebbrowserUrlDelegate(string strUrl);

        #endregion

        private void Init()
        {
            _.Info("Initialize UI Classes and Renderer", _.InfoImportance.Important);

            PSettings = new PreferenceManager();

            //Find clickable Panel and perform click
            ClickablePanel.Instances.Find(x => x.Name == PSettings.PreferenceAll.Global.ApplicationLastOpenedPanel).PerformClick();
            cpnlOverlaysResources.PerformClick();

            _tmrMainTick.Interval = PSettings.PreferenceAll.Global.DataRefresh;
            _tmrMainTick.Tick += _tmrMainTick_Tick;
            _tmrMainTick.Enabled = true;

            _wcMainWebClient.Proxy = null;
            _wcMainWebClient.DownloadProgressChanged += _wcMainWebClient_DownloadProgressChanged;
            _wcMainWebClient.DownloadFileCompleted += _wcMainWebClient_DownloadFileCompleted;

            _ucDownloadManager.UpdateAvailable += _ucDownloadManager_UpdateAvailable;
            _ucDownloadManager.CheckComplete += _ucDownloadManager_CheckComplete;
            _ucDownloadManager.DownloadManagerUpdateRequired += _ucDownloadManager_DownloadManagerUpdateRequired;
            _ucDownloadManager.CheckUpdates();
            


            /* Add all the panels to the container... */
            _lContainer.Add(new ResourcesRenderer(Gameinfo, PSettings, PSc2Process));
            _lContainer.Add(new IncomeRenderer(Gameinfo, PSettings, PSc2Process));
            _lContainer.Add(new WorkerRenderer(Gameinfo, PSettings, PSc2Process));
            _lContainer.Add(new ArmyRenderer(Gameinfo, PSettings, PSc2Process));
            _lContainer.Add(new ApmRenderer(Gameinfo, PSettings, PSc2Process));
            _lContainer.Add(new MaphackRenderer(Gameinfo, PSettings, PSc2Process));
            _lContainer.Add(new UnitRenderer(Gameinfo, PSettings, PSc2Process));
            _lContainer.Add(new ProductionRenderer(Gameinfo, PSettings, PSc2Process));
            _lContainer.Add(new PersonalApmRenderer(Gameinfo, PSettings, PSc2Process));
            _lContainer.Add(new PersonalClockRenderer(Gameinfo, PSettings, PSc2Process));
            _lContainer.Add(new WorkerCoachRenderer(Gameinfo, PSettings, PSc2Process));
            _lContainer.Add(new AlertRenderer(Gameinfo, PSettings, PSc2Process));

            BaseRendererEventMapping();

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
        }

        /// <summary>
        /// This method will handle the input for the overlays and other callable things.
        /// This supports button_click events, Keypresses (GetAsyncKeyState) and chat-input
        /// <param name="clickButton">The Button- object you want to pass. Leave this to null if you don't have a button!</param>
        /// <param name="e">The standard EventArgs object. Leave this to null</param>
        /// </summary>
        private void InputManager(object clickButton = null, EventArgs e = null)
        {
            //Button
            if (clickButton != null)
            {
                if (clickButton.Equals(btnLaunchResource))
                    LaunchRendererWithButton(clickButton, typeof (ResourcesRenderer));

                else if (clickButton.Equals(btnLaunchIncome))
                    LaunchRendererWithButton(clickButton, typeof (IncomeRenderer));

                else if (clickButton.Equals(btnLaunchArmy))
                    LaunchRendererWithButton(clickButton, typeof (ArmyRenderer));

                else if (clickButton.Equals(btnLaunchApm))
                    LaunchRendererWithButton(clickButton, typeof (ApmRenderer));

                else if (clickButton.Equals(btnLaunchWorker))
                    LaunchRendererWithButton(clickButton, typeof (WorkerRenderer));

                else if (clickButton.Equals(btnLaunchMaphack))
                    LaunchRendererWithButton(clickButton, typeof (MaphackRenderer));

                else if (clickButton.Equals(btnLaunchUnit))
                    LaunchRendererWithButton(clickButton, typeof (UnitRenderer));

                else if (clickButton.Equals(btnLaunchProduction))
                    LaunchRendererWithButton(clickButton, typeof (ProductionRenderer));
            }

            else
            {
                LaunchPanels();
            }
        }

        /// <summary>
        /// Launches the panel(s) if they are calles
        /// Supports the hotkey combination and the chatbox in the game
        /// </summary>
        private void LaunchPanels()
        {
            if (Gameinfo.Gameinfo == null)
                return;

            var strInput = Gameinfo.Gameinfo.ChatInput;

            if (String.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));


            foreach (var renderer in _lContainer)
            {
                if (renderer is ResourcesRenderer)
                {
                    if (HelpFunctions.HotkeysPressed(PSettings.PreferenceAll.OverlayResources.Hotkey1,
                        PSettings.PreferenceAll.OverlayResources.Hotkey2,
                        PSettings.PreferenceAll.OverlayResources.Hotkey3))
                        renderer.ToggleShowHide();


                    else if (strInput.Equals(PSettings.PreferenceAll.OverlayResources.TogglePanel))
                    {
                        renderer.ToggleShowHide();

                        Simulation.Keyboard.Keyboard_SimulateKey(PSc2Process.MainWindowHandle, Keys.Enter, 1);
                    }

                    btnLaunchResource.ForeColor = renderer.IsHidden ? Color.Red : Color.Green;
                }

                else if (renderer is IncomeRenderer)
                {
                    if (HelpFunctions.HotkeysPressed(PSettings.PreferenceAll.OverlayIncome.Hotkey1,
                        PSettings.PreferenceAll.OverlayIncome.Hotkey2,
                        PSettings.PreferenceAll.OverlayIncome.Hotkey3))
                        renderer.ToggleShowHide();


                    else if (strInput.Equals(PSettings.PreferenceAll.OverlayIncome.TogglePanel))
                    {
                        renderer.ToggleShowHide();

                        Simulation.Keyboard.Keyboard_SimulateKey(PSc2Process.MainWindowHandle, Keys.Enter, 1);
                    }

                    btnLaunchIncome.ForeColor = renderer.IsHidden ? Color.Red : Color.Green;
                }

                else if (renderer is WorkerRenderer)
                {
                    if (HelpFunctions.HotkeysPressed(PSettings.PreferenceAll.OverlayWorker.Hotkey1,
                        PSettings.PreferenceAll.OverlayWorker.Hotkey2,
                        PSettings.PreferenceAll.OverlayWorker.Hotkey3))
                        renderer.ToggleShowHide();


                    else if (strInput.Equals(PSettings.PreferenceAll.OverlayWorker.TogglePanel))
                    {
                        renderer.ToggleShowHide();

                        Simulation.Keyboard.Keyboard_SimulateKey(PSc2Process.MainWindowHandle, Keys.Enter, 1);
                    }

                    btnLaunchWorker.ForeColor = renderer.IsHidden ? Color.Red : Color.Green;
                }

                else if (renderer is ApmRenderer)
                {
                    if (HelpFunctions.HotkeysPressed(PSettings.PreferenceAll.OverlayApm.Hotkey1,
                        PSettings.PreferenceAll.OverlayApm.Hotkey2,
                        PSettings.PreferenceAll.OverlayApm.Hotkey3))
                        renderer.ToggleShowHide();


                    else if (strInput.Equals(PSettings.PreferenceAll.OverlayApm.TogglePanel))
                    {
                        renderer.ToggleShowHide();

                        Simulation.Keyboard.Keyboard_SimulateKey(PSc2Process.MainWindowHandle, Keys.Enter, 1);
                    }

                    btnLaunchApm.ForeColor = renderer.IsHidden ? Color.Red : Color.Green;
                }

                else if (renderer is ArmyRenderer)
                {
                    if (HelpFunctions.HotkeysPressed(PSettings.PreferenceAll.OverlayArmy.Hotkey1,
                        PSettings.PreferenceAll.OverlayArmy.Hotkey2,
                        PSettings.PreferenceAll.OverlayArmy.Hotkey3))
                        renderer.ToggleShowHide();


                    else if (strInput.Equals(PSettings.PreferenceAll.OverlayArmy.TogglePanel))
                    {
                        renderer.ToggleShowHide();

                        Simulation.Keyboard.Keyboard_SimulateKey(PSc2Process.MainWindowHandle, Keys.Enter, 1);
                    }

                    btnLaunchArmy.ForeColor = renderer.IsHidden ? Color.Red : Color.Green;
                }

                else if (renderer is MaphackRenderer)
                {
                    if (HelpFunctions.HotkeysPressed(PSettings.PreferenceAll.OverlayMaphack.Hotkey1,
                        PSettings.PreferenceAll.OverlayMaphack.Hotkey2,
                        PSettings.PreferenceAll.OverlayMaphack.Hotkey3))
                        renderer.ToggleShowHide();


                    else if (strInput.Equals(PSettings.PreferenceAll.OverlayMaphack.TogglePanel))
                    {
                        renderer.ToggleShowHide();

                        Simulation.Keyboard.Keyboard_SimulateKey(PSc2Process.MainWindowHandle, Keys.Enter, 1);
                    }

                    btnLaunchMaphack.ForeColor = renderer.IsHidden ? Color.Red : Color.Green;
                }

                else if (renderer is UnitRenderer)
                {
                    if (HelpFunctions.HotkeysPressed(PSettings.PreferenceAll.OverlayUnits.Hotkey1,
                        PSettings.PreferenceAll.OverlayUnits.Hotkey2,
                        PSettings.PreferenceAll.OverlayUnits.Hotkey3))
                        renderer.ToggleShowHide();


                    else if (strInput.Equals(PSettings.PreferenceAll.OverlayUnits.TogglePanel))
                    {
                        renderer.ToggleShowHide();

                        Simulation.Keyboard.Keyboard_SimulateKey(PSc2Process.MainWindowHandle, Keys.Enter, 1);
                    }

                    btnLaunchUnit.ForeColor = renderer.IsHidden ? Color.Red : Color.Green;
                }

                else if (renderer is ProductionRenderer)
                {
                    if (HelpFunctions.HotkeysPressed(PSettings.PreferenceAll.OverlayProduction.Hotkey1,
                        PSettings.PreferenceAll.OverlayProduction.Hotkey2,
                        PSettings.PreferenceAll.OverlayProduction.Hotkey3))
                        renderer.ToggleShowHide();


                    else if (strInput.Equals(PSettings.PreferenceAll.OverlayProduction.TogglePanel))
                    {
                        renderer.ToggleShowHide();

                        Simulation.Keyboard.Keyboard_SimulateKey(PSc2Process.MainWindowHandle, Keys.Enter, 1);
                    }

                    btnLaunchProduction.ForeColor = renderer.IsHidden ? Color.Red : Color.Green;
                }
            }
        }

        /// <summary>
        /// Make Panels visible (or invisible)
        /// </summary>
        /// <param name="state">Visibility state</param>
        private void ChangeVisibleState(Boolean state)
        {
            foreach (var renderer in _lContainer)
            {
                if (!renderer.IsHidden)
                    renderer.Visible = state;
            }
        }
       
        #region Side - Clickable Panels

        #region Event methods

        private void cpnl_Click(object sender, EventArgs e)
        {
            var panel = sender as ClickablePanel;
            if (panel != null)
            {
                PSettings.PreferenceAll.Global.ApplicationLastOpenedPanel = panel.Name;
                lblTabname.Text = panel.DisplayText;

                if (panel.SettingsPanel != null)
                    panel.SettingsPanel.Visible = true;


                foreach (var pnl in pnlMainArea.Controls)
                {
                    if (pnl == panel.SettingsPanel)
                        continue;

                    if (pnl.GetType() == typeof(Panel))
                    {
                        ((Panel)pnl).Visible = false;
                    }
                }
            }
        }

        #endregion

        #endregion

        private void LanguageStringEventMapping()
        {
            _lstrChCreditsContributer.TextChanged += _lstrChCreditsContributer_TextChanged;
            _lstrChCreditsReason.TextChanged += _lstrChCreditsReason_TextChanged;

            _lstrChPluginsPluginName.TextChanged += _lstrChPluginsPluginName_TextChanged;
            _lstrChPluginsPluginVersion.TextChanged += _lstrChPluginsPluginVersion_TextChanged;

            _lstrChDebugAttribute.TextChanged += _lstrChDebugAttribute_TextChanged;
            _lstrChDebugValue.TextChanged += _lstrChDebugValue_TextChanged;

            _lstrPluginContextRemovePlugin.TextChanged += _lstrPluginContextRemovePlugin_TextChanged;
            _lstrPluginContextInstallPlugin.TextChanged += _lstrPluginContextInstallPlugin_TextChanged;
        }

        #region Application Panel Data

        private void LaunchRendererWithButton(object clickButton, Type targetType)
        {
            var button = clickButton as Button;
            if (button != null)
            {
                var btn = button;
                foreach (var renderer in _lContainer)
                {
                    if (renderer.GetType() == targetType)
                    {
                        renderer.ToggleShowHide();
                        btn.ForeColor = renderer.IsHidden ? Color.Red : Color.Green;
                    }
                }
            }

            else
                throw new Exception("You passed something that isn't a button!");
        }

        private void LaunchRenderer(Type targetType)
        {
            foreach (var renderer in _lContainer)
            {
                if (renderer.GetType() == targetType)
                {
                    renderer.ToggleShowHide();
                }
            }
        }

        private void ShowAvailableUpdates()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ShowAvailableUpdatesDelegate(ShowAvailableUpdates));
                return;
            }

            var result = new AnotherMessageBox().Show(_strUpdateFiles + "\n" + _lstrApplicationDoYouWishToUpdate, _lstrApplicationUpdateTitle.Text, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (File.Exists(Constants.StrDownloadManager))
                {
                    _bLaunchDownloadManager = true;
                    Close();
                }
            }

            _strUpdateFiles = String.Empty;
        }

        #region Event methods

        private void btnAdjustPanels_Click(object sender, EventArgs e)
        {
            _bAdjustPanels ^= true;

            btnAdjustPanels.ForeColor = _bAdjustPanels ? Color.ForestGreen : Color.Red;
            TogglePanelBorders();
        }

        private void ntxtMemoryRefresh_NumberChanged(object sender, NumberArgs e)
        {
            var o = sender as NumberTextBox;
            if (o == null)
                return;

            if (o.Number == 0)
            {
                o.Number = 1;
                o.Select(1, 0);
                return;
            }

            PSettings.PreferenceAll.Global.DataRefresh = o.Number;

            Gameinfo.CSleepTime = o.Number;
            ntxtBenchmarkDataInterval.Number = o.Number;
        }

        private void ntxtGraphicsRefresh_NumberChanged(object sender, NumberArgs e)
        {
            var o = sender as NumberTextBox;
            if (o == null)
                return;

            if (o.Number == 0)
            {
                o.Number = 1;
                o.Select(1, 0);
                return;
            }

            PSettings.PreferenceAll.Global.DrawingRefresh = o.Number;
            ntxtBenchmarkDrawingInterval.Number = o.Number;

            _lContainer.SetDrawingInterval(PSettings.PreferenceAll.Global.DrawingRefresh);
        }

        void ktxtReposition_KeyChanged(KeyTextBox o, EventKey e)
        {
            PSettings.PreferenceAll.Global.ChangeSizeAndPosition = o.HotKeyValue;
        }

        private void chBxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the proper language
            foreach (var keyvalue in _dictLanguageFile)
            {
                if (keyvalue.Value == chBxLanguage.SelectedItem.ToString())
                {
                    PSettings.PreferenceAll.Global.Language = keyvalue.Key;
                    break;
                }
            }
            
            //Change the language for all instances within those classes
            LanguageButton.ChangeLanguage(PSettings.PreferenceAll.Global.Language);
            LanguageLabel.ChangeLanguage(PSettings.PreferenceAll.Global.Language);
            AnotherCheckbox.ChangeLanguage(PSettings.PreferenceAll.Global.Language);
            ClickablePanel.ChangeLanguage(PSettings.PreferenceAll.Global.Language);
            LanguageString.ChangeLanguage(PSettings.PreferenceAll.Global.Language);

            //Trigger some methods manually
            LoadContributers();
        }

        private void btnReposition_Click(object sender, EventArgs e)
        {
            RestorePanelPositionAndSize();
        }

        private void chBxOnlyDrawInForeground_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.PreferenceAll.Global.DrawOnlyInForeground = o.Checked;
        }

        private void btnRestoreSettings_Click(object sender, EventArgs e)
        {
            var result = new AnotherMessageBox().Show(_lstrApplicationRestoreSettingsText.Text, _lstrApplicationRestoreSettingsHeader.Text, MessageBoxButtons.YesNo
                );

          

            if (result == DialogResult.Yes)
            {
                PSettings.Restore();
                RestorePanelPositionAndSize();
                ControlsFill();
            }
        }

        

        private void NewMainHandler_Load(object sender, EventArgs e)
        {
            if (PSettings.AskForDonation())
                cpnlHelpMe.PerformClick();
        }

        void _ucDownloadManager_DownloadManagerUpdateRequired(object sender, EventArgs e)
        {
            var dm = sender as DownloadManager;

            if (dm == null)
                return;

            dm.InstallDownloadManager();
        }

        void _ucDownloadManager_UpdateAvailable(object sender, UpdateArgs e)
        {
            _strUpdateFiles += "[" + e.UpdateName + "] " + e.OldVersion + " -> " + e.NewVersion + "\n";
        }

        void _ucDownloadManager_CheckComplete(object sender, EventArgs e)
        {
            new Thread(PluginLoadAvailablePlugins).Start();

            var dm = sender as DownloadManager;

            if (dm == null)
                return;

            if (dm.BUpdatesAvailable == UpdateState.Available)
            {
                ShowAvailableUpdates();
            }
        }

        #endregion

        #endregion

        #region Overlays Panel Data

        private void EventMappingResource()
        {
            _.Info("Map Events For Resource Events", _.InfoImportance.Important);

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
            _.Info("Map Events For Income Events", _.InfoImportance.Important);

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
            _.Info("Map Events For Worker Events", _.InfoImportance.Important);

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
            _.Info("Map Events For Apm Events", _.InfoImportance.Important);

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
            _.Info("Map Events For Army Events", _.InfoImportance.Important);

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
            _.Info("Map Events For Maphack Events", _.InfoImportance.Important);

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
            _.Info("Map Events For Unittab Events", _.InfoImportance.Important);

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
            _.Info("Map Events For Productiontab Events", _.InfoImportance.Important);

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

        private void OverlaysEventMapping()
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

        private void LaunchOnStartup()
        {
            foreach (var renderer in _lContainer)
            {
                if (renderer.GetType() == typeof(ResourcesRenderer))
                {
                    if (PSettings.PreferenceAll.OverlayResources.LaunchStatus)
                    {
                        renderer.Show();
                    }

                }

                else if (renderer.GetType() == typeof(IncomeRenderer))
                {
                    if (PSettings.PreferenceAll.OverlayIncome.LaunchStatus)
                    {
                        renderer.Show();
                    }

                }

                else if (renderer.GetType() == typeof(WorkerRenderer))
                {
                    if (PSettings.PreferenceAll.OverlayWorker.LaunchStatus)
                    {
                        renderer.Show();
                    }

                }

                else if (renderer.GetType() == typeof(ApmRenderer))
                {
                    if (PSettings.PreferenceAll.OverlayApm.LaunchStatus)
                    {
                        renderer.Show();
                    }

                }

                else if (renderer.GetType() == typeof(ArmyRenderer))
                {
                    if (PSettings.PreferenceAll.OverlayArmy.LaunchStatus)
                    {
                        renderer.Show();
                    }

                }

                else if (renderer.GetType() == typeof(MaphackRenderer))
                {
                    if (PSettings.PreferenceAll.OverlayMaphack.LaunchStatus)
                    {
                        renderer.Show();
                    }

                }

                else if (renderer.GetType() == typeof(UnitRenderer))
                {
                    if (PSettings.PreferenceAll.OverlayUnits.LaunchStatus)
                    {
                        renderer.Show();
                    }

                }

                else if (renderer.GetType() == typeof(ProductionRenderer))
                {
                    if (PSettings.PreferenceAll.OverlayProduction.LaunchStatus)
                    {
                        renderer.Show();
                    }

                }
            }
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
                PSettings.PreferenceAll.OverlayResources.TogglePanel = senda.Text;

            else if (parent.Name.Contains("Income"))
                PSettings.PreferenceAll.OverlayIncome.TogglePanel = senda.Text;

            else if (parent.Name.Contains("Worker"))
                PSettings.PreferenceAll.OverlayWorker.TogglePanel = senda.Text;

            else if (parent.Name.Contains("Apm"))
                PSettings.PreferenceAll.OverlayApm.TogglePanel = senda.Text;

            else if (parent.Name.Contains("Army"))
                PSettings.PreferenceAll.OverlayArmy.TogglePanel = senda.Text;

            else if (parent.Name.Contains("Maphack"))
                PSettings.PreferenceAll.OverlayMaphack.TogglePanel = senda.Text;

            else if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.TogglePanel = senda.Text;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.TogglePanel = senda.Text;

            else
                Messages.Show("Couldn't find parent!");
        }

        void txtOverlaysResize_TextChanged(object sender, EventArgs e)
        {
            var senda = (TextBox)sender;

            var parent = HelpFunctions.findParentByName(senda, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.PreferenceAll.OverlayResources.ChangeSize = senda.Text;

            else if (parent.Name.Contains("Income"))
                PSettings.PreferenceAll.OverlayIncome.ChangeSize = senda.Text;

            else if (parent.Name.Contains("Worker"))
                PSettings.PreferenceAll.OverlayWorker.ChangeSize = senda.Text;

            else if (parent.Name.Contains("Apm"))
                PSettings.PreferenceAll.OverlayApm.ChangeSize = senda.Text;

            else if (parent.Name.Contains("Army"))
                PSettings.PreferenceAll.OverlayArmy.ChangeSize = senda.Text;

            else if (parent.Name.Contains("Maphack"))
                PSettings.PreferenceAll.OverlayMaphack.ChangeSize = senda.Text;

            else if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.ChangeSize = senda.Text;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.ChangeSize = senda.Text;

            else
                Messages.Show("Couldn't find parent!");
        }

        void txtOverlaysReposition_TextChanged(object sender, EventArgs e)
        {
            var senda = (TextBox)sender;

            var parent = HelpFunctions.findParentByName(senda, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.PreferenceAll.OverlayResources.ChangePosition = senda.Text;

            else if (parent.Name.Contains("Income"))
                PSettings.PreferenceAll.OverlayIncome.ChangePosition = senda.Text;

            else if (parent.Name.Contains("Worker"))
                PSettings.PreferenceAll.OverlayWorker.ChangePosition = senda.Text;

            else if (parent.Name.Contains("Apm"))
                PSettings.PreferenceAll.OverlayApm.ChangePosition = senda.Text;

            else if (parent.Name.Contains("Army"))
                PSettings.PreferenceAll.OverlayArmy.ChangePosition = senda.Text;

            else if (parent.Name.Contains("Maphack"))
                PSettings.PreferenceAll.OverlayMaphack.ChangePosition = senda.Text;

            else if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.ChangePosition = senda.Text;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.ChangePosition = senda.Text;

            else
                Messages.Show("Couldn't find parent!");
        }

        void ktxtOverlaysHotkey3_KeyChanged(KeyTextBox o, EventKey e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.PreferenceAll.OverlayResources.Hotkey3 = o.HotKeyValue;

            else if (parent.Name.Contains("Income"))
                PSettings.PreferenceAll.OverlayIncome.Hotkey3 = o.HotKeyValue;

            else if (parent.Name.Contains("Worker"))
                PSettings.PreferenceAll.OverlayWorker.Hotkey3 = o.HotKeyValue;

            else if (parent.Name.Contains("Apm"))
                PSettings.PreferenceAll.OverlayApm.Hotkey3 = o.HotKeyValue;

            else if (parent.Name.Contains("Army"))
                PSettings.PreferenceAll.OverlayArmy.Hotkey3 = o.HotKeyValue;

            else if (parent.Name.Contains("Maphack"))
                PSettings.PreferenceAll.OverlayMaphack.Hotkey3 = o.HotKeyValue;

            else if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.Hotkey3 = o.HotKeyValue;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.Hotkey3 = o.HotKeyValue;

            else
                Messages.Show("Couldn't find parent!");
        }

        void ktxtOverlaysHotkey2_KeyChanged(KeyTextBox o, EventKey e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.PreferenceAll.OverlayResources.Hotkey2 = o.HotKeyValue;

            else if (parent.Name.Contains("Income"))
                PSettings.PreferenceAll.OverlayIncome.Hotkey2 = o.HotKeyValue;

            else if (parent.Name.Contains("Worker"))
                PSettings.PreferenceAll.OverlayWorker.Hotkey2 = o.HotKeyValue;

            else if (parent.Name.Contains("Apm"))
                PSettings.PreferenceAll.OverlayApm.Hotkey2 = o.HotKeyValue;

            else if (parent.Name.Contains("Army"))
                PSettings.PreferenceAll.OverlayArmy.Hotkey2 = o.HotKeyValue;

            else if (parent.Name.Contains("Maphack"))
                PSettings.PreferenceAll.OverlayMaphack.Hotkey2 = o.HotKeyValue;

            else if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.Hotkey2 = o.HotKeyValue;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.Hotkey2 = o.HotKeyValue;

            else
                Messages.Show("Couldn't find parent!");
        }

        void ktxtOverlaysHotkey1_KeyChanged(KeyTextBox o, EventKey e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.PreferenceAll.OverlayResources.Hotkey1 = o.HotKeyValue;

            else if (parent.Name.Contains("Income"))
                PSettings.PreferenceAll.OverlayIncome.Hotkey1 = o.HotKeyValue;

            else if (parent.Name.Contains("Worker"))
                PSettings.PreferenceAll.OverlayWorker.Hotkey1 = o.HotKeyValue;

            else if (parent.Name.Contains("Apm"))
                PSettings.PreferenceAll.OverlayApm.Hotkey1 = o.HotKeyValue;

            else if (parent.Name.Contains("Army"))
                PSettings.PreferenceAll.OverlayArmy.Hotkey1 = o.HotKeyValue;

            else if (parent.Name.Contains("Maphack"))
                PSettings.PreferenceAll.OverlayMaphack.Hotkey1 = o.HotKeyValue;

            else if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.Hotkey1 = o.HotKeyValue;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.Hotkey1 = o.HotKeyValue;

            else
                Messages.Show("Couldn't find parent!");
        }

        void ocOverlaysOpacity_ValueChanged(UiOpacityControl uiOpacityControl, NumberArgs eventNumber)
        {
            var parent = HelpFunctions.findParentByName(uiOpacityControl, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.PreferenceAll.OverlayResources.Opacity = (float)uiOpacityControl.Number / 100;

            else if (parent.Name.Contains("Income"))
                PSettings.PreferenceAll.OverlayIncome.Opacity = (float)uiOpacityControl.Number / 100;

            else if (parent.Name.Contains("Worker"))
                PSettings.PreferenceAll.OverlayWorker.Opacity = (float)uiOpacityControl.Number / 100;

            else if (parent.Name.Contains("Apm"))
                PSettings.PreferenceAll.OverlayApm.Opacity = (float)uiOpacityControl.Number / 100;

            else if (parent.Name.Contains("Army"))
                PSettings.PreferenceAll.OverlayArmy.Opacity = (float)uiOpacityControl.Number / 100;

            else if (parent.Name.Contains("Maphack"))
                PSettings.PreferenceAll.OverlayMaphack.Opacity = (float)uiOpacityControl.Number / 100;

            else if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.Opacity = (float)uiOpacityControl.Number / 100;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.Opacity = (float)uiOpacityControl.Number / 100;

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
                PSettings.PreferenceAll.OverlayResources.FontName = ftDialog.Font.Name;

            else if (parent.Name.Contains("Income"))
                PSettings.PreferenceAll.OverlayIncome.FontName = ftDialog.Font.Name;

            else if (parent.Name.Contains("Worker"))
                PSettings.PreferenceAll.OverlayWorker.FontName = ftDialog.Font.Name;

            else if (parent.Name.Contains("Apm"))
                PSettings.PreferenceAll.OverlayApm.FontName = ftDialog.Font.Name;

            else if (parent.Name.Contains("Army"))
                PSettings.PreferenceAll.OverlayArmy.FontName = ftDialog.Font.Name;

            else if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.FontName = ftDialog.Font.Name;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.FontName = ftDialog.Font.Name;

            else 
                Messages.Show("Couldn't find parent!");

            senda.Text = ftDialog.Font.Name;
        }

        void aChBxOverlaysRemoveYourself_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.PreferenceAll.OverlayResources.RemoveLocalplayer = o.Checked;
            
            else if (parent.Name.Contains("Income"))
                PSettings.PreferenceAll.OverlayIncome.RemoveLocalplayer = o.Checked;

            else if (parent.Name.Contains("Apm"))
                PSettings.PreferenceAll.OverlayApm.RemoveLocalplayer = o.Checked;

            else if (parent.Name.Contains("Army"))
                PSettings.PreferenceAll.OverlayArmy.RemoveLocalplayer = o.Checked;

            else if (parent.Name.Contains("Maphack"))
                PSettings.PreferenceAll.OverlayMaphack.RemoveLocalplayer = o.Checked;

            else if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.RemoveLocalplayer = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.RemoveLocalplayer = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysRemoveNeutral_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.PreferenceAll.OverlayResources.RemoveNeutral = o.Checked;

            else if (parent.Name.Contains("Income"))
                PSettings.PreferenceAll.OverlayIncome.RemoveNeutral = o.Checked;

            else if (parent.Name.Contains("Apm"))
                PSettings.PreferenceAll.OverlayApm.RemoveNeutral = o.Checked;

            else if (parent.Name.Contains("Army"))
                PSettings.PreferenceAll.OverlayArmy.RemoveNeutral = o.Checked;

            else if (parent.Name.Contains("Maphack"))
                PSettings.PreferenceAll.OverlayMaphack.RemoveNeutral = o.Checked;

            else if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.RemoveNeutral = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.RemoveNeutral = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysRemoveClantags_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.PreferenceAll.OverlayResources.RemoveClanTag = o.Checked;

            else if (parent.Name.Contains("Income"))
                PSettings.PreferenceAll.OverlayIncome.RemoveClanTag = o.Checked;

            else if (parent.Name.Contains("Apm"))
                PSettings.PreferenceAll.OverlayApm.RemoveClanTag = o.Checked;

            else if (parent.Name.Contains("Army"))
                PSettings.PreferenceAll.OverlayArmy.RemoveClanTag = o.Checked;

            else if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.RemoveClanTag = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.RemoveClanTag = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysRemoveAllie_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.PreferenceAll.OverlayResources.RemoveAllie = o.Checked;

            else if (parent.Name.Contains("Income"))
                PSettings.PreferenceAll.OverlayIncome.RemoveAllie = o.Checked;

            else if (parent.Name.Contains("Apm"))
                PSettings.PreferenceAll.OverlayApm.RemoveAllie = o.Checked;

            else if (parent.Name.Contains("Army"))
                PSettings.PreferenceAll.OverlayArmy.RemoveAllie = o.Checked;

            else if (parent.Name.Contains("Maphack"))
                PSettings.PreferenceAll.OverlayMaphack.RemoveAllie = o.Checked;

            else if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.RemoveAllie = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.RemoveAllie = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysRemoveAi_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.PreferenceAll.OverlayResources.RemoveAi = o.Checked;

            else if (parent.Name.Contains("Income"))
                PSettings.PreferenceAll.OverlayIncome.RemoveAi = o.Checked;

            else if (parent.Name.Contains("Apm"))
                PSettings.PreferenceAll.OverlayApm.RemoveAi = o.Checked;

            else if (parent.Name.Contains("Army"))
                PSettings.PreferenceAll.OverlayArmy.RemoveAi = o.Checked;

            else if (parent.Name.Contains("Maphack"))
                PSettings.PreferenceAll.OverlayMaphack.RemoveAi = o.Checked;

            else if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.RemoveAi = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.RemoveAi = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysDrawBackground_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Resource"))
                PSettings.PreferenceAll.OverlayResources.DrawBackground = o.Checked;

            else if (parent.Name.Contains("Income"))
                PSettings.PreferenceAll.OverlayIncome.DrawBackground = o.Checked;

            else if (parent.Name.Contains("Apm"))
                PSettings.PreferenceAll.OverlayApm.DrawBackground = o.Checked;

            else if (parent.Name.Contains("Army"))
                PSettings.PreferenceAll.OverlayArmy.DrawBackground = o.Checked;

            else if (parent.Name.Contains("Worker"))
                PSettings.PreferenceAll.OverlayWorker.DrawBackground = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void ntxtOverlaysSize_NumberChanged(object sender, NumberArgs e)
        {
            var o = sender as NumberTextBox;

            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.PictureSize = o.Number;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.PictureSize = o.Number;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysDisplayUpgrades_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.PreferenceAll.OverlayProduction.ShowUpgrades = o.Checked;
        }

        void aChBxOverlaysTransparentImages_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Production"))
            {
                PSettings.PreferenceAll.OverlayProduction.UseTransparentImages = o.Checked;
                _lContainer.Find(x => x is ProductionRenderer).ChangeImageResources(o.Checked);
            }

            else if (parent.Name.Contains("Unit"))
            {
                PSettings.PreferenceAll.OverlayUnits.UseTransparentImages = o.Checked;
                _lContainer.Find(x => x is UnitRenderer).ChangeImageResources(o.Checked);
            }

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysSplitUnitsBuildings_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.SplitBuildingsAndUnits = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.SplitBuildingsAndUnits = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysRemoveSpellcounter_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.PreferenceAll.OverlayUnits.RemoveSpellCounter = o.Checked;
        }

        void aChBxOverlaysRemoveProductionstatus_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.PreferenceAll.OverlayUnits.RemoveProductionLine = o.Checked;
        }

        void aChBxOverlaysRemoveChronoboost_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.RemoveChronoboost = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.RemoveChronoboost = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysDisplayBuildings_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.ShowBuildings = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.ShowBuildings = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void aChBxOverlaysDisplayUnits_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            var parent = HelpFunctions.findParentByName(o, "pnlOverlays");

            if (parent.Name.Contains("Production"))
                PSettings.PreferenceAll.OverlayProduction.ShowUnits = o.Checked;

            else if (parent.Name.Contains("Unit"))
                PSettings.PreferenceAll.OverlayUnits.ShowUnits = o.Checked;

            else
                Messages.Show("Couldn't find parent!");
        }

        void btnOverlaysColorDestinationline_Click(object sender, EventArgs e)
        {
            var cl = new ColorDialog();
            cl.Color = Color.YellowGreen;
            cl.FullOpen = true;
            cl.ShowDialog();

            PSettings.PreferenceAll.OverlayMaphack.DestinationLine = cl.Color;
            pnlOverlayMaphack.pnlBasics.btnColorDestinationline.BackColor = cl.Color;
        }

        void aChBxOverlaysRemoveVisionArea_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.PreferenceAll.OverlayMaphack.RemoveVisionArea = o.Checked;
        }

        void aChBxOverlaysRemoveDestinationLine_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.PreferenceAll.OverlayMaphack.RemoveDestinationLine = o.Checked;
        }

        void aChBxOverlaysRemoveCamera_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.PreferenceAll.OverlayMaphack.RemoveCamera = o.Checked;
        }

        void aChBxOverlaysDefensiveStructures_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.PreferenceAll.OverlayMaphack.ColorDefensiveStructures = o.Checked;
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

            _lPluginContainer.Clear();
            _lPlugins.Clear();
            _lPluginDatastores.Clear();
            

            var files = Directory.GetFiles(Constants.StrPluginFolder, "*.dll");

            for (var i = 0; i < files.Length; i++)
            {
                var tmpAppDomain = AppDomain.CreateDomain(files[i].Substring(files[i].LastIndexOf("\\", StringComparison.Ordinal)));

                try
                {
                    var foo =
                        (IPlugins)
                            tmpAppDomain.CreateInstanceFromAndUnwrap(files[i], "Plugin.Extensions.AnotherSc2HackPlugin");

                    if (_lPlugins.Exists(x => x.Plugin.GetPluginName() == foo.GetPluginName()))
                       throw new TypeLoadException("Plugin Load Error"); //:D



                    _lPlugins.Add(new LocalPlugins(foo, files[i]));
                    _lPluginContainer.Add(tmpAppDomain);
                }

                catch (TypeLoadException)
                {
                    //If we are here, we couldn't load illegal .dll- files
                    //It's all good here!
                    AppDomain.Unload(tmpAppDomain);
                }

                catch (Exception)
                {
                    MessageBox.Show("Couldn't load plugin '" + files[i] + "'");
                }
            }

            var languageFiles = Directory.GetFiles(Constants.StrPluginFolder, "*.lang");

            foreach (var languageFile in languageFiles)
            {
                var plugin = new PluginDatastore();
                plugin.Name = Path.GetFileNameWithoutExtension(languageFile);

                using (var sr = new StreamReader(languageFile))
                {
                    var strVersion = sr.ReadLine();

                    if (strVersion != null && strVersion.Length > 2)
                        plugin.Version = strVersion.Substring(1);

                    else
                        plugin.Version = "0.0.0.0";
                }   

                plugin.Hash = Hashes.HashFromFile(languageFile, Hashes.HashAlgorithm.Md5);
                plugin.DownloadPath = languageFile;

                _lPluginDatastores.Add(plugin);
            }
            InitializeLanguageFiles();


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



            //Init the clickable panels for the plugins (if needed)
            foreach (var localPlugins in _lPlugins)
            {
                if (localPlugins.Plugin.GetPluginEntryName() != null && localPlugins.Plugin.GetPluginEntryName().Length > 0)
                {
                    //Remove plugin from cliclable container
                    var clickControls = pnlLeftSelection.Controls.Find(localPlugins.Hash, false);
                    var clickPanels = pnlMainArea.Controls.Find(localPlugins.Hash, false);

                    foreach (var clickControl in clickControls)
                    {
                        pnlLeftSelection.Controls.Remove(clickControl);
                    }

                    foreach (var clickPanel in clickPanels)
                    {
                        pnlMainArea.Controls.Remove(clickPanel);
                    }


                    var cntrls = pnlLeftSelection.Controls;
                    var iHeight = cpnlApplication.Height;

                    foreach (var cntrl in cntrls)
                    {
                        var cont = cntrl as ClickablePanel;

                        if (cont != null)
                            iHeight += cont.Height;
                    }

                    #region Create Panel

                    var panel = new Panel();

                    panel.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right)));
                    panel.Location = new Point(0, 80);
                    panel.Name = localPlugins.Hash;
                    panel.Size = new Size(1029, 450);
                    panel.TabIndex = 0;

                    pnlMainArea.Controls.Add(panel);

                    #endregion

                    #region Clickable Panel

                    var click = new ClickablePanel();
                    click.Parent = pnlLeftSelection;

                    click.ActiveBackgroundColor = Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(63)))), ((int)(((byte)(72)))));
                    click.ActiveBorderPosition = ActiveBorderPosition.Left;
                    click.ActiveForegroundColor = Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
                    click.BackColor = Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(90)))));
                    click.DisplayColor = Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
                    click.DisplayText = localPlugins.Plugin.GetPluginEntryName();
                    click.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    click.HoverBackgroundColor = Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(105)))), ((int)(((byte)(114)))));
                    click.InactiveBackgroundColor = Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(90)))));
                    click.InactiveForegroundColor = Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
                    click.IsClicked = false;
                    click.IsHovering = false;
                    click.Location = new Point(0, iHeight);
                    click.Name = localPlugins.Hash;
                    click.Size = new Size(152, 40);

                    click.Icon = HelpFunctions.ByteArrayToImage(localPlugins.Plugin.GetPluginIcon()) ?? Resources.icon_default_plugin;

                    click.TabIndex = 0;
                    click.TextSize = 11F;
                    click.SettingsPanel = panel;

                    click.Click += cpnl_Click;

                    #endregion


                }
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
                lwi.Checked = true;
                lstvPluginsLoadedPlugins.Items.Add(lwi);
            }

            foreach (var plugin in _lPluginDatastores)
            {
                var lwi = new ListViewItem();

                lwi.BackColor = lstvPluginsLoadedPlugins.Items.Count % 2 == 0 ? lwi.BackColor : Color.WhiteSmoke;
                lwi.Text = plugin.Name;

                lwi.SubItems.Add(new ListViewItem.ListViewSubItem(lwi, plugin.Version));
                lwi.Checked = true;
                lstvPluginsLoadedPlugins.Items.Add(lwi);
            }

   
        }

        /// <summary>
        /// This will fetch the plugins from a webserver.
        /// That means you will be able to load plugins right away!
        /// </summary>
        private void PluginLoadAvailablePlugins()
        {
            _.Info("Worker \"PluginLoadAvailablePlugins()\" started!", _.InfoImportance.VeryImportant);

            _lOnlinePlugins.Clear();
            foreach (var pluginDatastore in _ucDownloadManager.PluginDatastoresOnline)
            {
                var onlinePlugin = new OnlinePlugin();
                onlinePlugin.Name = pluginDatastore.Name;
                onlinePlugin.Description = pluginDatastore.Description;
                onlinePlugin.DownloadLink = pluginDatastore.DownloadPath;
                onlinePlugin.Hash = pluginDatastore.Hash;

                foreach (var imagePath in pluginDatastore.ImagePaths)
                {
                    onlinePlugin.ImageLinks.Add(imagePath);
                }

                onlinePlugin.Version = new Version(pluginDatastore.Version);
                _lOnlinePlugins.Add(onlinePlugin);
            }

            //We have to operate cross-thread wide. So we have to create an invoker...
            MethodInvoker myInvoker = delegate
            {
                lstvPluginsAvailablePlugins.Items.Clear();
                lstvPluginsAvailablePlugins.Enabled = true;

                foreach (var plugin in _lOnlinePlugins)
                {
                    var lwi = new ListViewItem();

                    lwi.BackColor = lstvPluginsAvailablePlugins.Items.Count % 2 == 0 ? lwi.BackColor : Color.WhiteSmoke;
                    lwi.Text = plugin.Name;

                    lwi.SubItems.Add(new ListViewItem.ListViewSubItem(lwi, plugin.Version.ToString()));

                    lstvPluginsAvailablePlugins.Items.Add(lwi);
                }

                
            };

            
            //...and invoke it here
            var iCounter = 0;

            while (iCounter < 10)
            {
                try
                {
                    if (!Created)
                    {
                        Thread.Sleep(50);

                    }

                    else
                    {
                        //Actual invoking
                        Invoke(myInvoker);
                        break;
                    }
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

                finally
                {
                    iCounter += 1;
                }
            }

            

            _.Info("Worker \"PluginLoadAvailablePlugins()\" finished!", _.InfoImportance.VeryImportant);
        }

        #endregion

        #region Event methods

        private void pcbPluginsImages_Click(object sender, EventArgs e)
        {
            if (pcbPluginsImages.Image == null)
                return;

            if (_lOnlinePlugins[IPluginsSelectedPluginIndex].Images.Count == _lOnlinePlugins[IPluginsSelectedPluginIndex].ImageLinks.Count)
                new BigPreviewPicture(_lOnlinePlugins[IPluginsSelectedPluginIndex].Images).ShowDialog();

            else
                new BigPreviewPicture(pcbPluginsImages.Image).ShowDialog();
        }

        private void lstvPluginsLoadedPlugins_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Index <= -1)
                return;

            if (_lPlugins.Count <= 0)
                return;

            if (e.Item.Index >= _lPlugins.Count)
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



            if (_lPlugins.Find(x => x.Hash == _lOnlinePlugins[IPluginsSelectedPluginIndex].Hash) != null)
            {
                MessageBox.Show("Plugin already installed!\n\nPlease select another plugin!", "Plugin Error");
            }

            if (_lPluginDatastores.Find(x => x.Hash == _lOnlinePlugins[IPluginsSelectedPluginIndex].Hash) != null)
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

        private void lstvPluginsLoadedPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            var senda = (ListView)sender;

            if (senda.SelectedIndices.Count <= 0)
                return;

            if (senda.SelectedIndices[0] < 0 ||
                senda.SelectedIndices[0] > _lPlugins.Count - 1)
                return;

            rtbPluginsDescription.Text = _lPlugins[senda.SelectedIndices[0]].Plugin.GetPluginDescription();
        }

        private void tsPluginRemove_Click(object sender, EventArgs e)
        {
            if (lstvPluginsLoadedPlugins.SelectedIndices.Count <= 0)
                return;

            if (lstvPluginsLoadedPlugins.SelectedIndices[0] < 0 ||
                lstvPluginsLoadedPlugins.SelectedIndices[0] > _lPlugins.Count + _lPluginDatastores.Count - 1)
                return;

            PluginRemovePlugin(lstvPluginsLoadedPlugins.SelectedIndices[0]);
        }

        private void tsPluginInstallPlugin_Click(object sender, EventArgs e)
        {
            btnPluginsInstallPlugin_Click(btnPluginsInstallPlugin, e);
        }

        void _lstrChPluginsPluginVersion_TextChanged(object sender, EventArgs e)
        {
            chPluginsAvailablePluginVersion.Text = _lstrChPluginsPluginVersion.Text;
            chPluginsLoadedPluginVersion.Text = _lstrChPluginsPluginVersion.Text;
        }

        void _lstrChPluginsPluginName_TextChanged(object sender, EventArgs e)
        {
            chPluginsAvailablePluginName.Text = _lstrChPluginsPluginName.Text;
            chPluginsLoadedPluginName.Text = _lstrChPluginsPluginName.Text;
        }

        void _lstrPluginContextInstallPlugin_TextChanged(object sender, EventArgs e)
        {
            tsPluginInstallPlugin.Text = _lstrPluginContextInstallPlugin.Text;
        }

        void _lstrPluginContextRemovePlugin_TextChanged(object sender, EventArgs e)
        {
            tsPluginRemove.Text = _lstrPluginContextRemovePlugin.Text;
        }

        #endregion

        /// <summary>
        /// Refresh the list of plugins
        /// </summary>
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
               /* Gameinfo.CAccessPlayers |= plugin.Plugin.GetRequiresPlayer();
                Gameinfo.CAccessSelection |= plugin.Plugin.GetRequiresSelection();
                Gameinfo.CAccessUnits |= plugin.Plugin.GetRequiresUnit();
                Gameinfo.CAccessUnitCommands |= plugin.Plugin.GetRequiresUnit();
                Gameinfo.CAccessGameinfo |= plugin.Plugin.GetRequiresGameinfo();
                Gameinfo.CAccessGroups |= plugin.Plugin.GetRequiresGroups();
                Gameinfo.CAccessMapInfo |= plugin.Plugin.GetRequiresMap();*/
            }
        }


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

            catch (Exception)
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

        private void PluginRemovePlugin(int index)
        {
            var iDomainIndex = -1;

            if (index < _lPlugins.Count)
              iDomainIndex = _lPluginContainer.FindIndex(x => x.FriendlyName == _lPlugins[index].PluginPath.Substring(_lPlugins[index].PluginPath.LastIndexOf(("\\"), StringComparison.Ordinal)));

            //No Domain found - it's a languagePlugin
            if (iDomainIndex < 0)
            {
                index = index - _lPlugins.Count;

                var plugin = _lPluginDatastores[index];

                if (PSettings.PreferenceAll.Global.Language == plugin.DownloadPath)
                {
                    new AnotherMessageBox().Show("Can't delete currently selected language!");
                    return;
                }

                if (File.Exists(plugin.DownloadPath))
                {
                    File.Delete(plugin.DownloadPath);
                    _lPluginDatastores.RemoveAt(index);
                    chBxLanguage.Items.RemoveAt(index);
                    PluginsLocalLoadedPluginsRefresh();
                }

                return;
            }
                

            Console.WriteLine("Removing Plugin {0} - Closing AppDomain {1}", _lPlugins[index].Plugin.GetPluginName(), _lPluginContainer[iDomainIndex].FriendlyName);
            Console.WriteLine("This Domain: " + AppDomain.CurrentDomain.FriendlyName);

            try
            {
                var strTempPluginPath = String.Empty;
                var strPuginHash = _lPlugins[index].Hash;

                //Stop plugin nicely 
                _lPlugins[index].Plugin.StopPlugin();
                strTempPluginPath = _lPlugins[index].PluginPath;
                _lPlugins.RemoveAt(index);

                //unload Appdomain
                AppDomain.Unload(_lPluginContainer[iDomainIndex]);
                _lPluginContainer.RemoveAt(iDomainIndex);

                //Delete Files that sound like the plugin
                var filename = Path.GetFileNameWithoutExtension(strTempPluginPath);
                var pluginFiles = Directory.GetFiles(
                    strTempPluginPath.Substring(0, strTempPluginPath.LastIndexOf("\\", StringComparison.Ordinal)), filename + "*");

                //Remove plugin from cliclable container
                var clickControls = pnlLeftSelection.Controls.Find(strPuginHash, false);
                var clickPanels = pnlMainArea.Controls.Find(strPuginHash, false);

                foreach (var clickControl in clickControls)
                {
                    pnlLeftSelection.Controls.Remove(clickControl);
                }

                foreach (var clickPanel in clickPanels)
                {
                    pnlMainArea.Controls.Remove(clickPanel);
                }

                foreach (var pluginFile in pluginFiles)
                {
                    try
                    {

                    
                    File.Delete(pluginFile);
                    }

                    catch
                    {
                        MessageBox.Show("Can't delete the plugin!\n" +
                                        "Please remove it manually from here:\n" +
                                        pluginFile);
                    }
                }
            }

            catch (AppDomainUnloadedException)
            {
                MessageBox.Show("I am sorry you read this!\n\nCouldn't uninstall plugin.\nRemove by hand!");
            }

            PluginsLocalLoadedPluginsRefresh();
        }

        #endregion

        #region Debug Panel Data

        #region Load Data into listviews

        private void DebugPlayerRefresh()
        {
            if (Gameinfo == null || Gameinfo.Player == null || Gameinfo.Player.Count <= 0)
            {
                lstvDebugPlayderdata.Enabled = false;
                return;
            }

            lstvDebugPlayderdata.Enabled = true;

            if (IDebugPlayerIndex > Gameinfo.Player.Count)
                IDebugPlayerIndex = Gameinfo.Player.Count - 1;

            lblDebugPlayerLocation.Text = (IDebugPlayerIndex + 1) + "/" +
                                          (Gameinfo.Player.Count); 

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

            txtDebugPlayerMemory.Text = Player.ClassObjectCount.ToString();
        }

        private void DebugUnitRefresh()
        {
            if (Gameinfo == null || Gameinfo.Unit == null || Gameinfo.Unit.Count <= 0)
            {
                lstvDebugUnitdata.Enabled = false;
                return;
            }

            lstvDebugUnitdata.Enabled = true;

            if (IDebugUnitIndex > Gameinfo.Unit.Count)
                IDebugUnitIndex = Gameinfo.Unit.Count - 1;

            var player = Gameinfo.Unit[IDebugUnitIndex];
            var properties = TypeDescriptor.GetProperties(player);

            lblDebugUnitLocation.Text = (IDebugUnitIndex + 1) + "/" + (Gameinfo.Unit.Count + 1);

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

            txtDebugUnitMemory.Text = Unit.ClassObjectCount.ToString();
        }

        private void DebugMapRefresh()
        {
            if (Gameinfo == null)
                return;

            var fields = typeof(Map).GetFields(BindingFlags.Public | BindingFlags.Instance);

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

                    var value = property.GetValue(Gameinfo.Gameinfo);
                    if (value != null)
                        lstvDebugMatchdata.Items[i].SubItems[lstvDebugMatchdata.Items[i].SubItems.Count - 1].Text = value.ToString();
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
                    var value = property.GetValue(Gameinfo.Gameinfo);
                    if (value != null)
                        lwi.SubItems.Add(new ListViewItem.ListViewSubItem(lwi, value.ToString()));

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

        private void ntxtDebugPlayerLocation_NumberChanged(object sender, NumberArgs e)
        {
            var o = sender as NumberTextBox;
            if (o == null)
                return;

            IDebugPlayerIndex = e.Number;
        }

        private void ntxtDebugUnitLocation_NumberChanged(object sender, NumberArgs e)
        {
            var o = sender as NumberTextBox;
            if (o == null)
                return;

            IDebugUnitIndex = e.Number;
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

        void _lstrChDebugValue_TextChanged(object sender, EventArgs e)
        {
            chDebugMapDataValue.Text = _lstrChDebugValue.Text;
            chDebugMatchDataValue.Text = _lstrChDebugValue.Text;
            chDebugUnitDataValue.Text = _lstrChDebugValue.Text;
            chDebugPlayerDataValue.Text = _lstrChDebugValue.Text;
        }

        void _lstrChDebugAttribute_TextChanged(object sender, EventArgs e)
        {
            chDebugMapDataAttribute.Text = _lstrChDebugAttribute.Text;
            chDebugMatchDataAttribute.Text = _lstrChDebugAttribute.Text;
            chDebugUnitDataAttribute.Text = _lstrChDebugAttribute.Text;
            chDebugPlayerDataAttribute.Text = _lstrChDebugAttribute.Text;
        }

        #endregion

        #endregion

        #region Renderer Eventmappings

        /// <summary>
        /// Init Eventmapping for the Baserenderer
        /// </summary>
        private void BaseRendererEventMapping()
        {
            foreach (var renderer in _lContainer)
            {
                renderer.IterationPerSecondChanged += renderer_IterationPerSecondChanged;
            }
        }

        /// <summary>
        /// Implement the required action (set the number)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void renderer_IterationPerSecondChanged(object sender, NumberArgs e)
        {
            var fExpectedIterations = (float)1000/PSettings.PreferenceAll.Global.DrawingRefresh;
            var fPercentageReached = (e.Number/fExpectedIterations) * 100;
            var clForeground = Color.Black;
            if (fPercentageReached > 80)
                clForeground = Color.ForestGreen;

            else if (fPercentageReached > 50)
                clForeground = Color.DarkOrange;

            else
                clForeground = Color.Red;

            var resourcesRenderer = sender as ResourcesRenderer;
            if (resourcesRenderer != null)
            {
                ntxtBenchmarkResourceIterations.Number = e.Number;
                ntxtBenchmarkResourceIterations.ForeColor = clForeground;
                return;
            }

            var incomeRenderer = sender as IncomeRenderer;
            if (incomeRenderer != null)
            {
                ntxtBenchmarkIncomeIterations.Number = e.Number;
                ntxtBenchmarkIncomeIterations.ForeColor = clForeground;
                return;
            }

            var workerRenderer = sender as WorkerRenderer;
            if (workerRenderer != null)
            {
                ntxtBenchmarkWorkerIterations.Number = e.Number;
                ntxtBenchmarkWorkerIterations.ForeColor = clForeground;
                return;
            }

            var armyRenderer = sender as ArmyRenderer;
            if (armyRenderer != null)
            {
                ntxtBenchmarkArmyIterations.Number = e.Number;
                ntxtBenchmarkArmyIterations.ForeColor = clForeground;
                return;
            }

            var apmRenderer = sender as ApmRenderer;
            if (apmRenderer != null)
            {
                ntxtBenchmarkApmIterations.Number = e.Number;
                ntxtBenchmarkApmIterations.ForeColor = clForeground;
                return;
            }

            var unitRenderer = sender as UnitRenderer;
            if (unitRenderer != null)
            {
                ntxtBenchmarkUnitTabIterations.Number = e.Number;
                ntxtBenchmarkUnitTabIterations.ForeColor = clForeground;
                return;
            }

            var productionRenderer = sender as ProductionRenderer;
            if (productionRenderer != null)
            {
                ntxtBenchmarkProductionTabIterations.Number = e.Number;
                ntxtBenchmarkProductionTabIterations.ForeColor = clForeground;
                return;
            }

            var maphackRenderer = sender as MaphackRenderer;
            if (maphackRenderer != null)
            {
                ntxtBenchmarkMaphackIterations.Number = e.Number;
                ntxtBenchmarkMaphackIterations.ForeColor = clForeground;
                return;
            }


        }

        #endregion

        #region Various Panel Data

        #region Event Mappings

        private void ntxtVariousApmLimit_NumberChanged(object sender, NumberArgs e)
        {
            PSettings.PreferenceAll.OverlayPersonalApm.ApmAlertLimit = e.Number;
        }

        private void chBxVariousShowPersonalApm_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.PreferenceAll.OverlayPersonalApm.PersonalApm = o.Checked;
            LaunchRenderer(typeof(PersonalApmRenderer));
        }

        private void chBxVariousPersonalApmAlert_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.PreferenceAll.OverlayPersonalApm.EnableAlert = o.Checked;
        }

        private void chBxVariousShowPersonalClock_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.PreferenceAll.OverlayPersonalClock.PersonalClock = o.Checked;
            LaunchRenderer(typeof(PersonalClockRenderer));
        }

        private void chBxVariousWorkerCoach_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.PreferenceAll.OverlayWorkerCoach.WorkerCoach = o.Checked;
            LaunchRenderer(typeof(WorkerCoachRenderer));

        }

        private void ntxtVariousWorkerCoachDisableAfter_NumberChanged(object sender, NumberArgs e)
        {
            PSettings.PreferenceAll.OverlayWorkerCoach.DisableAfter = e.Number;
        }

        private void aChBxVariousShowAlerts_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.PreferenceAll.OverlayAlert.ShowAlert = e.Value;
            LaunchRenderer(typeof(AlertRenderer));
        }

        private void aChBxVariousAlertSoundNotification_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.PreferenceAll.OverlayAlert.SoundNotification = e.Value;
        }

        private void ntxtVariousAlertShowDuration_NumberChanged(object sender, NumberArgs e)
        {
            PSettings.PreferenceAll.OverlayAlert.Time = e.Number;
        }

        private void btnVariousOpenAlerts_Click(object sender, EventArgs e)
        {
            var aConf = new AlertConfiguration(PSettings);
            aConf.Icon = Icon;
            var result = aConf.ShowDialog();

            if (result != DialogResult.Cancel)
            {
                PSettings = aConf.PSettings;
            }
        }


        #endregion

        #endregion

        #region HelpMe Panel Data

        #region Event Mappings

        private void btnHelpMePostOnD3scene_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.d3scene.com/forum/newreply.php?p=717534&noquote=1");
        }

        private void btnHelpMeEmailMe_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:bpatriciaella@yahoo.com");
        }

        private void btnHelpMeGithubIssues_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/bellaPatricia/AnotherSc2Hack/issues/new");
        }

        private void btnHelpMeLocalize_Click(object sender, EventArgs e)
        {
            Process.Start(
                "http://www.d3scene.com/forum/starcraft-2-hacks/65535-anothersc2hack-wol-hots-2-1-10-35237-a-163.html#post733195");
        }

        private void btnHelpMeCopyBitcoin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblHelpMeBitcoin.Text.Substring(lblHelpMeBitcoin.Text.IndexOf(":", StringComparison.Ordinal) + 2));
        }

        private void btnHelpMeCopyEmail_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblHelpMeEmail.Text);
        }

        private void btnHelpMePaypal_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=3ZAZS7HNX6DPW");
        }

        #endregion

        #endregion

        #region Credits Panel Data

        /// <summary>
        /// Load some contibuters into the listview
        /// </summary>
        private void LoadContributers()
        {
            lstvCredits.Items.Clear();


            var dict = new Dictionary<string, string>();

            dict.Add("D3Scene", _lstrCreditsReasonD3Scene.Text);
            dict.Add("Translators", _lstrCreditsTranslators.Text);
            dict.Add("Donators", _lstrCreditsReasonDonators.Text);
            dict.Add("RHCP (D3Scene)", _lstrCreditsReasonRhcp.Text);
            dict.Add("Beaving (D3Scene)", _lstrCreditsReasonBeaving.Text);
            dict.Add("Mr Nukealizer (D3Scene)", _lstrCreditsReasonMrnukealizer.Text);
            dict.Add("MyTeeWun (D3Scene)", _lstrCreditsReasonMyteewun.Text);
            dict.Add("mischa (D3Scene)", _lstrCreditsReasonMischa.Text);
            dict.Add("mr_ice (D3Scene)", _lstrCreditsReasonMrice.Text);
            dict.Add("Tracky (D3Scene)", _lstrCreditsReasonTracky.Text);
            dict.Add("Various people", _lstrCreditsReasonVariousPeople.Text);
            


            foreach (KeyValuePair<string, string> keyValuePair in dict)
            {
                var item = new ListViewItem(keyValuePair.Key);
                item.SubItems.Add(keyValuePair.Value);

                if (lstvCredits.Items.Count % 2 == 0)
                    item.BackColor = Color.WhiteSmoke;

                lstvCredits.Items.Add(item);
                lstvCredits.Columns[lstvCredits.Columns.Count - 1].Width = -2;
            }

        }

        #region Event Mappings

        /// <summary>
        /// Simple resize
        /// </summary>
        /// <param name="sender">The sender (source)</param>
        /// <param name="e">Standard event args</param>
        private void lstvCredits_SizeChanged(object sender, EventArgs e)
        {
            lstvCredits.Columns[lstvCredits.Columns.Count - 1].Width = -2;
        }

        void _lstrChCreditsReason_TextChanged(object sender, EventArgs e)
        {
            chCreditsReason.Text = _lstrChCreditsReason.Text;
        }

        void _lstrChCreditsContributer_TextChanged(object sender, EventArgs e)
        {
            chCreditsContributer.Text = _lstrChCreditsContributer.Text;
        }

        #endregion

        #endregion

        #region Load Settings Into Controls

        private void ControlsFill()
        {
            //Application / Global
            ntxtMemoryRefresh.Number = PSettings.PreferenceAll.Global.DataRefresh;
            ntxtGraphicsRefresh.Number = PSettings.PreferenceAll.Global.DrawingRefresh;
            ktxtReposition.Text = PSettings.PreferenceAll.Global.ChangeSizeAndPosition.ToString();
            aChBxOnlyDrawInForeground.Checked = PSettings.PreferenceAll.Global.DrawOnlyInForeground;

            if (!PSettings.PreferenceAll.Global.ApplicationSize.Equals(new Size(0, 0)))
                Size = PSettings.PreferenceAll.Global.ApplicationSize;

            else
                Size = new Size(1196, 630);

            CenterToScreen();

            InitializeLanguageFiles();
            InitializeResources();
            InitializeIncome();
            InitializeApm();
            InitializeArmy();
            InitializeWorker();
            InitializeMaphack();
            InitializeUnittab();
            InitializeProductiontab();
            InitializeVarious();
        }

        private void InitializeLanguageFiles()
        {
            _dictLanguageFile.Clear();
            chBxLanguage.Items.Clear();

            if (!Directory.Exists(Constants.StrPluginFolder))
            {
                Directory.CreateDirectory(Constants.StrPluginFolder);
                return;
            }

            var files = Directory.GetFiles(Constants.StrPluginFolder, "*.lang");

            foreach (var file in files)
            {
                if (file != null)
                {
                    var strLanguageName = String.Empty;
                    var strLanguageFile = String.Empty;

                    var strSource = File.ReadAllLines(file, Encoding.UTF8);
                    foreach (var strLine in strSource)
                    {
                        if (strLine.StartsWith("LanguageName:"))
                        {
                            strLanguageFile = file;
                            strLanguageName =
                                strLine.Substring(strLine.IndexOf("LanguageName: ", StringComparison.Ordinal) +
                                                  "LanguageName: ".Length);
                            break;
                        }
                    }

                    _dictLanguageFile.Add(file, strLanguageName);

                    chBxLanguage.Items.Add(_dictLanguageFile[file]);

                    //Select the last saved language
                    if (PSettings.PreferenceAll.Global.Language == strLanguageFile)
                        chBxLanguage.SelectedIndex = chBxLanguage.Items.Count - 1;
                }
            }
        }

        private void InitializeResources()
        {
            pnlOverlayResource.pnlBasics.aChBxDrawBackground.Checked = PSettings.PreferenceAll.OverlayResources.DrawBackground;
            pnlOverlayResource.pnlBasics.aChBxRemoveAi.Checked = PSettings.PreferenceAll.OverlayResources.RemoveAi;
            pnlOverlayResource.pnlBasics.aChBxRemoveAllie.Checked = PSettings.PreferenceAll.OverlayResources.RemoveAllie;
            pnlOverlayResource.pnlBasics.aChBxRemoveClantags.Checked = PSettings.PreferenceAll.OverlayResources.RemoveClanTag;
            pnlOverlayResource.pnlBasics.aChBxRemoveNeutral.Checked = PSettings.PreferenceAll.OverlayResources.RemoveNeutral;
            pnlOverlayResource.pnlBasics.aChBxRemoveYourself.Checked = PSettings.PreferenceAll.OverlayResources.RemoveLocalplayer;
            pnlOverlayResource.pnlBasics.btnSetFont.Text = PSettings.PreferenceAll.OverlayResources.FontName;
            pnlOverlayResource.pnlBasics.OpacityControl.tbOpacity.Value = PSettings.PreferenceAll.OverlayResources.Opacity > 1.0
                ? (Int32)PSettings.PreferenceAll.OverlayResources.Opacity
                : (Int32)(PSettings.PreferenceAll.OverlayResources.Opacity * 100);

            pnlOverlayResource.pnlLauncher.ktxtHotkey1.Text = PSettings.PreferenceAll.OverlayResources.Hotkey1.ToString();
            pnlOverlayResource.pnlLauncher.ktxtHotkey2.Text = PSettings.PreferenceAll.OverlayResources.Hotkey2.ToString();
            pnlOverlayResource.pnlLauncher.ktxtHotkey3.Text = PSettings.PreferenceAll.OverlayResources.Hotkey3.ToString();

            pnlOverlayResource.pnlLauncher.txtReposition.Text = PSettings.PreferenceAll.OverlayResources.ChangePosition;
            pnlOverlayResource.pnlLauncher.txtResize.Text = PSettings.PreferenceAll.OverlayResources.ChangeSize;
            pnlOverlayResource.pnlLauncher.txtToggle.Text = PSettings.PreferenceAll.OverlayResources.TogglePanel;
        }

        private void InitializeIncome()
        {
            pnlOverlayIncome.pnlBasics.aChBxDrawBackground.Checked = PSettings.PreferenceAll.OverlayIncome.DrawBackground;
            pnlOverlayIncome.pnlBasics.aChBxRemoveAi.Checked = PSettings.PreferenceAll.OverlayIncome.RemoveAi;
            pnlOverlayIncome.pnlBasics.aChBxRemoveAllie.Checked = PSettings.PreferenceAll.OverlayIncome.RemoveAllie;
            pnlOverlayIncome.pnlBasics.aChBxRemoveClantags.Checked = PSettings.PreferenceAll.OverlayIncome.RemoveClanTag;
            pnlOverlayIncome.pnlBasics.aChBxRemoveNeutral.Checked = PSettings.PreferenceAll.OverlayIncome.RemoveNeutral;
            pnlOverlayIncome.pnlBasics.aChBxRemoveYourself.Checked = PSettings.PreferenceAll.OverlayIncome.RemoveLocalplayer;
            pnlOverlayIncome.pnlBasics.btnSetFont.Text = PSettings.PreferenceAll.OverlayIncome.FontName;
            pnlOverlayIncome.pnlBasics.OpacityControl.tbOpacity.Value = PSettings.PreferenceAll.OverlayIncome.Opacity > 1.0
                ? (Int32)PSettings.PreferenceAll.OverlayIncome.Opacity
                : (Int32)(PSettings.PreferenceAll.OverlayIncome.Opacity * 100);

            pnlOverlayIncome.pnlLauncher.ktxtHotkey1.Text = PSettings.PreferenceAll.OverlayIncome.Hotkey1.ToString();
            pnlOverlayIncome.pnlLauncher.ktxtHotkey2.Text = PSettings.PreferenceAll.OverlayIncome.Hotkey2.ToString();
            pnlOverlayIncome.pnlLauncher.ktxtHotkey3.Text = PSettings.PreferenceAll.OverlayIncome.Hotkey3.ToString();

            pnlOverlayIncome.pnlLauncher.txtReposition.Text = PSettings.PreferenceAll.OverlayIncome.ChangePosition;
            pnlOverlayIncome.pnlLauncher.txtResize.Text = PSettings.PreferenceAll.OverlayIncome.ChangeSize;
            pnlOverlayIncome.pnlLauncher.txtToggle.Text = PSettings.PreferenceAll.OverlayIncome.TogglePanel;
        }

        private void InitializeApm()
        {
            pnlOverlayApm.pnlBasics.aChBxDrawBackground.Checked = PSettings.PreferenceAll.OverlayApm.DrawBackground;
            pnlOverlayApm.pnlBasics.aChBxRemoveAi.Checked = PSettings.PreferenceAll.OverlayApm.RemoveAi;
            pnlOverlayApm.pnlBasics.aChBxRemoveAllie.Checked = PSettings.PreferenceAll.OverlayApm.RemoveAllie;
            pnlOverlayApm.pnlBasics.aChBxRemoveClantags.Checked = PSettings.PreferenceAll.OverlayApm.RemoveClanTag;
            pnlOverlayApm.pnlBasics.aChBxRemoveNeutral.Checked = PSettings.PreferenceAll.OverlayApm.RemoveNeutral;
            pnlOverlayApm.pnlBasics.aChBxRemoveYourself.Checked = PSettings.PreferenceAll.OverlayApm.RemoveLocalplayer;
            pnlOverlayApm.pnlBasics.btnSetFont.Text = PSettings.PreferenceAll.OverlayApm.FontName;
            pnlOverlayApm.pnlBasics.OpacityControl.tbOpacity.Value = PSettings.PreferenceAll.OverlayApm.Opacity > 1.0
                ? (Int32)PSettings.PreferenceAll.OverlayApm.Opacity
                : (Int32)(PSettings.PreferenceAll.OverlayApm.Opacity * 100);

            pnlOverlayApm.pnlLauncher.ktxtHotkey1.Text = PSettings.PreferenceAll.OverlayApm.Hotkey1.ToString();
            pnlOverlayApm.pnlLauncher.ktxtHotkey2.Text = PSettings.PreferenceAll.OverlayApm.Hotkey2.ToString();
            pnlOverlayApm.pnlLauncher.ktxtHotkey3.Text = PSettings.PreferenceAll.OverlayApm.Hotkey3.ToString();

            pnlOverlayApm.pnlLauncher.txtReposition.Text = PSettings.PreferenceAll.OverlayApm.ChangePosition;
            pnlOverlayApm.pnlLauncher.txtResize.Text = PSettings.PreferenceAll.OverlayApm.ChangeSize;
            pnlOverlayApm.pnlLauncher.txtToggle.Text = PSettings.PreferenceAll.OverlayApm.TogglePanel;
        }

        private void InitializeArmy()
        {
            pnlOverlayArmy.pnlBasics.aChBxDrawBackground.Checked = PSettings.PreferenceAll.OverlayArmy.DrawBackground;
            pnlOverlayArmy.pnlBasics.aChBxRemoveAi.Checked = PSettings.PreferenceAll.OverlayArmy.RemoveAi;
            pnlOverlayArmy.pnlBasics.aChBxRemoveAllie.Checked = PSettings.PreferenceAll.OverlayArmy.RemoveAllie;
            pnlOverlayArmy.pnlBasics.aChBxRemoveClantags.Checked = PSettings.PreferenceAll.OverlayArmy.RemoveClanTag;
            pnlOverlayArmy.pnlBasics.aChBxRemoveNeutral.Checked = PSettings.PreferenceAll.OverlayArmy.RemoveNeutral;
            pnlOverlayArmy.pnlBasics.aChBxRemoveYourself.Checked = PSettings.PreferenceAll.OverlayArmy.RemoveLocalplayer;
            pnlOverlayArmy.pnlBasics.btnSetFont.Text = PSettings.PreferenceAll.OverlayArmy.FontName;
            pnlOverlayArmy.pnlBasics.OpacityControl.tbOpacity.Value = PSettings.PreferenceAll.OverlayArmy.Opacity > 1.0
                ? (Int32)PSettings.PreferenceAll.OverlayArmy.Opacity
                : (Int32)(PSettings.PreferenceAll.OverlayArmy.Opacity * 100);

            pnlOverlayArmy.pnlLauncher.ktxtHotkey1.Text = PSettings.PreferenceAll.OverlayArmy.Hotkey1.ToString();
            pnlOverlayArmy.pnlLauncher.ktxtHotkey2.Text = PSettings.PreferenceAll.OverlayArmy.Hotkey2.ToString();
            pnlOverlayArmy.pnlLauncher.ktxtHotkey3.Text = PSettings.PreferenceAll.OverlayArmy.Hotkey3.ToString();

            pnlOverlayArmy.pnlLauncher.txtReposition.Text = PSettings.PreferenceAll.OverlayArmy.ChangePosition;
            pnlOverlayArmy.pnlLauncher.txtResize.Text = PSettings.PreferenceAll.OverlayArmy.ChangeSize;
            pnlOverlayArmy.pnlLauncher.txtToggle.Text = PSettings.PreferenceAll.OverlayArmy.TogglePanel;
        }

        private void InitializeMaphack()
        {
            pnlOverlayMaphack.pnlBasics.aChBxRemoveAi.Checked = PSettings.PreferenceAll.OverlayMaphack.RemoveAi;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveAllie.Checked = PSettings.PreferenceAll.OverlayMaphack.RemoveAllie;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveNeutral.Checked = PSettings.PreferenceAll.OverlayMaphack.RemoveNeutral;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveYourself.Checked = PSettings.PreferenceAll.OverlayMaphack.RemoveLocalplayer;
            pnlOverlayMaphack.pnlBasics.OpacityControl.tbOpacity.Value = PSettings.PreferenceAll.OverlayMaphack.Opacity > 1.0
                ? (Int32)PSettings.PreferenceAll.OverlayMaphack.Opacity
                : (Int32)(PSettings.PreferenceAll.OverlayMaphack.Opacity * 100);
            pnlOverlayMaphack.pnlBasics.aChBxDefensiveStructures.Checked =
                PSettings.PreferenceAll.OverlayMaphack.ColorDefensiveStructures;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveCamera.Checked = PSettings.PreferenceAll.OverlayMaphack.RemoveCamera;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveVisionArea.Checked = PSettings.PreferenceAll.OverlayMaphack.RemoveVisionArea;
            pnlOverlayMaphack.pnlBasics.aChBxRemoveDestinationLine.Checked = PSettings.PreferenceAll.OverlayMaphack.RemoveDestinationLine;
            pnlOverlayMaphack.pnlBasics.btnColorDestinationline.BackColor = PSettings.PreferenceAll.OverlayMaphack.DestinationLine;

            pnlOverlayMaphack.pnlLauncher.ktxtHotkey1.Text = PSettings.PreferenceAll.OverlayMaphack.Hotkey1.ToString();
            pnlOverlayMaphack.pnlLauncher.ktxtHotkey2.Text = PSettings.PreferenceAll.OverlayMaphack.Hotkey2.ToString();
            pnlOverlayMaphack.pnlLauncher.ktxtHotkey3.Text = PSettings.PreferenceAll.OverlayMaphack.Hotkey3.ToString();

            pnlOverlayMaphack.pnlLauncher.txtReposition.Text = PSettings.PreferenceAll.OverlayMaphack.ChangePosition;
            pnlOverlayMaphack.pnlLauncher.txtResize.Text = PSettings.PreferenceAll.OverlayMaphack.ChangeSize;
            pnlOverlayMaphack.pnlLauncher.txtToggle.Text = PSettings.PreferenceAll.OverlayMaphack.TogglePanel;

            for (var i = 0; i < PSettings.PreferenceAll.OverlayMaphack.UnitIds.Count; i++)
            {
                var id =
               (UnitId)
                   Enum.Parse(typeof(UnitId), PSettings.PreferenceAll.OverlayMaphack.UnitIds[i].ToString());

                pnlOverlayMaphack.LUnitFilter.Add(id, PSettings.PreferenceAll.OverlayMaphack.UnitColors[i]);
            }

            pnlOverlayMaphack.AddUnitsToListview();

        }

        private void InitializeWorker()
        {
            pnlOverlayWorker.aChBxDrawBackground.Checked = PSettings.PreferenceAll.OverlayWorker.DrawBackground;
            pnlOverlayWorker.btnSetFont.Text = PSettings.PreferenceAll.OverlayWorker.FontName;
            pnlOverlayWorker.OpacityControl.tbOpacity.Value = PSettings.PreferenceAll.OverlayWorker.Opacity > 1.0
                ? (Int32)PSettings.PreferenceAll.OverlayWorker.Opacity
                : (Int32)(PSettings.PreferenceAll.OverlayWorker.Opacity * 100);

            pnlOverlayWorker.pnlLauncher.ktxtHotkey1.Text = PSettings.PreferenceAll.OverlayWorker.Hotkey1.ToString();
            pnlOverlayWorker.pnlLauncher.ktxtHotkey2.Text = PSettings.PreferenceAll.OverlayWorker.Hotkey2.ToString();
            pnlOverlayWorker.pnlLauncher.ktxtHotkey3.Text = PSettings.PreferenceAll.OverlayWorker.Hotkey3.ToString();

            pnlOverlayWorker.pnlLauncher.txtReposition.Text = PSettings.PreferenceAll.OverlayWorker.ChangePosition;
            pnlOverlayWorker.pnlLauncher.txtResize.Text = PSettings.PreferenceAll.OverlayWorker.ChangeSize;
            pnlOverlayWorker.pnlLauncher.txtToggle.Text = PSettings.PreferenceAll.OverlayWorker.TogglePanel;
        }

        private void InitializeUnittab()
        {
            pnlOverlayUnittab.pnlBasics.aChBxRemoveAi.Checked = PSettings.PreferenceAll.OverlayUnits.RemoveAi;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveAllie.Checked = PSettings.PreferenceAll.OverlayUnits.RemoveAllie;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveClantags.Checked = PSettings.PreferenceAll.OverlayUnits.RemoveClanTag;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveNeutral.Checked = PSettings.PreferenceAll.OverlayUnits.RemoveNeutral;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveYourself.Checked = PSettings.PreferenceAll.OverlayUnits.RemoveLocalplayer;
            pnlOverlayUnittab.pnlBasics.btnSetFont.Text = PSettings.PreferenceAll.OverlayUnits.FontName;
            pnlOverlayUnittab.pnlBasics.OpacityControl.tbOpacity.Value = PSettings.PreferenceAll.OverlayUnits.Opacity > 1.0
                ? (Int32)PSettings.PreferenceAll.OverlayUnits.Opacity
                : (Int32)(PSettings.PreferenceAll.OverlayUnits.Opacity * 100);
            pnlOverlayUnittab.pnlBasics.aChBxDisplayBuildings.Checked = PSettings.PreferenceAll.OverlayUnits.ShowBuildings;
            pnlOverlayUnittab.pnlBasics.aChBxDisplayUnits.Checked = PSettings.PreferenceAll.OverlayUnits.ShowUnits;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveChronoboost.Checked = PSettings.PreferenceAll.OverlayUnits.RemoveChronoboost;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveProductionstatus.Checked = PSettings.PreferenceAll.OverlayUnits.RemoveProductionLine;
            pnlOverlayUnittab.pnlBasics.aChBxRemoveSpellcounter.Checked = PSettings.PreferenceAll.OverlayUnits.RemoveSpellCounter;
            pnlOverlayUnittab.pnlBasics.aChBxSplitUnitsBuildings.Checked = PSettings.PreferenceAll.OverlayUnits.SplitBuildingsAndUnits;
            pnlOverlayUnittab.pnlBasics.aChBxTransparentImages.Checked = PSettings.PreferenceAll.OverlayUnits.UseTransparentImages;
            

            pnlOverlayUnittab.pnlLauncher.ktxtHotkey1.Text = PSettings.PreferenceAll.OverlayUnits.Hotkey1.ToString();
            pnlOverlayUnittab.pnlLauncher.ktxtHotkey2.Text = PSettings.PreferenceAll.OverlayUnits.Hotkey2.ToString();
            pnlOverlayUnittab.pnlLauncher.ktxtHotkey3.Text = PSettings.PreferenceAll.OverlayUnits.Hotkey3.ToString();

            pnlOverlayUnittab.pnlLauncher.txtReposition.Text = PSettings.PreferenceAll.OverlayUnits.ChangePosition;
            pnlOverlayUnittab.pnlLauncher.txtResize.Text = PSettings.PreferenceAll.OverlayUnits.ChangeSize;
            pnlOverlayUnittab.pnlLauncher.txtToggle.Text = PSettings.PreferenceAll.OverlayUnits.TogglePanel;

            pnlOverlayUnittab.pnlSpecial.ntxtSize.Text = PSettings.PreferenceAll.OverlayUnits.PictureSize.ToString();
        }

        private void InitializeProductiontab()
        {
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveAi.Checked = PSettings.PreferenceAll.OverlayProduction.RemoveAi;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveAllie.Checked = PSettings.PreferenceAll.OverlayProduction.RemoveAllie;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveClantags.Checked = PSettings.PreferenceAll.OverlayProduction.RemoveClanTag;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveNeutral.Checked = PSettings.PreferenceAll.OverlayProduction.RemoveNeutral;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveYourself.Checked = PSettings.PreferenceAll.OverlayProduction.RemoveLocalplayer;
            pnlOverlayProductiontab.pnlBasics.btnSetFont.Text = PSettings.PreferenceAll.OverlayProduction.FontName;
            pnlOverlayProductiontab.pnlBasics.OpacityControl.tbOpacity.Value = PSettings.PreferenceAll.OverlayProduction.Opacity > 1.0
                ? (Int32)PSettings.PreferenceAll.OverlayProduction.Opacity
                : (Int32)(PSettings.PreferenceAll.OverlayProduction.Opacity * 100);
            pnlOverlayProductiontab.pnlBasics.aChBxDisplayBuildings.Checked = PSettings.PreferenceAll.OverlayProduction.ShowBuildings;
            pnlOverlayProductiontab.pnlBasics.aChBxDisplayUnits.Checked = PSettings.PreferenceAll.OverlayProduction.ShowUnits;
            pnlOverlayProductiontab.pnlBasics.aChBxDisplayUpgrades.Checked = PSettings.PreferenceAll.OverlayProduction.ShowUpgrades;
            pnlOverlayProductiontab.pnlBasics.aChBxRemoveChronoboost.Checked = PSettings.PreferenceAll.OverlayProduction.RemoveChronoboost;
            pnlOverlayProductiontab.pnlBasics.aChBxSplitUnitsBuildings.Checked = PSettings.PreferenceAll.OverlayProduction.SplitBuildingsAndUnits;
            pnlOverlayProductiontab.pnlBasics.aChBxTransparentImages.Checked = PSettings.PreferenceAll.OverlayProduction.UseTransparentImages;


            pnlOverlayProductiontab.pnlLauncher.ktxtHotkey1.Text = PSettings.PreferenceAll.OverlayProduction.Hotkey1.ToString();
            pnlOverlayProductiontab.pnlLauncher.ktxtHotkey2.Text = PSettings.PreferenceAll.OverlayProduction.Hotkey2.ToString();
            pnlOverlayProductiontab.pnlLauncher.ktxtHotkey3.Text = PSettings.PreferenceAll.OverlayProduction.Hotkey3.ToString();

            pnlOverlayProductiontab.pnlLauncher.txtReposition.Text = PSettings.PreferenceAll.OverlayProduction.ChangePosition;
            pnlOverlayProductiontab.pnlLauncher.txtResize.Text = PSettings.PreferenceAll.OverlayProduction.ChangeSize;
            pnlOverlayProductiontab.pnlLauncher.txtToggle.Text = PSettings.PreferenceAll.OverlayProduction.TogglePanel;

            pnlOverlayProductiontab.pnlSpecial.ntxtSize.Text = PSettings.PreferenceAll.OverlayProduction.PictureSize.ToString();
        }

        private void InitializeVarious()
        {
            aChBxVariousPersonalApmAlert.Checked = PSettings.PreferenceAll.OverlayPersonalApm.EnableAlert;
            aChBxVariousShowPersonalApm.Checked = PSettings.PreferenceAll.OverlayPersonalApm.PersonalApm;
            ntxtVariousApmLimit.Number = PSettings.PreferenceAll.OverlayPersonalApm.ApmAlertLimit;

            aChBxVariousShowPersonalClock.Checked = PSettings.PreferenceAll.OverlayPersonalClock.PersonalClock;

            aChBxVariousWorkerCoach.Checked = PSettings.PreferenceAll.OverlayWorkerCoach.WorkerCoach;
            ntxtVariousWorkerCoachDisableAfter.Number = PSettings.PreferenceAll.OverlayWorkerCoach.DisableAfter;

            aChBxVariousAlertSoundNotification.Checked = PSettings.PreferenceAll.OverlayAlert.SoundNotification;
            aChBxVariousShowAlerts.Checked = PSettings.PreferenceAll.OverlayAlert.ShowAlert;
            ntxtVariousAlertShowDuration.Number = PSettings.PreferenceAll.OverlayAlert.Time;
        }

        #endregion

        #region Global Event Methods

        void _tmrMainTick_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - _dtSecond).Seconds >= 1)
            {
                _dtSecond = DateTime.Now;

                if (cpnlDebug.IsClicked)
                {
                    DebugPlayerRefresh();
                    DebugUnitRefresh();
                    DebugMapRefresh();
                    DebugMatchinformationRefresh();
                }
            }

            for (var i = 0; i < _lContainer.Count; i++)
            {
              /*  Gameinfo.CAccessGameinfo |= _lContainer[i].GInformation.CAccessGameinfo;
                Gameinfo.CAccessGroups |= _lContainer[i].GInformation.CAccessGroups;
                Gameinfo.CAccessMapInfo |= _lContainer[i].GInformation.CAccessMapInfo;
                Gameinfo.CAccessPlayers |= _lContainer[i].GInformation.CAccessPlayers;
                Gameinfo.CAccessSelection |= _lContainer[i].GInformation.CAccessSelection;
                Gameinfo.CAccessUnitCommands |= _lContainer[i].GInformation.CAccessUnitCommands;
                Gameinfo.CAccessUnits |= _lContainer[i].GInformation.CAccessUnits;*/
            }



            InputManager();
            PluginDataRefresh();
        }

        private void pnlMainArea_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(200, 200, 200))), new Point(15, 60),
                new Point(pnlMainArea.Width - 15, 60));
        }

        private void NewMainHandler_Resize(object sender, EventArgs e)
        {
            pnlMainArea.Invalidate();
            PSettings.PreferenceAll.Global.ApplicationSize = Size;
        }

        //Draw a new border on the top and bottom of the panel
        private void DrawVerticalBorders(object sender, PaintEventArgs e)
        {
            var send = (Panel)sender;

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, 0, Width, 0);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, send.Height - 1, Width, send.Height - 1);
        }

        private void NewMainHandler_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!PSettings.Write())
            {
                e.Cancel = true;
                return;
            }

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
            _lContainer.CloseNicely();
        }

        private void NewMainHandler_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_bLaunchDownloadManager)
                Process.Start(Constants.StrDownloadManager);
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

        void Gameinfo_IterationPerSecondChanged(object sender, NumberArgs e)
        {
            var fExpectedIterations = (float)1000 / PSettings.PreferenceAll.Global.DrawingRefresh;
            var fPercentageReached = (e.Number / fExpectedIterations) * 100;
            var clForeground = Color.Black;
            if (fPercentageReached > 80)
                clForeground = Color.ForestGreen;

            else if (fPercentageReached > 50)
                clForeground = Color.DarkOrange;

            else
                clForeground = Color.Red;


            ntxtBenchmarkDataIterations.Number = e.Number;
            ntxtBenchmarkDataIterations.ForeColor = clForeground;
        }

        void Gameinfo_ProcessFound(object sender, ProcessFoundArgs e)
        {
            PSc2Process = e.Process;
        }

        #endregion

        

        

        private void TogglePanelBorders()
        {
            foreach (var renderer in _lContainer)
            {
                renderer.FormBorderStyle = _bAdjustPanels ? FormBorderStyle.Sizable : FormBorderStyle.None;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logger.Emit("Cool Test title", new Exception("kek"));
        }

        private void RestorePanelPositionAndSize()
        {
            var tmpPreferences = PSettings;

            HelpFunctions.InitResolution(ref tmpPreferences, _lstrApplicationRestorePanelPositionText.Text, _lstrApplicationRestorePanelPositionHeader.Text);
            PSettings = tmpPreferences;

            foreach (var renderer in _lContainer)
            {
                renderer.ReloadPreferencesIntoControls();
            }
        }

        
    } 
}
