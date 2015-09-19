// Superclass to handle the basic rendering and Window- handling
// for each subclass. Actually runs all the crap like resizing, information- gathering, drawing and even more for you
// You just have to set up all the information for the specific classes (like in which setting you'd like to write).
// And, of course, a drawing- implementation to get your drawing done.
// 
// Inherit from this class to get your stuff done easily!
// 
// 
// Written by bellaPatricia @ 2014 - August - 01

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using AnotherSc2Hack.Properties;
using PredefinedTypes;
using Utilities.Events;
using Utilities.ExtensionMethods;
using _ = Utilities.InfoManager.InfoManager;
using Interop = Utilities.InteropCalls.InteropCalls;
using MouseButtons = System.Windows.Forms.MouseButtons;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    /// <summary>
    ///     Baseclass which handles everything around the drawing of the content.
    ///     Does the dirty work so you don't have to care about the basic "fuck up"
    /// </summary>
    public abstract partial class BaseRenderer : Form
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseRenderer" /> class.
        /// </summary>
        /// <param name="gInformation">The GameInfo reference to access the gamedata</param>
        /// <param name="pSettings">The Preference reference to get the information which data will be drawn</param>
        /// <param name="sc2Process">The Process- handle to check whenever a process is available or not</param>
        protected BaseRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
        {
            GInformation = gInformation;
            PSettings = pSettings;
            PSc2Process = sc2Process;

            InitCode();
        }

        #endregion

        #region Variables

        public event NumberChangeHandler IterationPerSecondChanged;

        private int _iTimesRefreshed; //Dunno.. :D
        private Point _ptMousePosition = new Point(0, 0); //Position for the Moving of the Panel
        private bool _bDraw = true;

        protected Stopwatch SwMainWatch = new Stopwatch(); //Stopwatch for Debugging and speed- tests
        protected DateTime DtBegin = DateTime.Now; //First Datetime to get the Delta between the begin and end [TopMost]

        protected DateTime DtSecond = DateTime.Now;
        //Second Datetime to get the Delta between the begin and end [TopMost]

        protected bool BSurpressForeground;
        protected bool BChangingPosition;
        protected bool BMouseDown;
        protected bool BSetSize;
        protected bool BToggleSize;
        protected bool BSetPosition;
        protected bool BTogglePosition;
        protected string StrBackupChatbox = string.Empty;
        protected string StrBackupSizeChatbox = string.Empty;
        internal Stopwatch _swMainWatch = new Stopwatch();

        #region UnitCounter - Count all objects per player

        #region Terran

        protected List<UnitCount> LTbCommandCenter = new List<UnitCount>();
        protected List<UnitCount> LTbPlanetaryFortress = new List<UnitCount>();
        protected List<UnitCount> LTbOrbitalCommand = new List<UnitCount>();
        protected List<UnitCount> LTbBarracks = new List<UnitCount>();
        protected List<UnitCount> LTbSupply = new List<UnitCount>();
        protected List<UnitCount> LTbEbay = new List<UnitCount>();
        protected List<UnitCount> LTbRefinery = new List<UnitCount>();
        protected List<UnitCount> LTbBunker = new List<UnitCount>();
        protected List<UnitCount> LTbTurrent = new List<UnitCount>();
        protected List<UnitCount> LTbSensorTower = new List<UnitCount>();
        protected List<UnitCount> LTbFactory = new List<UnitCount>();
        protected List<UnitCount> LTbStarport = new List<UnitCount>();
        protected List<UnitCount> LTbArmory = new List<UnitCount>();
        protected List<UnitCount> LTbGhostAcademy = new List<UnitCount>();
        protected List<UnitCount> LTbFusionCore = new List<UnitCount>();
        protected List<UnitCount> LTbTechlab = new List<UnitCount>();
        protected List<UnitCount> LTbReactor = new List<UnitCount>();
        protected List<UnitCount> LTbAutoTurret = new List<UnitCount>();


        protected List<UnitCount> LTuScv = new List<UnitCount>();
        protected List<UnitCount> LTuMule = new List<UnitCount>();
        protected List<UnitCount> LTuMarine = new List<UnitCount>();
        protected List<UnitCount> LTuMarauder = new List<UnitCount>();
        protected List<UnitCount> LTuReaper = new List<UnitCount>();
        protected List<UnitCount> LTuGhost = new List<UnitCount>();
        protected List<UnitCount> LTuWidowMine = new List<UnitCount>();
        protected List<UnitCount> LTuSiegetank = new List<UnitCount>();
        protected List<UnitCount> LTuHellion = new List<UnitCount>();
        protected List<UnitCount> LTuHellbat = new List<UnitCount>();
        protected List<UnitCount> LTuThor = new List<UnitCount>();
        protected List<UnitCount> LTuViking = new List<UnitCount>();
        protected List<UnitCount> LTuBanshee = new List<UnitCount>();
        protected List<UnitCount> LTuMedivac = new List<UnitCount>();
        protected List<UnitCount> LTuBattlecruiser = new List<UnitCount>();
        protected List<UnitCount> LTuRaven = new List<UnitCount>();
        protected List<UnitCount> LTuPointDefenseDrone = new List<UnitCount>();
        protected List<UnitCount> LTuNuke = new List<UnitCount>();


        protected List<UnitCount> LTupInfantryWeapon1 = new List<UnitCount>();
        protected List<UnitCount> LTupInfantryWeapon2 = new List<UnitCount>();
        protected List<UnitCount> LTupInfantryWeapon3 = new List<UnitCount>();
        protected List<UnitCount> LTupInfantryArmor1 = new List<UnitCount>();
        protected List<UnitCount> LTupInfantryArmor2 = new List<UnitCount>();
        protected List<UnitCount> LTupInfantryArmor3 = new List<UnitCount>();
        protected List<UnitCount> LTupVehicleWeapon1 = new List<UnitCount>();
        protected List<UnitCount> LTupVehicleWeapon2 = new List<UnitCount>();
        protected List<UnitCount> LTupVehicleWeapon3 = new List<UnitCount>();
        protected List<UnitCount> LTupShipWeapon1 = new List<UnitCount>();
        protected List<UnitCount> LTupShipWeapon2 = new List<UnitCount>();
        protected List<UnitCount> LTupShipWeapon3 = new List<UnitCount>();
        protected List<UnitCount> LTupVehicleShipPlanting1 = new List<UnitCount>();
        protected List<UnitCount> LTupVehicleShipPlanting2 = new List<UnitCount>();
        protected List<UnitCount> LTupVehicleShipPlanting3 = new List<UnitCount>();
        protected List<UnitCount> LTupNeosteelFrame = new List<UnitCount>();
        protected List<UnitCount> LTupStructureArmor = new List<UnitCount>();
        protected List<UnitCount> LTupHighSecAutoTracking = new List<UnitCount>();
        protected List<UnitCount> LTupConcussiveShells = new List<UnitCount>();
        protected List<UnitCount> LTupCombatShields = new List<UnitCount>();
        protected List<UnitCount> LTupStim = new List<UnitCount>();
        protected List<UnitCount> LTupBlueFlame = new List<UnitCount>();
        protected List<UnitCount> LTupDrillingClaws = new List<UnitCount>();
        protected List<UnitCount> LTupTransformationServos = new List<UnitCount>();
        protected List<UnitCount> LTupCloakingField = new List<UnitCount>();
        protected List<UnitCount> LTupCaduceusReactor = new List<UnitCount>();
        protected List<UnitCount> LTupDurableMaterials = new List<UnitCount>();
        protected List<UnitCount> LTupCorvidReactor = new List<UnitCount>();
        protected List<UnitCount> LTupWeaponRefit = new List<UnitCount>();
        protected List<UnitCount> LTupBehemothReactor = new List<UnitCount>();
        protected List<UnitCount> LTupPersonalCloak = new List<UnitCount>();
        protected List<UnitCount> LTupMoebiusReactor = new List<UnitCount>();
        protected List<UnitCount> LTupPlanetaryFortress = new List<UnitCount>();
        protected List<UnitCount> LTupOrbitalCommand = new List<UnitCount>();

        #endregion

        #region Protoss

        protected List<UnitCount> LPbNexus = new List<UnitCount>();
        protected List<UnitCount> LPbPylon = new List<UnitCount>();
        protected List<UnitCount> LPbGateway = new List<UnitCount>();
        protected List<UnitCount> LPbForge = new List<UnitCount>();
        protected List<UnitCount> LPbCybercore = new List<UnitCount>();
        protected List<UnitCount> LPbWarpgate = new List<UnitCount>();
        protected List<UnitCount> LPbCannon = new List<UnitCount>();
        protected List<UnitCount> LPbAssimilator = new List<UnitCount>();
        protected List<UnitCount> LPbTwilight = new List<UnitCount>();
        protected List<UnitCount> LPbStargate = new List<UnitCount>();
        protected List<UnitCount> LPbRobotics = new List<UnitCount>();
        protected List<UnitCount> LPbRoboticsSupport = new List<UnitCount>();
        protected List<UnitCount> LPbFleetbeacon = new List<UnitCount>();
        protected List<UnitCount> LPbTemplarArchives = new List<UnitCount>();
        protected List<UnitCount> LPbDarkshrine = new List<UnitCount>();

        protected List<UnitCount> LPuProbe = new List<UnitCount>();
        protected List<UnitCount> LPuStalker = new List<UnitCount>();
        protected List<UnitCount> LPuZealot = new List<UnitCount>();
        protected List<UnitCount> LPuSentry = new List<UnitCount>();
        protected List<UnitCount> LPuDt = new List<UnitCount>();
        protected List<UnitCount> LPuHt = new List<UnitCount>();
        protected List<UnitCount> LPuMothership = new List<UnitCount>();
        protected List<UnitCount> LPuMothershipcore = new List<UnitCount>();
        protected List<UnitCount> LPuArchon = new List<UnitCount>();
        protected List<UnitCount> LPuWarpprism = new List<UnitCount>();
        protected List<UnitCount> LPuObserver = new List<UnitCount>();
        protected List<UnitCount> LPuColossus = new List<UnitCount>();
        protected List<UnitCount> LPuImmortal = new List<UnitCount>();
        protected List<UnitCount> LPuPhoenix = new List<UnitCount>();
        protected List<UnitCount> LPuVoidray = new List<UnitCount>();
        protected List<UnitCount> LPuOracle = new List<UnitCount>();
        protected List<UnitCount> LPuTempest = new List<UnitCount>();
        protected List<UnitCount> LPuCarrier = new List<UnitCount>();
        protected List<UnitCount> LPuForcefield = new List<UnitCount>();

        protected List<UnitCount> LPupGroundWeapon1 = new List<UnitCount>();
        protected List<UnitCount> LPupGroundWeapon2 = new List<UnitCount>();
        protected List<UnitCount> LPupGroundWeapon3 = new List<UnitCount>();
        protected List<UnitCount> LPupGroundArmor1 = new List<UnitCount>();
        protected List<UnitCount> LPupGroundArmor2 = new List<UnitCount>();
        protected List<UnitCount> LPupGroundArmor3 = new List<UnitCount>();
        protected List<UnitCount> LPupShield1 = new List<UnitCount>();
        protected List<UnitCount> LPupShield2 = new List<UnitCount>();
        protected List<UnitCount> LPupShield3 = new List<UnitCount>();
        protected List<UnitCount> LPupAirWeapon1 = new List<UnitCount>();
        protected List<UnitCount> LPupAirWeapon2 = new List<UnitCount>();
        protected List<UnitCount> LPupAirWeapon3 = new List<UnitCount>();
        protected List<UnitCount> LPupAirArmor1 = new List<UnitCount>();
        protected List<UnitCount> LPupAirArmor2 = new List<UnitCount>();
        protected List<UnitCount> LPupAirArmor3 = new List<UnitCount>();
        protected List<UnitCount> LPupStorm = new List<UnitCount>();
        protected List<UnitCount> LPupWarpGate = new List<UnitCount>();
        protected List<UnitCount> LPupBlink = new List<UnitCount>();
        protected List<UnitCount> LPupCharge = new List<UnitCount>();
        protected List<UnitCount> LPupAnionPulseCrystal = new List<UnitCount>();
        protected List<UnitCount> LPupGraviticBooster = new List<UnitCount>();
        protected List<UnitCount> LPupGraviticDrive = new List<UnitCount>();
        protected List<UnitCount> LPupGravitonCatapult = new List<UnitCount>();
        protected List<UnitCount> LPupExtendedThermalLance = new List<UnitCount>();

        #endregion

        #region Zerg

        protected List<UnitCount> LZbHatchery = new List<UnitCount>();
        protected List<UnitCount> LZbLair = new List<UnitCount>();
        protected List<UnitCount> LZbHive = new List<UnitCount>();
        protected List<UnitCount> LZbSpawningpool = new List<UnitCount>();
        protected List<UnitCount> LZbRoachwarren = new List<UnitCount>();
        protected List<UnitCount> LZbCreepTumor = new List<UnitCount>();
        protected List<UnitCount> LZbEvochamber = new List<UnitCount>();
        protected List<UnitCount> LZbSpine = new List<UnitCount>();
        protected List<UnitCount> LZbSpore = new List<UnitCount>();
        protected List<UnitCount> LZbBanelingnest = new List<UnitCount>();
        protected List<UnitCount> LZbExtractor = new List<UnitCount>();
        protected List<UnitCount> LZbHydraden = new List<UnitCount>();
        protected List<UnitCount> LZbSpire = new List<UnitCount>();
        protected List<UnitCount> LZbNydusbegin = new List<UnitCount>();
        protected List<UnitCount> LZbNydusend = new List<UnitCount>();
        protected List<UnitCount> LZbUltracavern = new List<UnitCount>();
        protected List<UnitCount> LZbGreaterspire = new List<UnitCount>();
        protected List<UnitCount> LZbInfestationpit = new List<UnitCount>();

        protected List<UnitCount> LZuLarva = new List<UnitCount>();
        protected List<UnitCount> LZuDrone = new List<UnitCount>();
        protected List<UnitCount> LZuOverlord = new List<UnitCount>();
        protected List<UnitCount> LZuZergling = new List<UnitCount>();
        protected List<UnitCount> LZuBaneling = new List<UnitCount>();
        protected List<UnitCount> LZuBanelingCocoon = new List<UnitCount>();
        protected List<UnitCount> LZuBroodlordCocoon = new List<UnitCount>();
        protected List<UnitCount> LZuRoach = new List<UnitCount>();
        protected List<UnitCount> LZuHydra = new List<UnitCount>();
        protected List<UnitCount> LZuInfestor = new List<UnitCount>();
        protected List<UnitCount> LZuInfestedTerran = new List<UnitCount>();
        protected List<UnitCount> LZuInfestedTerranEgg = new List<UnitCount>();
        protected List<UnitCount> LZuQueen = new List<UnitCount>();
        protected List<UnitCount> LZuOverseer = new List<UnitCount>();
        protected List<UnitCount> LZuOverseerCocoon = new List<UnitCount>();
        protected List<UnitCount> LZuMutalisk = new List<UnitCount>();
        protected List<UnitCount> LZuCorruptor = new List<UnitCount>();
        protected List<UnitCount> LZuBroodlord = new List<UnitCount>();
        protected List<UnitCount> LZuUltralisk = new List<UnitCount>();
        protected List<UnitCount> LZuSwarmhost = new List<UnitCount>();
        protected List<UnitCount> LZuViper = new List<UnitCount>();
        protected List<UnitCount> LZuLocust = new List<UnitCount>();
        protected List<UnitCount> LZuFlyingLocust = new List<UnitCount>();
        protected List<UnitCount> LZuChangeling = new List<UnitCount>();
        protected List<UnitCount> LZuBroodling = new List<UnitCount>();


        protected List<UnitCount> LZupAirWeapon1 = new List<UnitCount>();
        protected List<UnitCount> LZupAirWeapon2 = new List<UnitCount>();
        protected List<UnitCount> LZupAirWeapon3 = new List<UnitCount>();
        protected List<UnitCount> LZupAirArmor1 = new List<UnitCount>();
        protected List<UnitCount> LZupAirArmor2 = new List<UnitCount>();
        protected List<UnitCount> LZupAirArmor3 = new List<UnitCount>();
        protected List<UnitCount> LZupGroundWeapon1 = new List<UnitCount>();
        protected List<UnitCount> LZupGroundWeapon2 = new List<UnitCount>();
        protected List<UnitCount> LZupGroundWeapon3 = new List<UnitCount>();
        protected List<UnitCount> LZupGroundArmor1 = new List<UnitCount>();
        protected List<UnitCount> LZupGroundArmor2 = new List<UnitCount>();
        protected List<UnitCount> LZupGroundArmor3 = new List<UnitCount>();
        protected List<UnitCount> LZupGroundMelee1 = new List<UnitCount>();
        protected List<UnitCount> LZupGroundMelee2 = new List<UnitCount>();
        protected List<UnitCount> LZupGroundMelee3 = new List<UnitCount>();
        protected List<UnitCount> LZupMetabolicBoost = new List<UnitCount>();
        protected List<UnitCount> LZupAdrenalGlands = new List<UnitCount>();
        protected List<UnitCount> LZupCentrifugalHooks = new List<UnitCount>();
        protected List<UnitCount> LZupChitinousPlating = new List<UnitCount>();
        protected List<UnitCount> LZupEnduringLocusts = new List<UnitCount>();
        protected List<UnitCount> LZupGlialReconstruction = new List<UnitCount>();
        protected List<UnitCount> LZupGroovedSpines = new List<UnitCount>();
        protected List<UnitCount> LZupMuscularAugments = new List<UnitCount>();
        protected List<UnitCount> LZupNeutralParasite = new List<UnitCount>();
        protected List<UnitCount> LZupPathoglenGlands = new List<UnitCount>();
        protected List<UnitCount> LZupPneumatizedCarapace = new List<UnitCount>();
        protected List<UnitCount> LZupTunnnelingClaws = new List<UnitCount>();
        protected List<UnitCount> LZupVentralSacs = new List<UnitCount>();
        protected List<UnitCount> LZupBurrow = new List<UnitCount>();
        protected List<UnitCount> LZupFlyingLocust = new List<UnitCount>();

        #endregion

        #region Images

        #region Terran

        #region Units

        protected Image ImgTuScv = Resources.tu_scv,
            ImgTuMule = Resources.tu_Mule,
            ImgTuMarine = Resources.tu_marine,
            ImgTuMarauder = Resources.tu_marauder,
            ImgTuReaper = Resources.tu_reaper,
            ImgTuGhost = Resources.tu_ghost,
            ImgTuHellion = Resources.tu_hellion,
            ImgTuHellbat = Resources.tu_battlehellion,
            ImgTuSiegetank = Resources.tu_tank,
            ImgTuThor = Resources.tu_thor,
            ImgTuWidowMine = Resources.tu_widowmine,
            ImgTuViking = Resources.tu_vikingAir,
            ImgTuRaven = Resources.tu_raven,
            ImgTuMedivac = Resources.tu_medivac,
            ImgTuBattlecruiser = Resources.tu_battlecruiser,
            ImgTuBanshee = Resources.tu_banshee,
            ImgTuPointDefenseDrone = Resources.tu_pdd,
            ImgTuNuke = Resources.Tu_Nuke;

        #endregion

        #region Buildings

        protected Image ImgTbCc = Resources.tb_cc,
            ImgTbOc = Resources.tb_oc,
            ImgTbPf = Resources.tb_pf,
            ImgTbSupply = Resources.tb_supply,
            ImgTbRefinery = Resources.tb_refinery,
            ImgTbBarracks = Resources.tb_rax,
            ImgTbEbay = Resources.tb_ebay,
            ImgTbTurrent = Resources.tb_turret,
            ImgTbSensorTower = Resources.tb_sensor,
            ImgTbFactory = Resources.tb_fax,
            ImgTbStarport = Resources.tb_starport,
            ImgTbGhostacademy = Resources.tb_ghostacademy,
            ImgTbArmory = Resources.tb_Armory,
            ImgTbBunker = Resources.tb_bunker,
            ImgTbFusioncore = Resources.tb_fusioncore,
            ImgTbTechlab = Resources.tb_techlab,
            ImgTbReactor = Resources.tb_reactor,
            ImgTbAutoTurret = Resources.tb_autoturret;

        #endregion

        #region Upgrades

        protected Image ImgTupStim = Resources.Tup_Stim,
            ImgTupConcussiveShells = Resources.Tup_ConcussiveShells,
            ImgTupCombatShields = Resources.Tup_CombatShields,
            ImgTupPersonalCloak = Resources.Tup_PersonalCloak,
            ImgTupMoebiusReactor = Resources.Tup_MoebiusReactor,
            ImgTupBlueFlame = Resources.Tup_BlueFlame,
            ImgTupTransformatorServos = Resources.Tup_TransformationServos,
            ImgTupDrillingClaws = Resources.Tup_DrillingClaws,
            ImgTupCloakingField = Resources.Tup_CloakingField,
            ImgTupDurableMaterials = Resources.Tup_DurableMaterials,
            ImgTupCaduceusReactor = Resources.Tup_CaduceusReactor,
            ImgTupCorvidReactor = Resources.Tup_CorvidReactor,
            ImgTupBehemothReacot = Resources.Tup_BehemothReactor,
            ImgTupWeaponRefit = Resources.Tup_WeaponRefit,
            ImgTupInfantryWeapon1 = Resources.Tup_InfantyWeapon1,
            ImgTupInfantryWeapon2 = Resources.Tup_InfantyWeapon2,
            ImgTupInfantryWeapon3 = Resources.Tup_InfantyWeapon3,
            ImgTupInfantryArmor1 = Resources.Tup_InfantyArmor1,
            ImgTupInfantryArmor2 = Resources.Tup_InfantyArmor2,
            ImgTupInfantryArmor3 = Resources.Tup_InfantyArmor3,
            ImgTupVehicleWeapon1 = Resources.Tup_VehicleWeapon1,
            ImgTupVehicleWeapon2 = Resources.Tup_VehicleWeapon2,
            ImgTupVehicleWeapon3 = Resources.Tup_VehicleWeapon3,
            ImgTupShipWeapon1 = Resources.Tup_ShipWeapon1,
            ImgTupShipWeapon2 = Resources.Tup_ShipWeapon2,
            ImgTupShipWeapon3 = Resources.Tup_ShipWeapon3,
            ImgTupVehicleShipPlanting1 = Resources.Tup_VehicleShipPlanting1,
            ImgTupVehicleShipPlanting2 = Resources.Tup_VehicleShipPlanting2,
            ImgTupVehicleShipPlanting3 = Resources.Tup_VehicleShipPlanting3,
            ImgTupHighSecAutoTracking = Resources.Tup_HighSecAutotracking,
            ImgTupStructureArmor = Resources.Tup_StructureArmor,
            ImgTupNeosteelFrame = Resources.Tup_NeosteelFrame;

        

        #endregion

        #endregion

        #region Protoss

        #region Units

        protected Image ImgPuProbe = Resources.pu_probe,
            ImgPuZealot = Resources.pu_Zealot,
            ImgPuStalker = Resources.pu_Stalker,
            ImgPuSentry = Resources.pu_sentry,
            ImgPuDarkTemplar = Resources.pu_DarkTemplar,
            ImgPuHighTemplar = Resources.pu_ht,
            ImgPuColossus = Resources.pu_Colossus,
            ImgPuImmortal = Resources.pu_immortal,
            ImgPuWapprism = Resources.pu_warpprism,
            ImgPuObserver = Resources.pu_Observer,
            ImgPuOracle = Resources.pu_oracle,
            ImgPuTempest = Resources.pu_tempest,
            ImgPuPhoenix = Resources.pu_pheonix,
            ImgPuVoidray = Resources.pu_Voidray,
            ImgPuCarrier = Resources.pu_carrier,
            ImgPuMothershipcore = Resources.pu_mothershipcore,
            ImgPuMothership = Resources.pu_Mothership,
            ImgPuArchon = Resources.pu_Archon,
            ImgPupForcefield = Resources.PuForceField;

        #endregion

        #region Buildings

        protected Image ImgPbNexus = Resources.pb_Nexus,
            ImgPbPylon = Resources.pb_Pylon,
            ImgPbGateway = Resources.pb_gateway,
            ImgPbWarpgate = Resources.pb_warpgate,
            ImgPbAssimilator = Resources.pb_Assimilator,
            ImgPbForge = Resources.pb_forge,
            ImgPbCannon = Resources.pb_Cannon,
            ImgPbCybercore = Resources.pb_cybercore,
            ImgPbStargate = Resources.pb_stargate,
            ImgPbRobotics = Resources.pb_robotics,
            ImgPbRoboticsSupport = Resources.pb_roboticssupport,
            ImgPbTwillightCouncil = Resources.pb_twillightCouncil,
            ImgPbDarkShrine = Resources.pb_DarkShrine,
            ImgPbTemplarArchives = Resources.pb_templararchives,
            ImgPbFleetBeacon = Resources.pb_FleetBeacon;

        #endregion

        #region Upgrades

        protected Image ImgPupGroundWeapon1 = Resources.Pup_GroundW1,
            ImgPupGroundWeapon2 = Resources.Pup_GroundW2,
            ImgPupGroundWeapon3 = Resources.Pup_GroundW3,
            ImgPupGroundArmor1 = Resources.Pup_GroundA1,
            ImgPupGroundArmor2 = Resources.Pup_GroundA2,
            ImgPupGroundArmor3 = Resources.Pup_GroundA3,
            ImgPupShield1 = Resources.Pup_S1,
            ImgPupShield2 = Resources.Pup_S2,
            ImgPupShield3 = Resources.Pup_S3,
            ImgPupAirWeapon1 = Resources.Pup_AirW1,
            ImgPupAirWeapon2 = Resources.Pup_AirW2,
            ImgPupAirWeapon3 = Resources.Pup_AirW3,
            ImgPupAirArmor1 = Resources.Pup_AirA1,
            ImgPupAirArmor2 = Resources.Pup_AirA2,
            ImgPupAirArmor3 = Resources.Pup_AirA3,
            ImgPupBlink = Resources.Pup_Blink,
            ImgPupCharge = Resources.Pup_Charge,
            ImgPupGraviticBooster = Resources.Pup_GraviticBoosters,
            ImgPupGraviticDrive = Resources.Pup_GraviticDrive,
            ImgPupExtendedThermalLance = Resources.Pup_ExtendedThermalLance,
            ImgPupAnionPulseCrystals = Resources.Pup_AnionPulseCrystals,
            ImgPupGravitonCatapult = Resources.Pup_GravitonCatapult,
            ImgPupWarpGate = Resources.Pup_Warpgate,
            ImgPupStorm = Resources.Pup_Storm;

        #endregion

        #endregion

        #region Zerg

        #region Units

        protected Image ImgZuDrone = Resources.zu_drone,
            ImgZuLarva = Resources.zu_larva,
            ImgZuZergling = Resources.zu_zergling,
            ImgZuBaneling = Resources.zu_baneling,
            ImgZuBanelingCocoon = Resources.zu_banelingcocoon,
            ImgZuRoach = Resources.zu_roach,
            ImgZuHydra = Resources.zu_hydra,
            ImgZuMutalisk = Resources.zu_mutalisk,
            ImgZuUltra = Resources.zu_ultra,
            ImgZuViper = Resources.zu_viper,
            ImgZuSwarmhost = Resources.zu_swarmhost,
            ImgZuInfestor = Resources.zu_infestor,
            ImgInfestedTerran = Resources.zu_infestedterran,
            ImgInfestedTerranEgg = Resources.zu_infestedterran,
            ImgZuCorruptor = Resources.zu_corruptor,
            ImgZuChangeling = Resources.zu_changeling,
            ImgZuBroodlord = Resources.zu_broodlord,
            ImgZuBroodlordCocoon = Resources.zu_broodlordcocoon,
            ImgZuQueen = Resources.zu_queen,
            ImgZuOverlord = Resources.zu_overlord,
            ImgZuOverseer = Resources.zu_overseer,
            ImgZuOvserseerCocoon = Resources.zu_overseercocoon,
            ImgZuLocust = Resources.zu_locust,
            ImgZuFlyingLocust = Resources.zup_flying_locust,
            ImgZuBroodling = Resources.trans_zu_broodling;

        #endregion

        #region Buildings

        protected Image ImgZbHatchery = Resources.zb_hatchery,
            ImgZbLair = Resources.zb_lair,
            ImgZbHive = Resources.zb_hive,
            ImgZbCreepTumor = Resources.Zb_Creep_Tumor,
            ImgZbSpawningpool = Resources.zb_spawningpool,
            ImgZbExtractor = Resources.zb_extactor,
            ImgZbEvochamber = Resources.zb_evochamber,
            ImgZbSpinecrawler = Resources.zb_spine,
            ImgZbSporecrawler = Resources.zb_spore,
            ImgZbRoachwarren = Resources.zb_roachwarren,
            ImgZbGreaterspire = Resources.zb_greaterspire,
            ImgZbSpire = Resources.zb_spire,
            ImgZbNydusNetwork = Resources.zb_nydusnetwork,
            ImgZbNydusWorm = Resources.zb_nydusworm,
            ImgZbHydraden = Resources.zb_hydraden,
            ImgZbInfestationpit = Resources.zb_infestationpit,
            ImgZbUltracavern = Resources.zb_ultracavery,
            ImgZbBanelingnest = Resources.zb_banelingnest;

        #endregion

        #region Upgrades

        protected Image ImgZupAirWeapon1 = Resources.Zup_AirW1,
            ImgZupAirWeapon2 = Resources.Zup_AirW2,
            ImgZupAirWeapon3 = Resources.Zup_AirW3,
            ImgZupAirArmor1 = Resources.Zup_AirA1,
            ImgZupAirArmor2 = Resources.Zup_AirA2,
            ImgZupAirArmor3 = Resources.Zup_AirA3,
            ImgZupGroundWeapon1 = Resources.Zup_GroundW1,
            ImgZupGroundWeapon2 = Resources.Zup_GroundW2,
            ImgZupGroundWeapon3 = Resources.Zup_GroundW3,
            ImgZupGroundArmor1 = Resources.Zup_GroundA1,
            ImgZupGroundArmor2 = Resources.Zup_GroundA2,
            ImgZupGroundArmor3 = Resources.Zup_GroundA3,
            ImgZupGroundMelee1 = Resources.Zup_GroundM1,
            ImgZupGroundMelee2 = Resources.Zup_GroundM2,
            ImgZupGroundMelee3 = Resources.Zup_GroundM3,
            ImgZupBurrow = Resources.Zup_Burrow,
            ImgZupAdrenalGlands = Resources.Zup_AdrenalGlands,
            ImgZupCentrifugalHooks = Resources.Zup_CentrifugalHooks,
            ImgZupChitinousPlating = Resources.Zup_ChitinousPlating,
            ImgZupEnduringLocusts = Resources.Zup_EnduringLocusts,
            ImgZupGlialReconstruction = Resources.Zup_GlialReconstruction,
            ImgZupGroovedSpines = Resources.Zup_GroovedSpines,
            ImgZupMetabolicBoost = Resources.Zup_MetabolicBoost,
            ImgZupMuscularAugments = Resources.Zup_MuscularAugments,
            ImgZupNeutralParasite = Resources.Zup_NeutralParasite,
            ImgZupPathoglenGlands = Resources.Zup_PathogenGlands,
            ImgZupPneumatizedCarapace = Resources.Zup_PneumatizedCarapace,
            ImgZupTunnelingClaws = Resources.Zup_TunnelingClaws,
            ImgZupVentrallSacs = Resources.Zup_VentralSacs,
            ImgZupFlyingLocust = Resources.zup_flying_locust;

        #endregion

        #endregion

        #region Other

        protected readonly Image ImgSpeedArrow = Resources.Speed_Arrow;

        #endregion

        #endregion

        #endregion

        #endregion

        #region Events

        public event EventHandler IsHiddenChanged;
        public event EventHandler ShowCalled;
        public event EventHandler HideCalled;
        public event EventHandler CloseCalled;

        #endregion

        #region Getter/ Setter

        //Counts the iterations within a second
        private int _iterationsPerSecond;

        public int IterationsPerSeconds
        {
            get { return _iterationsPerSecond; }
            set
            {
                if (_iterationsPerSecond == value)
                    return;

                _iterationsPerSecond = value;

                var nArgs = new NumberArgs(value);

                OnNumberChanged(this, nArgs);
            }
        }

        private bool _isHidden = true;

        public bool IsHidden
        {
            get { return _isHidden; }

            private set
            {
                if (value == _isHidden)
                    return;

                _isHidden = value;

                OnIsHiddenChanged(this, new EventArgs());
            }
        }

        public bool IsDestroyed { get; set; }
        public CustomWindowStyles SetWindowStyle { get; set; }

        public bool IsAllowedToClose { get; set; }
        public GameInfo GInformation { get; set; }
        public PreferenceManager PSettings { get; set; }
        public Process PSc2Process { get; set; }
        public int BorderWidth { get; private set; }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Event manager to send the event to the caller
        /// </summary>
        /// <param name="sender">This object</param>
        /// <param name="e">Event Args</param>
        private void OnIsHiddenChanged(object sender, EventArgs e)
        {
            IsHiddenChanged?.Invoke(sender, e);
        }

        /// <summary>
        ///     Initializes the code.
        ///     It's just there to reduce the amount of codelines.
        /// </summary>
        private void InitCode()
        {
            IsHidden = true;
            IsAllowedToClose = false;

            SetStyle(ControlStyles.DoubleBuffer |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint, true);

            InitializeComponent();

            BorderWidth = 10;

            LoadPreferencesIntoControls();

            Text = HelpFunctions.SetWindowTitle();
        }

        /// <summary>
        ///     Simple Event we call when it's time to...
        /// </summary>
        /// <param name="sender">The reference we use</param>
        /// <param name="e">The Numberargs with the information about the number we pass by</param>
        private void OnNumberChanged(object sender, NumberArgs e)
        {
            IterationPerSecondChanged?.Invoke(sender, e);
        }

        /// <summary>
        ///     Changes the position of the Form based on mouse- position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var mousePos = MousePosition;
                mousePos.Offset(-_ptMousePosition.X, -_ptMousePosition.Y);
                Location = mousePos;
            }
        }

        /// <summary>
        ///     Sets variables to finalize the re- position/ -sizing.
        ///     Also calls MouseUpTransferData()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_MouseUp(object sender, MouseEventArgs e)
        {
            Interop.SetForegroundWindow(PSc2Process.MainWindowHandle);

            MouseUpTransferData();

            BChangingPosition = false;
            BMouseDown = false;
        }

        /// <summary>
        ///     Changes the state of BMouseDown (to allow reposition)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_MouseDown(object sender, MouseEventArgs e)
        {
            _ptMousePosition = new Point(e.X, e.Y);

            BMouseDown = true;
        }

        /// <summary>
        ///     Handles the resizing using the mouse- wheel.
        ///     Makes a precheck and finally calls MouseWheelTransferData(e).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Width >= Screen.PrimaryScreen.Bounds.Width &&
                e.Delta.Equals(120))
                return;

            MouseWheelTransferData(e);
        }

        /// <summary>
        ///     Changes the statte of IsDestroyed to true.
        ///     Also calls ChangeForecolorOfButton(Color.Red) to color the button of a specific Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsDestroyed = true;
        }

        /// <summary>
        ///     The Form_Load is there to load some basic stuff like Color and Timer- fixures.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_Load(object sender, EventArgs e)
        {
            LoadPreferencesIntoControls();

            LoadSpecificData();

            TopMost = true;


            BackColor = Color.FromArgb(255, 50, 50, 50);
            TransparencyKey = Color.FromArgb(255, 50, 50, 50);


            tmrRefreshGraphic.Enabled = true;
        }

        /// <summary>
        ///     Refreshes the Foreground (in case it failed somehow)
        ///     No idea why I use this, lol.
        /// </summary>
        /// <param name="hWnd">Handle for this Form</param>
        private void RefreshForeground(IntPtr hWnd)
        {
            var z = 0;
            for (var h = hWnd; h != IntPtr.Zero; h = Interop.GetWindow(h, Interop.GetWindowCmd.GwHwndprev))
                z++;


            if (z > 5)
            {
                // ???
                TopMost = false;
                TopMost = true;
            }
        }

        /// <summary>
        ///     Gets the Keyboard- input from SC2's chatbox.
        /// </summary>
        private void GetKeyboardInput()
        {
            if (GInformation.Gameinfo == null)
                return;

            var sInput = GInformation.Gameinfo.ChatInput;

            if (sInput != StrBackupChatbox)
                BTogglePosition = true;

            if (sInput != StrBackupSizeChatbox)
                BToggleSize = true;


            StrBackupChatbox = sInput;
            StrBackupSizeChatbox = sInput;
        }

        /// <summary>
        ///     Change the window- style (to make it click- and non-clickable)
        /// </summary>
        private void ChangeWindowStyle()
        {
            if (SetWindowStyle.Equals(CustomWindowStyles.Clickable))
            {
                BChangingPosition = true;
                BSurpressForeground = true;
                HelpFunctions.SetWindowStyle(Handle, CustomWindowStyles.Clickable);
            }

            else if (SetWindowStyle.Equals(CustomWindowStyles.NotClickable))
            {
                BSurpressForeground = false;

                if (!BMouseDown)
                    BChangingPosition = false;
                HelpFunctions.SetWindowStyle(Handle, CustomWindowStyles.NotClickable);
            }
        }

        /// <summary>
        ///     The basic Timermethod to re- draw and gather new data like the Chatbox- strings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrRefreshGraphic_Tick(object sender, EventArgs e)
        {
            //_swMainWatch.Reset();
            //_swMainWatch.Start();

            Invalidate();

            //_swMainWatch.Stop();
            //Debug.WriteLine("Time to Invalidate:" + 1000000 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency + " µs");


            if (HelpFunctions.HotkeysPressed(PSettings.PreferenceAll.Global.ChangeSizeAndPosition))
                SetWindowStyle = CustomWindowStyles.Clickable;

            else if (FormBorderStyle != FormBorderStyle.None)
                SetWindowStyle = CustomWindowStyles.Clickable;


            else
                SetWindowStyle = CustomWindowStyles.NotClickable;

            ChangeWindowStyle();


            GetKeyboardInput();
            AdjustPanelPosition();
            AdjustPanelSize();

            /* Refresh Top- Most */
            if (
                PSc2Process != null && PSc2Process.ProcessName.Length > 0 &&
                Interop.GetForegroundWindow().Equals(PSc2Process.MainWindowHandle))
            {
                if ((DateTime.Now - DtBegin).Seconds > 1)
                {
                    RefreshForeground(Handle);
                    DtBegin = DateTime.Now;
                }
            }

            //_swMainWatch.Stop();
            //Debug.WriteLine("Time to Iterate the timer:" + 1000000 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency + " µs");
        }

        /// <summary>
        ///     Draws the border when you resize/resposition/Click the howkey around the panel
        /// </summary>
        /// <param name="buffer">The buffer that helps us to draw the border.</param>
        private void DrawResizeBorder(BufferedGraphics buffer)
        {
            if (!BChangingPosition && !BSetPosition && !BSetSize)
                return;

            var targetBrush = new HatchBrush(HatchStyle.ForwardDiagonal, Color.YellowGreen, Color.WhiteSmoke);
            var targetPen = new Pen(targetBrush, BorderWidth);

            buffer.Graphics.DrawRectangle(targetPen, 0 + (targetPen.Width/2), 0 + (targetPen.Width / 2),
                ClientSize.Width - (targetPen.Width), ClientSize.Height - (targetPen.Width));

            // Draw current size 
            buffer.Graphics.DrawString(
                Width.ToString(CultureInfo.InvariantCulture) + "x" +
                Height.ToString(CultureInfo.InvariantCulture) + " - [X=" +
                Location.X.ToString(CultureInfo.InvariantCulture) + "; Y=" +
                Location.Y.ToString(CultureInfo.InvariantCulture) + "]",
                Font, Brushes.WhiteSmoke, Brushes.Black, targetPen.Width, targetPen.Width, 1, 1, true);
        }

        /// <summary>
        /// Redraw if you resize (with the form event)
        /// </summary>
        /// <param name="sender">The source</param>
        /// <param name="e">Simple Event Args</param>
        private void BaseRenderer_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        #endregion

        #region Protected abstract Methods (Form specific)

        /// <summary>
        ///     Draws the stuff you want to have drawn
        ///     Using this method so you don't need to override the OnPaint- method (cuz that would cause more fuck-up)
        /// </summary>
        /// <param name="g">Prebuffered graphics.. D:</param>
        protected abstract void Draw(BufferedGraphics g);

        /// <summary>
        ///     Load Form- specific data in the initialization of the Form.
        ///     This gets called within the Form_Load!
        /// </summary>
        protected abstract void LoadSpecificData();

        /// <summary>
        ///     Defines what happens after the resizing.
        ///     Usually some kind of datatransfer with the preferences.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void BaseRenderer_ResizeEnd(object sender, EventArgs e);

        /// <summary>
        ///     Adjust the panelsize and change the settings for Form X.
        /// </summary>
        protected abstract void AdjustPanelSize();

        /// <summary>
        ///     Adjust the panelposition and change the settings for Form X.
        /// </summary>
        protected abstract void AdjustPanelPosition();

        /// <summary>
        ///     Load the preferences for Form X into the Controls (size, size)
        /// </summary>
        protected abstract void LoadPreferencesIntoControls();

        /// <summary>
        ///     Transfers Mousedata (position) into the specific Form
        /// </summary>
        protected abstract void MouseUpTransferData();

        /// <summary>
        ///     Transfers Mousedata (size) into the specific Form
        /// </summary>
        /// <param name="e"></param>
        protected abstract void MouseWheelTransferData(MouseEventArgs e);

        #endregion

        #region Protected Methods

        /// <summary>
        ///     Checks if gameheart.
        /// </summary>
        /// <param name="p">The player</param>
        /// <returns>Is the player is gameheartish.</returns>
        protected bool CheckIfGameheart(Player p)
        {
            if (p.CurrentBuildings == 0 &&
                p.Status.Equals(PlayerStatus.Playing) &&
                p.SupplyMax == 0 &&
                p.SupplyMin == 0 &&
                p.Worker == 0 &&
                p.Minerals == 0 &&
                p.Gas == 0)
                return true;

            return false;
        }

        /// <summary>
        ///     The override OnPaint- method to draw the content and more imporantly: the basic stuff around the panels.
        ///     Since it's always the same, it won't get overridden!
        /// </summary>
        /// <param name="e">The letter e - huehue</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if ((DateTime.Now - DtSecond).Seconds >= 1)
            {
                //Debug.WriteLine("The OnPaint- loop was refreshed " + lTimesRefreshed + " times in a second!");
                IterationsPerSeconds = _iTimesRefreshed;
                _iTimesRefreshed = 0;
                DtSecond = DateTime.Now;
            }
            _iTimesRefreshed++;

            base.OnPaint(e);


            //_swMainWatch.Reset();
            //_swMainWatch.Start();

            var context = new BufferedGraphicsContext();
            context.MaximumBuffer = ClientSize;

            using (var buffer = context.Allocate(e.Graphics, ClientRectangle))
            {
                buffer.Graphics.Clear(BackColor);
                buffer.Graphics.CompositingMode = CompositingMode.SourceOver;
                buffer.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
                buffer.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                buffer.Graphics.SmoothingMode = SmoothingMode.HighSpeed;


                if (GInformation != null &&
                    GInformation.Gameinfo != null &&
                    GInformation.Gameinfo.IsIngame)
                {
                    if (PSettings.PreferenceAll.Global.DrawOnlyInForeground && !BSurpressForeground)
                    {
                        _bDraw = PSc2Process != null && Interop.GetForegroundWindow().Equals(PSc2Process.MainWindowHandle);
                    }

                    else
                    {
                        _bDraw = true;

                        if (PSc2Process == null)
                        {
                            _bDraw = false;
                            PSc2Process = GInformation.CStarcraft2;
                        }

                        else if (Interop.GetForegroundWindow().Equals(PSc2Process.MainWindowHandle))
                        {
                            Interop.SetActiveWindow(Handle);
                        }
                    }


                    if (_bDraw)
                    {
                        Draw(buffer);

                        DrawResizeBorder(buffer);
                    }
                }


                buffer.Render();
            }

            context.Dispose();

            //_swMainWatch.Stop();
            //Debug.WriteLine("Time to execute DrawingMethods:" + 1000000 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency + " µs");
        }

        /// <summary>
        ///     Override the FormClosing to stop the user from actually destroying the window.
        ///     The BaseRenderer is designed to never die.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Hide();

            if (!IsAllowedToClose)
                e.Cancel = true;

            OnCloseCalled();

            base.OnFormClosing(e);
        }

        /// <summary>
        ///     Sorts the Construction- states of a unit- List. (Units in production)
        /// </summary>
        /// <param name="lCounter"></param>
        protected void SortConstructionStates(ref List<UnitCount> lCounter)
        {
            for (var i = 0; i < lCounter.Count; i++)
            {
                lCounter[i].ConstructionState.Sort((x, y) => y.CompareTo(x));
            }
        }

        /// <summary>
        ///     Sorts the AliveSince- states of a unit- List. (e.g. Mules, Forces, Locusts)
        /// </summary>
        /// <param name="lCounter"></param>
        protected void SortAliveSinceStates(ref List<UnitCount> lCounter)
        {
            for (var i = 0; i < lCounter.Count; i++)
            {
                lCounter[i].AliveSince.Sort((x, y) => x.CompareTo(y));
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Override Hide- Method to change the IsHidden property [true].
        /// </summary>
        public new void Hide()
        {
            _.Info($"Hide Panel {Name}", _.InfoImportance.Important);
            IsHidden = true;

            IterationsPerSeconds = 99999;

            tmrRefreshGraphic.Enabled = false;

            OnHideCalled();

            base.Hide();

            //Thread.Sleep(100);
        }

        /// <summary>
        ///     Override Show- Method to change the IsHidden property [false].
        /// </summary>
        public new void Show()
        {
            _.Info($"Show Panel {Name}", _.InfoImportance.Important);
            IsHidden = false;

            tmrRefreshGraphic.Enabled = true;

            OnShowCalled();

            base.Show();

            //Thread.Sleep(100);
        }

        /// <summary>
        ///     Toggles the Show/ Hide based on the state of IsHidden
        /// </summary>
        public void ToggleShowHide()
        {
            if (IsHidden)
                Show();

            else
                Hide();
        }

        /// <summary>
        ///     Hide/ Show Form based on a boolean.
        /// </summary>
        /// <param name="show">Hide or Show</param>
        public void ToggleShowHide(bool show)
        {
            if (show)
                Show();

            else
                Hide();
        }

        /// <summary>
        ///     Simply reloads the Preferences and puts them into the controls
        /// </summary>
        public void ReloadPreferencesIntoControls()
        {
            LoadPreferencesIntoControls();
        }

        public void ChangeImageResources(bool useTransparentImages = false)
        {
            _.Info($"Change Image Resources. Use Transparent: {useTransparentImages} for Panel {Name}", _.InfoImportance.Important);

            if (!useTransparentImages)
            {
                #region Terran

                ImgTuScv = Resources.tu_scv;
                ImgTuMule = Resources.tu_Mule;
                ImgTuMarine = Resources.tu_marine;
                ImgTuMarauder = Resources.tu_marauder;
                ImgTuReaper = Resources.tu_reaper;
                ImgTuGhost = Resources.tu_ghost;
                ImgTuHellion = Resources.tu_hellion;
                ImgTuHellbat = Resources.tu_battlehellion;
                ImgTuSiegetank = Resources.tu_tank;
                ImgTuThor = Resources.tu_thor;
                ImgTuWidowMine = Resources.tu_widowmine;
                ImgTuViking = Resources.tu_vikingAir;
                ImgTuRaven = Resources.tu_raven;
                ImgTuMedivac = Resources.tu_medivac;
                ImgTuBattlecruiser = Resources.tu_battlecruiser;
                ImgTuBanshee = Resources.tu_banshee;
                ImgTuPointDefenseDrone = Resources.tu_pdd;
                ImgTuNuke = Resources.Tu_Nuke;

                ImgTbCc = Resources.tb_cc;
                ImgTbOc = Resources.tb_oc;
                ImgTbPf = Resources.tb_pf;
                ImgTbSupply = Resources.tb_supply;
                ImgTbRefinery = Resources.tb_refinery;
                ImgTbBarracks = Resources.tb_rax;
                ImgTbEbay = Resources.tb_ebay;
                ImgTbTurrent = Resources.tb_turret;
                ImgTbSensorTower = Resources.tb_sensor;
                ImgTbFactory = Resources.tb_fax;
                ImgTbStarport = Resources.tb_starport;
                ImgTbGhostacademy = Resources.tb_ghostacademy;
                ImgTbArmory = Resources.tb_Armory;
                ImgTbBunker = Resources.tb_bunker;
                ImgTbFusioncore = Resources.tb_fusioncore;
                ImgTbTechlab = Resources.tb_techlab;
                ImgTbReactor = Resources.tb_reactor;
                ImgTbAutoTurret = Resources.tb_autoturret;

                ImgTupStim = Resources.Tup_Stim;
                ImgTupConcussiveShells = Resources.Tup_ConcussiveShells;
                ImgTupCombatShields = Resources.Tup_CombatShields;
                ImgTupPersonalCloak = Resources.Tup_PersonalCloak;
                ImgTupMoebiusReactor = Resources.Tup_MoebiusReactor;
                ImgTupBlueFlame = Resources.Tup_BlueFlame;
                ImgTupTransformatorServos = Resources.Tup_TransformationServos;
                ImgTupDrillingClaws = Resources.Tup_DrillingClaws;
                ImgTupCloakingField = Resources.Tup_CloakingField;
                ImgTupDurableMaterials = Resources.Tup_DurableMaterials;
                ImgTupCaduceusReactor = Resources.Tup_CaduceusReactor;
                ImgTupCorvidReactor = Resources.Tup_CorvidReactor;
                ImgTupBehemothReacot = Resources.Tup_BehemothReactor;
                ImgTupWeaponRefit = Resources.Tup_WeaponRefit;
                ImgTupInfantryWeapon1 = Resources.Tup_InfantyWeapon1;
                ImgTupInfantryWeapon2 = Resources.Tup_InfantyWeapon2;
                ImgTupInfantryWeapon3 = Resources.Tup_InfantyWeapon3;
                ImgTupInfantryArmor1 = Resources.Tup_InfantyArmor1;
                ImgTupInfantryArmor2 = Resources.Tup_InfantyArmor2;
                ImgTupInfantryArmor3 = Resources.Tup_InfantyArmor3;
                ImgTupVehicleWeapon1 = Resources.Tup_VehicleWeapon1;
                ImgTupVehicleWeapon2 = Resources.Tup_VehicleWeapon2;
                ImgTupVehicleWeapon3 = Resources.Tup_VehicleWeapon3;
                ImgTupShipWeapon1 = Resources.Tup_ShipWeapon1;
                ImgTupShipWeapon2 = Resources.Tup_ShipWeapon2;
                ImgTupShipWeapon3 = Resources.Tup_ShipWeapon3;
                ImgTupVehicleShipPlanting1 = Resources.Tup_VehicleShipPlanting1;
                ImgTupVehicleShipPlanting2 = Resources.Tup_VehicleShipPlanting2;
                ImgTupVehicleShipPlanting3 = Resources.Tup_VehicleShipPlanting3;
                ImgTupHighSecAutoTracking = Resources.Tup_HighSecAutotracking;
                ImgTupStructureArmor = Resources.Tup_StructureArmor;
                ImgTupNeosteelFrame = Resources.Tup_NeosteelFrame;

                #endregion

                #region Protoss

                ImgPuProbe = Resources.pu_probe;
                ImgPuZealot = Resources.pu_Zealot;
                ImgPuStalker = Resources.pu_Stalker;
                ImgPuSentry = Resources.pu_sentry;
                ImgPuDarkTemplar = Resources.pu_DarkTemplar;
                ImgPuHighTemplar = Resources.pu_ht;
                ImgPuColossus = Resources.pu_Colossus;
                ImgPuImmortal = Resources.pu_immortal;
                ImgPuWapprism = Resources.pu_warpprism;
                ImgPuObserver = Resources.pu_Observer;
                ImgPuOracle = Resources.pu_oracle;
                ImgPuTempest = Resources.pu_tempest;
                ImgPuPhoenix = Resources.pu_pheonix;
                ImgPuVoidray = Resources.pu_Voidray;
                ImgPuCarrier = Resources.pu_carrier;
                ImgPuMothershipcore = Resources.pu_mothershipcore;
                ImgPuMothership = Resources.pu_Mothership;
                ImgPuArchon = Resources.pu_Archon;

                ImgPbNexus = Resources.pb_Nexus;
                ImgPbPylon = Resources.pb_Pylon;
                ImgPbGateway = Resources.pb_gateway;
                ImgPbWarpgate = Resources.pb_warpgate;
                ImgPbAssimilator = Resources.pb_Assimilator;
                ImgPbForge = Resources.pb_forge;
                ImgPbCannon = Resources.pb_Cannon;
                ImgPbCybercore = Resources.pb_cybercore;
                ImgPbStargate = Resources.pb_stargate;
                ImgPbRobotics = Resources.pb_robotics;
                ImgPbRoboticsSupport = Resources.pb_roboticssupport;
                ImgPbTwillightCouncil = Resources.pb_twillightCouncil;
                ImgPbDarkShrine = Resources.pb_DarkShrine;
                ImgPbTemplarArchives = Resources.pb_templararchives;
                ImgPbFleetBeacon = Resources.pb_FleetBeacon;

                ImgPupGroundWeapon1 = Resources.Pup_GroundW1;
                ImgPupGroundWeapon2 = Resources.Pup_GroundW2;
                ImgPupGroundWeapon3 = Resources.Pup_GroundW3;
                ImgPupGroundArmor1 = Resources.Pup_GroundA1;
                ImgPupGroundArmor2 = Resources.Pup_GroundA2;
                ImgPupGroundArmor3 = Resources.Pup_GroundA3;
                ImgPupShield1 = Resources.Pup_S1;
                ImgPupShield2 = Resources.Pup_S2;
                ImgPupShield3 = Resources.Pup_S3;
                ImgPupAirWeapon1 = Resources.Pup_AirW1;
                ImgPupAirWeapon2 = Resources.Pup_AirW2;
                ImgPupAirWeapon3 = Resources.Pup_AirW3;
                ImgPupAirArmor1 = Resources.Pup_AirA1;
                ImgPupAirArmor2 = Resources.Pup_AirA2;
                ImgPupAirArmor3 = Resources.Pup_AirA3;
                ImgPupBlink = Resources.Pup_Blink;
                ImgPupCharge = Resources.Pup_Charge;
                ImgPupGraviticBooster = Resources.Pup_GraviticBoosters;
                ImgPupGraviticDrive = Resources.Pup_GraviticDrive;
                ImgPupExtendedThermalLance = Resources.Pup_ExtendedThermalLance;
                ImgPupAnionPulseCrystals = Resources.Pup_AnionPulseCrystals;
                ImgPupGravitonCatapult = Resources.Pup_GravitonCatapult;
                ImgPupWarpGate = Resources.Pup_Warpgate;
                ImgPupStorm = Resources.Pup_Storm;
                ImgPupForcefield = Resources.PuForceField;

                #endregion

                #region Zerg

                ImgZuDrone = Resources.zu_drone;
                ImgZuLarva = Resources.zu_larva;
                ImgZuZergling = Resources.zu_zergling;
                ImgZuBaneling = Resources.zu_baneling;
                ImgZuBanelingCocoon = Resources.zu_banelingcocoon;
                ImgZuRoach = Resources.zu_roach;
                ImgZuHydra = Resources.zu_hydra;
                ImgZuMutalisk = Resources.zu_mutalisk;
                ImgZuUltra = Resources.zu_ultra;
                ImgZuViper = Resources.zu_viper;
                ImgZuSwarmhost = Resources.zu_swarmhost;
                ImgZuInfestor = Resources.zu_infestor;
                ImgInfestedTerran = Resources.zu_infestedterran;
                ImgInfestedTerranEgg = Resources.zu_infestedterran;
                ImgZuCorruptor = Resources.zu_corruptor;
                ImgZuBroodlord = Resources.zu_broodlord;
                ImgZuBroodlordCocoon = Resources.zu_broodlordcocoon;
                ImgZuQueen = Resources.zu_queen;
                ImgZuOverlord = Resources.zu_overlord;
                ImgZuOverseer = Resources.zu_overseer;
                ImgZuOvserseerCocoon = Resources.zu_overseercocoon;
                ImgZuLocust = Resources.zu_locust;
                ImgZuFlyingLocust = Resources.zup_flying_locust;
                ImgZuChangeling = Resources.zu_changeling;
                ImgZuBroodling = Resources.trans_zu_broodling;

                ImgZbHatchery = Resources.zb_hatchery;
                ImgZbLair = Resources.zb_lair;
                ImgZbHive = Resources.zb_hive;
                ImgZbCreepTumor = Resources.Zb_Creep_Tumor;
                ImgZbSpawningpool = Resources.zb_spawningpool;
                ImgZbExtractor = Resources.zb_extactor;
                ImgZbEvochamber = Resources.zb_evochamber;
                ImgZbSpinecrawler = Resources.zb_spine;
                ImgZbSporecrawler = Resources.zb_spore;
                ImgZbRoachwarren = Resources.zb_roachwarren;
                ImgZbGreaterspire = Resources.zb_greaterspire;
                ImgZbSpire = Resources.zb_spire;
                ImgZbNydusNetwork = Resources.zb_nydusnetwork;
                ImgZbNydusWorm = Resources.zb_nydusworm;
                ImgZbHydraden = Resources.zb_hydraden;
                ImgZbInfestationpit = Resources.zb_infestationpit;
                ImgZbUltracavern = Resources.zb_ultracavery;
                ImgZbBanelingnest = Resources.zb_banelingnest;

                ImgZupAirWeapon1 = Resources.Zup_AirW1;
                ImgZupAirWeapon2 = Resources.Zup_AirW2;
                ImgZupAirWeapon3 = Resources.Zup_AirW3;
                ImgZupAirArmor1 = Resources.Zup_AirA1;
                ImgZupAirArmor2 = Resources.Zup_AirA2;
                ImgZupAirArmor3 = Resources.Zup_AirA3;
                ImgZupGroundWeapon1 = Resources.Zup_GroundW1;
                ImgZupGroundWeapon2 = Resources.Zup_GroundW2;
                ImgZupGroundWeapon3 = Resources.Zup_GroundW3;
                ImgZupGroundArmor1 = Resources.Zup_GroundA1;
                ImgZupGroundArmor2 = Resources.Zup_GroundA2;
                ImgZupGroundArmor3 = Resources.Zup_GroundA3;
                ImgZupGroundMelee1 = Resources.Zup_GroundM1;
                ImgZupGroundMelee2 = Resources.Zup_GroundM2;
                ImgZupGroundMelee3 = Resources.Zup_GroundM3;
                ImgZupBurrow = Resources.Zup_Burrow;
                ImgZupAdrenalGlands = Resources.Zup_AdrenalGlands;
                ImgZupCentrifugalHooks = Resources.Zup_CentrifugalHooks;
                ImgZupChitinousPlating = Resources.Zup_ChitinousPlating;
                ImgZupEnduringLocusts = Resources.Zup_EnduringLocusts;
                ImgZupGlialReconstruction = Resources.Zup_GlialReconstruction;
                ImgZupGroovedSpines = Resources.Zup_GroovedSpines;
                ImgZupMetabolicBoost = Resources.Zup_MetabolicBoost;
                ImgZupMuscularAugments = Resources.Zup_MuscularAugments;
                ImgZupNeutralParasite = Resources.Zup_NeutralParasite;
                ImgZupPathoglenGlands = Resources.Zup_PathogenGlands;
                ImgZupPneumatizedCarapace = Resources.Zup_PneumatizedCarapace;
                ImgZupTunnelingClaws = Resources.Zup_TunnelingClaws;
                ImgZupVentrallSacs = Resources.Zup_VentralSacs;
                ImgZupFlyingLocust = Resources.zup_flying_locust;

                #endregion
            }

            else
            {
                #region Terran

                ImgTuScv = Resources.trans_tu_scv;
                ImgTuMule = Resources.trans_tu_mule;
                ImgTuMarine = Resources.trans_tu_marine;
                ImgTuMarauder = Resources.trans_tu_marauder;
                ImgTuReaper = Resources.trans_tu_reaper;
                ImgTuGhost = Resources.trans_tu_ghost;
                ImgTuHellion = Resources.trans_tu_hellion;
                ImgTuHellbat = Resources.trans_tu_hellbat;
                ImgTuSiegetank = Resources.trans_tu_siegetank;
                ImgTuThor = Resources.trans_tu_thor;
                ImgTuWidowMine = Resources.trans_tu_widowmine;
                ImgTuViking = Resources.trans_tu_vikingair;
                ImgTuRaven = Resources.trans_tu_raven;
                ImgTuMedivac = Resources.trans_tu_medivac;
                ImgTuBattlecruiser = Resources.trans_tu_battlecruiser;
                ImgTuBanshee = Resources.trans_tu_banshee;
                ImgTuPointDefenseDrone = Resources.trans_tu_pdd;
                ImgTuNuke = Resources.trans_tu_nuke;

                ImgTbCc = Resources.trans_tb_commandcenter;
                ImgTbOc = Resources.trans_tb_orbitalcommand;
                ImgTbPf = Resources.trans_tb_planetaryfortress;
                ImgTbSupply = Resources.trans_tb_supplydepot;
                ImgTbRefinery = Resources.trans_tb_refinery;
                ImgTbBarracks = Resources.trans_tb_barracks;
                ImgTbEbay = Resources.trans_tb_engineeringbay;
                ImgTbTurrent = Resources.trans_tb_missileturret;
                ImgTbSensorTower = Resources.trans_tb_sensortower;
                ImgTbFactory = Resources.trans_tb_factory;
                ImgTbStarport = Resources.trans_tb_starport;
                ImgTbGhostacademy = Resources.trans_tb_ghostacademy;
                ImgTbArmory = Resources.trans_tb_armory;
                ImgTbBunker = Resources.trans_tb_bunker;
                ImgTbFusioncore = Resources.trans_tb_fusioncore;
                ImgTbTechlab = Resources.trans_tb_techlab;
                ImgTbReactor = Resources.trans_tb_reactor;
                ImgTbAutoTurret = Resources.trans_tb_autoturret;

                ImgTupStim = Resources.trans_Tup_Stim;
                ImgTupConcussiveShells = Resources.trans_Tup_ConcussiveShells;
                ImgTupCombatShields = Resources.trans_Tup_CombatShields;
                ImgTupPersonalCloak = Resources.trans_Tup_PersonalCloak;
                ImgTupMoebiusReactor = Resources.trans_Tup_MoebiusReactor;
                ImgTupBlueFlame = Resources.trans_Tup_BlueFlame;
                ImgTupTransformatorServos = Resources.trans_Tup_TransformationServos;
                ImgTupDrillingClaws = Resources.trans_Tup_DrillingClaws;
                ImgTupCloakingField = Resources.trans_Tup_CloakingField;
                ImgTupDurableMaterials = Resources.trans_Tup_DurableMaterials;
                ImgTupCaduceusReactor = Resources.trans_Tup_CaduceusReactor;
                ImgTupCorvidReactor = Resources.trans_Tup_CorvidReactor;
                ImgTupBehemothReacot = Resources.trans_BehemothReactor;
                ImgTupWeaponRefit = Resources.trans_tup_weaponrefit;
                ImgTupInfantryWeapon1 = Resources.trans_Tup_InfantyWeapon1;
                ImgTupInfantryWeapon2 = Resources.trans_Tup_InfantyWeapon2;
                ImgTupInfantryWeapon3 = Resources.trans_Tup_InfantyWeapon3;
                ImgTupInfantryArmor1 = Resources.trans_Tup_InfantyArmor1;
                ImgTupInfantryArmor2 = Resources.trans_Tup_InfantyArmor2;
                ImgTupInfantryArmor3 = Resources.trans_Tup_InfantyArmor3;
                ImgTupVehicleWeapon1 = Resources.trans_Tup_VehicleWeapon1;
                ImgTupVehicleWeapon2 = Resources.trans_Tup_VehicleWeapon2;
                ImgTupVehicleWeapon3 = Resources.trans_Tup_VehicleWeapon3;
                ImgTupShipWeapon1 = Resources.trans_Tup_ShipWeapon1;
                ImgTupShipWeapon2 = Resources.trans_Tup_ShipWeapon2;
                ImgTupShipWeapon3 = Resources.trans_Tup_ShipWeapon3;
                ImgTupVehicleShipPlanting1 = Resources.trans_Tup_VehicleShipPlanting1;
                ImgTupVehicleShipPlanting2 = Resources.trans_Tup_VehicleShipPlanting2;
                ImgTupVehicleShipPlanting3 = Resources.trans_Tup_VehicleShipPlanting3;
                ImgTupHighSecAutoTracking = Resources.trans_Tup_HighSecAutotracking;
                ImgTupStructureArmor = Resources.trans_Tup_StructureArmor;
                ImgTupNeosteelFrame = Resources.trans_Tup_NeosteelFrame;

                #endregion

                #region Protoss

                ImgPuProbe = Resources.trans_pu_probe;
                ImgPuZealot = Resources.trans_pu_zealot;
                ImgPuStalker = Resources.trans_pu_stalker;
                ImgPuSentry = Resources.trans_pu_sentry;
                ImgPuDarkTemplar = Resources.trans_pu_darktemplar;
                ImgPuHighTemplar = Resources.trans_pu_hightemplar;
                ImgPuColossus = Resources.trans_pu_colossus;
                ImgPuImmortal = Resources.trans_pu_immortal;
                ImgPuWapprism = Resources.trans_pu_warpprism;
                ImgPuObserver = Resources.trans_pu_observer;
                ImgPuOracle = Resources.trans_pu_oracle;
                ImgPuTempest = Resources.trans_pu_tempest;
                ImgPuPhoenix = Resources.trans_pu_phoenix;
                ImgPuVoidray = Resources.trans_pu_voidray;
                ImgPuCarrier = Resources.trans_pu_carrier;
                ImgPuMothershipcore = Resources.trans_pu_mothershipcore;
                ImgPuMothership = Resources.trans_pu_mothership;
                ImgPuArchon = Resources.trans_pu_archon;

                ImgPbNexus = Resources.trans_pb_nexus;
                ImgPbPylon = Resources.trans_pb_pylon;
                ImgPbGateway = Resources.trans_pb_gateway;
                ImgPbWarpgate = Resources.trans_pb_warpgate;
                ImgPbAssimilator = Resources.trans_pb_assimilator;
                ImgPbForge = Resources.trans_pb_forge;
                ImgPbCannon = Resources.trans_pb_photoncannon;
                ImgPbCybercore = Resources.trans_pb_cyberneticscore;
                ImgPbStargate = Resources.trans_pb_stargate;
                ImgPbRobotics = Resources.trans_pb_roboticsfacility;
                ImgPbRoboticsSupport = Resources.trans_pb_roboticsbay;
                ImgPbTwillightCouncil = Resources.trans_pb_twilightcouncil;
                ImgPbDarkShrine = Resources.trans_pb_darkshrine;
                ImgPbTemplarArchives = Resources.trans_pb_templararchive;
                ImgPbFleetBeacon = Resources.trans_pb_fleetbeacon;

                ImgPupGroundWeapon1 = Resources.trans_Pup_GroundW1;
                ImgPupGroundWeapon2 = Resources.trans_Pup_GroundW2;
                ImgPupGroundWeapon3 = Resources.trans_Pup_GroundW3;
                ImgPupGroundArmor1 = Resources.trans_Pup_GroundA1;
                ImgPupGroundArmor2 = Resources.trans_Pup_GroundA2;
                ImgPupGroundArmor3 = Resources.trans_Pup_GroundA3;
                ImgPupShield1 = Resources.trans_Pup_S1;
                ImgPupShield2 = Resources.trans_Pup_S2;
                ImgPupShield3 = Resources.trans_Pup_S3;
                ImgPupAirWeapon1 = Resources.trans_Pup_AirW1;
                ImgPupAirWeapon2 = Resources.trans_Pup_AirW2;
                ImgPupAirWeapon3 = Resources.trans_Pup_AirW3;
                ImgPupAirArmor1 = Resources.trans_Pup_AirA1;
                ImgPupAirArmor2 = Resources.trans_Pup_AirA2;
                ImgPupAirArmor3 = Resources.trans_Pup_AirA3;
                ImgPupBlink = Resources.trans_Pup_Blink;
                ImgPupCharge = Resources.trans_Pup_Charge;
                ImgPupGraviticBooster = Resources.trans_Pup_GraviticBoosters;
                ImgPupGraviticDrive = Resources.trans_Pup_GraviticDrive;
                ImgPupExtendedThermalLance = Resources.trans_Pup_ExtendedThermalLance;
                ImgPupAnionPulseCrystals = Resources.trans_Pup_AnionPulseCrystals;
                ImgPupGravitonCatapult = Resources.trans_Pup_GravitonCatapult;
                ImgPupWarpGate = Resources.trans_Pup_Warpgate;
                ImgPupStorm = Resources.trans_Pup_Storm;
                ImgPupForcefield = Resources.trans_pup_forcefield;

                #endregion

                #region Zerg

                ImgZuDrone = Resources.trans_zu_drone;
                ImgZuLarva = Resources.trans_zu_larva;
                ImgZuZergling = Resources.trans_zu_zergling;
                ImgZuBaneling = Resources.trans_zu_baneling;
                ImgZuBanelingCocoon = Resources.trans_zu_banelingcocoon;
                ImgZuRoach = Resources.trans_zu_roach;
                ImgZuHydra = Resources.trans_zu_hydralisk;
                ImgZuMutalisk = Resources.trans_zu_mutalisk;
                ImgZuUltra = Resources.trans_zu_ultralisk;
                ImgZuViper = Resources.trans_zu_viper;
                ImgZuSwarmhost = Resources.trans_zu_swarmhost;
                ImgZuInfestor = Resources.trans_zu_infestor;
                ImgInfestedTerran = Resources.trans_zu_InfestedTerran;
                ImgInfestedTerranEgg = Resources.trans_zu_InfestedTerran;
                ImgZuCorruptor = Resources.trans_zu_corruptor;
                ImgZuBroodlord = Resources.trans_zu_broodlord;
                ImgZuBroodlordCocoon = Resources.trans_zu_BroodLordCocoon;
                ImgZuQueen = Resources.trans_zu_queen;
                ImgZuOverlord = Resources.trans_zu_overlord;
                ImgZuOverseer = Resources.trans_zu_overseer;
                ImgZuOvserseerCocoon = Resources.trans_zu_OverlordCocoon;
                ImgZuLocust = Resources.trans_zu_locust;
                ImgZuFlyingLocust = Resources.trans_Zup_flying_locust;
                ImgZuChangeling = Resources.trans_zu_changeling;
                ImgZuBroodling = Resources.trans_zu_broodling;

                ImgZbHatchery = Resources.trans_zb_hatchery;
                ImgZbLair = Resources.trans_zb_lair;
                ImgZbHive = Resources.trans_zb_hive;
                ImgZbCreepTumor = Resources.trans_zb_creeptumor;
                ImgZbSpawningpool = Resources.trans_zb_spawningpool;
                ImgZbExtractor = Resources.trans_zb_extractor;
                ImgZbEvochamber = Resources.trans_zb_evolutionchamber;
                ImgZbSpinecrawler = Resources.trans_zb_spinecrawler;
                ImgZbSporecrawler = Resources.trans_zb_sporecrawler;
                ImgZbRoachwarren = Resources.trans_zb_roachwarren;
                ImgZbGreaterspire = Resources.trans_zb_greaterspire;
                ImgZbSpire = Resources.trans_zb_spire;
                ImgZbNydusNetwork = Resources.trans_zb_nydusnetwork;
                ImgZbNydusWorm = Resources.trans_zb_nyduscanal;
                ImgZbHydraden = Resources.trans_zb_hydraliskden;
                ImgZbInfestationpit = Resources.trans_zb_infestationpit;
                ImgZbUltracavern = Resources.trans_zb_ultraliskcavern;
                ImgZbBanelingnest = Resources.trans_zb_banelingnest;

                ImgZupAirWeapon1 = Resources.trans_Zup_AirW1;
                ImgZupAirWeapon2 = Resources.trans_Zup_AirW2;
                ImgZupAirWeapon3 = Resources.trans_Zup_AirW3;
                ImgZupAirArmor1 = Resources.trans_Zup_AirA1;
                ImgZupAirArmor2 = Resources.trans_Zup_AirA2;
                ImgZupAirArmor3 = Resources.trans_Zup_AirA3;
                ImgZupGroundWeapon1 = Resources.trans_Zup_GroundW1;
                ImgZupGroundWeapon2 = Resources.trans_Zup_GroundW2;
                ImgZupGroundWeapon3 = Resources.trans_Zup_GroundW3;
                ImgZupGroundArmor1 = Resources.trans_Zup_GroundA1;
                ImgZupGroundArmor2 = Resources.trans_Zup_GroundA2;
                ImgZupGroundArmor3 = Resources.trans_Zup_GroundA3;
                ImgZupGroundMelee1 = Resources.trans_Zup_GroundM1;
                ImgZupGroundMelee2 = Resources.trans_Zup_GroundM2;
                ImgZupGroundMelee3 = Resources.trans_Zup_GroundM3;
                ImgZupBurrow = Resources.trans_Zup_Burrow;
                ImgZupAdrenalGlands = Resources.trans_Zup_AdrenalGlands;
                ImgZupCentrifugalHooks = Resources.trans_Zup_CentrifugalHooks;
                ImgZupChitinousPlating = Resources.trans_Zup_ChitinousPlating;
                ImgZupEnduringLocusts = Resources.trans_Zup_EnduringLocusts;
                ImgZupGlialReconstruction = Resources.trans_Zup_GlialReconstruction;
                ImgZupGroovedSpines = Resources.trans_Zup_GroovedSpines;
                ImgZupMetabolicBoost = Resources.trans_Zup_MetabolicBoost;
                ImgZupMuscularAugments = Resources.trans_Zup_MuscularAugments;
                ImgZupNeutralParasite = Resources.trans_Zup_NeutralParasite;
                ImgZupPathoglenGlands = Resources.trans_Zup_PathogenGlands;
                ImgZupPneumatizedCarapace = Resources.trans_Zup_PneumatizedCarapace;
                ImgZupTunnelingClaws = Resources.trans_Zup_TunnelingClaws;
                ImgZupVentrallSacs = Resources.trans_Zup_VentralSacs;
                ImgZupFlyingLocust = Resources.trans_Zup_flying_locust;

                #endregion
            }
        }

        #endregion

        protected void CountUnits()
        {
#if !DEBUG
            try
            {
#endif
                if (GInformation.Gameinfo == null ||
                    !GInformation.Gameinfo.IsIngame ||
                    GInformation.Player.Count <= 0 ||
                    GInformation.Unit.Count <= 0)
                    return;

                #region Clear the Lists

                #region Terran

                if (LTbCommandCenter.Count > 0)
                    LTbCommandCenter.Clear();

                if (LTbOrbitalCommand.Count > 0)
                    LTbOrbitalCommand.Clear();

                if (LTbPlanetaryFortress.Count > 0)
                    LTbPlanetaryFortress.Clear();

                if (LTbBarracks.Count > 0)
                    LTbBarracks.Clear();

                if (LTbSupply.Count > 0)
                    LTbSupply.Clear();

                if (LTbRefinery.Count > 0)
                    LTbRefinery.Clear();

                if (LTbBunker.Count > 0)
                    LTbBunker.Clear();

                if (LTbTurrent.Count > 0)
                    LTbTurrent.Clear();

                if (LTbSensorTower.Count > 0)
                    LTbSensorTower.Clear();

                if (LTbEbay.Count > 0)
                    LTbEbay.Clear();

                if (LTbStarport.Count > 0)
                    LTbStarport.Clear();

                if (LTbFactory.Count > 0)
                    LTbFactory.Clear();

                if (LTbArmory.Count > 0)
                    LTbArmory.Clear();

                if (LTbFusionCore.Count > 0)
                    LTbFusionCore.Clear();

                if (LTbGhostAcademy.Count > 0)
                    LTbGhostAcademy.Clear();

                if (LTbReactor.Count > 0)
                    LTbReactor.Clear();

                if (LTbTechlab.Count > 0)
                    LTbTechlab.Clear();

                if (LTbAutoTurret.Count > 0)
                    LTbAutoTurret.Clear();


                if (LTuScv.Count > 0)
                    LTuScv.Clear();

                if (LTuMule.Count > 0)
                    LTuMule.Clear();

                if (LTuMarine.Count > 0)
                    LTuMarine.Clear();

                if (LTuMarauder.Count > 0)
                    LTuMarauder.Clear();

                if (LTuReaper.Count > 0)
                    LTuReaper.Clear();

                if (LTuGhost.Count > 0)
                    LTuGhost.Clear();

                if (LTuWidowMine.Count > 0)
                    LTuWidowMine.Clear();

                if (LTuSiegetank.Count > 0)
                    LTuSiegetank.Clear();

                if (LTuHellbat.Count > 0)
                    LTuHellbat.Clear();

                if (LTuHellion.Count > 0)
                    LTuHellion.Clear();

                if (LTuThor.Count > 0)
                    LTuThor.Clear();

                if (LTuBanshee.Count > 0)
                    LTuBanshee.Clear();

                if (LTuBattlecruiser.Count > 0)
                    LTuBattlecruiser.Clear();

                if (LTuViking.Count > 0)
                    LTuViking.Clear();

                if (LTuRaven.Count > 0)
                    LTuRaven.Clear();

                if (LTuMedivac.Count > 0)
                    LTuMedivac.Clear();

                if (LTuPointDefenseDrone.Count > 0)
                    LTuPointDefenseDrone.Clear();

                if (LTuNuke.Count > 0)
                    LTuNuke.Clear();


                if (LTupStim.Count > 0)
                    LTupStim.Clear();

                if (LTupBehemothReactor.Count > 0)
                    LTupBehemothReactor.Clear();

                if (LTupBlueFlame.Count > 0)
                    LTupBlueFlame.Clear();

                if (LTupCaduceusReactor.Count > 0)
                    LTupCaduceusReactor.Clear();

                if (LTupCloakingField.Count > 0)
                    LTupCloakingField.Clear();

                if (LTupCombatShields.Count > 0)
                    LTupCombatShields.Clear();

                if (LTupConcussiveShells.Count > 0)
                    LTupConcussiveShells.Clear();

                if (LTupCorvidReactor.Count > 0)
                    LTupCorvidReactor.Clear();

                if (LTupDrillingClaws.Count > 0)
                    LTupDrillingClaws.Clear();

                if (LTupDurableMaterials.Count > 0)
                    LTupDurableMaterials.Clear();

                if (LTupHighSecAutoTracking.Count > 0)
                    LTupHighSecAutoTracking.Clear();

                if (LTupInfantryArmor1.Count > 0)
                    LTupInfantryArmor1.Clear();

                if (LTupInfantryArmor2.Count > 0)
                    LTupInfantryArmor2.Clear();

                if (LTupInfantryArmor3.Count > 0)
                    LTupInfantryArmor3.Clear();

                if (LTupInfantryWeapon1.Count > 0)
                    LTupInfantryWeapon1.Clear();

                if (LTupInfantryWeapon2.Count > 0)
                    LTupInfantryWeapon2.Clear();

                if (LTupInfantryWeapon3.Count > 0)
                    LTupInfantryWeapon3.Clear();

                if (LTupMoebiusReactor.Count > 0)
                    LTupMoebiusReactor.Clear();

                if (LTupNeosteelFrame.Count > 0)
                    LTupNeosteelFrame.Clear();

                if (LTupOrbitalCommand.Count > 0)
                    LTupOrbitalCommand.Clear();

                if (LTupPersonalCloak.Count > 0)
                    LTupPersonalCloak.Clear();

                if (LTupPlanetaryFortress.Count > 0)
                    LTupPlanetaryFortress.Clear();

                if (LTupShipWeapon1.Count > 0)
                    LTupShipWeapon1.Clear();

                if (LTupShipWeapon2.Count > 0)
                    LTupShipWeapon2.Clear();

                if (LTupShipWeapon3.Count > 0)
                    LTupShipWeapon3.Clear();

                if (LTupStructureArmor.Count > 0)
                    LTupStructureArmor.Clear();

                if (LTupTransformationServos.Count > 0)
                    LTupTransformationServos.Clear();

                if (LTupVehicleShipPlanting1.Count > 0)
                    LTupVehicleShipPlanting1.Clear();

                if (LTupVehicleShipPlanting2.Count > 0)
                    LTupVehicleShipPlanting2.Clear();

                if (LTupVehicleShipPlanting3.Count > 0)
                    LTupVehicleShipPlanting3.Clear();

                if (LTupVehicleWeapon1.Count > 0)
                    LTupVehicleWeapon1.Clear();

                if (LTupVehicleWeapon2.Count > 0)
                    LTupVehicleWeapon2.Clear();

                if (LTupVehicleWeapon3.Count > 0)
                    LTupVehicleWeapon3.Clear();

                if (LTupWeaponRefit.Count > 0)
                    LTupWeaponRefit.Clear();

                #endregion

                #region Protoss

                if (LPbAssimilator.Count > 0)
                    LPbAssimilator.Clear();

                if (LPbNexus.Count > 0)
                    LPbNexus.Clear();

                if (LPbPylon.Count > 0)
                    LPbPylon.Clear();

                if (LPbGateway.Count > 0)
                    LPbGateway.Clear();

                if (LPbWarpgate.Count > 0)
                    LPbWarpgate.Clear();

                if (LPbForge.Count > 0)
                    LPbForge.Clear();

                if (LPbCannon.Count > 0)
                    LPbCannon.Clear();

                if (LPbTwilight.Count > 0)
                    LPbTwilight.Clear();

                if (LPbTemplarArchives.Count > 0)
                    LPbTemplarArchives.Clear();

                if (LPbDarkshrine.Count > 0)
                    LPbDarkshrine.Clear();

                if (LPbRobotics.Count > 0)
                    LPbRobotics.Clear();

                if (LPbRoboticsSupport.Count > 0)
                    LPbRoboticsSupport.Clear();

                if (LPbFleetbeacon.Count > 0)
                    LPbFleetbeacon.Clear();

                if (LPbCybercore.Count > 0)
                    LPbCybercore.Clear();

                if (LPbStargate.Count > 0)
                    LPbStargate.Clear();


                if (LPuArchon.Count > 0)
                    LPuArchon.Clear();

                if (LPuCarrier.Count > 0)
                    LPuCarrier.Clear();

                if (LPuColossus.Count > 0)
                    LPuColossus.Clear();

                if (LPuDt.Count > 0)
                    LPuDt.Clear();

                if (LPuHt.Count > 0)
                    LPuHt.Clear();

                if (LPuForcefield.Count > 0)
                    LPuForcefield.Clear();

                if (LPuImmortal.Count > 0)
                    LPuImmortal.Clear();

                if (LPuMothership.Count > 0)
                    LPuMothership.Clear();

                if (LPuMothershipcore.Count > 0)
                    LPuMothershipcore.Clear();

                if (LPuObserver.Count > 0)
                    LPuObserver.Clear();

                if (LPuOracle.Count > 0)
                    LPuOracle.Clear();

                if (LPuPhoenix.Count > 0)
                    LPuPhoenix.Clear();

                if (LPuProbe.Count > 0)
                    LPuProbe.Clear();

                if (LPuSentry.Count > 0)
                    LPuSentry.Clear();

                if (LPuStalker.Count > 0)
                    LPuStalker.Clear();

                if (LPuTempest.Count > 0)
                    LPuTempest.Clear();

                if (LPuVoidray.Count > 0)
                    LPuVoidray.Clear();

                if (LPuWarpprism.Count > 0)
                    LPuWarpprism.Clear();

                if (LPuZealot.Count > 0)
                    LPuZealot.Clear();


                if (LPupAirArmor1.Count > 0)
                    LPupAirArmor1.Clear();

                if (LPupAirArmor2.Count > 0)
                    LPupAirArmor2.Clear();

                if (LPupAirArmor3.Count > 0)
                    LPupAirArmor3.Clear();

                if (LPupAirWeapon1.Count > 0)
                    LPupAirWeapon1.Clear();

                if (LPupAirWeapon2.Count > 0)
                    LPupAirWeapon2.Clear();

                if (LPupAirWeapon3.Count > 0)
                    LPupAirWeapon3.Clear();

                if (LPupAnionPulseCrystal.Count > 0)
                    LPupAnionPulseCrystal.Clear();

                if (LPupBlink.Count > 0)
                    LPupBlink.Clear();

                if (LPupCharge.Count > 0)
                    LPupCharge.Clear();

                if (LPupExtendedThermalLance.Count > 0)
                    LPupExtendedThermalLance.Clear();

                if (LPupGraviticBooster.Count > 0)
                    LPupGraviticBooster.Clear();

                if (LPupGraviticDrive.Count > 0)
                    LPupGraviticDrive.Clear();

                if (LPupGravitonCatapult.Count > 0)
                    LPupGravitonCatapult.Clear();

                if (LPupGroundArmor1.Count > 0)
                    LPupGroundArmor1.Clear();

                if (LPupGroundArmor2.Count > 0)
                    LPupGroundArmor2.Clear();

                if (LPupGroundArmor3.Count > 0)
                    LPupGroundArmor3.Clear();

                if (LPupGroundWeapon1.Count > 0)
                    LPupGroundWeapon1.Clear();

                if (LPupGroundWeapon2.Count > 0)
                    LPupGroundWeapon2.Clear();

                if (LPupGroundWeapon3.Count > 0)
                    LPupGroundWeapon3.Clear();

                if (LPupShield1.Count > 0)
                    LPupShield1.Clear();

                if (LPupShield2.Count > 0)
                    LPupShield2.Clear();

                if (LPupShield3.Count > 0)
                    LPupShield3.Clear();

                if (LPupStorm.Count > 0)
                    LPupStorm.Clear();

                if (LPupWarpGate.Count > 0)
                    LPupWarpGate.Clear();

                #endregion

                #region Zerg

                if (LZbBanelingnest.Count > 0)
                    LZbBanelingnest.Clear();

                if (LZbEvochamber.Count > 0)
                    LZbEvochamber.Clear();

                if (LZbExtractor.Count > 0)
                    LZbExtractor.Clear();

                if (LZbGreaterspire.Count > 0)
                    LZbGreaterspire.Clear();

                if (LZbHatchery.Count > 0)
                    LZbHatchery.Clear();

                if (LZbHive.Count > 0)
                    LZbHive.Clear();

                if (LZbHydraden.Count > 0)
                    LZbHydraden.Clear();

                if (LZbInfestationpit.Count > 0)
                    LZbInfestationpit.Clear();

                if (LZbLair.Count > 0)
                    LZbLair.Clear();

                if (LZbNydusbegin.Count > 0)
                    LZbNydusbegin.Clear();

                if (LZbNydusend.Count > 0)
                    LZbNydusend.Clear();

                if (LZbRoachwarren.Count > 0)
                    LZbRoachwarren.Clear();

                if (LZbSpawningpool.Count > 0)
                    LZbSpawningpool.Clear();

                if (LZbSpine.Count > 0)
                    LZbSpine.Clear();

                if (LZbSpire.Count > 0)
                    LZbSpire.Clear();

                if (LZbSpore.Count > 0)
                    LZbSpore.Clear();

                if (LZbUltracavern.Count > 0)
                    LZbUltracavern.Clear();

                if (LZbCreepTumor.Count > 0)
                    LZbCreepTumor.Clear();


                if (LZuBaneling.Count > 0)
                    LZuBaneling.Clear();

                if (LZuBroodlord.Count > 0)
                    LZuBroodlord.Clear();

                if (LZuCorruptor.Count > 0)
                    LZuCorruptor.Clear();

                if (LZuDrone.Count > 0)
                    LZuDrone.Clear();

                if (LZuHydra.Count > 0)
                    LZuHydra.Clear();

                if (LZuBanelingCocoon.Count > 0)
                    LZuBanelingCocoon.Clear();

                if (LZuBroodlordCocoon.Count > 0)
                    LZuBroodlordCocoon.Clear();

                if (LZuInfestor.Count > 0)
                    LZuInfestor.Clear();

                if (LZuInfestedTerran.Count > 0)
                    LZuInfestedTerran.Clear();

                if (LZuInfestedTerranEgg.Count > 0)
                    LZuInfestedTerranEgg.Clear();

                if (LZuLarva.Count > 0)
                    LZuLarva.Clear();

                if (LZuMutalisk.Count > 0)
                    LZuMutalisk.Clear();

                if (LZuOverlord.Count > 0)
                    LZuOverlord.Clear();

                if (LZuOverseer.Count > 0)
                    LZuOverseer.Clear();

                if (LZuQueen.Count > 0)
                    LZuQueen.Clear();

                if (LZuRoach.Count > 0)
                    LZuRoach.Clear();

                if (LZuSwarmhost.Count > 0)
                    LZuSwarmhost.Clear();

                if (LZuUltralisk.Count > 0)
                    LZuUltralisk.Clear();

                if (LZuViper.Count > 0)
                    LZuViper.Clear();

                if (LZuLocust.Count > 0)
                    LZuLocust.Clear();

                if (LZuFlyingLocust.Count > 0)
                    LZuFlyingLocust.Clear();

                if (LZuZergling.Count > 0)
                    LZuZergling.Clear();

                if (LZuOverseerCocoon.Count > 0)
                    LZuOverseerCocoon.Clear();

                if (LZuChangeling.Count > 0)
                    LZuChangeling.Clear();

                if (LZuBroodling.Count > 0)
                    LZuBroodling.Clear();
                

                if (LZupAdrenalGlands.Count > 0)
                    LZupAdrenalGlands.Clear();

                if (LZupAirArmor1.Count > 0)
                    LZupAirArmor1.Clear();

                if (LZupAirArmor2.Count > 0)
                    LZupAirArmor2.Clear();

                if (LZupAirArmor3.Count > 0)
                    LZupAirArmor3.Clear();

                if (LZupAirWeapon1.Count > 0)
                    LZupAirWeapon1.Clear();

                if (LZupAirWeapon2.Count > 0)
                    LZupAirWeapon2.Clear();

                if (LZupAirWeapon3.Count > 0)
                    LZupAirWeapon3.Clear();

                if (LZupBurrow.Count > 0)
                    LZupBurrow.Clear();

                if (LZupCentrifugalHooks.Count > 0)
                    LZupCentrifugalHooks.Clear();

                if (LZupChitinousPlating.Count > 0)
                    LZupChitinousPlating.Clear();

                if (LZupEnduringLocusts.Count > 0)
                    LZupEnduringLocusts.Clear();

                if (LZupGlialReconstruction.Count > 0)
                    LZupGlialReconstruction.Clear();

                if (LZupGroovedSpines.Count > 0)
                    LZupGroovedSpines.Clear();

                if (LZupGroundArmor1.Count > 0)
                    LZupGroundArmor1.Clear();

                if (LZupGroundArmor2.Count > 0)
                    LZupGroundArmor2.Clear();

                if (LZupGroundArmor3.Count > 0)
                    LZupGroundArmor3.Clear();

                if (LZupGroundWeapon1.Count > 0)
                    LZupGroundWeapon1.Clear();

                if (LZupGroundWeapon2.Count > 0)
                    LZupGroundWeapon2.Clear();

                if (LZupGroundWeapon3.Count > 0)
                    LZupGroundWeapon3.Clear();

                if (LZupGroundMelee1.Count > 0)
                    LZupGroundMelee1.Clear();

                if (LZupGroundMelee2.Count > 0)
                    LZupGroundMelee2.Clear();

                if (LZupGroundMelee3.Count > 0)
                    LZupGroundMelee3.Clear();

                if (LZupMetabolicBoost.Count > 0)
                    LZupMetabolicBoost.Clear();

                if (LZupMuscularAugments.Count > 0)
                    LZupMuscularAugments.Clear();

                if (LZupNeutralParasite.Count > 0)
                    LZupNeutralParasite.Clear();

                if (LZupPathoglenGlands.Count > 0)
                    LZupPathoglenGlands.Clear();

                if (LZupPneumatizedCarapace.Count > 0)
                    LZupPneumatizedCarapace.Clear();

                if (LZupTunnnelingClaws.Count > 0)
                    LZupTunnnelingClaws.Clear();

                if (LZupVentralSacs.Count > 0)
                    LZupVentralSacs.Clear();

                if (LZupFlyingLocust.Count > 0)
                    LZupFlyingLocust.Clear();

                #endregion

                #endregion

                #region Setup for the dummy- values

                for (var i = 0; i < GInformation.Player.Count; i++)
                {
                    #region Terran

                    #region Units

                    LTuScv.Add(new UnitCount());
                    LTuBanshee.Add(new UnitCount());
                    LTuBattlecruiser.Add(new UnitCount());
                    LTuGhost.Add(new UnitCount());
                    LTuHellbat.Add(new UnitCount());
                    LTuHellion.Add(new UnitCount());
                    LTuMarauder.Add(new UnitCount());
                    LTuMarine.Add(new UnitCount());
                    LTuMedivac.Add(new UnitCount());
                    LTuMule.Add(new UnitCount());
                    LTuNuke.Add(new UnitCount());
                    LTuPointDefenseDrone.Add(new UnitCount());
                    LTuRaven.Add(new UnitCount());
                    LTuReaper.Add(new UnitCount());
                    LTuSiegetank.Add(new UnitCount());
                    LTuThor.Add(new UnitCount());
                    LTuViking.Add(new UnitCount());
                    LTuWidowMine.Add(new UnitCount());

                    #endregion

                    #region Buildings

                    LTbArmory.Add(new UnitCount());
                    LTbAutoTurret.Add(new UnitCount());
                    LTbBarracks.Add(new UnitCount());
                    LTbBunker.Add(new UnitCount());
                    LTbCommandCenter.Add(new UnitCount());
                    LTbEbay.Add(new UnitCount());
                    LTbFactory.Add(new UnitCount());
                    LTbFusionCore.Add(new UnitCount());
                    LTbGhostAcademy.Add(new UnitCount());
                    LTbOrbitalCommand.Add(new UnitCount());
                    LTbPlanetaryFortress.Add(new UnitCount());
                    LTbReactor.Add(new UnitCount());
                    LTbRefinery.Add(new UnitCount());
                    LTbSensorTower.Add(new UnitCount());
                    LTbStarport.Add(new UnitCount());
                    LTbSupply.Add(new UnitCount());
                    LTbTechlab.Add(new UnitCount());
                    LTbTurrent.Add(new UnitCount());

                    #endregion

                    #region Upgrades

                    LTupBehemothReactor.Add(new UnitCount());
                    LTupBlueFlame.Add(new UnitCount());
                    LTupCaduceusReactor.Add(new UnitCount());
                    LTupCloakingField.Add(new UnitCount());
                    LTupCombatShields.Add(new UnitCount());
                    LTupConcussiveShells.Add(new UnitCount());
                    LTupCorvidReactor.Add(new UnitCount());
                    LTupDrillingClaws.Add(new UnitCount());
                    LTupDurableMaterials.Add(new UnitCount());
                    LTupHighSecAutoTracking.Add(new UnitCount());
                    LTupInfantryArmor1.Add(new UnitCount());
                    LTupInfantryArmor2.Add(new UnitCount());
                    LTupInfantryArmor3.Add(new UnitCount());
                    LTupInfantryWeapon1.Add(new UnitCount());
                    LTupInfantryWeapon2.Add(new UnitCount());
                    LTupInfantryWeapon3.Add(new UnitCount());
                    LTupMoebiusReactor.Add(new UnitCount());
                    LTupNeosteelFrame.Add(new UnitCount());
                    LTupOrbitalCommand.Add(new UnitCount());
                    LTupPersonalCloak.Add(new UnitCount());
                    LTupPlanetaryFortress.Add(new UnitCount());
                    LTupShipWeapon1.Add(new UnitCount());
                    LTupShipWeapon2.Add(new UnitCount());
                    LTupShipWeapon3.Add(new UnitCount());
                    LTupStim.Add(new UnitCount());
                    LTupStructureArmor.Add(new UnitCount());
                    LTupTransformationServos.Add(new UnitCount());
                    LTupVehicleShipPlanting1.Add(new UnitCount());
                    LTupVehicleShipPlanting2.Add(new UnitCount());
                    LTupVehicleShipPlanting3.Add(new UnitCount());
                    LTupVehicleWeapon1.Add(new UnitCount());
                    LTupVehicleWeapon2.Add(new UnitCount());
                    LTupVehicleWeapon3.Add(new UnitCount());
                    LTupWeaponRefit.Add(new UnitCount());

                    #endregion

                    #endregion

                    #region Protoss

                    #region Units

                    LPuArchon.Add(new UnitCount());
                    LPuCarrier.Add(new UnitCount());
                    LPuColossus.Add(new UnitCount());
                    LPuDt.Add(new UnitCount());
                    LPuHt.Add(new UnitCount());
                    LPuImmortal.Add(new UnitCount());
                    LPuMothership.Add(new UnitCount());
                    LPuMothershipcore.Add(new UnitCount());
                    LPuObserver.Add(new UnitCount());
                    LPuOracle.Add(new UnitCount());
                    LPuPhoenix.Add(new UnitCount());
                    LPuProbe.Add(new UnitCount());
                    LPuSentry.Add(new UnitCount());
                    LPuStalker.Add(new UnitCount());
                    LPuTempest.Add(new UnitCount());
                    LPuVoidray.Add(new UnitCount());
                    LPuWarpprism.Add(new UnitCount());
                    LPuZealot.Add(new UnitCount());
                    LPuForcefield.Add(new UnitCount());

                    #endregion

                    #region Buildings

                    LPbAssimilator.Add(new UnitCount());
                    LPbCannon.Add(new UnitCount());
                    LPbCybercore.Add(new UnitCount());
                    LPbDarkshrine.Add(new UnitCount());
                    LPbFleetbeacon.Add(new UnitCount());
                    LPbForge.Add(new UnitCount());
                    LPbGateway.Add(new UnitCount());
                    LPbNexus.Add(new UnitCount());
                    LPbPylon.Add(new UnitCount());
                    LPbRobotics.Add(new UnitCount());
                    LPbRoboticsSupport.Add(new UnitCount());
                    LPbStargate.Add(new UnitCount());
                    LPbTemplarArchives.Add(new UnitCount());
                    LPbTwilight.Add(new UnitCount());
                    LPbWarpgate.Add(new UnitCount());

                    #endregion

                    #region Upgrades

                    LPupBlink.Add(new UnitCount());
                    LPupCharge.Add(new UnitCount());
                    LPupExtendedThermalLance.Add(new UnitCount());
                    LPupGraviticBooster.Add(new UnitCount());
                    LPupGraviticDrive.Add(new UnitCount());
                    LPupGravitonCatapult.Add(new UnitCount());
                    LPupGroundArmor1.Add(new UnitCount());
                    LPupGroundArmor2.Add(new UnitCount());
                    LPupGroundArmor3.Add(new UnitCount());
                    LPupGroundWeapon1.Add(new UnitCount());
                    LPupGroundWeapon2.Add(new UnitCount());
                    LPupGroundWeapon3.Add(new UnitCount());
                    LPupShield1.Add(new UnitCount());
                    LPupShield2.Add(new UnitCount());
                    LPupShield3.Add(new UnitCount());
                    LPupStorm.Add(new UnitCount());
                    LPupWarpGate.Add(new UnitCount());
                    LPupAirArmor1.Add(new UnitCount());
                    LPupAirArmor2.Add(new UnitCount());
                    LPupAirArmor3.Add(new UnitCount());
                    LPupAirWeapon1.Add(new UnitCount());
                    LPupAirWeapon2.Add(new UnitCount());
                    LPupAirWeapon3.Add(new UnitCount());
                    LPupAnionPulseCrystal.Add(new UnitCount());

                    #endregion

                    #endregion

                    #region Zerg

                    #region Units

                    LZuBaneling.Add(new UnitCount());
                    LZuBanelingCocoon.Add(new UnitCount());
                    LZuBroodlord.Add(new UnitCount());
                    LZuBroodlordCocoon.Add(new UnitCount());
                    LZuCorruptor.Add(new UnitCount());
                    LZuDrone.Add(new UnitCount());
                    LZuHydra.Add(new UnitCount());
                    LZuInfestor.Add(new UnitCount());
                    LZuInfestedTerran.Add(new UnitCount());
                    LZuInfestedTerranEgg.Add(new UnitCount());
                    LZuLarva.Add(new UnitCount());
                    LZuMutalisk.Add(new UnitCount());
                    LZuOverlord.Add(new UnitCount());
                    LZuOverseer.Add(new UnitCount());
                    LZuOverseerCocoon.Add(new UnitCount());
                    LZuQueen.Add(new UnitCount());
                    LZuRoach.Add(new UnitCount());
                    LZuSwarmhost.Add(new UnitCount());
                    LZuUltralisk.Add(new UnitCount());
                    LZuViper.Add(new UnitCount());
                    LZuZergling.Add(new UnitCount());
                    LZuLocust.Add(new UnitCount());
                    LZuFlyingLocust.Add(new UnitCount());
                    LZuChangeling.Add(new UnitCount());
                    LZuBroodling.Add(new UnitCount());

                    #endregion

                    #region Buildings

                    LZbBanelingnest.Add(new UnitCount());
                    LZbCreepTumor.Add(new UnitCount());
                    LZbEvochamber.Add(new UnitCount());
                    LZbExtractor.Add(new UnitCount());
                    LZbGreaterspire.Add(new UnitCount());
                    LZbHatchery.Add(new UnitCount());
                    LZbHive.Add(new UnitCount());
                    LZbHydraden.Add(new UnitCount());
                    LZbInfestationpit.Add(new UnitCount());
                    LZbLair.Add(new UnitCount());
                    LZbNydusbegin.Add(new UnitCount());
                    LZbNydusend.Add(new UnitCount());
                    LZbRoachwarren.Add(new UnitCount());
                    LZbSpawningpool.Add(new UnitCount());
                    LZbSpine.Add(new UnitCount());
                    LZbSpire.Add(new UnitCount());
                    LZbSpore.Add(new UnitCount());
                    LZbUltracavern.Add(new UnitCount());

                    #endregion

                    #region Upgrades

                    LZupAdrenalGlands.Add(new UnitCount());
                    LZupAirArmor1.Add(new UnitCount());
                    LZupAirArmor2.Add(new UnitCount());
                    LZupAirArmor3.Add(new UnitCount());
                    LZupAirWeapon1.Add(new UnitCount());
                    LZupAirWeapon2.Add(new UnitCount());
                    LZupAirWeapon3.Add(new UnitCount());
                    LZupBurrow.Add(new UnitCount());
                    LZupCentrifugalHooks.Add(new UnitCount());
                    LZupChitinousPlating.Add(new UnitCount());
                    LZupEnduringLocusts.Add(new UnitCount());
                    LZupGlialReconstruction.Add(new UnitCount());
                    LZupGroovedSpines.Add(new UnitCount());
                    LZupGroundArmor1.Add(new UnitCount());
                    LZupGroundArmor2.Add(new UnitCount());
                    LZupGroundArmor3.Add(new UnitCount());
                    LZupGroundMelee1.Add(new UnitCount());
                    LZupGroundMelee2.Add(new UnitCount());
                    LZupGroundMelee3.Add(new UnitCount());
                    LZupGroundWeapon1.Add(new UnitCount());
                    LZupGroundWeapon2.Add(new UnitCount());
                    LZupGroundWeapon3.Add(new UnitCount());
                    LZupMetabolicBoost.Add(new UnitCount());
                    LZupMuscularAugments.Add(new UnitCount());
                    LZupNeutralParasite.Add(new UnitCount());
                    LZupPathoglenGlands.Add(new UnitCount());
                    LZupPneumatizedCarapace.Add(new UnitCount());
                    LZupTunnnelingClaws.Add(new UnitCount());
                    LZupVentralSacs.Add(new UnitCount());
                    LZupFlyingLocust.Add(new UnitCount());

                    #endregion

                    #endregion
                }

                /* Forcefield.. */
                LPuForcefield.Add(new UnitCount());

                #endregion

                for (var j = 0; j < GInformation.Unit.Count; j++)
                {
                    var tmpUnit = GInformation.Unit[j];

                    if (tmpUnit.IsHallucination)
                        continue;

                    #region Alive

                    if (tmpUnit.IsAlive)
                    {
                        #region Terran

                        #region Units

                        if (tmpUnit.Id == UnitId.TuScv)
                            LTuScv[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.TuMule)
                        {
                            LTuMule[tmpUnit.Owner].UnitAmount += 1;
                            LTuMule[tmpUnit.Owner].Id = UnitId.TuMule;
                            LTuMule[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince/387328.0f));
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TuMarine)
                            LTuMarine[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuMarauder)
                            LTuMarauder[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuReaper)
                            LTuReaper[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.TuGhost)
                        {
                            LTuGhost[tmpUnit.Owner].UnitAmount += 1;
                            LTuGhost[tmpUnit.Owner].Id = UnitId.TuGhost;
                            LTuGhost[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            LTuGhost[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TuWidowMine ||
                                 tmpUnit.Id ==
                                 UnitId.TuWidowMineBurrow)
                            LTuWidowMine[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuSiegetank ||
                                 tmpUnit.Id ==
                                 UnitId.TuSiegetankSieged)
                            LTuSiegetank[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.TuThor)
                            LTuThor[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuHellbat)
                            LTuHellbat[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuNuke)
                            LTuNuke[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuHellion)
                            LTuHellion[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuBanshee)
                            LTuBanshee[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuBattlecruiser)
                            LTuBattlecruiser[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuMedivac)
                            LTuMedivac[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.TuRaven)
                            LTuRaven[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.TuPdd)
                            LTuPointDefenseDrone[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuVikingAir ||
                                 tmpUnit.Id ==
                                 UnitId.TuVikingGround)
                            LTuViking[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Buildings

                            #region Command Center (Air/ Ground/ Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbCcGround ||
                                 tmpUnit.Id == UnitId.TbCcAir)
                        {
                            LTbCommandCenter[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    LTuScv[tmpUnit.Owner].UnitUnderConstruction += 1;
                                    LTuScv[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                }
                            }

                            else
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupUpgradeToOrbital))
                                    {
                                        LTbOrbitalCommand[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTbOrbitalCommand[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupUpgradeToPlanetary))
                                    {
                                        LTbPlanetaryFortress[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTbPlanetaryFortress[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Orbital Command (Air/ Ground/ Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbOrbitalAir ||
                                 tmpUnit.Id ==
                                 UnitId.TbOrbitalGround)
                        {
                            LTbOrbitalCommand[tmpUnit.Owner].UnitAmount += 1;
                            LTbOrbitalCommand[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            LTbOrbitalCommand[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                            LTbOrbitalCommand[tmpUnit.Owner].Id = UnitId.TbOrbitalGround;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    LTuScv[tmpUnit.Owner].UnitUnderConstruction += 1;
                                    LTuScv[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                }
                            }
                        }

                            #endregion

                            #region Barracks (Air/ Ground/ Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbRaxAir ||
                                 tmpUnit.Id ==
                                 UnitId.TbBarracksGround)
                        {
                            LTbBarracks[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuMarine))
                                    {
                                        LTuMarine[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuMarine[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuMarauder))
                                    {
                                        LTuMarauder[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuMarauder[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuReaper))
                                    {
                                        LTuReaper[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuReaper[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuGhost))
                                    {
                                        LTuGhost[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuGhost[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Bunker

                        else if (tmpUnit.Id ==
                                 UnitId.TbBunker)
                            LTbBunker[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Turret

                        else if (tmpUnit.Id ==
                                 UnitId.TbTurret)
                            LTbTurrent[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Refinery

                        else if (tmpUnit.Id ==
                                 UnitId.TbRefinery)
                            LTbRefinery[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Sensor Tower

                        else if (tmpUnit.Id ==
                                 UnitId.TbSensortower)
                            LTbSensorTower[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Planetary (Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbPlanetary)
                        {
                            LTbPlanetaryFortress[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    LTuScv[tmpUnit.Owner].UnitUnderConstruction += 1;
                                    LTuScv[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                }
                            }
                        }

                            #endregion

                            #region Engineering Bay (Upgrade Production)

                        else if (tmpUnit.Id == UnitId.TbEbay)
                        {
                            LTbEbay[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupInfantryArmor1))
                                    {
                                        LTupInfantryArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupInfantryArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupInfantryArmor2))
                                    {
                                        LTupInfantryArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupInfantryArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupInfantryArmor3))
                                    {
                                        LTupInfantryArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupInfantryArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupInfantryWeapon1))
                                    {
                                        LTupInfantryWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupInfantryWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupInfantryWeapon2))
                                    {
                                        LTupInfantryWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupInfantryWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupInfantryWeapon3))
                                    {
                                        LTupInfantryWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupInfantryWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupHighSecAutoTracking))
                                    {
                                        LTupHighSecAutoTracking[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupHighSecAutoTracking[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupNeosteelFrame))
                                    {
                                        LTupNeosteelFrame[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupNeosteelFrame[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupStructureArmor))
                                    {
                                        LTupStructureArmor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupStructureArmor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Factory (Air/ Ground/ Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbFactoryAir ||
                                 tmpUnit.Id ==
                                 UnitId.TbFactoryGround)
                        {
                            LTbFactory[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuHellion))
                                    {
                                        LTuHellion[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuHellion[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuHellbat))
                                    {
                                        LTuHellbat[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuHellbat[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuWidowMine))
                                    {
                                        LTuWidowMine[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuWidowMine[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuSiegetank))
                                    {
                                        LTuSiegetank[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuSiegetank[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuThor))
                                    {
                                        LTuThor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuThor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Starport (Air/ Ground/ Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbStarportAir ||
                                 tmpUnit.Id ==
                                 UnitId.TbStarportGround)
                        {
                            LTbStarport[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuVikingAir))
                                    {
                                        LTuViking[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuViking[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuBanshee))
                                    {
                                        LTuBanshee[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuBanshee[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuMedivac))
                                    {
                                        LTuMedivac[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuMedivac[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuRaven))
                                    {
                                        LTuRaven[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuRaven[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuBattlecruiser))
                                    {
                                        LTuBattlecruiser[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuBattlecruiser[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Supply (Hidden/ Normal)

                        else if (tmpUnit.Id ==
                                 UnitId.TbSupplyGround ||
                                 tmpUnit.Id ==
                                 UnitId.TbSupplyHidden)
                            LTbSupply[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Ghost Academy (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbGhostacademy)
                        {
                            LTbGhostAcademy[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupPersonalCloak))
                                    {
                                        LTupPersonalCloak[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupPersonalCloak[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupMoebiusReactor))
                                    {
                                        LTupMoebiusReactor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupMoebiusReactor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuNuke))
                                    {
                                        LTuNuke[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTuNuke[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Fucion Core (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbFusioncore)
                        {
                            LTbFusionCore[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupWeaponRefit))
                                    {
                                        LTupWeaponRefit[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupWeaponRefit[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupBehemothReactor))
                                    {
                                        LTupBehemothReactor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupBehemothReactor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Armory (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbArmory)
                        {
                            LTbArmory[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupVehicleShipPlanting1))
                                    {
                                        LTupVehicleShipPlanting1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupVehicleShipPlanting1[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupVehicleShipPlanting2))
                                    {
                                        LTupVehicleShipPlanting2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupVehicleShipPlanting2[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupVehicleShipPlanting3))
                                    {
                                        LTupVehicleShipPlanting3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupVehicleShipPlanting3[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupVehicleWeapon1))
                                    {
                                        LTupVehicleWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupVehicleWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupVehicleWeapon2))
                                    {
                                        LTupVehicleWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupVehicleWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupVehicleWeapon3))
                                    {
                                        LTupVehicleWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupVehicleWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupShipWeapon1))
                                    {
                                        LTupShipWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupShipWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupShipWeapon2))
                                    {
                                        LTupShipWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupShipWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupShipWeapon3))
                                    {
                                        LTupShipWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupShipWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region AutoTurret

                        else if (tmpUnit.Id ==
                                 UnitId.TbAutoTurret)
                            LTbAutoTurret[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Techlab Barracks (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbTechlabRax)
                        {
                            LTbTechlab[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupStim))
                                    {
                                        LTupStim[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupStim[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupCombatShields))
                                    {
                                        LTupCombatShields[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupCombatShields[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupConcussiveShells))
                                    {
                                        LTupConcussiveShells[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupConcussiveShells[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Techlab Factory (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbTechlabFactory)
                        {
                            LTbTechlab[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupBlueFlame))
                                    {
                                        LTupBlueFlame[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupBlueFlame[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupDrillingClaws))
                                    {
                                        LTupDrillingClaws[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupDrillingClaws[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupTransformatorServos))
                                    {
                                        LTupTransformationServos[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupTransformationServos[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Techlab Starport (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbTechlabStarport)
                        {
                            LTbTechlab[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupCloakingField))
                                    {
                                        LTupCloakingField[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupCloakingField[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupCorvidReactor))
                                    {
                                        LTupCorvidReactor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupCorvidReactor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupCaduceusReactor))
                                    {
                                        LTupCaduceusReactor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupCaduceusReactor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupDurableMeterials))
                                    {
                                        LTupDurableMaterials[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LTupDurableMaterials[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Reactor (Normal, Starport, Factory, Barracks COMBINED)

                        else if (tmpUnit.Id ==
                                 UnitId.TbReactor ||
                                 tmpUnit.Id ==
                                 UnitId.TbReactorFactory ||
                                 tmpUnit.Id ==
                                 UnitId.TbReactorRax ||
                                 tmpUnit.Id ==
                                 UnitId.TbReactorStarport)
                            LTbReactor[tmpUnit.Owner].UnitAmount += 1;

                            #endregion


                            #endregion

                            #endregion

                            #region Protoss

                            #region Units

                        else if (tmpUnit.Id ==
                                 UnitId.PuForceField)
                        {
                            LPuForcefield[GInformation.Player.Count].UnitAmount += 1;
                            LPuForcefield[GInformation.Player.Count].Id =
                                UnitId.PuForceField;
                            LPuForcefield[GInformation.Player.Count].AliveSince.Add(1 -
                                                                                     (tmpUnit.AliveSince/
                                                                                      62208.0f));
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PuArchon)
                        {
                            LPuArchon[tmpUnit.Owner].UnitAmount += 1;

                            //Archons take 12 seconds to finish morphing
                            //12 secs = 49152 SC2 ticks (* 4096)
                            //Thus AliveSince > 49152 = Ready to roll

                            if (tmpUnit.AliveSince < 49152)
                            {
                                LPuArchon[tmpUnit.Owner].UnitUnderConstruction += 1;
                                LPuArchon[tmpUnit.Owner].ConstructionState.Add((tmpUnit.AliveSince/49152f)*100);
                            }
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PuCarrier)
                            LPuCarrier[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuColossus)
                            LPuColossus[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuDarktemplar)
                            LPuDt[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuHightemplar)
                        {
                            LPuHt[tmpUnit.Owner].UnitAmount += 1;
                            LPuHt[tmpUnit.Owner].Id = UnitId.PuHightemplar;
                            LPuHt[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            LPuHt[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PuImmortal)
                            LPuImmortal[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuMothership)
                        {
                            LPuMothership[tmpUnit.Owner].UnitAmount += 1;
                            LPuMothership[tmpUnit.Owner].Id = UnitId.PuMothership;
                            LPuMothership[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            LPuMothership[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PuMothershipCore)
                        {
                            LPuMothershipcore[tmpUnit.Owner].UnitAmount += 1;
                            LPuMothershipcore[tmpUnit.Owner].Id = UnitId.PuMothershipCore;
                            LPuMothershipcore[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            LPuMothershipcore[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);

                            if (tmpUnit.ProdNumberOfQueuedUnits == 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupUpgradeToMothership))
                                    {
                                        LPuMothership[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuMothership[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PuObserver)
                            LPuObserver[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuOracle)
                            LPuOracle[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuPhoenix)
                            LPuPhoenix[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.PuProbe)
                            LPuProbe[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuSentry)
                        {
                            LPuSentry[tmpUnit.Owner].UnitAmount += 1;
                            LPuSentry[tmpUnit.Owner].Id = UnitId.PuSentry;
                            LPuSentry[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            LPuSentry[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PuStalker)
                            LPuStalker[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuTempest)
                            LPuTempest[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuVoidray)
                            LPuVoidray[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuWarpprismPhase ||
                                 tmpUnit.Id ==
                                 UnitId.PuWarpprismTransport)
                            LPuWarpprism[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuZealot)
                            LPuZealot[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Buildings

                            #region Nexus (Unit Production)

                        else if (tmpUnit.Id == UnitId.PbNexus)
                        {
                            LPbNexus[tmpUnit.Owner].UnitAmount += 1;
                            LPbNexus[tmpUnit.Owner].Id = tmpUnit.Id;
                            LPbNexus[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            LPbNexus[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PuProbe))
                                    {
                                        LPuProbe[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuProbe[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuProbe[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuMothershipCore))
                                    {
                                        LPuMothershipcore[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuMothershipcore[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuMothershipcore[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Pylon

                        else if (tmpUnit.Id == UnitId.PbPylon)
                            LPbPylon[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Assimilator

                        else if (tmpUnit.Id ==
                                 UnitId.PbAssimilator)
                            LPbAssimilator[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Cannon

                        else if (tmpUnit.Id ==
                                 UnitId.PbCannon)
                            LPbCannon[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region CyberCore (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbCybercore)
                        {
                            LPbCybercore[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupAirA1))
                                    {
                                        LPupAirArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupAirArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupAirArmor1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupAirA2))
                                    {
                                        LPupAirArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupAirArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupAirArmor2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupAirA3))
                                    {
                                        LPupAirArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupAirArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupAirArmor3[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupAirW1))
                                    {
                                        LPupAirWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupAirWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupAirWeapon1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupAirW2))
                                    {
                                        LPupAirWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupAirWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupAirWeapon2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupAirW3))
                                    {
                                        LPupAirWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupAirWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupAirWeapon3[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupWarpGate))
                                    {
                                        LPupWarpGate[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupWarpGate[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupWarpGate[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                        LPupWarpGate[tmpUnit.Owner].Id = UnitId.PupWarpGate;
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Dark Shrine

                        else if (tmpUnit.Id ==
                                 UnitId.PbDarkshrine)
                            LPbDarkshrine[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Fleet Beacon (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbFleetbeacon)
                        {
                            LPbFleetbeacon[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupAnionPulseCrystals))
                                    {
                                        LPupAnionPulseCrystal[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupAnionPulseCrystal[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                        LPupAnionPulseCrystal[tmpUnit.Owner].SpeedMultiplier.Add(
                                            tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGravitonCatapult))
                                    {
                                        LPupGravitonCatapult[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupGravitonCatapult[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                        LPupGravitonCatapult[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Forge (Upgrade Production)

                        else if (tmpUnit.Id == UnitId.PbForge)
                        {
                            LPbForge[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGroundA1))
                                    {
                                        LPupGroundArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupGroundArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupGroundArmor1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGroundA2))
                                    {
                                        LPupGroundArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupGroundArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupGroundArmor2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGroundA3))
                                    {
                                        LPupGroundArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupGroundArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupGroundArmor3[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGroundW1))
                                    {
                                        LPupGroundWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupGroundWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupGroundWeapon1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGroundW2))
                                    {
                                        LPupGroundWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupGroundWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupGroundWeapon2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGroundW3))
                                    {
                                        LPupGroundWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupGroundWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupGroundWeapon3[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupS1))
                                    {
                                        LPupShield1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupShield1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupShield1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupS2))
                                    {
                                        LPupShield2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupShield2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupShield2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupS3))
                                    {
                                        LPupShield3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupShield3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupShield3[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Gateway (Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbGateway)
                        {
                            LPbGateway[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PuZealot))
                                    {
                                        LPuZealot[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuZealot[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuZealot[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuStalker))
                                    {
                                        LPuStalker[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuStalker[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuStalker[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuSentry))
                                    {
                                        LPuSentry[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuSentry[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuSentry[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuHightemplar))
                                    {
                                        LPuHt[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuHt[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuHt[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuDarktemplar))
                                    {
                                        LPuDt[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuDt[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuDt[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Robotics Bay (Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbRoboticsbay)
                        {
                            LPbRobotics[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PuObserver))
                                    {
                                        LPuObserver[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuObserver[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuObserver[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuWarpprismTransport))
                                    {
                                        LPuWarpprism[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuWarpprism[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuWarpprism[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuImmortal))
                                    {
                                        LPuImmortal[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuImmortal[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuImmortal[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuColossus))
                                    {
                                        LPuColossus[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuColossus[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuColossus[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Robotics Support Bay (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbRoboticssupportbay)
                        {
                            LPbRoboticsSupport[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupExtendedThermalLance))
                                    {
                                        LPupExtendedThermalLance[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupExtendedThermalLance[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                        LPupExtendedThermalLance[tmpUnit.Owner].SpeedMultiplier.Add(
                                            tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGraviticBooster))
                                    {
                                        LPupGraviticBooster[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupGraviticBooster[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupGraviticBooster[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGraviticDrive))
                                    {
                                        LPupGraviticDrive[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupGraviticDrive[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupGraviticDrive[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Stargate (Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbStargate)
                        {
                            LPbStargate[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PuPhoenix))
                                    {
                                        LPuPhoenix[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuPhoenix[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuPhoenix[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuOracle))
                                    {
                                        LPuOracle[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuOracle[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuOracle[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuVoidray))
                                    {
                                        LPuVoidray[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuVoidray[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuVoidray[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuCarrier))
                                    {
                                        LPuCarrier[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuCarrier[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuCarrier[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuTempest))
                                    {
                                        LPuTempest[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPuTempest[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPuTempest[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Templar Archives (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbTemplararchives)
                        {
                            LPbTemplarArchives[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupStorm))
                                    {
                                        LPupStorm[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupStorm[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupStorm[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Twilight Council (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbTwilightcouncil)
                        {
                            LPbTwilight[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupBlink))
                                    {
                                        LPupBlink[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupBlink[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupBlink[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupCharge))
                                    {
                                        LPupCharge[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LPupCharge[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        LPupCharge[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region WarpGate (Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbWarpgate)
                            LPbWarpgate[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #endregion

                            #endregion

                            #region Zerg

                            #region Units

                        else if (tmpUnit.Id ==
                                 UnitId.ZuEgg)
                        {
                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZuDrone))
                                    {
                                        LZuDrone[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuDrone[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuOverlord))
                                    {
                                        LZuOverlord[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuOverlord[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuZergling))
                                    {
                                        LZuZergling[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuZergling[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuRoach))
                                    {
                                        LZuRoach[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuRoach[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuHydralisk))
                                    {
                                        LZuHydra[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuHydra[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuMutalisk))
                                    {
                                        LZuMutalisk[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuMutalisk[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuInfestor))
                                    {
                                        LZuInfestor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuInfestor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuUltra))
                                    {
                                        LZuUltralisk[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuUltralisk[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuCorruptor))
                                    {
                                        LZuCorruptor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuCorruptor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuViper))
                                    {
                                        LZuViper[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuViper[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuSwarmHost))
                                    {
                                        LZuSwarmhost[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuSwarmhost[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBaneling ||
                                 tmpUnit.Id ==
                                 UnitId.ZuBanelingBurrow)
                            LZuBaneling[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuLocust)
                        {
                            LZuLocust[tmpUnit.Owner].UnitAmount += 1;
                            LZuLocust[tmpUnit.Owner].Id = UnitId.ZuLocust;

                            if (tmpUnit.AliveSince > 73216f)
                                LZuLocust[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince/113920f));

                            else
                                LZuLocust[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince/73216f));
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZuFlyingLocust)
                        {
                            LZuFlyingLocust[tmpUnit.Owner].UnitAmount += 1;
                            LZuFlyingLocust[tmpUnit.Owner].Id = UnitId.ZuFlyingLocust;

                            if (tmpUnit.AliveSince > 73216f)
                                LZuFlyingLocust[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince / 113920f));

                            else
                                LZuFlyingLocust[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince / 73216f));
                        }


                        else if (tmpUnit.Id ==
                                 UnitId.ZuBanelingCocoon)
                        {
                            LZuBanelingCocoon[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZuBaneling))
                                    {
                                        LZuBaneling[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuBaneling[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBroodlord)
                            LZuBroodlord[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBroodlordCocoon)
                        {
                            LZuBroodlordCocoon[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits == 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupUpgradeToBroodlord))
                                    {
                                        LZuBroodlord[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuBroodlord[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZuCorruptor)
                            LZuCorruptor[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.ZuDrone ||
                                 tmpUnit.Id ==
                                 UnitId.ZuDroneBurrow)
                            LZuDrone[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuHydraBurrow ||
                                 tmpUnit.Id ==
                                 UnitId.ZuHydralisk)
                            LZuHydra[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuInfestor ||
                                 tmpUnit.Id ==
                                 UnitId.ZuInfestorBurrow)
                        {
                            LZuInfestor[tmpUnit.Owner].UnitAmount += 1;
                            LZuInfestor[tmpUnit.Owner].Id = UnitId.ZuInfestor;
                            LZuInfestor[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            LZuInfestor[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZuInfestedTerran ||
                                 tmpUnit.Id ==
                                 UnitId.ZuInfestedTerran2)
                        {
                            LZuInfestedTerran[tmpUnit.Owner].UnitAmount += 1;
                            LZuInfestedTerran[tmpUnit.Owner].Id = UnitId.ZuInfestedTerran;
                            LZuInfestedTerran[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince / 143360f));
                        }

                        else if (tmpUnit.Id == UnitId.ZuInfestedSwarmEgg)
                        {
                            LZuInfestedTerranEgg[tmpUnit.Owner].UnitUnderConstruction += 1;
                            LZuInfestedTerranEgg[tmpUnit.Owner].Id = UnitId.ZuInfestedSwarmEgg;
                            LZuInfestedTerranEgg[tmpUnit.Owner].ConstructionState.Add(tmpUnit.AliveSince/20480f * 100);

                        }

                        else if (tmpUnit.Id == UnitId.ZuLarva)
                            LZuLarva[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuMutalisk)
                            LZuMutalisk[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuOverlord)
                            LZuOverlord[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBroodling)
                        {
                            LZuBroodling[tmpUnit.Owner].UnitAmount += 1;
                            LZuBroodling[tmpUnit.Owner].Id = UnitId.ZuBroodling;
                            LZuBroodling[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince / 32768f));
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZuOverseer)
                            LZuOverseer[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuOverseerCocoon)
                        {
                            LZuOverseerCocoon[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits == 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupUpgradeToOverseer))
                                    {
                                        LZuOverseer[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuOverseer[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        else if (tmpUnit.Id == UnitId.ZuQueen ||
                                 tmpUnit.Id ==
                                 UnitId.ZuQueenBurrow)
                        {
                            LZuQueen[tmpUnit.Owner].UnitAmount += 1;
                            LZuQueen[tmpUnit.Owner].Id = UnitId.ZuQueen;
                            LZuQueen[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            LZuQueen[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                        }

                        else if (tmpUnit.Id == UnitId.ZuRoach ||
                                 tmpUnit.Id ==
                                 UnitId.ZuRoachBurrow)
                            LZuRoach[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuSwarmHost ||
                                 tmpUnit.Id ==
                                 UnitId.ZuSwarmHostBurrow)
                            LZuSwarmhost[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.ZuUltra ||
                                 tmpUnit.Id ==
                                 UnitId.ZuUltraBurrow)
                            LZuUltralisk[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.ZuViper)
                        {
                            LZuViper[tmpUnit.Owner].UnitAmount += 1;
                            LZuViper[tmpUnit.Owner].Id = UnitId.ZuViper;
                            LZuViper[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            LZuViper[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZuZergling ||
                                 tmpUnit.Id ==
                                 UnitId.ZuZerglingBurrow)
                            LZuZergling[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.ZuChangeling ||
                                 tmpUnit.Id == UnitId.ZuChangelingMarineShield ||
                                 tmpUnit.Id == UnitId.ZuChangelingMarine ||
                                 tmpUnit.Id == UnitId.ZuChangelingSpeedling ||
                                 tmpUnit.Id == UnitId.ZuChangelingZealot ||
                                 tmpUnit.Id == UnitId.ZuChangelingZergling)
                        {
                            LZuChangeling[tmpUnit.Owner].UnitAmount += 1;
                            LZuChangeling[tmpUnit.Owner].Id = UnitId.ZuChangeling;
                            LZuChangeling[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince / 614400f));
                        }

                            #endregion

                            #region Structures

                            #region Baneling Nest (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbBanelingNest)
                        {
                            LZbBanelingnest[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupCentrifugalHooks))
                                    {
                                        LZupCentrifugalHooks[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupCentrifugalHooks[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Creeptumor

                        else if (tmpUnit.Id ==
                                 UnitId.ZbCreeptumor ||
                                 tmpUnit.Id ==
                                 UnitId.ZbCreeptumorBurrowed ||
                                 tmpUnit.Id ==
                                 UnitId.ZbCreepTumorMissle ||
                                 tmpUnit.Id ==
                                 UnitId.ZbCreepTumorBuilding)
                            LZbCreepTumor[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Evolution Chamber (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbEvolutionChamber)
                        {
                            LZbEvochamber[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundA1))
                                    {
                                        LZupGroundArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupGroundArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundA2))
                                    {
                                        LZupGroundArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupGroundArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundA3))
                                    {
                                        LZupGroundArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupGroundArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundW1))
                                    {
                                        LZupGroundWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupGroundWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundW2))
                                    {
                                        LZupGroundWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupGroundWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundW3))
                                    {
                                        LZupGroundWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupGroundWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundM1))
                                    {
                                        LZupGroundMelee1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupGroundMelee1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundM2))
                                    {
                                        LZupGroundMelee2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupGroundMelee2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundM3))
                                    {
                                        LZupGroundMelee3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupGroundMelee3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Extractor

                        else if (tmpUnit.Id ==
                                 UnitId.ZbExtractor)
                            LZbExtractor[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Greater Spire (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbGreaterspire)
                        {
                            LZbGreaterspire[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirA1))
                                    {
                                        LZupAirArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupAirArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirA2))
                                    {
                                        LZupAirArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupAirArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirA3))
                                    {
                                        LZupAirArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupAirArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirW1))
                                    {
                                        LZupAirWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupAirWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirW2))
                                    {
                                        LZupAirWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupAirWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirW3))
                                    {
                                        LZupAirWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupAirWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Hatchery (Unit Production, Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbHatchery)
                        {
                            LZbHatchery[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZuQueen))
                                    {
                                        LZuQueen[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuQueen[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupVentralSacs))
                                    {
                                        LZupVentralSacs[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupVentralSacs[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupBurrow))
                                    {
                                        LZupBurrow[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupBurrow[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupPneumatizedCarapace))
                                    {
                                        LZupPneumatizedCarapace[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupPneumatizedCarapace[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }

                            //Upgrade To Lair
                            else
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupUpgradeToLair))
                                    {
                                        LZbLair[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZbLair[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Hive (Unit Production, Upgrade Production)

                        else if (tmpUnit.Id == UnitId.ZbHive)
                        {
                            LZbHive[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZuQueen))
                                    {
                                        LZuQueen[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuQueen[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupVentralSacs))
                                    {
                                        LZupVentralSacs[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupVentralSacs[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupBurrow))
                                    {
                                        LZupBurrow[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupBurrow[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupPneumatizedCarapace))
                                    {
                                        LZupPneumatizedCarapace[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupPneumatizedCarapace[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Hydra Den (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbHydraDen)
                        {
                            LZbHydraden[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroovedSpines))
                                    {
                                        LZupGroovedSpines[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupGroovedSpines[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupMuscularAugments))
                                    {
                                        LZupMuscularAugments[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupMuscularAugments[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Infestation Pit (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbInfestationPit)
                        {
                            LZbInfestationpit[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupNeutralParasite))
                                    {
                                        LZupNeutralParasite[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupNeutralParasite[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupEnduringLocusts))
                                    {
                                        LZupEnduringLocusts[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupEnduringLocusts[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupPathoglenGlands))
                                    {
                                        LZupPathoglenGlands[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupPathoglenGlands[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(UnitId.ZupFlyingLocust))
                                    {
                                        LZupFlyingLocust[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupFlyingLocust[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Liar (Unit Production, Upgrade Production)

                        else if (tmpUnit.Id == UnitId.ZbLiar)
                        {
                            LZbLair[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZuQueen))
                                    {
                                        LZuQueen[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZuQueen[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupVentralSacs))
                                    {
                                        LZupVentralSacs[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupVentralSacs[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupBurrow))
                                    {
                                        LZupBurrow[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupBurrow[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupPneumatizedCarapace))
                                    {
                                        LZupPneumatizedCarapace[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupPneumatizedCarapace[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }

                            //Upgrade To Hive
                            else
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupUpgradeToHive))
                                    {
                                        LZbHive[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZbHive[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Nydus Network

                        else if (tmpUnit.Id ==
                                 UnitId.ZbNydusNetwork)
                            LZbNydusbegin[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Nydus Worm

                        else if (tmpUnit.Id ==
                                 UnitId.ZbNydusWorm)
                            LZbNydusend[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Roach Warran (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbRoachWarren)
                        {
                            LZbRoachwarren[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupTunnelingClaws))
                                    {
                                        LZupTunnnelingClaws[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupTunnnelingClaws[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupGlialReconstruction))
                                    {
                                        LZupGlialReconstruction[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupGlialReconstruction[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Spawning Pool (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbSpawningPool)
                        {
                            LZbSpawningpool[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupMetabolicBoost))
                                    {
                                        LZupMetabolicBoost[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupMetabolicBoost[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupAdrenalGlands))
                                    {
                                        LZupAdrenalGlands[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupAdrenalGlands[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Spine Crawler

                        else if (tmpUnit.Id ==
                                 UnitId.ZbSpineCrawler ||
                                 tmpUnit.Id ==
                                 UnitId.ZbSpineCrawlerUnrooted)
                            LZbSpine[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Spire (Upgrade Production)

                        else if (tmpUnit.Id == UnitId.ZbSpire)
                        {
                            LZbSpire[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirA1))
                                    {
                                        LZupAirArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupAirArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirA2))
                                    {
                                        LZupAirArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupAirArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirA3))
                                    {
                                        LZupAirArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupAirArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirW1))
                                    {
                                        LZupAirWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupAirWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirW2))
                                    {
                                        LZupAirWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupAirWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirW3))
                                    {
                                        LZupAirWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupAirWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }

                            //Upgrade To Greater Spire
                            else
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupUpgradeToGreaterSpire))
                                    {
                                        LZbGreaterspire[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZbGreaterspire[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Spore Crawler

                        else if (tmpUnit.Id ==
                                 UnitId.ZbSporeCrawler ||
                                 tmpUnit.Id ==
                                 UnitId.ZbSporeCrawlerUnrooted)
                            LZbSpore[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Ultra Cavern (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbUltraCavern)
                        {
                            LZbUltracavern[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupChitinousPlating))
                                    {
                                        LZupChitinousPlating[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        LZupChitinousPlating[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        #endregion

                        #endregion

                        #endregion
                    }

                    #endregion

                    #region Under Construction (Buildings)

                    if (tmpUnit.IsUnderConstruction ||
                        tmpUnit.BuildingState == 512)
                    {
                        #region Terran

                        #region Structures

                        if (tmpUnit.Id ==
                            UnitId.TbCcGround ||
                            tmpUnit.Id == UnitId.TbCcAir)
                        {
                            LTbCommandCenter[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbCommandCenter[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbOrbitalAir ||
                                 tmpUnit.Id ==
                                 UnitId.TbOrbitalGround)
                        {
                            LTbOrbitalCommand[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbOrbitalCommand[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbRaxAir ||
                                 tmpUnit.Id ==
                                 UnitId.TbBarracksGround)
                        {
                            LTbBarracks[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbBarracks[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbBunker)
                        {
                            LTbBunker[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbBunker[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbTurret)
                        {
                            LTbTurrent[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbTurrent[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbRefinery)
                        {
                            LTbRefinery[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbRefinery[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbSensortower)
                        {
                            LTbSensorTower[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbSensorTower[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbPlanetary)
                        {
                            LTbPlanetaryFortress[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbPlanetaryFortress[tmpUnit.Owner].ConstructionState.Add(tmp);


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    LTuScv[tmpUnit.Owner].UnitUnderConstruction += 1;
                                    LTuScv[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                }
                            }
                        }

                        else if (tmpUnit.Id == UnitId.TbEbay)
                        {
                            LTbEbay[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbEbay[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbFactoryAir ||
                                 tmpUnit.Id ==
                                 UnitId.TbFactoryGround)
                        {
                            LTbFactory[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbFactory[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbStarportAir ||
                                 tmpUnit.Id ==
                                 UnitId.TbStarportGround)
                        {
                            LTbStarport[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbStarport[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbSupplyGround ||
                                 tmpUnit.Id ==
                                 UnitId.TbSupplyHidden)
                        {
                            LTbSupply[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbSupply[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbGhostacademy)
                        {
                            LTbGhostAcademy[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbGhostAcademy[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbFusioncore)
                        {
                            LTbFusionCore[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbFusionCore[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbArmory)
                        {
                            LTbArmory[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbArmory[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbTechlab ||
                                 tmpUnit.Id ==
                                 UnitId.TbTechlabFactory ||
                                 tmpUnit.Id ==
                                 UnitId.TbTechlabRax ||
                                 tmpUnit.Id ==
                                 UnitId.TbTechlabStarport)
                        {
                            LTbTechlab[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbTechlab[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbReactor ||
                                 tmpUnit.Id ==
                                 UnitId.TbReactorFactory ||
                                 tmpUnit.Id ==
                                 UnitId.TbReactorRax ||
                                 tmpUnit.Id ==
                                 UnitId.TbReactorStarport)
                        {
                            LTbReactor[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LTbReactor[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                            #endregion

                            #region Units

                        else if (tmpUnit.Id == UnitId.TuScv)
                            LTuScv[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.TuMule)
                            LTuMule[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuMarine)
                            LTuMarine[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuMarauder)
                            LTuMarauder[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuReaper)
                            LTuReaper[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.TuGhost)
                            LTuGhost[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuWidowMine ||
                                 tmpUnit.Id ==
                                 UnitId.TuWidowMineBurrow)
                            LTuWidowMine[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuSiegetank ||
                                 tmpUnit.Id ==
                                 UnitId.TuSiegetankSieged)
                            LTuSiegetank[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.TuThor)
                            LTuThor[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuHellbat)
                            LTuHellbat[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuHellion)
                            LTuHellion[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuBanshee)
                            LTuBanshee[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuBattlecruiser)
                            LTuBattlecruiser[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuMedivac)
                            LTuMedivac[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.TuRaven)
                            LTuRaven[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuVikingAir ||
                                 tmpUnit.Id ==
                                 UnitId.TuVikingGround)
                            LTuViking[tmpUnit.Owner].UnitUnderConstruction += 1;



                            #endregion

                            #endregion

                            #region Protoss

                            #region Structures

                        else if (tmpUnit.Id == UnitId.PbNexus)
                        {
                            LPbNexus[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbNexus[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == UnitId.PbPylon)
                        {
                            LPbPylon[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbPylon[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbAssimilator)
                        {
                            LPbAssimilator[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbAssimilator[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbCannon)
                        {
                            LPbCannon[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbCannon[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbCybercore)
                        {
                            LPbCybercore[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbCybercore[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbDarkshrine)
                        {
                            LPbDarkshrine[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbDarkshrine[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbFleetbeacon)
                        {
                            LPbFleetbeacon[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbFleetbeacon[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == UnitId.PbForge)
                        {
                            LPbForge[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbForge[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbGateway)
                        {
                            LPbGateway[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbGateway[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbRoboticsbay)
                        {
                            LPbRobotics[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbRobotics[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbRoboticssupportbay)
                        {
                            LPbRoboticsSupport[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbRoboticsSupport[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbStargate)
                        {
                            LPbStargate[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbStargate[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbTemplararchives)
                        {
                            LPbTemplarArchives[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbTemplarArchives[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbTwilightcouncil)
                        {
                            LPbTwilight[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbTwilight[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbWarpgate)
                        {
                            LPbWarpgate[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LPbWarpgate[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                            #endregion

                            #region Units

                        /*else if (tmpUnit.Id ==
                            UnitId.PuArchon)
                            _lPuArchon[tmpUnit.Owner].UnitUnderConstruction += 1;*/

                        else if (tmpUnit.Id ==
                                 UnitId.PuCarrier)
                            LPuCarrier[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuColossus)
                            LPuColossus[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuDarktemplar)
                            LPuDt[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuHightemplar)
                            LPuHt[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuImmortal)
                            LPuImmortal[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuMothership)
                            LPuMothership[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuMothershipCore)
                            LPuMothershipcore[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuObserver)
                            LPuObserver[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuOracle)
                            LPuOracle[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuPhoenix)
                            LPuPhoenix[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.PuProbe)
                            LPuProbe[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuSentry)
                            LPuSentry[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuStalker)
                            LPuStalker[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuTempest)
                            LPuTempest[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuVoidray)
                            LPuVoidray[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuWarpprismPhase ||
                                 tmpUnit.Id ==
                                 UnitId.PuWarpprismTransport)
                            LPuWarpprism[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuZealot)
                            LPuZealot[tmpUnit.Owner].UnitUnderConstruction += 1;

                            #endregion

                            #endregion

                            #region Zerg

                            #region Structures

                        else if (tmpUnit.Id ==
                                 UnitId.ZbBanelingNest)
                        {
                            LZbBanelingnest[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbBanelingnest[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }


                        else if (tmpUnit.Id ==
                                 UnitId.ZbCreeptumor ||
                                 tmpUnit.Id ==
                                 UnitId.ZbCreeptumorBurrowed ||
                                 tmpUnit.Id ==
                                 UnitId.ZbCreepTumorMissle ||
                                 tmpUnit.Id ==
                                 UnitId.ZbCreepTumorBuilding)
                        {
                            LZbCreepTumor[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbCreepTumor[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbEvolutionChamber)
                        {
                            LZbEvochamber[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbEvochamber[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbExtractor)
                        {
                            LZbExtractor[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbExtractor[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbGreaterspire)
                        {
                            LZbGreaterspire[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbGreaterspire[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbHatchery)
                        {
                            LZbHatchery[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbHatchery[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == UnitId.ZbHive)
                        {
                            LZbHive[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbHive[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbHydraDen)
                        {
                            LZbHydraden[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbHydraden[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbInfestationPit)
                        {
                            LZbInfestationpit[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbInfestationpit[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == UnitId.ZbLiar)
                        {
                            LZbLair[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbLair[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbNydusNetwork)
                        {
                            LZbNydusbegin[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbNydusbegin[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbNydusWorm)
                        {
                            LZbNydusend[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp = tmpUnit.AliveSince/81920f * 100;
                            LZbNydusend[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbRoachWarren)
                        {
                            LZbRoachwarren[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbRoachwarren[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbSpawningPool)
                        {
                            LZbSpawningpool[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbSpawningpool[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbSpineCrawler ||
                                 tmpUnit.Id ==
                                 UnitId.ZbSpineCrawlerUnrooted)
                        {
                            LZbSpine[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbSpine[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == UnitId.ZbSpire)
                        {
                            LZbSpire[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbSpire[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbSporeCrawler ||
                                 tmpUnit.Id ==
                                 UnitId.ZbSporeCrawlerUnrooted)
                        {
                            LZbSpore[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            LZbSpore[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbUltraCavern)
                        {
                            LZbUltracavern[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);

                            LZbUltracavern[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                            #endregion

                            #region Units

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBaneling ||
                                 tmpUnit.Id ==
                                 UnitId.ZuBanelingBurrow)
                            LZuBaneling[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBanelingCocoon)
                            LZuBanelingCocoon[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBroodlord)
                            LZuBroodlord[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBroodlordCocoon)
                            LZuBroodlordCocoon[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuCorruptor)
                            LZuCorruptor[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.ZuDrone ||
                                 tmpUnit.Id ==
                                 UnitId.ZuDroneBurrow)
                            LZuDrone[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuHydraBurrow ||
                                 tmpUnit.Id ==
                                 UnitId.ZuHydralisk)
                            LZuHydra[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuInfestor ||
                                 tmpUnit.Id ==
                                 UnitId.ZuInfestorBurrow)
                            LZuInfestor[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.ZuLarva)
                            LZuLarva[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuMutalisk)
                            LZuMutalisk[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuOverlord)
                            LZuOverlord[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuOverseer)
                            LZuOverseer[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuOverseerCocoon)
                            LZuOverseerCocoon[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.ZuQueen ||
                                 tmpUnit.Id ==
                                 UnitId.ZuQueenBurrow)
                            LZuQueen[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.ZuRoach ||
                                 tmpUnit.Id ==
                                 UnitId.ZuRoachBurrow)
                            LZuRoach[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuSwarmHost ||
                                 tmpUnit.Id ==
                                 UnitId.ZuSwarmHostBurrow)
                            LZuSwarmhost[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.ZuUltra ||
                                 tmpUnit.Id ==
                                 UnitId.ZuUltraBurrow)
                            LZuUltralisk[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.ZuViper)
                            LZuViper[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuZergling ||
                                 tmpUnit.Id ==
                                 UnitId.ZuZerglingBurrow)
                            LZuZergling[tmpUnit.Owner].UnitUnderConstruction += 1;

                        #endregion

                        #endregion
                    }

                    #endregion
                }

                #region Sort Construction- states

                #region Terran

                SortConstructionStates(ref LTbArmory);
                SortConstructionStates(ref LTbAutoTurret);
                SortConstructionStates(ref LTbBarracks);
                SortConstructionStates(ref LTbBunker);
                SortConstructionStates(ref LTbCommandCenter);
                SortConstructionStates(ref LTbEbay);
                SortConstructionStates(ref LTbFactory);
                SortConstructionStates(ref LTbFusionCore);
                SortConstructionStates(ref LTbGhostAcademy);
                SortConstructionStates(ref LTbOrbitalCommand);
                SortConstructionStates(ref LTbPlanetaryFortress);
                SortConstructionStates(ref LTbReactor);
                SortConstructionStates(ref LTbRefinery);
                SortConstructionStates(ref LTbSensorTower);
                SortConstructionStates(ref LTbStarport);
                SortConstructionStates(ref LTbSupply);
                SortConstructionStates(ref LTbTechlab);
                SortConstructionStates(ref LTbTurrent);

                SortConstructionStates(ref LTuBanshee);
                SortConstructionStates(ref LTuBattlecruiser);
                SortConstructionStates(ref LTuGhost);
                SortConstructionStates(ref LTuHellbat);
                SortConstructionStates(ref LTuHellion);
                SortConstructionStates(ref LTuMarauder);
                SortConstructionStates(ref LTuMarine);
                SortConstructionStates(ref LTuMedivac);
                SortAliveSinceStates(ref LTuMule);
                SortConstructionStates(ref LTuNuke);
                SortConstructionStates(ref LTuPointDefenseDrone);
                SortConstructionStates(ref LTuRaven);
                SortConstructionStates(ref LTuReaper);
                SortConstructionStates(ref LTuScv);
                SortConstructionStates(ref LTuSiegetank);
                SortConstructionStates(ref LTuThor);
                SortConstructionStates(ref LTuViking);
                SortConstructionStates(ref LTuWidowMine);

                SortConstructionStates(ref LTupBehemothReactor);
                SortConstructionStates(ref LTupBlueFlame);
                SortConstructionStates(ref LTupCaduceusReactor);
                SortConstructionStates(ref LTupCloakingField);
                SortConstructionStates(ref LTupCombatShields);
                SortConstructionStates(ref LTupConcussiveShells);
                SortConstructionStates(ref LTupCorvidReactor);
                SortConstructionStates(ref LTupDrillingClaws);
                SortConstructionStates(ref LTupDurableMaterials);
                SortConstructionStates(ref LTupHighSecAutoTracking);
                SortConstructionStates(ref LTupInfantryArmor1);
                SortConstructionStates(ref LTupInfantryArmor2);
                SortConstructionStates(ref LTupInfantryArmor3);
                SortConstructionStates(ref LTupInfantryWeapon1);
                SortConstructionStates(ref LTupInfantryWeapon2);
                SortConstructionStates(ref LTupInfantryWeapon3);
                SortConstructionStates(ref LTupMoebiusReactor);
                SortConstructionStates(ref LTupNeosteelFrame);
                SortConstructionStates(ref LTupOrbitalCommand);
                SortConstructionStates(ref LTupPersonalCloak);
                SortConstructionStates(ref LTupPlanetaryFortress);
                SortConstructionStates(ref LTupShipWeapon1);
                SortConstructionStates(ref LTupShipWeapon2);
                SortConstructionStates(ref LTupShipWeapon3);
                SortConstructionStates(ref LTupStim);
                SortConstructionStates(ref LTupStructureArmor);
                SortConstructionStates(ref LTupTransformationServos);
                SortConstructionStates(ref LTupVehicleShipPlanting1);
                SortConstructionStates(ref LTupVehicleShipPlanting2);
                SortConstructionStates(ref LTupVehicleShipPlanting3);
                SortConstructionStates(ref LTupVehicleWeapon1);
                SortConstructionStates(ref LTupVehicleWeapon2);
                SortConstructionStates(ref LTupVehicleWeapon3);
                SortConstructionStates(ref LTupWeaponRefit);

                #endregion

                #region Protoss

                SortConstructionStates(ref LPbAssimilator);
                SortConstructionStates(ref LPbCannon);
                SortConstructionStates(ref LPbCybercore);
                SortConstructionStates(ref LPbDarkshrine);
                SortConstructionStates(ref LPbFleetbeacon);
                SortConstructionStates(ref LPbForge);
                SortConstructionStates(ref LPbGateway);
                SortConstructionStates(ref LPbNexus);
                SortConstructionStates(ref LPbPylon);
                SortConstructionStates(ref LPbRobotics);
                SortConstructionStates(ref LPbRoboticsSupport);
                SortConstructionStates(ref LPbStargate);
                SortConstructionStates(ref LPbTemplarArchives);
                SortConstructionStates(ref LPbTwilight);
                SortConstructionStates(ref LPbWarpgate);

                SortConstructionStates(ref LPuArchon);
                SortConstructionStates(ref LPuCarrier);
                SortConstructionStates(ref LPuColossus);
                SortConstructionStates(ref LPuDt);
                SortConstructionStates(ref LPuHt);
                SortConstructionStates(ref LPuImmortal);
                SortConstructionStates(ref LPuMothership);
                SortConstructionStates(ref LPuMothershipcore);
                SortConstructionStates(ref LPuObserver);
                SortConstructionStates(ref LPuOracle);
                SortConstructionStates(ref LPuPhoenix);
                SortConstructionStates(ref LPuProbe);
                SortConstructionStates(ref LPuSentry);
                SortConstructionStates(ref LPuStalker);
                SortConstructionStates(ref LPuTempest);
                SortConstructionStates(ref LPuVoidray);
                SortConstructionStates(ref LPuWarpprism);
                SortConstructionStates(ref LPuZealot);
                SortAliveSinceStates(ref LPuForcefield);

                SortConstructionStates(ref LPupAirArmor1);
                SortConstructionStates(ref LPupAirArmor2);
                SortConstructionStates(ref LPupAirArmor3);
                SortConstructionStates(ref LPupAirWeapon1);
                SortConstructionStates(ref LPupAirWeapon2);
                SortConstructionStates(ref LPupAirWeapon3);
                SortConstructionStates(ref LPupAnionPulseCrystal);
                SortConstructionStates(ref LPupBlink);
                SortConstructionStates(ref LPupCharge);
                SortConstructionStates(ref LPupExtendedThermalLance);
                SortConstructionStates(ref LPupGraviticBooster);
                SortConstructionStates(ref LPupGraviticDrive);
                SortConstructionStates(ref LPupGravitonCatapult);
                SortConstructionStates(ref LPupGroundArmor1);
                SortConstructionStates(ref LPupGroundArmor2);
                SortConstructionStates(ref LPupGroundArmor3);
                SortConstructionStates(ref LPupGroundWeapon1);
                SortConstructionStates(ref LPupGroundWeapon2);
                SortConstructionStates(ref LPupGroundWeapon3);
                SortConstructionStates(ref LPupShield1);
                SortConstructionStates(ref LPupShield2);
                SortConstructionStates(ref LPupShield3);
                SortConstructionStates(ref LPupStorm);
                SortConstructionStates(ref LPupWarpGate);

                #endregion

                #region Zerg

                SortConstructionStates(ref LZbBanelingnest);
                SortConstructionStates(ref LZbCreepTumor);
                SortConstructionStates(ref LZbEvochamber);
                SortConstructionStates(ref LZbExtractor);
                SortConstructionStates(ref LZbGreaterspire);
                SortConstructionStates(ref LZbHatchery);
                SortConstructionStates(ref LZbHive);
                SortConstructionStates(ref LZbHydraden);
                SortConstructionStates(ref LZbInfestationpit);
                SortConstructionStates(ref LZbLair);
                SortConstructionStates(ref LZbNydusbegin);
                SortConstructionStates(ref LZbNydusend);
                SortConstructionStates(ref LZbRoachwarren);
                SortConstructionStates(ref LZbSpawningpool);
                SortConstructionStates(ref LZbSpine);
                SortConstructionStates(ref LZbSpire);
                SortConstructionStates(ref LZbSpore);
                SortConstructionStates(ref LZbUltracavern);

                SortConstructionStates(ref LZuBaneling);
                SortConstructionStates(ref LZuBanelingCocoon);
                SortConstructionStates(ref LZuBroodlord);
                SortConstructionStates(ref LZuBroodlordCocoon);
                SortConstructionStates(ref LZuCorruptor);
                SortConstructionStates(ref LZuDrone);
                SortConstructionStates(ref LZuHydra);
                SortConstructionStates(ref LZuInfestor);
                SortConstructionStates(ref LZuInfestedTerranEgg);
                SortConstructionStates(ref LZuLarva);
                SortConstructionStates(ref LZuMutalisk);
                SortConstructionStates(ref LZuOverlord);
                SortConstructionStates(ref LZuOverseer);
                SortConstructionStates(ref LZuOverseerCocoon);
                SortConstructionStates(ref LZuQueen);
                SortConstructionStates(ref LZuRoach);
                SortConstructionStates(ref LZuSwarmhost);
                SortConstructionStates(ref LZuUltralisk);
                SortConstructionStates(ref LZuViper);
                SortConstructionStates(ref LZuZergling);
                SortAliveSinceStates(ref LZuBroodling);
                SortAliveSinceStates(ref LZuLocust);
                SortAliveSinceStates(ref LZuFlyingLocust);
                SortAliveSinceStates(ref LZuChangeling);
                SortAliveSinceStates(ref LZuInfestedTerran);
                

                SortConstructionStates(ref LZupAdrenalGlands);
                SortConstructionStates(ref LZupAirArmor1);
                SortConstructionStates(ref LZupAirArmor2);
                SortConstructionStates(ref LZupAirArmor3);
                SortConstructionStates(ref LZupAirWeapon1);
                SortConstructionStates(ref LZupAirWeapon2);
                SortConstructionStates(ref LZupAirWeapon3);
                SortConstructionStates(ref LZupBurrow);
                SortConstructionStates(ref LZupCentrifugalHooks);
                SortConstructionStates(ref LZupChitinousPlating);
                SortConstructionStates(ref LZupEnduringLocusts);
                SortConstructionStates(ref LZupGlialReconstruction);
                SortConstructionStates(ref LZupGroovedSpines);
                SortConstructionStates(ref LZupGroundArmor1);
                SortConstructionStates(ref LZupGroundArmor2);
                SortConstructionStates(ref LZupGroundArmor3);
                SortConstructionStates(ref LZupGroundMelee1);
                SortConstructionStates(ref LZupGroundMelee2);
                SortConstructionStates(ref LZupGroundMelee3);
                SortConstructionStates(ref LZupGroundWeapon1);
                SortConstructionStates(ref LZupGroundWeapon2);
                SortConstructionStates(ref LZupGroundWeapon3);
                SortConstructionStates(ref LZupMetabolicBoost);
                SortConstructionStates(ref LZupMuscularAugments);
                SortConstructionStates(ref LZupNeutralParasite);
                SortConstructionStates(ref LZupPathoglenGlands);
                SortConstructionStates(ref LZupPneumatizedCarapace);
                SortConstructionStates(ref LZupTunnnelingClaws);
                SortConstructionStates(ref LZupVentralSacs);

                #endregion

                #endregion

#if !DEBUG
            }
            catch (Exception ex)
            {
                Messages.LogFile("Over all", ex);
            }
#endif
        }

        protected virtual void OnShowCalled()
        {
            ShowCalled?.Invoke(this, new EventArgs());
        }

        protected virtual void OnHideCalled()
        {
            HideCalled?.Invoke(this, new EventArgs());
        }

        protected virtual void OnCloseCalled()
        {
            CloseCalled?.Invoke(this, new EventArgs());
        }

       
    }
}