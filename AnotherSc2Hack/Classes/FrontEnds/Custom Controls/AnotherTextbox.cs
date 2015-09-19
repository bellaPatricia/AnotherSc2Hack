using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    class AnotherTextbox : TextBox
    {
        private string _watermark = string.Empty;

        public string Watermark
        {
            get
            {
                return _watermark;
            }
            set
            {
                _watermark = value;
                
                if (Text.Length <= 0)
                    SetupWatermarkText();
            }
        }

        private readonly Color _clOldForeColor;


        public AnotherTextbox()
        {
            Enter += AnotherTextbox_Enter;
            Leave += AnotherTextbox_Leave;
            TextChanged += AnotherTextbox_TextChanged;

            _clOldForeColor = ForeColor;
        }

        void AnotherTextbox_TextChanged(object sender, EventArgs e)
        {
            if (Text.Equals(string.Empty) &&
                !Focused)
                SetupWatermarkText();
        }

        public override sealed Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        void AnotherTextbox_Leave(object sender, EventArgs e)
        {
            if (Text.Length <= 0)
                SetupWatermarkText();
        }

        void AnotherTextbox_Enter(object sender, EventArgs e)
        {
            ForeColor = _clOldForeColor;

            if (Text.Equals(Watermark))
                Text = string.Empty;
        }

        private void SetupWatermarkText()
        {
            Text = Watermark;
            ForeColor = Color.Gray;
        }
    }
}
