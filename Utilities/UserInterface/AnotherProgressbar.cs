using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Utilities.UserInterface
{
    public partial class AnotherProgressbar : UserControl
    {
        public AnotherProgressbar()
        {
            InitializeComponent();

            InitializeBrush();

            pnlDrawArea.Click += PnlDrawArea_Click;
            
            pnlDrawArea.Invalidate();
        }

        private void PnlDrawArea_Click(object sender, EventArgs e)
        {
            OnFuckYou(this, e);
        }

        public event EventHandler FuckYou;

        private void OnFuckYou(object sender, EventArgs e)
        {
            FuckYou?.Invoke(sender, e);
            Console.WriteLine("Clicked");
        }

        private HatchBrush _bProgressbar;
        private Color _clColor1 = Color.GreenYellow;

        public Color Color1
        {
            get { return _clColor1;}
            set
            {
                _clColor1 = value;
                InitializeBrush();
            }
        }

        private Color _clColor2 = Color.WhiteSmoke;

        public Color Color2
        {
            get { return _clColor2; }
            set
            {
                _clColor2 = value;
                InitializeBrush();
            }
        }

        public int TotalSteps { get; set; } = 100;
        private int _currentStep = 50;

        public int CurrentStep
        {
            get { return _currentStep; }
            set
            {
                _currentStep = value;
                pnlDrawArea.Invalidate();
            }
        }

        private void InitializeBrush()
        {
            _bProgressbar = new HatchBrush(HatchStyle.ForwardDiagonal, Color1, Color2);
        }

        private void pnlDrawArea_Paint(object sender, PaintEventArgs e)
        {
            var drawArea = sender as Panel;

            if (drawArea == null)
                return;

            if (_bProgressbar == null)
                return;

            Console.WriteLine($"Current Step: {CurrentStep}, Total Steps: {TotalSteps}");

            var percentageDone = (float)CurrentStep / TotalSteps;
            Console.WriteLine($"Percentage Done: {percentageDone}");


            var newWidth = drawArea.Width * percentageDone;

            Console.WriteLine($"New Width: {newWidth}");


            e.Graphics.FillRectangle(_bProgressbar,
                new Rectangle(drawArea.Location, new Size((int)newWidth, drawArea.ClientSize.Height)));
        }

        
    }
}
