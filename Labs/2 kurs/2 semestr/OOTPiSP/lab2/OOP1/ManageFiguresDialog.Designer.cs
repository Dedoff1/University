namespace OOP1
{
    partial class ManageFiguresDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.comboBoxFG = new System.Windows.Forms.ComboBox();
            this.txtVel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccelX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccelY = new System.Windows.Forms.TextBox();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtXSpawn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtYSpawn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtY2Spawn = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtX2Spawn = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(723, 329);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(149, 44);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(93, 385);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(149, 44);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // comboBoxFG
            // 
            this.comboBoxFG.FormattingEnabled = true;
            this.comboBoxFG.Location = new System.Drawing.Point(64, 52);
            this.comboBoxFG.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.comboBoxFG.Name = "comboBoxFG";
            this.comboBoxFG.Size = new System.Drawing.Size(239, 33);
            this.comboBoxFG.TabIndex = 2;
            // 
            // txtVel
            // 
            this.txtVel.Location = new System.Drawing.Point(425, 59);
            this.txtVel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtVel.Name = "txtVel";
            this.txtVel.Size = new System.Drawing.Size(196, 31);
            this.txtVel.TabIndex = 3;
            this.txtVel.Text = "100";
            this.txtVel.TextChanged += new System.EventHandler(this.txtVel_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Скорость";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(697, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Угол";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(697, 59);
            this.txtAngle.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(196, 31);
            this.txtAngle.TabIndex = 5;
            this.txtAngle.Text = "0";
            this.txtAngle.TextChanged += new System.EventHandler(this.txtAngle_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(425, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ускорение X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtAccelX
            // 
            this.txtAccelX.Location = new System.Drawing.Point(425, 191);
            this.txtAccelX.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtAccelX.Name = "txtAccelX";
            this.txtAccelX.Size = new System.Drawing.Size(196, 31);
            this.txtAccelX.TabIndex = 7;
            this.txtAccelX.Text = "0";
            this.txtAccelX.TextChanged += new System.EventHandler(this.txtAccelX_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(699, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ускорение Y";
            // 
            // txtAccelY
            // 
            this.txtAccelY.Location = new System.Drawing.Point(699, 186);
            this.txtAccelY.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtAccelY.Name = "txtAccelY";
            this.txtAccelY.Size = new System.Drawing.Size(196, 31);
            this.txtAccelY.TabIndex = 9;
            this.txtAccelY.Text = "0";
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(723, 385);
            this.btnDeleteAll.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(149, 90);
            this.btnDeleteAll.TabIndex = 11;
            this.btnDeleteAll.Text = "Удалить всё";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(425, 230);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Координата X";
            // 
            // txtXSpawn
            // 
            this.txtXSpawn.Location = new System.Drawing.Point(425, 266);
            this.txtXSpawn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtXSpawn.Name = "txtXSpawn";
            this.txtXSpawn.Size = new System.Drawing.Size(196, 31);
            this.txtXSpawn.TabIndex = 12;
            this.txtXSpawn.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(692, 230);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Координата Y";
            // 
            // txtYSpawn
            // 
            this.txtYSpawn.Location = new System.Drawing.Point(692, 266);
            this.txtYSpawn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtYSpawn.Name = "txtYSpawn";
            this.txtYSpawn.Size = new System.Drawing.Size(196, 31);
            this.txtYSpawn.TabIndex = 16;
            this.txtYSpawn.Text = "450";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 416);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Координата Y2";
            // 
            // txtY2Spawn
            // 
            this.txtY2Spawn.Location = new System.Drawing.Point(425, 448);
            this.txtY2Spawn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtY2Spawn.Name = "txtY2Spawn";
            this.txtY2Spawn.Size = new System.Drawing.Size(196, 31);
            this.txtY2Spawn.TabIndex = 20;
            this.txtY2Spawn.Text = "950";
            this.txtY2Spawn.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(425, 326);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "Координата X2";
            // 
            // txtX2Spawn
            // 
            this.txtX2Spawn.Location = new System.Drawing.Point(425, 362);
            this.txtX2Spawn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtX2Spawn.Name = "txtX2Spawn";
            this.txtX2Spawn.Size = new System.Drawing.Size(196, 31);
            this.txtX2Spawn.TabIndex = 18;
            this.txtX2Spawn.Text = "200";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(919, 342);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 52);
            this.button1.TabIndex = 22;
            this.button1.Text = "Тест";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ManageFiguresDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 498);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtY2Spawn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtX2Spawn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtYSpawn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtXSpawn);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAccelY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAccelX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVel);
            this.Controls.Add(this.comboBoxFG);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "ManageFiguresDialog";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.ManageFiguresDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox comboBoxFG;
        private System.Windows.Forms.TextBox txtVel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccelX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAccelY;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtXSpawn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtY2Spawn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtX2Spawn;
        private System.Windows.Forms.TextBox txtYSpawn;
        private System.Windows.Forms.Button button1;
    }
}