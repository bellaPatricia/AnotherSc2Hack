using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Predefined;
using Predefined = Predefined.PredefinedData;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public partial class Renderer : Form
    {
        #region Variables 

        #region Private

        private readonly PredefinedData.RenderForm _rRenderForm = PredefinedData.RenderForm.Dummy;    //To check what renderform is called
        private readonly MainHandler.MainHandler _hMainHandler;                                              //Mainhandler - handles access to the Engine
        private Point _ptMousePosition = new Point(0,0);                                                //Position for the Moving of the Panel
        private Preferences _pSettings;

        private Image _imgMinerals = Properties.Resources.Mineral_Protoss,
                      _imgGas = Properties.Resources.Gas_Protoss,
                      _imgSupply = Properties.Resources.Supply_Protoss,
                      _imgWorker = Properties.Resources.P_Probe;

        private Boolean _bChangingPosition;
        private Boolean _bDraw = true;
        private Boolean _bSurpressForeground;
        private Stopwatch _swMainWatch = new Stopwatch();

        private DateTime _dtBegin = DateTime.Now;               //Check for the TopMost refreshing

        const Int32 SizeOfRectangle = 10;                      //Size for the corner- rectangles (when changing position)

        /* Size for Unit/ Productionsize */
        private Int32 _iUnitPanelWidth;
        private Int32 _iUnitPanelWidthWithoutName;
        private Int32 _iUnitPosAfterName;

        private Int32 _iProdPanelWidth;
        private Int32 _iProdPanelWidthWithoutName;
        private Int32 _iProdPosAfterName;


        #endregion

        #region Public

        public Boolean IsDestroyed = false;

        #endregion

        #endregion

        #region UnitCounter - Count all objects per player

        #region Terran

        List<PredefinedData.UnitCount> _lTbCommandCenter = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbPlanetaryFortress = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbOrbitalCommand = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbBarracks = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbSupply = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbEbay = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbRefinery = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbBunker = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbTurrent = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbSensorTower = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbFactory = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbStarport = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbArmory = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbGhostAcademy = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbFusionCore = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbTechlab = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbReactor = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTbAutoTurret = new List<PredefinedData.UnitCount>();


        List<PredefinedData.UnitCount> _lTuScv = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuMule = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuMarine = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuMarauder = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuReaper = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuGhost = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuWidowMine = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuSiegetank = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuHellion = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuHellbat = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuThor = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuViking = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuBanshee = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuMedivac = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuBattlecruiser = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuRaven = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuPointDefenseDrone = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTuNuke = new List<PredefinedData.UnitCount>(); 


        List<PredefinedData.UnitCount> _lTupInfantryWeapon1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupInfantryWeapon2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupInfantryWeapon3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupInfantryArmor1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupInfantryArmor2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupInfantryArmor3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupVehicleWeapon1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupVehicleWeapon2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupVehicleWeapon3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupShipWeapon1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupShipWeapon2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupShipWeapon3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupVehicleShipPlanting1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupVehicleShipPlanting2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupVehicleShipPlanting3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupNeosteelFrame = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupStructureArmor = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupHighSecAutoTracking = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupConcussiveShells = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupCombatShields = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupStim = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupBlueFlame = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupDrillingClaws = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupTransformationServos = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupCloakingField = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupCaduceusReactor = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupDurableMaterials = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupCorvidReactor = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupWeaponRefit = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupBehemothReactor = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupPersonalCloak = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupMoebiusReactor = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupPlanetaryFortress = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lTupOrbitalCommand = new List<PredefinedData.UnitCount>();



            #endregion

        #region Protoss

        List<PredefinedData.UnitCount> _lPbNexus = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPbPylon = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPbGateway = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPbForge = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPbCybercore = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPbWarpgate = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPbCannon = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPbAssimilator = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPbTwilight = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPbStargate = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPbRobotics = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPbRoboticsSupport = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPbFleetbeacon = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPbTemplarArchives = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPbDarkshrine = new List<PredefinedData.UnitCount>();

        List<PredefinedData.UnitCount> _lPuProbe = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuStalker = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuZealot = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuSentry = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuDt = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuHt = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuMothership = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuMothershipcore = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuArchon = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuWarpprism = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuObserver = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuColossus = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuImmortal = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuPhoenix = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuVoidray = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuOracle = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuTempest = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuCarrier = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPuForcefield = new List<PredefinedData.UnitCount>();

        List<PredefinedData.UnitCount> _lPupGroundWeapon1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupGroundWeapon2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupGroundWeapon3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupGroundArmor1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupGroundArmor2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupGroundArmor3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupShield1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupShield2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupShield3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupAirWeapon1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupAirWeapon2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupAirWeapon3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupAirArmor1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupAirArmor2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupAirArmor3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupStorm = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupWarpGate = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupBlink = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupCharge = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupAnionPulseCrystal = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupGraviticBooster = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupGraviticDrive = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupGravitonCatapult = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lPupExtendedThermalLance = new List<PredefinedData.UnitCount>(); 

        #endregion

        #region Zerg

        List<PredefinedData.UnitCount> _lZbHatchery = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbLair = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbHive = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbSpawningpool = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbRoachwarren = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbCreepTumor = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbEvochamber = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbSpine = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbSpore = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbBanelingnest = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbExtractor = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbHydraden = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbSpire = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbNydusbegin = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbNydusend = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbUltracavern = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbGreaterspire = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZbInfestationpit = new List<PredefinedData.UnitCount>();

        List<PredefinedData.UnitCount> _lZuLarva = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuDrone = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuOverlord = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuZergling = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuBaneling = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuBanelingCocoon = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuBroodlordCocoon = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuRoach = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuHydra = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuInfestor = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuQueen = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuOverseer = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuOverseerCocoon = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuMutalisk = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuCorruptor = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuBroodlord = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuUltralisk = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuSwarmhost = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuViper = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZuLocust = new List<PredefinedData.UnitCount>();

        List<PredefinedData.UnitCount> _lZupAirWeapon1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupAirWeapon2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupAirWeapon3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupAirArmor1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupAirArmor2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupAirArmor3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupGroundWeapon1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupGroundWeapon2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupGroundWeapon3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupGroundArmor1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupGroundArmor2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupGroundArmor3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupGroundMelee1 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupGroundMelee2 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupGroundMelee3 = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupMetabolicBoost = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupAdrenalGlands = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupCentrifugalHooks = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupChitinousPlating = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupEnduringLocusts = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupGlialReconstruction = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupGroovedSpines = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupMuscularAugments = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupNeutralParasite = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupPathoglenGlands = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupPneumatizedCarapace = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupTunnnelingClaws = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupVentralSacs = new List<PredefinedData.UnitCount>();
        List<PredefinedData.UnitCount> _lZupBurrow = new List<PredefinedData.UnitCount>();
      
        

        #endregion

        #region Images

        #region Terran

        #region Units

        private readonly Image _imgTuScv = Properties.Resources.tu_scv,
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

        private readonly Image _imgTbCc = Properties.Resources.tb_cc,
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

        private readonly Image _imgTupStim = Properties.Resources.Tup_Stim,
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

        private readonly Image _imgPuProbe = Properties.Resources.pu_probe,
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

        private readonly Image _imgPbNexus = Properties.Resources.pb_Nexus,
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

        private readonly Image _imgPupGroundWeapon1 = Properties.Resources.Pup_GroundW1,
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

        private readonly Image _imgZuDrone = Properties.Resources.zu_drone,
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

        private readonly Image _imgZbHatchery = Properties.Resources.zb_hatchery,
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

        private readonly Image _imgZupAirWeapon1 = Properties.Resources.Zup_AirW1,
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

        private readonly Image _imgSpeedArrow = Properties.Resources.Speed_Arrow;

        #endregion

        #endregion

        #endregion

        #region Experimental Stuff


        #endregion

        public Renderer(PredefinedData.RenderForm rnd, MainHandler.MainHandler hnd)
        {
            _rRenderForm = rnd;
            _hMainHandler = hnd;

            _pSettings = _hMainHandler.PSettings;

            SetStyle(ControlStyles.DoubleBuffer |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint, true);

            InitializeComponent();

            if (rnd.Equals(PredefinedData.RenderForm.Production) ||
                rnd.Equals(PredefinedData.RenderForm.Units))
                _hMainHandler.GInformation.CAccessUnitCommands = true;
        }

        private void Renderer_2_Load(object sender, EventArgs e)
        {
            LoadPreferencesIntoControls();

            if (_rRenderForm.Equals(PredefinedData.RenderForm.ExportIdsToFile))
            {
                ExportUnitIdsToFile();
                return;
            }

            if (_rRenderForm.Equals(PredefinedData.RenderForm.Production) ||
                     _rRenderForm.Equals(PredefinedData.RenderForm.Units))
                /*CountUnits();*/ CountUnits_2();

            TopMost = true;


            BackColor = Color.FromArgb(255, 50, 50, 50);
            TransparencyKey = Color.FromArgb(255, 50, 50, 50);

            ChangeForecolorOfButton(Color.Green);


            tmrRefreshGraphic.Enabled = true;
        }

        public long IterationsPerSeconds { get; set; }
        private long _lTimesRefreshed;
        private DateTime _dtSecond = DateTime.Now;
        protected override void OnPaint(PaintEventArgs e)
        {
            if ((DateTime.Now - _dtSecond).Seconds >= 1)
            {
                //Debug.WriteLine("The OnPaint- loop was refreshed " + lTimesRefreshed + " times in a second!");
                IterationsPerSeconds = _lTimesRefreshed;
                _lTimesRefreshed = 0;
                _dtSecond = DateTime.Now;
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

                if (_hMainHandler.GInformation.Gameinfo.IsIngame)
                {
                    if (_pSettings.GlobalDrawOnlyInForeground && !_bSurpressForeground)
                    {
                        _bDraw = InteropCalls.GetForegroundWindow().Equals(_hMainHandler.PSc2Process.MainWindowHandle);
                    }

                    else
                    {
                        _bDraw = true;

                        if (InteropCalls.GetForegroundWindow().Equals(_hMainHandler.PSc2Process.MainWindowHandle))
                        {
                            InteropCalls.SetActiveWindow(Handle);
                        }
                    }

                    if (_bDraw)
                    {
                        if (_rRenderForm.Equals(PredefinedData.RenderForm.Maphack))
                            DrawMinimap(buffer);

                        else if (_rRenderForm.Equals(PredefinedData.RenderForm.Units))
                            DrawUnits(buffer);

                        else if (_rRenderForm.Equals(PredefinedData.RenderForm.Resources))
                            DrawResources(buffer);

                        else if (_rRenderForm.Equals(PredefinedData.RenderForm.Income))
                            DrawIncome(buffer);

                        else if (_rRenderForm.Equals(PredefinedData.RenderForm.Army))
                            DrawArmy(buffer);

                        else if (_rRenderForm.Equals(PredefinedData.RenderForm.Apm))
                            DrawApm(buffer);

                        else if (_rRenderForm.Equals(PredefinedData.RenderForm.Worker))
                            DrawWorker(buffer);

                        else if (_rRenderForm.Equals(PredefinedData.RenderForm.Production))
                            DrawProduction(buffer);

                        else if (_rRenderForm.Equals(PredefinedData.RenderForm.PersonalApm))
                            DrawPersonalApm(buffer);

                        else if (_rRenderForm.Equals(PredefinedData.RenderForm.PersonalClock))
                            DrawPersonalClock(buffer);

                        #region Draw a Rectangle around the Panels (When changing position)

                        /* Draw a final bound around the panel */
                        if (_bChangingPosition || _bSetPosition || _bSetSize)
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

        private void CountUnits_2()
        {
#if !DEBUG
            try
            {
#endif
                if (!_hMainHandler.GInformation.Gameinfo.IsIngame ||
                    _hMainHandler.GInformation.Player.Count <= 0 ||
                    _hMainHandler.GInformation.Unit.Count <= 0)
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

                for (var i = 0; i < _hMainHandler.GInformation.Player.Count; i++)
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

                for (var j = 0; j < _hMainHandler.GInformation.Unit.Count; j++)
                {
                    var tmpUnit = _hMainHandler.GInformation.Unit[j];

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
                            _lTuMule[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince/387328.0f));
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
                            _lPuForcefield[_hMainHandler.GInformation.Player.Count].UnitAmount += 1;
                            _lPuForcefield[_hMainHandler.GInformation.Player.Count].Id =
                                PredefinedData.UnitId.PuForceField;
                            _lPuForcefield[_hMainHandler.GInformation.Player.Count].AliveSince.Add(1 -
                                                                                                   (tmpUnit.AliveSince/
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
                                _lZuLocust[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince/113920f));

                            else
                                _lZuLocust[tmpUnit.Owner].AliveSince.Add(1 - (tmpUnit.AliveSince/73216f));
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

        private void SortConstructionStates(ref List<PredefinedData.UnitCount> lCounter)
        {
            for (var i = 0; i < lCounter.Count; i++)
            {
                lCounter[i].ConstructionState.Sort((x, y) => y.CompareTo(x));
            }
        }

        private void SortAliveSinceStates(ref List<PredefinedData.UnitCount> lCounter)
        {
            for (var i = 0; i < lCounter.Count; i++)
            {
                lCounter[i].AliveSince.Sort((x, y) => x.CompareTo(y));
            }
        }

        /* Gameheart stuff */
        private Boolean CheckIfGameheart(PredefinedData.PlayerStruct p)
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

        /* Draw the units */
        private void Helper_DrawUnits(PredefinedData.UnitCount unit, ref Int32 posX, Int32 posY, Int32 size, Image img,
                                      BufferedGraphics g, Color clPlayercolor, Font font, Boolean isStructure)
        {
            Int32 result = 0;
            float fWidthSize = 0f;

            /* Unitamount defines all buildings*/
            if (isStructure)
                unit.UnitAmount -= unit.UnitUnderConstruction;

            /* If there is nothing to draw.. */
            if (unit.UnitAmount == 0 && unit.UnitUnderConstruction == 0)
                return;

            /* Draw the actual image */
            g.Graphics.DrawImage(img, posX, posY, size, size);


            if (unit.UnitAmount > 0)
            {
                float fWidth;

                if (unit.UnitAmount.ToString(CultureInfo.InvariantCulture).Length == 1)
                    fWidth = unit.UnitAmount.ToString(CultureInfo.InvariantCulture).Length*(font.Size + 4);

                else
                    fWidth = unit.UnitAmount.ToString(CultureInfo.InvariantCulture).Length*(font.Size);

                fWidthSize = fWidth;

                #region Amount of Units

                HelpFunctions.HelpGraphics.FillRoundRectangle(g.Graphics,
                                                               new SolidBrush(Color.FromArgb(100, Color.Black)),
                                                               posX + 1, posY + 1, fWidth, font.Size + 9, 5);


                g.Graphics.DrawString(unit.UnitAmount.ToString(CultureInfo.InvariantCulture), font, Brushes.White,
                                      posX + 2,
                                      posY + 2);

                #endregion

                #region Energy

                #region Protoss

                if (unit.Id.Equals(PredefinedData.UnitId.PbNexus))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy / 4096;
                        var tmpRes = tmp/25;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                else if (unit.Id.Equals(PredefinedData.UnitId.PuHightemplar))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy / 4096;
                        var tmpRes = tmp / 75;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                else if (unit.Id.Equals(PredefinedData.UnitId.PuSentry))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy / 4096;
                        var tmpRes = tmp / 50;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                #endregion

                #region Terran

                else if (unit.Id.Equals(PredefinedData.UnitId.TuGhost))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy / 4096;
                        var tmpRes = tmp / 75;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                else if (unit.Id.Equals(PredefinedData.UnitId.TbOrbitalGround))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy / 4096;
                        var tmpRes = tmp / 50;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                #endregion

                #region Zerg

                else if (unit.Id.Equals(PredefinedData.UnitId.ZuViper))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy / 4096;
                        var tmpRes = tmp / 75;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                else if (unit.Id.Equals(PredefinedData.UnitId.ZuInfestor))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy / 4096;
                        var tmpRes = tmp / 75;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                #endregion

                #endregion
            }

            if (result > 0 && !_pSettings.UnitTabRemoveSpellCounter)
            {
                HelpFunctions.HelpGraphics.FillRoundRectangle(g.Graphics,
                    new SolidBrush(Color.FromArgb(100, Color.Black)),
                    posX + size -
                    TextRenderer.MeasureText(result.ToString(CultureInfo.InvariantCulture), font).Width,
                    posY + font.Size + 10, fWidthSize, font.Size + 9, 5);


                g.Graphics.DrawString(result.ToString(CultureInfo.InvariantCulture), font,
                    Brushes.DeepPink,
                    posX + size -
                    TextRenderer.MeasureText(result.ToString(CultureInfo.InvariantCulture), font).Width,
                    posY + font.Size + 9);
            }


            if (unit.UnitUnderConstruction > 0)
            {
                var bDraw = false;

                if (unit.SpeedMultiplier.Count > 0)
                {
                    /* If any of them is above 4069... */
                    foreach (var speed in unit.SpeedMultiplier)
                    {
                        if (speed > 4096)
                        {
                            bDraw = true;
                            break;
                        }
                    }
                }




                if (bDraw && !_pSettings.UnitTabRemoveChronoboost)
                {
                    HelpFunctions.HelpGraphics.FillRoundRectangle(g.Graphics,
                    new SolidBrush(Color.FromArgb(100, Color.White)),
                    posX + size - 22,
                    posY + 3, 19, 19, 5);
                    g.Graphics.DrawImage(_imgSpeedArrow, new Rectangle(posX + size - 20, posY + 5, 15, 15));
                }


                float fWidth;

                if (unit.UnitUnderConstruction.ToString(CultureInfo.InvariantCulture).Length == 1)
                    fWidth = unit.UnitUnderConstruction.ToString(CultureInfo.InvariantCulture).Length * (font.Size + 4);

                else
                    fWidth = unit.UnitUnderConstruction.ToString(CultureInfo.InvariantCulture).Length * (font.Size);

                HelpFunctions.HelpGraphics.FillRoundRectangle(g.Graphics,
                                                               new SolidBrush(Color.FromArgb(100, Color.Black)),
                                                               posX + 1, posY + font.Size + 10, fWidth, font.Size + 9, 5);


                g.Graphics.DrawString(unit.UnitUnderConstruction.ToString(CultureInfo.InvariantCulture), font,
                                      Brushes.Orange, posX + 2,
                                      posY + font.Size + 9);


                if (!_pSettings.UnitTabRemoveProdLine)
                {
                    /* Adjust relative size */
                    float ftemp = size - 4;

                    if (unit.ConstructionState.Count > 0)
                        ftemp *= (unit.ConstructionState[0]/100);

                    else
                        ftemp = 0;

                    

                    /* Draw status- line */
                    g.Graphics.DrawRectangle(new Pen(Brushes.Yellow, 1), posX + 2, posY + size - 5, (Int32)ftemp, 1);
                    g.Graphics.DrawRectangle(new Pen(Brushes.Black, 1), posX + 2, posY + size - 5, size - 3, 3);
                }

                
            }

            
            if ((unit.Id.Equals(PredefinedData.UnitId.TuMule) || unit.Id.Equals(PredefinedData.UnitId.PuForceField)) &&
                !_pSettings.UnitTabRemoveProdLine)
            {



                float ftemp = size - 4;
                ftemp *= (unit.AliveSince[0]);

                /* Draw status- line */
                g.Graphics.DrawRectangle(new Pen(Brushes.Yellow, 1), posX + 2, posY + size - 5, (Int32)ftemp, 1);
                g.Graphics.DrawRectangle(new Pen(Brushes.Black, 1), posX + 2, posY + size - 5, size - 3, 3);
            }

            


            g.Graphics.DrawRectangle(new Pen(new SolidBrush(clPlayercolor), 2), posX, posY, size, size);
            posX += size;
        }

        /* Draw the units */
        private void Helper_DrawUnitsProduction(PredefinedData.UnitCount unit, ref Int32 posX, Int32 posY, Int32 size, Image img,
                                      BufferedGraphics g, Color clPlayercolor, Font font, Boolean isStructure)
        {
            /* Unitamount defines all buildings*/
            if (isStructure)
                unit.UnitAmount -= unit.UnitUnderConstruction;

            /* If there is nothing to draw.. */
            if (unit.UnitUnderConstruction == 0)
                return;

            if (unit.ConstructionState == null)
                return;

            if (unit.ConstructionState.Count == 0)
                return;

            if (float.IsNaN(unit.ConstructionState[0]) ||
                unit.ConstructionState[0].Equals(0.0f))
                return;

            g.Graphics.DrawImage(img, posX, posY, size, size);


            //if (unit.UnitAmount > 0)
            //{
            //    float fWidth;

            //    if (unit.UnitAmount.ToString(CultureInfo.InvariantCulture).Length == 1)
            //        fWidth = unit.UnitAmount.ToString(CultureInfo.InvariantCulture).Length * (font.Size + 4);

            //    else
            //        fWidth = unit.UnitAmount.ToString(CultureInfo.InvariantCulture).Length * (font.Size);

            //    HelpFunctions.Help_Graphics.FillRoundRectangle(g.Graphics,
            //                                                   new SolidBrush(Color.FromArgb(100, Color.Black)),
            //                                                   posX + 1, posY + 1, fWidth, font.Size + 9, 5);


            //    g.Graphics.DrawString(unit.UnitAmount.ToString(CultureInfo.InvariantCulture), font, Brushes.White,
            //                          posX + 2,
            //                          posY + 2);

            //}

            if (unit.UnitUnderConstruction > 0)
            {
                var bDraw = false;

                if (unit.SpeedMultiplier.Count > 0)
                {
                    /* If any of them is above 4069... */
                    foreach (var speed in unit.SpeedMultiplier)
                    {
                        if (speed > 4096)
                        {
                            bDraw = true;
                            break;
                        }
                    }
                }


                if (bDraw && !_pSettings.ProdTabRemoveChronoboost)
                {
                    HelpFunctions.HelpGraphics.FillRoundRectangle(g.Graphics,
                    new SolidBrush(Color.FromArgb(100, Color.White)),
                    posX + size - 22,
                    posY + 3, 19, 19, 5);
                    g.Graphics.DrawImage(_imgSpeedArrow, new Rectangle(posX + size - 20, posY + 5, 15, 15));
                }


                float fWidth;

                if (unit.UnitUnderConstruction.ToString(CultureInfo.InvariantCulture).Length == 1)
                    fWidth = unit.UnitUnderConstruction.ToString(CultureInfo.InvariantCulture).Length*(font.Size + 4);

                else
                    fWidth = unit.UnitUnderConstruction.ToString(CultureInfo.InvariantCulture).Length*(font.Size);

                HelpFunctions.HelpGraphics.FillRoundRectangle(g.Graphics,
                    new SolidBrush(Color.FromArgb(100, Color.Black)),
                    posX + 1, posY + font.Size + 10, fWidth, font.Size + 9, 5);


                g.Graphics.DrawString(unit.UnitUnderConstruction.ToString(CultureInfo.InvariantCulture), font,
                    Brushes.Orange, posX + 2,
                    posY + font.Size + 9);



                /* Adjust relative size */
                float ftemp = size - 4;
                ftemp *= (unit.ConstructionState[0]/100);

                /* Draw status- line */
                g.Graphics.DrawRectangle(new Pen(Brushes.Yellow, 1), posX + 2, posY + size - 5, (Int32) ftemp, 1);
                g.Graphics.DrawRectangle(new Pen(Brushes.Black, 1), posX + 2, posY + size - 5, size - 3, 3);
            }


            g.Graphics.DrawRectangle(new Pen(new SolidBrush(clPlayercolor), 2), posX, posY, size, size);
            posX += size;
        }

        #region Drawing Methods

        /* Draw the curretn Resources */
        private void DrawResources(BufferedGraphics g)
        {

            try
            {
                
                if (!_hMainHandler.GInformation.Gameinfo.IsIngame)
                    return;

                var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;

                if (iValidPlayerCount == 0)
                    return;

                Opacity = _pSettings.ResourceOpacity;
                var iSingleHeight = Height/iValidPlayerCount;
                var fNewFontSize = (float) ((29.0/100)*iSingleHeight);
                var fInternalFont = new Font(_pSettings.ResourceFontName, fNewFontSize, FontStyle.Bold);
                var fInternalFontNormal = new Font(fInternalFont.Name, fNewFontSize, FontStyle.Regular);

                if (!_bChangingPosition)
                {
                    Height = _pSettings.ResourceHeight * iValidPlayerCount;
                    Width = _pSettings.ResourceWidth;

                    
                }

                var iCounter = 0;

                
                for (var i = 0; i < _hMainHandler.GInformation.Player.Count; i++)
                {
                    var clPlayercolor = _hMainHandler.GInformation.Player[i].Color;

                    #region Teamcolor

                    RendererHelper.TeamColor(_hMainHandler.GInformation.Player, i,
                                              _hMainHandler.GInformation.Gameinfo.IsTeamcolor, ref clPlayercolor);

                    #endregion

                    #region Escape sequences

                    if (_pSettings.ResourceRemoveAi)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue;
                    }

                    if (_pSettings.ResourceRemoveNeutral)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue;
                    }

                    if (_pSettings.ResourceRemoveAllie)
                    {
                        if (_hMainHandler.GInformation.Player[0].Localplayer == 16)
                        {
                            //Do nothing
                        }

                        else
                        {
                            if (_hMainHandler.GInformation.Player[i].Team ==
                                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[i].Localplayer].Team &&
                                !_hMainHandler.GInformation.Player[i].IsLocalplayer)
                                continue;
                        }
                    }

                    if (_pSettings.ResourceRemoveLocalplayer)
                    {
                        if (_hMainHandler.GInformation.Player[i].IsLocalplayer)
                            continue;
                    }



                    if (_hMainHandler.GInformation.Player[i].Name.StartsWith("\0") || _hMainHandler.GInformation.Player[i].NameLength <= 0)
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Hostile))
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Observer))
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Referee))
                        continue;

                    if (CheckIfGameheart(_hMainHandler.GInformation.Player[i]))
                        continue;

                    #endregion

                    #region SetValidImages (Race)

                    if (_hMainHandler.GInformation.Player[i].PlayerRace.Equals(PredefinedData.PlayerRace.Terran))
                    {
                        _imgMinerals = Properties.Resources.Mineral_Terran;
                        _imgGas = Properties.Resources.Gas_Terran;
                        _imgSupply = Properties.Resources.Supply_Terran;
                        _imgWorker = Properties.Resources.T_SCV;
                    }

                    else if (_hMainHandler.GInformation.Player[i].PlayerRace.Equals(PredefinedData.PlayerRace.Protoss))
                    {
                        _imgMinerals = Properties.Resources.Mineral_Protoss;
                        _imgGas = Properties.Resources.Gas_Protoss;
                        _imgSupply = Properties.Resources.Supply_Protoss;
                        _imgWorker = Properties.Resources.P_Probe;
                    }

                    else
                    {
                        _imgMinerals = Properties.Resources.Mineral_Zerg;
                        _imgGas = Properties.Resources.Gas_Zerg;
                        _imgSupply = Properties.Resources.Supply_Zerg;
                        _imgWorker = Properties.Resources.Z_Drone;
                    }

                    #endregion

                    #region Draw Bounds and Background

                    if (_pSettings.ResourceDrawBackground)
                    {
                        /* Background */
                        g.Graphics.FillRectangle(Brushes.Gray, 1, 1 + (iSingleHeight*iCounter), Width - 2,
                                                 iSingleHeight - 2);

                        /* Border */
                        g.Graphics.DrawRectangle(new Pen(new SolidBrush(clPlayercolor), 2), 1,
                                                 1 + (iSingleHeight*iCounter),
                                                 Width - 2, iSingleHeight - 2);
                    }

                    #endregion

                    #region Content Drawing

                    #region Name

                    var strName = (_hMainHandler.GInformation.Player[i].ClanTag.StartsWith("\0") || _pSettings.ResourceRemoveClanTag)
                                         ? _hMainHandler.GInformation.Player[i].Name
                                         : "[" + _hMainHandler.GInformation.Player[i].ClanTag + "] " + _hMainHandler.GInformation.Player[i].Name;

                    Drawing.DrawString(g.Graphics, strName, fInternalFont,
                        new SolidBrush(clPlayercolor),
                        Brushes.Black, (float) ((1.67/100)*Width),
                        (float) ((24.0/100)*iSingleHeight) + iSingleHeight*iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Team

                    Drawing.DrawString(g.Graphics, "#" + _hMainHandler.GInformation.Player[i].Team, fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float) ((29.67/100)*Width),
                        (float) ((24.0/100)*iSingleHeight) + iSingleHeight*iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Minerals

                    /* Icon */
                    Drawing.DrawImage(g.Graphics, _imgMinerals, (float) ((37.0/100)*Width),
                        (float) ((14.0/100)*iSingleHeight) + (Height/iValidPlayerCount)*iCounter,
                        (float) ((70.0/100)*iSingleHeight), (float) ((70.0/100)*iSingleHeight), Brushes.Black, 1f, 1f,
                        false);

                    Drawing.DrawString(g.Graphics,
                        _hMainHandler.GInformation.Player[i].Minerals.ToString(CultureInfo.InvariantCulture),
                        fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float) ((43.67/100)*Width),
                        (float) ((24.0/100)*iSingleHeight) + iSingleHeight*iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Gas

                    /* Icon */
                    Drawing.DrawImage(g.Graphics, _imgGas, (float) ((57.0/100)*Width),
                        (float) ((14.0/100)*iSingleHeight) + (Height/iValidPlayerCount)*iCounter,
                        (float) ((70.0/100)*iSingleHeight), (float) ((70.0/100)*iSingleHeight), Brushes.Black, 1f, 1f,
                        false);

                    Drawing.DrawString(g.Graphics,
                        _hMainHandler.GInformation.Player[i].Gas.ToString(CultureInfo.InvariantCulture),
                        fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float) ((63.67/100)*Width),
                        (float) ((24.0/100)*iSingleHeight) + iSingleHeight*iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Supply

                    /* Icon */
                    Drawing.DrawImage(g.Graphics, _imgSupply, (float) ((75.0/100)*Width),
                        (float) ((14.0/100)*iSingleHeight) + (Height/iValidPlayerCount)*iCounter,
                        (float) ((70.0/100)*iSingleHeight), (float) ((70.0/100)*iSingleHeight), Brushes.Black, 1f, 1f,
                        false);

                    Drawing.DrawString(g.Graphics,
                        _hMainHandler.GInformation.Player[i].SupplyMin.ToString(CultureInfo.InvariantCulture) + "/" +
                        _hMainHandler.GInformation.Player[i].SupplyMax,
                        fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float) ((81.67/100)*Width),
                        (float) ((24.0/100)*iSingleHeight) + iSingleHeight*iCounter,
                        1f, 1f, true);

                    #endregion

                    #endregion


                    iCounter++;
                }
            }

            catch (Exception ex)
            {
                Messages.LogFile("DrawResource", "Over all", ex);
            }
        }

        /* Draw Income */
        private void DrawIncome(BufferedGraphics g)
        {
            try
            {

                if (!_hMainHandler.GInformation.Gameinfo.IsIngame)
                    return;

                var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;

                if (iValidPlayerCount == 0)
                    return;

                Opacity = _pSettings.IncomeOpacity;
                var iSingleHeight = Height/iValidPlayerCount;
                var fNewFontSize = (float) ((29.0/100)*iSingleHeight);
                var fInternalFont = new Font(_pSettings.IncomeFontName, fNewFontSize, FontStyle.Bold);
                var fInternalFontNormal = new Font(fInternalFont.Name, fNewFontSize, FontStyle.Regular);

                if (!_bChangingPosition)
                {
                    Height = _pSettings.IncomeHeight * iValidPlayerCount;
                    Width = _pSettings.IncomeWidth;
                }

                var iCounter = 0;
                for (var i = 0; i < _hMainHandler.GInformation.Player.Count; i++)
                {
                    var clPlayercolor = _hMainHandler.GInformation.Player[i].Color;

                    #region Teamcolor

                    RendererHelper.TeamColor(_hMainHandler.GInformation.Player, i,
                                              _hMainHandler.GInformation.Gameinfo.IsTeamcolor, ref clPlayercolor);

                    #endregion

                    #region Escape sequences

                    if (_pSettings.IncomeRemoveAi)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue;
                    }

                    if (_pSettings.IncomeRemoveNeutral)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue;
                    }

                    if (_pSettings.IncomeRemoveAllie)
                    {
                        if (_hMainHandler.GInformation.Player[0].Localplayer == 16)
                        {
                            //Do nothing
                        }

                        else
                        {
                            if (_hMainHandler.GInformation.Player[i].Team ==
                                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[i].Localplayer].Team &&
                                !_hMainHandler.GInformation.Player[i].IsLocalplayer)
                                continue;
                        }
                    }

                    if (_pSettings.IncomeRemoveLocalplayer)
                    {
                        if (_hMainHandler.GInformation.Player[i].IsLocalplayer)
                            continue;
                    }

                    if (_hMainHandler.GInformation.Player[i].Name.StartsWith("\0") || _hMainHandler.GInformation.Player[i].NameLength <= 0)
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Hostile))
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Observer))
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Referee))
                        continue;

                    if (CheckIfGameheart(_hMainHandler.GInformation.Player[i]))
                        continue;

                    #endregion

                    #region SetValidImages (Race)

                    if (_hMainHandler.GInformation.Player[i].PlayerRace.Equals(PredefinedData.PlayerRace.Terran))
                    {
                        _imgMinerals = Properties.Resources.Mineral_Terran;
                        _imgGas = Properties.Resources.Gas_Terran;
                        _imgSupply = Properties.Resources.Supply_Terran;
                        _imgWorker = Properties.Resources.T_SCV;
                    }

                    else if (_hMainHandler.GInformation.Player[i].PlayerRace.Equals(PredefinedData.PlayerRace.Protoss))
                    {
                        _imgMinerals = Properties.Resources.Mineral_Protoss;
                        _imgGas = Properties.Resources.Gas_Protoss;
                        _imgSupply = Properties.Resources.Supply_Protoss;
                        _imgWorker = Properties.Resources.P_Probe;
                    }

                    else
                    {
                        _imgMinerals = Properties.Resources.Mineral_Zerg;
                        _imgGas = Properties.Resources.Gas_Zerg;
                        _imgSupply = Properties.Resources.Supply_Zerg;
                        _imgWorker = Properties.Resources.Z_Drone;
                    }

                    #endregion

                    #region Draw Bounds and Background

                    if (_pSettings.IncomeDrawBackground)
                    {
                        /* Background */
                        g.Graphics.FillRectangle(Brushes.Gray, 1, 1 + (iSingleHeight*iCounter), Width - 2,
                                                 iSingleHeight - 2);

                        /* Border */
                        g.Graphics.DrawRectangle(new Pen(new SolidBrush(clPlayercolor), 2), 1,
                                                 1 + (iSingleHeight*iCounter),
                                                 Width - 2, iSingleHeight - 2);
                    }


                    #endregion

                    #region Content Drawing

                    #region Name

                    var strName = (_hMainHandler.GInformation.Player[i].ClanTag.StartsWith("\0") || _pSettings.IncomeRemoveClanTag)
                                         ? _hMainHandler.GInformation.Player[i].Name
                                         : "[" + _hMainHandler.GInformation.Player[i].ClanTag + "] " + _hMainHandler.GInformation.Player[i].Name;


                    Drawing.DrawString(g.Graphics, strName, fInternalFont,
                        new SolidBrush(clPlayercolor),
                        Brushes.Black, (float) ((1.67/100)*Width),
                        (float) ((24.0/100)*iSingleHeight) + iSingleHeight*iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Team

                    Drawing.DrawString(g.Graphics, "#" + _hMainHandler.GInformation.Player[i].Team, fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float) ((29.67/100)*Width),
                        (float) ((24.0/100)*iSingleHeight) + iSingleHeight*iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Minerals

                    /* Icon */
                    g.Graphics.DrawImage(_imgMinerals, (float) ((37.0/100)*Width),
                                         (float) ((14.0/100)*iSingleHeight) + (Height/iValidPlayerCount)*iCounter,
                                         (float) ((70.0/100)*iSingleHeight), (float) ((70.0/100)*iSingleHeight));

                    /* Mineral Count */
                    Drawing.DrawString(g.Graphics,
                        _hMainHandler.GInformation.Player[i].MineralsIncome.ToString(CultureInfo.InvariantCulture),
                        fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float) ((43.67/100)*Width),
                        (float) ((24.0/100)*iSingleHeight) + iSingleHeight*iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Gas

                    /* Icon */
                    g.Graphics.DrawImage(_imgGas, (float) ((57.0/100)*Width),
                                         (float) ((14.0/100)*iSingleHeight) + (Height/iValidPlayerCount)*iCounter,
                                         (float) ((70.0/100)*iSingleHeight), (float) ((70.0/100)*iSingleHeight));

                    /* Gas Count */
                    Drawing.DrawString(g.Graphics,
                        _hMainHandler.GInformation.Player[i].GasIncome.ToString(CultureInfo.InvariantCulture),
                        fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((63.67 / 100) * Width),
                                          (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Workers

                    /* Icon */
                    g.Graphics.DrawImage(_imgWorker, (float) ((75.0/100)*Width),
                        (float) ((14.0/100)*iSingleHeight) + (Height/iValidPlayerCount)*iCounter,
                        (float)((70.0 / 100) * iSingleHeight), (float)((70.0 / 100) * iSingleHeight));

                    /* Worker Count */
                    Drawing.DrawString(g.Graphics,
                        _hMainHandler.GInformation.Player[i].Worker.ToString(CultureInfo.InvariantCulture),
                        fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((81.67 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #endregion


                    iCounter++;
                }
            }

            catch (Exception ex)
            {
                Messages.LogFile("DrawIncome", "Over all", ex);
            }
        }

        /* Draw Army */
        private void DrawArmy(BufferedGraphics g)
        {
            try
            {

                if (!_hMainHandler.GInformation.Gameinfo.IsIngame)
                    return;

                var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;

                if (iValidPlayerCount == 0)
                    return;

                Opacity = _pSettings.ArmyOpacity;
                var iSingleHeight = Height/iValidPlayerCount;
                var fNewFontSize = (float) ((29.0/100)*iSingleHeight);
                var fInternalFont = new Font(_pSettings.ArmyFontName, fNewFontSize, FontStyle.Bold);
                var fInternalFontNormal = new Font(fInternalFont.Name, fNewFontSize, FontStyle.Regular);

                if (!_bChangingPosition)
                {
                    Height = _pSettings.ArmyHeight * iValidPlayerCount;
                    Width = _pSettings.ArmyWidth;
                }

                var iCounter = 0;
                for (var i = 0; i < _hMainHandler.GInformation.Player.Count; i++)
                {
                    var clPlayercolor = _hMainHandler.GInformation.Player[i].Color;

                    #region Teamcolor

                    RendererHelper.TeamColor(_hMainHandler.GInformation.Player, i,
                                              _hMainHandler.GInformation.Gameinfo.IsTeamcolor, ref clPlayercolor);

                    #endregion

                    #region Escape sequences

                    if (_pSettings.ArmyRemoveAi)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue;
                    }

                    if (_pSettings.ArmyRemoveNeutral)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue;
                    }

                    if (_pSettings.ArmyRemoveAllie)
                    {
                        if (_hMainHandler.GInformation.Player[0].Localplayer == 16)
                        {
                            //Do nothing
                        }

                        else
                        {
                            if (_hMainHandler.GInformation.Player[i].Team ==
                                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[i].Localplayer].Team &&
                                !_hMainHandler.GInformation.Player[i].IsLocalplayer)
                                continue;
                        }
                    }

                    if (_pSettings.ArmyRemoveLocalplayer)
                    {
                        if (_hMainHandler.GInformation.Player[i].IsLocalplayer)
                            continue;
                    }

                    if (_hMainHandler.GInformation.Player[i].Name.StartsWith("\0") || _hMainHandler.GInformation.Player[i].NameLength <= 0)
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Hostile))
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Observer))
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Referee))
                        continue;

                    if (CheckIfGameheart(_hMainHandler.GInformation.Player[i]))
                        continue;

                    #endregion

                    #region SetValidImages (Race)

                    if (_hMainHandler.GInformation.Player[i].PlayerRace.Equals(PredefinedData.PlayerRace.Terran))
                    {
                        _imgMinerals = Properties.Resources.Mineral_Terran;
                        _imgGas = Properties.Resources.Gas_Terran;
                        _imgSupply = Properties.Resources.Supply_Terran;
                        _imgWorker = Properties.Resources.T_SCV;
                    }

                    else if (_hMainHandler.GInformation.Player[i].PlayerRace.Equals(PredefinedData.PlayerRace.Protoss))
                    {
                        _imgMinerals = Properties.Resources.Mineral_Protoss;
                        _imgGas = Properties.Resources.Gas_Protoss;
                        _imgSupply = Properties.Resources.Supply_Protoss;
                        _imgWorker = Properties.Resources.P_Probe;
                    }

                    else
                    {
                        _imgMinerals = Properties.Resources.Mineral_Zerg;
                        _imgGas = Properties.Resources.Gas_Zerg;
                        _imgSupply = Properties.Resources.Supply_Zerg;
                        _imgWorker = Properties.Resources.Z_Drone;
                    }

                    #endregion

                    #region Draw Bounds and Background

                    if (_pSettings.ArmyDrawBackground)
                    {
                        /* Background */
                        g.Graphics.FillRectangle(Brushes.Gray, 1, 1 + (iSingleHeight*iCounter), Width - 2,
                                                 iSingleHeight - 2);

                        /* Border */
                        g.Graphics.DrawRectangle(new Pen(new SolidBrush(clPlayercolor), 2), 1,
                                                 1 + (iSingleHeight*iCounter),
                                                 Width - 2, iSingleHeight - 2);
                    }

                    #endregion

                    #region Content Drawing

                    #region Name

                    var strName = (_hMainHandler.GInformation.Player[i].ClanTag.StartsWith("\0") || _pSettings.ArmyRemoveClanTag)
                                         ? _hMainHandler.GInformation.Player[i].Name
                                         : "[" + _hMainHandler.GInformation.Player[i].ClanTag + "] " + _hMainHandler.GInformation.Player[i].Name;

                    Drawing.DrawString(g.Graphics,
                        strName,
                        fInternalFont,
                        new SolidBrush(clPlayercolor),
                        Brushes.Black, (float) ((1.67/100)*Width),
                        (float) ((24.0/100)*iSingleHeight) + iSingleHeight*iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Team

                    Drawing.DrawString(g.Graphics,
                        "#" + _hMainHandler.GInformation.Player[i].Team, fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float) ((29.67/100)*Width),
                        (float) ((24.0/100)*iSingleHeight) + iSingleHeight*iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Minerals

                    /* Icon */
                    g.Graphics.DrawImage(_imgMinerals, (float) ((37.0/100)*Width),
                                         (float) ((14.0/100)*iSingleHeight) + (Height/iValidPlayerCount)*iCounter,
                                         (float) ((70.0/100)*iSingleHeight), (float) ((70.0/100)*iSingleHeight));

                    /* Mineral Count */
                    Drawing.DrawString(g.Graphics,
                        _hMainHandler.GInformation.Player[i].MineralsArmy.ToString(CultureInfo.InvariantCulture), fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((43.67 / 100) * Width),
                                          (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Gas

                    /* Icon */
                    g.Graphics.DrawImage(_imgGas, (float) ((57.0/100)*Width),
                                         (float) ((14.0/100)*iSingleHeight) + (Height/iValidPlayerCount)*iCounter,
                                         (float) ((70.0/100)*iSingleHeight), (float) ((70.0/100)*iSingleHeight));

                    /* Gas Count */
                    Drawing.DrawString(g.Graphics,
                        _hMainHandler.GInformation.Player[i].GasArmy.ToString(CultureInfo.InvariantCulture), fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((63.67 / 100) * Width),
                                          (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Supply

                    /* Icon */
                    g.Graphics.DrawImage(_imgSupply, (float) ((75.0/100)*Width),
                                         (float) ((14.0/100)*iSingleHeight) + (Height/iValidPlayerCount)*iCounter,
                                         (float) ((70.0/100)*iSingleHeight), (float) ((70.0/100)*iSingleHeight));

                    /* Mineral Count */
                    Drawing.DrawString(g.Graphics,
                        (_hMainHandler.GInformation.Player[i].ArmySupply).ToString(CultureInfo.InvariantCulture) + " / " +
                        _hMainHandler.GInformation.Player[i].SupplyMax, fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((81.67 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #endregion


                    iCounter++;
                }
            }

            catch (Exception ex)
            {
                Messages.LogFile("DrawArmy", "Over all", ex);
            }
        }

        /* Draw Apm */
        private void DrawApm(BufferedGraphics g)
        {
            try
            {

           

                if (!_hMainHandler.GInformation.Gameinfo.IsIngame)
                    return;

                var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;

                if (iValidPlayerCount == 0)
                    return;

                Opacity = _pSettings.ApmOpacity;
                var iSingleHeight = Height/iValidPlayerCount;
                var fNewFontSize = (float) ((29.0/100)*iSingleHeight);
                var fInternalFont = new Font(_pSettings.ApmFontName, fNewFontSize, FontStyle.Bold);
                var fInternalFontNormal = new Font(fInternalFont.Name, fNewFontSize, FontStyle.Regular);

                if (!_bChangingPosition)
                {
                    Height = _pSettings.ApmHeight * iValidPlayerCount;
                    Width = _pSettings.ApmWidth;
                }

                var iCounter = 0;
                for (var i = 0; i < _hMainHandler.GInformation.Player.Count; i++)
                {
                    var clPlayercolor = _hMainHandler.GInformation.Player[i].Color;

                    #region Teamcolor

                    RendererHelper.TeamColor(_hMainHandler.GInformation.Player, i,
                                              _hMainHandler.GInformation.Gameinfo.IsTeamcolor, ref clPlayercolor);

                    #endregion

                    #region Escape sequences

                    if (_hMainHandler.GInformation.Player[i].Name.StartsWith("\0") || _hMainHandler.GInformation.Player[i].NameLength <= 0)
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Hostile))
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Observer))
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Referee))
                        continue;

                    if (CheckIfGameheart(_hMainHandler.GInformation.Player[i]))
                        continue;

                    


                    if (_pSettings.ApmRemoveAi)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue;
                    }

                    if (_pSettings.ApmRemoveNeutral)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue;
                    }

                    if (_pSettings.ApmRemoveAllie)
                    {
                        if (_hMainHandler.GInformation.Player[0].Localplayer == 16)
                        {
                            //Do nothing
                        }

                        else
                        {
                            if (_hMainHandler.GInformation.Player[i].Team ==
                                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[i].Localplayer].Team &&
                                !_hMainHandler.GInformation.Player[i].IsLocalplayer)
                                continue;
                        }
                    }

                    if (_pSettings.ApmRemoveLocalplayer)
                    {
                        if (_hMainHandler.GInformation.Player[i].IsLocalplayer)
                            continue;
                    }

                    

                    #endregion

                    #region Draw Bounds and Background

                    if (_pSettings.ApmDrawBackground)
                    {
                        /* Background */
                        g.Graphics.FillRectangle(Brushes.Gray, 1, 1 + (iSingleHeight*iCounter), Width - 2,
                                                 iSingleHeight - 2);

                        /* Border */
                        g.Graphics.DrawRectangle(new Pen(new SolidBrush(clPlayercolor), 2), 1,
                                                 1 + (iSingleHeight*iCounter),
                                                 Width - 2, iSingleHeight - 2);
                    }

                    #endregion

                    #region Content Drawing

                    #region Name

                    var strName = (_hMainHandler.GInformation.Player[i].ClanTag.StartsWith("\0") || _pSettings.ApmRemoveClanTag)
                                         ? _hMainHandler.GInformation.Player[i].Name
                                         : "[" + _hMainHandler.GInformation.Player[i].ClanTag + "] " + _hMainHandler.GInformation.Player[i].Name;

                    Drawing.DrawString(g.Graphics,
                        strName,
                        fInternalFont,
                        new SolidBrush(clPlayercolor),
                        Brushes.Black, (float) ((1.67/100)*Width),
                        (float) ((24.0/100)*iSingleHeight) + iSingleHeight*iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Team

                    Drawing.DrawString(g.Graphics,
                        "#" + _hMainHandler.GInformation.Player[i].Team, fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float) ((29.67/100)*Width),
                        (float) ((24.0/100)*iSingleHeight) + iSingleHeight*iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Apm

                    Drawing.DrawString(g.Graphics,
                        "APM: " + _hMainHandler.GInformation.Player[i].ApmAverage +
                        " [" + _hMainHandler.GInformation.Player[i].Apm + "]", fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float) ((37.0/100)*Width),
                        (float) ((24.0/100)*iSingleHeight) + iSingleHeight*iCounter,
                        1f, 1f, true);


                    #endregion

                    #region Epm

                    Drawing.DrawString(g.Graphics,
                       "EPM: " + _hMainHandler.GInformation.Player[i].EpmAverage +
                        " [" + _hMainHandler.GInformation.Player[i].Epm + "]", fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((63.67 / 100) * Width),
                                          (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #endregion


                    iCounter++;
                }

            }

            catch (Exception ex)
            {
                Messages.LogFile("DrawApm", "Over all", ex);
            }

        }

        /* Draw Worker */
        private void DrawWorker(BufferedGraphics g)
        {
            try
            {

                if (!_hMainHandler.GInformation.Gameinfo.IsIngame)
                {
                    g.Graphics.Clear(BackColor);
                    return;
                }

                if (_hMainHandler.GInformation.Player == null || 
                    _hMainHandler.GInformation.Player.Count <= 0)
                    return;

                Opacity = _pSettings.WorkerOpacity;
                var iSingleHeight = Height;
                var fNewFontSize = (float) ((29.0/100)*iSingleHeight);
                var fInternalFont = new Font(_pSettings.WorkerFontName, fNewFontSize, FontStyle.Bold);

                Color clPlayercolor;

                if (_hMainHandler.GInformation.Player[0].Localplayer < _hMainHandler.GInformation.Player.Count)
                    clPlayercolor = _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Color;

                else
                    return;

                if (!_bChangingPosition)
                {
                    Height = _pSettings.WorkerHeight;
                    Width = _pSettings.WorkerWidth;
                }

                #region Teamcolor

                if (_hMainHandler.GInformation.Gameinfo.IsTeamcolor)
                    clPlayercolor = Color.Green;

                #endregion

                #region Draw Bounds and Background

                if (_pSettings.WorkerDrawBackground)
                {
                    /* Background */
                    g.Graphics.FillRectangle(Brushes.Gray, 1, 1, Width - 2, iSingleHeight - 2);

                    /* Border */
                    g.Graphics.DrawRectangle(new Pen(new SolidBrush(clPlayercolor), 2), 1, 1, Width - 2,
                                             iSingleHeight - 2);
                }

                #endregion

                #region Worker

                Drawing.DrawString(g.Graphics,
                        _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Worker + "   Workers",
                        fInternalFont,
                        new SolidBrush(clPlayercolor),
                        Brushes.Black, (float)((16.67 / 100) * Width),
                                      (float)((24.0 / 100) * iSingleHeight),
                        1f, 1f, true);

                #endregion

            }

            catch (Exception ex)
            {
                Messages.LogFile("DrawWorker", "Over all", ex);
            }
        }

        /* Imitates the Minimap */
        private void DrawMinimap(BufferedGraphics g)
        {
            try
            {
            
                if (!_hMainHandler.GInformation.Gameinfo.IsIngame)
                {
                    g.Graphics.Clear(Color.White);
                    g.Graphics.Clear(BackColor);
                    return;
                }

                Opacity = _pSettings.MaphackOpacity;

                if (!_bChangingPosition)
                {
                    Height = _pSettings.MaphackHeight;
                    Width = _pSettings.MaphackWidth;
                }

                var tmpMap = _hMainHandler.GInformation.Map;

                #region Introduction

                #region Variables

                float fScale,
                      fX,
                      fY;

                #endregion

                #region Get minimap Bounds

                var fa = Height/(float) Width;
                var fb = ((float)tmpMap.PlayableHeight / tmpMap.PlayableWidth);

                if (fa >= fb)
                {
                    fScale = (float)Width / tmpMap.PlayableWidth;
                    fX = 0;
                    fY = (Height - fScale * tmpMap.PlayableHeight) / 2;
                }
                else
                {
                    fScale = (float)Height / tmpMap.PlayableHeight;
                    fY = 0;
                    fX = (Width - fScale * tmpMap.PlayableWidth) / 2;
                }



                #endregion

                #region Draw Bounds

                if (!_pSettings.MaphackRemoveVisionArea)
                {
                    /* Draw Rectangle */
                    g.Graphics.DrawRectangle(Constants.PBound, 0, 0, Width - Constants.PBound.Width,
                                             Height - Constants.PBound.Width);

                    /* Draw Playable Area */
                    g.Graphics.DrawRectangle(Constants.PArea, fX, fY, Width - fX*2 - Constants.PArea.Width,
                                             Height - fY*2 - Constants.PArea.Width);
                }

                #endregion

                #endregion

                #region Actual Drawing

                #region Draw Unit- destination

                if (!_pSettings.MaphackDisableDestinationLine)
                {
                    for (var i = 0; i < _hMainHandler.GInformation.Unit.Count; i++)
                    {
                        var clDestination = _pSettings.MaphackDestinationColor;

                        var tmpUnit = _hMainHandler.GInformation.Unit[i];


                        

                        #region Escape Sequences


                        /* Ai */
                        if (_pSettings.MaphackRemoveAi)
                        {
                            if (
                                _hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(
                                    PredefinedData.PlayerType.Ai))
                                continue;
                        }

                        /* Allie */
                        if (_pSettings.MaphackRemoveAllie)
                        {
                            if (_hMainHandler.GInformation.Player[0].Localplayer < _hMainHandler.GInformation.Player.Count)
                            {
                                if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Team ==
                                    _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Team &&
                                    !_hMainHandler.GInformation.Player[tmpUnit.Owner].IsLocalplayer)
                                    continue;
                            }
                        }

                        /* Localplayer Units */
                        if (_pSettings.MaphackRemoveLocalplayer)
                        {
                            if (tmpUnit.Owner == _hMainHandler.GInformation.Player[0].Localplayer)
                                continue;
                        }

                        /* Neutral Units */
                        if (_pSettings.MaphackRemoveNeutral)
                        {
                            if (
                                _hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(
                                    PredefinedData.PlayerType.Neutral))
                                continue;
                        }

                        /* Dead Units */
                        if ((tmpUnit.TargetFilter & (ulong) PredefinedData.TargetFilterFlag.Dead) > 0)
                            continue;


                        /* Moving- state */
                        if (tmpUnit.Movestate.Equals(0))
                            continue;




                        #endregion

                        #region Scalling (Unitposition + UnitDestination)

                        var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
                        var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;

                        var iUnitDestPosX = (tmpUnit.DestinationPositionX - tmpMap.Left) * fScale +
                                            fX;
                        var iUnitDestPosY = (tmpMap.Top - tmpUnit.DestinationPositionY) * fScale +
                                            fY;

                        if (float.IsNaN(iUnitPosX) ||
                            float.IsNaN(iUnitPosY) ||
                            float.IsNaN(iUnitDestPosX) ||
                            float.IsNaN(iUnitDestPosY))
                        {
                            continue;
                        }


                        #endregion

                        g.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                        g.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                        /* Draws the Line */
                        if (tmpUnit.DestinationPositionX > 10 &&
                            tmpUnit.DestinationPositionY > 10)
                            g.Graphics.DrawLine(new Pen(new SolidBrush(clDestination)), iUnitPosX, iUnitPosY,
                                                iUnitDestPosX,
                                                iUnitDestPosY);

                        g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
                        g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                        g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;

                    }
                }

                #endregion

                #region Draw Creeptumors

                for (var i = 0; i < _hMainHandler.GInformation.Unit.Count; i++)
                {
                    var tmpUnit = _hMainHandler.GInformation.Unit[i];

                    #region Exceptions

                    /* Ai */
                    if (_pSettings.MaphackRemoveAi)
                    {
                        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue; //clUnitBoundBorder = Color.Transparent;

                    }

                    /* Allie */
                    if (_pSettings.MaphackRemoveAllie)
                    {
                        if (_hMainHandler.GInformation.Player[0].Localplayer < _hMainHandler.GInformation.Player.Count)
                        {
                            if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Team ==
                                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Team &&
                                !_hMainHandler.GInformation.Player[tmpUnit.Owner].IsLocalplayer)
                                continue; //clUnitBoundBorder = Color.Transparent;

                        }
                    }

                    /* Localplayer Units */
                    if (_pSettings.MaphackRemoveLocalplayer)
                    {
                        if (tmpUnit.Owner == _hMainHandler.GInformation.Player[0].Localplayer)
                            continue; //clUnitBoundBorder = Color.Transparent;

                    }

                    /* Neutral Units */
                    if (_pSettings.MaphackRemoveNeutral)
                    {
                        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue; //clUnitBoundBorder = Color.Transparent;

                    }

                    /* Dead Units */
                    if ((tmpUnit.TargetFilter & (ulong)PredefinedData.TargetFilterFlag.Dead) > 0)
                        continue;

                    #endregion

                    #region Actual Drawing


                    if (tmpUnit.Id == PredefinedData.UnitId.ZbCreeptumor ||
                        tmpUnit.Id == PredefinedData.UnitId.ZbCreepTumorBuilding ||
                        tmpUnit.Id == PredefinedData.UnitId.ZbCreepTumorMissle ||
                        tmpUnit.Id == PredefinedData.UnitId.ZbCreeptumorBurrowed)
                        {

                            #region Scalling (Unitposition)

                            var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
                            var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;

                            if (float.IsNaN(iUnitPosX) ||
                                float.IsNaN(iUnitPosY))
                            {
                                continue;
                            }


                            #endregion


                            const Int32 iRadius = 4;


                            

                          
                            g.Graphics.DrawLine(Constants.PBlack2, iUnitPosX - iRadius, iUnitPosY - iRadius, iUnitPosX + iRadius, iUnitPosY + iRadius);
                            g.Graphics.DrawLine(Constants.PBlack2, iUnitPosX + iRadius, iUnitPosY - iRadius, iUnitPosX - iRadius, iUnitPosY + iRadius);


                        }
                    

                    #endregion

                }

                #endregion

                #region Draw Unit (Border/ outer Rectangle)

                for (var i = 0; i < _hMainHandler.GInformation.Unit.Count; i++)
                {
                    var tmpUnit = _hMainHandler.GInformation.Unit[i];
                    var clUnitBound = Color.Black;

                    if (tmpUnit.Owner >= (_hMainHandler.GInformation.Player.Count))
                        continue;


                    #region Escape Sequences

                    /* Ai */
                    if (_pSettings.MaphackRemoveAi)
                    {
                        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue;
                    }

                    /* Allie */
                    if (_pSettings.MaphackRemoveAllie)
                    {
                        if (_hMainHandler.GInformation.Player[0].Localplayer < _hMainHandler.GInformation.Player.Count)
                        {
                            if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Team ==
                                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Team &&
                                !_hMainHandler.GInformation.Player[tmpUnit.Owner].IsLocalplayer)
                                continue;
                        }
                    }

                    /* Localplayer Units */
                    if (_pSettings.MaphackRemoveLocalplayer)
                    {
                        if (tmpUnit.Owner == _hMainHandler.GInformation.Player[0].Localplayer)
                            continue;
                    }

                    /* Neutral Units */
                    if (_pSettings.MaphackRemoveNeutral)
                    {
                        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue;
                    }


                    /* Dead Units */
                    if ((tmpUnit.TargetFilter & (ulong) PredefinedData.TargetFilterFlag.Dead) > 0)
                        continue;

                    /* Creep tumor */
                    if (tmpUnit.Id ==
                        PredefinedData.UnitId.ZbCreeptumorBurrowed)
                        continue;




                    #endregion

                    #region Scalling (Unitposition)

                    var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
                    var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;

                    if (float.IsNaN(iUnitPosX) ||
                        float.IsNaN(iUnitPosY))
                    {
                        continue;
                    }


                    #endregion

                    

                    var fUnitSize = tmpUnit.Size;
                    var size = 2.0f;

                    if (fUnitSize >= 0.5)
                        size = 3;

                    if (fUnitSize >= 0.875)
                        size = 4;

                    if (fUnitSize >= 1.5)
                        size = 6;

                    if (fUnitSize >= 2.0)
                        size = 8;

                    if (fUnitSize >= 2.5)
                        size = 10;

                    size += 0.5f;


                    #region Actual drawing

                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

                    if (tmpUnit.IsCloaked && 
                        tmpUnit.Id != PredefinedData.UnitId.ZbCreeptumorBurrowed)
                    {
                        g.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Gray)), iUnitPosX - size/2,
                                                 iUnitPosY - size/2, size, size);

                        g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBound)), iUnitPosX - size/2 - 0.5f,
                                                 iUnitPosY - size/2 - 0.5f, size + 1, size + 1);
                    }

                    else
                    {
                        g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBound)), iUnitPosX - size/2,
                                                 iUnitPosY - size/2, size, size);
                    }

                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

                    #endregion
                }

                #endregion

                #region Draw Unit (Inner Rectangle)

                for (var i = 0; i < _hMainHandler.GInformation.Unit.Count; i++)
                {
                    var tmpUnit = _hMainHandler.GInformation.Unit[i];
                    //Color clUnit = LUnit[i].Owner > LPlayer.Count ? Color.Transparent : LPlayer[LUnit[i].Owner].Color;

                    if (tmpUnit.Owner >= _hMainHandler.GInformation.Player.Count)
                        continue;


                    var clUnit = _hMainHandler.GInformation.Player[tmpUnit.Owner].Color;
                   
                    #region Teamcolor
                    
                    RendererHelper.TeamColor(_hMainHandler.GInformation.Player, _hMainHandler.GInformation.Unit, i,
                                              _hMainHandler.GInformation.Gameinfo.IsTeamcolor, ref clUnit);

                    #endregion

                    #region Scalling (Unitposition)

                    var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left)*fScale + fX;
                    var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY)*fScale + fY;


                    if (float.IsNaN(iUnitPosX) ||
                        float.IsNaN(iUnitPosY))
                    {
                        continue;
                    }

                    #endregion

                    #region Escape Sequences

                    /* Ai */
                    if (_pSettings.MaphackRemoveAi)
                    {
                        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue;
                    }

                    /* Allie */
                    if (_pSettings.MaphackRemoveAllie)
                    {
                        if (_hMainHandler.GInformation.Player[0].Localplayer < _hMainHandler.GInformation.Player.Count)
                        {
                            if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Team ==
                                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Team &&
                                !_hMainHandler.GInformation.Player[tmpUnit.Owner].IsLocalplayer)
                                continue;
                        }
                    }

                    /* Localplayer Units */
                    if (_pSettings.MaphackRemoveLocalplayer)
                    {
                        if (tmpUnit.Owner == _hMainHandler.GInformation.Player[0].Localplayer)
                            continue;
                    }

                    /* Neutral Units */
                    if (_pSettings.MaphackRemoveNeutral)
                    {
                        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue;
                    }


                    /* Dead Units */
                    if ((tmpUnit.TargetFilter & (ulong) PredefinedData.TargetFilterFlag.Dead) > 0)
                        continue;

                    /* Creep tumor */
                    if (tmpUnit.Id ==
                         PredefinedData.UnitId.ZbCreeptumorBurrowed)
                        continue;




                    #endregion

                    var fUnitSize = tmpUnit.Size;
                    var size = 2.0f;

                    if (fUnitSize >= 0.5f)
                        size = 3;

                    if (fUnitSize >= 0.875)
                        size = 4;

                    if (fUnitSize >= 1.5)
                        size = 6;

                    if (fUnitSize >= 2.0)
                        size = 8;

                    if (fUnitSize >= 2.5)
                        size = 10;

                    size -= 0.5f;


                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

                    /* Draw the Unit (Actual Unit) */
                    g.Graphics.FillRectangle(new SolidBrush(clUnit), iUnitPosX - size/2, iUnitPosY - size/2, size, size);

                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

                }

                #endregion

                #region Draw Border of special Units

                for (var i = 0; i < _hMainHandler.GInformation.Unit.Count; i++)
                {
                    var tmpUnit = _hMainHandler.GInformation.Unit[i];
                    var clUnitBoundBorder = Color.Black;

                    if (tmpUnit.Owner >= (_hMainHandler.GInformation.Player.Count))
                        continue;


                    #region Scalling (Unitposition)

                    var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left)*fScale + fX;
                    var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY)*fScale + fY;


                    if (float.IsNaN(iUnitPosX) ||
                        float.IsNaN(iUnitPosY))
                    {
                        continue;
                    }

                    #endregion

                    #region Escape Sequences

                    /* Ai */
                    if (_pSettings.MaphackRemoveAi)
                    {
                        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue; //clUnitBoundBorder = Color.Transparent;

                    }

                    /* Allie */
                    if (_pSettings.MaphackRemoveAllie)
                    {
                        if (_hMainHandler.GInformation.Player[0].Localplayer < _hMainHandler.GInformation.Player.Count)
                        {
                            if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Team ==
                                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Team &&
                                !_hMainHandler.GInformation.Player[tmpUnit.Owner].IsLocalplayer)
                                continue; //clUnitBoundBorder = Color.Transparent;

                        }
                    }

                    /* Localplayer Units */
                    if (_pSettings.MaphackRemoveLocalplayer)
                    {
                        if (tmpUnit.Owner == _hMainHandler.GInformation.Player[0].Localplayer)
                            continue; //clUnitBoundBorder = Color.Transparent;

                    }

                    /* Neutral Units */
                    if (_pSettings.MaphackRemoveNeutral)
                    {
                        if (_hMainHandler.GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue; //clUnitBoundBorder = Color.Transparent;

                    }


                    /* Dead Units */
                    if ((tmpUnit.TargetFilter & (ulong) PredefinedData.TargetFilterFlag.Dead) > 0)
                        continue;






                    #endregion


                    var fUnitSize = tmpUnit.Size;
                    var size = 2.0f;

                    if (fUnitSize >= 0.875)
                        size = 4;

                    if (fUnitSize >= 1.5)
                        size = 6;

                    if (fUnitSize >= 2.0)
                        size = 8;

                    if (fUnitSize >= 2.5)
                        size = 10;

                    size += 0.5f;


                    #region Border special Units

                    #region Self created Units

                    if (_pSettings.MaphackUnitIds != null ||
                        _pSettings.MaphackUnitColors != null)
                    {
                        for (var j = 0; j < _pSettings.MaphackUnitIds.Count; j++)
                        {
                            var tmpSettingsId = _pSettings.MaphackUnitIds[j];
                            var bExpression = false;

                            if (tmpSettingsId == PredefinedData.UnitId.ZuChangeling)
                            {
                                if (tmpUnit.Id == PredefinedData.UnitId.ZuChangeling ||
                                    tmpUnit.Id == PredefinedData.UnitId.ZuChangelingMarine ||
                                    tmpUnit.Id == PredefinedData.UnitId.ZuChangelingMarineShield ||
                                    tmpUnit.Id == PredefinedData.UnitId.ZuChangelingSpeedling ||
                                    tmpUnit.Id == PredefinedData.UnitId.ZuChangelingZealot ||
                                    tmpUnit.Id == PredefinedData.UnitId.ZuChangelingZergling)
                                    bExpression = true;
                            }

                            else
                                bExpression = tmpUnit.Id == _pSettings.MaphackUnitIds[j] ? true : false;

                            if (bExpression)
                            {
                                if (_pSettings.MaphackUnitColors[j] != Color.Transparent)
                                {
                                    var clUnit = _pSettings.MaphackUnitColors[j];
                                    if (!tmpUnit.IsAlive)
                                        continue;

                                    if (_pSettings.MaphackRemoveLocalplayer)
                                    {
                                        if (tmpUnit.Owner ==
                                            _hMainHandler.GInformation.Player[0].Localplayer)
                                            continue;
                                    }

                                    g.Graphics.DrawRectangle(
                                        new Pen(new SolidBrush(clUnit), 1.5f),
                                        (iUnitPosX - size/2), (iUnitPosY - size/2), size, size);

                                    g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBoundBorder)),
                                                             iUnitPosX - ((size/2) + 0.75f),
                                                             iUnitPosY - ((size/2) + 0.75f), size + 1.75f, size + 1.75f);
                                }
                            }
                        }
                    }

                    #endregion

                    #region CreepTumors

                    //if (_hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int) PredefinedTypes.UnitId.ZbCreeptumor)
                    //{
                    //    g.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Gray), 1.5f),
                    //                             (iUnitPosX - size/2), (iUnitPosY - size/2), size, size);

                    //    g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBoundBorder)),
                    //                             iUnitPosX - ((size/2) + 0.75f),
                    //                             iUnitPosY - ((size/2) + 0.75f), size + 1.75f, size + 1.75f);
                    //}


                    //if (_hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreeptumor ||
                    //    _hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreepTumorBuilding ||
                    //    _hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreepTumorMissle ||
                    //    _hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreeptumorBurrowed)
                    //{
                    //    const Int32 iRadius = 4;

                    //    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    //    g.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                        
                    //    g.Graphics.DrawLine(Constants.PBlack1, iUnitPosX - iRadius, iUnitPosY - iRadius, iUnitPosX + iRadius, iUnitPosY + iRadius);
                    //    g.Graphics.DrawLine(Constants.PBlack1, iUnitPosX + iRadius, iUnitPosY - iRadius, iUnitPosX - iRadius, iUnitPosY + iRadius);

                    //    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    //    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                    //}

                    #endregion

                    #region Unitgroup I - Defensive Buildings

                    if (_pSettings.MaphackColorDefensivestructuresYellow)
                    {
                        if (tmpUnit.Id ==  PredefinedData.UnitId.TbTurret ||
                            tmpUnit.Id ==  PredefinedData.UnitId.TbBunker ||
                            tmpUnit.Id ==  PredefinedData.UnitId.TbPlanetary ||
                            tmpUnit.Id ==  PredefinedData.UnitId.ZbSpineCrawler ||
                            tmpUnit.Id ==  PredefinedData.UnitId.ZbSpineCrawlerUnrooted ||
                            tmpUnit.Id ==  PredefinedData.UnitId.ZbSporeCrawler ||
                            tmpUnit.Id ==  PredefinedData.UnitId.ZbSporeCrawlerUnrooted ||
                            tmpUnit.Id ==  PredefinedData.UnitId.PbCannon)
                        {
                            var clUnitBound = Color.Yellow;


                            if ((tmpUnit.TargetFilter & (UInt64) PredefinedData.TargetFilterFlag.Dead) > 0)
                                continue;


                            if (_pSettings.MaphackRemoveLocalplayer)
                            {
                                if (tmpUnit.Owner == _hMainHandler.GInformation.Player[0].Localplayer)
                                    continue;

                            }

                            g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBound), 1.5f),
                                                     (iUnitPosX - size/2), (iUnitPosY - size/2), size, size);

                            g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBoundBorder)),
                                                     iUnitPosX - ((size/2) + 0.75f),
                                                     iUnitPosY - ((size/2) + 0.75f), size + 1.75f, size + 1.75f);
                        }
                    }

                    #endregion

                    #region Hallucinations - make a triangle

                    #endregion

                    var ptPoints = new PointF[3];
                    var fRadius = size * 2;

                    if (tmpUnit.IsHallucination)
                    {
                        ptPoints[0] = new PointF(iUnitPosX + (size / 2), iUnitPosY - fRadius - 1);
                        ptPoints[1] = new PointF(iUnitPosX - fRadius, iUnitPosY + fRadius);
                        ptPoints[2] = new PointF(iUnitPosX + fRadius + 1, iUnitPosY + fRadius);
                    }

                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                    g.Graphics.DrawPolygon(new Pen(Brushes.Orange, 1), ptPoints);

                    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                    #endregion

                }

                #endregion

                

                #region Draw Player camera

                if (!_pSettings.MaphackRemoveCamera)
                {
                    for (var i = 0; i < _hMainHandler.GInformation.Player.Count; i++)
                    {
                        var clPlayercolor = _hMainHandler.GInformation.Player[i].Color;

                        #region Teamcolor

                        if (_hMainHandler.GInformation.Gameinfo.IsTeamcolor)
                        {
                            if (_hMainHandler.GInformation.Player[0].Localplayer < _hMainHandler.GInformation.Player.Count)
                            {
                                if (_hMainHandler.GInformation.Player[i].IsLocalplayer)
                                    clPlayercolor = Color.Green;

                                else if (_hMainHandler.GInformation.Player[i].Team ==
                                         _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Team &&
                                         !_hMainHandler.GInformation.Player[i].IsLocalplayer)
                                    clPlayercolor = Color.Yellow;

                                else
                                    clPlayercolor = Color.Red;
                            }
                        }

                        #endregion

                        #region Escape Sequences

                        /* Ai - Works */
                        if (_pSettings.MaphackRemoveAi)
                        {
                            if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Ai))
                                continue;
                        }

                        /* Observer */
                        if (_pSettings.MaphackRemoveObserver)
                        {
                            if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Observer))
                                continue;
                        }

                        /* Referee */
                        if (_pSettings.MaphackRemoveReferee)
                        {
                            if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Referee))
                                continue;
                        }

                        /* Localplayer - Works */
                        if (_pSettings.MaphackRemoveLocalplayer)
                        {
                            if (_hMainHandler.GInformation.Player[i].IsLocalplayer)
                                continue;
                        }

                        /* Allie */
                        if (_pSettings.MaphackRemoveAllie)
                        {
                            if (_hMainHandler.GInformation.Player[0].Localplayer < _hMainHandler.GInformation.Player.Count)
                            {
                                if (_hMainHandler.GInformation.Player[i].Team ==
                                    _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[i].Localplayer].Team &&
                                    !_hMainHandler.GInformation.Player[i].IsLocalplayer)
                                    continue;
                            }
                        }

                        /* Neutral */
                        if (_pSettings.MaphackRemoveNeutral)
                        {
                            if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Neutral))
                                continue;
                        }

                        /* Hosile */
                        if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Hostile))
                            continue;

                        if (float.IsInfinity(fScale))
                            continue;

                        if (CheckIfGameheart(_hMainHandler.GInformation.Player[i]))
                            continue;

                        #endregion

                        #region Drawing

                        //The actrual position of the Cameras
                        var fPlayerX = (_hMainHandler.GInformation.Player[i].CameraPositionX - tmpMap.Left)*fScale + fX;
                        var fPlayerY = (tmpMap.Top - _hMainHandler.GInformation.Player[i].CameraPositionY)*fScale + fY;


                        if (fPlayerX <= 0 || fPlayerX >= Width ||
                            fPlayerY <= 0 || fPlayerY >= Height)
                            continue;


                        var ptPoints = new PointF[4];
                        ptPoints[0] = new PointF(fPlayerX - 35f, fPlayerY - 24f);
                        ptPoints[1] = new PointF(fPlayerX + 35f, fPlayerY - 24f);
                        ptPoints[2] = new PointF(fPlayerX + 24f, fPlayerY + 10f);
                        ptPoints[3] = new PointF(fPlayerX - 24f, fPlayerY + 10f);




                        g.Graphics.DrawPolygon(new Pen(new SolidBrush(clPlayercolor), 2), ptPoints);

                        #endregion

                    }
                }

                #endregion

                #endregion

            }

            catch (Exception ex)
            {
                Messages.LogFile("DrawMinimap", "Over all", ex);
            }
        }

        /* Count the Units/ structures */
        private void DrawUnits(BufferedGraphics g)
        {
            try
            {

                if (!_hMainHandler.GInformation.Gameinfo.IsIngame)
                    return;

                Opacity = _pSettings.UnitTabOpacity;

                /* Add the feature that the window (in case you have all races and more units than your display can hold) 
                 * will split the units to the next line */

                /* Count all included units */

                //_swMainWatch.Reset();
                //_swMainWatch.Start();
                //CountUnits();
                CountUnits_2();

                //_swMainWatch.Stop();
                //Debug.WriteLine(Math.Round(1000000.0 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency, 2) + " µs");




                Int32 iSize = _pSettings.UnitPictureSize;
                var iPosY = 0;
                var iPosX = 0;

                var iMaximumWidth = 0;
                var fsize = (float) (iSize/3.5);
                var iPosXAfterName = (Int32) (fsize*14);
                    /* We take the fontsize times the (probably) with a common String- lenght*/

                var iWidthUnits = 0;
                var iWidthBuildings = 0;

                if (fsize < 1)
                    fsize = 1;

                var fStringFont = new Font(_pSettings.UnitTabFontName, fsize, FontStyle.Regular);


                /* Define the startposition of the picture drawing
                 * using the longest name as reference */
                var strPlayerName = String.Empty;
                for (var i = 0; i < _hMainHandler.GInformation.Player.Count; i++)
                {
                    var strTemp = (_hMainHandler.GInformation.Player[i].ClanTag.StartsWith("\0") ||
                                   _pSettings.UnitTabRemoveClanTag)
                        ? _hMainHandler.GInformation.Player[i].Name
                        : "[" + _hMainHandler.GInformation.Player[i].ClanTag + "] " +
                          _hMainHandler.GInformation.Player[i].Name;

                    if (strTemp.Length >= strPlayerName.Length)
                        strPlayerName = strTemp;
                }

                iPosXAfterName = TextRenderer.MeasureText(strPlayerName, fStringFont).Width + 20;

                /* Fix the size of the icons to 25x25 */
                for (var i = 0; i < _hMainHandler.GInformation.Player.Count; i++)
                {

                    //_swMainWatch.Reset();
                    //_swMainWatch.Start();

                    var clPlayercolor = _hMainHandler.GInformation.Player[i].Color;

                    #region Teamcolor

                    if (_hMainHandler.GInformation.Gameinfo.IsTeamcolor)
                    {
                        if (_hMainHandler.GInformation.Player[i].Localplayer < _hMainHandler.GInformation.Player.Count)
                        {
                            if (_hMainHandler.GInformation.Player[i].IsLocalplayer)
                                clPlayercolor = Color.Green;

                            else if (_hMainHandler.GInformation.Player[i].Team ==
                                     _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer]
                                         .Team &&
                                     !_hMainHandler.GInformation.Player[i].IsLocalplayer)
                                clPlayercolor = Color.Yellow;

                            else
                                clPlayercolor = Color.Red;
                        }
                    }

                    #endregion

                    #region Exceptions - Throw out players

                    /* Remove Ai - Works */
                    if (_pSettings.UnitTabRemoveAi)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type == PredefinedData.PlayerType.Ai)
                        {
                            continue;
                        }
                    }

                    /* Remove Referee - Not Tested */
                    if (_pSettings.UnitTabRemoveReferee)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type == PredefinedData.PlayerType.Referee)
                        {
                            continue;
                        }
                    }

                    /* Remove Observer - Not Tested */
                    if (_pSettings.UnitTabRemoveObserver)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type == PredefinedData.PlayerType.Observer)
                        {
                            continue;
                        }
                    }

                    /* Remove Neutral - Works */
                    if (_pSettings.UnitTabRemoveNeutral)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type == PredefinedData.PlayerType.Neutral)
                        {
                            continue;
                        }
                    }

                    /* Remove Localplayer - Works */
                    if (_pSettings.UnitTabRemoveLocalplayer)
                    {
                        if (_hMainHandler.GInformation.Player[i].IsLocalplayer)
                        {
                            continue;
                        }
                    }

                    /* Remove Allie - Works */
                    if (_pSettings.UnitTabRemoveAllie)
                    {
                        if (_hMainHandler.GInformation.Player[i].Team ==
                            _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[i].Localplayer].Team &&
                            !_hMainHandler.GInformation.Player[i].IsLocalplayer)
                        {
                            continue;
                        }
                    }

                    if (_hMainHandler.GInformation.Player[i].Type == PredefinedData.PlayerType.Hostile)
                        continue;



                    #endregion


                    if (_hMainHandler.GInformation.Player[i].Name.Length <= 0 ||
                        _hMainHandler.GInformation.Player[i].Name.StartsWith("\0"))
                        continue;

                    if (CheckIfGameheart(_hMainHandler.GInformation.Player[i]))
                        continue;


                    iPosX = 0;

                    /* Draw Name in front of Icons */
                    var strName = (_hMainHandler.GInformation.Player[i].ClanTag.StartsWith("\0") ||
                                   _pSettings.UnitTabRemoveClanTag)
                        ? _hMainHandler.GInformation.Player[i].Name
                        : "[" + _hMainHandler.GInformation.Player[i].ClanTag + "] " +
                          _hMainHandler.GInformation.Player[i].Name;

                    Drawing.DrawString(g.Graphics,
                        strName,
                        fStringFont,
                        new SolidBrush(clPlayercolor),
                        Brushes.Black, iPosX + 10,
                        iPosY + 10,
                        1f, 1f, true);

                    iPosX = iPosXAfterName;

                    #region Draw Units

                    if (_hMainHandler.PSettings.UnitShowUnits)
                    {

                        /* Terran */
                        Helper_DrawUnits(_lTuScv[i], ref iPosX, iPosY, iSize, _imgTuScv, g, clPlayercolor,
                            fStringFont, false);

                        Helper_DrawUnits(_lTuMarine[i], ref iPosX, iPosY, iSize, _imgTuMarine, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuMarauder[i], ref iPosX, iPosY, iSize, _imgTuMarauder, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lTuReaper[i], ref iPosX, iPosY, iSize, _imgTuReaper, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuGhost[i], ref iPosX, iPosY, iSize, _imgTuGhost, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuMule[i], ref iPosX, iPosY, iSize, _imgTuMule, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuHellion[i], ref iPosX, iPosY, iSize, _imgTuHellion, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuHellbat[i], ref iPosX, iPosY, iSize, _imgTuHellbat, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuWidowMine[i], ref iPosX, iPosY, iSize, _imgTuWidowMine, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lTuSiegetank[i], ref iPosX, iPosY, iSize, _imgTuSiegetank, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lTuThor[i], ref iPosX, iPosY, iSize, _imgTuThor, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuMedivac[i], ref iPosX, iPosY, iSize, _imgTuMedivac, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuBanshee[i], ref iPosX, iPosY, iSize, _imgTuBanshee, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuViking[i], ref iPosX, iPosY, iSize, _imgTuViking, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuRaven[i], ref iPosX, iPosY, iSize, _imgTuRaven, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuBattlecruiser[i], ref iPosX, iPosY, iSize, _imgTuBattlecruiser, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lTuPointDefenseDrone[i], ref iPosX, iPosY, iSize, _imgTuPointDefenseDrone,
                            g, clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lTuNuke[i], ref iPosX, iPosY, iSize,
                            _imgTuNuke, g, clPlayercolor, fStringFont, false);


                        /* Protoss */
                        Helper_DrawUnits(_lPuProbe[i], ref iPosX, iPosY, iSize, _imgPuProbe, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuZealot[i], ref iPosX, iPosY, iSize, _imgPuZealot, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuStalker[i], ref iPosX, iPosY, iSize, _imgPuStalker, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuSentry[i], ref iPosX, iPosY, iSize, _imgPuSentry, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuDt[i], ref iPosX, iPosY, iSize, _imgPuDarkTemplar, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuHt[i], ref iPosX, iPosY, iSize, _imgPuHighTemplar, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuArchon[i], ref iPosX, iPosY, iSize, _imgPuArchon, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuImmortal[i], ref iPosX, iPosY, iSize, _imgPuImmortal, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lPuColossus[i], ref iPosX, iPosY, iSize, _imgPuColossus, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lPuObserver[i], ref iPosX, iPosY, iSize, _imgPuObserver, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lPuWarpprism[i], ref iPosX, iPosY, iSize, _imgPuWapprism, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lPuPhoenix[i], ref iPosX, iPosY, iSize, _imgPuPhoenix, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuVoidray[i], ref iPosX, iPosY, iSize, _imgPuVoidray, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuOracle[i], ref iPosX, iPosY, iSize, _imgPuOracle, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuCarrier[i], ref iPosX, iPosY, iSize, _imgPuCarrier, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuTempest[i], ref iPosX, iPosY, iSize, _imgPuTempest, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuMothershipcore[i], ref iPosX, iPosY, iSize, _imgPuMothershipcore, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lPuMothership[i], ref iPosX, iPosY, iSize, _imgPuMothership, g,
                            clPlayercolor, fStringFont, false);


                        /* Zerg */
                        Helper_DrawUnits(_lZuDrone[i], ref iPosX, iPosY, iSize, _imgZuDrone, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuOverlord[i], ref iPosX, iPosY, iSize, _imgZuOverlord, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuQueen[i], ref iPosX, iPosY, iSize, _imgZuQueen, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuZergling[i], ref iPosX, iPosY, iSize, _imgZuZergling, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuBaneling[i], ref iPosX, iPosY, iSize, _imgZuBaneling, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuBanelingCocoon[i], ref iPosX, iPosY, iSize, _imgZuBanelingCocoon, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuRoach[i], ref iPosX, iPosY, iSize, _imgZuRoach, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuHydra[i], ref iPosX, iPosY, iSize, _imgZuHydra, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuMutalisk[i], ref iPosX, iPosY, iSize, _imgZuMutalisk, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuInfestor[i], ref iPosX, iPosY, iSize, _imgZuInfestor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuOverseer[i], ref iPosX, iPosY, iSize, _imgZuOverseer, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuOverseerCocoon[i], ref iPosX, iPosY, iSize, _imgZuOvserseerCocoon, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuSwarmhost[i], ref iPosX, iPosY, iSize, _imgZuSwarmhost, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuUltralisk[i], ref iPosX, iPosY, iSize, _imgZuUltra, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuViper[i], ref iPosX, iPosY, iSize, _imgZuViper, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuCorruptor[i], ref iPosX, iPosY, iSize, _imgZuCorruptor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuBroodlord[i], ref iPosX, iPosY, iSize, _imgZuBroodlord, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuBroodlordCocoon[i], ref iPosX, iPosY, iSize, _imgZuBroodlordCocoon,
                            g, clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuLocust[i], ref iPosX, iPosY, iSize, _imgZuLocust, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuLarva[i], ref iPosX, iPosY, iSize, _imgZuLarva, g, clPlayercolor,
                            fStringFont, false);

                        /* Maximum for the units */
                        iWidthUnits = iPosX;

                    }

                    #endregion



                    #region - Split Units and Buildings -

                    if (_pSettings.UnitTabSplitUnitsAndBuildings)
                    {
                        var iHavetoadd = 0; //Adds +1 when a neutral player is on position 0


                        if (_hMainHandler.GInformation.Player[0].Type == PredefinedData.PlayerType.Neutral)
                            iHavetoadd += 1;

                        if (i == iHavetoadd)
                        {
                            if (iPosX > iPosXAfterName)
                            {
                                iPosY += iSize + 2;
                                iPosX = iPosXAfterName;
                            }
                        }

                        else if (i > iHavetoadd)
                        {
                            if (iPosX > iPosXAfterName)
                            {
                                iPosY += iSize + 2;
                                iPosX = iPosXAfterName;
                            }
                        }
                    }

                    #endregion



                    #region Draw Buildings

                    if (_hMainHandler.PSettings.UnitShowBuildings)
                    {
                        /* Terran */
                        Helper_DrawUnits(_lTbCommandCenter[i],
                            ref iPosX, iPosY, iSize, _imgTbCc, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbOrbitalCommand[i],
                            ref iPosX, iPosY, iSize, _imgTbOc, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbPlanetaryFortress[i],
                            ref iPosX, iPosY, iSize, _imgTbPf, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbSupply[i], ref iPosX, iPosY,
                            iSize, _imgTbSupply, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbRefinery[i], ref iPosX, iPosY,
                            iSize, _imgTbRefinery, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbBunker[i], ref iPosX, iPosY,
                            iSize, _imgTbBunker, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbTechlab[i], ref iPosX, iPosY,
                            iSize, _imgTbTechlab, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbReactor[i], ref iPosX, iPosY,
                            iSize, _imgTbReactor, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbTurrent[i], ref iPosX, iPosY,
                            iSize, _imgTbTurrent, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbSensorTower[i], ref iPosX,
                            iPosY, iSize, _imgTbSensorTower, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbEbay[i], ref iPosX, iPosY, iSize,
                            _imgTbEbay, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbGhostAcademy[i], ref iPosX,
                            iPosY, iSize, _imgTbGhostacademy, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbArmory[i], ref iPosX, iPosY,
                            iSize, _imgTbArmory, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbFusionCore[i], ref iPosX,
                            iPosY, iSize, _imgTbFusioncore, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbBarracks[i], ref iPosX, iPosY,
                            iSize, _imgTbBarracks, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbFactory[i], ref iPosX, iPosY,
                            iSize, _imgTbFactory, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbStarport[i], ref iPosX, iPosY,
                            iSize, _imgTbStarport, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbAutoTurret[i], ref iPosX, iPosY, iSize, _imgTbAutoTurret, g,
                            clPlayercolor, fStringFont, false);


                        /* Protoss */
                        Helper_DrawUnits(_lPbNexus[i], ref iPosX, iPosY, iSize, _imgPbNexus, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(_lPbPylon[i], ref iPosX, iPosY, iSize, _imgPbPylon, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(_lPbAssimilator[i], ref iPosX, iPosY, iSize, _imgPbAssimilator, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbCannon[i], ref iPosX, iPosY, iSize, _imgPbCannon, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(_lPbDarkshrine[i], ref iPosX, iPosY, iSize, _imgPbDarkShrine, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbTemplarArchives[i], ref iPosX, iPosY, iSize, _imgPbTemplarArchives,
                            g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbTwilight[i], ref iPosX, iPosY, iSize, _imgPbTwillightCouncil, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbCybercore[i], ref iPosX, iPosY, iSize, _imgPbCybercore, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbForge[i], ref iPosX, iPosY, iSize, _imgPbForge, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(_lPbFleetbeacon[i], ref iPosX, iPosY, iSize, _imgPbFleetBeacon, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbRoboticsSupport[i], ref iPosX, iPosY, iSize, _imgPbRoboticsSupport,
                            g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbGateway[i], ref iPosX, iPosY, iSize, _imgPbGateway, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(_lPbWarpgate[i], ref iPosX, iPosY, iSize, _imgPbWarpgate, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbStargate[i], ref iPosX, iPosY, iSize, _imgPbStargate, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbRobotics[i], ref iPosX, iPosY, iSize, _imgPbRobotics, g,
                            clPlayercolor, fStringFont, true);

                        /* Zerg */
                        Helper_DrawUnits(_lZbCreepTumor[i], ref iPosX, iPosY, iSize, _imgZbCreepTumor, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbHatchery[i], ref iPosX, iPosY, iSize, _imgZbHatchery, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbLair[i], ref iPosX, iPosY, iSize, _imgZbLair, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(_lZbHive[i], ref iPosX, iPosY, iSize, _imgZbHive, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(_lZbSpawningpool[i], ref iPosX, iPosY, iSize, _imgZbSpawningpool, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbEvochamber[i], ref iPosX, iPosY, iSize, _imgZbEvochamber, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbExtractor[i], ref iPosX, iPosY, iSize, _imgZbExtractor, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbSpine[i], ref iPosX, iPosY, iSize, _imgZbSpinecrawler, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbSpore[i], ref iPosX, iPosY, iSize, _imgZbSporecrawler, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbHydraden[i], ref iPosX, iPosY, iSize, _imgZbHydraden, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbRoachwarren[i], ref iPosX, iPosY, iSize, _imgZbRoachwarren, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbSpire[i], ref iPosX, iPosY, iSize, _imgZbSpire, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(_lZbGreaterspire[i], ref iPosX, iPosY, iSize, _imgZbGreaterspire, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbUltracavern[i], ref iPosX, iPosY, iSize, _imgZbUltracavern, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbInfestationpit[i], ref iPosX, iPosY, iSize, _imgZbInfestationpit, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbBanelingnest[i], ref iPosX, iPosY, iSize, _imgZbBanelingnest, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbNydusbegin[i], ref iPosX, iPosY, iSize, _imgZbNydusNetwork, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbNydusend[i], ref iPosX, iPosY, iSize, _imgZbNydusWorm, g,
                            clPlayercolor, fStringFont, true);

                        iWidthBuildings = iPosX;

                    }

                    #endregion



                    if (iPosX > iPosXAfterName)
                        iPosY += iSize + 2;

                    /* Check which width is bigger */
                    iPosX = iWidthUnits > iWidthBuildings ? iWidthUnits : iWidthBuildings;

                    /* Adjust maximum width */
                    if (iPosX >= iMaximumWidth)
                        iMaximumWidth = iPosX;

                    //if (iHavetoadd > 0)
                    //    iMaximumWidth += iSize;

                    //_swMainWatch.Stop();
                    //Debug.WriteLine("Time to execute Playerrun in DrawUnits:" + 1000000 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency + " µs");
                }

                /* Forcefield */
                iPosX = iPosXAfterName;
                Helper_DrawUnits(_lPuForcefield[_hMainHandler.GInformation.Player.Count], ref iPosX, iPosY, iSize,
                    _imgPuForceField, g,
                    Color.White, fStringFont, false);
                iPosY += iSize + 2;

                if (FormBorderStyle == FormBorderStyle.None)
                {
                    Width = iMaximumWidth + 1;
                    Height = iPosY;
                }

                else
                {
                    _iUnitPanelWidth = iMaximumWidth + 1;
                    _iUnitPanelWidthWithoutName = _iUnitPanelWidth - iPosXAfterName;
                    _iUnitPosAfterName = iPosXAfterName;
                }
            }

            catch (Exception ex)
            {
                Messages.LogFile("DrawUnits", "Over all", ex);
            }


        }

        /* Count the Units/ structures */
        private void DrawProduction(BufferedGraphics g)
        {
            try
            {

                if (!_hMainHandler.GInformation.Gameinfo.IsIngame)
                    return;

                Opacity = _pSettings.ProdTabOpacity;

                /* Add the feature that the window (in case you have all races and more units than your display can hold) 
                 * will split the units to the next line */

                /* Count all included units */
                //CountUnits();
                CountUnits_2();

                var iHavetoadd = 0; //Adds +1 when a neutral player is on position 0
                Int32 iSize = _pSettings.ProdPictureSize;
                var iPosY = 0;
                var iPosX = 0;

                var iMaximumWidth = 0;
                var fsize = (float)(iSize / 3.5);
                var iPosXAfterName = (Int32)(fsize * 14);    /* We take the fontsize times the (probably) with a common String- lenght*/
                var iPosYInitial = iPosY;

                var iWidthUnits = 0;
                var iWidthBuildings = 0;
                var iWidthUpgrades = 0;

                if (fsize < 1)
                    fsize = 1;

                var fStringFont = new Font(_pSettings.ProdTabFontName, fsize, FontStyle.Regular);


                /* Define the startposition of the picture drawing
                 * using the longest name as reference */
                var strPlayerName = String.Empty;
                for (var i = 0; i < _hMainHandler.GInformation.Player.Count; i++)
                {
                    var strTemp = (_hMainHandler.GInformation.Player[i].ClanTag.StartsWith("\0") || _pSettings.ProdTabRemoveClanTag)
                                             ? _hMainHandler.GInformation.Player[i].Name
                                             : "[" + _hMainHandler.GInformation.Player[i].ClanTag + "] " + _hMainHandler.GInformation.Player[i].Name;

                    if (strTemp.Length >= strPlayerName.Length)
                        strPlayerName = strTemp;
                }

                iPosXAfterName = TextRenderer.MeasureText(strPlayerName, fStringFont).Width + 20;


                /* Fix the size of the icons to 25x25 */
                for (var i = 0; i < _hMainHandler.GInformation.Player.Count; i++)
                {
                    var clPlayercolor = _hMainHandler.GInformation.Player[i].Color;

                    #region Teamcolor

                    if (_hMainHandler.GInformation.Gameinfo.IsTeamcolor)
                    {
                        if (_hMainHandler.GInformation.Player[i].Localplayer < _hMainHandler.GInformation.Player.Count)
                        {
                            if (_hMainHandler.GInformation.Player[i].IsLocalplayer)
                                clPlayercolor = Color.Green;

                            else if (_hMainHandler.GInformation.Player[i].Team ==
                                     _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Team &&
                                     !_hMainHandler.GInformation.Player[i].IsLocalplayer)
                                clPlayercolor = Color.Yellow;

                            else
                                clPlayercolor = Color.Red;
                        }
                    }

                    #endregion

                    #region Exceptions - Throw out players

                    /* Remove Ai - Works */
                    if (_pSettings.ProdTabRemoveAi)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type == PredefinedData.PlayerType.Ai)
                        {
                            continue;
                        }
                    }

                    /* Remove Referee - Not Tested */
                    if (_pSettings.ProdTabRemoveReferee)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type == PredefinedData.PlayerType.Referee)
                        {
                            continue;
                        }
                    }

                    /* Remove Observer - Not Tested */
                    if (_pSettings.ProdTabRemoveObserver)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type == PredefinedData.PlayerType.Observer)
                        {
                            continue;
                        }
                    }

                    /* Remove Neutral - Works */
                    if (_pSettings.ProdTabRemoveNeutral)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type == PredefinedData.PlayerType.Neutral)
                        {
                            continue;
                        }
                    }

                    /* Remove Localplayer - Works */
                    if (_pSettings.ProdTabRemoveLocalplayer)
                    {
                        if (_hMainHandler.GInformation.Player[i].IsLocalplayer)
                        {
                            continue;
                        }
                    }

                    /* Remove Allie - Works */
                    if (_pSettings.ProdTabRemoveAllie)
                    {
                        if (_hMainHandler.GInformation.Player[i].Team == _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[i].Localplayer].Team &&
                            !_hMainHandler.GInformation.Player[i].IsLocalplayer)
                        {
                            continue;
                        }
                    }

                    if (_hMainHandler.GInformation.Player[i].Type == PredefinedData.PlayerType.Hostile)
                        continue;



                    #endregion

                    if (_hMainHandler.GInformation.Player[i].Name.Length <= 0 ||
                        _hMainHandler.GInformation.Player[i].Name.StartsWith("\0"))
                        continue;

                    if (CheckIfGameheart(_hMainHandler.GInformation.Player[i]))
                        continue;

                    iPosX = 0;

                    /* Draw Name in front of Icons */
                    var strName = (_hMainHandler.GInformation.Player[i].ClanTag.StartsWith("\0") || _pSettings.ProdTabRemoveClanTag)
                                         ? _hMainHandler.GInformation.Player[i].Name
                                         : "[" + _hMainHandler.GInformation.Player[i].ClanTag + "] " + _hMainHandler.GInformation.Player[i].Name;

                    Drawing.DrawString(g.Graphics,
                       strName,
                       fStringFont,
                       new SolidBrush(clPlayercolor),
                       Brushes.Black, iPosX + 10,
                       iPosY + 10,
                       1f, 1f, true);
                    

                    iPosX = iPosXAfterName;

                    #region Draw Units

                    if (_hMainHandler.PSettings.ProdTabShowUnits)
                    {

                        /* Terran */
                        Helper_DrawUnitsProduction(_lTuScv[i], ref iPosX, iPosY, iSize, _imgTuScv, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuMarine[i], ref iPosX, iPosY, iSize, _imgTuMarine, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuMarauder[i], ref iPosX, iPosY, iSize, _imgTuMarauder, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuReaper[i], ref iPosX, iPosY, iSize, _imgTuReaper, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuGhost[i], ref iPosX, iPosY, iSize, _imgTuGhost, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuMule[i], ref iPosX, iPosY, iSize, _imgTuMule, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuHellion[i], ref iPosX, iPosY, iSize, _imgTuHellion, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuHellbat[i], ref iPosX, iPosY, iSize, _imgTuHellbat, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuWidowMine[i], ref iPosX, iPosY, iSize, _imgTuWidowMine, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuSiegetank[i], ref iPosX, iPosY, iSize, _imgTuSiegetank, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuThor[i], ref iPosX, iPosY, iSize, _imgTuThor, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuMedivac[i], ref iPosX, iPosY, iSize, _imgTuMedivac, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuBanshee[i], ref iPosX, iPosY, iSize, _imgTuBanshee, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuViking[i], ref iPosX, iPosY, iSize, _imgTuViking, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuRaven[i], ref iPosX, iPosY, iSize, _imgTuRaven, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuBattlecruiser[i], ref iPosX, iPosY, iSize, _imgTuBattlecruiser, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTbAutoTurret[i], ref iPosX, iPosY, iSize, _imgTbAutoTurret, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuPointDefenseDrone[i], ref iPosX, iPosY, iSize,
                            _imgTuPointDefenseDrone, g, clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTuNuke[i], ref iPosX, iPosY, iSize,
                            _imgTuNuke, g, clPlayercolor, fStringFont, false);


                        /* Protoss */
                        Helper_DrawUnitsProduction(_lPuProbe[i], ref iPosX, iPosY, iSize, _imgPuProbe, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuZealot[i], ref iPosX, iPosY, iSize, _imgPuZealot, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuStalker[i], ref iPosX, iPosY, iSize, _imgPuStalker, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuSentry[i], ref iPosX, iPosY, iSize, _imgPuSentry, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuDt[i], ref iPosX, iPosY, iSize, _imgPuDarkTemplar, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuHt[i], ref iPosX, iPosY, iSize, _imgPuHighTemplar, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuArchon[i], ref iPosX, iPosY, iSize, _imgPuArchon, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuImmortal[i], ref iPosX, iPosY, iSize, _imgPuImmortal, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuColossus[i], ref iPosX, iPosY, iSize, _imgPuColossus, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuObserver[i], ref iPosX, iPosY, iSize, _imgPuObserver, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuWarpprism[i], ref iPosX, iPosY, iSize, _imgPuWapprism, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuPhoenix[i], ref iPosX, iPosY, iSize, _imgPuPhoenix, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuVoidray[i], ref iPosX, iPosY, iSize, _imgPuVoidray, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuOracle[i], ref iPosX, iPosY, iSize, _imgPuOracle, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuCarrier[i], ref iPosX, iPosY, iSize, _imgPuCarrier, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuTempest[i], ref iPosX, iPosY, iSize, _imgPuTempest, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuMothershipcore[i], ref iPosX, iPosY, iSize, _imgPuMothershipcore,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPuMothership[i], ref iPosX, iPosY, iSize, _imgPuMothership, g,
                            clPlayercolor, fStringFont, false);

                        /* Zerg */
                        Helper_DrawUnitsProduction(_lZuLarva[i], ref iPosX, iPosY, iSize, _imgZuLarva, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuDrone[i], ref iPosX, iPosY, iSize, _imgZuDrone, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuOverlord[i], ref iPosX, iPosY, iSize, _imgZuOverlord, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuQueen[i], ref iPosX, iPosY, iSize, _imgZuQueen, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuZergling[i], ref iPosX, iPosY, iSize, _imgZuZergling, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuBaneling[i], ref iPosX, iPosY, iSize, _imgZuBaneling, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuBanelingCocoon[i], ref iPosX, iPosY, iSize, _imgZuBanelingCocoon,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuRoach[i], ref iPosX, iPosY, iSize, _imgZuRoach, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuHydra[i], ref iPosX, iPosY, iSize, _imgZuHydra, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuMutalisk[i], ref iPosX, iPosY, iSize, _imgZuMutalisk, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuInfestor[i], ref iPosX, iPosY, iSize, _imgZuInfestor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuOverseer[i], ref iPosX, iPosY, iSize, _imgZuOverseer, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuOverseerCocoon[i], ref iPosX, iPosY, iSize, _imgZuOvserseerCocoon,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuSwarmhost[i], ref iPosX, iPosY, iSize, _imgZuSwarmhost, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuUltralisk[i], ref iPosX, iPosY, iSize, _imgZuUltra, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuViper[i], ref iPosX, iPosY, iSize, _imgZuViper, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuCorruptor[i], ref iPosX, iPosY, iSize, _imgZuCorruptor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuBroodlord[i], ref iPosX, iPosY, iSize, _imgZuBroodlord, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZuBroodlordCocoon[i], ref iPosX, iPosY, iSize,
                            _imgZuBroodlordCocoon,
                            g, clPlayercolor, fStringFont, false);

                        /* Maximum for the units */
                        iWidthUnits = iPosX;

                    }

                    #endregion

                    #region - Split Units and Buildings -

                    if (_pSettings.ProdTabSplitUnitsAndBuildings)
                    {
                        iHavetoadd = 0;


                        if (_hMainHandler.GInformation.Player[0].Type == PredefinedData.PlayerType.Neutral)
                            iHavetoadd += 1;

                        if (i == iHavetoadd)
                        {
                            if (iPosX > iPosXAfterName)
                            {
                                iPosY += iSize + 2;
                                iPosX = iPosXAfterName;
                            }
                        }

                        else if (i > iHavetoadd)
                        {
                            if (iPosX > iPosXAfterName)
                            {
                                iPosY += iSize + 2;
                                iPosX = iPosXAfterName;
                            }
                        }
                    }

                    #endregion

                    #region Draw Buildings

                    if (_hMainHandler.PSettings.ProdTabShowBuildings)
                    {

                        /* Terran */
                        Helper_DrawUnitsProduction(_lTbCommandCenter[i],
                            ref iPosX, iPosY, iSize, _imgTbCc, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbOrbitalCommand[i],
                            ref iPosX, iPosY, iSize, _imgTbOc, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbPlanetaryFortress[i],
                            ref iPosX, iPosY, iSize, _imgTbPf, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbSupply[i], ref iPosX, iPosY,
                            iSize, _imgTbSupply, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbRefinery[i], ref iPosX, iPosY,
                            iSize, _imgTbRefinery, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbBunker[i], ref iPosX, iPosY,
                            iSize, _imgTbBunker, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbTechlab[i], ref iPosX, iPosY,
                            iSize, _imgTbTechlab, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbReactor[i], ref iPosX, iPosY,
                            iSize, _imgTbReactor, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbTurrent[i], ref iPosX, iPosY,
                            iSize, _imgTbTurrent, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbSensorTower[i], ref iPosX,
                            iPosY, iSize, _imgTbSensorTower, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbEbay[i], ref iPosX, iPosY, iSize,
                            _imgTbEbay, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbGhostAcademy[i], ref iPosX,
                            iPosY, iSize, _imgTbGhostacademy, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbArmory[i], ref iPosX, iPosY,
                            iSize, _imgTbArmory, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbFusionCore[i], ref iPosX,
                            iPosY, iSize, _imgTbFusioncore, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbBarracks[i], ref iPosX, iPosY,
                            iSize, _imgTbBarracks, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbFactory[i], ref iPosX, iPosY,
                            iSize, _imgTbFactory, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lTbStarport[i], ref iPosX, iPosY,
                            iSize, _imgTbStarport, g,
                            clPlayercolor, fStringFont, true);


                        /* Protoss */
                        Helper_DrawUnitsProduction(_lPbNexus[i], ref iPosX, iPosY, iSize, _imgPbNexus, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnitsProduction(_lPbPylon[i], ref iPosX, iPosY, iSize, _imgPbPylon, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnitsProduction(_lPbAssimilator[i], ref iPosX, iPosY, iSize, _imgPbAssimilator, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lPbCannon[i], ref iPosX, iPosY, iSize, _imgPbCannon, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lPbDarkshrine[i], ref iPosX, iPosY, iSize, _imgPbDarkShrine, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lPbTemplarArchives[i], ref iPosX, iPosY, iSize,
                            _imgPbTemplarArchives,
                            g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lPbTwilight[i], ref iPosX, iPosY, iSize, _imgPbTwillightCouncil, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lPbCybercore[i], ref iPosX, iPosY, iSize, _imgPbCybercore, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lPbForge[i], ref iPosX, iPosY, iSize, _imgPbForge, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnitsProduction(_lPbFleetbeacon[i], ref iPosX, iPosY, iSize, _imgPbFleetBeacon, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lPbRoboticsSupport[i], ref iPosX, iPosY, iSize,
                            _imgPbRoboticsSupport,
                            g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lPbGateway[i], ref iPosX, iPosY, iSize, _imgPbGateway, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lPbWarpgate[i], ref iPosX, iPosY, iSize, _imgPbWarpgate, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lPbStargate[i], ref iPosX, iPosY, iSize, _imgPbStargate, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lPbRobotics[i], ref iPosX, iPosY, iSize, _imgPbRobotics, g,
                            clPlayercolor, fStringFont, true);

                        /* Zerg */
                        Helper_DrawUnitsProduction(_lZbCreepTumor[i], ref iPosX, iPosY, iSize, _imgZbCreepTumor, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbHatchery[i], ref iPosX, iPosY, iSize, _imgZbHatchery, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbLair[i], ref iPosX, iPosY, iSize, _imgZbLair, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbHive[i], ref iPosX, iPosY, iSize, _imgZbHive, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbSpawningpool[i], ref iPosX, iPosY, iSize, _imgZbSpawningpool, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbEvochamber[i], ref iPosX, iPosY, iSize, _imgZbEvochamber, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbExtractor[i], ref iPosX, iPosY, iSize, _imgZbExtractor, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbSpine[i], ref iPosX, iPosY, iSize, _imgZbSpinecrawler, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbSpore[i], ref iPosX, iPosY, iSize, _imgZbSporecrawler, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbHydraden[i], ref iPosX, iPosY, iSize, _imgZbHydraden, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbRoachwarren[i], ref iPosX, iPosY, iSize, _imgZbRoachwarren, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbSpire[i], ref iPosX, iPosY, iSize, _imgZbSpire, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbGreaterspire[i], ref iPosX, iPosY, iSize, _imgZbGreaterspire, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbUltracavern[i], ref iPosX, iPosY, iSize, _imgZbUltracavern, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbInfestationpit[i], ref iPosX, iPosY, iSize, _imgZbInfestationpit,
                            g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbBanelingnest[i], ref iPosX, iPosY, iSize, _imgZbBanelingnest, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbNydusbegin[i], ref iPosX, iPosY, iSize, _imgZbNydusNetwork, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(_lZbNydusend[i], ref iPosX, iPosY, iSize, _imgZbNydusWorm, g,
                            clPlayercolor, fStringFont, true);

                        iWidthBuildings = iPosX;

                    }

                    #endregion

                    #region - Split Units and Buildings -

                    if (_pSettings.ProdTabSplitUnitsAndBuildings)
                    {
                        iHavetoadd = 0;


                        if (_hMainHandler.GInformation.Player[0].Type == PredefinedData.PlayerType.Neutral)
                            iHavetoadd += 1;

                        if (i == iHavetoadd)
                        {
                            if (iPosX > iPosXAfterName)
                            {
                                iPosY += iSize + 2;
                                iPosX = iPosXAfterName;
                            }
                        }

                        else if (i > iHavetoadd)
                        {
                            if (iPosX > iPosXAfterName)
                            {
                                iPosY += iSize + 2;
                                iPosX = iPosXAfterName;
                            }
                        }
                    }

                    #endregion

                    #region Upgrades

                    if (_hMainHandler.PSettings.ProdTabShowUpgrades)
                    {

                        #region Terran

                        Helper_DrawUnitsProduction(_lTupStim[i], ref iPosX, iPosY, iSize, _imgTupStim, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupCombatShields[i], ref iPosX, iPosY, iSize, _imgTupCombatShields,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupConcussiveShells[i], ref iPosX, iPosY, iSize,
                            _imgTupConcussiveShells, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupBlueFlame[i], ref iPosX, iPosY, iSize, _imgTupBlueFlame, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupDrillingClaws[i], ref iPosX, iPosY, iSize, _imgTupDrillingClaws,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupTransformationServos[i], ref iPosX, iPosY, iSize,
                            _imgTupTransformatorServos, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupPersonalCloak[i], ref iPosX, iPosY, iSize, _imgTupPersonalCloak,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupMoebiusReactor[i], ref iPosX, iPosY, iSize,
                            _imgTupMoebiusReactor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupWeaponRefit[i], ref iPosX, iPosY, iSize, _imgTupWeaponRefit, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupBehemothReactor[i], ref iPosX, iPosY, iSize,
                            _imgTupBehemothReacot, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupCloakingField[i], ref iPosX, iPosY, iSize, _imgTupCloakingField,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupCorvidReactor[i], ref iPosX, iPosY, iSize, _imgTupCorvidReactor,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupCaduceusReactor[i], ref iPosX, iPosY, iSize,
                            _imgTupCaduceusReactor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupDurableMaterials[i], ref iPosX, iPosY, iSize,
                            _imgTupDurableMaterials, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupVehicleShipPlanting1[i], ref iPosX, iPosY, iSize,
                            _imgTupVehicleShipPlanting1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupVehicleShipPlanting2[i], ref iPosX, iPosY, iSize,
                            _imgTupVehicleShipPlanting2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupVehicleShipPlanting3[i], ref iPosX, iPosY, iSize,
                            _imgTupVehicleShipPlanting3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupVehicleWeapon1[i], ref iPosX, iPosY, iSize,
                            _imgTupVehicleWeapon1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupVehicleWeapon2[i], ref iPosX, iPosY, iSize,
                            _imgTupVehicleWeapon2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupVehicleWeapon3[i], ref iPosX, iPosY, iSize,
                            _imgTupVehicleWeapon3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupShipWeapon1[i], ref iPosX, iPosY, iSize, _imgTupShipWeapon1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupShipWeapon2[i], ref iPosX, iPosY, iSize, _imgTupShipWeapon2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupShipWeapon3[i], ref iPosX, iPosY, iSize, _imgTupShipWeapon3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupInfantryArmor1[i], ref iPosX, iPosY, iSize,
                            _imgTupInfantryArmor1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupInfantryArmor2[i], ref iPosX, iPosY, iSize,
                            _imgTupInfantryArmor2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupInfantryArmor3[i], ref iPosX, iPosY, iSize,
                            _imgTupInfantryArmor3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupInfantryWeapon1[i], ref iPosX, iPosY, iSize,
                            _imgTupInfantryWeapon1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupInfantryWeapon2[i], ref iPosX, iPosY, iSize,
                            _imgTupInfantryWeapon2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupInfantryWeapon3[i], ref iPosX, iPosY, iSize,
                            _imgTupInfantryWeapon3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupHighSecAutoTracking[i], ref iPosX, iPosY, iSize,
                            _imgTupHighSecAutoTracking, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupStructureArmor[i], ref iPosX, iPosY, iSize,
                            _imgTupStructureArmor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lTupNeosteelFrame[i], ref iPosX, iPosY, iSize, _imgTupNeosteelFrame,
                            g,
                            clPlayercolor, fStringFont, false);

                        #endregion

                        #region Protoss

                        Helper_DrawUnitsProduction(_lPupAirArmor1[i], ref iPosX, iPosY, iSize, _imgPupAirArmor1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupAirArmor2[i], ref iPosX, iPosY, iSize, _imgPupAirArmor2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupAirArmor3[i], ref iPosX, iPosY, iSize, _imgPupAirArmor3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupAirWeapon1[i], ref iPosX, iPosY, iSize, _imgPupAirWeapon1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupAirWeapon2[i], ref iPosX, iPosY, iSize, _imgPupAirWeapon2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupAirWeapon3[i], ref iPosX, iPosY, iSize, _imgPupAirWeapon3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupGroundWeapon1[i], ref iPosX, iPosY, iSize, _imgPupGroundWeapon1,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupGroundWeapon2[i], ref iPosX, iPosY, iSize, _imgPupGroundWeapon2,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupGroundWeapon3[i], ref iPosX, iPosY, iSize, _imgPupGroundWeapon3,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupGroundArmor1[i], ref iPosX, iPosY, iSize, _imgPupGroundArmor1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupGroundArmor2[i], ref iPosX, iPosY, iSize, _imgPupGroundArmor2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupGroundArmor3[i], ref iPosX, iPosY, iSize, _imgPupGroundArmor3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupShield1[i], ref iPosX, iPosY, iSize, _imgPupShield1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupShield2[i], ref iPosX, iPosY, iSize, _imgPupShield2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupShield3[i], ref iPosX, iPosY, iSize, _imgPupShield3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupExtendedThermalLance[i], ref iPosX, iPosY, iSize,
                            _imgPupExtendedThermalLance, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupGraviticBooster[i], ref iPosX, iPosY, iSize,
                            _imgPupGraviticBooster, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupGraviticDrive[i], ref iPosX, iPosY, iSize, _imgPupGraviticDrive,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupGravitonCatapult[i], ref iPosX, iPosY, iSize,
                            _imgPupGravitonCatapult, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupStorm[i], ref iPosX, iPosY, iSize, _imgPupStorm, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupBlink[i], ref iPosX, iPosY, iSize, _imgPupBlink, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupCharge[i], ref iPosX, iPosY, iSize, _imgPupCharge, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupAnionPulseCrystal[i], ref iPosX, iPosY, iSize,
                            _imgPupAnionPulseCrystals, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lPupWarpGate[i], ref iPosX, iPosY, iSize, _imgPupWarpGate, g,
                            clPlayercolor, fStringFont, false);

                        #endregion

                        #region Zerg

                        Helper_DrawUnitsProduction(_lZupAdrenalGlands[i], ref iPosX, iPosY, iSize, _imgZupAdrenalGlands,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupAirArmor1[i], ref iPosX, iPosY, iSize, _imgZupAirArmor1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupAirArmor2[i], ref iPosX, iPosY, iSize, _imgZupAirArmor2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupAirArmor3[i], ref iPosX, iPosY, iSize, _imgZupAirArmor3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupAirWeapon1[i], ref iPosX, iPosY, iSize, _imgZupAirWeapon1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupAirWeapon2[i], ref iPosX, iPosY, iSize, _imgZupAirWeapon2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupAirWeapon3[i], ref iPosX, iPosY, iSize, _imgZupAirWeapon3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupBurrow[i], ref iPosX, iPosY, iSize, _imgZupBurrow, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupCentrifugalHooks[i], ref iPosX, iPosY, iSize,
                            _imgZupCentrifugalHooks, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupChitinousPlating[i], ref iPosX, iPosY, iSize,
                            _imgZupChitinousPlating, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupEnduringLocusts[i], ref iPosX, iPosY, iSize,
                            _imgZupEnduringLocusts, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupGlialReconstruction[i], ref iPosX, iPosY, iSize,
                            _imgZupGlialReconstruction, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupGroovedSpines[i], ref iPosX, iPosY, iSize, _imgZupGroovedSpines,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupGroundArmor1[i], ref iPosX, iPosY, iSize, _imgZupGroundArmor1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupGroundArmor2[i], ref iPosX, iPosY, iSize, _imgZupGroundArmor2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupGroundArmor3[i], ref iPosX, iPosY, iSize, _imgZupGroundArmor3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupGroundMelee1[i], ref iPosX, iPosY, iSize, _imgZupGroundMelee1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupGroundMelee2[i], ref iPosX, iPosY, iSize, _imgZupGroundMelee2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupGroundMelee3[i], ref iPosX, iPosY, iSize, _imgZupGroundMelee3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupGroundWeapon1[i], ref iPosX, iPosY, iSize, _imgZupGroundWeapon1,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupGroundWeapon2[i], ref iPosX, iPosY, iSize, _imgZupGroundWeapon2,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupGroundWeapon3[i], ref iPosX, iPosY, iSize, _imgZupGroundWeapon3,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupMetabolicBoost[i], ref iPosX, iPosY, iSize,
                            _imgZupMetabolicBoost, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupMuscularAugments[i], ref iPosX, iPosY, iSize,
                            _imgZupMuscularAugments, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupNeutralParasite[i], ref iPosX, iPosY, iSize,
                            _imgZupNeutralParasite, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupPathoglenGlands[i], ref iPosX, iPosY, iSize,
                            _imgZupPathoglenGlands, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupPneumatizedCarapace[i], ref iPosX, iPosY, iSize,
                            _imgZupPneumatizedCarapace, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupTunnnelingClaws[i], ref iPosX, iPosY, iSize,
                            _imgZupTunnelingClaws, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(_lZupVentralSacs[i], ref iPosX, iPosY, iSize, _imgZupVentrallSacs, g,
                            clPlayercolor, fStringFont, false);


                        #endregion

                        iWidthUpgrades = iPosX;
                    }

                    #endregion

                    if (iPosX > iPosXAfterName)
                    {
                        iPosY += iSize + 2;
                    }

                 
                       


                    /* Check which width is bigger */
                    //if (iWidthUnits > iWidthBuildings)
                    //{
                    //    if (iWidthUnits > iWidthUpgrades)
                    //        iPosX = iWidthUnits;

                    //    else if (iWidthUpgrades > iWidthUnits)
                    //        iPosX = iWidthUpgrades;
                    //}

                    //else if (iWidthBuildings > iWidthUnits)
                    //{
                    //    if (iWidthBuildings > iWidthUpgrades)
                    //        iPosX = iWidthBuildings;

                    //    else if (iWidthUpgrades > iWidthBuildings)
                    //        iPosX = iWidthUpgrades;
                    //}

                    //else if (iWidthUpgrades > iWidthUnits)
                    //{
                    //    if (iWidthBuildings > iWidthUpgrades)
                    //        iPosX = iWidthBuildings;

                    //    else if (iWidthUpgrades > iWidthBuildings)
                    //        iPosX = iWidthUpgrades;
                    //}

                    var iWidthMax = HelpFunctions.GetMaximumInteger(iWidthBuildings, iWidthUnits, iWidthUpgrades);
                    iPosX = iWidthMax;

                    //iPosX = iWidthUnits > iWidthBuildings ? iWidthUnits : iWidthBuildings;

                    //iPosX = iWidthUnits > iWidthBuildings ? iWidthUnits : iWidthBuildings;

                    /* Adjust maximum width */
                    if (iPosX >= iMaximumWidth)
                        iMaximumWidth = iPosX;

                    if (iHavetoadd > 0)
                        iMaximumWidth += iSize;
                }

                if (FormBorderStyle == FormBorderStyle.None)
                {
                    Width = iMaximumWidth + 1;
                    Height = iPosY;
                }

                else
                {
                    _iProdPanelWidth = iMaximumWidth + 1;
                    _iProdPanelWidthWithoutName = _iProdPanelWidth - iPosXAfterName;
                    _iProdPosAfterName = iPosXAfterName;
                }

            }

            catch (Exception ex)
            {
                Messages.LogFile("DrawProduction", "Over all", ex);
            }
        }


        /* Draw Personal APM */
        private void DrawPersonalApm(BufferedGraphics g)
        {
            if (!_hMainHandler.GInformation.Gameinfo.IsIngame)
                return;

            var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;

            if (iValidPlayerCount == 0)
                return;

            if (_hMainHandler.GInformation.Player.Count <= 0)
                return;

            if (_hMainHandler.GInformation.Player[0].Localplayer == 16)
                return;

            var iSingleHeight = Height;
            var fNewFontSize = (float)((29.0 / 100) * iSingleHeight);


            var clApmColor = Brushes.Green;
            if (_pSettings.PersonalApmAlert)
            {
                if (_hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Apm <
                    _pSettings.PersonalApmAlertLimit)
                    clApmColor = Brushes.Red;
            }

            Drawing.DrawString(g.Graphics,
                "APM: " +
                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].ApmAverage.ToString(
                    CultureInfo.InvariantCulture) + " [" +
                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Apm.ToString(
                    CultureInfo.InvariantCulture) + "]",
                new Font("Century Gothic", fNewFontSize, FontStyle.Regular),
                clApmColor,
                Brushes.Black, (float) ((13.67/100)*Width),
                (float) ((24.0/100)*iSingleHeight),
                1f, 1f, true);
        }

        /* Draw Personal APM */
        private void DrawPersonalClock(BufferedGraphics g)
        {
            if (!_hMainHandler.GInformation.Gameinfo.IsIngame)
                return;

            var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;

            if (iValidPlayerCount == 0)
                return;

            if (_hMainHandler.GInformation.Player.Count <= 0)
                return;


            var iSingleHeight = Height;
            var fNewFontSize = (float)((29.0 / 100) * iSingleHeight);

            var dtTimeStamp = DateTime.Now;
            var strTime = dtTimeStamp.TimeOfDay.ToString().Substring(0, 8);

            Drawing.DrawString(g.Graphics,
               "Time: " + strTime,
               new Font("Century Gothic", fNewFontSize, FontStyle.Regular),
               Brushes.White,
               Brushes.Black, (float)((13.67 / 100) * Width),
                (float)((24.0 / 100) * iSingleHeight),
               1f, 1f, true);
        }

        /* Draw Overqueued Units */
        private void DrawOverqueuedUnits(BufferedGraphics g)
        {
           /* Only showing for the local player! */
            try
            {
                #region Return if filter is active

                if (!_hMainHandler.GInformation.Gameinfo.IsIngame)
                {
                    g.Graphics.Clear(BackColor);
                    return;
                }

                if (_hMainHandler.GInformation.Player == null ||
                    _hMainHandler.GInformation.Player.Count <= 0)
                    return;

                #endregion

                Opacity = _pSettings.WorkerOpacity;
                var iSingleHeight = Height;
                var fNewFontSize = (float)((29.0 / 100) * iSingleHeight);
                var fInternalFont = new Font(_pSettings.WorkerFontName, fNewFontSize, FontStyle.Bold);

                Color clPlayercolor;

                if (_hMainHandler.GInformation.Player[0].Localplayer < _hMainHandler.GInformation.Player.Count)
                    clPlayercolor = _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Color;

                else
                    return;



                #region Teamcolor

                if (_hMainHandler.GInformation.Gameinfo.IsTeamcolor)
                    clPlayercolor = Color.Green;

                #endregion

                #region Draw Bounds and Background

                if (_pSettings.WorkerDrawBackground)
                {
                    /* Background */
                    g.Graphics.FillRectangle(Brushes.Gray, 1, 1, Width - 2, iSingleHeight - 2);

                    /* Border */
                    g.Graphics.DrawRectangle(new Pen(new SolidBrush(clPlayercolor), 2), 1, 1, Width - 2,
                                             iSingleHeight - 2);
                }

                #endregion

                #region Actual Drawing

                CountUnits_2();

                

                /* Text */
                g.Graphics.DrawString(_hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[0].Localplayer].Worker + "   Workers", fInternalFont,
                                      new SolidBrush(clPlayercolor), (float)((16.67 / 100) * Width),
                                      (float)((24.0 / 100) * iSingleHeight));

                #endregion

            }

            catch (Exception ex)
            {
                Messages.LogFile("DrawOverqueuedUnits", "Over all", ex);
            }
        }

        #endregion

        /* Refresges the drawing */
        private void tmrRefreshGraphic_Tick(object sender, EventArgs e)
        {
            //_swMainWatch.Reset();
            //_swMainWatch.Start();

            Invalidate();

            //_swMainWatch.Stop();
            //Debug.WriteLine("Time to Invalidate:" + 1000000 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency + " µs");


            if (HelpFunctions.HotkeysPressed(_pSettings.GlobalChangeSizeAndPosition))
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
            _pSettings = _hMainHandler.PSettings;

            /* Refresh Top- Most */
            if (
                _hMainHandler.PSc2Process != null && _hMainHandler.PSc2Process.ProcessName.Length > 0 &&
                InteropCalls.GetForegroundWindow().Equals(_hMainHandler.PSc2Process.MainWindowHandle))
            {
                if ((DateTime.Now - _dtBegin).Seconds > 1)
                {
                    RefreshForeground(Handle);
                    _dtBegin = DateTime.Now;
                }
            }

            //_swMainWatch.Stop();
            //Debug.WriteLine("Time to Iterate the timer:" + 1000000 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency + " µs");
        }

        /* Load Preferences into the controls */
        private void LoadPreferencesIntoControls()
        {
            /* Set mainform to max. Mainscreen size and position */
            if (_rRenderForm.Equals(PredefinedData.RenderForm.Resources))
            {
                Location = new Point(_pSettings.ResourcePositionX,
                                     _pSettings.ResourcePositionY);
                Size = new Size(_pSettings.ResourceWidth, _pSettings.ResourceHeight);
                Opacity = _pSettings.ResourceOpacity;
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Income))
            {
                Location = new Point(_pSettings.IncomePositionX,
                                     _pSettings.IncomePositionY);
                Size = new Size(_pSettings.IncomeWidth, _pSettings.IncomeHeight);
                Opacity = _pSettings.IncomeOpacity;
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Army))
            {
                Location = new Point(_pSettings.ArmyPositionX,
                                     _pSettings.ArmyPositionY);
                Size = new Size(_pSettings.ArmyWidth, _pSettings.ArmyHeight);
                Opacity = _pSettings.ArmyOpacity;
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Apm))
            {
                Location = new Point(_pSettings.ApmPositionX,
                                     _pSettings.ApmPositionY);
                Size = new Size(_pSettings.ApmWidth, _pSettings.ApmHeight);
                Opacity = _pSettings.ApmOpacity;
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Worker))
            {
                Location = new Point(_pSettings.WorkerPositionX,
                                     _pSettings.WorkerPositionY);
                Size = new Size(_pSettings.WorkerWidth, _pSettings.WorkerHeight);
                Opacity = _pSettings.WorkerOpacity;
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Maphack))
            {
                Location = new Point(_pSettings.MaphackPositionX, _pSettings.MaphackPositionY);
                Size = new Size(_pSettings.MaphackWidth, _pSettings.MaphackHeight);
                Opacity = _pSettings.MaphackOpacity;
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Units))
            {
                Location = new Point(_pSettings.UnitTabPositionX, _pSettings.UnitTabPositionY);
                Size = new Size(_pSettings.UnitTabWidth, _pSettings.UnitTabHeight);
                Opacity = _pSettings.UnitTabOpacity;
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Production))
            {
                Location = new Point(_pSettings.ProdTabPositionX, _pSettings.ProdTabPositionY);
                Size = new Size(_pSettings.ProdTabWidth, _pSettings.ProdTabHeight);
                Opacity = _pSettings.ProdTabOpacity;
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.PersonalApm))
            {
                Location = new Point(_pSettings.PersonalApmPositionX,
                                     _pSettings.PersonalApmPositionY);
                Size = new Size(_pSettings.PersonalApmWidth,
                                _pSettings.PersonalApmHeight);
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.PersonalClock))
            {
                Location = new Point(_pSettings.PersonalClockPositionX,
                                     _pSettings.PersonalClockPositionY);
                Size = new Size(_pSettings.PersonalClockWidth,
                                _pSettings.PersonalClockHeight);
            }

           /* Timer on load */
            tmrRefreshGraphic.Interval = _pSettings.GlobalDrawingRefresh;
        }

        /* Change the windowstyle */
        private void ChangeWindowStyle()
        {
            if (SetWindowStyle.Equals(PredefinedData.CustomWindowStyles.Clickable))
            {
                _bChangingPosition = true;
                _bSurpressForeground = true;
                HelpFunctions.SetWindowStyle(Handle, PredefinedData.CustomWindowStyles.Clickable);
            }

            else if (SetWindowStyle.Equals(PredefinedData.CustomWindowStyles.NotClickable))
            {
                _bSurpressForeground = false;

                if (!_bMouseDown)
                    _bChangingPosition = false;
                HelpFunctions.SetWindowStyle(Handle, PredefinedData.CustomWindowStyles.NotClickable);
            }

            return;

            /*
            if (InteropCalls.GetAsyncKeyState(_pSettings.GlobalChangeSizeAndPosition) <= -32767)
            {
                //var initial = InteropCalls.GetWindowLong(Handle, (Int32) InteropCalls.Gwl.ExStyle);
                //InteropCalls.SetWindowLong(Handle, (Int32) InteropCalls.Gwl.ExStyle,
                //                            (IntPtr) (initial & ~(Int32) InteropCalls.Ws.ExTransparent));
                HelpFunctions.SetWindowStyle(Handle, PredefinedTypes.CustomWindowStyles.Clickable);
                _bChangingPosition = true;
                _bSurpressForeground = true;
            }

            else
            {
                //var initial = InteropCalls.GetWindowLong(Handle, (Int32) InteropCalls.Gwl.ExStyle);
                //InteropCalls.SetWindowLong(Handle, (Int32) InteropCalls.Gwl.ExStyle,
                //                            (IntPtr) (initial | (Int32) InteropCalls.Ws.ExTransparent));
                HelpFunctions.SetWindowStyle(Handle, PredefinedTypes.CustomWindowStyles.NotClickable);
                _bSurpressForeground = false;

                if (!_bMouseDown)
                    _bChangingPosition = false;
            }
           */
        }

        /* Ajust Panelposition */
        private Boolean _bSetPosition;
        private Boolean _bToggle;
        private void AdjustPanelPosition()
        {
            #region Resources

            if (_rRenderForm.Equals(PredefinedData.RenderForm.Resources))
            {
                if (_bSetPosition)
                {
                    tmrRefreshGraphic.Interval = 20;

                    Location = Cursor.Position;
                    _pSettings.ResourcePositionX = Cursor.Position.X;
                    _pSettings.ResourcePositionY = Cursor.Position.Y;
                }

                var strInput = _strBackup;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));

                if (strInput.Equals(_pSettings.ResourceChangePositionPanel))
                {
                    if (_bToggle)
                    {
                        _bToggle = !_bToggle;

                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = string.Empty;
                    tmrRefreshGraphic.Interval = _pSettings.GlobalDrawingRefresh;

                    /* Transfer to Mainform */
                    _hMainHandler.ResourceInformation.txtPosX.Text = _pSettings.ResourcePositionX.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.ResourceInformation.txtPosY.Text = _pSettings.ResourcePositionY.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion

            #region Income

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Income))
            {
                if (_bSetPosition)
                {
                    tmrRefreshGraphic.Interval = 20;

                    Location = Cursor.Position;

                  
                    _hMainHandler.PSettings.IncomePositionX = Cursor.Position.X;
                    _hMainHandler.PSettings.IncomePositionY = Cursor.Position.Y;
                }

                var strInput = _strBackup;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));

                if (strInput.Equals(_hMainHandler.PSettings.IncomeChangePositionPanel))
                {
                    if (_bToggle)
                    {
                        _bToggle = !_bToggle;

                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = string.Empty;
                    tmrRefreshGraphic.Interval = _pSettings.GlobalDrawingRefresh;

                    /* Transfer to Mainform */
                    _hMainHandler.IncomeInformation.txtPosX.Text = _pSettings.IncomePositionX.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.IncomeInformation.txtPosY.Text = _pSettings.IncomePositionY.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion

            #region Worker

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Worker))
            {
                if (_bSetPosition)
                {
                    tmrRefreshGraphic.Interval = 20;

                    Location = Cursor.Position;
                    _hMainHandler.PSettings.WorkerPositionX = Cursor.Position.X;
                    _hMainHandler.PSettings.WorkerPositionY = Cursor.Position.Y;

                   
                }

                var strInput = _strBackup;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));

                if (strInput.Equals(_hMainHandler.PSettings.WorkerChangePositionPanel))
                {
                    if (_bToggle)
                    {
                        _bToggle = !_bToggle;

                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = string.Empty;
                    tmrRefreshGraphic.Interval = _hMainHandler.PSettings.GlobalDrawingRefresh;

                    /* Transfer to Mainform */
                    _hMainHandler.WorkerInformation.txtPosX.Text = _hMainHandler.PSettings.WorkerPositionX.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.WorkerInformation.txtPosY.Text = _hMainHandler.PSettings.WorkerPositionY.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion

            #region Apm

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Apm))
            {
                if (_bSetPosition)
                {
                    tmrRefreshGraphic.Interval = 20;

                    Location = Cursor.Position;
                    _hMainHandler.PSettings.ApmPositionX = Cursor.Position.X;
                    _hMainHandler.PSettings.ApmPositionY = Cursor.Position.Y;
                }

                var strInput = _strBackup;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));

                if (strInput.Equals(_hMainHandler.PSettings.ApmChangePositionPanel))
                {
                    if (_bToggle)
                    {
                        _bToggle = !_bToggle;

                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = string.Empty;
                    tmrRefreshGraphic.Interval = _hMainHandler.PSettings.GlobalDrawingRefresh;

                    /* Transfer to Mainform */
                    _hMainHandler.ApmInformation.txtPosX.Text = _hMainHandler.PSettings.ApmPositionX.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.ApmInformation.txtPosY.Text = _hMainHandler.PSettings.ApmPositionY.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion

            #region Army

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Army))
            {
                if (_bSetPosition)
                {
                    tmrRefreshGraphic.Interval = 20;

                    Location = Cursor.Position;
                    _hMainHandler.PSettings.ArmyPositionX = Cursor.Position.X;
                    _hMainHandler.PSettings.ArmyPositionY = Cursor.Position.Y;
                }

                var strInput = _strBackup;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));

                if (strInput.Equals(_hMainHandler.PSettings.ArmyChangePositionPanel))
                {
                    if (_bToggle)
                    {
                        _bToggle = !_bToggle;

                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = string.Empty;
                    tmrRefreshGraphic.Interval = _hMainHandler.PSettings.GlobalDrawingRefresh;

                    /* Transfer to Mainform */
                    _hMainHandler.ArmyInformation.txtPosX.Text = _hMainHandler.PSettings.ArmyPositionX.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.ArmyInformation.txtPosY.Text = _hMainHandler.PSettings.ArmyPositionY.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion

            #region Maphack

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Maphack))
            {
                if (_bSetPosition)
                {
                    tmrRefreshGraphic.Interval = 20;

                    Location = Cursor.Position;
                    _hMainHandler.PSettings.MaphackPositionX = Cursor.Position.X;
                    _hMainHandler.PSettings.MaphackPositionY = Cursor.Position.Y;
                }

                var strInput = _strBackup;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));

                if (strInput.Equals(_hMainHandler.PSettings.MaphackChangePositionPanel))
                {
                    if (_bToggle)
                    {
                        _bToggle = !_bToggle;

                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = string.Empty;
                    tmrRefreshGraphic.Interval = _hMainHandler.PSettings.GlobalDrawingRefresh;

                    /* Transfer to Mainform */
                    _hMainHandler.MaphackInformation.txtPosX.Text = _hMainHandler.PSettings.MaphackPositionX.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.MaphackInformation.txtPosY.Text = _hMainHandler.PSettings.MaphackPositionY.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion

            #region Units

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Units))
            {
                if (_bSetPosition)
                {
                    tmrRefreshGraphic.Interval = 20;

                    Location = Cursor.Position;
                    _hMainHandler.PSettings.UnitTabPositionX = Cursor.Position.X;
                    _hMainHandler.PSettings.UnitTabPositionY = Cursor.Position.Y;
                }

                var strInput = _strBackup;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));

                if (strInput.Equals(_hMainHandler.PSettings.UnitChangePositionPanel))
                {
                    if (_bToggle)
                    {
                        _bToggle = !_bToggle;

                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = string.Empty;
                    tmrRefreshGraphic.Interval = _hMainHandler.PSettings.GlobalDrawingRefresh;

                    /* Transfer to Mainform */
                    _hMainHandler.UnittabInformation.txtPosX.Text = _hMainHandler.PSettings.UnitTabPositionX.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.UnittabInformation.txtPosY.Text = _hMainHandler.PSettings.UnitTabPositionY.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion

            #region Production

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Production))
            {
                if (_bSetPosition)
                {
                    tmrRefreshGraphic.Interval = 20;

                    Location = Cursor.Position;
                    _hMainHandler.PSettings.ProdTabPositionX = Cursor.Position.X;
                    _hMainHandler.PSettings.ProdTabPositionY = Cursor.Position.Y;
                }

                var strInput = _strBackup;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));

                if (strInput.Equals(_hMainHandler.PSettings.ProdChangePositionPanel))
                {
                    if (_bToggle)
                    {
                        _bToggle = !_bToggle;

                        if (!_bSetPosition)
                            _bSetPosition = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    _bSetPosition = false;
                    _strBackup = string.Empty;
                    tmrRefreshGraphic.Interval = _hMainHandler.PSettings.GlobalDrawingRefresh;

                    /* Transfer to Mainform */
                    _hMainHandler.ProductionTabInformation.txtPosX.Text = _hMainHandler.PSettings.ProdTabPositionX.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.ProductionTabInformation.txtPosY.Text = _hMainHandler.PSettings.ProdTabPositionY.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion
        }

        /* Adjust Panelsize */
        private Boolean _bSetSize;
        private Boolean _bToggleSize;
        private void AdjustPanelSize()
        {
            #region Resources

            if (_rRenderForm.Equals(PredefinedData.RenderForm.Resources))
            {
                if (_bSetSize)
                {
                    tmrRefreshGraphic.Interval = 20;

                    _hMainHandler.PSettings.ResourceWidth = Cursor.Position.X - Left;

                    var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;
                    if (_hMainHandler.PSettings.ResourceRemoveNeutral)
                        iValidPlayerCount -= 1;



                    /* If the Valid Player count is zero, change it.. */
                    var iRealPlayerCount = iValidPlayerCount == 0 ? 1 : iValidPlayerCount;

                    if ((Cursor.Position.Y - Top) / iRealPlayerCount >= 5)
                    {
                        _hMainHandler.PSettings.ResourceHeight = (Cursor.Position.Y - Top)/
                                                                 iRealPlayerCount;
                    }

                    else
                        _hMainHandler.PSettings.ResourceHeight = 5;

                    
                }

                var strInput = _strBackupSize;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));


                if (strInput.Equals(_hMainHandler.PSettings.ResourceChangeSizePanel))
                {
                    if (_bToggleSize)
                    {
                        _bToggleSize = !_bToggleSize;

                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    tmrRefreshGraphic.Interval = _hMainHandler.PSettings.GlobalDrawingRefresh;

                    _bSetSize = false;
                    _strBackupSize = string.Empty;

                    /* Transfer to Mainform */
                    _hMainHandler.ResourceInformation.txtWidth.Text = _hMainHandler.PSettings.ResourceWidth.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.ResourceInformation.txtHeight.Text = _hMainHandler.PSettings.ResourceHeight.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion

            #region Income

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Income))
            {
                if (_bSetSize)
                {
                    tmrRefreshGraphic.Interval = 20;

                    _hMainHandler.PSettings.IncomeWidth = Cursor.Position.X - Left;

                    var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;
                    if (_hMainHandler.PSettings.ResourceRemoveNeutral)
                        iValidPlayerCount -= 1;

                    if ((Cursor.Position.Y - Top) / iValidPlayerCount >= 5)
                    {
                        _hMainHandler.PSettings.IncomeHeight = (Cursor.Position.Y - Top)/
                                                               iValidPlayerCount;
                    }

                    else
                        _hMainHandler.PSettings.IncomeHeight = 5;
                }

                var strInput = _strBackupSize;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));


                if (strInput.Equals(_hMainHandler.PSettings.IncomeChangeSizePanel))
                {
                    if (_bToggleSize)
                    {
                        _bToggleSize = !_bToggleSize;

                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    tmrRefreshGraphic.Interval = _hMainHandler.PSettings.GlobalDrawingRefresh;

                    _bSetSize = false;
                    _strBackupSize = string.Empty;

                    /* Transfer to Mainform */
                    _hMainHandler.IncomeInformation.txtWidth.Text = _hMainHandler.PSettings.IncomeWidth.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.IncomeInformation.txtHeight.Text = _hMainHandler.PSettings.IncomeHeight.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion

            #region Worker

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Worker))
            {
                if (_bSetSize)
                {
                    tmrRefreshGraphic.Interval = 20;

                    _hMainHandler.PSettings.WorkerWidth = Cursor.Position.X - Left;

                    if ((Cursor.Position.Y - Top) >= 5)
                        _hMainHandler.PSettings.WorkerHeight = (Cursor.Position.Y - Top);
                    

                    else
                        _hMainHandler.PSettings.WorkerHeight = 5;
                }

                var strInput = _strBackupSize;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));


                if (strInput.Equals(_hMainHandler.PSettings.WorkerChangeSizePanel))
                {
                    if (_bToggleSize)
                    {
                        _bToggleSize = !_bToggleSize;

                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    tmrRefreshGraphic.Interval = _hMainHandler.PSettings.GlobalDrawingRefresh;

                    _bSetSize = false;
                    _strBackupSize = string.Empty;

                    /* Transfer to Mainform */
                    _hMainHandler.WorkerInformation.txtWidth.Text = _hMainHandler.PSettings.WorkerWidth.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.WorkerInformation.txtHeight.Text = _hMainHandler.PSettings.WorkerHeight.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion

            #region Apm

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Apm))
            {
                if (_bSetSize)
                {
                    tmrRefreshGraphic.Interval = 20;

                    _hMainHandler.PSettings.ApmWidth = Cursor.Position.X - Left;

                    var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;
                    if (_hMainHandler.PSettings.ResourceRemoveNeutral)
                        iValidPlayerCount -= 1;

                    if ((Cursor.Position.Y - Top) / iValidPlayerCount >= 5)
                    {
                        _hMainHandler.PSettings.ApmHeight = (Cursor.Position.Y - Top)/
                                                            iValidPlayerCount;
                    }

                    else
                        _hMainHandler.PSettings.MaphackHeight = 5;
                }

                var strInput = _strBackupSize;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));


                if (strInput.Equals(_hMainHandler.PSettings.ApmChangeSizePanel))
                {
                    if (_bToggleSize)
                    {
                        _bToggleSize = !_bToggleSize;

                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    tmrRefreshGraphic.Interval = _hMainHandler.PSettings.GlobalDrawingRefresh;

                    _bSetSize = false;
                    _strBackupSize = string.Empty;

                    /* Transfer to Mainform */
                    _hMainHandler.ApmInformation.txtWidth.Text = _hMainHandler.PSettings.ApmWidth.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.ApmInformation.txtHeight.Text = _hMainHandler.PSettings.ApmHeight.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion

            #region Army

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Army))
            {
                if (_bSetSize)
                {
                    tmrRefreshGraphic.Interval = 20;

                    _hMainHandler.PSettings.ArmyWidth = Cursor.Position.X - Left;

                    var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;
                    if (_hMainHandler.PSettings.ResourceRemoveNeutral)
                        iValidPlayerCount -= 1;

                    if ((Cursor.Position.Y - Top) / iValidPlayerCount >= 5)
                    {
                        _hMainHandler.PSettings.ArmyHeight = (Cursor.Position.Y - Top)/
                                                             iValidPlayerCount;
                    }
                    else
                        _hMainHandler.PSettings.ApmHeight = 5;
                }

                var strInput = _strBackupSize;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));


                if (strInput.Equals(_hMainHandler.PSettings.ArmyChangeSizePanel))
                {
                    if (_bToggleSize)
                    {
                        _bToggleSize = !_bToggleSize;

                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    tmrRefreshGraphic.Interval = _pSettings.GlobalDrawingRefresh;

                    _bSetSize = false;
                    _strBackupSize = string.Empty;

                    /* Transfer to Mainform */
                    _hMainHandler.ArmyInformation.txtWidth.Text = _pSettings.ArmyWidth.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.ArmyInformation.txtHeight.Text = _pSettings.ArmyHeight.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion

            #region Maphack

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Maphack))
            {
                if (_bSetSize)
                {
                    tmrRefreshGraphic.Interval = 20;

                    _hMainHandler.PSettings.MaphackWidth = Cursor.Position.X - Left;

                    if ((Cursor.Position.Y - Top) >= 5)
                        _hMainHandler.PSettings.MaphackHeight = (Cursor.Position.Y - Top);

                    else
                        _hMainHandler.PSettings.MaphackHeight = 5;

                }

                var strInput = _strBackupSize;

                if (String.IsNullOrEmpty(strInput))
                    return;
                

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));


                if (strInput.Equals(_hMainHandler.PSettings.MaphackChangeSizePanel))
                {
                    if (_bToggleSize)
                    {
                        _bToggleSize = !_bToggleSize;

                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    tmrRefreshGraphic.Interval = _pSettings.GlobalDrawingRefresh;
                    
                    _bSetSize = false;
                    _strBackupSize = string.Empty;

                    /* Transfer to Mainform */
                    _hMainHandler.MaphackInformation.txtWidth.Text = _pSettings.MaphackWidth.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.MaphackInformation.txtHeight.Text = _pSettings.MaphackHeight.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion

            #region Units

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Units))
            {
                if (_bSetSize)
                {
                    tmrRefreshGraphic.Interval = 20;

                    _hMainHandler.PSettings.UnitTabWidth = Cursor.Position.X - Left;

                    if ((Cursor.Position.Y - Top) >= 5)
                        _hMainHandler.PSettings.UnitTabHeight = (Cursor.Position.Y - Top);

                    else
                        _hMainHandler.PSettings.UnitTabHeight = 5;
                }

                var strInput = _strBackupSize;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));


                if (strInput.Equals(_hMainHandler.PSettings.UnitChangeSizePanel))
                {
                    if (_bToggleSize)
                    {
                        _bToggleSize = !_bToggleSize;

                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    tmrRefreshGraphic.Interval = _hMainHandler.PSettings.GlobalDrawingRefresh;

                    _bSetSize = false;
                    _strBackupSize = string.Empty;

                    /* Transfer to Mainform */
                    _hMainHandler.UnittabInformation.txtWidth.Text = _pSettings.UnitTabWidth.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.UnittabInformation.txtHeight.Text = _pSettings.UnitTabHeight.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion

            #region Production

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Production))
            {
                if (_bSetSize)
                {
                    tmrRefreshGraphic.Interval = 20;

                    _hMainHandler.PSettings.ProdTabWidth = Cursor.Position.X - Left;

                    if ((Cursor.Position.Y - Top) >= 5)
                        _hMainHandler.PSettings.ProdTabHeight = (Cursor.Position.Y - Top);

                    else
                        _hMainHandler.PSettings.ProdTabHeight = 5;
                }

                var strInput = _strBackupSize;

                if (String.IsNullOrEmpty(strInput))
                    return;

                if (strInput.Contains('\0'))
                    strInput = strInput.Substring(0, strInput.IndexOf('\0'));


                if (strInput.Equals(_hMainHandler.PSettings.ProdChangeSizePanel))
                {
                    if (_bToggleSize)
                    {
                        _bToggleSize = !_bToggleSize;

                        if (!_bSetSize)
                            _bSetSize = true;
                    }
                }

                if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
                {
                    tmrRefreshGraphic.Interval = _hMainHandler.PSettings.GlobalDrawingRefresh;

                    _bSetSize = false;
                    _strBackupSize = string.Empty;

                    /* Transfer to Mainform */
                    _hMainHandler.ProductionTabInformation.txtWidth.Text = _pSettings.ProdTabWidth.ToString(CultureInfo.InvariantCulture);
                    _hMainHandler.ProductionTabInformation.txtHeight.Text = _pSettings.ProdTabHeight.ToString(CultureInfo.InvariantCulture);
                }
            }

            #endregion
        }

        private string _strBackup = string.Empty;
        private String _strBackupSize = String.Empty;
        public void GetKeyboardInput()
        {
            var sInput = _hMainHandler.GInformation.Gameinfo.ChatInput;

            if (sInput != _strBackup)
                _bToggle = true;

            if (sInput != _strBackupSize)
                _bToggleSize = true;
            

            _strBackup = sInput;
            _strBackupSize = sInput;
        }

        /* Iterate through unitstruct and export UnitId's and Names */
        private readonly List<PredefinedData.Unit> _lUnitForUniqueness = new List<PredefinedData.Unit>(); 
        private void ExportUnitIdsToFile()
        {
            var sfdSaveFile = new SaveFileDialog();
            sfdSaveFile.Filter = "txt (Textfile)|*.txt|csv (Tablesheet)|*.csv";
            var result = sfdSaveFile.ShowDialog();

            if (!result.Equals(DialogResult.OK))
            {
                Close();
                return;
            }

            var sw = new StreamWriter(sfdSaveFile.FileName);

            if (Path.GetExtension(sfdSaveFile.FileName) == ".csv")
            {
                sw.WriteLine("ID; Name; Raw Name");
                for (var i = 0; i < _hMainHandler.GInformation.Unit.Count; i++)
                {
                    var bUnique = false;

                    if (_lUnitForUniqueness.Count <= 0)
                        _lUnitForUniqueness.Add(_hMainHandler.GInformation.Unit[i]);

                    else
                    {
                        for (var j = 0; j < _lUnitForUniqueness.Count; j++)
                        {
                            if (_lUnitForUniqueness[j].Id != _hMainHandler.GInformation.Unit[i].Id)
                                bUnique = true;

                            else
                            {
                                bUnique = false;
                                break;
                            }
                        }

                        if (bUnique)
                            _lUnitForUniqueness.Add(_hMainHandler.GInformation.Unit[i]);  
                    }  
                }

                _lUnitForUniqueness.Sort((x, y) => x.Id.CompareTo(y.Id));

                for (var i = 0; i < _lUnitForUniqueness.Count; i++ )
                    sw.WriteLine((int)_lUnitForUniqueness[i].Id + ";" + _lUnitForUniqueness[i].Name + ";" +
                                             _lUnitForUniqueness[i].RawName);
                sw.Close();
                Close();
    
            }

            else
            {
                sw.WriteLine("public enum UnitId");
                sw.WriteLine("{");
                for (var i = 0; i < _hMainHandler.GInformation.Unit.Count; i++)
                {
                    var bUnique = false;

                    if (_lUnitForUniqueness.Count <= 0)
                        _lUnitForUniqueness.Add(_hMainHandler.GInformation.Unit[i]);

                    else
                    {
                        for (var j = 0; j < _lUnitForUniqueness.Count; j++)
                        {
                            if (_lUnitForUniqueness[j].Id != _hMainHandler.GInformation.Unit[i].Id)
                                bUnique = true;

                            else
                            {
                                bUnique = false;
                                break;
                            }
                        }

                        if (bUnique)
                            _lUnitForUniqueness.Add(_hMainHandler.GInformation.Unit[i]);
                    }  
                }

                _lUnitForUniqueness.Sort((x, y) => x.Id.CompareTo(y.Id));

                for (var i = 0; i < _lUnitForUniqueness.Count; i++)
                {
                    if (i + 1 == _lUnitForUniqueness.Count)
                        sw.WriteLine("\t" + _lUnitForUniqueness[i].Name + " = " + (int)_lUnitForUniqueness[i].Id);

                    else
                        sw.WriteLine("\t" + _lUnitForUniqueness[i].Name + " = " + (int)_lUnitForUniqueness[i].Id + ",");
                }


                sw.WriteLine("}");
                sw.Close();
                Close();
            }

            Process.Start(sfdSaveFile.FileName);
        }

        #region Mouseactions

        private void Renderer_2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var mousePos = MousePosition;
                mousePos.Offset(-_ptMousePosition.X, -_ptMousePosition.Y);
                Location = mousePos;
            }
        }

        private Boolean _bMouseDown;
        private void Renderer_2_MouseDown(object sender, MouseEventArgs e)
        {
            _ptMousePosition = new Point(e.X, e.Y);

            _bMouseDown = true;
        }

        private void Renderer_2_MouseUp(object sender, MouseEventArgs e)
        {
            InteropCalls.SetForegroundWindow(_hMainHandler.PSc2Process.MainWindowHandle);


            if (_rRenderForm.Equals(PredefinedData.RenderForm.Units))
            {
                _hMainHandler.PSettings.UnitTabPositionX = Location.X;
                _hMainHandler.PSettings.UnitTabPositionY = Location.Y;
                _hMainHandler.PSettings.UnitTabHeight = Height;
                _hMainHandler.PSettings.UnitTabWidth = Width;
                _hMainHandler.PSettings.UnitTabOpacity = Opacity;

                /* Transfer to Mainform */
                _hMainHandler.UnittabInformation.txtPosX.Text = Location.X.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.UnittabInformation.txtPosY.Text = Location.Y.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.UnittabInformation.txtWidth.Text = Width.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.UnittabInformation.txtHeight.Text = Height.ToString(CultureInfo.InvariantCulture);
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Production))
            {
                _hMainHandler.PSettings.ProdTabPositionX = Location.X;
                _hMainHandler.PSettings.ProdTabPositionY = Location.Y;
                _hMainHandler.PSettings.ProdTabHeight = Height;
                _hMainHandler.PSettings.ProdTabWidth = Width;
                _hMainHandler.PSettings.ProdTabOpacity = Opacity;

                /* Transfer to Mainform */
                _hMainHandler.ProductionTabInformation.txtPosX.Text = Location.X.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.ProductionTabInformation.txtPosY.Text = Location.Y.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.ProductionTabInformation.txtWidth.Text = Width.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.ProductionTabInformation.txtHeight.Text = Height.ToString(CultureInfo.InvariantCulture);
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Maphack))
            {
                _hMainHandler.PSettings.MaphackPositionX = Location.X;
                _hMainHandler.PSettings.MaphackPositionY = Location.Y;
                _hMainHandler.PSettings.MaphackHeight = Height;
                _hMainHandler.PSettings.MaphackWidth = Width;
                _hMainHandler.PSettings.MaphackOpacity = Opacity;

                /* Transfer to Mainform */
                _hMainHandler.MaphackInformation.txtPosX.Text = Location.X.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.MaphackInformation.txtPosY.Text = Location.Y.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.MaphackInformation.txtWidth.Text = Width.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.MaphackInformation.txtHeight.Text = Height.ToString(CultureInfo.InvariantCulture);
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Resources))
            {
                /* Has to be calculated manually because each panels has it's own Neutral handling.. */
                var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;


                _hMainHandler.PSettings.ResourcePositionX = Location.X;
                _hMainHandler.PSettings.ResourcePositionY = Location.Y;
                _hMainHandler.PSettings.ResourceWidth = Width;
                _hMainHandler.PSettings.ResourceHeight = Height/iValidPlayerCount;
                _hMainHandler.PSettings.ResourceOpacity = Opacity;

                /* Transfer to Mainform */
                _hMainHandler.ResourceInformation.txtPosX.Text = Location.X.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.ResourceInformation.txtPosY.Text = Location.Y.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.ResourceInformation.txtWidth.Text = Width.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.ResourceInformation.txtHeight.Text = Height.ToString(CultureInfo.InvariantCulture);
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Income))
            {
                /* Has to be calculated manually because each panels has it's own Neutral handling.. */
                var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;

                _hMainHandler.PSettings.IncomePositionX = Location.X;
                _hMainHandler.PSettings.IncomePositionY = Location.Y;
                _hMainHandler.PSettings.IncomeWidth = Width;
                _hMainHandler.PSettings.IncomeHeight = Height/iValidPlayerCount;
                _hMainHandler.PSettings.IncomeOpacity = Opacity;

                /* Transfer to Mainform */
                _hMainHandler.IncomeInformation.txtPosX.Text = Location.X.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.IncomeInformation.txtPosY.Text = Location.Y.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.IncomeInformation.txtWidth.Text = Width.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.IncomeInformation.txtHeight.Text = Height.ToString(CultureInfo.InvariantCulture);
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Army))
            {
                /* Has to be calculated manually because each panels has it's own Neutral handling.. */
                var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;

                _hMainHandler.PSettings.ArmyPositionX = Location.X;
                _hMainHandler.PSettings.ArmyPositionY = Location.Y;
                _hMainHandler.PSettings.ArmyWidth = Width;
                _hMainHandler.PSettings.ArmyHeight = Height/iValidPlayerCount;
                _hMainHandler.PSettings.ArmyOpacity = Opacity;

                /* Transfer to Mainform */
                _hMainHandler.ArmyInformation.txtPosX.Text = Location.X.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.ArmyInformation.txtPosY.Text = Location.Y.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.ArmyInformation.txtWidth.Text = Width.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.ArmyInformation.txtHeight.Text = Height.ToString(CultureInfo.InvariantCulture);
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Apm))
            {
                /* Has to be calculated manually because each panels has it's own Neutral handling.. */
                var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;

                _hMainHandler.PSettings.ApmPositionX = Location.X;
                _hMainHandler.PSettings.ApmPositionY = Location.Y;
                _hMainHandler.PSettings.ApmWidth = Width;
                _hMainHandler.PSettings.ApmHeight = Height/iValidPlayerCount;
                _hMainHandler.PSettings.ApmOpacity = Opacity;

                /* Transfer to Mainform */
                _hMainHandler.ApmInformation.txtPosX.Text = Location.X.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.ApmInformation.txtPosY.Text = Location.Y.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.ApmInformation.txtWidth.Text = Width.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.ApmInformation.txtHeight.Text = Height.ToString(CultureInfo.InvariantCulture);
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Worker))
            {
                _hMainHandler.PSettings.WorkerPositionX = Location.X;
                _hMainHandler.PSettings.WorkerPositionY = Location.Y;
                _hMainHandler.PSettings.WorkerWidth = Width;
                _hMainHandler.PSettings.WorkerHeight = Height; 
                _hMainHandler.PSettings.WorkerOpacity = Opacity;

                /* Transfer to Mainform */
                _hMainHandler.WorkerInformation.txtPosX.Text = Location.X.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.WorkerInformation.txtPosY.Text = Location.Y.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.WorkerInformation.txtWidth.Text = Width.ToString(CultureInfo.InvariantCulture);
                _hMainHandler.WorkerInformation.txtHeight.Text = Height.ToString(CultureInfo.InvariantCulture);
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.PersonalApm))
            {
                _hMainHandler.PSettings.PersonalApmPositionX = Location.X;
                _hMainHandler.PSettings.PersonalApmPositionY = Location.Y;
                _hMainHandler.PSettings.PersonalApmWidth = Width;
                _hMainHandler.PSettings.PersonalApmHeight = Height; 
            }

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.PersonalClock))
            {
                _hMainHandler.PSettings.PersonalClockPositionX = Location.X;
                _hMainHandler.PSettings.PersonalClockPositionY = Location.Y;
                _hMainHandler.PSettings.PersonalClockWidth = Width;
                _hMainHandler.PSettings.PersonalClockHeight = Height; 
            }

            _bChangingPosition = false;
            _bMouseDown = false;
        }

        private void Renderer_2_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Width >= Screen.PrimaryScreen.Bounds.Width &&
                e.Delta.Equals(120))
                return;

            /* Maphack */
            if (_rRenderForm.Equals(PredefinedData.RenderForm.Maphack))
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

            /* UnitTab */
            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Units))
            {
                if (e.Delta.Equals(120))
                {
                    _hMainHandler.PSettings.UnitPictureSize += 1;
                    _hMainHandler.txtUnitPictureSize.Text = _pSettings.UnitPictureSize.ToString(CultureInfo.InvariantCulture);
                }

                else if (e.Delta.Equals(-120))
                {
                    _hMainHandler.PSettings.UnitPictureSize -= 1;
                    _hMainHandler.txtUnitPictureSize.Text = _pSettings.UnitPictureSize.ToString(CultureInfo.InvariantCulture);
                }
            }

            /* Production */
            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Production))
            {
                if (e.Delta.Equals(120))
                {
                    _hMainHandler.PSettings.ProdPictureSize += 1;
                    _hMainHandler.txtProductionTabPictureSize.Text = _pSettings.ProdPictureSize.ToString(CultureInfo.InvariantCulture);
                }

                else if (e.Delta.Equals(-120))
                {
                    _hMainHandler.PSettings.ProdPictureSize -= 1;
                    _hMainHandler.txtProductionTabPictureSize.Text = _pSettings.ProdPictureSize.ToString(CultureInfo.InvariantCulture);
                }
            }

            /* Worker- Panel */
            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Worker))
            {
                if (e.Delta.Equals(120))
                {
                    Width += 3;
                    Height += 1;
                }

                else if (e.Delta.Equals(-120))
                {
                    Width -= 3;
                    Height -= 1;
                }
            }

            /* Personal APM- Panel */
            else if (_rRenderForm.Equals(PredefinedData.RenderForm.PersonalApm))
            {
                if (e.Delta.Equals(120))
                {
                    Width += 3;
                    Height += 1;
                }

                else if (e.Delta.Equals(-120))
                {
                    Width -= 3;
                    Height -= 1;
                }
            }

            /* Personal Clock - Panel */
            else if (_rRenderForm.Equals(PredefinedData.RenderForm.PersonalClock))
            {
                if (e.Delta.Equals(120))
                {
                    Width += 3;
                    Height += 1;
                }

                else if (e.Delta.Equals(-120))
                {
                    Width -= 3;
                    Height -= 1;
                }
            }

            /* Normal Panels */
            else
            {
                if (e.Delta.Equals(120))
                {
                    Width += 4;
                    Height += 1;
                }

                else if (e.Delta.Equals(-120))
                {
                    Width -= 4;
                    Height -= 1;
                }
            }
        }

        #endregion

        /* Refresh Top-Most */
        private void RefreshForeground(IntPtr hWnd)
        {
            var z = 0;
            for (var h = hWnd; h != IntPtr.Zero; h = InteropCalls.GetWindow(h, InteropCalls.GetWindowCmd.GwHwndprev)) z++;


            if (z > 5)
            {
                TopMost = false;
                TopMost = true;
            }
        }

        private void Renderer_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsDestroyed = true;

            ChangeForecolorOfButton(Color.Red);
        }

        private void ChangeForecolorOfButton(Color cl)
        {
            if (_rRenderForm.Equals(PredefinedData.RenderForm.Resources))
                _hMainHandler.btnResources.ForeColor = cl;

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Income))
                _hMainHandler.btnIncome.ForeColor = cl;

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Apm))
                _hMainHandler.btnApm.ForeColor = cl;

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Army))
                _hMainHandler.btnArmy.ForeColor = cl;

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Maphack))
                _hMainHandler.btnMaphack.ForeColor = cl;

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Units))
                _hMainHandler.btnUnit.ForeColor = cl;

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Worker))
                _hMainHandler.btnWorker.ForeColor = cl;

            else if (_rRenderForm.Equals(PredefinedData.RenderForm.Production))
                _hMainHandler.btnProduction.ForeColor = cl;
        }


        public PredefinedData.CustomWindowStyles SetWindowStyle { get; set; }

        /* Called when position or size was changed */
        private void Renderer_ResizeEnd(object sender, EventArgs e)
        {
            /* If the Valid Player count is zero, change it.. */
            var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;

            var iRealPlayerCount = iValidPlayerCount == 0 ? 1 : iValidPlayerCount;

            if (_rRenderForm.Equals(PredefinedData.RenderForm.Apm))
            {
                _hMainHandler.PSettings.ApmHeight = (Height / iRealPlayerCount);
                _hMainHandler.PSettings.ApmWidth = Width;
                _hMainHandler.PSettings.ApmPositionX = Location.X;
                _hMainHandler.PSettings.ApmPositionY = Location.Y;
            }

            if (_rRenderForm.Equals(PredefinedData.RenderForm.Army))
            {
                _hMainHandler.PSettings.ArmyHeight = (Height / iRealPlayerCount);
                _hMainHandler.PSettings.ArmyWidth = Width;
                _hMainHandler.PSettings.ArmyPositionX = Location.X;
                _hMainHandler.PSettings.ArmyPositionY = Location.Y;
            }

            if (_rRenderForm.Equals(PredefinedData.RenderForm.Income))
            {
                _hMainHandler.PSettings.IncomeHeight = (Height / iRealPlayerCount);
                _hMainHandler.PSettings.IncomeWidth = Width;
                _hMainHandler.PSettings.IncomePositionX = Location.X;
                _hMainHandler.PSettings.IncomePositionY = Location.Y;
            }

            if (_rRenderForm.Equals(PredefinedData.RenderForm.Maphack))
            {
                _hMainHandler.PSettings.MaphackHeight = (Height);
                _hMainHandler.PSettings.MaphackWidth = Width;
                _hMainHandler.PSettings.MaphackPositionX = Location.X;
                _hMainHandler.PSettings.MaphackPositionY = Location.Y;
            }

            if (_rRenderForm.Equals(PredefinedData.RenderForm.PersonalApm))
            {
                _hMainHandler.PSettings.PersonalApmHeight = (Height);
                _hMainHandler.PSettings.PersonalApmWidth = Width;
                _hMainHandler.PSettings.PersonalApmPositionX = Location.X;
                _hMainHandler.PSettings.PersonalApmPositionY = Location.Y;
            }

            if (_rRenderForm.Equals(PredefinedData.RenderForm.PersonalClock))
            {
                _hMainHandler.PSettings.PersonalClockHeight = (Height);
                _hMainHandler.PSettings.PersonalClockWidth = Width;
                _hMainHandler.PSettings.PersonalClockPositionX = Location.X;
                _hMainHandler.PSettings.PersonalClockPositionY = Location.Y;
            }

            if (_rRenderForm.Equals(PredefinedData.RenderForm.Production))
            {
                /* Required to avoid the size of the border [FormBorderStyle] */
                var tmpOld = FormBorderStyle;
                FormBorderStyle = FormBorderStyle.None;

                /* Calculate amount of unitpictures - width */
                Int32 iAmount = _iProdPanelWidthWithoutName / _pSettings.ProdPictureSize;
                _hMainHandler.PSettings.ProdPictureSize = (Width - (_iProdPosAfterName + 1)) /
                                                          iAmount;
                _hMainHandler.txtProductionTabPictureSize.Text = _hMainHandler.PSettings.ProdPictureSize.ToString(CultureInfo.InvariantCulture);



                FormBorderStyle = tmpOld;

                /* Temporarily reset interval */
                var oldInterval = tmrRefreshGraphic.Interval;
                tmrRefreshGraphic.Interval = 1;

                new Thread(() =>
                {
                    Thread.Sleep(1);

                    MethodInvoker littleInvoker = () => _hMainHandler.btnChangeBorderstyle.PerformClick();

                    Invoke(littleInvoker);

                    Thread.Sleep(100);

                    littleInvoker = () => _hMainHandler.btnChangeBorderstyle.PerformClick();

                    Invoke(littleInvoker);
                }).Start();

                tmrRefreshGraphic.Interval = oldInterval;

                _hMainHandler.PSettings.ProdTabPositionX = Location.X;
                _hMainHandler.PSettings.ProdTabPositionY = Location.Y;
            }

            if (_rRenderForm.Equals(PredefinedData.RenderForm.Resources))
            {
                _hMainHandler.PSettings.ResourceHeight = (Height / iRealPlayerCount);
                _hMainHandler.PSettings.ResourceWidth = Width;
                _hMainHandler.PSettings.ResourcePositionX = Location.X;
                _hMainHandler.PSettings.ResourcePositionY = Location.Y;
            }

            if (_rRenderForm.Equals(PredefinedData.RenderForm.Units))
            {
                /* Required to avoid the size of the border [FormBorderStyle] */
                var tmpOld = FormBorderStyle;
                FormBorderStyle = FormBorderStyle.None;

                /* Calculate amount of unitpictures - width */
                Int32 iAmount = _iUnitPanelWidthWithoutName/_pSettings.UnitPictureSize;
                _hMainHandler.PSettings.UnitPictureSize = (Width - (_iUnitPosAfterName + 1))/
                                                          iAmount;
                _hMainHandler.txtUnitPictureSize.Text = _hMainHandler.PSettings.UnitPictureSize.ToString(CultureInfo.InvariantCulture);

               

                FormBorderStyle = tmpOld;

                /* Temporarily reset interval */
                var oldInterval = tmrRefreshGraphic.Interval;
                tmrRefreshGraphic.Interval = 1;

                new Thread(() =>
                    {
                        Thread.Sleep(1);

                        MethodInvoker littleInvoker = () => _hMainHandler.btnChangeBorderstyle.PerformClick();

                        Invoke(littleInvoker);

                        Thread.Sleep(100);

                        littleInvoker = () => _hMainHandler.btnChangeBorderstyle.PerformClick();

                        Invoke(littleInvoker);
                    }).Start();

                tmrRefreshGraphic.Interval = oldInterval;

                _hMainHandler.PSettings.UnitTabPositionX = Location.X;
                _hMainHandler.PSettings.UnitTabPositionY = Location.Y;
            }

            if (_rRenderForm.Equals(PredefinedData.RenderForm.Worker))
            {
                _hMainHandler.PSettings.WorkerHeight = (Height);
                _hMainHandler.PSettings.WorkerWidth = Width;
                _hMainHandler.PSettings.WorkerPositionX = Location.X;
                _hMainHandler.PSettings.WorkerPositionY = Location.Y;
            }
        }
    }
}
