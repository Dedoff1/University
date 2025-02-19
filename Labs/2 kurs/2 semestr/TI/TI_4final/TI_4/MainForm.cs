using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace TI_4;

public partial class MainForm : Form
{
    const int CountOfTests = 10;

    BigInteger BigIntegerR { get; set; }
    BigInteger BigIntegerFunctionR { get; set; }
    BigInteger BigIntegerE { get; set; }
    BigInteger BigIntegerD { get; set; }

    byte[] OpenedFileBytes { get; set; }

    BigInteger HashFunction { get; set; }
    
    BigInteger EdsValue { get; set; }

    public MainForm() => InitializeComponent();

    void ButtonR_Click(object sender, EventArgs e)
    {
        TextBoxP.Text = string.Join("", TextBoxP.Text.Where(char.IsDigit));
        TextBoxQ.Text = string.Join("", TextBoxQ.Text.Where(char.IsDigit));
        TextBoxD.Text = string.Join("", TextBoxD.Text.Where(char.IsDigit));

        if (TextBoxP.Text.Length == 0)
        {
            MessageBox.Show("Right the correct P value!", "Warning");
            return;
        }
        
        if (TextBoxQ.Text.Length == 0)
        {
            MessageBox.Show("Write a correct Q value !", "Warning");
            return;
        }

        BigInteger bigIntegerP = BigInteger.Parse(TextBoxP.Text);
        if (!RSA.IsPrime(bigIntegerP, CountOfTests))
        {
            MessageBox.Show("P is supposed to be a prime number!", "Warning");
            return;
        }
        
        BigInteger bigIntegerQ = BigInteger.Parse(TextBoxQ.Text);
        if (!RSA.IsPrime(bigIntegerQ, CountOfTests))
        {
            MessageBox.Show("Q is supposed to be a prime number!", "Warning");
            return;
        }

        BigIntegerR = bigIntegerQ * bigIntegerP;
        if (BigIntegerR < 256)
        {
            MessageBox.Show("P*Q is supposed to be bigger than 256!", "Warning");
            return;
        }
        
        TextBoxR.Text = BigIntegerR.ToString();
        BigIntegerFunctionR = RSA.EulerPhi(BigIntegerR);
        TextBoxEuler.Text = BigIntegerFunctionR.ToString();

        if (TextBoxD.Text.Length == 0)
        {
            MessageBox.Show("Write a correct D value!", "Warning");
            return;
        }
        
        BigIntegerD = BigInteger.Parse(TextBoxD.Text);
        if (BigIntegerD < 1 || BigIntegerD >= BigIntegerFunctionR)
        {
            MessageBox.Show("D is supposed to be bigger than 1 and not bigger than Euler function!", "Warning");
            return;
        }
        
        BigInteger gcd = RSA.FindGcd(BigIntegerD, BigIntegerFunctionR);
        if (gcd != 1)
        {
            MessageBox.Show("D is supposed to be prime with Euler function!", "Warning");
            return;
        }
        
        var extendedEuclidResult = BigIntegerFunctionR > BigIntegerD
            ? RSA.EuclidExtended(BigIntegerFunctionR, BigIntegerD) 
            : RSA.EuclidExtended(BigIntegerD, BigIntegerFunctionR);
        
        BigIntegerE = extendedEuclidResult.y1;

        if (BigIntegerE < 0)
        {
            BigIntegerE += BigIntegerFunctionR;
        }

        TextBoxE.Text = BigIntegerE.ToString();

        ResultButton.Enabled = true;
    }

    void ClearStrip_Click(object sender, EventArgs e)
    {
        TextBoxR.Clear();
        TextBoxEuler.Clear();
        TextBoxE.Clear();
        PlainText.Clear();
        ResultButton.Enabled = false;
        TextBoxHash.Clear();
        TextBoxEDS.Clear();
    }


