using System.Xml.Serialization;

namespace XMLParse
{
    [XmlRoot(ElementName = "root")]
    public class Device
    {
            [XmlElement(ElementName = "deviceName")]
            public string DeviceName { get; set; }

            [XmlElement(ElementName = "manufacturer")]
            public string Manufacturer { get; set; }

            [XmlElement(ElementName = "part-number")]
            public string PartNumber { get; set; }

            [XmlElement(ElementName = "serial-number")]
            public string SerialNumber { get; set; }

            [XmlElement(ElementName = "product-name")]
            public string ProductName { get; set; }

            [XmlElement(ElementName = "vendor-part-number")]
            public string VendorPartNumber { get; set; }

            [XmlElement(ElementName = "vendor-serial-number")]
            public string VendorSerialNumber { get; set; }

            [XmlElement(ElementName = "license-id")]
            public string LicenseId { get; set; }

            [XmlElement(ElementName = "chassis-wwn")]
            public string ChassisWwn { get; set; }

            [XmlElement(ElementName = "collectorDate")]
            public string CollectorDate { get; set; }

            [XmlElement(ElementName = "ports")]
            public List<Port> Ports { get; set; }
        }


    }
