/* GameInfo.cs
 * Written: 31 August 2013
 * by bellaPatricia
 * 
 * This file contains methods to gather important data
 * such as the entire player- and unitstruct.
 * However, not all data are used.
 * 
 * There's a thread which checks automatically if SC2 is available or has been closed.
 * If Sc2 closes and restarts, the thread will notice that restart and unlock the new process.
 * 
 * If there are more than one instances of Sc2 running you are lost.
 * Blizzard didn't want to have more instances to be ran at once and no user ever told me that they'd like to.
 * 
 * 
 * The Method "DoMassiveScan" reads bytebuffers. Those buffers differs on the amount of units/ players and so on..
 * 
 * 
 * 
 * 09-Feb-2014 (bellaPatricia)
 * ===========================
 * Changed The colors, using the actual ARGB- values instead of Colordefinitions by System.Drawing's Color- Class.
 * 
 * */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Threading;
using PredefinedTypes;
using Utilities.Events;
using _ = Utilities.InfoManager.InfoManager;

namespace AnotherSc2Hack.Classes.BackEnds
{
    public delegate void NewMatchHandler(object sender, EventArgs e);


    

    public class GameInfo
    {
        private Thread _thrWorker;
        private Int32 _maxPlayerAmount = 16;
        private Stopwatch _swmainwatch = new Stopwatch();
        private readonly List<UnitAssigner> _lUnitAssigner = new List<UnitAssigner>();
        private bool _bSkip;
        private Random _rnd = new Random();
        public readonly Memory Memory = new Memory();
        public event NewMatchHandler NewMatch;
        private readonly List<PlayerRace> _lRace = new List<PlayerRace>();


        public event NumberChangeHandler IterationPerSecondChanged;
        public event ProcessFoundHandler ProcessFound;

        private int _lTimesRefreshed;

        private int _iterationsPerSecond = 0;

        public int IterationsPerSeconds
        {
            get { return _iterationsPerSecond;}
            set
            {
                if (_iterationsPerSecond == value)
                    return;

                _iterationsPerSecond = value;
                var nArgs = new NumberArgs(value);

                OnNumberChanged(this, nArgs);
            }
        }

        public Offsets MyOffsets = new Offsets();

        private void OnNumberChanged(object sender, NumberArgs e)
        {
            if (IterationPerSecondChanged != null)
                IterationPerSecondChanged(sender, e);
        }

        private void OnProcessFound(object sender, ProcessFoundArgs e)
        {
            if (ProcessFound != null)
                ProcessFound(sender, e);
        }

        /* Is able to shut the Worker- thread down */
        public void HandleThread(bool threadState)
        {
            if (threadState)
            {
                CThreadState = true;

                _thrWorker = new Thread(RefreshData);
                _thrWorker.Priority = ThreadPriority.Highest;
                _thrWorker.Name = "Worker \"RefreshData()\"";
                _thrWorker.Start();

                _.Info($"Launched Worker {_thrWorker.Name}", _.InfoImportance.VeryImportant);
            }

            else
            {
                if (_thrWorker != null)
                {
                    if (_thrWorker.IsAlive)
                    {
                        CThreadState = false;
                        _.Info($"Worker {_thrWorker.Name} Will Stop Any Moment", _.InfoImportance.VeryImportant);
                    }

                }
            }
        }

       

        private void AssignEvents()
        {
            NewMatch += GameInfo_NewMatch;
            ProcessFound += GameInfo_ProcessFound;
            MyOffsets.OffsetsNotProperlySet += MyOffsets_OffsetsNotProperlySet;
        }

        void GameInfo_ProcessFound(object sender, ProcessFoundArgs e)
        {
            _.Info("Process Found - Assigning Addresses", _.InfoImportance.Important);

            MyOffsets.AssignAddresses(e.Process);
        }


        //TODO: Finish this
        void MyOffsets_OffsetsNotProperlySet(object sender, EventArgs e)
        {
            _.Info("Offsets Not Properly Set, Using Signature Scan!", _.InfoImportance.VeryImportant);

            if (Memory.Process == null)
            {
                Process proc;
                if (Processing.GetProcess(Constants.StrStarcraft2ProcessName, out proc))
                {
                    Memory.Process = proc;
                    Memory.DesiredAccess = Memory.VmRead;
                    //Memory.UnlockProcess(Memory.VmRead);

                    CStarcraft2 = Memory.Process;

                    CWindowStyle = GetGWindowStyle();
                }
            }

            #region Player

            var playerbase = Memory.FindPattern(new byte[] {15, 0xb6, 0xc1, 0x69, 0xc0, 0, 0, 0, 0, 5, 0, 0, 0, 0},
                "xxxxx??xxx????",
                0,
                (int)Memory.Process.MainModule.BaseAddress,
                Memory.Process.MainModule.ModuleMemorySize);

            MyOffsets.PlayerStructSize = Memory.ReadInt32(playerbase + 5);
            MyOffsets.PlayerStruct = Memory.ReadInt32(playerbase + 10);

            #endregion

            #region Localplayer

            var localplayer = Memory.FindPattern(new byte[] { 0xA0, 0, 0, 0, 0, 0xC3, 0xA0, 0, 0, 0, 0, 0xC3 },
                 "x????xx????x",
                 0,
                (int)Memory.Process.MainModule.BaseAddress,
                Memory.Process.MainModule.ModuleMemorySize);

            MyOffsets.Localplayer4 = Memory.ReadInt32(localplayer + 7);

            #endregion

            #region Unit

            var unitbase = Memory.FindPattern(new byte[] { 0xc1, 0xe0, 6, 5, 0, 0, 0, 0, 0x33 },
                 "xxxx????x",
                 0,
                (int)Memory.Process.MainModule.BaseAddress,
                Memory.Process.MainModule.ModuleMemorySize);

            if (unitbase == (uint)Memory.Process.MainModule.BaseAddress)
            {
                unitbase = Memory.FindPattern(new byte[] { 0xc1, 0xe0, 7, 5, 0, 0, 0, 0, 0x33 },
                 "xxxx????x",
                 0,
                (int)Memory.Process.MainModule.BaseAddress,
                Memory.Process.MainModule.ModuleMemorySize);

            }

            MyOffsets.UnitStruct = Memory.ReadInt32(unitbase + 4);

            #endregion

            #region Selection

            var selection = Memory.FindPattern(new byte[] { 0x0F, 0xB6, 0xC1, 0x69, 0xC0, 0x60, 0x1B, 0x00, 0x00, 0x05, 0, 0, 0, 0, 0xC3 },
                 "xxxxxxxxxx????x",
                 0,
                (int)Memory.Process.MainModule.BaseAddress,
                Memory.Process.MainModule.ModuleMemorySize);

            MyOffsets.UiRawSelectionStruct = Memory.ReadInt32(selection + 10);
            MyOffsets.UiSelectionStruct = Memory.ReadInt32(selection + 10);

            

            #endregion

            #region Timer

            var timer = Memory.FindPattern(new byte[] { 
					0xC1, 0xEA, 0x0A, 0xB9, 0x00, 0x01, 0x00, 0x00, 0x01, 0x0D, 0, 0, 0, 0, 0xF6, 0xD2, 0xA3, 0, 0, 0, 0, 0xF6, 0xC2, 
					0x01, 0x74, 0x06, 0x01, 0x0D, 0, 0, 0, 0, 0x83, 0x3D, 0, 0, 0, 0, 0x00, 0x56, 0xBE, 0xFF, 0xFF, 0xFF, 0x7F
				 },
                 "xxxxxxxxxx????xxx????xxxxxxx????xx????xxxxxxx",
                 0,
                (int)Memory.Process.MainModule.BaseAddress,
                Memory.Process.MainModule.ModuleMemorySize);

            MyOffsets.TimerData = Memory.ReadInt32(timer + 28);

            #endregion
        }

        void GameInfo_NewMatch(object sender, EventArgs e)
        {
            _.Info("Found A New Match!", _.InfoImportance.Important);

            #region Gather Race-data

            _lRace.Clear();

            // Race Buffer 
            var racelenght = _maxPlayerAmount * MyOffsets.RaceSize;
            var raceChunk = Memory.ReadMemory(MyOffsets.RaceStruct, racelenght);

            // Create little race- array and catch all races 
            for (var i = 0; i < _maxPlayerAmount; i++)
                _lRace.Add((PlayerRace)raceChunk[i * MyOffsets.RaceSize]);

            #endregion
        }


        #region Constructors

       
        public GameInfo()
        {
            _.Info("Initialize GameInfo", _.InfoImportance.VeryImportant);

            AssignEvents();
            
            CSleepTime = 33;

            HandleThread(true);
        }

