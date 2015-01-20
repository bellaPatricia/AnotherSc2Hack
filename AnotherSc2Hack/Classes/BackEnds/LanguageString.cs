using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AnotherSc2Hack.Classes.BackEnds
{
    
    public class LanguageString
    {
        public string Text { get; set; }
        public string Name { get; set; }

        public LanguageString()
        {
            
        }

        public LanguageString(string text)
        {
            Text = text;
        }

        public LanguageString(string text, string name)
        {
            Text = text;
            Name = name;
        }

        public string LanguageFile
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
    }
}
