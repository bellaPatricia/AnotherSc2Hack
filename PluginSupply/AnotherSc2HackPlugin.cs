/// PluginSupply
/// A plugin to show the supply of all players
/// Version 1.0.0.0 as of 2014-June-05
/// by bellaPatricia
/// 
/// Feel free to edit, change and copy this code!


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using PredefinedTypes = Predefined.PredefinedData;
using PluginInterface;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.IO;
using PluginSupply;

namespace Plugin.Extensions
{
    public class Renderer : Form
    {
        #region Public Accessors

        public PredefinedTypes.PList PList { get; set; }
        public PredefinedTypes.Gameinformation GInfo { get; set; }
        public PredefinedTypes.CustomWindowStyles SetWindowStyle { get; set; }

        #endregion

        #region Private variables

        private readonly Timer _tmrMainTick = new Timer();                                      /* Maintimer */
        private Font _fCenturyGothic12 = new Font("Centruy Gothic", 12, FontStyle.Regular);     /* Default- font (size wioll be changed) */
        private readonly Pen _pYellowGreen2 = new Pen(Brushes.YellowGreen, 2);                  /* Default pen for resize (border) */
        private Boolean _bMouseDown;                                                            /* Variable to make sure to not set the height */
        private Boolean _bChangingPosition;                                                     /*  */
        private Point _ptMousePosition = new Point(0, 0);                                       /* Position of the mouse-cursor */
        private const Int32 SizeOfRectangle = 10;                                               /* Size of the rectangle(s) @ resizing */
        private readonly Preferences _pSettings = new Preferences();                            /* Psettings - load and writes settings */
        private Int32 _iRealPlayerCount;                                                        /* Contains the actual playercount */
        private bool _bChangingCursor;                                                          /*  */
        private bool _bNswe;                                                                    /*  */
        Int32 _iTimer;                                                                          /* Counter for the 2 second delay ofter position- keypress */
        DateTime _dtStart = DateTime.Now;                                                       /* Datetime */

        #endregion

        #region Interopservices - kernel-/ user- calls

        /* GetWindowLong */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

        /* SetWindowLong */
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        /* GetAsyncKeyState */
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Int32 vKey);

        /* SetForegroundWindow */
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        #endregion

        #region Interopservices - Enumerations

        [Flags]
        public enum Gwl
        {
            ExStyle = -20
        }

        [Flags]
        public enum Ws
        {
            Caption = 0x00C00000,
            Border = 0x00800000,
            ExLayered = 0x80000,
            Sysmenu = 0x00080000,
            Minimizebox = 0x00020000,
            ExTransparent = 0x20

        }

        #endregion

        public Renderer()
        {
            SetStyle(ControlStyles.DoubleBuffer |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint, true);

            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;

            
            

            
            _tmrMainTick.Interval = 40;                 /* 25 FPS */
            _tmrMainTick.Enabled = true;

            #region Events

            MouseMove += Renderer_MouseMove;
            MouseDown += Renderer_MouseDown;
            MouseUp += Renderer_MouseUp;
            MouseWheel += Renderer_MouseWheel;
            SizeChanged += Renderer_SizeChanged;

            FormClosing += Renderer_FormClosing;

            Load += Renderer_Load;

            _tmrMainTick.Tick += _tmrMainTick_Tick;

            #endregion

        }

        void _tmrMainTick_Tick(object sender, EventArgs e)
        {
            Invalidate();


            if (HotkeysPressed(_pSettings.Key))
            {
                SetWindowStyle = PredefinedTypes.CustomWindowStyles.Clickable;
                //FormBorderStyle = FormBorderStyle.SizableToolWindow;
                _iTimer = 2;
                _dtStart = DateTime.Now;
            }

            else if (_iTimer <= 0)
            {
                SetWindowStyle = PredefinedTypes.CustomWindowStyles.NotClickable;
                //FormBorderStyle = FormBorderStyle.None;
            }

            ChangeWindowStyle();


            if ((DateTime.Now - _dtStart).Seconds >= 1)
            {
                _dtStart = DateTime.Now;
                _iTimer -= 1;
            }

            Text = _iTimer.ToString();
        }


