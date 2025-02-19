namespace Lab4
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
            Calculate = new Button();
            PValue = new Label();
            QValue = new Label();
            SecretKey = new Label();
            PValueBox = new TextBox();
            QValueBox = new TextBox();
            SecretKeyBox = new TextBox();
            OriginalTextBox = new TextBox();
            OriginalText = new Label();
            ResultTextBox = new TextBox();
            ResultText = new Label();
            Hash = new Label();
            Sign = new Label();
            HashBox = new TextBox();
            SignBox = new TextBox();
            PathLoadBox = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            LoadFile = new Button();
            CheckSign = new Button();
            ProcessedTextBox = new TextBox();
            ProcessedText = new Label();
            ResultCheckBox = new TextBox();
            FilePath = new Label();
            ResultCheck = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // Calculate
            // 
            Calculate.Location = new Point(1125, 491);
            Calculate.Name = "Calculate";
            Calculate.Size = new Size(150, 46);
            Calculate.TabIndex = 0;
            Calculate.Text = "Calculate";
            Calculate.UseVisualStyleBackColor = true;
            Calculate.Click += Calculate_Click;
            // 
            // PValue
            // 
            PValue.AutoSize = true;
            PValue.Location = new Point(513, 67);
            PValue.Name = "PValue";
            PValue.Size = new Size(85, 32);
            PValue.TabIndex = 1;
            PValue.Text = "PValue";
            // 
            // QValue
            // 
            QValue.AutoSize = true;
            QValue.Location = new Point(805, 67);
            QValue.Name = "QValue";
            QValue.Size = new Size(89, 32);
            QValue.TabIndex = 2;
            QValue.Text = "QValue";
            // 
            // SecretKey
            // 
            SecretKey.AutoSize = true;
            SecretKey.Location = new Point(1085, 67);
            SecretKey.Name = "SecretKey";
            SecretKey.Size = new Size(119, 32);
            SecretKey.TabIndex = 3;
            SecretKey.Text = "SecretKey";
            // 
            // PValueBox
            // 
            PValueBox.Location = new Point(467, 154);
            PValueBox.Name = "PValueBox";
            PValueBox.Size = new Size(200, 39);
            PValueBox.TabIndex = 4;
            // 
            // QValueBox
            // 
            QValueBox.Location = new Point(766, 154);
            QValueBox.Name = "QValueBox";
            QValueBox.Size = new Size(200, 39);
            QValueBox.TabIndex = 5;
            // 
            // SecretKeyBox
            // 
            SecretKeyBox.Location = new Point(1061, 154);
            SecretKeyBox.Name = "SecretKeyBox";
            SecretKeyBox.Size = new Size(200, 39);
            SecretKeyBox.TabIndex = 6;
            // 
            // OriginalTextBox
            // 
            OriginalTextBox.Location = new Point(149, 143);
            OriginalTextBox.Name = "OriginalTextBox";
            OriginalTextBox.Size = new Size(200, 39);
            OriginalTextBox.TabIndex = 7;
            // 
            // OriginalText
            // 
            OriginalText.AutoSize = true;
            OriginalText.Location = new Point(166, 79);
            OriginalText.Name = "OriginalText";
            OriginalText.Size = new Size(141, 32);
            OriginalText.TabIndex = 8;
            OriginalText.Text = "OriginalText";
            // 
            // ResultTextBox
            // 
            ResultTextBox.Location = new Point(394, 280);
            ResultTextBox.Name = "ResultTextBox";
            ResultTextBox.Size = new Size(347, 39);
            ResultTextBox.TabIndex = 9;
            // 
            // ResultText
            // 
            ResultText.AutoSize = true;
            ResultText.Location = new Point(502, 231);
            ResultText.Name = "ResultText";
            ResultText.Size = new Size(121, 32);
            ResultText.TabIndex = 10;
            ResultText.Text = "ResultText";
            // 
            // Hash
            // 
            Hash.AutoSize = true;
            Hash.Location = new Point(816, 215);
            Hash.Name = "Hash";
            Hash.Size = new Size(67, 32);
            Hash.TabIndex = 11;
            Hash.Text = "Hash";
            // 
            // Sign
            // 
            Sign.AutoSize = true;
            Sign.Location = new Point(1104, 215);
            Sign.Name = "Sign";
            Sign.Size = new Size(61, 32);
            Sign.TabIndex = 12;
            Sign.Text = "Sign";
            // 
            // HashBox
            // 
            HashBox.Location = new Point(766, 280);
            HashBox.Name = "HashBox";
            HashBox.Size = new Size(200, 39);
            HashBox.TabIndex = 13;
            // 
            // SignBox
            // 
            SignBox.Location = new Point(1061, 280);
            SignBox.Name = "SignBox";
            SignBox.Size = new Size(200, 39);
            SignBox.TabIndex = 14;
            // 
            // PathLoadBox
            // 
            PathLoadBox.Location = new Point(149, 418);
            PathLoadBox.Name = "PathLoadBox";
            PathLoadBox.Size = new Size(200, 39);
            PathLoadBox.TabIndex = 15;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // LoadFile
            // 
            LoadFile.Location = new Point(166, 505);
            LoadFile.Name = "LoadFile";
            LoadFile.Size = new Size(150, 46);
            LoadFile.TabIndex = 16;
            LoadFile.Text = "LoadFile";
            LoadFile.UseVisualStyleBackColor = true;
            LoadFile.Click += LoadFile_Click;
            // 
            // CheckSign
            // 
            CheckSign.Location = new Point(1125, 592);
            CheckSign.Name = "CheckSign";
            CheckSign.Size = new Size(150, 46);
            CheckSign.TabIndex = 17;
            CheckSign.Text = "CheckSign";
            CheckSign.UseVisualStyleBackColor = true;
            CheckSign.Click += CheckSign_Click;
            // 
            // ProcessedTextBox
            // 
            ProcessedTextBox.Location = new Point(149, 280);
            ProcessedTextBox.Name = "ProcessedTextBox";
            ProcessedTextBox.Size = new Size(200, 39);
            ProcessedTextBox.TabIndex = 18;
            // 
            // ProcessedText
            // 
            ProcessedText.AutoSize = true;
            ProcessedText.Location = new Point(178, 231);
            ProcessedText.Name = "ProcessedText";
            ProcessedText.Size = new Size(163, 32);
            ProcessedText.TabIndex = 19;
            ProcessedText.Text = "ProcessedText";
            // 
            // ResultCheckBox
            // 
            ResultCheckBox.Location = new Point(1061, 396);
            ResultCheckBox.Name = "ResultCheckBox";
            ResultCheckBox.Size = new Size(200, 39);
            ResultCheckBox.TabIndex = 20;
            // 
            // FilePath
            // 
            FilePath.AutoSize = true;
            FilePath.Location = new Point(197, 363);
            FilePath.Name = "FilePath";
            FilePath.Size = new Size(97, 32);
            FilePath.TabIndex = 21;
            FilePath.Text = "FilePath";
            // 
            // ResultCheck
            // 
            ResultCheck.AutoSize = true;
            ResultCheck.Location = new Point(1087, 342);
            ResultCheck.Name = "ResultCheck";
            ResultCheck.Size = new Size(143, 32);
            ResultCheck.TabIndex = 24;
            ResultCheck.Text = "ResultCheck";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(777, 396);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 39);
            textBox1.TabIndex = 25;
            textBox1.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1412, 860);
            Controls.Add(textBox1);
            Controls.Add(ResultCheck);
            Controls.Add(FilePath);
            Controls.Add(ResultCheckBox);
            Controls.Add(ProcessedText);
            Controls.Add(ProcessedTextBox);
            Controls.Add(CheckSign);
            Controls.Add(LoadFile);
            Controls.Add(PathLoadBox);
            Controls.Add(SignBox);
            Controls.Add(HashBox);
            Controls.Add(Sign);
            Controls.Add(Hash);
            Controls.Add(ResultText);
            Controls.Add(ResultTextBox);
            Controls.Add(OriginalText);
            Controls.Add(OriginalTextBox);
            Controls.Add(SecretKeyBox);
            Controls.Add(QValueBox);
            Controls.Add(PValueBox);
            Controls.Add(SecretKey);
            Controls.Add(QValue);
            Controls.Add(PValue);
            Controls.Add(Calculate);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Calculate;
        private Label PValue;
        private Label QValue;
        private Label SecretKey;
        private TextBox PValueBox;
        private TextBox QValueBox;
        private TextBox SecretKeyBox;
        private TextBox OriginalTextBox;
        private Label OriginalText;
        private TextBox ResultTextBox;
        private Label ResultText;
        private Label Hash;
        private Label Sign;
        private TextBox HashBox;
        private TextBox SignBox;
        private TextBox PathLoadBox;
        private OpenFileDialog openFileDialog1;
        private Button LoadFile;
        private Button CheckSign;
        private TextBox ProcessedTextBox;
        private Label ProcessedText;
        private TextBox ResultCheckBox;
        private Label FilePath;
        private Label ResultCheck;
        private TextBox textBox1;
    }
}