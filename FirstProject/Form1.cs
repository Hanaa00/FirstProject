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
                }
                else if (Path.GetExtension(loadedFile) == ".json")
                {
                    fileContentTextBox.Text = ParseJSONfile.ParseDevice(loadedFile);
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

        }
    }
}
        
    

