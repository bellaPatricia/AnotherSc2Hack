using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PredefinedTypes
{
    [Serializable]
    [DebuggerDisplay("Name: {Name} ({Id}) - Owner: {Owner}")]
    public class Unit
    {
        public Unit()
        {
            ProdMineralCost = new List<int>();
            ProdProcess = new List<float>();
            ProdReactorAttached = new List<bool>();
            ProdSupply = new List<int>();
            ProdSupplyRaw = new List<int>();
            ProdUnitProductionId = new List<UnitId>();
            ProdVespineCost = new List<int>();
            ProdTimeLeft = new List<float>();
            ClassObjectCount += 1;
        }

        ~Unit()
        {
            ClassObjectCount -= 1;
        }

        public static int ClassObjectCount { get; private set; }
        public string Name { get; set; }
        public string RawName { get; set; }
        public int NameLength { get; set; }
        public UnitId Id { get; set; }
        public float Size { get; set; }
        public int MaximumHealth { get; set; }
        public int MaximumShield { get; set; }
        public int RandomFlag { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int DestinationPositionX { get; set; }
        public int DestinationPositionY { get; set; }
        public UInt64 TargetFilter { get; set; }
        public int DamageTaken { get; set; }
        public int ShieldDamageTaken { get; set; }
        public int Energy { get; set; }
        public int MaximumEnergy { get; set; }
        public int Owner { get; set; }
        public int State { get; set; }
        public int Movestate { get; set; }

        public int SpeedMultiplier { get; set; }
        public int BuildingState { get; set; }
        //public UnitModelStruct CustomStruct { get; set; }
        public int ModelPointer { get; set; }
        public int AliveSince { get; set; }

        public bool IsAlive { get; set; }
        public bool IsUnderConstruction { get; set; }
        public bool IsCloaked { get; set; }
        public bool IsStructure { get; set; }
        public bool IsGround { get; set; }
        public bool IsAir { get; set; }
        public bool IsLight { get; set; }
        public bool IsArmored { get; set; }
        public bool IsBiological { get; set; }
        public bool IsRobotic { get; set; }
        public bool IsMechanical { get; set; }
        public bool IsPsionic { get; set; }
        public bool IsMassive { get; set; }
        public bool IsVisible { get; set; }
        public bool IsBurried { get; set; }
        public bool IsHallucination { get; set; }
        public bool IsDetector { get; set; }

        public int ProdNumberOfQueuedUnits { get; set; }
        public List<UnitId> ProdUnitProductionId { get; set; }
        public List<float> ProdProcess { get; set; }
        public List<float> ProdTimeLeft { get; set; }
        public List<bool> ProdReactorAttached { get; set; }
        public List<int> ProdMineralCost { get; set; }
        public List<int> ProdVespineCost { get; set; }
        public List<int> ProdSupplyRaw { get; set; }
        public List<int> ProdSupply { get; set; }
        public bool ProdAttachingAddOn { get; set; }




    };

    public struct UnitModelStruct
    {
        public float Size;
        public int MaximumHealth;
        public int MaximumShield;
        public int MaximumEnergy;
        public UnitId Id;
        public int NameLenght;
        public string RawName;
        public string Name;
    };

    public struct UnitProduction
    {
        public int UnitsInProduction;
        public UnitId Id;
        public float ProductionStatus;
        public float ProductionTimeLeft;
        public bool ReactorAttached;
        public int MineralCost;
        public int VespineCost;
        public int SupplyRaw;
        public int Supply;
        public bool AttachingAddOn;
    }

    public struct UnitAssigner
    {
        public UnitId Id;
        public float Size;
        public int Pointer;
        public int MaximumHealth;
        public UnitModelStruct CustomStruct;
    };

    public class UnitCount
    {
        public UnitCount()
        {
            ConstructionState = new List<float>();
            AliveSince = new List<float>();
            ConstructionTimeLeft = new List<float>();
            Energy = new List<int>();
            SpeedMultiplier = new List<int>();
            MaximumEnergy = new List<int>();
        }

        public int UnitAmount { get; set; }
        public List<float> ConstructionState { get; set; }
        public List<float> ConstructionTimeLeft { get; set; }
        public List<int> Energy { get; set; }
        public List<int> SpeedMultiplier { get; set; }
        public int UnitUnderConstruction { get; set; }
        public UnitId Id { get; set; }
        public List<float> AliveSince { get; set; }
        public List<int> MaximumEnergy { get; set; }
    }

    //This work is based on Qazzies/ MrNukealizers research on the Targetfilter
    public enum TargetFilterFlag : ulong
    {
        Outer = 0x0000800000000000,
        Unstoppable = 0x0000400000000000,
        Summoned = 0x0000200000000000,
        Stunned = 0x0000100000000000,
        Radar = 0x0000080000000000,
        Detector = 0x0000040000000000,
        Passive = 0x0000020000000000,
        Benign = 0x0000010000000000,
        HasShields = 0x0000008000000000,
        HasEnergy = 0x0000004000000000,
        Invulnerable = 0x0000002000000000,
        Hallucination = 0x0000001000000000,
        Hidden = 0x0000000800000000,
        Revivable = 0x0000000400000000,
        Dead = 0x0000000200000000,
        UnderConstruction = 0x0000000100000000,
        Stasis = 0x0000000080000000,
        Visible = 0x0000000040000000,
        Cloaked = 0x0000000020000000,
        Buried = 0x0000000010000000,
        PreventReveal = 0x0000000008000000,
        PreventDefeat = 0x0000000004000000,
        CanHaveShields = 0x0000000002000000,
        CanHaveEnergy = 0x0000000001000000,
        Uncommandable = 0x0000000000800000,
        Item = 0x0000000000400000,
        Destructable = 0x0000000000200000,
        Missile = 0x0000000000100000,
        ResourcesHarvestable = 0x0000000000080000,
        ResourcesRaw = 0x0000000000040000,
        Worker = 0x0000000000020000,
        Heroic = 0x0000000000010000,
        Hover = 0x0000000000008000,
        Structure = 0x0000000000004000,
        Massive = 0x0000000000002000,
        Psionic = 0x0000000000001000,
        Mechanical = 0x0000000000000800,
        Robotic = 0x0000000000000400,
        Biological = 0x0000000000000200,
        Armored = 0x0000000000000100,
        Light = 0x0000000000000080,
        Ground = 0x0000000000000040,
        Air = 0x0000000000000020,
        Enemy = 0x0000000000000010,
        Neutral = 0x0000000000000008,
        Ally = 0x0000000000000004,
        Player = 0x0000000000000002,
        Self = 0x0000000000000001
    };

    public enum AbilityType
    {
        ArchonWarp = 0xfd,
        ArmoryResearch = 0x9b,
        ArmSiloWithNuke = 150,
        AssaultMode = 0x7f,
        Attack = 0x2a,
        AttackRedirect = 240,
        AttackWarpPrism = 0x6b,
        BanelingNestResearch = 210,
        BansheeCloak = 0x7b,
        BarracksAddOns = 0x85,
        BarracksLand = 0x8e,
        BarracksLiftOff = 0x86,
        BarracksReactorMorph = 0xed,
        BarracksTechLabMorph = 0xe9,
        BarracksTechLabResearch = 0x97,
        BarracksTrain = 0x91,
        Beacon = 0x27,
        Blink = 0xcc,
        BroodLordHangar = 0xff,
        BroodLordQueue2 = 0xa4,
        BuildAutoTurret = 0xfc,
        BuildInProgress = 0x71,
        BuildinProgressNydusCanal = 0x4e,
        BuildNydusCanal = 0xfe,
        BunkerTransport = 0x81,
        BurrowBanelingDown = 0xb5,
        BurrowBanelingUp = 0xb6,
        BurrowCreepTumorDown = 230,
        BurrowDroneDown = 0xb7,
        BurrowDroneUp = 0xb8,
        BurrowedStop = 0xf3,
        BurrowHydraliskDown = 0xb9,
        BurrowHydraliskUp = 0xba,
        BurrowInfestorDown = 0xcd,
        BurrowInfestorTerranDown = 0xbf,
        BurrowInfestorTerranUp = 0xc0,
        BurrowInfestorUp = 0xce,
        BurrowQueenDown = 0xc9,
        BurrowQueenUp = 0xca,
        BurrowRoachDown = 0xbb,
        BurrowRoachUp = 0xbc,
        BurrowUltraliskDown = 0xd3,
        BurrowUltraliskUp = 0xd4,
        BurrowZerglingDown = 0xbd,
        BurrowZerglingUp = 190,
        CAbil = 0,
        CAbilArmMagazine = 5,
        CAbilAttack = 6,
        CAbilAugment = 7,
        CAbilBattery = 8,
        CAbilBeacon = 9,
        CAbilBehavior = 10,
        CAbilBuild = 11,
        CAbilBuildable = 12,
        CAbilEffect = 1,
        CAbilEffectInstant = 13,
        CAbilEffectTarget = 14,
        CAbilHarvest = 15,
        CAbilInteract = 0x10,
        CAbilInventory = 0x11,
        CAbilLearn = 0x12,
        CAbilMerge = 0x13,
        CAbilMergeable = 20,
        CAbilMorph = 0x15,
        CAbilMorphPlacement = 0x16,
        CAbilMove = 0x17,
        CAbilPawn = 0x18,
        CAbilProgress = 3,
        CAbilQueue = 0x19,
        CAbilQueueable = 2,
        CAbilRally = 0x1a,
        CAbilRedirect = 4,
        CAbilResearch = 0x1b,
        CAbilRevive = 0x1c,
        CAbilSpecialize = 0x1d,
        CAbilStop = 30,
        CAbilTrain = 0x1f,
        CAbilTransport = 0x20,
        CAbilWarpable = 0x21,
        CAbilWarpTrain = 0x22,
        CalldownMule = 0x4c,
        CarrierHangar = 0xa5,
        Charge = 0x100,
        CommandCenterLand = 0x84,
        CommandCenterLiftOff = 0x83,
        CommandCenterTrain = 0x8d,
        CommandCenterTransport = 130,
        Contaminate = 260,
        Corruption = 50,
        CreepTumorBuild = 0xfb,
        CyberneticsCoreResearch = 0xde,
        DisguiseAsMarineWithoutShield = 0x54,
        DisguiseAsMarineWithShield = 0x53,
        DisguiseAsZealot = 0x52,
        DisguiseAsZerglingWithoutWings = 0x56,
        DisguiseAsZerglingWithWings = 0x55,
        DisguiseChangeling = 0x30,
        DroneHarvest = 170,
        Emp = 0xe3,
        EngineeringBayResearch = 0x94,
        Evolutionchamberresearch = 0xab,
        Explode = 0x36,
        FactoryAddOns = 0x87,
        FactoryLand = 0x8b,
        FactoryLiftOff = 0x88,
        FactoryReactorMorph = 0xee,
        FactoryTechLabMorph = 0xea,
        FactoryTechLabResearch = 0x98,
        FactoryTrain = 0x92,
        Feedback = 0x3d,
        FighterMode = 0x80,
        FleetBeaconResearch = 0x37,
        ForceField = 0xda,
        ForgeResearch = 0xa6,
        Frenzy = 0x103,
        FungalGrowth = 0x38,
        FusionCoreResearch = 0xdd,
        GatewayTrain = 0x9e,
        GenerateCreep = 0xf5,
        GhostAcademyResearch = 0x9a,
        GhostCloak = 0x76,
        GhostHoldFire = 0x33,
        GhostWeaponsFree = 0x34,
        GravitonBeam = 0x4d,
        GuardianShield = 0x39,
        HallucinationArchon = 0x40,
        HallucinationColossus = 0x41,
        HallucinationHighTemplar = 0x42,
        HallucinationImmortal = 0x43,
        HallucinationPhoenix = 0x44,
        HallucinationProbe = 0x45,
        HallucinationStalker = 70,
        HallucinationVoidRay = 0x47,
        HallucinationWarpPrism = 0x48,
        HallucinationZealot = 0x49,
        HangarQueue5 = 0xa3,
        HerdInteract = 0x102,
        HoldFire = 0x25,
        HydraliskDenResearch = 0xb1,
        InfestationPitResearch = 0xd1,
        InfestedTerrans = 0x5f,
        InfestedTerransLayEgg = 0x106,
        LairResearch = 0xaf,
        LarvaTrain = 0xb3,
        Leech = 80,
        MassRecall = 0x3e,
        MedivacHeal = 120,
        MedivacTransport = 0x7c,
        MercCompoundResearch = 0x95,
        Mergeable = 0xc6,
        MorphBackToGateway = 0xd7,
        MorphToBroodLord = 180,
        MorphToInfestedTerran = 0x35,
        MorphToOverseer = 0xcf,
        MorphZerglingToBaneling = 0x3b,
        Move = 0x26,
        MuleGather = 0x4a,
        MuleRepair = 0x3a,
        NeuralParasite = 0x60,
        NexusTrain = 0xa1,
        NexusTrainMothership = 60,
        NydusCanalTransport = 0xcb,
        OrbitalCommandLand = 0xd9,
        OrbitalLiftOff = 0xd8,
        OverlordTransport = 0xc5,
        PhaseShift = 0x57,
        PhasingMode = 0xdb,
        PlacePointDefenseDrone = 0x3f,
        ProbeHarvest = 0x6a,
        ProgressRally = 0x59,
        ProtossBuild = 0x9c,
        PsiStorm = 0xa2,
        Que1 = 0x6c,
        Que5 = 0x6d,
        Que5Addon = 0x70,
        Que5LongBlend = 110,
        Que5Passive = 0x6f,
        QueenBuild = 0xf6,
        Rally = 0x58,
        RallyCommand = 90,
        RallyHatchery = 0x5c,
        RallyNexus = 0x5b,
        RavenBuild = 0x74,
        ReactorMorph = 0xec,
        RedstoneLavaCritterBurrow = 0xc1,
        RedstoneLavaCritterInjuredBurrow = 0xc2,
        RedstoneLavaCritterInjuredUnburrow = 0xc4,
        RedstoneLavaCritterUnburrow = 0xc3,
        Refund = 0x2e,
        Repair = 0x72,
        RoachWarrenResearch = 0x5d,
        RoboticsBayResearch = 0xa7,
        RoboticsFacilityTrain = 160,
        Salvage = 0x2f,
        SalvageBunker = 0xe2,
        SalvageBunkerRefund = 0xe1,
        SalvageTwo = 0x31,
        SapStructure = 0x5e,
        ScannerSweep = 0x7d,
        ScvHarvest = 0x69,
        SeekerMissile = 0x4b,
        Shatter = 0x105,
        SiegeMode = 0x79,
        Siphon = 0x4f,
        Snipe = 0x77,
        SpawnChangeling = 0x51,
        SpawningPoolResearch = 0xb0,
        SpawnLarva = 0x61,
        SpineCrawlerRoot = 0xf9,
        SpineCrawlerUproot = 0xf7,
        SpireResearch = 0xb2,
        SporeCrawlerRoot = 250,
        SporeCrawlerUproot = 0xf8,
        StargateTrain = 0x9f,
        StarportAddOns = 0x89,
        StarportLand = 140,
        StarportLiftOff = 0x8a,
        StarportReactorMorph = 0xef,
        StarportTechLabMorph = 0xeb,
        StarportTechLabResearch = 0x99,
        StarportTrain = 0x93,
        Stimpack = 0x75,
        StimpackMarauder = 0x62,
        StimpackMarauderRedirect = 0xf2,
        StimpackRedirect = 0xf1,
        Stop = 0x24,
        StopRedirect = 0xf4,
        SupplyDepotLower = 0x8f,
        SupplyDepotRaise = 0x90,
        SupplyDrop = 0x63,
        TacNukeStrike = 0xe0,
        Taunt = 0x23,
        TechLabMorph = 0xe8,
        TemplarArchivesResearch = 0xa8,
        TemporalRift = 0x65,
        TerranAddOns = 0x2b,
        TerranBuild = 0x73,
        TerranBuildingLand = 0x2d,
        TerranBuildingLiftOff = 0x2c,
        ThorStrikeCannons = 100,
        TimeWarp = 0x66,
        TowerCapture = 0x101,
        TrainQueen = 0xe5,
        Transfusion = 0xe7,
        TransportMode = 220,
        TwilightCouncilResearch = 0xdf,
        UltraliskCavernResearch = 0x67,
        Unsiege = 0x7a,
        UpgradeToGreaterSpire = 0xae,
        UpgradeToHive = 0xad,
        UpgradeToLair = 0xac,
        UpgradeToOrbital = 0xd5,
        UpgradeToPlanetaryFortress = 0xd0,
        UpgradeToWarpGate = 0xd6,
        VolatileBurstBuilding = 0x11c,
        Vortex = 0xe4,
        Warpable = 0xc7,
        WarpGateTrain = 200,
        WarpPrismTransport = 0x9d,
        WormholeTransit = 0x68,
        Yamato = 0x7e,
        ZergBuild = 0xa9
    };

    public enum UnitId
    {
        PuColossus = 38, //Valid
        TbTechlab = 39, //Valid
        TbReactor = 40, //Valid
        ZuInfestedTerran = 42, //Valid
        ZuBanelingCocoon = 43, //Valid
        ZuBaneling = 44, //Valid
        PuMothership = 45, //Valid
        TuPdd = 46, //
        ZuChangeling = 47, //Valid
        ZuChangelingZealot = 48, //Valid
        ZuChangelingMarineShield = 49, //Valid
        ZuChangelingMarine = 50, //Valid
        ZuChangelingSpeedling = 51, //Valid
        ZuChangelingZergling = 52, //Valid
        TbCcGround = 54, //Valid
        TbSupplyGround = 55, //Valid
        TbRefinery = 56, //Valid
        TbBarracksGround = 57, //Valid
        TbEbay = 58, //Valid
        TbTurret = 59, //Valid
        TbBunker = 60, //Valid
        TbSensortower = 61, //Valid
        TbGhostacademy = 62, //Valid
        TbFactoryGround = 63, //Valid
        TbStarportGround = 64, //Valid
        TbArmory = 66, //Valid
        TbFusioncore = 67, //Valid
        TbAutoTurret = 68, //Valid
        TuSiegetankSieged = 69, //Valid
        TuSiegetank = 70, //Valid
        TuVikingGround = 71, //Valid
        TuVikingAir = 72, //Valid
        TbCcAir = 73, //Valid
        TbTechlabRax = 74, //Not Sure
        TbReactorRax = 75, //Not sure
        TbTechlabFactory = 76, //Not sure
        TbReactorFactory = 77, //Not sure
        TbTechlabStarport = 78, //Not sure
        TbReactorStarport = 79, //Not sure
        TbFactoryAir = 80, //Valid
        TbStarportAir = 81, //Valid
        TuScv = 82, //Valid
        TbRaxAir = 83, //Valid
        TbSupplyHidden = 84, //Valid
        TuMarine = 85, //Valid
        TuReaper = 86, //Valid
        TuGhost = 87, //Valid
        TuMarauder = 88, //Valid
        TuThor = 89, //Valid
        TuHellion = 90, //Valid
        TuMedivac = 91, //Valid
        TuBanshee = 92, //Valid
        TuRaven = 93, //Valid
        TuBattlecruiser = 94, //Valid
        TuNuke = 95, //Valid
        PbNexus = 96, //Valid
        PbPylon = 97, //Valid
        PbAssimilator = 98, //Valid
        PbGateway = 99, //Valid
        PbForge = 100, //Valid
        PbFleetbeacon = 101, //Valid
        PbTwilightcouncil = 102, //Valid
        PbCannon = 103, //Valid
        PbStargate = 104, //Valid
        PbTemplararchives = 105, //Valid
        PbDarkshrine = 106, //Valid
        PbRoboticssupportbay = 107, //Valid
        PbRoboticsbay = 108, //Valid
        PbCybercore = 109, //Valid
        PuZealot = 110, //Valid 
        PuStalker = 111, //Valid
        PuHightemplar = 112, //Valid
        PuDarktemplar = 113, //Valid
        PuSentry = 114, //Valid
        PuPhoenix = 115, //Valid
        PuCarrier = 116, //Valid
        PuVoidray = 117, //Valid
        PuWarpprismTransport = 118, //Valid
        PuObserver = 119, //Valid
        PuImmortal = 120, //Valid
        PuProbe = 121, //Valid
        PuInterceptor = 122, //Valid
        ZbHatchery = 123, //Valid
        ZbCreepTumorBuilding = 124, //Valid
        ZbExtractor = 125, //Valid
        ZbSpawningPool = 126, //Valid
        ZbEvolutionChamber = 127, //Valid
        ZbHydraDen = 128, //Valid
        ZbSpire = 129, //Valid
        ZbUltraCavern = 130, //Valid
        ZbInfestationPit = 131, //Valid
        ZbNydusNetwork = 132, //Valid
        ZbBanelingNest = 133, //Valid
        ZbRoachWarren = 134, //Valid
        ZbSpineCrawler = 135, //Valid
        ZbSporeCrawler = 136, //Valid
        ZbLiar = 137, //Valid
        ZbHive = 138, //Valid
        ZbGreaterspire = 139, //Valid
        ZuEgg = 140, //Valid
        ZuDrone = 141, //Valid
        ZuZergling = 142, //Valid
        ZuOverlord = 143, //Valid
        ZuHydralisk = 144, //Valid
        ZuMutalisk = 145, //Valid
        ZuUltra = 146, //Valid
        ZuRoach = 147, //Valid
        ZuInfestor = 148, //Valid
        ZuCorruptor = 149, //Valid
        ZuBroodlordCocoon = 150, //Valid
        ZuBroodlord = 151, //Valid
        ZuBanelingBurrow = 152, //Valid
        ZuDroneBurrow = 153, //Valid
        ZuHydraBurrow = 154, //Valid
        ZuRoachBurrow = 155, //Valid
        ZuZerglingBurrow = 156, //Valid
        ZuInfestedTerran2 = 157, //Valid
        ZuQueenBurrow = 162, //Valid
        ZuQueen = 163, //Valid
        ZuInfestorBurrow = 164, //Valid
        ZuOverseerCocoon = 165, //Valid
        ZuOverseer = 166, //Valid
        TbPlanetary = 167, //Valid
        ZuUltraBurrow = 168, //Valid
        TbOrbitalGround = 169, //Valid
        PbWarpgate = 170, //Valid
        TbOrbitalAir = 171, //Valid
        PuForceField = 172, //Valid
        PuWarpprismPhase = 173, //Valid
        ZbCreeptumorBurrowed = 174, //Valid
        ZbCreeptumor = 175, //Valid
        ZbSpineCrawlerUnrooted = 176, //Valid
        ZbSporeCrawlerUnrooted = 177, //Valid
        PuArchon = 178, //Valid
        ZbNydusWorm = 179, //Valid
        ZuBroodlordEscort = 180, //Valid
        NbMineralRichPatch = 181, //Valid
        NbXelNagaTower = 183, //Valid
        ZuInfestedSwarmEgg = 187, //Valid
        ZuLarva = 188, //Valid
        TuMule = 196, //Valid
        ZuBroodling = 219, //Valid
        NbMineralPatch = 261, //Valid
        NbGas = 262, //Valid
        NbGasSpace = 263, //Valid
        NbGasRich = 264, //Valid
        TuHellbat = 410, //Valid
        PuMothershipCore = 414, //Valid
        ZuLocust = 418, //Valid
        ZuSwarmHostBurrow = 422, //Valid
        ZuSwarmHost = 423, //Valid
        PuOracle = 424, //Valid
        PuTempest = 425, //Valid
        TuWarhound = 426, //Valid
        TuWidowMine = 427, //Valid
        ZuViper = 428, //Valid
        TuWidowMineBurrow = 429, //Valid
        ZbCreepTumorMissle = 483, //Valid

        K5Kerrigan = 1567,

        /* The following are not existing, but have to be put here to be accessable by the whole stuff */
        /* Terran */
        TupStim,
        TupConcussiveShells,
        TupCombatShields,
        TupInfantryWeapon1,
        TupInfantryWeapon2,
        TupInfantryWeapon3,
        TupInfantryArmor1,
        TupInfantryArmor2,
        TupInfantryArmor3,
        TupHighSecAutoTracking,
        TupNeosteelFrame,
        TupStructureArmor,
        TupPersonalCloak,
        TupMoebiusReactor,
        TupWeaponRefit,
        TupBehemothReactor,
        TupVehicleWeapon1,
        TupVehicleWeapon2,
        TupVehicleWeapon3,
        TupShipWeapon1,
        TupShipWeapon2,
        TupShipWeapon3,
        TupVehicleShipPlanting1,
        TupVehicleShipPlanting2,
        TupVehicleShipPlanting3,
        TupBlueFlame,
        TupDrillingClaws,
        TupTransformatorServos,
        TupCloakingField,
        TupCaduceusReactor,
        TupDurableMeterials,
        TupCorvidReactor,
        TupUpgradeToOrbital,
        TupUpgradeToPlanetary,

        /* Protoss */
        PupAirW1,
        PupAirW2,
        PupAirW3,
        PupAirA1,
        PupAirA2,
        PupAirA3,
        PupGroundW1,
        PupGroundW2,
        PupGroundW3,
        PupGroundA1,
        PupGroundA2,
        PupGroundA3,
        PupS1,
        PupS2,
        PupS3,
        PupBlink,
        PupCharge,
        PupGraviticBooster,
        PupGraviticDrive,
        PupStorm,
        PupExtendedThermalLance,
        PupWarpGate,
        PupAnionPulseCrystals,
        PupGravitonCatapult,
        PupUpgradeToMothership,
        PupUpgradeToArchon,

        /* Zerg */
        ZupAirA1,
        ZupAirA2,
        ZupAirA3,
        ZupAirW1,
        ZupAirW2,
        ZupAirW3,
        ZupGroundW1,
        ZupGroundW2,
        ZupGroundW3,
        ZupGroundA1,
        ZupGroundA2,
        ZupGroundA3,
        ZupGroundM1,
        ZupGroundM2,
        ZupGroundM3,
        ZupAdrenalGlands,
        ZupBurrow,
        ZupCentrifugalHooks,
        ZupChitinousPlating,
        ZupEnduringLocusts,
        ZupGlialReconstruction,
        ZupGroovedSpines,
        ZupMetabolicBoost,
        ZupMuscularAugments,
        ZupNeutralParasite,
        ZupPathoglenGlands,
        ZupPneumatizedCarapace,
        ZupTunnelingClaws,
        ZupVentralSacs,
        ZupUpgradeToLair,
        ZupUpgradeToHive,
        ZupUpgradeToGreaterSpire,
        ZupUpgradeToBroodlord,
        ZupUpgradeToOverseer,
        ZupFlyingLocust,

        None,

    };
}
