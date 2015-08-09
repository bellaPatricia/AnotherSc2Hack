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
        private const int SizeOfRectangle = 10; //Size for the corner- rectangles (when changing position)

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
        protected Stopwatch _swMainWatch = new Stopwatch();

        #region UnitCounter - Count all objects per player

        #region Terran

        protected List<UnitCount> _lTbCommandCenter = new List<UnitCount>();
        protected List<UnitCount> _lTbPlanetaryFortress = new List<UnitCount>();
        protected List<UnitCount> _lTbOrbitalCommand = new List<UnitCount>();
        protected List<UnitCount> _lTbBarracks = new List<UnitCount>();
        protected List<UnitCount> _lTbSupply = new List<UnitCount>();
        protected List<UnitCount> _lTbEbay = new List<UnitCount>();
        protected List<UnitCount> _lTbRefinery = new List<UnitCount>();
        protected List<UnitCount> _lTbBunker = new List<UnitCount>();
        protected List<UnitCount> _lTbTurrent = new List<UnitCount>();
        protected List<UnitCount> _lTbSensorTower = new List<UnitCount>();
        protected List<UnitCount> _lTbFactory = new List<UnitCount>();
        protected List<UnitCount> _lTbStarport = new List<UnitCount>();
        protected List<UnitCount> _lTbArmory = new List<UnitCount>();
        protected List<UnitCount> _lTbGhostAcademy = new List<UnitCount>();
        protected List<UnitCount> _lTbFusionCore = new List<UnitCount>();
        protected List<UnitCount> _lTbTechlab = new List<UnitCount>();
        protected List<UnitCount> _lTbReactor = new List<UnitCount>();
        protected List<UnitCount> _lTbAutoTurret = new List<UnitCount>();


        protected List<UnitCount> _lTuScv = new List<UnitCount>();
        protected List<UnitCount> _lTuMule = new List<UnitCount>();
        protected List<UnitCount> _lTuMarine = new List<UnitCount>();
        protected List<UnitCount> _lTuMarauder = new List<UnitCount>();
        protected List<UnitCount> _lTuReaper = new List<UnitCount>();
        protected List<UnitCount> _lTuGhost = new List<UnitCount>();
        protected List<UnitCount> _lTuWidowMine = new List<UnitCount>();
        protected List<UnitCount> _lTuSiegetank = new List<UnitCount>();
        protected List<UnitCount> _lTuHellion = new List<UnitCount>();
        protected List<UnitCount> _lTuHellbat = new List<UnitCount>();
        protected List<UnitCount> _lTuThor = new List<UnitCount>();
        protected List<UnitCount> _lTuViking = new List<UnitCount>();
        protected List<UnitCount> _lTuBanshee = new List<UnitCount>();
        protected List<UnitCount> _lTuMedivac = new List<UnitCount>();
        protected List<UnitCount> _lTuBattlecruiser = new List<UnitCount>();
        protected List<UnitCount> _lTuRaven = new List<UnitCount>();
        protected List<UnitCount> _lTuPointDefenseDrone = new List<UnitCount>();
        protected List<UnitCount> _lTuNuke = new List<UnitCount>();


        protected List<UnitCount> _lTupInfantryWeapon1 = new List<UnitCount>();
        protected List<UnitCount> _lTupInfantryWeapon2 = new List<UnitCount>();
        protected List<UnitCount> _lTupInfantryWeapon3 = new List<UnitCount>();
        protected List<UnitCount> _lTupInfantryArmor1 = new List<UnitCount>();
        protected List<UnitCount> _lTupInfantryArmor2 = new List<UnitCount>();
        protected List<UnitCount> _lTupInfantryArmor3 = new List<UnitCount>();
        protected List<UnitCount> _lTupVehicleWeapon1 = new List<UnitCount>();
        protected List<UnitCount> _lTupVehicleWeapon2 = new List<UnitCount>();
        protected List<UnitCount> _lTupVehicleWeapon3 = new List<UnitCount>();
        protected List<UnitCount> _lTupShipWeapon1 = new List<UnitCount>();
        protected List<UnitCount> _lTupShipWeapon2 = new List<UnitCount>();
        protected List<UnitCount> _lTupShipWeapon3 = new List<UnitCount>();
        protected List<UnitCount> _lTupVehicleShipPlanting1 = new List<UnitCount>();
        protected List<UnitCount> _lTupVehicleShipPlanting2 = new List<UnitCount>();
        protected List<UnitCount> _lTupVehicleShipPlanting3 = new List<UnitCount>();
        protected List<UnitCount> _lTupNeosteelFrame = new List<UnitCount>();
        protected List<UnitCount> _lTupStructureArmor = new List<UnitCount>();
        protected List<UnitCount> _lTupHighSecAutoTracking = new List<UnitCount>();
        protected List<UnitCount> _lTupConcussiveShells = new List<UnitCount>();
        protected List<UnitCount> _lTupCombatShields = new List<UnitCount>();
        protected List<UnitCount> _lTupStim = new List<UnitCount>();
        protected List<UnitCount> _lTupBlueFlame = new List<UnitCount>();
        protected List<UnitCount> _lTupDrillingClaws = new List<UnitCount>();
        protected List<UnitCount> _lTupTransformationServos = new List<UnitCount>();
        protected List<UnitCount> _lTupCloakingField = new List<UnitCount>();
        protected List<UnitCount> _lTupCaduceusReactor = new List<UnitCount>();
        protected List<UnitCount> _lTupDurableMaterials = new List<UnitCount>();
        protected List<UnitCount> _lTupCorvidReactor = new List<UnitCount>();
        protected List<UnitCount> _lTupWeaponRefit = new List<UnitCount>();
        protected List<UnitCount> _lTupBehemothReactor = new List<UnitCount>();
        protected List<UnitCount> _lTupPersonalCloak = new List<UnitCount>();
        protected List<UnitCount> _lTupMoebiusReactor = new List<UnitCount>();
        protected List<UnitCount> _lTupPlanetaryFortress = new List<UnitCount>();
        protected List<UnitCount> _lTupOrbitalCommand = new List<UnitCount>();

        #endregion

        #region Protoss

        protected List<UnitCount> _lPbNexus = new List<UnitCount>();
        protected List<UnitCount> _lPbPylon = new List<UnitCount>();
        protected List<UnitCount> _lPbGateway = new List<UnitCount>();
        protected List<UnitCount> _lPbForge = new List<UnitCount>();
        protected List<UnitCount> _lPbCybercore = new List<UnitCount>();
        protected List<UnitCount> _lPbWarpgate = new List<UnitCount>();
        protected List<UnitCount> _lPbCannon = new List<UnitCount>();
        protected List<UnitCount> _lPbAssimilator = new List<UnitCount>();
        protected List<UnitCount> _lPbTwilight = new List<UnitCount>();
        protected List<UnitCount> _lPbStargate = new List<UnitCount>();
        protected List<UnitCount> _lPbRobotics = new List<UnitCount>();
        protected List<UnitCount> _lPbRoboticsSupport = new List<UnitCount>();
        protected List<UnitCount> _lPbFleetbeacon = new List<UnitCount>();
        protected List<UnitCount> _lPbTemplarArchives = new List<UnitCount>();
        protected List<UnitCount> _lPbDarkshrine = new List<UnitCount>();

        protected List<UnitCount> _lPuProbe = new List<UnitCount>();
        protected List<UnitCount> _lPuStalker = new List<UnitCount>();
        protected List<UnitCount> _lPuZealot = new List<UnitCount>();
        protected List<UnitCount> _lPuSentry = new List<UnitCount>();
        protected List<UnitCount> _lPuDt = new List<UnitCount>();
        protected List<UnitCount> _lPuHt = new List<UnitCount>();
        protected List<UnitCount> _lPuMothership = new List<UnitCount>();
        protected List<UnitCount> _lPuMothershipcore = new List<UnitCount>();
        protected List<UnitCount> _lPuArchon = new List<UnitCount>();
        protected List<UnitCount> _lPuWarpprism = new List<UnitCount>();
        protected List<UnitCount> _lPuObserver = new List<UnitCount>();
        protected List<UnitCount> _lPuColossus = new List<UnitCount>();
        protected List<UnitCount> _lPuImmortal = new List<UnitCount>();
        protected List<UnitCount> _lPuPhoenix = new List<UnitCount>();
        protected List<UnitCount> _lPuVoidray = new List<UnitCount>();
        protected List<UnitCount> _lPuOracle = new List<UnitCount>();
        protected List<UnitCount> _lPuTempest = new List<UnitCount>();
        protected List<UnitCount> _lPuCarrier = new List<UnitCount>();
        protected List<UnitCount> _lPuForcefield = new List<UnitCount>();

        protected List<UnitCount> _lPupGroundWeapon1 = new List<UnitCount>();
        protected List<UnitCount> _lPupGroundWeapon2 = new List<UnitCount>();
        protected List<UnitCount> _lPupGroundWeapon3 = new List<UnitCount>();
        protected List<UnitCount> _lPupGroundArmor1 = new List<UnitCount>();
        protected List<UnitCount> _lPupGroundArmor2 = new List<UnitCount>();
        protected List<UnitCount> _lPupGroundArmor3 = new List<UnitCount>();
        protected List<UnitCount> _lPupShield1 = new List<UnitCount>();
        protected List<UnitCount> _lPupShield2 = new List<UnitCount>();
        protected List<UnitCount> _lPupShield3 = new List<UnitCount>();
        protected List<UnitCount> _lPupAirWeapon1 = new List<UnitCount>();
        protected List<UnitCount> _lPupAirWeapon2 = new List<UnitCount>();
        protected List<UnitCount> _lPupAirWeapon3 = new List<UnitCount>();
        protected List<UnitCount> _lPupAirArmor1 = new List<UnitCount>();
        protected List<UnitCount> _lPupAirArmor2 = new List<UnitCount>();
        protected List<UnitCount> _lPupAirArmor3 = new List<UnitCount>();
        protected List<UnitCount> _lPupStorm = new List<UnitCount>();
        protected List<UnitCount> _lPupWarpGate = new List<UnitCount>();
        protected List<UnitCount> _lPupBlink = new List<UnitCount>();
        protected List<UnitCount> _lPupCharge = new List<UnitCount>();
        protected List<UnitCount> _lPupAnionPulseCrystal = new List<UnitCount>();
        protected List<UnitCount> _lPupGraviticBooster = new List<UnitCount>();
        protected List<UnitCount> _lPupGraviticDrive = new List<UnitCount>();
        protected List<UnitCount> _lPupGravitonCatapult = new List<UnitCount>();
        protected List<UnitCount> _lPupExtendedThermalLance = new List<UnitCount>();

        #endregion

        #region Zerg

        protected List<UnitCount> _lZbHatchery = new List<UnitCount>();
        protected List<UnitCount> _lZbLair = new List<UnitCount>();
        protected List<UnitCount> _lZbHive = new List<UnitCount>();
        protected List<UnitCount> _lZbSpawningpool = new List<UnitCount>();
        protected List<UnitCount> _lZbRoachwarren = new List<UnitCount>();
        protected List<UnitCount> _lZbCreepTumor = new List<UnitCount>();
        protected List<UnitCount> _lZbEvochamber = new List<UnitCount>();
        protected List<UnitCount> _lZbSpine = new List<UnitCount>();
        protected List<UnitCount> _lZbSpore = new List<UnitCount>();
        protected List<UnitCount> _lZbBanelingnest = new List<UnitCount>();
        protected List<UnitCount> _lZbExtractor = new List<UnitCount>();
        protected List<UnitCount> _lZbHydraden = new List<UnitCount>();
        protected List<UnitCount> _lZbSpire = new List<UnitCount>();
        protected List<UnitCount> _lZbNydusbegin = new List<UnitCount>();
        protected List<UnitCount> _lZbNydusend = new List<UnitCount>();
        protected List<UnitCount> _lZbUltracavern = new List<UnitCount>();
        protected List<UnitCount> _lZbGreaterspire = new List<UnitCount>();
        protected List<UnitCount> _lZbInfestationpit = new List<UnitCount>();

        protected List<UnitCount> _lZuLarva = new List<UnitCount>();
        protected List<UnitCount> _lZuDrone = new List<UnitCount>();
        protected List<UnitCount> _lZuOverlord = new List<UnitCount>();
        protected List<UnitCount> _lZuZergling = new List<UnitCount>();
        protected List<UnitCount> _lZuBaneling = new List<UnitCount>();
        protected List<UnitCount> _lZuBanelingCocoon = new List<UnitCount>();
        protected List<UnitCount> _lZuBroodlordCocoon = new List<UnitCount>();
        protected List<UnitCount> _lZuRoach = new List<UnitCount>();
        protected List<UnitCount> _lZuHydra = new List<UnitCount>();
        protected List<UnitCount> _lZuInfestor = new List<UnitCount>();
        protected List<UnitCount> _lZuInfestedTerran = new List<UnitCount>();
        protected List<UnitCount> _lZuInfestedTerranEgg = new List<UnitCount>();
        protected List<UnitCount> _lZuQueen = new List<UnitCount>();
        protected List<UnitCount> _lZuOverseer = new List<UnitCount>();
        protected List<UnitCount> _lZuOverseerCocoon = new List<UnitCount>();
        protected List<UnitCount> _lZuMutalisk = new List<UnitCount>();
        protected List<UnitCount> _lZuCorruptor = new List<UnitCount>();
        protected List<UnitCount> _lZuBroodlord = new List<UnitCount>();
        protected List<UnitCount> _lZuUltralisk = new List<UnitCount>();
        protected List<UnitCount> _lZuSwarmhost = new List<UnitCount>();
        protected List<UnitCount> _lZuViper = new List<UnitCount>();
        protected List<UnitCount> _lZuLocust = new List<UnitCount>();
        protected List<UnitCount> _lZuFlyingLocust = new List<UnitCount>();
        protected List<UnitCount> _lZuChangeling = new List<UnitCount>();


        protected List<UnitCount> _lZupAirWeapon1 = new List<UnitCount>();
        protected List<UnitCount> _lZupAirWeapon2 = new List<UnitCount>();
        protected List<UnitCount> _lZupAirWeapon3 = new List<UnitCount>();
        protected List<UnitCount> _lZupAirArmor1 = new List<UnitCount>();
        protected List<UnitCount> _lZupAirArmor2 = new List<UnitCount>();
        protected List<UnitCount> _lZupAirArmor3 = new List<UnitCount>();
        protected List<UnitCount> _lZupGroundWeapon1 = new List<UnitCount>();
        protected List<UnitCount> _lZupGroundWeapon2 = new List<UnitCount>();
        protected List<UnitCount> _lZupGroundWeapon3 = new List<UnitCount>();
        protected List<UnitCount> _lZupGroundArmor1 = new List<UnitCount>();
        protected List<UnitCount> _lZupGroundArmor2 = new List<UnitCount>();
        protected List<UnitCount> _lZupGroundArmor3 = new List<UnitCount>();
        protected List<UnitCount> _lZupGroundMelee1 = new List<UnitCount>();
        protected List<UnitCount> _lZupGroundMelee2 = new List<UnitCount>();
        protected List<UnitCount> _lZupGroundMelee3 = new List<UnitCount>();
        protected List<UnitCount> _lZupMetabolicBoost = new List<UnitCount>();
        protected List<UnitCount> _lZupAdrenalGlands = new List<UnitCount>();
        protected List<UnitCount> _lZupCentrifugalHooks = new List<UnitCount>();
        protected List<UnitCount> _lZupChitinousPlating = new List<UnitCount>();
        protected List<UnitCount> _lZupEnduringLocusts = new List<UnitCount>();
        protected List<UnitCount> _lZupGlialReconstruction = new List<UnitCount>();
        protected List<UnitCount> _lZupGroovedSpines = new List<UnitCount>();
        protected List<UnitCount> _lZupMuscularAugments = new List<UnitCount>();
        protected List<UnitCount> _lZupNeutralParasite = new List<UnitCount>();
        protected List<UnitCount> _lZupPathoglenGlands = new List<UnitCount>();
        protected List<UnitCount> _lZupPneumatizedCarapace = new List<UnitCount>();
        protected List<UnitCount> _lZupTunnnelingClaws = new List<UnitCount>();
        protected List<UnitCount> _lZupVentralSacs = new List<UnitCount>();
        protected List<UnitCount> _lZupBurrow = new List<UnitCount>();
        protected List<UnitCount> _lZupFlyingLocust = new List<UnitCount>();

        #endregion

        #region Images

        #region Terran

        #region Units

        protected Image _imgTuScv = Resources.tu_scv,
            _imgTuMule = Resources.tu_Mule,
            _imgTuMarine = Resources.tu_marine,
            _imgTuMarauder = Resources.tu_marauder,
            _imgTuReaper = Resources.tu_reaper,
            _imgTuGhost = Resources.tu_ghost,
            _imgTuHellion = Resources.tu_hellion,
            _imgTuHellbat = Resources.tu_battlehellion,
            _imgTuSiegetank = Resources.tu_tank,
            _imgTuThor = Resources.tu_thor,
            _imgTuWidowMine = Resources.tu_widowmine,
            _imgTuViking = Resources.tu_vikingAir,
            _imgTuRaven = Resources.tu_raven,
            _imgTuMedivac = Resources.tu_medivac,
            _imgTuBattlecruiser = Resources.tu_battlecruiser,
            _imgTuBanshee = Resources.tu_banshee,
            _imgTuPointDefenseDrone = Resources.tu_pdd,
            _imgTuNuke = Resources.Tu_Nuke;

        #endregion

        #region Buildings

        protected Image _imgTbCc = Resources.tb_cc,
            _imgTbOc = Resources.tb_oc,
            _imgTbPf = Resources.tb_pf,
            _imgTbSupply = Resources.tb_supply,
            _imgTbRefinery = Resources.tb_refinery,
            _imgTbBarracks = Resources.tb_rax,
            _imgTbEbay = Resources.tb_ebay,
            _imgTbTurrent = Resources.tb_turret,
            _imgTbSensorTower = Resources.tb_sensor,
            _imgTbFactory = Resources.tb_fax,
            _imgTbStarport = Resources.tb_starport,
            _imgTbGhostacademy = Resources.tb_ghostacademy,
            _imgTbArmory = Resources.tb_Armory,
            _imgTbBunker = Resources.tb_bunker,
            _imgTbFusioncore = Resources.tb_fusioncore,
            _imgTbTechlab = Resources.tb_techlab,
            _imgTbReactor = Resources.tb_reactor,
            _imgTbAutoTurret = Resources.tb_autoturret;

        #endregion

        #region Upgrades

        protected Image _imgTupStim = Resources.Tup_Stim,
            _imgTupConcussiveShells = Resources.Tup_ConcussiveShells,
            _imgTupCombatShields = Resources.Tup_CombatShields,
            _imgTupPersonalCloak = Resources.Tup_PersonalCloak,
            _imgTupMoebiusReactor = Resources.Tup_MoebiusReactor,
            _imgTupBlueFlame = Resources.Tup_BlueFlame,
            _imgTupTransformatorServos = Resources.Tup_TransformationServos,
            _imgTupDrillingClaws = Resources.Tup_DrillingClaws,
            _imgTupCloakingField = Resources.Tup_CloakingField,
            _imgTupDurableMaterials = Resources.Tup_DurableMaterials,
            _imgTupCaduceusReactor = Resources.Tup_CaduceusReactor,
            _imgTupCorvidReactor = Resources.Tup_CorvidReactor,
            _imgTupBehemothReacot = Resources.Tup_BehemothReactor,
            _imgTupWeaponRefit = Resources.Tup_WeaponRefit,
            _imgTupInfantryWeapon1 = Resources.Tup_InfantyWeapon1,
            _imgTupInfantryWeapon2 = Resources.Tup_InfantyWeapon2,
            _imgTupInfantryWeapon3 = Resources.Tup_InfantyWeapon3,
            _imgTupInfantryArmor1 = Resources.Tup_InfantyArmor1,
            _imgTupInfantryArmor2 = Resources.Tup_InfantyArmor2,
            _imgTupInfantryArmor3 = Resources.Tup_InfantyArmor3,
            _imgTupVehicleWeapon1 = Resources.Tup_VehicleWeapon1,
            _imgTupVehicleWeapon2 = Resources.Tup_VehicleWeapon2,
            _imgTupVehicleWeapon3 = Resources.Tup_VehicleWeapon3,
            _imgTupShipWeapon1 = Resources.Tup_ShipWeapon1,
            _imgTupShipWeapon2 = Resources.Tup_ShipWeapon2,
            _imgTupShipWeapon3 = Resources.Tup_ShipWeapon3,
            _imgTupVehicleShipPlanting1 = Resources.Tup_VehicleShipPlanting1,
            _imgTupVehicleShipPlanting2 = Resources.Tup_VehicleShipPlanting2,
            _imgTupVehicleShipPlanting3 = Resources.Tup_VehicleShipPlanting3,
            _imgTupHighSecAutoTracking = Resources.Tup_HighSecAutotracking,
            _imgTupStructureArmor = Resources.Tup_StructureArmor,
            _imgTupNeosteelFrame = Resources.Tup_NeosteelFrame;

        #endregion

        #endregion

        #region Protoss

        #region Units

        protected Image _imgPuProbe = Resources.pu_probe,
            _imgPuZealot = Resources.pu_Zealot,
            _imgPuStalker = Resources.pu_Stalker,
            _imgPuSentry = Resources.pu_sentry,
            _imgPuDarkTemplar = Resources.pu_DarkTemplar,
            _imgPuHighTemplar = Resources.pu_ht,
            _imgPuColossus = Resources.pu_Colossus,
            _imgPuImmortal = Resources.pu_immortal,
            _imgPuWapprism = Resources.pu_warpprism,
            _imgPuObserver = Resources.pu_Observer,
            _imgPuOracle = Resources.pu_oracle,
            _imgPuTempest = Resources.pu_tempest,
            _imgPuPhoenix = Resources.pu_pheonix,
            _imgPuVoidray = Resources.pu_Voidray,
            _imgPuCarrier = Resources.pu_carrier,
            _imgPuMothershipcore = Resources.pu_mothershipcore,
            _imgPuMothership = Resources.pu_Mothership,
            _imgPuArchon = Resources.pu_Archon,
            _imgPuForceField = Resources.PuForceField;

        #endregion

        #region Buildings

        protected Image _imgPbNexus = Resources.pb_Nexus,
            _imgPbPylon = Resources.pb_Pylon,
            _imgPbGateway = Resources.pb_gateway,
            _imgPbWarpgate = Resources.pb_warpgate,
            _imgPbAssimilator = Resources.pb_Assimilator,
            _imgPbForge = Resources.pb_forge,
            _imgPbCannon = Resources.pb_Cannon,
            _imgPbCybercore = Resources.pb_cybercore,
            _imgPbStargate = Resources.pb_stargate,
            _imgPbRobotics = Resources.pb_robotics,
            _imgPbRoboticsSupport = Resources.pb_roboticssupport,
            _imgPbTwillightCouncil = Resources.pb_twillightCouncil,
            _imgPbDarkShrine = Resources.pb_DarkShrine,
            _imgPbTemplarArchives = Resources.pb_templararchives,
            _imgPbFleetBeacon = Resources.pb_FleetBeacon;

        #endregion

        #region Upgrades

        protected Image _imgPupGroundWeapon1 = Resources.Pup_GroundW1,
            _imgPupGroundWeapon2 = Resources.Pup_GroundW2,
            _imgPupGroundWeapon3 = Resources.Pup_GroundW3,
            _imgPupGroundArmor1 = Resources.Pup_GroundA1,
            _imgPupGroundArmor2 = Resources.Pup_GroundA2,
            _imgPupGroundArmor3 = Resources.Pup_GroundA3,
            _imgPupShield1 = Resources.Pup_S1,
            _imgPupShield2 = Resources.Pup_S2,
            _imgPupShield3 = Resources.Pup_S3,
            _imgPupAirWeapon1 = Resources.Pup_AirW1,
            _imgPupAirWeapon2 = Resources.Pup_AirW2,
            _imgPupAirWeapon3 = Resources.Pup_AirW3,
            _imgPupAirArmor1 = Resources.Pup_AirA1,
            _imgPupAirArmor2 = Resources.Pup_AirA2,
            _imgPupAirArmor3 = Resources.Pup_AirA3,
            _imgPupBlink = Resources.Pup_Blink,
            _imgPupCharge = Resources.Pup_Charge,
            _imgPupGraviticBooster = Resources.Pup_GraviticBoosters,
            _imgPupGraviticDrive = Resources.Pup_GraviticDrive,
            _imgPupExtendedThermalLance = Resources.Pup_ExtendedThermalLance,
            _imgPupAnionPulseCrystals = Resources.Pup_AnionPulseCrystals,
            _imgPupGravitonCatapult = Resources.Pup_GravitonCatapult,
            _imgPupWarpGate = Resources.Pup_Warpgate,
            _imgPupStorm = Resources.Pup_Storm;

        #endregion

        #endregion

        #region Zerg

        #region Units

        protected Image _imgZuDrone = Resources.zu_drone,
            _imgZuLarva = Resources.zu_larva,
            _imgZuZergling = Resources.zu_zergling,
            _imgZuBaneling = Resources.zu_baneling,
            _imgZuBanelingCocoon = Resources.zu_banelingcocoon,
            _imgZuRoach = Resources.zu_roach,
            _imgZuHydra = Resources.zu_hydra,
            _imgZuMutalisk = Resources.zu_mutalisk,
            _imgZuUltra = Resources.zu_ultra,
            _imgZuViper = Resources.zu_viper,
            _imgZuSwarmhost = Resources.zu_swarmhost,
            _imgZuInfestor = Resources.zu_infestor,
            _imgInfestedTerran = Resources.zu_infestedterran,
            _imgInfestedTerranEgg = Resources.zu_infestedterran,
            _imgZuCorruptor = Resources.zu_corruptor,
            _imgZuChangeling = Resources.zu_changeling,
            _imgZuBroodlord = Resources.zu_broodlord,
            _imgZuBroodlordCocoon = Resources.zu_broodlordcocoon,
            _imgZuQueen = Resources.zu_queen,
            _imgZuOverlord = Resources.zu_overlord,
            _imgZuOverseer = Resources.zu_overseer,
            _imgZuOvserseerCocoon = Resources.zu_overseercocoon,
            _imgZuLocust = Resources.zu_locust,
            _imgZuFlyingLocust = Resources.zup_flying_locust;

        #endregion

        #region Buildings

        protected Image _imgZbHatchery = Resources.zb_hatchery,
            _imgZbLair = Resources.zb_lair,
            _imgZbHive = Resources.zb_hive,
            _imgZbCreepTumor = Resources.Zb_Creep_Tumor,
            _imgZbSpawningpool = Resources.zb_spawningpool,
            _imgZbExtractor = Resources.zb_extactor,
            _imgZbEvochamber = Resources.zb_evochamber,
            _imgZbSpinecrawler = Resources.zb_spine,
            _imgZbSporecrawler = Resources.zb_spore,
            _imgZbRoachwarren = Resources.zb_roachwarren,
            _imgZbGreaterspire = Resources.zb_greaterspire,
            _imgZbSpire = Resources.zb_spire,
            _imgZbNydusNetwork = Resources.zb_nydusnetwork,
            _imgZbNydusWorm = Resources.zb_nydusworm,
            _imgZbHydraden = Resources.zb_hydraden,
            _imgZbInfestationpit = Resources.zb_infestationpit,
            _imgZbUltracavern = Resources.zb_ultracavery,
            _imgZbBanelingnest = Resources.zb_banelingnest;

        #endregion

        #region Upgrades

        protected Image _imgZupAirWeapon1 = Resources.Zup_AirW1,
            _imgZupAirWeapon2 = Resources.Zup_AirW2,
            _imgZupAirWeapon3 = Resources.Zup_AirW3,
            _imgZupAirArmor1 = Resources.Zup_AirA1,
            _imgZupAirArmor2 = Resources.Zup_AirA2,
            _imgZupAirArmor3 = Resources.Zup_AirA3,
            _imgZupGroundWeapon1 = Resources.Zup_GroundW1,
            _imgZupGroundWeapon2 = Resources.Zup_GroundW2,
            _imgZupGroundWeapon3 = Resources.Zup_GroundW3,
            _imgZupGroundArmor1 = Resources.Zup_GroundA1,
            _imgZupGroundArmor2 = Resources.Zup_GroundA2,
            _imgZupGroundArmor3 = Resources.Zup_GroundA3,
            _imgZupGroundMelee1 = Resources.Zup_GroundM1,
            _imgZupGroundMelee2 = Resources.Zup_GroundM2,
            _imgZupGroundMelee3 = Resources.Zup_GroundM3,
            _imgZupBurrow = Resources.Zup_Burrow,
            _imgZupAdrenalGlands = Resources.Zup_AdrenalGlands,
            _imgZupCentrifugalHooks = Resources.Zup_CentrifugalHooks,
            _imgZupChitinousPlating = Resources.Zup_ChitinousPlating,
            _imgZupEnduringLocusts = Resources.Zup_EnduringLocusts,
            _imgZupGlialReconstruction = Resources.Zup_GlialReconstruction,
            _imgZupGroovedSpines = Resources.Zup_GroovedSpines,
            _imgZupMetabolicBoost = Resources.Zup_MetabolicBoost,
            _imgZupMuscularAugments = Resources.Zup_MuscularAugments,
            _imgZupNeutralParasite = Resources.Zup_NeutralParasite,
            _imgZupPathoglenGlands = Resources.Zup_PathogenGlands,
            _imgZupPneumatizedCarapace = Resources.Zup_PneumatizedCarapace,
            _imgZupTunnelingClaws = Resources.Zup_TunnelingClaws,
            _imgZupVentrallSacs = Resources.Zup_VentralSacs,
            _imgZupFlyingLocust = Resources.zup_flying_locust;

        #endregion

        #endregion

        #region Other

        protected readonly Image _imgSpeedArrow = Resources.Speed_Arrow;

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

        #endregion

        #region Private Methods

        /// <summary>
        ///     Event manager to send the event to the caller
        /// </summary>
        /// <param name="sender">This object</param>
        /// <param name="e">Event Args</param>
        private void OnIsHiddenChanged(object sender, EventArgs e)
        {
            if (IsHiddenChanged != null)
                IsHiddenChanged(sender, e);
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
            if (IterationPerSecondChanged != null)
                IterationPerSecondChanged(sender, e);
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
            InteropCalls.SetForegroundWindow(PSc2Process.MainWindowHandle);

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
            for (var h = hWnd; h != IntPtr.Zero; h = InteropCalls.GetWindow(h, InteropCalls.GetWindowCmd.GwHwndprev))
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
                InteropCalls.GetForegroundWindow().Equals(PSc2Process.MainWindowHandle))
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

            // Simple border 
            buffer.Graphics.DrawRectangle(Constants.PYellowGreen2,
                1,
                1,
                Width - 2,
                Height - 2);

            // Draw some filled frectangles to make the resizing easier 
            buffer.Graphics.FillRectangle(Brushes.YellowGreen,
                Width - SizeOfRectangle, 0, SizeOfRectangle,
                SizeOfRectangle);

            buffer.Graphics.FillRectangle(Brushes.YellowGreen,
                0, Height - SizeOfRectangle, SizeOfRectangle,
                SizeOfRectangle);

            buffer.Graphics.FillRectangle(Brushes.YellowGreen,
                Width - SizeOfRectangle, Height - SizeOfRectangle,
                SizeOfRectangle, SizeOfRectangle);

            // Draw current size 
            buffer.Graphics.DrawString(
                Width.ToString(CultureInfo.InvariantCulture) + "x" +
                Height.ToString(CultureInfo.InvariantCulture) + " - [X=" +
                Location.X.ToString(CultureInfo.InvariantCulture) + "; Y=" +
                Location.Y.ToString(CultureInfo.InvariantCulture) + "]",
                new Font("Arial", 8, FontStyle.Regular), Brushes.YellowGreen, 2, 2);
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
                        if (PSc2Process == null)
                            _bDraw = false;

                        else
                            _bDraw = InteropCalls.GetForegroundWindow().Equals(PSc2Process.MainWindowHandle);
                    }

                    else
                    {
                        _bDraw = true;

                        if (PSc2Process == null)
                        {
                            _bDraw = false;
                            PSc2Process = GInformation.CStarcraft2;
                        }

                        else if (InteropCalls.GetForegroundWindow().Equals(PSc2Process.MainWindowHandle))
                        {
                            InteropCalls.SetActiveWindow(Handle);
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
            if (!useTransparentImages)
            {
                #region Terran

                _imgTuScv = Resources.tu_scv;
                _imgTuMule = Resources.tu_Mule;
                _imgTuMarine = Resources.tu_marine;
                _imgTuMarauder = Resources.tu_marauder;
                _imgTuReaper = Resources.tu_reaper;
                _imgTuGhost = Resources.tu_ghost;
                _imgTuHellion = Resources.tu_hellion;
                _imgTuHellbat = Resources.tu_battlehellion;
                _imgTuSiegetank = Resources.tu_tank;
                _imgTuThor = Resources.tu_thor;
                _imgTuWidowMine = Resources.tu_widowmine;
                _imgTuViking = Resources.tu_vikingAir;
                _imgTuRaven = Resources.tu_raven;
                _imgTuMedivac = Resources.tu_medivac;
                _imgTuBattlecruiser = Resources.tu_battlecruiser;
                _imgTuBanshee = Resources.tu_banshee;
                _imgTuPointDefenseDrone = Resources.tu_pdd;
                _imgTuNuke = Resources.Tu_Nuke;

                _imgTbCc = Resources.tb_cc;
                _imgTbOc = Resources.tb_oc;
                _imgTbPf = Resources.tb_pf;
                _imgTbSupply = Resources.tb_supply;
                _imgTbRefinery = Resources.tb_refinery;
                _imgTbBarracks = Resources.tb_rax;
                _imgTbEbay = Resources.tb_ebay;
                _imgTbTurrent = Resources.tb_turret;
                _imgTbSensorTower = Resources.tb_sensor;
                _imgTbFactory = Resources.tb_fax;
                _imgTbStarport = Resources.tb_starport;
                _imgTbGhostacademy = Resources.tb_ghostacademy;
                _imgTbArmory = Resources.tb_Armory;
                _imgTbBunker = Resources.tb_bunker;
                _imgTbFusioncore = Resources.tb_fusioncore;
                _imgTbTechlab = Resources.tb_techlab;
                _imgTbReactor = Resources.tb_reactor;
                _imgTbAutoTurret = Resources.tb_autoturret;

                _imgTupStim = Resources.Tup_Stim;
                _imgTupConcussiveShells = Resources.Tup_ConcussiveShells;
                _imgTupCombatShields = Resources.Tup_CombatShields;
                _imgTupPersonalCloak = Resources.Tup_PersonalCloak;
                _imgTupMoebiusReactor = Resources.Tup_MoebiusReactor;
                _imgTupBlueFlame = Resources.Tup_BlueFlame;
                _imgTupTransformatorServos = Resources.Tup_TransformationServos;
                _imgTupDrillingClaws = Resources.Tup_DrillingClaws;
                _imgTupCloakingField = Resources.Tup_CloakingField;
                _imgTupDurableMaterials = Resources.Tup_DurableMaterials;
                _imgTupCaduceusReactor = Resources.Tup_CaduceusReactor;
                _imgTupCorvidReactor = Resources.Tup_CorvidReactor;
                _imgTupBehemothReacot = Resources.Tup_BehemothReactor;
                _imgTupWeaponRefit = Resources.Tup_WeaponRefit;
                _imgTupInfantryWeapon1 = Resources.Tup_InfantyWeapon1;
                _imgTupInfantryWeapon2 = Resources.Tup_InfantyWeapon2;
                _imgTupInfantryWeapon3 = Resources.Tup_InfantyWeapon3;
                _imgTupInfantryArmor1 = Resources.Tup_InfantyArmor1;
                _imgTupInfantryArmor2 = Resources.Tup_InfantyArmor2;
                _imgTupInfantryArmor3 = Resources.Tup_InfantyArmor3;
                _imgTupVehicleWeapon1 = Resources.Tup_VehicleWeapon1;
                _imgTupVehicleWeapon2 = Resources.Tup_VehicleWeapon2;
                _imgTupVehicleWeapon3 = Resources.Tup_VehicleWeapon3;
                _imgTupShipWeapon1 = Resources.Tup_ShipWeapon1;
                _imgTupShipWeapon2 = Resources.Tup_ShipWeapon2;
                _imgTupShipWeapon3 = Resources.Tup_ShipWeapon3;
                _imgTupVehicleShipPlanting1 = Resources.Tup_VehicleShipPlanting1;
                _imgTupVehicleShipPlanting2 = Resources.Tup_VehicleShipPlanting2;
                _imgTupVehicleShipPlanting3 = Resources.Tup_VehicleShipPlanting3;
                _imgTupHighSecAutoTracking = Resources.Tup_HighSecAutotracking;
                _imgTupStructureArmor = Resources.Tup_StructureArmor;
                _imgTupNeosteelFrame = Resources.Tup_NeosteelFrame;

                #endregion

                #region Protoss

                _imgPuProbe = Resources.pu_probe;
                _imgPuZealot = Resources.pu_Zealot;
                _imgPuStalker = Resources.pu_Stalker;
                _imgPuSentry = Resources.pu_sentry;
                _imgPuDarkTemplar = Resources.pu_DarkTemplar;
                _imgPuHighTemplar = Resources.pu_ht;
                _imgPuColossus = Resources.pu_Colossus;
                _imgPuImmortal = Resources.pu_immortal;
                _imgPuWapprism = Resources.pu_warpprism;
                _imgPuObserver = Resources.pu_Observer;
                _imgPuOracle = Resources.pu_oracle;
                _imgPuTempest = Resources.pu_tempest;
                _imgPuPhoenix = Resources.pu_pheonix;
                _imgPuVoidray = Resources.pu_Voidray;
                _imgPuCarrier = Resources.pu_carrier;
                _imgPuMothershipcore = Resources.pu_mothershipcore;
                _imgPuMothership = Resources.pu_Mothership;
                _imgPuArchon = Resources.pu_Archon;
                _imgPuForceField = Resources.PuForceField;

                _imgPbNexus = Resources.pb_Nexus;
                _imgPbPylon = Resources.pb_Pylon;
                _imgPbGateway = Resources.pb_gateway;
                _imgPbWarpgate = Resources.pb_warpgate;
                _imgPbAssimilator = Resources.pb_Assimilator;
                _imgPbForge = Resources.pb_forge;
                _imgPbCannon = Resources.pb_Cannon;
                _imgPbCybercore = Resources.pb_cybercore;
                _imgPbStargate = Resources.pb_stargate;
                _imgPbRobotics = Resources.pb_robotics;
                _imgPbRoboticsSupport = Resources.pb_roboticssupport;
                _imgPbTwillightCouncil = Resources.pb_twillightCouncil;
                _imgPbDarkShrine = Resources.pb_DarkShrine;
                _imgPbTemplarArchives = Resources.pb_templararchives;
                _imgPbFleetBeacon = Resources.pb_FleetBeacon;

                _imgPupGroundWeapon1 = Resources.Pup_GroundW1;
                _imgPupGroundWeapon2 = Resources.Pup_GroundW2;
                _imgPupGroundWeapon3 = Resources.Pup_GroundW3;
                _imgPupGroundArmor1 = Resources.Pup_GroundA1;
                _imgPupGroundArmor2 = Resources.Pup_GroundA2;
                _imgPupGroundArmor3 = Resources.Pup_GroundA3;
                _imgPupShield1 = Resources.Pup_S1;
                _imgPupShield2 = Resources.Pup_S2;
                _imgPupShield3 = Resources.Pup_S3;
                _imgPupAirWeapon1 = Resources.Pup_AirW1;
                _imgPupAirWeapon2 = Resources.Pup_AirW2;
                _imgPupAirWeapon3 = Resources.Pup_AirW3;
                _imgPupAirArmor1 = Resources.Pup_AirA1;
                _imgPupAirArmor2 = Resources.Pup_AirA2;
                _imgPupAirArmor3 = Resources.Pup_AirA3;
                _imgPupBlink = Resources.Pup_Blink;
                _imgPupCharge = Resources.Pup_Charge;
                _imgPupGraviticBooster = Resources.Pup_GraviticBoosters;
                _imgPupGraviticDrive = Resources.Pup_GraviticDrive;
                _imgPupExtendedThermalLance = Resources.Pup_ExtendedThermalLance;
                _imgPupAnionPulseCrystals = Resources.Pup_AnionPulseCrystals;
                _imgPupGravitonCatapult = Resources.Pup_GravitonCatapult;
                _imgPupWarpGate = Resources.Pup_Warpgate;
                _imgPupStorm = Resources.Pup_Storm;

                #endregion

                #region Zerg

                _imgZuDrone = Resources.zu_drone;
                _imgZuLarva = Resources.zu_larva;
                _imgZuZergling = Resources.zu_zergling;
                _imgZuBaneling = Resources.zu_baneling;
                _imgZuBanelingCocoon = Resources.zu_banelingcocoon;
                _imgZuRoach = Resources.zu_roach;
                _imgZuHydra = Resources.zu_hydra;
                _imgZuMutalisk = Resources.zu_mutalisk;
                _imgZuUltra = Resources.zu_ultra;
                _imgZuViper = Resources.zu_viper;
                _imgZuSwarmhost = Resources.zu_swarmhost;
                _imgZuInfestor = Resources.zu_infestor;
                _imgInfestedTerran = Resources.zu_infestedterran;
                _imgInfestedTerranEgg = Resources.zu_infestedterran;
                _imgZuCorruptor = Resources.zu_corruptor;
                _imgZuBroodlord = Resources.zu_broodlord;
                _imgZuBroodlordCocoon = Resources.zu_broodlordcocoon;
                _imgZuQueen = Resources.zu_queen;
                _imgZuOverlord = Resources.zu_overlord;
                _imgZuOverseer = Resources.zu_overseer;
                _imgZuOvserseerCocoon = Resources.zu_overseercocoon;
                _imgZuLocust = Resources.zu_locust;
                _imgZuFlyingLocust = Resources.zup_flying_locust;
                _imgZuChangeling = Resources.zu_changeling;

                _imgZbHatchery = Resources.zb_hatchery;
                _imgZbLair = Resources.zb_lair;
                _imgZbHive = Resources.zb_hive;
                _imgZbCreepTumor = Resources.Zb_Creep_Tumor;
                _imgZbSpawningpool = Resources.zb_spawningpool;
                _imgZbExtractor = Resources.zb_extactor;
                _imgZbEvochamber = Resources.zb_evochamber;
                _imgZbSpinecrawler = Resources.zb_spine;
                _imgZbSporecrawler = Resources.zb_spore;
                _imgZbRoachwarren = Resources.zb_roachwarren;
                _imgZbGreaterspire = Resources.zb_greaterspire;
                _imgZbSpire = Resources.zb_spire;
                _imgZbNydusNetwork = Resources.zb_nydusnetwork;
                _imgZbNydusWorm = Resources.zb_nydusworm;
                _imgZbHydraden = Resources.zb_hydraden;
                _imgZbInfestationpit = Resources.zb_infestationpit;
                _imgZbUltracavern = Resources.zb_ultracavery;
                _imgZbBanelingnest = Resources.zb_banelingnest;

                _imgZupAirWeapon1 = Resources.Zup_AirW1;
                _imgZupAirWeapon2 = Resources.Zup_AirW2;
                _imgZupAirWeapon3 = Resources.Zup_AirW3;
                _imgZupAirArmor1 = Resources.Zup_AirA1;
                _imgZupAirArmor2 = Resources.Zup_AirA2;
                _imgZupAirArmor3 = Resources.Zup_AirA3;
                _imgZupGroundWeapon1 = Resources.Zup_GroundW1;
                _imgZupGroundWeapon2 = Resources.Zup_GroundW2;
                _imgZupGroundWeapon3 = Resources.Zup_GroundW3;
                _imgZupGroundArmor1 = Resources.Zup_GroundA1;
                _imgZupGroundArmor2 = Resources.Zup_GroundA2;
                _imgZupGroundArmor3 = Resources.Zup_GroundA3;
                _imgZupGroundMelee1 = Resources.Zup_GroundM1;
                _imgZupGroundMelee2 = Resources.Zup_GroundM2;
                _imgZupGroundMelee3 = Resources.Zup_GroundM3;
                _imgZupBurrow = Resources.Zup_Burrow;
                _imgZupAdrenalGlands = Resources.Zup_AdrenalGlands;
                _imgZupCentrifugalHooks = Resources.Zup_CentrifugalHooks;
                _imgZupChitinousPlating = Resources.Zup_ChitinousPlating;
                _imgZupEnduringLocusts = Resources.Zup_EnduringLocusts;
                _imgZupGlialReconstruction = Resources.Zup_GlialReconstruction;
                _imgZupGroovedSpines = Resources.Zup_GroovedSpines;
                _imgZupMetabolicBoost = Resources.Zup_MetabolicBoost;
                _imgZupMuscularAugments = Resources.Zup_MuscularAugments;
                _imgZupNeutralParasite = Resources.Zup_NeutralParasite;
                _imgZupPathoglenGlands = Resources.Zup_PathogenGlands;
                _imgZupPneumatizedCarapace = Resources.Zup_PneumatizedCarapace;
                _imgZupTunnelingClaws = Resources.Zup_TunnelingClaws;
                _imgZupVentrallSacs = Resources.Zup_VentralSacs;
                _imgZupFlyingLocust = Resources.zup_flying_locust;

                #endregion
            }

            else
            {
                #region Terran

                _imgTuScv = Resources.trans_tu_scv;
                _imgTuMule = Resources.trans_tu_mule;
                _imgTuMarine = Resources.trans_tu_marine;
                _imgTuMarauder = Resources.trans_tu_marauder;
                _imgTuReaper = Resources.trans_tu_reaper;
                _imgTuGhost = Resources.trans_tu_ghost;
                _imgTuHellion = Resources.trans_tu_hellion;
                _imgTuHellbat = Resources.trans_tu_hellbat;
                _imgTuSiegetank = Resources.trans_tu_siegetank;
                _imgTuThor = Resources.trans_tu_thor;
                _imgTuWidowMine = Resources.trans_tu_widowmine;
                _imgTuViking = Resources.trans_tu_vikingair;
                _imgTuRaven = Resources.trans_tu_raven;
                _imgTuMedivac = Resources.trans_tu_medivac;
                _imgTuBattlecruiser = Resources.trans_tu_battlecruiser;
                _imgTuBanshee = Resources.trans_tu_banshee;
                _imgTuPointDefenseDrone = Resources.trans_tu_pdd;
                _imgTuNuke = Resources.trans_tu_nuke;

                _imgTbCc = Resources.trans_tb_commandcenter;
                _imgTbOc = Resources.trans_tb_orbitalcommand;
                _imgTbPf = Resources.trans_tb_planetaryfortress;
                _imgTbSupply = Resources.trans_tb_supplydepot;
                _imgTbRefinery = Resources.trans_tb_refinery;
                _imgTbBarracks = Resources.trans_tb_barracks;
                _imgTbEbay = Resources.trans_tb_engineeringbay;
                _imgTbTurrent = Resources.trans_tb_missileturret;
                _imgTbSensorTower = Resources.trans_tb_sensortower;
                _imgTbFactory = Resources.trans_tb_factory;
                _imgTbStarport = Resources.trans_tb_starport;
                _imgTbGhostacademy = Resources.trans_tb_ghostacademy;
                _imgTbArmory = Resources.trans_tb_armory;
                _imgTbBunker = Resources.trans_tb_bunker;
                _imgTbFusioncore = Resources.trans_tb_fusioncore;
                _imgTbTechlab = Resources.trans_tb_techlab;
                _imgTbReactor = Resources.trans_tb_reactor;
                _imgTbAutoTurret = Resources.trans_tb_autoturret;

                _imgTupStim = Resources.trans_Tup_Stim;
                _imgTupConcussiveShells = Resources.trans_Tup_ConcussiveShells;
                _imgTupCombatShields = Resources.trans_Tup_CombatShields;
                _imgTupPersonalCloak = Resources.trans_Tup_PersonalCloak;
                _imgTupMoebiusReactor = Resources.trans_Tup_MoebiusReactor;
                _imgTupBlueFlame = Resources.trans_Tup_BlueFlame;
                _imgTupTransformatorServos = Resources.trans_Tup_TransformationServos;
                _imgTupDrillingClaws = Resources.trans_Tup_DrillingClaws;
                _imgTupCloakingField = Resources.trans_Tup_CloakingField;
                _imgTupDurableMaterials = Resources.trans_Tup_DurableMaterials;
                _imgTupCaduceusReactor = Resources.trans_Tup_CaduceusReactor;
                _imgTupCorvidReactor = Resources.trans_Tup_CorvidReactor;
                _imgTupBehemothReacot = Resources.trans_BehemothReactor;
                _imgTupWeaponRefit = Resources.trans_Tup_WeaponRefit;
                _imgTupInfantryWeapon1 = Resources.trans_Tup_InfantyWeapon1;
                _imgTupInfantryWeapon2 = Resources.trans_Tup_InfantyWeapon2;
                _imgTupInfantryWeapon3 = Resources.trans_Tup_InfantyWeapon3;
                _imgTupInfantryArmor1 = Resources.trans_Tup_InfantyArmor1;
                _imgTupInfantryArmor2 = Resources.trans_Tup_InfantyArmor2;
                _imgTupInfantryArmor3 = Resources.trans_Tup_InfantyArmor3;
                _imgTupVehicleWeapon1 = Resources.trans_Tup_VehicleWeapon1;
                _imgTupVehicleWeapon2 = Resources.trans_Tup_VehicleWeapon2;
                _imgTupVehicleWeapon3 = Resources.trans_Tup_VehicleWeapon3;
                _imgTupShipWeapon1 = Resources.trans_Tup_ShipWeapon1;
                _imgTupShipWeapon2 = Resources.trans_Tup_ShipWeapon2;
                _imgTupShipWeapon3 = Resources.trans_Tup_ShipWeapon3;
                _imgTupVehicleShipPlanting1 = Resources.trans_Tup_VehicleShipPlanting1;
                _imgTupVehicleShipPlanting2 = Resources.trans_Tup_VehicleShipPlanting2;
                _imgTupVehicleShipPlanting3 = Resources.trans_Tup_VehicleShipPlanting3;
                _imgTupHighSecAutoTracking = Resources.trans_Tup_HighSecAutotracking;
                _imgTupStructureArmor = Resources.trans_Tup_StructureArmor;
                _imgTupNeosteelFrame = Resources.trans_Tup_NeosteelFrame;

                #endregion

                #region Protoss

                _imgPuProbe = Resources.trans_pu_probe;
                _imgPuZealot = Resources.trans_pu_zealot;
                _imgPuStalker = Resources.trans_pu_stalker;
                _imgPuSentry = Resources.trans_pu_sentry;
                _imgPuDarkTemplar = Resources.trans_pu_darktemplar;
                _imgPuHighTemplar = Resources.trans_pu_hightemplar;
                _imgPuColossus = Resources.trans_pu_colossus;
                _imgPuImmortal = Resources.trans_pu_immortal;
                _imgPuWapprism = Resources.trans_pu_warpprism;
                _imgPuObserver = Resources.trans_pu_observer;
                _imgPuOracle = Resources.trans_pu_oracle;
                _imgPuTempest = Resources.trans_pu_tempest;
                _imgPuPhoenix = Resources.trans_pu_phoenix;
                _imgPuVoidray = Resources.trans_pu_voidray;
                _imgPuCarrier = Resources.trans_pu_carrier;
                _imgPuMothershipcore = Resources.trans_pu_mothershipcore;
                _imgPuMothership = Resources.trans_pu_mothership;
                _imgPuArchon = Resources.trans_pu_archon;
                _imgPuForceField = Resources.PuForceField;

                _imgPbNexus = Resources.trans_pb_nexus;
                _imgPbPylon = Resources.trans_pb_pylon;
                _imgPbGateway = Resources.trans_pb_gateway;
                _imgPbWarpgate = Resources.trans_pb_warpgate;
                _imgPbAssimilator = Resources.trans_pb_assimilator;
                _imgPbForge = Resources.trans_pb_forge;
                _imgPbCannon = Resources.trans_pb_photoncannon;
                _imgPbCybercore = Resources.trans_pb_cyberneticscore;
                _imgPbStargate = Resources.trans_pb_stargate;
                _imgPbRobotics = Resources.trans_pb_roboticsfacility;
                _imgPbRoboticsSupport = Resources.trans_pb_roboticsbay;
                _imgPbTwillightCouncil = Resources.trans_pb_twilightcouncil;
                _imgPbDarkShrine = Resources.trans_pb_darkshrine;
                _imgPbTemplarArchives = Resources.trans_pb_templararchive;
                _imgPbFleetBeacon = Resources.trans_pb_fleetbeacon;

                _imgPupGroundWeapon1 = Resources.trans_Pup_GroundW1;
                _imgPupGroundWeapon2 = Resources.trans_Pup_GroundW2;
                _imgPupGroundWeapon3 = Resources.trans_Pup_GroundW3;
                _imgPupGroundArmor1 = Resources.trans_Pup_GroundA1;
                _imgPupGroundArmor2 = Resources.trans_Pup_GroundA2;
                _imgPupGroundArmor3 = Resources.trans_Pup_GroundA3;
                _imgPupShield1 = Resources.trans_Pup_S1;
                _imgPupShield2 = Resources.trans_Pup_S2;
                _imgPupShield3 = Resources.trans_Pup_S3;
                _imgPupAirWeapon1 = Resources.trans_Pup_AirW1;
                _imgPupAirWeapon2 = Resources.trans_Pup_AirW2;
                _imgPupAirWeapon3 = Resources.trans_Pup_AirW3;
                _imgPupAirArmor1 = Resources.trans_Pup_AirA1;
                _imgPupAirArmor2 = Resources.trans_Pup_AirA2;
                _imgPupAirArmor3 = Resources.trans_Pup_AirA3;
                _imgPupBlink = Resources.trans_Pup_Blink;
                _imgPupCharge = Resources.trans_Pup_Charge;
                _imgPupGraviticBooster = Resources.trans_Pup_GraviticBoosters;
                _imgPupGraviticDrive = Resources.trans_Pup_GraviticDrive;
                _imgPupExtendedThermalLance = Resources.trans_Pup_ExtendedThermalLance;
                _imgPupAnionPulseCrystals = Resources.trans_Pup_AnionPulseCrystals;
                _imgPupGravitonCatapult = Resources.trans_Pup_GravitonCatapult;
                _imgPupWarpGate = Resources.trans_Pup_Warpgate;
                _imgPupStorm = Resources.trans_Pup_Storm;

                #endregion

                #region Zerg

                _imgZuDrone = Resources.trans_zu_drone;
                _imgZuLarva = Resources.trans_zu_larva;
                _imgZuZergling = Resources.trans_zu_zergling;
                _imgZuBaneling = Resources.trans_zu_baneling;
                _imgZuBanelingCocoon = Resources.trans_zu_banelingcocoon;
                _imgZuRoach = Resources.trans_zu_roach;
                _imgZuHydra = Resources.trans_zu_hydralisk;
                _imgZuMutalisk = Resources.trans_zu_mutalisk;
                _imgZuUltra = Resources.trans_zu_ultralisk;
                _imgZuViper = Resources.trans_zu_viper;
                _imgZuSwarmhost = Resources.trans_zu_swarmhost;
                _imgZuInfestor = Resources.trans_zu_infestor;
                _imgInfestedTerran = Resources.trans_zu_InfestedTerran;
                _imgInfestedTerranEgg = Resources.trans_zu_InfestedTerran;
                _imgZuCorruptor = Resources.trans_zu_corruptor;
                _imgZuBroodlord = Resources.trans_zu_broodlord;
                _imgZuBroodlordCocoon = Resources.trans_zu_BroodLordCocoon;
                _imgZuQueen = Resources.trans_zu_queen;
                _imgZuOverlord = Resources.trans_zu_overlord;
                _imgZuOverseer = Resources.trans_zu_overseer;
                _imgZuOvserseerCocoon = Resources.trans_zu_OverlordCocoon;
                _imgZuLocust = Resources.trans_zu_locust;
                _imgZuFlyingLocust = Resources.trans_Zup_flying_locust;
                _imgZuChangeling = Resources.trans_zu_changeling; 

                _imgZbHatchery = Resources.trans_zb_hatchery;
                _imgZbLair = Resources.trans_zb_lair;
                _imgZbHive = Resources.trans_zb_hive;
                _imgZbCreepTumor = Resources.trans_zb_creeptumor;
                _imgZbSpawningpool = Resources.trans_zb_spawningpool;
                _imgZbExtractor = Resources.trans_zb_extractor;
                _imgZbEvochamber = Resources.trans_zb_evolutionchamber;
                _imgZbSpinecrawler = Resources.trans_zb_spinecrawler;
                _imgZbSporecrawler = Resources.trans_zb_sporecrawler;
                _imgZbRoachwarren = Resources.trans_zb_roachwarren;
                _imgZbGreaterspire = Resources.trans_zb_greaterspire;
                _imgZbSpire = Resources.trans_zb_spire;
                _imgZbNydusNetwork = Resources.trans_zb_nydusnetwork;
                _imgZbNydusWorm = Resources.trans_zb_nyduscanal;
                _imgZbHydraden = Resources.trans_zb_hydraliskden;
                _imgZbInfestationpit = Resources.trans_zb_infestationpit;
                _imgZbUltracavern = Resources.trans_zb_ultraliskcavern;
                _imgZbBanelingnest = Resources.trans_zb_banelingnest;

                _imgZupAirWeapon1 = Resources.trans_Zup_AirW1;
                _imgZupAirWeapon2 = Resources.trans_Zup_AirW2;
                _imgZupAirWeapon3 = Resources.trans_Zup_AirW3;
                _imgZupAirArmor1 = Resources.trans_Zup_AirA1;
                _imgZupAirArmor2 = Resources.trans_Zup_AirA2;
                _imgZupAirArmor3 = Resources.trans_Zup_AirA3;
                _imgZupGroundWeapon1 = Resources.trans_Zup_GroundW1;
                _imgZupGroundWeapon2 = Resources.trans_Zup_GroundW2;
                _imgZupGroundWeapon3 = Resources.trans_Zup_GroundW3;
                _imgZupGroundArmor1 = Resources.trans_Zup_GroundA1;
                _imgZupGroundArmor2 = Resources.trans_Zup_GroundA2;
                _imgZupGroundArmor3 = Resources.trans_Zup_GroundA3;
                _imgZupGroundMelee1 = Resources.trans_Zup_GroundM1;
                _imgZupGroundMelee2 = Resources.trans_Zup_GroundM2;
                _imgZupGroundMelee3 = Resources.trans_Zup_GroundM3;
                _imgZupBurrow = Resources.trans_Zup_Burrow;
                _imgZupAdrenalGlands = Resources.trans_Zup_AdrenalGlands;
                _imgZupCentrifugalHooks = Resources.trans_Zup_CentrifugalHooks;
                _imgZupChitinousPlating = Resources.trans_Zup_ChitinousPlating;
                _imgZupEnduringLocusts = Resources.trans_Zup_EnduringLocusts;
                _imgZupGlialReconstruction = Resources.trans_Zup_GlialReconstruction;
                _imgZupGroovedSpines = Resources.trans_Zup_GroovedSpines;
                _imgZupMetabolicBoost = Resources.trans_Zup_MetabolicBoost;
                _imgZupMuscularAugments = Resources.trans_Zup_MuscularAugments;
                _imgZupNeutralParasite = Resources.trans_Zup_NeutralParasite;
                _imgZupPathoglenGlands = Resources.trans_Zup_PathogenGlands;
                _imgZupPneumatizedCarapace = Resources.trans_Zup_PneumatizedCarapace;
                _imgZupTunnelingClaws = Resources.trans_Zup_TunnelingClaws;
                _imgZupVentrallSacs = Resources.trans_Zup_VentralSacs;
                _imgZupFlyingLocust = Resources.trans_Zup_flying_locust;

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

                if (_lTbCommandCenter.Count > 0)
                    _lTbCommandCenter.Clear();

                if (_lTbOrbitalCommand.Count > 0)
                    _lTbOrbitalCommand.Clear();

                if (_lTbPlanetaryFortress.Count > 0)
                    _lTbPlanetaryFortress.Clear();

                if (_lTbBarracks.Count > 0)
                    _lTbBarracks.Clear();

                if (_lTbSupply.Count > 0)
                    _lTbSupply.Clear();

                if (_lTbRefinery.Count > 0)
                    _lTbRefinery.Clear();

                if (_lTbBunker.Count > 0)
                    _lTbBunker.Clear();

                if (_lTbTurrent.Count > 0)
                    _lTbTurrent.Clear();

                if (_lTbSensorTower.Count > 0)
                    _lTbSensorTower.Clear();

                if (_lTbEbay.Count > 0)
                    _lTbEbay.Clear();

                if (_lTbStarport.Count > 0)
                    _lTbStarport.Clear();

                if (_lTbFactory.Count > 0)
                    _lTbFactory.Clear();

                if (_lTbArmory.Count > 0)
                    _lTbArmory.Clear();

                if (_lTbFusionCore.Count > 0)
                    _lTbFusionCore.Clear();

                if (_lTbGhostAcademy.Count > 0)
                    _lTbGhostAcademy.Clear();

                if (_lTbReactor.Count > 0)
                    _lTbReactor.Clear();

                if (_lTbTechlab.Count > 0)
                    _lTbTechlab.Clear();

                if (_lTbAutoTurret.Count > 0)
                    _lTbAutoTurret.Clear();


                if (_lTuScv.Count > 0)
                    _lTuScv.Clear();

                if (_lTuMule.Count > 0)
                    _lTuMule.Clear();

                if (_lTuMarine.Count > 0)
                    _lTuMarine.Clear();

                if (_lTuMarauder.Count > 0)
                    _lTuMarauder.Clear();

                if (_lTuReaper.Count > 0)
                    _lTuReaper.Clear();

                if (_lTuGhost.Count > 0)
                    _lTuGhost.Clear();

                if (_lTuWidowMine.Count > 0)
                    _lTuWidowMine.Clear();

                if (_lTuSiegetank.Count > 0)
                    _lTuSiegetank.Clear();

                if (_lTuHellbat.Count > 0)
                    _lTuHellbat.Clear();

                if (_lTuHellion.Count > 0)
                    _lTuHellion.Clear();

                if (_lTuThor.Count > 0)
                    _lTuThor.Clear();

                if (_lTuBanshee.Count > 0)
                    _lTuBanshee.Clear();

                if (_lTuBattlecruiser.Count > 0)
                    _lTuBattlecruiser.Clear();

                if (_lTuViking.Count > 0)
                    _lTuViking.Clear();

                if (_lTuRaven.Count > 0)
                    _lTuRaven.Clear();

                if (_lTuMedivac.Count > 0)
                    _lTuMedivac.Clear();

                if (_lTuPointDefenseDrone.Count > 0)
                    _lTuPointDefenseDrone.Clear();

                if (_lTuNuke.Count > 0)
                    _lTuNuke.Clear();


                if (_lTupStim.Count > 0)
                    _lTupStim.Clear();

                if (_lTupBehemothReactor.Count > 0)
                    _lTupBehemothReactor.Clear();

                if (_lTupBlueFlame.Count > 0)
                    _lTupBlueFlame.Clear();

                if (_lTupCaduceusReactor.Count > 0)
                    _lTupCaduceusReactor.Clear();

                if (_lTupCloakingField.Count > 0)
                    _lTupCloakingField.Clear();

                if (_lTupCombatShields.Count > 0)
                    _lTupCombatShields.Clear();

                if (_lTupConcussiveShells.Count > 0)
                    _lTupConcussiveShells.Clear();

                if (_lTupCorvidReactor.Count > 0)
                    _lTupCorvidReactor.Clear();

                if (_lTupDrillingClaws.Count > 0)
                    _lTupDrillingClaws.Clear();

                if (_lTupDurableMaterials.Count > 0)
                    _lTupDurableMaterials.Clear();

                if (_lTupHighSecAutoTracking.Count > 0)
                    _lTupHighSecAutoTracking.Clear();

                if (_lTupInfantryArmor1.Count > 0)
                    _lTupInfantryArmor1.Clear();

                if (_lTupInfantryArmor2.Count > 0)
                    _lTupInfantryArmor2.Clear();

                if (_lTupInfantryArmor3.Count > 0)
                    _lTupInfantryArmor3.Clear();

                if (_lTupInfantryWeapon1.Count > 0)
                    _lTupInfantryWeapon1.Clear();

                if (_lTupInfantryWeapon2.Count > 0)
                    _lTupInfantryWeapon2.Clear();

                if (_lTupInfantryWeapon3.Count > 0)
                    _lTupInfantryWeapon3.Clear();

                if (_lTupMoebiusReactor.Count > 0)
                    _lTupMoebiusReactor.Clear();

                if (_lTupNeosteelFrame.Count > 0)
                    _lTupNeosteelFrame.Clear();

                if (_lTupOrbitalCommand.Count > 0)
                    _lTupOrbitalCommand.Clear();

                if (_lTupPersonalCloak.Count > 0)
                    _lTupPersonalCloak.Clear();

                if (_lTupPlanetaryFortress.Count > 0)
                    _lTupPlanetaryFortress.Clear();

                if (_lTupShipWeapon1.Count > 0)
                    _lTupShipWeapon1.Clear();

                if (_lTupShipWeapon2.Count > 0)
                    _lTupShipWeapon2.Clear();

                if (_lTupShipWeapon3.Count > 0)
                    _lTupShipWeapon3.Clear();

                if (_lTupStructureArmor.Count > 0)
                    _lTupStructureArmor.Clear();

                if (_lTupTransformationServos.Count > 0)
                    _lTupTransformationServos.Clear();

                if (_lTupVehicleShipPlanting1.Count > 0)
                    _lTupVehicleShipPlanting1.Clear();

                if (_lTupVehicleShipPlanting2.Count > 0)
                    _lTupVehicleShipPlanting2.Clear();

                if (_lTupVehicleShipPlanting3.Count > 0)
                    _lTupVehicleShipPlanting3.Clear();

                if (_lTupVehicleWeapon1.Count > 0)
                    _lTupVehicleWeapon1.Clear();

                if (_lTupVehicleWeapon2.Count > 0)
                    _lTupVehicleWeapon2.Clear();

                if (_lTupVehicleWeapon3.Count > 0)
                    _lTupVehicleWeapon3.Clear();

                if (_lTupWeaponRefit.Count > 0)
                    _lTupWeaponRefit.Clear();

                #endregion

                #region Protoss

                if (_lPbAssimilator.Count > 0)
                    _lPbAssimilator.Clear();

                if (_lPbNexus.Count > 0)
                    _lPbNexus.Clear();

                if (_lPbPylon.Count > 0)
                    _lPbPylon.Clear();

                if (_lPbGateway.Count > 0)
                    _lPbGateway.Clear();

                if (_lPbWarpgate.Count > 0)
                    _lPbWarpgate.Clear();

                if (_lPbForge.Count > 0)
                    _lPbForge.Clear();

                if (_lPbCannon.Count > 0)
                    _lPbCannon.Clear();

                if (_lPbTwilight.Count > 0)
                    _lPbTwilight.Clear();

                if (_lPbTemplarArchives.Count > 0)
                    _lPbTemplarArchives.Clear();

                if (_lPbDarkshrine.Count > 0)
                    _lPbDarkshrine.Clear();

                if (_lPbRobotics.Count > 0)
                    _lPbRobotics.Clear();

                if (_lPbRoboticsSupport.Count > 0)
                    _lPbRoboticsSupport.Clear();

                if (_lPbFleetbeacon.Count > 0)
                    _lPbFleetbeacon.Clear();

                if (_lPbCybercore.Count > 0)
                    _lPbCybercore.Clear();

                if (_lPbStargate.Count > 0)
                    _lPbStargate.Clear();


                if (_lPuArchon.Count > 0)
                    _lPuArchon.Clear();

                if (_lPuCarrier.Count > 0)
                    _lPuCarrier.Clear();

                if (_lPuColossus.Count > 0)
                    _lPuColossus.Clear();

                if (_lPuDt.Count > 0)
                    _lPuDt.Clear();

                if (_lPuHt.Count > 0)
                    _lPuHt.Clear();

                if (_lPuForcefield.Count > 0)
                    _lPuForcefield.Clear();

                if (_lPuImmortal.Count > 0)
                    _lPuImmortal.Clear();

                if (_lPuMothership.Count > 0)
                    _lPuMothership.Clear();

                if (_lPuMothershipcore.Count > 0)
                    _lPuMothershipcore.Clear();

                if (_lPuObserver.Count > 0)
                    _lPuObserver.Clear();

                if (_lPuOracle.Count > 0)
                    _lPuOracle.Clear();

                if (_lPuPhoenix.Count > 0)
                    _lPuPhoenix.Clear();

                if (_lPuProbe.Count > 0)
                    _lPuProbe.Clear();

                if (_lPuSentry.Count > 0)
                    _lPuSentry.Clear();

                if (_lPuStalker.Count > 0)
                    _lPuStalker.Clear();

                if (_lPuTempest.Count > 0)
                    _lPuTempest.Clear();

                if (_lPuVoidray.Count > 0)
                    _lPuVoidray.Clear();

                if (_lPuWarpprism.Count > 0)
                    _lPuWarpprism.Clear();

                if (_lPuZealot.Count > 0)
                    _lPuZealot.Clear();


                if (_lPupAirArmor1.Count > 0)
                    _lPupAirArmor1.Clear();

                if (_lPupAirArmor2.Count > 0)
                    _lPupAirArmor2.Clear();

                if (_lPupAirArmor3.Count > 0)
                    _lPupAirArmor3.Clear();

                if (_lPupAirWeapon1.Count > 0)
                    _lPupAirWeapon1.Clear();

                if (_lPupAirWeapon2.Count > 0)
                    _lPupAirWeapon2.Clear();

                if (_lPupAirWeapon3.Count > 0)
                    _lPupAirWeapon3.Clear();

                if (_lPupAnionPulseCrystal.Count > 0)
                    _lPupAnionPulseCrystal.Clear();

                if (_lPupBlink.Count > 0)
                    _lPupBlink.Clear();

                if (_lPupCharge.Count > 0)
                    _lPupCharge.Clear();

                if (_lPupExtendedThermalLance.Count > 0)
                    _lPupExtendedThermalLance.Clear();

                if (_lPupGraviticBooster.Count > 0)
                    _lPupGraviticBooster.Clear();

                if (_lPupGraviticDrive.Count > 0)
                    _lPupGraviticDrive.Clear();

                if (_lPupGravitonCatapult.Count > 0)
                    _lPupGravitonCatapult.Clear();

                if (_lPupGroundArmor1.Count > 0)
                    _lPupGroundArmor1.Clear();

                if (_lPupGroundArmor2.Count > 0)
                    _lPupGroundArmor2.Clear();

                if (_lPupGroundArmor3.Count > 0)
                    _lPupGroundArmor3.Clear();

                if (_lPupGroundWeapon1.Count > 0)
                    _lPupGroundWeapon1.Clear();

                if (_lPupGroundWeapon2.Count > 0)
                    _lPupGroundWeapon2.Clear();

                if (_lPupGroundWeapon3.Count > 0)
                    _lPupGroundWeapon3.Clear();

                if (_lPupShield1.Count > 0)
                    _lPupShield1.Clear();

                if (_lPupShield2.Count > 0)
                    _lPupShield2.Clear();

                if (_lPupShield3.Count > 0)
                    _lPupShield3.Clear();

                if (_lPupStorm.Count > 0)
                    _lPupStorm.Clear();

                if (_lPupWarpGate.Count > 0)
                    _lPupWarpGate.Clear();

                #endregion

                #region Zerg

                if (_lZbBanelingnest.Count > 0)
                    _lZbBanelingnest.Clear();

                if (_lZbEvochamber.Count > 0)
                    _lZbEvochamber.Clear();

                if (_lZbExtractor.Count > 0)
                    _lZbExtractor.Clear();

                if (_lZbGreaterspire.Count > 0)
                    _lZbGreaterspire.Clear();

                if (_lZbHatchery.Count > 0)
                    _lZbHatchery.Clear();

                if (_lZbHive.Count > 0)
                    _lZbHive.Clear();

                if (_lZbHydraden.Count > 0)
                    _lZbHydraden.Clear();

                if (_lZbInfestationpit.Count > 0)
                    _lZbInfestationpit.Clear();

                if (_lZbLair.Count > 0)
                    _lZbLair.Clear();

                if (_lZbNydusbegin.Count > 0)
                    _lZbNydusbegin.Clear();

                if (_lZbNydusend.Count > 0)
                    _lZbNydusend.Clear();

                if (_lZbRoachwarren.Count > 0)
                    _lZbRoachwarren.Clear();

                if (_lZbSpawningpool.Count > 0)
                    _lZbSpawningpool.Clear();

                if (_lZbSpine.Count > 0)
                    _lZbSpine.Clear();

                if (_lZbSpire.Count > 0)
                    _lZbSpire.Clear();

                if (_lZbSpore.Count > 0)
                    _lZbSpore.Clear();

                if (_lZbUltracavern.Count > 0)
                    _lZbUltracavern.Clear();

                if (_lZbCreepTumor.Count > 0)
                    _lZbCreepTumor.Clear();


                if (_lZuBaneling.Count > 0)
                    _lZuBaneling.Clear();

                if (_lZuBroodlord.Count > 0)
                    _lZuBroodlord.Clear();

                if (_lZuCorruptor.Count > 0)
                    _lZuCorruptor.Clear();

                if (_lZuDrone.Count > 0)
                    _lZuDrone.Clear();

                if (_lZuHydra.Count > 0)
                    _lZuHydra.Clear();

                if (_lZuBanelingCocoon.Count > 0)
                    _lZuBanelingCocoon.Clear();

                if (_lZuBroodlordCocoon.Count > 0)
                    _lZuBroodlordCocoon.Clear();

                if (_lZuInfestor.Count > 0)
                    _lZuInfestor.Clear();

                if (_lZuInfestedTerran.Count > 0)
                    _lZuInfestedTerran.Clear();

                if (_lZuInfestedTerranEgg.Count > 0)
                    _lZuInfestedTerranEgg.Clear();

                if (_lZuLarva.Count > 0)
                    _lZuLarva.Clear();

                if (_lZuMutalisk.Count > 0)
                    _lZuMutalisk.Clear();

                if (_lZuOverlord.Count > 0)
                    _lZuOverlord.Clear();

                if (_lZuOverseer.Count > 0)
                    _lZuOverseer.Clear();

                if (_lZuQueen.Count > 0)
                    _lZuQueen.Clear();

                if (_lZuRoach.Count > 0)
                    _lZuRoach.Clear();

                if (_lZuSwarmhost.Count > 0)
                    _lZuSwarmhost.Clear();

                if (_lZuUltralisk.Count > 0)
                    _lZuUltralisk.Clear();

                if (_lZuViper.Count > 0)
                    _lZuViper.Clear();

                if (_lZuLocust.Count > 0)
                    _lZuLocust.Clear();

                if (_lZuFlyingLocust.Count > 0)
                    _lZuFlyingLocust.Clear();

                if (_lZuZergling.Count > 0)
                    _lZuZergling.Clear();

                if (_lZuOverseerCocoon.Count > 0)
                    _lZuOverseerCocoon.Clear();

                if (_lZuChangeling.Count > 0)
                    _lZuChangeling.Clear();
                

                if (_lZupAdrenalGlands.Count > 0)
                    _lZupAdrenalGlands.Clear();

                if (_lZupAirArmor1.Count > 0)
                    _lZupAirArmor1.Clear();

                if (_lZupAirArmor2.Count > 0)
                    _lZupAirArmor2.Clear();

                if (_lZupAirArmor3.Count > 0)
                    _lZupAirArmor3.Clear();

                if (_lZupAirWeapon1.Count > 0)
                    _lZupAirWeapon1.Clear();

                if (_lZupAirWeapon2.Count > 0)
                    _lZupAirWeapon2.Clear();

                if (_lZupAirWeapon3.Count > 0)
                    _lZupAirWeapon3.Clear();

                if (_lZupBurrow.Count > 0)
                    _lZupBurrow.Clear();

                if (_lZupCentrifugalHooks.Count > 0)
                    _lZupCentrifugalHooks.Clear();

                if (_lZupChitinousPlating.Count > 0)
                    _lZupChitinousPlating.Clear();

                if (_lZupEnduringLocusts.Count > 0)
                    _lZupEnduringLocusts.Clear();

                if (_lZupGlialReconstruction.Count > 0)
                    _lZupGlialReconstruction.Clear();

                if (_lZupGroovedSpines.Count > 0)
                    _lZupGroovedSpines.Clear();

                if (_lZupGroundArmor1.Count > 0)
                    _lZupGroundArmor1.Clear();

                if (_lZupGroundArmor2.Count > 0)
                    _lZupGroundArmor2.Clear();

                if (_lZupGroundArmor3.Count > 0)
                    _lZupGroundArmor3.Clear();

                if (_lZupGroundWeapon1.Count > 0)
                    _lZupGroundWeapon1.Clear();

                if (_lZupGroundWeapon2.Count > 0)
                    _lZupGroundWeapon2.Clear();

                if (_lZupGroundWeapon3.Count > 0)
                    _lZupGroundWeapon3.Clear();

                if (_lZupGroundMelee1.Count > 0)
                    _lZupGroundMelee1.Clear();

                if (_lZupGroundMelee2.Count > 0)
                    _lZupGroundMelee2.Clear();

                if (_lZupGroundMelee3.Count > 0)
                    _lZupGroundMelee3.Clear();

                if (_lZupMetabolicBoost.Count > 0)
                    _lZupMetabolicBoost.Clear();

                if (_lZupMuscularAugments.Count > 0)
                    _lZupMuscularAugments.Clear();

                if (_lZupNeutralParasite.Count > 0)
                    _lZupNeutralParasite.Clear();

                if (_lZupPathoglenGlands.Count > 0)
                    _lZupPathoglenGlands.Clear();

                if (_lZupPneumatizedCarapace.Count > 0)
                    _lZupPneumatizedCarapace.Clear();

                if (_lZupTunnnelingClaws.Count > 0)
                    _lZupTunnnelingClaws.Clear();

                if (_lZupVentralSacs.Count > 0)
                    _lZupVentralSacs.Clear();

                if (_lZupFlyingLocust.Count > 0)
                    _lZupFlyingLocust.Clear();

                #endregion

                #endregion

                #region Setup for the dummy- values

                for (var i = 0; i < GInformation.Player.Count; i++)
                {
                    #region Terran

                    #region Units

                    _lTuScv.Add(new UnitCount());
                    _lTuBanshee.Add(new UnitCount());
                    _lTuBattlecruiser.Add(new UnitCount());
                    _lTuGhost.Add(new UnitCount());
                    _lTuHellbat.Add(new UnitCount());
                    _lTuHellion.Add(new UnitCount());
                    _lTuMarauder.Add(new UnitCount());
                    _lTuMarine.Add(new UnitCount());
                    _lTuMedivac.Add(new UnitCount());
                    _lTuMule.Add(new UnitCount());
                    _lTuNuke.Add(new UnitCount());
                    _lTuPointDefenseDrone.Add(new UnitCount());
                    _lTuRaven.Add(new UnitCount());
                    _lTuReaper.Add(new UnitCount());
                    _lTuSiegetank.Add(new UnitCount());
                    _lTuThor.Add(new UnitCount());
                    _lTuViking.Add(new UnitCount());
                    _lTuWidowMine.Add(new UnitCount());

                    #endregion

                    #region Buildings

                    _lTbArmory.Add(new UnitCount());
                    _lTbAutoTurret.Add(new UnitCount());
                    _lTbBarracks.Add(new UnitCount());
                    _lTbBunker.Add(new UnitCount());
                    _lTbCommandCenter.Add(new UnitCount());
                    _lTbEbay.Add(new UnitCount());
                    _lTbFactory.Add(new UnitCount());
                    _lTbFusionCore.Add(new UnitCount());
                    _lTbGhostAcademy.Add(new UnitCount());
                    _lTbOrbitalCommand.Add(new UnitCount());
                    _lTbPlanetaryFortress.Add(new UnitCount());
                    _lTbReactor.Add(new UnitCount());
                    _lTbRefinery.Add(new UnitCount());
                    _lTbSensorTower.Add(new UnitCount());
                    _lTbStarport.Add(new UnitCount());
                    _lTbSupply.Add(new UnitCount());
                    _lTbTechlab.Add(new UnitCount());
                    _lTbTurrent.Add(new UnitCount());

                    #endregion

                    #region Upgrades

                    _lTupBehemothReactor.Add(new UnitCount());
                    _lTupBlueFlame.Add(new UnitCount());
                    _lTupCaduceusReactor.Add(new UnitCount());
                    _lTupCloakingField.Add(new UnitCount());
                    _lTupCombatShields.Add(new UnitCount());
                    _lTupConcussiveShells.Add(new UnitCount());
                    _lTupCorvidReactor.Add(new UnitCount());
                    _lTupDrillingClaws.Add(new UnitCount());
                    _lTupDurableMaterials.Add(new UnitCount());
                    _lTupHighSecAutoTracking.Add(new UnitCount());
                    _lTupInfantryArmor1.Add(new UnitCount());
                    _lTupInfantryArmor2.Add(new UnitCount());
                    _lTupInfantryArmor3.Add(new UnitCount());
                    _lTupInfantryWeapon1.Add(new UnitCount());
                    _lTupInfantryWeapon2.Add(new UnitCount());
                    _lTupInfantryWeapon3.Add(new UnitCount());
                    _lTupMoebiusReactor.Add(new UnitCount());
                    _lTupNeosteelFrame.Add(new UnitCount());
                    _lTupOrbitalCommand.Add(new UnitCount());
                    _lTupPersonalCloak.Add(new UnitCount());
                    _lTupPlanetaryFortress.Add(new UnitCount());
                    _lTupShipWeapon1.Add(new UnitCount());
                    _lTupShipWeapon2.Add(new UnitCount());
                    _lTupShipWeapon3.Add(new UnitCount());
                    _lTupStim.Add(new UnitCount());
                    _lTupStructureArmor.Add(new UnitCount());
                    _lTupTransformationServos.Add(new UnitCount());
                    _lTupVehicleShipPlanting1.Add(new UnitCount());
                    _lTupVehicleShipPlanting2.Add(new UnitCount());
                    _lTupVehicleShipPlanting3.Add(new UnitCount());
                    _lTupVehicleWeapon1.Add(new UnitCount());
                    _lTupVehicleWeapon2.Add(new UnitCount());
                    _lTupVehicleWeapon3.Add(new UnitCount());
                    _lTupWeaponRefit.Add(new UnitCount());

                    #endregion

                    #endregion

                    #region Protoss

                    #region Units

                    _lPuArchon.Add(new UnitCount());
                    _lPuCarrier.Add(new UnitCount());
                    _lPuColossus.Add(new UnitCount());
                    _lPuDt.Add(new UnitCount());
                    _lPuHt.Add(new UnitCount());
                    _lPuImmortal.Add(new UnitCount());
                    _lPuMothership.Add(new UnitCount());
                    _lPuMothershipcore.Add(new UnitCount());
                    _lPuObserver.Add(new UnitCount());
                    _lPuOracle.Add(new UnitCount());
                    _lPuPhoenix.Add(new UnitCount());
                    _lPuProbe.Add(new UnitCount());
                    _lPuSentry.Add(new UnitCount());
                    _lPuStalker.Add(new UnitCount());
                    _lPuTempest.Add(new UnitCount());
                    _lPuVoidray.Add(new UnitCount());
                    _lPuWarpprism.Add(new UnitCount());
                    _lPuZealot.Add(new UnitCount());
                    _lPuForcefield.Add(new UnitCount());

                    #endregion

                    #region Buildings

                    _lPbAssimilator.Add(new UnitCount());
                    _lPbCannon.Add(new UnitCount());
                    _lPbCybercore.Add(new UnitCount());
                    _lPbDarkshrine.Add(new UnitCount());
                    _lPbFleetbeacon.Add(new UnitCount());
                    _lPbForge.Add(new UnitCount());
                    _lPbGateway.Add(new UnitCount());
                    _lPbNexus.Add(new UnitCount());
                    _lPbPylon.Add(new UnitCount());
                    _lPbRobotics.Add(new UnitCount());
                    _lPbRoboticsSupport.Add(new UnitCount());
                    _lPbStargate.Add(new UnitCount());
                    _lPbTemplarArchives.Add(new UnitCount());
                    _lPbTwilight.Add(new UnitCount());
                    _lPbWarpgate.Add(new UnitCount());

                    #endregion

                    #region Upgrades

                    _lPupBlink.Add(new UnitCount());
                    _lPupCharge.Add(new UnitCount());
                    _lPupExtendedThermalLance.Add(new UnitCount());
                    _lPupGraviticBooster.Add(new UnitCount());
                    _lPupGraviticDrive.Add(new UnitCount());
                    _lPupGravitonCatapult.Add(new UnitCount());
                    _lPupGroundArmor1.Add(new UnitCount());
                    _lPupGroundArmor2.Add(new UnitCount());
                    _lPupGroundArmor3.Add(new UnitCount());
                    _lPupGroundWeapon1.Add(new UnitCount());
                    _lPupGroundWeapon2.Add(new UnitCount());
                    _lPupGroundWeapon3.Add(new UnitCount());
                    _lPupShield1.Add(new UnitCount());
                    _lPupShield2.Add(new UnitCount());
                    _lPupShield3.Add(new UnitCount());
                    _lPupStorm.Add(new UnitCount());
                    _lPupWarpGate.Add(new UnitCount());
                    _lPupAirArmor1.Add(new UnitCount());
                    _lPupAirArmor2.Add(new UnitCount());
                    _lPupAirArmor3.Add(new UnitCount());
                    _lPupAirWeapon1.Add(new UnitCount());
                    _lPupAirWeapon2.Add(new UnitCount());
                    _lPupAirWeapon3.Add(new UnitCount());
                    _lPupAnionPulseCrystal.Add(new UnitCount());

                    #endregion

                    #endregion

                    #region Zerg

                    #region Units

                    _lZuBaneling.Add(new UnitCount());
                    _lZuBanelingCocoon.Add(new UnitCount());
                    _lZuBroodlord.Add(new UnitCount());
                    _lZuBroodlordCocoon.Add(new UnitCount());
                    _lZuCorruptor.Add(new UnitCount());
                    _lZuDrone.Add(new UnitCount());
                    _lZuHydra.Add(new UnitCount());
                    _lZuInfestor.Add(new UnitCount());
                    _lZuInfestedTerran.Add(new UnitCount());
                    _lZuInfestedTerranEgg.Add(new UnitCount());
                    _lZuLarva.Add(new UnitCount());
                    _lZuMutalisk.Add(new UnitCount());
                    _lZuOverlord.Add(new UnitCount());
                    _lZuOverseer.Add(new UnitCount());
                    _lZuOverseerCocoon.Add(new UnitCount());
                    _lZuQueen.Add(new UnitCount());
                    _lZuRoach.Add(new UnitCount());
                    _lZuSwarmhost.Add(new UnitCount());
                    _lZuUltralisk.Add(new UnitCount());
                    _lZuViper.Add(new UnitCount());
                    _lZuZergling.Add(new UnitCount());
                    _lZuLocust.Add(new UnitCount());
                    _lZuFlyingLocust.Add(new UnitCount());
                    _lZuChangeling.Add(new UnitCount());

                    #endregion

                    #region Buildings

                    _lZbBanelingnest.Add(new UnitCount());
                    _lZbCreepTumor.Add(new UnitCount());
                    _lZbEvochamber.Add(new UnitCount());
                    _lZbExtractor.Add(new UnitCount());
                    _lZbGreaterspire.Add(new UnitCount());
                    _lZbHatchery.Add(new UnitCount());
                    _lZbHive.Add(new UnitCount());
                    _lZbHydraden.Add(new UnitCount());
                    _lZbInfestationpit.Add(new UnitCount());
                    _lZbLair.Add(new UnitCount());
                    _lZbNydusbegin.Add(new UnitCount());
                    _lZbNydusend.Add(new UnitCount());
                    _lZbRoachwarren.Add(new UnitCount());
                    _lZbSpawningpool.Add(new UnitCount());
                    _lZbSpine.Add(new UnitCount());
                    _lZbSpire.Add(new UnitCount());
                    _lZbSpore.Add(new UnitCount());
                    _lZbUltracavern.Add(new UnitCount());

                    #endregion

                    #region Upgrades

                    _lZupAdrenalGlands.Add(new UnitCount());
                    _lZupAirArmor1.Add(new UnitCount());
                    _lZupAirArmor2.Add(new UnitCount());
                    _lZupAirArmor3.Add(new UnitCount());
                    _lZupAirWeapon1.Add(new UnitCount());
                    _lZupAirWeapon2.Add(new UnitCount());
                    _lZupAirWeapon3.Add(new UnitCount());
                    _lZupBurrow.Add(new UnitCount());
                    _lZupCentrifugalHooks.Add(new UnitCount());
                    _lZupChitinousPlating.Add(new UnitCount());
                    _lZupEnduringLocusts.Add(new UnitCount());
                    _lZupGlialReconstruction.Add(new UnitCount());
                    _lZupGroovedSpines.Add(new UnitCount());
                    _lZupGroundArmor1.Add(new UnitCount());
                    _lZupGroundArmor2.Add(new UnitCount());
                    _lZupGroundArmor3.Add(new UnitCount());
                    _lZupGroundMelee1.Add(new UnitCount());
                    _lZupGroundMelee2.Add(new UnitCount());
                    _lZupGroundMelee3.Add(new UnitCount());
                    _lZupGroundWeapon1.Add(new UnitCount());
                    _lZupGroundWeapon2.Add(new UnitCount());
                    _lZupGroundWeapon3.Add(new UnitCount());
                    _lZupMetabolicBoost.Add(new UnitCount());
                    _lZupMuscularAugments.Add(new UnitCount());
                    _lZupNeutralParasite.Add(new UnitCount());
                    _lZupPathoglenGlands.Add(new UnitCount());
                    _lZupPneumatizedCarapace.Add(new UnitCount());
                    _lZupTunnnelingClaws.Add(new UnitCount());
                    _lZupVentralSacs.Add(new UnitCount());
                    _lZupFlyingLocust.Add(new UnitCount());

                    #endregion

                    #endregion
                }

                /* Forcefield.. */
                _lPuForcefield.Add(new UnitCount());

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
                            _lTuScv[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.TuMule)
                        {
                            _lTuMule[tmpUnit.Owner].UnitAmount += 1;
                            _lTuMule[tmpUnit.Owner].Id = UnitId.TuMule;
                            _lTuMule[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince/387328.0f));
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TuMarine)
                            _lTuMarine[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuMarauder)
                            _lTuMarauder[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuReaper)
                            _lTuReaper[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.TuGhost)
                        {
                            _lTuGhost[tmpUnit.Owner].UnitAmount += 1;
                            _lTuGhost[tmpUnit.Owner].Id = UnitId.TuGhost;
                            _lTuGhost[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            _lTuGhost[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TuWidowMine ||
                                 tmpUnit.Id ==
                                 UnitId.TuWidowMineBurrow)
                            _lTuWidowMine[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuSiegetank ||
                                 tmpUnit.Id ==
                                 UnitId.TuSiegetankSieged)
                            _lTuSiegetank[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.TuThor)
                            _lTuThor[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuHellbat)
                            _lTuHellbat[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuNuke)
                            _lTuNuke[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuHellion)
                            _lTuHellion[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuBanshee)
                            _lTuBanshee[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuBattlecruiser)
                            _lTuBattlecruiser[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuMedivac)
                            _lTuMedivac[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.TuRaven)
                            _lTuRaven[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.TuPdd)
                            _lTuPointDefenseDrone[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuVikingAir ||
                                 tmpUnit.Id ==
                                 UnitId.TuVikingGround)
                            _lTuViking[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Buildings

                            #region Command Center (Air/ Ground/ Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbCcGround ||
                                 tmpUnit.Id == UnitId.TbCcAir)
                        {
                            _lTbCommandCenter[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    _lTuScv[tmpUnit.Owner].UnitUnderConstruction += 1;
                                    _lTuScv[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
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
                                        _lTbOrbitalCommand[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTbOrbitalCommand[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupUpgradeToPlanetary))
                                    {
                                        _lTbPlanetaryFortress[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTbPlanetaryFortress[tmpUnit.Owner].ConstructionState.Add(
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
                            _lTbOrbitalCommand[tmpUnit.Owner].UnitAmount += 1;
                            _lTbOrbitalCommand[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            _lTbOrbitalCommand[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                            _lTbOrbitalCommand[tmpUnit.Owner].Id = UnitId.TbOrbitalGround;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    _lTuScv[tmpUnit.Owner].UnitUnderConstruction += 1;
                                    _lTuScv[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
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
                            _lTbBarracks[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuMarine))
                                    {
                                        _lTuMarine[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuMarine[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuMarauder))
                                    {
                                        _lTuMarauder[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuMarauder[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuReaper))
                                    {
                                        _lTuReaper[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuReaper[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuGhost))
                                    {
                                        _lTuGhost[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuGhost[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Bunker

                        else if (tmpUnit.Id ==
                                 UnitId.TbBunker)
                            _lTbBunker[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Turret

                        else if (tmpUnit.Id ==
                                 UnitId.TbTurret)
                            _lTbTurrent[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Refinery

                        else if (tmpUnit.Id ==
                                 UnitId.TbRefinery)
                            _lTbRefinery[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Sensor Tower

                        else if (tmpUnit.Id ==
                                 UnitId.TbSensortower)
                            _lTbSensorTower[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Planetary (Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbPlanetary)
                        {
                            _lTbPlanetaryFortress[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    _lTuScv[tmpUnit.Owner].UnitUnderConstruction += 1;
                                    _lTuScv[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                }
                            }
                        }

                            #endregion

                            #region Engineering Bay (Upgrade Production)

                        else if (tmpUnit.Id == UnitId.TbEbay)
                        {
                            _lTbEbay[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupInfantryArmor1))
                                    {
                                        _lTupInfantryArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupInfantryArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupInfantryArmor2))
                                    {
                                        _lTupInfantryArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupInfantryArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupInfantryArmor3))
                                    {
                                        _lTupInfantryArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupInfantryArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupInfantryWeapon1))
                                    {
                                        _lTupInfantryWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupInfantryWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupInfantryWeapon2))
                                    {
                                        _lTupInfantryWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupInfantryWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupInfantryWeapon3))
                                    {
                                        _lTupInfantryWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupInfantryWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupHighSecAutoTracking))
                                    {
                                        _lTupHighSecAutoTracking[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupHighSecAutoTracking[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupNeosteelFrame))
                                    {
                                        _lTupNeosteelFrame[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupNeosteelFrame[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupStructureArmor))
                                    {
                                        _lTupStructureArmor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupStructureArmor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
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
                            _lTbFactory[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuHellion))
                                    {
                                        _lTuHellion[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuHellion[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuHellbat))
                                    {
                                        _lTuHellbat[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuHellbat[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuWidowMine))
                                    {
                                        _lTuWidowMine[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuWidowMine[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuSiegetank))
                                    {
                                        _lTuSiegetank[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuSiegetank[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuThor))
                                    {
                                        _lTuThor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuThor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
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
                            _lTbStarport[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuVikingAir))
                                    {
                                        _lTuViking[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuViking[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuBanshee))
                                    {
                                        _lTuBanshee[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuBanshee[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuMedivac))
                                    {
                                        _lTuMedivac[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuMedivac[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuRaven))
                                    {
                                        _lTuRaven[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuRaven[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuBattlecruiser))
                                    {
                                        _lTuBattlecruiser[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuBattlecruiser[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
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
                            _lTbSupply[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Ghost Academy (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbGhostacademy)
                        {
                            _lTbGhostAcademy[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupPersonalCloak))
                                    {
                                        _lTupPersonalCloak[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupPersonalCloak[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupMoebiusReactor))
                                    {
                                        _lTupMoebiusReactor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupMoebiusReactor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TuNuke))
                                    {
                                        _lTuNuke[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuNuke[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Fucion Core (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbFusioncore)
                        {
                            _lTbFusionCore[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupWeaponRefit))
                                    {
                                        _lTupWeaponRefit[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupWeaponRefit[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupBehemothReactor))
                                    {
                                        _lTupBehemothReactor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupBehemothReactor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Armory (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbArmory)
                        {
                            _lTbArmory[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupVehicleShipPlanting1))
                                    {
                                        _lTupVehicleShipPlanting1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupVehicleShipPlanting1[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupVehicleShipPlanting2))
                                    {
                                        _lTupVehicleShipPlanting2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupVehicleShipPlanting2[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupVehicleShipPlanting3))
                                    {
                                        _lTupVehicleShipPlanting3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupVehicleShipPlanting3[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupVehicleWeapon1))
                                    {
                                        _lTupVehicleWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupVehicleWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupVehicleWeapon2))
                                    {
                                        _lTupVehicleWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupVehicleWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupVehicleWeapon3))
                                    {
                                        _lTupVehicleWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupVehicleWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupShipWeapon1))
                                    {
                                        _lTupShipWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupShipWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupShipWeapon2))
                                    {
                                        _lTupShipWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupShipWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupShipWeapon3))
                                    {
                                        _lTupShipWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupShipWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region AutoTurret

                        else if (tmpUnit.Id ==
                                 UnitId.TbAutoTurret)
                            _lTbAutoTurret[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Techlab Barracks (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.TbTechlabRax)
                        {
                            _lTbTechlab[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupStim))
                                    {
                                        _lTupStim[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupStim[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupCombatShields))
                                    {
                                        _lTupCombatShields[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupCombatShields[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupConcussiveShells))
                                    {
                                        _lTupConcussiveShells[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupConcussiveShells[tmpUnit.Owner].ConstructionState.Add(
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
                            _lTbTechlab[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupBlueFlame))
                                    {
                                        _lTupBlueFlame[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupBlueFlame[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupDrillingClaws))
                                    {
                                        _lTupDrillingClaws[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupDrillingClaws[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupTransformatorServos))
                                    {
                                        _lTupTransformationServos[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupTransformationServos[tmpUnit.Owner].ConstructionState.Add(
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
                            _lTbTechlab[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupCloakingField))
                                    {
                                        _lTupCloakingField[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupCloakingField[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupCorvidReactor))
                                    {
                                        _lTupCorvidReactor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupCorvidReactor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupCaduceusReactor))
                                    {
                                        _lTupCaduceusReactor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupCaduceusReactor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.TupDurableMeterials))
                                    {
                                        _lTupDurableMaterials[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupDurableMaterials[tmpUnit.Owner].ConstructionState.Add(
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
                            _lTbReactor[tmpUnit.Owner].UnitAmount += 1;

                            #endregion


                            #endregion

                            #endregion

                            #region Protoss

                            #region Units

                        else if (tmpUnit.Id ==
                                 UnitId.PuForceField)
                        {
                            _lPuForcefield[GInformation.Player.Count].UnitAmount += 1;
                            _lPuForcefield[GInformation.Player.Count].Id =
                                UnitId.PuForceField;
                            _lPuForcefield[GInformation.Player.Count].AliveSince.Add(1 -
                                                                                     (tmpUnit.AliveSince/
                                                                                      62208.0f));
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PuArchon)
                        {
                            _lPuArchon[tmpUnit.Owner].UnitAmount += 1;

                            //Archons take 12 seconds to finish morphing
                            //12 secs = 49152 SC2 ticks (* 4096)
                            //Thus AliveSince > 49152 = Ready to roll

                            if (tmpUnit.AliveSince < 49152)
                            {
                                _lPuArchon[tmpUnit.Owner].UnitUnderConstruction += 1;
                                _lPuArchon[tmpUnit.Owner].ConstructionState.Add((tmpUnit.AliveSince/49152f)*100);
                            }
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PuCarrier)
                            _lPuCarrier[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuColossus)
                            _lPuColossus[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuDarktemplar)
                            _lPuDt[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuHightemplar)
                        {
                            _lPuHt[tmpUnit.Owner].UnitAmount += 1;
                            _lPuHt[tmpUnit.Owner].Id = UnitId.PuHightemplar;
                            _lPuHt[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            _lPuHt[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PuImmortal)
                            _lPuImmortal[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuMothership)
                        {
                            _lPuMothership[tmpUnit.Owner].UnitAmount += 1;
                            _lPuMothership[tmpUnit.Owner].Id = UnitId.PuMothership;
                            _lPuMothership[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            _lPuMothership[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PuMothershipCore)
                        {
                            _lPuMothershipcore[tmpUnit.Owner].UnitAmount += 1;
                            _lPuMothershipcore[tmpUnit.Owner].Id = UnitId.PuMothershipCore;
                            _lPuMothershipcore[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            _lPuMothershipcore[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);

                            if (tmpUnit.ProdNumberOfQueuedUnits == 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupUpgradeToMothership))
                                    {
                                        _lPuMothership[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuMothership[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PuObserver)
                            _lPuObserver[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuOracle)
                            _lPuOracle[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuPhoenix)
                            _lPuPhoenix[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.PuProbe)
                            _lPuProbe[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuSentry)
                        {
                            _lPuSentry[tmpUnit.Owner].UnitAmount += 1;
                            _lPuSentry[tmpUnit.Owner].Id = UnitId.PuSentry;
                            _lPuSentry[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            _lPuSentry[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PuStalker)
                            _lPuStalker[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuTempest)
                            _lPuTempest[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuVoidray)
                            _lPuVoidray[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuWarpprismPhase ||
                                 tmpUnit.Id ==
                                 UnitId.PuWarpprismTransport)
                            _lPuWarpprism[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuZealot)
                            _lPuZealot[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Buildings

                            #region Nexus (Unit Production)

                        else if (tmpUnit.Id == UnitId.PbNexus)
                        {
                            _lPbNexus[tmpUnit.Owner].UnitAmount += 1;
                            _lPbNexus[tmpUnit.Owner].Id = tmpUnit.Id;
                            _lPbNexus[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            _lPbNexus[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PuProbe))
                                    {
                                        _lPuProbe[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuProbe[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuProbe[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuMothershipCore))
                                    {
                                        _lPuMothershipcore[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuMothershipcore[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuMothershipcore[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Pylon

                        else if (tmpUnit.Id == UnitId.PbPylon)
                            _lPbPylon[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Assimilator

                        else if (tmpUnit.Id ==
                                 UnitId.PbAssimilator)
                            _lPbAssimilator[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Cannon

                        else if (tmpUnit.Id ==
                                 UnitId.PbCannon)
                            _lPbCannon[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region CyberCore (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbCybercore)
                        {
                            _lPbCybercore[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupAirA1))
                                    {
                                        _lPupAirArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupAirArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupAirArmor1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupAirA2))
                                    {
                                        _lPupAirArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupAirArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupAirArmor2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupAirA3))
                                    {
                                        _lPupAirArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupAirArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupAirArmor3[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupAirW1))
                                    {
                                        _lPupAirWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupAirWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupAirWeapon1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupAirW2))
                                    {
                                        _lPupAirWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupAirWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupAirWeapon2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupAirW3))
                                    {
                                        _lPupAirWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupAirWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupAirWeapon3[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupWarpGate))
                                    {
                                        _lPupWarpGate[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupWarpGate[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupWarpGate[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                        _lPupWarpGate[tmpUnit.Owner].Id = UnitId.PupWarpGate;
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Dark Shrine

                        else if (tmpUnit.Id ==
                                 UnitId.PbDarkshrine)
                            _lPbDarkshrine[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Fleet Beacon (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbFleetbeacon)
                        {
                            _lPbFleetbeacon[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupAnionPulseCrystals))
                                    {
                                        _lPupAnionPulseCrystal[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupAnionPulseCrystal[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                        _lPupAnionPulseCrystal[tmpUnit.Owner].SpeedMultiplier.Add(
                                            tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGravitonCatapult))
                                    {
                                        _lPupGravitonCatapult[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGravitonCatapult[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                        _lPupGravitonCatapult[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Forge (Upgrade Production)

                        else if (tmpUnit.Id == UnitId.PbForge)
                        {
                            _lPbForge[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGroundA1))
                                    {
                                        _lPupGroundArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGroundArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGroundArmor1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGroundA2))
                                    {
                                        _lPupGroundArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGroundArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGroundArmor2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGroundA3))
                                    {
                                        _lPupGroundArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGroundArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGroundArmor3[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGroundW1))
                                    {
                                        _lPupGroundWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGroundWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGroundWeapon1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGroundW2))
                                    {
                                        _lPupGroundWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGroundWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGroundWeapon2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGroundW3))
                                    {
                                        _lPupGroundWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGroundWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGroundWeapon3[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupS1))
                                    {
                                        _lPupShield1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupShield1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupShield1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupS2))
                                    {
                                        _lPupShield2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupShield2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupShield2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupS3))
                                    {
                                        _lPupShield3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupShield3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupShield3[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Gateway (Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbGateway)
                        {
                            _lPbGateway[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PuZealot))
                                    {
                                        _lPuZealot[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuZealot[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuZealot[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuStalker))
                                    {
                                        _lPuStalker[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuStalker[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuStalker[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuSentry))
                                    {
                                        _lPuSentry[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuSentry[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuSentry[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuHightemplar))
                                    {
                                        _lPuHt[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuHt[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuHt[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuDarktemplar))
                                    {
                                        _lPuDt[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuDt[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuDt[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Robotics Bay (Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbRoboticsbay)
                        {
                            _lPbRobotics[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PuObserver))
                                    {
                                        _lPuObserver[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuObserver[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuObserver[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuWarpprismTransport))
                                    {
                                        _lPuWarpprism[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuWarpprism[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuWarpprism[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuImmortal))
                                    {
                                        _lPuImmortal[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuImmortal[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuImmortal[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuColossus))
                                    {
                                        _lPuColossus[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuColossus[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuColossus[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Robotics Support Bay (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbRoboticssupportbay)
                        {
                            _lPbRoboticsSupport[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupExtendedThermalLance))
                                    {
                                        _lPupExtendedThermalLance[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupExtendedThermalLance[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                        _lPupExtendedThermalLance[tmpUnit.Owner].SpeedMultiplier.Add(
                                            tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGraviticBooster))
                                    {
                                        _lPupGraviticBooster[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGraviticBooster[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGraviticBooster[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupGraviticDrive))
                                    {
                                        _lPupGraviticDrive[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGraviticDrive[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGraviticDrive[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Stargate (Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbStargate)
                        {
                            _lPbStargate[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PuPhoenix))
                                    {
                                        _lPuPhoenix[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuPhoenix[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuPhoenix[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuOracle))
                                    {
                                        _lPuOracle[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuOracle[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuOracle[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuVoidray))
                                    {
                                        _lPuVoidray[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuVoidray[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuVoidray[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuCarrier))
                                    {
                                        _lPuCarrier[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuCarrier[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuCarrier[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.PuTempest))
                                    {
                                        _lPuTempest[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuTempest[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuTempest[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Templar Archives (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbTemplararchives)
                        {
                            _lPbTemplarArchives[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupStorm))
                                    {
                                        _lPupStorm[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupStorm[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupStorm[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Twilight Council (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbTwilightcouncil)
                        {
                            _lPbTwilight[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupBlink))
                                    {
                                        _lPupBlink[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupBlink[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupBlink[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.PupCharge))
                                    {
                                        _lPupCharge[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupCharge[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupCharge[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region WarpGate (Unit Production)

                        else if (tmpUnit.Id ==
                                 UnitId.PbWarpgate)
                            _lPbWarpgate[tmpUnit.Owner].UnitAmount += 1;

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
                                        _lZuDrone[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuDrone[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuOverlord))
                                    {
                                        _lZuOverlord[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuOverlord[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuZergling))
                                    {
                                        _lZuZergling[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuZergling[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuRoach))
                                    {
                                        _lZuRoach[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuRoach[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuHydralisk))
                                    {
                                        _lZuHydra[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuHydra[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuMutalisk))
                                    {
                                        _lZuMutalisk[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuMutalisk[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuInfestor))
                                    {
                                        _lZuInfestor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuInfestor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuUltra))
                                    {
                                        _lZuUltralisk[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuUltralisk[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuCorruptor))
                                    {
                                        _lZuCorruptor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuCorruptor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuViper))
                                    {
                                        _lZuViper[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuViper[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZuSwarmHost))
                                    {
                                        _lZuSwarmhost[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuSwarmhost[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBaneling ||
                                 tmpUnit.Id ==
                                 UnitId.ZuBanelingBurrow)
                            _lZuBaneling[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuLocust)
                        {
                            _lZuLocust[tmpUnit.Owner].UnitAmount += 1;
                            _lZuLocust[tmpUnit.Owner].Id = UnitId.ZuLocust;

                            if (tmpUnit.AliveSince > 73216f)
                                _lZuLocust[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince/113920f));

                            else
                                _lZuLocust[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince/73216f));
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZuFlyingLocust)
                        {
                            _lZuFlyingLocust[tmpUnit.Owner].UnitAmount += 1;
                            _lZuFlyingLocust[tmpUnit.Owner].Id = UnitId.ZuFlyingLocust;

                            if (tmpUnit.AliveSince > 73216f)
                                _lZuFlyingLocust[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince / 113920f));

                            else
                                _lZuFlyingLocust[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince / 73216f));
                        }


                        else if (tmpUnit.Id ==
                                 UnitId.ZuBanelingCocoon)
                        {
                            _lZuBanelingCocoon[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZuBaneling))
                                    {
                                        _lZuBaneling[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuBaneling[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBroodlord)
                            _lZuBroodlord[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBroodlordCocoon)
                        {
                            _lZuBroodlordCocoon[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits == 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupUpgradeToBroodlord))
                                    {
                                        _lZuBroodlord[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuBroodlord[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZuCorruptor)
                            _lZuCorruptor[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.ZuDrone ||
                                 tmpUnit.Id ==
                                 UnitId.ZuDroneBurrow)
                            _lZuDrone[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuHydraBurrow ||
                                 tmpUnit.Id ==
                                 UnitId.ZuHydralisk)
                            _lZuHydra[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuInfestor ||
                                 tmpUnit.Id ==
                                 UnitId.ZuInfestorBurrow)
                        {
                            _lZuInfestor[tmpUnit.Owner].UnitAmount += 1;
                            _lZuInfestor[tmpUnit.Owner].Id = UnitId.ZuInfestor;
                            _lZuInfestor[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            _lZuInfestor[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZuInfestedTerran ||
                                 tmpUnit.Id ==
                                 UnitId.ZuInfestedTerran2)
                        {
                            _lZuInfestedTerran[tmpUnit.Owner].UnitAmount += 1;
                            _lZuInfestedTerran[tmpUnit.Owner].Id = UnitId.ZuInfestedTerran;
                            _lZuInfestedTerran[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince / 143360f));
                        }

                        else if (tmpUnit.Id == UnitId.ZuInfestedSwarmEgg)
                        {
                            _lZuInfestedTerranEgg[tmpUnit.Owner].UnitUnderConstruction += 1;
                            _lZuInfestedTerranEgg[tmpUnit.Owner].Id = UnitId.ZuInfestedSwarmEgg;
                            _lZuInfestedTerranEgg[tmpUnit.Owner].ConstructionState.Add(tmpUnit.AliveSince/20480f * 100);

                        }

                        else if (tmpUnit.Id == UnitId.ZuLarva)
                            _lZuLarva[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuMutalisk)
                            _lZuMutalisk[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuOverlord)
                            _lZuOverlord[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuOverseer)
                            _lZuOverseer[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuOverseerCocoon)
                        {
                            _lZuOverseerCocoon[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits == 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupUpgradeToOverseer))
                                    {
                                        _lZuOverseer[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuOverseer[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        else if (tmpUnit.Id == UnitId.ZuQueen ||
                                 tmpUnit.Id ==
                                 UnitId.ZuQueenBurrow)
                        {
                            _lZuQueen[tmpUnit.Owner].UnitAmount += 1;
                            _lZuQueen[tmpUnit.Owner].Id = UnitId.ZuQueen;
                            _lZuQueen[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            _lZuQueen[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                        }

                        else if (tmpUnit.Id == UnitId.ZuRoach ||
                                 tmpUnit.Id ==
                                 UnitId.ZuRoachBurrow)
                            _lZuRoach[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuSwarmHost ||
                                 tmpUnit.Id ==
                                 UnitId.ZuSwarmHostBurrow)
                            _lZuSwarmhost[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.ZuUltra ||
                                 tmpUnit.Id ==
                                 UnitId.ZuUltraBurrow)
                            _lZuUltralisk[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.ZuViper)
                        {
                            _lZuViper[tmpUnit.Owner].UnitAmount += 1;
                            _lZuViper[tmpUnit.Owner].Id = UnitId.ZuViper;
                            _lZuViper[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            _lZuViper[tmpUnit.Owner].MaximumEnergy.Add(tmpUnit.MaximumEnergy);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZuZergling ||
                                 tmpUnit.Id ==
                                 UnitId.ZuZerglingBurrow)
                            _lZuZergling[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == UnitId.ZuChangeling ||
                                 tmpUnit.Id == UnitId.ZuChangelingMarineShield ||
                                 tmpUnit.Id == UnitId.ZuChangelingMarine ||
                                 tmpUnit.Id == UnitId.ZuChangelingSpeedling ||
                                 tmpUnit.Id == UnitId.ZuChangelingZealot ||
                                 tmpUnit.Id == UnitId.ZuChangelingZergling)
                        {
                            _lZuChangeling[tmpUnit.Owner].UnitAmount += 1;
                            _lZuChangeling[tmpUnit.Owner].Id = UnitId.ZuChangeling;
                            _lZuChangeling[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince / 614400f));
                        }

                            #endregion

                            #region Structures

                            #region Baneling Nest (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbBanelingNest)
                        {
                            _lZbBanelingnest[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupCentrifugalHooks))
                                    {
                                        _lZupCentrifugalHooks[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupCentrifugalHooks[tmpUnit.Owner].ConstructionState.Add(
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
                            _lZbCreepTumor[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Evolution Chamber (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbEvolutionChamber)
                        {
                            _lZbEvochamber[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundA1))
                                    {
                                        _lZupGroundArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundA2))
                                    {
                                        _lZupGroundArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundA3))
                                    {
                                        _lZupGroundArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundW1))
                                    {
                                        _lZupGroundWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundW2))
                                    {
                                        _lZupGroundWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundW3))
                                    {
                                        _lZupGroundWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundM1))
                                    {
                                        _lZupGroundMelee1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundMelee1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundM2))
                                    {
                                        _lZupGroundMelee2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundMelee2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroundM3))
                                    {
                                        _lZupGroundMelee3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundMelee3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Extractor

                        else if (tmpUnit.Id ==
                                 UnitId.ZbExtractor)
                            _lZbExtractor[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Greater Spire (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbGreaterspire)
                        {
                            _lZbGreaterspire[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirA1))
                                    {
                                        _lZupAirArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirA2))
                                    {
                                        _lZupAirArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirA3))
                                    {
                                        _lZupAirArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirW1))
                                    {
                                        _lZupAirWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirW2))
                                    {
                                        _lZupAirWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirW3))
                                    {
                                        _lZupAirWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Hatchery (Unit Production, Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbHatchery)
                        {
                            _lZbHatchery[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZuQueen))
                                    {
                                        _lZuQueen[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuQueen[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupVentralSacs))
                                    {
                                        _lZupVentralSacs[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupVentralSacs[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupBurrow))
                                    {
                                        _lZupBurrow[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupBurrow[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupPneumatizedCarapace))
                                    {
                                        _lZupPneumatizedCarapace[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupPneumatizedCarapace[tmpUnit.Owner].ConstructionState.Add(
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
                                        _lZbLair[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZbLair[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Hive (Unit Production, Upgrade Production)

                        else if (tmpUnit.Id == UnitId.ZbHive)
                        {
                            _lZbHive[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZuQueen))
                                    {
                                        _lZuQueen[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuQueen[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupVentralSacs))
                                    {
                                        _lZupVentralSacs[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupVentralSacs[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupBurrow))
                                    {
                                        _lZupBurrow[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupBurrow[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupPneumatizedCarapace))
                                    {
                                        _lZupPneumatizedCarapace[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupPneumatizedCarapace[tmpUnit.Owner].ConstructionState.Add(
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
                            _lZbHydraden[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupGroovedSpines))
                                    {
                                        _lZupGroovedSpines[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroovedSpines[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupMuscularAugments))
                                    {
                                        _lZupMuscularAugments[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupMuscularAugments[tmpUnit.Owner].ConstructionState.Add(
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
                            _lZbInfestationpit[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupNeutralParasite))
                                    {
                                        _lZupNeutralParasite[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupNeutralParasite[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupEnduringLocusts))
                                    {
                                        _lZupEnduringLocusts[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupEnduringLocusts[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupPathoglenGlands))
                                    {
                                        _lZupPathoglenGlands[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupPathoglenGlands[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(UnitId.ZupFlyingLocust))
                                    {
                                        _lZupFlyingLocust[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupFlyingLocust[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Liar (Unit Production, Upgrade Production)

                        else if (tmpUnit.Id == UnitId.ZbLiar)
                        {
                            _lZbLair[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZuQueen))
                                    {
                                        _lZuQueen[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuQueen[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupVentralSacs))
                                    {
                                        _lZupVentralSacs[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupVentralSacs[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupBurrow))
                                    {
                                        _lZupBurrow[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupBurrow[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupPneumatizedCarapace))
                                    {
                                        _lZupPneumatizedCarapace[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupPneumatizedCarapace[tmpUnit.Owner].ConstructionState.Add(
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
                                        _lZbHive[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZbHive[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                            #endregion

                            #region Nydus Network

                        else if (tmpUnit.Id ==
                                 UnitId.ZbNydusNetwork)
                            _lZbNydusbegin[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Nydus Worm

                        else if (tmpUnit.Id ==
                                 UnitId.ZbNydusWorm)
                            _lZbNydusend[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Roach Warran (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbRoachWarren)
                        {
                            _lZbRoachwarren[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupTunnelingClaws))
                                    {
                                        _lZupTunnnelingClaws[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupTunnnelingClaws[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupGlialReconstruction))
                                    {
                                        _lZupGlialReconstruction[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGlialReconstruction[tmpUnit.Owner].ConstructionState.Add(
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
                            _lZbSpawningpool[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupMetabolicBoost))
                                    {
                                        _lZupMetabolicBoost[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupMetabolicBoost[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        UnitId.ZupAdrenalGlands))
                                    {
                                        _lZupAdrenalGlands[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAdrenalGlands[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
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
                            _lZbSpine[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Spire (Upgrade Production)

                        else if (tmpUnit.Id == UnitId.ZbSpire)
                        {
                            _lZbSpire[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirA1))
                                    {
                                        _lZupAirArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirA2))
                                    {
                                        _lZupAirArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirA3))
                                    {
                                        _lZupAirArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirW1))
                                    {
                                        _lZupAirWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirW2))
                                    {
                                        _lZupAirWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupAirW3))
                                    {
                                        _lZupAirWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
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
                                        _lZbGreaterspire[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZbGreaterspire[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
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
                            _lZbSpore[tmpUnit.Owner].UnitAmount += 1;

                            #endregion

                            #region Ultra Cavern (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 UnitId.ZbUltraCavern)
                        {
                            _lZbUltracavern[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            UnitId.ZupChitinousPlating))
                                    {
                                        _lZupChitinousPlating[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupChitinousPlating[tmpUnit.Owner].ConstructionState.Add(
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
                            _lTbCommandCenter[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbCommandCenter[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbOrbitalAir ||
                                 tmpUnit.Id ==
                                 UnitId.TbOrbitalGround)
                        {
                            _lTbOrbitalCommand[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbOrbitalCommand[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbRaxAir ||
                                 tmpUnit.Id ==
                                 UnitId.TbBarracksGround)
                        {
                            _lTbBarracks[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbBarracks[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbBunker)
                        {
                            _lTbBunker[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbBunker[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbTurret)
                        {
                            _lTbTurrent[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbTurrent[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbRefinery)
                        {
                            _lTbRefinery[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbRefinery[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbSensortower)
                        {
                            _lTbSensorTower[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbSensorTower[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbPlanetary)
                        {
                            _lTbPlanetaryFortress[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbPlanetaryFortress[tmpUnit.Owner].ConstructionState.Add(tmp);


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    _lTuScv[tmpUnit.Owner].UnitUnderConstruction += 1;
                                    _lTuScv[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                }
                            }
                        }

                        else if (tmpUnit.Id == UnitId.TbEbay)
                        {
                            _lTbEbay[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbEbay[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbFactoryAir ||
                                 tmpUnit.Id ==
                                 UnitId.TbFactoryGround)
                        {
                            _lTbFactory[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbFactory[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbStarportAir ||
                                 tmpUnit.Id ==
                                 UnitId.TbStarportGround)
                        {
                            _lTbStarport[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbStarport[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbSupplyGround ||
                                 tmpUnit.Id ==
                                 UnitId.TbSupplyHidden)
                        {
                            _lTbSupply[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbSupply[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbGhostacademy)
                        {
                            _lTbGhostAcademy[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbGhostAcademy[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbFusioncore)
                        {
                            _lTbFusionCore[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbFusionCore[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.TbArmory)
                        {
                            _lTbArmory[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbArmory[tmpUnit.Owner].ConstructionState.Add(tmp);
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
                            _lTbTechlab[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbTechlab[tmpUnit.Owner].ConstructionState.Add(tmp);
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
                            _lTbReactor[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lTbReactor[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                            #endregion

                            #region Units

                        else if (tmpUnit.Id == UnitId.TuScv)
                            _lTuScv[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.TuMule)
                            _lTuMule[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuMarine)
                            _lTuMarine[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuMarauder)
                            _lTuMarauder[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuReaper)
                            _lTuReaper[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.TuGhost)
                            _lTuGhost[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuWidowMine ||
                                 tmpUnit.Id ==
                                 UnitId.TuWidowMineBurrow)
                            _lTuWidowMine[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuSiegetank ||
                                 tmpUnit.Id ==
                                 UnitId.TuSiegetankSieged)
                            _lTuSiegetank[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.TuThor)
                            _lTuThor[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuHellbat)
                            _lTuHellbat[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuHellion)
                            _lTuHellion[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuBanshee)
                            _lTuBanshee[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuBattlecruiser)
                            _lTuBattlecruiser[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuMedivac)
                            _lTuMedivac[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.TuRaven)
                            _lTuRaven[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.TuVikingAir ||
                                 tmpUnit.Id ==
                                 UnitId.TuVikingGround)
                            _lTuViking[tmpUnit.Owner].UnitUnderConstruction += 1;



                            #endregion

                            #endregion

                            #region Protoss

                            #region Structures

                        else if (tmpUnit.Id == UnitId.PbNexus)
                        {
                            _lPbNexus[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbNexus[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == UnitId.PbPylon)
                        {
                            _lPbPylon[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbPylon[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbAssimilator)
                        {
                            _lPbAssimilator[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbAssimilator[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbCannon)
                        {
                            _lPbCannon[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbCannon[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbCybercore)
                        {
                            _lPbCybercore[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbCybercore[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbDarkshrine)
                        {
                            _lPbDarkshrine[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbDarkshrine[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbFleetbeacon)
                        {
                            _lPbFleetbeacon[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbFleetbeacon[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == UnitId.PbForge)
                        {
                            _lPbForge[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbForge[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbGateway)
                        {
                            _lPbGateway[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbGateway[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbRoboticsbay)
                        {
                            _lPbRobotics[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbRobotics[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbRoboticssupportbay)
                        {
                            _lPbRoboticsSupport[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbRoboticsSupport[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbStargate)
                        {
                            _lPbStargate[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbStargate[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbTemplararchives)
                        {
                            _lPbTemplarArchives[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbTemplarArchives[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbTwilightcouncil)
                        {
                            _lPbTwilight[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbTwilight[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.PbWarpgate)
                        {
                            _lPbWarpgate[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lPbWarpgate[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                            #endregion

                            #region Units

                        /*else if (tmpUnit.Id ==
                            UnitId.PuArchon)
                            _lPuArchon[tmpUnit.Owner].UnitUnderConstruction += 1;*/

                        else if (tmpUnit.Id ==
                                 UnitId.PuCarrier)
                            _lPuCarrier[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuColossus)
                            _lPuColossus[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuDarktemplar)
                            _lPuDt[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuHightemplar)
                            _lPuHt[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuImmortal)
                            _lPuImmortal[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuMothership)
                            _lPuMothership[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuMothershipCore)
                            _lPuMothershipcore[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuObserver)
                            _lPuObserver[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuOracle)
                            _lPuOracle[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuPhoenix)
                            _lPuPhoenix[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.PuProbe)
                            _lPuProbe[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuSentry)
                            _lPuSentry[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuStalker)
                            _lPuStalker[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuTempest)
                            _lPuTempest[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuVoidray)
                            _lPuVoidray[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuWarpprismPhase ||
                                 tmpUnit.Id ==
                                 UnitId.PuWarpprismTransport)
                            _lPuWarpprism[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.PuZealot)
                            _lPuZealot[tmpUnit.Owner].UnitUnderConstruction += 1;

                            #endregion

                            #endregion

                            #region Zerg

                            #region Structures

                        else if (tmpUnit.Id ==
                                 UnitId.ZbBanelingNest)
                        {
                            _lZbBanelingnest[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbBanelingnest[tmpUnit.Owner].ConstructionState.Add(tmp);
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
                            _lZbCreepTumor[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbCreepTumor[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbEvolutionChamber)
                        {
                            _lZbEvochamber[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbEvochamber[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbExtractor)
                        {
                            _lZbExtractor[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbExtractor[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbGreaterspire)
                        {
                            _lZbGreaterspire[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbGreaterspire[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbHatchery)
                        {
                            _lZbHatchery[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbHatchery[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == UnitId.ZbHive)
                        {
                            _lZbHive[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbHive[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbHydraDen)
                        {
                            _lZbHydraden[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbHydraden[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbInfestationPit)
                        {
                            _lZbInfestationpit[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbInfestationpit[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == UnitId.ZbLiar)
                        {
                            _lZbLair[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbLair[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbNydusNetwork)
                        {
                            _lZbNydusbegin[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbNydusbegin[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbNydusWorm)
                        {
                            _lZbNydusend[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp = tmpUnit.AliveSince/81920f * 100;
                            _lZbNydusend[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbRoachWarren)
                        {
                            _lZbRoachwarren[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbRoachwarren[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbSpawningPool)
                        {
                            _lZbSpawningpool[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbSpawningpool[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbSpineCrawler ||
                                 tmpUnit.Id ==
                                 UnitId.ZbSpineCrawlerUnrooted)
                        {
                            _lZbSpine[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbSpine[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == UnitId.ZbSpire)
                        {
                            _lZbSpire[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbSpire[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbSporeCrawler ||
                                 tmpUnit.Id ==
                                 UnitId.ZbSporeCrawlerUnrooted)
                        {
                            _lZbSpore[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);
                            _lZbSpore[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                                 UnitId.ZbUltraCavern)
                        {
                            _lZbUltracavern[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                    Math.Round(
                                        ((tmpUnit.MaximumHealth -
                                          tmpUnit.DamageTaken)/
                                         (float) tmpUnit.MaximumHealth)*100, 1);

                            _lZbUltracavern[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                            #endregion

                            #region Units

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBaneling ||
                                 tmpUnit.Id ==
                                 UnitId.ZuBanelingBurrow)
                            _lZuBaneling[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBanelingCocoon)
                            _lZuBanelingCocoon[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBroodlord)
                            _lZuBroodlord[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuBroodlordCocoon)
                            _lZuBroodlordCocoon[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuCorruptor)
                            _lZuCorruptor[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.ZuDrone ||
                                 tmpUnit.Id ==
                                 UnitId.ZuDroneBurrow)
                            _lZuDrone[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuHydraBurrow ||
                                 tmpUnit.Id ==
                                 UnitId.ZuHydralisk)
                            _lZuHydra[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuInfestor ||
                                 tmpUnit.Id ==
                                 UnitId.ZuInfestorBurrow)
                            _lZuInfestor[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.ZuLarva)
                            _lZuLarva[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuMutalisk)
                            _lZuMutalisk[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuOverlord)
                            _lZuOverlord[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuOverseer)
                            _lZuOverseer[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuOverseerCocoon)
                            _lZuOverseerCocoon[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.ZuQueen ||
                                 tmpUnit.Id ==
                                 UnitId.ZuQueenBurrow)
                            _lZuQueen[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.ZuRoach ||
                                 tmpUnit.Id ==
                                 UnitId.ZuRoachBurrow)
                            _lZuRoach[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuSwarmHost ||
                                 tmpUnit.Id ==
                                 UnitId.ZuSwarmHostBurrow)
                            _lZuSwarmhost[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.ZuUltra ||
                                 tmpUnit.Id ==
                                 UnitId.ZuUltraBurrow)
                            _lZuUltralisk[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == UnitId.ZuViper)
                            _lZuViper[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                                 UnitId.ZuZergling ||
                                 tmpUnit.Id ==
                                 UnitId.ZuZerglingBurrow)
                            _lZuZergling[tmpUnit.Owner].UnitUnderConstruction += 1;

                        #endregion

                        #endregion
                    }

                    #endregion
                }

                #region Sort Construction- states

                #region Terran

                SortConstructionStates(ref _lTbArmory);
                SortConstructionStates(ref _lTbAutoTurret);
                SortConstructionStates(ref _lTbBarracks);
                SortConstructionStates(ref _lTbBunker);
                SortConstructionStates(ref _lTbCommandCenter);
                SortConstructionStates(ref _lTbEbay);
                SortConstructionStates(ref _lTbFactory);
                SortConstructionStates(ref _lTbFusionCore);
                SortConstructionStates(ref _lTbGhostAcademy);
                SortConstructionStates(ref _lTbOrbitalCommand);
                SortConstructionStates(ref _lTbPlanetaryFortress);
                SortConstructionStates(ref _lTbReactor);
                SortConstructionStates(ref _lTbRefinery);
                SortConstructionStates(ref _lTbSensorTower);
                SortConstructionStates(ref _lTbStarport);
                SortConstructionStates(ref _lTbSupply);
                SortConstructionStates(ref _lTbTechlab);
                SortConstructionStates(ref _lTbTurrent);

                SortConstructionStates(ref _lTuBanshee);
                SortConstructionStates(ref _lTuBattlecruiser);
                SortConstructionStates(ref _lTuGhost);
                SortConstructionStates(ref _lTuHellbat);
                SortConstructionStates(ref _lTuHellion);
                SortConstructionStates(ref _lTuMarauder);
                SortConstructionStates(ref _lTuMarine);
                SortConstructionStates(ref _lTuMedivac);
                SortAliveSinceStates(ref _lTuMule);
                SortConstructionStates(ref _lTuNuke);
                SortConstructionStates(ref _lTuPointDefenseDrone);
                SortConstructionStates(ref _lTuRaven);
                SortConstructionStates(ref _lTuReaper);
                SortConstructionStates(ref _lTuScv);
                SortConstructionStates(ref _lTuSiegetank);
                SortConstructionStates(ref _lTuThor);
                SortConstructionStates(ref _lTuViking);
                SortConstructionStates(ref _lTuWidowMine);

                SortConstructionStates(ref _lTupBehemothReactor);
                SortConstructionStates(ref _lTupBlueFlame);
                SortConstructionStates(ref _lTupCaduceusReactor);
                SortConstructionStates(ref _lTupCloakingField);
                SortConstructionStates(ref _lTupCombatShields);
                SortConstructionStates(ref _lTupConcussiveShells);
                SortConstructionStates(ref _lTupCorvidReactor);
                SortConstructionStates(ref _lTupDrillingClaws);
                SortConstructionStates(ref _lTupDurableMaterials);
                SortConstructionStates(ref _lTupHighSecAutoTracking);
                SortConstructionStates(ref _lTupInfantryArmor1);
                SortConstructionStates(ref _lTupInfantryArmor2);
                SortConstructionStates(ref _lTupInfantryArmor3);
                SortConstructionStates(ref _lTupInfantryWeapon1);
                SortConstructionStates(ref _lTupInfantryWeapon2);
                SortConstructionStates(ref _lTupInfantryWeapon3);
                SortConstructionStates(ref _lTupMoebiusReactor);
                SortConstructionStates(ref _lTupNeosteelFrame);
                SortConstructionStates(ref _lTupOrbitalCommand);
                SortConstructionStates(ref _lTupPersonalCloak);
                SortConstructionStates(ref _lTupPlanetaryFortress);
                SortConstructionStates(ref _lTupShipWeapon1);
                SortConstructionStates(ref _lTupShipWeapon2);
                SortConstructionStates(ref _lTupShipWeapon3);
                SortConstructionStates(ref _lTupStim);
                SortConstructionStates(ref _lTupStructureArmor);
                SortConstructionStates(ref _lTupTransformationServos);
                SortConstructionStates(ref _lTupVehicleShipPlanting1);
                SortConstructionStates(ref _lTupVehicleShipPlanting2);
                SortConstructionStates(ref _lTupVehicleShipPlanting3);
                SortConstructionStates(ref _lTupVehicleWeapon1);
                SortConstructionStates(ref _lTupVehicleWeapon2);
                SortConstructionStates(ref _lTupVehicleWeapon3);
                SortConstructionStates(ref _lTupWeaponRefit);

                #endregion

                #region Protoss

                SortConstructionStates(ref _lPbAssimilator);
                SortConstructionStates(ref _lPbCannon);
                SortConstructionStates(ref _lPbCybercore);
                SortConstructionStates(ref _lPbDarkshrine);
                SortConstructionStates(ref _lPbFleetbeacon);
                SortConstructionStates(ref _lPbForge);
                SortConstructionStates(ref _lPbGateway);
                SortConstructionStates(ref _lPbNexus);
                SortConstructionStates(ref _lPbPylon);
                SortConstructionStates(ref _lPbRobotics);
                SortConstructionStates(ref _lPbRoboticsSupport);
                SortConstructionStates(ref _lPbStargate);
                SortConstructionStates(ref _lPbTemplarArchives);
                SortConstructionStates(ref _lPbTwilight);
                SortConstructionStates(ref _lPbWarpgate);

                SortConstructionStates(ref _lPuArchon);
                SortConstructionStates(ref _lPuCarrier);
                SortConstructionStates(ref _lPuColossus);
                SortConstructionStates(ref _lPuDt);
                SortConstructionStates(ref _lPuHt);
                SortConstructionStates(ref _lPuImmortal);
                SortConstructionStates(ref _lPuMothership);
                SortConstructionStates(ref _lPuMothershipcore);
                SortConstructionStates(ref _lPuObserver);
                SortConstructionStates(ref _lPuOracle);
                SortConstructionStates(ref _lPuPhoenix);
                SortConstructionStates(ref _lPuProbe);
                SortConstructionStates(ref _lPuSentry);
                SortConstructionStates(ref _lPuStalker);
                SortConstructionStates(ref _lPuTempest);
                SortConstructionStates(ref _lPuVoidray);
                SortConstructionStates(ref _lPuWarpprism);
                SortConstructionStates(ref _lPuZealot);
                SortAliveSinceStates(ref _lPuForcefield);

                SortConstructionStates(ref _lPupAirArmor1);
                SortConstructionStates(ref _lPupAirArmor2);
                SortConstructionStates(ref _lPupAirArmor3);
                SortConstructionStates(ref _lPupAirWeapon1);
                SortConstructionStates(ref _lPupAirWeapon2);
                SortConstructionStates(ref _lPupAirWeapon3);
                SortConstructionStates(ref _lPupAnionPulseCrystal);
                SortConstructionStates(ref _lPupBlink);
                SortConstructionStates(ref _lPupCharge);
                SortConstructionStates(ref _lPupExtendedThermalLance);
                SortConstructionStates(ref _lPupGraviticBooster);
                SortConstructionStates(ref _lPupGraviticDrive);
                SortConstructionStates(ref _lPupGravitonCatapult);
                SortConstructionStates(ref _lPupGroundArmor1);
                SortConstructionStates(ref _lPupGroundArmor2);
                SortConstructionStates(ref _lPupGroundArmor3);
                SortConstructionStates(ref _lPupGroundWeapon1);
                SortConstructionStates(ref _lPupGroundWeapon2);
                SortConstructionStates(ref _lPupGroundWeapon3);
                SortConstructionStates(ref _lPupShield1);
                SortConstructionStates(ref _lPupShield2);
                SortConstructionStates(ref _lPupShield3);
                SortConstructionStates(ref _lPupStorm);
                SortConstructionStates(ref _lPupWarpGate);

                #endregion

                #region Zerg

                SortConstructionStates(ref _lZbBanelingnest);
                SortConstructionStates(ref _lZbCreepTumor);
                SortConstructionStates(ref _lZbEvochamber);
                SortConstructionStates(ref _lZbExtractor);
                SortConstructionStates(ref _lZbGreaterspire);
                SortConstructionStates(ref _lZbHatchery);
                SortConstructionStates(ref _lZbHive);
                SortConstructionStates(ref _lZbHydraden);
                SortConstructionStates(ref _lZbInfestationpit);
                SortConstructionStates(ref _lZbLair);
                SortConstructionStates(ref _lZbNydusbegin);
                SortConstructionStates(ref _lZbNydusend);
                SortConstructionStates(ref _lZbRoachwarren);
                SortConstructionStates(ref _lZbSpawningpool);
                SortConstructionStates(ref _lZbSpine);
                SortConstructionStates(ref _lZbSpire);
                SortConstructionStates(ref _lZbSpore);
                SortConstructionStates(ref _lZbUltracavern);

                SortConstructionStates(ref _lZuBaneling);
                SortConstructionStates(ref _lZuBanelingCocoon);
                SortConstructionStates(ref _lZuBroodlord);
                SortConstructionStates(ref _lZuBroodlordCocoon);
                SortConstructionStates(ref _lZuCorruptor);
                SortConstructionStates(ref _lZuDrone);
                SortConstructionStates(ref _lZuHydra);
                SortConstructionStates(ref _lZuInfestor);
                SortConstructionStates(ref _lZuInfestedTerranEgg);
                SortConstructionStates(ref _lZuLarva);
                SortConstructionStates(ref _lZuMutalisk);
                SortConstructionStates(ref _lZuOverlord);
                SortConstructionStates(ref _lZuOverseer);
                SortConstructionStates(ref _lZuOverseerCocoon);
                SortConstructionStates(ref _lZuQueen);
                SortConstructionStates(ref _lZuRoach);
                SortConstructionStates(ref _lZuSwarmhost);
                SortConstructionStates(ref _lZuUltralisk);
                SortConstructionStates(ref _lZuViper);
                SortConstructionStates(ref _lZuZergling);
                SortAliveSinceStates(ref _lZuLocust);
                SortAliveSinceStates(ref _lZuFlyingLocust);
                SortAliveSinceStates(ref _lZuChangeling);
                SortAliveSinceStates(ref _lZuInfestedTerran);
                

                SortConstructionStates(ref _lZupAdrenalGlands);
                SortConstructionStates(ref _lZupAirArmor1);
                SortConstructionStates(ref _lZupAirArmor2);
                SortConstructionStates(ref _lZupAirArmor3);
                SortConstructionStates(ref _lZupAirWeapon1);
                SortConstructionStates(ref _lZupAirWeapon2);
                SortConstructionStates(ref _lZupAirWeapon3);
                SortConstructionStates(ref _lZupBurrow);
                SortConstructionStates(ref _lZupCentrifugalHooks);
                SortConstructionStates(ref _lZupChitinousPlating);
                SortConstructionStates(ref _lZupEnduringLocusts);
                SortConstructionStates(ref _lZupGlialReconstruction);
                SortConstructionStates(ref _lZupGroovedSpines);
                SortConstructionStates(ref _lZupGroundArmor1);
                SortConstructionStates(ref _lZupGroundArmor2);
                SortConstructionStates(ref _lZupGroundArmor3);
                SortConstructionStates(ref _lZupGroundMelee1);
                SortConstructionStates(ref _lZupGroundMelee2);
                SortConstructionStates(ref _lZupGroundMelee3);
                SortConstructionStates(ref _lZupGroundWeapon1);
                SortConstructionStates(ref _lZupGroundWeapon2);
                SortConstructionStates(ref _lZupGroundWeapon3);
                SortConstructionStates(ref _lZupMetabolicBoost);
                SortConstructionStates(ref _lZupMuscularAugments);
                SortConstructionStates(ref _lZupNeutralParasite);
                SortConstructionStates(ref _lZupPathoglenGlands);
                SortConstructionStates(ref _lZupPneumatizedCarapace);
                SortConstructionStates(ref _lZupTunnnelingClaws);
                SortConstructionStates(ref _lZupVentralSacs);

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