        public GameInfo(Boolean useThreadedGameInfo)
        {
            _.Info("Initialize GameInfo", _.InfoImportance.VeryImportant);

            AssignEvents();

            if (useThreadedGameInfo)
            {
                CSleepTime = 33;
                HandleThread(true);
            }

            else
            {

                #region Exceptions

                /* Check if the Handle is unlocked */
                if (Memory.Handle == IntPtr.Zero)
                {
                    Process proc;
                    if (Processing.GetProcess(Constants.StrStarcraft2ProcessName, out proc))
                    {
                        Memory.Process = proc;
                        Memory.DesiredAccess = Memory.VmRead;
                        //Memory.UnlockProcess(Memory.VmRead);

                        CStarcraft2 = Memory.Process;

                        CWindowStyle = GetGWindowStyle();
                    }

                    else
                        return;
                }

                #endregion


                Unit = new List<Unit>();
                Player = new List<Player>();
                Selection = new List<Selection>();
                Group = new List<Groups>();
                /*if (Processing.GetProcess(Constants.StrStarcraft2ProcessName, out Memory.Process)) 
                {}*/

                Memory.DesiredAccess = Memory.VmRead;
                //Memory.UnlockProcess(Memory.VmRead);

                CStarcraft2 = Memory.Process;

                CWindowStyle = GetGWindowStyle();



                DoMassiveScan();
            }
        }

        #endregion

        /* Main- worker that refreshes data */
        private DateTime _dtSecond = DateTime.Now;
        private bool _bIngame;
        private void RefreshData()
        {
            while (CThreadState)
            {
                _.Info("RefreshData Still Running", _.InfoImportance.NotImportant);

                #region Exceptions

                /* Check if the Handle is unlocked */
                if (CStarcraft2 == null || CStarcraft2.HasExited)
                {
                    _.Info("Stacraft Not Found, Slow Mode", _.InfoImportance.NotImportant);

                    Process proc;
                    if (Processing.GetProcess(Constants.StrStarcraft2ProcessName, out proc))
                    {
                        

                        Memory.Process = proc;
                        Memory.DesiredAccess = Memory.VmRead;
                        //Memory.UnlockProcess(Memory.VmRead);

                        CStarcraft2 = Memory.Process;
                        OnProcessFound(this, new ProcessFoundArgs(Memory.Process));

                        CWindowStyle = GetGWindowStyle();
                    }

                    else
                    {
                        CStarcraft2 = null;
                        Thread.Sleep(100);
                        continue;
                    }
                }

                /* Check if ingame */
                if (!GetGIngame())
                {
                    _.Info("Currently Not In A Game", _.InfoImportance.NotImportant);

                    /* if (!Processing.GetProcess(Constants.StrStarcraft2ProcessName))
                     {
                         _memory.Process = null;
                         _memory.Handle = IntPtr.Zero;
                     }*/

                    if (Gameinfo == null)
                        Gameinfo = new Gameinformation();

                    Gameinfo.IsIngame = false;

                    //We slow down...
                    Thread.Sleep(100);
                    _maxPlayerAmount = 16;  /* Reset playersize to maximum */
                    continue;
                }

                #endregion

                //DoMassiveTestScan();
                //_swmainwatch.Reset();
                //_swmainwatch.Start();

                /* This is for test purposes only!
                 * Shows the Iterations within the given time */
                if ((DateTime.Now - _dtSecond).Seconds >= 1)
                {
                    // Debug.WriteLine("The RefreshData- loop was refreshed " + _lTimesRefreshed + " times in a second!");
                    IterationsPerSeconds = _lTimesRefreshed;
                    _lTimesRefreshed = 0;
                    _dtSecond = DateTime.Now;
                }
                _lTimesRefreshed++;

                if (Gameinfo != null)
                    _bIngame = Gameinfo.IsIngame;

                DoMassiveScan();


                if (Gameinfo != null && (!_bIngame &&
                    Gameinfo.IsIngame))
                {
                    OnNewMatch(this, new EventArgs());
                }

                //_swmainwatch.Stop();
                //Console.WriteLine("Time to execute \"DoMassiveScan()\":" + (1000000 * _swmainwatch.ElapsedTicks / Stopwatch.Frequency).ToString("# ##0") + " µs");

                

                Thread.Sleep(CSleepTime);
            }

            Debug.WriteLine("Worker \"RefreshData()\" finished!");
        }

        public void OnNewMatch(object sender, EventArgs e)
        {
            if (NewMatch != null)
                NewMatch(sender, e);
        }

        private DateTime _dtProduction = DateTime.Now;

        /// <summary>
        /// Reads the memory (complete chunks for each area) and maps
        /// them correctly and puts themm into the global scope.
        /// </summary>
        public void DoMassiveScan()
        {
            
            GatherAndMapPlayerData();

            //_swmainwatch.Reset();
            //_swmainwatch.Start();

            GatherAndMapUnitData();

            //_swmainwatch.Stop();
            //Console.WriteLine(1000000 * _swmainwatch.ElapsedTicks / Stopwatch.Frequency);
            
            GatherAndMapMapData();
            GatherAndMapSelectionData();
            GatherAndMapGroupData();
            GatherAndMapGameData();

            

        }

