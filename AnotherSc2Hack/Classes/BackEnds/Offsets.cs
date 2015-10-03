using System;
using System.Diagnostics;
using System.Windows.Forms;
using Utilities.Processing;

namespace AnotherSc2Hack.Classes.BackEnds
{
    public class Offsets
    {
        #region create variables for Addresses

        public int PlayerStruct;
        public int PlayerStructSize;
        public int UnitStruct;
        public int MapStruct;

        public int RawPlayerCameraX;
        public int RawPlayerCameraY;
        public int RawPlayerCameraRotation;
        public int RawPlayerCameraDistance;
        public int RawPlayerCameraAngle;
        public int RawPlayerPlayertype;
        public int RawPlayerStatus;
        public int RawPlayerDifficulty;
        public int RawPlayerNamelenght;
        public int RawPlayerName;
        public int RawPlayerColor;
        public int RawPlayerAccountId;
        public int RawPlayerClanTag;
        public int RawPlayerClanTagLenght;
        public int RawPlayerApmCurrent;
        public int RawPlayerEpmCurrent;
        public int RawPlayerApmAverage;
        public int RawPlayerEpmAverage;
        public int RawPlayerTeam;
        public int RawPlayerWorkers;
        public int RawPlayerUnitsInProduction;
        public int RawPlayerSupplyMin;
        public int RawPlayerSupplyMax;
        public int RawPlayerMinerals;
        public int RawPlayerGas;
        public int RawPlayerMineralsIncome;
        public int RawPlayerGasIncome;
        public int RawPlayerMineralsArmy;
        public int RawPlayerGasArmy;
        public int RawPlayerLocalplayer = 0;
        public int RawPlayerCurrentBuildings;

        public int RawGroupBase = 0x31CE258,
                   RawGroupSize = 0x1b60,
                   RawGroupAmountofUnits,
                   RawGroupUnitIndex = 0x0A,
                   RawGroupUnitIndexSize = 0x04;

        public int RaceStruct,
                            RaceSize,
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

        public int Localplayer4;

        public int RawUnitPosX,
            RawUnitPosY,
            RawUnitTargetFilter,
            RawUnitDestinationX,
            RawUnitDestinationY,
            RawUnitEnergy,
            RawUnitAliveSince,
            RawUnitDamageTaken,
            RawUnitSpeedMultiplier,
            RawUnitBuildingState,
            RawUnitOwner,
            RawUnitShieldDamageTaken,
            RawUnitLastOrder = 0,
            RawUnitState,
            RawUnitModel,
            RawUnitMovestate,
            RawUnitRandomFlag;

        public int UnitTotal,
                   UnitModel,
                   UnitStringStruct,
                   UnitString,
                   UnitStructSize,
                   UnitMaxShield,
                   UnitModelId,
                   UnitMaxHealth,
                   UnitMaxEnergy,
                   UnitModelSize;

        public int MapIngame = 0,
                   MapFileInfoName;

        public int RawMapTop,
                     RawMapBottom,
                     RawMapRight,
                     RawMapLeft;

        public int UiSelectionStruct,
                   UiTotalSelectedUnits,
                   UiTotalSelectedTypes,
                   UiSelectedType,
                   UiSelectedIndex,
                   UiSize;

        public int UiRawSelectionStruct,
                     UiRawTotalSelectedUnits,
                     UiRawTotalSelectedTypes,
                     UiRawSelectedType,
                     UiRawSelectedIndex;

        public int TeamColor1;

        public int TimerData;

        public int PauseEnabled;

        public int Gamespeed;

        public int FramesPerSecond;

        public int Gametype;

        #endregion

        public event EventHandler OffsetsNotProperlySet;

        private Process _starcraft;

        public void OnOffsetsNotProperlySet(object o, EventArgs e)
        {
            OffsetsNotProperlySet?.Invoke(o, e);
        }

        public Offsets()
        {
            Process proc;
            if (Processing.GetProcess(Constants.StrStarcraft2ProcessName, out proc))
                _starcraft = proc;
        }

