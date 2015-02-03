using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using AnotherSc2Hack.Classes.FrontEnds.Container;

namespace AnotherSc2Hack.Classes.BackEnds.Preference
{
    //TODO: Add global filters
    class PreferenceManager
    {
        private PreferenceAll _preferenceAll;
        private XmlSerializer _xmlSerializer;

        public PreferenceManager()
        {
            _preferenceAll = new PreferenceAll();
            _xmlSerializer = new XmlSerializer(_preferenceAll.GetType());
        }

        public void Read()
        {
            _preferenceAll = (PreferenceAll)_xmlSerializer.Deserialize(new StreamReader(Constants.StrXmlPreferences));

            /*
            var xmlReader = XmlReader.Create(Constants.StrXmlPreferences);

            while (xmlReader.Read())
            {
                //ReaderHelper(xmlReader, Global);
                ReaderHelper(xmlReader, pOverlayResource, OverlayResources);
                ReaderHelper(xmlReader, pOverlayIncome, OverlayIncome);
                ReaderHelper(xmlReader, pOverlayWorker, OverlayWorker);
                ReaderHelper(xmlReader, pOverlayArmy, OverlayArmy);
                ReaderHelper(xmlReader, pOverlayApm, OverlayApm);
                ReaderHelper(xmlReader, pOverlayProduction, OverlayProduction);
                ReaderHelper(xmlReader, pOverlayUnits, OverlayUnits);
                ReaderHelper(xmlReader, pOverlayMaphack, OverlayMaphack);
            }

            */

            
        }

        private void ReaderHelper(XmlReader reader, PreferenceBase preferenceStructure)
        {
            if ((reader.NodeType == XmlNodeType.Element) && reader.Name == preferenceStructure.ElementName)
            {
                var infos = preferenceStructure.GetType().GetProperties();
                while (reader.Read())
                {
                    foreach (var propertyInfo in infos)
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && reader.Name == propertyInfo.Name)
                        {

                            var strItemType = reader.GetAttribute("Type");

                            if (strItemType != null)
                            {
                                var type = Type.GetType(strItemType);

                                
                            }

                            Console.WriteLine(reader.Name + "[" + strItemType + "] => " + reader.ReadElementString());
                            //propertyInfo.SetValue(preferenceStructure, strItem);
                            //Console.WriteLine(propertyInfo.Name + " => " + reader.GetAttribute(propertyInfo.Name));

                        }
                    }

                }
            }
        }

        private void WriteHelper(XmlWriter writer, PreferenceBase preferenceStructure)
        {
            var infos = preferenceStructure.GetType().GetProperties();
            

            writer.WriteStartElement(preferenceStructure.ElementName);

            foreach (var propertyInfo in infos)
            {
                writer.WriteStartElement(propertyInfo.Name);
                writer.WriteAttributeString("Type", propertyInfo.PropertyType.ToString());
                writer.WriteString(propertyInfo.GetValue(preferenceStructure).ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        public void Write()
        {
            _xmlSerializer.Serialize(new StreamWriter(Constants.StrXmlPreferences), _preferenceAll);

           /**
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
            }*/
        }
    }
}
