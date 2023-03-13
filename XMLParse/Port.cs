using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace XMLParse
{
    [XmlRoot(ElementName = "root")]
    public class Port
    {
        [XmlElement(ElementName = "wwpn")]
        public string Wwpn { get; set; }

        [XmlElement(ElementName = "wwnn")]
        public string Wwnn { get; set; }

        [XmlElement(ElementName = "domain-id")]
        public int DomainId { get; set; }

        [XmlElement(ElementName = "fcid")]
        public int Fcid { get; set; }

        [XmlElement(ElementName = "firmware-version")]
        public string FirmwareVersion { get; set; }

        [XmlElement(ElementName = "serial-number")]
        public string SerialNumber { get; set; }

        [XmlElement(ElementName = "port_name")]
        public string PortName { get; set; }

        [XmlElement(ElementName = "port_number")]
        public int PortNumber { get; set; }
    }
   

}
