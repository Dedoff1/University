using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.shape;

namespace WinFormsApp1
{
    internal class MenuItem : DisplayObject
    {
        public DisplayObject obj;  
        public Txt text;  // Текст
        public MenuItem[] items;  // Подменю 
        public int numItem;  // Количество объектов подменю
        public bool visible;
        public MenuItem[] parent;
        public MenuItem parentObj;
        public TObj type;
        public event EventHandler Clicked;
        public int shiftX, shiftY;



        public void OnClicked()
        {
            var clickedHandler = Clicked;
            if (clickedHandler != null)
            {
                clickedHandler.Invoke(this, EventArgs.Empty);
            }
        }

        public MenuItem(Txt text, DisplayObject obj, int x, int y, TObj typeObj, int shiftX, int shiftY)
        {
            this.x = x;
            this.y = y;
            this.text = text;
            this.obj = obj;
            items = new MenuItem[5];
            visible = false;
            numItem = 0;
            this.type = typeObj;
            this.shiftX = shiftX;
            this.shiftY = shiftY;
        }

        public void AddItem(TObj typeObj, string str, (byte, byte, byte) colorText, (byte, byte, byte) bTxtColor,
                            int bordTxt, System.Drawing.Font font, int fontSize, int height, int width, (byte, byte, byte) color,
                            (byte, byte, byte) frameColor, int frameWidth, int dx, int dy)
        {
            (int, int) shift;
            type = typeObj;
            if (numItem == 0)
            {
                shift = (obj.x + dx, obj.y + dy);
            }
            else
            {
                shift = (items[numItem - 1].obj.fpx1 + dx, items[numItem - 1].obj.fpy1 +dy);
            }


            Txt itemText = new Txt(str, x, y, colorText,font, fontSize);
            int textWidth = TextRenderer.MeasureText(str, font).Width;
            DisplayObject itemObj = CreateObj(typeObj, height, Math.Max(width, textWidth), shift, color, frameColor, frameWidth);
            items[numItem] = new MenuItem(itemText, itemObj, shift.Item1, shift.Item2, typeObj, dx, dy);
            items[numItem].Shift();
            items[numItem].updatePosition();
            items[numItem].calculateFrame();
            numItem++;
        }

        public override void calculateFrame()
        {
            obj.calculateFrame();
        }

        public static void MakeVisible(MenuItem item)
        {
            foreach (var subItem in item.items)
            {
                if (subItem != null)
                    subItem.visible = true;
            }
        }

        public static void MakeParentVisible(MenuItem item)
        {
            MenuItem[] parent = item.parent;
            if (parent == null)
                return;
            foreach (var parentItem in parent)
            {
                if (parentItem != null)
                {
                    parentItem.visible = true;
                    MakeParentVisible(parentItem);
                }
            }
        }

        public static void MakeInvisible(MenuItem item)
        {
            foreach (var subItem in item.items)
            {
                if (subItem != null)
                    subItem.visible = false;
            }
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            if (visible)
            {
                obj.Draw(g);
                text.Draw(g);
            }
            foreach (var subItem in items)
            {
                if (subItem != null)
                    subItem.Draw(g);
            }
        }

        public override void updatePosition()
        {
            obj.x = x;
            obj.y = y;
            obj.updatePosition();
            foreach (var subItem in items)
            {
                if (subItem != null)
                    subItem.updatePosition();
            }
        }

        public void Shift()
        {
            text.updatePosition();
            text.calculateFrame();
            int textWidth = text.fpx2 - text.fpx1;
            int textHeight = text.fpy2 - text.fpy1;
            int objCentrX = obj.fpx1 + (obj.fpx2 - obj.fpx1) / 2;
            int objCentrY = obj.fpy1 + (obj.fpy2 - obj.fpy1) / 2;
            text.x = objCentrX - textWidth / 2;
            text.y = objCentrY - textHeight / 2;
            text.updatePosition();
            text.calculateFrame();
        }

        public static DisplayObject CreateObj(TObj typeObj, int height, int width, (int, int) pos, (byte, byte, byte) color, (byte, byte, byte) frameColor, int frameWidth)
        {
            switch (typeObj)
            {
                case TObj.rect:
                    return new Rect(height, width, pos.Item1, pos.Item2, color, frameColor, frameWidth);
                case TObj.triangle:
                    return new Triangle(width, pos.Item1, pos.Item2, color, frameColor, frameWidth);
                case TObj.circle:
                    return new Circle(width, pos.Item1, pos.Item2, color, frameColor, frameWidth);
                case TObj.ellipse:
                    return new Ellipse(width, height, pos.Item1, pos.Item2, color, frameColor, frameWidth);
                case TObj.square:
                    return new Square(width, pos.Item1, pos.Item2, color, frameColor, frameWidth);
            }
            return null;
        }

        public bool Contains(int x, int y)
        {
            obj.calculateFrame();
            if ((obj.fpx1 <= x) && (obj.fpx2 >= x) && (obj.fpy1 <= y) && (obj.fpy2 >= y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Change(ref MenuItem item, MenuItem prev,string str, (byte, byte, byte) colorText, (byte, byte, byte) bTxtColor,
                    int bordTxt, System.Drawing.Font font, int fontSize, int height, int width, (byte, byte, byte) color,
                    (byte, byte, byte) frameColor, int frameWidth, int dx, int dy, TObj typeObj, int x, int y)
        {
            (int, int) shift;
           

        
            Txt itemText = new Txt(str, x, y, colorText, font, fontSize);
            int textWidth = TextRenderer.MeasureText(str, font).Width;
            if (typeObj == TObj.triangle)
                textWidth *= 3;

            DisplayObject itemObj = CreateObj(typeObj, height, Math.Max(width, textWidth), (x, y), color, frameColor, frameWidth);
            
            item = new MenuItem(itemText, itemObj, x, y, typeObj, dx, dy);
          
            this.color = item.color;
            obj.frameWidth = item.frameWidth;
            this.obj = item.obj;
            this.x = x; this.y= y;    
            obj.x = x; obj.y = y;
            this.frameColor = item.frameColor;
         
            this.text = item.text;
            this.shiftX = dx;
            this.shiftY = dy;
            type = typeObj;

            this.calcPosition(dx, dy, prev);
    
            obj.updatePosition();
            obj.calculateFrame();
            Shift();
            updatePosition();
            calculateFrame();
        }

        public void calcPosition(int dx, int dy, MenuItem parent)
        {

            if (parent != null )
            {
   
                this.x = parent.obj.fpx1 + dx; this.y = parent.obj.fpy1 + dy;
                obj.x = parent.obj.fpx1 + dx; obj.y = parent.obj.fpy1 + dy;
            }
        }
        
    }

}
