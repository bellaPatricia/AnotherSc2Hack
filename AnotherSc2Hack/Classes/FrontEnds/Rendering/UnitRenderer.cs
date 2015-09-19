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
    public class UnitRenderer : BaseRenderer
    {
        /* Size for Unit/ Productionsize */
        private int _iUnitPanelWidth;
        private int _iUnitPanelWidthWithoutName;
        private int _iUnitPosAfterName;

        public UnitRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
            : base(gInformation, pSettings, sc2Process)
        {
            IsHiddenChanged += UnitRenderer_IsHiddenChanged;
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

                Opacity = PSettings.PreferenceAll.OverlayUnits.Opacity;

                /* Add the feature that the window (in case you have all races and more units than your display can hold) 
                 * will split the units to the next line */

                /* Count all included units */

                //_swMainWatch.Reset();
                //_swMainWatch.Start();

                CountUnits();

                //_swMainWatch.Stop();
                //Console.WriteLine(Math.Round(1000000.0 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency, 2) + " µs");


                var iSize = PSettings.PreferenceAll.OverlayUnits.PictureSize;
                var iPosY = 0;
                var iPosX = 0;

                var iMaximumWidth = 0;
                var fsize = (float) (iSize/3.5);
                var iPosXAfterName = (int) (fsize*14);
                /* We take the fontsize times the (probably) with a common String- lenght*/

                var iWidthUnits = 0;
                var iWidthBuildings = 0;

                if (fsize < 1)
                    fsize = 1;

                var fStringFont = new Font(PSettings.PreferenceAll.OverlayUnits.FontName, fsize, FontStyle.Regular);


                /* Define the startposition of the picture drawing
                 * using the longest name as reference */
                var strPlayerName = string.Empty;
                for (var i = 0; i < GInformation.Player.Count; i++)
                {
                    var strTemp = (GInformation.Player[i].ClanTag.StartsWith("\0") ||
                                   PSettings.PreferenceAll.OverlayUnits.RemoveClanTag)
                        ? GInformation.Player[i].Name
                        : "[" + GInformation.Player[i].ClanTag + "] " +
                          GInformation.Player[i].Name;

                    if (strTemp.Length >= strPlayerName.Length)
                        strPlayerName = strTemp;
                }

                iPosXAfterName = TextRenderer.MeasureText(strPlayerName, fStringFont).Width + 20;

                /* Fix the size of the icons to 25x25 */
                for (var i = 0; i < GInformation.Player.Count; i++)
                {
                    //_swMainWatch.Reset();
                    //_swMainWatch.Start();

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
                    if (PSettings.PreferenceAll.OverlayUnits.RemoveAi)
                    {
                        if (tmpPlayer.Type == PlayerType.Ai)
                        {
                            continue;
                        }
                    }

                    /* Remove Neutral - Works */
                    if (PSettings.PreferenceAll.OverlayUnits.RemoveNeutral)
                    {
                        if (tmpPlayer.Type == PlayerType.Neutral)
                        {
                            continue;
                        }
                    }

                    /* Remove Localplayer - Works */
                    if (PSettings.PreferenceAll.OverlayUnits.RemoveLocalplayer)
                    {
                        if (tmpPlayer == Player.LocalPlayer)
                            continue;
                    }

                    /* Remove Allie - Works */
                    if (PSettings.PreferenceAll.OverlayUnits.RemoveAllie)
                    {
                        if (tmpPlayer.Team ==
                            Player.LocalPlayer.Team &&
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
                                   PSettings.PreferenceAll.OverlayUnits.RemoveClanTag)
                        ? GInformation.Player[i].Name
                        : "[" + GInformation.Player[i].ClanTag + "] " +
                          GInformation.Player[i].Name;

                    g.Graphics.DrawString(
                        strName,
                        fStringFont,
                        new SolidBrush(clPlayercolor),
                        Brushes.Black, iPosX + 10,
                        iPosY + 10,
                        1f, 1f, true);

                    iPosX = iPosXAfterName;

                    #region Draw Units

                    if (PSettings.PreferenceAll.OverlayUnits.ShowUnits)
                    {
                        /* Terran */
                        Helper_DrawUnits(LTuScv, i, ref iPosX, iPosY, iSize, ImgTuScv, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LTuMarine, i, ref iPosX, iPosY, iSize, ImgTuMarine, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LTuMarauder, i, ref iPosX, iPosY, iSize, ImgTuMarauder, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LTuReaper, i, ref iPosX, iPosY, iSize, ImgTuReaper, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LTuGhost, i, ref iPosX, iPosY, iSize, ImgTuGhost, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LTuMule, i, ref iPosX, iPosY, iSize, ImgTuMule, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LTuHellion, i, ref iPosX, iPosY, iSize, ImgTuHellion, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LTuHellbat, i, ref iPosX, iPosY, iSize, ImgTuHellbat, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LTuWidowMine, i, ref iPosX, iPosY, iSize, ImgTuWidowMine, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LTuSiegetank, i, ref iPosX, iPosY, iSize, ImgTuSiegetank, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LTuThor, i, ref iPosX, iPosY, iSize, ImgTuThor, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LTuMedivac, i, ref iPosX, iPosY, iSize, ImgTuMedivac, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LTuBanshee, i, ref iPosX, iPosY, iSize, ImgTuBanshee, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LTuViking, i, ref iPosX, iPosY, iSize, ImgTuViking, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LTuRaven, i, ref iPosX, iPosY, iSize, ImgTuRaven, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LTuBattlecruiser, i, ref iPosX, iPosY, iSize, ImgTuBattlecruiser, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LTuPointDefenseDrone, i, ref iPosX, iPosY, iSize, ImgTuPointDefenseDrone,
                            g, clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LTuNuke, i, ref iPosX, iPosY, iSize,
                            ImgTuNuke, g, clPlayercolor, fStringFont, false);


                        /* Protoss */
                        Helper_DrawUnits(LPuProbe, i, ref iPosX, iPosY, iSize, ImgPuProbe, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LPuZealot, i, ref iPosX, iPosY, iSize, ImgPuZealot, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LPuStalker, i, ref iPosX, iPosY, iSize, ImgPuStalker, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LPuSentry, i, ref iPosX, iPosY, iSize, ImgPuSentry, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LPuDt, i, ref iPosX, iPosY, iSize, ImgPuDarkTemplar, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LPuHt, i, ref iPosX, iPosY, iSize, ImgPuHighTemplar, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LPuArchon, i, ref iPosX, iPosY, iSize, ImgPuArchon, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LPuImmortal, i, ref iPosX, iPosY, iSize, ImgPuImmortal, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LPuColossus, i, ref iPosX, iPosY, iSize, ImgPuColossus, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LPuObserver, i, ref iPosX, iPosY, iSize, ImgPuObserver, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LPuWarpprism, i, ref iPosX, iPosY, iSize, ImgPuWapprism, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LPuPhoenix, i, ref iPosX, iPosY, iSize, ImgPuPhoenix, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LPuVoidray, i, ref iPosX, iPosY, iSize, ImgPuVoidray, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LPuOracle, i, ref iPosX, iPosY, iSize, ImgPuOracle, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LPuCarrier, i, ref iPosX, iPosY, iSize, ImgPuCarrier, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LPuTempest, i, ref iPosX, iPosY, iSize, ImgPuTempest, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LPuMothershipcore, i, ref iPosX, iPosY, iSize, ImgPuMothershipcore, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LPuMothership, i, ref iPosX, iPosY, iSize, ImgPuMothership, g,
                            clPlayercolor, fStringFont, false);


                        /* Zerg */
                        Helper_DrawUnits(LZuDrone, i, ref iPosX, iPosY, iSize, ImgZuDrone, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LZuOverlord, i, ref iPosX, iPosY, iSize, ImgZuOverlord, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LZuQueen, i, ref iPosX, iPosY, iSize, ImgZuQueen, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LZuZergling, i, ref iPosX, iPosY, iSize, ImgZuZergling, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LZuBaneling, i, ref iPosX, iPosY, iSize, ImgZuBaneling, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LZuBanelingCocoon, i, ref iPosX, iPosY, iSize, ImgZuBanelingCocoon, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LZuRoach, i, ref iPosX, iPosY, iSize, ImgZuRoach, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LZuHydra, i, ref iPosX, iPosY, iSize, ImgZuHydra, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LZuMutalisk, i, ref iPosX, iPosY, iSize, ImgZuMutalisk, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LZuInfestor, i, ref iPosX, iPosY, iSize, ImgZuInfestor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LZuOverseer, i, ref iPosX, iPosY, iSize, ImgZuOverseer, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LZuOverseerCocoon, i, ref iPosX, iPosY, iSize, ImgZuOvserseerCocoon, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LZuSwarmhost, i, ref iPosX, iPosY, iSize, ImgZuSwarmhost, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LZuUltralisk, i, ref iPosX, iPosY, iSize, ImgZuUltra, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LZuViper, i, ref iPosX, iPosY, iSize, ImgZuViper, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LZuCorruptor, i, ref iPosX, iPosY, iSize, ImgZuCorruptor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LZuBroodlord, i, ref iPosX, iPosY, iSize, ImgZuBroodlord, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LZuBroodlordCocoon, i, ref iPosX, iPosY, iSize, ImgZuBroodlordCocoon,
                            g, clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LZuLocust, i, ref iPosX, iPosY, iSize, ImgZuLocust, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LZuFlyingLocust, i, ref iPosX, iPosY, iSize, ImgZuFlyingLocust, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LZuBroodling, i, ref iPosX, iPosY, iSize, ImgZuBroodling, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LZuLarva, i, ref iPosX, iPosY, iSize, ImgZuLarva, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LZuChangeling, i, ref iPosX, iPosY, iSize, ImgZuChangeling, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LZuInfestedTerran, i, ref iPosX, iPosY, iSize, ImgInfestedTerran, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LZuInfestedTerranEgg, i, ref iPosX, iPosY, iSize, ImgInfestedTerranEgg, g, clPlayercolor,
                           fStringFont, false);

                        /* Maximum for the units */
                        iWidthUnits = iPosX;
                    }

                    #endregion

                    #region - Split Units and Buildings -

                    if (PSettings.PreferenceAll.OverlayUnits.SplitBuildingsAndUnits)
                    {
                        var iHavetoadd = 0; //Adds +1 when a neutral player is on position 0


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

                        if (PSettings.PreferenceAll.OverlayUnits.UseTransparentImages)
                            iPosY += 3;
                    }

                    #endregion

                    #region Draw Buildings

                    if (PSettings.PreferenceAll.OverlayUnits.ShowBuildings)
                    {
                        /* Terran */
                        Helper_DrawUnits(LTbCommandCenter, i,
                            ref iPosX, iPosY, iSize, ImgTbCc, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbOrbitalCommand, i,
                            ref iPosX, iPosY, iSize, ImgTbOc, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LTbPlanetaryFortress, i,
                            ref iPosX, iPosY, iSize, ImgTbPf, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LTbSupply, i, ref iPosX, iPosY,
                            iSize, ImgTbSupply, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbRefinery, i, ref iPosX, iPosY,
                            iSize, ImgTbRefinery, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbBunker, i, ref iPosX, iPosY,
                            iSize, ImgTbBunker, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbTechlab, i, ref iPosX, iPosY,
                            iSize, ImgTbTechlab, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbReactor, i, ref iPosX, iPosY,
                            iSize, ImgTbReactor, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbTurrent, i, ref iPosX, iPosY,
                            iSize, ImgTbTurrent, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbSensorTower, i, ref iPosX,
                            iPosY, iSize, ImgTbSensorTower, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbEbay, i, ref iPosX, iPosY, iSize,
                            ImgTbEbay, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbGhostAcademy, i, ref iPosX,
                            iPosY, iSize, ImgTbGhostacademy, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbArmory, i, ref iPosX, iPosY,
                            iSize, ImgTbArmory, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbFusionCore, i, ref iPosX,
                            iPosY, iSize, ImgTbFusioncore, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbBarracks, i, ref iPosX, iPosY,
                            iSize, ImgTbBarracks, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbFactory, i, ref iPosX, iPosY,
                            iSize, ImgTbFactory, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbStarport, i, ref iPosX, iPosY,
                            iSize, ImgTbStarport, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LTbAutoTurret, i, ref iPosX, iPosY, iSize, ImgTbAutoTurret, g,
                            clPlayercolor, fStringFont, false);


                        /* Protoss */
                        Helper_DrawUnits(LPbNexus, i, ref iPosX, iPosY, iSize, ImgPbNexus, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(LPbPylon, i, ref iPosX, iPosY, iSize, ImgPbPylon, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(LPbAssimilator, i, ref iPosX, iPosY, iSize, ImgPbAssimilator, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LPbCannon, i, ref iPosX, iPosY, iSize, ImgPbCannon, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(LPbDarkshrine, i, ref iPosX, iPosY, iSize, ImgPbDarkShrine, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LPbTemplarArchives, i, ref iPosX, iPosY, iSize, ImgPbTemplarArchives,
                            g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LPbTwilight, i, ref iPosX, iPosY, iSize, ImgPbTwillightCouncil, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LPbCybercore, i, ref iPosX, iPosY, iSize, ImgPbCybercore, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LPbForge, i, ref iPosX, iPosY, iSize, ImgPbForge, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(LPbFleetbeacon, i, ref iPosX, iPosY, iSize, ImgPbFleetBeacon, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LPbRoboticsSupport, i, ref iPosX, iPosY, iSize, ImgPbRoboticsSupport,
                            g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LPbGateway, i, ref iPosX, iPosY, iSize, ImgPbGateway, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(LPbWarpgate, i, ref iPosX, iPosY, iSize, ImgPbWarpgate, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LPbStargate, i, ref iPosX, iPosY, iSize, ImgPbStargate, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LPbRobotics, i, ref iPosX, iPosY, iSize, ImgPbRobotics, g,
                            clPlayercolor, fStringFont, true);

                        /* Zerg */
                        Helper_DrawUnits(LZbCreepTumor, i, ref iPosX, iPosY, iSize, ImgZbCreepTumor, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LZbHatchery, i, ref iPosX, iPosY, iSize, ImgZbHatchery, g,
                            clPlayercolor, fStringFont, true);
                        //Note: Since Lairs/ Hives can not be placed plainly on the ground, we have to hack here
                        //We'll pretend them to be units so we don't subtract the units in procution from the unitamount
                        Helper_DrawUnits(LZbLair, i, ref iPosX, iPosY, iSize, ImgZbLair, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LZbHive, i, ref iPosX, iPosY, iSize, ImgZbHive, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(LZbSpawningpool, i, ref iPosX, iPosY, iSize, ImgZbSpawningpool, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LZbEvochamber, i, ref iPosX, iPosY, iSize, ImgZbEvochamber, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LZbExtractor, i, ref iPosX, iPosY, iSize, ImgZbExtractor, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LZbSpine, i, ref iPosX, iPosY, iSize, ImgZbSpinecrawler, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LZbSpore, i, ref iPosX, iPosY, iSize, ImgZbSporecrawler, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LZbHydraden, i, ref iPosX, iPosY, iSize, ImgZbHydraden, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LZbRoachwarren, i, ref iPosX, iPosY, iSize, ImgZbRoachwarren, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LZbSpire, i, ref iPosX, iPosY, iSize, ImgZbSpire, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(LZbGreaterspire, i, ref iPosX, iPosY, iSize, ImgZbGreaterspire, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(LZbUltracavern, i, ref iPosX, iPosY, iSize, ImgZbUltracavern, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LZbInfestationpit, i, ref iPosX, iPosY, iSize, ImgZbInfestationpit, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LZbBanelingnest, i, ref iPosX, iPosY, iSize, ImgZbBanelingnest, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LZbNydusbegin, i, ref iPosX, iPosY, iSize, ImgZbNydusNetwork, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(LZbNydusend, i, ref iPosX, iPosY, iSize, ImgZbNydusWorm, g,
                            clPlayercolor, fStringFont, true);

                        iWidthBuildings = iPosX;
                    }

                    #endregion

                    if (iPosX > iPosXAfterName)
                    {
                        iPosY += iSize + 2;

                        if (PSettings.PreferenceAll.OverlayUnits.UseTransparentImages)
                            iPosY += 5;
                    }

                    /* Check which width is bigger */
                    iPosX = iWidthUnits > iWidthBuildings ? iWidthUnits : iWidthBuildings;

                    /* Adjust maximum width */
                    if (iPosX >= iMaximumWidth)
                        iMaximumWidth = iPosX;

                    //if (iHavetoadd > 0)
                    //    iMaximumWidth += iSize;

                    //_swMainWatch.Stop();
                    //Debug.WriteLine("Time to execute Playerrun in DrawUnits:" + 1000000 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency + " µs");
                }

                /* Forcefield */
                iPosX = iPosXAfterName;
                Helper_DrawUnits(LPuForcefield, GInformation.Player.Count, ref iPosX, iPosY, iSize,
                    ImgPupForcefield, g,
                    Color.White, fStringFont, false);
                iPosY += iSize + 5;

                if (FormBorderStyle == FormBorderStyle.None)
                {
                    Width = iMaximumWidth + 1;
                    Height = iPosY;
                }

                else
                {
                    _iUnitPanelWidth = iMaximumWidth + 1;
                    _iUnitPanelWidthWithoutName = _iUnitPanelWidth - iPosXAfterName;
                    _iUnitPosAfterName = iPosXAfterName;
                }
            }

            catch (IndexOutOfRangeException)
            {
                //This will get thrown if a list with unitinformation is empty.
                //For now we can't do anything about it.
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

            PSettings.PreferenceAll.OverlayUnits.X = Location.X;
            PSettings.PreferenceAll.OverlayUnits.Y = Location.Y;
            PSettings.PreferenceAll.OverlayUnits.Width = Width;
            PSettings.PreferenceAll.OverlayUnits.Height = Height/iValidPlayerCount;
            PSettings.PreferenceAll.OverlayUnits.Opacity = Opacity;
        }

        /// <summary>
        ///     Sends the panel specific data into the Form's controls and settings
        /// </summary>
        protected override void MouseWheelTransferData(MouseEventArgs e)
        {
            if (e.Delta.Equals(120))
            {
                PSettings.PreferenceAll.OverlayUnits.PictureSize += 1;
            }

            else if (e.Delta.Equals(-120))
            {
                PSettings.PreferenceAll.OverlayUnits.PictureSize -= 1;
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

                PSettings.PreferenceAll.OverlayUnits.Width = Cursor.Position.X - Left;

                if ((Cursor.Position.Y - Top) >= 5)
                    PSettings.PreferenceAll.OverlayUnits.Height = (Cursor.Position.Y - Top);

                else
                    PSettings.PreferenceAll.OverlayUnits.Height = 5;
            }

            var strInput = StrBackupSizeChatbox;

            if (string.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));


            if (strInput.Equals(PSettings.PreferenceAll.OverlayUnits.ChangeSize))
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
            Location = new Point(PSettings.PreferenceAll.OverlayUnits.X,
                PSettings.PreferenceAll.OverlayUnits.Y);
            Opacity = PSettings.PreferenceAll.OverlayUnits.Opacity;
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
                PSettings.PreferenceAll.OverlayUnits.X = Cursor.Position.X;
                PSettings.PreferenceAll.OverlayUnits.Y = Cursor.Position.Y;
            }

            var strInput = StrBackupChatbox;

            if (string.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));

            if (strInput.Equals(PSettings.PreferenceAll.OverlayUnits.ChangePosition))
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

        private void UnitRenderer_IsHiddenChanged(object sender, EventArgs e)
        {
            PSettings.PreferenceAll.OverlayUnits.LaunchStatus = !IsHidden;
        }

        /// <summary>
        ///     Changes settings for a specific Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BaseRenderer_ResizeEnd(object sender, EventArgs e)
        {
            /* If the Valid Player count is zero, change it.. */
            var iValidPlayerCount = GInformation.Gameinfo.ValidPlayerCount;

            var iRealPlayerCount = iValidPlayerCount == 0 ? 1 : iValidPlayerCount;

            /* Required to avoid the size of the border [FormBorderStyle] */
            var tmpOld = FormBorderStyle;
            FormBorderStyle = FormBorderStyle.None;

            /* Calculate amount of unitpictures - width */
            var iAmount = _iUnitPanelWidthWithoutName/PSettings.PreferenceAll.OverlayUnits.PictureSize;
            PSettings.PreferenceAll.OverlayUnits.PictureSize = (Width - (_iUnitPosAfterName + 1))/
                                                               iAmount;


            FormBorderStyle = tmpOld;

            /* Temporarily reset interval */
            var oldInterval = tmrRefreshGraphic.Interval;
            tmrRefreshGraphic.Interval = 1;


            tmrRefreshGraphic.Interval = oldInterval;

            PSettings.PreferenceAll.OverlayUnits.X = Location.X;
            PSettings.PreferenceAll.OverlayUnits.Y = Location.Y;
        }

        /* Draw the units */

        private void Helper_DrawUnits(List<UnitCount> units, int index, ref int posX, int posY, int size, Image img,
            BufferedGraphics g, Color clPlayercolor, Font font, bool isStructure)
        {
            if (units == null ||
                units.Count <= 0)
                return;

            var unit = units[index];

            var bSpaceForPercentage = false;
            var result = 0;
            var fWidthSize = 0f;

            //Unitamount defines all buildings (applied to buildings actually placed on the map, not Upgrade To Lair and such..
            if (isStructure)
                unit.UnitAmount -= unit.UnitUnderConstruction;

            /* If there is nothing to draw.. */
            if (unit.UnitAmount == 0 && unit.UnitUnderConstruction == 0)
                return;

            /* Draw the actual image */
            g.Graphics.DrawImage(img, posX, posY, size, size);


            if (unit.UnitAmount > 0)
            {
                float fWidth;

                if (unit.UnitAmount.ToString(CultureInfo.InvariantCulture).Length == 1)
                    fWidth = unit.UnitAmount.ToString(CultureInfo.InvariantCulture).Length*(font.Size + 4);

                else
                    fWidth = unit.UnitAmount.ToString(CultureInfo.InvariantCulture).Length*(font.Size);

                fWidthSize = fWidth;

                #region Amount of Units

                HelpFunctions.HelpGraphics.FillRoundRectangle(g.Graphics,
                    new SolidBrush(Color.FromArgb(100, Color.Gray)),
                    posX + 1, posY + 1 - 1, fWidth, font.Size + 9, 5);


                g.Graphics.DrawString(unit.UnitAmount.ToString(CultureInfo.InvariantCulture), font, Brushes.White,
                    posX + 2,
                    posY + 2 - 1);

                #endregion

                #region Energy

                if (unit.Energy.Count == 1)
                {
                    var fLenght = unit.Energy[0]/(float) unit.MaximumEnergy[0];
                    fLenght *= size;

                    g.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Black)), posX + size, posY, 16,
                        fLenght);

                    if (PSettings.PreferenceAll.OverlayUnits.UseTransparentImages)
                        g.Graphics.DrawRectangle(new Pen(Brushes.Gray), posX + size, posY, 16, size);

                    var text = (unit.Energy[0] >> 12).ToString(CultureInfo.InvariantCulture);

                    var pt = new PointF(posX + size, posY);


                    g.Graphics.TranslateTransform(pt.X, pt.Y); // Set rotation point
                    g.Graphics.RotateTransform(90); // Rotate text
                    g.Graphics.TranslateTransform(-pt.X, -pt.Y); // Reset translate transform
                    var sz = g.Graphics.MeasureString(text, Font); // Get size of rotated text (bounding box)
                    g.Graphics.DrawString(text, Font, Brushes.Cyan, new PointF(pt.X, pt.Y - sz.Height));
                    // Draw string centered in x, y
                    g.Graphics.ResetTransform();
                    // Only needed if you reuse the Graphics object for multiple calls to DrawString

                    bSpaceForPercentage = true;
                }

                #region Protoss

                if (unit.Id.Equals(UnitId.PbNexus))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy/4096;
                        var tmpRes = tmp/25;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                else if (unit.Id.Equals(UnitId.PuHightemplar))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy/4096;
                        var tmpRes = tmp/75;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                else if (unit.Id.Equals(UnitId.PuSentry))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy/4096;
                        var tmpRes = tmp/50;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                else if (unit.Id.Equals(UnitId.PuMothershipCore))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy/4096;
                        var tmpRes = tmp/100;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                else if (unit.Id.Equals(UnitId.PuMothership))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy/4096;
                        var tmpRes = tmp/100;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                    #endregion

                    #region Terran

                else if (unit.Id.Equals(UnitId.TuGhost))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy/4096;
                        var tmpRes = tmp/75;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                else if (unit.Id.Equals(UnitId.TbOrbitalGround))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy/4096;
                        var tmpRes = tmp/50;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                    #endregion

                    #region Zerg

                else if (unit.Id.Equals(UnitId.ZuViper))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy/4096;
                        var tmpRes = tmp/75;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                else if (unit.Id.Equals(UnitId.ZuInfestor))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy/4096;
                        var tmpRes = tmp/75;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                else if (unit.Id.Equals(UnitId.ZuQueen) ||
                         unit.Id.Equals(UnitId.ZuQueenBurrow))
                {
                    foreach (var energy in unit.Energy)
                    {
                        var tmp = energy/4096;
                        var tmpRes = tmp/25;
                        if (tmpRes >= 1)
                            result += tmpRes;
                    }
                }

                #endregion

                #endregion
            }

            if (!PSettings.PreferenceAll.OverlayUnits.RemoveSpellCounter)
            {
                float newWidth = 10;
                float newHeight = 10;
                float newPosX = 0;
                float newPosY = 0;
                if (result > 0)
                {
                    var fWidth = TextRenderer.MeasureText(result.ToString(CultureInfo.InvariantCulture), font).Width;
                    var fHeight = TextRenderer.MeasureText(result.ToString(CultureInfo.InvariantCulture), font).Height;

                    g.Graphics.FillRoundRectangle(new SolidBrush(Color.FromArgb(100, Color.Gray)),
                        posX + size - fWidth + 5 - 2,
                        posY + size - fHeight,
                        fWidth - 5,
                        fHeight,
                        5);

                    g.Graphics.DrawString(result.ToString(CultureInfo.InvariantCulture),
                        font,
                        Brushes.Cyan,
                        posX + size - fWidth + 5 - 2,
                        posY + size - fHeight);


                    /* HelpFunctions.HelpGraphics.FillRoundRectangle(g.Graphics,
                        new SolidBrush(Color.FromArgb(100, Color.Black)),
                        posX + size -
                        TextRenderer.MeasureText(result.ToString(CultureInfo.InvariantCulture), font).Width,
                        posY + font.Size + 10, fWidthSize, font.Size + 9, 5);*/


                    /*  g.Graphics.DrawString(result.ToString(CultureInfo.InvariantCulture), font,
                        Brushes.DeepPink,
                        posX + size -
                        TextRenderer.MeasureText(result.ToString(CultureInfo.InvariantCulture), font).Width,
                        posY + font.Size + 9);*/

                    newWidth = fWidth - 5;
                    newHeight = fHeight;
                    newPosX = posX + size - fWidth + 5;
                    newPosY = posY + size - fHeight;
                }

                else
                {
                    newPosX = posX + size - 30;
                    newPosY = posY + size - 30;
                }

                //TODO: Clean this up/ fix it<
                if (unit.Energy.Count > 0)
                {
#if DEBUG
                    throw new Exception("THIS PART NEEDS SOME CORRECTION!!");
#endif

                    //g.Graphics.DrawPie(new Pen(Brushes.Red), posX, posY, size + 5, size + 5, 0, 270);
                    /* var brsh = new SolidBrush(Color.FromArgb(170, Color.GreenYellow));
                    var iUpperLimit = (float) unit.Energy[0]/unit.MaximumEnergy[0];
                    iUpperLimit *= 360;

                    g.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.Graphics.DrawArc(new Pen(brsh, 2), newPosX - 2, newPosY - 2, newWidth, newHeight, 0, iUpperLimit);
                    g.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;*/
                }
            }


            if (unit.UnitUnderConstruction > 0 || unit.Id == UnitId.ZuInfestedSwarmEgg)
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


                if (bDraw && !PSettings.PreferenceAll.OverlayUnits.RemoveChronoboost)
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
                    new SolidBrush(Color.FromArgb(100, Color.Gray)),
                    posX + 1, posY + font.Size + 10, fWidth, font.Size + 9, 5);


                g.Graphics.DrawString(unit.UnitUnderConstruction.ToString(CultureInfo.InvariantCulture), font,
                    Brushes.Orange, posX + 2,
                    posY + font.Size + 9);


                if (!PSettings.PreferenceAll.OverlayUnits.RemoveProductionLine)
                {
                    /* Adjust relative size */
                    float ftemp = size - 4;

                    if (unit.ConstructionState.Count > 0)
                        ftemp *= (unit.ConstructionState[0]/100);

                    else
                        ftemp = 0;


                    /* Draw status- line */
                    //g.Graphics.DrawRectangle(new Pen(Brushes.Yellow, 1), posX + 2, posY + size - 5, (Int32)ftemp, 1);

                    var iOffset = 5;

                    if (!PSettings.PreferenceAll.OverlayUnits.UseTransparentImages)
                        iOffset = 0;


                    g.Graphics.DrawLine(new Pen(Brushes.Yellow, 2), posX + 2, posY + size - 3 + iOffset,
                        posX + 1 + (int) ftemp,
                        posY + size - 3 + iOffset);
                    g.Graphics.DrawRectangle(new Pen(Brushes.Black, 1), posX + 2, posY + size - 5 + iOffset, size - 5, 3);
                }
            }


            if ((unit.Id.Equals(UnitId.TuMule) ||
                unit.Id.Equals(UnitId.PuForceField) ||
                unit.Id.Equals(UnitId.ZuLocust) ||
                unit.Id.Equals(UnitId.ZuFlyingLocust) ||
                unit.Id.Equals(UnitId.ZuChangeling) ||
                unit.Id.Equals(UnitId.ZuInfestedTerran) ||
                unit.Id.Equals(UnitId.ZuBroodling)) &&
                !PSettings.PreferenceAll.OverlayUnits.RemoveProductionLine)
            {
                float ftemp = size - 4;
                ftemp *= (unit.AliveSince[0]);
                ftemp = (float)Math.Ceiling(ftemp);

                /* Draw status- line */
                var iOffset = 5;

                if (!PSettings.PreferenceAll.OverlayUnits.UseTransparentImages)
                    iOffset = 0;


                g.Graphics.DrawLine(new Pen(Brushes.LimeGreen, 2), posX + 2, posY + size - 3 + iOffset,
                    posX + 1 + (int)ftemp,
                    posY + size - 3 + iOffset);
                g.Graphics.DrawRectangle(new Pen(Brushes.Black, 1), posX + 2, posY + size - 5 + iOffset, size - 5, 3);
            }


            if (!PSettings.PreferenceAll.OverlayUnits.UseTransparentImages)
            {
                if (bSpaceForPercentage)
                    g.Graphics.DrawRectangle(new Pen(new SolidBrush(clPlayercolor), 2), posX, posY, size + 16, size);

                else
                    g.Graphics.DrawRectangle(new Pen(new SolidBrush(clPlayercolor), 2), posX, posY, size, size);
            }

            posX += size;

            if (bSpaceForPercentage)
                posX += 16;
        }
    }
}