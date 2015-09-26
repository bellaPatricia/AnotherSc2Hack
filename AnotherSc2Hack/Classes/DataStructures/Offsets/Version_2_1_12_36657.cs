using System.Diagnostics;

namespace AnotherSc2Hack.Classes.DataStructures.Offsets
{
    public static class Version211236657
    {
        public static void MapOffsets(Process starcraft)
        {
            Player.Size = new OffsetStructure(0xE18, 0);
            Player.Struct = starcraft.MainModule.BaseAddress.ToInt32() + new OffsetStructure(0x362BF90, 0);
            Player.CameraX = new OffsetStructure(0x8, 4);
            Player.CameraX = new OffsetStructure(0xC, 4);
            Player.CameraDistance = new OffsetStructure(0x10, 4);
            Player.CameraAngle = new OffsetStructure(0x14, 4);
            Player.CameraRotation = new OffsetStructure(0x18, 4);
            Player.Team = new OffsetStructure(0x1C, 1);
            Player.Type = new OffsetStructure(0x1D, 1);
            Player.Status = new OffsetStructure(0x1E, 1);
            Player.Difficulty = new OffsetStructure(0x20, 1);            
            Player.NameLength = new OffsetStructure(0xB4, 4);
            Player.Name = new OffsetStructure(0x64, Player.NameLength);
            Player.ClantagLength = new OffsetStructure(0x108, 4);
            Player.Clantag = new OffsetStructure(0x114, Player.ClantagLength);
            Player.ColorIndex = new OffsetStructure(0x1B8, 1);
            Player.AccountId = new OffsetStructure(0x210, 16);
            Player.ApmCurrent = new OffsetStructure(0x5F0, 4);
            Player.ApmAverage = new OffsetStructure(0x5F8, 4);
            Player.EpmCurrent = new OffsetStructure(0x638, 4);
            Player.EpmAverage = new OffsetStructure(0x638, 4);
            Player.UnitsInProduction = new OffsetStructure(0x6A0, 4);
            Player.WorkerCount = new OffsetStructure(0x7E0, 4);
            Player.SupplyLimit = new OffsetStructure(0x8A0, 4);
            Player.SupplyCurrent = new OffsetStructure(0x8B8, 4);
            Player.MineralsCurrent = new OffsetStructure(0x8F8, 4);
            Player.VespeneCurrent = new OffsetStructure(0x900, 4);
            Player.MineralsIncome = new OffsetStructure(0x978, 4);
            Player.VespeneIncome = new OffsetStructure(0x980, 4);
            Player.MineralsArmyValue = new OffsetStructure(0xC60, 4);
            Player.VespeneArmyValue = new OffsetStructure(0xC88, 4);
        }
    }
}
