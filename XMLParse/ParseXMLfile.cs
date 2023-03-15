using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XMLParse;

namespace XMLParse
{
    public class ParseXMLfile
    {
        public static string ParseXmlFile(string filePath)
        {
            try
            {
                
                XmlSerializer serializer = new XmlSerializer(typeof(Device));
                Device device;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    device = (Device)serializer.Deserialize(reader);
                }

                
                string parsedData = $"Device Name: {device.DeviceName}\r\n" +
                                    $"Manufacturer: {device.Manufacturer}\r\n" +
                                    $"Part Number: {device.PartNumber}\r\n" +
                                    $"Serial Number: {device.SerialNumber}\r\n" +
                                    $"Product Name: {device.ProductName}\r\n" +
                                    $"Vendor Part Number: {device.VendorPartNumber}\r\n" +
                                    $"Vendor Serial Number: {device.VendorSerialNumber}\r\n" +
                                    $"License ID: {device.LicenseId}\r\n" +
                                    $"Chassis Wwn: {device.ChassisWwn}\r\n" +
                                    $"Collector Date: {device.CollectorDate}\r\n\r\n" +
                                    "Ports:\r\n";

                foreach (Port port in device.Ports)
                {
                    parsedData += $"  WWPN: {port.Wwpn}\r\n" +
                                    $"  WWNN: {port.Wwnn}\r\n" +
                                    $"  Domain ID: {port.DomainId}\r\n" +
                                    $"  FCID: {port.Fcid}\r\n" +
                                    $"  Firmware Version: {port.FirmwareVersion}\r\n" +
                                    $"  Serial Number: {port.SerialNumber}\r\n" +
                                    $"  Port Name: {port.PortName}\r\n" +
                                    $"  Port Number: {port.PortNumber}\r\n\r\n";
                }

                return parsedData;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

    }
}
