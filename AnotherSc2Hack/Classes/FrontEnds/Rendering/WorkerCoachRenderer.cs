using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using System.Drawing;
using PredefinedTypes = Predefined.PredefinedData;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    public class WorkerCoachRenderer : BaseRenderer
    {
        #region Private Variables

        private Int32 _iWorkerBegin;
        private Int32 _iWorkerEnd;
        private Int32 _iEnergyBegin;
        private Int32 _iEnergyEnd;
        
        private readonly List<int> _lWorkerIdle = new List<int>();
        private readonly List<int> _lEnergyIdle = new List<int>(); 
        private Image _imgWorker = Properties.Resources.trans_tu_scv;
        private Image _imgSpecial = Properties.Resources.trans_tu_mule;
        private Font _bFont;

        #endregion

        #region Properties

        private bool _bWorkerJustGotInactive;

        public bool BWorkerJustGotInactive
        {
            get { return _bWorkerJustGotInactive; }
            set
            {
                if (_bWorkerJustGotInactive == value)
                    return;



                if (!_bWorkerJustGotInactive &&
                    value)
                    OnWorkerProductionIdle(this, new EventArgs());

                else if (_bWorkerJustGotInactive && !value)
                    OnWorkerProductionActive(this, new EventArgs());

                _bWorkerJustGotInactive = value;
            }
        }


        private bool _bEnergyJustGotInactive;
        public bool BEnergyJustGotInactive
        {
            get { return _bEnergyJustGotInactive; }
            set
            {
                if (_bEnergyJustGotInactive == value)
                    return;



                if (!_bEnergyJustGotInactive &&
                    value)
                    OnEnergyIdle(this, new EventArgs());

                else if (_bEnergyJustGotInactive && !value)
                    OnEnergyActive(this, new EventArgs());

                _bEnergyJustGotInactive = value;
            }
        }

        #endregion

        #region Private Events

        private event EventHandler WorkerProductionIdle;
        private event EventHandler WorkerProductionActive;
        private event EventHandler EnergyIdle;
        private event EventHandler EnergyActive;

        #endregion

        #region Constructor

        public WorkerCoachRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
            : base(gInformation, pSettings, sc2Process)
        {
        }

        #endregion

        #region Private Methods

        void WorkerCoachRenderer_EnergyActive(object sender, EventArgs e)
        {
            _lEnergyIdle.Add(_iEnergyEnd - _iEnergyBegin);
        }

        void WorkerCoachRenderer_EnergyIdle(object sender, EventArgs e)
        {
            if (GInformation.Gameinfo != null)
                _iEnergyBegin = GInformation.Gameinfo.Timer;
        }

        void WorkerCoachRenderer_WorkerProductionActive(object sender, EventArgs e)
        {
            _lWorkerIdle.Add(_iWorkerEnd - _iWorkerBegin);
        }

        void WorkerCoachRenderer_WorkerProductionIdle(object sender, EventArgs e)
        {
            if (GInformation.Gameinfo != null)
                _iWorkerBegin = GInformation.Gameinfo.Timer;
        }

        void GInformation_NewMatch(object sender, EventArgs e)
        {
            _iWorkerBegin = 0;
            _lWorkerIdle.Clear();

            _iEnergyBegin = 0;
            _lEnergyIdle.Clear();


            if (GInformation.Player != null &&
                GInformation.Player.HasLocalplayer)
            {
                var player = GInformation.Player[GInformation.Player.LocalplayerIndex];

                if (player.PlayerRace == PredefinedTypes.PlayerRace.Terran)
                {
                    _imgWorker = Properties.Resources.trans_tu_scv;
                    _imgSpecial = Properties.Resources.trans_tu_mule;
                }

                else if (player.PlayerRace == PredefinedTypes.PlayerRace.Protoss)
                {
                    _imgWorker = Properties.Resources.trans_pu_probe;
                    _imgSpecial = Properties.Resources.pup_chrono;
                }
            }
        }

        #endregion

        #region Event Methods

        private void OnWorkerProductionIdle(object sender, EventArgs e)
        {
            if (WorkerProductionIdle != null)
                WorkerProductionIdle(sender, e);
        }

        private void OnWorkerProductionActive(object sender, EventArgs e)
        {
            if (WorkerProductionActive != null)
                WorkerProductionActive(sender, e);
        }

        private void OnEnergyIdle(object sender, EventArgs e)
        {
            if (EnergyIdle != null)
                EnergyIdle(sender, e);
        }

        private void OnEnergyActive(object sender, EventArgs e)
        {
            if (EnergyActive != null)
                EnergyActive(sender, e);
        }

        #endregion

        #region Protected Methods

        protected override void Draw(BufferedGraphics g)
        {
            GInformation.CAccessPlayers = true;
            GInformation.CAccessUnits = true;
            GInformation.CAccessUnitCommands = true;

            try
            {
                #region Exceptions

                if (GInformation.Player == null ||
                    GInformation.Unit == null)
                    return;

                if (!GInformation.Gameinfo.IsIngame)
                {
                    _iWorkerEnd = 0;
                    _iWorkerBegin = 0;
                    _iEnergyBegin = 0;
                    _iEnergyEnd = 0;
                    return;
                }

                if (GInformation.Player.Count <= 0 ||
                    GInformation.Unit.Count <= 0)
                    return;

                if (!GInformation.Player.HasLocalplayer)
                    return;

                if (GInformation.Player.LocalplayerIndex == 16)
                    return;


                if (GInformation.Gameinfo.Timer/60 >= PSettings.PreferenceAll.OverlayWorkerCoach.DisableAfter)
                    Opacity = 0.3;

                else
                    Opacity = 0.8;
                

                #endregion

                var localPlayer = GInformation.Player[GInformation.Player.LocalplayerIndex];

                var iUnusedWorkers = 0;
                var iUnusedEnergy = 0;


                foreach (var unit in localPlayer.Units)
                {
                    if (localPlayer.Minerals < 50)
                        return;

                    if (localPlayer.SupplyMin == localPlayer.SupplyMax)
                        return;

                    if (unit.Id.Equals(PredefinedTypes.UnitId.TbCcGround) ||
                        unit.Id.Equals(PredefinedTypes.UnitId.TbPlanetary) ||
                        unit.Id.Equals(PredefinedTypes.UnitId.TbOrbitalGround))
                    {
                        if (!unit.IsUnderConstruction &&
                            unit.ProdNumberOfQueuedUnits <= 0)
                        {
                            if (!unit.ProdUnitProductionId.Contains(PredefinedTypes.UnitId.TupUpgradeToOrbital) &&
                                !unit.ProdUnitProductionId.Contains(PredefinedTypes.UnitId.TupUpgradeToPlanetary))
                                iUnusedWorkers += 1;
                        }

                        if (unit.Id.Equals(PredefinedTypes.UnitId.TbOrbitalGround) ||
                            unit.Id.Equals(PredefinedTypes.UnitId.TbOrbitalAir))
                        {
                            var tmp = (double)(unit.Energy >> 12) / 50;
                            tmp = Math.Floor(tmp);
                            iUnusedEnergy += (int)tmp;
                        }
                    }

                    if (unit.Id.Equals(PredefinedTypes.UnitId.PbNexus))
                    {
                        if (!unit.IsUnderConstruction &&
                            unit.ProdNumberOfQueuedUnits <= 0)
                            iUnusedWorkers += 1;

                        var tmp = (double)(unit.Energy >> 12) / 25;
                        tmp = Math.Floor(tmp);
                        iUnusedEnergy += (int)tmp;
                    }
                }

                

                if (iUnusedWorkers > 0)
                {
                    BWorkerJustGotInactive = true;


                    _iWorkerEnd = GInformation.Gameinfo.Timer;
                    var strCurrentIdleTime = ((_iWorkerEnd - _iWorkerBegin) / 60) + ":" + (_iWorkerEnd - _iWorkerBegin) % 60;
                    var iSumIdleTime = _lWorkerIdle.Sum() + (_iWorkerEnd - _iWorkerBegin);
                    var strSumIdleTime = iSumIdleTime / 60 + ":" + iSumIdleTime % 60;

                    g.Graphics.DrawImage(_imgWorker, new Rectangle(33, 28, 36, 36));
                    g.Graphics.DrawString(strCurrentIdleTime + " [" + strSumIdleTime + "]", _bFont, Brushes.DarkOrange, new PointF(75 + 33 + 20, 28));
                    g.Graphics.DrawString(iUnusedWorkers.ToString(), _bFont, Brushes.DarkOrange, new PointF(41 + 33, 28));
                }

                else
                    BWorkerJustGotInactive = false;


                if (iUnusedEnergy > 0)
                {
                    BEnergyJustGotInactive = true;

                    _iEnergyEnd = GInformation.Gameinfo.Timer;
                    var strCurrentIdleTime = ((_iEnergyEnd - _iEnergyBegin) / 60) + ":" + (_iEnergyEnd - _iEnergyBegin) % 60;
                    var iSumIdleTime = _lEnergyIdle.Sum() + (_iEnergyEnd - _iEnergyBegin);
                    var strSumIdleTime = iSumIdleTime / 60 + ":" + iSumIdleTime % 60;

                    g.Graphics.DrawImage(_imgSpecial, new Rectangle(33, 28 + 36, 36, 36));
                    g.Graphics.DrawString(strCurrentIdleTime + " [" + strSumIdleTime + "]", _bFont, Brushes.DarkOrange, new PointF(75 + 33 + 20, 28 + 40));
                    g.Graphics.DrawString(iUnusedEnergy.ToString(), _bFont, Brushes.DarkOrange,
                        new PointF(41 + 33, 28 + 40));
                }

                else
                    BEnergyJustGotInactive = false;


                if (iUnusedEnergy > 0 ||
                    iUnusedWorkers > 0)
                {
                    //Draw the background image manually
                    g.Graphics.DrawImage(Properties.Resources.WorkerCoach, 0, 0, Width - 1, Height - 1);
                }
            }

            catch (Exception ex)
            {

            }
        }

        protected override void LoadSpecificData()
        {
            _bFont = new Font("Century Gothic", 17f);

            GInformation.NewMatch += GInformation_NewMatch;
            WorkerProductionIdle += WorkerCoachRenderer_WorkerProductionIdle;
            WorkerProductionActive += WorkerCoachRenderer_WorkerProductionActive;
            EnergyIdle += WorkerCoachRenderer_EnergyIdle;
            EnergyActive += WorkerCoachRenderer_EnergyActive;
        }

        protected override void BaseRenderer_ResizeEnd(object sender, EventArgs e)
        {
            PSettings.PreferenceAll.OverlayWorkerCoach.X = Location.X;
            PSettings.PreferenceAll.OverlayWorkerCoach.Y = Location.Y;
            PSettings.PreferenceAll.OverlayWorkerCoach.Width = Width;
            PSettings.PreferenceAll.OverlayWorkerCoach.Height = Height;
        }

        protected override void AdjustPanelSize()
        {
            //No
        }

        protected override void AdjustPanelPosition()
        {
            //No
        }

        protected override void LoadPreferencesIntoControls()
        {
            Location = new Point(PSettings.PreferenceAll.OverlayWorkerCoach.X,
                                     PSettings.PreferenceAll.OverlayWorkerCoach.Y);
            Size = new Size(PSettings.PreferenceAll.OverlayWorkerCoach.Width,
                            PSettings.PreferenceAll.OverlayWorkerCoach.Height);
        }

        protected override void MouseUpTransferData()
        {
            PSettings.PreferenceAll.OverlayWorkerCoach.X = Location.X;
            PSettings.PreferenceAll.OverlayWorkerCoach.Y = Location.Y;
            PSettings.PreferenceAll.OverlayWorkerCoach.Width = Width;
            PSettings.PreferenceAll.OverlayWorkerCoach.Height = Height;
        }

        protected override void MouseWheelTransferData(MouseEventArgs e)
        {
            if (e.Delta.Equals(120))
            {
                Width += 2;
                Height += 1;
            }

            else if (e.Delta.Equals(-120))
            {
                Width -= 2;
                Height -= 1;
            }
        }

        #endregion
    }
}
