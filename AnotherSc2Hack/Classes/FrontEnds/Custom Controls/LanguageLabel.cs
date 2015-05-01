using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public class LanguageLabel : Label
    {
        public String LanguageFile { get; set; }

        private static readonly List<LanguageLabel> Instances = new List<LanguageLabel>();

        public LanguageLabel()
        {
            Instances.Add(this);
        }

        ~LanguageLabel()
        {
            var index = Instances.FindIndex(x => x.GetHashCode().Equals(GetHashCode()));
            Instances.RemoveAt(index);
        }


        public static void OutputPath()
        {
            foreach (var languageLabel in Instances)
            {
                Console.WriteLine(HelpFunctions.GetParent(languageLabel) + Constants.ChrLanguageSplitSign + " " + languageLabel.Text);
            }
        }

        public static bool ChangeLanguage(string languageFile)
        {
            if (!File.Exists(languageFile))
                return false;

            var strLines = File.ReadAllLines(languageFile, Encoding.Default);


            foreach (var strLine in strLines)
            {
                var strControlAndName = new string[2];
                strControlAndName[0] = strLine.Substring(0,strLine.IndexOf(Constants.ChrLanguageSplitSign));
                strControlAndName[1] = strLine.Substring(strLine.IndexOf(Constants.ChrLanguageSplitSign) + 1);

                var strControlNames = strControlAndName[0].Split(Constants.ChrLanguageControlSplitSign);

                foreach (var languageLabel in Instances)
                {
                    if (HelpFunctions.CheckParents(languageLabel, 0, ref strControlNames))
                    {
                        languageLabel.Text = strControlAndName[1].Trim();
                        break;
                    }
                }
                
            }

            return true;
        }
    }
 
}
