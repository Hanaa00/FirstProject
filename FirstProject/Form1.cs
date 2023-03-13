using System.IO;
using System.Xml.Serialization;
using XMLParse;

namespace FirstProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog.FilterIndex = 1;
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

            
                XmlSerializer deviceSerializer = new XmlSerializer(typeof(Device));

               
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    Device device = (Device)deviceSerializer.Deserialize(fileStream);

                    
                    fileContentTextBox.Text = $"Device Name: {device.DeviceName}\r\n";
                    fileContentTextBox.AppendText($"Manufacturer: {device.Manufacturer}\r\n");
                    fileContentTextBox.AppendText($"Part Number: {device.PartNumber}\r\n");
                    fileContentTextBox.AppendText($"Serial Number: {device.SerialNumber}\r\n");
                    fileContentTextBox.AppendText($"Product Name: {device.ProductName}\r\n");
                    fileContentTextBox.AppendText($"Vendor Part Number: {device.VendorPartNumber}\r\n");
                    fileContentTextBox.AppendText($"Vendor Serial Number: {device.VendorSerialNumber}\r\n");
                    fileContentTextBox.AppendText($"License ID: {device.LicenseId}\r\n");
                    fileContentTextBox.AppendText($"Chassis WWN: {device.ChassisWwn}\r\n");

                    
                    foreach (Port port in device.Ports)
                    {
                        fileContentTextBox.AppendText("\r\n");
                        fileContentTextBox.AppendText($"WWPN: {port.Wwpn}\r\n");
                        fileContentTextBox.AppendText($"WWNN: {port.Wwnn}\r\n");
                        fileContentTextBox.AppendText($"Domain ID: {port.DomainId}\r\n");
                        fileContentTextBox.AppendText($"FCID: {port.Fcid}\r\n");
                        fileContentTextBox.AppendText($"Firmware Version: {port.FirmwareVersion}\r\n");
                        fileContentTextBox.AppendText($"Serial Number: {port.SerialNumber}\r\n");
                        fileContentTextBox.AppendText($"Port Name: {port.PortName}\r\n");
                        fileContentTextBox.AppendText($"Port Number: {port.PortNumber}\r\n");
                    }
                }
            }
        }
    }
}
