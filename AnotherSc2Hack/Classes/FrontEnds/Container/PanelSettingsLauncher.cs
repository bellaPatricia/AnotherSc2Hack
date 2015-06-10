using System;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;

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
