using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP1
{
    public class DiagonalLine : DisplayObject
    {
        private PictureBox pictureBox; 
        private static Random random = new Random();
        private float timeNow;
        private double x1Start;
        private double y1Start;
        private double x2Start;
        private double y2Start;


        public DiagonalLine(double x1, double y1, double x2, double y2, int fillColorR, int fillColorG, int fillColorB, int borderColorR, int borderColorG, int borderColorB, int borderWidth, PictureBox pictureBox, int vel, int angle, int accelX, int accelY)
            : base(x1, y1, x2, y2, fillColorR, fillColorG, fillColorB, borderColorR, borderColorG, borderColorB, borderWidth, vel, angle, accelX, accelY)
        {
            this.x2 = x2;
            this.y2 = y2;
            this.pictureBox = pictureBox;
            this.vel = vel;
            this.angle = angle;
            timeNow = 0;
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
            using (Pen pen = new Pen(fillColor, borderWidth))
            {
                g.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
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

            if (!pictureBox.ClientRectangle.Contains(new System.Drawing.Rectangle((int)Math.Min(x1, x2), (int)Math.Min(y1, y2), (int)(x2 - x1), (int)(y2 - y1))))
            {
                float width = (float)(x2 - x1);
                float height = (float)(y2 - y1);
                x1 = random.Next(pictureBox.ClientRectangle.Width);
                y1 = random.Next(pictureBox.ClientRectangle.Height);
                x2 = x1 + width;
                y2 = y1 + height;

                 
                 
                time0 = DateTime.Now;
            }

            CalculateBoundingRectangle();

            pictureBox.Invalidate();
        }

        protected override void CalculateBoundingRectangle()
        {

            double topLeftX = Math.Min(x1, x2) - borderWidth;
            double topLeftY = Math.Min(y1, y2) - borderWidth;


            double boundingWidth = Math.Abs(x2 - x1) + borderWidth;
            double boundingHeight = Math.Abs(y2 - y1) + borderWidth;

            SetBoundingRectangle(topLeftX, topLeftY, boundingWidth, boundingHeight);
        }

    }
}
