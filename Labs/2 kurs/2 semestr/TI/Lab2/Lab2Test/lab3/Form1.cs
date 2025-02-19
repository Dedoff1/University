using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string filepathload;
        public string filepathsave;
        private void button2_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                LoadFromFile.Text = filePath;
                filepathload = filePath;
            }

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                LoadFromFile.Text = filePath;
                filepathsave = filePath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileContent = File.ReadAllText(filepathload);
            byte[] bytes = Encoding.UTF8.GetBytes(fileContent);
            StringBuilder binaryString = new StringBuilder();
            foreach (byte b in bytes)
            {
                binaryString.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            OriginalText.Text = binaryString.ToString();
            string origkey = "";
            origkey = OriginalKey.Text;
            string key = "";
            string tempkey = "";
            string restext = "";
            while (key.Length < binaryString.Length)
            {
                tempkey =Convert.ToString( origkey[0] ^ origkey[6] ^ origkey[7] ^ origkey[26]);
                key += origkey[0];
                origkey = origkey.Substring(1)+tempkey;
                
            }
            for (int i = 0; i < binaryString.Length; i++)
            {
                  tempkey = Convert.ToString(binaryString[i] ^ key[i]);
                  restext += tempkey;
            }
            ResultText.Text=restext;
            
        }
    }
}