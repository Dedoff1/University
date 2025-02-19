using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP1
{
    public class InvertedTriangle : DisplayObject
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

        public InvertedTriangle(double x1, double y1, double x2, double y2, int fillColorR, int fillColorG, int fillColorB, int borderColorR, int borderColorG, int borderColorB, int borderWidth, PictureBox pictureBox, int vel, int angle, int accelX, int accelY)
            : base(x1, y1, x2, y2, fillColorR, fillColorG, fillColorB, borderColorR, borderColorG, borderColorB, borderWidth, vel, angle, accelX, accelY)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = (float)(x1 + (x2 - x1) / 2);
            this.y3 = (float)(y1 + (y2 - y1));
            CalculateBoundingRectangle();
            this.pictureBox = pictureBox;
            this.vel = vel;
            this.angle = angle;
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
                g.FillPolygon(brush, new[] { new Point((int)x1, (int)y1), new Point((int)x1 + (int)(x2 - x1), (int)y1), new Point((int)x3, (int)y3) });
            }
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                g.DrawPolygon(pen, new[] { new Point((int)x1, (int)y1), new Point((int)x1 + (int)(x2 - x1), (int)y1), new Point((int)x3, (int)y3) });
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
            if (!pictureBox.ClientRectangle.Contains(new System.Drawing.Rectangle((int)x1, (int)y1, (int)(x2 - x1), (int)(y3 - y1))))
            {
                float width = (float)(x2 - x1);
                float height = (float)(y3 - y1);
                x1 = random.Next(pictureBox.ClientRectangle.Width - (int)width);
                y1 = random.Next(pictureBox.ClientRectangle.Height - (int)height);
                x2 = x1 + width;
                y2 = y1;
                x3 = (float)(x1 + width / 2);
                y3 = (float)(y1 + height);


                 
                 
                time0 = DateTime.Now;
            }

            CalculateBoundingRectangle();

            pictureBox.Invalidate();
        }

        protected override void CalculateBoundingRectangle()
        {
            double topLeftX = Math.Min(x1, x1 + (x2 - x1) / 2) - borderWidth;
            double topLeftY = Math.Min(y1, y1 + (y2 - y1)) - borderWidth;

            double boundingWidth = Math.Abs((x2 - x1)) + borderWidth;
            double boundingHeight = Math.Abs((y2 - y1)) + borderWidth;

            SetBoundingRectangle(topLeftX, topLeftY, boundingWidth, boundingHeight);
        }
    }
}
