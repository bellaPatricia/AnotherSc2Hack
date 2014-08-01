using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using Predefined;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    public class Income : BaseRenderer
    {

        private Image _imgMinerals = Properties.Resources.Mineral_Protoss,
                      _imgGas = Properties.Resources.Gas_Protoss,
                      _imgSupply = Properties.Resources.Supply_Protoss,
                      _imgWorker = Properties.Resources.P_Probe;


        public Income(MainHandler.MainHandler hnd)
            : base(hnd)
        {
            
        }

        /// <summary>
        /// Draws the panelspecific data.
        /// </summary>
        /// <param name="g"></param>
        protected override void Draw(BufferedGraphics g)
        {
            try
            {

                if (!HMainHandler.GInformation.Gameinfo.IsIngame)
                    return;

                var iValidPlayerCount = HMainHandler.GInformation.Gameinfo.ValidPlayerCount;

                if (iValidPlayerCount == 0)
                    return;

                Opacity = PSettings.IncomeOpacity;
                var iSingleHeight = Height / iValidPlayerCount;
                var fNewFontSize = (float)((29.0 / 100) * iSingleHeight);
                var fInternalFont = new Font(PSettings.IncomeFontName, fNewFontSize, FontStyle.Bold);
                var fInternalFontNormal = new Font(fInternalFont.Name, fNewFontSize, FontStyle.Regular);

                if (!BChangingPosition)
                {
                    Height = PSettings.IncomeHeight * iValidPlayerCount;
                    Width = PSettings.IncomeWidth;
                }

                var iCounter = 0;
                for (var i = 0; i < HMainHandler.GInformation.Player.Count; i++)
                {
                    var clPlayercolor = HMainHandler.GInformation.Player[i].Color;

                    #region Teamcolor

                    RendererHelper.TeamColor(HMainHandler.GInformation.Player, i,
                                              HMainHandler.GInformation.Gameinfo.IsTeamcolor, ref clPlayercolor);

                    #endregion

                    #region Escape sequences

                    if (PSettings.IncomeRemoveAi)
                    {
                        if (HMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue;
                    }

                    if (PSettings.IncomeRemoveNeutral)
                    {
                        if (HMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue;
                    }

                    if (PSettings.IncomeRemoveAllie)
                    {
                        if (HMainHandler.GInformation.Player[0].Localplayer == 16)
                        {
                            //Do nothing
                        }

                        else
                        {
                            if (HMainHandler.GInformation.Player[i].Team ==
                                HMainHandler.GInformation.Player[HMainHandler.GInformation.Player[i].Localplayer].Team &&
                                !HMainHandler.GInformation.Player[i].IsLocalplayer)
                                continue;
                        }
                    }

                    if (PSettings.IncomeRemoveLocalplayer)
                    {
                        if (HMainHandler.GInformation.Player[i].IsLocalplayer)
                            continue;
                    }

                    if (HMainHandler.GInformation.Player[i].Name.StartsWith("\0") || HMainHandler.GInformation.Player[i].NameLength <= 0)
                        continue;

                    if (HMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Hostile))
                        continue;

                    if (HMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Observer))
                        continue;

                    if (HMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Referee))
                        continue;

                    if (CheckIfGameheart(HMainHandler.GInformation.Player[i]))
                        continue;

                    #endregion

                    #region SetValidImages (Race)

                    if (HMainHandler.GInformation.Player[i].PlayerRace.Equals(PredefinedData.PlayerRace.Terran))
                    {
                        _imgMinerals = Properties.Resources.Mineral_Terran;
                        _imgGas = Properties.Resources.Gas_Terran;
                        _imgSupply = Properties.Resources.Supply_Terran;
                        _imgWorker = Properties.Resources.T_SCV;
                    }

                    else if (HMainHandler.GInformation.Player[i].PlayerRace.Equals(PredefinedData.PlayerRace.Protoss))
                    {
                        _imgMinerals = Properties.Resources.Mineral_Protoss;
                        _imgGas = Properties.Resources.Gas_Protoss;
                        _imgSupply = Properties.Resources.Supply_Protoss;
                        _imgWorker = Properties.Resources.P_Probe;
                    }

                    else
                    {
                        _imgMinerals = Properties.Resources.Mineral_Zerg;
                        _imgGas = Properties.Resources.Gas_Zerg;
                        _imgSupply = Properties.Resources.Supply_Zerg;
                        _imgWorker = Properties.Resources.Z_Drone;
                    }

                    #endregion

                    #region Draw Bounds and Background

                    if (PSettings.IncomeDrawBackground)
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

                    var strName = (HMainHandler.GInformation.Player[i].ClanTag.StartsWith("\0") || PSettings.IncomeRemoveClanTag)
                                         ? HMainHandler.GInformation.Player[i].Name
                                         : "[" + HMainHandler.GInformation.Player[i].ClanTag + "] " + HMainHandler.GInformation.Player[i].Name;


                    Drawing.DrawString(g.Graphics, strName, fInternalFont,
                        new SolidBrush(clPlayercolor),
                        Brushes.Black, (float)((1.67 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Team

                    Drawing.DrawString(g.Graphics, "#" + HMainHandler.GInformation.Player[i].Team, fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((29.67 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Minerals

                    /* Icon */
                    g.Graphics.DrawImage(_imgMinerals, (float)((37.0 / 100) * Width),
                                         (float)((14.0 / 100) * iSingleHeight) + (Height / iValidPlayerCount) * iCounter,
                                         (float)((70.0 / 100) * iSingleHeight), (float)((70.0 / 100) * iSingleHeight));

                    /* Mineral Count */
                    Drawing.DrawString(g.Graphics,
                        HMainHandler.GInformation.Player[i].MineralsIncome.ToString(CultureInfo.InvariantCulture),
                        fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((43.67 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Gas

                    /* Icon */
                    g.Graphics.DrawImage(_imgGas, (float)((57.0 / 100) * Width),
                                         (float)((14.0 / 100) * iSingleHeight) + (Height / iValidPlayerCount) * iCounter,
                                         (float)((70.0 / 100) * iSingleHeight), (float)((70.0 / 100) * iSingleHeight));

                    /* Gas Count */
                    Drawing.DrawString(g.Graphics,
                        HMainHandler.GInformation.Player[i].GasIncome.ToString(CultureInfo.InvariantCulture),
                        fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((63.67 / 100) * Width),
                                          (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Workers

                    /* Icon */
                    g.Graphics.DrawImage(_imgWorker, (float)((75.0 / 100) * Width),
                        (float)((14.0 / 100) * iSingleHeight) + (Height / iValidPlayerCount) * iCounter,
                        (float)((70.0 / 100) * iSingleHeight), (float)((70.0 / 100) * iSingleHeight));

                    /* Worker Count */
                    Drawing.DrawString(g.Graphics,
                        HMainHandler.GInformation.Player[i].Worker.ToString(CultureInfo.InvariantCulture),
                        fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((81.67 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #endregion


                    iCounter++;
                }
            }

            catch (Exception ex)
            {
                Messages.LogFile("DrawIncome", "Over all", ex);
            }
        }

        /// <summary>
        /// Sends the panel specific data into the Form's controls and settings
        /// </summary>
        protected override void MouseUpTransferData()
        {
            /* Has to be calculated manually because each panels has it's own Neutral handling.. */
            var iValidPlayerCount = HMainHandler.GInformation.Gameinfo.ValidPlayerCount;

            HMainHandler.PSettings.IncomePositionX = Location.X;
            HMainHandler.PSettings.IncomePositionY = Location.Y;
            HMainHandler.PSettings.IncomeWidth = Width;
            HMainHandler.PSettings.IncomeHeight = Height / iValidPlayerCount;
            HMainHandler.PSettings.IncomeOpacity = Opacity;

            /* Transfer to Mainform */
            HMainHandler.IncomeInformation.txtPosX.Text = Location.X.ToString(CultureInfo.InvariantCulture);
            HMainHandler.IncomeInformation.txtPosY.Text = Location.Y.ToString(CultureInfo.InvariantCulture);
            HMainHandler.IncomeInformation.txtWidth.Text = Width.ToString(CultureInfo.InvariantCulture);
            HMainHandler.IncomeInformation.txtHeight.Text = Height.ToString(CultureInfo.InvariantCulture);
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
        /// Sends the panel specific data (color) into the Form's controls and settings
        /// </summary>
        protected override void ChangeForecolorOfButton(Color cl)
        {
            HMainHandler.btnIncome.ForeColor = cl;
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

                HMainHandler.PSettings.IncomeWidth = Cursor.Position.X - Left;

                var iValidPlayerCount = HMainHandler.GInformation.Gameinfo.ValidPlayerCount;
                if (HMainHandler.PSettings.IncomeRemoveNeutral)
                    iValidPlayerCount -= 1;

                if ((Cursor.Position.Y - Top) / iValidPlayerCount >= 5)
                {
                    HMainHandler.PSettings.IncomeHeight = (Cursor.Position.Y - Top) /
                                                        iValidPlayerCount;
                }

                else
                    HMainHandler.PSettings.IncomeHeight = 5;
            }

            var strInput = StrBackupSizeChatbox;

            if (String.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));


            if (strInput.Equals(HMainHandler.PSettings.IncomeChangeSizePanel))
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
                tmrRefreshGraphic.Interval = HMainHandler.PSettings.GlobalDrawingRefresh;

                BSetSize = false;
                StrBackupSizeChatbox = string.Empty;

                /* Transfer to Mainform */
                HMainHandler.IncomeInformation.txtWidth.Text = HMainHandler.PSettings.IncomeWidth.ToString(CultureInfo.InvariantCulture);
                HMainHandler.IncomeInformation.txtHeight.Text = HMainHandler.PSettings.IncomeHeight.ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Loads the settings of the specific Form into the controls (Location, Size)
        /// </summary>
        protected override void LoadPreferencesIntoControls()
        {
            Location = new Point(PSettings.IncomePositionX,
                                     PSettings.IncomePositionY);
            Size = new Size(PSettings.IncomeWidth, PSettings.IncomeHeight);
            Opacity = PSettings.IncomeOpacity;
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
                HMainHandler.PSettings.IncomePositionX = Cursor.Position.X;
                HMainHandler.PSettings.IncomePositionY = Cursor.Position.Y;
            }

            var strInput = StrBackupChatbox;

            if (String.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));

            if (strInput.Equals(HMainHandler.PSettings.IncomeChangePositionPanel))
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
                tmrRefreshGraphic.Interval = HMainHandler.PSettings.GlobalDrawingRefresh;

                /* Transfer to Mainform */
                HMainHandler.IncomeInformation.txtPosX.Text = HMainHandler.PSettings.IncomePositionX.ToString(CultureInfo.InvariantCulture);
                HMainHandler.IncomeInformation.txtPosY.Text = HMainHandler.PSettings.IncomePositionY.ToString(CultureInfo.InvariantCulture);
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
            var iValidPlayerCount = HMainHandler.GInformation.Gameinfo.ValidPlayerCount;

            var iRealPlayerCount = iValidPlayerCount == 0 ? 1 : iValidPlayerCount;

            HMainHandler.PSettings.IncomeHeight = (Height / iRealPlayerCount);
            HMainHandler.PSettings.IncomeWidth = Width;
            HMainHandler.PSettings.IncomePositionX = Location.X;
            HMainHandler.PSettings.IncomePositionY = Location.Y;
        }
    }
}
