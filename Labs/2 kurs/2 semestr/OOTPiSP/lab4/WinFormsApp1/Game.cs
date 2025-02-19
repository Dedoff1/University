using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WinFormsApp1.shape;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WinFormsApp1
{
    enum TObj { rect, square, circle, ellipse, triangle }
    internal class Game
    {
        public Bitmap canvas;
        
        private Circle[] circles;
        private Rect[] rects;
        private Ellipse[] ellipses;
        private Square[] squares;
        private Triangle[] triangles;
        private GameField field;
        public Menu menu;
        public Menu m;
        private MenuItem clickedItem;
        public bool gameVisible;
        public MenuItem lastCreated;


        public void MouseClick(object sender, MouseEventArgs e)
        {
            if (menu.visible)
            {
                for (int i = 0; i < menu.numItem; i++)
                {
                    ProcessMouseClick(menu.items[i], e.Location.X, e.Location.Y);
                }
            }
            if (m.visible)
            {
                for (int i = 0; i < m.numItem; i++)
                {
                    ProcessMouseClick(m.items[i], e.Location.X, e.Location.Y);
                }
            }
        }

        public void DoubleClick(object sender, MouseEventArgs e)
        {
            if (m.visible)
            {
                for (int i = 0; i < m.numItem; i++)
                {
                    ProcessDClick(m.items[i], e.Location.X, e.Location.Y);
                }
            }
        }

        private bool ItParent(MenuItem item, int x, int y)
        {
            for (int i = 0; i < item.numItem; i++)
            {
                if (item.items[i].Contains(x, y)) return true;
                ItParent(item.items[i], x, y);
            }
            return false;
        }

        private MenuItem GetParent(MenuItem item, MenuItem[] parent)
        {
            if (parent != null)
            {
                foreach (MenuItem item2 in parent)
                {
                    if (item2 != null)
                    {
                        for (int i = 0; i < item2.numItem; i++)
                        {
                            if (item2.items[i] == item) return item2;
                        }
                    }
                }
            }
            else
            {
                foreach (MenuItem item2 in m.items)
                {
                    if (item2 != null)
                    {
                        for (int i = 0; i < item2.numItem; i++)
                        {
                            if (item2.items[i] == item) return item2;
                        }
                    }
                }
            }
            return null;
        }

        private void ProcessMouseClick(MenuItem item, int x, int y)
        {
            if (!item.Contains(x, y))
            {
                if (item.visible)
                    MenuItem.MakeParentVisible(item);
                if (!ItParent(item, x, y))
                    MenuItem.MakeInvisible(item);
            }
            else
            {
                if (item.visible)
                {
                    MenuItem.MakeParentVisible(item);
                    MenuItem.MakeVisible(item);
                    item.OnClicked();
                }
            }
            for (int i = 0; i < item.numItem; i++)
            {
                ProcessMouseClick(item.items[i], x, y);
            }
        }

        private void ProcessDClick(MenuItem item, int x, int y)
        {
            if (item.Contains(x, y))
            {
                if (item.visible)
                {

                    menu.visible = true;
                    clickedItem = item;
                }
                return;
            }
            else
            {
                
                for (int i = 0; i < item.numItem; i++)
                {
                    ProcessDClick(item.items[i], x, y);
                }
            }
        }

        static (byte, byte, byte) RandomColor()
        {
            Random rnd = new Random();
            return new((byte)rnd.Next(255), (byte)rnd.Next(255), (byte)rnd.Next(255));
        }

        private (int, int) RandomPosition()
        {
            Random rnd = new Random();
            return (rnd.Next(field.clientX1, field.clientX2), rnd.Next(field.clientY1, field.clientY2));
        }

        private void MoveObj(DisplayObject obj, float time)
        {
            obj.Move(time);
            obj.updatePosition();
            obj.calculateFrame();
        }

        private float RandomV()
        {
            Random rnd = new Random();
            return ((float)(rnd.Next(1, 3) - 1.5f));
        }
        private float RandomA()
        {
            Random rnd = new Random();
            switch (rnd.Next(1, 2))
            {
                case 1:
                    return 0f;
                default:
                    return ((float)rnd.NextDouble() * 0.77f - 0.5f);
            }
        }

        public void TimerUpdate(float time)
        {
            CheckObj(circles, TObj.circle);
            CheckObj(rects, TObj.rect);
            CheckObj(triangles, TObj.triangle);
            CheckObj(squares, TObj.square);
            CheckObj(ellipses, TObj.ellipse);
            for (int i = 0; i < circles.Length; i++)
            {
                MoveObj(circles[i], time);
                MoveObj(rects[i], time);
                MoveObj(triangles[i], time);
                MoveObj(squares[i], time);
                MoveObj(ellipses[i], time);
            }
        }


        private DisplayObject RandomObj(TObj type)
        {
            Random rnd = new Random();
            int max = 100;
            int min = 20;
            int maxWidth = 20;
            int x = rnd.Next(min, max);
            int y = rnd.Next(min, max);
            int frame = rnd.Next(maxWidth);
            int radius = rnd.Next(min, max);
            int length = rnd.Next(min, max);
            var pos = RandomPosition();
            switch (type)
            {
                case TObj.square:
                    return new Square(length, pos.Item1, pos.Item2, RandomColor(), RandomColor(), frame);
                case TObj.rect:
                    return new Rect(y, x, pos.Item1, pos.Item2, RandomColor(), RandomColor(), frame);
                case TObj.triangle:
                    return new Triangle(length, pos.Item1, pos.Item2, RandomColor(), RandomColor(), frame);
                case TObj.circle:
                    return new Circle(radius, pos.Item1, pos.Item2, RandomColor(), RandomColor(), frame);
                case TObj.ellipse:
                    return new Ellipse(x, y, pos.Item1, pos.Item2, RandomColor(), RandomColor(), frame);
                default: return null;
            }
        }

        private bool OutFrame(DisplayObject o)
        {
            if ((o.fpx1 <= field.clientX1)
                || (o.fpy1 <= field.clientY1)
                || (o.fpx2 >= field.clientX2)
                || (o.fpy2 >= field.clientY2))
            {
                return false;
            }
            else return true;
        }

        private bool Out(DisplayObject o)
        {
            if ((o.x <= field.clientX1)
                || (o.y <= field.clientY1)
                || (o.x >= field.clientX2)
                || (o.y >= field.clientY2))
            {
                return true;
            }
            else return false;
        }

        private void RandomSpeed(DisplayObject[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].vX = RandomV();
                arr[i].vY = RandomV();
                arr[i].aX = RandomA();
                arr[i].aY = RandomA();
            }
        }

        private void CheckObj(DisplayObject[] arr, TObj type)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (Out(arr[i]))
                {
                    arr[i] = RandomObj(type);
                    CheckO(arr[i]);
                    arr[i].vX = RandomV();
                    arr[i].vY = RandomV();
                    arr[i].aX = RandomA();
                    arr[i].aY = RandomA();
                }
            }
        }

        private void CheckO(DisplayObject o)
        {
            while (!OutFrame(o))
            {
                var pos = RandomPosition();
                o.x = pos.Item1;
                o.y = pos.Item2;
                o.updatePosition();
                o.calculateFrame();
            }
        }

        private void Check(DisplayObject[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                while (!OutFrame(arr[i]))
                {
                    var pos = RandomPosition();
                    arr[i].x = pos.Item1;
                    arr[i].y = pos.Item2;
                    arr[i].updatePosition();
                    arr[i].calculateFrame();
                }

            }
        }

        private void CheckMenu(MenuItem menu)
        {
            while (!OutFrame(menu.obj))
            {
                var pos = RandomPosition();
                menu.obj.x = pos.Item1;
                menu.obj.y = pos.Item2;
                menu.obj.updatePosition();
                menu.obj.calculateFrame();
                menu.Shift();
            }
        }
        public Game(Bitmap canvas, int objCount)
        {
            this.canvas = canvas;

            circles = new Circle[objCount];
            triangles = new Triangle[objCount];
            ellipses = new Ellipse[objCount];
            squares = new Square[objCount];
            rects = new Rect[objCount];
            gameVisible = false;

            Random rnd = new Random();
            int width = 10;

            field = new GameField(canvas.Size.Height - 2 * width, canvas.Size.Width - 2 * width, 0, 0, RandomColor(), RandomColor(), width);
            field.updatePosition();
            field.calculateFrame();

            for (int i = 0; i < objCount; i++)
            {
                circles[i] = RandomObj(TObj.circle) as Circle;
                rects[i] = RandomObj(TObj.rect) as Rect;
                triangles[i] = RandomObj(TObj.triangle) as Triangle;
                squares[i] = RandomObj(TObj.square) as Square;
                ellipses[i] = RandomObj(TObj.ellipse) as Ellipse;
            }

            Check(circles);
            Check(rects);
            Check(triangles);
            Check(squares);
            Check(ellipses);

            RandomSpeed(circles);
            RandomSpeed(rects);
            RandomSpeed(triangles);
            RandomSpeed(squares);
            RandomSpeed(ellipses);


            CreateMenu();
            CreateM();
        }

        public void Start()
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);
                field.Draw(g);

                if (gameVisible)
                {
                    for (int i = 0; i < rects.Length; i++)
                    {
                        circles[i].Draw(g);
                        rects[i].Draw(g);
                        triangles[i].Draw(g);
                        squares[i].Draw(g);
                        ellipses[i].Draw(g);
                    }
                }

                if (menu.visible)
                {
                    menu.Draw(g);
                }
                if (m.visible)
                {
                    m.Draw(g);
                }
            }

        }


        private void CreateMenu()
        {
            int textSize = 8;
            int height = 100;
            int width = 100;
            int shiftX = (int)(width * 1.5);
            int shiftY = (int)(height * 1.3);
            menu = new Menu(new Rect(0, 0, 850, 25, RandomColor(), RandomColor(), 0));
            (byte, byte, byte) bTColor = RandomColor();
            (byte, byte, byte) textColor = RandomColor();
            (byte, byte, byte) sColor = RandomColor();
            (byte, byte, byte) bSColor = RandomColor();
            string[] strMenu = { "Создать", "Удалить", "Изменить" };

            Font font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            for (int i = 0; i < strMenu.Length; i++)
            {
                menu.AddItem(strMenu[i], textColor, bTColor, 5, font, textSize, height, width, sColor, bSColor, 5, shiftX, 0, TObj.circle);
                menu.items[i].parent = null;
                menu.items[i].Shift();
            }
            menu.items[0].AddItem(TObj.circle, " Добавить \n   в меню", textColor, bTColor, 1, font, textSize, height, width, sColor, bSColor, 5, 0, shiftY);
            menu.items[0].AddItem(TObj.circle, "Добавить\nподменю", textColor, bTColor, 1, font, textSize, height, width, sColor, bSColor, 5, 0, shiftY);
            menu.items[0].AddItem(TObj.circle, " Создать\n главное\n    меню", textColor, bTColor, 1, font, textSize, height, width, sColor, bSColor, 5, 0, shiftY);
            menu.items[0].items[0].parent = menu.items;
            menu.items[0].items[1].parent = menu.items;
            menu.items[0].items[0].Shift();
            menu.items[0].items[1].Shift();
            menu.items[2].Clicked += Change_Click;
            menu.items[1].Clicked += Delete_Click;
            menu.items[0].items[0].Clicked += newMenuItem;
            menu.items[0].items[1].Clicked += newItem;
            menu.items[0].items[2].Clicked += CreateNewMenu;


        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (clickedItem != null)
            {
                int size;
                MenuItem[] arr = clickedItem.parent;
                if (arr == null) { m.deleteItemMenu(clickedItem); }
                else
                {
                    var res = GetParent(clickedItem, arr);
                    if (res != null)
                        m.deleteItem(clickedItem, res);
                    else
                    {
                        m.deleteItemMenu(clickedItem);
                    }
                }
            }
            clickedItem = null;
        }

        private MenuItem FindPrev(MenuItem item, MenuItem parent)
        {
            MenuItem prev = null;
            if (parent != null)
            {
                if (parent.numItem == 0) return parent;
                for (int i = 0; i < parent.numItem; i++)
                {
                    if (parent.items[i] == item)
                    {
                        return prev;
                    }
                    prev = parent.items[i];
                }
            }
            else
            {
                for (int i = 0; i < m.numItem; i++)
                {
                    if (m.items[i] == item)
                    {
                        return prev;
                    }
                    prev = m.items[i];
                }
            }
            return prev;
        }


        private void Change_Click(object sender, EventArgs e)
        {

            if (clickedItem != null)
            {
                string fontName = clickedItem.text.font.Name;
                using (Form2 form = new Form2(clickedItem.text.textStr, fontName, Convert.ToString(clickedItem.obj.GetType()), clickedItem.text.fontSize, clickedItem.obj.fpy2 - clickedItem.obj.fpy1, clickedItem.obj.fpx2 - clickedItem.obj.fpx1, clickedItem.obj.frameWidth, clickedItem.obj.x, clickedItem.obj.y, clickedItem.shiftX, clickedItem.shiftY, clickedItem.obj.color, clickedItem.obj.frameColor, clickedItem.text.color, "Изменить"))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        TObj type;
                        switch (form.type)
                        {
                            case 0: type = TObj.rect; break;
                            case 1: type = TObj.square; break;
                            case 2: type = TObj.circle; break;
                            case 3: type = TObj.ellipse; break;
                            case 4: type = TObj.triangle; break;
                            default: type = TObj.rect; break;
                        }

                        string str = form.text1;
                        int textSize = form.text7;
                        int height = form.text5;
                        int width = form.text4;
                        int shiftX = form.text2;
                        int shiftY = form.text3;

                        int frameWidth = form.text6;

                        string strX = form.text8;
                        string strY = form.text9;


                        int x = Convert.ToInt32(strX) + 11;
                        int y = Convert.ToInt32(strY) + 11;
                        if (frameWidth != 0)
                        {
                            x -= 1;
                            y -= 1;
                        }
                        if (frameWidth % 2 != 0)
                        {
                            x -= 1;
                            y -= 1;
                        }


                        string fontStr = form.font;
                        (byte, byte, byte) bTColor = RandomColor();
                        (byte, byte, byte) textColor = form.textColor;
                        (byte, byte, byte) sColor = form.color;
                        (byte, byte, byte) bSColor = form.colorFrame;
                        Font font = new Font(fontStr, textSize, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                        MenuItem prev = FindPrev(clickedItem, GetParent(clickedItem, clickedItem.parent));
                        if (prev == null) prev = GetParent(clickedItem, clickedItem.parent);


                        clickedItem.Change(ref clickedItem, prev, str, textColor, bTColor, 1, font, textSize, height, width, sColor, bSColor, frameWidth, shiftX, shiftY, type, x, y);
                        clickedItem.obj.updatePosition();

                        clickedItem.calculateFrame();
                        clickedItem.Shift();


       

                        lastCreated = clickedItem;

                    }
                }
                clickedItem = null;
            }
        }

        private void CreateM()
        {
            m = new Menu(field);
        }

        public void newItem(object sender, EventArgs e)
        {
            if (clickedItem != null)
            {
                Random rnd = new Random();
                string str = clickedItem.text.textStr; // Используем текст родительского элемента
                int textSize = (int)clickedItem.text.font.Size; // Используем размер текста родительского элемента

                int height = clickedItem.obj.fpy2 - clickedItem.obj.fpy1 - clickedItem.obj.frameWidth * 2; // Используем высоту родительского элемента
                int width = clickedItem.obj.fpx2 - clickedItem.obj.fpx1 - clickedItem.obj.frameWidth * 2;
                if (clickedItem.type == TObj.triangle)
                {
                    height = clickedItem.obj.fpy2 - clickedItem.obj.fpy1; // Используем высоту родительского элемента
                    width = clickedItem.obj.fpx2 - clickedItem.obj.fpx1;
                }
                int shiftX = 0;
                int shiftY = clickedItem.obj.fpy2 - clickedItem.obj.fpy1 + 50; // Смещение по оси Y ниже родительского элемента
                (byte, byte, byte) bTColor = RandomColor();
                (byte, byte, byte) textColor = clickedItem.text.color;
                (byte, byte, byte) sColor = clickedItem.obj.color; // Используем цвет заливки родительского элемента
                (byte, byte, byte) bSColor = clickedItem.obj.frameColor; // Используем цвет рамки родительского элемента
                int borderwidth = clickedItem.obj.frameWidth;
                Font font = clickedItem.text.font; // Используем шрифт родительского элемента

                clickedItem.AddItem(clickedItem.type, str, textColor, bTColor, 1, font, textSize, height, width, sColor, bSColor, borderwidth, shiftX, shiftY);

                if (clickedItem.parent == null)
                {
                    clickedItem.items[clickedItem.numItem - 1].parent = m.items;
                }
                else
                {
                    var res = GetParent(clickedItem, clickedItem.parent);
                    if (res != null)
                        clickedItem.items[clickedItem.numItem - 1].parent = res.items;
                    else
                        clickedItem.items[clickedItem.numItem - 1].parent = m.items;

                }
                clickedItem.items[clickedItem.numItem - 1].Shift();


                // Обновляем позицию и границы объекта
                clickedItem.items[clickedItem.numItem - 1].obj.updatePosition();
                clickedItem.items[clickedItem.numItem - 1].obj.calculateFrame();
                clickedItem.items[clickedItem.numItem - 1].Shift();
                lastCreated = clickedItem.items[clickedItem.numItem - 1];
                clickedItem = null;

            }
        }
        public void newMenuItem(object sender, EventArgs e)
        {
            if (clickedItem == null) return;

            var parent = clickedItem;
            string str = parent.text.textStr; // Используем текст родительского элемента
            int textSize = (int)parent.text.font.Size; // Используем размер текста родительского элемента

            int height = parent.obj.fpy2 - parent.obj.fpy1 - parent.obj.frameWidth * 2; // Используем высоту родительского элемента
            int width = parent.obj.fpx2 - parent.obj.fpx1 - parent.obj.frameWidth * 2;
            if (parent.type == TObj.triangle)
            {
                height = parent.obj.fpy2 - parent.obj.fpy1; // Используем высоту родительского элемента
                width = parent.obj.fpx2 - parent.obj.fpx1;
            }
            int shiftX = parent.obj.fpx2 - parent.obj.fpx1 + 50;
            int shiftY = 0;
            (byte, byte, byte) bTColor = RandomColor();
            (byte, byte, byte) textColor = parent.text.color;
            (byte, byte, byte) sColor = parent.obj.color; // Используем цвет заливки родительского элемента
            (byte, byte, byte) bSColor = parent.obj.frameColor; // Используем цвет рамки родительского элемента
            int borderwidth = parent.obj.frameWidth;
            Font font = parent.text.font; // Используем шрифт родительского элемента

            m.AddItem(str, textColor, bTColor, 1, font, textSize, height, width, sColor, bSColor, borderwidth, shiftX, shiftY, parent.type);
            m.items[m.numItem - 1].parent = null;
            m.items[m.numItem - 1].Shift();
            m.items[m.numItem - 1].obj.x = parent.obj.fpx1 + shiftX;
            m.items[m.numItem - 1].obj.y = parent.obj.fpy1 + shiftY;
            m.items[m.numItem - 1].parent = new MenuItem[5];
            m.items[m.numItem - 1].parent[0] = parent;
            m.items[m.numItem - 1].obj.updatePosition();
            m.items[m.numItem - 1].obj.calculateFrame();
            m.items[m.numItem - 1].Shift();
            lastCreated = m.items[m.numItem - 1];
        }

        private void CreateNewMenu(object sender, EventArgs e)
        {
            if (m.numItem == 0)
            {
                Random rnd = new Random();
                TObj type = (TObj)rnd.Next(0, 4);

                string str = "Рандомный текст";
                int textSize = rnd.Next(8, 15);
                int height = rnd.Next(50, 100);
                int width = rnd.Next(50, 100);
                int shiftX = 0;
                int shiftY = 0;
                int border = rnd.Next(5, 15);
                string fontStr = "Arial";
                (byte, byte, byte) bTColor = RandomColor();
                (byte, byte, byte) textColor = RandomColor();
                (byte, byte, byte) sColor = RandomColor();
                (byte, byte, byte) bSColor = RandomColor();
                Font font = new Font(fontStr, textSize, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                m.AddItem(str, textColor, bTColor, 1, font, textSize, height, width, sColor, bSColor, border, shiftX, shiftY, type);
                m.items[m.numItem - 1].parent = null;
                m.items[m.numItem - 1].Shift();
                m.items[m.numItem - 1].obj.x = (field.fpx2 / 2) - width / 2;
                m.items[m.numItem - 1].obj.y = (field.fpy2 / 2) - height / 2 - 200;
                m.items[m.numItem - 1].obj.updatePosition();
                m.items[m.numItem - 1].obj.calculateFrame();
                m.items[m.numItem - 1].Shift();
                lastCreated = m.items[m.numItem - 1];
            }
        }
    }
}
