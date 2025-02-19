using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.shape
{
    internal class Triangle : DisplayObject
    {
        private System.Drawing.PointF[] points;
        private int sideLength;

        public Triangle(int sideLength, int left, int top, (byte, byte, byte) color, (byte, byte, byte) frameColor, int frameWidth) : base(left, top, color, frameColor, frameWidth)
        {
            this.sideLength = sideLength;
            CalculatePoints();
        }

        private void CalculatePoints()
        {
            points = new System.Drawing.PointF[3];

            float halfSide = sideLength / 2f;
            float centerX = x + halfSide;
            float centerY = y + (float)(sideLength * Math.Sqrt(3) / 2);

            points[0] = new System.Drawing.PointF(x, y + sideLength); // Левая нижняя вершина
            points[1] = new System.Drawing.PointF(centerX, y); // Верхняя вершина
            points[2] = new System.Drawing.PointF(x + sideLength, y + sideLength); // Правая нижняя вершина
            calculateFrame();
        }

        public override void Draw(Graphics bitmap)
        {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(color.Item1, color.Item2, color.Item3)))
                {
                    bitmap.FillPolygon(brush, points);
                }
            if (frameWidth != 0)
            {
                using (Pen pen = new Pen(Color.FromArgb(frameColor.Item1, frameColor.Item2, frameColor.Item3), frameWidth))
                {
                    bitmap.DrawPolygon(pen, points);
                }
            }
        }

        public override void calculateFrame()
        {
            float minX = points.Min(p => p.X);
            float minY = points.Min(p => p.Y);
            float maxX = points.Max(p => p.X);
            float maxY = points.Max(p => p.Y);

            fpx1 = (int)minX;
            fpy1 = (int)minY;
            fpx2 = (int)maxX;
            fpy2 = (int)maxY;
        }


        public override void updatePosition()
        {
            CalculatePoints();
        }
    }
}
