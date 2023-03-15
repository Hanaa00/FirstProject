using Newtonsoft.Json;
using System.Xml.Serialization;


namespace XMLParse
{
    [XmlRoot(ElementName = "root")]
    public class Port
    {

        [JsonProperty("wwpn")]
        [XmlElement(ElementName = "wwpn")]
        public string Wwpn { get; set; }

        [JsonProperty("wwnn")]
        [XmlElement(ElementName = "wwnn")]
        public string Wwnn { get; set; }

        [JsonProperty("domain-id")]
        [XmlElement(ElementName = "domain-id")]
        public int DomainId { get; set; }

        [JsonProperty("fcid")]
        [XmlElement(ElementName = "fcid")]
        public int Fcid { get; set; }

        [JsonProperty("firmware-version")]
        [XmlElement(ElementName = "firmware-version")]
        public string FirmwareVersion { get; set; }

        [JsonProperty("serial-number")]
        [XmlElement(ElementName = "serial-number")]
        public string SerialNumber { get; set; }

        [JsonProperty("port_name")]
        [XmlElement(ElementName = "port_name")]
        public string PortName { get; set; }

        [JsonProperty("port_number")]
        [XmlElement(ElementName = "port_number")]
        public int PortNumber { get; set; }
    }
   

}
