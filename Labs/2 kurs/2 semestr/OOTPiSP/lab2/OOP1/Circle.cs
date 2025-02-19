using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP1
{
    public class Circle : DisplayObject
    {
        private double radius;
        private PictureBox pictureBox; 
        private static Random random = new Random();
        private float timeNow;
        private double x1Start;
        private double y1Start;
        private double x2Start;
        private double y2Start;
        public Circle(double x1, double y1, double x2, double y2, int fillColorR, int fillColorG, int fillColorB, int borderColorR, int borderColorG, int borderColorB, int borderWidth, PictureBox pictureBox, int vel, int angle, int accelX, int accelY)
            : base(x1, y1, x2, y2, fillColorR, fillColorG, fillColorB, borderColorR, borderColorG, borderColorB, borderWidth, vel, angle, accelX, accelY)
        {
            this.radius = Math.Min(x2 - x1, y2 - y1) / 2;
            this.pictureBox = pictureBox;
            x1Start = x1;
            y1Start = y1;
            x2Start = x2;
            y2Start = y2;
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            float topLeftX = (float)(x1 - radius);
            float topLeftY = (float)(y1 - radius);
            Color fillColor = Color.FromArgb(fillColorR, fillColorG, fillColorB);
            Color borderColor = Color.FromArgb(borderColorR, borderColorG, borderColorB);
            using (SolidBrush brush = new SolidBrush(fillColor))
            {
                g.FillEllipse(brush, topLeftX, topLeftY, (float)radius * 2,(float) radius * 2);
            }
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                g.DrawEllipse(pen, topLeftX, topLeftY, (float)radius * 2, (float)radius * 2);
            }
            
        }

        protected override void ShiftCoords(double deltaX, double deltaY)
        {
            x1 = x1Start + deltaX;
            y1 = y1Start + deltaY;
            x2 = x2Start + deltaX;
            y2 = y2Start + deltaY;


            if (!pictureBox.ClientRectangle.Contains(new System.Drawing.Rectangle((int)(x1 - radius+10), (int)(y1 - radius-10), (int)(radius * 2), (int)(radius * 2))))
            {
                
                x1 = random.Next((int)(radius), (int)(pictureBox.ClientRectangle.Width - radius));
                y1 = random.Next((int)(radius), (int)(pictureBox.ClientRectangle.Height - radius));
                x2 = x1 + radius*2;
                y2 = x1 + radius*2;
                 
                 
                time0 = DateTime.Now;
            }

            
            CalculateBoundingRectangle();

            pictureBox.Invalidate();
        }


        protected override void CalculateBoundingRectangle()
        {
            double diameter = Math.Min(x2 - x1, y2 - y1) + borderWidth;

            double topLeftX = x1 + (x2 - x1 - diameter) / 2 - borderWidth;
            double topLeftY = y1 + (y2 - y1 - diameter) / 2 - borderWidth;



            SetBoundingRectangle(topLeftX, topLeftY, topLeftX+diameter, topLeftY+diameter);
        }
    }
}
