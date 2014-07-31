using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using Predefined;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    public abstract partial class BaseRenderer : Form
    {
        public long IterationsPerSeconds { get; set; }
        private long _lTimesRefreshed;
        private DateTime _dtSecond = DateTime.Now;
        public readonly MainHandler.MainHandler _hMainHandler;                                              //Mainhandler - handles access to the Engine
        private Point _ptMousePosition = new Point(0, 0);                                                //Position for the Moving of the Panel
        public Preferences _pSettings;
        public Boolean _bChangingPosition;
        private Boolean _bDraw = true;
        public Boolean _bSurpressForeground;
        private Stopwatch _swMainWatch = new Stopwatch();
        const Int32 SizeOfRectangle = 10;                      //Size for the corner- rectangles (when changing position)

        /* Adjust Panelsize */
        private Boolean _bSetSize;
        private Boolean _bToggleSize;

        /* Ajust Panelposition */
        private Boolean _bSetPosition;
        private Boolean _bToggle;

        private void InitCode()
        {
            SetStyle(ControlStyles.DoubleBuffer |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint, true);

            InitializeComponent();
        }

        public BaseRenderer()
        {
            InitCode();
        }

        public BaseRenderer(MainHandler.MainHandler hnd)
        {
            _hMainHandler = hnd;

            _pSettings = _hMainHandler.PSettings;


            InitCode();
        }

        /// <summary>
        /// </summary>
        /// <param name="e">Eine Instanz von <see cref="T:System.Windows.Forms.PaintEventArgs" />, die die Ereignisdaten enthält.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if ((DateTime.Now - _dtSecond).Seconds >= 1)
            {
                //Debug.WriteLine("The OnPaint- loop was refreshed " + lTimesRefreshed + " times in a second!");
                IterationsPerSeconds = _lTimesRefreshed;
                _lTimesRefreshed = 0;
                _dtSecond = DateTime.Now;
            }
            _lTimesRefreshed++;

            base.OnPaint(e);



            //_swMainWatch.Reset();
            //_swMainWatch.Start();

            var context = new BufferedGraphicsContext();
            context.MaximumBuffer = ClientSize;

            using (BufferedGraphics buffer = context.Allocate(e.Graphics, ClientRectangle))
            {
                buffer.Graphics.Clear(BackColor);
                buffer.Graphics.CompositingMode = CompositingMode.SourceOver;
                buffer.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
                buffer.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                buffer.Graphics.SmoothingMode = SmoothingMode.HighSpeed;

                if (_hMainHandler.GInformation.Gameinfo.IsIngame)
                {
                    if (_pSettings.GlobalDrawOnlyInForeground && !_bSurpressForeground)
                    {
                        _bDraw = InteropCalls.GetForegroundWindow().Equals(_hMainHandler.PSc2Process.MainWindowHandle);
                    }

                    else
                    {
                        _bDraw = true;

                        if (InteropCalls.GetForegroundWindow().Equals(_hMainHandler.PSc2Process.MainWindowHandle))
                        {
                            InteropCalls.SetActiveWindow(Handle);
                        }
                    }

                    if (_bDraw)
                    {
                        Draw(buffer);

                        #region Draw a Rectangle around the Panels (When changing position)

                        /* Draw a final bound around the panel */
                        if (_bChangingPosition || _bSetPosition || _bSetSize)
                        {


                            /* Simple border */
                            buffer.Graphics.DrawRectangle(Constants.PYellowGreen2,
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

                            /* Draw current size */
                            buffer.Graphics.DrawString(
                                Width.ToString(CultureInfo.InvariantCulture) + "x" +
                                Height.ToString(CultureInfo.InvariantCulture) + " - [X=" +
                            Location.X.ToString(CultureInfo.InvariantCulture) + "; Y=" + Location.Y.ToString(CultureInfo.InvariantCulture) + "]",
                                new Font("Arial", 8, FontStyle.Regular), Brushes.YellowGreen, 2, 2);
                        }

                        #endregion
                    }

                }



                buffer.Render();
            }

            context.Dispose();

            //_swMainWatch.Stop();
            //Debug.WriteLine("Time to execute DrawingMethods:" + 1000000 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency + " µs");
        }

        /// <summary>
        /// Draws the stuff you want to have drawn
        /// </summary>
        /// <param name="g">The g.</param>
        public abstract void Draw(BufferedGraphics g);

        /// <summary>
        /// Checks if gameheart.
        /// </summary>
        /// <param name="p">The player</param>
        /// <returns>Is the player is gameheartish.</returns>
        public Boolean CheckIfGameheart(PredefinedData.PlayerStruct p)
        {
            if (p.CurrentBuildings == 0 &&
                p.Status.Equals(PredefinedData.PlayerStatus.Playing) &&
                p.SupplyMax == 0 &&
                p.SupplyMin == 0 &&
                p.Worker == 0 &&
                p.Minerals == 0 &&
                p.Gas == 0)
                return true;

            return false;
        }

        private void BaseRenderer_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void BaseRenderer_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void BaseRenderer_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void BaseRenderer_MouseWheel(object sender, MouseEventArgs e)
        {
            
        }

        private void BaseRenderer_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void BaseRenderer_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void BaseRenderer_Load(object sender, EventArgs e)
        {

        }


    }
}
