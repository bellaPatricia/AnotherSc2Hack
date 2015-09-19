using System.Collections.Generic;
using PredefinedTypes;

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

            //Initialize with class
            Mind.Initialize();
            _bInitialized = true;
        }
    }
}