    void ResultButton_Click(object sender, EventArgs e)
    {
        /* if (PlainText.Text.Length == 0)
         {
             MessageBox.Show("Длина вашего текста должна быть отлична от нуля. Попробуйте открыть файл!",
                 "Внимание");
             return;
         } */

        if (RadioButtonCreate.Checked)
        {
            if (OpenedFileBytes == null || OpenedFileBytes.Length == 0)
            {
                HashFunction = 100;
                TextBoxHash.Text = HashFunction.ToString();
                EdsValue = RSA.QuickPowerMod(HashFunction, BigIntegerD, BigIntegerR);
                TextBoxEDS.Text = EdsValue.ToString();
                SaveToFile.Enabled = true;
                // Если файл пустой, записываем пустую строку, а затем значение из TextBoxEDS.Text
                //File.WriteAllText(OpenFileDialog.FileName, Environment.NewLine + TextBoxEDS.Text);
            }
            else
            {
                // Если файл не пустой, вычисляем хэш
                HashFunction = EDS.HashFunction(OpenedFileBytes, BigIntegerR);
                TextBoxHash.Text = HashFunction.ToString();
                EdsValue = RSA.QuickPowerMod(HashFunction, BigIntegerD, BigIntegerR);
                TextBoxEDS.Text = EdsValue.ToString();
                SaveToFile.Enabled = true;
            }
        }

        if (RadioButtonCheck.Checked)
        {
            /*if (OpenedFileBytes.Length == 0)
            {
                MessageBox.Show("Сначала откройте файл с проверяемым текстом!", "Внимание");
                return;
            }*/

            // Читаем все строки из файла
            string[] lines = PlainText.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length == 0)
            {
                MessageBox.Show("There is no text to check the sign!", "Warning");
                return;
            }

            // Берем последнюю строку из файла и пытаемся преобразовать ее в подпись
            try
            {
                EdsValue = BigInteger.Parse(lines.Last());
                TextBoxEDS.Text = EdsValue.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Problem with reading the sign!", "Warning");
                return;
            }

            // Вычисляем хэш для всего содержимого файла без последней строки (подписи)
            string textWithoutSignature = string.Join(Environment.NewLine, lines.Take(lines.Length - 1));
            byte[] fileBytesWithoutSignature = Encoding.UTF8.GetBytes(textWithoutSignature);
            if (fileBytesWithoutSignature.Length > 0)
            {
                HashFunction = EDS.HashFunction(fileBytesWithoutSignature, BigIntegerR);
            }
            else
            {
                HashFunction = 100;
            }
            TextBoxHash.Text = HashFunction.ToString();

            // Проверяем подпись
            var temp = RSA.QuickPowerMod(EdsValue, BigIntegerE, BigIntegerR);
            string result = temp != HashFunction ? "Sign is not valid!" : "Sign is valid!";
            MessageBox.Show($"Hash of the given text: {HashFunction}{Environment.NewLine}" +
                            $"Hash calculated by the sign: {temp}{Environment.NewLine}" +
                            $"{result}");
        }


    }
    void OpenFilePlain_Click(object sender, EventArgs e)
    {
        if (OpenFileDialog.ShowDialog() != DialogResult.Cancel)
        {
            PlainText.Text = File.ReadAllText(OpenFileDialog.FileName);
            OpenedFileBytes = Encoding.UTF8.GetBytes(PlainText.Text);
        }   
    }

    void SaveFilePlain_Click(object sender, EventArgs e)
    {
        if (SaveFileDialog.ShowDialog() != DialogResult.Cancel)
        {
            File.WriteAllText(SaveFileDialog.FileName, 
                PlainText.Text + Environment.NewLine + $"{TextBoxEDS.Text}");
        }
    }

    void RadioButton_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButtonCheck.Checked)
            SaveToFile.Enabled = false;
        PlainText.Clear();
        TextBoxHash.Clear();
    }

    private void ProgrammerStrip_Click(object sender, EventArgs e)
    {

    }

    private void MainForm_Load(object sender, EventArgs e)
    {

    }

    private void классToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Cool!",
               "Class");
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void ClearLines_Click(object sender, EventArgs e)
    {
        TextBoxR.Clear();
        TextBoxEuler.Clear();
        TextBoxE.Clear();
        PlainText.Clear();
        ResultButton.Enabled = false;
        TextBoxHash.Clear();
        TextBoxEDS.Clear();
    }

    private void LoadFromFile_Click(object sender, EventArgs e)
    {
        if (OpenFileDialog.ShowDialog() != DialogResult.Cancel)
        {
            PlainText.Text = File.ReadAllText(OpenFileDialog.FileName);
            OpenedFileBytes = Encoding.UTF8.GetBytes(PlainText.Text);
        }
    }

    private void SaveToFile_Click(object sender, EventArgs e)
    {
        if (SaveFileDialog.ShowDialog() != DialogResult.Cancel)
        {
            File.WriteAllText(SaveFileDialog.FileName,
                PlainText.Text + Environment.NewLine + $"{TextBoxEDS.Text}");
        }
    }
}