using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using AnotherSc2Hack.Properties;
using PredefinedTypes;
using Utilities.Logger;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    internal class AlertRenderer : BaseRenderer
    {
        private readonly Dictionary<UnitId, Image> _dictionaryUnits = new Dictionary<UnitId, Image>();
        private bool _bWorkerState = true;
        private List<PlayerStore> _playerStores = new List<PlayerStore>(16);

        public AlertRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
            : base(gInformation, pSettings, sc2Process)
        {
            gInformation.NewMatch += gInformation_NewMatch;

            FillDictionary();

            ShowCalled += AlertRenderer_ShowCalled;
            HideCalled += AlertRenderer_HideCalled;
        }

        private void AlertRenderer_HideCalled(object sender, EventArgs e)
        {
            _bWorkerState = false;
        }

        private void AlertRenderer_ShowCalled(object sender, EventArgs e)
        {
            _bWorkerState = true;

            new Thread(UnitWorker)
            {
                Name = "AlertRenderer > UnitWorker"
            }.Start();
        }

        private void gInformation_NewMatch(object sender, EventArgs e)
        {
            _playerStores.Clear();
        }

        private void FillDictionary()
        {
            _dictionaryUnits.Add(UnitId.PbAssimilator, Resources.trans_pb_assimilator);
            _dictionaryUnits.Add(UnitId.PbCannon, Resources.trans_pb_photoncannon);
            _dictionaryUnits.Add(UnitId.PbCybercore, Resources.trans_pb_cyberneticscore);
            _dictionaryUnits.Add(UnitId.PbDarkshrine, Resources.trans_pb_darkshrine);
            _dictionaryUnits.Add(UnitId.PbFleetbeacon, Resources.trans_pb_fleetbeacon);
            _dictionaryUnits.Add(UnitId.PbForge, Resources.trans_pb_forge);
            _dictionaryUnits.Add(UnitId.PbGateway, Resources.trans_pb_gateway);
            _dictionaryUnits.Add(UnitId.PbNexus, Resources.trans_pb_nexus);
            _dictionaryUnits.Add(UnitId.PbPylon, Resources.trans_pb_pylon);
            _dictionaryUnits.Add(UnitId.PbRoboticsbay, Resources.trans_pb_roboticsfacility); //ToDo: Check this!
            _dictionaryUnits.Add(UnitId.PbRoboticssupportbay, Resources.trans_pb_roboticsbay);
            _dictionaryUnits.Add(UnitId.PbStargate, Resources.trans_pb_stargate);
            _dictionaryUnits.Add(UnitId.PbTemplararchives, Resources.trans_pb_templararchive);
            _dictionaryUnits.Add(UnitId.PbTwilightcouncil, Resources.trans_pb_twilightcouncil);
            _dictionaryUnits.Add(UnitId.PbWarpgate, Resources.trans_pb_warpgate);
            _dictionaryUnits.Add(UnitId.PuArchon, Resources.trans_pu_archon);
            _dictionaryUnits.Add(UnitId.PuCarrier, Resources.trans_pu_carrier);
            _dictionaryUnits.Add(UnitId.PuColossus, Resources.trans_pu_colossus);
            _dictionaryUnits.Add(UnitId.PuDarktemplar, Resources.trans_pu_darktemplar);
            _dictionaryUnits.Add(UnitId.PuForceField, Resources.PuForceField);
                //ToDo: Fix this with an actual forceField picture (transparent)
            _dictionaryUnits.Add(UnitId.PuHightemplar, Resources.trans_pu_hightemplar);
            _dictionaryUnits.Add(UnitId.PuImmortal, Resources.trans_pu_immortal);
            _dictionaryUnits.Add(UnitId.PuInterceptor, Resources.trans_pu_interceptor);
            _dictionaryUnits.Add(UnitId.PuMothership, Resources.trans_pu_mothership);
            _dictionaryUnits.Add(UnitId.PuMothershipCore, Resources.trans_pu_mothershipcore);
            _dictionaryUnits.Add(UnitId.PuObserver, Resources.trans_pu_observer);
            _dictionaryUnits.Add(UnitId.PuOracle, Resources.trans_pu_oracle);
            _dictionaryUnits.Add(UnitId.PuPhoenix, Resources.trans_pu_phoenix);
            _dictionaryUnits.Add(UnitId.PuProbe, Resources.trans_pu_probe);
            _dictionaryUnits.Add(UnitId.PuSentry, Resources.trans_pu_sentry);
            _dictionaryUnits.Add(UnitId.PuStalker, Resources.trans_pu_stalker);
            _dictionaryUnits.Add(UnitId.PuTempest, Resources.trans_pu_tempest);
            _dictionaryUnits.Add(UnitId.PuVoidray, Resources.trans_pu_voidray);
            _dictionaryUnits.Add(UnitId.PuWarpprismPhase, Resources.trans_pu_warpprismphasing);
            _dictionaryUnits.Add(UnitId.PuWarpprismTransport, Resources.trans_pu_warpprism);
            _dictionaryUnits.Add(UnitId.PuZealot, Resources.trans_pu_zealot);
            _dictionaryUnits.Add(UnitId.TbArmory, Resources.trans_tb_armory);
            _dictionaryUnits.Add(UnitId.TbAutoTurret, Resources.trans_tb_autoturret);
            _dictionaryUnits.Add(UnitId.TbBarracksGround, Resources.trans_tb_barracks);
            _dictionaryUnits.Add(UnitId.TbBunker, Resources.trans_tb_bunker);
            _dictionaryUnits.Add(UnitId.TbCcAir, Resources.trans_tb_commandcenter);
            _dictionaryUnits.Add(UnitId.TbCcGround, Resources.trans_tb_commandcenter);
            _dictionaryUnits.Add(UnitId.TbEbay, Resources.trans_tb_engineeringbay);
            _dictionaryUnits.Add(UnitId.TbFactoryAir, Resources.trans_tb_factory);
            _dictionaryUnits.Add(UnitId.TbFactoryGround, Resources.trans_tb_factory);
            _dictionaryUnits.Add(UnitId.TbFusioncore, Resources.trans_tb_fusioncore);
            _dictionaryUnits.Add(UnitId.TbGhostacademy, Resources.trans_tb_ghostacademy);
            _dictionaryUnits.Add(UnitId.TbOrbitalAir, Resources.trans_tb_orbitalcommand);
            _dictionaryUnits.Add(UnitId.TbOrbitalGround, Resources.trans_tb_orbitalcommand);
            _dictionaryUnits.Add(UnitId.TbPlanetary, Resources.trans_tb_planetaryfortress);
            _dictionaryUnits.Add(UnitId.TbRaxAir, Resources.trans_tb_barracks);
            _dictionaryUnits.Add(UnitId.TbReactor, Resources.trans_tb_reactor);
            _dictionaryUnits.Add(UnitId.TbReactorFactory, Resources.trans_tb_reactor); //ToDo: Add Factory Reactor
            _dictionaryUnits.Add(UnitId.TbReactorRax, Resources.trans_tb_reactor); //ToDo: Add Barracks Reactor
            _dictionaryUnits.Add(UnitId.TbReactorStarport, Resources.trans_tb_reactor); //ToDo: Add Starport Reactor
            _dictionaryUnits.Add(UnitId.TbRefinery, Resources.trans_tb_refinery);
            _dictionaryUnits.Add(UnitId.TbSensortower, Resources.trans_tb_sensortower);
            _dictionaryUnits.Add(UnitId.TbStarportAir, Resources.trans_tb_starport);
            _dictionaryUnits.Add(UnitId.TbStarportGround, Resources.trans_tb_starport);
            _dictionaryUnits.Add(UnitId.TbSupplyGround, Resources.trans_tb_supplydepot);
            _dictionaryUnits.Add(UnitId.TbSupplyHidden, Resources.trans_tb_supplydepotlowered);
            _dictionaryUnits.Add(UnitId.TbTechlab, Resources.trans_tb_techlab);
            _dictionaryUnits.Add(UnitId.TbTechlabFactory, Resources.trans_tb_techlab); //ToDo: Add Factory Techlab
            _dictionaryUnits.Add(UnitId.TbTechlabRax, Resources.trans_tb_techlab); //ToDo: Add Barracks Techlab
            _dictionaryUnits.Add(UnitId.TbTechlabStarport, Resources.trans_tb_techlab); //ToDo: Add Starport Techlab
            _dictionaryUnits.Add(UnitId.TbTurret, Resources.trans_tb_missileturret);
            _dictionaryUnits.Add(UnitId.TuBanshee, Resources.trans_tu_banshee);
            _dictionaryUnits.Add(UnitId.TuBattlecruiser, Resources.trans_tu_battlecruiser);
            _dictionaryUnits.Add(UnitId.TuGhost, Resources.trans_tu_ghost);
            _dictionaryUnits.Add(UnitId.TuHellbat, Resources.trans_tu_hellbat);
            _dictionaryUnits.Add(UnitId.TuHellion, Resources.trans_tu_hellion);
            _dictionaryUnits.Add(UnitId.TuMarauder, Resources.trans_tu_marauder);
            _dictionaryUnits.Add(UnitId.TuMarine, Resources.trans_tu_marine);
            _dictionaryUnits.Add(UnitId.TuMedivac, Resources.trans_tu_medivac);
            _dictionaryUnits.Add(UnitId.TuMule, Resources.trans_tu_mule);
            _dictionaryUnits.Add(UnitId.TuNuke, Resources.trans_tu_nuke);
            _dictionaryUnits.Add(UnitId.TuPdd, Resources.trans_tu_pdd);
            _dictionaryUnits.Add(UnitId.TuRaven, Resources.trans_tu_raven);
            _dictionaryUnits.Add(UnitId.TuReaper, Resources.trans_tu_reaper);
            _dictionaryUnits.Add(UnitId.TuScv, Resources.trans_tu_scv);
            _dictionaryUnits.Add(UnitId.TuSiegetank, Resources.trans_tu_siegetank);
            _dictionaryUnits.Add(UnitId.TuSiegetankSieged, Resources.trans_tu_siegetank); //ToDo: Add Sieged Siegetank
            _dictionaryUnits.Add(UnitId.TuThor, Resources.trans_tu_thor);
            _dictionaryUnits.Add(UnitId.TuVikingAir, Resources.trans_tu_vikingair);
            _dictionaryUnits.Add(UnitId.TuVikingGround, Resources.trans_tu_vikingair); //ToDo: Add Viking on Ground
            //_dictionaryUnits.Add(UnitId.TuWarhound, Properties.Resources.trans_warh);                 //ToDo: Add Warhound
            _dictionaryUnits.Add(UnitId.TuWidowMine, Resources.trans_tu_widowmine);
            _dictionaryUnits.Add(UnitId.TuWidowMineBurrow, Resources.trans_tu_widowmine);
            _dictionaryUnits.Add(UnitId.ZbBanelingNest, Resources.trans_zb_banelingnest);
            _dictionaryUnits.Add(UnitId.ZbCreeptumor, Resources.trans_zb_creeptumor);
            _dictionaryUnits.Add(UnitId.ZbCreepTumorBuilding, Resources.trans_zb_creeptumor);
            _dictionaryUnits.Add(UnitId.ZbCreeptumorBurrowed, Resources.trans_zb_creeptumor);
            _dictionaryUnits.Add(UnitId.ZbCreepTumorMissle, Resources.trans_zb_creeptumor);
            _dictionaryUnits.Add(UnitId.ZbEvolutionChamber, Resources.trans_zb_evolutionchamber);
            _dictionaryUnits.Add(UnitId.ZbExtractor, Resources.trans_zb_extractor);
            _dictionaryUnits.Add(UnitId.ZbGreaterspire, Resources.trans_zb_greaterspire);
            _dictionaryUnits.Add(UnitId.ZbHatchery, Resources.trans_zb_hatchery);
            _dictionaryUnits.Add(UnitId.ZbHive, Resources.trans_zb_hive);
            _dictionaryUnits.Add(UnitId.ZbHydraDen, Resources.trans_zb_hydraliskden);
            _dictionaryUnits.Add(UnitId.ZbInfestationPit, Resources.trans_zb_infestationpit);
            _dictionaryUnits.Add(UnitId.ZbLiar, Resources.trans_zb_lair);
            _dictionaryUnits.Add(UnitId.ZbNydusNetwork, Resources.trans_zb_nydusnetwork);
            _dictionaryUnits.Add(UnitId.ZbNydusWorm, Resources.trans_zb_nyduscanal);
            _dictionaryUnits.Add(UnitId.ZbRoachWarren, Resources.trans_zb_roachwarren);
            _dictionaryUnits.Add(UnitId.ZbSpawningPool, Resources.trans_zb_spawningpool);
            _dictionaryUnits.Add(UnitId.ZbSpineCrawler, Resources.trans_zb_spinecrawler);
            _dictionaryUnits.Add(UnitId.ZbSpineCrawlerUnrooted, Resources.trans_zb_spinecrawler);
                //ToDo: Add unrooted Spinecrawler
            _dictionaryUnits.Add(UnitId.ZbSpire, Resources.trans_zb_spire);
            _dictionaryUnits.Add(UnitId.ZbSporeCrawler, Resources.trans_zb_sporecrawler);
            _dictionaryUnits.Add(UnitId.ZbSporeCrawlerUnrooted, Resources.trans_zb_sporecrawler);
                //ToDo: Add unrooted Sporecrawler
            _dictionaryUnits.Add(UnitId.ZbUltraCavern, Resources.trans_zb_ultraliskcavern);
            _dictionaryUnits.Add(UnitId.ZuBaneling, Resources.trans_zu_baneling);
            _dictionaryUnits.Add(UnitId.ZuBanelingBurrow, Resources.trans_zu_baneling);
            _dictionaryUnits.Add(UnitId.ZuBanelingCocoon, Resources.trans_zu_banelingcocoon);
            //_dictionaryUnits.Add(UnitId.ZuBroodling, Properties.Resources.bro);                               //ToDo: Add Broodling
            _dictionaryUnits.Add(UnitId.ZuBroodlord, Resources.trans_zu_broodlord);
            _dictionaryUnits.Add(UnitId.ZuBroodlordCocoon, Resources.trans_zu_BroodLordCocoon);
            _dictionaryUnits.Add(UnitId.ZuChangeling, Resources.trans_zu_changeling);
            _dictionaryUnits.Add(UnitId.ZuChangelingMarine, Resources.trans_zu_changeling);
            _dictionaryUnits.Add(UnitId.ZuChangelingMarineShield, Resources.trans_zu_changeling);
            _dictionaryUnits.Add(UnitId.ZuChangelingSpeedling, Resources.trans_zu_changeling);
            _dictionaryUnits.Add(UnitId.ZuChangelingZealot, Resources.trans_zu_changeling);
            _dictionaryUnits.Add(UnitId.ZuChangelingZergling, Resources.trans_zu_changeling);
            _dictionaryUnits.Add(UnitId.ZuCorruptor, Resources.trans_zu_corruptor);
            _dictionaryUnits.Add(UnitId.ZuDrone, Resources.trans_zu_drone);
            _dictionaryUnits.Add(UnitId.ZuDroneBurrow, Resources.trans_zu_drone);
            _dictionaryUnits.Add(UnitId.ZuEgg, Resources.trans_zu_egg);
            _dictionaryUnits.Add(UnitId.ZuHydraBurrow, Resources.trans_zu_hydralisk);
            _dictionaryUnits.Add(UnitId.ZuHydralisk, Resources.trans_zu_hydralisk);
            //_dictionaryUnits.Add(UnitId.ZuInfestedSwarmEgg, Properties.Resources.trans_infe);                 //ToDo: Add Infested Swarm Egg (Infested Terran Spawn)
            _dictionaryUnits.Add(UnitId.ZuInfestedTerran, Resources.trans_zu_InfestedTerran);
            _dictionaryUnits.Add(UnitId.ZuInfestedTerran2, Resources.trans_zu_InfestedTerran);
            _dictionaryUnits.Add(UnitId.ZuInfestor, Resources.trans_zu_infestor);
            _dictionaryUnits.Add(UnitId.ZuInfestorBurrow, Resources.trans_zu_infestor);
            _dictionaryUnits.Add(UnitId.ZuLarva, Resources.trans_zu_larva);
            _dictionaryUnits.Add(UnitId.ZuLocust, Resources.trans_zu_locust);
            _dictionaryUnits.Add(UnitId.ZuMutalisk, Resources.trans_zu_mutalisk);
            _dictionaryUnits.Add(UnitId.ZuOverlord, Resources.trans_zu_overlord);
            _dictionaryUnits.Add(UnitId.ZuOverseer, Resources.trans_zu_overseer);
            _dictionaryUnits.Add(UnitId.ZuOverseerCocoon, Resources.trans_zu_OverlordCocoon);
            _dictionaryUnits.Add(UnitId.ZuQueen, Resources.trans_zu_queen);
            _dictionaryUnits.Add(UnitId.ZuQueenBurrow, Resources.trans_zu_queen);
            _dictionaryUnits.Add(UnitId.ZuRoach, Resources.trans_zu_roach);
            _dictionaryUnits.Add(UnitId.ZuRoachBurrow, Resources.trans_zu_roach);
            _dictionaryUnits.Add(UnitId.ZuSwarmHost, Resources.trans_zu_swarmhost);
            _dictionaryUnits.Add(UnitId.ZuSwarmHostBurrow, Resources.trans_zu_swarmhost);
            _dictionaryUnits.Add(UnitId.ZuUltra, Resources.trans_zu_ultralisk);
            _dictionaryUnits.Add(UnitId.ZuUltraBurrow, Resources.trans_zu_ultralisk);
            _dictionaryUnits.Add(UnitId.ZuViper, Resources.trans_zu_viper);
            _dictionaryUnits.Add(UnitId.ZuZergling, Resources.trans_zu_zergling);
            _dictionaryUnits.Add(UnitId.ZuZerglingBurrow, Resources.trans_zu_zergling);

            _dictionaryUnits.Add(UnitId.TupBehemothReactor, Resources.trans_BehemothReactor);
            _dictionaryUnits.Add(UnitId.TupBlueFlame, Resources.trans_Tup_BlueFlame);
            _dictionaryUnits.Add(UnitId.TupCaduceusReactor, Resources.trans_Tup_CaduceusReactor);
            _dictionaryUnits.Add(UnitId.TupCloakingField, Resources.trans_Tup_CloakingField);
            _dictionaryUnits.Add(UnitId.TupCombatShields, Resources.trans_Tup_CombatShields);
            _dictionaryUnits.Add(UnitId.TupConcussiveShells, Resources.trans_Tup_ConcussiveShells);
            _dictionaryUnits.Add(UnitId.TupCorvidReactor, Resources.trans_Tup_CorvidReactor);
            _dictionaryUnits.Add(UnitId.TupDrillingClaws, Resources.trans_Tup_DrillingClaws);
            _dictionaryUnits.Add(UnitId.TupDurableMeterials, Resources.trans_Tup_DurableMaterials);
            _dictionaryUnits.Add(UnitId.TupHighSecAutoTracking, Resources.trans_Tup_HighSecAutotracking);
            _dictionaryUnits.Add(UnitId.TupInfantryArmor1, Resources.trans_Tup_InfantyArmor1);
            _dictionaryUnits.Add(UnitId.TupInfantryArmor2, Resources.trans_Tup_InfantyArmor2);
            _dictionaryUnits.Add(UnitId.TupInfantryArmor3, Resources.trans_Tup_InfantyArmor3);
            _dictionaryUnits.Add(UnitId.TupInfantryWeapon1, Resources.trans_Tup_InfantyWeapon1);
            _dictionaryUnits.Add(UnitId.TupInfantryWeapon2, Resources.trans_Tup_InfantyWeapon2);
            _dictionaryUnits.Add(UnitId.TupInfantryWeapon3, Resources.trans_Tup_InfantyWeapon3);
            _dictionaryUnits.Add(UnitId.TupMoebiusReactor, Resources.trans_Tup_MoebiusReactor);
            _dictionaryUnits.Add(UnitId.TupNeosteelFrame, Resources.trans_Tup_NeosteelFrame);
            _dictionaryUnits.Add(UnitId.TupPersonalCloak, Resources.trans_Tup_PersonalCloak);
            _dictionaryUnits.Add(UnitId.TupShipWeapon1, Resources.trans_Tup_ShipWeapon1);
            _dictionaryUnits.Add(UnitId.TupShipWeapon2, Resources.trans_Tup_ShipWeapon2);
            _dictionaryUnits.Add(UnitId.TupShipWeapon3, Resources.trans_Tup_ShipWeapon3);
            _dictionaryUnits.Add(UnitId.TupStim, Resources.trans_Tup_Stim);
            _dictionaryUnits.Add(UnitId.TupStructureArmor, Resources.trans_Tup_StructureArmor);
            _dictionaryUnits.Add(UnitId.TupTransformatorServos, Resources.trans_Tup_TransformationServos);
            _dictionaryUnits.Add(UnitId.TupUpgradeToOrbital, Resources.trans_Tup_OrbitalCommand);
            _dictionaryUnits.Add(UnitId.TupUpgradeToPlanetary, Resources.trans_Tup_PlanetaryFortress);
            _dictionaryUnits.Add(UnitId.TupVehicleShipPlanting1, Resources.trans_Tup_VehicleShipPlanting1);
            _dictionaryUnits.Add(UnitId.TupVehicleShipPlanting2, Resources.trans_Tup_VehicleShipPlanting2);
            _dictionaryUnits.Add(UnitId.TupVehicleShipPlanting3, Resources.trans_Tup_VehicleShipPlanting3);
            _dictionaryUnits.Add(UnitId.TupVehicleWeapon1, Resources.trans_Tup_VehicleWeapon1);
            _dictionaryUnits.Add(UnitId.TupVehicleWeapon2, Resources.trans_Tup_VehicleWeapon2);
            _dictionaryUnits.Add(UnitId.TupVehicleWeapon3, Resources.trans_Tup_VehicleWeapon3);
            _dictionaryUnits.Add(UnitId.TupWeaponRefit, Resources.trans_Tup_WeaponRefit);

            _dictionaryUnits.Add(UnitId.PupAirA1, Resources.trans_Pup_AirA1);
            _dictionaryUnits.Add(UnitId.PupAirA2, Resources.trans_Pup_AirA2);
            _dictionaryUnits.Add(UnitId.PupAirA3, Resources.trans_Pup_AirA3);
            _dictionaryUnits.Add(UnitId.PupAirW1, Resources.trans_Pup_AirW1);
            _dictionaryUnits.Add(UnitId.PupAirW2, Resources.trans_Pup_AirW2);
            _dictionaryUnits.Add(UnitId.PupAirW3, Resources.trans_Pup_AirW3);
            _dictionaryUnits.Add(UnitId.PupAnionPulseCrystals, Resources.trans_Pup_AnionPulseCrystals);
            _dictionaryUnits.Add(UnitId.PupBlink, Resources.trans_Pup_Blink);
            _dictionaryUnits.Add(UnitId.PupCharge, Resources.trans_Pup_Charge);
            _dictionaryUnits.Add(UnitId.PupExtendedThermalLance, Resources.trans_Pup_ExtendedThermalLance);
            _dictionaryUnits.Add(UnitId.PupGraviticBooster, Resources.trans_Pup_GraviticBoosters);
            _dictionaryUnits.Add(UnitId.PupGraviticDrive, Resources.trans_Pup_GraviticDrive);
            _dictionaryUnits.Add(UnitId.PupGravitonCatapult, Resources.trans_Pup_GravitonCatapult);
            _dictionaryUnits.Add(UnitId.PupGroundA1, Resources.trans_Pup_GroundA1);
            _dictionaryUnits.Add(UnitId.PupGroundA2, Resources.trans_Pup_GroundA2);
            _dictionaryUnits.Add(UnitId.PupGroundA3, Resources.trans_Pup_GroundA3);
            _dictionaryUnits.Add(UnitId.PupGroundW1, Resources.trans_Pup_GroundW1);
            _dictionaryUnits.Add(UnitId.PupGroundW2, Resources.trans_Pup_GroundW2);
            _dictionaryUnits.Add(UnitId.PupGroundW3, Resources.trans_Pup_GroundW3);
            _dictionaryUnits.Add(UnitId.PupS1, Resources.trans_Pup_S1);
            _dictionaryUnits.Add(UnitId.PupS2, Resources.trans_Pup_S2);
            _dictionaryUnits.Add(UnitId.PupS3, Resources.trans_Pup_S3);
            _dictionaryUnits.Add(UnitId.PupStorm, Resources.trans_Pup_Storm);
            _dictionaryUnits.Add(UnitId.PupWarpGate, Resources.trans_Pup_Warpgate);

            _dictionaryUnits.Add(UnitId.ZupAdrenalGlands, Resources.trans_Zup_AdrenalGlands);
            _dictionaryUnits.Add(UnitId.ZupAirA1, Resources.trans_Zup_AirA1);
            _dictionaryUnits.Add(UnitId.ZupAirA2, Resources.trans_Zup_AirA2);
            _dictionaryUnits.Add(UnitId.ZupAirA3, Resources.trans_Zup_AirA3);
            _dictionaryUnits.Add(UnitId.ZupAirW1, Resources.trans_Zup_AirW1);
            _dictionaryUnits.Add(UnitId.ZupAirW2, Resources.trans_Zup_AirW2);
            _dictionaryUnits.Add(UnitId.ZupAirW3, Resources.trans_Zup_AirW3);
            _dictionaryUnits.Add(UnitId.ZupBurrow, Resources.trans_Zup_Burrow);
            _dictionaryUnits.Add(UnitId.ZupChitinousPlating, Resources.trans_Zup_ChitinousPlating);
            _dictionaryUnits.Add(UnitId.ZupCentrifugalHooks, Resources.trans_Zup_CentrifugalHooks);
            _dictionaryUnits.Add(UnitId.ZupGlialReconstruction, Resources.trans_Zup_GlialReconstruction);
            _dictionaryUnits.Add(UnitId.ZupEnduringLocusts, Resources.trans_Zup_EnduringLocusts);
            _dictionaryUnits.Add(UnitId.ZupGroovedSpines, Resources.trans_Zup_GroovedSpines);
            _dictionaryUnits.Add(UnitId.ZupGroundA1, Resources.trans_Zup_GroundA1);
            _dictionaryUnits.Add(UnitId.ZupGroundA2, Resources.trans_Zup_GroundA2);
            _dictionaryUnits.Add(UnitId.ZupGroundA3, Resources.trans_Zup_GroundA3);
            _dictionaryUnits.Add(UnitId.ZupGroundM1, Resources.trans_Zup_GroundM1);
            _dictionaryUnits.Add(UnitId.ZupGroundM2, Resources.trans_Zup_GroundM2);
            _dictionaryUnits.Add(UnitId.ZupGroundM3, Resources.trans_Zup_GroundM3);
            _dictionaryUnits.Add(UnitId.ZupGroundW1, Resources.trans_Zup_GroundW1);
            _dictionaryUnits.Add(UnitId.ZupGroundW2, Resources.trans_Zup_GroundW2);
            _dictionaryUnits.Add(UnitId.ZupGroundW3, Resources.trans_Zup_GroundW3);
            _dictionaryUnits.Add(UnitId.ZupMetabolicBoost, Resources.trans_Zup_MetabolicBoost);
            _dictionaryUnits.Add(UnitId.ZupMuscularAugments, Resources.trans_Zup_MuscularAugments);
            _dictionaryUnits.Add(UnitId.ZupNeutralParasite, Resources.trans_Zup_NeutralParasite);
            _dictionaryUnits.Add(UnitId.ZupPathoglenGlands, Resources.trans_Zup_PathogenGlands);
            _dictionaryUnits.Add(UnitId.ZupPneumatizedCarapace, Resources.trans_Zup_PneumatizedCarapace);
            _dictionaryUnits.Add(UnitId.ZupTunnelingClaws, Resources.trans_Zup_TunnelingClaws);
            _dictionaryUnits.Add(UnitId.ZupUpgradeToBroodlord, Resources.trans_zu_BroodLordCocoon);
            _dictionaryUnits.Add(UnitId.ZupUpgradeToGreaterSpire, Resources.trans_zb_greaterspire);
            _dictionaryUnits.Add(UnitId.ZupUpgradeToHive, Resources.trans_zb_hive);
            _dictionaryUnits.Add(UnitId.ZupUpgradeToLair, Resources.trans_zb_lair);
            _dictionaryUnits.Add(UnitId.ZupUpgradeToOverseer, Resources.trans_zu_OverlordCocoon);
        }

        private void UnitWorker()
        {
            while (_bWorkerState)
            {
                Thread.Sleep(PSettings.PreferenceAll.Global.DrawingRefresh);

                #region Exceptions

                if (GInformation == null ||
                    GInformation.Gameinfo == null ||
                    !GInformation.Gameinfo.IsIngame ||
                    PSettings.PreferenceAll.OverlayAlert.UnitIds.Count <= 0 ||
                    GInformation.Player.Count <= 0 ||
                    GInformation.Unit.Count <= 0)
                {
                    Thread.Sleep(Constants.IdleRefreshRate);
                    continue;
                }

                #endregion

                var players = new List<PlayerStore>(_playerStores);

                for (var index = 0; index < GInformation.Player.Count; index++)
                {
                    #region Add missing player elements

                    var player = GInformation.Player[index];
                    if (index >= players.Count)
                    {
                        players.Add(new PlayerStore(player.Name));
                        players[index].Color = player.Color;
                    }

                    #endregion

                    #region Exceptions 

                    if (player.Type != PlayerType.Human &&
                        player.Type != PlayerType.Ai)
                        continue;

                    if (player == Player.LocalPlayer)
                        continue;

                    if (player.Team == Player.LocalPlayer.Team)
                        continue;

                    #endregion

                    #region Add Units to the list

                    try
                    {
                        var units = new List<Unit>(player.Units);
                        foreach (var unit in units)
                        {
                            foreach (var unitId in PSettings.PreferenceAll.OverlayAlert.UnitIds)
                            {
                                //Buildings
                                if (unit.Id == unitId)
                                {
                                    if (unit.IsUnderConstruction)
                                        AddNewUnit(players[index], unitId);
                                }

                                //Units being produced
                                var unitsInProduction = unit.ProdUnitProductionId.FindAll(x => x == unitId);
                                foreach (var unitInProduction in unitsInProduction)
                                {
                                    AddNewUnit(players[index], unitInProduction);
                                }
                            }
                        }
                    }

                    catch
                        (InvalidOperationException ex)
                    {
                        Logger.Emit(ex);
                    }

                    catch (ArgumentException ex)
                    {
                        Logger.Emit(ex);
                    }

                    #endregion

                    #region Remove stuck entries

                    var toManipulate = new Dictionary<UnitId, UnitListData>();

                    if (players[index].Units != null)
                    {
                        foreach (var unitListData in players[index].Units)
                        {
                            if (!unitListData.Value.IsValid)
                                continue;

                            var bSoundPlayed = unitListData.Value.SoundPlayed;
                            var bIsValid = true;
                            if (!unitListData.Value.SoundPlayed &&
                                PSettings.PreferenceAll.OverlayAlert.SoundNotification)
                            {
                                PlaySound();
                                bSoundPlayed = true;
                            }

                            if ((DateTime.Now - unitListData.Value.InitDate).Seconds >
                                PSettings.PreferenceAll.OverlayAlert.Time)
                                bIsValid = false;

                            toManipulate.Add(unitListData.Key,
                                new UnitListData(unitListData.Value.InitDate, bIsValid, bSoundPlayed));
                        }
                    }

                    foreach (var unitData in toManipulate)
                    {
                        players[index].Units[unitData.Key] = unitData.Value;
                    }

                    #endregion
                }


                _playerStores = players;
            }
        }

        private void AddNewUnit(PlayerStore playerStore, UnitId unitId)
        {
            try
            {
                var time = playerStore.Units[unitId].InitDate;

                if ((DateTime.Now - time).Seconds > PSettings.PreferenceAll.OverlayAlert.Time)
                    playerStore.Units[unitId] = new UnitListData(time, false, true);
            }
            catch (KeyNotFoundException)
            {
                playerStore.Units.Add(unitId, new UnitListData(DateTime.Now, true, false));
            }
        }

        private void PlaySound()
        {
            SystemSounds.Asterisk.Play();
        }

        protected override void Draw(BufferedGraphics g)
        {
            var fPenWidth = 3f;

            var iPosX = (int) fPenWidth;
            var iPosY = (int) fPenWidth;

            var tempPlayerStores = new List<PlayerStore>(_playerStores);

            foreach (var playerStore in tempPlayerStores)
            {
                var tempDictionary = new Dictionary<UnitId, UnitListData>(playerStore.Units);

                foreach (var playerUnit in tempDictionary)
                {
                    if (!playerUnit.Value.IsValid)
                        continue;

                    //var targetBrush = new SolidBrush(Color.FromArgb(255, playerStore.Color));
                    var targetBrush = new HatchBrush(HatchStyle.ForwardDiagonal, playerStore.Color, Color.WhiteSmoke);
                    var targetRectangle = new Rectangle(iPosX,
                        iPosY,
                        PSettings.PreferenceAll.OverlayAlert.IconWidth,
                        PSettings.PreferenceAll.OverlayAlert.IconHeight);

                    try
                    {
                        g.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                        g.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                        g.Graphics.FillEllipse(targetBrush,
                            (int) (iPosX - (fPenWidth/2)),
                            (int) (iPosY - (fPenWidth/2)),
                            (int) (PSettings.PreferenceAll.OverlayAlert.IconWidth + fPenWidth),
                            (int) (PSettings.PreferenceAll.OverlayAlert.IconHeight + fPenWidth));

                        using (var gfxPath = new GraphicsPath())
                        {
                            gfxPath.AddEllipse(targetRectangle);

                            using (var region = new Region(targetRectangle))
                            {
                                region.Exclude(gfxPath);

                                g.Graphics.ExcludeClip(region);

                                g.Graphics.DrawImage(_dictionaryUnits[playerUnit.Key], targetRectangle);
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        Logger.Emit(ex);
                    }

                    //Set position for the next panel
                    iPosX += PSettings.PreferenceAll.OverlayAlert.IconWidth + (int) fPenWidth*2;

                    //Resize properly
                    if (iPosX >= ClientSize.Width)
                        ClientSize = new Size(iPosX - (int) (fPenWidth),
                            iPosY + PSettings.PreferenceAll.OverlayAlert.IconHeight + (int) fPenWidth*2);
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

        protected override void MouseWheelTransferData(MouseEventArgs e)
        {
            if (e.Delta.Equals(120))
            {
                PSettings.PreferenceAll.OverlayAlert.IconWidth += 1;
                PSettings.PreferenceAll.OverlayAlert.IconHeight += 1;
            }

            else if (e.Delta.Equals(-120))
            {
                PSettings.PreferenceAll.OverlayAlert.IconWidth -= 1;
                PSettings.PreferenceAll.OverlayAlert.IconHeight -= 1;
            }
        }
    }

    internal class PlayerStore
    {
        public PlayerStore(string playerName)
        {
            Units = new Dictionary<UnitId, UnitListData>();
            PlayerName = playerName;
            Color = Color.Red;
        }

        public Dictionary<UnitId, UnitListData> Units { get; set; }
        public string PlayerName { get; set; }
        public Color Color { get; set; }
    }

    internal struct UnitListData
    {
        public UnitListData(DateTime initDate, bool isValid, bool soundPlayed)
        {
            InitDate = initDate;
            IsValid = isValid;
            SoundPlayed = soundPlayed;
        }

        public DateTime InitDate { get; set; }
        public bool IsValid { get; set; }
        public bool SoundPlayed { get; set; }

        public override string ToString()
        {
            return $"Init Date: {InitDate}, IsValid: {IsValid}, SoundPlayed: {SoundPlayed}";
        }
    }
}