using System;
using System.Drawing;
using System.Text;

namespace AnotherSc2Hack.Classes.BackEnds.Gameinfo
{
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

    public class Player
    {
        private readonly Int32 _iPlayerIndex;
        private readonly Offsets _oOffsets = new Offsets();

        public Player(Int32 iPlayerIndex)
        {
            _iPlayerIndex = iPlayerIndex;
        }

        public void SetProperties(ref byte[] buffer)
        {
            CameraPositionX = BitConverter.ToInt32(buffer,
                                                   _iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.RawPlayerCameraX);
            CameraPositionY = BitConverter.ToInt32(buffer,
                                                   _iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.RawPlayerCameraY);
            CameraAngle = BitConverter.ToInt32(buffer,
                                               _iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.RawPlayerCameraAngle);
            CameraRotation = BitConverter.ToInt32(buffer,
                                                  _iPlayerIndex*_oOffsets.PlayerStructSize +
                                                  _oOffsets.RawPlayerCameraRotation);
            CameraDistance = BitConverter.ToInt32(buffer,
                                                  _iPlayerIndex*_oOffsets.PlayerStructSize +
                                                  _oOffsets.RawPlayerCameraDistance);
            Status = (PlayerStatus) buffer[_iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.RawPlayerStatus];
            Type = (PlayerType) buffer[_iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.RawPlayerPlayertype];
            Difficulty =
                (PlayerDifficulty) buffer[_iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.RawPlayerDifficulty];
            NameLenght =
                BitConverter.ToInt32(buffer, _iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.NameLenght) >> 2;
            Name = Encoding.UTF8.GetString(buffer, _iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.RawPlayerName,
                                           NameLenght);
            //TODO: Color;

            ApmAverage = BitConverter.ToInt32(buffer,
                                              _iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.RawPlayerApmAverage);
            ApmCurrent = BitConverter.ToInt32(buffer,
                                              _iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.RawPlayerApmCurrent);
            EpmAverage = BitConverter.ToInt32(buffer,
                                              _iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.RawPlayerEpmAverage);
            EpmCurrent = BitConverter.ToInt32(buffer,
                                              _iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.RawPlayerEpmCurrent);
            ClanTagLenght = BitConverter.ToInt32(buffer,
                                                 _iPlayerIndex*_oOffsets.PlayerStructSize +
                                                 _oOffsets.RawPlayerClanTagLenght) >> 2;
            ClanTag = Encoding.UTF8.GetString(buffer,
                                              _iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.RawPlayerClanTag,
                                              ClanTagLenght);
            HarvesterCount = BitConverter.ToInt32(buffer,
                                                  _iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.RawPlayerWorkers);
            SupplyCurrent = BitConverter.ToInt32(buffer,
                                                 _iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.RawPlayerSupplyMin) >>
                            12;
            SupplyMaximum =
                BitConverter.ToInt32(buffer, _iPlayerIndex*_oOffsets.PlayerStructSize + _oOffsets.SupplyMax) >> 12;

            //ToDo: SupplyLimit




        }

       



        public Int32 CameraPositionX { get; private set; }
        public Int32 CameraPositionY { get; private set; }
        public Int32 CameraDistance { get; private set; }
        public Int32 CameraAngle { get; private set; }
        public Int32 CameraRotation { get; private set; }
        public PlayerStatus Status { get; private set; }
        public PlayerType Type { get; private set; }
        public PlayerDifficulty Difficulty { get; private set; }
        public Int32 NameLenght { get; private set; }
        public String Name { get; private set; }
        public Color Color { get; private set; }
        public Int32 ClanTagLenght { get; private set; }
        public String ClanTag { get; private set; }
        public Int32 ApmAverage { get; private set; }
        public Int32 ApmCurrent { get; private set; }
        public Int32 EpmAverage { get; private set; }
        public Int32 EpmCurrent { get; private set; }
        public Int32 HarvesterCount { get; private set; }
        public Int32 SupplyCurrent { get; private set; }
        public Int32 SupplyMaximum { get; private set; }
        public Int32 SupplyLimit { get; private set; }
        public String AccountId { get; private set; }
        public Int32 ArmySupply { get; private set; }
        public Int32 Minerals { get; private set; }
        public Int32 Vespine { get; private set; }
        public Int32 Terrazine { get; private set; }
        public Int32 CustomResource { get; private set; }
        public Int32 MineralsIncome { get; private set; }
        public Int32 VespineIncome { get; private set; }
        public Int32 TerrazineIncome { get; private set; }
        public Int32 CustomResourceIncome { get; private set; }
        public Int32 MineralsArmysize { get; private set; }
        public Int32 VespineArmysize { get; private set; }
        public Int32 TerrazineArmysize { get; private set; }
        public Int32 CustomResourceArmysize { get; private set; }
        public PlayerRace Race { get; private set; }
        public Boolean IsLocalplayer { get; private set; }
        public Int32 Localplayer { get; private set; }
        public Int32 Team { get; private set; }
    }

    /*public Int32 CameraPositionX;
            public Int32 CameraPositionY;
            public Int32 CameraDistance;
            public Int32 CameraRotation;
            public Int32 CameraAngle;
            public PlayerStatus Status;
            public PlayerType Type;
            public PlayerDifficulty Difficulty;
            public Int32 NameLength;
            public String Name;
            public Color Color;
            public String ClanTag;
            public Int32 Apm;
            public Int32 Epm;
            public Int32 ApmAverage;
            public Int32 EpmAverage;
            public Int32 Worker;
            public Int32 SupplyMinRaw;
            public Int32 SupplyMaxRaw;
            public Int32 SupplyMin;
            public Int32 SupplyMax;
            public Int32 CurrentBuildings;
            public String AccountId;
            public Int32 ArmySupply;
            public Int32 Minerals;
            public Int32 Gas;
            public Int32 MineralsIncome;
            public Int32 GasIncome;
            public Int32 MineralsArmy;
            public Int32 GasArmy;
            public Int32 Team;
            public PlayerRace PlayerRace;
            public Int32 Localplayer;   //Makes no sense to put this into the struct but it makes stuff easier
            public Boolean IsLocalplayer;
            public Int32 ValidSize;
            public LeagueInfo LeagueInfo;*/
}