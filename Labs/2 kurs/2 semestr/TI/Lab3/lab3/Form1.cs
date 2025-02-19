namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                LoadFromFile.Text = filePath;
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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int p, x, k;
            string Test;
            bool Correct1,Correct2,Correct3;
            Test = pvalue.Text;
            Correct1 = Test.All(char.IsDigit);
            Test = xvalue.Text;
            Correct2 = Test.All(char.IsDigit);
            Test = kvalue.Text;
            Correct3 = Test.All(char.IsDigit);
            if (LoadFromFile.Text=="" || SaveToFile.Text == "") 
            if (Correct1 && Correct2 && Correct3)
            {
                p = int.Parse(pvalue.Text);
                x = int.Parse(xvalue.Text);
                k = int.Parse(kvalue.Text);
            }
            else
                MessageBox.Show ("¬водимые значени€ могут быть только числами");
        }
    }
}