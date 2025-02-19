using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.shape
{
    abstract public class DisplayObject
    {
        public int x;
        public int y;
        public (byte, byte, byte) color;
        public (byte, byte, byte) frameColor;
        public int frameWidth;

        public int fpx1;
        public int fpy1;
        public int fpx2;
        public int fpy2;

        public float vX;
        public float vY;

        public float aX;
        public float aY;




        public DisplayObject(int posX, int posY, (byte, byte, byte) color, (byte, byte, byte) frameColor, int frameWidth)
        {
            x = posX;
            y = posY;
            this.color = color;
            this.frameColor = frameColor;
            this.frameWidth = frameWidth;
        }

        public void Move(float t)
        {
            x += (int)(t * (aX * t / 2 + vX));
            y += (int)(t * (aY * t / 2 + vY));

            vX += aX * t;
            vY += aY * t;
        }
        public DisplayObject() { }
        abstract public void Draw(Graphics bitmap);
        abstract public void calculateFrame();
        abstract public void updatePosition();
    }
}
