using System.Drawing;
using System.Globalization;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public partial class UiInformation : AbstractUserControl
    {
        public UiInformation()
        {
            InitializeComponent();
        }

        public void SetPosition(Point location)
        {
            txtPosX.Text = location.X.ToString(CultureInfo.InvariantCulture);
            txtPosY.Text = location.Y.ToString(CultureInfo.InvariantCulture);
        }

        public void SetSize(Size size)
        {
            txtWidth.Text = size.Width.ToString(CultureInfo.InvariantCulture);
            txtHeight.Text = size.Height.ToString(CultureInfo.InvariantCulture);
        }

        public void SetGeometry(int x, int y, int width, int height)
        {
            txtPosX.Text = x.ToString(CultureInfo.InvariantCulture);
            txtPosY.Text = x.ToString(CultureInfo.InvariantCulture);
            txtWidth.Text = width.ToString(CultureInfo.InvariantCulture);
            txtHeight.Text = height.ToString(CultureInfo.InvariantCulture);
        }

        public void SetGeometry(Point location, Size size)
        {
            txtPosX.Text = location.X.ToString(CultureInfo.InvariantCulture);
            txtPosY.Text = location.Y.ToString(CultureInfo.InvariantCulture);
            txtWidth.Text = size.Width.ToString(CultureInfo.InvariantCulture);
            txtHeight.Text = size.Height.ToString(CultureInfo.InvariantCulture);
        }
    }
}
