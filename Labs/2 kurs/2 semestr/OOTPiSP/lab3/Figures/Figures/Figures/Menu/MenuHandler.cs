using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figures.Menu
{
    public partial class MenuHandler : Form
    {
        private int childFormNumber = 0;

        public int tR, tG, tB;

        public int fR, fG, fB;

        public int bR, bG, bB;

        public string text, textStyle;

        public int textSize;

        public int borderWidth;

        public int X, Y;

        public int dx, dy;

        System.Drawing.Color tmp1 = Color.Empty;
        System.Drawing.Color tmp2 = Color.Empty;
        System.Drawing.Color tmp3 = Color.Empty;

        public string objType;

        public int width, height;
        public bool clicked1Color = false;
        public bool clicked2Color = false;
        public bool clicked3Color = false;
        int minus = 0;

        private void Edit_Click(object sender, EventArgs e)
        {
            
            menuItem.frameObj.isFindNewObject = true;
            menuItem.isFindNewObject = true;
            menuItem.reservIndex = menuItem.index;
            ///////////////////
            text = inputText.Text;
            if (String.IsNullOrEmpty(text))
            {
                text = menuItem.text;
            }
///////////////////////////////
            textStyle = fontStyle.Text;
            if (String.IsNullOrEmpty(textStyle))
            {
                textStyle = menuItem.textStyle;
            }
///////////////////////////////
            if (String.IsNullOrEmpty(inputTextSize.Text))
            {
                textSize = menuItem.fontSize;
            }
            else
            {
                textSize = int.Parse(inputTextSize.Text);

                if (textSize == 0) textSize = 0;
            }
//////////////////////////////
            if (String.IsNullOrEmpty(inputBorderWidth.Text))
            {
                borderWidth = menuItem.borderThickness;
            }
            else
            {
                borderWidth = int.Parse(inputBorderWidth.Text);

                if (borderWidth == 0)
                {
                    bR = fR;
                    bG = fG;
                    bB = fB;
                }

            }

            objType = figureType.Text;

            if (String.IsNullOrEmpty(inputX.Text))
            {
                X = menuItem.x;
            }
            else
            {
                int.TryParse(inputX.Text, out X);

                if (X == 0) X = menuItem.x;
            }

            if (String.IsNullOrEmpty(inputY.Text))
            {
                Y = menuItem.y;
            }
            else
            {
                int.TryParse(inputY.Text, out Y);

                if (Y == 0) Y = menuItem.y;
            }

            if (String.IsNullOrEmpty(inputWidth.Text))
            {
                width = (int)(menuItem.frameObj.fFrameX - menuItem.frameObj.sFrameX);
            }
            else
            {
                int.TryParse(inputWidth.Text, out width);

                if (width == 0) width = (int)(menuItem.frameObj.fFrameX - menuItem.frameObj.sFrameX);
            }

            if (String.IsNullOrEmpty(inputHeight.Text))
            {
                height = (int)(menuItem.frameObj.fFrameY - menuItem.frameObj.sFrameY);
            }
            else
            {
                int.TryParse(inputHeight.Text, out height);

                if (height == 0) height = (int)(menuItem.frameObj.fFrameY - menuItem.frameObj.sFrameY);
            }

            if (String.IsNullOrEmpty(inputDx.Text))
            {
                dx = 0;
            }
            else
            {
                int.TryParse(inputDx.Text, out dx);
            }

            if (String.IsNullOrEmpty(inputDy.Text))
            {
                dy = 0;
            }
            else
            {
                int.TryParse(inputDy.Text, out dy);
            }
            
            menuItem.changeBorderColor(bR, bG, bB);
            

            menuItem.changeCoords(X, Y, dx, dy);
            menuItem.changeText(text, textStyle, textSize);
            string textt = text;
            Font font = new Font(textStyle, textSize);

            // Измерение ширины текста
            Size textSizes = TextRenderer.MeasureText(textt, font);

            menuItem.changeFillColor(fR, fG, fB);

            menuItem.changeTextColor(tR, tG, tB);


            menuItem.changeObject(objType);

            menuItem.changeBorderSize(borderWidth);

            // Ширина текста в пикселях
            int textWidth = textSizes.Width;

            int tmp = (int)(menuItem.frameObj.fFrameX - menuItem.frameObj.sFrameX);
            int tmpY = (int)(menuItem.frameObj.fFrameY - menuItem.frameObj.sFrameY);
            
            if ((int)(menuItem.frameObj.fFrameX - menuItem.frameObj.sFrameX) < textWidth+5 && menuItem.frameObj.isTurn == false)
            {
                int lack = textWidth - tmp + 15;
                int lackY = textWidth - tmpY + 15;
               
                if(menuItem.frameObj.isType == "square" || menuItem.frameObj.isType == "circle") 
                    
                    menuItem.resize(width + lack, height + lack);
                else if(menuItem.frameObj.isType == "triangle")
                    menuItem.resize(width + lackY + (int)(0.7*lackY), height +lackY);
                else
                {
                    menuItem.resize(width + lack, height);
                }

                menuItem.frameObj.isTurn = true;
            }
            else
            {
                if(menuItem.frameObj.isType == "square" || menuItem.frameObj.isType == "circle")
                   
                {
                    menuItem.resize(height, height);
                }
                else
                {
                    menuItem.resize(width, height);
                }

                menuItem.frameObj.isTurn = false;

            }

            menuItem.curDisplaceX = (int)menuItem.frameObj.fFrameX;
            menuItem.curDisplaseY = (int)menuItem.frameObj.fFrameY;

        }

        private void inputHeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bR = int.Parse(bTextBoxR.Text);
            bG = int.Parse(bTextBoxG.Text);
            bB = int.Parse(bTextBoxB.Text);

            bColorBox.BackColor = Color.FromArgb(bR,bG, bB);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fR = int.Parse(fTextBoxR.Text);
            fG = int.Parse(fTextBoxG.Text);
            fB = int.Parse(fTextBoxB.Text);

            fColorBox.BackColor = Color.FromArgb(fR, fG, fB);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tR = int.Parse(fontTextBoxR.Text);
            tG = int.Parse(fontTextBoxG.Text);
            tB = int.Parse(fontTextBoxB.Text);

            fontColorBox.BackColor = Color.FromArgb(tR, tG, tB);
        }

        private void fontColorBox_Click(object sender, EventArgs e)
        {

        }

        private void inputText_TextChanged(object sender, EventArgs e)
        {

        }

        private MenuItems menuItem;

        private void bColorBox_Click(object sender, EventArgs e)
        {

        }

        public MenuHandler(MenuItems menuItemd)
        {
            InitializeComponent();

            this.menuItem = menuItemd;
            this.bB = menuItem.frameObj.bB;
            this.bR = menuItem.frameObj.bR;
            this.bG = menuItem.frameObj.bG;

            ///////////////////////////////////
            inputText.Text = menuItem.text;
            inputTextSize.Text = menuItem.fontSize.ToString();
            fontStyle.Text = menuItem.textStyle;
            inputWidth.Text = (menuItem.frameObj.fFrameX - menuItem.frameObj.sFrameX).ToString();
            inputHeight.Text = (menuItem.frameObj.fFrameY - menuItem.frameObj.sFrameY).ToString();
            inputBorderWidth.Text = menuItem.frameObj.borderThickness.ToString();
           
            figureType.Text = menuItem.frameObj.isType;

            inputX.Text = menuItem.frameObj.sFrameX.ToString();
            inputY.Text = menuItem.frameObj.sFrameY.ToString();




            tB = menuItem.tB;
            tG = menuItem.tG;   
            tR = menuItem.tR;
            fB = menuItem.frameObj.fB;
            fG = menuItem.frameObj.fG;
            fR = menuItem.frameObj.fR;

            tmp1 = System.Drawing.Color.FromArgb(tR, tG, tB);
            tmp2 = System.Drawing.Color.FromArgb(fR, fG, fB);
            tmp3 = System.Drawing.Color.FromArgb(bR, bG, bB);


            bTextBoxR.Text = bR.ToString();
            bTextBoxG.Text = bG.ToString();
            bTextBoxB.Text = bB.ToString();

            fTextBoxR.Text = fR.ToString();
            fTextBoxG.Text = fG.ToString();
            fTextBoxB.Text = fB.ToString();

            fontTextBoxR.Text = tR.ToString();
            fontTextBoxG.Text = tG.ToString(); 
            fontTextBoxB.Text = tB.ToString();

            
         
            fontColorBox.BackColor = tmp1;
            fColorBox.BackColor = tmp2;
            bColorBox.BackColor = tmp3;

        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Окно " + childFormNumber++;
            childForm.Show();
        }

        private void MenuHandler_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



       
    }
}
