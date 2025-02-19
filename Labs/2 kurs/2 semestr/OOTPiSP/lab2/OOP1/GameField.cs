using System;
using System.Drawing;

namespace OOP1
{
    public class GameField : DisplayObject
    {
        private DisplayObject[] _displayObjects = new DisplayObject[80];
        private int _p = 0;

        public GameField(int x1, int y1, int x2, int y2, int fillColorR, int fillColorG, int fillColorB, int borderColorR, int borderColorG, int borderColorB, int borderWidth)
            : base(x1, y1, x2, y2, fillColorR, fillColorG, fillColorB, borderColorR, borderColorG, borderColorB, borderWidth)
        {
        }

        public DisplayObject[] CreateArray(int Len)
        {
            DisplayObject[] array = new DisplayObject[Len];
            return array;
        }
        protected override void ShiftCoords(double deltaX, double deltaY)
        {
        }
        public void Add(DisplayObject o)
        {

            _displayObjects[_p++] = o;
        }

        public void Delete(DisplayObject o)
        {
            int indexToRemove = Array.IndexOf(_displayObjects, o);
            for (int i = indexToRemove; i < _displayObjects.Length - 1; i++)
                _displayObjects[i] = _displayObjects[i + 1];
            _p--;
        }
        public override void Draw(Graphics g)
        {
            base.Draw(g);
            Color fillColor = Color.FromArgb(fillColorR, fillColorG, fillColorB);
            Color borderColor = Color.White;//Color.FromArgb(borderColorR, borderColorG, borderColorB);
            using (SolidBrush brush = new SolidBrush(fillColor))
            {
                g.FillRectangle(brush, (float)x1, (float)y1, (float)(x2 - x1), (float)(y2 - y1));
            }

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                g.DrawRectangle(pen, (float)x1, (float)y1, (float)(x2 - x1) -borderWidth/3, (float)(y2 - y1) -borderWidth / 3);
            }
        }
        protected override void CalculateBoundingRectangle()
        {

            int topLeftX = (int)x1 - borderWidth;
            int topLeftY = (int)y1 - borderWidth;
            int boundingWidth = (int)(x2 - x1) + borderWidth;
            int boundingHeight = (int)(y2 - y1) + borderWidth;

            SetBoundingRectangle(topLeftX, topLeftY, boundingWidth, boundingHeight);
        }

    }
}
