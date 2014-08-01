// Superclass to handle the basic rendering and Window- handling
// for each subclass. Actually runs all the crap like resizing, information- gathering, drawing and even more for you
// You just have to set up all the information for the specific classes (like in which setting you'd like to write).
// And, of course, a drawing- implementation to get your drawing done.
// 
// Inherit from this class to get your stuff done easily!
// 
// 
// Written by bellaPatricia @ 2014 - August - 01

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
        #region Variabled

        public long IterationsPerSeconds { get; set; }                          //Counts the iterations within a second

        private long _lTimesRefreshed;                                          //Dunno.. :D
        private Point _ptMousePosition = new Point(0, 0);                       //Position for the Moving of the Panel
        private Boolean _bDraw = true;
        private const Int32 SizeOfRectangle = 10;                               //Size for the corner- rectangles (when changing position)

        protected readonly MainHandler.MainHandler HMainHandler;                //Mainhandler - handles access to the Engine
        protected Stopwatch SwMainWatch = new Stopwatch();                      //Stopwatch for Debugging and speed- tests
        protected DateTime DtBegin = DateTime.Now;                              //First Datetime to get the Delta between the begin and end [TopMost]
        protected DateTime DtSecond = DateTime.Now;                             //Second Datetime to get the Delta between the begin and end [TopMost]
        protected Preferences PSettings;                                        //Preferences directly..
        protected Boolean BSurpressForeground;
        protected Boolean BChangingPosition;
        protected Boolean BMouseDown;
        protected Boolean BSetSize;
        protected Boolean BToggleSize;
        protected Boolean BSetPosition;
        protected Boolean BTogglePosition;
        protected String StrBackupChatbox = String.Empty;
        protected String StrBackupSizeChatbox = String.Empty;

        #endregion

        #region Getter/ Setter

        public Boolean IsDestroyed { get; set; }
        public PredefinedData.CustomWindowStyles SetWindowStyle { get; set; }

        #endregion

        #region Constructor

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

        #endregion

        #region Private Methods

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

            LoadSpecificData();

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

            if (sInput != StrBackupChatbox)
                BTogglePosition = true;

            if (sInput != StrBackupSizeChatbox)
                BToggleSize = true;


            StrBackupChatbox = sInput;
            StrBackupSizeChatbox = sInput;
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

        #endregion

        #region Protected abstract Methods (Form specific)

        /// <summary>
        /// Draws the stuff you want to have drawn
        /// Using this method so you don't need to override the OnPaint- method (cuz that would cause more fuck-up)
        /// </summary>
        /// <param name="g">Prebuffered graphics.. D:</param>
        protected abstract void Draw(BufferedGraphics g);

        /// <summary>
        /// Load Form- specific data in the initialization of the Form.
        /// This gets called within the Form_Load!
        /// </summary>
        protected abstract void LoadSpecificData();

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
        /// Transfers Mousedata (position) into the specific Form
        /// </summary>
        protected abstract void MouseUpTransferData();

        /// <summary>
        /// Transfers Mousedata (size) into the specific Form
        /// </summary>
        /// <param name="e"></param>
        protected abstract void MouseWheelTransferData(MouseEventArgs e);

        #endregion

        #region Protected Methods

        /// <summary>
        /// Checks if gameheart.
        /// </summary>
        /// <param name="p">The player</param>
        /// <returns>Is the player is gameheartish.</returns>
        protected Boolean CheckIfGameheart(PredefinedData.PlayerStruct p)
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
        /// The override OnPaint- method to draw the content and more imporantly: the basic stuff around the panels.
        /// Since it's always the same, it won't get overridden!
        /// </summary>
        /// <param name="e">The letter e - huehue</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if ((DateTime.Now - DtSecond).Seconds >= 1)
            {
                //Debug.WriteLine("The OnPaint- loop was refreshed " + lTimesRefreshed + " times in a second!");
                IterationsPerSeconds = _lTimesRefreshed;
                _lTimesRefreshed = 0;
                DtSecond = DateTime.Now;
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

        #endregion
    }
}
