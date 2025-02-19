using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace OOP_lab_1
{
    public partial class FormMain : Form
    {
        static public Pen _pen;
        //public int borderSizeWindow = 50;
        public Graphics g;
        private int width;
        private int height;
        private GameField _gameField;
        public static void DrawBorder(Form form, Graphics graphics)
        {
            graphics.DrawRectangle(_pen, form.ClientRectangle);
        }
        public FormMain()
        {
            InitializeComponent();
            width = ClientSize.Width;//- borderSizeWindow;
            height = ClientSize.Height;// - borderSizeWindow;
            //_pen = new Pen(Color.White, borderSizeWindow) { Alignment = PenAlignment.Inset };
            g = this.CreateGraphics();
        }
        
        private void DrawObjects(GameField drField, Graphics graphic)
        {
            drField.Draw(graphic);
            foreach (var currObj in drField.arr)
            {
                currObj.Draw(graphic);
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            int newX = ClientSize.Width - width;
            int newY = ClientSize.Height -  height;
            width = ClientSize.Width;
            height = ClientSize.Height;
            if (_gameField != null)
            {
                _gameField.Update(_gameField.GetX + newX, _gameField.GetY + newY);
                for (int i = 0; i < _gameField.arr.Length; i++)
                {
                    var temp = _gameField.arr[i];
                    temp.Update(newX + temp.GetX, newY + temp.GetY);
                }
                g.Clear(Color.FromArgb(240,240,240));
                DrawObjects(_gameField, g);
            }
            //DrawBorder(this, g);
        }

        private void FormMain_Click(object sender, EventArgs e)
        {
           
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
        //    DrawBorder(this, g);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(Color.FromArgb(240, 240, 240));
            int minX = 0;// borderSizeWindow;
            int minY = 0;// borderSizeWindow;
            int maxX = this.ClientSize.Width;// - borderSizeWindow;
            int maxY = this.ClientSize.Height;// - borderSizeWindow;
            GameField gameField = GameField.GenerateObjects(width - 200, height - 200, minX + 200, minY + 200, maxX, maxY);
            _gameField = gameField;
            DrawObjects(gameField, g);
           // DrawBorder(this, g);
        }
    }
}