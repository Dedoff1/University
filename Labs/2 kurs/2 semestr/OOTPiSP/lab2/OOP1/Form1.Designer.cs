namespace OOP1
{
    partial class Form1
    {
        // другой сгенерированный код

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtAnchorX = new System.Windows.Forms.TextBox();
            this.txtAnchorY = new System.Windows.Forms.TextBox();
            this.btnCreateAnchor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnchorX2 = new System.Windows.Forms.TextBox();
            this.txtAnchorY2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.txtVel = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAccelX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAccelY = new System.Windows.Forms.TextBox();
            this.btnManageFigures = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(10, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1198, 582);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtAnchorX
            // 
            this.txtAnchorX.Location = new System.Drawing.Point(25, 29);
            this.txtAnchorX.Name = "txtAnchorX";
            this.txtAnchorX.Size = new System.Drawing.Size(77, 31);
            this.txtAnchorX.TabIndex = 1;
            this.txtAnchorX.Text = "5";
            this.txtAnchorX.TextChanged += new System.EventHandler(this.txtAnchorX_TextChanged);
            // 
            // txtAnchorY
            // 
            this.txtAnchorY.Location = new System.Drawing.Point(111, 29);
            this.txtAnchorY.Name = "txtAnchorY";
            this.txtAnchorY.Size = new System.Drawing.Size(74, 31);
            this.txtAnchorY.TabIndex = 2;
            this.txtAnchorY.Text = "5";
            this.txtAnchorY.TextChanged += new System.EventHandler(this.txtAnchorY_TextChanged);
            // 
            // btnCreateAnchor
            // 
            this.btnCreateAnchor.Location = new System.Drawing.Point(864, 27);
            this.btnCreateAnchor.Name = "btnCreateAnchor";
            this.btnCreateAnchor.Size = new System.Drawing.Size(89, 23);
            this.btnCreateAnchor.TabIndex = 3;
            this.btnCreateAnchor.Text = "Нарисовать";
            this.btnCreateAnchor.UseVisualStyleBackColor = true;
            this.btnCreateAnchor.Click += new System.EventHandler(this.btnCreateAnchor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Координата X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Координата Y";
            // 
            // txtAnchorX2
            // 
            this.txtAnchorX2.Location = new System.Drawing.Point(207, 29);
            this.txtAnchorX2.Name = "txtAnchorX2";
            this.txtAnchorX2.Size = new System.Drawing.Size(74, 31);
            this.txtAnchorX2.TabIndex = 6;
            this.txtAnchorX2.Text = "870";
            // 
            // txtAnchorY2
            // 
            this.txtAnchorY2.Location = new System.Drawing.Point(290, 29);
            this.txtAnchorY2.Name = "txtAnchorY2";
            this.txtAnchorY2.Size = new System.Drawing.Size(74, 31);
            this.txtAnchorY2.TabIndex = 7;
            this.txtAnchorY2.Text = "560";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Координата X2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Координата Y2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(502, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Градус";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(426, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Скорость";
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(505, 29);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(70, 31);
            this.txtAngle.TabIndex = 11;
            this.txtAngle.Text = "0";
            // 
            // txtVel
            // 
            this.txtVel.Location = new System.Drawing.Point(429, 29);
            this.txtVel.Name = "txtVel";
            this.txtVel.Size = new System.Drawing.Size(70, 31);
            this.txtVel.TabIndex = 10;
            this.txtVel.Text = "0";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(959, 27);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(117, 23);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Начать движение";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(791, 30);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(28, 27);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(757, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Ускорение от и до";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1082, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(49, 31);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "60";
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1092, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 25);
            this.label8.TabIndex = 18;
            this.label8.Text = "FPS";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(575, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 25);
            this.label9.TabIndex = 20;
            this.label9.Text = "Ускорение X";
            // 
            // txtAccelX
            // 
            this.txtAccelX.Location = new System.Drawing.Point(578, 29);
            this.txtAccelX.Name = "txtAccelX";
            this.txtAccelX.Size = new System.Drawing.Size(70, 31);
            this.txtAccelX.TabIndex = 19;
            this.txtAccelX.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(654, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 25);
            this.label10.TabIndex = 22;
            this.label10.Text = "Ускорение Y";
            // 
            // txtAccelY
            // 
            this.txtAccelY.Location = new System.Drawing.Point(657, 29);
            this.txtAccelY.Name = "txtAccelY";
            this.txtAccelY.Size = new System.Drawing.Size(70, 31);
            this.txtAccelY.TabIndex = 21;
            this.txtAccelY.Text = "0";
            // 
            // btnManageFigures
            // 
            this.btnManageFigures.Location = new System.Drawing.Point(1137, 27);
            this.btnManageFigures.Name = "btnManageFigures";
            this.btnManageFigures.Size = new System.Drawing.Size(75, 23);
            this.btnManageFigures.TabIndex = 23;
            this.btnManageFigures.Text = "Изменить";
            this.btnManageFigures.UseVisualStyleBackColor = true;
            this.btnManageFigures.Click += new System.EventHandler(this.btnManageFigures_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1218, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Меню";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1330, 640);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnManageFigures);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtAccelY);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAccelX);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.txtVel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAnchorY2);
            this.Controls.Add(this.txtAnchorX2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreateAnchor);
            this.Controls.Add(this.txtAnchorY);
            this.Controls.Add(this.txtAnchorX);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtAnchorX;
        private System.Windows.Forms.TextBox txtAnchorY;
        private System.Windows.Forms.Button btnCreateAnchor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnchorX2;
        private System.Windows.Forms.TextBox txtAnchorY2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.TextBox txtVel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAccelX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAccelY;
        private System.Windows.Forms.Button btnManageFigures;
        private System.Windows.Forms.Button button1;
    }
}

