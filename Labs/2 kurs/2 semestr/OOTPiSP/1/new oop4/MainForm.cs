using oop3.DisplayObjects;
using oop3.Menu;
using oop3.Utilities;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace oop2
{
    public partial class MainForm : Form
    {
        public static int fieldX1 = 0, fieldY1 = 0;
        public static int fieldX2 = 1400, fieldY2 = 900;
        public static int borderThickness = 30;

        private readonly bool movementEnabled = true;
        private static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private static int FPS = 60;
        // because of double-bufferization:
        private static int timeIntervalTimer = 1000 / FPS / 2;
        private static double actualTimerIntervalSec = timeIntervalTimer * 2;
        private static int timeInterval = 1000 / FPS / 2;

        private static double timeCounter = 0;

        private static Game MainGame;
        private static bool accelerated = false;


        public MainForm()
        {
            InitializeComponent();

            DoubleBuffered = true;
            WindowState = FormWindowState.Maximized;

            if (movementEnabled)
            {
                timer.Tick += new EventHandler(TimerHandler);
                timer.Interval = timeIntervalTimer;
                timer.Enabled = true;
            }

            Rectangle workArea = Screen.GetWorkingArea(this);

            // make right bottom the second point
            fieldX2 = DisplayRectangle.Width;// -100;
            fieldY2 = DisplayRectangle.Height;// -100;

            GameField field;
            DisplayObject[] objects;

            (field, objects) = ObjectInitializer.generateDrawField(fieldX1, fieldY1, fieldX2, fieldY2, borderThickness, accelerated);
            field.isAccelerated = false;

          

            foreach (DisplayObject obj in objects)
            {
                field.AddObject(obj);
            }

            // Initializing Game object
            MainGame = new Game(field);

        }

        private void TimerHandler(Object myObject, EventArgs myEventArgs)
        {
            timeCounter += actualTimerIntervalSec / 1000.0;
            MainGame.MoveObjects(actualTimerIntervalSec / 1000.0);
            Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            MainGame.DrawGame(e.Graphics);
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            MainGame.HandleClick(x, y);

            Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
