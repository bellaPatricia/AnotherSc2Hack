using System;
using System.Drawing;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    public partial class AnotherMessageBox : Form
    {

        #region Private Variables

        private readonly LanguageString _lstrAnotherMessageBoxOk = new LanguageString("lstrAnotherMessageBoxOk", "Ok");
        private readonly LanguageString _lstrAnotherMessageBoxCancel = new LanguageString("lstrAnotherMessageBoxCancel", "Cancel");
        private readonly LanguageString _lstrAnotherMessageBoxAbort = new LanguageString("lstrAnotherMessageBoxAbort", "Abort");
        private readonly LanguageString _lstrAnotherMessageBoxRetry = new LanguageString("lstrAnotherMessageBoxRetry", "Retry");
        private readonly LanguageString _lstrAnotherMessageBoxIgnore = new LanguageString("lstrAnotherMessageBoxIgnore", "Ignore");
        private readonly LanguageString _lstrAnotherMessageBoxYes = new LanguageString("lstrAnotherMessageBoxYes", "Yes");
        private readonly LanguageString _lstrAnotherMessageBoxNo = new LanguageString("lstrAnotherMessageBoxNo", "No");

        #endregion

        public AnotherMessageBox()
        {
            InitializeComponent();

            btnNo.Text = _lstrAnotherMessageBoxNo.Text;
            btnOk.Text = _lstrAnotherMessageBoxOk.Text;
            btnRetry.Text = _lstrAnotherMessageBoxRetry.Text;
            btnYes.Text = _lstrAnotherMessageBoxYes.Text;
            btnIgnore.Text = _lstrAnotherMessageBoxIgnore.Text;
            btnCancel.Text = _lstrAnotherMessageBoxCancel.Text;
            btnAbort.Text = _lstrAnotherMessageBoxAbort.Text;
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
            string caption = "",
            MessageBoxButtons buttons = MessageBoxButtons.OK, Font font = null)
        {
            const int iMargin = 25;
            const int iButtonSpacer = 15;


            if (font != null)
            {
                Font = font;
            }

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

                btnNo.Location = new Point(ClientSize.Width - btnNo.Width - iMargin, btnNo.Location.Y);
                btnYes.Location = new Point(ClientSize.Width - btnNo.Width - iMargin - btnYes.Width - iButtonSpacer, btnYes.Location.Y);
            }

            else if (buttons == MessageBoxButtons.OK)
            {
                btnOk.Visible = true;

                btnOk.Location = new Point(ClientSize.Width - btnOk.Width - iMargin, btnOk.Location.Y);
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
            textSize.Height += iMargin;


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
