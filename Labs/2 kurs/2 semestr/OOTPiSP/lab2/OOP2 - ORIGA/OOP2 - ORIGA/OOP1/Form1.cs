using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OOP1
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private static Random random2 = new Random();
        private const int numberOfFigures = 10;
        private DisplayObject[] objects;
        private Bitmap buffer;

        public Form1()
        {

            InitializeComponent();
            timer1 = new Timer();
            checkBox1 = new CheckBox();
            checkBox1.Checked = false;
            timer1.Tick += timer1_Tick;

        }
    



        private void btnCreateAnchor_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            int x1 = int.Parse(txtAnchorX.Text);
            int y1 = int.Parse(txtAnchorY.Text);
            int x2 = int.Parse(txtAnchorX2.Text);
            int y2 = int.Parse(txtAnchorY2.Text);
            int vel = int.Parse(txtVel.Text);
            int angle = int.Parse(txtAngle.Text);
            int accelX = (int)(float.Parse(txtAccelX.Text));
            int accelY = (int)(float.Parse(txtAccelY.Text));
             selectionFillColorR = GetRandomColor();
             selectionFillColorG = GetRandomColor();
             selectionFillColorB = GetRandomColor();
             //selectionBorderColorR = GetRandomColor();
            // selectionBorderColorG = Green;
            //selectionBorderColorB = GetRandomColor();
            selectionBorderWidth = (int)GetRandomBorderWidth();


            int wf = this.Width;
            int hf = this.Height;
            // верхний левый угол
            //int x = x1;
            //int y = y1;

            // правый нижний угол
             int x = wf - (x2 - x1) - x1 - 9;
             int y = hf - (y2 - y1) - y1 - 31;

            // правый верхний угол
            //x = wf - (x2 - x1) - x1 - 16;
            //y = y1;

            // левый нижний угол
            //x = x1;
            //y = hf - (y2 - y1) - y1 - 38;
            pictureBox1.Location = new Point(x, y);
            pictureBox1.Size = new Size(x2 - x1, y2 - y1);

            ClearBuffer();
            DrawSelectionRectangle(pictureBox1.Width, pictureBox1.Height);
            DrawRandomFigures(x1, y1, x2, y2, pictureBox1.Width, pictureBox1.Height, vel, angle, accelX, accelY);

            pictureBox1.Image = buffer;
        }
       
        private void ClearBuffer()
        {
          
            buffer?.Dispose();

            
            buffer = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private int selectionFillColorR, selectionFillColorG, selectionFillColorB, Red, Blue, Green;
        private int selectionBorderWidth= 10;

        private void DrawSelectionRectangle(int pictureBoxWidth, int pictureBoxHeight)
        {
           

            using (Graphics g = Graphics.FromImage(buffer))
            {
                GameField selectionRectangle = new GameField(0, 0, pictureBoxWidth, pictureBoxHeight, selectionFillColorR, selectionFillColorG, Red, Green, Blue, 350,10);
                selectionRectangle.Draw(g);
            }
        }

        private void DrawRandomFigures(int x1, int y1, int x2, int y2, int pictureBoxWidth, int pictureBoxHeight, int vel, int angle, int accelX, int accelY)
        {
            using (Graphics g = Graphics.FromImage(buffer))
            {
                objects = new DisplayObject[numberOfFigures * 8];
                int accelXs = accelX;
                int accelYs = accelY;

                for (int i = 0; i < numberOfFigures; i++)
                {
                    int index = i * 8;
                    for (int j = 0; j < 8; j++)
                    {

                        int figureWidth = random.Next((x2 - x1) / 15, (x2 - x1) / 4);
                        int figureHeight = random.Next((y2 - y1) / 10, (y2 - y1) / 3);
                        int figureX = random.Next(0, pictureBoxWidth);
                        int figureY = random.Next(0, pictureBoxHeight);
                        if (checkBox1.Checked)
                        {
                            accelX = random2.Next(-(int)accelXs, (int)accelXs);
                            accelY = random2.Next(-(int)accelYs, (int)accelYs);
                        }

                        int borderWidth = GetRandomBorderWidth();

                        if (figureX + figureWidth >= x2 - x1 - 10)
                        {
                            while (figureX + figureWidth >= x2 - x1 - 10)
                            {
                                figureX--;
                            }
                            figureWidth = figureWidth - 15 - (int)borderWidth;
                        }
                        if (figureX - figureWidth <= 10)
                        {
                            while (figureX - figureWidth <= 10)
                            {
                                figureX++;
                            }
                            figureWidth = figureWidth + 15 + (int)borderWidth;
                        }
                        if (figureY + figureHeight > y2 - y1 - 10)
                        {
                            while (figureY + figureHeight > y2 - y1 - 10)
                            {
                                figureY--;
                            }
                            figureHeight = figureHeight - 15 - (int)borderWidth;
                        }
                        if (figureY - figureHeight <= 10)
                        {
                            while (figureY - figureHeight <= 10)
                            {
                                figureY++;
                            }
                            figureHeight = figureHeight + 15 + (int)borderWidth;
                        }

                        switch (j)
                        {
                            case 0:
                                objects[index + j] = new Circle(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                                break;
                            case 1:
                                objects[index + j] = new Triangle(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                                break;
                            case 2:
                                objects[index + j] = new Rectangle(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                                break;
                            case 3:
                                objects[index + j] = new Oval(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                                break;
                            case 4:
                                objects[index + j] = new DiagonalLine(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                                break;
                            case 5:
                                objects[index + j] = new Square(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                                break;
                            case 6:
                                objects[index + j] = new Rhombus(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                                break;
                            case 7:
                                objects[index + j] = new InvertedTriangle(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1,vel, angle, accelX, accelY);
                                break;
                        }

                    }
                }

                foreach (DisplayObject obj in objects)
                {
                    obj.Draw(g);
                }
            }
        }
        private void UpdateAndRedrawFigures(float deltaTime)
        {
            foreach (DisplayObject obj in objects)
            {
                obj.Move();
            }

            ClearBuffer();
            DrawSelectionRectangle(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(buffer))
            {
                foreach (DisplayObject obj in objects)
                {
                    obj.Draw(g);
                }
            }

            pictureBox1.Image = buffer;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!float.TryParse(textBox1.Text, out float inputValue) || inputValue <= 0)
            {
                MessageBox.Show("Введите положительное число в textBox1.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            timer1.Interval = 1000 / (int)inputValue;
            float deltaTime = 1f / inputValue; 
            UpdateAndRedrawFigures(deltaTime);
        }

        private int GetRandomColor()
        {
            return random.Next(0,255);
        }

        private int GetRandomBorderWidth()
        {
            return random.Next(1, 5);
        }

        private void txtAnchorX_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAnchorY_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private bool isTimerRunning = false;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int inputValue) || inputValue <= 0)
            {
                MessageBox.Show("Пожалуйста, введите положительное целое число в textBox1.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            timer1.Stop();
            if (isTimerRunning)
            {
                timer1.Stop();
                isTimerRunning = false;
            }
            else
            {
                isTimerRunning = true;
                timer1.Interval = 1000 / inputValue;

            timer1.Start();
            }
            foreach (DisplayObject obj in objects)
            {
                obj.time0 = DateTime.Now;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox1.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void DeleteAllFigures()
        {
            objects = new DisplayObject[0];

            // Очистка PictureBox
            pictureBox1.Controls.Clear();
            pictureBox1.Invalidate(); // Добавляем перерисовку
        }

        private void btnManageFigures_Click(object sender, EventArgs e)
        {
            ManageFiguresDialog manageFiguresDialog = new ManageFiguresDialog(objects, this);
            manageFiguresDialog.ShowDialog();
            pictureBox1.Image = buffer;
        }
        public void DeleteFiguresByType(string figureType)
        {
            if (objects != null && objects.Length > 0)
            {
                List<DisplayObject> updatedObjects = new List<DisplayObject>();

                foreach (DisplayObject obj in objects)
                {
                    if (obj.GetType().Name != figureType)
                    {
                        updatedObjects.Add(obj);
                    }
                }

                objects = updatedObjects.ToArray();



                // Перерисовываем фигуры
                RedrawFigures();
            }

        }
        public void AddFigure(string figureType, int vel,int x1, int y1, int x2, int y2 ,int angle, int accelX, int accelY)
        {
            
            accelX = (int)(accelX);
            accelY = (int)(accelY);
            int accelXs = accelX;
            int accelYs = accelY;
            int pictureBoxWidth = pictureBox1.Width;
            int pictureBoxHeight = pictureBox1.Height;
            //int figureX = pictureBox1.Width - x2 -x1;
            //int figureY = pictureBox1.Height - y2 -y1;
            int figureWidth = x2-x1;
            int figureHeight = y2-y1;
            int figureX = x1;
            int figureY = y1;
            if (checkBox1.Checked)
            {
                accelX = random2.Next(-(int)accelXs, (int)accelXs);
                accelY = random2.Next(-(int)accelYs, (int)accelYs);
            }

            int borderWidth = GetRandomBorderWidth();


            DisplayObject newObject = null;

            switch (figureType)
            {
                case "Circle":
                    newObject = new Circle(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                    break;
                case "Triangle":
                    newObject = new Triangle(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                    break;
                case "Rectangle":
                    newObject = new Rectangle(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                    break;
                case "Oval":
                    newObject = new Oval(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                    break;
                case "Rhombus":
                    newObject = new Rhombus(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                    break;
                case "Square":
                    newObject = new Square(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                    break;
                case "DiagonalLine":
                    newObject = new DiagonalLine(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                    break;
                case "InvertedTriangle":
                    newObject = new InvertedTriangle(figureX, figureY, figureX + figureWidth, figureY + figureHeight, GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), GetRandomColor(), borderWidth, pictureBox1, vel, angle, accelX, accelY);
                    break;
            }

            if (newObject != null)
            {
                Array.Resize(ref objects, objects.Length + 1);
                objects[objects.Length - 1] = newObject;

                // Перерисовываем фигуры
                RedrawFigures();
            }
        }
        private void RedrawFigures()
        {

            using (Graphics g = Graphics.FromImage(buffer))
            { if (objects != null)
                {
                    pictureBox1.Visible = true;
                    foreach (DisplayObject obj in objects)
                    {
                        obj.Draw(g);
                    }
                }
                else { pictureBox1.Visible = false; }
            }

            pictureBox1.Image = buffer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToggleVisibility(label2);
            ToggleVisibility(label1);
            ToggleVisibility(label3);
            ToggleVisibility(label4);
            ToggleVisibility(label5);
            ToggleVisibility(label6);
            ToggleVisibility(label7);
            ToggleVisibility(label8);
            ToggleVisibility(label9);
            ToggleVisibility(label10);
            ToggleVisibility(btnCreateAnchor);
            ToggleVisibility(btnManageFigures);
            ToggleVisibility(btnUpdate);
            ToggleVisibility(txtVel);
            ToggleVisibility(txtAccelX);
            ToggleVisibility(txtAccelY);
            ToggleVisibility(txtAnchorX);
            ToggleVisibility(txtAnchorX2);
            ToggleVisibility(txtAnchorY);
            ToggleVisibility(txtAnchorY2);
            ToggleVisibility(textBox1);
            ToggleVisibility(txtAngle);
            ToggleVisibility(checkBox1);

        }

        private void ToggleVisibility(Control control)
        {
            control.Visible = !control.Visible;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int x1 = int.Parse(txtAnchorX.Text);
            int y1 = int.Parse(txtAnchorY.Text);
            int x2 = int.Parse(txtAnchorX2.Text);
            int y2 = int.Parse(txtAnchorY2.Text);
            int vel = int.Parse(txtVel.Text);
            int angle = int.Parse(txtAngle.Text);
            int accelX = (int)(float.Parse(txtAccelX.Text));
            int accelY = (int)(float.Parse(txtAccelY.Text));


            int wf = this.Width;
            int hf = this.Height;
            // верхний левый угол
            // x = x1;
            // y = y1;

            // правый нижний угол
            int x = wf - (x2 - x1) - x1 - 9;
            int y = hf - (y2 - y1) - y1 - 31;

            // правый верхний угол
            //int x = wf - (x2 - x1) - x1 - 16;
            //int y = y1;

            // левый нижний угол
            //int x = x1;
            //int y = hf - (y2 - y1) - y1 - 38;
            pictureBox1.Location = new Point(x, y);
            pictureBox1.Size = new Size(x2 - x1, y2 - y1);

            ClearBuffer();
            DrawSelectionRectangle(pictureBox1.Width, pictureBox1.Height);
            RedrawFigures();

            pictureBox1.Image = buffer;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}