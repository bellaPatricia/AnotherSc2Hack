using System;
using System.Diagnostics;
using System.Windows.Forms;
using Utilities.Processing;

namespace AnotherSc2Hack.Classes.BackEnds
{
    public class Offsets
    {
        #region create variables for Addresses

        public int PlayerStruct { get; set; }
        public int PlayerStructSize { get; set; }
        public int UnitStruct { get; set; }
        public int MapStruct { get; set; }

        public int RawPlayerCameraX { get; set; }
        public int RawPlayerCameraY { get; set; }
        public int RawPlayerCameraRotation { get; set; }
        public int RawPlayerCameraDistance { get; set; }
        public int RawPlayerCameraAngle { get; set; }
        public int RawPlayerPlayertype { get; set; }
        public int RawPlayerStatus { get; set; }
        public int RawPlayerDifficulty { get; set; }
        public int RawPlayerNamelenght { get; set; }
        public int RawPlayerName { get; set; }
        public int RawPlayerColor { get; set; }
        public int RawPlayerAccountId { get; set; }
        public int RawPlayerClanTag { get; set; }
        public int RawPlayerClanTagLenght { get; set; }
        public int RawPlayerApmCurrent { get; set; }
        public int RawPlayerEpmCurrent { get; set; }
        public int RawPlayerApmAverage { get; set; }
        public int RawPlayerEpmAverage { get; set; }
        public int RawPlayerTeam { get; set; }
        public int RawPlayerWorkers { get; set; }
        public int RawPlayerUnitsInProduction { get; set; }
        public int RawPlayerSupplyMin { get; set; }
        public int RawPlayerSupplyMax { get; set; }
        public int RawPlayerMinerals { get; set; }
        public int RawPlayerGas { get; set; }
        public int RawPlayerMineralsIncome { get; set; }
        public int RawPlayerGasIncome { get; set; }
        public int RawPlayerMineralsArmy { get; set; }
        public int RawPlayerGasArmy { get; set; }
        public int RawPlayerLocalplayer { get; set; }
        public int RawPlayerCurrentBuildings { get; set; }

        public int RawGroupBase = 0x31CE258;

        public int RawGroupSize = 0x1b60;

        public int RawGroupAmountofUnits = 0x00;

        public int RawGroupUnitIndex = 0x0A;

        public int RawGroupUnitIndexSize = 0x04;

        public int RaceStruct { get; set; }

        public int RaceSize { get; set; }

        public int Team { get; set; }

        public int TeamSize { get; set; }

        public int ChatBase = 0x017AB3C8;

        public int ChatOff0 = 0x398;

        public int ChatOff1 = 0x21C;

        public int ChatOff2 = 0x004;

        public int ChatOff3 = 0x004;

        public int ChatOff4 = 0x014;

        public int Localplayer4 { get; set; }

        public int RawUnitPosX { get; set; }

        public int RawUnitPosY { get; set; }

        public int RawUnitTargetFilter { get; set; }

        public int RawUnitDestinationX { get; set; }

        public int RawUnitDestinationY { get; set; }

        public int RawUnitEnergy { get; set; }

        public int RawUnitAliveSince { get; set; }

        public int RawUnitDamageTaken { get; set; }

        public int RawUnitSpeedMultiplier { get; set; }

        public int RawUnitBuildingState { get; set; }

        public int RawUnitOwner { get; set; }

        public int RawUnitShieldDamageTaken { get; set; }

        public int RawUnitLastOrder { get; set; }

        public int RawUnitState { get; set; }

        public int RawUnitModel { get; set; }

        public int RawUnitMovestate { get; set; }

        public int RawUnitRandomFlag { get; set; }

        public int UnitTotal { get; set; }

        public int UnitModel { get; set; }

        public int UnitStringStruct { get; set; }

        public int UnitString { get; set; }

        public int UnitStructSize { get; set; }

        public int UnitMaxShield { get; set; }

        public int UnitModelId { get; set; }

        public int UnitMaxHealth { get; set; }

        public int UnitMaxEnergy { get; set; }

        public int UnitModelSize { get; set; }

