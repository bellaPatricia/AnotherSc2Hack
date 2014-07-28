using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PredefinedTypes = Predefined.PredefinedData;
using PluginInterface;
using System.Threading;
using System.Runtime.InteropServices;

namespace WorkerProduction
{
    public class AnotherSc2HackPlugin : IPlugins
    {
        private Production _pData = null;

        public string GetPluginDescription()
        {
            return "Makes you some neat workers automatically!";
        }

        public string GetPluginName()
        {
            return "WorkerAutomation";
        }

        public bool GetRequiresGameinfo()
        {
            return true;
        }

        public bool GetRequiresGroups()
        {
            return true;
        }

        public bool GetRequiresMap()
        {
            return true;
        }

        public bool GetRequiresPlayer()
        {
            return true;
        }

        public bool GetRequiresSelection()
        {
            return true;
        }

        public bool GetRequiresUnit()
        {
            return true;
        }

        public void SetGameinfo(PredefinedTypes.Gameinformation gameinfo)
        {
            if (_pData != null)
                _pData.Gameinfo = gameinfo;
        }

        public void SetGroups(List<PredefinedTypes.Groups> groups)
        {
            if (_pData != null)
                _pData.Groups = groups;
        }

        public void SetMap(PredefinedTypes.Map map)
        {
            if (_pData != null)
                _pData.Map = map;
        }

        public void SetPlayers(PredefinedTypes.PList players)
        {
            if (_pData != null)
                _pData.Players = players;
        }

        public void SetSelection(PredefinedTypes.LSelection selection)
        {
            if (_pData != null)
                _pData.Selections = selection;
        }

        public void SetUnits(List<PredefinedTypes.Unit> units)
        {
            if (_pData != null)
                _pData.Unit = units;
        }

        public void StartPlugin()
        {
            _pData = new Production();
            _pData.Start();
        }

        public void StopPlugin()
        {
            _pData.Stop();
            _pData = null;
        }
    }

    public class Production
    {
        public List<PredefinedTypes.Unit> Unit { get; set; }
        public PredefinedTypes.PList Players { get; set; }
        public PredefinedTypes.Gameinformation Gameinfo { get; set; }
        public List<PredefinedTypes.Groups> Groups { get; set; }
        public PredefinedTypes.LSelection Selections { get; set; }
        public PredefinedTypes.Map Map { get; set; }

        private Boolean _bMainThreadState = false;

        public Production()
        {
            
        }

        public void Start()
        {
            _bMainThreadState = true;
            new Thread(Worker).Start();
        }

        public void Stop()
        {
            _bMainThreadState = false;
        }

