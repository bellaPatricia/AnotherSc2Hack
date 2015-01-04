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
        private readonly List<IPlugins> _lPlugins = new List<IPlugins>();
        private readonly List<OnlinePlugin> _lOnlinePlugins = new List<OnlinePlugin>();
        private readonly WebClient _wcMainWebClient = new WebClient();


        private Int32 _iPluginsSelectedPluginIndex;

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

            PluginsLocalLoadPlugins();
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
            
        }

        private void PluginDataRefresh()
        {
            if (_lPlugins == null || _lPlugins.Count <= 0)
                return;


            foreach (var plugin in _lPlugins)
            {
                /* Refresh some Data */
                plugin.SetMap(Gameinfo.Map);
                plugin.SetPlayers(Gameinfo.Player);
                plugin.SetUnits(Gameinfo.Unit);
                plugin.SetSelection(Gameinfo.Selection);
                plugin.SetGroups(Gameinfo.Group);
                plugin.SetGameinfo(Gameinfo.Gameinfo);

                /* Set Access values for Gameinfo */
                Gameinfo.CAccessPlayers |= plugin.GetRequiresPlayer();
                Gameinfo.CAccessSelection |= plugin.GetRequiresSelection();
                Gameinfo.CAccessUnits |= plugin.GetRequiresUnit();
                Gameinfo.CAccessUnitCommands |= plugin.GetRequiresUnit();
                Gameinfo.CAccessGameinfo |= plugin.GetRequiresGameinfo();
                Gameinfo.CAccessGroups |= plugin.GetRequiresGroups();
                Gameinfo.CAccessMapInfo |= plugin.GetRequiresMap();
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
            MessageBox.Show("Nothing to do here");
        }

        #endregion

        #endregion

        #region Overlays Panel Data

        private void EventMapping()
        {
            #region Overlay Resource

            pnlOverlayResource.pnlBasics.aChBxDrawBackground.CheckedChanged += aChBxOverlayResourceDrawBackground_CheckedChanged;
            pnlOverlayResource.pnlBasics.aChBxRemoveAi.CheckedChanged += aChBxOverlayResourceRemoveAi_CheckedChanged;
            pnlOverlayResource.pnlBasics.aChBxRemoveAllie.CheckedChanged += aChBxOverlayResourceRemoveAllie_CheckedChanged;
            pnlOverlayResource.pnlBasics.aChBxRemoveClantags.CheckedChanged += aChBxOverlayResourceRemoveClantags_CheckedChanged;
            pnlOverlayResource.pnlBasics.aChBxRemoveNeutral.CheckedChanged += aChBxOverlayResourceRemoveNeutral_CheckedChanged;
            pnlOverlayResource.pnlBasics.aChBxRemoveYourself.CheckedChanged += aChBxOverlayResourceRemoveYourself_CheckedChanged;
            pnlOverlayResource.pnlBasics.btnSetFont.Click += btnOverlayResourceSetFont_Click;
            pnlOverlayResource.pnlBasics.OpacityControl.ValueChanged += OpacityControlOverlayResource_ValueChanged;

            pnlOverlayResource.pnlLauncher.ktxtHotkey1.TextChanged += ktxtOverlayResourceHotkey1_TextChanged;
            pnlOverlayResource.pnlLauncher.ktxtHotkey2.TextChanged += ktxtOverlayResourceHotkey2_TextChanged;
            pnlOverlayResource.pnlLauncher.ktxtHotkey3.TextChanged += ktxtOverlayResourceHotkey3_TextChanged;
            pnlOverlayResource.pnlLauncher.txtReposition.TextChanged += txtOverlayResourceReposition_TextChanged;
            pnlOverlayResource.pnlLauncher.txtResize.TextChanged += txtOverlayResourceResize_TextChanged;
            pnlOverlayResource.pnlLauncher.txtToggle.TextChanged += txtOverlayResourceToggle_TextChanged;

            #endregion
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

        #region Overlay Resource

        void txtOverlayResourceToggle_TextChanged(object sender, EventArgs e)
        {
            var senda = (TextBox)sender;

            var parent = senda.Parent.Parent;
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

            else if (parent.Name.Contains("Production"))
                PSettings.ProdTogglePanel = senda.Text;

            else if (parent.Name.Contains("Unit"))
                PSettings.UnitTogglePanel = senda.Text;

            MessageBox.Show(parent.Name);
        }

        void txtOverlayResourceResize_TextChanged(object sender, EventArgs e)
        {
            var senda = (TextBox)sender;
            PSettings.ResourceChangeSizePanel = senda.Text;
        }

        void txtOverlayResourceReposition_TextChanged(object sender, EventArgs e)
        {
            var senda = (TextBox)sender;
            PSettings.ResourceChangePositionPanel = senda.Text;
        }

        void ktxtOverlayResourceHotkey3_TextChanged(object sender, EventArgs e)
        {
            var senda = (KeyTextBox)sender;
            PSettings.ResourceHotkey3 = senda.HotKeyValue;
        }

        void ktxtOverlayResourceHotkey2_TextChanged(object sender, EventArgs e)
        {
            var senda = (KeyTextBox)sender;
            PSettings.ResourceHotkey2 = senda.HotKeyValue;
        }

        private void ktxtOverlayResourceHotkey1_TextChanged(object sender, EventArgs eventArgs)
        {
            var senda = (KeyTextBox)sender;
            PSettings.ResourceHotkey1 = senda.HotKeyValue;
        }

        private void OpacityControlOverlayResource_ValueChanged(UiOpacityControl uiOpacityControl, EventNumber eventNumber)
        {
            PSettings.ResourceOpacity = uiOpacityControl.Number;
        }

        void btnOverlayResourceSetFont_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Show some font");
        }

        void aChBxOverlayResourceRemoveYourself_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.ResourceRemoveLocalplayer = o.Checked;
        }

        void aChBxOverlayResourceRemoveNeutral_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.ResourceRemoveNeutral = o.Checked;
        }

        void aChBxOverlayResourceRemoveClantags_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.ResourceRemoveClanTag = o.Checked;
        }

        void aChBxOverlayResourceRemoveAllie_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.ResourceRemoveAllie = o.Checked;
        }

        void aChBxOverlayResourceRemoveAi_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.ResourceRemoveAi = o.Checked;
        }

        void aChBxOverlayResourceDrawBackground_CheckedChanged(AnotherCheckbox o, EventChecked e)
        {
            PSettings.ResourceDrawBackground = o.Checked;
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

                    if (_lPlugins.Exists(x => x.GetPluginName() == foo.GetPluginName()))
                       throw new TypeLoadException("Fuck you");
                    

                    _lPlugins.Add(foo);
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
                plugin.StartPlugin();
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
                lwi.Text = plugin.GetPluginName();

                lwi.SubItems.Add(new ListViewItem.ListViewSubItem(lwi, plugin.GetPluginVersion().ToString()));

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
                _lPlugins[e.Item.Index].StartPlugin();

            else
                _lPlugins[e.Item.Index].StopPlugin();
        }

        private void lstvPluginsAvailablePlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            var senda = ((ListView)sender);
            if (senda.Items.Count <= 0)
                return;

            if (senda.SelectedItems.Count <= 0)
                return;

            if (senda.SelectedItems[0].Index >= senda.Items.Count)
                return;

            IPluginsSelectedPluginIndex = senda.SelectedItems[0].Index;

            if (_lOnlinePlugins[IPluginsSelectedPluginIndex].Images.Count > 0)
            {
                pcbPluginsImages.Image = _lOnlinePlugins[IPluginsSelectedPluginIndex].Images[0];
                IPluginsImageIndex = 0;
            }

            var onlinePlugin = _lOnlinePlugins[IPluginsSelectedPluginIndex];

            rtbPluginsDescription.Text = onlinePlugin.Description;


            

            if (_lOnlinePlugins[IPluginsSelectedPluginIndex].Images.Count <= 0)
                new Thread(PluginDownloadSpecificImages).Start(IPluginsSelectedPluginIndex);
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
            var strOnlinePath = _lOnlinePlugins[IPluginsSelectedPluginIndex].DownloadLink;
            var strLocalPath =
                _lOnlinePlugins[IPluginsSelectedPluginIndex].DownloadLink.Split('/')[
                    _lOnlinePlugins[IPluginsSelectedPluginIndex].DownloadLink.Split('/').Length - 1];

            PluginsInstallPlugin(strOnlinePath + "#" + strLocalPath);

            //new Thread(PluginsInstallPlugin).Start(strOnlinePath + "#" + strLocalPath);
        }

        #endregion

       

        private void PluginDownloadSpecificImages(object index)
        {
            var i = (Int32)index;

            MethodInvoker myInvoker = delegate
            {
                //Download images if available AND they were not downloaded already!
                if (_lOnlinePlugins[i].Images.Count <= 0)
                {
                    for (var j = 0; j < _lOnlinePlugins[i].ImageLinks.Count; j++)
                    {
                        var rawImg =
                            _wcMainWebClient.DownloadData(_lOnlinePlugins[i].ImageLinks[j]);
                        var img = HelpFunctions.ByteArrayToImage(rawImg);

                        _lOnlinePlugins[i].Images.Add(img);
                    }
                }

                lstvPluginsAvailablePlugins_SelectedIndexChanged(lstvPluginsAvailablePlugins, new EventArgs());
                
            };

            var bFailed = true;

            while (bFailed)
            {
                try
                {
                    Invoke(myInvoker);
                    bFailed = false;
                }

                catch
                {
                    //Nothing
                    Thread.Sleep(30);
                }
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

            catch (Exception ex)
            {
                MessageBox.Show("Couldn't install Plugin!", "Something went wrong!");
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
                plugin.StopPlugin();
            }

            foreach (var appDomain in _lPluginContainer)
            {
                AppDomain.Unload(appDomain);
            }

            _tmrMainTick.Enabled = false;
            Gameinfo.HandleThread(false);
        }

        

        

        

       
    }

    [DebuggerDisplay("Name: {Name}; Description: {Description}; Version: {Version}; Link: {DownloadLink}")]
    public class OnlinePlugin
    {

        public OnlinePlugin()
        {
            InitCode();
        }

        private void InitCode()
        {
            ImageLinks = new List<String>();
            Images = new List<Image>();
            Name = String.Empty;
            Description = String.Empty;
            Version = new Version(0, 0, 0, 0);
            RequiresUpdate = false;
            LocalPath = String.Empty;
        }

        

        public String Name { get; set; }
        public String Description { get; set; }
        public List<String> ImageLinks { get; set; }
        public List<Image> Images { get; set; } 
        public Version Version { get; set; }
        public String DownloadLink { get; set; }
        public Boolean RequiresUpdate { get; set; }
        public String LocalPath { get; set; }
    }

    
}
