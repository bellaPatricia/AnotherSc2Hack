using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AnotherSc2Hack.Classes.FrontEnds.Container;

namespace AnotherSc2Hack.Classes.BackEnds.Preference
{
    //TODO: Add global filters
    class PreferenceManager
    {
        public PreferenceGlobal Global { get; set; }
        public PreferenceOverlayResources OverlayResources { get; set; }
        public PreferenceOverlayWorker OverlayWorker { get; set; }
        public PreferenceOverlayUnits OverlayUnits { get; set; }
        public PreferenceOverlayProduction OverlayProduction { get; set; }
        public PreferenceOverlayIncome OverlayIncome { get; set; }
        public PreferenceOverlayArmy OverlayArmy { get; set; }
        public PreferenceOverlayApm OverlayApm { get; set; }
        public PreferenceOverlayMaphack OverlayMaphack { get; set; }

        public PreferenceManager()
        {
            Global = new PreferenceGlobal();
            OverlayResources = new PreferenceOverlayResources();
            OverlayIncome = new PreferenceOverlayIncome();
            OverlayWorker = new PreferenceOverlayWorker();
            OverlayApm = new PreferenceOverlayApm();
            OverlayArmy = new PreferenceOverlayArmy();
            OverlayProduction = new PreferenceOverlayProduction();
            OverlayUnits = new PreferenceOverlayUnits();
            OverlayMaphack = new PreferenceOverlayMaphack();
        }

        public void Read()
        {
            
        }

        public void Write()
        {
            var pGlobal = typeof(PreferenceGlobal).GetProperties();
            var pOverlayResource = typeof(PreferenceOverlayResources).GetProperties();
            var pOverlayIncome = typeof(PreferenceOverlayIncome).GetProperties();
            var pOverlayWorker = typeof(PreferenceOverlayWorker).GetProperties();
            var pOverlayArmy = typeof(PreferenceOverlayArmy).GetProperties();
            var pOverlayApm = typeof(PreferenceOverlayApm).GetProperties();
            var pOverlayProduction = typeof(PreferenceOverlayProduction).GetProperties();
            var pOverlayUnits = typeof(PreferenceOverlayUnits).GetProperties();
            var pOverlayMaphack = typeof(PreferenceOverlayMaphack).GetProperties();


            var xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;

            try
            {

                using (var xmlWriter = XmlWriter.Create(Constants.StrXmlPreferences, xmlSettings))
                {
                    xmlWriter.WriteComment("AnotherSc2 Hack - Settings file");
                    xmlWriter.WriteComment("This file contains various settings for the software");
                    xmlWriter.WriteComment("Please don't mess it up!");

                    xmlWriter.WriteStartElement("AnotherSc2Hack");

                    #region Global

                    xmlWriter.WriteComment("Changes that affect the whole application and in the global scope");
                    xmlWriter.WriteStartElement("Global");
                    foreach (var propertyInfo in pGlobal)
                    {
                        xmlWriter.WriteElementString(propertyInfo.Name, propertyInfo.GetValue(Global).ToString());
                    }
                    xmlWriter.WriteEndElement();

                    #endregion

                    #region Overlays

                    xmlWriter.WriteComment("Overlay specific settings. Seperated for each overlay");
                    xmlWriter.WriteStartElement("Overlays");

                    #region Resource

                    xmlWriter.WriteStartElement("OverlayResources");
                    foreach (var propertyInfo in pOverlayResource)
                    {
                        xmlWriter.WriteElementString(propertyInfo.Name,
                            propertyInfo.GetValue(OverlayResources).ToString());
                    }
                    xmlWriter.WriteEndElement();

                    #endregion

                    #region Income

                    xmlWriter.WriteStartElement("OverlayIncome");
                    foreach (var propertyInfo in pOverlayIncome)
                    {
                        Console.WriteLine("Name: " + propertyInfo.Name);
                        Console.WriteLine("Value: " + propertyInfo.GetValue(OverlayIncome));

                        xmlWriter.WriteElementString(propertyInfo.Name, propertyInfo.GetValue(OverlayIncome).ToString());
                    }
                    xmlWriter.WriteEndElement();

                    #endregion

                    #region Worker

                    xmlWriter.WriteStartElement("OverlayWorker");
                    foreach (var propertyInfo in pOverlayWorker)
                    {
                        xmlWriter.WriteElementString(propertyInfo.Name, propertyInfo.GetValue(OverlayWorker).ToString());
                    }
                    xmlWriter.WriteEndElement();

                    #endregion

                    #region Apm

                    xmlWriter.WriteStartElement("OverlayApm");
                    foreach (var propertyInfo in pOverlayApm)
                    {
                        xmlWriter.WriteElementString(propertyInfo.Name, propertyInfo.GetValue(OverlayApm).ToString());
                    }
                    xmlWriter.WriteEndElement();

                    #endregion

                    #region Army

                    xmlWriter.WriteStartElement("OverlayArmy");
                    foreach (var propertyInfo in pOverlayArmy)
                    {
                        xmlWriter.WriteElementString(propertyInfo.Name, propertyInfo.GetValue(OverlayArmy).ToString());
                    }
                    xmlWriter.WriteEndElement();

                    #endregion

                    #region Units

                    xmlWriter.WriteStartElement("OverlayUnits");
                    foreach (var propertyInfo in pOverlayUnits)
                    {
                        xmlWriter.WriteElementString(propertyInfo.Name, propertyInfo.GetValue(OverlayUnits).ToString());
                    }
                    xmlWriter.WriteEndElement();

                    #endregion

                    #region Production

                    xmlWriter.WriteStartElement("OverlayProduction");
                    foreach (var propertyInfo in pOverlayProduction)
                    {
                        xmlWriter.WriteElementString(propertyInfo.Name,
                            propertyInfo.GetValue(OverlayProduction).ToString());
                    }
                    xmlWriter.WriteEndElement();

                    #endregion

                    #region Maphack

                    xmlWriter.WriteStartElement("OverlayMaphack");
                    foreach (var propertyInfo in pOverlayMaphack)
                    {
                        xmlWriter.WriteElementString(propertyInfo.Name,
                            propertyInfo.GetValue(OverlayMaphack).ToString());
                    }
                    xmlWriter.WriteEndElement();

                    #endregion

                    xmlWriter.WriteEndElement();

                    #endregion



                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();

                }
            }

            catch (TargetException ex)
            {
                Messages.Show("Whatever", ex);
            }
        }
    }
}
