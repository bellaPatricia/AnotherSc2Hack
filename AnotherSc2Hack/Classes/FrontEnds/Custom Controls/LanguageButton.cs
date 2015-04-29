using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public class LanguageButton : Button
    {
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
                Console.WriteLine(HelpFunctions.GetParent(languageButton) + Constants.ChrLanguageSplitSign + " ");
            }
        }

        public String LanguageFile
        {
            get { return _languageFile; }
            set
            {
                _languageFile = value;
                ChangeLanguage();
            }
        }

        private string _languageFile = String.Empty;

        public void ChangeLanguage()
        {
            ReadLanguagefile();
        }



        private void ReadLanguagefile()
        {
            var tmpFileAvailable = File.Exists(_languageFile);

            if (!tmpFileAvailable)
                return;

            using (var sr = new StreamReader(_languageFile, System.Text.Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    var strLine = sr.ReadLine();

                    if (strLine == null ||
                            strLine.Length <= 0)
                        continue;

                    if (strLine.StartsWith(";"))
                        continue;

                    /* If it is contained there.. (PARTLY) */
                    if (strLine.Contains(Name))
                    {
                        /* Now the actual compare */
                        //var tmp = strLine.Replace(" ", "");
                        var tmp = strLine;

                        var mappedStuff = tmp.Split('=');

                        if (mappedStuff.Length > 1)
                        {
                            if (mappedStuff[0].Trim().Equals(Name))
                            {
                                Text = mappedStuff[1].TrimStart();
                            }
                        }
                    }
                }
            }
        }

        public static bool ChangeLanguage(string languageFile)
        {
            if (!File.Exists(languageFile))
                return false;

            var strLines = File.ReadAllLines(languageFile);

            foreach (var strLine in strLines)
            {
                var strControlandName = strLine.Split(Constants.ChrLanguageSplitSign);
                if (strControlandName.Length != 2)
                    continue;

                var strControlNames = strControlandName[0].Split(Constants.ChrLanguageControlSplitSign);

                foreach (var languageButton in Instances)
                {
                    if (languageButton.Name == "btnLaunchResource")
                        Console.WriteLine("");

                    if (CheckParents(languageButton, 0, ref strControlNames))
                    {
                        languageButton.Text = strControlandName[1].Trim();
                        break;
                    }
                }
                

            }

            return true;
        }

        private static bool CheckParents(Control currentControl, int index, ref string[] controlNames)
        {
            var bResult = currentControl.Name == controlNames[controlNames.Length - index - 1];

            if (!bResult)
                return false;

            if (currentControl.Parent != null)
                CheckParents(currentControl.Parent, ++index, ref controlNames);

            return true;
        }
    }
}
