using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AnotherSc2Hack.Classes.BackEnds
{
    
    public class LanguageString
    {
        private static readonly List<LanguageString> Instances = new List<LanguageString>();
        private static string _strLastUsedLanguageFile = String.Empty;

        public string Text { get; set; }
        public string Name { get; set; }

        public LanguageString(string text, string name)
        {
            Text = text;
            Name = name;

            Instances.Add(this);

            ChangeLanguage(_strLastUsedLanguageFile);
        }

        ~LanguageString()
        {
            var index = Instances.FindIndex(x => x.GetHashCode().Equals(GetHashCode()));
            Instances.RemoveAt(index);
        }


        public static bool ChangeLanguage(string languageFile)
        {
            if (!File.Exists(languageFile))
                return false;

            _strLastUsedLanguageFile = languageFile;

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

                foreach (var languageString in Instances)
                {
                    if (languageString.Name == strControlNames[0])
                        languageString.Text = strControlAndName[1].Trim();
                    
                }
            }

            return true;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
