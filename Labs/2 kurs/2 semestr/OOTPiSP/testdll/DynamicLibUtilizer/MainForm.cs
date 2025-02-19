
using oop;
using oop.DisplayObjects;

namespace LibUtilizer
{
    public partial class MainForm : Form
    {        
        private static Game MainGame;
        private double actualTimerIntervalSec;
        private readonly bool movementEnabled = true;
        private static bool accelerated = false;

        public MainForm()
        {
            InitializeComponent();

            DoubleBuffered = true;
            WindowState = FormWindowState.Maximized;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            int FPS = 60;
            int timeIntervalTimer = 1000 / FPS / 2;
            actualTimerIntervalSec = timeIntervalTimer * 2;

            if (movementEnabled)
            {
                timer.Tick += new EventHandler(TimerHandler);
                timer.Interval = timeIntervalTimer;
                timer.Enabled = true;
            }

            Rectangle workArea = Screen.GetWorkingArea(this);


            int fieldX1 = 0, fieldY1 = 0;
            int fieldX2 = 1400, fieldY2 = 900;
            int borderThickness = 30;
            
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
            MainGame = new Game(field, FPS);

        }

        private void TimerHandler(Object myObject, EventArgs myEventArgs)
        {
            MainGame.MoveObjects(actualTimerIntervalSec / 1000.0);
            Invalidate();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            MainGame.HandleClick(x, y);

            Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            MainGame.DrawGame(e.Graphics);
        }
    }
}
