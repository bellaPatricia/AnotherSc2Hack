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
            var xmlReader = XmlReader.Create(Constants.StrXmlPreferences);

            while (xmlReader.Read())
            {
                ReaderHelper(xmlReader, Global);
                /*ReaderHelper(xmlReader, pOverlayResource, OverlayResources);
                ReaderHelper(xmlReader, pOverlayIncome, OverlayIncome);
                ReaderHelper(xmlReader, pOverlayWorker, OverlayWorker);
                ReaderHelper(xmlReader, pOverlayArmy, OverlayArmy);
                ReaderHelper(xmlReader, pOverlayApm, OverlayApm);
                ReaderHelper(xmlReader, pOverlayProduction, OverlayProduction);
                ReaderHelper(xmlReader, pOverlayUnits, OverlayUnits);
                ReaderHelper(xmlReader, pOverlayMaphack, OverlayMaphack);*/
            }


        }

        private void ReaderHelper(XmlReader reader, PreferenceBase preferenceStructure)
        {
            if ((reader.NodeType == XmlNodeType.Element) && reader.Name == preferenceStructure.ElementName)
            {
                var infos = preferenceStructure.GetType().GetProperties();

                Console.WriteLine("Type => " + preferenceStructure.GetType());
                foreach (var propertyInfo in infos)
                {
                    var strItem = reader.GetAttribute(propertyInfo.Name);

                    Console.WriteLine(propertyInfo.Name + " => " + strItem);
                    Console.WriteLine(propertyInfo.Name.GetType());
                    //propertyInfo.SetValue(preferenceStructure, strItem);
                    //Console.WriteLine(propertyInfo.Name + " => " + reader.GetAttribute(propertyInfo.Name));

                }


            }
        }

        private void WriteHelper(XmlWriter writer, PreferenceBase preferenceStructure)
        {
            var infos = preferenceStructure.GetType().GetProperties();

            writer.WriteStartElement(preferenceStructure.ElementName);

            foreach (var propertyInfo in infos)
            {
                writer.WriteAttributeString(propertyInfo.Name, propertyInfo.GetValue(preferenceStructure).ToString());
            }

            writer.WriteEndElement();
        }

        public void Write()
        {
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

                    xmlWriter.WriteComment("Changes that affect the whole application and in the global scope");
                    WriteHelper(xmlWriter, Global);

                    xmlWriter.WriteComment("Overlay specific settings. Seperated for each overlay");
                    xmlWriter.WriteStartElement("Overlays");
                    WriteHelper(xmlWriter, OverlayResources);
                    WriteHelper(xmlWriter, OverlayIncome);
                    WriteHelper(xmlWriter, OverlayWorker);
                    WriteHelper(xmlWriter, OverlayApm);
                    WriteHelper(xmlWriter, OverlayArmy);
                    WriteHelper(xmlWriter, OverlayUnits);
                    WriteHelper(xmlWriter, OverlayProduction);
                    WriteHelper(xmlWriter, OverlayMaphack);
                    xmlWriter.WriteEndElement();

                    



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
