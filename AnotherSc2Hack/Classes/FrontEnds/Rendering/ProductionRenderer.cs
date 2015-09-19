using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using PredefinedTypes;
using Utilities.ExtensionMethods;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    public class ProductionRenderer : BaseRenderer
    {
        /* Size for Unit/ Productionsize */
        private int _iProdPanelWidth;
        private int _iProdPanelWidthWithoutName;
        private int _iProdPosAfterName;

        public ProductionRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
            : base(gInformation, pSettings, sc2Process)
        {
            IsHiddenChanged += ProductionRenderer_IsHiddenChanged;
        }

        /// <summary>
        ///     Draws the panelspecific data.
        /// </summary>
        /// <param name="g"></param>
        protected override void Draw(BufferedGraphics g)
        {
            try
            {
                if (!GInformation.Gameinfo.IsIngame)
                    return;

                Opacity = PSettings.PreferenceAll.OverlayProduction.Opacity;

                /* Add the feature that the window (in case you have all races and more units than your display can hold) 
                 * will split the units to the next line */

                /* Count all included units */
                //CountUnits();
                CountUnits();

                var iHavetoadd = 0; //Adds +1 when a neutral player is on position 0
                var iSize = PSettings.PreferenceAll.OverlayProduction.PictureSize;
                var iPosY = 0;
                var iPosX = 0;
                var iPosYName = 0;

                var iMaximumWidth = 0;
                var fsize = (float) (iSize/3.5);
                var iPosXAfterName = (int) (fsize*14);
                    /* We take the fontsize times the (probably) with a common String- lenght*/
                var iPosYInitial = iPosY;

                var iWidthUnits = 0;
                var iWidthBuildings = 0;
                var iWidthUpgrades = 0;

                if (fsize < 1)
                    fsize = 1;

                var fStringFont = new Font(PSettings.PreferenceAll.OverlayProduction.FontName, fsize, FontStyle.Regular);


                /* Define the startposition of the picture drawing
                 * using the longest name as reference */
                var strPlayerName = string.Empty;
                for (var i = 0; i < GInformation.Player.Count; i++)
                {
                    var strTemp = (GInformation.Player[i].ClanTag.StartsWith("\0") ||
                                   PSettings.PreferenceAll.OverlayProduction.RemoveClanTag)
                        ? GInformation.Player[i].Name
                        : "[" + GInformation.Player[i].ClanTag + "] " + GInformation.Player[i].Name;

                    if (strTemp.Length >= strPlayerName.Length)
                        strPlayerName = strTemp;
                }

                iPosXAfterName = TextRenderer.MeasureText(strPlayerName, fStringFont).Width + 20;


                /* Fix the size of the icons to 25x25 */
                for (var i = 0; i < GInformation.Player.Count; i++)
                {
                    var clPlayercolor = GInformation.Player[i].Color;

                    var tmpPlayer = GInformation.Player[i];

                    #region Teamcolor

                    if (GInformation.Gameinfo.IsTeamcolor)
                    {
                        if (Player.LocalPlayer != null)
                        {
                            if (GInformation.Player[i] == Player.LocalPlayer)
                                clPlayercolor = Color.Green;

                            else if (GInformation.Player[i].Team ==
                                     Player.LocalPlayer.Team &&
                                     GInformation.Player[i] != Player.LocalPlayer)
                                clPlayercolor = Color.Yellow;

                            else
                                clPlayercolor = Color.Red;
                        }
                    }

                    #endregion

                    #region Exceptions - Throw out players

                    /* Remove Ai - Works */
                    if (PSettings.PreferenceAll.OverlayProduction.RemoveAi)
                    {
                        if (GInformation.Player[i].Type == PlayerType.Ai)
                        {
                            continue;
                        }
                    }

                    /* Remove Neutral - Works */
                    if (PSettings.PreferenceAll.OverlayProduction.RemoveNeutral)
                    {
                        if (tmpPlayer.Type == PlayerType.Neutral)
                        {
                            continue;
                        }
                    }

                    /* Remove Localplayer - Works */
                    if (PSettings.PreferenceAll.OverlayProduction.RemoveLocalplayer)
                    {
                        if (tmpPlayer == Player.LocalPlayer)
                            continue;
                    }

                    /* Remove Allie - Works */
                    if (PSettings.PreferenceAll.OverlayProduction.RemoveAllie)
                    {
                        if (tmpPlayer.Team == Player.LocalPlayer.Team &&
                            tmpPlayer != Player.LocalPlayer)
                        {
                            continue;
                        }
                    }

                    if (GInformation.Player[i].Type.Equals(PlayerType.Hostile))
                        continue;

                    if (GInformation.Player[i].Type.Equals(PlayerType.Observer))
                        continue;

                    if (GInformation.Player[i].Type.Equals(PlayerType.Referee))
                        continue;

                    #endregion

                    if (GInformation.Player[i].Name.Length <= 0 ||
                        GInformation.Player[i].Name.StartsWith("\0"))
                        continue;

                    if (CheckIfGameheart(GInformation.Player[i]))
                        continue;


                    iPosX = 0;

                    /* Draw Name in front of Icons */
                    var strName = (GInformation.Player[i].ClanTag.StartsWith("\0") ||
                                   PSettings.PreferenceAll.OverlayProduction.RemoveClanTag)
                        ? GInformation.Player[i].Name
                        : "[" + GInformation.Player[i].ClanTag + "] " + GInformation.Player[i].Name;

                    //Name gets drawn after the icon- drawing is done!


                    iPosX = iPosXAfterName;

                    #region Draw Units

                    if (PSettings.PreferenceAll.OverlayProduction.ShowUnits)
                    {
                        /* Terran */
                        Helper_DrawUnitsProduction(LTuScv, i, ref iPosX, iPosY, iSize, ImgTuScv, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(LTuMarine, i, ref iPosX, iPosY, iSize, ImgTuMarine, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTuMarauder, i, ref iPosX, iPosY, iSize, ImgTuMarauder, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTuReaper, i, ref iPosX, iPosY, iSize, ImgTuReaper, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTuGhost, i, ref iPosX, iPosY, iSize, ImgTuGhost, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(LTuMule, i, ref iPosX, iPosY, iSize, ImgTuMule, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(LTuHellion, i, ref iPosX, iPosY, iSize, ImgTuHellion, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTuHellbat, i, ref iPosX, iPosY, iSize, ImgTuHellbat, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTuWidowMine, i, ref iPosX, iPosY, iSize, ImgTuWidowMine, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTuSiegetank, i, ref iPosX, iPosY, iSize, ImgTuSiegetank, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTuThor, i, ref iPosX, iPosY, iSize, ImgTuThor, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(LTuMedivac, i, ref iPosX, iPosY, iSize, ImgTuMedivac, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTuBanshee, i, ref iPosX, iPosY, iSize, ImgTuBanshee, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTuViking, i, ref iPosX, iPosY, iSize, ImgTuViking, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTuRaven, i, ref iPosX, iPosY, iSize, ImgTuRaven, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(LTuBattlecruiser, i, ref iPosX, iPosY, iSize, ImgTuBattlecruiser, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTbAutoTurret, i, ref iPosX, iPosY, iSize, ImgTbAutoTurret, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTuPointDefenseDrone, i, ref iPosX, iPosY, iSize,
                            ImgTuPointDefenseDrone, g, clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTuNuke, i, ref iPosX, iPosY, iSize,
                            ImgTuNuke, g, clPlayercolor, fStringFont, false);


                        /* Protoss */
                        Helper_DrawUnitsProduction(LPuProbe, i, ref iPosX, iPosY, iSize, ImgPuProbe, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(LPuZealot, i, ref iPosX, iPosY, iSize, ImgPuZealot, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuStalker, i, ref iPosX, iPosY, iSize, ImgPuStalker, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuSentry, i, ref iPosX, iPosY, iSize, ImgPuSentry, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuDt, i, ref iPosX, iPosY, iSize, ImgPuDarkTemplar, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuHt, i, ref iPosX, iPosY, iSize, ImgPuHighTemplar, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuArchon, i, ref iPosX, iPosY, iSize, ImgPuArchon, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuImmortal, i, ref iPosX, iPosY, iSize, ImgPuImmortal, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuColossus, i, ref iPosX, iPosY, iSize, ImgPuColossus, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuObserver, i, ref iPosX, iPosY, iSize, ImgPuObserver, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuWarpprism, i, ref iPosX, iPosY, iSize, ImgPuWapprism, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuPhoenix, i, ref iPosX, iPosY, iSize, ImgPuPhoenix, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuVoidray, i, ref iPosX, iPosY, iSize, ImgPuVoidray, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuOracle, i, ref iPosX, iPosY, iSize, ImgPuOracle, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuCarrier, i, ref iPosX, iPosY, iSize, ImgPuCarrier, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuTempest, i, ref iPosX, iPosY, iSize, ImgPuTempest, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuMothershipcore, i, ref iPosX, iPosY, iSize, ImgPuMothershipcore,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPuMothership, i, ref iPosX, iPosY, iSize, ImgPuMothership, g,
                            clPlayercolor, fStringFont, false);

                        /* Zerg */
                        Helper_DrawUnitsProduction(LZuLarva, i, ref iPosX, iPosY, iSize, ImgZuLarva, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(LZuDrone, i, ref iPosX, iPosY, iSize, ImgZuDrone, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(LZuOverlord, i, ref iPosX, iPosY, iSize, ImgZuOverlord, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZuQueen, i, ref iPosX, iPosY, iSize, ImgZuQueen, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(LZuZergling, i, ref iPosX, iPosY, iSize, ImgZuZergling, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZuBaneling, i, ref iPosX, iPosY, iSize, ImgZuBaneling, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZuBanelingCocoon, i, ref iPosX, iPosY, iSize, ImgZuBanelingCocoon,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZuRoach, i, ref iPosX, iPosY, iSize, ImgZuRoach, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(LZuHydra, i, ref iPosX, iPosY, iSize, ImgZuHydra, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(LZuMutalisk, i, ref iPosX, iPosY, iSize, ImgZuMutalisk, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZuInfestor, i, ref iPosX, iPosY, iSize, ImgZuInfestor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZuOverseer, i, ref iPosX, iPosY, iSize, ImgZuOverseer, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZuOverseerCocoon, i, ref iPosX, iPosY, iSize, ImgZuOvserseerCocoon,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZuSwarmhost, i, ref iPosX, iPosY, iSize, ImgZuSwarmhost, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZuUltralisk, i, ref iPosX, iPosY, iSize, ImgZuUltra, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZuViper, i, ref iPosX, iPosY, iSize, ImgZuViper, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnitsProduction(LZuCorruptor, i, ref iPosX, iPosY, iSize, ImgZuCorruptor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZuBroodlord, i, ref iPosX, iPosY, iSize, ImgZuBroodlord, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZuBroodlordCocoon, i, ref iPosX, iPosY, iSize,
                            ImgZuBroodlordCocoon,
                            g, clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZuInfestedTerran, i, ref iPosX, iPosY, iSize,
                           ImgInfestedTerran,
                           g, clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZuInfestedTerranEgg, i, ref iPosX, iPosY, iSize,
                           ImgInfestedTerranEgg,
                           g, clPlayercolor, fStringFont, false);

                        /* Maximum for the units */
                        iWidthUnits = iPosX;
                    }

                    #endregion

                    #region - Split Units and Buildings -

                    if (PSettings.PreferenceAll.OverlayProduction.SplitBuildingsAndUnits)
                    {
                        iHavetoadd = 0;


                        if (GInformation.Player[0].Type == PlayerType.Neutral)
                            iHavetoadd += 1;

                        if (i == iHavetoadd)
                        {
                            if (iPosX > iPosXAfterName)
                            {
                                iPosY += iSize + 2;
                                iPosX = iPosXAfterName;
                            }
                        }

                        else if (i > iHavetoadd)
                        {
                            if (iPosX > iPosXAfterName)
                            {
                                iPosY += iSize + 2;
                                iPosX = iPosXAfterName;
                            }
                        }

                        if (PSettings.PreferenceAll.OverlayProduction.UseTransparentImages)
                            iPosY += 3;
                    }

                    #endregion

                    #region Draw Buildings

                    if (PSettings.PreferenceAll.OverlayProduction.ShowBuildings)
                    {
                        /* Terran */
                        Helper_DrawUnitsProduction(LTbCommandCenter, i,
                            ref iPosX, iPosY, iSize, ImgTbCc, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LTbOrbitalCommand, i,
                            ref iPosX, iPosY, iSize, ImgTbOc, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTbPlanetaryFortress, i,
                            ref iPosX, iPosY, iSize, ImgTbPf, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTbSupply, i, ref iPosX, iPosY,
                            iSize, ImgTbSupply, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LTbRefinery, i, ref iPosX, iPosY,
                            iSize, ImgTbRefinery, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LTbBunker, i, ref iPosX, iPosY,
                            iSize, ImgTbBunker, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LTbTechlab, i, ref iPosX, iPosY,
                            iSize, ImgTbTechlab, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LTbReactor, i, ref iPosX, iPosY,
                            iSize, ImgTbReactor, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LTbTurrent, i, ref iPosX, iPosY,
                            iSize, ImgTbTurrent, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LTbSensorTower, i, ref iPosX,
                            iPosY, iSize, ImgTbSensorTower, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LTbEbay, i, ref iPosX, iPosY, iSize,
                            ImgTbEbay, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LTbGhostAcademy, i, ref iPosX,
                            iPosY, iSize, ImgTbGhostacademy, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LTbArmory, i, ref iPosX, iPosY,
                            iSize, ImgTbArmory, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LTbFusionCore, i, ref iPosX,
                            iPosY, iSize, ImgTbFusioncore, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LTbBarracks, i, ref iPosX, iPosY,
                            iSize, ImgTbBarracks, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LTbFactory, i, ref iPosX, iPosY,
                            iSize, ImgTbFactory, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LTbStarport, i, ref iPosX, iPosY,
                            iSize, ImgTbStarport, g,
                            clPlayercolor, fStringFont, true);


                        /* Protoss */
                        Helper_DrawUnitsProduction(LPbNexus, i, ref iPosX, iPosY, iSize, ImgPbNexus, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnitsProduction(LPbPylon, i, ref iPosX, iPosY, iSize, ImgPbPylon, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnitsProduction(LPbAssimilator, i, ref iPosX, iPosY, iSize, ImgPbAssimilator, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LPbCannon, i, ref iPosX, iPosY, iSize, ImgPbCannon, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LPbDarkshrine, i, ref iPosX, iPosY, iSize, ImgPbDarkShrine, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LPbTemplarArchives, i, ref iPosX, iPosY, iSize,
                            ImgPbTemplarArchives,
                            g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LPbTwilight, i, ref iPosX, iPosY, iSize, ImgPbTwillightCouncil, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LPbCybercore, i, ref iPosX, iPosY, iSize, ImgPbCybercore, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LPbForge, i, ref iPosX, iPosY, iSize, ImgPbForge, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnitsProduction(LPbFleetbeacon, i, ref iPosX, iPosY, iSize, ImgPbFleetBeacon, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LPbRoboticsSupport, i, ref iPosX, iPosY, iSize,
                            ImgPbRoboticsSupport,
                            g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LPbGateway, i, ref iPosX, iPosY, iSize, ImgPbGateway, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LPbWarpgate, i, ref iPosX, iPosY, iSize, ImgPbWarpgate, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LPbStargate, i, ref iPosX, iPosY, iSize, ImgPbStargate, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LPbRobotics, i, ref iPosX, iPosY, iSize, ImgPbRobotics, g,
                            clPlayercolor, fStringFont, true);

                        /* Zerg */
                        Helper_DrawUnitsProduction(LZbCreepTumor, i, ref iPosX, iPosY, iSize, ImgZbCreepTumor, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LZbHatchery, i, ref iPosX, iPosY, iSize, ImgZbHatchery, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LZbLair, i, ref iPosX, iPosY, iSize, ImgZbLair, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnitsProduction(LZbHive, i, ref iPosX, iPosY, iSize, ImgZbHive, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnitsProduction(LZbSpawningpool, i, ref iPosX, iPosY, iSize, ImgZbSpawningpool, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LZbEvochamber, i, ref iPosX, iPosY, iSize, ImgZbEvochamber, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LZbExtractor, i, ref iPosX, iPosY, iSize, ImgZbExtractor, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LZbSpine, i, ref iPosX, iPosY, iSize, ImgZbSpinecrawler, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LZbSpore, i, ref iPosX, iPosY, iSize, ImgZbSporecrawler, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LZbHydraden, i, ref iPosX, iPosY, iSize, ImgZbHydraden, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LZbRoachwarren, i, ref iPosX, iPosY, iSize, ImgZbRoachwarren, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LZbSpire, i, ref iPosX, iPosY, iSize, ImgZbSpire, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnitsProduction(LZbGreaterspire, i, ref iPosX, iPosY, iSize, ImgZbGreaterspire, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LZbUltracavern, i, ref iPosX, iPosY, iSize, ImgZbUltracavern, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LZbInfestationpit, i, ref iPosX, iPosY, iSize, ImgZbInfestationpit,
                            g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LZbBanelingnest, i, ref iPosX, iPosY, iSize, ImgZbBanelingnest, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LZbNydusbegin, i, ref iPosX, iPosY, iSize, ImgZbNydusNetwork, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnitsProduction(LZbNydusend, i, ref iPosX, iPosY, iSize, ImgZbNydusWorm, g,
                            clPlayercolor, fStringFont, true);

                        iWidthBuildings = iPosX;
                    }

                    #endregion

                    #region - Split Units and Buildings -

                    if (PSettings.PreferenceAll.OverlayProduction.SplitBuildingsAndUnits)
                    {
                        iHavetoadd = 0;


                        if (GInformation.Player[0].Type == PlayerType.Neutral)
                            iHavetoadd += 1;

                        if (i == iHavetoadd)
                        {
                            if (iPosX > iPosXAfterName)
                            {
                                iPosY += iSize + 2;
                                iPosX = iPosXAfterName;
                            }
                        }

                        else if (i > iHavetoadd)
                        {
                            if (iPosX > iPosXAfterName)
                            {
                                iPosY += iSize + 2;
                                iPosX = iPosXAfterName;
                            }
                        }

                        if (PSettings.PreferenceAll.OverlayProduction.UseTransparentImages)
                            iPosY += 3;
                    }

                    #endregion

                    #region Upgrades

                    if (PSettings.PreferenceAll.OverlayProduction.ShowUpgrades)
                    {
                        #region Terran

                        Helper_DrawUnitsProduction(LTupStim, i, ref iPosX, iPosY, iSize, ImgTupStim, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupCombatShields, i, ref iPosX, iPosY, iSize, ImgTupCombatShields,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupConcussiveShells, i, ref iPosX, iPosY, iSize,
                            ImgTupConcussiveShells, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupBlueFlame, i, ref iPosX, iPosY, iSize, ImgTupBlueFlame, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupDrillingClaws, i, ref iPosX, iPosY, iSize, ImgTupDrillingClaws,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupTransformationServos, i, ref iPosX, iPosY, iSize,
                            ImgTupTransformatorServos, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupPersonalCloak, i, ref iPosX, iPosY, iSize, ImgTupPersonalCloak,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupMoebiusReactor, i, ref iPosX, iPosY, iSize,
                            ImgTupMoebiusReactor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupWeaponRefit, i, ref iPosX, iPosY, iSize, ImgTupWeaponRefit, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupBehemothReactor, i, ref iPosX, iPosY, iSize,
                            ImgTupBehemothReacot, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupCloakingField, i, ref iPosX, iPosY, iSize, ImgTupCloakingField,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupCorvidReactor, i, ref iPosX, iPosY, iSize, ImgTupCorvidReactor,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupCaduceusReactor, i, ref iPosX, iPosY, iSize,
                            ImgTupCaduceusReactor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupDurableMaterials, i, ref iPosX, iPosY, iSize,
                            ImgTupDurableMaterials, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupVehicleShipPlanting1, i, ref iPosX, iPosY, iSize,
                            ImgTupVehicleShipPlanting1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupVehicleShipPlanting2, i, ref iPosX, iPosY, iSize,
                            ImgTupVehicleShipPlanting2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupVehicleShipPlanting3, i, ref iPosX, iPosY, iSize,
                            ImgTupVehicleShipPlanting3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupVehicleWeapon1, i, ref iPosX, iPosY, iSize,
                            ImgTupVehicleWeapon1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupVehicleWeapon2, i, ref iPosX, iPosY, iSize,
                            ImgTupVehicleWeapon2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupVehicleWeapon3, i, ref iPosX, iPosY, iSize,
                            ImgTupVehicleWeapon3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupShipWeapon1, i, ref iPosX, iPosY, iSize, ImgTupShipWeapon1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupShipWeapon2, i, ref iPosX, iPosY, iSize, ImgTupShipWeapon2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupShipWeapon3, i, ref iPosX, iPosY, iSize, ImgTupShipWeapon3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupInfantryArmor1, i, ref iPosX, iPosY, iSize,
                            ImgTupInfantryArmor1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupInfantryArmor2, i, ref iPosX, iPosY, iSize,
                            ImgTupInfantryArmor2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupInfantryArmor3, i, ref iPosX, iPosY, iSize,
                            ImgTupInfantryArmor3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupInfantryWeapon1, i, ref iPosX, iPosY, iSize,
                            ImgTupInfantryWeapon1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupInfantryWeapon2, i, ref iPosX, iPosY, iSize,
                            ImgTupInfantryWeapon2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupInfantryWeapon3, i, ref iPosX, iPosY, iSize,
                            ImgTupInfantryWeapon3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupHighSecAutoTracking, i, ref iPosX, iPosY, iSize,
                            ImgTupHighSecAutoTracking, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupStructureArmor, i, ref iPosX, iPosY, iSize,
                            ImgTupStructureArmor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LTupNeosteelFrame, i, ref iPosX, iPosY, iSize, ImgTupNeosteelFrame,
                            g,
                            clPlayercolor, fStringFont, false);

                        #endregion

                        #region Protoss

                        Helper_DrawUnitsProduction(LPupAirArmor1, i, ref iPosX, iPosY, iSize, ImgPupAirArmor1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupAirArmor2, i, ref iPosX, iPosY, iSize, ImgPupAirArmor2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupAirArmor3, i, ref iPosX, iPosY, iSize, ImgPupAirArmor3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupAirWeapon1, i, ref iPosX, iPosY, iSize, ImgPupAirWeapon1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupAirWeapon2, i, ref iPosX, iPosY, iSize, ImgPupAirWeapon2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupAirWeapon3, i, ref iPosX, iPosY, iSize, ImgPupAirWeapon3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupGroundWeapon1, i, ref iPosX, iPosY, iSize, ImgPupGroundWeapon1,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupGroundWeapon2, i, ref iPosX, iPosY, iSize, ImgPupGroundWeapon2,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupGroundWeapon3, i, ref iPosX, iPosY, iSize, ImgPupGroundWeapon3,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupGroundArmor1, i, ref iPosX, iPosY, iSize, ImgPupGroundArmor1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupGroundArmor2, i, ref iPosX, iPosY, iSize, ImgPupGroundArmor2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupGroundArmor3, i, ref iPosX, iPosY, iSize, ImgPupGroundArmor3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupShield1, i, ref iPosX, iPosY, iSize, ImgPupShield1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupShield2, i, ref iPosX, iPosY, iSize, ImgPupShield2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupShield3, i, ref iPosX, iPosY, iSize, ImgPupShield3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupExtendedThermalLance, i, ref iPosX, iPosY, iSize,
                            ImgPupExtendedThermalLance, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupGraviticBooster, i, ref iPosX, iPosY, iSize,
                            ImgPupGraviticBooster, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupGraviticDrive, i, ref iPosX, iPosY, iSize, ImgPupGraviticDrive,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupGravitonCatapult, i, ref iPosX, iPosY, iSize,
                            ImgPupGravitonCatapult, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupStorm, i, ref iPosX, iPosY, iSize, ImgPupStorm, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupBlink, i, ref iPosX, iPosY, iSize, ImgPupBlink, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupCharge, i, ref iPosX, iPosY, iSize, ImgPupCharge, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupAnionPulseCrystal, i, ref iPosX, iPosY, iSize,
                            ImgPupAnionPulseCrystals, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LPupWarpGate, i, ref iPosX, iPosY, iSize, ImgPupWarpGate, g,
                            clPlayercolor, fStringFont, false);

                        #endregion

                        #region Zerg

                        Helper_DrawUnitsProduction(LZupAdrenalGlands, i, ref iPosX, iPosY, iSize, ImgZupAdrenalGlands,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupAirArmor1, i, ref iPosX, iPosY, iSize, ImgZupAirArmor1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupAirArmor2, i, ref iPosX, iPosY, iSize, ImgZupAirArmor2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupAirArmor3, i, ref iPosX, iPosY, iSize, ImgZupAirArmor3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupAirWeapon1, i, ref iPosX, iPosY, iSize, ImgZupAirWeapon1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupAirWeapon2, i, ref iPosX, iPosY, iSize, ImgZupAirWeapon2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupAirWeapon3, i, ref iPosX, iPosY, iSize, ImgZupAirWeapon3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupBurrow, i, ref iPosX, iPosY, iSize, ImgZupBurrow, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupCentrifugalHooks, i, ref iPosX, iPosY, iSize,
                            ImgZupCentrifugalHooks, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupChitinousPlating, i, ref iPosX, iPosY, iSize,
                            ImgZupChitinousPlating, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupEnduringLocusts, i, ref iPosX, iPosY, iSize,
                            ImgZupEnduringLocusts, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupFlyingLocust, i, ref iPosX, iPosY, iSize,
                            ImgZupFlyingLocust, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupGlialReconstruction, i, ref iPosX, iPosY, iSize,
                            ImgZupGlialReconstruction, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupGroovedSpines, i, ref iPosX, iPosY, iSize, ImgZupGroovedSpines,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupGroundArmor1, i, ref iPosX, iPosY, iSize, ImgZupGroundArmor1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupGroundArmor2, i, ref iPosX, iPosY, iSize, ImgZupGroundArmor2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupGroundArmor3, i, ref iPosX, iPosY, iSize, ImgZupGroundArmor3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupGroundMelee1, i, ref iPosX, iPosY, iSize, ImgZupGroundMelee1, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupGroundMelee2, i, ref iPosX, iPosY, iSize, ImgZupGroundMelee2, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupGroundMelee3, i, ref iPosX, iPosY, iSize, ImgZupGroundMelee3, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupGroundWeapon1, i, ref iPosX, iPosY, iSize, ImgZupGroundWeapon1,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupGroundWeapon2, i, ref iPosX, iPosY, iSize, ImgZupGroundWeapon2,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupGroundWeapon3, i, ref iPosX, iPosY, iSize, ImgZupGroundWeapon3,
                            g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupMetabolicBoost, i, ref iPosX, iPosY, iSize,
                            ImgZupMetabolicBoost, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupMuscularAugments, i, ref iPosX, iPosY, iSize,
                            ImgZupMuscularAugments, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupNeutralParasite, i, ref iPosX, iPosY, iSize,
                            ImgZupNeutralParasite, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupPathoglenGlands, i, ref iPosX, iPosY, iSize,
                            ImgZupPathoglenGlands, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupPneumatizedCarapace, i, ref iPosX, iPosY, iSize,
                            ImgZupPneumatizedCarapace, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupTunnnelingClaws, i, ref iPosX, iPosY, iSize,
                            ImgZupTunnelingClaws, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnitsProduction(LZupVentralSacs, i, ref iPosX, iPosY, iSize, ImgZupVentrallSacs, g,
                            clPlayercolor, fStringFont, false);

                        #endregion

                        iWidthUpgrades = iPosX;
                    }

                    #endregion

                    if (iPosX > iPosXAfterName)
                    {
                        iPosY += iSize + 2;

                        if (PSettings.PreferenceAll.OverlayProduction.UseTransparentImages)
                            iPosY += 5;
                    }


                    /* Check which width is bigger */
                    //if (iWidthUnits > iWidthBuildings)
                    //{
                    //    if (iWidthUnits > iWidthUpgrades)
                    //        iPosX = iWidthUnits;

                    //    else if (iWidthUpgrades > iWidthUnits)
                    //        iPosX = iWidthUpgrades;
                    //}

                    //else if (iWidthBuildings > iWidthUnits)
                    //{
                    //    if (iWidthBuildings > iWidthUpgrades)
                    //        iPosX = iWidthBuildings;

                    //    else if (iWidthUpgrades > iWidthBuildings)
                    //        iPosX = iWidthUpgrades;
                    //}

                    //else if (iWidthUpgrades > iWidthUnits)
                    //{
                    //    if (iWidthBuildings > iWidthUpgrades)
                    //        iPosX = iWidthBuildings;

                    //    else if (iWidthUpgrades > iWidthBuildings)
                    //        iPosX = iWidthUpgrades;
                    //}

                    var iWidthMax = HelpFunctions.GetMaximumInteger(iWidthBuildings, iWidthUnits, iWidthUpgrades);
                    iPosX = iWidthMax;

                    //iPosX = iWidthUnits > iWidthBuildings ? iWidthUnits : iWidthBuildings;

                    //iPosX = iWidthUnits > iWidthBuildings ? iWidthUnits : iWidthBuildings;

                    /* Adjust maximum width */
                    if (iPosX >= iMaximumWidth)
                        iMaximumWidth = iPosX;

                    if (iHavetoadd > 0)
                        iMaximumWidth += iSize;


                    if (iWidthMax > iPosXAfterName)
                    {
                        g.Graphics.DrawString(
                            strName,
                            fStringFont,
                            new SolidBrush(clPlayercolor),
                            Brushes.Black, 0 + 10,
                            iPosYName + 10,
                            1f, 1f, true);
                    }

                    iPosYName = iPosY;
                }

                if (FormBorderStyle == FormBorderStyle.None)
                {
                    Width = iMaximumWidth + 1;
                    Height = iPosY;
                }

                else
                {
                    _iProdPanelWidth = iMaximumWidth + 1;
                    _iProdPanelWidthWithoutName = _iProdPanelWidth - iPosXAfterName;
                    _iProdPosAfterName = iPosXAfterName;
                }
            }

            catch (Exception ex)
            {
                Messages.LogFile("Over all", ex);
            }
        }

        /// <summary>
        ///     Sends the panel specific data into the Form's controls and settings
        /// </summary>
        protected override void MouseUpTransferData()
        {
            /* Has to be calculated manually because each panels has it's own Neutral handling.. */
            var iValidPlayerCount = GInformation.Gameinfo.ValidPlayerCount;

            PSettings.PreferenceAll.OverlayProduction.X = Location.X;
            PSettings.PreferenceAll.OverlayProduction.Y = Location.Y;
            PSettings.PreferenceAll.OverlayProduction.Width = Width;
            PSettings.PreferenceAll.OverlayProduction.Height = Height/iValidPlayerCount;
            PSettings.PreferenceAll.OverlayProduction.Opacity = Opacity;
        }

        /// <summary>
        ///     Sends the panel specific data into the Form's controls and settings
        /// </summary>
        protected override void MouseWheelTransferData(MouseEventArgs e)
        {
            if (e.Delta.Equals(120))
            {
                PSettings.PreferenceAll.OverlayProduction.PictureSize += 1;
            }

            else if (e.Delta.Equals(-120))
            {
                PSettings.PreferenceAll.OverlayProduction.PictureSize -= 1;
            }
        }

        /// <summary>
        ///     Sends the panel specific data into the Form's controls and settings
        ///     Also changes the Size directly!
        /// </summary>
        protected override void AdjustPanelSize()
        {
            if (BSetSize)
            {
                tmrRefreshGraphic.Interval = 20;

                PSettings.PreferenceAll.OverlayProduction.Width = Cursor.Position.X - Left;

                if ((Cursor.Position.Y - Top) >= 5)
                    PSettings.PreferenceAll.OverlayProduction.Height = (Cursor.Position.Y - Top);

                else
                    PSettings.PreferenceAll.OverlayProduction.Height = 5;
            }

            var strInput = StrBackupSizeChatbox;

            if (string.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));


            if (strInput.Equals(PSettings.PreferenceAll.OverlayProduction.ChangeSize))
            {
                if (BToggleSize)
                {
                    BToggleSize = !BToggleSize;

                    if (!BSetSize)
                        BSetSize = true;
                }
            }

            if (HelpFunctions.HotkeysPressed(Keys.Enter))
            {
                tmrRefreshGraphic.Interval = PSettings.PreferenceAll.Global.DrawingRefresh;

                BSetSize = false;
                StrBackupSizeChatbox = string.Empty;
            }
        }

        /// <summary>
        ///     Loads the settings of the specific Form into the controls (Location, Size)
        /// </summary>
        protected override void LoadPreferencesIntoControls()
        {
            Location = new Point(PSettings.PreferenceAll.OverlayProduction.X,
                PSettings.PreferenceAll.OverlayProduction.Y);
            Opacity = PSettings.PreferenceAll.OverlayProduction.Opacity;
        }

        /// <summary>
        ///     Sends the panel specific data into the Form's controls and settings
        ///     Also changes the Position directly!
        /// </summary>
        protected override void AdjustPanelPosition()
        {
            if (BSetPosition)
            {
                tmrRefreshGraphic.Interval = 20;

                Location = Cursor.Position;
                PSettings.PreferenceAll.OverlayProduction.X = Cursor.Position.X;
                PSettings.PreferenceAll.OverlayProduction.Y = Cursor.Position.Y;
            }

            var strInput = StrBackupChatbox;

            if (string.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));

            if (strInput.Equals(PSettings.PreferenceAll.OverlayProduction.ChangePosition))
            {
                if (BTogglePosition)
                {
                    BTogglePosition = !BTogglePosition;

                    if (!BSetPosition)
                        BSetPosition = true;
                }
            }

            if (HelpFunctions.HotkeysPressed(Keys.Enter))
            {
                BSetPosition = false;
                StrBackupChatbox = string.Empty;
                tmrRefreshGraphic.Interval = PSettings.PreferenceAll.Global.DrawingRefresh;
            }
        }

        /// <summary>
        ///     Loads some specific data into the Form.
        /// </summary>
        protected override void LoadSpecificData()
        {
        }

        private void ProductionRenderer_IsHiddenChanged(object sender, EventArgs e)
        {
            PSettings.PreferenceAll.OverlayProduction.LaunchStatus = !IsHidden;
        }

        /// <summary>
        ///     Changes settings for a specific Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BaseRenderer_ResizeEnd(object sender, EventArgs e)
        {
            /* Required to avoid the size of the border [FormBorderStyle] */
            var tmpOld = FormBorderStyle;
            FormBorderStyle = FormBorderStyle.None;

            /* Calculate amount of unitpictures - width */
            var iAmount = _iProdPanelWidthWithoutName/PSettings.PreferenceAll.OverlayProduction.PictureSize;
            PSettings.PreferenceAll.OverlayProduction.PictureSize = (Width - (_iProdPosAfterName + 1))/
                                                                    iAmount;


            FormBorderStyle = tmpOld;

            /* Temporarily reset interval */
            var oldInterval = tmrRefreshGraphic.Interval;
            tmrRefreshGraphic.Interval = 1;


            tmrRefreshGraphic.Interval = oldInterval;

            PSettings.PreferenceAll.OverlayProduction.X = Location.X;
            PSettings.PreferenceAll.OverlayProduction.Y = Location.Y;
        }

        /* Draw the units */

        private void Helper_DrawUnitsProduction(List<UnitCount> units, int index, ref int posX, int posY, int size,
            Image img,
            BufferedGraphics g, Color clPlayercolor, Font font, bool isStructure)
        {
            if (units == null ||
                units.Count <= 0)
                return;

            var unit = units[index];


            /* Unitamount defines all buildings*/
            if (isStructure)
                unit.UnitAmount -= unit.UnitUnderConstruction;

            /* If there is nothing to draw.. */
            if (unit.UnitUnderConstruction == 0)
                return;

            if (unit.ConstructionState == null)
                return;

            if (unit.ConstructionState.Count == 0)
                return;

            if (float.IsNaN(unit.ConstructionState[0]) ||
                unit.ConstructionState[0].Equals(0.0f))
                return;

            g.Graphics.DrawImage(img, posX, posY, size, size);


            if (unit.UnitUnderConstruction > 0)
            {
                var bDraw = false;

                if (unit.SpeedMultiplier.Count > 0)
                {
                    /* If any of them is above 4069... */
                    foreach (var speed in unit.SpeedMultiplier)
                    {
                        if (speed > 4096)
                        {
                            bDraw = true;
                            break;
                        }
                    }
                }


                if (bDraw && !PSettings.PreferenceAll.OverlayProduction.RemoveChronoboost)
                {
                    HelpFunctions.HelpGraphics.FillRoundRectangle(g.Graphics,
                        new SolidBrush(Color.FromArgb(100, Color.White)),
                        posX + size - 22,
                        posY + 3, 19, 19, 5);
                    g.Graphics.DrawImage(ImgSpeedArrow, new Rectangle(posX + size - 20, posY + 5, 15, 15));
                }


                float fWidth;

                if (unit.UnitUnderConstruction.ToString(CultureInfo.InvariantCulture).Length == 1)
                    fWidth = unit.UnitUnderConstruction.ToString(CultureInfo.InvariantCulture).Length*(font.Size + 4);

                else
                    fWidth = unit.UnitUnderConstruction.ToString(CultureInfo.InvariantCulture).Length*(font.Size);

                HelpFunctions.HelpGraphics.FillRoundRectangle(g.Graphics,
                    new SolidBrush(Color.FromArgb(100, Color.Black)),
                    posX + 1, posY + font.Size + 10, fWidth, font.Size + 9, 5);


                g.Graphics.DrawString(unit.UnitUnderConstruction.ToString(CultureInfo.InvariantCulture), font,
                    Brushes.Orange, posX + 2,
                    posY + font.Size + 9);


                /* Adjust relative size */
                float ftemp = size - 4;
                ftemp *= (unit.ConstructionState[0]/100);

                var iOffset = 5;

                if (!PSettings.PreferenceAll.OverlayProduction.UseTransparentImages)
                    iOffset = 0;


                /* Draw status- line */
                g.Graphics.DrawLine(new Pen(Brushes.Yellow, 2), posX + 2, posY + size - 3 + iOffset,
                    posX + 2 + (int) ftemp,
                    posY + size - 3 + iOffset);
                g.Graphics.DrawRectangle(new Pen(Brushes.Black, 1), posX + 2, posY + size - 5 + iOffset, size - 3, 3);
            }

            if (!PSettings.PreferenceAll.OverlayProduction.UseTransparentImages)
                g.Graphics.DrawRectangle(new Pen(new SolidBrush(clPlayercolor), 2), posX, posY, size, size);

            posX += size;
        }
    }
}