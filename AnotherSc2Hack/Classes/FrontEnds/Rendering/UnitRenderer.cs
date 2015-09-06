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
                        Helper_DrawUnits(_lTuScv, i, ref iPosX, iPosY, iSize, _imgTuScv, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuMarine, i, ref iPosX, iPosY, iSize, _imgTuMarine, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuMarauder, i, ref iPosX, iPosY, iSize, _imgTuMarauder, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lTuReaper, i, ref iPosX, iPosY, iSize, _imgTuReaper, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuGhost, i, ref iPosX, iPosY, iSize, _imgTuGhost, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuMule, i, ref iPosX, iPosY, iSize, _imgTuMule, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuHellion, i, ref iPosX, iPosY, iSize, _imgTuHellion, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuHellbat, i, ref iPosX, iPosY, iSize, _imgTuHellbat, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuWidowMine, i, ref iPosX, iPosY, iSize, _imgTuWidowMine, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lTuSiegetank, i, ref iPosX, iPosY, iSize, _imgTuSiegetank, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lTuThor, i, ref iPosX, iPosY, iSize, _imgTuThor, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuMedivac, i, ref iPosX, iPosY, iSize, _imgTuMedivac, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuBanshee, i, ref iPosX, iPosY, iSize, _imgTuBanshee, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuViking, i, ref iPosX, iPosY, iSize, _imgTuViking, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuRaven, i, ref iPosX, iPosY, iSize, _imgTuRaven, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lTuBattlecruiser, i, ref iPosX, iPosY, iSize, _imgTuBattlecruiser, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lTuPointDefenseDrone, i, ref iPosX, iPosY, iSize, _imgTuPointDefenseDrone,
                            g, clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lTuNuke, i, ref iPosX, iPosY, iSize,
                            _imgTuNuke, g, clPlayercolor, fStringFont, false);


                        /* Protoss */
                        Helper_DrawUnits(_lPuProbe, i, ref iPosX, iPosY, iSize, _imgPuProbe, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuZealot, i, ref iPosX, iPosY, iSize, _imgPuZealot, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuStalker, i, ref iPosX, iPosY, iSize, _imgPuStalker, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuSentry, i, ref iPosX, iPosY, iSize, _imgPuSentry, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuDt, i, ref iPosX, iPosY, iSize, _imgPuDarkTemplar, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuHt, i, ref iPosX, iPosY, iSize, _imgPuHighTemplar, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuArchon, i, ref iPosX, iPosY, iSize, _imgPuArchon, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuImmortal, i, ref iPosX, iPosY, iSize, _imgPuImmortal, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lPuColossus, i, ref iPosX, iPosY, iSize, _imgPuColossus, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lPuObserver, i, ref iPosX, iPosY, iSize, _imgPuObserver, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lPuWarpprism, i, ref iPosX, iPosY, iSize, _imgPuWapprism, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lPuPhoenix, i, ref iPosX, iPosY, iSize, _imgPuPhoenix, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuVoidray, i, ref iPosX, iPosY, iSize, _imgPuVoidray, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuOracle, i, ref iPosX, iPosY, iSize, _imgPuOracle, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuCarrier, i, ref iPosX, iPosY, iSize, _imgPuCarrier, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuTempest, i, ref iPosX, iPosY, iSize, _imgPuTempest, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lPuMothershipcore, i, ref iPosX, iPosY, iSize, _imgPuMothershipcore, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lPuMothership, i, ref iPosX, iPosY, iSize, _imgPuMothership, g,
                            clPlayercolor, fStringFont, false);


                        /* Zerg */
                        Helper_DrawUnits(_lZuDrone, i, ref iPosX, iPosY, iSize, _imgZuDrone, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuOverlord, i, ref iPosX, iPosY, iSize, _imgZuOverlord, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuQueen, i, ref iPosX, iPosY, iSize, _imgZuQueen, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuZergling, i, ref iPosX, iPosY, iSize, _imgZuZergling, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuBaneling, i, ref iPosX, iPosY, iSize, _imgZuBaneling, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuBanelingCocoon, i, ref iPosX, iPosY, iSize, _imgZuBanelingCocoon, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuRoach, i, ref iPosX, iPosY, iSize, _imgZuRoach, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuHydra, i, ref iPosX, iPosY, iSize, _imgZuHydra, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuMutalisk, i, ref iPosX, iPosY, iSize, _imgZuMutalisk, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuInfestor, i, ref iPosX, iPosY, iSize, _imgZuInfestor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuOverseer, i, ref iPosX, iPosY, iSize, _imgZuOverseer, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuOverseerCocoon, i, ref iPosX, iPosY, iSize, _imgZuOvserseerCocoon, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuSwarmhost, i, ref iPosX, iPosY, iSize, _imgZuSwarmhost, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuUltralisk, i, ref iPosX, iPosY, iSize, _imgZuUltra, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuViper, i, ref iPosX, iPosY, iSize, _imgZuViper, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuCorruptor, i, ref iPosX, iPosY, iSize, _imgZuCorruptor, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuBroodlord, i, ref iPosX, iPosY, iSize, _imgZuBroodlord, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuBroodlordCocoon, i, ref iPosX, iPosY, iSize, _imgZuBroodlordCocoon,
                            g, clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZuLocust, i, ref iPosX, iPosY, iSize, _imgZuLocust, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuFlyingLocust, i, ref iPosX, iPosY, iSize, _imgZuFlyingLocust, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuLarva, i, ref iPosX, iPosY, iSize, _imgZuLarva, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuChangeling, i, ref iPosX, iPosY, iSize, _imgZuChangeling, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuInfestedTerran, i, ref iPosX, iPosY, iSize, _imgInfestedTerran, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZuInfestedTerranEgg, i, ref iPosX, iPosY, iSize, _imgInfestedTerranEgg, g, clPlayercolor,
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
                        Helper_DrawUnits(_lTbCommandCenter, i,
                            ref iPosX, iPosY, iSize, _imgTbCc, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbOrbitalCommand, i,
                            ref iPosX, iPosY, iSize, _imgTbOc, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lTbPlanetaryFortress, i,
                            ref iPosX, iPosY, iSize, _imgTbPf, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lTbSupply, i, ref iPosX, iPosY,
                            iSize, _imgTbSupply, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbRefinery, i, ref iPosX, iPosY,
                            iSize, _imgTbRefinery, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbBunker, i, ref iPosX, iPosY,
                            iSize, _imgTbBunker, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbTechlab, i, ref iPosX, iPosY,
                            iSize, _imgTbTechlab, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbReactor, i, ref iPosX, iPosY,
                            iSize, _imgTbReactor, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbTurrent, i, ref iPosX, iPosY,
                            iSize, _imgTbTurrent, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbSensorTower, i, ref iPosX,
                            iPosY, iSize, _imgTbSensorTower, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbEbay, i, ref iPosX, iPosY, iSize,
                            _imgTbEbay, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbGhostAcademy, i, ref iPosX,
                            iPosY, iSize, _imgTbGhostacademy, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbArmory, i, ref iPosX, iPosY,
                            iSize, _imgTbArmory, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbFusionCore, i, ref iPosX,
                            iPosY, iSize, _imgTbFusioncore, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbBarracks, i, ref iPosX, iPosY,
                            iSize, _imgTbBarracks, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbFactory, i, ref iPosX, iPosY,
                            iSize, _imgTbFactory, g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbStarport, i, ref iPosX, iPosY,
                            iSize, _imgTbStarport, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lTbAutoTurret, i, ref iPosX, iPosY, iSize, _imgTbAutoTurret, g,
                            clPlayercolor, fStringFont, false);


                        /* Protoss */
                        Helper_DrawUnits(_lPbNexus, i, ref iPosX, iPosY, iSize, _imgPbNexus, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(_lPbPylon, i, ref iPosX, iPosY, iSize, _imgPbPylon, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(_lPbAssimilator, i, ref iPosX, iPosY, iSize, _imgPbAssimilator, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbCannon, i, ref iPosX, iPosY, iSize, _imgPbCannon, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(_lPbDarkshrine, i, ref iPosX, iPosY, iSize, _imgPbDarkShrine, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbTemplarArchives, i, ref iPosX, iPosY, iSize, _imgPbTemplarArchives,
                            g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbTwilight, i, ref iPosX, iPosY, iSize, _imgPbTwillightCouncil, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbCybercore, i, ref iPosX, iPosY, iSize, _imgPbCybercore, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbForge, i, ref iPosX, iPosY, iSize, _imgPbForge, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(_lPbFleetbeacon, i, ref iPosX, iPosY, iSize, _imgPbFleetBeacon, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbRoboticsSupport, i, ref iPosX, iPosY, iSize, _imgPbRoboticsSupport,
                            g, clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbGateway, i, ref iPosX, iPosY, iSize, _imgPbGateway, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(_lPbWarpgate, i, ref iPosX, iPosY, iSize, _imgPbWarpgate, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbStargate, i, ref iPosX, iPosY, iSize, _imgPbStargate, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lPbRobotics, i, ref iPosX, iPosY, iSize, _imgPbRobotics, g,
                            clPlayercolor, fStringFont, true);

                        /* Zerg */
                        Helper_DrawUnits(_lZbCreepTumor, i, ref iPosX, iPosY, iSize, _imgZbCreepTumor, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbHatchery, i, ref iPosX, iPosY, iSize, _imgZbHatchery, g,
                            clPlayercolor, fStringFont, true);
                        //Note: Since Lairs/ Hives can not be placed plainly on the ground, we have to hack here
                        //We'll pretend them to be units so we don't subtract the units in procution from the unitamount
                        Helper_DrawUnits(_lZbLair, i, ref iPosX, iPosY, iSize, _imgZbLair, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZbHive, i, ref iPosX, iPosY, iSize, _imgZbHive, g, clPlayercolor,
                            fStringFont, false);
                        Helper_DrawUnits(_lZbSpawningpool, i, ref iPosX, iPosY, iSize, _imgZbSpawningpool, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbEvochamber, i, ref iPosX, iPosY, iSize, _imgZbEvochamber, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbExtractor, i, ref iPosX, iPosY, iSize, _imgZbExtractor, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbSpine, i, ref iPosX, iPosY, iSize, _imgZbSpinecrawler, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbSpore, i, ref iPosX, iPosY, iSize, _imgZbSporecrawler, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbHydraden, i, ref iPosX, iPosY, iSize, _imgZbHydraden, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbRoachwarren, i, ref iPosX, iPosY, iSize, _imgZbRoachwarren, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbSpire, i, ref iPosX, iPosY, iSize, _imgZbSpire, g, clPlayercolor,
                            fStringFont, true);
                        Helper_DrawUnits(_lZbGreaterspire, i, ref iPosX, iPosY, iSize, _imgZbGreaterspire, g,
                            clPlayercolor, fStringFont, false);
                        Helper_DrawUnits(_lZbUltracavern, i, ref iPosX, iPosY, iSize, _imgZbUltracavern, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbInfestationpit, i, ref iPosX, iPosY, iSize, _imgZbInfestationpit, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbBanelingnest, i, ref iPosX, iPosY, iSize, _imgZbBanelingnest, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbNydusbegin, i, ref iPosX, iPosY, iSize, _imgZbNydusNetwork, g,
                            clPlayercolor, fStringFont, true);
                        Helper_DrawUnits(_lZbNydusend, i, ref iPosX, iPosY, iSize, _imgZbNydusWorm, g,
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
                Helper_DrawUnits(_lPuForcefield, GInformation.Player.Count, ref iPosX, iPosY, iSize,
                    _imgPupForcefield, g,
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
                    g.Graphics.DrawImage(_imgSpeedArrow, new Rectangle(posX + size - 20, posY + 5, 15, 15));
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
                unit.Id.Equals(UnitId.ZuInfestedTerran)) &&
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