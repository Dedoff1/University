using System;
using System.IO;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.LinkLabel;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private BigInteger d;
        public string filepathload;
        private void Calculate_Click(object sender, EventArgs e)
        {
            ProcessedTextBox.Text = "";
            ResultTextBox.Text = "";
            ResultCheckBox.Text = "";
            HashBox.Text = "";
            SignBox.Text = "";
            BigInteger p, q, d, r, rfunc, h0, h1, sign;
            string originaltext;
            string correctiontext = "", correctionp = "", correctionq = "", correctiond = "", finalp = "", finalq = "", finald = "";
            originaltext = OriginalTextBox.Text;
            foreach (char c in originaltext)
            {
                // Проверьте, является ли символ русской буквой
                if ((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я') || (c>='a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    // Добавьте букву в новую строку
                    correctiontext += Char.ToLower(c);
                }
            }
            if (PValueBox.Text == "" || QValueBox.Text == "" || SecretKeyBox.Text == "" || correctiontext.Length == 0)
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                correctionp = PValueBox.Text;
                correctionq = QValueBox.Text;
                correctiond = SecretKeyBox.Text;
                for (int i = 0; i < PValueBox.Text.Length; i++)
                    if (char.IsDigit(correctionp[i]))
                        finalp = finalp + PValueBox.Text[i];
                for (int i = 0; i < QValueBox.Text.Length; i++)
                    if (char.IsDigit(correctionq[i]))
                        finalq = finalq + QValueBox.Text[i];
                for (int i = 0; i < SecretKeyBox.Text.Length; i++)
                    if (char.IsDigit(correctiond[i]))
                        finald = finalp + SecretKeyBox.Text[i];
                if (finalp == "" || finalq == "" || finald == "" || correctiontext.Length == 0)
                {
                    MessageBox.Show("Введите корректные данные");
                }
                else
                {
                    p = BigInteger.Parse(finalp);
                    q = BigInteger.Parse(finalq);
                    d = BigInteger.Parse(finald);
                    r = p * q;
                    rfunc = (q - 1) * (p - 1);
                    if (AreCoprime(d, rfunc))
                    {
                        if (!(1 < d && d < rfunc))
                        {
                            MessageBox.Show("Указанные значения d и r не удовлетворяют условиям.");
                        }
                        else
                        {
                            h0 = 100;
                            h1 = 0;
                            ProcessedTextBox.Text = correctiontext;
                            for (int i = 0; i < correctiontext.Length; i++)
                            {
                                h1 = (h0 + (originaltext[i] - 'а' + 1)) * (h0 + (originaltext[i] - 'а' + 1)) % r;
                                h0 = h1;
                            }
                            HashBox.Text = h1.ToString();
                            sign = PowerMod(h1, d, r);
                            SignBox.Text = sign.ToString();
                            originaltext = originaltext + ", " + sign.ToString();
                            ResultTextBox.Text = originaltext;
                            if (!(PathLoadBox.Text == ""))
                                File.WriteAllText(filepathload, originaltext);
                        }

                    }
                    else

                    {

                        MessageBox.Show("Неккорректные значения d и r");

                    }
                }
            }


        }
        public BigInteger PowerMod(BigInteger a, BigInteger b, BigInteger m)
        {
            BigInteger result = 1;
            while (b > 0)
            {
                if (b % 2 == 1)
                {
                    result = (result * a) % m;
                }
                b /= 2;
                a = (a * a) % m;
            }
            return result;
        }
        public static bool AreCoprime(BigInteger a, BigInteger b)
        {
            return GCD(a, b).Equals(BigInteger.One);
        }

        private static BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (b != BigInteger.Zero)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }





        /*public static int FindExponent(BigInteger d, BigInteger r)
        {
            // Проверьте условия
            if (!(1 < d && d < r) || GCD(d, r) != 1)
            {
                
                //MessageBox.Show("Указанные значения d и r не удовлетворяют условиям.");
            }
            

                // Инициализируйте экспоненту
                int e = 2;

                // Вычисляйте экспоненту, пока не будет найдено значение, удовлетворяющее условию
                while ((BigInteger.Pow(d, e) % r) != 1)
                {
                    e++;
                }

                return e;
            
        }*/

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void LoadFile_Click(object sender, EventArgs e)
        {

            var filePath = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                PathLoadBox.Text = filePath;
                filepathload = filePath;
            }
            string fileContent = File.ReadAllText(filepathload);
            OriginalTextBox.Text = fileContent;

        }


        private void CheckSign_Click(object sender, EventArgs e)
        {
            //if (Checking.Checked)
            //{
            BigInteger p, q, r, rfunc, h0, h1, sign1, sign2, exp, sign3, d;
            string originaltext, sign;
            string correctiontext = "";
            sign = "";
            int ex;
            originaltext = OriginalTextBox.Text;

            int indexOfQuote = originaltext.IndexOf(',');
            if (indexOfQuote == -1)
            {
                MessageBox.Show("Отсутствует подпись");
            }
            else
            {

                for (int i = indexOfQuote + 1; i < originaltext.Length; i++)
                {
                    if (char.IsDigit(originaltext[i]))
                    {
                        // Добавьте цифру к переменной numbers
                        sign += originaltext[i];
                    }
                }
                sign1 = int.Parse(sign);
                foreach (char c in originaltext)
                {
                    // Проверьте, является ли символ русской буквой
                    if ((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                    {
                        // Добавьте букву в новую строку
                        correctiontext += Char.ToLower(c);
                    }
                }
                if (PValueBox.Text == "" || QValueBox.Text == "" || SecretKeyBox.Text == "" || correctiontext.Length == 0)
                {
                    MessageBox.Show("Введите все данные");
                }
                else
                {
                    p = BigInteger.Parse(PValueBox.Text);
                    q = BigInteger.Parse(QValueBox.Text);
                    d = BigInteger.Parse(SecretKeyBox.Text);
                    r = p * q;
                    rfunc = (q - 1) * (p - 1);
                    if (AreCoprime(d, rfunc))
                    {

                        h0 = 100;
                        h1 = 0;
                        ProcessedTextBox.Text = correctiontext;
                        for (int i = 0; i < correctiontext.Length; i++)
                        {
                            h1 = (h0 + (correctiontext[i] - 'а' + 1)) * (h0 + (correctiontext[i] - 'а' + 1)) % r;
                            h0 = h1;
                        }
                        HashBox.Text = h1.ToString();
                        if (!(1 < d && d < rfunc) || GCD(d, rfunc) != 1)
                        {
                            MessageBox.Show("Указанные значения d и r не удовлетворяют условиям.");
                        }
                        else
                        {
                            /*ex = 10;
                            while (true)
                            {
                                if ((ex * d) % rfunc == 0)
                                    break;
                                else
                                    ex++;
                            }*/

                            // Инициализируйте экспоненту
                            ex = 2;

                            // Вычисляйте экспоненту, пока не будет найдено значение, удовлетворяющее условию
                            while ((BigInteger.Pow(d, ex) % rfunc) != 1)
                            {
                                ex++;
                            }
                            exp = ex;
                            sign2 = PowerMod(sign1, exp, r);
                            
                            //SignBox.Text = sign2.ToString();
                            ResultTextBox.Text = originaltext;
                            if ( sign2 == h1)
                            {
                                textBox1.Text = "Подпись действительна";
                            }
                            else
                            {
                                textBox1.Text = "Подпись не действительна";
                            }
                            
                            
                            
                            
                            
                            




                            
                            sign3 = PowerMod(h1, d, r);
                            SignBox.Text = sign3.ToString();
                            
                            
                            
                            if (sign1 == sign3)
                            {
                                ResultCheckBox.Text = "Подпись действительна";
                            }
                            else
                            {
                                ResultCheckBox.Text = "Подпись не действительна";
                            }
                        }
                    }
                    else MessageBox.Show("Введите кооректное значения d и r");
                }
            }
        }


    }
}