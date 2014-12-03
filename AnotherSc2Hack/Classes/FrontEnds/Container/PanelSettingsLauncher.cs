using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    public partial class PanelSettingsLauncher : UserControl
    {
        public PanelSettingsLauncher()
        {
            InitializeComponent();
        }

        public void ChangeLanguage(String languageFile)
        {
            foreach (var control in Controls)
            {
                if (control.GetType() == typeof (LanguageLabel))
                {
                    var tmp = ((LanguageLabel) control);
                    tmp.LanguageFile = languageFile;
                }
            }
        }
    }
}
