namespace LabTU3GUI
{
    public partial class Form1
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
            rTBG = new RichTextBox();
            rBP = new TextBox();
            tBG = new TextBox();
            tBX = new TextBox();
            tBK = new TextBox();
            tBY = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            rTBT = new RichTextBox();
            rTBR = new RichTextBox();
            label7 = new Label();
            label8 = new Label();
            btnStart = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            CB2 = new ComboBox();
            button1 = new Button();
            btnLoad = new Button();
            oFD1 = new OpenFileDialog();
            button2 = new Button();
            sFD1 = new SaveFileDialog();
            tBNum = new TextBox();
            Clear = new Button();
            SuspendLayout();
            // 
            // rTBG
            // 
            rTBG.Location = new Point(40, 102);
            rTBG.Margin = new Padding(5);
            rTBG.Name = "rTBG";
            rTBG.ReadOnly = true;
            rTBG.Size = new Size(1218, 108);
            rTBG.TabIndex = 0;
            rTBG.Text = "";
            // 
            // rBP
            // 
            rBP.Location = new Point(147, 53);
            rBP.Margin = new Padding(5);
            rBP.Name = "rBP";
            rBP.Size = new Size(103, 39);
            rBP.TabIndex = 1;
            rBP.Click += rBP_Click;
            // 
            // tBG
            // 
            tBG.Location = new Point(308, 268);
            tBG.Margin = new Padding(5);
            tBG.Name = "tBG";
            tBG.Size = new Size(98, 39);
            tBG.TabIndex = 2;
            // 
            // tBX
            // 
            tBX.Location = new Point(308, 53);
            tBX.Margin = new Padding(5);
            tBX.Name = "tBX";
            tBX.Size = new Size(105, 39);
            tBX.TabIndex = 3;
            // 
            // tBK
            // 
            tBK.Location = new Point(477, 53);
            tBK.Margin = new Padding(5);
            tBK.Name = "tBK";
            tBK.Size = new Size(98, 39);
            tBK.TabIndex = 4;
            // 
            // tBY
            // 
            tBY.Location = new Point(551, 268);
            tBY.Margin = new Padding(5);
            tBY.Name = "tBY";
            tBY.ReadOnly = true;
            tBY.Size = new Size(103, 39);
            tBY.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 39);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(118, 32);
            label1.TabIndex = 6;
            label1.Text = "Parametrs";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(179, 9);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(27, 32);
            label2.TabIndex = 7;
            label2.Text = "P";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(334, 215);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(30, 32);
            label3.TabIndex = 8;
            label3.Text = "G";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(347, 9);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(28, 32);
            label4.TabIndex = 9;
            label4.Text = "X";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(501, 9);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(28, 32);
            label5.TabIndex = 10;
            label5.Text = "K";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(581, 220);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(27, 32);
            label6.TabIndex = 11;
            label6.Text = "Y";
            // 
            // rTBT
            // 
            rTBT.Location = new Point(58, 400);
            rTBT.Margin = new Padding(5);
            rTBT.Name = "rTBT";
            rTBT.ReadOnly = true;
            rTBT.Size = new Size(1211, 166);
            rTBT.TabIndex = 12;
            rTBT.Text = "";
            // 
            // rTBR
            // 
            rTBR.Location = new Point(58, 654);
            rTBR.Margin = new Padding(5);
            rTBR.Name = "rTBR";
            rTBR.ReadOnly = true;
            rTBR.Size = new Size(1211, 186);
            rTBR.TabIndex = 13;
            rTBR.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(58, 363);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(148, 32);
            label7.TabIndex = 15;
            label7.Text = "Original Text";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(65, 618);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(128, 32);
            label8.TabIndex = 16;
            label8.Text = "Result Text";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(1050, 262);
            btnStart.Margin = new Padding(5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(153, 46);
            btnStart.TabIndex = 17;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += button1_Click;
            // 
            // CB2
            // 
            CB2.DropDownStyle = ComboBoxStyle.DropDownList;
            CB2.Items.AddRange(new object[] { "Encrypt", "Decrypt" });
            CB2.Location = new Point(728, 268);
            CB2.Margin = new Padding(5);
            CB2.Name = "CB2";
            CB2.Size = new Size(275, 40);
            CB2.TabIndex = 18;
            CB2.SelectedIndexChanged += CB2_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(728, 43);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(153, 46);
            button1.TabIndex = 19;
            button1.Text = "Calculate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(260, 349);
            btnLoad.Margin = new Padding(5);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(153, 46);
            btnLoad.TabIndex = 20;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // oFD1
            // 
            oFD1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            button2.Location = new Point(260, 604);
            button2.Margin = new Padding(5);
            button2.Name = "button2";
            button2.Size = new Size(153, 46);
            button2.TabIndex = 21;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tBNum
            // 
            tBNum.Location = new Point(108, 269);
            tBNum.Margin = new Padding(5);
            tBNum.Name = "tBNum";
            tBNum.ReadOnly = true;
            tBNum.Size = new Size(98, 39);
            tBNum.TabIndex = 22;
            // 
            // Clear
            // 
            Clear.Location = new Point(1050, 333);
            Clear.Name = "Clear";
            Clear.Size = new Size(153, 46);
            Clear.TabIndex = 23;
            Clear.Text = "Clear";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += Clear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1306, 888);
            Controls.Add(Clear);
            Controls.Add(tBNum);
            Controls.Add(button2);
            Controls.Add(btnLoad);
            Controls.Add(button1);
            Controls.Add(CB2);
            Controls.Add(btnStart);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(rTBR);
            Controls.Add(rTBT);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tBY);
            Controls.Add(tBK);
            Controls.Add(tBX);
            Controls.Add(tBG);
            Controls.Add(rBP);
            Controls.Add(rTBG);
            Margin = new Padding(5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rTBG;
        private TextBox rBP;
        private TextBox tBG;
        private TextBox tBX;
        private TextBox tBK;
        private TextBox tBY;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        public RichTextBox rTBT;
        public RichTextBox rTBR;
        private Label label7;
        private Label label8;
        private Button btnStart;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ComboBox CB2;
        private Button button1;
        private Button btnLoad;
        private OpenFileDialog oFD1;
        private Button button2;
        private SaveFileDialog sFD1;
        private TextBox tBNum;
        private Button Clear;
    }
}