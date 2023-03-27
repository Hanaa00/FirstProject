using Newtonsoft.Json;
using System.Xml.Serialization;

namespace XMLParse
{
    [XmlRoot(ElementName = "root")]
    public class Device
    {
        public Device()
        {
            Ports = new List<Port>(); // Or whatever type the Ports property is.
        }

        [JsonProperty("deviceName")]
            [XmlElement(ElementName = "deviceName")]
            public string? DeviceName { get; set; }


            [JsonProperty("manufacturer")]
            [XmlElement(ElementName = "manufacturer")]
            public string? Manufacturer { get; set; }


            [JsonProperty("part-number")]
            [XmlElement(ElementName = "part-number")]
            public string? PartNumber { get; set; }


           [JsonProperty("serial-number")]
           [XmlElement(ElementName = "serial-number")]
            public string? SerialNumber { get; set; }


           [JsonProperty("product-name")]
           [XmlElement(ElementName = "product-name")]
            public string? ProductName { get; set; }


          [JsonProperty("vendor-part-number")]
          [XmlElement(ElementName = "vendor-part-number")]
            public string? VendorPartNumber { get; set; }


          [JsonProperty("vendor-serial-number")]
          [XmlElement(ElementName = "vendor-serial-number")]
            public string? VendorSerialNumber { get; set; }


          [JsonProperty("license-id")]
          [XmlElement(ElementName = "license-id")]
            public string? LicenseId { get; set; }


          [JsonProperty("chassis-wwn")]
          [XmlElement(ElementName = "chassis-wwn")]
            public string? ChassisWwn { get; set; }

          [JsonProperty("collectorDate")]
          [XmlElement(ElementName = "collectorDate")]
            public string? CollectorDate { get; set; }

            [XmlElement(ElementName = "ports")]
            public List<Port> Ports { get; set; }
        }


    }
