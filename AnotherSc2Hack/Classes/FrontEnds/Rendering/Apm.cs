/// Shows the APM/ EPM of the player

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using AnotherSc2Hack.Classes.BackEnds;
using Predefined;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    public class Apm : BaseRenderer
    {
        public Apm(MainHandler.MainHandler hnd) : base(hnd)
        {
            
        }

        public override void Draw(System.Drawing.BufferedGraphics g)
        {
            try
            {



                if (!_hMainHandler.GInformation.Gameinfo.IsIngame)
                    return;

                var iValidPlayerCount = _hMainHandler.GInformation.Gameinfo.ValidPlayerCount;

                if (iValidPlayerCount == 0)
                    return;

                Opacity = _pSettings.ApmOpacity;
                var iSingleHeight = Height / iValidPlayerCount;
                var fNewFontSize = (float)((29.0 / 100) * iSingleHeight);
                var fInternalFont = new Font(_pSettings.ApmFontName, fNewFontSize, FontStyle.Bold);
                var fInternalFontNormal = new Font(fInternalFont.Name, fNewFontSize, FontStyle.Regular);

                if (!_bChangingPosition)
                {
                    Height = _pSettings.ApmHeight * iValidPlayerCount;
                    Width = _pSettings.ApmWidth;
                }

                var iCounter = 0;
                for (var i = 0; i < _hMainHandler.GInformation.Player.Count; i++)
                {
                    var clPlayercolor = _hMainHandler.GInformation.Player[i].Color;

                    #region Teamcolor

                    RendererHelper.TeamColor(_hMainHandler.GInformation.Player, i,
                                              _hMainHandler.GInformation.Gameinfo.IsTeamcolor, ref clPlayercolor);

                    #endregion

                    #region Escape sequences

                    if (_hMainHandler.GInformation.Player[i].Name.StartsWith("\0") || _hMainHandler.GInformation.Player[i].NameLength <= 0)
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Hostile))
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Observer))
                        continue;

                    if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Referee))
                        continue;

                    if (CheckIfGameheart(_hMainHandler.GInformation.Player[i]))
                        continue;




                    if (_pSettings.ApmRemoveAi)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue;
                    }

                    if (_pSettings.ApmRemoveNeutral)
                    {
                        if (_hMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue;
                    }

                    if (_pSettings.ApmRemoveAllie)
                    {
                        if (_hMainHandler.GInformation.Player[0].Localplayer == 16)
                        {
                            //Do nothing
                        }

                        else
                        {
                            if (_hMainHandler.GInformation.Player[i].Team ==
                                _hMainHandler.GInformation.Player[_hMainHandler.GInformation.Player[i].Localplayer].Team &&
                                !_hMainHandler.GInformation.Player[i].IsLocalplayer)
                                continue;
                        }
                    }

                    if (_pSettings.ApmRemoveLocalplayer)
                    {
                        if (_hMainHandler.GInformation.Player[i].IsLocalplayer)
                            continue;
                    }



                    #endregion

                    #region Draw Bounds and Background

                    if (_pSettings.ApmDrawBackground)
                    {
                        /* Background */
                        g.Graphics.FillRectangle(Brushes.Gray, 1, 1 + (iSingleHeight * iCounter), Width - 2,
                                                 iSingleHeight - 2);

                        /* Border */
                        g.Graphics.DrawRectangle(new Pen(new SolidBrush(clPlayercolor), 2), 1,
                                                 1 + (iSingleHeight * iCounter),
                                                 Width - 2, iSingleHeight - 2);
                    }

                    #endregion

                    #region Content Drawing

                    #region Name

                    var strName = (_hMainHandler.GInformation.Player[i].ClanTag.StartsWith("\0") || _pSettings.ApmRemoveClanTag)
                                         ? _hMainHandler.GInformation.Player[i].Name
                                         : "[" + _hMainHandler.GInformation.Player[i].ClanTag + "] " + _hMainHandler.GInformation.Player[i].Name;

                    Drawing.DrawString(g.Graphics,
                        strName,
                        fInternalFont,
                        new SolidBrush(clPlayercolor),
                        Brushes.Black, (float)((1.67 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Team

                    Drawing.DrawString(g.Graphics,
                        "#" + _hMainHandler.GInformation.Player[i].Team, fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((29.67 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Apm

                    Drawing.DrawString(g.Graphics,
                        "APM: " + _hMainHandler.GInformation.Player[i].ApmAverage +
                        " [" + _hMainHandler.GInformation.Player[i].Apm + "]", fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((37.0 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);


                    #endregion

                    #region Epm

                    Drawing.DrawString(g.Graphics,
                       "EPM: " + _hMainHandler.GInformation.Player[i].EpmAverage +
                        " [" + _hMainHandler.GInformation.Player[i].Epm + "]", fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((63.67 / 100) * Width),
                                          (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #endregion


                    iCounter++;
                }

            }

            catch (Exception ex)
            {
                Messages.LogFile("DrawApm", "Over all", ex);
            }

        }
    }
}
