using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using PredefinedTypes;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    public class MaphackRenderer : BaseRenderer
    {
        public MaphackRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
            : base(gInformation, pSettings, sc2Process)
        {
            IsHiddenChanged += MaphackRenderer_IsHiddenChanged;
        }

        /// <summary>
        /// Draws the panelspecific data.
        /// </summary>
        /// <param name="g"></param>
        protected override void Draw(BufferedGraphics g)
        {
            try
            {
                if (GInformation.Unit == null ||
                    GInformation.Unit.Count <= 0)
                    return;

                if (GInformation.Player == null)
                    return;

                if (!GInformation.Gameinfo.IsIngame)
                {
                    g.Graphics.Clear(Color.White);
                    g.Graphics.Clear(BackColor);
                    return;
                }

                Opacity = PSettings.PreferenceAll.OverlayMaphack.Opacity;

                if (!BChangingPosition)
                {
                    Height = PSettings.PreferenceAll.OverlayMaphack.Height;
                    Width = PSettings.PreferenceAll.OverlayMaphack.Width;
                }

                var tmpMap = GInformation.Map;


                #region Introduction

                #region Variables

                float fScale,
                      fX,
                      fY;

                #endregion

                #region Get minimap Bounds

                var fa = Height / (float)Width;
                var fb = ((float)tmpMap.PlayableHeight / tmpMap.PlayableWidth);

                if (fa >= fb)
                {
                    fScale = (float)Width / tmpMap.PlayableWidth;
                    fX = 0;
                    fY = (Height - fScale * tmpMap.PlayableHeight) / 2;
                }
                else
                {
                    fScale = (float)Height / tmpMap.PlayableHeight;
                    fY = 0;
                    fX = (Width - fScale * tmpMap.PlayableWidth) / 2;
                }



                #endregion

                #region Draw Bounds

                if (!PSettings.PreferenceAll.OverlayMaphack.RemoveVisionArea)
                {
                    /* Draw Rectangle */
                    g.Graphics.DrawRectangle(Constants.PBound, 0, 0, Width - Constants.PBound.Width,
                                             Height - Constants.PBound.Width);

                    /* Draw Playable Area */
                    g.Graphics.DrawRectangle(Constants.PArea, fX, fY, Width - fX * 2 - Constants.PArea.Width,
                                             Height - fY * 2 - Constants.PArea.Width);
                }

                #endregion

                #endregion

                #region Actual Drawing

                #region Draw Unit- destination

                if (!PSettings.PreferenceAll.OverlayMaphack.RemoveDestinationLine)
                {
                    for (var i = 0; i < GInformation.Unit.Count; i++)
                    {
                        var clDestination = PSettings.PreferenceAll.OverlayMaphack.DestinationLine;

                        var tmpUnit = GInformation.Unit[i];




                        #region Escape Sequences


                        /* Ai */
                        if (PSettings.PreferenceAll.OverlayMaphack.RemoveAi)
                        {
                            if (
                                GInformation.Player[tmpUnit.Owner].Type.Equals(
                                    PredefinedData.PlayerType.Ai))
                                continue;
                        }

                        /* Allie */
                        if (PSettings.PreferenceAll.OverlayMaphack.RemoveAllie)
                        {
                            if (GInformation.Player[0].Localplayer < GInformation.Player.Count)
                            {
                                if (GInformation.Player[tmpUnit.Owner].Team ==
                                    GInformation.Player[GInformation.Player[0].Localplayer].Team &&
                                    !GInformation.Player[tmpUnit.Owner].IsLocalplayer)
                                    continue;
                            }
                        }

                        /* Localplayer Units */
                        if (PSettings.PreferenceAll.OverlayMaphack.RemoveLocalplayer)
                        {
                            if (tmpUnit.Owner == GInformation.Player[0].Localplayer)
                                continue;
                        }

                        /* Neutral Units */
                        if (PSettings.PreferenceAll.OverlayMaphack.RemoveNeutral)
                        {
                            if (
                                GInformation.Player[tmpUnit.Owner].Type.Equals(
                                    PredefinedData.PlayerType.Neutral))
                                continue;
                        }

                        /* Dead Units */
                        if ((tmpUnit.TargetFilter & (ulong)PredefinedData.TargetFilterFlag.Dead) > 0)
                            continue;


                        /* Moving- state */
                        if (tmpUnit.Movestate.Equals(0))
                            continue;




                        #endregion

                        #region Scalling (Unitposition + UnitDestination)

                        var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
                        var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;

                        var iUnitDestPosX = (tmpUnit.DestinationPositionX - tmpMap.Left) * fScale +
                                            fX;
                        var iUnitDestPosY = (tmpMap.Top - tmpUnit.DestinationPositionY) * fScale +
                                            fY;

                        if (float.IsNaN(iUnitPosX) ||
                            float.IsNaN(iUnitPosY) ||
                            float.IsNaN(iUnitDestPosX) ||
                            float.IsNaN(iUnitDestPosY))
                        {
                            continue;
                        }


                        #endregion

                        g.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                        g.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                        /* Draws the Line */
                        if (tmpUnit.DestinationPositionX > 10 &&
                            tmpUnit.DestinationPositionY > 10)
                            g.Graphics.DrawLine(new Pen(new SolidBrush(clDestination)), iUnitPosX, iUnitPosY,
                                                iUnitDestPosX,
                                                iUnitDestPosY);

                        g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
                        g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                        g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;

                    }
                }

                #endregion

                #region Draw Creeptumors

                for (var i = 0; i < GInformation.Unit.Count; i++)
                {
                    var tmpUnit = GInformation.Unit[i];

                    #region Exceptions

                    /* Ai */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveAi)
                    {
                        if (GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue; //clUnitBoundBorder = Color.Transparent;

                    }

                    /* Allie */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveAllie)
                    {
                        if (GInformation.Player[0].Localplayer < GInformation.Player.Count)
                        {
                            if (GInformation.Player[tmpUnit.Owner].Team ==
                                GInformation.Player[GInformation.Player[0].Localplayer].Team &&
                                !GInformation.Player[tmpUnit.Owner].IsLocalplayer)
                                continue; //clUnitBoundBorder = Color.Transparent;

                        }
                    }

                    /* Localplayer Units */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveLocalplayer)
                    {
                        if (tmpUnit.Owner == GInformation.Player[0].Localplayer)
                            continue; //clUnitBoundBorder = Color.Transparent;

                    }

                    /* Neutral Units */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveNeutral)
                    {
                        if (GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue; //clUnitBoundBorder = Color.Transparent;

                    }

                    /* Dead Units */
                    if ((tmpUnit.TargetFilter & (ulong)PredefinedData.TargetFilterFlag.Dead) > 0)
                        continue;

                    #endregion

                    #region Actual Drawing


                    if (tmpUnit.Id == PredefinedData.UnitId.ZbCreeptumor ||
                        tmpUnit.Id == PredefinedData.UnitId.ZbCreepTumorBuilding ||
                        tmpUnit.Id == PredefinedData.UnitId.ZbCreepTumorMissle ||
                        tmpUnit.Id == PredefinedData.UnitId.ZbCreeptumorBurrowed)
                    {

                        #region Scalling (Unitposition)

                        var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
                        var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;

                        if (float.IsNaN(iUnitPosX) ||
                            float.IsNaN(iUnitPosY))
                        {
                            continue;
                        }


                        #endregion


                        const Int32 iRadius = 4;





                        g.Graphics.DrawLine(Constants.PBlack2, iUnitPosX - iRadius, iUnitPosY - iRadius, iUnitPosX + iRadius, iUnitPosY + iRadius);
                        g.Graphics.DrawLine(Constants.PBlack2, iUnitPosX + iRadius, iUnitPosY - iRadius, iUnitPosX - iRadius, iUnitPosY + iRadius);


                    }


                    #endregion

                }

                #endregion

                #region Draw Unit (Border/ outer Rectangle)

                for (var i = 0; i < GInformation.Unit.Count; i++)
                {
                    var tmpUnit = GInformation.Unit[i];
                    var clUnitBound = Color.Black;

                    if (tmpUnit.Owner >= (GInformation.Player.Count))
                        continue;


                    #region Escape Sequences

                    /* Ai */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveAi)
                    {
                        if (GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue;
                    }

                    /* Allie */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveAllie)
                    {
                        if (GInformation.Player[0].Localplayer < GInformation.Player.Count)
                        {
                            if (GInformation.Player[tmpUnit.Owner].Team ==
                                GInformation.Player[GInformation.Player[0].Localplayer].Team &&
                                !GInformation.Player[tmpUnit.Owner].IsLocalplayer)
                                continue;
                        }
                    }

                    /* Localplayer Units */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveLocalplayer)
                    {
                        if (tmpUnit.Owner == GInformation.Player[0].Localplayer)
                            continue;
                    }

                    /* Neutral Units */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveNeutral)
                    {
                        if (GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue;
                    }


                    /* Dead Units */
                    if ((tmpUnit.TargetFilter & (ulong)PredefinedData.TargetFilterFlag.Dead) > 0)
                        continue;

                    /* Creep tumor */
                    if (tmpUnit.Id ==
                        PredefinedData.UnitId.ZbCreeptumorBurrowed)
                        continue;




                    #endregion

                    #region Scalling (Unitposition)

                    var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
                    var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;

                    if (float.IsNaN(iUnitPosX) ||
                        float.IsNaN(iUnitPosY))
                    {
                        continue;
                    }


                    #endregion



                    var fUnitSize = tmpUnit.Size;
                    var size = 2.0f;

                    if (fUnitSize >= 0.5)
                        size = 3;

                    if (fUnitSize >= 0.875)
                        size = 4;

                    if (fUnitSize >= 1.5)
                        size = 6;

                    if (fUnitSize >= 2.0)
                        size = 8;

                    if (fUnitSize >= 2.5)
                        size = 10;

                    size += 0.5f;


                    #region Actual drawing

                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

                    if (tmpUnit.IsCloaked &&
                        tmpUnit.Id != PredefinedData.UnitId.ZbCreeptumorBurrowed)
                    {
                        g.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Gray)), iUnitPosX - size / 2,
                                                 iUnitPosY - size / 2, size, size);

                        g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBound)), iUnitPosX - size / 2 - 0.5f,
                                                 iUnitPosY - size / 2 - 0.5f, size + 1, size + 1);
                    }

                    else
                    {
                        g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBound)), iUnitPosX - size / 2,
                                                 iUnitPosY - size / 2, size, size);
                    }

                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

                    #endregion
                }

                #endregion

                #region Draw Unit (Inner Rectangle)

                for (var i = 0; i < GInformation.Unit.Count; i++)
                {
                    var tmpUnit = GInformation.Unit[i];
                    //Color clUnit = LUnit[i].Owner > LPlayer.Count ? Color.Transparent : LPlayer[LUnit[i].Owner].Color;

                    if (tmpUnit.Owner >= GInformation.Player.Count)
                        continue;


                    var clUnit = GInformation.Player[tmpUnit.Owner].Color;

                    #region Teamcolor

                    RendererHelper.TeamColor(GInformation.Player, GInformation.Unit, i,
                                              GInformation.Gameinfo.IsTeamcolor, ref clUnit);

                    #endregion

                    #region Scalling (Unitposition)

                    var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
                    var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;


                    if (float.IsNaN(iUnitPosX) ||
                        float.IsNaN(iUnitPosY))
                    {
                        continue;
                    }

                    #endregion

                    #region Escape Sequences

                    /* Ai */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveAi)
                    {
                        if (GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue;
                    }

                    /* Allie */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveAllie)
                    {
                        if (GInformation.Player[0].Localplayer < GInformation.Player.Count)
                        {
                            if (GInformation.Player[tmpUnit.Owner].Team ==
                                GInformation.Player[GInformation.Player[0].Localplayer].Team &&
                                !GInformation.Player[tmpUnit.Owner].IsLocalplayer)
                                continue;
                        }
                    }

                    /* Localplayer Units */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveLocalplayer)
                    {
                        if (tmpUnit.Owner == GInformation.Player[0].Localplayer)
                            continue;
                    }

                    /* Neutral Units */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveNeutral)
                    {
                        if (GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue;
                    }


                    /* Dead Units */
                    if ((tmpUnit.TargetFilter & (ulong)PredefinedData.TargetFilterFlag.Dead) > 0)
                        continue;

                    /* Creep tumor */
                    if (tmpUnit.Id ==
                         PredefinedData.UnitId.ZbCreeptumorBurrowed)
                        continue;




                    #endregion

                    var fUnitSize = tmpUnit.Size;
                    var size = 2.0f;

                    if (fUnitSize >= 0.5f)
                        size = 3;

                    if (fUnitSize >= 0.875)
                        size = 4;

                    if (fUnitSize >= 1.5)
                        size = 6;

                    if (fUnitSize >= 2.0)
                        size = 8;

                    if (fUnitSize >= 2.5)
                        size = 10;

                    size -= 0.5f;


                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

                    /* Draw the Unit (Actual Unit) */
                    g.Graphics.FillRectangle(new SolidBrush(clUnit), iUnitPosX - size / 2, iUnitPosY - size / 2, size, size);

                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    g.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

                }

                #endregion

                #region Draw Border of special Units

                for (var i = 0; i < GInformation.Unit.Count; i++)
                {
                    var tmpUnit = GInformation.Unit[i];
                    var clUnitBoundBorder = Color.Black;

                    if (tmpUnit.Owner >= (GInformation.Player.Count))
                        continue;


                    #region Scalling (Unitposition)

                    var iUnitPosX = (tmpUnit.PositionX - tmpMap.Left) * fScale + fX;
                    var iUnitPosY = (tmpMap.Top - tmpUnit.PositionY) * fScale + fY;


                    if (float.IsNaN(iUnitPosX) ||
                        float.IsNaN(iUnitPosY))
                    {
                        continue;
                    }

                    #endregion

                    #region Escape Sequences

                    /* Ai */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveAi)
                    {
                        if (GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue; //clUnitBoundBorder = Color.Transparent;

                    }

                    /* Allie */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveAllie)
                    {
                        if (GInformation.Player[0].Localplayer < GInformation.Player.Count)
                        {
                            if (GInformation.Player[tmpUnit.Owner].Team ==
                                GInformation.Player[GInformation.Player[0].Localplayer].Team &&
                                !GInformation.Player[tmpUnit.Owner].IsLocalplayer)
                                continue; //clUnitBoundBorder = Color.Transparent;

                        }
                    }

                    /* Localplayer Units */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveLocalplayer)
                    {
                        if (tmpUnit.Owner == GInformation.Player[0].Localplayer)
                            continue; //clUnitBoundBorder = Color.Transparent;

                    }

                    /* Neutral Units */
                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveNeutral)
                    {
                        if (GInformation.Player[tmpUnit.Owner].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue; //clUnitBoundBorder = Color.Transparent;

                    }


                    /* Dead Units */
                    if ((tmpUnit.TargetFilter & (ulong)PredefinedData.TargetFilterFlag.Dead) > 0)
                        continue;






                    #endregion


                    var fUnitSize = tmpUnit.Size;
                    var size = 2.0f;

                    if (fUnitSize >= 0.875)
                        size = 4;

                    if (fUnitSize >= 1.5)
                        size = 6;

                    if (fUnitSize >= 2.0)
                        size = 8;

                    if (fUnitSize >= 2.5)
                        size = 10;

                    size += 0.5f;


                    #region Border special Units

                    #region Self created Units

                    if (PSettings.PreferenceAll.OverlayMaphack.UnitIds != null ||
                        PSettings.PreferenceAll.OverlayMaphack.UnitColors != null)
                    {
                        for (var j = 0; j < PSettings.PreferenceAll.OverlayMaphack.UnitIds.Count; j++)
                        {
                            var tmpSettingsId = PSettings.PreferenceAll.OverlayMaphack.UnitIds[j];
                            var bExpression = false;

                            if (tmpSettingsId == PredefinedData.UnitId.ZuChangeling)
                            {
                                if (tmpUnit.Id == PredefinedData.UnitId.ZuChangeling ||
                                    tmpUnit.Id == PredefinedData.UnitId.ZuChangelingMarine ||
                                    tmpUnit.Id == PredefinedData.UnitId.ZuChangelingMarineShield ||
                                    tmpUnit.Id == PredefinedData.UnitId.ZuChangelingSpeedling ||
                                    tmpUnit.Id == PredefinedData.UnitId.ZuChangelingZealot ||
                                    tmpUnit.Id == PredefinedData.UnitId.ZuChangelingZergling)
                                    bExpression = true;
                            }

                            else
                                bExpression = tmpUnit.Id == PSettings.PreferenceAll.OverlayMaphack.UnitIds[j] ? true : false;

                            if (bExpression)
                            {
                                if (PSettings.PreferenceAll.OverlayMaphack.UnitColors[j] != Color.Transparent)
                                {
                                    var clUnit = PSettings.PreferenceAll.OverlayMaphack.UnitColors[j];
                                    if (!tmpUnit.IsAlive)
                                        continue;

                                    if (PSettings.PreferenceAll.OverlayMaphack.RemoveLocalplayer)
                                    {
                                        if (tmpUnit.Owner ==
                                            GInformation.Player[0].Localplayer)
                                            continue;
                                    }

                                    g.Graphics.DrawRectangle(
                                        new Pen(new SolidBrush(clUnit), 1.5f),
                                        (iUnitPosX - size / 2), (iUnitPosY - size / 2), size, size);

                                    g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBoundBorder)),
                                                             iUnitPosX - ((size / 2) + 0.75f),
                                                             iUnitPosY - ((size / 2) + 0.75f), size + 1.75f, size + 1.75f);
                                }
                            }
                        }
                    }

                    #endregion

                    #region CreepTumors

                    //if (_hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int) PredefinedTypes.UnitId.ZbCreeptumor)
                    //{
                    //    g.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Gray), 1.5f),
                    //                             (iUnitPosX - size/2), (iUnitPosY - size/2), size, size);

                    //    g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBoundBorder)),
                    //                             iUnitPosX - ((size/2) + 0.75f),
                    //                             iUnitPosY - ((size/2) + 0.75f), size + 1.75f, size + 1.75f);
                    //}


                    //if (_hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreeptumor ||
                    //    _hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreepTumorBuilding ||
                    //    _hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreepTumorMissle ||
                    //    _hMainHandler.GInformation.Unit[i].CustomStruct.Id == (int)PredefinedTypes.UnitId.ZbCreeptumorBurrowed)
                    //{
                    //    const Int32 iRadius = 4;

                    //    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    //    g.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                    //    g.Graphics.DrawLine(Constants.PBlack1, iUnitPosX - iRadius, iUnitPosY - iRadius, iUnitPosX + iRadius, iUnitPosY + iRadius);
                    //    g.Graphics.DrawLine(Constants.PBlack1, iUnitPosX + iRadius, iUnitPosY - iRadius, iUnitPosX - iRadius, iUnitPosY + iRadius);

                    //    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    //    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                    //}

                    #endregion

                    #region Unitgroup I - Defensive Buildings

                    if (PSettings.PreferenceAll.OverlayMaphack.ColorDefensiveStructures)
                    {
                        if (tmpUnit.Id == PredefinedData.UnitId.TbTurret ||
                            tmpUnit.Id == PredefinedData.UnitId.TbBunker ||
                            tmpUnit.Id == PredefinedData.UnitId.TbPlanetary ||
                            tmpUnit.Id == PredefinedData.UnitId.ZbSpineCrawler ||
                            tmpUnit.Id == PredefinedData.UnitId.ZbSpineCrawlerUnrooted ||
                            tmpUnit.Id == PredefinedData.UnitId.ZbSporeCrawler ||
                            tmpUnit.Id == PredefinedData.UnitId.ZbSporeCrawlerUnrooted ||
                            tmpUnit.Id == PredefinedData.UnitId.PbCannon)
                        {
                            var clUnitBound = Color.Yellow;


                            if ((tmpUnit.TargetFilter & (UInt64)PredefinedData.TargetFilterFlag.Dead) > 0)
                                continue;


                            if (PSettings.PreferenceAll.OverlayMaphack.RemoveLocalplayer)
                            {
                                if (tmpUnit.Owner == GInformation.Player[0].Localplayer)
                                    continue;

                            }

                            g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBound), 1.5f),
                                                     (iUnitPosX - size / 2), (iUnitPosY - size / 2), size, size);

                            g.Graphics.DrawRectangle(new Pen(new SolidBrush(clUnitBoundBorder)),
                                                     iUnitPosX - ((size / 2) + 0.75f),
                                                     iUnitPosY - ((size / 2) + 0.75f), size + 1.75f, size + 1.75f);
                        }
                    }

                    #endregion

                    #region Hallucinations - make a triangle

                    #endregion

                    var ptPoints = new PointF[3];
                    var fRadius = size * 2;

                    if (tmpUnit.IsHallucination)
                    {
                        ptPoints[0] = new PointF(iUnitPosX + (size / 2), iUnitPosY - fRadius - 1);
                        ptPoints[1] = new PointF(iUnitPosX - fRadius, iUnitPosY + fRadius);
                        ptPoints[2] = new PointF(iUnitPosX + fRadius + 1, iUnitPosY + fRadius);
                    }

                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                    g.Graphics.DrawPolygon(new Pen(Brushes.Orange, 1), ptPoints);

                    g.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    g.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                    #endregion

                }

                #endregion



                #region Draw Player camera

                if (!PSettings.PreferenceAll.OverlayMaphack.RemoveCamera)
                {
                    for (var i = 0; i < GInformation.Player.Count; i++)
                    {
                        var clPlayercolor = GInformation.Player[i].Color;

                        #region Teamcolor

                        if (GInformation.Gameinfo.IsTeamcolor)
                        {
                            if (GInformation.Player[0].Localplayer < GInformation.Player.Count)
                            {
                                if (GInformation.Player[i].IsLocalplayer)
                                    clPlayercolor = Color.Green;

                                else if (GInformation.Player[i].Team ==
                                         GInformation.Player[GInformation.Player[0].Localplayer].Team &&
                                         !GInformation.Player[i].IsLocalplayer)
                                    clPlayercolor = Color.Yellow;

                                else
                                    clPlayercolor = Color.Red;
                            }
                        }

                        #endregion

                        #region Escape Sequences

                        /* Ai - Works */
                        if (PSettings.PreferenceAll.OverlayMaphack.RemoveAi)
                        {
                            if (GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Ai))
                                continue;
                        }

                        /* Localplayer - Works */
                        if (PSettings.PreferenceAll.OverlayMaphack.RemoveLocalplayer)
                        {
                            if (GInformation.Player[i].IsLocalplayer)
                                continue;
                        }

                        /* Allie */
                        if (PSettings.PreferenceAll.OverlayMaphack.RemoveAllie)
                        {
                            if (GInformation.Player[0].Localplayer < GInformation.Player.Count)
                            {
                                if (GInformation.Player[i].Team ==
                                    GInformation.Player[GInformation.Player[i].Localplayer].Team &&
                                    !GInformation.Player[i].IsLocalplayer)
                                    continue;
                            }
                        }

                        /* Neutral */
                        if (PSettings.PreferenceAll.OverlayMaphack.RemoveNeutral)
                        {
                            if (GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Neutral))
                                continue;
                        }

                        if (GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Hostile))
                            continue;

                        if (GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Observer))
                            continue;

                        if (GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Referee))
                            continue;

                        if (float.IsInfinity(fScale))
                            continue;

                        if (CheckIfGameheart(GInformation.Player[i]))
                            continue;

                        #endregion

                        #region Drawing

                        //The actrual position of the Cameras
                        var fPlayerX = (GInformation.Player[i].CameraPositionX - tmpMap.Left) * fScale + fX;
                        var fPlayerY = (tmpMap.Top - GInformation.Player[i].CameraPositionY) * fScale + fY;


                        if (fPlayerX <= 0 || fPlayerX >= Width ||
                            fPlayerY <= 0 || fPlayerY >= Height)
                            continue;


                        var ptPoints = new PointF[4];
                        ptPoints[0] = new PointF(fPlayerX - 35f, fPlayerY - 24f);
                        ptPoints[1] = new PointF(fPlayerX + 35f, fPlayerY - 24f);
                        ptPoints[2] = new PointF(fPlayerX + 24f, fPlayerY + 10f);
                        ptPoints[3] = new PointF(fPlayerX - 24f, fPlayerY + 10f);




                        g.Graphics.DrawPolygon(new Pen(new SolidBrush(clPlayercolor), 2), ptPoints);

                        #endregion

                    }
                }

                #endregion

                #endregion

            }

            catch (Exception ex)
            {
                Messages.LogFile("Over all", ex);
            }
        }

        /// <summary>
        /// Sends the panel specific data into the Form's controls and settings
        /// </summary>
        protected override void MouseUpTransferData()
        {
            PSettings.PreferenceAll.OverlayMaphack.X = Location.X;
            PSettings.PreferenceAll.OverlayMaphack.Y = Location.Y;
            PSettings.PreferenceAll.OverlayMaphack.Width = Width;
            PSettings.PreferenceAll.OverlayMaphack.Height = Height;
            PSettings.PreferenceAll.OverlayMaphack.Opacity = Opacity;
        }

        /// <summary>
        /// Sends the panel specific data into the Form's controls and settings
        /// </summary>
        protected override void MouseWheelTransferData(MouseEventArgs e)
        {
            if (e.Delta.Equals(120))
            {
                Width += 1;
                Height += 1;
            }

            else if (e.Delta.Equals(-120))
            {
                Width -= 1;
                Height -= 1;
            }
        }

        /// <summary>
        /// Sends the panel specific data into the Form's controls and settings
        /// Also changes the Size directly!
        /// </summary>
        protected override void AdjustPanelSize()
        {
            if (BSetSize)
            {
                tmrRefreshGraphic.Interval = 20;

                PSettings.PreferenceAll.OverlayMaphack.Width = Cursor.Position.X - Left;

                var iValidPlayerCount = GInformation.Gameinfo.ValidPlayerCount;
                if (PSettings.PreferenceAll.OverlayMaphack.RemoveNeutral)
                    iValidPlayerCount -= 1;

                if ((Cursor.Position.Y - Top) / iValidPlayerCount >= 5)
                {
                    PSettings.PreferenceAll.OverlayMaphack.Height = (Cursor.Position.Y - Top) /
                                                        iValidPlayerCount;
                }

                else
                    PSettings.PreferenceAll.OverlayMaphack.Height = 5;
            }

            var strInput = StrBackupSizeChatbox;

            if (String.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));


            if (strInput.Equals(PSettings.PreferenceAll.OverlayMaphack.ChangeSize))
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
        /// Loads the settings of the specific Form into the controls (Location, Size)
        /// </summary>
        protected override void LoadPreferencesIntoControls()
        {
            Location = new Point(PSettings.PreferenceAll.OverlayMaphack.X,
                                     PSettings.PreferenceAll.OverlayMaphack.Y);
            Size = new Size(PSettings.PreferenceAll.OverlayMaphack.Width, PSettings.PreferenceAll.OverlayMaphack.Height);
            Opacity = PSettings.PreferenceAll.OverlayMaphack.Opacity;
        }

        /// <summary>
        /// Sends the panel specific data into the Form's controls and settings
        /// Also changes the Position directly!
        /// </summary>
        protected override void AdjustPanelPosition()
        {
            if (BSetPosition)
            {
                tmrRefreshGraphic.Interval = 20;

                Location = Cursor.Position;
                PSettings.PreferenceAll.OverlayMaphack.X = Cursor.Position.X;
                PSettings.PreferenceAll.OverlayMaphack.Y = Cursor.Position.Y;
            }

            var strInput = StrBackupChatbox;

            if (String.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));

            if (strInput.Equals(PSettings.PreferenceAll.OverlayMaphack.ChangePosition))
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
        /// Loads some specific data into the Form.
        /// </summary>
        protected override void LoadSpecificData()
        {
            IsHiddenChanged += MaphackRenderer_IsHiddenChanged;
        }

        void MaphackRenderer_IsHiddenChanged(object sender, EventArgs e)
        {
            PSettings.PreferenceAll.OverlayMaphack.LaunchStatus = !IsHidden;
        }

        /// <summary>
        /// Changes settings for a specific Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BaseRenderer_ResizeEnd(object sender, EventArgs e)
        {
            PSettings.PreferenceAll.OverlayMaphack.Height = Height;
            PSettings.PreferenceAll.OverlayMaphack.Width = Width;
            PSettings.PreferenceAll.OverlayMaphack.X = Location.X;
            PSettings.PreferenceAll.OverlayMaphack.Y = Location.Y;
        }
    }
}
