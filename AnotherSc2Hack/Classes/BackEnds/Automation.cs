using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds.Gameinfo;
using AnotherSc2Hack.Classes.FrontEnds.MainHandler;
using PredefinedTypes = Predefined.PredefinedData;

namespace AnotherSc2Hack.Classes.BackEnds
{
    class DrawPanel : Form
    {
        public String DrawText { get; set; }

        private String _strDefaultString = "Active";
        private readonly System.Windows.Forms.Timer _tmrMainTick = new System.Windows.Forms.Timer();

        public DrawPanel()
        {
            _tmrMainTick.Tick += _tmrMainTick_Tick;
            _tmrMainTick.Interval = 33; /* Around 30 FPS */
            _tmrMainTick.Enabled = true;

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint, true);

            TransparencyKey = Color.Pink;
            BackColor = Color.Pink;
            FormBorderStyle = FormBorderStyle.None;
            DrawText = "Active";
            TopMost = true;

        }

        public override sealed Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        void _tmrMainTick_Tick(object sender, EventArgs e)
        {
            
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawString(DrawText, new Font("Calibri", 14, FontStyle.Bold), Brushes.Green, 0, 0);
        }
    }

    class Automation
    {
        private readonly MainHandler _hMainhandler;
        private Boolean _bNeedToBuild;
        private DateTime _dtTimeStamp = DateTime.Now;
        private readonly DrawPanel _dPnl = new DrawPanel();
        

        public Boolean WorkerProduction { get; set; }

        public void StartWorkerProduction()
        {
            WorkerProduction = true;


            var thrWorkerProduction = new Thread(AutoWorkerProduction)
            {
                Name = "Worker Production",
                Priority = ThreadPriority.Highest
            };

            thrWorkerProduction.Start();
        }

        public void StopWorkerProduction()
        {
            WorkerProduction = false;
        }
        

        public Automation(MainHandler hMainhandler, PredefinedTypes.Automation flag)
        {
            _hMainhandler = hMainhandler;
            _dPnl.Show();

            CoreAutomationStatus = true;
            CoreSleeptime = 100;

            

            if (flag.Equals(PredefinedTypes.Automation.WorkerProduction))
            {
                var thrAutomationWorker = new Thread(AutomationWorker)
                {
                    Name = "Automationworker",
                    Priority = ThreadPriority.Highest
                };
                thrAutomationWorker.Start();
            }

            if (flag.Equals(PredefinedTypes.Automation.Inject))
            {
                var thrInjection = new Thread(Inject)
                {
                    Name = "Inject Worker",
                    Priority = ThreadPriority.Highest
                };
                thrInjection.Start();
            }

            if (flag.Equals(PredefinedTypes.Automation.Production))
            {
                var thrProduction = new Thread(Production)
                {
                    Name = "Production Worker",
                    Priority = ThreadPriority.Highest
                };

                var thrLeftClick = new Thread(CatchLeftClick)
                    {
                        Name = "LeftClick Worker",
                        Priority = ThreadPriority.AboveNormal
                    };


                CoreSleeptime = 50;
                thrProduction.Start();
                thrLeftClick.Start();
            }

            if (flag.Equals(PredefinedTypes.Automation.Testing))
            {
                StartWorkerProduction();
            }
        }

        private void AutoWorkerProductionProtoss(ref Process sc2, ref GameInfo gInfo, ref Player localplayer)
        {
            
        }

        private Int32 GetGroupNumber(Keys group)
        {
            switch (group)
            {
                case Keys.D1:
                    return 0;

                case Keys.D2:
                    return 1;

                case Keys.D3:
                    return 2;

                case Keys.D4:
                    return 3;

                case Keys.D5:
                    return 4;

                case Keys.D6:
                    return 5;

                case Keys.D7:
                    return 6;

                case Keys.D8:
                    return 7;

                case Keys.D9:
                    return 8;

                case Keys.D0:
                    return 9;

                default:
                    return -1;
            }
        }

        Stopwatch _swMainwatch = new Stopwatch();
        private int _iIteration = 0;

        

        //TODO: Exception when writing
        private void AutoWorkerProduction()
        {
            var bSleepLonger = false;

            var gMainInfo = new GameInfo(false);
            gMainInfo.CAccessUnitCommands = true;
            gMainInfo.CAccessSelection = true;
            gMainInfo.CAccessGroups = true;
        

            var lLockedUnitList = new List<UnitLock>();
            var lLockedUnitListOld = new List<UnitLock>();
            

            while (WorkerProduction)
            {
                /* Sleeptime *has* to be set that high - some bugs will happen (doubled Workers in queue) if it will be lower */
                if (bSleepLonger)
                    Thread.Sleep(250);

                else
                    Thread.Sleep(1);

                bSleepLonger = false;

                #region Check if MainInfo was actually set...

                if (gMainInfo.CStarcraft2 == null)
                {
                    gMainInfo = new GameInfo(false);
                    Thread.Sleep(100);
                    continue;
                }

                #endregion

                gMainInfo.DoMassiveScan();

                #region Exceptions/ Throws/ handling

                /* Get new data */
                var pSc2 = _hMainhandler.PSc2Process;

                /* Exceptions when not in a game/ SC2 not started */
                if (pSc2 == null)
                {
                    bSleepLonger = true;
                    continue;
                }

                if (gMainInfo.Gameinfo == null)
                {
                    bSleepLonger = true;
                    continue;
                }

                if (!gMainInfo.Gameinfo.IsIngame)
                {
                    bSleepLonger = true;
                    continue;
                }

                if (gMainInfo.Player == null ||
                    gMainInfo.Unit == null ||
                    gMainInfo.Group == null ||
                    gMainInfo.Selection == null)
                {
                    bSleepLonger = true;
                    continue;
                }


                /* Check if the localplayer is in the game */
                if (gMainInfo.Player.LocalplayerIndex >= 16)
                {
                    bSleepLonger = true;
                    continue;
                }

                /* Open Chat */
                if (gMainInfo.Gameinfo.ChatIsOpen)
                {
                    _dPnl.DrawText = "Chat Open";
                    bSleepLonger = true;
                    continue;
                }

                /* If supply is okay */
                var tmpLocPlayer = gMainInfo.Player[gMainInfo.Player.LocalplayerIndex];
                if (tmpLocPlayer.SupplyMin >= tmpLocPlayer.SupplyMax ||
                    tmpLocPlayer.SupplyMin >= 200)
                {
                    bSleepLonger = true;
                    continue;
                }
                    

                /* If there are enough Minerals for Workers */
                if (tmpLocPlayer.Minerals < 50)
                {
                    _dPnl.DrawText = "Not enough Minerals";
                    bSleepLonger = true;
                    continue;
                }

                /* Build to a certain amount of units */
                if (tmpLocPlayer.Worker >= _hMainhandler.PSettings.WorkerAutomationMaximumWorkers)
                {
                    _dPnl.DrawText = "Harvestercount reached!";
                    bSleepLonger = true;
                    continue;
                }

                if (_hMainhandler.PSettings.WorkerAutomationDisableWhenSelecting)
                {
                    if (HelpFunctions.HotkeysPressed(Keys.LButton) ||
                        HelpFunctions.HotkeysPressed(Keys.RButton))

                    {
                        _dPnl.DrawText = "Mouse selecting";
                        bSleepLonger = true;
                        continue;
                    }
                }

                /* Shift will break *anything* - Units will regroup and be added if it's held. 
                 * We simply wait till it's released! */
                if (HelpFunctions.HotkeysPressed(Keys.ShiftKey) ||
                    HelpFunctions.HotkeysPressed(Keys.ControlKey))
                {
                    _dPnl.DrawText = "Shift/ CTRL beeing pressed";
                    bSleepLonger = true;
                    continue;
                }

                /* Apm protection */
                if (tmpLocPlayer.Apm >= _hMainhandler.PSettings.WorkerAutomationApmProtection)
                {
                    _dPnl.DrawText = "APM protection [" + tmpLocPlayer.Apm + "]";
                    bSleepLonger = true;
                    continue;
                }

                if (_hMainhandler.PSettings.WorkerAutomationStartNextWorkerAt > 100)
                    _hMainhandler.PSettings.WorkerAutomationStartNextWorkerAt = 99;

                /* Check current selection */
                var bEscape = false;
                var bSurpressEscapeKeyPress = false;
                for (var i = 0; i < gMainInfo.Selection.Count; i++)
                {
                    var selection = gMainInfo.Selection[i];

                    if (selection.Unit.Id == PredefinedTypes.UnitId.TuScv ||
                        selection.Unit.Id == PredefinedTypes.UnitId.PuProbe)
                    {
                        bEscape = true;
                        break;
                    }

                    if (selection.Unit.IsUnderConstruction)
                        bSurpressEscapeKeyPress = true;
                }

                if (bEscape)
                    continue;

                if (HelpFunctions.HotkeysPressed(Keys.Escape))
                {
                    _dPnl.DrawText = "Escape pressed";
                    Thread.Sleep(3000);
                    continue;
                }

                #endregion

                _dPnl.DrawText = "Active";

                _iIteration += 1;

                /* Check "CC- Group" only */
                Int32 iGroup = GetGroupNumber(_hMainhandler.PSettings.WorkerAutomationMainbuildingGroup);
                if (iGroup == -1)
                {
                    MessageBox.Show("Wrong Mainbuidinggroup!");
                    return;
                }

                if (gMainInfo.Group.Count < iGroup)
                    continue;

                /* Save the unitlocks */
                var bReAssign = false;
                if (lLockedUnitListOld.Count > 0)
                {
                    if ((DateTime.Now - lLockedUnitListOld[0].Date).Seconds >= 1)
                        bReAssign = true;
                }

                else
                    bReAssign = true;

                if (bReAssign)
                {
                    lLockedUnitListOld.Clear();
                    if (lLockedUnitList.Count > 0)
                    {
                        foreach (var i in lLockedUnitList)
                        {
                            i.IsLocked = false;
                            lLockedUnitListOld.Add(i);
                        }
                    }
                }

                lLockedUnitList.Clear();

                var keys = new List<Keys>();
                for (var i = 0; i < gMainInfo.Group[iGroup].Units.Count; i++)
                {
                    var isLocked = false;
                    

                    var tmpUnit = gMainInfo.Group[iGroup].Units[i];
                    if (lLockedUnitListOld.Count > 0 && lLockedUnitListOld.Count - 1 >= i)
                        lLockedUnitList.Add(lLockedUnitListOld[i]);

                    else
                        lLockedUnitList.Add(new UnitLock(tmpUnit, false));
                    if (tmpUnit.IsUnderConstruction)
                        continue;

                    

                    /* Check if it's a CC/ OC/ Planetary */
                    if (tmpUnit.Id == PredefinedTypes.UnitId.TbOrbitalGround ||
                        tmpUnit.Id == PredefinedTypes.UnitId.TbPlanetary ||
                        tmpUnit.Id == PredefinedTypes.UnitId.TbCcGround)
                    {
                        /* Check if there's a CC able to upgrade to an OC */
                        if (tmpUnit.Id == PredefinedTypes.UnitId.TbCcGround)
                        {
                            if (tmpUnit.RandomFlag == 8)
                                continue;

                            /* Make OC */
                            if (tmpLocPlayer.Minerals > 150 &&
                                _hMainhandler.PSettings.WorkerAutomationAutoupgradeToOc &&
                                (HelpFunctions.CountUnitTypePerPlayer(gMainInfo.Unit, PredefinedTypes.UnitId.TbRaxAir, tmpLocPlayer.Localplayer) > 0 ||
                                HelpFunctions.CountUnitTypePerPlayer(gMainInfo.Unit, PredefinedTypes.UnitId.TbBarracksGround, tmpLocPlayer.Localplayer) > 0))
                            {
                                if (gMainInfo.Group[iGroup].Units[0].Id == PredefinedTypes.UnitId.TbOrbitalAir ||
                                    gMainInfo.Group[iGroup].Units[0].Id == PredefinedTypes.UnitId.TbOrbitalGround)
                                {
                                    keys.Add(Keys.Tab);
                                }

                                if (tmpUnit.ProdNumberOfQueuedUnits <= 0)
                                    {
                                        if (lLockedUnitListOld.Count > 0 && !lLockedUnitListOld[i].IsLocked)
                                        {
                                            keys.Add(_hMainhandler.PSettings.WorkerAutomationOrbitalKey);
                                        }

                                        isLocked = true;
                                    }
                                }


                            

                            else
                            {
                                if (tmpUnit.ProdNumberOfQueuedUnits <= 1)
                                {
                                    

                                    if (tmpUnit.ProdProcess[0] >
                                        _hMainhandler.PSettings.WorkerAutomationStartNextWorkerAt ||
                                        tmpUnit.ProdProcess[0] <= 0 ||
                                        float.IsNaN(tmpUnit.ProdProcess[0]))
                                    {
                                        if (lLockedUnitListOld.Count > 0 && !lLockedUnitListOld[i].IsLocked)
                                        {
                                            keys.Add(_hMainhandler.PSettings.WorkerAutomationScvKey);
                                            Debug.WriteLine("[" + DateTime.Now + "." + DateTime.Now.Millisecond +
                                                            "] - Added Key to build SCV (" + _iIteration + ")");
                                            
                                        }
                                        isLocked = true;
                                    }


                                }
                            }
                        }

                        else if (tmpUnit.Id == PredefinedTypes.UnitId.TbPlanetary)
                        {
                            if (tmpUnit.ProdNumberOfQueuedUnits <= 1)
                            {
                                if (tmpUnit.ProdProcess[0] > _hMainhandler.PSettings.WorkerAutomationStartNextWorkerAt ||
                                    tmpUnit.ProdProcess[0] <= 0 ||
                                    float.IsNaN(tmpUnit.ProdProcess[0]))
                                {
                                    if (!lLockedUnitListOld[i].IsLocked)
                                    {
                                        keys.Add(_hMainhandler.PSettings.WorkerAutomationScvKey);
                                    }

                                    isLocked = true;
                                }

                            }
                        }

                        else
                        {
                            if (tmpUnit.ProdNumberOfQueuedUnits <= 1)
                            {
                                if (tmpUnit.ProdProcess[0] > _hMainhandler.PSettings.WorkerAutomationStartNextWorkerAt ||
                                    tmpUnit.ProdProcess[0] <= 0 ||
                                    float.IsNaN(tmpUnit.ProdProcess[0]))
                                {
                                    /*
                                        if (!lLockedUnitListOld[i].IsLocked)
                                        {
                                            keys.Add(_hMainhandler.PSettings.WorkerAutomationScvKey);
                                        }
                                        isLocked = true;
                                    */
                                    keys.Add(_hMainhandler.PSettings.WorkerAutomationScvKey);
                                }

                            }
                        }
                    }

                    else if (tmpUnit.Id == PredefinedTypes.UnitId.PbNexus)
                    {
                        if (tmpUnit.ProdNumberOfQueuedUnits <= 1)
                        {
                            if (tmpUnit.ProdProcess[0] > 85 ||
                                tmpUnit.ProdProcess[0] <= 0 ||
                                float.IsNaN(tmpUnit.ProdProcess[0]))
                            {
                                if (!lLockedUnitListOld[i].IsLocked)
                                {
                                    keys.Add(_hMainhandler.PSettings.WorkerAutomationProbeKey);
                                }
                                isLocked = true;
                            }

                        }
                    }

                    lLockedUnitList[i].IsLocked = isLocked;
                }

                if (keys.Count == 0)
                    continue;

                /* Check if there are enough buildings to make a call */
                if (tmpLocPlayer.PlayerRace.Equals(PredefinedTypes.PlayerRace.Terran))
                {
                    
                }

                else if (tmpLocPlayer.PlayerRace.Equals(PredefinedTypes.PlayerRace.Protoss))
                {


                    if (keys.Count > 0 && keys.Count <
                        (HelpFunctions.CountUnitTypePerPlayer(gMainInfo.Group[iGroup].Units,
                            PredefinedTypes.UnitId.PbNexus, tmpLocPlayer.Localplayer)/2))
                    {
                        continue;
                    }
                }


                /* Save Old selection */
                Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, Keys.ControlKey, _hMainhandler.PSettings.WorkerAutomationBackupGroup);

                /* Press ESC to kill stop current actions */
                //if (!bSurpressEscapeKeyPress)
                //    Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, Keys.Escape);

                /* Release Shift/ Control */
                Simulation.Keyboard.PressKey(pSc2.MainWindowHandle, InteropCalls.WMessages.Keyup, Keys.ControlKey, Keys.ShiftKey, Keys.Alt);

                /* Select CC/ OC/ PF [3] */
                Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, _hMainhandler.PSettings.WorkerAutomationMainbuildingGroup);

                /* Build SCV */
                for (var i = 0; i < keys.Count; i++)
                {
                    Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, keys[i]);
                }



                /* Select old selection */
                Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, _hMainhandler.PSettings.WorkerAutomationBackupGroup);

                #region Back up old Units of that group 

                

                #endregion

                
                Thread.Sleep(500);
            }
        }

        class LKeys
        {
            public LKeys(Keys key, Int32 times)
            {
                Key = key;
                Times = times;
            }

            private Keys Key { get; set; }
            private Int32 Times { get; set; }
        }

        private void TestingWorker()
        {

            _hMainhandler.GInformation.CAccessUnitCommands = true;
            _hMainhandler.GInformation.CAccessSelection = true;
            _hMainhandler.GInformation.CAccessGroups = true;
            while (true)
            {
                Thread.Sleep(1);

                
                var ginfo = _hMainhandler.GInformation;
                var pSc2 = _hMainhandler.PSc2Process;

                
                /* Check if the localplayer is in the game */
                if (ginfo.Player.LocalplayerIndex >= 16)
                    continue;

                /* If supply is okay */
                var tmpLocPlayer = ginfo.Player[ginfo.Player.LocalplayerIndex];
                if (tmpLocPlayer.SupplyMin >= tmpLocPlayer.SupplyMax ||
                    tmpLocPlayer.SupplyMin >= 200)
                    continue;

                /* Check if you can use an Orbital */
                bool bScvRequired = false;
                foreach (PredefinedTypes.Unit t in ginfo.Unit)
                {
                    if (t.Owner != ginfo.Player.LocalplayerIndex)
                        continue;

                    if (t.Id == PredefinedTypes.UnitId.TbOrbitalGround &&
                        !t.IsUnderConstruction)
                    {
                        if (t.ProdNumberOfQueuedUnits <= 0)
                            bScvRequired = true;
                    }

                    if (t.Id == PredefinedTypes.UnitId.TbCcGround &&
                        !t.IsUnderConstruction)
                    {
                        if (t.ProdNumberOfQueuedUnits <= 0)
                            bScvRequired = true;
                    }

                    if (t.Id == PredefinedTypes.UnitId.TbPlanetary &&
                        !t.IsUnderConstruction)
                    {
                        if (t.ProdNumberOfQueuedUnits <= 0)
                            bScvRequired = true;
                    }
                }

                if (!bScvRequired)
                    continue;

                if (tmpLocPlayer.Minerals < 50)
                    continue;

                if (tmpLocPlayer.Worker >= 80)
                    continue;

                if (HelpFunctions.HotkeysPressed(Keys.ShiftKey))
                {
                    Thread.Sleep(500);
                    continue;
                }

                bool bThrowRequired = false;
                bool bSurpressEscape = false;
                for (var i = 0; i < ginfo.Selection.Count; i++)
                {
                    if (ginfo.Selection[i].Unit.Id == PredefinedTypes.UnitId.TuScv)
                    {
                        bThrowRequired = true;
                    }

                    else if (ginfo.Selection[i].Unit.Id == PredefinedTypes.UnitId.TbOrbitalGround ||
                        ginfo.Selection[i].Unit.Id == PredefinedTypes.UnitId.TbCcGround ||
                        ginfo.Selection[i].Unit.Id == PredefinedTypes.UnitId.TbPlanetary)
                    {
                        bSurpressEscape = true;
                    }
                }

                


                var iTimesToPress = 0;
                if (ginfo.Group.Count >= 2)
                {
                    for (var i = 0; i < ginfo.Group[2].Units.Count; i++)
                    {
                        var tmpUnit = ginfo.Group[2].Units[i];
                        if (tmpUnit.Id == PredefinedTypes.UnitId.TbOrbitalGround ||
                            tmpUnit.Id == PredefinedTypes.UnitId.TbCcGround ||
                            tmpUnit.Id == PredefinedTypes.UnitId.TbPlanetary)
                        {
                            if (tmpUnit.Id == PredefinedTypes.UnitId.TbCcGround)
                            {
                                if (tmpUnit.RandomFlag == 8)
                                {
                                    Thread.Sleep(500);
                                    bThrowRequired = true;
                                    break;
                                }

                                /* Check if there is money for an Orbital and surpress SCV Production */
                                if (tmpLocPlayer.Minerals >= 150)
                                {
                                    /* Make Orbital */
                                    /* Save Old selection */
                                    Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, Keys.ControlKey, Keys.D0);

                                    /* Press ESC to kill stop current actions */
                                    if (!bSurpressEscape)
                                        Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, Keys.Escape);

                                    /* Release Shift/ Control */
                                    Simulation.Keyboard.PressKey(pSc2.MainWindowHandle, InteropCalls.WMessages.Keyup, Keys.ControlKey, Keys.ShiftKey, Keys.Alt);

                                    /* Select CC/ OC/ PF [3] */
                                    Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, Keys.D3);

                                    /* Build Orbital */
                                    Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, Keys.B);
                                    

                                    /* Select old selection */
                                    Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, Keys.D0);

                                    break;
                                }
                            }

                            else if (tmpUnit.ProdNumberOfQueuedUnits == 0)
                            {
                                if (tmpLocPlayer.Worker + iTimesToPress <= 79)
                                    iTimesToPress += 1;
                            }
                        }
                    }
                }

                if (bThrowRequired)
                    continue;

                /* Save Old selection */
                Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, Keys.ControlKey, Keys.D0);

                /* Press ESC to kill stop current actions */
                if (!bSurpressEscape)
                    Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, Keys.Escape);

                /* Release Shift/ Control */
                Simulation.Keyboard.PressKey(pSc2.MainWindowHandle, InteropCalls.WMessages.Keyup, Keys.ControlKey, Keys.ShiftKey, Keys.Alt);            

                /* Select CC/ OC/ PF [3] */
                Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, Keys.D3);

                /* Build SCV */
                for (var i = 0; i < iTimesToPress; i++)
                {
                    Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, Keys.S);
                }

                /* Select old selection */
                Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, Keys.D0);

                /* Let the thread sleep */
                Thread.Sleep(500);

            }
        }

        private static bool UnitAvailable(IEnumerable<PredefinedTypes.Unit> units, PredefinedTypes.PList players, PredefinedTypes.UnitId targetUnit, int amount)
        {
            int iAmount = 0;
            foreach (var u in units)
            {
                if (u.Owner != players.LocalplayerIndex)
                    continue;

                if (u.Id.Equals(targetUnit))
                    iAmount += 1;
            }

            if (iAmount >= amount)
                return true;

            return false;
        }
        
        private Point _ptLeftClickPoint = new Point(0, 0);
        private Point _ptLeftClickPoint2 = new Point(0, 0);
        private void CatchLeftClick()
        {
            var bIsPressed = false;
            while (true)
            {
                if (HelpFunctions.HotkeysPressed(Keys.LButton))
                {
                    if (!bIsPressed)
                    {
                        _ptLeftClickPoint = Cursor.Position;
                        bIsPressed = true;
                    }

                    continue;
                }

                bIsPressed = false;

                Thread.Sleep(10);
            }
        }

        private void Production()
        {
            var ah = new AutomationHelper(_hMainhandler.PSc2Process.MainWindowHandle, PredefinedTypes.AutomationMethods.SendMessage);
            var bLockSimulation = false;
            var bRestoreMouseWindow = false;
            var sw = new Stopwatch();
            var gameInfo = new GameInfo(false);

            while (CoreAutomationStatus)
            {
                

                Thread.Sleep(CoreSleeptime);


                sw.Reset();
                sw.Start();


                gameInfo.DoMassiveScan();


                //if (HelpFunctions.HotkeysPressed(Keys.Escape, Keys.F1))
                //    CoreAutomationStatus = false;
                

                /* Check if the group (4) needs to be called */
                var bNeedToCall = false;
                var iTimesToBuild = 0;
                var lUnits = gameInfo.Group[4].Units;



                for (var i = 0; i < lUnits.Count; i++)
                {
                    if (!lUnits[i].IsStructure)
                        continue;

                    if (lUnits[i].IsUnderConstruction)
                        continue;

                    //if (!bNeedToCall)
                    //{
                    //    if (lUnits[i].ProdReactorAttached[0])
                    //    {
                    //        if (lUnits[i].ProdNumberOfQueuedUnits < 2)
                    //        {
                    //            bNeedToCall = true;
                    //        }
                    //    }

                    //    else
                    //    {
                    //        if (lUnits[i].ProdNumberOfQueuedUnits < 1)
                    //        {
                    //            bNeedToCall = true;
                    //        }
                    //    }
                    //}

                    if (lUnits[i].ProdNumberOfQueuedUnits < 1)
                    {
                        iTimesToBuild += 1;
                        bNeedToCall = true;
                    }

                    
                }

                    bLockSimulation = false;

                if (bNeedToCall)
                {
                    gameInfo.DoMassiveScan();
                    lUnits = gameInfo.Group[4].Units;
                    for (var i = 0; i < lUnits.Count; i++)
                    {
                        if (!lUnits[i].IsStructure)
                            continue;

                        if (lUnits[i].IsUnderConstruction)
                            continue;

                        if (lUnits[i].ProdNumberOfQueuedUnits > 0)
                            bLockSimulation = true;
                    }

                    if (bLockSimulation)
                        continue;

                    /* Check if Leftclick is still pressed */
                    bRestoreMouseWindow = HelpFunctions.HotkeysPressed(Keys.LButton);

                    /* Cancel all commands */
                    ah.PerformCompleteKeypress(Keys.Escape);

                    /* Assign current mouse- position */
                    _ptLeftClickPoint2 = Cursor.Position;


                    /* Store current selection */
                    ah.AssignGroup(PredefinedTypes.GroupSelection.Group7);

                    /* Select Group (4) */
                    ah.SelectGroup(PredefinedTypes.GroupSelection.Group4);

                    /* Build Marines */
                   // for (var i = 0; i < iTimesToBuild; i++ )
                        ah.PerformCompleteKeypress(Keys.A);


                    /* Restore selection */
                    ah.SelectGroup(PredefinedTypes.GroupSelection.Group7);

                    /* Restore dropwindow */
                    if (bRestoreMouseWindow)
                    {
                        bRestoreMouseWindow = false;

                        InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                                 (uint) InteropCalls.WMessages.Lbuttondown,
                                                 IntPtr.Zero,
                                                 (IntPtr) Simulation.Mouse.MakeLParam(_ptLeftClickPoint));

                        /* Make a little "mousemove" */
                        Cursor.Position = _ptLeftClickPoint2;

                        //InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                        //                         (uint) InteropCalls.WMessages.Lbuttondown,
                        //                         IntPtr.Zero,
                        //                         (IntPtr) Simulation.Mouse.MakeLParam(ptLeftClickPoint2));
                    }
                }

                sw.Stop();
                Debug.WriteLine("Time to execute code: " + 1000000 * sw.ElapsedTicks / Stopwatch.Frequency + " µs");
            }

            
        }

        private void Inject()
        {
            while (CoreAutomationStatus)
            {
                if (HelpFunctions.HotkeysPressed(Keys.ControlKey, Keys.Menu, Keys.ControlKey))
                {
                    var iTimesAvailable = HelpFunctions.CountUnitTypePerPlayer(_hMainhandler.GInformation.Unit,
                                                                                   PredefinedTypes.UnitId.ZbHatchery,
                                                                                   _hMainhandler.GInformation.Player[0]
                                                                                       .Localplayer);

                    Point ptOldCursor = Cursor.Position;
                    SetScreenSnapshot(Keys.F5);



                    Thread.Sleep(100);

                    /* Release Control key */
                    InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                             (uint)InteropCalls.WMessages.Keyup, (IntPtr)Keys.ControlKey,
                                             IntPtr.Zero);

                    Thread.Sleep(100);


                    

                    for (var i = 0; i < iTimesAvailable; i++)
                    {
                        if (_hMainhandler.GInformation.Selection[0].Unit.Id !=
                            PredefinedTypes.UnitId.ZuQueen)
                        {
                            /* Select Group */
                            InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                                     (uint)InteropCalls.WMessages.Keydown, (IntPtr)Keys.D0,
                                                     IntPtr.Zero);
                            Thread.Sleep(1);
                            InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                                     (uint)InteropCalls.WMessages.Keyup, (IntPtr)Keys.D0,
                                                     IntPtr.Zero);
                        }


                        /* Press v */
                        InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                                 (uint)InteropCalls.WMessages.Keydown, (IntPtr)Keys.V,
                                                 IntPtr.Zero);
                        Thread.Sleep(1);
                        InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                                 (uint)InteropCalls.WMessages.Keyup, (IntPtr)Keys.V,
                                                 IntPtr.Zero);




                        /* Send Backspace */
                        InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                                 (uint)InteropCalls.WMessages.Keydown, (IntPtr)Keys.Back,
                                                 IntPtr.Zero);
                        Thread.Sleep(1);
                        InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                                 (uint)InteropCalls.WMessages.Keyup, (IntPtr)Keys.Back,
                                                 IntPtr.Zero);




                        /* Drop command */
                        var iPosX = Screen.PrimaryScreen.Bounds.Width / 2;
                        var iPosY = Screen.PrimaryScreen.Bounds.Height / 2 - 130;

                        Cursor.Position = new Point(iPosX, iPosY);


                        InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                                 (uint)InteropCalls.WMessages.Lbuttondown,
                                                 IntPtr.Zero,
                                                 (IntPtr)Simulation.Mouse.MakeLParam(new Point(iPosX, iPosY)));
                        Thread.Sleep(1);
                        InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                                 (uint)InteropCalls.WMessages.Lbuttonup,
                                                 IntPtr.Zero,
                                                 (IntPtr)Simulation.Mouse.MakeLParam(new Point(iPosX, iPosY)));
                   
                    }

                    Simulation.Keyboard.Keyboard_SimulateKey(_hMainhandler.PSc2Process.MainWindowHandle,
                                                        Keys.Escape);

                    Cursor.Position = ptOldCursor;
                    GetScreenSnapshot(Keys.F5);
                }


               
               Thread.Sleep(CoreSleeptime);
            }
            /* Queens already selected */

        }

        private static void MouseClick(int x, int y, IntPtr handle) //handle for the browser window
        {
            var lParam = (IntPtr)((y << 16) | x); // The coordinates
            var wParam = IntPtr.Zero; // Additional parameters for the click (e.g. Ctrl)

            const uint downCode = 0x201; // Left click down code
            const uint upCode = 0x202; // Left click up code

            InteropCalls.SendMessage(handle, downCode, wParam, lParam); // Mouse button down
            InteropCalls.SendMessage(handle, upCode, wParam, lParam); // Mouse button up
        }

        private void AutomationWorker()
        {
            while (CoreAutomationStatus)
            {
                if ((DateTime.Now - _dtTimeStamp).Milliseconds >= 100)
                {
                    if (NeededToBuild())
                    {
                        ProduceWorkers();
                    }

                    _dtTimeStamp = DateTime.Now;

                    Debug.WriteLine(_bNeedToBuild);
                }


                Thread.Sleep(CoreSleeptime);
            }
        }

        private void ProduceWorkers()
        {
            CheckIfKeyIfPressed(Keys.ControlKey);

            /* Check if it's needed to produce a worker */
                _bNeedToBuild = false;


                /* Store current selection */
                InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                         (uint)InteropCalls.WMessages.Keydown, (IntPtr)Keys.ControlKey, IntPtr.Zero);
                InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                         (uint)InteropCalls.WMessages.Keydown, (IntPtr)Keys.D7, IntPtr.Zero);

                //Thread.Sleep(10);

                InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                         (uint)InteropCalls.WMessages.Keyup, (IntPtr)Keys.D7, IntPtr.Zero);
                InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                         (uint)InteropCalls.WMessages.Keyup, (IntPtr)Keys.ControlKey, IntPtr.Zero);

               // Thread.Sleep(10);

                //keys.Add(Keys.Control);
                //keys.Add(Keys.D7);
                //Simulation.Keyboard_SimulateKeys(_hMainhandler.PSc2Process.MainWindowHandle, keys);
                //keys.Clear();

                /* Select Mainbuilding */
                Simulation.Keyboard.Keyboard_SimulateKey(_hMainhandler.PSc2Process.MainWindowHandle, Keys.D3);

                /* Produce worker */
                //Simulation.Keyboard_SimulateKey(_hMainhandler.PSc2Process.MainWindowHandle, Keys.E);

                InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                         (uint) InteropCalls.WMessages.Keydown, (IntPtr) Keys.E, IntPtr.Zero);
                //Thread.Sleep(10);
                InteropCalls.SendMessage(_hMainhandler.PSc2Process.MainWindowHandle,
                                         (uint) InteropCalls.WMessages.Keyup, (IntPtr) Keys.E, IntPtr.Zero);


            /* Select Army again */
                Simulation.Keyboard.Keyboard_SimulateKey(_hMainhandler.PSc2Process.MainWindowHandle, Keys.D7);
            
        }

        private Boolean NeededToBuild()
        {
            for (var i = 0; i < _hMainhandler.GInformation.Unit.Count; i++)
            {
                if (_hMainhandler.GInformation.Unit[i].Id.Equals(PredefinedTypes.UnitId.PbNexus))
                {
                    for (var j = 0; j < _hMainhandler.GInformation.Player.Count; j++ )
                    {
                        if (_hMainhandler.GInformation.Player[j].IsLocalplayer)
                        {
                            if (_hMainhandler.GInformation.Unit[i].ProdNumberOfQueuedUnits <= 0)
                                return true;
                        }
                    }
                }
            }

            return false;
        }

        private void CheckIfKeyIfPressed(Keys key)
        {
            TryAgain:

            if (InteropCalls.GetAsyncKeyState(key) == -32767)
            {
                Thread.Sleep(10);
                goto TryAgain;
            }

        }

        private void SetScreenSnapshot(Keys snapshotSpot)
        {
            Simulation.Keyboard.PressKeysDownAndUpSync(_hMainhandler.PSc2Process.MainWindowHandle,
                Keys.ControlKey, snapshotSpot);
        }

        private void GetScreenSnapshot(Keys snapshotSpot)
        {
            Simulation.Keyboard.Keyboard_SimulateKey(_hMainhandler.PSc2Process.MainWindowHandle,
                snapshotSpot);
        }

        public Boolean CoreAutomationStatus { get; set; }
        public Int32 CoreSleeptime { get; set; }
    }

    public class UnitLock
    {
        public UnitLock()
        {
            
        }

        public UnitLock(PredefinedTypes.Unit unit, Boolean isLocked)
        {
            Unit = unit;
            IsLocked = isLocked;
            Date = DateTime.Now;
        }

        public Boolean IsLocked { get; set; }
        public PredefinedTypes.Unit Unit { get; set; }
        public DateTime Date { get; set; }
    }
}
