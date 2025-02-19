using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP1
{
    public class Triangle : DisplayObject
    {
        private double  x3, y3;
        private int initVelX, initVelY;
        private PictureBox pictureBox;
        private static Random random = new Random();
        private float timeNow;
        private double x1Start;
        private double y1Start;
        private double x2Start;
        private double y2Start;
        private double x3Start;
        private double y3Start;


        public Triangle(double x1, double y1, double x2, double y2, int fillColorR, int fillColorG, int fillColorB, int borderColorR, int borderColorG, int borderColorB, int borderWidth, PictureBox pictureBox, int vel, int angle, int accelX, int accelY)
            : base(x1, y1, x2, y2, fillColorR, fillColorG, fillColorB, borderColorR, borderColorG, borderColorB, borderWidth, vel, angle, accelX, accelY)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = (float)( x1 + (x2 - x1) / 2);
            this.y3 = (float)y1;
            this.pictureBox = pictureBox;
            this.vel = vel;
            this.angle = angle;
            CalculateBoundingRectangle();
            x1Start = x1;
            y1Start = y1;
            x2Start = x2;
            y2Start = y2;
            x3Start = x3;
            y3Start = y3;
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            Color fillColor = Color.FromArgb(fillColorR, fillColorG, fillColorB);
            Color borderColor = Color.FromArgb(borderColorR, borderColorG, borderColorB);
            using (SolidBrush brush = new SolidBrush(fillColor))
            {
                g.FillPolygon(brush, new[] { new Point((int)x1, (int)y2), new Point((int)x3, (int)y1), new Point((int)x2, (int)y2) });
            }
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                g.DrawPolygon(pen, new[] { new Point((int)x1, (int)y2), new Point((int)x3, (int)y1), new Point((int)x2, (int)y2) });
            }
        }

        protected override void ShiftCoords(double deltaX, double deltaY)
        {
            x1 = x1Start + deltaX;
            y1 = y1Start + deltaY;
            x2 = x2Start + deltaX;
            y2 = y2Start + deltaY;
            x3 = x3Start + deltaX;
            y3 = y3Start + deltaY;
            if (accelX == 0 && accelY == 0)
            {
                timeNow = 0;
            }

            if (!pictureBox.ClientRectangle.Contains(new System.Drawing.Rectangle(Math.Min((int)x1, Math.Min((int)x2, (int)x3)), Math.Min((int)y1, Math.Min((int)y2, (int)y3)), (int)x2 - (int)x1, (int)y2 - (int)y1)))
            {
                float width = (float)(x2 - x1);
                float height = (float)(y2 - y1);
                x1 = random.Next(pictureBox.ClientRectangle.Width);
                y1 = random.Next(pictureBox.ClientRectangle.Height);
                x2 = x1 + width;
                y2 = y1 + height;
                x3 = (float)(x1 + width / 2);
                y3 = (float)y1;

                 
                 
                time0 = DateTime.Now;
            }
           

            CalculateBoundingRectangle();
        }

        protected override void CalculateBoundingRectangle()
        {
            double lowestX = Math.Min(x1, Math.Min(x2, x3)) - borderWidth;
            double lowestY = Math.Min(y1, Math.Min(y2, y3)) - borderWidth;
            double highestX = Math.Max(x1, Math.Max(x2, x3));
            double highestY = Math.Max(y1, Math.Max(y2, y3));

            double width = highestX - lowestX + borderWidth;
            double height = highestY - lowestY + borderWidth;


            SetBoundingRectangle(lowestX, lowestY, width, height);
        }
    }
}
