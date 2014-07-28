using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public class AbstractUserControl : UserControl
    {
        public void ChangeLanguageFile(string languagefile)
        {
            foreach (Control control in Controls)
            {
                if (control is LanguageLabel)
                {
                    var lbl = (LanguageLabel)control;
                    lbl.LanguageFile = languagefile;
                }

                else if (control is LanguageCheckbox)
                {
                    var chBx = (LanguageCheckbox)control;
                    chBx.LanguageFile = languagefile;
                }

                else if (control is LanguageButton)
                {
                    var btn = (LanguageButton)control;
                    btn.LanguageFile = languagefile;
                }

                else if (control is LanguageGroupbox)
                {
                    var gb = (LanguageGroupbox)control;
                    gb.LanguageFile = languagefile;

                    ChangeLanguageFile(languagefile, gb.Controls);
                }
            }
        }

        public void ChangeLanguageFile(string languagefile, ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is LanguageLabel)
                {
                    var lbl = (LanguageLabel)control;
                    lbl.LanguageFile = languagefile;
                }

                else if (control is LanguageCheckbox)
                {
                    var chBx = (LanguageCheckbox)control;
                    chBx.LanguageFile = languagefile;
                }

                else if (control is LanguageButton)
                {
                    var btn = (LanguageButton)control;
                    btn.LanguageFile = languagefile;
                }

                else if (control is LanguageGroupbox)
                {
                    var gb = (LanguageGroupbox)control;
                    gb.LanguageFile = languagefile;

                    ChangeLanguageFile(languagefile, gb.Controls);
                }
            }
        }
    }
}
