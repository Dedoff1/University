using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP1
{
    public partial class ManageFiguresDialog : Form
    {
        private DisplayObject[] objects;
        private Form1 form1;

        public ManageFiguresDialog(DisplayObject[] objects, Form1 form1)
        {
            InitializeComponent();
            this.objects = objects;
            this.form1 = form1;
        }


        private void ManageFiguresDialog_Load(object sender, EventArgs e)
        {
            comboBoxFG.Items.Add("Circle");
            comboBoxFG.Items.Add("Triangle");
            comboBoxFG.Items.Add("Rectangle");
            comboBoxFG.Items.Add("Oval");
            comboBoxFG.Items.Add("Rhombus");
            comboBoxFG.Items.Add("Square");
            comboBoxFG.Items.Add("DiagonalLine");
            comboBoxFG.Items.Add("InvertedTriangle");
        }

        private void txtVel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAngle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAccelX_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string selectedFigureType = comboBoxFG.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedFigureType))
            {
                int vel = int.Parse(txtVel.Text);
                int angle = int.Parse(txtAngle.Text);
                int accelX = int.Parse(txtAccelX.Text);
                int accelY = int.Parse(txtAccelY.Text);
                int spawnX = int.Parse(txtXSpawn.Text);
                int spawnY = int.Parse(txtYSpawn.Text);
                int sizeX = int.Parse(txtX2Spawn.Text);
                int sizeY = int.Parse(txtY2Spawn.Text);
                form1.AddFigure(selectedFigureType, vel, spawnX, spawnY, sizeX,sizeY,  angle, accelX, accelY);
            }
        }


        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (form1 != null)
            {
                form1.DeleteAllFigures();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selectedFigureType = comboBoxFG.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedFigureType))
            {
                form1.DeleteFiguresByType(selectedFigureType);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedFigureType = comboBoxFG.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedFigureType))
            {
                int vel = int.Parse(txtVel.Text);
                int angle = int.Parse(txtAngle.Text);
                int accelX = int.Parse(txtAccelX.Text);
                int accelY = int.Parse(txtAccelY.Text);
                int spawnX = int.Parse(txtXSpawn.Text);
                int spawnY = int.Parse(txtYSpawn.Text);
                int sizeX = int.Parse(txtX2Spawn.Text);
                int sizeY = int.Parse(txtY2Spawn.Text);
                form1.AddFigure(selectedFigureType, vel, spawnX, spawnY, sizeX, sizeY, angle -45, accelX, accelY);
                form1.AddFigure(selectedFigureType, vel, spawnX, spawnY, sizeX, sizeY, angle , accelX, accelY);
                form1.AddFigure(selectedFigureType, 0, spawnX, spawnY, sizeX, sizeY, angle, accelX, accelY);
            }
        }
    }
}