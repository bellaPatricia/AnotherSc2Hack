using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using Predefined;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    public class ResourcesRenderer : BaseRenderer
    {

        private Image _imgMinerals = Properties.Resources.Mineral_Protoss,
                      _imgGas = Properties.Resources.Gas_Protoss,
                      _imgSupply = Properties.Resources.Supply_Protoss,
                      _imgWorker = Properties.Resources.P_Probe;


        public ResourcesRenderer(MainHandler.MainHandler hnd)
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

                Opacity = PSettings.ResourceOpacity;
                var iSingleHeight = Height / iValidPlayerCount;
                var fNewFontSize = (float)((29.0 / 100) * iSingleHeight);
                var fInternalFont = new Font(PSettings.ResourceFontName, fNewFontSize, FontStyle.Bold);
                var fInternalFontNormal = new Font(fInternalFont.Name, fNewFontSize, FontStyle.Regular);

                if (!BChangingPosition)
                {
                    Height = PSettings.ResourceHeight * iValidPlayerCount;
                    Width = PSettings.ResourceWidth;


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

                    if (PSettings.ResourceRemoveAi)
                    {
                        if (HMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue;
                    }

                    if (PSettings.ResourceRemoveNeutral)
                    {
                        if (HMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue;
                    }

                    if (PSettings.ResourceRemoveAllie)
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

                    if (PSettings.ResourceRemoveLocalplayer)
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

                    if (PSettings.ResourceDrawBackground)
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

                    var strName = (HMainHandler.GInformation.Player[i].ClanTag.StartsWith("\0") || PSettings.ResourceRemoveClanTag)
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
                    Drawing.DrawImage(g.Graphics, _imgMinerals, (float)((37.0 / 100) * Width),
                        (float)((14.0 / 100) * iSingleHeight) + (Height / iValidPlayerCount) * iCounter,
                        (float)((70.0 / 100) * iSingleHeight), (float)((70.0 / 100) * iSingleHeight), Brushes.Black, 1f, 1f,
                        false);

                    Drawing.DrawString(g.Graphics,
                        HMainHandler.GInformation.Player[i].Minerals.ToString(CultureInfo.InvariantCulture),
                        fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((43.67 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Gas

                    /* Icon */
                    Drawing.DrawImage(g.Graphics, _imgGas, (float)((57.0 / 100) * Width),
                        (float)((14.0 / 100) * iSingleHeight) + (Height / iValidPlayerCount) * iCounter,
                        (float)((70.0 / 100) * iSingleHeight), (float)((70.0 / 100) * iSingleHeight), Brushes.Black, 1f, 1f,
                        false);

                    Drawing.DrawString(g.Graphics,
                        HMainHandler.GInformation.Player[i].Gas.ToString(CultureInfo.InvariantCulture),
                        fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((63.67 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Supply

                    /* Icon */
                    Drawing.DrawImage(g.Graphics, _imgSupply, (float)((75.0 / 100) * Width),
                        (float)((14.0 / 100) * iSingleHeight) + (Height / iValidPlayerCount) * iCounter,
                        (float)((70.0 / 100) * iSingleHeight), (float)((70.0 / 100) * iSingleHeight), Brushes.Black, 1f, 1f,
                        false);

                    Drawing.DrawString(g.Graphics,
                        HMainHandler.GInformation.Player[i].SupplyMin.ToString(CultureInfo.InvariantCulture) + "/" +
                        HMainHandler.GInformation.Player[i].SupplyMax,
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
                Messages.LogFile("DrawResource", "Over all", ex);
            }
        }

        /// <summary>
        /// Sends the panel specific data into the Form's controls and settings
        /// </summary>
        protected override void MouseUpTransferData()
        {
            /* Has to be calculated manually because each panels has it's own Neutral handling.. */
            var iValidPlayerCount = HMainHandler.GInformation.Gameinfo.ValidPlayerCount;

            HMainHandler.PSettings.ResourcePositionX = Location.X;
            HMainHandler.PSettings.ResourcePositionY = Location.Y;
            HMainHandler.PSettings.ResourceWidth = Width;
            HMainHandler.PSettings.ResourceHeight = Height / iValidPlayerCount;
            HMainHandler.PSettings.ResourceOpacity = Opacity;

            /* Transfer to Mainform */
            HMainHandler.ResourceInformation.txtPosX.Text = Location.X.ToString(CultureInfo.InvariantCulture);
            HMainHandler.ResourceInformation.txtPosY.Text = Location.Y.ToString(CultureInfo.InvariantCulture);
            HMainHandler.ResourceInformation.txtWidth.Text = Width.ToString(CultureInfo.InvariantCulture);
            HMainHandler.ResourceInformation.txtHeight.Text = Height.ToString(CultureInfo.InvariantCulture);
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
            HMainHandler.btnResources.ForeColor = cl;
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

                HMainHandler.PSettings.ResourceWidth = Cursor.Position.X - Left;

                var iValidPlayerCount = HMainHandler.GInformation.Gameinfo.ValidPlayerCount;
                if (HMainHandler.PSettings.ResourceRemoveNeutral)
                    iValidPlayerCount -= 1;

                if ((Cursor.Position.Y - Top) / iValidPlayerCount >= 5)
                {
                    HMainHandler.PSettings.ResourceHeight = (Cursor.Position.Y - Top) /
                                                        iValidPlayerCount;
                }

                else
                    HMainHandler.PSettings.ResourceHeight = 5;
            }

            var strInput = StrBackupSizeChatbox;

            if (String.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));


            if (strInput.Equals(HMainHandler.PSettings.ResourceChangeSizePanel))
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
                HMainHandler.ResourceInformation.txtWidth.Text = HMainHandler.PSettings.ResourceWidth.ToString(CultureInfo.InvariantCulture);
                HMainHandler.ResourceInformation.txtHeight.Text = HMainHandler.PSettings.ResourceHeight.ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Loads the settings of the specific Form into the controls (Location, Size)
        /// </summary>
        protected override void LoadPreferencesIntoControls()
        {
            Location = new Point(PSettings.ResourcePositionX,
                                     PSettings.ResourcePositionY);
            Size = new Size(PSettings.ResourceWidth, PSettings.ResourceHeight);
            Opacity = PSettings.ResourceOpacity;
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
                HMainHandler.PSettings.ResourcePositionX = Cursor.Position.X;
                HMainHandler.PSettings.ResourcePositionY = Cursor.Position.Y;
            }

            var strInput = StrBackupChatbox;

            if (String.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));

            if (strInput.Equals(HMainHandler.PSettings.ResourceChangePositionPanel))
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
                HMainHandler.ResourceInformation.txtPosX.Text = HMainHandler.PSettings.ResourcePositionX.ToString(CultureInfo.InvariantCulture);
                HMainHandler.ResourceInformation.txtPosY.Text = HMainHandler.PSettings.ResourcePositionY.ToString(CultureInfo.InvariantCulture);
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

            HMainHandler.PSettings.ResourceHeight = (Height / iRealPlayerCount);
            HMainHandler.PSettings.ResourceWidth = Width;
            HMainHandler.PSettings.ResourcePositionX = Location.X;
            HMainHandler.PSettings.ResourcePositionY = Location.Y;
        }
    }
}
