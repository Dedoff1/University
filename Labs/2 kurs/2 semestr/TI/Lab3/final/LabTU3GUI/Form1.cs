using LabTU3GUI;
using System.Numerics;
using System.Text;

namespace LabTU3GUI
{
    public partial class Form1 : Form
    {
        public static Files files = new Files();
        public static ElGamal gamal = new ElGamal();
        public static Check checkVal = new Check();
        public static byte[] data, decodedText;
        public static short[] codedText;
        public static int P, X, K, G;
        public static BigInteger Y;
        public static int[] gener;
        public static bool encrState;
        public static BigInteger calculateY(int g, int x, int p)
        {
            return BigInteger.ModPow(g, x, p);
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (CB2.SelectedIndex == 0)
            {
                try
                {
                    encrState = true;
                    rTBR.Text = "";
                    if (!getData()) encryptData();
                }
                catch
                {
                    MessageBox.Show("A Problem occured. Please check your data1.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                try
                {
                    encrState = false;
                    rTBR.Text = "";
                    if (!getData()) decryptData();
                }
                catch
                {
                    MessageBox.Show("A Problem occured. Please check your data2.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                P = Convert.ToInt32(rBP.Text);
                //       if (!checkVal.prime(P) || P > short.MaxValue || P <= Byte.MaxValue)
                if (false)
                {
                    MessageBox.Show("A Problem occured. Please check your data3.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    gener = checkVal.generators(P);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < gener.Length; i++)
                    {
                        sb.Append($"{gener[i]} ");
                    }
                    tBNum.Text = gener.Length.ToString();
                    rTBG.Text = "";
                    rTBG.AppendText(sb.ToString());
                }
            }
            catch
            {
                MessageBox.Show("A Problem occured. Please check your data4.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public bool getData()
        {
            try
            {
                bool check = false;
                bool error = false;
                P = Convert.ToInt32(rBP.Text);
                if (!checkVal.prime(P) || P > short.MaxValue || P <= Byte.MaxValue) error = true;
                if (encrState)
                {
                    G = Convert.ToInt32(tBG.Text);
                    int i = 0;
                    if (gener != null)
                    {
                        while (i < gener.Length || !check)
                        {
                            if (G == gener[i])
                            {
                                check = true;
                            }
                            i++;
                        }
                    }
                    else
                    {
                        error = true;
                    }
                }
                else
                {
                    check = true;
                }
                if (!check) error = true;
                X = Convert.ToInt32(tBX.Text);
                if (X <= 1 || X >= P - 1)
                {
                    error = true;
                }
                if (encrState)
                {
                    K = Convert.ToInt32(tBK.Text);
                    if (K <= 1 || K >= P - 1)
                    {
                        check = false;
                        error = true;
                    }
                    else
                    {
                        if (!checkVal.relPrime(K, P - 1))
                        {
                            check = false;
                            error = true;
                        }
                    }

                    Y = calculateY(G, X, P);
                    tBY.Text = Y.ToString();
                }
                if (error)
                {
                    MessageBox.Show("A Problem occured. Please check your data5.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return error;
            }
            catch
            {
                MessageBox.Show("A Problem occured. Please check your data6.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
        }

        public void encryptData()
        {
            try
            {
                decodedText = null;
                encrState = true;
                if (rTBT.Text != "")
                {
                    codedText = gamal.encrypt(G, K, P, Y, data);
                    StringBuilder s = new StringBuilder();

                    for (int i = 0; i < codedText.Length; i++)
                    {
                        s.Append($"{codedText[i]} ");
                    }
                    rTBR.Text = "";
                    rTBR.AppendText(s.ToString());
                }
            }
            catch
            {
                MessageBox.Show("A Problem occured. Please check your data7.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void decryptData()
        {
            try
            {
                codedText = null;
                encrState = false;
                if (rTBT.Text != "")
                {
                    decodedText = gamal.decrypt(P, X, data);
                    StringBuilder s = new StringBuilder();

                    for (int i = 0; i < decodedText.Length; i++)
                    {
                        s.Append($"{decodedText[i]} ");
                    }
                    rTBR.Text = "";
                    rTBR.AppendText(s.ToString());
                }
            }
            catch
            {
                MessageBox.Show("A Problem occured. Please check your data8.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public byte[] conShortToByte(short[] arr)
        {
            byte[] textDec = new byte[arr.Length * 2];
            for (int i = 0; i < arr.Length; i++)
            {
                textDec[2 * i] = (byte)(arr[i] >> 8);
                textDec[2 * i + 1] = (byte)(arr[i] & 255);
            }
            return textDec;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (oFD1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    data = files.readFile(oFD1.FileName);
                    StringBuilder s = new StringBuilder();

                    for (int i = 0; i < data.Length; i++)
                    {
                        s.Append($"{data[i]} ");
                    }
                    rTBT.Text = "";
                    rTBR.Text = "";
                    rTBT.AppendText(s.ToString());

                }
                catch
                {
                    MessageBox.Show("A Problem occured. Please check your data9.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sFD1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (codedText != null)
                    {
                        files.writeFile(sFD1.FileName, conShortToByte(codedText));
                    }
                    else if (decodedText != null)
                    {
                        files.writeFile(sFD1.FileName, decodedText);
                    }
                }
                catch
                {
                    MessageBox.Show("A Problem occured. Please check your data10.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void rBP_Click(object sender, EventArgs e)
        {
            rTBG.Text = "";
            tBNum.Text = "";
            gener = null;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            rTBT.Clear();
            rTBR.Clear();
        }

        private void CB2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}