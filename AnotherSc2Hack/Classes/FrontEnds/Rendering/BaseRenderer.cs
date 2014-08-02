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
using Predefined;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    /// <summary>
    /// Baseclass which handles everything around the drawing of the content.
    /// Does the dirty work so you don't have to care about the basic "fuck up"
    /// </summary>
    public abstract partial class BaseRenderer : Form
    {
        #region Variables

        public long IterationsPerSeconds { get; set; }                          //Counts the iterations within a second

        private long _lTimesRefreshed;                                          //Dunno.. :D
        private Point _ptMousePosition = new Point(0, 0);                       //Position for the Moving of the Panel
        private Boolean _bDraw = true;
        private const Int32 SizeOfRectangle = 10;                               //Size for the corner- rectangles (when changing position)

        protected readonly MainHandler.MainHandler HMainHandler;                //Mainhandler - handles access to the Engine
        protected Stopwatch SwMainWatch = new Stopwatch();                      //Stopwatch for Debugging and speed- tests
        protected DateTime DtBegin = DateTime.Now;                              //First Datetime to get the Delta between the begin and end [TopMost]
        protected DateTime DtSecond = DateTime.Now;                             //Second Datetime to get the Delta between the begin and end [TopMost]
        protected Preferences PSettings;                                        //Preferences directly..
        protected Boolean BSurpressForeground;
        protected Boolean BChangingPosition;
        protected Boolean BMouseDown;
        protected Boolean BSetSize;
        protected Boolean BToggleSize;
        protected Boolean BSetPosition;
        protected Boolean BTogglePosition;
        protected String StrBackupChatbox = String.Empty;
        protected String StrBackupSizeChatbox = String.Empty;


        #region UnitCounter - Count all objects per player

        #region Terran

        protected List<PredefinedData.UnitCount> _lTbCommandCenter = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbPlanetaryFortress = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbOrbitalCommand = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbBarracks = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbSupply = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbEbay = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbRefinery = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbBunker = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbTurrent = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbSensorTower = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbFactory = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbStarport = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbArmory = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbGhostAcademy = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbFusionCore = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbTechlab = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbReactor = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTbAutoTurret = new List<PredefinedData.UnitCount>();


        protected List<PredefinedData.UnitCount> _lTuScv = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuMule = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuMarine = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuMarauder = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuReaper = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuGhost = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuWidowMine = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuSiegetank = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuHellion = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuHellbat = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuThor = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuViking = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuBanshee = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuMedivac = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuBattlecruiser = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuRaven = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuPointDefenseDrone = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTuNuke = new List<PredefinedData.UnitCount>();


        protected List<PredefinedData.UnitCount> _lTupInfantryWeapon1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupInfantryWeapon2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupInfantryWeapon3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupInfantryArmor1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupInfantryArmor2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupInfantryArmor3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupVehicleWeapon1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupVehicleWeapon2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupVehicleWeapon3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupShipWeapon1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupShipWeapon2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupShipWeapon3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupVehicleShipPlanting1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupVehicleShipPlanting2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupVehicleShipPlanting3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupNeosteelFrame = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupStructureArmor = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupHighSecAutoTracking = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupConcussiveShells = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupCombatShields = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupStim = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupBlueFlame = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupDrillingClaws = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupTransformationServos = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupCloakingField = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupCaduceusReactor = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupDurableMaterials = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupCorvidReactor = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupWeaponRefit = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupBehemothReactor = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupPersonalCloak = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupMoebiusReactor = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupPlanetaryFortress = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lTupOrbitalCommand = new List<PredefinedData.UnitCount>();



        #endregion

        #region Protoss

        protected List<PredefinedData.UnitCount> _lPbNexus = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPbPylon = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPbGateway = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPbForge = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPbCybercore = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPbWarpgate = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPbCannon = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPbAssimilator = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPbTwilight = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPbStargate = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPbRobotics = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPbRoboticsSupport = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPbFleetbeacon = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPbTemplarArchives = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPbDarkshrine = new List<PredefinedData.UnitCount>();

        protected List<PredefinedData.UnitCount> _lPuProbe = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuStalker = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuZealot = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuSentry = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuDt = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuHt = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuMothership = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuMothershipcore = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuArchon = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuWarpprism = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuObserver = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuColossus = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuImmortal = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuPhoenix = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuVoidray = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuOracle = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuTempest = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuCarrier = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPuForcefield = new List<PredefinedData.UnitCount>();

        protected List<PredefinedData.UnitCount> _lPupGroundWeapon1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupGroundWeapon2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupGroundWeapon3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupGroundArmor1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupGroundArmor2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupGroundArmor3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupShield1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupShield2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupShield3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupAirWeapon1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupAirWeapon2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupAirWeapon3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupAirArmor1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupAirArmor2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupAirArmor3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupStorm = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupWarpGate = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupBlink = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupCharge = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupAnionPulseCrystal = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupGraviticBooster = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupGraviticDrive = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupGravitonCatapult = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lPupExtendedThermalLance = new List<PredefinedData.UnitCount>();

        #endregion

        #region Zerg

        protected List<PredefinedData.UnitCount> _lZbHatchery = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbLair = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbHive = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbSpawningpool = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbRoachwarren = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbCreepTumor = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbEvochamber = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbSpine = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbSpore = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbBanelingnest = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbExtractor = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbHydraden = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbSpire = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbNydusbegin = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbNydusend = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbUltracavern = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbGreaterspire = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZbInfestationpit = new List<PredefinedData.UnitCount>();

        protected List<PredefinedData.UnitCount> _lZuLarva = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuDrone = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuOverlord = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuZergling = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuBaneling = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuBanelingCocoon = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuBroodlordCocoon = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuRoach = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuHydra = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuInfestor = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuQueen = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuOverseer = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuOverseerCocoon = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuMutalisk = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuCorruptor = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuBroodlord = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuUltralisk = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuSwarmhost = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuViper = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZuLocust = new List<PredefinedData.UnitCount>();

        protected List<PredefinedData.UnitCount> _lZupAirWeapon1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupAirWeapon2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupAirWeapon3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupAirArmor1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupAirArmor2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupAirArmor3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupGroundWeapon1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupGroundWeapon2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupGroundWeapon3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupGroundArmor1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupGroundArmor2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupGroundArmor3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupGroundMelee1 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupGroundMelee2 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupGroundMelee3 = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupMetabolicBoost = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupAdrenalGlands = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupCentrifugalHooks = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupChitinousPlating = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupEnduringLocusts = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupGlialReconstruction = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupGroovedSpines = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupMuscularAugments = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupNeutralParasite = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupPathoglenGlands = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupPneumatizedCarapace = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupTunnnelingClaws = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupVentralSacs = new List<PredefinedData.UnitCount>();
        protected List<PredefinedData.UnitCount> _lZupBurrow = new List<PredefinedData.UnitCount>();



        #endregion

        #region Images

        #region Terran

        #region Units

        protected readonly Image _imgTuScv = Properties.Resources.tu_scv,
                               _imgTuMule = Properties.Resources.tu_Mule,
                               _imgTuMarine = Properties.Resources.tu_marine,
                               _imgTuMarauder = Properties.Resources.tu_marauder,
                               _imgTuReaper = Properties.Resources.tu_reaper,
                               _imgTuGhost = Properties.Resources.tu_ghost,
                               _imgTuHellion = Properties.Resources.tu_hellion,
                               _imgTuHellbat = Properties.Resources.tu_battlehellion,
                               _imgTuSiegetank = Properties.Resources.tu_tank,
                               _imgTuThor = Properties.Resources.tu_thor,
                               _imgTuWidowMine = Properties.Resources.tu_widowmine,
                               _imgTuViking = Properties.Resources.tu_vikingAir,
                               _imgTuRaven = Properties.Resources.tu_raven,
                               _imgTuMedivac = Properties.Resources.tu_medivac,
                               _imgTuBattlecruiser = Properties.Resources.tu_battlecruiser,
                               _imgTuBanshee = Properties.Resources.tu_banshee,
                               _imgTuPointDefenseDrone = Properties.Resources.tu_pdd,
                               _imgTuNuke = Properties.Resources.Tu_Nuke;

        #endregion

        #region Buildings

        protected readonly Image _imgTbCc = Properties.Resources.tb_cc,
                               _imgTbOc = Properties.Resources.tb_oc,
                               _imgTbPf = Properties.Resources.tb_pf,
                               _imgTbSupply = Properties.Resources.tb_supply,
                               _imgTbRefinery = Properties.Resources.tb_refinery,
                               _imgTbBarracks = Properties.Resources.tb_rax,
                               _imgTbEbay = Properties.Resources.tb_ebay,
                               _imgTbTurrent = Properties.Resources.tb_turret,
                               _imgTbSensorTower = Properties.Resources.tb_sensor,
                               _imgTbFactory = Properties.Resources.tb_fax,
                               _imgTbStarport = Properties.Resources.tb_starport,
                               _imgTbGhostacademy = Properties.Resources.tb_ghostacademy,
                               _imgTbArmory = Properties.Resources.tb_Armory,
                               _imgTbBunker = Properties.Resources.tb_bunker,
                               _imgTbFusioncore = Properties.Resources.tb_fusioncore,
                               _imgTbTechlab = Properties.Resources.tb_techlab,
                               _imgTbReactor = Properties.Resources.tb_reactor,
                               _imgTbAutoTurret = Properties.Resources.tb_autoturret;

        #endregion

        #region Upgrades

        protected readonly Image _imgTupStim = Properties.Resources.Tup_Stim,
                               _imgTupConcussiveShells = Properties.Resources.Tup_ConcussiveShells,
                               _imgTupCombatShields = Properties.Resources.Tup_CombatShields,
                               _imgTupPersonalCloak = Properties.Resources.Tup_PersonalCloak,
                               _imgTupMoebiusReactor = Properties.Resources.Tup_MoebiusReactor,
                               _imgTupBlueFlame = Properties.Resources.Tup_BlueFlame,
                               _imgTupTransformatorServos = Properties.Resources.Tup_TransformationServos,
                               _imgTupDrillingClaws = Properties.Resources.Tup_DrillingClaws,
                               _imgTupCloakingField = Properties.Resources.Tup_CloakingField,
                               _imgTupDurableMaterials = Properties.Resources.Tup_DurableMaterials,
                               _imgTupCaduceusReactor = Properties.Resources.Tup_CaduceusReactor,
                               _imgTupCorvidReactor = Properties.Resources.Tup_CorvidReactor,
                               _imgTupBehemothReacot = Properties.Resources.Tup_BehemothReactor,
                               _imgTupWeaponRefit = Properties.Resources.Tup_WeaponRefit,
                               _imgTupInfantryWeapon1 = Properties.Resources.Tup_InfantyWeapon1,
                               _imgTupInfantryWeapon2 = Properties.Resources.Tup_InfantyWeapon2,
                               _imgTupInfantryWeapon3 = Properties.Resources.Tup_InfantyWeapon3,
                               _imgTupInfantryArmor1 = Properties.Resources.Tup_InfantyArmor1,
                               _imgTupInfantryArmor2 = Properties.Resources.Tup_InfantyArmor2,
                               _imgTupInfantryArmor3 = Properties.Resources.Tup_InfantyArmor3,
                               _imgTupVehicleWeapon1 = Properties.Resources.Tup_VehicleWeapon1,
                               _imgTupVehicleWeapon2 = Properties.Resources.Tup_VehicleWeapon2,
                               _imgTupVehicleWeapon3 = Properties.Resources.Tup_VehicleWeapon3,
                               _imgTupShipWeapon1 = Properties.Resources.Tup_ShipWeapon1,
                               _imgTupShipWeapon2 = Properties.Resources.Tup_ShipWeapon2,
                               _imgTupShipWeapon3 = Properties.Resources.Tup_ShipWeapon3,
                               _imgTupVehicleShipPlanting1 = Properties.Resources.Tup_VehicleShipPlanting1,
                               _imgTupVehicleShipPlanting2 = Properties.Resources.Tup_VehicleShipPlanting2,
                               _imgTupVehicleShipPlanting3 = Properties.Resources.Tup_VehicleShipPlanting3,
                               _imgTupHighSecAutoTracking = Properties.Resources.Tup_HighSecAutotracking,
                               _imgTupStructureArmor = Properties.Resources.Tup_StructureArmor,
                               _imgTupNeosteelFrame = Properties.Resources.Tup_NeosteelFrame;

        #endregion

        #endregion

        #region Protoss

        #region Units

        protected readonly Image _imgPuProbe = Properties.Resources.pu_probe,
                               _imgPuZealot = Properties.Resources.pu_Zealot,
                               _imgPuStalker = Properties.Resources.pu_Stalker,
                               _imgPuSentry = Properties.Resources.pu_sentry,
                               _imgPuDarkTemplar = Properties.Resources.pu_DarkTemplar,
                               _imgPuHighTemplar = Properties.Resources.pu_ht,
                               _imgPuColossus = Properties.Resources.pu_Colossus,
                               _imgPuImmortal = Properties.Resources.pu_immortal,
                               _imgPuWapprism = Properties.Resources.pu_warpprism,
                               _imgPuObserver = Properties.Resources.pu_Observer,
                               _imgPuOracle = Properties.Resources.pu_oracle,
                               _imgPuTempest = Properties.Resources.pu_tempest,
                               _imgPuPhoenix = Properties.Resources.pu_pheonix,
                               _imgPuVoidray = Properties.Resources.pu_Voidray,
                               _imgPuCarrier = Properties.Resources.pu_carrier,
                               _imgPuMothershipcore = Properties.Resources.pu_mothershipcore,
                               _imgPuMothership = Properties.Resources.pu_Mothership,
                               _imgPuArchon = Properties.Resources.pu_Archon,
                               _imgPuForceField = Properties.Resources.PuForceField;

        #endregion

        #region Buildings

        protected readonly Image _imgPbNexus = Properties.Resources.pb_Nexus,
                               _imgPbPylon = Properties.Resources.pb_Pylon,
                               _imgPbGateway = Properties.Resources.pb_gateway,
                               _imgPbWarpgate = Properties.Resources.pb_warpgate,
                               _imgPbAssimilator = Properties.Resources.pb_Assimilator,
                               _imgPbForge = Properties.Resources.pb_forge,
                               _imgPbCannon = Properties.Resources.pb_Cannon,
                               _imgPbCybercore = Properties.Resources.pb_cybercore,
                               _imgPbStargate = Properties.Resources.pb_stargate,
                               _imgPbRobotics = Properties.Resources.pb_robotics,
                               _imgPbRoboticsSupport = Properties.Resources.pb_roboticssupport,
                               _imgPbTwillightCouncil = Properties.Resources.pb_twillightCouncil,
                               _imgPbDarkShrine = Properties.Resources.pb_DarkShrine,
                               _imgPbTemplarArchives = Properties.Resources.pb_templararchives,
                               _imgPbFleetBeacon = Properties.Resources.pb_FleetBeacon;

        #endregion

        #region Upgrades

        protected readonly Image _imgPupGroundWeapon1 = Properties.Resources.Pup_GroundW1,
                               _imgPupGroundWeapon2 = Properties.Resources.Pup_GroundW2,
                               _imgPupGroundWeapon3 = Properties.Resources.Pup_GroundW3,
                               _imgPupGroundArmor1 = Properties.Resources.Pup_GroundA1,
                               _imgPupGroundArmor2 = Properties.Resources.Pup_GroundA2,
                               _imgPupGroundArmor3 = Properties.Resources.Pup_GroundA3,
                               _imgPupShield1 = Properties.Resources.Pup_S1,
                               _imgPupShield2 = Properties.Resources.Pup_S2,
                               _imgPupShield3 = Properties.Resources.Pup_S3,
                               _imgPupAirWeapon1 = Properties.Resources.Pup_AirW1,
                               _imgPupAirWeapon2 = Properties.Resources.Pup_AirW2,
                               _imgPupAirWeapon3 = Properties.Resources.Pup_AirW3,
                               _imgPupAirArmor1 = Properties.Resources.Pup_AirA1,
                               _imgPupAirArmor2 = Properties.Resources.Pup_AirA2,
                               _imgPupAirArmor3 = Properties.Resources.Pup_AirA3,
                               _imgPupBlink = Properties.Resources.Pup_Blink,
                               _imgPupCharge = Properties.Resources.Pup_Charge,
                               _imgPupGraviticBooster = Properties.Resources.Pup_GraviticBoosters,
                               _imgPupGraviticDrive = Properties.Resources.Pup_GraviticDrive,
                               _imgPupExtendedThermalLance = Properties.Resources.Pup_ExtendedThermalLance,
                               _imgPupAnionPulseCrystals = Properties.Resources.Pup_AnionPulseCrystals,
                               _imgPupGravitonCatapult = Properties.Resources.Pup_GravitonCatapult,
                               _imgPupWarpGate = Properties.Resources.Pup_Warpgate,
                               _imgPupStorm = Properties.Resources.Pup_Storm;

        #endregion

        #endregion

        #region Zerg

        #region Units

        protected readonly Image _imgZuDrone = Properties.Resources.zu_drone,
                               _imgZuLarva = Properties.Resources.zu_larva,
                               _imgZuZergling = Properties.Resources.zu_zergling,
                               _imgZuBaneling = Properties.Resources.zu_baneling,
                               _imgZuBanelingCocoon = Properties.Resources.zu_banelingcocoon,
                               _imgZuRoach = Properties.Resources.zu_roach,
                               _imgZuHydra = Properties.Resources.zu_hydra,
                               _imgZuMutalisk = Properties.Resources.zu_mutalisk,
                               _imgZuUltra = Properties.Resources.zu_ultra,
                               _imgZuViper = Properties.Resources.zu_viper,
                               _imgZuSwarmhost = Properties.Resources.zu_swarmhost,
                               _imgZuInfestor = Properties.Resources.zu_infestor,
                               _imgZuCorruptor = Properties.Resources.zu_corruptor,
                               _imgZuBroodlord = Properties.Resources.zu_broodlord,
                               _imgZuBroodlordCocoon = Properties.Resources.zu_broodlordcocoon,
                               _imgZuQueen = Properties.Resources.zu_queen,
                               _imgZuOverlord = Properties.Resources.zu_overlord,
                               _imgZuOverseer = Properties.Resources.zu_overseer,
                               _imgZuOvserseerCocoon = Properties.Resources.zu_overseercocoon,
                               _imgZuLocust = Properties.Resources.zu_locust;

        #endregion

        #region Buildings

        protected readonly Image _imgZbHatchery = Properties.Resources.zb_hatchery,
                               _imgZbLair = Properties.Resources.zb_lair,
                               _imgZbHive = Properties.Resources.zb_hive,
                               _imgZbCreepTumor = Properties.Resources.Zb_Creep_Tumor,
                               _imgZbSpawningpool = Properties.Resources.zb_spawningpool,
                               _imgZbExtractor = Properties.Resources.zb_extactor,
                               _imgZbEvochamber = Properties.Resources.zb_evochamber,
                               _imgZbSpinecrawler = Properties.Resources.zb_spine,
                               _imgZbSporecrawler = Properties.Resources.zb_spore,
                               _imgZbRoachwarren = Properties.Resources.zb_roachwarren,
                               _imgZbGreaterspire = Properties.Resources.zb_greaterspire,
                               _imgZbSpire = Properties.Resources.zb_spire,
                               _imgZbNydusNetwork = Properties.Resources.zb_nydusnetwork,
                               _imgZbNydusWorm = Properties.Resources.zb_nydusworm,
                               _imgZbHydraden = Properties.Resources.zb_hydraden,
                               _imgZbInfestationpit = Properties.Resources.zb_infestationpit,
                               _imgZbUltracavern = Properties.Resources.zb_ultracavery,
                               _imgZbBanelingnest = Properties.Resources.zb_banelingnest;

        #endregion

        #region Upgrades

        protected readonly Image _imgZupAirWeapon1 = Properties.Resources.Zup_AirW1,
                               _imgZupAirWeapon2 = Properties.Resources.Zup_AirW2,
                               _imgZupAirWeapon3 = Properties.Resources.Zup_AirW3,
                               _imgZupAirArmor1 = Properties.Resources.Zup_AirA1,
                               _imgZupAirArmor2 = Properties.Resources.Zup_AirA2,
                               _imgZupAirArmor3 = Properties.Resources.Zup_AirA3,
                               _imgZupGroundWeapon1 = Properties.Resources.Zup_GroundW1,
                               _imgZupGroundWeapon2 = Properties.Resources.Zup_GroundW2,
                               _imgZupGroundWeapon3 = Properties.Resources.Zup_GroundW3,
                               _imgZupGroundArmor1 = Properties.Resources.Zup_GroundA1,
                               _imgZupGroundArmor2 = Properties.Resources.Zup_GroundA2,
                               _imgZupGroundArmor3 = Properties.Resources.Zup_GroundA3,
                               _imgZupGroundMelee1 = Properties.Resources.Zup_GroundM1,
                               _imgZupGroundMelee2 = Properties.Resources.Zup_GroundM2,
                               _imgZupGroundMelee3 = Properties.Resources.Zup_GroundM3,
                               _imgZupBurrow = Properties.Resources.Zup_Burrow,
                               _imgZupAdrenalGlands = Properties.Resources.Zup_AdrenalGlands,
                               _imgZupCentrifugalHooks = Properties.Resources.Zup_CentrifugalHooks,
                               _imgZupChitinousPlating = Properties.Resources.Zup_ChitinousPlating,
                               _imgZupEnduringLocusts = Properties.Resources.Zup_EnduringLocusts,
                               _imgZupGlialReconstruction = Properties.Resources.Zup_GlialReconstruction,
                               _imgZupGroovedSpines = Properties.Resources.Zup_GroovedSpines,
                               _imgZupMetabolicBoost = Properties.Resources.Zup_MetabolicBoost,
                               _imgZupMuscularAugments = Properties.Resources.Zup_MuscularAugments,
                               _imgZupNeutralParasite = Properties.Resources.Zup_NeutralParasite,
                               _imgZupPathoglenGlands = Properties.Resources.Zup_PathogenGlands,
                               _imgZupPneumatizedCarapace = Properties.Resources.Zup_PneumatizedCarapace,
                               _imgZupTunnelingClaws = Properties.Resources.Zup_TunnelingClaws,
                               _imgZupVentrallSacs = Properties.Resources.Zup_VentralSacs;

        #endregion

        #endregion

        #region Other

        protected readonly Image _imgSpeedArrow = Properties.Resources.Speed_Arrow;

        #endregion

        #endregion

        #endregion

        #endregion

        #region Getter/ Setter

        public Boolean IsDestroyed { get; set; }
        public PredefinedData.CustomWindowStyles SetWindowStyle { get; set; }
        public Boolean IsHidden { get; private set; }
        public Boolean IsAllowedToClose { get; set; }
        

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRenderer"/> class.
        /// </summary>
        /// <param name="hnd">The handle to the MainHandle (to get data like GameInfo or Preferences and direct Form- control).</param>
        protected BaseRenderer(MainHandler.MainHandler hnd)
        {
            HMainHandler = hnd;

            PSettings = HMainHandler.PSettings;


            InitCode();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes the code.
        /// It's just there to reduce the amount of codelines. 
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
        /// Changes the position of the Form based on mouse- position
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
        /// Sets variables to finalize the re- position/ -sizing.
        /// Also calls MouseUpTransferData()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_MouseUp(object sender, MouseEventArgs e)
        {
            InteropCalls.SetForegroundWindow(HMainHandler.PSc2Process.MainWindowHandle);

            MouseUpTransferData();

            BChangingPosition = false;
            BMouseDown = false;
        }

        /// <summary>
        /// Changes the state of BMouseDown (to allow reposition)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_MouseDown(object sender, MouseEventArgs e)
        {
            _ptMousePosition = new Point(e.X, e.Y);

            BMouseDown = true;
        }

        /// <summary>
        /// Handles the resizing using the mouse- wheel.
        /// Makes a precheck and finally calls MouseWheelTransferData(e).
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
        /// Changes the statte of IsDestroyed to true.
        /// Also calls ChangeForecolorOfButton(Color.Red) to color the button of a specific Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsDestroyed = true;

            ChangeForecolorOfButton(Color.Red);
        }

        /// <summary>
        /// The Form_Load is there to load some basic stuff like Color and Timer- fixures.
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

            ChangeForecolorOfButton(Color.Green);


            tmrRefreshGraphic.Enabled = true;
        }

        /// <summary>
        /// Refreshes the Foreground (in case it failed somehow)
        /// No idea why I use this, lol.
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
        /// Gets the Keyboard- input from SC2's chatbox.
        /// </summary>
        private void GetKeyboardInput()
        {
            var sInput = HMainHandler.GInformation.Gameinfo.ChatInput;

            if (sInput != StrBackupChatbox)
                BTogglePosition = true;

            if (sInput != StrBackupSizeChatbox)
                BToggleSize = true;


            StrBackupChatbox = sInput;
            StrBackupSizeChatbox = sInput;
        }

        /// <summary>
        /// Change the window- style (to make it click- and non-clickable)
        /// </summary>
        private void ChangeWindowStyle()
        {
            if (SetWindowStyle.Equals(PredefinedData.CustomWindowStyles.Clickable))
            {
                BChangingPosition = true;
                BSurpressForeground = true;
                HelpFunctions.SetWindowStyle(Handle, PredefinedData.CustomWindowStyles.Clickable);
            }

            else if (SetWindowStyle.Equals(PredefinedData.CustomWindowStyles.NotClickable))
            {
                BSurpressForeground = false;

                if (!BMouseDown)
                    BChangingPosition = false;
                HelpFunctions.SetWindowStyle(Handle, PredefinedData.CustomWindowStyles.NotClickable);
            }
        }

        /// <summary>
        /// The basic Timermethod to re- draw and gather new data like the Chatbox- strings.
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


            if (HelpFunctions.HotkeysPressed(PSettings.GlobalChangeSizeAndPosition))
                SetWindowStyle = PredefinedData.CustomWindowStyles.Clickable;

            else if (FormBorderStyle != FormBorderStyle.None)
                SetWindowStyle = PredefinedData.CustomWindowStyles.Clickable;


            else
                SetWindowStyle = PredefinedData.CustomWindowStyles.NotClickable;

            ChangeWindowStyle();


            GetKeyboardInput();
            AdjustPanelPosition();
            AdjustPanelSize();

            /* Reset settings */
            PSettings = HMainHandler.PSettings;

            /* Refresh Top- Most */
            if (
                HMainHandler.PSc2Process != null && HMainHandler.PSc2Process.ProcessName.Length > 0 &&
                InteropCalls.GetForegroundWindow().Equals(HMainHandler.PSc2Process.MainWindowHandle))
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

        #endregion

        #region Protected abstract Methods (Form specific)

        /// <summary>
        /// Draws the stuff you want to have drawn
        /// Using this method so you don't need to override the OnPaint- method (cuz that would cause more fuck-up)
        /// </summary>
        /// <param name="g">Prebuffered graphics.. D:</param>
        protected abstract void Draw(BufferedGraphics g);

        /// <summary>
        /// Load Form- specific data in the initialization of the Form.
        /// This gets called within the Form_Load!
        /// </summary>
        protected abstract void LoadSpecificData();

        /// <summary>
        /// Changes the color of a button on a specific Form.
        /// </summary>
        /// <param name="cl"></param>
        protected abstract void ChangeForecolorOfButton(Color cl);

        /// <summary>
        /// Defines what happens after the resizing.
        /// Usually some kind of datatransfer with the preferences.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void BaseRenderer_ResizeEnd(object sender, EventArgs e);

        /// <summary>
        /// Adjust the panelsize and change the settings for Form X.
        /// </summary>
        protected abstract void AdjustPanelSize();

        /// <summary>
        /// Adjust the panelposition and change the settings for Form X.
        /// </summary>
        protected abstract void AdjustPanelPosition();

        /// <summary>
        /// Load the preferences for Form X into the Controls (location, size)
        /// </summary>
        protected abstract void LoadPreferencesIntoControls();

        /// <summary>
        /// Transfers Mousedata (position) into the specific Form
        /// </summary>
        protected abstract void MouseUpTransferData();

        /// <summary>
        /// Transfers Mousedata (size) into the specific Form
        /// </summary>
        /// <param name="e"></param>
        protected abstract void MouseWheelTransferData(MouseEventArgs e);


        #endregion

        #region Protected Methods

        /// <summary>
        /// Checks if gameheart.
        /// </summary>
        /// <param name="p">The player</param>
        /// <returns>Is the player is gameheartish.</returns>
        protected Boolean CheckIfGameheart(PredefinedData.PlayerStruct p)
        {
            if (p.CurrentBuildings == 0 &&
                p.Status.Equals(PredefinedData.PlayerStatus.Playing) &&
                p.SupplyMax == 0 &&
                p.SupplyMin == 0 &&
                p.Worker == 0 &&
                p.Minerals == 0 &&
                p.Gas == 0)
                return true;

            return false;
        }

        /// <summary>
        /// The override OnPaint- method to draw the content and more imporantly: the basic stuff around the panels.
        /// Since it's always the same, it won't get overridden!
        /// </summary>
        /// <param name="e">The letter e - huehue</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if ((DateTime.Now - DtSecond).Seconds >= 1)
            {
                //Debug.WriteLine("The OnPaint- loop was refreshed " + lTimesRefreshed + " times in a second!");
                IterationsPerSeconds = _lTimesRefreshed;
                _lTimesRefreshed = 0;
                DtSecond = DateTime.Now;
            }
            _lTimesRefreshed++;

            base.OnPaint(e);



            //_swMainWatch.Reset();
            //_swMainWatch.Start();

            var context = new BufferedGraphicsContext();
            context.MaximumBuffer = ClientSize;

            using (BufferedGraphics buffer = context.Allocate(e.Graphics, ClientRectangle))
            {
                buffer.Graphics.Clear(BackColor);
                buffer.Graphics.CompositingMode = CompositingMode.SourceOver;
                buffer.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
                buffer.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                buffer.Graphics.SmoothingMode = SmoothingMode.HighSpeed;

                if (HMainHandler.GInformation.Gameinfo.IsIngame)
                {
                    if (PSettings.GlobalDrawOnlyInForeground && !BSurpressForeground)
                    {
                        _bDraw = InteropCalls.GetForegroundWindow().Equals(HMainHandler.PSc2Process.MainWindowHandle);
                    }

                    else
                    {
                        _bDraw = true;

                        if (InteropCalls.GetForegroundWindow().Equals(HMainHandler.PSc2Process.MainWindowHandle))
                        {
                            InteropCalls.SetActiveWindow(Handle);
                        }
                    }

                    if (_bDraw)
                    {
                        Draw(buffer);

                        #region Draw a Rectangle around the Panels (When changing position)

                        /* Draw a final bound around the panel */
                        if (BChangingPosition || BSetPosition || BSetSize)
                        {


                            /* Simple border */
                            buffer.Graphics.DrawRectangle(Constants.PYellowGreen2,
                                                        1,
                                                        1,
                                                        Width - 2,
                                                        Height - 2);

                            /* Draw some filled frectangles to make the resizing easier */
                            buffer.Graphics.FillRectangle(Brushes.YellowGreen,
                                                          Width - SizeOfRectangle, 0, SizeOfRectangle,
                                                          SizeOfRectangle);

                            buffer.Graphics.FillRectangle(Brushes.YellowGreen,
                                                          0, Height - SizeOfRectangle, SizeOfRectangle,
                                                          SizeOfRectangle);

                            buffer.Graphics.FillRectangle(Brushes.YellowGreen,
                                                          Width - SizeOfRectangle, Height - SizeOfRectangle,
                                                          SizeOfRectangle, SizeOfRectangle);

                            /* Draw current size */
                            buffer.Graphics.DrawString(
                                Width.ToString(CultureInfo.InvariantCulture) + "x" +
                                Height.ToString(CultureInfo.InvariantCulture) + " - [X=" +
                            Location.X.ToString(CultureInfo.InvariantCulture) + "; Y=" + Location.Y.ToString(CultureInfo.InvariantCulture) + "]",
                                new Font("Arial", 8, FontStyle.Regular), Brushes.YellowGreen, 2, 2);
                        }

                        #endregion
                    }

                }



                buffer.Render();
            }

            context.Dispose();

            //_swMainWatch.Stop();
            //Debug.WriteLine("Time to execute DrawingMethods:" + 1000000 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency + " µs");
        }

        /// <summary>
        /// Override the FormClosing to stop the user from actually destroying the window.
        /// The BaseRenderer is designed to never die.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Hide();

            if (!IsAllowedToClose)
                e.Cancel = true;


            base.OnFormClosing(e);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Override Hide- Method to change the IsHidden property [true].
        /// </summary>
        public new void Hide()
        {
            IsHidden = true;

            tmrRefreshGraphic.Enabled = false;

            ChangeForecolorOfButton(Color.Red);

            base.Hide();
        }

        /// <summary>
        /// Override Show- Method to change the IsHidden property [false].
        /// </summary>
        public new void Show()
        {
            IsHidden = false;

            tmrRefreshGraphic.Enabled = true;

            ChangeForecolorOfButton(Color.Green);

            base.Show();
        }

        /// <summary>
        /// Toggles the Show/ Hide based on the state of IsHidden
        /// </summary>
        public void ToggleShowHide()
        {
            if (IsHidden)
                Show();

            else
                Hide();
        }

        /// <summary>
        /// Hide/ Show Form based on a boolean.
        /// </summary>
        /// <param name="show">Hide or Show</param>
        public void ToggleShowHide(Boolean show)
        {
            if (show)
                Show();

            else
                Hide();
        }

        /// <summary>
        /// Simply reloads the Preferences and puts them into the controls
        /// </summary>
        public void ReloadPreferencesIntoControls()
        {
            LoadPreferencesIntoControls();
        }

        

        #endregion

        protected void CountUnits()
        {
#if !DEBUG
            try
            {
#endif
                if (!HMainHandler.GInformation.Gameinfo.IsIngame ||
                    HMainHandler.GInformation.Player.Count <= 0 ||
                    HMainHandler.GInformation.Unit.Count <= 0)
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

                if (_lZuZergling.Count > 0)
                    _lZuZergling.Clear();

                if (_lZuOverseerCocoon.Count > 0)
                    _lZuOverseerCocoon.Clear();


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

                #endregion

                #endregion

                #region Setup for the dummy- values

                for (var i = 0; i < HMainHandler.GInformation.Player.Count; i++)
                {
                    #region Terran

                    #region Units

                    _lTuScv.Add(new PredefinedData.UnitCount());
                    _lTuBanshee.Add(new PredefinedData.UnitCount());
                    _lTuBattlecruiser.Add(new PredefinedData.UnitCount());
                    _lTuGhost.Add(new PredefinedData.UnitCount());
                    _lTuHellbat.Add(new PredefinedData.UnitCount());
                    _lTuHellion.Add(new PredefinedData.UnitCount());
                    _lTuMarauder.Add(new PredefinedData.UnitCount());
                    _lTuMarine.Add(new PredefinedData.UnitCount());
                    _lTuMedivac.Add(new PredefinedData.UnitCount());
                    _lTuMule.Add(new PredefinedData.UnitCount());
                    _lTuNuke.Add(new PredefinedData.UnitCount());
                    _lTuPointDefenseDrone.Add(new PredefinedData.UnitCount());
                    _lTuRaven.Add(new PredefinedData.UnitCount());
                    _lTuReaper.Add(new PredefinedData.UnitCount());
                    _lTuSiegetank.Add(new PredefinedData.UnitCount());
                    _lTuThor.Add(new PredefinedData.UnitCount());
                    _lTuViking.Add(new PredefinedData.UnitCount());
                    _lTuWidowMine.Add(new PredefinedData.UnitCount());

                    #endregion

                    #region Buildings

                    _lTbArmory.Add(new PredefinedData.UnitCount());
                    _lTbAutoTurret.Add(new PredefinedData.UnitCount());
                    _lTbBarracks.Add(new PredefinedData.UnitCount());
                    _lTbBunker.Add(new PredefinedData.UnitCount());
                    _lTbCommandCenter.Add(new PredefinedData.UnitCount());
                    _lTbEbay.Add(new PredefinedData.UnitCount());
                    _lTbFactory.Add(new PredefinedData.UnitCount());
                    _lTbFusionCore.Add(new PredefinedData.UnitCount());
                    _lTbGhostAcademy.Add(new PredefinedData.UnitCount());
                    _lTbOrbitalCommand.Add(new PredefinedData.UnitCount());
                    _lTbPlanetaryFortress.Add(new PredefinedData.UnitCount());
                    _lTbReactor.Add(new PredefinedData.UnitCount());
                    _lTbRefinery.Add(new PredefinedData.UnitCount());
                    _lTbSensorTower.Add(new PredefinedData.UnitCount());
                    _lTbStarport.Add(new PredefinedData.UnitCount());
                    _lTbSupply.Add(new PredefinedData.UnitCount());
                    _lTbTechlab.Add(new PredefinedData.UnitCount());
                    _lTbTurrent.Add(new PredefinedData.UnitCount());

                    #endregion

                    #region Upgrades

                    _lTupBehemothReactor.Add(new PredefinedData.UnitCount());
                    _lTupBlueFlame.Add(new PredefinedData.UnitCount());
                    _lTupCaduceusReactor.Add(new PredefinedData.UnitCount());
                    _lTupCloakingField.Add(new PredefinedData.UnitCount());
                    _lTupCombatShields.Add(new PredefinedData.UnitCount());
                    _lTupConcussiveShells.Add(new PredefinedData.UnitCount());
                    _lTupCorvidReactor.Add(new PredefinedData.UnitCount());
                    _lTupDrillingClaws.Add(new PredefinedData.UnitCount());
                    _lTupDurableMaterials.Add(new PredefinedData.UnitCount());
                    _lTupHighSecAutoTracking.Add(new PredefinedData.UnitCount());
                    _lTupInfantryArmor1.Add(new PredefinedData.UnitCount());
                    _lTupInfantryArmor2.Add(new PredefinedData.UnitCount());
                    _lTupInfantryArmor3.Add(new PredefinedData.UnitCount());
                    _lTupInfantryWeapon1.Add(new PredefinedData.UnitCount());
                    _lTupInfantryWeapon2.Add(new PredefinedData.UnitCount());
                    _lTupInfantryWeapon3.Add(new PredefinedData.UnitCount());
                    _lTupMoebiusReactor.Add(new PredefinedData.UnitCount());
                    _lTupNeosteelFrame.Add(new PredefinedData.UnitCount());
                    _lTupOrbitalCommand.Add(new PredefinedData.UnitCount());
                    _lTupPersonalCloak.Add(new PredefinedData.UnitCount());
                    _lTupPlanetaryFortress.Add(new PredefinedData.UnitCount());
                    _lTupShipWeapon1.Add(new PredefinedData.UnitCount());
                    _lTupShipWeapon2.Add(new PredefinedData.UnitCount());
                    _lTupShipWeapon3.Add(new PredefinedData.UnitCount());
                    _lTupStim.Add(new PredefinedData.UnitCount());
                    _lTupStructureArmor.Add(new PredefinedData.UnitCount());
                    _lTupTransformationServos.Add(new PredefinedData.UnitCount());
                    _lTupVehicleShipPlanting1.Add(new PredefinedData.UnitCount());
                    _lTupVehicleShipPlanting2.Add(new PredefinedData.UnitCount());
                    _lTupVehicleShipPlanting3.Add(new PredefinedData.UnitCount());
                    _lTupVehicleWeapon1.Add(new PredefinedData.UnitCount());
                    _lTupVehicleWeapon2.Add(new PredefinedData.UnitCount());
                    _lTupVehicleWeapon3.Add(new PredefinedData.UnitCount());
                    _lTupWeaponRefit.Add(new PredefinedData.UnitCount());

                    #endregion

                    #endregion

                    #region Protoss

                    #region Units

                    _lPuArchon.Add(new PredefinedData.UnitCount());
                    _lPuCarrier.Add(new PredefinedData.UnitCount());
                    _lPuColossus.Add(new PredefinedData.UnitCount());
                    _lPuDt.Add(new PredefinedData.UnitCount());
                    _lPuHt.Add(new PredefinedData.UnitCount());
                    _lPuImmortal.Add(new PredefinedData.UnitCount());
                    _lPuMothership.Add(new PredefinedData.UnitCount());
                    _lPuMothershipcore.Add(new PredefinedData.UnitCount());
                    _lPuObserver.Add(new PredefinedData.UnitCount());
                    _lPuOracle.Add(new PredefinedData.UnitCount());
                    _lPuPhoenix.Add(new PredefinedData.UnitCount());
                    _lPuProbe.Add(new PredefinedData.UnitCount());
                    _lPuSentry.Add(new PredefinedData.UnitCount());
                    _lPuStalker.Add(new PredefinedData.UnitCount());
                    _lPuTempest.Add(new PredefinedData.UnitCount());
                    _lPuVoidray.Add(new PredefinedData.UnitCount());
                    _lPuWarpprism.Add(new PredefinedData.UnitCount());
                    _lPuZealot.Add(new PredefinedData.UnitCount());
                    _lPuForcefield.Add(new PredefinedData.UnitCount());

                    #endregion

                    #region Buildings

                    _lPbAssimilator.Add(new PredefinedData.UnitCount());
                    _lPbCannon.Add(new PredefinedData.UnitCount());
                    _lPbCybercore.Add(new PredefinedData.UnitCount());
                    _lPbDarkshrine.Add(new PredefinedData.UnitCount());
                    _lPbFleetbeacon.Add(new PredefinedData.UnitCount());
                    _lPbForge.Add(new PredefinedData.UnitCount());
                    _lPbGateway.Add(new PredefinedData.UnitCount());
                    _lPbNexus.Add(new PredefinedData.UnitCount());
                    _lPbPylon.Add(new PredefinedData.UnitCount());
                    _lPbRobotics.Add(new PredefinedData.UnitCount());
                    _lPbRoboticsSupport.Add(new PredefinedData.UnitCount());
                    _lPbStargate.Add(new PredefinedData.UnitCount());
                    _lPbTemplarArchives.Add(new PredefinedData.UnitCount());
                    _lPbTwilight.Add(new PredefinedData.UnitCount());
                    _lPbWarpgate.Add(new PredefinedData.UnitCount());

                    #endregion

                    #region Upgrades

                    _lPupBlink.Add(new PredefinedData.UnitCount());
                    _lPupCharge.Add(new PredefinedData.UnitCount());
                    _lPupExtendedThermalLance.Add(new PredefinedData.UnitCount());
                    _lPupGraviticBooster.Add(new PredefinedData.UnitCount());
                    _lPupGraviticDrive.Add(new PredefinedData.UnitCount());
                    _lPupGravitonCatapult.Add(new PredefinedData.UnitCount());
                    _lPupGroundArmor1.Add(new PredefinedData.UnitCount());
                    _lPupGroundArmor2.Add(new PredefinedData.UnitCount());
                    _lPupGroundArmor3.Add(new PredefinedData.UnitCount());
                    _lPupGroundWeapon1.Add(new PredefinedData.UnitCount());
                    _lPupGroundWeapon2.Add(new PredefinedData.UnitCount());
                    _lPupGroundWeapon3.Add(new PredefinedData.UnitCount());
                    _lPupShield1.Add(new PredefinedData.UnitCount());
                    _lPupShield2.Add(new PredefinedData.UnitCount());
                    _lPupShield3.Add(new PredefinedData.UnitCount());
                    _lPupStorm.Add(new PredefinedData.UnitCount());
                    _lPupWarpGate.Add(new PredefinedData.UnitCount());
                    _lPupAirArmor1.Add(new PredefinedData.UnitCount());
                    _lPupAirArmor2.Add(new PredefinedData.UnitCount());
                    _lPupAirArmor3.Add(new PredefinedData.UnitCount());
                    _lPupAirWeapon1.Add(new PredefinedData.UnitCount());
                    _lPupAirWeapon2.Add(new PredefinedData.UnitCount());
                    _lPupAirWeapon3.Add(new PredefinedData.UnitCount());
                    _lPupAnionPulseCrystal.Add(new PredefinedData.UnitCount());

                    #endregion

                    #endregion

                    #region Zerg

                    #region Units

                    _lZuBaneling.Add(new PredefinedData.UnitCount());
                    _lZuBanelingCocoon.Add(new PredefinedData.UnitCount());
                    _lZuBroodlord.Add(new PredefinedData.UnitCount());
                    _lZuBroodlordCocoon.Add(new PredefinedData.UnitCount());
                    _lZuCorruptor.Add(new PredefinedData.UnitCount());
                    _lZuDrone.Add(new PredefinedData.UnitCount());
                    _lZuHydra.Add(new PredefinedData.UnitCount());
                    _lZuInfestor.Add(new PredefinedData.UnitCount());
                    _lZuLarva.Add(new PredefinedData.UnitCount());
                    _lZuMutalisk.Add(new PredefinedData.UnitCount());
                    _lZuOverlord.Add(new PredefinedData.UnitCount());
                    _lZuOverseer.Add(new PredefinedData.UnitCount());
                    _lZuOverseerCocoon.Add(new PredefinedData.UnitCount());
                    _lZuQueen.Add(new PredefinedData.UnitCount());
                    _lZuRoach.Add(new PredefinedData.UnitCount());
                    _lZuSwarmhost.Add(new PredefinedData.UnitCount());
                    _lZuUltralisk.Add(new PredefinedData.UnitCount());
                    _lZuViper.Add(new PredefinedData.UnitCount());
                    _lZuZergling.Add(new PredefinedData.UnitCount());
                    _lZuLocust.Add(new PredefinedData.UnitCount());

                    #endregion

                    #region Buildings

                    _lZbBanelingnest.Add(new PredefinedData.UnitCount());
                    _lZbCreepTumor.Add(new PredefinedData.UnitCount());
                    _lZbEvochamber.Add(new PredefinedData.UnitCount());
                    _lZbExtractor.Add(new PredefinedData.UnitCount());
                    _lZbGreaterspire.Add(new PredefinedData.UnitCount());
                    _lZbHatchery.Add(new PredefinedData.UnitCount());
                    _lZbHive.Add(new PredefinedData.UnitCount());
                    _lZbHydraden.Add(new PredefinedData.UnitCount());
                    _lZbInfestationpit.Add(new PredefinedData.UnitCount());
                    _lZbLair.Add(new PredefinedData.UnitCount());
                    _lZbNydusbegin.Add(new PredefinedData.UnitCount());
                    _lZbNydusend.Add(new PredefinedData.UnitCount());
                    _lZbRoachwarren.Add(new PredefinedData.UnitCount());
                    _lZbSpawningpool.Add(new PredefinedData.UnitCount());
                    _lZbSpine.Add(new PredefinedData.UnitCount());
                    _lZbSpire.Add(new PredefinedData.UnitCount());
                    _lZbSpore.Add(new PredefinedData.UnitCount());
                    _lZbUltracavern.Add(new PredefinedData.UnitCount());

                    #endregion

                    #region Upgrades

                    _lZupAdrenalGlands.Add(new PredefinedData.UnitCount());
                    _lZupAirArmor1.Add(new PredefinedData.UnitCount());
                    _lZupAirArmor2.Add(new PredefinedData.UnitCount());
                    _lZupAirArmor3.Add(new PredefinedData.UnitCount());
                    _lZupAirWeapon1.Add(new PredefinedData.UnitCount());
                    _lZupAirWeapon2.Add(new PredefinedData.UnitCount());
                    _lZupAirWeapon3.Add(new PredefinedData.UnitCount());
                    _lZupBurrow.Add(new PredefinedData.UnitCount());
                    _lZupCentrifugalHooks.Add(new PredefinedData.UnitCount());
                    _lZupChitinousPlating.Add(new PredefinedData.UnitCount());
                    _lZupEnduringLocusts.Add(new PredefinedData.UnitCount());
                    _lZupGlialReconstruction.Add(new PredefinedData.UnitCount());
                    _lZupGroovedSpines.Add(new PredefinedData.UnitCount());
                    _lZupGroundArmor1.Add(new PredefinedData.UnitCount());
                    _lZupGroundArmor2.Add(new PredefinedData.UnitCount());
                    _lZupGroundArmor3.Add(new PredefinedData.UnitCount());
                    _lZupGroundMelee1.Add(new PredefinedData.UnitCount());
                    _lZupGroundMelee2.Add(new PredefinedData.UnitCount());
                    _lZupGroundMelee3.Add(new PredefinedData.UnitCount());
                    _lZupGroundWeapon1.Add(new PredefinedData.UnitCount());
                    _lZupGroundWeapon2.Add(new PredefinedData.UnitCount());
                    _lZupGroundWeapon3.Add(new PredefinedData.UnitCount());
                    _lZupMetabolicBoost.Add(new PredefinedData.UnitCount());
                    _lZupMuscularAugments.Add(new PredefinedData.UnitCount());
                    _lZupNeutralParasite.Add(new PredefinedData.UnitCount());
                    _lZupPathoglenGlands.Add(new PredefinedData.UnitCount());
                    _lZupPneumatizedCarapace.Add(new PredefinedData.UnitCount());
                    _lZupTunnnelingClaws.Add(new PredefinedData.UnitCount());
                    _lZupVentralSacs.Add(new PredefinedData.UnitCount());

                    #endregion

                    #endregion
                }

                /* Forcefield.. */
                _lPuForcefield.Add(new PredefinedData.UnitCount());

                #endregion

                for (var j = 0; j < HMainHandler.GInformation.Unit.Count; j++)
                {
                    var tmpUnit = HMainHandler.GInformation.Unit[j];

                    if (tmpUnit.IsHallucination)
                        continue;

                    #region Alive

                    if (tmpUnit.IsAlive)
                    {

                        #region Terran

                        #region Units

                        if (tmpUnit.Id == PredefinedData.UnitId.TuScv)
                            _lTuScv[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.TuMule)
                        {
                            _lTuMule[tmpUnit.Owner].UnitAmount += 1;
                            _lTuMule[tmpUnit.Owner].Id = PredefinedData.UnitId.TuMule;
                            _lTuMule[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince / 387328.0f));
                        }

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TuMarine)
                            _lTuMarine[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TuMarauder)
                            _lTuMarauder[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TuReaper)
                            _lTuReaper[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.TuGhost)
                        {
                            _lTuGhost[tmpUnit.Owner].UnitAmount += 1;
                            _lTuGhost[tmpUnit.Owner].Id = PredefinedData.UnitId.TuGhost;
                            _lTuGhost[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                        }

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TuWidowMine ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.TuWidowMineBurrow)
                            _lTuWidowMine[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TuSiegetank ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.TuSiegetankSieged)
                            _lTuSiegetank[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.TuThor)
                            _lTuThor[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TuHellbat)
                            _lTuHellbat[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TuNuke)
                            _lTuNuke[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TuHellion)
                            _lTuHellion[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TuBanshee)
                            _lTuBanshee[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TuBattlecruiser)
                            _lTuBattlecruiser[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TuMedivac)
                            _lTuMedivac[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.TuRaven)
                            _lTuRaven[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.TuPdd)
                            _lTuPointDefenseDrone[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TuVikingAir ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.TuVikingGround)
                            _lTuViking[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Buildings

                        #region Command Center (Air/ Ground/ Unit Production)

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TbCcGround ||
                                 tmpUnit.Id == PredefinedData.UnitId.TbCcAir)
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
                        }

                        #endregion

                        #region Orbital Command (Air/ Ground/ Unit Production)

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TbOrbitalAir ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.TbOrbitalGround)
                        {
                            _lTbOrbitalCommand[tmpUnit.Owner].UnitAmount += 1;
                            _lTbOrbitalCommand[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                            _lTbOrbitalCommand[tmpUnit.Owner].Id = PredefinedData.UnitId.TbOrbitalGround;

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
                                 PredefinedData.UnitId.TbRaxAir ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.TbBarracksGround)
                        {
                            _lTbBarracks[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuMarine))
                                    {
                                        _lTuMarine[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuMarine[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuMarauder))
                                    {
                                        _lTuMarauder[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuMarauder[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuReaper))
                                    {
                                        _lTuReaper[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuReaper[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuGhost))
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
                                 PredefinedData.UnitId.TbBunker)
                            _lTbBunker[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Turret

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TbTurret)
                            _lTbTurrent[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Refinery

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TbRefinery)
                            _lTbRefinery[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Sensor Tower

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TbSensortower)
                            _lTbSensorTower[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Planetary (Unit Production)

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TbPlanetary)
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

                        else if (tmpUnit.Id == PredefinedData.UnitId.TbEbay)
                        {
                            _lTbEbay[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupInfantryArmor1))
                                    {
                                        _lTupInfantryArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupInfantryArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupInfantryArmor2))
                                    {
                                        _lTupInfantryArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupInfantryArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupInfantryArmor3))
                                    {
                                        _lTupInfantryArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupInfantryArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupInfantryWeapon1))
                                    {
                                        _lTupInfantryWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupInfantryWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupInfantryWeapon2))
                                    {
                                        _lTupInfantryWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupInfantryWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupInfantryWeapon3))
                                    {
                                        _lTupInfantryWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupInfantryWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupHighSecAutoTracking))
                                    {
                                        _lTupHighSecAutoTracking[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupHighSecAutoTracking[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupNeosteelFrame))
                                    {
                                        _lTupNeosteelFrame[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupNeosteelFrame[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupStructureArmor))
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
                                 PredefinedData.UnitId.TbFactoryAir ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.TbFactoryGround)
                        {
                            _lTbFactory[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuHellion))
                                    {
                                        _lTuHellion[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuHellion[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuHellbat))
                                    {
                                        _lTuHellbat[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuHellbat[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuWidowMine))
                                    {

                                        _lTuWidowMine[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuWidowMine[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuSiegetank))
                                    {
                                        _lTuSiegetank[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuSiegetank[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuThor))
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
                                 PredefinedData.UnitId.TbStarportAir ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.TbStarportGround)
                        {
                            _lTbStarport[tmpUnit.Owner].UnitAmount += 1;



                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuVikingAir))
                                    {
                                        _lTuViking[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuViking[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuBanshee))
                                    {
                                        _lTuBanshee[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuBanshee[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuMedivac))
                                    {
                                        _lTuMedivac[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuMedivac[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuRaven))
                                    {
                                        _lTuRaven[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTuRaven[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuBattlecruiser))
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
                                 PredefinedData.UnitId.TbSupplyGround ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.TbSupplyHidden)
                            _lTbSupply[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Ghost Academy (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TbGhostacademy)
                        {
                            _lTbGhostAcademy[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupPersonalCloak))
                                    {
                                        _lTupPersonalCloak[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupPersonalCloak[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupMoebiusReactor))
                                    {
                                        _lTupMoebiusReactor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupMoebiusReactor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TuNuke))
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
                                 PredefinedData.UnitId.TbFusioncore)
                        {
                            _lTbFusionCore[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupWeaponRefit))
                                    {
                                        _lTupWeaponRefit[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupWeaponRefit[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupBehemothReactor))
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
                                 PredefinedData.UnitId.TbArmory)
                        {
                            _lTbArmory[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupVehicleShipPlanting1))
                                    {
                                        _lTupVehicleShipPlanting1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupVehicleShipPlanting1[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupVehicleShipPlanting2))
                                    {
                                        _lTupVehicleShipPlanting2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupVehicleShipPlanting2[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupVehicleShipPlanting3))
                                    {
                                        _lTupVehicleShipPlanting3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupVehicleShipPlanting3[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupVehicleWeapon1))
                                    {
                                        _lTupVehicleWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupVehicleWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupVehicleWeapon2))
                                    {
                                        _lTupVehicleWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupVehicleWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupVehicleWeapon3))
                                    {
                                        _lTupVehicleWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupVehicleWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupShipWeapon1))
                                    {
                                        _lTupShipWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupShipWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupShipWeapon2))
                                    {
                                        _lTupShipWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupShipWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupShipWeapon3))
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
                                 PredefinedData.UnitId.TbAutoTurret)
                            _lTbAutoTurret[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Techlab Barracks (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.TbTechlabRax)
                        {
                            _lTbTechlab[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {

                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupStim))
                                    {
                                        _lTupStim[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupStim[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupCombatShields))
                                    {
                                        _lTupCombatShields[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupCombatShields[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupConcussiveShells))
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
                                 PredefinedData.UnitId.TbTechlabFactory)
                        {
                            _lTbTechlab[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupBlueFlame))
                                    {
                                        _lTupBlueFlame[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupBlueFlame[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupDrillingClaws))
                                    {
                                        _lTupDrillingClaws[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupDrillingClaws[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupTransformatorServos))
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
                                 PredefinedData.UnitId.TbTechlabStarport)
                        {
                            _lTbTechlab[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupCloakingField))
                                    {
                                        _lTupCloakingField[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupCloakingField[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupCorvidReactor))
                                    {
                                        _lTupCorvidReactor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupCorvidReactor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupCaduceusReactor))
                                    {
                                        _lTupCaduceusReactor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lTupCaduceusReactor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.TupDurableMeterials))
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
                                 PredefinedData.UnitId.TbReactor ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.TbReactorFactory ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.TbReactorRax ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.TbReactorStarport)
                            _lTbReactor[tmpUnit.Owner].UnitAmount += 1;

                        #endregion


                        #endregion

                        #endregion

                        #region Protoss

                        #region Units

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuForceField)
                        {
                            _lPuForcefield[HMainHandler.GInformation.Player.Count].UnitAmount += 1;
                            _lPuForcefield[HMainHandler.GInformation.Player.Count].Id =
                                PredefinedData.UnitId.PuForceField;
                            _lPuForcefield[HMainHandler.GInformation.Player.Count].AliveSince.Add(1 -
                                                                                                   (tmpUnit.AliveSince /
                                                                                                    62208.0f));
                        }

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuArchon)
                            _lPuArchon[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuCarrier)
                            _lPuCarrier[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuColossus)
                            _lPuColossus[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuDarktemplar)
                            _lPuDt[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuHightemplar)
                        {
                            _lPuHt[tmpUnit.Owner].UnitAmount += 1;
                            _lPuHt[tmpUnit.Owner].Id = PredefinedData.UnitId.PuHightemplar;
                            _lPuHt[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                        }

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuImmortal)
                            _lPuImmortal[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuMothership)
                            _lPuMothership[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuMothershipCore)
                            _lPuMothershipcore[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuObserver)
                            _lPuObserver[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuOracle)
                            _lPuOracle[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuPhoenix)
                            _lPuPhoenix[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.PuProbe)
                            _lPuProbe[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuSentry)
                        {
                            _lPuSentry[tmpUnit.Owner].UnitAmount += 1;
                            _lPuSentry[tmpUnit.Owner].Id = PredefinedData.UnitId.PuSentry;
                            _lPuSentry[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                        }

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuStalker)
                            _lPuStalker[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuTempest)
                            _lPuTempest[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuVoidray)
                            _lPuVoidray[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuWarpprismPhase ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.PuWarpprismTransport)
                            _lPuWarpprism[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PuZealot)
                            _lPuZealot[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Buildings

                        #region Nexus (Unit Production)

                        else if (tmpUnit.Id == PredefinedData.UnitId.PbNexus)
                        {
                            _lPbNexus[tmpUnit.Owner].UnitAmount += 1;
                            _lPbNexus[tmpUnit.Owner].Id = tmpUnit.Id;
                            _lPbNexus[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PuProbe))
                                    {
                                        _lPuProbe[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuProbe[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuProbe[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.PuMothershipCore))
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

                        else if (tmpUnit.Id == PredefinedData.UnitId.PbPylon)
                            _lPbPylon[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Assimilator

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PbAssimilator)
                            _lPbAssimilator[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Cannon

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PbCannon)
                            _lPbCannon[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region CyberCore (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PbCybercore)
                        {
                            _lPbCybercore[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupAirA1))
                                    {
                                        _lPupAirArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupAirArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupAirArmor1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupAirA2))
                                    {
                                        _lPupAirArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupAirArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupAirArmor2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupAirA3))
                                    {
                                        _lPupAirArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupAirArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupAirArmor3[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupAirW1))
                                    {
                                        _lPupAirWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupAirWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupAirWeapon1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupAirW2))
                                    {
                                        _lPupAirWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupAirWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupAirWeapon2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupAirW3))
                                    {
                                        _lPupAirWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupAirWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupAirWeapon3[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupWarpGate))
                                    {
                                        _lPupWarpGate[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupWarpGate[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupWarpGate[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                        _lPupWarpGate[tmpUnit.Owner].Id = PredefinedData.UnitId.PupWarpGate;
                                    }
                                }
                            }
                        }

                        #endregion

                        #region Dark Shrine

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PbDarkshrine)
                            _lPbDarkshrine[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Fleet Beacon (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.PbFleetbeacon)
                        {
                            _lPbFleetbeacon[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupAnionPulseCrystals))
                                    {
                                        _lPupAnionPulseCrystal[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupAnionPulseCrystal[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                        _lPupAnionPulseCrystal[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupGravitonCatapult))
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

                        else if (tmpUnit.Id == PredefinedData.UnitId.PbForge)
                        {
                            _lPbForge[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupGroundA1))
                                    {
                                        _lPupGroundArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGroundArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGroundArmor1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupGroundA2))
                                    {
                                        _lPupGroundArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGroundArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGroundArmor2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupGroundA3))
                                    {
                                        _lPupGroundArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGroundArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGroundArmor3[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupGroundW1))
                                    {
                                        _lPupGroundWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGroundWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGroundWeapon1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupGroundW2))
                                    {
                                        _lPupGroundWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGroundWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGroundWeapon2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupGroundW3))
                                    {
                                        _lPupGroundWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGroundWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGroundWeapon3[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupS1))
                                    {
                                        _lPupShield1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupShield1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupShield1[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupS2))
                                    {
                                        _lPupShield2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupShield2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupShield2[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupS3))
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
                                 PredefinedData.UnitId.PbGateway)
                        {
                            _lPbGateway[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PuZealot))
                                    {
                                        _lPuZealot[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuZealot[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuZealot[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.PuStalker))
                                    {
                                        _lPuStalker[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuStalker[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuStalker[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.PuSentry))
                                    {
                                        _lPuSentry[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuSentry[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuSentry[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.PuHightemplar))
                                    {
                                        _lPuHt[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuHt[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuHt[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.PuDarktemplar))
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
                                 PredefinedData.UnitId.PbRoboticsbay)
                        {
                            _lPbRobotics[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PuObserver))
                                    {
                                        _lPuObserver[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuObserver[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuObserver[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.PuWarpprismTransport))
                                    {
                                        _lPuWarpprism[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuWarpprism[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuWarpprism[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.PuImmortal))
                                    {
                                        _lPuImmortal[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuImmortal[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuImmortal[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.PuColossus))
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
                                 PredefinedData.UnitId.PbRoboticssupportbay)
                        {
                            _lPbRoboticsSupport[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupExtendedThermalLance))
                                    {
                                        _lPupExtendedThermalLance[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupExtendedThermalLance[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                        _lPupExtendedThermalLance[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupGraviticBooster))
                                    {
                                        _lPupGraviticBooster[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupGraviticBooster[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupGraviticBooster[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupGraviticDrive))
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
                                 PredefinedData.UnitId.PbStargate)
                        {
                            _lPbStargate[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PuPhoenix))
                                    {
                                        _lPuPhoenix[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuPhoenix[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuPhoenix[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.PuOracle))
                                    {
                                        _lPuOracle[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuOracle[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuOracle[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.PuVoidray))
                                    {
                                        _lPuVoidray[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuVoidray[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuVoidray[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.PuCarrier))
                                    {
                                        _lPuCarrier[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPuCarrier[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPuCarrier[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.PuTempest))
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
                                 PredefinedData.UnitId.PbTemplararchives)
                        {
                            _lPbTemplarArchives[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupStorm))
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
                                 PredefinedData.UnitId.PbTwilightcouncil)
                        {
                            _lPbTwilight[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupBlink))
                                    {
                                        _lPupBlink[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lPupBlink[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                        _lPupBlink[tmpUnit.Owner].SpeedMultiplier.Add(tmpUnit.SpeedMultiplier);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.PupCharge))
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
                                 PredefinedData.UnitId.PbWarpgate)
                            _lPbWarpgate[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #endregion

                        #endregion

                        #region Zerg

                        #region Units

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuEgg)
                        {
                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZuDrone))
                                    {
                                        _lZuDrone[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuDrone[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZuOverlord))
                                    {
                                        _lZuOverlord[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuOverlord[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZuZergling))
                                    {
                                        _lZuZergling[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuZergling[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZuRoach))
                                    {
                                        _lZuRoach[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuRoach[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZuHydralisk))
                                    {
                                        _lZuHydra[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuHydra[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZuMutalisk))
                                    {
                                        _lZuMutalisk[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuMutalisk[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZuInfestor))
                                    {
                                        _lZuInfestor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuInfestor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZuUltra))
                                    {
                                        _lZuUltralisk[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuUltralisk[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZuCorruptor))
                                    {
                                        _lZuCorruptor[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuCorruptor[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZuViper))
                                    {
                                        _lZuViper[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuViper[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZuSwarmHost))
                                    {
                                        _lZuSwarmhost[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuSwarmhost[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuBaneling ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuBanelingBurrow)
                            _lZuBaneling[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuLocust)
                        {
                            _lZuLocust[tmpUnit.Owner].UnitAmount += 1;
                            _lZuLocust[tmpUnit.Owner].Id = PredefinedData.UnitId.ZuLocust;

                            if (tmpUnit.AliveSince > 73216f)
                                _lZuLocust[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince / 113920f));

                            else
                                _lZuLocust[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince / 73216f));
                        }


                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuBanelingCocoon)
                        {
                            _lZuBanelingCocoon[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZuBaneling))
                                    {
                                        _lZuBaneling[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuBaneling[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuBroodlord)
                            _lZuBroodlord[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuBroodlordCocoon)
                            _lZuBroodlordCocoon[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuCorruptor)
                            _lZuCorruptor[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZuDrone ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuDroneBurrow)
                            _lZuDrone[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuHydraBurrow ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuHydralisk)
                            _lZuHydra[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuInfestor ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuInfestorBurrow)
                        {
                            _lZuInfestor[tmpUnit.Owner].UnitAmount += 1;
                            _lZuInfestor[tmpUnit.Owner].Id = PredefinedData.UnitId.ZuInfestor;
                            _lZuInfestor[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                        }

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZuLarva)
                            _lZuLarva[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuMutalisk)
                            _lZuMutalisk[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuOverlord)
                            _lZuOverlord[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuOverseer)
                            _lZuOverseer[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuOverseerCocoon)
                            _lZuOverseerCocoon[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZuQueen ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuQueenBurrow)
                            _lZuQueen[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZuRoach ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuRoachBurrow)
                            _lZuRoach[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuSwarmHost ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuSwarmHostBurrow)
                            _lZuSwarmhost[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZuUltra ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuUltraBurrow)
                            _lZuUltralisk[tmpUnit.Owner].UnitAmount += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZuViper)
                        {
                            _lZuViper[tmpUnit.Owner].UnitAmount += 1;
                            _lZuViper[tmpUnit.Owner].Id = PredefinedData.UnitId.ZuViper;
                            _lZuViper[tmpUnit.Owner].Energy.Add(tmpUnit.Energy);
                        }

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuZergling ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.ZuZerglingBurrow)
                            _lZuZergling[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Structures

                        #region Baneling Nest (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZbBanelingNest)
                        {
                            _lZbBanelingnest[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupCentrifugalHooks))
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
                                 PredefinedData.UnitId.ZbCreeptumor ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.ZbCreeptumorBurrowed ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.ZbCreepTumorMissle ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.ZbCreepTumorBuilding)
                            _lZbCreepTumor[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Evolution Chamber (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZbEvolutionChamber)
                        {
                            _lZbEvochamber[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupGroundA1))
                                    {
                                        _lZupGroundArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupGroundA2))
                                    {
                                        _lZupGroundArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupGroundA3))
                                    {
                                        _lZupGroundArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupGroundW1))
                                    {
                                        _lZupGroundWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupGroundW2))
                                    {
                                        _lZupGroundWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupGroundW3))
                                    {
                                        _lZupGroundWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupGroundM1))
                                    {
                                        _lZupGroundMelee1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundMelee1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupGroundM2))
                                    {
                                        _lZupGroundMelee2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroundMelee2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupGroundM3))
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
                                 PredefinedData.UnitId.ZbExtractor)
                            _lZbExtractor[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Greater Spire (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZbGreaterspire)
                        {
                            _lZbGreaterspire[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupAirA1))
                                    {
                                        _lZupAirArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupAirA2))
                                    {
                                        _lZupAirArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupAirA3))
                                    {
                                        _lZupAirArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupAirW1))
                                    {
                                        _lZupAirWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupAirW2))
                                    {
                                        _lZupAirWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupAirW3))
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
                                 PredefinedData.UnitId.ZbHatchery)
                        {
                            _lZbHatchery[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZuQueen))
                                    {
                                        _lZuQueen[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuQueen[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZupVentralSacs))
                                    {
                                        _lZupVentralSacs[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupVentralSacs[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZupBurrow))
                                    {
                                        _lZupBurrow[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupBurrow[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZupPneumatizedCarapace))
                                    {
                                        _lZupPneumatizedCarapace[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupPneumatizedCarapace[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        #endregion

                        #region Hive (Unit Production, Upgrade Production)

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZbHive)
                        {
                            _lZbHive[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZuQueen))
                                    {
                                        _lZuQueen[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuQueen[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZupVentralSacs))
                                    {
                                        _lZupVentralSacs[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupVentralSacs[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZupBurrow))
                                    {
                                        _lZupBurrow[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupBurrow[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZupPneumatizedCarapace))
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
                                 PredefinedData.UnitId.ZbHydraDen)
                        {
                            _lZbHydraden[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupGroovedSpines))
                                    {
                                        _lZupGroovedSpines[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupGroovedSpines[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZupMuscularAugments))
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
                                 PredefinedData.UnitId.ZbInfestationPit)
                        {
                            _lZbInfestationpit[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupNeutralParasite))
                                    {
                                        _lZupNeutralParasite[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupNeutralParasite[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZupEnduringLocusts))
                                    {
                                        _lZupEnduringLocusts[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupEnduringLocusts[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZupPathoglenGlands))
                                    {
                                        _lZupPathoglenGlands[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupPathoglenGlands[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        #endregion

                        #region Liar (Unit Production, Upgrade Production)

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZbLiar)
                        {
                            _lZbLair[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZuQueen))
                                    {
                                        _lZuQueen[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZuQueen[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZupVentralSacs))
                                    {
                                        _lZupVentralSacs[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupVentralSacs[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZupBurrow))
                                    {
                                        _lZupBurrow[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupBurrow[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZupPneumatizedCarapace))
                                    {
                                        _lZupPneumatizedCarapace[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupPneumatizedCarapace[tmpUnit.Owner].ConstructionState.Add(
                                            tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        #endregion

                        #region Nydus Network

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZbNydusNetwork)
                            _lZbNydusbegin[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Nydus Worm

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZbNydusWorm)
                            _lZbNydusend[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Roach Warran (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZbRoachWarren)
                        {
                            _lZbRoachwarren[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupTunnelingClaws))
                                    {
                                        _lZupTunnnelingClaws[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupTunnnelingClaws[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZupGlialReconstruction))
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
                                 PredefinedData.UnitId.ZbSpawningPool)
                        {
                            _lZbSpawningpool[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupMetabolicBoost))
                                    {
                                        _lZupMetabolicBoost[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupMetabolicBoost[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (tmpUnit.ProdUnitProductionId[k].Equals(
                                        PredefinedData.UnitId.ZupAdrenalGlands))
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
                                 PredefinedData.UnitId.ZbSpineCrawler ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.ZbSpineCrawlerUnrooted)
                            _lZbSpine[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Spire (Upgrade Production)

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZbSpire)
                        {
                            _lZbSpire[tmpUnit.Owner].UnitAmount += 1;

                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupAirA1))
                                    {
                                        _lZupAirArmor1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirArmor1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupAirA2))
                                    {
                                        _lZupAirArmor2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirArmor2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupAirA3))
                                    {
                                        _lZupAirArmor3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirArmor3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupAirW1))
                                    {
                                        _lZupAirWeapon1[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirWeapon1[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupAirW2))
                                    {
                                        _lZupAirWeapon2[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirWeapon2[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }

                                    else if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupAirW3))
                                    {
                                        _lZupAirWeapon3[tmpUnit.Owner].UnitUnderConstruction += 1;
                                        _lZupAirWeapon3[tmpUnit.Owner].ConstructionState.Add(tmpUnit.ProdProcess[k]);
                                    }
                                }
                            }
                        }

                        #endregion

                        #region Spore Crawler

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZbSporeCrawler ||
                                 tmpUnit.Id ==
                                 PredefinedData.UnitId.ZbSporeCrawlerUnrooted)
                            _lZbSpore[tmpUnit.Owner].UnitAmount += 1;

                        #endregion

                        #region Ultra Cavern (Upgrade Production)

                        else if (tmpUnit.Id ==
                                 PredefinedData.UnitId.ZbUltraCavern)
                        {
                            _lZbUltracavern[tmpUnit.Owner].UnitAmount += 1;


                            if (tmpUnit.ProdNumberOfQueuedUnits > 0)
                            {
                                for (var k = 0; k < tmpUnit.ProdMineralCost.Count; k++)
                                {
                                    if (
                                        tmpUnit.ProdUnitProductionId[k].Equals(
                                            PredefinedData.UnitId.ZupChitinousPlating))
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
                            PredefinedData.UnitId.TbCcGround ||
                            tmpUnit.Id == PredefinedData.UnitId.TbCcAir)
                        {
                            _lTbCommandCenter[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbCommandCenter[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbOrbitalAir ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.TbOrbitalGround)
                        {
                            _lTbOrbitalCommand[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbOrbitalCommand[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbRaxAir ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.TbBarracksGround)
                        {
                            _lTbBarracks[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbBarracks[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbBunker)
                        {
                            _lTbBunker[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbBunker[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbTurret)
                        {
                            _lTbTurrent[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbTurrent[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbRefinery)
                        {
                            _lTbRefinery[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbRefinery[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbSensortower)
                        {
                            _lTbSensorTower[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbSensorTower[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbPlanetary)
                        {
                            _lTbPlanetaryFortress[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
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

                        else if (tmpUnit.Id == PredefinedData.UnitId.TbEbay)
                        {
                            _lTbEbay[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbEbay[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbFactoryAir ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.TbFactoryGround)
                        {
                            _lTbFactory[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbFactory[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbStarportAir ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.TbStarportGround)
                        {
                            _lTbStarport[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbStarport[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbSupplyGround ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.TbSupplyHidden)
                        {
                            _lTbSupply[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbSupply[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbGhostacademy)
                        {
                            _lTbGhostAcademy[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbGhostAcademy[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbFusioncore)
                        {
                            _lTbFusionCore[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbFusionCore[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbArmory)
                        {
                            _lTbArmory[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbArmory[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbTechlab ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.TbTechlabFactory ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.TbTechlabRax ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.TbTechlabStarport)
                        {
                            _lTbTechlab[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbTechlab[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TbReactor ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.TbReactorFactory ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.TbReactorRax ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.TbReactorStarport)
                        {
                            _lTbReactor[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lTbReactor[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        #endregion

                        #region Units

                        else if (tmpUnit.Id == PredefinedData.UnitId.TuScv)
                            _lTuScv[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.TuMule)
                            _lTuMule[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TuMarine)
                            _lTuMarine[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TuMarauder)
                            _lTuMarauder[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TuReaper)
                            _lTuReaper[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.TuGhost)
                            _lTuGhost[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TuWidowMine ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.TuWidowMineBurrow)
                            _lTuWidowMine[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TuSiegetank ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.TuSiegetankSieged)
                            _lTuSiegetank[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.TuThor)
                            _lTuThor[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TuHellbat)
                            _lTuHellbat[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TuHellion)
                            _lTuHellion[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TuBanshee)
                            _lTuBanshee[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TuBattlecruiser)
                            _lTuBattlecruiser[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TuMedivac)
                            _lTuMedivac[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.TuRaven)
                            _lTuRaven[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.TuVikingAir ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.TuVikingGround)
                            _lTuViking[tmpUnit.Owner].UnitUnderConstruction += 1;



                        #endregion

                        #endregion

                        #region Protoss

                        #region Structures

                        else if (tmpUnit.Id == PredefinedData.UnitId.PbNexus)
                        {
                            _lPbNexus[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbNexus[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == PredefinedData.UnitId.PbPylon)
                        {
                            _lPbPylon[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbPylon[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PbAssimilator)
                        {
                            _lPbAssimilator[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbAssimilator[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PbCannon)
                        {
                            _lPbCannon[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbCannon[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PbCybercore)
                        {
                            _lPbCybercore[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbCybercore[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PbDarkshrine)
                        {
                            _lPbDarkshrine[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbDarkshrine[tmpUnit.Owner].ConstructionState.Add(tmp);

                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PbFleetbeacon)
                        {
                            _lPbFleetbeacon[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbFleetbeacon[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == PredefinedData.UnitId.PbForge)
                        {
                            _lPbForge[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbForge[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PbGateway)
                        {
                            _lPbGateway[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbGateway[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PbRoboticsbay)
                        {
                            _lPbRobotics[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbRobotics[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PbRoboticssupportbay)
                        {
                            _lPbRoboticsSupport[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbRoboticsSupport[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PbStargate)
                        {
                            _lPbStargate[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbStargate[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PbTemplararchives)
                        {
                            _lPbTemplarArchives[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbTemplarArchives[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PbTwilightcouncil)
                        {
                            _lPbTwilight[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbTwilight[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PbWarpgate)
                        {
                            _lPbWarpgate[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lPbWarpgate[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        #endregion

                        #region Units

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuArchon)
                            _lPuArchon[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuCarrier)
                            _lPuCarrier[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuColossus)
                            _lPuColossus[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuDarktemplar)
                            _lPuDt[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuHightemplar)
                            _lPuHt[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuImmortal)
                            _lPuImmortal[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuMothership)
                            _lPuMothership[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuMothershipCore)
                            _lPuMothershipcore[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuObserver)
                            _lPuObserver[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuOracle)
                            _lPuOracle[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuPhoenix)
                            _lPuPhoenix[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.PuProbe)
                            _lPuProbe[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuSentry)
                            _lPuSentry[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuStalker)
                            _lPuStalker[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuTempest)
                            _lPuTempest[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuVoidray)
                            _lPuVoidray[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuWarpprismPhase ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.PuWarpprismTransport)
                            _lPuWarpprism[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.PuZealot)
                            _lPuZealot[tmpUnit.Owner].UnitUnderConstruction += 1;

                        #endregion

                        #endregion

                        #region Zerg

                        #region Structures

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbBanelingNest)
                        {
                            _lZbBanelingnest[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbBanelingnest[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }


                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbCreeptumor ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.ZbCreeptumorBurrowed ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.ZbCreepTumorMissle ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.ZbCreepTumorBuilding)
                        {
                            _lZbCreepTumor[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbCreepTumor[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbEvolutionChamber)
                        {
                            _lZbEvochamber[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbEvochamber[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbExtractor)
                        {
                            _lZbExtractor[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbExtractor[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbGreaterspire)
                        {
                            _lZbGreaterspire[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbGreaterspire[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbHatchery)
                        {
                            _lZbHatchery[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbHatchery[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZbHive)
                        {
                            _lZbHive[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbHive[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbHydraDen)
                        {
                            _lZbHydraden[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbHydraden[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbInfestationPit)
                        {
                            _lZbInfestationpit[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbInfestationpit[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZbLiar)
                        {
                            _lZbLair[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbLair[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbNydusNetwork)
                        {
                            _lZbNydusbegin[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbNydusbegin[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbNydusWorm)
                        {
                            _lZbNydusend[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbNydusend[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbRoachWarren)
                        {
                            _lZbRoachwarren[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbRoachwarren[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbSpawningPool)
                        {
                            _lZbSpawningpool[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbSpawningpool[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbSpineCrawler ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.ZbSpineCrawlerUnrooted)
                        {
                            _lZbSpine[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbSpine[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZbSpire)
                        {
                            _lZbSpire[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbSpire[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbSporeCrawler ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.ZbSporeCrawlerUnrooted)
                        {
                            _lZbSpore[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);
                            _lZbSpore[tmpUnit.Owner].ConstructionState.Add(tmp);
                        }

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZbUltraCavern)
                        {
                            _lZbUltracavern[tmpUnit.Owner].UnitUnderConstruction += 1;

                            var tmp =
                                (float)
                                Math.Round(
                                    ((tmpUnit.MaximumHealth -
                                      tmpUnit.DamageTaken) /
                                     (float)tmpUnit.MaximumHealth) * 100, 1);

                            _lZbUltracavern[tmpUnit.Owner].ConstructionState.Add(tmp);

                        }

                        #endregion

                        #region Units

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZuBaneling ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.ZuBanelingBurrow)
                            _lZuBaneling[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZuBanelingCocoon)
                            _lZuBanelingCocoon[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZuBroodlord)
                            _lZuBroodlord[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZuBroodlordCocoon)
                            _lZuBroodlordCocoon[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZuCorruptor)
                            _lZuCorruptor[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZuDrone ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.ZuDroneBurrow)
                            _lZuDrone[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZuHydraBurrow ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.ZuHydralisk)
                            _lZuHydra[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZuInfestor ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.ZuInfestorBurrow)
                            _lZuInfestor[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZuLarva)
                            _lZuLarva[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZuMutalisk)
                            _lZuMutalisk[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZuOverlord)
                            _lZuOverlord[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZuOverseer)
                            _lZuOverseer[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZuOverseerCocoon)
                            _lZuOverseerCocoon[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZuQueen ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.ZuQueenBurrow)
                            _lZuQueen[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZuRoach ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.ZuRoachBurrow)
                            _lZuRoach[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZuSwarmHost ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.ZuSwarmHostBurrow)
                            _lZuSwarmhost[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZuUltra ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.ZuUltraBurrow)
                            _lZuUltralisk[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id == PredefinedData.UnitId.ZuViper)
                            _lZuViper[tmpUnit.Owner].UnitUnderConstruction += 1;

                        else if (tmpUnit.Id ==
                            PredefinedData.UnitId.ZuZergling ||
                            tmpUnit.Id ==
                            PredefinedData.UnitId.ZuZerglingBurrow)
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
                SortAliveSinceStates(ref _lZuLocust);
                SortConstructionStates(ref _lZuZergling);

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
                Messages.LogFile("CountUnits_2", "Over all", ex);

            }
#endif
        }

        protected void SortConstructionStates(ref List<PredefinedData.UnitCount> lCounter)
        {
            for (var i = 0; i < lCounter.Count; i++)
            {
                lCounter[i].ConstructionState.Sort((x, y) => y.CompareTo(x));
            }
        }

        protected void SortAliveSinceStates(ref List<PredefinedData.UnitCount> lCounter)
        {
            for (var i = 0; i < lCounter.Count; i++)
            {
                lCounter[i].AliveSince.Sort((x, y) => x.CompareTo(y));
            }
        }
    }
}
