using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using PredefinedTypes = Predefined.PredefinedData;
using PluginInterface;
using Color = System.Windows.Media.Color;
using Image = System.Windows.Controls.Image;

namespace PluginUpgradeAlert
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PredefinedTypes.Map Map { get; set; }
        public PredefinedTypes.Gameinformation Gameinfo { get; set; }
        public PredefinedTypes.PList Players { get; set; }
        public List<PredefinedTypes.Unit> Units { get; set; }
        public PredefinedTypes.LSelection Selection { get; set; }
        public List<PredefinedTypes.Groups> Groups { get; set; }


        private DispatcherTimer _tmrMainTimer = new DispatcherTimer();
        private List<PredefinedTypes.UnitCount> _lTupConcussiveShells = new List<PredefinedTypes.UnitCount>();
        private Image _imgTupConcussiveShells;// = ImageProperties.Resources.Tup_ConcussiveShells;
        private List<System.Windows.Shapes.Rectangle> _lRectangles = new List<System.Windows.Shapes.Rectangle>(); 
        

        public MainWindow()
        {
            InitializeComponent();

            _tmrMainTimer.Tick += _tmrMainTimer_Tick;
            _tmrMainTimer.IsEnabled = true;
            _tmrMainTimer.Interval = new TimeSpan(0,0,0,0,30);

            for (int i = 0; i < 1; i++)
            {
                
                var tmpRec = new System.Windows.Shapes.Rectangle();
                tmpRec.Fill = Brushes.LightGray;
                tmpRec.Opacity = 0.5;
                tmpRec.Width = 500;
                tmpRec.Height = 300;
                tmpRec.RadiusX = 30;
                tmpRec.RadiusY = 20;

                cnvMainCanvas.Children.Add(tmpRec);
                _lRectangles.Add(tmpRec);

            }
        }

        void _tmrMainTimer_Tick(object sender, EventArgs e)

        {
            CountUpgrades();

            if (_lTupConcussiveShells.Count > 0 &&
                _lTupConcussiveShells[1].ConstructionState.Count > 0)
            {
                if (_lTupConcussiveShells[1].ConstructionTimeLeft[0] <= 30)
                {
                    Title = "ok";
                    DrawRectangle(_imgTupConcussiveShells, _lTupConcussiveShells[1].ConstructionTimeLeft[0], Colors.Aqua);
                }
            }
            
        }

        private void DrawRectangle(Image imgUpgrade, float fTimeLeft, Color clPlayercolor)
        {
            /* 50x50 */

            /* Make the complete Rectangle */

        }


        private void CountUpgrades()
        {
            if (Units == null ||
                Units.Count <= 0)
                return;

            if (Players == null ||
                Players.Count <= 0)
                return;

            if (_lTupConcussiveShells.Count > 0)
                _lTupConcussiveShells.Clear();

            for (var i = 0; i < Players.Count; i++)
            {
                _lTupConcussiveShells.Add(new PredefinedTypes.UnitCount());
            }

            for (var i = 0; i < Units.Count; i++)
            {
                var tmpUnit = Units[i];

                if (!tmpUnit.IsAlive ||
                    !tmpUnit.IsStructure)
                    continue;

                if (tmpUnit.Id.Equals(PredefinedTypes.UnitId.TbTechlabRax))
                {
                    if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                    {
                        for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                        {
                            if (tmpUnit.ProdUnitProductionId[k].Equals(PredefinedTypes.UnitId.TupConcussiveShells))
                            {
                                _lTupConcussiveShells[tmpUnit.Owner].UnitUnderConstruction += 1;
                                _lTupConcussiveShells[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                _lTupConcussiveShells[tmpUnit.Owner].ConstructionTimeLeft.Add(tmpUnit.ProdTimeLeft[k]);
                            }
                        }
                    }
                }
            }
        }
    }

    public class AnotherSc2HackPlugin : IPlugins
    {
        private MainWindow _mMainForm = null;

        public string GetPluginDescription()
        {
            return "A plugin to show Updates when they are about to finish";
        }

        public string GetPluginName()
        {
            return "Upgrade Alert";
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
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Gameinfo = gameinfo;
            }
        }

        public void SetGroups(List<PredefinedTypes.Groups> groups)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Groups = groups;
            }
        }

        public void SetMap(PredefinedTypes.Map map)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Map = map;
            }
        }

        public void SetPlayers(PredefinedTypes.PList players)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Players = players;
            }
        }

        public void SetSelection(PredefinedTypes.LSelection selection)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Selection = selection;
            }
        }

        public void SetUnits(List<PredefinedTypes.Unit> units)
        {
            if (_mMainForm != null &&
                _mMainForm.IsLoaded)
            {
                _mMainForm.Units = units;
            }
        }


        public void StartPlugin()
        {

            if (_mMainForm == null)
                _mMainForm = new MainWindow();


            if (_mMainForm.IsLoaded)
                _mMainForm.Close();

            else
            {

                _mMainForm = new MainWindow();
                _mMainForm.Show();
            }




        }

        public void StopPlugin()
        {
            if (_mMainForm != null)
                _mMainForm.Close();
        }
    }
}
