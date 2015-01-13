using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    class AnotherTextbox : TextBox
    {
        private string _watermark = String.Empty;

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

        private Color _clOldForeColor;


        public AnotherTextbox()
        {
            Enter += AnotherTextbox_Enter;
            Leave += AnotherTextbox_Leave;
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
            if (ForeColor == _clOldForeColor)
                return;

            Text = "";
            ForeColor = _clOldForeColor;
        }

        private void SetupWatermarkText()
        {
            _clOldForeColor = ForeColor;
            Text = Watermark;
            ForeColor = Color.Gray;
        }
    }
}
