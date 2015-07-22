using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using PredefinedTypes;
using Utilities.ExtensionMethods;
using Utilities.Logger;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    class AlertRenderer : BaseRenderer
    {
        private List<PlayerStore> _playerStores = new List<PlayerStore>(16);
        private Dictionary<UnitId, Image> _dictionaryUnits = new Dictionary<UnitId, Image>();

        public AlertRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
            : base(gInformation, pSettings, sc2Process)
        {
            gInformation.NewMatch += gInformation_NewMatch;

            FillDictionary();
        }

        void gInformation_NewMatch(object sender, EventArgs e)
        {
            _playerStores.Clear();
        }

        private void FillDictionary()
        {            
            _dictionaryUnits.Add(UnitId.PbAssimilator, Properties.Resources.trans_pb_assimilator);
            _dictionaryUnits.Add(UnitId.PbCannon, Properties.Resources.trans_pb_photoncannon);
            _dictionaryUnits.Add(UnitId.PbCybercore, Properties.Resources.trans_pb_cyberneticscore);
            _dictionaryUnits.Add(UnitId.PbDarkshrine, Properties.Resources.trans_pb_darkshrine);
            _dictionaryUnits.Add(UnitId.PbFleetbeacon, Properties.Resources.trans_pb_fleetbeacon);
            _dictionaryUnits.Add(UnitId.PbForge, Properties.Resources.trans_pb_forge);
            _dictionaryUnits.Add(UnitId.PbGateway, Properties.Resources.trans_pb_gateway);
            _dictionaryUnits.Add(UnitId.PbNexus, Properties.Resources.trans_pb_nexus);
            _dictionaryUnits.Add(UnitId.PbPylon, Properties.Resources.trans_pb_pylon);
            _dictionaryUnits.Add(UnitId.PbRoboticsbay, Properties.Resources.trans_pb_roboticsbay);                  //ToDo: Check this!
            _dictionaryUnits.Add(UnitId.PbRoboticssupportbay, Properties.Resources.trans_pb_roboticsfacility);
            _dictionaryUnits.Add(UnitId.PbStargate, Properties.Resources.trans_pb_stargate);
            _dictionaryUnits.Add(UnitId.PbTemplararchives, Properties.Resources.trans_pb_templararchive);
            _dictionaryUnits.Add(UnitId.PbTwilightcouncil, Properties.Resources.trans_pb_twilightcouncil);
            _dictionaryUnits.Add(UnitId.PbWarpgate, Properties.Resources.trans_pb_warpgate);
            _dictionaryUnits.Add(UnitId.PuArchon, Properties.Resources.trans_pu_archon);
            _dictionaryUnits.Add(UnitId.PuCarrier, Properties.Resources.trans_pu_carrier);
            _dictionaryUnits.Add(UnitId.PuColossus, Properties.Resources.trans_pu_colossus);
            _dictionaryUnits.Add(UnitId.PuDarktemplar, Properties.Resources.trans_pu_darktemplar);
            _dictionaryUnits.Add(UnitId.PuForceField, Properties.Resources.PuForceField);   //ToDo: Fix this with an actual forceField picture (transparent)
            _dictionaryUnits.Add(UnitId.PuHightemplar, Properties.Resources.trans_pu_hightemplar);
            _dictionaryUnits.Add(UnitId.PuImmortal, Properties.Resources.trans_pu_immortal);
            _dictionaryUnits.Add(UnitId.PuInterceptor, Properties.Resources.trans_pu_interceptor);
            _dictionaryUnits.Add(UnitId.PuMothership, Properties.Resources.trans_pu_mothership);
            _dictionaryUnits.Add(UnitId.PuMothershipCore, Properties.Resources.trans_pu_mothershipcore);
            _dictionaryUnits.Add(UnitId.PuObserver, Properties.Resources.trans_pu_observer);
            _dictionaryUnits.Add(UnitId.PuOracle, Properties.Resources.trans_pu_oracle);
            _dictionaryUnits.Add(UnitId.PuPhoenix, Properties.Resources.trans_pu_phoenix);
            _dictionaryUnits.Add(UnitId.PuProbe, Properties.Resources.trans_pu_probe);
            _dictionaryUnits.Add(UnitId.PuSentry, Properties.Resources.trans_pu_sentry);
            _dictionaryUnits.Add(UnitId.PuStalker, Properties.Resources.trans_pu_stalker);
            _dictionaryUnits.Add(UnitId.PuTempest, Properties.Resources.trans_pu_tempest);
            _dictionaryUnits.Add(UnitId.PuVoidray, Properties.Resources.trans_pu_voidray);
            _dictionaryUnits.Add(UnitId.PuWarpprismPhase, Properties.Resources.trans_pu_warpprismphasing);
            _dictionaryUnits.Add(UnitId.PuWarpprismTransport, Properties.Resources.trans_pu_warpprism);
            _dictionaryUnits.Add(UnitId.PuZealot, Properties.Resources.trans_pu_zealot);
            _dictionaryUnits.Add(UnitId.TbArmory, Properties.Resources.trans_tb_armory);
            _dictionaryUnits.Add(UnitId.TbAutoTurret, Properties.Resources.trans_tb_autoturret);
            _dictionaryUnits.Add(UnitId.TbBarracksGround, Properties.Resources.trans_tb_barracks);
            _dictionaryUnits.Add(UnitId.TbBunker, Properties.Resources.trans_tb_bunker);
            _dictionaryUnits.Add(UnitId.TbCcAir, Properties.Resources.trans_tb_commandcenter);
            _dictionaryUnits.Add(UnitId.TbCcGround, Properties.Resources.trans_tb_commandcenter);
            _dictionaryUnits.Add(UnitId.TbEbay, Properties.Resources.trans_tb_engineeringbay);
            _dictionaryUnits.Add(UnitId.TbFactoryAir, Properties.Resources.trans_tb_factory);
            _dictionaryUnits.Add(UnitId.TbFactoryGround, Properties.Resources.trans_tb_factory);
            _dictionaryUnits.Add(UnitId.TbFusioncore, Properties.Resources.trans_tb_fusioncore);
            _dictionaryUnits.Add(UnitId.TbGhostacademy, Properties.Resources.trans_tb_ghostacademy);
            _dictionaryUnits.Add(UnitId.TbOrbitalAir, Properties.Resources.trans_tb_orbitalcommand);
            _dictionaryUnits.Add(UnitId.TbOrbitalGround, Properties.Resources.trans_tb_orbitalcommand);
            _dictionaryUnits.Add(UnitId.TbPlanetary, Properties.Resources.trans_tb_planetaryfortress);
            _dictionaryUnits.Add(UnitId.TbRaxAir, Properties.Resources.trans_tb_barracks);
            _dictionaryUnits.Add(UnitId.TbReactor, Properties.Resources.trans_tb_reactor);
            _dictionaryUnits.Add(UnitId.TbReactorFactory, Properties.Resources.trans_tb_reactor);   //ToDo: Add Factory Reactor
            _dictionaryUnits.Add(UnitId.TbReactorRax, Properties.Resources.trans_tb_reactor);       //ToDo: Add Barracks Reactor
            _dictionaryUnits.Add(UnitId.TbReactorStarport, Properties.Resources.trans_tb_reactor);  //ToDo: Add Starport Reactor
            _dictionaryUnits.Add(UnitId.TbRefinery, Properties.Resources.trans_tb_refinery);
            _dictionaryUnits.Add(UnitId.TbSensortower, Properties.Resources.trans_tb_sensortower);
            _dictionaryUnits.Add(UnitId.TbStarportAir, Properties.Resources.trans_tb_starport);
            _dictionaryUnits.Add(UnitId.TbStarportGround, Properties.Resources.trans_tb_starport);
            _dictionaryUnits.Add(UnitId.TbSupplyGround, Properties.Resources.trans_tb_supplydepot);
            _dictionaryUnits.Add(UnitId.TbSupplyHidden, Properties.Resources.trans_tb_supplydepotlowered);
            _dictionaryUnits.Add(UnitId.TbTechlab, Properties.Resources.trans_tb_techlab);
            _dictionaryUnits.Add(UnitId.TbTechlabFactory, Properties.Resources.trans_tb_techlab);   //ToDo: Add Factory Techlab
            _dictionaryUnits.Add(UnitId.TbTechlabRax, Properties.Resources.trans_tb_techlab);       //ToDo: Add Barracks Techlab
            _dictionaryUnits.Add(UnitId.TbTechlabStarport, Properties.Resources.trans_tb_techlab);  //ToDo: Add Starport Techlab
            _dictionaryUnits.Add(UnitId.TbTurret, Properties.Resources.trans_tb_missileturret);
            _dictionaryUnits.Add(UnitId.TuBanshee, Properties.Resources.trans_tu_banshee);
            _dictionaryUnits.Add(UnitId.TuBattlecruiser, Properties.Resources.trans_tu_battlecruiser);
            _dictionaryUnits.Add(UnitId.TuGhost, Properties.Resources.trans_tu_ghost);
            _dictionaryUnits.Add(UnitId.TuHellbat, Properties.Resources.trans_tu_hellbat);
            _dictionaryUnits.Add(UnitId.TuHellion, Properties.Resources.trans_tu_hellion);
            _dictionaryUnits.Add(UnitId.TuMarauder, Properties.Resources.trans_tu_marauder);
            _dictionaryUnits.Add(UnitId.TuMarine, Properties.Resources.trans_tu_marine);
            _dictionaryUnits.Add(UnitId.TuMedivac, Properties.Resources.trans_tu_medivac);
            _dictionaryUnits.Add(UnitId.TuMule, Properties.Resources.trans_tu_mule);
            _dictionaryUnits.Add(UnitId.TuNuke, Properties.Resources.trans_tu_nuke);
            _dictionaryUnits.Add(UnitId.TuPdd, Properties.Resources.trans_tu_pdd);
            _dictionaryUnits.Add(UnitId.TuRaven, Properties.Resources.trans_tu_raven);
            _dictionaryUnits.Add(UnitId.TuReaper, Properties.Resources.trans_tu_reaper);
            _dictionaryUnits.Add(UnitId.TuScv, Properties.Resources.trans_tu_scv);
            _dictionaryUnits.Add(UnitId.TuSiegetank, Properties.Resources.trans_tu_siegetank);
            _dictionaryUnits.Add(UnitId.TuSiegetankSieged, Properties.Resources.trans_tu_siegetank);    //ToDo: Add Sieged Siegetank
            _dictionaryUnits.Add(UnitId.TuThor, Properties.Resources.trans_tu_thor);
            _dictionaryUnits.Add(UnitId.TuVikingAir, Properties.Resources.trans_tu_vikingair);
            _dictionaryUnits.Add(UnitId.TuVikingGround, Properties.Resources.trans_tu_vikingair);       //ToDo: Add Viking on Ground
            //_dictionaryUnits.Add(UnitId.TuWarhound, Properties.Resources.trans_warh);                 //ToDo: Add Warhound
            _dictionaryUnits.Add(UnitId.TuWidowMine, Properties.Resources.trans_tu_widowmine);
            _dictionaryUnits.Add(UnitId.TuWidowMineBurrow, Properties.Resources.trans_tu_widowmine);
            _dictionaryUnits.Add(UnitId.ZbBanelingNest, Properties.Resources.trans_zb_banelingnest);
            _dictionaryUnits.Add(UnitId.ZbCreeptumor, Properties.Resources.trans_zb_creeptumor);
            _dictionaryUnits.Add(UnitId.ZbCreepTumorBuilding, Properties.Resources.trans_zb_creeptumor);
            _dictionaryUnits.Add(UnitId.ZbCreeptumorBurrowed, Properties.Resources.trans_zb_creeptumor);
            _dictionaryUnits.Add(UnitId.ZbCreepTumorMissle, Properties.Resources.trans_zb_creeptumor);
            _dictionaryUnits.Add(UnitId.ZbEvolutionChamber, Properties.Resources.trans_zb_evolutionchamber);
            _dictionaryUnits.Add(UnitId.ZbExtractor, Properties.Resources.trans_zb_extractor);
            _dictionaryUnits.Add(UnitId.ZbGreaterspire, Properties.Resources.trans_zb_greaterspire);
            _dictionaryUnits.Add(UnitId.ZbHatchery, Properties.Resources.trans_zb_hatchery);
            _dictionaryUnits.Add(UnitId.ZbHive, Properties.Resources.trans_zb_hive);
            _dictionaryUnits.Add(UnitId.ZbHydraDen, Properties.Resources.trans_zb_hydraliskden);
            _dictionaryUnits.Add(UnitId.ZbInfestationPit, Properties.Resources.trans_zb_infestationpit);
            _dictionaryUnits.Add(UnitId.ZbLiar, Properties.Resources.trans_zb_lair);
            _dictionaryUnits.Add(UnitId.ZbNydusNetwork, Properties.Resources.trans_zb_nydusnetwork);
            _dictionaryUnits.Add(UnitId.ZbNydusWorm, Properties.Resources.trans_zb_nyduscanal);
            _dictionaryUnits.Add(UnitId.ZbRoachWarren, Properties.Resources.trans_zb_roachwarren);
            _dictionaryUnits.Add(UnitId.ZbSpawningPool, Properties.Resources.trans_zb_spawningpool);
            _dictionaryUnits.Add(UnitId.ZbSpineCrawler, Properties.Resources.trans_zb_spinecrawler);
            _dictionaryUnits.Add(UnitId.ZbSpineCrawlerUnrooted, Properties.Resources.trans_zb_spinecrawler);    //ToDo: Add unrooted Spinecrawler
            _dictionaryUnits.Add(UnitId.ZbSpire, Properties.Resources.trans_zb_spire);
            _dictionaryUnits.Add(UnitId.ZbSporeCrawler, Properties.Resources.trans_zb_sporecrawler);
            _dictionaryUnits.Add(UnitId.ZbSporeCrawlerUnrooted, Properties.Resources.trans_zb_sporecrawler);    //ToDo: Add unrooted Sporecrawler
            _dictionaryUnits.Add(UnitId.ZbUltraCavern, Properties.Resources.trans_zb_ultraliskcavern);
            _dictionaryUnits.Add(UnitId.ZuBaneling, Properties.Resources.trans_zu_baneling);
            _dictionaryUnits.Add(UnitId.ZuBanelingBurrow, Properties.Resources.trans_zu_baneling);
            _dictionaryUnits.Add(UnitId.ZuBanelingCocoon, Properties.Resources.trans_zu_banelingcocoon);
            //_dictionaryUnits.Add(UnitId.ZuBroodling, Properties.Resources.bro);                               //ToDo: Add Broodling
            _dictionaryUnits.Add(UnitId.ZuBroodlord, Properties.Resources.trans_zu_broodlord);
            _dictionaryUnits.Add(UnitId.ZuBroodlordCocoon, Properties.Resources.trans_zu_BroodLordCocoon);
            _dictionaryUnits.Add(UnitId.ZuChangeling, Properties.Resources.trans_zu_changeling);
            _dictionaryUnits.Add(UnitId.ZuChangelingMarine, Properties.Resources.trans_zu_changeling);
            _dictionaryUnits.Add(UnitId.ZuChangelingMarineShield, Properties.Resources.trans_zu_changeling);
            _dictionaryUnits.Add(UnitId.ZuChangelingSpeedling, Properties.Resources.trans_zu_changeling);
            _dictionaryUnits.Add(UnitId.ZuChangelingZealot, Properties.Resources.trans_zu_changeling);
            _dictionaryUnits.Add(UnitId.ZuChangelingZergling, Properties.Resources.trans_zu_changeling);
            _dictionaryUnits.Add(UnitId.ZuCorruptor, Properties.Resources.trans_zu_corruptor);
            _dictionaryUnits.Add(UnitId.ZuDrone, Properties.Resources.trans_zu_drone);
            _dictionaryUnits.Add(UnitId.ZuDroneBurrow, Properties.Resources.trans_zu_drone);
            _dictionaryUnits.Add(UnitId.ZuEgg, Properties.Resources.trans_zu_egg);
            _dictionaryUnits.Add(UnitId.ZuHydraBurrow, Properties.Resources.trans_zu_hydralisk);
            _dictionaryUnits.Add(UnitId.ZuHydralisk, Properties.Resources.trans_zu_hydralisk);
            //_dictionaryUnits.Add(UnitId.ZuInfestedSwarmEgg, Properties.Resources.trans_infe);                 //ToDo: Add Infested Swarm Egg (Infested Terran Spawn)
            _dictionaryUnits.Add(UnitId.ZuInfestedTerran, Properties.Resources.trans_zu_InfestedTerran);
            _dictionaryUnits.Add(UnitId.ZuInfestedTerran2, Properties.Resources.trans_zu_InfestedTerran);
            _dictionaryUnits.Add(UnitId.ZuInfestor, Properties.Resources.trans_zu_infestor);
            _dictionaryUnits.Add(UnitId.ZuInfestorBurrow, Properties.Resources.trans_zu_infestor);
            _dictionaryUnits.Add(UnitId.ZuLarva, Properties.Resources.trans_zu_larva);
            _dictionaryUnits.Add(UnitId.ZuLocust, Properties.Resources.trans_zu_locust);
            _dictionaryUnits.Add(UnitId.ZuMutalisk, Properties.Resources.trans_zu_mutalisk);
            _dictionaryUnits.Add(UnitId.ZuOverlord, Properties.Resources.trans_zu_overlord);
            _dictionaryUnits.Add(UnitId.ZuOverseer, Properties.Resources.trans_zu_overseer);
            _dictionaryUnits.Add(UnitId.ZuOverseerCocoon, Properties.Resources.trans_zu_OverlordCocoon);
            _dictionaryUnits.Add(UnitId.ZuQueen, Properties.Resources.trans_zu_queen);
            _dictionaryUnits.Add(UnitId.ZuQueenBurrow, Properties.Resources.trans_zu_queen);
            _dictionaryUnits.Add(UnitId.ZuRoach, Properties.Resources.trans_zu_roach);
            _dictionaryUnits.Add(UnitId.ZuRoachBurrow, Properties.Resources.trans_zu_roach);
            _dictionaryUnits.Add(UnitId.ZuSwarmHost, Properties.Resources.trans_zu_swarmhost);
            _dictionaryUnits.Add(UnitId.ZuSwarmHostBurrow, Properties.Resources.trans_zu_swarmhost);
            _dictionaryUnits.Add(UnitId.ZuUltra, Properties.Resources.trans_zu_ultralisk);
            _dictionaryUnits.Add(UnitId.ZuUltraBurrow, Properties.Resources.trans_zu_ultralisk);
            _dictionaryUnits.Add(UnitId.ZuViper, Properties.Resources.trans_zu_viper);
            _dictionaryUnits.Add(UnitId.ZuZergling, Properties.Resources.trans_zu_zergling);
            _dictionaryUnits.Add(UnitId.ZuZerglingBurrow, Properties.Resources.trans_zu_zergling);

        }

        private bool _bWorkerState = true;

        private void UnitWorker()
        {
           
                #region Exceptions

                if (GInformation == null)
                    return;

                if (GInformation.Gameinfo == null)
                    return;

                if (!GInformation.Gameinfo.IsIngame)
                    return;

                if (PSettings.PreferenceAll.OverlayAlert.UnitIds.Count <= 0)
                    return;

                if (GInformation.Player.Count <= 0)
                    return;

                if (GInformation.Unit.Count <= 0)
                    return;

                #endregion


                var players = new List<PlayerStore>(_playerStores);

                for (var index = 0; index < GInformation.Player.Count; index++)
                {
                    var player = GInformation.Player[index];
                    if (index >= players.Count)
                    {
                        players.Add(new PlayerStore(player.Name));
                        players[index].Color = player.Color;
                    }

                    #region Exceptions 
                    
                    if (player == Player.LocalPlayer)
                        continue;

                    if (player.Team == Player.LocalPlayer.Team)
                        continue;

                    if (player.Type != PlayerType.Ai &&
                        player.Type != PlayerType.Human)
                        continue;

                    #endregion

                    foreach (var unitId in PSettings.PreferenceAll.OverlayAlert.UnitIds)
                    {
                        DateTime initDate;

                        try
                        {

                            initDate = players[index].Units[unitId];

                            
                        }

                        catch (KeyNotFoundException ex)
                        {
                            //Console.WriteLine(unitId);
                            //var unit = player.Units.Find(x => x.Id == unitId);
                            players[index].Units.Add(unitId, DateTime.Now);

                        }

                        catch (Exception ex)
                        {
                            //Console.WriteLine(ex);
                            Logger.Emit("UnitWorker (Iterate Units of player)", ex);
                        }
                    }

                }

                _playerStores = players;
        }

        protected override void Draw(BufferedGraphics g)
        {
            var fPenWidth = 3f;

            UnitWorker();

            Console.WriteLine(_playerStores.Count);

            var fPosX = fPenWidth;
            var fPosY = fPenWidth;

            foreach (var playerStore in _playerStores)
            {
                foreach (var playerUnit in playerStore.Units)
                {
                    if ((DateTime.Now - playerUnit.Value).Seconds >= PSettings.PreferenceAll.OverlayAlert.Time)
                        continue;

                    try
                    {
                        g.Graphics.DrawImage(_dictionaryUnits[playerUnit.Key],
                            fPosX,
                            fPosY,
                            PSettings.PreferenceAll.OverlayAlert.IconWidth,
                            PSettings.PreferenceAll.OverlayAlert.IconHeight);
                    }

                    catch (KeyNotFoundException ex)
                    {
                        Logger.Emit("Draw Alert", ex);
                    }

                    g.Graphics.DrawRectangle(new Pen(playerStore.Color, fPenWidth), fPosX - (fPenWidth / 2), fPosY - (fPenWidth / 2),
                        PSettings.PreferenceAll.OverlayAlert.IconWidth + fPenWidth,
                        PSettings.PreferenceAll.OverlayAlert.IconHeight + fPenWidth);

                    //Set position for the next panel
                    fPosX += PSettings.PreferenceAll.OverlayAlert.IconWidth + (int)fPenWidth * 2;

                    //Resize properly
                    if (fPosX >= ClientSize.Width)
                        ClientSize = new Size((int)fPosX - (int)(fPenWidth), (int)fPosY + PSettings.PreferenceAll.OverlayAlert.IconHeight + (int)fPenWidth * 2);
                }
            }
        }

        protected override void LoadSpecificData()
        {
            /* Nothing */
        }

        protected override void BaseRenderer_ResizeEnd(object sender, EventArgs e)
        {
            PSettings.PreferenceAll.OverlayAlert.Height = Height;
            PSettings.PreferenceAll.OverlayAlert.Width = Width;
            PSettings.PreferenceAll.OverlayAlert.X = Location.X;
            PSettings.PreferenceAll.OverlayAlert.Y = Location.Y;
        }

        protected override void AdjustPanelSize()
        {
            /* Nothing */
        }

        protected override void AdjustPanelPosition()
        {
            /* Nothing */
        }

        protected override void LoadPreferencesIntoControls()
        {
            Location = new Point(PSettings.PreferenceAll.OverlayAlert.X,
                                     PSettings.PreferenceAll.OverlayAlert.Y);
            Size = new Size(PSettings.PreferenceAll.OverlayAlert.Width,
                            PSettings.PreferenceAll.OverlayAlert.Height);
        }

        protected override void MouseUpTransferData()
        {
            PSettings.PreferenceAll.OverlayAlert.X = Location.X;
            PSettings.PreferenceAll.OverlayAlert.Y = Location.Y;
            PSettings.PreferenceAll.OverlayAlert.Width = Width;
            PSettings.PreferenceAll.OverlayAlert.Height = Height; 
        }

        protected override void MouseWheelTransferData(System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta.Equals(120))
            {
                Width += 1;
                Height += 1;
            }

            else if (e.Delta.Equals(-120))
            {
                Width -= 1;
                Height -= 1;
            }
        }
    }

    internal class PlayerStore
    {
        public Dictionary<UnitId, DateTime> Units { get; set; }
        public string PlayerName { get; set; }
        public Color Color { get; set; }

        public PlayerStore(string playerName)
        {
            Units = new Dictionary<UnitId, DateTime>();
            PlayerName = playerName;
            Color = Color.Red;
            
        }
    }
}
