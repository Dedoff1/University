using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP1
{
    public class Rhombus : DisplayObject
    {
        private int initVelX, initVelY;
        private float timeNow;
        private PictureBox pictureBox;
        private static Random random = new Random();
        private double x1Start;
        private double y1Start;
        private double x2Start;
        private double y2Start;

        public Rhombus(double x1, double y1, double x2, double y2, int fillColorR, int fillColorG, int fillColorB, int borderColorR, int borderColorG, int borderColorB, int borderWidth, PictureBox pictureBox, int vel, int angle, int accelX, int accelY)
            : base(x1, y1, x2, y2, fillColorR, fillColorG, fillColorB, borderColorR, borderColorG, borderColorB, borderWidth, vel, angle, accelX, accelY)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.pictureBox = pictureBox;
            this.angle = angle;
            timeNow = 0;
            x1Start = x1;
            y1Start = y1;
            x2Start = x2;
            y2Start = y2;


            CalculateBoundingRectangle();
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            int width = (int)(x2 - x1);
            int height = (int)(y2 - y1);
            
            int midX = (int)x1 + width / 2;
            int midY = (int)y1 + height / 2;

            Point top = new Point(midX, (int)y1);
            Point right = new Point((int)x2, midY);
            Point bottom = new Point(midX, (int)(y2));
            Point left = new Point((int)(x1), midY);
            Color fillColor =Color.FromArgb(fillColorR, fillColorG, fillColorB);
            Color borderColor =Color.FromArgb(borderColorR, borderColorG, borderColorB);
            using (SolidBrush brush = new SolidBrush(fillColor))
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                g.FillPolygon(brush, new Point[] { top, right, bottom, left });
                g.DrawPolygon(pen, new Point[] { top, right, bottom, left });
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

            if (!pictureBox.ClientRectangle.Contains(new System.Drawing.Rectangle((int)x1, (int)y1, (int)(x2 - x1), (int)(y2 - y1))))
            {
                float width = (float)( x2 - x1);
                float height = (float)(y2 - y1);
                x1 = random.Next(0, pictureBox.ClientRectangle.Width - (int)width);
                y1 = random.Next(0, pictureBox.ClientRectangle.Height - (int)height);
                x2 = x1 + width;
                y2 = y1 + height;
                 
                 
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
