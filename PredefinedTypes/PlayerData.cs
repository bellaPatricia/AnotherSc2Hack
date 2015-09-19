using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace PredefinedTypes
{
    [Serializable]
    [DebuggerDisplay("Name: {Name}, Team: {Team}, Minerals: {Minerals}")]
    public class Player
    {
        public static Player LocalPlayer { get; set; }
        public static int ClassObjectCount { get; private set; }

        public int CameraPositionX { get; set; }
        public int CameraPositionY { get; set; }
        public int CameraDistance { get; set; }
        public int CameraRotation { get; set; }
        public int CameraAngle { get; set; }
        public PlayerStatus Status { get; set; }
        public PlayerType Type { get; set; }
        public PlayerDifficulty Difficulty { get; set; }
        public int NameLength { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public string ClanTag { get; set; }
        public int Apm { get; set; }
        public int Epm { get; set; }
        public int ApmAverage { get; set; }
        public int EpmAverage { get; set; }
        public int Worker { get; set; }
        public int UnitsInProduction { get; set; }
        public int SupplyMinRaw { get; set; }
        public int SupplyMaxRaw { get; set; }
        public int SupplyMin { get; set; }
        public int SupplyMax { get; set; }
        public int CurrentBuildings { get; set; }
        public string AccountId { get; set; }
        public int ArmySupply { get; set; }
        public int Minerals { get; set; }
        public int Gas { get; set; }
        public int MineralsIncome { get; set; }
        public int GasIncome { get; set; }
        public int MineralsArmy { get; set; }
        public int GasArmy { get; set; }
        public int Team { get; set; }
        public int Index { get; set; }
        public PlayerRace PlayerRace { get; set; }
        public List<Unit> Units { get; set; }

        public Player()
        {
            Units = new List<Unit>();
            ClassObjectCount += 1;
        }

        ~Player()
        {
            ClassObjectCount -= 1;
        }
    };

    public enum PlayerStatus
    {
        Playing = 0,
        Won = 1,
        Lost = 2,
        Tied = 3,
        NotDefined = 42,
    };

    public enum PlayerColor
    {
        White = 0,
        Red = 1,
        Blue = 2,
        Teal = 3,
        Purple = 4,
        Yellow = 5,
        Orange = 6,
        Green = 7,
        LightPink = 8,
        Violet = 9,
        LightGray = 10,
        DarkGreen = 11,
        Brown = 12,
        LightGreen = 13,
        DarkGray = 14,
        Pink = 15,
    };

    public enum PlayerType
    {
        Human = 1,
        Ai = 2,
        Neutral = 3,
        Hostile = 4,
        Referee = 5,
        Observer = 6,
        NotDefined = 7
    };

    /* We read the first byte and check out what letter it is
         * so we can cast them directly! */

    public enum PlayerRace
    {
        Terran = 84,
        Protoss = 80,
        Zerg = 90,
        Other = 0
    };

    /* Those values are correct ones so that casting is possible */

    public enum PlayerDifficulty
    {
        VeryEasy = 1,
        Easy = 2,
        Medium = 3,
        Hard = 4,
        Harder = 5,
        VeryHard = 6,
        Elite = 7,
        CheaterVision = 8,
        CheaterResources = 9,
        CheaterInsane = 10,
    };
}
