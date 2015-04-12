using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using System.Drawing;
using AnotherSc2Hack.Classes.ExtensionMethods;
using PredefinedTypes = Predefined.PredefinedData;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    public class WorkerCoachRenderer : BaseRenderer
    {

        private Int32 _iTimerBegin = 0;
        private Int32 _iTimerEnd = 0;
        private Int32 _iTimerSum = 0;
        private Boolean _bJustGotInactive = false;
        private List<int> _lWorkerIdle = new List<int>();
        private Image _imgWorker = Properties.Resources.trans_tu_scv;
        private Image _imgSpecial = Properties.Resources.trans_tu_mule;


        public WorkerCoachRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
            : base(gInformation, pSettings, sc2Process)
        {
            
        }

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
                    _iTimerSum = 0;
                    _iTimerEnd = 0;
                    _iTimerBegin = 0;
                    return;
                }

                if (GInformation.Player.Count <= 0 ||
                    GInformation.Unit.Count <= 0)
                    return;

                if (!GInformation.Player.HasLocalplayer)
                    return;

                if (GInformation.Player.LocalplayerIndex == 16)
                    return;


                if (GInformation.Gameinfo.Timer / 60 >= PSettings.PreferenceAll.OverlayWorkerCoach.DisableAfter)
                    return;

                #endregion

                var localPlayer = GInformation.Player[GInformation.Player.LocalplayerIndex];

                var iUnusedWorkers = 0;
                var iUnusedEnergy = 0;


                foreach (var unit in localPlayer.Units)
                {
                    if (localPlayer.Minerals < 50)
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

                    g.Graphics.DrawImage(_imgWorker, new Rectangle(33, 28, 36, 36));
                    

                    /*g.Graphics.DrawString(strText + " [" + strTextSum + "]", Font, Brushes.DarkOrange, new PointF(75 + 33, 28));
                    g.Graphics.DrawString(iUnusedWorkers.ToString(), Font, Brushes.DarkOrange, new PointF(41 + 33, 28));*/
                }


                if (iUnusedEnergy > 0)
                {
                    g.Graphics.DrawImage(_imgSpecial, new Rectangle(33, 28 + 36, 36, 36));
                    //g.Graphics.DrawString(iUnusedEnergy.ToString(), Font, Brushes.DarkOrange, new PointF(41 + 33, 28 + 40));
                }
            }

            catch (Exception ex)
            {
                
            }
        }

        protected override void LoadSpecificData()
        {
            BackgroundImage = Properties.Resources.WorkerCoach;
            Font = new Font("Century Gothic", 20f);

            GInformation.NewMatch += GInformation_NewMatch;
        }

        void GInformation_NewMatch(object sender, EventArgs e)
        {
            _iTimerBegin = 0;
            

            if (GInformation.Player.HasLocalplayer)
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
    }
}
