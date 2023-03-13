using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


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
            openFileDialog.Filter= "XML Files (*.xml)|*.xml";
            openFileDialog.FilterIndex = 1;
            DialogResult result= openFileDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string formattedContent = FormatXmlDocument(xmlDocument);
                fileContentTextBox.Text = formattedContent;
            }
        }

        private string FormatXmlDocument(XmlDocument xmlDocument)
        {
            StringBuilder sb = new StringBuilder();
            XmlElement root = xmlDocument.DocumentElement;
            XmlNodeList nodeList = root.ChildNodes;
            foreach (XmlNode node in nodeList)
            {
                sb.AppendLine($"{node.Name}: {node.InnerText}");
            }
            return sb.ToString();
        }


    }
}