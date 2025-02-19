﻿using Figures.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using UserMenu = Figures.Menu.Menu;

using Rectangle = Figures.Figures.Rectangle;

namespace Figures
{
    public partial class Form1 : Form
    {

        GameField gameField;
        
        public int windowWidth;
        public int windowHeight;

        Random random;

        Game game;

        UserMenu userMenu;

        bool isChanged = true;

        public Form1()
        {
            random = new Random();

            InitializeComponent();
            windowWidth = DrawingField.Width;
            windowHeight = DrawingField.Height;
            windowWidth = 1536;
            windowHeight = 801;
            //gameField = new GameField(15, 15, windowWidth - 15, windowHeight - 15, random.Next(255), random.Next(255), random.Next(255), random.Next(255), random.Next(255), random.Next(255), 30, windowWidth, windowHeight);

            //userMenu = new UserMenu(gameField);

            //game = new Game(gameField, 30, 15, 15, windowWidth - 15, windowHeight - 15, 15);

            gameField = new GameField(15, 15, windowWidth - 20, windowHeight - 20, random.Next(255), random.Next(255), random.Next(255), random.Next(255), random.Next(255), random.Next(255), 33, windowWidth, windowHeight);

            userMenu = new UserMenu(gameField);

            game = new Game(gameField, 30, 15, 15, windowWidth - 15, windowHeight - 15, 5);

        }

        private void DrawingField_Click(object sender, EventArgs e)
        {
        }

        private void DrawingField_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            gameField.Draw(graphics);

            foreach (var obj in userMenu.menuItems)
            {
                
                if (obj.isVisible)
                {

                    obj.Draw(graphics);
                    obj.DrawText(graphics);
                    
                }
                
            }

            //Отрисовываем элементы menu после нажатия кнопки m
            if (Program.isMenuVisible)
            {
                foreach (var obj in userMenu.itemsInMenu)
                {
                    obj.Draw(graphics);
                    obj.DrawText(graphics);
                   

                    foreach (var submenuItems in obj.subMenuItems)
                    {
                        if (submenuItems.isVisible)
                        {
                            submenuItems.Draw(graphics);
                            submenuItems.DrawText(graphics);
                            
                        }    
                    }

                }
            }     

            game.Play();

            DrawingField.Invalidate();
        }

        private void DrawingField_MouseDown(object sender, MouseEventArgs e)
        {
            userMenu.onClick(e.X, e.Y, userMenu.menuItems);
            userMenu.onEditClick(e.X, e.Y, userMenu.itemsInMenu);
        }

        private void DrawingField_SizeChanged(object sender, EventArgs e)
        {
        }

        private void DrawingField_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void DrawingField_DoubleClick(object sender, EventArgs e)
        {
            //if (isChanged)
            //{
            //    windowWidth = DrawingField.Width;
            //    windowHeight = DrawingField.Height;
            //    gameField = new GameField(15, 15, windowWidth - 20, windowHeight - 20, random.Next(255), random.Next(255), random.Next(255), random.Next(255), random.Next(255), random.Next(255), 33, windowWidth, windowHeight);

            //    userMenu = new UserMenu(gameField);

            //    game = new Game(gameField, 30, 15, 15, windowWidth - 15, windowHeight - 15, 5);
            //    DrawingField.Invalidate();
            //    isChanged = false;
            //}
        }
    }
}
