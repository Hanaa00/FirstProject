using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstProject
{
    public partial class Form2 : Form
    {
        string path;
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1_input.Text = "https://filesamples.com/samples/code/json/sample4.json";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd=new FolderBrowserDialog();
            if(fbd.ShowDialog()== DialogResult.OK)
            {
                path=fbd.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = textBox1_input.Text;
            WebClient client = new WebClient();
            string jsonData = client.DownloadString(url);
            string fileName = Path.GetFileName(url);
            string filePath = Path.Combine(path, fileName);
            File.WriteAllText(filePath, jsonData);
            MessageBox.Show("File saved successfully.");

        }

        
    }
}
