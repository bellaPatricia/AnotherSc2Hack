using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public class LanguageButton : Button
    {
        public String LanguageFile { get; set; }

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
                var strControlandName = strLine.Split(Constants.ChrLanguageSplitSign);
                if (strControlandName.Length != 2)
                    continue;

                var strControlNames = strControlandName[0].Split(Constants.ChrLanguageControlSplitSign);

                foreach (var languageButton in Instances)
                {
                    if (HelpFunctions.CheckParents(languageButton, 0, ref strControlNames))
                    {
                        languageButton.Text = strControlandName[1].Trim();
                        break;
                    }
                }
            }

            return true;
        }
    }
}
