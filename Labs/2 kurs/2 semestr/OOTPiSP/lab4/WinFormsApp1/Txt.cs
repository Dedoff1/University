using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.shape;

namespace WinFormsApp1
{
    internal class Txt : DisplayObject
    {
        public string textStr;  // Строка текста
        public System.Drawing.Font font;  // Шрифт
        public int fontSize;  // Размер шрифта

        


        public Txt(string str, int posX, int posY, (byte, byte, byte) color, System.Drawing.Font font, int fontSize)
        {
            x = posX; y = posY;
            textStr = str;
            this.font = font;
            this.fontSize = fontSize;
            this.color = color;
            calculateFrame();
        }

        public override void calculateFrame()
        {
            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
            {
                SizeF textSize = graphics.MeasureString(textStr, font);
                fpx1 = x;
                fpy1 = y;
                fpx2 = (int)(x + textSize.Width);
                fpy2 = (int)(y + textSize.Height);
            }
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(System.Drawing.Color.FromArgb(color.Item1, color.Item2, color.Item3)))
            {
                //frameColor.Item1, frameColor.Item2, frameColor.Item3
              
                using (Pen pen = new Pen(System.Drawing.Color.FromArgb(color.Item1, color.Item2, color.Item3), frameWidth))
                {
                    g.DrawString(textStr, font, brush, x, y);
                    //g.DrawRectangle(pen, x, y, fpx2 - fpx1, fpy2 - fpy1);
                }
            }
        }

        public override void updatePosition()
        {
            calculateFrame();
        }
    }

}
