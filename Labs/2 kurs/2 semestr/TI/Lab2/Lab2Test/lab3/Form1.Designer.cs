namespace lab3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            OriginalText = new TextBox();
            OriginalKey = new TextBox();
            ResultKey = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            button2 = new Button();
            button3 = new Button();
            LoadFromFile = new TextBox();
            SaveToFile = new TextBox();
            label5 = new Label();
            ResultText = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1082, 264);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 0;
            button1.Text = "Расчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // OriginalText
            // 
            OriginalText.Location = new Point(190, 127);
            OriginalText.Name = "OriginalText";
            OriginalText.Size = new Size(200, 39);
            OriginalText.TabIndex = 1;
            // 
            // OriginalKey
            // 
            OriginalKey.Location = new Point(464, 127);
            OriginalKey.Name = "OriginalKey";
            OriginalKey.Size = new Size(200, 39);
            OriginalKey.TabIndex = 2;
            // 
            // ResultKey
            // 
            ResultKey.Location = new Point(766, 127);
            ResultKey.Name = "ResultKey";
            ResultKey.Size = new Size(200, 39);
            ResultKey.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(236, 74);
            label1.Name = "label1";
            label1.Size = new Size(171, 32);
            label1.TabIndex = 4;
            label1.Text = "Входной текст";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(524, 74);
            label2.Name = "label2";
            label2.Size = new Size(228, 32);
            label2.TabIndex = 5;
            label2.Text = "начальный регистр";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(826, 74);
            label3.Name = "label3";
            label3.Size = new Size(185, 32);
            label3.TabIndex = 6;
            label3.Text = "итоговый ключ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(414, 20);
            label4.Name = "label4";
            label4.Size = new Size(296, 32);
            label4.TabIndex = 7;
            label4.Text = "Введите входные данные";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // button2
            // 
            button2.Location = new Point(150, 296);
            button2.Name = "button2";
            button2.Size = new Size(296, 46);
            button2.TabIndex = 8;
            button2.Text = "Загрузить с файла";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(509, 296);
            button3.Name = "button3";
            button3.Size = new Size(283, 46);
            button3.TabIndex = 9;
            button3.Text = "Сохранить в файл";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // LoadFromFile
            // 
            LoadFromFile.Location = new Point(205, 228);
            LoadFromFile.Name = "LoadFromFile";
            LoadFromFile.Size = new Size(200, 39);
            LoadFromFile.TabIndex = 10;
            // 
            // SaveToFile
            // 
            SaveToFile.Location = new Point(524, 228);
            SaveToFile.Name = "SaveToFile";
            SaveToFile.Size = new Size(200, 39);
            SaveToFile.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1082, 61);
            label5.Name = "label5";
            label5.Size = new Size(186, 32);
            label5.TabIndex = 12;
            label5.Text = "Итоговый текст";
            // 
            // ResultText
            // 
            ResultText.Location = new Point(1051, 142);
            ResultText.Name = "ResultText";
            ResultText.Size = new Size(200, 39);
            ResultText.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1333, 774);
            Controls.Add(ResultText);
            Controls.Add(label5);
            Controls.Add(SaveToFile);
            Controls.Add(LoadFromFile);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ResultKey);
            Controls.Add(OriginalKey);
            Controls.Add(OriginalText);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox OriginalText;
        private TextBox OriginalKey;
        private TextBox ResultKey;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private OpenFileDialog openFileDialog3;
        private Button button2;
        private Button button3;
        private TextBox LoadFromFile;
        private TextBox SaveToFile;
        private Label label5;
        private TextBox ResultText;
    }
}