using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    public partial class AnotherMessageBox : Form
    {
        public AnotherMessageBox()
        {
            InitializeComponent();
        }

        public void Show(string text)
        {
            
        }

        public void Show(string text, string caption)
        {
            
        }

        public void Show(string text, string caption, Font font)
        {
            lblMainText.Font = font;

            lblMainText.Text = text;
            Text = caption;

            var textSize = TextRenderer.MeasureText(text, font);
            textSize.Width += lblMainText.Padding.Horizontal;
            textSize.Width += lblMainText.Location.X*2;

            textSize.Height += pnlBottomContainer.Height;
            textSize.Height += lblMainText.Location.Y + lblMainText.Padding.Vertical;


            ClientSize = textSize;

            ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
