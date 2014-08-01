/// Shows the APM/ EPM of the player

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using Predefined;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    public class Apm : BaseRenderer
    {
        public Apm(MainHandler.MainHandler hnd) : base(hnd)
        {
            
        }

        public override void Draw(BufferedGraphics g)
        {
            try
            {



                if (!HMainHandler.GInformation.Gameinfo.IsIngame)
                    return;

                var iValidPlayerCount = HMainHandler.GInformation.Gameinfo.ValidPlayerCount;

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
                for (var i = 0; i < HMainHandler.GInformation.Player.Count; i++)
                {
                    var clPlayercolor = HMainHandler.GInformation.Player[i].Color;

                    #region Teamcolor

                    RendererHelper.TeamColor(HMainHandler.GInformation.Player, i,
                                              HMainHandler.GInformation.Gameinfo.IsTeamcolor, ref clPlayercolor);

                    #endregion

                    #region Escape sequences

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




                    if (PSettings.ApmRemoveAi)
                    {
                        if (HMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Ai))
                            continue;
                    }

                    if (PSettings.ApmRemoveNeutral)
                    {
                        if (HMainHandler.GInformation.Player[i].Type.Equals(PredefinedData.PlayerType.Neutral))
                            continue;
                    }

                    if (PSettings.ApmRemoveAllie)
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

                    if (PSettings.ApmRemoveLocalplayer)
                    {
                        if (HMainHandler.GInformation.Player[i].IsLocalplayer)
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

                    var strName = (HMainHandler.GInformation.Player[i].ClanTag.StartsWith("\0") || PSettings.ApmRemoveClanTag)
                                         ? HMainHandler.GInformation.Player[i].Name
                                         : "[" + HMainHandler.GInformation.Player[i].ClanTag + "] " + HMainHandler.GInformation.Player[i].Name;

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
                        "#" + HMainHandler.GInformation.Player[i].Team, fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((29.67 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);

                    #endregion

                    #region Apm

                    Drawing.DrawString(g.Graphics,
                        "APM: " + HMainHandler.GInformation.Player[i].ApmAverage +
                        " [" + HMainHandler.GInformation.Player[i].Apm + "]", fInternalFontNormal,
                        Brushes.White,
                        Brushes.Black, (float)((37.0 / 100) * Width),
                        (float)((24.0 / 100) * iSingleHeight) + iSingleHeight * iCounter,
                        1f, 1f, true);


                    #endregion

                    #region Epm

                    Drawing.DrawString(g.Graphics,
                       "EPM: " + HMainHandler.GInformation.Player[i].EpmAverage +
                        " [" + HMainHandler.GInformation.Player[i].Epm + "]", fInternalFontNormal,
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

        protected override void MouseUpTransferData()
        {
            /* Has to be calculated manually because each panels has it's own Neutral handling.. */
            var iValidPlayerCount = HMainHandler.GInformation.Gameinfo.ValidPlayerCount;

            HMainHandler.PSettings.ApmPositionX = Location.X;
            HMainHandler.PSettings.ApmPositionY = Location.Y;
            HMainHandler.PSettings.ApmWidth = Width;
            HMainHandler.PSettings.ApmHeight = Height / iValidPlayerCount;
            HMainHandler.PSettings.ApmOpacity = Opacity;

            /* Transfer to Mainform */
            HMainHandler.ApmInformation.txtPosX.Text = Location.X.ToString(CultureInfo.InvariantCulture);
            HMainHandler.ApmInformation.txtPosY.Text = Location.Y.ToString(CultureInfo.InvariantCulture);
            HMainHandler.ApmInformation.txtWidth.Text = Width.ToString(CultureInfo.InvariantCulture);
            HMainHandler.ApmInformation.txtHeight.Text = Height.ToString(CultureInfo.InvariantCulture);
        }

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

        protected override void ChangeForecolorOfButton(Color cl)
        {
            HMainHandler.btnApm.ForeColor = cl;
        }

        protected override void AdjustPanelSize()
        {
            if (BSetSize)
            {
                tmrRefreshGraphic.Interval = 20;

                HMainHandler.PSettings.ApmWidth = Cursor.Position.X - Left;

                var iValidPlayerCount = HMainHandler.GInformation.Gameinfo.ValidPlayerCount;
                if (HMainHandler.PSettings.ResourceRemoveNeutral)
                    iValidPlayerCount -= 1;

                if ((Cursor.Position.Y - Top) / iValidPlayerCount >= 5)
                {
                    HMainHandler.PSettings.ApmHeight = (Cursor.Position.Y - Top) /
                                                        iValidPlayerCount;
                }

                else
                    HMainHandler.PSettings.MaphackHeight = 5;
            }

            var strInput = StrBackupSize;

            if (String.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));


            if (strInput.Equals(HMainHandler.PSettings.ApmChangeSizePanel))
            {
                if (BToggleSize)
                {
                    BToggleSize = !BToggleSize;

                    if (!BSetSize)
                        BSetSize = true;
                }
            }

            if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
            {
                tmrRefreshGraphic.Interval = HMainHandler.PSettings.GlobalDrawingRefresh;

                BSetSize = false;
                StrBackupSize = string.Empty;

                /* Transfer to Mainform */
                HMainHandler.ApmInformation.txtWidth.Text = HMainHandler.PSettings.ApmWidth.ToString(CultureInfo.InvariantCulture);
                HMainHandler.ApmInformation.txtHeight.Text = HMainHandler.PSettings.ApmHeight.ToString(CultureInfo.InvariantCulture);
            }
        }

        protected override void LoadPreferencesIntoControls()
        {
            Location = new Point(PSettings.ApmPositionX,
                                     PSettings.ApmPositionY);
            Size = new Size(PSettings.ApmWidth, PSettings.ApmHeight);
            Opacity = PSettings.ApmOpacity;
        }

        protected override void AdjustPanelPosition()
        {
            if (BSetPosition)
            {
                tmrRefreshGraphic.Interval = 20;

                Location = Cursor.Position;
                HMainHandler.PSettings.ApmPositionX = Cursor.Position.X;
                HMainHandler.PSettings.ApmPositionY = Cursor.Position.Y;
            }

            var strInput = StrBackup;

            if (String.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));

            if (strInput.Equals(HMainHandler.PSettings.ApmChangePositionPanel))
            {
                if (BToggle)
                {
                    BToggle = !BToggle;

                    if (!BSetPosition)
                        BSetPosition = true;
                }
            }

            if (HelpFunctions.HotkeysPressed(Keys.Enter, Keys.Enter, Keys.Enter))
            {
                BSetPosition = false;
                StrBackup = string.Empty;
                tmrRefreshGraphic.Interval = HMainHandler.PSettings.GlobalDrawingRefresh;

                /* Transfer to Mainform */
                HMainHandler.ApmInformation.txtPosX.Text = HMainHandler.PSettings.ApmPositionX.ToString(CultureInfo.InvariantCulture);
                HMainHandler.ApmInformation.txtPosY.Text = HMainHandler.PSettings.ApmPositionY.ToString(CultureInfo.InvariantCulture);
            }
        }

        protected override void LoadSpedificData()
        {
            /* Nothing special here :) */
        }

        protected override void BaseRenderer_ResizeEnd(object sender, EventArgs e)
        {
            /* If the Valid Player count is zero, change it.. */
            var iValidPlayerCount = HMainHandler.GInformation.Gameinfo.ValidPlayerCount;

            var iRealPlayerCount = iValidPlayerCount == 0 ? 1 : iValidPlayerCount;

            HMainHandler.PSettings.ApmHeight = (Height / iRealPlayerCount);
            HMainHandler.PSettings.ApmWidth = Width;
            HMainHandler.PSettings.ApmPositionX = Location.X;
            HMainHandler.PSettings.ApmPositionY = Location.Y;
        }
    }
}
