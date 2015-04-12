using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Forms;         //I'm a nasty motherfucker, I know :/
using PredefinedTypes = Predefined.PredefinedData;
using PluginInterface;
using PluginWorkerTrainer;

namespace Plugin.Extensions
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _tmrMainTick = new DispatcherTimer();
        private Preferences _pSettings = new Preferences();
        private Boolean _bMouseDown;
        private Int32 _iTimerBegin = 0;
        private Int32 _iTimerEnd = 0;
        private Int32 _iTimerSum = 0;
        private Boolean _bWorkerOverlayIsActive = false;

        public Boolean IsClosed { get; private set; }
        public IntPtr Handle { get; private set; }
        public PredefinedTypes.Gameinformation Gameinfo { get; set; }
        public PredefinedTypes.PList Players { get; set; }
        public List<PredefinedTypes.Unit> Units { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            IsClosed = true;

            _tmrMainTick.Tick += _tmrMainTick_Tick;
            _tmrMainTick.Interval = new TimeSpan(0, 0, 0, 0, _pSettings.Interval);
            _tmrMainTick.IsEnabled = true;


            imgProbe.Visibility = Visibility.Hidden;
            imgScv.Visibility = Visibility.Hidden;
            imgChronoboost.Visibility = Visibility.Hidden;
            imgMule.Visibility = Visibility.Hidden;

            txtEnergy.Foreground = new SolidColorBrush(Colors.Orange);
            txtWorkers.Foreground = new SolidColorBrush(Colors.Orange);

            Left = _pSettings.Left;
            Top = _pSettings.Top;
        }

        void _tmrMainTick_Tick(object sender, EventArgs e)
        {
            try
            {

                if (!Refresh())
                {
                    Opacity = 0.3;
                    cnvMiddle.Visibility = Visibility.Hidden;
                }

                else
                {
                    Opacity = 1;
                    cnvMiddle.Visibility = Visibility.Visible;
                }

                if (Gameinfo == null ||
                    Various.HotkeysPressed(_pSettings.HomeKey) ||
                    !Gameinfo.IsIngame ||
                    _bMouseDown)
                {
                    if (Various.HotkeysPressed(_pSettings.HomeKey) || _bMouseDown)
                    {
                        brdCanvasBorder.BorderThickness = new Thickness(4, 4, 4, 4);
                        brdCanvasBorder.BorderBrush = new SolidColorBrush(Colors.YellowGreen);
                        Opacity = Constants.MaximalOpacity;

                    }

                    btnSettings.Visibility = Visibility.Visible;
                    Various.SetWindowStyle(Handle, PredefinedTypes.CustomWindowStyles.Clickable);
                }

                else
                {
                    Various.SetWindowStyle(Handle, PredefinedTypes.CustomWindowStyles.NotClickable);
                    brdCanvasBorder.BorderThickness = new Thickness(0, 0, 0, 0);
                    btnSettings.Visibility = Visibility.Hidden;
                }

                if (Gameinfo != null)
                {
                    if (!Gameinfo.IsIngame)
                    {
                        _iTimerSum = 0;
                        _iTimerEnd = 0;
                        _iTimerBegin = 0;
                    }

                    if (Opacity >= 1)
                    {
                        if (!_bWorkerOverlayIsActive)
                        {
                            _iTimerBegin = Gameinfo.Timer;
                            _bWorkerOverlayIsActive = true;
                        }

                        else
                        {
                            _iTimerEnd = Gameinfo.Timer;
                        }
                    }

                    else
                    {
                        if (_bWorkerOverlayIsActive)
                        {
                            _iTimerEnd = Gameinfo.Timer;
                            _bWorkerOverlayIsActive = false;
                            _iTimerSum += _iTimerEnd - _iTimerBegin;
                        }
                    }

                    var strText = ((_iTimerEnd - _iTimerBegin)/60) + ":" + (_iTimerEnd - _iTimerBegin)%60;
                    var iNewSum = _iTimerSum + (_iTimerEnd - _iTimerBegin);
                    var strTextSum = iNewSum/60 + ":" + iNewSum%60;
                    txtTimerSum.Text = strText + " [" + strTextSum + "]";
                }

                

            }

            catch (Exception ex)
            {
                throw new Exception("If you see this: copy the message and send it to me!", ex);
            }
        }

        public new void Show()
        {
            base.Show();


            Width = _pSettings.Width;
            Height = _pSettings.Height;
            Left = _pSettings.Left;
            Top = _pSettings.Top;
            Topmost = true;
            IsClosed = false;


            Handle = new WindowInteropHelper(this).Handle;
            Various.SetWindowStyle(new WindowInteropHelper(this).Handle, PredefinedTypes.CustomWindowStyles.NotClickable);

            TransformImage();
        }

        public new void Close()
        {
            base.Close();

            _pSettings.Left = Left;
            _pSettings.Top = Top;
            _pSettings.WritePreferences();


            IsClosed = true;
        }

        private void TransformImage()
        {
            if (Left > SystemParameters.PrimaryScreenWidth / 2)
            {

                var trans = new TransformGroup();
                trans.Children.Add(new TranslateTransform(0, 0));
                trans.Children.Add(new RotateTransform(0));
                imgBackgroundBrush.Transform = trans;
            }

            else if (Left < SystemParameters.PrimaryScreenWidth / 2)
            {
                var trans = new TransformGroup();
                trans.Children.Add(new TranslateTransform(-250, -126));
                trans.Children.Add(new RotateTransform(180));
                imgBackgroundBrush.Transform = trans;
            }
        }

        public new void DragMove()
        {
            base.DragMove();

            TransformImage();
            _pSettings.Left = Left;
            _pSettings.Top = Top;
        }

        public Boolean Refresh()
        {
            #region Exceptions 

            if (Players == null ||
                Units == null)
                return false;

            if (!Gameinfo.IsIngame)
            {
                _iTimerSum = 0;
                return false;
            }

            if (Players.Count <= 0 ||
                Units.Count <= 0)
                return false;

            if (!Players.HasLocalplayer)
                return false;

            if (Players.LocalplayerIndex == 16)
                return false;
            

            if (Gameinfo.Timer/60 >= _pSettings.DisableAfterMinute)
            {

                return false;
            }

            #endregion

            Width = _pSettings.Width;
            Height = _pSettings.Height;
            _tmrMainTick.Interval = new TimeSpan(0, 0, 0, 0, _pSettings.Interval);

            var localPlayer = Players[Players.LocalplayerIndex];

            var iWorkers = 0;
            var iEnergy = 0;
            var tmpImgWorkers = imgScv;
            var tmpImgEnergy = imgMule;

            if (localPlayer.PlayerRace == PredefinedTypes.PlayerRace.Terran)
            {
                imgProbe.Visibility = Visibility.Hidden;
                imgChronoboost.Visibility = Visibility.Hidden;

                tmpImgWorkers = imgScv;
                tmpImgEnergy = imgMule;
            }

            else if (localPlayer.PlayerRace == PredefinedTypes.PlayerRace.Protoss)
            {
                tmpImgWorkers = imgProbe;
                tmpImgEnergy = imgChronoboost;

                imgScv.Visibility = Visibility.Hidden;
                imgMule.Visibility = Visibility.Hidden;
            }

            else if (localPlayer.PlayerRace == PredefinedTypes.PlayerRace.Zerg)
                return false;


            foreach (var unit in localPlayer.Units)
            {
                if (localPlayer.Minerals < 50)
                    return false;

                if (unit.Id.Equals(PredefinedTypes.UnitId.TbCcGround) ||
                    unit.Id.Equals(PredefinedTypes.UnitId.TbPlanetary) ||
                    unit.Id.Equals(PredefinedTypes.UnitId.TbOrbitalGround))
                {
                    if (!unit.IsUnderConstruction &&
                        unit.ProdNumberOfQueuedUnits <= 0)
                    {
                        if (!unit.ProdUnitProductionId.Contains(PredefinedTypes.UnitId.TupUpgradeToOrbital) &&
                            !unit.ProdUnitProductionId.Contains(PredefinedTypes.UnitId.TupUpgradeToPlanetary))
                        iWorkers += 1;
                    }

                    if (unit.Id.Equals(PredefinedTypes.UnitId.TbOrbitalGround) ||
                        unit.Id.Equals(PredefinedTypes.UnitId.TbOrbitalAir))
                    {
                        var tmp = (double)(unit.Energy >> 12) / 50;
                        tmp = Math.Floor(tmp);
                        iEnergy += (int)tmp;
                    }
                }

                if (unit.Id.Equals(PredefinedTypes.UnitId.PbNexus))
                {
                    if (!unit.IsUnderConstruction &&
                        unit.ProdNumberOfQueuedUnits <= 0)
                        iWorkers += 1;

                    var tmp = (double)(unit.Energy >> 12) / 25;
                    tmp = Math.Floor(tmp);
                    iEnergy += (int)tmp;
                }
            }

            if (iWorkers > 0)
            {
                txtWorkers.Visibility = Visibility.Visible;
                tmpImgWorkers.Visibility = Visibility.Visible;
                txtTimerSum.Visibility = Visibility.Visible;
                txtWorkers.Text = iWorkers.ToString(CultureInfo.InvariantCulture);
            }

            else
            {
                txtWorkers.Visibility = Visibility.Hidden;
                tmpImgWorkers.Visibility = Visibility.Hidden;
            }

            if (iEnergy > 0)
            {
                txtEnergy.Visibility = Visibility.Visible;
                txtEnergy.Text = iEnergy.ToString();
                tmpImgEnergy.Visibility = Visibility.Visible;
            }

            else
            {
                tmpImgEnergy.Visibility = Visibility.Hidden;
                txtEnergy.Visibility = Visibility.Hidden;
            }

            if (iWorkers == 0 &&
                iEnergy == 0)
            {
                return false;
            }

            return true;
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            var set = new Settings(_pSettings);
            set.ShowDialog();

            _pSettings = set.Pref;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _bMouseDown = true;
            DragMove();
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _bMouseDown = false;
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            _pSettings.Left = Left;
            _pSettings.Top = Top;
        }
    }

    public class AnotherSc2HackPlugin : MarshalByRefObject, IPlugins
    {
        private MainWindow _mainWindows = new MainWindow(); 

        public string GetPluginDescription()
        {
            return "Shows if you could make a Probe/ SCV\n" + 
                "and also available Mule- drops and\n" + 
                "Chronoboosts";
        }

        public string GetPluginName()
        {
            return "WorkerTrainer";
        }

        public bool GetRequiresGameinfo()
        {
            return true;
        }

        public bool GetRequiresGroups()
        {
            return false;
        }

        public bool GetRequiresMap()
        {
            return false;
        }

        public bool GetRequiresPlayer()
        {
            return true;
        }

        public bool GetRequiresSelection()
        {
            return false;
        }

        public bool GetRequiresUnit()
        {
            return true;
        }

        public void SetGameinfo(PredefinedTypes.Gameinformation gameinfo)
        {
            if (_mainWindows != null)
                _mainWindows.Gameinfo = gameinfo;
        }

        public void SetGroups(List<PredefinedTypes.Groups> groups)
        {
            //Nope
        }

        public void SetMap(PredefinedTypes.Map map)
        {
            //Nope
        }

        public void SetPlayers(PredefinedTypes.PList players)
        {
            if (_mainWindows != null)
                _mainWindows.Players = players;
        }

        public void SetSelection(PredefinedTypes.LSelection selection)
        {
            //Nope
        }

        public void SetUnits(List<PredefinedTypes.Unit> units)
        {
            if (_mainWindows != null)
                _mainWindows.Units = units;
        }

        public void StartPlugin()
        {
            if (_mainWindows != null &&
                !_mainWindows.IsClosed)
                _mainWindows.Show();

            else
            {
                _mainWindows = new MainWindow();
                _mainWindows.Show();
            }
        }

        public void StopPlugin()
        {
            _mainWindows.Close();
        }

        public string GetFileLocation()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location;
        }

        public Version GetPluginVersion()
        {
            return new Version(FileVersionInfo.GetVersionInfo(GetFileLocation()).FileVersion);
        }


        public System.Windows.Controls.UserControl GetPanelSettingsData()
        {
            return null;
        }

        public string GetPluginEntryName()
        {
            return String.Empty;
        }

        public byte[] GetPluginIcon()
        {
            return null;
        }

        public void SetStarcraftProcess(Process sc2Process)
        {
            //No
        }
    }
}
