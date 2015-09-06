using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using PredefinedTypes;
using Utilities.ExtensionMethods;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    public class WorkerRenderer : BaseRenderer
    {
        public WorkerRenderer(GameInfo gInformation, PreferenceManager pSettings, Process sc2Process)
            : base(gInformation, pSettings, sc2Process)
        {
            IsHiddenChanged += WorkerRenderer_IsHiddenChanged;
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
                {
                    g.Graphics.Clear(BackColor);
                    return;
                }

                if (GInformation.Player == null ||
                    GInformation.Player.Count <= 0)
                    return;

                Opacity = PSettings.PreferenceAll.OverlayWorker.Opacity;
                var iSingleHeight = Height;
                var fNewFontSize = (float) ((29.0/100)*iSingleHeight);
                var fInternalFont = new Font(PSettings.PreferenceAll.OverlayWorker.FontName, fNewFontSize,
                    FontStyle.Bold);

                Color clPlayercolor;

                if (Player.LocalPlayer != null)
                    clPlayercolor = Player.LocalPlayer.Color;

                else
                    return;

                if (!BChangingPosition)
                {
                    Height = PSettings.PreferenceAll.OverlayWorker.Height;
                    Width = PSettings.PreferenceAll.OverlayWorker.Width;
                }

                #region Teamcolor

                if (GInformation.Gameinfo.IsTeamcolor)
                    clPlayercolor = Color.Green;

                #endregion

                #region Draw Bounds and Background

                if (PSettings.PreferenceAll.OverlayWorker.DrawBackground)
                {
                    /* Background */
                    g.Graphics.FillRectangle(Brushes.Gray, 1, 1, Width - 2, iSingleHeight - 2);

                    /* Border */
                    g.Graphics.DrawRectangle(new Pen(new SolidBrush(clPlayercolor), 2), 1, 1, Width - 2,
                        iSingleHeight - 2);
                }

                #endregion

                #region Worker

                g.Graphics.DrawString(
                    $"{Player.LocalPlayer.Worker} [+{Player.LocalPlayer.WorkerInConstruction}] Workers",
                    fInternalFont,
                    new SolidBrush(clPlayercolor),
                    Brushes.Black, (float) ((16.67/100)*Width),
                    (float) ((24.0/100)*iSingleHeight),
                    1f, 1f, true);

                #endregion
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
            PSettings.PreferenceAll.OverlayWorker.X = Location.X;
            PSettings.PreferenceAll.OverlayWorker.Y = Location.Y;
            PSettings.PreferenceAll.OverlayWorker.Width = Width;
            PSettings.PreferenceAll.OverlayWorker.Height = Height;
            PSettings.PreferenceAll.OverlayWorker.Opacity = Opacity;
        }

        /// <summary>
        ///     Sends the panel specific data into the Form's controls and settings
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
        ///     Sends the panel specific data into the Form's controls and settings
        ///     Also changes the Size directly!
        /// </summary>
        protected override void AdjustPanelSize()
        {
            if (BSetSize)
            {
                tmrRefreshGraphic.Interval = 20;

                PSettings.PreferenceAll.OverlayWorker.Width = Cursor.Position.X - Left;

                var iValidPlayerCount = GInformation.Gameinfo.ValidPlayerCount;

                if ((Cursor.Position.Y - Top)/iValidPlayerCount >= 5)
                {
                    PSettings.PreferenceAll.OverlayWorker.Height = (Cursor.Position.Y - Top)/
                                                                   iValidPlayerCount;
                }

                else
                    PSettings.PreferenceAll.OverlayWorker.Height = 5;
            }

            var strInput = StrBackupSizeChatbox;

            if (string.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));


            if (strInput.Equals(PSettings.PreferenceAll.OverlayWorker.ChangeSize))
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
            Location = new Point(PSettings.PreferenceAll.OverlayWorker.X,
                PSettings.PreferenceAll.OverlayWorker.Y);
            Size = new Size(PSettings.PreferenceAll.OverlayWorker.Width, PSettings.PreferenceAll.OverlayWorker.Height);
            Opacity = PSettings.PreferenceAll.OverlayWorker.Opacity;
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
                PSettings.PreferenceAll.OverlayWorker.X = Cursor.Position.X;
                PSettings.PreferenceAll.OverlayWorker.Y = Cursor.Position.Y;
            }

            var strInput = StrBackupChatbox;

            if (string.IsNullOrEmpty(strInput))
                return;

            if (strInput.Contains('\0'))
                strInput = strInput.Substring(0, strInput.IndexOf('\0'));

            if (strInput.Equals(PSettings.PreferenceAll.OverlayWorker.ChangePosition))
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

        private void WorkerRenderer_IsHiddenChanged(object sender, EventArgs e)
        {
            PSettings.PreferenceAll.OverlayWorker.LaunchStatus = !IsHidden;
        }

        /// <summary>
        ///     Changes settings for a specific Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BaseRenderer_ResizeEnd(object sender, EventArgs e)
        {
            PSettings.PreferenceAll.OverlayWorker.Height = Height;
            PSettings.PreferenceAll.OverlayWorker.Width = Width;
            PSettings.PreferenceAll.OverlayWorker.X = Location.X;
            PSettings.PreferenceAll.OverlayWorker.Y = Location.Y;
        }
    }
}