        public int MapIngame { get; set; }

        public int MapFileInfoName { get; set; }

        public int RawMapTop { get; set; }

        public int RawMapBottom { get; set; }

        public int RawMapRight { get; set; }

        public int RawMapLeft { get; set; }

        public int UiSelectionStruct { get; set; }

        public int UiTotalSelectedUnits { get; set; }

        public int UiTotalSelectedTypes { get; set; }

        public int UiSelectedType { get; set; }

        public int UiSelectedIndex { get; set; }

        public int UiSize { get; set; }

        public int UiRawSelectionStruct { get; set; }

        public int UiRawTotalSelectedUnits { get; set; }

        public int UiRawTotalSelectedTypes { get; set; }

        public int UiRawSelectedType { get; set; }

        public int UiRawSelectedIndex { get; set; }

        public int TeamColor { get; set; }

        public int TimerData { get; set; }

        public int Gamespeed { get; set; }        

        public int Gametype { get; set; }

        #endregion

        public event EventHandler OffsetsNotProperlySet;

        private Process _starcraft = null;

        public void OnOffsetsNotProperlySet(object o, EventArgs e)
        {
            if (OffsetsNotProperlySet != null)
                OffsetsNotProperlySet(o, e);
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

            if (starcraftVersion.Equals("3.0.3.38749"))
                Version__3_0_3_38749(_starcraft);

            else
            {
                MessageBox.Show("This tool is outdated.\n" +
                                "Please be so kind and create a post in the forum\n" +
                                "so I can update it!\n\n" + 
                "Maybe it's still possible to use\n" + 
                "this tool. Give it a shot!", "Ouch... new SCII version!?");

                Version__3_0_3_38749(_starcraft);
                
                OnOffsetsNotProperlySet(this, new EventArgs());
            }
        }

        private void Version__3_0_3_38749(Process starcraft)
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
            UnitTotal = (int)starcraft.MainModule.BaseAddress + 0x01EA2DC0; // or 1EA2DC4

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
            UiSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x01EE9BB8;
            UiTotalSelectedUnits = UiSelectionStruct + 0x0; //
            UiTotalSelectedTypes = UiSelectionStruct + 0x2; //
            UiSelectedType = UiSelectionStruct + 0x4; //
            UiSelectedIndex = UiSelectionStruct + 0xA; //
            UiSize = 4; //147

            UiRawSelectionStruct = (int)starcraft.MainModule.BaseAddress + 0x01EE9BB8;
            UiRawTotalSelectedUnits = 0x0;
            UiRawTotalSelectedTypes = 0x2;
            UiRawSelectedType = 0x4;

            /* Is in a loop, has to be like this */
            UiRawSelectedIndex = 0xA;

            #endregion

            #region Groups - unused & outdated

            /* 4 Bytes */
            RawGroupBase = (int)starcraft.MainModule.BaseAddress + 0x01EEEDD8;

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

            //Race Player 1+2
            RaceStruct = (int)starcraft.MainModule.BaseAddress + 0x4B043280;
            RaceSize = 0x30;

            //UiChatInput /k
            ChatBase = (int)starcraft.MainModule.BaseAddress + 0x024DEBCC;
            ChatOff0 = 0x1DC;
            ChatOff1 = 0x070;
            ChatOff2 = 0x114;
            ChatOff3 = 0x0;
            ChatOff4 = 0x020;

            /* 1 Byte */
            Localplayer4 = (int)starcraft.MainModule.BaseAddress + 0x1B7A9E0;

            /* 1 Byte k
             *
             * 0 - Teamcolor Off
             * 2 - Teamcolor On*/
            TeamColor = (int)starcraft.MainModule.BaseAddress + 0x1B7A174; //or 247EE24

            /* 4 Bytes 
             *
             * Devide by 4090 to get actual value 
             * Is 0 when not Ingame */
            TimerData = (int)starcraft.MainModule.BaseAddress + 0x1A71DC4; //1B7963C or 1BA7428

            //4 byte k
            Gamespeed = (int)starcraft.MainModule.BaseAddress + 0x055E133C;

            #endregion
        }

    }
}