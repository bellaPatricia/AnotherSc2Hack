using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using Predefined;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    public class WorkerRenderer : BaseRenderer
    {

        private Image _imgMinerals = Properties.Resources.Mineral_Protoss,
                      _imgGas = Properties.Resources.Gas_Protoss,
                      _imgWorker = Properties.Resources.P_Probe;


        public WorkerRenderer(MainHandler.MainHandler hnd)
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
                {
                    g.Graphics.Clear(BackColor);
                    return;
                }

                if (HMainHandler.GInformation.Player == null ||
                    HMainHandler.GInformation.Player.Count <= 0)
                    return;

                Opacity = PSettings.WorkerOpacity;
                var iSingleHeight = Height;
                var fNewFontSize = (float)((29.0 / 100) * iSingleHeight);
                var fInternalFont = new Font(PSettings.WorkerFontName, fNewFontSize, FontStyle.Bold);

                Color clPlayercolor;

                if (HMainHandler.GInformation.Player[0].Localplayer < HMainHandler.GInformation.Player.Count)
                    clPlayercolor = HMainHandler.GInformation.Player[HMainHandler.GInformation.Player[0].Localplayer].Color;

                else
                    return;

                if (!BChangingPosition)
                {
                    Height = PSettings.WorkerHeight;
                    Width = PSettings.WorkerWidth;
                }

                #region Teamcolor

                if (HMainHandler.GInformation.Gameinfo.IsTeamcolor)
                    clPlayercolor = Color.Green;

                #endregion

                #region Draw Bounds and Background

                if (PSettings.WorkerDrawBackground)
                {
                    /* Background */
                    g.Graphics.FillRectangle(Brushes.Gray, 1, 1, Width - 2, iSingleHeight - 2);

                    /* Border */
                    g.Graphics.DrawRectangle(new Pen(new SolidBrush(clPlayercolor), 2), 1, 1, Width - 2,
                                             iSingleHeight - 2);
                }

                #endregion

                #region Worker

                Drawing.DrawString(g.Graphics,
                        HMainHandler.GInformation.Player[HMainHandler.GInformation.Player[0].Localplayer].Worker + "   Workers",
                        fInternalFont,
                        new SolidBrush(clPlayercolor),
                        Brushes.Black, (float)((16.67 / 100) * Width),
                                      (float)((24.0 / 100) * iSingleHeight),
                        1f, 1f, true);

                #endregion

            }

            catch (Exception ex)
            {
                Messages.LogFile("DrawWorker", "Over all", ex);
            }
        }

        /// <summary>
        /// Sends the panel specific data into the Form's controls and settings
        /// </summary>
        protected override void MouseUpTransferData()
        {
            HMainHandler.PSettings.WorkerPositionX = Location.X;
            HMainHandler.PSettings.WorkerPositionY = Location.Y;
            HMainHandler.PSettings.WorkerWidth = Width;
            HMainHandler.PSettings.WorkerHeight = Height;
            HMainHandler.PSettings.WorkerOpacity = Opacity;

            /* Transfer to Mainform */
            HMainHandler.WorkerInformation.txtPosX.Text = Location.X.ToString(CultureInfo.InvariantCulture);
            HMainHandler.WorkerInformation.txtPosY.Text = Location.Y.ToString(CultureInfo.InvariantCulture);
            HMainHandler.WorkerInformation.txtWidth.Text = Width.ToString(CultureInfo.InvariantCulture);
            HMainHandler.WorkerInformation.txtHeight.Text = Height.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Sends the panel specific data into the Form's controls and settings
        /// </summary>
        protected override void MouseWheelTransferData(MouseEventArgs e)
        {
            if (e.Delta.Equals(120))
            {
                Width += 3;
                Height += 1;
            }

            else if (e.Delta.Equals(-120))
            {
                Width -= 3;
                Height -= 1;
            }
        }

        /// <summary>
        /// Sends the panel specific data (color) into the Form's controls and settings
        /// </summary>
        protected override void ChangeForecolorOfButton(Color cl)
        {
            HMainHandler.btnWorker.ForeColor = cl;
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

                HMainHandler.PSettings.WorkerWidth = Cursor.Position.X - Left;

                var iValidPlayerCount = HMainHandler.GInformation.Gameinfo.ValidPlayerCount;

                if ((Cursor.Position.Y - Top) / iValidPlayerCount >= 5)
                {
                    HMainHandler.PSettings.WorkerHeight = (Cursor.Position.Y - Top) /
                                                        iValidPlayerCount;
                }

                else
                    HMainHandler.PSettings.WorkerHeight = 5;
            }

            var strInput = StrBackupSizeChatbox;

            if (String.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));


            if (strInput.Equals(HMainHandler.PSettings.WorkerChangeSizePanel))
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
                HMainHandler.WorkerInformation.txtWidth.Text = HMainHandler.PSettings.WorkerWidth.ToString(CultureInfo.InvariantCulture);
                HMainHandler.WorkerInformation.txtHeight.Text = HMainHandler.PSettings.WorkerHeight.ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Loads the settings of the specific Form into the controls (Location, Size)
        /// </summary>
        protected override void LoadPreferencesIntoControls()
        {
            Location = new Point(PSettings.WorkerPositionX,
                                     PSettings.WorkerPositionY);
            Size = new Size(PSettings.WorkerWidth, PSettings.WorkerHeight);
            Opacity = PSettings.WorkerOpacity;
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
                HMainHandler.PSettings.WorkerPositionX = Cursor.Position.X;
                HMainHandler.PSettings.WorkerPositionY = Cursor.Position.Y;
            }

            var strInput = StrBackupChatbox;

            if (String.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));

            if (strInput.Equals(HMainHandler.PSettings.WorkerChangePositionPanel))
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
                HMainHandler.WorkerInformation.txtPosX.Text = HMainHandler.PSettings.WorkerPositionX.ToString(CultureInfo.InvariantCulture);
                HMainHandler.WorkerInformation.txtPosY.Text = HMainHandler.PSettings.WorkerPositionY.ToString(CultureInfo.InvariantCulture);
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
            HMainHandler.PSettings.WorkerHeight = Height;
            HMainHandler.PSettings.WorkerWidth = Width;
            HMainHandler.PSettings.WorkerPositionX = Location.X;
            HMainHandler.PSettings.WorkerPositionY = Location.Y;
        }
    }
}
