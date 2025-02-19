namespace WinFormsApp1
{
    partial class Form2
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
            button1 = new Button();
            colorDialog1 = new ColorDialog();
            textBoxName = new TextBox();
            label1 = new Label();
            comboBoxFont = new ComboBox();
            comboBoxFigure = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            textBoxdx = new TextBox();
            textBoxdy = new TextBox();
            label6 = new Label();
            label7 = new Label();
            textBoxWidth = new TextBox();
            textBoxHeight = new TextBox();
            pictureBoxMainColor = new PictureBox();
            button2 = new Button();
            label8 = new Label();
            textBoxBorderSize = new TextBox();
            button3 = new Button();
            pictureBoxBorderColor = new PictureBox();
            colorDialog2 = new ColorDialog();
            label9 = new Label();
            textBoxTextSize = new TextBox();
            button4 = new Button();
            pictureBoxTextColor = new PictureBox();
            label10 = new Label();
            label11 = new Label();
            textBoxX = new TextBox();
            textBoxY = new TextBox();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMainColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBorderColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTextColor).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(418, 305);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(164, 9);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(224, 27);
            textBoxName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 12);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 2;
            label1.Text = "Текст";
            label1.Click += label1_Click;
            // 
            // comboBoxFont
            // 
            comboBoxFont.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFont.FormattingEnabled = true;
            comboBoxFont.Items.AddRange(new object[] { "Arial", "Times New Roman", "Segoe UI" });
            comboBoxFont.Location = new Point(164, 89);
            comboBoxFont.Name = "comboBoxFont";
            comboBoxFont.Size = new Size(224, 28);
            comboBoxFont.TabIndex = 3;
            // 
            // comboBoxFigure
            // 
            comboBoxFigure.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFigure.FormattingEnabled = true;
            comboBoxFigure.Items.AddRange(new object[] { "Прямоугольник", "Квадрат", "Круг", "Эллипс", "Треугольник" });
            comboBoxFigure.Location = new Point(164, 123);
            comboBoxFigure.Name = "comboBoxFigure";
            comboBoxFigure.Size = new Size(224, 28);
            comboBoxFigure.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 95);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 5;
            label2.Text = "Шрифт";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 126);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 6;
            label3.Text = "Фигура";
            // 
            // textBoxdx
            // 
            textBoxdx.Location = new Point(559, 196);
            textBoxdx.Name = "textBoxdx";
            textBoxdx.Size = new Size(224, 27);
            textBoxdx.TabIndex = 7;
            // 
            // textBoxdy
            // 
            textBoxdy.Location = new Point(559, 229);
            textBoxdy.Name = "textBoxdy";
            textBoxdy.Size = new Size(224, 27);
            textBoxdy.TabIndex = 8;
            textBoxdy.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(446, 11);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 11;
            label6.Text = "width";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(444, 44);
            label7.Name = "label7";
            label7.Size = new Size(51, 20);
            label7.TabIndex = 12;
            label7.Text = "height";
            // 
            // textBoxWidth
            // 
            textBoxWidth.Location = new Point(559, 5);
            textBoxWidth.Name = "textBoxWidth";
            textBoxWidth.Size = new Size(224, 27);
            textBoxWidth.TabIndex = 13;
            // 
            // textBoxHeight
            // 
            textBoxHeight.Location = new Point(559, 38);
            textBoxHeight.Name = "textBoxHeight";
            textBoxHeight.Size = new Size(224, 27);
            textBoxHeight.TabIndex = 14;
            // 
            // pictureBoxMainColor
            // 
            pictureBoxMainColor.BackColor = SystemColors.MenuHighlight;
            pictureBoxMainColor.Location = new Point(164, 219);
            pictureBoxMainColor.Name = "pictureBoxMainColor";
            pictureBoxMainColor.Size = new Size(224, 24);
            pictureBoxMainColor.TabIndex = 15;
            pictureBoxMainColor.TabStop = false;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(12, 220);
            button2.Name = "button2";
            button2.Size = new Size(126, 24);
            button2.TabIndex = 16;
            button2.Text = "color";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(418, 74);
            label8.Name = "label8";
            label8.Size = new Size(115, 20);
            label8.TabIndex = 17;
            label8.Text = "Ширина рамки";
            label8.Click += label8_Click;
            // 
            // textBoxBorderSize
            // 
            textBoxBorderSize.Location = new Point(559, 74);
            textBoxBorderSize.Name = "textBoxBorderSize";
            textBoxBorderSize.Size = new Size(224, 27);
            textBoxBorderSize.TabIndex = 18;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(12, 176);
            button3.Name = "button3";
            button3.Size = new Size(124, 25);
            button3.TabIndex = 19;
            button3.Text = "Цвет рамки";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pictureBoxBorderColor
            // 
            pictureBoxBorderColor.BackColor = SystemColors.ControlDark;
            pictureBoxBorderColor.Location = new Point(164, 175);
            pictureBoxBorderColor.Name = "pictureBoxBorderColor";
            pictureBoxBorderColor.Size = new Size(224, 26);
            pictureBoxBorderColor.TabIndex = 20;
            pictureBoxBorderColor.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(32, 52);
            label9.Name = "label9";
            label9.Size = new Size(106, 20);
            label9.TabIndex = 21;
            label9.Text = "Размер текста";
            // 
            // textBoxTextSize
            // 
            textBoxTextSize.Location = new Point(164, 49);
            textBoxTextSize.Name = "textBoxTextSize";
            textBoxTextSize.Size = new Size(224, 27);
            textBoxTextSize.TabIndex = 22;
            // 
            // button4
            // 
            button4.Location = new Point(12, 250);
            button4.Name = "button4";
            button4.Size = new Size(126, 29);
            button4.TabIndex = 23;
            button4.Text = "цвет текста";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // pictureBoxTextColor
            // 
            pictureBoxTextColor.BackColor = SystemColors.ActiveCaptionText;
            pictureBoxTextColor.Location = new Point(164, 249);
            pictureBoxTextColor.Name = "pictureBoxTextColor";
            pictureBoxTextColor.Size = new Size(224, 29);
            pictureBoxTextColor.TabIndex = 24;
            pictureBoxTextColor.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(434, 115);
            label10.Name = "label10";
            label10.Size = new Size(18, 20);
            label10.TabIndex = 25;
            label10.Text = "X";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(434, 156);
            label11.Name = "label11";
            label11.Size = new Size(17, 20);
            label11.TabIndex = 26;
            label11.Text = "Y";
            // 
            // textBoxX
            // 
            textBoxX.Location = new Point(559, 112);
            textBoxX.Name = "textBoxX";
            textBoxX.Size = new Size(224, 27);
            textBoxX.TabIndex = 27;
            // 
            // textBoxY
            // 
            textBoxY.Location = new Point(559, 153);
            textBoxY.Name = "textBoxY";
            textBoxY.Size = new Size(224, 27);
            textBoxY.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(424, 203);
            label4.Name = "label4";
            label4.Size = new Size(27, 20);
            label4.TabIndex = 29;
            label4.Text = "dX";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(424, 236);
            label5.Name = "label5";
            label5.Size = new Size(26, 20);
            label5.TabIndex = 30;
            label5.Text = "dY";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 369);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBoxY);
            Controls.Add(textBoxX);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(pictureBoxTextColor);
            Controls.Add(button4);
            Controls.Add(textBoxTextSize);
            Controls.Add(label9);
            Controls.Add(pictureBoxBorderColor);
            Controls.Add(button3);
            Controls.Add(textBoxBorderSize);
            Controls.Add(label8);
            Controls.Add(button2);
            Controls.Add(pictureBoxMainColor);
            Controls.Add(textBoxHeight);
            Controls.Add(textBoxWidth);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textBoxdy);
            Controls.Add(textBoxdx);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBoxFigure);
            Controls.Add(comboBoxFont);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            Controls.Add(button1);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Изменение";
            ((System.ComponentModel.ISupportInitialize)pictureBoxMainColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBorderColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTextColor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ColorDialog colorDialog1;
        private TextBox textBoxName;
        private Label label1;
        private ComboBox comboBoxFont;
        private ComboBox comboBoxFigure;
        private Label label2;
        private Label label3;
        private TextBox textBoxdx;
        private TextBox textBoxdy;
        private Label label6;
        private Label label7;
        private TextBox textBoxWidth;
        private TextBox textBoxHeight;
        private PictureBox pictureBoxMainColor;
        private Button button2;
        private Label label8;
        private TextBox textBoxBorderSize;
        private Button button3;
        private PictureBox pictureBoxBorderColor;
        private ColorDialog colorDialog2;
        private Label label9;
        private TextBox textBoxTextSize;
        private Button button4;
        private PictureBox pictureBoxTextColor;
        private Label label10;
        private Label label11;
        private TextBox textBoxX;
        private TextBox textBoxY;
        private Label label4;
        private Label label5;
    }
}