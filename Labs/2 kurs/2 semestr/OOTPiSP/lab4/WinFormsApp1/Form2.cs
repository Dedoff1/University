using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {

        public Form2(string text, string fontName, string type, int textSize, int height, int width, int frameW, int x, int y, int dX, int dY, (byte, byte, byte) color, (byte, byte, byte) borderColor, (byte, byte, byte) fontColor, string buttonName)
        {
            InitializeComponent();
            x -= 11;
            y -= 11;
            if (frameW != 0 )
            {
                x += 1;
                y += 1;
            }
            if (frameW % 2 != 0)
            {
                x += 1;
                y += 1;
            }
            textBoxName.Text = text;
            textBoxWidth.Text = Convert.ToString(width - 2 * frameW);
            textBoxHeight.Text = Convert.ToString(height - 2 * frameW);
            textBoxBorderSize.Text = Convert.ToString(frameW);
            textBoxTextSize.Text = Convert.ToString(textSize);
            comboBoxFont.SelectedIndex = comboBoxFont.FindStringExact(fontName);
            switch (type)
            {
                case "WinFormsApp1.shape.Rect": comboBoxFigure.SelectedIndex = 0; break;
                case "WinFormsApp1.shape.Square": comboBoxFigure.SelectedIndex = 1; break;
                case "WinFormsApp1.shape.Circle": comboBoxFigure.SelectedIndex = 2; break;
                case "WinFormsApp1.shape.Ellipse": comboBoxFigure.SelectedIndex = 3; break;
                case "WinFormsApp1.shape.Triangle": comboBoxFigure.SelectedIndex = 4; break;
            }
            textBoxdx.Visible = true;
            textBoxdy.Visible = true;
            textBoxdx.Text = Convert.ToString(dX);
            textBoxdy.Text = Convert.ToString(dY);
            textBoxX.Text = Convert.ToString(x);
            textBoxY.Text = Convert.ToString(y);
            //    MessageBox.Show(Convert.ToString(color.Item1));
            pictureBoxBorderColor.BackColor = Color.FromArgb(borderColor.Item1, borderColor.Item2, borderColor.Item3);
            pictureBoxMainColor.BackColor = Color.FromArgb(color.Item1, color.Item2, color.Item3);
            pictureBoxTextColor.BackColor = Color.FromArgb(fontColor.Item1, fontColor.Item2, fontColor.Item3);

            button1.Text = buttonName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                pictureBoxMainColor.BackColor = colorDialog1.Color;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog(this) == DialogResult.OK)
            {
                pictureBoxBorderColor.BackColor = colorDialog2.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog(this) == DialogResult.OK)
            {
                pictureBoxTextColor.BackColor = colorDialog2.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public int text7
        {
            get
            {
                int result;
                if (int.TryParse(textBoxTextSize.Text, out result))
                {
                    return result;
                }
                else
                {
                    // Обработка случаев, когда ввод некорректен
                    // Например, вы можете вернуть значение по умолчанию или вывести сообщение об ошибке
                    MessageBox.Show("Некорректный ввод в поле text7");
                    return 0; // или другое значение по умолчанию
                }
            }
        }

        public int text6
        {
            get { return Convert.ToInt32(textBoxBorderSize.Text); }
        }
        public int text5
        {
            get { return Convert.ToInt32(textBoxHeight.Text); }
        }

        public int text4
        {
            get { return Convert.ToInt32(textBoxWidth.Text); }
        }

        public int text3
        {
            get { return Convert.ToInt32(textBoxdy.Text); }
        }

        public int text2
        {
            get { return Convert.ToInt32(textBoxdx.Text); }
        }

        public string text1
        {
            get { return textBoxName.Text; }
        }

        public string text9
        {
            get { return textBoxY.Text; }
        }

        public string text8
        {
            get { return textBoxX.Text; }
        }
        public (byte, byte, byte) colorFrame
        {
            get { return (pictureBoxBorderColor.BackColor.R, pictureBoxBorderColor.BackColor.G, pictureBoxBorderColor.BackColor.B); }
        }

        public (byte, byte, byte) color
        {
            get { return (pictureBoxMainColor.BackColor.R, pictureBoxMainColor.BackColor.G, pictureBoxMainColor.BackColor.B); }
        }

        public (byte, byte, byte) textColor
        {
            get { return (pictureBoxTextColor.BackColor.R, pictureBoxTextColor.BackColor.G, pictureBoxTextColor.BackColor.B); }
        }

        public string font
        {
            get
            {
                switch (comboBoxFont.SelectedIndex)
                {
                    case 0: return "Arial";
                    case 1: return "Times New Roman";
                    case 2: return "Segoe UI";
                    default: return "Arial";
                }
            }
        }

        public int type
        {
            get
            {
                return (comboBoxFigure.SelectedIndex);
            }
        }
    }
}