        #region Formevents
        void Renderer_SizeChanged(object sender, EventArgs e)
        {
            if (Height != 0 && _iRealPlayerCount  != 0)
            _pSettings.Height = Height / _iRealPlayerCount;
        }

        void Renderer_Load(object sender, EventArgs e)
        {
            Location = new Point(_pSettings.X, _pSettings.Y);
            Width = _pSettings.Width;
            TopMost = true;
            //Height = _pSettings.Height;

            BackColor = Color.FromArgb(255, 64, 0, 64);
            TransparencyKey = Color.FromArgb(255, 64, 0, 64);
        }

        void Renderer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_iRealPlayerCount == 0)
                _iRealPlayerCount = 1;

            /* Set position & size to settingsfile */
            _pSettings.X = Location.X;
            _pSettings.Y = Location.Y;
            _pSettings.Width = Width;
            _pSettings.Height = Height / _iRealPlayerCount;
            

            _pSettings.Write();
            _tmrMainTick.Enabled = false;
        }

        #endregion

        #region Mouseevents
        void Renderer_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Width >= Screen.PrimaryScreen.Bounds.Width &&
               e.Delta.Equals(120))
                return;

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

        void Renderer_MouseUp(object sender, MouseEventArgs e)
        {
           // SetForegroundWindow(Process.GetProcessesByName("SC2")[0].MainWindowHandle);
            //FormBorderStyle = FormBorderStyle.None;

            /* Set position & size to settingsfile */
            _pSettings.X = Location.X;
            _pSettings.Y = Location.Y;
            _pSettings.Width = Width;
            _pSettings.Height = Height / _iRealPlayerCount;

            _bChangingPosition = false;
            _bMouseDown = false;
            _bNswe = false;
            _bChangingCursor = false;
        }

        void Renderer_MouseDown(object sender, MouseEventArgs e)
        {
            _ptMousePosition = new Point(e.X, e.Y);

            _bMouseDown = true;
        }

        
        void Renderer_MouseMove(object sender, MouseEventArgs e)
        {
            /* Get pos on form */
            var pos = Cursor.Position;

            if (pos.X > Left + Width - 10 &&
                pos.X < Left + Width &&
                pos.Y > Top + Height - 10 &&
                     pos.Y < Top + Height)
            {
                Cursor = Cursors.SizeNWSE;
                _bChangingCursor = true;
                _bNswe = true;
            }

            else if (pos.X > Left + Width - 10 &&
                pos.X < Left + Width &&
                !_bNswe)
            {
                //Width = Cursor.Position.X;
                Cursor = Cursors.SizeWE;
                _bChangingCursor = true;
            }

            else if (pos.Y > Top + Height - 10 &&
                     pos.Y < Top + Height && 
                !_bNswe)
            {
                //Height = Cursor.Position.Y;
                Cursor = Cursors.SizeNS;
                _bChangingCursor = true;
            }

            else
            {
                if (pos.X > (Left + Width/2) - SizeOfRectangle &&
                    pos.X < (Left + Width/2) + SizeOfRectangle &&
                    pos.Y > (Top + Height/2) - SizeOfRectangle &&
                    pos.Y < (Top + Height/2) + SizeOfRectangle)
                    Cursor = Cursors.Default;

                if (!_bChangingCursor)
                Cursor = Cursors.Default;
            }


            if (e.Button == MouseButtons.Left)
            {
                if (Cursor.Equals(Cursors.SizeNS))
                {
                    Height = (pos.Y - Top);
                }

                else if (Cursor.Equals(Cursors.SizeWE))
                {
                    Width = (pos.X - Left);
                }

                else if (Cursor.Equals(Cursors.SizeNWSE))
                {
                    Height = (pos.Y - Top);
                    Width = (pos.X - Left);
                }

                else
                {
                    var mousePos = MousePosition;
                    mousePos.Offset(-_ptMousePosition.X, -_ptMousePosition.Y);
                    Location = mousePos;
                }
            }
        }

        #endregion

        #region Drawing

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var context = new BufferedGraphicsContext();
            context.MaximumBuffer = ClientSize;

            using (BufferedGraphics buffer = context.Allocate(e.Graphics, ClientRectangle))
            {
                buffer.Graphics.Clear(BackColor);
                buffer.Graphics.CompositingMode = CompositingMode.SourceOver;
                buffer.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                buffer.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                buffer.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                if (GInfo != null && GInfo.IsIngame)
                {
                    Drawing(buffer.Graphics);
                }

                #region Draw a Rectangle around the Panels (When changing position)

                /* Draw a final bound around the panel */
                if (_bChangingPosition)
                {


                    /* Simple border */
                    buffer.Graphics.DrawRectangle(_pYellowGreen2,
                        1,
                        1,
                        Width - 2,
                        Height - 2);

                    /* Draw some filled frectangles to make the resizing easier */
                    buffer.Graphics.FillRectangle(Brushes.YellowGreen,
                        Width - SizeOfRectangle, 0, SizeOfRectangle,
                        SizeOfRectangle);

                    buffer.Graphics.FillRectangle(Brushes.YellowGreen,
                        0, Height - SizeOfRectangle, SizeOfRectangle,
                        SizeOfRectangle);

                    buffer.Graphics.FillRectangle(Brushes.YellowGreen,
                        Width - SizeOfRectangle, Height - SizeOfRectangle,
                        SizeOfRectangle, SizeOfRectangle);

                    buffer.Graphics.FillRectangle(Brushes.YellowGreen,
                        Width/2 - SizeOfRectangle, Height/2 - SizeOfRectangle,
                        SizeOfRectangle*2, SizeOfRectangle*2);

                    /* Draw current size */
                    buffer.Graphics.DrawString(
                        Width.ToString() + "x" +
                        Height.ToString() + " - [X=" +
                        Location.X.ToString() + "; Y=" + Location.Y.ToString() + "]",
                        new Font("Arial", 8, FontStyle.Regular), Brushes.YellowGreen, 2, 2);
                }

                else
                    Cursor = Cursors.Default;

                #endregion


                buffer.Render();
            }

            context.Dispose();
        }

        private void Drawing(Graphics g)
        {
            /* In b4 exceptions of index */
            if (PList == null ||
                PList.Count <= 0)
                return;

            /* Resize based on width */
            var fNewFontSize = (float)((12.0 / 100) * Width  );
            _fCenturyGothic12 = new Font(_fCenturyGothic12.Name, fNewFontSize, FontStyle.Regular);

            /* Size per item */
            var iSize = _pSettings.Height;

            /* Will not change size if it gets resized manually */
            if (!_bMouseDown)
                Height = iSize * _iRealPlayerCount;


            var iCounter = 0;
            foreach (var t in PList)
            {


                var p = t;
                var cl = p.Color;

                TeamColor(PList, iCounter,
                                              GInfo.IsTeamcolor, ref cl);

                /* Gonna ignore useless players! */
                if (p.Type.Equals(PredefinedTypes.PlayerType.Neutral) ||
                    p.Type.Equals(PredefinedTypes.PlayerType.Hostile) ||
                    p.Type.Equals(PredefinedTypes.PlayerType.Observer) ||
                    p.Type.Equals(PredefinedTypes.PlayerType.Referee) ||
                    p.NameLength <= 2)
                    continue;

                /* Make the colored circle */
                DrawString(g, "●", _fCenturyGothic12, new SolidBrush(p.Color), Brushes.Black, (float) ((1.67/100)*Width),
                    (float) ((17.0/100)*iSize) + iSize*iCounter, 1f, 1f, true);

                

                /* Now the actual supply */
                var strSupply = t.SupplyMin + "/" + t.SupplyMax;
                DrawString(g, strSupply, _fCenturyGothic12, Brushes.White, Brushes.Black,
                    (float) ((1.67/100)*Width) + TextRenderer.MeasureText("●", _fCenturyGothic12).Width,
                    (float) ((17.0/100)*iSize) + iSize*iCounter, 1f, 1f, true);


                iCounter += 1;
            }

            _iRealPlayerCount = iCounter;

            
        }

        /* Change the windowstyle */
        private void ChangeWindowStyle()
        {
            if (SetWindowStyle.Equals(PredefinedTypes.CustomWindowStyles.Clickable))
            {
                _bChangingPosition = true;
                ChangeWindowStyle(Handle, PredefinedTypes.CustomWindowStyles.Clickable);
                //FormBorderStyle = FormBorderStyle.SizableToolWindow;
            }

            else if (SetWindowStyle.Equals(PredefinedTypes.CustomWindowStyles.NotClickable))
            {
                if (!_bMouseDown)
                    _bChangingPosition = false;
                ChangeWindowStyle(Handle, PredefinedTypes.CustomWindowStyles.NotClickable);
                //FormBorderStyle = FormBorderStyle.None;
            }
        }

        public static void DrawString(Graphics g, string text, Font font, Brush textBrush, Brush shadowBrush, float x, float y, float shadowXOffset, float shadowYOffset, bool addShadow)
        {
            if (addShadow)
            {
                /* Shadow */
                g.DrawString(text, font, shadowBrush, x + shadowXOffset, y + shadowYOffset);
            }


            /* Text */
            g.DrawString(text, font, textBrush, x, y);
        }

        #endregion

        #region Various helping- methods

        /* Setup the colors for the teamcolors */
        public static void TeamColor(List<PredefinedTypes.PlayerStruct> pPlayers, Int32 iIndex, Boolean isTeamcolorEnabled, ref Color clPlayercolor)
        {
            if (!isTeamcolorEnabled)
                return;


            if (pPlayers[0].Localplayer < pPlayers.Count)
            {
                if (pPlayers[iIndex].IsLocalplayer)
                    clPlayercolor = Color.Green;

                else if (pPlayers[iIndex].Team ==
                         pPlayers[pPlayers[0].Localplayer].Team &&
                         !pPlayers[iIndex].IsLocalplayer)
                    clPlayercolor = Color.Yellow;

                else if (pPlayers[pPlayers[0].Localplayer].Team !=
                         pPlayers[iIndex].Team)
                    clPlayercolor = Color.Red;

                else
                    clPlayercolor = Color.White;
            }

        }

        public static void ChangeWindowStyle(IntPtr handle, PredefinedTypes.CustomWindowStyles wndStyle)
        {
            if (wndStyle.Equals(PredefinedTypes.CustomWindowStyles.Clickable))
            {
                var initial = GetWindowLong(handle, (Int32)Gwl.ExStyle);
                SetWindowLong(handle, (Int32)Gwl.ExStyle,
                                            (IntPtr)(initial & ~(Int32)Ws.ExTransparent));
            }

            else if (wndStyle.Equals(PredefinedTypes.CustomWindowStyles.NotClickable))
            {
                var initial = GetWindowLong(handle, (Int32)Gwl.ExStyle);
                SetWindowLong(handle, (Int32)Gwl.ExStyle,
                                            (IntPtr)(initial | (Int32)Ws.ExTransparent));
            }
        }

        public static Boolean HotkeysPressed(params Int32[] keys)
        {
            Boolean blResult = true;

            for (var i = 0; i < keys.Length; i++)
            {
                blResult = blResult && GetAsyncKeyState(keys[i]) <= -32767;
            }

            return blResult;
        }

        #endregion

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Renderer));
            this.SuspendLayout();
            // 
            // Renderer
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Renderer";
            this.ResumeLayout(false);

        }

    }

    /* Required shit - Interface and such.. */
    public class AnotherSc2HackPlugin : MarshalByRefObject, IPlugins
    {

        private Renderer _rndMainWindow = null;

        public string GetPluginDescription()
        {
            return "Shows the Supply of the opponents";
        }

        public string GetPluginName()
        {
            return "Plain Supply";
        }

        public bool GetRequiresGameinfo()
        {
            return true;
        }

        public bool GetRequiresGroups()
        {
            return false;
        }

        public bool GetRequiresMap()
        {
            return false;
        }

        public bool GetRequiresPlayer()
        {
            return true;
        }

        public bool GetRequiresSelection()
        {
            return false;
        }

        public bool GetRequiresUnit()
        {
            return false;
        }

        public void SetGameinfo(PredefinedTypes.Gameinformation gameinfo)
        {
            if (gameinfo != null)
            _rndMainWindow.GInfo = gameinfo;
        }

        public void SetGroups(List<PredefinedTypes.Groups> groups)
        {
            /* Derp */
        }

        public void SetMap(PredefinedTypes.Map map)
        {
            /* Derp */
        }

        public void SetPlayers(PredefinedTypes.PList players)
        {
            if (players != null)
                _rndMainWindow.PList = players;
        }

        public void SetSelection(PredefinedTypes.LSelection selection)
        {
            /* Derp */
        }

        public void SetUnits(List<PredefinedTypes.Unit> units)
        {
            /* Derp */
        }

        public void StartPlugin()
        {
            if (_rndMainWindow == null)
                _rndMainWindow = new Renderer();

            if (!_rndMainWindow.Created)
            {
                if (_rndMainWindow.IsDisposed)
                    _rndMainWindow = new Renderer();

                _rndMainWindow.Show();
            }

            
        }

        public void StopPlugin()
        {
            if (_rndMainWindow != null &&
                _rndMainWindow.Created)
                _rndMainWindow.Close();

        }

        public string GetFileLocation()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location;
        }

        public Version GetPluginVersion()
        {
            return new Version(FileVersionInfo.GetVersionInfo(GetFileLocation()).FileVersion);
        }


        public System.Windows.Controls.UserControl GetPanelSettingsData()
        {
            var usr = new Settings();

            return usr;
        }

        public string GetPluginEntryName()
        {
            return "Plugin Supply";
        }

        public void SetStarcraftProcess(Process sc2Process)
        {
            //
        }

        public byte[] GetPluginIcon()
        {
            var image = new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 24, 0, 0, 0, 24, 8, 6, 0, 0, 0, 224, 119, 61, 248, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206, 28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 9, 112, 72, 89, 115, 0, 0, 14, 193, 0, 0, 14, 193, 1, 184, 145, 107, 237, 0, 0, 0, 6, 98, 75, 71, 68, 0, 255, 0, 255, 0, 255, 160, 189, 167, 147, 0, 0, 0, 7, 116, 73, 77, 69, 7, 223, 1, 27, 18, 9, 19, 223, 26, 112, 253, 0, 0, 6, 238, 73, 68, 65, 84, 72, 75, 165, 150, 121, 76, 155, 231, 29, 199, 223, 21, 80, 9, 9, 142, 193, 7, 190, 79, 108, 108, 48, 198, 216, 230, 176, 1, 3, 54, 193, 220, 181, 185, 237, 128, 129, 146, 4, 48, 135, 13, 137, 33, 156, 33, 28, 73, 160, 28, 165, 57, 32, 132, 22, 136, 104, 82, 74, 214, 117, 234, 210, 166, 105, 146, 102, 25, 213, 242, 71, 182, 253, 19, 105, 170, 42, 77, 155, 180, 171, 234, 63, 221, 161, 78, 81, 182, 124, 247, 24, 172, 105, 149, 86, 105, 211, 190, 210, 163, 223, 79, 239, 251, 62, 159, 231, 121, 190, 207, 245, 82, 255, 173, 76, 230, 236, 146, 35, 246, 87, 58, 152, 76, 54, 35, 244, 136, 50, 26, 181, 161, 236, 255, 84, 81, 158, 205, 231, 114, 150, 98, 125, 190, 12, 181, 85, 85, 79, 104, 49, 7, 37, 161, 87, 148, 82, 169, 14, 101, 251, 162, 211, 57, 161, 236, 127, 208, 128, 183, 126, 247, 253, 107, 173, 248, 226, 158, 3, 189, 109, 101, 208, 233, 245, 187, 89, 89, 217, 201, 2, 129, 144, 22, 250, 36, 168, 136, 80, 252, 110, 157, 107, 147, 133, 50, 138, 90, 29, 241, 178, 230, 198, 167, 236, 118, 103, 87, 193, 163, 7, 239, 125, 222, 228, 246, 32, 199, 86, 13, 189, 169, 22, 197, 101, 46, 100, 231, 28, 249, 92, 171, 77, 93, 49, 100, 152, 52, 41, 58, 67, 121, 90, 90, 150, 207, 104, 52, 39, 7, 235, 118, 245, 244, 239, 49, 190, 165, 146, 170, 186, 253, 168, 19, 209, 54, 166, 37, 45, 45, 165, 21, 215, 47, 159, 191, 128, 243, 139, 215, 113, 255, 225, 99, 204, 94, 88, 132, 235, 120, 15, 138, 28, 205, 104, 105, 59, 131, 90, 215, 171, 176, 230, 23, 67, 111, 76, 255, 67, 71, 119, 0, 221, 254, 0, 108, 5, 37, 143, 245, 134, 140, 204, 32, 167, 206, 221, 28, 12, 251, 58, 183, 240, 102, 40, 107, 139, 252, 116, 89, 190, 244, 214, 152, 28, 167, 106, 210, 176, 189, 208, 134, 237, 173, 29, 172, 95, 219, 132, 175, 163, 15, 175, 84, 119, 163, 211, 63, 137, 177, 169, 121, 12, 157, 153, 64, 255, 224, 24, 236, 246, 114, 156, 236, 63, 131, 181, 183, 119, 80, 83, 239, 129, 205, 102, 127, 154, 103, 45, 44, 12, 210, 150, 46, 109, 80, 84, 123, 231, 96, 48, 167, 158, 60, 249, 83, 120, 147, 255, 204, 248, 180, 47, 23, 87, 134, 50, 241, 232, 170, 19, 159, 221, 240, 99, 227, 202, 50, 238, 223, 190, 141, 137, 209, 11, 8, 156, 158, 199, 250, 245, 109, 56, 43, 157, 232, 233, 27, 192, 7, 119, 239, 194, 221, 220, 143, 236, 220, 98, 120, 90, 59, 208, 115, 114, 240, 69, 109, 157, 27, 21, 142, 250, 223, 100, 101, 231, 239, 91, 18, 212, 17, 91, 89, 228, 213, 141, 31, 14, 12, 156, 125, 237, 155, 130, 2, 7, 46, 47, 12, 96, 125, 110, 4, 171, 115, 147, 216, 125, 240, 33, 126, 247, 171, 95, 98, 228, 244, 20, 188, 157, 195, 248, 228, 254, 143, 113, 235, 198, 91, 88, 89, 93, 195, 196, 244, 12, 234, 70, 63, 66, 182, 197, 9, 62, 143, 135, 192, 208, 4, 142, 122, 26, 81, 89, 237, 129, 68, 34, 125, 24, 194, 83, 148, 187, 177, 71, 121, 106, 116, 233, 215, 189, 35, 139, 240, 5, 198, 240, 131, 219, 15, 240, 250, 252, 21, 248, 187, 79, 225, 225, 189, 79, 240, 222, 187, 183, 208, 221, 53, 138, 106, 119, 0, 238, 134, 46, 244, 158, 94, 65, 75, 96, 5, 13, 195, 91, 40, 31, 253, 5, 196, 220, 4, 68, 69, 29, 64, 203, 137, 14, 180, 117, 247, 192, 98, 177, 129, 193, 100, 238, 132, 240, 20, 85, 81, 221, 97, 116, 30, 61, 245, 15, 119, 231, 12, 22, 174, 126, 31, 227, 51, 171, 88, 92, 121, 23, 131, 99, 139, 56, 217, 55, 142, 64, 224, 28, 154, 60, 61, 48, 164, 219, 145, 81, 212, 10, 207, 230, 87, 112, 173, 125, 13, 203, 177, 155, 16, 105, 221, 224, 74, 114, 192, 100, 114, 145, 110, 206, 69, 118, 190, 29, 9, 42, 205, 51, 130, 85, 238, 211, 137, 10, 139, 221, 73, 150, 66, 247, 87, 37, 245, 1, 12, 140, 207, 98, 230, 210, 53, 248, 189, 165, 216, 125, 244, 35, 4, 134, 23, 81, 85, 239, 133, 189, 180, 14, 185, 53, 103, 225, 189, 252, 5, 154, 222, 252, 51, 204, 245, 23, 33, 86, 213, 66, 144, 64, 236, 145, 91, 17, 31, 159, 2, 69, 66, 42, 248, 34, 41, 210, 53, 154, 103, 166, 196, 196, 162, 16, 158, 162, 106, 43, 143, 90, 43, 107, 79, 252, 77, 159, 231, 194, 244, 210, 60, 204, 233, 6, 124, 188, 221, 132, 157, 155, 147, 184, 243, 147, 159, 227, 238, 238, 207, 112, 231, 209, 19, 184, 166, 159, 162, 138, 88, 146, 83, 253, 6, 146, 210, 27, 33, 77, 172, 2, 95, 150, 3, 129, 52, 13, 2, 145, 2, 50, 185, 26, 60, 190, 8, 53, 89, 25, 96, 114, 197, 95, 51, 227, 248, 237, 148, 57, 211, 154, 233, 235, 56, 243, 77, 77, 93, 27, 76, 54, 23, 46, 46, 5, 80, 90, 82, 138, 158, 19, 21, 88, 95, 112, 99, 168, 223, 135, 145, 233, 55, 112, 113, 227, 125, 76, 47, 191, 3, 139, 235, 10, 84, 134, 102, 40, 212, 118, 136, 226, 173, 72, 142, 151, 130, 35, 80, 131, 201, 230, 129, 195, 225, 65, 192, 39, 69, 162, 0, 79, 32, 33, 207, 226, 238, 80, 89, 230, 130, 173, 6, 87, 31, 188, 222, 113, 52, 188, 58, 136, 123, 55, 90, 144, 111, 78, 195, 135, 203, 69, 248, 236, 109, 39, 142, 59, 146, 33, 18, 39, 96, 116, 102, 13, 237, 254, 62, 88, 236, 85, 164, 231, 149, 80, 42, 51, 160, 75, 76, 133, 73, 201, 128, 82, 196, 6, 139, 205, 135, 128, 199, 133, 144, 23, 7, 177, 56, 30, 124, 190, 248, 25, 155, 197, 26, 165, 196, 98, 101, 147, 70, 151, 251, 194, 106, 117, 194, 127, 162, 9, 70, 157, 30, 57, 166, 84, 20, 155, 36, 120, 250, 65, 11, 198, 142, 25, 224, 110, 233, 132, 167, 163, 31, 246, 170, 70, 24, 205, 249, 144, 169, 45, 80, 171, 82, 97, 212, 234, 8, 60, 6, 73, 74, 38, 248, 113, 28, 72, 5, 113, 72, 148, 114, 192, 227, 242, 255, 206, 136, 97, 108, 134, 102, 128, 162, 184, 18, 237, 100, 145, 53, 247, 249, 206, 249, 44, 212, 148, 164, 66, 167, 209, 160, 194, 162, 70, 143, 75, 143, 199, 91, 69, 152, 153, 29, 65, 174, 163, 157, 156, 69, 197, 100, 83, 89, 161, 203, 200, 132, 66, 161, 134, 76, 166, 130, 38, 137, 14, 85, 62, 11, 236, 24, 22, 18, 36, 92, 112, 185, 92, 200, 164, 178, 191, 18, 236, 203, 251, 116, 162, 188, 194, 202, 248, 124, 107, 253, 111, 95, 155, 236, 195, 230, 164, 13, 245, 182, 84, 140, 6, 142, 161, 247, 120, 9, 122, 235, 133, 24, 153, 156, 66, 153, 219, 143, 204, 108, 43, 178, 173, 197, 48, 229, 21, 128, 28, 57, 96, 115, 248, 80, 105, 99, 160, 208, 177, 160, 16, 9, 201, 242, 84, 129, 47, 148, 64, 42, 145, 190, 96, 50, 152, 185, 123, 240, 114, 71, 75, 184, 171, 193, 127, 182, 245, 88, 63, 134, 167, 150, 241, 241, 166, 23, 215, 39, 236, 228, 220, 47, 68, 134, 46, 5, 42, 14, 13, 205, 93, 195, 168, 105, 29, 64, 154, 201, 2, 54, 177, 66, 103, 204, 68, 98, 178, 134, 228, 196, 115, 54, 19, 74, 57, 15, 154, 68, 53, 36, 50, 5, 89, 166, 114, 136, 68, 18, 112, 57, 220, 253, 163, 162, 176, 200, 125, 160, 214, 229, 251, 169, 255, 228, 28, 26, 9, 228, 236, 208, 0, 110, 221, 218, 194, 246, 98, 41, 186, 143, 234, 161, 16, 115, 97, 182, 150, 35, 61, 183, 20, 98, 2, 224, 113, 121, 224, 147, 34, 23, 16, 75, 68, 164, 231, 74, 41, 18, 9, 92, 36, 18, 5, 189, 7, 95, 32, 10, 142, 108, 244, 80, 212, 129, 253, 187, 66, 34, 215, 134, 165, 232, 243, 58, 236, 101, 30, 180, 251, 102, 225, 105, 240, 99, 234, 194, 42, 214, 103, 28, 184, 58, 89, 140, 194, 156, 4, 226, 169, 2, 201, 41, 233, 200, 211, 27, 200, 242, 19, 67, 74, 96, 74, 49, 153, 84, 30, 27, 114, 121, 60, 89, 53, 164, 199, 4, 206, 102, 199, 253, 133, 193, 96, 121, 9, 54, 44, 200, 102, 196, 254, 235, 118, 165, 162, 18, 212, 198, 177, 226, 242, 150, 231, 253, 131, 151, 48, 54, 190, 134, 217, 185, 107, 40, 40, 56, 2, 131, 46, 25, 102, 67, 22, 212, 106, 29, 140, 26, 45, 226, 120, 193, 6, 36, 164, 183, 2, 178, 169, 132, 4, 46, 130, 80, 44, 70, 28, 87, 248, 37, 61, 38, 182, 134, 176, 94, 10, 2, 95, 142, 140, 10, 134, 111, 41, 66, 169, 74, 29, 207, 43, 112, 161, 204, 209, 138, 120, 117, 10, 226, 4, 82, 178, 67, 149, 207, 19, 148, 90, 178, 75, 19, 9, 72, 6, 1, 153, 68, 9, 105, 64, 34, 35, 94, 75, 227, 201, 123, 210, 152, 64, 248, 37, 141, 30, 91, 26, 226, 80, 84, 120, 100, 40, 249, 15, 226, 9, 149, 3, 44, 142, 232, 30, 141, 30, 237, 139, 138, 142, 150, 196, 208, 153, 153, 60, 190, 236, 143, 50, 89, 18, 241, 89, 28, 244, 249, 247, 180, 232, 104, 231, 97, 122, 140, 131, 25, 199, 93, 142, 101, 113, 111, 210, 99, 152, 105, 161, 234, 20, 131, 253, 29, 151, 190, 33, 61, 127, 47, 50, 216, 130, 151, 162, 233, 172, 112, 218, 225, 67, 123, 67, 13, 234, 32, 45, 54, 57, 150, 193, 121, 135, 252, 178, 140, 68, 30, 164, 237, 253, 70, 132, 71, 68, 124, 47, 150, 201, 14, 139, 58, 116, 56, 34, 44, 44, 124, 239, 219, 232, 195, 244, 96, 248, 55, 81, 212, 63, 1, 202, 177, 17, 213, 200, 85, 33, 119, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 };
            return image;
        }

        
    }
}
