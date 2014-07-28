using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.BackEnds
{
    public class Offsets
    {
        #region create variables for Addresses

        public int PlayerStruct = 0;
        public int UnitStruct = 0;
        public int MapStruct = 0;

        public Int32 RawPlayerCameraX = 0,
                     RawPlayerCameraY = 0,
                     RawPlayerCameraRotation = 0,
                     RawPlayerCameraDistance = 0,
                     RawPlayerCameraAngle = 0,
                     RawPlayerPlayertype = 0,
                     RawPlayerStatus = 0,
                     RawPlayerDifficulty = 0,
                     RawPlayerNamelenght = 0,
                     RawPlayerName = 0,
                     RawPlayerColor = 0,
                     RawPlayerAccountId = 0,
                     RawPlayerClanTag = 0,
                     RawPlayerClanTagLenght = 0,
                     RawPlayerApmCurrent = 0,
                     RawPlayerEpmCurrent = 0,
                     RawPlayerApmAverage = 0,
                     RawPlayerEpmAverage = 0,
                     RawPlayerTeam = 0,
                     RawPlayerWorkers = 0,
                     RawPlayerSupplyMin = 0,
                     RawPlayerSupplyMax = 0,
                     RawPlayerMinerals = 0,
                     RawPlayerGas = 0,
                     RawPlayerMineralsIncome = 0,
                     RawPlayerGasIncome = 0,
                     RawPlayerMineralsArmy = 0,
                     RawPlayerGasArmy = 0,
                     RawPlayerLocalplayer = 0,
                     RawPlayerCurrentBuildings = 0;

        public int CameraX = 0,
                            CameraY = 0,
                            CameraDistance = 0,
                            CameraRotation = 0,
                            Playertype = 0,
                            Status = 0,
                            NameLenght = 0,
                            Name = 0,
                            AccountId = 0,
                            Color = 0,
                            Apm = 0,
                            Epm = 0,
                            ApmAverage = 0,
                            EpmAverage = 0,
                            Workers = 0,
                            SupplyMin = 0,
                            SupplyMax = 0,
                            MineralsCurrent = 0,
                            GasCurrent = 0,
                            MineralsIncome = 0,
                            CurrentBuildings = 0,
                            GasIncome = 0,
                            MineralsArmy = 0,
                            GasArmy = 0,
                            PlayerStructSize = 0;

        public int RawGroupBase = 0x31CE258,
                   RawGroupSize = 0x1b60,
                   RawGroupAmountofUnits = 0x00,
                   RawGroupUnitIndex = 0x0A,
                   RawGroupUnitIndexSize = 0x04;

        public int RaceStruct = 0,
                            RaceSize = 0,
                            Team = 0,
                            TeamSize = 0;

        public int ChatBase = 0x017AB3C8,
                            ChatOff0 = 0x398,
                            ChatOff1 = 0x21C,
                            ChatOff2 = 0x004,
                            ChatOff3 = 0x004,
                            ChatOff4 = 0x014;

        public int ChatOpenBase = 0x0112E840,
            ChatOpenOff0= 0x190,
            ChatOpenOff1 = 0x004,
            ChatOpenOff2 = 0x398,
            ChatOpenOff3 = 0x008,
            ChatOpenOff4 = 0x16C;

        public int Localplayer1 = 0,
                            Localplayer2 = 0,
                            Localplayer3 = 0,
                            Localplayer4 = 0;

        public Int32 RawUnitPosX = 0,
            RawUnitPosY = 0,
            RawUnitTargetFilter = 0,
            RawUnitDestinationX = 0,
            RawUnitDestinationY = 0,
            RawUnitEnergy = 0,
            RawUnitAliveSince = 0,
            RawUnitDamageTaken = 0,
            RawUnitSpeedMultiplier = 0,
            RawUnitBuildingState = 0,
            RawUnitOwner = 0,
            RawUnitShieldDamageTaken = 0,
            RawUnitLastOrder = 0,
            RawUnitState = 0,
            RawUnitModel = 0,
            RawUnitMovestate = 0,
            RawUnitRandomFlag = 0;

        public int UnitPosX = 0,
                   UnitPosY = 0,
                   UnitTargetFilter = 0,
                   UnitTotal = 0,
                   UnitDeathType = 0,
                   UnitDestinationX = 0,
                   UnitDestinationY = 0,
                   UnitEnergy = 0,
                   UnitHp = 0,
                   UnitOwner = 0,
                   UnitState = 0,
                   UnitModel = 0,
                   UnitBeeingPuked = 0,
                   UnitMoveState = 0,
                   UnitStringStruct = 0,
                   UnitString = 0,
                   UnitStructSize = 0,
                   UnitMaxShield = 0,
                   UnitModelId = 0,
                   UnitMaxHealth = 0,
                   UnitModelSize = 0;

        public Int32 StructureStruct = 0,
                     StructurePointerToUnitStruct = 0,
                     StructureHarvesterCount = 0,
                     StructureCount = 0,
                     StructureSize = 0;

        public Int32 RawStructureHarvesterCount = 0;

        public int MapIngame = 0,
                   MapFileInfoName = 0;

        public Int32 RawMapTop = 0,
                     RawMapBottom = 0,
                     RawMapRight = 0,
                     RawMapLeft = 0;

        public int UiSelectionStruct = 0,
                   UiTotalSelectedUnits = 0,
                   UiTotalSelectedTypes = 0,
                   UiSelectedType = 0,
                   UiSelectedIndex = 0,
                   UiSize = 0;

        public Int32 UiRawSelectionStruct = 0,
                     UiRawTotalSelectedUnits = 0,
                     UiRawTotalSelectedTypes = 0,
                     UiRawSelectedType = 0,
                     UiRawSelectedIndex = 0;

        public int TeamColor1 = 0;

        public int TimerData = 0;

        public int PauseEnabled = 0;

        public int Gamespeed = 0;

        public int FramesPerSecond = 0;

        public int Gametype = 0;

        #endregion

        public Offsets()
        {
            Process proc;
            if (Processing.GetProcess(Constants.StrStarcraft2ProcessName, out proc))
                AssignAddresses(proc);
        }

        public void AssignAddresses(Process starcraft)
        {
            var starcraftVersion = starcraft.MainModule.FileVersionInfo.FileVersion;

            if (starcraftVersion.StartsWith("2.0.11"))
            {
                Version__2_0_11(starcraft);
            }

            else if (starcraftVersion.Equals("2.1.0.28667"))
            {
                Version__2_1_0_28667(starcraft);
            }

            else if (starcraftVersion.Equals("2.1.1.29261") ||
                starcraftVersion.Equals("2.1.2.30315") ||
                starcraftVersion.Equals("2.1.3.30508"))
            {
                Version__2_1_3_30508(starcraft);
            }

            else
            {
                MessageBox.Show("This tool is outdated.\n" +
                                "Please be so kind and create a post in the forum\n" +
                                "so I can update it!\n\n" + 
                "Maybe it's still possible to use\n" + 
                "this tool. Give it a shot!", "Ouch... new version!?");

                Version__2_1_3_30508(starcraft);
            }
        }

        private void Version__2_0_11(Process starcraft)
        {
            #region PlayerInformation

            //Playerinfo
            PlayerStruct = (int)starcraft.MainModule.BaseAddress + 0x035E6E00; //V

            PlayerStructSize = 0xDC0; //V

            /* 4 Bytes */
            RawPlayerCameraX = 0x008;

            /* 4 Bytes */
            RawPlayerCameraY = 0x00C;

            /* 4 Bytes */
            RawPlayerCameraDistance = 0x010;

            /* 4 Bytes */
            RawPlayerCameraAngle = 0x014;

            /* 4 Bytes */
            RawPlayerCameraRotation = 0x018;

            /* 1 Byte */
            RawPlayerTeam = 0x01C;

            /* 1 Byte */
            RawPlayerPlayertype = 0x01D;

            /* 1 Byte */
            RawPlayerStatus = 0x01E;

            /* 1 Byte */
            RawPlayerDifficulty = 0x020;

            /* Unknown */
            RawPlayerName = 0x060;

            /* 4 Byte */
            RawPlayerClanTagLenght = 0x108;

            /* Max 6 signs */
            RawPlayerClanTag = 0x110;

            /* 1 Byte 
             * ####################
             * 0 - White
             * 1 - red
             * 2 - Blue
             * 3 - Teal
             * 4 - Purple
             * 5 - Yellow
             * 6 - Orange
             * 7 - Green
             * 8 - Light Pink
             * 9 - Violet
             * 10 - Light Gray
             * 11 - Dark Green
             * 12 - Brown
             * 13 - Light Green
             * 14 - Dark Gray
             * 15 - Pink 
             * #################### */
            RawPlayerColor = 0x160; /* + 50 */

            /* 4 Bytes 
             *
             * Devide by 4 to get actual value */
            RawPlayerNamelenght = 0x0B0;

            /* Unknown */
            RawPlayerAccountId = 0x1C0;

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerApmCurrent = 0x598;

            /* 4 Bytes */
            RawPlayerApmAverage = 0x5A0;

            /* 4 Bytes */
            RawPlayerEpmAverage = 0x5E0;

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerEpmCurrent = 0x5D8;

            /* 4 Bytes */
            RawPlayerCurrentBuildings = 0x6B0; //?

            /* 4 Bytes */
            RawPlayerWorkers = 0x788;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMin = 0x860;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMax = 0x848;

            /* 4 Bytes */
            RawPlayerMinerals = 0x8A0;

            /* 4 Bytes */
            RawPlayerGas = 0x8A8;

            /* 4 Bytes */
            RawPlayerMineralsIncome = 0x920;

            /* 4 Bytes */
            RawPlayerGasIncome = 0x928;

            /* 4 Bytes */
            RawPlayerMineralsArmy = 0xC08;

            /* 4 Bytes */
            RawPlayerGasArmy = 0xC30;


            #endregion

            #region UnitInformation

            //Unitinfo
            UnitStruct = (int)starcraft.MainModule.BaseAddress + 0x03665140; //V

            /* 4 Bytes */
            UnitTotal = (int)starcraft.MainModule.BaseAddress + 0x03665104; //

            /* 4 Bytes
             *
             * Is a pointer */
            UnitStringStruct = 0x7DC; //?

            /* 4 Bytes
             *
             * Is a Pointer */
            UnitString = 0x020; //?

            /* 4 Bytes
             *
             * Is a pointer */
            UnitModel = UnitStruct + 8; //? 

            /* 2 Bytes */
            UnitModelId = 0x06; //

            /* 4 Bytes (float)
             *
             * devide by 4096 */
            UnitModelSize = 0x3AC; //?

            /* 4 Bytes  */
            UnitMaxHealth = 0x368;


            UnitStructSize = 0x1C0;

            //Raw Unitdata
            /* Bytes */
            RawUnitRandomFlag = 0x20;

            /* 4 Bytes */
            RawUnitPosX = 0x4C;

            /* 4 Bytes */
            RawUnitPosY = 0x50;

            /* 4 Bytes */
            RawUnitDestinationX = 0x80;

            /* 4 Bytes */
            RawUnitDestinationY = 0x84;

            /* 8 Bytes */
            RawUnitTargetFilter = 0x14;

            /* 4 Bytes */
            /* Till Mule dies: 387328 */
            RawUnitAliveSince = 0x16C;

            /* 4 Bytes 
             *
             * Devide by 4096 to get actual value */
            RawUnitDamageTaken = 0x114;

            /* 4 Bytes 
             *
             * Devide by 4096 to get actual value */
            RawUnitEnergy = 0x11C;

            /* 1 Byte */
            RawUnitOwner = 0x41;

            /* 4 Bytes */
            RawUnitState = 0x2B;

            /* 4 Bytes */
            RawUnitMovestate = 0x60;

            /* 2 Bytes */
            RawUnitBuildingState = 0x34; //?

            /* 4 Bytes */
            RawUnitModel = 0x008; //

            #endregion

            #region MapInformation

            //Mapinfo 
            MapStruct = (int)starcraft.MainModule.BaseAddress + 0x03534E90;
            MapFileInfoName = 0x2A0; /* DISAPPEARED :( */

            //Raw Mapadata
            RawMapLeft = 0x128;
            RawMapBottom = 0x12C;
            RawMapRight = 0x130;
            RawMapTop = 0x134;

            #endregion

            #region Groups

            /* 4 Bytes */
            RawGroupBase = (int)starcraft.MainModule.BaseAddress + 0x31CE258;

            /* 4 Bytes */
            RawGroupSize = 0x1b60;

            /* 2 Bytes */
            RawGroupAmountofUnits = 0x00;

            /* 2 Bytes */
            RawGroupUnitIndex = 0x0A;

            /* 1 Byte? No result! */
            RawGroupUnitIndexSize = 0x04;

            #endregion

            #region Various

            //Race
            RaceStruct = (int)starcraft.MainModule.BaseAddress + 0x02F6C850;
            RaceSize = 0x10;

            //ChatInput
            ChatBase = (int)starcraft.MainModule.BaseAddress + 0x0031073C0;
            ChatOff0 = 0x3B0;
            ChatOff1 = 0x208;
            ChatOff2 = 0x000;
            ChatOff3 = 0x000;
            ChatOff4 = 0x014;

            /* 1 Byte */
            Localplayer4 = (int)starcraft.MainModule.BaseAddress + 0x011265D8;

            /* 1 Byte 
             *
             * 0 - Teamcolor Off
             * 2 - Teamcolor On*/
            TeamColor1 = (int)starcraft.MainModule.BaseAddress + 0x03108504;

            /* 4 Bytes 
             *
             * Devide by 4090 to get actual value 
             * Is 0 when not Ingame */
            TimerData = (int)starcraft.MainModule.BaseAddress + 0x031082F0;

            /* 4 Bytes */
            Gamespeed = (int)starcraft.MainModule.BaseAddress + 0x04EEB184;

            #endregion

            #region Outdated and Unused

            //Selected stuff - UNUSED
            UiSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x031CAB90; //
            UiTotalSelectedUnits = UiSelectionStruct + 0x0; //
            UiTotalSelectedTypes = UiSelectionStruct + 0x2; //
            UiSelectedType = UiSelectionStruct + 0x4; //
            UiSelectedIndex = UiSelectionStruct + 0xA; //
            UiSize = 4; //147

            UiRawSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x031CAB90;
            UiRawTotalSelectedUnits = 0x0;
            UiRawTotalSelectedTypes = 0x2;
            UiRawSelectedType = 0x4;

            /* Is in a loop, has to be like this */
            UiRawSelectedIndex = 0xA;

            //Pause 
            PauseEnabled = (int)starcraft.MainModule.BaseAddress + 0x024C9E38; /* 0x022ab7b8
                                               * 0x25ef0b8 
                                               * 0x3de06e4 
                                               * 0x3e0fc20 */

            /* Structure Struct - UNUSED */
            StructureStruct = (int)starcraft.MainModule.BaseAddress + 0x0329029C;
            StructureHarvesterCount = StructureStruct + 0x4C;
            StructureCount = (int)starcraft.MainModule.BaseAddress + 0x03290288;
            StructureSize = 0x94;


            //Fps
            FramesPerSecond = (int)
                              starcraft.MainModule.BaseAddress + 0x03ED54DC;

            //Gametype 
            Gametype = 0x0176DCC8;

            #endregion
        }

        private void Version__2_1_0_28667(Process starcraft)
        {
            #region PlayerInformation

            //Playerinfo
            PlayerStruct = (int)starcraft.MainModule.BaseAddress + 0x035EE2D8; //V

            PlayerStructSize = 0x0E10; //V

            /* 4 Bytes */
            RawPlayerCameraX = 0x008;

            /* 4 Bytes */
            RawPlayerCameraY = 0x00C;

            /* 4 Bytes */
            RawPlayerCameraDistance = 0x010;

            /* 4 Bytes */
            RawPlayerCameraAngle = 0x014;

            /* 4 Bytes */
            RawPlayerCameraRotation = 0x018;

            /* 1 Byte */
            RawPlayerTeam = 0x01C;

            /* 1 Byte */
            RawPlayerPlayertype = 0x01D;

            /* 1 Byte */
            RawPlayerStatus = 0x01E;

            /* 1 Byte */
            RawPlayerDifficulty = 0x020;

            /* Unknown */
            RawPlayerName = 0x060;

            /* 4 Byte */
            RawPlayerClanTagLenght = 0x108;

            /* Max 6 signs */
            RawPlayerClanTag = 0x110;

            /* 1 Byte 
             * ####################
             * 0 - White
             * 1 - red
             * 2 - Blue
             * 3 - Teal
             * 4 - Purple
             * 5 - Yellow
             * 6 - Orange
             * 7 - Green
             * 8 - Light Pink
             * 9 - Violet
             * 10 - Light Gray
             * 11 - Dark Green
             * 12 - Brown
             * 13 - Light Green
             * 14 - Dark Gray
             * 15 - Pink 
             * #################### */
            RawPlayerColor = 0x1B0;

            /* 4 Bytes 
             *
             * Devide by 4 to get actual value */
            RawPlayerNamelenght = 0x0B0;

            /* Unknown */
            RawPlayerAccountId = 0x210;

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerApmCurrent = 0x5E8;

            /* 4 Bytes */
            RawPlayerApmAverage = 0x5F0;

            /* 4 Bytes */
            RawPlayerEpmAverage = 0x630;

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerEpmCurrent = 0x628;

            /* 4 Bytes */
            RawPlayerWorkers = 0x7D8;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMin = 0x8B0;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMax = 0x898;

            /* 4 Bytes */
            RawPlayerMinerals = 0x8F0;

            /* 4 Bytes */
            RawPlayerGas = 0x8F8;

            /* 4 Bytes */
            RawPlayerMineralsIncome = 0x970;

            /* 4 Bytes */
            RawPlayerGasIncome = 0x978;

            /* 4 Bytes */
            RawPlayerMineralsArmy = 0xC58;

            /* 4 Bytes */
            RawPlayerGasArmy = 0xC80;


            #endregion

            #region UnitInformation

            //Unitinfo
            UnitStruct = (int)starcraft.MainModule.BaseAddress + 0x0366cb40; //V

            /* 4 Bytes */
            UnitTotal = (int)starcraft.MainModule.BaseAddress + 0x0366CB00; //V

            /* 4 Bytes
             *
             * Is a pointer */
            UnitStringStruct = 0x7DC; //?

            /* 4 Bytes
             *
             * Is a Pointer */
            UnitString = 0x020; //?

            /* 4 Bytes
             *
             * Is a pointer */
            UnitModel = UnitStruct + 8; //? 

            /* 2 Bytes */
            UnitModelId = 0x06; //

            /* 4 Bytes (float)
             *
             * devide by 4096 */
            UnitModelSize = 0x3AC; //?

            /* 4 Bytes  */
            UnitMaxHealth = 0x818;


            UnitStructSize = 0x1C0;

            //Raw Unitdata

            /* 4 Bytes */
            RawUnitPosX = 0x4C;

            /* 4 Bytes */
            RawUnitPosY = 0x50;

            /* 4 Bytes */
            RawUnitDestinationX = 0x80;

            /* 4 Bytes */
            RawUnitDestinationY = 0x84;

            /* 8 Bytes */
            RawUnitTargetFilter = 0x14;

            /* 1 Byte */
            RawUnitRandomFlag = 0x20;

            /* 4 Bytes */
            /* Till Mule dies: 387328 */
            RawUnitAliveSince = 0x16C;

            /* 4 Bytes 
             *
             * Devide by 4096 to get actual value */
            RawUnitDamageTaken = 0x114;

            /* 4 Bytes 
             *
             * Devide by 4096 to get actual value */
            RawUnitEnergy = 0x11C;

            /* 1 Byte */
            RawUnitOwner = 0x27;

            /* 4 Bytes */
            RawUnitState = 0x2B;

            /* 4 Bytes */
            RawUnitMovestate = 0x60;

            /* 2 Bytes */
            RawUnitBuildingState = 0x34; //?

            /* 4 Bytes */
            RawUnitModel = 0x008; //

            #endregion

            #region MapInformation

            //Mapinfo 
            MapStruct = (int)starcraft.MainModule.BaseAddress + 0x0353C478; /* V */
            MapFileInfoName = 0x2A0; /* DISAPPEARED :( */

            //Raw Mapadata
            RawMapLeft = 0x18;
            RawMapBottom = 0x1C;
            RawMapRight = 0x20;
            RawMapTop = 0x24;

            #endregion

            #region Selection

            //Selected stuff
            UiSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x031D2048; //
            UiTotalSelectedUnits = UiSelectionStruct + 0x0; //
            UiTotalSelectedTypes = UiSelectionStruct + 0x2; //
            UiSelectedType = UiSelectionStruct + 0x4; //
            UiSelectedIndex = UiSelectionStruct + 0xA; //
            UiSize = 4; //147

            UiRawSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x031D2048;
            UiRawTotalSelectedUnits = 0x0;
            UiRawTotalSelectedTypes = 0x2;
            UiRawSelectedType = 0x4;

            /* Is in a loop, has to be like this */
            UiRawSelectedIndex = 0xA;

            #endregion

            #region Groups

            /* 4 Bytes */
            RawGroupBase = (int)starcraft.MainModule.BaseAddress + 0x031D7270;

            /* 4 Bytes */
            RawGroupSize = 0x1b60;

            /* 2 Bytes */
            RawGroupAmountofUnits = 0x00;

            /* 2 Bytes */
            RawGroupUnitIndex = 0x0A;

            /* 1 Byte? No result! */
            RawGroupUnitIndexSize = 0x04;

            #endregion

            #region Various

            //Race
            RaceStruct = (int)starcraft.MainModule.BaseAddress + 0x02F73CB0;        //V
            RaceSize = 0x10;

            //ChatInput
            ChatBase = (int)starcraft.MainModule.BaseAddress + 0x0310E870;          //V
            ChatOff0 = 0x398;
            ChatOff1 = 0x208;
            ChatOff2 = 0x000;
            ChatOff3 = 0x000;
            ChatOff4 = 0x014;

            /* Chat Open */
            ChatOpenBase = (int)starcraft.MainModule.BaseAddress + 0x0112E840;
            ChatOpenOff0 = 0x190;
            ChatOpenOff1 = 0x004;
            ChatOpenOff2 = 0x398;
            ChatOpenOff3 = 0x008;
            ChatOpenOff4 = 0x16C;

            /* 1 Byte */
            Localplayer4 = (int)starcraft.MainModule.BaseAddress + 0x0112DE18;      //V

            /* 1 Byte 
             *
             * 0 - Teamcolor Off
             * 2 - Teamcolor On*/
            TeamColor1 = (int)starcraft.MainModule.BaseAddress + 0x0310F9BC;        //V

            /* 4 Bytes 
             *
             * Devide by 4090 to get actual value 
             * Is 0 when not Ingame */
            TimerData = (int)starcraft.MainModule.BaseAddress + 0x0353C41C;         //V

            /* 4 Bytes */
            Gamespeed = (int)starcraft.MainModule.BaseAddress + 0x04EF35C4;         //V

            #endregion

            #region Outdated and Unused



            //Pause 
            PauseEnabled = (int)starcraft.MainModule.BaseAddress + 0x024C9E38; /* 0x022ab7b8
                                               * 0x25ef0b8 
                                               * 0x3de06e4 
                                               * 0x3e0fc20 */

            /* Structure Struct - UNUSED */
            StructureStruct = (int)starcraft.MainModule.BaseAddress + 0x0329029C;
            StructureHarvesterCount = StructureStruct + 0x4C;
            StructureCount = (int)starcraft.MainModule.BaseAddress + 0x03290288;
            StructureSize = 0x94;


            //Fps
            FramesPerSecond = (int)
                              starcraft.MainModule.BaseAddress + 0x03ED54DC;

            //Gametype 
            Gametype = 0x0176DCC8;

            #endregion 
        }

        private void Version__2_1_3_30508(Process starcraft)
        {
            #region PlayerInformation

            //Playerinfo
            PlayerStruct = (int)starcraft.MainModule.BaseAddress + 0x035f4798; //V

            PlayerStructSize = 0x0E10; //V

            /* 4 Bytes */
            RawPlayerCameraX = 0x008;

            /* 4 Bytes */
            RawPlayerCameraY = 0x00C;

            /* 4 Bytes */
            RawPlayerCameraDistance = 0x010;

            /* 4 Bytes */
            RawPlayerCameraAngle = 0x014;

            /* 4 Bytes */
            RawPlayerCameraRotation = 0x018;

            /* 1 Byte */
            RawPlayerTeam = 0x01C;

            /* 1 Byte */
            RawPlayerPlayertype = 0x01D;

            /* 1 Byte */
            RawPlayerStatus = 0x01E;

            /* 1 Byte */
            RawPlayerDifficulty = 0x020;

            /* Unknown */
            RawPlayerName = 0x060;

            /* 4 Byte */
            RawPlayerClanTagLenght = 0x108;

            /* Max 6 signs */
            RawPlayerClanTag = 0x110;

            /* 1 Byte 
             * ####################
             * 0 - White
             * 1 - red
             * 2 - Blue
             * 3 - Teal
             * 4 - Purple
             * 5 - Yellow
             * 6 - Orange
             * 7 - Green
             * 8 - Light Pink
             * 9 - Violet
             * 10 - Light Gray
             * 11 - Dark Green
             * 12 - Brown
             * 13 - Light Green
             * 14 - Dark Gray
             * 15 - Pink 
             * #################### */
            RawPlayerColor = 0x1B0;

            /* 4 Bytes 
             *
             * Devide by 4 to get actual value */
            RawPlayerNamelenght = 0x0B0;

            /* Unknown */
            RawPlayerAccountId = 0x210;

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerApmCurrent = 0x5E8;

            /* 4 Bytes */
            RawPlayerApmAverage = 0x5F0;

            /* 4 Bytes */
            RawPlayerEpmAverage = 0x630;

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerEpmCurrent = 0x628;

            /* 4 Bytes */
            RawPlayerWorkers = 0x7D8;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMin = 0x8B0;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMax = 0x898;

            /* 4 Bytes */
            RawPlayerMinerals = 0x8F0;

            /* 4 Bytes */
            RawPlayerGas = 0x8F8;

            /* 4 Bytes */
            RawPlayerMineralsIncome = 0x970;

            /* 4 Bytes */
            RawPlayerGasIncome = 0x978;

            /* 4 Bytes */
            RawPlayerMineralsArmy = 0xC58;

            /* 4 Bytes */
            RawPlayerGasArmy = 0xC80;


            #endregion

            #region UnitInformation

            //Unitinfo
            UnitStruct = (int)starcraft.MainModule.BaseAddress + 0x03673000; //ok

            /* 4 Bytes */
            UnitTotal = (int)starcraft.MainModule.BaseAddress + 0x03672FC4; //ok

            /* 4 Bytes
             *
             * Is a pointer */
            UnitStringStruct = 0x7DC; //?

            /* 4 Bytes
             *
             * Is a Pointer */
            UnitString = 0x020; //?

            /* 4 Bytes
             *
             * Is a pointer */
            UnitModel = UnitStruct + 8; //? 

            /* 2 Bytes */
            UnitModelId = 0x06; //

            /* 4 Bytes (float)
             *
             * devide by 4096 */
            UnitModelSize = 0x3AC; //?

            /* 4 Bytes  */
            UnitMaxHealth = 0x818;

            /* 4 Bytes  */
            UnitMaxShield = 0x88C;

            UnitStructSize = 0x1C0;

            //Raw Unitdata

            /* 4 Bytes */
            RawUnitPosX = 0x4C;

            /* 4 Bytes */
            RawUnitPosY = 0x50;

            /* 4 Bytes */
            RawUnitDestinationX = 0x80;

            /* 4 Bytes */
            RawUnitDestinationY = 0x84;

            /* 8 Bytes */
            RawUnitTargetFilter = 0x14;

            /* 1 Byte */
            RawUnitRandomFlag = 0x20;

            /* 4 Bytes */
            /* Till Mule dies: 387328 */
            RawUnitAliveSince = 0x16C;

            /* 4 Bytes 
             *
             * Devide by 4096 to get actual value */
            RawUnitDamageTaken = 0x114;

            /* 4 Bytes 
             *
             * Devide by 4096 to get actual value */
            RawUnitShieldDamageTaken = 0x118;

            /* 4 Bytes 
             *
             * Devide by 4096 to get actual value */
            RawUnitEnergy = 0x11C;

            /* 1 Byte */
            RawUnitOwner = 0x27;

            /* 4 Byte */
            RawUnitSpeedMultiplier = 0x0168;

            /* 4 Bytes */
            RawUnitState = 0x2B;

            /* 4 Bytes */
            RawUnitMovestate = 0x60;

            /* 2 Bytes */
            RawUnitBuildingState = 0x34; //?

            /* 4 Bytes */
            RawUnitModel = 0x008; //

            #endregion

            #region MapInformation

            //Mapinfo 
            MapStruct = (int)starcraft.MainModule.BaseAddress + 0x03542938; /* V */
            MapFileInfoName = 0x2A0; /* DISAPPEARED :( */

            //Raw Mapadata
            RawMapLeft = 0x18;
            RawMapBottom = 0x1C;
            RawMapRight = 0x20;
            RawMapTop = 0x24;

            #endregion

            #region Selection

            //Selected stuff
            UiSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x468A200; //ok
            UiTotalSelectedUnits = UiSelectionStruct + 0x0; //
            UiTotalSelectedTypes = UiSelectionStruct + 0x2; //
            UiSelectedType = UiSelectionStruct + 0x4; //
            UiSelectedIndex = UiSelectionStruct + 0xA; //
            UiSize = 4; //147

            UiRawSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x0468A200;
            UiRawTotalSelectedUnits = 0x0;
            UiRawTotalSelectedTypes = 0x2;
            UiRawSelectedType = 0x4;

            /* Is in a loop, has to be like this */
            UiRawSelectedIndex = 0xA;

            #endregion

            #region Groups

            /* 4 Bytes */
            RawGroupBase = (int)starcraft.MainModule.BaseAddress + 0x031DD730;

            /* 4 Bytes */
            RawGroupSize = 0x1b60;

            /* 2 Bytes */
            RawGroupAmountofUnits = 0x00;

            /* 2 Bytes */
            RawGroupUnitIndex = 0x0A;

            /* 1 Byte? No result! */
            RawGroupUnitIndexSize = 0x04;

            #endregion

            #region Various

            //Race
            RaceStruct = (int)starcraft.MainModule.BaseAddress + 0x02f75980;        //ok
            RaceSize = 0x10;

            //ChatInput
            ChatBase = (int)starcraft.MainModule.BaseAddress + 0x003114D30;          //ok
            ChatOff0 = 0x398;
            ChatOff1 = 0x208;
            ChatOff2 = 0x000;
            ChatOff3 = 0x000;
            ChatOff4 = 0x014;

            /* 1 Byte */
            Localplayer4 = (int)starcraft.MainModule.BaseAddress + 0x0112e5f0;      //ok?

            /* 1 Byte 
             *
             * 0 - Teamcolor Off
             * 2 - Teamcolor On*/
            TeamColor1 = (int)starcraft.MainModule.BaseAddress + 0x03115E7C;        //ok

            /* 4 Bytes 
             *
             * Devide by 4090 to get actual value 
             * Is 0 when not Ingame */
            TimerData = (int)starcraft.MainModule.BaseAddress + 0x035428dc;         //ok

            /* 4 Bytes */
            Gamespeed = (int)starcraft.MainModule.BaseAddress + 0x04EFE5F4;         //ok

            #endregion

            #region Outdated and Unused



            //Pause 
            PauseEnabled = (int)starcraft.MainModule.BaseAddress + 0x024C9E38; /* 0x022ab7b8
                                               * 0x25ef0b8 
                                               * 0x3de06e4 
                                               * 0x3e0fc20 */

            /* Structure Struct - UNUSED */
            StructureStruct = (int)starcraft.MainModule.BaseAddress + 0x0329029C;
            StructureHarvesterCount = StructureStruct + 0x4C;
            StructureCount = (int)starcraft.MainModule.BaseAddress + 0x03290288;
            StructureSize = 0x94;


            //Fps
            FramesPerSecond = (int)
                              starcraft.MainModule.BaseAddress + 0x03ED54DC;

            //Gametype 
            Gametype = 0x0176DCC8;

            #endregion
        }
    }
}