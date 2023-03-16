using System.IO;
using System.Xml.Serialization;
using XMLparse;
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
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml|HTML Files (*.html;*.htm)|*.html;*.htm|Text Files (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(ofd.FileName);
                if (extension == ".json")
                {
                    fileContentTextBox.Text = ParseJSONfile.ParseDevice(ofd.FileName);
                }
                else if (extension == ".xml")
                {
                    fileContentTextBox.Text = ParseXMLfile.ParseXmlFile(ofd.FileName);
                }
                else if (extension == ".html" || extension == ".htm")
                {
                    fileContentTextBox.Text = ParseHTMLFile.Parse(ofd.FileName);
                }
                else if (extension == ".txt") 
                {
                    fileContentTextBox.Text = XMLParse.ParseTXTfile.Parse(ofd.FileName);  
                }
                else
                {
                    MessageBox.Show("Invalid file type. Please select a JSON, XML,HTML or TEXT file.");
                }
            }
        }
    }
    }
        
    

