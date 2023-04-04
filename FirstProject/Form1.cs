using DocumentFormat.OpenXml.Wordprocessing;
using OfficeOpenXml;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using XMLparse;
using XMLParse;


namespace FirstProject
{
    public partial class Form1 : Form
    {
        private string loadedFile;
        public bool is_XML = false;
        public bool is_JSON = false;
        public string fileName;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button_click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml|HTML Files (*.html;*.htm)|*.html;*.htm|Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                loadedFile=ofd.FileName;
                MessageBox.Show("File loaded successfully!");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (loadedFile != null)
            {
                if (Path.GetExtension(loadedFile) == ".xml")
                {
                    fileContentTextBox.Text=ParseXMLfile.ParseXmlFile(loadedFile);
                    is_XML= true;
                }
                else if (Path.GetExtension(loadedFile) == ".json")
                {
                    fileContentTextBox.Text = ParseJSONfile.ParseDevice(loadedFile);
                    is_JSON= true;
                }
                else if (Path.GetExtension(loadedFile) == ".html")
                {
                    fileContentTextBox.Text = ParseHTMLFile.Parse(loadedFile);
                }
                else if (Path.GetExtension(loadedFile) == ".txt")
                {
                    fileContentTextBox.Text = ParseTXTfile.Parse(loadedFile);
                }
                else if (Path.GetExtension(loadedFile) == ".csv")
                {
                    fileContentTextBox.Text = ParseCSVfile.Parse(loadedFile);
                }
            }
            else
            {
                MessageBox.Show("Please load a file first!");
            }
            if (is_JSON || is_XML)
            {
                button3.Visible = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
         

            var device = new Device();

            var templatePath = Path.Combine(Application.StartupPath,"Template.xlsx");

            //if (!File.Exists(templatePath))
            //{
            //    MessageBox.Show("Excel template not found.");
            //    return;
            //}
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

           

            using (var template = new ExcelPackage(new FileInfo(templatePath)))
            {
                // Dodavanje podataka u excel device sheet
                var deviceSheet = template.Workbook.Worksheets["Device info"];
                if (deviceSheet == null)
                {
                    MessageBox.Show("Device info sheet not found in the Excel template.");
                    return;
                }

                var portSheet = template.Workbook.Worksheets["Port info"];
                if (portSheet == null)
                {
                    MessageBox.Show("Port info sheet not found in the Excel template.");
                    return;
                }

                if (is_XML)
                {
                    device = ParseXMLfile.ParseDevice(loadedFile);
                    is_XML= false;
                }
                if (is_JSON)
                {
                    device = ParseJSONfile.ParseDevicee(loadedFile);
                    is_JSON= false;
                }

                deviceSheet.Cells["A2"].Value = device.DeviceName;
                deviceSheet.Cells["B2"].Value = device.Manufacturer;
                deviceSheet.Cells["C2"].Value = device.PartNumber;
                deviceSheet.Cells["D2"].Value = device.SerialNumber;
                deviceSheet.Cells["E2"].Value = device.ProductName;
                deviceSheet.Cells["F2"].Value = device.VendorPartNumber;
                deviceSheet.Cells["G2"].Value = device.VendorSerialNumber;
                deviceSheet.Cells["H2"].Value = device.LicenseId;
                deviceSheet.Cells["I2"].Value = device.ChassisWwn;
                deviceSheet.Cells["J2"].Value = device.CollectorDate;
               
               

                int row = 2;
                foreach (var port in device.Ports)
                {
                    portSheet.Cells["A" + row].Value = port.Wwnn;
                    portSheet.Cells["B" + row].Value = port.Wwpn;
                    portSheet.Cells["C" + row].Value = port.DomainId;
                    portSheet.Cells["D" + row].Value = port.Fcid;
                    portSheet.Cells["E" + row].Value = port.PortName;
                    portSheet.Cells["F" + row].Value = port.PortNumber;
                    portSheet.Cells["G" + row].Value = port.FirmwareVersion;
                    portSheet.Cells["H" + row].Value = port.SerialNumber;
                    portSheet.Cells["I" + row].Value = device.DeviceName;
                    portSheet.Cells["J" + row].Value = device.SerialNumber;
                    row++;
                }
            
               template.Save();
               MessageBox.Show("Export successful.");
            }

          
        }

       

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fileContentTextBox.Clear();
        }



        private void toolStripMenu_exit_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void toolStripMenu_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Parsing app is an application whose main task is parsing files with following extensions: " +
                "JSON, XML, HTML, TXT, CSV ." +
                "Button \"Upload\" loads the desired file." +
                "Button \"Parse file\" parses the loaded file." +
                "Button \"Export to Excel\" exports the parsed file to Excel.");
        }

        private void GetInputOnline_Click(object sender, EventArgs e)
        {
            Form getInputOnlineform = new Form2();
            getInputOnlineform.Show();
        }
    }
}

        
    

