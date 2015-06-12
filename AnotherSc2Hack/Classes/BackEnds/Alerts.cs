using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.BackEnds
{
    public class Alerts
    {
        public class AlertsSettings
        {
            public AlertsSettings()
            {
                CurrentSupply = new List<int>();
                MaximumSupply = new List<int>();
            }

            public List<Int32> CurrentSupply { get; set; }
            public List<Int32> MaximumSupply { get; set; } 
        }

        public static AlertsSettings ReadAlertsFromFile()
        {
            var al = new AlertsSettings();

            if (!File.Exists(Constants.StrAlertsSettings))
            {
                al.CurrentSupply.Add(10);
                al.CurrentSupply.Add(17);
                al.CurrentSupply.Add(25);
                al.CurrentSupply.Add(32);
                al.CurrentSupply.Add(40);

                al.MaximumSupply.Add(11);
                al.MaximumSupply.Add(19);
                al.MaximumSupply.Add(27);
                al.MaximumSupply.Add(35);
                al.MaximumSupply.Add(43);

                return al;
            }

            using (var sr = new StreamReader(Constants.StrAlertsSettings))
            {
                while (!sr.EndOfStream)
                {
                    var strLine = sr.ReadLine();

                    if (strLine == null)
                        continue;

                    if (strLine.Length <= 0)
                        continue;

                    if (strLine.StartsWith("#"))
                        continue;


                    var strValue = strLine.Split(';');

                    try
                    {
                        al.CurrentSupply.Add(int.Parse(strValue[0]));
                        al.MaximumSupply.Add(int.Parse(strValue[1]));
                    }
                    catch
                    {
                        MessageBox.Show("Error in line!", "AlertsFile.dat- error!");
                    }
                }
            }

            return al;
        }

        //public static bool SupplyWarning(PredefinedTypes.Player player)
        //{
            
        //}
    }
}
