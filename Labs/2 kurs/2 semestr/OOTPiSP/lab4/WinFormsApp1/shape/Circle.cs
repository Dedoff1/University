using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.shape
{
    internal class Circle:DisplayObject
    {
        private int radius;
        private Rectangle shape;

        public Circle(int diam, int posX, int posY, (byte, byte, byte) color, (byte, byte, byte) frameColor, int frameWidth) : base(posX, posY, color, frameColor, frameWidth)
        {
            this.radius = diam / 2;
            int diameter = diam;

            shape = new Rectangle(posX+frameWidth, posY+frameWidth, diameter, diameter);
            calculateFrame();
        }

        public override void Draw(Graphics bitmap)
        {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(color.Item1, color.Item2, color.Item3)))
                {
                    bitmap.FillEllipse(brush, shape.X - 1, shape.Y - 1, shape.Width + 2, shape.Height + 2);
                }
            if (frameWidth != 0)
            {
                using (Pen pen = new Pen(Color.FromArgb(frameColor.Item1, frameColor.Item2, frameColor.Item3), frameWidth))
                {
                    bitmap.DrawEllipse(pen, shape.X - frameWidth / 2, shape.Y - frameWidth / 2, shape.Width + frameWidth, shape.Height + frameWidth);
                }
            }
        }

        public override void calculateFrame()
        {
            fpx1 = x;
            fpy1 = y;
            fpx2 = x + shape.Width + 2 * frameWidth;
            fpy2 = y + shape.Height + 2 * frameWidth;
        }

        public override void updatePosition()
        {
            shape.Location = new Point(x + frameWidth, y + frameWidth);
        }
    }
}
