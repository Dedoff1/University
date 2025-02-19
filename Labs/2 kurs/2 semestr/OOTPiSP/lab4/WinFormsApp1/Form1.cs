using System.Reflection;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Game game;
        private System.Timers.Timer timer;

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
                           BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                           null,
                           panel1,
                           new object[] { true });

            game = new Game(new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height), 5);
            panel1.MouseClick += game.MouseClick;
            panel1.MouseDoubleClick += game.DoubleClick;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(game.canvas, Point.Empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            game.m.visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game.Start();
            game.TimerUpdate((float)timer1.Interval / 10f);
            panel1.Invalidate();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            // game.MouseClick(e.X, e.Y);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F)
            {
                game.menu.visible = false;
            }
            if (e.KeyCode == Keys.D)
            {
                game.menu.visible = true;
            }

            if (e.KeyCode == Keys.A)
            {
                game.gameVisible = true;
            }
            if (e.KeyCode == Keys.S)
            {
                game.gameVisible = false;
            }

            if (e.KeyCode == Keys.Z)
            {
                game.m.visible = true;
            }
            if (e.KeyCode == Keys.X)
            {
                game.m.visible = false;
            }
        }
    }
}