using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Windows.Forms;

namespace PluginWorkerTrainer
{
    public class Preferences
    {

        public Double Width { get; set; }
        public Double Height { get; set; }
        public Double Left { get; set; }
        public Double Top { get; set; }
        public Int32 Interval { get; set; }
        public Keys HomeKey { get; set; }
        public Int32 DisableAfterMinute { get; set; }

        public Preferences()
        {
            HomeKey = Keys.None;
            ReadPreferences();
        }

        public void ReadPreferences()
        {
            if (!File.Exists(Constants.PreferenceFile))
            {
                SetDefaultValues();
                return;
            }

            using (var reader = new StreamReader(Constants.PreferenceFile))
            {
                while (!reader.EndOfStream)
                {
                    var strLine = reader.ReadLine();

                    if (strLine == null)
                        continue;

                    if (strLine.StartsWith(";"))
                        continue;

                    if (strLine.Contains(" = "))
                        strLine = strLine.Replace(" = ", "");

                    if (Width == 0.0)
                        Width = ReadSubSetting(Width, "Width", strLine);

                    else if (Height == 0.0)
                        Height = ReadSubSetting(Height, "Height", strLine);

                    else if (Left == 0.0)
                        Left = ReadSubSetting(Left, "Left", strLine);

                    else if (Top == 0.0)
                        Top = ReadSubSetting(Top, "Top", strLine);

                    else if (Interval == 0)
                        Interval = ReadSubSetting(Interval, "Interval", strLine);

                    else if (HomeKey == Keys.None)
                        HomeKey = ReadSubSetting(HomeKey, "HomeKey", strLine);

                    else if (DisableAfterMinute == 0)
                        DisableAfterMinute = ReadSubSetting(DisableAfterMinute, "Minute", strLine);
                }
            }
        }

        public void WritePreferences()
        {
            if (File.Exists(Constants.PreferenceFile))
                File.Delete(Constants.PreferenceFile);

            using (var writer = new StreamWriter(Constants.PreferenceFile))
            {
                WriteSubSetting(writer, Width, "Width");
                WriteSubSetting(writer, Height, "Height");
                WriteSubSetting(writer, Left, "Left");
                WriteSubSetting(writer, Top, "Top");
                WriteSubSetting(writer, Interval, "Interval");
                WriteSubSetting(writer, HomeKey, "HomeKey");
                WriteSubSetting(writer, DisableAfterMinute, "Minute");
            }
        }

        

        private void SetDefaultValues()
        {
            Width = 250;
            Height = 126;
            Left = SystemParameters.PrimaryScreenWidth - Width;
            Top = SystemParameters.PrimaryScreenHeight - Height - 400;
            Interval = 50;
            HomeKey = Keys.NumPad0;
            DisableAfterMinute = 12;
        }

        private static void WriteSubSetting(StreamWriter sw, object variable, String definition)
        {
            sw.WriteLine(";Type = " + variable.GetType());
            sw.WriteLine(definition + " = " + variable);
        }

        private static T ReadSubSetting<T>(T variable, String definition, String innerString)
        {
            if (variable is bool)
            {
                var tmp = Convert.ToBoolean(variable);
                if (tmp)
                    return variable;//(T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom("true");

                if (innerString.StartsWith(definition))
                {
                    innerString = innerString.Substring(definition.Length,
                            innerString.Length -
                            definition.Length);

                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(innerString);
                }
            }

            else if (variable is Int32)
            {
                if (Convert.ToInt32(variable) != 0)
                    return variable;

                if (innerString.StartsWith(definition))
                {
                    innerString = innerString.Substring(definition.Length,
                            innerString.Length -
                            definition.Length);

                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(innerString);
                }
            }

            else if (variable is Double)
            {
                if (Convert.ToDouble(variable) != 0.0)
                    return variable;

                if (innerString.StartsWith(definition))
                {
                    innerString = innerString.Substring(definition.Length,
                            innerString.Length -
                            definition.Length);

                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(innerString);
                }
            }

            else if (variable is Keys)
            {
                if (Convert.ToInt32(variable) != 0)
                    return variable;

                if (innerString.StartsWith(definition))
                {
                    innerString = innerString.Substring(definition.Length,
                            innerString.Length -
                            definition.Length);

                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(innerString);
                }
            }

            else if (variable is string)
            {
                if (variable.ToString().Length > 0)
                    return variable;

                if (innerString.StartsWith(definition))
                {
                    innerString = innerString.Substring(definition.Length,
                            innerString.Length -
                            definition.Length);

                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(innerString);
                }
            }

            return variable;
        }
    

        


    }
}
