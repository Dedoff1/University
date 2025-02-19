using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.shape
{
    internal class Ellipse : DisplayObject
    {
        private System.Drawing.RectangleF shape;
        private float radiusX;
        private float radiusY;

        private void CreateEllipse()
        {
            shape = new System.Drawing.RectangleF(x+frameWidth, y+frameWidth, radiusX, radiusY);
        }

        public Ellipse(int radiusX, int radiusY, int posX, int posY, (byte, byte, byte) color, (byte, byte, byte) frameColor, int frameWidth) : base(posX, posY, color, frameColor, frameWidth)
        {
            this.radiusX = radiusX;
            this.radiusY = radiusY;

            CreateEllipse();
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
            fpx2 = (int)(x + shape.Width + 2 * frameWidth);
            fpy2 = (int)(y + shape.Height + 2 * frameWidth);
        }

        public override void updatePosition()
        {
            shape.Location = new Point(x + frameWidth, y + frameWidth);
        }
    }
}
