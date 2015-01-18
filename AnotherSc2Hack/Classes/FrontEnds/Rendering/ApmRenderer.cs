using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using Predefined;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    public class ApmRenderer : BaseRenderer
    {
        public ApmRenderer(GameInfo gInformation, Preferences pSettings, Process sc2Process)
            : base(gInformation, pSettings, sc2Process)
        {
            
        }

        /// <summary>
        /// Draws the panelspecific data.
        /// </summary>
        /// <param name="g"></param>
        protected override void Draw(BufferedGraphics g)
        {
            GInformation.CAccessPlayers = true;

            try
            {
                if (!GInformation.Gameinfo.IsIngame)
                    return;

                var iValidPlayerCount = GInformation.Gameinfo.ValidPlayerCount;

                if (iValidPlayerCount == 0)
                    return;

                Opacity = PSettings.ApmOpacity;
                var iSingleHeight = Height / iValidPlayerCount;
                var fNewFontSize = (float)((29.0 / 100) * iSingleHeight);
                var fInternalFont = new Font(PSettings.ApmFontName, fNewFontSize, FontStyle.Bold);
                var fInternalFontNormal = new Font(fInternalFont.Name, fNewFontSize, FontStyle.Regular);

                if (!BChangingPosition)
                {
                    Height = PSettings.ApmHeight * iValidPlayerCount;
                    Width = PSettings.ApmWidth;
                }

                var iCounter = 0;
                for (var i = 0; i < GInformation.Player.Count; i++)
                {
                    var clPlayercolor = GInformation.Player[i].Color;

                    #region Teamcolor

                    RendererHelper.TeamColor(GInformation.Player, i,
                                              GInformation.Gameinfo.IsTeamcolor, ref clPlayercolor);

                    #endregion

                    #region Escape sequences

                    if (GInformation.Player[i].Name.StartsWith("\0") || GInformation.Player[i].NameLength <= 0)
                        continue;

                    if (GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Hostile))
                        continue;

                    if (GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Observer))
                        continue;

                    if (GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Referee))
                        continue;

                    if (CheckIfGameheart(GInformation.Player[i]))
                        continue;




                    if (PSettings.ApmRemoveAi)
                    {
                        if (GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue;
                    }

                    if (PSettings.ApmRemoveNeutral)
                    {
                        if (GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue;
                    }

                    if (PSettings.ApmRemoveAllie)
                    {
                        if (GInformation.Player[0].Localplayer == 16)
                        {
                            //Do nothing
                        }

                        else
                        {
                            if (GInformation.Player[i].Team ==
                                GInformation.Player[GInformation.Player[i].Localplayer].Team &&
                                !GInformation.Player[i].IsLocalplayer)
                                continue;
                        }
                    }

                    if (PSettings.ApmRemoveLocalplayer)
                    {
                        if (GInformation.Player[i].IsLocalplayer)
                            continue;
                    }



                    #endregion

                    #region Draw Bounds and Background

                    if (PSettings.ApmDrawBackground)
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

                    var strName = (GInformation.Player[i].ClanTag.StartsWith("\0") || PSettings.ApmRemoveClanTag)
                                         ? GInformation.Player[i].Name
                                         : "[" + GInformation.Player[i].ClanTag + "] " + GInformation.Player[i].Name;

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
                        "#" + GInformation.Player[i].Team, fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((29.67 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Apm

                    Drawing.DrawString(g.Graphics,
                        "APM: " + GInformation.Player[i].ApmAverage +
                        " [" + GInformation.Player[i].Apm + "]", fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((37.0 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);


                    #endregion

                    #region Epm

                    Drawing.DrawString(g.Graphics,
                       "EPM: " + GInformation.Player[i].EpmAverage +
                        " [" + GInformation.Player[i].Epm + "]", fInternalFontNormal,
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
                Messages.LogFile("Over all", ex);
            }

        }

        /// <summary>
        /// Sends the panel specific data into the Form's controls and settings
        /// </summary>
        protected override void MouseUpTransferData()
        {
            /* Has to be calculated manually because each panels has it's own Neutral handling.. */
            var iValidPlayerCount = GInformation.Gameinfo.ValidPlayerCount;

            PSettings.ApmPositionX = Location.X;
            PSettings.ApmPositionY = Location.Y;
            PSettings.ApmWidth = Width;
            PSettings.ApmHeight = Height / iValidPlayerCount;
            PSettings.ApmOpacity = Opacity;
        }

        /// <summary>
        /// Sends the panel specific data into the Form's controls and settings
        /// </summary>
        protected override void MouseWheelTransferData(MouseEventArgs e)
        {
            if (e.Delta.Equals(120))
            {
                Width += 4;
                Height += 1;
            }

            else if (e.Delta.Equals(-120))
            {
                Width -= 4;
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

                PSettings.ApmWidth = Cursor.Position.X - Left;

                var iValidPlayerCount = GInformation.Gameinfo.ValidPlayerCount;
                if (PSettings.ApmRemoveNeutral)
                    iValidPlayerCount -= 1;

                if ((Cursor.Position.Y - Top) / iValidPlayerCount >= 5)
                {
                    PSettings.ApmHeight = (Cursor.Position.Y - Top) /
                                                        iValidPlayerCount;
                }

                else
                    PSettings.ApmHeight = 5;
            }

            var strInput = StrBackupSizeChatbox;

            if (String.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));


            if (strInput.Equals(PSettings.ApmChangeSizePanel))
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
                tmrRefreshGraphic.Interval = PSettings.GlobalDrawingRefresh;

                BSetSize = false;
                StrBackupSizeChatbox = string.Empty;
            }
        }

        /// <summary>
        /// Loads the settings of the specific Form into the controls (Location, Size)
        /// </summary>
        protected override void LoadPreferencesIntoControls()
        {
            Location = new Point(PSettings.ApmPositionX,
                                     PSettings.ApmPositionY);
            Size = new Size(PSettings.ApmWidth, PSettings.ApmHeight);
            Opacity = PSettings.ApmOpacity;
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
                PSettings.ApmPositionX = Cursor.Position.X;
                PSettings.ApmPositionY = Cursor.Position.Y;
            }

            var strInput = StrBackupChatbox;

            if (String.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));

            if (strInput.Equals(PSettings.ApmChangePositionPanel))
            {
                if (BTogglePosition)
                {
                    BTogglePosition = !BTogglePosition;

                    if (!BSetPosition)
                        BSetPosition = true;
                }
            }

            if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
            {
                BSetPosition = false;
                StrBackupChatbox = string.Empty;
                tmrRefreshGraphic.Interval = PSettings.GlobalDrawingRefresh;
            }
        }

        /// <summary>
        /// Loads some specific data into the Form.
        /// </summary>
        protected override void LoadSpecificData()
        {
            /* Nothing special here :) */
        }

        /// <summary>
        /// Changes settings for a specific Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BaseRenderer_ResizeEnd(object sender, EventArgs e)
        {
            /* If the Valid Player count is zero, change it.. */
            var iValidPlayerCount = GInformation.Gameinfo.ValidPlayerCount;

            var iRealPlayerCount = iValidPlayerCount == 0 ? 1 : iValidPlayerCount;

            PSettings.ApmHeight = (Height / iRealPlayerCount);
            PSettings.ApmWidth = Width;
            PSettings.ApmPositionX = Location.X;
            PSettings.ApmPositionY = Location.Y;
        }
    }
}
