/// PluginSupply
/// A plugin to show the supply of all players
/// Version 1.0.0.0 as of 2014-June-05
/// by bellaPatricia
/// 
/// Feel free to edit, change and copy this code!


using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PredefinedTypes = Predefined.PredefinedData;
using PluginInterface;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace PluginSupply
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

    }

    /* Required shit - Interface and such.. */
    public class AnotherSc2HackPlugin : IPlugins
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
    }
}
