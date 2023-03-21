namespace WindowsForm2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd=new OpenFileDialog();
            ofd.Filter = "JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml|HTML Files (*.html;*.htm)|*.html;*.htm|Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileContent=File.ReadAllText(ofd.FileName);
                textBox1.Text = fileContent;
            }
        }

       
    }
}