        private void GatherAndMapPlayerData()
        {
            if (!CAccessPlayers)
                return;

            _.Info("Fetching Player Data", _.InfoImportance.NotImportant);

            // Player Buffer 
            var playerLenght = _maxPlayerAmount * MyOffsets.PlayerStructSize;
            var playerChunk = Memory.ReadMemory(MyOffsets.PlayerStruct, playerLenght);

            
            // Counts the valid race- holders (Ai, Human) 
            var iRaceCounter = 0;
            var lPlayer = new List<Player>(_maxPlayerAmount);

            if (playerChunk.Length > 0)
            {
                for (var i = 0; i < _maxPlayerAmount; i++)
                {

                    var p = new Player();

                    p.CameraPositionX = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerCameraX + (i * MyOffsets.PlayerStructSize));
                    p.CameraPositionY = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerCameraY + (i * MyOffsets.PlayerStructSize));
                    p.CameraDistance = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerCameraDistance + (i * MyOffsets.PlayerStructSize));
                    p.CameraAngle = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerCameraAngle + (i * MyOffsets.PlayerStructSize));
                    p.CameraRotation = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerCameraRotation + (i * MyOffsets.PlayerStructSize));
                    p.Difficulty = (PlayerDifficulty)playerChunk[MyOffsets.RawPlayerDifficulty + (i * MyOffsets.PlayerStructSize)];
                    p.Status = GetGPlayerStatusModified(playerChunk[MyOffsets.RawPlayerStatus + (i * MyOffsets.PlayerStructSize)]);
                    p.Type = GetGPlayerTypeModified(playerChunk[MyOffsets.RawPlayerPlayertype + (i * MyOffsets.PlayerStructSize)]);
                    p.NameLength = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerNamelenght + (i * MyOffsets.PlayerStructSize)) >> 2;
                    p.Name = Encoding.UTF8.GetString(playerChunk, MyOffsets.RawPlayerName + (i * MyOffsets.PlayerStructSize), p.NameLength);
                    p.ClanTag = Encoding.UTF8.GetString(playerChunk, MyOffsets.RawPlayerClanTag + (i * MyOffsets.PlayerStructSize), 6);
                    p.Color = GetGPlayerColorModified(BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerColor + (i * MyOffsets.PlayerStructSize)));
                    p.Apm = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerApmCurrent + (i * MyOffsets.PlayerStructSize));
                    p.Epm = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerEpmCurrent + (i * MyOffsets.PlayerStructSize));
                    p.ApmAverage = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerApmAverage + (i * MyOffsets.PlayerStructSize));
                    p.EpmAverage = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerEpmAverage + (i * MyOffsets.PlayerStructSize));
                    p.Worker = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerWorkers + (i * MyOffsets.PlayerStructSize));
                    p.UnitsInProduction = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerUnitsInProduction + (i * MyOffsets.PlayerStructSize));
                    p.AccountId = Encoding.UTF8.GetString(playerChunk, MyOffsets.RawPlayerAccountId + (i * MyOffsets.PlayerStructSize), 16);
                    p.SupplyMaxRaw = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerSupplyMax + (i * MyOffsets.PlayerStructSize));
                    p.SupplyMinRaw = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerSupplyMin + (i * MyOffsets.PlayerStructSize));
                    p.SupplyMax = p.SupplyMaxRaw >> 12;
                    p.SupplyMin = p.SupplyMinRaw >> 12;
                    p.ArmySupply = p.SupplyMin - p.Worker;
                    p.CurrentBuildings = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerCurrentBuildings + (i * MyOffsets.PlayerStructSize));
                    p.Minerals = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerMinerals + (i * MyOffsets.PlayerStructSize));
                    p.Gas = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerGas + (i * MyOffsets.PlayerStructSize));
                    p.MineralsIncome = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerMineralsIncome + (i * MyOffsets.PlayerStructSize));
                    p.GasIncome = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerGasIncome + (i * MyOffsets.PlayerStructSize));
                    p.MineralsArmy = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerMineralsArmy + (i * MyOffsets.PlayerStructSize));
                    p.GasArmy = BitConverter.ToInt32(playerChunk, MyOffsets.RawPlayerGasArmy + (i * MyOffsets.PlayerStructSize));
                    p.Team = playerChunk[MyOffsets.RawPlayerTeam + (i * MyOffsets.PlayerStructSize)];
                    p.Index = i;

                    if ((p.Type == PlayerType.Human ||
                        p.Type == PlayerType.Ai) && 
                        _lRace.Count > iRaceCounter)
                    {
                        p.PlayerRace = _lRace[iRaceCounter];
                        iRaceCounter++;
                    }

                    //* We check if the Player (name) does exist. If it does not, we 
                    // * reduce the actual Playersize and save time! */
                    //if (!p.Type.Equals(PredefinedTypes.PlayerType.Neutral))
                    //{
                    //    if (p.NameLength <= 0 ||
                    //        p.Name.StartsWith("\0"))
                    //    {
                    //        _maxPlayerAmount = i + 1;
                    //        continue;
                    //    }
                    //}

                    lPlayer.Add(p);
                }

                Player = lPlayer;

                var iLocalPlayer = GetGPlayerLocalplayer();
                if (iLocalPlayer < 16)
                    PredefinedTypes.Player.LocalPlayer = Player[iLocalPlayer];

                else
                    PredefinedTypes.Player.LocalPlayer = null;
            }

            else
            {
                if (Player.Count > 0)
                    Player.Clear();
            }
        }

        private void GatherAndMapUnitData()
        {
            if (!CAccessUnits)
                return;

            _.Info("Fetching Unit Data", _.InfoImportance.NotImportant);

            // Unit Buffer 
            var iAmountOfUnits = GetGUnitReadUnitCount();
            var unitLength = iAmountOfUnits * MyOffsets.UnitStructSize;

            var unitChunk = Memory.ReadMemory(MyOffsets.UnitStruct, unitLength);


            if (unitChunk.Length > 0)
            {
                if (iAmountOfUnits <= 0)
                    _lUnitAssigner.Clear();


                var lUnit = new List<Unit>(iAmountOfUnits);
                for (var i = 0; i < iAmountOfUnits; i++)
                {
                    //_swmainwatch.Reset();
                    //_swmainwatch.Start();

                    _bSkip = false;

                    var u = new Unit();

                    u.PositionX = BitConverter.ToInt32(unitChunk, MyOffsets.RawUnitPosX + (i * MyOffsets.UnitStructSize));
                    u.PositionY = BitConverter.ToInt32(unitChunk, MyOffsets.RawUnitPosY + (i * MyOffsets.UnitStructSize));
                    u.DestinationPositionX = BitConverter.ToInt32(unitChunk, MyOffsets.RawUnitDestinationX + (i * MyOffsets.UnitStructSize));
                    u.DestinationPositionY = BitConverter.ToInt32(unitChunk, MyOffsets.RawUnitDestinationY + (i * MyOffsets.UnitStructSize));
                    u.DamageTaken = BitConverter.ToInt32(unitChunk, MyOffsets.RawUnitDamageTaken + (i * MyOffsets.UnitStructSize));
                    u.ShieldDamageTaken = BitConverter.ToInt32(unitChunk, MyOffsets.RawUnitShieldDamageTaken + (i * MyOffsets.UnitStructSize));
                    u.TargetFilter = BitConverter.ToUInt64(unitChunk, MyOffsets.RawUnitTargetFilter + (i * MyOffsets.UnitStructSize));
                    u.State = BitConverter.ToInt32(unitChunk, MyOffsets.RawUnitState + (i * MyOffsets.UnitStructSize));
                    u.RandomFlag = unitChunk[MyOffsets.RawUnitRandomFlag + (i * MyOffsets.UnitStructSize)];
                    u.Owner = unitChunk[MyOffsets.RawUnitOwner + (i * MyOffsets.UnitStructSize)];
                    u.SpeedMultiplier = BitConverter.ToInt32(unitChunk,
                        MyOffsets.RawUnitSpeedMultiplier + (i * MyOffsets.UnitStructSize));
                    u.Movestate = BitConverter.ToInt32(unitChunk, MyOffsets.RawUnitMovestate + (i * MyOffsets.UnitStructSize));
                    u.Energy = BitConverter.ToInt32(unitChunk, MyOffsets.RawUnitEnergy + (i * MyOffsets.UnitStructSize));
                    u.BuildingState = BitConverter.ToInt16(unitChunk, MyOffsets.RawUnitBuildingState + (i * MyOffsets.UnitStructSize));
                    u.ModelPointer = BitConverter.ToInt32(unitChunk, MyOffsets.RawUnitModel + (i * MyOffsets.UnitStructSize));
                    u.AliveSince = BitConverter.ToInt32(unitChunk, MyOffsets.RawUnitAliveSince + (i * MyOffsets.UnitStructSize));
                    u.IsAlive = (u.TargetFilter & (UInt64)TargetFilterFlag.Dead) == 0;
                    u.IsUnderConstruction = (u.TargetFilter &
                                             (UInt64)TargetFilterFlag.UnderConstruction) > 0;
                    u.IsStructure = (u.TargetFilter & (UInt64)TargetFilterFlag.Structure) > 0;
                    u.IsCloaked = (u.TargetFilter & (UInt64)TargetFilterFlag.Cloaked) > 0;
                    u.IsAir = (u.TargetFilter & (UInt64)TargetFilterFlag.Air) > 0;
                    u.IsArmored = (u.TargetFilter & (UInt64)TargetFilterFlag.Armored) > 0;
                    u.IsBiological = (u.TargetFilter & (UInt64)TargetFilterFlag.Biological) > 0;
                    u.IsBurried = (u.TargetFilter & (UInt64)TargetFilterFlag.Buried) > 0;
                    u.IsDetector = (u.TargetFilter & (UInt64)TargetFilterFlag.Detector) > 0;
                    u.IsGround = (u.TargetFilter & (UInt64)TargetFilterFlag.Ground) > 0;
                    u.IsHallucination = (u.TargetFilter & (UInt64)TargetFilterFlag.Hallucination) > 0;
                    u.IsLight = (u.TargetFilter & (UInt64)TargetFilterFlag.Light) > 0;
                    u.IsMassive = (u.TargetFilter & (UInt64)TargetFilterFlag.Massive) > 0;
                    u.IsMechanical = (u.TargetFilter & (UInt64)TargetFilterFlag.Mechanical) > 0;
                    u.IsPsionic = (u.TargetFilter & (UInt64)TargetFilterFlag.Psionic) > 0;
                    u.IsRobotic = (u.TargetFilter & (UInt64)TargetFilterFlag.Robotic) > 0;
                    u.IsVisible = (u.TargetFilter & (UInt64)TargetFilterFlag.Visible) > 0;

                    /* Reset owner */
                    if (Player != null &&
                        u.Owner >= Player.Count)
                        u.Owner = 0;



                    //if (u.IsStructure)
                    //    u.ProdNumberOfQueuedUnits = GetGUnitNumberOfQueuedUnit(i);

                    //_swmainwatch.Stop();
                    //Debug.WriteLine("Unitstruct - Basic stuff: " + 1000000 * _swmainwatch.ElapsedTicks / Stopwatch.Frequency + " µs");

                    //_swmainwatch.Reset();
                    //_swmainwatch.Start();

                    for (var j = 0; j < _lUnitAssigner.Count; j++)
                    {
                        if (_lUnitAssigner[j].Pointer == u.ModelPointer)
                        {
                            var tmp = _lUnitAssigner[j].CustomStruct;
                            u.Id = tmp.Id;
                            u.Name = tmp.Name;
                            u.RawName = tmp.RawName;
                            u.NameLength = tmp.NameLenght;
                            u.Size = tmp.Size;
                            u.MaximumHealth = tmp.MaximumHealth;
                            u.MaximumShield = tmp.MaximumShield;
                            u.MaximumEnergy = tmp.MaximumEnergy;

                            if (CAccessUnitCommands)
                                AssignUnitCommands(ref u, i);





                            lUnit.Add(u);
                            _bSkip = true;
                            break;
                        }
                    }


                    //Add the specific units to each player
                    if (Player != null &&
                        Player.Count > u.Owner)
                    Player[u.Owner].Units.Add(u);
                    

                    //_swmainwatch.Stop();
                    //Debug.WriteLine("Unitstruct - Unitassigner: " + 1000000 * _swmainwatch.ElapsedTicks / Stopwatch.Frequency + " µs");


                    if (_bSkip)
                        continue;

                    /* Assign a new Unit- assigner */
                    var ua = new UnitAssigner
                    {
                        Pointer = u.ModelPointer,
                        CustomStruct = GetGUnitStruct(i)
                    };


                    _lUnitAssigner.Add(ua);

                    var tmp2 = _lUnitAssigner[_lUnitAssigner.Count - 1].CustomStruct;


                    u.Id = tmp2.Id;
                    u.Name = tmp2.Name;
                    u.RawName = tmp2.RawName;
                    u.NameLength = tmp2.NameLenght;
                    u.Size = tmp2.Size;
                    u.MaximumHealth = tmp2.MaximumHealth;
                    u.MaximumEnergy = tmp2.MaximumEnergy;

                    /* If the code reaches this point, there are A LOT units without 
                     * assigned commands. We have to redo that!
                     * That will be a one- time thing at the first launch of GameInfo- class!*/
                    if (CAccessUnitCommands)
                        AssignUnitCommands(ref u, i);

                    lUnit.Add(u);

                    if ((DateTime.Now - _dtProduction).Milliseconds >= 500)
                        _dtProduction = DateTime.Now;
                }

                Unit = lUnit;
            }

            else
            {
                if (Unit != null && Unit.Count > 0)
                    Unit.Clear();
            }
        }

        private void GatherAndMapMapData()
        {
            if (!CAccessMapInfo)
                return;

            // Map Buffer 
            var mapLength = MyOffsets.RawMapTop + 4;

            var mapChunk = Memory.ReadMemory(MyOffsets.MapStruct, mapLength);



            var map = new Map
            {
                Bottom = BitConverter.ToInt32(mapChunk, MyOffsets.RawMapBottom),
                Top = BitConverter.ToInt32(mapChunk, MyOffsets.RawMapTop),
                Right = BitConverter.ToInt32(mapChunk, MyOffsets.RawMapRight),
                Left = BitConverter.ToInt32(mapChunk, MyOffsets.RawMapLeft),
            };

            map.PlayableWidth = map.Right - map.Left;
            map.PlayableHeight = map.Top - map.Bottom;

            Map = map;
        }

        private void GatherAndMapSelectionData()
        {
            if (!CAccessSelection)
                return;

            // Selection Buffer 
            var selectionlength = GetGSelectionCount() * 4 + MyOffsets.UiRawSelectedIndex;

            var selectionChunk = Memory.ReadMemory(MyOffsets.UiRawSelectionStruct, selectionlength);


            var realSelectionCount = selectionChunk.Length / 4 - 2;


            var lSelection = new List<Selection>();

            if (CAccessSelection)
            {
                for (var i = 0; i < realSelectionCount; i++)
                {
                    var sel = new Selection();

                    sel.UnitIndex = BitConverter.ToInt16(selectionChunk, MyOffsets.UiRawSelectedIndex + (4 * i)) / 4;
                    try
                    {
                        if (sel.UnitIndex < 0 ||
                            sel.UnitIndex >= Unit.Count)
                        {
                            //Do Nothing
                        }

                        else
                            sel.Unit = Unit[sel.UnitIndex];
                    }

                    catch (Exception ex)
                    {
                        Messages.LogFile("Within 'Selection'", ex);
                    }


                    lSelection.Add(sel);
                }
            }

            Selection = lSelection;
        }

        private void GatherAndMapGroupData()
        {
            if (!CAccessGroups)
                return;

            // Group Buffer 
            var groupLenght = 11 * MyOffsets.RawGroupSize;

            var groupChunk = Memory.ReadMemory(MyOffsets.RawGroupBase, groupLenght);


            var lGroups = new List<Groups>();

            if (CAccessGroups)
            {
                for (var i = 0; i < 10; i++)
                {
                    var group = new Groups();
                    var amountOfUnits = BitConverter.ToInt16(groupChunk, MyOffsets.RawGroupAmountofUnits + (MyOffsets.RawGroupSize * i));
                    var lUnit = new List<Unit>();

                    for (var k = 0; k < amountOfUnits; k++)
                    {
                        try
                        {
                            var tmp = BitConverter.ToInt16(groupChunk,
                                (MyOffsets.RawGroupSize * i) + (MyOffsets.RawGroupUnitIndexSize * k) +
                                MyOffsets.RawGroupUnitIndex) / 4;

                            if (tmp < 0 ||
                                tmp >= Unit.Count)
                            {
                                //Do nothing
                            }

                            else
                            {
                                lUnit.Add(
                                    Unit[tmp]);
                            }
                        }

                        catch (Exception ex)
                        {
                            Messages.LogFile("Within 'Groups'", ex);
                        }
                    }

                    group.Units = lUnit;
                    lGroups.Add(group);
                }
            }

            Group = lGroups;
        }

        private void GatherAndMapGameData()
        {
            if (!CAccessGameinfo)
                return;

            var gInfo = new Gameinformation
            {
                ChatInput = GetGChatInput(),
                Timer = GetGTimer(),
                IsIngame = GetGIngame(),
                Fps = GetGFps(),
                Speed = GetGGamespeed(),
                IsTeamcolor = GetGTeamcolor(),
                ChatIsOpen = GetGChatIsOpen(),
                //Style = GetGWindowStyle(),
                ValidPlayerCount = HelpFunctions.GetValidPlayerCount(Player),
                Pause = GetGPause()
            };

            Gameinfo = gInfo;
        }




        /* Method to assign the unitcommands (how many units are in queue, how is the 
         * completion percentage of that unit) */
        private void AssignUnitCommands(ref Unit u, int i)
        {
            if (u.Id.Equals(UnitId.PbNexus) ||
                u.Id.Equals(UnitId.PbGateway) ||
                u.Id.Equals(UnitId.PbWarpgate) ||
                u.Id.Equals(UnitId.PbStargate) ||
                u.Id.Equals(UnitId.PbRoboticsbay) ||
                u.Id.Equals(UnitId.TbCcGround) ||
                u.Id.Equals(UnitId.TbOrbitalGround) ||
                u.Id.Equals(UnitId.TbPlanetary) ||
                u.Id.Equals(UnitId.TbBarracksGround) ||
                u.Id.Equals(UnitId.TbFactoryGround) ||
                u.Id.Equals(UnitId.TbStarportGround) ||
                u.Id.Equals(UnitId.ZbHatchery) ||
                u.Id.Equals(UnitId.ZbLiar) ||
                u.Id.Equals(UnitId.ZbHive) ||
                u.Id.Equals(UnitId.ZuBanelingCocoon) ||
                u.Id.Equals(UnitId.ZuBroodlordCocoon) ||
                u.Id.Equals(UnitId.ZuEgg) ||
                u.Id.Equals(UnitId.ZuOverseerCocoon) ||
                u.Id.Equals(UnitId.TbEbay) ||
                u.Id.Equals(UnitId.TbTechlabFactory) ||
                u.Id.Equals(UnitId.TbTechlabRax) ||
                u.Id.Equals(UnitId.TbTechlabStarport) ||
                u.Id.Equals(UnitId.TbFusioncore) ||
                u.Id.Equals(UnitId.TbGhostacademy) ||
                u.Id.Equals(UnitId.TbArmory) ||
                u.Id.Equals(UnitId.PbCybercore) ||
                u.Id.Equals(UnitId.PbFleetbeacon) ||
                u.Id.Equals(UnitId.PbForge) ||
                u.Id.Equals(UnitId.PbTemplararchives) ||
                u.Id.Equals(UnitId.PbTwilightcouncil) ||
                u.Id.Equals(UnitId.PbRoboticssupportbay) ||
                u.Id.Equals(UnitId.PuMothershipCore) ||
                u.Id.Equals(UnitId.ZbEvolutionChamber) ||
                u.Id.Equals(UnitId.ZbSpire) ||
                u.Id.Equals(UnitId.ZbSpawningPool) ||
                u.Id.Equals(UnitId.ZbUltraCavern) ||
                u.Id.Equals(UnitId.ZbRoachWarren) ||
                u.Id.Equals(UnitId.ZbHydraDen) ||
                u.Id.Equals(UnitId.ZbBanelingNest) ||
                u.Id.Equals(UnitId.ZbHatchery) ||
                u.Id.Equals(UnitId.ZbLiar) ||
                u.Id.Equals(UnitId.ZbHive) ||
                u.Id.Equals(UnitId.ZbInfestationPit) ||
                u.Id.Equals(UnitId.ZbGreaterspire))
            {
                if (u.IsAlive)
                {
                    var prd = GetGUnitNumberOfQueuedUnit(i,
                        u.Id);

                    for (var k = 0; k < prd.Count; k++)
                    {
                        u.ProdUnitProductionId.Add(prd[k].Id);
                        u.ProdProcess.Add(prd[k].ProductionStatus);
                        u.ProdNumberOfQueuedUnits = prd[0].UnitsInProduction;
                        u.ProdReactorAttached.Add(prd[k].ReactorAttached);
                        u.ProdMineralCost.Add(prd[k].MineralCost);
                        u.ProdVespineCost.Add(prd[k].VespineCost);
                        u.ProdTimeLeft.Add(prd[k].ProductionTimeLeft);
                        u.ProdAttachingAddOn = prd[k].AttachingAddOn;
                    }


                }

            }
        }


        #region Functions to get Playerinformation


        private PlayerStatus GetGPlayerStatusModified(Byte bValue)
        {
            switch (bValue)
            {
                case (Int32)PlayerStatus.Lost:
                    return PlayerStatus.Lost;

                case (Int32)PlayerStatus.Playing:
                    return PlayerStatus.Playing;

                case (Int32)PlayerStatus.Tied:
                    return PlayerStatus.Tied;

                case (Int32)PlayerStatus.Won:
                    return PlayerStatus.Won;

                default:
                    return PlayerStatus.NotDefined;
            }
        }



        /* Translates pure data into types */
        private PlayerType GetGPlayerTypeModified(Byte bValue)
        {
            switch (bValue)
            {
                case (Int32)PlayerType.Ai:
                    return PlayerType.Ai;

                case (Int32)PlayerType.Hostile:
                    return PlayerType.Hostile;

                case (Int32)PlayerType.Human:
                    return PlayerType.Human;

                case (Int32)PlayerType.Neutral:
                    return PlayerType.Neutral;

                case (Int32)PlayerType.Observer:
                    return PlayerType.Observer;

                case (Int32)PlayerType.Referee:
                    return PlayerType.Referee;

                default:
                    return PlayerType.NotDefined;
            }
        }

        /* Translates pure data into types */
        private Color GetGPlayerColorModified(Int32 iValue)
        {
            switch (iValue)
            {
                case (Int32)PlayerColor.Blue:
                    return Color.FromArgb(255, 0, 66, 255);

                case (Int32)PlayerColor.Brown:
                    return Color.FromArgb(255, 78, 42, 4);

                case (Int32)PlayerColor.DarkGray:
                    return Color.FromArgb(255, 35, 35, 35);

                case (Int32)PlayerColor.DarkGreen:
                    return Color.FromArgb(255, 16, 98, 70);

                case (Int32)PlayerColor.Green:
                    return Color.FromArgb(255, 22, 128, 0);

                case (Int32)PlayerColor.LightGray:
                    return Color.FromArgb(255, 82, 84, 148);

                case (Int32)PlayerColor.LightGreen:
                    return Color.FromArgb(255, 150, 255, 145);

                case (Int32)PlayerColor.LightPink:
                    return Color.FromArgb(255, 204, 166, 252);

                case (Int32)PlayerColor.Orange:
                    return Color.FromArgb(255, 254, 138, 14);

                case (Int32)PlayerColor.Pink:
                    return Color.FromArgb(255, 229, 91, 176);

                case (Int32)PlayerColor.Purple:
                    return Color.FromArgb(255, 84, 0, 129);

                case (Int32)PlayerColor.Red:
                    return Color.FromArgb(255, 182, 20, 30);

                case (Int32)PlayerColor.Teal:
                    return Color.FromArgb(255, 28, 167, 234);

                case (Int32)PlayerColor.Violet:
                    return Color.FromArgb(255, 31, 1, 201);

                case (Int32)PlayerColor.White:
                    return Color.White;

                default:
                    return Color.Yellow;
            }
        }



        /* 1 Byte */
        private Int32 GetGPlayerLocalplayer()
        {
            var tmp = Memory.ReadMemory(MyOffsets.Localplayer4, 1)[0];// InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.Localplayer4, sizeof (byte))[0];

            return tmp;
        }


        #endregion

        #region Functions to get Unitinformation



        /* Get the name */
        private UnitModelStruct GetGUnitStruct(Int32 iUnitNum)
        {
            var iContentofUnitModel = Memory.ReadInt32(MyOffsets.UnitModel + MyOffsets.UnitStructSize * iUnitNum);
            /*BitConverter.ToInt32(
                InteropCalls.Help_ReadProcessMemory(HStarcraft,
                                     MyOffsets.UnitModel + MyOffsets.UnitStructSize * iUnitNum, 4), 0);*/

            var iContentofUnitModelShifted = (iContentofUnitModel << 5) & 0xFFFFFFFF;

            /* Id - 2 Byte*/
            var id = (UnitId)Memory.ReadInt16(MyOffsets.UnitModelId + (int)iContentofUnitModelShifted);
            /*BitConverter.ToInt16(
                InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.UnitModelId + (int)iContentofUnitModelShifted, 2),
                0);*/

            //if (id.Equals(PredefinedTypes.UnitId.PuZealot))
            //{
            //    id = id + 1;
            //}

            /* Size - 4 Byte*/
            var size = (float)Memory.ReadInt32(MyOffsets.UnitModelSize + (int)iContentofUnitModelShifted);
            /* (float)BitConverter.ToInt32(
                 InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.UnitModelSize + (int)iContentofUnitModelShifted, 4),
                 0);*/

            size /= 4096;

            /* Maximum Health - 4 Byte 
             * Value is raw and has to be 
             * devided by 4096 or bitshifted >> 12! */
            var health = Memory.ReadInt32(MyOffsets.UnitMaxHealth + (int)iContentofUnitModelShifted);
            /*BitConverter.ToInt32(
                    InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.UnitMaxHealth + (int)iContentofUnitModelShifted, 4),
                    0);*/
            // HelpFunctions.GetMaximumHealth((PredefinedTypes.UnitId) id) << 12;

            var maximumEnergy = Memory.ReadInt32(MyOffsets.UnitMaxEnergy + iContentofUnitModelShifted);


            /* Maximum Health - 4 Byte 
             * Value is raw and has to be 
             * devided by 4096 or bitshifted >> 12! */
            var shield = Memory.ReadInt32(MyOffsets.UnitMaxShield + (int)iContentofUnitModelShifted);
            /*BitConverter.ToInt32(
                InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.UnitMaxShield + (int)iContentofUnitModelShifted, 4),
                0);*/
            // HelpFunctions.GetMaximumHealth((PredefinedTypes.UnitId) id) << 12;


            /* Pointer to the name struct */
            var iStringStruct = Memory.ReadInt32(MyOffsets.UnitStringStruct + (int)iContentofUnitModelShifted);
            /*BitConverter.ToInt32(
                InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.UnitStringStruct + (int)iContentofUnitModelShifted, 4),
                0);*/

            /* Namelenght */
            var iNameLenght = Memory.ReadInt32(iStringStruct);
            /*   BitConverter.ToInt32(
                   InteropCalls.Help_ReadProcessMemory(HStarcraft, iStringStruct, 4),
                   0);*/

            /* Name */
            var sName = Memory.ReadString(iNameLenght + MyOffsets.UnitString, 50, Encoding.UTF8);
            /*Encoding.UTF8.GetString(  InteropCalls.Help_ReadProcessMemory(HStarcraft, iNameLenght + MyOffsets.UnitString,
                                                                        50));*/

            if (sName.Contains("\0"))
                sName = sName.Substring(0, sName.IndexOf('\0'));


            var str = new UnitModelStruct();
            str.NameLenght = sName.Length;
            str.RawName = sName;
            str.Id = id;
            str.MaximumHealth = health;
            str.MaximumShield = shield;
            str.Size = size;
            str.MaximumEnergy = maximumEnergy;

            if (sName.Contains("Unit/Name"))
                str.Name = sName.Substring(10);

            return str;
        }

        /* 4 Bytes */
        private Int32 GetGUnitReadUnitCount()
        {
            return Memory.ReadInt32(MyOffsets.UnitTotal);
            /*  (BitConverter.ToInt32(
                  InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.UnitTotal, sizeof(Int32)),
                  0));*/
        }

        private List<UnitProduction> GetGUnitNumberOfQueuedUnit(Int32 iUnitNum, UnitId structureId)
        {
            _.Info("Assign Special Attributes Of Units", _.InfoImportance.Important);

            var lUnitIds = new List<UnitProduction>();

            /* Content of Abilities (pAbilities) */
            var iUnitAbilitiesPointer = Memory.ReadUInt32(MyOffsets.UnitStruct + 0xDC + MyOffsets.UnitStructSize * iUnitNum);
            /* BitConverter.ToUInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.UnitStruct + 0xDC + MyOffsets.UnitStructSize * iUnitNum, 4), 0);*/





            /* Bitwise AND */
            iUnitAbilitiesPointer = iUnitAbilitiesPointer & 0xFFFFFFFC;




            var iAbilityCount = Memory.ReadInt16((int)iUnitAbilitiesPointer + 0x16);
            /*BitConverter.ToInt16(InteropCalls.Help_ReadProcessMemory(HStarcraft, (int)iUnitAbilitiesPointer + 0x16, 2),
                                 0);
        */

            /* Reading the Bytearray */

            /* Read the result of iUnitAbilitiesPointer (p1) */
            var iUnitAbilitiesPointerResult = Memory.ReadInt32(iUnitAbilitiesPointer);
            /*BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft,
                                                                                             (int)iUnitAbilitiesPointer, 4),
                                                         0);*/

            /* Add 3 to that value */
            iUnitAbilitiesPointerResult += 3;

            try
            {
                Memory.ReadMemory(iUnitAbilitiesPointerResult, iAbilityCount);
            }

            catch
            {
                throw new Exception("If you read this, don't commit suicide! I fucked up - sorry.\n" +
                "Just report this thing!");
            }

            Int32 iIndexToLookAt = -1;
            var byteBuffer = Memory.ReadMemory(iUnitAbilitiesPointerResult, iAbilityCount);// InteropCalls.Help_ReadProcessMemory(HStarcraft, iUnitAbilitiesPointerResult, iAbilityCount);

            for (var i = 0; i < byteBuffer.Length; i++)
            {
#if !DEBUG

                if (byteBuffer[i].Equals(0x19))
                {
                    iIndexToLookAt = i;

                    if (!structureId.Equals(UnitId.TbPlanetary))
                        break;
                }

#else
                #region Debug/ Tests

                var _iContentOfPointer = Memory.ReadUInt32(iUnitAbilitiesPointer + 0x18 + 4*i);
                   /* BitConverter.ToUInt32(
                        InteropCalls.Help_ReadProcessMemory(HStarcraft, (Int32)iUnitAbilitiesPointer + 0x18 + 4 * i, 4),
                        0);*/

                // Number of queued Units 
                var _iNumberOfQueuedUnits = Memory.ReadInt32(_iContentOfPointer + 0x28);
                    /*BitConverter.ToInt32(
                    InteropCalls.Help_ReadProcessMemory(HStarcraft, (Int32)_iContentOfPointer + 0x28, 4), 0);*/

                var _bReactorAttached = Memory.ReadInt32(_iContentOfPointer + 0x48);
                    /*BitConverter.ToInt32(
                InteropCalls.Help_ReadProcessMemory(HStarcraft, (Int32)_iContentOfPointer + 0x48, 4), 0) != 0
                                       ? true
                                       : false;*/

                var result2 = Memory.ReadUInt32(iUnitAbilitiesPointerResult - 3 + 0xA4 + (i*4));
                /*    BitConverter.ToUInt32(
                        InteropCalls.Help_ReadProcessMemory(HStarcraft, iUnitAbilitiesPointerResult - 3 + 0xA4 + (i * 4), 4), 0);
                */
                var resultOfResult2 = Memory.ReadUInt32(result2 + 4);
                  /*  BitConverter.ToUInt32(
                        InteropCalls.Help_ReadProcessMemory(HStarcraft, (UInt32)(result2 + 4), 4), 0);
                */

                var strAbilityName = Memory.ReadString(resultOfResult2, 16, Encoding.UTF8);
                   /* Encoding.UTF8.GetString(InteropCalls.Help_ReadProcessMemory(HStarcraft, resultOfResult2,
                        16));*/


                var _iArrayOfBytes = Memory.ReadInt32(_iContentOfPointer + 0x34);
                   /* BitConverter.ToInt32(
                        InteropCalls.Help_ReadProcessMemory(HStarcraft, (Int32)_iContentOfPointer + 0x34, 4), 0);
                */

                var _iTempPtr = Memory.ReadInt32(_iArrayOfBytes);
                   /* BitConverter.ToInt32(
                        InteropCalls.Help_ReadProcessMemory(HStarcraft, (Int32)_iArrayOfBytes, 4), 0);
                */

                var _productionChunk = Memory.ReadMemory(_iTempPtr, 0x80);
                   /* InteropCalls.Help_ReadProcessMemory(HStarcraft, _iTempPtr, 0x80);*/

                var _iType = BitConverter.ToInt32(_productionChunk, 0x44);
                var _iSupplyRaw = BitConverter.ToInt32(_productionChunk, 0x64);
                var _iTimeMax = BitConverter.ToUInt32(_productionChunk, 0x68);
                var _iTimeLeft = (float)BitConverter.ToUInt32(_productionChunk, 0x6C);
                var _iMineralCost = BitConverter.ToInt32(_productionChunk, 0x74);
                var _iVespineCost = BitConverter.ToInt32(_productionChunk, 0x78);

                var _iSomething = Memory.ReadInt32(_iContentOfPointer + 0x4);
                   /* BitConverter.ToInt32(
                        InteropCalls.Help_ReadProcessMemory(HStarcraft, (Int32) _iContentOfPointer + 0x4, 4), 0);
                */

                Debug.WriteLine("\n");
                Debug.WriteLine("i: " + i);
                Debug.WriteLine("iPointerResult - 3: 0x" + (iUnitAbilitiesPointerResult - 3).ToString("X8"));
                Debug.WriteLine("Result2 (0xA4): 0x" + result2.ToString("X8"));
                Debug.WriteLine("Result of Result2: 0x" + result2.ToString("X8"));
                Debug.WriteLine("Ability Name: " + strAbilityName);
                //Debug.WriteLine("NumberOfQueuedUnits: " + _iNumberOfQueuedUnits);
                //Debug.WriteLine("Bytebuffer Item: 0x" + byteBuffer[i].ToString("X2") + " - " + byteBuffer[i]);
                //Debug.WriteLine("Minerals: " + _iMineralCost);
                //Debug.WriteLine("Reactor Attached: " + _bReactorAttached);
                //Debug.WriteLine("iType: " + _iType);
                //Debug.WriteLine("Time Left: " + _iTimeLeft);
                //Debug.WriteLine("iContent of pointer: 0x" + _iContentOfPointer.ToString("X8"));
                //Debug.WriteLine("Temp ptr: 0x" + _iTempPtr.ToString("X8"));
                //Debug.WriteLine("iSometzhing: 0x" + _iSomething.ToString("X8"));
               

                #endregion

#endif
            }



            /* Read the DATA Pointer (that leads to our result) */
            var iContentOfPointer = Memory.ReadUInt32(iUnitAbilitiesPointer + 0x18 + 4 * iIndexToLookAt);
            /*BitConverter.ToUInt32(
                InteropCalls.Help_ReadProcessMemory(HStarcraft, (Int32)iUnitAbilitiesPointer + 0x18 + 4 * iIndexToLookAt, 4), 0);*/

            /* Number of queued Units */
            var iNumberOfQueuedUnits = Memory.ReadInt32(iContentOfPointer + 0x28);
            /*   BitConverter.ToInt32(
               InteropCalls.Help_ReadProcessMemory(HStarcraft, (Int32) iContentOfPointer + 0x28, 4), 0);*/

            //Check if an addon is beeing added
            var bAddOnAttaching = Memory.ReadInt32(iContentOfPointer + 0x9C) == 260;

            var bReactorAttached = Memory.ReadInt32(iContentOfPointer + 0x48) != 0;
            /*  BitConverter.ToInt32(
              InteropCalls.Help_ReadProcessMemory(HStarcraft, (Int32) iContentOfPointer + 0x48, 4), 0) != 0;*/

            var iArrayOfBytes = Memory.ReadInt32(iContentOfPointer + 0x34);
            /* BitConverter.ToInt32(
                 InteropCalls.Help_ReadProcessMemory(HStarcraft, (Int32) iContentOfPointer + 0x34, 4), 0);*/

            var iTempPtr = Memory.ReadInt32(iArrayOfBytes);
            /*BitConverter.ToInt32(
                InteropCalls.Help_ReadProcessMemory(HStarcraft, iArrayOfBytes , 4), 0);*/

            /* Because it's possible that a Reactor builds two different units, we have to check that! */
            if (bReactorAttached && iNumberOfQueuedUnits > 1)
            {
                var iTempPtr2 = Memory.ReadInt32(iArrayOfBytes + 4);
                /*   BitConverter.ToInt32(
                   InteropCalls.Help_ReadProcessMemory(HStarcraft, iArrayOfBytes + 4, 4), 0);*/

                var productionChunk2 = Memory.ReadMemory(iTempPtr2, 0x80);
                /*InteropCalls.Help_ReadProcessMemory(HStarcraft, iTempPtr2, 0x80);*/

                var iType2 = BitConverter.ToInt32(productionChunk2, 0x44);
                var iSupplyRaw2 = BitConverter.ToInt32(productionChunk2, 0x64);
                var iTimeMax2 = BitConverter.ToUInt32(productionChunk2, 0x68);
                var iTimeLeft2 = (float)BitConverter.ToUInt32(productionChunk2, 0x6C);
                var iMineralCost2 = BitConverter.ToInt32(productionChunk2, 0x74);
                var iVespineCost2 = BitConverter.ToInt32(productionChunk2, 0x78);
                var iUnitIndexBuiltFrom2 = BitConverter.ToUInt16(productionChunk2, 0x5E) / 4;

                Console.WriteLine("Supply Raw: " + iSupplyRaw2);

                var prd2 = new UnitProduction();
                prd2.ProductionStatus = 100 - (iTimeLeft2 / iTimeMax2) * 100;
                prd2.Id = HelpFunctions.GetUnitIdFromLogicalId(structureId, iType2, (Int32)iTimeMax2, iMineralCost2, iVespineCost2, iSupplyRaw2 >> 12);
                prd2.ReactorAttached = bReactorAttached;
                prd2.UnitsInProduction = iNumberOfQueuedUnits;
                prd2.MineralCost = iMineralCost2;
                prd2.AttachingAddOn = bAddOnAttaching;
                prd2.VespineCost = iVespineCost2;
                prd2.SupplyRaw = iSupplyRaw2;
                prd2.Supply = iSupplyRaw2 >> 12;
                prd2.ProductionTimeLeft = iTimeLeft2 / 65536;


                lUnitIds.Add(prd2);
            }

            //That will happen if there is no unit to be build or something is morphing like a Hatch => Lair
            //Thus: Check if the sourcebuilding is a hatch or something..
            else if (iNumberOfQueuedUnits <= 0)
            {
                if (structureId.Equals(UnitId.ZbHatchery) ||
                    structureId.Equals(UnitId.ZbLiar) ||
                    structureId.Equals(UnitId.ZbSpire) ||
                    structureId.Equals(UnitId.ZuBroodlordCocoon) ||
                    structureId.Equals(UnitId.ZuOverseerCocoon) ||
                    structureId.Equals(UnitId.TbCcGround) ||
                    structureId.Equals(UnitId.PuMothershipCore) ||
                    structureId.Equals(UnitId.PuArchon))
                {
                    var iUnitCommandQueuePointer = Memory.ReadUInt32(MyOffsets.UnitStruct + 0xD4 + MyOffsets.UnitStructSize * iUnitNum);
                    /*InteropCalls.ReadUInt32(HStarcraft,
                    MyOffsets.UnitStruct + 0xD4 + MyOffsets.UnitStructSize * iUnitNum);*/

                    if (iUnitCommandQueuePointer > 0)
                    {
                        var iUnitCommandQueueChunk = Memory.ReadMemory(iUnitCommandQueuePointer + 0x98, 0xCC);
                        /*InteropCalls.Help_ReadProcessMemory(HStarcraft,
                            iUnitCommandQueuePointer + 0x98,
                            0xCC);
                        */
                        var iType2 = -1; //BitConverter.ToInt32(iUnitCommandQueueChunk, 0x44);
                        var iTimeMax2 = BitConverter.ToUInt32(iUnitCommandQueueChunk, 0x1C);
                        var iTimeLeft2 = (float)BitConverter.ToUInt32(iUnitCommandQueueChunk, 0);
                        var iMineralCost2 = BitConverter.ToInt32(iUnitCommandQueueChunk, 0xC4);
                        var iVespineCost2 = BitConverter.ToInt32(iUnitCommandQueueChunk, 0xC8);

                        var prd2 = new UnitProduction
                        {
                            Id =
                                HelpFunctions.GetUnitIdFromLogicalId(structureId, iType2, (Int32)iTimeMax2,
                                    iMineralCost2, iVespineCost2, 0),
                            MineralCost = iMineralCost2,
                            ProductionStatus = 100 - (iTimeLeft2 / iTimeMax2) * 100,
                            ProductionTimeLeft = iTimeLeft2 / 65536,
                            ReactorAttached = false,
                            Supply = 0,
                            SupplyRaw = 0,
                            UnitsInProduction = 0,
                            VespineCost = iVespineCost2
                        };

                        lUnitIds.Add(prd2);

                    }
                }
            }

            var productionChunk = Memory.ReadMemory(iTempPtr, 0x80);// InteropCalls.Help_ReadProcessMemory(HStarcraft, iTempPtr, 0x80);

            #region Debug and Tests

            // /* Read all 4- Bytes */

            // //var sw = new StreamWriter("Seeking.txt");
            // var strResult = "Looking for (Marine): 85 - (0x55)\n\n";

            // //sw.WriteLine(strResult);
            // for (var i = 0; i < productionChunk.Length / 4; i++)
            // {
            //     //strResult = String.Empty;

            //     //strResult += "0x" + (i * 4).ToString("X2");
            //     //strResult += ":";
            //     //strResult += (BitConverter.ToInt32(productionChunk, i * 4)).ToString() + " - (0x" +
            //     //             (BitConverter.ToInt32(productionChunk, i * 4)).ToString("X2") + ")";

            //     //sw.WriteLine(strResult);
            //     var iProbPtr = BitConverter.ToInt32(productionChunk, i * 4);
            //     var iResPtr = InteropCalls.Help_ReadProcessMemory(HStarcraft, iProbPtr, 4);

            //     var iInt32ResPtr = BitConverter.ToInt32(iResPtr, 0);

            //     //if (iInt32ResPtr != 0)
            //     //{
            //     //    var iChunk = InteropCalls.Help_ReadProcessMemory(HStarcraft, iInt32ResPtr, 0x80);

            //     //    strResult += "We are at: 0x" + iInt32ResPtr.ToString("X2") + "\n";

            //     //    for (var j = 0; j < 0x80/2; j++)
            //     //    {
            //     //        strResult += "0x" + (j*2).ToString("X2") + ": " + (BitConverter.ToUInt16(iChunk, j*2) / 4096).ToString() +
            //     //                     " - (0x" +
            //     //                     (BitConverter.ToUInt16(iChunk, j*2) / 4096).ToString("X2") + ")";
            //     //        strResult += "\n";

            //     //    }

            //     if (iInt32ResPtr != 0)
            //     {
            //         strResult += "0x" + (i * 4).ToString("X2");
            //         strResult += ":";
            //         strResult += ((BitConverter.ToInt32(productionChunk, i * 4) << 5) & 0xFFFFFFFC).ToString() + " - (0x" +
            //                      ((BitConverter.ToInt32(productionChunk, i * 4) << 5) & 0xFFFFFFFC).ToString("X2") + ")";
            //         strResult += "\n";
            //     }


            //     //}
            // }
            // MessageBox.Show(strResult);

            //// sw.Close();

            // //MessageBox.Show(strResult);


            #endregion

            var iType = BitConverter.ToInt32(productionChunk, 0x44);
            var iSupplyRaw = BitConverter.ToInt32(productionChunk, 0x64);
            var iTimeMax = BitConverter.ToUInt32(productionChunk, 0x68);
            var iTimeLeft = (float)BitConverter.ToUInt32(productionChunk, 0x6C);
            var iMineralCost = BitConverter.ToInt32(productionChunk, 0x74);
            var iVespineCost = BitConverter.ToInt32(productionChunk, 0x78);
            var iUnitIndexBuiltFrom = BitConverter.ToUInt16(productionChunk, 0x5E) / 4;
            var strType = Convert.ToString(iType, 16);


            var prd = new UnitProduction();
            prd.ProductionStatus = 100 - (iTimeLeft / iTimeMax) * 100;
            prd.Id = HelpFunctions.GetUnitIdFromLogicalId(structureId, iType, (Int32)iTimeMax, iMineralCost, iVespineCost, iSupplyRaw >> 12);
            prd.ReactorAttached = bReactorAttached;
            prd.UnitsInProduction = iNumberOfQueuedUnits;
            prd.MineralCost = iMineralCost;
            prd.VespineCost = iVespineCost;
            prd.SupplyRaw = iSupplyRaw;
            prd.Supply = iSupplyRaw >> 12;
            prd.ProductionTimeLeft = iTimeLeft / 65536;
            prd.AttachingAddOn = bAddOnAttaching;

            if (prd.Id != UnitId.None)
                lUnitIds.Add(prd);

            return lUnitIds;


        }

        #endregion

        #region Functions to get the Selection- stuff

        private Int32 GetGSelectionCount()
        {
            return Memory.ReadInt16(MyOffsets.UiTotalSelectedUnits);
            //(BitConverter.ToInt16(InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.UiTotalSelectedUnits, 2), 0));
        }

        #endregion


        #region Functions to get Gameinformation

        //Max length is 255
        private string GetGChatInput()
        {
            var i1 = Memory.ReadInt32(MyOffsets.ChatBase);// BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.ChatBase, 4), 0);
            var i2 = Memory.ReadInt32(MyOffsets.ChatOff0 + i1);// BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.ChatOff0 + i1, 4), 0);
            var i3 = Memory.ReadInt32(MyOffsets.ChatOff1 + i2); //BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.ChatOff1 + i2, 4), 0);
            var i4 = Memory.ReadInt32(MyOffsets.ChatOff2 + i3); //BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.ChatOff2 + i3, 4), 0);
            var i5 = Memory.ReadInt32(MyOffsets.ChatOff3 + i4); //BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.ChatOff3 + i4, 4), 0);

            var i6 = i5 + MyOffsets.ChatOff4;    //<-- Result

            return Memory.ReadString(i6, 255, Encoding.UTF8);// Encoding.UTF8.GetString(InteropCalls.Help_ReadProcessMemory(HStarcraft, i6, 255));
        }

        private bool GetGChatIsOpen()
        {
            return false;

            /*

            var i1 = BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.ChatOpenBase, 4), 0);
            var i2 = BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.ChatOpenOff0 + i1, 4), 0);
            var i3 = BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.ChatOpenOff1 + i2, 4), 0);
            var i4 = BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.ChatOpenOff2 + i3, 4), 0);
            var i5 = BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.ChatOpenOff3 + i4, 4), 0);

            var i6 = i5 + MyOffsets.ChatOpenOff4;    //<-- Result

            return BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft, i6, 255), 0) > 0;*/
        }

        /* 4 Bytes */
        private Int32 GetGTimer()
        {
            var iGameTimeRaw = Memory.ReadInt32(MyOffsets.TimerData);
            var iGameTime = iGameTimeRaw >> 12;

            //Console.WriteLine("Gametime Raw: {0}", iGameTimeRaw);
            //Console.WriteLine("Gametime: {0}", iGameTime);

            return iGameTime;
        }

        /* Gathered from Timerdata */
        private Boolean GetGIngame()
        {
            return (GetGTimer() != 0);
        }

        /* 4 Bytes */
        private Int32 GetGFps()
        {
            return Memory.ReadInt32(MyOffsets.FramesPerSecond);
            /*(BitConverter.ToInt32(
                InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.FramesPerSecond, sizeof (Int32)), 0));*/
        }

        /* 4 Bytes */
        private Gamespeed GetGGamespeed()
        {
            var iBuffer = Memory.ReadInt32(MyOffsets.Gamespeed);
            // BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.Gamespeed, sizeof (Int32)), 0);

            return (Gamespeed)iBuffer;
        }

        /* 1 Byte */
        private Boolean GetGTeamcolor()
        {
            var iBuffer = Memory.ReadByte(MyOffsets.TeamColor1);// InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.TeamColor1, sizeof (Byte))[0];

            if (iBuffer == 0)
                return false;

            return true;
        }

        /* 4 Bytes - No memory read */
        private WindowStyle GetGWindowStyle()
        {
            var iBuffer = InteropCalls.GetWindowLongPtr(Memory.Process.MainWindowHandle, (Int32)InteropCalls.Gwl.ExStyle);

            return (WindowStyle)iBuffer;
        }

        /* 4 Bytes */
        private Boolean GetGPause()
        {
            return Memory.ReadInt32(MyOffsets.PauseEnabled) > 0;// (BitConverter.ToInt32(InteropCalls.Help_ReadProcessMemory(HStarcraft, MyOffsets.PauseEnabled, 4), 0) > 0);
        }

        #endregion

        public Int32 CSleepTime { get; set; }
        public Boolean CThreadState { get; set; }
        public Process CStarcraft2 { get; set; }
        public WindowStyle CWindowStyle { get; set; }


        public bool CAccessUnitCommands { get; private set; }

        private bool _cAccessUnits;

        public bool CAccessUnits
        {
            get
            {
                if (_iUnitCalls > 10)
                {
                    _.Info("Not Using Units Anymore", _.InfoImportance.NotImportant);
                    _cAccessUnits = false;
                    CAccessUnitCommands = false;
                }

                _iUnitCalls += 1;
                return _cAccessUnits;
            }
            private set { _cAccessUnits = value; }
        }

        private bool _cAccessPlayers;
        public bool CAccessPlayers
        {
            get
            {
                if (_iPlayerCalls > 10)
                {
                    _.Info("Not Using Players Anymore", _.InfoImportance.NotImportant);
                    _cAccessPlayers = false;
                }

                _iPlayerCalls += 1;

                return _cAccessPlayers;
            }
            private set { _cAccessPlayers = value; }
        }

        private bool _cAccessGroups;
        public bool CAccessGroups
        {
            get
            {
                if (_iGroupCalls > 10)
                {
                    _.Info("Not Using Groups Anymore", _.InfoImportance.NotImportant);
                    _cAccessGroups = false;
                }

                _iGroupCalls += 1;

                return _cAccessGroups;
            }
            private set { _cAccessGroups = value; }
        }

        private bool _cAccessSelection;
        public bool CAccessSelection
        {
            get
            {
                if (_iSelectionCalls > 10)
                {
                    _.Info("Not Using Selections Anymore", _.InfoImportance.NotImportant);
                    _cAccessSelection = false;
                }

                _iSelectionCalls += 1;

                return _cAccessSelection;
            }
            private set { _cAccessSelection = value; }
        }

        private bool _cAccessMapInfo;
        public bool CAccessMapInfo
        {
            get
            {
                if (_iMapinfoCalls > 10)
                {
                    _.Info("Not Using Mapdata Anymore", _.InfoImportance.NotImportant);
                    _cAccessMapInfo = false;
                }

                _iMapinfoCalls += 1;

                return _cAccessMapInfo;
            }
            private set { _cAccessMapInfo = value; }
        }

        private bool _cAccessGameinfo;
        public bool CAccessGameinfo
        {
            get
            {
                if (_iGameinfoCalls > 10)
                {
                    _.Info("Not Using Gameinfo Anymore", _.InfoImportance.NotImportant);
                    _cAccessGameinfo = false;
                }

                _iGameinfoCalls += 1;

                return _cAccessGameinfo;
            }
            private set { _cAccessGameinfo = value; }
        }


        private int _iPlayerCalls;
        private int _iUnitCalls;
        private int _iMapinfoCalls;
        private int _iSelectionCalls;
        private int _iGroupCalls;
        private int _iGameinfoCalls;

        #region Units

        private List<Unit> _unit = new List<Unit>();

        public List<Unit> Unit
        {
            get
            {
                _iUnitCalls = 0;
                CAccessUnits = true;
                CAccessUnitCommands = true;
                return _unit;
            }
            set { _unit = value; }
        }

        #endregion

        #region Map

        private Map _map;

        public Map Map
        {
            get
            {
                _iMapinfoCalls = 0;
                CAccessMapInfo = true;
                return _map;
            }
            set { _map = value; }
        }

        #endregion

        #region Gameinfo

        private Gameinformation _gameinfo = new Gameinformation();

        public Gameinformation Gameinfo
        {
            get
            {
                _iGameinfoCalls = 0;
                CAccessGameinfo = true;
                return _gameinfo;
            }
            set { _gameinfo = value; }
        }

        #endregion

        #region Selection

        private List<Selection> _selection = new List<Selection>();

        public List<Selection> Selection
        {
            get
            {
                _iSelectionCalls = 0;
                CAccessSelection = true;
                return _selection;
            }
            set { _selection = value; }
        }

        #endregion

        #region Group

        private List<Groups> _group = new List<Groups>();

        public List<Groups> Group
        {
            get
            {
                _iGroupCalls = 0;
                CAccessGroups = true;
                return _group;
            }
            set { _group = value; }
        }

        #endregion

        #region Player

        private List<Player> _player = new List<Player>();

        public List<Player> Player
        {
            get
            {
                _iPlayerCalls = 0;
                CAccessPlayers = true;
                return _player;
            }
            set { _player = value; }
        }

        #endregion

        public Int32 RandomNumber { get; set; }
        public DateTime LastCallTime { get; private set; }
    }
}
