using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    public class LanguageButton : Button
    {
        public string LanguageFile { get; set; }

        private static readonly List<LanguageButton> Instances = new List<LanguageButton>();

        public LanguageButton()
        {
            Instances.Add(this);
        }

        ~LanguageButton()
        {
            var index = Instances.FindIndex(x => x.GetHashCode().Equals(GetHashCode()));
            Instances.RemoveAt(index);
        }


        public static void OutputPath()
        {
            foreach (var languageButton in Instances)
            {
                Console.WriteLine(HelpFunctions.GetParent(languageButton) + Constants.ChrLanguageSplitSign + " " + languageButton.Text);
            }
        }

        public static bool ChangeLanguage(string languageFile)
        {
            if (!File.Exists(languageFile))
                return false;
            

            var strLines = File.ReadAllLines(languageFile, Encoding.Default);

            foreach (var strLine in strLines)
            {
                if (strLine.Length <= 0 ||
                    strLine.StartsWith(";"))
                    continue;

                var strControlAndName = new string[2];
                strControlAndName[0] = strLine.Substring(0, strLine.IndexOf(Constants.ChrLanguageSplitSign));
                strControlAndName[1] = strLine.Substring(strLine.IndexOf(Constants.ChrLanguageSplitSign) + 1);


                var strControlNames = strControlAndName[0].Split(Constants.ChrLanguageControlSplitSign);

                foreach (var languageButton in Instances)
                {
                    if (HelpFunctions.CheckParents(languageButton, 0, ref strControlNames))
                    {
                        languageButton.Text = strControlAndName[1].Trim();
                    }
                }
            }

            return true;
        }
    }
}