        public void AssignAddresses(Process starcraft = null)
        {
            if (starcraft != null)
                _starcraft = starcraft;

            if (_starcraft == null)
                return;

            var starcraftVersion = _starcraft.MainModule.FileVersionInfo.FileVersion;

            if (starcraftVersion.StartsWith("2.0.11"))
            {
                Version__2_0_11(_starcraft);
            }

            else if (starcraftVersion.Equals("2.1.0.28667"))
            {
                Version__2_1_0_28667(_starcraft);
            }

            else if (starcraftVersion.Equals("2.1.1.29261") ||
                starcraftVersion.Equals("2.1.2.30315") ||
                starcraftVersion.Equals("2.1.3.30508"))
            {
                Version__2_1_3_30508(_starcraft);
            }

            else if (starcraftVersion.Equals("2.1.4.32283"))
                Version__2_1_4_32283(_starcraft);

            else if (starcraftVersion.Equals("2.1.5.32392") ||
                starcraftVersion.Equals("2.1.6.32540") ||
                starcraftVersion.Equals("2.1.7.33148") ||
                starcraftVersion.Equals("2.1.8.33553"))
                Version__2_1_5_32392(_starcraft);

                
            else if (starcraftVersion.Equals("2.1.9.34644") ||
                starcraftVersion.Equals("2.1.10.35237"))
                Version__2_1_9_34644(_starcraft);
                
            else if (starcraftVersion.Equals("2.1.11.36281"))
                Version__2_1_11_36281(_starcraft);

            else if (starcraftVersion.Equals("2.1.12.36657"))
                Version__2_1_12_36657(_starcraft);

            else if(starcraftVersion == "2.5.5.37164")
                Version__2_5_5_37164(_starcraft);

            else
            {
                MessageBox.Show("This tool is outdated.\n" +
                                "Please be so kind and create a post in the forum\n" +
                                "so I can update it!\n\n" + 
                "Maybe it's still possible to use\n" + 
                "this tool. Give it a shot!", "Ouch... new SCII version!?");
                
                Version__2_1_9_34644(_starcraft);
                
                OnOffsetsNotProperlySet(this, new EventArgs());
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

            //UiChatInput
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

            //UiChatInput
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

            //UiChatInput
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

            //Fps
            FramesPerSecond = (int)
                              starcraft.MainModule.BaseAddress + 0x03ED54DC;

            //Gametype 
            Gametype = 0x0176DCC8;

            #endregion
        }

        private void Version__2_1_4_32283(Process starcraft)
        {
            #region PlayerInformation

            //Playerinfo
            PlayerStruct = (int)starcraft.MainModule.BaseAddress + 0x03620CB0; //V

            PlayerStructSize = 0x0E18; //V

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
            RawPlayerName = 0x064;              

            /* 4 Byte */
            RawPlayerClanTagLenght = 0x108;

            /* Max 6 signs */
            RawPlayerClanTag = 0x114;

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
            RawPlayerColor = 0x01B8;

            /* 4 Bytes 
             *
             * Devide by 4 to get actual value */
            RawPlayerNamelenght = 0x0B4;

            /* Unknown */
            RawPlayerAccountId = 0x210;         //ok

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerApmCurrent = 0x5F0;        //ok

            /* 4 Bytes */
            RawPlayerApmAverage = 0x5F8;        //ok

            /* 4 Bytes */
            RawPlayerEpmAverage = 0x638;        //ok

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerEpmCurrent = 0x630;        //ok

            /* 4 Bytes */
            RawPlayerWorkers = 0x7E0;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMin = 0x8B8;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMax = 0x8A0;

            /* 4 Bytes */
            RawPlayerMinerals = 0x8F8;

            /* 4 Bytes */
            RawPlayerGas = 0x900;

            /* 4 Bytes */
            RawPlayerMineralsIncome = 0x978;

            /* 4 Bytes */
            RawPlayerGasIncome = 0x980;

            /* 4 Bytes */
            RawPlayerMineralsArmy = 0xC60;

            /* 4 Bytes */
            RawPlayerGasArmy = 0xC88;


            #endregion

            #region UnitInformation

            //Unitinfo
            UnitStruct = (int)starcraft.MainModule.BaseAddress + 0x0369f580; //ok

            /* 4 Bytes */
            UnitTotal = (int)starcraft.MainModule.BaseAddress + 0x0369F540; 

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

            /* 4 Bytes */
            UnitMaxEnergy = 0x860;

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
            MapStruct = (int)starcraft.MainModule.BaseAddress + 0x0356EE50; /* V */
            MapFileInfoName = 0x2A0; /* DISAPPEARED :( */

            //Raw Mapadata
            RawMapLeft = 0x18;
            RawMapBottom = 0x1C;
            RawMapRight = 0x20;
            RawMapTop = 0x24;

            #endregion

            #region Selection - Unused & outdated

            //Selected stuff
            UiSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x046B6200; //ok
            UiTotalSelectedUnits = UiSelectionStruct + 0x0; //
            UiTotalSelectedTypes = UiSelectionStruct + 0x2; //
            UiSelectedType = UiSelectionStruct + 0x4; //
            UiSelectedIndex = UiSelectionStruct + 0xA; //
            UiSize = 4; //147

            UiRawSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x046B6200;
            UiRawTotalSelectedUnits = 0x0;
            UiRawTotalSelectedTypes = 0x2;
            UiRawSelectedType = 0x4;

            /* Is in a loop, has to be like this */
            UiRawSelectedIndex = 0xA;

            #endregion

            #region Groups - unused & outdated

            /* 4 Bytes */
            RawGroupBase = (int)starcraft.MainModule.BaseAddress + 0x046D3360;

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
            RaceStruct = (int)starcraft.MainModule.BaseAddress + 0x02FA0B90;        //ok
            RaceSize = 0x10;

            //UiChatInput
            ChatBase = (int)starcraft.MainModule.BaseAddress + 0x003140650;         //ok
            ChatOff0 = 0x398;
            ChatOff1 = 0x208;
            ChatOff2 = 0x000;
            ChatOff3 = 0x000;
            ChatOff4 = 0x014;

            /* 1 Byte */
            Localplayer4 = (int)starcraft.MainModule.BaseAddress + 0x011596A8;      //ok

            /* 1 Byte 
             *
             * 0 - Teamcolor Off
             * 2 - Teamcolor On*/
            TeamColor1 = (int)starcraft.MainModule.BaseAddress + 0x03141EA4;        //ok

            /* 4 Bytes 
             *
             * Devide by 4090 to get actual value 
             * Is 0 when not Ingame */
            TimerData = (int)starcraft.MainModule.BaseAddress + 0x0356EDF0;          //ok

            /* 4 Bytes */
            Gamespeed = (int)starcraft.MainModule.BaseAddress + 0x04F2A6B4;         //ok

            #endregion

            #region Outdated and Unused



            //Pause 
            PauseEnabled = (int)starcraft.MainModule.BaseAddress + 0x024C9E38; /* 0x022ab7b8
                                               * 0x25ef0b8 
                                               * 0x3de06e4 
                                               * 0x3e0fc20 */
            //Fps
            FramesPerSecond = (int)
                              starcraft.MainModule.BaseAddress + 0x03ED54DC;

            //Gametype 
            Gametype = 0x0176DCC8;

            #endregion
        }

        private void Version__2_1_5_32392(Process starcraft)
        {
            #region PlayerInformation

            //Playerinfo
            PlayerStruct = (int)starcraft.MainModule.BaseAddress + 0x03620CB0; //V

            PlayerStructSize = 0x0E18; //V

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
            RawPlayerName = 0x064;

            /* 4 Byte */
            RawPlayerClanTagLenght = 0x108;

            /* Max 6 signs */
            RawPlayerClanTag = 0x114;

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
            RawPlayerColor = 0x01B8;

            /* 4 Bytes 
             *
             * Devide by 4 to get actual value */
            RawPlayerNamelenght = 0x0B4;

            /* Unknown */
            RawPlayerAccountId = 0x210;         //ok

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerApmCurrent = 0x5F0;        //ok

            /* 4 Bytes */
            RawPlayerApmAverage = 0x5F8;        //ok

            /* 4 Bytes */
            RawPlayerEpmAverage = 0x638;        //ok

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerEpmCurrent = 0x630;        //ok

            /* 4 Bytes */
            RawPlayerWorkers = 0x7E0;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMin = 0x8B8;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMax = 0x8A0;

            /* 4 Bytes */
            RawPlayerMinerals = 0x8F8;

            /* 4 Bytes */
            RawPlayerGas = 0x900;

            /* 4 Bytes */
            RawPlayerMineralsIncome = 0x978;

            /* 4 Bytes */
            RawPlayerGasIncome = 0x980;

            /* 4 Bytes */
            RawPlayerMineralsArmy = 0xC60;

            /* 4 Bytes */
            RawPlayerGasArmy = 0xC88;


            #endregion

            #region UnitInformation

            //Unitinfo
            UnitStruct = (int)starcraft.MainModule.BaseAddress + 0x0369f580; //ok

            UnitStructSize = 0x1C0;

            /* 4 Bytes */
            UnitTotal = (int)starcraft.MainModule.BaseAddress + 0x0369F540;

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

            /* 4 Bytes */
            UnitMaxEnergy = 0x860;

            /* 4 Bytes  */
            UnitMaxShield = 0x88C;

            

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
            MapStruct = (int)starcraft.MainModule.BaseAddress + 0x0356EE50; /* V */
            MapFileInfoName = 0x2A0; /* DISAPPEARED :( */

            //Raw Mapadata
            RawMapLeft = 0x18;
            RawMapBottom = 0x1C;
            RawMapRight = 0x20;
            RawMapTop = 0x24;

            #endregion

            #region Selection - Unused & outdated

            //Selected stuff
            UiSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x046B6200; //ok
            UiTotalSelectedUnits = UiSelectionStruct + 0x0; //
            UiTotalSelectedTypes = UiSelectionStruct + 0x2; //
            UiSelectedType = UiSelectionStruct + 0x4; //
            UiSelectedIndex = UiSelectionStruct + 0xA; //
            UiSize = 4; //147

            UiRawSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x046B6200;
            UiRawTotalSelectedUnits = 0x0;
            UiRawTotalSelectedTypes = 0x2;
            UiRawSelectedType = 0x4;

            /* Is in a loop, has to be like this */
            UiRawSelectedIndex = 0xA;

            #endregion

            #region Groups - unused & outdated

            /* 4 Bytes */
            RawGroupBase = (int)starcraft.MainModule.BaseAddress + 0x046D3360;

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
            RaceStruct = (int)starcraft.MainModule.BaseAddress + 0x02FA0B90;        //ok
            RaceSize = 0x10;

            //UiChatInput
            ChatBase = (int)starcraft.MainModule.BaseAddress + 0x003140650;         //ok
            ChatOff0 = 0x398;
            ChatOff1 = 0x208;
            ChatOff2 = 0x000;
            ChatOff3 = 0x000;
            ChatOff4 = 0x014;

            /* 1 Byte */
            Localplayer4 = (int)starcraft.MainModule.BaseAddress + 0x011596A8;      //ok

            /* 1 Byte 
             *
             * 0 - Teamcolor Off
             * 2 - Teamcolor On*/
            TeamColor1 = (int)starcraft.MainModule.BaseAddress + 0x03141EA4;        //ok

            /* 4 Bytes 
             *
             * Devide by 4090 to get actual value 
             * Is 0 when not Ingame */
            TimerData = (int)starcraft.MainModule.BaseAddress + 0x0356EDF0;          //ok

            /* 4 Bytes */
            Gamespeed = (int)starcraft.MainModule.BaseAddress + 0x04F2A6B4;         //ok

            #endregion

            #region Outdated and Unused



            //Pause 
            PauseEnabled = (int)starcraft.MainModule.BaseAddress + 0x024C9E38; /* 0x022ab7b8
                                               * 0x25ef0b8 
                                               * 0x3de06e4 
                                               * 0x3e0fc20 */

            //Fps
            FramesPerSecond = (int)
                              starcraft.MainModule.BaseAddress + 0x03ED54DC;

            //Gametype 
            Gametype = 0x0176DCC8;

            #endregion
        }

        private void Version__2_1_9_34644(Process starcraft)
        {
            #region PlayerInformation

            //Playerinfo
            PlayerStruct = (int)starcraft.MainModule.BaseAddress + 0x03625F90; //k

            PlayerStructSize = 0x0E18; //k

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
            RawPlayerName = 0x064;

            /* 4 Byte */
            RawPlayerClanTagLenght = 0x108;

            /* Max 6 signs */
            RawPlayerClanTag = 0x114;

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
            RawPlayerColor = 0x01B8;

            /* 4 Bytes 
             *
             * Devide by 4 to get actual value */
            RawPlayerNamelenght = 0x0B4;

            /* Unknown */
            RawPlayerAccountId = 0x210;         //ok

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerApmCurrent = 0x5F0;        //ok

            /* 4 Bytes */
            RawPlayerApmAverage = 0x5F8;        //ok

            /* 4 Bytes */
            RawPlayerEpmAverage = 0x638;        //ok

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerEpmCurrent = 0x630;        //ok

            /* 4 Bytes */
            RawPlayerWorkers = 0x7E0;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMin = 0x8B8;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMax = 0x8A0;

            /* 4 Bytes */
            RawPlayerMinerals = 0x8F8;

            /* 4 Bytes */
            RawPlayerGas = 0x900;

            /* 4 Bytes */
            RawPlayerMineralsIncome = 0x978;

            /* 4 Bytes */
            RawPlayerGasIncome = 0x980;

            /* 4 Bytes */
            RawPlayerMineralsArmy = 0xC60;

            /* 4 Bytes */
            RawPlayerGasArmy = 0xC88;


            #endregion

            #region UnitInformation

            //Unitinfo
            UnitStruct = (int)starcraft.MainModule.BaseAddress + 0x036A4840; //k

            /* 4 Bytes */
            UnitTotal = (int)starcraft.MainModule.BaseAddress + 0x036A4800;

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

            /* 4 Bytes */
            UnitMaxEnergy = 0x860;

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
            MapStruct = (int)starcraft.MainModule.BaseAddress + 0x03574130;
            MapFileInfoName = 0x2A0; /* DISAPPEARED :( */

            //Raw Mapadata
            RawMapLeft = 0x18;
            RawMapBottom = 0x1C;
            RawMapRight = 0x20;
            RawMapTop = 0x24;

            #endregion

            #region Selection - Unused & outdated

            //Selected stuff
            UiSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x46BB200; //k
            UiTotalSelectedUnits = UiSelectionStruct + 0x0; //
            UiTotalSelectedTypes = UiSelectionStruct + 0x2; //
            UiSelectedType = UiSelectionStruct + 0x4; //
            UiSelectedIndex = UiSelectionStruct + 0xA; //
            UiSize = 4; //147

            UiRawSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x46BB200;
            UiRawTotalSelectedUnits = 0x0;
            UiRawTotalSelectedTypes = 0x2;
            UiRawSelectedType = 0x4;

            /* Is in a loop, has to be like this */
            UiRawSelectedIndex = 0xA;

            #endregion

            #region Groups - unused & outdated

            /* 4 Bytes */
            RawGroupBase = (int)starcraft.MainModule.BaseAddress + 0x046D8360;  //k

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
            RaceStruct = (int)starcraft.MainModule.BaseAddress + 0x2FA5B90;        //k
            RaceSize = 0x10;

            //UiChatInput
            ChatBase = (int)starcraft.MainModule.BaseAddress + 0x003145920;         //k
            ChatOff0 = 0x398;
            ChatOff1 = 0x208;
            ChatOff2 = 0x000;
            ChatOff3 = 0x000;
            ChatOff4 = 0x014;

            /* 1 Byte */
            Localplayer4 = (int)starcraft.MainModule.BaseAddress + 0x0115EED0;      //k
            
            /* 1 Byte 
             *
             * 0 - Teamcolor Off
             * 2 - Teamcolor On*/
            TeamColor1 = (int)starcraft.MainModule.BaseAddress + 0x03147184;        //k

            /* 4 Bytes 
             *
             * Devide by 4090 to get actual value 
             * Is 0 when not Ingame */
            TimerData = (int)starcraft.MainModule.BaseAddress + 0x035740D4;          //k

            /* 4 Bytes */
            Gamespeed = (int)starcraft.MainModule.BaseAddress + 0x04F2F6B4;         //k

            //4 Bytes
            FramesPerSecond = (int)
                starcraft.MainModule.BaseAddress + 0x05002BC4;

            //1 Byte
            PauseEnabled = (int)starcraft.MainModule.BaseAddress + 0x03574018;

            #endregion
        }

        private void Version__2_1_11_36281(Process starcraft)
        {
            #region PlayerInformation

            //Playerinfo
            PlayerStruct = (int)starcraft.MainModule.BaseAddress + 0x0362BF90;

            PlayerStructSize = 0x0E18;

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
            RawPlayerName = 0x064;

            /* 4 Byte */
            RawPlayerClanTagLenght = 0x108;

            /* Max 6 signs */
            RawPlayerClanTag = 0x114;

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
            RawPlayerColor = 0x01B8;

            /* 4 Bytes 
             *
             * Devide by 4 to get actual value */
            RawPlayerNamelenght = 0x0B4;

            /* Unknown */
            RawPlayerAccountId = 0x210;         //ok

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerApmCurrent = 0x5F0;        //ok

            /* 4 Bytes */
            RawPlayerApmAverage = 0x5F8;        //ok

            /* 4 Bytes */
            RawPlayerEpmAverage = 0x638;        //ok

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerEpmCurrent = 0x630;        //ok

            /* 4 Bytes */
            RawPlayerWorkers = 0x7E0;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMin = 0x8B8;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMax = 0x8A0;

            /* 4 Bytes */
            RawPlayerMinerals = 0x8F8;

            /* 4 Bytes */
            RawPlayerGas = 0x900;

            /* 4 Bytes */
            RawPlayerMineralsIncome = 0x978;

            /* 4 Bytes */
            RawPlayerGasIncome = 0x980;

            /* 4 Bytes */
            RawPlayerMineralsArmy = 0xC60;

            /* 4 Bytes */
            RawPlayerGasArmy = 0xC88;


            #endregion

            #region UnitInformation

            //Unitinfo
            UnitStruct = (int)starcraft.MainModule.BaseAddress + 0x036AA840;

            /* 4 Bytes */
            UnitTotal = (int)starcraft.MainModule.BaseAddress + 0x036AA800;

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

            /* 4 Bytes */
            UnitMaxEnergy = 0x860;

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
            MapStruct = (int)starcraft.MainModule.BaseAddress + 0x0357A130;
            MapFileInfoName = 0x2A0; /* DISAPPEARED :( */

            //Raw Mapadata
            RawMapLeft = 0x18;
            RawMapBottom = 0x1C;
            RawMapRight = 0x20;
            RawMapTop = 0x24;

            #endregion

            #region Selection - Unused & outdated

            //Selected stuff
            UiSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x046C1200;
            UiTotalSelectedUnits = UiSelectionStruct + 0x0; //
            UiTotalSelectedTypes = UiSelectionStruct + 0x2; //
            UiSelectedType = UiSelectionStruct + 0x4; //
            UiSelectedIndex = UiSelectionStruct + 0xA; //
            UiSize = 4; //147

            UiRawSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x46C1200;
            UiRawTotalSelectedUnits = 0x0;
            UiRawTotalSelectedTypes = 0x2;
            UiRawSelectedType = 0x4;

            /* Is in a loop, has to be like this */
            UiRawSelectedIndex = 0xA;

            #endregion

            #region Groups - unused & outdated

            /* 4 Bytes */
            RawGroupBase = (int)starcraft.MainModule.BaseAddress + 0x046DE360;

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
            RaceStruct = (int)starcraft.MainModule.BaseAddress + 0x02FABB90;
            RaceSize = 0x10;

            //UiChatInput
            ChatBase = (int)starcraft.MainModule.BaseAddress + 0x00314B920;
            ChatOff0 = 0x394;
            ChatOff1 = 0x160;
            ChatOff2 = 0x00C;
            ChatOff3 = 0x26C;
            ChatOff4 = 0x014;

            /* 1 Byte */
            Localplayer4 = (int)starcraft.MainModule.BaseAddress + 0x01164ED8;

            /* 1 Byte 
             *
             * 0 - Teamcolor Off
             * 2 - Teamcolor On*/
            TeamColor1 = (int)starcraft.MainModule.BaseAddress + 0x0314D184;

            /* 4 Bytes 
             *
             * Devide by 4090 to get actual value 
             * Is 0 when not Ingame */
            TimerData = (int)starcraft.MainModule.BaseAddress + 0x0357A0D4;

            /* 4 Bytes */
            Gamespeed = (int)starcraft.MainModule.BaseAddress + 0x04F356B4;

            //Not yet
            //4 Bytes
            FramesPerSecond = (int)
                starcraft.MainModule.BaseAddress + 0x05008BC4;

            //1 Byte
            PauseEnabled = (int)starcraft.MainModule.BaseAddress + 0x0357A018;

            #endregion
        }

        private void Version__2_1_12_36657(Process starcraft)
        {
            #region PlayerInformation

            //Playerinfo
            PlayerStruct = (int)starcraft.MainModule.BaseAddress + 0x0362BF90;

            PlayerStructSize = 0x0E18;

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
            RawPlayerName = 0x064;

            /* 4 Byte */
            RawPlayerClanTagLenght = 0x108;

            /* Max 6 signs */
            RawPlayerClanTag = 0x114;

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
            RawPlayerColor = 0x01B8;

            /* 4 Bytes 
             *
             * Devide by 4 to get actual value */
            RawPlayerNamelenght = 0x0B4;

            /* Unknown */
            RawPlayerAccountId = 0x210;         //ok

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerApmCurrent = 0x5F0;        //ok

            /* 4 Bytes */
            RawPlayerApmAverage = 0x5F8;        //ok

            /* 4 Bytes */
            RawPlayerEpmAverage = 0x638;        //ok

            // 4 Bytes
            RawPlayerUnitsInProduction = 0x06A0;

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerEpmCurrent = 0x630;        //ok

            /* 4 Bytes */
            RawPlayerWorkers = 0x7E0;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMin = 0x8B8;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMax = 0x8A0;

            /* 4 Bytes */
            RawPlayerMinerals = 0x8F8;

            /* 4 Bytes */
            RawPlayerGas = 0x900;

            /* 4 Bytes */
            RawPlayerMineralsIncome = 0x978;

            /* 4 Bytes */
            RawPlayerGasIncome = 0x980;

            /* 4 Bytes */
            RawPlayerMineralsArmy = 0xC60;

            /* 4 Bytes */
            RawPlayerGasArmy = 0xC88;


            #endregion

            #region UnitInformation

            //Unitinfo
            UnitStruct = (int)starcraft.MainModule.BaseAddress + 0x036AA840;

            /* 4 Bytes */
            UnitTotal = (int)starcraft.MainModule.BaseAddress + 0x036AA800;

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

            /* 4 Bytes */
            UnitMaxEnergy = 0x860;

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
            MapStruct = (int)starcraft.MainModule.BaseAddress + 0x0357A130;
            MapFileInfoName = 0x2A0; /* DISAPPEARED :( */

            //Raw Mapadata
            RawMapLeft = 0x18;
            RawMapBottom = 0x1C;
            RawMapRight = 0x20;
            RawMapTop = 0x24;

            #endregion

            #region Selection - Unused & outdated

            //Selected stuff
            UiSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x046C1200;
            UiTotalSelectedUnits = UiSelectionStruct + 0x0; //
            UiTotalSelectedTypes = UiSelectionStruct + 0x2; //
            UiSelectedType = UiSelectionStruct + 0x4; //
            UiSelectedIndex = UiSelectionStruct + 0xA; //
            UiSize = 4; //147

            UiRawSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x46C1200;
            UiRawTotalSelectedUnits = 0x0;
            UiRawTotalSelectedTypes = 0x2;
            UiRawSelectedType = 0x4;

            /* Is in a loop, has to be like this */
            UiRawSelectedIndex = 0xA;

            #endregion

            #region Groups - unused & outdated

            /* 4 Bytes */
            RawGroupBase = (int)starcraft.MainModule.BaseAddress + 0x046DE360;

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
            RaceStruct = (int)starcraft.MainModule.BaseAddress + 0x02FABB90;
            RaceSize = 0x10;

            //UiChatInput
            ChatBase = (int)starcraft.MainModule.BaseAddress + 0x00314B920;
            ChatOff0 = 0x394;
            ChatOff1 = 0x160;
            ChatOff2 = 0x00C;
            ChatOff3 = 0x26C;
            ChatOff4 = 0x014;

            /* 1 Byte */
            Localplayer4 = (int)starcraft.MainModule.BaseAddress + 0x01164ED8;

            /* 1 Byte 
             *
             * 0 - Teamcolor Off
             * 2 - Teamcolor On*/
            TeamColor1 = (int)starcraft.MainModule.BaseAddress + 0x0314D184;

            /* 4 Bytes 
             *
             * Devide by 4090 to get actual value 
             * Is 0 when not Ingame */
            TimerData = (int)starcraft.MainModule.BaseAddress + 0x0357A0D4;

            /* 4 Bytes */
            Gamespeed = (int)starcraft.MainModule.BaseAddress + 0x04F356B4;

            //Not yet
            //4 Bytes
            FramesPerSecond = (int)
                starcraft.MainModule.BaseAddress + 0x05008BC4;

            //1 Byte
            PauseEnabled = (int)starcraft.MainModule.BaseAddress + 0x0357A018;

            #endregion
        }

        private void Version__2_5_5_37164(Process starcraft)
        {
            #region PlayerInformation

            //Playerinfo
            PlayerStruct = (int)starcraft.MainModule.BaseAddress + 0x0362BF90;

            PlayerStructSize = 0x0E18;

            /* 4 Bytes */   
            RawPlayerCameraX = 0x008;   //1A2A3B0

            /* 4 Bytes */
            RawPlayerCameraY = 0x00C;   //1A2A3B4

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
            RawPlayerName = 0x064;

            /* 4 Byte */
            RawPlayerClanTagLenght = 0x108;

            /* Max 6 signs */
            RawPlayerClanTag = 0x114;

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
            RawPlayerColor = 0x01B8;

            /* 4 Bytes 
             *
             * Devide by 4 to get actual value */
            RawPlayerNamelenght = 0x0B4;

            /* Unknown */
            RawPlayerAccountId = 0x210;         //ok

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerApmCurrent = 0x5F0;        //ok

            /* 4 Bytes */
            RawPlayerApmAverage = 0x5F8;        //ok

            /* 4 Bytes */
            RawPlayerEpmAverage = 0x638;        //ok

            // 4 Bytes
            RawPlayerUnitsInProduction = 0x06A0;

            /* 4 Bytes 
             * 
             * Is a bit different when the time ticked a few mins.. */
            RawPlayerEpmCurrent = 0x630;        //ok

            /* 4 Bytes */
            RawPlayerWorkers = 0x7E0;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMin = 0x8B8;

            /* 4 Bytes
             *
             * Devide by 4096 to get actual count */
            RawPlayerSupplyMax = 0x8A0;

            /* 4 Bytes */
            RawPlayerMinerals = 0x8F8;

            /* 4 Bytes */
            RawPlayerGas = 0x900;

            /* 4 Bytes */
            RawPlayerMineralsIncome = 0x978;

            /* 4 Bytes */
            RawPlayerGasIncome = 0x980;

            /* 4 Bytes */
            RawPlayerMineralsArmy = 0xC60;

            /* 4 Bytes */
            RawPlayerGasArmy = 0xC88;


            #endregion

            #region UnitInformation

            //Unitinfo
            UnitStruct = (int)starcraft.MainModule.BaseAddress + 0x036AA840;

            /* 4 Bytes */
            UnitTotal = (int)starcraft.MainModule.BaseAddress + 0x036AA800;

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

            /* 4 Bytes */
            UnitMaxEnergy = 0x860;

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
            MapStruct = (int)starcraft.MainModule.BaseAddress + 0x01DB7AA4;
            MapFileInfoName = 0x2A0; /* DISAPPEARED :( */

            //Raw Mapadata
            RawMapLeft = 0x18;
            RawMapBottom = 0x1C;
            RawMapRight = 0x20;
            RawMapTop = 0x24;

            #endregion

            #region Selection - Unused & outdated

            //Selected stuff
            UiSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x01A2C050;
            UiTotalSelectedUnits = UiSelectionStruct + 0x0; //
            UiTotalSelectedTypes = UiSelectionStruct + 0x2; //
            UiSelectedType = UiSelectionStruct + 0x4; //
            UiSelectedIndex = UiSelectionStruct + 0xA; //
            UiSize = 4; //147

            UiRawSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x01A2C050;
            UiRawTotalSelectedUnits = 0x0;
            UiRawTotalSelectedTypes = 0x2;
            UiRawSelectedType = 0x4;

            /* Is in a loop, has to be like this */
            UiRawSelectedIndex = 0xA;

            #endregion

            #region Groups - unused & outdated

            /* 4 Bytes */
            RawGroupBase = (int)starcraft.MainModule.BaseAddress + 0x01A408D0;

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
            RaceStruct = (int)starcraft.MainModule.BaseAddress + 0x0516C1D0;
            RaceSize = 0x10;

            //UiChatInput
            ChatBase = (int)starcraft.MainModule.BaseAddress + 0x00343F5BC;
            ChatOff0 = 0x2B8;
            ChatOff1 = 0x05C;
            ChatOff2 = 0x098;
            ChatOff3 = 0x13C;
            ChatOff4 = 0x014;

            /* 1 Byte */
            Localplayer4 = (int)starcraft.MainModule.BaseAddress + 0x01164ED8;  //ToDo

            /* 1 Byte 
             *
             * 0 - Teamcolor Off
             * 2 - Teamcolor On*/
            TeamColor1 = (int)starcraft.MainModule.BaseAddress + 0x018954B8; //Or: 0x1A29C50

            /* 4 Bytes 
             *
             * Devide by 4090 to get actual value 
             * Is 0 when not Ingame */
            TimerData = (int)starcraft.MainModule.BaseAddress + 0x01A1D670; //Or: 0x1DB7A20

            // 4 Bytes
            Gamespeed = (int)starcraft.MainModule.BaseAddress + 0x03257204;

            #endregion
        }

    }
}
