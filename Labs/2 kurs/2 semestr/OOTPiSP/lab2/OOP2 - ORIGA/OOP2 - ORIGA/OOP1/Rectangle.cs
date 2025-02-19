using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP1
{
    public class Rectangle : DisplayObject
    {
        private int initVelX, initVelY;
        private PictureBox pictureBox; 
        private static Random random = new Random();
        private float timeNow;
        private float width, height;
        private double x1Start;
        private double y1Start;
        private double x2Start;
        private double y2Start;
        public Rectangle(double x1, double y1, double x2, double y2, int fillColorR, int fillColorG, int fillColorB, int borderColorR, int borderColorG, int borderColorB, int borderWidth, PictureBox pictureBox, int vel, int angle, int accelX, int accelY)
            : base(x1, y1, x2, y2, fillColorR, fillColorG, fillColorB, borderColorR, borderColorG, borderColorB, borderWidth, vel, angle, accelX, accelY)
        {
            this.width = (float)(x2 - x1);
            this.height = (float)(y2 - y1);
            this.pictureBox = pictureBox;
            

            CalculateBoundingRectangle();
            this.vel = vel;
            this.angle = angle;
            x1Start = x1;
            y1Start = y1;
            x2Start = x2;
            y2Start = y2;
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            Color fillColor = Color.FromArgb(fillColorR, fillColorG, fillColorB);
            Color borderColor = Color.FromArgb(borderColorR, borderColorG, borderColorB);
            using (SolidBrush brush = new SolidBrush(fillColor))
            {
                g.FillRectangle(brush, (float)x1, (float)y1, width, height);
            }
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                g.DrawRectangle(pen, (float)x1,(float) y1, width, height);
            }
        }

        protected override void ShiftCoords(double deltaX, double deltaY)
        {
            x1 = x1Start + deltaX;
            y1 = y1Start + deltaY;
            x2 = x2Start + deltaX;
            y2 = y2Start + deltaY;
            if (accelX == 0 && accelY == 0)
            {
                timeNow = 0;
            }
            if (!pictureBox.ClientRectangle.Contains(new System.Drawing.Rectangle((int)x1, (int)y1, (int)width, (int)height)))
            {

                x1 = random.Next((int)width, pictureBox.ClientRectangle.Width - (int)width);
                y1 = random.Next((int)height, pictureBox.ClientRectangle.Height - (int)height);

                 
                 
                time0 = DateTime.Now;
            }


            CalculateBoundingRectangle();

            pictureBox.Invalidate();
        }

        protected override void CalculateBoundingRectangle()
        {

            double topLeftX = x1 - borderWidth;
            double topLeftY = y1 - borderWidth;
            double boundingWidth = (x2 - x1) + borderWidth;
            double boundingHeight = (y2 - y1) + borderWidth;

            SetBoundingRectangle(topLeftX, topLeftY, boundingWidth, boundingHeight);
        }
    }
}
