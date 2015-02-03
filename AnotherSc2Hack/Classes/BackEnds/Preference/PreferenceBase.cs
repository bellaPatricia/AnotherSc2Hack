using System.Xml.Serialization;

namespace AnotherSc2Hack.Classes.BackEnds.Preference
{
    public class PreferenceBase
    {
        [XmlIgnore]
        public string ElementName = "PleaseChangeMe";
    }
}
