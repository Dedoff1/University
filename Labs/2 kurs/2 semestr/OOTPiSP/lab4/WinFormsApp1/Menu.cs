using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.shape;

namespace WinFormsApp1
{
    internal class Menu : DisplayObject
    {
        DisplayObject obj;
        public MenuItem[] items;  // Меню
        public int numItem;//кол-во пунктов меню
        public bool visible;
      

        public Menu(DisplayObject obj)
        {
            visible = false;
            numItem = 0;
            this.obj = obj;
            items = new MenuItem[20];
        }

        public void AddItem(string str, (byte, byte, byte) colorText, (byte, byte, byte) bTxtColor,
                            int bordTxt, System.Drawing.Font font, int fontSize, int height, int width, (byte, byte, byte) color,
                            (byte, byte, byte) frameColor, int frameWidth, int dx, int dy, TObj typeObj)
        {
            (int, int) shift;
            if (numItem == 0)
            {
                shift = (obj.x + dx, obj.y + dy);
            }
            else
            {
                shift = (items[numItem - 1].obj.fpx1+dx, items[numItem - 1].obj.fpy1+dy);
            }
            
            Txt text = new Txt(str, x + 5, y, colorText, font, fontSize);
            int textWidth = TextRenderer.MeasureText(str, font).Width;
            if (typeObj == TObj.triangle)
                textWidth *= 3;
            DisplayObject menuItemObj = MenuItem.CreateObj(typeObj, height, Math.Max(textWidth, width), shift, color, frameColor, frameWidth);
            menuItemObj.updatePosition();
            menuItemObj.calculateFrame();


            items[numItem] = new MenuItem(text, menuItemObj, shift.Item1, shift.Item2, typeObj, dx, dy);
            items[numItem].visible = true;
            items[numItem].updatePosition();
            items[numItem].calculateFrame();
            numItem++;
        }

        public override void calculateFrame()
        {
            obj.calculateFrame();
        }

        public void deleteItemMenu(MenuItem item)
        {
            bool start = false;
            for (int i = 0; i <numItem - 1; i++)
            {
                if (items[i] == item)
                {
                    start = true;
                }
                if (start)
                {
                    items[i] = items[i + 1];
                }
            }
            if (items[numItem - 1] == item)
            {
                start = true;
                items[numItem - 1] = null;
            }
            numItem--;
        }

        public void deleteItem(MenuItem item, MenuItem arr)
        {
            bool start = false;
            for(int i=0;i<arr.numItem-1;i++)
            {
                if (arr.items[i] == item)
                {
                    start = true;
                }
                if(start)
                {
                    arr.items[i] = arr.items[i+1];
                }
            }
            if (arr.items[arr.numItem-1]==item)
            {
                start = true;
                arr.items[arr.numItem - 1] = null;
            }
            if (start) arr.numItem--;
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            //obj.Draw(g);
            foreach (var item in items)
            {
                if (item != null)
                    item.Draw(g);
            }
        }


        public override void updatePosition()
        {
            obj.x = x;
            obj.y = y;
            obj.updatePosition();
        }

    }

}
