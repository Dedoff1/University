using Figures.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figures.Menu
{
    public class MenuItems : DisplayObject
    {
        
        public string text;

        public int fontSize;

        public string textStyle = "Arial";
        public bool flag;

        public int x;
        public int y;

        public int FF = 0;

        public int tR, tG, tB;

        public DisplayObject frameObj;
        public DisplayObject ReservObj;

        public int index, parentIndex = 0;
        public int submenuCount = 0;
        public int reservIndex = 0;
        

        public MenuItems[] subMenuItems = new MenuItems[0];

        public bool isParent = true;
        public bool is2Parent = false;
        public int menu;

        public int curDisplace = 70;
        public int curDisplaceX = 0;
        public int curDisplaseY = 0;

      
        

        public bool isVisible = true;

        private GameField _gameField;

        public MenuItems(int x, int y, int fontSize, string text, string textStyle, int tR, int tG, int tB, DisplayObject frameObj, int index, GameField gameField)
        {
            this.frameObj = frameObj;

            this.x = x;
            this.y = y;

            this.text = text;
            this.tR = tR;
            this.tG = tG;
            this.tB = tB;

            this.index = index;

            this.fontSize = fontSize;

            _gameField = gameField;
        }

        public override void Draw(Graphics graphics)
        {
            frameObj.Draw(graphics);
        }

        public override void DrawText(Graphics graphics)
        {
            using (Font myFont = new Font(textStyle, fontSize))
            {
                Brush brush = new SolidBrush(Color.FromArgb(tR, tG, tB));
                SizeF textSize = graphics.MeasureString(text, myFont);
                frameObj.widthText =(int)textSize.Width;
                frameObj.heightText = (int)textSize.Height;

                if (frameObj.isTurn && frameObj.isType == "circle")
                    graphics.DrawString(text, myFont, brush, new PointF(centerTextX(), centerTextY()));
                else
               if (frameObj.isTurn && frameObj.isType == "square")
                    graphics.DrawString(text, myFont, brush, new PointF(centerTextX(), centerTextY()));
                else
               if (frameObj.isTurn && frameObj.isType == "triangle")
                    graphics.DrawString(text, myFont, brush, new PointF(centerTextX(), centerTextY()));
                else
                if (frameObj.isTurn && frameObj.isType =="rectangle")
                    graphics.DrawString(text, myFont, brush, new PointF(centerTextX() , centerTextY()));
                else
                if (frameObj.isTurn && frameObj.isType == "ellipse")
                    graphics.DrawString(text, myFont, brush, new PointF(centerTextX(), centerTextY()));
                else
                
                {
                    graphics.DrawString(text, myFont, brush, new PointF(centerTextX(), centerTextY()));
                }
            }
        }

        private int centerTextX()
        {
            if (frameObj.isType == "ellipse")
            {
                return (int)((frameObj.fFrameX - frameObj.sFrameX - frameObj.widthText) / 2 + frameObj.sFrameX + 
                    (int)((frameObj.fFrameX - frameObj.sFrameX) * 0.065));
            }

            return (int)((frameObj.fFrameX - frameObj.sFrameX - frameObj.widthText)/2 + frameObj.sFrameX);
        }

        private int centerTextY()
        {
            if(frameObj.isType == "triangle")
            {
                return (int)((frameObj.fFrameY - frameObj.sFrameY - frameObj.heightText) / 2 + frameObj.sFrameY + 
                    (int)(0.1 * (frameObj.fFrameY - frameObj.sFrameY)));
            }

            if(frameObj.isType == "ellipse")
            {
                return (int)((frameObj.fFrameY - frameObj.sFrameY - frameObj.heightText) / 2 + frameObj.sFrameY + 
                    (int)(0.1 * (frameObj.fFrameY - frameObj.sFrameY)));
            }

            
            return (int)((frameObj.fFrameY - frameObj.sFrameY - frameObj.heightText) / 2 + frameObj.sFrameY);
        }

        public void changeCoords(int x, int y, int dx, int dy)
        {
            frameObj.sFrameX = x; frameObj.sFrameY = y;
            frameObj.fFrameX = x + (frameObj.fFrameX - frameObj.sFrameX);
            frameObj.fFrameY = y + (frameObj.fFrameY - frameObj.sFrameY);

            frameObj.sFrameX += dx;
            frameObj.sFrameY += dy;

            frameObj.fFrameX += dx;
            frameObj.fFrameY += dy;

            curDisplaceX = (int)frameObj.fFrameX;
            curDisplaseY = (int)frameObj.fFrameY;
          
        }

        public void changeText(string text, string textType, int fontWidth)
        {
            textStyle = textType;
            fontSize = fontWidth;
            this.text = text;
        }

        public void resize(int width, int height)
        {
            frameObj.fFrameX = frameObj.sFrameX + width;
            frameObj.fFrameY = frameObj.sFrameY + height;
        }

        public void changeBorderSize(int size)
        {
            frameObj.borderThickness = size;
            borderThickness = size;
        }

        public void changeFillColor(int fR, int fG, int fB)
        {
            frameObj.fR = fR;
            frameObj.fG = fG;
            frameObj.fB = fB;
        }

        public void changeBorderColor(int bR, int  bG, int bB)
        {
            frameObj.bR = bR;
            frameObj.bG = bG;
            frameObj.bB = bB;
        }

        public void changeTextColor(int tR,  int tG, int tB)
        {
            this.tR = tR;
            this.tG = tG;
            this.tB = tB;
        }

        public void changeObject(string objType)
        {
            if (objType == "rectangle")
            {

                Figures.Rectangle obj = _gameField.generateRandomRectangle();

                obj.fR = frameObj.fR;
                obj.fB = frameObj.fB;
                obj.fG = frameObj.fG;

                obj.bR = frameObj.bR;
                obj.bB = frameObj.bB;
                obj.bG = frameObj.bG;

                obj.sFrameX = frameObj.sFrameX;
                obj.sFrameY = frameObj.sFrameY;

                obj.fFrameX = frameObj.fFrameX;
                obj.fFrameY = frameObj.fFrameY;
                obj.borderThickness = frameObj.borderThickness;
                obj.isType = "rectangle";
                obj.isFindNewObject = frameObj.isFindNewObject;
                frameObj = obj;
                frameObj.isType = "rectangle";

            }
            else if (objType == "circle")
            {

                Circle obj = _gameField.generateRandomCircle();

                obj.fR = frameObj.fR;
                obj.fB = frameObj.fB;
                obj.fG = frameObj.fG;

                obj.bR = frameObj.bR;
                obj.bB = frameObj.bB;
                obj.bG = frameObj.bG;

                obj.sFrameX = frameObj.sFrameX;
                obj.sFrameY = frameObj.sFrameY;
                obj.borderThickness = frameObj.borderThickness;
                obj.fFrameX = frameObj.fFrameX;
                obj.fFrameY = frameObj.fFrameY;
                obj.isType = "circle";
                obj.isFindNewObject = frameObj.isFindNewObject;
                frameObj = obj;
                frameObj.isType = "circle";
            }
            else if (objType == "triangle")
            {

                Triangle obj = _gameField.generateRandomTriangle();

                obj.fR = frameObj.fR;
                obj.fB = frameObj.fB;
                obj.fG = frameObj.fG;

                obj.bR = frameObj.bR;
                obj.bB = frameObj.bB;
                obj.bG = frameObj.bG;

                obj.sFrameX = frameObj.sFrameX;
                obj.sFrameY = frameObj.sFrameY;
                obj.borderThickness = frameObj.borderThickness;
                obj.fFrameX = frameObj.fFrameX;
                obj.fFrameY = frameObj.fFrameY;
                obj.isType = "triangle";
                obj.isFindNewObject = frameObj.isFindNewObject;
                frameObj = obj;
                frameObj.isType = "triangle";
            }
            else if (objType == "square")
            {

                Square obj = _gameField.generateRandomSquare();

                obj.fR = frameObj.fR;
                obj.fB = frameObj.fB;
                obj.fG = frameObj.fG;

                obj.bR = frameObj.bR;
                obj.bB = frameObj.bB;
                obj.bG = frameObj.bG;

                obj.sFrameX = frameObj.sFrameX;
                obj.sFrameY = frameObj.sFrameY;
                obj.borderThickness = frameObj.borderThickness;
                obj.fFrameX = frameObj.fFrameX;
                obj.fFrameY = frameObj.fFrameY;
                obj.isType = "square";
                obj.isFindNewObject = frameObj.isFindNewObject;
                frameObj = obj;
                frameObj.isType = "square";
            }
            else if (objType == "line")
            {

                Line obj = _gameField.generateRandomLine();

                obj.fR = frameObj.fR;
                obj.fB = frameObj.fB;
                obj.fG = frameObj.fG;

                obj.bR = frameObj.bR;
                obj.bB = frameObj.bB;
                obj.bG = frameObj.bG;

                obj.sFrameX = frameObj.sFrameX;
                obj.sFrameY = frameObj.sFrameY;
                obj.borderThickness = frameObj.borderThickness;
                obj.fFrameX = frameObj.fFrameX;
                obj.fFrameY = frameObj.fFrameY;
                obj.isType = "line";
                obj.isFindNewObject = frameObj.isFindNewObject;
                frameObj = obj;
                frameObj.isType = "line";
            }
            else if (objType == "ellipse")
            {

                Ellipse obj = _gameField.generateRandomEllipse();

                obj.fR = frameObj.fR;
                obj.fB = frameObj.fB;
                obj.fG = frameObj.fG;

                obj.bR = frameObj.bR;
                obj.bB = frameObj.bB;
                obj.bG = frameObj.bG;
                obj.borderThickness = frameObj.borderThickness;
                obj.sFrameX = frameObj.sFrameX;
                obj.sFrameY = frameObj.sFrameY;

                obj.fFrameX = frameObj.fFrameX;
                obj.fFrameY = frameObj.fFrameY;
                obj.isType = "ellipse";
                obj.isFindNewObject = frameObj.isFindNewObject;
                frameObj = obj;
                frameObj.isType = "ellipse";
            }
        }

        public bool isAbsolute = false;

    }
}