        private void Worker()
        {
            /* Setting- Options */
            var kMainBuilding = Keys.D3;
            var kScvKey = Keys.S;
            var kBackupGroup = Keys.D9;
            var fBuildNextScvAt = 95f;
            var pSc2 = Process.GetProcessesByName("SC2")[0];
            var uOldUnits = new List<PredefinedTypes.Unit>();

            while (_bMainThreadState)
            {
                Thread.Sleep(50);

                if (!Gameinfo.IsIngame)
                    continue;

                if (Players == null ||
                    Players.Count <= 0)
                    continue;

                if (Unit == null ||
                    Unit.Count <= 0)
                    continue;

                if (Map.PlayableHeight <= 0)
                    continue;

                if (Groups == null ||
                    Groups.Count <= 0)
                    continue;

                if (Selections == null ||
                    Selections.Count <= 0)
                    continue;

                var keysToBePressed = new List<Keys>();

                var iGroup = GetGroupNumber(kMainBuilding);
                if (iGroup == -1)
                    continue;

                for (var i = 0; i < Groups[iGroup].Units.Count; i++)
                {
                    var tmpUnit = Groups[iGroup].Units[i];

                    if (tmpUnit.Id.Equals(PredefinedTypes.UnitId.TbCcGround))
                    {
                        if (uOldUnits.Count > 0)
                            CommandCenter(ref keysToBePressed, tmpUnit, uOldUnits[i], kScvKey, fBuildNextScvAt);

                        else
                            CommandCenter(ref keysToBePressed, tmpUnit, tmpUnit, kScvKey, fBuildNextScvAt);
                    }
                }

                if (keysToBePressed.Count <= 0)
                    continue;

                /* Save Old selection */
                PressKeysDownAndUpSync(pSc2.MainWindowHandle, Keys.ControlKey, kBackupGroup);

                /* Press ESC to kill stop current actions */
                //if (!bSurpressEscapeKeyPress)
                //    Simulation.Keyboard.PressKeysDownAndUpSync(pSc2.MainWindowHandle, Keys.Escape);

                /* Release Shift/ Control */
                PressKey(pSc2.MainWindowHandle, WMessages.Keyup, Keys.ControlKey, Keys.ShiftKey, Keys.Alt);

                /* Select CC/ OC/ PF [3] */
                PressKeysDownAndUpSync(pSc2.MainWindowHandle, kMainBuilding);

                /* Build SCV */
                for (var i = 0; i < keysToBePressed.Count; i++)
                {
                    PressKeysDownAndUpSync(pSc2.MainWindowHandle, keysToBePressed[i]);
                }

                /* Select old selection */
                PressKeysDownAndUpSync(pSc2.MainWindowHandle, kBackupGroup);

                Thread.Sleep(500);

                uOldUnits.Clear();
                for (var i = 0; i < Groups[iGroup].Units.Count; i++)
                {
                    uOldUnits.Add(Groups[iGroup].Units[i]);
                }
            }
        }

        private void CommandCenter(ref List<Keys> keys, PredefinedTypes.Unit unit, PredefinedTypes.Unit oldUnit, Keys scvKey, float buildNextScvAt)
        {
            if (unit.ProdNumberOfQueuedUnits <= 0)
            {
                keys.Add(scvKey);
            }

            else if (unit.ProdNumberOfQueuedUnits == 1)
            {
                if (unit.ProdProcess[0] >= buildNextScvAt)
                    keys.Add(scvKey);
            }
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

        /// <summary>
        /// This will press (and hold) an undefined amount of keys.
        /// The keypress will begin with the first item and end with the last item.
        /// The keydown will begin with the first item and end with the last item.
        /// </summary>
        /// <param name="handle">The target handle</param>
        /// <param name="key">The key you wish to use</param>
        public static void PressKeysDownAndUpSync(IntPtr handle, params Keys[] key)
        {
            foreach (var t in key)
            {
                SendMessage(handle, (uint)WMessages.Keydown, (IntPtr)t,
                    IntPtr.Zero);
            }


            foreach (var t in key)
            {
                SendMessage(handle, (uint)WMessages.Keyup, (IntPtr)t,
                    IntPtr.Zero);
            }
        }

        public static void PressKey(IntPtr handle, WMessages msg, params Keys[] keys)
        {
            foreach (var k in keys)
            {
                SendMessage(handle, (uint)msg, (IntPtr)k,
                    IntPtr.Zero);
            }
        }

        /* SendMessage */
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

        [Flags]
        public enum WMessages
        {

            Keyfirst = 0x100,
            Keydown = 0x100,
            Keyup = 0x101,
            Char = 0x102,
            Deadchar = 0x103,
            Syskeydown = 0x104,
            Syskeyup = 0x105,
            Syschar = 0x106,
            Sysdeadchar = 0x107,
            Keylast = 0x108,


            Mousefirst = 0x200,
            Mousemove = 0x200,
            Lbuttondown = 0x201,
            Lbuttonup = 0x202,
            Lbuttondblclk = 0x203,
            Rbuttondown = 0x204,
            Rbuttonup = 0x205,
            Rbuttondblclk = 0x206,
            Mbuttondown = 0x207,
            Mbuttonup = 0x208,
            Mbuttondblclk = 0x209,
            Mousewheel = 0x20A,
            Mousehwheel = 0x20E,
        }
    }
}
