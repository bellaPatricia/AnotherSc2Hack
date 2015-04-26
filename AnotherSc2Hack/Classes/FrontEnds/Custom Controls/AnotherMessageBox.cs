using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    public partial class AnotherMessageBox : Form
    {
        public AnotherMessageBox()
        {
            InitializeComponent();
        }

        private DialogResult _dialogResult = DialogResult.Abort;

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

        public DialogResult Show(string text,
            string caption,
            MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            #region Make buttons (in)visible

            var controls = pnlBottomContainer.Controls;

            foreach (var control in controls)
            {
                var cntrl = control as Button;

                if (cntrl == null)
                    continue;

                cntrl.Visible = false;
            }

            if (buttons == MessageBoxButtons.YesNo)
            {
                btnYes.Visible = true;
                btnNo.Visible = true;

                btnNo.Location = new Point(507, btnNo.Location.Y);
                btnYes.Location = new Point(393, btnYes.Location.Y);
            }

            else if (buttons == MessageBoxButtons.OK)
            {
                btnOk.Visible = true;

                btnOk.Location = new Point(507, btnOk.Location.Y);
            }

            #endregion

            #region actual text


            lblMainText.Text = text;
            Text = caption;

            var textSize = TextRenderer.MeasureText(text, Font);
            textSize.Width += lblMainText.Padding.Horizontal;
            textSize.Width += lblMainText.Location.X * 2;

            textSize.Height += pnlBottomContainer.Height;
            textSize.Height += lblMainText.Location.Y + lblMainText.Padding.Vertical;


            ClientSize = textSize;

            #endregion

            ShowDialog();

            return _dialogResult;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _dialogResult = DialogResult.OK;
            Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            _dialogResult = DialogResult.No;
            Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            _dialogResult = DialogResult.Yes;
            Close();
        }

        //Draw a new border on the top and bottom of the panel
        private void DrawVerticalBorders(object sender, PaintEventArgs e)
        {
            var send = (Panel)sender;

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, 0, Width, 0);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, send.Height - 1, Width, send.Height - 1);
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            _dialogResult = DialogResult.Abort;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _dialogResult = DialogResult.Cancel;
        }
    }
}
