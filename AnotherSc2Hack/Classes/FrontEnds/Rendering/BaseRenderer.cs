using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using Predefined;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    /// <summary>
    /// Baseclass which handles everything around the drawing of the content.
    /// Does the dirty work so you don't have to care about the basic "fuck up"
    /// </summary>
    public abstract partial class BaseRenderer : Form
    {
        public long IterationsPerSeconds { get; set; }
        private long _lTimesRefreshed;
        private DateTime _dtSecond = DateTime.Now;
        protected readonly MainHandler.MainHandler HMainHandler;                                              //Mainhandler - handles access to the Engine
        private Point _ptMousePosition = new Point(0, 0);                                                //Position for the Moving of the Panel
        protected Preferences PSettings;
        protected Boolean BChangingPosition;
        protected Boolean BMouseDown;
        private Boolean _bDraw = true;
        public Boolean BSurpressForeground;
        protected Stopwatch SwMainWatch = new Stopwatch();
        protected DateTime DtBegin = DateTime.Now;               //Check for the TopMost refreshing
        private const Int32 SizeOfRectangle = 10;                      //Size for the corner- rectangles (when changing position)

        /* Adjust Panelsize */
        protected Boolean BSetSize;
        protected Boolean BToggleSize;

        /* Ajust Panelposition */
        protected Boolean BSetPosition;
        protected Boolean BToggle;

        //This is for the text- input
        protected String StrBackup = String.Empty;
        protected String StrBackupSize = String.Empty;

        public Boolean IsDestroyed { get; set; }
        public PredefinedData.CustomWindowStyles SetWindowStyle { get; set; }

        /// <summary>
        /// Initializes the code.
        /// It's just there to reduce the amount of codelines. 
        /// </summary>
        private void InitCode()
        {
            SetStyle(ControlStyles.DoubleBuffer |
            ControlStyles.UserPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint, true);

            InitializeComponent();

            LoadPreferencesIntoControls();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRenderer"/> class.
        /// </summary>
        /// <param name="hnd">The handle to the MainHandle (to get data like GameInfo or Preferences and direct Form- control).</param>
        protected BaseRenderer(MainHandler.MainHandler hnd)
        {
            HMainHandler = hnd;

            PSettings = HMainHandler.PSettings;


            InitCode();
        }

        /// <summary>
       /// The override OnPaint- method to draw the content and more imporantly: the basic stuff around the panels.
       /// Since it's always the same, it won't get overridden!
       /// </summary>
       /// <param name="e">The letter e - huehue</param>
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

                if (HMainHandler.GInformation.Gameinfo.IsIngame)
                {
                    if (PSettings.GlobalDrawOnlyInForeground && !BSurpressForeground)
                    {
                        _bDraw = InteropCalls.GetForegroundWindow().Equals(HMainHandler.PSc2Process.MainWindowHandle);
                    }

                    else
                    {
                        _bDraw = true;

                        if (InteropCalls.GetForegroundWindow().Equals(HMainHandler.PSc2Process.MainWindowHandle))
                        {
                            InteropCalls.SetActiveWindow(Handle);
                        }
                    }

                    if (_bDraw)
                    {
                        Draw(buffer);

                        #region Draw a Rectangle around the Panels (When changing position)

                        /* Draw a final bound around the panel */
                        if (BChangingPosition || BSetPosition || BSetSize)
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
        /// Using this method so you don't need to override the OnPaint- method (cuz that would cause more fuck-up)
        /// </summary>
        /// <param name="g">Prebuffered graphics.. D:</param>
        public abstract void Draw(BufferedGraphics g);

        /// <summary>
        /// Load Form- specific data in the initialization of the Form.
        /// This gets called within the Form_Load!
        /// </summary>
        protected abstract void LoadSpedificData();

        /// <summary>
        /// Changes the color of a button on a specific Form.
        /// </summary>
        /// <param name="cl"></param>
        protected abstract void ChangeForecolorOfButton(Color cl);

        /// <summary>
        /// Defines what happens after the resizing.
        /// Usually some kind of datatransfer with the preferences.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void BaseRenderer_ResizeEnd(object sender, EventArgs e);

        /// <summary>
        /// Adjust the panelsize and change the settings for Form X.
        /// </summary>
        protected abstract void AdjustPanelSize();

        /// <summary>
        /// Adjust the panelposition and change the settings for Form X.
        /// </summary>
        protected abstract void AdjustPanelPosition();

        /// <summary>
        /// Load the preferences for Form X into the Controls (location, size)
        /// </summary>
        protected abstract void LoadPreferencesIntoControls();

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

        /// <summary>
        /// Transfers Mousedata (position) into the specific Form
        /// </summary>
        protected abstract void MouseUpTransferData();

        /// <summary>
        /// Transfers Mousedata (size) into the specific Form
        /// </summary>
        /// <param name="e"></param>
        protected abstract void MouseWheelTransferData(MouseEventArgs e);

        /// <summary>
        /// Changes the position of the Form based on mouse- position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var mousePos = MousePosition;
                mousePos.Offset(-_ptMousePosition.X, -_ptMousePosition.Y);
                Location = mousePos;
            }
        }
        
        /// <summary>
        /// Sets variables to finalize the re- position/ -sizing.
        /// Also calls MouseUpTransferData()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_MouseUp(object sender, MouseEventArgs e)
        {
            InteropCalls.SetForegroundWindow(HMainHandler.PSc2Process.MainWindowHandle);

            MouseUpTransferData();

            BChangingPosition = false;
            BMouseDown = false;
        }

        /// <summary>
        /// Changes the state of BMouseDown (to allow reposition)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_MouseDown(object sender, MouseEventArgs e)
        {
            _ptMousePosition = new Point(e.X, e.Y);

            BMouseDown = true;
        }

        /// <summary>
        /// Handles the resizing using the mouse- wheel.
        /// Makes a precheck and finally calls MouseWheelTransferData(e).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Width >= Screen.PrimaryScreen.Bounds.Width &&
                e.Delta.Equals(120))
                return;

            MouseWheelTransferData(e);
        }
        
        /// <summary>
        /// Changes the statte of IsDestroyed to true.
        /// Also calls ChangeForecolorOfButton(Color.Red) to color the button of a specific Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsDestroyed = true;

            ChangeForecolorOfButton(Color.Red);
        }
    
        /// <summary>
        /// The Form_Load is there to load some basic stuff like Color and Timer- fixures.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseRenderer_Load(object sender, EventArgs e)
        {
            LoadPreferencesIntoControls();

            LoadSpedificData();

            TopMost = true;


            BackColor = Color.FromArgb(255, 50, 50, 50);
            TransparencyKey = Color.FromArgb(255, 50, 50, 50);

            ChangeForecolorOfButton(Color.Green);


            tmrRefreshGraphic.Enabled = true;
        }
    
        /// <summary>
        /// Refreshes the Foreground (in case it failed somehow)
        /// No idea why I use this, lol.
        /// </summary>
        /// <param name="hWnd">Handle for this Form</param>
        private void RefreshForeground(IntPtr hWnd)
        {
            var z = 0;
            for (var h = hWnd; h != IntPtr.Zero; h = InteropCalls.GetWindow(h, InteropCalls.GetWindowCmd.GwHwndprev)) 
                z++;


            if (z > 5)
            {
                // ???
                TopMost = false;
                TopMost = true;
            }
        }

        /// <summary>
        /// Gets the Keyboard- input from SC2's chatbox.
        /// </summary>
        private void GetKeyboardInput()
        {
            var sInput = HMainHandler.GInformation.Gameinfo.ChatInput;

            if (sInput != StrBackup)
                BToggle = true;

            if (sInput != StrBackupSize)
                BToggleSize = true;


            StrBackup = sInput;
            StrBackupSize = sInput;
        }

        
        /// <summary>
        /// Change the window- style (to make it click- and non-clickable)
        /// </summary>
        private void ChangeWindowStyle()
        {
            if (SetWindowStyle.Equals(PredefinedData.CustomWindowStyles.Clickable))
            {
                BChangingPosition = true;
                BSurpressForeground = true;
                HelpFunctions.SetWindowStyle(Handle, PredefinedData.CustomWindowStyles.Clickable);
            }

            else if (SetWindowStyle.Equals(PredefinedData.CustomWindowStyles.NotClickable))
            {
                BSurpressForeground = false;

                if (!BMouseDown)
                    BChangingPosition = false;
                HelpFunctions.SetWindowStyle(Handle, PredefinedData.CustomWindowStyles.NotClickable);
            }
        }

        /// <summary>
        /// The basic Timermethod to re- draw and gather new data like the Chatbox- strings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrRefreshGraphic_Tick(object sender, EventArgs e)
        {
            //_swMainWatch.Reset();
            //_swMainWatch.Start();

            Invalidate();

            //_swMainWatch.Stop();
            //Debug.WriteLine("Time to Invalidate:" + 1000000 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency + " µs");


            if (HelpFunctions.HotkeysPressed(PSettings.GlobalChangeSizeAndPosition))
                SetWindowStyle = PredefinedData.CustomWindowStyles.Clickable;

            else if (FormBorderStyle != FormBorderStyle.None)
                SetWindowStyle = PredefinedData.CustomWindowStyles.Clickable;


            else
                SetWindowStyle = PredefinedData.CustomWindowStyles.NotClickable;

            ChangeWindowStyle();


            GetKeyboardInput();
            AdjustPanelPosition();
            AdjustPanelSize();

            /* Reset settings */
            PSettings = HMainHandler.PSettings;

            /* Refresh Top- Most */
            if (
                HMainHandler.PSc2Process != null && HMainHandler.PSc2Process.ProcessName.Length > 0 &&
                InteropCalls.GetForegroundWindow().Equals(HMainHandler.PSc2Process.MainWindowHandle))
            {
                if ((DateTime.Now - DtBegin).Seconds > 1)
                {
                    RefreshForeground(Handle);
                    DtBegin = DateTime.Now;
                }
            }

            //_swMainWatch.Stop();
            //Debug.WriteLine("Time to Iterate the timer:" + 1000000 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency + " µs");
        }

    }
}
