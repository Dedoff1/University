using Figures.Figures;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Rectangle = Figures.Figures.Rectangle;

namespace Figures.Menu
{
    internal class Menu
    {
        public int curItemPos = 0;
        int currentIndex = 0;


        int ggg = 0;
        GameField _gameField;
        public bool forTest = false;
        public bool forAddMenu = false;
        int firstTry = 0;
        // массив элементов меню
        public MenuItems[] menuItems = new MenuItems[0];

        private const int editIShift = 150;

        private static int itemToEditIndex = 0;

        private static int itemDisplaceX = 50;
        private static int itemDisplaceY = 50;

        Random random = new Random();
        public int indexReservItem = 0;
        public bool FLAG = false;

        public int subMenuIndex = 0;

        private int fWidth, fHeight;

        bool isClicked = true;

        public Menu(GameField _gameField)
        {
            this._gameField = _gameField;

            fWidth = _gameField.windowWidth;
            fHeight = _gameField.windowHeight;

            generateEditFields(_gameField.windowWidth, _gameField.windowHeight);
            curItemPos = 0;
        }

        public void funcMaster()
        {
            if (curItemPos != 0)
            {
                for (int i = 0; i < menuItems.Length-1; i++)
                {
                    if (menuItems[i].frameObj.isFindNewObject)
                    {

                        indexReservItem = i; //+ fff + menuItems[i].submenuCount - 3;
                        
                        FLAG = true;
                        menuItems[i].frameObj.isFindNewObject = false;
                        break;
                    }

                }
            }
        }


        public void newFuncMaster()
        {
            if (curItemPos != 0)
            {
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (menuItems[i].frameObj.isFindNewObject || menuItems[i].isParent)
                    {

                        indexReservItem = menuItems[i].index; //+ fff + menuItems[i].submenuCount - 3;
                        FLAG = true;
                        menuItems[i].frameObj.isFindNewObject = false;
                        break;
                    }



                }
            }
        }

        public void AddItem(ref string objTypeYou, int x, int y, int fontSize, string text, int tR, int tG, int tB)
        {
            string objType = objTypeYou;
            resizeArr(menuItems);
            funcMaster();
            
            objTypeYou = objType;
            if(FLAG)
                objType = menuItems[indexReservItem].frameObj.isType;

            if (objType == "rectangle")
            {
                if (FLAG)
                {
                    Rectangle obj = _gameField.generateRandomRectangle();
                    changePos(obj, x, y);
                    resizeFrame(obj, (int)(menuItems[indexReservItem].frameObj.fFrameX - menuItems[indexReservItem].frameObj.sFrameX),
                       (int)(menuItems[indexReservItem].frameObj.fFrameY - menuItems[indexReservItem].frameObj.sFrameY));
                    obj.isType = "rectangle";
                    obj.fontWeight = fontSize;
                    menuItems[curItemPos] = new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);

                    menuItems[curItemPos].frameObj.isType = menuItems[indexReservItem].frameObj.isType;

                    menuItems[curItemPos].isFindNewObject = false;
                    menuItems[curItemPos].frameObj.isFindNewObject = false;
                    menuItems[indexReservItem].frameObj.isFindNewObject = false;
                    menuItems[indexReservItem].isFindNewObject = false;


                    menuItems[curItemPos].frameObj.fR = menuItems[indexReservItem].frameObj.fR;
                    menuItems[curItemPos].frameObj.fB = menuItems[indexReservItem].frameObj.fB;
                    menuItems[curItemPos].frameObj.fG = menuItems[indexReservItem].frameObj.fG;
                    // border
                    menuItems[curItemPos].frameObj.borderThickness = menuItems[indexReservItem].frameObj.borderThickness;
                    menuItems[curItemPos].borderThickness = menuItems[indexReservItem].borderThickness;

                    // text //
                    menuItems[curItemPos].text = menuItems[indexReservItem].text;
                    menuItems[curItemPos].fontSize = menuItems[indexReservItem].fontSize;
                    menuItems[curItemPos].textStyle = menuItems[indexReservItem].textStyle;
                    menuItems[curItemPos].tB = menuItems[indexReservItem].tB;
                    menuItems[curItemPos].tG = menuItems[indexReservItem].tG;
                    menuItems[curItemPos].tR = menuItems[indexReservItem].tR;
                    // text // 

                    menuItems[curItemPos].frameObj.bR = menuItems[indexReservItem].frameObj.bR;
                    menuItems[curItemPos].frameObj.bB = menuItems[indexReservItem].frameObj.bB;
                    menuItems[curItemPos].frameObj.bG = menuItems[indexReservItem].frameObj.bG;
                    

                    menuItems[curItemPos].curDisplaceX = (int)menuItems[curItemPos].frameObj.fFrameX;
                    menuItems[curItemPos].curDisplaseY = (int)menuItems[curItemPos].frameObj.fFrameY;
                }
                else
                {
                    Rectangle obj = _gameField.generateRandomRectangle();
                    changePos(obj, x, y);
                    resizeFrame(obj, 100, 70);
                    obj.isType = "rectangle";
                    obj.fontWeight = fontSize;
                    menuItems[curItemPos] = new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);
                    menuItems[curItemPos].isType = "rectangle";
                    menuItems[curItemPos].fontWeight = fontSize;

                    menuItems[curItemPos].curDisplaceX = (int)menuItems[curItemPos].frameObj.fFrameX;
                    menuItems[curItemPos].curDisplaseY = (int)menuItems[curItemPos].frameObj.fFrameY;
                }
               
               
               
                

                menuItems[curItemPos].isAbsolute = true;

                currentIndex++;

