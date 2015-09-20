using System.Diagnostics;

namespace AnotherSc2Hack.Classes.DataStructures.Offsets
{
    public static class Version211236657
    {
        public static void MapOffsets(Process starcraft)
        {
            Player.Size = 0xE18;
            Player.Struct = starcraft.MainModule.BaseAddress.ToInt32() + 0x362BF90;
            Player.CameraX = 0x8;
            Player.CameraX = 0xC;
            Player.CameraDistance = 0x10;
            Player.CameraAngle = 0x14;
            Player.CameraRotation = 0x18;
            Player.Team = 0x1C;
            Player.Type = 0x1D;
            Player.Status = 0x1E;
            Player.Difficulty = 0x20;
            Player.Name = 0x64;
            Player.NameLength = 0xB4;
            Player.ClantagLength = 0x108;
            Player.Clantag = 0x114;
            Player.ColorIndex = 0x1B8;
            Player.AccountId = 0x210;
            Player.ApmCurrent = 0x5F0;
            Player.ApmAverage = 0x5F8;
            Player.EpmCurrent = 0x638;
            Player.EpmAverage = 0x638;
            Player.UnitsInProduction = 0x6A0;
            Player.WorkerCount = 0x7E0;
            Player.SupplyLimit = 0x8A0;
            Player.SupplyCurrent = 0x8B8;
            Player.MineralsCurrent = 0x8F8;
            Player.VespeneCurrent = 0x900;
            Player.MineralsIncome = 0x978;
            Player.VespeneIncome = 0x980;
            Player.MineralsArmyValue = 0xC60;
            Player.VespeneArmyValue = 0xC88;
        }
    }
}
