using System.Windows.Forms;

namespace Form2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml|HTML Files (*.html;*.htm)|*.html;*.htm|Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string FileContent = File.ReadAllText(ofd.FileName);
                textBox1.Text = FileContent;
            }
        }

        private void ParseButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please load a file first.");
                return;
            }

            string fileExtension = Path.GetExtension(ofd.FileName);
        }
    }
}