using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.shape
{
    internal class GameField : DisplayObject
    {
        private System.Drawing.Rectangle shape;

        public int clientX1 { get => x+frameWidth; }
        public int clientX2 { get => x+frameWidth+shape.Width; }
        public int clientY1 { get => y+frameWidth; }
        public int clientY2 { get => y + frameWidth+shape.Height; }

        public GameField(int height, int width, int posX, int posY, (byte, byte, byte) color, (byte, byte, byte) frameColor, int frameWidth) : base(posX, posY, color, frameColor, frameWidth)
        {
            shape = new Rectangle(x + frameWidth, y + frameWidth, width, height);
            calculateFrame();
        }

        public override void Draw(Graphics bitmap)
        {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(color.Item1, color.Item2, color.Item3)))
                {
                    bitmap.FillRectangle(brush, shape.X-1, shape.Y-1, shape.Width+2, shape.Height+2);
                }

                using (Pen pen = new Pen(Color.FromArgb(frameColor.Item1, frameColor.Item2, frameColor.Item3), frameWidth))
                {
                    bitmap.DrawRectangle(pen, shape.X - frameWidth / 2, shape.Y - frameWidth / 2, shape.Width + frameWidth, shape.Height + frameWidth);
                }
        }

        public override void updatePosition()
        {
            shape.Location = new Point(x+frameWidth, y + frameWidth);
        }

        public override void calculateFrame()
        {
            fpx1 = x + 10;
            fpy1 = y + 10;
            fpx2 = x + shape.Width + 2 * frameWidth - 10;
            fpy2 = y + shape.Height + 2 * frameWidth - 10;
        }
    }

}
