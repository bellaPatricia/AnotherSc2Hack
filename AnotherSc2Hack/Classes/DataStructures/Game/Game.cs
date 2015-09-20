using System.Collections.Generic;
using System.Diagnostics;
using PredefinedTypes;
using Utilities.Processing;
using _ = Utilities.InfoManager.InfoManager;

namespace AnotherSc2Hack.Classes.DataStructures.Game
{
    public static class Game
    {
        private static bool _bInitialized;

        private static Gameinformation _gameinformation;
        private static List<Player> _player;
        private static List<Unit> _unit;
        private static List<Selection> _selection;
        private static List<Groups> _group;
        private static Map _map;

        public static Gameinformation Gameinformation
        {
            get
            {
                OnAccessCall();
                return _gameinformation;
            }
            set { _gameinformation = value; }
        }

        public static List<Player> Player
        {
            get
            {
                OnAccessCall();
                return _player;
            }
            set { _player = value; }
        }

        public static List<Unit> Unit
        {
            get
            {
                OnAccessCall();
                return _unit;
            }
            set { _unit = value; }
        }

        public static List<Selection> Selection
        {
            get
            {
                OnAccessCall();
                return _selection;
            }
            set { _selection = value; }
        }

        public static List<Groups> Group
        {
            get
            {
                OnAccessCall();
                return _group;
            }
            set { _group = value; }
        }

        public static Map Map
        {
            get
            {
                OnAccessCall();
                return _map;
            }
            set { _map = value; }
        }

        private static void OnAccessCall()
        {
            Initialize();
        }

        private static void Initialize()
        {
            if (_bInitialized)
                return;

            _.Info("Within the Initializing of the Game", _.InfoImportance.VeryImportant);

            //Initialize with class

            Process proc;
            var processFound = Processing.CheckProcess("SC2", out proc);
            if (processFound)
                new Mind(proc);

            _bInitialized = true;
        }

        
    }
}