                curItemPos++;
            }
            else if (objType == "circle")
            {
                
                if (FLAG)
                {
                    Circle obj = _gameField.generateRandomCircle();
                    changePos(obj, x, y);
                    resizeFrame(obj, (int)(menuItems[indexReservItem].frameObj.fFrameX - menuItems[indexReservItem].frameObj.sFrameX),
                       (int)(menuItems[indexReservItem].frameObj.fFrameY - menuItems[indexReservItem].frameObj.sFrameY));
                    obj.isType = "circle";
                    obj.fontWeight = fontSize;
                    menuItems[curItemPos] = new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);

                    menuItems[curItemPos].frameObj.isType = menuItems[indexReservItem].frameObj.isType;

                    menuItems[curItemPos].isFindNewObject = false;
                    menuItems[curItemPos].frameObj.isFindNewObject = false;
                    menuItems[indexReservItem].frameObj.isFindNewObject = false;
                    menuItems[indexReservItem].isFindNewObject = false;


                    menuItems[curItemPos].frameObj.fR = menuItems[indexReservItem].frameObj.fR;
                    menuItems[curItemPos].frameObj.fB = menuItems[indexReservItem].frameObj.fB;
                    menuItems[curItemPos].frameObj.fG = menuItems[indexReservItem].frameObj.fG;

                    // border
                    menuItems[curItemPos].frameObj.borderThickness = menuItems[indexReservItem].frameObj.borderThickness;
                    menuItems[curItemPos].borderThickness = menuItems[indexReservItem].borderThickness;

                    // text //
                    menuItems[curItemPos].text = menuItems[indexReservItem].text;
                    menuItems[curItemPos].fontSize = menuItems[indexReservItem].fontSize;
                    menuItems[curItemPos].textStyle = menuItems[indexReservItem].textStyle;
                    menuItems[curItemPos].tB = menuItems[indexReservItem].tB;
                    menuItems[curItemPos].tG = menuItems[indexReservItem].tG;
                    menuItems[curItemPos].tR = menuItems[indexReservItem].tR;

                    // text // 

                    menuItems[curItemPos].frameObj.bR = menuItems[indexReservItem].frameObj.bR;
                    menuItems[curItemPos].frameObj.bB = menuItems[indexReservItem].frameObj.bB;
                    menuItems[curItemPos].frameObj.bG = menuItems[indexReservItem].frameObj.bG;

                    menuItems[curItemPos].curDisplaceX = (int)menuItems[curItemPos].frameObj.fFrameX;
                    menuItems[curItemPos].curDisplaseY = (int)menuItems[curItemPos].frameObj.fFrameY;

                }
                else
                {
                    Circle obj = _gameField.generateRandomCircle();
                    changePos(obj, x, y);
                    resizeFrame(obj, 70, 70);
                    obj.isType = "circle";
                    obj.fontWeight = fontSize;
                    menuItems[curItemPos] = new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);
                    menuItems[curItemPos].isType = "circle";
                    menuItems[curItemPos].fontWeight = fontSize;

                    menuItems[curItemPos].curDisplaceX = (int)menuItems[curItemPos].frameObj.fFrameX;
                    menuItems[curItemPos].curDisplaseY = (int)menuItems[curItemPos].frameObj.fFrameY;

                }



                menuItems[curItemPos].isAbsolute = true;

                currentIndex++;
                curItemPos++;
            }
            else if (objType == "triangle")
            {
                

                if (FLAG)
                {
                    Triangle obj = _gameField.generateRandomTriangle();
                    changePos(obj, x, y);
                    resizeFrame(obj, (int)(menuItems[indexReservItem].frameObj.fFrameX - menuItems[indexReservItem].frameObj.sFrameX),
                        (int)(menuItems[indexReservItem].frameObj.fFrameY - menuItems[indexReservItem].frameObj.sFrameY));
                    obj.isType = "triangle";
                    obj.fontWeight = fontSize;
                    menuItems[curItemPos] = new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);


                    menuItems[curItemPos].isFindNewObject = false;
                    menuItems[curItemPos].frameObj.isFindNewObject = false;
                    menuItems[indexReservItem].frameObj.isFindNewObject = false;
                    menuItems[indexReservItem].isFindNewObject = false;


                    menuItems[curItemPos].frameObj.isType = menuItems[indexReservItem].frameObj.isType;


                    menuItems[curItemPos].frameObj.fR = menuItems[indexReservItem].frameObj.fR;
                    menuItems[curItemPos].frameObj.fB = menuItems[indexReservItem].frameObj.fB;
                    menuItems[curItemPos].frameObj.fG = menuItems[indexReservItem].frameObj.fG;

                    // border
                    menuItems[curItemPos].frameObj.borderThickness = menuItems[indexReservItem].frameObj.borderThickness;
                    menuItems[curItemPos].borderThickness = menuItems[indexReservItem].borderThickness;

                    // text //
                    menuItems[curItemPos].text = menuItems[indexReservItem].text;
                    menuItems[curItemPos].fontSize = menuItems[indexReservItem].fontSize;
                    menuItems[curItemPos].textStyle = menuItems[indexReservItem].textStyle;
                    menuItems[curItemPos].tB = menuItems[indexReservItem].tB;
                    menuItems[curItemPos].tG = menuItems[indexReservItem].tG;
                    menuItems[curItemPos].tR = menuItems[indexReservItem].tR;

                    // text // 

                    menuItems[curItemPos].frameObj.bR = menuItems[indexReservItem].frameObj.bR;
                    menuItems[curItemPos].frameObj.bB = menuItems[indexReservItem].frameObj.bB;
                    menuItems[curItemPos].frameObj.bG = menuItems[indexReservItem].frameObj.bG;

                    menuItems[curItemPos].curDisplaceX = (int)menuItems[curItemPos].frameObj.fFrameX;
                    menuItems[curItemPos].curDisplaseY = (int)menuItems[curItemPos].frameObj.fFrameY;
                }
                else
                {
                    Triangle obj = _gameField.generateRandomTriangle();
                    changePos(obj, x, y);
                    resizeFrame(obj, 70, 70);
                    obj.isType = "triangle";
                    obj.fontWeight = fontSize;
                    menuItems[curItemPos] = new MenuItems(x, y, fontSize - 2, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);
                    menuItems[curItemPos].isType = "triangle";
                    menuItems[curItemPos].fontWeight = fontSize;

                    menuItems[curItemPos].curDisplaceX = (int)menuItems[curItemPos].frameObj.fFrameX;
                    menuItems[curItemPos].curDisplaseY = (int)menuItems[curItemPos].frameObj.fFrameY;
                }

                
                
               
                

                menuItems[curItemPos].isAbsolute = true;

                currentIndex++;
                curItemPos++;
            }
            else if (objType == "square")
            {

                

                if (FLAG)
                {
                    Square obj = _gameField.generateRandomSquare();
                    changePos(obj, x, y);
                    resizeFrame(obj, (int)(menuItems[indexReservItem].frameObj.fFrameX - menuItems[indexReservItem].frameObj.sFrameX),
                       (int)(menuItems[indexReservItem].frameObj.fFrameY - menuItems[indexReservItem].frameObj.sFrameY));
                    obj.isType = "square";
                    obj.fontWeight = fontSize;
                    menuItems[curItemPos] = new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);


                    // border
                    menuItems[curItemPos].frameObj.borderThickness = menuItems[indexReservItem].frameObj.borderThickness;
                    menuItems[curItemPos].borderThickness = menuItems[indexReservItem].borderThickness;


                    menuItems[curItemPos].frameObj.isType = menuItems[indexReservItem].frameObj.isType;

                    menuItems[curItemPos].isFindNewObject = false;
                    menuItems[curItemPos].frameObj.isFindNewObject = false;
                    menuItems[indexReservItem].frameObj.isFindNewObject = false;
                    menuItems[indexReservItem].isFindNewObject = false;


                    menuItems[curItemPos].frameObj.fR = menuItems[indexReservItem].frameObj.fR;
                    menuItems[curItemPos].frameObj.fB = menuItems[indexReservItem].frameObj.fB;
                    menuItems[curItemPos].frameObj.fG = menuItems[indexReservItem].frameObj.fG;

                    // text //
                    menuItems[curItemPos].text = menuItems[indexReservItem].text;
                    menuItems[curItemPos].fontSize = menuItems[indexReservItem].fontSize;
                    menuItems[curItemPos].textStyle = menuItems[indexReservItem].textStyle;
                    menuItems[curItemPos].tB = menuItems[indexReservItem].tB;
                    menuItems[curItemPos].tG = menuItems[indexReservItem].tG;
                    menuItems[curItemPos].tR = menuItems[indexReservItem].tR;

                    // text // 

                    menuItems[curItemPos].frameObj.bR = menuItems[indexReservItem].frameObj.bR;
                    menuItems[curItemPos].frameObj.bB = menuItems[indexReservItem].frameObj.bB;
                    menuItems[curItemPos].frameObj.bG = menuItems[indexReservItem].frameObj.bG;

                    menuItems[curItemPos].curDisplaceX = (int)menuItems[curItemPos].frameObj.fFrameX;
                    menuItems[curItemPos].curDisplaseY = (int)menuItems[curItemPos].frameObj.fFrameY;
                }
                else
                {
                    Square obj = _gameField.generateRandomSquare();
                    changePos(obj, x, y);
                    resizeFrame(obj, 70, 70);
                    obj.isType = "square";
                    obj.fontWeight = fontSize;
                    menuItems[curItemPos] = new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);
                    menuItems[curItemPos].isType = "square";
                    menuItems[curItemPos].fontWeight = fontSize;

                    menuItems[curItemPos].curDisplaceX = (int)menuItems[curItemPos].frameObj.fFrameX;
                    menuItems[curItemPos].curDisplaseY = (int)menuItems[curItemPos].frameObj.fFrameY;
                }

                menuItems[curItemPos].isAbsolute = true;

                currentIndex++;
                curItemPos++;
            }
            else if (objType == "line")
            {
                

                if (FLAG)
                {
                   // menuItems[curItemPos] = menuItems[indexReservItem];
                }
                else
                {
                    Line obj = _gameField.generateRandomLine();
                    changePos(obj, x, y);
                    resizeFrame(obj, 100, 70);
                    obj.isType = "line";
                    obj.fontWeight = fontSize;
                    menuItems[curItemPos] = new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);
                    menuItems[curItemPos].isType = "line";
                    menuItems[curItemPos].fontWeight = fontSize;
                }

               
                menuItems[curItemPos].curDisplaceX = (int)menuItems[curItemPos].frameObj.fFrameX;
                menuItems[curItemPos].curDisplaseY = (int)menuItems[curItemPos].frameObj.fFrameY;

                menuItems[curItemPos].isAbsolute = true;

                currentIndex++;
                curItemPos++;
            }
            else if (objType == "ellipse")
            {
                if (FLAG)
                {
                    Ellipse obj = _gameField.generateRandomEllipse();
                    changePos(obj, x, y);
                    resizeFrame(obj, (int)(menuItems[indexReservItem].frameObj.fFrameX - menuItems[indexReservItem].frameObj.sFrameX), 
                        (int)(menuItems[indexReservItem].frameObj.fFrameY - menuItems[indexReservItem].frameObj.sFrameY));
                    obj.isType = "ellipse";
                    obj.fontWeight = fontSize;
                    menuItems[curItemPos] = new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);


                    menuItems[curItemPos].isFindNewObject = false;
                    menuItems[curItemPos].frameObj.isFindNewObject = false;
                    menuItems[indexReservItem].frameObj.isFindNewObject = false;
                    menuItems[indexReservItem].isFindNewObject = false;


                    menuItems[curItemPos].frameObj.isType = menuItems[indexReservItem].frameObj.isType;

                    // border
                    menuItems[curItemPos].frameObj.borderThickness = menuItems[indexReservItem].frameObj.borderThickness;
                    menuItems[curItemPos].borderThickness = menuItems[indexReservItem].borderThickness;
                    //////////////////////////////////////////////////////
                    menuItems[curItemPos].frameObj.fR = menuItems[indexReservItem].frameObj.fR;
                    menuItems[curItemPos].frameObj.fB = menuItems[indexReservItem].frameObj.fB;
                    menuItems[curItemPos].frameObj.fG = menuItems[indexReservItem].frameObj.fG;

                    // text //
                    menuItems[curItemPos].text = menuItems[indexReservItem].text;
                    menuItems[curItemPos].fontSize = menuItems[indexReservItem].fontSize;
                    menuItems[curItemPos].textStyle = menuItems[indexReservItem].textStyle;
                    menuItems[curItemPos].tB = menuItems[indexReservItem].tB;
                    menuItems[curItemPos].tG = menuItems[indexReservItem].tG;
                    menuItems[curItemPos].tR = menuItems[indexReservItem].tR;

                    // text // 

                    menuItems[curItemPos].frameObj.bR = menuItems[indexReservItem].frameObj.bR;
                    menuItems[curItemPos].frameObj.bB = menuItems[indexReservItem].frameObj.bB;
                    menuItems[curItemPos].frameObj.bG = menuItems[indexReservItem].frameObj.bG;

                    menuItems[curItemPos].curDisplaceX = (int)menuItems[curItemPos].frameObj.fFrameX;
                    menuItems[curItemPos].curDisplaseY = (int)menuItems[curItemPos].frameObj.fFrameY;
                }
                else
                {
                    Ellipse obj = _gameField.generateRandomEllipse();
                    changePos(obj, x, y);
                    resizeFrame(obj, 100, 70);
                    obj.isType = "ellipse";
                    obj.fontWeight = fontSize;
                    menuItems[curItemPos] = new MenuItems(x, y, fontSize - 2, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);
                    menuItems[curItemPos].isType = "ellipse";
                    menuItems[curItemPos].fontWeight = fontSize;
                    menuItems[curItemPos].curDisplaceX = (int)menuItems[curItemPos].frameObj.fFrameX;
                    menuItems[curItemPos].curDisplaseY = (int)menuItems[curItemPos].frameObj.fFrameY;

                }

               

                menuItems[curItemPos].isAbsolute = true;

                currentIndex++;
                curItemPos++;
            }
        }

        public void AddSubmenu(int index)
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (menuItems[i].index == index)
                {
                    menuItems[i].isParent = true;
                    menuItems[i].submenuCount++;
                   
                    string tmpString = menuItems[i + menuItems[i].submenuCount-1].frameObj.isType;
                    insertMenu(i + menuItems[i].submenuCount, AddRandomSubitem(tmpString, menuItems[i].curDisplaceX+20, menuItems[i].curDisplaseY, 14, "Text", random.Next(255), random.Next(255), random.Next(255), i + menuItems[i].submenuCount));
                    curItemPos++;
                    menuItems[i].isType = tmpString;
                    menuItems[i].fontWeight = 14;
                    menuItems[i].curDisplaceX = (int)menuItems[i + menuItems[i].submenuCount].frameObj.fFrameX;
                    menuItems[i].curDisplaseY = (int)menuItems[i + menuItems[i].submenuCount].frameObj.fFrameY;
                    menuItems[i + menuItems[i].submenuCount].isParent = false;
                    menuItems[i + menuItems[i].submenuCount].isVisible = true;
       
                    menuItems[i + menuItems[i].submenuCount].parentIndex = index;

                    

                    menuItems[i + menuItems[i].submenuCount].curDisplaceX = (int)menuItems[i + menuItems[i].submenuCount].frameObj.fFrameX + 50;
                    menuItems[i + menuItems[i].submenuCount].curDisplaseY = (int)menuItems[i + menuItems[i].submenuCount].frameObj.sFrameY;

                    menuItems[i + menuItems[i].submenuCount].index = currentIndex;
                    currentIndex++;

                    break;
                }
            }   
        }

        private void insertMenu(int index, MenuItems obj)
        {
            MenuItems[] newArray = new MenuItems[menuItems.Length + 1];

            Array.Copy(menuItems, newArray, index);
            newArray[index] = obj;

            Array.Copy(menuItems, index, newArray, index + 1, menuItems.Length - index);

            menuItems = newArray;
        }

        public void AddEditSubmenu(string text)
        {
            itemsInMenu[0].subMenuItems = createSubmenu(itemsInMenu[0].subMenuItems);
            forAddMenu = true;
            itemsInMenu[0].subMenuItems[itemsInMenu[0].submenuCount] = AddRandomSubitem(objTypes[0], editIShift+itemsInMenu[0].curDisplace, 500 + itemsInMenu[0].curDisplace, 15, text, random.Next(255), random.Next(255), random.Next(255),0);
            itemsInMenu[0].curDisplace += 70;
            itemsInMenu[0].subMenuItems[itemsInMenu[0].submenuCount].index = subMenuIndex;
            itemsInMenu[0].submenuCount++;
            itemsInMenu[0].subMenuItems[subMenuIndex].frameObj.fR = 0;
            itemsInMenu[0].subMenuItems[subMenuIndex].frameObj.fG = 140;
            itemsInMenu[0].subMenuItems[subMenuIndex].frameObj.fB = 120;
            itemsInMenu[0].subMenuItems[subMenuIndex].tR = 0;
            itemsInMenu[0].subMenuItems[subMenuIndex].tG = 0;
            itemsInMenu[0].subMenuItems[subMenuIndex].tB = 0;
            itemsInMenu[0].subMenuItems[subMenuIndex].frameObj.bR = 150;
            itemsInMenu[0].subMenuItems[subMenuIndex].frameObj.bG = 0;
            itemsInMenu[0].subMenuItems[subMenuIndex].frameObj.bB = 0;

            itemsInMenu[0].subMenuItems[subMenuIndex].frameObj.borderThickness = 3;
            subMenuIndex++;
        }

        private MenuItems[] createSubmenu(MenuItems[] submenu)
        {
            MenuItems[] newArray = new MenuItems[submenu.Length + 1];

            Array.Copy(submenu, newArray, submenu.Length);

            return newArray;
        }

        public void DeleteItem(int index)
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (menuItems[i].index == index)
                {

                    if (menuItems.Length == 1)
                    {
                        MenuItems[] newArray = new MenuItems[menuItems.Length - 1];
                        menuItems = newArray;
                        curItemPos--;
                        break;
                    }

                    if (menuItems[i].isParent)
                    {
                        int len = 1 + menuItems[i].submenuCount;

                        for (int j = i + 1; j < len; j++)
                        {
                            if (menuItems[j].isParent)
                            {
                                len += menuItems[j].submenuCount;
                            }

                        }

                        curItemPos -= len;

                        MenuItems[] newArray = new MenuItems[menuItems.Length - len];

                        int pIndex = menuItems[i].parentIndex;

                        Array.Copy(menuItems, newArray, i);
                        Array.Copy(menuItems, i + 1 + menuItems[i].submenuCount, newArray, i, menuItems.Length - i - len);

                        menuItems = newArray;

                        for (int j = 0; j < menuItems.Length; j++)
                        {
                            if (menuItems[j].index == pIndex)
                            {
                                menuItems[j].submenuCount -= 1;
                                break;
                            }
                        }
                        break;
                    }
                    else
                    {
                        MenuItems[] newArray = new MenuItems[menuItems.Length - 1];
                        int pIndex = menuItems[i].parentIndex;

                        Array.Copy(menuItems, 0, newArray, 0, i);
                        
                        Array.Copy(menuItems, i + 1, newArray, i, menuItems.Length - i - 1);

                        menuItems = newArray;

                        curItemPos--;

                        for (int j = 0; j < menuItems.Length; j++)
                        {
                            if (menuItems[j].index == pIndex)
                            {
                                menuItems[j].submenuCount -= 1;
                                break;
                            }
                        }

                        break;
                    }
                }
            }
        }

        public void resizeFrame(DisplayObject obj, int width, int height)
        {
            obj.fFrameX = obj.sFrameX + width;
            obj.fFrameY = obj.sFrameY + height;
        }

        public void changePos(DisplayObject obj, int x, int y)
        {
            obj.sFrameX = x; obj.sFrameY = y;
            obj.fFrameX = x + (obj.fFrameX - obj.sFrameX);
            obj.fFrameY = y + (obj.fFrameY - obj.sFrameY);
        }

        public void changeFrameColor(DisplayObject obj, int r, int g, int b)
        {
            obj.fR = r;
            obj.fG = g;
            obj.fB = b;
        }

        public void generateEditFields(int width, int height)
        {
            generateEditField(width, height, editIShift, 450, "Add Item");
            AddEditSubmenu("Add in menu");
            AddEditSubmenu("  Add in submenu");
            generateEditField(width, height, (int)(editIShift*2.5), 450, "Delete Item");
            generateEditField(width, height, (int)(editIShift*4), 450, "Edit Item");
        }
        private void generateEditField(int width, int height, int shiftX, int shiftY,string text)
        {
            Rectangle obj = _gameField.generateRandomRectangle();
            changePos(obj, shiftX - 50, shiftY + 50);
            resizeFrame(obj, 150, 50);

            obj.fR = 0;
            obj.fG = 140;
            obj. fB = 120;

            obj.bR = 150;
            obj.bG = 0;
            obj.bB = 0;

            obj.borderThickness = 3;

            itemsInMenu[curItemPos] = new MenuItems(width - shiftX, height - shiftY, 15, text, "Arial" ,0, 0, 0, obj, currentIndex, _gameField);

            currentIndex++;
            curItemPos++;
        }

        public void onClick(int x, int y, MenuItems[] items)
        {
            
            bool isFind = false;
            
            foreach (var obj in items)
            {
                if ((x >= obj.frameObj.sFrameX && x <= obj.frameObj.fFrameX) && (y >= obj.frameObj.sFrameY && y <= obj.frameObj.fFrameY))
                {
                    if (obj.isVisible)
                    {
                        itemToEditIndex = obj.index;
                    }
                    
                    int pos = 0;

                    for (int i = 0; i < menuItems.Length; i++)
                    {
                        if (menuItems[i].index == itemToEditIndex)
                        {
                            pos = i;
                            break;
                        }
                    }

                    isClicked = !isClicked;

                    if (isClicked)
                    {
                        int len = pos + menuItems[pos].submenuCount + 1;
                        for (int i = pos + 1; i < len; i++)
                        {
                             if (menuItems[i].isParent) len += menuItems[i].submenuCount;
                            menuItems[i].isVisible = false;
                        }
                    }
                    else
                    {
                        int len = pos + menuItems[pos].submenuCount + 1;

                        int i = pos + 1;

                        while (i < len)
                        {
                            menuItems[i].isVisible = true;

                            if (menuItems[i].isParent)
                            {
                                len += menuItems[i].submenuCount;
                                int ind = i;
                                i += menuItems[i].submenuCount + 1;
                                for (int j = ind+1; j < i; j++)
                                {
                                    menuItems[j].isVisible = false;
                                }
                                continue;
                            }
                            i++;
                        }

                        
                    }

                    isFind = true;
                    
                }
            }

            if (!isFind)
            {
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (!menuItems[i].isAbsolute)
                    {
                        menuItems[i].isVisible=false;
                    }
                }   
            }

        }

        private void resizeArr(MenuItems[] arr)
        {
            MenuItems[] newArray = new MenuItems[arr.Length + 1];

            Array.Copy(arr, newArray, arr.Length);

            menuItems = newArray;
        }


        public void onEditClick(int x, int y, MenuItems[] editItems)
        {
            foreach (var obj in editItems)
            {
                if ((x >= obj.frameObj.sFrameX && x <= obj.frameObj.fFrameX) && (y >= obj.frameObj.sFrameY && y <= obj.frameObj.fFrameY) && obj.index == 0 && Program.isMenuVisible)
                {
                    foreach (var submenu in obj.subMenuItems)
                    {
                        submenu.isVisible = !submenu.isVisible;       
                    }    
                }

                if ((x >= obj.frameObj.sFrameX && x <= obj.frameObj.fFrameX) && (y >= obj.frameObj.sFrameY && y <= obj.frameObj.fFrameY) && obj.index == 1 && Program.isMenuVisible)
                {
                    DeleteItem(itemToEditIndex);
                }

                if ((x >= obj.frameObj.sFrameX && x <= obj.frameObj.fFrameX) && (y >= obj.frameObj.sFrameY && y <= obj.frameObj.fFrameY) && obj.index == 2 && Program.isMenuVisible)
                {
                    Edit(itemToEditIndex);
                }
            }
           
            foreach (var obj in editItems[0].subMenuItems)
            {
                
                if ((x >= obj.frameObj.sFrameX && x <= obj.frameObj.fFrameX) && (y >= obj.frameObj.sFrameY && y <= obj.frameObj.fFrameY) && obj.index == 0 && Program.isMenuVisible && obj.isVisible)
                {
                    //if (menuItems.Length != 0 && menuItems[menuItems.Length-1].isFindNewObject)
                    //{
                    //    obj.text = menuItems[menuItems.Length-1].text;
                    //    obj.frameObj.textman = menuItems[menuItems.Length - 1].text;
                    //    obj.frameObj.isType = menuItems[menuItems.Length-1].isType;
                    //    obj.fontWeight = menuItems[menuItems.Length-1].fontSize;
                    //    AddItem(obj.frameObj.isType, itemDisplaceX, itemDisplaceY, obj.fontWeight, obj.frameObj.textman, random.Next(255), random.Next(255), random.Next(255));
                    //}
                    //else
                    //{
                        
                    obj.frameObj.textman = "Text";


                    obj.frameObj.isType = objTypes[random.Next(5)];
                    string gggtmp = obj.frameObj.isType;
                    obj.fontWeight = random.Next(14) + 5;
                    AddItem(ref gggtmp, itemDisplaceX, itemDisplaceY, obj.fontWeight, "Text", random.Next(255), random.Next(255), random.Next(255));
                    if(firstTry == 0)
                        menuItems[0].frameObj.isFindNewObject = true;
                    firstTry++;
                    itemDisplaceX = itemDisplaceX + 130;
                    if(itemDisplaceX > fWidth-150)
                    {
                        itemDisplaceY += 120;
                        itemDisplaceX = 50;
                    }
                    
                    
                }

                if ((x >= obj.frameObj.sFrameX && x <= obj.frameObj.fFrameX) && (y >= obj.frameObj.sFrameY && y <= obj.frameObj.fFrameY) && obj.index == 1 && Program.isMenuVisible && obj.isVisible)
                {
                    AddSubmenu(itemToEditIndex);
                }
            }

        }

        private void Edit(int index)
        {
            foreach (var obj in menuItems)
            {
                if (obj.index == index)
                {
                    MenuHandler handler = new MenuHandler(obj);
                    handler.Show();
                }
            }
        }

        public MenuItems AddRandomSubitem(string objType, int x, int y, int fontSize, string text, int tR, int tG, int tB, int indexParent)
        {
            newFuncMaster();
           
            if (objType == "rectangle")
            {
                Rectangle obj = _gameField.generateRandomRectangle();
                changePos(obj, x, y+20);
                if (forAddMenu)
                {
                    forAddMenu = false;
                    resizeFrame(obj, 150, 50);
                    obj.isType = "rectangle";
                    obj.fontWeight = fontSize;
                   
                    return new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);
                }
                else
                    resizeFrame(obj, 100, 70);

                obj.isType = "rectangle";
                obj.fontWeight = fontSize;

                if(FLAG)
                {
                    Rectangle obj1 = _gameField.generateRandomRectangle();
                    changePos(obj1, x, y+20);
                    resizeFrame(obj1,(int)(menuItems[indexParent-1].frameObj.fFrameX - menuItems[indexParent - 1].frameObj.sFrameX),
                        (int)(menuItems[indexParent - 1].frameObj.fFrameY - menuItems[indexParent - 1].frameObj.sFrameY));
                    MenuItems NewSUbITEM = new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj1, currentIndex, _gameField);
                    
                    NewSUbITEM.frameObj.isType = menuItems[indexParent - 1].frameObj.isType;
                    NewSUbITEM.isType = menuItems[indexParent - 1].isType;

                    // border
                    NewSUbITEM.frameObj.borderThickness = menuItems[indexParent - 1].frameObj.borderThickness;
                    NewSUbITEM.borderThickness = menuItems[indexParent - 1].borderThickness;
                    //////////////////////////////////////////////////////
                    NewSUbITEM.frameObj.fR = menuItems[indexParent - 1].frameObj.fR;
                    NewSUbITEM.frameObj.fB = menuItems[indexParent - 1].frameObj.fB;
                    NewSUbITEM.frameObj.fG = menuItems[indexParent - 1].frameObj.fG;

      



                    // text //
                    NewSUbITEM.text = menuItems[indexParent - 1].text;
                    NewSUbITEM.fontSize = menuItems[indexParent - 1].fontSize;
                    NewSUbITEM.textStyle = menuItems[indexParent - 1].textStyle;
                    NewSUbITEM.tB = menuItems[indexParent - 1].tB;
                    NewSUbITEM.tG = menuItems[indexParent - 1].tG;
                    NewSUbITEM.tR = menuItems[indexParent - 1].tR;

                    // text // v

                    NewSUbITEM.frameObj.bR = menuItems[indexParent - 1].frameObj.bR;
                    NewSUbITEM.frameObj.bB = menuItems[indexParent - 1].frameObj.bB;
                    NewSUbITEM.frameObj.bG = menuItems[indexParent - 1].frameObj.bG;

                   
                    return NewSUbITEM;
                }
                else
                    return new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);
            }
            else if (objType == "circle")
            {
                Circle obj = _gameField.generateRandomCircle();
                changePos(obj, x, y);
                resizeFrame(obj, 70, 70);
                obj.isType = "circle";
                obj.fontWeight = fontSize;
                if (FLAG)
                {
                    Circle obj1 = _gameField.generateRandomCircle();
                    changePos(obj1, x, y);
                    resizeFrame(obj1, (int)(menuItems[indexParent - 1].frameObj.fFrameX - menuItems[indexParent - 1].frameObj.sFrameX),
                        (int)(menuItems[indexParent-1].frameObj.fFrameY - menuItems[indexParent-1].frameObj.sFrameY));
                    MenuItems NewSUbITEM = new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj1, currentIndex, _gameField);
                    
                    NewSUbITEM.frameObj.isType = menuItems[indexParent-1].frameObj.isType;
                    NewSUbITEM.isType = menuItems[indexParent-1].isType;

                    // border
                    NewSUbITEM.frameObj.borderThickness = menuItems[indexParent-1].frameObj.borderThickness;
                    NewSUbITEM.borderThickness = menuItems[indexParent-1].borderThickness;
                    //////////////////////////////////////////////////////
                    NewSUbITEM.frameObj.fR = menuItems[indexParent-1].frameObj.fR;
                    NewSUbITEM.frameObj.fB = menuItems[indexParent-1].frameObj.fB;
                    NewSUbITEM.frameObj.fG = menuItems[indexParent-1].frameObj.fG;





                    // text //
                    NewSUbITEM.text = menuItems[indexParent-1].text;
                    NewSUbITEM.fontSize = menuItems[indexParent-1].fontSize;
                    NewSUbITEM.textStyle = menuItems[indexParent-1].textStyle;
                    NewSUbITEM.tB = menuItems[indexParent-1].tB;
                    NewSUbITEM.tG = menuItems[indexParent-1].tG;
                    NewSUbITEM.tR = menuItems[indexParent-1].tR;

                    // text // v

                    NewSUbITEM.frameObj.bR = menuItems[indexParent-1].frameObj.bR;
                    NewSUbITEM.frameObj.bB = menuItems[indexParent-1].frameObj.bB;
                    NewSUbITEM.frameObj.bG = menuItems[indexParent-1].frameObj.bG;

                   
                    return NewSUbITEM;
                }
                else
                    return new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);
            }
            else if (objType == "triangle")
            {
                Triangle obj = _gameField.generateRandomTriangle();
                changePos(obj, x, y);
                resizeFrame(obj, 70, 70);
                obj.isType = "triangle";
                obj.fontWeight = fontSize;
                if (FLAG)
                {
                    Triangle obj1 = _gameField.generateRandomTriangle();
                    changePos(obj1, x, y);
                    resizeFrame(obj1, (int)(menuItems[indexParent-1].frameObj.fFrameX - menuItems[indexParent-1].frameObj.sFrameX),
                        (int)(menuItems[indexParent-1].frameObj.fFrameY - menuItems[indexParent-1].frameObj.sFrameY));
                    MenuItems NewSUbITEM = new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj1, currentIndex, _gameField);
                
                    NewSUbITEM.frameObj.isType = menuItems[indexParent-1].frameObj.isType;
                    NewSUbITEM.isType = menuItems[indexParent-1].isType;

                    // border
                    NewSUbITEM.frameObj.borderThickness = menuItems[indexParent-1].frameObj.borderThickness;
                    NewSUbITEM.borderThickness = menuItems[indexParent-1].borderThickness;
                    //////////////////////////////////////////////////////
                    NewSUbITEM.frameObj.fR = menuItems[indexParent-1].frameObj.fR;
                    NewSUbITEM.frameObj.fB = menuItems[indexParent-1].frameObj.fB;
                    NewSUbITEM.frameObj.fG = menuItems[indexParent-1].frameObj.fG;




                    // text //
                    NewSUbITEM.text = menuItems[indexParent-1].text;
                    NewSUbITEM.fontSize = menuItems[indexParent-1].fontSize;
                    NewSUbITEM.textStyle = menuItems[indexParent-1].textStyle;
                    NewSUbITEM.tB = menuItems[indexParent-1].tB;
                    NewSUbITEM.tG = menuItems[indexParent-1].tG;
                    NewSUbITEM.tR = menuItems[indexParent-1].tR;

                    // text // v

                    NewSUbITEM.frameObj.bR = menuItems[indexParent-1].frameObj.bR;
                    NewSUbITEM.frameObj.bB = menuItems[indexParent-1].frameObj.bB;
                    NewSUbITEM.frameObj.bG = menuItems[indexParent-1].frameObj.bG;

                    
                    return NewSUbITEM;
                }
                else
                    return new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);
            }
            else if (objType == "square")
            {
                Square obj = _gameField.generateRandomSquare();
                changePos(obj, x, y+20);
                resizeFrame(obj, 70, 70);
                obj.isType = "square";
                obj.fontWeight = fontSize;
                if (FLAG)
                {
                    Square obj1 = _gameField.generateRandomSquare();
                    changePos(obj1, x, y+20);
                    resizeFrame(obj1, (int)(menuItems[indexParent-1].frameObj.fFrameX - menuItems[indexParent-1].frameObj.sFrameX),
                        (int)(menuItems[indexParent-1].frameObj.fFrameY - menuItems[indexParent-1].frameObj.sFrameY));
                    MenuItems NewSUbITEM = new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj1, currentIndex, _gameField);
                    NewSUbITEM.frameObj.isType = menuItems[indexParent-1].frameObj.isType;
                    NewSUbITEM.isType = menuItems[indexParent-1].isType;

                    // border
                    NewSUbITEM.frameObj.borderThickness = menuItems[indexParent-1].frameObj.borderThickness;
                    NewSUbITEM.borderThickness = menuItems[indexParent-1].borderThickness;
                    //////////////////////////////////////////////////////
                    NewSUbITEM.frameObj.fR = menuItems[indexParent-1].frameObj.fR;
                    NewSUbITEM.frameObj.fB = menuItems[indexParent-1].frameObj.fB;
                    NewSUbITEM.frameObj.fG = menuItems[indexParent-1].frameObj.fG;

         


                    // text //
                    NewSUbITEM.text = menuItems[indexParent-1].text;
                    NewSUbITEM.fontSize = menuItems[indexParent-1].fontSize;
                    NewSUbITEM.textStyle = menuItems[indexParent-1].textStyle;
                    NewSUbITEM.tB = menuItems[indexParent-1].tB;
                    NewSUbITEM.tG = menuItems[indexParent-1].tG;
                    NewSUbITEM.tR = menuItems[indexParent-1].tR;

                    // text // v

                    NewSUbITEM.frameObj.bR = menuItems[indexParent-1].frameObj.bR;
                    NewSUbITEM.frameObj.bB = menuItems[indexParent-1].frameObj.bB;
                    NewSUbITEM.frameObj.bG = menuItems[indexParent-1].frameObj.bG;

                   
                    return NewSUbITEM;
                }
                else
                    return new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);
            }
            else if (objType == "ellipse")
            {
                Ellipse obj = _gameField.generateRandomEllipse();
                changePos(obj, x, y);
                resizeFrame(obj, 100, 70);
                obj.isType = "ellipse";
                obj.fontWeight = fontSize;
                if (FLAG)
                {
                    Ellipse obj1 = _gameField.generateRandomEllipse();
                    changePos(obj1, x, y);
                    resizeFrame(obj1, (int)(menuItems[indexParent-1].frameObj.fFrameX - menuItems[indexParent-1].frameObj.sFrameX),
                        (int)(menuItems[indexParent-1].frameObj.fFrameY - menuItems[indexParent-1].frameObj.sFrameY));
                    MenuItems NewSUbITEM = new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj1, currentIndex, _gameField);
                    NewSUbITEM.frameObj.isType = menuItems[indexParent-1].frameObj.isType;
                    NewSUbITEM.isType = menuItems[indexParent-1].isType;

                    // border
                    NewSUbITEM.frameObj.borderThickness = menuItems[indexParent-1].frameObj.borderThickness;
                    NewSUbITEM.borderThickness = menuItems[indexParent-1].borderThickness;
                    //////////////////////////////////////////////////////
                    NewSUbITEM.frameObj.fR = menuItems[indexParent-1].frameObj.fR;
                    NewSUbITEM.frameObj.fB = menuItems[indexParent-1].frameObj.fB;
                    NewSUbITEM.frameObj.fG = menuItems[indexParent-1].frameObj.fG;

  


                    // text //
                    NewSUbITEM.text = menuItems[indexParent-1].text;
                    NewSUbITEM.fontSize = menuItems[indexParent-1].fontSize;
                    NewSUbITEM.textStyle = menuItems[indexParent-1].textStyle;
                    NewSUbITEM.tB = menuItems[indexParent-1].tB;
                    NewSUbITEM.tG = menuItems[indexParent-1].tG;
                    NewSUbITEM.tR = menuItems[indexParent-1].tR;

                    // text // v

                    NewSUbITEM.frameObj.bR = menuItems[indexParent-1].frameObj.bR;
                    NewSUbITEM.frameObj.bB = menuItems[indexParent-1].frameObj.bB;
                    NewSUbITEM.frameObj.bG = menuItems[indexParent-1].frameObj.bG;

                    
                    return NewSUbITEM;
                }
                else
                    return new MenuItems(x, y, fontSize, text, "Times New Roman", tR, tG, tB, obj, currentIndex, _gameField);
            }

            return null;
        }

        public static string[] objTypes = new string[] { "rectangle", "ellipse", "square", "circle", "triangle" };

        public MenuItems[] itemsInMenu = new MenuItems[3];

    }
}
