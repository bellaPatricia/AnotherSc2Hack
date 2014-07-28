using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PluginSupply
{
    public class Preferences
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public Int32 Width { get; set; }
        public Int32 Height { get; set; }
        public Int32 Key { get; set; }

        private string StrPrefFile = "PluginSupply.ini";

        public Preferences()
        {
            if (Directory.Exists("Plugins"))
                StrPrefFile = "Plugins\\" + StrPrefFile;

            Read();
        }

         ~Preferences()
        {
            Write();
        }

        public void Read()
        {
            if (!File.Exists(StrPrefFile))
            {
                X = 0;
                Y = 0;
                Width = 100;
                Height = 25;
                Key = (Int32)Keys.NumPad0;
                Write();
            }

            else
            {
                using (var sr = new StreamReader(StrPrefFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string strLine = sr.ReadLine();

                        if (strLine == null)
                            continue;

                        if (strLine.Length <= 0)
                            continue;

                        string strLetter = strLine[0].ToString(CultureInfo.InvariantCulture);
                        strLine = strLine.Substring(strLine.IndexOf("=", System.StringComparison.Ordinal) + 1);

                        var iRes = 0;
                        if (Int32.TryParse(strLine, out iRes))
                        {
                            //Blubb
                        }

                        if (strLetter == "X")
                            X = iRes;

                        else if (strLetter == "Y")
                            Y = iRes;

                        else if (strLetter == "W")
                            Width = iRes;

                        else if (strLetter == "H")
                            Height = iRes;

                        else if (strLetter == "K")
                            Key = iRes;
                    }
                }
            }
        }

        public void Write()
        {
            if (File.Exists(StrPrefFile))
                File.Delete(StrPrefFile);

            using (var sw = new StreamWriter(StrPrefFile))
            {
                sw.WriteLine("X=" + X);
                sw.WriteLine("Y=" + Y);
                sw.WriteLine("Width=" + Width);
                sw.WriteLine("Height=" + Height);
                sw.WriteLine("Key(Decimal-base10)=" + Key);
            }
        }
    }

    
}
